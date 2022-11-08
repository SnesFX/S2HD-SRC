using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Menu;
using SonicOrca.Resources;

namespace S2HD
{
	// Token: 0x0200009E RID: 158
	internal class LogosGameState : IGameState, IDisposable
	{
		// Token: 0x0600037C RID: 892 RVA: 0x000193BE File Offset: 0x000175BE
		public LogosGameState(SonicOrcaGameContext context)
		{
			this._gameContext = context;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x000193DC File Offset: 0x000175DC
		private void LoadResources()
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependenciesByAttribute(this);
			this._loadingCTS = new CancellationTokenSource();
			this._loadingTask = this._resourceSession.LoadAsync(this._loadingCTS.Token, false);
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00019438 File Offset: 0x00017638
		public void Dispose()
		{
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

		// Token: 0x0600037F RID: 895 RVA: 0x0001948A File Offset: 0x0001768A
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
			this._smallSonic = true;
			this._sonicX = -256;
			this._sonicVX = 100;
			yield return UpdateResult.Wait(8);
			while (this._sonicX < 2176)
			{
				this._sonicX += this._sonicVX;
				this._sonicFrame = (this._sonicFrame + 1) % 8;
				yield return UpdateResult.Next();
			}
			this._smallSonic = false;
			this._sonicX = 2944;
			this._sonicVX = -266;
			yield return UpdateResult.Wait(8);
			while (this._sonicX > -1024)
			{
				this._sonicX += this._sonicVX;
				this._sonicFrame = (this._sonicFrame + 1) % 8;
				yield return UpdateResult.Next();
			}
			this._sonicX = -1024;
			this._sonicVX = 200;
			yield return UpdateResult.Wait(16);
			while (this._sonicX < 2944)
			{
				this._sonicX += this._sonicVX;
				this._sonicFrame = (this._sonicFrame + 1) % 8;
				yield return UpdateResult.Next();
			}
			yield return UpdateResult.Wait(90);
			this._fadeTransition.BeginFadeOut();
			while (!this._fadeTransition.Finished)
			{
				this._fadeTransition.Update();
				yield return UpdateResult.Next();
			}
			yield break;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0001949C File Offset: 0x0001769C
		public void Draw()
		{
			if (!this._loaded)
			{
				return;
			}
			I2dRenderer g = SharedRenderers.Standard2d;
			Renderer renderer = this._gameContext.Renderer;
			g = renderer.Get2dRenderer();
			this.DrawPoweredBy(g);
			if (this._smallSonic)
			{
				this.DrawSmallSonic(g);
			}
			else
			{
				this.DrawEngineLogo(g);
				this.DrawSonic(g);
			}
			this._fadeTransition.Draw(renderer);
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00019500 File Offset: 0x00017700
		private void DrawPoweredBy(I2dRenderer g)
		{
			Rectangle clipRectangle = g.ClipRectangle;
			if (this._smallSonic)
			{
				g.ClipRectangle = new Rectangle(0.0, 0.0, (double)this._sonicX, 1080.0);
			}
			g.RenderText(new TextRenderInfo
			{
				Font = this._font,
				Text = "POWERED BY",
				Bounds = new Rectangle(0.0, 120.0, 1920.0, 120.0),
				Alignment = FontAlignment.Centre,
				Overlay = new int?(0)
			});
			if (this._smallSonic)
			{
				g.ClipRectangle = clipRectangle;
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x000195C0 File Offset: 0x000177C0
		private void DrawEngineLogo(I2dRenderer g)
		{
			Sizei sizei = new Sizei(this._engineTexture.Width, this._engineTexture.Height);
			Rectanglei r = new Rectanglei(960 - sizei.Width / 2, 540 - sizei.Height / 2, sizei.Width, sizei.Height);
			r.Left = Math.Max(r.Left, this._sonicX);
			if (r.Width > 0)
			{
				Rectanglei r2 = new Rectanglei(sizei.Width - r.Width, 0, r.Width, sizei.Height);
				g.BlendMode = BlendMode.Alpha;
				g.Colour = Colours.White;
				g.RenderTexture(this._enginePartialTexture, r2, r, false, false);
			}
			if (this._sonicVX < 0)
			{
				return;
			}
			r = new Rectanglei(960 - sizei.Width / 2, 540 - sizei.Height / 2, sizei.Width, sizei.Height);
			r.Right = Math.Min(r.Right, this._sonicX);
			if (r.Width > 0)
			{
				Rectanglei r2 = new Rectanglei(0, 0, r.Width, sizei.Height);
				g.BlendMode = BlendMode.Alpha;
				g.Colour = Colours.White;
				g.RenderTexture(this._engineTexture, r2, r, false, false);
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x00019734 File Offset: 0x00017934
		private void DrawSmallSonic(I2dRenderer g)
		{
			Rectanglei r = new Rectanglei(this._sonicFrame * 1024, 0, 1024, 1120);
			Rectanglei r2 = new Rectanglei(this._sonicX - 128, 40, 256, 280);
			if (r2.Right > 0 && r2.Left < 1920)
			{
				g.BlendMode = BlendMode.Alpha;
				g.Colour = Colours.White;
				g.RenderTexture(this._engineSonicTexture, r, r2, this._sonicVX >= 0, false);
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x000197D0 File Offset: 0x000179D0
		private void DrawSonic(I2dRenderer g)
		{
			Rectanglei r = new Rectanglei(this._sonicFrame * 1024, 0, 1024, 1120);
			Rectanglei r2 = new Rectanglei(this._sonicX - 512, -20, 1024, 1120);
			if (r2.Right > 0 && r2.Left < 1920)
			{
				g.BlendMode = BlendMode.Alpha;
				g.Colour = Colours.White;
				g.RenderTexture(this._engineSonicTexture, r, r2, this._sonicVX >= 0, false);
			}
		}

		// Token: 0x04000434 RID: 1076
		private bool _loaded;

		// Token: 0x04000435 RID: 1077
		private Task _loadingTask;

		// Token: 0x04000436 RID: 1078
		private CancellationTokenSource _loadingCTS;

		// Token: 0x04000437 RID: 1079
		private ResourceSession _resourceSession;

		// Token: 0x04000438 RID: 1080
		[ResourcePath("SONICORCA/ENGINE")]
		private ITexture _engineTexture;

		// Token: 0x04000439 RID: 1081
		[ResourcePath("SONICORCA/ENGINE/PARTIAL")]
		private ITexture _enginePartialTexture;

		// Token: 0x0400043A RID: 1082
		[ResourcePath("SONICORCA/ENGINE/SONIC")]
		private ITexture _engineSonicTexture;

		// Token: 0x0400043B RID: 1083
		[ResourcePath("SONICORCA/FONTS/HUD")]
		private Font _font;

		// Token: 0x0400043C RID: 1084
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x0400043D RID: 1085
		private readonly FadeTransition _fadeTransition = new FadeTransition(60);

		// Token: 0x0400043E RID: 1086
		private bool _smallSonic;

		// Token: 0x0400043F RID: 1087
		private int _sonicX;

		// Token: 0x04000440 RID: 1088
		private int _sonicVX;

		// Token: 0x04000441 RID: 1089
		private int _sonicFrame;

		// Token: 0x02000117 RID: 279
		private static class ResourceKeys
		{
			// Token: 0x040006F2 RID: 1778
			public const string Engine = "SONICORCA/ENGINE";

			// Token: 0x040006F3 RID: 1779
			public const string EnginePartial = "SONICORCA/ENGINE/PARTIAL";

			// Token: 0x040006F4 RID: 1780
			public const string EngineSonic = "SONICORCA/ENGINE/SONIC";

			// Token: 0x040006F5 RID: 1781
			public const string Font = "SONICORCA/FONTS/HUD";
		}
	}
}
