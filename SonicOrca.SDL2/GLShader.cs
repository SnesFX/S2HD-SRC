using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Graphics;

namespace SonicOrca.SDL2
{
	// Token: 0x02000005 RID: 5
	internal class GLShader : IShader, IDisposable
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000026BC File Offset: 0x000008BC
		public int Id
		{
			get
			{
				return this._glId;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000026C4 File Offset: 0x000008C4
		public GLShader(SonicOrca.Graphics.ShaderType type, string sourceCode)
		{
			this._type = GLShader.ShaderTypeConversionTable[(int)type];
			this._sourceCode = sourceCode;
			this._glId = GL.CreateShader(this._type);
			try
			{
				GL.ShaderSource(this._glId, this._sourceCode);
				GL.CompileShader(this._glId);
				int num;
				GL.GetShader(this._glId, ShaderParameter.CompileStatus, out num);
				if (num != 1)
				{
					string shaderInfoLog = GL.GetShaderInfoLog(this._glId);
					throw new SDL2Exception(string.Format("Error compiling shader.\n\n{0}", shaderInfoLog), new InvalidDataException(shaderInfoLog));
				}
			}
			catch
			{
				GL.DeleteShader(this._glId);
				throw;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002778 File Offset: 0x00000978
		public void Dispose()
		{
			GL.DeleteShader(this._glId);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002785 File Offset: 0x00000985
		// Note: this type is marked as 'beforefieldinit'.
		static GLShader()
		{
			OpenTK.Graphics.OpenGL.ShaderType[] array = new OpenTK.Graphics.OpenGL.ShaderType[6];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.500D287DF1D8DAC7618D8DAD9FD18178FF38BEB9).FieldHandle);
			GLShader.ShaderTypeConversionTable = array;
		}

		// Token: 0x04000010 RID: 16
		private static readonly IReadOnlyList<OpenTK.Graphics.OpenGL.ShaderType> ShaderTypeConversionTable;

		// Token: 0x04000011 RID: 17
		private readonly OpenTK.Graphics.OpenGL.ShaderType _type;

		// Token: 0x04000012 RID: 18
		private readonly string _sourceCode;

		// Token: 0x04000013 RID: 19
		private int _glId;
	}
}
