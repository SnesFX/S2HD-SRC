using System;
using SonicOrca;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace S2HD.Title
{
	// Token: 0x020000A5 RID: 165
	internal class Background
	{
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x0001A8F9 File Offset: 0x00018AF9
		// (set) Token: 0x060003D5 RID: 981 RVA: 0x0001A901 File Offset: 0x00018B01
		public bool Visible { get; set; }

		// Token: 0x060003D6 RID: 982 RVA: 0x0001A90A File Offset: 0x00018B0A
		public Background(S2HDSonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._gameContext.ResourceTree.FullfillLoadedResourcesByAttribute(this);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0001A92C File Offset: 0x00018B2C
		public void Reset()
		{
			this._ticks = 0;
			this._backgroundFlash = 0.0;
			this._backgroundSkyCentreX = 1260.0;
			this._backgroundIslandCentreX = 1088.0;
			this._waterSparkleAnimationInstance = null;
			this.Visible = false;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0001A97B File Offset: 0x00018B7B
		public void WipeOut()
		{
			this._wipeTransitionActive = true;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0001A984 File Offset: 0x00018B84
		public void Update()
		{
			if (this._ticks == 0)
			{
				this.Visible = true;
				this._backgroundFlash = 1.0;
				this._waterSparkleAnimationInstance = new AnimationInstance(this._animationGroup, 10);
				this._waterSparkleAnimationInstance.AdditiveBlending = true;
			}
			else
			{
				this._backgroundFlash = Math.Max(0.0, this._backgroundFlash - 0.03125);
			}
			this._backgroundSkyCentreX += -0.05;
			this._backgroundIslandCentreX += -0.1;
			if (this._backgroundSkyCentreX + (double)(this._textureBackgroundSky.Width / 2) < 0.0)
			{
				this._backgroundSkyCentreX = (double)(this._textureBackgroundSky.Width / 2);
			}
			if (this._backgroundIslandCentreX < (double)(-(double)this._textureBackgroundIsland.Width))
			{
				this._backgroundIslandCentreX = (double)(1920 + this._textureBackgroundIsland.Width);
			}
			this._waterSparkleAnimationInstance.Animate();
			if (this._wipeTransitionActive)
			{
				this._wipeHeight += 20;
				if (this._wipeHeight >= 600)
				{
					this._wipeTransitionActive = false;
				}
			}
			this._ticks++;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0001AAC8 File Offset: 0x00018CC8
		public void Draw(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.BlendMode = BlendMode.Alpha;
			if (this.Visible)
			{
				i2dRenderer.Colour = Colours.White;
				int num = (int)this._backgroundSkyCentreX;
				do
				{
					i2dRenderer.RenderTexture(this._textureBackgroundSky, new Vector2i(num, 540), false, false);
					num += this._textureBackgroundSky.Width;
				}
				while (num - this._textureBackgroundSky.Width / 2 < 1920);
				i2dRenderer.RenderTexture(this._textureBackgroundDeathEgg, new Vector2(1750.0, 192.0), false, false);
				i2dRenderer.RenderTexture(this._textureBackgroundIsland, new Vector2(this._backgroundIslandCentreX, 540.0), false, false);
				this._waterSparkleAnimationInstance.Draw(i2dRenderer, new Vector2(this._backgroundIslandCentreX + 38.0, 892.0), false, false);
			}
			if (this._backgroundFlash > 0.0)
			{
				i2dRenderer.RenderQuad(new Colour(this._backgroundFlash, 1.0, 1.0, 1.0), new Rectangle(0.0, 0.0, 1920.0, 1080.0));
			}
			if (this._wipeHeight > 0)
			{
				Rectanglei r = new Rectanglei(0, this._wipeHeight - this._textureWipe.Height, 1920, this._textureWipe.Height);
				i2dRenderer.RenderTexture(this._textureWipe, r, false, false);
				r = new Rectanglei(0, 1080 - this._wipeHeight, 1920, this._textureWipe.Height);
				i2dRenderer.RenderTexture(this._textureWipe, r, false, true);
			}
		}

		// Token: 0x04000467 RID: 1127
		private const int BackgroundSkyStartX = 1260;

		// Token: 0x04000468 RID: 1128
		private const int BackgroundIslandStartX = 1088;

		// Token: 0x04000469 RID: 1129
		private const double BackgroundSkyVelocity = -0.05;

		// Token: 0x0400046A RID: 1130
		private const double BackgroundIslandVelocity = -0.1;

		// Token: 0x0400046B RID: 1131
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x0400046C RID: 1132
		[ResourcePath("SONICORCA/TITLE/BACKGROUND/SKY")]
		private ITexture _textureBackgroundSky;

		// Token: 0x0400046D RID: 1133
		[ResourcePath("SONICORCA/TITLE/BACKGROUND/ISLAND")]
		private ITexture _textureBackgroundIsland;

		// Token: 0x0400046E RID: 1134
		[ResourcePath("SONICORCA/TITLE/BACKGROUND/DEATHEGG")]
		private ITexture _textureBackgroundDeathEgg;

		// Token: 0x0400046F RID: 1135
		[ResourcePath("SONICORCA/TITLE/WIPE")]
		private ITexture _textureWipe;

		// Token: 0x04000470 RID: 1136
		[ResourcePath("SONICORCA/TITLE/ANIGROUP")]
		private AnimationGroup _animationGroup;

		// Token: 0x04000471 RID: 1137
		private AnimationInstance _waterSparkleAnimationInstance;

		// Token: 0x04000472 RID: 1138
		private double _backgroundFlash;

		// Token: 0x04000473 RID: 1139
		private double _backgroundSkyCentreX;

		// Token: 0x04000474 RID: 1140
		private double _backgroundIslandCentreX;

		// Token: 0x04000475 RID: 1141
		private int _ticks;

		// Token: 0x04000476 RID: 1142
		private int _wipeHeight;

		// Token: 0x04000477 RID: 1143
		private bool _wipeTransitionActive;
	}
}
