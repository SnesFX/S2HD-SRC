using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000008 RID: 8
	public class CharacterRenderer : ICharacterRenderer, IRenderer, IDisposable
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000301E File Offset: 0x0000121E
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00003026 File Offset: 0x00001226
		public Matrix4 ModelMatrix { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000064 RID: 100 RVA: 0x0000302F File Offset: 0x0000122F
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00003037 File Offset: 0x00001237
		public Rectangle ClipRectangle { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003040 File Offset: 0x00001240
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00003048 File Offset: 0x00001248
		public int Filter { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003051 File Offset: 0x00001251
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00003059 File Offset: 0x00001259
		public double FilterAmount { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003062 File Offset: 0x00001262
		// (set) Token: 0x0600006B RID: 107 RVA: 0x0000306A File Offset: 0x0000126A
		public float Brightness { get; set; }

		// Token: 0x0600006C RID: 108 RVA: 0x00003073 File Offset: 0x00001273
		public static CharacterRenderer FromRenderer(Renderer renderer)
		{
			if (!CharacterRenderer.RendererDictionary.ContainsKey(renderer))
			{
				CharacterRenderer.RendererDictionary.Add(renderer, new CharacterRenderer(renderer));
			}
			return CharacterRenderer.RendererDictionary[renderer];
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000030A0 File Offset: 0x000012A0
		private CharacterRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/character.shader");
			this._ghostShaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/ghost.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vaoGhost = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(CharacterRenderer.Vertex));
			this._vaoGhost.DefineAttributes(this._ghostShaderProgram.Program, this._vbo, typeof(CharacterRenderer.Vertex));
			this.ModelMatrix = Matrix4.Identity;
			this.ClipRectangle = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
			this._shaderProgram.Program.Activate();
			this._shaderProgram.Program.SetUniform("InputTextureSkin", 0);
			this._shaderProgram.Program.SetUniform("InputTextureBody", 1);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003217 File Offset: 0x00001417
		public void Dispose()
		{
			this._vao.Dispose();
			this._vaoGhost.Dispose();
			this._vbo.Dispose();
			this._shaderProgram.Dispose();
			this._ghostShaderProgram.Dispose();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003250 File Offset: 0x00001450
		public void RenderTexture(ITexture skinTexture, ITexture bodyTexture, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			this.RenderTexture(skinTexture, bodyTexture, 0.0, 0.0, 0.0, source, destination, flipX, flipY);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003288 File Offset: 0x00001488
		public void RenderTexture(ITexture skinTexture, ITexture bodyTexture, double hueShift, double satuationShift, double luminosityShift, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			this.RenderTexture(this._shaderProgram, skinTexture, bodyTexture, hueShift, satuationShift, luminosityShift, source, destination, flipX, flipY);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000032B0 File Offset: 0x000014B0
		public void RenderTextureGhost(ITexture skinTexture, ITexture bodyTexture, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			this.RenderTexture(this._ghostShaderProgram, skinTexture, bodyTexture, 0.0, 0.0, 0.0, source, destination, flipX, flipY);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000032F0 File Offset: 0x000014F0
		private void RenderTexture(ManagedShaderProgram managedShaderProgram, ITexture skinTexture, ITexture bodyTexture, double hueShift, double satuationShift, double luminosityShift, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			Renderer.GetVertices(destination, this.vertexPositions);
			Renderer.GetTextureMappings(skinTexture, source, this.vertexUVs, flipX, flipY);
			for (int i = 0; i < 4; i++)
			{
				this._vertices[i] = new CharacterRenderer.Vertex
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
					}
				};
			}
			this._vbo.SetData<CharacterRenderer.Vertex>(this._vertices, 0, 4);
			Matrix4 value = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			this._renderer.ActivateRenderer(this);
			this._graphicsContext.BlendMode = BlendMode.Alpha;
			this._graphicsContext.SetTextures(new ITexture[]
			{
				skinTexture,
				bodyTexture
			});
			IShaderProgram program = managedShaderProgram.Program;
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
			program.SetUniform("InputHSLShift", new Vector3(hueShift, satuationShift, luminosityShift));
			program.SetUniform("InputClipRectangle", new Vector4(this.ClipRectangle.X, this.ClipRectangle.Y, this.ClipRectangle.Right, this.ClipRectangle.Bottom));
			program.SetUniform("InputFilter", this.Filter);
			program.SetUniform("InputFilterAmount", this.FilterAmount);
			if (managedShaderProgram == this._shaderProgram)
			{
				program.SetUniform("InputBrightness", this.Brightness);
			}
			((managedShaderProgram == this._ghostShaderProgram) ? this._vaoGhost : this._vao).Render(PrimitiveType.Quads, 0, 4);
		}

		// Token: 0x04000021 RID: 33
		private static readonly Dictionary<Renderer, CharacterRenderer> RendererDictionary = new Dictionary<Renderer, CharacterRenderer>();

		// Token: 0x04000022 RID: 34
		private readonly Renderer _renderer;

		// Token: 0x04000023 RID: 35
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000024 RID: 36
		private readonly IBuffer _vbo;

		// Token: 0x04000025 RID: 37
		private readonly IVertexArray _vao;

		// Token: 0x04000026 RID: 38
		private readonly IVertexArray _vaoGhost;

		// Token: 0x04000027 RID: 39
		private CharacterRenderer.Vertex[] _vertices = new CharacterRenderer.Vertex[4];

		// Token: 0x04000028 RID: 40
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x04000029 RID: 41
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x0400002A RID: 42
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x0400002B RID: 43
		private ManagedShaderProgram _ghostShaderProgram;

		// Token: 0x0200001F RID: 31
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x040000FF RID: 255
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x04000100 RID: 256
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;
		}
	}
}
