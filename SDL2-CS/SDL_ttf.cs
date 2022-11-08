using System;
using System.Runtime.InteropServices;

namespace SDL2
{
	// Token: 0x02000005 RID: 5
	public static class SDL_ttf
	{
		// Token: 0x06000246 RID: 582 RVA: 0x00002AF0 File Offset: 0x00000CF0
		public static void SDL_TTF_VERSION(out SDL.SDL_version X)
		{
			X.major = 2;
			X.minor = 0;
			X.patch = 12;
		}

		// Token: 0x06000247 RID: 583
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_LinkedVersion")]
		private static extern IntPtr INTERNAL_TTF_LinkedVersion();

		// Token: 0x06000248 RID: 584 RVA: 0x00002B0C File Offset: 0x00000D0C
		public static SDL.SDL_version TTF_LinkedVersion()
		{
			IntPtr ptr = SDL_ttf.INTERNAL_TTF_LinkedVersion();
			return (SDL.SDL_version)Marshal.PtrToStructure(ptr, typeof(SDL.SDL_version));
		}

		// Token: 0x06000249 RID: 585
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_ByteSwappedUNICODE(int swapped);

		// Token: 0x0600024A RID: 586
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_Init();

		// Token: 0x0600024B RID: 587
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_OpenFont([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string file, int ptsize);

		// Token: 0x0600024C RID: 588
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_OpenFontRW(IntPtr src, int freesrc, int ptsize);

		// Token: 0x0600024D RID: 589
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_OpenFontIndex([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string file, int ptsize, long index);

		// Token: 0x0600024E RID: 590
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_OpenFontIndexRW(IntPtr src, int freesrc, int ptsize, long index);

		// Token: 0x0600024F RID: 591
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontStyle(IntPtr font);

		// Token: 0x06000250 RID: 592
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_SetFontStyle(IntPtr font, int style);

		// Token: 0x06000251 RID: 593
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontOutline(IntPtr font);

		// Token: 0x06000252 RID: 594
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_SetFontOutline(IntPtr font, int outline);

		// Token: 0x06000253 RID: 595
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontHinting(IntPtr font);

		// Token: 0x06000254 RID: 596
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_SetFontHinting(IntPtr font, int hinting);

		// Token: 0x06000255 RID: 597
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontHeight(IntPtr font);

		// Token: 0x06000256 RID: 598
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontAscent(IntPtr font);

		// Token: 0x06000257 RID: 599
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontDescent(IntPtr font);

		// Token: 0x06000258 RID: 600
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontLineSkip(IntPtr font);

		// Token: 0x06000259 RID: 601
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GetFontKerning(IntPtr font);

		// Token: 0x0600025A RID: 602
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_SetFontKerning(IntPtr font, int allowed);

		// Token: 0x0600025B RID: 603
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern long TTF_FontFaces(IntPtr font);

		// Token: 0x0600025C RID: 604
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);

		// Token: 0x0600025D RID: 605
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string TTF_FontFaceFamilyName(IntPtr font);

		// Token: 0x0600025E RID: 606
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string TTF_FontFaceStyleName(IntPtr font);

		// Token: 0x0600025F RID: 607
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GlyphIsProvided(IntPtr font, ushort ch);

		// Token: 0x06000260 RID: 608
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_GlyphMetrics(IntPtr font, ushort ch, out int minx, out int maxx, out int miny, out int maxy, out int advance);

		// Token: 0x06000261 RID: 609
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_SizeText(IntPtr font, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string text, out int w, out int h);

		// Token: 0x06000262 RID: 610
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_SizeUTF8(IntPtr font, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string text, out int w, out int h);

		// Token: 0x06000263 RID: 611
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_SizeUNICODE(IntPtr font, [MarshalAs(UnmanagedType.LPWStr)] [In] string text, out int w, out int h);

		// Token: 0x06000264 RID: 612
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Solid(IntPtr font, [MarshalAs(UnmanagedType.LPStr)] [In] string text, SDL.SDL_Color fg);

		// Token: 0x06000265 RID: 613
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUTF8_Solid(IntPtr font, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string text, SDL.SDL_Color fg);

		// Token: 0x06000266 RID: 614
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Solid(IntPtr font, [MarshalAs(UnmanagedType.LPWStr)] [In] string text, SDL.SDL_Color fg);

		// Token: 0x06000267 RID: 615
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph_Solid(IntPtr font, ushort ch, SDL.SDL_Color fg);

		// Token: 0x06000268 RID: 616
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Shaded(IntPtr font, [MarshalAs(UnmanagedType.LPStr)] [In] string text, SDL.SDL_Color fg, SDL.SDL_Color bg);

		// Token: 0x06000269 RID: 617
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUTF8_Shaded(IntPtr font, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string text, SDL.SDL_Color fg, SDL.SDL_Color bg);

		// Token: 0x0600026A RID: 618
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Shaded(IntPtr font, [MarshalAs(UnmanagedType.LPWStr)] [In] string text, SDL.SDL_Color fg, SDL.SDL_Color bg);

		// Token: 0x0600026B RID: 619
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph_Shaded(IntPtr font, ushort ch, SDL.SDL_Color fg, SDL.SDL_Color bg);

		// Token: 0x0600026C RID: 620
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Blended(IntPtr font, [MarshalAs(UnmanagedType.LPStr)] [In] string text, SDL.SDL_Color fg);

		// Token: 0x0600026D RID: 621
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUTF8_Blended(IntPtr font, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string text, SDL.SDL_Color fg);

		// Token: 0x0600026E RID: 622
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Blended(IntPtr font, [MarshalAs(UnmanagedType.LPWStr)] [In] string text, SDL.SDL_Color fg);

		// Token: 0x0600026F RID: 623
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderText_Blended_Wrapped(IntPtr font, [MarshalAs(UnmanagedType.LPStr)] [In] string text, SDL.SDL_Color fg, uint wrapped);

		// Token: 0x06000270 RID: 624
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUTF8_Blended_Wrapped(IntPtr font, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string text, SDL.SDL_Color fg, uint wrapped);

		// Token: 0x06000271 RID: 625
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped(IntPtr font, [MarshalAs(UnmanagedType.LPWStr)] [In] string text, SDL.SDL_Color fg, uint wrapped);

		// Token: 0x06000272 RID: 626
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr TTF_RenderGlyph_Blended(IntPtr font, ushort ch, SDL.SDL_Color fg);

		// Token: 0x06000273 RID: 627
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_CloseFont(IntPtr font);

		// Token: 0x06000274 RID: 628
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void TTF_Quit();

		// Token: 0x06000275 RID: 629
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int TTF_WasInit();

		// Token: 0x06000276 RID: 630
		[DllImport("SDL2_ttf.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetFontKerningSize(IntPtr font, int prev_index, int index);

		// Token: 0x040000D8 RID: 216
		private const string nativeLibName = "SDL2_ttf.dll";

		// Token: 0x040000D9 RID: 217
		public const int SDL_TTF_MAJOR_VERSION = 2;

		// Token: 0x040000DA RID: 218
		public const int SDL_TTF_MINOR_VERSION = 0;

		// Token: 0x040000DB RID: 219
		public const int SDL_TTF_PATCHLEVEL = 12;

		// Token: 0x040000DC RID: 220
		public const int UNICODE_BOM_NATIVE = 65279;

		// Token: 0x040000DD RID: 221
		public const int UNICODE_BOM_SWAPPED = 65534;

		// Token: 0x040000DE RID: 222
		public const int TTF_STYLE_NORMAL = 0;

		// Token: 0x040000DF RID: 223
		public const int TTF_STYLE_BOLD = 1;

		// Token: 0x040000E0 RID: 224
		public const int TTF_STYLE_ITALIC = 2;

		// Token: 0x040000E1 RID: 225
		public const int TTF_STYLE_UNDERLINE = 4;

		// Token: 0x040000E2 RID: 226
		public const int TTF_STYLE_STRIKETHROUGH = 8;

		// Token: 0x040000E3 RID: 227
		public const int TTF_HINTING_NORMAL = 0;

		// Token: 0x040000E4 RID: 228
		public const int TTF_HINTING_LIGHT = 1;

		// Token: 0x040000E5 RID: 229
		public const int TTF_HINTING_MONO = 2;

		// Token: 0x040000E6 RID: 230
		public const int TTF_HINTING_NONE = 3;
	}
}
