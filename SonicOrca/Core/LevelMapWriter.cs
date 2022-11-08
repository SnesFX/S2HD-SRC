using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using SonicOrca.Core.Collision;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x0200012F RID: 303
	public class LevelMapWriter
	{
		// Token: 0x06000BF0 RID: 3056 RVA: 0x0002DDBF File Offset: 0x0002BFBF
		public LevelMapWriter(LevelMap map)
		{
			this._levelMap = map;
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0002DDD0 File Offset: 0x0002BFD0
		public void Save(string path)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true
			};
			using (XmlWriter xmlWriter = XmlWriter.Create(path, settings))
			{
				xmlWriter.WriteStartDocument();
				xmlWriter.WriteStartElement("map");
				xmlWriter.WriteStartElement("tiles");
				foreach (ILevelLayerTreeNode node in this._levelMap.LayerTree.Children)
				{
					this.WriteLevelLayerTreeNode(xmlWriter, node);
				}
				xmlWriter.WriteEndElement();
				if (this._levelMap.CollisionVectors.Count > 0)
				{
					xmlWriter.WriteStartElement("collision");
					xmlWriter.WriteStartElement("paths");
					foreach (int num in this._levelMap.CollisionPathLayers)
					{
						xmlWriter.WriteStartElement("path");
						xmlWriter.WriteAttributeString("layer", num.ToString());
						xmlWriter.WriteEndElement();
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteStartElement("vectors");
					foreach (CollisionVector collisionVector in this._levelMap.CollisionVectors)
					{
						xmlWriter.WriteStartElement("vector");
						xmlWriter.WriteAttributeString("a", collisionVector.RelativeA.X + "," + collisionVector.RelativeA.Y);
						xmlWriter.WriteAttributeString("b", collisionVector.RelativeB.X + "," + collisionVector.RelativeB.Y);
						xmlWriter.WriteAttributeString("paths", collisionVector.Paths.ToString());
						xmlWriter.WriteAttributeString("flags", ((int)collisionVector.Flags).ToString());
						xmlWriter.WriteEndElement();
					}
					xmlWriter.WriteEndElement();
					xmlWriter.WriteEndElement();
				}
				if (this._levelMap.Markers.Count > 0)
				{
					xmlWriter.WriteStartElement("markers");
					foreach (LevelMarker levelMarker in this._levelMap.Markers)
					{
						xmlWriter.WriteStartElement("marker");
						if (!string.IsNullOrEmpty(levelMarker.Name))
						{
							xmlWriter.WriteAttributeString("name", levelMarker.Name);
						}
						if (!string.IsNullOrEmpty(levelMarker.Tag))
						{
							xmlWriter.WriteAttributeString("tag", levelMarker.Tag);
						}
						xmlWriter.WriteAttributeString("x", levelMarker.Bounds.X.ToString());
						xmlWriter.WriteAttributeString("y", levelMarker.Bounds.Y.ToString());
						if (levelMarker.Bounds.Width > 0)
						{
							xmlWriter.WriteAttributeString("width", levelMarker.Bounds.Width.ToString());
						}
						if (levelMarker.Bounds.Height > 0)
						{
							xmlWriter.WriteAttributeString("height", levelMarker.Bounds.Height.ToString());
						}
						if (levelMarker.Layer != null)
						{
							xmlWriter.WriteAttributeString("layer", this._levelMap.Layers.IndexOf(levelMarker.Layer).ToString());
						}
						xmlWriter.WriteEndElement();
					}
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndDocument();
			}
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0002E220 File Offset: 0x0002C420
		private void WriteLevelLayerTreeNode(XmlWriter xmlWriter, ILevelLayerTreeNode node)
		{
			if (node is LevelLayerGroup)
			{
				xmlWriter.WriteStartElement("layergroup");
				xmlWriter.WriteAttributeString("name", node.Name);
				foreach (ILevelLayerTreeNode node2 in node.Children)
				{
					this.WriteLevelLayerTreeNode(xmlWriter, node2);
				}
				xmlWriter.WriteEndElement();
				return;
			}
			LevelLayer layer = (LevelLayer)node;
			xmlWriter.WriteStartElement("layer");
			if (!string.IsNullOrEmpty(layer.Name))
			{
				xmlWriter.WriteAttributeString("name", layer.Name);
			}
			if (layer.MiniMapColour != default(Colour))
			{
				xmlWriter.WriteAttributeString("minimap_colour", layer.MiniMapColour.ToHexString());
			}
			if (layer.LayerRowDefinitions.Count > 0)
			{
				xmlWriter.WriteStartElement("rowdefinitions");
				foreach (LayerRowDefinition layerRowDefinition in layer.LayerRowDefinitions)
				{
					xmlWriter.WriteStartElement("rowdefinition");
					if (layerRowDefinition.Width != 0)
					{
						xmlWriter.WriteAttributeString("width", layerRowDefinition.Width.ToString());
					}
					xmlWriter.WriteAttributeString("height", layerRowDefinition.Height.ToString());
					if (layerRowDefinition.Parallax != 1.0)
					{
						xmlWriter.WriteAttributeString("parallax_x", layerRowDefinition.Parallax.ToString(CultureInfo.InvariantCulture));
					}
					if (layerRowDefinition.Velocity != 0.0)
					{
						xmlWriter.WriteAttributeString("velocity_x", layerRowDefinition.Velocity.ToString(CultureInfo.InvariantCulture));
					}
					if (layerRowDefinition.InitialOffset != 0)
					{
						xmlWriter.WriteAttributeString("offset_x", layerRowDefinition.InitialOffset.ToString(CultureInfo.InvariantCulture));
					}
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
			}
			if (layer.Lighting.Type != LevelLayerLightingType.Outside || layer.Lighting.Light != 1.0)
			{
				xmlWriter.WriteStartElement("lighting");
				xmlWriter.WriteAttributeString("type", layer.Lighting.Type.ToString().ToLower());
				xmlWriter.WriteAttributeString("light", layer.Lighting.Light.ToString());
				xmlWriter.WriteEndElement();
			}
			if (layer.Shadows.Count > 0)
			{
				xmlWriter.WriteStartElement("shadows");
				foreach (LevelLayerShadow levelLayerShadow in layer.Shadows)
				{
					xmlWriter.WriteStartElement("shadow");
					if (!levelLayerShadow.Tiles)
					{
						xmlWriter.WriteAttributeString("tiles", "false");
					}
					if (!levelLayerShadow.Objects)
					{
						xmlWriter.WriteAttributeString("tiles", "false");
					}
					xmlWriter.WriteAttributeString("layerIndexOffset", levelLayerShadow.LayerIndexOffset.ToString());
					xmlWriter.WriteAttributeString("dx", levelLayerShadow.Displacement.X.ToString());
					xmlWriter.WriteAttributeString("dy", levelLayerShadow.Displacement.Y.ToString());
					if (levelLayerShadow.Softness != 0)
					{
						xmlWriter.WriteAttributeString("softness", levelLayerShadow.Softness.ToString());
					}
					if (levelLayerShadow.Colour != LevelLayerShadow.DefaultShadowColour)
					{
						xmlWriter.WriteAttributeString("colour", levelLayerShadow.Colour.ToHexString());
					}
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
			}
			if (layer.Rows > 0)
			{
				xmlWriter.WriteStartElement("tiles");
				if (layer.OffsetY != 0)
				{
					xmlWriter.WriteAttributeString("offset_y", layer.OffsetY.ToString());
				}
				if (layer.AutomaticYParallax)
				{
					xmlWriter.WriteAttributeString("parallax_y", "auto");
				}
				else if (layer.ParallaxY != 1.0)
				{
					xmlWriter.WriteAttributeString("parallax_y", layer.ParallaxY.ToString(CultureInfo.InvariantCulture));
				}
				if (layer.WrapX)
				{
					xmlWriter.WriteAttributeString("wrap_x", "true");
				}
				if (layer.WrapY)
				{
					xmlWriter.WriteAttributeString("wrap_y", "true");
				}
				int y2;
				int y;
				for (y = 0; y < layer.Rows; y = y2 + 1)
				{
					xmlWriter.WriteStartElement("row");
					IEnumerable<int> source = from x in Enumerable.Range(0, layer.Columns)
					select layer.Tiles[x, y];
					xmlWriter.WriteString(string.Join(",", from tileIndex in source
					select (((tileIndex & 16384) != 0) ? "h" : string.Empty) + (((tileIndex & 32768) != 0) ? "v" : string.Empty) + (tileIndex & 4095)));
					xmlWriter.WriteEndElement();
					y2 = y;
				}
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
		}

		// Token: 0x040006E1 RID: 1761
		private readonly LevelMap _levelMap;
	}
}
