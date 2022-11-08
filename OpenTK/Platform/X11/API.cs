using System;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000109 RID: 265
	internal static class API
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000A68 RID: 2664 RVA: 0x00020CD4 File Offset: 0x0001EED4
		internal static IntPtr DefaultDisplay
		{
			get
			{
				return API.defaultDisplay;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00020CDC File Offset: 0x0001EEDC
		private static int DefaultScreen
		{
			get
			{
				return API.defaultScreen;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000A6A RID: 2666 RVA: 0x00020CE4 File Offset: 0x0001EEE4
		internal static int ScreenCount
		{
			get
			{
				return API.screenCount;
			}
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x00020CEC File Offset: 0x0001EEEC
		static API()
		{
			Functions.XInitThreads();
			API.defaultDisplay = Functions.XOpenDisplay(IntPtr.Zero);
			if (API.defaultDisplay == IntPtr.Zero)
			{
				throw new PlatformException("Could not establish connection to the X-Server.");
			}
			using (new XLock(API.defaultDisplay))
			{
				API.screenCount = Functions.XScreenCount(API.DefaultDisplay);
			}
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x00020D70 File Offset: 0x0001EF70
		private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			if (API.defaultDisplay != IntPtr.Zero)
			{
				Functions.XCloseDisplay(API.defaultDisplay);
				API.defaultDisplay = IntPtr.Zero;
				API.defaultScreen = 0;
				API.rootWindow = IntPtr.Zero;
			}
		}

		// Token: 0x06000A6D RID: 2669
		[DllImport("libX11", EntryPoint = "XCreateSimpleWindow")]
		public static extern IntPtr CreateSimpleWindow(IntPtr display, IntPtr parent, int x, int y, int width, int height, int border_width, long border, long background);

		// Token: 0x06000A6E RID: 2670
		[DllImport("libX11")]
		public static extern int XResizeWindow(IntPtr display, IntPtr window, int width, int height);

		// Token: 0x06000A6F RID: 2671
		[DllImport("libX11", EntryPoint = "XDestroyWindow")]
		public static extern void DestroyWindow(IntPtr display, IntPtr window);

		// Token: 0x06000A70 RID: 2672
		[DllImport("libX11", EntryPoint = "XMapWindow")]
		public static extern void MapWindow(IntPtr display, IntPtr window);

		// Token: 0x06000A71 RID: 2673
		[DllImport("libX11", EntryPoint = "XMapRaised")]
		public static extern void MapRaised(IntPtr display, IntPtr window);

		// Token: 0x06000A72 RID: 2674
		[DllImport("libX11", EntryPoint = "XDefaultVisual")]
		public static extern IntPtr DefaultVisual(IntPtr display, int screen_number);

		// Token: 0x06000A73 RID: 2675
		[DllImport("libX11", EntryPoint = "XFree")]
		public static extern void Free(IntPtr buffer);

		// Token: 0x06000A74 RID: 2676
		[SuppressUnmanagedCodeSecurity]
		[DllImport("libX11", EntryPoint = "XEventsQueued")]
		public static extern int EventsQueued(IntPtr display, int mode);

		// Token: 0x06000A75 RID: 2677
		[SuppressUnmanagedCodeSecurity]
		[DllImport("libX11", EntryPoint = "XPending")]
		public static extern int Pending(IntPtr display);

		// Token: 0x06000A76 RID: 2678
		[DllImport("libX11", EntryPoint = "XNextEvent")]
		public static extern void NextEvent(IntPtr display, [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object e);

		// Token: 0x06000A77 RID: 2679
		[DllImport("libX11", EntryPoint = "XNextEvent")]
		public static extern void NextEvent(IntPtr display, [In] [Out] IntPtr e);

		// Token: 0x06000A78 RID: 2680
		[DllImport("libX11", EntryPoint = "XPeekEvent")]
		public static extern void PeekEvent(IntPtr display, [MarshalAs(UnmanagedType.AsAny)] [In] [Out] object event_return);

		// Token: 0x06000A79 RID: 2681
		[DllImport("libX11", EntryPoint = "XPeekEvent")]
		public static extern void PeekEvent(IntPtr display, [In] [Out] XEvent event_return);

		// Token: 0x06000A7A RID: 2682
		[DllImport("libX11", EntryPoint = "XSendEvent")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SendEvent(IntPtr display, IntPtr window, bool propagate, [MarshalAs(UnmanagedType.SysInt)] EventMask event_mask, ref XEvent event_send);

		// Token: 0x06000A7B RID: 2683
		[DllImport("libX11", EntryPoint = "XSelectInput")]
		public static extern void SelectInput(IntPtr display, IntPtr w, EventMask event_mask);

		// Token: 0x06000A7C RID: 2684
		[DllImport("libX11", EntryPoint = "XCheckIfEvent")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckIfEvent(IntPtr display, ref XEvent event_return, API.CheckEventPredicate predicate, IntPtr arg);

		// Token: 0x06000A7D RID: 2685
		[DllImport("libX11", EntryPoint = "XIfEvent")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IfEvent(IntPtr display, ref XEvent event_return, API.CheckEventPredicate predicate, IntPtr arg);

		// Token: 0x06000A7E RID: 2686
		[DllImport("libX11", EntryPoint = "XCheckMaskEvent")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckMaskEvent(IntPtr display, EventMask event_mask, ref XEvent event_return);

		// Token: 0x06000A7F RID: 2687
		[DllImport("libX11", EntryPoint = "XGrabPointer")]
		public static extern ErrorCodes GrabPointer(IntPtr display, IntPtr grab_window, bool owner_events, int event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, IntPtr confine_to, IntPtr cursor, int time);

		// Token: 0x06000A80 RID: 2688
		[DllImport("libX11", EntryPoint = "XUngrabPointer")]
		public static extern ErrorCodes UngrabPointer(IntPtr display, int time);

		// Token: 0x06000A81 RID: 2689
		[DllImport("libX11", EntryPoint = "XGrabKeyboard")]
		public static extern ErrorCodes GrabKeyboard(IntPtr display, IntPtr grab_window, bool owner_events, GrabMode pointer_mode, GrabMode keyboard_mode, int time);

		// Token: 0x06000A82 RID: 2690
		[DllImport("libX11", EntryPoint = "XUngrabKeyboard")]
		public static extern void UngrabKeyboard(IntPtr display, int time);

		// Token: 0x06000A83 RID: 2691
		[DllImport("libX11", EntryPoint = "XGetKeyboardMapping")]
		public static extern IntPtr GetKeyboardMapping(IntPtr display, byte first_keycode, int keycode_count, ref int keysyms_per_keycode_return);

		// Token: 0x06000A84 RID: 2692
		[DllImport("libX11", EntryPoint = "XDisplayKeycodes")]
		public static extern void DisplayKeycodes(IntPtr display, ref int min_keycodes_return, ref int max_keycodes_return);

		// Token: 0x06000A85 RID: 2693
		[DllImport("libXxf86vm")]
		public static extern bool XF86VidModeQueryExtension(IntPtr display, out int event_base_return, out int error_base_return);

		// Token: 0x06000A86 RID: 2694
		[DllImport("libXxf86vm")]
		public static extern bool XF86VidModeSwitchToMode(IntPtr display, int screen, IntPtr modeline);

		// Token: 0x06000A87 RID: 2695
		[DllImport("libXxf86vm")]
		public static extern bool XF86VidModeQueryVersion(IntPtr display, out int major_version_return, out int minor_version_return);

		// Token: 0x06000A88 RID: 2696
		[DllImport("libXxf86vm")]
		public static extern bool XF86VidModeGetModeLine(IntPtr display, int screen, out int dotclock_return, out API.XF86VidModeModeLine modeline);

		// Token: 0x06000A89 RID: 2697
		[DllImport("libXxf86vm")]
		public static extern bool XF86VidModeGetAllModeLines(IntPtr display, int screen, out int modecount_return, out IntPtr modesinfo);

		// Token: 0x06000A8A RID: 2698
		[DllImport("libXxf86vm")]
		public static extern bool XF86VidModeGetViewPort(IntPtr display, int screen, out int x_return, out int y_return);

		// Token: 0x06000A8B RID: 2699
		[DllImport("libXxf86vm")]
		public static extern bool XF86VidModeSetViewPort(IntPtr display, int screen, int x, int y);

		// Token: 0x06000A8C RID: 2700
		[DllImport("libX11", EntryPoint = "XLookupKeysym")]
		public static extern IntPtr LookupKeysym(ref XKeyEvent key_event, int index);

		// Token: 0x04000971 RID: 2417
		private const string _dll_name = "libX11";

		// Token: 0x04000972 RID: 2418
		private const string _dll_name_vid = "libXxf86vm";

		// Token: 0x04000973 RID: 2419
		private static IntPtr defaultDisplay;

		// Token: 0x04000974 RID: 2420
		private static int defaultScreen;

		// Token: 0x04000975 RID: 2421
		private static IntPtr rootWindow;

		// Token: 0x04000976 RID: 2422
		private static int screenCount;

		// Token: 0x04000977 RID: 2423
		internal static object Lock = new object();

		// Token: 0x0200010A RID: 266
		// (Invoke) Token: 0x06000A8E RID: 2702
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate bool CheckEventPredicate(IntPtr display, ref XEvent @event, IntPtr arg);

		// Token: 0x0200010B RID: 267
		internal struct XF86VidModeModeLine
		{
			// Token: 0x04000978 RID: 2424
			public short hdisplay;

			// Token: 0x04000979 RID: 2425
			public short hsyncstart;

			// Token: 0x0400097A RID: 2426
			public short hsyncend;

			// Token: 0x0400097B RID: 2427
			public short htotal;

			// Token: 0x0400097C RID: 2428
			public short vdisplay;

			// Token: 0x0400097D RID: 2429
			public short vsyncstart;

			// Token: 0x0400097E RID: 2430
			public short vsyncend;

			// Token: 0x0400097F RID: 2431
			public short vtotal;

			// Token: 0x04000980 RID: 2432
			public int flags;

			// Token: 0x04000981 RID: 2433
			public int privsize;

			// Token: 0x04000982 RID: 2434
			public IntPtr _private;
		}

		// Token: 0x0200010C RID: 268
		internal struct XF86VidModeModeInfo
		{
			// Token: 0x04000983 RID: 2435
			public int dotclock;

			// Token: 0x04000984 RID: 2436
			public short hdisplay;

			// Token: 0x04000985 RID: 2437
			public short hsyncstart;

			// Token: 0x04000986 RID: 2438
			public short hsyncend;

			// Token: 0x04000987 RID: 2439
			public short htotal;

			// Token: 0x04000988 RID: 2440
			public short hskew;

			// Token: 0x04000989 RID: 2441
			public short vdisplay;

			// Token: 0x0400098A RID: 2442
			public short vsyncstart;

			// Token: 0x0400098B RID: 2443
			public short vsyncend;

			// Token: 0x0400098C RID: 2444
			public short vtotal;

			// Token: 0x0400098D RID: 2445
			public short vskew;

			// Token: 0x0400098E RID: 2446
			public int flags;

			// Token: 0x0400098F RID: 2447
			private int privsize;

			// Token: 0x04000990 RID: 2448
			private IntPtr _private;
		}

		// Token: 0x0200010D RID: 269
		internal struct XF86VidModeMonitor
		{
			// Token: 0x04000991 RID: 2449
			[MarshalAs(UnmanagedType.LPStr)]
			private string vendor;

			// Token: 0x04000992 RID: 2450
			[MarshalAs(UnmanagedType.LPStr)]
			private string model;

			// Token: 0x04000993 RID: 2451
			private float EMPTY;

			// Token: 0x04000994 RID: 2452
			private byte nhsync;

			// Token: 0x04000995 RID: 2453
			private IntPtr hsync;

			// Token: 0x04000996 RID: 2454
			private byte nvsync;

			// Token: 0x04000997 RID: 2455
			private IntPtr vsync;
		}

		// Token: 0x0200010E RID: 270
		internal struct XF86VidModeSyncRange
		{
			// Token: 0x04000998 RID: 2456
			private float hi;

			// Token: 0x04000999 RID: 2457
			private float lo;
		}

		// Token: 0x0200010F RID: 271
		internal struct XF86VidModeNotifyEvent
		{
			// Token: 0x0400099A RID: 2458
			private int type;

			// Token: 0x0400099B RID: 2459
			private ulong serial;

			// Token: 0x0400099C RID: 2460
			private bool send_event;

			// Token: 0x0400099D RID: 2461
			private IntPtr display;

			// Token: 0x0400099E RID: 2462
			private IntPtr root;

			// Token: 0x0400099F RID: 2463
			private int state;

			// Token: 0x040009A0 RID: 2464
			private int kind;

			// Token: 0x040009A1 RID: 2465
			private bool forced;

			// Token: 0x040009A2 RID: 2466
			private IntPtr time;
		}

		// Token: 0x02000110 RID: 272
		internal struct XF86VidModeGamma
		{
			// Token: 0x040009A3 RID: 2467
			private float red;

			// Token: 0x040009A4 RID: 2468
			private float green;

			// Token: 0x040009A5 RID: 2469
			private float blue;
		}
	}
}
