using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca;
using SonicOrca.Audio;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace S2HD.Menu
{
	// Token: 0x020000C1 RID: 193
	internal class OptionsGameState : IGameState, IDisposable
	{
		// Token: 0x06000493 RID: 1171 RVA: 0x0001E4C8 File Offset: 0x0001C6C8
		public OptionsGameState(S2HDSonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._graphicsContext = this._gameContext.Window.GraphicsContext;
			this._viewPresenterFactory = new MenuViewPresenterFactory(this._gameContext, this._settingUIResources);
			IMenuViewModel optionsView = new MenuViewFactory(this._gameContext).GetOptionsView();
			this._viewPresenterHost = new MenuViewPresenterHost(this._viewPresenterFactory, optionsView, this._settingUIResources);
			this._viewPresenterHost.NavigateNext += this.NavigateNextHandler;
			this._viewPresenterHost.NavigateBack += this.NavigateBackHandler;
			this._buttonBarUI = new ButtonBarUI(this._settingUIResources);
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0001E582 File Offset: 0x0001C782
		public void Dispose()
		{
			SampleInstance musicSampleInstance = this._musicSampleInstance;
			if (musicSampleInstance != null)
			{
				musicSampleInstance.Dispose();
			}
			ResourceSession resourceSession = this._resourceSession;
			if (resourceSession == null)
			{
				return;
			}
			resourceSession.Dispose();
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0001E5A8 File Offset: 0x0001C7A8
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependenciesByAttribute(this);
			this._settingUIResources.PushDependencies(this._resourceSession);
			await this._resourceSession.LoadAsync(ct, false);
			resourceTree.FullfillLoadedResourcesByAttribute(this);
			this._settingUIResources.FetchResources(resourceTree);
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0001E5F8 File Offset: 0x0001C7F8
		private void Initialise()
		{
			this._backgroundTexture.Wrapping = TextureWrapping.Repeat;
			this._bounds = new Rectanglei(0, 0, 1920, 1080);
			this._fadeOutOpacity = 0f;
			this._viewPresenterHost.Bounds = this._bounds.Inflate(new Vector2i(-512, -386));
			this._buttonBarUI.Bounds = new Rectanglei(0, this._bounds.Height - 100, this._bounds.Width, 64);
			this._buttonBarUI.Items = new ButtonBarItem[]
			{
				new ButtonBarItem
				{
					Button = GamePadButton.A,
					Text = "APPLY"
				},
				new ButtonBarItem
				{
					Button = GamePadButton.B,
					Text = "CANCEL"
				}
			}.ToImmutableArray<ButtonBarItem>();
			this._initialised = true;
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0001E6E9 File Offset: 0x0001C8E9
		public IEnumerable<UpdateResult> Update()
		{
			Task loadTask = this.LoadAsync(default(CancellationToken));
			while (!loadTask.IsCompleted)
			{
				yield return UpdateResult.Next();
			}
			if (loadTask.IsFaulted)
			{
				yield break;
			}
			this.Initialise();
			this._musicSampleInstance = new SampleInstance(this._gameContext.Audio, this._musicSampleInfo);
			this._musicSampleInstance.Classification = SampleInstanceClassification.Music;
			this._musicSampleInstance.Play();
			while (this._fadeOutOpacity < 1f)
			{
				this._fadeOutOpacity += 0.016666668f;
				this._fadeOutOpacity = Math.Min(this._fadeOutOpacity, 1f);
				this._viewPresenterHost.Update();
				yield return UpdateResult.Next();
			}
			while (!this._finished)
			{
				this._viewPresenterHost.Update();
				this._viewPresenterHost.HandleInput();
				yield return UpdateResult.Next();
			}
			while (this._fadeOutOpacity > 0f)
			{
				this._musicSampleInstance.Volume -= 0.01666666753590107;
				this._fadeOutOpacity -= 0.016666668f;
				this._fadeOutOpacity = Math.Min(this._fadeOutOpacity, 1f);
				this._viewPresenterHost.Update();
				yield return UpdateResult.Next();
			}
			this._musicSampleInstance.Stop();
			yield break;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001E6F9 File Offset: 0x0001C8F9
		private void NavigateNextHandler(object sender, NavigateNextEventArgs e)
		{
			if (e.Tag is int && (int)e.Tag == 4)
			{
				this._gameContext.Settings.Apply();
			}
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0001E726 File Offset: 0x0001C926
		private void NavigateBackHandler(object sender, EventArgs e)
		{
			this._finished = true;
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001E730 File Offset: 0x0001C930
		public void Draw()
		{
			if (!this._initialised)
			{
				return;
			}
			Renderer renderer = this._gameContext.Renderer;
			this.DrawBackground(renderer);
			this.DrawViewPresenterHost(renderer);
			this.DrawButtonBar(renderer);
			this.DrawFadeOut(renderer);
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0001E76E File Offset: 0x0001C96E
		private void DrawButtonBar(Renderer renderer)
		{
			this._buttonBarUI.Draw(renderer);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0001E77C File Offset: 0x0001C97C
		private void DrawBackground(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.BlendMode = BlendMode.Opaque;
			i2dRenderer.Colour = Colours.White;
			i2dRenderer.ModelMatrix = Matrix4.Identity;
			i2dRenderer.RenderTexture(this._backgroundTexture, this._bounds, this._bounds, false, false);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0001E7CF File Offset: 0x0001C9CF
		private void DrawViewPresenterHost(Renderer renderer)
		{
			this._viewPresenterHost.Draw(renderer);
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0001E7DD File Offset: 0x0001C9DD
		private void DrawFadeOut(Renderer renderer)
		{
			renderer.DeativateRenderer();
			IFadeTransitionRenderer fadeTransition = SharedRenderers.FadeTransition;
			fadeTransition.Opacity = this._fadeOutOpacity - 1f;
			fadeTransition.Render();
		}

		// Token: 0x0400052C RID: 1324
		[ResourcePath("SONICORCA/MUSIC/OPTIONS")]
		private SampleInfo _musicSampleInfo;

		// Token: 0x0400052D RID: 1325
		[ResourcePath("SONICORCA/MENU/OPTIONS/MENU3")]
		private ITexture _backgroundTexture;

		// Token: 0x0400052E RID: 1326
		private const int FadeTime = 60;

		// Token: 0x0400052F RID: 1327
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x04000530 RID: 1328
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000531 RID: 1329
		private readonly SettingUIResources _settingUIResources = new SettingUIResources();

		// Token: 0x04000532 RID: 1330
		private readonly MenuViewPresenterFactory _viewPresenterFactory;

		// Token: 0x04000533 RID: 1331
		private readonly MenuViewPresenterHost _viewPresenterHost;

		// Token: 0x04000534 RID: 1332
		private readonly ButtonBarUI _buttonBarUI;

		// Token: 0x04000535 RID: 1333
		private ResourceSession _resourceSession;

		// Token: 0x04000536 RID: 1334
		private bool _initialised;

		// Token: 0x04000537 RID: 1335
		private bool _finished;

		// Token: 0x04000538 RID: 1336
		private SampleInstance _musicSampleInstance;

		// Token: 0x04000539 RID: 1337
		private Rectanglei _bounds;

		// Token: 0x0400053A RID: 1338
		private float _fadeOutOpacity;
	}
}
