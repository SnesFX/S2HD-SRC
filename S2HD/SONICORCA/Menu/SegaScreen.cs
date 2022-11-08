using System;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Audio;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Menu
{
	// Token: 0x02000095 RID: 149
	internal class SegaScreen : Screen
	{
		// Token: 0x06000330 RID: 816 RVA: 0x00017820 File Offset: 0x00015A20
		public SegaScreen(SonicOrcaGameContext context)
		{
			this._context = context;
			this._fadeTransition.Set();
			this._stateMachine = this.CreateFSM();
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00017854 File Offset: 0x00015A54
		public override async Task LoadAsync(ScreenLoadingProgress progress, CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._context.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependencies(new string[]
			{
				"SONICORCA/MENU/SEGA/SCREENLOGO",
				"SONICORCA/MENU/SEGA/SOUND"
			});
			await this._resourceSession.LoadAsync(ct, false);
			this._logoTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/MENU/SEGA/SCREENLOGO");
			this._segaSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/MENU/SEGA/SOUND");
		}

		// Token: 0x06000332 RID: 818 RVA: 0x000178A1 File Offset: 0x00015AA1
		public override void Unload()
		{
			if (this._segaSampleInstance != null)
			{
				this._segaSampleInstance.Dispose();
			}
			if (this._resourceSession != null)
			{
				this._resourceSession.Unload();
			}
		}

		// Token: 0x06000333 RID: 819 RVA: 0x000178CC File Offset: 0x00015ACC
		private FiniteStateMachine CreateFSM()
		{
			int cancelWait = 0;
			FiniteStateMachine finiteStateMachine = new FiniteStateMachine();
			Action <>9__8;
			finiteStateMachine.Begin().Do(delegate
			{
				cancelWait = 120;
			}).While(delegate()
			{
				int cancelWait = cancelWait;
				cancelWait--;
				return cancelWait >= 0 && !this._cancelled;
			}).Do(delegate
			{
				if (this._cancelled)
				{
					finiteStateMachine.Finish();
					return;
				}
				this._fadeTransition.BeginFadeIn();
			}).While(() => !this._fadeTransition.Finished, delegate()
			{
				if (this._cancelled)
				{
					this._fadeTransition.BeginFadeOut();
					FiniteStateMachine.IState state = finiteStateMachine.Begin().Do(delegate
					{
						this._fadeTransition.BeginFadeOut();
					}).While(() => !this._fadeTransition.Finished, delegate()
					{
						this._fadeTransition.Update();
					});
					Action action;
					if ((action = <>9__8) == null)
					{
						action = (<>9__8 = delegate()
						{
							finiteStateMachine.Finish();
						});
					}
					state.Do(action);
					return;
				}
				this._fadeTransition.Update();
			}).Do(delegate
			{
				this._segaSampleInstance = new SampleInstance(this._context, this._segaSample, null);
				this._segaSampleInstance.Play();
			}).While(() => this._segaSampleInstance.Playing).Do(delegate
			{
				cancelWait = 60;
			}).While(delegate()
			{
				int cancelWait = cancelWait;
				cancelWait--;
				return cancelWait >= 0 && !this._cancelled;
			}).Do(delegate
			{
				this._fadeTransition.BeginFadeOut();
			}).While(() => !this._fadeTransition.Finished, delegate()
			{
				this._fadeTransition.Update();
			});
			return finiteStateMachine;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000179CC File Offset: 0x00015BCC
		public override void Update()
		{
			if (this._context.Pressed[0].Start)
			{
				this._cancelled = true;
			}
			if (!this._stateMachine.Update())
			{
				base.Finish();
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00017A00 File Offset: 0x00015C00
		public override void Draw(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderQuad(Colours.White, new Rectangle(0.0, 0.0, 1920.0, 1080.0));
			i2dRenderer.RenderTexture(this._logoTexture, new Vector2(960.0, 540.0), false, false);
			this._fadeTransition.Draw(renderer);
		}

		// Token: 0x040003EB RID: 1003
		private const string LogoResourceKey = "SONICORCA/MENU/SEGA/SCREENLOGO";

		// Token: 0x040003EC RID: 1004
		private const string SoundResourceKey = "SONICORCA/MENU/SEGA/SOUND";

		// Token: 0x040003ED RID: 1005
		private readonly SonicOrcaGameContext _context;

		// Token: 0x040003EE RID: 1006
		private readonly FadeTransition _fadeTransition = new FadeTransition(30);

		// Token: 0x040003EF RID: 1007
		private ResourceSession _resourceSession;

		// Token: 0x040003F0 RID: 1008
		private ITexture _logoTexture;

		// Token: 0x040003F1 RID: 1009
		private Sample _segaSample;

		// Token: 0x040003F2 RID: 1010
		private SampleInstance _segaSampleInstance;

		// Token: 0x040003F3 RID: 1011
		private readonly FiniteStateMachine _stateMachine;

		// Token: 0x040003F4 RID: 1012
		private bool _cancelled;
	}
}
