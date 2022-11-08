using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000118 RID: 280
	internal class AreaResourceType : ResourceType
	{
		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000A74 RID: 2676 RVA: 0x000293CC File Offset: 0x000275CC
		public override string Name
		{
			get
			{
				return "area, cs";
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000A75 RID: 2677 RVA: 0x000293D3 File Offset: 0x000275D3
		public override string DefaultExtension
		{
			get
			{
				return ".area.cs";
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000293DA File Offset: 0x000275DA
		public AreaResourceType() : base(ResourceTypeIdentifier.Area)
		{
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x000293E8 File Offset: 0x000275E8
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			Type type = ScriptImport.Compile(await new StreamReader(e.InputStream).ReadToEndAsync()).FirstOrDefault((Type x) => typeof(Area).IsAssignableFrom(x));
			if (type == null)
			{
				throw new ResourceException("No class inheriting Area found.");
			}
			Area area = (Area)Activator.CreateInstance(type);
			area.Resource = e.Resource;
			e.PushDependencies(from x in area.Dependencies
			select e.GetAbsolutePath(x));
			return area;
		}
	}
}
