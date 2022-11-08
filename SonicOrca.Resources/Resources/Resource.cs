using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SonicOrca.Resources
{
	// Token: 0x02000005 RID: 5
	public sealed class Resource : IDisposable
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021D4 File Offset: 0x000003D4
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000021DB File Offset: 0x000003DB
		public static int LoadedResourceCount { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000021E3 File Offset: 0x000003E3
		public string FullKeyPath
		{
			get
			{
				return this._fullKeyPath;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000021EB File Offset: 0x000003EB
		public ResourceTypeIdentifier Identifier
		{
			get
			{
				return this._identifier;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000021F3 File Offset: 0x000003F3
		public ResourceSource Source
		{
			get
			{
				return this._source;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000021FB File Offset: 0x000003FB
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002203 File Offset: 0x00000403
		public ILoadedResource LoadedResource { get; private set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000220C File Offset: 0x0000040C
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002214 File Offset: 0x00000414
		public int DependencyCount { get; private set; }

		// Token: 0x06000015 RID: 21 RVA: 0x0000221D File Offset: 0x0000041D
		public Resource(string fullKeyPath, ResourceTypeIdentifier identifier, ResourceSource source)
		{
			this._fullKeyPath = fullKeyPath;
			this._identifier = identifier;
			this._source = source;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002257 File Offset: 0x00000457
		public void Dispose()
		{
			this._loadSemaphore.Dispose();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002264 File Offset: 0x00000464
		public override string ToString()
		{
			return string.Format("{0} Loaded = {1} DependencyCount = {2}", this.Identifier, this.LoadedResource != null, this.DependencyCount);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002294 File Offset: 0x00000494
		public async Task LoadAsync(ResourceSession session, CancellationToken ct = default(CancellationToken), int level = 0)
		{
			this._loadSemaphore.WaitOne();
			if (this.LoadedResource == null)
			{
				ResourceType resourceType = ResourceType.FromIdentifier(this.Identifier);
				if (resourceType == null)
				{
					throw new ResourceException(string.Format("No registered resource type, {0}", this.Identifier));
				}
				using (Stream uncompressedStream = this.Source.ReadUncompressed())
				{
					ResourceLoadArgs loadArguments = new ResourceLoadArgs(session.ResourceTree, this, uncompressedStream);
					try
					{
						ILoadedResource loadedResource = await resourceType.LoadAsync(loadArguments, ct);
						this.LoadedResource = loadedResource;
						if (!Environment.Is64BitProcess)
						{
							using (IEnumerator<Resource> enumerator = loadArguments.Dependencies.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									Resource resource = enumerator.Current;
									this.LoadChildResourceAsync(session, resource, level, ct).Wait();
								}
								goto IL_260;
							}
						}
						await Task.WhenAll((from x in loadArguments.Dependencies
						select this.LoadChildResourceAsync(session, x, level, ct)).ToArray<Task>());
						IL_260:;
					}
					catch (Exception)
					{
						throw;
					}
					loadArguments = null;
				}
				Stream uncompressedStream = null;
				this.DependencyCount = 1;
				Resource.LoadedResourceCount++;
			}
			else
			{
				this.DependencyCount++;
			}
			this._loadSemaphore.Release();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000022F4 File Offset: 0x000004F4
		private async Task LoadChildResourceAsync(ResourceSession session, Resource resource, int level, CancellationToken ct = default(CancellationToken))
		{
			bool resourceWasLoaded = resource.LoadedResource != null;
			await resource.LoadAsync(session, ct, level + 1);
			if (!resourceWasLoaded)
			{
				resource.LoadedResource.OnLoaded();
			}
			object sync = this._childResources.Sync;
			lock (sync)
			{
				this._childResources.Instance.Add(resource);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000235C File Offset: 0x0000055C
		public void Unload(int level = 0)
		{
			this._loadSemaphore.WaitOne();
			if (this.LoadedResource != null)
			{
				if (this.DependencyCount == 1)
				{
					foreach (Resource resource in this._childResources.Instance)
					{
						resource.Unload(level + 1);
					}
					this._childResources.Instance.Clear();
					this.LoadedResource.Dispose();
					this.LoadedResource = null;
					this.DependencyCount = 0;
					Resource.LoadedResourceCount--;
				}
				else
				{
					int dependencyCount = this.DependencyCount;
					this.DependencyCount = dependencyCount - 1;
				}
			}
			this._loadSemaphore.Release();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002428 File Offset: 0x00000628
		public void Export(string path)
		{
			byte[] array = new byte[1024];
			using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
			{
				using (Stream stream = this.Source.ReadUncompressed())
				{
					int num;
					do
					{
						num = stream.Read(array, 0, array.Length);
						fileStream.Write(array, 0, num);
					}
					while (num != 0);
				}
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000024A0 File Offset: 0x000006A0
		public static Resource FromFile(string path)
		{
			path = Path.GetFullPath(path);
			string fullKeyPath = "$" + path;
			ResourceTypeIdentifier identifier = ResourceType.FromPath(path).Identifier;
			ResourceSource source = new FileResourceSource(path, 0L, new FileInfo(path).Length, false);
			return new Resource(fullKeyPath, identifier, source);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024E8 File Offset: 0x000006E8
		public static Resource FromFile(string path, string fullResourceKeyPath)
		{
			return new Resource(fullResourceKeyPath, ResourceType.FromPath(path).Identifier, new FileResourceSource(path, 0L, new FileInfo(path).Length, false));
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002510 File Offset: 0x00000710
		public string GetAbsolutePath(string keyPath)
		{
			if (keyPath.StartsWith("/"))
			{
				if (this._fullKeyPath.StartsWith("$"))
				{
					return ResourcePath.GetRelativeFileResourceFromAbsolute(this._fullKeyPath, keyPath);
				}
				keyPath = this._fullKeyPath + keyPath;
				Stack<string> stack = new Stack<string>();
				int num;
				while ((num = keyPath.IndexOf('/')) != -1)
				{
					if (num == 0)
					{
						keyPath = keyPath.Substring(1);
						if (stack.Count > 0)
						{
							stack.Pop();
						}
					}
					else
					{
						stack.Push(keyPath.Substring(0, num));
						keyPath = keyPath.Substring(num + 1);
					}
				}
				stack.Push(keyPath);
				keyPath = string.Join("/", stack.ToArray().Reverse<string>());
			}
			return keyPath;
		}

		// Token: 0x04000005 RID: 5
		private readonly Lockable<List<Resource>> _childResources = new Lockable<List<Resource>>(new List<Resource>());

		// Token: 0x04000006 RID: 6
		private readonly Semaphore _loadSemaphore = new Semaphore(1, 1);

		// Token: 0x04000007 RID: 7
		private readonly string _fullKeyPath;

		// Token: 0x04000008 RID: 8
		private readonly ResourceTypeIdentifier _identifier;

		// Token: 0x04000009 RID: 9
		private readonly ResourceSource _source;
	}
}
