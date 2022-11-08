using System;

namespace SonicOrca.Graphics
{
	// Token: 0x020000C7 RID: 199
	public class ManagedShaderProgram : IDisposable
	{
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x0001D124 File Offset: 0x0001B324
		public IShader Vertex
		{
			get
			{
				return this._vertexShader;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x0001D12C File Offset: 0x0001B32C
		public IShader Fragment
		{
			get
			{
				return this._fragmentShader;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x0001D134 File Offset: 0x0001B334
		public IShaderProgram Program
		{
			get
			{
				return this._shaderProgram;
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0001D13C File Offset: 0x0001B33C
		public ManagedShaderProgram(IGraphicsContext context, string vertexSourceCode, string fragmentSourceCode)
		{
			this._vertexShader = context.CreateShader(ShaderType.Vertex, vertexSourceCode);
			this._fragmentShader = context.CreateShader(ShaderType.Fragment, fragmentSourceCode);
			this._shaderProgram = context.CreateShaderProgram(new IShader[]
			{
				this._vertexShader,
				this._fragmentShader
			});
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0001D18F File Offset: 0x0001B38F
		public void Dispose()
		{
			this._shaderProgram.Dispose();
			this._vertexShader.Dispose();
			this._fragmentShader.Dispose();
		}

		// Token: 0x04000475 RID: 1141
		private readonly IShader _vertexShader;

		// Token: 0x04000476 RID: 1142
		private readonly IShader _fragmentShader;

		// Token: 0x04000477 RID: 1143
		private readonly IShaderProgram _shaderProgram;
	}
}
