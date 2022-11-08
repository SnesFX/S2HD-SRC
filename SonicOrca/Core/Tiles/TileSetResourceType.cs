using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Extensions;
using SonicOrca.Resources;

namespace SonicOrca.Core.Tiles
{
	// Token: 0x02000152 RID: 338
	internal class TileSetResourceType : ResourceType
	{
		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000E22 RID: 3618 RVA: 0x000362C0 File Offset: 0x000344C0
		public override string Name
		{
			get
			{
				return "tileset, xml";
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000E23 RID: 3619 RVA: 0x000362C7 File Offset: 0x000344C7
		public override string DefaultExtension
		{
			get
			{
				return ".tileset.xml";
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x000362CE File Offset: 0x000344CE
		public TileSetResourceType() : base(ResourceTypeIdentifier.TileSet)
		{
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x000362DC File Offset: 0x000344DC
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			XmlDocument xmlDocument = new XmlDocument();
			await Task.Run(delegate()
			{
				xmlDocument.Load(e.InputStream);
			});
			XmlNode xmlNode = xmlDocument.SelectSingleNode("tileset");
			IEnumerable<string> enumerable = from x in xmlNode.SelectNodes("textures/texture").OfType<XmlNode>()
			select e.GetAbsolutePath(x.InnerText);
			e.PushDependencies(enumerable);
			TileSet tileSet = new TileSet(e.ResourceTree, enumerable);
			tileSet.Resource = e.Resource;
			IEnumerable<Tile> source = from x in xmlNode.SelectNodes("tiles/tile").OfType<XmlNode>()
			select TileSetResourceType.ParseXmlTile(x, tileSet);
			IEnumerable<TileSequence> source2 = from x in xmlNode.SelectNodes("tiles/tileseq").OfType<XmlNode>()
			select TileSetResourceType.ParseXmlTileSequence(x, tileSet);
			foreach (ITile tile in source.Cast<ITile>().Concat(source2.Cast<ITile>()))
			{
				tileSet[tile.Id] = tile;
			}
			return tileSet;
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x00036324 File Offset: 0x00034524
		private static Tile ParseXmlTile(XmlNode node, TileSet tileSet)
		{
			int id = int.Parse(node.Attributes["id"].Value);
			string text;
			int defaultTextureId = node.TryGetAttributeValue("texture", out text) ? int.Parse(text) : 0;
			int defaultX = node.TryGetAttributeValue("x", out text) ? int.Parse(text) : 0;
			int defaultY = node.TryGetAttributeValue("y", out text) ? int.Parse(text) : 0;
			int defaultDelay = node.TryGetAttributeValue("delay", out text) ? int.Parse(text) : 0;
			float defaultOpacity = node.TryGetAttributeValue("opacity", out text) ? float.Parse(text) : 1f;
			TileBlendMode blend = TileBlendMode.Alpha;
			TileBlendMode tileBlendMode;
			if (node.TryGetAttributeValue("blend", out text) && Enum.TryParse<TileBlendMode>(text, true, out tileBlendMode))
			{
				blend = tileBlendMode;
			}
			XmlNode[] array = node.SelectNodes("frame").OfType<XmlNode>().ToArray<XmlNode>();
			IEnumerable<Tile.Frame> enumerable2;
			if (array.Length == 0)
			{
				IEnumerable<Tile.Frame> enumerable = new Tile.Frame[]
				{
					new Tile.Frame
					{
						TextureId = defaultTextureId,
						X = defaultX,
						Y = defaultY,
						Delay = defaultDelay,
						Opacity = defaultOpacity
					}
				};
				enumerable2 = enumerable;
			}
			else
			{
				enumerable2 = from x in array
				select TileSetResourceType.ParseXmlTileFrame(x, defaultX, defaultY, defaultTextureId, defaultDelay, defaultOpacity);
			}
			IEnumerable<Tile.Frame> frames = enumerable2;
			return new Tile(tileSet, id, frames, blend);
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x000364A4 File Offset: 0x000346A4
		private static Tile.Frame ParseXmlTileFrame(XmlNode node, int defaultX, int defaultY, int defaultTextureId, int defaultDelay, float defaultOpacity)
		{
			string s;
			return new Tile.Frame
			{
				TextureId = (node.TryGetAttributeValue("texture", out s) ? int.Parse(s) : defaultTextureId),
				X = (node.TryGetAttributeValue("x", out s) ? int.Parse(s) : defaultX),
				Y = (node.TryGetAttributeValue("y", out s) ? int.Parse(s) : defaultY),
				Delay = (node.TryGetAttributeValue("delay", out s) ? int.Parse(s) : defaultDelay),
				Opacity = (node.TryGetAttributeValue("opacity", out s) ? float.Parse(s) : defaultOpacity)
			};
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00036558 File Offset: 0x00034758
		private static TileSequence ParseXmlTileSequence(XmlNode node, TileSet tileSet)
		{
			int id = int.Parse(node.Attributes["id"].Value);
			List<int> list = new List<int>();
			XmlNode[] array = node.SelectNodes("tile").OfType<XmlNode>().ToArray<XmlNode>();
			for (int i = 0; i < array.Length; i++)
			{
				string s;
				if (array[i].TryGetAttributeValue("id", out s))
				{
					list.Add(int.Parse(s));
				}
			}
			return new TileSequence(tileSet, id, list);
		}
	}
}
