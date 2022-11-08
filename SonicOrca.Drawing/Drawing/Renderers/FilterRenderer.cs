using System;
using System.Collections.Generic;
using System.IO;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x0200000A RID: 10
	internal class FilterRenderer : IRenderer, IDisposable
	{
		// Token: 0x0600007B RID: 123 RVA: 0x0000390C File Offset: 0x00001B0C
		public static FilterRenderer FromRenderer(Renderer renderer)
		{
			if (!FilterRenderer.RendererDictionary.ContainsKey(renderer))
			{
				FilterRenderer.RendererDictionary.Add(renderer, new FilterRenderer(renderer));
			}
			return FilterRenderer.RendererDictionary[renderer];
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003938 File Offset: 0x00001B38
		private FilterRenderer(Renderer renderer)
		{
			this._renderer = renderer;
			renderer.RegisterRenderer(this);
			this._graphicsContext = renderer.Window.GraphicsContext;
			string sourceCode;
			string sourceCode2;
			OrcaShader.Parse(File.ReadAllText("shaders/greyscale_filter.shader"), out sourceCode, out sourceCode2);
			this._vertexShader = this._graphicsContext.CreateShader(ShaderType.Vertex, sourceCode);
			this._fragmentShader = this._graphicsContext.CreateShader(ShaderType.Fragment, sourceCode2);
			this._shaderProgram = this._graphicsContext.CreateShaderProgram(new IShader[]
			{
				this._vertexShader,
				this._fragmentShader
			});
			this._vertexBuffer = this._graphicsContext.CreateVertexBuffer(new int[]
			{
				2,
				2
			});
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003A03 File Offset: 0x00001C03
		public void Dispose()
		{
			this._vertexBuffer.Dispose();
			this._vertexShader.Dispose();
			this._fragmentShader.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002C05 File Offset: 0x00000E05
		public void Deactivate()
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003A31 File Offset: 0x00001C31
		public void Render(ITexture texture, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			this.Render(texture, new Rectanglei(0, 0, texture.Width, texture.Height), destination, flipX, flipY);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003A54 File Offset: 0x00001C54
		public void Render(ITexture texture, Rectanglei source, Rectanglei destination, bool flipX = false, bool flipY = false)
		{
			Renderer.GetVertices(destination, this.vertexPositions);
			Renderer.GetTextureMappings(texture, source, this.vertexUVs, flipX, flipY);
			this._vertexBuffer.Begin();
			for (int i = 0; i < 4; i++)
			{
				this._vertexBuffer.AddValue(0, this.vertexPositions[i]);
				this._vertexBuffer.AddValue(0, this.vertexUVs[i]);
			}
			this._vertexBuffer.End();
			Matrix4 value = this._renderer.Window.GraphicsContext.CurrentFramebuffer.CreateOrthographic();
			this._renderer.ActivateRenderer(this);
			this._graphicsContext.BlendMode = BlendMode.Alpha;
			this._graphicsContext.SetTexture(texture);
			this._shaderProgram.Activate();
			this._shaderProgram.SetUniform("ProjectionMatrix", value);
			this._shaderProgram.SetUniform("InputTexture", 0);
			this._graphicsContext.BlendMode = BlendMode.Opaque;
			this._vertexBuffer.Render(PrimitiveType.Quads);
		}

		// Token: 0x04000038 RID: 56
		private static readonly Dictionary<Renderer, FilterRenderer> RendererDictionary = new Dictionary<Renderer, FilterRenderer>();

		// Token: 0x04000039 RID: 57
		private readonly Renderer _renderer;

		// Token: 0x0400003A RID: 58
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x0400003B RID: 59
		private IShader _vertexShader;

		// Token: 0x0400003C RID: 60
		private IShader _fragmentShader;

		// Token: 0x0400003D RID: 61
		private Vector2[] vertexPositions = new Vector2[4];

		// Token: 0x0400003E RID: 62
		private Vector2[] vertexUVs = new Vector2[4];

		// Token: 0x0400003F RID: 63
		private IShaderProgram _shaderProgram;

		// Token: 0x04000040 RID: 64
		private VertexBuffer _vertexBuffer;
	}
}
