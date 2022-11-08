using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics;

namespace OpenTK.Platform.X11
{
	// Token: 0x020001B0 RID: 432
	internal class Glx : GraphicsBindingsBase
	{
		// Token: 0x06000B14 RID: 2836 RVA: 0x000261C4 File Offset: 0x000243C4
		internal Glx()
		{
			this._EntryPointsInstance = Glx.EntryPoints;
			this._EntryPointNamesInstance = Glx.EntryPointNames;
			this._EntryPointNameOffsetsInstance = Glx.EntryPointOffsets;
			int num = 0;
			int i = 0;
			int num2 = 0;
			while (i < Glx.EntryPointNames.Length)
			{
				if (Glx.EntryPointNames[i] == 0)
				{
					Glx.EntryPointOffsets[num2++] = num;
					num = i + 1;
				}
				i++;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x00026228 File Offset: 0x00024428
		protected override object SyncRoot
		{
			get
			{
				return Glx.sync_root;
			}
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00026230 File Offset: 0x00024430
		protected override IntPtr GetAddress(string funcname)
		{
			return Glx.Arb.GetProcAddress(funcname);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x00026238 File Offset: 0x00024438
		internal unsafe override void LoadEntryPoints()
		{
			fixed (byte* entryPointNamesInstance = this._EntryPointNamesInstance)
			{
				for (int i = 0; i < this._EntryPointsInstance.Length; i++)
				{
					this._EntryPointsInstance[i] = Glx.Arb.GetProcAddress(new IntPtr((void*)((byte*)entryPointNamesInstance + this._EntryPointNameOffsetsInstance[i])));
				}
			}
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x000262A0 File Offset: 0x000244A0
		internal static bool SupportsFunction(string name)
		{
			int num = Array.IndexOf(Glx.EntryPointNames, name);
			return num >= 0 && Glx.EntryPoints[num] != IntPtr.Zero;
		}

		// Token: 0x06000B19 RID: 2841
		[DllImport("libGL.so.1", EntryPoint = "glXIsDirect")]
		public static extern bool IsDirect(IntPtr dpy, IntPtr context);

		// Token: 0x06000B1A RID: 2842
		[DllImport("libGL.so.1", EntryPoint = "glXQueryDrawable")]
		public static extern ErrorCode QueryDrawable(IntPtr dpy, IntPtr drawable, GLXAttribute attribute, out int value);

		// Token: 0x06000B1B RID: 2843
		[DllImport("libGL.so.1", EntryPoint = "glXQueryExtension")]
		public static extern bool QueryExtension(IntPtr dpy, out int errorBase, out int eventBase);

		// Token: 0x06000B1C RID: 2844
		[DllImport("libGL.so.1", EntryPoint = "glXQueryExtensionsString")]
		private static extern IntPtr QueryExtensionsStringInternal(IntPtr dpy, int screen);

		// Token: 0x06000B1D RID: 2845 RVA: 0x000262DC File Offset: 0x000244DC
		public static string QueryExtensionsString(IntPtr dpy, int screen)
		{
			return Marshal.PtrToStringAnsi(Glx.QueryExtensionsStringInternal(dpy, screen));
		}

		// Token: 0x06000B1E RID: 2846
		[DllImport("libGL.so.1", EntryPoint = "glXQueryVersion")]
		public static extern bool QueryVersion(IntPtr dpy, out int major, out int minor);

		// Token: 0x06000B1F RID: 2847
		[DllImport("libGL.so.1", EntryPoint = "glXCreateContext")]
		public static extern IntPtr CreateContext(IntPtr dpy, IntPtr vis, IntPtr shareList, bool direct);

		// Token: 0x06000B20 RID: 2848
		[DllImport("libGL.so.1", EntryPoint = "glXCreateContext")]
		public static extern IntPtr CreateContext(IntPtr dpy, ref XVisualInfo vis, IntPtr shareList, bool direct);

		// Token: 0x06000B21 RID: 2849
		[DllImport("libGL.so.1", EntryPoint = "glXDestroyContext")]
		public static extern void DestroyContext(IntPtr dpy, IntPtr context);

		// Token: 0x06000B22 RID: 2850 RVA: 0x000262EC File Offset: 0x000244EC
		public static void DestroyContext(IntPtr dpy, ContextHandle context)
		{
			Glx.DestroyContext(dpy, context.Handle);
		}

		// Token: 0x06000B23 RID: 2851
		[DllImport("libGL.so.1", EntryPoint = "glXGetCurrentContext")]
		public static extern IntPtr GetCurrentContext();

		// Token: 0x06000B24 RID: 2852
		[DllImport("libGL.so.1", EntryPoint = "glXMakeCurrent")]
		public static extern bool MakeCurrent(IntPtr display, IntPtr drawable, IntPtr context);

		// Token: 0x06000B25 RID: 2853 RVA: 0x000262FC File Offset: 0x000244FC
		public static bool MakeCurrent(IntPtr display, IntPtr drawable, ContextHandle context)
		{
			return Glx.MakeCurrent(display, drawable, context.Handle);
		}

		// Token: 0x06000B26 RID: 2854
		[DllImport("libGL.so.1", EntryPoint = "glXSwapBuffers")]
		public static extern void SwapBuffers(IntPtr display, IntPtr drawable);

		// Token: 0x06000B27 RID: 2855
		[DllImport("libGL.so.1", EntryPoint = "glXGetProcAddress")]
		public static extern IntPtr GetProcAddress([MarshalAs(UnmanagedType.LPTStr)] string procName);

		// Token: 0x06000B28 RID: 2856
		[DllImport("libGL.so.1", EntryPoint = "glXGetProcAddress")]
		public static extern IntPtr GetProcAddress(IntPtr procName);

		// Token: 0x06000B29 RID: 2857
		[DllImport("libGL.so.1", EntryPoint = "glXGetConfig")]
		public static extern int GetConfig(IntPtr dpy, ref XVisualInfo vis, GLXAttribute attrib, out int value);

		// Token: 0x06000B2A RID: 2858
		[DllImport("libGL.so.1", EntryPoint = "glXChooseVisual")]
		public static extern IntPtr ChooseVisual(IntPtr dpy, int screen, IntPtr attriblist);

		// Token: 0x06000B2B RID: 2859
		[DllImport("libGL.so.1", EntryPoint = "glXChooseVisual")]
		public static extern IntPtr ChooseVisual(IntPtr dpy, int screen, ref int attriblist);

		// Token: 0x06000B2C RID: 2860 RVA: 0x0002630C File Offset: 0x0002450C
		public unsafe static IntPtr ChooseVisual(IntPtr dpy, int screen, int[] attriblist)
		{
			fixed (int* ptr = attriblist)
			{
				return Glx.ChooseVisual(dpy, screen, (IntPtr)((void*)ptr));
			}
		}

		// Token: 0x06000B2D RID: 2861
		[DllImport("libGL.so.1", EntryPoint = "glXChooseFBConfig")]
		public unsafe static extern IntPtr* ChooseFBConfig(IntPtr dpy, int screen, int[] attriblist, out int fbount);

		// Token: 0x06000B2E RID: 2862
		[DllImport("libGL.so.1", EntryPoint = "glXGetVisualFromFBConfig")]
		public static extern IntPtr GetVisualFromFBConfig(IntPtr dpy, IntPtr fbconfig);

		// Token: 0x04001202 RID: 4610
		private const string Library = "libGL.so.1";

		// Token: 0x04001203 RID: 4611
		private static readonly object sync_root = new object();

		// Token: 0x04001204 RID: 4612
		private static readonly byte[] EntryPointNames = new byte[]
		{
			103,
			108,
			88,
			67,
			114,
			101,
			97,
			116,
			101,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			65,
			116,
			116,
			114,
			105,
			98,
			115,
			65,
			82,
			66,
			0,
			103,
			108,
			88,
			83,
			119,
			97,
			112,
			73,
			110,
			116,
			101,
			114,
			118,
			97,
			108,
			69,
			88,
			84,
			0,
			103,
			108,
			88,
			83,
			119,
			97,
			112,
			73,
			110,
			116,
			101,
			114,
			118,
			97,
			108,
			77,
			69,
			83,
			65,
			0,
			103,
			108,
			88,
			71,
			101,
			116,
			83,
			119,
			97,
			112,
			73,
			110,
			116,
			101,
			114,
			118,
			97,
			108,
			77,
			69,
			83,
			65,
			0,
			103,
			108,
			88,
			83,
			119,
			97,
			112,
			73,
			110,
			116,
			101,
			114,
			118,
			97,
			108,
			83,
			71,
			73,
			0
		};

		// Token: 0x04001205 RID: 4613
		private static readonly int[] EntryPointOffsets = new int[5];

		// Token: 0x04001206 RID: 4614
		private static IntPtr[] EntryPoints = new IntPtr[5];

		// Token: 0x020001B1 RID: 433
		public class Arb
		{
			// Token: 0x06000B30 RID: 2864 RVA: 0x00026380 File Offset: 0x00024580
			public unsafe static IntPtr CreateContextAttribs(IntPtr display, IntPtr fbconfig, IntPtr share_context, bool direct, int* attribs)
			{
				return calli(System.IntPtr(System.IntPtr,System.IntPtr,System.IntPtr,System.Boolean,System.Int32*), display, fbconfig, share_context, direct, attribs, Glx.EntryPoints[0]);
			}

			// Token: 0x06000B31 RID: 2865 RVA: 0x00026394 File Offset: 0x00024594
			public unsafe static IntPtr CreateContextAttribs(IntPtr display, IntPtr fbconfig, IntPtr share_context, bool direct, int[] attribs)
			{
				fixed (int* ptr = ref (attribs != null && attribs.Length != 0) ? ref attribs[0] : ref *null)
				{
					return calli(System.IntPtr(System.IntPtr,System.IntPtr,System.IntPtr,System.Boolean,System.Int32*), display, fbconfig, share_context, direct, ptr, Glx.EntryPoints[0]);
				}
			}

			// Token: 0x06000B32 RID: 2866
			[DllImport("libGL.so.1", EntryPoint = "glXGetProcAddressARB")]
			public static extern IntPtr GetProcAddress([MarshalAs(UnmanagedType.LPTStr)] string procName);

			// Token: 0x06000B33 RID: 2867
			[DllImport("libGL.so.1", EntryPoint = "glXGetProcAddressARB")]
			public static extern IntPtr GetProcAddress(IntPtr procName);
		}

		// Token: 0x020001B2 RID: 434
		public class Ext
		{
			// Token: 0x06000B35 RID: 2869 RVA: 0x000263D4 File Offset: 0x000245D4
			public static ErrorCode SwapInterval(IntPtr display, IntPtr drawable, int interval)
			{
				return calli(OpenTK.Platform.X11.ErrorCode(System.IntPtr,System.IntPtr,System.Int32), display, drawable, interval, Glx.EntryPoints[1]);
			}
		}

		// Token: 0x020001B3 RID: 435
		public class Mesa
		{
			// Token: 0x06000B37 RID: 2871 RVA: 0x000263F0 File Offset: 0x000245F0
			public static ErrorCode SwapInterval(int interval)
			{
				return calli(OpenTK.Platform.X11.ErrorCode(System.Int32), interval, Glx.EntryPoints[2]);
			}

			// Token: 0x06000B38 RID: 2872 RVA: 0x00026400 File Offset: 0x00024600
			public static int GetSwapInterval()
			{
				return calli(System.Int32(), Glx.EntryPoints[3]);
			}
		}

		// Token: 0x020001B4 RID: 436
		public class Sgi
		{
			// Token: 0x06000B3A RID: 2874 RVA: 0x00026418 File Offset: 0x00024618
			public static ErrorCode SwapInterval(int interval)
			{
				return calli(OpenTK.Platform.X11.ErrorCode(System.Int32), interval, Glx.EntryPoints[4]);
			}
		}
	}
}
