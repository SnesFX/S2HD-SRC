using System;
using System.Collections.Generic;
using SonicOrca;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace S2HD.Title
{
	// Token: 0x020000A6 RID: 166
	internal class Banner
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060003DB RID: 987 RVA: 0x0001AC9B File Offset: 0x00018E9B
		// (set) Token: 0x060003DC RID: 988 RVA: 0x0001ACA3 File Offset: 0x00018EA3
		public Vector2i Position { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060003DD RID: 989 RVA: 0x0001ACAC File Offset: 0x00018EAC
		// (set) Token: 0x060003DE RID: 990 RVA: 0x0001ACB4 File Offset: 0x00018EB4
		public bool ShowStarLensFare { get; set; }

		// Token: 0x060003DF RID: 991 RVA: 0x0001ACBD File Offset: 0x00018EBD
		public Banner(S2HDSonicOrcaGameContext gameContext, IMaskRenderer maskRenderer)
		{
			this._gameContext = gameContext;
			this._maskRenderer = maskRenderer;
			this.GetResourceReferences();
			this.Position = new Vector2i(960, 476);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0001ACFC File Offset: 0x00018EFC
		private void GetResourceReferences()
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._animationGroup = resourceTree.GetLoadedResource<AnimationGroup>("SONICORCA/TITLE/ANIGROUP");
			this._bannerTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/TITLE/FRAMES/0");
			this._bannerInsideTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/TITLE/FRAMES/1");
			this._titleOutlineTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/TITLE/ADDFRAMES/0");
			this._maskTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/TITLE/ADDFRAMES/1");
			this._hdStarTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/TITLE/ADDFRAMES/2");
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0001AD7C File Offset: 0x00018F7C
		public void Reset()
		{
			this._ticks = 0;
			this._preBannerStarSpin = new AnimationInstance[8];
			this._sonicAnimationInstance = null;
			this._sonicHandAnimationInstance = null;
			this._tailsAnimationInstance = null;
			this._tailsTailsAnimationInstance = null;
			this._sonic2AnimationInstance = null;
			this._theHedgehogAnimationInstance = null;
			this._hdAnimationInstance = null;
			this._bannerInsideOpacity = 0.0;
			this._bannerOpacity = 0.0;
			this._sonic2Opacity = 0.0;
			this._maskOffset = -1.0;
			this.ShowStarLensFare = false;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0001AE10 File Offset: 0x00019010
		public void DoShine(int duration)
		{
			this._effectEventManager.BeginEvent(this.EffectShine(duration));
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0001AE24 File Offset: 0x00019024
		private IEnumerable<UpdateResult> EffectShine(int duration)
		{
			this._maskOffset = -1.0;
			do
			{
				yield return UpdateResult.Next();
				this._maskOffset += 2.0 / (double)duration;
			}
			while (this._maskOffset < 1.0);
			this._maskOffset = 1.0;
			yield break;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0001AE3C File Offset: 0x0001903C
		public void Update()
		{
			if (this._ticks == 268)
			{
				this.DoShine(368);
			}
			if (this._ticks >= 296)
			{
				this._bannerInsideOpacity = Math.Min(1.0, this._bannerInsideOpacity + 0.013888888888888888);
			}
			if (this._ticks >= 332)
			{
				this._bannerOpacity = Math.Min(1.0, this._bannerOpacity + 0.03125);
			}
			for (int i = 0; i < this._preBannerStarSpin.Length; i++)
			{
				if (this._preBannerStarSpin[i] == null)
				{
					if (this._ticks >= 298 + i * 4)
					{
						this._preBannerStarSpin[i] = new AnimationInstance(this._animationGroup, 3);
					}
				}
				else if (this._preBannerStarSpin[i].Cycles == 0)
				{
					this._preBannerStarSpin[i].Animate();
				}
			}
			if (this._ticks >= 346)
			{
				this._sonic2Opacity = Math.Min(1.0, this._sonic2Opacity + 0.0625);
				if (this._sonic2AnimationInstance == null)
				{
					this._sonic2AnimationInstance = new AnimationInstance(this._animationGroup, 2);
				}
			}
			if (this._ticks >= 360)
			{
				if (this._theHedgehogAnimationInstance == null)
				{
					this._theHedgehogAnimationInstance = new AnimationInstance(this._animationGroup, 1);
				}
				this._theHedgehogAnimationInstance.Animate();
			}
			if (this._ticks >= 364)
			{
				if (this._sonicAnimationInstance == null)
				{
					this._sonicAnimationInstance = new AnimationInstance(this._animationGroup, 4);
				}
				this._sonicAnimationInstance.Animate();
			}
			if (this._ticks >= 413)
			{
				if (this._sonicHandAnimationInstance == null)
				{
					this._sonicHandAnimationInstance = new AnimationInstance(this._animationGroup, 5);
				}
				this._sonicHandAnimationInstance.Animate();
			}
			if (this._ticks >= 400)
			{
				if (this._tailsAnimationInstance == null)
				{
					this._tailsAnimationInstance = new AnimationInstance(this._animationGroup, 6);
					this._tailsTailsAnimationInstance = new AnimationInstance(this._animationGroup, 7);
				}
				this._tailsAnimationInstance.Animate();
				this._tailsTailsAnimationInstance.Animate();
			}
			if (this._ticks >= 436)
			{
				this._sonic2AnimationInstance.Animate();
			}
			if (this._ticks >= 454)
			{
				if (this._hdAnimationInstance == null)
				{
					this._hdAnimationInstance = new AnimationInstance(this._animationGroup, 0);
				}
				this._hdAnimationInstance.Animate();
			}
			this._effectEventManager.Update();
			this._ticks++;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0001B0B8 File Offset: 0x000192B8
		public void Draw(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.BlendMode = BlendMode.Alpha;
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate((double)this.Position.X, (double)this.Position.Y, 0.0);
				if (this._bannerInsideOpacity > 0.0 && this._bannerOpacity < 1.0)
				{
					i2dRenderer.Colour = new Colour(this._bannerInsideOpacity, 1.0, 1.0, 1.0);
					i2dRenderer.RenderTexture(this._bannerInsideTexture, new Vector2(0.0, -114.0), false, false);
				}
				if (this._bannerOpacity > 0.0)
				{
					i2dRenderer.Colour = new Colour(this._bannerOpacity, 1.0, 1.0, 1.0);
					i2dRenderer.RenderTexture(this._bannerTexture, new Vector2(0.0, 0.0), false, false);
				}
				for (int i = 0; i < 8; i++)
				{
					if (this._preBannerStarSpin[i] != null && this._preBannerStarSpin[i].Cycles == 0)
					{
						this._preBannerStarSpin[i].Draw(i2dRenderer, Banner.SpinningStarOffsets[i], false, false);
					}
				}
				this.DrawSonicAndTails(renderer);
				if (this._sonic2AnimationInstance != null)
				{
					this._sonic2AnimationInstance.Draw(i2dRenderer, new Colour(this._sonic2Opacity, 1.0, 1.0, 1.0), new Vector2(0.0, 77.0), false, false);
				}
				if (this._theHedgehogAnimationInstance != null)
				{
					this._theHedgehogAnimationInstance.Draw(i2dRenderer, new Vector2(0.0, 153.0), false, false);
				}
				if (this._hdAnimationInstance != null)
				{
					this._hdAnimationInstance.Draw(i2dRenderer, new Vector2(0.0, 266.0), false, false);
				}
				if (this.ShowStarLensFare)
				{
					i2dRenderer.BlendMode = BlendMode.Additive;
					i2dRenderer.RenderTexture(this._hdStarTexture, new Vector2(0.0, 188.0), false, false);
				}
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0001B348 File Offset: 0x00019548
		public void DrawUnfaded(Renderer renderer)
		{
			this.DrawTitleShine(renderer);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0001B354 File Offset: 0x00019554
		private void DrawSonicAndTails(Renderer renderer)
		{
			I2dRenderer renderer2 = renderer.Get2dRenderer();
			if (this._sonicAnimationInstance != null)
			{
				this._sonicAnimationInstance.Draw(renderer2, new Vector2(89.0, -158.0), false, false);
			}
			if (this._sonicHandAnimationInstance != null)
			{
				this._sonicHandAnimationInstance.Draw(renderer2, new Vector2(230.0, -89.0), false, false);
			}
			if (this._tailsTailsAnimationInstance != null)
			{
				this._tailsTailsAnimationInstance.Draw(renderer2, new Vector2(-264.0, -65.0), false, false);
			}
			if (this._tailsAnimationInstance != null)
			{
				this._tailsAnimationInstance.Draw(renderer2, new Vector2(-108.0, -121.0), false, false);
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0001B41C File Offset: 0x0001961C
		private void DrawTitleShine(Renderer renderer)
		{
			if (this._maskOffset <= -1.0 || this._maskOffset >= 1.0)
			{
				return;
			}
			renderer.DeativateRenderer();
			this._maskRenderer.Texture = this._titleOutlineTexture;
			this._maskRenderer.Source = new Rectanglei(0, 0, this._titleOutlineTexture.Width, this._titleOutlineTexture.Height);
			this._maskRenderer.Destination = new Rectanglei(this.Position.X - this._titleOutlineTexture.Width / 2, this.Position.Y - this._titleOutlineTexture.Height / 2, this._titleOutlineTexture.Width, this._titleOutlineTexture.Height);
			this._maskTexture.Wrapping = TextureWrapping.Clamp;
			this._maskRenderer.MaskTexture = this._maskTexture;
			this._maskRenderer.MaskSource = new Rectanglei(0, 0, this._maskTexture.Width, this._maskTexture.Height);
			this._maskRenderer.MaskDestination = new Rectanglei(this.Position.X + (int)(this._maskOffset * 1920.0), this.Position.Y + (int)(this._maskOffset * 1080.0), 1920, 1080);
			this._maskRenderer.BlendMode = BlendMode.Additive;
			this._maskRenderer.Render(true);
		}

		// Token: 0x04000479 RID: 1145
		private const int BannerStartTime = 332;

		// Token: 0x0400047A RID: 1146
		private static readonly Vector2i[] SpinningStarOffsets = new Vector2i[]
		{
			new Vector2i(-214, -41),
			new Vector2i(-190, -129),
			new Vector2i(-130, -193),
			new Vector2i(-50, -233),
			new Vector2i(50, -233),
			new Vector2i(130, -193),
			new Vector2i(190, -129),
			new Vector2i(214, -41)
		};

		// Token: 0x0400047B RID: 1147
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x0400047C RID: 1148
		private readonly IMaskRenderer _maskRenderer;

		// Token: 0x0400047D RID: 1149
		private AnimationGroup _animationGroup;

		// Token: 0x0400047E RID: 1150
		[ResourcePath("SONICORCA/TITLE/FRAMES/0")]
		private ITexture _bannerTexture;

		// Token: 0x0400047F RID: 1151
		[ResourcePath("SONICORCA/TITLE/FRAMES/1")]
		private ITexture _bannerInsideTexture;

		// Token: 0x04000480 RID: 1152
		[ResourcePath("SONICORCA/TITLE/ADDFRAMES/0")]
		private ITexture _hdStarTexture;

		// Token: 0x04000481 RID: 1153
		[ResourcePath("SONICORCA/TITLE/ADDFRAMES/1")]
		private ITexture _maskTexture;

		// Token: 0x04000482 RID: 1154
		[ResourcePath("SONICORCA/TITLE/ADDFRAMES/2")]
		private ITexture _titleOutlineTexture;

		// Token: 0x04000483 RID: 1155
		private AnimationInstance[] _preBannerStarSpin;

		// Token: 0x04000484 RID: 1156
		private AnimationInstance _sonicAnimationInstance;

		// Token: 0x04000485 RID: 1157
		private AnimationInstance _sonicHandAnimationInstance;

		// Token: 0x04000486 RID: 1158
		private AnimationInstance _tailsAnimationInstance;

		// Token: 0x04000487 RID: 1159
		private AnimationInstance _tailsTailsAnimationInstance;

		// Token: 0x04000488 RID: 1160
		private AnimationInstance _sonic2AnimationInstance;

		// Token: 0x04000489 RID: 1161
		private AnimationInstance _theHedgehogAnimationInstance;

		// Token: 0x0400048A RID: 1162
		private AnimationInstance _hdAnimationInstance;

		// Token: 0x0400048B RID: 1163
		private readonly EffectEventManager _effectEventManager = new EffectEventManager();

		// Token: 0x0400048C RID: 1164
		private int _ticks;

		// Token: 0x0400048D RID: 1165
		private double _bannerInsideOpacity;

		// Token: 0x0400048E RID: 1166
		private double _bannerOpacity;

		// Token: 0x0400048F RID: 1167
		private double _sonic2Opacity;

		// Token: 0x04000490 RID: 1168
		private double _maskOffset;
	}
}
