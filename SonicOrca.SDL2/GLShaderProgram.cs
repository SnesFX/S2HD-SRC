using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.SDL2
{
	// Token: 0x0200000E RID: 14
	internal class GLShaderProgram : IShaderProgram, IDisposable
	{
		// Token: 0x06000099 RID: 153 RVA: 0x00004120 File Offset: 0x00002320
		public GLShaderProgram(GLGraphicsContext context, IEnumerable<GLShader> shaders)
		{
			this._context = context;
			this._glId = this.CreateShaderProgram(shaders);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004147 File Offset: 0x00002347
		public virtual void Dispose()
		{
			GL.DeleteProgram(this._glId);
			this._context.ShaderPrograms.Remove(this);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004168 File Offset: 0x00002368
		private int CreateShaderProgram(IEnumerable<GLShader> shaders)
		{
			int num = GL.CreateProgram();
			try
			{
				foreach (GLShader glshader in shaders)
				{
					GL.AttachShader(num, glshader.Id);
				}
				GL.LinkProgram(num);
				int num2;
				GL.GetProgram(num, ProgramParameter.LinkStatus, out num2);
				if (num2 != 1)
				{
					throw new Exception(GL.GetProgramInfoLog(num));
				}
				this._context.ShaderPrograms.Add(this);
			}
			catch
			{
				GL.DeleteProgram(num);
				throw;
			}
			return num;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004208 File Offset: 0x00002408
		public void Activate()
		{
			GL.UseProgram(this._glId);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004215 File Offset: 0x00002415
		public int GetAttributeLocation(string name)
		{
			return GL.GetAttribLocation(this._glId, name);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004224 File Offset: 0x00002424
		public int GetUniformLocation(string name)
		{
			int result;
			if (!this._uniformLocations.TryGetValue(name, out result))
			{
				result = (this._uniformLocations[name] = GL.GetUniformLocation(this._glId, name));
			}
			return result;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004260 File Offset: 0x00002460
		public void SetUniform(string name, int value)
		{
			int uniformLocation = this.GetUniformLocation(name);
			if (uniformLocation >= 0)
			{
				GL.Uniform1(uniformLocation, value);
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004280 File Offset: 0x00002480
		public void SetUniform(string name, float value)
		{
			int uniformLocation = this.GetUniformLocation(name);
			if (uniformLocation >= 0)
			{
				GL.Uniform1(uniformLocation, value);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000042A0 File Offset: 0x000024A0
		public void SetUniform(string name, double value)
		{
			int uniformLocation = this.GetUniformLocation(name);
			if (uniformLocation >= 0)
			{
				GL.Uniform1(uniformLocation, (float)value);
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000042C4 File Offset: 0x000024C4
		public void SetUniform(string name, Vector2 value)
		{
			int uniformLocation = this.GetUniformLocation(name);
			if (uniformLocation >= 0)
			{
				GL.Uniform2(uniformLocation, (float)value.X, (float)value.Y);
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000042F4 File Offset: 0x000024F4
		public void SetUniform(string name, Vector3 value)
		{
			int uniformLocation = this.GetUniformLocation(name);
			if (uniformLocation >= 0)
			{
				GL.Uniform3(uniformLocation, (float)value.X, (float)value.Y, (float)value.Z);
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000432C File Offset: 0x0000252C
		public void SetUniform(string name, Vector4 value)
		{
			int uniformLocation = this.GetUniformLocation(name);
			if (uniformLocation >= 0)
			{
				GL.Uniform4(uniformLocation, (float)value.X, (float)value.Y, (float)value.Z, (float)value.W);
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000436C File Offset: 0x0000256C
		public void SetUniform(string name, Matrix4 value)
		{
			int uniformLocation = this.GetUniformLocation(name);
			if (uniformLocation >= 0)
			{
				GL.UniformMatrix4(uniformLocation, 1, false, new float[]
				{
					(float)value.M11,
					(float)value.M21,
					(float)value.M31,
					(float)value.M41,
					(float)value.M12,
					(float)value.M22,
					(float)value.M32,
					(float)value.M42,
					(float)value.M13,
					(float)value.M23,
					(float)value.M33,
					(float)value.M43,
					(float)value.M14,
					(float)value.M24,
					(float)value.M34,
					(float)value.M44
				});
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004440 File Offset: 0x00002640
		public void SetUniform(string name, Colour value)
		{
			int uniformLocation = this.GetUniformLocation(name);
			if (uniformLocation >= 0)
			{
				GL.Uniform4(uniformLocation, (float)value.Red / 255f, (float)value.Green / 255f, (float)value.Blue / 255f, (float)value.Alpha / 255f);
			}
		}

		// Token: 0x04000045 RID: 69
		private readonly GLGraphicsContext _context;

		// Token: 0x04000046 RID: 70
		private readonly int _glId;

		// Token: 0x04000047 RID: 71
		private readonly Dictionary<string, int> _uniformLocations = new Dictionary<string, int>();
	}
}
