using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Resources;

namespace SonicOrca.Core.Objects
{
	// Token: 0x0200015C RID: 348
	internal class ObjectTypeResourceType : ResourceType
	{
		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x000377DF File Offset: 0x000359DF
		public override string Name
		{
			get
			{
				return "object, cs";
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x000377E6 File Offset: 0x000359E6
		public override string DefaultExtension
		{
			get
			{
				return ".object.cs";
			}
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x000377ED File Offset: 0x000359ED
		public ObjectTypeResourceType() : base(ResourceTypeIdentifier.Object)
		{
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x000377FC File Offset: 0x000359FC
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			Type[] source = ScriptImport.Compile(await new StreamReader(e.InputStream).ReadToEndAsync());
			Type type = source.FirstOrDefault((Type x) => typeof(ObjectType).IsAssignableFrom(x));
			Type left = source.FirstOrDefault((Type x) => typeof(ActiveObject).IsAssignableFrom(x));
			if (type == null)
			{
				throw new ResourceException("No class inheriting ObjectType found.");
			}
			if (left == null)
			{
				throw new ResourceException("No class inheriting ActiveObject found.");
			}
			ObjectType objectType = (ObjectType)Activator.CreateInstance(type);
			objectType.Resource = e.Resource;
			e.PushDependencies(from x in objectType.Dependencies
			select e.GetAbsolutePath(x));
			return objectType;
		}
	}
}
