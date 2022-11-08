using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SonicOrca.Resources
{
	// Token: 0x0200000F RID: 15
	public abstract class ResourceType
	{
		// Token: 0x06000062 RID: 98 RVA: 0x000037D4 File Offset: 0x000019D4
		static ResourceType()
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				foreach (Type type in assemblies[i].GetTypes())
				{
					if (!(typeof(ResourceType) == type) && typeof(ResourceType).IsAssignableFrom(type))
					{
						Activator.CreateInstance(type);
					}
				}
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000384E File Offset: 0x00001A4E
		public static ResourceType FromIdentifier(ResourceTypeIdentifier identifier)
		{
			if (!ResourceType.RegisteredResourceTypeDictionary.ContainsKey(identifier))
			{
				throw new ResourceException(identifier + " is not a registered resource type.");
			}
			return ResourceType.RegisteredResourceTypeDictionary[identifier];
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003880 File Offset: 0x00001A80
		public static ResourceType FromPath(string path)
		{
			int num = path.IndexOf('.');
			string extension = (num != -1) ? path.Substring(num) : null;
			if (extension == null)
			{
				throw new NotImplementedException();
			}
			ResourceType resourceType = ResourceType.RegisteredResourceTypes.FirstOrDefault((ResourceType x) => x.DefaultExtension == extension);
			if (resourceType == null)
			{
				throw new ResourceException("No registered resource type for this extension.");
			}
			return resourceType;
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000038E2 File Offset: 0x00001AE2
		public static IEnumerable<ResourceType> RegisteredResourceTypes
		{
			get
			{
				return ResourceType.RegisteredResourceTypeDictionary.Values;
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000038EE File Offset: 0x00001AEE
		protected ResourceType(ResourceTypeIdentifier identifier)
		{
			this._identifier = identifier;
			ResourceType.RegisteredResourceTypeDictionary.Add(identifier, this);
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00003909 File Offset: 0x00001B09
		public ResourceTypeIdentifier Identifier
		{
			get
			{
				return this._identifier;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003911 File Offset: 0x00001B11
		public virtual bool CompressByDefault
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000069 RID: 105
		public abstract string Name { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600006A RID: 106
		public abstract string DefaultExtension { get; }

		// Token: 0x0600006B RID: 107
		public abstract Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken));

		// Token: 0x04000034 RID: 52
		private static readonly Dictionary<ResourceTypeIdentifier, ResourceType> RegisteredResourceTypeDictionary = new Dictionary<ResourceTypeIdentifier, ResourceType>();

		// Token: 0x04000035 RID: 53
		private readonly ResourceTypeIdentifier _identifier;
	}
}
