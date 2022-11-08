using System;
using System.Runtime.InteropServices;

namespace SDL2
{
	// Token: 0x02000003 RID: 3
	public static class SDL_image
	{
		// Token: 0x060001EA RID: 490 RVA: 0x000029E4 File Offset: 0x00000BE4
		public static void SDL_IMAGE_VERSION(out SDL.SDL_version X)
		{
			X.major = 2;
			X.minor = 0;
			X.patch = 0;
		}

		// Token: 0x060001EB RID: 491
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_LinkedVersion")]
		private static extern IntPtr INTERNAL_IMG_LinkedVersion();

		// Token: 0x060001EC RID: 492 RVA: 0x000029FC File Offset: 0x00000BFC
		public static SDL.SDL_version IMG_LinkedVersion()
		{
			IntPtr ptr = SDL_image.INTERNAL_IMG_LinkedVersion();
			return (SDL.SDL_version)Marshal.PtrToStructure(ptr, typeof(SDL.SDL_version));
		}

		// Token: 0x060001ED RID: 493
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int IMG_Init(SDL_image.IMG_InitFlags flags);

		// Token: 0x060001EE RID: 494
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void IMG_Quit();

		// Token: 0x060001EF RID: 495
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_Load([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string file);

		// Token: 0x060001F0 RID: 496
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_Load_RW(IntPtr src, int freesrc);

		// Token: 0x060001F1 RID: 497
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_LoadTyped_RW(IntPtr src, int freesrc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string type);

		// Token: 0x060001F2 RID: 498
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_LoadTexture(IntPtr renderer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string file);

		// Token: 0x060001F3 RID: 499
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_LoadTexture_RW(IntPtr renderer, IntPtr src, int freesrc);

		// Token: 0x060001F4 RID: 500
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_LoadTextureTyped_RW(IntPtr renderer, IntPtr src, int freesrc, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string type);

		// Token: 0x060001F5 RID: 501
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int IMG_InvertAlpha(int on);

		// Token: 0x060001F6 RID: 502
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr IMG_ReadXPMFromArray([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] [In] string[] xpm);

		// Token: 0x060001F7 RID: 503
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int IMG_SavePNG(IntPtr surface, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string file);

		// Token: 0x060001F8 RID: 504
		[DllImport("SDL2_image.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int IMG_SavePNG_RW(IntPtr surface, IntPtr dst, int freedst);

		// Token: 0x040000CB RID: 203
		private const string nativeLibName = "SDL2_image.dll";

		// Token: 0x040000CC RID: 204
		public const int SDL_IMAGE_MAJOR_VERSION = 2;

		// Token: 0x040000CD RID: 205
		public const int SDL_IMAGE_MINOR_VERSION = 0;

		// Token: 0x040000CE RID: 206
		public const int SDL_IMAGE_PATCHLEVEL = 0;

		// Token: 0x02000070 RID: 112
		[Flags]
		public enum IMG_InitFlags
		{
			// Token: 0x040005B0 RID: 1456
			IMG_INIT_JPG = 1,
			// Token: 0x040005B1 RID: 1457
			IMG_INIT_PNG = 2,
			// Token: 0x040005B2 RID: 1458
			IMG_INIT_TIF = 4,
			// Token: 0x040005B3 RID: 1459
			IMG_INIT_WEBP = 8
		}
	}
}
