using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B33 RID: 2867
	internal static class Cgl
	{
		// Token: 0x06005AA4 RID: 23204
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLGetError")]
		internal static extern Cgl.Error GetError();

		// Token: 0x06005AA5 RID: 23205
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL")]
		private static extern IntPtr CGLErrorString(Cgl.Error code);

		// Token: 0x06005AA6 RID: 23206 RVA: 0x000F658C File Offset: 0x000F478C
		internal static string ErrorString(Cgl.Error code)
		{
			return Marshal.PtrToStringAnsi(Cgl.CGLErrorString(code));
		}

		// Token: 0x06005AA7 RID: 23207
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLChoosePixelFormat")]
		internal static extern Cgl.Error ChoosePixelFormat(int[] attribs, ref IntPtr format, ref int numPixelFormats);

		// Token: 0x06005AA8 RID: 23208
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLDescribePixelFormat")]
		internal static extern Cgl.Error DescribePixelFormat(IntPtr pix, int pix_num, Cgl.PixelFormatInt attrib, out int value);

		// Token: 0x06005AA9 RID: 23209
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLDescribePixelFormat")]
		internal static extern Cgl.Error DescribePixelFormat(IntPtr pix, int pix_num, Cgl.PixelFormatBool attrib, out bool value);

		// Token: 0x06005AAA RID: 23210
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLGetPixelFormat")]
		internal static extern IntPtr GetPixelFormat(IntPtr context);

		// Token: 0x06005AAB RID: 23211
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLCreateContext")]
		internal static extern Cgl.Error CreateContext(IntPtr format, IntPtr share, ref IntPtr context);

		// Token: 0x06005AAC RID: 23212
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLDestroyPixelFormat")]
		internal static extern Cgl.Error DestroyPixelFormat(IntPtr format);

		// Token: 0x06005AAD RID: 23213
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLGetCurrentContext")]
		internal static extern IntPtr GetCurrentContext();

		// Token: 0x06005AAE RID: 23214
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLSetCurrentContext")]
		internal static extern Cgl.Error SetCurrentContext(IntPtr context);

		// Token: 0x06005AAF RID: 23215
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLDestroyContext")]
		internal static extern Cgl.Error DestroyContext(IntPtr context);

		// Token: 0x06005AB0 RID: 23216
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLSetParameter")]
		internal static extern Cgl.Error SetParameter(IntPtr context, int parameter, ref int value);

		// Token: 0x06005AB1 RID: 23217
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLFlushDrawable")]
		internal static extern Cgl.Error FlushDrawable(IntPtr context);

		// Token: 0x06005AB2 RID: 23218
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLSetSurface")]
		internal static extern Cgl.Error SetSurface(IntPtr context, int conId, int winId, int surfId);

		// Token: 0x06005AB3 RID: 23219
		[DllImport("/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL", EntryPoint = "CGLUpdateContext")]
		internal static extern Cgl.Error UpdateContext(IntPtr context);

		// Token: 0x06005AB4 RID: 23220
		[DllImport("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon", EntryPoint = "CGSMainConnectionID")]
		internal static extern int MainConnectionID();

		// Token: 0x06005AB5 RID: 23221
		[DllImport("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon", EntryPoint = "CGSGetSurfaceCount")]
		internal static extern Cgl.Error GetSurfaceCount(int conId, int winId, ref int count);

		// Token: 0x06005AB6 RID: 23222
		[DllImport("/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon", EntryPoint = "CGSGetSurfaceList")]
		internal static extern Cgl.Error GetSurfaceList(int conId, int winId, int count, ref int ids, ref int filled);

		// Token: 0x0400B66B RID: 46699
		private const string cgl = "/System/Library/Frameworks/OpenGL.framework/Versions/Current/OpenGL";

		// Token: 0x0400B66C RID: 46700
		private const string cgs = "/System/Library/Frameworks/Carbon.framework/Versions/Current/Carbon";

		// Token: 0x02000B34 RID: 2868
		internal enum PixelFormatBool
		{
			// Token: 0x0400B66E RID: 46702
			None,
			// Token: 0x0400B66F RID: 46703
			AllRenderers,
			// Token: 0x0400B670 RID: 46704
			Doublebuffer = 5,
			// Token: 0x0400B671 RID: 46705
			Stereo,
			// Token: 0x0400B672 RID: 46706
			AuxBuffers,
			// Token: 0x0400B673 RID: 46707
			MinimumPolicy = 51,
			// Token: 0x0400B674 RID: 46708
			MaximumPolicy,
			// Token: 0x0400B675 RID: 46709
			Offscreen,
			// Token: 0x0400B676 RID: 46710
			AuxDepthStencil = 57,
			// Token: 0x0400B677 RID: 46711
			ColorFloat,
			// Token: 0x0400B678 RID: 46712
			Multisample,
			// Token: 0x0400B679 RID: 46713
			Supersample,
			// Token: 0x0400B67A RID: 46714
			SampleALpha,
			// Token: 0x0400B67B RID: 46715
			SingleRenderer = 71,
			// Token: 0x0400B67C RID: 46716
			NoRecovery,
			// Token: 0x0400B67D RID: 46717
			Accelerated,
			// Token: 0x0400B67E RID: 46718
			ClosestPolicy,
			// Token: 0x0400B67F RID: 46719
			BackingStore = 76,
			// Token: 0x0400B680 RID: 46720
			Window = 80,
			// Token: 0x0400B681 RID: 46721
			Compliant = 83,
			// Token: 0x0400B682 RID: 46722
			PBuffer = 90,
			// Token: 0x0400B683 RID: 46723
			RemotePBuffer
		}

		// Token: 0x02000B35 RID: 2869
		internal enum PixelFormatInt
		{
			// Token: 0x0400B685 RID: 46725
			ColorSize = 8,
			// Token: 0x0400B686 RID: 46726
			AlphaSize = 11,
			// Token: 0x0400B687 RID: 46727
			DepthSize,
			// Token: 0x0400B688 RID: 46728
			StencilSize,
			// Token: 0x0400B689 RID: 46729
			AccumSize,
			// Token: 0x0400B68A RID: 46730
			SampleBuffers = 55,
			// Token: 0x0400B68B RID: 46731
			Samples,
			// Token: 0x0400B68C RID: 46732
			RendererID = 70,
			// Token: 0x0400B68D RID: 46733
			DisplayMask = 84,
			// Token: 0x0400B68E RID: 46734
			OpenGLProfile = 99,
			// Token: 0x0400B68F RID: 46735
			VScreenCount = 128
		}

		// Token: 0x02000B36 RID: 2870
		internal enum OpenGLProfileVersion
		{
			// Token: 0x0400B691 RID: 46737
			Legacy = 256,
			// Token: 0x0400B692 RID: 46738
			Core3_2 = 12800
		}

		// Token: 0x02000B37 RID: 2871
		internal enum ParameterNames
		{
			// Token: 0x0400B694 RID: 46740
			SwapInterval = 222
		}

		// Token: 0x02000B38 RID: 2872
		internal enum Error
		{
			// Token: 0x0400B696 RID: 46742
			None
		}
	}
}
