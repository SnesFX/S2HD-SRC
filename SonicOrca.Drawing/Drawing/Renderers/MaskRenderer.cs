using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000006 RID: 6
	internal class MaskRenderer : IMaskRenderer, IDisposable, IRenderer
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000024B8 File Offset: 0x000006B8
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000024C0 File Offset: 0x000006C0
		public ITexture Texture { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000024C9 File Offset: 0x000006C9
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000024D1 File Offset: 0x000006D1
		public Rectanglei Source { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000024DA File Offset: 0x000006DA
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000024E2 File Offset: 0x000006E2
		public Rectanglei Destination { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000024EB File Offset: 0x000006EB
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000024F3 File Offset: 0x000006F3
		public ITexture MaskTexture { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000024FC File Offset: 0x000006FC
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00002504 File Offset: 0x00000704
		public Rectanglei MaskSource { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000035 RID: 53 RVA: 0x0000250D File Offset: 0x0000070D
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00002515 File Offset: 0x00000715
		public Rectanglei MaskDestination { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000251E File Offset: 0x0000071E
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00002526 File Offset: 0x00000726
		public BlendMode BlendMode { get; set; } = BlendMode.Alpha;

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000252F File Offset: 0x0000072F
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002537 File Offset: 0x00000737
		public Colour Colour { get; set; } = Colours.White;

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002540 File Offset: 0x00000740
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002548 File Offset: 0x00000748
		public Matrix4 MaskModelMatrix
		{
			get
			{
				return this._maskModelMatrix;
			}
			set
			{
				if (this._maskModelMatrix != value)
				{
					this._maskModelMatrix = value;
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000255F File Offset: 0x0000075F
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002567 File Offset: 0x00000767
		public Matrix4 IntersectionModelMatrix
		{
			get
			{
				return this._intersectionModelMatrix;
			}
			set
			{
				if (this._intersectionModelMatrix != value)
				{
					this._intersectionModelMatrix = value;
				}
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000257E File Offset: 0x0000077E
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002586 File Offset: 0x00000786
		public Matrix4 TargetModelMatrix
		{
			get
			{
				return this._targetModelMatrix;
			}
			set
			{
				if (this._targetModelMatrix != value)
				{
					this._targetModelMatrix = value;
				}
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000259D File Offset: 0x0000079D
		public static MaskRenderer FromRenderer(Renderer renderer)
		{
			if (!MaskRenderer.RendererDictionary.ContainsKey(renderer))
			{
				MaskRenderer.RendererDictionary.Add(renderer, new MaskRenderer(renderer));
			}
			return MaskRenderer.RendererDictionary[renderer];
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000025C8 File Offset: 0x000007C8
		public MaskRenderer(Renderer renderer)
		{
			this._graphicsContext = renderer.Window.GraphicsContext;
			renderer.RegisterRenderer(this);
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/mask.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(MaskRenderer.Vertex));
			this._shaderProgram.Program.Activate();
			this._shaderProgram.Program.SetUniform("InputTexture", 0);
			this._shaderProgram.Program.SetUniform("InputTextureMask", 1);
			this._intersectionModelMatrix = Matrix4.Identity;
			this._targetModelMatrix = Matrix4.Identity;
			this._maskModelMatrix = Matrix4.Identity;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000026CC File Offset: 0x000008CC
		public void Dispose()
		{
			this._vao.Dispose();
			this._vbo.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000026EF File Offset: 0x000008EF
		public IDisposable BeginMatixState()
		{
			return new MaskRenderer.MatrixState(this, this._intersectionModelMatrix, this._maskModelMatrix, this._targetModelMatrix);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000270C File Offset: 0x0000090C
		public void Render(bool maskColorMultiply = false)
		{
			IGraphicsContext graphicsContext = this._graphicsContext;
			IShaderProgram program = this._shaderProgram.Program;
			Rectanglei clippedDestination = Rectanglei.Intersect(this.Destination, this.MaskDestination);
			if (this.Texture == null)
			{
				throw new InvalidOperationException("Texture was null.");
			}
			int num = 0;
			if (this.MaskTexture != null)
			{
				num++;
				if (clippedDestination.Width <= 0 || clippedDestination.Height <= 0)
				{
					return;
				}
			}
			else
			{
				clippedDestination = this.Destination;
			}
			this._vertices[0].position.x = (float)clippedDestination.Left;
			this._vertices[0].position.y = (float)clippedDestination.Top;
			this._vertices[1].position.x = (float)clippedDestination.Left;
			this._vertices[1].position.y = (float)clippedDestination.Bottom;
			this._vertices[2].position.x = (float)clippedDestination.Right;
			this._vertices[2].position.y = (float)clippedDestination.Bottom;
			this._vertices[3].position.x = (float)clippedDestination.Right;
			this._vertices[3].position.y = (float)clippedDestination.Top;
			float s;
			float t;
			float s2;
			float t2;
			this.GetClippedSourceRect(this.Texture, this.Source, this.Destination, clippedDestination, out s, out t, out s2, out t2);
			ITexture texture = this.Texture;
			int width = texture.Width;
			int height = texture.Height;
			this._vertices[0].texcoords.s = s;
			this._vertices[0].texcoords.t = t;
			this._vertices[1].texcoords.s = s;
			this._vertices[1].texcoords.t = t2;
			this._vertices[2].texcoords.s = s2;
			this._vertices[2].texcoords.t = t2;
			this._vertices[3].texcoords.s = s2;
			this._vertices[3].texcoords.t = t;
			if (num > 0)
			{
				float s3;
				float t3;
				float s4;
				float t4;
				this.GetClippedSourceRect(this.MaskTexture, this.MaskSource, this.MaskDestination, clippedDestination, out s3, out t3, out s4, out t4);
				this._vertices[0].masktexcoords.s = s3;
				this._vertices[0].masktexcoords.t = t3;
				this._vertices[1].masktexcoords.s = s3;
				this._vertices[1].masktexcoords.t = t4;
				this._vertices[2].masktexcoords.s = s4;
				this._vertices[2].masktexcoords.t = t4;
				this._vertices[3].masktexcoords.s = s4;
				this._vertices[3].masktexcoords.t = t3;
			}
			this._vbo.SetData(this._vertices);
			graphicsContext.BlendMode = this.BlendMode;
			graphicsContext.SetTexture(0, this.Texture);
			graphicsContext.SetTexture(1, this.MaskTexture);
			program.Activate();
			program.SetUniform("IntersectionModelViewMatrix", this._intersectionModelMatrix);
			program.SetUniform("MaskModelViewMatrix", this._maskModelMatrix);
			program.SetUniform("TargetModelViewMatrix", this._targetModelMatrix);
			program.SetUniform("ProjectionMatrix", this._graphicsContext.CurrentFramebuffer.CreateOrthographic());
			program.SetUniform("MaskInput", num);
			program.SetUniform("InputColour", this.Colour);
			program.SetUniform("MaskColorMultiply", maskColorMultiply ? 1 : 0);
			this._vao.Render(PrimitiveType.Quads, this._vertices);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002B14 File Offset: 0x00000D14
		private void GetClippedSourceRect(ITexture sourceTexture, Rectanglei source, Rectanglei destination, Rectanglei clippedDestination, out float left, out float top, out float right, out float bottom)
		{
			left = (float)source.Left / (float)sourceTexture.Width;
			top = (float)source.Top / (float)sourceTexture.Height;
			right = (float)source.Right / (float)sourceTexture.Width;
			bottom = (float)source.Bottom / (float)sourceTexture.Height;
			float num = right - left;
			float num2 = bottom - top;
			left += (float)(clippedDestination.Left - destination.Left) / (float)destination.Width / num;
			top += (float)(clippedDestination.Top - destination.Top) / (float)destination.Height / num2;
			right -= (float)(destination.Right - clippedDestination.Right) / (float)destination.Width / num2;
			bottom -= (float)(destination.Bottom - clippedDestination.Bottom) / (float)destination.Height / num2;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x04000006 RID: 6
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000007 RID: 7
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x04000008 RID: 8
		private IBuffer _vbo;

		// Token: 0x04000009 RID: 9
		private IVertexArray _vao;

		// Token: 0x0400000A RID: 10
		private MaskRenderer.Vertex[] _vertices = new MaskRenderer.Vertex[4];

		// Token: 0x04000013 RID: 19
		private Matrix4 _maskModelMatrix;

		// Token: 0x04000014 RID: 20
		private Matrix4 _targetModelMatrix;

		// Token: 0x04000015 RID: 21
		private Matrix4 _intersectionModelMatrix;

		// Token: 0x04000016 RID: 22
		private static readonly Dictionary<Renderer, MaskRenderer> RendererDictionary = new Dictionary<Renderer, MaskRenderer>();

		// Token: 0x0200001D RID: 29
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x040000F8 RID: 248
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x040000F9 RID: 249
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;

			// Token: 0x040000FA RID: 250
			[VertexAttribute("VertexMaskTextureMapping")]
			public vec2 masktexcoords;
		}

		// Token: 0x0200001E RID: 30
		private class MatrixState : IDisposable
		{
			// Token: 0x06000180 RID: 384 RVA: 0x00008581 File Offset: 0x00006781
			public MatrixState(MaskRenderer maskRenderer, Matrix4 intersectionMatrix, Matrix4 maskMatrix, Matrix4 targetMatrix)
			{
				this._maskRenderer = maskRenderer;
				this._intersectionMatrix = intersectionMatrix;
				this._maskMatrix = maskMatrix;
				this._targetMatrix = targetMatrix;
			}

			// Token: 0x06000181 RID: 385 RVA: 0x000085A6 File Offset: 0x000067A6
			public void Dispose()
			{
				this._maskRenderer.IntersectionModelMatrix = this._intersectionMatrix;
				this._maskRenderer.MaskModelMatrix = this._maskMatrix;
				this._maskRenderer.TargetModelMatrix = this._targetMatrix;
			}

			// Token: 0x040000FB RID: 251
			private readonly MaskRenderer _maskRenderer;

			// Token: 0x040000FC RID: 252
			private readonly Matrix4 _maskMatrix;

			// Token: 0x040000FD RID: 253
			private readonly Matrix4 _targetMatrix;

			// Token: 0x040000FE RID: 254
			private readonly Matrix4 _intersectionMatrix;
		}
	}
}
