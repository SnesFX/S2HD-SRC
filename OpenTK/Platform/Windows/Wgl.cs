using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000E5 RID: 229
	internal class Wgl
	{
		// Token: 0x06000956 RID: 2390 RVA: 0x0001F730 File Offset: 0x0001D930
		public static bool SupportsExtension(string name)
		{
			return Wgl.SupportsExtension(Wgl.GetCurrentDC(), name);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0001F740 File Offset: 0x0001D940
		public static bool SupportsExtension(IntPtr dc, string name)
		{
			lock (Wgl.sync)
			{
				if (Wgl.extensions.Count == 0)
				{
					bool flag = Wgl.SupportsFunction("wglGetExtensionsStringARB");
					bool flag2 = Wgl.SupportsFunction("wglGetExtensionsStringEXT");
					string text = flag ? Wgl.Arb.GetExtensionsString(dc) : (flag2 ? Wgl.Ext.GetExtensionsString() : string.Empty);
					if (!string.IsNullOrEmpty(text))
					{
						foreach (string key in text.Split(new char[]
						{
							' '
						}))
						{
							Wgl.extensions.Add(key, true);
						}
					}
				}
			}
			return Wgl.extensions.Count > 0 && Wgl.extensions.ContainsKey(name);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0001F810 File Offset: 0x0001DA10
		public static bool SupportsFunction(string name)
		{
			int num = Array.IndexOf<string>(Wgl.EntryPointNames, name);
			return num >= 0 && Wgl.EntryPoints[num] != IntPtr.Zero;
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000959 RID: 2393 RVA: 0x0001F84C File Offset: 0x0001DA4C
		private object SyncRoot
		{
			get
			{
				return Wgl.sync;
			}
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0001F854 File Offset: 0x0001DA54
		private IntPtr GetAddress(string function_string)
		{
			IntPtr procAddress = Wgl.GetProcAddress(function_string);
			if (!Wgl.IsValid(procAddress))
			{
				procAddress = Functions.GetProcAddress(WinFactory.OpenGLHandle, function_string);
			}
			return procAddress;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0001F880 File Offset: 0x0001DA80
		private static bool IsValid(IntPtr address)
		{
			long num = address.ToInt64();
			return num < -1L || num > 3L;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0001F8A4 File Offset: 0x0001DAA4
		internal void LoadEntryPoints()
		{
			lock (this.SyncRoot)
			{
				if (Wgl.GetCurrentContext() != IntPtr.Zero)
				{
					for (int i = 0; i < Wgl.EntryPointNames.Length; i++)
					{
						Wgl.EntryPoints[i] = this.GetAddress(Wgl.EntryPointNames[i]);
					}
					Wgl.extensions.Clear();
				}
			}
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0001F924 File Offset: 0x0001DB24
		static Wgl()
		{
			Wgl.EntryPointNames = new string[]
			{
				"wglCreateContextAttribsARB",
				"wglGetExtensionsStringARB",
				"wglGetPixelFormatAttribivARB",
				"wglGetPixelFormatAttribfvARB",
				"wglChoosePixelFormatARB",
				"wglMakeContextCurrentARB",
				"wglGetCurrentReadDCARB",
				"wglCreatePbufferARB",
				"wglGetPbufferDCARB",
				"wglReleasePbufferDCARB",
				"wglDestroyPbufferARB",
				"wglQueryPbufferARB",
				"wglBindTexImageARB",
				"wglReleaseTexImageARB",
				"wglSetPbufferAttribARB",
				"wglGetExtensionsStringEXT",
				"wglSwapIntervalEXT",
				"wglGetSwapIntervalEXT"
			};
			Wgl.EntryPoints = new IntPtr[Wgl.EntryPointNames.Length];
		}

		// Token: 0x0600095E RID: 2398
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglCreateContext", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr CreateContext(IntPtr hDc);

		// Token: 0x0600095F RID: 2399
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglDeleteContext", ExactSpelling = true, SetLastError = true)]
		internal static extern bool DeleteContext(IntPtr oldContext);

		// Token: 0x06000960 RID: 2400
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglGetCurrentContext", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr GetCurrentContext();

		// Token: 0x06000961 RID: 2401
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglMakeCurrent", ExactSpelling = true, SetLastError = true)]
		internal static extern bool MakeCurrent(IntPtr hDc, IntPtr newContext);

		// Token: 0x06000962 RID: 2402
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglChoosePixelFormat", ExactSpelling = true, SetLastError = true)]
		internal static extern int ChoosePixelFormat(IntPtr hDc, ref PixelFormatDescriptor pPfd);

		// Token: 0x06000963 RID: 2403
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglDescribePixelFormat", ExactSpelling = true, SetLastError = true)]
		internal static extern int DescribePixelFormat(IntPtr hdc, int ipfd, int cjpfd, ref PixelFormatDescriptor ppfd);

		// Token: 0x06000964 RID: 2404
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglGetCurrentDC", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr GetCurrentDC();

		// Token: 0x06000965 RID: 2405
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglGetProcAddress", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr GetProcAddress(string lpszProc);

		// Token: 0x06000966 RID: 2406
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglGetProcAddress", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr GetProcAddress(IntPtr lpszProc);

		// Token: 0x06000967 RID: 2407
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglGetPixelFormat", ExactSpelling = true, SetLastError = true)]
		internal static extern int GetPixelFormat(IntPtr hdc);

		// Token: 0x06000968 RID: 2408
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglSetPixelFormat", ExactSpelling = true, SetLastError = true)]
		internal static extern bool SetPixelFormat(IntPtr hdc, int ipfd, ref PixelFormatDescriptor ppfd);

		// Token: 0x06000969 RID: 2409
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglSwapBuffers", ExactSpelling = true, SetLastError = true)]
		internal static extern bool SwapBuffers(IntPtr hdc);

		// Token: 0x0600096A RID: 2410
		[SuppressUnmanagedCodeSecurity]
		[DllImport("OPENGL32.DLL", EntryPoint = "wglShareLists", ExactSpelling = true, SetLastError = true)]
		internal static extern bool ShareLists(IntPtr hrcSrvShare, IntPtr hrcSrvSource);

		// Token: 0x0400079F RID: 1951
		internal const string Library = "OPENGL32.DLL";

		// Token: 0x040007A0 RID: 1952
		private static IntPtr[] EntryPoints;

		// Token: 0x040007A1 RID: 1953
		private static string[] EntryPointNames;

		// Token: 0x040007A2 RID: 1954
		private static readonly Dictionary<string, bool> extensions = new Dictionary<string, bool>();

		// Token: 0x040007A3 RID: 1955
		private static readonly object sync = new object();

		// Token: 0x020000E6 RID: 230
		public static class Arb
		{
			// Token: 0x0600096B RID: 2411 RVA: 0x0001FA00 File Offset: 0x0001DC00
			public unsafe static IntPtr CreateContextAttribs(IntPtr hDC, IntPtr hShareContext, int[] attribList)
			{
				fixed (int* ptr = ref (attribList != null && attribList.Length != 0) ? ref attribList[0] : ref *null)
				{
					return calli(System.IntPtr(System.IntPtr,System.IntPtr,System.Int32*), hDC, hShareContext, ptr, Wgl.EntryPoints[0]);
				}
			}

			// Token: 0x0600096C RID: 2412 RVA: 0x0001FA34 File Offset: 0x0001DC34
			public unsafe static string GetExtensionsString(IntPtr hdc)
			{
				return new string((sbyte*)((void*)calli(System.IntPtr(System.IntPtr), hdc, Wgl.EntryPoints[1])));
			}

			// Token: 0x0600096D RID: 2413 RVA: 0x0001FA50 File Offset: 0x0001DC50
			public unsafe static bool GetPixelFormatAttrib(IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, [Out] int[] piValues)
			{
				fixed (int* ptr = ref (piAttributes != null && piAttributes.Length != 0) ? ref piAttributes[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = ref (piValues != null && piValues.Length != 0) ? ref piValues[0] : ref *null)
					{
						return calli(System.Boolean(System.IntPtr,System.Int32,System.Int32,System.UInt32,System.Int32*,System.Int32*), hdc, iPixelFormat, iLayerPlane, nAttributes, ptr2, ptr3, Wgl.EntryPoints[2]);
					}
				}
			}

			// Token: 0x0600096E RID: 2414 RVA: 0x0001FAA0 File Offset: 0x0001DCA0
			public unsafe static bool GetPixelFormatAttrib(IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out int piValues)
			{
				fixed (int* ptr = &piAttributes)
				{
					int* ptr2 = ptr;
					fixed (int* ptr3 = &piValues)
					{
						return calli(System.Boolean(System.IntPtr,System.Int32,System.Int32,System.UInt32,System.Int32*,System.Int32*), hdc, iPixelFormat, iLayerPlane, nAttributes, ptr2, ptr3, Wgl.EntryPoints[2]);
					}
				}
			}

			// Token: 0x0600096F RID: 2415 RVA: 0x0001FAC8 File Offset: 0x0001DCC8
			[CLSCompliant(false)]
			public unsafe static bool GetPixelFormatAttrib(IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, int[] piAttributes, [Out] float[] pfValues)
			{
				fixed (int* ptr = ref (piAttributes != null && piAttributes.Length != 0) ? ref piAttributes[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (float* ptr3 = ref (pfValues != null && pfValues.Length != 0) ? ref pfValues[0] : ref *null)
					{
						return calli(System.Boolean(System.IntPtr,System.Int32,System.Int32,System.UInt32,System.Int32*,System.Single*), hdc, iPixelFormat, iLayerPlane, nAttributes, ptr2, ptr3, Wgl.EntryPoints[3]);
					}
				}
			}

			// Token: 0x06000970 RID: 2416 RVA: 0x0001FB18 File Offset: 0x0001DD18
			public unsafe static bool GetPixelFormatAttrib(IntPtr hdc, int iPixelFormat, int iLayerPlane, int nAttributes, ref int piAttributes, out float pfValues)
			{
				fixed (int* ptr = &piAttributes)
				{
					int* ptr2 = ptr;
					fixed (float* ptr3 = &pfValues)
					{
						return calli(System.Boolean(System.IntPtr,System.Int32,System.Int32,System.UInt32,System.Int32*,System.Single*), hdc, iPixelFormat, iLayerPlane, nAttributes, ptr2, ptr3, Wgl.EntryPoints[3]);
					}
				}
			}

			// Token: 0x06000971 RID: 2417 RVA: 0x0001FB40 File Offset: 0x0001DD40
			public unsafe static bool ChoosePixelFormat(IntPtr hdc, int[] piAttribIList, float[] pfAttribFList, int nMaxFormats, [Out] int[] piFormats, out int nNumFormats)
			{
				fixed (int* ptr = ref (piAttribIList != null && piAttribIList.Length != 0) ? ref piAttribIList[0] : ref *null)
				{
					int* ptr2 = ptr;
					fixed (float* ptr3 = ref (pfAttribFList != null && pfAttribFList.Length != 0) ? ref pfAttribFList[0] : ref *null)
					{
						float* ptr4 = ptr3;
						fixed (int* ptr5 = ref (piFormats != null && piFormats.Length != 0) ? ref piFormats[0] : ref *null)
						{
							int* ptr6 = ptr5;
							fixed (int* ptr7 = &nNumFormats)
							{
								return calli(System.Boolean(System.IntPtr,System.Int32*,System.Single*,System.UInt32,System.Int32*,System.UInt32*), hdc, ptr2, ptr4, nMaxFormats, ptr6, ptr7, Wgl.EntryPoints[4]);
							}
						}
					}
				}
			}

			// Token: 0x06000972 RID: 2418 RVA: 0x0001FBA8 File Offset: 0x0001DDA8
			public unsafe static bool ChoosePixelFormat(IntPtr hdc, ref int piAttribIList, ref float pfAttribFList, int nMaxFormats, out int piFormats, out int nNumFormats)
			{
				fixed (int* ptr = &piAttribIList)
				{
					int* ptr2 = ptr;
					fixed (float* ptr3 = &pfAttribFList)
					{
						float* ptr4 = ptr3;
						fixed (int* ptr5 = &piFormats)
						{
							int* ptr6 = ptr5;
							fixed (int* ptr7 = &nNumFormats)
							{
								return calli(System.Boolean(System.IntPtr,System.Int32*,System.Single*,System.UInt32,System.Int32*,System.UInt32*), hdc, ptr2, ptr4, nMaxFormats, ptr6, ptr7, Wgl.EntryPoints[4]);
							}
						}
					}
				}
			}

			// Token: 0x06000973 RID: 2419 RVA: 0x0001FBD8 File Offset: 0x0001DDD8
			public static bool MakeContextCurrent(IntPtr hDrawDC, IntPtr hReadDC, IntPtr hglrc)
			{
				return calli(System.Boolean(System.IntPtr,System.IntPtr,System.IntPtr), hDrawDC, hReadDC, hglrc, Wgl.EntryPoints[5]);
			}

			// Token: 0x06000974 RID: 2420 RVA: 0x0001FBEC File Offset: 0x0001DDEC
			public static IntPtr GetCurrentReadDC()
			{
				return calli(System.IntPtr(), Wgl.EntryPoints[6]);
			}

			// Token: 0x06000975 RID: 2421 RVA: 0x0001FBFC File Offset: 0x0001DDFC
			public unsafe static IntPtr CreatePbuffer(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, int[] piAttribList)
			{
				fixed (int* ptr = ref (piAttribList != null && piAttribList.Length != 0) ? ref piAttribList[0] : ref *null)
				{
					return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32,System.Int32,System.Int32*), hDC, iPixelFormat, iWidth, iHeight, ptr, Wgl.EntryPoints[7]);
				}
			}

			// Token: 0x06000976 RID: 2422 RVA: 0x0001FC34 File Offset: 0x0001DE34
			public unsafe static IntPtr CreatePbuffer(IntPtr hDC, int iPixelFormat, int iWidth, int iHeight, ref int piAttribList)
			{
				fixed (int* ptr = &piAttribList)
				{
					return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32,System.Int32,System.Int32*), hDC, iPixelFormat, iWidth, iHeight, ptr, Wgl.EntryPoints[7]);
				}
			}

			// Token: 0x06000977 RID: 2423 RVA: 0x0001FC58 File Offset: 0x0001DE58
			public static IntPtr GetPbufferDC(IntPtr hPbuffer)
			{
				return calli(System.IntPtr(System.IntPtr), hPbuffer, Wgl.EntryPoints[8]);
			}

			// Token: 0x06000978 RID: 2424 RVA: 0x0001FC68 File Offset: 0x0001DE68
			public static int ReleasePbufferDC(IntPtr hPbuffer, IntPtr hDC)
			{
				return calli(System.Int32(System.IntPtr,System.IntPtr), hPbuffer, hDC, Wgl.EntryPoints[9]);
			}

			// Token: 0x06000979 RID: 2425 RVA: 0x0001FC7C File Offset: 0x0001DE7C
			public static bool DestroyPbuffer(IntPtr hPbuffer)
			{
				return calli(System.Boolean(System.IntPtr), hPbuffer, Wgl.EntryPoints[10]);
			}

			// Token: 0x0600097A RID: 2426 RVA: 0x0001FC8C File Offset: 0x0001DE8C
			public unsafe static bool QueryPbuffer(IntPtr hPbuffer, int iAttribute, [Out] int[] piValue)
			{
				fixed (int* ptr = ref (piValue != null && piValue.Length != 0) ? ref piValue[0] : ref *null)
				{
					return calli(System.Boolean(System.IntPtr,System.Int32,System.Int32*), hPbuffer, iAttribute, ptr, Wgl.EntryPoints[11]);
				}
			}

			// Token: 0x0600097B RID: 2427 RVA: 0x0001FCC0 File Offset: 0x0001DEC0
			public unsafe static bool QueryPbuffer(IntPtr hPbuffer, int iAttribute, out int piValue)
			{
				fixed (int* ptr = &piValue)
				{
					return calli(System.Boolean(System.IntPtr,System.Int32,System.Int32*), hPbuffer, iAttribute, ptr, Wgl.EntryPoints[11]);
				}
			}

			// Token: 0x0600097C RID: 2428 RVA: 0x0001FCE0 File Offset: 0x0001DEE0
			public static bool BindTexImage(IntPtr hPbuffer, int iBuffer)
			{
				return calli(System.Boolean(System.IntPtr,System.Int32), hPbuffer, iBuffer, Wgl.EntryPoints[12]);
			}

			// Token: 0x0600097D RID: 2429 RVA: 0x0001FCF4 File Offset: 0x0001DEF4
			public static bool ReleaseTexImage(IntPtr hPbuffer, int iBuffer)
			{
				return calli(System.Boolean(System.IntPtr,System.Int32), hPbuffer, iBuffer, Wgl.EntryPoints[13]);
			}

			// Token: 0x0600097E RID: 2430 RVA: 0x0001FD08 File Offset: 0x0001DF08
			public unsafe static bool SetPbufferAttrib(IntPtr hPbuffer, int[] piAttribList)
			{
				fixed (int* ptr = ref (piAttribList != null && piAttribList.Length != 0) ? ref piAttribList[0] : ref *null)
				{
					return calli(System.Boolean(System.IntPtr,System.Int32*), hPbuffer, ptr, Wgl.EntryPoints[14]);
				}
			}

			// Token: 0x0600097F RID: 2431 RVA: 0x0001FD3C File Offset: 0x0001DF3C
			public unsafe static bool SetPbufferAttrib(IntPtr hPbuffer, ref int piAttribList)
			{
				fixed (int* ptr = &piAttribList)
				{
					return calli(System.Boolean(System.IntPtr,System.Int32*), hPbuffer, ptr, Wgl.EntryPoints[14]);
				}
			}
		}

		// Token: 0x020000E7 RID: 231
		public static class Ext
		{
			// Token: 0x06000980 RID: 2432 RVA: 0x0001FD5C File Offset: 0x0001DF5C
			public unsafe static string GetExtensionsString()
			{
				return new string((sbyte*)((void*)calli(System.IntPtr(), Wgl.EntryPoints[15])));
			}

			// Token: 0x06000981 RID: 2433 RVA: 0x0001FD78 File Offset: 0x0001DF78
			public static bool SwapInterval(int interval)
			{
				return calli(System.Boolean(System.Int32), interval, Wgl.EntryPoints[16]);
			}

			// Token: 0x06000982 RID: 2434 RVA: 0x0001FD88 File Offset: 0x0001DF88
			public static int GetSwapInterval()
			{
				return calli(System.Int32(), Wgl.EntryPoints[17]);
			}
		}
	}
}
