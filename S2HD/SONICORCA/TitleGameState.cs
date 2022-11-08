using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using S2HD;
using S2HD.Title;
using SonicOrca.Audio;
using SonicOrca.Core;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca
{
	// Token: 0x02000092 RID: 146
	internal class TitleGameState : IGameState, IDisposable
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000301 RID: 769 RVA: 0x000163C1 File Offset: 0x000145C1
		// (set) Token: 0x06000302 RID: 770 RVA: 0x000163C9 File Offset: 0x000145C9
		public Background Background { get; private set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000303 RID: 771 RVA: 0x000163D2 File Offset: 0x000145D2
		// (set) Token: 0x06000304 RID: 772 RVA: 0x000163DA File Offset: 0x000145DA
		public LevelPrepareSettings LevelPrepareSettings { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000305 RID: 773 RVA: 0x000163E3 File Offset: 0x000145E3
		// (set) Token: 0x06000306 RID: 774 RVA: 0x000163EB File Offset: 0x000145EB
		public TitleGameState.ResultType Result { get; set; }

		// Token: 0x06000307 RID: 775 RVA: 0x000163F4 File Offset: 0x000145F4
		public TitleGameState(S2HDSonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			Version appVersion = Program.AppVersion;
			this._versionText = string.Format("Version {0}.{1} Demo Build {2}", appVersion.Major, appVersion.Minor, appVersion.Build);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x000164D0 File Offset: 0x000146D0
		private void LoadResources()
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependencies(TitleResources.AllResourceKeys);
			this._loadingCTS = new CancellationTokenSource();
			this._loadingTask = this._resourceSession.LoadAsync(this._loadingCTS.Token, false);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00016530 File Offset: 0x00014730
		private void GetResourceReferences()
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._font = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/HUD");
			this._animationGroup = resourceTree.GetLoadedResource<AnimationGroup>("SONICORCA/TITLE/ANIGROUP");
			this._sparkleSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/SOUND/SPARKLE");
			this._shootingStarSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/SOUND/SHOOTINGSTAR");
			this._musicSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/TITLE/MUSIC");
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0001659E File Offset: 0x0001479E
		public void Dispose()
		{
			this._resourceSession.Dispose();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x000165AB File Offset: 0x000147AB
		public IEnumerable<UpdateResult> Update()
		{
			this._maskRenderer = this._gameContext.Renderer.GetMaskRenderer();
			this.LoadResources();
			while (!this._loadingTask.IsCompleted)
			{
				yield return UpdateResult.Next();
			}
			if (this._loadingTask.IsFaulted)
			{
				yield break;
			}
			this.GetResourceReferences();
			this._loaded = true;
			this.Background = new Background(this._gameContext);
			this._banner = new Banner(this._gameContext, this._maskRenderer);
			this._userInterface = new UserInterface(this._gameContext, this, this._maskRenderer);
			this.RestartEvents();
			for (;;)
			{
				if (this._fadingOut)
				{
					if (this._fadeOutOpacity <= 0f)
					{
						break;
					}
					this._fadeOutOpacity -= 0.016666668f;
					this._musicInstance.Volume = (double)this._fadeOutOpacity;
				}
				if (this._ticks == 268)
				{
					this._musicInstance = new SampleInstance(this._gameContext, this._musicSample, null);
					this._musicInstance.Play();
				}
				if (this._ticks == 458)
				{
					this.Background.Visible = true;
					this._banner.ShowStarLensFare = true;
					this._userInterface.Visible = true;
				}
				this._banner.Update();
				if (this.Background.Visible)
				{
					this.Background.Update();
				}
				this._userInterface.Update();
				if (this._ticks >= 662)
				{
					if (this._shootingStarAnimationInstance == null)
					{
						this._shootingStarAnimationInstance = new AnimationInstance(this._animationGroup, 9);
						this._shootingStarAnimationInstance.AdditiveBlending = true;
						this._shootingStarPosition = new Vector2(1440.0, 0.0);
						this._gameContext.Audio.PlaySound(this._shootingStarSample);
					}
					this._shootingStarAnimationInstance.Animate();
					this._shootingStarPosition += new Vector2(-16.0, 8.0);
				}
				this.UpdateSparkle();
				this._ticks++;
				yield return UpdateResult.Next();
			}
			this._gameContext.Audio.StopAll();
			yield break;
			yield break;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x000165BC File Offset: 0x000147BC
		private void RestartEvents()
		{
			this._ticks = 0;
			this._sparkleAnimationInstance = null;
			this._fadeOutOpacity = 1f;
			this._fadingOut = false;
			this.Background.Reset();
			this._banner.Reset();
			this._userInterface.Reset();
			this._gameContext.Audio.StopAll();
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0001661A File Offset: 0x0001481A
		public void FadeOut()
		{
			this._fadingOut = true;
			this._banner.DoShine(210);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00016633 File Offset: 0x00014833
		private void CreateSparkle(Vector2i position)
		{
			this._sparkleAnimationInstance = new AnimationInstance(this._animationGroup, 8);
			this._sparkleAnimationInstance.AdditiveBlending = true;
			this._sparklePosition = position;
			this._gameContext.Audio.PlaySound(this._sparkleSample);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00016670 File Offset: 0x00014870
		private void UpdateSparkle()
		{
			foreach (Tuple<int, Vector2i> tuple in this.SparkleTable)
			{
				if (tuple.Item1 == this._ticks)
				{
					this.CreateSparkle(this._banner.Position + tuple.Item2);
				}
			}
			if (this._sparkleAnimationInstance != null)
			{
				this._sparkleAnimationInstance.Animate();
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000166F4 File Offset: 0x000148F4
		public void Draw()
		{
			if (!this._loaded)
			{
				return;
			}
			Renderer renderer = this._gameContext.Renderer;
			this.DrawIntroText(renderer);
			this.Background.Draw(renderer);
			this.DrawShootingStar(renderer);
			this._banner.Draw(renderer);
			this.DrawSparkle(renderer);
			this._userInterface.Draw(renderer);
			if (this.Background.Visible)
			{
				this.DrawVersion(renderer);
			}
			if (this._fadeOutOpacity != 1f)
			{
				renderer.DeativateRenderer();
				IFadeTransitionRenderer fadeTransition = SharedRenderers.FadeTransition;
				fadeTransition.Opacity = this._fadeOutOpacity - 1f;
				fadeTransition.Render();
			}
			this._banner.DrawUnfaded(renderer);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x000167A0 File Offset: 0x000149A0
		private void DrawIntroText(Renderer renderer)
		{
			double valueAt = TitleGameState.IntroTextOpacity.GetValueAt(this._ticks);
			if (valueAt > 0.0)
			{
				IReadOnlyList<string> readOnlyList = new string[]
				{
					"SONIC",
					"AND",
					"MILES \"TAILS\" PROWER",
					"IN"
				};
				int num = 540 - readOnlyList.Count * 128 / 2;
				Colour colour = new Colour(valueAt, 1.0, 1.0, 1.0);
				IFontRenderer fontRenderer = renderer.GetFontRenderer();
				foreach (string text in readOnlyList)
				{
					fontRenderer.RenderStringWithShadow(text, new Rectangle(0.0, (double)num, 1920.0, 0.0), FontAlignment.Centre, this._font, colour, new int?(0));
					num += 128;
				}
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x000168B0 File Offset: 0x00014AB0
		private void DrawSparkle(Renderer renderer)
		{
			I2dRenderer renderer2 = renderer.Get2dRenderer();
			if (this._sparkleAnimationInstance != null && this._sparkleAnimationInstance.Cycles == 0)
			{
				this._sparkleAnimationInstance.Draw(renderer2, this._sparklePosition, false, false);
			}
		}

		// Token: 0x06000313 RID: 787 RVA: 0x000168F4 File Offset: 0x00014AF4
		private void DrawShootingStar(Renderer renderer)
		{
			I2dRenderer renderer2 = renderer.Get2dRenderer();
			if (this._shootingStarAnimationInstance != null)
			{
				this._shootingStarAnimationInstance.Draw(renderer2, this._shootingStarPosition, false, false);
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00016924 File Offset: 0x00014B24
		private void DrawVersion(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			double a = (double)(this._fadeOutOpacity / 2f);
			Colour colour = new Colour(a, 1.0, 1.0, 1.0);
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix *= Matrix4.CreateTranslation(8.0, 1072.0, 0.0);
				i2dRenderer.ModelMatrix *= Matrix4.CreateScale(0.5, 0.5, 1.0);
				Rectangle boundary = new Rectangle(0.0, 0.0, 0.0, 0.0);
				fontRenderer.RenderStringWithShadow(this._versionText.ToUpper(), boundary, FontAlignment.Bottom, this._font, colour, new int?(0));
			}
		}

		// Token: 0x040003C4 RID: 964
		private static readonly EaseTimeline IntroTextOpacity = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(32, 0.0),
			new EaseTimeline.Entry(64, 1.0),
			new EaseTimeline.Entry(144, 1.0),
			new EaseTimeline.Entry(176, 0.0)
		});

		// Token: 0x040003C5 RID: 965
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x040003C6 RID: 966
		private ResourceSession _resourceSession;

		// Token: 0x040003C7 RID: 967
		private Font _font;

		// Token: 0x040003C8 RID: 968
		private AnimationGroup _animationGroup;

		// Token: 0x040003C9 RID: 969
		private Sample _sparkleSample;

		// Token: 0x040003CA RID: 970
		private Sample _shootingStarSample;

		// Token: 0x040003CB RID: 971
		private Sample _musicSample;

		// Token: 0x040003CC RID: 972
		private SampleInstance _musicInstance;

		// Token: 0x040003CD RID: 973
		private IReadOnlyCollection<Tuple<int, Vector2i>> SparkleTable = new Tuple<int, Vector2i>[]
		{
			new Tuple<int, Vector2i>(204, new Vector2i(-126, -320)),
			new Tuple<int, Vector2i>(220, new Vector2i(-280, 366)),
			new Tuple<int, Vector2i>(236, new Vector2i(324, -4)),
			new Tuple<int, Vector2i>(252, new Vector2i(80, 168))
		};

		// Token: 0x040003CE RID: 974
		private const int BannerStartTime = 332;

		// Token: 0x040003CF RID: 975
		private int _ticks;

		// Token: 0x040003D0 RID: 976
		private Vector2i _sparklePosition;

		// Token: 0x040003D1 RID: 977
		private AnimationInstance _sparkleAnimationInstance;

		// Token: 0x040003D2 RID: 978
		private float _fadeOutOpacity;

		// Token: 0x040003D3 RID: 979
		private bool _fadingOut;

		// Token: 0x040003D4 RID: 980
		private AnimationInstance _shootingStarAnimationInstance;

		// Token: 0x040003D5 RID: 981
		private Vector2 _shootingStarPosition;

		// Token: 0x040003D6 RID: 982
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x040003D7 RID: 983
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x040003D8 RID: 984
		private IMaskRenderer _maskRenderer;

		// Token: 0x040003D9 RID: 985
		private bool _loaded;

		// Token: 0x040003DA RID: 986
		private Task _loadingTask;

		// Token: 0x040003DB RID: 987
		private CancellationTokenSource _loadingCTS;

		// Token: 0x040003DC RID: 988
		private Banner _banner;

		// Token: 0x040003DD RID: 989
		private UserInterface _userInterface;

		// Token: 0x040003DE RID: 990
		private string _versionText;

		// Token: 0x02000102 RID: 258
		public enum ResultType
		{
			// Token: 0x04000693 RID: 1683
			NewGame,
			// Token: 0x04000694 RID: 1684
			LevelSelect,
			// Token: 0x04000695 RID: 1685
			ShowOptions,
			// Token: 0x04000696 RID: 1686
			ShowAchievements,
			// Token: 0x04000697 RID: 1687
			StartDemo,
			// Token: 0x04000698 RID: 1688
			Quit
		}
	}
}
