using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SonicOrca.Resources
{
	// Token: 0x0200000C RID: 12
	public class ResourceSession : IDisposable
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002EEC File Offset: 0x000010EC
		public ResourceTree ResourceTree
		{
			get
			{
				return this._resourceTree;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002EF4 File Offset: 0x000010F4
		public ResourceSession(ResourceTree tree)
		{
			this._resourceTree = tree;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002F2F File Offset: 0x0000112F
		public void Dispose()
		{
			this.Unload();
			this._disposed = true;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002F40 File Offset: 0x00001140
		public void PushDependencies(IEnumerable<string> fullKeyPaths)
		{
			foreach (string fullKeyPath in fullKeyPaths)
			{
				this.PushDependency(fullKeyPath);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002F88 File Offset: 0x00001188
		public void PushDependencies(params string[] fullKeyPaths)
		{
			foreach (string fullKeyPath in fullKeyPaths)
			{
				this.PushDependency(fullKeyPath);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002FB0 File Offset: 0x000011B0
		public void PushDependency(string fullKeyPath)
		{
			ResourceTree.Node node = this._resourceTree[fullKeyPath];
			Resource resource;
			if (node == null)
			{
				if (!fullKeyPath.StartsWith("$"))
				{
					throw new ResourceException(string.Format("Resource node not found, {0}.", fullKeyPath));
				}
				resource = Resource.FromFile(fullKeyPath.Substring(1));
			}
			else
			{
				resource = node.Resource;
			}
			if (resource == null)
			{
				throw new ResourceException(string.Format("Resource node has no resource or has missing resource type loader, {0}.", fullKeyPath));
			}
			this.PushDependency(resource);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000301C File Offset: 0x0000121C
		public void PushDependency(Resource resource)
		{
			this.CheckDisposed();
			object unloadedResourcesSync = this._unloadedResourcesSync;
			lock (unloadedResourcesSync)
			{
				if (!this._unloadedResources.Contains(resource) && !this._intermediateResources.Contains(resource) && !this._loadedResources.Contains(resource))
				{
					this._unloadedResources.Add(resource);
				}
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003098 File Offset: 0x00001298
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken), bool serial = false)
		{
			ResourceSession.<>c__DisplayClass14_0 CS$<>8__locals1 = new ResourceSession.<>c__DisplayClass14_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.ct = ct;
			this.CheckDisposed();
			CS$<>8__locals1.localLoaded = new HashSet<Resource>();
			CS$<>8__locals1.localLoadedSync = new object();
			try
			{
				while (this._unloadedResources.Count > 0)
				{
					this._intermediateResources.Clear();
					this._intermediateResources.UnionWith(this._unloadedResources);
					this._unloadedResources.Clear();
					if (serial)
					{
						foreach (Resource resource4 in this._intermediateResources)
						{
							await resource4.LoadAsync(this, CS$<>8__locals1.ct, 0);
							CS$<>8__locals1.localLoaded.Add(resource4);
							resource4 = null;
						}
						HashSet<Resource>.Enumerator enumerator = default(HashSet<Resource>.Enumerator);
					}
					else
					{
						await Task.WhenAll(this._intermediateResources.Select(delegate(Resource resource)
						{
							ResourceSession.<>c__DisplayClass14_1 CS$<>8__locals2 = new ResourceSession.<>c__DisplayClass14_1();
							CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
							CS$<>8__locals2.resource = resource;
							return Task.Run(delegate()
							{
								ResourceSession.<>c__DisplayClass14_1.<<LoadAsync>b__1>d <<LoadAsync>b__1>d;
								<<LoadAsync>b__1>d.<>4__this = CS$<>8__locals2;
								<<LoadAsync>b__1>d.<>t__builder = AsyncTaskMethodBuilder.Create();
								<<LoadAsync>b__1>d.<>1__state = -1;
								AsyncTaskMethodBuilder <>t__builder = <<LoadAsync>b__1>d.<>t__builder;
								<>t__builder.Start<ResourceSession.<>c__DisplayClass14_1.<<LoadAsync>b__1>d>(ref <<LoadAsync>b__1>d);
								return <<LoadAsync>b__1>d.<>t__builder.Task;
							});
						}).ToArray<Task>());
					}
				}
				foreach (Resource resource2 in from r in CS$<>8__locals1.localLoaded
				where r.DependencyCount == 1
				select r)
				{
					resource2.LoadedResource.OnLoaded();
				}
				this._loadedResources.UnionWith(CS$<>8__locals1.localLoaded);
			}
			catch (Exception)
			{
				HashSet<Resource>.Enumerator enumerator3 = CS$<>8__locals1.localLoaded.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						Resource resource3 = enumerator3.Current;
						resource3.Unload(0);
					}
				}
				finally
				{
					int num;
					if (num < 0)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				throw;
			}
			finally
			{
				this._intermediateResources.Clear();
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000030F0 File Offset: 0x000012F0
		public void Unload()
		{
			this.CheckDisposed();
			foreach (Resource resource in from r in this._loadedResources
			where r.LoadedResource != null
			select r)
			{
				resource.Unload(0);
			}
			this._loadedResources.Clear();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003170 File Offset: 0x00001370
		private void CheckDisposed()
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException(typeof(ResourceSession).Name);
			}
		}

		// Token: 0x0400002C RID: 44
		private readonly ResourceTree _resourceTree;

		// Token: 0x0400002D RID: 45
		private readonly HashSet<Resource> _unloadedResources = new HashSet<Resource>();

		// Token: 0x0400002E RID: 46
		private readonly HashSet<Resource> _intermediateResources = new HashSet<Resource>();

		// Token: 0x0400002F RID: 47
		private readonly HashSet<Resource> _loadedResources = new HashSet<Resource>();

		// Token: 0x04000030 RID: 48
		private bool _disposed;

		// Token: 0x04000031 RID: 49
		private object _unloadedResourcesSync = new object();
	}
}
