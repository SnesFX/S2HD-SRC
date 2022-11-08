using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SonicOrca.Core;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000013 RID: 19
	public class TileRenderer : ITileRenderer, IRenderer, IDisposable
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00005F8D File Offset: 0x0000418D
		// (set) Token: 0x060000FA RID: 250 RVA: 0x00005F95 File Offset: 0x00004195
		public Matrix4 ModelMatrix { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00005F9E File Offset: 0x0000419E
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00005FA6 File Offset: 0x000041A6
		public ITexture[] Textures { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00005FAF File Offset: 0x000041AF
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00005FB7 File Offset: 0x000041B7
		public Colour Colour { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00005FC0 File Offset: 0x000041C0
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00005FC8 File Offset: 0x000041C8
		public Rectangle ClipRectangle { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00005FD1 File Offset: 0x000041D1
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00005FD9 File Offset: 0x000041D9
		public int Filter { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00005FE2 File Offset: 0x000041E2
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00005FEA File Offset: 0x000041EA
		public double FilterAmount { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00005FF3 File Offset: 0x000041F3
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00005FFB File Offset: 0x000041FB
		public bool Rendering { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00006004 File Offset: 0x00004204
		// (set) Token: 0x06000108 RID: 264 RVA: 0x0000600C File Offset: 0x0000420C
		public int NumTiles { get; private set; }

		// Token: 0x06000109 RID: 265 RVA: 0x00006015 File Offset: 0x00004215
		public static TileRenderer FromRenderer(Renderer renderer)
		{
			if (!TileRenderer.RendererDictionary.ContainsKey(renderer))
			{
				TileRenderer.RendererDictionary.Add(renderer, new TileRenderer(renderer));
			}
			return TileRenderer.RendererDictionary[renderer];
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00006040 File Offset: 0x00004240
		private TileRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/tile.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(TileRenderer.Vertex));
			this.ModelMatrix = Matrix4.Identity;
			this.Colour = Colours.White;
			this.ClipRectangle = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
			this._shaderProgram.Program.Activate();
			for (int i = 0; i < 4; i++)
			{
				this._shaderProgram.Program.SetUniform("InputTexture[" + i + "]", i);
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000617C File Offset: 0x0000437C
		public void Dispose()
		{
			this._vbo.Dispose();
			this._vao.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000619F File Offset: 0x0000439F
		public void BeginRender()
		{
			if (this.Rendering)
			{
				throw new InvalidOperationException("Already renderering.");
			}
			this.Rendering = true;
			this.NumTiles = 0;
			this.numVertices = 0;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000061CC File Offset: 0x000043CC
		public void AddTile(Rectanglei source, Rectanglei destination, int textureIndex, bool flipX = false, bool flipY = false, float opacity = 1f, TileBlendMode blend = TileBlendMode.Alpha)
		{
			if (!this.Rendering)
			{
				throw new Exception("Not currently renderering");
			}
			ITexture texture = this.Textures[textureIndex];
			Renderer.GetVertices(destination, this.vertexPositions);
			Renderer.GetTextureMappings(texture, source, this.vertexUVs, flipX, flipY);
			for (int i = 0; i < 4; i++)
			{
				this._vertices[this.numVertices].position.x = (float)this.vertexPositions[i].X;
				this._vertices[this.numVertices].position.y = (float)this.vertexPositions[i].Y;
				this._vertices[this.numVertices].texcoords.s = (float)this.vertexUVs[i].X;
				this._vertices[this.numVertices].texcoords.t = (float)this.vertexUVs[i].Y;
				this._vertices[this.numVertices].texindex = (float)textureIndex;
				this._vertices[this.numVertices].opacity = opacity;
				this.numVertices++;
				if (this.numVertices >= this._vertices.Length)
				{
					TileRenderer.Vertex[] array = new TileRenderer.Vertex[this._vertices.Length * 2];
					Array.Copy(this._vertices, array, this._vertices.Length);
					this._vertices = array;
				}
			}
			int numTiles = this.NumTiles;
			this.NumTiles = numTiles + 1;
			this._tempLastBlendMode = blend;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000636C File Offset: 0x0000456C
		public void EndRender()
		{
			if (!this.Rendering)
			{
				throw new Exception("Not currently renderering");
			}
			this._vbo.SetData<TileRenderer.Vertex>(this._vertices, 0, this.numVertices);
			this._renderer.ActivateRenderer(this);
			this._graphicsContext.BlendMode = ((this._tempLastBlendMode == TileBlendMode.Additive) ? BlendMode.Additive : BlendMode.Alpha);
			ITexture[] textures = this.Textures;
			for (int i = 0; i < textures.Length; i++)
			{
				textures[i].Filtering = TextureFiltering.NearestNeighbour;
			}
			this._graphicsContext.SetTextures(this.Textures);
			Matrix4 value = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			IShaderProgram program = this._shaderProgram.Program;
			program.Activate();
			if (ShadowRenderer.IsShadowing)
			{
				program.SetUniform("AlphaGrayscale", 1f);
			}
			else
			{
				program.SetUniform("AlphaGrayscale", 0f);
			}
			program.SetUniform("ModelViewMatrix", this.ModelMatrix);
			program.SetUniform("ProjectionMatrix", value);
			program.SetUniform("InputColour", this.Colour);
			program.SetUniform("InputClipRectangle", new Vector4(this.ClipRectangle.X, this.ClipRectangle.Y, this.ClipRectangle.Right, this.ClipRectangle.Bottom));
			program.SetUniform("ShadowColour", TileRenderer.ShadowColour);
			program.SetUniform("InputFilter", this.Filter);
			program.SetUniform("InputFilterAmount", this.FilterAmount);
			this._vao.Render(PrimitiveType.Quads, 0, this.numVertices);
			this.Rendering = false;
		}

		// Token: 0x04000098 RID: 152
		private static readonly Dictionary<Renderer, TileRenderer> RendererDictionary = new Dictionary<Renderer, TileRenderer>();

		// Token: 0x04000099 RID: 153
		private readonly Renderer _renderer;

		// Token: 0x0400009A RID: 154
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x0400009B RID: 155
		private readonly IBuffer _vbo;

		// Token: 0x0400009C RID: 156
		private readonly IVertexArray _vao;

		// Token: 0x0400009D RID: 157
		private TileRenderer.Vertex[] _vertices = new TileRenderer.Vertex[20];

		// Token: 0x0400009E RID: 158
		public int numVertices;

		// Token: 0x0400009F RID: 159
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x040000A0 RID: 160
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x040000A1 RID: 161
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x040000AA RID: 170
		public static Colour ShadowColour;

		// Token: 0x040000AB RID: 171
		private TileBlendMode _tempLastBlendMode;

		// Token: 0x0200002A RID: 42
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x0400012B RID: 299
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x0400012C RID: 300
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;

			// Token: 0x0400012D RID: 301
			[VertexAttribute("VertexTextureIndex")]
			public float texindex;

			// Token: 0x0400012E RID: 302
			[VertexAttribute("VertexOpacity")]
			public float opacity;
		}
	}
}
