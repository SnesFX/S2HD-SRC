using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SonicOrca.Resources
{
	// Token: 0x0200000E RID: 14
	public class ResourceTree : IEnumerable<ResourceTree.Node>, IEnumerable
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003379 File Offset: 0x00001579
		public ResourceTree.Node Head
		{
			get
			{
				return this._head;
			}
		}

		// Token: 0x17000016 RID: 22
		public ResourceTree.Node this[string fullKeyPath]
		{
			get
			{
				if (string.IsNullOrEmpty(fullKeyPath))
				{
					return null;
				}
				ResourceTree.Node node = this._head;
				foreach (string key in fullKeyPath.Split(new char[]
				{
					'/'
				}))
				{
					if ((node = node[key]) == null)
					{
						break;
					}
				}
				return node;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000033D4 File Offset: 0x000015D4
		public ResourceTree.Node GetOrAdd(string fullKeyPath)
		{
			ResourceTree.Node node = this._head;
			foreach (string key in fullKeyPath.Split(new char[]
			{
				'/'
			}))
			{
				node = node.GetOrAdd(key);
			}
			return node;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003415 File Offset: 0x00001615
		public ResourceTree.Node SetOrAdd(string fullKeyPath, Resource resource)
		{
			ResourceTree.Node orAdd = this.GetOrAdd(fullKeyPath);
			orAdd.Resource = resource;
			return orAdd;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003425 File Offset: 0x00001625
		public ResourceTree.Node SetOrAddFromFile(string resourcePath)
		{
			return this.SetOrAdd("$" + resourcePath, Resource.FromFile(resourcePath));
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000343E File Offset: 0x0000163E
		public ResourceTree.Node SetOrAddFromFile(string fullKeyPath, string resourcePath)
		{
			return this.SetOrAdd(fullKeyPath, Resource.FromFile(resourcePath, fullKeyPath));
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003450 File Offset: 0x00001650
		public ILoadedResource GetLoadedResource(string fullKeyPath)
		{
			ResourceTree.Node node = this[fullKeyPath];
			if (node == null)
			{
				throw new ResourceException(fullKeyPath + " doesn't exist.");
			}
			if (node.Resource == null)
			{
				throw new ResourceException(fullKeyPath + " has no registered resource.");
			}
			ILoadedResource loadedResource = node.Resource.LoadedResource;
			if (loadedResource == null)
			{
				throw new ResourceException(fullKeyPath + " has not been loaded.");
			}
			return loadedResource;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000034AF File Offset: 0x000016AF
		public T GetLoadedResource<T>(string fullKeyPath) where T : ILoadedResource
		{
			ILoadedResource loadedResource = this.GetLoadedResource(fullKeyPath);
			if (!(loadedResource is T))
			{
				throw new ResourceException(fullKeyPath + " doesn't have the correct resource type.");
			}
			return (T)((object)loadedResource);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000034D6 File Offset: 0x000016D6
		public T GetLoadedResource<T>(ILoadedResource parentLoadedResource, string fullKeyPath) where T : ILoadedResource
		{
			fullKeyPath = parentLoadedResource.Resource.GetAbsolutePath(fullKeyPath);
			return this.GetLoadedResource<T>(fullKeyPath);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000034F0 File Offset: 0x000016F0
		public bool TryGetLoadedResource(string fullKeyPath, out ILoadedResource loadedResource)
		{
			loadedResource = null;
			ResourceTree.Node node = this[fullKeyPath];
			if (node == null || node.Resource == null)
			{
				return false;
			}
			loadedResource = node.Resource.LoadedResource;
			return loadedResource != null;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003528 File Offset: 0x00001728
		public bool TryGetLoadedResource<T>(string fullKeyPath, out T loadedResource) where T : class, ILoadedResource
		{
			ILoadedResource loadedResource2;
			if (this.TryGetLoadedResource(fullKeyPath, out loadedResource2))
			{
				loadedResource = (loadedResource2 as T);
				return loadedResource != null;
			}
			loadedResource = default(T);
			return false;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003568 File Offset: 0x00001768
		public void RemoveEmptyNodes()
		{
			this.RemoveEmptyNodes(this._head);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003578 File Offset: 0x00001778
		private void RemoveEmptyNodes(ResourceTree.Node node)
		{
			foreach (ResourceTree.Node node2 in node.ToArray<ResourceTree.Node>())
			{
				this.RemoveEmptyNodes(node2);
			}
			if (node.Parent == null)
			{
				return;
			}
			if (node.Resource == null && node.Children.Count == 0)
			{
				node.Parent.Remove(node.Key);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000035D4 File Offset: 0x000017D4
		public void MergeWith(ResourceTree tree)
		{
			foreach (KeyValuePair<string, ResourceTree.Node> keyValuePair in tree.GetNodeListing())
			{
				ResourceTree.Node orAdd = this.GetOrAdd(keyValuePair.Key);
				if (keyValuePair.Value.Resource != null)
				{
					orAdd.Resource = keyValuePair.Value.Resource;
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003648 File Offset: 0x00001848
		public IDictionary<string, ResourceTree.Node> GetNodeListing()
		{
			Dictionary<string, ResourceTree.Node> dictionary = new Dictionary<string, ResourceTree.Node>();
			Stack<Tuple<string, ResourceTree.Node>> stack = new Stack<Tuple<string, ResourceTree.Node>>();
			stack.Push(new Tuple<string, ResourceTree.Node>(string.Empty, this._head));
			do
			{
				Tuple<string, ResourceTree.Node> tuple = stack.Pop();
				string text = (string.IsNullOrEmpty(tuple.Item1) ? string.Empty : (tuple.Item1 + "/")) + tuple.Item2.Key;
				dictionary[text] = tuple.Item2;
				foreach (ResourceTree.Node item in tuple.Item2)
				{
					stack.Push(new Tuple<string, ResourceTree.Node>(text, item));
				}
			}
			while (stack.Count > 0);
			return dictionary;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000371C File Offset: 0x0000191C
		public IDictionary<string, Resource> GetResourceListing()
		{
			Dictionary<string, Resource> dictionary = new Dictionary<string, Resource>();
			foreach (KeyValuePair<string, ResourceTree.Node> keyValuePair in from x in this.GetNodeListing()
			where x.Value.Resource != null
			select x)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value.Resource;
			}
			return dictionary;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000037A8 File Offset: 0x000019A8
		public IEnumerator<ResourceTree.Node> GetEnumerator()
		{
			Stack<ResourceTree.Node> stack = new Stack<ResourceTree.Node>();
			stack.Push(this._head);
			do
			{
				ResourceTree.Node topNode = stack.Pop();
				yield return topNode;
				foreach (ResourceTree.Node item in topNode)
				{
					stack.Push(item);
				}
				topNode = null;
			}
			while (stack.Count > 0);
			yield break;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000037B7 File Offset: 0x000019B7
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000033 RID: 51
		private readonly ResourceTree.Node _head = new ResourceTree.Node();

		// Token: 0x0200001D RID: 29
		public class Node : IEnumerable<ResourceTree.Node>, IEnumerable
		{
			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000095 RID: 149 RVA: 0x00004476 File Offset: 0x00002676
			public ResourceTree.Node Parent
			{
				get
				{
					return this._parent;
				}
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000096 RID: 150 RVA: 0x0000447E File Offset: 0x0000267E
			public ICollection<ResourceTree.Node> Children
			{
				get
				{
					return this._children.Values;
				}
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000097 RID: 151 RVA: 0x0000448B File Offset: 0x0000268B
			public string Key
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000098 RID: 152 RVA: 0x00004493 File Offset: 0x00002693
			// (set) Token: 0x06000099 RID: 153 RVA: 0x0000449B File Offset: 0x0000269B
			public Resource Resource { get; set; }

			// Token: 0x0600009A RID: 154 RVA: 0x000044A4 File Offset: 0x000026A4
			public Node()
			{
			}

			// Token: 0x0600009B RID: 155 RVA: 0x000044B7 File Offset: 0x000026B7
			public Node(ResourceTree.Node parent, string key, Resource resource = null)
			{
				this._parent = parent;
				this._key = key;
				this.Resource = resource;
			}

			// Token: 0x1700002A RID: 42
			public ResourceTree.Node this[string key]
			{
				get
				{
					if (!this._children.ContainsKey(key))
					{
						return null;
					}
					return this._children[key];
				}
			}

			// Token: 0x0600009D RID: 157 RVA: 0x000044FD File Offset: 0x000026FD
			public ResourceTree.Node Add(string key, Resource resource)
			{
				ResourceTree.Node orAdd = this.GetOrAdd(key);
				orAdd.Resource = resource;
				return orAdd;
			}

			// Token: 0x0600009E RID: 158 RVA: 0x00004510 File Offset: 0x00002710
			public ResourceTree.Node GetOrAdd(string key)
			{
				if (this._children.ContainsKey(key))
				{
					return this._children[key];
				}
				ResourceTree.Node node = new ResourceTree.Node(this, key, null);
				this._children.Add(key, node);
				return node;
			}

			// Token: 0x0600009F RID: 159 RVA: 0x0000454F File Offset: 0x0000274F
			public void Remove(string key)
			{
				this._children.Remove(key);
			}

			// Token: 0x060000A0 RID: 160 RVA: 0x0000455E File Offset: 0x0000275E
			public IEnumerator<ResourceTree.Node> GetEnumerator()
			{
				return this._children.Values.GetEnumerator();
			}

			// Token: 0x060000A1 RID: 161 RVA: 0x00004575 File Offset: 0x00002775
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060000A2 RID: 162 RVA: 0x0000448B File Offset: 0x0000268B
			public override string ToString()
			{
				return this._key;
			}

			// Token: 0x0400006C RID: 108
			private readonly ResourceTree.Node _parent;

			// Token: 0x0400006D RID: 109
			private readonly Dictionary<string, ResourceTree.Node> _children = new Dictionary<string, ResourceTree.Node>();

			// Token: 0x0400006E RID: 110
			private readonly string _key;
		}
	}
}
