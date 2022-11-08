using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Core;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000015 RID: 21
	internal class WaterRenderer : IWaterRenderer, IRenderer, IDisposable
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000120 RID: 288 RVA: 0x000069E8 File Offset: 0x00004BE8
		// (set) Token: 0x06000121 RID: 289 RVA: 0x000069F0 File Offset: 0x00004BF0
		public double HueTarget { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000122 RID: 290 RVA: 0x000069F9 File Offset: 0x00004BF9
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00006A01 File Offset: 0x00004C01
		public double HueAmount { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00006A0A File Offset: 0x00004C0A
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00006A12 File Offset: 0x00004C12
		public double SaturationChange { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00006A1B File Offset: 0x00004C1B
		// (set) Token: 0x06000127 RID: 295 RVA: 0x00006A23 File Offset: 0x00004C23
		public double LuminosityChange { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00006A2C File Offset: 0x00004C2C
		// (set) Token: 0x06000129 RID: 297 RVA: 0x00006A34 File Offset: 0x00004C34
		public double WavePhase { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00006A3D File Offset: 0x00004C3D
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00006A45 File Offset: 0x00004C45
		public double NumWaves { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00006A4E File Offset: 0x00004C4E
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00006A56 File Offset: 0x00004C56
		public double WaveSize { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00006A5F File Offset: 0x00004C5F
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00006A67 File Offset: 0x00004C67
		public float Time { get; set; }

		// Token: 0x06000130 RID: 304 RVA: 0x00006A70 File Offset: 0x00004C70
		public static WaterRenderer FromRenderer(Renderer renderer)
		{
			if (!WaterRenderer.RendererDictionary.ContainsKey(renderer))
			{
				WaterRenderer.RendererDictionary.Add(renderer, new WaterRenderer(renderer));
			}
			return WaterRenderer.RendererDictionary[renderer];
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00006A9C File Offset: 0x00004C9C
		private WaterRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/water.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(WaterRenderer.Vertex));
			this._canvas = this._graphicsContext.CreateFrameBuffer(1920, 1080, 1);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00006B6C File Offset: 0x00004D6C
		public void Dispose()
		{
			this._canvas.Dispose();
			this._vbo.Dispose();
			this._vao.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00006B9C File Offset: 0x00004D9C
		public void Render(Rectanglei regionToFilter)
		{
			IFramebuffer currentFramebuffer = this._graphicsContext.CurrentFramebuffer;
			WaterManager.waveTexture.Wrapping = TextureWrapping.Repeat;
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, 33071);
			int num = (int)(WaterManager.viewportWaterLevel - 80f);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 1080)
			{
				num = 1080;
			}
			this._canvas.Activate();
			this.Render(currentFramebuffer.Textures[0], new Rectanglei(0, 0, 1920, 1080 - num), new Rectanglei(0, 0, 1920, 1080 - num), false, false);
			currentFramebuffer.Activate();
			SimpleRenderer simpleRenderer = SimpleRenderer.FromRenderer(this._renderer);
			simpleRenderer.BlendMode = BlendMode.Alpha;
			simpleRenderer.Colour = Colours.White;
			simpleRenderer.RenderTexture(this._canvas.Textures[0], new Rectanglei(0, num, 1920, 1080), new Rectanglei(0, num, 1920, 1080), false, false);
			simpleRenderer.BlendMode = BlendMode.Alpha;
			simpleRenderer.Deactivate();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00006CAE File Offset: 0x00004EAE
		public void Render(ITexture texture, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			this.Render(texture, new Rectanglei(0, 0, texture.Width, texture.Height), destination, flipX, flipY);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00006CD0 File Offset: 0x00004ED0
		public void Render(ITexture texture, Rectanglei source, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			Renderer.GetVertices(destination, this.vertexPositions);
			Renderer.GetTextureMappings(texture, source, this.vertexUVs, flipX, flipY);
			for (int i = 0; i < 4; i++)
			{
				this._vertices[i].position = this.vertexPositions[i].ToVec2();
				this._vertices[i].texcoords = this.vertexUVs[i].ToVec2();
			}
			this._vbo.SetData<WaterRenderer.Vertex>(this._vertices, 0, 4);
			Matrix4 value = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			this._renderer.ActivateRenderer(this);
			this._graphicsContext.BlendMode = BlendMode.Alpha;
			this._graphicsContext.SetTexture(0, texture);
			this._graphicsContext.SetTexture(1, WaterManager.waveTexture);
			IShaderProgram program = this._shaderProgram.Program;
			program.Activate();
			program.SetUniform("ProjectionMatrix", value);
			program.SetUniform("InputTexture", 0);
			program.SetUniform("WaveTexture", 1);
			program.SetUniform("InputHueTarget", this.HueTarget);
			program.SetUniform("InputHueAmount", this.HueAmount);
			program.SetUniform("InputSaturationChange", this.SaturationChange);
			program.SetUniform("InputLuminosityChange", this.LuminosityChange);
			program.SetUniform("InputWavePhase", this.WavePhase);
			program.SetUniform("InputNumWaves", this.NumWaves);
			program.SetUniform("InputWaveSize", this.WaveSize);
			program.SetUniform("iGlobalTime", this.Time);
			program.SetUniform("InputPositionX", WaterManager.offsetX);
			program.SetUniform("InputPositionY", -WaterManager.offsetY);
			program.SetUniform("InputWaterLevel", WaterManager.viewportWaterLevel / 1080f);
			this._graphicsContext.BlendMode = BlendMode.Opaque;
			this._vao.Render(SonicOrca.Graphics.PrimitiveType.Quads, 0, 4);
		}

		// Token: 0x040000BB RID: 187
		private static readonly Dictionary<Renderer, WaterRenderer> RendererDictionary = new Dictionary<Renderer, WaterRenderer>();

		// Token: 0x040000BC RID: 188
		private readonly Renderer _renderer;

		// Token: 0x040000BD RID: 189
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x040000BE RID: 190
		private readonly IBuffer _vbo;

		// Token: 0x040000BF RID: 191
		private readonly IVertexArray _vao;

		// Token: 0x040000C0 RID: 192
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x040000C1 RID: 193
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x040000C2 RID: 194
		private readonly WaterRenderer.Vertex[] _vertices = new WaterRenderer.Vertex[4];

		// Token: 0x040000C3 RID: 195
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x040000C4 RID: 196
		private IFramebuffer _canvas;

		// Token: 0x0200002C RID: 44
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x04000133 RID: 307
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x04000134 RID: 308
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;
		}
	}
}
