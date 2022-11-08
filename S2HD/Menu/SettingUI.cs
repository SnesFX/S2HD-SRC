using System;
using System.Linq;
using SonicOrca;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace S2HD.Menu
{
	// Token: 0x020000BA RID: 186
	internal class SettingUI
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x0001E028 File Offset: 0x0001C228
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x0001E030 File Offset: 0x0001C230
		public Rectanglei Bounds { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x0001E039 File Offset: 0x0001C239
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x0001E041 File Offset: 0x0001C241
		public bool Highlighted { get; set; }

		// Token: 0x06000472 RID: 1138 RVA: 0x0001E04C File Offset: 0x0001C24C
		public SettingUI(ISetting setting, ISettingUIResources resources)
		{
			this._setting = setting;
			this._resources = resources;
			this._name = setting.Name;
			if (setting is ISpinnerSetting)
			{
				this._values = (setting as ISpinnerSetting).Values.ToArray<string>();
			}
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0001E0AF File Offset: 0x0001C2AF
		public void Draw(Renderer renderer)
		{
			this.DrawLeft(renderer);
			this.DrawRight(renderer);
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0001E0BF File Offset: 0x0001C2BF
		private void DrawLeft(Renderer renderer)
		{
			renderer.GetFontRenderer().RenderStringWithShadow(this._name, this.Bounds, FontAlignment.MiddleY, this._resources.Font, this.FontColour, new int?(this.FontOverlay));
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0001E0FC File Offset: 0x0001C2FC
		private void DrawRight(Renderer renderer)
		{
			if (this._setting is IAudioSliderSetting)
			{
				this.DrawRightAudioSlider(renderer, this._setting as IAudioSliderSetting);
				return;
			}
			if (this._setting is ISpinnerSetting)
			{
				this.DrawRightSpinner(renderer, this._setting as ISpinnerSetting);
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0001E148 File Offset: 0x0001C348
		private void DrawRightAudioSlider(Renderer renderer, IAudioSliderSetting setting)
		{
			ITexture audioSliderEmptyTexture = this._resources.AudioSliderEmptyTexture;
			ITexture texture = this.Highlighted ? this._resources.AudioSliderGoldTexture : this._resources.AudioSliderSilverTexture;
			Rectanglei rectanglei = new Rectanglei(0, 0, audioSliderEmptyTexture.Width, audioSliderEmptyTexture.Height);
			rectanglei.X = this.Bounds.Right - audioSliderEmptyTexture.Width - 24;
			rectanglei.Y = this.Bounds.Centre.Y - rectanglei.Height / 2;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderTexture(audioSliderEmptyTexture, rectanglei, false, false);
			int num = (int)Math.Floor(setting.Value * (double)this.SliderWidths.Length);
			num = MathX.Clamp(0, num, this.SliderWidths.Length - 1);
			int width = this.SliderWidths[num];
			Rectanglei r = rectanglei;
			r.Width = width;
			i2dRenderer.RenderTexture(texture, new Rectangle(0.0, 0.0, (double)r.Width, (double)r.Height), r, false, false);
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			Rectanglei bounds = this.Bounds;
			fontRenderer.RenderStringWithShadow('▶'.ToString(), bounds, (FontAlignment)6, this._resources.Font, this.FontColour, new int?(this.FontOverlay));
			bounds.Right = rectanglei.X + 12;
			fontRenderer.RenderStringWithShadow('◀'.ToString(), bounds, (FontAlignment)6, this._resources.Font, this.FontColour, new int?(this.FontOverlay));
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0001E2F8 File Offset: 0x0001C4F8
		private void DrawRightSpinner(Renderer renderer, ISpinnerSetting setting)
		{
			int selectedIndex = setting.SelectedIndex;
			string str = this._values[selectedIndex];
			string text = "◀ " + str + " ▶";
			renderer.GetFontRenderer().RenderStringWithShadow(text, this.Bounds, (FontAlignment)6, this._resources.Font, this.FontColour, new int?(this.FontOverlay));
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x0001E35A File Offset: 0x0001C55A
		private Colour FontColour
		{
			get
			{
				if (!this.Highlighted)
				{
					return Colour.FromOpacity(0.6);
				}
				return Colours.White;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x0001E378 File Offset: 0x0001C578
		private int FontOverlay
		{
			get
			{
				if (!this.Highlighted)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x04000519 RID: 1305
		private readonly int[] SliderWidths = new int[]
		{
			0,
			45,
			59,
			73,
			89,
			105,
			121,
			139,
			159,
			181,
			223
		};

		// Token: 0x0400051A RID: 1306
		private const char ArrowLeftChar = '◀';

		// Token: 0x0400051B RID: 1307
		private const char ArrowRightChar = '▶';

		// Token: 0x0400051C RID: 1308
		private readonly ISetting _setting;

		// Token: 0x0400051D RID: 1309
		private readonly ISettingUIResources _resources;

		// Token: 0x0400051E RID: 1310
		private string _name;

		// Token: 0x0400051F RID: 1311
		private string[] _values;
	}
}
