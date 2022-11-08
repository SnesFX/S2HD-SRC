using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;
using SonicOrca.Graphics.V2.Animation;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x0200000E RID: 14
	public class ObjectRenderer : IObjectRenderer, IRenderer, IDisposable
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600009F RID: 159 RVA: 0x0000455C File Offset: 0x0000275C
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x00004564 File Offset: 0x00002764
		public Matrix4 ModelMatrix { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x0000456D File Offset: 0x0000276D
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00004575 File Offset: 0x00002775
		public BlendMode BlendMode { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000457E File Offset: 0x0000277E
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00004586 File Offset: 0x00002786
		public Rectangle ClipRectangle { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x0000458F File Offset: 0x0000278F
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00004597 File Offset: 0x00002797
		public Colour MultiplyColour { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x000045A0 File Offset: 0x000027A0
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x000045A8 File Offset: 0x000027A8
		public Colour AdditiveColour { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000045B1 File Offset: 0x000027B1
		// (set) Token: 0x060000AA RID: 170 RVA: 0x000045B9 File Offset: 0x000027B9
		public ITexture Texture { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000AB RID: 171 RVA: 0x000045C2 File Offset: 0x000027C2
		// (set) Token: 0x060000AC RID: 172 RVA: 0x000045CA File Offset: 0x000027CA
		public Vector2 Scale
		{
			get
			{
				return this._scale;
			}
			set
			{
				this._scale = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000AD RID: 173 RVA: 0x000045D3 File Offset: 0x000027D3
		// (set) Token: 0x060000AE RID: 174 RVA: 0x000045DB File Offset: 0x000027DB
		public bool EmitsLight { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000AF RID: 175 RVA: 0x000045E4 File Offset: 0x000027E4
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x000045EC File Offset: 0x000027EC
		public bool Shadow { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x000045F5 File Offset: 0x000027F5
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x000045FD File Offset: 0x000027FD
		public int Filter { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00004606 File Offset: 0x00002806
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x0000460E File Offset: 0x0000280E
		public double FilterAmount { get; set; }

		// Token: 0x060000B5 RID: 181 RVA: 0x00004617 File Offset: 0x00002817
		public static ObjectRenderer FromRenderer(Renderer renderer)
		{
			if (!ObjectRenderer.RendererDictionary.ContainsKey(renderer))
			{
				ObjectRenderer.RendererDictionary.Add(renderer, new ObjectRenderer(renderer));
			}
			return ObjectRenderer.RendererDictionary[renderer];
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004644 File Offset: 0x00002844
		private ObjectRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/object.shader");
			this._shadowShaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/object_shadow.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vaoShadow = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(ObjectRenderer.Vertex));
			this._vaoShadow.DefineAttributes(this._shadowShaderProgram.Program, this._vbo, typeof(ObjectRenderer.Vertex));
			this.ModelMatrix = Matrix4.Identity;
			this.BlendMode = BlendMode.Alpha;
			this.ClipRectangle = new Rectangle(0.0, 0.0, (double)this._renderer.Window.ClientSize.X, (double)this._renderer.Window.ClientSize.Y);
			this.MultiplyColour = Colours.White;
			this.Scale = new Vector2(1.0, 1.0);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000047D8 File Offset: 0x000029D8
		public void Dispose()
		{
			this._vao.Dispose();
			this._vaoShadow.Dispose();
			this._vbo.Dispose();
			this._shaderProgram.Dispose();
			this._shadowShaderProgram.Dispose();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004811 File Offset: 0x00002A11
		public void Deactivate()
		{
			this.Render();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000481C File Offset: 0x00002A1C
		private void Render()
		{
			if (this._batchedVertexCount == 0)
			{
				return;
			}
			this.PushBatchOperation();
			this._vbo.SetData<ObjectRenderer.Vertex>(this._vertices.ToArray(), 0, this._vertices.Count);
			this._projectionMatrix = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			foreach (ObjectRenderer.BatchOperation batchOperation in this._batchOperations)
			{
				batchOperation.Render();
			}
			this._batchOperations.Clear();
			this._batchedVertexIndex = 0;
			this._batchedVertexCount = 0;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000048D8 File Offset: 0x00002AD8
		private void PushBatchOperation()
		{
			if (this._batchedVertexIndex == this._batchedVertexCount)
			{
				return;
			}
			this._batchOperations.Add(new ObjectRenderer.BatchOperation(this, this._batchedVertexIndex, this._batchedVertexCount - this._batchedVertexIndex, this.BlendMode, this.ClipRectangle, this.ModelMatrix, this.Texture, this.MultiplyColour, this.AdditiveColour, this.Shadow, this.EmitsLight ? 0 : this.Filter, this.FilterAmount));
			this._batchedVertexIndex = this._batchedVertexCount;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004968 File Offset: 0x00002B68
		private void PushVertices(IReadOnlyList<Vector2> positions, IReadOnlyList<Vector2> textureMappings)
		{
			this._renderer.ActivateRenderer(this);
			if (this._batchedVertexCount == 0)
			{
				this._batchedVertexIndex = 0;
				this._vertices.Clear();
			}
			for (int i = 0; i < positions.Count; i++)
			{
				this._vertices.Add(new ObjectRenderer.Vertex
				{
					position = new vec2
					{
						x = (float)positions[i].X,
						y = (float)positions[i].Y
					},
					texcoords = new vec2
					{
						s = (float)textureMappings[i].X,
						t = (float)textureMappings[i].Y
					}
				});
			}
			this._batchedVertexCount += positions.Count;
			this.PushBatchOperation();
			if (this._batchedVertexCount > 1024)
			{
				this.Render();
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004A6E File Offset: 0x00002C6E
		public IDisposable BeginMatixState()
		{
			return new ObjectRenderer.MatrixState(this, this.ModelMatrix, this.ClipRectangle);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004A82 File Offset: 0x00002C82
		public void SetDefault()
		{
			this.BlendMode = BlendMode.Alpha;
			this.MultiplyColour = Colours.White;
			this.AdditiveColour = Colours.Black;
			this.Shadow = false;
			this.EmitsLight = false;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004AB0 File Offset: 0x00002CB0
		public void Render(AnimationInstance animationInstance, bool flipX = false, bool flipY = false)
		{
			Animation.Frame currentFrame = animationInstance.CurrentFrame;
			this.Texture = animationInstance.CurrentTexture;
			this.Render(currentFrame.Source, currentFrame.Offset, flipX, flipY);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004AF0 File Offset: 0x00002CF0
		public void Render(AnimationInstance animationInstance, Vector2 destination, bool flipX = false, bool flipY = false)
		{
			Animation.Frame currentFrame = animationInstance.CurrentFrame;
			this.Texture = animationInstance.CurrentTexture;
			this.Render(currentFrame.Source, destination + currentFrame.Offset, flipX, flipY);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Render(CompositionInstance compositionInstance, Vector2 destination, bool flipX = false, bool flipY = false)
		{
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004B37 File Offset: 0x00002D37
		public void Render(Vector2 destination = default(Vector2), bool flipX = false, bool flipY = false)
		{
			this.Render(new Rectangle(0.0, 0.0, (double)this.Texture.Width, (double)this.Texture.Height), destination, flipX, flipY);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004B71 File Offset: 0x00002D71
		public void Render(Rectangle destination, bool flipX = false, bool flipY = false)
		{
			this.Render(new Rectangle(0.0, 0.0, (double)this.Texture.Width, (double)this.Texture.Height), destination, flipX, flipY);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004BAC File Offset: 0x00002DAC
		public void Render(Rectangle source, Vector2 offset, bool flipX = false, bool flipY = false)
		{
			this.Render(source, new Rectangle((offset.X - (double)((int)(source.Width / 2.0))) * this.Scale.X, (offset.Y - (double)((int)(source.Height / 2.0))) * this.Scale.Y, source.Width * this.Scale.X, source.Height * this.Scale.Y), flipX, flipY);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004C48 File Offset: 0x00002E48
		public void Render(Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			Renderer.GetVertices(destination, this.vertexPositions);
			if (Math.Abs(this.ModelMatrix.M11) != 1.0 || Math.Abs(this.ModelMatrix.M22) != 1.0)
			{
				Renderer.GetTextureMappingsHalfIn(this.Texture, source, ref this.vertexUVs, flipX, flipY);
			}
			else
			{
				Renderer.GetTextureMappings(this.Texture, source, this.vertexUVs, flipX, flipY);
			}
			this.PushVertices(this.vertexPositions, this.vertexUVs);
		}

		// Token: 0x04000061 RID: 97
		private static readonly Dictionary<Renderer, ObjectRenderer> RendererDictionary = new Dictionary<Renderer, ObjectRenderer>();

		// Token: 0x04000062 RID: 98
		private readonly Renderer _renderer;

		// Token: 0x04000063 RID: 99
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000064 RID: 100
		private readonly IBuffer _vbo;

		// Token: 0x04000065 RID: 101
		private readonly IVertexArray _vao;

		// Token: 0x04000066 RID: 102
		private readonly IVertexArray _vaoShadow;

		// Token: 0x04000067 RID: 103
		private readonly List<ObjectRenderer.Vertex> _vertices = new List<ObjectRenderer.Vertex>();

		// Token: 0x04000068 RID: 104
		private readonly ManagedShaderProgram _shaderProgram;

		// Token: 0x04000069 RID: 105
		private readonly ManagedShaderProgram _shadowShaderProgram;

		// Token: 0x0400006A RID: 106
		private Matrix4 _projectionMatrix;

		// Token: 0x0400006B RID: 107
		private readonly List<ObjectRenderer.BatchOperation> _batchOperations = new List<ObjectRenderer.BatchOperation>();

		// Token: 0x0400006C RID: 108
		private int _batchedVertexIndex;

		// Token: 0x0400006D RID: 109
		private int _batchedVertexCount;

		// Token: 0x04000074 RID: 116
		private Vector2 _scale;

		// Token: 0x04000079 RID: 121
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x0400007A RID: 122
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x02000024 RID: 36
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x04000109 RID: 265
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x0400010A RID: 266
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;
		}

		// Token: 0x02000025 RID: 37
		private class BatchOperation
		{
			// Token: 0x06000182 RID: 386 RVA: 0x000085DC File Offset: 0x000067DC
			public BatchOperation(ObjectRenderer objectRenderer, int vertexBufferIndex, int vertexCount, BlendMode blendMode, Rectangle clipRectangle, Matrix4 modelMatrix, ITexture texture, Colour multiplyColour, Colour additiveColour, bool shadow, int filter, double filterAmount)
			{
				this._objectRenderer = objectRenderer;
				this._vertexBufferIndex = vertexBufferIndex;
				this._vertexCount = vertexCount;
				this._blendMode = blendMode;
				this._clipRectangle = clipRectangle;
				this._modelMatrix = modelMatrix;
				this._texture = texture;
				this._multiplyColour = multiplyColour;
				this._additiveColour = additiveColour;
				this._shadow = shadow;
				this._filter = filter;
				this._filterAmount = filterAmount;
			}

			// Token: 0x06000183 RID: 387 RVA: 0x00008658 File Offset: 0x00006858
			public void Render()
			{
				IGraphicsContext graphicsContext = this._objectRenderer._graphicsContext;
				IShaderProgram shaderProgram = this._shadow ? this._objectRenderer._shadowShaderProgram.Program : this._objectRenderer._shaderProgram.Program;
				graphicsContext.BlendMode = this._blendMode;
				graphicsContext.SetTexture(this._texture);
				shaderProgram.Activate();
				if (ShadowRenderer.IsShadowing)
				{
					shaderProgram.SetUniform("AlphaGrayscale", 1f);
				}
				else
				{
					shaderProgram.SetUniform("AlphaGrayscale", 0f);
				}
				shaderProgram.SetUniform("ModelViewMatrix", this._modelMatrix);
				shaderProgram.SetUniform("ProjectionMatrix", this._objectRenderer._projectionMatrix);
				shaderProgram.SetUniform("InputTexture", 0);
				shaderProgram.SetUniform("InputClipRectangle", new Vector4(this._clipRectangle.X, this._clipRectangle.Y, this._clipRectangle.Right, this._clipRectangle.Bottom));
				shaderProgram.SetUniform("InputColourMultiply", this._multiplyColour);
				shaderProgram.SetUniform("InputColourAdd", this._additiveColour);
				shaderProgram.SetUniform("InputEnableMask", (this._blendMode == BlendMode.Additive) ? 0 : 1);
				shaderProgram.SetUniform("InputFilter", this._filter);
				shaderProgram.SetUniform("InputFilterAmount", this._filterAmount);
				(this._shadow ? this._objectRenderer._vaoShadow : this._objectRenderer._vao).Render(PrimitiveType.Quads, this._vertexBufferIndex, this._vertexCount);
			}

			// Token: 0x0400010B RID: 267
			private readonly ObjectRenderer _objectRenderer;

			// Token: 0x0400010C RID: 268
			private readonly int _vertexBufferIndex;

			// Token: 0x0400010D RID: 269
			private readonly int _vertexCount;

			// Token: 0x0400010E RID: 270
			private readonly BlendMode _blendMode;

			// Token: 0x0400010F RID: 271
			private readonly Rectangle _clipRectangle;

			// Token: 0x04000110 RID: 272
			private readonly Matrix4 _modelMatrix;

			// Token: 0x04000111 RID: 273
			private readonly ITexture _texture;

			// Token: 0x04000112 RID: 274
			private readonly Colour _multiplyColour;

			// Token: 0x04000113 RID: 275
			private readonly Colour _additiveColour;

			// Token: 0x04000114 RID: 276
			private readonly bool _shadow;

			// Token: 0x04000115 RID: 277
			private readonly int _filter;

			// Token: 0x04000116 RID: 278
			private readonly double _filterAmount;

			// Token: 0x04000117 RID: 279
			private Vector2[] vertexPositions = new Vector2[4];
		}

		// Token: 0x02000026 RID: 38
		private class MatrixState : IDisposable
		{
			// Token: 0x06000184 RID: 388 RVA: 0x000087EA File Offset: 0x000069EA
			public MatrixState(ObjectRenderer objectRenderer, Matrix4 matrix, Rectangle clipRectangle)
			{
				this._objectRenderer = objectRenderer;
				this._matrix = matrix;
				this._clipRectangle = clipRectangle;
			}

			// Token: 0x06000185 RID: 389 RVA: 0x00008807 File Offset: 0x00006A07
			public void Dispose()
			{
				this._objectRenderer.ModelMatrix = this._matrix;
				this._objectRenderer.ClipRectangle = this._clipRectangle;
			}

			// Token: 0x04000118 RID: 280
			private readonly ObjectRenderer _objectRenderer;

			// Token: 0x04000119 RID: 281
			private readonly Matrix4 _matrix;

			// Token: 0x0400011A RID: 282
			private readonly Rectangle _clipRectangle;
		}
	}
}
