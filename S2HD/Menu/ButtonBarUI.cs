using System;
using System.Collections.Immutable;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace S2HD.Menu
{
	// Token: 0x020000AC RID: 172
	internal class ButtonBarUI
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x0001CF80 File Offset: 0x0001B180
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x0001CF88 File Offset: 0x0001B188
		public Rectanglei Bounds
		{
			get
			{
				return this._bounds;
			}
			set
			{
				this._bounds = value;
				this._layoutDirty = true;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0001CF98 File Offset: 0x0001B198
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0001CFA0 File Offset: 0x0001B1A0
		public ImmutableArray<ButtonBarItem> Items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
				this._layoutDirty = true;
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0001CFB0 File Offset: 0x0001B1B0
		public ButtonBarUI(IControlResources resources)
		{
			this._controlResources = resources;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0001CFC8 File Offset: 0x0001B1C8
		private void CalculateItemPositions(I2dRenderer g)
		{
			int length = this._items.Length;
			int num = 0;
			this._itemX = new int[length];
			for (int i = 0; i < length; i++)
			{
				this._itemX[i] = num;
				ButtonBarItem item = this._items[i];
				num += this.GetItemWidth(g, item);
				num += 16;
			}
			int num2 = this.Bounds.Width - (num - 16);
			for (int j = 0; j < length; j++)
			{
				this._itemX[j] += num2;
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0001D05C File Offset: 0x0001B25C
		private int GetItemWidth(I2dRenderer g, ButtonBarItem item)
		{
			int num = 0;
			if (this.GetButtonTexture(item) != null)
			{
				num += 64;
			}
			TextRenderInfo textRenderInfo = this.GetTextRenderInfo(default(Rectanglei), item.Text);
			return num + (int)g.MeasureText(textRenderInfo).Width;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0001D0A4 File Offset: 0x0001B2A4
		public void Draw(Renderer renderer)
		{
			I2dRenderer g = renderer.Get2dRenderer();
			if (this._layoutDirty)
			{
				this._layoutDirty = false;
				this.CalculateItemPositions(g);
			}
			this.DrawStrip(g);
			int y = this.Bounds.Centre.Y;
			for (int i = 0; i < this._items.Length; i++)
			{
				ButtonBarItem item = this._items[i];
				int x = this._itemX[i];
				this.DrawButton(g, item, x, y);
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0001D12C File Offset: 0x0001B32C
		private void DrawStrip(I2dRenderer g)
		{
			g.BlendMode = BlendMode.Alpha;
			g.RenderQuad(new Colour(0.2, 0.0, 0.0, 0.0), this.Bounds);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0001D17C File Offset: 0x0001B37C
		private void DrawButton(I2dRenderer g, ButtonBarItem item, int x, int y)
		{
			x += 32;
			ITexture buttonTexture = this.GetButtonTexture(item);
			if (buttonTexture != null)
			{
				g.BlendMode = BlendMode.Alpha;
				g.Colour = Colours.White;
				g.RenderTexture(buttonTexture, new Vector2i(x, y), false, false);
				x += 32;
			}
			if (!string.IsNullOrEmpty(item.Text))
			{
				Rectanglei bounds = new Rectanglei(x, y - this.Bounds.Height / 2, 0, this.Bounds.Height);
				TextRenderInfo textRenderInfo = this.GetTextRenderInfo(bounds, item.Text);
				g.RenderText(textRenderInfo);
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0001D218 File Offset: 0x0001B418
		private ITexture GetButtonTexture(ButtonBarItem item)
		{
			GamePadButton button = item.Button;
			if (button == GamePadButton.A)
			{
				return this._controlResources.ButtonA;
			}
			if (button != GamePadButton.B)
			{
				return null;
			}
			return this._controlResources.ButtonB;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0001D250 File Offset: 0x0001B450
		private TextRenderInfo GetTextRenderInfo(Rectanglei bounds, string text)
		{
			return new TextRenderInfo
			{
				Bounds = bounds,
				Colour = Colours.White,
				Overlay = new int?(0),
				Alignment = FontAlignment.MiddleY,
				Font = this._controlResources.Font,
				SizeMultiplier = 0.75f,
				Text = text
			};
		}

		// Token: 0x040004EE RID: 1262
		private readonly IControlResources _controlResources;

		// Token: 0x040004EF RID: 1263
		private Rectanglei _bounds;

		// Token: 0x040004F0 RID: 1264
		private ImmutableArray<ButtonBarItem> _items;

		// Token: 0x040004F1 RID: 1265
		private bool _layoutDirty = true;

		// Token: 0x040004F2 RID: 1266
		private int[] _itemX;
	}
}
