using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Extensions;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000129 RID: 297
	internal class LevelMapResourceType : ResourceType
	{
		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x0002CFB5 File Offset: 0x0002B1B5
		public override string Name
		{
			get
			{
				return "map, xml";
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x0002CFBC File Offset: 0x0002B1BC
		public override string DefaultExtension
		{
			get
			{
				return ".map.xml";
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0002CFC3 File Offset: 0x0002B1C3
		public LevelMapResourceType() : base(ResourceTypeIdentifier.Map)
		{
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0002CFD0 File Offset: 0x0002B1D0
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			XmlDocument xmlDocument = new XmlDocument();
			await Task.Run(delegate()
			{
				xmlDocument.Load(e.InputStream);
			});
			LevelMap map = new LevelMap();
			map.Resource = e.Resource;
			XmlNode parent = xmlDocument.SelectSingleNode("map/tiles");
			ILevelLayerTreeNode[] items = this.GetLevelLayersFromXmlNode(parent, map).ToArray<ILevelLayerTreeNode>();
			map.LayerTree.Children.Clear();
			map.LayerTree.Children.AddRange(items);
			LevelLayer[] items2 = (from x in map.LayerTree.GetDescendantsOrdered()
			select x as LevelLayer into x
			where x != null
			select x).ToArray<LevelLayer>();
			map.Layers.Clear();
			map.Layers.AddRange(items2);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("map/collision");
			if (xmlNode != null)
			{
				map.CollisionPathLayers.AddRange(this.GetCollisionPathsFromXmlNode(xmlNode.SelectSingleNode("paths")));
				map.CollisionVectors.AddRange(this.GetCollisionVectorsFromXmlNode(xmlNode.SelectSingleNode("vectors")));
			}
			XmlNode xmlNode2 = xmlDocument.SelectSingleNode("map/markers");
			if (xmlNode2 != null)
			{
				map.Markers.AddRange(from x in xmlNode2.SelectNodes("marker").OfType<XmlNode>()
				select this.GetMarkerFromXmlNode(map, x));
			}
			return map;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0002D01D File Offset: 0x0002B21D
		private IEnumerable<ILevelLayerTreeNode> GetLevelLayersFromXmlNode(XmlNode parent, LevelMap map)
		{
			foreach (object obj in parent.ChildNodes)
			{
				XmlNode node = (XmlNode)obj;
				if (node.Name == "layergroup")
				{
					string empty;
					if (!node.TryGetAttributeValue("name", out empty))
					{
						empty = string.Empty;
					}
					LevelLayerGroup levelLayerGroup = new LevelLayerGroup(empty);
					foreach (ILevelLayerTreeNode item in this.GetLevelLayersFromXmlNode(node, map))
					{
						levelLayerGroup.Children.Add(item);
					}
					yield return levelLayerGroup;
				}
				else if (node.Name == "layer")
				{
					LevelLayer levelLayerFromXmlNode = this.GetLevelLayerFromXmlNode(node, map);
					yield return levelLayerFromXmlNode;
				}
				node = null;
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0002D03C File Offset: 0x0002B23C
		private LevelLayer GetLevelLayerFromXmlNode(XmlNode node, LevelMap map)
		{
			LevelLayer levelLayer = new LevelLayer(map);
			string text;
			if (node.TryGetAttributeValue("name", out text))
			{
				levelLayer.Name = text;
			}
			Colour miniMapColour;
			if (node.TryGetAttributeValue("minimap_colour", out text) && Colour.TryParseHex(text, out miniMapColour))
			{
				levelLayer.MiniMapColour = miniMapColour;
			}
			levelLayer.LayerRowDefinitions.AddRange(from x in node.SelectNodes("rowdefinitions/rowdefinition").OfType<XmlNode>()
			select this.GetRowDefinitionFromXmlNode(x));
			XmlNode xmlNode = node.SelectSingleNode("lighting");
			if (xmlNode != null)
			{
				LevelLayerLighting levelLayerLighting = new LevelLayerLighting();
				LevelLayerLightingType type;
				if (xmlNode.TryGetAttributeValue("type", out text) && Enum.TryParse<LevelLayerLightingType>(text, true, out type))
				{
					levelLayerLighting.Type = type;
				}
				if (xmlNode.TryGetAttributeValue("light", out text))
				{
					levelLayerLighting.Light = double.Parse(text, CultureInfo.InvariantCulture);
				}
				levelLayer.Lighting = levelLayerLighting;
			}
			levelLayer.Shadows.AddRange(from x in node.SelectNodes("shadows/shadow").OfType<XmlNode>()
			select this.GetShadowFromXmlNode(x));
			XmlNode xmlNode2 = node.SelectSingleNode("tiles");
			if (xmlNode2 != null)
			{
				if (xmlNode2.TryGetAttributeValue("offset_y", out text))
				{
					levelLayer.OffsetY = int.Parse(text);
				}
				if (xmlNode2.TryGetAttributeValue("parallax_y", out text))
				{
					if (text.Equals("auto", StringComparison.OrdinalIgnoreCase))
					{
						levelLayer.AutomaticYParallax = true;
					}
					else
					{
						levelLayer.ParallaxY = double.Parse(text, CultureInfo.InvariantCulture);
					}
				}
				if (xmlNode2.TryGetAttributeValue("wrap_x", out text))
				{
					levelLayer.WrapX = text.Equals("true", StringComparison.OrdinalIgnoreCase);
				}
				if (xmlNode2.TryGetAttributeValue("wrap_y", out text))
				{
					levelLayer.WrapY = text.Equals("true", StringComparison.OrdinalIgnoreCase);
				}
			}
			int[][] array = (from x in node.SelectNodes("tiles/row").OfType<XmlNode>()
			select this.ReadTileValues(x.InnerText)).ToArray<int[]>();
			if (array.Length != 0)
			{
				levelLayer.Resize(array.Max((int[] x) => x.Length), array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					for (int j = 0; j < Math.Min(levelLayer.Columns, array[i].Length); j++)
					{
						levelLayer.Tiles[j, i] = array[i][j];
					}
				}
			}
			return levelLayer;
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0002D290 File Offset: 0x0002B490
		private LayerRowDefinition GetRowDefinitionFromXmlNode(XmlNode node)
		{
			LayerRowDefinition layerRowDefinition = new LayerRowDefinition();
			string s;
			if (node.TryGetAttributeValue("width", out s))
			{
				layerRowDefinition.Width = int.Parse(s);
			}
			if (node.TryGetAttributeValue("height", out s))
			{
				layerRowDefinition.Height = int.Parse(s);
			}
			if (node.TryGetAttributeValue("parallax_x", out s))
			{
				layerRowDefinition.Parallax = double.Parse(s, CultureInfo.InvariantCulture);
			}
			if (node.TryGetAttributeValue("velocity_x", out s))
			{
				layerRowDefinition.Velocity = double.Parse(s, CultureInfo.InvariantCulture);
			}
			if (node.TryGetAttributeValue("offset_x", out s))
			{
				layerRowDefinition.InitialOffset = int.Parse(s);
			}
			return layerRowDefinition;
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0002D338 File Offset: 0x0002B538
		private LevelLayerShadow GetShadowFromXmlNode(XmlNode node)
		{
			LevelLayerShadow levelLayerShadow = new LevelLayerShadow();
			string text;
			if (node.TryGetAttributeValue("tiles", out text))
			{
				levelLayerShadow.Tiles = bool.Parse(text);
			}
			if (node.TryGetAttributeValue("objects", out text))
			{
				levelLayerShadow.Objects = bool.Parse(text);
			}
			if (node.TryGetAttributeValue("layerIndexOffset", out text))
			{
				levelLayerShadow.LayerIndexOffset = int.Parse(text);
			}
			if (node.TryGetAttributeValue("dx", out text))
			{
				Vector2i displacement = levelLayerShadow.Displacement;
				displacement.X = int.Parse(text);
				levelLayerShadow.Displacement = displacement;
			}
			if (node.TryGetAttributeValue("dy", out text))
			{
				Vector2i displacement2 = levelLayerShadow.Displacement;
				displacement2.Y = int.Parse(text);
				levelLayerShadow.Displacement = displacement2;
			}
			if (node.TryGetAttributeValue("softness", out text))
			{
				levelLayerShadow.Softness = int.Parse(text);
			}
			if (node.TryGetAttributeValue("colour", out text))
			{
				levelLayerShadow.Colour = Colour.ParseHex(text);
			}
			return levelLayerShadow;
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0002D428 File Offset: 0x0002B628
		private void ReadXYAttribute(string attributeValue, out bool x, out bool y)
		{
			string[] array = attributeValue.Split(new char[]
			{
				','
			});
			x = (array[0] == "true");
			y = (array[1] == "true");
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0002D468 File Offset: 0x0002B668
		private void ReadXYAttribute(string attributeValue, out Vector2 result)
		{
			string[] array = attributeValue.Split(new char[]
			{
				','
			});
			result = new Vector2(double.Parse(array[0], CultureInfo.InvariantCulture), double.Parse(array[1], CultureInfo.InvariantCulture));
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0002D4AC File Offset: 0x0002B6AC
		private int[] ReadTileValues(string text)
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<int> list = new List<int>();
			StringReader stringReader = new StringReader(text);
			while (stringReader.CanRead())
			{
				int num = 0;
				char c = (char)stringReader.Peek();
				if (char.ToUpper(c) == 'H')
				{
					num |= 16384;
					stringReader.Read();
					c = (char)stringReader.Peek();
				}
				if (char.ToUpper(c) == 'V')
				{
					num |= 32768;
					stringReader.Read();
					c = (char)stringReader.Peek();
				}
				stringBuilder.Clear();
				while (char.IsNumber(c))
				{
					stringReader.Read();
					stringBuilder.Append(c);
					c = (char)stringReader.Peek();
				}
				num |= int.Parse(stringBuilder.ToString());
				list.Add(num);
				if (c != ',' && c != '￿')
				{
					throw new Exception();
				}
				stringReader.Read();
			}
			return list.ToArray();
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0002D590 File Offset: 0x0002B790
		private LevelMarker GetMarkerFromXmlNode(LevelMap map, XmlNode node)
		{
			Rectanglei bounds = default(Rectanglei);
			bounds.X = int.Parse(node.Attributes["x"].Value);
			bounds.Y = int.Parse(node.Attributes["y"].Value);
			string text;
			if (node.TryGetAttributeValue("width", out text))
			{
				bounds.Width = int.Parse(text);
			}
			if (node.TryGetAttributeValue("height", out text))
			{
				bounds.Height = int.Parse(text);
			}
			string name = null;
			if (node.TryGetAttributeValue("name", out text))
			{
				name = text;
			}
			string tag = null;
			if (node.TryGetAttributeValue("tag", out text))
			{
				tag = text;
			}
			LevelLayer layer = null;
			if (node.TryGetAttributeValue("layer", out text))
			{
				layer = map.Layers[int.Parse(text)];
			}
			return new LevelMarker(name, tag, bounds, layer);
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0002D674 File Offset: 0x0002B874
		private IEnumerable<CollisionVector> GetCollisionVectorsFromXmlNode(XmlNode parent)
		{
			foreach (object obj in parent.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				Vector2i a;
				Vector2i b;
				string s;
				uint paths;
				int flags;
				if (!(xmlNode.Name != "vector") && this.TryGetAttributeXY(xmlNode, "a", out a) && this.TryGetAttributeXY(xmlNode, "b", out b) && xmlNode.TryGetAttributeValue("paths", out s) && uint.TryParse(s, out paths) && xmlNode.TryGetAttributeValue("flags", out s) && int.TryParse(s, out flags))
				{
					yield return new CollisionVector(a, b, paths, (CollisionFlags)flags);
				}
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0002D68B File Offset: 0x0002B88B
		private IEnumerable<int> GetCollisionPathsFromXmlNode(XmlNode parent)
		{
			foreach (object obj in parent.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (!(xmlNode.Name != "path"))
				{
					string s;
					if (!xmlNode.TryGetAttributeValue("layer", out s))
					{
						throw new Exception();
					}
					int num;
					if (!int.TryParse(s, out num))
					{
						throw new Exception();
					}
					yield return num;
				}
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0002D69C File Offset: 0x0002B89C
		private bool TryGetAttributeXY(XmlNode node, string name, out Vector2i xy)
		{
			xy = default(Vector2i);
			string text;
			if (!node.TryGetAttributeValue(name, out text))
			{
				return false;
			}
			string[] array = text.Split(new char[]
			{
				','
			});
			if (array.Length != 2)
			{
				return false;
			}
			int x;
			if (!int.TryParse(array[0], out x))
			{
				return false;
			}
			int y;
			if (!int.TryParse(array[1], out y))
			{
				return false;
			}
			xy = new Vector2i(x, y);
			return true;
		}
	}
}
