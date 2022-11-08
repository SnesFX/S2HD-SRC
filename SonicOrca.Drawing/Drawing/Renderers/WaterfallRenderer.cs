using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000014 RID: 20
	internal class WaterfallRenderer : IRenderer, IDisposable
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000111 RID: 273 RVA: 0x0000651F File Offset: 0x0000471F
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00006527 File Offset: 0x00004727
		public ITexture DistortionTexture { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00006530 File Offset: 0x00004730
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00006538 File Offset: 0x00004738
		public double DistortionAmount { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00006541 File Offset: 0x00004741
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00006549 File Offset: 0x00004749
		public Vector2 DistortionOffset { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00006552 File Offset: 0x00004752
		// (set) Token: 0x06000118 RID: 280 RVA: 0x0000655A File Offset: 0x0000475A
		public Vector2i NonDistortionRadius { get; set; }

		// Token: 0x06000119 RID: 281 RVA: 0x00006563 File Offset: 0x00004763
		public static WaterfallRenderer FromRenderer(Renderer renderer)
		{
			if (!WaterfallRenderer.RendererDictionary.ContainsKey(renderer))
			{
				WaterfallRenderer.RendererDictionary.Add(renderer, new WaterfallRenderer(renderer));
			}
			return WaterfallRenderer.RendererDictionary[renderer];
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00006590 File Offset: 0x00004790
		private WaterfallRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/waterfall.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(WaterfallRenderer.Vertex));
			this._shaderProgram.Program.Activate();
			this._shaderProgram.Program.SetUniform("InputTexture", 0);
			this._shaderProgram.Program.SetUniform("InputDistortionTexture", 1);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00006698 File Offset: 0x00004898
		public void Dispose()
		{
			this._vbo.Dispose();
			this._vao.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000066BB File Offset: 0x000048BB
		public void Render(ITexture texture, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			this.Render(texture, new Rectanglei(0, 0, texture.Width, texture.Height), destination, flipX, flipY);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000066DC File Offset: 0x000048DC
		public void Render(ITexture texture, Rectanglei source, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			Renderer.GetVertices(destination, this.vertexPositions);
			Renderer.GetTextureMappings(texture, source, this.vertexUVs, flipX, flipY);
			Renderer.GetTextureMappings(this.DistortionTexture, new Rectangle(this.DistortionOffset.X * (double)this.DistortionTexture.Width, this.DistortionOffset.Y * (double)this.DistortionTexture.Height, (double)destination.Width, (double)destination.Height), this.distortionUVs, false, false);
			Renderer.GetVertices(new Rectangle(0.0, 0.0, 1.0, 1.0), this.vertexNormalisation);
			for (int i = 0; i < 4; i++)
			{
				this._vertices[i] = new WaterfallRenderer.Vertex
				{
					position = new vec2
					{
						x = (float)this.vertexPositions[i].X,
						y = (float)this.vertexPositions[i].Y
					},
					texcoords = new vec2
					{
						s = (float)this.vertexUVs[i].X,
						t = (float)this.vertexUVs[i].Y
					},
					distortiontexcoords = new vec2
					{
						s = (float)this.distortionUVs[i].X,
						t = (float)this.distortionUVs[i].Y
					},
					normalisation = new vec2
					{
						x = (float)this.vertexNormalisation[i].X,
						y = (float)this.vertexNormalisation[i].Y
					}
				};
			}
			this._vbo.SetData<WaterfallRenderer.Vertex>(this._vertices, 0, 4);
			Matrix4 value = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			this._renderer.ActivateRenderer(this);
			this._graphicsContext.BlendMode = BlendMode.Opaque;
			this._graphicsContext.SetTextures(new ITexture[]
			{
				texture,
				this.DistortionTexture
			});
			IShaderProgram program = this._shaderProgram.Program;
			program.Activate();
			program.SetUniform("ProjectionMatrix", value);
			program.SetUniform("InputDistortionAmount", 1.0 / (double)texture.Height * this.DistortionAmount);
			program.SetUniform("InputNonDistortionRadius", new Vector2(1.0 / (double)destination.Width * (double)this.NonDistortionRadius.X, 1.0 / (double)destination.Height * (double)this.NonDistortionRadius.Y));
			this._vao.Render(PrimitiveType.Quads, 0, 4);
		}

		// Token: 0x040000AC RID: 172
		private static readonly Dictionary<Renderer, WaterfallRenderer> RendererDictionary = new Dictionary<Renderer, WaterfallRenderer>();

		// Token: 0x040000AD RID: 173
		private readonly Renderer _renderer;

		// Token: 0x040000AE RID: 174
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x040000AF RID: 175
		private readonly IBuffer _vbo;

		// Token: 0x040000B0 RID: 176
		private readonly IVertexArray _vao;

		// Token: 0x040000B1 RID: 177
		private readonly WaterfallRenderer.Vertex[] _vertices = new WaterfallRenderer.Vertex[4];

		// Token: 0x040000B2 RID: 178
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x040000B3 RID: 179
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x040000B4 RID: 180
		private Vector2[] distortionUVs = new Vector2[4];

		// Token: 0x040000B5 RID: 181
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x040000BA RID: 186
		private Vector2[] vertexNormalisation = new Vector2[4];

		// Token: 0x0200002B RID: 43
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x0400012F RID: 303
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x04000130 RID: 304
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;

			// Token: 0x04000131 RID: 305
			[VertexAttribute("DistortionTextureMapping")]
			public vec2 distortiontexcoords;

			// Token: 0x04000132 RID: 306
			[VertexAttribute("VertexNormalisation")]
			public vec2 normalisation;
		}
	}
}
