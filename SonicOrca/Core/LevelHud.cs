using System;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Core.Objects;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000110 RID: 272
	internal class LevelHud : IDisposable
	{
		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x00026B0E File Offset: 0x00024D0E
		// (set) Token: 0x06000A10 RID: 2576 RVA: 0x00026B16 File Offset: 0x00024D16
		public bool ItalicFont { get; set; }

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x00026B1F File Offset: 0x00024D1F
		// (set) Token: 0x06000A12 RID: 2578 RVA: 0x00026B27 File Offset: 0x00024D27
		public bool ShowMiliseconds { get; set; }

		// Token: 0x06000A13 RID: 2579 RVA: 0x00026B30 File Offset: 0x00024D30
		public LevelHud(Level level)
		{
			this._level = level;
			this.ItalicFont = true;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00026B48 File Offset: 0x00024D48
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._level.GameContext.ResourceTree;
			this._fontResourceKey = (this.ItalicFont ? "SONICORCA/FONTS/HUDITALIC" : "SONICORCA/FONTS/HUD");
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependencies(new string[]
			{
				this._fontResourceKey,
				"SONICORCA/HUD/CHECKERED",
				"SONICORCA/HUD/CHECKERED/TAILS",
				"SONICORCA/HUD/TRIANGLE",
				"SONICORCA/HUD/TRIANGLE/TAILS",
				"SONICORCA/HUD/TRIANGLE/KNUCKLES",
				"SONICORCA/HUD/LIFE/SONIC",
				"SONICORCA/HUD/LIFE/TAILS"
			});
			await this._resourceSession.LoadAsync(ct, false);
			this._font = resourceTree.GetLoadedResource<Font>(this._fontResourceKey);
			this._checkeredTextureSonic = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/CHECKERED");
			this._checkeredTextureTails = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/CHECKERED/TAILS");
			this._triangleTextureSonic = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TRIANGLE");
			this._triangleTextureTails = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TRIANGLE/TAILS");
			this._triangleTextureKnuckles = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TRIANGLE/KNUCKLES");
			this._lifeTextureSonic = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/LIFE/SONIC");
			this._lifeTextureTails = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/LIFE/TAILS");
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00026B95 File Offset: 0x00024D95
		public void Dispose()
		{
			if (this._resourceSession != null)
			{
				this._resourceSession.Dispose();
			}
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00026BAA File Offset: 0x00024DAA
		public void Animate()
		{
			this._redAnimation = (this._redAnimation + 0.05) % 2.0;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00026BCC File Offset: 0x00024DCC
		public void Draw(Renderer renderer)
		{
			ICharacter protagonist = this._level.Player.Protagonist;
			if (protagonist != null && protagonist.IsDebug)
			{
				this.DrawDebug(renderer);
				return;
			}
			this.DrawNormal(renderer);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00026C04 File Offset: 0x00024E04
		private void DrawNormal(Renderer renderer)
		{
			this.DrawTLInfo(renderer, 226.0, 610.0, 98.0, "SCORE", this._level.Player.Score.ToString(), false, true);
			int num = this._level.Time / 60 / 60;
			int num2 = this._level.Time / 60 % 60;
			int num3 = this._level.Time % 60 * 100 / 60;
			if (this.ShowMiliseconds)
			{
				this.DrawTLInfo(renderer, 226.0, 400.0, 162.0, "TIME", string.Format("{0}'{1:00}\"{2:00}", num, num2, num3), num >= 9, false);
			}
			else
			{
				this.DrawTLInfo(renderer, 226.0, 400.0, 162.0, "TIME", string.Format("{0}:{1:00}", num, num2), num >= 9, false);
			}
			this.DrawTLInfo(renderer, 226.0, 516.0, 226.0, "RINGS", this._level.Player.CurrentRings.ToString(), this._level.Player.CurrentRings == 0, true);
			if (this._level.Player.Lives >= 0)
			{
				this.DrawLives(renderer);
			}
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00026D94 File Offset: 0x00024F94
		private void DrawDebug(Renderer renderer)
		{
			ICharacter protagonist = this._level.Player.Protagonist;
			this.DrawTLInfoHexCoordinate(renderer, 226.0, 98.0, "PLAYER", protagonist.Position);
			this.DrawTLInfoHexCoordinate(renderer, 226.0, 162.0, "SCROLL", (Vector2i)this._level.Camera.Bounds.TopLeft);
			this.DrawBottomText(renderer, "DEBUG MODE");
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00026E20 File Offset: 0x00025020
		private void DrawTLInfoHexCoordinate(Renderer renderer, double captionLeft, double captionTop, string caption, Vector2i coordinate)
		{
			this.DrawTLInfo(renderer, captionLeft, captionLeft + 630.0, captionTop, caption, string.Format("{0:X5} {1:X5}", coordinate.X & 1048575, coordinate.Y & 1048575), false, true);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00026E74 File Offset: 0x00025074
		private void DrawTLInfo(Renderer renderer, double captionLeft, double valueRight, double top, string caption, string value, bool redAnimate = false, bool rightAligned = true)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			i2dRenderer.BlendMode = BlendMode.Alpha;
			i2dRenderer.Colour = new Colour(96, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			if (this._level.Player.ProtagonistCharacterType == CharacterType.Sonic)
			{
				i2dRenderer.RenderTexture(this._checkeredTextureSonic, new Vector2(captionLeft - (double)(this._checkeredTextureSonic.Width / 2) - 8.0, top + (double)this._font.Height / 2.0), false, false);
			}
			else
			{
				if (this._level.Player.ProtagonistCharacterType != CharacterType.Tails)
				{
					throw new NotImplementedException();
				}
				i2dRenderer.RenderTexture(this._checkeredTextureTails, new Vector2(captionLeft - (double)(this._checkeredTextureTails.Width / 2) - 8.0, top + (double)this._font.Height / 2.0), false, false);
			}
			if (rightAligned)
			{
				fontRenderer.RenderStringWithShadow(value, new Rectangle(0.0, top, valueRight, 0.0), FontAlignment.Right, this._font, 0);
			}
			else
			{
				fontRenderer.RenderStringWithShadow(value, new Rectangle(valueRight, top, 0.0, 0.0), FontAlignment.Left, this._font, 0);
			}
			Rectangle boundary = new Rectangle(captionLeft, top, 0.0, 0.0);
			FontAlignment fontAlignment = FontAlignment.Left;
			Rectangle rectangle = this._font.MeasureString(caption, boundary, fontAlignment);
			i2dRenderer.Colour = new Colour(155, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			if (this._level.Player.ProtagonistCharacterType == CharacterType.Sonic)
			{
				i2dRenderer.RenderTexture(this._triangleTextureSonic, new Vector2(rectangle.Right - 8.0, rectangle.Bottom - 4.0), false, false);
			}
			else if (this._level.Player.ProtagonistCharacterType == CharacterType.Tails)
			{
				i2dRenderer.RenderTexture(this._triangleTextureTails, new Vector2(rectangle.Right - 8.0, rectangle.Bottom - 4.0), false, false);
			}
			else
			{
				i2dRenderer.RenderTexture(this._triangleTextureKnuckles, new Vector2(rectangle.Right - 8.0, rectangle.Bottom - 4.0), false, false);
			}
			Colour white = Colours.White;
			if (redAnimate)
			{
				double num = (this._redAnimation > 1.0) ? (2.0 - this._redAnimation) : this._redAnimation;
				white = new Colour(1.0, 1.0 - num, 1.0 - num);
			}
			fontRenderer.RenderStringWithShadow(caption, new Rectangle(captionLeft, top, 0.0, 0.0), fontAlignment, this._font, white, new int?(1));
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00027170 File Offset: 0x00025370
		private void DrawLives(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			i2dRenderer.Colour = Colours.White;
			if (this._level.Player.ProtagonistCharacterType == CharacterType.Sonic)
			{
				i2dRenderer.RenderTexture(this._lifeTextureSonic, new Vector2(264.0, 958.0), false, false);
			}
			else
			{
				if (this._level.Player.ProtagonistCharacterType != CharacterType.Tails)
				{
					throw new NotImplementedException();
				}
				i2dRenderer.RenderTexture(this._lifeTextureTails, new Vector2(264.0, 958.0), false, false);
			}
			fontRenderer.RenderStringWithShadow("×", new Rectangle(300.0, 934.0, 0.0, 0.0), FontAlignment.Left, this._font, 1);
			fontRenderer.RenderStringWithShadow(this._level.Player.Lives.ToString(), new Rectangle(370.0, 934.0, 0.0, 0.0), FontAlignment.Left, this._font, 0);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0002729C File Offset: 0x0002549C
		private void DrawBottomText(Renderer renderer, string text)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			i2dRenderer.Colour = Colours.White;
			if (this._level.Player.ProtagonistCharacterType == CharacterType.Sonic)
			{
				i2dRenderer.RenderTexture(this._lifeTextureSonic, new Vector2(264.0, 958.0), false, false);
			}
			else
			{
				if (this._level.Player.ProtagonistCharacterType != CharacterType.Tails)
				{
					throw new NotImplementedException();
				}
				i2dRenderer.RenderTexture(this._lifeTextureTails, new Vector2(264.0, 958.0), false, false);
			}
			fontRenderer.RenderStringWithShadow(text, new Rectangle(310.0, 934.0, 0.0, 0.0), FontAlignment.Left, this._font, 1);
		}

		// Token: 0x040005C8 RID: 1480
		private const string HudFontResourceKey = "SONICORCA/FONTS/HUD";

		// Token: 0x040005C9 RID: 1481
		private const string HudItalicFontResourceKey = "SONICORCA/FONTS/HUDITALIC";

		// Token: 0x040005CA RID: 1482
		private const string SonicCheckeredResourceKey = "SONICORCA/HUD/CHECKERED";

		// Token: 0x040005CB RID: 1483
		private const string TailsCheckeredResourceKey = "SONICORCA/HUD/CHECKERED/TAILS";

		// Token: 0x040005CC RID: 1484
		private const string SonicTriangleResourceKey = "SONICORCA/HUD/TRIANGLE";

		// Token: 0x040005CD RID: 1485
		private const string TailsTriangleResourceKey = "SONICORCA/HUD/TRIANGLE/TAILS";

		// Token: 0x040005CE RID: 1486
		private const string KnucklesTriangleResourceKey = "SONICORCA/HUD/TRIANGLE/KNUCKLES";

		// Token: 0x040005CF RID: 1487
		private const string SonicLifeResourceKey = "SONICORCA/HUD/LIFE/SONIC";

		// Token: 0x040005D0 RID: 1488
		private const string TailsLifeResourceKey = "SONICORCA/HUD/LIFE/TAILS";

		// Token: 0x040005D1 RID: 1489
		private const string szScore = "SCORE";

		// Token: 0x040005D2 RID: 1490
		private const string szTime = "TIME";

		// Token: 0x040005D3 RID: 1491
		private const string szRings = "RINGS";

		// Token: 0x040005D4 RID: 1492
		private readonly Level _level;

		// Token: 0x040005D5 RID: 1493
		private ResourceSession _resourceSession;

		// Token: 0x040005D6 RID: 1494
		private string _fontResourceKey;

		// Token: 0x040005D7 RID: 1495
		private Font _font;

		// Token: 0x040005D8 RID: 1496
		private ITexture _checkeredTextureSonic;

		// Token: 0x040005D9 RID: 1497
		private ITexture _checkeredTextureTails;

		// Token: 0x040005DA RID: 1498
		private ITexture _triangleTextureSonic;

		// Token: 0x040005DB RID: 1499
		private ITexture _triangleTextureTails;

		// Token: 0x040005DC RID: 1500
		private ITexture _triangleTextureKnuckles;

		// Token: 0x040005DD RID: 1501
		private ITexture _lifeTextureSonic;

		// Token: 0x040005DE RID: 1502
		private ITexture _lifeTextureTails;

		// Token: 0x040005DF RID: 1503
		private double _redAnimation;
	}
}
