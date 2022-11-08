using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Graphics.LowLevel;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x0200000D RID: 13
	internal class NonLayerRenderer : INonLayerRenderer, IRenderer, IDisposable
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00004333 File Offset: 0x00002533
		public static NonLayerRenderer FromRenderer(Renderer renderer)
		{
			if (!NonLayerRenderer.RendererDictionary.ContainsKey(renderer))
			{
				NonLayerRenderer.RendererDictionary.Add(renderer, new NonLayerRenderer(renderer));
			}
			return NonLayerRenderer.RendererDictionary[renderer];
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004360 File Offset: 0x00002560
		private NonLayerRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			this._shaderProgram = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/nonlayer.shader");
			this._vbo = this._graphicsContext.CreateBuffer();
			this._vao = this._graphicsContext.CreateVertexArray();
			this._vao.DefineAttributes(this._shaderProgram.Program, this._vbo, typeof(NonLayerRenderer.Vertex));
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004407 File Offset: 0x00002607
		public void Dispose()
		{
			this._vbo.Dispose();
			this._vao.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000442A File Offset: 0x0000262A
		public void Render(Rectanglei destination)
		{
			this.Render(new Rectanglei[]
			{
				destination
			});
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004440 File Offset: 0x00002640
		public void Render(IEnumerable<Rectanglei> destinations)
		{
			this._vertices.Clear();
			foreach (Rectanglei r in destinations)
			{
				Vector2[] array = new Vector2[4];
				Renderer.GetVertices(r, array);
				for (int i = 0; i < 4; i++)
				{
					this._vertices.Add(new NonLayerRenderer.Vertex
					{
						position = array[i].ToVec2()
					});
				}
			}
			this._vbo.SetData(this._vertices.ToArray());
			Matrix4 value = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			this._renderer.ActivateRenderer(this);
			this._graphicsContext.BlendMode = BlendMode.Alpha;
			IShaderProgram program = this._shaderProgram.Program;
			program.Activate();
			program.SetUniform("ProjectionMatrix", value);
			this._vao.Render(PrimitiveType.Quads, 0, this._vertices.Count);
		}

		// Token: 0x04000059 RID: 89
		private static readonly Dictionary<Renderer, NonLayerRenderer> RendererDictionary = new Dictionary<Renderer, NonLayerRenderer>();

		// Token: 0x0400005A RID: 90
		private readonly Renderer _renderer;

		// Token: 0x0400005B RID: 91
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x0400005C RID: 92
		private readonly IBuffer _vbo;

		// Token: 0x0400005D RID: 93
		private readonly IVertexArray _vao;

		// Token: 0x0400005E RID: 94
		private readonly List<NonLayerRenderer.Vertex> _vertices = new List<NonLayerRenderer.Vertex>();

		// Token: 0x0400005F RID: 95
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x04000060 RID: 96
		private ManagedShaderProgram _shaderProgram;

		// Token: 0x02000023 RID: 35
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Vertex
		{
			// Token: 0x04000108 RID: 264
			[VertexAttribute("VertexPosition")]
			public vec2 position;
		}
	}
}
