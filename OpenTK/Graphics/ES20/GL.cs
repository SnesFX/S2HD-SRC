using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000504 RID: 1284
	public sealed class GL : GraphicsBindingsBase
	{
		// Token: 0x060035F1 RID: 13809 RVA: 0x0008DC28 File Offset: 0x0008BE28
		public GL()
		{
			this._EntryPointsInstance = GL.EntryPoints;
			this._EntryPointNamesInstance = GL.EntryPointNames;
			this._EntryPointNameOffsetsInstance = GL.EntryPointNameOffsets;
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060035F2 RID: 13810 RVA: 0x0008DC54 File Offset: 0x0008BE54
		protected override object SyncRoot
		{
			get
			{
				return GL.sync_root;
			}
		}

		// Token: 0x060035F3 RID: 13811 RVA: 0x0008DC5C File Offset: 0x0008BE5C
		public static void ClearColor(Color color)
		{
			GL.ClearColor((float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
		}

		// Token: 0x060035F4 RID: 13812 RVA: 0x0008DC9C File Offset: 0x0008BE9C
		public static void ClearColor(Color4 color)
		{
			GL.ClearColor(color.R, color.G, color.B, color.A);
		}

		// Token: 0x060035F5 RID: 13813 RVA: 0x0008DCC0 File Offset: 0x0008BEC0
		public static void BlendColor(Color color)
		{
			GL.BlendColor((float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
		}

		// Token: 0x060035F6 RID: 13814 RVA: 0x0008DD00 File Offset: 0x0008BF00
		public static void BlendColor(Color4 color)
		{
			GL.BlendColor(color.R, color.G, color.B, color.A);
		}

		// Token: 0x060035F7 RID: 13815 RVA: 0x0008DD24 File Offset: 0x0008BF24
		[CLSCompliant(false)]
		public static void Uniform2(int location, ref Vector2 vector)
		{
			GL.Uniform2(location, vector.X, vector.Y);
		}

		// Token: 0x060035F8 RID: 13816 RVA: 0x0008DD38 File Offset: 0x0008BF38
		[CLSCompliant(false)]
		public static void Uniform3(int location, ref Vector3 vector)
		{
			GL.Uniform3(location, vector.X, vector.Y, vector.Z);
		}

		// Token: 0x060035F9 RID: 13817 RVA: 0x0008DD54 File Offset: 0x0008BF54
		[CLSCompliant(false)]
		public static void Uniform4(int location, ref Vector4 vector)
		{
			GL.Uniform4(location, vector.X, vector.Y, vector.Z, vector.W);
		}

		// Token: 0x060035FA RID: 13818 RVA: 0x0008DD74 File Offset: 0x0008BF74
		public static void Uniform2(int location, Vector2 vector)
		{
			GL.Uniform2(location, vector.X, vector.Y);
		}

		// Token: 0x060035FB RID: 13819 RVA: 0x0008DD8C File Offset: 0x0008BF8C
		public static void Uniform3(int location, Vector3 vector)
		{
			GL.Uniform3(location, vector.X, vector.Y, vector.Z);
		}

		// Token: 0x060035FC RID: 13820 RVA: 0x0008DDAC File Offset: 0x0008BFAC
		public static void Uniform4(int location, Vector4 vector)
		{
			GL.Uniform4(location, vector.X, vector.Y, vector.Z, vector.W);
		}

		// Token: 0x060035FD RID: 13821 RVA: 0x0008DDD0 File Offset: 0x0008BFD0
		public static void Uniform4(int location, Color4 color)
		{
			GL.Uniform4(location, color.R, color.G, color.B, color.A);
		}

		// Token: 0x060035FE RID: 13822 RVA: 0x0008DDF4 File Offset: 0x0008BFF4
		public static void Uniform4(int location, Quaternion quaternion)
		{
			GL.Uniform4(location, quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
		}

		// Token: 0x060035FF RID: 13823 RVA: 0x0008DE18 File Offset: 0x0008C018
		public unsafe static void UniformMatrix2(int location, bool transpose, ref Matrix2 matrix)
		{
			fixed (float* ptr = &matrix.Row0.X)
			{
				GL.UniformMatrix2(location, 1, transpose, ptr);
			}
		}

		// Token: 0x06003600 RID: 13824 RVA: 0x0008DE40 File Offset: 0x0008C040
		public unsafe static void UniformMatrix3(int location, bool transpose, ref Matrix3 matrix)
		{
			fixed (float* ptr = &matrix.Row0.X)
			{
				GL.UniformMatrix3(location, 1, transpose, ptr);
			}
		}

		// Token: 0x06003601 RID: 13825 RVA: 0x0008DE68 File Offset: 0x0008C068
		public unsafe static void UniformMatrix4(int location, bool transpose, ref Matrix4 matrix)
		{
			fixed (float* ptr = &matrix.Row0.X)
			{
				GL.UniformMatrix4(location, 1, transpose, ptr);
			}
		}

		// Token: 0x06003602 RID: 13826 RVA: 0x0008DE90 File Offset: 0x0008C090
		public static string GetActiveAttrib(int program, int index, out int size, out ActiveAttribType type)
		{
			int num;
			GL.GetProgram(program, GetProgramParameterName.ActiveAttributeMaxLength, out num);
			StringBuilder stringBuilder = new StringBuilder((num == 0) ? 1 : (num * 2));
			GL.GetActiveAttrib(program, index, stringBuilder.Capacity, out num, out size, out type, stringBuilder);
			return stringBuilder.ToString();
		}

		// Token: 0x06003603 RID: 13827 RVA: 0x0008DED4 File Offset: 0x0008C0D4
		public static string GetActiveUniform(int program, int uniformIndex, out int size, out ActiveUniformType type)
		{
			int num;
			GL.GetProgram(program, GetProgramParameterName.ActiveUniformMaxLength, out num);
			StringBuilder stringBuilder = new StringBuilder((num == 0) ? 1 : num);
			GL.GetActiveUniform(program, uniformIndex, stringBuilder.Capacity, out num, out size, out type, stringBuilder);
			return stringBuilder.ToString();
		}

		// Token: 0x06003604 RID: 13828 RVA: 0x0008DF14 File Offset: 0x0008C114
		public unsafe static void ShaderSource(int shader, string @string)
		{
			int length = @string.Length;
			GL.ShaderSource((uint)shader, 1, new string[]
			{
				@string
			}, &length);
		}

		// Token: 0x06003605 RID: 13829 RVA: 0x0008DF40 File Offset: 0x0008C140
		public static string GetShaderInfoLog(int shader)
		{
			string result;
			GL.GetShaderInfoLog(shader, out result);
			return result;
		}

		// Token: 0x06003606 RID: 13830 RVA: 0x0008DF58 File Offset: 0x0008C158
		public unsafe static void GetShaderInfoLog(int shader, out string info)
		{
			int num;
			GL.GetShader(shader, ShaderParameter.InfoLogLength, out num);
			if (num == 0)
			{
				info = string.Empty;
				return;
			}
			StringBuilder stringBuilder = new StringBuilder(num * 2);
			GL.GetShaderInfoLog((uint)shader, stringBuilder.Capacity, &num, stringBuilder);
			info = stringBuilder.ToString();
		}

		// Token: 0x06003607 RID: 13831 RVA: 0x0008DFA0 File Offset: 0x0008C1A0
		public static string GetProgramInfoLog(int program)
		{
			string result;
			GL.GetProgramInfoLog(program, out result);
			return result;
		}

		// Token: 0x06003608 RID: 13832 RVA: 0x0008DFB8 File Offset: 0x0008C1B8
		public unsafe static void GetProgramInfoLog(int program, out string info)
		{
			int num;
			GL.GetProgram(program, GetProgramParameterName.InfoLogLength, out num);
			if (num == 0)
			{
				info = string.Empty;
				return;
			}
			StringBuilder stringBuilder = new StringBuilder(num * 2);
			GL.GetProgramInfoLog((uint)program, stringBuilder.Capacity, &num, stringBuilder);
			info = stringBuilder.ToString();
		}

		// Token: 0x06003609 RID: 13833 RVA: 0x0008E000 File Offset: 0x0008C200
		[CLSCompliant(false)]
		public static void VertexAttrib2(int index, ref Vector2 v)
		{
			GL.VertexAttrib2(index, v.X, v.Y);
		}

		// Token: 0x0600360A RID: 13834 RVA: 0x0008E014 File Offset: 0x0008C214
		[CLSCompliant(false)]
		public static void VertexAttrib3(int index, ref Vector3 v)
		{
			GL.VertexAttrib3(index, v.X, v.Y, v.Z);
		}

		// Token: 0x0600360B RID: 13835 RVA: 0x0008E030 File Offset: 0x0008C230
		[CLSCompliant(false)]
		public static void VertexAttrib4(int index, ref Vector4 v)
		{
			GL.VertexAttrib4(index, v.X, v.Y, v.Z, v.W);
		}

		// Token: 0x0600360C RID: 13836 RVA: 0x0008E050 File Offset: 0x0008C250
		public static void VertexAttrib2(int index, Vector2 v)
		{
			GL.VertexAttrib2(index, v.X, v.Y);
		}

		// Token: 0x0600360D RID: 13837 RVA: 0x0008E068 File Offset: 0x0008C268
		public static void VertexAttrib3(int index, Vector3 v)
		{
			GL.VertexAttrib3(index, v.X, v.Y, v.Z);
		}

		// Token: 0x0600360E RID: 13838 RVA: 0x0008E088 File Offset: 0x0008C288
		public static void VertexAttrib4(int index, Vector4 v)
		{
			GL.VertexAttrib4(index, v.X, v.Y, v.Z, v.W);
		}

		// Token: 0x0600360F RID: 13839 RVA: 0x0008E0AC File Offset: 0x0008C2AC
		public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized, int stride, int offset)
		{
			GL.VertexAttribPointer(index, size, type, normalized, stride, (IntPtr)offset);
		}

		// Token: 0x06003610 RID: 13840 RVA: 0x0008E0C0 File Offset: 0x0008C2C0
		[CLSCompliant(false)]
		public static void VertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, int offset)
		{
			GL.VertexAttribPointer(index, size, type, normalized, stride, (IntPtr)offset);
		}

		// Token: 0x06003611 RID: 13841 RVA: 0x0008E0D4 File Offset: 0x0008C2D4
		public static void DrawElements(BeginMode mode, int count, DrawElementsType type, int offset)
		{
			GL.DrawElements((PrimitiveType)mode, count, type, new IntPtr(offset));
		}

		// Token: 0x06003612 RID: 13842 RVA: 0x0008E0E4 File Offset: 0x0008C2E4
		public unsafe static void GetFloat(GetPName pname, out Vector2 vector)
		{
			fixed (Vector2* ptr = &vector)
			{
				GL.GetFloat(pname, (float*)ptr);
			}
		}

		// Token: 0x06003613 RID: 13843 RVA: 0x0008E100 File Offset: 0x0008C300
		public unsafe static void GetFloat(GetPName pname, out Vector3 vector)
		{
			fixed (Vector3* ptr = &vector)
			{
				GL.GetFloat(pname, (float*)ptr);
			}
		}

		// Token: 0x06003614 RID: 13844 RVA: 0x0008E11C File Offset: 0x0008C31C
		public unsafe static void GetFloat(GetPName pname, out Vector4 vector)
		{
			fixed (Vector4* ptr = &vector)
			{
				GL.GetFloat(pname, (float*)ptr);
			}
		}

		// Token: 0x06003615 RID: 13845 RVA: 0x0008E138 File Offset: 0x0008C338
		public unsafe static void GetFloat(GetPName pname, out Matrix4 matrix)
		{
			fixed (Matrix4* ptr = &matrix)
			{
				GL.GetFloat(pname, (float*)ptr);
			}
		}

		// Token: 0x06003616 RID: 13846 RVA: 0x0008E154 File Offset: 0x0008C354
		public static void Viewport(Size size)
		{
			GL.Viewport(0, 0, size.Width, size.Height);
		}

		// Token: 0x06003617 RID: 13847 RVA: 0x0008E16C File Offset: 0x0008C36C
		public static void Viewport(Point location, Size size)
		{
			GL.Viewport(location.X, location.Y, size.Width, size.Height);
		}

		// Token: 0x06003618 RID: 13848 RVA: 0x0008E190 File Offset: 0x0008C390
		public static void Viewport(Rectangle rectangle)
		{
			GL.Viewport(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
		}

		// Token: 0x06003619 RID: 13849 RVA: 0x0008E1B4 File Offset: 0x0008C3B4
		static GL()
		{
			GL.EntryPoints = new IntPtr[GL.EntryPointNameOffsets.Length];
		}

		// Token: 0x0600361A RID: 13850 RVA: 0x0008E210 File Offset: 0x0008C410
		[Obsolete("Use strongly-typed overload instead")]
		public static void ActiveTexture(All texture)
		{
			calli(System.Void(System.Int32), texture, GL.EntryPoints[2]);
		}

		// Token: 0x0600361B RID: 13851 RVA: 0x0008E220 File Offset: 0x0008C420
		public static void ActiveTexture(TextureUnit texture)
		{
			calli(System.Void(System.Int32), texture, GL.EntryPoints[2]);
		}

		// Token: 0x0600361C RID: 13852 RVA: 0x0008E230 File Offset: 0x0008C430
		[CLSCompliant(false)]
		public static void AttachShader(int program, int shader)
		{
			calli(System.Void(System.UInt32,System.UInt32), program, shader, GL.EntryPoints[4]);
		}

		// Token: 0x0600361D RID: 13853 RVA: 0x0008E240 File Offset: 0x0008C440
		[CLSCompliant(false)]
		public static void AttachShader(uint program, uint shader)
		{
			calli(System.Void(System.UInt32,System.UInt32), program, shader, GL.EntryPoints[4]);
		}

		// Token: 0x0600361E RID: 13854 RVA: 0x0008E250 File Offset: 0x0008C450
		[CLSCompliant(false)]
		public static void BindAttribLocation(int program, int index, string name)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(name);
			calli(System.Void(System.UInt32,System.UInt32,System.IntPtr), program, index, intPtr, GL.EntryPoints[8]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x0600361F RID: 13855 RVA: 0x0008E27C File Offset: 0x0008C47C
		[CLSCompliant(false)]
		public static void BindAttribLocation(uint program, uint index, string name)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(name);
			calli(System.Void(System.UInt32,System.UInt32,System.IntPtr), program, index, intPtr, GL.EntryPoints[8]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003620 RID: 13856 RVA: 0x0008E2A8 File Offset: 0x0008C4A8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void BindBuffer(All target, int buffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, buffer, GL.EntryPoints[9]);
		}

		// Token: 0x06003621 RID: 13857 RVA: 0x0008E2BC File Offset: 0x0008C4BC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void BindBuffer(All target, uint buffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, buffer, GL.EntryPoints[9]);
		}

		// Token: 0x06003622 RID: 13858 RVA: 0x0008E2D0 File Offset: 0x0008C4D0
		[CLSCompliant(false)]
		public static void BindBuffer(BufferTarget target, int buffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, buffer, GL.EntryPoints[9]);
		}

		// Token: 0x06003623 RID: 13859 RVA: 0x0008E2E4 File Offset: 0x0008C4E4
		[CLSCompliant(false)]
		public static void BindBuffer(BufferTarget target, uint buffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, buffer, GL.EntryPoints[9]);
		}

		// Token: 0x06003624 RID: 13860 RVA: 0x0008E2F8 File Offset: 0x0008C4F8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void BindFramebuffer(All target, int framebuffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, framebuffer, GL.EntryPoints[10]);
		}

		// Token: 0x06003625 RID: 13861 RVA: 0x0008E30C File Offset: 0x0008C50C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void BindFramebuffer(All target, uint framebuffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, framebuffer, GL.EntryPoints[10]);
		}

		// Token: 0x06003626 RID: 13862 RVA: 0x0008E320 File Offset: 0x0008C520
		[CLSCompliant(false)]
		public static void BindFramebuffer(FramebufferTarget target, int framebuffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, framebuffer, GL.EntryPoints[10]);
		}

		// Token: 0x06003627 RID: 13863 RVA: 0x0008E334 File Offset: 0x0008C534
		[CLSCompliant(false)]
		public static void BindFramebuffer(FramebufferTarget target, uint framebuffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, framebuffer, GL.EntryPoints[10]);
		}

		// Token: 0x06003628 RID: 13864 RVA: 0x0008E348 File Offset: 0x0008C548
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void BindRenderbuffer(All target, int renderbuffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, renderbuffer, GL.EntryPoints[12]);
		}

		// Token: 0x06003629 RID: 13865 RVA: 0x0008E35C File Offset: 0x0008C55C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void BindRenderbuffer(All target, uint renderbuffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, renderbuffer, GL.EntryPoints[12]);
		}

		// Token: 0x0600362A RID: 13866 RVA: 0x0008E370 File Offset: 0x0008C570
		[CLSCompliant(false)]
		public static void BindRenderbuffer(RenderbufferTarget target, int renderbuffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, renderbuffer, GL.EntryPoints[12]);
		}

		// Token: 0x0600362B RID: 13867 RVA: 0x0008E384 File Offset: 0x0008C584
		[CLSCompliant(false)]
		public static void BindRenderbuffer(RenderbufferTarget target, uint renderbuffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, renderbuffer, GL.EntryPoints[12]);
		}

		// Token: 0x0600362C RID: 13868 RVA: 0x0008E398 File Offset: 0x0008C598
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void BindTexture(All target, int texture)
		{
			calli(System.Void(System.Int32,System.UInt32), target, texture, GL.EntryPoints[13]);
		}

		// Token: 0x0600362D RID: 13869 RVA: 0x0008E3AC File Offset: 0x0008C5AC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void BindTexture(All target, uint texture)
		{
			calli(System.Void(System.Int32,System.UInt32), target, texture, GL.EntryPoints[13]);
		}

		// Token: 0x0600362E RID: 13870 RVA: 0x0008E3C0 File Offset: 0x0008C5C0
		[CLSCompliant(false)]
		public static void BindTexture(TextureTarget target, int texture)
		{
			calli(System.Void(System.Int32,System.UInt32), target, texture, GL.EntryPoints[13]);
		}

		// Token: 0x0600362F RID: 13871 RVA: 0x0008E3D4 File Offset: 0x0008C5D4
		[CLSCompliant(false)]
		public static void BindTexture(TextureTarget target, uint texture)
		{
			calli(System.Void(System.Int32,System.UInt32), target, texture, GL.EntryPoints[13]);
		}

		// Token: 0x06003630 RID: 13872 RVA: 0x0008E3E8 File Offset: 0x0008C5E8
		public static void BlendColor(float red, float green, float blue, float alpha)
		{
			calli(System.Void(System.Single,System.Single,System.Single,System.Single), red, green, blue, alpha, GL.EntryPoints[17]);
		}

		// Token: 0x06003631 RID: 13873 RVA: 0x0008E3FC File Offset: 0x0008C5FC
		[Obsolete("Use strongly-typed overload instead")]
		public static void BlendEquation(All mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[18]);
		}

		// Token: 0x06003632 RID: 13874 RVA: 0x0008E40C File Offset: 0x0008C60C
		public static void BlendEquation(BlendEquationMode mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[18]);
		}

		// Token: 0x06003633 RID: 13875 RVA: 0x0008E41C File Offset: 0x0008C61C
		[Obsolete("Use strongly-typed overload instead")]
		public static void BlendEquationSeparate(All modeRGB, All modeAlpha)
		{
			calli(System.Void(System.Int32,System.Int32), modeRGB, modeAlpha, GL.EntryPoints[21]);
		}

		// Token: 0x06003634 RID: 13876 RVA: 0x0008E430 File Offset: 0x0008C630
		public static void BlendEquationSeparate(BlendEquationMode modeRGB, BlendEquationMode modeAlpha)
		{
			calli(System.Void(System.Int32,System.Int32), modeRGB, modeAlpha, GL.EntryPoints[21]);
		}

		// Token: 0x06003635 RID: 13877 RVA: 0x0008E444 File Offset: 0x0008C644
		[Obsolete("Use strongly-typed overload instead")]
		public static void BlendFunc(All sfactor, All dfactor)
		{
			calli(System.Void(System.Int32,System.Int32), sfactor, dfactor, GL.EntryPoints[23]);
		}

		// Token: 0x06003636 RID: 13878 RVA: 0x0008E458 File Offset: 0x0008C658
		public static void BlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor)
		{
			calli(System.Void(System.Int32,System.Int32), sfactor, dfactor, GL.EntryPoints[23]);
		}

		// Token: 0x06003637 RID: 13879 RVA: 0x0008E46C File Offset: 0x0008C66C
		[Obsolete("Use strongly-typed overload instead")]
		public static void BlendFuncSeparate(All sfactorRGB, All dfactorRGB, All sfactorAlpha, All dfactorAlpha)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha, GL.EntryPoints[25]);
		}

		// Token: 0x06003638 RID: 13880 RVA: 0x0008E480 File Offset: 0x0008C680
		public static void BlendFuncSeparate(BlendingFactorSrc sfactorRGB, BlendingFactorDest dfactorRGB, BlendingFactorSrc sfactorAlpha, BlendingFactorDest dfactorAlpha)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha, GL.EntryPoints[25]);
		}

		// Token: 0x06003639 RID: 13881 RVA: 0x0008E494 File Offset: 0x0008C694
		[Obsolete("Use strongly-typed overload instead")]
		public static void BufferData(All target, IntPtr size, IntPtr data, All usage)
		{
			calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, data, usage, GL.EntryPoints[30]);
		}

		// Token: 0x0600363A RID: 13882 RVA: 0x0008E4A8 File Offset: 0x0008C6A8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(All target, IntPtr size, [In] [Out] T2[] data, All usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x0600363B RID: 13883 RVA: 0x0008E4DC File Offset: 0x0008C6DC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(All target, IntPtr size, [In] [Out] T2[,] data, All usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x0600363C RID: 13884 RVA: 0x0008E514 File Offset: 0x0008C714
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(All target, IntPtr size, [In] [Out] T2[,,] data, All usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x0600363D RID: 13885 RVA: 0x0008E54C File Offset: 0x0008C74C
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void BufferData<T2>(All target, IntPtr size, [In] [Out] ref T2 data, All usage) where T2 : struct
		{
			fixed (T2* ptr = &data)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x0600363E RID: 13886 RVA: 0x0008E570 File Offset: 0x0008C770
		[Obsolete("Use BufferUsageHint overload instead")]
		public static void BufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsage usage)
		{
			calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, data, usage, GL.EntryPoints[30]);
		}

		// Token: 0x0600363F RID: 13887 RVA: 0x0008E584 File Offset: 0x0008C784
		public static void BufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsageHint usage)
		{
			calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, data, usage, GL.EntryPoints[30]);
		}

		// Token: 0x06003640 RID: 13888 RVA: 0x0008E598 File Offset: 0x0008C798
		[Obsolete("Use BufferUsageHint overload instead")]
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(BufferTarget target, IntPtr size, [In] [Out] T2[] data, BufferUsage usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x06003641 RID: 13889 RVA: 0x0008E5CC File Offset: 0x0008C7CC
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(BufferTarget target, IntPtr size, [In] [Out] T2[] data, BufferUsageHint usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x06003642 RID: 13890 RVA: 0x0008E600 File Offset: 0x0008C800
		[Obsolete("Use BufferUsageHint overload instead")]
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(BufferTarget target, IntPtr size, [In] [Out] T2[,] data, BufferUsage usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x06003643 RID: 13891 RVA: 0x0008E638 File Offset: 0x0008C838
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(BufferTarget target, IntPtr size, [In] [Out] T2[,] data, BufferUsageHint usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x06003644 RID: 13892 RVA: 0x0008E670 File Offset: 0x0008C870
		[CLSCompliant(false)]
		[Obsolete("Use BufferUsageHint overload instead")]
		public unsafe static void BufferData<T2>(BufferTarget target, IntPtr size, [In] [Out] T2[,,] data, BufferUsage usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x06003645 RID: 13893 RVA: 0x0008E6A8 File Offset: 0x0008C8A8
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(BufferTarget target, IntPtr size, [In] [Out] T2[,,] data, BufferUsageHint usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x06003646 RID: 13894 RVA: 0x0008E6E0 File Offset: 0x0008C8E0
		[Obsolete("Use BufferUsageHint overload instead")]
		public unsafe static void BufferData<T2>(BufferTarget target, IntPtr size, [In] [Out] ref T2 data, BufferUsage usage) where T2 : struct
		{
			fixed (T2* ptr = &data)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x06003647 RID: 13895 RVA: 0x0008E704 File Offset: 0x0008C904
		public unsafe static void BufferData<T2>(BufferTarget target, IntPtr size, [In] [Out] ref T2 data, BufferUsageHint usage) where T2 : struct
		{
			fixed (T2* ptr = &data)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[30]);
			}
		}

		// Token: 0x06003648 RID: 13896 RVA: 0x0008E728 File Offset: 0x0008C928
		[Obsolete("Use strongly-typed overload instead")]
		public static void BufferSubData(All target, IntPtr offset, IntPtr size, IntPtr data)
		{
			calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, data, GL.EntryPoints[31]);
		}

		// Token: 0x06003649 RID: 13897 RVA: 0x0008E73C File Offset: 0x0008C93C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void BufferSubData<T3>(All target, IntPtr offset, IntPtr size, [In] [Out] T3[] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[31]);
			}
		}

		// Token: 0x0600364A RID: 13898 RVA: 0x0008E770 File Offset: 0x0008C970
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void BufferSubData<T3>(All target, IntPtr offset, IntPtr size, [In] [Out] T3[,] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[31]);
			}
		}

		// Token: 0x0600364B RID: 13899 RVA: 0x0008E7A8 File Offset: 0x0008C9A8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void BufferSubData<T3>(All target, IntPtr offset, IntPtr size, [In] [Out] T3[,,] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[31]);
			}
		}

		// Token: 0x0600364C RID: 13900 RVA: 0x0008E7E0 File Offset: 0x0008C9E0
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void BufferSubData<T3>(All target, IntPtr offset, IntPtr size, [In] [Out] ref T3 data) where T3 : struct
		{
			fixed (T3* ptr = &data)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[31]);
			}
		}

		// Token: 0x0600364D RID: 13901 RVA: 0x0008E804 File Offset: 0x0008CA04
		public static void BufferSubData(BufferTarget target, IntPtr offset, IntPtr size, IntPtr data)
		{
			calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, data, GL.EntryPoints[31]);
		}

		// Token: 0x0600364E RID: 13902 RVA: 0x0008E818 File Offset: 0x0008CA18
		[CLSCompliant(false)]
		public unsafe static void BufferSubData<T3>(BufferTarget target, IntPtr offset, IntPtr size, [In] [Out] T3[] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[31]);
			}
		}

		// Token: 0x0600364F RID: 13903 RVA: 0x0008E84C File Offset: 0x0008CA4C
		[CLSCompliant(false)]
		public unsafe static void BufferSubData<T3>(BufferTarget target, IntPtr offset, IntPtr size, [In] [Out] T3[,] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[31]);
			}
		}

		// Token: 0x06003650 RID: 13904 RVA: 0x0008E884 File Offset: 0x0008CA84
		[CLSCompliant(false)]
		public unsafe static void BufferSubData<T3>(BufferTarget target, IntPtr offset, IntPtr size, [In] [Out] T3[,,] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[31]);
			}
		}

		// Token: 0x06003651 RID: 13905 RVA: 0x0008E8BC File Offset: 0x0008CABC
		public unsafe static void BufferSubData<T3>(BufferTarget target, IntPtr offset, IntPtr size, [In] [Out] ref T3 data) where T3 : struct
		{
			fixed (T3* ptr = &data)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[31]);
			}
		}

		// Token: 0x06003652 RID: 13906 RVA: 0x0008E8E0 File Offset: 0x0008CAE0
		[Obsolete("Use strongly-typed overload instead")]
		public static FramebufferErrorCode CheckFramebufferStatus(All target)
		{
			return calli(System.Int32(System.Int32), target, GL.EntryPoints[32]);
		}

		// Token: 0x06003653 RID: 13907 RVA: 0x0008E8F0 File Offset: 0x0008CAF0
		public static FramebufferErrorCode CheckFramebufferStatus(FramebufferTarget target)
		{
			return calli(System.Int32(System.Int32), target, GL.EntryPoints[32]);
		}

		// Token: 0x06003654 RID: 13908 RVA: 0x0008E900 File Offset: 0x0008CB00
		[Obsolete("Use strongly-typed overload instead")]
		public static void Clear(All mask)
		{
			calli(System.Void(System.Int32), mask, GL.EntryPoints[33]);
		}

		// Token: 0x06003655 RID: 13909 RVA: 0x0008E910 File Offset: 0x0008CB10
		public static void Clear(ClearBufferMask mask)
		{
			calli(System.Void(System.Int32), mask, GL.EntryPoints[33]);
		}

		// Token: 0x06003656 RID: 13910 RVA: 0x0008E920 File Offset: 0x0008CB20
		public static void ClearColor(float red, float green, float blue, float alpha)
		{
			calli(System.Void(System.Single,System.Single,System.Single,System.Single), red, green, blue, alpha, GL.EntryPoints[34]);
		}

		// Token: 0x06003657 RID: 13911 RVA: 0x0008E934 File Offset: 0x0008CB34
		public static void ClearDepth(float d)
		{
			calli(System.Void(System.Single), d, GL.EntryPoints[35]);
		}

		// Token: 0x06003658 RID: 13912 RVA: 0x0008E944 File Offset: 0x0008CB44
		public static void ClearStencil(int s)
		{
			calli(System.Void(System.Int32), s, GL.EntryPoints[36]);
		}

		// Token: 0x06003659 RID: 13913 RVA: 0x0008E954 File Offset: 0x0008CB54
		public static void ColorMask(bool red, bool green, bool blue, bool alpha)
		{
			calli(System.Void(System.Boolean,System.Boolean,System.Boolean,System.Boolean), red, green, blue, alpha, GL.EntryPoints[38]);
		}

		// Token: 0x0600365A RID: 13914 RVA: 0x0008E968 File Offset: 0x0008CB68
		[CLSCompliant(false)]
		public static void CompileShader(int shader)
		{
			calli(System.Void(System.UInt32), shader, GL.EntryPoints[40]);
		}

		// Token: 0x0600365B RID: 13915 RVA: 0x0008E978 File Offset: 0x0008CB78
		[CLSCompliant(false)]
		public static void CompileShader(uint shader)
		{
			calli(System.Void(System.UInt32), shader, GL.EntryPoints[40]);
		}

		// Token: 0x0600365C RID: 13916 RVA: 0x0008E988 File Offset: 0x0008CB88
		[Obsolete("Use strongly-typed overload instead")]
		public static void CompressedTexImage2D(All target, int level, All internalformat, int width, int height, int border, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, data, GL.EntryPoints[41]);
		}

		// Token: 0x0600365D RID: 13917 RVA: 0x0008E9B0 File Offset: 0x0008CBB0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexImage2D<T7>(All target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x0600365E RID: 13918 RVA: 0x0008E9F0 File Offset: 0x0008CBF0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexImage2D<T7>(All target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x0600365F RID: 13919 RVA: 0x0008EA34 File Offset: 0x0008CC34
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(All target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x06003660 RID: 13920 RVA: 0x0008EA78 File Offset: 0x0008CC78
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexImage2D<T7>(All target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] ref T7 data) where T7 : struct
		{
			fixed (T7* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x06003661 RID: 13921 RVA: 0x0008EAA4 File Offset: 0x0008CCA4
		[Obsolete("Use TextureTarget2d overload instead")]
		public static void CompressedTexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, data, GL.EntryPoints[41]);
		}

		// Token: 0x06003662 RID: 13922 RVA: 0x0008EACC File Offset: 0x0008CCCC
		[Obsolete("Use TextureTarget2d overload instead")]
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x06003663 RID: 13923 RVA: 0x0008EB0C File Offset: 0x0008CD0C
		[Obsolete("Use TextureTarget2d overload instead")]
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x06003664 RID: 13924 RVA: 0x0008EB50 File Offset: 0x0008CD50
		[CLSCompliant(false)]
		[Obsolete("Use TextureTarget2d overload instead")]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x06003665 RID: 13925 RVA: 0x0008EB94 File Offset: 0x0008CD94
		[Obsolete("Use TextureTarget2d overload instead")]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, int imageSize, [In] [Out] ref T7 data) where T7 : struct
		{
			fixed (T7* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x06003666 RID: 13926 RVA: 0x0008EBC0 File Offset: 0x0008CDC0
		public static void CompressedTexImage2D(TextureTarget2d target, int level, CompressedInternalFormat internalformat, int width, int height, int border, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, data, GL.EntryPoints[41]);
		}

		// Token: 0x06003667 RID: 13927 RVA: 0x0008EBE8 File Offset: 0x0008CDE8
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget2d target, int level, CompressedInternalFormat internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x06003668 RID: 13928 RVA: 0x0008EC28 File Offset: 0x0008CE28
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget2d target, int level, CompressedInternalFormat internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x06003669 RID: 13929 RVA: 0x0008EC6C File Offset: 0x0008CE6C
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget2d target, int level, CompressedInternalFormat internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x0600366A RID: 13930 RVA: 0x0008ECB0 File Offset: 0x0008CEB0
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget2d target, int level, CompressedInternalFormat internalformat, int width, int height, int border, int imageSize, [In] [Out] ref T7 data) where T7 : struct
		{
			fixed (T7* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[41]);
			}
		}

		// Token: 0x0600366B RID: 13931 RVA: 0x0008ECDC File Offset: 0x0008CEDC
		[Obsolete("Use strongly-typed overload instead")]
		public static void CompressedTexSubImage2D(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, data, GL.EntryPoints[43]);
		}

		// Token: 0x0600366C RID: 13932 RVA: 0x0008ED04 File Offset: 0x0008CF04
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, [In] [Out] T8[] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x0600366D RID: 13933 RVA: 0x0008ED44 File Offset: 0x0008CF44
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, [In] [Out] T8[,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x0600366E RID: 13934 RVA: 0x0008ED88 File Offset: 0x0008CF88
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, [In] [Out] T8[,,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x0600366F RID: 13935 RVA: 0x0008EDCC File Offset: 0x0008CFCC
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, [In] [Out] ref T8 data) where T8 : struct
		{
			fixed (T8* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x06003670 RID: 13936 RVA: 0x0008EDF8 File Offset: 0x0008CFF8
		[Obsolete("Use TextureTarget2d and CompressedInternalFormat overloads instead")]
		public static void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, data, GL.EntryPoints[43]);
		}

		// Token: 0x06003671 RID: 13937 RVA: 0x0008EE20 File Offset: 0x0008D020
		[CLSCompliant(false)]
		[Obsolete("Use TextureTarget2d and CompressedInternalFormat overloads instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x06003672 RID: 13938 RVA: 0x0008EE60 File Offset: 0x0008D060
		[CLSCompliant(false)]
		[Obsolete("Use TextureTarget2d and CompressedInternalFormat overloads instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x06003673 RID: 13939 RVA: 0x0008EEA4 File Offset: 0x0008D0A4
		[Obsolete("Use TextureTarget2d and CompressedInternalFormat overloads instead")]
		[CLSCompliant(false)]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[,,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x06003674 RID: 13940 RVA: 0x0008EEE8 File Offset: 0x0008D0E8
		[Obsolete("Use TextureTarget2d and CompressedInternalFormat overloads instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] ref T8 data) where T8 : struct
		{
			fixed (T8* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x06003675 RID: 13941 RVA: 0x0008EF14 File Offset: 0x0008D114
		public static void CompressedTexSubImage2D(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, data, GL.EntryPoints[43]);
		}

		// Token: 0x06003676 RID: 13942 RVA: 0x0008EF3C File Offset: 0x0008D13C
		[CLSCompliant(false)]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x06003677 RID: 13943 RVA: 0x0008EF7C File Offset: 0x0008D17C
		[CLSCompliant(false)]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x06003678 RID: 13944 RVA: 0x0008EFC0 File Offset: 0x0008D1C0
		[CLSCompliant(false)]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[,,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x06003679 RID: 13945 RVA: 0x0008F004 File Offset: 0x0008D204
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] ref T8 data) where T8 : struct
		{
			fixed (T8* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[43]);
			}
		}

		// Token: 0x0600367A RID: 13946 RVA: 0x0008F030 File Offset: 0x0008D230
		[Obsolete("Use strongly-typed overload instead")]
		public static void CopyTexImage2D(All target, int level, All internalformat, int x, int y, int width, int height, int border)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, internalformat, x, y, width, height, border, GL.EntryPoints[47]);
		}

		// Token: 0x0600367B RID: 13947 RVA: 0x0008F058 File Offset: 0x0008D258
		[Obsolete("Use TextureTarget2d and TextureCopyComponentCount overloads instead")]
		public static void CopyTexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int x, int y, int width, int height, int border)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, internalformat, x, y, width, height, border, GL.EntryPoints[47]);
		}

		// Token: 0x0600367C RID: 13948 RVA: 0x0008F080 File Offset: 0x0008D280
		public static void CopyTexImage2D(TextureTarget2d target, int level, TextureCopyComponentCount internalformat, int x, int y, int width, int height, int border)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, internalformat, x, y, width, height, border, GL.EntryPoints[47]);
		}

		// Token: 0x0600367D RID: 13949 RVA: 0x0008F0A8 File Offset: 0x0008D2A8
		[Obsolete("Use strongly-typed overload instead")]
		public static void CopyTexSubImage2D(All target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, xoffset, yoffset, x, y, width, height, GL.EntryPoints[48]);
		}

		// Token: 0x0600367E RID: 13950 RVA: 0x0008F0D0 File Offset: 0x0008D2D0
		[Obsolete("Use TextureTarget2d overload instead")]
		public static void CopyTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, xoffset, yoffset, x, y, width, height, GL.EntryPoints[48]);
		}

		// Token: 0x0600367F RID: 13951 RVA: 0x0008F0F8 File Offset: 0x0008D2F8
		public static void CopyTexSubImage2D(TextureTarget2d target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, xoffset, yoffset, x, y, width, height, GL.EntryPoints[48]);
		}

		// Token: 0x06003680 RID: 13952 RVA: 0x0008F120 File Offset: 0x0008D320
		public static int CreateProgram()
		{
			return calli(System.Int32(), GL.EntryPoints[54]);
		}

		// Token: 0x06003681 RID: 13953 RVA: 0x0008F130 File Offset: 0x0008D330
		[Obsolete("Use strongly-typed overload instead")]
		public static int CreateShader(All type)
		{
			return calli(System.Int32(System.Int32), type, GL.EntryPoints[55]);
		}

		// Token: 0x06003682 RID: 13954 RVA: 0x0008F140 File Offset: 0x0008D340
		public static int CreateShader(ShaderType type)
		{
			return calli(System.Int32(System.Int32), type, GL.EntryPoints[55]);
		}

		// Token: 0x06003683 RID: 13955 RVA: 0x0008F150 File Offset: 0x0008D350
		[Obsolete("Use strongly-typed overload instead")]
		public static void CullFace(All mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[58]);
		}

		// Token: 0x06003684 RID: 13956 RVA: 0x0008F160 File Offset: 0x0008D360
		public static void CullFace(CullFaceMode mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[58]);
		}

		// Token: 0x06003685 RID: 13957 RVA: 0x0008F170 File Offset: 0x0008D370
		public static void DebugMessageCallback(DebugProc callback, IntPtr userParam)
		{
			calli(System.Void(OpenTK.Graphics.ES20.DebugProc,System.IntPtr), callback, userParam, GL.EntryPoints[59]);
		}

		// Token: 0x06003686 RID: 13958 RVA: 0x0008F184 File Offset: 0x0008D384
		[CLSCompliant(false)]
		public unsafe static void DebugMessageCallback<T1>(DebugProc callback, [In] [Out] T1[] userParam) where T1 : struct
		{
			fixed (T1* ptr = ref (userParam != null && userParam.Length != 0) ? ref userParam[0] : ref *null)
			{
				calli(System.Void(OpenTK.Graphics.ES20.DebugProc,System.IntPtr), callback, ptr, GL.EntryPoints[59]);
			}
		}

		// Token: 0x06003687 RID: 13959 RVA: 0x0008F1B8 File Offset: 0x0008D3B8
		[CLSCompliant(false)]
		public unsafe static void DebugMessageCallback<T1>(DebugProc callback, [In] [Out] T1[,] userParam) where T1 : struct
		{
			fixed (T1* ptr = ref (userParam != null && userParam.Length != 0) ? ref userParam[0, 0] : ref *null)
			{
				calli(System.Void(OpenTK.Graphics.ES20.DebugProc,System.IntPtr), callback, ptr, GL.EntryPoints[59]);
			}
		}

		// Token: 0x06003688 RID: 13960 RVA: 0x0008F1F0 File Offset: 0x0008D3F0
		[CLSCompliant(false)]
		public unsafe static void DebugMessageCallback<T1>(DebugProc callback, [In] [Out] T1[,,] userParam) where T1 : struct
		{
			fixed (T1* ptr = ref (userParam != null && userParam.Length != 0) ? ref userParam[0, 0, 0] : ref *null)
			{
				calli(System.Void(OpenTK.Graphics.ES20.DebugProc,System.IntPtr), callback, ptr, GL.EntryPoints[59]);
			}
		}

		// Token: 0x06003689 RID: 13961 RVA: 0x0008F228 File Offset: 0x0008D428
		public unsafe static void DebugMessageCallback<T1>(DebugProc callback, [In] [Out] ref T1 userParam) where T1 : struct
		{
			fixed (T1* ptr = &userParam)
			{
				calli(System.Void(OpenTK.Graphics.ES20.DebugProc,System.IntPtr), callback, ptr, GL.EntryPoints[59]);
			}
		}

		// Token: 0x0600368A RID: 13962 RVA: 0x0008F248 File Offset: 0x0008D448
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(All source, All type, All severity, int count, int[] ids, bool enabled)
		{
			fixed (int* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[61]);
			}
		}

		// Token: 0x0600368B RID: 13963 RVA: 0x0008F284 File Offset: 0x0008D484
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(All source, All type, All severity, int count, ref int ids, bool enabled)
		{
			fixed (int* ptr = &ids)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[61]);
			}
		}

		// Token: 0x0600368C RID: 13964 RVA: 0x0008F2AC File Offset: 0x0008D4AC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(All source, All type, All severity, int count, int* ids, bool enabled)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ids, enabled, GL.EntryPoints[61]);
		}

		// Token: 0x0600368D RID: 13965 RVA: 0x0008F2C4 File Offset: 0x0008D4C4
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void DebugMessageControl(All source, All type, All severity, int count, uint[] ids, bool enabled)
		{
			fixed (uint* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[61]);
			}
		}

		// Token: 0x0600368E RID: 13966 RVA: 0x0008F300 File Offset: 0x0008D500
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void DebugMessageControl(All source, All type, All severity, int count, ref uint ids, bool enabled)
		{
			fixed (uint* ptr = &ids)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[61]);
			}
		}

		// Token: 0x0600368F RID: 13967 RVA: 0x0008F328 File Offset: 0x0008D528
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(All source, All type, All severity, int count, uint* ids, bool enabled)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ids, enabled, GL.EntryPoints[61]);
		}

		// Token: 0x06003690 RID: 13968 RVA: 0x0008F340 File Offset: 0x0008D540
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, int[] ids, bool enabled)
		{
			fixed (int* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[61]);
			}
		}

		// Token: 0x06003691 RID: 13969 RVA: 0x0008F37C File Offset: 0x0008D57C
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, ref int ids, bool enabled)
		{
			fixed (int* ptr = &ids)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[61]);
			}
		}

		// Token: 0x06003692 RID: 13970 RVA: 0x0008F3A4 File Offset: 0x0008D5A4
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, int* ids, bool enabled)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ids, enabled, GL.EntryPoints[61]);
		}

		// Token: 0x06003693 RID: 13971 RVA: 0x0008F3BC File Offset: 0x0008D5BC
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, uint[] ids, bool enabled)
		{
			fixed (uint* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[61]);
			}
		}

		// Token: 0x06003694 RID: 13972 RVA: 0x0008F3F8 File Offset: 0x0008D5F8
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, ref uint ids, bool enabled)
		{
			fixed (uint* ptr = &ids)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[61]);
			}
		}

		// Token: 0x06003695 RID: 13973 RVA: 0x0008F420 File Offset: 0x0008D620
		[CLSCompliant(false)]
		public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, uint* ids, bool enabled)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ids, enabled, GL.EntryPoints[61]);
		}

		// Token: 0x06003696 RID: 13974 RVA: 0x0008F438 File Offset: 0x0008D638
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void DebugMessageInsert(All source, All type, int id, All severity, int length, string buf)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(buf);
			calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.IntPtr), source, type, id, severity, length, intPtr, GL.EntryPoints[63]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003697 RID: 13975 RVA: 0x0008F468 File Offset: 0x0008D668
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void DebugMessageInsert(All source, All type, uint id, All severity, int length, string buf)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(buf);
			calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.IntPtr), source, type, id, severity, length, intPtr, GL.EntryPoints[63]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003698 RID: 13976 RVA: 0x0008F498 File Offset: 0x0008D698
		[CLSCompliant(false)]
		public static void DebugMessageInsert(DebugSourceExternal source, DebugType type, int id, DebugSeverity severity, int length, string buf)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(buf);
			calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.IntPtr), source, type, id, severity, length, intPtr, GL.EntryPoints[63]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003699 RID: 13977 RVA: 0x0008F4C8 File Offset: 0x0008D6C8
		[CLSCompliant(false)]
		public static void DebugMessageInsert(DebugSourceExternal source, DebugType type, uint id, DebugSeverity severity, int length, string buf)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(buf);
			calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.IntPtr), source, type, id, severity, length, intPtr, GL.EntryPoints[63]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x0600369A RID: 13978 RVA: 0x0008F4F8 File Offset: 0x0008D6F8
		[CLSCompliant(false)]
		public static void DeleteBuffer(int buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref buffers, GL.EntryPoints[65]);
		}

		// Token: 0x0600369B RID: 13979 RVA: 0x0008F50C File Offset: 0x0008D70C
		[CLSCompliant(false)]
		public static void DeleteBuffer(uint buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref buffers, GL.EntryPoints[65]);
		}

		// Token: 0x0600369C RID: 13980 RVA: 0x0008F520 File Offset: 0x0008D720
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, int[] buffers)
		{
			fixed (int* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[65]);
			}
		}

		// Token: 0x0600369D RID: 13981 RVA: 0x0008F554 File Offset: 0x0008D754
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, ref int buffers)
		{
			fixed (int* ptr = &buffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[65]);
			}
		}

		// Token: 0x0600369E RID: 13982 RVA: 0x0008F574 File Offset: 0x0008D774
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, int* buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, buffers, GL.EntryPoints[65]);
		}

		// Token: 0x0600369F RID: 13983 RVA: 0x0008F588 File Offset: 0x0008D788
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, uint[] buffers)
		{
			fixed (uint* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[65]);
			}
		}

		// Token: 0x060036A0 RID: 13984 RVA: 0x0008F5BC File Offset: 0x0008D7BC
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, ref uint buffers)
		{
			fixed (uint* ptr = &buffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[65]);
			}
		}

		// Token: 0x060036A1 RID: 13985 RVA: 0x0008F5DC File Offset: 0x0008D7DC
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, uint* buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, buffers, GL.EntryPoints[65]);
		}

		// Token: 0x060036A2 RID: 13986 RVA: 0x0008F5F0 File Offset: 0x0008D7F0
		[CLSCompliant(false)]
		public static void DeleteFramebuffer(int framebuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref framebuffers, GL.EntryPoints[67]);
		}

		// Token: 0x060036A3 RID: 13987 RVA: 0x0008F604 File Offset: 0x0008D804
		[CLSCompliant(false)]
		public static void DeleteFramebuffer(uint framebuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref framebuffers, GL.EntryPoints[67]);
		}

		// Token: 0x060036A4 RID: 13988 RVA: 0x0008F618 File Offset: 0x0008D818
		[CLSCompliant(false)]
		public unsafe static void DeleteFramebuffers(int n, int[] framebuffers)
		{
			fixed (int* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[67]);
			}
		}

		// Token: 0x060036A5 RID: 13989 RVA: 0x0008F64C File Offset: 0x0008D84C
		[CLSCompliant(false)]
		public unsafe static void DeleteFramebuffers(int n, ref int framebuffers)
		{
			fixed (int* ptr = &framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[67]);
			}
		}

		// Token: 0x060036A6 RID: 13990 RVA: 0x0008F66C File Offset: 0x0008D86C
		[CLSCompliant(false)]
		public unsafe static void DeleteFramebuffers(int n, int* framebuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, framebuffers, GL.EntryPoints[67]);
		}

		// Token: 0x060036A7 RID: 13991 RVA: 0x0008F680 File Offset: 0x0008D880
		[CLSCompliant(false)]
		public unsafe static void DeleteFramebuffers(int n, uint[] framebuffers)
		{
			fixed (uint* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[67]);
			}
		}

		// Token: 0x060036A8 RID: 13992 RVA: 0x0008F6B4 File Offset: 0x0008D8B4
		[CLSCompliant(false)]
		public unsafe static void DeleteFramebuffers(int n, ref uint framebuffers)
		{
			fixed (uint* ptr = &framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[67]);
			}
		}

		// Token: 0x060036A9 RID: 13993 RVA: 0x0008F6D4 File Offset: 0x0008D8D4
		[CLSCompliant(false)]
		public unsafe static void DeleteFramebuffers(int n, uint* framebuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, framebuffers, GL.EntryPoints[67]);
		}

		// Token: 0x060036AA RID: 13994 RVA: 0x0008F6E8 File Offset: 0x0008D8E8
		[CLSCompliant(false)]
		public static void DeleteProgram(int program)
		{
			calli(System.Void(System.UInt32), program, GL.EntryPoints[70]);
		}

		// Token: 0x060036AB RID: 13995 RVA: 0x0008F6F8 File Offset: 0x0008D8F8
		[CLSCompliant(false)]
		public static void DeleteProgram(uint program)
		{
			calli(System.Void(System.UInt32), program, GL.EntryPoints[70]);
		}

		// Token: 0x060036AC RID: 13996 RVA: 0x0008F708 File Offset: 0x0008D908
		[CLSCompliant(false)]
		public static void DeleteRenderbuffer(int renderbuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref renderbuffers, GL.EntryPoints[73]);
		}

		// Token: 0x060036AD RID: 13997 RVA: 0x0008F71C File Offset: 0x0008D91C
		[CLSCompliant(false)]
		public static void DeleteRenderbuffer(uint renderbuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref renderbuffers, GL.EntryPoints[73]);
		}

		// Token: 0x060036AE RID: 13998 RVA: 0x0008F730 File Offset: 0x0008D930
		[CLSCompliant(false)]
		public unsafe static void DeleteRenderbuffers(int n, int[] renderbuffers)
		{
			fixed (int* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[73]);
			}
		}

		// Token: 0x060036AF RID: 13999 RVA: 0x0008F764 File Offset: 0x0008D964
		[CLSCompliant(false)]
		public unsafe static void DeleteRenderbuffers(int n, ref int renderbuffers)
		{
			fixed (int* ptr = &renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[73]);
			}
		}

		// Token: 0x060036B0 RID: 14000 RVA: 0x0008F784 File Offset: 0x0008D984
		[CLSCompliant(false)]
		public unsafe static void DeleteRenderbuffers(int n, int* renderbuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, renderbuffers, GL.EntryPoints[73]);
		}

		// Token: 0x060036B1 RID: 14001 RVA: 0x0008F798 File Offset: 0x0008D998
		[CLSCompliant(false)]
		public unsafe static void DeleteRenderbuffers(int n, uint[] renderbuffers)
		{
			fixed (uint* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[73]);
			}
		}

		// Token: 0x060036B2 RID: 14002 RVA: 0x0008F7CC File Offset: 0x0008D9CC
		[CLSCompliant(false)]
		public unsafe static void DeleteRenderbuffers(int n, ref uint renderbuffers)
		{
			fixed (uint* ptr = &renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[73]);
			}
		}

		// Token: 0x060036B3 RID: 14003 RVA: 0x0008F7EC File Offset: 0x0008D9EC
		[CLSCompliant(false)]
		public unsafe static void DeleteRenderbuffers(int n, uint* renderbuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, renderbuffers, GL.EntryPoints[73]);
		}

		// Token: 0x060036B4 RID: 14004 RVA: 0x0008F800 File Offset: 0x0008DA00
		[CLSCompliant(false)]
		public static void DeleteShader(int shader)
		{
			calli(System.Void(System.UInt32), shader, GL.EntryPoints[74]);
		}

		// Token: 0x060036B5 RID: 14005 RVA: 0x0008F810 File Offset: 0x0008DA10
		[CLSCompliant(false)]
		public static void DeleteShader(uint shader)
		{
			calli(System.Void(System.UInt32), shader, GL.EntryPoints[74]);
		}

		// Token: 0x060036B6 RID: 14006 RVA: 0x0008F820 File Offset: 0x0008DA20
		[CLSCompliant(false)]
		public static void DeleteTexture(int textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref textures, GL.EntryPoints[76]);
		}

		// Token: 0x060036B7 RID: 14007 RVA: 0x0008F834 File Offset: 0x0008DA34
		[CLSCompliant(false)]
		public static void DeleteTexture(uint textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref textures, GL.EntryPoints[76]);
		}

		// Token: 0x060036B8 RID: 14008 RVA: 0x0008F848 File Offset: 0x0008DA48
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, int[] textures)
		{
			fixed (int* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[76]);
			}
		}

		// Token: 0x060036B9 RID: 14009 RVA: 0x0008F87C File Offset: 0x0008DA7C
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, ref int textures)
		{
			fixed (int* ptr = &textures)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[76]);
			}
		}

		// Token: 0x060036BA RID: 14010 RVA: 0x0008F89C File Offset: 0x0008DA9C
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, int* textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, textures, GL.EntryPoints[76]);
		}

		// Token: 0x060036BB RID: 14011 RVA: 0x0008F8B0 File Offset: 0x0008DAB0
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, uint[] textures)
		{
			fixed (uint* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[76]);
			}
		}

		// Token: 0x060036BC RID: 14012 RVA: 0x0008F8E4 File Offset: 0x0008DAE4
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, ref uint textures)
		{
			fixed (uint* ptr = &textures)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[76]);
			}
		}

		// Token: 0x060036BD RID: 14013 RVA: 0x0008F904 File Offset: 0x0008DB04
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, uint* textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, textures, GL.EntryPoints[76]);
		}

		// Token: 0x060036BE RID: 14014 RVA: 0x0008F918 File Offset: 0x0008DB18
		[Obsolete("Use strongly-typed overload instead")]
		public static void DepthFunc(All func)
		{
			calli(System.Void(System.Int32), func, GL.EntryPoints[78]);
		}

		// Token: 0x060036BF RID: 14015 RVA: 0x0008F928 File Offset: 0x0008DB28
		public static void DepthFunc(DepthFunction func)
		{
			calli(System.Void(System.Int32), func, GL.EntryPoints[78]);
		}

		// Token: 0x060036C0 RID: 14016 RVA: 0x0008F938 File Offset: 0x0008DB38
		public static void DepthMask(bool flag)
		{
			calli(System.Void(System.Boolean), flag, GL.EntryPoints[79]);
		}

		// Token: 0x060036C1 RID: 14017 RVA: 0x0008F948 File Offset: 0x0008DB48
		public static void DepthRange(float n, float f)
		{
			calli(System.Void(System.Single,System.Single), n, f, GL.EntryPoints[80]);
		}

		// Token: 0x060036C2 RID: 14018 RVA: 0x0008F95C File Offset: 0x0008DB5C
		[CLSCompliant(false)]
		public static void DetachShader(int program, int shader)
		{
			calli(System.Void(System.UInt32,System.UInt32), program, shader, GL.EntryPoints[81]);
		}

		// Token: 0x060036C3 RID: 14019 RVA: 0x0008F970 File Offset: 0x0008DB70
		[CLSCompliant(false)]
		public static void DetachShader(uint program, uint shader)
		{
			calli(System.Void(System.UInt32,System.UInt32), program, shader, GL.EntryPoints[81]);
		}

		// Token: 0x060036C4 RID: 14020 RVA: 0x0008F984 File Offset: 0x0008DB84
		[Obsolete("Use strongly-typed overload instead")]
		public static void Disable(All cap)
		{
			calli(System.Void(System.Int32), cap, GL.EntryPoints[82]);
		}

		// Token: 0x060036C5 RID: 14021 RVA: 0x0008F994 File Offset: 0x0008DB94
		public static void Disable(EnableCap cap)
		{
			calli(System.Void(System.Int32), cap, GL.EntryPoints[82]);
		}

		// Token: 0x060036C6 RID: 14022 RVA: 0x0008F9A4 File Offset: 0x0008DBA4
		[CLSCompliant(false)]
		public static void DisableVertexAttribArray(int index)
		{
			calli(System.Void(System.UInt32), index, GL.EntryPoints[85]);
		}

		// Token: 0x060036C7 RID: 14023 RVA: 0x0008F9B4 File Offset: 0x0008DBB4
		[CLSCompliant(false)]
		public static void DisableVertexAttribArray(uint index)
		{
			calli(System.Void(System.UInt32), index, GL.EntryPoints[85]);
		}

		// Token: 0x060036C8 RID: 14024 RVA: 0x0008F9C4 File Offset: 0x0008DBC4
		[Obsolete("Use strongly-typed overload instead")]
		public static void DrawArrays(All mode, int first, int count)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), mode, first, count, GL.EntryPoints[87]);
		}

		// Token: 0x060036C9 RID: 14025 RVA: 0x0008F9D8 File Offset: 0x0008DBD8
		[Obsolete("Use PrimitiveType overload instead")]
		public static void DrawArrays(BeginMode mode, int first, int count)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), mode, first, count, GL.EntryPoints[87]);
		}

		// Token: 0x060036CA RID: 14026 RVA: 0x0008F9EC File Offset: 0x0008DBEC
		public static void DrawArrays(PrimitiveType mode, int first, int count)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), mode, first, count, GL.EntryPoints[87]);
		}

		// Token: 0x060036CB RID: 14027 RVA: 0x0008FA00 File Offset: 0x0008DC00
		[Obsolete("Use strongly-typed overload instead")]
		public static void DrawElements(All mode, int count, All type, IntPtr indices)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, indices, GL.EntryPoints[94]);
		}

		// Token: 0x060036CC RID: 14028 RVA: 0x0008FA14 File Offset: 0x0008DC14
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(All mode, int count, All type, [In] [Out] T3[] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036CD RID: 14029 RVA: 0x0008FA48 File Offset: 0x0008DC48
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(All mode, int count, All type, [In] [Out] T3[,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036CE RID: 14030 RVA: 0x0008FA80 File Offset: 0x0008DC80
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void DrawElements<T3>(All mode, int count, All type, [In] [Out] T3[,,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036CF RID: 14031 RVA: 0x0008FAB8 File Offset: 0x0008DCB8
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void DrawElements<T3>(All mode, int count, All type, [In] [Out] ref T3 indices) where T3 : struct
		{
			fixed (T3* ptr = &indices)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036D0 RID: 14032 RVA: 0x0008FADC File Offset: 0x0008DCDC
		[Obsolete("Use PrimitiveType overload instead")]
		public static void DrawElements(BeginMode mode, int count, DrawElementsType type, IntPtr indices)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, indices, GL.EntryPoints[94]);
		}

		// Token: 0x060036D1 RID: 14033 RVA: 0x0008FAF0 File Offset: 0x0008DCF0
		[Obsolete("Use PrimitiveType overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(BeginMode mode, int count, DrawElementsType type, [In] [Out] T3[] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036D2 RID: 14034 RVA: 0x0008FB24 File Offset: 0x0008DD24
		[Obsolete("Use PrimitiveType overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(BeginMode mode, int count, DrawElementsType type, [In] [Out] T3[,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036D3 RID: 14035 RVA: 0x0008FB5C File Offset: 0x0008DD5C
		[CLSCompliant(false)]
		[Obsolete("Use PrimitiveType overload instead")]
		public unsafe static void DrawElements<T3>(BeginMode mode, int count, DrawElementsType type, [In] [Out] T3[,,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036D4 RID: 14036 RVA: 0x0008FB94 File Offset: 0x0008DD94
		[Obsolete("Use PrimitiveType overload instead")]
		public unsafe static void DrawElements<T3>(BeginMode mode, int count, DrawElementsType type, [In] [Out] ref T3 indices) where T3 : struct
		{
			fixed (T3* ptr = &indices)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036D5 RID: 14037 RVA: 0x0008FBB8 File Offset: 0x0008DDB8
		public static void DrawElements(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, indices, GL.EntryPoints[94]);
		}

		// Token: 0x060036D6 RID: 14038 RVA: 0x0008FBCC File Offset: 0x0008DDCC
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036D7 RID: 14039 RVA: 0x0008FC00 File Offset: 0x0008DE00
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036D8 RID: 14040 RVA: 0x0008FC38 File Offset: 0x0008DE38
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[,,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036D9 RID: 14041 RVA: 0x0008FC70 File Offset: 0x0008DE70
		public unsafe static void DrawElements<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] ref T3 indices) where T3 : struct
		{
			fixed (T3* ptr = &indices)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[94]);
			}
		}

		// Token: 0x060036DA RID: 14042 RVA: 0x0008FC94 File Offset: 0x0008DE94
		[Obsolete("Use strongly-typed overload instead")]
		public static void Enable(All cap)
		{
			calli(System.Void(System.Int32), cap, GL.EntryPoints[100]);
		}

		// Token: 0x060036DB RID: 14043 RVA: 0x0008FCA4 File Offset: 0x0008DEA4
		public static void Enable(EnableCap cap)
		{
			calli(System.Void(System.Int32), cap, GL.EntryPoints[100]);
		}

		// Token: 0x060036DC RID: 14044 RVA: 0x0008FCB4 File Offset: 0x0008DEB4
		[CLSCompliant(false)]
		public static void EnableVertexAttribArray(int index)
		{
			calli(System.Void(System.UInt32), index, GL.EntryPoints[103]);
		}

		// Token: 0x060036DD RID: 14045 RVA: 0x0008FCC4 File Offset: 0x0008DEC4
		[CLSCompliant(false)]
		public static void EnableVertexAttribArray(uint index)
		{
			calli(System.Void(System.UInt32), index, GL.EntryPoints[103]);
		}

		// Token: 0x060036DE RID: 14046 RVA: 0x0008FCD4 File Offset: 0x0008DED4
		public static void Finish()
		{
			calli(System.Void(), GL.EntryPoints[121]);
		}

		// Token: 0x060036DF RID: 14047 RVA: 0x0008FCE4 File Offset: 0x0008DEE4
		public static void Flush()
		{
			calli(System.Void(), GL.EntryPoints[123]);
		}

		// Token: 0x060036E0 RID: 14048 RVA: 0x0008FCF4 File Offset: 0x0008DEF4
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void FramebufferRenderbuffer(All target, All attachment, All renderbuffertarget, int renderbuffer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), target, attachment, renderbuffertarget, renderbuffer, GL.EntryPoints[125]);
		}

		// Token: 0x060036E1 RID: 14049 RVA: 0x0008FD08 File Offset: 0x0008DF08
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void FramebufferRenderbuffer(All target, All attachment, All renderbuffertarget, uint renderbuffer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), target, attachment, renderbuffertarget, renderbuffer, GL.EntryPoints[125]);
		}

		// Token: 0x060036E2 RID: 14050 RVA: 0x0008FD1C File Offset: 0x0008DF1C
		[CLSCompliant(false)]
		public static void FramebufferRenderbuffer(FramebufferTarget target, All attachment, RenderbufferTarget renderbuffertarget, int renderbuffer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), target, attachment, renderbuffertarget, renderbuffer, GL.EntryPoints[125]);
		}

		// Token: 0x060036E3 RID: 14051 RVA: 0x0008FD30 File Offset: 0x0008DF30
		[CLSCompliant(false)]
		public static void FramebufferRenderbuffer(FramebufferTarget target, All attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), target, attachment, renderbuffertarget, renderbuffer, GL.EntryPoints[125]);
		}

		// Token: 0x060036E4 RID: 14052 RVA: 0x0008FD44 File Offset: 0x0008DF44
		[CLSCompliant(false)]
		[Obsolete("Use FramebufferAttachment overload instead")]
		public static void FramebufferRenderbuffer(FramebufferTarget target, FramebufferSlot attachment, RenderbufferTarget renderbuffertarget, int renderbuffer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), target, attachment, renderbuffertarget, renderbuffer, GL.EntryPoints[125]);
		}

		// Token: 0x060036E5 RID: 14053 RVA: 0x0008FD58 File Offset: 0x0008DF58
		[CLSCompliant(false)]
		[Obsolete("Use FramebufferAttachment overload instead")]
		public static void FramebufferRenderbuffer(FramebufferTarget target, FramebufferSlot attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), target, attachment, renderbuffertarget, renderbuffer, GL.EntryPoints[125]);
		}

		// Token: 0x060036E6 RID: 14054 RVA: 0x0008FD6C File Offset: 0x0008DF6C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void FramebufferTexture2D(All target, All attachment, All textarget, int texture, int level)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[126]);
		}

		// Token: 0x060036E7 RID: 14055 RVA: 0x0008FD84 File Offset: 0x0008DF84
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void FramebufferTexture2D(All target, All attachment, All textarget, uint texture, int level)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[126]);
		}

		// Token: 0x060036E8 RID: 14056 RVA: 0x0008FD9C File Offset: 0x0008DF9C
		[CLSCompliant(false)]
		[Obsolete("Use TextureTarget2d overload instead")]
		public static void FramebufferTexture2D(FramebufferTarget target, All attachment, TextureTarget textarget, int texture, int level)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[126]);
		}

		// Token: 0x060036E9 RID: 14057 RVA: 0x0008FDB4 File Offset: 0x0008DFB4
		[CLSCompliant(false)]
		[Obsolete("Use TextureTarget2d overload instead")]
		public static void FramebufferTexture2D(FramebufferTarget target, All attachment, TextureTarget textarget, uint texture, int level)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[126]);
		}

		// Token: 0x060036EA RID: 14058 RVA: 0x0008FDCC File Offset: 0x0008DFCC
		[CLSCompliant(false)]
		public static void FramebufferTexture2D(FramebufferTarget target, All attachment, TextureTarget2d textarget, int texture, int level)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[126]);
		}

		// Token: 0x060036EB RID: 14059 RVA: 0x0008FDE4 File Offset: 0x0008DFE4
		[CLSCompliant(false)]
		public static void FramebufferTexture2D(FramebufferTarget target, All attachment, TextureTarget2d textarget, uint texture, int level)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[126]);
		}

		// Token: 0x060036EC RID: 14060 RVA: 0x0008FDFC File Offset: 0x0008DFFC
		[Obsolete("Use TextureTarget2d overload instead")]
		[CLSCompliant(false)]
		public static void FramebufferTexture2D(FramebufferTarget target, FramebufferSlot attachment, TextureTarget textarget, int texture, int level)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[126]);
		}

		// Token: 0x060036ED RID: 14061 RVA: 0x0008FE14 File Offset: 0x0008E014
		[CLSCompliant(false)]
		[Obsolete("Use TextureTarget2d overload instead")]
		public static void FramebufferTexture2D(FramebufferTarget target, FramebufferSlot attachment, TextureTarget textarget, uint texture, int level)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[126]);
		}

		// Token: 0x060036EE RID: 14062 RVA: 0x0008FE2C File Offset: 0x0008E02C
		[Obsolete("Use strongly-typed overload instead")]
		public static void FrontFace(All mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[131]);
		}

		// Token: 0x060036EF RID: 14063 RVA: 0x0008FE40 File Offset: 0x0008E040
		public static void FrontFace(FrontFaceDirection mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[131]);
		}

		// Token: 0x060036F0 RID: 14064 RVA: 0x0008FE54 File Offset: 0x0008E054
		[CLSCompliant(false)]
		public static int GenBuffer()
		{
			int result;
			calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[132]);
			return result;
		}

		// Token: 0x060036F1 RID: 14065 RVA: 0x0008FE78 File Offset: 0x0008E078
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, [Out] int[] buffers)
		{
			fixed (int* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[132]);
			}
		}

		// Token: 0x060036F2 RID: 14066 RVA: 0x0008FEAC File Offset: 0x0008E0AC
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, out int buffers)
		{
			fixed (int* ptr = &buffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[132]);
			}
		}

		// Token: 0x060036F3 RID: 14067 RVA: 0x0008FED0 File Offset: 0x0008E0D0
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, [Out] int* buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, buffers, GL.EntryPoints[132]);
		}

		// Token: 0x060036F4 RID: 14068 RVA: 0x0008FEE4 File Offset: 0x0008E0E4
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, [Out] uint[] buffers)
		{
			fixed (uint* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[132]);
			}
		}

		// Token: 0x060036F5 RID: 14069 RVA: 0x0008FF18 File Offset: 0x0008E118
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, out uint buffers)
		{
			fixed (uint* ptr = &buffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[132]);
			}
		}

		// Token: 0x060036F6 RID: 14070 RVA: 0x0008FF3C File Offset: 0x0008E13C
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, [Out] uint* buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, buffers, GL.EntryPoints[132]);
		}

		// Token: 0x060036F7 RID: 14071 RVA: 0x0008FF50 File Offset: 0x0008E150
		[Obsolete("Use strongly-typed overload instead")]
		public static void GenerateMipmap(All target)
		{
			calli(System.Void(System.Int32), target, GL.EntryPoints[133]);
		}

		// Token: 0x060036F8 RID: 14072 RVA: 0x0008FF64 File Offset: 0x0008E164
		public static void GenerateMipmap(TextureTarget target)
		{
			calli(System.Void(System.Int32), target, GL.EntryPoints[133]);
		}

		// Token: 0x060036F9 RID: 14073 RVA: 0x0008FF78 File Offset: 0x0008E178
		[CLSCompliant(false)]
		public static int GenFramebuffer()
		{
			int result;
			calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[135]);
			return result;
		}

		// Token: 0x060036FA RID: 14074 RVA: 0x0008FF9C File Offset: 0x0008E19C
		[CLSCompliant(false)]
		public unsafe static void GenFramebuffers(int n, [Out] int[] framebuffers)
		{
			fixed (int* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[135]);
			}
		}

		// Token: 0x060036FB RID: 14075 RVA: 0x0008FFD0 File Offset: 0x0008E1D0
		[CLSCompliant(false)]
		public unsafe static void GenFramebuffers(int n, out int framebuffers)
		{
			fixed (int* ptr = &framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[135]);
			}
		}

		// Token: 0x060036FC RID: 14076 RVA: 0x0008FFF4 File Offset: 0x0008E1F4
		[CLSCompliant(false)]
		public unsafe static void GenFramebuffers(int n, [Out] int* framebuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, framebuffers, GL.EntryPoints[135]);
		}

		// Token: 0x060036FD RID: 14077 RVA: 0x00090008 File Offset: 0x0008E208
		[CLSCompliant(false)]
		public unsafe static void GenFramebuffers(int n, [Out] uint[] framebuffers)
		{
			fixed (uint* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[135]);
			}
		}

		// Token: 0x060036FE RID: 14078 RVA: 0x0009003C File Offset: 0x0008E23C
		[CLSCompliant(false)]
		public unsafe static void GenFramebuffers(int n, out uint framebuffers)
		{
			fixed (uint* ptr = &framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[135]);
			}
		}

		// Token: 0x060036FF RID: 14079 RVA: 0x00090060 File Offset: 0x0008E260
		[CLSCompliant(false)]
		public unsafe static void GenFramebuffers(int n, [Out] uint* framebuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, framebuffers, GL.EntryPoints[135]);
		}

		// Token: 0x06003700 RID: 14080 RVA: 0x00090074 File Offset: 0x0008E274
		[CLSCompliant(false)]
		public static int GenRenderbuffer()
		{
			int result;
			calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[139]);
			return result;
		}

		// Token: 0x06003701 RID: 14081 RVA: 0x00090098 File Offset: 0x0008E298
		[CLSCompliant(false)]
		public unsafe static void GenRenderbuffers(int n, [Out] int[] renderbuffers)
		{
			fixed (int* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[139]);
			}
		}

		// Token: 0x06003702 RID: 14082 RVA: 0x000900CC File Offset: 0x0008E2CC
		[CLSCompliant(false)]
		public unsafe static void GenRenderbuffers(int n, out int renderbuffers)
		{
			fixed (int* ptr = &renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[139]);
			}
		}

		// Token: 0x06003703 RID: 14083 RVA: 0x000900F0 File Offset: 0x0008E2F0
		[CLSCompliant(false)]
		public unsafe static void GenRenderbuffers(int n, [Out] int* renderbuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, renderbuffers, GL.EntryPoints[139]);
		}

		// Token: 0x06003704 RID: 14084 RVA: 0x00090104 File Offset: 0x0008E304
		[CLSCompliant(false)]
		public unsafe static void GenRenderbuffers(int n, [Out] uint[] renderbuffers)
		{
			fixed (uint* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[139]);
			}
		}

		// Token: 0x06003705 RID: 14085 RVA: 0x00090138 File Offset: 0x0008E338
		[CLSCompliant(false)]
		public unsafe static void GenRenderbuffers(int n, out uint renderbuffers)
		{
			fixed (uint* ptr = &renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[139]);
			}
		}

		// Token: 0x06003706 RID: 14086 RVA: 0x0009015C File Offset: 0x0008E35C
		[CLSCompliant(false)]
		public unsafe static void GenRenderbuffers(int n, [Out] uint* renderbuffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, renderbuffers, GL.EntryPoints[139]);
		}

		// Token: 0x06003707 RID: 14087 RVA: 0x00090170 File Offset: 0x0008E370
		[CLSCompliant(false)]
		public static int GenTexture()
		{
			int result;
			calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[140]);
			return result;
		}

		// Token: 0x06003708 RID: 14088 RVA: 0x00090194 File Offset: 0x0008E394
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, [Out] int[] textures)
		{
			fixed (int* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[140]);
			}
		}

		// Token: 0x06003709 RID: 14089 RVA: 0x000901C8 File Offset: 0x0008E3C8
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, out int textures)
		{
			fixed (int* ptr = &textures)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[140]);
			}
		}

		// Token: 0x0600370A RID: 14090 RVA: 0x000901EC File Offset: 0x0008E3EC
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, [Out] int* textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, textures, GL.EntryPoints[140]);
		}

		// Token: 0x0600370B RID: 14091 RVA: 0x00090200 File Offset: 0x0008E400
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, [Out] uint[] textures)
		{
			fixed (uint* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[140]);
			}
		}

		// Token: 0x0600370C RID: 14092 RVA: 0x00090234 File Offset: 0x0008E434
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, out uint textures)
		{
			fixed (uint* ptr = &textures)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[140]);
			}
		}

		// Token: 0x0600370D RID: 14093 RVA: 0x00090258 File Offset: 0x0008E458
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, [Out] uint* textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, textures, GL.EntryPoints[140]);
		}

		// Token: 0x0600370E RID: 14094 RVA: 0x0009026C File Offset: 0x0008E46C
		[CLSCompliant(false)]
		public unsafe static void GetActiveAttrib(int program, int index, int bufSize, out int length, out int size, out ActiveAttribType type, [Out] StringBuilder name)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &size)
				{
					int* ptr4 = ptr3;
					fixed (ActiveAttribType* ptr5 = &type)
					{
						ActiveAttribType* ptr6 = ptr5;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, ptr2, ptr4, ptr6, intPtr, GL.EntryPoints[142]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		// Token: 0x0600370F RID: 14095 RVA: 0x000902B8 File Offset: 0x0008E4B8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetActiveAttrib(int program, int index, int bufSize, out int length, out int size, out All type, [Out] StringBuilder name)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &size)
				{
					int* ptr4 = ptr3;
					fixed (All* ptr5 = &type)
					{
						All* ptr6 = ptr5;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, ptr2, ptr4, ptr6, intPtr, GL.EntryPoints[142]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		// Token: 0x06003710 RID: 14096 RVA: 0x00090304 File Offset: 0x0008E504
		[CLSCompliant(false)]
		public unsafe static void GetActiveAttrib(int program, int index, int bufSize, [Out] int* length, [Out] int* size, [Out] ActiveAttribType* type, [Out] StringBuilder name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
			calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, length, size, type, intPtr, GL.EntryPoints[142]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003711 RID: 14097 RVA: 0x00090348 File Offset: 0x0008E548
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetActiveAttrib(int program, int index, int bufSize, [Out] int* length, [Out] int* size, [Out] All* type, [Out] StringBuilder name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
			calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, length, size, type, intPtr, GL.EntryPoints[142]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003712 RID: 14098 RVA: 0x0009038C File Offset: 0x0008E58C
		[CLSCompliant(false)]
		public unsafe static void GetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out ActiveAttribType type, [Out] StringBuilder name)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &size)
				{
					int* ptr4 = ptr3;
					fixed (ActiveAttribType* ptr5 = &type)
					{
						ActiveAttribType* ptr6 = ptr5;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, ptr2, ptr4, ptr6, intPtr, GL.EntryPoints[142]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		// Token: 0x06003713 RID: 14099 RVA: 0x000903D8 File Offset: 0x0008E5D8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out All type, [Out] StringBuilder name)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &size)
				{
					int* ptr4 = ptr3;
					fixed (All* ptr5 = &type)
					{
						All* ptr6 = ptr5;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, ptr2, ptr4, ptr6, intPtr, GL.EntryPoints[142]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		// Token: 0x06003714 RID: 14100 RVA: 0x00090424 File Offset: 0x0008E624
		[CLSCompliant(false)]
		public unsafe static void GetActiveAttrib(uint program, uint index, int bufSize, [Out] int* length, [Out] int* size, [Out] ActiveAttribType* type, [Out] StringBuilder name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
			calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, length, size, type, intPtr, GL.EntryPoints[142]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003715 RID: 14101 RVA: 0x00090468 File Offset: 0x0008E668
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetActiveAttrib(uint program, uint index, int bufSize, [Out] int* length, [Out] int* size, [Out] All* type, [Out] StringBuilder name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
			calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, length, size, type, intPtr, GL.EntryPoints[142]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003716 RID: 14102 RVA: 0x000904AC File Offset: 0x0008E6AC
		[CLSCompliant(false)]
		public unsafe static void GetActiveUniform(int program, int index, int bufSize, out int length, out int size, out ActiveUniformType type, [Out] StringBuilder name)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &size)
				{
					int* ptr4 = ptr3;
					fixed (ActiveUniformType* ptr5 = &type)
					{
						ActiveUniformType* ptr6 = ptr5;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, ptr2, ptr4, ptr6, intPtr, GL.EntryPoints[143]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		// Token: 0x06003717 RID: 14103 RVA: 0x000904F8 File Offset: 0x0008E6F8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetActiveUniform(int program, int index, int bufSize, out int length, out int size, out All type, [Out] StringBuilder name)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &size)
				{
					int* ptr4 = ptr3;
					fixed (All* ptr5 = &type)
					{
						All* ptr6 = ptr5;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, ptr2, ptr4, ptr6, intPtr, GL.EntryPoints[143]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		// Token: 0x06003718 RID: 14104 RVA: 0x00090544 File Offset: 0x0008E744
		[CLSCompliant(false)]
		public unsafe static void GetActiveUniform(int program, int index, int bufSize, [Out] int* length, [Out] int* size, [Out] ActiveUniformType* type, [Out] StringBuilder name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
			calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, length, size, type, intPtr, GL.EntryPoints[143]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003719 RID: 14105 RVA: 0x00090588 File Offset: 0x0008E788
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetActiveUniform(int program, int index, int bufSize, [Out] int* length, [Out] int* size, [Out] All* type, [Out] StringBuilder name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
			calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, length, size, type, intPtr, GL.EntryPoints[143]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600371A RID: 14106 RVA: 0x000905CC File Offset: 0x0008E7CC
		[CLSCompliant(false)]
		public unsafe static void GetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, out ActiveUniformType type, [Out] StringBuilder name)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &size)
				{
					int* ptr4 = ptr3;
					fixed (ActiveUniformType* ptr5 = &type)
					{
						ActiveUniformType* ptr6 = ptr5;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, ptr2, ptr4, ptr6, intPtr, GL.EntryPoints[143]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		// Token: 0x0600371B RID: 14107 RVA: 0x00090618 File Offset: 0x0008E818
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, out All type, [Out] StringBuilder name)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &size)
				{
					int* ptr4 = ptr3;
					fixed (All* ptr5 = &type)
					{
						All* ptr6 = ptr5;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, ptr2, ptr4, ptr6, intPtr, GL.EntryPoints[143]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		// Token: 0x0600371C RID: 14108 RVA: 0x00090664 File Offset: 0x0008E864
		[CLSCompliant(false)]
		public unsafe static void GetActiveUniform(uint program, uint index, int bufSize, [Out] int* length, [Out] int* size, [Out] ActiveUniformType* type, [Out] StringBuilder name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
			calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, length, size, type, intPtr, GL.EntryPoints[143]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600371D RID: 14109 RVA: 0x000906A8 File Offset: 0x0008E8A8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetActiveUniform(uint program, uint index, int bufSize, [Out] int* length, [Out] int* size, [Out] All* type, [Out] StringBuilder name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)name.Capacity);
			calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.Int32*,System.Int32*,System.IntPtr), program, index, bufSize, length, size, type, intPtr, GL.EntryPoints[143]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, name);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600371E RID: 14110 RVA: 0x000906EC File Offset: 0x0008E8EC
		[CLSCompliant(false)]
		public unsafe static void GetAttachedShaders(int program, int maxCount, out int count, [Out] int[] shaders)
		{
			fixed (int* ptr = &count)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.UInt32*), program, maxCount, ptr2, ptr3, GL.EntryPoints[144]);
				}
			}
		}

		// Token: 0x0600371F RID: 14111 RVA: 0x00090728 File Offset: 0x0008E928
		[CLSCompliant(false)]
		public unsafe static void GetAttachedShaders(int program, int maxCount, out int count, out int shaders)
		{
			fixed (int* ptr = &count)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &shaders)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.UInt32*), program, maxCount, ptr2, ptr3, GL.EntryPoints[144]);
				}
			}
		}

		// Token: 0x06003720 RID: 14112 RVA: 0x00090750 File Offset: 0x0008E950
		[CLSCompliant(false)]
		public unsafe static void GetAttachedShaders(int program, int maxCount, [Out] int* count, [Out] int* shaders)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.UInt32*), program, maxCount, count, shaders, GL.EntryPoints[144]);
		}

		// Token: 0x06003721 RID: 14113 RVA: 0x00090768 File Offset: 0x0008E968
		[CLSCompliant(false)]
		public unsafe static void GetAttachedShaders(uint program, int maxCount, out int count, [Out] uint[] shaders)
		{
			fixed (int* ptr = &count)
			{
				int* ptr2 = ptr;
				fixed (uint* ptr3 = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.UInt32*), program, maxCount, ptr2, ptr3, GL.EntryPoints[144]);
				}
			}
		}

		// Token: 0x06003722 RID: 14114 RVA: 0x000907A4 File Offset: 0x0008E9A4
		[CLSCompliant(false)]
		public unsafe static void GetAttachedShaders(uint program, int maxCount, out int count, out uint shaders)
		{
			fixed (int* ptr = &count)
			{
				int* ptr2 = ptr;
				fixed (uint* ptr3 = &shaders)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.UInt32*), program, maxCount, ptr2, ptr3, GL.EntryPoints[144]);
				}
			}
		}

		// Token: 0x06003723 RID: 14115 RVA: 0x000907CC File Offset: 0x0008E9CC
		[CLSCompliant(false)]
		public unsafe static void GetAttachedShaders(uint program, int maxCount, [Out] int* count, [Out] uint* shaders)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.UInt32*), program, maxCount, count, shaders, GL.EntryPoints[144]);
		}

		// Token: 0x06003724 RID: 14116 RVA: 0x000907E4 File Offset: 0x0008E9E4
		[CLSCompliant(false)]
		public static int GetAttribLocation(int program, string name)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(name);
			int result = calli(System.Int32(System.UInt32,System.IntPtr), program, intPtr, GL.EntryPoints[145]);
			BindingsBase.FreeStringPtr(intPtr);
			return result;
		}

		// Token: 0x06003725 RID: 14117 RVA: 0x00090810 File Offset: 0x0008EA10
		[CLSCompliant(false)]
		public static int GetAttribLocation(uint program, string name)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(name);
			int result = calli(System.Int32(System.UInt32,System.IntPtr), program, intPtr, GL.EntryPoints[145]);
			BindingsBase.FreeStringPtr(intPtr);
			return result;
		}

		// Token: 0x06003726 RID: 14118 RVA: 0x0009083C File Offset: 0x0008EA3C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static bool GetBoolean(All pname)
		{
			bool result;
			calli(System.Void(System.Int32,System.Boolean*), pname, ref result, GL.EntryPoints[146]);
			return result;
		}

		// Token: 0x06003727 RID: 14119 RVA: 0x00090860 File Offset: 0x0008EA60
		[CLSCompliant(false)]
		public static bool GetBoolean(GetPName pname)
		{
			bool result;
			calli(System.Void(System.Int32,System.Boolean*), pname, ref result, GL.EntryPoints[146]);
			return result;
		}

		// Token: 0x06003728 RID: 14120 RVA: 0x00090884 File Offset: 0x0008EA84
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetBoolean(All pname, [Out] bool[] data)
		{
			fixed (bool* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Boolean*), pname, ptr, GL.EntryPoints[146]);
			}
		}

		// Token: 0x06003729 RID: 14121 RVA: 0x000908B8 File Offset: 0x0008EAB8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(All pname, out bool data)
		{
			fixed (bool* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Boolean*), pname, ptr, GL.EntryPoints[146]);
			}
		}

		// Token: 0x0600372A RID: 14122 RVA: 0x000908DC File Offset: 0x0008EADC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(All pname, [Out] bool* data)
		{
			calli(System.Void(System.Int32,System.Boolean*), pname, data, GL.EntryPoints[146]);
		}

		// Token: 0x0600372B RID: 14123 RVA: 0x000908F0 File Offset: 0x0008EAF0
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(GetPName pname, [Out] bool[] data)
		{
			fixed (bool* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Boolean*), pname, ptr, GL.EntryPoints[146]);
			}
		}

		// Token: 0x0600372C RID: 14124 RVA: 0x00090924 File Offset: 0x0008EB24
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(GetPName pname, out bool data)
		{
			fixed (bool* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Boolean*), pname, ptr, GL.EntryPoints[146]);
			}
		}

		// Token: 0x0600372D RID: 14125 RVA: 0x00090948 File Offset: 0x0008EB48
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(GetPName pname, [Out] bool* data)
		{
			calli(System.Void(System.Int32,System.Boolean*), pname, data, GL.EntryPoints[146]);
		}

		// Token: 0x0600372E RID: 14126 RVA: 0x0009095C File Offset: 0x0008EB5C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetBufferParameter(All target, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[147]);
			}
		}

		// Token: 0x0600372F RID: 14127 RVA: 0x00090994 File Offset: 0x0008EB94
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetBufferParameter(All target, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[147]);
			}
		}

		// Token: 0x06003730 RID: 14128 RVA: 0x000909B8 File Offset: 0x0008EBB8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetBufferParameter(All target, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[147]);
		}

		// Token: 0x06003731 RID: 14129 RVA: 0x000909D0 File Offset: 0x0008EBD0
		[CLSCompliant(false)]
		public unsafe static void GetBufferParameter(BufferTarget target, BufferParameterName pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[147]);
			}
		}

		// Token: 0x06003732 RID: 14130 RVA: 0x00090A08 File Offset: 0x0008EC08
		[CLSCompliant(false)]
		public unsafe static void GetBufferParameter(BufferTarget target, BufferParameterName pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[147]);
			}
		}

		// Token: 0x06003733 RID: 14131 RVA: 0x00090A2C File Offset: 0x0008EC2C
		[CLSCompliant(false)]
		public unsafe static void GetBufferParameter(BufferTarget target, BufferParameterName pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[147]);
		}

		// Token: 0x06003734 RID: 14132 RVA: 0x00090A44 File Offset: 0x0008EC44
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static int GetDebugMessageLog(int count, int bufSize, [Out] All[] sources, [Out] All[] types, [Out] int[] ids, [Out] All[] severities, [Out] int[] lengths, [Out] StringBuilder messageLog)
		{
			fixed (All* ptr = ref (sources != null && sources.Length != 0) ? ref sources[0] : ref *null)
			{
				All* ptr2 = ptr;
				fixed (All* ptr3 = ref (types != null && types.Length != 0) ? ref types[0] : ref *null)
				{
					All* ptr4 = ptr3;
					fixed (int* ptr5 = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
					{
						int* ptr6 = ptr5;
						fixed (All* ptr7 = ref (severities != null && severities.Length != 0) ? ref severities[0] : ref *null)
						{
							All* ptr8 = ptr7;
							fixed (int* ptr9 = ref (lengths != null && lengths.Length != 0) ? ref lengths[0] : ref *null)
							{
								int* ptr10 = ptr9;
								IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
								int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[149]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
								Marshal.FreeHGlobal(intPtr);
								return result;
							}
						}
					}
				}
			}
		}

		// Token: 0x06003735 RID: 14133 RVA: 0x00090AFC File Offset: 0x0008ECFC
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static int GetDebugMessageLog(int count, int bufSize, out All sources, out All types, out int ids, out All severities, out int lengths, [Out] StringBuilder messageLog)
		{
			fixed (All* ptr = &sources)
			{
				All* ptr2 = ptr;
				fixed (All* ptr3 = &types)
				{
					All* ptr4 = ptr3;
					fixed (int* ptr5 = &ids)
					{
						int* ptr6 = ptr5;
						fixed (All* ptr7 = &severities)
						{
							All* ptr8 = ptr7;
							fixed (int* ptr9 = &lengths)
							{
								int* ptr10 = ptr9;
								IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
								int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[149]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
								Marshal.FreeHGlobal(intPtr);
								return result;
							}
						}
					}
				}
			}
		}

		// Token: 0x06003736 RID: 14134 RVA: 0x00090B54 File Offset: 0x0008ED54
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(int count, int bufSize, [Out] All* sources, [Out] All* types, [Out] int* ids, [Out] All* severities, [Out] int* lengths, [Out] StringBuilder messageLog)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
			int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, sources, types, ids, severities, lengths, intPtr, GL.EntryPoints[149]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06003737 RID: 14135 RVA: 0x00090B98 File Offset: 0x0008ED98
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(int count, int bufSize, [Out] DebugSourceExternal[] sources, [Out] DebugType[] types, [Out] int[] ids, [Out] DebugSeverity[] severities, [Out] int[] lengths, [Out] StringBuilder messageLog)
		{
			fixed (DebugSourceExternal* ptr = ref (sources != null && sources.Length != 0) ? ref sources[0] : ref *null)
			{
				DebugSourceExternal* ptr2 = ptr;
				fixed (DebugType* ptr3 = ref (types != null && types.Length != 0) ? ref types[0] : ref *null)
				{
					DebugType* ptr4 = ptr3;
					fixed (int* ptr5 = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
					{
						int* ptr6 = ptr5;
						fixed (DebugSeverity* ptr7 = ref (severities != null && severities.Length != 0) ? ref severities[0] : ref *null)
						{
							DebugSeverity* ptr8 = ptr7;
							fixed (int* ptr9 = ref (lengths != null && lengths.Length != 0) ? ref lengths[0] : ref *null)
							{
								int* ptr10 = ptr9;
								IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
								int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[149]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
								Marshal.FreeHGlobal(intPtr);
								return result;
							}
						}
					}
				}
			}
		}

		// Token: 0x06003738 RID: 14136 RVA: 0x00090C50 File Offset: 0x0008EE50
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(int count, int bufSize, out DebugSourceExternal sources, out DebugType types, out int ids, out DebugSeverity severities, out int lengths, [Out] StringBuilder messageLog)
		{
			fixed (DebugSourceExternal* ptr = &sources)
			{
				DebugSourceExternal* ptr2 = ptr;
				fixed (DebugType* ptr3 = &types)
				{
					DebugType* ptr4 = ptr3;
					fixed (int* ptr5 = &ids)
					{
						int* ptr6 = ptr5;
						fixed (DebugSeverity* ptr7 = &severities)
						{
							DebugSeverity* ptr8 = ptr7;
							fixed (int* ptr9 = &lengths)
							{
								int* ptr10 = ptr9;
								IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
								int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[149]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
								Marshal.FreeHGlobal(intPtr);
								return result;
							}
						}
					}
				}
			}
		}

		// Token: 0x06003739 RID: 14137 RVA: 0x00090CA8 File Offset: 0x0008EEA8
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(int count, int bufSize, [Out] DebugSourceExternal* sources, [Out] DebugType* types, [Out] int* ids, [Out] DebugSeverity* severities, [Out] int* lengths, [Out] StringBuilder messageLog)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
			int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, sources, types, ids, severities, lengths, intPtr, GL.EntryPoints[149]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x0600373A RID: 14138 RVA: 0x00090CEC File Offset: 0x0008EEEC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(uint count, int bufSize, [Out] All[] sources, [Out] All[] types, [Out] uint[] ids, [Out] All[] severities, [Out] int[] lengths, [Out] StringBuilder messageLog)
		{
			fixed (All* ptr = ref (sources != null && sources.Length != 0) ? ref sources[0] : ref *null)
			{
				All* ptr2 = ptr;
				fixed (All* ptr3 = ref (types != null && types.Length != 0) ? ref types[0] : ref *null)
				{
					All* ptr4 = ptr3;
					fixed (uint* ptr5 = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
					{
						uint* ptr6 = ptr5;
						fixed (All* ptr7 = ref (severities != null && severities.Length != 0) ? ref severities[0] : ref *null)
						{
							All* ptr8 = ptr7;
							fixed (int* ptr9 = ref (lengths != null && lengths.Length != 0) ? ref lengths[0] : ref *null)
							{
								int* ptr10 = ptr9;
								IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
								int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[149]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
								Marshal.FreeHGlobal(intPtr);
								return result;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600373B RID: 14139 RVA: 0x00090DA4 File Offset: 0x0008EFA4
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static int GetDebugMessageLog(uint count, int bufSize, out All sources, out All types, out uint ids, out All severities, out int lengths, [Out] StringBuilder messageLog)
		{
			fixed (All* ptr = &sources)
			{
				All* ptr2 = ptr;
				fixed (All* ptr3 = &types)
				{
					All* ptr4 = ptr3;
					fixed (uint* ptr5 = &ids)
					{
						uint* ptr6 = ptr5;
						fixed (All* ptr7 = &severities)
						{
							All* ptr8 = ptr7;
							fixed (int* ptr9 = &lengths)
							{
								int* ptr10 = ptr9;
								IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
								int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[149]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
								Marshal.FreeHGlobal(intPtr);
								return result;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600373C RID: 14140 RVA: 0x00090DFC File Offset: 0x0008EFFC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(uint count, int bufSize, [Out] All* sources, [Out] All* types, [Out] uint* ids, [Out] All* severities, [Out] int* lengths, [Out] StringBuilder messageLog)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
			int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, sources, types, ids, severities, lengths, intPtr, GL.EntryPoints[149]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x0600373D RID: 14141 RVA: 0x00090E40 File Offset: 0x0008F040
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(uint count, int bufSize, [Out] DebugSourceExternal[] sources, [Out] DebugType[] types, [Out] uint[] ids, [Out] DebugSeverity[] severities, [Out] int[] lengths, [Out] StringBuilder messageLog)
		{
			fixed (DebugSourceExternal* ptr = ref (sources != null && sources.Length != 0) ? ref sources[0] : ref *null)
			{
				DebugSourceExternal* ptr2 = ptr;
				fixed (DebugType* ptr3 = ref (types != null && types.Length != 0) ? ref types[0] : ref *null)
				{
					DebugType* ptr4 = ptr3;
					fixed (uint* ptr5 = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
					{
						uint* ptr6 = ptr5;
						fixed (DebugSeverity* ptr7 = ref (severities != null && severities.Length != 0) ? ref severities[0] : ref *null)
						{
							DebugSeverity* ptr8 = ptr7;
							fixed (int* ptr9 = ref (lengths != null && lengths.Length != 0) ? ref lengths[0] : ref *null)
							{
								int* ptr10 = ptr9;
								IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
								int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[149]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
								Marshal.FreeHGlobal(intPtr);
								return result;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600373E RID: 14142 RVA: 0x00090EF8 File Offset: 0x0008F0F8
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(uint count, int bufSize, out DebugSourceExternal sources, out DebugType types, out uint ids, out DebugSeverity severities, out int lengths, [Out] StringBuilder messageLog)
		{
			fixed (DebugSourceExternal* ptr = &sources)
			{
				DebugSourceExternal* ptr2 = ptr;
				fixed (DebugType* ptr3 = &types)
				{
					DebugType* ptr4 = ptr3;
					fixed (uint* ptr5 = &ids)
					{
						uint* ptr6 = ptr5;
						fixed (DebugSeverity* ptr7 = &severities)
						{
							DebugSeverity* ptr8 = ptr7;
							fixed (int* ptr9 = &lengths)
							{
								int* ptr10 = ptr9;
								IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
								int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[149]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
								Marshal.FreeHGlobal(intPtr);
								return result;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600373F RID: 14143 RVA: 0x00090F50 File Offset: 0x0008F150
		[CLSCompliant(false)]
		public unsafe static int GetDebugMessageLog(uint count, int bufSize, [Out] DebugSourceExternal* sources, [Out] DebugType* types, [Out] uint* ids, [Out] DebugSeverity* severities, [Out] int* lengths, [Out] StringBuilder messageLog)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
			int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, sources, types, ids, severities, lengths, intPtr, GL.EntryPoints[149]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x06003740 RID: 14144 RVA: 0x00090F94 File Offset: 0x0008F194
		public static ErrorCode GetError()
		{
			return calli(System.Int32(), GL.EntryPoints[153]);
		}

		// Token: 0x06003741 RID: 14145 RVA: 0x00090FA8 File Offset: 0x0008F1A8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static float GetFloat(All pname)
		{
			float result;
			calli(System.Void(System.Int32,System.Single*), pname, ref result, GL.EntryPoints[156]);
			return result;
		}

		// Token: 0x06003742 RID: 14146 RVA: 0x00090FCC File Offset: 0x0008F1CC
		[CLSCompliant(false)]
		public static float GetFloat(GetPName pname)
		{
			float result;
			calli(System.Void(System.Int32,System.Single*), pname, ref result, GL.EntryPoints[156]);
			return result;
		}

		// Token: 0x06003743 RID: 14147 RVA: 0x00090FF0 File Offset: 0x0008F1F0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetFloat(All pname, [Out] float[] data)
		{
			fixed (float* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[156]);
			}
		}

		// Token: 0x06003744 RID: 14148 RVA: 0x00091024 File Offset: 0x0008F224
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetFloat(All pname, out float data)
		{
			fixed (float* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[156]);
			}
		}

		// Token: 0x06003745 RID: 14149 RVA: 0x00091048 File Offset: 0x0008F248
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetFloat(All pname, [Out] float* data)
		{
			calli(System.Void(System.Int32,System.Single*), pname, data, GL.EntryPoints[156]);
		}

		// Token: 0x06003746 RID: 14150 RVA: 0x0009105C File Offset: 0x0008F25C
		[CLSCompliant(false)]
		public unsafe static void GetFloat(GetPName pname, [Out] float[] data)
		{
			fixed (float* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[156]);
			}
		}

		// Token: 0x06003747 RID: 14151 RVA: 0x00091090 File Offset: 0x0008F290
		[CLSCompliant(false)]
		public unsafe static void GetFloat(GetPName pname, out float data)
		{
			fixed (float* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[156]);
			}
		}

		// Token: 0x06003748 RID: 14152 RVA: 0x000910B4 File Offset: 0x0008F2B4
		[CLSCompliant(false)]
		public unsafe static void GetFloat(GetPName pname, [Out] float* data)
		{
			calli(System.Void(System.Int32,System.Single*), pname, data, GL.EntryPoints[156]);
		}

		// Token: 0x06003749 RID: 14153 RVA: 0x000910C8 File Offset: 0x0008F2C8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetFramebufferAttachmentParameter(All target, All attachment, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, ptr, GL.EntryPoints[157]);
			}
		}

		// Token: 0x0600374A RID: 14154 RVA: 0x00091100 File Offset: 0x0008F300
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetFramebufferAttachmentParameter(All target, All attachment, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, ptr, GL.EntryPoints[157]);
			}
		}

		// Token: 0x0600374B RID: 14155 RVA: 0x00091124 File Offset: 0x0008F324
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetFramebufferAttachmentParameter(All target, All attachment, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, @params, GL.EntryPoints[157]);
		}

		// Token: 0x0600374C RID: 14156 RVA: 0x0009113C File Offset: 0x0008F33C
		[CLSCompliant(false)]
		public unsafe static void GetFramebufferAttachmentParameter(FramebufferTarget target, All attachment, FramebufferParameterName pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, ptr, GL.EntryPoints[157]);
			}
		}

		// Token: 0x0600374D RID: 14157 RVA: 0x00091174 File Offset: 0x0008F374
		[CLSCompliant(false)]
		public unsafe static void GetFramebufferAttachmentParameter(FramebufferTarget target, All attachment, FramebufferParameterName pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, ptr, GL.EntryPoints[157]);
			}
		}

		// Token: 0x0600374E RID: 14158 RVA: 0x00091198 File Offset: 0x0008F398
		[CLSCompliant(false)]
		public unsafe static void GetFramebufferAttachmentParameter(FramebufferTarget target, All attachment, FramebufferParameterName pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, @params, GL.EntryPoints[157]);
		}

		// Token: 0x0600374F RID: 14159 RVA: 0x000911B0 File Offset: 0x0008F3B0
		[CLSCompliant(false)]
		[Obsolete("Use FramebufferAttachment overload instead")]
		public unsafe static void GetFramebufferAttachmentParameter(FramebufferTarget target, FramebufferSlot attachment, FramebufferParameterName pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, ptr, GL.EntryPoints[157]);
			}
		}

		// Token: 0x06003750 RID: 14160 RVA: 0x000911E8 File Offset: 0x0008F3E8
		[Obsolete("Use FramebufferAttachment overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetFramebufferAttachmentParameter(FramebufferTarget target, FramebufferSlot attachment, FramebufferParameterName pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, ptr, GL.EntryPoints[157]);
			}
		}

		// Token: 0x06003751 RID: 14161 RVA: 0x0009120C File Offset: 0x0008F40C
		[Obsolete("Use FramebufferAttachment overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetFramebufferAttachmentParameter(FramebufferTarget target, FramebufferSlot attachment, FramebufferParameterName pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, @params, GL.EntryPoints[157]);
		}

		// Token: 0x06003752 RID: 14162 RVA: 0x00091224 File Offset: 0x0008F424
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static int GetInteger(All pname)
		{
			int result;
			calli(System.Void(System.Int32,System.Int32*), pname, ref result, GL.EntryPoints[161]);
			return result;
		}

		// Token: 0x06003753 RID: 14163 RVA: 0x00091248 File Offset: 0x0008F448
		[CLSCompliant(false)]
		public static int GetInteger(GetPName pname)
		{
			int result;
			calli(System.Void(System.Int32,System.Int32*), pname, ref result, GL.EntryPoints[161]);
			return result;
		}

		// Token: 0x06003754 RID: 14164 RVA: 0x0009126C File Offset: 0x0008F46C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetInteger(All pname, [Out] int[] data)
		{
			fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[161]);
			}
		}

		// Token: 0x06003755 RID: 14165 RVA: 0x000912A0 File Offset: 0x0008F4A0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetInteger(All pname, out int data)
		{
			fixed (int* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[161]);
			}
		}

		// Token: 0x06003756 RID: 14166 RVA: 0x000912C4 File Offset: 0x0008F4C4
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetInteger(All pname, [Out] int* data)
		{
			calli(System.Void(System.Int32,System.Int32*), pname, data, GL.EntryPoints[161]);
		}

		// Token: 0x06003757 RID: 14167 RVA: 0x000912D8 File Offset: 0x0008F4D8
		[CLSCompliant(false)]
		public unsafe static void GetInteger(GetPName pname, [Out] int[] data)
		{
			fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[161]);
			}
		}

		// Token: 0x06003758 RID: 14168 RVA: 0x0009130C File Offset: 0x0008F50C
		[CLSCompliant(false)]
		public unsafe static void GetInteger(GetPName pname, out int data)
		{
			fixed (int* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[161]);
			}
		}

		// Token: 0x06003759 RID: 14169 RVA: 0x00091330 File Offset: 0x0008F530
		[CLSCompliant(false)]
		public unsafe static void GetInteger(GetPName pname, [Out] int* data)
		{
			calli(System.Void(System.Int32,System.Int32*), pname, data, GL.EntryPoints[161]);
		}

		// Token: 0x0600375A RID: 14170 RVA: 0x00091344 File Offset: 0x0008F544
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetObjectLabel(All identifier, int name, int bufSize, [Out] int[] length, [Out] StringBuilder label)
		{
			fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[165]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0600375B RID: 14171 RVA: 0x00091398 File Offset: 0x0008F598
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetObjectLabel(All identifier, int name, int bufSize, out int length, [Out] StringBuilder label)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[165]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0600375C RID: 14172 RVA: 0x000913D8 File Offset: 0x0008F5D8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetObjectLabel(All identifier, int name, int bufSize, [Out] int* length, [Out] StringBuilder label)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, length, intPtr, GL.EntryPoints[165]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600375D RID: 14173 RVA: 0x00091418 File Offset: 0x0008F618
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetObjectLabel(All identifier, uint name, int bufSize, [Out] int[] length, [Out] StringBuilder label)
		{
			fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[165]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0600375E RID: 14174 RVA: 0x0009146C File Offset: 0x0008F66C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectLabel(All identifier, uint name, int bufSize, out int length, [Out] StringBuilder label)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[165]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0600375F RID: 14175 RVA: 0x000914AC File Offset: 0x0008F6AC
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetObjectLabel(All identifier, uint name, int bufSize, [Out] int* length, [Out] StringBuilder label)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, length, intPtr, GL.EntryPoints[165]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003760 RID: 14176 RVA: 0x000914EC File Offset: 0x0008F6EC
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, int name, int bufSize, [Out] int[] length, [Out] StringBuilder label)
		{
			fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[165]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003761 RID: 14177 RVA: 0x00091540 File Offset: 0x0008F740
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, int name, int bufSize, out int length, [Out] StringBuilder label)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[165]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003762 RID: 14178 RVA: 0x00091580 File Offset: 0x0008F780
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, int name, int bufSize, [Out] int* length, [Out] StringBuilder label)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, length, intPtr, GL.EntryPoints[165]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003763 RID: 14179 RVA: 0x000915C0 File Offset: 0x0008F7C0
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, int bufSize, [Out] int[] length, [Out] StringBuilder label)
		{
			fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[165]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003764 RID: 14180 RVA: 0x00091614 File Offset: 0x0008F814
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, int bufSize, out int length, [Out] StringBuilder label)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[165]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003765 RID: 14181 RVA: 0x00091654 File Offset: 0x0008F854
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, int bufSize, [Out] int* length, [Out] StringBuilder label)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, length, intPtr, GL.EntryPoints[165]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003766 RID: 14182 RVA: 0x00091694 File Offset: 0x0008F894
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectPtrLabel(IntPtr ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label)
		{
			fixed (int* ptr2 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
			{
				int* ptr3 = ptr2;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr, bufSize, ptr3, intPtr, GL.EntryPoints[168]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003767 RID: 14183 RVA: 0x000916E4 File Offset: 0x0008F8E4
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length, [Out] StringBuilder label)
		{
			fixed (int* ptr2 = &length)
			{
				int* ptr3 = ptr2;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr, bufSize, ptr3, intPtr, GL.EntryPoints[168]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003768 RID: 14184 RVA: 0x00091724 File Offset: 0x0008F924
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectPtrLabel(IntPtr ptr, int bufSize, [Out] int* length, [Out] StringBuilder label)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
			calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr, bufSize, length, intPtr, GL.EntryPoints[168]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003769 RID: 14185 RVA: 0x00091760 File Offset: 0x0008F960
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[] ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0] : ref *null)
			{
				T0* ptr3 = ptr2;
				fixed (int* ptr4 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr5 = ptr4;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[168]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x0600376A RID: 14186 RVA: 0x000917C4 File Offset: 0x0008F9C4
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[] ptr, int bufSize, out int length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0] : ref *null)
			{
				T0* ptr3 = ptr2;
				fixed (int* ptr4 = &length)
				{
					int* ptr5 = ptr4;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[168]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x0600376B RID: 14187 RVA: 0x00091818 File Offset: 0x0008FA18
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[] ptr, int bufSize, [Out] int* length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0] : ref *null)
			{
				T0* ptr3 = ptr2;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, length, intPtr, GL.EntryPoints[168]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0600376C RID: 14188 RVA: 0x00091868 File Offset: 0x0008FA68
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,] ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0] : ref *null)
			{
				T0* ptr3 = ptr2;
				fixed (int* ptr4 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr5 = ptr4;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[168]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x0600376D RID: 14189 RVA: 0x000918D0 File Offset: 0x0008FAD0
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,] ptr, int bufSize, out int length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0] : ref *null)
			{
				T0* ptr3 = ptr2;
				fixed (int* ptr4 = &length)
				{
					int* ptr5 = ptr4;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[168]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x0600376E RID: 14190 RVA: 0x00091928 File Offset: 0x0008FB28
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,] ptr, int bufSize, [Out] int* length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0] : ref *null)
			{
				T0* ptr3 = ptr2;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, length, intPtr, GL.EntryPoints[168]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0600376F RID: 14191 RVA: 0x0009197C File Offset: 0x0008FB7C
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,,] ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0, 0] : ref *null)
			{
				T0* ptr3 = ptr2;
				fixed (int* ptr4 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr5 = ptr4;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[168]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x06003770 RID: 14192 RVA: 0x000919E8 File Offset: 0x0008FBE8
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,,] ptr, int bufSize, out int length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0, 0] : ref *null)
			{
				T0* ptr3 = ptr2;
				fixed (int* ptr4 = &length)
				{
					int* ptr5 = ptr4;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[168]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x06003771 RID: 14193 RVA: 0x00091A40 File Offset: 0x0008FC40
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,,] ptr, int bufSize, [Out] int* length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0, 0] : ref *null)
			{
				T0* ptr3 = ptr2;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, length, intPtr, GL.EntryPoints[168]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003772 RID: 14194 RVA: 0x00091A94 File Offset: 0x0008FC94
		[CLSCompliant(false)]
		[Obsolete("Use out overload instead")]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] ref T0 ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = &ptr)
			{
				T0* ptr3 = ptr2;
				fixed (int* ptr4 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr5 = ptr4;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[168]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x06003773 RID: 14195 RVA: 0x00091AE8 File Offset: 0x0008FCE8
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] ref T0 ptr, int bufSize, out int length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = &ptr)
			{
				T0* ptr3 = ptr2;
				fixed (int* ptr4 = &length)
				{
					int* ptr5 = ptr4;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[168]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}

		// Token: 0x06003774 RID: 14196 RVA: 0x00091B28 File Offset: 0x0008FD28
		[Obsolete("Use out overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetObjectPtrLabel<T0>([In] [Out] ref T0 ptr, int bufSize, [Out] int* length, [Out] StringBuilder label) where T0 : struct
		{
			fixed (T0* ptr2 = &ptr)
			{
				T0* ptr3 = ptr2;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, length, intPtr, GL.EntryPoints[168]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003775 RID: 14197 RVA: 0x00091B68 File Offset: 0x0008FD68
		[Obsolete("Use strongly-typed overload instead")]
		public static void GetPointer(All pname, [Out] IntPtr @params)
		{
			calli(System.Void(System.Int32,System.IntPtr), pname, @params, GL.EntryPoints[180]);
		}

		// Token: 0x06003776 RID: 14198 RVA: 0x00091B7C File Offset: 0x0008FD7C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[180]);
			}
		}

		// Token: 0x06003777 RID: 14199 RVA: 0x00091BB0 File Offset: 0x0008FDB0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[,] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[180]);
			}
		}

		// Token: 0x06003778 RID: 14200 RVA: 0x00091BE8 File Offset: 0x0008FDE8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[,,] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[180]);
			}
		}

		// Token: 0x06003779 RID: 14201 RVA: 0x00091C24 File Offset: 0x0008FE24
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetPointer<T1>(All pname, [In] [Out] ref T1 @params) where T1 : struct
		{
			fixed (T1* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[180]);
			}
		}

		// Token: 0x0600377A RID: 14202 RVA: 0x00091C48 File Offset: 0x0008FE48
		public static void GetPointer(GetPointervPName pname, [Out] IntPtr @params)
		{
			calli(System.Void(System.Int32,System.IntPtr), pname, @params, GL.EntryPoints[180]);
		}

		// Token: 0x0600377B RID: 14203 RVA: 0x00091C5C File Offset: 0x0008FE5C
		[CLSCompliant(false)]
		public unsafe static void GetPointer<T1>(GetPointervPName pname, [In] [Out] T1[] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[180]);
			}
		}

		// Token: 0x0600377C RID: 14204 RVA: 0x00091C90 File Offset: 0x0008FE90
		[CLSCompliant(false)]
		public unsafe static void GetPointer<T1>(GetPointervPName pname, [In] [Out] T1[,] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[180]);
			}
		}

		// Token: 0x0600377D RID: 14205 RVA: 0x00091CC8 File Offset: 0x0008FEC8
		[CLSCompliant(false)]
		public unsafe static void GetPointer<T1>(GetPointervPName pname, [In] [Out] T1[,,] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[180]);
			}
		}

		// Token: 0x0600377E RID: 14206 RVA: 0x00091D04 File Offset: 0x0008FF04
		public unsafe static void GetPointer<T1>(GetPointervPName pname, [In] [Out] ref T1 @params) where T1 : struct
		{
			fixed (T1* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[180]);
			}
		}

		// Token: 0x0600377F RID: 14207 RVA: 0x00091D28 File Offset: 0x0008FF28
		[CLSCompliant(false)]
		public unsafe static void GetProgramInfoLog(int program, int bufSize, out int length, [Out] StringBuilder infoLog)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), program, bufSize, ptr2, intPtr, GL.EntryPoints[183]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003780 RID: 14208 RVA: 0x00091D68 File Offset: 0x0008FF68
		[CLSCompliant(false)]
		public unsafe static void GetProgramInfoLog(int program, int bufSize, [Out] int* length, [Out] StringBuilder infoLog)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
			calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), program, bufSize, length, intPtr, GL.EntryPoints[183]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003781 RID: 14209 RVA: 0x00091DA4 File Offset: 0x0008FFA4
		[CLSCompliant(false)]
		public unsafe static void GetProgramInfoLog(uint program, int bufSize, out int length, [Out] StringBuilder infoLog)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), program, bufSize, ptr2, intPtr, GL.EntryPoints[183]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x06003782 RID: 14210 RVA: 0x00091DE4 File Offset: 0x0008FFE4
		[CLSCompliant(false)]
		public unsafe static void GetProgramInfoLog(uint program, int bufSize, [Out] int* length, [Out] StringBuilder infoLog)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
			calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), program, bufSize, length, intPtr, GL.EntryPoints[183]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x06003783 RID: 14211 RVA: 0x00091E20 File Offset: 0x00090020
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetProgram(int program, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x06003784 RID: 14212 RVA: 0x00091E58 File Offset: 0x00090058
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetProgram(int program, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x06003785 RID: 14213 RVA: 0x00091E7C File Offset: 0x0009007C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetProgram(int program, All pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, @params, GL.EntryPoints[184]);
		}

		// Token: 0x06003786 RID: 14214 RVA: 0x00091E94 File Offset: 0x00090094
		[CLSCompliant(false)]
		public unsafe static void GetProgram(int program, GetProgramParameterName pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x06003787 RID: 14215 RVA: 0x00091ECC File Offset: 0x000900CC
		[CLSCompliant(false)]
		public unsafe static void GetProgram(int program, GetProgramParameterName pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x06003788 RID: 14216 RVA: 0x00091EF0 File Offset: 0x000900F0
		[CLSCompliant(false)]
		public unsafe static void GetProgram(int program, GetProgramParameterName pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, @params, GL.EntryPoints[184]);
		}

		// Token: 0x06003789 RID: 14217 RVA: 0x00091F08 File Offset: 0x00090108
		[CLSCompliant(false)]
		[Obsolete("Use GetProgramParameterName overload instead")]
		public unsafe static void GetProgram(int program, ProgramParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x0600378A RID: 14218 RVA: 0x00091F40 File Offset: 0x00090140
		[Obsolete("Use GetProgramParameterName overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetProgram(int program, ProgramParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x0600378B RID: 14219 RVA: 0x00091F64 File Offset: 0x00090164
		[Obsolete("Use GetProgramParameterName overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetProgram(int program, ProgramParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, @params, GL.EntryPoints[184]);
		}

		// Token: 0x0600378C RID: 14220 RVA: 0x00091F7C File Offset: 0x0009017C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetProgram(uint program, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x0600378D RID: 14221 RVA: 0x00091FB4 File Offset: 0x000901B4
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetProgram(uint program, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x0600378E RID: 14222 RVA: 0x00091FD8 File Offset: 0x000901D8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetProgram(uint program, All pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, @params, GL.EntryPoints[184]);
		}

		// Token: 0x0600378F RID: 14223 RVA: 0x00091FF0 File Offset: 0x000901F0
		[CLSCompliant(false)]
		public unsafe static void GetProgram(uint program, GetProgramParameterName pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x06003790 RID: 14224 RVA: 0x00092028 File Offset: 0x00090228
		[CLSCompliant(false)]
		public unsafe static void GetProgram(uint program, GetProgramParameterName pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x06003791 RID: 14225 RVA: 0x0009204C File Offset: 0x0009024C
		[CLSCompliant(false)]
		public unsafe static void GetProgram(uint program, GetProgramParameterName pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, @params, GL.EntryPoints[184]);
		}

		// Token: 0x06003792 RID: 14226 RVA: 0x00092064 File Offset: 0x00090264
		[Obsolete("Use GetProgramParameterName overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetProgram(uint program, ProgramParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x06003793 RID: 14227 RVA: 0x0009209C File Offset: 0x0009029C
		[Obsolete("Use GetProgramParameterName overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetProgram(uint program, ProgramParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, ptr, GL.EntryPoints[184]);
			}
		}

		// Token: 0x06003794 RID: 14228 RVA: 0x000920C0 File Offset: 0x000902C0
		[CLSCompliant(false)]
		[Obsolete("Use GetProgramParameterName overload instead")]
		public unsafe static void GetProgram(uint program, ProgramParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, pname, @params, GL.EntryPoints[184]);
		}

		// Token: 0x06003795 RID: 14229 RVA: 0x000920D8 File Offset: 0x000902D8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetRenderbufferParameter(All target, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[192]);
			}
		}

		// Token: 0x06003796 RID: 14230 RVA: 0x00092110 File Offset: 0x00090310
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetRenderbufferParameter(All target, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[192]);
			}
		}

		// Token: 0x06003797 RID: 14231 RVA: 0x00092134 File Offset: 0x00090334
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetRenderbufferParameter(All target, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[192]);
		}

		// Token: 0x06003798 RID: 14232 RVA: 0x0009214C File Offset: 0x0009034C
		[CLSCompliant(false)]
		public unsafe static void GetRenderbufferParameter(RenderbufferTarget target, RenderbufferParameterName pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[192]);
			}
		}

		// Token: 0x06003799 RID: 14233 RVA: 0x00092184 File Offset: 0x00090384
		[CLSCompliant(false)]
		public unsafe static void GetRenderbufferParameter(RenderbufferTarget target, RenderbufferParameterName pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[192]);
			}
		}

		// Token: 0x0600379A RID: 14234 RVA: 0x000921A8 File Offset: 0x000903A8
		[CLSCompliant(false)]
		public unsafe static void GetRenderbufferParameter(RenderbufferTarget target, RenderbufferParameterName pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[192]);
		}

		// Token: 0x0600379B RID: 14235 RVA: 0x000921C0 File Offset: 0x000903C0
		[CLSCompliant(false)]
		public unsafe static void GetShaderInfoLog(int shader, int bufSize, out int length, [Out] StringBuilder infoLog)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufSize, ptr2, intPtr, GL.EntryPoints[195]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0600379C RID: 14236 RVA: 0x00092200 File Offset: 0x00090400
		[CLSCompliant(false)]
		public unsafe static void GetShaderInfoLog(int shader, int bufSize, [Out] int* length, [Out] StringBuilder infoLog)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
			calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufSize, length, intPtr, GL.EntryPoints[195]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600379D RID: 14237 RVA: 0x0009223C File Offset: 0x0009043C
		[CLSCompliant(false)]
		public unsafe static void GetShaderInfoLog(uint shader, int bufSize, out int length, [Out] StringBuilder infoLog)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufSize, ptr2, intPtr, GL.EntryPoints[195]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0600379E RID: 14238 RVA: 0x0009227C File Offset: 0x0009047C
		[CLSCompliant(false)]
		public unsafe static void GetShaderInfoLog(uint shader, int bufSize, [Out] int* length, [Out] StringBuilder infoLog)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
			calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufSize, length, intPtr, GL.EntryPoints[195]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600379F RID: 14239 RVA: 0x000922B8 File Offset: 0x000904B8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetShader(int shader, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, ptr, GL.EntryPoints[196]);
			}
		}

		// Token: 0x060037A0 RID: 14240 RVA: 0x000922F0 File Offset: 0x000904F0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetShader(int shader, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, ptr, GL.EntryPoints[196]);
			}
		}

		// Token: 0x060037A1 RID: 14241 RVA: 0x00092314 File Offset: 0x00090514
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetShader(int shader, All pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, @params, GL.EntryPoints[196]);
		}

		// Token: 0x060037A2 RID: 14242 RVA: 0x0009232C File Offset: 0x0009052C
		[CLSCompliant(false)]
		public unsafe static void GetShader(int shader, ShaderParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, ptr, GL.EntryPoints[196]);
			}
		}

		// Token: 0x060037A3 RID: 14243 RVA: 0x00092364 File Offset: 0x00090564
		[CLSCompliant(false)]
		public unsafe static void GetShader(int shader, ShaderParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, ptr, GL.EntryPoints[196]);
			}
		}

		// Token: 0x060037A4 RID: 14244 RVA: 0x00092388 File Offset: 0x00090588
		[CLSCompliant(false)]
		public unsafe static void GetShader(int shader, ShaderParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, @params, GL.EntryPoints[196]);
		}

		// Token: 0x060037A5 RID: 14245 RVA: 0x000923A0 File Offset: 0x000905A0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetShader(uint shader, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, ptr, GL.EntryPoints[196]);
			}
		}

		// Token: 0x060037A6 RID: 14246 RVA: 0x000923D8 File Offset: 0x000905D8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetShader(uint shader, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, ptr, GL.EntryPoints[196]);
			}
		}

		// Token: 0x060037A7 RID: 14247 RVA: 0x000923FC File Offset: 0x000905FC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetShader(uint shader, All pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, @params, GL.EntryPoints[196]);
		}

		// Token: 0x060037A8 RID: 14248 RVA: 0x00092414 File Offset: 0x00090614
		[CLSCompliant(false)]
		public unsafe static void GetShader(uint shader, ShaderParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, ptr, GL.EntryPoints[196]);
			}
		}

		// Token: 0x060037A9 RID: 14249 RVA: 0x0009244C File Offset: 0x0009064C
		[CLSCompliant(false)]
		public unsafe static void GetShader(uint shader, ShaderParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, ptr, GL.EntryPoints[196]);
			}
		}

		// Token: 0x060037AA RID: 14250 RVA: 0x00092470 File Offset: 0x00090670
		[CLSCompliant(false)]
		public unsafe static void GetShader(uint shader, ShaderParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), shader, pname, @params, GL.EntryPoints[196]);
		}

		// Token: 0x060037AB RID: 14251 RVA: 0x00092488 File Offset: 0x00090688
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetShaderPrecisionFormat(All shadertype, All precisiontype, [Out] int[] range, [Out] int[] precision)
		{
			fixed (int* ptr = ref (range != null && range.Length != 0) ? ref range[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = ref (precision != null && precision.Length != 0) ? ref precision[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*,System.Int32*), shadertype, precisiontype, ptr2, ptr3, GL.EntryPoints[197]);
				}
			}
		}

		// Token: 0x060037AC RID: 14252 RVA: 0x000924D4 File Offset: 0x000906D4
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetShaderPrecisionFormat(All shadertype, All precisiontype, out int range, out int precision)
		{
			fixed (int* ptr = &range)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &precision)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*,System.Int32*), shadertype, precisiontype, ptr2, ptr3, GL.EntryPoints[197]);
				}
			}
		}

		// Token: 0x060037AD RID: 14253 RVA: 0x000924FC File Offset: 0x000906FC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetShaderPrecisionFormat(All shadertype, All precisiontype, [Out] int* range, [Out] int* precision)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*,System.Int32*), shadertype, precisiontype, range, precision, GL.EntryPoints[197]);
		}

		// Token: 0x060037AE RID: 14254 RVA: 0x00092514 File Offset: 0x00090714
		[CLSCompliant(false)]
		public unsafe static void GetShaderPrecisionFormat(ShaderType shadertype, ShaderPrecision precisiontype, [Out] int[] range, [Out] int[] precision)
		{
			fixed (int* ptr = ref (range != null && range.Length != 0) ? ref range[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = ref (precision != null && precision.Length != 0) ? ref precision[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*,System.Int32*), shadertype, precisiontype, ptr2, ptr3, GL.EntryPoints[197]);
				}
			}
		}

		// Token: 0x060037AF RID: 14255 RVA: 0x00092560 File Offset: 0x00090760
		[CLSCompliant(false)]
		public unsafe static void GetShaderPrecisionFormat(ShaderType shadertype, ShaderPrecision precisiontype, out int range, out int precision)
		{
			fixed (int* ptr = &range)
			{
				int* ptr2 = ptr;
				fixed (int* ptr3 = &precision)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*,System.Int32*), shadertype, precisiontype, ptr2, ptr3, GL.EntryPoints[197]);
				}
			}
		}

		// Token: 0x060037B0 RID: 14256 RVA: 0x00092588 File Offset: 0x00090788
		[CLSCompliant(false)]
		public unsafe static void GetShaderPrecisionFormat(ShaderType shadertype, ShaderPrecision precisiontype, [Out] int* range, [Out] int* precision)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*,System.Int32*), shadertype, precisiontype, range, precision, GL.EntryPoints[197]);
		}

		// Token: 0x060037B1 RID: 14257 RVA: 0x000925A0 File Offset: 0x000907A0
		[CLSCompliant(false)]
		public unsafe static void GetShaderSource(int shader, int bufSize, out int length, [Out] StringBuilder source)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufSize, ptr2, intPtr, GL.EntryPoints[198]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x060037B2 RID: 14258 RVA: 0x000925E0 File Offset: 0x000907E0
		[CLSCompliant(false)]
		public unsafe static void GetShaderSource(int shader, int bufSize, [Out] int* length, [Out] StringBuilder source)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
			calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufSize, length, intPtr, GL.EntryPoints[198]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x060037B3 RID: 14259 RVA: 0x0009261C File Offset: 0x0009081C
		[CLSCompliant(false)]
		public unsafe static void GetShaderSource(uint shader, int bufSize, out int length, [Out] StringBuilder source)
		{
			fixed (int* ptr = &length)
			{
				int* ptr2 = ptr;
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufSize, ptr2, intPtr, GL.EntryPoints[198]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x060037B4 RID: 14260 RVA: 0x0009265C File Offset: 0x0009085C
		[CLSCompliant(false)]
		public unsafe static void GetShaderSource(uint shader, int bufSize, [Out] int* length, [Out] StringBuilder source)
		{
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
			calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufSize, length, intPtr, GL.EntryPoints[198]);
			BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x060037B5 RID: 14261 RVA: 0x00092698 File Offset: 0x00090898
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static string GetString(All name)
		{
			return new string((sbyte*)((void*)calli(System.IntPtr(System.Int32), name, GL.EntryPoints[199])));
		}

		// Token: 0x060037B6 RID: 14262 RVA: 0x000926B8 File Offset: 0x000908B8
		public unsafe static string GetString(StringName name)
		{
			return new string((sbyte*)((void*)calli(System.IntPtr(System.Int32), name, GL.EntryPoints[199])));
		}

		// Token: 0x060037B7 RID: 14263 RVA: 0x000926D8 File Offset: 0x000908D8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(All target, All pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[201]);
			}
		}

		// Token: 0x060037B8 RID: 14264 RVA: 0x00092710 File Offset: 0x00090910
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(All target, All pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[201]);
			}
		}

		// Token: 0x060037B9 RID: 14265 RVA: 0x00092734 File Offset: 0x00090934
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(All target, All pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[201]);
		}

		// Token: 0x060037BA RID: 14266 RVA: 0x0009274C File Offset: 0x0009094C
		[CLSCompliant(false)]
		[Obsolete("Use GetTextureParameterName overload instead")]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[201]);
			}
		}

		// Token: 0x060037BB RID: 14267 RVA: 0x00092784 File Offset: 0x00090984
		[CLSCompliant(false)]
		[Obsolete("Use GetTextureParameterName overload instead")]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[201]);
			}
		}

		// Token: 0x060037BC RID: 14268 RVA: 0x000927A8 File Offset: 0x000909A8
		[CLSCompliant(false)]
		[Obsolete("Use GetTextureParameterName overload instead")]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[201]);
		}

		// Token: 0x060037BD RID: 14269 RVA: 0x000927C0 File Offset: 0x000909C0
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameterName pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[201]);
			}
		}

		// Token: 0x060037BE RID: 14270 RVA: 0x000927F8 File Offset: 0x000909F8
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameterName pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[201]);
			}
		}

		// Token: 0x060037BF RID: 14271 RVA: 0x0009281C File Offset: 0x00090A1C
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameterName pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[201]);
		}

		// Token: 0x060037C0 RID: 14272 RVA: 0x00092834 File Offset: 0x00090A34
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexParameter(All target, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[204]);
			}
		}

		// Token: 0x060037C1 RID: 14273 RVA: 0x0009286C File Offset: 0x00090A6C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexParameter(All target, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[204]);
			}
		}

		// Token: 0x060037C2 RID: 14274 RVA: 0x00092890 File Offset: 0x00090A90
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(All target, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[204]);
		}

		// Token: 0x060037C3 RID: 14275 RVA: 0x000928A8 File Offset: 0x00090AA8
		[CLSCompliant(false)]
		[Obsolete("Use GetTextureParameterName overload instead")]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[204]);
			}
		}

		// Token: 0x060037C4 RID: 14276 RVA: 0x000928E0 File Offset: 0x00090AE0
		[CLSCompliant(false)]
		[Obsolete("Use GetTextureParameterName overload instead")]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[204]);
			}
		}

		// Token: 0x060037C5 RID: 14277 RVA: 0x00092904 File Offset: 0x00090B04
		[CLSCompliant(false)]
		[Obsolete("Use GetTextureParameterName overload instead")]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[204]);
		}

		// Token: 0x060037C6 RID: 14278 RVA: 0x0009291C File Offset: 0x00090B1C
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameterName pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[204]);
			}
		}

		// Token: 0x060037C7 RID: 14279 RVA: 0x00092954 File Offset: 0x00090B54
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameterName pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[204]);
			}
		}

		// Token: 0x060037C8 RID: 14280 RVA: 0x00092978 File Offset: 0x00090B78
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameterName pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[204]);
		}

		// Token: 0x060037C9 RID: 14281 RVA: 0x00092990 File Offset: 0x00090B90
		[CLSCompliant(false)]
		public unsafe static void GetUniform(int program, int location, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), program, location, ptr, GL.EntryPoints[206]);
			}
		}

		// Token: 0x060037CA RID: 14282 RVA: 0x000929C8 File Offset: 0x00090BC8
		[CLSCompliant(false)]
		public unsafe static void GetUniform(int program, int location, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), program, location, ptr, GL.EntryPoints[206]);
			}
		}

		// Token: 0x060037CB RID: 14283 RVA: 0x000929EC File Offset: 0x00090BEC
		[CLSCompliant(false)]
		public unsafe static void GetUniform(int program, int location, [Out] float* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Single*), program, location, @params, GL.EntryPoints[206]);
		}

		// Token: 0x060037CC RID: 14284 RVA: 0x00092A04 File Offset: 0x00090C04
		[CLSCompliant(false)]
		public unsafe static void GetUniform(uint program, int location, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), program, location, ptr, GL.EntryPoints[206]);
			}
		}

		// Token: 0x060037CD RID: 14285 RVA: 0x00092A3C File Offset: 0x00090C3C
		[CLSCompliant(false)]
		public unsafe static void GetUniform(uint program, int location, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), program, location, ptr, GL.EntryPoints[206]);
			}
		}

		// Token: 0x060037CE RID: 14286 RVA: 0x00092A60 File Offset: 0x00090C60
		[CLSCompliant(false)]
		public unsafe static void GetUniform(uint program, int location, [Out] float* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Single*), program, location, @params, GL.EntryPoints[206]);
		}

		// Token: 0x060037CF RID: 14287 RVA: 0x00092A78 File Offset: 0x00090C78
		[CLSCompliant(false)]
		public unsafe static void GetUniform(int program, int location, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, location, ptr, GL.EntryPoints[207]);
			}
		}

		// Token: 0x060037D0 RID: 14288 RVA: 0x00092AB0 File Offset: 0x00090CB0
		[CLSCompliant(false)]
		public unsafe static void GetUniform(int program, int location, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, location, ptr, GL.EntryPoints[207]);
			}
		}

		// Token: 0x060037D1 RID: 14289 RVA: 0x00092AD4 File Offset: 0x00090CD4
		[CLSCompliant(false)]
		public unsafe static void GetUniform(int program, int location, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, location, @params, GL.EntryPoints[207]);
		}

		// Token: 0x060037D2 RID: 14290 RVA: 0x00092AEC File Offset: 0x00090CEC
		[CLSCompliant(false)]
		public unsafe static void GetUniform(uint program, int location, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, location, ptr, GL.EntryPoints[207]);
			}
		}

		// Token: 0x060037D3 RID: 14291 RVA: 0x00092B24 File Offset: 0x00090D24
		[CLSCompliant(false)]
		public unsafe static void GetUniform(uint program, int location, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, location, ptr, GL.EntryPoints[207]);
			}
		}

		// Token: 0x060037D4 RID: 14292 RVA: 0x00092B48 File Offset: 0x00090D48
		[CLSCompliant(false)]
		public unsafe static void GetUniform(uint program, int location, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), program, location, @params, GL.EntryPoints[207]);
		}

		// Token: 0x060037D5 RID: 14293 RVA: 0x00092B60 File Offset: 0x00090D60
		[CLSCompliant(false)]
		public static int GetUniformLocation(int program, string name)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(name);
			int result = calli(System.Int32(System.UInt32,System.IntPtr), program, intPtr, GL.EntryPoints[208]);
			BindingsBase.FreeStringPtr(intPtr);
			return result;
		}

		// Token: 0x060037D6 RID: 14294 RVA: 0x00092B8C File Offset: 0x00090D8C
		[CLSCompliant(false)]
		public static int GetUniformLocation(uint program, string name)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(name);
			int result = calli(System.Int32(System.UInt32,System.IntPtr), program, intPtr, GL.EntryPoints[208]);
			BindingsBase.FreeStringPtr(intPtr);
			return result;
		}

		// Token: 0x060037D7 RID: 14295 RVA: 0x00092BB8 File Offset: 0x00090DB8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttrib(int index, All pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060037D8 RID: 14296 RVA: 0x00092BF0 File Offset: 0x00090DF0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttrib(int index, All pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060037D9 RID: 14297 RVA: 0x00092C14 File Offset: 0x00090E14
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttrib(int index, All pname, [Out] float* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, @params, GL.EntryPoints[209]);
		}

		// Token: 0x060037DA RID: 14298 RVA: 0x00092C2C File Offset: 0x00090E2C
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(int index, VertexAttribParameter pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060037DB RID: 14299 RVA: 0x00092C64 File Offset: 0x00090E64
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(int index, VertexAttribParameter pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060037DC RID: 14300 RVA: 0x00092C88 File Offset: 0x00090E88
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(int index, VertexAttribParameter pname, [Out] float* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, @params, GL.EntryPoints[209]);
		}

		// Token: 0x060037DD RID: 14301 RVA: 0x00092CA0 File Offset: 0x00090EA0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttrib(uint index, All pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060037DE RID: 14302 RVA: 0x00092CD8 File Offset: 0x00090ED8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttrib(uint index, All pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060037DF RID: 14303 RVA: 0x00092CFC File Offset: 0x00090EFC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, All pname, [Out] float* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, @params, GL.EntryPoints[209]);
		}

		// Token: 0x060037E0 RID: 14304 RVA: 0x00092D14 File Offset: 0x00090F14
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, VertexAttribParameter pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060037E1 RID: 14305 RVA: 0x00092D4C File Offset: 0x00090F4C
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, VertexAttribParameter pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060037E2 RID: 14306 RVA: 0x00092D70 File Offset: 0x00090F70
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, VertexAttribParameter pname, [Out] float* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Single*), index, pname, @params, GL.EntryPoints[209]);
		}

		// Token: 0x060037E3 RID: 14307 RVA: 0x00092D88 File Offset: 0x00090F88
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(int index, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, ptr, GL.EntryPoints[210]);
			}
		}

		// Token: 0x060037E4 RID: 14308 RVA: 0x00092DC0 File Offset: 0x00090FC0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(int index, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, ptr, GL.EntryPoints[210]);
			}
		}

		// Token: 0x060037E5 RID: 14309 RVA: 0x00092DE4 File Offset: 0x00090FE4
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttrib(int index, All pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, @params, GL.EntryPoints[210]);
		}

		// Token: 0x060037E6 RID: 14310 RVA: 0x00092DFC File Offset: 0x00090FFC
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(int index, VertexAttribParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, ptr, GL.EntryPoints[210]);
			}
		}

		// Token: 0x060037E7 RID: 14311 RVA: 0x00092E34 File Offset: 0x00091034
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(int index, VertexAttribParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, ptr, GL.EntryPoints[210]);
			}
		}

		// Token: 0x060037E8 RID: 14312 RVA: 0x00092E58 File Offset: 0x00091058
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(int index, VertexAttribParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, @params, GL.EntryPoints[210]);
		}

		// Token: 0x060037E9 RID: 14313 RVA: 0x00092E70 File Offset: 0x00091070
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttrib(uint index, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, ptr, GL.EntryPoints[210]);
			}
		}

		// Token: 0x060037EA RID: 14314 RVA: 0x00092EA8 File Offset: 0x000910A8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, ptr, GL.EntryPoints[210]);
			}
		}

		// Token: 0x060037EB RID: 14315 RVA: 0x00092ECC File Offset: 0x000910CC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, All pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, @params, GL.EntryPoints[210]);
		}

		// Token: 0x060037EC RID: 14316 RVA: 0x00092EE4 File Offset: 0x000910E4
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, VertexAttribParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, ptr, GL.EntryPoints[210]);
			}
		}

		// Token: 0x060037ED RID: 14317 RVA: 0x00092F1C File Offset: 0x0009111C
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, VertexAttribParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, ptr, GL.EntryPoints[210]);
			}
		}

		// Token: 0x060037EE RID: 14318 RVA: 0x00092F40 File Offset: 0x00091140
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttrib(uint index, VertexAttribParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32*), index, pname, @params, GL.EntryPoints[210]);
		}

		// Token: 0x060037EF RID: 14319 RVA: 0x00092F58 File Offset: 0x00091158
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void GetVertexAttribPointer(int index, All pname, [Out] IntPtr pointer)
		{
			calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, pointer, GL.EntryPoints[211]);
		}

		// Token: 0x060037F0 RID: 14320 RVA: 0x00092F70 File Offset: 0x00091170
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttribPointer<T2>(int index, All pname, [In] [Out] T2[] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037F1 RID: 14321 RVA: 0x00092FA8 File Offset: 0x000911A8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(int index, All pname, [In] [Out] T2[,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037F2 RID: 14322 RVA: 0x00092FE4 File Offset: 0x000911E4
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(int index, All pname, [In] [Out] T2[,,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037F3 RID: 14323 RVA: 0x00093020 File Offset: 0x00091220
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttribPointer<T2>(int index, All pname, [In] [Out] ref T2 pointer) where T2 : struct
		{
			fixed (T2* ptr = &pointer)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037F4 RID: 14324 RVA: 0x00093044 File Offset: 0x00091244
		[CLSCompliant(false)]
		public static void GetVertexAttribPointer(int index, VertexAttribPointerParameter pname, [Out] IntPtr pointer)
		{
			calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, pointer, GL.EntryPoints[211]);
		}

		// Token: 0x060037F5 RID: 14325 RVA: 0x0009305C File Offset: 0x0009125C
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(int index, VertexAttribPointerParameter pname, [In] [Out] T2[] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037F6 RID: 14326 RVA: 0x00093094 File Offset: 0x00091294
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(int index, VertexAttribPointerParameter pname, [In] [Out] T2[,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037F7 RID: 14327 RVA: 0x000930D0 File Offset: 0x000912D0
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(int index, VertexAttribPointerParameter pname, [In] [Out] T2[,,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037F8 RID: 14328 RVA: 0x0009310C File Offset: 0x0009130C
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(int index, VertexAttribPointerParameter pname, [In] [Out] ref T2 pointer) where T2 : struct
		{
			fixed (T2* ptr = &pointer)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037F9 RID: 14329 RVA: 0x00093130 File Offset: 0x00091330
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void GetVertexAttribPointer(uint index, All pname, [Out] IntPtr pointer)
		{
			calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, pointer, GL.EntryPoints[211]);
		}

		// Token: 0x060037FA RID: 14330 RVA: 0x00093148 File Offset: 0x00091348
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(uint index, All pname, [In] [Out] T2[] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037FB RID: 14331 RVA: 0x00093180 File Offset: 0x00091380
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(uint index, All pname, [In] [Out] T2[,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037FC RID: 14332 RVA: 0x000931BC File Offset: 0x000913BC
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttribPointer<T2>(uint index, All pname, [In] [Out] T2[,,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037FD RID: 14333 RVA: 0x000931F8 File Offset: 0x000913F8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetVertexAttribPointer<T2>(uint index, All pname, [In] [Out] ref T2 pointer) where T2 : struct
		{
			fixed (T2* ptr = &pointer)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x060037FE RID: 14334 RVA: 0x0009321C File Offset: 0x0009141C
		[CLSCompliant(false)]
		public static void GetVertexAttribPointer(uint index, VertexAttribPointerParameter pname, [Out] IntPtr pointer)
		{
			calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, pointer, GL.EntryPoints[211]);
		}

		// Token: 0x060037FF RID: 14335 RVA: 0x00093234 File Offset: 0x00091434
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(uint index, VertexAttribPointerParameter pname, [In] [Out] T2[] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x06003800 RID: 14336 RVA: 0x0009326C File Offset: 0x0009146C
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(uint index, VertexAttribPointerParameter pname, [In] [Out] T2[,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x06003801 RID: 14337 RVA: 0x000932A8 File Offset: 0x000914A8
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(uint index, VertexAttribPointerParameter pname, [In] [Out] T2[,,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x06003802 RID: 14338 RVA: 0x000932E4 File Offset: 0x000914E4
		[CLSCompliant(false)]
		public unsafe static void GetVertexAttribPointer<T2>(uint index, VertexAttribPointerParameter pname, [In] [Out] ref T2 pointer) where T2 : struct
		{
			fixed (T2* ptr = &pointer)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr), index, pname, ptr, GL.EntryPoints[211]);
			}
		}

		// Token: 0x06003803 RID: 14339 RVA: 0x00093308 File Offset: 0x00091508
		[Obsolete("Use strongly-typed overload instead")]
		public static void Hint(All target, All mode)
		{
			calli(System.Void(System.Int32,System.Int32), target, mode, GL.EntryPoints[212]);
		}

		// Token: 0x06003804 RID: 14340 RVA: 0x0009331C File Offset: 0x0009151C
		public static void Hint(HintTarget target, HintMode mode)
		{
			calli(System.Void(System.Int32,System.Int32), target, mode, GL.EntryPoints[212]);
		}

		// Token: 0x06003805 RID: 14341 RVA: 0x00093330 File Offset: 0x00091530
		[CLSCompliant(false)]
		public static bool IsBuffer(int buffer)
		{
			return calli(System.Byte(System.UInt32), buffer, GL.EntryPoints[214]);
		}

		// Token: 0x06003806 RID: 14342 RVA: 0x00093344 File Offset: 0x00091544
		[CLSCompliant(false)]
		public static bool IsBuffer(uint buffer)
		{
			return calli(System.Byte(System.UInt32), buffer, GL.EntryPoints[214]);
		}

		// Token: 0x06003807 RID: 14343 RVA: 0x00093358 File Offset: 0x00091558
		[Obsolete("Use strongly-typed overload instead")]
		public static bool IsEnabled(All cap)
		{
			return calli(System.Byte(System.Int32), cap, GL.EntryPoints[215]);
		}

		// Token: 0x06003808 RID: 14344 RVA: 0x0009336C File Offset: 0x0009156C
		public static bool IsEnabled(EnableCap cap)
		{
			return calli(System.Byte(System.Int32), cap, GL.EntryPoints[215]);
		}

		// Token: 0x06003809 RID: 14345 RVA: 0x00093380 File Offset: 0x00091580
		[CLSCompliant(false)]
		public static bool IsFramebuffer(int framebuffer)
		{
			return calli(System.Byte(System.UInt32), framebuffer, GL.EntryPoints[218]);
		}

		// Token: 0x0600380A RID: 14346 RVA: 0x00093394 File Offset: 0x00091594
		[CLSCompliant(false)]
		public static bool IsFramebuffer(uint framebuffer)
		{
			return calli(System.Byte(System.UInt32), framebuffer, GL.EntryPoints[218]);
		}

		// Token: 0x0600380B RID: 14347 RVA: 0x000933A8 File Offset: 0x000915A8
		[CLSCompliant(false)]
		public static bool IsProgram(int program)
		{
			return calli(System.Byte(System.UInt32), program, GL.EntryPoints[219]);
		}

		// Token: 0x0600380C RID: 14348 RVA: 0x000933BC File Offset: 0x000915BC
		[CLSCompliant(false)]
		public static bool IsProgram(uint program)
		{
			return calli(System.Byte(System.UInt32), program, GL.EntryPoints[219]);
		}

		// Token: 0x0600380D RID: 14349 RVA: 0x000933D0 File Offset: 0x000915D0
		[CLSCompliant(false)]
		public static bool IsRenderbuffer(int renderbuffer)
		{
			return calli(System.Byte(System.UInt32), renderbuffer, GL.EntryPoints[222]);
		}

		// Token: 0x0600380E RID: 14350 RVA: 0x000933E4 File Offset: 0x000915E4
		[CLSCompliant(false)]
		public static bool IsRenderbuffer(uint renderbuffer)
		{
			return calli(System.Byte(System.UInt32), renderbuffer, GL.EntryPoints[222]);
		}

		// Token: 0x0600380F RID: 14351 RVA: 0x000933F8 File Offset: 0x000915F8
		[CLSCompliant(false)]
		public static bool IsShader(int shader)
		{
			return calli(System.Byte(System.UInt32), shader, GL.EntryPoints[223]);
		}

		// Token: 0x06003810 RID: 14352 RVA: 0x0009340C File Offset: 0x0009160C
		[CLSCompliant(false)]
		public static bool IsShader(uint shader)
		{
			return calli(System.Byte(System.UInt32), shader, GL.EntryPoints[223]);
		}

		// Token: 0x06003811 RID: 14353 RVA: 0x00093420 File Offset: 0x00091620
		[CLSCompliant(false)]
		public static bool IsTexture(int texture)
		{
			return calli(System.Byte(System.UInt32), texture, GL.EntryPoints[225]);
		}

		// Token: 0x06003812 RID: 14354 RVA: 0x00093434 File Offset: 0x00091634
		[CLSCompliant(false)]
		public static bool IsTexture(uint texture)
		{
			return calli(System.Byte(System.UInt32), texture, GL.EntryPoints[225]);
		}

		// Token: 0x06003813 RID: 14355 RVA: 0x00093448 File Offset: 0x00091648
		public static void LineWidth(float width)
		{
			calli(System.Void(System.Single), width, GL.EntryPoints[228]);
		}

		// Token: 0x06003814 RID: 14356 RVA: 0x0009345C File Offset: 0x0009165C
		[CLSCompliant(false)]
		public static void LinkProgram(int program)
		{
			calli(System.Void(System.UInt32), program, GL.EntryPoints[229]);
		}

		// Token: 0x06003815 RID: 14357 RVA: 0x00093470 File Offset: 0x00091670
		[CLSCompliant(false)]
		public static void LinkProgram(uint program)
		{
			calli(System.Void(System.UInt32), program, GL.EntryPoints[229]);
		}

		// Token: 0x06003816 RID: 14358 RVA: 0x00093484 File Offset: 0x00091684
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void ObjectLabel(All identifier, int name, int length, string label)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), identifier, name, length, intPtr, GL.EntryPoints[235]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003817 RID: 14359 RVA: 0x000934B4 File Offset: 0x000916B4
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void ObjectLabel(All identifier, uint name, int length, string label)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), identifier, name, length, intPtr, GL.EntryPoints[235]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003818 RID: 14360 RVA: 0x000934E4 File Offset: 0x000916E4
		[CLSCompliant(false)]
		public static void ObjectLabel(ObjectLabelIdentifier identifier, int name, int length, string label)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), identifier, name, length, intPtr, GL.EntryPoints[235]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003819 RID: 14361 RVA: 0x00093514 File Offset: 0x00091714
		[CLSCompliant(false)]
		public static void ObjectLabel(ObjectLabelIdentifier identifier, uint name, int length, string label)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), identifier, name, length, intPtr, GL.EntryPoints[235]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x0600381A RID: 14362 RVA: 0x00093544 File Offset: 0x00091744
		public static void ObjectPtrLabel(IntPtr ptr, int length, string label)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
			calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr, length, intPtr, GL.EntryPoints[237]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x0600381B RID: 14363 RVA: 0x00093574 File Offset: 0x00091774
		[CLSCompliant(false)]
		public unsafe static void ObjectPtrLabel<T0>([In] [Out] T0[] ptr, int length, string label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0] : ref *null)
			{
				T0* ptr3 = ptr2;
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr3, length, intPtr, GL.EntryPoints[237]);
				BindingsBase.FreeStringPtr(intPtr);
			}
		}

		// Token: 0x0600381C RID: 14364 RVA: 0x000935B8 File Offset: 0x000917B8
		[CLSCompliant(false)]
		public unsafe static void ObjectPtrLabel<T0>([In] [Out] T0[,] ptr, int length, string label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0] : ref *null)
			{
				T0* ptr3 = ptr2;
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr3, length, intPtr, GL.EntryPoints[237]);
				BindingsBase.FreeStringPtr(intPtr);
			}
		}

		// Token: 0x0600381D RID: 14365 RVA: 0x00093600 File Offset: 0x00091800
		[CLSCompliant(false)]
		public unsafe static void ObjectPtrLabel<T0>([In] [Out] T0[,,] ptr, int length, string label) where T0 : struct
		{
			fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0, 0] : ref *null)
			{
				T0* ptr3 = ptr2;
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr3, length, intPtr, GL.EntryPoints[237]);
				BindingsBase.FreeStringPtr(intPtr);
			}
		}

		// Token: 0x0600381E RID: 14366 RVA: 0x00093648 File Offset: 0x00091848
		public unsafe static void ObjectPtrLabel<T0>([In] [Out] ref T0 ptr, int length, string label) where T0 : struct
		{
			fixed (T0* ptr2 = &ptr)
			{
				T0* ptr3 = ptr2;
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr3, length, intPtr, GL.EntryPoints[237]);
				BindingsBase.FreeStringPtr(intPtr);
			}
		}

		// Token: 0x0600381F RID: 14367 RVA: 0x00093678 File Offset: 0x00091878
		[Obsolete("Use strongly-typed overload instead")]
		public static void PixelStore(All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[240]);
		}

		// Token: 0x06003820 RID: 14368 RVA: 0x0009368C File Offset: 0x0009188C
		public static void PixelStore(PixelStoreParameter pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[240]);
		}

		// Token: 0x06003821 RID: 14369 RVA: 0x000936A0 File Offset: 0x000918A0
		public static void PolygonOffset(float factor, float units)
		{
			calli(System.Void(System.Single,System.Single), factor, units, GL.EntryPoints[241]);
		}

		// Token: 0x06003822 RID: 14370 RVA: 0x000936B4 File Offset: 0x000918B4
		public static void PopDebugGroup()
		{
			calli(System.Void(), GL.EntryPoints[242]);
		}

		// Token: 0x06003823 RID: 14371 RVA: 0x000936C8 File Offset: 0x000918C8
		[CLSCompliant(false)]
		public static void PushDebugGroup(All source, int id, int length, string message)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(message);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), source, id, length, intPtr, GL.EntryPoints[281]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003824 RID: 14372 RVA: 0x000936F8 File Offset: 0x000918F8
		[CLSCompliant(false)]
		public static void PushDebugGroup(All source, uint id, int length, string message)
		{
			IntPtr intPtr = BindingsBase.MarshalStringToPtr(message);
			calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), source, id, length, intPtr, GL.EntryPoints[281]);
			BindingsBase.FreeStringPtr(intPtr);
		}

		// Token: 0x06003825 RID: 14373 RVA: 0x00093728 File Offset: 0x00091928
		[Obsolete("Use strongly-typed overload instead")]
		public static void ReadPixels(int x, int y, int width, int height, All format, All type, [Out] IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, pixels, GL.EntryPoints[288]);
		}

		// Token: 0x06003826 RID: 14374 RVA: 0x00093750 File Offset: 0x00091950
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, All format, All type, [In] [Out] T6[] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[288]);
			}
		}

		// Token: 0x06003827 RID: 14375 RVA: 0x00093790 File Offset: 0x00091990
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, All format, All type, [In] [Out] T6[,] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[288]);
			}
		}

		// Token: 0x06003828 RID: 14376 RVA: 0x000937D4 File Offset: 0x000919D4
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, All format, All type, [In] [Out] T6[,,] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[288]);
			}
		}

		// Token: 0x06003829 RID: 14377 RVA: 0x00093818 File Offset: 0x00091A18
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, All format, All type, [In] [Out] ref T6 pixels) where T6 : struct
		{
			fixed (T6* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[288]);
			}
		}

		// Token: 0x0600382A RID: 14378 RVA: 0x00093844 File Offset: 0x00091A44
		public static void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, [Out] IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, pixels, GL.EntryPoints[288]);
		}

		// Token: 0x0600382B RID: 14379 RVA: 0x0009386C File Offset: 0x00091A6C
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In] [Out] T6[] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[288]);
			}
		}

		// Token: 0x0600382C RID: 14380 RVA: 0x000938AC File Offset: 0x00091AAC
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In] [Out] T6[,] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[288]);
			}
		}

		// Token: 0x0600382D RID: 14381 RVA: 0x000938F0 File Offset: 0x00091AF0
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In] [Out] T6[,,] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[288]);
			}
		}

		// Token: 0x0600382E RID: 14382 RVA: 0x00093934 File Offset: 0x00091B34
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In] [Out] ref T6 pixels) where T6 : struct
		{
			fixed (T6* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[288]);
			}
		}

		// Token: 0x0600382F RID: 14383 RVA: 0x00093960 File Offset: 0x00091B60
		public static void ReleaseShaderCompiler()
		{
			calli(System.Void(), GL.EntryPoints[289]);
		}

		// Token: 0x06003830 RID: 14384 RVA: 0x00093974 File Offset: 0x00091B74
		[Obsolete("Use strongly-typed overload instead")]
		public static void RenderbufferStorage(All target, All internalformat, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), target, internalformat, width, height, GL.EntryPoints[290]);
		}

		// Token: 0x06003831 RID: 14385 RVA: 0x0009398C File Offset: 0x00091B8C
		public static void RenderbufferStorage(RenderbufferTarget target, RenderbufferInternalFormat internalformat, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), target, internalformat, width, height, GL.EntryPoints[290]);
		}

		// Token: 0x06003832 RID: 14386 RVA: 0x000939A4 File Offset: 0x00091BA4
		public static void SampleCoverage(float value, bool invert)
		{
			calli(System.Void(System.Single,System.Boolean), value, invert, GL.EntryPoints[297]);
		}

		// Token: 0x06003833 RID: 14387 RVA: 0x000939B8 File Offset: 0x00091BB8
		public static void Scissor(int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), x, y, width, height, GL.EntryPoints[300]);
		}

		// Token: 0x06003834 RID: 14388 RVA: 0x000939D0 File Offset: 0x00091BD0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary(int count, int[] shaders, All binaryformat, IntPtr binary, int length)
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr, binaryformat, binary, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003835 RID: 14389 RVA: 0x00093A08 File Offset: 0x00091C08
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int[] shaders, All binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003836 RID: 14390 RVA: 0x00093A58 File Offset: 0x00091C58
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, int[] shaders, All binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003837 RID: 14391 RVA: 0x00093AAC File Offset: 0x00091CAC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int[] shaders, All binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003838 RID: 14392 RVA: 0x00093B00 File Offset: 0x00091D00
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, int[] shaders, All binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = &binary)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003839 RID: 14393 RVA: 0x00093B3C File Offset: 0x00091D3C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary(int count, int[] shaders, ShaderBinaryFormat binaryformat, IntPtr binary, int length)
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr, binaryformat, binary, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600383A RID: 14394 RVA: 0x00093B74 File Offset: 0x00091D74
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int[] shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600383B RID: 14395 RVA: 0x00093BC4 File Offset: 0x00091DC4
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int[] shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600383C RID: 14396 RVA: 0x00093C18 File Offset: 0x00091E18
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int[] shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600383D RID: 14397 RVA: 0x00093C6C File Offset: 0x00091E6C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int[] shaders, ShaderBinaryFormat binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = &binary)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600383E RID: 14398 RVA: 0x00093CA8 File Offset: 0x00091EA8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary(int count, ref int shaders, All binaryformat, IntPtr binary, int length)
		{
			fixed (int* ptr = &shaders)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr, binaryformat, binary, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600383F RID: 14399 RVA: 0x00093CD0 File Offset: 0x00091ED0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref int shaders, All binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (int* ptr = &shaders)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003840 RID: 14400 RVA: 0x00093D0C File Offset: 0x00091F0C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref int shaders, All binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (int* ptr = &shaders)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003841 RID: 14401 RVA: 0x00093D4C File Offset: 0x00091F4C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, ref int shaders, All binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (int* ptr = &shaders)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003842 RID: 14402 RVA: 0x00093D8C File Offset: 0x00091F8C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, ref int shaders, All binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (int* ptr = &shaders)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = &binary)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003843 RID: 14403 RVA: 0x00093DB8 File Offset: 0x00091FB8
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary(int count, ref int shaders, ShaderBinaryFormat binaryformat, IntPtr binary, int length)
		{
			fixed (int* ptr = &shaders)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr, binaryformat, binary, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003844 RID: 14404 RVA: 0x00093DE0 File Offset: 0x00091FE0
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref int shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (int* ptr = &shaders)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003845 RID: 14405 RVA: 0x00093E1C File Offset: 0x0009201C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref int shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (int* ptr = &shaders)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003846 RID: 14406 RVA: 0x00093E5C File Offset: 0x0009205C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref int shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (int* ptr = &shaders)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003847 RID: 14407 RVA: 0x00093E9C File Offset: 0x0009209C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref int shaders, ShaderBinaryFormat binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (int* ptr = &shaders)
			{
				int* ptr2 = ptr;
				fixed (T3* ptr3 = &binary)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003848 RID: 14408 RVA: 0x00093EC8 File Offset: 0x000920C8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary(int count, int* shaders, All binaryformat, IntPtr binary, int length)
		{
			calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, binary, length, GL.EntryPoints[303]);
		}

		// Token: 0x06003849 RID: 14409 RVA: 0x00093EE0 File Offset: 0x000920E0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, int* shaders, All binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600384A RID: 14410 RVA: 0x00093F18 File Offset: 0x00092118
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, int* shaders, All binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600384B RID: 14411 RVA: 0x00093F54 File Offset: 0x00092154
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, int* shaders, All binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600384C RID: 14412 RVA: 0x00093F94 File Offset: 0x00092194
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, int* shaders, All binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (T3* ptr = &binary)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600384D RID: 14413 RVA: 0x00093FBC File Offset: 0x000921BC
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary(int count, int* shaders, ShaderBinaryFormat binaryformat, IntPtr binary, int length)
		{
			calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, binary, length, GL.EntryPoints[303]);
		}

		// Token: 0x0600384E RID: 14414 RVA: 0x00093FD4 File Offset: 0x000921D4
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int* shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600384F RID: 14415 RVA: 0x0009400C File Offset: 0x0009220C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int* shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003850 RID: 14416 RVA: 0x00094048 File Offset: 0x00092248
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int* shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003851 RID: 14417 RVA: 0x00094088 File Offset: 0x00092288
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, int* shaders, ShaderBinaryFormat binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (T3* ptr = &binary)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003852 RID: 14418 RVA: 0x000940B0 File Offset: 0x000922B0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary(int count, uint[] shaders, All binaryformat, IntPtr binary, int length)
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr, binaryformat, binary, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003853 RID: 14419 RVA: 0x000940E8 File Offset: 0x000922E8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint[] shaders, All binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003854 RID: 14420 RVA: 0x00094138 File Offset: 0x00092338
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, uint[] shaders, All binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003855 RID: 14421 RVA: 0x0009418C File Offset: 0x0009238C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, uint[] shaders, All binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003856 RID: 14422 RVA: 0x000941E0 File Offset: 0x000923E0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, uint[] shaders, All binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = &binary)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003857 RID: 14423 RVA: 0x0009421C File Offset: 0x0009241C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary(int count, uint[] shaders, ShaderBinaryFormat binaryformat, IntPtr binary, int length)
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr, binaryformat, binary, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003858 RID: 14424 RVA: 0x00094254 File Offset: 0x00092454
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint[] shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003859 RID: 14425 RVA: 0x000942A4 File Offset: 0x000924A4
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint[] shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600385A RID: 14426 RVA: 0x000942F8 File Offset: 0x000924F8
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint[] shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600385B RID: 14427 RVA: 0x0009434C File Offset: 0x0009254C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint[] shaders, ShaderBinaryFormat binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = &binary)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600385C RID: 14428 RVA: 0x00094388 File Offset: 0x00092588
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary(int count, ref uint shaders, All binaryformat, IntPtr binary, int length)
		{
			fixed (uint* ptr = &shaders)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr, binaryformat, binary, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600385D RID: 14429 RVA: 0x000943B0 File Offset: 0x000925B0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref uint shaders, All binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = &shaders)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600385E RID: 14430 RVA: 0x000943EC File Offset: 0x000925EC
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, ref uint shaders, All binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = &shaders)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x0600385F RID: 14431 RVA: 0x0009442C File Offset: 0x0009262C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, ref uint shaders, All binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = &shaders)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003860 RID: 14432 RVA: 0x0009446C File Offset: 0x0009266C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, ref uint shaders, All binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (uint* ptr = &shaders)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = &binary)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003861 RID: 14433 RVA: 0x00094498 File Offset: 0x00092698
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary(int count, ref uint shaders, ShaderBinaryFormat binaryformat, IntPtr binary, int length)
		{
			fixed (uint* ptr = &shaders)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr, binaryformat, binary, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003862 RID: 14434 RVA: 0x000944C0 File Offset: 0x000926C0
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref uint shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = &shaders)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003863 RID: 14435 RVA: 0x000944FC File Offset: 0x000926FC
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref uint shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = &shaders)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003864 RID: 14436 RVA: 0x0009453C File Offset: 0x0009273C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref uint shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (uint* ptr = &shaders)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003865 RID: 14437 RVA: 0x0009457C File Offset: 0x0009277C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, ref uint shaders, ShaderBinaryFormat binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (uint* ptr = &shaders)
			{
				uint* ptr2 = ptr;
				fixed (T3* ptr3 = &binary)
				{
					calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, ptr2, binaryformat, ptr3, length, GL.EntryPoints[303]);
				}
			}
		}

		// Token: 0x06003866 RID: 14438 RVA: 0x000945A8 File Offset: 0x000927A8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary(int count, uint* shaders, All binaryformat, IntPtr binary, int length)
		{
			calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, binary, length, GL.EntryPoints[303]);
		}

		// Token: 0x06003867 RID: 14439 RVA: 0x000945C0 File Offset: 0x000927C0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, uint* shaders, All binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003868 RID: 14440 RVA: 0x000945F8 File Offset: 0x000927F8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, uint* shaders, All binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003869 RID: 14441 RVA: 0x00094634 File Offset: 0x00092834
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, uint* shaders, All binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600386A RID: 14442 RVA: 0x00094674 File Offset: 0x00092874
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ShaderBinary<T3>(int count, uint* shaders, All binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (T3* ptr = &binary)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600386B RID: 14443 RVA: 0x0009469C File Offset: 0x0009289C
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary(int count, uint* shaders, ShaderBinaryFormat binaryformat, IntPtr binary, int length)
		{
			calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, binary, length, GL.EntryPoints[303]);
		}

		// Token: 0x0600386C RID: 14444 RVA: 0x000946B4 File Offset: 0x000928B4
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint* shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600386D RID: 14445 RVA: 0x000946EC File Offset: 0x000928EC
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint* shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600386E RID: 14446 RVA: 0x00094728 File Offset: 0x00092928
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint* shaders, ShaderBinaryFormat binaryformat, [In] [Out] T3[,,] binary, int length) where T3 : struct
		{
			fixed (T3* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x0600386F RID: 14447 RVA: 0x00094768 File Offset: 0x00092968
		[CLSCompliant(false)]
		public unsafe static void ShaderBinary<T3>(int count, uint* shaders, ShaderBinaryFormat binaryformat, [In] [Out] ref T3 binary, int length) where T3 : struct
		{
			fixed (T3* ptr = &binary)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32,System.IntPtr,System.Int32), count, shaders, binaryformat, ptr, length, GL.EntryPoints[303]);
			}
		}

		// Token: 0x06003870 RID: 14448 RVA: 0x00094790 File Offset: 0x00092990
		[CLSCompliant(false)]
		public unsafe static void ShaderSource(int shader, int count, string[] @string, int[] length)
		{
			IntPtr intPtr = BindingsBase.MarshalStringArrayToPtr(@string);
			IntPtr intPtr2 = intPtr;
			fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), shader, count, intPtr2, ptr, GL.EntryPoints[304]);
				BindingsBase.FreeStringArrayPtr(intPtr, @string.Length);
			}
		}

		// Token: 0x06003871 RID: 14449 RVA: 0x000947D8 File Offset: 0x000929D8
		[CLSCompliant(false)]
		public unsafe static void ShaderSource(int shader, int count, string[] @string, ref int length)
		{
			IntPtr intPtr = BindingsBase.MarshalStringArrayToPtr(@string);
			IntPtr intPtr2 = intPtr;
			fixed (int* ptr = &length)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), shader, count, intPtr2, ptr, GL.EntryPoints[304]);
				BindingsBase.FreeStringArrayPtr(intPtr, @string.Length);
			}
		}

		// Token: 0x06003872 RID: 14450 RVA: 0x0009480C File Offset: 0x00092A0C
		[CLSCompliant(false)]
		public unsafe static void ShaderSource(int shader, int count, string[] @string, int* length)
		{
			IntPtr intPtr = BindingsBase.MarshalStringArrayToPtr(@string);
			calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), shader, count, intPtr, length, GL.EntryPoints[304]);
			BindingsBase.FreeStringArrayPtr(intPtr, @string.Length);
		}

		// Token: 0x06003873 RID: 14451 RVA: 0x00094840 File Offset: 0x00092A40
		[CLSCompliant(false)]
		public unsafe static void ShaderSource(uint shader, int count, string[] @string, int[] length)
		{
			IntPtr intPtr = BindingsBase.MarshalStringArrayToPtr(@string);
			IntPtr intPtr2 = intPtr;
			fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), shader, count, intPtr2, ptr, GL.EntryPoints[304]);
				BindingsBase.FreeStringArrayPtr(intPtr, @string.Length);
			}
		}

		// Token: 0x06003874 RID: 14452 RVA: 0x00094888 File Offset: 0x00092A88
		[CLSCompliant(false)]
		public unsafe static void ShaderSource(uint shader, int count, string[] @string, ref int length)
		{
			IntPtr intPtr = BindingsBase.MarshalStringArrayToPtr(@string);
			IntPtr intPtr2 = intPtr;
			fixed (int* ptr = &length)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), shader, count, intPtr2, ptr, GL.EntryPoints[304]);
				BindingsBase.FreeStringArrayPtr(intPtr, @string.Length);
			}
		}

		// Token: 0x06003875 RID: 14453 RVA: 0x000948BC File Offset: 0x00092ABC
		[CLSCompliant(false)]
		public unsafe static void ShaderSource(uint shader, int count, string[] @string, int* length)
		{
			IntPtr intPtr = BindingsBase.MarshalStringArrayToPtr(@string);
			calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), shader, count, intPtr, length, GL.EntryPoints[304]);
			BindingsBase.FreeStringArrayPtr(intPtr, @string.Length);
		}

		// Token: 0x06003876 RID: 14454 RVA: 0x000948F0 File Offset: 0x00092AF0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void StencilFunc(All func, int @ref, int mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.UInt32), func, @ref, mask, GL.EntryPoints[306]);
		}

		// Token: 0x06003877 RID: 14455 RVA: 0x00094908 File Offset: 0x00092B08
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void StencilFunc(All func, int @ref, uint mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.UInt32), func, @ref, mask, GL.EntryPoints[306]);
		}

		// Token: 0x06003878 RID: 14456 RVA: 0x00094920 File Offset: 0x00092B20
		[CLSCompliant(false)]
		public static void StencilFunc(StencilFunction func, int @ref, int mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.UInt32), func, @ref, mask, GL.EntryPoints[306]);
		}

		// Token: 0x06003879 RID: 14457 RVA: 0x00094938 File Offset: 0x00092B38
		[CLSCompliant(false)]
		public static void StencilFunc(StencilFunction func, int @ref, uint mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.UInt32), func, @ref, mask, GL.EntryPoints[306]);
		}

		// Token: 0x0600387A RID: 14458 RVA: 0x00094950 File Offset: 0x00092B50
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void StencilFuncSeparate(All face, All func, int @ref, int mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), face, func, @ref, mask, GL.EntryPoints[307]);
		}

		// Token: 0x0600387B RID: 14459 RVA: 0x00094968 File Offset: 0x00092B68
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void StencilFuncSeparate(All face, All func, int @ref, uint mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), face, func, @ref, mask, GL.EntryPoints[307]);
		}

		// Token: 0x0600387C RID: 14460 RVA: 0x00094980 File Offset: 0x00092B80
		[Obsolete("Use StencilFace overload instead")]
		[CLSCompliant(false)]
		public static void StencilFuncSeparate(CullFaceMode face, StencilFunction func, int @ref, int mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), face, func, @ref, mask, GL.EntryPoints[307]);
		}

		// Token: 0x0600387D RID: 14461 RVA: 0x00094998 File Offset: 0x00092B98
		[CLSCompliant(false)]
		[Obsolete("Use StencilFace overload instead")]
		public static void StencilFuncSeparate(CullFaceMode face, StencilFunction func, int @ref, uint mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), face, func, @ref, mask, GL.EntryPoints[307]);
		}

		// Token: 0x0600387E RID: 14462 RVA: 0x000949B0 File Offset: 0x00092BB0
		[CLSCompliant(false)]
		public static void StencilFuncSeparate(StencilFace face, StencilFunction func, int @ref, int mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), face, func, @ref, mask, GL.EntryPoints[307]);
		}

		// Token: 0x0600387F RID: 14463 RVA: 0x000949C8 File Offset: 0x00092BC8
		[CLSCompliant(false)]
		public static void StencilFuncSeparate(StencilFace face, StencilFunction func, int @ref, uint mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), face, func, @ref, mask, GL.EntryPoints[307]);
		}

		// Token: 0x06003880 RID: 14464 RVA: 0x000949E0 File Offset: 0x00092BE0
		[CLSCompliant(false)]
		public static void StencilMask(int mask)
		{
			calli(System.Void(System.UInt32), mask, GL.EntryPoints[308]);
		}

		// Token: 0x06003881 RID: 14465 RVA: 0x000949F4 File Offset: 0x00092BF4
		[CLSCompliant(false)]
		public static void StencilMask(uint mask)
		{
			calli(System.Void(System.UInt32), mask, GL.EntryPoints[308]);
		}

		// Token: 0x06003882 RID: 14466 RVA: 0x00094A08 File Offset: 0x00092C08
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static void StencilMaskSeparate(All face, int mask)
		{
			calli(System.Void(System.Int32,System.UInt32), face, mask, GL.EntryPoints[309]);
		}

		// Token: 0x06003883 RID: 14467 RVA: 0x00094A1C File Offset: 0x00092C1C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void StencilMaskSeparate(All face, uint mask)
		{
			calli(System.Void(System.Int32,System.UInt32), face, mask, GL.EntryPoints[309]);
		}

		// Token: 0x06003884 RID: 14468 RVA: 0x00094A30 File Offset: 0x00092C30
		[CLSCompliant(false)]
		[Obsolete("Use StencilFace overload instead")]
		public static void StencilMaskSeparate(CullFaceMode face, int mask)
		{
			calli(System.Void(System.Int32,System.UInt32), face, mask, GL.EntryPoints[309]);
		}

		// Token: 0x06003885 RID: 14469 RVA: 0x00094A44 File Offset: 0x00092C44
		[Obsolete("Use StencilFace overload instead")]
		[CLSCompliant(false)]
		public static void StencilMaskSeparate(CullFaceMode face, uint mask)
		{
			calli(System.Void(System.Int32,System.UInt32), face, mask, GL.EntryPoints[309]);
		}

		// Token: 0x06003886 RID: 14470 RVA: 0x00094A58 File Offset: 0x00092C58
		[CLSCompliant(false)]
		public static void StencilMaskSeparate(StencilFace face, int mask)
		{
			calli(System.Void(System.Int32,System.UInt32), face, mask, GL.EntryPoints[309]);
		}

		// Token: 0x06003887 RID: 14471 RVA: 0x00094A6C File Offset: 0x00092C6C
		[CLSCompliant(false)]
		public static void StencilMaskSeparate(StencilFace face, uint mask)
		{
			calli(System.Void(System.Int32,System.UInt32), face, mask, GL.EntryPoints[309]);
		}

		// Token: 0x06003888 RID: 14472 RVA: 0x00094A80 File Offset: 0x00092C80
		[Obsolete("Use strongly-typed overload instead")]
		public static void StencilOp(All fail, All zfail, All zpass)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), fail, zfail, zpass, GL.EntryPoints[310]);
		}

		// Token: 0x06003889 RID: 14473 RVA: 0x00094A98 File Offset: 0x00092C98
		public static void StencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), fail, zfail, zpass, GL.EntryPoints[310]);
		}

		// Token: 0x0600388A RID: 14474 RVA: 0x00094AB0 File Offset: 0x00092CB0
		[Obsolete("Use strongly-typed overload instead")]
		public static void StencilOpSeparate(All face, All sfail, All dpfail, All dppass)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), face, sfail, dpfail, dppass, GL.EntryPoints[311]);
		}

		// Token: 0x0600388B RID: 14475 RVA: 0x00094AC8 File Offset: 0x00092CC8
		[Obsolete("Use StencilFace overload instead")]
		public static void StencilOpSeparate(CullFaceMode face, StencilOp sfail, StencilOp dpfail, StencilOp dppass)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), face, sfail, dpfail, dppass, GL.EntryPoints[311]);
		}

		// Token: 0x0600388C RID: 14476 RVA: 0x00094AE0 File Offset: 0x00092CE0
		public static void StencilOpSeparate(StencilFace face, StencilOp sfail, StencilOp dpfail, StencilOp dppass)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), face, sfail, dpfail, dppass, GL.EntryPoints[311]);
		}

		// Token: 0x0600388D RID: 14477 RVA: 0x00094AF8 File Offset: 0x00092CF8
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexImage2D(All target, int level, All internalformat, int width, int height, int border, All format, All type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, pixels, GL.EntryPoints[315]);
		}

		// Token: 0x0600388E RID: 14478 RVA: 0x00094B24 File Offset: 0x00092D24
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(All target, int level, All internalformat, int width, int height, int border, All format, All type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x0600388F RID: 14479 RVA: 0x00094B68 File Offset: 0x00092D68
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexImage2D<T8>(All target, int level, All internalformat, int width, int height, int border, All format, All type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x06003890 RID: 14480 RVA: 0x00094BB0 File Offset: 0x00092DB0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(All target, int level, All internalformat, int width, int height, int border, All format, All type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x06003891 RID: 14481 RVA: 0x00094BF8 File Offset: 0x00092DF8
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexImage2D<T8>(All target, int level, All internalformat, int width, int height, int border, All format, All type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x06003892 RID: 14482 RVA: 0x00094C28 File Offset: 0x00092E28
		[Obsolete("Use TextureTarget2d overload instead")]
		public static void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, pixels, GL.EntryPoints[315]);
		}

		// Token: 0x06003893 RID: 14483 RVA: 0x00094C54 File Offset: 0x00092E54
		[Obsolete("Use TextureTarget2d overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x06003894 RID: 14484 RVA: 0x00094C98 File Offset: 0x00092E98
		[Obsolete("Use TextureTarget2d overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x06003895 RID: 14485 RVA: 0x00094CE0 File Offset: 0x00092EE0
		[Obsolete("Use TextureTarget2d overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x06003896 RID: 14486 RVA: 0x00094D28 File Offset: 0x00092F28
		[Obsolete("Use TextureTarget2d overload instead")]
		public unsafe static void TexImage2D<T8>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x06003897 RID: 14487 RVA: 0x00094D58 File Offset: 0x00092F58
		public static void TexImage2D(TextureTarget2d target, int level, TextureComponentCount internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, pixels, GL.EntryPoints[315]);
		}

		// Token: 0x06003898 RID: 14488 RVA: 0x00094D84 File Offset: 0x00092F84
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget2d target, int level, TextureComponentCount internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x06003899 RID: 14489 RVA: 0x00094DC8 File Offset: 0x00092FC8
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget2d target, int level, TextureComponentCount internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x0600389A RID: 14490 RVA: 0x00094E10 File Offset: 0x00093010
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget2d target, int level, TextureComponentCount internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x0600389B RID: 14491 RVA: 0x00094E58 File Offset: 0x00093058
		public unsafe static void TexImage2D<T8>(TextureTarget2d target, int level, TextureComponentCount internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[315]);
			}
		}

		// Token: 0x0600389C RID: 14492 RVA: 0x00094E88 File Offset: 0x00093088
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexParameter(All target, All pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), target, pname, param, GL.EntryPoints[317]);
		}

		// Token: 0x0600389D RID: 14493 RVA: 0x00094EA0 File Offset: 0x000930A0
		public static void TexParameter(TextureTarget target, TextureParameterName pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), target, pname, param, GL.EntryPoints[317]);
		}

		// Token: 0x0600389E RID: 14494 RVA: 0x00094EB8 File Offset: 0x000930B8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexParameter(All target, All pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[318]);
			}
		}

		// Token: 0x0600389F RID: 14495 RVA: 0x00094EF0 File Offset: 0x000930F0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexParameter(All target, All pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[318]);
		}

		// Token: 0x060038A0 RID: 14496 RVA: 0x00094F08 File Offset: 0x00093108
		[CLSCompliant(false)]
		public unsafe static void TexParameter(TextureTarget target, TextureParameterName pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[318]);
			}
		}

		// Token: 0x060038A1 RID: 14497 RVA: 0x00094F40 File Offset: 0x00093140
		[CLSCompliant(false)]
		public unsafe static void TexParameter(TextureTarget target, TextureParameterName pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[318]);
		}

		// Token: 0x060038A2 RID: 14498 RVA: 0x00094F58 File Offset: 0x00093158
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexParameter(All target, All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[319]);
		}

		// Token: 0x060038A3 RID: 14499 RVA: 0x00094F70 File Offset: 0x00093170
		public static void TexParameter(TextureTarget target, TextureParameterName pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[319]);
		}

		// Token: 0x060038A4 RID: 14500 RVA: 0x00094F88 File Offset: 0x00093188
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexParameter(All target, All pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[322]);
			}
		}

		// Token: 0x060038A5 RID: 14501 RVA: 0x00094FC0 File Offset: 0x000931C0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexParameter(All target, All pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[322]);
		}

		// Token: 0x060038A6 RID: 14502 RVA: 0x00094FD8 File Offset: 0x000931D8
		[CLSCompliant(false)]
		public unsafe static void TexParameter(TextureTarget target, TextureParameterName pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[322]);
			}
		}

		// Token: 0x060038A7 RID: 14503 RVA: 0x00095010 File Offset: 0x00093210
		[CLSCompliant(false)]
		public unsafe static void TexParameter(TextureTarget target, TextureParameterName pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[322]);
		}

		// Token: 0x060038A8 RID: 14504 RVA: 0x00095028 File Offset: 0x00093228
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexSubImage2D(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, pixels, GL.EntryPoints[327]);
		}

		// Token: 0x060038A9 RID: 14505 RVA: 0x00095054 File Offset: 0x00093254
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038AA RID: 14506 RVA: 0x00095098 File Offset: 0x00093298
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038AB RID: 14507 RVA: 0x000950E0 File Offset: 0x000932E0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038AC RID: 14508 RVA: 0x00095128 File Offset: 0x00093328
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038AD RID: 14509 RVA: 0x00095158 File Offset: 0x00093358
		[Obsolete("Use TextureTarget2d overload instead")]
		public static void TexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, pixels, GL.EntryPoints[327]);
		}

		// Token: 0x060038AE RID: 14510 RVA: 0x00095184 File Offset: 0x00093384
		[Obsolete("Use TextureTarget2d overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038AF RID: 14511 RVA: 0x000951C8 File Offset: 0x000933C8
		[CLSCompliant(false)]
		[Obsolete("Use TextureTarget2d overload instead")]
		public unsafe static void TexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038B0 RID: 14512 RVA: 0x00095210 File Offset: 0x00093410
		[Obsolete("Use TextureTarget2d overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038B1 RID: 14513 RVA: 0x00095258 File Offset: 0x00093458
		[Obsolete("Use TextureTarget2d overload instead")]
		public unsafe static void TexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038B2 RID: 14514 RVA: 0x00095288 File Offset: 0x00093488
		public static void TexSubImage2D(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, pixels, GL.EntryPoints[327]);
		}

		// Token: 0x060038B3 RID: 14515 RVA: 0x000952B4 File Offset: 0x000934B4
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038B4 RID: 14516 RVA: 0x000952F8 File Offset: 0x000934F8
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038B5 RID: 14517 RVA: 0x00095340 File Offset: 0x00093540
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038B6 RID: 14518 RVA: 0x00095388 File Offset: 0x00093588
		public unsafe static void TexSubImage2D<T8>(TextureTarget2d target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[327]);
			}
		}

		// Token: 0x060038B7 RID: 14519 RVA: 0x000953B8 File Offset: 0x000935B8
		public static void Uniform1(int location, float v0)
		{
			calli(System.Void(System.Int32,System.Single), location, v0, GL.EntryPoints[333]);
		}

		// Token: 0x060038B8 RID: 14520 RVA: 0x000953CC File Offset: 0x000935CC
		[CLSCompliant(false)]
		public unsafe static void Uniform1(int location, int count, float[] value)
		{
			fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, ptr, GL.EntryPoints[334]);
			}
		}

		// Token: 0x060038B9 RID: 14521 RVA: 0x00095404 File Offset: 0x00093604
		[CLSCompliant(false)]
		public unsafe static void Uniform1(int location, int count, ref float value)
		{
			fixed (float* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, ptr, GL.EntryPoints[334]);
			}
		}

		// Token: 0x060038BA RID: 14522 RVA: 0x00095428 File Offset: 0x00093628
		[CLSCompliant(false)]
		public unsafe static void Uniform1(int location, int count, float* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, value, GL.EntryPoints[334]);
		}

		// Token: 0x060038BB RID: 14523 RVA: 0x00095440 File Offset: 0x00093640
		public static void Uniform1(int location, int v0)
		{
			calli(System.Void(System.Int32,System.Int32), location, v0, GL.EntryPoints[335]);
		}

		// Token: 0x060038BC RID: 14524 RVA: 0x00095454 File Offset: 0x00093654
		[CLSCompliant(false)]
		public unsafe static void Uniform1(int location, int count, int[] value)
		{
			fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, ptr, GL.EntryPoints[336]);
			}
		}

		// Token: 0x060038BD RID: 14525 RVA: 0x0009548C File Offset: 0x0009368C
		[CLSCompliant(false)]
		public unsafe static void Uniform1(int location, int count, ref int value)
		{
			fixed (int* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, ptr, GL.EntryPoints[336]);
			}
		}

		// Token: 0x060038BE RID: 14526 RVA: 0x000954B0 File Offset: 0x000936B0
		[CLSCompliant(false)]
		public unsafe static void Uniform1(int location, int count, int* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, value, GL.EntryPoints[336]);
		}

		// Token: 0x060038BF RID: 14527 RVA: 0x000954C8 File Offset: 0x000936C8
		public static void Uniform2(int location, float v0, float v1)
		{
			calli(System.Void(System.Int32,System.Single,System.Single), location, v0, v1, GL.EntryPoints[337]);
		}

		// Token: 0x060038C0 RID: 14528 RVA: 0x000954E0 File Offset: 0x000936E0
		[CLSCompliant(false)]
		public unsafe static void Uniform2(int location, int count, float[] value)
		{
			fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, ptr, GL.EntryPoints[338]);
			}
		}

		// Token: 0x060038C1 RID: 14529 RVA: 0x00095518 File Offset: 0x00093718
		[CLSCompliant(false)]
		public unsafe static void Uniform2(int location, int count, ref float value)
		{
			fixed (float* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, ptr, GL.EntryPoints[338]);
			}
		}

		// Token: 0x060038C2 RID: 14530 RVA: 0x0009553C File Offset: 0x0009373C
		[CLSCompliant(false)]
		public unsafe static void Uniform2(int location, int count, float* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, value, GL.EntryPoints[338]);
		}

		// Token: 0x060038C3 RID: 14531 RVA: 0x00095554 File Offset: 0x00093754
		public static void Uniform2(int location, int v0, int v1)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), location, v0, v1, GL.EntryPoints[339]);
		}

		// Token: 0x060038C4 RID: 14532 RVA: 0x0009556C File Offset: 0x0009376C
		[CLSCompliant(false)]
		public unsafe static void Uniform2(int location, int count, int[] value)
		{
			fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, ptr, GL.EntryPoints[340]);
			}
		}

		// Token: 0x060038C5 RID: 14533 RVA: 0x000955A4 File Offset: 0x000937A4
		[CLSCompliant(false)]
		public unsafe static void Uniform2(int location, int count, int* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, value, GL.EntryPoints[340]);
		}

		// Token: 0x060038C6 RID: 14534 RVA: 0x000955BC File Offset: 0x000937BC
		public static void Uniform3(int location, float v0, float v1, float v2)
		{
			calli(System.Void(System.Int32,System.Single,System.Single,System.Single), location, v0, v1, v2, GL.EntryPoints[341]);
		}

		// Token: 0x060038C7 RID: 14535 RVA: 0x000955D4 File Offset: 0x000937D4
		[CLSCompliant(false)]
		public unsafe static void Uniform3(int location, int count, float[] value)
		{
			fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, ptr, GL.EntryPoints[342]);
			}
		}

		// Token: 0x060038C8 RID: 14536 RVA: 0x0009560C File Offset: 0x0009380C
		[CLSCompliant(false)]
		public unsafe static void Uniform3(int location, int count, ref float value)
		{
			fixed (float* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, ptr, GL.EntryPoints[342]);
			}
		}

		// Token: 0x060038C9 RID: 14537 RVA: 0x00095630 File Offset: 0x00093830
		[CLSCompliant(false)]
		public unsafe static void Uniform3(int location, int count, float* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, value, GL.EntryPoints[342]);
		}

		// Token: 0x060038CA RID: 14538 RVA: 0x00095648 File Offset: 0x00093848
		public static void Uniform3(int location, int v0, int v1, int v2)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), location, v0, v1, v2, GL.EntryPoints[343]);
		}

		// Token: 0x060038CB RID: 14539 RVA: 0x00095660 File Offset: 0x00093860
		[CLSCompliant(false)]
		public unsafe static void Uniform3(int location, int count, int[] value)
		{
			fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, ptr, GL.EntryPoints[344]);
			}
		}

		// Token: 0x060038CC RID: 14540 RVA: 0x00095698 File Offset: 0x00093898
		[CLSCompliant(false)]
		public unsafe static void Uniform3(int location, int count, ref int value)
		{
			fixed (int* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, ptr, GL.EntryPoints[344]);
			}
		}

		// Token: 0x060038CD RID: 14541 RVA: 0x000956BC File Offset: 0x000938BC
		[CLSCompliant(false)]
		public unsafe static void Uniform3(int location, int count, int* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, value, GL.EntryPoints[344]);
		}

		// Token: 0x060038CE RID: 14542 RVA: 0x000956D4 File Offset: 0x000938D4
		public static void Uniform4(int location, float v0, float v1, float v2, float v3)
		{
			calli(System.Void(System.Int32,System.Single,System.Single,System.Single,System.Single), location, v0, v1, v2, v3, GL.EntryPoints[345]);
		}

		// Token: 0x060038CF RID: 14543 RVA: 0x000956EC File Offset: 0x000938EC
		[CLSCompliant(false)]
		public unsafe static void Uniform4(int location, int count, float[] value)
		{
			fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, ptr, GL.EntryPoints[346]);
			}
		}

		// Token: 0x060038D0 RID: 14544 RVA: 0x00095724 File Offset: 0x00093924
		[CLSCompliant(false)]
		public unsafe static void Uniform4(int location, int count, ref float value)
		{
			fixed (float* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, ptr, GL.EntryPoints[346]);
			}
		}

		// Token: 0x060038D1 RID: 14545 RVA: 0x00095748 File Offset: 0x00093948
		[CLSCompliant(false)]
		public unsafe static void Uniform4(int location, int count, float* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), location, count, value, GL.EntryPoints[346]);
		}

		// Token: 0x060038D2 RID: 14546 RVA: 0x00095760 File Offset: 0x00093960
		public static void Uniform4(int location, int v0, int v1, int v2, int v3)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), location, v0, v1, v2, v3, GL.EntryPoints[347]);
		}

		// Token: 0x060038D3 RID: 14547 RVA: 0x00095778 File Offset: 0x00093978
		[CLSCompliant(false)]
		public unsafe static void Uniform4(int location, int count, int[] value)
		{
			fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x060038D4 RID: 14548 RVA: 0x000957B0 File Offset: 0x000939B0
		[CLSCompliant(false)]
		public unsafe static void Uniform4(int location, int count, ref int value)
		{
			fixed (int* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x060038D5 RID: 14549 RVA: 0x000957D4 File Offset: 0x000939D4
		[CLSCompliant(false)]
		public unsafe static void Uniform4(int location, int count, int* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), location, count, value, GL.EntryPoints[348]);
		}

		// Token: 0x060038D6 RID: 14550 RVA: 0x000957EC File Offset: 0x000939EC
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix2(int location, int count, bool transpose, float[] value)
		{
			fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[349]);
			}
		}

		// Token: 0x060038D7 RID: 14551 RVA: 0x00095824 File Offset: 0x00093A24
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix2(int location, int count, bool transpose, ref float value)
		{
			fixed (float* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[349]);
			}
		}

		// Token: 0x060038D8 RID: 14552 RVA: 0x00095848 File Offset: 0x00093A48
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix2(int location, int count, bool transpose, float* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[349]);
		}

		// Token: 0x060038D9 RID: 14553 RVA: 0x00095860 File Offset: 0x00093A60
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix3(int location, int count, bool transpose, float[] value)
		{
			fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[352]);
			}
		}

		// Token: 0x060038DA RID: 14554 RVA: 0x00095898 File Offset: 0x00093A98
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix3(int location, int count, bool transpose, ref float value)
		{
			fixed (float* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[352]);
			}
		}

		// Token: 0x060038DB RID: 14555 RVA: 0x000958BC File Offset: 0x00093ABC
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix3(int location, int count, bool transpose, float* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[352]);
		}

		// Token: 0x060038DC RID: 14556 RVA: 0x000958D4 File Offset: 0x00093AD4
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix4(int location, int count, bool transpose, float[] value)
		{
			fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[355]);
			}
		}

		// Token: 0x060038DD RID: 14557 RVA: 0x0009590C File Offset: 0x00093B0C
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix4(int location, int count, bool transpose, ref float value)
		{
			fixed (float* ptr = &value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[355]);
			}
		}

		// Token: 0x060038DE RID: 14558 RVA: 0x00095930 File Offset: 0x00093B30
		[CLSCompliant(false)]
		public unsafe static void UniformMatrix4(int location, int count, bool transpose, float* value)
		{
			calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[355]);
		}

		// Token: 0x060038DF RID: 14559 RVA: 0x00095948 File Offset: 0x00093B48
		[CLSCompliant(false)]
		public static void UseProgram(int program)
		{
			calli(System.Void(System.UInt32), program, GL.EntryPoints[359]);
		}

		// Token: 0x060038E0 RID: 14560 RVA: 0x0009595C File Offset: 0x00093B5C
		[CLSCompliant(false)]
		public static void UseProgram(uint program)
		{
			calli(System.Void(System.UInt32), program, GL.EntryPoints[359]);
		}

		// Token: 0x060038E1 RID: 14561 RVA: 0x00095970 File Offset: 0x00093B70
		[CLSCompliant(false)]
		public static void ValidateProgram(int program)
		{
			calli(System.Void(System.UInt32), program, GL.EntryPoints[362]);
		}

		// Token: 0x060038E2 RID: 14562 RVA: 0x00095984 File Offset: 0x00093B84
		[CLSCompliant(false)]
		public static void ValidateProgram(uint program)
		{
			calli(System.Void(System.UInt32), program, GL.EntryPoints[362]);
		}

		// Token: 0x060038E3 RID: 14563 RVA: 0x00095998 File Offset: 0x00093B98
		[CLSCompliant(false)]
		public static void VertexAttrib1(int index, float x)
		{
			calli(System.Void(System.UInt32,System.Single), index, x, GL.EntryPoints[364]);
		}

		// Token: 0x060038E4 RID: 14564 RVA: 0x000959AC File Offset: 0x00093BAC
		[CLSCompliant(false)]
		public static void VertexAttrib1(uint index, float x)
		{
			calli(System.Void(System.UInt32,System.Single), index, x, GL.EntryPoints[364]);
		}

		// Token: 0x060038E5 RID: 14565 RVA: 0x000959C0 File Offset: 0x00093BC0
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib1(int index, float[] v)
		{
			fixed (float* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[365]);
			}
		}

		// Token: 0x060038E6 RID: 14566 RVA: 0x000959F4 File Offset: 0x00093BF4
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib1(int index, float* v)
		{
			calli(System.Void(System.UInt32,System.Single*), index, v, GL.EntryPoints[365]);
		}

		// Token: 0x060038E7 RID: 14567 RVA: 0x00095A08 File Offset: 0x00093C08
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib1(uint index, float[] v)
		{
			fixed (float* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[365]);
			}
		}

		// Token: 0x060038E8 RID: 14568 RVA: 0x00095A3C File Offset: 0x00093C3C
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib1(uint index, float* v)
		{
			calli(System.Void(System.UInt32,System.Single*), index, v, GL.EntryPoints[365]);
		}

		// Token: 0x060038E9 RID: 14569 RVA: 0x00095A50 File Offset: 0x00093C50
		[CLSCompliant(false)]
		public static void VertexAttrib2(int index, float x, float y)
		{
			calli(System.Void(System.UInt32,System.Single,System.Single), index, x, y, GL.EntryPoints[366]);
		}

		// Token: 0x060038EA RID: 14570 RVA: 0x00095A68 File Offset: 0x00093C68
		[CLSCompliant(false)]
		public static void VertexAttrib2(uint index, float x, float y)
		{
			calli(System.Void(System.UInt32,System.Single,System.Single), index, x, y, GL.EntryPoints[366]);
		}

		// Token: 0x060038EB RID: 14571 RVA: 0x00095A80 File Offset: 0x00093C80
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib2(int index, float[] v)
		{
			fixed (float* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[367]);
			}
		}

		// Token: 0x060038EC RID: 14572 RVA: 0x00095AB4 File Offset: 0x00093CB4
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib2(int index, ref float v)
		{
			fixed (float* ptr = &v)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[367]);
			}
		}

		// Token: 0x060038ED RID: 14573 RVA: 0x00095AD8 File Offset: 0x00093CD8
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib2(int index, float* v)
		{
			calli(System.Void(System.UInt32,System.Single*), index, v, GL.EntryPoints[367]);
		}

		// Token: 0x060038EE RID: 14574 RVA: 0x00095AEC File Offset: 0x00093CEC
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib2(uint index, float[] v)
		{
			fixed (float* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[367]);
			}
		}

		// Token: 0x060038EF RID: 14575 RVA: 0x00095B20 File Offset: 0x00093D20
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib2(uint index, ref float v)
		{
			fixed (float* ptr = &v)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[367]);
			}
		}

		// Token: 0x060038F0 RID: 14576 RVA: 0x00095B44 File Offset: 0x00093D44
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib2(uint index, float* v)
		{
			calli(System.Void(System.UInt32,System.Single*), index, v, GL.EntryPoints[367]);
		}

		// Token: 0x060038F1 RID: 14577 RVA: 0x00095B58 File Offset: 0x00093D58
		[CLSCompliant(false)]
		public static void VertexAttrib3(int index, float x, float y, float z)
		{
			calli(System.Void(System.UInt32,System.Single,System.Single,System.Single), index, x, y, z, GL.EntryPoints[368]);
		}

		// Token: 0x060038F2 RID: 14578 RVA: 0x00095B70 File Offset: 0x00093D70
		[CLSCompliant(false)]
		public static void VertexAttrib3(uint index, float x, float y, float z)
		{
			calli(System.Void(System.UInt32,System.Single,System.Single,System.Single), index, x, y, z, GL.EntryPoints[368]);
		}

		// Token: 0x060038F3 RID: 14579 RVA: 0x00095B88 File Offset: 0x00093D88
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib3(int index, float[] v)
		{
			fixed (float* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[369]);
			}
		}

		// Token: 0x060038F4 RID: 14580 RVA: 0x00095BBC File Offset: 0x00093DBC
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib3(int index, ref float v)
		{
			fixed (float* ptr = &v)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[369]);
			}
		}

		// Token: 0x060038F5 RID: 14581 RVA: 0x00095BE0 File Offset: 0x00093DE0
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib3(int index, float* v)
		{
			calli(System.Void(System.UInt32,System.Single*), index, v, GL.EntryPoints[369]);
		}

		// Token: 0x060038F6 RID: 14582 RVA: 0x00095BF4 File Offset: 0x00093DF4
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib3(uint index, float[] v)
		{
			fixed (float* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[369]);
			}
		}

		// Token: 0x060038F7 RID: 14583 RVA: 0x00095C28 File Offset: 0x00093E28
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib3(uint index, ref float v)
		{
			fixed (float* ptr = &v)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[369]);
			}
		}

		// Token: 0x060038F8 RID: 14584 RVA: 0x00095C4C File Offset: 0x00093E4C
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib3(uint index, float* v)
		{
			calli(System.Void(System.UInt32,System.Single*), index, v, GL.EntryPoints[369]);
		}

		// Token: 0x060038F9 RID: 14585 RVA: 0x00095C60 File Offset: 0x00093E60
		[CLSCompliant(false)]
		public static void VertexAttrib4(int index, float x, float y, float z, float w)
		{
			calli(System.Void(System.UInt32,System.Single,System.Single,System.Single,System.Single), index, x, y, z, w, GL.EntryPoints[370]);
		}

		// Token: 0x060038FA RID: 14586 RVA: 0x00095C78 File Offset: 0x00093E78
		[CLSCompliant(false)]
		public static void VertexAttrib4(uint index, float x, float y, float z, float w)
		{
			calli(System.Void(System.UInt32,System.Single,System.Single,System.Single,System.Single), index, x, y, z, w, GL.EntryPoints[370]);
		}

		// Token: 0x060038FB RID: 14587 RVA: 0x00095C90 File Offset: 0x00093E90
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib4(int index, float[] v)
		{
			fixed (float* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[371]);
			}
		}

		// Token: 0x060038FC RID: 14588 RVA: 0x00095CC4 File Offset: 0x00093EC4
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib4(int index, ref float v)
		{
			fixed (float* ptr = &v)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[371]);
			}
		}

		// Token: 0x060038FD RID: 14589 RVA: 0x00095CE8 File Offset: 0x00093EE8
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib4(int index, float* v)
		{
			calli(System.Void(System.UInt32,System.Single*), index, v, GL.EntryPoints[371]);
		}

		// Token: 0x060038FE RID: 14590 RVA: 0x00095CFC File Offset: 0x00093EFC
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib4(uint index, float[] v)
		{
			fixed (float* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[371]);
			}
		}

		// Token: 0x060038FF RID: 14591 RVA: 0x00095D30 File Offset: 0x00093F30
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib4(uint index, ref float v)
		{
			fixed (float* ptr = &v)
			{
				calli(System.Void(System.UInt32,System.Single*), index, ptr, GL.EntryPoints[371]);
			}
		}

		// Token: 0x06003900 RID: 14592 RVA: 0x00095D54 File Offset: 0x00093F54
		[CLSCompliant(false)]
		public unsafe static void VertexAttrib4(uint index, float* v)
		{
			calli(System.Void(System.UInt32,System.Single*), index, v, GL.EntryPoints[371]);
		}

		// Token: 0x06003901 RID: 14593 RVA: 0x00095D68 File Offset: 0x00093F68
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void VertexAttribPointer(int index, int size, All type, bool normalized, int stride, IntPtr pointer)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, pointer, GL.EntryPoints[375]);
		}

		// Token: 0x06003902 RID: 14594 RVA: 0x00095D84 File Offset: 0x00093F84
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void VertexAttribPointer<T5>(int index, int size, All type, bool normalized, int stride, [In] [Out] T5[] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003903 RID: 14595 RVA: 0x00095DC0 File Offset: 0x00093FC0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void VertexAttribPointer<T5>(int index, int size, All type, bool normalized, int stride, [In] [Out] T5[,] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003904 RID: 14596 RVA: 0x00095E00 File Offset: 0x00094000
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(int index, int size, All type, bool normalized, int stride, [In] [Out] T5[,,] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003905 RID: 14597 RVA: 0x00095E44 File Offset: 0x00094044
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(int index, int size, All type, bool normalized, int stride, [In] [Out] ref T5 pointer) where T5 : struct
		{
			fixed (T5* ptr = &pointer)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003906 RID: 14598 RVA: 0x00095E6C File Offset: 0x0009406C
		[CLSCompliant(false)]
		public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, pointer, GL.EntryPoints[375]);
		}

		// Token: 0x06003907 RID: 14599 RVA: 0x00095E88 File Offset: 0x00094088
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(int index, int size, VertexAttribPointerType type, bool normalized, int stride, [In] [Out] T5[] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003908 RID: 14600 RVA: 0x00095EC4 File Offset: 0x000940C4
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(int index, int size, VertexAttribPointerType type, bool normalized, int stride, [In] [Out] T5[,] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003909 RID: 14601 RVA: 0x00095F04 File Offset: 0x00094104
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(int index, int size, VertexAttribPointerType type, bool normalized, int stride, [In] [Out] T5[,,] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x0600390A RID: 14602 RVA: 0x00095F48 File Offset: 0x00094148
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(int index, int size, VertexAttribPointerType type, bool normalized, int stride, [In] [Out] ref T5 pointer) where T5 : struct
		{
			fixed (T5* ptr = &pointer)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x0600390B RID: 14603 RVA: 0x00095F70 File Offset: 0x00094170
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void VertexAttribPointer(uint index, int size, All type, bool normalized, int stride, IntPtr pointer)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, pointer, GL.EntryPoints[375]);
		}

		// Token: 0x0600390C RID: 14604 RVA: 0x00095F8C File Offset: 0x0009418C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void VertexAttribPointer<T5>(uint index, int size, All type, bool normalized, int stride, [In] [Out] T5[] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x0600390D RID: 14605 RVA: 0x00095FC8 File Offset: 0x000941C8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void VertexAttribPointer<T5>(uint index, int size, All type, bool normalized, int stride, [In] [Out] T5[,] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x0600390E RID: 14606 RVA: 0x00096008 File Offset: 0x00094208
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(uint index, int size, All type, bool normalized, int stride, [In] [Out] T5[,,] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x0600390F RID: 14607 RVA: 0x0009604C File Offset: 0x0009424C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void VertexAttribPointer<T5>(uint index, int size, All type, bool normalized, int stride, [In] [Out] ref T5 pointer) where T5 : struct
		{
			fixed (T5* ptr = &pointer)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003910 RID: 14608 RVA: 0x00096074 File Offset: 0x00094274
		[CLSCompliant(false)]
		public static void VertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer)
		{
			calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, pointer, GL.EntryPoints[375]);
		}

		// Token: 0x06003911 RID: 14609 RVA: 0x00096090 File Offset: 0x00094290
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, [In] [Out] T5[] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003912 RID: 14610 RVA: 0x000960CC File Offset: 0x000942CC
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, [In] [Out] T5[,] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003913 RID: 14611 RVA: 0x0009610C File Offset: 0x0009430C
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, [In] [Out] T5[,,] pointer) where T5 : struct
		{
			fixed (T5* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003914 RID: 14612 RVA: 0x00096150 File Offset: 0x00094350
		[CLSCompliant(false)]
		public unsafe static void VertexAttribPointer<T5>(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, [In] [Out] ref T5 pointer) where T5 : struct
		{
			fixed (T5* ptr = &pointer)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Int32,System.IntPtr), index, size, type, normalized, stride, ptr, GL.EntryPoints[375]);
			}
		}

		// Token: 0x06003915 RID: 14613 RVA: 0x00096178 File Offset: 0x00094378
		public static void Viewport(int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), x, y, width, height, GL.EntryPoints[376]);
		}

		// Token: 0x04004CEE RID: 19694
		private const string Library = "libGLESv2.dll";

		// Token: 0x04004CEF RID: 19695
		private static readonly object sync_root = new object();

		// Token: 0x04004CF0 RID: 19696
		private static IntPtr[] EntryPoints;

		// Token: 0x04004CF1 RID: 19697
		private static byte[] EntryPointNames = new byte[]
		{
			103,
			108,
			65,
			99,
			116,
			105,
			118,
			101,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			69,
			88,
			84,
			0,
			103,
			108,
			65,
			99,
			116,
			105,
			118,
			101,
			83,
			104,
			97,
			100,
			101,
			114,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			69,
			88,
			84,
			0,
			103,
			108,
			65,
			99,
			116,
			105,
			118,
			101,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			0,
			103,
			108,
			65,
			108,
			112,
			104,
			97,
			70,
			117,
			110,
			99,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			65,
			116,
			116,
			97,
			99,
			104,
			83,
			104,
			97,
			100,
			101,
			114,
			0,
			103,
			108,
			66,
			101,
			103,
			105,
			110,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			65,
			77,
			68,
			0,
			103,
			108,
			66,
			101,
			103,
			105,
			110,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			66,
			101,
			103,
			105,
			110,
			81,
			117,
			101,
			114,
			121,
			69,
			88,
			84,
			0,
			103,
			108,
			66,
			105,
			110,
			100,
			65,
			116,
			116,
			114,
			105,
			98,
			76,
			111,
			99,
			97,
			116,
			105,
			111,
			110,
			0,
			103,
			108,
			66,
			105,
			110,
			100,
			66,
			117,
			102,
			102,
			101,
			114,
			0,
			103,
			108,
			66,
			105,
			110,
			100,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			0,
			103,
			108,
			66,
			105,
			110,
			100,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			80,
			105,
			112,
			101,
			108,
			105,
			110,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			66,
			105,
			110,
			100,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			0,
			103,
			108,
			66,
			105,
			110,
			100,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			0,
			103,
			108,
			66,
			105,
			110,
			100,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			114,
			114,
			97,
			121,
			79,
			69,
			83,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			66,
			97,
			114,
			114,
			105,
			101,
			114,
			75,
			72,
			82,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			66,
			97,
			114,
			114,
			105,
			101,
			114,
			78,
			86,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			67,
			111,
			108,
			111,
			114,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			69,
			113,
			117,
			97,
			116,
			105,
			111,
			110,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			69,
			113,
			117,
			97,
			116,
			105,
			111,
			110,
			69,
			88,
			84,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			69,
			113,
			117,
			97,
			116,
			105,
			111,
			110,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			69,
			113,
			117,
			97,
			116,
			105,
			111,
			110,
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			101,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			69,
			113,
			117,
			97,
			116,
			105,
			111,
			110,
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			101,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			70,
			117,
			110,
			99,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			70,
			117,
			110,
			99,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			70,
			117,
			110,
			99,
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			101,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			70,
			117,
			110,
			99,
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			101,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			66,
			108,
			101,
			110,
			100,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			78,
			86,
			0,
			103,
			108,
			66,
			108,
			105,
			116,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			65,
			78,
			71,
			76,
			69,
			0,
			103,
			108,
			66,
			108,
			105,
			116,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			78,
			86,
			0,
			103,
			108,
			66,
			117,
			102,
			102,
			101,
			114,
			68,
			97,
			116,
			97,
			0,
			103,
			108,
			66,
			117,
			102,
			102,
			101,
			114,
			83,
			117,
			98,
			68,
			97,
			116,
			97,
			0,
			103,
			108,
			67,
			104,
			101,
			99,
			107,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			83,
			116,
			97,
			116,
			117,
			115,
			0,
			103,
			108,
			67,
			108,
			101,
			97,
			114,
			0,
			103,
			108,
			67,
			108,
			101,
			97,
			114,
			67,
			111,
			108,
			111,
			114,
			0,
			103,
			108,
			67,
			108,
			101,
			97,
			114,
			68,
			101,
			112,
			116,
			104,
			102,
			0,
			103,
			108,
			67,
			108,
			101,
			97,
			114,
			83,
			116,
			101,
			110,
			99,
			105,
			108,
			0,
			103,
			108,
			67,
			108,
			105,
			101,
			110,
			116,
			87,
			97,
			105,
			116,
			83,
			121,
			110,
			99,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			77,
			97,
			115,
			107,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			77,
			97,
			115,
			107,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			67,
			111,
			109,
			112,
			105,
			108,
			101,
			83,
			104,
			97,
			100,
			101,
			114,
			0,
			103,
			108,
			67,
			111,
			109,
			112,
			114,
			101,
			115,
			115,
			101,
			100,
			84,
			101,
			120,
			73,
			109,
			97,
			103,
			101,
			50,
			68,
			0,
			103,
			108,
			67,
			111,
			109,
			112,
			114,
			101,
			115,
			115,
			101,
			100,
			84,
			101,
			120,
			73,
			109,
			97,
			103,
			101,
			51,
			68,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			111,
			109,
			112,
			114,
			101,
			115,
			115,
			101,
			100,
			84,
			101,
			120,
			83,
			117,
			98,
			73,
			109,
			97,
			103,
			101,
			50,
			68,
			0,
			103,
			108,
			67,
			111,
			109,
			112,
			114,
			101,
			115,
			115,
			101,
			100,
			84,
			101,
			120,
			83,
			117,
			98,
			73,
			109,
			97,
			103,
			101,
			51,
			68,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			111,
			112,
			121,
			66,
			117,
			102,
			102,
			101,
			114,
			83,
			117,
			98,
			68,
			97,
			116,
			97,
			78,
			86,
			0,
			103,
			108,
			67,
			111,
			112,
			121,
			73,
			109,
			97,
			103,
			101,
			83,
			117,
			98,
			68,
			97,
			116,
			97,
			69,
			88,
			84,
			0,
			103,
			108,
			67,
			111,
			112,
			121,
			84,
			101,
			120,
			73,
			109,
			97,
			103,
			101,
			50,
			68,
			0,
			103,
			108,
			67,
			111,
			112,
			121,
			84,
			101,
			120,
			83,
			117,
			98,
			73,
			109,
			97,
			103,
			101,
			50,
			68,
			0,
			103,
			108,
			67,
			111,
			112,
			121,
			84,
			101,
			120,
			83,
			117,
			98,
			73,
			109,
			97,
			103,
			101,
			51,
			68,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			111,
			112,
			121,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			76,
			101,
			118,
			101,
			108,
			115,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			67,
			111,
			118,
			101,
			114,
			97,
			103,
			101,
			77,
			97,
			115,
			107,
			78,
			86,
			0,
			103,
			108,
			67,
			111,
			118,
			101,
			114,
			97,
			103,
			101,
			79,
			112,
			101,
			114,
			97,
			116,
			105,
			111,
			110,
			78,
			86,
			0,
			103,
			108,
			67,
			114,
			101,
			97,
			116,
			101,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			67,
			114,
			101,
			97,
			116,
			101,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			0,
			103,
			108,
			67,
			114,
			101,
			97,
			116,
			101,
			83,
			104,
			97,
			100,
			101,
			114,
			0,
			103,
			108,
			67,
			114,
			101,
			97,
			116,
			101,
			83,
			104,
			97,
			100,
			101,
			114,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			69,
			88,
			84,
			0,
			103,
			108,
			67,
			114,
			101,
			97,
			116,
			101,
			83,
			104,
			97,
			100,
			101,
			114,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			67,
			117,
			108,
			108,
			70,
			97,
			99,
			101,
			0,
			103,
			108,
			68,
			101,
			98,
			117,
			103,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			67,
			97,
			108,
			108,
			98,
			97,
			99,
			107,
			0,
			103,
			108,
			68,
			101,
			98,
			117,
			103,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			67,
			97,
			108,
			108,
			98,
			97,
			99,
			107,
			75,
			72,
			82,
			0,
			103,
			108,
			68,
			101,
			98,
			117,
			103,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			0,
			103,
			108,
			68,
			101,
			98,
			117,
			103,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			75,
			72,
			82,
			0,
			103,
			108,
			68,
			101,
			98,
			117,
			103,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			73,
			110,
			115,
			101,
			114,
			116,
			0,
			103,
			108,
			68,
			101,
			98,
			117,
			103,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			73,
			110,
			115,
			101,
			114,
			116,
			75,
			72,
			82,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			66,
			117,
			102,
			102,
			101,
			114,
			115,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			70,
			101,
			110,
			99,
			101,
			115,
			78,
			86,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			115,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			115,
			65,
			77,
			68,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			80,
			105,
			112,
			101,
			108,
			105,
			110,
			101,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			81,
			117,
			101,
			114,
			105,
			101,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			115,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			83,
			104,
			97,
			100,
			101,
			114,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			83,
			121,
			110,
			99,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			0,
			103,
			108,
			68,
			101,
			108,
			101,
			116,
			101,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			114,
			114,
			97,
			121,
			115,
			79,
			69,
			83,
			0,
			103,
			108,
			68,
			101,
			112,
			116,
			104,
			70,
			117,
			110,
			99,
			0,
			103,
			108,
			68,
			101,
			112,
			116,
			104,
			77,
			97,
			115,
			107,
			0,
			103,
			108,
			68,
			101,
			112,
			116,
			104,
			82,
			97,
			110,
			103,
			101,
			102,
			0,
			103,
			108,
			68,
			101,
			116,
			97,
			99,
			104,
			83,
			104,
			97,
			100,
			101,
			114,
			0,
			103,
			108,
			68,
			105,
			115,
			97,
			98,
			108,
			101,
			0,
			103,
			108,
			68,
			105,
			115,
			97,
			98,
			108,
			101,
			68,
			114,
			105,
			118,
			101,
			114,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			68,
			105,
			115,
			97,
			98,
			108,
			101,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			68,
			105,
			115,
			97,
			98,
			108,
			101,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			65,
			114,
			114,
			97,
			121,
			0,
			103,
			108,
			68,
			105,
			115,
			99,
			97,
			114,
			100,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			69,
			88,
			84,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			65,
			114,
			114,
			97,
			121,
			115,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			65,
			114,
			114,
			97,
			121,
			115,
			73,
			110,
			115,
			116,
			97,
			110,
			99,
			101,
			100,
			65,
			78,
			71,
			76,
			69,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			65,
			114,
			114,
			97,
			121,
			115,
			73,
			110,
			115,
			116,
			97,
			110,
			99,
			101,
			100,
			69,
			88,
			84,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			65,
			114,
			114,
			97,
			121,
			115,
			73,
			110,
			115,
			116,
			97,
			110,
			99,
			101,
			100,
			78,
			86,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			66,
			117,
			102,
			102,
			101,
			114,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			66,
			117,
			102,
			102,
			101,
			114,
			115,
			73,
			110,
			100,
			101,
			120,
			101,
			100,
			69,
			88,
			84,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			66,
			117,
			102,
			102,
			101,
			114,
			115,
			78,
			86,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			115,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			115,
			73,
			110,
			115,
			116,
			97,
			110,
			99,
			101,
			100,
			65,
			78,
			71,
			76,
			69,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			115,
			73,
			110,
			115,
			116,
			97,
			110,
			99,
			101,
			100,
			69,
			88,
			84,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			115,
			73,
			110,
			115,
			116,
			97,
			110,
			99,
			101,
			100,
			78,
			86,
			0,
			103,
			108,
			69,
			71,
			76,
			73,
			109,
			97,
			103,
			101,
			84,
			97,
			114,
			103,
			101,
			116,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			79,
			69,
			83,
			0,
			103,
			108,
			69,
			71,
			76,
			73,
			109,
			97,
			103,
			101,
			84,
			97,
			114,
			103,
			101,
			116,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			50,
			68,
			79,
			69,
			83,
			0,
			103,
			108,
			69,
			110,
			97,
			98,
			108,
			101,
			0,
			103,
			108,
			69,
			110,
			97,
			98,
			108,
			101,
			68,
			114,
			105,
			118,
			101,
			114,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			110,
			97,
			98,
			108,
			101,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			69,
			110,
			97,
			98,
			108,
			101,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			65,
			114,
			114,
			97,
			121,
			0,
			103,
			108,
			69,
			110,
			100,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			65,
			77,
			68,
			0,
			103,
			108,
			69,
			110,
			100,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			69,
			110,
			100,
			81,
			117,
			101,
			114,
			121,
			69,
			88,
			84,
			0,
			103,
			108,
			69,
			110,
			100,
			84,
			105,
			108,
			105,
			110,
			103,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			66,
			117,
			102,
			102,
			101,
			114,
			80,
			111,
			105,
			110,
			116,
			101,
			114,
			118,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			66,
			117,
			102,
			102,
			101,
			114,
			115,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			115,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			66,
			105,
			110,
			97,
			114,
			121,
			83,
			111,
			117,
			114,
			99,
			101,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			115,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			115,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			83,
			104,
			97,
			100,
			101,
			114,
			115,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			84,
			101,
			120,
			76,
			101,
			118,
			101,
			108,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			118,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			84,
			101,
			120,
			83,
			117,
			98,
			73,
			109,
			97,
			103,
			101,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			71,
			101,
			116,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			73,
			115,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			66,
			105,
			110,
			97,
			114,
			121,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			69,
			120,
			116,
			84,
			101,
			120,
			79,
			98,
			106,
			101,
			99,
			116,
			83,
			116,
			97,
			116,
			101,
			79,
			118,
			101,
			114,
			114,
			105,
			100,
			101,
			105,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			70,
			101,
			110,
			99,
			101,
			83,
			121,
			110,
			99,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			70,
			105,
			110,
			105,
			115,
			104,
			0,
			103,
			108,
			70,
			105,
			110,
			105,
			115,
			104,
			70,
			101,
			110,
			99,
			101,
			78,
			86,
			0,
			103,
			108,
			70,
			108,
			117,
			115,
			104,
			0,
			103,
			108,
			70,
			108,
			117,
			115,
			104,
			77,
			97,
			112,
			112,
			101,
			100,
			66,
			117,
			102,
			102,
			101,
			114,
			82,
			97,
			110,
			103,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			0,
			103,
			108,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			50,
			68,
			0,
			103,
			108,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			50,
			68,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			50,
			68,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			73,
			77,
			71,
			0,
			103,
			108,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			51,
			68,
			79,
			69,
			83,
			0,
			103,
			108,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			70,
			114,
			111,
			110,
			116,
			70,
			97,
			99,
			101,
			0,
			103,
			108,
			71,
			101,
			110,
			66,
			117,
			102,
			102,
			101,
			114,
			115,
			0,
			103,
			108,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			101,
			77,
			105,
			112,
			109,
			97,
			112,
			0,
			103,
			108,
			71,
			101,
			110,
			70,
			101,
			110,
			99,
			101,
			115,
			78,
			86,
			0,
			103,
			108,
			71,
			101,
			110,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			115,
			0,
			103,
			108,
			71,
			101,
			110,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			115,
			65,
			77,
			68,
			0,
			103,
			108,
			71,
			101,
			110,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			80,
			105,
			112,
			101,
			108,
			105,
			110,
			101,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			110,
			81,
			117,
			101,
			114,
			105,
			101,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			110,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			115,
			0,
			103,
			108,
			71,
			101,
			110,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			0,
			103,
			108,
			71,
			101,
			110,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			114,
			114,
			97,
			121,
			115,
			79,
			69,
			83,
			0,
			103,
			108,
			71,
			101,
			116,
			65,
			99,
			116,
			105,
			118,
			101,
			65,
			116,
			116,
			114,
			105,
			98,
			0,
			103,
			108,
			71,
			101,
			116,
			65,
			99,
			116,
			105,
			118,
			101,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			0,
			103,
			108,
			71,
			101,
			116,
			65,
			116,
			116,
			97,
			99,
			104,
			101,
			100,
			83,
			104,
			97,
			100,
			101,
			114,
			115,
			0,
			103,
			108,
			71,
			101,
			116,
			65,
			116,
			116,
			114,
			105,
			98,
			76,
			111,
			99,
			97,
			116,
			105,
			111,
			110,
			0,
			103,
			108,
			71,
			101,
			116,
			66,
			111,
			111,
			108,
			101,
			97,
			110,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			66,
			117,
			102,
			102,
			101,
			114,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			66,
			117,
			102,
			102,
			101,
			114,
			80,
			111,
			105,
			110,
			116,
			101,
			114,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			71,
			101,
			116,
			68,
			101,
			98,
			117,
			103,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			76,
			111,
			103,
			0,
			103,
			108,
			71,
			101,
			116,
			68,
			101,
			98,
			117,
			103,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			76,
			111,
			103,
			75,
			72,
			82,
			0,
			103,
			108,
			71,
			101,
			116,
			68,
			114,
			105,
			118,
			101,
			114,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			115,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			71,
			101,
			116,
			68,
			114,
			105,
			118,
			101,
			114,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			83,
			116,
			114,
			105,
			110,
			103,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			71,
			101,
			116,
			69,
			114,
			114,
			111,
			114,
			0,
			103,
			108,
			71,
			101,
			116,
			70,
			101,
			110,
			99,
			101,
			105,
			118,
			78,
			86,
			0,
			103,
			108,
			71,
			101,
			116,
			70,
			105,
			114,
			115,
			116,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			73,
			100,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			71,
			101,
			116,
			70,
			108,
			111,
			97,
			116,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			65,
			116,
			116,
			97,
			99,
			104,
			109,
			101,
			110,
			116,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			71,
			114,
			97,
			112,
			104,
			105,
			99,
			115,
			82,
			101,
			115,
			101,
			116,
			83,
			116,
			97,
			116,
			117,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			73,
			110,
			116,
			101,
			103,
			101,
			114,
			54,
			52,
			118,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			71,
			101,
			116,
			73,
			110,
			116,
			101,
			103,
			101,
			114,
			105,
			95,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			73,
			110,
			116,
			101,
			103,
			101,
			114,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			78,
			101,
			120,
			116,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			73,
			100,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			71,
			101,
			116,
			110,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			110,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			79,
			98,
			106,
			101,
			99,
			116,
			76,
			97,
			98,
			101,
			108,
			0,
			103,
			108,
			71,
			101,
			116,
			79,
			98,
			106,
			101,
			99,
			116,
			76,
			97,
			98,
			101,
			108,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			79,
			98,
			106,
			101,
			99,
			116,
			76,
			97,
			98,
			101,
			108,
			75,
			72,
			82,
			0,
			103,
			108,
			71,
			101,
			116,
			79,
			98,
			106,
			101,
			99,
			116,
			80,
			116,
			114,
			76,
			97,
			98,
			101,
			108,
			0,
			103,
			108,
			71,
			101,
			116,
			79,
			98,
			106,
			101,
			99,
			116,
			80,
			116,
			114,
			76,
			97,
			98,
			101,
			108,
			75,
			72,
			82,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			67,
			111,
			117,
			110,
			116,
			101,
			114,
			73,
			110,
			102,
			111,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			67,
			111,
			117,
			110,
			116,
			101,
			114,
			68,
			97,
			116,
			97,
			65,
			77,
			68,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			67,
			111,
			117,
			110,
			116,
			101,
			114,
			73,
			110,
			102,
			111,
			65,
			77,
			68,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			67,
			111,
			117,
			110,
			116,
			101,
			114,
			115,
			65,
			77,
			68,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			67,
			111,
			117,
			110,
			116,
			101,
			114,
			83,
			116,
			114,
			105,
			110,
			103,
			65,
			77,
			68,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			71,
			114,
			111,
			117,
			112,
			115,
			65,
			77,
			68,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			71,
			114,
			111,
			117,
			112,
			83,
			116,
			114,
			105,
			110,
			103,
			65,
			77,
			68,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			68,
			97,
			116,
			97,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			73,
			100,
			66,
			121,
			78,
			97,
			109,
			101,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			101,
			114,
			102,
			81,
			117,
			101,
			114,
			121,
			73,
			110,
			102,
			111,
			73,
			78,
			84,
			69,
			76,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			111,
			105,
			110,
			116,
			101,
			114,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			111,
			105,
			110,
			116,
			101,
			114,
			118,
			75,
			72,
			82,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			66,
			105,
			110,
			97,
			114,
			121,
			79,
			69,
			83,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			73,
			110,
			102,
			111,
			76,
			111,
			103,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			105,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			80,
			105,
			112,
			101,
			108,
			105,
			110,
			101,
			73,
			110,
			102,
			111,
			76,
			111,
			103,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			80,
			105,
			112,
			101,
			108,
			105,
			110,
			101,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			81,
			117,
			101,
			114,
			121,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			81,
			117,
			101,
			114,
			121,
			79,
			98,
			106,
			101,
			99,
			116,
			105,
			54,
			52,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			81,
			117,
			101,
			114,
			121,
			79,
			98,
			106,
			101,
			99,
			116,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			81,
			117,
			101,
			114,
			121,
			79,
			98,
			106,
			101,
			99,
			116,
			117,
			105,
			54,
			52,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			81,
			117,
			101,
			114,
			121,
			79,
			98,
			106,
			101,
			99,
			116,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			83,
			97,
			109,
			112,
			108,
			101,
			114,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			73,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			83,
			97,
			109,
			112,
			108,
			101,
			114,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			73,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			83,
			104,
			97,
			100,
			101,
			114,
			73,
			110,
			102,
			111,
			76,
			111,
			103,
			0,
			103,
			108,
			71,
			101,
			116,
			83,
			104,
			97,
			100,
			101,
			114,
			105,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			83,
			104,
			97,
			100,
			101,
			114,
			80,
			114,
			101,
			99,
			105,
			115,
			105,
			111,
			110,
			70,
			111,
			114,
			109,
			97,
			116,
			0,
			103,
			108,
			71,
			101,
			116,
			83,
			104,
			97,
			100,
			101,
			114,
			83,
			111,
			117,
			114,
			99,
			101,
			0,
			103,
			108,
			71,
			101,
			116,
			83,
			116,
			114,
			105,
			110,
			103,
			0,
			103,
			108,
			71,
			101,
			116,
			83,
			121,
			110,
			99,
			105,
			118,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			71,
			101,
			116,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			102,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			73,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			73,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			71,
			101,
			116,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			84,
			114,
			97,
			110,
			115,
			108,
			97,
			116,
			101,
			100,
			83,
			104,
			97,
			100,
			101,
			114,
			83,
			111,
			117,
			114,
			99,
			101,
			65,
			78,
			71,
			76,
			69,
			0,
			103,
			108,
			71,
			101,
			116,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			102,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			105,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			76,
			111,
			99,
			97,
			116,
			105,
			111,
			110,
			0,
			103,
			108,
			71,
			101,
			116,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			102,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			105,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			80,
			111,
			105,
			110,
			116,
			101,
			114,
			118,
			0,
			103,
			108,
			72,
			105,
			110,
			116,
			0,
			103,
			108,
			73,
			110,
			115,
			101,
			114,
			116,
			69,
			118,
			101,
			110,
			116,
			77,
			97,
			114,
			107,
			101,
			114,
			69,
			88,
			84,
			0,
			103,
			108,
			73,
			115,
			66,
			117,
			102,
			102,
			101,
			114,
			0,
			103,
			108,
			73,
			115,
			69,
			110,
			97,
			98,
			108,
			101,
			100,
			0,
			103,
			108,
			73,
			115,
			69,
			110,
			97,
			98,
			108,
			101,
			100,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			73,
			115,
			70,
			101,
			110,
			99,
			101,
			78,
			86,
			0,
			103,
			108,
			73,
			115,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			0,
			103,
			108,
			73,
			115,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			0,
			103,
			108,
			73,
			115,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			80,
			105,
			112,
			101,
			108,
			105,
			110,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			73,
			115,
			81,
			117,
			101,
			114,
			121,
			69,
			88,
			84,
			0,
			103,
			108,
			73,
			115,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			0,
			103,
			108,
			73,
			115,
			83,
			104,
			97,
			100,
			101,
			114,
			0,
			103,
			108,
			73,
			115,
			83,
			121,
			110,
			99,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			73,
			115,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			0,
			103,
			108,
			73,
			115,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			114,
			114,
			97,
			121,
			79,
			69,
			83,
			0,
			103,
			108,
			76,
			97,
			98,
			101,
			108,
			79,
			98,
			106,
			101,
			99,
			116,
			69,
			88,
			84,
			0,
			103,
			108,
			76,
			105,
			110,
			101,
			87,
			105,
			100,
			116,
			104,
			0,
			103,
			108,
			76,
			105,
			110,
			107,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			0,
			103,
			108,
			77,
			97,
			112,
			66,
			117,
			102,
			102,
			101,
			114,
			79,
			69,
			83,
			0,
			103,
			108,
			77,
			97,
			112,
			66,
			117,
			102,
			102,
			101,
			114,
			82,
			97,
			110,
			103,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			77,
			105,
			110,
			83,
			97,
			109,
			112,
			108,
			101,
			83,
			104,
			97,
			100,
			105,
			110,
			103,
			79,
			69,
			83,
			0,
			103,
			108,
			77,
			117,
			108,
			116,
			105,
			68,
			114,
			97,
			119,
			65,
			114,
			114,
			97,
			121,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			77,
			117,
			108,
			116,
			105,
			68,
			114,
			97,
			119,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			79,
			98,
			106,
			101,
			99,
			116,
			76,
			97,
			98,
			101,
			108,
			0,
			103,
			108,
			79,
			98,
			106,
			101,
			99,
			116,
			76,
			97,
			98,
			101,
			108,
			75,
			72,
			82,
			0,
			103,
			108,
			79,
			98,
			106,
			101,
			99,
			116,
			80,
			116,
			114,
			76,
			97,
			98,
			101,
			108,
			0,
			103,
			108,
			79,
			98,
			106,
			101,
			99,
			116,
			80,
			116,
			114,
			76,
			97,
			98,
			101,
			108,
			75,
			72,
			82,
			0,
			103,
			108,
			80,
			97,
			116,
			99,
			104,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			105,
			120,
			101,
			108,
			83,
			116,
			111,
			114,
			101,
			105,
			0,
			103,
			108,
			80,
			111,
			108,
			121,
			103,
			111,
			110,
			79,
			102,
			102,
			115,
			101,
			116,
			0,
			103,
			108,
			80,
			111,
			112,
			68,
			101,
			98,
			117,
			103,
			71,
			114,
			111,
			117,
			112,
			0,
			103,
			108,
			80,
			111,
			112,
			68,
			101,
			98,
			117,
			103,
			71,
			114,
			111,
			117,
			112,
			75,
			72,
			82,
			0,
			103,
			108,
			80,
			111,
			112,
			71,
			114,
			111,
			117,
			112,
			77,
			97,
			114,
			107,
			101,
			114,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			105,
			109,
			105,
			116,
			105,
			118,
			101,
			66,
			111,
			117,
			110,
			100,
			105,
			110,
			103,
			66,
			111,
			120,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			66,
			105,
			110,
			97,
			114,
			121,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			102,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			117,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			102,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			117,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			102,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			117,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			102,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			117,
			105,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			50,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			50,
			120,
			51,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			50,
			120,
			52,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			51,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			51,
			120,
			50,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			51,
			120,
			52,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			52,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			52,
			120,
			50,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			52,
			120,
			51,
			102,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			80,
			117,
			115,
			104,
			68,
			101,
			98,
			117,
			103,
			71,
			114,
			111,
			117,
			112,
			0,
			103,
			108,
			80,
			117,
			115,
			104,
			68,
			101,
			98,
			117,
			103,
			71,
			114,
			111,
			117,
			112,
			75,
			72,
			82,
			0,
			103,
			108,
			80,
			117,
			115,
			104,
			71,
			114,
			111,
			117,
			112,
			77,
			97,
			114,
			107,
			101,
			114,
			69,
			88,
			84,
			0,
			103,
			108,
			81,
			117,
			101,
			114,
			121,
			67,
			111,
			117,
			110,
			116,
			101,
			114,
			69,
			88,
			84,
			0,
			103,
			108,
			82,
			101,
			97,
			100,
			66,
			117,
			102,
			102,
			101,
			114,
			73,
			110,
			100,
			101,
			120,
			101,
			100,
			69,
			88,
			84,
			0,
			103,
			108,
			82,
			101,
			97,
			100,
			66,
			117,
			102,
			102,
			101,
			114,
			78,
			86,
			0,
			103,
			108,
			82,
			101,
			97,
			100,
			110,
			80,
			105,
			120,
			101,
			108,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			82,
			101,
			97,
			100,
			80,
			105,
			120,
			101,
			108,
			115,
			0,
			103,
			108,
			82,
			101,
			108,
			101,
			97,
			115,
			101,
			83,
			104,
			97,
			100,
			101,
			114,
			67,
			111,
			109,
			112,
			105,
			108,
			101,
			114,
			0,
			103,
			108,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			0,
			103,
			108,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			65,
			78,
			71,
			76,
			69,
			0,
			103,
			108,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			73,
			77,
			71,
			0,
			103,
			108,
			82,
			101,
			110,
			100,
			101,
			114,
			98,
			117,
			102,
			102,
			101,
			114,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			78,
			86,
			0,
			103,
			108,
			82,
			101,
			115,
			111,
			108,
			118,
			101,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			70,
			114,
			97,
			109,
			101,
			98,
			117,
			102,
			102,
			101,
			114,
			65,
			80,
			80,
			76,
			69,
			0,
			103,
			108,
			83,
			97,
			109,
			112,
			108,
			101,
			67,
			111,
			118,
			101,
			114,
			97,
			103,
			101,
			0,
			103,
			108,
			83,
			97,
			109,
			112,
			108,
			101,
			114,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			73,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			83,
			97,
			109,
			112,
			108,
			101,
			114,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			73,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			83,
			99,
			105,
			115,
			115,
			111,
			114,
			0,
			103,
			108,
			83,
			101,
			108,
			101,
			99,
			116,
			80,
			101,
			114,
			102,
			77,
			111,
			110,
			105,
			116,
			111,
			114,
			67,
			111,
			117,
			110,
			116,
			101,
			114,
			115,
			65,
			77,
			68,
			0,
			103,
			108,
			83,
			101,
			116,
			70,
			101,
			110,
			99,
			101,
			78,
			86,
			0,
			103,
			108,
			83,
			104,
			97,
			100,
			101,
			114,
			66,
			105,
			110,
			97,
			114,
			121,
			0,
			103,
			108,
			83,
			104,
			97,
			100,
			101,
			114,
			83,
			111,
			117,
			114,
			99,
			101,
			0,
			103,
			108,
			83,
			116,
			97,
			114,
			116,
			84,
			105,
			108,
			105,
			110,
			103,
			81,
			67,
			79,
			77,
			0,
			103,
			108,
			83,
			116,
			101,
			110,
			99,
			105,
			108,
			70,
			117,
			110,
			99,
			0,
			103,
			108,
			83,
			116,
			101,
			110,
			99,
			105,
			108,
			70,
			117,
			110,
			99,
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			101,
			0,
			103,
			108,
			83,
			116,
			101,
			110,
			99,
			105,
			108,
			77,
			97,
			115,
			107,
			0,
			103,
			108,
			83,
			116,
			101,
			110,
			99,
			105,
			108,
			77,
			97,
			115,
			107,
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			101,
			0,
			103,
			108,
			83,
			116,
			101,
			110,
			99,
			105,
			108,
			79,
			112,
			0,
			103,
			108,
			83,
			116,
			101,
			110,
			99,
			105,
			108,
			79,
			112,
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			101,
			0,
			103,
			108,
			84,
			101,
			115,
			116,
			70,
			101,
			110,
			99,
			101,
			78,
			86,
			0,
			103,
			108,
			84,
			101,
			120,
			66,
			117,
			102,
			102,
			101,
			114,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			66,
			117,
			102,
			102,
			101,
			114,
			82,
			97,
			110,
			103,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			73,
			109,
			97,
			103,
			101,
			50,
			68,
			0,
			103,
			108,
			84,
			101,
			120,
			73,
			109,
			97,
			103,
			101,
			51,
			68,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			102,
			0,
			103,
			108,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			102,
			118,
			0,
			103,
			108,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			0,
			103,
			108,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			73,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			73,
			117,
			105,
			118,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			105,
			118,
			0,
			103,
			108,
			84,
			101,
			120,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			49,
			68,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			50,
			68,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			51,
			68,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			51,
			68,
			77,
			117,
			108,
			116,
			105,
			115,
			97,
			109,
			112,
			108,
			101,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			83,
			117,
			98,
			73,
			109,
			97,
			103,
			101,
			50,
			68,
			0,
			103,
			108,
			84,
			101,
			120,
			83,
			117,
			98,
			73,
			109,
			97,
			103,
			101,
			51,
			68,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			49,
			68,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			50,
			68,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			83,
			116,
			111,
			114,
			97,
			103,
			101,
			51,
			68,
			69,
			88,
			84,
			0,
			103,
			108,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			86,
			105,
			101,
			119,
			69,
			88,
			84,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			102,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			102,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			105,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			49,
			105,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			102,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			102,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			105,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			50,
			105,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			102,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			102,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			105,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			51,
			105,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			102,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			102,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			105,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			52,
			105,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			50,
			102,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			50,
			120,
			51,
			102,
			118,
			78,
			86,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			50,
			120,
			52,
			102,
			118,
			78,
			86,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			51,
			102,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			51,
			120,
			50,
			102,
			118,
			78,
			86,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			51,
			120,
			52,
			102,
			118,
			78,
			86,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			52,
			102,
			118,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			52,
			120,
			50,
			102,
			118,
			78,
			86,
			0,
			103,
			108,
			85,
			110,
			105,
			102,
			111,
			114,
			109,
			77,
			97,
			116,
			114,
			105,
			120,
			52,
			120,
			51,
			102,
			118,
			78,
			86,
			0,
			103,
			108,
			85,
			110,
			109,
			97,
			112,
			66,
			117,
			102,
			102,
			101,
			114,
			79,
			69,
			83,
			0,
			103,
			108,
			85,
			115,
			101,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			0,
			103,
			108,
			85,
			115,
			101,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			83,
			116,
			97,
			103,
			101,
			115,
			69,
			88,
			84,
			0,
			103,
			108,
			85,
			115,
			101,
			83,
			104,
			97,
			100,
			101,
			114,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			69,
			88,
			84,
			0,
			103,
			108,
			86,
			97,
			108,
			105,
			100,
			97,
			116,
			101,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			0,
			103,
			108,
			86,
			97,
			108,
			105,
			100,
			97,
			116,
			101,
			80,
			114,
			111,
			103,
			114,
			97,
			109,
			80,
			105,
			112,
			101,
			108,
			105,
			110,
			101,
			69,
			88,
			84,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			49,
			102,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			49,
			102,
			118,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			50,
			102,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			50,
			102,
			118,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			51,
			102,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			51,
			102,
			118,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			52,
			102,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			52,
			102,
			118,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			68,
			105,
			118,
			105,
			115,
			111,
			114,
			65,
			78,
			71,
			76,
			69,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			68,
			105,
			118,
			105,
			115,
			111,
			114,
			69,
			88,
			84,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			68,
			105,
			118,
			105,
			115,
			111,
			114,
			78,
			86,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			65,
			116,
			116,
			114,
			105,
			98,
			80,
			111,
			105,
			110,
			116,
			101,
			114,
			0,
			103,
			108,
			86,
			105,
			101,
			119,
			112,
			111,
			114,
			116,
			0,
			103,
			108,
			87,
			97,
			105,
			116,
			83,
			121,
			110,
			99,
			65,
			80,
			80,
			76,
			69,
			0
		};

		// Token: 0x04004CF2 RID: 19698
		private static int[] EntryPointNameOffsets = new int[]
		{
			0,
			19,
			44,
			60,
			76,
			91,
			113,
			135,
			151,
			172,
			185,
			203,
			228,
			247,
			261,
			282,
			300,
			317,
			330,
			346,
			365,
			385,
			409,
			437,
			449,
			465,
			485,
			509,
			529,
			552,
			572,
			585,
			601,
			626,
			634,
			647,
			661,
			676,
			698,
			710,
			726,
			742,
			765,
			791,
			817,
			846,
			868,
			890,
			907,
			927,
			950,
			975,
			992,
			1014,
			1037,
			1053,
			1068,
			1093,
			1119,
			1130,
			1153,
			1179,
			1201,
			1226,
			1247,
			1271,
			1287,
			1304,
			1325,
			1349,
			1372,
			1388,
			1416,
			1435,
			1457,
			1472,
			1490,
			1507,
			1531,
			1543,
			1555,
			1569,
			1584,
			1594,
			1621,
			1635,
			1662,
			1686,
			1699,
			1726,
			1751,
			1775,
			1792,
			1816,
			1832,
			1847,
			1876,
			1903,
			1929,
			1968,
			1997,
			2006,
			2032,
			2045,
			2071,
			2091,
			2111,
			2125,
			2141,
			2168,
			2188,
			2213,
			2245,
			2266,
			2292,
			2312,
			2344,
			2368,
			2389,
			2414,
			2447,
			2464,
			2473,
			2489,
			2497,
			2525,
			2551,
			2574,
			2611,
			2648,
			2674,
			2698,
			2710,
			2723,
			2740,
			2754,
			2772,
			2793,
			2818,
			2834,
			2853,
			2867,
			2888,
			2906,
			2925,
			2946,
			2966,
			2980,
			3003,
			3026,
			3047,
			3071,
			3095,
			3124,
			3135,
			3150,
			3177,
			3189,
			3227,
			3255,
			3276,
			3295,
			3309,
			3335,
			3354,
			3373,
			3390,
			3410,
			3430,
			3450,
			3473,
			3499,
			3530,
			3561,
			3589,
			3622,
			3648,
			3679,
			3703,
			3731,
			3755,
			3769,
			3786,
			3808,
			3828,
			3843,
			3874,
			3900,
			3916,
			3940,
			3962,
			3987,
			4010,
			4039,
			4067,
			4096,
			4115,
			4129,
			4156,
			4174,
			4186,
			4203,
			4223,
			4247,
			4272,
			4292,
			4325,
			4340,
			4355,
			4376,
			4396,
			4416,
			4442,
			4449,
			4472,
			4483,
			4495,
			4511,
			4523,
			4539,
			4551,
			4574,
			4587,
			4604,
			4615,
			4629,
			4641,
			4660,
			4677,
			4689,
			4703,
			4718,
			4738,
			4760,
			4781,
			4804,
			4818,
			4835,
			4852,
			4872,
			4893,
			4907,
			4923,
			4939,
			4958,
			4978,
			5004,
			5023,
			5046,
			5068,
			5091,
			5113,
			5136,
			5159,
			5183,
			5205,
			5228,
			5250,
			5273,
			5296,
			5320,
			5342,
			5365,
			5387,
			5410,
			5433,
			5457,
			5479,
			5502,
			5524,
			5547,
			5570,
			5594,
			5623,
			5654,
			5685,
			5714,
			5745,
			5776,
			5805,
			5836,
			5867,
			5884,
			5904,
			5925,
			5943,
			5966,
			5981,
			5998,
			6011,
			6035,
			6057,
			6095,
			6133,
			6169,
			6205,
			6240,
			6277,
			6294,
			6319,
			6345,
			6355,
			6386,
			6399,
			6414,
			6429,
			6447,
			6461,
			6483,
			6497,
			6519,
			6531,
			6551,
			6565,
			6580,
			6600,
			6613,
			6629,
			6645,
			6662,
			6678,
			6699,
			6721,
			6738,
			6756,
			6774,
			6792,
			6821,
			6837,
			6856,
			6878,
			6900,
			6922,
			6939,
			6951,
			6964,
			6976,
			6989,
			7001,
			7014,
			7026,
			7039,
			7051,
			7064,
			7076,
			7089,
			7101,
			7114,
			7126,
			7139,
			7158,
			7181,
			7204,
			7223,
			7246,
			7269,
			7288,
			7311,
			7334,
			7351,
			7364,
			7386,
			7408,
			7426,
			7455,
			7472,
			7490,
			7507,
			7525,
			7542,
			7560,
			7577,
			7595,
			7622,
			7647,
			7671,
			7693,
			7704
		};

		// Token: 0x02000505 RID: 1285
		public static class Amd
		{
			// Token: 0x06003916 RID: 14614 RVA: 0x00096190 File Offset: 0x00094390
			[CLSCompliant(false)]
			public static void BeginPerfMonitor(int monitor)
			{
				calli(System.Void(System.UInt32), monitor, GL.EntryPoints[5]);
			}

			// Token: 0x06003917 RID: 14615 RVA: 0x000961A0 File Offset: 0x000943A0
			[CLSCompliant(false)]
			public static void BeginPerfMonitor(uint monitor)
			{
				calli(System.Void(System.UInt32), monitor, GL.EntryPoints[5]);
			}

			// Token: 0x06003918 RID: 14616 RVA: 0x000961B0 File Offset: 0x000943B0
			[CLSCompliant(false)]
			public static void DeletePerfMonitor(int monitors)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref monitors, GL.EntryPoints[68]);
			}

			// Token: 0x06003919 RID: 14617 RVA: 0x000961C4 File Offset: 0x000943C4
			[CLSCompliant(false)]
			public static void DeletePerfMonitor(uint monitors)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref monitors, GL.EntryPoints[68]);
			}

			// Token: 0x0600391A RID: 14618 RVA: 0x000961D8 File Offset: 0x000943D8
			[CLSCompliant(false)]
			public unsafe static void DeletePerfMonitors(int n, int[] monitors)
			{
				fixed (int* ptr = ref (monitors != null && monitors.Length != 0) ? ref monitors[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[68]);
				}
			}

			// Token: 0x0600391B RID: 14619 RVA: 0x0009620C File Offset: 0x0009440C
			[CLSCompliant(false)]
			public unsafe static void DeletePerfMonitors(int n, ref int monitors)
			{
				fixed (int* ptr = &monitors)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[68]);
				}
			}

			// Token: 0x0600391C RID: 14620 RVA: 0x0009622C File Offset: 0x0009442C
			[CLSCompliant(false)]
			public unsafe static void DeletePerfMonitors(int n, int* monitors)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, monitors, GL.EntryPoints[68]);
			}

			// Token: 0x0600391D RID: 14621 RVA: 0x00096240 File Offset: 0x00094440
			[CLSCompliant(false)]
			public unsafe static void DeletePerfMonitors(int n, uint[] monitors)
			{
				fixed (uint* ptr = ref (monitors != null && monitors.Length != 0) ? ref monitors[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[68]);
				}
			}

			// Token: 0x0600391E RID: 14622 RVA: 0x00096274 File Offset: 0x00094474
			[CLSCompliant(false)]
			public unsafe static void DeletePerfMonitors(int n, ref uint monitors)
			{
				fixed (uint* ptr = &monitors)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[68]);
				}
			}

			// Token: 0x0600391F RID: 14623 RVA: 0x00096294 File Offset: 0x00094494
			[CLSCompliant(false)]
			public unsafe static void DeletePerfMonitors(int n, uint* monitors)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, monitors, GL.EntryPoints[68]);
			}

			// Token: 0x06003920 RID: 14624 RVA: 0x000962A8 File Offset: 0x000944A8
			[CLSCompliant(false)]
			public static void EndPerfMonitor(int monitor)
			{
				calli(System.Void(System.UInt32), monitor, GL.EntryPoints[104]);
			}

			// Token: 0x06003921 RID: 14625 RVA: 0x000962B8 File Offset: 0x000944B8
			[CLSCompliant(false)]
			public static void EndPerfMonitor(uint monitor)
			{
				calli(System.Void(System.UInt32), monitor, GL.EntryPoints[104]);
			}

			// Token: 0x06003922 RID: 14626 RVA: 0x000962C8 File Offset: 0x000944C8
			[CLSCompliant(false)]
			public static int GenPerfMonitor()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[136]);
				return result;
			}

			// Token: 0x06003923 RID: 14627 RVA: 0x000962EC File Offset: 0x000944EC
			[CLSCompliant(false)]
			public unsafe static void GenPerfMonitors(int n, [Out] int[] monitors)
			{
				fixed (int* ptr = ref (monitors != null && monitors.Length != 0) ? ref monitors[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[136]);
				}
			}

			// Token: 0x06003924 RID: 14628 RVA: 0x00096320 File Offset: 0x00094520
			[CLSCompliant(false)]
			public unsafe static void GenPerfMonitors(int n, out int monitors)
			{
				fixed (int* ptr = &monitors)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[136]);
				}
			}

			// Token: 0x06003925 RID: 14629 RVA: 0x00096344 File Offset: 0x00094544
			[CLSCompliant(false)]
			public unsafe static void GenPerfMonitors(int n, [Out] int* monitors)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, monitors, GL.EntryPoints[136]);
			}

			// Token: 0x06003926 RID: 14630 RVA: 0x00096358 File Offset: 0x00094558
			[CLSCompliant(false)]
			public unsafe static void GenPerfMonitors(int n, [Out] uint[] monitors)
			{
				fixed (uint* ptr = ref (monitors != null && monitors.Length != 0) ? ref monitors[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[136]);
				}
			}

			// Token: 0x06003927 RID: 14631 RVA: 0x0009638C File Offset: 0x0009458C
			[CLSCompliant(false)]
			public unsafe static void GenPerfMonitors(int n, out uint monitors)
			{
				fixed (uint* ptr = &monitors)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[136]);
				}
			}

			// Token: 0x06003928 RID: 14632 RVA: 0x000963B0 File Offset: 0x000945B0
			[CLSCompliant(false)]
			public unsafe static void GenPerfMonitors(int n, [Out] uint* monitors)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, monitors, GL.EntryPoints[136]);
			}

			// Token: 0x06003929 RID: 14633 RVA: 0x000963C4 File Offset: 0x000945C4
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterData(int monitor, All pname, int dataSize, [Out] int[] data, out int bytesWritten)
			{
				fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*,System.Int32*), monitor, pname, dataSize, ptr2, ptr3, GL.EntryPoints[171]);
					}
				}
			}

			// Token: 0x0600392A RID: 14634 RVA: 0x00096400 File Offset: 0x00094600
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterData(int monitor, All pname, int dataSize, out int data, out int bytesWritten)
			{
				fixed (int* ptr = &data)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*,System.Int32*), monitor, pname, dataSize, ptr2, ptr3, GL.EntryPoints[171]);
					}
				}
			}

			// Token: 0x0600392B RID: 14635 RVA: 0x0009642C File Offset: 0x0009462C
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterData(int monitor, All pname, int dataSize, [Out] int* data, [Out] int* bytesWritten)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*,System.Int32*), monitor, pname, dataSize, data, bytesWritten, GL.EntryPoints[171]);
			}

			// Token: 0x0600392C RID: 14636 RVA: 0x00096444 File Offset: 0x00094644
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterData(uint monitor, All pname, int dataSize, [Out] uint[] data, out int bytesWritten)
			{
				fixed (uint* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*,System.Int32*), monitor, pname, dataSize, ptr2, ptr3, GL.EntryPoints[171]);
					}
				}
			}

			// Token: 0x0600392D RID: 14637 RVA: 0x00096480 File Offset: 0x00094680
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterData(uint monitor, All pname, int dataSize, out uint data, out int bytesWritten)
			{
				fixed (uint* ptr = &data)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*,System.Int32*), monitor, pname, dataSize, ptr2, ptr3, GL.EntryPoints[171]);
					}
				}
			}

			// Token: 0x0600392E RID: 14638 RVA: 0x000964AC File Offset: 0x000946AC
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterData(uint monitor, All pname, int dataSize, [Out] uint* data, [Out] int* bytesWritten)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*,System.Int32*), monitor, pname, dataSize, data, bytesWritten, GL.EntryPoints[171]);
			}

			// Token: 0x0600392F RID: 14639 RVA: 0x000964C4 File Offset: 0x000946C4
			[CLSCompliant(false)]
			public static void GetPerfMonitorCounterInfo(int group, int counter, All pname, [Out] IntPtr data)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, data, GL.EntryPoints[172]);
			}

			// Token: 0x06003930 RID: 14640 RVA: 0x000964DC File Offset: 0x000946DC
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterInfo<T3>(int group, int counter, All pname, [In] [Out] T3[] data) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x06003931 RID: 14641 RVA: 0x00096514 File Offset: 0x00094714
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterInfo<T3>(int group, int counter, All pname, [In] [Out] T3[,] data) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x06003932 RID: 14642 RVA: 0x00096550 File Offset: 0x00094750
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterInfo<T3>(int group, int counter, All pname, [In] [Out] T3[,,] data) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x06003933 RID: 14643 RVA: 0x0009658C File Offset: 0x0009478C
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterInfo<T3>(int group, int counter, All pname, [In] [Out] ref T3 data) where T3 : struct
			{
				fixed (T3* ptr = &data)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x06003934 RID: 14644 RVA: 0x000965B0 File Offset: 0x000947B0
			[CLSCompliant(false)]
			public static void GetPerfMonitorCounterInfo(uint group, uint counter, All pname, [Out] IntPtr data)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, data, GL.EntryPoints[172]);
			}

			// Token: 0x06003935 RID: 14645 RVA: 0x000965C8 File Offset: 0x000947C8
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterInfo<T3>(uint group, uint counter, All pname, [In] [Out] T3[] data) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x06003936 RID: 14646 RVA: 0x00096600 File Offset: 0x00094800
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterInfo<T3>(uint group, uint counter, All pname, [In] [Out] T3[,] data) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x06003937 RID: 14647 RVA: 0x0009663C File Offset: 0x0009483C
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterInfo<T3>(uint group, uint counter, All pname, [In] [Out] T3[,,] data) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x06003938 RID: 14648 RVA: 0x00096678 File Offset: 0x00094878
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterInfo<T3>(uint group, uint counter, All pname, [In] [Out] ref T3 data) where T3 : struct
			{
				fixed (T3* ptr = &data)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr), group, counter, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x06003939 RID: 14649 RVA: 0x0009669C File Offset: 0x0009489C
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounters(int group, out int numCounters, out int maxActiveCounters, int counterSize, [Out] int[] counters)
			{
				fixed (int* ptr = &numCounters)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &maxActiveCounters)
					{
						int* ptr4 = ptr3;
						fixed (int* ptr5 = ref (counters != null && counters.Length != 0) ? ref counters[0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32*,System.Int32*,System.Int32,System.UInt32*), group, ptr2, ptr4, counterSize, ptr5, GL.EntryPoints[173]);
						}
					}
				}
			}

			// Token: 0x0600393A RID: 14650 RVA: 0x000966DC File Offset: 0x000948DC
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounters(int group, out int numCounters, out int maxActiveCounters, int counterSize, out int counters)
			{
				fixed (int* ptr = &numCounters)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &maxActiveCounters)
					{
						int* ptr4 = ptr3;
						fixed (int* ptr5 = &counters)
						{
							calli(System.Void(System.UInt32,System.Int32*,System.Int32*,System.Int32,System.UInt32*), group, ptr2, ptr4, counterSize, ptr5, GL.EntryPoints[173]);
						}
					}
				}
			}

			// Token: 0x0600393B RID: 14651 RVA: 0x00096708 File Offset: 0x00094908
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounters(int group, [Out] int* numCounters, [Out] int* maxActiveCounters, int counterSize, [Out] int* counters)
			{
				calli(System.Void(System.UInt32,System.Int32*,System.Int32*,System.Int32,System.UInt32*), group, numCounters, maxActiveCounters, counterSize, counters, GL.EntryPoints[173]);
			}

			// Token: 0x0600393C RID: 14652 RVA: 0x00096720 File Offset: 0x00094920
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounters(uint group, out int numCounters, out int maxActiveCounters, int counterSize, [Out] uint[] counters)
			{
				fixed (int* ptr = &numCounters)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &maxActiveCounters)
					{
						int* ptr4 = ptr3;
						fixed (uint* ptr5 = ref (counters != null && counters.Length != 0) ? ref counters[0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32*,System.Int32*,System.Int32,System.UInt32*), group, ptr2, ptr4, counterSize, ptr5, GL.EntryPoints[173]);
						}
					}
				}
			}

			// Token: 0x0600393D RID: 14653 RVA: 0x00096760 File Offset: 0x00094960
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounters(uint group, out int numCounters, out int maxActiveCounters, int counterSize, out uint counters)
			{
				fixed (int* ptr = &numCounters)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &maxActiveCounters)
					{
						int* ptr4 = ptr3;
						fixed (uint* ptr5 = &counters)
						{
							calli(System.Void(System.UInt32,System.Int32*,System.Int32*,System.Int32,System.UInt32*), group, ptr2, ptr4, counterSize, ptr5, GL.EntryPoints[173]);
						}
					}
				}
			}

			// Token: 0x0600393E RID: 14654 RVA: 0x0009678C File Offset: 0x0009498C
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounters(uint group, [Out] int* numCounters, [Out] int* maxActiveCounters, int counterSize, [Out] uint* counters)
			{
				calli(System.Void(System.UInt32,System.Int32*,System.Int32*,System.Int32,System.UInt32*), group, numCounters, maxActiveCounters, counterSize, counters, GL.EntryPoints[173]);
			}

			// Token: 0x0600393F RID: 14655 RVA: 0x000967A4 File Offset: 0x000949A4
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterString(int group, int counter, int bufSize, out int length, [Out] StringBuilder counterString)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterString.Capacity);
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), group, counter, bufSize, ptr2, intPtr, GL.EntryPoints[174]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, counterString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003940 RID: 14656 RVA: 0x000967E4 File Offset: 0x000949E4
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterString(int group, int counter, int bufSize, [Out] int* length, [Out] StringBuilder counterString)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterString.Capacity);
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), group, counter, bufSize, length, intPtr, GL.EntryPoints[174]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, counterString);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003941 RID: 14657 RVA: 0x00096824 File Offset: 0x00094A24
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterString(uint group, uint counter, int bufSize, out int length, [Out] StringBuilder counterString)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterString.Capacity);
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), group, counter, bufSize, ptr2, intPtr, GL.EntryPoints[174]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, counterString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003942 RID: 14658 RVA: 0x00096864 File Offset: 0x00094A64
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorCounterString(uint group, uint counter, int bufSize, [Out] int* length, [Out] StringBuilder counterString)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterString.Capacity);
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), group, counter, bufSize, length, intPtr, GL.EntryPoints[174]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, counterString);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003943 RID: 14659 RVA: 0x000968A4 File Offset: 0x00094AA4
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroups(out int numGroups, int groupsSize, [Out] int[] groups)
			{
				fixed (int* ptr = &numGroups)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (groups != null && groups.Length != 0) ? ref groups[0] : ref *null)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, groupsSize, ptr3, GL.EntryPoints[175]);
					}
				}
			}

			// Token: 0x06003944 RID: 14660 RVA: 0x000968DC File Offset: 0x00094ADC
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroups(out int numGroups, int groupsSize, out int groups)
			{
				fixed (int* ptr = &numGroups)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &groups)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, groupsSize, ptr3, GL.EntryPoints[175]);
					}
				}
			}

			// Token: 0x06003945 RID: 14661 RVA: 0x00096904 File Offset: 0x00094B04
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroups(out int numGroups, int groupsSize, [Out] uint[] groups)
			{
				fixed (int* ptr = &numGroups)
				{
					int* ptr2 = ptr;
					fixed (uint* ptr3 = ref (groups != null && groups.Length != 0) ? ref groups[0] : ref *null)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, groupsSize, ptr3, GL.EntryPoints[175]);
					}
				}
			}

			// Token: 0x06003946 RID: 14662 RVA: 0x0009693C File Offset: 0x00094B3C
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroups(out int numGroups, int groupsSize, out uint groups)
			{
				fixed (int* ptr = &numGroups)
				{
					int* ptr2 = ptr;
					fixed (uint* ptr3 = &groups)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, groupsSize, ptr3, GL.EntryPoints[175]);
					}
				}
			}

			// Token: 0x06003947 RID: 14663 RVA: 0x00096964 File Offset: 0x00094B64
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroups([Out] int* numGroups, int groupsSize, [Out] int* groups)
			{
				calli(System.Void(System.Int32*,System.Int32,System.UInt32*), numGroups, groupsSize, groups, GL.EntryPoints[175]);
			}

			// Token: 0x06003948 RID: 14664 RVA: 0x0009697C File Offset: 0x00094B7C
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroups([Out] int* numGroups, int groupsSize, [Out] uint* groups)
			{
				calli(System.Void(System.Int32*,System.Int32,System.UInt32*), numGroups, groupsSize, groups, GL.EntryPoints[175]);
			}

			// Token: 0x06003949 RID: 14665 RVA: 0x00096994 File Offset: 0x00094B94
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroupString(int group, int bufSize, out int length, [Out] StringBuilder groupString)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)groupString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), group, bufSize, ptr2, intPtr, GL.EntryPoints[176]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, groupString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x0600394A RID: 14666 RVA: 0x000969D4 File Offset: 0x00094BD4
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroupString(int group, int bufSize, [Out] int* length, [Out] StringBuilder groupString)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)groupString.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), group, bufSize, length, intPtr, GL.EntryPoints[176]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, groupString);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x0600394B RID: 14667 RVA: 0x00096A10 File Offset: 0x00094C10
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroupString(uint group, int bufSize, out int length, [Out] StringBuilder groupString)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)groupString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), group, bufSize, ptr2, intPtr, GL.EntryPoints[176]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, groupString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x0600394C RID: 14668 RVA: 0x00096A50 File Offset: 0x00094C50
			[CLSCompliant(false)]
			public unsafe static void GetPerfMonitorGroupString(uint group, int bufSize, [Out] int* length, [Out] StringBuilder groupString)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)groupString.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), group, bufSize, length, intPtr, GL.EntryPoints[176]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, groupString);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x0600394D RID: 14669 RVA: 0x00096A8C File Offset: 0x00094C8C
			[CLSCompliant(false)]
			public unsafe static void SelectPerfMonitorCounters(int monitor, bool enable, int group, int numCounters, [Out] int[] counterList)
			{
				fixed (int* ptr = ref (counterList != null && counterList.Length != 0) ? ref counterList[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Boolean,System.UInt32,System.Int32,System.UInt32*), monitor, enable, group, numCounters, ptr, GL.EntryPoints[301]);
				}
			}

			// Token: 0x0600394E RID: 14670 RVA: 0x00096AC8 File Offset: 0x00094CC8
			[CLSCompliant(false)]
			public unsafe static void SelectPerfMonitorCounters(int monitor, bool enable, int group, int numCounters, out int counterList)
			{
				fixed (int* ptr = &counterList)
				{
					calli(System.Void(System.UInt32,System.Boolean,System.UInt32,System.Int32,System.UInt32*), monitor, enable, group, numCounters, ptr, GL.EntryPoints[301]);
				}
			}

			// Token: 0x0600394F RID: 14671 RVA: 0x00096AF0 File Offset: 0x00094CF0
			[CLSCompliant(false)]
			public unsafe static void SelectPerfMonitorCounters(int monitor, bool enable, int group, int numCounters, [Out] int* counterList)
			{
				calli(System.Void(System.UInt32,System.Boolean,System.UInt32,System.Int32,System.UInt32*), monitor, enable, group, numCounters, counterList, GL.EntryPoints[301]);
			}

			// Token: 0x06003950 RID: 14672 RVA: 0x00096B08 File Offset: 0x00094D08
			[CLSCompliant(false)]
			public unsafe static void SelectPerfMonitorCounters(uint monitor, bool enable, uint group, int numCounters, [Out] uint[] counterList)
			{
				fixed (uint* ptr = ref (counterList != null && counterList.Length != 0) ? ref counterList[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Boolean,System.UInt32,System.Int32,System.UInt32*), monitor, enable, group, numCounters, ptr, GL.EntryPoints[301]);
				}
			}

			// Token: 0x06003951 RID: 14673 RVA: 0x00096B44 File Offset: 0x00094D44
			[CLSCompliant(false)]
			public unsafe static void SelectPerfMonitorCounters(uint monitor, bool enable, uint group, int numCounters, out uint counterList)
			{
				fixed (uint* ptr = &counterList)
				{
					calli(System.Void(System.UInt32,System.Boolean,System.UInt32,System.Int32,System.UInt32*), monitor, enable, group, numCounters, ptr, GL.EntryPoints[301]);
				}
			}

			// Token: 0x06003952 RID: 14674 RVA: 0x00096B6C File Offset: 0x00094D6C
			[CLSCompliant(false)]
			public unsafe static void SelectPerfMonitorCounters(uint monitor, bool enable, uint group, int numCounters, [Out] uint* counterList)
			{
				calli(System.Void(System.UInt32,System.Boolean,System.UInt32,System.Int32,System.UInt32*), monitor, enable, group, numCounters, counterList, GL.EntryPoints[301]);
			}
		}

		// Token: 0x02000506 RID: 1286
		public static class Angle
		{
			// Token: 0x06003953 RID: 14675 RVA: 0x00096B84 File Offset: 0x00094D84
			[Obsolete("Use strongly-typed overload instead")]
			public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, All mask, All filter)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter, GL.EntryPoints[28]);
			}

			// Token: 0x06003954 RID: 14676 RVA: 0x00096BB0 File Offset: 0x00094DB0
			public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter, GL.EntryPoints[28]);
			}

			// Token: 0x06003955 RID: 14677 RVA: 0x00096BDC File Offset: 0x00094DDC
			[Obsolete("Use strongly-typed overload instead")]
			public static void DrawArraysInstanced(All mode, int first, int count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), mode, first, count, primcount, GL.EntryPoints[88]);
			}

			// Token: 0x06003956 RID: 14678 RVA: 0x00096BF0 File Offset: 0x00094DF0
			public static void DrawArraysInstanced(PrimitiveType mode, int first, int count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), mode, first, count, primcount, GL.EntryPoints[88]);
			}

			// Token: 0x06003957 RID: 14679 RVA: 0x00096C04 File Offset: 0x00094E04
			[Obsolete("Use strongly-typed overload instead")]
			public static void DrawElementsInstanced(All mode, int count, All type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[95]);
			}

			// Token: 0x06003958 RID: 14680 RVA: 0x00096C1C File Offset: 0x00094E1C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[95]);
				}
			}

			// Token: 0x06003959 RID: 14681 RVA: 0x00096C54 File Offset: 0x00094E54
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[95]);
				}
			}

			// Token: 0x0600395A RID: 14682 RVA: 0x00096C90 File Offset: 0x00094E90
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[95]);
				}
			}

			// Token: 0x0600395B RID: 14683 RVA: 0x00096CCC File Offset: 0x00094ECC
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[95]);
				}
			}

			// Token: 0x0600395C RID: 14684 RVA: 0x00096CF0 File Offset: 0x00094EF0
			public static void DrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[95]);
			}

			// Token: 0x0600395D RID: 14685 RVA: 0x00096D08 File Offset: 0x00094F08
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[95]);
				}
			}

			// Token: 0x0600395E RID: 14686 RVA: 0x00096D40 File Offset: 0x00094F40
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[95]);
				}
			}

			// Token: 0x0600395F RID: 14687 RVA: 0x00096D7C File Offset: 0x00094F7C
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[95]);
				}
			}

			// Token: 0x06003960 RID: 14688 RVA: 0x00096DB8 File Offset: 0x00094FB8
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[95]);
				}
			}

			// Token: 0x06003961 RID: 14689 RVA: 0x00096DDC File Offset: 0x00094FDC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetTranslatedShaderSource(int shader, int bufsize, [Out] int[] length, [Out] StringBuilder source)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufsize, ptr2, intPtr, GL.EntryPoints[205]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003962 RID: 14690 RVA: 0x00096E2C File Offset: 0x0009502C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetTranslatedShaderSource(int shader, int bufsize, out int length, [Out] StringBuilder source)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufsize, ptr2, intPtr, GL.EntryPoints[205]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003963 RID: 14691 RVA: 0x00096E6C File Offset: 0x0009506C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetTranslatedShaderSource(int shader, int bufsize, [Out] int* length, [Out] StringBuilder source)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufsize, length, intPtr, GL.EntryPoints[205]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003964 RID: 14692 RVA: 0x00096EA8 File Offset: 0x000950A8
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetTranslatedShaderSource(uint shader, int bufsize, [Out] int[] length, [Out] StringBuilder source)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufsize, ptr2, intPtr, GL.EntryPoints[205]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003965 RID: 14693 RVA: 0x00096EF8 File Offset: 0x000950F8
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetTranslatedShaderSource(uint shader, int bufsize, out int length, [Out] StringBuilder source)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufsize, ptr2, intPtr, GL.EntryPoints[205]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003966 RID: 14694 RVA: 0x00096F38 File Offset: 0x00095138
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetTranslatedShaderSource(uint shader, int bufsize, [Out] int* length, [Out] StringBuilder source)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), shader, bufsize, length, intPtr, GL.EntryPoints[205]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003967 RID: 14695 RVA: 0x00096F74 File Offset: 0x00095174
			[Obsolete("Use strongly-typed overload instead")]
			public static void RenderbufferStorageMultisample(All target, int samples, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[291]);
			}

			// Token: 0x06003968 RID: 14696 RVA: 0x00096F8C File Offset: 0x0009518C
			public static void RenderbufferStorageMultisample(RenderbufferTarget target, int samples, RenderbufferInternalFormat internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[291]);
			}

			// Token: 0x06003969 RID: 14697 RVA: 0x00096FA4 File Offset: 0x000951A4
			[CLSCompliant(false)]
			public static void VertexAttribDivisor(int index, int divisor)
			{
				calli(System.Void(System.UInt32,System.UInt32), index, divisor, GL.EntryPoints[372]);
			}

			// Token: 0x0600396A RID: 14698 RVA: 0x00096FB8 File Offset: 0x000951B8
			[CLSCompliant(false)]
			public static void VertexAttribDivisor(uint index, uint divisor)
			{
				calli(System.Void(System.UInt32,System.UInt32), index, divisor, GL.EntryPoints[372]);
			}
		}

		// Token: 0x02000507 RID: 1287
		public static class Apple
		{
			// Token: 0x0600396B RID: 14699 RVA: 0x00096FCC File Offset: 0x000951CC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static WaitSyncStatus ClientWaitSync(IntPtr sync, All flags, long timeout)
			{
				return calli(System.Int32(System.IntPtr,System.Int32,System.UInt64), sync, flags, timeout, GL.EntryPoints[37]);
			}

			// Token: 0x0600396C RID: 14700 RVA: 0x00096FE0 File Offset: 0x000951E0
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static WaitSyncStatus ClientWaitSync(IntPtr sync, All flags, ulong timeout)
			{
				return calli(System.Int32(System.IntPtr,System.Int32,System.UInt64), sync, flags, timeout, GL.EntryPoints[37]);
			}

			// Token: 0x0600396D RID: 14701 RVA: 0x00096FF4 File Offset: 0x000951F4
			[CLSCompliant(false)]
			public static WaitSyncStatus ClientWaitSync(IntPtr sync, ClientWaitSyncFlags flags, long timeout)
			{
				return calli(System.Int32(System.IntPtr,System.Int32,System.UInt64), sync, flags, timeout, GL.EntryPoints[37]);
			}

			// Token: 0x0600396E RID: 14702 RVA: 0x00097008 File Offset: 0x00095208
			[CLSCompliant(false)]
			public static WaitSyncStatus ClientWaitSync(IntPtr sync, ClientWaitSyncFlags flags, ulong timeout)
			{
				return calli(System.Int32(System.IntPtr,System.Int32,System.UInt64), sync, flags, timeout, GL.EntryPoints[37]);
			}

			// Token: 0x0600396F RID: 14703 RVA: 0x0009701C File Offset: 0x0009521C
			[CLSCompliant(false)]
			public static void CopyTextureLevel(int destinationTexture, int sourceTexture, int sourceBaseLevel, int sourceLevelCount)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32), destinationTexture, sourceTexture, sourceBaseLevel, sourceLevelCount, GL.EntryPoints[50]);
			}

			// Token: 0x06003970 RID: 14704 RVA: 0x00097030 File Offset: 0x00095230
			[CLSCompliant(false)]
			public static void CopyTextureLevel(uint destinationTexture, uint sourceTexture, int sourceBaseLevel, int sourceLevelCount)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32), destinationTexture, sourceTexture, sourceBaseLevel, sourceLevelCount, GL.EntryPoints[50]);
			}

			// Token: 0x06003971 RID: 14705 RVA: 0x00097044 File Offset: 0x00095244
			public static void DeleteSync(IntPtr sync)
			{
				calli(System.Void(System.IntPtr), sync, GL.EntryPoints[75]);
			}

			// Token: 0x06003972 RID: 14706 RVA: 0x00097054 File Offset: 0x00095254
			[Obsolete("Use strongly-typed overload instead")]
			public static IntPtr FenceSync(All condition, All flags)
			{
				return calli(System.IntPtr(System.Int32,System.Int32), condition, flags, GL.EntryPoints[120]);
			}

			// Token: 0x06003973 RID: 14707 RVA: 0x00097068 File Offset: 0x00095268
			public static IntPtr FenceSync(SyncCondition condition, WaitSyncFlags flags)
			{
				return calli(System.IntPtr(System.Int32,System.Int32), condition, flags, GL.EntryPoints[120]);
			}

			// Token: 0x06003974 RID: 14708 RVA: 0x0009707C File Offset: 0x0009527C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static long GetInteger64(All pname)
			{
				long result;
				calli(System.Void(System.Int32,System.Int64*), pname, ref result, GL.EntryPoints[159]);
				return result;
			}

			// Token: 0x06003975 RID: 14709 RVA: 0x000970A0 File Offset: 0x000952A0
			[CLSCompliant(false)]
			public static long GetInteger64(GetPName pname)
			{
				long result;
				calli(System.Void(System.Int32,System.Int64*), pname, ref result, GL.EntryPoints[159]);
				return result;
			}

			// Token: 0x06003976 RID: 14710 RVA: 0x000970C4 File Offset: 0x000952C4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetInteger64(All pname, [Out] long[] @params)
			{
				fixed (long* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int64*), pname, ptr, GL.EntryPoints[159]);
				}
			}

			// Token: 0x06003977 RID: 14711 RVA: 0x000970F8 File Offset: 0x000952F8
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetInteger64(All pname, out long @params)
			{
				fixed (long* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int64*), pname, ptr, GL.EntryPoints[159]);
				}
			}

			// Token: 0x06003978 RID: 14712 RVA: 0x0009711C File Offset: 0x0009531C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetInteger64(All pname, [Out] long* @params)
			{
				calli(System.Void(System.Int32,System.Int64*), pname, @params, GL.EntryPoints[159]);
			}

			// Token: 0x06003979 RID: 14713 RVA: 0x00097130 File Offset: 0x00095330
			[CLSCompliant(false)]
			public unsafe static void GetInteger64(GetPName pname, [Out] long[] @params)
			{
				fixed (long* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int64*), pname, ptr, GL.EntryPoints[159]);
				}
			}

			// Token: 0x0600397A RID: 14714 RVA: 0x00097164 File Offset: 0x00095364
			[CLSCompliant(false)]
			public unsafe static void GetInteger64(GetPName pname, out long @params)
			{
				fixed (long* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int64*), pname, ptr, GL.EntryPoints[159]);
				}
			}

			// Token: 0x0600397B RID: 14715 RVA: 0x00097188 File Offset: 0x00095388
			[CLSCompliant(false)]
			public unsafe static void GetInteger64(GetPName pname, [Out] long* @params)
			{
				calli(System.Void(System.Int32,System.Int64*), pname, @params, GL.EntryPoints[159]);
			}

			// Token: 0x0600397C RID: 14716 RVA: 0x0009719C File Offset: 0x0009539C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, All pname, int bufSize, [Out] int[] length, [Out] int[] values)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (values != null && values.Length != 0) ? ref values[0] : ref *null)
					{
						calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, ptr2, ptr3, GL.EntryPoints[200]);
					}
				}
			}

			// Token: 0x0600397D RID: 14717 RVA: 0x000971EC File Offset: 0x000953EC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, All pname, int bufSize, out int length, out int values)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &values)
					{
						calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, ptr2, ptr3, GL.EntryPoints[200]);
					}
				}
			}

			// Token: 0x0600397E RID: 14718 RVA: 0x00097218 File Offset: 0x00095418
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, All pname, int bufSize, [Out] int* length, [Out] int* values)
			{
				calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, length, values, GL.EntryPoints[200]);
			}

			// Token: 0x0600397F RID: 14719 RVA: 0x00097230 File Offset: 0x00095430
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, SyncParameterName pname, int bufSize, [Out] int[] length, [Out] int[] values)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (values != null && values.Length != 0) ? ref values[0] : ref *null)
					{
						calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, ptr2, ptr3, GL.EntryPoints[200]);
					}
				}
			}

			// Token: 0x06003980 RID: 14720 RVA: 0x00097280 File Offset: 0x00095480
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, SyncParameterName pname, int bufSize, out int length, out int values)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &values)
					{
						calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, ptr2, ptr3, GL.EntryPoints[200]);
					}
				}
			}

			// Token: 0x06003981 RID: 14721 RVA: 0x000972AC File Offset: 0x000954AC
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, SyncParameterName pname, int bufSize, [Out] int* length, [Out] int* values)
			{
				calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, length, values, GL.EntryPoints[200]);
			}

			// Token: 0x06003982 RID: 14722 RVA: 0x000972C4 File Offset: 0x000954C4
			public static bool IsSync(IntPtr sync)
			{
				return calli(System.Byte(System.IntPtr), sync, GL.EntryPoints[224]);
			}

			// Token: 0x06003983 RID: 14723 RVA: 0x000972D8 File Offset: 0x000954D8
			[Obsolete("Use strongly-typed overload instead")]
			public static void RenderbufferStorageMultisample(All target, int samples, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[292]);
			}

			// Token: 0x06003984 RID: 14724 RVA: 0x000972F0 File Offset: 0x000954F0
			public static void RenderbufferStorageMultisample(RenderbufferTarget target, int samples, RenderbufferInternalFormat internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[292]);
			}

			// Token: 0x06003985 RID: 14725 RVA: 0x00097308 File Offset: 0x00095508
			public static void ResolveMultisampleFramebuffer()
			{
				calli(System.Void(), GL.EntryPoints[296]);
			}

			// Token: 0x06003986 RID: 14726 RVA: 0x0009731C File Offset: 0x0009551C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void WaitSync(IntPtr sync, All flags, long timeout)
			{
				calli(System.Void(System.IntPtr,System.Int32,System.UInt64), sync, flags, timeout, GL.EntryPoints[377]);
			}

			// Token: 0x06003987 RID: 14727 RVA: 0x00097334 File Offset: 0x00095534
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void WaitSync(IntPtr sync, All flags, ulong timeout)
			{
				calli(System.Void(System.IntPtr,System.Int32,System.UInt64), sync, flags, timeout, GL.EntryPoints[377]);
			}

			// Token: 0x06003988 RID: 14728 RVA: 0x0009734C File Offset: 0x0009554C
			[CLSCompliant(false)]
			public static void WaitSync(IntPtr sync, WaitSyncFlags flags, long timeout)
			{
				calli(System.Void(System.IntPtr,System.Int32,System.UInt64), sync, flags, timeout, GL.EntryPoints[377]);
			}

			// Token: 0x06003989 RID: 14729 RVA: 0x00097364 File Offset: 0x00095564
			[CLSCompliant(false)]
			public static void WaitSync(IntPtr sync, WaitSyncFlags flags, ulong timeout)
			{
				calli(System.Void(System.IntPtr,System.Int32,System.UInt64), sync, flags, timeout, GL.EntryPoints[377]);
			}
		}

		// Token: 0x02000508 RID: 1288
		public static class Ext
		{
			// Token: 0x0600398A RID: 14730 RVA: 0x0009737C File Offset: 0x0009557C
			[CLSCompliant(false)]
			public static void ActiveProgram(int program)
			{
				calli(System.Void(System.UInt32), program, GL.EntryPoints[0]);
			}

			// Token: 0x0600398B RID: 14731 RVA: 0x0009738C File Offset: 0x0009558C
			[CLSCompliant(false)]
			public static void ActiveProgram(uint program)
			{
				calli(System.Void(System.UInt32), program, GL.EntryPoints[0]);
			}

			// Token: 0x0600398C RID: 14732 RVA: 0x0009739C File Offset: 0x0009559C
			[CLSCompliant(false)]
			public static void ActiveShaderProgram(int pipeline, int program)
			{
				calli(System.Void(System.UInt32,System.UInt32), pipeline, program, GL.EntryPoints[1]);
			}

			// Token: 0x0600398D RID: 14733 RVA: 0x000973AC File Offset: 0x000955AC
			[CLSCompliant(false)]
			public static void ActiveShaderProgram(uint pipeline, uint program)
			{
				calli(System.Void(System.UInt32,System.UInt32), pipeline, program, GL.EntryPoints[1]);
			}

			// Token: 0x0600398E RID: 14734 RVA: 0x000973BC File Offset: 0x000955BC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void BeginQuery(All target, int id)
			{
				calli(System.Void(System.Int32,System.UInt32), target, id, GL.EntryPoints[7]);
			}

			// Token: 0x0600398F RID: 14735 RVA: 0x000973CC File Offset: 0x000955CC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void BeginQuery(All target, uint id)
			{
				calli(System.Void(System.Int32,System.UInt32), target, id, GL.EntryPoints[7]);
			}

			// Token: 0x06003990 RID: 14736 RVA: 0x000973DC File Offset: 0x000955DC
			[CLSCompliant(false)]
			public static void BeginQuery(QueryTarget target, int id)
			{
				calli(System.Void(System.Int32,System.UInt32), target, id, GL.EntryPoints[7]);
			}

			// Token: 0x06003991 RID: 14737 RVA: 0x000973EC File Offset: 0x000955EC
			[CLSCompliant(false)]
			public static void BeginQuery(QueryTarget target, uint id)
			{
				calli(System.Void(System.Int32,System.UInt32), target, id, GL.EntryPoints[7]);
			}

			// Token: 0x06003992 RID: 14738 RVA: 0x000973FC File Offset: 0x000955FC
			[CLSCompliant(false)]
			public static void BindProgramPipeline(int pipeline)
			{
				calli(System.Void(System.UInt32), pipeline, GL.EntryPoints[11]);
			}

			// Token: 0x06003993 RID: 14739 RVA: 0x0009740C File Offset: 0x0009560C
			[CLSCompliant(false)]
			public static void BindProgramPipeline(uint pipeline)
			{
				calli(System.Void(System.UInt32), pipeline, GL.EntryPoints[11]);
			}

			// Token: 0x06003994 RID: 14740 RVA: 0x0009741C File Offset: 0x0009561C
			[Obsolete("Use strongly-typed overload instead")]
			public static void BlendEquation(All mode)
			{
				calli(System.Void(System.Int32), mode, GL.EntryPoints[19]);
			}

			// Token: 0x06003995 RID: 14741 RVA: 0x0009742C File Offset: 0x0009562C
			public static void BlendEquation(BlendEquationMode mode)
			{
				calli(System.Void(System.Int32), mode, GL.EntryPoints[19]);
			}

			// Token: 0x06003996 RID: 14742 RVA: 0x0009743C File Offset: 0x0009563C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static void BlendEquation(int buf, All mode)
			{
				calli(System.Void(System.UInt32,System.Int32), buf, mode, GL.EntryPoints[20]);
			}

			// Token: 0x06003997 RID: 14743 RVA: 0x00097450 File Offset: 0x00095650
			[CLSCompliant(false)]
			public static void BlendEquation(int buf, BlendEquationMode mode)
			{
				calli(System.Void(System.UInt32,System.Int32), buf, mode, GL.EntryPoints[20]);
			}

			// Token: 0x06003998 RID: 14744 RVA: 0x00097464 File Offset: 0x00095664
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void BlendEquation(uint buf, All mode)
			{
				calli(System.Void(System.UInt32,System.Int32), buf, mode, GL.EntryPoints[20]);
			}

			// Token: 0x06003999 RID: 14745 RVA: 0x00097478 File Offset: 0x00095678
			[CLSCompliant(false)]
			public static void BlendEquation(uint buf, BlendEquationMode mode)
			{
				calli(System.Void(System.UInt32,System.Int32), buf, mode, GL.EntryPoints[20]);
			}

			// Token: 0x0600399A RID: 14746 RVA: 0x0009748C File Offset: 0x0009568C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void BlendEquationSeparate(int buf, All modeRGB, All modeAlpha)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), buf, modeRGB, modeAlpha, GL.EntryPoints[22]);
			}

			// Token: 0x0600399B RID: 14747 RVA: 0x000974A0 File Offset: 0x000956A0
			[CLSCompliant(false)]
			public static void BlendEquationSeparate(int buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), buf, modeRGB, modeAlpha, GL.EntryPoints[22]);
			}

			// Token: 0x0600399C RID: 14748 RVA: 0x000974B4 File Offset: 0x000956B4
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void BlendEquationSeparate(uint buf, All modeRGB, All modeAlpha)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), buf, modeRGB, modeAlpha, GL.EntryPoints[22]);
			}

			// Token: 0x0600399D RID: 14749 RVA: 0x000974C8 File Offset: 0x000956C8
			[CLSCompliant(false)]
			public static void BlendEquationSeparate(uint buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), buf, modeRGB, modeAlpha, GL.EntryPoints[22]);
			}

			// Token: 0x0600399E RID: 14750 RVA: 0x000974DC File Offset: 0x000956DC
			[CLSCompliant(false)]
			public static void BlendFunc(int buf, All src, All dst)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), buf, src, dst, GL.EntryPoints[24]);
			}

			// Token: 0x0600399F RID: 14751 RVA: 0x000974F0 File Offset: 0x000956F0
			[CLSCompliant(false)]
			public static void BlendFunc(uint buf, All src, All dst)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), buf, src, dst, GL.EntryPoints[24]);
			}

			// Token: 0x060039A0 RID: 14752 RVA: 0x00097504 File Offset: 0x00095704
			[CLSCompliant(false)]
			public static void BlendFuncSeparate(int buf, All srcRGB, All dstRGB, All srcAlpha, All dstAlpha)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32), buf, srcRGB, dstRGB, srcAlpha, dstAlpha, GL.EntryPoints[26]);
			}

			// Token: 0x060039A1 RID: 14753 RVA: 0x0009751C File Offset: 0x0009571C
			[CLSCompliant(false)]
			public static void BlendFuncSeparate(uint buf, All srcRGB, All dstRGB, All srcAlpha, All dstAlpha)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32), buf, srcRGB, dstRGB, srcAlpha, dstAlpha, GL.EntryPoints[26]);
			}

			// Token: 0x060039A2 RID: 14754 RVA: 0x00097534 File Offset: 0x00095734
			[CLSCompliant(false)]
			public static void ColorMask(int index, bool r, bool g, bool b, bool a)
			{
				calli(System.Void(System.UInt32,System.Boolean,System.Boolean,System.Boolean,System.Boolean), index, r, g, b, a, GL.EntryPoints[39]);
			}

			// Token: 0x060039A3 RID: 14755 RVA: 0x0009754C File Offset: 0x0009574C
			[CLSCompliant(false)]
			public static void ColorMask(uint index, bool r, bool g, bool b, bool a)
			{
				calli(System.Void(System.UInt32,System.Boolean,System.Boolean,System.Boolean,System.Boolean), index, r, g, b, a, GL.EntryPoints[39]);
			}

			// Token: 0x060039A4 RID: 14756 RVA: 0x00097564 File Offset: 0x00095764
			[CLSCompliant(false)]
			public static void CopyImageSubData(int srcName, All srcTarget, int srcLevel, int srcX, int srcY, int srcZ, int dstName, All dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth, GL.EntryPoints[46]);
			}

			// Token: 0x060039A5 RID: 14757 RVA: 0x00097598 File Offset: 0x00095798
			[CLSCompliant(false)]
			public static void CopyImageSubData(uint srcName, All srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, All dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth, GL.EntryPoints[46]);
			}

			// Token: 0x060039A6 RID: 14758 RVA: 0x000975CC File Offset: 0x000957CC
			public static int CreateShaderProgram(All type, string @string)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(@string);
				int result = calli(System.Int32(System.Int32,System.IntPtr), type, intPtr, GL.EntryPoints[56]);
				BindingsBase.FreeStringPtr(intPtr);
				return result;
			}

			// Token: 0x060039A7 RID: 14759 RVA: 0x000975F8 File Offset: 0x000957F8
			public static int CreateShaderProgram(All type, int count, string[] strings)
			{
				IntPtr intPtr = BindingsBase.MarshalStringArrayToPtr(strings);
				int result = calli(System.Int32(System.Int32,System.Int32,System.IntPtr), type, count, intPtr, GL.EntryPoints[57]);
				BindingsBase.FreeStringArrayPtr(intPtr, strings.Length);
				return result;
			}

			// Token: 0x060039A8 RID: 14760 RVA: 0x00097628 File Offset: 0x00095828
			[CLSCompliant(false)]
			public static void DeleteProgramPipeline(int pipelines)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref pipelines, GL.EntryPoints[71]);
			}

			// Token: 0x060039A9 RID: 14761 RVA: 0x0009763C File Offset: 0x0009583C
			[CLSCompliant(false)]
			public static void DeleteProgramPipeline(uint pipelines)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref pipelines, GL.EntryPoints[71]);
			}

			// Token: 0x060039AA RID: 14762 RVA: 0x00097650 File Offset: 0x00095850
			[CLSCompliant(false)]
			public unsafe static void DeleteProgramPipelines(int n, int[] pipelines)
			{
				fixed (int* ptr = ref (pipelines != null && pipelines.Length != 0) ? ref pipelines[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[71]);
				}
			}

			// Token: 0x060039AB RID: 14763 RVA: 0x00097684 File Offset: 0x00095884
			[CLSCompliant(false)]
			public unsafe static void DeleteProgramPipelines(int n, ref int pipelines)
			{
				fixed (int* ptr = &pipelines)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[71]);
				}
			}

			// Token: 0x060039AC RID: 14764 RVA: 0x000976A4 File Offset: 0x000958A4
			[CLSCompliant(false)]
			public unsafe static void DeleteProgramPipelines(int n, int* pipelines)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, pipelines, GL.EntryPoints[71]);
			}

			// Token: 0x060039AD RID: 14765 RVA: 0x000976B8 File Offset: 0x000958B8
			[CLSCompliant(false)]
			public unsafe static void DeleteProgramPipelines(int n, uint[] pipelines)
			{
				fixed (uint* ptr = ref (pipelines != null && pipelines.Length != 0) ? ref pipelines[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[71]);
				}
			}

			// Token: 0x060039AE RID: 14766 RVA: 0x000976EC File Offset: 0x000958EC
			[CLSCompliant(false)]
			public unsafe static void DeleteProgramPipelines(int n, ref uint pipelines)
			{
				fixed (uint* ptr = &pipelines)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[71]);
				}
			}

			// Token: 0x060039AF RID: 14767 RVA: 0x0009770C File Offset: 0x0009590C
			[CLSCompliant(false)]
			public unsafe static void DeleteProgramPipelines(int n, uint* pipelines)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, pipelines, GL.EntryPoints[71]);
			}

			// Token: 0x060039B0 RID: 14768 RVA: 0x00097720 File Offset: 0x00095920
			[CLSCompliant(false)]
			public static void DeleteQuery(int ids)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref ids, GL.EntryPoints[72]);
			}

			// Token: 0x060039B1 RID: 14769 RVA: 0x00097734 File Offset: 0x00095934
			[CLSCompliant(false)]
			public static void DeleteQuery(uint ids)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref ids, GL.EntryPoints[72]);
			}

			// Token: 0x060039B2 RID: 14770 RVA: 0x00097748 File Offset: 0x00095948
			[CLSCompliant(false)]
			public unsafe static void DeleteQueries(int n, int[] ids)
			{
				fixed (int* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[72]);
				}
			}

			// Token: 0x060039B3 RID: 14771 RVA: 0x0009777C File Offset: 0x0009597C
			[CLSCompliant(false)]
			public unsafe static void DeleteQueries(int n, ref int ids)
			{
				fixed (int* ptr = &ids)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[72]);
				}
			}

			// Token: 0x060039B4 RID: 14772 RVA: 0x0009779C File Offset: 0x0009599C
			[CLSCompliant(false)]
			public unsafe static void DeleteQueries(int n, int* ids)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ids, GL.EntryPoints[72]);
			}

			// Token: 0x060039B5 RID: 14773 RVA: 0x000977B0 File Offset: 0x000959B0
			[CLSCompliant(false)]
			public unsafe static void DeleteQueries(int n, uint[] ids)
			{
				fixed (uint* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[72]);
				}
			}

			// Token: 0x060039B6 RID: 14774 RVA: 0x000977E4 File Offset: 0x000959E4
			[CLSCompliant(false)]
			public unsafe static void DeleteQueries(int n, ref uint ids)
			{
				fixed (uint* ptr = &ids)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[72]);
				}
			}

			// Token: 0x060039B7 RID: 14775 RVA: 0x00097804 File Offset: 0x00095A04
			[CLSCompliant(false)]
			public unsafe static void DeleteQueries(int n, uint* ids)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ids, GL.EntryPoints[72]);
			}

			// Token: 0x060039B8 RID: 14776 RVA: 0x00097818 File Offset: 0x00095A18
			[CLSCompliant(false)]
			public static void Disable(All target, int index)
			{
				calli(System.Void(System.Int32,System.UInt32), target, index, GL.EntryPoints[84]);
			}

			// Token: 0x060039B9 RID: 14777 RVA: 0x0009782C File Offset: 0x00095A2C
			[CLSCompliant(false)]
			public static void Disable(All target, uint index)
			{
				calli(System.Void(System.Int32,System.UInt32), target, index, GL.EntryPoints[84]);
			}

			// Token: 0x060039BA RID: 14778 RVA: 0x00097840 File Offset: 0x00095A40
			[CLSCompliant(false)]
			public unsafe static void DiscardFramebuffer(All target, int numAttachments, All[] attachments)
			{
				fixed (All* ptr = ref (attachments != null && attachments.Length != 0) ? ref attachments[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, numAttachments, ptr, GL.EntryPoints[86]);
				}
			}

			// Token: 0x060039BB RID: 14779 RVA: 0x00097874 File Offset: 0x00095A74
			[CLSCompliant(false)]
			public unsafe static void DiscardFramebuffer(All target, int numAttachments, ref All attachments)
			{
				fixed (All* ptr = &attachments)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, numAttachments, ptr, GL.EntryPoints[86]);
				}
			}

			// Token: 0x060039BC RID: 14780 RVA: 0x00097894 File Offset: 0x00095A94
			[CLSCompliant(false)]
			public unsafe static void DiscardFramebuffer(All target, int numAttachments, All* attachments)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, numAttachments, attachments, GL.EntryPoints[86]);
			}

			// Token: 0x060039BD RID: 14781 RVA: 0x000978A8 File Offset: 0x00095AA8
			[Obsolete("Use strongly-typed overload instead")]
			public static void DrawArraysInstanced(All mode, int start, int count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), mode, start, count, primcount, GL.EntryPoints[89]);
			}

			// Token: 0x060039BE RID: 14782 RVA: 0x000978BC File Offset: 0x00095ABC
			public static void DrawArraysInstanced(PrimitiveType mode, int start, int count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), mode, start, count, primcount, GL.EntryPoints[89]);
			}

			// Token: 0x060039BF RID: 14783 RVA: 0x000978D0 File Offset: 0x00095AD0
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawBuffers(int n, All[] bufs)
			{
				fixed (All* ptr = ref (bufs != null && bufs.Length != 0) ? ref bufs[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), n, ptr, GL.EntryPoints[91]);
				}
			}

			// Token: 0x060039C0 RID: 14784 RVA: 0x00097904 File Offset: 0x00095B04
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawBuffers(int n, ref All bufs)
			{
				fixed (All* ptr = &bufs)
				{
					calli(System.Void(System.Int32,System.Int32*), n, ptr, GL.EntryPoints[91]);
				}
			}

			// Token: 0x060039C1 RID: 14785 RVA: 0x00097924 File Offset: 0x00095B24
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawBuffers(int n, All* bufs)
			{
				calli(System.Void(System.Int32,System.Int32*), n, bufs, GL.EntryPoints[91]);
			}

			// Token: 0x060039C2 RID: 14786 RVA: 0x00097938 File Offset: 0x00095B38
			[CLSCompliant(false)]
			public unsafe static void DrawBuffers(int n, DrawBufferMode[] bufs)
			{
				fixed (DrawBufferMode* ptr = ref (bufs != null && bufs.Length != 0) ? ref bufs[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), n, ptr, GL.EntryPoints[91]);
				}
			}

			// Token: 0x060039C3 RID: 14787 RVA: 0x0009796C File Offset: 0x00095B6C
			[CLSCompliant(false)]
			public unsafe static void DrawBuffers(int n, ref DrawBufferMode bufs)
			{
				fixed (DrawBufferMode* ptr = &bufs)
				{
					calli(System.Void(System.Int32,System.Int32*), n, ptr, GL.EntryPoints[91]);
				}
			}

			// Token: 0x060039C4 RID: 14788 RVA: 0x0009798C File Offset: 0x00095B8C
			[CLSCompliant(false)]
			public unsafe static void DrawBuffers(int n, DrawBufferMode* bufs)
			{
				calli(System.Void(System.Int32,System.Int32*), n, bufs, GL.EntryPoints[91]);
			}

			// Token: 0x060039C5 RID: 14789 RVA: 0x000979A0 File Offset: 0x00095BA0
			[CLSCompliant(false)]
			public unsafe static void DrawBuffersIndexed(int n, All[] location, int[] indices)
			{
				fixed (All* ptr = ref (location != null && location.Length != 0) ? ref location[0] : ref *null)
				{
					All* ptr2 = ptr;
					fixed (int* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*), n, ptr2, ptr3, GL.EntryPoints[92]);
					}
				}
			}

			// Token: 0x060039C6 RID: 14790 RVA: 0x000979E8 File Offset: 0x00095BE8
			[CLSCompliant(false)]
			public unsafe static void DrawBuffersIndexed(int n, ref All location, ref int indices)
			{
				fixed (All* ptr = &location)
				{
					All* ptr2 = ptr;
					fixed (int* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*), n, ptr2, ptr3, GL.EntryPoints[92]);
					}
				}
			}

			// Token: 0x060039C7 RID: 14791 RVA: 0x00097A0C File Offset: 0x00095C0C
			[CLSCompliant(false)]
			public unsafe static void DrawBuffersIndexed(int n, All* location, int* indices)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32*), n, location, indices, GL.EntryPoints[92]);
			}

			// Token: 0x060039C8 RID: 14792 RVA: 0x00097A20 File Offset: 0x00095C20
			[Obsolete("Use strongly-typed overload instead")]
			public static void DrawElementsInstanced(All mode, int count, All type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[96]);
			}

			// Token: 0x060039C9 RID: 14793 RVA: 0x00097A38 File Offset: 0x00095C38
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[96]);
				}
			}

			// Token: 0x060039CA RID: 14794 RVA: 0x00097A70 File Offset: 0x00095C70
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[96]);
				}
			}

			// Token: 0x060039CB RID: 14795 RVA: 0x00097AAC File Offset: 0x00095CAC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[96]);
				}
			}

			// Token: 0x060039CC RID: 14796 RVA: 0x00097AE8 File Offset: 0x00095CE8
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[96]);
				}
			}

			// Token: 0x060039CD RID: 14797 RVA: 0x00097B0C File Offset: 0x00095D0C
			public static void DrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[96]);
			}

			// Token: 0x060039CE RID: 14798 RVA: 0x00097B24 File Offset: 0x00095D24
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[96]);
				}
			}

			// Token: 0x060039CF RID: 14799 RVA: 0x00097B5C File Offset: 0x00095D5C
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[96]);
				}
			}

			// Token: 0x060039D0 RID: 14800 RVA: 0x00097B98 File Offset: 0x00095D98
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[96]);
				}
			}

			// Token: 0x060039D1 RID: 14801 RVA: 0x00097BD4 File Offset: 0x00095DD4
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[96]);
				}
			}

			// Token: 0x060039D2 RID: 14802 RVA: 0x00097BF8 File Offset: 0x00095DF8
			[CLSCompliant(false)]
			public static void Enable(All target, int index)
			{
				calli(System.Void(System.Int32,System.UInt32), target, index, GL.EntryPoints[102]);
			}

			// Token: 0x060039D3 RID: 14803 RVA: 0x00097C0C File Offset: 0x00095E0C
			[CLSCompliant(false)]
			public static void Enable(All target, uint index)
			{
				calli(System.Void(System.Int32,System.UInt32), target, index, GL.EntryPoints[102]);
			}

			// Token: 0x060039D4 RID: 14804 RVA: 0x00097C20 File Offset: 0x00095E20
			[Obsolete("Use strongly-typed overload instead")]
			public static void EndQuery(All target)
			{
				calli(System.Void(System.Int32), target, GL.EntryPoints[106]);
			}

			// Token: 0x060039D5 RID: 14805 RVA: 0x00097C30 File Offset: 0x00095E30
			public static void EndQuery(QueryTarget target)
			{
				calli(System.Void(System.Int32), target, GL.EntryPoints[106]);
			}

			// Token: 0x060039D6 RID: 14806 RVA: 0x00097C40 File Offset: 0x00095E40
			[Obsolete("Use strongly-typed overload instead")]
			public static void FlushMappedBufferRange(All target, IntPtr offset, IntPtr length)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr), target, offset, length, GL.EntryPoints[124]);
			}

			// Token: 0x060039D7 RID: 14807 RVA: 0x00097C54 File Offset: 0x00095E54
			public static void FlushMappedBufferRange(BufferTarget target, IntPtr offset, IntPtr length)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr), target, offset, length, GL.EntryPoints[124]);
			}

			// Token: 0x060039D8 RID: 14808 RVA: 0x00097C68 File Offset: 0x00095E68
			[CLSCompliant(false)]
			public static void FramebufferTexture2DMultisample(All target, All attachment, All textarget, int texture, int level, int samples)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, samples, GL.EntryPoints[127]);
			}

			// Token: 0x060039D9 RID: 14809 RVA: 0x00097C80 File Offset: 0x00095E80
			[CLSCompliant(false)]
			public static void FramebufferTexture2DMultisample(All target, All attachment, All textarget, uint texture, int level, int samples)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, samples, GL.EntryPoints[127]);
			}

			// Token: 0x060039DA RID: 14810 RVA: 0x00097C98 File Offset: 0x00095E98
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static void FramebufferTexture(All target, All attachment, int texture, int level)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, texture, level, GL.EntryPoints[130]);
			}

			// Token: 0x060039DB RID: 14811 RVA: 0x00097CB0 File Offset: 0x00095EB0
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void FramebufferTexture(All target, All attachment, uint texture, int level)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, texture, level, GL.EntryPoints[130]);
			}

			// Token: 0x060039DC RID: 14812 RVA: 0x00097CC8 File Offset: 0x00095EC8
			[CLSCompliant(false)]
			public static void FramebufferTexture(FramebufferTarget target, All attachment, int texture, int level)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, texture, level, GL.EntryPoints[130]);
			}

			// Token: 0x060039DD RID: 14813 RVA: 0x00097CE0 File Offset: 0x00095EE0
			[CLSCompliant(false)]
			public static void FramebufferTexture(FramebufferTarget target, All attachment, uint texture, int level)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, texture, level, GL.EntryPoints[130]);
			}

			// Token: 0x060039DE RID: 14814 RVA: 0x00097CF8 File Offset: 0x00095EF8
			[CLSCompliant(false)]
			public static int GenProgramPipeline()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[137]);
				return result;
			}

			// Token: 0x060039DF RID: 14815 RVA: 0x00097D1C File Offset: 0x00095F1C
			[CLSCompliant(false)]
			public unsafe static void GenProgramPipelines(int n, [Out] int[] pipelines)
			{
				fixed (int* ptr = ref (pipelines != null && pipelines.Length != 0) ? ref pipelines[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[137]);
				}
			}

			// Token: 0x060039E0 RID: 14816 RVA: 0x00097D50 File Offset: 0x00095F50
			[CLSCompliant(false)]
			public unsafe static void GenProgramPipelines(int n, out int pipelines)
			{
				fixed (int* ptr = &pipelines)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[137]);
				}
			}

			// Token: 0x060039E1 RID: 14817 RVA: 0x00097D74 File Offset: 0x00095F74
			[CLSCompliant(false)]
			public unsafe static void GenProgramPipelines(int n, [Out] int* pipelines)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, pipelines, GL.EntryPoints[137]);
			}

			// Token: 0x060039E2 RID: 14818 RVA: 0x00097D88 File Offset: 0x00095F88
			[CLSCompliant(false)]
			public unsafe static void GenProgramPipelines(int n, [Out] uint[] pipelines)
			{
				fixed (uint* ptr = ref (pipelines != null && pipelines.Length != 0) ? ref pipelines[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[137]);
				}
			}

			// Token: 0x060039E3 RID: 14819 RVA: 0x00097DBC File Offset: 0x00095FBC
			[CLSCompliant(false)]
			public unsafe static void GenProgramPipelines(int n, out uint pipelines)
			{
				fixed (uint* ptr = &pipelines)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[137]);
				}
			}

			// Token: 0x060039E4 RID: 14820 RVA: 0x00097DE0 File Offset: 0x00095FE0
			[CLSCompliant(false)]
			public unsafe static void GenProgramPipelines(int n, [Out] uint* pipelines)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, pipelines, GL.EntryPoints[137]);
			}

			// Token: 0x060039E5 RID: 14821 RVA: 0x00097DF4 File Offset: 0x00095FF4
			[CLSCompliant(false)]
			public static int GenQuery()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[138]);
				return result;
			}

			// Token: 0x060039E6 RID: 14822 RVA: 0x00097E18 File Offset: 0x00096018
			[CLSCompliant(false)]
			public unsafe static void GenQueries(int n, [Out] int[] ids)
			{
				fixed (int* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[138]);
				}
			}

			// Token: 0x060039E7 RID: 14823 RVA: 0x00097E4C File Offset: 0x0009604C
			[CLSCompliant(false)]
			public unsafe static void GenQueries(int n, out int ids)
			{
				fixed (int* ptr = &ids)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[138]);
				}
			}

			// Token: 0x060039E8 RID: 14824 RVA: 0x00097E70 File Offset: 0x00096070
			[CLSCompliant(false)]
			public unsafe static void GenQueries(int n, [Out] int* ids)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ids, GL.EntryPoints[138]);
			}

			// Token: 0x060039E9 RID: 14825 RVA: 0x00097E84 File Offset: 0x00096084
			[CLSCompliant(false)]
			public unsafe static void GenQueries(int n, [Out] uint[] ids)
			{
				fixed (uint* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[138]);
				}
			}

			// Token: 0x060039EA RID: 14826 RVA: 0x00097EB8 File Offset: 0x000960B8
			[CLSCompliant(false)]
			public unsafe static void GenQueries(int n, out uint ids)
			{
				fixed (uint* ptr = &ids)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[138]);
				}
			}

			// Token: 0x060039EB RID: 14827 RVA: 0x00097EDC File Offset: 0x000960DC
			[CLSCompliant(false)]
			public unsafe static void GenQueries(int n, [Out] uint* ids)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ids, GL.EntryPoints[138]);
			}

			// Token: 0x060039EC RID: 14828 RVA: 0x00097EF0 File Offset: 0x000960F0
			public static All GetGraphicsResetStatus()
			{
				return calli(System.Int32(), GL.EntryPoints[158]);
			}

			// Token: 0x060039ED RID: 14829 RVA: 0x00097F04 File Offset: 0x00096104
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetInteger(All target, int index, [Out] int[] data)
			{
				fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, ptr, GL.EntryPoints[160]);
				}
			}

			// Token: 0x060039EE RID: 14830 RVA: 0x00097F3C File Offset: 0x0009613C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetInteger(All target, int index, out int data)
			{
				fixed (int* ptr = &data)
				{
					calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, ptr, GL.EntryPoints[160]);
				}
			}

			// Token: 0x060039EF RID: 14831 RVA: 0x00097F60 File Offset: 0x00096160
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetInteger(All target, int index, [Out] int* data)
			{
				calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, data, GL.EntryPoints[160]);
			}

			// Token: 0x060039F0 RID: 14832 RVA: 0x00097F78 File Offset: 0x00096178
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetInteger(All target, uint index, [Out] int[] data)
			{
				fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, ptr, GL.EntryPoints[160]);
				}
			}

			// Token: 0x060039F1 RID: 14833 RVA: 0x00097FB0 File Offset: 0x000961B0
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetInteger(All target, uint index, out int data)
			{
				fixed (int* ptr = &data)
				{
					calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, ptr, GL.EntryPoints[160]);
				}
			}

			// Token: 0x060039F2 RID: 14834 RVA: 0x00097FD4 File Offset: 0x000961D4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetInteger(All target, uint index, [Out] int* data)
			{
				calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, data, GL.EntryPoints[160]);
			}

			// Token: 0x060039F3 RID: 14835 RVA: 0x00097FEC File Offset: 0x000961EC
			[CLSCompliant(false)]
			public unsafe static void GetInteger(GetIndexedPName target, int index, [Out] int[] data)
			{
				fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, ptr, GL.EntryPoints[160]);
				}
			}

			// Token: 0x060039F4 RID: 14836 RVA: 0x00098024 File Offset: 0x00096224
			[CLSCompliant(false)]
			public unsafe static void GetInteger(GetIndexedPName target, int index, out int data)
			{
				fixed (int* ptr = &data)
				{
					calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, ptr, GL.EntryPoints[160]);
				}
			}

			// Token: 0x060039F5 RID: 14837 RVA: 0x00098048 File Offset: 0x00096248
			[CLSCompliant(false)]
			public unsafe static void GetInteger(GetIndexedPName target, int index, [Out] int* data)
			{
				calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, data, GL.EntryPoints[160]);
			}

			// Token: 0x060039F6 RID: 14838 RVA: 0x00098060 File Offset: 0x00096260
			[CLSCompliant(false)]
			public unsafe static void GetInteger(GetIndexedPName target, uint index, [Out] int[] data)
			{
				fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, ptr, GL.EntryPoints[160]);
				}
			}

			// Token: 0x060039F7 RID: 14839 RVA: 0x00098098 File Offset: 0x00096298
			[CLSCompliant(false)]
			public unsafe static void GetInteger(GetIndexedPName target, uint index, out int data)
			{
				fixed (int* ptr = &data)
				{
					calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, ptr, GL.EntryPoints[160]);
				}
			}

			// Token: 0x060039F8 RID: 14840 RVA: 0x000980BC File Offset: 0x000962BC
			[CLSCompliant(false)]
			public unsafe static void GetInteger(GetIndexedPName target, uint index, [Out] int* data)
			{
				calli(System.Void(System.Int32,System.UInt32,System.Int32*), target, index, data, GL.EntryPoints[160]);
			}

			// Token: 0x060039F9 RID: 14841 RVA: 0x000980D4 File Offset: 0x000962D4
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, [Out] float[] @params)
			{
				fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, ptr, GL.EntryPoints[163]);
				}
			}

			// Token: 0x060039FA RID: 14842 RVA: 0x0009810C File Offset: 0x0009630C
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, out float @params)
			{
				fixed (float* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, ptr, GL.EntryPoints[163]);
				}
			}

			// Token: 0x060039FB RID: 14843 RVA: 0x00098130 File Offset: 0x00096330
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, [Out] float* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, @params, GL.EntryPoints[163]);
			}

			// Token: 0x060039FC RID: 14844 RVA: 0x00098148 File Offset: 0x00096348
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, [Out] float[] @params)
			{
				fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, ptr, GL.EntryPoints[163]);
				}
			}

			// Token: 0x060039FD RID: 14845 RVA: 0x00098180 File Offset: 0x00096380
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, out float @params)
			{
				fixed (float* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, ptr, GL.EntryPoints[163]);
				}
			}

			// Token: 0x060039FE RID: 14846 RVA: 0x000981A4 File Offset: 0x000963A4
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, [Out] float* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, @params, GL.EntryPoints[163]);
			}

			// Token: 0x060039FF RID: 14847 RVA: 0x000981BC File Offset: 0x000963BC
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, ptr, GL.EntryPoints[164]);
				}
			}

			// Token: 0x06003A00 RID: 14848 RVA: 0x000981F4 File Offset: 0x000963F4
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, ptr, GL.EntryPoints[164]);
				}
			}

			// Token: 0x06003A01 RID: 14849 RVA: 0x00098218 File Offset: 0x00096418
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, @params, GL.EntryPoints[164]);
			}

			// Token: 0x06003A02 RID: 14850 RVA: 0x00098230 File Offset: 0x00096430
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, ptr, GL.EntryPoints[164]);
				}
			}

			// Token: 0x06003A03 RID: 14851 RVA: 0x00098268 File Offset: 0x00096468
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, ptr, GL.EntryPoints[164]);
				}
			}

			// Token: 0x06003A04 RID: 14852 RVA: 0x0009828C File Offset: 0x0009648C
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, @params, GL.EntryPoints[164]);
			}

			// Token: 0x06003A05 RID: 14853 RVA: 0x000982A4 File Offset: 0x000964A4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectLabel(All type, int @object, int bufSize, [Out] int[] length, [Out] StringBuilder label)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), type, @object, bufSize, ptr2, intPtr, GL.EntryPoints[166]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003A06 RID: 14854 RVA: 0x000982F8 File Offset: 0x000964F8
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(All type, int @object, int bufSize, out int length, [Out] StringBuilder label)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), type, @object, bufSize, ptr2, intPtr, GL.EntryPoints[166]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003A07 RID: 14855 RVA: 0x00098338 File Offset: 0x00096538
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(All type, int @object, int bufSize, [Out] int* length, [Out] StringBuilder label)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), type, @object, bufSize, length, intPtr, GL.EntryPoints[166]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003A08 RID: 14856 RVA: 0x00098378 File Offset: 0x00096578
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectLabel(All type, uint @object, int bufSize, [Out] int[] length, [Out] StringBuilder label)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), type, @object, bufSize, ptr2, intPtr, GL.EntryPoints[166]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003A09 RID: 14857 RVA: 0x000983CC File Offset: 0x000965CC
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectLabel(All type, uint @object, int bufSize, out int length, [Out] StringBuilder label)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), type, @object, bufSize, ptr2, intPtr, GL.EntryPoints[166]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003A0A RID: 14858 RVA: 0x0009840C File Offset: 0x0009660C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(All type, uint @object, int bufSize, [Out] int* length, [Out] StringBuilder label)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), type, @object, bufSize, length, intPtr, GL.EntryPoints[166]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003A0B RID: 14859 RVA: 0x0009844C File Offset: 0x0009664C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramPipelineInfoLog(int pipeline, int bufSize, [Out] int[] length, [Out] StringBuilder infoLog)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), pipeline, bufSize, ptr2, intPtr, GL.EntryPoints[185]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003A0C RID: 14860 RVA: 0x0009849C File Offset: 0x0009669C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramPipelineInfoLog(int pipeline, int bufSize, out int length, [Out] StringBuilder infoLog)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), pipeline, bufSize, ptr2, intPtr, GL.EntryPoints[185]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003A0D RID: 14861 RVA: 0x000984DC File Offset: 0x000966DC
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramPipelineInfoLog(int pipeline, int bufSize, [Out] int* length, [Out] StringBuilder infoLog)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), pipeline, bufSize, length, intPtr, GL.EntryPoints[185]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003A0E RID: 14862 RVA: 0x00098518 File Offset: 0x00096718
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramPipelineInfoLog(uint pipeline, int bufSize, [Out] int[] length, [Out] StringBuilder infoLog)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), pipeline, bufSize, ptr2, intPtr, GL.EntryPoints[185]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003A0F RID: 14863 RVA: 0x00098568 File Offset: 0x00096768
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramPipelineInfoLog(uint pipeline, int bufSize, out int length, [Out] StringBuilder infoLog)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), pipeline, bufSize, ptr2, intPtr, GL.EntryPoints[185]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003A10 RID: 14864 RVA: 0x000985A8 File Offset: 0x000967A8
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramPipelineInfoLog(uint pipeline, int bufSize, [Out] int* length, [Out] StringBuilder infoLog)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)infoLog.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), pipeline, bufSize, length, intPtr, GL.EntryPoints[185]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, infoLog);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003A11 RID: 14865 RVA: 0x000985E4 File Offset: 0x000967E4
			[CLSCompliant(false)]
			public unsafe static void GetProgramPipeline(int pipeline, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), pipeline, pname, ptr, GL.EntryPoints[186]);
				}
			}

			// Token: 0x06003A12 RID: 14866 RVA: 0x0009861C File Offset: 0x0009681C
			[CLSCompliant(false)]
			public unsafe static void GetProgramPipeline(int pipeline, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), pipeline, pname, ptr, GL.EntryPoints[186]);
				}
			}

			// Token: 0x06003A13 RID: 14867 RVA: 0x00098640 File Offset: 0x00096840
			[CLSCompliant(false)]
			public unsafe static void GetProgramPipeline(int pipeline, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), pipeline, pname, @params, GL.EntryPoints[186]);
			}

			// Token: 0x06003A14 RID: 14868 RVA: 0x00098658 File Offset: 0x00096858
			[CLSCompliant(false)]
			public unsafe static void GetProgramPipeline(uint pipeline, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), pipeline, pname, ptr, GL.EntryPoints[186]);
				}
			}

			// Token: 0x06003A15 RID: 14869 RVA: 0x00098690 File Offset: 0x00096890
			[CLSCompliant(false)]
			public unsafe static void GetProgramPipeline(uint pipeline, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), pipeline, pname, ptr, GL.EntryPoints[186]);
				}
			}

			// Token: 0x06003A16 RID: 14870 RVA: 0x000986B4 File Offset: 0x000968B4
			[CLSCompliant(false)]
			public unsafe static void GetProgramPipeline(uint pipeline, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), pipeline, pname, @params, GL.EntryPoints[186]);
			}

			// Token: 0x06003A17 RID: 14871 RVA: 0x000986CC File Offset: 0x000968CC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetQuery(All target, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[187]);
				}
			}

			// Token: 0x06003A18 RID: 14872 RVA: 0x00098704 File Offset: 0x00096904
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQuery(All target, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[187]);
				}
			}

			// Token: 0x06003A19 RID: 14873 RVA: 0x00098728 File Offset: 0x00096928
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetQuery(All target, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[187]);
			}

			// Token: 0x06003A1A RID: 14874 RVA: 0x00098740 File Offset: 0x00096940
			[CLSCompliant(false)]
			public unsafe static void GetQuery(QueryTarget target, GetQueryParam pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[187]);
				}
			}

			// Token: 0x06003A1B RID: 14875 RVA: 0x00098778 File Offset: 0x00096978
			[CLSCompliant(false)]
			public unsafe static void GetQuery(QueryTarget target, GetQueryParam pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[187]);
				}
			}

			// Token: 0x06003A1C RID: 14876 RVA: 0x0009879C File Offset: 0x0009699C
			[CLSCompliant(false)]
			public unsafe static void GetQuery(QueryTarget target, GetQueryParam pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[187]);
			}

			// Token: 0x06003A1D RID: 14877 RVA: 0x000987B4 File Offset: 0x000969B4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(int id, All pname, [Out] long[] @params)
			{
				fixed (long* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, ptr, GL.EntryPoints[188]);
				}
			}

			// Token: 0x06003A1E RID: 14878 RVA: 0x000987EC File Offset: 0x000969EC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(int id, All pname, out long @params)
			{
				fixed (long* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, ptr, GL.EntryPoints[188]);
				}
			}

			// Token: 0x06003A1F RID: 14879 RVA: 0x00098810 File Offset: 0x00096A10
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(int id, All pname, [Out] long* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, @params, GL.EntryPoints[188]);
			}

			// Token: 0x06003A20 RID: 14880 RVA: 0x00098828 File Offset: 0x00096A28
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(int id, GetQueryObjectParam pname, [Out] long[] @params)
			{
				fixed (long* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, ptr, GL.EntryPoints[188]);
				}
			}

			// Token: 0x06003A21 RID: 14881 RVA: 0x00098860 File Offset: 0x00096A60
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(int id, GetQueryObjectParam pname, out long @params)
			{
				fixed (long* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, ptr, GL.EntryPoints[188]);
				}
			}

			// Token: 0x06003A22 RID: 14882 RVA: 0x00098884 File Offset: 0x00096A84
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(int id, GetQueryObjectParam pname, [Out] long* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, @params, GL.EntryPoints[188]);
			}

			// Token: 0x06003A23 RID: 14883 RVA: 0x0009889C File Offset: 0x00096A9C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, All pname, [Out] long[] @params)
			{
				fixed (long* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, ptr, GL.EntryPoints[188]);
				}
			}

			// Token: 0x06003A24 RID: 14884 RVA: 0x000988D4 File Offset: 0x00096AD4
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, All pname, out long @params)
			{
				fixed (long* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, ptr, GL.EntryPoints[188]);
				}
			}

			// Token: 0x06003A25 RID: 14885 RVA: 0x000988F8 File Offset: 0x00096AF8
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(uint id, All pname, [Out] long* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, @params, GL.EntryPoints[188]);
			}

			// Token: 0x06003A26 RID: 14886 RVA: 0x00098910 File Offset: 0x00096B10
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, [Out] long[] @params)
			{
				fixed (long* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, ptr, GL.EntryPoints[188]);
				}
			}

			// Token: 0x06003A27 RID: 14887 RVA: 0x00098948 File Offset: 0x00096B48
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, out long @params)
			{
				fixed (long* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, ptr, GL.EntryPoints[188]);
				}
			}

			// Token: 0x06003A28 RID: 14888 RVA: 0x0009896C File Offset: 0x00096B6C
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, [Out] long* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int64*), id, pname, @params, GL.EntryPoints[188]);
			}

			// Token: 0x06003A29 RID: 14889 RVA: 0x00098984 File Offset: 0x00096B84
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(int id, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, ptr, GL.EntryPoints[189]);
				}
			}

			// Token: 0x06003A2A RID: 14890 RVA: 0x000989BC File Offset: 0x00096BBC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(int id, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, ptr, GL.EntryPoints[189]);
				}
			}

			// Token: 0x06003A2B RID: 14891 RVA: 0x000989E0 File Offset: 0x00096BE0
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(int id, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, @params, GL.EntryPoints[189]);
			}

			// Token: 0x06003A2C RID: 14892 RVA: 0x000989F8 File Offset: 0x00096BF8
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(int id, GetQueryObjectParam pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, ptr, GL.EntryPoints[189]);
				}
			}

			// Token: 0x06003A2D RID: 14893 RVA: 0x00098A30 File Offset: 0x00096C30
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(int id, GetQueryObjectParam pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, ptr, GL.EntryPoints[189]);
				}
			}

			// Token: 0x06003A2E RID: 14894 RVA: 0x00098A54 File Offset: 0x00096C54
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(int id, GetQueryObjectParam pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, @params, GL.EntryPoints[189]);
			}

			// Token: 0x06003A2F RID: 14895 RVA: 0x00098A6C File Offset: 0x00096C6C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(uint id, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, ptr, GL.EntryPoints[189]);
				}
			}

			// Token: 0x06003A30 RID: 14896 RVA: 0x00098AA4 File Offset: 0x00096CA4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(uint id, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, ptr, GL.EntryPoints[189]);
				}
			}

			// Token: 0x06003A31 RID: 14897 RVA: 0x00098AC8 File Offset: 0x00096CC8
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(uint id, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, @params, GL.EntryPoints[189]);
			}

			// Token: 0x06003A32 RID: 14898 RVA: 0x00098AE0 File Offset: 0x00096CE0
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, ptr, GL.EntryPoints[189]);
				}
			}

			// Token: 0x06003A33 RID: 14899 RVA: 0x00098B18 File Offset: 0x00096D18
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, ptr, GL.EntryPoints[189]);
				}
			}

			// Token: 0x06003A34 RID: 14900 RVA: 0x00098B3C File Offset: 0x00096D3C
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), id, pname, @params, GL.EntryPoints[189]);
			}

			// Token: 0x06003A35 RID: 14901 RVA: 0x00098B54 File Offset: 0x00096D54
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(uint id, All pname, [Out] ulong[] @params)
			{
				fixed (ulong* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt64*), id, pname, ptr, GL.EntryPoints[190]);
				}
			}

			// Token: 0x06003A36 RID: 14902 RVA: 0x00098B8C File Offset: 0x00096D8C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(uint id, All pname, out ulong @params)
			{
				fixed (ulong* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt64*), id, pname, ptr, GL.EntryPoints[190]);
				}
			}

			// Token: 0x06003A37 RID: 14903 RVA: 0x00098BB0 File Offset: 0x00096DB0
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, All pname, [Out] ulong* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt64*), id, pname, @params, GL.EntryPoints[190]);
			}

			// Token: 0x06003A38 RID: 14904 RVA: 0x00098BC8 File Offset: 0x00096DC8
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, [Out] ulong[] @params)
			{
				fixed (ulong* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt64*), id, pname, ptr, GL.EntryPoints[190]);
				}
			}

			// Token: 0x06003A39 RID: 14905 RVA: 0x00098C00 File Offset: 0x00096E00
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, out ulong @params)
			{
				fixed (ulong* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt64*), id, pname, ptr, GL.EntryPoints[190]);
				}
			}

			// Token: 0x06003A3A RID: 14906 RVA: 0x00098C24 File Offset: 0x00096E24
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, [Out] ulong* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt64*), id, pname, @params, GL.EntryPoints[190]);
			}

			// Token: 0x06003A3B RID: 14907 RVA: 0x00098C3C File Offset: 0x00096E3C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetQueryObject(uint id, All pname, [Out] uint[] @params)
			{
				fixed (uint* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt32*), id, pname, ptr, GL.EntryPoints[191]);
				}
			}

			// Token: 0x06003A3C RID: 14908 RVA: 0x00098C74 File Offset: 0x00096E74
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, All pname, out uint @params)
			{
				fixed (uint* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt32*), id, pname, ptr, GL.EntryPoints[191]);
				}
			}

			// Token: 0x06003A3D RID: 14909 RVA: 0x00098C98 File Offset: 0x00096E98
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, All pname, [Out] uint* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32*), id, pname, @params, GL.EntryPoints[191]);
			}

			// Token: 0x06003A3E RID: 14910 RVA: 0x00098CB0 File Offset: 0x00096EB0
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, [Out] uint[] @params)
			{
				fixed (uint* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt32*), id, pname, ptr, GL.EntryPoints[191]);
				}
			}

			// Token: 0x06003A3F RID: 14911 RVA: 0x00098CE8 File Offset: 0x00096EE8
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, out uint @params)
			{
				fixed (uint* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt32*), id, pname, ptr, GL.EntryPoints[191]);
				}
			}

			// Token: 0x06003A40 RID: 14912 RVA: 0x00098D0C File Offset: 0x00096F0C
			[CLSCompliant(false)]
			public unsafe static void GetQueryObject(uint id, GetQueryObjectParam pname, [Out] uint* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32*), id, pname, @params, GL.EntryPoints[191]);
			}

			// Token: 0x06003A41 RID: 14913 RVA: 0x00098D24 File Offset: 0x00096F24
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(int sampler, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, ptr, GL.EntryPoints[193]);
				}
			}

			// Token: 0x06003A42 RID: 14914 RVA: 0x00098D5C File Offset: 0x00096F5C
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(int sampler, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, ptr, GL.EntryPoints[193]);
				}
			}

			// Token: 0x06003A43 RID: 14915 RVA: 0x00098D80 File Offset: 0x00096F80
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(int sampler, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, @params, GL.EntryPoints[193]);
			}

			// Token: 0x06003A44 RID: 14916 RVA: 0x00098D98 File Offset: 0x00096F98
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(uint sampler, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, ptr, GL.EntryPoints[193]);
				}
			}

			// Token: 0x06003A45 RID: 14917 RVA: 0x00098DD0 File Offset: 0x00096FD0
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(uint sampler, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, ptr, GL.EntryPoints[193]);
				}
			}

			// Token: 0x06003A46 RID: 14918 RVA: 0x00098DF4 File Offset: 0x00096FF4
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(uint sampler, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, @params, GL.EntryPoints[193]);
			}

			// Token: 0x06003A47 RID: 14919 RVA: 0x00098E0C File Offset: 0x0009700C
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(uint sampler, All pname, [Out] uint[] @params)
			{
				fixed (uint* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt32*), sampler, pname, ptr, GL.EntryPoints[194]);
				}
			}

			// Token: 0x06003A48 RID: 14920 RVA: 0x00098E44 File Offset: 0x00097044
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(uint sampler, All pname, out uint @params)
			{
				fixed (uint* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt32*), sampler, pname, ptr, GL.EntryPoints[194]);
				}
			}

			// Token: 0x06003A49 RID: 14921 RVA: 0x00098E68 File Offset: 0x00097068
			[CLSCompliant(false)]
			public unsafe static void GetSamplerParameterI(uint sampler, All pname, [Out] uint* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32*), sampler, pname, @params, GL.EntryPoints[194]);
			}

			// Token: 0x06003A4A RID: 14922 RVA: 0x00098E80 File Offset: 0x00097080
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetTexParameterI(All target, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[202]);
				}
			}

			// Token: 0x06003A4B RID: 14923 RVA: 0x00098EB8 File Offset: 0x000970B8
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterI(All target, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[202]);
				}
			}

			// Token: 0x06003A4C RID: 14924 RVA: 0x00098EDC File Offset: 0x000970DC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetTexParameterI(All target, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[202]);
			}

			// Token: 0x06003A4D RID: 14925 RVA: 0x00098EF4 File Offset: 0x000970F4
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterI(TextureTarget target, GetTextureParameter pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[202]);
				}
			}

			// Token: 0x06003A4E RID: 14926 RVA: 0x00098F2C File Offset: 0x0009712C
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterI(TextureTarget target, GetTextureParameter pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[202]);
				}
			}

			// Token: 0x06003A4F RID: 14927 RVA: 0x00098F50 File Offset: 0x00097150
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterI(TextureTarget target, GetTextureParameter pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[202]);
			}

			// Token: 0x06003A50 RID: 14928 RVA: 0x00098F68 File Offset: 0x00097168
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetTexParameterI(All target, All pname, [Out] uint[] @params)
			{
				fixed (uint* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, ptr, GL.EntryPoints[203]);
				}
			}

			// Token: 0x06003A51 RID: 14929 RVA: 0x00098FA0 File Offset: 0x000971A0
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterI(All target, All pname, out uint @params)
			{
				fixed (uint* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, ptr, GL.EntryPoints[203]);
				}
			}

			// Token: 0x06003A52 RID: 14930 RVA: 0x00098FC4 File Offset: 0x000971C4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetTexParameterI(All target, All pname, [Out] uint* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, @params, GL.EntryPoints[203]);
			}

			// Token: 0x06003A53 RID: 14931 RVA: 0x00098FDC File Offset: 0x000971DC
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterI(TextureTarget target, GetTextureParameter pname, [Out] uint[] @params)
			{
				fixed (uint* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, ptr, GL.EntryPoints[203]);
				}
			}

			// Token: 0x06003A54 RID: 14932 RVA: 0x00099014 File Offset: 0x00097214
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterI(TextureTarget target, GetTextureParameter pname, out uint @params)
			{
				fixed (uint* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, ptr, GL.EntryPoints[203]);
				}
			}

			// Token: 0x06003A55 RID: 14933 RVA: 0x00099038 File Offset: 0x00097238
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterI(TextureTarget target, GetTextureParameter pname, [Out] uint* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, @params, GL.EntryPoints[203]);
			}

			// Token: 0x06003A56 RID: 14934 RVA: 0x00099050 File Offset: 0x00097250
			public static void InsertEventMarker(int length, string marker)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(marker);
				calli(System.Void(System.Int32,System.IntPtr), length, intPtr, GL.EntryPoints[213]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003A57 RID: 14935 RVA: 0x0009907C File Offset: 0x0009727C
			[CLSCompliant(false)]
			public static bool IsEnabled(All target, int index)
			{
				return calli(System.Byte(System.Int32,System.UInt32), target, index, GL.EntryPoints[216]);
			}

			// Token: 0x06003A58 RID: 14936 RVA: 0x00099090 File Offset: 0x00097290
			[CLSCompliant(false)]
			public static bool IsEnabled(All target, uint index)
			{
				return calli(System.Byte(System.Int32,System.UInt32), target, index, GL.EntryPoints[216]);
			}

			// Token: 0x06003A59 RID: 14937 RVA: 0x000990A4 File Offset: 0x000972A4
			[CLSCompliant(false)]
			public static bool IsProgramPipeline(int pipeline)
			{
				return calli(System.Byte(System.UInt32), pipeline, GL.EntryPoints[220]);
			}

			// Token: 0x06003A5A RID: 14938 RVA: 0x000990B8 File Offset: 0x000972B8
			[CLSCompliant(false)]
			public static bool IsProgramPipeline(uint pipeline)
			{
				return calli(System.Byte(System.UInt32), pipeline, GL.EntryPoints[220]);
			}

			// Token: 0x06003A5B RID: 14939 RVA: 0x000990CC File Offset: 0x000972CC
			[CLSCompliant(false)]
			public static bool IsQuery(int id)
			{
				return calli(System.Byte(System.UInt32), id, GL.EntryPoints[221]);
			}

			// Token: 0x06003A5C RID: 14940 RVA: 0x000990E0 File Offset: 0x000972E0
			[CLSCompliant(false)]
			public static bool IsQuery(uint id)
			{
				return calli(System.Byte(System.UInt32), id, GL.EntryPoints[221]);
			}

			// Token: 0x06003A5D RID: 14941 RVA: 0x000990F4 File Offset: 0x000972F4
			[CLSCompliant(false)]
			public static void LabelObject(All type, int @object, int length, string label)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), type, @object, length, intPtr, GL.EntryPoints[227]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003A5E RID: 14942 RVA: 0x00099124 File Offset: 0x00097324
			[CLSCompliant(false)]
			public static void LabelObject(All type, uint @object, int length, string label)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), type, @object, length, intPtr, GL.EntryPoints[227]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003A5F RID: 14943 RVA: 0x00099154 File Offset: 0x00097354
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static IntPtr MapBufferRange(All target, IntPtr offset, IntPtr length, int access)
			{
				return calli(System.IntPtr(System.Int32,System.IntPtr,System.IntPtr,System.UInt32), target, offset, length, access, GL.EntryPoints[231]);
			}

			// Token: 0x06003A60 RID: 14944 RVA: 0x0009916C File Offset: 0x0009736C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static IntPtr MapBufferRange(All target, IntPtr offset, IntPtr length, uint access)
			{
				return calli(System.IntPtr(System.Int32,System.IntPtr,System.IntPtr,System.UInt32), target, offset, length, access, GL.EntryPoints[231]);
			}

			// Token: 0x06003A61 RID: 14945 RVA: 0x00099184 File Offset: 0x00097384
			[CLSCompliant(false)]
			public static IntPtr MapBufferRange(BufferTarget target, IntPtr offset, IntPtr length, int access)
			{
				return calli(System.IntPtr(System.Int32,System.IntPtr,System.IntPtr,System.UInt32), target, offset, length, access, GL.EntryPoints[231]);
			}

			// Token: 0x06003A62 RID: 14946 RVA: 0x0009919C File Offset: 0x0009739C
			[CLSCompliant(false)]
			public static IntPtr MapBufferRange(BufferTarget target, IntPtr offset, IntPtr length, uint access)
			{
				return calli(System.IntPtr(System.Int32,System.IntPtr,System.IntPtr,System.UInt32), target, offset, length, access, GL.EntryPoints[231]);
			}

			// Token: 0x06003A63 RID: 14947 RVA: 0x000991B4 File Offset: 0x000973B4
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(All mode, int[] first, int[] count, int primcount)
			{
				fixed (int* ptr = ref (first != null && first.Length != 0) ? ref first[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, ptr2, ptr3, primcount, GL.EntryPoints[233]);
					}
				}
			}

			// Token: 0x06003A64 RID: 14948 RVA: 0x00099200 File Offset: 0x00097400
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawArrays(All mode, ref int first, ref int count, int primcount)
			{
				fixed (int* ptr = &first)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &count)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, ptr2, ptr3, primcount, GL.EntryPoints[233]);
					}
				}
			}

			// Token: 0x06003A65 RID: 14949 RVA: 0x00099228 File Offset: 0x00097428
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawArrays(All mode, int* first, int* count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, first, count, primcount, GL.EntryPoints[233]);
			}

			// Token: 0x06003A66 RID: 14950 RVA: 0x00099240 File Offset: 0x00097440
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(PrimitiveType mode, int[] first, int[] count, int primcount)
			{
				fixed (int* ptr = ref (first != null && first.Length != 0) ? ref first[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, ptr2, ptr3, primcount, GL.EntryPoints[233]);
					}
				}
			}

			// Token: 0x06003A67 RID: 14951 RVA: 0x0009928C File Offset: 0x0009748C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(PrimitiveType mode, ref int first, ref int count, int primcount)
			{
				fixed (int* ptr = &first)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &count)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, ptr2, ptr3, primcount, GL.EntryPoints[233]);
					}
				}
			}

			// Token: 0x06003A68 RID: 14952 RVA: 0x000992B4 File Offset: 0x000974B4
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(PrimitiveType mode, int* first, int* count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, first, count, primcount, GL.EntryPoints[233]);
			}

			// Token: 0x06003A69 RID: 14953 RVA: 0x000992CC File Offset: 0x000974CC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(All mode, int[] count, All type, IntPtr indices, int primcount)
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr, type, indices, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A6A RID: 14954 RVA: 0x00099304 File Offset: 0x00097504
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, int[] count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A6B RID: 14955 RVA: 0x00099354 File Offset: 0x00097554
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, int[] count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A6C RID: 14956 RVA: 0x000993A8 File Offset: 0x000975A8
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, int[] count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A6D RID: 14957 RVA: 0x000993FC File Offset: 0x000975FC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, int[] count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A6E RID: 14958 RVA: 0x00099438 File Offset: 0x00097638
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(All mode, ref int count, All type, IntPtr indices, int primcount)
			{
				fixed (int* ptr = &count)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr, type, indices, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A6F RID: 14959 RVA: 0x00099460 File Offset: 0x00097660
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, ref int count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A70 RID: 14960 RVA: 0x0009949C File Offset: 0x0009769C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, ref int count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A71 RID: 14961 RVA: 0x000994DC File Offset: 0x000976DC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, ref int count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A72 RID: 14962 RVA: 0x0009951C File Offset: 0x0009771C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, ref int count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A73 RID: 14963 RVA: 0x00099548 File Offset: 0x00097748
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(All mode, int* count, All type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[234]);
			}

			// Token: 0x06003A74 RID: 14964 RVA: 0x00099560 File Offset: 0x00097760
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, int* count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A75 RID: 14965 RVA: 0x00099598 File Offset: 0x00097798
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, int* count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A76 RID: 14966 RVA: 0x000995D4 File Offset: 0x000977D4
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, int* count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A77 RID: 14967 RVA: 0x00099614 File Offset: 0x00097814
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, int* count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A78 RID: 14968 RVA: 0x0009963C File Offset: 0x0009783C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(PrimitiveType mode, int[] count, DrawElementsType type, IntPtr indices, int primcount)
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr, type, indices, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A79 RID: 14969 RVA: 0x00099674 File Offset: 0x00097874
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int[] count, DrawElementsType type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A7A RID: 14970 RVA: 0x000996C4 File Offset: 0x000978C4
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int[] count, DrawElementsType type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A7B RID: 14971 RVA: 0x00099718 File Offset: 0x00097918
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int[] count, DrawElementsType type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A7C RID: 14972 RVA: 0x0009976C File Offset: 0x0009796C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int[] count, DrawElementsType type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A7D RID: 14973 RVA: 0x000997A8 File Offset: 0x000979A8
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(PrimitiveType mode, ref int count, DrawElementsType type, IntPtr indices, int primcount)
			{
				fixed (int* ptr = &count)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr, type, indices, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A7E RID: 14974 RVA: 0x000997D0 File Offset: 0x000979D0
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, ref int count, DrawElementsType type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A7F RID: 14975 RVA: 0x0009980C File Offset: 0x00097A0C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, ref int count, DrawElementsType type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A80 RID: 14976 RVA: 0x0009984C File Offset: 0x00097A4C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, ref int count, DrawElementsType type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A81 RID: 14977 RVA: 0x0009988C File Offset: 0x00097A8C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, ref int count, DrawElementsType type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[234]);
					}
				}
			}

			// Token: 0x06003A82 RID: 14978 RVA: 0x000998B8 File Offset: 0x00097AB8
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(PrimitiveType mode, int* count, DrawElementsType type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[234]);
			}

			// Token: 0x06003A83 RID: 14979 RVA: 0x000998D0 File Offset: 0x00097AD0
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int* count, DrawElementsType type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A84 RID: 14980 RVA: 0x00099908 File Offset: 0x00097B08
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int* count, DrawElementsType type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A85 RID: 14981 RVA: 0x00099944 File Offset: 0x00097B44
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int* count, DrawElementsType type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A86 RID: 14982 RVA: 0x00099984 File Offset: 0x00097B84
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int* count, DrawElementsType type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[234]);
				}
			}

			// Token: 0x06003A87 RID: 14983 RVA: 0x000999AC File Offset: 0x00097BAC
			public static void PatchParameter(All pname, int value)
			{
				calli(System.Void(System.Int32,System.Int32), pname, value, GL.EntryPoints[239]);
			}

			// Token: 0x06003A88 RID: 14984 RVA: 0x000999C0 File Offset: 0x00097BC0
			public static void PopGroupMarker()
			{
				calli(System.Void(), GL.EntryPoints[244]);
			}

			// Token: 0x06003A89 RID: 14985 RVA: 0x000999D4 File Offset: 0x00097BD4
			public static void PrimitiveBoundingBox(float minX, float minY, float minZ, float minW, float maxX, float maxY, float maxZ, float maxW)
			{
				calli(System.Void(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), minX, minY, minZ, minW, maxX, maxY, maxZ, maxW, GL.EntryPoints[245]);
			}

			// Token: 0x06003A8A RID: 14986 RVA: 0x00099A00 File Offset: 0x00097C00
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static void ProgramParameter(int program, All pname, int value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), program, pname, value, GL.EntryPoints[247]);
			}

			// Token: 0x06003A8B RID: 14987 RVA: 0x00099A18 File Offset: 0x00097C18
			[CLSCompliant(false)]
			public static void ProgramParameter(int program, ProgramParameterName pname, int value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), program, pname, value, GL.EntryPoints[247]);
			}

			// Token: 0x06003A8C RID: 14988 RVA: 0x00099A30 File Offset: 0x00097C30
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void ProgramParameter(uint program, All pname, int value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), program, pname, value, GL.EntryPoints[247]);
			}

			// Token: 0x06003A8D RID: 14989 RVA: 0x00099A48 File Offset: 0x00097C48
			[CLSCompliant(false)]
			public static void ProgramParameter(uint program, ProgramParameterName pname, int value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), program, pname, value, GL.EntryPoints[247]);
			}

			// Token: 0x06003A8E RID: 14990 RVA: 0x00099A60 File Offset: 0x00097C60
			[CLSCompliant(false)]
			public static void ProgramUniform1(int program, int location, float v0)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single), program, location, v0, GL.EntryPoints[248]);
			}

			// Token: 0x06003A8F RID: 14991 RVA: 0x00099A78 File Offset: 0x00097C78
			[CLSCompliant(false)]
			public static void ProgramUniform1(uint program, int location, float v0)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single), program, location, v0, GL.EntryPoints[248]);
			}

			// Token: 0x06003A90 RID: 14992 RVA: 0x00099A90 File Offset: 0x00097C90
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(int program, int location, int count, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[249]);
				}
			}

			// Token: 0x06003A91 RID: 14993 RVA: 0x00099AC8 File Offset: 0x00097CC8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(int program, int location, int count, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[249]);
				}
			}

			// Token: 0x06003A92 RID: 14994 RVA: 0x00099AEC File Offset: 0x00097CEC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(int program, int location, int count, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, value, GL.EntryPoints[249]);
			}

			// Token: 0x06003A93 RID: 14995 RVA: 0x00099B04 File Offset: 0x00097D04
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[249]);
				}
			}

			// Token: 0x06003A94 RID: 14996 RVA: 0x00099B3C File Offset: 0x00097D3C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[249]);
				}
			}

			// Token: 0x06003A95 RID: 14997 RVA: 0x00099B60 File Offset: 0x00097D60
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, value, GL.EntryPoints[249]);
			}

			// Token: 0x06003A96 RID: 14998 RVA: 0x00099B78 File Offset: 0x00097D78
			[CLSCompliant(false)]
			public static void ProgramUniform1(int program, int location, int v0)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), program, location, v0, GL.EntryPoints[250]);
			}

			// Token: 0x06003A97 RID: 14999 RVA: 0x00099B90 File Offset: 0x00097D90
			[CLSCompliant(false)]
			public static void ProgramUniform1(uint program, int location, int v0)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32), program, location, v0, GL.EntryPoints[250]);
			}

			// Token: 0x06003A98 RID: 15000 RVA: 0x00099BA8 File Offset: 0x00097DA8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(int program, int location, int count, int[] value)
			{
				fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[251]);
				}
			}

			// Token: 0x06003A99 RID: 15001 RVA: 0x00099BE0 File Offset: 0x00097DE0
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(int program, int location, int count, ref int value)
			{
				fixed (int* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[251]);
				}
			}

			// Token: 0x06003A9A RID: 15002 RVA: 0x00099C04 File Offset: 0x00097E04
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(int program, int location, int count, int* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, value, GL.EntryPoints[251]);
			}

			// Token: 0x06003A9B RID: 15003 RVA: 0x00099C1C File Offset: 0x00097E1C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, int[] value)
			{
				fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[251]);
				}
			}

			// Token: 0x06003A9C RID: 15004 RVA: 0x00099C54 File Offset: 0x00097E54
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, ref int value)
			{
				fixed (int* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[251]);
				}
			}

			// Token: 0x06003A9D RID: 15005 RVA: 0x00099C78 File Offset: 0x00097E78
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, int* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, value, GL.EntryPoints[251]);
			}

			// Token: 0x06003A9E RID: 15006 RVA: 0x00099C90 File Offset: 0x00097E90
			[CLSCompliant(false)]
			public static void ProgramUniform1(uint program, int location, uint v0)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32), program, location, v0, GL.EntryPoints[252]);
			}

			// Token: 0x06003A9F RID: 15007 RVA: 0x00099CA8 File Offset: 0x00097EA8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, uint[] value)
			{
				fixed (uint* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, ptr, GL.EntryPoints[253]);
				}
			}

			// Token: 0x06003AA0 RID: 15008 RVA: 0x00099CE0 File Offset: 0x00097EE0
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, ref uint value)
			{
				fixed (uint* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, ptr, GL.EntryPoints[253]);
				}
			}

			// Token: 0x06003AA1 RID: 15009 RVA: 0x00099D04 File Offset: 0x00097F04
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform1(uint program, int location, int count, uint* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, value, GL.EntryPoints[253]);
			}

			// Token: 0x06003AA2 RID: 15010 RVA: 0x00099D1C File Offset: 0x00097F1C
			[CLSCompliant(false)]
			public static void ProgramUniform2(int program, int location, float v0, float v1)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single,System.Single), program, location, v0, v1, GL.EntryPoints[254]);
			}

			// Token: 0x06003AA3 RID: 15011 RVA: 0x00099D34 File Offset: 0x00097F34
			[CLSCompliant(false)]
			public static void ProgramUniform2(uint program, int location, float v0, float v1)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single,System.Single), program, location, v0, v1, GL.EntryPoints[254]);
			}

			// Token: 0x06003AA4 RID: 15012 RVA: 0x00099D4C File Offset: 0x00097F4C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(int program, int location, int count, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[255]);
				}
			}

			// Token: 0x06003AA5 RID: 15013 RVA: 0x00099D84 File Offset: 0x00097F84
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(int program, int location, int count, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[255]);
				}
			}

			// Token: 0x06003AA6 RID: 15014 RVA: 0x00099DA8 File Offset: 0x00097FA8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(int program, int location, int count, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, value, GL.EntryPoints[255]);
			}

			// Token: 0x06003AA7 RID: 15015 RVA: 0x00099DC0 File Offset: 0x00097FC0
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(uint program, int location, int count, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[255]);
				}
			}

			// Token: 0x06003AA8 RID: 15016 RVA: 0x00099DF8 File Offset: 0x00097FF8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(uint program, int location, int count, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[255]);
				}
			}

			// Token: 0x06003AA9 RID: 15017 RVA: 0x00099E1C File Offset: 0x0009801C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(uint program, int location, int count, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, value, GL.EntryPoints[255]);
			}

			// Token: 0x06003AAA RID: 15018 RVA: 0x00099E34 File Offset: 0x00098034
			[CLSCompliant(false)]
			public static void ProgramUniform2(int program, int location, int v0, int v1)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32), program, location, v0, v1, GL.EntryPoints[256]);
			}

			// Token: 0x06003AAB RID: 15019 RVA: 0x00099E4C File Offset: 0x0009804C
			[CLSCompliant(false)]
			public static void ProgramUniform2(uint program, int location, int v0, int v1)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32), program, location, v0, v1, GL.EntryPoints[256]);
			}

			// Token: 0x06003AAC RID: 15020 RVA: 0x00099E64 File Offset: 0x00098064
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(int program, int location, int count, int[] value)
			{
				fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[257]);
				}
			}

			// Token: 0x06003AAD RID: 15021 RVA: 0x00099E9C File Offset: 0x0009809C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(int program, int location, int count, int* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, value, GL.EntryPoints[257]);
			}

			// Token: 0x06003AAE RID: 15022 RVA: 0x00099EB4 File Offset: 0x000980B4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(uint program, int location, int count, int[] value)
			{
				fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[257]);
				}
			}

			// Token: 0x06003AAF RID: 15023 RVA: 0x00099EEC File Offset: 0x000980EC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(uint program, int location, int count, int* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, value, GL.EntryPoints[257]);
			}

			// Token: 0x06003AB0 RID: 15024 RVA: 0x00099F04 File Offset: 0x00098104
			[CLSCompliant(false)]
			public static void ProgramUniform2(uint program, int location, uint v0, uint v1)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32,System.UInt32), program, location, v0, v1, GL.EntryPoints[258]);
			}

			// Token: 0x06003AB1 RID: 15025 RVA: 0x00099F1C File Offset: 0x0009811C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(uint program, int location, int count, uint[] value)
			{
				fixed (uint* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, ptr, GL.EntryPoints[259]);
				}
			}

			// Token: 0x06003AB2 RID: 15026 RVA: 0x00099F54 File Offset: 0x00098154
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(uint program, int location, int count, ref uint value)
			{
				fixed (uint* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, ptr, GL.EntryPoints[259]);
				}
			}

			// Token: 0x06003AB3 RID: 15027 RVA: 0x00099F78 File Offset: 0x00098178
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform2(uint program, int location, int count, uint* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, value, GL.EntryPoints[259]);
			}

			// Token: 0x06003AB4 RID: 15028 RVA: 0x00099F90 File Offset: 0x00098190
			[CLSCompliant(false)]
			public static void ProgramUniform3(int program, int location, float v0, float v1, float v2)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single,System.Single,System.Single), program, location, v0, v1, v2, GL.EntryPoints[260]);
			}

			// Token: 0x06003AB5 RID: 15029 RVA: 0x00099FA8 File Offset: 0x000981A8
			[CLSCompliant(false)]
			public static void ProgramUniform3(uint program, int location, float v0, float v1, float v2)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single,System.Single,System.Single), program, location, v0, v1, v2, GL.EntryPoints[260]);
			}

			// Token: 0x06003AB6 RID: 15030 RVA: 0x00099FC0 File Offset: 0x000981C0
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(int program, int location, int count, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[261]);
				}
			}

			// Token: 0x06003AB7 RID: 15031 RVA: 0x00099FF8 File Offset: 0x000981F8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(int program, int location, int count, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[261]);
				}
			}

			// Token: 0x06003AB8 RID: 15032 RVA: 0x0009A01C File Offset: 0x0009821C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(int program, int location, int count, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, value, GL.EntryPoints[261]);
			}

			// Token: 0x06003AB9 RID: 15033 RVA: 0x0009A034 File Offset: 0x00098234
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[261]);
				}
			}

			// Token: 0x06003ABA RID: 15034 RVA: 0x0009A06C File Offset: 0x0009826C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[261]);
				}
			}

			// Token: 0x06003ABB RID: 15035 RVA: 0x0009A090 File Offset: 0x00098290
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, value, GL.EntryPoints[261]);
			}

			// Token: 0x06003ABC RID: 15036 RVA: 0x0009A0A8 File Offset: 0x000982A8
			[CLSCompliant(false)]
			public static void ProgramUniform3(int program, int location, int v0, int v1, int v2)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32), program, location, v0, v1, v2, GL.EntryPoints[262]);
			}

			// Token: 0x06003ABD RID: 15037 RVA: 0x0009A0C0 File Offset: 0x000982C0
			[CLSCompliant(false)]
			public static void ProgramUniform3(uint program, int location, int v0, int v1, int v2)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32), program, location, v0, v1, v2, GL.EntryPoints[262]);
			}

			// Token: 0x06003ABE RID: 15038 RVA: 0x0009A0D8 File Offset: 0x000982D8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(int program, int location, int count, int[] value)
			{
				fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[263]);
				}
			}

			// Token: 0x06003ABF RID: 15039 RVA: 0x0009A110 File Offset: 0x00098310
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(int program, int location, int count, ref int value)
			{
				fixed (int* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[263]);
				}
			}

			// Token: 0x06003AC0 RID: 15040 RVA: 0x0009A134 File Offset: 0x00098334
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(int program, int location, int count, int* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, value, GL.EntryPoints[263]);
			}

			// Token: 0x06003AC1 RID: 15041 RVA: 0x0009A14C File Offset: 0x0009834C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, int[] value)
			{
				fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[263]);
				}
			}

			// Token: 0x06003AC2 RID: 15042 RVA: 0x0009A184 File Offset: 0x00098384
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, ref int value)
			{
				fixed (int* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[263]);
				}
			}

			// Token: 0x06003AC3 RID: 15043 RVA: 0x0009A1A8 File Offset: 0x000983A8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, int* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, value, GL.EntryPoints[263]);
			}

			// Token: 0x06003AC4 RID: 15044 RVA: 0x0009A1C0 File Offset: 0x000983C0
			[CLSCompliant(false)]
			public static void ProgramUniform3(uint program, int location, uint v0, uint v1, uint v2)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32,System.UInt32,System.UInt32), program, location, v0, v1, v2, GL.EntryPoints[264]);
			}

			// Token: 0x06003AC5 RID: 15045 RVA: 0x0009A1D8 File Offset: 0x000983D8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, uint[] value)
			{
				fixed (uint* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, ptr, GL.EntryPoints[265]);
				}
			}

			// Token: 0x06003AC6 RID: 15046 RVA: 0x0009A210 File Offset: 0x00098410
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, ref uint value)
			{
				fixed (uint* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, ptr, GL.EntryPoints[265]);
				}
			}

			// Token: 0x06003AC7 RID: 15047 RVA: 0x0009A234 File Offset: 0x00098434
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform3(uint program, int location, int count, uint* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, value, GL.EntryPoints[265]);
			}

			// Token: 0x06003AC8 RID: 15048 RVA: 0x0009A24C File Offset: 0x0009844C
			[CLSCompliant(false)]
			public static void ProgramUniform4(int program, int location, float v0, float v1, float v2, float v3)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single,System.Single,System.Single,System.Single), program, location, v0, v1, v2, v3, GL.EntryPoints[266]);
			}

			// Token: 0x06003AC9 RID: 15049 RVA: 0x0009A268 File Offset: 0x00098468
			[CLSCompliant(false)]
			public static void ProgramUniform4(uint program, int location, float v0, float v1, float v2, float v3)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Single,System.Single,System.Single,System.Single), program, location, v0, v1, v2, v3, GL.EntryPoints[266]);
			}

			// Token: 0x06003ACA RID: 15050 RVA: 0x0009A284 File Offset: 0x00098484
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(int program, int location, int count, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[267]);
				}
			}

			// Token: 0x06003ACB RID: 15051 RVA: 0x0009A2BC File Offset: 0x000984BC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(int program, int location, int count, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[267]);
				}
			}

			// Token: 0x06003ACC RID: 15052 RVA: 0x0009A2E0 File Offset: 0x000984E0
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(int program, int location, int count, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, value, GL.EntryPoints[267]);
			}

			// Token: 0x06003ACD RID: 15053 RVA: 0x0009A2F8 File Offset: 0x000984F8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[267]);
				}
			}

			// Token: 0x06003ACE RID: 15054 RVA: 0x0009A330 File Offset: 0x00098530
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, ptr, GL.EntryPoints[267]);
				}
			}

			// Token: 0x06003ACF RID: 15055 RVA: 0x0009A354 File Offset: 0x00098554
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, count, value, GL.EntryPoints[267]);
			}

			// Token: 0x06003AD0 RID: 15056 RVA: 0x0009A36C File Offset: 0x0009856C
			[CLSCompliant(false)]
			public static void ProgramUniform4(int program, int location, int v0, int v1, int v2, int v3)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), program, location, v0, v1, v2, v3, GL.EntryPoints[268]);
			}

			// Token: 0x06003AD1 RID: 15057 RVA: 0x0009A388 File Offset: 0x00098588
			[CLSCompliant(false)]
			public static void ProgramUniform4(uint program, int location, int v0, int v1, int v2, int v3)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), program, location, v0, v1, v2, v3, GL.EntryPoints[268]);
			}

			// Token: 0x06003AD2 RID: 15058 RVA: 0x0009A3A4 File Offset: 0x000985A4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(int program, int location, int count, int[] value)
			{
				fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[269]);
				}
			}

			// Token: 0x06003AD3 RID: 15059 RVA: 0x0009A3DC File Offset: 0x000985DC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(int program, int location, int count, ref int value)
			{
				fixed (int* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[269]);
				}
			}

			// Token: 0x06003AD4 RID: 15060 RVA: 0x0009A400 File Offset: 0x00098600
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(int program, int location, int count, int* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, value, GL.EntryPoints[269]);
			}

			// Token: 0x06003AD5 RID: 15061 RVA: 0x0009A418 File Offset: 0x00098618
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, int[] value)
			{
				fixed (int* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[269]);
				}
			}

			// Token: 0x06003AD6 RID: 15062 RVA: 0x0009A450 File Offset: 0x00098650
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, ref int value)
			{
				fixed (int* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, ptr, GL.EntryPoints[269]);
				}
			}

			// Token: 0x06003AD7 RID: 15063 RVA: 0x0009A474 File Offset: 0x00098674
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, int* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, count, value, GL.EntryPoints[269]);
			}

			// Token: 0x06003AD8 RID: 15064 RVA: 0x0009A48C File Offset: 0x0009868C
			[CLSCompliant(false)]
			public static void ProgramUniform4(uint program, int location, uint v0, uint v1, uint v2, uint v3)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32,System.UInt32,System.UInt32,System.UInt32), program, location, v0, v1, v2, v3, GL.EntryPoints[270]);
			}

			// Token: 0x06003AD9 RID: 15065 RVA: 0x0009A4A8 File Offset: 0x000986A8
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, uint[] value)
			{
				fixed (uint* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, ptr, GL.EntryPoints[271]);
				}
			}

			// Token: 0x06003ADA RID: 15066 RVA: 0x0009A4E0 File Offset: 0x000986E0
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, ref uint value)
			{
				fixed (uint* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, ptr, GL.EntryPoints[271]);
				}
			}

			// Token: 0x06003ADB RID: 15067 RVA: 0x0009A504 File Offset: 0x00098704
			[CLSCompliant(false)]
			public unsafe static void ProgramUniform4(uint program, int location, int count, uint* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.UInt32*), program, location, count, value, GL.EntryPoints[271]);
			}

			// Token: 0x06003ADC RID: 15068 RVA: 0x0009A51C File Offset: 0x0009871C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[272]);
				}
			}

			// Token: 0x06003ADD RID: 15069 RVA: 0x0009A558 File Offset: 0x00098758
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[272]);
				}
			}

			// Token: 0x06003ADE RID: 15070 RVA: 0x0009A580 File Offset: 0x00098780
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[272]);
			}

			// Token: 0x06003ADF RID: 15071 RVA: 0x0009A598 File Offset: 0x00098798
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[272]);
				}
			}

			// Token: 0x06003AE0 RID: 15072 RVA: 0x0009A5D4 File Offset: 0x000987D4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[272]);
				}
			}

			// Token: 0x06003AE1 RID: 15073 RVA: 0x0009A5FC File Offset: 0x000987FC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[272]);
			}

			// Token: 0x06003AE2 RID: 15074 RVA: 0x0009A614 File Offset: 0x00098814
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x3(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[273]);
				}
			}

			// Token: 0x06003AE3 RID: 15075 RVA: 0x0009A650 File Offset: 0x00098850
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x3(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[273]);
				}
			}

			// Token: 0x06003AE4 RID: 15076 RVA: 0x0009A678 File Offset: 0x00098878
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x3(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[273]);
			}

			// Token: 0x06003AE5 RID: 15077 RVA: 0x0009A690 File Offset: 0x00098890
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x3(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[273]);
				}
			}

			// Token: 0x06003AE6 RID: 15078 RVA: 0x0009A6CC File Offset: 0x000988CC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x3(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[273]);
				}
			}

			// Token: 0x06003AE7 RID: 15079 RVA: 0x0009A6F4 File Offset: 0x000988F4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x3(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[273]);
			}

			// Token: 0x06003AE8 RID: 15080 RVA: 0x0009A70C File Offset: 0x0009890C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x4(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[274]);
				}
			}

			// Token: 0x06003AE9 RID: 15081 RVA: 0x0009A748 File Offset: 0x00098948
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x4(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[274]);
				}
			}

			// Token: 0x06003AEA RID: 15082 RVA: 0x0009A770 File Offset: 0x00098970
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x4(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[274]);
			}

			// Token: 0x06003AEB RID: 15083 RVA: 0x0009A788 File Offset: 0x00098988
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x4(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[274]);
				}
			}

			// Token: 0x06003AEC RID: 15084 RVA: 0x0009A7C4 File Offset: 0x000989C4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x4(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[274]);
				}
			}

			// Token: 0x06003AED RID: 15085 RVA: 0x0009A7EC File Offset: 0x000989EC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix2x4(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[274]);
			}

			// Token: 0x06003AEE RID: 15086 RVA: 0x0009A804 File Offset: 0x00098A04
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[275]);
				}
			}

			// Token: 0x06003AEF RID: 15087 RVA: 0x0009A840 File Offset: 0x00098A40
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[275]);
				}
			}

			// Token: 0x06003AF0 RID: 15088 RVA: 0x0009A868 File Offset: 0x00098A68
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[275]);
			}

			// Token: 0x06003AF1 RID: 15089 RVA: 0x0009A880 File Offset: 0x00098A80
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[275]);
				}
			}

			// Token: 0x06003AF2 RID: 15090 RVA: 0x0009A8BC File Offset: 0x00098ABC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[275]);
				}
			}

			// Token: 0x06003AF3 RID: 15091 RVA: 0x0009A8E4 File Offset: 0x00098AE4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[275]);
			}

			// Token: 0x06003AF4 RID: 15092 RVA: 0x0009A8FC File Offset: 0x00098AFC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x2(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[276]);
				}
			}

			// Token: 0x06003AF5 RID: 15093 RVA: 0x0009A938 File Offset: 0x00098B38
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x2(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[276]);
				}
			}

			// Token: 0x06003AF6 RID: 15094 RVA: 0x0009A960 File Offset: 0x00098B60
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x2(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[276]);
			}

			// Token: 0x06003AF7 RID: 15095 RVA: 0x0009A978 File Offset: 0x00098B78
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x2(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[276]);
				}
			}

			// Token: 0x06003AF8 RID: 15096 RVA: 0x0009A9B4 File Offset: 0x00098BB4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x2(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[276]);
				}
			}

			// Token: 0x06003AF9 RID: 15097 RVA: 0x0009A9DC File Offset: 0x00098BDC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x2(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[276]);
			}

			// Token: 0x06003AFA RID: 15098 RVA: 0x0009A9F4 File Offset: 0x00098BF4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x4(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[277]);
				}
			}

			// Token: 0x06003AFB RID: 15099 RVA: 0x0009AA30 File Offset: 0x00098C30
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x4(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[277]);
				}
			}

			// Token: 0x06003AFC RID: 15100 RVA: 0x0009AA58 File Offset: 0x00098C58
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x4(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[277]);
			}

			// Token: 0x06003AFD RID: 15101 RVA: 0x0009AA70 File Offset: 0x00098C70
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x4(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[277]);
				}
			}

			// Token: 0x06003AFE RID: 15102 RVA: 0x0009AAAC File Offset: 0x00098CAC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x4(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[277]);
				}
			}

			// Token: 0x06003AFF RID: 15103 RVA: 0x0009AAD4 File Offset: 0x00098CD4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix3x4(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[277]);
			}

			// Token: 0x06003B00 RID: 15104 RVA: 0x0009AAEC File Offset: 0x00098CEC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[278]);
				}
			}

			// Token: 0x06003B01 RID: 15105 RVA: 0x0009AB28 File Offset: 0x00098D28
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[278]);
				}
			}

			// Token: 0x06003B02 RID: 15106 RVA: 0x0009AB50 File Offset: 0x00098D50
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[278]);
			}

			// Token: 0x06003B03 RID: 15107 RVA: 0x0009AB68 File Offset: 0x00098D68
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[278]);
				}
			}

			// Token: 0x06003B04 RID: 15108 RVA: 0x0009ABA4 File Offset: 0x00098DA4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[278]);
				}
			}

			// Token: 0x06003B05 RID: 15109 RVA: 0x0009ABCC File Offset: 0x00098DCC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[278]);
			}

			// Token: 0x06003B06 RID: 15110 RVA: 0x0009ABE4 File Offset: 0x00098DE4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x2(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[279]);
				}
			}

			// Token: 0x06003B07 RID: 15111 RVA: 0x0009AC20 File Offset: 0x00098E20
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x2(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[279]);
				}
			}

			// Token: 0x06003B08 RID: 15112 RVA: 0x0009AC48 File Offset: 0x00098E48
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x2(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[279]);
			}

			// Token: 0x06003B09 RID: 15113 RVA: 0x0009AC60 File Offset: 0x00098E60
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x2(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[279]);
				}
			}

			// Token: 0x06003B0A RID: 15114 RVA: 0x0009AC9C File Offset: 0x00098E9C
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x2(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[279]);
				}
			}

			// Token: 0x06003B0B RID: 15115 RVA: 0x0009ACC4 File Offset: 0x00098EC4
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x2(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[279]);
			}

			// Token: 0x06003B0C RID: 15116 RVA: 0x0009ACDC File Offset: 0x00098EDC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x3(int program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[280]);
				}
			}

			// Token: 0x06003B0D RID: 15117 RVA: 0x0009AD18 File Offset: 0x00098F18
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x3(int program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[280]);
				}
			}

			// Token: 0x06003B0E RID: 15118 RVA: 0x0009AD40 File Offset: 0x00098F40
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x3(int program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[280]);
			}

			// Token: 0x06003B0F RID: 15119 RVA: 0x0009AD58 File Offset: 0x00098F58
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x3(uint program, int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[280]);
				}
			}

			// Token: 0x06003B10 RID: 15120 RVA: 0x0009AD94 File Offset: 0x00098F94
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x3(uint program, int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, ptr, GL.EntryPoints[280]);
				}
			}

			// Token: 0x06003B11 RID: 15121 RVA: 0x0009ADBC File Offset: 0x00098FBC
			[CLSCompliant(false)]
			public unsafe static void ProgramUniformMatrix4x3(uint program, int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Boolean,System.Single*), program, location, count, transpose, value, GL.EntryPoints[280]);
			}

			// Token: 0x06003B12 RID: 15122 RVA: 0x0009ADD4 File Offset: 0x00098FD4
			public static void PushGroupMarker(int length, string marker)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(marker);
				calli(System.Void(System.Int32,System.IntPtr), length, intPtr, GL.EntryPoints[283]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003B13 RID: 15123 RVA: 0x0009AE00 File Offset: 0x00099000
			[CLSCompliant(false)]
			public static void QueryCounter(int id, All target)
			{
				calli(System.Void(System.UInt32,System.Int32), id, target, GL.EntryPoints[284]);
			}

			// Token: 0x06003B14 RID: 15124 RVA: 0x0009AE14 File Offset: 0x00099014
			[CLSCompliant(false)]
			public static void QueryCounter(uint id, All target)
			{
				calli(System.Void(System.UInt32,System.Int32), id, target, GL.EntryPoints[284]);
			}

			// Token: 0x06003B15 RID: 15125 RVA: 0x0009AE28 File Offset: 0x00099028
			public static void ReadBufferIndexed(All src, int index)
			{
				calli(System.Void(System.Int32,System.Int32), src, index, GL.EntryPoints[285]);
			}

			// Token: 0x06003B16 RID: 15126 RVA: 0x0009AE3C File Offset: 0x0009903C
			public static void ReadnPixels(int x, int y, int width, int height, All format, All type, int bufSize, [Out] IntPtr data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, data, GL.EntryPoints[287]);
			}

			// Token: 0x06003B17 RID: 15127 RVA: 0x0009AE68 File Offset: 0x00099068
			[CLSCompliant(false)]
			public unsafe static void ReadnPixels<T7>(int x, int y, int width, int height, All format, All type, int bufSize, [In] [Out] T7[] data) where T7 : struct
			{
				fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, ptr, GL.EntryPoints[287]);
				}
			}

			// Token: 0x06003B18 RID: 15128 RVA: 0x0009AEA8 File Offset: 0x000990A8
			[CLSCompliant(false)]
			public unsafe static void ReadnPixels<T7>(int x, int y, int width, int height, All format, All type, int bufSize, [In] [Out] T7[,] data) where T7 : struct
			{
				fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, ptr, GL.EntryPoints[287]);
				}
			}

			// Token: 0x06003B19 RID: 15129 RVA: 0x0009AEEC File Offset: 0x000990EC
			[CLSCompliant(false)]
			public unsafe static void ReadnPixels<T7>(int x, int y, int width, int height, All format, All type, int bufSize, [In] [Out] T7[,,] data) where T7 : struct
			{
				fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, ptr, GL.EntryPoints[287]);
				}
			}

			// Token: 0x06003B1A RID: 15130 RVA: 0x0009AF34 File Offset: 0x00099134
			public unsafe static void ReadnPixels<T7>(int x, int y, int width, int height, All format, All type, int bufSize, [In] [Out] ref T7 data) where T7 : struct
			{
				fixed (T7* ptr = &data)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, ptr, GL.EntryPoints[287]);
				}
			}

			// Token: 0x06003B1B RID: 15131 RVA: 0x0009AF60 File Offset: 0x00099160
			[Obsolete("Use strongly-typed overload instead")]
			public static void RenderbufferStorageMultisample(All target, int samples, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[293]);
			}

			// Token: 0x06003B1C RID: 15132 RVA: 0x0009AF78 File Offset: 0x00099178
			public static void RenderbufferStorageMultisample(RenderbufferTarget target, int samples, RenderbufferInternalFormat internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[293]);
			}

			// Token: 0x06003B1D RID: 15133 RVA: 0x0009AF90 File Offset: 0x00099190
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(int sampler, All pname, int[] param)
			{
				fixed (int* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, ptr, GL.EntryPoints[298]);
				}
			}

			// Token: 0x06003B1E RID: 15134 RVA: 0x0009AFC8 File Offset: 0x000991C8
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(int sampler, All pname, ref int param)
			{
				fixed (int* ptr = &param)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, ptr, GL.EntryPoints[298]);
				}
			}

			// Token: 0x06003B1F RID: 15135 RVA: 0x0009AFEC File Offset: 0x000991EC
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(int sampler, All pname, int* param)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, param, GL.EntryPoints[298]);
			}

			// Token: 0x06003B20 RID: 15136 RVA: 0x0009B004 File Offset: 0x00099204
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(uint sampler, All pname, int[] param)
			{
				fixed (int* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, ptr, GL.EntryPoints[298]);
				}
			}

			// Token: 0x06003B21 RID: 15137 RVA: 0x0009B03C File Offset: 0x0009923C
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(uint sampler, All pname, ref int param)
			{
				fixed (int* ptr = &param)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, ptr, GL.EntryPoints[298]);
				}
			}

			// Token: 0x06003B22 RID: 15138 RVA: 0x0009B060 File Offset: 0x00099260
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(uint sampler, All pname, int* param)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), sampler, pname, param, GL.EntryPoints[298]);
			}

			// Token: 0x06003B23 RID: 15139 RVA: 0x0009B078 File Offset: 0x00099278
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(uint sampler, All pname, uint[] param)
			{
				fixed (uint* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt32*), sampler, pname, ptr, GL.EntryPoints[299]);
				}
			}

			// Token: 0x06003B24 RID: 15140 RVA: 0x0009B0B0 File Offset: 0x000992B0
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(uint sampler, All pname, ref uint param)
			{
				fixed (uint* ptr = &param)
				{
					calli(System.Void(System.UInt32,System.Int32,System.UInt32*), sampler, pname, ptr, GL.EntryPoints[299]);
				}
			}

			// Token: 0x06003B25 RID: 15141 RVA: 0x0009B0D4 File Offset: 0x000992D4
			[CLSCompliant(false)]
			public unsafe static void SamplerParameterI(uint sampler, All pname, uint* param)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32*), sampler, pname, param, GL.EntryPoints[299]);
			}

			// Token: 0x06003B26 RID: 15142 RVA: 0x0009B0EC File Offset: 0x000992EC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void TexBuffer(All target, All internalformat, int buffer)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32), target, internalformat, buffer, GL.EntryPoints[313]);
			}

			// Token: 0x06003B27 RID: 15143 RVA: 0x0009B104 File Offset: 0x00099304
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void TexBuffer(All target, All internalformat, uint buffer)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32), target, internalformat, buffer, GL.EntryPoints[313]);
			}

			// Token: 0x06003B28 RID: 15144 RVA: 0x0009B11C File Offset: 0x0009931C
			[CLSCompliant(false)]
			public static void TexBuffer(TextureTarget target, All internalformat, int buffer)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32), target, internalformat, buffer, GL.EntryPoints[313]);
			}

			// Token: 0x06003B29 RID: 15145 RVA: 0x0009B134 File Offset: 0x00099334
			[CLSCompliant(false)]
			public static void TexBuffer(TextureTarget target, All internalformat, uint buffer)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32), target, internalformat, buffer, GL.EntryPoints[313]);
			}

			// Token: 0x06003B2A RID: 15146 RVA: 0x0009B14C File Offset: 0x0009934C
			[CLSCompliant(false)]
			public static void TexBufferRange(All target, All internalformat, int buffer, IntPtr offset, IntPtr size)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.IntPtr,System.IntPtr), target, internalformat, buffer, offset, size, GL.EntryPoints[314]);
			}

			// Token: 0x06003B2B RID: 15147 RVA: 0x0009B164 File Offset: 0x00099364
			[CLSCompliant(false)]
			public static void TexBufferRange(All target, All internalformat, uint buffer, IntPtr offset, IntPtr size)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.IntPtr,System.IntPtr), target, internalformat, buffer, offset, size, GL.EntryPoints[314]);
			}

			// Token: 0x06003B2C RID: 15148 RVA: 0x0009B17C File Offset: 0x0009937C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(All target, All pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[320]);
				}
			}

			// Token: 0x06003B2D RID: 15149 RVA: 0x0009B1B4 File Offset: 0x000993B4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexParameterI(All target, All pname, ref int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[320]);
				}
			}

			// Token: 0x06003B2E RID: 15150 RVA: 0x0009B1D8 File Offset: 0x000993D8
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(All target, All pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[320]);
			}

			// Token: 0x06003B2F RID: 15151 RVA: 0x0009B1F0 File Offset: 0x000993F0
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(TextureTarget target, TextureParameterName pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[320]);
				}
			}

			// Token: 0x06003B30 RID: 15152 RVA: 0x0009B228 File Offset: 0x00099428
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(TextureTarget target, TextureParameterName pname, ref int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[320]);
				}
			}

			// Token: 0x06003B31 RID: 15153 RVA: 0x0009B24C File Offset: 0x0009944C
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(TextureTarget target, TextureParameterName pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[320]);
			}

			// Token: 0x06003B32 RID: 15154 RVA: 0x0009B264 File Offset: 0x00099464
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexParameterI(All target, All pname, uint[] @params)
			{
				fixed (uint* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, ptr, GL.EntryPoints[321]);
				}
			}

			// Token: 0x06003B33 RID: 15155 RVA: 0x0009B29C File Offset: 0x0009949C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(All target, All pname, ref uint @params)
			{
				fixed (uint* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, ptr, GL.EntryPoints[321]);
				}
			}

			// Token: 0x06003B34 RID: 15156 RVA: 0x0009B2C0 File Offset: 0x000994C0
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexParameterI(All target, All pname, uint* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, @params, GL.EntryPoints[321]);
			}

			// Token: 0x06003B35 RID: 15157 RVA: 0x0009B2D8 File Offset: 0x000994D8
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(TextureTarget target, TextureParameterName pname, uint[] @params)
			{
				fixed (uint* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, ptr, GL.EntryPoints[321]);
				}
			}

			// Token: 0x06003B36 RID: 15158 RVA: 0x0009B310 File Offset: 0x00099510
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(TextureTarget target, TextureParameterName pname, ref uint @params)
			{
				fixed (uint* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, ptr, GL.EntryPoints[321]);
				}
			}

			// Token: 0x06003B37 RID: 15159 RVA: 0x0009B334 File Offset: 0x00099534
			[CLSCompliant(false)]
			public unsafe static void TexParameterI(TextureTarget target, TextureParameterName pname, uint* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.UInt32*), target, pname, @params, GL.EntryPoints[321]);
			}

			// Token: 0x06003B38 RID: 15160 RVA: 0x0009B34C File Offset: 0x0009954C
			public static void TexStorage1D(All target, int levels, All internalformat, int width)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), target, levels, internalformat, width, GL.EntryPoints[323]);
			}

			// Token: 0x06003B39 RID: 15161 RVA: 0x0009B364 File Offset: 0x00099564
			[Obsolete("Use strongly-typed overload instead")]
			public static void TexStorage2D(All target, int levels, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, levels, internalformat, width, height, GL.EntryPoints[324]);
			}

			// Token: 0x06003B3A RID: 15162 RVA: 0x0009B37C File Offset: 0x0009957C
			public static void TexStorage2D(TextureTarget2d target, int levels, SizedInternalFormat internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, levels, internalformat, width, height, GL.EntryPoints[324]);
			}

			// Token: 0x06003B3B RID: 15163 RVA: 0x0009B394 File Offset: 0x00099594
			[Obsolete("Use strongly-typed overload instead")]
			public static void TexStorage3D(All target, int levels, All internalformat, int width, int height, int depth)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, levels, internalformat, width, height, depth, GL.EntryPoints[325]);
			}

			// Token: 0x06003B3C RID: 15164 RVA: 0x0009B3B0 File Offset: 0x000995B0
			public static void TexStorage3D(TextureTarget3d target, int levels, SizedInternalFormat internalformat, int width, int height, int depth)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, levels, internalformat, width, height, depth, GL.EntryPoints[325]);
			}

			// Token: 0x06003B3D RID: 15165 RVA: 0x0009B3CC File Offset: 0x000995CC
			[CLSCompliant(false)]
			public static void TextureStorage1D(int texture, All target, int levels, All internalformat, int width)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, GL.EntryPoints[329]);
			}

			// Token: 0x06003B3E RID: 15166 RVA: 0x0009B3E4 File Offset: 0x000995E4
			[CLSCompliant(false)]
			public static void TextureStorage1D(uint texture, All target, int levels, All internalformat, int width)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, GL.EntryPoints[329]);
			}

			// Token: 0x06003B3F RID: 15167 RVA: 0x0009B3FC File Offset: 0x000995FC
			[CLSCompliant(false)]
			public static void TextureStorage2D(int texture, All target, int levels, All internalformat, int width, int height)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, height, GL.EntryPoints[330]);
			}

			// Token: 0x06003B40 RID: 15168 RVA: 0x0009B418 File Offset: 0x00099618
			[CLSCompliant(false)]
			public static void TextureStorage2D(uint texture, All target, int levels, All internalformat, int width, int height)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, height, GL.EntryPoints[330]);
			}

			// Token: 0x06003B41 RID: 15169 RVA: 0x0009B434 File Offset: 0x00099634
			[CLSCompliant(false)]
			public static void TextureStorage3D(int texture, All target, int levels, All internalformat, int width, int height, int depth)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, height, depth, GL.EntryPoints[331]);
			}

			// Token: 0x06003B42 RID: 15170 RVA: 0x0009B45C File Offset: 0x0009965C
			[CLSCompliant(false)]
			public static void TextureStorage3D(uint texture, All target, int levels, All internalformat, int width, int height, int depth)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, height, depth, GL.EntryPoints[331]);
			}

			// Token: 0x06003B43 RID: 15171 RVA: 0x0009B484 File Offset: 0x00099684
			[CLSCompliant(false)]
			public static void TextureView(int texture, All target, int origtexture, All internalformat, int minlevel, int numlevels, int minlayer, int numlayers)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32,System.Int32,System.UInt32,System.UInt32,System.UInt32,System.UInt32), texture, target, origtexture, internalformat, minlevel, numlevels, minlayer, numlayers, GL.EntryPoints[332]);
			}

			// Token: 0x06003B44 RID: 15172 RVA: 0x0009B4B0 File Offset: 0x000996B0
			[CLSCompliant(false)]
			public static void TextureView(uint texture, All target, uint origtexture, All internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers)
			{
				calli(System.Void(System.UInt32,System.Int32,System.UInt32,System.Int32,System.UInt32,System.UInt32,System.UInt32,System.UInt32), texture, target, origtexture, internalformat, minlevel, numlevels, minlayer, numlayers, GL.EntryPoints[332]);
			}

			// Token: 0x06003B45 RID: 15173 RVA: 0x0009B4DC File Offset: 0x000996DC
			[CLSCompliant(false)]
			public static void UseProgramStages(int pipeline, int stages, int program)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.UInt32), pipeline, stages, program, GL.EntryPoints[360]);
			}

			// Token: 0x06003B46 RID: 15174 RVA: 0x0009B4F4 File Offset: 0x000996F4
			[CLSCompliant(false)]
			public static void UseProgramStages(uint pipeline, uint stages, uint program)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.UInt32), pipeline, stages, program, GL.EntryPoints[360]);
			}

			// Token: 0x06003B47 RID: 15175 RVA: 0x0009B50C File Offset: 0x0009970C
			[CLSCompliant(false)]
			public static void UseShaderProgram(All type, int program)
			{
				calli(System.Void(System.Int32,System.UInt32), type, program, GL.EntryPoints[361]);
			}

			// Token: 0x06003B48 RID: 15176 RVA: 0x0009B520 File Offset: 0x00099720
			[CLSCompliant(false)]
			public static void UseShaderProgram(All type, uint program)
			{
				calli(System.Void(System.Int32,System.UInt32), type, program, GL.EntryPoints[361]);
			}

			// Token: 0x06003B49 RID: 15177 RVA: 0x0009B534 File Offset: 0x00099734
			[CLSCompliant(false)]
			public static void ValidateProgramPipeline(int pipeline)
			{
				calli(System.Void(System.UInt32), pipeline, GL.EntryPoints[363]);
			}

			// Token: 0x06003B4A RID: 15178 RVA: 0x0009B548 File Offset: 0x00099748
			[CLSCompliant(false)]
			public static void ValidateProgramPipeline(uint pipeline)
			{
				calli(System.Void(System.UInt32), pipeline, GL.EntryPoints[363]);
			}

			// Token: 0x06003B4B RID: 15179 RVA: 0x0009B55C File Offset: 0x0009975C
			[CLSCompliant(false)]
			public static void VertexAttribDivisor(int index, int divisor)
			{
				calli(System.Void(System.UInt32,System.UInt32), index, divisor, GL.EntryPoints[373]);
			}

			// Token: 0x06003B4C RID: 15180 RVA: 0x0009B570 File Offset: 0x00099770
			[CLSCompliant(false)]
			public static void VertexAttribDivisor(uint index, uint divisor)
			{
				calli(System.Void(System.UInt32,System.UInt32), index, divisor, GL.EntryPoints[373]);
			}
		}

		// Token: 0x02000509 RID: 1289
		public static class Img
		{
			// Token: 0x06003B4D RID: 15181 RVA: 0x0009B584 File Offset: 0x00099784
			[CLSCompliant(false)]
			public static void FramebufferTexture2DMultisample(All target, All attachment, All textarget, int texture, int level, int samples)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, samples, GL.EntryPoints[128]);
			}

			// Token: 0x06003B4E RID: 15182 RVA: 0x0009B5A0 File Offset: 0x000997A0
			[CLSCompliant(false)]
			public static void FramebufferTexture2DMultisample(All target, All attachment, All textarget, uint texture, int level, int samples)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, samples, GL.EntryPoints[128]);
			}

			// Token: 0x06003B4F RID: 15183 RVA: 0x0009B5BC File Offset: 0x000997BC
			[Obsolete("Use strongly-typed overload instead")]
			public static void RenderbufferStorageMultisample(All target, int samples, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[294]);
			}

			// Token: 0x06003B50 RID: 15184 RVA: 0x0009B5D4 File Offset: 0x000997D4
			public static void RenderbufferStorageMultisample(RenderbufferTarget target, int samples, RenderbufferInternalFormat internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[294]);
			}
		}

		// Token: 0x0200050A RID: 1290
		public static class Intel
		{
			// Token: 0x06003B51 RID: 15185 RVA: 0x0009B5EC File Offset: 0x000997EC
			[CLSCompliant(false)]
			public static void BeginPerfQuery(int queryHandle)
			{
				calli(System.Void(System.UInt32), queryHandle, GL.EntryPoints[6]);
			}

			// Token: 0x06003B52 RID: 15186 RVA: 0x0009B5FC File Offset: 0x000997FC
			[CLSCompliant(false)]
			public static void BeginPerfQuery(uint queryHandle)
			{
				calli(System.Void(System.UInt32), queryHandle, GL.EntryPoints[6]);
			}

			// Token: 0x06003B53 RID: 15187 RVA: 0x0009B60C File Offset: 0x0009980C
			[CLSCompliant(false)]
			public unsafe static void CreatePerfQuery(int queryId, [Out] int[] queryHandle)
			{
				fixed (int* ptr = ref (queryHandle != null && queryHandle.Length != 0) ? ref queryHandle[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32*), queryId, ptr, GL.EntryPoints[53]);
				}
			}

			// Token: 0x06003B54 RID: 15188 RVA: 0x0009B640 File Offset: 0x00099840
			[CLSCompliant(false)]
			public unsafe static void CreatePerfQuery(int queryId, out int queryHandle)
			{
				fixed (int* ptr = &queryHandle)
				{
					calli(System.Void(System.UInt32,System.UInt32*), queryId, ptr, GL.EntryPoints[53]);
				}
			}

			// Token: 0x06003B55 RID: 15189 RVA: 0x0009B660 File Offset: 0x00099860
			[CLSCompliant(false)]
			public unsafe static void CreatePerfQuery(int queryId, [Out] int* queryHandle)
			{
				calli(System.Void(System.UInt32,System.UInt32*), queryId, queryHandle, GL.EntryPoints[53]);
			}

			// Token: 0x06003B56 RID: 15190 RVA: 0x0009B674 File Offset: 0x00099874
			[CLSCompliant(false)]
			public unsafe static void CreatePerfQuery(uint queryId, [Out] uint[] queryHandle)
			{
				fixed (uint* ptr = ref (queryHandle != null && queryHandle.Length != 0) ? ref queryHandle[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32*), queryId, ptr, GL.EntryPoints[53]);
				}
			}

			// Token: 0x06003B57 RID: 15191 RVA: 0x0009B6A8 File Offset: 0x000998A8
			[CLSCompliant(false)]
			public unsafe static void CreatePerfQuery(uint queryId, out uint queryHandle)
			{
				fixed (uint* ptr = &queryHandle)
				{
					calli(System.Void(System.UInt32,System.UInt32*), queryId, ptr, GL.EntryPoints[53]);
				}
			}

			// Token: 0x06003B58 RID: 15192 RVA: 0x0009B6C8 File Offset: 0x000998C8
			[CLSCompliant(false)]
			public unsafe static void CreatePerfQuery(uint queryId, [Out] uint* queryHandle)
			{
				calli(System.Void(System.UInt32,System.UInt32*), queryId, queryHandle, GL.EntryPoints[53]);
			}

			// Token: 0x06003B59 RID: 15193 RVA: 0x0009B6DC File Offset: 0x000998DC
			[CLSCompliant(false)]
			public static void DeletePerfQuery(int queryHandle)
			{
				calli(System.Void(System.UInt32), queryHandle, GL.EntryPoints[69]);
			}

			// Token: 0x06003B5A RID: 15194 RVA: 0x0009B6EC File Offset: 0x000998EC
			[CLSCompliant(false)]
			public static void DeletePerfQuery(uint queryHandle)
			{
				calli(System.Void(System.UInt32), queryHandle, GL.EntryPoints[69]);
			}

			// Token: 0x06003B5B RID: 15195 RVA: 0x0009B6FC File Offset: 0x000998FC
			[CLSCompliant(false)]
			public static void EndPerfQuery(int queryHandle)
			{
				calli(System.Void(System.UInt32), queryHandle, GL.EntryPoints[105]);
			}

			// Token: 0x06003B5C RID: 15196 RVA: 0x0009B70C File Offset: 0x0009990C
			[CLSCompliant(false)]
			public static void EndPerfQuery(uint queryHandle)
			{
				calli(System.Void(System.UInt32), queryHandle, GL.EntryPoints[105]);
			}

			// Token: 0x06003B5D RID: 15197 RVA: 0x0009B71C File Offset: 0x0009991C
			[CLSCompliant(false)]
			public static int GetFirstPerfQueryI()
			{
				int result;
				calli(System.Void(System.UInt32*), ref result, GL.EntryPoints[155]);
				return result;
			}

			// Token: 0x06003B5E RID: 15198 RVA: 0x0009B73C File Offset: 0x0009993C
			[CLSCompliant(false)]
			public unsafe static void GetFirstPerfQueryI([Out] int[] queryId)
			{
				fixed (int* ptr = ref (queryId != null && queryId.Length != 0) ? ref queryId[0] : ref *null)
				{
					calli(System.Void(System.UInt32*), ptr, GL.EntryPoints[155]);
				}
			}

			// Token: 0x06003B5F RID: 15199 RVA: 0x0009B770 File Offset: 0x00099970
			[CLSCompliant(false)]
			public unsafe static void GetFirstPerfQueryI(out int queryId)
			{
				fixed (int* ptr = &queryId)
				{
					calli(System.Void(System.UInt32*), ptr, GL.EntryPoints[155]);
				}
			}

			// Token: 0x06003B60 RID: 15200 RVA: 0x0009B794 File Offset: 0x00099994
			[CLSCompliant(false)]
			public unsafe static void GetFirstPerfQueryI([Out] int* queryId)
			{
				calli(System.Void(System.UInt32*), queryId, GL.EntryPoints[155]);
			}

			// Token: 0x06003B61 RID: 15201 RVA: 0x0009B7A8 File Offset: 0x000999A8
			[CLSCompliant(false)]
			public unsafe static void GetFirstPerfQueryI([Out] uint[] queryId)
			{
				fixed (uint* ptr = ref (queryId != null && queryId.Length != 0) ? ref queryId[0] : ref *null)
				{
					calli(System.Void(System.UInt32*), ptr, GL.EntryPoints[155]);
				}
			}

			// Token: 0x06003B62 RID: 15202 RVA: 0x0009B7DC File Offset: 0x000999DC
			[CLSCompliant(false)]
			public unsafe static void GetFirstPerfQueryI(out uint queryId)
			{
				fixed (uint* ptr = &queryId)
				{
					calli(System.Void(System.UInt32*), ptr, GL.EntryPoints[155]);
				}
			}

			// Token: 0x06003B63 RID: 15203 RVA: 0x0009B800 File Offset: 0x00099A00
			[CLSCompliant(false)]
			public unsafe static void GetFirstPerfQueryI([Out] uint* queryId)
			{
				calli(System.Void(System.UInt32*), queryId, GL.EntryPoints[155]);
			}

			// Token: 0x06003B64 RID: 15204 RVA: 0x0009B814 File Offset: 0x00099A14
			[CLSCompliant(false)]
			public static int GetNextPerfQueryI(int queryId)
			{
				int result;
				calli(System.Void(System.UInt32,System.UInt32*), queryId, ref result, GL.EntryPoints[162]);
				return result;
			}

			// Token: 0x06003B65 RID: 15205 RVA: 0x0009B838 File Offset: 0x00099A38
			[CLSCompliant(false)]
			public static int GetNextPerfQueryI(uint queryId)
			{
				int result;
				calli(System.Void(System.UInt32,System.UInt32*), queryId, ref result, GL.EntryPoints[162]);
				return result;
			}

			// Token: 0x06003B66 RID: 15206 RVA: 0x0009B85C File Offset: 0x00099A5C
			[CLSCompliant(false)]
			public unsafe static void GetNextPerfQueryI(int queryId, [Out] int[] nextQueryId)
			{
				fixed (int* ptr = ref (nextQueryId != null && nextQueryId.Length != 0) ? ref nextQueryId[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32*), queryId, ptr, GL.EntryPoints[162]);
				}
			}

			// Token: 0x06003B67 RID: 15207 RVA: 0x0009B890 File Offset: 0x00099A90
			[CLSCompliant(false)]
			public unsafe static void GetNextPerfQueryI(int queryId, out int nextQueryId)
			{
				fixed (int* ptr = &nextQueryId)
				{
					calli(System.Void(System.UInt32,System.UInt32*), queryId, ptr, GL.EntryPoints[162]);
				}
			}

			// Token: 0x06003B68 RID: 15208 RVA: 0x0009B8B4 File Offset: 0x00099AB4
			[CLSCompliant(false)]
			public unsafe static void GetNextPerfQueryI(int queryId, [Out] int* nextQueryId)
			{
				calli(System.Void(System.UInt32,System.UInt32*), queryId, nextQueryId, GL.EntryPoints[162]);
			}

			// Token: 0x06003B69 RID: 15209 RVA: 0x0009B8C8 File Offset: 0x00099AC8
			[CLSCompliant(false)]
			public unsafe static void GetNextPerfQueryI(uint queryId, [Out] uint[] nextQueryId)
			{
				fixed (uint* ptr = ref (nextQueryId != null && nextQueryId.Length != 0) ? ref nextQueryId[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32*), queryId, ptr, GL.EntryPoints[162]);
				}
			}

			// Token: 0x06003B6A RID: 15210 RVA: 0x0009B8FC File Offset: 0x00099AFC
			[CLSCompliant(false)]
			public unsafe static void GetNextPerfQueryI(uint queryId, out uint nextQueryId)
			{
				fixed (uint* ptr = &nextQueryId)
				{
					calli(System.Void(System.UInt32,System.UInt32*), queryId, ptr, GL.EntryPoints[162]);
				}
			}

			// Token: 0x06003B6B RID: 15211 RVA: 0x0009B920 File Offset: 0x00099B20
			[CLSCompliant(false)]
			public unsafe static void GetNextPerfQueryI(uint queryId, [Out] uint* nextQueryId)
			{
				calli(System.Void(System.UInt32,System.UInt32*), queryId, nextQueryId, GL.EntryPoints[162]);
			}

			// Token: 0x06003B6C RID: 15212 RVA: 0x0009B934 File Offset: 0x00099B34
			[CLSCompliant(false)]
			public unsafe static void GetPerfCounterInfo(int queryId, int counterId, int counterNameLength, [Out] StringBuilder counterName, int counterDescLength, [Out] StringBuilder counterDesc, [Out] int[] counterOffset, [Out] int[] counterDataSize, [Out] int[] counterTypeEnum, [Out] int[] counterDataTypeEnum, [Out] long[] rawCounterMaxValue)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterName.Capacity);
				IntPtr intPtr2 = intPtr;
				IntPtr intPtr3 = Marshal.AllocHGlobal((IntPtr)counterDesc.Capacity);
				IntPtr intPtr4 = intPtr3;
				fixed (int* ptr = ref (counterOffset != null && counterOffset.Length != 0) ? ref counterOffset[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (counterDataSize != null && counterDataSize.Length != 0) ? ref counterDataSize[0] : ref *null)
					{
						int* ptr4 = ptr3;
						fixed (int* ptr5 = ref (counterTypeEnum != null && counterTypeEnum.Length != 0) ? ref counterTypeEnum[0] : ref *null)
						{
							int* ptr6 = ptr5;
							fixed (int* ptr7 = ref (counterDataTypeEnum != null && counterDataTypeEnum.Length != 0) ? ref counterDataTypeEnum[0] : ref *null)
							{
								int* ptr8 = ptr7;
								fixed (long* ptr9 = ref (rawCounterMaxValue != null && rawCounterMaxValue.Length != 0) ? ref rawCounterMaxValue[0] : ref *null)
								{
									calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.IntPtr,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt64*), queryId, counterId, counterNameLength, intPtr2, counterDescLength, intPtr4, ptr2, ptr4, ptr6, ptr8, ptr9, GL.EntryPoints[170]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, counterName);
									Marshal.FreeHGlobal(intPtr);
									BindingsBase.MarshalPtrToStringBuilder(intPtr3, counterDesc);
									Marshal.FreeHGlobal(intPtr3);
								}
							}
						}
					}
				}
			}

			// Token: 0x06003B6D RID: 15213 RVA: 0x0009BA10 File Offset: 0x00099C10
			[CLSCompliant(false)]
			public unsafe static void GetPerfCounterInfo(int queryId, int counterId, int counterNameLength, [Out] StringBuilder counterName, int counterDescLength, [Out] StringBuilder counterDesc, out int counterOffset, out int counterDataSize, out int counterTypeEnum, out int counterDataTypeEnum, out long rawCounterMaxValue)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterName.Capacity);
				IntPtr intPtr2 = intPtr;
				IntPtr intPtr3 = Marshal.AllocHGlobal((IntPtr)counterDesc.Capacity);
				IntPtr intPtr4 = intPtr3;
				fixed (int* ptr = &counterOffset)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &counterDataSize)
					{
						int* ptr4 = ptr3;
						fixed (int* ptr5 = &counterTypeEnum)
						{
							int* ptr6 = ptr5;
							fixed (int* ptr7 = &counterDataTypeEnum)
							{
								int* ptr8 = ptr7;
								fixed (long* ptr9 = &rawCounterMaxValue)
								{
									calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.IntPtr,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt64*), queryId, counterId, counterNameLength, intPtr2, counterDescLength, intPtr4, ptr2, ptr4, ptr6, ptr8, ptr9, GL.EntryPoints[170]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, counterName);
									Marshal.FreeHGlobal(intPtr);
									BindingsBase.MarshalPtrToStringBuilder(intPtr3, counterDesc);
									Marshal.FreeHGlobal(intPtr3);
								}
							}
						}
					}
				}
			}

			// Token: 0x06003B6E RID: 15214 RVA: 0x0009BA88 File Offset: 0x00099C88
			[CLSCompliant(false)]
			public unsafe static void GetPerfCounterInfo(int queryId, int counterId, int counterNameLength, [Out] StringBuilder counterName, int counterDescLength, [Out] StringBuilder counterDesc, [Out] int* counterOffset, [Out] int* counterDataSize, [Out] int* counterTypeEnum, [Out] int* counterDataTypeEnum, [Out] long* rawCounterMaxValue)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterName.Capacity);
				IntPtr intPtr2 = intPtr;
				IntPtr intPtr3 = Marshal.AllocHGlobal((IntPtr)counterDesc.Capacity);
				calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.IntPtr,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt64*), queryId, counterId, counterNameLength, intPtr2, counterDescLength, intPtr3, counterOffset, counterDataSize, counterTypeEnum, counterDataTypeEnum, rawCounterMaxValue, GL.EntryPoints[170]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, counterName);
				Marshal.FreeHGlobal(intPtr);
				BindingsBase.MarshalPtrToStringBuilder(intPtr3, counterDesc);
				Marshal.FreeHGlobal(intPtr3);
			}

			// Token: 0x06003B6F RID: 15215 RVA: 0x0009BAEC File Offset: 0x00099CEC
			[CLSCompliant(false)]
			public unsafe static void GetPerfCounterInfo(uint queryId, uint counterId, uint counterNameLength, [Out] StringBuilder counterName, uint counterDescLength, [Out] StringBuilder counterDesc, [Out] uint[] counterOffset, [Out] uint[] counterDataSize, [Out] uint[] counterTypeEnum, [Out] uint[] counterDataTypeEnum, [Out] ulong[] rawCounterMaxValue)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterName.Capacity);
				IntPtr intPtr2 = intPtr;
				IntPtr intPtr3 = Marshal.AllocHGlobal((IntPtr)counterDesc.Capacity);
				IntPtr intPtr4 = intPtr3;
				fixed (uint* ptr = ref (counterOffset != null && counterOffset.Length != 0) ? ref counterOffset[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (uint* ptr3 = ref (counterDataSize != null && counterDataSize.Length != 0) ? ref counterDataSize[0] : ref *null)
					{
						uint* ptr4 = ptr3;
						fixed (uint* ptr5 = ref (counterTypeEnum != null && counterTypeEnum.Length != 0) ? ref counterTypeEnum[0] : ref *null)
						{
							uint* ptr6 = ptr5;
							fixed (uint* ptr7 = ref (counterDataTypeEnum != null && counterDataTypeEnum.Length != 0) ? ref counterDataTypeEnum[0] : ref *null)
							{
								uint* ptr8 = ptr7;
								fixed (ulong* ptr9 = ref (rawCounterMaxValue != null && rawCounterMaxValue.Length != 0) ? ref rawCounterMaxValue[0] : ref *null)
								{
									calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.IntPtr,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt64*), queryId, counterId, counterNameLength, intPtr2, counterDescLength, intPtr4, ptr2, ptr4, ptr6, ptr8, ptr9, GL.EntryPoints[170]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, counterName);
									Marshal.FreeHGlobal(intPtr);
									BindingsBase.MarshalPtrToStringBuilder(intPtr3, counterDesc);
									Marshal.FreeHGlobal(intPtr3);
								}
							}
						}
					}
				}
			}

			// Token: 0x06003B70 RID: 15216 RVA: 0x0009BBC8 File Offset: 0x00099DC8
			[CLSCompliant(false)]
			public unsafe static void GetPerfCounterInfo(uint queryId, uint counterId, uint counterNameLength, [Out] StringBuilder counterName, uint counterDescLength, [Out] StringBuilder counterDesc, out uint counterOffset, out uint counterDataSize, out uint counterTypeEnum, out uint counterDataTypeEnum, out ulong rawCounterMaxValue)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterName.Capacity);
				IntPtr intPtr2 = intPtr;
				IntPtr intPtr3 = Marshal.AllocHGlobal((IntPtr)counterDesc.Capacity);
				IntPtr intPtr4 = intPtr3;
				fixed (uint* ptr = &counterOffset)
				{
					uint* ptr2 = ptr;
					fixed (uint* ptr3 = &counterDataSize)
					{
						uint* ptr4 = ptr3;
						fixed (uint* ptr5 = &counterTypeEnum)
						{
							uint* ptr6 = ptr5;
							fixed (uint* ptr7 = &counterDataTypeEnum)
							{
								uint* ptr8 = ptr7;
								fixed (ulong* ptr9 = &rawCounterMaxValue)
								{
									calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.IntPtr,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt64*), queryId, counterId, counterNameLength, intPtr2, counterDescLength, intPtr4, ptr2, ptr4, ptr6, ptr8, ptr9, GL.EntryPoints[170]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, counterName);
									Marshal.FreeHGlobal(intPtr);
									BindingsBase.MarshalPtrToStringBuilder(intPtr3, counterDesc);
									Marshal.FreeHGlobal(intPtr3);
								}
							}
						}
					}
				}
			}

			// Token: 0x06003B71 RID: 15217 RVA: 0x0009BC40 File Offset: 0x00099E40
			[CLSCompliant(false)]
			public unsafe static void GetPerfCounterInfo(uint queryId, uint counterId, uint counterNameLength, [Out] StringBuilder counterName, uint counterDescLength, [Out] StringBuilder counterDesc, [Out] uint* counterOffset, [Out] uint* counterDataSize, [Out] uint* counterTypeEnum, [Out] uint* counterDataTypeEnum, [Out] ulong* rawCounterMaxValue)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)counterName.Capacity);
				IntPtr intPtr2 = intPtr;
				IntPtr intPtr3 = Marshal.AllocHGlobal((IntPtr)counterDesc.Capacity);
				calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.IntPtr,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt64*), queryId, counterId, counterNameLength, intPtr2, counterDescLength, intPtr3, counterOffset, counterDataSize, counterTypeEnum, counterDataTypeEnum, rawCounterMaxValue, GL.EntryPoints[170]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, counterName);
				Marshal.FreeHGlobal(intPtr);
				BindingsBase.MarshalPtrToStringBuilder(intPtr3, counterDesc);
				Marshal.FreeHGlobal(intPtr3);
			}

			// Token: 0x06003B72 RID: 15218 RVA: 0x0009BCA4 File Offset: 0x00099EA4
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData(int queryHandle, int flags, int dataSize, [Out] IntPtr data, [Out] int[] bytesWritten)
			{
				fixed (int* ptr = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, data, ptr, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B73 RID: 15219 RVA: 0x0009BCE0 File Offset: 0x00099EE0
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData(int queryHandle, int flags, int dataSize, [Out] IntPtr data, out int bytesWritten)
			{
				fixed (int* ptr = &bytesWritten)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, data, ptr, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B74 RID: 15220 RVA: 0x0009BD08 File Offset: 0x00099F08
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData(int queryHandle, int flags, int dataSize, [Out] IntPtr data, [Out] int* bytesWritten)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, data, bytesWritten, GL.EntryPoints[177]);
			}

			// Token: 0x06003B75 RID: 15221 RVA: 0x0009BD20 File Offset: 0x00099F20
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[] data, [Out] int[] bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (int* ptr3 = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B76 RID: 15222 RVA: 0x0009BD70 File Offset: 0x00099F70
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[] data, out int bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (int* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B77 RID: 15223 RVA: 0x0009BDAC File Offset: 0x00099FAC
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[] data, [Out] int* bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr, bytesWritten, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B78 RID: 15224 RVA: 0x0009BDE4 File Offset: 0x00099FE4
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[,] data, [Out] int[] bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (int* ptr3 = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B79 RID: 15225 RVA: 0x0009BE38 File Offset: 0x0009A038
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[,] data, out int bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (int* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B7A RID: 15226 RVA: 0x0009BE78 File Offset: 0x0009A078
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[,] data, [Out] int* bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr, bytesWritten, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B7B RID: 15227 RVA: 0x0009BEB4 File Offset: 0x0009A0B4
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[,,] data, [Out] int[] bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (int* ptr3 = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B7C RID: 15228 RVA: 0x0009BF08 File Offset: 0x0009A108
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[,,] data, out int bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (int* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B7D RID: 15229 RVA: 0x0009BF48 File Offset: 0x0009A148
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] T3[,,] data, [Out] int* bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr, bytesWritten, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B7E RID: 15230 RVA: 0x0009BF88 File Offset: 0x0009A188
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] ref T3 data, [Out] int[] bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = &data)
				{
					T3* ptr2 = ptr;
					fixed (int* ptr3 = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B7F RID: 15231 RVA: 0x0009BFC8 File Offset: 0x0009A1C8
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] ref T3 data, out int bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = &data)
				{
					T3* ptr2 = ptr;
					fixed (int* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B80 RID: 15232 RVA: 0x0009BFF4 File Offset: 0x0009A1F4
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(int queryHandle, int flags, int dataSize, [In] [Out] ref T3 data, [Out] int* bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = &data)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr, bytesWritten, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B81 RID: 15233 RVA: 0x0009C01C File Offset: 0x0009A21C
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData(uint queryHandle, uint flags, int dataSize, [Out] IntPtr data, [Out] uint[] bytesWritten)
			{
				fixed (uint* ptr = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, data, ptr, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B82 RID: 15234 RVA: 0x0009C058 File Offset: 0x0009A258
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData(uint queryHandle, uint flags, int dataSize, [Out] IntPtr data, out uint bytesWritten)
			{
				fixed (uint* ptr = &bytesWritten)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, data, ptr, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B83 RID: 15235 RVA: 0x0009C080 File Offset: 0x0009A280
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData(uint queryHandle, uint flags, int dataSize, [Out] IntPtr data, [Out] uint* bytesWritten)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, data, bytesWritten, GL.EntryPoints[177]);
			}

			// Token: 0x06003B84 RID: 15236 RVA: 0x0009C098 File Offset: 0x0009A298
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[] data, [Out] uint[] bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (uint* ptr3 = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B85 RID: 15237 RVA: 0x0009C0E8 File Offset: 0x0009A2E8
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[] data, out uint bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (uint* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B86 RID: 15238 RVA: 0x0009C124 File Offset: 0x0009A324
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[] data, [Out] uint* bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr, bytesWritten, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B87 RID: 15239 RVA: 0x0009C15C File Offset: 0x0009A35C
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[,] data, [Out] uint[] bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (uint* ptr3 = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B88 RID: 15240 RVA: 0x0009C1B0 File Offset: 0x0009A3B0
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[,] data, out uint bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (uint* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B89 RID: 15241 RVA: 0x0009C1F0 File Offset: 0x0009A3F0
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[,] data, [Out] uint* bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr, bytesWritten, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B8A RID: 15242 RVA: 0x0009C22C File Offset: 0x0009A42C
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[,,] data, [Out] uint[] bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (uint* ptr3 = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B8B RID: 15243 RVA: 0x0009C280 File Offset: 0x0009A480
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[,,] data, out uint bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					T3* ptr2 = ptr;
					fixed (uint* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B8C RID: 15244 RVA: 0x0009C2C0 File Offset: 0x0009A4C0
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] T3[,,] data, [Out] uint* bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr, bytesWritten, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B8D RID: 15245 RVA: 0x0009C300 File Offset: 0x0009A500
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] ref T3 data, [Out] uint[] bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = &data)
				{
					T3* ptr2 = ptr;
					fixed (uint* ptr3 = ref (bytesWritten != null && bytesWritten.Length != 0) ? ref bytesWritten[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B8E RID: 15246 RVA: 0x0009C340 File Offset: 0x0009A540
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] ref T3 data, out uint bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = &data)
				{
					T3* ptr2 = ptr;
					fixed (uint* ptr3 = &bytesWritten)
					{
						calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr2, ptr3, GL.EntryPoints[177]);
					}
				}
			}

			// Token: 0x06003B8F RID: 15247 RVA: 0x0009C36C File Offset: 0x0009A56C
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryData<T3>(uint queryHandle, uint flags, int dataSize, [In] [Out] ref T3 data, [Out] uint* bytesWritten) where T3 : struct
			{
				fixed (T3* ptr = &data)
				{
					calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.IntPtr,System.UInt32*), queryHandle, flags, dataSize, ptr, bytesWritten, GL.EntryPoints[177]);
				}
			}

			// Token: 0x06003B90 RID: 15248 RVA: 0x0009C394 File Offset: 0x0009A594
			[CLSCompliant(false)]
			public static int GetPerfQueryIdByName([Out] StringBuilder queryName)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				calli(System.Void(System.IntPtr,System.UInt32*), intPtr, ref intPtr, GL.EntryPoints[178]);
				int result = (int)intPtr;
				BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
				Marshal.FreeHGlobal(intPtr);
				return result;
			}

			// Token: 0x06003B91 RID: 15249 RVA: 0x0009C3D0 File Offset: 0x0009A5D0
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryIdByName([Out] StringBuilder queryName, [Out] int[] queryId)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = ref (queryId != null && queryId.Length != 0) ? ref queryId[0] : ref *null)
				{
					calli(System.Void(System.IntPtr,System.UInt32*), intPtr2, ptr, GL.EntryPoints[178]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003B92 RID: 15250 RVA: 0x0009C420 File Offset: 0x0009A620
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryIdByName([Out] StringBuilder queryName, out int queryId)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = &queryId)
				{
					calli(System.Void(System.IntPtr,System.UInt32*), intPtr2, ptr, GL.EntryPoints[178]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003B93 RID: 15251 RVA: 0x0009C45C File Offset: 0x0009A65C
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryIdByName([Out] StringBuilder queryName, [Out] int* queryId)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				calli(System.Void(System.IntPtr,System.UInt32*), intPtr, queryId, GL.EntryPoints[178]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003B94 RID: 15252 RVA: 0x0009C494 File Offset: 0x0009A694
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryIdByName([Out] StringBuilder queryName, [Out] uint[] queryId)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (uint* ptr = ref (queryId != null && queryId.Length != 0) ? ref queryId[0] : ref *null)
				{
					calli(System.Void(System.IntPtr,System.UInt32*), intPtr2, ptr, GL.EntryPoints[178]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003B95 RID: 15253 RVA: 0x0009C4E4 File Offset: 0x0009A6E4
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryIdByName([Out] StringBuilder queryName, out uint queryId)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (uint* ptr = &queryId)
				{
					calli(System.Void(System.IntPtr,System.UInt32*), intPtr2, ptr, GL.EntryPoints[178]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003B96 RID: 15254 RVA: 0x0009C520 File Offset: 0x0009A720
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryIdByName([Out] StringBuilder queryName, [Out] uint* queryId)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				calli(System.Void(System.IntPtr,System.UInt32*), intPtr, queryId, GL.EntryPoints[178]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003B97 RID: 15255 RVA: 0x0009C558 File Offset: 0x0009A758
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryInfo(int queryId, int queryNameLength, [Out] StringBuilder queryName, [Out] int[] dataSize, [Out] int[] noCounters, [Out] int[] noInstances, [Out] int[] capsMask)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = ref (dataSize != null && dataSize.Length != 0) ? ref dataSize[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (noCounters != null && noCounters.Length != 0) ? ref noCounters[0] : ref *null)
					{
						int* ptr4 = ptr3;
						fixed (int* ptr5 = ref (noInstances != null && noInstances.Length != 0) ? ref noInstances[0] : ref *null)
						{
							int* ptr6 = ptr5;
							fixed (int* ptr7 = ref (capsMask != null && capsMask.Length != 0) ? ref capsMask[0] : ref *null)
							{
								calli(System.Void(System.UInt32,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*), queryId, queryNameLength, intPtr2, ptr2, ptr4, ptr6, ptr7, GL.EntryPoints[179]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
								Marshal.FreeHGlobal(intPtr);
							}
						}
					}
				}
			}

			// Token: 0x06003B98 RID: 15256 RVA: 0x0009C5F4 File Offset: 0x0009A7F4
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryInfo(int queryId, int queryNameLength, [Out] StringBuilder queryName, out int dataSize, out int noCounters, out int noInstances, out int capsMask)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = &dataSize)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &noCounters)
					{
						int* ptr4 = ptr3;
						fixed (int* ptr5 = &noInstances)
						{
							int* ptr6 = ptr5;
							fixed (int* ptr7 = &capsMask)
							{
								calli(System.Void(System.UInt32,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*), queryId, queryNameLength, intPtr2, ptr2, ptr4, ptr6, ptr7, GL.EntryPoints[179]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
								Marshal.FreeHGlobal(intPtr);
							}
						}
					}
				}
			}

			// Token: 0x06003B99 RID: 15257 RVA: 0x0009C644 File Offset: 0x0009A844
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryInfo(int queryId, int queryNameLength, [Out] StringBuilder queryName, [Out] int* dataSize, [Out] int* noCounters, [Out] int* noInstances, [Out] int* capsMask)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				calli(System.Void(System.UInt32,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*), queryId, queryNameLength, intPtr, dataSize, noCounters, noInstances, capsMask, GL.EntryPoints[179]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003B9A RID: 15258 RVA: 0x0009C684 File Offset: 0x0009A884
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryInfo(uint queryId, uint queryNameLength, [Out] StringBuilder queryName, [Out] uint[] dataSize, [Out] uint[] noCounters, [Out] uint[] noInstances, [Out] uint[] capsMask)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (uint* ptr = ref (dataSize != null && dataSize.Length != 0) ? ref dataSize[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (uint* ptr3 = ref (noCounters != null && noCounters.Length != 0) ? ref noCounters[0] : ref *null)
					{
						uint* ptr4 = ptr3;
						fixed (uint* ptr5 = ref (noInstances != null && noInstances.Length != 0) ? ref noInstances[0] : ref *null)
						{
							uint* ptr6 = ptr5;
							fixed (uint* ptr7 = ref (capsMask != null && capsMask.Length != 0) ? ref capsMask[0] : ref *null)
							{
								calli(System.Void(System.UInt32,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*), queryId, queryNameLength, intPtr2, ptr2, ptr4, ptr6, ptr7, GL.EntryPoints[179]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
								Marshal.FreeHGlobal(intPtr);
							}
						}
					}
				}
			}

			// Token: 0x06003B9B RID: 15259 RVA: 0x0009C720 File Offset: 0x0009A920
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryInfo(uint queryId, uint queryNameLength, [Out] StringBuilder queryName, out uint dataSize, out uint noCounters, out uint noInstances, out uint capsMask)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (uint* ptr = &dataSize)
				{
					uint* ptr2 = ptr;
					fixed (uint* ptr3 = &noCounters)
					{
						uint* ptr4 = ptr3;
						fixed (uint* ptr5 = &noInstances)
						{
							uint* ptr6 = ptr5;
							fixed (uint* ptr7 = &capsMask)
							{
								calli(System.Void(System.UInt32,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*), queryId, queryNameLength, intPtr2, ptr2, ptr4, ptr6, ptr7, GL.EntryPoints[179]);
								BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
								Marshal.FreeHGlobal(intPtr);
							}
						}
					}
				}
			}

			// Token: 0x06003B9C RID: 15260 RVA: 0x0009C770 File Offset: 0x0009A970
			[CLSCompliant(false)]
			public unsafe static void GetPerfQueryInfo(uint queryId, uint queryNameLength, [Out] StringBuilder queryName, [Out] uint* dataSize, [Out] uint* noCounters, [Out] uint* noInstances, [Out] uint* capsMask)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)queryName.Capacity);
				calli(System.Void(System.UInt32,System.UInt32,System.IntPtr,System.UInt32*,System.UInt32*,System.UInt32*,System.UInt32*), queryId, queryNameLength, intPtr, dataSize, noCounters, noInstances, capsMask, GL.EntryPoints[179]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, queryName);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x0200050B RID: 1291
		public static class Khr
		{
			// Token: 0x06003B9D RID: 15261 RVA: 0x0009C7B0 File Offset: 0x0009A9B0
			public static void BlendBarrier()
			{
				calli(System.Void(), GL.EntryPoints[15]);
			}

			// Token: 0x06003B9E RID: 15262 RVA: 0x0009C7C0 File Offset: 0x0009A9C0
			public static void DebugMessageCallback(DebugProcKhr callback, IntPtr userParam)
			{
				calli(System.Void(OpenTK.Graphics.ES20.DebugProcKhr,System.IntPtr), callback, userParam, GL.EntryPoints[60]);
			}

			// Token: 0x06003B9F RID: 15263 RVA: 0x0009C7D4 File Offset: 0x0009A9D4
			[CLSCompliant(false)]
			public unsafe static void DebugMessageCallback<T1>(DebugProcKhr callback, [In] [Out] T1[] userParam) where T1 : struct
			{
				fixed (T1* ptr = ref (userParam != null && userParam.Length != 0) ? ref userParam[0] : ref *null)
				{
					calli(System.Void(OpenTK.Graphics.ES20.DebugProcKhr,System.IntPtr), callback, ptr, GL.EntryPoints[60]);
				}
			}

			// Token: 0x06003BA0 RID: 15264 RVA: 0x0009C808 File Offset: 0x0009AA08
			[CLSCompliant(false)]
			public unsafe static void DebugMessageCallback<T1>(DebugProcKhr callback, [In] [Out] T1[,] userParam) where T1 : struct
			{
				fixed (T1* ptr = ref (userParam != null && userParam.Length != 0) ? ref userParam[0, 0] : ref *null)
				{
					calli(System.Void(OpenTK.Graphics.ES20.DebugProcKhr,System.IntPtr), callback, ptr, GL.EntryPoints[60]);
				}
			}

			// Token: 0x06003BA1 RID: 15265 RVA: 0x0009C840 File Offset: 0x0009AA40
			[CLSCompliant(false)]
			public unsafe static void DebugMessageCallback<T1>(DebugProcKhr callback, [In] [Out] T1[,,] userParam) where T1 : struct
			{
				fixed (T1* ptr = ref (userParam != null && userParam.Length != 0) ? ref userParam[0, 0, 0] : ref *null)
				{
					calli(System.Void(OpenTK.Graphics.ES20.DebugProcKhr,System.IntPtr), callback, ptr, GL.EntryPoints[60]);
				}
			}

			// Token: 0x06003BA2 RID: 15266 RVA: 0x0009C878 File Offset: 0x0009AA78
			public unsafe static void DebugMessageCallback<T1>(DebugProcKhr callback, [In] [Out] ref T1 userParam) where T1 : struct
			{
				fixed (T1* ptr = &userParam)
				{
					calli(System.Void(OpenTK.Graphics.ES20.DebugProcKhr,System.IntPtr), callback, ptr, GL.EntryPoints[60]);
				}
			}

			// Token: 0x06003BA3 RID: 15267 RVA: 0x0009C898 File Offset: 0x0009AA98
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DebugMessageControl(All source, All type, All severity, int count, int[] ids, bool enabled)
			{
				fixed (int* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003BA4 RID: 15268 RVA: 0x0009C8D4 File Offset: 0x0009AAD4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DebugMessageControl(All source, All type, All severity, int count, ref int ids, bool enabled)
			{
				fixed (int* ptr = &ids)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003BA5 RID: 15269 RVA: 0x0009C8FC File Offset: 0x0009AAFC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DebugMessageControl(All source, All type, All severity, int count, int* ids, bool enabled)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ids, enabled, GL.EntryPoints[62]);
			}

			// Token: 0x06003BA6 RID: 15270 RVA: 0x0009C914 File Offset: 0x0009AB14
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DebugMessageControl(All source, All type, All severity, int count, uint[] ids, bool enabled)
			{
				fixed (uint* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003BA7 RID: 15271 RVA: 0x0009C950 File Offset: 0x0009AB50
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DebugMessageControl(All source, All type, All severity, int count, ref uint ids, bool enabled)
			{
				fixed (uint* ptr = &ids)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003BA8 RID: 15272 RVA: 0x0009C978 File Offset: 0x0009AB78
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DebugMessageControl(All source, All type, All severity, int count, uint* ids, bool enabled)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ids, enabled, GL.EntryPoints[62]);
			}

			// Token: 0x06003BA9 RID: 15273 RVA: 0x0009C990 File Offset: 0x0009AB90
			[CLSCompliant(false)]
			public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, int[] ids, bool enabled)
			{
				fixed (int* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003BAA RID: 15274 RVA: 0x0009C9CC File Offset: 0x0009ABCC
			[CLSCompliant(false)]
			public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, ref int ids, bool enabled)
			{
				fixed (int* ptr = &ids)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003BAB RID: 15275 RVA: 0x0009C9F4 File Offset: 0x0009ABF4
			[CLSCompliant(false)]
			public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, int* ids, bool enabled)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ids, enabled, GL.EntryPoints[62]);
			}

			// Token: 0x06003BAC RID: 15276 RVA: 0x0009CA0C File Offset: 0x0009AC0C
			[CLSCompliant(false)]
			public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, uint[] ids, bool enabled)
			{
				fixed (uint* ptr = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003BAD RID: 15277 RVA: 0x0009CA48 File Offset: 0x0009AC48
			[CLSCompliant(false)]
			public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, ref uint ids, bool enabled)
			{
				fixed (uint* ptr = &ids)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ptr, enabled, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003BAE RID: 15278 RVA: 0x0009CA70 File Offset: 0x0009AC70
			[CLSCompliant(false)]
			public unsafe static void DebugMessageControl(DebugSourceControl source, DebugTypeControl type, DebugSeverityControl severity, int count, uint* ids, bool enabled)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.UInt32*,System.Boolean), source, type, severity, count, ids, enabled, GL.EntryPoints[62]);
			}

			// Token: 0x06003BAF RID: 15279 RVA: 0x0009CA88 File Offset: 0x0009AC88
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static void DebugMessageInsert(All source, All type, int id, All severity, int length, string buf)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(buf);
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.IntPtr), source, type, id, severity, length, intPtr, GL.EntryPoints[64]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BB0 RID: 15280 RVA: 0x0009CAB8 File Offset: 0x0009ACB8
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void DebugMessageInsert(All source, All type, uint id, All severity, int length, string buf)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(buf);
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.IntPtr), source, type, id, severity, length, intPtr, GL.EntryPoints[64]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BB1 RID: 15281 RVA: 0x0009CAE8 File Offset: 0x0009ACE8
			[CLSCompliant(false)]
			public static void DebugMessageInsert(DebugSourceExternal source, DebugType type, int id, DebugSeverity severity, int length, string buf)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(buf);
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.IntPtr), source, type, id, severity, length, intPtr, GL.EntryPoints[64]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BB2 RID: 15282 RVA: 0x0009CB18 File Offset: 0x0009AD18
			[CLSCompliant(false)]
			public static void DebugMessageInsert(DebugSourceExternal source, DebugType type, uint id, DebugSeverity severity, int length, string buf)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(buf);
				calli(System.Void(System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32,System.IntPtr), source, type, id, severity, length, intPtr, GL.EntryPoints[64]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BB3 RID: 15283 RVA: 0x0009CB48 File Offset: 0x0009AD48
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static int GetDebugMessageLog(int count, int bufSize, [Out] All[] sources, [Out] All[] types, [Out] int[] ids, [Out] All[] severities, [Out] int[] lengths, [Out] StringBuilder messageLog)
			{
				fixed (All* ptr = ref (sources != null && sources.Length != 0) ? ref sources[0] : ref *null)
				{
					All* ptr2 = ptr;
					fixed (All* ptr3 = ref (types != null && types.Length != 0) ? ref types[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (int* ptr5 = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
						{
							int* ptr6 = ptr5;
							fixed (All* ptr7 = ref (severities != null && severities.Length != 0) ? ref severities[0] : ref *null)
							{
								All* ptr8 = ptr7;
								fixed (int* ptr9 = ref (lengths != null && lengths.Length != 0) ? ref lengths[0] : ref *null)
								{
									int* ptr10 = ptr9;
									IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
									int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[150]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
									Marshal.FreeHGlobal(intPtr);
									return result;
								}
							}
						}
					}
				}
			}

			// Token: 0x06003BB4 RID: 15284 RVA: 0x0009CC00 File Offset: 0x0009AE00
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static int GetDebugMessageLog(int count, int bufSize, out All sources, out All types, out int ids, out All severities, out int lengths, [Out] StringBuilder messageLog)
			{
				fixed (All* ptr = &sources)
				{
					All* ptr2 = ptr;
					fixed (All* ptr3 = &types)
					{
						All* ptr4 = ptr3;
						fixed (int* ptr5 = &ids)
						{
							int* ptr6 = ptr5;
							fixed (All* ptr7 = &severities)
							{
								All* ptr8 = ptr7;
								fixed (int* ptr9 = &lengths)
								{
									int* ptr10 = ptr9;
									IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
									int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[150]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
									Marshal.FreeHGlobal(intPtr);
									return result;
								}
							}
						}
					}
				}
			}

			// Token: 0x06003BB5 RID: 15285 RVA: 0x0009CC58 File Offset: 0x0009AE58
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(int count, int bufSize, [Out] All* sources, [Out] All* types, [Out] int* ids, [Out] All* severities, [Out] int* lengths, [Out] StringBuilder messageLog)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
				int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, sources, types, ids, severities, lengths, intPtr, GL.EntryPoints[150]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
				Marshal.FreeHGlobal(intPtr);
				return result;
			}

			// Token: 0x06003BB6 RID: 15286 RVA: 0x0009CC9C File Offset: 0x0009AE9C
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(int count, int bufSize, [Out] DebugSourceExternal[] sources, [Out] DebugType[] types, [Out] int[] ids, [Out] DebugSeverity[] severities, [Out] int[] lengths, [Out] StringBuilder messageLog)
			{
				fixed (DebugSourceExternal* ptr = ref (sources != null && sources.Length != 0) ? ref sources[0] : ref *null)
				{
					DebugSourceExternal* ptr2 = ptr;
					fixed (DebugType* ptr3 = ref (types != null && types.Length != 0) ? ref types[0] : ref *null)
					{
						DebugType* ptr4 = ptr3;
						fixed (int* ptr5 = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
						{
							int* ptr6 = ptr5;
							fixed (DebugSeverity* ptr7 = ref (severities != null && severities.Length != 0) ? ref severities[0] : ref *null)
							{
								DebugSeverity* ptr8 = ptr7;
								fixed (int* ptr9 = ref (lengths != null && lengths.Length != 0) ? ref lengths[0] : ref *null)
								{
									int* ptr10 = ptr9;
									IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
									int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[150]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
									Marshal.FreeHGlobal(intPtr);
									return result;
								}
							}
						}
					}
				}
			}

			// Token: 0x06003BB7 RID: 15287 RVA: 0x0009CD54 File Offset: 0x0009AF54
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(int count, int bufSize, out DebugSourceExternal sources, out DebugType types, out int ids, out DebugSeverity severities, out int lengths, [Out] StringBuilder messageLog)
			{
				fixed (DebugSourceExternal* ptr = &sources)
				{
					DebugSourceExternal* ptr2 = ptr;
					fixed (DebugType* ptr3 = &types)
					{
						DebugType* ptr4 = ptr3;
						fixed (int* ptr5 = &ids)
						{
							int* ptr6 = ptr5;
							fixed (DebugSeverity* ptr7 = &severities)
							{
								DebugSeverity* ptr8 = ptr7;
								fixed (int* ptr9 = &lengths)
								{
									int* ptr10 = ptr9;
									IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
									int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[150]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
									Marshal.FreeHGlobal(intPtr);
									return result;
								}
							}
						}
					}
				}
			}

			// Token: 0x06003BB8 RID: 15288 RVA: 0x0009CDAC File Offset: 0x0009AFAC
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(int count, int bufSize, [Out] DebugSourceExternal* sources, [Out] DebugType* types, [Out] int* ids, [Out] DebugSeverity* severities, [Out] int* lengths, [Out] StringBuilder messageLog)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
				int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, sources, types, ids, severities, lengths, intPtr, GL.EntryPoints[150]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
				Marshal.FreeHGlobal(intPtr);
				return result;
			}

			// Token: 0x06003BB9 RID: 15289 RVA: 0x0009CDF0 File Offset: 0x0009AFF0
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(uint count, int bufSize, [Out] All[] sources, [Out] All[] types, [Out] uint[] ids, [Out] All[] severities, [Out] int[] lengths, [Out] StringBuilder messageLog)
			{
				fixed (All* ptr = ref (sources != null && sources.Length != 0) ? ref sources[0] : ref *null)
				{
					All* ptr2 = ptr;
					fixed (All* ptr3 = ref (types != null && types.Length != 0) ? ref types[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (uint* ptr5 = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
						{
							uint* ptr6 = ptr5;
							fixed (All* ptr7 = ref (severities != null && severities.Length != 0) ? ref severities[0] : ref *null)
							{
								All* ptr8 = ptr7;
								fixed (int* ptr9 = ref (lengths != null && lengths.Length != 0) ? ref lengths[0] : ref *null)
								{
									int* ptr10 = ptr9;
									IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
									int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[150]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
									Marshal.FreeHGlobal(intPtr);
									return result;
								}
							}
						}
					}
				}
			}

			// Token: 0x06003BBA RID: 15290 RVA: 0x0009CEA8 File Offset: 0x0009B0A8
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(uint count, int bufSize, out All sources, out All types, out uint ids, out All severities, out int lengths, [Out] StringBuilder messageLog)
			{
				fixed (All* ptr = &sources)
				{
					All* ptr2 = ptr;
					fixed (All* ptr3 = &types)
					{
						All* ptr4 = ptr3;
						fixed (uint* ptr5 = &ids)
						{
							uint* ptr6 = ptr5;
							fixed (All* ptr7 = &severities)
							{
								All* ptr8 = ptr7;
								fixed (int* ptr9 = &lengths)
								{
									int* ptr10 = ptr9;
									IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
									int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[150]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
									Marshal.FreeHGlobal(intPtr);
									return result;
								}
							}
						}
					}
				}
			}

			// Token: 0x06003BBB RID: 15291 RVA: 0x0009CF00 File Offset: 0x0009B100
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static int GetDebugMessageLog(uint count, int bufSize, [Out] All* sources, [Out] All* types, [Out] uint* ids, [Out] All* severities, [Out] int* lengths, [Out] StringBuilder messageLog)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
				int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, sources, types, ids, severities, lengths, intPtr, GL.EntryPoints[150]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
				Marshal.FreeHGlobal(intPtr);
				return result;
			}

			// Token: 0x06003BBC RID: 15292 RVA: 0x0009CF44 File Offset: 0x0009B144
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(uint count, int bufSize, [Out] DebugSourceExternal[] sources, [Out] DebugType[] types, [Out] uint[] ids, [Out] DebugSeverity[] severities, [Out] int[] lengths, [Out] StringBuilder messageLog)
			{
				fixed (DebugSourceExternal* ptr = ref (sources != null && sources.Length != 0) ? ref sources[0] : ref *null)
				{
					DebugSourceExternal* ptr2 = ptr;
					fixed (DebugType* ptr3 = ref (types != null && types.Length != 0) ? ref types[0] : ref *null)
					{
						DebugType* ptr4 = ptr3;
						fixed (uint* ptr5 = ref (ids != null && ids.Length != 0) ? ref ids[0] : ref *null)
						{
							uint* ptr6 = ptr5;
							fixed (DebugSeverity* ptr7 = ref (severities != null && severities.Length != 0) ? ref severities[0] : ref *null)
							{
								DebugSeverity* ptr8 = ptr7;
								fixed (int* ptr9 = ref (lengths != null && lengths.Length != 0) ? ref lengths[0] : ref *null)
								{
									int* ptr10 = ptr9;
									IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
									int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[150]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
									Marshal.FreeHGlobal(intPtr);
									return result;
								}
							}
						}
					}
				}
			}

			// Token: 0x06003BBD RID: 15293 RVA: 0x0009CFFC File Offset: 0x0009B1FC
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(uint count, int bufSize, out DebugSourceExternal sources, out DebugType types, out uint ids, out DebugSeverity severities, out int lengths, [Out] StringBuilder messageLog)
			{
				fixed (DebugSourceExternal* ptr = &sources)
				{
					DebugSourceExternal* ptr2 = ptr;
					fixed (DebugType* ptr3 = &types)
					{
						DebugType* ptr4 = ptr3;
						fixed (uint* ptr5 = &ids)
						{
							uint* ptr6 = ptr5;
							fixed (DebugSeverity* ptr7 = &severities)
							{
								DebugSeverity* ptr8 = ptr7;
								fixed (int* ptr9 = &lengths)
								{
									int* ptr10 = ptr9;
									IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
									int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, ptr2, ptr4, ptr6, ptr8, ptr10, intPtr, GL.EntryPoints[150]);
									BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
									Marshal.FreeHGlobal(intPtr);
									return result;
								}
							}
						}
					}
				}
			}

			// Token: 0x06003BBE RID: 15294 RVA: 0x0009D054 File Offset: 0x0009B254
			[CLSCompliant(false)]
			public unsafe static int GetDebugMessageLog(uint count, int bufSize, [Out] DebugSourceExternal* sources, [Out] DebugType* types, [Out] uint* ids, [Out] DebugSeverity* severities, [Out] int* lengths, [Out] StringBuilder messageLog)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)messageLog.Capacity);
				int result = calli(System.Int32(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.UInt32*,System.Int32*,System.Int32*,System.IntPtr), count, bufSize, sources, types, ids, severities, lengths, intPtr, GL.EntryPoints[150]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, messageLog);
				Marshal.FreeHGlobal(intPtr);
				return result;
			}

			// Token: 0x06003BBF RID: 15295 RVA: 0x0009D098 File Offset: 0x0009B298
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(All identifier, int name, int bufSize, [Out] int[] length, [Out] StringBuilder label)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[167]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BC0 RID: 15296 RVA: 0x0009D0EC File Offset: 0x0009B2EC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(All identifier, int name, int bufSize, out int length, [Out] StringBuilder label)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[167]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BC1 RID: 15297 RVA: 0x0009D12C File Offset: 0x0009B32C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetObjectLabel(All identifier, int name, int bufSize, [Out] int* length, [Out] StringBuilder label)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, length, intPtr, GL.EntryPoints[167]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003BC2 RID: 15298 RVA: 0x0009D16C File Offset: 0x0009B36C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetObjectLabel(All identifier, uint name, int bufSize, [Out] int[] length, [Out] StringBuilder label)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[167]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BC3 RID: 15299 RVA: 0x0009D1C0 File Offset: 0x0009B3C0
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(All identifier, uint name, int bufSize, out int length, [Out] StringBuilder label)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[167]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BC4 RID: 15300 RVA: 0x0009D200 File Offset: 0x0009B400
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetObjectLabel(All identifier, uint name, int bufSize, [Out] int* length, [Out] StringBuilder label)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, length, intPtr, GL.EntryPoints[167]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003BC5 RID: 15301 RVA: 0x0009D240 File Offset: 0x0009B440
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, int name, int bufSize, [Out] int[] length, [Out] StringBuilder label)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[167]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BC6 RID: 15302 RVA: 0x0009D294 File Offset: 0x0009B494
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, int name, int bufSize, out int length, [Out] StringBuilder label)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[167]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BC7 RID: 15303 RVA: 0x0009D2D4 File Offset: 0x0009B4D4
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, int name, int bufSize, [Out] int* length, [Out] StringBuilder label)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, length, intPtr, GL.EntryPoints[167]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003BC8 RID: 15304 RVA: 0x0009D314 File Offset: 0x0009B514
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, int bufSize, [Out] int[] length, [Out] StringBuilder label)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[167]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BC9 RID: 15305 RVA: 0x0009D368 File Offset: 0x0009B568
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, int bufSize, out int length, [Out] StringBuilder label)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, ptr2, intPtr, GL.EntryPoints[167]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BCA RID: 15306 RVA: 0x0009D3A8 File Offset: 0x0009B5A8
			[CLSCompliant(false)]
			public unsafe static void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, int bufSize, [Out] int* length, [Out] StringBuilder label)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.Int32*,System.IntPtr), identifier, name, bufSize, length, intPtr, GL.EntryPoints[167]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003BCB RID: 15307 RVA: 0x0009D3E8 File Offset: 0x0009B5E8
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectPtrLabel(IntPtr ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label)
			{
				fixed (int* ptr2 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr3 = ptr2;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr, bufSize, ptr3, intPtr, GL.EntryPoints[169]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BCC RID: 15308 RVA: 0x0009D438 File Offset: 0x0009B638
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length, [Out] StringBuilder label)
			{
				fixed (int* ptr2 = &length)
				{
					int* ptr3 = ptr2;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr, bufSize, ptr3, intPtr, GL.EntryPoints[169]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BCD RID: 15309 RVA: 0x0009D478 File Offset: 0x0009B678
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel(IntPtr ptr, int bufSize, [Out] int* length, [Out] StringBuilder label)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
				calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr, bufSize, length, intPtr, GL.EntryPoints[169]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003BCE RID: 15310 RVA: 0x0009D4B4 File Offset: 0x0009B6B4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[] ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0] : ref *null)
				{
					T0* ptr3 = ptr2;
					fixed (int* ptr4 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
					{
						int* ptr5 = ptr4;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
						calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[169]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}

			// Token: 0x06003BCF RID: 15311 RVA: 0x0009D518 File Offset: 0x0009B718
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[] ptr, int bufSize, out int length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0] : ref *null)
				{
					T0* ptr3 = ptr2;
					fixed (int* ptr4 = &length)
					{
						int* ptr5 = ptr4;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
						calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[169]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}

			// Token: 0x06003BD0 RID: 15312 RVA: 0x0009D56C File Offset: 0x0009B76C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[] ptr, int bufSize, [Out] int* length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0] : ref *null)
				{
					T0* ptr3 = ptr2;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, length, intPtr, GL.EntryPoints[169]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BD1 RID: 15313 RVA: 0x0009D5BC File Offset: 0x0009B7BC
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,] ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0] : ref *null)
				{
					T0* ptr3 = ptr2;
					fixed (int* ptr4 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
					{
						int* ptr5 = ptr4;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
						calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[169]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}

			// Token: 0x06003BD2 RID: 15314 RVA: 0x0009D624 File Offset: 0x0009B824
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,] ptr, int bufSize, out int length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0] : ref *null)
				{
					T0* ptr3 = ptr2;
					fixed (int* ptr4 = &length)
					{
						int* ptr5 = ptr4;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
						calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[169]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}

			// Token: 0x06003BD3 RID: 15315 RVA: 0x0009D67C File Offset: 0x0009B87C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,] ptr, int bufSize, [Out] int* length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0] : ref *null)
				{
					T0* ptr3 = ptr2;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, length, intPtr, GL.EntryPoints[169]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BD4 RID: 15316 RVA: 0x0009D6D0 File Offset: 0x0009B8D0
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,,] ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0, 0] : ref *null)
				{
					T0* ptr3 = ptr2;
					fixed (int* ptr4 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
					{
						int* ptr5 = ptr4;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
						calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[169]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}

			// Token: 0x06003BD5 RID: 15317 RVA: 0x0009D73C File Offset: 0x0009B93C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,,] ptr, int bufSize, out int length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0, 0] : ref *null)
				{
					T0* ptr3 = ptr2;
					fixed (int* ptr4 = &length)
					{
						int* ptr5 = ptr4;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
						calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[169]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}

			// Token: 0x06003BD6 RID: 15318 RVA: 0x0009D794 File Offset: 0x0009B994
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] T0[,,] ptr, int bufSize, [Out] int* length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0, 0] : ref *null)
				{
					T0* ptr3 = ptr2;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, length, intPtr, GL.EntryPoints[169]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BD7 RID: 15319 RVA: 0x0009D7E8 File Offset: 0x0009B9E8
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] ref T0 ptr, int bufSize, [Out] int[] length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = &ptr)
				{
					T0* ptr3 = ptr2;
					fixed (int* ptr4 = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
					{
						int* ptr5 = ptr4;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
						calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[169]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}

			// Token: 0x06003BD8 RID: 15320 RVA: 0x0009D83C File Offset: 0x0009BA3C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] ref T0 ptr, int bufSize, out int length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = &ptr)
				{
					T0* ptr3 = ptr2;
					fixed (int* ptr4 = &length)
					{
						int* ptr5 = ptr4;
						IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
						calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, ptr5, intPtr, GL.EntryPoints[169]);
						BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}

			// Token: 0x06003BD9 RID: 15321 RVA: 0x0009D87C File Offset: 0x0009BA7C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetObjectPtrLabel<T0>([In] [Out] ref T0 ptr, int bufSize, [Out] int* length, [Out] StringBuilder label) where T0 : struct
			{
				fixed (T0* ptr2 = &ptr)
				{
					T0* ptr3 = ptr2;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)label.Capacity);
					calli(System.Void(System.IntPtr,System.Int32,System.Int32*,System.IntPtr), ptr3, bufSize, length, intPtr, GL.EntryPoints[169]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, label);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003BDA RID: 15322 RVA: 0x0009D8BC File Offset: 0x0009BABC
			public static void GetPointer(All pname, [Out] IntPtr @params)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, @params, GL.EntryPoints[181]);
			}

			// Token: 0x06003BDB RID: 15323 RVA: 0x0009D8D0 File Offset: 0x0009BAD0
			[CLSCompliant(false)]
			public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[181]);
				}
			}

			// Token: 0x06003BDC RID: 15324 RVA: 0x0009D904 File Offset: 0x0009BB04
			[CLSCompliant(false)]
			public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[,] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[181]);
				}
			}

			// Token: 0x06003BDD RID: 15325 RVA: 0x0009D93C File Offset: 0x0009BB3C
			[CLSCompliant(false)]
			public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[,,] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[181]);
				}
			}

			// Token: 0x06003BDE RID: 15326 RVA: 0x0009D978 File Offset: 0x0009BB78
			public unsafe static void GetPointer<T1>(All pname, [In] [Out] ref T1 @params) where T1 : struct
			{
				fixed (T1* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[181]);
				}
			}

			// Token: 0x06003BDF RID: 15327 RVA: 0x0009D99C File Offset: 0x0009BB9C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public static void ObjectLabel(All identifier, int name, int length, string label)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), identifier, name, length, intPtr, GL.EntryPoints[236]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BE0 RID: 15328 RVA: 0x0009D9CC File Offset: 0x0009BBCC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public static void ObjectLabel(All identifier, uint name, int length, string label)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), identifier, name, length, intPtr, GL.EntryPoints[236]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BE1 RID: 15329 RVA: 0x0009D9FC File Offset: 0x0009BBFC
			[CLSCompliant(false)]
			public static void ObjectLabel(ObjectLabelIdentifier identifier, int name, int length, string label)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), identifier, name, length, intPtr, GL.EntryPoints[236]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BE2 RID: 15330 RVA: 0x0009DA2C File Offset: 0x0009BC2C
			[CLSCompliant(false)]
			public static void ObjectLabel(ObjectLabelIdentifier identifier, uint name, int length, string label)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), identifier, name, length, intPtr, GL.EntryPoints[236]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BE3 RID: 15331 RVA: 0x0009DA5C File Offset: 0x0009BC5C
			public static void ObjectPtrLabel(IntPtr ptr, int length, string label)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
				calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr, length, intPtr, GL.EntryPoints[238]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BE4 RID: 15332 RVA: 0x0009DA8C File Offset: 0x0009BC8C
			[CLSCompliant(false)]
			public unsafe static void ObjectPtrLabel<T0>([In] [Out] T0[] ptr, int length, string label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0] : ref *null)
				{
					T0* ptr3 = ptr2;
					IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
					calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr3, length, intPtr, GL.EntryPoints[238]);
					BindingsBase.FreeStringPtr(intPtr);
				}
			}

			// Token: 0x06003BE5 RID: 15333 RVA: 0x0009DAD0 File Offset: 0x0009BCD0
			[CLSCompliant(false)]
			public unsafe static void ObjectPtrLabel<T0>([In] [Out] T0[,] ptr, int length, string label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0] : ref *null)
				{
					T0* ptr3 = ptr2;
					IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
					calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr3, length, intPtr, GL.EntryPoints[238]);
					BindingsBase.FreeStringPtr(intPtr);
				}
			}

			// Token: 0x06003BE6 RID: 15334 RVA: 0x0009DB18 File Offset: 0x0009BD18
			[CLSCompliant(false)]
			public unsafe static void ObjectPtrLabel<T0>([In] [Out] T0[,,] ptr, int length, string label) where T0 : struct
			{
				fixed (T0* ptr2 = ref (ptr != null && ptr.Length != 0) ? ref ptr[0, 0, 0] : ref *null)
				{
					T0* ptr3 = ptr2;
					IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
					calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr3, length, intPtr, GL.EntryPoints[238]);
					BindingsBase.FreeStringPtr(intPtr);
				}
			}

			// Token: 0x06003BE7 RID: 15335 RVA: 0x0009DB60 File Offset: 0x0009BD60
			public unsafe static void ObjectPtrLabel<T0>([In] [Out] ref T0 ptr, int length, string label) where T0 : struct
			{
				fixed (T0* ptr2 = &ptr)
				{
					T0* ptr3 = ptr2;
					IntPtr intPtr = BindingsBase.MarshalStringToPtr(label);
					calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), ptr3, length, intPtr, GL.EntryPoints[238]);
					BindingsBase.FreeStringPtr(intPtr);
				}
			}

			// Token: 0x06003BE8 RID: 15336 RVA: 0x0009DB90 File Offset: 0x0009BD90
			public static void PopDebugGroup()
			{
				calli(System.Void(), GL.EntryPoints[243]);
			}

			// Token: 0x06003BE9 RID: 15337 RVA: 0x0009DBA4 File Offset: 0x0009BDA4
			[CLSCompliant(false)]
			public static void PushDebugGroup(All source, int id, int length, string message)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(message);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), source, id, length, intPtr, GL.EntryPoints[282]);
				BindingsBase.FreeStringPtr(intPtr);
			}

			// Token: 0x06003BEA RID: 15338 RVA: 0x0009DBD4 File Offset: 0x0009BDD4
			[CLSCompliant(false)]
			public static void PushDebugGroup(All source, uint id, int length, string message)
			{
				IntPtr intPtr = BindingsBase.MarshalStringToPtr(message);
				calli(System.Void(System.Int32,System.UInt32,System.Int32,System.IntPtr), source, id, length, intPtr, GL.EntryPoints[282]);
				BindingsBase.FreeStringPtr(intPtr);
			}
		}

		// Token: 0x0200050C RID: 1292
		public static class NV
		{
			// Token: 0x06003BEB RID: 15339 RVA: 0x0009DC04 File Offset: 0x0009BE04
			public static void BlendBarrier()
			{
				calli(System.Void(), GL.EntryPoints[16]);
			}

			// Token: 0x06003BEC RID: 15340 RVA: 0x0009DC14 File Offset: 0x0009BE14
			public static void BlendParameter(All pname, int value)
			{
				calli(System.Void(System.Int32,System.Int32), pname, value, GL.EntryPoints[27]);
			}

			// Token: 0x06003BED RID: 15341 RVA: 0x0009DC28 File Offset: 0x0009BE28
			[Obsolete("Use strongly-typed overload instead")]
			public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, All mask, All filter)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter, GL.EntryPoints[29]);
			}

			// Token: 0x06003BEE RID: 15342 RVA: 0x0009DC54 File Offset: 0x0009BE54
			public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter, GL.EntryPoints[29]);
			}

			// Token: 0x06003BEF RID: 15343 RVA: 0x0009DC80 File Offset: 0x0009BE80
			[Obsolete("Use strongly-typed overload instead")]
			public static void CopyBufferSubData(All readTarget, All writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), readTarget, writeTarget, readOffset, writeOffset, size, GL.EntryPoints[45]);
			}

			// Token: 0x06003BF0 RID: 15344 RVA: 0x0009DC98 File Offset: 0x0009BE98
			public static void CopyBufferSubData(BufferTarget readTarget, BufferTarget writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), readTarget, writeTarget, readOffset, writeOffset, size, GL.EntryPoints[45]);
			}

			// Token: 0x06003BF1 RID: 15345 RVA: 0x0009DCB0 File Offset: 0x0009BEB0
			public static void CoverageMask(bool mask)
			{
				calli(System.Void(System.Boolean), mask, GL.EntryPoints[51]);
			}

			// Token: 0x06003BF2 RID: 15346 RVA: 0x0009DCC0 File Offset: 0x0009BEC0
			public static void CoverageOperation(All operation)
			{
				calli(System.Void(System.Int32), operation, GL.EntryPoints[52]);
			}

			// Token: 0x06003BF3 RID: 15347 RVA: 0x0009DCD0 File Offset: 0x0009BED0
			[CLSCompliant(false)]
			public static void DeleteFence(int fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref fences, GL.EntryPoints[66]);
			}

			// Token: 0x06003BF4 RID: 15348 RVA: 0x0009DCE4 File Offset: 0x0009BEE4
			[CLSCompliant(false)]
			public static void DeleteFence(uint fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref fences, GL.EntryPoints[66]);
			}

			// Token: 0x06003BF5 RID: 15349 RVA: 0x0009DCF8 File Offset: 0x0009BEF8
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, int[] fences)
			{
				fixed (int* ptr = ref (fences != null && fences.Length != 0) ? ref fences[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[66]);
				}
			}

			// Token: 0x06003BF6 RID: 15350 RVA: 0x0009DD2C File Offset: 0x0009BF2C
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, ref int fences)
			{
				fixed (int* ptr = &fences)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[66]);
				}
			}

			// Token: 0x06003BF7 RID: 15351 RVA: 0x0009DD4C File Offset: 0x0009BF4C
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, int* fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, fences, GL.EntryPoints[66]);
			}

			// Token: 0x06003BF8 RID: 15352 RVA: 0x0009DD60 File Offset: 0x0009BF60
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, uint[] fences)
			{
				fixed (uint* ptr = ref (fences != null && fences.Length != 0) ? ref fences[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[66]);
				}
			}

			// Token: 0x06003BF9 RID: 15353 RVA: 0x0009DD94 File Offset: 0x0009BF94
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, ref uint fences)
			{
				fixed (uint* ptr = &fences)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[66]);
				}
			}

			// Token: 0x06003BFA RID: 15354 RVA: 0x0009DDB4 File Offset: 0x0009BFB4
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, uint* fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, fences, GL.EntryPoints[66]);
			}

			// Token: 0x06003BFB RID: 15355 RVA: 0x0009DDC8 File Offset: 0x0009BFC8
			[Obsolete("Use strongly-typed overload instead")]
			public static void DrawArraysInstanced(All mode, int first, int count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), mode, first, count, primcount, GL.EntryPoints[90]);
			}

			// Token: 0x06003BFC RID: 15356 RVA: 0x0009DDDC File Offset: 0x0009BFDC
			public static void DrawArraysInstanced(PrimitiveType mode, int first, int count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), mode, first, count, primcount, GL.EntryPoints[90]);
			}

			// Token: 0x06003BFD RID: 15357 RVA: 0x0009DDF0 File Offset: 0x0009BFF0
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawBuffers(int n, All[] bufs)
			{
				fixed (All* ptr = ref (bufs != null && bufs.Length != 0) ? ref bufs[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), n, ptr, GL.EntryPoints[93]);
				}
			}

			// Token: 0x06003BFE RID: 15358 RVA: 0x0009DE24 File Offset: 0x0009C024
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void DrawBuffers(int n, ref All bufs)
			{
				fixed (All* ptr = &bufs)
				{
					calli(System.Void(System.Int32,System.Int32*), n, ptr, GL.EntryPoints[93]);
				}
			}

			// Token: 0x06003BFF RID: 15359 RVA: 0x0009DE44 File Offset: 0x0009C044
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawBuffers(int n, All* bufs)
			{
				calli(System.Void(System.Int32,System.Int32*), n, bufs, GL.EntryPoints[93]);
			}

			// Token: 0x06003C00 RID: 15360 RVA: 0x0009DE58 File Offset: 0x0009C058
			[CLSCompliant(false)]
			public unsafe static void DrawBuffers(int n, DrawBufferMode[] bufs)
			{
				fixed (DrawBufferMode* ptr = ref (bufs != null && bufs.Length != 0) ? ref bufs[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), n, ptr, GL.EntryPoints[93]);
				}
			}

			// Token: 0x06003C01 RID: 15361 RVA: 0x0009DE8C File Offset: 0x0009C08C
			[CLSCompliant(false)]
			public unsafe static void DrawBuffers(int n, ref DrawBufferMode bufs)
			{
				fixed (DrawBufferMode* ptr = &bufs)
				{
					calli(System.Void(System.Int32,System.Int32*), n, ptr, GL.EntryPoints[93]);
				}
			}

			// Token: 0x06003C02 RID: 15362 RVA: 0x0009DEAC File Offset: 0x0009C0AC
			[CLSCompliant(false)]
			public unsafe static void DrawBuffers(int n, DrawBufferMode* bufs)
			{
				calli(System.Void(System.Int32,System.Int32*), n, bufs, GL.EntryPoints[93]);
			}

			// Token: 0x06003C03 RID: 15363 RVA: 0x0009DEC0 File Offset: 0x0009C0C0
			[Obsolete("Use strongly-typed overload instead")]
			public static void DrawElementsInstanced(All mode, int count, All type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[97]);
			}

			// Token: 0x06003C04 RID: 15364 RVA: 0x0009DED8 File Offset: 0x0009C0D8
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[97]);
				}
			}

			// Token: 0x06003C05 RID: 15365 RVA: 0x0009DF10 File Offset: 0x0009C110
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[97]);
				}
			}

			// Token: 0x06003C06 RID: 15366 RVA: 0x0009DF4C File Offset: 0x0009C14C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[97]);
				}
			}

			// Token: 0x06003C07 RID: 15367 RVA: 0x0009DF88 File Offset: 0x0009C188
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void DrawElementsInstanced<T3>(All mode, int count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[97]);
				}
			}

			// Token: 0x06003C08 RID: 15368 RVA: 0x0009DFAC File Offset: 0x0009C1AC
			public static void DrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[97]);
			}

			// Token: 0x06003C09 RID: 15369 RVA: 0x0009DFC4 File Offset: 0x0009C1C4
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[97]);
				}
			}

			// Token: 0x06003C0A RID: 15370 RVA: 0x0009DFFC File Offset: 0x0009C1FC
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[97]);
				}
			}

			// Token: 0x06003C0B RID: 15371 RVA: 0x0009E038 File Offset: 0x0009C238
			[CLSCompliant(false)]
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[97]);
				}
			}

			// Token: 0x06003C0C RID: 15372 RVA: 0x0009E074 File Offset: 0x0009C274
			public unsafe static void DrawElementsInstanced<T3>(PrimitiveType mode, int count, DrawElementsType type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[97]);
				}
			}

			// Token: 0x06003C0D RID: 15373 RVA: 0x0009E098 File Offset: 0x0009C298
			[CLSCompliant(false)]
			public static void FinishFence(int fence)
			{
				calli(System.Void(System.UInt32), fence, GL.EntryPoints[122]);
			}

			// Token: 0x06003C0E RID: 15374 RVA: 0x0009E0A8 File Offset: 0x0009C2A8
			[CLSCompliant(false)]
			public static void FinishFence(uint fence)
			{
				calli(System.Void(System.UInt32), fence, GL.EntryPoints[122]);
			}

			// Token: 0x06003C0F RID: 15375 RVA: 0x0009E0B8 File Offset: 0x0009C2B8
			[CLSCompliant(false)]
			public static int GenFence()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[134]);
				return result;
			}

			// Token: 0x06003C10 RID: 15376 RVA: 0x0009E0DC File Offset: 0x0009C2DC
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, [Out] int[] fences)
			{
				fixed (int* ptr = ref (fences != null && fences.Length != 0) ? ref fences[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[134]);
				}
			}

			// Token: 0x06003C11 RID: 15377 RVA: 0x0009E110 File Offset: 0x0009C310
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, out int fences)
			{
				fixed (int* ptr = &fences)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[134]);
				}
			}

			// Token: 0x06003C12 RID: 15378 RVA: 0x0009E134 File Offset: 0x0009C334
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, [Out] int* fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, fences, GL.EntryPoints[134]);
			}

			// Token: 0x06003C13 RID: 15379 RVA: 0x0009E148 File Offset: 0x0009C348
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, [Out] uint[] fences)
			{
				fixed (uint* ptr = ref (fences != null && fences.Length != 0) ? ref fences[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[134]);
				}
			}

			// Token: 0x06003C14 RID: 15380 RVA: 0x0009E17C File Offset: 0x0009C37C
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, out uint fences)
			{
				fixed (uint* ptr = &fences)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[134]);
				}
			}

			// Token: 0x06003C15 RID: 15381 RVA: 0x0009E1A0 File Offset: 0x0009C3A0
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, [Out] uint* fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, fences, GL.EntryPoints[134]);
			}

			// Token: 0x06003C16 RID: 15382 RVA: 0x0009E1B4 File Offset: 0x0009C3B4
			[CLSCompliant(false)]
			public unsafe static void GetFence(int fence, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, ptr, GL.EntryPoints[154]);
				}
			}

			// Token: 0x06003C17 RID: 15383 RVA: 0x0009E1EC File Offset: 0x0009C3EC
			[CLSCompliant(false)]
			public unsafe static void GetFence(int fence, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, ptr, GL.EntryPoints[154]);
				}
			}

			// Token: 0x06003C18 RID: 15384 RVA: 0x0009E210 File Offset: 0x0009C410
			[CLSCompliant(false)]
			public unsafe static void GetFence(int fence, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, @params, GL.EntryPoints[154]);
			}

			// Token: 0x06003C19 RID: 15385 RVA: 0x0009E228 File Offset: 0x0009C428
			[CLSCompliant(false)]
			public unsafe static void GetFence(uint fence, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, ptr, GL.EntryPoints[154]);
				}
			}

			// Token: 0x06003C1A RID: 15386 RVA: 0x0009E260 File Offset: 0x0009C460
			[CLSCompliant(false)]
			public unsafe static void GetFence(uint fence, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, ptr, GL.EntryPoints[154]);
				}
			}

			// Token: 0x06003C1B RID: 15387 RVA: 0x0009E284 File Offset: 0x0009C484
			[CLSCompliant(false)]
			public unsafe static void GetFence(uint fence, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, @params, GL.EntryPoints[154]);
			}

			// Token: 0x06003C1C RID: 15388 RVA: 0x0009E29C File Offset: 0x0009C49C
			[CLSCompliant(false)]
			public static bool IsFence(int fence)
			{
				return calli(System.Byte(System.UInt32), fence, GL.EntryPoints[217]);
			}

			// Token: 0x06003C1D RID: 15389 RVA: 0x0009E2B0 File Offset: 0x0009C4B0
			[CLSCompliant(false)]
			public static bool IsFence(uint fence)
			{
				return calli(System.Byte(System.UInt32), fence, GL.EntryPoints[217]);
			}

			// Token: 0x06003C1E RID: 15390 RVA: 0x0009E2C4 File Offset: 0x0009C4C4
			public static void ReadBuffer(All mode)
			{
				calli(System.Void(System.Int32), mode, GL.EntryPoints[286]);
			}

			// Token: 0x06003C1F RID: 15391 RVA: 0x0009E2D8 File Offset: 0x0009C4D8
			[Obsolete("Use strongly-typed overload instead")]
			public static void RenderbufferStorageMultisample(All target, int samples, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[295]);
			}

			// Token: 0x06003C20 RID: 15392 RVA: 0x0009E2F0 File Offset: 0x0009C4F0
			public static void RenderbufferStorageMultisample(RenderbufferTarget target, int samples, RenderbufferInternalFormat internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[295]);
			}

			// Token: 0x06003C21 RID: 15393 RVA: 0x0009E308 File Offset: 0x0009C508
			[CLSCompliant(false)]
			public static void SetFence(int fence, All condition)
			{
				calli(System.Void(System.UInt32,System.Int32), fence, condition, GL.EntryPoints[302]);
			}

			// Token: 0x06003C22 RID: 15394 RVA: 0x0009E31C File Offset: 0x0009C51C
			[CLSCompliant(false)]
			public static void SetFence(uint fence, All condition)
			{
				calli(System.Void(System.UInt32,System.Int32), fence, condition, GL.EntryPoints[302]);
			}

			// Token: 0x06003C23 RID: 15395 RVA: 0x0009E330 File Offset: 0x0009C530
			[CLSCompliant(false)]
			public static bool TestFence(int fence)
			{
				return calli(System.Byte(System.UInt32), fence, GL.EntryPoints[312]);
			}

			// Token: 0x06003C24 RID: 15396 RVA: 0x0009E344 File Offset: 0x0009C544
			[CLSCompliant(false)]
			public static bool TestFence(uint fence)
			{
				return calli(System.Byte(System.UInt32), fence, GL.EntryPoints[312]);
			}

			// Token: 0x06003C25 RID: 15397 RVA: 0x0009E358 File Offset: 0x0009C558
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix2x3(int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[350]);
				}
			}

			// Token: 0x06003C26 RID: 15398 RVA: 0x0009E390 File Offset: 0x0009C590
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix2x3(int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[350]);
				}
			}

			// Token: 0x06003C27 RID: 15399 RVA: 0x0009E3B4 File Offset: 0x0009C5B4
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix2x3(int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[350]);
			}

			// Token: 0x06003C28 RID: 15400 RVA: 0x0009E3CC File Offset: 0x0009C5CC
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix2x4(int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[351]);
				}
			}

			// Token: 0x06003C29 RID: 15401 RVA: 0x0009E404 File Offset: 0x0009C604
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix2x4(int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[351]);
				}
			}

			// Token: 0x06003C2A RID: 15402 RVA: 0x0009E428 File Offset: 0x0009C628
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix2x4(int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[351]);
			}

			// Token: 0x06003C2B RID: 15403 RVA: 0x0009E440 File Offset: 0x0009C640
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix3x2(int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[353]);
				}
			}

			// Token: 0x06003C2C RID: 15404 RVA: 0x0009E478 File Offset: 0x0009C678
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix3x2(int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[353]);
				}
			}

			// Token: 0x06003C2D RID: 15405 RVA: 0x0009E49C File Offset: 0x0009C69C
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix3x2(int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[353]);
			}

			// Token: 0x06003C2E RID: 15406 RVA: 0x0009E4B4 File Offset: 0x0009C6B4
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix3x4(int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[354]);
				}
			}

			// Token: 0x06003C2F RID: 15407 RVA: 0x0009E4EC File Offset: 0x0009C6EC
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix3x4(int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[354]);
				}
			}

			// Token: 0x06003C30 RID: 15408 RVA: 0x0009E510 File Offset: 0x0009C710
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix3x4(int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[354]);
			}

			// Token: 0x06003C31 RID: 15409 RVA: 0x0009E528 File Offset: 0x0009C728
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix4x2(int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[356]);
				}
			}

			// Token: 0x06003C32 RID: 15410 RVA: 0x0009E560 File Offset: 0x0009C760
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix4x2(int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[356]);
				}
			}

			// Token: 0x06003C33 RID: 15411 RVA: 0x0009E584 File Offset: 0x0009C784
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix4x2(int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[356]);
			}

			// Token: 0x06003C34 RID: 15412 RVA: 0x0009E59C File Offset: 0x0009C79C
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix4x3(int location, int count, bool transpose, float[] value)
			{
				fixed (float* ptr = ref (value != null && value.Length != 0) ? ref value[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[357]);
				}
			}

			// Token: 0x06003C35 RID: 15413 RVA: 0x0009E5D4 File Offset: 0x0009C7D4
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix4x3(int location, int count, bool transpose, ref float value)
			{
				fixed (float* ptr = &value)
				{
					calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, ptr, GL.EntryPoints[357]);
				}
			}

			// Token: 0x06003C36 RID: 15414 RVA: 0x0009E5F8 File Offset: 0x0009C7F8
			[CLSCompliant(false)]
			public unsafe static void UniformMatrix4x3(int location, int count, bool transpose, float* value)
			{
				calli(System.Void(System.Int32,System.Int32,System.Boolean,System.Single*), location, count, transpose, value, GL.EntryPoints[357]);
			}

			// Token: 0x06003C37 RID: 15415 RVA: 0x0009E610 File Offset: 0x0009C810
			[CLSCompliant(false)]
			public static void VertexAttribDivisor(int index, int divisor)
			{
				calli(System.Void(System.UInt32,System.UInt32), index, divisor, GL.EntryPoints[374]);
			}

			// Token: 0x06003C38 RID: 15416 RVA: 0x0009E624 File Offset: 0x0009C824
			[CLSCompliant(false)]
			public static void VertexAttribDivisor(uint index, uint divisor)
			{
				calli(System.Void(System.UInt32,System.UInt32), index, divisor, GL.EntryPoints[374]);
			}
		}

		// Token: 0x0200050D RID: 1293
		public static class Oes
		{
			// Token: 0x06003C39 RID: 15417 RVA: 0x0009E638 File Offset: 0x0009C838
			[CLSCompliant(false)]
			public static void BindVertexArray(int array)
			{
				calli(System.Void(System.UInt32), array, GL.EntryPoints[14]);
			}

			// Token: 0x06003C3A RID: 15418 RVA: 0x0009E648 File Offset: 0x0009C848
			[CLSCompliant(false)]
			public static void BindVertexArray(uint array)
			{
				calli(System.Void(System.UInt32), array, GL.EntryPoints[14]);
			}

			// Token: 0x06003C3B RID: 15419 RVA: 0x0009E658 File Offset: 0x0009C858
			[Obsolete("Use strongly-typed overload instead")]
			public static void CompressedTexImage3D(All target, int level, All internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, data, GL.EntryPoints[42]);
			}

			// Token: 0x06003C3C RID: 15420 RVA: 0x0009E680 File Offset: 0x0009C880
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void CompressedTexImage3D<T8>(All target, int level, All internalformat, int width, int height, int depth, int border, int imageSize, [In] [Out] T8[] data) where T8 : struct
			{
				fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, ptr, GL.EntryPoints[42]);
				}
			}

			// Token: 0x06003C3D RID: 15421 RVA: 0x0009E6C0 File Offset: 0x0009C8C0
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void CompressedTexImage3D<T8>(All target, int level, All internalformat, int width, int height, int depth, int border, int imageSize, [In] [Out] T8[,] data) where T8 : struct
			{
				fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, ptr, GL.EntryPoints[42]);
				}
			}

			// Token: 0x06003C3E RID: 15422 RVA: 0x0009E704 File Offset: 0x0009C904
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void CompressedTexImage3D<T8>(All target, int level, All internalformat, int width, int height, int depth, int border, int imageSize, [In] [Out] T8[,,] data) where T8 : struct
			{
				fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, ptr, GL.EntryPoints[42]);
				}
			}

			// Token: 0x06003C3F RID: 15423 RVA: 0x0009E748 File Offset: 0x0009C948
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void CompressedTexImage3D<T8>(All target, int level, All internalformat, int width, int height, int depth, int border, int imageSize, [In] [Out] ref T8 data) where T8 : struct
			{
				fixed (T8* ptr = &data)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, ptr, GL.EntryPoints[42]);
				}
			}

			// Token: 0x06003C40 RID: 15424 RVA: 0x0009E774 File Offset: 0x0009C974
			public static void CompressedTexImage3D(TextureTarget3d target, int level, CompressedInternalFormat internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, data, GL.EntryPoints[42]);
			}

			// Token: 0x06003C41 RID: 15425 RVA: 0x0009E79C File Offset: 0x0009C99C
			[CLSCompliant(false)]
			public unsafe static void CompressedTexImage3D<T8>(TextureTarget3d target, int level, CompressedInternalFormat internalformat, int width, int height, int depth, int border, int imageSize, [In] [Out] T8[] data) where T8 : struct
			{
				fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, ptr, GL.EntryPoints[42]);
				}
			}

			// Token: 0x06003C42 RID: 15426 RVA: 0x0009E7DC File Offset: 0x0009C9DC
			[CLSCompliant(false)]
			public unsafe static void CompressedTexImage3D<T8>(TextureTarget3d target, int level, CompressedInternalFormat internalformat, int width, int height, int depth, int border, int imageSize, [In] [Out] T8[,] data) where T8 : struct
			{
				fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, ptr, GL.EntryPoints[42]);
				}
			}

			// Token: 0x06003C43 RID: 15427 RVA: 0x0009E820 File Offset: 0x0009CA20
			[CLSCompliant(false)]
			public unsafe static void CompressedTexImage3D<T8>(TextureTarget3d target, int level, CompressedInternalFormat internalformat, int width, int height, int depth, int border, int imageSize, [In] [Out] T8[,,] data) where T8 : struct
			{
				fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, ptr, GL.EntryPoints[42]);
				}
			}

			// Token: 0x06003C44 RID: 15428 RVA: 0x0009E864 File Offset: 0x0009CA64
			public unsafe static void CompressedTexImage3D<T8>(TextureTarget3d target, int level, CompressedInternalFormat internalformat, int width, int height, int depth, int border, int imageSize, [In] [Out] ref T8 data) where T8 : struct
			{
				fixed (T8* ptr = &data)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, imageSize, ptr, GL.EntryPoints[42]);
				}
			}

			// Token: 0x06003C45 RID: 15429 RVA: 0x0009E890 File Offset: 0x0009CA90
			[Obsolete("Use strongly-typed overload instead")]
			public static void CompressedTexSubImage3D(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, IntPtr data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data, GL.EntryPoints[44]);
			}

			// Token: 0x06003C46 RID: 15430 RVA: 0x0009E8BC File Offset: 0x0009CABC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void CompressedTexSubImage3D<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, [In] [Out] T10[] data) where T10 : struct
			{
				fixed (T10* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x06003C47 RID: 15431 RVA: 0x0009E900 File Offset: 0x0009CB00
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void CompressedTexSubImage3D<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, [In] [Out] T10[,] data) where T10 : struct
			{
				fixed (T10* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x06003C48 RID: 15432 RVA: 0x0009E948 File Offset: 0x0009CB48
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void CompressedTexSubImage3D<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, [In] [Out] T10[,,] data) where T10 : struct
			{
				fixed (T10* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x06003C49 RID: 15433 RVA: 0x0009E990 File Offset: 0x0009CB90
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void CompressedTexSubImage3D<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, [In] [Out] ref T10 data) where T10 : struct
			{
				fixed (T10* ptr = &data)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x06003C4A RID: 15434 RVA: 0x0009E9C0 File Offset: 0x0009CBC0
			public static void CompressedTexSubImage3D(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, IntPtr data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data, GL.EntryPoints[44]);
			}

			// Token: 0x06003C4B RID: 15435 RVA: 0x0009E9EC File Offset: 0x0009CBEC
			[CLSCompliant(false)]
			public unsafe static void CompressedTexSubImage3D<T10>(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, [In] [Out] T10[] data) where T10 : struct
			{
				fixed (T10* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x06003C4C RID: 15436 RVA: 0x0009EA30 File Offset: 0x0009CC30
			[CLSCompliant(false)]
			public unsafe static void CompressedTexSubImage3D<T10>(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, [In] [Out] T10[,] data) where T10 : struct
			{
				fixed (T10* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x06003C4D RID: 15437 RVA: 0x0009EA78 File Offset: 0x0009CC78
			[CLSCompliant(false)]
			public unsafe static void CompressedTexSubImage3D<T10>(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, [In] [Out] T10[,,] data) where T10 : struct
			{
				fixed (T10* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x06003C4E RID: 15438 RVA: 0x0009EAC0 File Offset: 0x0009CCC0
			public unsafe static void CompressedTexSubImage3D<T10>(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, int imageSize, [In] [Out] ref T10 data) where T10 : struct
			{
				fixed (T10* ptr = &data)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x06003C4F RID: 15439 RVA: 0x0009EAF0 File Offset: 0x0009CCF0
			[Obsolete("Use strongly-typed overload instead")]
			public static void CopyTexSubImage3D(All target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, xoffset, yoffset, zoffset, x, y, width, height, GL.EntryPoints[49]);
			}

			// Token: 0x06003C50 RID: 15440 RVA: 0x0009EB18 File Offset: 0x0009CD18
			public static void CopyTexSubImage3D(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, xoffset, yoffset, zoffset, x, y, width, height, GL.EntryPoints[49]);
			}

			// Token: 0x06003C51 RID: 15441 RVA: 0x0009EB40 File Offset: 0x0009CD40
			[CLSCompliant(false)]
			public static void DeleteVertexArray(int arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref arrays, GL.EntryPoints[77]);
			}

			// Token: 0x06003C52 RID: 15442 RVA: 0x0009EB54 File Offset: 0x0009CD54
			[CLSCompliant(false)]
			public static void DeleteVertexArray(uint arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref arrays, GL.EntryPoints[77]);
			}

			// Token: 0x06003C53 RID: 15443 RVA: 0x0009EB68 File Offset: 0x0009CD68
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, int[] arrays)
			{
				fixed (int* ptr = ref (arrays != null && arrays.Length != 0) ? ref arrays[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[77]);
				}
			}

			// Token: 0x06003C54 RID: 15444 RVA: 0x0009EB9C File Offset: 0x0009CD9C
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, ref int arrays)
			{
				fixed (int* ptr = &arrays)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[77]);
				}
			}

			// Token: 0x06003C55 RID: 15445 RVA: 0x0009EBBC File Offset: 0x0009CDBC
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, int* arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, arrays, GL.EntryPoints[77]);
			}

			// Token: 0x06003C56 RID: 15446 RVA: 0x0009EBD0 File Offset: 0x0009CDD0
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, uint[] arrays)
			{
				fixed (uint* ptr = ref (arrays != null && arrays.Length != 0) ? ref arrays[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[77]);
				}
			}

			// Token: 0x06003C57 RID: 15447 RVA: 0x0009EC04 File Offset: 0x0009CE04
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, ref uint arrays)
			{
				fixed (uint* ptr = &arrays)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[77]);
				}
			}

			// Token: 0x06003C58 RID: 15448 RVA: 0x0009EC24 File Offset: 0x0009CE24
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, uint* arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, arrays, GL.EntryPoints[77]);
			}

			// Token: 0x06003C59 RID: 15449 RVA: 0x0009EC38 File Offset: 0x0009CE38
			public static void EGLImageTargetRenderbufferStorage(All target, IntPtr image)
			{
				calli(System.Void(System.Int32,System.IntPtr), target, image, GL.EntryPoints[98]);
			}

			// Token: 0x06003C5A RID: 15450 RVA: 0x0009EC4C File Offset: 0x0009CE4C
			public static void EGLImageTargetTexture2D(All target, IntPtr image)
			{
				calli(System.Void(System.Int32,System.IntPtr), target, image, GL.EntryPoints[99]);
			}

			// Token: 0x06003C5B RID: 15451 RVA: 0x0009EC60 File Offset: 0x0009CE60
			[CLSCompliant(false)]
			public static void FramebufferTexture3D(All target, All attachment, All textarget, int texture, int level, int zoffset)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, zoffset, GL.EntryPoints[129]);
			}

			// Token: 0x06003C5C RID: 15452 RVA: 0x0009EC7C File Offset: 0x0009CE7C
			[CLSCompliant(false)]
			public static void FramebufferTexture3D(All target, All attachment, All textarget, uint texture, int level, int zoffset)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, zoffset, GL.EntryPoints[129]);
			}

			// Token: 0x06003C5D RID: 15453 RVA: 0x0009EC98 File Offset: 0x0009CE98
			[CLSCompliant(false)]
			public static int GenVertexArray()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[141]);
				return result;
			}

			// Token: 0x06003C5E RID: 15454 RVA: 0x0009ECBC File Offset: 0x0009CEBC
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, [Out] int[] arrays)
			{
				fixed (int* ptr = ref (arrays != null && arrays.Length != 0) ? ref arrays[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[141]);
				}
			}

			// Token: 0x06003C5F RID: 15455 RVA: 0x0009ECF0 File Offset: 0x0009CEF0
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, out int arrays)
			{
				fixed (int* ptr = &arrays)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[141]);
				}
			}

			// Token: 0x06003C60 RID: 15456 RVA: 0x0009ED14 File Offset: 0x0009CF14
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, [Out] int* arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, arrays, GL.EntryPoints[141]);
			}

			// Token: 0x06003C61 RID: 15457 RVA: 0x0009ED28 File Offset: 0x0009CF28
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, [Out] uint[] arrays)
			{
				fixed (uint* ptr = ref (arrays != null && arrays.Length != 0) ? ref arrays[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[141]);
				}
			}

			// Token: 0x06003C62 RID: 15458 RVA: 0x0009ED5C File Offset: 0x0009CF5C
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, out uint arrays)
			{
				fixed (uint* ptr = &arrays)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[141]);
				}
			}

			// Token: 0x06003C63 RID: 15459 RVA: 0x0009ED80 File Offset: 0x0009CF80
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, [Out] uint* arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, arrays, GL.EntryPoints[141]);
			}

			// Token: 0x06003C64 RID: 15460 RVA: 0x0009ED94 File Offset: 0x0009CF94
			[Obsolete("Use strongly-typed overload instead")]
			public static void GetBufferPointer(All target, All pname, [Out] IntPtr @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, @params, GL.EntryPoints[148]);
			}

			// Token: 0x06003C65 RID: 15461 RVA: 0x0009EDAC File Offset: 0x0009CFAC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetBufferPointer<T2>(All target, All pname, [In] [Out] T2[] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003C66 RID: 15462 RVA: 0x0009EDE4 File Offset: 0x0009CFE4
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetBufferPointer<T2>(All target, All pname, [In] [Out] T2[,] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003C67 RID: 15463 RVA: 0x0009EE20 File Offset: 0x0009D020
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetBufferPointer<T2>(All target, All pname, [In] [Out] T2[,,] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003C68 RID: 15464 RVA: 0x0009EE5C File Offset: 0x0009D05C
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void GetBufferPointer<T2>(All target, All pname, [In] [Out] ref T2 @params) where T2 : struct
			{
				fixed (T2* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003C69 RID: 15465 RVA: 0x0009EE80 File Offset: 0x0009D080
			public static void GetBufferPointer(BufferTarget target, BufferPointer pname, [Out] IntPtr @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, @params, GL.EntryPoints[148]);
			}

			// Token: 0x06003C6A RID: 15466 RVA: 0x0009EE98 File Offset: 0x0009D098
			[CLSCompliant(false)]
			public unsafe static void GetBufferPointer<T2>(BufferTarget target, BufferPointer pname, [In] [Out] T2[] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003C6B RID: 15467 RVA: 0x0009EED0 File Offset: 0x0009D0D0
			[CLSCompliant(false)]
			public unsafe static void GetBufferPointer<T2>(BufferTarget target, BufferPointer pname, [In] [Out] T2[,] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003C6C RID: 15468 RVA: 0x0009EF0C File Offset: 0x0009D10C
			[CLSCompliant(false)]
			public unsafe static void GetBufferPointer<T2>(BufferTarget target, BufferPointer pname, [In] [Out] T2[,,] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003C6D RID: 15469 RVA: 0x0009EF48 File Offset: 0x0009D148
			public unsafe static void GetBufferPointer<T2>(BufferTarget target, BufferPointer pname, [In] [Out] ref T2 @params) where T2 : struct
			{
				fixed (T2* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003C6E RID: 15470 RVA: 0x0009EF6C File Offset: 0x0009D16C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary(int program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [Out] IntPtr binary)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr3, binary, GL.EntryPoints[182]);
					}
				}
			}

			// Token: 0x06003C6F RID: 15471 RVA: 0x0009EFBC File Offset: 0x0009D1BC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [In] [Out] T4[] binary) where T4 : struct
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C70 RID: 15472 RVA: 0x0009F020 File Offset: 0x0009D220
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [In] [Out] T4[,] binary) where T4 : struct
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C71 RID: 15473 RVA: 0x0009F088 File Offset: 0x0009D288
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [In] [Out] T4[,,] binary) where T4 : struct
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C72 RID: 15474 RVA: 0x0009F0F4 File Offset: 0x0009D2F4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [In] [Out] ref T4 binary) where T4 : struct
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = &binary)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C73 RID: 15475 RVA: 0x0009F144 File Offset: 0x0009D344
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary(int program, int bufSize, out int length, out All binaryFormat, [Out] IntPtr binary)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr3, binary, GL.EntryPoints[182]);
					}
				}
			}

			// Token: 0x06003C74 RID: 15476 RVA: 0x0009F170 File Offset: 0x0009D370
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, out int length, out All binaryFormat, [In] [Out] T4[] binary) where T4 : struct
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C75 RID: 15477 RVA: 0x0009F1B0 File Offset: 0x0009D3B0
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, out int length, out All binaryFormat, [In] [Out] T4[,] binary) where T4 : struct
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C76 RID: 15478 RVA: 0x0009F1F4 File Offset: 0x0009D3F4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, out int length, out All binaryFormat, [In] [Out] T4[,,] binary) where T4 : struct
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C77 RID: 15479 RVA: 0x0009F23C File Offset: 0x0009D43C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, out int length, out All binaryFormat, [In] [Out] ref T4 binary) where T4 : struct
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = &binary)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C78 RID: 15480 RVA: 0x0009F268 File Offset: 0x0009D468
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary(int program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [Out] IntPtr binary)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, binary, GL.EntryPoints[182]);
			}

			// Token: 0x06003C79 RID: 15481 RVA: 0x0009F280 File Offset: 0x0009D480
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [In] [Out] T4[] binary) where T4 : struct
			{
				fixed (T4* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, ptr, GL.EntryPoints[182]);
				}
			}

			// Token: 0x06003C7A RID: 15482 RVA: 0x0009F2BC File Offset: 0x0009D4BC
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [In] [Out] T4[,] binary) where T4 : struct
			{
				fixed (T4* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, ptr, GL.EntryPoints[182]);
				}
			}

			// Token: 0x06003C7B RID: 15483 RVA: 0x0009F2FC File Offset: 0x0009D4FC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [In] [Out] T4[,,] binary) where T4 : struct
			{
				fixed (T4* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, ptr, GL.EntryPoints[182]);
				}
			}

			// Token: 0x06003C7C RID: 15484 RVA: 0x0009F33C File Offset: 0x0009D53C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(int program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [In] [Out] ref T4 binary) where T4 : struct
			{
				fixed (T4* ptr = &binary)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, ptr, GL.EntryPoints[182]);
				}
			}

			// Token: 0x06003C7D RID: 15485 RVA: 0x0009F364 File Offset: 0x0009D564
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary(uint program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [Out] IntPtr binary)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr3, binary, GL.EntryPoints[182]);
					}
				}
			}

			// Token: 0x06003C7E RID: 15486 RVA: 0x0009F3B4 File Offset: 0x0009D5B4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [In] [Out] T4[] binary) where T4 : struct
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C7F RID: 15487 RVA: 0x0009F418 File Offset: 0x0009D618
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [In] [Out] T4[,] binary) where T4 : struct
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C80 RID: 15488 RVA: 0x0009F480 File Offset: 0x0009D680
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [In] [Out] T4[,,] binary) where T4 : struct
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C81 RID: 15489 RVA: 0x0009F4EC File Offset: 0x0009D6EC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, [Out] int[] length, [Out] All[] binaryFormat, [In] [Out] ref T4 binary) where T4 : struct
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = ref (binaryFormat != null && binaryFormat.Length != 0) ? ref binaryFormat[0] : ref *null)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = &binary)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C82 RID: 15490 RVA: 0x0009F53C File Offset: 0x0009D73C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary(uint program, int bufSize, out int length, out All binaryFormat, [Out] IntPtr binary)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr3, binary, GL.EntryPoints[182]);
					}
				}
			}

			// Token: 0x06003C83 RID: 15491 RVA: 0x0009F568 File Offset: 0x0009D768
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, out int length, out All binaryFormat, [In] [Out] T4[] binary) where T4 : struct
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C84 RID: 15492 RVA: 0x0009F5A8 File Offset: 0x0009D7A8
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, out int length, out All binaryFormat, [In] [Out] T4[,] binary) where T4 : struct
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C85 RID: 15493 RVA: 0x0009F5EC File Offset: 0x0009D7EC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, out int length, out All binaryFormat, [In] [Out] T4[,,] binary) where T4 : struct
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C86 RID: 15494 RVA: 0x0009F634 File Offset: 0x0009D834
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, out int length, out All binaryFormat, [In] [Out] ref T4 binary) where T4 : struct
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (All* ptr3 = &binaryFormat)
					{
						All* ptr4 = ptr3;
						fixed (T4* ptr5 = &binary)
						{
							calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, ptr2, ptr4, ptr5, GL.EntryPoints[182]);
						}
					}
				}
			}

			// Token: 0x06003C87 RID: 15495 RVA: 0x0009F660 File Offset: 0x0009D860
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary(uint program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [Out] IntPtr binary)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, binary, GL.EntryPoints[182]);
			}

			// Token: 0x06003C88 RID: 15496 RVA: 0x0009F678 File Offset: 0x0009D878
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [In] [Out] T4[] binary) where T4 : struct
			{
				fixed (T4* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, ptr, GL.EntryPoints[182]);
				}
			}

			// Token: 0x06003C89 RID: 15497 RVA: 0x0009F6B4 File Offset: 0x0009D8B4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [In] [Out] T4[,] binary) where T4 : struct
			{
				fixed (T4* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, ptr, GL.EntryPoints[182]);
				}
			}

			// Token: 0x06003C8A RID: 15498 RVA: 0x0009F6F4 File Offset: 0x0009D8F4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [In] [Out] T4[,,] binary) where T4 : struct
			{
				fixed (T4* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, ptr, GL.EntryPoints[182]);
				}
			}

			// Token: 0x06003C8B RID: 15499 RVA: 0x0009F734 File Offset: 0x0009D934
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void GetProgramBinary<T4>(uint program, int bufSize, [Out] int* length, [Out] All* binaryFormat, [In] [Out] ref T4 binary) where T4 : struct
			{
				fixed (T4* ptr = &binary)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.Int32*,System.IntPtr), program, bufSize, length, binaryFormat, ptr, GL.EntryPoints[182]);
				}
			}

			// Token: 0x06003C8C RID: 15500 RVA: 0x0009F75C File Offset: 0x0009D95C
			[CLSCompliant(false)]
			public static bool IsVertexArray(int array)
			{
				return calli(System.Byte(System.UInt32), array, GL.EntryPoints[226]);
			}

			// Token: 0x06003C8D RID: 15501 RVA: 0x0009F770 File Offset: 0x0009D970
			[CLSCompliant(false)]
			public static bool IsVertexArray(uint array)
			{
				return calli(System.Byte(System.UInt32), array, GL.EntryPoints[226]);
			}

			// Token: 0x06003C8E RID: 15502 RVA: 0x0009F784 File Offset: 0x0009D984
			public static IntPtr MapBuffer(All target, All access)
			{
				return calli(System.IntPtr(System.Int32,System.Int32), target, access, GL.EntryPoints[230]);
			}

			// Token: 0x06003C8F RID: 15503 RVA: 0x0009F798 File Offset: 0x0009D998
			public static void MinSampleShading(float value)
			{
				calli(System.Void(System.Single), value, GL.EntryPoints[232]);
			}

			// Token: 0x06003C90 RID: 15504 RVA: 0x0009F7AC File Offset: 0x0009D9AC
			[CLSCompliant(false)]
			public static void ProgramBinary(int program, All binaryFormat, IntPtr binary, int length)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, binary, length, GL.EntryPoints[246]);
			}

			// Token: 0x06003C91 RID: 15505 RVA: 0x0009F7C4 File Offset: 0x0009D9C4
			[CLSCompliant(false)]
			public unsafe static void ProgramBinary<T2>(int program, All binaryFormat, [In] [Out] T2[] binary, int length) where T2 : struct
			{
				fixed (T2* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, ptr, length, GL.EntryPoints[246]);
				}
			}

			// Token: 0x06003C92 RID: 15506 RVA: 0x0009F7FC File Offset: 0x0009D9FC
			[CLSCompliant(false)]
			public unsafe static void ProgramBinary<T2>(int program, All binaryFormat, [In] [Out] T2[,] binary, int length) where T2 : struct
			{
				fixed (T2* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, ptr, length, GL.EntryPoints[246]);
				}
			}

			// Token: 0x06003C93 RID: 15507 RVA: 0x0009F838 File Offset: 0x0009DA38
			[CLSCompliant(false)]
			public unsafe static void ProgramBinary<T2>(int program, All binaryFormat, [In] [Out] T2[,,] binary, int length) where T2 : struct
			{
				fixed (T2* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, ptr, length, GL.EntryPoints[246]);
				}
			}

			// Token: 0x06003C94 RID: 15508 RVA: 0x0009F874 File Offset: 0x0009DA74
			[CLSCompliant(false)]
			public unsafe static void ProgramBinary<T2>(int program, All binaryFormat, [In] [Out] ref T2 binary, int length) where T2 : struct
			{
				fixed (T2* ptr = &binary)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, ptr, length, GL.EntryPoints[246]);
				}
			}

			// Token: 0x06003C95 RID: 15509 RVA: 0x0009F898 File Offset: 0x0009DA98
			[CLSCompliant(false)]
			public static void ProgramBinary(uint program, All binaryFormat, IntPtr binary, int length)
			{
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, binary, length, GL.EntryPoints[246]);
			}

			// Token: 0x06003C96 RID: 15510 RVA: 0x0009F8B0 File Offset: 0x0009DAB0
			[CLSCompliant(false)]
			public unsafe static void ProgramBinary<T2>(uint program, All binaryFormat, [In] [Out] T2[] binary, int length) where T2 : struct
			{
				fixed (T2* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, ptr, length, GL.EntryPoints[246]);
				}
			}

			// Token: 0x06003C97 RID: 15511 RVA: 0x0009F8E8 File Offset: 0x0009DAE8
			[CLSCompliant(false)]
			public unsafe static void ProgramBinary<T2>(uint program, All binaryFormat, [In] [Out] T2[,] binary, int length) where T2 : struct
			{
				fixed (T2* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, ptr, length, GL.EntryPoints[246]);
				}
			}

			// Token: 0x06003C98 RID: 15512 RVA: 0x0009F924 File Offset: 0x0009DB24
			[CLSCompliant(false)]
			public unsafe static void ProgramBinary<T2>(uint program, All binaryFormat, [In] [Out] T2[,,] binary, int length) where T2 : struct
			{
				fixed (T2* ptr = ref (binary != null && binary.Length != 0) ? ref binary[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, ptr, length, GL.EntryPoints[246]);
				}
			}

			// Token: 0x06003C99 RID: 15513 RVA: 0x0009F960 File Offset: 0x0009DB60
			[CLSCompliant(false)]
			public unsafe static void ProgramBinary<T2>(uint program, All binaryFormat, [In] [Out] ref T2 binary, int length) where T2 : struct
			{
				fixed (T2* ptr = &binary)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32), program, binaryFormat, ptr, length, GL.EntryPoints[246]);
				}
			}

			// Token: 0x06003C9A RID: 15514 RVA: 0x0009F984 File Offset: 0x0009DB84
			[Obsolete("Use strongly-typed overload instead")]
			public static void TexImage3D(All target, int level, All internalformat, int width, int height, int depth, int border, All format, All type, IntPtr pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, pixels, GL.EntryPoints[316]);
			}

			// Token: 0x06003C9B RID: 15515 RVA: 0x0009F9B4 File Offset: 0x0009DBB4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexImage3D<T9>(All target, int level, All internalformat, int width, int height, int depth, int border, All format, All type, [In] [Out] T9[] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003C9C RID: 15516 RVA: 0x0009F9F8 File Offset: 0x0009DBF8
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexImage3D<T9>(All target, int level, All internalformat, int width, int height, int depth, int border, All format, All type, [In] [Out] T9[,] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003C9D RID: 15517 RVA: 0x0009FA40 File Offset: 0x0009DC40
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexImage3D<T9>(All target, int level, All internalformat, int width, int height, int depth, int border, All format, All type, [In] [Out] T9[,,] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003C9E RID: 15518 RVA: 0x0009FA8C File Offset: 0x0009DC8C
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexImage3D<T9>(All target, int level, All internalformat, int width, int height, int depth, int border, All format, All type, [In] [Out] ref T9 pixels) where T9 : struct
			{
				fixed (T9* ptr = &pixels)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003C9F RID: 15519 RVA: 0x0009FABC File Offset: 0x0009DCBC
			[Obsolete("Use strongly-typed overload instead")]
			public static void TexImage3D(All target, int level, int internalformat, int width, int height, int depth, int border, All format, All type, IntPtr pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, pixels, GL.EntryPoints[316]);
			}

			// Token: 0x06003CA0 RID: 15520 RVA: 0x0009FAEC File Offset: 0x0009DCEC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexImage3D<T9>(All target, int level, int internalformat, int width, int height, int depth, int border, All format, All type, [In] [Out] T9[] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CA1 RID: 15521 RVA: 0x0009FB30 File Offset: 0x0009DD30
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexImage3D<T9>(All target, int level, int internalformat, int width, int height, int depth, int border, All format, All type, [In] [Out] T9[,] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CA2 RID: 15522 RVA: 0x0009FB78 File Offset: 0x0009DD78
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexImage3D<T9>(All target, int level, int internalformat, int width, int height, int depth, int border, All format, All type, [In] [Out] T9[,,] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CA3 RID: 15523 RVA: 0x0009FBC4 File Offset: 0x0009DDC4
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexImage3D<T9>(All target, int level, int internalformat, int width, int height, int depth, int border, All format, All type, [In] [Out] ref T9 pixels) where T9 : struct
			{
				fixed (T9* ptr = &pixels)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CA4 RID: 15524 RVA: 0x0009FBF4 File Offset: 0x0009DDF4
			[Obsolete("Use strongly-typed overload instead")]
			public static void TexImage3D(TextureTarget3d target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, IntPtr pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, pixels, GL.EntryPoints[316]);
			}

			// Token: 0x06003CA5 RID: 15525 RVA: 0x0009FC24 File Offset: 0x0009DE24
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexImage3D<T9>(TextureTarget3d target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, [In] [Out] T9[] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CA6 RID: 15526 RVA: 0x0009FC68 File Offset: 0x0009DE68
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexImage3D<T9>(TextureTarget3d target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, [In] [Out] T9[,] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CA7 RID: 15527 RVA: 0x0009FCB0 File Offset: 0x0009DEB0
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexImage3D<T9>(TextureTarget3d target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, [In] [Out] T9[,,] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CA8 RID: 15528 RVA: 0x0009FCFC File Offset: 0x0009DEFC
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexImage3D<T9>(TextureTarget3d target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, [In] [Out] ref T9 pixels) where T9 : struct
			{
				fixed (T9* ptr = &pixels)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CA9 RID: 15529 RVA: 0x0009FD2C File Offset: 0x0009DF2C
			public static void TexImage3D(TextureTarget3d target, int level, TextureComponentCount internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, IntPtr pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, pixels, GL.EntryPoints[316]);
			}

			// Token: 0x06003CAA RID: 15530 RVA: 0x0009FD5C File Offset: 0x0009DF5C
			[CLSCompliant(false)]
			public unsafe static void TexImage3D<T9>(TextureTarget3d target, int level, TextureComponentCount internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, [In] [Out] T9[] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CAB RID: 15531 RVA: 0x0009FDA0 File Offset: 0x0009DFA0
			[CLSCompliant(false)]
			public unsafe static void TexImage3D<T9>(TextureTarget3d target, int level, TextureComponentCount internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, [In] [Out] T9[,] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CAC RID: 15532 RVA: 0x0009FDE8 File Offset: 0x0009DFE8
			[CLSCompliant(false)]
			public unsafe static void TexImage3D<T9>(TextureTarget3d target, int level, TextureComponentCount internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, [In] [Out] T9[,,] pixels) where T9 : struct
			{
				fixed (T9* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CAD RID: 15533 RVA: 0x0009FE34 File Offset: 0x0009E034
			public unsafe static void TexImage3D<T9>(TextureTarget3d target, int level, TextureComponentCount internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, [In] [Out] ref T9 pixels) where T9 : struct
			{
				fixed (T9* ptr = &pixels)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, depth, border, format, type, ptr, GL.EntryPoints[316]);
				}
			}

			// Token: 0x06003CAE RID: 15534 RVA: 0x0009FE64 File Offset: 0x0009E064
			public static void TexStorage3DMultisample(All target, int samples, All internalformat, int width, int height, int depth, bool fixedsamplelocations)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Boolean), target, samples, internalformat, width, height, depth, fixedsamplelocations, GL.EntryPoints[326]);
			}

			// Token: 0x06003CAF RID: 15535 RVA: 0x0009FE8C File Offset: 0x0009E08C
			[Obsolete("Use strongly-typed overload instead")]
			public static void TexSubImage3D(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, IntPtr pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels, GL.EntryPoints[328]);
			}

			// Token: 0x06003CB0 RID: 15536 RVA: 0x0009FEBC File Offset: 0x0009E0BC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexSubImage3D<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[] pixels) where T10 : struct
			{
				fixed (T10* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x06003CB1 RID: 15537 RVA: 0x0009FF04 File Offset: 0x0009E104
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexSubImage3D<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[,] pixels) where T10 : struct
			{
				fixed (T10* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x06003CB2 RID: 15538 RVA: 0x0009FF50 File Offset: 0x0009E150
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void TexSubImage3D<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[,,] pixels) where T10 : struct
			{
				fixed (T10* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x06003CB3 RID: 15539 RVA: 0x0009FF9C File Offset: 0x0009E19C
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void TexSubImage3D<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] ref T10 pixels) where T10 : struct
			{
				fixed (T10* ptr = &pixels)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x06003CB4 RID: 15540 RVA: 0x0009FFD0 File Offset: 0x0009E1D0
			public static void TexSubImage3D(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, IntPtr pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels, GL.EntryPoints[328]);
			}

			// Token: 0x06003CB5 RID: 15541 RVA: 0x000A0000 File Offset: 0x0009E200
			[CLSCompliant(false)]
			public unsafe static void TexSubImage3D<T10>(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[] pixels) where T10 : struct
			{
				fixed (T10* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x06003CB6 RID: 15542 RVA: 0x000A0048 File Offset: 0x0009E248
			[CLSCompliant(false)]
			public unsafe static void TexSubImage3D<T10>(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[,] pixels) where T10 : struct
			{
				fixed (T10* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x06003CB7 RID: 15543 RVA: 0x000A0094 File Offset: 0x0009E294
			[CLSCompliant(false)]
			public unsafe static void TexSubImage3D<T10>(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[,,] pixels) where T10 : struct
			{
				fixed (T10* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x06003CB8 RID: 15544 RVA: 0x000A00E0 File Offset: 0x0009E2E0
			public unsafe static void TexSubImage3D<T10>(TextureTarget3d target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] ref T10 pixels) where T10 : struct
			{
				fixed (T10* ptr = &pixels)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x06003CB9 RID: 15545 RVA: 0x000A0114 File Offset: 0x0009E314
			[Obsolete("Use strongly-typed overload instead")]
			public static bool UnmapBuffer(All target)
			{
				return calli(System.Byte(System.Int32), target, GL.EntryPoints[358]);
			}

			// Token: 0x06003CBA RID: 15546 RVA: 0x000A0128 File Offset: 0x0009E328
			public static bool UnmapBuffer(BufferTarget target)
			{
				return calli(System.Byte(System.Int32), target, GL.EntryPoints[358]);
			}
		}

		// Token: 0x0200050E RID: 1294
		public static class Qcom
		{
			// Token: 0x06003CBB RID: 15547 RVA: 0x000A013C File Offset: 0x0009E33C
			public static void AlphaFunc(All func, float @ref)
			{
				calli(System.Void(System.Int32,System.Single), func, @ref, GL.EntryPoints[3]);
			}

			// Token: 0x06003CBC RID: 15548 RVA: 0x000A014C File Offset: 0x0009E34C
			[CLSCompliant(false)]
			public static void DisableDriverControl(int driverControl)
			{
				calli(System.Void(System.UInt32), driverControl, GL.EntryPoints[83]);
			}

			// Token: 0x06003CBD RID: 15549 RVA: 0x000A015C File Offset: 0x0009E35C
			[CLSCompliant(false)]
			public static void DisableDriverControl(uint driverControl)
			{
				calli(System.Void(System.UInt32), driverControl, GL.EntryPoints[83]);
			}

			// Token: 0x06003CBE RID: 15550 RVA: 0x000A016C File Offset: 0x0009E36C
			[CLSCompliant(false)]
			public static void EnableDriverControl(int driverControl)
			{
				calli(System.Void(System.UInt32), driverControl, GL.EntryPoints[101]);
			}

			// Token: 0x06003CBF RID: 15551 RVA: 0x000A017C File Offset: 0x0009E37C
			[CLSCompliant(false)]
			public static void EnableDriverControl(uint driverControl)
			{
				calli(System.Void(System.UInt32), driverControl, GL.EntryPoints[101]);
			}

			// Token: 0x06003CC0 RID: 15552 RVA: 0x000A018C File Offset: 0x0009E38C
			[CLSCompliant(false)]
			public static void EndTiling(int preserveMask)
			{
				calli(System.Void(System.UInt32), preserveMask, GL.EntryPoints[107]);
			}

			// Token: 0x06003CC1 RID: 15553 RVA: 0x000A019C File Offset: 0x0009E39C
			[CLSCompliant(false)]
			public static void EndTiling(uint preserveMask)
			{
				calli(System.Void(System.UInt32), preserveMask, GL.EntryPoints[107]);
			}

			// Token: 0x06003CC2 RID: 15554 RVA: 0x000A01AC File Offset: 0x0009E3AC
			public static void ExtGetBufferPointer(All target, [Out] IntPtr @params)
			{
				calli(System.Void(System.Int32,System.IntPtr), target, @params, GL.EntryPoints[108]);
			}

			// Token: 0x06003CC3 RID: 15555 RVA: 0x000A01C0 File Offset: 0x0009E3C0
			[CLSCompliant(false)]
			public unsafe static void ExtGetBufferPointer<T1>(All target, [In] [Out] T1[] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), target, ptr, GL.EntryPoints[108]);
				}
			}

			// Token: 0x06003CC4 RID: 15556 RVA: 0x000A01F4 File Offset: 0x0009E3F4
			[CLSCompliant(false)]
			public unsafe static void ExtGetBufferPointer<T1>(All target, [In] [Out] T1[,] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), target, ptr, GL.EntryPoints[108]);
				}
			}

			// Token: 0x06003CC5 RID: 15557 RVA: 0x000A022C File Offset: 0x0009E42C
			[CLSCompliant(false)]
			public unsafe static void ExtGetBufferPointer<T1>(All target, [In] [Out] T1[,,] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), target, ptr, GL.EntryPoints[108]);
				}
			}

			// Token: 0x06003CC6 RID: 15558 RVA: 0x000A0264 File Offset: 0x0009E464
			public unsafe static void ExtGetBufferPointer<T1>(All target, [In] [Out] ref T1 @params) where T1 : struct
			{
				fixed (T1* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.IntPtr), target, ptr, GL.EntryPoints[108]);
				}
			}

			// Token: 0x06003CC7 RID: 15559 RVA: 0x000A0284 File Offset: 0x0009E484
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetBuffers([Out] int[] buffers, int maxBuffers, [Out] int[] numBuffers)
			{
				fixed (int* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numBuffers != null && numBuffers.Length != 0) ? ref numBuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[109]);
					}
				}
			}

			// Token: 0x06003CC8 RID: 15560 RVA: 0x000A02CC File Offset: 0x0009E4CC
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers([Out] int[] buffers, int maxBuffers, out int numBuffers)
			{
				fixed (int* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numBuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[109]);
					}
				}
			}

			// Token: 0x06003CC9 RID: 15561 RVA: 0x000A0304 File Offset: 0x0009E504
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers(out int buffers, int maxBuffers, out int numBuffers)
			{
				fixed (int* ptr = &buffers)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numBuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[109]);
					}
				}
			}

			// Token: 0x06003CCA RID: 15562 RVA: 0x000A0328 File Offset: 0x0009E528
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers([Out] int* buffers, int maxBuffers, [Out] int* numBuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), buffers, maxBuffers, numBuffers, GL.EntryPoints[109]);
			}

			// Token: 0x06003CCB RID: 15563 RVA: 0x000A033C File Offset: 0x0009E53C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetBuffers([Out] uint[] buffers, int maxBuffers, [Out] int[] numBuffers)
			{
				fixed (uint* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numBuffers != null && numBuffers.Length != 0) ? ref numBuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[109]);
					}
				}
			}

			// Token: 0x06003CCC RID: 15564 RVA: 0x000A0384 File Offset: 0x0009E584
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers([Out] uint[] buffers, int maxBuffers, out int numBuffers)
			{
				fixed (uint* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numBuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[109]);
					}
				}
			}

			// Token: 0x06003CCD RID: 15565 RVA: 0x000A03BC File Offset: 0x0009E5BC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers(out uint buffers, int maxBuffers, out int numBuffers)
			{
				fixed (uint* ptr = &buffers)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numBuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[109]);
					}
				}
			}

			// Token: 0x06003CCE RID: 15566 RVA: 0x000A03E0 File Offset: 0x0009E5E0
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetBuffers([Out] uint* buffers, int maxBuffers, [Out] int* numBuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), buffers, maxBuffers, numBuffers, GL.EntryPoints[109]);
			}

			// Token: 0x06003CCF RID: 15567 RVA: 0x000A03F4 File Offset: 0x0009E5F4
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetFramebuffers([Out] int[] framebuffers, int maxFramebuffers, [Out] int[] numFramebuffers)
			{
				fixed (int* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numFramebuffers != null && numFramebuffers.Length != 0) ? ref numFramebuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[110]);
					}
				}
			}

			// Token: 0x06003CD0 RID: 15568 RVA: 0x000A043C File Offset: 0x0009E63C
			[CLSCompliant(false)]
			public unsafe static void ExtGetFramebuffers([Out] int[] framebuffers, int maxFramebuffers, out int numFramebuffers)
			{
				fixed (int* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numFramebuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[110]);
					}
				}
			}

			// Token: 0x06003CD1 RID: 15569 RVA: 0x000A0474 File Offset: 0x0009E674
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetFramebuffers(out int framebuffers, int maxFramebuffers, out int numFramebuffers)
			{
				fixed (int* ptr = &framebuffers)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numFramebuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[110]);
					}
				}
			}

			// Token: 0x06003CD2 RID: 15570 RVA: 0x000A0498 File Offset: 0x0009E698
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers([Out] int* framebuffers, int maxFramebuffers, [Out] int* numFramebuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), framebuffers, maxFramebuffers, numFramebuffers, GL.EntryPoints[110]);
			}

			// Token: 0x06003CD3 RID: 15571 RVA: 0x000A04AC File Offset: 0x0009E6AC
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers([Out] uint[] framebuffers, int maxFramebuffers, [Out] int[] numFramebuffers)
			{
				fixed (uint* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numFramebuffers != null && numFramebuffers.Length != 0) ? ref numFramebuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[110]);
					}
				}
			}

			// Token: 0x06003CD4 RID: 15572 RVA: 0x000A04F4 File Offset: 0x0009E6F4
			[CLSCompliant(false)]
			public unsafe static void ExtGetFramebuffers([Out] uint[] framebuffers, int maxFramebuffers, out int numFramebuffers)
			{
				fixed (uint* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numFramebuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[110]);
					}
				}
			}

			// Token: 0x06003CD5 RID: 15573 RVA: 0x000A052C File Offset: 0x0009E72C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers(out uint framebuffers, int maxFramebuffers, out int numFramebuffers)
			{
				fixed (uint* ptr = &framebuffers)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numFramebuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[110]);
					}
				}
			}

			// Token: 0x06003CD6 RID: 15574 RVA: 0x000A0550 File Offset: 0x0009E750
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers([Out] uint* framebuffers, int maxFramebuffers, [Out] int* numFramebuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), framebuffers, maxFramebuffers, numFramebuffers, GL.EntryPoints[110]);
			}

			// Token: 0x06003CD7 RID: 15575 RVA: 0x000A0564 File Offset: 0x0009E764
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(int program, All shadertype, [Out] StringBuilder source, [Out] int[] length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr2, ptr, GL.EntryPoints[111]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003CD8 RID: 15576 RVA: 0x000A05B0 File Offset: 0x0009E7B0
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(int program, All shadertype, [Out] StringBuilder source, out int length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = &length)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr2, ptr, GL.EntryPoints[111]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003CD9 RID: 15577 RVA: 0x000A05EC File Offset: 0x0009E7EC
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(int program, All shadertype, [Out] StringBuilder source, [Out] int* length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr, length, GL.EntryPoints[111]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003CDA RID: 15578 RVA: 0x000A0624 File Offset: 0x0009E824
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(uint program, All shadertype, [Out] StringBuilder source, [Out] int[] length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr2, ptr, GL.EntryPoints[111]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003CDB RID: 15579 RVA: 0x000A0670 File Offset: 0x0009E870
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(uint program, All shadertype, [Out] StringBuilder source, out int length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = &length)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr2, ptr, GL.EntryPoints[111]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003CDC RID: 15580 RVA: 0x000A06AC File Offset: 0x0009E8AC
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(uint program, All shadertype, [Out] StringBuilder source, [Out] int* length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr, length, GL.EntryPoints[111]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003CDD RID: 15581 RVA: 0x000A06E4 File Offset: 0x0009E8E4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetProgram([Out] int[] programs, int maxPrograms, [Out] int[] numPrograms)
			{
				fixed (int* ptr = ref (programs != null && programs.Length != 0) ? ref programs[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numPrograms != null && numPrograms.Length != 0) ? ref numPrograms[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[112]);
					}
				}
			}

			// Token: 0x06003CDE RID: 15582 RVA: 0x000A072C File Offset: 0x0009E92C
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgram([Out] int[] programs, int maxPrograms, out int numPrograms)
			{
				fixed (int* ptr = ref (programs != null && programs.Length != 0) ? ref programs[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numPrograms)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[112]);
					}
				}
			}

			// Token: 0x06003CDF RID: 15583 RVA: 0x000A0764 File Offset: 0x0009E964
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgram(out int programs, int maxPrograms, out int numPrograms)
			{
				fixed (int* ptr = &programs)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numPrograms)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[112]);
					}
				}
			}

			// Token: 0x06003CE0 RID: 15584 RVA: 0x000A0788 File Offset: 0x0009E988
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetProgram([Out] int* programs, int maxPrograms, [Out] int* numPrograms)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), programs, maxPrograms, numPrograms, GL.EntryPoints[112]);
			}

			// Token: 0x06003CE1 RID: 15585 RVA: 0x000A079C File Offset: 0x0009E99C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetProgram([Out] uint[] programs, int maxPrograms, [Out] int[] numPrograms)
			{
				fixed (uint* ptr = ref (programs != null && programs.Length != 0) ? ref programs[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numPrograms != null && numPrograms.Length != 0) ? ref numPrograms[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[112]);
					}
				}
			}

			// Token: 0x06003CE2 RID: 15586 RVA: 0x000A07E4 File Offset: 0x0009E9E4
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgram([Out] uint[] programs, int maxPrograms, out int numPrograms)
			{
				fixed (uint* ptr = ref (programs != null && programs.Length != 0) ? ref programs[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numPrograms)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[112]);
					}
				}
			}

			// Token: 0x06003CE3 RID: 15587 RVA: 0x000A081C File Offset: 0x0009EA1C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgram(out uint programs, int maxPrograms, out int numPrograms)
			{
				fixed (uint* ptr = &programs)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numPrograms)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[112]);
					}
				}
			}

			// Token: 0x06003CE4 RID: 15588 RVA: 0x000A0840 File Offset: 0x0009EA40
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetProgram([Out] uint* programs, int maxPrograms, [Out] int* numPrograms)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), programs, maxPrograms, numPrograms, GL.EntryPoints[112]);
			}

			// Token: 0x06003CE5 RID: 15589 RVA: 0x000A0854 File Offset: 0x0009EA54
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers([Out] int[] renderbuffers, int maxRenderbuffers, [Out] int[] numRenderbuffers)
			{
				fixed (int* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numRenderbuffers != null && numRenderbuffers.Length != 0) ? ref numRenderbuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[113]);
					}
				}
			}

			// Token: 0x06003CE6 RID: 15590 RVA: 0x000A089C File Offset: 0x0009EA9C
			[CLSCompliant(false)]
			public unsafe static void ExtGetRenderbuffers([Out] int[] renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
			{
				fixed (int* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numRenderbuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[113]);
					}
				}
			}

			// Token: 0x06003CE7 RID: 15591 RVA: 0x000A08D4 File Offset: 0x0009EAD4
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetRenderbuffers(out int renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
			{
				fixed (int* ptr = &renderbuffers)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numRenderbuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[113]);
					}
				}
			}

			// Token: 0x06003CE8 RID: 15592 RVA: 0x000A08F8 File Offset: 0x0009EAF8
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers([Out] int* renderbuffers, int maxRenderbuffers, [Out] int* numRenderbuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), renderbuffers, maxRenderbuffers, numRenderbuffers, GL.EntryPoints[113]);
			}

			// Token: 0x06003CE9 RID: 15593 RVA: 0x000A090C File Offset: 0x0009EB0C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers([Out] uint[] renderbuffers, int maxRenderbuffers, [Out] int[] numRenderbuffers)
			{
				fixed (uint* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numRenderbuffers != null && numRenderbuffers.Length != 0) ? ref numRenderbuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[113]);
					}
				}
			}

			// Token: 0x06003CEA RID: 15594 RVA: 0x000A0954 File Offset: 0x0009EB54
			[CLSCompliant(false)]
			public unsafe static void ExtGetRenderbuffers([Out] uint[] renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
			{
				fixed (uint* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numRenderbuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[113]);
					}
				}
			}

			// Token: 0x06003CEB RID: 15595 RVA: 0x000A098C File Offset: 0x0009EB8C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers(out uint renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
			{
				fixed (uint* ptr = &renderbuffers)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numRenderbuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[113]);
					}
				}
			}

			// Token: 0x06003CEC RID: 15596 RVA: 0x000A09B0 File Offset: 0x0009EBB0
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers([Out] uint* renderbuffers, int maxRenderbuffers, [Out] int* numRenderbuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), renderbuffers, maxRenderbuffers, numRenderbuffers, GL.EntryPoints[113]);
			}

			// Token: 0x06003CED RID: 15597 RVA: 0x000A09C4 File Offset: 0x0009EBC4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetShaders([Out] int[] shaders, int maxShaders, [Out] int[] numShaders)
			{
				fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numShaders != null && numShaders.Length != 0) ? ref numShaders[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[114]);
					}
				}
			}

			// Token: 0x06003CEE RID: 15598 RVA: 0x000A0A0C File Offset: 0x0009EC0C
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders([Out] int[] shaders, int maxShaders, out int numShaders)
			{
				fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numShaders)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[114]);
					}
				}
			}

			// Token: 0x06003CEF RID: 15599 RVA: 0x000A0A44 File Offset: 0x0009EC44
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders(out int shaders, int maxShaders, out int numShaders)
			{
				fixed (int* ptr = &shaders)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numShaders)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[114]);
					}
				}
			}

			// Token: 0x06003CF0 RID: 15600 RVA: 0x000A0A68 File Offset: 0x0009EC68
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetShaders([Out] int* shaders, int maxShaders, [Out] int* numShaders)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), shaders, maxShaders, numShaders, GL.EntryPoints[114]);
			}

			// Token: 0x06003CF1 RID: 15601 RVA: 0x000A0A7C File Offset: 0x0009EC7C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetShaders([Out] uint[] shaders, int maxShaders, [Out] int[] numShaders)
			{
				fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numShaders != null && numShaders.Length != 0) ? ref numShaders[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[114]);
					}
				}
			}

			// Token: 0x06003CF2 RID: 15602 RVA: 0x000A0AC4 File Offset: 0x0009ECC4
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders([Out] uint[] shaders, int maxShaders, out int numShaders)
			{
				fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numShaders)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[114]);
					}
				}
			}

			// Token: 0x06003CF3 RID: 15603 RVA: 0x000A0AFC File Offset: 0x0009ECFC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders(out uint shaders, int maxShaders, out int numShaders)
			{
				fixed (uint* ptr = &shaders)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numShaders)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[114]);
					}
				}
			}

			// Token: 0x06003CF4 RID: 15604 RVA: 0x000A0B20 File Offset: 0x0009ED20
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetShaders([Out] uint* shaders, int maxShaders, [Out] int* numShaders)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), shaders, maxShaders, numShaders, GL.EntryPoints[114]);
			}

			// Token: 0x06003CF5 RID: 15605 RVA: 0x000A0B34 File Offset: 0x0009ED34
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(int texture, All face, int level, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, ptr, GL.EntryPoints[115]);
				}
			}

			// Token: 0x06003CF6 RID: 15606 RVA: 0x000A0B6C File Offset: 0x0009ED6C
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(int texture, All face, int level, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, ptr, GL.EntryPoints[115]);
				}
			}

			// Token: 0x06003CF7 RID: 15607 RVA: 0x000A0B90 File Offset: 0x0009ED90
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(int texture, All face, int level, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, @params, GL.EntryPoints[115]);
			}

			// Token: 0x06003CF8 RID: 15608 RVA: 0x000A0BA8 File Offset: 0x0009EDA8
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(uint texture, All face, int level, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, ptr, GL.EntryPoints[115]);
				}
			}

			// Token: 0x06003CF9 RID: 15609 RVA: 0x000A0BE0 File Offset: 0x0009EDE0
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(uint texture, All face, int level, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, ptr, GL.EntryPoints[115]);
				}
			}

			// Token: 0x06003CFA RID: 15610 RVA: 0x000A0C04 File Offset: 0x0009EE04
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(uint texture, All face, int level, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, @params, GL.EntryPoints[115]);
			}

			// Token: 0x06003CFB RID: 15611 RVA: 0x000A0C1C File Offset: 0x0009EE1C
			public static void ExtGetTexSubImage(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [Out] IntPtr texels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, texels, GL.EntryPoints[116]);
			}

			// Token: 0x06003CFC RID: 15612 RVA: 0x000A0C48 File Offset: 0x0009EE48
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexSubImage<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[] texels) where T10 : struct
			{
				fixed (T10* ptr = ref (texels != null && texels.Length != 0) ? ref texels[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[116]);
				}
			}

			// Token: 0x06003CFD RID: 15613 RVA: 0x000A0C8C File Offset: 0x0009EE8C
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexSubImage<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[,] texels) where T10 : struct
			{
				fixed (T10* ptr = ref (texels != null && texels.Length != 0) ? ref texels[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[116]);
				}
			}

			// Token: 0x06003CFE RID: 15614 RVA: 0x000A0CD4 File Offset: 0x0009EED4
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexSubImage<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[,,] texels) where T10 : struct
			{
				fixed (T10* ptr = ref (texels != null && texels.Length != 0) ? ref texels[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[116]);
				}
			}

			// Token: 0x06003CFF RID: 15615 RVA: 0x000A0D1C File Offset: 0x0009EF1C
			public unsafe static void ExtGetTexSubImage<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] ref T10 texels) where T10 : struct
			{
				fixed (T10* ptr = &texels)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[116]);
				}
			}

			// Token: 0x06003D00 RID: 15616 RVA: 0x000A0D4C File Offset: 0x0009EF4C
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures([Out] int[] textures, int maxTextures, [Out] int[] numTextures)
			{
				fixed (int* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numTextures != null && numTextures.Length != 0) ? ref numTextures[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxTextures, ptr3, GL.EntryPoints[117]);
					}
				}
			}

			// Token: 0x06003D01 RID: 15617 RVA: 0x000A0D94 File Offset: 0x0009EF94
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures(out int textures, int maxTextures, out int numTextures)
			{
				fixed (int* ptr = &textures)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numTextures)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxTextures, ptr3, GL.EntryPoints[117]);
					}
				}
			}

			// Token: 0x06003D02 RID: 15618 RVA: 0x000A0DB8 File Offset: 0x0009EFB8
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures([Out] int* textures, int maxTextures, [Out] int* numTextures)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), textures, maxTextures, numTextures, GL.EntryPoints[117]);
			}

			// Token: 0x06003D03 RID: 15619 RVA: 0x000A0DCC File Offset: 0x0009EFCC
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures([Out] uint[] textures, int maxTextures, [Out] int[] numTextures)
			{
				fixed (uint* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numTextures != null && numTextures.Length != 0) ? ref numTextures[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxTextures, ptr3, GL.EntryPoints[117]);
					}
				}
			}

			// Token: 0x06003D04 RID: 15620 RVA: 0x000A0E14 File Offset: 0x0009F014
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures(out uint textures, int maxTextures, out int numTextures)
			{
				fixed (uint* ptr = &textures)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numTextures)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxTextures, ptr3, GL.EntryPoints[117]);
					}
				}
			}

			// Token: 0x06003D05 RID: 15621 RVA: 0x000A0E38 File Offset: 0x0009F038
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures([Out] uint* textures, int maxTextures, [Out] int* numTextures)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), textures, maxTextures, numTextures, GL.EntryPoints[117]);
			}

			// Token: 0x06003D06 RID: 15622 RVA: 0x000A0E4C File Offset: 0x0009F04C
			[CLSCompliant(false)]
			public static bool ExtIsProgramBinary(int program)
			{
				return calli(System.Byte(System.UInt32), program, GL.EntryPoints[118]);
			}

			// Token: 0x06003D07 RID: 15623 RVA: 0x000A0E5C File Offset: 0x0009F05C
			[CLSCompliant(false)]
			public static bool ExtIsProgramBinary(uint program)
			{
				return calli(System.Byte(System.UInt32), program, GL.EntryPoints[118]);
			}

			// Token: 0x06003D08 RID: 15624 RVA: 0x000A0E6C File Offset: 0x0009F06C
			public static void ExtTexObjectStateOverride(All target, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[119]);
			}

			// Token: 0x06003D09 RID: 15625 RVA: 0x000A0E80 File Offset: 0x0009F080
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl([Out] int[] num, int size, [Out] int[] driverControls)
			{
				fixed (int* ptr = ref (num != null && num.Length != 0) ? ref num[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (driverControls != null && driverControls.Length != 0) ? ref driverControls[0] : ref *null)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, size, ptr3, GL.EntryPoints[151]);
					}
				}
			}

			// Token: 0x06003D0A RID: 15626 RVA: 0x000A0ECC File Offset: 0x0009F0CC
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl([Out] int[] num, int size, [Out] uint[] driverControls)
			{
				fixed (int* ptr = ref (num != null && num.Length != 0) ? ref num[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (uint* ptr3 = ref (driverControls != null && driverControls.Length != 0) ? ref driverControls[0] : ref *null)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, size, ptr3, GL.EntryPoints[151]);
					}
				}
			}

			// Token: 0x06003D0B RID: 15627 RVA: 0x000A0F18 File Offset: 0x0009F118
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl(out int num, int size, out int driverControls)
			{
				fixed (int* ptr = &num)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &driverControls)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, size, ptr3, GL.EntryPoints[151]);
					}
				}
			}

			// Token: 0x06003D0C RID: 15628 RVA: 0x000A0F40 File Offset: 0x0009F140
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl(out int num, int size, out uint driverControls)
			{
				fixed (int* ptr = &num)
				{
					int* ptr2 = ptr;
					fixed (uint* ptr3 = &driverControls)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, size, ptr3, GL.EntryPoints[151]);
					}
				}
			}

			// Token: 0x06003D0D RID: 15629 RVA: 0x000A0F68 File Offset: 0x0009F168
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl([Out] int* num, int size, [Out] int* driverControls)
			{
				calli(System.Void(System.Int32*,System.Int32,System.UInt32*), num, size, driverControls, GL.EntryPoints[151]);
			}

			// Token: 0x06003D0E RID: 15630 RVA: 0x000A0F80 File Offset: 0x0009F180
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl([Out] int* num, int size, [Out] uint* driverControls)
			{
				calli(System.Void(System.Int32*,System.Int32,System.UInt32*), num, size, driverControls, GL.EntryPoints[151]);
			}

			// Token: 0x06003D0F RID: 15631 RVA: 0x000A0F98 File Offset: 0x0009F198
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(int driverControl, int bufSize, [Out] int[] length, [Out] StringBuilder driverControlString)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, ptr2, intPtr, GL.EntryPoints[152]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003D10 RID: 15632 RVA: 0x000A0FE8 File Offset: 0x0009F1E8
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(int driverControl, int bufSize, out int length, [Out] StringBuilder driverControlString)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, ptr2, intPtr, GL.EntryPoints[152]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003D11 RID: 15633 RVA: 0x000A1028 File Offset: 0x0009F228
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(int driverControl, int bufSize, [Out] int* length, [Out] StringBuilder driverControlString)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, length, intPtr, GL.EntryPoints[152]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003D12 RID: 15634 RVA: 0x000A1064 File Offset: 0x0009F264
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(uint driverControl, int bufSize, [Out] int[] length, [Out] StringBuilder driverControlString)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, ptr2, intPtr, GL.EntryPoints[152]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003D13 RID: 15635 RVA: 0x000A10B4 File Offset: 0x0009F2B4
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(uint driverControl, int bufSize, out int length, [Out] StringBuilder driverControlString)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, ptr2, intPtr, GL.EntryPoints[152]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x06003D14 RID: 15636 RVA: 0x000A10F4 File Offset: 0x0009F2F4
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(uint driverControl, int bufSize, [Out] int* length, [Out] StringBuilder driverControlString)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, length, intPtr, GL.EntryPoints[152]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x06003D15 RID: 15637 RVA: 0x000A1130 File Offset: 0x0009F330
			[CLSCompliant(false)]
			public static void StartTiling(int x, int y, int width, int height, int preserveMask)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.UInt32,System.UInt32), x, y, width, height, preserveMask, GL.EntryPoints[305]);
			}

			// Token: 0x06003D16 RID: 15638 RVA: 0x000A1148 File Offset: 0x0009F348
			[CLSCompliant(false)]
			public static void StartTiling(uint x, uint y, uint width, uint height, uint preserveMask)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.UInt32,System.UInt32), x, y, width, height, preserveMask, GL.EntryPoints[305]);
			}
		}
	}
}
