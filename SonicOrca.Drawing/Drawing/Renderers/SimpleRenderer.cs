using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000012 RID: 18
	public class SimpleRenderer : I2dRenderer, IDisposable, IRenderer
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00004FF1 File Offset: 0x000031F1
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00004FF9 File Offset: 0x000031F9
		public Matrix4 ModelMatrix
		{
			get
			{
				return this._modelMatrix;
			}
			set
			{
				if (this._modelMatrix != value)
				{
					this.PushBatchOperation();
					this._modelMatrix = value;
				}
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00005016 File Offset: 0x00003216
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x0000501E File Offset: 0x0000321E
		public BlendMode BlendMode
		{
			get
			{
				return this._blendMode;
			}
			set
			{
				if (this._blendMode != value)
				{
					this.PushBatchOperation();
					this._blendMode = value;
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00005036 File Offset: 0x00003236
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x0000503E File Offset: 0x0000323E
		public Rectangle ClipRectangle
		{
			get
			{
				return this._clipRectangle;
			}
			set
			{
				if (this._clipRectangle != value)
				{
					this.PushBatchOperation();
					this._clipRectangle = value;
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000505B File Offset: 0x0000325B
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00005063 File Offset: 0x00003263
		public Colour Colour
		{
			get
			{
				return this._colour;
			}
			set
			{
				if (this._colour != value)
				{
					this.PushBatchOperation();
					this._colour = value;
				}
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00005080 File Offset: 0x00003280
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00005088 File Offset: 0x00003288
		public Colour AdditiveColour
		{
			get
			{
				return this._additiveColour;
			}
			set
			{
				if (this._additiveColour != value)
				{
					this.PushBatchOperation();
					this._additiveColour = value;
				}
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000DA RID: 218 RVA: 0x000050A5 File Offset: 0x000032A5
		// (set) Token: 0x060000DB RID: 219 RVA: 0x000050C4 File Offset: 0x000032C4
		public ITexture Texture
		{
			get
			{
				if (this._textures == null)
				{
					return null;
				}
				if (this._textures.Length == 0)
				{
					return null;
				}
				return this._textures[0];
			}
			set
			{
				if (value == null)
				{
					if (this._textures.Length != 0)
					{
						this.PushBatchOperation();
						this._textures = new ITexture[0];
						return;
					}
				}
				else if (this._textures.Length == 1)
				{
					if (this._textures[0] == value)
					{
						this.PushBatchOperation();
						this._textures[0] = value;
						return;
					}
				}
				else
				{
					this.PushBatchOperation();
					this._textures = new ITexture[]
					{
						value
					};
				}
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000DC RID: 220 RVA: 0x0000512C File Offset: 0x0000332C
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00005134 File Offset: 0x00003334
		public IEnumerable<ITexture> Textures
		{
			get
			{
				return this._textures;
			}
			set
			{
				if (value == null)
				{
					this.Texture = null;
					return;
				}
				ITexture[] array = value.ToArray<ITexture>();
				if (this._textures.Length != array.Length)
				{
					this.PushBatchOperation();
					this._textures = array;
					return;
				}
				bool flag = false;
				for (int i = 0; i < this._textures.Length; i++)
				{
					if (this._textures[i] != array[i])
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					this.PushBatchOperation();
					this._textures = array;
				}
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000051A4 File Offset: 0x000033A4
		public static SimpleRenderer FromRenderer(Renderer renderer)
		{
			if (!SimpleRenderer.RendererDictionary.ContainsKey(renderer))
			{
				SimpleRenderer.RendererDictionary.Add(renderer, new SimpleRenderer(renderer));
			}
			return SimpleRenderer.RendererDictionary[renderer];
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000051D0 File Offset: 0x000033D0
		private SimpleRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/simple.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(SimpleRenderer.Vertex));
			this._modelMatrix = Matrix4.Identity;
			this.BlendMode = BlendMode.Alpha;
			this.ClipRectangle = new Rectangle(0.0, 0.0, (double)this._renderer.Window.ClientSize.X, (double)this._renderer.Window.ClientSize.Y);
			this.Colour = Colours.White;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005310 File Offset: 0x00003510
		public void Dispose()
		{
			this._vbo.Dispose();
			this._vao.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00005333 File Offset: 0x00003533
		public void Deactivate()
		{
			this.Render();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000533C File Offset: 0x0000353C
		private void Render()
		{
			if (this._batchedVertexCount == 0)
			{
				return;
			}
			this.PushBatchOperation();
			this._vbo.SetData<SimpleRenderer.Vertex>(this._verticesData, 0, this.numVerticesData);
			this._projectionMatrix = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			for (int i = 0; i < this.numBatchOperations; i++)
			{
				this._batchOperations[i].Render();
			}
			this.numBatchOperations = 0;
			this._batchedVertexIndex = 0;
			this._batchedVertexCount = 0;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000053C4 File Offset: 0x000035C4
		private void PushBatchOperation()
		{
			if (this._batchedVertexIndex == this._batchedVertexCount)
			{
				return;
			}
			if (this.numBatchOperations >= this._batchOperations.Length)
			{
				SimpleRenderer.BatchOperation[] array = new SimpleRenderer.BatchOperation[this._batchOperations.Length * 2];
				for (int i = 0; i < this._batchOperations.Length; i++)
				{
					array[i] = this._batchOperations[i];
				}
				this._batchOperations = array;
			}
			if (this._batchOperations[this.numBatchOperations] == null)
			{
				this._batchOperations[this.numBatchOperations] = new SimpleRenderer.BatchOperation(this, this._primitiveType, this._batchedVertexIndex, this._batchedVertexCount - this._batchedVertexIndex, this._blendMode, this._clipRectangle, this._textures, this._modelMatrix, this._additiveColour);
			}
			else
			{
				this._batchOperations[this.numBatchOperations]._simpleRenderer = this;
				this._batchOperations[this.numBatchOperations]._primitiveType = this._primitiveType;
				this._batchOperations[this.numBatchOperations]._vertexBufferIndex = this._batchedVertexIndex;
				this._batchOperations[this.numBatchOperations]._vertexCount = this._batchedVertexCount - this._batchedVertexIndex;
				this._batchOperations[this.numBatchOperations]._blendMode = this._blendMode;
				this._batchOperations[this.numBatchOperations]._clipRectangle = this._clipRectangle;
				this._batchOperations[this.numBatchOperations]._textures = this._textures.ToArray<ITexture>();
				this._batchOperations[this.numBatchOperations]._modelMatrix = this._modelMatrix;
				this._batchOperations[this.numBatchOperations]._additiveColour = this._additiveColour;
			}
			this.numBatchOperations++;
			this._batchedVertexIndex = this._batchedVertexCount;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000557C File Offset: 0x0000377C
		private void PushVertices(IReadOnlyList<Vector2> positions)
		{
			Colour[] array = new Colour[positions.Count];
			Vector2[] textureMappings = new Vector2[positions.Count];
			for (int i = 0; i < positions.Count; i++)
			{
				array[i] = this.Colour;
			}
			this.PushVertices(positions, array, textureMappings);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000055C8 File Offset: 0x000037C8
		public void PushVertices(IReadOnlyList<Vector2> positions, IReadOnlyList<Colour> colours, IReadOnlyList<Vector2> textureMappings)
		{
			this._renderer.ActivateRenderer(this);
			if (this._batchedVertexCount == 0)
			{
				this._batchedVertexIndex = 0;
				this.numVerticesData = 0;
			}
			for (int i = 0; i < positions.Count; i++)
			{
				this._verticesData[this.numVerticesData].position.x = (float)positions[i].X;
				this._verticesData[this.numVerticesData].position.y = (float)positions[i].Y;
				this._verticesData[this.numVerticesData].colour.r = (float)colours[i].Red / 255f;
				this._verticesData[this.numVerticesData].colour.g = (float)colours[i].Green / 255f;
				this._verticesData[this.numVerticesData].colour.b = (float)colours[i].Blue / 255f;
				this._verticesData[this.numVerticesData].colour.a = (float)colours[i].Alpha / 255f;
				this._verticesData[this.numVerticesData].texcoords.s = (float)textureMappings[i].X;
				this._verticesData[this.numVerticesData].texcoords.t = (float)textureMappings[i].Y;
				this.numVerticesData++;
				if (this.numVerticesData >= this._verticesData.Length)
				{
					SimpleRenderer.Vertex[] array = new SimpleRenderer.Vertex[this._verticesData.Length * 2];
					Array.Copy(this._verticesData, array, this._verticesData.Length);
					this._verticesData = array;
				}
			}
			this._batchedVertexCount += positions.Count;
			if (this._batchedVertexCount > 1024)
			{
				this.Render();
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000057ED File Offset: 0x000039ED
		public IDisposable BeginMatixState()
		{
			return new SimpleRenderer.MatrixState(this, this._modelMatrix, this._clipRectangle);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00005804 File Offset: 0x00003A04
		public void SetVertices(Rectangle rectangle)
		{
			this._vertices = new Vector2[]
			{
				new Vector2(rectangle.Left, rectangle.Top),
				new Vector2(rectangle.Left, rectangle.Bottom),
				new Vector2(rectangle.Right, rectangle.Bottom),
				new Vector2(rectangle.Right, rectangle.Top)
			};
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00005888 File Offset: 0x00003A88
		public void SetVerticesFromTextureSize(Vector2 position)
		{
			ITexture texture = this.Texture;
			if (texture == null)
			{
				throw new InvalidOperationException("Texture not set");
			}
			this.SetVertices(new Rectangle(position.X, position.Y, (double)texture.Width, (double)texture.Height));
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000058D1 File Offset: 0x00003AD1
		public void RenderTexture(ITexture texture, Vector2 destination, bool flipX = false, bool flipY = false)
		{
			this.RenderTexture(texture, new Rectangle(0.0, 0.0, (double)texture.Width, (double)texture.Height), destination, flipX, flipY);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00005903 File Offset: 0x00003B03
		public void RenderTexture(ITexture texture, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			this.RenderTexture(texture, new Rectangle(0.0, 0.0, (double)texture.Width, (double)texture.Height), destination, flipX, flipY);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005938 File Offset: 0x00003B38
		public void RenderTexture(ITexture texture, Rectangle source, Vector2 destination, bool flipX = false, bool flipY = false)
		{
			this.RenderTexture(texture, source, new Rectangle(destination.X - (double)((int)((double)texture.Width / 2.0)), destination.Y - (double)((int)((double)texture.Height / 2.0)), (double)texture.Width, (double)texture.Height), flipX, flipY);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000599C File Offset: 0x00003B9C
		public void RenderTexture(IEnumerable<ITexture> textures, Vector2 destination)
		{
			ITexture texture = textures.First<ITexture>();
			this.RenderTexture(textures, new Rectangle(0.0, 0.0, (double)texture.Width, (double)texture.Height), destination);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000059E0 File Offset: 0x00003BE0
		public void RenderTexture(IEnumerable<ITexture> textures, Rectangle destination)
		{
			ITexture texture = textures.First<ITexture>();
			this.RenderTexture(textures, new Rectangle(0.0, 0.0, (double)texture.Width, (double)texture.Height), destination, false, false);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005A24 File Offset: 0x00003C24
		public void RenderTexture(IEnumerable<ITexture> textures, Rectangle source, Vector2 destination)
		{
			ITexture texture = textures.First<ITexture>();
			this.RenderTexture(textures, source, new Rectangle(destination.X - (double)texture.Width / 2.0, destination.Y - (double)texture.Height / 2.0, (double)texture.Width, (double)texture.Height), false, false);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00005A87 File Offset: 0x00003C87
		public void RenderTexture(ITexture texture, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			this.RenderTexture(new ITexture[]
			{
				texture
			}, source, destination, flipX, flipY);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005AA0 File Offset: 0x00003CA0
		public void RenderTexture(IEnumerable<ITexture> textures, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			if (textures.Count<ITexture>() == 0)
			{
				throw new ArgumentException("No textures specified", "textures");
			}
			Renderer.GetVertices(destination, this.vertexPositions);
			ITexture texture = textures.First<ITexture>();
			if (this._modelMatrix.M11 != 1.0 || this._modelMatrix.M22 != 1.0)
			{
				Renderer.GetTextureMappingsHalfIn(texture, source, ref this.vertexUVs, flipX, flipY);
			}
			else
			{
				Renderer.GetTextureMappings(texture, source, this.vertexUVs, flipX, flipY);
			}
			this.Textures = textures;
			this.PushVertices(this.vertexPositions, new Colour[]
			{
				this.Colour,
				this.Colour,
				this.Colour,
				this.Colour
			}, this.vertexUVs);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005B88 File Offset: 0x00003D88
		public void RenderQuad(Colour colour, Rectangle rectangle)
		{
			this.Colour = colour;
			this.Texture = null;
			this.PushVertices(new Vector2[]
			{
				new Vector2(rectangle.Left, rectangle.Top),
				new Vector2(rectangle.Left, rectangle.Bottom),
				new Vector2(rectangle.Right, rectangle.Bottom),
				new Vector2(rectangle.Right, rectangle.Top)
			});
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00005C17 File Offset: 0x00003E17
		public void RenderQuad(Colour colour, Vector2[] points)
		{
			this.Colour = colour;
			this.Texture = null;
			this.PushVertices(points);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005C30 File Offset: 0x00003E30
		public void RenderEllipse(Colour colour, Vector2 centre, double innerRadius, double outerRadius, int sectors)
		{
			this.Colour = colour;
			this.Texture = null;
			Vector2[] array = new Vector2[sectors * 4];
			int num = 0;
			for (int i = 0; i < sectors; i++)
			{
				double num2 = (double)i * 6.283185307179586 / (double)sectors;
				double num3 = (double)(i + 1) * 6.283185307179586 / (double)sectors;
				array[num++] = new Vector2(Math.Sin(num2) * outerRadius, -Math.Cos(num2) * outerRadius) + centre;
				array[num++] = new Vector2(Math.Sin(num2) * innerRadius, -Math.Cos(num2) * innerRadius) + centre;
				array[num++] = new Vector2(Math.Sin(num3) * innerRadius, -Math.Cos(num3) * innerRadius) + centre;
				array[num++] = new Vector2(Math.Sin(num3) * outerRadius, -Math.Cos(num3) * outerRadius) + centre;
			}
			this.PushVertices(array);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005D3C File Offset: 0x00003F3C
		public void RenderRectangle(Colour colour, Rectangle rect, double thickness)
		{
			double num = Math.Min(thickness, rect.Width);
			double num2 = Math.Min(thickness, rect.Height);
			this.RenderQuad(colour, new Rectangle(rect.X, rect.Y, num, rect.Height));
			this.RenderQuad(colour, new Rectangle(rect.Right - num, rect.Y, num, rect.Height));
			this.RenderQuad(colour, new Rectangle(rect.X + num, rect.Y, rect.Width - num * 2.0, num2));
			this.RenderQuad(colour, new Rectangle(rect.X + num, rect.Bottom - num2, rect.Width - num * 2.0, num2));
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005E10 File Offset: 0x00004010
		public void RenderLine(Colour colour, Vector2 a, Vector2 b, double thickness)
		{
			this.Colour = colour;
			this.Texture = null;
			a += new Vector2(0.5, 0.5);
			b += new Vector2(0.5, 0.5);
			thickness /= 2.0;
			double num = Math.Atan2(a.Y - b.Y, a.X - b.X) + 1.5707963267948966;
			double num2 = Math.Atan2(a.Y - b.Y, a.X - b.X) - 1.5707963267948966;
			this.PushVertices(new Vector2[]
			{
				a + new Vector2(Math.Cos(num) * thickness, Math.Sin(num) * thickness),
				a + new Vector2(Math.Cos(num2) * thickness, Math.Sin(num2) * thickness),
				b + new Vector2(Math.Cos(num) * thickness, Math.Sin(num) * thickness),
				b + new Vector2(Math.Cos(num2) * thickness, Math.Sin(num2) * thickness)
			});
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00005F6F File Offset: 0x0000416F
		public Rectangle RenderText(TextRenderInfo textRenderInfo)
		{
			return TextRenderingHelpers.RenderWith2d(this, textRenderInfo);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005F78 File Offset: 0x00004178
		public Rectangle MeasureText(TextRenderInfo textRenderInfo)
		{
			return TextRenderingHelpers.MeasureWith2d(this, textRenderInfo);
		}

		// Token: 0x04000081 RID: 129
		private static readonly Dictionary<Renderer, SimpleRenderer> RendererDictionary = new Dictionary<Renderer, SimpleRenderer>();

		// Token: 0x04000082 RID: 130
		private readonly Renderer _renderer;

		// Token: 0x04000083 RID: 131
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000084 RID: 132
		private readonly IBuffer _vbo;

		// Token: 0x04000085 RID: 133
		private readonly IVertexArray _vao;

		// Token: 0x04000086 RID: 134
		private SimpleRenderer.Vertex[] _verticesData = new SimpleRenderer.Vertex[20];

		// Token: 0x04000087 RID: 135
		private int numVerticesData;

		// Token: 0x04000088 RID: 136
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x04000089 RID: 137
		private Matrix4 _projectionMatrix;

		// Token: 0x0400008A RID: 138
		private Matrix4 _modelMatrix;

		// Token: 0x0400008B RID: 139
		private PrimitiveType _primitiveType = PrimitiveType.Quads;

		// Token: 0x0400008C RID: 140
		private ITexture[] _textures = new ITexture[0];

		// Token: 0x0400008D RID: 141
		private Vector2[] _vertices;

		// Token: 0x0400008E RID: 142
		private BlendMode _blendMode;

		// Token: 0x0400008F RID: 143
		private Rectangle _clipRectangle;

		// Token: 0x04000090 RID: 144
		private Colour _colour;

		// Token: 0x04000091 RID: 145
		private Colour _additiveColour;

		// Token: 0x04000092 RID: 146
		private SimpleRenderer.BatchOperation[] _batchOperations = new SimpleRenderer.BatchOperation[4];

		// Token: 0x04000093 RID: 147
		private int numBatchOperations;

		// Token: 0x04000094 RID: 148
		private int _batchedVertexIndex;

		// Token: 0x04000095 RID: 149
		private int _batchedVertexCount;

		// Token: 0x04000096 RID: 150
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x04000097 RID: 151
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x02000027 RID: 39
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x0400011B RID: 283
			[VertexAttribute("VertexPosition")]
			public vec2 position;

			// Token: 0x0400011C RID: 284
			[VertexAttribute("VertexColour")]
			public vec4 colour;

			// Token: 0x0400011D RID: 285
			[VertexAttribute("VertexTextureMapping")]
			public vec2 texcoords;
		}

		// Token: 0x02000028 RID: 40
		private class BatchOperation
		{
			// Token: 0x06000186 RID: 390 RVA: 0x0000882C File Offset: 0x00006A2C
			public BatchOperation(SimpleRenderer simpleRenderer, PrimitiveType primitiveType, int vertexBufferIndex, int vertexCount, BlendMode blendMode, Rectangle clipRectangle, IEnumerable<ITexture> textures, Matrix4 modelMatrix, Colour additiveColour)
			{
				this._simpleRenderer = simpleRenderer;
				this._primitiveType = primitiveType;
				this._vertexBufferIndex = vertexBufferIndex;
				this._vertexCount = vertexCount;
				this._blendMode = blendMode;
				this._clipRectangle = clipRectangle;
				this._textures = textures.ToArray<ITexture>();
				this._modelMatrix = modelMatrix;
				this._additiveColour = additiveColour;
			}

			// Token: 0x06000187 RID: 391 RVA: 0x00008898 File Offset: 0x00006A98
			public void Render()
			{
				IGraphicsContext graphicsContext = this._simpleRenderer._graphicsContext;
				IShaderProgram program = this._simpleRenderer._shaderProgram.Program;
				graphicsContext.BlendMode = this._blendMode;
				graphicsContext.SetTextures(this._textures);
				program.Activate();
				program.SetUniform("ModelViewMatrix", this._modelMatrix);
				program.SetUniform("ProjectionMatrix", this._simpleRenderer._projectionMatrix);
				program.SetUniform("InputTextureCount", this._textures.Count);
				for (int i = 0; i < this._textures.Count; i++)
				{
					program.SetUniform("InputTexture[" + i + "]", i);
				}
				program.SetUniform("InputClipRectangle", new Vector4(this._clipRectangle.X, this._clipRectangle.Y, this._clipRectangle.Right, this._clipRectangle.Bottom));
				program.SetUniform("InputAdditiveColour", this._additiveColour);
				this._simpleRenderer._vao.Render(this._primitiveType, this._vertexBufferIndex, this._vertexCount);
			}

			// Token: 0x0400011E RID: 286
			public SimpleRenderer _simpleRenderer;

			// Token: 0x0400011F RID: 287
			public PrimitiveType _primitiveType;

			// Token: 0x04000120 RID: 288
			public int _vertexBufferIndex;

			// Token: 0x04000121 RID: 289
			public int _vertexCount;

			// Token: 0x04000122 RID: 290
			public BlendMode _blendMode;

			// Token: 0x04000123 RID: 291
			public Rectangle _clipRectangle;

			// Token: 0x04000124 RID: 292
			public IReadOnlyList<ITexture> _textures;

			// Token: 0x04000125 RID: 293
			public Matrix4 _modelMatrix;

			// Token: 0x04000126 RID: 294
			public Colour _additiveColour;

			// Token: 0x04000127 RID: 295
			private Vector2[] vertexPositions = new Vector2[4];
		}

		// Token: 0x02000029 RID: 41
		private class MatrixState : IDisposable
		{
			// Token: 0x06000188 RID: 392 RVA: 0x000089BC File Offset: 0x00006BBC
			public MatrixState(SimpleRenderer simpleRenderer, Matrix4 matrix, Rectangle clipRectangle)
			{
				this._simpleRenderer = simpleRenderer;
				this._matrix = matrix;
				this._clipRectangle = clipRectangle;
			}

			// Token: 0x06000189 RID: 393 RVA: 0x000089D9 File Offset: 0x00006BD9
			public void Dispose()
			{
				this._simpleRenderer.ModelMatrix = this._matrix;
				this._simpleRenderer.ClipRectangle = this._clipRectangle;
			}

			// Token: 0x04000128 RID: 296
			private readonly SimpleRenderer _simpleRenderer;

			// Token: 0x04000129 RID: 297
			private readonly Matrix4 _matrix;

			// Token: 0x0400012A RID: 298
			private readonly Rectangle _clipRectangle;
		}
	}
}
