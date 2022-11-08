using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca;
using SonicOrca.Audio;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.V2.Video;
using SonicOrca.Input;
using SonicOrca.Resources;

namespace S2HD
{
	// Token: 0x0200009D RID: 157
	internal class CreditsGameState : IGameState, IDisposable
	{
		// Token: 0x06000377 RID: 887 RVA: 0x00019217 File Offset: 0x00017417
		public CreditsGameState(SonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._resourceSession = new ResourceSession(gameContext.ResourceTree);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00019238 File Offset: 0x00017438
		private void LoadResources()
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependenciesByAttribute(this);
			this._loadingCTS = new CancellationTokenSource();
			this._loadingTask = this._resourceSession.LoadAsync(this._loadingCTS.Token, false);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00019294 File Offset: 0x00017494
		public void Dispose()
		{
			SampleInstance musicInstance = this._musicInstance;
			if (musicInstance != null)
			{
				musicInstance.Dispose();
			}
			this._musicInstance = null;
			if (this._loadingTask != null && !this._loadingTask.IsCompleted)
			{
				this._loadingCTS.Cancel();
				this._loadingTask.Wait();
			}
			if (this._resourceSession != null)
			{
				this._resourceSession.Dispose();
				this._resourceSession = null;
			}
		}

		// Token: 0x0600037A RID: 890 RVA: 0x000192FE File Offset: 0x000174FE
		public IEnumerable<UpdateResult> Update()
		{
			this.LoadResources();
			while (!this._loadingTask.IsCompleted)
			{
				yield return UpdateResult.Next();
			}
			if (this._loadingTask.IsFaulted)
			{
				yield break;
			}
			this._gameContext.ResourceTree.FullfillLoadedResourcesByAttribute(this);
			this._loaded = true;
			this._creditsFilmInstance = new FilmInstance(this._creditsFilmGroup);
			this._musicInstance = new SampleInstance(this._gameContext, this._musicSample, new int?(458980));
			this._fadeOpacity = 0.0;
			bool playedStarSFX = false;
			bool quit = false;
			while (!this._creditsFilmInstance.Finished)
			{
				double currentTime = this._creditsFilmInstance.CurrentTime;
				if (currentTime < 42.0)
				{
					InputState pressed = this._gameContext.Input.Pressed;
					if (pressed.Keyboard[40] || pressed.GamePad[0].Start)
					{
						quit = true;
					}
				}
				if (quit)
				{
					this._musicInstance.Volume -= 0.008333333333333333;
					this._fadeOpacity += 0.008333333333333333;
					if (this._fadeOpacity >= 1.0)
					{
						break;
					}
				}
				if (!this._musicInstance.Playing && currentTime >= 2.0)
				{
					this._musicInstance.Play();
				}
				if (currentTime >= 45.0)
				{
					double volume = 1.0 - Math.Min((currentTime - 45.0) / 8.0, 1.0);
					this._musicInstance.Volume = volume;
				}
				if (!playedStarSFX && currentTime >= 52.5)
				{
					playedStarSFX = true;
					this._gameContext.Audio.PlaySound(this._shootingStarSample);
				}
				this._creditsFilmInstance.Animate();
				yield return UpdateResult.Next();
			}
			yield break;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00019310 File Offset: 0x00017510
		public void Draw()
		{
			if (!this._loaded)
			{
				return;
			}
			Renderer renderer = this._gameContext.Renderer;
			this._creditsFilmInstance.Draw(renderer, default(Vector2), false, false);
			if (this._fadeOpacity < 1.0)
			{
				I2dRenderer i2dRenderer = renderer.Get2dRenderer();
				Colour colour = new Colour(this._fadeOpacity, 0.0, 0.0, 0.0);
				i2dRenderer.BlendMode = BlendMode.Alpha;
				i2dRenderer.RenderQuad(colour, new Rectangle(0.0, 0.0, 1920.0, 1080.0));
			}
		}

		// Token: 0x04000429 RID: 1065
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x0400042A RID: 1066
		private bool _loaded;

		// Token: 0x0400042B RID: 1067
		private Task _loadingTask;

		// Token: 0x0400042C RID: 1068
		private CancellationTokenSource _loadingCTS;

		// Token: 0x0400042D RID: 1069
		private ResourceSession _resourceSession;

		// Token: 0x0400042E RID: 1070
		[ResourcePath("SONICORCA/MUSIC/CREDITS")]
		private Sample _musicSample;

		// Token: 0x0400042F RID: 1071
		[ResourcePath("SONICORCA/SOUND/SHOOTINGSTAR")]
		private Sample _shootingStarSample;

		// Token: 0x04000430 RID: 1072
		[ResourcePath("SONICORCA/CREDITS/SEQUENCE/GROUP")]
		private FilmGroup _creditsFilmGroup;

		// Token: 0x04000431 RID: 1073
		private FilmInstance _creditsFilmInstance;

		// Token: 0x04000432 RID: 1074
		private SampleInstance _musicInstance;

		// Token: 0x04000433 RID: 1075
		private double _fadeOpacity;

		// Token: 0x02000115 RID: 277
		private static class ResourceKeys
		{
			// Token: 0x040006E7 RID: 1767
			public const string RoleFont = "SONICORCA/FONTS/TITLE/S2/NAME";

			// Token: 0x040006E8 RID: 1768
			public const string NameFont = "SONICORCA/FONTS/HUD";

			// Token: 0x040006E9 RID: 1769
			public const string Logo = "SONICORCA/LOGO";

			// Token: 0x040006EA RID: 1770
			public const string Music = "SONICORCA/MUSIC/CREDITS";

			// Token: 0x040006EB RID: 1771
			public const string ShootingStarSample = "SONICORCA/SOUND/SHOOTINGSTAR";
		}
	}
}
