using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics;

namespace OpenTK.Platform.Egl
{
	// Token: 0x02000075 RID: 117
	internal static class Egl
	{
		// Token: 0x06000744 RID: 1860
		[DllImport("libEGL.dll", EntryPoint = "eglGetError")]
		public static extern ErrorCode GetError();

		// Token: 0x06000745 RID: 1861
		[DllImport("libEGL.dll", EntryPoint = "eglGetDisplay")]
		public static extern IntPtr GetDisplay(IntPtr display_id);

		// Token: 0x06000746 RID: 1862
		[DllImport("libEGL.dll", EntryPoint = "eglInitialize")]
		public static extern bool Initialize(IntPtr dpy, out int major, out int minor);

		// Token: 0x06000747 RID: 1863
		[DllImport("libEGL.dll", EntryPoint = "eglTerminate")]
		public static extern bool Terminate(IntPtr dpy);

		// Token: 0x06000748 RID: 1864
		[DllImport("libEGL.dll", EntryPoint = "eglQueryString")]
		public static extern IntPtr QueryString(IntPtr dpy, int name);

		// Token: 0x06000749 RID: 1865
		[DllImport("libEGL.dll", EntryPoint = "eglGetConfigs")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetConfigs(IntPtr dpy, IntPtr[] configs, int config_size, out int num_config);

		// Token: 0x0600074A RID: 1866
		[DllImport("libEGL.dll", EntryPoint = "eglChooseConfig")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ChooseConfig(IntPtr dpy, int[] attrib_list, [In] [Out] IntPtr[] configs, int config_size, out int num_config);

		// Token: 0x0600074B RID: 1867
		[DllImport("libEGL.dll", EntryPoint = "eglGetConfigAttrib")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool GetConfigAttrib(IntPtr dpy, IntPtr config, int attribute, out int value);

		// Token: 0x0600074C RID: 1868
		[DllImport("libEGL.dll", EntryPoint = "eglCreateWindowSurface")]
		public static extern IntPtr CreateWindowSurface(IntPtr dpy, IntPtr config, IntPtr win, IntPtr attrib_list);

		// Token: 0x0600074D RID: 1869
		[DllImport("libEGL.dll", EntryPoint = "eglCreatePbufferSurface")]
		public static extern IntPtr CreatePbufferSurface(IntPtr dpy, IntPtr config, int[] attrib_list);

		// Token: 0x0600074E RID: 1870
		[DllImport("libEGL.dll", EntryPoint = "eglCreatePixmapSurface")]
		public static extern IntPtr CreatePixmapSurface(IntPtr dpy, IntPtr config, IntPtr pixmap, int[] attrib_list);

		// Token: 0x0600074F RID: 1871
		[DllImport("libEGL.dll", EntryPoint = "eglDestroySurface")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroySurface(IntPtr dpy, IntPtr surface);

		// Token: 0x06000750 RID: 1872
		[DllImport("libEGL.dll", EntryPoint = "eglQuerySurface")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QuerySurface(IntPtr dpy, IntPtr surface, int attribute, out int value);

		// Token: 0x06000751 RID: 1873
		[DllImport("libEGL.dll", EntryPoint = "eglBindAPI")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool BindAPI(RenderApi api);

		// Token: 0x06000752 RID: 1874
		[DllImport("libEGL.dll", EntryPoint = "eglQueryAPI")]
		public static extern int QueryAPI();

		// Token: 0x06000753 RID: 1875
		[DllImport("libEGL.dll", EntryPoint = "eglWaitClient")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool WaitClient();

		// Token: 0x06000754 RID: 1876
		[DllImport("libEGL.dll", EntryPoint = "eglReleaseThread")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ReleaseThread();

		// Token: 0x06000755 RID: 1877
		[DllImport("libEGL.dll", EntryPoint = "eglCreatePbufferFromClientBuffer")]
		public static extern IntPtr CreatePbufferFromClientBuffer(IntPtr dpy, int buftype, IntPtr buffer, IntPtr config, int[] attrib_list);

		// Token: 0x06000756 RID: 1878
		[DllImport("libEGL.dll", EntryPoint = "eglSurfaceAttrib")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SurfaceAttrib(IntPtr dpy, IntPtr surface, int attribute, int value);

		// Token: 0x06000757 RID: 1879
		[DllImport("libEGL.dll", EntryPoint = "eglBindTexImage")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool BindTexImage(IntPtr dpy, IntPtr surface, int buffer);

		// Token: 0x06000758 RID: 1880
		[DllImport("libEGL.dll", EntryPoint = "eglReleaseTexImage")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ReleaseTexImage(IntPtr dpy, IntPtr surface, int buffer);

		// Token: 0x06000759 RID: 1881
		[DllImport("libEGL.dll", EntryPoint = "eglSwapInterval")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SwapInterval(IntPtr dpy, int interval);

		// Token: 0x0600075A RID: 1882
		[DllImport("libEGL.dll")]
		private static extern IntPtr eglCreateContext(IntPtr dpy, IntPtr config, IntPtr share_context, int[] attrib_list);

		// Token: 0x0600075B RID: 1883 RVA: 0x00018A6C File Offset: 0x00016C6C
		public static IntPtr CreateContext(IntPtr dpy, IntPtr config, IntPtr share_context, int[] attrib_list)
		{
			IntPtr intPtr = Egl.eglCreateContext(dpy, config, share_context, attrib_list);
			if (intPtr == IntPtr.Zero)
			{
				throw new GraphicsContextException(string.Format("Failed to create EGL context, error: {0}.", Egl.GetError()));
			}
			return intPtr;
		}

		// Token: 0x0600075C RID: 1884
		[DllImport("libEGL.dll", EntryPoint = "eglDestroyContext")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool DestroyContext(IntPtr dpy, IntPtr ctx);

		// Token: 0x0600075D RID: 1885
		[DllImport("libEGL.dll", EntryPoint = "eglMakeCurrent")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool MakeCurrent(IntPtr dpy, IntPtr draw, IntPtr read, IntPtr ctx);

		// Token: 0x0600075E RID: 1886
		[DllImport("libEGL.dll", EntryPoint = "eglGetCurrentContext")]
		public static extern IntPtr GetCurrentContext();

		// Token: 0x0600075F RID: 1887
		[DllImport("libEGL.dll", EntryPoint = "eglGetCurrentSurface")]
		public static extern IntPtr GetCurrentSurface(int readdraw);

		// Token: 0x06000760 RID: 1888
		[DllImport("libEGL.dll", EntryPoint = "eglGetCurrentDisplay")]
		public static extern IntPtr GetCurrentDisplay();

		// Token: 0x06000761 RID: 1889
		[DllImport("libEGL.dll", EntryPoint = "eglQueryContext")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool QueryContext(IntPtr dpy, IntPtr ctx, int attribute, out int value);

		// Token: 0x06000762 RID: 1890
		[DllImport("libEGL.dll", EntryPoint = "eglWaitGL")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool WaitGL();

		// Token: 0x06000763 RID: 1891
		[DllImport("libEGL.dll", EntryPoint = "eglWaitNative")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool WaitNative(int engine);

		// Token: 0x06000764 RID: 1892
		[DllImport("libEGL.dll", EntryPoint = "eglSwapBuffers")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SwapBuffers(IntPtr dpy, IntPtr surface);

		// Token: 0x06000765 RID: 1893
		[DllImport("libEGL.dll", EntryPoint = "eglCopyBuffers")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CopyBuffers(IntPtr dpy, IntPtr surface, IntPtr target);

		// Token: 0x06000766 RID: 1894
		[DllImport("libEGL.dll", EntryPoint = "eglGetProcAddress")]
		public static extern IntPtr GetProcAddress(string funcname);

		// Token: 0x06000767 RID: 1895
		[DllImport("libEGL.dll", EntryPoint = "eglGetProcAddress")]
		public static extern IntPtr GetProcAddress(IntPtr funcname);

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x00018AAC File Offset: 0x00016CAC
		public static bool IsSupported
		{
			get
			{
				try
				{
					Egl.GetCurrentContext();
				}
				catch (Exception)
				{
					return false;
				}
				return true;
			}
		}

		// Token: 0x040001F3 RID: 499
		public const int VERSION_1_0 = 1;

		// Token: 0x040001F4 RID: 500
		public const int VERSION_1_1 = 1;

		// Token: 0x040001F5 RID: 501
		public const int VERSION_1_2 = 1;

		// Token: 0x040001F6 RID: 502
		public const int VERSION_1_3 = 1;

		// Token: 0x040001F7 RID: 503
		public const int VERSION_1_4 = 1;

		// Token: 0x040001F8 RID: 504
		public const int FALSE = 0;

		// Token: 0x040001F9 RID: 505
		public const int TRUE = 1;

		// Token: 0x040001FA RID: 506
		public const int DONT_CARE = -1;

		// Token: 0x040001FB RID: 507
		public const int CONTEXT_LOST = 12302;

		// Token: 0x040001FC RID: 508
		public const int BUFFER_SIZE = 12320;

		// Token: 0x040001FD RID: 509
		public const int ALPHA_SIZE = 12321;

		// Token: 0x040001FE RID: 510
		public const int BLUE_SIZE = 12322;

		// Token: 0x040001FF RID: 511
		public const int GREEN_SIZE = 12323;

		// Token: 0x04000200 RID: 512
		public const int RED_SIZE = 12324;

		// Token: 0x04000201 RID: 513
		public const int DEPTH_SIZE = 12325;

		// Token: 0x04000202 RID: 514
		public const int STENCIL_SIZE = 12326;

		// Token: 0x04000203 RID: 515
		public const int CONFIG_CAVEAT = 12327;

		// Token: 0x04000204 RID: 516
		public const int CONFIG_ID = 12328;

		// Token: 0x04000205 RID: 517
		public const int LEVEL = 12329;

		// Token: 0x04000206 RID: 518
		public const int MAX_PBUFFER_HEIGHT = 12330;

		// Token: 0x04000207 RID: 519
		public const int MAX_PBUFFER_PIXELS = 12331;

		// Token: 0x04000208 RID: 520
		public const int MAX_PBUFFER_WIDTH = 12332;

		// Token: 0x04000209 RID: 521
		public const int NATIVE_RENDERABLE = 12333;

		// Token: 0x0400020A RID: 522
		public const int NATIVE_VISUAL_ID = 12334;

		// Token: 0x0400020B RID: 523
		public const int NATIVE_VISUAL_TYPE = 12335;

		// Token: 0x0400020C RID: 524
		public const int PRESERVED_RESOURCES = 12336;

		// Token: 0x0400020D RID: 525
		public const int SAMPLES = 12337;

		// Token: 0x0400020E RID: 526
		public const int SAMPLE_BUFFERS = 12338;

		// Token: 0x0400020F RID: 527
		public const int SURFACE_TYPE = 12339;

		// Token: 0x04000210 RID: 528
		public const int TRANSPARENT_TYPE = 12340;

		// Token: 0x04000211 RID: 529
		public const int TRANSPARENT_BLUE_VALUE = 12341;

		// Token: 0x04000212 RID: 530
		public const int TRANSPARENT_GREEN_VALUE = 12342;

		// Token: 0x04000213 RID: 531
		public const int TRANSPARENT_RED_VALUE = 12343;

		// Token: 0x04000214 RID: 532
		public const int NONE = 12344;

		// Token: 0x04000215 RID: 533
		public const int BIND_TO_TEXTURE_RGB = 12345;

		// Token: 0x04000216 RID: 534
		public const int BIND_TO_TEXTURE_RGBA = 12346;

		// Token: 0x04000217 RID: 535
		public const int MIN_SWAP_INTERVAL = 12347;

		// Token: 0x04000218 RID: 536
		public const int MAX_SWAP_INTERVAL = 12348;

		// Token: 0x04000219 RID: 537
		public const int LUMINANCE_SIZE = 12349;

		// Token: 0x0400021A RID: 538
		public const int ALPHA_MASK_SIZE = 12350;

		// Token: 0x0400021B RID: 539
		public const int COLOR_BUFFER_TYPE = 12351;

		// Token: 0x0400021C RID: 540
		public const int RENDERABLE_TYPE = 12352;

		// Token: 0x0400021D RID: 541
		public const int MATCH_NATIVE_PIXMAP = 12353;

		// Token: 0x0400021E RID: 542
		public const int CONFORMANT = 12354;

		// Token: 0x0400021F RID: 543
		public const int SLOW_CONFIG = 12368;

		// Token: 0x04000220 RID: 544
		public const int NON_CONFORMANT_CONFIG = 12369;

		// Token: 0x04000221 RID: 545
		public const int TRANSPARENT_RGB = 12370;

		// Token: 0x04000222 RID: 546
		public const int RGB_BUFFER = 12430;

		// Token: 0x04000223 RID: 547
		public const int LUMINANCE_BUFFER = 12431;

		// Token: 0x04000224 RID: 548
		public const int NO_TEXTURE = 12380;

		// Token: 0x04000225 RID: 549
		public const int TEXTURE_RGB = 12381;

		// Token: 0x04000226 RID: 550
		public const int TEXTURE_RGBA = 12382;

		// Token: 0x04000227 RID: 551
		public const int TEXTURE_2D = 12383;

		// Token: 0x04000228 RID: 552
		public const int PBUFFER_BIT = 1;

		// Token: 0x04000229 RID: 553
		public const int PIXMAP_BIT = 2;

		// Token: 0x0400022A RID: 554
		public const int WINDOW_BIT = 4;

		// Token: 0x0400022B RID: 555
		public const int VG_COLORSPACE_LINEAR_BIT = 32;

		// Token: 0x0400022C RID: 556
		public const int VG_ALPHA_FORMAT_PRE_BIT = 64;

		// Token: 0x0400022D RID: 557
		public const int MULTISAMPLE_RESOLVE_BOX_BIT = 512;

		// Token: 0x0400022E RID: 558
		public const int SWAP_BEHAVIOR_PRESERVED_BIT = 1024;

		// Token: 0x0400022F RID: 559
		public const int OPENGL_ES_BIT = 1;

		// Token: 0x04000230 RID: 560
		public const int OPENVG_BIT = 2;

		// Token: 0x04000231 RID: 561
		public const int OPENGL_ES2_BIT = 4;

		// Token: 0x04000232 RID: 562
		public const int OPENGL_BIT = 8;

		// Token: 0x04000233 RID: 563
		public const int VENDOR = 12371;

		// Token: 0x04000234 RID: 564
		public const int VERSION = 12372;

		// Token: 0x04000235 RID: 565
		public const int EXTENSIONS = 12373;

		// Token: 0x04000236 RID: 566
		public const int CLIENT_APIS = 12429;

		// Token: 0x04000237 RID: 567
		public const int HEIGHT = 12374;

		// Token: 0x04000238 RID: 568
		public const int WIDTH = 12375;

		// Token: 0x04000239 RID: 569
		public const int LARGEST_PBUFFER = 12376;

		// Token: 0x0400023A RID: 570
		public const int TEXTURE_FORMAT = 12416;

		// Token: 0x0400023B RID: 571
		public const int TEXTURE_TARGET = 12417;

		// Token: 0x0400023C RID: 572
		public const int MIPMAP_TEXTURE = 12418;

		// Token: 0x0400023D RID: 573
		public const int MIPMAP_LEVEL = 12419;

		// Token: 0x0400023E RID: 574
		public const int RENDER_BUFFER = 12422;

		// Token: 0x0400023F RID: 575
		public const int VG_COLORSPACE = 12423;

		// Token: 0x04000240 RID: 576
		public const int VG_ALPHA_FORMAT = 12424;

		// Token: 0x04000241 RID: 577
		public const int HORIZONTAL_RESOLUTION = 12432;

		// Token: 0x04000242 RID: 578
		public const int VERTICAL_RESOLUTION = 12433;

		// Token: 0x04000243 RID: 579
		public const int PIXEL_ASPECT_RATIO = 12434;

		// Token: 0x04000244 RID: 580
		public const int SWAP_BEHAVIOR = 12435;

		// Token: 0x04000245 RID: 581
		public const int MULTISAMPLE_RESOLVE = 12441;

		// Token: 0x04000246 RID: 582
		public const int BACK_BUFFER = 12420;

		// Token: 0x04000247 RID: 583
		public const int SINGLE_BUFFER = 12421;

		// Token: 0x04000248 RID: 584
		public const int VG_COLORSPACE_sRGB = 12425;

		// Token: 0x04000249 RID: 585
		public const int VG_COLORSPACE_LINEAR = 12426;

		// Token: 0x0400024A RID: 586
		public const int VG_ALPHA_FORMAT_NONPRE = 12427;

		// Token: 0x0400024B RID: 587
		public const int VG_ALPHA_FORMAT_PRE = 12428;

		// Token: 0x0400024C RID: 588
		public const int DISPLAY_SCALING = 10000;

		// Token: 0x0400024D RID: 589
		public const int UNKNOWN = -1;

		// Token: 0x0400024E RID: 590
		public const int BUFFER_PRESERVED = 12436;

		// Token: 0x0400024F RID: 591
		public const int BUFFER_DESTROYED = 12437;

		// Token: 0x04000250 RID: 592
		public const int OPENVG_IMAGE = 12438;

		// Token: 0x04000251 RID: 593
		public const int CONTEXT_CLIENT_TYPE = 12439;

		// Token: 0x04000252 RID: 594
		public const int CONTEXT_CLIENT_VERSION = 12440;

		// Token: 0x04000253 RID: 595
		public const int MULTISAMPLE_RESOLVE_DEFAULT = 12442;

		// Token: 0x04000254 RID: 596
		public const int MULTISAMPLE_RESOLVE_BOX = 12443;

		// Token: 0x04000255 RID: 597
		public const int OPENGL_ES_API = 12448;

		// Token: 0x04000256 RID: 598
		public const int OPENVG_API = 12449;

		// Token: 0x04000257 RID: 599
		public const int OPENGL_API = 12450;

		// Token: 0x04000258 RID: 600
		public const int DRAW = 12377;

		// Token: 0x04000259 RID: 601
		public const int READ = 12378;

		// Token: 0x0400025A RID: 602
		public const int CORE_NATIVE_ENGINE = 12379;

		// Token: 0x0400025B RID: 603
		public const int COLORSPACE = 12423;

		// Token: 0x0400025C RID: 604
		public const int ALPHA_FORMAT = 12424;

		// Token: 0x0400025D RID: 605
		public const int COLORSPACE_sRGB = 12425;

		// Token: 0x0400025E RID: 606
		public const int COLORSPACE_LINEAR = 12426;

		// Token: 0x0400025F RID: 607
		public const int ALPHA_FORMAT_NONPRE = 12427;

		// Token: 0x04000260 RID: 608
		public const int ALPHA_FORMAT_PRE = 12428;
	}
}
