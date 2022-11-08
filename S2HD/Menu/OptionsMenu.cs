using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca;
using SonicOrca.Drawing.Renderers;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.V2.Animation;
using SonicOrca.Resources;

namespace S2HD.Menu
{
	// Token: 0x020000C2 RID: 194
	internal class OptionsMenu : IDisposable
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0001E801 File Offset: 0x0001CA01
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0001E809 File Offset: 0x0001CA09
		public bool CanRestart { get; set; }

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060004A1 RID: 1185 RVA: 0x0001E814 File Offset: 0x0001CA14
		// (remove) Token: 0x060004A2 RID: 1186 RVA: 0x0001E84C File Offset: 0x0001CA4C
		public event EventHandler OnResume;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060004A3 RID: 1187 RVA: 0x0001E884 File Offset: 0x0001CA84
		// (remove) Token: 0x060004A4 RID: 1188 RVA: 0x0001E8BC File Offset: 0x0001CABC
		public event EventHandler OnRestart;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060004A5 RID: 1189 RVA: 0x0001E8F4 File Offset: 0x0001CAF4
		// (remove) Token: 0x060004A6 RID: 1190 RVA: 0x0001E92C File Offset: 0x0001CB2C
		public event EventHandler OnQuit;

		// Token: 0x060004A7 RID: 1191 RVA: 0x0001E964 File Offset: 0x0001CB64
		public OptionsMenu(S2HDSonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._graphicsContext = gameContext.Window.GraphicsContext;
			this._settingUIResources = new SettingUIResources();
			this._viewPresenterFactory = new MenuViewPresenterFactory(this._gameContext, this._settingUIResources);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0001E9BC File Offset: 0x0001CBBC
		public void Dispose()
		{
			ResourceSession resourceSession = this._resourceSession;
			if (resourceSession == null)
			{
				return;
			}
			resourceSession.Dispose();
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0001E9D0 File Offset: 0x0001CBD0
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependenciesByAttribute(this);
			this._settingUIResources.PushDependencies(this._resourceSession);
			await this._resourceSession.LoadAsync(ct, false);
			resourceTree.FullfillLoadedResourcesByAttribute(this);
			this._settingUIResources.FetchResources(resourceTree);
			this._loaded = true;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0001EA20 File Offset: 0x0001CC20
		private void Initialise()
		{
			this._menuPopInComposition = new CompositionInstance(this._menuPopInCompositionGroup);
			this._menuPopOutComposition = new CompositionInstance(this._menuPopOutCompositionGroup);
			this._subMenuAudioPopInComposition = new CompositionInstance(this._subMenuAudioPopInCompositionGroup);
			this._subMenuAudioPopOutComposition = new CompositionInstance(this._subMenuAudioPopOutCompositionGroup);
			this._subMenuVideoPopInComposition = new CompositionInstance(this._subMenuVideoPopInCompositionGroup);
			this._subMenuVideoPopOutComposition = new CompositionInstance(this._subMenuVideoPopOutCompositionGroup);
			this._subMenuOptionsPopInComposition = new CompositionInstance(this._subMenuOptionsPopInCompositionGroup);
			this._currentComposition = this._menuPopInComposition;
			this._compositions.Add(this._menuPopInComposition);
			this._compositions.Add(this._menuPopOutComposition);
			this._compositions.Add(this._subMenuAudioPopInComposition);
			this._compositions.Add(this._subMenuAudioPopOutComposition);
			this._compositions.Add(this._subMenuVideoPopInComposition);
			this._compositions.Add(this._subMenuVideoPopOutComposition);
			this._compositions.Add(this._subMenuOptionsPopInComposition);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0001EB28 File Offset: 0x0001CD28
		public void Update()
		{
			if (!this._loaded)
			{
				return;
			}
			if (!this._initialised)
			{
				this._initialised = true;
				this.Initialise();
			}
			if (!this._showing)
			{
				return;
			}
			if (this._currentComposition != null)
			{
				this._currentComposition.Animate();
				if (this._currentComposition.Finished && this._currentComposition != this._menuPopOutComposition)
				{
					this._circleSize = (float)this._circleTexture.Width;
					int num = (int)this._circleSize;
					this._circleBounds = new Rectanglei(0, 0, num, num);
					if (this._currentComposition == this._subMenuVideoPopInComposition)
					{
						this._circleBounds.X = (1920 - num) / 2;
						this._circleBounds.Y = 337;
					}
					else if (this._currentComposition == this._subMenuAudioPopInComposition)
					{
						this._circleBounds.X = (1920 - num) / 2;
						this._circleBounds.Y = 400;
					}
					else
					{
						this._circleBounds.X = (1920 - num) / 2;
						this._circleBounds.Y = (1080 - num) / 2;
					}
					Rectanglei bounds = Rectanglei.FromLTRB(this._circleBounds.Left, this._circleBounds.Top + 60, this._circleBounds.Right, this._circleBounds.Bottom);
					this._viewPresenterHost.Bounds = bounds;
					this._viewPresenterHost.Update();
					this._viewPresenterHost.HandleInput();
				}
			}
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0001ECA4 File Offset: 0x0001CEA4
		private void NavigateNextHandler(object sender, NavigateNextEventArgs e)
		{
			if (e.Tag is int)
			{
				switch ((int)e.Tag)
				{
				case 1:
				{
					EventHandler onQuit = this.OnQuit;
					if (onQuit == null)
					{
						return;
					}
					onQuit(this, EventArgs.Empty);
					return;
				}
				case 2:
				{
					EventHandler onRestart = this.OnRestart;
					if (onRestart == null)
					{
						return;
					}
					onRestart(this, EventArgs.Empty);
					return;
				}
				case 3:
				{
					EventHandler onResume = this.OnResume;
					if (onResume == null)
					{
						return;
					}
					onResume(this, EventArgs.Empty);
					return;
				}
				case 4:
					this._gameContext.Settings.Apply();
					return;
				case 5:
					this.ResetCompositions();
					this._currentComposition = this._subMenuOptionsPopInComposition;
					return;
				case 6:
					this.ResetCompositions();
					this._currentComposition = this._subMenuAudioPopInComposition;
					return;
				case 7:
					this.ResetCompositions();
					this._currentComposition = this._subMenuVideoPopInComposition;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0001ED80 File Offset: 0x0001CF80
		private void NavigateBackHandler(object sender, EventArgs e)
		{
			if (this._currentComposition != this._menuPopInComposition && this._currentComposition != this._subMenuOptionsPopInComposition)
			{
				this.ResetCompositions();
				this._currentComposition = this._subMenuOptionsPopInComposition;
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0001EDB0 File Offset: 0x0001CFB0
		private void ResetCompositions()
		{
			foreach (CompositionInstance compositionInstance in this._compositions)
			{
				compositionInstance.ResetFrame();
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0001EE00 File Offset: 0x0001D000
		public void Draw(Renderer renderer)
		{
			if (!this._loaded || !this._showing)
			{
				return;
			}
			I2dRenderer g = renderer.Get2dRenderer();
			this.BlurGame(renderer, g);
			if (this._currentComposition != null)
			{
				this._currentComposition.Draw(renderer, default(Vector2), false, false);
				if (this._currentComposition.Finished)
				{
					this.DrawViewPresenterHost(renderer);
				}
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0001EE60 File Offset: 0x0001D060
		private void BlurGame(Renderer renderer, I2dRenderer g)
		{
			Rectanglei rectanglei = new Rectanglei(0, 0, 1920, 1080);
			renderer.DeativateRenderer();
			IFramebuffer currentFramebuffer = this._graphicsContext.CurrentFramebuffer;
			GaussianBlurRenderer gaussianBlurRenderer = GaussianBlurRenderer.FromRenderer(renderer);
			gaussianBlurRenderer.Softness = 4.0;
			gaussianBlurRenderer.Render(currentFramebuffer.Textures[0], rectanglei, false, false);
			g.BlendMode = BlendMode.Alpha;
			g.RenderQuad(new Colour(0.5, 0.0, 0.0, 0.0), rectanglei);
			renderer.DeativateRenderer();
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0001EEFD File Offset: 0x0001D0FD
		private void DrawViewPresenterHost(Renderer renderer)
		{
			this._viewPresenterHost.Draw(renderer);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0001EF0C File Offset: 0x0001D10C
		public void Show()
		{
			this.ResetCompositions();
			this._currentComposition = this._menuPopInComposition;
			this._showing = true;
			IListMenuViewModel inGameOptionsView = new MenuViewFactory(this._gameContext).GetInGameOptionsView(this.CanRestart);
			this._viewPresenterHost = new MenuViewPresenterHost(this._viewPresenterFactory, inGameOptionsView, this._settingUIResources);
			this._viewPresenterHost.NavigateNext += this.NavigateNextHandler;
			this._viewPresenterHost.NavigateBack += this.NavigateBackHandler;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001EF8F File Offset: 0x0001D18F
		public void Hide()
		{
			this._showing = false;
			this._viewPresenterHost = null;
		}

		// Token: 0x0400053B RID: 1339
		[ResourcePath("SONICORCA/MENU/OPTIONS/CIRCLE")]
		private ITexture _circleTexture;

		// Token: 0x0400053C RID: 1340
		[ResourcePath("SONICORCA/MENU/OPTIONS/V2/PAUSE")]
		private CompositionGroup _menuPopInCompositionGroup;

		// Token: 0x0400053D RID: 1341
		[ResourcePath("SONICORCA/MENU/OPTIONS/V2/EXITPAUSE")]
		private CompositionGroup _menuPopOutCompositionGroup;

		// Token: 0x0400053E RID: 1342
		[ResourcePath("SONICORCA/MENU/OPTIONS/V2/AUDIO")]
		private CompositionGroup _subMenuAudioPopInCompositionGroup;

		// Token: 0x0400053F RID: 1343
		[ResourcePath("SONICORCA/MENU/OPTIONS/V2/EXITAUDIO")]
		private CompositionGroup _subMenuAudioPopOutCompositionGroup;

		// Token: 0x04000540 RID: 1344
		[ResourcePath("SONICORCA/MENU/OPTIONS/V2/VIDEO")]
		private CompositionGroup _subMenuVideoPopInCompositionGroup;

		// Token: 0x04000541 RID: 1345
		[ResourcePath("SONICORCA/MENU/OPTIONS/V2/EXITVIDEO")]
		private CompositionGroup _subMenuVideoPopOutCompositionGroup;

		// Token: 0x04000542 RID: 1346
		[ResourcePath("SONICORCA/MENU/OPTIONS/V2/OPTIONS")]
		private CompositionGroup _subMenuOptionsPopInCompositionGroup;

		// Token: 0x04000543 RID: 1347
		private CompositionInstance _menuPopInComposition;

		// Token: 0x04000544 RID: 1348
		private CompositionInstance _menuPopOutComposition;

		// Token: 0x04000545 RID: 1349
		private CompositionInstance _subMenuAudioPopInComposition;

		// Token: 0x04000546 RID: 1350
		private CompositionInstance _subMenuAudioPopOutComposition;

		// Token: 0x04000547 RID: 1351
		private CompositionInstance _subMenuVideoPopInComposition;

		// Token: 0x04000548 RID: 1352
		private CompositionInstance _subMenuVideoPopOutComposition;

		// Token: 0x04000549 RID: 1353
		private CompositionInstance _subMenuOptionsPopInComposition;

		// Token: 0x0400054A RID: 1354
		private CompositionInstance _currentComposition;

		// Token: 0x0400054B RID: 1355
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x0400054C RID: 1356
		private readonly SettingUIResources _settingUIResources;

		// Token: 0x0400054D RID: 1357
		private ResourceSession _resourceSession;

		// Token: 0x0400054E RID: 1358
		private bool _loaded;

		// Token: 0x0400054F RID: 1359
		private bool _initialised;

		// Token: 0x04000550 RID: 1360
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000551 RID: 1361
		private float _circleSize;

		// Token: 0x04000552 RID: 1362
		private Rectanglei _circleBounds;

		// Token: 0x04000553 RID: 1363
		private bool _showing;

		// Token: 0x04000554 RID: 1364
		private readonly MenuViewPresenterFactory _viewPresenterFactory;

		// Token: 0x04000555 RID: 1365
		private MenuViewPresenterHost _viewPresenterHost;

		// Token: 0x0400055A RID: 1370
		private List<CompositionInstance> _compositions = new List<CompositionInstance>();
	}
}
