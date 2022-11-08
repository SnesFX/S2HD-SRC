using System;
using System.Collections.Generic;
using SonicOrca.Graphics;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000011 RID: 17
	internal class ShadowRenderer : IRenderer, IDisposable
	{
		// Token: 0x060000CB RID: 203 RVA: 0x00004F33 File Offset: 0x00003133
		public static ShadowRenderer FromRenderer(Renderer renderer)
		{
			if (!ShadowRenderer.RendererDictionary.ContainsKey(renderer))
			{
				ShadowRenderer.RendererDictionary.Add(renderer, new ShadowRenderer(renderer));
			}
			return ShadowRenderer.RendererDictionary[renderer];
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004F60 File Offset: 0x00003160
		private ShadowRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/shadow.shader");
			this._vertexBuffer = this._graphicsContext.CreateVertexBuffer(new int[]
			{
				2,
				2
			});
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004FC7 File Offset: 0x000031C7
		public void Dispose()
		{
			this._vertexBuffer.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x0400007B RID: 123
		private static readonly Dictionary<Renderer, ShadowRenderer> RendererDictionary = new Dictionary<Renderer, ShadowRenderer>();

		// Token: 0x0400007C RID: 124
		private readonly Renderer _renderer;

		// Token: 0x0400007D RID: 125
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x0400007E RID: 126
		public static bool IsShadowing = false;

		// Token: 0x0400007F RID: 127
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x04000080 RID: 128
		private VertexBuffer _vertexBuffer;
	}
}
