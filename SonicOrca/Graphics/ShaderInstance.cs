using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics
{
	// Token: 0x020000CB RID: 203
	public class ShaderInstance : IDisposable
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x0001D501 File Offset: 0x0001B701
		public IGraphicsContext GraphicsContext
		{
			get
			{
				return this._graphicsContext;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x0001D509 File Offset: 0x0001B709
		public IShaderProgram ShaderProgram
		{
			get
			{
				return this._shaderProgram.Program;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0001D516 File Offset: 0x0001B716
		public VertexBuffer VertexBuffer
		{
			get
			{
				return this._vertexBuffer;
			}
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0001D51E File Offset: 0x0001B71E
		public ShaderInstance(IGraphicsContext graphicsContext, string vertex, string fragment, IEnumerable<int> vertexCounts)
		{
			this._graphicsContext = graphicsContext;
			this._shaderProgram = new ManagedShaderProgram(graphicsContext, vertex, fragment);
			this._vertexBuffer = this._graphicsContext.CreateVertexBuffer(vertexCounts);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0001D54E File Offset: 0x0001B74E
		public ShaderInstance(IGraphicsContext graphicsContext, string orcaGLSL, IEnumerable<int> vertexCounts)
		{
			this._graphicsContext = graphicsContext;
			this._shaderProgram = OrcaShader.Create(graphicsContext, orcaGLSL);
			this._vertexBuffer = this._graphicsContext.CreateVertexBuffer(vertexCounts);
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0001D57C File Offset: 0x0001B77C
		public void Dispose()
		{
			this._vertexBuffer.Dispose();
			this._shaderProgram.Dispose();
		}

		// Token: 0x04000487 RID: 1159
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x04000488 RID: 1160
		private readonly ManagedShaderProgram _shaderProgram;

		// Token: 0x04000489 RID: 1161
		private readonly VertexBuffer _vertexBuffer;
	}
}
