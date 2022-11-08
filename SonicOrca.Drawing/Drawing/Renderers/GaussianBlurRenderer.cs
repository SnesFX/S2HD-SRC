using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x0200000B RID: 11
	public class GaussianBlurRenderer : IRenderer, IDisposable
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003B65 File Offset: 0x00001D65
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00003B6D File Offset: 0x00001D6D
		public double Softness
		{
			get
			{
				return this._softness;
			}
			set
			{
				if (this._softness != value)
				{
					if (value == 0.0)
					{
						throw new ArgumentException("Softness can not be 0.", "value");
					}
					this._softness = value;
					this._gaussianWeights = GaussianBlurRenderer.CalculateWeights(value);
				}
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003BA7 File Offset: 0x00001DA7
		public static GaussianBlurRenderer FromRenderer(Renderer renderer)
		{
			if (!GaussianBlurRenderer.RendererDictionary.ContainsKey(renderer))
			{
				GaussianBlurRenderer.RendererDictionary.Add(renderer, new GaussianBlurRenderer(renderer));
			}
			return GaussianBlurRenderer.RendererDictionary[renderer];
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003BD4 File Offset: 0x00001DD4
		private GaussianBlurRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/gaussian_blur.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(GaussianBlurRenderer.Vertex));
			this.Softness = 8.0;
			this._shaderProgram.Program.Activate();
			this._shaderProgram.Program.SetUniform("InputTexture", 0);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003CBD File Offset: 0x00001EBD
		public void Dispose()
		{
			if (this._intermediateTarget != null)
			{
				this._intermediateTarget.Dispose();
			}
			this._vbo.Dispose();
			this._vao.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003CF3 File Offset: 0x00001EF3
		public void Render(ITexture texture, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			this.Render(texture, new Rectanglei(0, 0, texture.Width, texture.Height), destination, flipX, flipY);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003D14 File Offset: 0x00001F14
		public void Render(ITexture texture, Rectanglei source, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			Renderer.GetVertices(destination, this.vertexPositions);
			Renderer.GetTextureMappings(texture, source, this.vertexUVs, flipX, flipY);
			for (int i = 0; i < 4; i++)
			{
				this._vertices[i] = new GaussianBlurRenderer.Vertex
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
			this._vbo.SetData<GaussianBlurRenderer.Vertex>(this._vertices, 0, 4);
			Matrix4 value = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			this._renderer.ActivateRenderer(this);
			this._graphicsContext.BlendMode = BlendMode.Alpha;
			this._graphicsContext.SetTexture(texture);
			IShaderProgram program = this._shaderProgram.Program;
			program.Activate();
			program.SetUniform("ProjectionMatrix", value);
			program.SetUniform("InputAxis", 0);
			for (int j = 0; j < 5; j++)
			{
				program.SetUniform("InputWeight[" + j + "]", this._gaussianWeights[j]);
			}
			IFramebuffer currentFramebuffer = this._graphicsContext.CurrentFramebuffer;
			if (this._intermediateTarget == null || this._intermediateTarget.Width < destination.Width || this._intermediateTarget.Height < destination.Height)
			{
				if (this._intermediateTarget != null)
				{
					this._intermediateTarget.Dispose();
				}
				this._intermediateTarget = this._graphicsContext.CreateFrameBuffer(destination.Width, destination.Height, 1);
			}
			this._intermediateTarget.Activate();
			this._graphicsContext.ClearBuffer();
			this._graphicsContext.BlendMode = BlendMode.Opaque;
			this._vao.Render(PrimitiveType.Quads, 0, 4);
			this._graphicsContext.SetTexture(this._intermediateTarget.Textures[0]);
			program.SetUniform("InputAxis", 1);
			currentFramebuffer.Activate();
			this._vao.Render(PrimitiveType.Quads, 0, 4);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003F7C File Offset: 0x0000217C
		private static double[] CalculateWeights(double sigma2)
		{
			double[] array = new double[5];
			array[0] = GaussianBlurRenderer.Gaussian(0.0, sigma2);
			double num = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = GaussianBlurRenderer.Gaussian((double)i, sigma2);
				num += 2.0 * array[i];
			}
			for (int j = 0; j < array.Length; j++)
			{
				array[j] /= num;
			}
			return array;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003FEC File Offset: 0x000021EC
		private static double Gaussian(double x, double sigma2)
		{
			double num = 1.0 / (6.283185307179586 * sigma2);
			double d = -(x * x) / (2.0 * sigma2);
			return num * Math.Exp(d);
		}

		// Token: 0x04000041 RID: 65
		private static readonly Dictionary<Renderer, GaussianBlurRenderer> RendererDictionary = new Dictionary<Renderer, GaussianBlurRenderer>();

		// Token: 0x04000042 RID: 66
		private readonly Renderer _renderer;

		// Token: 0x04000043 RID: 67
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000044 RID: 68
		private readonly IBuffer _vbo;

		// Token: 0x04000045 RID: 69
		private readonly IVertexArray _vao;

		// Token: 0x04000046 RID: 70
		private readonly GaussianBlurRenderer.Vertex[] _vertices = new GaussianBlurRenderer.Vertex[4];

		// Token: 0x04000047 RID: 71
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x04000048 RID: 72
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x04000049 RID: 73
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x0400004A RID: 74
		private IFramebuffer _intermediateTarget;

		// Token: 0x0400004B RID: 75
		private double[] _gaussianWeights;

		// Token: 0x0400004C RID: 76
		private double _softness;

		// Token: 0x02000021 RID: 33
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x04000103 RID: 259
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x04000104 RID: 260
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;
		}
	}
}
