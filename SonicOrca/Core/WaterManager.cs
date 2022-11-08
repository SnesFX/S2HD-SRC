using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000151 RID: 337
	public class WaterManager
	{
		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000DFE RID: 3582 RVA: 0x00035BEF File Offset: 0x00033DEF
		public Level Level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000DFF RID: 3583 RVA: 0x00035BF7 File Offset: 0x00033DF7
		// (set) Token: 0x06000E00 RID: 3584 RVA: 0x00035BFF File Offset: 0x00033DFF
		public bool Enabled { get; set; }

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000E01 RID: 3585 RVA: 0x00035C08 File Offset: 0x00033E08
		public IList<Rectanglei> WaterAreas
		{
			get
			{
				return this._waterAreas;
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x00035C10 File Offset: 0x00033E10
		// (set) Token: 0x06000E03 RID: 3587 RVA: 0x00035C18 File Offset: 0x00033E18
		public double HueTarget { get; set; }

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x00035C21 File Offset: 0x00033E21
		// (set) Token: 0x06000E05 RID: 3589 RVA: 0x00035C29 File Offset: 0x00033E29
		public double HueAmount { get; set; }

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000E06 RID: 3590 RVA: 0x00035C32 File Offset: 0x00033E32
		// (set) Token: 0x06000E07 RID: 3591 RVA: 0x00035C3A File Offset: 0x00033E3A
		public double SaturationChange { get; set; }

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000E08 RID: 3592 RVA: 0x00035C43 File Offset: 0x00033E43
		// (set) Token: 0x06000E09 RID: 3593 RVA: 0x00035C4B File Offset: 0x00033E4B
		public double LuminosityChange { get; set; }

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000E0A RID: 3594 RVA: 0x00035C54 File Offset: 0x00033E54
		// (set) Token: 0x06000E0B RID: 3595 RVA: 0x00035C5C File Offset: 0x00033E5C
		public double WavePhase { get; set; }

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000E0C RID: 3596 RVA: 0x00035C65 File Offset: 0x00033E65
		// (set) Token: 0x06000E0D RID: 3597 RVA: 0x00035C6D File Offset: 0x00033E6D
		public double NumWaves { get; set; }

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000E0E RID: 3598 RVA: 0x00035C76 File Offset: 0x00033E76
		// (set) Token: 0x06000E0F RID: 3599 RVA: 0x00035C7E File Offset: 0x00033E7E
		public double WaveSize { get; set; }

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x00035C87 File Offset: 0x00033E87
		// (set) Token: 0x06000E11 RID: 3601 RVA: 0x00035C8F File Offset: 0x00033E8F
		public string SurfaceResourceKey { get; set; }

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000E12 RID: 3602 RVA: 0x00035C98 File Offset: 0x00033E98
		// (set) Token: 0x06000E13 RID: 3603 RVA: 0x00035CA0 File Offset: 0x00033EA0
		public double SurfaceOffsetY { get; set; }

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000E14 RID: 3604 RVA: 0x00035CA9 File Offset: 0x00033EA9
		// (set) Token: 0x06000E15 RID: 3605 RVA: 0x00035CB1 File Offset: 0x00033EB1
		internal AnimationGroup SpashEnterAnimationGroup { get; set; }

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x00035CBA File Offset: 0x00033EBA
		// (set) Token: 0x06000E17 RID: 3607 RVA: 0x00035CC2 File Offset: 0x00033EC2
		internal AnimationGroup SpashExitAnimationGroup { get; set; }

		// Token: 0x06000E18 RID: 3608 RVA: 0x00035CCC File Offset: 0x00033ECC
		public WaterManager(Level level)
		{
			this._gameContext = level.GameContext;
			this._level = level;
			this.HueTarget = 0.45;
			this.HueAmount = 0.4;
			this.SaturationChange = -0.5;
			this.LuminosityChange = 0.0;
			this.NumWaves = 1.5;
			this.WaveSize = 4.0;
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x00035D64 File Offset: 0x00033F64
		public void Load()
		{
			if (this.Enabled)
			{
				ResourceTree resourceTree = this._level.GameContext.ResourceTree;
				this.SpashEnterAnimationGroup = resourceTree.GetLoadedResource<AnimationGroup>("SONICORCA/PARTICLE/SPLASH/ENTER");
				this.SpashExitAnimationGroup = resourceTree.GetLoadedResource<AnimationGroup>("SONICORCA/PARTICLE/SPLASH/EXIT");
				WaterManager.waveTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/OBJECTS/WAVE/TEXTURE");
				this.wavesAnimationGroup = resourceTree.GetLoadedResource<AnimationGroup>("SONICORCA/OBJECTS/WAVES/ANIGROUP");
				this._gameContext.Renderer.GetWaterRenderer();
				this._loaded = true;
			}
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x00035DE8 File Offset: 0x00033FE8
		public void Update()
		{
			if (this.Enabled && this._loaded)
			{
				foreach (Splash splash in this._splashes)
				{
					splash.Animate();
				}
				this._splashes.RemoveAll((Splash x) => x.Finished);
			}
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00035E74 File Offset: 0x00034074
		public void Animate()
		{
			if (this.Enabled && this._loaded)
			{
				this._waveFrame++;
				this._waterTime += 0.0166f;
				this.WavePhase = 0.0 * MathX.WrapRadians(this.WavePhase + 0.03125);
			}
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x00035ED8 File Offset: 0x000340D8
		public bool IsUnderwater(Vector2i position)
		{
			return this._waterAreas.Any((Rectanglei x) => x.Contains(position));
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00035F09 File Offset: 0x00034109
		public void CreateSplash(LevelLayer layer, SplashType splashType, Vector2i position)
		{
			this._splashes.Add(new Splash(this, splashType, position));
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00035F1E File Offset: 0x0003411E
		public void CreateBubble(int layer, Vector2i position, int size)
		{
			this._level.ObjectManager.AddObject(new ObjectPlacement(this._level.CommonResources.GetResourcePath("bubbleobject"), layer, position, new
			{
				Size = size
			}));
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x00035F54 File Offset: 0x00034154
		public void Draw(Renderer renderer, Viewport viewport)
		{
			if (this.Enabled && this._loaded)
			{
				this.DrawSplashes(renderer, viewport);
				foreach (Rectanglei r in this._waterAreas)
				{
					Rectangle r2 = r;
					this.Draw(renderer, viewport, r2);
				}
			}
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x00035FCC File Offset: 0x000341CC
		public void DrawSplashes(Renderer renderer, Viewport viewport)
		{
			if (this._splashes.Count > 0)
			{
				using (viewport.ApplyRendererState(renderer))
				{
					I2dRenderer i2dRenderer = renderer.Get2dRenderer();
					i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate((double)(-(double)viewport.Bounds.X), (double)(-(double)viewport.Bounds.Y), 0.0);
					foreach (Splash splash in this._splashes)
					{
						splash.Draw(i2dRenderer);
					}
				}
				renderer.DeativateRenderer();
			}
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00036098 File Offset: 0x00034298
		public void Draw(Renderer renderer, Viewport viewport, Rectanglei waterArea)
		{
			WaterManager.waveTexture = this.wavesAnimationGroup.Textures[this._waveFrame / 2 % 32];
			Rectanglei bounds = viewport.Bounds;
			bounds.Left = Math.Max(bounds.Left, waterArea.Left);
			bounds.Top = Math.Max(bounds.Top, waterArea.Top);
			bounds.Right = Math.Min(bounds.Right, waterArea.Right);
			bounds.Bottom = Math.Min(bounds.Bottom, waterArea.Bottom);
			bounds.X -= viewport.Bounds.X;
			bounds.Y -= viewport.Bounds.Y;
			Vector2 scale = viewport.Scale;
			bounds.X = (int)((double)bounds.X * scale.X);
			bounds.Y = (int)((double)bounds.Y * scale.Y);
			bounds.Width = (int)((double)bounds.Width * scale.X);
			bounds.Height = (int)((double)bounds.Height * scale.Y);
			if (bounds.Width < 0 || (double)bounds.Height < -(this.WavePhase + (double)waterArea.Y / 1080.0 * 6.283185307179586))
			{
				return;
			}
			IWaterRenderer waterRenderer = renderer.GetWaterRenderer();
			waterRenderer.HueTarget = this.HueTarget;
			waterRenderer.HueAmount = this.HueAmount;
			waterRenderer.SaturationChange = this.SaturationChange;
			waterRenderer.LuminosityChange = this.LuminosityChange;
			waterRenderer.WavePhase = 0.0;
			waterRenderer.NumWaves = this.NumWaves / scale.Y;
			waterRenderer.WaveSize = this.WaveSize * scale.X;
			waterRenderer.Time = this._waterTime;
			WaterManager.offsetX = (float)viewport.Bounds.Left;
			WaterManager.offsetY = (float)viewport.Bounds.Top;
			WaterManager.viewportWaterLevel = (float)bounds.Y;
			waterRenderer.Render(bounds);
		}

		// Token: 0x040007E4 RID: 2020
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040007E5 RID: 2021
		private readonly Level _level;

		// Token: 0x040007E6 RID: 2022
		private readonly List<Rectanglei> _waterAreas = new List<Rectanglei>();

		// Token: 0x040007F1 RID: 2033
		public static float offsetX;

		// Token: 0x040007F2 RID: 2034
		public static float offsetY;

		// Token: 0x040007F3 RID: 2035
		public static float viewportWaterLevel;

		// Token: 0x040007F4 RID: 2036
		public static ITexture waveTexture;

		// Token: 0x040007F5 RID: 2037
		private AnimationGroup wavesAnimationGroup;

		// Token: 0x040007F6 RID: 2038
		private int _waveFrame;

		// Token: 0x040007F7 RID: 2039
		private float _waterTime;

		// Token: 0x040007F8 RID: 2040
		private bool _loaded;

		// Token: 0x040007FB RID: 2043
		private readonly List<Splash> _splashes = new List<Splash>();
	}
}
