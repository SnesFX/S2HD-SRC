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
	// Token: 0x020000A0 RID: 160
	internal class TeamLogoGameState : IGameState, IDisposable
	{
		// Token: 0x06000395 RID: 917 RVA: 0x00019B19 File Offset: 0x00017D19
		public TeamLogoGameState(S2HDSonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00019B28 File Offset: 0x00017D28
		public async Task LoadAsync()
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependenciesByAttribute(this);
			await this._resourceSession.LoadAsync(default(CancellationToken), false);
			resourceTree.FullfillLoadedResourcesByAttribute(this);
			this._loaded = true;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00019B6D File Offset: 0x00017D6D
		public void Dispose()
		{
			ResourceSession resourceSession = this._resourceSession;
			if (resourceSession == null)
			{
				return;
			}
			resourceSession.Dispose();
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00019B7F File Offset: 0x00017D7F
		public IEnumerable<UpdateResult> Update()
		{
			Task loadTask = this.LoadAsync();
			while (!loadTask.IsCompleted)
			{
				yield return UpdateResult.Next();
			}
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

		// Token: 0x06000399 RID: 921 RVA: 0x00019B90 File Offset: 0x00017D90
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

		// Token: 0x0400044A RID: 1098
		private const int FadeTime = 60;

		// Token: 0x0400044B RID: 1099
		private const int ShowTime = 240;

		// Token: 0x0400044C RID: 1100
		[ResourcePath("SONICORCA/TEAMLOGO")]
		private ITexture _disclaimerTexture;

		// Token: 0x0400044D RID: 1101
		private S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x0400044E RID: 1102
		private ResourceSession _resourceSession;

		// Token: 0x0400044F RID: 1103
		private bool _loaded;

		// Token: 0x04000450 RID: 1104
		private float _opacity;
	}
}
