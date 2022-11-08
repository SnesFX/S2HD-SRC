using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x02000122 RID: 290
	public class LevelLayer : ILevelLayerTreeNode
	{
		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000B44 RID: 2884 RVA: 0x0002BC45 File Offset: 0x00029E45
		public Level Level
		{
			get
			{
				return this._map.Level;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x0002BC52 File Offset: 0x00029E52
		public LevelMap Map
		{
			get
			{
				return this._map;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000B46 RID: 2886 RVA: 0x0002BC5A File Offset: 0x00029E5A
		// (set) Token: 0x06000B47 RID: 2887 RVA: 0x0002BC62 File Offset: 0x00029E62
		public int Index { get; set; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000B48 RID: 2888 RVA: 0x0002BC6B File Offset: 0x00029E6B
		// (set) Token: 0x06000B49 RID: 2889 RVA: 0x0002BC73 File Offset: 0x00029E73
		public string Name { get; set; }

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0002BC7C File Offset: 0x00029E7C
		// (set) Token: 0x06000B4B RID: 2891 RVA: 0x0002BC84 File Offset: 0x00029E84
		public bool Editing { get; set; }

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0002BC8D File Offset: 0x00029E8D
		// (set) Token: 0x06000B4D RID: 2893 RVA: 0x0002BC95 File Offset: 0x00029E95
		public bool Visible { get; set; }

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000B4E RID: 2894 RVA: 0x0000AB58 File Offset: 0x00008D58
		public IList<ILevelLayerTreeNode> Children
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x0002BC9E File Offset: 0x00029E9E
		public IList<LayerRowDefinition> LayerRowDefinitions
		{
			get
			{
				return this._layerRowDefinitions;
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000B50 RID: 2896 RVA: 0x0002BCA6 File Offset: 0x00029EA6
		// (set) Token: 0x06000B51 RID: 2897 RVA: 0x0002BCAE File Offset: 0x00029EAE
		public int Columns { get; private set; }

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000B52 RID: 2898 RVA: 0x0002BCB7 File Offset: 0x00029EB7
		// (set) Token: 0x06000B53 RID: 2899 RVA: 0x0002BCBF File Offset: 0x00029EBF
		public int Rows { get; private set; }

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000B54 RID: 2900 RVA: 0x0002BCC8 File Offset: 0x00029EC8
		// (set) Token: 0x06000B55 RID: 2901 RVA: 0x0002BCD0 File Offset: 0x00029ED0
		public int[,] Tiles { get; private set; }

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000B56 RID: 2902 RVA: 0x0002BCD9 File Offset: 0x00029ED9
		// (set) Token: 0x06000B57 RID: 2903 RVA: 0x0002BCE1 File Offset: 0x00029EE1
		public int OffsetY { get; set; }

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000B58 RID: 2904 RVA: 0x0002BCEA File Offset: 0x00029EEA
		// (set) Token: 0x06000B59 RID: 2905 RVA: 0x0002BCF2 File Offset: 0x00029EF2
		public double ParallaxY { get; set; }

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000B5A RID: 2906 RVA: 0x0002BCFB File Offset: 0x00029EFB
		// (set) Token: 0x06000B5B RID: 2907 RVA: 0x0002BD03 File Offset: 0x00029F03
		public bool AutomaticYParallax { get; set; }

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0002BD0C File Offset: 0x00029F0C
		// (set) Token: 0x06000B5D RID: 2909 RVA: 0x0002BD14 File Offset: 0x00029F14
		public bool WrapX { get; set; }

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0002BD1D File Offset: 0x00029F1D
		// (set) Token: 0x06000B5F RID: 2911 RVA: 0x0002BD25 File Offset: 0x00029F25
		public bool WrapY { get; set; }

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0002BD2E File Offset: 0x00029F2E
		public IList<LevelLayerShadow> Shadows
		{
			get
			{
				return this._shadows;
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0002BD36 File Offset: 0x00029F36
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x0002BD3E File Offset: 0x00029F3E
		public LevelLayerLighting Lighting { get; set; }

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0002BD47 File Offset: 0x00029F47
		// (set) Token: 0x06000B64 RID: 2916 RVA: 0x0002BD4F File Offset: 0x00029F4F
		public IEnumerable<Rectanglei> WaterfallEffects { get; set; }

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x0002BD58 File Offset: 0x00029F58
		// (set) Token: 0x06000B66 RID: 2918 RVA: 0x0002BD60 File Offset: 0x00029F60
		public Colour MiniMapColour { get; set; }

		// Token: 0x06000B67 RID: 2919 RVA: 0x0002BD6C File Offset: 0x00029F6C
		public LevelLayer(LevelMap map)
		{
			this._map = map;
			this.Visible = true;
			this.Columns = 0;
			this.Rows = 0;
			this.Tiles = new int[0, 0];
			this.Name = string.Empty;
			this.ParallaxY = 1.0;
			this.Lighting = new LevelLayerLighting();
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0002BDE3 File Offset: 0x00029FE3
		public override string ToString()
		{
			if (!string.IsNullOrEmpty(this.Name))
			{
				return this.Name;
			}
			return base.ToString();
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x0002BE00 File Offset: 0x0002A000
		public void Resize(int columns, int rows)
		{
			int num = Math.Min(rows, this.Rows);
			int num2 = Math.Min(columns, this.Columns);
			int[,] array = new int[columns, rows];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array[j, i] = this.Tiles[j, i];
				}
			}
			this.Columns = columns;
			this.Rows = rows;
			this.Tiles = array;
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x00006325 File Offset: 0x00004525
		public void Update()
		{
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0002BE78 File Offset: 0x0002A078
		public void Animate()
		{
			foreach (LayerRowDefinition layerRowDefinition in this._layerRowDefinitions)
			{
				layerRowDefinition.Animate();
			}
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0002BEC8 File Offset: 0x0002A0C8
		public void Draw(Renderer renderer, Viewport viewport, LayerViewOptions viewOptions, LevelLayerShadow shadow)
		{
			if (!this.Visible)
			{
				return;
			}
			if (this.Editing)
			{
				this.DrawNonLayerTiles(renderer, viewport, viewOptions);
			}
			using (viewport.ApplyRendererState(renderer))
			{
				if (viewOptions.ShowObjects)
				{
					this.Level.ObjectManager.Draw(renderer, viewport, this, viewOptions, false);
				}
				if (viewOptions.ShowLandscape)
				{
					Matrix4 modelMatrix = Matrix4.Identity;
					if (viewOptions.Shadows)
					{
						modelMatrix = Matrix4.CreateTranslation((Vector2i)new Vector2((double)shadow.Displacement.X * viewport.Scale.X, (double)shadow.Displacement.Y * viewport.Scale.Y));
					}
					ITileRenderer tileRenderer = renderer.GetTileRenderer();
					tileRenderer.ClipRectangle = viewport.Destination;
					tileRenderer.ModelMatrix = modelMatrix;
					tileRenderer.Textures = this._map.Level.TileSet.Textures.ToArray<ITexture>();
					tileRenderer.Filter = viewOptions.Filter;
					tileRenderer.FilterAmount = viewOptions.FilterAmount;
					tileRenderer.BeginRender();
					this.DrawTilesVertical(renderer, viewport, viewOptions);
					tileRenderer.EndRender();
				}
				if (viewOptions.ShowObjects)
				{
					this.Level.ObjectManager.Draw(renderer, viewport, this, viewOptions, true);
				}
				renderer.DeativateRenderer();
			}
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0002C038 File Offset: 0x0002A238
		public void DrawNonLayerTiles(Renderer renderer, Viewport viewport, LayerViewOptions viewOptions)
		{
			int num = Math.Max(0, this.Columns * 64 - viewport.Bounds.X);
			int num2 = Math.Max(0, this.Rows * 64 - viewport.Bounds.Y);
			num = (int)((double)num * viewport.Scale.X);
			num2 = (int)((double)num2 * viewport.Scale.Y);
			List<Rectanglei> list = new List<Rectanglei>(2);
			if (num < viewport.Destination.Width)
			{
				Rectanglei item = new Rectanglei(num, 0, viewport.Destination.Width - num, viewport.Destination.Height);
				list.Add(item);
			}
			if (num2 < viewport.Destination.Height && num > 0)
			{
				Rectanglei item2 = new Rectanglei(0, num2, Math.Min(viewport.Destination.Width, num), viewport.Destination.Height - num2);
				list.Add(item2);
			}
			if (list.Count > 0)
			{
				renderer.GetNonLayerRenderer().Render(list);
			}
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0002C154 File Offset: 0x0002A354
		private void DrawTilesVertical(Renderer renderer, Viewport viewport, LayerViewOptions viewOptions)
		{
			if (this.Rows == 0 || this.Columns == 0)
			{
				return;
			}
			bool flag = !this.Editing && this.WrapY;
			int num = this.Editing ? 0 : this.OffsetY;
			double num2 = this.Editing ? 1.0 : this.ParallaxY;
			int num3 = (int)((double)(this.Rows * 64) * viewport.Scale.Y);
			int num4 = (int)((double)viewport.Bounds.Y * viewport.Scale.Y * num2);
			if (!flag && num4 >= num3)
			{
				return;
			}
			int num5 = num4 % num3;
			int i = viewport.Destination.Y + num;
			while (i < viewport.Destination.Bottom)
			{
				int val = num3 - num5;
				int val2 = viewport.Destination.Bottom - i;
				int num6 = Math.Min(val, val2);
				this.DrawTilesHorizontal(renderer, viewport, viewOptions, num5, i, ref num6);
				if (num6 <= 0)
				{
					break;
				}
				num5 += num6;
				i += num6;
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

		// Token: 0x06000B6F RID: 2927 RVA: 0x0002C27C File Offset: 0x0002A47C
		private void DrawTilesHorizontal(Renderer renderer, Viewport viewport, LayerViewOptions viewOptions, int sourceY, int destinationY, ref int height)
		{
			int num = (int)(64.0 * viewport.Scale.X);
			int num2 = this.Columns * num;
			int num3 = this.Rows * num;
			bool flag = !this.Editing && this.WrapX;
			double num4 = this.Editing ? 1.0 : this.ParallaxY;
			int num5 = 0;
			int num6;
			LayerRowDefinition rowDefinitionAt = this.GetRowDefinitionAt((int)((double)sourceY / viewport.Scale.Y), out num6);
			if (rowDefinitionAt != null && !this.Editing)
			{
				num4 = rowDefinitionAt.Parallax;
				num5 = (int)rowDefinitionAt.CurrentOffset;
				if (rowDefinitionAt.Width != 0)
				{
					num2 = (int)((double)rowDefinitionAt.Width * viewport.Scale.X);
				}
				num6 = (int)((double)num6 * viewport.Scale.Y);
				height = Math.Min(height, num6 + (int)((double)rowDefinitionAt.Height * viewport.Scale.Y) - sourceY);
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
			int i = (int)((double)viewport.Bounds.X * viewport.Scale.X * num4) - num5;
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
			int j = viewport.Destination.X;
			while (j < viewport.Destination.Right)
			{
				int index = 0;
				if (num7 >= 0 && sourceY >= 0 && num7 < num2 && sourceY < num3)
				{
					index = this.Tiles[num7 / num, sourceY / num];
				}
				int num8 = -(num7 % num);
				int num9 = num - num7 % num;
				if (num9 == 0)
				{
					break;
				}
				Rectanglei source = new Rectanglei(0, (int)((double)(sourceY % num) / viewport.Scale.Y), 64, (int)((double)height / viewport.Scale.Y));
				Rectanglei destination = new Rectanglei(j + num8, destinationY, num, height);
				this.Level.TileSet.DrawTile(renderer, index, source, destination);
				num7 += num9;
				j += num9;
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

		// Token: 0x06000B70 RID: 2928 RVA: 0x0002C50C File Offset: 0x0002A70C
		public LayerRowDefinition GetRowDefinitionAt(int y, out int top)
		{
			int num = 0;
			foreach (LayerRowDefinition layerRowDefinition in this._layerRowDefinitions)
			{
				if (y >= num && y < num + layerRowDefinition.Height)
				{
					top = num;
					return layerRowDefinition;
				}
				num += layerRowDefinition.Height;
			}
			top = 0;
			return null;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0002C580 File Offset: 0x0002A780
		public void Merge(LevelLayer layer)
		{
			int num = Math.Max(this.Columns, layer.Columns);
			int num2 = Math.Max(this.Rows, layer.Rows);
			int[,] array = new int[num, num2];
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (this.Columns > j && this.Rows > i)
					{
						array[j, i] = this.Tiles[j, i];
					}
					if (layer.Columns > j && layer.Rows > i && layer.Tiles[j, i] != 0)
					{
						array[j, i] = layer.Tiles[j, i];
					}
				}
			}
			this.Columns = num;
			this.Rows = num2;
			this.Tiles = array;
		}

		// Token: 0x04000687 RID: 1671
		private readonly LevelMap _map;

		// Token: 0x0400068C RID: 1676
		private readonly List<LayerRowDefinition> _layerRowDefinitions = new List<LayerRowDefinition>();

		// Token: 0x04000695 RID: 1685
		private readonly List<LevelLayerShadow> _shadows = new List<LevelLayerShadow>();
	}
}
