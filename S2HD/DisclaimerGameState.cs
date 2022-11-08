using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace S2HD
{
	// Token: 0x0200009B RID: 155
	internal class DisclaimerGameState : IGameState, IDisposable
	{
		// Token: 0x0600036E RID: 878 RVA: 0x00019027 File Offset: 0x00017227
		public DisclaimerGameState(S2HDSonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00019038 File Offset: 0x00017238
		public async Task LoadAsync()
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependenciesByAttribute(this);
			await this._resourceSession.LoadAsync(default(CancellationToken), false);
			resourceTree.FullfillLoadedResourcesByAttribute(this);
			this._loaded = true;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0001907D File Offset: 0x0001727D
		public void Dispose()
		{
			ResourceSession resourceSession = this._resourceSession;
			if (resourceSession == null)
			{
				return;
			}
			resourceSession.Dispose();
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0001908F File Offset: 0x0001728F
		public IEnumerable<UpdateResult> Update()
		{
			Task loadTask = this.LoadAsync();
			while (!loadTask.IsCompleted)
			{
				yield return UpdateResult.Next();
			}
			yield return UpdateResult.Wait(60);
			this._opacity = 0f;
			while (this._opacity < 1f)
			{
				this._opacity += 0.016666668f;
				this._opacity = Math.Min(this._opacity, 1f);
				yield return UpdateResult.Next();
			}
			int time = 240;
			while (time > 0)
			{
				int num = time;
				time = num - 1;
				yield return UpdateResult.Next();
			}
			while (this._opacity > 0f)
			{
				this._opacity -= 0.016666668f;
				this._opacity = Math.Max(this._opacity, 0f);
				yield return UpdateResult.Next();
			}
			yield break;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x000190A0 File Offset: 0x000172A0
		public void Draw()
		{
			if (this._loaded)
			{
				I2dRenderer i2dRenderer = this._gameContext.Renderer.Get2dRenderer();
				Rectanglei rectanglei = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
				i2dRenderer.BlendMode = BlendMode.Opaque;
				i2dRenderer.Colour = Colours.White;
				i2dRenderer.RenderTexture(this._disclaimerTexture, rectanglei.Centre, false, false);
				Colour colour = new Colour((double)(1f - this._opacity), 0.0, 0.0, 0.0);
				i2dRenderer.BlendMode = BlendMode.Alpha;
				i2dRenderer.RenderQuad(colour, new Rectangle(0.0, 0.0, 1920.0, 1080.0));
			}
		}

		// Token: 0x04000421 RID: 1057
		private const int FadeTime = 60;

		// Token: 0x04000422 RID: 1058
		private const int ShowTime = 240;

		// Token: 0x04000423 RID: 1059
		[ResourcePath("SONICORCA/DISCLAIMER")]
		private ITexture _disclaimerTexture;

		// Token: 0x04000424 RID: 1060
		private S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x04000425 RID: 1061
		private ResourceSession _resourceSession;

		// Token: 0x04000426 RID: 1062
		private bool _loaded;

		// Token: 0x04000427 RID: 1063
		private float _opacity;
	}
}
