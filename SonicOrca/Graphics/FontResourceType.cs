using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Graphics
{
	// Token: 0x020000D6 RID: 214
	internal class FontResourceType : ResourceType
	{
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x0001DC96 File Offset: 0x0001BE96
		public override string Name
		{
			get
			{
				return "font, xml";
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x0001DC9D File Offset: 0x0001BE9D
		public override string DefaultExtension
		{
			get
			{
				return ".font.xml";
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0001DCA4 File Offset: 0x0001BEA4
		public FontResourceType() : base(ResourceTypeIdentifier.Font)
		{
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0001DCB4 File Offset: 0x0001BEB4
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			XmlDocument xmlDocument = new XmlDocument();
			await Task.Run(delegate()
			{
				xmlDocument.Load(e.InputStream);
			});
			XmlNode xmlNode = xmlDocument.SelectSingleNode("font");
			string absolutePath = e.GetAbsolutePath(xmlNode.SelectSingleNode("shape").InnerText);
			string[] array = (from x in xmlNode.SelectNodes("overlay").OfType<XmlNode>()
			select e.GetAbsolutePath(x.InnerText)).ToArray<string>();
			int defaultWidth = int.Parse(xmlNode.GetNodeInnerText("width", "0"));
			int height = int.Parse(xmlNode.GetNodeInnerText("height", "0"));
			int tracking = int.Parse(xmlNode.GetNodeInnerText("tracking", "0"));
			Vector2i? shadow = null;
			XmlNode xmlNode2 = xmlNode.SelectSingleNode("shadow");
			if (xmlNode2 != null)
			{
				shadow = new Vector2i?(new Vector2i(int.Parse(xmlNode2.Attributes["x"].Value), int.Parse(xmlNode2.Attributes["y"].Value)));
			}
			IEnumerable<Font.CharacterDefinition> characterDefinitions = from x in xmlNode.SelectNodes("chardefs/chardef").OfType<XmlNode>()
			select this.ParseCharacterDefinition(x);
			e.PushDependency(absolutePath);
			e.PushDependencies(array);
			return new Font(e.ResourceTree, absolutePath, array, defaultWidth, height, tracking, shadow, characterDefinitions)
			{
				Resource = e.Resource
			};
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0001DD04 File Offset: 0x0001BF04
		private Font.CharacterDefinition ParseCharacterDefinition(XmlNode chardefNode)
		{
			char key = chardefNode.Attributes["char"].Value.First<char>();
			XmlNode xmlNode = chardefNode.SelectSingleNode("rect");
			Rectanglei sourceRectangle = new Rectanglei(int.Parse(xmlNode.Attributes["x"].Value), int.Parse(xmlNode.Attributes["y"].Value), int.Parse(xmlNode.Attributes["w"].Value), int.Parse(xmlNode.Attributes["h"].Value));
			XmlNode xmlNode2 = chardefNode.SelectSingleNode("offset");
			Vector2i offset = (xmlNode2 == null) ? default(Vector2i) : new Vector2i(int.Parse(xmlNode2.Attributes["x"].Value), int.Parse(xmlNode2.Attributes["y"].Value));
			string s;
			int width = chardefNode.TryGetNodeInnerText("width", out s) ? int.Parse(s) : sourceRectangle.Width;
			return new Font.CharacterDefinition(key, sourceRectangle, offset, width);
		}
	}
}
