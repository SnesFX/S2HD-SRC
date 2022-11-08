using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x020004FC RID: 1276
	public sealed class GL : GraphicsBindingsBase
	{
		// Token: 0x060031B6 RID: 12726 RVA: 0x00084444 File Offset: 0x00082644
		public GL()
		{
			this._EntryPointsInstance = GL.EntryPoints;
			this._EntryPointNamesInstance = GL.EntryPointNames;
			this._EntryPointNameOffsetsInstance = GL.EntryPointNameOffsets;
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060031B7 RID: 12727 RVA: 0x00084470 File Offset: 0x00082670
		protected override object SyncRoot
		{
			get
			{
				return GL.sync_root;
			}
		}

		// Token: 0x060031B8 RID: 12728 RVA: 0x00084478 File Offset: 0x00082678
		static GL()
		{
			GL.EntryPoints = new IntPtr[GL.EntryPointNameOffsets.Length];
		}

		// Token: 0x060031B9 RID: 12729 RVA: 0x000844D4 File Offset: 0x000826D4
		[Obsolete("Use strongly-typed overload instead")]
		public static void ActiveTexture(All texture)
		{
			calli(System.Void(System.Int32), texture, GL.EntryPoints[1]);
		}

		// Token: 0x060031BA RID: 12730 RVA: 0x000844E4 File Offset: 0x000826E4
		public static void ActiveTexture(TextureUnit texture)
		{
			calli(System.Void(System.Int32), texture, GL.EntryPoints[1]);
		}

		// Token: 0x060031BB RID: 12731 RVA: 0x000844F4 File Offset: 0x000826F4
		[Obsolete("Use strongly-typed overload instead")]
		public static void AlphaFunc(All func, float @ref)
		{
			calli(System.Void(System.Int32,System.Single), func, @ref, GL.EntryPoints[2]);
		}

		// Token: 0x060031BC RID: 12732 RVA: 0x00084504 File Offset: 0x00082704
		public static void AlphaFunc(AlphaFunction func, float @ref)
		{
			calli(System.Void(System.Int32,System.Single), func, @ref, GL.EntryPoints[2]);
		}

		// Token: 0x060031BD RID: 12733 RVA: 0x00084514 File Offset: 0x00082714
		public static void AlphaFuncx(All func, int @ref)
		{
			calli(System.Void(System.Int32,System.Int32), func, @ref, GL.EntryPoints[3]);
		}

		// Token: 0x060031BE RID: 12734 RVA: 0x00084524 File Offset: 0x00082724
		[CLSCompliant(false)]
		public static void BindBuffer(All target, int buffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, buffer, GL.EntryPoints[5]);
		}

		// Token: 0x060031BF RID: 12735 RVA: 0x00084534 File Offset: 0x00082734
		[CLSCompliant(false)]
		public static void BindBuffer(All target, uint buffer)
		{
			calli(System.Void(System.Int32,System.UInt32), target, buffer, GL.EntryPoints[5]);
		}

		// Token: 0x060031C0 RID: 12736 RVA: 0x00084544 File Offset: 0x00082744
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void BindTexture(All target, int texture)
		{
			calli(System.Void(System.Int32,System.UInt32), target, texture, GL.EntryPoints[8]);
		}

		// Token: 0x060031C1 RID: 12737 RVA: 0x00084554 File Offset: 0x00082754
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void BindTexture(All target, uint texture)
		{
			calli(System.Void(System.Int32,System.UInt32), target, texture, GL.EntryPoints[8]);
		}

		// Token: 0x060031C2 RID: 12738 RVA: 0x00084564 File Offset: 0x00082764
		[CLSCompliant(false)]
		public static void BindTexture(TextureTarget target, int texture)
		{
			calli(System.Void(System.Int32,System.UInt32), target, texture, GL.EntryPoints[8]);
		}

		// Token: 0x060031C3 RID: 12739 RVA: 0x00084574 File Offset: 0x00082774
		[CLSCompliant(false)]
		public static void BindTexture(TextureTarget target, uint texture)
		{
			calli(System.Void(System.Int32,System.UInt32), target, texture, GL.EntryPoints[8]);
		}

		// Token: 0x060031C4 RID: 12740 RVA: 0x00084584 File Offset: 0x00082784
		[Obsolete("Use strongly-typed overload instead")]
		public static void BlendFunc(All sfactor, All dfactor)
		{
			calli(System.Void(System.Int32,System.Int32), sfactor, dfactor, GL.EntryPoints[15]);
		}

		// Token: 0x060031C5 RID: 12741 RVA: 0x00084598 File Offset: 0x00082798
		public static void BlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor)
		{
			calli(System.Void(System.Int32,System.Int32), sfactor, dfactor, GL.EntryPoints[15]);
		}

		// Token: 0x060031C6 RID: 12742 RVA: 0x000845AC File Offset: 0x000827AC
		public static void BufferData(All target, IntPtr size, IntPtr data, All usage)
		{
			calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, data, usage, GL.EntryPoints[17]);
		}

		// Token: 0x060031C7 RID: 12743 RVA: 0x000845C0 File Offset: 0x000827C0
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(All target, IntPtr size, [In] [Out] T2[] data, All usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[17]);
			}
		}

		// Token: 0x060031C8 RID: 12744 RVA: 0x000845F4 File Offset: 0x000827F4
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(All target, IntPtr size, [In] [Out] T2[,] data, All usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[17]);
			}
		}

		// Token: 0x060031C9 RID: 12745 RVA: 0x0008462C File Offset: 0x0008282C
		[CLSCompliant(false)]
		public unsafe static void BufferData<T2>(All target, IntPtr size, [In] [Out] T2[,,] data, All usage) where T2 : struct
		{
			fixed (T2* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[17]);
			}
		}

		// Token: 0x060031CA RID: 12746 RVA: 0x00084664 File Offset: 0x00082864
		public unsafe static void BufferData<T2>(All target, IntPtr size, [In] [Out] ref T2 data, All usage) where T2 : struct
		{
			fixed (T2* ptr = &data)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.Int32), target, size, ptr, usage, GL.EntryPoints[17]);
			}
		}

		// Token: 0x060031CB RID: 12747 RVA: 0x00084688 File Offset: 0x00082888
		public static void BufferSubData(All target, IntPtr offset, IntPtr size, IntPtr data)
		{
			calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, data, GL.EntryPoints[18]);
		}

		// Token: 0x060031CC RID: 12748 RVA: 0x0008469C File Offset: 0x0008289C
		[CLSCompliant(false)]
		public unsafe static void BufferSubData<T3>(All target, IntPtr offset, IntPtr size, [In] [Out] T3[] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[18]);
			}
		}

		// Token: 0x060031CD RID: 12749 RVA: 0x000846D0 File Offset: 0x000828D0
		[CLSCompliant(false)]
		public unsafe static void BufferSubData<T3>(All target, IntPtr offset, IntPtr size, [In] [Out] T3[,] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[18]);
			}
		}

		// Token: 0x060031CE RID: 12750 RVA: 0x00084708 File Offset: 0x00082908
		[CLSCompliant(false)]
		public unsafe static void BufferSubData<T3>(All target, IntPtr offset, IntPtr size, [In] [Out] T3[,,] data) where T3 : struct
		{
			fixed (T3* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[18]);
			}
		}

		// Token: 0x060031CF RID: 12751 RVA: 0x00084740 File Offset: 0x00082940
		public unsafe static void BufferSubData<T3>(All target, IntPtr offset, IntPtr size, [In] [Out] ref T3 data) where T3 : struct
		{
			fixed (T3* ptr = &data)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr,System.IntPtr), target, offset, size, ptr, GL.EntryPoints[18]);
			}
		}

		// Token: 0x060031D0 RID: 12752 RVA: 0x00084764 File Offset: 0x00082964
		[Obsolete("Use strongly-typed overload instead")]
		public static void Clear(All mask)
		{
			calli(System.Void(System.Int32), mask, GL.EntryPoints[20]);
		}

		// Token: 0x060031D1 RID: 12753 RVA: 0x00084774 File Offset: 0x00082974
		public static void Clear(ClearBufferMask mask)
		{
			calli(System.Void(System.Int32), mask, GL.EntryPoints[20]);
		}

		// Token: 0x060031D2 RID: 12754 RVA: 0x00084784 File Offset: 0x00082984
		[Obsolete("Use ClearMask overload instead")]
		public static void Clear(uint mask)
		{
			calli(System.Void(System.Int32), mask, GL.EntryPoints[20]);
		}

		// Token: 0x060031D3 RID: 12755 RVA: 0x00084794 File Offset: 0x00082994
		public static void ClearColor(float red, float green, float blue, float alpha)
		{
			calli(System.Void(System.Single,System.Single,System.Single,System.Single), red, green, blue, alpha, GL.EntryPoints[22]);
		}

		// Token: 0x060031D4 RID: 12756 RVA: 0x000847A8 File Offset: 0x000829A8
		public static void ClearColorx(int red, int green, int blue, int alpha)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), red, green, blue, alpha, GL.EntryPoints[23]);
		}

		// Token: 0x060031D5 RID: 12757 RVA: 0x000847BC File Offset: 0x000829BC
		public static void ClearDepth(float d)
		{
			calli(System.Void(System.Single), d, GL.EntryPoints[25]);
		}

		// Token: 0x060031D6 RID: 12758 RVA: 0x000847CC File Offset: 0x000829CC
		public static void ClearDepthx(int depth)
		{
			calli(System.Void(System.Int32), depth, GL.EntryPoints[27]);
		}

		// Token: 0x060031D7 RID: 12759 RVA: 0x000847DC File Offset: 0x000829DC
		public static void ClearStencil(int s)
		{
			calli(System.Void(System.Int32), s, GL.EntryPoints[29]);
		}

		// Token: 0x060031D8 RID: 12760 RVA: 0x000847EC File Offset: 0x000829EC
		[Obsolete("Use strongly-typed overload instead")]
		public static void ClientActiveTexture(All texture)
		{
			calli(System.Void(System.Int32), texture, GL.EntryPoints[30]);
		}

		// Token: 0x060031D9 RID: 12761 RVA: 0x000847FC File Offset: 0x000829FC
		public static void ClientActiveTexture(TextureUnit texture)
		{
			calli(System.Void(System.Int32), texture, GL.EntryPoints[30]);
		}

		// Token: 0x060031DA RID: 12762 RVA: 0x0008480C File Offset: 0x00082A0C
		[CLSCompliant(false)]
		public unsafe static void ClipPlane(All p, float[] eqn)
		{
			fixed (float* ptr = ref (eqn != null && eqn.Length != 0) ? ref eqn[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), p, ptr, GL.EntryPoints[32]);
			}
		}

		// Token: 0x060031DB RID: 12763 RVA: 0x00084840 File Offset: 0x00082A40
		[CLSCompliant(false)]
		public unsafe static void ClipPlane(All p, ref float eqn)
		{
			fixed (float* ptr = &eqn)
			{
				calli(System.Void(System.Int32,System.Single*), p, ptr, GL.EntryPoints[32]);
			}
		}

		// Token: 0x060031DC RID: 12764 RVA: 0x00084860 File Offset: 0x00082A60
		[CLSCompliant(false)]
		public unsafe static void ClipPlane(All p, float* eqn)
		{
			calli(System.Void(System.Int32,System.Single*), p, eqn, GL.EntryPoints[32]);
		}

		// Token: 0x060031DD RID: 12765 RVA: 0x00084874 File Offset: 0x00082A74
		[CLSCompliant(false)]
		public unsafe static void ClipPlanex(All plane, int[] equation)
		{
			fixed (int* ptr = ref (equation != null && equation.Length != 0) ? ref equation[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), plane, ptr, GL.EntryPoints[35]);
			}
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x000848A8 File Offset: 0x00082AA8
		[CLSCompliant(false)]
		public unsafe static void ClipPlanex(All plane, ref int equation)
		{
			fixed (int* ptr = &equation)
			{
				calli(System.Void(System.Int32,System.Int32*), plane, ptr, GL.EntryPoints[35]);
			}
		}

		// Token: 0x060031DF RID: 12767 RVA: 0x000848C8 File Offset: 0x00082AC8
		[CLSCompliant(false)]
		public unsafe static void ClipPlanex(All plane, int* equation)
		{
			calli(System.Void(System.Int32,System.Int32*), plane, equation, GL.EntryPoints[35]);
		}

		// Token: 0x060031E0 RID: 12768 RVA: 0x000848DC File Offset: 0x00082ADC
		public static void Color4(float red, float green, float blue, float alpha)
		{
			calli(System.Void(System.Single,System.Single,System.Single,System.Single), red, green, blue, alpha, GL.EntryPoints[40]);
		}

		// Token: 0x060031E1 RID: 12769 RVA: 0x000848F0 File Offset: 0x00082AF0
		public static void Color4(byte red, byte green, byte blue, byte alpha)
		{
			calli(System.Void(System.Byte,System.Byte,System.Byte,System.Byte), red, green, blue, alpha, GL.EntryPoints[41]);
		}

		// Token: 0x060031E2 RID: 12770 RVA: 0x00084904 File Offset: 0x00082B04
		public static void Color4x(int red, int green, int blue, int alpha)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), red, green, blue, alpha, GL.EntryPoints[42]);
		}

		// Token: 0x060031E3 RID: 12771 RVA: 0x00084918 File Offset: 0x00082B18
		public static void ColorMask(bool red, bool green, bool blue, bool alpha)
		{
			calli(System.Void(System.Boolean,System.Boolean,System.Boolean,System.Boolean), red, green, blue, alpha, GL.EntryPoints[45]);
		}

		// Token: 0x060031E4 RID: 12772 RVA: 0x0008492C File Offset: 0x00082B2C
		[Obsolete("Use strongly-typed overload instead")]
		public static void ColorPointer(int size, All type, int stride, IntPtr pointer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, pointer, GL.EntryPoints[46]);
		}

		// Token: 0x060031E5 RID: 12773 RVA: 0x00084940 File Offset: 0x00082B40
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ColorPointer<T3>(int size, All type, int stride, [In] [Out] T3[] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[46]);
			}
		}

		// Token: 0x060031E6 RID: 12774 RVA: 0x00084974 File Offset: 0x00082B74
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ColorPointer<T3>(int size, All type, int stride, [In] [Out] T3[,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[46]);
			}
		}

		// Token: 0x060031E7 RID: 12775 RVA: 0x000849AC File Offset: 0x00082BAC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ColorPointer<T3>(int size, All type, int stride, [In] [Out] T3[,,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[46]);
			}
		}

		// Token: 0x060031E8 RID: 12776 RVA: 0x000849E4 File Offset: 0x00082BE4
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ColorPointer<T3>(int size, All type, int stride, [In] [Out] ref T3 pointer) where T3 : struct
		{
			fixed (T3* ptr = &pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[46]);
			}
		}

		// Token: 0x060031E9 RID: 12777 RVA: 0x00084A08 File Offset: 0x00082C08
		public static void ColorPointer(int size, ColorPointerType type, int stride, IntPtr pointer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, pointer, GL.EntryPoints[46]);
		}

		// Token: 0x060031EA RID: 12778 RVA: 0x00084A1C File Offset: 0x00082C1C
		[CLSCompliant(false)]
		public unsafe static void ColorPointer<T3>(int size, ColorPointerType type, int stride, [In] [Out] T3[] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[46]);
			}
		}

		// Token: 0x060031EB RID: 12779 RVA: 0x00084A50 File Offset: 0x00082C50
		[CLSCompliant(false)]
		public unsafe static void ColorPointer<T3>(int size, ColorPointerType type, int stride, [In] [Out] T3[,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[46]);
			}
		}

		// Token: 0x060031EC RID: 12780 RVA: 0x00084A88 File Offset: 0x00082C88
		[CLSCompliant(false)]
		public unsafe static void ColorPointer<T3>(int size, ColorPointerType type, int stride, [In] [Out] T3[,,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[46]);
			}
		}

		// Token: 0x060031ED RID: 12781 RVA: 0x00084AC0 File Offset: 0x00082CC0
		public unsafe static void ColorPointer<T3>(int size, ColorPointerType type, int stride, [In] [Out] ref T3 pointer) where T3 : struct
		{
			fixed (T3* ptr = &pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[46]);
			}
		}

		// Token: 0x060031EE RID: 12782 RVA: 0x00084AE4 File Offset: 0x00082CE4
		[Obsolete("Use strongly-typed overload instead")]
		public static void CompressedTexImage2D(All target, int level, All internalformat, int width, int height, int border, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, data, GL.EntryPoints[47]);
		}

		// Token: 0x060031EF RID: 12783 RVA: 0x00084B0C File Offset: 0x00082D0C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexImage2D<T7>(All target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[47]);
			}
		}

		// Token: 0x060031F0 RID: 12784 RVA: 0x00084B4C File Offset: 0x00082D4C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexImage2D<T7>(All target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[47]);
			}
		}

		// Token: 0x060031F1 RID: 12785 RVA: 0x00084B90 File Offset: 0x00082D90
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(All target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[47]);
			}
		}

		// Token: 0x060031F2 RID: 12786 RVA: 0x00084BD4 File Offset: 0x00082DD4
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexImage2D<T7>(All target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] ref T7 data) where T7 : struct
		{
			fixed (T7* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[47]);
			}
		}

		// Token: 0x060031F3 RID: 12787 RVA: 0x00084C00 File Offset: 0x00082E00
		public static void CompressedTexImage2D(TextureTarget target, int level, All internalformat, int width, int height, int border, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, data, GL.EntryPoints[47]);
		}

		// Token: 0x060031F4 RID: 12788 RVA: 0x00084C28 File Offset: 0x00082E28
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[47]);
			}
		}

		// Token: 0x060031F5 RID: 12789 RVA: 0x00084C68 File Offset: 0x00082E68
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[47]);
			}
		}

		// Token: 0x060031F6 RID: 12790 RVA: 0x00084CAC File Offset: 0x00082EAC
		[CLSCompliant(false)]
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] T7[,,] data) where T7 : struct
		{
			fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[47]);
			}
		}

		// Token: 0x060031F7 RID: 12791 RVA: 0x00084CF0 File Offset: 0x00082EF0
		public unsafe static void CompressedTexImage2D<T7>(TextureTarget target, int level, All internalformat, int width, int height, int border, int imageSize, [In] [Out] ref T7 data) where T7 : struct
		{
			fixed (T7* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, imageSize, ptr, GL.EntryPoints[47]);
			}
		}

		// Token: 0x060031F8 RID: 12792 RVA: 0x00084D1C File Offset: 0x00082F1C
		[Obsolete("Use strongly-typed overload instead")]
		public static void CompressedTexSubImage2D(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, data, GL.EntryPoints[48]);
		}

		// Token: 0x060031F9 RID: 12793 RVA: 0x00084D44 File Offset: 0x00082F44
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, [In] [Out] T8[] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[48]);
			}
		}

		// Token: 0x060031FA RID: 12794 RVA: 0x00084D84 File Offset: 0x00082F84
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void CompressedTexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, [In] [Out] T8[,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[48]);
			}
		}

		// Token: 0x060031FB RID: 12795 RVA: 0x00084DC8 File Offset: 0x00082FC8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, [In] [Out] T8[,,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[48]);
			}
		}

		// Token: 0x060031FC RID: 12796 RVA: 0x00084E0C File Offset: 0x0008300C
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void CompressedTexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, int imageSize, [In] [Out] ref T8 data) where T8 : struct
		{
			fixed (T8* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[48]);
			}
		}

		// Token: 0x060031FD RID: 12797 RVA: 0x00084E38 File Offset: 0x00083038
		public static void CompressedTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, IntPtr data)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, data, GL.EntryPoints[48]);
		}

		// Token: 0x060031FE RID: 12798 RVA: 0x00084E60 File Offset: 0x00083060
		[CLSCompliant(false)]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[48]);
			}
		}

		// Token: 0x060031FF RID: 12799 RVA: 0x00084EA0 File Offset: 0x000830A0
		[CLSCompliant(false)]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[48]);
			}
		}

		// Token: 0x06003200 RID: 12800 RVA: 0x00084EE4 File Offset: 0x000830E4
		[CLSCompliant(false)]
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] T8[,,] data) where T8 : struct
		{
			fixed (T8* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[48]);
			}
		}

		// Token: 0x06003201 RID: 12801 RVA: 0x00084F28 File Offset: 0x00083128
		public unsafe static void CompressedTexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, [In] [Out] ref T8 data) where T8 : struct
		{
			fixed (T8* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, imageSize, ptr, GL.EntryPoints[48]);
			}
		}

		// Token: 0x06003202 RID: 12802 RVA: 0x00084F54 File Offset: 0x00083154
		[Obsolete("Use strongly-typed overload instead")]
		public static void CopyTexImage2D(All target, int level, All internalformat, int x, int y, int width, int height, int border)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, internalformat, x, y, width, height, border, GL.EntryPoints[51]);
		}

		// Token: 0x06003203 RID: 12803 RVA: 0x00084F7C File Offset: 0x0008317C
		public static void CopyTexImage2D(TextureTarget target, int level, All internalformat, int x, int y, int width, int height, int border)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, internalformat, x, y, width, height, border, GL.EntryPoints[51]);
		}

		// Token: 0x06003204 RID: 12804 RVA: 0x00084FA4 File Offset: 0x000831A4
		[Obsolete("Use strongly-typed overload instead")]
		public static void CopyTexSubImage2D(All target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, xoffset, yoffset, x, y, width, height, GL.EntryPoints[52]);
		}

		// Token: 0x06003205 RID: 12805 RVA: 0x00084FCC File Offset: 0x000831CC
		public static void CopyTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, level, xoffset, yoffset, x, y, width, height, GL.EntryPoints[52]);
		}

		// Token: 0x06003206 RID: 12806 RVA: 0x00084FF4 File Offset: 0x000831F4
		[Obsolete("Use strongly-typed overload instead")]
		public static void CullFace(All mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[54]);
		}

		// Token: 0x06003207 RID: 12807 RVA: 0x00085004 File Offset: 0x00083204
		public static void CullFace(CullFaceMode mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[54]);
		}

		// Token: 0x06003208 RID: 12808 RVA: 0x00085014 File Offset: 0x00083214
		[CLSCompliant(false)]
		public static void DeleteBuffer(int buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref buffers, GL.EntryPoints[56]);
		}

		// Token: 0x06003209 RID: 12809 RVA: 0x00085028 File Offset: 0x00083228
		[CLSCompliant(false)]
		public static void DeleteBuffer(uint buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref buffers, GL.EntryPoints[56]);
		}

		// Token: 0x0600320A RID: 12810 RVA: 0x0008503C File Offset: 0x0008323C
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, int[] buffers)
		{
			fixed (int* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[56]);
			}
		}

		// Token: 0x0600320B RID: 12811 RVA: 0x00085070 File Offset: 0x00083270
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, ref int buffers)
		{
			fixed (int* ptr = &buffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[56]);
			}
		}

		// Token: 0x0600320C RID: 12812 RVA: 0x00085090 File Offset: 0x00083290
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, int* buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, buffers, GL.EntryPoints[56]);
		}

		// Token: 0x0600320D RID: 12813 RVA: 0x000850A4 File Offset: 0x000832A4
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, uint[] buffers)
		{
			fixed (uint* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[56]);
			}
		}

		// Token: 0x0600320E RID: 12814 RVA: 0x000850D8 File Offset: 0x000832D8
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, ref uint buffers)
		{
			fixed (uint* ptr = &buffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[56]);
			}
		}

		// Token: 0x0600320F RID: 12815 RVA: 0x000850F8 File Offset: 0x000832F8
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, uint* buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, buffers, GL.EntryPoints[56]);
		}

		// Token: 0x06003210 RID: 12816 RVA: 0x0008510C File Offset: 0x0008330C
		[CLSCompliant(false)]
		public static void DeleteTexture(int textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref textures, GL.EntryPoints[61]);
		}

		// Token: 0x06003211 RID: 12817 RVA: 0x00085120 File Offset: 0x00083320
		[CLSCompliant(false)]
		public static void DeleteTexture(uint textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), 1, ref textures, GL.EntryPoints[61]);
		}

		// Token: 0x06003212 RID: 12818 RVA: 0x00085134 File Offset: 0x00083334
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, int[] textures)
		{
			fixed (int* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[61]);
			}
		}

		// Token: 0x06003213 RID: 12819 RVA: 0x00085168 File Offset: 0x00083368
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, ref int textures)
		{
			fixed (int* ptr = &textures)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[61]);
			}
		}

		// Token: 0x06003214 RID: 12820 RVA: 0x00085188 File Offset: 0x00083388
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, int* textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, textures, GL.EntryPoints[61]);
		}

		// Token: 0x06003215 RID: 12821 RVA: 0x0008519C File Offset: 0x0008339C
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, uint[] textures)
		{
			fixed (uint* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[61]);
			}
		}

		// Token: 0x06003216 RID: 12822 RVA: 0x000851D0 File Offset: 0x000833D0
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, ref uint textures)
		{
			fixed (uint* ptr = &textures)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[61]);
			}
		}

		// Token: 0x06003217 RID: 12823 RVA: 0x000851F0 File Offset: 0x000833F0
		[CLSCompliant(false)]
		public unsafe static void DeleteTextures(int n, uint* textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, textures, GL.EntryPoints[61]);
		}

		// Token: 0x06003218 RID: 12824 RVA: 0x00085204 File Offset: 0x00083404
		[Obsolete("Use strongly-typed overload instead")]
		public static void DepthFunc(All func)
		{
			calli(System.Void(System.Int32), func, GL.EntryPoints[63]);
		}

		// Token: 0x06003219 RID: 12825 RVA: 0x00085214 File Offset: 0x00083414
		public static void DepthFunc(DepthFunction func)
		{
			calli(System.Void(System.Int32), func, GL.EntryPoints[63]);
		}

		// Token: 0x0600321A RID: 12826 RVA: 0x00085224 File Offset: 0x00083424
		public static void DepthMask(bool flag)
		{
			calli(System.Void(System.Boolean), flag, GL.EntryPoints[64]);
		}

		// Token: 0x0600321B RID: 12827 RVA: 0x00085234 File Offset: 0x00083434
		public static void DepthRange(float n, float f)
		{
			calli(System.Void(System.Single,System.Single), n, f, GL.EntryPoints[65]);
		}

		// Token: 0x0600321C RID: 12828 RVA: 0x00085248 File Offset: 0x00083448
		public static void DepthRangex(int n, int f)
		{
			calli(System.Void(System.Int32,System.Int32), n, f, GL.EntryPoints[67]);
		}

		// Token: 0x0600321D RID: 12829 RVA: 0x0008525C File Offset: 0x0008345C
		[Obsolete("Use strongly-typed overload instead")]
		public static void Disable(All cap)
		{
			calli(System.Void(System.Int32), cap, GL.EntryPoints[69]);
		}

		// Token: 0x0600321E RID: 12830 RVA: 0x0008526C File Offset: 0x0008346C
		public static void Disable(EnableCap cap)
		{
			calli(System.Void(System.Int32), cap, GL.EntryPoints[69]);
		}

		// Token: 0x0600321F RID: 12831 RVA: 0x0008527C File Offset: 0x0008347C
		[Obsolete("Use strongly-typed overload instead")]
		public static void DisableClientState(All array)
		{
			calli(System.Void(System.Int32), array, GL.EntryPoints[70]);
		}

		// Token: 0x06003220 RID: 12832 RVA: 0x0008528C File Offset: 0x0008348C
		public static void DisableClientState(EnableCap array)
		{
			calli(System.Void(System.Int32), array, GL.EntryPoints[70]);
		}

		// Token: 0x06003221 RID: 12833 RVA: 0x0008529C File Offset: 0x0008349C
		[Obsolete("Use strongly-typed overload instead")]
		public static void DrawArrays(All mode, int first, int count)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), mode, first, count, GL.EntryPoints[73]);
		}

		// Token: 0x06003222 RID: 12834 RVA: 0x000852B0 File Offset: 0x000834B0
		[Obsolete("Use PrimitiveType overload instead")]
		public static void DrawArrays(BeginMode mode, int first, int count)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), mode, first, count, GL.EntryPoints[73]);
		}

		// Token: 0x06003223 RID: 12835 RVA: 0x000852C4 File Offset: 0x000834C4
		public static void DrawArrays(PrimitiveType mode, int first, int count)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), mode, first, count, GL.EntryPoints[73]);
		}

		// Token: 0x06003224 RID: 12836 RVA: 0x000852D8 File Offset: 0x000834D8
		[Obsolete("Use strongly-typed overload instead")]
		public static void DrawElements(All mode, int count, All type, IntPtr indices)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, indices, GL.EntryPoints[74]);
		}

		// Token: 0x06003225 RID: 12837 RVA: 0x000852EC File Offset: 0x000834EC
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void DrawElements<T3>(All mode, int count, All type, [In] [Out] T3[] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x06003226 RID: 12838 RVA: 0x00085320 File Offset: 0x00083520
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(All mode, int count, All type, [In] [Out] T3[,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x06003227 RID: 12839 RVA: 0x00085358 File Offset: 0x00083558
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void DrawElements<T3>(All mode, int count, All type, [In] [Out] T3[,,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x06003228 RID: 12840 RVA: 0x00085390 File Offset: 0x00083590
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void DrawElements<T3>(All mode, int count, All type, [In] [Out] ref T3 indices) where T3 : struct
		{
			fixed (T3* ptr = &indices)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x06003229 RID: 12841 RVA: 0x000853B4 File Offset: 0x000835B4
		[Obsolete("Use PrimitiveType overload instead")]
		public static void DrawElements(BeginMode mode, int count, All type, IntPtr indices)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, indices, GL.EntryPoints[74]);
		}

		// Token: 0x0600322A RID: 12842 RVA: 0x000853C8 File Offset: 0x000835C8
		[Obsolete("Use PrimitiveType overload instead")]
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(BeginMode mode, int count, All type, [In] [Out] T3[] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x0600322B RID: 12843 RVA: 0x000853FC File Offset: 0x000835FC
		[CLSCompliant(false)]
		[Obsolete("Use PrimitiveType overload instead")]
		public unsafe static void DrawElements<T3>(BeginMode mode, int count, All type, [In] [Out] T3[,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x0600322C RID: 12844 RVA: 0x00085434 File Offset: 0x00083634
		[CLSCompliant(false)]
		[Obsolete("Use PrimitiveType overload instead")]
		public unsafe static void DrawElements<T3>(BeginMode mode, int count, All type, [In] [Out] T3[,,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x0600322D RID: 12845 RVA: 0x0008546C File Offset: 0x0008366C
		[Obsolete("Use PrimitiveType overload instead")]
		public unsafe static void DrawElements<T3>(BeginMode mode, int count, All type, [In] [Out] ref T3 indices) where T3 : struct
		{
			fixed (T3* ptr = &indices)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x0600322E RID: 12846 RVA: 0x00085490 File Offset: 0x00083690
		public static void DrawElements(PrimitiveType mode, int count, All type, IntPtr indices)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, indices, GL.EntryPoints[74]);
		}

		// Token: 0x0600322F RID: 12847 RVA: 0x000854A4 File Offset: 0x000836A4
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(PrimitiveType mode, int count, All type, [In] [Out] T3[] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x06003230 RID: 12848 RVA: 0x000854D8 File Offset: 0x000836D8
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(PrimitiveType mode, int count, All type, [In] [Out] T3[,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x06003231 RID: 12849 RVA: 0x00085510 File Offset: 0x00083710
		[CLSCompliant(false)]
		public unsafe static void DrawElements<T3>(PrimitiveType mode, int count, All type, [In] [Out] T3[,,] indices) where T3 : struct
		{
			fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x06003232 RID: 12850 RVA: 0x00085548 File Offset: 0x00083748
		public unsafe static void DrawElements<T3>(PrimitiveType mode, int count, All type, [In] [Out] ref T3 indices) where T3 : struct
		{
			fixed (T3* ptr = &indices)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), mode, count, type, ptr, GL.EntryPoints[74]);
			}
		}

		// Token: 0x06003233 RID: 12851 RVA: 0x0008556C File Offset: 0x0008376C
		[Obsolete("Use strongly-typed overload instead")]
		public static void Enable(All cap)
		{
			calli(System.Void(System.Int32), cap, GL.EntryPoints[85]);
		}

		// Token: 0x06003234 RID: 12852 RVA: 0x0008557C File Offset: 0x0008377C
		public static void Enable(EnableCap cap)
		{
			calli(System.Void(System.Int32), cap, GL.EntryPoints[85]);
		}

		// Token: 0x06003235 RID: 12853 RVA: 0x0008558C File Offset: 0x0008378C
		[Obsolete("Use strongly-typed overload instead")]
		public static void EnableClientState(All array)
		{
			calli(System.Void(System.Int32), array, GL.EntryPoints[86]);
		}

		// Token: 0x06003236 RID: 12854 RVA: 0x0008559C File Offset: 0x0008379C
		public static void EnableClientState(EnableCap array)
		{
			calli(System.Void(System.Int32), array, GL.EntryPoints[86]);
		}

		// Token: 0x06003237 RID: 12855 RVA: 0x000855AC File Offset: 0x000837AC
		public static void Finish()
		{
			calli(System.Void(), GL.EntryPoints[107]);
		}

		// Token: 0x06003238 RID: 12856 RVA: 0x000855BC File Offset: 0x000837BC
		public static void Flush()
		{
			calli(System.Void(), GL.EntryPoints[109]);
		}

		// Token: 0x06003239 RID: 12857 RVA: 0x000855CC File Offset: 0x000837CC
		[Obsolete("Use strongly-typed overload instead")]
		public static void Fog(All pname, float param)
		{
			calli(System.Void(System.Int32,System.Single), pname, param, GL.EntryPoints[111]);
		}

		// Token: 0x0600323A RID: 12858 RVA: 0x000855E0 File Offset: 0x000837E0
		public static void Fog(FogParameter pname, float param)
		{
			calli(System.Void(System.Int32,System.Single), pname, param, GL.EntryPoints[111]);
		}

		// Token: 0x0600323B RID: 12859 RVA: 0x000855F4 File Offset: 0x000837F4
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void Fog(All pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[112]);
			}
		}

		// Token: 0x0600323C RID: 12860 RVA: 0x00085628 File Offset: 0x00083828
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void Fog(All pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Single*), pname, @params, GL.EntryPoints[112]);
		}

		// Token: 0x0600323D RID: 12861 RVA: 0x0008563C File Offset: 0x0008383C
		[CLSCompliant(false)]
		public unsafe static void Fog(FogParameter pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[112]);
			}
		}

		// Token: 0x0600323E RID: 12862 RVA: 0x00085670 File Offset: 0x00083870
		[CLSCompliant(false)]
		public unsafe static void Fog(FogParameter pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Single*), pname, @params, GL.EntryPoints[112]);
		}

		// Token: 0x0600323F RID: 12863 RVA: 0x00085684 File Offset: 0x00083884
		public static void Fogx(All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[113]);
		}

		// Token: 0x06003240 RID: 12864 RVA: 0x00085698 File Offset: 0x00083898
		[CLSCompliant(false)]
		public unsafe static void Fogx(All pname, int[] param)
		{
			fixed (int* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[115]);
			}
		}

		// Token: 0x06003241 RID: 12865 RVA: 0x000856CC File Offset: 0x000838CC
		[CLSCompliant(false)]
		public unsafe static void Fogx(All pname, int* param)
		{
			calli(System.Void(System.Int32,System.Int32*), pname, param, GL.EntryPoints[115]);
		}

		// Token: 0x06003242 RID: 12866 RVA: 0x000856E0 File Offset: 0x000838E0
		[Obsolete("Use strongly-typed overload instead")]
		public static void FrontFace(All mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[121]);
		}

		// Token: 0x06003243 RID: 12867 RVA: 0x000856F0 File Offset: 0x000838F0
		public static void FrontFace(FrontFaceDirection mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[121]);
		}

		// Token: 0x06003244 RID: 12868 RVA: 0x00085700 File Offset: 0x00083900
		public static void Frustum(float l, float r, float b, float t, float n, float f)
		{
			calli(System.Void(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), l, r, b, t, n, f, GL.EntryPoints[122]);
		}

		// Token: 0x06003245 RID: 12869 RVA: 0x00085718 File Offset: 0x00083918
		public static void Frustumx(int l, int r, int b, int t, int n, int f)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), l, r, b, t, n, f, GL.EntryPoints[124]);
		}

		// Token: 0x06003246 RID: 12870 RVA: 0x00085730 File Offset: 0x00083930
		[CLSCompliant(false)]
		public static int GenBuffer()
		{
			int result;
			calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[126]);
			return result;
		}

		// Token: 0x06003247 RID: 12871 RVA: 0x00085750 File Offset: 0x00083950
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, [Out] int[] buffers)
		{
			fixed (int* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[126]);
			}
		}

		// Token: 0x06003248 RID: 12872 RVA: 0x00085784 File Offset: 0x00083984
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, out int buffers)
		{
			fixed (int* ptr = &buffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[126]);
			}
		}

		// Token: 0x06003249 RID: 12873 RVA: 0x000857A4 File Offset: 0x000839A4
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, [Out] int* buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, buffers, GL.EntryPoints[126]);
		}

		// Token: 0x0600324A RID: 12874 RVA: 0x000857B8 File Offset: 0x000839B8
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, [Out] uint[] buffers)
		{
			fixed (uint* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[126]);
			}
		}

		// Token: 0x0600324B RID: 12875 RVA: 0x000857EC File Offset: 0x000839EC
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, out uint buffers)
		{
			fixed (uint* ptr = &buffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[126]);
			}
		}

		// Token: 0x0600324C RID: 12876 RVA: 0x0008580C File Offset: 0x00083A0C
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, [Out] uint* buffers)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, buffers, GL.EntryPoints[126]);
		}

		// Token: 0x0600324D RID: 12877 RVA: 0x00085820 File Offset: 0x00083A20
		[CLSCompliant(false)]
		public static int GenTexture()
		{
			int result;
			calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[131]);
			return result;
		}

		// Token: 0x0600324E RID: 12878 RVA: 0x00085844 File Offset: 0x00083A44
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, [Out] int[] textures)
		{
			fixed (int* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[131]);
			}
		}

		// Token: 0x0600324F RID: 12879 RVA: 0x00085878 File Offset: 0x00083A78
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, out int textures)
		{
			fixed (int* ptr = &textures)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[131]);
			}
		}

		// Token: 0x06003250 RID: 12880 RVA: 0x0008589C File Offset: 0x00083A9C
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, [Out] int* textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, textures, GL.EntryPoints[131]);
		}

		// Token: 0x06003251 RID: 12881 RVA: 0x000858B0 File Offset: 0x00083AB0
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, [Out] uint[] textures)
		{
			fixed (uint* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[131]);
			}
		}

		// Token: 0x06003252 RID: 12882 RVA: 0x000858E4 File Offset: 0x00083AE4
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, out uint textures)
		{
			fixed (uint* ptr = &textures)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[131]);
			}
		}

		// Token: 0x06003253 RID: 12883 RVA: 0x00085908 File Offset: 0x00083B08
		[CLSCompliant(false)]
		public unsafe static void GenTextures(int n, [Out] uint* textures)
		{
			calli(System.Void(System.Int32,System.UInt32*), n, textures, GL.EntryPoints[131]);
		}

		// Token: 0x06003254 RID: 12884 RVA: 0x0008591C File Offset: 0x00083B1C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static bool GetBoolean(All pname)
		{
			bool result;
			calli(System.Void(System.Int32,System.Boolean*), pname, ref result, GL.EntryPoints[133]);
			return result;
		}

		// Token: 0x06003255 RID: 12885 RVA: 0x00085940 File Offset: 0x00083B40
		[CLSCompliant(false)]
		public static bool GetBoolean(GetPName pname)
		{
			bool result;
			calli(System.Void(System.Int32,System.Boolean*), pname, ref result, GL.EntryPoints[133]);
			return result;
		}

		// Token: 0x06003256 RID: 12886 RVA: 0x00085964 File Offset: 0x00083B64
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(All pname, [Out] bool[] data)
		{
			fixed (bool* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Boolean*), pname, ptr, GL.EntryPoints[133]);
			}
		}

		// Token: 0x06003257 RID: 12887 RVA: 0x00085998 File Offset: 0x00083B98
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetBoolean(All pname, out bool data)
		{
			fixed (bool* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Boolean*), pname, ptr, GL.EntryPoints[133]);
			}
		}

		// Token: 0x06003258 RID: 12888 RVA: 0x000859BC File Offset: 0x00083BBC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(All pname, [Out] bool* data)
		{
			calli(System.Void(System.Int32,System.Boolean*), pname, data, GL.EntryPoints[133]);
		}

		// Token: 0x06003259 RID: 12889 RVA: 0x000859D0 File Offset: 0x00083BD0
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(GetPName pname, [Out] bool[] data)
		{
			fixed (bool* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Boolean*), pname, ptr, GL.EntryPoints[133]);
			}
		}

		// Token: 0x0600325A RID: 12890 RVA: 0x00085A04 File Offset: 0x00083C04
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(GetPName pname, out bool data)
		{
			fixed (bool* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Boolean*), pname, ptr, GL.EntryPoints[133]);
			}
		}

		// Token: 0x0600325B RID: 12891 RVA: 0x00085A28 File Offset: 0x00083C28
		[CLSCompliant(false)]
		public unsafe static void GetBoolean(GetPName pname, [Out] bool* data)
		{
			calli(System.Void(System.Int32,System.Boolean*), pname, data, GL.EntryPoints[133]);
		}

		// Token: 0x0600325C RID: 12892 RVA: 0x00085A3C File Offset: 0x00083C3C
		[CLSCompliant(false)]
		public unsafe static void GetBufferParameter(All target, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[134]);
			}
		}

		// Token: 0x0600325D RID: 12893 RVA: 0x00085A74 File Offset: 0x00083C74
		[CLSCompliant(false)]
		public unsafe static void GetBufferParameter(All target, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[134]);
			}
		}

		// Token: 0x0600325E RID: 12894 RVA: 0x00085A98 File Offset: 0x00083C98
		[CLSCompliant(false)]
		public unsafe static void GetBufferParameter(All target, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[134]);
		}

		// Token: 0x0600325F RID: 12895 RVA: 0x00085AB0 File Offset: 0x00083CB0
		[CLSCompliant(false)]
		public unsafe static void GetClipPlane(All plane, [Out] float[] equation)
		{
			fixed (float* ptr = ref (equation != null && equation.Length != 0) ? ref equation[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), plane, ptr, GL.EntryPoints[136]);
			}
		}

		// Token: 0x06003260 RID: 12896 RVA: 0x00085AE4 File Offset: 0x00083CE4
		[CLSCompliant(false)]
		public unsafe static void GetClipPlane(All plane, out float equation)
		{
			fixed (float* ptr = &equation)
			{
				calli(System.Void(System.Int32,System.Single*), plane, ptr, GL.EntryPoints[136]);
			}
		}

		// Token: 0x06003261 RID: 12897 RVA: 0x00085B08 File Offset: 0x00083D08
		[CLSCompliant(false)]
		public unsafe static void GetClipPlane(All plane, [Out] float* equation)
		{
			calli(System.Void(System.Int32,System.Single*), plane, equation, GL.EntryPoints[136]);
		}

		// Token: 0x06003262 RID: 12898 RVA: 0x00085B1C File Offset: 0x00083D1C
		[CLSCompliant(false)]
		public unsafe static void GetClipPlanex(All plane, [Out] int[] equation)
		{
			fixed (int* ptr = ref (equation != null && equation.Length != 0) ? ref equation[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), plane, ptr, GL.EntryPoints[138]);
			}
		}

		// Token: 0x06003263 RID: 12899 RVA: 0x00085B50 File Offset: 0x00083D50
		[CLSCompliant(false)]
		public unsafe static void GetClipPlanex(All plane, out int equation)
		{
			fixed (int* ptr = &equation)
			{
				calli(System.Void(System.Int32,System.Int32*), plane, ptr, GL.EntryPoints[138]);
			}
		}

		// Token: 0x06003264 RID: 12900 RVA: 0x00085B74 File Offset: 0x00083D74
		[CLSCompliant(false)]
		public unsafe static void GetClipPlanex(All plane, [Out] int* equation)
		{
			calli(System.Void(System.Int32,System.Int32*), plane, equation, GL.EntryPoints[138]);
		}

		// Token: 0x06003265 RID: 12901 RVA: 0x00085B88 File Offset: 0x00083D88
		public static ErrorCode GetError()
		{
			return calli(System.Int32(), GL.EntryPoints[143]);
		}

		// Token: 0x06003266 RID: 12902 RVA: 0x00085B9C File Offset: 0x00083D9C
		[CLSCompliant(false)]
		public static int GetFixed(All pname)
		{
			int result;
			calli(System.Void(System.Int32,System.Int32*), pname, ref result, GL.EntryPoints[145]);
			return result;
		}

		// Token: 0x06003267 RID: 12903 RVA: 0x00085BC0 File Offset: 0x00083DC0
		[CLSCompliant(false)]
		public unsafe static void GetFixed(All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[145]);
			}
		}

		// Token: 0x06003268 RID: 12904 RVA: 0x00085BF4 File Offset: 0x00083DF4
		[CLSCompliant(false)]
		public unsafe static void GetFixed(All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[145]);
			}
		}

		// Token: 0x06003269 RID: 12905 RVA: 0x00085C18 File Offset: 0x00083E18
		[CLSCompliant(false)]
		public unsafe static void GetFixed(All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32*), pname, @params, GL.EntryPoints[145]);
		}

		// Token: 0x0600326A RID: 12906 RVA: 0x00085C2C File Offset: 0x00083E2C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static float GetFloat(All pname)
		{
			float result;
			calli(System.Void(System.Int32,System.Single*), pname, ref result, GL.EntryPoints[147]);
			return result;
		}

		// Token: 0x0600326B RID: 12907 RVA: 0x00085C50 File Offset: 0x00083E50
		[CLSCompliant(false)]
		public static float GetFloat(GetPName pname)
		{
			float result;
			calli(System.Void(System.Int32,System.Single*), pname, ref result, GL.EntryPoints[147]);
			return result;
		}

		// Token: 0x0600326C RID: 12908 RVA: 0x00085C74 File Offset: 0x00083E74
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetFloat(All pname, [Out] float[] data)
		{
			fixed (float* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[147]);
			}
		}

		// Token: 0x0600326D RID: 12909 RVA: 0x00085CA8 File Offset: 0x00083EA8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetFloat(All pname, out float data)
		{
			fixed (float* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[147]);
			}
		}

		// Token: 0x0600326E RID: 12910 RVA: 0x00085CCC File Offset: 0x00083ECC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetFloat(All pname, [Out] float* data)
		{
			calli(System.Void(System.Int32,System.Single*), pname, data, GL.EntryPoints[147]);
		}

		// Token: 0x0600326F RID: 12911 RVA: 0x00085CE0 File Offset: 0x00083EE0
		[CLSCompliant(false)]
		public unsafe static void GetFloat(GetPName pname, [Out] float[] data)
		{
			fixed (float* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[147]);
			}
		}

		// Token: 0x06003270 RID: 12912 RVA: 0x00085D14 File Offset: 0x00083F14
		[CLSCompliant(false)]
		public unsafe static void GetFloat(GetPName pname, out float data)
		{
			fixed (float* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[147]);
			}
		}

		// Token: 0x06003271 RID: 12913 RVA: 0x00085D38 File Offset: 0x00083F38
		[CLSCompliant(false)]
		public unsafe static void GetFloat(GetPName pname, [Out] float* data)
		{
			calli(System.Void(System.Int32,System.Single*), pname, data, GL.EntryPoints[147]);
		}

		// Token: 0x06003272 RID: 12914 RVA: 0x00085D4C File Offset: 0x00083F4C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public static int GetInteger(All pname)
		{
			int result;
			calli(System.Void(System.Int32,System.Int32*), pname, ref result, GL.EntryPoints[152]);
			return result;
		}

		// Token: 0x06003273 RID: 12915 RVA: 0x00085D70 File Offset: 0x00083F70
		[CLSCompliant(false)]
		public static int GetInteger(GetPName pname)
		{
			int result;
			calli(System.Void(System.Int32,System.Int32*), pname, ref result, GL.EntryPoints[152]);
			return result;
		}

		// Token: 0x06003274 RID: 12916 RVA: 0x00085D94 File Offset: 0x00083F94
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetInteger(All pname, [Out] int[] data)
		{
			fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[152]);
			}
		}

		// Token: 0x06003275 RID: 12917 RVA: 0x00085DC8 File Offset: 0x00083FC8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetInteger(All pname, out int data)
		{
			fixed (int* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[152]);
			}
		}

		// Token: 0x06003276 RID: 12918 RVA: 0x00085DEC File Offset: 0x00083FEC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetInteger(All pname, [Out] int* data)
		{
			calli(System.Void(System.Int32,System.Int32*), pname, data, GL.EntryPoints[152]);
		}

		// Token: 0x06003277 RID: 12919 RVA: 0x00085E00 File Offset: 0x00084000
		[CLSCompliant(false)]
		public unsafe static void GetInteger(GetPName pname, [Out] int[] data)
		{
			fixed (int* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[152]);
			}
		}

		// Token: 0x06003278 RID: 12920 RVA: 0x00085E34 File Offset: 0x00084034
		[CLSCompliant(false)]
		public unsafe static void GetInteger(GetPName pname, out int data)
		{
			fixed (int* ptr = &data)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[152]);
			}
		}

		// Token: 0x06003279 RID: 12921 RVA: 0x00085E58 File Offset: 0x00084058
		[CLSCompliant(false)]
		public unsafe static void GetInteger(GetPName pname, [Out] int* data)
		{
			calli(System.Void(System.Int32,System.Int32*), pname, data, GL.EntryPoints[152]);
		}

		// Token: 0x0600327A RID: 12922 RVA: 0x00085E6C File Offset: 0x0008406C
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetLight(All light, All pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, ptr, GL.EntryPoints[153]);
			}
		}

		// Token: 0x0600327B RID: 12923 RVA: 0x00085EA4 File Offset: 0x000840A4
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetLight(All light, All pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, ptr, GL.EntryPoints[153]);
			}
		}

		// Token: 0x0600327C RID: 12924 RVA: 0x00085EC8 File Offset: 0x000840C8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetLight(All light, All pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, @params, GL.EntryPoints[153]);
		}

		// Token: 0x0600327D RID: 12925 RVA: 0x00085EE0 File Offset: 0x000840E0
		[CLSCompliant(false)]
		public unsafe static void GetLight(LightName light, LightParameter pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, ptr, GL.EntryPoints[153]);
			}
		}

		// Token: 0x0600327E RID: 12926 RVA: 0x00085F18 File Offset: 0x00084118
		[CLSCompliant(false)]
		public unsafe static void GetLight(LightName light, LightParameter pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, ptr, GL.EntryPoints[153]);
			}
		}

		// Token: 0x0600327F RID: 12927 RVA: 0x00085F3C File Offset: 0x0008413C
		[CLSCompliant(false)]
		public unsafe static void GetLight(LightName light, LightParameter pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, @params, GL.EntryPoints[153]);
		}

		// Token: 0x06003280 RID: 12928 RVA: 0x00085F54 File Offset: 0x00084154
		[CLSCompliant(false)]
		public unsafe static void GetLightx(All light, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, ptr, GL.EntryPoints[155]);
			}
		}

		// Token: 0x06003281 RID: 12929 RVA: 0x00085F8C File Offset: 0x0008418C
		[CLSCompliant(false)]
		public unsafe static void GetLightx(All light, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, ptr, GL.EntryPoints[155]);
			}
		}

		// Token: 0x06003282 RID: 12930 RVA: 0x00085FB0 File Offset: 0x000841B0
		[CLSCompliant(false)]
		public unsafe static void GetLightx(All light, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, @params, GL.EntryPoints[155]);
		}

		// Token: 0x06003283 RID: 12931 RVA: 0x00085FC8 File Offset: 0x000841C8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetMaterial(All face, All pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, ptr, GL.EntryPoints[158]);
			}
		}

		// Token: 0x06003284 RID: 12932 RVA: 0x00086000 File Offset: 0x00084200
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetMaterial(All face, All pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, ptr, GL.EntryPoints[158]);
			}
		}

		// Token: 0x06003285 RID: 12933 RVA: 0x00086024 File Offset: 0x00084224
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetMaterial(All face, All pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, @params, GL.EntryPoints[158]);
		}

		// Token: 0x06003286 RID: 12934 RVA: 0x0008603C File Offset: 0x0008423C
		[CLSCompliant(false)]
		public unsafe static void GetMaterial(MaterialFace face, MaterialParameter pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, ptr, GL.EntryPoints[158]);
			}
		}

		// Token: 0x06003287 RID: 12935 RVA: 0x00086074 File Offset: 0x00084274
		[CLSCompliant(false)]
		public unsafe static void GetMaterial(MaterialFace face, MaterialParameter pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, ptr, GL.EntryPoints[158]);
			}
		}

		// Token: 0x06003288 RID: 12936 RVA: 0x00086098 File Offset: 0x00084298
		[CLSCompliant(false)]
		public unsafe static void GetMaterial(MaterialFace face, MaterialParameter pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, @params, GL.EntryPoints[158]);
		}

		// Token: 0x06003289 RID: 12937 RVA: 0x000860B0 File Offset: 0x000842B0
		[CLSCompliant(false)]
		public unsafe static void GetMaterialx(All face, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, ptr, GL.EntryPoints[160]);
			}
		}

		// Token: 0x0600328A RID: 12938 RVA: 0x000860E8 File Offset: 0x000842E8
		[CLSCompliant(false)]
		public unsafe static void GetMaterialx(All face, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, ptr, GL.EntryPoints[160]);
			}
		}

		// Token: 0x0600328B RID: 12939 RVA: 0x0008610C File Offset: 0x0008430C
		[CLSCompliant(false)]
		public unsafe static void GetMaterialx(All face, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, @params, GL.EntryPoints[160]);
		}

		// Token: 0x0600328C RID: 12940 RVA: 0x00086124 File Offset: 0x00084324
		[CLSCompliant(false)]
		public unsafe static void GetPixelMapx(All map, int size, [Out] int[] values)
		{
			fixed (int* ptr = ref (values != null && values.Length != 0) ? ref values[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), map, size, ptr, GL.EntryPoints[164]);
			}
		}

		// Token: 0x0600328D RID: 12941 RVA: 0x0008615C File Offset: 0x0008435C
		[CLSCompliant(false)]
		public unsafe static void GetPixelMapx(All map, int size, out int values)
		{
			fixed (int* ptr = &values)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), map, size, ptr, GL.EntryPoints[164]);
			}
		}

		// Token: 0x0600328E RID: 12942 RVA: 0x00086180 File Offset: 0x00084380
		[CLSCompliant(false)]
		public unsafe static void GetPixelMapx(All map, int size, [Out] int* values)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), map, size, values, GL.EntryPoints[164]);
		}

		// Token: 0x0600328F RID: 12943 RVA: 0x00086198 File Offset: 0x00084398
		[Obsolete("Use strongly-typed overload instead")]
		public static void GetPointer(All pname, [Out] IntPtr @params)
		{
			calli(System.Void(System.Int32,System.IntPtr), pname, @params, GL.EntryPoints[165]);
		}

		// Token: 0x06003290 RID: 12944 RVA: 0x000861AC File Offset: 0x000843AC
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[165]);
			}
		}

		// Token: 0x06003291 RID: 12945 RVA: 0x000861E0 File Offset: 0x000843E0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[,] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[165]);
			}
		}

		// Token: 0x06003292 RID: 12946 RVA: 0x00086218 File Offset: 0x00084418
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetPointer<T1>(All pname, [In] [Out] T1[,,] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[165]);
			}
		}

		// Token: 0x06003293 RID: 12947 RVA: 0x00086254 File Offset: 0x00084454
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetPointer<T1>(All pname, [In] [Out] ref T1 @params) where T1 : struct
		{
			fixed (T1* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[165]);
			}
		}

		// Token: 0x06003294 RID: 12948 RVA: 0x00086278 File Offset: 0x00084478
		public static void GetPointer(GetPointervPName pname, [Out] IntPtr @params)
		{
			calli(System.Void(System.Int32,System.IntPtr), pname, @params, GL.EntryPoints[165]);
		}

		// Token: 0x06003295 RID: 12949 RVA: 0x0008628C File Offset: 0x0008448C
		[CLSCompliant(false)]
		public unsafe static void GetPointer<T1>(GetPointervPName pname, [In] [Out] T1[] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[165]);
			}
		}

		// Token: 0x06003296 RID: 12950 RVA: 0x000862C0 File Offset: 0x000844C0
		[CLSCompliant(false)]
		public unsafe static void GetPointer<T1>(GetPointervPName pname, [In] [Out] T1[,] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[165]);
			}
		}

		// Token: 0x06003297 RID: 12951 RVA: 0x000862F8 File Offset: 0x000844F8
		[CLSCompliant(false)]
		public unsafe static void GetPointer<T1>(GetPointervPName pname, [In] [Out] T1[,,] @params) where T1 : struct
		{
			fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[165]);
			}
		}

		// Token: 0x06003298 RID: 12952 RVA: 0x00086334 File Offset: 0x00084534
		public unsafe static void GetPointer<T1>(GetPointervPName pname, [In] [Out] ref T1 @params) where T1 : struct
		{
			fixed (T1* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.IntPtr), pname, ptr, GL.EntryPoints[165]);
			}
		}

		// Token: 0x06003299 RID: 12953 RVA: 0x00086358 File Offset: 0x00084558
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static string GetString(All name)
		{
			return new string((sbyte*)((void*)calli(System.IntPtr(System.Int32), name, GL.EntryPoints[167])));
		}

		// Token: 0x0600329A RID: 12954 RVA: 0x00086378 File Offset: 0x00084578
		public unsafe static string GetString(StringName name)
		{
			return new string((sbyte*)((void*)calli(System.IntPtr(System.Int32), name, GL.EntryPoints[167])));
		}

		// Token: 0x0600329B RID: 12955 RVA: 0x00086398 File Offset: 0x00084598
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexEnv(All target, All pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[169]);
			}
		}

		// Token: 0x0600329C RID: 12956 RVA: 0x000863D0 File Offset: 0x000845D0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexEnv(All target, All pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[169]);
			}
		}

		// Token: 0x0600329D RID: 12957 RVA: 0x000863F4 File Offset: 0x000845F4
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexEnv(All target, All pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[169]);
		}

		// Token: 0x0600329E RID: 12958 RVA: 0x0008640C File Offset: 0x0008460C
		[CLSCompliant(false)]
		public unsafe static void GetTexEnv(TextureEnvTarget target, TextureEnvParameter pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[169]);
			}
		}

		// Token: 0x0600329F RID: 12959 RVA: 0x00086444 File Offset: 0x00084644
		[CLSCompliant(false)]
		public unsafe static void GetTexEnv(TextureEnvTarget target, TextureEnvParameter pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[169]);
			}
		}

		// Token: 0x060032A0 RID: 12960 RVA: 0x00086468 File Offset: 0x00084668
		[CLSCompliant(false)]
		public unsafe static void GetTexEnv(TextureEnvTarget target, TextureEnvParameter pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[169]);
		}

		// Token: 0x060032A1 RID: 12961 RVA: 0x00086480 File Offset: 0x00084680
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetTexEnv(All target, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[170]);
			}
		}

		// Token: 0x060032A2 RID: 12962 RVA: 0x000864B8 File Offset: 0x000846B8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetTexEnv(All target, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[170]);
			}
		}

		// Token: 0x060032A3 RID: 12963 RVA: 0x000864DC File Offset: 0x000846DC
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexEnv(All target, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[170]);
		}

		// Token: 0x060032A4 RID: 12964 RVA: 0x000864F4 File Offset: 0x000846F4
		[CLSCompliant(false)]
		public unsafe static void GetTexEnv(TextureEnvTarget target, TextureEnvParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[170]);
			}
		}

		// Token: 0x060032A5 RID: 12965 RVA: 0x0008652C File Offset: 0x0008472C
		[CLSCompliant(false)]
		public unsafe static void GetTexEnv(TextureEnvTarget target, TextureEnvParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[170]);
			}
		}

		// Token: 0x060032A6 RID: 12966 RVA: 0x00086550 File Offset: 0x00084750
		[CLSCompliant(false)]
		public unsafe static void GetTexEnv(TextureEnvTarget target, TextureEnvParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[170]);
		}

		// Token: 0x060032A7 RID: 12967 RVA: 0x00086568 File Offset: 0x00084768
		[CLSCompliant(false)]
		public unsafe static void GetTexEnvx(All target, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[171]);
			}
		}

		// Token: 0x060032A8 RID: 12968 RVA: 0x000865A0 File Offset: 0x000847A0
		[CLSCompliant(false)]
		public unsafe static void GetTexEnvx(All target, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[171]);
			}
		}

		// Token: 0x060032A9 RID: 12969 RVA: 0x000865C4 File Offset: 0x000847C4
		[CLSCompliant(false)]
		public unsafe static void GetTexEnvx(All target, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[171]);
		}

		// Token: 0x060032AA RID: 12970 RVA: 0x000865DC File Offset: 0x000847DC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(All target, All pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[177]);
			}
		}

		// Token: 0x060032AB RID: 12971 RVA: 0x00086614 File Offset: 0x00084814
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexParameter(All target, All pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[177]);
			}
		}

		// Token: 0x060032AC RID: 12972 RVA: 0x00086638 File Offset: 0x00084838
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexParameter(All target, All pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[177]);
		}

		// Token: 0x060032AD RID: 12973 RVA: 0x00086650 File Offset: 0x00084850
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[177]);
			}
		}

		// Token: 0x060032AE RID: 12974 RVA: 0x00086688 File Offset: 0x00084888
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, out float @params)
		{
			fixed (float* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[177]);
			}
		}

		// Token: 0x060032AF RID: 12975 RVA: 0x000866AC File Offset: 0x000848AC
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[177]);
		}

		// Token: 0x060032B0 RID: 12976 RVA: 0x000866C4 File Offset: 0x000848C4
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexParameter(All target, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[178]);
			}
		}

		// Token: 0x060032B1 RID: 12977 RVA: 0x000866FC File Offset: 0x000848FC
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexParameter(All target, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[178]);
			}
		}

		// Token: 0x060032B2 RID: 12978 RVA: 0x00086720 File Offset: 0x00084920
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void GetTexParameter(All target, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[178]);
		}

		// Token: 0x060032B3 RID: 12979 RVA: 0x00086738 File Offset: 0x00084938
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[178]);
			}
		}

		// Token: 0x060032B4 RID: 12980 RVA: 0x00086770 File Offset: 0x00084970
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[178]);
			}
		}

		// Token: 0x060032B5 RID: 12981 RVA: 0x00086794 File Offset: 0x00084994
		[CLSCompliant(false)]
		public unsafe static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[178]);
		}

		// Token: 0x060032B6 RID: 12982 RVA: 0x000867AC File Offset: 0x000849AC
		[CLSCompliant(false)]
		public unsafe static void GetTexParameterx(All target, All pname, [Out] int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[179]);
			}
		}

		// Token: 0x060032B7 RID: 12983 RVA: 0x000867E4 File Offset: 0x000849E4
		[CLSCompliant(false)]
		public unsafe static void GetTexParameterx(All target, All pname, out int @params)
		{
			fixed (int* ptr = &@params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[179]);
			}
		}

		// Token: 0x060032B8 RID: 12984 RVA: 0x00086808 File Offset: 0x00084A08
		[CLSCompliant(false)]
		public unsafe static void GetTexParameterx(All target, All pname, [Out] int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[179]);
		}

		// Token: 0x060032B9 RID: 12985 RVA: 0x00086820 File Offset: 0x00084A20
		[Obsolete("Use strongly-typed overload instead")]
		public static void Hint(All target, All mode)
		{
			calli(System.Void(System.Int32,System.Int32), target, mode, GL.EntryPoints[181]);
		}

		// Token: 0x060032BA RID: 12986 RVA: 0x00086834 File Offset: 0x00084A34
		public static void Hint(HintTarget target, HintMode mode)
		{
			calli(System.Void(System.Int32,System.Int32), target, mode, GL.EntryPoints[181]);
		}

		// Token: 0x060032BB RID: 12987 RVA: 0x00086848 File Offset: 0x00084A48
		[CLSCompliant(false)]
		public static bool IsBuffer(int buffer)
		{
			return calli(System.Byte(System.UInt32), buffer, GL.EntryPoints[184]);
		}

		// Token: 0x060032BC RID: 12988 RVA: 0x0008685C File Offset: 0x00084A5C
		[CLSCompliant(false)]
		public static bool IsBuffer(uint buffer)
		{
			return calli(System.Byte(System.UInt32), buffer, GL.EntryPoints[184]);
		}

		// Token: 0x060032BD RID: 12989 RVA: 0x00086870 File Offset: 0x00084A70
		[Obsolete("Use strongly-typed overload instead")]
		public static bool IsEnabled(All cap)
		{
			return calli(System.Byte(System.Int32), cap, GL.EntryPoints[185]);
		}

		// Token: 0x060032BE RID: 12990 RVA: 0x00086884 File Offset: 0x00084A84
		public static bool IsEnabled(EnableCap cap)
		{
			return calli(System.Byte(System.Int32), cap, GL.EntryPoints[185]);
		}

		// Token: 0x060032BF RID: 12991 RVA: 0x00086898 File Offset: 0x00084A98
		[CLSCompliant(false)]
		public static bool IsTexture(int texture)
		{
			return calli(System.Byte(System.UInt32), texture, GL.EntryPoints[190]);
		}

		// Token: 0x060032C0 RID: 12992 RVA: 0x000868AC File Offset: 0x00084AAC
		[CLSCompliant(false)]
		public static bool IsTexture(uint texture)
		{
			return calli(System.Byte(System.UInt32), texture, GL.EntryPoints[190]);
		}

		// Token: 0x060032C1 RID: 12993 RVA: 0x000868C0 File Offset: 0x00084AC0
		[Obsolete("Use strongly-typed overload instead")]
		public static void Light(All light, All pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), light, pname, param, GL.EntryPoints[192]);
		}

		// Token: 0x060032C2 RID: 12994 RVA: 0x000868D8 File Offset: 0x00084AD8
		public static void Light(LightName light, LightParameter pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), light, pname, param, GL.EntryPoints[192]);
		}

		// Token: 0x060032C3 RID: 12995 RVA: 0x000868F0 File Offset: 0x00084AF0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void Light(All light, All pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, ptr, GL.EntryPoints[193]);
			}
		}

		// Token: 0x060032C4 RID: 12996 RVA: 0x00086928 File Offset: 0x00084B28
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void Light(All light, All pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, @params, GL.EntryPoints[193]);
		}

		// Token: 0x060032C5 RID: 12997 RVA: 0x00086940 File Offset: 0x00084B40
		[CLSCompliant(false)]
		public unsafe static void Light(LightName light, LightParameter pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, ptr, GL.EntryPoints[193]);
			}
		}

		// Token: 0x060032C6 RID: 12998 RVA: 0x00086978 File Offset: 0x00084B78
		[CLSCompliant(false)]
		public unsafe static void Light(LightName light, LightParameter pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), light, pname, @params, GL.EntryPoints[193]);
		}

		// Token: 0x060032C7 RID: 12999 RVA: 0x00086990 File Offset: 0x00084B90
		[Obsolete("Use strongly-typed overload instead")]
		public static void LightModel(All pname, float param)
		{
			calli(System.Void(System.Int32,System.Single), pname, param, GL.EntryPoints[194]);
		}

		// Token: 0x060032C8 RID: 13000 RVA: 0x000869A4 File Offset: 0x00084BA4
		public static void LightModel(LightModelParameter pname, float param)
		{
			calli(System.Void(System.Int32,System.Single), pname, param, GL.EntryPoints[194]);
		}

		// Token: 0x060032C9 RID: 13001 RVA: 0x000869B8 File Offset: 0x00084BB8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void LightModel(All pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[195]);
			}
		}

		// Token: 0x060032CA RID: 13002 RVA: 0x000869EC File Offset: 0x00084BEC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void LightModel(All pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Single*), pname, @params, GL.EntryPoints[195]);
		}

		// Token: 0x060032CB RID: 13003 RVA: 0x00086A00 File Offset: 0x00084C00
		[CLSCompliant(false)]
		public unsafe static void LightModel(LightModelParameter pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[195]);
			}
		}

		// Token: 0x060032CC RID: 13004 RVA: 0x00086A34 File Offset: 0x00084C34
		[CLSCompliant(false)]
		public unsafe static void LightModel(LightModelParameter pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Single*), pname, @params, GL.EntryPoints[195]);
		}

		// Token: 0x060032CD RID: 13005 RVA: 0x00086A48 File Offset: 0x00084C48
		public static void LightModelx(All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[196]);
		}

		// Token: 0x060032CE RID: 13006 RVA: 0x00086A5C File Offset: 0x00084C5C
		[CLSCompliant(false)]
		public unsafe static void LightModelx(All pname, int[] param)
		{
			fixed (int* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[198]);
			}
		}

		// Token: 0x060032CF RID: 13007 RVA: 0x00086A90 File Offset: 0x00084C90
		[CLSCompliant(false)]
		public unsafe static void LightModelx(All pname, int* param)
		{
			calli(System.Void(System.Int32,System.Int32*), pname, param, GL.EntryPoints[198]);
		}

		// Token: 0x060032D0 RID: 13008 RVA: 0x00086AA4 File Offset: 0x00084CA4
		public static void Lightx(All light, All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), light, pname, param, GL.EntryPoints[200]);
		}

		// Token: 0x060032D1 RID: 13009 RVA: 0x00086ABC File Offset: 0x00084CBC
		[CLSCompliant(false)]
		public unsafe static void Lightx(All light, All pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, ptr, GL.EntryPoints[202]);
			}
		}

		// Token: 0x060032D2 RID: 13010 RVA: 0x00086AF4 File Offset: 0x00084CF4
		[CLSCompliant(false)]
		public unsafe static void Lightx(All light, All pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, @params, GL.EntryPoints[202]);
		}

		// Token: 0x060032D3 RID: 13011 RVA: 0x00086B0C File Offset: 0x00084D0C
		public static void LineWidth(float width)
		{
			calli(System.Void(System.Single), width, GL.EntryPoints[204]);
		}

		// Token: 0x060032D4 RID: 13012 RVA: 0x00086B20 File Offset: 0x00084D20
		public static void LineWidthx(int width)
		{
			calli(System.Void(System.Int32), width, GL.EntryPoints[205]);
		}

		// Token: 0x060032D5 RID: 13013 RVA: 0x00086B34 File Offset: 0x00084D34
		public static void LoadIdentity()
		{
			calli(System.Void(), GL.EntryPoints[207]);
		}

		// Token: 0x060032D6 RID: 13014 RVA: 0x00086B48 File Offset: 0x00084D48
		[CLSCompliant(false)]
		public unsafe static void LoadMatrix(float[] m)
		{
			fixed (float* ptr = ref (m != null && m.Length != 0) ? ref m[0] : ref *null)
			{
				calli(System.Void(System.Single*), ptr, GL.EntryPoints[208]);
			}
		}

		// Token: 0x060032D7 RID: 13015 RVA: 0x00086B7C File Offset: 0x00084D7C
		[CLSCompliant(false)]
		public unsafe static void LoadMatrix(ref float m)
		{
			fixed (float* ptr = &m)
			{
				calli(System.Void(System.Single*), ptr, GL.EntryPoints[208]);
			}
		}

		// Token: 0x060032D8 RID: 13016 RVA: 0x00086BA0 File Offset: 0x00084DA0
		[CLSCompliant(false)]
		public unsafe static void LoadMatrix(float* m)
		{
			calli(System.Void(System.Single*), m, GL.EntryPoints[208]);
		}

		// Token: 0x060032D9 RID: 13017 RVA: 0x00086BB4 File Offset: 0x00084DB4
		[CLSCompliant(false)]
		public unsafe static void LoadMatrixx(int[] m)
		{
			fixed (int* ptr = ref (m != null && m.Length != 0) ? ref m[0] : ref *null)
			{
				calli(System.Void(System.Int32*), ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060032DA RID: 13018 RVA: 0x00086BE8 File Offset: 0x00084DE8
		[CLSCompliant(false)]
		public unsafe static void LoadMatrixx(ref int m)
		{
			fixed (int* ptr = &m)
			{
				calli(System.Void(System.Int32*), ptr, GL.EntryPoints[209]);
			}
		}

		// Token: 0x060032DB RID: 13019 RVA: 0x00086C0C File Offset: 0x00084E0C
		[CLSCompliant(false)]
		public unsafe static void LoadMatrixx(int* m)
		{
			calli(System.Void(System.Int32*), m, GL.EntryPoints[209]);
		}

		// Token: 0x060032DC RID: 13020 RVA: 0x00086C20 File Offset: 0x00084E20
		[Obsolete("Use strongly-typed overload instead")]
		public static void LogicOp(All opcode)
		{
			calli(System.Void(System.Int32), opcode, GL.EntryPoints[213]);
		}

		// Token: 0x060032DD RID: 13021 RVA: 0x00086C34 File Offset: 0x00084E34
		public static void LogicOp(LogicOp opcode)
		{
			calli(System.Void(System.Int32), opcode, GL.EntryPoints[213]);
		}

		// Token: 0x060032DE RID: 13022 RVA: 0x00086C48 File Offset: 0x00084E48
		[Obsolete("Use strongly-typed overload instead")]
		public static void Material(All face, All pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), face, pname, param, GL.EntryPoints[220]);
		}

		// Token: 0x060032DF RID: 13023 RVA: 0x00086C60 File Offset: 0x00084E60
		public static void Material(MaterialFace face, MaterialParameter pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), face, pname, param, GL.EntryPoints[220]);
		}

		// Token: 0x060032E0 RID: 13024 RVA: 0x00086C78 File Offset: 0x00084E78
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void Material(All face, All pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, ptr, GL.EntryPoints[221]);
			}
		}

		// Token: 0x060032E1 RID: 13025 RVA: 0x00086CB0 File Offset: 0x00084EB0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void Material(All face, All pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, @params, GL.EntryPoints[221]);
		}

		// Token: 0x060032E2 RID: 13026 RVA: 0x00086CC8 File Offset: 0x00084EC8
		[CLSCompliant(false)]
		public unsafe static void Material(MaterialFace face, MaterialParameter pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, ptr, GL.EntryPoints[221]);
			}
		}

		// Token: 0x060032E3 RID: 13027 RVA: 0x00086D00 File Offset: 0x00084F00
		[CLSCompliant(false)]
		public unsafe static void Material(MaterialFace face, MaterialParameter pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), face, pname, @params, GL.EntryPoints[221]);
		}

		// Token: 0x060032E4 RID: 13028 RVA: 0x00086D18 File Offset: 0x00084F18
		public static void Materialx(All face, All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), face, pname, param, GL.EntryPoints[222]);
		}

		// Token: 0x060032E5 RID: 13029 RVA: 0x00086D30 File Offset: 0x00084F30
		[CLSCompliant(false)]
		public unsafe static void Materialx(All face, All pname, int[] param)
		{
			fixed (int* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, ptr, GL.EntryPoints[224]);
			}
		}

		// Token: 0x060032E6 RID: 13030 RVA: 0x00086D68 File Offset: 0x00084F68
		[CLSCompliant(false)]
		public unsafe static void Materialx(All face, All pname, int* param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, param, GL.EntryPoints[224]);
		}

		// Token: 0x060032E7 RID: 13031 RVA: 0x00086D80 File Offset: 0x00084F80
		[Obsolete("Use strongly-typed overload instead")]
		public static void MatrixMode(All mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[227]);
		}

		// Token: 0x060032E8 RID: 13032 RVA: 0x00086D94 File Offset: 0x00084F94
		public static void MatrixMode(MatrixMode mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[227]);
		}

		// Token: 0x060032E9 RID: 13033 RVA: 0x00086DA8 File Offset: 0x00084FA8
		[Obsolete("Use strongly-typed overload instead")]
		public static void MultiTexCoord4(All target, float s, float t, float r, float q)
		{
			calli(System.Void(System.Int32,System.Single,System.Single,System.Single,System.Single), target, s, t, r, q, GL.EntryPoints[244]);
		}

		// Token: 0x060032EA RID: 13034 RVA: 0x00086DC0 File Offset: 0x00084FC0
		public static void MultiTexCoord4(TextureUnit target, float s, float t, float r, float q)
		{
			calli(System.Void(System.Int32,System.Single,System.Single,System.Single,System.Single), target, s, t, r, q, GL.EntryPoints[244]);
		}

		// Token: 0x060032EB RID: 13035 RVA: 0x00086DD8 File Offset: 0x00084FD8
		public static void MultiTexCoord4x(All texture, int s, int t, int r, int q)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, s, t, r, q, GL.EntryPoints[245]);
		}

		// Token: 0x060032EC RID: 13036 RVA: 0x00086DF0 File Offset: 0x00084FF0
		[CLSCompliant(false)]
		public unsafe static void MultMatrix(float[] m)
		{
			fixed (float* ptr = ref (m != null && m.Length != 0) ? ref m[0] : ref *null)
			{
				calli(System.Void(System.Single*), ptr, GL.EntryPoints[248]);
			}
		}

		// Token: 0x060032ED RID: 13037 RVA: 0x00086E24 File Offset: 0x00085024
		[CLSCompliant(false)]
		public unsafe static void MultMatrix(ref float m)
		{
			fixed (float* ptr = &m)
			{
				calli(System.Void(System.Single*), ptr, GL.EntryPoints[248]);
			}
		}

		// Token: 0x060032EE RID: 13038 RVA: 0x00086E48 File Offset: 0x00085048
		[CLSCompliant(false)]
		public unsafe static void MultMatrix(float* m)
		{
			calli(System.Void(System.Single*), m, GL.EntryPoints[248]);
		}

		// Token: 0x060032EF RID: 13039 RVA: 0x00086E5C File Offset: 0x0008505C
		[CLSCompliant(false)]
		public unsafe static void MultMatrixx(int[] m)
		{
			fixed (int* ptr = ref (m != null && m.Length != 0) ? ref m[0] : ref *null)
			{
				calli(System.Void(System.Int32*), ptr, GL.EntryPoints[249]);
			}
		}

		// Token: 0x060032F0 RID: 13040 RVA: 0x00086E90 File Offset: 0x00085090
		[CLSCompliant(false)]
		public unsafe static void MultMatrixx(ref int m)
		{
			fixed (int* ptr = &m)
			{
				calli(System.Void(System.Int32*), ptr, GL.EntryPoints[249]);
			}
		}

		// Token: 0x060032F1 RID: 13041 RVA: 0x00086EB4 File Offset: 0x000850B4
		[CLSCompliant(false)]
		public unsafe static void MultMatrixx(int* m)
		{
			calli(System.Void(System.Int32*), m, GL.EntryPoints[249]);
		}

		// Token: 0x060032F2 RID: 13042 RVA: 0x00086EC8 File Offset: 0x000850C8
		public static void Normal3(float nx, float ny, float nz)
		{
			calli(System.Void(System.Single,System.Single,System.Single), nx, ny, nz, GL.EntryPoints[252]);
		}

		// Token: 0x060032F3 RID: 13043 RVA: 0x00086EE0 File Offset: 0x000850E0
		public static void Normal3x(int nx, int ny, int nz)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), nx, ny, nz, GL.EntryPoints[253]);
		}

		// Token: 0x060032F4 RID: 13044 RVA: 0x00086EF8 File Offset: 0x000850F8
		[Obsolete("Use strongly-typed overload instead")]
		public static void NormalPointer(All type, int stride, IntPtr pointer)
		{
			calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, pointer, GL.EntryPoints[256]);
		}

		// Token: 0x060032F5 RID: 13045 RVA: 0x00086F10 File Offset: 0x00085110
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void NormalPointer<T2>(All type, int stride, [In] [Out] T2[] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[256]);
			}
		}

		// Token: 0x060032F6 RID: 13046 RVA: 0x00086F48 File Offset: 0x00085148
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void NormalPointer<T2>(All type, int stride, [In] [Out] T2[,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[256]);
			}
		}

		// Token: 0x060032F7 RID: 13047 RVA: 0x00086F84 File Offset: 0x00085184
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void NormalPointer<T2>(All type, int stride, [In] [Out] T2[,,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[256]);
			}
		}

		// Token: 0x060032F8 RID: 13048 RVA: 0x00086FC0 File Offset: 0x000851C0
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void NormalPointer<T2>(All type, int stride, [In] [Out] ref T2 pointer) where T2 : struct
		{
			fixed (T2* ptr = &pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[256]);
			}
		}

		// Token: 0x060032F9 RID: 13049 RVA: 0x00086FE4 File Offset: 0x000851E4
		public static void NormalPointer(NormalPointerType type, int stride, IntPtr pointer)
		{
			calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, pointer, GL.EntryPoints[256]);
		}

		// Token: 0x060032FA RID: 13050 RVA: 0x00086FFC File Offset: 0x000851FC
		[CLSCompliant(false)]
		public unsafe static void NormalPointer<T2>(NormalPointerType type, int stride, [In] [Out] T2[] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[256]);
			}
		}

		// Token: 0x060032FB RID: 13051 RVA: 0x00087034 File Offset: 0x00085234
		[CLSCompliant(false)]
		public unsafe static void NormalPointer<T2>(NormalPointerType type, int stride, [In] [Out] T2[,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[256]);
			}
		}

		// Token: 0x060032FC RID: 13052 RVA: 0x00087070 File Offset: 0x00085270
		[CLSCompliant(false)]
		public unsafe static void NormalPointer<T2>(NormalPointerType type, int stride, [In] [Out] T2[,,] pointer) where T2 : struct
		{
			fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[256]);
			}
		}

		// Token: 0x060032FD RID: 13053 RVA: 0x000870AC File Offset: 0x000852AC
		public unsafe static void NormalPointer<T2>(NormalPointerType type, int stride, [In] [Out] ref T2 pointer) where T2 : struct
		{
			fixed (T2* ptr = &pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[256]);
			}
		}

		// Token: 0x060032FE RID: 13054 RVA: 0x000870D0 File Offset: 0x000852D0
		public static void Ortho(float l, float r, float b, float t, float n, float f)
		{
			calli(System.Void(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), l, r, b, t, n, f, GL.EntryPoints[257]);
		}

		// Token: 0x060032FF RID: 13055 RVA: 0x000870EC File Offset: 0x000852EC
		public static void Orthox(int l, int r, int b, int t, int n, int f)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), l, r, b, t, n, f, GL.EntryPoints[259]);
		}

		// Token: 0x06003300 RID: 13056 RVA: 0x00087108 File Offset: 0x00085308
		[CLSCompliant(false)]
		public unsafe static void PixelMapx(All map, int size, int[] values)
		{
			fixed (int* ptr = ref (values != null && values.Length != 0) ? ref values[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), map, size, ptr, GL.EntryPoints[262]);
			}
		}

		// Token: 0x06003301 RID: 13057 RVA: 0x00087140 File Offset: 0x00085340
		[CLSCompliant(false)]
		public unsafe static void PixelMapx(All map, int size, ref int values)
		{
			fixed (int* ptr = &values)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), map, size, ptr, GL.EntryPoints[262]);
			}
		}

		// Token: 0x06003302 RID: 13058 RVA: 0x00087164 File Offset: 0x00085364
		[CLSCompliant(false)]
		public unsafe static void PixelMapx(All map, int size, int* values)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), map, size, values, GL.EntryPoints[262]);
		}

		// Token: 0x06003303 RID: 13059 RVA: 0x0008717C File Offset: 0x0008537C
		[Obsolete("Use strongly-typed overload instead")]
		public static void PixelStore(All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[263]);
		}

		// Token: 0x06003304 RID: 13060 RVA: 0x00087190 File Offset: 0x00085390
		public static void PixelStore(PixelStoreParameter pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[263]);
		}

		// Token: 0x06003305 RID: 13061 RVA: 0x000871A4 File Offset: 0x000853A4
		public static void PixelStorex(All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[264]);
		}

		// Token: 0x06003306 RID: 13062 RVA: 0x000871B8 File Offset: 0x000853B8
		public static void PointParameter(All pname, float param)
		{
			calli(System.Void(System.Int32,System.Single), pname, param, GL.EntryPoints[267]);
		}

		// Token: 0x06003307 RID: 13063 RVA: 0x000871CC File Offset: 0x000853CC
		[CLSCompliant(false)]
		public unsafe static void PointParameter(All pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Single*), pname, ptr, GL.EntryPoints[268]);
			}
		}

		// Token: 0x06003308 RID: 13064 RVA: 0x00087200 File Offset: 0x00085400
		[CLSCompliant(false)]
		public unsafe static void PointParameter(All pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Single*), pname, @params, GL.EntryPoints[268]);
		}

		// Token: 0x06003309 RID: 13065 RVA: 0x00087214 File Offset: 0x00085414
		public static void PointParameterx(All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[269]);
		}

		// Token: 0x0600330A RID: 13066 RVA: 0x00087228 File Offset: 0x00085428
		[CLSCompliant(false)]
		public unsafe static void PointParameterx(All pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[271]);
			}
		}

		// Token: 0x0600330B RID: 13067 RVA: 0x0008725C File Offset: 0x0008545C
		[CLSCompliant(false)]
		public unsafe static void PointParameterx(All pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32*), pname, @params, GL.EntryPoints[271]);
		}

		// Token: 0x0600330C RID: 13068 RVA: 0x00087270 File Offset: 0x00085470
		public static void PointSize(float size)
		{
			calli(System.Void(System.Single), size, GL.EntryPoints[273]);
		}

		// Token: 0x0600330D RID: 13069 RVA: 0x00087284 File Offset: 0x00085484
		public static void PointSizex(int size)
		{
			calli(System.Void(System.Int32), size, GL.EntryPoints[275]);
		}

		// Token: 0x0600330E RID: 13070 RVA: 0x00087298 File Offset: 0x00085498
		public static void PolygonOffset(float factor, float units)
		{
			calli(System.Void(System.Single,System.Single), factor, units, GL.EntryPoints[277]);
		}

		// Token: 0x0600330F RID: 13071 RVA: 0x000872AC File Offset: 0x000854AC
		public static void PolygonOffsetx(int factor, int units)
		{
			calli(System.Void(System.Int32,System.Int32), factor, units, GL.EntryPoints[278]);
		}

		// Token: 0x06003310 RID: 13072 RVA: 0x000872C0 File Offset: 0x000854C0
		public static void PopMatrix()
		{
			calli(System.Void(), GL.EntryPoints[280]);
		}

		// Token: 0x06003311 RID: 13073 RVA: 0x000872D4 File Offset: 0x000854D4
		public static void PushMatrix()
		{
			calli(System.Void(), GL.EntryPoints[282]);
		}

		// Token: 0x06003312 RID: 13074 RVA: 0x000872E8 File Offset: 0x000854E8
		[Obsolete("Use strongly-typed overload instead")]
		public static void ReadPixels(int x, int y, int width, int height, All format, All type, [Out] IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, pixels, GL.EntryPoints[291]);
		}

		// Token: 0x06003313 RID: 13075 RVA: 0x00087310 File Offset: 0x00085510
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, All format, All type, [In] [Out] T6[] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[291]);
			}
		}

		// Token: 0x06003314 RID: 13076 RVA: 0x00087350 File Offset: 0x00085550
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, All format, All type, [In] [Out] T6[,] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[291]);
			}
		}

		// Token: 0x06003315 RID: 13077 RVA: 0x00087394 File Offset: 0x00085594
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, All format, All type, [In] [Out] T6[,,] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[291]);
			}
		}

		// Token: 0x06003316 RID: 13078 RVA: 0x000873D8 File Offset: 0x000855D8
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, All format, All type, [In] [Out] ref T6 pixels) where T6 : struct
		{
			fixed (T6* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[291]);
			}
		}

		// Token: 0x06003317 RID: 13079 RVA: 0x00087404 File Offset: 0x00085604
		public static void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, [Out] IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, pixels, GL.EntryPoints[291]);
		}

		// Token: 0x06003318 RID: 13080 RVA: 0x0008742C File Offset: 0x0008562C
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In] [Out] T6[] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[291]);
			}
		}

		// Token: 0x06003319 RID: 13081 RVA: 0x0008746C File Offset: 0x0008566C
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In] [Out] T6[,] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[291]);
			}
		}

		// Token: 0x0600331A RID: 13082 RVA: 0x000874B0 File Offset: 0x000856B0
		[CLSCompliant(false)]
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In] [Out] T6[,,] pixels) where T6 : struct
		{
			fixed (T6* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[291]);
			}
		}

		// Token: 0x0600331B RID: 13083 RVA: 0x000874F4 File Offset: 0x000856F4
		public unsafe static void ReadPixels<T6>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In] [Out] ref T6 pixels) where T6 : struct
		{
			fixed (T6* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, ptr, GL.EntryPoints[291]);
			}
		}

		// Token: 0x0600331C RID: 13084 RVA: 0x00087520 File Offset: 0x00085720
		public static void Rotate(float angle, float x, float y, float z)
		{
			calli(System.Void(System.Single,System.Single,System.Single,System.Single), angle, x, y, z, GL.EntryPoints[299]);
		}

		// Token: 0x0600331D RID: 13085 RVA: 0x00087538 File Offset: 0x00085738
		public static void Rotatex(int angle, int x, int y, int z)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), angle, x, y, z, GL.EntryPoints[300]);
		}

		// Token: 0x0600331E RID: 13086 RVA: 0x00087550 File Offset: 0x00085750
		public static void SampleCoverage(float value, bool invert)
		{
			calli(System.Void(System.Single,System.Boolean), value, invert, GL.EntryPoints[302]);
		}

		// Token: 0x0600331F RID: 13087 RVA: 0x00087564 File Offset: 0x00085764
		public static void SampleCoveragex(int value, bool invert)
		{
			calli(System.Void(System.Int32,System.Boolean), value, invert, GL.EntryPoints[304]);
		}

		// Token: 0x06003320 RID: 13088 RVA: 0x00087578 File Offset: 0x00085778
		public static void Scale(float x, float y, float z)
		{
			calli(System.Void(System.Single,System.Single,System.Single), x, y, z, GL.EntryPoints[306]);
		}

		// Token: 0x06003321 RID: 13089 RVA: 0x00087590 File Offset: 0x00085790
		public static void Scalex(int x, int y, int z)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), x, y, z, GL.EntryPoints[307]);
		}

		// Token: 0x06003322 RID: 13090 RVA: 0x000875A8 File Offset: 0x000857A8
		public static void Scissor(int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), x, y, width, height, GL.EntryPoints[309]);
		}

		// Token: 0x06003323 RID: 13091 RVA: 0x000875C0 File Offset: 0x000857C0
		[Obsolete("Use strongly-typed overload instead")]
		public static void ShadeModel(All mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[311]);
		}

		// Token: 0x06003324 RID: 13092 RVA: 0x000875D4 File Offset: 0x000857D4
		public static void ShadeModel(ShadingModel mode)
		{
			calli(System.Void(System.Int32), mode, GL.EntryPoints[311]);
		}

		// Token: 0x06003325 RID: 13093 RVA: 0x000875E8 File Offset: 0x000857E8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void StencilFunc(All func, int @ref, int mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.UInt32), func, @ref, mask, GL.EntryPoints[313]);
		}

		// Token: 0x06003326 RID: 13094 RVA: 0x00087600 File Offset: 0x00085800
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public static void StencilFunc(All func, int @ref, uint mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.UInt32), func, @ref, mask, GL.EntryPoints[313]);
		}

		// Token: 0x06003327 RID: 13095 RVA: 0x00087618 File Offset: 0x00085818
		[CLSCompliant(false)]
		public static void StencilFunc(StencilFunction func, int @ref, int mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.UInt32), func, @ref, mask, GL.EntryPoints[313]);
		}

		// Token: 0x06003328 RID: 13096 RVA: 0x00087630 File Offset: 0x00085830
		[CLSCompliant(false)]
		public static void StencilFunc(StencilFunction func, int @ref, uint mask)
		{
			calli(System.Void(System.Int32,System.Int32,System.UInt32), func, @ref, mask, GL.EntryPoints[313]);
		}

		// Token: 0x06003329 RID: 13097 RVA: 0x00087648 File Offset: 0x00085848
		[CLSCompliant(false)]
		public static void StencilMask(int mask)
		{
			calli(System.Void(System.UInt32), mask, GL.EntryPoints[314]);
		}

		// Token: 0x0600332A RID: 13098 RVA: 0x0008765C File Offset: 0x0008585C
		[CLSCompliant(false)]
		public static void StencilMask(uint mask)
		{
			calli(System.Void(System.UInt32), mask, GL.EntryPoints[314]);
		}

		// Token: 0x0600332B RID: 13099 RVA: 0x00087670 File Offset: 0x00085870
		[Obsolete("Use strongly-typed overload instead")]
		public static void StencilOp(All fail, All zfail, All zpass)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), fail, zfail, zpass, GL.EntryPoints[315]);
		}

		// Token: 0x0600332C RID: 13100 RVA: 0x00087688 File Offset: 0x00085888
		public static void StencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), fail, zfail, zpass, GL.EntryPoints[315]);
		}

		// Token: 0x0600332D RID: 13101 RVA: 0x000876A0 File Offset: 0x000858A0
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexCoordPointer(int size, All type, int stride, IntPtr pointer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, pointer, GL.EntryPoints[333]);
		}

		// Token: 0x0600332E RID: 13102 RVA: 0x000876B8 File Offset: 0x000858B8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexCoordPointer<T3>(int size, All type, int stride, [In] [Out] T3[] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[333]);
			}
		}

		// Token: 0x0600332F RID: 13103 RVA: 0x000876F0 File Offset: 0x000858F0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexCoordPointer<T3>(int size, All type, int stride, [In] [Out] T3[,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[333]);
			}
		}

		// Token: 0x06003330 RID: 13104 RVA: 0x0008772C File Offset: 0x0008592C
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexCoordPointer<T3>(int size, All type, int stride, [In] [Out] T3[,,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[333]);
			}
		}

		// Token: 0x06003331 RID: 13105 RVA: 0x00087768 File Offset: 0x00085968
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexCoordPointer<T3>(int size, All type, int stride, [In] [Out] ref T3 pointer) where T3 : struct
		{
			fixed (T3* ptr = &pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[333]);
			}
		}

		// Token: 0x06003332 RID: 13106 RVA: 0x0008778C File Offset: 0x0008598C
		public static void TexCoordPointer(int size, TexCoordPointerType type, int stride, IntPtr pointer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, pointer, GL.EntryPoints[333]);
		}

		// Token: 0x06003333 RID: 13107 RVA: 0x000877A4 File Offset: 0x000859A4
		[CLSCompliant(false)]
		public unsafe static void TexCoordPointer<T3>(int size, TexCoordPointerType type, int stride, [In] [Out] T3[] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[333]);
			}
		}

		// Token: 0x06003334 RID: 13108 RVA: 0x000877DC File Offset: 0x000859DC
		[CLSCompliant(false)]
		public unsafe static void TexCoordPointer<T3>(int size, TexCoordPointerType type, int stride, [In] [Out] T3[,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[333]);
			}
		}

		// Token: 0x06003335 RID: 13109 RVA: 0x00087818 File Offset: 0x00085A18
		[CLSCompliant(false)]
		public unsafe static void TexCoordPointer<T3>(int size, TexCoordPointerType type, int stride, [In] [Out] T3[,,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[333]);
			}
		}

		// Token: 0x06003336 RID: 13110 RVA: 0x00087854 File Offset: 0x00085A54
		public unsafe static void TexCoordPointer<T3>(int size, TexCoordPointerType type, int stride, [In] [Out] ref T3 pointer) where T3 : struct
		{
			fixed (T3* ptr = &pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[333]);
			}
		}

		// Token: 0x06003337 RID: 13111 RVA: 0x00087878 File Offset: 0x00085A78
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexEnv(All target, All pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), target, pname, param, GL.EntryPoints[334]);
		}

		// Token: 0x06003338 RID: 13112 RVA: 0x00087890 File Offset: 0x00085A90
		public static void TexEnv(TextureEnvTarget target, TextureEnvParameter pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), target, pname, param, GL.EntryPoints[334]);
		}

		// Token: 0x06003339 RID: 13113 RVA: 0x000878A8 File Offset: 0x00085AA8
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexEnv(All target, All pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[335]);
			}
		}

		// Token: 0x0600333A RID: 13114 RVA: 0x000878E0 File Offset: 0x00085AE0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexEnv(All target, All pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[335]);
		}

		// Token: 0x0600333B RID: 13115 RVA: 0x000878F8 File Offset: 0x00085AF8
		[CLSCompliant(false)]
		public unsafe static void TexEnv(TextureEnvTarget target, TextureEnvParameter pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[335]);
			}
		}

		// Token: 0x0600333C RID: 13116 RVA: 0x00087930 File Offset: 0x00085B30
		[CLSCompliant(false)]
		public unsafe static void TexEnv(TextureEnvTarget target, TextureEnvParameter pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[335]);
		}

		// Token: 0x0600333D RID: 13117 RVA: 0x00087948 File Offset: 0x00085B48
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexEnv(All target, All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[336]);
		}

		// Token: 0x0600333E RID: 13118 RVA: 0x00087960 File Offset: 0x00085B60
		public static void TexEnv(TextureEnvTarget target, TextureEnvParameter pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[336]);
		}

		// Token: 0x0600333F RID: 13119 RVA: 0x00087978 File Offset: 0x00085B78
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexEnv(All target, All pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[337]);
			}
		}

		// Token: 0x06003340 RID: 13120 RVA: 0x000879B0 File Offset: 0x00085BB0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexEnv(All target, All pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[337]);
		}

		// Token: 0x06003341 RID: 13121 RVA: 0x000879C8 File Offset: 0x00085BC8
		[CLSCompliant(false)]
		public unsafe static void TexEnv(TextureEnvTarget target, TextureEnvParameter pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[337]);
			}
		}

		// Token: 0x06003342 RID: 13122 RVA: 0x00087A00 File Offset: 0x00085C00
		[CLSCompliant(false)]
		public unsafe static void TexEnv(TextureEnvTarget target, TextureEnvParameter pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[337]);
		}

		// Token: 0x06003343 RID: 13123 RVA: 0x00087A18 File Offset: 0x00085C18
		public static void TexEnvx(All target, All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[338]);
		}

		// Token: 0x06003344 RID: 13124 RVA: 0x00087A30 File Offset: 0x00085C30
		[CLSCompliant(false)]
		public unsafe static void TexEnvx(All target, All pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[340]);
			}
		}

		// Token: 0x06003345 RID: 13125 RVA: 0x00087A68 File Offset: 0x00085C68
		[CLSCompliant(false)]
		public unsafe static void TexEnvx(All target, All pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[340]);
		}

		// Token: 0x06003346 RID: 13126 RVA: 0x00087A80 File Offset: 0x00085C80
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexImage2D(All target, int level, int internalformat, int width, int height, int border, All format, All type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, pixels, GL.EntryPoints[348]);
		}

		// Token: 0x06003347 RID: 13127 RVA: 0x00087AAC File Offset: 0x00085CAC
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(All target, int level, int internalformat, int width, int height, int border, All format, All type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x06003348 RID: 13128 RVA: 0x00087AF0 File Offset: 0x00085CF0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(All target, int level, int internalformat, int width, int height, int border, All format, All type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x06003349 RID: 13129 RVA: 0x00087B38 File Offset: 0x00085D38
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexImage2D<T8>(All target, int level, int internalformat, int width, int height, int border, All format, All type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x0600334A RID: 13130 RVA: 0x00087B80 File Offset: 0x00085D80
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexImage2D<T8>(All target, int level, int internalformat, int width, int height, int border, All format, All type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x0600334B RID: 13131 RVA: 0x00087BB0 File Offset: 0x00085DB0
		public static void TexImage2D(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, pixels, GL.EntryPoints[348]);
		}

		// Token: 0x0600334C RID: 13132 RVA: 0x00087BDC File Offset: 0x00085DDC
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x0600334D RID: 13133 RVA: 0x00087C20 File Offset: 0x00085E20
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x0600334E RID: 13134 RVA: 0x00087C68 File Offset: 0x00085E68
		[CLSCompliant(false)]
		public unsafe static void TexImage2D<T8>(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x0600334F RID: 13135 RVA: 0x00087CB0 File Offset: 0x00085EB0
		public unsafe static void TexImage2D<T8>(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, internalformat, width, height, border, format, type, ptr, GL.EntryPoints[348]);
			}
		}

		// Token: 0x06003350 RID: 13136 RVA: 0x00087CE0 File Offset: 0x00085EE0
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexParameter(All target, All pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), target, pname, param, GL.EntryPoints[349]);
		}

		// Token: 0x06003351 RID: 13137 RVA: 0x00087CF8 File Offset: 0x00085EF8
		public static void TexParameter(TextureTarget target, TextureParameterName pname, float param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single), target, pname, param, GL.EntryPoints[349]);
		}

		// Token: 0x06003352 RID: 13138 RVA: 0x00087D10 File Offset: 0x00085F10
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexParameter(All target, All pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[350]);
			}
		}

		// Token: 0x06003353 RID: 13139 RVA: 0x00087D48 File Offset: 0x00085F48
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexParameter(All target, All pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[350]);
		}

		// Token: 0x06003354 RID: 13140 RVA: 0x00087D60 File Offset: 0x00085F60
		[CLSCompliant(false)]
		public unsafe static void TexParameter(TextureTarget target, TextureParameterName pname, float[] @params)
		{
			fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, ptr, GL.EntryPoints[350]);
			}
		}

		// Token: 0x06003355 RID: 13141 RVA: 0x00087D98 File Offset: 0x00085F98
		[CLSCompliant(false)]
		public unsafe static void TexParameter(TextureTarget target, TextureParameterName pname, float* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Single*), target, pname, @params, GL.EntryPoints[350]);
		}

		// Token: 0x06003356 RID: 13142 RVA: 0x00087DB0 File Offset: 0x00085FB0
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexParameter(All target, All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[351]);
		}

		// Token: 0x06003357 RID: 13143 RVA: 0x00087DC8 File Offset: 0x00085FC8
		public static void TexParameter(TextureTarget target, TextureParameterName pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[351]);
		}

		// Token: 0x06003358 RID: 13144 RVA: 0x00087DE0 File Offset: 0x00085FE0
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexParameter(All target, All pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[352]);
			}
		}

		// Token: 0x06003359 RID: 13145 RVA: 0x00087E18 File Offset: 0x00086018
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexParameter(All target, All pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[352]);
		}

		// Token: 0x0600335A RID: 13146 RVA: 0x00087E30 File Offset: 0x00086030
		[CLSCompliant(false)]
		public unsafe static void TexParameter(TextureTarget target, TextureParameterName pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[352]);
			}
		}

		// Token: 0x0600335B RID: 13147 RVA: 0x00087E68 File Offset: 0x00086068
		[CLSCompliant(false)]
		public unsafe static void TexParameter(TextureTarget target, TextureParameterName pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[352]);
		}

		// Token: 0x0600335C RID: 13148 RVA: 0x00087E80 File Offset: 0x00086080
		public static void TexParameterx(All target, All pname, int param)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[353]);
		}

		// Token: 0x0600335D RID: 13149 RVA: 0x00087E98 File Offset: 0x00086098
		[CLSCompliant(false)]
		public unsafe static void TexParameterx(All target, All pname, int[] @params)
		{
			fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[355]);
			}
		}

		// Token: 0x0600335E RID: 13150 RVA: 0x00087ED0 File Offset: 0x000860D0
		[CLSCompliant(false)]
		public unsafe static void TexParameterx(All target, All pname, int* @params)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[355]);
		}

		// Token: 0x0600335F RID: 13151 RVA: 0x00087EE8 File Offset: 0x000860E8
		[Obsolete("Use strongly-typed overload instead")]
		public static void TexSubImage2D(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, pixels, GL.EntryPoints[360]);
		}

		// Token: 0x06003360 RID: 13152 RVA: 0x00087F14 File Offset: 0x00086114
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[360]);
			}
		}

		// Token: 0x06003361 RID: 13153 RVA: 0x00087F58 File Offset: 0x00086158
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[360]);
			}
		}

		// Token: 0x06003362 RID: 13154 RVA: 0x00087FA0 File Offset: 0x000861A0
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[360]);
			}
		}

		// Token: 0x06003363 RID: 13155 RVA: 0x00087FE8 File Offset: 0x000861E8
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void TexSubImage2D<T8>(All target, int level, int xoffset, int yoffset, int width, int height, All format, All type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[360]);
			}
		}

		// Token: 0x06003364 RID: 13156 RVA: 0x00088018 File Offset: 0x00086218
		public static void TexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, pixels, GL.EntryPoints[360]);
		}

		// Token: 0x06003365 RID: 13157 RVA: 0x00088044 File Offset: 0x00086244
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[360]);
			}
		}

		// Token: 0x06003366 RID: 13158 RVA: 0x00088088 File Offset: 0x00086288
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[360]);
			}
		}

		// Token: 0x06003367 RID: 13159 RVA: 0x000880D0 File Offset: 0x000862D0
		[CLSCompliant(false)]
		public unsafe static void TexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] T8[,,] pixels) where T8 : struct
		{
			fixed (T8* ptr = ref (pixels != null && pixels.Length != 0) ? ref pixels[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[360]);
			}
		}

		// Token: 0x06003368 RID: 13160 RVA: 0x00088118 File Offset: 0x00086318
		public unsafe static void TexSubImage2D<T8>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, [In] [Out] ref T8 pixels) where T8 : struct
		{
			fixed (T8* ptr = &pixels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, width, height, format, type, ptr, GL.EntryPoints[360]);
			}
		}

		// Token: 0x06003369 RID: 13161 RVA: 0x00088148 File Offset: 0x00086348
		public static void Translate(float x, float y, float z)
		{
			calli(System.Void(System.Single,System.Single,System.Single), x, y, z, GL.EntryPoints[364]);
		}

		// Token: 0x0600336A RID: 13162 RVA: 0x00088160 File Offset: 0x00086360
		public static void Translatex(int x, int y, int z)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32), x, y, z, GL.EntryPoints[365]);
		}

		// Token: 0x0600336B RID: 13163 RVA: 0x00088178 File Offset: 0x00086378
		[Obsolete("Use strongly-typed overload instead")]
		public static void VertexPointer(int size, All type, int stride, IntPtr pointer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, pointer, GL.EntryPoints[380]);
		}

		// Token: 0x0600336C RID: 13164 RVA: 0x00088190 File Offset: 0x00086390
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void VertexPointer<T3>(int size, All type, int stride, [In] [Out] T3[] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[380]);
			}
		}

		// Token: 0x0600336D RID: 13165 RVA: 0x000881C8 File Offset: 0x000863C8
		[CLSCompliant(false)]
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void VertexPointer<T3>(int size, All type, int stride, [In] [Out] T3[,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[380]);
			}
		}

		// Token: 0x0600336E RID: 13166 RVA: 0x00088204 File Offset: 0x00086404
		[Obsolete("Use strongly-typed overload instead")]
		[CLSCompliant(false)]
		public unsafe static void VertexPointer<T3>(int size, All type, int stride, [In] [Out] T3[,,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[380]);
			}
		}

		// Token: 0x0600336F RID: 13167 RVA: 0x00088240 File Offset: 0x00086440
		[Obsolete("Use strongly-typed overload instead")]
		public unsafe static void VertexPointer<T3>(int size, All type, int stride, [In] [Out] ref T3 pointer) where T3 : struct
		{
			fixed (T3* ptr = &pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[380]);
			}
		}

		// Token: 0x06003370 RID: 13168 RVA: 0x00088264 File Offset: 0x00086464
		public static void VertexPointer(int size, VertexPointerType type, int stride, IntPtr pointer)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, pointer, GL.EntryPoints[380]);
		}

		// Token: 0x06003371 RID: 13169 RVA: 0x0008827C File Offset: 0x0008647C
		[CLSCompliant(false)]
		public unsafe static void VertexPointer<T3>(int size, VertexPointerType type, int stride, [In] [Out] T3[] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[380]);
			}
		}

		// Token: 0x06003372 RID: 13170 RVA: 0x000882B4 File Offset: 0x000864B4
		[CLSCompliant(false)]
		public unsafe static void VertexPointer<T3>(int size, VertexPointerType type, int stride, [In] [Out] T3[,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[380]);
			}
		}

		// Token: 0x06003373 RID: 13171 RVA: 0x000882F0 File Offset: 0x000864F0
		[CLSCompliant(false)]
		public unsafe static void VertexPointer<T3>(int size, VertexPointerType type, int stride, [In] [Out] T3[,,] pointer) where T3 : struct
		{
			fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[380]);
			}
		}

		// Token: 0x06003374 RID: 13172 RVA: 0x0008832C File Offset: 0x0008652C
		public unsafe static void VertexPointer<T3>(int size, VertexPointerType type, int stride, [In] [Out] ref T3 pointer) where T3 : struct
		{
			fixed (T3* ptr = &pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[380]);
			}
		}

		// Token: 0x06003375 RID: 13173 RVA: 0x00088350 File Offset: 0x00086550
		public static void Viewport(int x, int y, int width, int height)
		{
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), x, y, width, height, GL.EntryPoints[381]);
		}

		// Token: 0x06003376 RID: 13174 RVA: 0x00088368 File Offset: 0x00086568
		[Obsolete("Use GetClipPlane(..., float[]) instead. This method will return incorrect results.")]
		[CLSCompliant(false)]
		public static float GetClipPlane(All plane)
		{
			float result;
			calli(System.Void(System.Int32,System.Single*), plane, ref result, GL.EntryPoints[136]);
			return result;
		}

		// Token: 0x06003377 RID: 13175 RVA: 0x0008838C File Offset: 0x0008658C
		[Obsolete("Use GetClipPlane(..., int[]) instead. This method will return incorrect results.")]
		[CLSCompliant(false)]
		public static int GetClipPlanex(All plane)
		{
			int result;
			calli(System.Void(System.Int32,System.Int32*), plane, ref result, GL.EntryPoints[138]);
			return result;
		}

		// Token: 0x04004CE6 RID: 19686
		private const string Library = "GLESv1_CM";

		// Token: 0x04004CE7 RID: 19687
		private static readonly object sync_root = new object();

		// Token: 0x04004CE8 RID: 19688
		private static IntPtr[] EntryPoints;

		// Token: 0x04004CE9 RID: 19689
		private static byte[] EntryPointNames = new byte[]
		{
			103,
			108,
			65,
			99,
			99,
			117,
			109,
			120,
			79,
			69,
			83,
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
			120,
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
			120,
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			105,
			116,
			109,
			97,
			112,
			120,
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
			67,
			111,
			108,
			111,
			114,
			120,
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
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			101,
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			65,
			99,
			99,
			117,
			109,
			120,
			79,
			69,
			83,
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
			67,
			111,
			108,
			111,
			114,
			120,
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
			120,
			79,
			69,
			83,
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
			68,
			101,
			112,
			116,
			104,
			102,
			79,
			69,
			83,
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
			120,
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
			120,
			79,
			69,
			83,
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
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			102,
			0,
			103,
			108,
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			102,
			73,
			77,
			71,
			0,
			103,
			108,
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			102,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			120,
			0,
			103,
			108,
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			120,
			73,
			77,
			71,
			0,
			103,
			108,
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			51,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			51,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			52,
			102,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			52,
			117,
			98,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			52,
			120,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			52,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			111,
			108,
			111,
			114,
			52,
			120,
			118,
			79,
			69,
			83,
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
			110,
			118,
			111,
			108,
			117,
			116,
			105,
			111,
			110,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			67,
			111,
			110,
			118,
			111,
			108,
			117,
			116,
			105,
			111,
			110,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			120,
			118,
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
			67,
			117,
			114,
			114,
			101,
			110,
			116,
			80,
			97,
			108,
			101,
			116,
			116,
			101,
			77,
			97,
			116,
			114,
			105,
			120,
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			112,
			116,
			104,
			82,
			97,
			110,
			103,
			101,
			102,
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
			82,
			97,
			110,
			103,
			101,
			120,
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
			120,
			79,
			69,
			83,
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
			67,
			108,
			105,
			101,
			110,
			116,
			83,
			116,
			97,
			116,
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
			84,
			101,
			120,
			102,
			79,
			69,
			83,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			84,
			101,
			120,
			102,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			84,
			101,
			120,
			105,
			79,
			69,
			83,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			84,
			101,
			120,
			105,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			84,
			101,
			120,
			115,
			79,
			69,
			83,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			84,
			101,
			120,
			115,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			84,
			101,
			120,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			68,
			114,
			97,
			119,
			84,
			101,
			120,
			120,
			118,
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
			67,
			108,
			105,
			101,
			110,
			116,
			83,
			116,
			97,
			116,
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
			118,
			97,
			108,
			67,
			111,
			111,
			114,
			100,
			49,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			69,
			118,
			97,
			108,
			67,
			111,
			111,
			114,
			100,
			49,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			69,
			118,
			97,
			108,
			67,
			111,
			111,
			114,
			100,
			50,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			69,
			118,
			97,
			108,
			67,
			111,
			111,
			114,
			100,
			50,
			120,
			118,
			79,
			69,
			83,
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
			101,
			100,
			98,
			97,
			99,
			107,
			66,
			117,
			102,
			102,
			101,
			114,
			120,
			79,
			69,
			83,
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
			111,
			103,
			102,
			0,
			103,
			108,
			70,
			111,
			103,
			102,
			118,
			0,
			103,
			108,
			70,
			111,
			103,
			120,
			0,
			103,
			108,
			70,
			111,
			103,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			70,
			111,
			103,
			120,
			118,
			0,
			103,
			108,
			70,
			111,
			103,
			120,
			118,
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
			50,
			68,
			79,
			69,
			83,
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
			70,
			114,
			117,
			115,
			116,
			117,
			109,
			102,
			0,
			103,
			108,
			70,
			114,
			117,
			115,
			116,
			117,
			109,
			102,
			79,
			69,
			83,
			0,
			103,
			108,
			70,
			114,
			117,
			115,
			116,
			117,
			109,
			120,
			0,
			103,
			108,
			70,
			114,
			117,
			115,
			116,
			117,
			109,
			120,
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			102,
			0,
			103,
			108,
			71,
			101,
			116,
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			102,
			79,
			69,
			83,
			0,
			103,
			108,
			71,
			101,
			116,
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			120,
			0,
			103,
			108,
			71,
			101,
			116,
			67,
			108,
			105,
			112,
			80,
			108,
			97,
			110,
			101,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			71,
			101,
			116,
			67,
			111,
			110,
			118,
			111,
			108,
			117,
			116,
			105,
			111,
			110,
			80,
			97,
			114,
			97,
			109,
			101,
			116,
			101,
			114,
			120,
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
			120,
			101,
			100,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			70,
			105,
			120,
			101,
			100,
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
			79,
			69,
			83,
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
			72,
			105,
			115,
			116,
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
			120,
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
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			76,
			105,
			103,
			104,
			116,
			102,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			76,
			105,
			103,
			104,
			116,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			71,
			101,
			116,
			76,
			105,
			103,
			104,
			116,
			120,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			76,
			105,
			103,
			104,
			116,
			120,
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
			77,
			97,
			112,
			120,
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
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			102,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			71,
			101,
			116,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			120,
			118,
			0,
			103,
			108,
			71,
			101,
			116,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			120,
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
			80,
			105,
			120,
			101,
			108,
			77,
			97,
			112,
			120,
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
			79,
			69,
			83,
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
			69,
			110,
			118,
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
			69,
			110,
			118,
			105,
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
			69,
			110,
			118,
			120,
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
			69,
			110,
			118,
			120,
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
			84,
			101,
			120,
			71,
			101,
			110,
			102,
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
			84,
			101,
			120,
			71,
			101,
			110,
			105,
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
			84,
			101,
			120,
			71,
			101,
			110,
			120,
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
			120,
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
			105,
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
			120,
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
			120,
			118,
			79,
			69,
			83,
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
			100,
			101,
			120,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			73,
			110,
			100,
			101,
			120,
			120,
			118,
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			105,
			103,
			104,
			116,
			102,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			102,
			118,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			77,
			111,
			100,
			101,
			108,
			102,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			77,
			111,
			100,
			101,
			108,
			102,
			118,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			77,
			111,
			100,
			101,
			108,
			120,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			77,
			111,
			100,
			101,
			108,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			77,
			111,
			100,
			101,
			108,
			120,
			118,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			77,
			111,
			100,
			101,
			108,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			120,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			120,
			118,
			0,
			103,
			108,
			76,
			105,
			103,
			104,
			116,
			120,
			118,
			79,
			69,
			83,
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
			101,
			87,
			105,
			100,
			116,
			104,
			120,
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
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			76,
			111,
			97,
			100,
			73,
			100,
			101,
			110,
			116,
			105,
			116,
			121,
			0,
			103,
			108,
			76,
			111,
			97,
			100,
			77,
			97,
			116,
			114,
			105,
			120,
			102,
			0,
			103,
			108,
			76,
			111,
			97,
			100,
			77,
			97,
			116,
			114,
			105,
			120,
			120,
			0,
			103,
			108,
			76,
			111,
			97,
			100,
			77,
			97,
			116,
			114,
			105,
			120,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			76,
			111,
			97,
			100,
			80,
			97,
			108,
			101,
			116,
			116,
			101,
			70,
			114,
			111,
			109,
			77,
			111,
			100,
			101,
			108,
			86,
			105,
			101,
			119,
			77,
			97,
			116,
			114,
			105,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			76,
			111,
			97,
			100,
			84,
			114,
			97,
			110,
			115,
			112,
			111,
			115,
			101,
			77,
			97,
			116,
			114,
			105,
			120,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			76,
			111,
			103,
			105,
			99,
			79,
			112,
			0,
			103,
			108,
			77,
			97,
			112,
			49,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			77,
			97,
			112,
			50,
			120,
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
			97,
			112,
			71,
			114,
			105,
			100,
			49,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			77,
			97,
			112,
			71,
			114,
			105,
			100,
			50,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			102,
			0,
			103,
			108,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			102,
			118,
			0,
			103,
			108,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			120,
			0,
			103,
			108,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			120,
			118,
			0,
			103,
			108,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			77,
			97,
			116,
			114,
			105,
			120,
			73,
			110,
			100,
			101,
			120,
			80,
			111,
			105,
			110,
			116,
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
			116,
			114,
			105,
			120,
			77,
			111,
			100,
			101,
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
			77,
			117,
			108,
			116,
			105,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			49,
			98,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			49,
			98,
			118,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			49,
			120,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			49,
			120,
			118,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			50,
			98,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			50,
			98,
			118,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			50,
			120,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			50,
			120,
			118,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			51,
			98,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			51,
			98,
			118,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			51,
			120,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			51,
			120,
			118,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			98,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			98,
			118,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			102,
			0,
			103,
			108,
			77,
			117,
			108,
			116,
			105,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			120,
			0,
			103,
			108,
			77,
			117,
			108,
			116,
			105,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			120,
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
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			120,
			118,
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
			77,
			97,
			116,
			114,
			105,
			120,
			102,
			0,
			103,
			108,
			77,
			117,
			108,
			116,
			77,
			97,
			116,
			114,
			105,
			120,
			120,
			0,
			103,
			108,
			77,
			117,
			108,
			116,
			77,
			97,
			116,
			114,
			105,
			120,
			120,
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
			84,
			114,
			97,
			110,
			115,
			112,
			111,
			115,
			101,
			77,
			97,
			116,
			114,
			105,
			120,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			78,
			111,
			114,
			109,
			97,
			108,
			51,
			102,
			0,
			103,
			108,
			78,
			111,
			114,
			109,
			97,
			108,
			51,
			120,
			0,
			103,
			108,
			78,
			111,
			114,
			109,
			97,
			108,
			51,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			78,
			111,
			114,
			109,
			97,
			108,
			51,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			78,
			111,
			114,
			109,
			97,
			108,
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
			79,
			114,
			116,
			104,
			111,
			102,
			0,
			103,
			108,
			79,
			114,
			116,
			104,
			111,
			102,
			79,
			69,
			83,
			0,
			103,
			108,
			79,
			114,
			116,
			104,
			111,
			120,
			0,
			103,
			108,
			79,
			114,
			116,
			104,
			111,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			97,
			115,
			115,
			84,
			104,
			114,
			111,
			117,
			103,
			104,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			105,
			120,
			101,
			108,
			77,
			97,
			112,
			120,
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
			105,
			120,
			101,
			108,
			83,
			116,
			111,
			114,
			101,
			120,
			0,
			103,
			108,
			80,
			105,
			120,
			101,
			108,
			84,
			114,
			97,
			110,
			115,
			102,
			101,
			114,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			105,
			120,
			101,
			108,
			90,
			111,
			111,
			109,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			111,
			105,
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
			102,
			0,
			103,
			108,
			80,
			111,
			105,
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
			102,
			118,
			0,
			103,
			108,
			80,
			111,
			105,
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
			120,
			0,
			103,
			108,
			80,
			111,
			105,
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
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			111,
			105,
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
			120,
			118,
			0,
			103,
			108,
			80,
			111,
			105,
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
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			111,
			105,
			110,
			116,
			83,
			105,
			122,
			101,
			0,
			103,
			108,
			80,
			111,
			105,
			110,
			116,
			83,
			105,
			122,
			101,
			80,
			111,
			105,
			110,
			116,
			101,
			114,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			111,
			105,
			110,
			116,
			83,
			105,
			122,
			101,
			120,
			0,
			103,
			108,
			80,
			111,
			105,
			110,
			116,
			83,
			105,
			122,
			101,
			120,
			79,
			69,
			83,
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
			120,
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
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			111,
			112,
			77,
			97,
			116,
			114,
			105,
			120,
			0,
			103,
			108,
			80,
			114,
			105,
			111,
			114,
			105,
			116,
			105,
			122,
			101,
			84,
			101,
			120,
			116,
			117,
			114,
			101,
			115,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			80,
			117,
			115,
			104,
			77,
			97,
			116,
			114,
			105,
			120,
			0,
			103,
			108,
			81,
			117,
			101,
			114,
			121,
			77,
			97,
			116,
			114,
			105,
			120,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			82,
			97,
			115,
			116,
			101,
			114,
			80,
			111,
			115,
			50,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			82,
			97,
			115,
			116,
			101,
			114,
			80,
			111,
			115,
			50,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			82,
			97,
			115,
			116,
			101,
			114,
			80,
			111,
			115,
			51,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			82,
			97,
			115,
			116,
			101,
			114,
			80,
			111,
			115,
			51,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			82,
			97,
			115,
			116,
			101,
			114,
			80,
			111,
			115,
			52,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			82,
			97,
			115,
			116,
			101,
			114,
			80,
			111,
			115,
			52,
			120,
			118,
			79,
			69,
			83,
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
			99,
			116,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			82,
			101,
			99,
			116,
			120,
			118,
			79,
			69,
			83,
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
			79,
			69,
			83,
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
			82,
			111,
			116,
			97,
			116,
			101,
			102,
			0,
			103,
			108,
			82,
			111,
			116,
			97,
			116,
			101,
			120,
			0,
			103,
			108,
			82,
			111,
			116,
			97,
			116,
			101,
			120,
			79,
			69,
			83,
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
			67,
			111,
			118,
			101,
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
			120,
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
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			83,
			99,
			97,
			108,
			101,
			102,
			0,
			103,
			108,
			83,
			99,
			97,
			108,
			101,
			120,
			0,
			103,
			108,
			83,
			99,
			97,
			108,
			101,
			120,
			79,
			69,
			83,
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
			77,
			111,
			100,
			101,
			108,
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
			79,
			112,
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
			67,
			111,
			111,
			114,
			100,
			49,
			98,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			49,
			98,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			49,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			49,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			50,
			98,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			50,
			98,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			50,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			50,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			51,
			98,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			51,
			98,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			51,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			51,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			98,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			98,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
			52,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			67,
			111,
			111,
			114,
			100,
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
			84,
			101,
			120,
			69,
			110,
			118,
			102,
			0,
			103,
			108,
			84,
			101,
			120,
			69,
			110,
			118,
			102,
			118,
			0,
			103,
			108,
			84,
			101,
			120,
			69,
			110,
			118,
			105,
			0,
			103,
			108,
			84,
			101,
			120,
			69,
			110,
			118,
			105,
			118,
			0,
			103,
			108,
			84,
			101,
			120,
			69,
			110,
			118,
			120,
			0,
			103,
			108,
			84,
			101,
			120,
			69,
			110,
			118,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			69,
			110,
			118,
			120,
			118,
			0,
			103,
			108,
			84,
			101,
			120,
			69,
			110,
			118,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			71,
			101,
			110,
			102,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			71,
			101,
			110,
			102,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			71,
			101,
			110,
			105,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			71,
			101,
			110,
			105,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			71,
			101,
			110,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			84,
			101,
			120,
			71,
			101,
			110,
			120,
			118,
			79,
			69,
			83,
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
			105,
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
			120,
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
			120,
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
			120,
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
			120,
			118,
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
			114,
			97,
			110,
			115,
			108,
			97,
			116,
			101,
			102,
			0,
			103,
			108,
			84,
			114,
			97,
			110,
			115,
			108,
			97,
			116,
			101,
			120,
			0,
			103,
			108,
			84,
			114,
			97,
			110,
			115,
			108,
			97,
			116,
			101,
			120,
			79,
			69,
			83,
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
			86,
			101,
			114,
			116,
			101,
			120,
			50,
			98,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			50,
			98,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			50,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			50,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			51,
			98,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			51,
			98,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			51,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			51,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			52,
			98,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			52,
			98,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			52,
			120,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
			52,
			120,
			118,
			79,
			69,
			83,
			0,
			103,
			108,
			86,
			101,
			114,
			116,
			101,
			120,
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
			0,
			103,
			108,
			87,
			101,
			105,
			103,
			104,
			116,
			80,
			111,
			105,
			110,
			116,
			101,
			114,
			79,
			69,
			83,
			0
		};

		// Token: 0x04004CEA RID: 19690
		private static int[] EntryPointNameOffsets = new int[]
		{
			0,
			12,
			28,
			40,
			53,
			69,
			82,
			103,
			125,
			139,
			160,
			173,
			190,
			209,
			228,
			255,
			267,
			290,
			303,
			319,
			347,
			355,
			372,
			385,
			399,
			416,
			430,
			447,
			461,
			478,
			493,
			515,
			537,
			550,
			566,
			582,
			595,
			611,
			627,
			640,
			654,
			664,
			675,
			685,
			698,
			712,
			724,
			739,
			762,
			788,
			815,
			843,
			860,
			880,
			905,
			916,
			942,
			958,
			975,
			999,
			1024,
			1042,
			1059,
			1083,
			1095,
			1107,
			1121,
			1138,
			1152,
			1169,
			1179,
			1200,
			1227,
			1251,
			1264,
			1279,
			1293,
			1308,
			1322,
			1337,
			1351,
			1366,
			1380,
			1395,
			1434,
			1463,
			1472,
			1492,
			1518,
			1534,
			1551,
			1569,
			1586,
			1604,
			1631,
			1651,
			1676,
			1708,
			1729,
			1755,
			1775,
			1807,
			1831,
			1852,
			1877,
			1910,
			1931,
			1948,
			1957,
			1973,
			1981,
			2009,
			2016,
			2024,
			2031,
			2041,
			2049,
			2060,
			2089,
			2126,
			2163,
			2189,
			2201,
			2212,
			2226,
			2237,
			2251,
			2264,
			2284,
			2298,
			2319,
			2341,
			2355,
			2376,
			2390,
			2413,
			2436,
			2452,
			2471,
			2487,
			2506,
			2537,
			2561,
			2590,
			2601,
			2616,
			2628,
			2643,
			2655,
			2696,
			2724,
			2753,
			2774,
			2788,
			2801,
			2816,
			2829,
			2845,
			2859,
			2875,
			2893,
			2909,
			2928,
			2947,
			2966,
			2982,
			2996,
			3028,
			3040,
			3057,
			3071,
			3085,
			3099,
			3116,
			3133,
			3150,
			3167,
			3195,
			3215,
			3235,
			3255,
			3278,
			3285,
			3297,
			3310,
			3321,
			3333,
			3345,
			3364,
			3384,
			3398,
			3410,
			3429,
			3438,
			3448,
			3462,
			3477,
			3491,
			3508,
			3523,
			3541,
			3550,
			3562,
			3572,
			3585,
			3597,
			3610,
			3626,
			3641,
			3655,
			3669,
			3686,
			3722,
			3748,
			3758,
			3769,
			3780,
			3795,
			3815,
			3830,
			3845,
			3857,
			3870,
			3882,
			3897,
			3910,
			3926,
			3950,
			3963,
			3984,
			4007,
			4028,
			4050,
			4071,
			4093,
			4114,
			4136,
			4157,
			4179,
			4200,
			4222,
			4243,
			4265,
			4286,
			4308,
			4326,
			4344,
			4365,
			4387,
			4401,
			4415,
			4432,
			4458,
			4469,
			4480,
			4494,
			4509,
			4525,
			4534,
			4546,
			4555,
			4567,
			4585,
			4597,
			4611,
			4625,
			4645,
			4661,
			4679,
			4698,
			4716,
			4737,
			4756,
			4778,
			4790,
			4812,
			4825,
			4841,
			4857,
			4874,
			4894,
			4906,
			4931,
			4944,
			4962,
			4979,
			4997,
			5014,
			5032,
			5049,
			5067,
			5084,
			5097,
			5108,
			5120,
			5158,
			5194,
			5230,
			5255,
			5292,
			5302,
			5312,
			5325,
			5342,
			5362,
			5380,
			5401,
			5410,
			5419,
			5431,
			5441,
			5454,
			5467,
			5485,
			5499,
			5513,
			5525,
			5539,
			5555,
			5572,
			5588,
			5605,
			5621,
			5638,
			5654,
			5671,
			5687,
			5704,
			5720,
			5737,
			5753,
			5770,
			5786,
			5803,
			5821,
			5831,
			5842,
			5852,
			5863,
			5873,
			5886,
			5897,
			5911,
			5924,
			5938,
			5951,
			5965,
			5978,
			5992,
			6005,
			6021,
			6038,
			6054,
			6071,
			6087,
			6106,
			6123,
			6143,
			6161,
			6179,
			6197,
			6213,
			6235,
			6257,
			6279,
			6292,
			6305,
			6321,
			6338,
			6352,
			6367,
			6381,
			6396,
			6410,
			6425,
			6439,
			6454,
			6468,
			6483,
			6497,
			6512,
			6528,
			6539,
			6555
		};

		// Token: 0x020004FD RID: 1277
		public static class Apple
		{
			// Token: 0x06003378 RID: 13176 RVA: 0x000883B0 File Offset: 0x000865B0
			[CLSCompliant(false)]
			public static All ClientWaitSync(IntPtr sync, int flags, long timeout)
			{
				return calli(System.Int32(System.IntPtr,System.UInt32,System.UInt64), sync, flags, timeout, GL.EntryPoints[31]);
			}

			// Token: 0x06003379 RID: 13177 RVA: 0x000883C4 File Offset: 0x000865C4
			[CLSCompliant(false)]
			public static All ClientWaitSync(IntPtr sync, uint flags, ulong timeout)
			{
				return calli(System.Int32(System.IntPtr,System.UInt32,System.UInt64), sync, flags, timeout, GL.EntryPoints[31]);
			}

			// Token: 0x0600337A RID: 13178 RVA: 0x000883D8 File Offset: 0x000865D8
			[CLSCompliant(false)]
			public static void CopyTextureLevel(int destinationTexture, int sourceTexture, int sourceBaseLevel, int sourceLevelCount)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32), destinationTexture, sourceTexture, sourceBaseLevel, sourceLevelCount, GL.EntryPoints[53]);
			}

			// Token: 0x0600337B RID: 13179 RVA: 0x000883EC File Offset: 0x000865EC
			[CLSCompliant(false)]
			public static void CopyTextureLevel(uint destinationTexture, uint sourceTexture, int sourceBaseLevel, int sourceLevelCount)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.Int32,System.Int32), destinationTexture, sourceTexture, sourceBaseLevel, sourceLevelCount, GL.EntryPoints[53]);
			}

			// Token: 0x0600337C RID: 13180 RVA: 0x00088400 File Offset: 0x00086600
			public static void DeleteSync(IntPtr sync)
			{
				calli(System.Void(System.IntPtr), sync, GL.EntryPoints[60]);
			}

			// Token: 0x0600337D RID: 13181 RVA: 0x00088410 File Offset: 0x00086610
			[CLSCompliant(false)]
			public static IntPtr FenceSync(All condition, int flags)
			{
				return calli(System.IntPtr(System.Int32,System.UInt32), condition, flags, GL.EntryPoints[106]);
			}

			// Token: 0x0600337E RID: 13182 RVA: 0x00088424 File Offset: 0x00086624
			[CLSCompliant(false)]
			public static IntPtr FenceSync(All condition, uint flags)
			{
				return calli(System.IntPtr(System.Int32,System.UInt32), condition, flags, GL.EntryPoints[106]);
			}

			// Token: 0x0600337F RID: 13183 RVA: 0x00088438 File Offset: 0x00086638
			[CLSCompliant(false)]
			public static long GetInteger64(All pname)
			{
				long result;
				calli(System.Void(System.Int32,System.Int64*), pname, ref result, GL.EntryPoints[151]);
				return result;
			}

			// Token: 0x06003380 RID: 13184 RVA: 0x0008845C File Offset: 0x0008665C
			[CLSCompliant(false)]
			public unsafe static void GetInteger64(All pname, [Out] long[] @params)
			{
				fixed (long* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int64*), pname, ptr, GL.EntryPoints[151]);
				}
			}

			// Token: 0x06003381 RID: 13185 RVA: 0x00088490 File Offset: 0x00086690
			[CLSCompliant(false)]
			public unsafe static void GetInteger64(All pname, out long @params)
			{
				fixed (long* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int64*), pname, ptr, GL.EntryPoints[151]);
				}
			}

			// Token: 0x06003382 RID: 13186 RVA: 0x000884B4 File Offset: 0x000866B4
			[CLSCompliant(false)]
			public unsafe static void GetInteger64(All pname, [Out] long* @params)
			{
				calli(System.Void(System.Int32,System.Int64*), pname, @params, GL.EntryPoints[151]);
			}

			// Token: 0x06003383 RID: 13187 RVA: 0x000884C8 File Offset: 0x000866C8
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, All pname, int bufSize, [Out] int[] length, [Out] int[] values)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (values != null && values.Length != 0) ? ref values[0] : ref *null)
					{
						calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, ptr2, ptr3, GL.EntryPoints[168]);
					}
				}
			}

			// Token: 0x06003384 RID: 13188 RVA: 0x00088518 File Offset: 0x00086718
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, All pname, int bufSize, out int length, out int values)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &values)
					{
						calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, ptr2, ptr3, GL.EntryPoints[168]);
					}
				}
			}

			// Token: 0x06003385 RID: 13189 RVA: 0x00088544 File Offset: 0x00086744
			[CLSCompliant(false)]
			public unsafe static void GetSync(IntPtr sync, All pname, int bufSize, [Out] int* length, [Out] int* values)
			{
				calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32*,System.Int32*), sync, pname, bufSize, length, values, GL.EntryPoints[168]);
			}

			// Token: 0x06003386 RID: 13190 RVA: 0x0008855C File Offset: 0x0008675C
			public static bool IsSync(IntPtr sync)
			{
				return calli(System.Byte(System.IntPtr), sync, GL.EntryPoints[189]);
			}

			// Token: 0x06003387 RID: 13191 RVA: 0x00088570 File Offset: 0x00086770
			public static void RenderbufferStorageMultisample(All target, int samples, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[294]);
			}

			// Token: 0x06003388 RID: 13192 RVA: 0x00088588 File Offset: 0x00086788
			public static void ResolveMultisampleFramebuffer()
			{
				calli(System.Void(), GL.EntryPoints[298]);
			}

			// Token: 0x06003389 RID: 13193 RVA: 0x0008859C File Offset: 0x0008679C
			[CLSCompliant(false)]
			public static void WaitSync(IntPtr sync, int flags, long timeout)
			{
				calli(System.Void(System.IntPtr,System.UInt32,System.UInt64), sync, flags, timeout, GL.EntryPoints[382]);
			}

			// Token: 0x0600338A RID: 13194 RVA: 0x000885B4 File Offset: 0x000867B4
			[CLSCompliant(false)]
			public static void WaitSync(IntPtr sync, uint flags, ulong timeout)
			{
				calli(System.Void(System.IntPtr,System.UInt32,System.UInt64), sync, flags, timeout, GL.EntryPoints[382]);
			}
		}

		// Token: 0x020004FE RID: 1278
		public static class Ext
		{
			// Token: 0x0600338B RID: 13195 RVA: 0x000885CC File Offset: 0x000867CC
			[Obsolete("Use strongly-typed overload instead")]
			public static void BlendEquation(All mode)
			{
				calli(System.Void(System.Int32), mode, GL.EntryPoints[12]);
			}

			// Token: 0x0600338C RID: 13196 RVA: 0x000885DC File Offset: 0x000867DC
			public static void BlendEquation(BlendEquationModeExt mode)
			{
				calli(System.Void(System.Int32), mode, GL.EntryPoints[12]);
			}

			// Token: 0x0600338D RID: 13197 RVA: 0x000885EC File Offset: 0x000867EC
			[CLSCompliant(false)]
			public unsafe static void DiscardFramebuffer(All target, int numAttachments, All[] attachments)
			{
				fixed (All* ptr = ref (attachments != null && attachments.Length != 0) ? ref attachments[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, numAttachments, ptr, GL.EntryPoints[72]);
				}
			}

			// Token: 0x0600338E RID: 13198 RVA: 0x00088620 File Offset: 0x00086820
			[CLSCompliant(false)]
			public unsafe static void DiscardFramebuffer(All target, int numAttachments, ref All attachments)
			{
				fixed (All* ptr = &attachments)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, numAttachments, ptr, GL.EntryPoints[72]);
				}
			}

			// Token: 0x0600338F RID: 13199 RVA: 0x00088640 File Offset: 0x00086840
			[CLSCompliant(false)]
			public unsafe static void DiscardFramebuffer(All target, int numAttachments, All* attachments)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, numAttachments, attachments, GL.EntryPoints[72]);
			}

			// Token: 0x06003390 RID: 13200 RVA: 0x00088654 File Offset: 0x00086854
			public static void FlushMappedBufferRange(All target, IntPtr offset, IntPtr length)
			{
				calli(System.Void(System.Int32,System.IntPtr,System.IntPtr), target, offset, length, GL.EntryPoints[110]);
			}

			// Token: 0x06003391 RID: 13201 RVA: 0x00088668 File Offset: 0x00086868
			[CLSCompliant(false)]
			public static void FramebufferTexture2DMultisample(All target, All attachment, All textarget, int texture, int level, int samples)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, samples, GL.EntryPoints[118]);
			}

			// Token: 0x06003392 RID: 13202 RVA: 0x00088680 File Offset: 0x00086880
			[CLSCompliant(false)]
			public static void FramebufferTexture2DMultisample(All target, All attachment, All textarget, uint texture, int level, int samples)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, samples, GL.EntryPoints[118]);
			}

			// Token: 0x06003393 RID: 13203 RVA: 0x00088698 File Offset: 0x00086898
			public static All GetGraphicsResetStatus()
			{
				return calli(System.Int32(), GL.EntryPoints[149]);
			}

			// Token: 0x06003394 RID: 13204 RVA: 0x000886AC File Offset: 0x000868AC
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, [Out] float[] @params)
			{
				fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, ptr, GL.EntryPoints[162]);
				}
			}

			// Token: 0x06003395 RID: 13205 RVA: 0x000886E4 File Offset: 0x000868E4
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, out float @params)
			{
				fixed (float* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, ptr, GL.EntryPoints[162]);
				}
			}

			// Token: 0x06003396 RID: 13206 RVA: 0x00088708 File Offset: 0x00086908
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, [Out] float* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, @params, GL.EntryPoints[162]);
			}

			// Token: 0x06003397 RID: 13207 RVA: 0x00088720 File Offset: 0x00086920
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, [Out] float[] @params)
			{
				fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, ptr, GL.EntryPoints[162]);
				}
			}

			// Token: 0x06003398 RID: 13208 RVA: 0x00088758 File Offset: 0x00086958
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, out float @params)
			{
				fixed (float* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, ptr, GL.EntryPoints[162]);
				}
			}

			// Token: 0x06003399 RID: 13209 RVA: 0x0008877C File Offset: 0x0008697C
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, [Out] float* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Single*), program, location, bufSize, @params, GL.EntryPoints[162]);
			}

			// Token: 0x0600339A RID: 13210 RVA: 0x00088794 File Offset: 0x00086994
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, ptr, GL.EntryPoints[163]);
				}
			}

			// Token: 0x0600339B RID: 13211 RVA: 0x000887CC File Offset: 0x000869CC
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, ptr, GL.EntryPoints[163]);
				}
			}

			// Token: 0x0600339C RID: 13212 RVA: 0x000887F0 File Offset: 0x000869F0
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(int program, int location, int bufSize, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, @params, GL.EntryPoints[163]);
			}

			// Token: 0x0600339D RID: 13213 RVA: 0x00088808 File Offset: 0x00086A08
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, ptr, GL.EntryPoints[163]);
				}
			}

			// Token: 0x0600339E RID: 13214 RVA: 0x00088840 File Offset: 0x00086A40
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, ptr, GL.EntryPoints[163]);
				}
			}

			// Token: 0x0600339F RID: 13215 RVA: 0x00088864 File Offset: 0x00086A64
			[CLSCompliant(false)]
			public unsafe static void GetnUniform(uint program, int location, int bufSize, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32*), program, location, bufSize, @params, GL.EntryPoints[163]);
			}

			// Token: 0x060033A0 RID: 13216 RVA: 0x0008887C File Offset: 0x00086A7C
			[CLSCompliant(false)]
			public static IntPtr MapBufferRange(All target, IntPtr offset, IntPtr length, int access)
			{
				return calli(System.IntPtr(System.Int32,System.IntPtr,System.IntPtr,System.UInt32), target, offset, length, access, GL.EntryPoints[217]);
			}

			// Token: 0x060033A1 RID: 13217 RVA: 0x00088894 File Offset: 0x00086A94
			[CLSCompliant(false)]
			public static IntPtr MapBufferRange(All target, IntPtr offset, IntPtr length, uint access)
			{
				return calli(System.IntPtr(System.Int32,System.IntPtr,System.IntPtr,System.UInt32), target, offset, length, access, GL.EntryPoints[217]);
			}

			// Token: 0x060033A2 RID: 13218 RVA: 0x000888AC File Offset: 0x00086AAC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(All mode, int[] first, int[] count, int primcount)
			{
				fixed (int* ptr = ref (first != null && first.Length != 0) ? ref first[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, ptr2, ptr3, primcount, GL.EntryPoints[228]);
					}
				}
			}

			// Token: 0x060033A3 RID: 13219 RVA: 0x000888F8 File Offset: 0x00086AF8
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawArrays(All mode, ref int first, ref int count, int primcount)
			{
				fixed (int* ptr = &first)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &count)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, ptr2, ptr3, primcount, GL.EntryPoints[228]);
					}
				}
			}

			// Token: 0x060033A4 RID: 13220 RVA: 0x00088920 File Offset: 0x00086B20
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(All mode, int* first, int* count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, first, count, primcount, GL.EntryPoints[228]);
			}

			// Token: 0x060033A5 RID: 13221 RVA: 0x00088938 File Offset: 0x00086B38
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(PrimitiveType mode, int[] first, int[] count, int primcount)
			{
				fixed (int* ptr = ref (first != null && first.Length != 0) ? ref first[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, ptr2, ptr3, primcount, GL.EntryPoints[228]);
					}
				}
			}

			// Token: 0x060033A6 RID: 13222 RVA: 0x00088984 File Offset: 0x00086B84
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(PrimitiveType mode, ref int first, ref int count, int primcount)
			{
				fixed (int* ptr = &first)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &count)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, ptr2, ptr3, primcount, GL.EntryPoints[228]);
					}
				}
			}

			// Token: 0x060033A7 RID: 13223 RVA: 0x000889AC File Offset: 0x00086BAC
			[CLSCompliant(false)]
			public unsafe static void MultiDrawArrays(PrimitiveType mode, int* first, int* count, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32*,System.Int32), mode, first, count, primcount, GL.EntryPoints[228]);
			}

			// Token: 0x060033A8 RID: 13224 RVA: 0x000889C4 File Offset: 0x00086BC4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements(All mode, int[] count, All type, IntPtr indices, int primcount)
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr, type, indices, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033A9 RID: 13225 RVA: 0x000889FC File Offset: 0x00086BFC
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, int[] count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033AA RID: 13226 RVA: 0x00088A4C File Offset: 0x00086C4C
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, int[] count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033AB RID: 13227 RVA: 0x00088AA0 File Offset: 0x00086CA0
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, int[] count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033AC RID: 13228 RVA: 0x00088AF4 File Offset: 0x00086CF4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, int[] count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033AD RID: 13229 RVA: 0x00088B30 File Offset: 0x00086D30
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements(All mode, ref int count, All type, IntPtr indices, int primcount)
			{
				fixed (int* ptr = &count)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr, type, indices, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033AE RID: 13230 RVA: 0x00088B58 File Offset: 0x00086D58
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, ref int count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033AF RID: 13231 RVA: 0x00088B94 File Offset: 0x00086D94
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, ref int count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033B0 RID: 13232 RVA: 0x00088BD4 File Offset: 0x00086DD4
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, ref int count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033B1 RID: 13233 RVA: 0x00088C14 File Offset: 0x00086E14
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, ref int count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033B2 RID: 13234 RVA: 0x00088C40 File Offset: 0x00086E40
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements(All mode, int* count, All type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[229]);
			}

			// Token: 0x060033B3 RID: 13235 RVA: 0x00088C58 File Offset: 0x00086E58
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, int* count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033B4 RID: 13236 RVA: 0x00088C90 File Offset: 0x00086E90
			[CLSCompliant(false)]
			[Obsolete("Use strongly-typed overload instead")]
			public unsafe static void MultiDrawElements<T3>(All mode, int* count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033B5 RID: 13237 RVA: 0x00088CCC File Offset: 0x00086ECC
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, int* count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033B6 RID: 13238 RVA: 0x00088D0C File Offset: 0x00086F0C
			[Obsolete("Use strongly-typed overload instead")]
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(All mode, int* count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033B7 RID: 13239 RVA: 0x00088D34 File Offset: 0x00086F34
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(PrimitiveType mode, int[] count, All type, IntPtr indices, int primcount)
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr, type, indices, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033B8 RID: 13240 RVA: 0x00088D6C File Offset: 0x00086F6C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int[] count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033B9 RID: 13241 RVA: 0x00088DBC File Offset: 0x00086FBC
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int[] count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033BA RID: 13242 RVA: 0x00088E10 File Offset: 0x00087010
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int[] count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033BB RID: 13243 RVA: 0x00088E64 File Offset: 0x00087064
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int[] count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = ref (count != null && count.Length != 0) ? ref count[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033BC RID: 13244 RVA: 0x00088EA0 File Offset: 0x000870A0
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(PrimitiveType mode, ref int count, All type, IntPtr indices, int primcount)
			{
				fixed (int* ptr = &count)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr, type, indices, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033BD RID: 13245 RVA: 0x00088EC8 File Offset: 0x000870C8
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, ref int count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033BE RID: 13246 RVA: 0x00088F04 File Offset: 0x00087104
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, ref int count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033BF RID: 13247 RVA: 0x00088F44 File Offset: 0x00087144
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, ref int count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033C0 RID: 13248 RVA: 0x00088F84 File Offset: 0x00087184
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, ref int count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (int* ptr = &count)
				{
					int* ptr2 = ptr;
					fixed (T3* ptr3 = &indices)
					{
						calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, ptr2, type, ptr3, primcount, GL.EntryPoints[229]);
					}
				}
			}

			// Token: 0x060033C1 RID: 13249 RVA: 0x00088FB0 File Offset: 0x000871B0
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements(PrimitiveType mode, int* count, All type, IntPtr indices, int primcount)
			{
				calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, indices, primcount, GL.EntryPoints[229]);
			}

			// Token: 0x060033C2 RID: 13250 RVA: 0x00088FC8 File Offset: 0x000871C8
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int* count, All type, [In] [Out] T3[] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033C3 RID: 13251 RVA: 0x00089000 File Offset: 0x00087200
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int* count, All type, [In] [Out] T3[,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033C4 RID: 13252 RVA: 0x0008903C File Offset: 0x0008723C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int* count, All type, [In] [Out] T3[,,] indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = ref (indices != null && indices.Length != 0) ? ref indices[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033C5 RID: 13253 RVA: 0x0008907C File Offset: 0x0008727C
			[CLSCompliant(false)]
			public unsafe static void MultiDrawElements<T3>(PrimitiveType mode, int* count, All type, [In] [Out] ref T3 indices, int primcount) where T3 : struct
			{
				fixed (T3* ptr = &indices)
				{
					calli(System.Void(System.Int32,System.Int32*,System.Int32,System.IntPtr,System.Int32), mode, count, type, ptr, primcount, GL.EntryPoints[229]);
				}
			}

			// Token: 0x060033C6 RID: 13254 RVA: 0x000890A4 File Offset: 0x000872A4
			public static void ReadnPixels(int x, int y, int width, int height, All format, All type, int bufSize, [Out] IntPtr data)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, data, GL.EntryPoints[290]);
			}

			// Token: 0x060033C7 RID: 13255 RVA: 0x000890D0 File Offset: 0x000872D0
			[CLSCompliant(false)]
			public unsafe static void ReadnPixels<T7>(int x, int y, int width, int height, All format, All type, int bufSize, [In] [Out] T7[] data) where T7 : struct
			{
				fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, ptr, GL.EntryPoints[290]);
				}
			}

			// Token: 0x060033C8 RID: 13256 RVA: 0x00089110 File Offset: 0x00087310
			[CLSCompliant(false)]
			public unsafe static void ReadnPixels<T7>(int x, int y, int width, int height, All format, All type, int bufSize, [In] [Out] T7[,] data) where T7 : struct
			{
				fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, ptr, GL.EntryPoints[290]);
				}
			}

			// Token: 0x060033C9 RID: 13257 RVA: 0x00089154 File Offset: 0x00087354
			[CLSCompliant(false)]
			public unsafe static void ReadnPixels<T7>(int x, int y, int width, int height, All format, All type, int bufSize, [In] [Out] T7[,,] data) where T7 : struct
			{
				fixed (T7* ptr = ref (data != null && data.Length != 0) ? ref data[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, ptr, GL.EntryPoints[290]);
				}
			}

			// Token: 0x060033CA RID: 13258 RVA: 0x0008919C File Offset: 0x0008739C
			public unsafe static void ReadnPixels<T7>(int x, int y, int width, int height, All format, All type, int bufSize, [In] [Out] ref T7 data) where T7 : struct
			{
				fixed (T7* ptr = &data)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), x, y, width, height, format, type, bufSize, ptr, GL.EntryPoints[290]);
				}
			}

			// Token: 0x060033CB RID: 13259 RVA: 0x000891C8 File Offset: 0x000873C8
			public static void RenderbufferStorageMultisample(All target, int samples, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[295]);
			}

			// Token: 0x060033CC RID: 13260 RVA: 0x000891E0 File Offset: 0x000873E0
			public static void TexStorage1D(All target, int levels, All internalformat, int width)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), target, levels, internalformat, width, GL.EntryPoints[357]);
			}

			// Token: 0x060033CD RID: 13261 RVA: 0x000891F8 File Offset: 0x000873F8
			public static void TexStorage2D(All target, int levels, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, levels, internalformat, width, height, GL.EntryPoints[358]);
			}

			// Token: 0x060033CE RID: 13262 RVA: 0x00089210 File Offset: 0x00087410
			public static void TexStorage3D(All target, int levels, All internalformat, int width, int height, int depth)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, levels, internalformat, width, height, depth, GL.EntryPoints[359]);
			}

			// Token: 0x060033CF RID: 13263 RVA: 0x0008922C File Offset: 0x0008742C
			[CLSCompliant(false)]
			public static void TextureStorage1D(int texture, All target, int levels, All internalformat, int width)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, GL.EntryPoints[361]);
			}

			// Token: 0x060033D0 RID: 13264 RVA: 0x00089244 File Offset: 0x00087444
			[CLSCompliant(false)]
			public static void TextureStorage1D(uint texture, All target, int levels, All internalformat, int width)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, GL.EntryPoints[361]);
			}

			// Token: 0x060033D1 RID: 13265 RVA: 0x0008925C File Offset: 0x0008745C
			[CLSCompliant(false)]
			public static void TextureStorage2D(int texture, All target, int levels, All internalformat, int width, int height)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, height, GL.EntryPoints[362]);
			}

			// Token: 0x060033D2 RID: 13266 RVA: 0x00089278 File Offset: 0x00087478
			[CLSCompliant(false)]
			public static void TextureStorage2D(uint texture, All target, int levels, All internalformat, int width, int height)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, height, GL.EntryPoints[362]);
			}

			// Token: 0x060033D3 RID: 13267 RVA: 0x00089294 File Offset: 0x00087494
			[CLSCompliant(false)]
			public static void TextureStorage3D(int texture, All target, int levels, All internalformat, int width, int height, int depth)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, height, depth, GL.EntryPoints[363]);
			}

			// Token: 0x060033D4 RID: 13268 RVA: 0x000892BC File Offset: 0x000874BC
			[CLSCompliant(false)]
			public static void TextureStorage3D(uint texture, All target, int levels, All internalformat, int width, int height, int depth)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, target, levels, internalformat, width, height, depth, GL.EntryPoints[363]);
			}
		}

		// Token: 0x020004FF RID: 1279
		public static class Img
		{
			// Token: 0x060033D5 RID: 13269 RVA: 0x000892E4 File Offset: 0x000874E4
			[CLSCompliant(false)]
			public unsafe static void ClipPlane(All p, float[] eqn)
			{
				fixed (float* ptr = ref (eqn != null && eqn.Length != 0) ? ref eqn[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Single*), p, ptr, GL.EntryPoints[33]);
				}
			}

			// Token: 0x060033D6 RID: 13270 RVA: 0x00089318 File Offset: 0x00087518
			[CLSCompliant(false)]
			public unsafe static void ClipPlane(All p, ref float eqn)
			{
				fixed (float* ptr = &eqn)
				{
					calli(System.Void(System.Int32,System.Single*), p, ptr, GL.EntryPoints[33]);
				}
			}

			// Token: 0x060033D7 RID: 13271 RVA: 0x00089338 File Offset: 0x00087538
			[CLSCompliant(false)]
			public unsafe static void ClipPlane(All p, float* eqn)
			{
				calli(System.Void(System.Int32,System.Single*), p, eqn, GL.EntryPoints[33]);
			}

			// Token: 0x060033D8 RID: 13272 RVA: 0x0008934C File Offset: 0x0008754C
			[CLSCompliant(false)]
			public unsafe static void ClipPlanex(All p, int[] eqn)
			{
				fixed (int* ptr = ref (eqn != null && eqn.Length != 0) ? ref eqn[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), p, ptr, GL.EntryPoints[36]);
				}
			}

			// Token: 0x060033D9 RID: 13273 RVA: 0x00089380 File Offset: 0x00087580
			[CLSCompliant(false)]
			public unsafe static void ClipPlanex(All p, ref int eqn)
			{
				fixed (int* ptr = &eqn)
				{
					calli(System.Void(System.Int32,System.Int32*), p, ptr, GL.EntryPoints[36]);
				}
			}

			// Token: 0x060033DA RID: 13274 RVA: 0x000893A0 File Offset: 0x000875A0
			[CLSCompliant(false)]
			public unsafe static void ClipPlanex(All p, int* eqn)
			{
				calli(System.Void(System.Int32,System.Int32*), p, eqn, GL.EntryPoints[36]);
			}

			// Token: 0x060033DB RID: 13275 RVA: 0x000893B4 File Offset: 0x000875B4
			[CLSCompliant(false)]
			public static void FramebufferTexture2DMultisample(All target, All attachment, All textarget, int texture, int level, int samples)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, samples, GL.EntryPoints[119]);
			}

			// Token: 0x060033DC RID: 13276 RVA: 0x000893CC File Offset: 0x000875CC
			[CLSCompliant(false)]
			public static void FramebufferTexture2DMultisample(All target, All attachment, All textarget, uint texture, int level, int samples)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32,System.Int32), target, attachment, textarget, texture, level, samples, GL.EntryPoints[119]);
			}

			// Token: 0x060033DD RID: 13277 RVA: 0x000893E4 File Offset: 0x000875E4
			public static void RenderbufferStorageMultisample(All target, int samples, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, samples, internalformat, width, height, GL.EntryPoints[296]);
			}
		}

		// Token: 0x02000500 RID: 1280
		public static class NV
		{
			// Token: 0x060033DE RID: 13278 RVA: 0x000893FC File Offset: 0x000875FC
			[CLSCompliant(false)]
			public static void DeleteFence(int fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref fences, GL.EntryPoints[57]);
			}

			// Token: 0x060033DF RID: 13279 RVA: 0x00089410 File Offset: 0x00087610
			[CLSCompliant(false)]
			public static void DeleteFence(uint fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref fences, GL.EntryPoints[57]);
			}

			// Token: 0x060033E0 RID: 13280 RVA: 0x00089424 File Offset: 0x00087624
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, int[] fences)
			{
				fixed (int* ptr = ref (fences != null && fences.Length != 0) ? ref fences[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[57]);
				}
			}

			// Token: 0x060033E1 RID: 13281 RVA: 0x00089458 File Offset: 0x00087658
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, ref int fences)
			{
				fixed (int* ptr = &fences)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[57]);
				}
			}

			// Token: 0x060033E2 RID: 13282 RVA: 0x00089478 File Offset: 0x00087678
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, int* fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, fences, GL.EntryPoints[57]);
			}

			// Token: 0x060033E3 RID: 13283 RVA: 0x0008948C File Offset: 0x0008768C
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, uint[] fences)
			{
				fixed (uint* ptr = ref (fences != null && fences.Length != 0) ? ref fences[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[57]);
				}
			}

			// Token: 0x060033E4 RID: 13284 RVA: 0x000894C0 File Offset: 0x000876C0
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, ref uint fences)
			{
				fixed (uint* ptr = &fences)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[57]);
				}
			}

			// Token: 0x060033E5 RID: 13285 RVA: 0x000894E0 File Offset: 0x000876E0
			[CLSCompliant(false)]
			public unsafe static void DeleteFences(int n, uint* fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, fences, GL.EntryPoints[57]);
			}

			// Token: 0x060033E6 RID: 13286 RVA: 0x000894F4 File Offset: 0x000876F4
			[CLSCompliant(false)]
			public static void FinishFence(int fence)
			{
				calli(System.Void(System.UInt32), fence, GL.EntryPoints[108]);
			}

			// Token: 0x060033E7 RID: 13287 RVA: 0x00089504 File Offset: 0x00087704
			[CLSCompliant(false)]
			public static void FinishFence(uint fence)
			{
				calli(System.Void(System.UInt32), fence, GL.EntryPoints[108]);
			}

			// Token: 0x060033E8 RID: 13288 RVA: 0x00089514 File Offset: 0x00087714
			[CLSCompliant(false)]
			public static int GenFence()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[128]);
				return result;
			}

			// Token: 0x060033E9 RID: 13289 RVA: 0x00089538 File Offset: 0x00087738
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, [Out] int[] fences)
			{
				fixed (int* ptr = ref (fences != null && fences.Length != 0) ? ref fences[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[128]);
				}
			}

			// Token: 0x060033EA RID: 13290 RVA: 0x0008956C File Offset: 0x0008776C
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, out int fences)
			{
				fixed (int* ptr = &fences)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[128]);
				}
			}

			// Token: 0x060033EB RID: 13291 RVA: 0x00089590 File Offset: 0x00087790
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, [Out] int* fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, fences, GL.EntryPoints[128]);
			}

			// Token: 0x060033EC RID: 13292 RVA: 0x000895A4 File Offset: 0x000877A4
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, [Out] uint[] fences)
			{
				fixed (uint* ptr = ref (fences != null && fences.Length != 0) ? ref fences[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[128]);
				}
			}

			// Token: 0x060033ED RID: 13293 RVA: 0x000895D8 File Offset: 0x000877D8
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, out uint fences)
			{
				fixed (uint* ptr = &fences)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[128]);
				}
			}

			// Token: 0x060033EE RID: 13294 RVA: 0x000895FC File Offset: 0x000877FC
			[CLSCompliant(false)]
			public unsafe static void GenFences(int n, [Out] uint* fences)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, fences, GL.EntryPoints[128]);
			}

			// Token: 0x060033EF RID: 13295 RVA: 0x00089610 File Offset: 0x00087810
			[CLSCompliant(false)]
			public unsafe static void GetFence(int fence, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, ptr, GL.EntryPoints[144]);
				}
			}

			// Token: 0x060033F0 RID: 13296 RVA: 0x00089648 File Offset: 0x00087848
			[CLSCompliant(false)]
			public unsafe static void GetFence(int fence, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, ptr, GL.EntryPoints[144]);
				}
			}

			// Token: 0x060033F1 RID: 13297 RVA: 0x0008966C File Offset: 0x0008786C
			[CLSCompliant(false)]
			public unsafe static void GetFence(int fence, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, @params, GL.EntryPoints[144]);
			}

			// Token: 0x060033F2 RID: 13298 RVA: 0x00089684 File Offset: 0x00087884
			[CLSCompliant(false)]
			public unsafe static void GetFence(uint fence, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, ptr, GL.EntryPoints[144]);
				}
			}

			// Token: 0x060033F3 RID: 13299 RVA: 0x000896BC File Offset: 0x000878BC
			[CLSCompliant(false)]
			public unsafe static void GetFence(uint fence, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, ptr, GL.EntryPoints[144]);
				}
			}

			// Token: 0x060033F4 RID: 13300 RVA: 0x000896E0 File Offset: 0x000878E0
			[CLSCompliant(false)]
			public unsafe static void GetFence(uint fence, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32*), fence, pname, @params, GL.EntryPoints[144]);
			}

			// Token: 0x060033F5 RID: 13301 RVA: 0x000896F8 File Offset: 0x000878F8
			[CLSCompliant(false)]
			public static bool IsFence(int fence)
			{
				return calli(System.Byte(System.UInt32), fence, GL.EntryPoints[186]);
			}

			// Token: 0x060033F6 RID: 13302 RVA: 0x0008970C File Offset: 0x0008790C
			[CLSCompliant(false)]
			public static bool IsFence(uint fence)
			{
				return calli(System.Byte(System.UInt32), fence, GL.EntryPoints[186]);
			}

			// Token: 0x060033F7 RID: 13303 RVA: 0x00089720 File Offset: 0x00087920
			[CLSCompliant(false)]
			public static void SetFence(int fence, All condition)
			{
				calli(System.Void(System.UInt32,System.Int32), fence, condition, GL.EntryPoints[310]);
			}

			// Token: 0x060033F8 RID: 13304 RVA: 0x00089734 File Offset: 0x00087934
			[CLSCompliant(false)]
			public static void SetFence(uint fence, All condition)
			{
				calli(System.Void(System.UInt32,System.Int32), fence, condition, GL.EntryPoints[310]);
			}

			// Token: 0x060033F9 RID: 13305 RVA: 0x00089748 File Offset: 0x00087948
			[CLSCompliant(false)]
			public static bool TestFence(int fence)
			{
				return calli(System.Byte(System.UInt32), fence, GL.EntryPoints[316]);
			}

			// Token: 0x060033FA RID: 13306 RVA: 0x0008975C File Offset: 0x0008795C
			[CLSCompliant(false)]
			public static bool TestFence(uint fence)
			{
				return calli(System.Byte(System.UInt32), fence, GL.EntryPoints[316]);
			}
		}

		// Token: 0x02000501 RID: 1281
		public static class Oes
		{
			// Token: 0x060033FB RID: 13307 RVA: 0x00089770 File Offset: 0x00087970
			public static void Accumx(All op, int value)
			{
				calli(System.Void(System.Int32,System.Int32), op, value, GL.EntryPoints[0]);
			}

			// Token: 0x060033FC RID: 13308 RVA: 0x00089780 File Offset: 0x00087980
			public static void AlphaFuncx(All func, int @ref)
			{
				calli(System.Void(System.Int32,System.Int32), func, @ref, GL.EntryPoints[4]);
			}

			// Token: 0x060033FD RID: 13309 RVA: 0x00089790 File Offset: 0x00087990
			[CLSCompliant(false)]
			public static void BindFramebuffer(All target, int framebuffer)
			{
				calli(System.Void(System.Int32,System.UInt32), target, framebuffer, GL.EntryPoints[6]);
			}

			// Token: 0x060033FE RID: 13310 RVA: 0x000897A0 File Offset: 0x000879A0
			[CLSCompliant(false)]
			public static void BindFramebuffer(All target, uint framebuffer)
			{
				calli(System.Void(System.Int32,System.UInt32), target, framebuffer, GL.EntryPoints[6]);
			}

			// Token: 0x060033FF RID: 13311 RVA: 0x000897B0 File Offset: 0x000879B0
			[CLSCompliant(false)]
			public static void BindRenderbuffer(All target, int renderbuffer)
			{
				calli(System.Void(System.Int32,System.UInt32), target, renderbuffer, GL.EntryPoints[7]);
			}

			// Token: 0x06003400 RID: 13312 RVA: 0x000897C0 File Offset: 0x000879C0
			[CLSCompliant(false)]
			public static void BindRenderbuffer(All target, uint renderbuffer)
			{
				calli(System.Void(System.Int32,System.UInt32), target, renderbuffer, GL.EntryPoints[7]);
			}

			// Token: 0x06003401 RID: 13313 RVA: 0x000897D0 File Offset: 0x000879D0
			[CLSCompliant(false)]
			public static void BindVertexArray(int array)
			{
				calli(System.Void(System.UInt32), array, GL.EntryPoints[9]);
			}

			// Token: 0x06003402 RID: 13314 RVA: 0x000897E0 File Offset: 0x000879E0
			[CLSCompliant(false)]
			public static void BindVertexArray(uint array)
			{
				calli(System.Void(System.UInt32), array, GL.EntryPoints[9]);
			}

			// Token: 0x06003403 RID: 13315 RVA: 0x000897F0 File Offset: 0x000879F0
			[CLSCompliant(false)]
			public unsafe static void Bitmapx(int width, int height, int xorig, int yorig, int xmove, int ymove, byte[] bitmap)
			{
				fixed (byte* ptr = ref (bitmap != null && bitmap.Length != 0) ? ref bitmap[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Byte*), width, height, xorig, yorig, xmove, ymove, ptr, GL.EntryPoints[10]);
				}
			}

			// Token: 0x06003404 RID: 13316 RVA: 0x0008982C File Offset: 0x00087A2C
			[CLSCompliant(false)]
			public unsafe static void Bitmapx(int width, int height, int xorig, int yorig, int xmove, int ymove, ref byte bitmap)
			{
				fixed (byte* ptr = &bitmap)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Byte*), width, height, xorig, yorig, xmove, ymove, ptr, GL.EntryPoints[10]);
				}
			}

			// Token: 0x06003405 RID: 13317 RVA: 0x00089854 File Offset: 0x00087A54
			[CLSCompliant(false)]
			public unsafe static void Bitmapx(int width, int height, int xorig, int yorig, int xmove, int ymove, byte* bitmap)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Byte*), width, height, xorig, yorig, xmove, ymove, bitmap, GL.EntryPoints[10]);
			}

			// Token: 0x06003406 RID: 13318 RVA: 0x00089878 File Offset: 0x00087A78
			public static void BlendColorx(int red, int green, int blue, int alpha)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), red, green, blue, alpha, GL.EntryPoints[11]);
			}

			// Token: 0x06003407 RID: 13319 RVA: 0x0008988C File Offset: 0x00087A8C
			public static void BlendEquation(All mode)
			{
				calli(System.Void(System.Int32), mode, GL.EntryPoints[13]);
			}

			// Token: 0x06003408 RID: 13320 RVA: 0x0008989C File Offset: 0x00087A9C
			public static void BlendEquationSeparate(All modeRGB, All modeAlpha)
			{
				calli(System.Void(System.Int32,System.Int32), modeRGB, modeAlpha, GL.EntryPoints[14]);
			}

			// Token: 0x06003409 RID: 13321 RVA: 0x000898B0 File Offset: 0x00087AB0
			public static void BlendFuncSeparate(All srcRGB, All dstRGB, All srcAlpha, All dstAlpha)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), srcRGB, dstRGB, srcAlpha, dstAlpha, GL.EntryPoints[16]);
			}

			// Token: 0x0600340A RID: 13322 RVA: 0x000898C4 File Offset: 0x00087AC4
			public static All CheckFramebufferStatus(All target)
			{
				return calli(System.Int32(System.Int32), target, GL.EntryPoints[19]);
			}

			// Token: 0x0600340B RID: 13323 RVA: 0x000898D4 File Offset: 0x00087AD4
			public static void ClearAccumx(int red, int green, int blue, int alpha)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), red, green, blue, alpha, GL.EntryPoints[21]);
			}

			// Token: 0x0600340C RID: 13324 RVA: 0x000898E8 File Offset: 0x00087AE8
			public static void ClearColorx(int red, int green, int blue, int alpha)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), red, green, blue, alpha, GL.EntryPoints[24]);
			}

			// Token: 0x0600340D RID: 13325 RVA: 0x000898FC File Offset: 0x00087AFC
			public static void ClearDepth(float depth)
			{
				calli(System.Void(System.Single), depth, GL.EntryPoints[26]);
			}

			// Token: 0x0600340E RID: 13326 RVA: 0x0008990C File Offset: 0x00087B0C
			public static void ClearDepthx(int depth)
			{
				calli(System.Void(System.Int32), depth, GL.EntryPoints[28]);
			}

			// Token: 0x0600340F RID: 13327 RVA: 0x0008991C File Offset: 0x00087B1C
			[CLSCompliant(false)]
			public unsafe static void ClipPlane(All plane, float[] equation)
			{
				fixed (float* ptr = ref (equation != null && equation.Length != 0) ? ref equation[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Single*), plane, ptr, GL.EntryPoints[34]);
				}
			}

			// Token: 0x06003410 RID: 13328 RVA: 0x00089950 File Offset: 0x00087B50
			[CLSCompliant(false)]
			public unsafe static void ClipPlane(All plane, ref float equation)
			{
				fixed (float* ptr = &equation)
				{
					calli(System.Void(System.Int32,System.Single*), plane, ptr, GL.EntryPoints[34]);
				}
			}

			// Token: 0x06003411 RID: 13329 RVA: 0x00089970 File Offset: 0x00087B70
			[CLSCompliant(false)]
			public unsafe static void ClipPlane(All plane, float* equation)
			{
				calli(System.Void(System.Int32,System.Single*), plane, equation, GL.EntryPoints[34]);
			}

			// Token: 0x06003412 RID: 13330 RVA: 0x00089984 File Offset: 0x00087B84
			[CLSCompliant(false)]
			public unsafe static void ClipPlanex(All plane, int[] equation)
			{
				fixed (int* ptr = ref (equation != null && equation.Length != 0) ? ref equation[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), plane, ptr, GL.EntryPoints[37]);
				}
			}

			// Token: 0x06003413 RID: 13331 RVA: 0x000899B8 File Offset: 0x00087BB8
			[CLSCompliant(false)]
			public unsafe static void ClipPlanex(All plane, ref int equation)
			{
				fixed (int* ptr = &equation)
				{
					calli(System.Void(System.Int32,System.Int32*), plane, ptr, GL.EntryPoints[37]);
				}
			}

			// Token: 0x06003414 RID: 13332 RVA: 0x000899D8 File Offset: 0x00087BD8
			[CLSCompliant(false)]
			public unsafe static void ClipPlanex(All plane, int* equation)
			{
				calli(System.Void(System.Int32,System.Int32*), plane, equation, GL.EntryPoints[37]);
			}

			// Token: 0x06003415 RID: 13333 RVA: 0x000899EC File Offset: 0x00087BEC
			public static void Color3x(int red, int green, int blue)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), red, green, blue, GL.EntryPoints[38]);
			}

			// Token: 0x06003416 RID: 13334 RVA: 0x00089A00 File Offset: 0x00087C00
			[CLSCompliant(false)]
			public unsafe static void Color3x(int[] components)
			{
				fixed (int* ptr = ref (components != null && components.Length != 0) ? ref components[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[39]);
				}
			}

			// Token: 0x06003417 RID: 13335 RVA: 0x00089A30 File Offset: 0x00087C30
			[CLSCompliant(false)]
			public unsafe static void Color3x(ref int components)
			{
				fixed (int* ptr = &components)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[39]);
				}
			}

			// Token: 0x06003418 RID: 13336 RVA: 0x00089A50 File Offset: 0x00087C50
			[CLSCompliant(false)]
			public unsafe static void Color3x(int* components)
			{
				calli(System.Void(System.Int32*), components, GL.EntryPoints[39]);
			}

			// Token: 0x06003419 RID: 13337 RVA: 0x00089A60 File Offset: 0x00087C60
			public static void Color4x(int red, int green, int blue, int alpha)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), red, green, blue, alpha, GL.EntryPoints[43]);
			}

			// Token: 0x0600341A RID: 13338 RVA: 0x00089A74 File Offset: 0x00087C74
			[CLSCompliant(false)]
			public unsafe static void Color4x(int[] components)
			{
				fixed (int* ptr = ref (components != null && components.Length != 0) ? ref components[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x0600341B RID: 13339 RVA: 0x00089AA4 File Offset: 0x00087CA4
			[CLSCompliant(false)]
			public unsafe static void Color4x(ref int components)
			{
				fixed (int* ptr = &components)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[44]);
				}
			}

			// Token: 0x0600341C RID: 13340 RVA: 0x00089AC4 File Offset: 0x00087CC4
			[CLSCompliant(false)]
			public unsafe static void Color4x(int* components)
			{
				calli(System.Void(System.Int32*), components, GL.EntryPoints[44]);
			}

			// Token: 0x0600341D RID: 13341 RVA: 0x00089AD4 File Offset: 0x00087CD4
			public static void ConvolutionParameterx(All target, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[49]);
			}

			// Token: 0x0600341E RID: 13342 RVA: 0x00089AE8 File Offset: 0x00087CE8
			[CLSCompliant(false)]
			public unsafe static void ConvolutionParameterx(All target, All pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[50]);
				}
			}

			// Token: 0x0600341F RID: 13343 RVA: 0x00089B1C File Offset: 0x00087D1C
			[CLSCompliant(false)]
			public unsafe static void ConvolutionParameterx(All target, All pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[50]);
			}

			// Token: 0x06003420 RID: 13344 RVA: 0x00089B30 File Offset: 0x00087D30
			[CLSCompliant(false)]
			public static void CurrentPaletteMatrix(int matrixpaletteindex)
			{
				calli(System.Void(System.UInt32), matrixpaletteindex, GL.EntryPoints[55]);
			}

			// Token: 0x06003421 RID: 13345 RVA: 0x00089B40 File Offset: 0x00087D40
			[CLSCompliant(false)]
			public static void CurrentPaletteMatrix(uint matrixpaletteindex)
			{
				calli(System.Void(System.UInt32), matrixpaletteindex, GL.EntryPoints[55]);
			}

			// Token: 0x06003422 RID: 13346 RVA: 0x00089B50 File Offset: 0x00087D50
			[CLSCompliant(false)]
			public static void DeleteFramebuffer(int framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref framebuffers, GL.EntryPoints[58]);
			}

			// Token: 0x06003423 RID: 13347 RVA: 0x00089B64 File Offset: 0x00087D64
			[CLSCompliant(false)]
			public static void DeleteFramebuffer(uint framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref framebuffers, GL.EntryPoints[58]);
			}

			// Token: 0x06003424 RID: 13348 RVA: 0x00089B78 File Offset: 0x00087D78
			[CLSCompliant(false)]
			public unsafe static void DeleteFramebuffers(int n, int[] framebuffers)
			{
				fixed (int* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[58]);
				}
			}

			// Token: 0x06003425 RID: 13349 RVA: 0x00089BAC File Offset: 0x00087DAC
			[CLSCompliant(false)]
			public unsafe static void DeleteFramebuffers(int n, ref int framebuffers)
			{
				fixed (int* ptr = &framebuffers)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[58]);
				}
			}

			// Token: 0x06003426 RID: 13350 RVA: 0x00089BCC File Offset: 0x00087DCC
			[CLSCompliant(false)]
			public unsafe static void DeleteFramebuffers(int n, int* framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, framebuffers, GL.EntryPoints[58]);
			}

			// Token: 0x06003427 RID: 13351 RVA: 0x00089BE0 File Offset: 0x00087DE0
			[CLSCompliant(false)]
			public unsafe static void DeleteFramebuffers(int n, uint[] framebuffers)
			{
				fixed (uint* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[58]);
				}
			}

			// Token: 0x06003428 RID: 13352 RVA: 0x00089C14 File Offset: 0x00087E14
			[CLSCompliant(false)]
			public unsafe static void DeleteFramebuffers(int n, ref uint framebuffers)
			{
				fixed (uint* ptr = &framebuffers)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[58]);
				}
			}

			// Token: 0x06003429 RID: 13353 RVA: 0x00089C34 File Offset: 0x00087E34
			[CLSCompliant(false)]
			public unsafe static void DeleteFramebuffers(int n, uint* framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, framebuffers, GL.EntryPoints[58]);
			}

			// Token: 0x0600342A RID: 13354 RVA: 0x00089C48 File Offset: 0x00087E48
			[CLSCompliant(false)]
			public static void DeleteRenderbuffer(int renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref renderbuffers, GL.EntryPoints[59]);
			}

			// Token: 0x0600342B RID: 13355 RVA: 0x00089C5C File Offset: 0x00087E5C
			[CLSCompliant(false)]
			public static void DeleteRenderbuffer(uint renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref renderbuffers, GL.EntryPoints[59]);
			}

			// Token: 0x0600342C RID: 13356 RVA: 0x00089C70 File Offset: 0x00087E70
			[CLSCompliant(false)]
			public unsafe static void DeleteRenderbuffers(int n, int[] renderbuffers)
			{
				fixed (int* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[59]);
				}
			}

			// Token: 0x0600342D RID: 13357 RVA: 0x00089CA4 File Offset: 0x00087EA4
			[CLSCompliant(false)]
			public unsafe static void DeleteRenderbuffers(int n, ref int renderbuffers)
			{
				fixed (int* ptr = &renderbuffers)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[59]);
				}
			}

			// Token: 0x0600342E RID: 13358 RVA: 0x00089CC4 File Offset: 0x00087EC4
			[CLSCompliant(false)]
			public unsafe static void DeleteRenderbuffers(int n, int* renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, renderbuffers, GL.EntryPoints[59]);
			}

			// Token: 0x0600342F RID: 13359 RVA: 0x00089CD8 File Offset: 0x00087ED8
			[CLSCompliant(false)]
			public unsafe static void DeleteRenderbuffers(int n, uint[] renderbuffers)
			{
				fixed (uint* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[59]);
				}
			}

			// Token: 0x06003430 RID: 13360 RVA: 0x00089D0C File Offset: 0x00087F0C
			[CLSCompliant(false)]
			public unsafe static void DeleteRenderbuffers(int n, ref uint renderbuffers)
			{
				fixed (uint* ptr = &renderbuffers)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[59]);
				}
			}

			// Token: 0x06003431 RID: 13361 RVA: 0x00089D2C File Offset: 0x00087F2C
			[CLSCompliant(false)]
			public unsafe static void DeleteRenderbuffers(int n, uint* renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, renderbuffers, GL.EntryPoints[59]);
			}

			// Token: 0x06003432 RID: 13362 RVA: 0x00089D40 File Offset: 0x00087F40
			[CLSCompliant(false)]
			public static void DeleteVertexArray(int arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref arrays, GL.EntryPoints[62]);
			}

			// Token: 0x06003433 RID: 13363 RVA: 0x00089D54 File Offset: 0x00087F54
			[CLSCompliant(false)]
			public static void DeleteVertexArray(uint arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), 1, ref arrays, GL.EntryPoints[62]);
			}

			// Token: 0x06003434 RID: 13364 RVA: 0x00089D68 File Offset: 0x00087F68
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, int[] arrays)
			{
				fixed (int* ptr = ref (arrays != null && arrays.Length != 0) ? ref arrays[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003435 RID: 13365 RVA: 0x00089D9C File Offset: 0x00087F9C
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, ref int arrays)
			{
				fixed (int* ptr = &arrays)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003436 RID: 13366 RVA: 0x00089DBC File Offset: 0x00087FBC
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, int* arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, arrays, GL.EntryPoints[62]);
			}

			// Token: 0x06003437 RID: 13367 RVA: 0x00089DD0 File Offset: 0x00087FD0
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, uint[] arrays)
			{
				fixed (uint* ptr = ref (arrays != null && arrays.Length != 0) ? ref arrays[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003438 RID: 13368 RVA: 0x00089E04 File Offset: 0x00088004
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, ref uint arrays)
			{
				fixed (uint* ptr = &arrays)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[62]);
				}
			}

			// Token: 0x06003439 RID: 13369 RVA: 0x00089E24 File Offset: 0x00088024
			[CLSCompliant(false)]
			public unsafe static void DeleteVertexArrays(int n, uint* arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, arrays, GL.EntryPoints[62]);
			}

			// Token: 0x0600343A RID: 13370 RVA: 0x00089E38 File Offset: 0x00088038
			public static void DepthRange(float n, float f)
			{
				calli(System.Void(System.Single,System.Single), n, f, GL.EntryPoints[66]);
			}

			// Token: 0x0600343B RID: 13371 RVA: 0x00089E4C File Offset: 0x0008804C
			public static void DepthRangex(int n, int f)
			{
				calli(System.Void(System.Int32,System.Int32), n, f, GL.EntryPoints[68]);
			}

			// Token: 0x0600343C RID: 13372 RVA: 0x00089E60 File Offset: 0x00088060
			public static void DrawTex(float x, float y, float z, float width, float height)
			{
				calli(System.Void(System.Single,System.Single,System.Single,System.Single,System.Single), x, y, z, width, height, GL.EntryPoints[75]);
			}

			// Token: 0x0600343D RID: 13373 RVA: 0x00089E78 File Offset: 0x00088078
			[CLSCompliant(false)]
			public unsafe static void DrawTex(float[] coords)
			{
				fixed (float* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Single*), ptr, GL.EntryPoints[76]);
				}
			}

			// Token: 0x0600343E RID: 13374 RVA: 0x00089EA8 File Offset: 0x000880A8
			[CLSCompliant(false)]
			public unsafe static void DrawTex(ref float coords)
			{
				fixed (float* ptr = &coords)
				{
					calli(System.Void(System.Single*), ptr, GL.EntryPoints[76]);
				}
			}

			// Token: 0x0600343F RID: 13375 RVA: 0x00089EC8 File Offset: 0x000880C8
			[CLSCompliant(false)]
			public unsafe static void DrawTex(float* coords)
			{
				calli(System.Void(System.Single*), coords, GL.EntryPoints[76]);
			}

			// Token: 0x06003440 RID: 13376 RVA: 0x00089ED8 File Offset: 0x000880D8
			public static void DrawTex(int x, int y, int z, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), x, y, z, width, height, GL.EntryPoints[77]);
			}

			// Token: 0x06003441 RID: 13377 RVA: 0x00089EF0 File Offset: 0x000880F0
			[CLSCompliant(false)]
			public unsafe static void DrawTex(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[78]);
				}
			}

			// Token: 0x06003442 RID: 13378 RVA: 0x00089F20 File Offset: 0x00088120
			[CLSCompliant(false)]
			public unsafe static void DrawTex(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[78]);
				}
			}

			// Token: 0x06003443 RID: 13379 RVA: 0x00089F40 File Offset: 0x00088140
			[CLSCompliant(false)]
			public unsafe static void DrawTex(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[78]);
			}

			// Token: 0x06003444 RID: 13380 RVA: 0x00089F50 File Offset: 0x00088150
			public static void DrawTex(short x, short y, short z, short width, short height)
			{
				calli(System.Void(System.Int16,System.Int16,System.Int16,System.Int16,System.Int16), x, y, z, width, height, GL.EntryPoints[79]);
			}

			// Token: 0x06003445 RID: 13381 RVA: 0x00089F68 File Offset: 0x00088168
			[CLSCompliant(false)]
			public unsafe static void DrawTex(short[] coords)
			{
				fixed (short* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int16*), ptr, GL.EntryPoints[80]);
				}
			}

			// Token: 0x06003446 RID: 13382 RVA: 0x00089F98 File Offset: 0x00088198
			[CLSCompliant(false)]
			public unsafe static void DrawTex(ref short coords)
			{
				fixed (short* ptr = &coords)
				{
					calli(System.Void(System.Int16*), ptr, GL.EntryPoints[80]);
				}
			}

			// Token: 0x06003447 RID: 13383 RVA: 0x00089FB8 File Offset: 0x000881B8
			[CLSCompliant(false)]
			public unsafe static void DrawTex(short* coords)
			{
				calli(System.Void(System.Int16*), coords, GL.EntryPoints[80]);
			}

			// Token: 0x06003448 RID: 13384 RVA: 0x00089FC8 File Offset: 0x000881C8
			public static void DrawTexx(int x, int y, int z, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), x, y, z, width, height, GL.EntryPoints[81]);
			}

			// Token: 0x06003449 RID: 13385 RVA: 0x00089FE0 File Offset: 0x000881E0
			[CLSCompliant(false)]
			public unsafe static void DrawTexx(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[82]);
				}
			}

			// Token: 0x0600344A RID: 13386 RVA: 0x0008A010 File Offset: 0x00088210
			[CLSCompliant(false)]
			public unsafe static void DrawTexx(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[82]);
				}
			}

			// Token: 0x0600344B RID: 13387 RVA: 0x0008A030 File Offset: 0x00088230
			[CLSCompliant(false)]
			public unsafe static void DrawTexx(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[82]);
			}

			// Token: 0x0600344C RID: 13388 RVA: 0x0008A040 File Offset: 0x00088240
			public static void EGLImageTargetRenderbufferStorage(All target, IntPtr image)
			{
				calli(System.Void(System.Int32,System.IntPtr), target, image, GL.EntryPoints[83]);
			}

			// Token: 0x0600344D RID: 13389 RVA: 0x0008A054 File Offset: 0x00088254
			public static void EGLImageTargetTexture2D(All target, IntPtr image)
			{
				calli(System.Void(System.Int32,System.IntPtr), target, image, GL.EntryPoints[84]);
			}

			// Token: 0x0600344E RID: 13390 RVA: 0x0008A068 File Offset: 0x00088268
			public static void EvalCoord1x(int u)
			{
				calli(System.Void(System.Int32), u, GL.EntryPoints[89]);
			}

			// Token: 0x0600344F RID: 13391 RVA: 0x0008A078 File Offset: 0x00088278
			[CLSCompliant(false)]
			public unsafe static void EvalCoord1x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[90]);
			}

			// Token: 0x06003450 RID: 13392 RVA: 0x0008A088 File Offset: 0x00088288
			public static void EvalCoord2x(int u, int v)
			{
				calli(System.Void(System.Int32,System.Int32), u, v, GL.EntryPoints[91]);
			}

			// Token: 0x06003451 RID: 13393 RVA: 0x0008A09C File Offset: 0x0008829C
			[CLSCompliant(false)]
			public unsafe static void EvalCoord2x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[92]);
				}
			}

			// Token: 0x06003452 RID: 13394 RVA: 0x0008A0CC File Offset: 0x000882CC
			[CLSCompliant(false)]
			public unsafe static void EvalCoord2x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[92]);
				}
			}

			// Token: 0x06003453 RID: 13395 RVA: 0x0008A0EC File Offset: 0x000882EC
			[CLSCompliant(false)]
			public unsafe static void EvalCoord2x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[92]);
			}

			// Token: 0x06003454 RID: 13396 RVA: 0x0008A0FC File Offset: 0x000882FC
			[CLSCompliant(false)]
			public unsafe static void FeedbackBufferx(int n, All type, int[] buffer)
			{
				fixed (int* ptr = ref (buffer != null && buffer.Length != 0) ? ref buffer[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), n, type, ptr, GL.EntryPoints[105]);
				}
			}

			// Token: 0x06003455 RID: 13397 RVA: 0x0008A130 File Offset: 0x00088330
			[CLSCompliant(false)]
			public unsafe static void FeedbackBufferx(int n, All type, ref int buffer)
			{
				fixed (int* ptr = &buffer)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), n, type, ptr, GL.EntryPoints[105]);
				}
			}

			// Token: 0x06003456 RID: 13398 RVA: 0x0008A150 File Offset: 0x00088350
			[CLSCompliant(false)]
			public unsafe static void FeedbackBufferx(int n, All type, int* buffer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), n, type, buffer, GL.EntryPoints[105]);
			}

			// Token: 0x06003457 RID: 13399 RVA: 0x0008A164 File Offset: 0x00088364
			public static void Fogx(All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[114]);
			}

			// Token: 0x06003458 RID: 13400 RVA: 0x0008A178 File Offset: 0x00088378
			[CLSCompliant(false)]
			public unsafe static void Fogx(All pname, int[] param)
			{
				fixed (int* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[116]);
				}
			}

			// Token: 0x06003459 RID: 13401 RVA: 0x0008A1AC File Offset: 0x000883AC
			[CLSCompliant(false)]
			public unsafe static void Fogx(All pname, int* param)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, param, GL.EntryPoints[116]);
			}

			// Token: 0x0600345A RID: 13402 RVA: 0x0008A1C0 File Offset: 0x000883C0
			[CLSCompliant(false)]
			public static void FramebufferRenderbuffer(All target, All attachment, All renderbuffertarget, int renderbuffer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), target, attachment, renderbuffertarget, renderbuffer, GL.EntryPoints[117]);
			}

			// Token: 0x0600345B RID: 13403 RVA: 0x0008A1D4 File Offset: 0x000883D4
			[CLSCompliant(false)]
			public static void FramebufferRenderbuffer(All target, All attachment, All renderbuffertarget, uint renderbuffer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32), target, attachment, renderbuffertarget, renderbuffer, GL.EntryPoints[117]);
			}

			// Token: 0x0600345C RID: 13404 RVA: 0x0008A1E8 File Offset: 0x000883E8
			[CLSCompliant(false)]
			public static void FramebufferTexture2D(All target, All attachment, All textarget, int texture, int level)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[120]);
			}

			// Token: 0x0600345D RID: 13405 RVA: 0x0008A200 File Offset: 0x00088400
			[CLSCompliant(false)]
			public static void FramebufferTexture2D(All target, All attachment, All textarget, uint texture, int level)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.UInt32,System.Int32), target, attachment, textarget, texture, level, GL.EntryPoints[120]);
			}

			// Token: 0x0600345E RID: 13406 RVA: 0x0008A218 File Offset: 0x00088418
			public static void Frustum(float l, float r, float b, float t, float n, float f)
			{
				calli(System.Void(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), l, r, b, t, n, f, GL.EntryPoints[123]);
			}

			// Token: 0x0600345F RID: 13407 RVA: 0x0008A230 File Offset: 0x00088430
			public static void Frustumx(int l, int r, int b, int t, int n, int f)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), l, r, b, t, n, f, GL.EntryPoints[125]);
			}

			// Token: 0x06003460 RID: 13408 RVA: 0x0008A248 File Offset: 0x00088448
			public static void GenerateMipmap(All target)
			{
				calli(System.Void(System.Int32), target, GL.EntryPoints[127]);
			}

			// Token: 0x06003461 RID: 13409 RVA: 0x0008A258 File Offset: 0x00088458
			[CLSCompliant(false)]
			public static int GenFramebuffer()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[129]);
				return result;
			}

			// Token: 0x06003462 RID: 13410 RVA: 0x0008A27C File Offset: 0x0008847C
			[CLSCompliant(false)]
			public unsafe static void GenFramebuffers(int n, [Out] int[] framebuffers)
			{
				fixed (int* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[129]);
				}
			}

			// Token: 0x06003463 RID: 13411 RVA: 0x0008A2B0 File Offset: 0x000884B0
			[CLSCompliant(false)]
			public unsafe static void GenFramebuffers(int n, out int framebuffers)
			{
				fixed (int* ptr = &framebuffers)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[129]);
				}
			}

			// Token: 0x06003464 RID: 13412 RVA: 0x0008A2D4 File Offset: 0x000884D4
			[CLSCompliant(false)]
			public unsafe static void GenFramebuffers(int n, [Out] int* framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, framebuffers, GL.EntryPoints[129]);
			}

			// Token: 0x06003465 RID: 13413 RVA: 0x0008A2E8 File Offset: 0x000884E8
			[CLSCompliant(false)]
			public unsafe static void GenFramebuffers(int n, [Out] uint[] framebuffers)
			{
				fixed (uint* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[129]);
				}
			}

			// Token: 0x06003466 RID: 13414 RVA: 0x0008A31C File Offset: 0x0008851C
			[CLSCompliant(false)]
			public unsafe static void GenFramebuffers(int n, out uint framebuffers)
			{
				fixed (uint* ptr = &framebuffers)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[129]);
				}
			}

			// Token: 0x06003467 RID: 13415 RVA: 0x0008A340 File Offset: 0x00088540
			[CLSCompliant(false)]
			public unsafe static void GenFramebuffers(int n, [Out] uint* framebuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, framebuffers, GL.EntryPoints[129]);
			}

			// Token: 0x06003468 RID: 13416 RVA: 0x0008A354 File Offset: 0x00088554
			[CLSCompliant(false)]
			public static int GenRenderbuffer()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[130]);
				return result;
			}

			// Token: 0x06003469 RID: 13417 RVA: 0x0008A378 File Offset: 0x00088578
			[CLSCompliant(false)]
			public unsafe static void GenRenderbuffers(int n, [Out] int[] renderbuffers)
			{
				fixed (int* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[130]);
				}
			}

			// Token: 0x0600346A RID: 13418 RVA: 0x0008A3AC File Offset: 0x000885AC
			[CLSCompliant(false)]
			public unsafe static void GenRenderbuffers(int n, out int renderbuffers)
			{
				fixed (int* ptr = &renderbuffers)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[130]);
				}
			}

			// Token: 0x0600346B RID: 13419 RVA: 0x0008A3D0 File Offset: 0x000885D0
			[CLSCompliant(false)]
			public unsafe static void GenRenderbuffers(int n, [Out] int* renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, renderbuffers, GL.EntryPoints[130]);
			}

			// Token: 0x0600346C RID: 13420 RVA: 0x0008A3E4 File Offset: 0x000885E4
			[CLSCompliant(false)]
			public unsafe static void GenRenderbuffers(int n, [Out] uint[] renderbuffers)
			{
				fixed (uint* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[130]);
				}
			}

			// Token: 0x0600346D RID: 13421 RVA: 0x0008A418 File Offset: 0x00088618
			[CLSCompliant(false)]
			public unsafe static void GenRenderbuffers(int n, out uint renderbuffers)
			{
				fixed (uint* ptr = &renderbuffers)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[130]);
				}
			}

			// Token: 0x0600346E RID: 13422 RVA: 0x0008A43C File Offset: 0x0008863C
			[CLSCompliant(false)]
			public unsafe static void GenRenderbuffers(int n, [Out] uint* renderbuffers)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, renderbuffers, GL.EntryPoints[130]);
			}

			// Token: 0x0600346F RID: 13423 RVA: 0x0008A450 File Offset: 0x00088650
			[CLSCompliant(false)]
			public static int GenVertexArray()
			{
				int result;
				calli(System.Void(System.Int32,System.UInt32*), 1, ref result, GL.EntryPoints[132]);
				return result;
			}

			// Token: 0x06003470 RID: 13424 RVA: 0x0008A474 File Offset: 0x00088674
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, [Out] int[] arrays)
			{
				fixed (int* ptr = ref (arrays != null && arrays.Length != 0) ? ref arrays[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[132]);
				}
			}

			// Token: 0x06003471 RID: 13425 RVA: 0x0008A4A8 File Offset: 0x000886A8
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, out int arrays)
			{
				fixed (int* ptr = &arrays)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[132]);
				}
			}

			// Token: 0x06003472 RID: 13426 RVA: 0x0008A4CC File Offset: 0x000886CC
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, [Out] int* arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, arrays, GL.EntryPoints[132]);
			}

			// Token: 0x06003473 RID: 13427 RVA: 0x0008A4E0 File Offset: 0x000886E0
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, [Out] uint[] arrays)
			{
				fixed (uint* ptr = ref (arrays != null && arrays.Length != 0) ? ref arrays[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[132]);
				}
			}

			// Token: 0x06003474 RID: 13428 RVA: 0x0008A514 File Offset: 0x00088714
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, out uint arrays)
			{
				fixed (uint* ptr = &arrays)
				{
					calli(System.Void(System.Int32,System.UInt32*), n, ptr, GL.EntryPoints[132]);
				}
			}

			// Token: 0x06003475 RID: 13429 RVA: 0x0008A538 File Offset: 0x00088738
			[CLSCompliant(false)]
			public unsafe static void GenVertexArrays(int n, [Out] uint* arrays)
			{
				calli(System.Void(System.Int32,System.UInt32*), n, arrays, GL.EntryPoints[132]);
			}

			// Token: 0x06003476 RID: 13430 RVA: 0x0008A54C File Offset: 0x0008874C
			public static void GetBufferPointer(All target, All pname, [Out] IntPtr @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, @params, GL.EntryPoints[135]);
			}

			// Token: 0x06003477 RID: 13431 RVA: 0x0008A564 File Offset: 0x00088764
			[CLSCompliant(false)]
			public unsafe static void GetBufferPointer<T2>(All target, All pname, [In] [Out] T2[] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[135]);
				}
			}

			// Token: 0x06003478 RID: 13432 RVA: 0x0008A59C File Offset: 0x0008879C
			[CLSCompliant(false)]
			public unsafe static void GetBufferPointer<T2>(All target, All pname, [In] [Out] T2[,] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[135]);
				}
			}

			// Token: 0x06003479 RID: 13433 RVA: 0x0008A5D8 File Offset: 0x000887D8
			[CLSCompliant(false)]
			public unsafe static void GetBufferPointer<T2>(All target, All pname, [In] [Out] T2[,,] @params) where T2 : struct
			{
				fixed (T2* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[135]);
				}
			}

			// Token: 0x0600347A RID: 13434 RVA: 0x0008A614 File Offset: 0x00088814
			public unsafe static void GetBufferPointer<T2>(All target, All pname, [In] [Out] ref T2 @params) where T2 : struct
			{
				fixed (T2* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), target, pname, ptr, GL.EntryPoints[135]);
				}
			}

			// Token: 0x0600347B RID: 13435 RVA: 0x0008A638 File Offset: 0x00088838
			[CLSCompliant(false)]
			public unsafe static void GetClipPlane(All plane, [Out] float[] equation)
			{
				fixed (float* ptr = ref (equation != null && equation.Length != 0) ? ref equation[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Single*), plane, ptr, GL.EntryPoints[137]);
				}
			}

			// Token: 0x0600347C RID: 13436 RVA: 0x0008A66C File Offset: 0x0008886C
			[CLSCompliant(false)]
			public unsafe static void GetClipPlane(All plane, out float equation)
			{
				fixed (float* ptr = &equation)
				{
					calli(System.Void(System.Int32,System.Single*), plane, ptr, GL.EntryPoints[137]);
				}
			}

			// Token: 0x0600347D RID: 13437 RVA: 0x0008A690 File Offset: 0x00088890
			[CLSCompliant(false)]
			public unsafe static void GetClipPlane(All plane, [Out] float* equation)
			{
				calli(System.Void(System.Int32,System.Single*), plane, equation, GL.EntryPoints[137]);
			}

			// Token: 0x0600347E RID: 13438 RVA: 0x0008A6A4 File Offset: 0x000888A4
			[CLSCompliant(false)]
			public unsafe static void GetClipPlanex(All plane, [Out] int[] equation)
			{
				fixed (int* ptr = ref (equation != null && equation.Length != 0) ? ref equation[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), plane, ptr, GL.EntryPoints[139]);
				}
			}

			// Token: 0x0600347F RID: 13439 RVA: 0x0008A6D8 File Offset: 0x000888D8
			[CLSCompliant(false)]
			public unsafe static void GetClipPlanex(All plane, out int equation)
			{
				fixed (int* ptr = &equation)
				{
					calli(System.Void(System.Int32,System.Int32*), plane, ptr, GL.EntryPoints[139]);
				}
			}

			// Token: 0x06003480 RID: 13440 RVA: 0x0008A6FC File Offset: 0x000888FC
			[CLSCompliant(false)]
			public unsafe static void GetClipPlanex(All plane, [Out] int* equation)
			{
				calli(System.Void(System.Int32,System.Int32*), plane, equation, GL.EntryPoints[139]);
			}

			// Token: 0x06003481 RID: 13441 RVA: 0x0008A710 File Offset: 0x00088910
			[CLSCompliant(false)]
			public unsafe static void GetConvolutionParameterx(All target, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[140]);
				}
			}

			// Token: 0x06003482 RID: 13442 RVA: 0x0008A748 File Offset: 0x00088948
			[CLSCompliant(false)]
			public unsafe static void GetConvolutionParameterx(All target, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[140]);
				}
			}

			// Token: 0x06003483 RID: 13443 RVA: 0x0008A76C File Offset: 0x0008896C
			[CLSCompliant(false)]
			public unsafe static void GetConvolutionParameterx(All target, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[140]);
			}

			// Token: 0x06003484 RID: 13444 RVA: 0x0008A784 File Offset: 0x00088984
			[CLSCompliant(false)]
			public static int GetFixed(All pname)
			{
				int result;
				calli(System.Void(System.Int32,System.Int32*), pname, ref result, GL.EntryPoints[146]);
				return result;
			}

			// Token: 0x06003485 RID: 13445 RVA: 0x0008A7A8 File Offset: 0x000889A8
			[CLSCompliant(false)]
			public unsafe static void GetFixed(All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[146]);
				}
			}

			// Token: 0x06003486 RID: 13446 RVA: 0x0008A7DC File Offset: 0x000889DC
			[CLSCompliant(false)]
			public unsafe static void GetFixed(All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[146]);
				}
			}

			// Token: 0x06003487 RID: 13447 RVA: 0x0008A800 File Offset: 0x00088A00
			[CLSCompliant(false)]
			public unsafe static void GetFixed(All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, @params, GL.EntryPoints[146]);
			}

			// Token: 0x06003488 RID: 13448 RVA: 0x0008A814 File Offset: 0x00088A14
			[CLSCompliant(false)]
			public unsafe static void GetFramebufferAttachmentParameter(All target, All attachment, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x06003489 RID: 13449 RVA: 0x0008A84C File Offset: 0x00088A4C
			[CLSCompliant(false)]
			public unsafe static void GetFramebufferAttachmentParameter(All target, All attachment, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, ptr, GL.EntryPoints[148]);
				}
			}

			// Token: 0x0600348A RID: 13450 RVA: 0x0008A870 File Offset: 0x00088A70
			[CLSCompliant(false)]
			public unsafe static void GetFramebufferAttachmentParameter(All target, All attachment, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, attachment, pname, @params, GL.EntryPoints[148]);
			}

			// Token: 0x0600348B RID: 13451 RVA: 0x0008A888 File Offset: 0x00088A88
			[CLSCompliant(false)]
			public unsafe static void GetHistogramParameterx(All target, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[150]);
				}
			}

			// Token: 0x0600348C RID: 13452 RVA: 0x0008A8C0 File Offset: 0x00088AC0
			[CLSCompliant(false)]
			public unsafe static void GetHistogramParameterx(All target, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[150]);
				}
			}

			// Token: 0x0600348D RID: 13453 RVA: 0x0008A8E4 File Offset: 0x00088AE4
			[CLSCompliant(false)]
			public unsafe static void GetHistogramParameterx(All target, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[150]);
			}

			// Token: 0x0600348E RID: 13454 RVA: 0x0008A8FC File Offset: 0x00088AFC
			[CLSCompliant(false)]
			public unsafe static void GetLightx(All light, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, ptr, GL.EntryPoints[154]);
				}
			}

			// Token: 0x0600348F RID: 13455 RVA: 0x0008A934 File Offset: 0x00088B34
			[CLSCompliant(false)]
			public unsafe static void GetLightx(All light, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, ptr, GL.EntryPoints[154]);
				}
			}

			// Token: 0x06003490 RID: 13456 RVA: 0x0008A958 File Offset: 0x00088B58
			[CLSCompliant(false)]
			public unsafe static void GetLightx(All light, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, @params, GL.EntryPoints[154]);
			}

			// Token: 0x06003491 RID: 13457 RVA: 0x0008A970 File Offset: 0x00088B70
			[CLSCompliant(false)]
			public unsafe static void GetMapx(All target, All query, [Out] int[] v)
			{
				fixed (int* ptr = ref (v != null && v.Length != 0) ? ref v[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, query, ptr, GL.EntryPoints[157]);
				}
			}

			// Token: 0x06003492 RID: 13458 RVA: 0x0008A9A8 File Offset: 0x00088BA8
			[CLSCompliant(false)]
			public unsafe static void GetMapx(All target, All query, out int v)
			{
				fixed (int* ptr = &v)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, query, ptr, GL.EntryPoints[157]);
				}
			}

			// Token: 0x06003493 RID: 13459 RVA: 0x0008A9CC File Offset: 0x00088BCC
			[CLSCompliant(false)]
			public unsafe static void GetMapx(All target, All query, [Out] int* v)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, query, v, GL.EntryPoints[157]);
			}

			// Token: 0x06003494 RID: 13460 RVA: 0x0008A9E4 File Offset: 0x00088BE4
			public static void GetMaterialx(All face, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), face, pname, param, GL.EntryPoints[159]);
			}

			// Token: 0x06003495 RID: 13461 RVA: 0x0008A9FC File Offset: 0x00088BFC
			[CLSCompliant(false)]
			public unsafe static void GetMaterialx(All face, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, ptr, GL.EntryPoints[161]);
				}
			}

			// Token: 0x06003496 RID: 13462 RVA: 0x0008AA34 File Offset: 0x00088C34
			[CLSCompliant(false)]
			public unsafe static void GetMaterialx(All face, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, @params, GL.EntryPoints[161]);
			}

			// Token: 0x06003497 RID: 13463 RVA: 0x0008AA4C File Offset: 0x00088C4C
			[CLSCompliant(false)]
			public unsafe static void GetRenderbufferParameter(All target, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[166]);
				}
			}

			// Token: 0x06003498 RID: 13464 RVA: 0x0008AA84 File Offset: 0x00088C84
			[CLSCompliant(false)]
			public unsafe static void GetRenderbufferParameter(All target, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[166]);
				}
			}

			// Token: 0x06003499 RID: 13465 RVA: 0x0008AAA8 File Offset: 0x00088CA8
			[CLSCompliant(false)]
			public unsafe static void GetRenderbufferParameter(All target, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[166]);
			}

			// Token: 0x0600349A RID: 13466 RVA: 0x0008AAC0 File Offset: 0x00088CC0
			[CLSCompliant(false)]
			public unsafe static void GetTexEnvx(All target, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x0600349B RID: 13467 RVA: 0x0008AAF8 File Offset: 0x00088CF8
			[CLSCompliant(false)]
			public unsafe static void GetTexEnvx(All target, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[172]);
				}
			}

			// Token: 0x0600349C RID: 13468 RVA: 0x0008AB1C File Offset: 0x00088D1C
			[CLSCompliant(false)]
			public unsafe static void GetTexEnvx(All target, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[172]);
			}

			// Token: 0x0600349D RID: 13469 RVA: 0x0008AB34 File Offset: 0x00088D34
			[CLSCompliant(false)]
			public unsafe static void GetTexGen(All coord, All pname, [Out] float[] @params)
			{
				fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Single*), coord, pname, ptr, GL.EntryPoints[173]);
				}
			}

			// Token: 0x0600349E RID: 13470 RVA: 0x0008AB6C File Offset: 0x00088D6C
			[CLSCompliant(false)]
			public unsafe static void GetTexGen(All coord, All pname, out float @params)
			{
				fixed (float* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Single*), coord, pname, ptr, GL.EntryPoints[173]);
				}
			}

			// Token: 0x0600349F RID: 13471 RVA: 0x0008AB90 File Offset: 0x00088D90
			[CLSCompliant(false)]
			public unsafe static void GetTexGen(All coord, All pname, [Out] float* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), coord, pname, @params, GL.EntryPoints[173]);
			}

			// Token: 0x060034A0 RID: 13472 RVA: 0x0008ABA8 File Offset: 0x00088DA8
			[CLSCompliant(false)]
			public unsafe static void GetTexGen(All coord, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, ptr, GL.EntryPoints[174]);
				}
			}

			// Token: 0x060034A1 RID: 13473 RVA: 0x0008ABE0 File Offset: 0x00088DE0
			[CLSCompliant(false)]
			public unsafe static void GetTexGen(All coord, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, ptr, GL.EntryPoints[174]);
				}
			}

			// Token: 0x060034A2 RID: 13474 RVA: 0x0008AC04 File Offset: 0x00088E04
			[CLSCompliant(false)]
			public unsafe static void GetTexGen(All coord, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, @params, GL.EntryPoints[174]);
			}

			// Token: 0x060034A3 RID: 13475 RVA: 0x0008AC1C File Offset: 0x00088E1C
			[CLSCompliant(false)]
			public unsafe static void GetTexGenx(All coord, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, ptr, GL.EntryPoints[175]);
				}
			}

			// Token: 0x060034A4 RID: 13476 RVA: 0x0008AC54 File Offset: 0x00088E54
			[CLSCompliant(false)]
			public unsafe static void GetTexGenx(All coord, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, ptr, GL.EntryPoints[175]);
				}
			}

			// Token: 0x060034A5 RID: 13477 RVA: 0x0008AC78 File Offset: 0x00088E78
			[CLSCompliant(false)]
			public unsafe static void GetTexGenx(All coord, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, @params, GL.EntryPoints[175]);
			}

			// Token: 0x060034A6 RID: 13478 RVA: 0x0008AC90 File Offset: 0x00088E90
			[CLSCompliant(false)]
			public unsafe static void GetTexLevelParameterx(All target, int level, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, level, pname, ptr, GL.EntryPoints[176]);
				}
			}

			// Token: 0x060034A7 RID: 13479 RVA: 0x0008ACC8 File Offset: 0x00088EC8
			[CLSCompliant(false)]
			public unsafe static void GetTexLevelParameterx(All target, int level, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, level, pname, ptr, GL.EntryPoints[176]);
				}
			}

			// Token: 0x060034A8 RID: 13480 RVA: 0x0008ACEC File Offset: 0x00088EEC
			[CLSCompliant(false)]
			public unsafe static void GetTexLevelParameterx(All target, int level, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32*), target, level, pname, @params, GL.EntryPoints[176]);
			}

			// Token: 0x060034A9 RID: 13481 RVA: 0x0008AD04 File Offset: 0x00088F04
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterx(All target, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[180]);
				}
			}

			// Token: 0x060034AA RID: 13482 RVA: 0x0008AD3C File Offset: 0x00088F3C
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterx(All target, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[180]);
				}
			}

			// Token: 0x060034AB RID: 13483 RVA: 0x0008AD60 File Offset: 0x00088F60
			[CLSCompliant(false)]
			public unsafe static void GetTexParameterx(All target, All pname, [Out] int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[180]);
			}

			// Token: 0x060034AC RID: 13484 RVA: 0x0008AD78 File Offset: 0x00088F78
			public static void Indexx(int component)
			{
				calli(System.Void(System.Int32), component, GL.EntryPoints[182]);
			}

			// Token: 0x060034AD RID: 13485 RVA: 0x0008AD8C File Offset: 0x00088F8C
			[CLSCompliant(false)]
			public unsafe static void Indexx(int* component)
			{
				calli(System.Void(System.Int32*), component, GL.EntryPoints[183]);
			}

			// Token: 0x060034AE RID: 13486 RVA: 0x0008ADA0 File Offset: 0x00088FA0
			[CLSCompliant(false)]
			public static bool IsFramebuffer(int framebuffer)
			{
				return calli(System.Byte(System.UInt32), framebuffer, GL.EntryPoints[187]);
			}

			// Token: 0x060034AF RID: 13487 RVA: 0x0008ADB4 File Offset: 0x00088FB4
			[CLSCompliant(false)]
			public static bool IsFramebuffer(uint framebuffer)
			{
				return calli(System.Byte(System.UInt32), framebuffer, GL.EntryPoints[187]);
			}

			// Token: 0x060034B0 RID: 13488 RVA: 0x0008ADC8 File Offset: 0x00088FC8
			[CLSCompliant(false)]
			public static bool IsRenderbuffer(int renderbuffer)
			{
				return calli(System.Byte(System.UInt32), renderbuffer, GL.EntryPoints[188]);
			}

			// Token: 0x060034B1 RID: 13489 RVA: 0x0008ADDC File Offset: 0x00088FDC
			[CLSCompliant(false)]
			public static bool IsRenderbuffer(uint renderbuffer)
			{
				return calli(System.Byte(System.UInt32), renderbuffer, GL.EntryPoints[188]);
			}

			// Token: 0x060034B2 RID: 13490 RVA: 0x0008ADF0 File Offset: 0x00088FF0
			[CLSCompliant(false)]
			public static bool IsVertexArray(int array)
			{
				return calli(System.Byte(System.UInt32), array, GL.EntryPoints[191]);
			}

			// Token: 0x060034B3 RID: 13491 RVA: 0x0008AE04 File Offset: 0x00089004
			[CLSCompliant(false)]
			public static bool IsVertexArray(uint array)
			{
				return calli(System.Byte(System.UInt32), array, GL.EntryPoints[191]);
			}

			// Token: 0x060034B4 RID: 13492 RVA: 0x0008AE18 File Offset: 0x00089018
			public static void LightModelx(All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[197]);
			}

			// Token: 0x060034B5 RID: 13493 RVA: 0x0008AE2C File Offset: 0x0008902C
			[CLSCompliant(false)]
			public unsafe static void LightModelx(All pname, int[] param)
			{
				fixed (int* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[199]);
				}
			}

			// Token: 0x060034B6 RID: 13494 RVA: 0x0008AE60 File Offset: 0x00089060
			[CLSCompliant(false)]
			public unsafe static void LightModelx(All pname, int* param)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, param, GL.EntryPoints[199]);
			}

			// Token: 0x060034B7 RID: 13495 RVA: 0x0008AE74 File Offset: 0x00089074
			public static void Lightx(All light, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), light, pname, param, GL.EntryPoints[201]);
			}

			// Token: 0x060034B8 RID: 13496 RVA: 0x0008AE8C File Offset: 0x0008908C
			[CLSCompliant(false)]
			public unsafe static void Lightx(All light, All pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, ptr, GL.EntryPoints[203]);
				}
			}

			// Token: 0x060034B9 RID: 13497 RVA: 0x0008AEC4 File Offset: 0x000890C4
			[CLSCompliant(false)]
			public unsafe static void Lightx(All light, All pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), light, pname, @params, GL.EntryPoints[203]);
			}

			// Token: 0x060034BA RID: 13498 RVA: 0x0008AEDC File Offset: 0x000890DC
			public static void LineWidthx(int width)
			{
				calli(System.Void(System.Int32), width, GL.EntryPoints[206]);
			}

			// Token: 0x060034BB RID: 13499 RVA: 0x0008AEF0 File Offset: 0x000890F0
			[CLSCompliant(false)]
			public unsafe static void LoadMatrixx(int[] m)
			{
				fixed (int* ptr = ref (m != null && m.Length != 0) ? ref m[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[210]);
				}
			}

			// Token: 0x060034BC RID: 13500 RVA: 0x0008AF24 File Offset: 0x00089124
			[CLSCompliant(false)]
			public unsafe static void LoadMatrixx(ref int m)
			{
				fixed (int* ptr = &m)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[210]);
				}
			}

			// Token: 0x060034BD RID: 13501 RVA: 0x0008AF48 File Offset: 0x00089148
			[CLSCompliant(false)]
			public unsafe static void LoadMatrixx(int* m)
			{
				calli(System.Void(System.Int32*), m, GL.EntryPoints[210]);
			}

			// Token: 0x060034BE RID: 13502 RVA: 0x0008AF5C File Offset: 0x0008915C
			public static void LoadPaletteFromModelViewMatrix()
			{
				calli(System.Void(), GL.EntryPoints[211]);
			}

			// Token: 0x060034BF RID: 13503 RVA: 0x0008AF70 File Offset: 0x00089170
			[CLSCompliant(false)]
			public unsafe static void LoadTransposeMatrixx(int[] m)
			{
				fixed (int* ptr = ref (m != null && m.Length != 0) ? ref m[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[212]);
				}
			}

			// Token: 0x060034C0 RID: 13504 RVA: 0x0008AFA4 File Offset: 0x000891A4
			[CLSCompliant(false)]
			public unsafe static void LoadTransposeMatrixx(ref int m)
			{
				fixed (int* ptr = &m)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[212]);
				}
			}

			// Token: 0x060034C1 RID: 13505 RVA: 0x0008AFC8 File Offset: 0x000891C8
			[CLSCompliant(false)]
			public unsafe static void LoadTransposeMatrixx(int* m)
			{
				calli(System.Void(System.Int32*), m, GL.EntryPoints[212]);
			}

			// Token: 0x060034C2 RID: 13506 RVA: 0x0008AFDC File Offset: 0x000891DC
			public static void Map1x(All target, int u1, int u2, int stride, int order, int points)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, u1, u2, stride, order, points, GL.EntryPoints[214]);
			}

			// Token: 0x060034C3 RID: 13507 RVA: 0x0008AFF8 File Offset: 0x000891F8
			public static void Map2x(All target, int u1, int u2, int ustride, int uorder, int v1, int v2, int vstride, int vorder, int points)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points, GL.EntryPoints[215]);
			}

			// Token: 0x060034C4 RID: 13508 RVA: 0x0008B028 File Offset: 0x00089228
			public static IntPtr MapBuffer(All target, All access)
			{
				return calli(System.IntPtr(System.Int32,System.Int32), target, access, GL.EntryPoints[216]);
			}

			// Token: 0x060034C5 RID: 13509 RVA: 0x0008B03C File Offset: 0x0008923C
			public static void MapGrid1x(int n, int u1, int u2)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), n, u1, u2, GL.EntryPoints[218]);
			}

			// Token: 0x060034C6 RID: 13510 RVA: 0x0008B054 File Offset: 0x00089254
			public static void MapGrid2x(int n, int u1, int u2, int v1, int v2)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), n, u1, u2, v1, v2, GL.EntryPoints[219]);
			}

			// Token: 0x060034C7 RID: 13511 RVA: 0x0008B06C File Offset: 0x0008926C
			public static void Materialx(All face, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), face, pname, param, GL.EntryPoints[223]);
			}

			// Token: 0x060034C8 RID: 13512 RVA: 0x0008B084 File Offset: 0x00089284
			[CLSCompliant(false)]
			public unsafe static void Materialx(All face, All pname, int[] param)
			{
				fixed (int* ptr = ref (param != null && param.Length != 0) ? ref param[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, ptr, GL.EntryPoints[225]);
				}
			}

			// Token: 0x060034C9 RID: 13513 RVA: 0x0008B0BC File Offset: 0x000892BC
			[CLSCompliant(false)]
			public unsafe static void Materialx(All face, All pname, int* param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), face, pname, param, GL.EntryPoints[225]);
			}

			// Token: 0x060034CA RID: 13514 RVA: 0x0008B0D4 File Offset: 0x000892D4
			public static void MatrixIndexPointer(int size, All type, int stride, IntPtr pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, pointer, GL.EntryPoints[226]);
			}

			// Token: 0x060034CB RID: 13515 RVA: 0x0008B0EC File Offset: 0x000892EC
			[CLSCompliant(false)]
			public unsafe static void MatrixIndexPointer<T3>(int size, All type, int stride, [In] [Out] T3[] pointer) where T3 : struct
			{
				fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[226]);
				}
			}

			// Token: 0x060034CC RID: 13516 RVA: 0x0008B124 File Offset: 0x00089324
			[CLSCompliant(false)]
			public unsafe static void MatrixIndexPointer<T3>(int size, All type, int stride, [In] [Out] T3[,] pointer) where T3 : struct
			{
				fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[226]);
				}
			}

			// Token: 0x060034CD RID: 13517 RVA: 0x0008B160 File Offset: 0x00089360
			[CLSCompliant(false)]
			public unsafe static void MatrixIndexPointer<T3>(int size, All type, int stride, [In] [Out] T3[,,] pointer) where T3 : struct
			{
				fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[226]);
				}
			}

			// Token: 0x060034CE RID: 13518 RVA: 0x0008B19C File Offset: 0x0008939C
			public unsafe static void MatrixIndexPointer<T3>(int size, All type, int stride, [In] [Out] ref T3 pointer) where T3 : struct
			{
				fixed (T3* ptr = &pointer)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[226]);
				}
			}

			// Token: 0x060034CF RID: 13519 RVA: 0x0008B1C0 File Offset: 0x000893C0
			[CLSCompliant(false)]
			public static void MultiTexCoord1(All texture, byte s)
			{
				calli(System.Void(System.Int32,System.SByte), texture, s, GL.EntryPoints[230]);
			}

			// Token: 0x060034D0 RID: 13520 RVA: 0x0008B1D4 File Offset: 0x000893D4
			[CLSCompliant(false)]
			public static void MultiTexCoord1(All texture, sbyte s)
			{
				calli(System.Void(System.Int32,System.SByte), texture, s, GL.EntryPoints[230]);
			}

			// Token: 0x060034D1 RID: 13521 RVA: 0x0008B1E8 File Offset: 0x000893E8
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord1(All texture, byte* coords)
			{
				calli(System.Void(System.Int32,System.SByte*), texture, coords, GL.EntryPoints[231]);
			}

			// Token: 0x060034D2 RID: 13522 RVA: 0x0008B1FC File Offset: 0x000893FC
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord1(All texture, sbyte* coords)
			{
				calli(System.Void(System.Int32,System.SByte*), texture, coords, GL.EntryPoints[231]);
			}

			// Token: 0x060034D3 RID: 13523 RVA: 0x0008B210 File Offset: 0x00089410
			public static void MultiTexCoord1x(All texture, int s)
			{
				calli(System.Void(System.Int32,System.Int32), texture, s, GL.EntryPoints[232]);
			}

			// Token: 0x060034D4 RID: 13524 RVA: 0x0008B224 File Offset: 0x00089424
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord1x(All texture, int* coords)
			{
				calli(System.Void(System.Int32,System.Int32*), texture, coords, GL.EntryPoints[233]);
			}

			// Token: 0x060034D5 RID: 13525 RVA: 0x0008B238 File Offset: 0x00089438
			[CLSCompliant(false)]
			public static void MultiTexCoord2(All texture, byte s, byte t)
			{
				calli(System.Void(System.Int32,System.SByte,System.SByte), texture, s, t, GL.EntryPoints[234]);
			}

			// Token: 0x060034D6 RID: 13526 RVA: 0x0008B250 File Offset: 0x00089450
			[CLSCompliant(false)]
			public static void MultiTexCoord2(All texture, sbyte s, sbyte t)
			{
				calli(System.Void(System.Int32,System.SByte,System.SByte), texture, s, t, GL.EntryPoints[234]);
			}

			// Token: 0x060034D7 RID: 13527 RVA: 0x0008B268 File Offset: 0x00089468
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2(All texture, byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[235]);
				}
			}

			// Token: 0x060034D8 RID: 13528 RVA: 0x0008B29C File Offset: 0x0008949C
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2(All texture, ref byte coords)
			{
				fixed (byte* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[235]);
				}
			}

			// Token: 0x060034D9 RID: 13529 RVA: 0x0008B2C0 File Offset: 0x000894C0
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2(All texture, byte* coords)
			{
				calli(System.Void(System.Int32,System.SByte*), texture, coords, GL.EntryPoints[235]);
			}

			// Token: 0x060034DA RID: 13530 RVA: 0x0008B2D4 File Offset: 0x000894D4
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2(All texture, sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[235]);
				}
			}

			// Token: 0x060034DB RID: 13531 RVA: 0x0008B308 File Offset: 0x00089508
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2(All texture, ref sbyte coords)
			{
				fixed (sbyte* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[235]);
				}
			}

			// Token: 0x060034DC RID: 13532 RVA: 0x0008B32C File Offset: 0x0008952C
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2(All texture, sbyte* coords)
			{
				calli(System.Void(System.Int32,System.SByte*), texture, coords, GL.EntryPoints[235]);
			}

			// Token: 0x060034DD RID: 13533 RVA: 0x0008B340 File Offset: 0x00089540
			public static void MultiTexCoord2x(All texture, int s, int t)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), texture, s, t, GL.EntryPoints[236]);
			}

			// Token: 0x060034DE RID: 13534 RVA: 0x0008B358 File Offset: 0x00089558
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2x(All texture, int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), texture, ptr, GL.EntryPoints[237]);
				}
			}

			// Token: 0x060034DF RID: 13535 RVA: 0x0008B38C File Offset: 0x0008958C
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2x(All texture, ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.Int32*), texture, ptr, GL.EntryPoints[237]);
				}
			}

			// Token: 0x060034E0 RID: 13536 RVA: 0x0008B3B0 File Offset: 0x000895B0
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord2x(All texture, int* coords)
			{
				calli(System.Void(System.Int32,System.Int32*), texture, coords, GL.EntryPoints[237]);
			}

			// Token: 0x060034E1 RID: 13537 RVA: 0x0008B3C4 File Offset: 0x000895C4
			[CLSCompliant(false)]
			public static void MultiTexCoord3(All texture, byte s, byte t, byte r)
			{
				calli(System.Void(System.Int32,System.SByte,System.SByte,System.SByte), texture, s, t, r, GL.EntryPoints[238]);
			}

			// Token: 0x060034E2 RID: 13538 RVA: 0x0008B3DC File Offset: 0x000895DC
			[CLSCompliant(false)]
			public static void MultiTexCoord3(All texture, sbyte s, sbyte t, sbyte r)
			{
				calli(System.Void(System.Int32,System.SByte,System.SByte,System.SByte), texture, s, t, r, GL.EntryPoints[238]);
			}

			// Token: 0x060034E3 RID: 13539 RVA: 0x0008B3F4 File Offset: 0x000895F4
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3(All texture, byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[239]);
				}
			}

			// Token: 0x060034E4 RID: 13540 RVA: 0x0008B428 File Offset: 0x00089628
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3(All texture, ref byte coords)
			{
				fixed (byte* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[239]);
				}
			}

			// Token: 0x060034E5 RID: 13541 RVA: 0x0008B44C File Offset: 0x0008964C
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3(All texture, byte* coords)
			{
				calli(System.Void(System.Int32,System.SByte*), texture, coords, GL.EntryPoints[239]);
			}

			// Token: 0x060034E6 RID: 13542 RVA: 0x0008B460 File Offset: 0x00089660
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3(All texture, sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[239]);
				}
			}

			// Token: 0x060034E7 RID: 13543 RVA: 0x0008B494 File Offset: 0x00089694
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3(All texture, ref sbyte coords)
			{
				fixed (sbyte* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[239]);
				}
			}

			// Token: 0x060034E8 RID: 13544 RVA: 0x0008B4B8 File Offset: 0x000896B8
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3(All texture, sbyte* coords)
			{
				calli(System.Void(System.Int32,System.SByte*), texture, coords, GL.EntryPoints[239]);
			}

			// Token: 0x060034E9 RID: 13545 RVA: 0x0008B4CC File Offset: 0x000896CC
			public static void MultiTexCoord3x(All texture, int s, int t, int r)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), texture, s, t, r, GL.EntryPoints[240]);
			}

			// Token: 0x060034EA RID: 13546 RVA: 0x0008B4E4 File Offset: 0x000896E4
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3x(All texture, int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), texture, ptr, GL.EntryPoints[241]);
				}
			}

			// Token: 0x060034EB RID: 13547 RVA: 0x0008B518 File Offset: 0x00089718
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3x(All texture, ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.Int32*), texture, ptr, GL.EntryPoints[241]);
				}
			}

			// Token: 0x060034EC RID: 13548 RVA: 0x0008B53C File Offset: 0x0008973C
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord3x(All texture, int* coords)
			{
				calli(System.Void(System.Int32,System.Int32*), texture, coords, GL.EntryPoints[241]);
			}

			// Token: 0x060034ED RID: 13549 RVA: 0x0008B550 File Offset: 0x00089750
			[CLSCompliant(false)]
			public static void MultiTexCoord4(All texture, byte s, byte t, byte r, byte q)
			{
				calli(System.Void(System.Int32,System.SByte,System.SByte,System.SByte,System.SByte), texture, s, t, r, q, GL.EntryPoints[242]);
			}

			// Token: 0x060034EE RID: 13550 RVA: 0x0008B568 File Offset: 0x00089768
			[CLSCompliant(false)]
			public static void MultiTexCoord4(All texture, sbyte s, sbyte t, sbyte r, sbyte q)
			{
				calli(System.Void(System.Int32,System.SByte,System.SByte,System.SByte,System.SByte), texture, s, t, r, q, GL.EntryPoints[242]);
			}

			// Token: 0x060034EF RID: 13551 RVA: 0x0008B580 File Offset: 0x00089780
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4(All texture, byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[243]);
				}
			}

			// Token: 0x060034F0 RID: 13552 RVA: 0x0008B5B4 File Offset: 0x000897B4
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4(All texture, ref byte coords)
			{
				fixed (byte* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[243]);
				}
			}

			// Token: 0x060034F1 RID: 13553 RVA: 0x0008B5D8 File Offset: 0x000897D8
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4(All texture, byte* coords)
			{
				calli(System.Void(System.Int32,System.SByte*), texture, coords, GL.EntryPoints[243]);
			}

			// Token: 0x060034F2 RID: 13554 RVA: 0x0008B5EC File Offset: 0x000897EC
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4(All texture, sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[243]);
				}
			}

			// Token: 0x060034F3 RID: 13555 RVA: 0x0008B620 File Offset: 0x00089820
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4(All texture, ref sbyte coords)
			{
				fixed (sbyte* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.SByte*), texture, ptr, GL.EntryPoints[243]);
				}
			}

			// Token: 0x060034F4 RID: 13556 RVA: 0x0008B644 File Offset: 0x00089844
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4(All texture, sbyte* coords)
			{
				calli(System.Void(System.Int32,System.SByte*), texture, coords, GL.EntryPoints[243]);
			}

			// Token: 0x060034F5 RID: 13557 RVA: 0x0008B658 File Offset: 0x00089858
			public static void MultiTexCoord4x(All texture, int s, int t, int r, int q)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), texture, s, t, r, q, GL.EntryPoints[246]);
			}

			// Token: 0x060034F6 RID: 13558 RVA: 0x0008B670 File Offset: 0x00089870
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4x(All texture, int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), texture, ptr, GL.EntryPoints[247]);
				}
			}

			// Token: 0x060034F7 RID: 13559 RVA: 0x0008B6A4 File Offset: 0x000898A4
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4x(All texture, ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32,System.Int32*), texture, ptr, GL.EntryPoints[247]);
				}
			}

			// Token: 0x060034F8 RID: 13560 RVA: 0x0008B6C8 File Offset: 0x000898C8
			[CLSCompliant(false)]
			public unsafe static void MultiTexCoord4x(All texture, int* coords)
			{
				calli(System.Void(System.Int32,System.Int32*), texture, coords, GL.EntryPoints[247]);
			}

			// Token: 0x060034F9 RID: 13561 RVA: 0x0008B6DC File Offset: 0x000898DC
			[CLSCompliant(false)]
			public unsafe static void MultMatrixx(int[] m)
			{
				fixed (int* ptr = ref (m != null && m.Length != 0) ? ref m[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[250]);
				}
			}

			// Token: 0x060034FA RID: 13562 RVA: 0x0008B710 File Offset: 0x00089910
			[CLSCompliant(false)]
			public unsafe static void MultMatrixx(ref int m)
			{
				fixed (int* ptr = &m)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[250]);
				}
			}

			// Token: 0x060034FB RID: 13563 RVA: 0x0008B734 File Offset: 0x00089934
			[CLSCompliant(false)]
			public unsafe static void MultMatrixx(int* m)
			{
				calli(System.Void(System.Int32*), m, GL.EntryPoints[250]);
			}

			// Token: 0x060034FC RID: 13564 RVA: 0x0008B748 File Offset: 0x00089948
			[CLSCompliant(false)]
			public unsafe static void MultTransposeMatrixx(int[] m)
			{
				fixed (int* ptr = ref (m != null && m.Length != 0) ? ref m[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[251]);
				}
			}

			// Token: 0x060034FD RID: 13565 RVA: 0x0008B77C File Offset: 0x0008997C
			[CLSCompliant(false)]
			public unsafe static void MultTransposeMatrixx(ref int m)
			{
				fixed (int* ptr = &m)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[251]);
				}
			}

			// Token: 0x060034FE RID: 13566 RVA: 0x0008B7A0 File Offset: 0x000899A0
			[CLSCompliant(false)]
			public unsafe static void MultTransposeMatrixx(int* m)
			{
				calli(System.Void(System.Int32*), m, GL.EntryPoints[251]);
			}

			// Token: 0x060034FF RID: 13567 RVA: 0x0008B7B4 File Offset: 0x000899B4
			public static void Normal3x(int nx, int ny, int nz)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), nx, ny, nz, GL.EntryPoints[254]);
			}

			// Token: 0x06003500 RID: 13568 RVA: 0x0008B7CC File Offset: 0x000899CC
			[CLSCompliant(false)]
			public unsafe static void Normal3x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[255]);
				}
			}

			// Token: 0x06003501 RID: 13569 RVA: 0x0008B800 File Offset: 0x00089A00
			[CLSCompliant(false)]
			public unsafe static void Normal3x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[255]);
				}
			}

			// Token: 0x06003502 RID: 13570 RVA: 0x0008B824 File Offset: 0x00089A24
			[CLSCompliant(false)]
			public unsafe static void Normal3x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[255]);
			}

			// Token: 0x06003503 RID: 13571 RVA: 0x0008B838 File Offset: 0x00089A38
			public static void Ortho(float l, float r, float b, float t, float n, float f)
			{
				calli(System.Void(System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), l, r, b, t, n, f, GL.EntryPoints[258]);
			}

			// Token: 0x06003504 RID: 13572 RVA: 0x0008B854 File Offset: 0x00089A54
			public static void Orthox(int l, int r, int b, int t, int n, int f)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), l, r, b, t, n, f, GL.EntryPoints[260]);
			}

			// Token: 0x06003505 RID: 13573 RVA: 0x0008B870 File Offset: 0x00089A70
			public static void PassThroughx(int token)
			{
				calli(System.Void(System.Int32), token, GL.EntryPoints[261]);
			}

			// Token: 0x06003506 RID: 13574 RVA: 0x0008B884 File Offset: 0x00089A84
			public static void PixelTransferx(All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[265]);
			}

			// Token: 0x06003507 RID: 13575 RVA: 0x0008B898 File Offset: 0x00089A98
			public static void PixelZoomx(int xfactor, int yfactor)
			{
				calli(System.Void(System.Int32,System.Int32), xfactor, yfactor, GL.EntryPoints[266]);
			}

			// Token: 0x06003508 RID: 13576 RVA: 0x0008B8AC File Offset: 0x00089AAC
			public static void PointParameterx(All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32), pname, param, GL.EntryPoints[270]);
			}

			// Token: 0x06003509 RID: 13577 RVA: 0x0008B8C0 File Offset: 0x00089AC0
			[CLSCompliant(false)]
			public unsafe static void PointParameterx(All pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32*), pname, ptr, GL.EntryPoints[272]);
				}
			}

			// Token: 0x0600350A RID: 13578 RVA: 0x0008B8F4 File Offset: 0x00089AF4
			[CLSCompliant(false)]
			public unsafe static void PointParameterx(All pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32*), pname, @params, GL.EntryPoints[272]);
			}

			// Token: 0x0600350B RID: 13579 RVA: 0x0008B908 File Offset: 0x00089B08
			public static void PointSizePointer(All type, int stride, IntPtr pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, pointer, GL.EntryPoints[274]);
			}

			// Token: 0x0600350C RID: 13580 RVA: 0x0008B920 File Offset: 0x00089B20
			[CLSCompliant(false)]
			public unsafe static void PointSizePointer<T2>(All type, int stride, [In] [Out] T2[] pointer) where T2 : struct
			{
				fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[274]);
				}
			}

			// Token: 0x0600350D RID: 13581 RVA: 0x0008B958 File Offset: 0x00089B58
			[CLSCompliant(false)]
			public unsafe static void PointSizePointer<T2>(All type, int stride, [In] [Out] T2[,] pointer) where T2 : struct
			{
				fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[274]);
				}
			}

			// Token: 0x0600350E RID: 13582 RVA: 0x0008B994 File Offset: 0x00089B94
			[CLSCompliant(false)]
			public unsafe static void PointSizePointer<T2>(All type, int stride, [In] [Out] T2[,,] pointer) where T2 : struct
			{
				fixed (T2* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[274]);
				}
			}

			// Token: 0x0600350F RID: 13583 RVA: 0x0008B9D0 File Offset: 0x00089BD0
			public unsafe static void PointSizePointer<T2>(All type, int stride, [In] [Out] ref T2 pointer) where T2 : struct
			{
				fixed (T2* ptr = &pointer)
				{
					calli(System.Void(System.Int32,System.Int32,System.IntPtr), type, stride, ptr, GL.EntryPoints[274]);
				}
			}

			// Token: 0x06003510 RID: 13584 RVA: 0x0008B9F4 File Offset: 0x00089BF4
			public static void PointSizex(int size)
			{
				calli(System.Void(System.Int32), size, GL.EntryPoints[276]);
			}

			// Token: 0x06003511 RID: 13585 RVA: 0x0008BA08 File Offset: 0x00089C08
			public static void PolygonOffsetx(int factor, int units)
			{
				calli(System.Void(System.Int32,System.Int32), factor, units, GL.EntryPoints[279]);
			}

			// Token: 0x06003512 RID: 13586 RVA: 0x0008BA1C File Offset: 0x00089C1C
			[CLSCompliant(false)]
			public unsafe static void PrioritizeTexturesx(int n, int[] textures, int[] priorities)
			{
				fixed (int* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (priorities != null && priorities.Length != 0) ? ref priorities[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.UInt32*,System.Int32*), n, ptr2, ptr3, GL.EntryPoints[281]);
					}
				}
			}

			// Token: 0x06003513 RID: 13587 RVA: 0x0008BA68 File Offset: 0x00089C68
			[CLSCompliant(false)]
			public unsafe static void PrioritizeTexturesx(int n, ref int textures, ref int priorities)
			{
				fixed (int* ptr = &textures)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &priorities)
					{
						calli(System.Void(System.Int32,System.UInt32*,System.Int32*), n, ptr2, ptr3, GL.EntryPoints[281]);
					}
				}
			}

			// Token: 0x06003514 RID: 13588 RVA: 0x0008BA90 File Offset: 0x00089C90
			[CLSCompliant(false)]
			public unsafe static void PrioritizeTexturesx(int n, int* textures, int* priorities)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32*), n, textures, priorities, GL.EntryPoints[281]);
			}

			// Token: 0x06003515 RID: 13589 RVA: 0x0008BAA8 File Offset: 0x00089CA8
			[CLSCompliant(false)]
			public unsafe static void PrioritizeTexturesx(int n, uint[] textures, int[] priorities)
			{
				fixed (uint* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (priorities != null && priorities.Length != 0) ? ref priorities[0] : ref *null)
					{
						calli(System.Void(System.Int32,System.UInt32*,System.Int32*), n, ptr2, ptr3, GL.EntryPoints[281]);
					}
				}
			}

			// Token: 0x06003516 RID: 13590 RVA: 0x0008BAF4 File Offset: 0x00089CF4
			[CLSCompliant(false)]
			public unsafe static void PrioritizeTexturesx(int n, ref uint textures, ref int priorities)
			{
				fixed (uint* ptr = &textures)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &priorities)
					{
						calli(System.Void(System.Int32,System.UInt32*,System.Int32*), n, ptr2, ptr3, GL.EntryPoints[281]);
					}
				}
			}

			// Token: 0x06003517 RID: 13591 RVA: 0x0008BB1C File Offset: 0x00089D1C
			[CLSCompliant(false)]
			public unsafe static void PrioritizeTexturesx(int n, uint* textures, int* priorities)
			{
				calli(System.Void(System.Int32,System.UInt32*,System.Int32*), n, textures, priorities, GL.EntryPoints[281]);
			}

			// Token: 0x06003518 RID: 13592 RVA: 0x0008BB34 File Offset: 0x00089D34
			[CLSCompliant(false)]
			public unsafe static int QueryMatrixx([Out] int[] mantissa, [Out] int[] exponent)
			{
				fixed (int* ptr = ref (mantissa != null && mantissa.Length != 0) ? ref mantissa[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (exponent != null && exponent.Length != 0) ? ref exponent[0] : ref *null)
					{
						return calli(System.Int32(System.Int32*,System.Int32*), ptr2, ptr3, GL.EntryPoints[283]);
					}
				}
			}

			// Token: 0x06003519 RID: 13593 RVA: 0x0008BB80 File Offset: 0x00089D80
			[CLSCompliant(false)]
			public unsafe static int QueryMatrixx(out int mantissa, out int exponent)
			{
				fixed (int* ptr = &mantissa)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &exponent)
					{
						return calli(System.Int32(System.Int32*,System.Int32*), ptr2, ptr3, GL.EntryPoints[283]);
					}
				}
			}

			// Token: 0x0600351A RID: 13594 RVA: 0x0008BBA8 File Offset: 0x00089DA8
			[CLSCompliant(false)]
			public unsafe static int QueryMatrixx([Out] int* mantissa, [Out] int* exponent)
			{
				return calli(System.Int32(System.Int32*,System.Int32*), mantissa, exponent, GL.EntryPoints[283]);
			}

			// Token: 0x0600351B RID: 13595 RVA: 0x0008BBBC File Offset: 0x00089DBC
			public static void RasterPos2x(int x, int y)
			{
				calli(System.Void(System.Int32,System.Int32), x, y, GL.EntryPoints[284]);
			}

			// Token: 0x0600351C RID: 13596 RVA: 0x0008BBD0 File Offset: 0x00089DD0
			[CLSCompliant(false)]
			public unsafe static void RasterPos2x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[285]);
				}
			}

			// Token: 0x0600351D RID: 13597 RVA: 0x0008BC04 File Offset: 0x00089E04
			[CLSCompliant(false)]
			public unsafe static void RasterPos2x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[285]);
				}
			}

			// Token: 0x0600351E RID: 13598 RVA: 0x0008BC28 File Offset: 0x00089E28
			[CLSCompliant(false)]
			public unsafe static void RasterPos2x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[285]);
			}

			// Token: 0x0600351F RID: 13599 RVA: 0x0008BC3C File Offset: 0x00089E3C
			public static void RasterPos3x(int x, int y, int z)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), x, y, z, GL.EntryPoints[286]);
			}

			// Token: 0x06003520 RID: 13600 RVA: 0x0008BC54 File Offset: 0x00089E54
			[CLSCompliant(false)]
			public unsafe static void RasterPos3x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[287]);
				}
			}

			// Token: 0x06003521 RID: 13601 RVA: 0x0008BC88 File Offset: 0x00089E88
			[CLSCompliant(false)]
			public unsafe static void RasterPos3x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[287]);
				}
			}

			// Token: 0x06003522 RID: 13602 RVA: 0x0008BCAC File Offset: 0x00089EAC
			[CLSCompliant(false)]
			public unsafe static void RasterPos3x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[287]);
			}

			// Token: 0x06003523 RID: 13603 RVA: 0x0008BCC0 File Offset: 0x00089EC0
			public static void RasterPos4x(int x, int y, int z, int w)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), x, y, z, w, GL.EntryPoints[288]);
			}

			// Token: 0x06003524 RID: 13604 RVA: 0x0008BCD8 File Offset: 0x00089ED8
			[CLSCompliant(false)]
			public unsafe static void RasterPos4x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[289]);
				}
			}

			// Token: 0x06003525 RID: 13605 RVA: 0x0008BD0C File Offset: 0x00089F0C
			[CLSCompliant(false)]
			public unsafe static void RasterPos4x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[289]);
				}
			}

			// Token: 0x06003526 RID: 13606 RVA: 0x0008BD30 File Offset: 0x00089F30
			[CLSCompliant(false)]
			public unsafe static void RasterPos4x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[289]);
			}

			// Token: 0x06003527 RID: 13607 RVA: 0x0008BD44 File Offset: 0x00089F44
			public static void Rectx(int x1, int y1, int x2, int y2)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), x1, y1, x2, y2, GL.EntryPoints[292]);
			}

			// Token: 0x06003528 RID: 13608 RVA: 0x0008BD5C File Offset: 0x00089F5C
			[CLSCompliant(false)]
			public unsafe static void Rectx(int[] v1, int[] v2)
			{
				fixed (int* ptr = ref (v1 != null && v1.Length != 0) ? ref v1[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (v2 != null && v2.Length != 0) ? ref v2[0] : ref *null)
					{
						calli(System.Void(System.Int32*,System.Int32*), ptr2, ptr3, GL.EntryPoints[293]);
					}
				}
			}

			// Token: 0x06003529 RID: 13609 RVA: 0x0008BDA8 File Offset: 0x00089FA8
			[CLSCompliant(false)]
			public unsafe static void Rectx(ref int v1, ref int v2)
			{
				fixed (int* ptr = &v1)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &v2)
					{
						calli(System.Void(System.Int32*,System.Int32*), ptr2, ptr3, GL.EntryPoints[293]);
					}
				}
			}

			// Token: 0x0600352A RID: 13610 RVA: 0x0008BDD0 File Offset: 0x00089FD0
			[CLSCompliant(false)]
			public unsafe static void Rectx(int* v1, int* v2)
			{
				calli(System.Void(System.Int32*,System.Int32*), v1, v2, GL.EntryPoints[293]);
			}

			// Token: 0x0600352B RID: 13611 RVA: 0x0008BDE4 File Offset: 0x00089FE4
			public static void RenderbufferStorage(All target, All internalformat, int width, int height)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), target, internalformat, width, height, GL.EntryPoints[297]);
			}

			// Token: 0x0600352C RID: 13612 RVA: 0x0008BDFC File Offset: 0x00089FFC
			public static void Rotatex(int angle, int x, int y, int z)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), angle, x, y, z, GL.EntryPoints[301]);
			}

			// Token: 0x0600352D RID: 13613 RVA: 0x0008BE14 File Offset: 0x0008A014
			public static void SampleCoverage(int value, bool invert)
			{
				calli(System.Void(System.Int32,System.Boolean), value, invert, GL.EntryPoints[303]);
			}

			// Token: 0x0600352E RID: 13614 RVA: 0x0008BE28 File Offset: 0x0008A028
			public static void SampleCoveragex(int value, bool invert)
			{
				calli(System.Void(System.Int32,System.Boolean), value, invert, GL.EntryPoints[305]);
			}

			// Token: 0x0600352F RID: 13615 RVA: 0x0008BE3C File Offset: 0x0008A03C
			public static void Scalex(int x, int y, int z)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), x, y, z, GL.EntryPoints[308]);
			}

			// Token: 0x06003530 RID: 13616 RVA: 0x0008BE54 File Offset: 0x0008A054
			[CLSCompliant(false)]
			public static void TexCoord1(byte s)
			{
				calli(System.Void(System.SByte), s, GL.EntryPoints[317]);
			}

			// Token: 0x06003531 RID: 13617 RVA: 0x0008BE68 File Offset: 0x0008A068
			[CLSCompliant(false)]
			public static void TexCoord1(sbyte s)
			{
				calli(System.Void(System.SByte), s, GL.EntryPoints[317]);
			}

			// Token: 0x06003532 RID: 13618 RVA: 0x0008BE7C File Offset: 0x0008A07C
			[CLSCompliant(false)]
			public unsafe static void TexCoord1(byte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[318]);
			}

			// Token: 0x06003533 RID: 13619 RVA: 0x0008BE90 File Offset: 0x0008A090
			[CLSCompliant(false)]
			public unsafe static void TexCoord1(sbyte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[318]);
			}

			// Token: 0x06003534 RID: 13620 RVA: 0x0008BEA4 File Offset: 0x0008A0A4
			public static void TexCoord1x(int s)
			{
				calli(System.Void(System.Int32), s, GL.EntryPoints[319]);
			}

			// Token: 0x06003535 RID: 13621 RVA: 0x0008BEB8 File Offset: 0x0008A0B8
			[CLSCompliant(false)]
			public unsafe static void TexCoord1x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[320]);
			}

			// Token: 0x06003536 RID: 13622 RVA: 0x0008BECC File Offset: 0x0008A0CC
			[CLSCompliant(false)]
			public static void TexCoord2(byte s, byte t)
			{
				calli(System.Void(System.SByte,System.SByte), s, t, GL.EntryPoints[321]);
			}

			// Token: 0x06003537 RID: 13623 RVA: 0x0008BEE0 File Offset: 0x0008A0E0
			[CLSCompliant(false)]
			public static void TexCoord2(sbyte s, sbyte t)
			{
				calli(System.Void(System.SByte,System.SByte), s, t, GL.EntryPoints[321]);
			}

			// Token: 0x06003538 RID: 13624 RVA: 0x0008BEF4 File Offset: 0x0008A0F4
			[CLSCompliant(false)]
			public unsafe static void TexCoord2(byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[322]);
				}
			}

			// Token: 0x06003539 RID: 13625 RVA: 0x0008BF28 File Offset: 0x0008A128
			[CLSCompliant(false)]
			public unsafe static void TexCoord2(ref byte coords)
			{
				fixed (byte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[322]);
				}
			}

			// Token: 0x0600353A RID: 13626 RVA: 0x0008BF4C File Offset: 0x0008A14C
			[CLSCompliant(false)]
			public unsafe static void TexCoord2(byte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[322]);
			}

			// Token: 0x0600353B RID: 13627 RVA: 0x0008BF60 File Offset: 0x0008A160
			[CLSCompliant(false)]
			public unsafe static void TexCoord2(sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[322]);
				}
			}

			// Token: 0x0600353C RID: 13628 RVA: 0x0008BF94 File Offset: 0x0008A194
			[CLSCompliant(false)]
			public unsafe static void TexCoord2(ref sbyte coords)
			{
				fixed (sbyte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[322]);
				}
			}

			// Token: 0x0600353D RID: 13629 RVA: 0x0008BFB8 File Offset: 0x0008A1B8
			[CLSCompliant(false)]
			public unsafe static void TexCoord2(sbyte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[322]);
			}

			// Token: 0x0600353E RID: 13630 RVA: 0x0008BFCC File Offset: 0x0008A1CC
			public static void TexCoord2x(int s, int t)
			{
				calli(System.Void(System.Int32,System.Int32), s, t, GL.EntryPoints[323]);
			}

			// Token: 0x0600353F RID: 13631 RVA: 0x0008BFE0 File Offset: 0x0008A1E0
			[CLSCompliant(false)]
			public unsafe static void TexCoord2x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[324]);
				}
			}

			// Token: 0x06003540 RID: 13632 RVA: 0x0008C014 File Offset: 0x0008A214
			[CLSCompliant(false)]
			public unsafe static void TexCoord2x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[324]);
				}
			}

			// Token: 0x06003541 RID: 13633 RVA: 0x0008C038 File Offset: 0x0008A238
			[CLSCompliant(false)]
			public unsafe static void TexCoord2x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[324]);
			}

			// Token: 0x06003542 RID: 13634 RVA: 0x0008C04C File Offset: 0x0008A24C
			[CLSCompliant(false)]
			public static void TexCoord3(byte s, byte t, byte r)
			{
				calli(System.Void(System.SByte,System.SByte,System.SByte), s, t, r, GL.EntryPoints[325]);
			}

			// Token: 0x06003543 RID: 13635 RVA: 0x0008C064 File Offset: 0x0008A264
			[CLSCompliant(false)]
			public static void TexCoord3(sbyte s, sbyte t, sbyte r)
			{
				calli(System.Void(System.SByte,System.SByte,System.SByte), s, t, r, GL.EntryPoints[325]);
			}

			// Token: 0x06003544 RID: 13636 RVA: 0x0008C07C File Offset: 0x0008A27C
			[CLSCompliant(false)]
			public unsafe static void TexCoord3(byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[326]);
				}
			}

			// Token: 0x06003545 RID: 13637 RVA: 0x0008C0B0 File Offset: 0x0008A2B0
			[CLSCompliant(false)]
			public unsafe static void TexCoord3(ref byte coords)
			{
				fixed (byte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[326]);
				}
			}

			// Token: 0x06003546 RID: 13638 RVA: 0x0008C0D4 File Offset: 0x0008A2D4
			[CLSCompliant(false)]
			public unsafe static void TexCoord3(byte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[326]);
			}

			// Token: 0x06003547 RID: 13639 RVA: 0x0008C0E8 File Offset: 0x0008A2E8
			[CLSCompliant(false)]
			public unsafe static void TexCoord3(sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[326]);
				}
			}

			// Token: 0x06003548 RID: 13640 RVA: 0x0008C11C File Offset: 0x0008A31C
			[CLSCompliant(false)]
			public unsafe static void TexCoord3(ref sbyte coords)
			{
				fixed (sbyte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[326]);
				}
			}

			// Token: 0x06003549 RID: 13641 RVA: 0x0008C140 File Offset: 0x0008A340
			[CLSCompliant(false)]
			public unsafe static void TexCoord3(sbyte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[326]);
			}

			// Token: 0x0600354A RID: 13642 RVA: 0x0008C154 File Offset: 0x0008A354
			public static void TexCoord3x(int s, int t, int r)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), s, t, r, GL.EntryPoints[327]);
			}

			// Token: 0x0600354B RID: 13643 RVA: 0x0008C16C File Offset: 0x0008A36C
			[CLSCompliant(false)]
			public unsafe static void TexCoord3x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x0600354C RID: 13644 RVA: 0x0008C1A0 File Offset: 0x0008A3A0
			[CLSCompliant(false)]
			public unsafe static void TexCoord3x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[328]);
				}
			}

			// Token: 0x0600354D RID: 13645 RVA: 0x0008C1C4 File Offset: 0x0008A3C4
			[CLSCompliant(false)]
			public unsafe static void TexCoord3x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[328]);
			}

			// Token: 0x0600354E RID: 13646 RVA: 0x0008C1D8 File Offset: 0x0008A3D8
			[CLSCompliant(false)]
			public static void TexCoord4(byte s, byte t, byte r, byte q)
			{
				calli(System.Void(System.SByte,System.SByte,System.SByte,System.SByte), s, t, r, q, GL.EntryPoints[329]);
			}

			// Token: 0x0600354F RID: 13647 RVA: 0x0008C1F0 File Offset: 0x0008A3F0
			[CLSCompliant(false)]
			public static void TexCoord4(sbyte s, sbyte t, sbyte r, sbyte q)
			{
				calli(System.Void(System.SByte,System.SByte,System.SByte,System.SByte), s, t, r, q, GL.EntryPoints[329]);
			}

			// Token: 0x06003550 RID: 13648 RVA: 0x0008C208 File Offset: 0x0008A408
			[CLSCompliant(false)]
			public unsafe static void TexCoord4(byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[330]);
				}
			}

			// Token: 0x06003551 RID: 13649 RVA: 0x0008C23C File Offset: 0x0008A43C
			[CLSCompliant(false)]
			public unsafe static void TexCoord4(ref byte coords)
			{
				fixed (byte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[330]);
				}
			}

			// Token: 0x06003552 RID: 13650 RVA: 0x0008C260 File Offset: 0x0008A460
			[CLSCompliant(false)]
			public unsafe static void TexCoord4(byte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[330]);
			}

			// Token: 0x06003553 RID: 13651 RVA: 0x0008C274 File Offset: 0x0008A474
			[CLSCompliant(false)]
			public unsafe static void TexCoord4(sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[330]);
				}
			}

			// Token: 0x06003554 RID: 13652 RVA: 0x0008C2A8 File Offset: 0x0008A4A8
			[CLSCompliant(false)]
			public unsafe static void TexCoord4(ref sbyte coords)
			{
				fixed (sbyte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[330]);
				}
			}

			// Token: 0x06003555 RID: 13653 RVA: 0x0008C2CC File Offset: 0x0008A4CC
			[CLSCompliant(false)]
			public unsafe static void TexCoord4(sbyte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[330]);
			}

			// Token: 0x06003556 RID: 13654 RVA: 0x0008C2E0 File Offset: 0x0008A4E0
			public static void TexCoord4x(int s, int t, int r, int q)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), s, t, r, q, GL.EntryPoints[331]);
			}

			// Token: 0x06003557 RID: 13655 RVA: 0x0008C2F8 File Offset: 0x0008A4F8
			[CLSCompliant(false)]
			public unsafe static void TexCoord4x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[332]);
				}
			}

			// Token: 0x06003558 RID: 13656 RVA: 0x0008C32C File Offset: 0x0008A52C
			[CLSCompliant(false)]
			public unsafe static void TexCoord4x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[332]);
				}
			}

			// Token: 0x06003559 RID: 13657 RVA: 0x0008C350 File Offset: 0x0008A550
			[CLSCompliant(false)]
			public unsafe static void TexCoord4x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[332]);
			}

			// Token: 0x0600355A RID: 13658 RVA: 0x0008C364 File Offset: 0x0008A564
			public static void TexEnvx(All target, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[339]);
			}

			// Token: 0x0600355B RID: 13659 RVA: 0x0008C37C File Offset: 0x0008A57C
			[CLSCompliant(false)]
			public unsafe static void TexEnvx(All target, All pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[341]);
				}
			}

			// Token: 0x0600355C RID: 13660 RVA: 0x0008C3B4 File Offset: 0x0008A5B4
			[CLSCompliant(false)]
			public unsafe static void TexEnvx(All target, All pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[341]);
			}

			// Token: 0x0600355D RID: 13661 RVA: 0x0008C3CC File Offset: 0x0008A5CC
			public static void TexGen(All coord, All pname, float param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single), coord, pname, param, GL.EntryPoints[342]);
			}

			// Token: 0x0600355E RID: 13662 RVA: 0x0008C3E4 File Offset: 0x0008A5E4
			[CLSCompliant(false)]
			public unsafe static void TexGen(All coord, All pname, float[] @params)
			{
				fixed (float* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Single*), coord, pname, ptr, GL.EntryPoints[343]);
				}
			}

			// Token: 0x0600355F RID: 13663 RVA: 0x0008C41C File Offset: 0x0008A61C
			[CLSCompliant(false)]
			public unsafe static void TexGen(All coord, All pname, float* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Single*), coord, pname, @params, GL.EntryPoints[343]);
			}

			// Token: 0x06003560 RID: 13664 RVA: 0x0008C434 File Offset: 0x0008A634
			public static void TexGen(All coord, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), coord, pname, param, GL.EntryPoints[344]);
			}

			// Token: 0x06003561 RID: 13665 RVA: 0x0008C44C File Offset: 0x0008A64C
			[CLSCompliant(false)]
			public unsafe static void TexGen(All coord, All pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, ptr, GL.EntryPoints[345]);
				}
			}

			// Token: 0x06003562 RID: 13666 RVA: 0x0008C484 File Offset: 0x0008A684
			[CLSCompliant(false)]
			public unsafe static void TexGen(All coord, All pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, @params, GL.EntryPoints[345]);
			}

			// Token: 0x06003563 RID: 13667 RVA: 0x0008C49C File Offset: 0x0008A69C
			public static void TexGenx(All coord, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), coord, pname, param, GL.EntryPoints[346]);
			}

			// Token: 0x06003564 RID: 13668 RVA: 0x0008C4B4 File Offset: 0x0008A6B4
			[CLSCompliant(false)]
			public unsafe static void TexGenx(All coord, All pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, ptr, GL.EntryPoints[347]);
				}
			}

			// Token: 0x06003565 RID: 13669 RVA: 0x0008C4EC File Offset: 0x0008A6EC
			[CLSCompliant(false)]
			public unsafe static void TexGenx(All coord, All pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), coord, pname, @params, GL.EntryPoints[347]);
			}

			// Token: 0x06003566 RID: 13670 RVA: 0x0008C504 File Offset: 0x0008A704
			public static void TexParameterx(All target, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[354]);
			}

			// Token: 0x06003567 RID: 13671 RVA: 0x0008C51C File Offset: 0x0008A71C
			[CLSCompliant(false)]
			public unsafe static void TexParameterx(All target, All pname, int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, ptr, GL.EntryPoints[356]);
				}
			}

			// Token: 0x06003568 RID: 13672 RVA: 0x0008C554 File Offset: 0x0008A754
			[CLSCompliant(false)]
			public unsafe static void TexParameterx(All target, All pname, int* @params)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32*), target, pname, @params, GL.EntryPoints[356]);
			}

			// Token: 0x06003569 RID: 13673 RVA: 0x0008C56C File Offset: 0x0008A76C
			public static void Translatex(int x, int y, int z)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), x, y, z, GL.EntryPoints[366]);
			}

			// Token: 0x0600356A RID: 13674 RVA: 0x0008C584 File Offset: 0x0008A784
			public static bool UnmapBuffer(All target)
			{
				return calli(System.Byte(System.Int32), target, GL.EntryPoints[367]);
			}

			// Token: 0x0600356B RID: 13675 RVA: 0x0008C598 File Offset: 0x0008A798
			[CLSCompliant(false)]
			public static void Vertex2(byte x)
			{
				calli(System.Void(System.SByte), x, GL.EntryPoints[368]);
			}

			// Token: 0x0600356C RID: 13676 RVA: 0x0008C5AC File Offset: 0x0008A7AC
			[CLSCompliant(false)]
			public static void Vertex2(sbyte x)
			{
				calli(System.Void(System.SByte), x, GL.EntryPoints[368]);
			}

			// Token: 0x0600356D RID: 13677 RVA: 0x0008C5C0 File Offset: 0x0008A7C0
			[CLSCompliant(false)]
			public unsafe static void Vertex2(byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[369]);
				}
			}

			// Token: 0x0600356E RID: 13678 RVA: 0x0008C5F4 File Offset: 0x0008A7F4
			[CLSCompliant(false)]
			public unsafe static void Vertex2(byte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[369]);
			}

			// Token: 0x0600356F RID: 13679 RVA: 0x0008C608 File Offset: 0x0008A808
			[CLSCompliant(false)]
			public unsafe static void Vertex2(sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[369]);
				}
			}

			// Token: 0x06003570 RID: 13680 RVA: 0x0008C63C File Offset: 0x0008A83C
			[CLSCompliant(false)]
			public unsafe static void Vertex2(sbyte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[369]);
			}

			// Token: 0x06003571 RID: 13681 RVA: 0x0008C650 File Offset: 0x0008A850
			public static void Vertex2x(int x)
			{
				calli(System.Void(System.Int32), x, GL.EntryPoints[370]);
			}

			// Token: 0x06003572 RID: 13682 RVA: 0x0008C664 File Offset: 0x0008A864
			[CLSCompliant(false)]
			public unsafe static void Vertex2x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[371]);
				}
			}

			// Token: 0x06003573 RID: 13683 RVA: 0x0008C698 File Offset: 0x0008A898
			[CLSCompliant(false)]
			public unsafe static void Vertex2x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[371]);
			}

			// Token: 0x06003574 RID: 13684 RVA: 0x0008C6AC File Offset: 0x0008A8AC
			[CLSCompliant(false)]
			public static void Vertex3(byte x, byte y)
			{
				calli(System.Void(System.SByte,System.SByte), x, y, GL.EntryPoints[372]);
			}

			// Token: 0x06003575 RID: 13685 RVA: 0x0008C6C0 File Offset: 0x0008A8C0
			[CLSCompliant(false)]
			public static void Vertex3(sbyte x, sbyte y)
			{
				calli(System.Void(System.SByte,System.SByte), x, y, GL.EntryPoints[372]);
			}

			// Token: 0x06003576 RID: 13686 RVA: 0x0008C6D4 File Offset: 0x0008A8D4
			[CLSCompliant(false)]
			public unsafe static void Vertex3(byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[373]);
				}
			}

			// Token: 0x06003577 RID: 13687 RVA: 0x0008C708 File Offset: 0x0008A908
			[CLSCompliant(false)]
			public unsafe static void Vertex3(ref byte coords)
			{
				fixed (byte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[373]);
				}
			}

			// Token: 0x06003578 RID: 13688 RVA: 0x0008C72C File Offset: 0x0008A92C
			[CLSCompliant(false)]
			public unsafe static void Vertex3(byte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[373]);
			}

			// Token: 0x06003579 RID: 13689 RVA: 0x0008C740 File Offset: 0x0008A940
			[CLSCompliant(false)]
			public unsafe static void Vertex3(sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[373]);
				}
			}

			// Token: 0x0600357A RID: 13690 RVA: 0x0008C774 File Offset: 0x0008A974
			[CLSCompliant(false)]
			public unsafe static void Vertex3(ref sbyte coords)
			{
				fixed (sbyte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[373]);
				}
			}

			// Token: 0x0600357B RID: 13691 RVA: 0x0008C798 File Offset: 0x0008A998
			[CLSCompliant(false)]
			public unsafe static void Vertex3(sbyte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[373]);
			}

			// Token: 0x0600357C RID: 13692 RVA: 0x0008C7AC File Offset: 0x0008A9AC
			public static void Vertex3x(int x, int y)
			{
				calli(System.Void(System.Int32,System.Int32), x, y, GL.EntryPoints[374]);
			}

			// Token: 0x0600357D RID: 13693 RVA: 0x0008C7C0 File Offset: 0x0008A9C0
			[CLSCompliant(false)]
			public unsafe static void Vertex3x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[375]);
				}
			}

			// Token: 0x0600357E RID: 13694 RVA: 0x0008C7F4 File Offset: 0x0008A9F4
			[CLSCompliant(false)]
			public unsafe static void Vertex3x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[375]);
				}
			}

			// Token: 0x0600357F RID: 13695 RVA: 0x0008C818 File Offset: 0x0008AA18
			[CLSCompliant(false)]
			public unsafe static void Vertex3x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[375]);
			}

			// Token: 0x06003580 RID: 13696 RVA: 0x0008C82C File Offset: 0x0008AA2C
			[CLSCompliant(false)]
			public static void Vertex4(byte x, byte y, byte z)
			{
				calli(System.Void(System.SByte,System.SByte,System.SByte), x, y, z, GL.EntryPoints[376]);
			}

			// Token: 0x06003581 RID: 13697 RVA: 0x0008C844 File Offset: 0x0008AA44
			[CLSCompliant(false)]
			public static void Vertex4(sbyte x, sbyte y, sbyte z)
			{
				calli(System.Void(System.SByte,System.SByte,System.SByte), x, y, z, GL.EntryPoints[376]);
			}

			// Token: 0x06003582 RID: 13698 RVA: 0x0008C85C File Offset: 0x0008AA5C
			[CLSCompliant(false)]
			public unsafe static void Vertex4(byte[] coords)
			{
				fixed (byte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[377]);
				}
			}

			// Token: 0x06003583 RID: 13699 RVA: 0x0008C890 File Offset: 0x0008AA90
			[CLSCompliant(false)]
			public unsafe static void Vertex4(ref byte coords)
			{
				fixed (byte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[377]);
				}
			}

			// Token: 0x06003584 RID: 13700 RVA: 0x0008C8B4 File Offset: 0x0008AAB4
			[CLSCompliant(false)]
			public unsafe static void Vertex4(byte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[377]);
			}

			// Token: 0x06003585 RID: 13701 RVA: 0x0008C8C8 File Offset: 0x0008AAC8
			[CLSCompliant(false)]
			public unsafe static void Vertex4(sbyte[] coords)
			{
				fixed (sbyte* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[377]);
				}
			}

			// Token: 0x06003586 RID: 13702 RVA: 0x0008C8FC File Offset: 0x0008AAFC
			[CLSCompliant(false)]
			public unsafe static void Vertex4(ref sbyte coords)
			{
				fixed (sbyte* ptr = &coords)
				{
					calli(System.Void(System.SByte*), ptr, GL.EntryPoints[377]);
				}
			}

			// Token: 0x06003587 RID: 13703 RVA: 0x0008C920 File Offset: 0x0008AB20
			[CLSCompliant(false)]
			public unsafe static void Vertex4(sbyte* coords)
			{
				calli(System.Void(System.SByte*), coords, GL.EntryPoints[377]);
			}

			// Token: 0x06003588 RID: 13704 RVA: 0x0008C934 File Offset: 0x0008AB34
			public static void Vertex4x(int x, int y, int z)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), x, y, z, GL.EntryPoints[378]);
			}

			// Token: 0x06003589 RID: 13705 RVA: 0x0008C94C File Offset: 0x0008AB4C
			[CLSCompliant(false)]
			public unsafe static void Vertex4x(int[] coords)
			{
				fixed (int* ptr = ref (coords != null && coords.Length != 0) ? ref coords[0] : ref *null)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[379]);
				}
			}

			// Token: 0x0600358A RID: 13706 RVA: 0x0008C980 File Offset: 0x0008AB80
			[CLSCompliant(false)]
			public unsafe static void Vertex4x(ref int coords)
			{
				fixed (int* ptr = &coords)
				{
					calli(System.Void(System.Int32*), ptr, GL.EntryPoints[379]);
				}
			}

			// Token: 0x0600358B RID: 13707 RVA: 0x0008C9A4 File Offset: 0x0008ABA4
			[CLSCompliant(false)]
			public unsafe static void Vertex4x(int* coords)
			{
				calli(System.Void(System.Int32*), coords, GL.EntryPoints[379]);
			}

			// Token: 0x0600358C RID: 13708 RVA: 0x0008C9B8 File Offset: 0x0008ABB8
			public static void WeightPointer(int size, All type, int stride, IntPtr pointer)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, pointer, GL.EntryPoints[383]);
			}

			// Token: 0x0600358D RID: 13709 RVA: 0x0008C9D0 File Offset: 0x0008ABD0
			[CLSCompliant(false)]
			public unsafe static void WeightPointer<T3>(int size, All type, int stride, [In] [Out] T3[] pointer) where T3 : struct
			{
				fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[383]);
				}
			}

			// Token: 0x0600358E RID: 13710 RVA: 0x0008CA08 File Offset: 0x0008AC08
			[CLSCompliant(false)]
			public unsafe static void WeightPointer<T3>(int size, All type, int stride, [In] [Out] T3[,] pointer) where T3 : struct
			{
				fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[383]);
				}
			}

			// Token: 0x0600358F RID: 13711 RVA: 0x0008CA44 File Offset: 0x0008AC44
			[CLSCompliant(false)]
			public unsafe static void WeightPointer<T3>(int size, All type, int stride, [In] [Out] T3[,,] pointer) where T3 : struct
			{
				fixed (T3* ptr = ref (pointer != null && pointer.Length != 0) ? ref pointer[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[383]);
				}
			}

			// Token: 0x06003590 RID: 13712 RVA: 0x0008CA80 File Offset: 0x0008AC80
			public unsafe static void WeightPointer<T3>(int size, All type, int stride, [In] [Out] ref T3 pointer) where T3 : struct
			{
				fixed (T3* ptr = &pointer)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.IntPtr), size, type, stride, ptr, GL.EntryPoints[383]);
				}
			}
		}

		// Token: 0x02000502 RID: 1282
		public static class Qcom
		{
			// Token: 0x06003591 RID: 13713 RVA: 0x0008CAA4 File Offset: 0x0008ACA4
			[CLSCompliant(false)]
			public static void DisableDriverControl(int driverControl)
			{
				calli(System.Void(System.UInt32), driverControl, GL.EntryPoints[71]);
			}

			// Token: 0x06003592 RID: 13714 RVA: 0x0008CAB4 File Offset: 0x0008ACB4
			[CLSCompliant(false)]
			public static void DisableDriverControl(uint driverControl)
			{
				calli(System.Void(System.UInt32), driverControl, GL.EntryPoints[71]);
			}

			// Token: 0x06003593 RID: 13715 RVA: 0x0008CAC4 File Offset: 0x0008ACC4
			[CLSCompliant(false)]
			public static void EnableDriverControl(int driverControl)
			{
				calli(System.Void(System.UInt32), driverControl, GL.EntryPoints[87]);
			}

			// Token: 0x06003594 RID: 13716 RVA: 0x0008CAD4 File Offset: 0x0008ACD4
			[CLSCompliant(false)]
			public static void EnableDriverControl(uint driverControl)
			{
				calli(System.Void(System.UInt32), driverControl, GL.EntryPoints[87]);
			}

			// Token: 0x06003595 RID: 13717 RVA: 0x0008CAE4 File Offset: 0x0008ACE4
			[CLSCompliant(false)]
			public static void EndTiling(int preserveMask)
			{
				calli(System.Void(System.UInt32), preserveMask, GL.EntryPoints[88]);
			}

			// Token: 0x06003596 RID: 13718 RVA: 0x0008CAF4 File Offset: 0x0008ACF4
			[CLSCompliant(false)]
			public static void EndTiling(uint preserveMask)
			{
				calli(System.Void(System.UInt32), preserveMask, GL.EntryPoints[88]);
			}

			// Token: 0x06003597 RID: 13719 RVA: 0x0008CB04 File Offset: 0x0008AD04
			public static void ExtGetBufferPointer(All target, [Out] IntPtr @params)
			{
				calli(System.Void(System.Int32,System.IntPtr), target, @params, GL.EntryPoints[93]);
			}

			// Token: 0x06003598 RID: 13720 RVA: 0x0008CB18 File Offset: 0x0008AD18
			[CLSCompliant(false)]
			public unsafe static void ExtGetBufferPointer<T1>(All target, [In] [Out] T1[] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), target, ptr, GL.EntryPoints[93]);
				}
			}

			// Token: 0x06003599 RID: 13721 RVA: 0x0008CB4C File Offset: 0x0008AD4C
			[CLSCompliant(false)]
			public unsafe static void ExtGetBufferPointer<T1>(All target, [In] [Out] T1[,] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), target, ptr, GL.EntryPoints[93]);
				}
			}

			// Token: 0x0600359A RID: 13722 RVA: 0x0008CB84 File Offset: 0x0008AD84
			[CLSCompliant(false)]
			public unsafe static void ExtGetBufferPointer<T1>(All target, [In] [Out] T1[,,] @params) where T1 : struct
			{
				fixed (T1* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.IntPtr), target, ptr, GL.EntryPoints[93]);
				}
			}

			// Token: 0x0600359B RID: 13723 RVA: 0x0008CBBC File Offset: 0x0008ADBC
			public unsafe static void ExtGetBufferPointer<T1>(All target, [In] [Out] ref T1 @params) where T1 : struct
			{
				fixed (T1* ptr = &@params)
				{
					calli(System.Void(System.Int32,System.IntPtr), target, ptr, GL.EntryPoints[93]);
				}
			}

			// Token: 0x0600359C RID: 13724 RVA: 0x0008CBDC File Offset: 0x0008ADDC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers([Out] int[] buffers, int maxBuffers, [Out] int[] numBuffers)
			{
				fixed (int* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numBuffers != null && numBuffers.Length != 0) ? ref numBuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[94]);
					}
				}
			}

			// Token: 0x0600359D RID: 13725 RVA: 0x0008CC24 File Offset: 0x0008AE24
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers([Out] int[] buffers, int maxBuffers, out int numBuffers)
			{
				fixed (int* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numBuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[94]);
					}
				}
			}

			// Token: 0x0600359E RID: 13726 RVA: 0x0008CC5C File Offset: 0x0008AE5C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetBuffers(out int buffers, int maxBuffers, out int numBuffers)
			{
				fixed (int* ptr = &buffers)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numBuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[94]);
					}
				}
			}

			// Token: 0x0600359F RID: 13727 RVA: 0x0008CC80 File Offset: 0x0008AE80
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetBuffers([Out] int* buffers, int maxBuffers, [Out] int* numBuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), buffers, maxBuffers, numBuffers, GL.EntryPoints[94]);
			}

			// Token: 0x060035A0 RID: 13728 RVA: 0x0008CC94 File Offset: 0x0008AE94
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers([Out] uint[] buffers, int maxBuffers, [Out] int[] numBuffers)
			{
				fixed (uint* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numBuffers != null && numBuffers.Length != 0) ? ref numBuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[94]);
					}
				}
			}

			// Token: 0x060035A1 RID: 13729 RVA: 0x0008CCDC File Offset: 0x0008AEDC
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers([Out] uint[] buffers, int maxBuffers, out int numBuffers)
			{
				fixed (uint* ptr = ref (buffers != null && buffers.Length != 0) ? ref buffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numBuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[94]);
					}
				}
			}

			// Token: 0x060035A2 RID: 13730 RVA: 0x0008CD14 File Offset: 0x0008AF14
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetBuffers(out uint buffers, int maxBuffers, out int numBuffers)
			{
				fixed (uint* ptr = &buffers)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numBuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxBuffers, ptr3, GL.EntryPoints[94]);
					}
				}
			}

			// Token: 0x060035A3 RID: 13731 RVA: 0x0008CD38 File Offset: 0x0008AF38
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetBuffers([Out] uint* buffers, int maxBuffers, [Out] int* numBuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), buffers, maxBuffers, numBuffers, GL.EntryPoints[94]);
			}

			// Token: 0x060035A4 RID: 13732 RVA: 0x0008CD4C File Offset: 0x0008AF4C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers([Out] int[] framebuffers, int maxFramebuffers, [Out] int[] numFramebuffers)
			{
				fixed (int* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numFramebuffers != null && numFramebuffers.Length != 0) ? ref numFramebuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[95]);
					}
				}
			}

			// Token: 0x060035A5 RID: 13733 RVA: 0x0008CD94 File Offset: 0x0008AF94
			[CLSCompliant(false)]
			public unsafe static void ExtGetFramebuffers([Out] int[] framebuffers, int maxFramebuffers, out int numFramebuffers)
			{
				fixed (int* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numFramebuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[95]);
					}
				}
			}

			// Token: 0x060035A6 RID: 13734 RVA: 0x0008CDCC File Offset: 0x0008AFCC
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetFramebuffers(out int framebuffers, int maxFramebuffers, out int numFramebuffers)
			{
				fixed (int* ptr = &framebuffers)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numFramebuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[95]);
					}
				}
			}

			// Token: 0x060035A7 RID: 13735 RVA: 0x0008CDF0 File Offset: 0x0008AFF0
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers([Out] int* framebuffers, int maxFramebuffers, [Out] int* numFramebuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), framebuffers, maxFramebuffers, numFramebuffers, GL.EntryPoints[95]);
			}

			// Token: 0x060035A8 RID: 13736 RVA: 0x0008CE04 File Offset: 0x0008B004
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers([Out] uint[] framebuffers, int maxFramebuffers, [Out] int[] numFramebuffers)
			{
				fixed (uint* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numFramebuffers != null && numFramebuffers.Length != 0) ? ref numFramebuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[95]);
					}
				}
			}

			// Token: 0x060035A9 RID: 13737 RVA: 0x0008CE4C File Offset: 0x0008B04C
			[CLSCompliant(false)]
			public unsafe static void ExtGetFramebuffers([Out] uint[] framebuffers, int maxFramebuffers, out int numFramebuffers)
			{
				fixed (uint* ptr = ref (framebuffers != null && framebuffers.Length != 0) ? ref framebuffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numFramebuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[95]);
					}
				}
			}

			// Token: 0x060035AA RID: 13738 RVA: 0x0008CE84 File Offset: 0x0008B084
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers(out uint framebuffers, int maxFramebuffers, out int numFramebuffers)
			{
				fixed (uint* ptr = &framebuffers)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numFramebuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxFramebuffers, ptr3, GL.EntryPoints[95]);
					}
				}
			}

			// Token: 0x060035AB RID: 13739 RVA: 0x0008CEA8 File Offset: 0x0008B0A8
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetFramebuffers([Out] uint* framebuffers, int maxFramebuffers, [Out] int* numFramebuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), framebuffers, maxFramebuffers, numFramebuffers, GL.EntryPoints[95]);
			}

			// Token: 0x060035AC RID: 13740 RVA: 0x0008CEBC File Offset: 0x0008B0BC
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(int program, All shadertype, [Out] StringBuilder source, [Out] int[] length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr2, ptr, GL.EntryPoints[96]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x060035AD RID: 13741 RVA: 0x0008CF08 File Offset: 0x0008B108
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(int program, All shadertype, [Out] StringBuilder source, out int length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = &length)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr2, ptr, GL.EntryPoints[96]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x060035AE RID: 13742 RVA: 0x0008CF44 File Offset: 0x0008B144
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(int program, All shadertype, [Out] StringBuilder source, [Out] int* length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr, length, GL.EntryPoints[96]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x060035AF RID: 13743 RVA: 0x0008CF7C File Offset: 0x0008B17C
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(uint program, All shadertype, [Out] StringBuilder source, [Out] int[] length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr2, ptr, GL.EntryPoints[96]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x060035B0 RID: 13744 RVA: 0x0008CFC8 File Offset: 0x0008B1C8
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(uint program, All shadertype, [Out] StringBuilder source, out int length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				IntPtr intPtr2 = intPtr;
				fixed (int* ptr = &length)
				{
					calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr2, ptr, GL.EntryPoints[96]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x060035B1 RID: 13745 RVA: 0x0008D004 File Offset: 0x0008B204
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgramBinarySource(uint program, All shadertype, [Out] StringBuilder source, [Out] int* length)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)source.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.IntPtr,System.Int32*), program, shadertype, intPtr, length, GL.EntryPoints[96]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, source);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x060035B2 RID: 13746 RVA: 0x0008D03C File Offset: 0x0008B23C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetProgram([Out] int[] programs, int maxPrograms, [Out] int[] numPrograms)
			{
				fixed (int* ptr = ref (programs != null && programs.Length != 0) ? ref programs[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numPrograms != null && numPrograms.Length != 0) ? ref numPrograms[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[97]);
					}
				}
			}

			// Token: 0x060035B3 RID: 13747 RVA: 0x0008D084 File Offset: 0x0008B284
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgram([Out] int[] programs, int maxPrograms, out int numPrograms)
			{
				fixed (int* ptr = ref (programs != null && programs.Length != 0) ? ref programs[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numPrograms)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[97]);
					}
				}
			}

			// Token: 0x060035B4 RID: 13748 RVA: 0x0008D0BC File Offset: 0x0008B2BC
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetProgram(out int programs, int maxPrograms, out int numPrograms)
			{
				fixed (int* ptr = &programs)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numPrograms)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[97]);
					}
				}
			}

			// Token: 0x060035B5 RID: 13749 RVA: 0x0008D0E0 File Offset: 0x0008B2E0
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgram([Out] int* programs, int maxPrograms, [Out] int* numPrograms)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), programs, maxPrograms, numPrograms, GL.EntryPoints[97]);
			}

			// Token: 0x060035B6 RID: 13750 RVA: 0x0008D0F4 File Offset: 0x0008B2F4
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetProgram([Out] uint[] programs, int maxPrograms, [Out] int[] numPrograms)
			{
				fixed (uint* ptr = ref (programs != null && programs.Length != 0) ? ref programs[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numPrograms != null && numPrograms.Length != 0) ? ref numPrograms[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[97]);
					}
				}
			}

			// Token: 0x060035B7 RID: 13751 RVA: 0x0008D13C File Offset: 0x0008B33C
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgram([Out] uint[] programs, int maxPrograms, out int numPrograms)
			{
				fixed (uint* ptr = ref (programs != null && programs.Length != 0) ? ref programs[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numPrograms)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[97]);
					}
				}
			}

			// Token: 0x060035B8 RID: 13752 RVA: 0x0008D174 File Offset: 0x0008B374
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetProgram(out uint programs, int maxPrograms, out int numPrograms)
			{
				fixed (uint* ptr = &programs)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numPrograms)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxPrograms, ptr3, GL.EntryPoints[97]);
					}
				}
			}

			// Token: 0x060035B9 RID: 13753 RVA: 0x0008D198 File Offset: 0x0008B398
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetProgram([Out] uint* programs, int maxPrograms, [Out] int* numPrograms)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), programs, maxPrograms, numPrograms, GL.EntryPoints[97]);
			}

			// Token: 0x060035BA RID: 13754 RVA: 0x0008D1AC File Offset: 0x0008B3AC
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers([Out] int[] renderbuffers, int maxRenderbuffers, [Out] int[] numRenderbuffers)
			{
				fixed (int* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numRenderbuffers != null && numRenderbuffers.Length != 0) ? ref numRenderbuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[98]);
					}
				}
			}

			// Token: 0x060035BB RID: 13755 RVA: 0x0008D1F4 File Offset: 0x0008B3F4
			[CLSCompliant(false)]
			public unsafe static void ExtGetRenderbuffers([Out] int[] renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
			{
				fixed (int* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numRenderbuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[98]);
					}
				}
			}

			// Token: 0x060035BC RID: 13756 RVA: 0x0008D22C File Offset: 0x0008B42C
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers(out int renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
			{
				fixed (int* ptr = &renderbuffers)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numRenderbuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[98]);
					}
				}
			}

			// Token: 0x060035BD RID: 13757 RVA: 0x0008D250 File Offset: 0x0008B450
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers([Out] int* renderbuffers, int maxRenderbuffers, [Out] int* numRenderbuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), renderbuffers, maxRenderbuffers, numRenderbuffers, GL.EntryPoints[98]);
			}

			// Token: 0x060035BE RID: 13758 RVA: 0x0008D264 File Offset: 0x0008B464
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers([Out] uint[] renderbuffers, int maxRenderbuffers, [Out] int[] numRenderbuffers)
			{
				fixed (uint* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numRenderbuffers != null && numRenderbuffers.Length != 0) ? ref numRenderbuffers[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[98]);
					}
				}
			}

			// Token: 0x060035BF RID: 13759 RVA: 0x0008D2AC File Offset: 0x0008B4AC
			[CLSCompliant(false)]
			public unsafe static void ExtGetRenderbuffers([Out] uint[] renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
			{
				fixed (uint* ptr = ref (renderbuffers != null && renderbuffers.Length != 0) ? ref renderbuffers[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numRenderbuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[98]);
					}
				}
			}

			// Token: 0x060035C0 RID: 13760 RVA: 0x0008D2E4 File Offset: 0x0008B4E4
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetRenderbuffers(out uint renderbuffers, int maxRenderbuffers, out int numRenderbuffers)
			{
				fixed (uint* ptr = &renderbuffers)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numRenderbuffers)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxRenderbuffers, ptr3, GL.EntryPoints[98]);
					}
				}
			}

			// Token: 0x060035C1 RID: 13761 RVA: 0x0008D308 File Offset: 0x0008B508
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetRenderbuffers([Out] uint* renderbuffers, int maxRenderbuffers, [Out] int* numRenderbuffers)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), renderbuffers, maxRenderbuffers, numRenderbuffers, GL.EntryPoints[98]);
			}

			// Token: 0x060035C2 RID: 13762 RVA: 0x0008D31C File Offset: 0x0008B51C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders([Out] int[] shaders, int maxShaders, [Out] int[] numShaders)
			{
				fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numShaders != null && numShaders.Length != 0) ? ref numShaders[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[99]);
					}
				}
			}

			// Token: 0x060035C3 RID: 13763 RVA: 0x0008D364 File Offset: 0x0008B564
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders([Out] int[] shaders, int maxShaders, out int numShaders)
			{
				fixed (int* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numShaders)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[99]);
					}
				}
			}

			// Token: 0x060035C4 RID: 13764 RVA: 0x0008D39C File Offset: 0x0008B59C
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders(out int shaders, int maxShaders, out int numShaders)
			{
				fixed (int* ptr = &shaders)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numShaders)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[99]);
					}
				}
			}

			// Token: 0x060035C5 RID: 13765 RVA: 0x0008D3C0 File Offset: 0x0008B5C0
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders([Out] int* shaders, int maxShaders, [Out] int* numShaders)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), shaders, maxShaders, numShaders, GL.EntryPoints[99]);
			}

			// Token: 0x060035C6 RID: 13766 RVA: 0x0008D3D4 File Offset: 0x0008B5D4
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders([Out] uint[] shaders, int maxShaders, [Out] int[] numShaders)
			{
				fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numShaders != null && numShaders.Length != 0) ? ref numShaders[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[99]);
					}
				}
			}

			// Token: 0x060035C7 RID: 13767 RVA: 0x0008D41C File Offset: 0x0008B61C
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders([Out] uint[] shaders, int maxShaders, out int numShaders)
			{
				fixed (uint* ptr = ref (shaders != null && shaders.Length != 0) ? ref shaders[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numShaders)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[99]);
					}
				}
			}

			// Token: 0x060035C8 RID: 13768 RVA: 0x0008D454 File Offset: 0x0008B654
			[CLSCompliant(false)]
			[Obsolete("Use out overload instead")]
			public unsafe static void ExtGetShaders(out uint shaders, int maxShaders, out int numShaders)
			{
				fixed (uint* ptr = &shaders)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numShaders)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxShaders, ptr3, GL.EntryPoints[99]);
					}
				}
			}

			// Token: 0x060035C9 RID: 13769 RVA: 0x0008D478 File Offset: 0x0008B678
			[Obsolete("Use out overload instead")]
			[CLSCompliant(false)]
			public unsafe static void ExtGetShaders([Out] uint* shaders, int maxShaders, [Out] int* numShaders)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), shaders, maxShaders, numShaders, GL.EntryPoints[99]);
			}

			// Token: 0x060035CA RID: 13770 RVA: 0x0008D48C File Offset: 0x0008B68C
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(int texture, All face, int level, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, ptr, GL.EntryPoints[100]);
				}
			}

			// Token: 0x060035CB RID: 13771 RVA: 0x0008D4C4 File Offset: 0x0008B6C4
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(int texture, All face, int level, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, ptr, GL.EntryPoints[100]);
				}
			}

			// Token: 0x060035CC RID: 13772 RVA: 0x0008D4E8 File Offset: 0x0008B6E8
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(int texture, All face, int level, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, @params, GL.EntryPoints[100]);
			}

			// Token: 0x060035CD RID: 13773 RVA: 0x0008D500 File Offset: 0x0008B700
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(uint texture, All face, int level, All pname, [Out] int[] @params)
			{
				fixed (int* ptr = ref (@params != null && @params.Length != 0) ? ref @params[0] : ref *null)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, ptr, GL.EntryPoints[100]);
				}
			}

			// Token: 0x060035CE RID: 13774 RVA: 0x0008D538 File Offset: 0x0008B738
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(uint texture, All face, int level, All pname, out int @params)
			{
				fixed (int* ptr = &@params)
				{
					calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, ptr, GL.EntryPoints[100]);
				}
			}

			// Token: 0x060035CF RID: 13775 RVA: 0x0008D55C File Offset: 0x0008B75C
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexLevelParameter(uint texture, All face, int level, All pname, [Out] int* @params)
			{
				calli(System.Void(System.UInt32,System.Int32,System.Int32,System.Int32,System.Int32*), texture, face, level, pname, @params, GL.EntryPoints[100]);
			}

			// Token: 0x060035D0 RID: 13776 RVA: 0x0008D574 File Offset: 0x0008B774
			public static void ExtGetTexSubImage(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [Out] IntPtr texels)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, texels, GL.EntryPoints[101]);
			}

			// Token: 0x060035D1 RID: 13777 RVA: 0x0008D5A0 File Offset: 0x0008B7A0
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexSubImage<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[] texels) where T10 : struct
			{
				fixed (T10* ptr = ref (texels != null && texels.Length != 0) ? ref texels[0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[101]);
				}
			}

			// Token: 0x060035D2 RID: 13778 RVA: 0x0008D5E4 File Offset: 0x0008B7E4
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexSubImage<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[,] texels) where T10 : struct
			{
				fixed (T10* ptr = ref (texels != null && texels.Length != 0) ? ref texels[0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[101]);
				}
			}

			// Token: 0x060035D3 RID: 13779 RVA: 0x0008D62C File Offset: 0x0008B82C
			[CLSCompliant(false)]
			public unsafe static void ExtGetTexSubImage<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] T10[,,] texels) where T10 : struct
			{
				fixed (T10* ptr = ref (texels != null && texels.Length != 0) ? ref texels[0, 0, 0] : ref *null)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[101]);
				}
			}

			// Token: 0x060035D4 RID: 13780 RVA: 0x0008D674 File Offset: 0x0008B874
			public unsafe static void ExtGetTexSubImage<T10>(All target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, All format, All type, [In] [Out] ref T10 texels) where T10 : struct
			{
				fixed (T10* ptr = &texels)
				{
					calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.IntPtr), target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, ptr, GL.EntryPoints[101]);
				}
			}

			// Token: 0x060035D5 RID: 13781 RVA: 0x0008D6A4 File Offset: 0x0008B8A4
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures([Out] int[] textures, int maxTextures, [Out] int[] numTextures)
			{
				fixed (int* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (numTextures != null && numTextures.Length != 0) ? ref numTextures[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxTextures, ptr3, GL.EntryPoints[102]);
					}
				}
			}

			// Token: 0x060035D6 RID: 13782 RVA: 0x0008D6EC File Offset: 0x0008B8EC
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures(out int textures, int maxTextures, out int numTextures)
			{
				fixed (int* ptr = &textures)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &numTextures)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxTextures, ptr3, GL.EntryPoints[102]);
					}
				}
			}

			// Token: 0x060035D7 RID: 13783 RVA: 0x0008D710 File Offset: 0x0008B910
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures([Out] int* textures, int maxTextures, [Out] int* numTextures)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), textures, maxTextures, numTextures, GL.EntryPoints[102]);
			}

			// Token: 0x060035D8 RID: 13784 RVA: 0x0008D724 File Offset: 0x0008B924
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures([Out] uint[] textures, int maxTextures, [Out] int[] numTextures)
			{
				fixed (uint* ptr = ref (textures != null && textures.Length != 0) ? ref textures[0] : ref *null)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = ref (numTextures != null && numTextures.Length != 0) ? ref numTextures[0] : ref *null)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxTextures, ptr3, GL.EntryPoints[102]);
					}
				}
			}

			// Token: 0x060035D9 RID: 13785 RVA: 0x0008D76C File Offset: 0x0008B96C
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures(out uint textures, int maxTextures, out int numTextures)
			{
				fixed (uint* ptr = &textures)
				{
					uint* ptr2 = ptr;
					fixed (int* ptr3 = &numTextures)
					{
						calli(System.Void(System.UInt32*,System.Int32,System.Int32*), ptr2, maxTextures, ptr3, GL.EntryPoints[102]);
					}
				}
			}

			// Token: 0x060035DA RID: 13786 RVA: 0x0008D790 File Offset: 0x0008B990
			[CLSCompliant(false)]
			public unsafe static void ExtGetTextures([Out] uint* textures, int maxTextures, [Out] int* numTextures)
			{
				calli(System.Void(System.UInt32*,System.Int32,System.Int32*), textures, maxTextures, numTextures, GL.EntryPoints[102]);
			}

			// Token: 0x060035DB RID: 13787 RVA: 0x0008D7A4 File Offset: 0x0008B9A4
			[CLSCompliant(false)]
			public static bool ExtIsProgramBinary(int program)
			{
				return calli(System.Byte(System.UInt32), program, GL.EntryPoints[103]);
			}

			// Token: 0x060035DC RID: 13788 RVA: 0x0008D7B4 File Offset: 0x0008B9B4
			[CLSCompliant(false)]
			public static bool ExtIsProgramBinary(uint program)
			{
				return calli(System.Byte(System.UInt32), program, GL.EntryPoints[103]);
			}

			// Token: 0x060035DD RID: 13789 RVA: 0x0008D7C4 File Offset: 0x0008B9C4
			public static void ExtTexObjectStateOverride(All target, All pname, int param)
			{
				calli(System.Void(System.Int32,System.Int32,System.Int32), target, pname, param, GL.EntryPoints[104]);
			}

			// Token: 0x060035DE RID: 13790 RVA: 0x0008D7D8 File Offset: 0x0008B9D8
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl([Out] int[] num, int size, [Out] int[] driverControls)
			{
				fixed (int* ptr = ref (num != null && num.Length != 0) ? ref num[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (driverControls != null && driverControls.Length != 0) ? ref driverControls[0] : ref *null)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, size, ptr3, GL.EntryPoints[141]);
					}
				}
			}

			// Token: 0x060035DF RID: 13791 RVA: 0x0008D824 File Offset: 0x0008BA24
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl([Out] int[] num, int size, [Out] uint[] driverControls)
			{
				fixed (int* ptr = ref (num != null && num.Length != 0) ? ref num[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (uint* ptr3 = ref (driverControls != null && driverControls.Length != 0) ? ref driverControls[0] : ref *null)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, size, ptr3, GL.EntryPoints[141]);
					}
				}
			}

			// Token: 0x060035E0 RID: 13792 RVA: 0x0008D870 File Offset: 0x0008BA70
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl(out int num, int size, out int driverControls)
			{
				fixed (int* ptr = &num)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &driverControls)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, size, ptr3, GL.EntryPoints[141]);
					}
				}
			}

			// Token: 0x060035E1 RID: 13793 RVA: 0x0008D898 File Offset: 0x0008BA98
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl(out int num, int size, out uint driverControls)
			{
				fixed (int* ptr = &num)
				{
					int* ptr2 = ptr;
					fixed (uint* ptr3 = &driverControls)
					{
						calli(System.Void(System.Int32*,System.Int32,System.UInt32*), ptr2, size, ptr3, GL.EntryPoints[141]);
					}
				}
			}

			// Token: 0x060035E2 RID: 13794 RVA: 0x0008D8C0 File Offset: 0x0008BAC0
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl([Out] int* num, int size, [Out] int* driverControls)
			{
				calli(System.Void(System.Int32*,System.Int32,System.UInt32*), num, size, driverControls, GL.EntryPoints[141]);
			}

			// Token: 0x060035E3 RID: 13795 RVA: 0x0008D8D8 File Offset: 0x0008BAD8
			[CLSCompliant(false)]
			public unsafe static void GetDriverControl([Out] int* num, int size, [Out] uint* driverControls)
			{
				calli(System.Void(System.Int32*,System.Int32,System.UInt32*), num, size, driverControls, GL.EntryPoints[141]);
			}

			// Token: 0x060035E4 RID: 13796 RVA: 0x0008D8F0 File Offset: 0x0008BAF0
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(int driverControl, int bufSize, [Out] int[] length, [Out] StringBuilder driverControlString)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, ptr2, intPtr, GL.EntryPoints[142]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x060035E5 RID: 13797 RVA: 0x0008D940 File Offset: 0x0008BB40
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(int driverControl, int bufSize, out int length, [Out] StringBuilder driverControlString)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, ptr2, intPtr, GL.EntryPoints[142]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x060035E6 RID: 13798 RVA: 0x0008D980 File Offset: 0x0008BB80
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(int driverControl, int bufSize, [Out] int* length, [Out] StringBuilder driverControlString)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, length, intPtr, GL.EntryPoints[142]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x060035E7 RID: 13799 RVA: 0x0008D9BC File Offset: 0x0008BBBC
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(uint driverControl, int bufSize, [Out] int[] length, [Out] StringBuilder driverControlString)
			{
				fixed (int* ptr = ref (length != null && length.Length != 0) ? ref length[0] : ref *null)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, ptr2, intPtr, GL.EntryPoints[142]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x060035E8 RID: 13800 RVA: 0x0008DA0C File Offset: 0x0008BC0C
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(uint driverControl, int bufSize, out int length, [Out] StringBuilder driverControlString)
			{
				fixed (int* ptr = &length)
				{
					int* ptr2 = ptr;
					IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
					calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, ptr2, intPtr, GL.EntryPoints[142]);
					BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
					Marshal.FreeHGlobal(intPtr);
				}
			}

			// Token: 0x060035E9 RID: 13801 RVA: 0x0008DA4C File Offset: 0x0008BC4C
			[CLSCompliant(false)]
			public unsafe static void GetDriverControlString(uint driverControl, int bufSize, [Out] int* length, [Out] StringBuilder driverControlString)
			{
				IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)driverControlString.Capacity);
				calli(System.Void(System.UInt32,System.Int32,System.Int32*,System.IntPtr), driverControl, bufSize, length, intPtr, GL.EntryPoints[142]);
				BindingsBase.MarshalPtrToStringBuilder(intPtr, driverControlString);
				Marshal.FreeHGlobal(intPtr);
			}

			// Token: 0x060035EA RID: 13802 RVA: 0x0008DA88 File Offset: 0x0008BC88
			[CLSCompliant(false)]
			public static void StartTiling(int x, int y, int width, int height, int preserveMask)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.UInt32,System.UInt32), x, y, width, height, preserveMask, GL.EntryPoints[312]);
			}

			// Token: 0x060035EB RID: 13803 RVA: 0x0008DAA0 File Offset: 0x0008BCA0
			[CLSCompliant(false)]
			public static void StartTiling(uint x, uint y, uint width, uint height, uint preserveMask)
			{
				calli(System.Void(System.UInt32,System.UInt32,System.UInt32,System.UInt32,System.UInt32), x, y, width, height, preserveMask, GL.EntryPoints[312]);
			}
		}
	}
}
