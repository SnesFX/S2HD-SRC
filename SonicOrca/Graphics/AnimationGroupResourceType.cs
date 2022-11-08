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
	// Token: 0x020000D9 RID: 217
	internal class AnimationGroupResourceType : ResourceType
	{
		// Token: 0x0600073A RID: 1850 RVA: 0x0001DFC0 File Offset: 0x0001C1C0
		public AnimationGroupResourceType() : base(ResourceTypeIdentifier.AnimationGroup)
		{
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x0001DFCD File Offset: 0x0001C1CD
		public override string Name
		{
			get
			{
				return "animationgroup, xml";
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x0001DFD4 File Offset: 0x0001C1D4
		public override string DefaultExtension
		{
			get
			{
				return ".anigroup.xml";
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0001DFDC File Offset: 0x0001C1DC
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			XmlDocument xmlDocument = new XmlDocument();
			await Task.Run(delegate()
			{
				xmlDocument.Load(e.InputStream);
			});
			XmlNode xmlNode = xmlDocument.SelectSingleNode("anigroup");
			IEnumerable<string> enumerable = from x in xmlNode.SelectNodes("textures/texture").OfType<XmlNode>()
			select e.GetAbsolutePath(x.InnerText);
			IEnumerable<Animation> animations = from x in xmlNode.SelectNodes("animations/animation").OfType<XmlNode>()
			select this.GetAnimationFromXmlNode(x);
			e.PushDependencies(enumerable);
			return new AnimationGroup(e.ResourceTree, enumerable, animations)
			{
				Resource = e.Resource
			};
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0001E02C File Offset: 0x0001C22C
		private Animation GetAnimationFromXmlNode(XmlNode node)
		{
			int? nextFrameIndex = null;
			int? loopFrameIndex = null;
			int defaultTexture = 0;
			int defaultWidth = 0;
			int defaultHeight = 0;
			int defaultOffsetX = 0;
			int defaultOffsetY = 0;
			int defaultDelay = 0;
			string s;
			if (node.TryGetAttributeValue("texture", out s))
			{
				defaultTexture = int.Parse(s);
			}
			if (node.TryGetAttributeValue("w", out s))
			{
				defaultWidth = int.Parse(s);
			}
			if (node.TryGetAttributeValue("h", out s))
			{
				defaultHeight = int.Parse(s);
			}
			if (node.TryGetAttributeValue("offset_x", out s))
			{
				defaultOffsetX = int.Parse(s);
			}
			if (node.TryGetAttributeValue("offset_y", out s))
			{
				defaultOffsetY = int.Parse(s);
			}
			if (node.TryGetAttributeValue("delay", out s))
			{
				defaultDelay = int.Parse(s);
			}
			if (node.TryGetAttributeValue("next", out s))
			{
				nextFrameIndex = new int?(int.Parse(s));
			}
			if (node.TryGetAttributeValue("loop", out s))
			{
				loopFrameIndex = new int?(int.Parse(s));
			}
			return new Animation(from x in node.SelectNodes("frame").OfType<XmlNode>()
			select this.GetFrameFromXmlNode(x, defaultTexture, defaultWidth, defaultHeight, defaultOffsetX, defaultOffsetY, defaultDelay), nextFrameIndex, loopFrameIndex);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0001E184 File Offset: 0x0001C384
		private Animation.Frame GetFrameFromXmlNode(XmlNode node, int defaultTexture, int defaultWidth, int defaultHeight, int defaultOffsetX, int defaultOffsetY, int defaultDelay)
		{
			Animation.Frame result = default(Animation.Frame);
			int x = int.Parse(node.Attributes["x"].Value);
			int y = int.Parse(node.Attributes["y"].Value);
			string s;
			int width = node.TryGetAttributeValue("w", out s) ? int.Parse(s) : defaultWidth;
			int height = node.TryGetAttributeValue("h", out s) ? int.Parse(s) : defaultHeight;
			result.TextureIndex = (node.TryGetAttributeValue("texture", out s) ? int.Parse(s) : defaultTexture);
			int x2 = node.TryGetAttributeValue("offset_x", out s) ? int.Parse(s) : defaultOffsetX;
			int y2 = node.TryGetAttributeValue("offset_y", out s) ? int.Parse(s) : defaultOffsetY;
			result.Delay = (node.TryGetAttributeValue("delay", out s) ? int.Parse(s) : defaultDelay);
			result.Offset = new Vector2i(x2, y2);
			result.Source = new Rectanglei(x, y, width, height);
			return result;
		}
	}
}
