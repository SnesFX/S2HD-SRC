using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x0200011D RID: 285
	public class LevelDependenciesResourceType : ResourceType
	{
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000A92 RID: 2706 RVA: 0x0002972C File Offset: 0x0002792C
		public override string Name
		{
			get
			{
				return "dependencies, xml";
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000A93 RID: 2707 RVA: 0x00029733 File Offset: 0x00027933
		public override string DefaultExtension
		{
			get
			{
				return ".dependencies.xml";
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000A94 RID: 2708 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0002973A File Offset: 0x0002793A
		public LevelDependenciesResourceType() : base(ResourceTypeIdentifier.LevelDependencies)
		{
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x00029748 File Offset: 0x00027948
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			XmlDocument xmlDocument = new XmlDocument();
			await Task.Run(delegate()
			{
				xmlDocument.Load(e.InputStream);
			});
			LevelDependencies levelDependencies = new LevelDependencies();
			levelDependencies.Resource = e.Resource;
			XmlNode xmlNode = xmlDocument.SelectSingleNode("Dependencies");
			e.PushDependencies((from x in xmlNode.SelectNodes("Dependency").OfType<XmlNode>()
			select x.SelectSingleNode("Key").InnerText).Distinct<string>());
			return levelDependencies;
		}
	}
}
