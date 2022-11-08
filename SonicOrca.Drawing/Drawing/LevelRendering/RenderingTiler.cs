using System;
using SonicOrca.Core;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Drawing.LevelRendering
{
	// Token: 0x0200001B RID: 27
	internal class RenderingTiler
	{
		// Token: 0x06000173 RID: 371 RVA: 0x00008009 File Offset: 0x00006209
		public RenderingTiler(Level level, RenderingTileList renderingTileList)
		{
			this._level = level;
			this._tileSet = level.TileSet;
			this._renderingTileList = renderingTileList;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000802C File Offset: 0x0000622C
		public void PrepareTiles(RenderingLayer renderingLayer, Viewport viewport, LayerViewOptions layerViewOptions)
		{
			int count = this._renderingTileList.Count;
			if (layerViewOptions.ShowLandscape)
			{
				this.PrepareTilesVertical(renderingLayer, viewport);
			}
			int count2 = this._renderingTileList.Count - count;
			renderingLayer.SetRenderTileRange(count, count2);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000806C File Offset: 0x0000626C
		private void PrepareTilesVertical(RenderingLayer renderingLayer, Viewport viewport)
		{
			LevelLayer layer = renderingLayer.Layer;
			if (layer.Rows == 0 || layer.Columns == 0)
			{
				return;
			}
			bool editing = layer.Editing;
			bool flag = !editing && layer.WrapY;
			int num = editing ? 0 : layer.OffsetY;
			double num2 = editing ? 1.0 : layer.ParallaxY;
			int num3 = layer.Rows * 64;
			int num4 = (int)((double)viewport.Bounds.Y * num2);
			if (!flag && num4 >= num3)
			{
				return;
			}
			int num5 = num4 % num3;
			int num6 = viewport.Destination.Y + num;
			while ((double)num6 < (double)viewport.Destination.Bottom / viewport.Scale.Y)
			{
				int num7 = num3 - num5;
				this.PrepareTilesHorizontal(renderingLayer, viewport, num5, num6, ref num7);
				if (num7 <= 0)
				{
					break;
				}
				num5 += num7;
				num6 += num7;
				if (flag)
				{
					num5 %= num3;
				}
				else if (num5 > num3)
				{
					break;
				}
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000816C File Offset: 0x0000636C
		private void PrepareTilesHorizontal(RenderingLayer renderingLayer, Viewport viewport, int sourceY, int destinationY, ref int height)
		{
			LevelLayer layer = renderingLayer.Layer;
			bool editing = layer.Editing;
			int num = 64;
			int num2 = layer.Columns * num;
			int num3 = layer.Rows * num;
			bool flag = !editing && layer.WrapX;
			double num4 = editing ? 1.0 : layer.ParallaxY;
			int num5 = 0;
			int num6;
			LayerRowDefinition rowDefinitionAt = layer.GetRowDefinitionAt(sourceY, out num6);
			if (rowDefinitionAt != null && !editing)
			{
				num4 = rowDefinitionAt.Parallax;
				num5 = (int)rowDefinitionAt.CurrentOffset;
				if (rowDefinitionAt.Width != 0)
				{
					int width = rowDefinitionAt.Width;
					if (width < num2)
					{
						num2 = width;
					}
				}
				height = Math.Min(height, num6 + rowDefinitionAt.Height - sourceY);
				height = Math.Min(height, 64 - sourceY % 64);
				if (height <= 0)
				{
					height = 1;
					return;
				}
			}
			if (height > num)
			{
				height = num - sourceY % num;
			}
			if (destinationY + height < viewport.Destination.Top)
			{
				return;
			}
			int i = (int)((double)viewport.Bounds.X * num4) - num5;
			if (flag)
			{
				while (i < 0)
				{
					i += num2;
				}
			}
			if (!flag && i > num2)
			{
				return;
			}
			if (flag)
			{
				i %= num2;
			}
			int num7 = i;
			int num8 = (int)((double)viewport.Destination.X / viewport.Scale.X);
			if (!editing)
			{
				double parallaxY = layer.ParallaxY;
			}
			TileSet tileSet = this._tileSet;
			int[,] tiles = layer.Tiles;
			while ((double)num8 < (double)viewport.Destination.Right / viewport.Scale.X)
			{
				int num9 = 0;
				if (num7 >= 0 && sourceY >= 0 && num7 < num2 && sourceY < num3)
				{
					num9 = tiles[num7 / num, sourceY / num];
				}
				int num10 = -(num7 % num);
				int num11 = num - num7 % num;
				if (num11 == 0)
				{
					break;
				}
				ITile tile;
				if (tileSet.TryGetValue(num9 & 4095, out tile))
				{
					Rectangle r = new Rectangle(0.0, (double)(sourceY % num), 64.0, (double)height);
					Rectanglei rectanglei = new Rectangle((double)(num8 + num10) * viewport.Scale.X, (double)destinationY * viewport.Scale.Y, (double)num * viewport.Scale.X, (double)height * viewport.Scale.Y);
					TileRenderInfo tileRenderInfo = new TileRenderInfo
					{
						Layer = layer,
						TileIndex = num9,
						Source = r,
						Destination = rectanglei
					};
					if (!renderingLayer.IsAreaClipped(viewport, rectanglei))
					{
						this._renderingTileList.AddTileRenderInfo(tileRenderInfo);
					}
				}
				num7 += num11;
				num8 += num11;
				if (flag)
				{
					num7 %= num2;
				}
				else if (num7 > num2)
				{
					break;
				}
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00008444 File Offset: 0x00006644
		public void RenderTiles(I2dRenderer g, ITileRenderer tr, int startIndex, int count)
		{
			if (count == 0)
			{
				return;
			}
			int num = startIndex + count - 1;
			for (int i = 1; i <= 2; i++)
			{
				TileBlendMode tileBlendMode = (TileBlendMode)i;
				tr.BeginRender();
				for (int j = startIndex; j <= num; j++)
				{
					TileRenderInfo tileRenderInfo = this._renderingTileList[j];
					ITile tile;
					if (this._tileSet.TryGetValue(tileRenderInfo.TileIndex, out tile))
					{
						Tile tile2 = tile as Tile;
						if (tile2 != null && tile2.Blend == tileBlendMode)
						{
							tile2.Draw(tr, tileRenderInfo.TileIndex, tileRenderInfo.Source, tileRenderInfo.Destination);
						}
					}
				}
				tr.EndRender();
			}
			for (int k = startIndex; k <= num; k++)
			{
				TileRenderInfo tileRenderInfo = this._renderingTileList[k];
				ITile tile3;
				if (this._tileSet.TryGetValue(tileRenderInfo.TileIndex, out tile3))
				{
					TileSequence tileSequence = tile3 as TileSequence;
					if (tileSequence != null)
					{
						tileSequence.Draw(g, tileRenderInfo.TileIndex, tileRenderInfo.Source, tileRenderInfo.Destination);
					}
				}
			}
		}

		// Token: 0x040000F1 RID: 241
		private readonly Level _level;

		// Token: 0x040000F2 RID: 242
		private readonly TileSet _tileSet;

		// Token: 0x040000F3 RID: 243
		private readonly RenderingTileList _renderingTileList;
	}
}
