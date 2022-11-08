using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x0200000C RID: 12
	internal class HeatRenderer : IHeatRenderer, IRenderer, IDisposable
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00004032 File Offset: 0x00002232
		// (set) Token: 0x0600008E RID: 142 RVA: 0x0000403A File Offset: 0x0000223A
		public ITexture DistortionTexture { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00004043 File Offset: 0x00002243
		// (set) Token: 0x06000090 RID: 144 RVA: 0x0000404B File Offset: 0x0000224B
		public double DistortionAmount { get; set; }

		// Token: 0x06000091 RID: 145 RVA: 0x00004054 File Offset: 0x00002254
		public static HeatRenderer FromRenderer(Renderer renderer)
		{
			if (!HeatRenderer.RendererDictionary.ContainsKey(renderer))
			{
				HeatRenderer.RendererDictionary.Add(renderer, new HeatRenderer(renderer));
			}
			return HeatRenderer.RendererDictionary[renderer];
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004080 File Offset: 0x00002280
		private HeatRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/heat.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(HeatRenderer.Vertex));
			this._shaderProgram.Program.Activate();
			this._shaderProgram.Program.SetUniform("InputTexture", 0);
			this._shaderProgram.Program.SetUniform("InputDistortionTexture", 1);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000417C File Offset: 0x0000237C
		public void Dispose()
		{
			this._vbo.Dispose();
			this._vao.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000419F File Offset: 0x0000239F
		public void Render(ITexture texture, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			this.Render(texture, new Rectanglei(0, 0, texture.Width, texture.Height), destination, flipX, flipY);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000041C0 File Offset: 0x000023C0
		public void Render(ITexture texture, Rectanglei source, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			Renderer.GetVertices(destination, this.vertexPositions);
			Renderer.GetTextureMappings(texture, source, this.vertexUVs, flipX, flipY);
			Renderer.GetTextureMappings(this.DistortionTexture, new Rectanglei(0, 0, this.DistortionTexture.Width, this.DistortionTexture.Height), this.distortionUVs, false, false);
			for (int i = 0; i < 4; i++)
			{
				this._vertices[i] = new HeatRenderer.Vertex
				{
					position = this.vertexPositions[i].ToVec2(),
					texcoords = this.vertexUVs[i].ToVec2(),
					distortiontexcoords = this.distortionUVs[i].ToVec2()
				};
			}
			this._vbo.SetData<HeatRenderer.Vertex>(this._vertices, 0, 4);
			Matrix4 value = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			this._renderer.ActivateRenderer(this);
			this._graphicsContext.BlendMode = BlendMode.Alpha;
			this._graphicsContext.SetTextures(new ITexture[]
			{
				texture,
				this.DistortionTexture
			});
			IShaderProgram program = this._shaderProgram.Program;
			program.Activate();
			program.SetUniform("ProjectionMatrix", value);
			program.SetUniform("InputDistortionAmount", this.DistortionAmount);
			this._vao.Render(PrimitiveType.Quads, 0, 4);
		}

		// Token: 0x0400004D RID: 77
		private static readonly Dictionary<Renderer, HeatRenderer> RendererDictionary = new Dictionary<Renderer, HeatRenderer>();

		// Token: 0x0400004E RID: 78
		private readonly Renderer _renderer;

		// Token: 0x0400004F RID: 79
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000050 RID: 80
		private readonly IBuffer _vbo;

		// Token: 0x04000051 RID: 81
		private readonly IVertexArray _vao;

		// Token: 0x04000052 RID: 82
		private readonly HeatRenderer.Vertex[] _vertices = new HeatRenderer.Vertex[4];

		// Token: 0x04000053 RID: 83
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x04000054 RID: 84
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x04000055 RID: 85
		private Vector2[] distortionUVs = new Vector2[4];

		// Token: 0x04000056 RID: 86
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x02000022 RID: 34
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x04000105 RID: 261
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x04000106 RID: 262
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;

			// Token: 0x04000107 RID: 263
			[VertexAttribute("DistortionTextureMapping")]
			public vec2 distortiontexcoords;
		}
	}
}
