using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Extensions;
using SonicOrca.Resources;

namespace SonicOrca.Audio
{
	// Token: 0x020001A7 RID: 423
	internal class SampleInfoResourceType : ResourceType
	{
		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x0600122E RID: 4654 RVA: 0x000479BF File Offset: 0x00045BBF
		public override string Name
		{
			get
			{
				return "sample info";
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x000479C6 File Offset: 0x00045BC6
		public override string DefaultExtension
		{
			get
			{
				return ".sampleinfo.xml";
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06001230 RID: 4656 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x000479CD File Offset: 0x00045BCD
		public SampleInfoResourceType() : base(ResourceTypeIdentifier.SampleInfo)
		{
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x000479DC File Offset: 0x00045BDC
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			return await Task.Run<SampleInfo>(delegate()
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(e.InputStream);
				string absolutePath = e.GetAbsolutePath(xmlDocument.SelectSingleNode("sampleinfo/sample").InnerText);
				e.PushDependency(absolutePath);
				int? loopSampleIndex = null;
				string s;
				if (xmlDocument.TryGetNodeInnerText("sampleinfo/loop", out s))
				{
					loopSampleIndex = new int?(int.Parse(s));
				}
				return new SampleInfo(e.ResourceTree, absolutePath, loopSampleIndex)
				{
					Resource = e.Resource
				};
			});
		}
	}
}
