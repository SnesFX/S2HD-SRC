using System;
using System.Threading;
using System.Threading.Tasks;

namespace SonicOrca.Resources
{
	// Token: 0x02000011 RID: 17
	public class XmlResourceType : ResourceType
	{
		// Token: 0x06000072 RID: 114 RVA: 0x0000394E File Offset: 0x00001B4E
		public XmlResourceType() : base(ResourceTypeIdentifier.Xml)
		{
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00003958 File Offset: 0x00001B58
		public override string Name
		{
			get
			{
				return "xml";
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000074 RID: 116 RVA: 0x0000395F File Offset: 0x00001B5F
		public override string DefaultExtension
		{
			get
			{
				return ".xml";
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00003966 File Offset: 0x00001B66
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003969 File Offset: 0x00001B69
		public override Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			return Task.Run<ILoadedResource>(() => new XmlLoadedResource(e.InputStream)
			{
				Resource = e.Resource
			});
		}
	}
}
