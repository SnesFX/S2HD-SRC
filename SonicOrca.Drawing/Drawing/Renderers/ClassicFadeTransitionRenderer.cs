using System;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000009 RID: 9
	internal class ClassicFadeTransitionRenderer : IFadeTransitionRenderer, IDisposable
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00003549 File Offset: 0x00001749
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00003551 File Offset: 0x00001751
		public float Opacity { get; set; }

		// Token: 0x06000077 RID: 119 RVA: 0x0000355C File Offset: 0x0000175C
		public ClassicFadeTransitionRenderer(IGraphicsContext graphicsContext)
		{
			this._graphicsContext = graphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/transition.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(ClassicFadeTransitionRenderer.Vertex));
			this._shaderProgram.Program.SetUniform("InputTexture", 0);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000035F6 File Offset: 0x000017F6
		public void Dispose()
		{
			this._vao.Dispose();
			this._vbo.Dispose();
			this._shaderProgram.Dispose();
			if (this._pingPongBuffer != null)
			{
				this._pingPongBuffer.Dispose();
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000362C File Offset: 0x0000182C
		public void Render()
		{
			IFramebuffer currentFramebuffer = this._graphicsContext.CurrentFramebuffer;
			if (this._pingPongBuffer == null || this._pingPongBuffer.Width != currentFramebuffer.Width || this._pingPongBuffer.Height != currentFramebuffer.Height)
			{
				if (this._pingPongBuffer != null)
				{
					this._pingPongBuffer.Dispose();
				}
				this._pingPongBuffer = this._graphicsContext.CreateFrameBuffer(currentFramebuffer.Width, currentFramebuffer.Height, 1);
			}
			this.Render(currentFramebuffer, this._pingPongBuffer);
			this.Opacity = 0f;
			this.Render(this._pingPongBuffer, currentFramebuffer);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000036CC File Offset: 0x000018CC
		public void Render(IFramebuffer sourceFramebuffer, IFramebuffer destFramebuffer)
		{
			IGraphicsContext graphicsContext = this._graphicsContext;
			IShaderProgram program = this._shaderProgram.Program;
			destFramebuffer.Activate();
			this._vertices[0].position.x = 0f;
			this._vertices[0].position.y = 0f;
			this._vertices[1].position.x = 0f;
			this._vertices[1].position.y = (float)destFramebuffer.Height;
			this._vertices[2].position.x = (float)destFramebuffer.Width;
			this._vertices[2].position.y = (float)destFramebuffer.Height;
			this._vertices[3].position.x = (float)destFramebuffer.Width;
			this._vertices[3].position.y = 0f;
			this._vertices[0].texcoords.s = 0f;
			this._vertices[0].texcoords.t = 1f;
			this._vertices[1].texcoords.s = 0f;
			this._vertices[1].texcoords.t = 0f;
			this._vertices[2].texcoords.s = 1f;
			this._vertices[2].texcoords.t = 0f;
			this._vertices[3].texcoords.s = 1f;
			this._vertices[3].texcoords.t = 1f;
			this._vbo.SetData(this._vertices);
			graphicsContext.BlendMode = BlendMode.Opaque;
			graphicsContext.SetTexture(sourceFramebuffer.Textures[0]);
			program.Activate();
			program.SetUniform("ProjectionMatrix", destFramebuffer.CreateOrthographic());
			program.SetUniform("InputDelta", this.Opacity);
			this._vao.Render(PrimitiveType.Quads, this._vertices);
		}

		// Token: 0x04000031 RID: 49
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000032 RID: 50
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x04000033 RID: 51
		private IBuffer _vbo;

		// Token: 0x04000034 RID: 52
		private IVertexArray _vao;

		// Token: 0x04000035 RID: 53
		private ClassicFadeTransitionRenderer.Vertex[] _vertices = new ClassicFadeTransitionRenderer.Vertex[4];

		// Token: 0x04000036 RID: 54
		private IFramebuffer _pingPongBuffer;

		// Token: 0x02000020 RID: 32
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x04000101 RID: 257
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x04000102 RID: 258
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;
		}
	}
}
