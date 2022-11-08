using System;
using System.Collections.Generic;
using System.IO;

namespace SonicOrca.Resources
{
	// Token: 0x02000009 RID: 9
	public sealed class ResourceLoadArgs
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002C42 File Offset: 0x00000E42
		public ResourceTree ResourceTree
		{
			get
			{
				return this._resourceTree;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002C4A File Offset: 0x00000E4A
		public Resource Resource
		{
			get
			{
				return this._resource;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002C52 File Offset: 0x00000E52
		public Stream InputStream
		{
			get
			{
				return this._inputStream;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002C5A File Offset: 0x00000E5A
		public IReadOnlyCollection<Resource> Dependencies
		{
			get
			{
				return this._dependencies.Instance;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002C67 File Offset: 0x00000E67
		public ResourceLoadArgs(ResourceTree resourceTree, Resource resource, Stream inputStream)
		{
			this._resourceTree = resourceTree;
			this._resource = resource;
			this._inputStream = inputStream;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002C94 File Offset: 0x00000E94
		public void PushDependencies(IEnumerable<string> fullKeyPaths)
		{
			foreach (string fullKeyPath in fullKeyPaths)
			{
				this.PushDependency(fullKeyPath);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002CDC File Offset: 0x00000EDC
		public void PushDependencies(params string[] fullKeyPaths)
		{
			foreach (string fullKeyPath in fullKeyPaths)
			{
				this.PushDependency(fullKeyPath);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002D04 File Offset: 0x00000F04
		public void PushDependency(string fullKeyPath)
		{
			ResourceTree.Node node = this._resourceTree[fullKeyPath];
			if (node == null)
			{
				if (!fullKeyPath.StartsWith("$"))
				{
					throw new ResourceException(string.Format("Resource node not found, {0}.", fullKeyPath));
				}
				node = this._resourceTree.SetOrAddFromFile(fullKeyPath.Substring(1));
			}
			Resource resource = node.Resource;
			if (resource == null)
			{
				throw new ResourceException(string.Format("Resource node has no resource or has missing resource type loader, {0}.", fullKeyPath));
			}
			this.PushDependency(resource);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002D78 File Offset: 0x00000F78
		private void PushDependency(Resource resource)
		{
			object sync = this._dependencies.Sync;
			lock (sync)
			{
				this._dependencies.Instance.Add(resource);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002DC8 File Offset: 0x00000FC8
		public string GetAbsolutePath(string keyPath)
		{
			return this._resource.GetAbsolutePath(keyPath);
		}

		// Token: 0x04000027 RID: 39
		private readonly ResourceTree _resourceTree;

		// Token: 0x04000028 RID: 40
		private readonly Resource _resource;

		// Token: 0x04000029 RID: 41
		private readonly Stream _inputStream;

		// Token: 0x0400002A RID: 42
		private readonly Lockable<List<Resource>> _dependencies = new Lockable<List<Resource>>(new List<Resource>());
	}
}
