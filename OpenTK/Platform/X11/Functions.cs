using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000106 RID: 262
	internal static class Functions
	{
		// Token: 0x060009A3 RID: 2467
		[DllImport("libX11", EntryPoint = "XOpenDisplay")]
		private static extern IntPtr sys_XOpenDisplay(IntPtr display);

		// Token: 0x060009A4 RID: 2468 RVA: 0x000207B0 File Offset: 0x0001E9B0
		public static IntPtr XOpenDisplay(IntPtr display)
		{
			IntPtr result;
			lock (Functions.Lock)
			{
				result = Functions.sys_XOpenDisplay(display);
			}
			return result;
		}

		// Token: 0x060009A5 RID: 2469
		[DllImport("libX11")]
		public static extern int XCloseDisplay(IntPtr display);

		// Token: 0x060009A6 RID: 2470
		[DllImport("libX11")]
		public static extern IntPtr XSynchronize(IntPtr display, bool onoff);

		// Token: 0x060009A7 RID: 2471
		[DllImport("libX11")]
		public unsafe static extern IntPtr XCreateWindow(IntPtr display, IntPtr parent, int x, int y, int width, int height, int border_width, int depth, int xclass, IntPtr visual, IntPtr valuemask, XSetWindowAttributes* attributes);

		// Token: 0x060009A8 RID: 2472
		[DllImport("libX11")]
		public static extern IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent, int x, int y, int width, int height, int border_width, UIntPtr border, UIntPtr background);

		// Token: 0x060009A9 RID: 2473
		[DllImport("libX11")]
		public static extern IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent, int x, int y, int width, int height, int border_width, IntPtr border, IntPtr background);

		// Token: 0x060009AA RID: 2474
		[DllImport("libX11")]
		public static extern int XMapWindow(IntPtr display, IntPtr window);

		// Token: 0x060009AB RID: 2475
		[DllImport("libX11")]
		public static extern int XUnmapWindow(IntPtr display, IntPtr window);

		// Token: 0x060009AC RID: 2476
		[DllImport("libX11", EntryPoint = "XMapSubwindows")]
		public static extern int XMapSubindows(IntPtr display, IntPtr window);

		// Token: 0x060009AD RID: 2477
		[DllImport("libX11")]
		public static extern int XUnmapSubwindows(IntPtr display, IntPtr window);

		// Token: 0x060009AE RID: 2478
		[DllImport("libX11")]
		public static extern IntPtr XRootWindow(IntPtr display, int screen_number);

		// Token: 0x060009AF RID: 2479
		[DllImport("libX11")]
		public static extern IntPtr XNextEvent(IntPtr display, ref XEvent xevent);

		// Token: 0x060009B0 RID: 2480
		[DllImport("libX11")]
		public static extern bool XWindowEvent(IntPtr display, IntPtr w, EventMask event_mask, ref XEvent event_return);

		// Token: 0x060009B1 RID: 2481
		[DllImport("libX11")]
		public static extern bool XCheckWindowEvent(IntPtr display, IntPtr w, EventMask event_mask, ref XEvent event_return);

		// Token: 0x060009B2 RID: 2482
		[DllImport("libX11")]
		public static extern bool XCheckTypedWindowEvent(IntPtr display, IntPtr w, XEventName event_type, ref XEvent event_return);

		// Token: 0x060009B3 RID: 2483
		[DllImport("libX11")]
		public static extern bool XCheckTypedEvent(IntPtr display, XEventName event_type, out XEvent event_return);

		// Token: 0x060009B4 RID: 2484
		[DllImport("libX11")]
		public static extern bool XIfEvent(IntPtr display, ref XEvent e, IntPtr predicate, IntPtr arg);

		// Token: 0x060009B5 RID: 2485
		[DllImport("libX11")]
		public static extern bool XCheckIfEvent(IntPtr display, ref XEvent e, IntPtr predicate, IntPtr arg);

		// Token: 0x060009B6 RID: 2486
		[DllImport("libX11")]
		public static extern int XConnectionNumber(IntPtr diplay);

		// Token: 0x060009B7 RID: 2487
		[DllImport("libX11")]
		public static extern int XPending(IntPtr diplay);

		// Token: 0x060009B8 RID: 2488
		[DllImport("libX11")]
		public static extern int XSelectInput(IntPtr display, IntPtr window, IntPtr mask);

		// Token: 0x060009B9 RID: 2489
		[DllImport("libX11")]
		public static extern int XDestroyWindow(IntPtr display, IntPtr window);

		// Token: 0x060009BA RID: 2490
		[DllImport("libX11")]
		public static extern int XReparentWindow(IntPtr display, IntPtr window, IntPtr parent, int x, int y);

		// Token: 0x060009BB RID: 2491
		[DllImport("libX11")]
		public static extern int XMoveResizeWindow(IntPtr display, IntPtr window, int x, int y, int width, int height);

		// Token: 0x060009BC RID: 2492
		[DllImport("libX11")]
		public static extern int XMoveWindow(IntPtr display, IntPtr w, int x, int y);

		// Token: 0x060009BD RID: 2493
		[DllImport("libX11")]
		public static extern int XResizeWindow(IntPtr display, IntPtr window, int width, int height);

		// Token: 0x060009BE RID: 2494
		[DllImport("libX11")]
		public static extern int XGetWindowAttributes(IntPtr display, IntPtr window, ref XWindowAttributes attributes);

		// Token: 0x060009BF RID: 2495
		[DllImport("libX11")]
		public static extern int XFlush(IntPtr display);

		// Token: 0x060009C0 RID: 2496
		[DllImport("libX11")]
		public static extern int XSetWMName(IntPtr display, IntPtr window, ref XTextProperty text_prop);

		// Token: 0x060009C1 RID: 2497
		[DllImport("libX11")]
		public static extern int XStoreName(IntPtr display, IntPtr window, string window_name);

		// Token: 0x060009C2 RID: 2498
		[DllImport("libX11")]
		public static extern int XFetchName(IntPtr display, IntPtr window, ref IntPtr window_name);

		// Token: 0x060009C3 RID: 2499
		[DllImport("libX11")]
		public static extern int XSendEvent(IntPtr display, IntPtr window, bool propagate, IntPtr event_mask, ref XEvent send_event);

		// Token: 0x060009C4 RID: 2500 RVA: 0x000207EC File Offset: 0x0001E9EC
		public static int XSendEvent(IntPtr display, IntPtr window, bool propagate, EventMask event_mask, ref XEvent send_event)
		{
			return Functions.XSendEvent(display, window, propagate, new IntPtr((int)event_mask), ref send_event);
		}

		// Token: 0x060009C5 RID: 2501
		[DllImport("libX11")]
		public static extern int XQueryTree(IntPtr display, IntPtr window, out IntPtr root_return, out IntPtr parent_return, out IntPtr children_return, out int nchildren_return);

		// Token: 0x060009C6 RID: 2502
		[DllImport("libX11")]
		public static extern int XFree(IntPtr data);

		// Token: 0x060009C7 RID: 2503
		[DllImport("libX11")]
		public static extern int XRaiseWindow(IntPtr display, IntPtr window);

		// Token: 0x060009C8 RID: 2504
		[DllImport("libX11")]
		public static extern uint XLowerWindow(IntPtr display, IntPtr window);

		// Token: 0x060009C9 RID: 2505
		[DllImport("libX11")]
		public static extern uint XConfigureWindow(IntPtr display, IntPtr window, ChangeWindowAttributes value_mask, ref XWindowChanges values);

		// Token: 0x060009CA RID: 2506
		[DllImport("libX11")]
		public static extern IntPtr XInternAtom(IntPtr display, string atom_name, bool only_if_exists);

		// Token: 0x060009CB RID: 2507
		[DllImport("libX11")]
		public static extern int XInternAtoms(IntPtr display, string[] atom_names, int atom_count, bool only_if_exists, IntPtr[] atoms);

		// Token: 0x060009CC RID: 2508
		[DllImport("libX11")]
		public static extern int XSetWMProtocols(IntPtr display, IntPtr window, IntPtr[] protocols, int count);

		// Token: 0x060009CD RID: 2509
		[DllImport("libX11")]
		public static extern int XGrabPointer(IntPtr display, IntPtr window, bool owner_events, EventMask event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, IntPtr confine_to, IntPtr cursor, IntPtr timestamp);

		// Token: 0x060009CE RID: 2510
		[DllImport("libX11")]
		public static extern int XUngrabPointer(IntPtr display, IntPtr timestamp);

		// Token: 0x060009CF RID: 2511
		[DllImport("libX11")]
		public static extern int XGrabButton(IntPtr display, int button, uint modifiers, IntPtr grab_window, bool owner_events, EventMask event_mask, GrabMode pointer_mode, GrabMode keyboard_mode, IntPtr confine_to, IntPtr cursor);

		// Token: 0x060009D0 RID: 2512
		[DllImport("libX11")]
		public static extern int XUngrabButton(IntPtr display, uint button, uint modifiers, IntPtr grab_window);

		// Token: 0x060009D1 RID: 2513
		[DllImport("libX11")]
		public static extern bool XQueryPointer(IntPtr display, IntPtr window, out IntPtr root, out IntPtr child, out int root_x, out int root_y, out int win_x, out int win_y, out int keys_buttons);

		// Token: 0x060009D2 RID: 2514
		[DllImport("libX11")]
		public static extern bool XTranslateCoordinates(IntPtr display, IntPtr src_w, IntPtr dest_w, int src_x, int src_y, out int intdest_x_return, out int dest_y_return, out IntPtr child_return);

		// Token: 0x060009D3 RID: 2515
		[DllImport("libX11")]
		public static extern int XGrabKey(IntPtr display, int keycode, uint modifiers, IntPtr grab_window, bool owner_events, GrabMode pointer_mode, GrabMode keyboard_mode);

		// Token: 0x060009D4 RID: 2516
		[DllImport("libX11")]
		public static extern int XUngrabKey(IntPtr display, int keycode, uint modifiers, IntPtr grab_window);

		// Token: 0x060009D5 RID: 2517
		[DllImport("libX11")]
		public static extern int XGrabKeyboard(IntPtr display, IntPtr window, bool owner_events, GrabMode pointer_mode, GrabMode keyboard_mode, IntPtr timestamp);

		// Token: 0x060009D6 RID: 2518
		[DllImport("libX11")]
		public static extern int XUngrabKeyboard(IntPtr display, IntPtr timestamp);

		// Token: 0x060009D7 RID: 2519
		[DllImport("libX11")]
		public static extern int XAllowEvents(IntPtr display, EventMode event_mode, IntPtr time);

		// Token: 0x060009D8 RID: 2520
		[DllImport("libX11")]
		public static extern bool XGetGeometry(IntPtr display, IntPtr window, out IntPtr root, out int x, out int y, out int width, out int height, out int border_width, out int depth);

		// Token: 0x060009D9 RID: 2521
		[DllImport("libX11")]
		public static extern bool XGetGeometry(IntPtr display, IntPtr window, IntPtr root, out int x, out int y, out int width, out int height, IntPtr border_width, IntPtr depth);

		// Token: 0x060009DA RID: 2522
		[DllImport("libX11")]
		public static extern bool XGetGeometry(IntPtr display, IntPtr window, IntPtr root, out int x, out int y, IntPtr width, IntPtr height, IntPtr border_width, IntPtr depth);

		// Token: 0x060009DB RID: 2523
		[DllImport("libX11")]
		public static extern bool XGetGeometry(IntPtr display, IntPtr window, IntPtr root, IntPtr x, IntPtr y, out int width, out int height, IntPtr border_width, IntPtr depth);

		// Token: 0x060009DC RID: 2524
		[DllImport("libX11")]
		public static extern uint XWarpPointer(IntPtr display, IntPtr src_w, IntPtr dest_w, int src_x, int src_y, uint src_width, uint src_height, int dest_x, int dest_y);

		// Token: 0x060009DD RID: 2525
		[DllImport("libX11")]
		public static extern int XClearWindow(IntPtr display, IntPtr window);

		// Token: 0x060009DE RID: 2526
		[DllImport("libX11")]
		public static extern int XClearArea(IntPtr display, IntPtr window, int x, int y, int width, int height, bool exposures);

		// Token: 0x060009DF RID: 2527
		[DllImport("libX11")]
		public static extern IntPtr XDefaultScreenOfDisplay(IntPtr display);

		// Token: 0x060009E0 RID: 2528
		[DllImport("libX11")]
		public static extern int XScreenNumberOfScreen(IntPtr display, IntPtr Screen);

		// Token: 0x060009E1 RID: 2529
		[DllImport("libX11")]
		public static extern IntPtr XDefaultVisual(IntPtr display, int screen_number);

		// Token: 0x060009E2 RID: 2530
		[DllImport("libX11")]
		public static extern uint XDefaultDepth(IntPtr display, int screen_number);

		// Token: 0x060009E3 RID: 2531
		[DllImport("libX11")]
		public static extern int XDefaultScreen(IntPtr display);

		// Token: 0x060009E4 RID: 2532
		[DllImport("libX11")]
		public static extern IntPtr XDefaultColormap(IntPtr display, int screen_number);

		// Token: 0x060009E5 RID: 2533
		[DllImport("libX11")]
		public static extern int XLookupColor(IntPtr display, IntPtr Colormap, string Coloranem, ref XColor exact_def_color, ref XColor screen_def_color);

		// Token: 0x060009E6 RID: 2534
		[DllImport("libX11")]
		public static extern int XAllocColor(IntPtr display, IntPtr Colormap, ref XColor colorcell_def);

		// Token: 0x060009E7 RID: 2535
		[DllImport("libX11")]
		public static extern int XSetTransientForHint(IntPtr display, IntPtr window, IntPtr prop_window);

		// Token: 0x060009E8 RID: 2536
		[DllImport("libX11")]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, ref MotifWmHints data, int nelements);

		// Token: 0x060009E9 RID: 2537
		[DllImport("libX11")]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, ref uint value, int nelements);

		// Token: 0x060009EA RID: 2538
		[DllImport("libX11")]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, ref int value, int nelements);

		// Token: 0x060009EB RID: 2539
		[DllImport("libX11")]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, ref IntPtr value, int nelements);

		// Token: 0x060009EC RID: 2540
		[DllImport("libX11")]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, uint[] data, int nelements);

		// Token: 0x060009ED RID: 2541
		[DllImport("libX11")]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, int[] data, int nelements);

		// Token: 0x060009EE RID: 2542
		[DllImport("libX11")]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, IntPtr[] data, int nelements);

		// Token: 0x060009EF RID: 2543
		[DllImport("libX11")]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, IntPtr atoms, int nelements);

		// Token: 0x060009F0 RID: 2544
		[DllImport("libX11", CharSet = CharSet.Ansi)]
		public static extern int XChangeProperty(IntPtr display, IntPtr window, IntPtr property, IntPtr type, int format, PropertyMode mode, string text, int text_length);

		// Token: 0x060009F1 RID: 2545
		[DllImport("libX11")]
		public static extern int XDeleteProperty(IntPtr display, IntPtr window, IntPtr property);

		// Token: 0x060009F2 RID: 2546
		[DllImport("libX11")]
		public static extern IntPtr XCreateGC(IntPtr display, IntPtr window, IntPtr valuemask, XGCValues[] values);

		// Token: 0x060009F3 RID: 2547
		[DllImport("libX11")]
		public static extern int XFreeGC(IntPtr display, IntPtr gc);

		// Token: 0x060009F4 RID: 2548
		[DllImport("libX11")]
		public static extern int XSetFunction(IntPtr display, IntPtr gc, GXFunction function);

		// Token: 0x060009F5 RID: 2549
		[DllImport("libX11")]
		public static extern int XSetLineAttributes(IntPtr display, IntPtr gc, int line_width, GCLineStyle line_style, GCCapStyle cap_style, GCJoinStyle join_style);

		// Token: 0x060009F6 RID: 2550
		[DllImport("libX11")]
		public static extern int XDrawLine(IntPtr display, IntPtr drawable, IntPtr gc, int x1, int y1, int x2, int y2);

		// Token: 0x060009F7 RID: 2551
		[DllImport("libX11")]
		public static extern int XDrawRectangle(IntPtr display, IntPtr drawable, IntPtr gc, int x1, int y1, int width, int height);

		// Token: 0x060009F8 RID: 2552
		[DllImport("libX11")]
		public static extern int XFillRectangle(IntPtr display, IntPtr drawable, IntPtr gc, int x1, int y1, int width, int height);

		// Token: 0x060009F9 RID: 2553
		[DllImport("libX11")]
		public static extern int XSetWindowBackground(IntPtr display, IntPtr window, IntPtr background);

		// Token: 0x060009FA RID: 2554
		[DllImport("libX11")]
		public static extern int XCopyArea(IntPtr display, IntPtr src, IntPtr dest, IntPtr gc, int src_x, int src_y, int width, int height, int dest_x, int dest_y);

		// Token: 0x060009FB RID: 2555
		[DllImport("libX11")]
		public static extern int XGetWindowProperty(IntPtr display, IntPtr window, IntPtr atom, IntPtr long_offset, IntPtr long_length, bool delete, IntPtr req_type, out IntPtr actual_type, out int actual_format, out IntPtr nitems, out IntPtr bytes_after, ref IntPtr prop);

		// Token: 0x060009FC RID: 2556
		[DllImport("libX11")]
		public static extern int XSetInputFocus(IntPtr display, IntPtr window, RevertTo revert_to, IntPtr time);

		// Token: 0x060009FD RID: 2557
		[DllImport("libX11")]
		public static extern int XIconifyWindow(IntPtr display, IntPtr window, int screen_number);

		// Token: 0x060009FE RID: 2558
		[DllImport("libX11")]
		public static extern int XDefineCursor(IntPtr display, IntPtr window, IntPtr cursor);

		// Token: 0x060009FF RID: 2559
		[DllImport("libX11")]
		public static extern int XUndefineCursor(IntPtr display, IntPtr window);

		// Token: 0x06000A00 RID: 2560
		[DllImport("libX11")]
		public static extern int XFreeCursor(IntPtr display, IntPtr cursor);

		// Token: 0x06000A01 RID: 2561
		[DllImport("libX11")]
		public static extern IntPtr XCreateFontCursor(IntPtr display, CursorFontShape shape);

		// Token: 0x06000A02 RID: 2562
		[DllImport("libX11")]
		public static extern IntPtr XCreatePixmapCursor(IntPtr display, IntPtr source, IntPtr mask, ref XColor foreground_color, ref XColor background_color, int x_hot, int y_hot);

		// Token: 0x06000A03 RID: 2563
		[DllImport("libX11")]
		public static extern IntPtr XCreatePixmapFromBitmapData(IntPtr display, IntPtr drawable, byte[] data, int width, int height, IntPtr fg, IntPtr bg, int depth);

		// Token: 0x06000A04 RID: 2564
		[DllImport("libX11")]
		public static extern IntPtr XCreatePixmap(IntPtr display, IntPtr d, int width, int height, int depth);

		// Token: 0x06000A05 RID: 2565
		[DllImport("libX11")]
		public static extern IntPtr XFreePixmap(IntPtr display, IntPtr pixmap);

		// Token: 0x06000A06 RID: 2566
		[DllImport("libX11")]
		public static extern int XQueryBestCursor(IntPtr display, IntPtr drawable, int width, int height, out int best_width, out int best_height);

		// Token: 0x06000A07 RID: 2567
		[DllImport("libX11")]
		public static extern int XQueryExtension(IntPtr display, string extension_name, out int major, out int first_event, out int first_error);

		// Token: 0x06000A08 RID: 2568
		[DllImport("libX11")]
		public static extern IntPtr XWhitePixel(IntPtr display, int screen_no);

		// Token: 0x06000A09 RID: 2569
		[DllImport("libX11")]
		public static extern IntPtr XBlackPixel(IntPtr display, int screen_no);

		// Token: 0x06000A0A RID: 2570
		[DllImport("libX11")]
		public static extern void XGrabServer(IntPtr display);

		// Token: 0x06000A0B RID: 2571
		[DllImport("libX11")]
		public static extern void XUngrabServer(IntPtr display);

		// Token: 0x06000A0C RID: 2572
		[DllImport("libX11")]
		public static extern int XGetWMNormalHints(IntPtr display, IntPtr window, ref XSizeHints hints, out IntPtr supplied_return);

		// Token: 0x06000A0D RID: 2573
		[DllImport("libX11")]
		public static extern void XSetWMNormalHints(IntPtr display, IntPtr window, ref XSizeHints hints);

		// Token: 0x06000A0E RID: 2574
		[DllImport("libX11")]
		public static extern void XSetZoomHints(IntPtr display, IntPtr window, ref XSizeHints hints);

		// Token: 0x06000A0F RID: 2575
		[DllImport("libX11")]
		public static extern IntPtr XGetWMHints(IntPtr display, IntPtr w);

		// Token: 0x06000A10 RID: 2576
		[DllImport("libX11")]
		public static extern void XSetWMHints(IntPtr display, IntPtr w, ref XWMHints wmhints);

		// Token: 0x06000A11 RID: 2577
		[DllImport("libX11")]
		public static extern IntPtr XAllocWMHints();

		// Token: 0x06000A12 RID: 2578
		[DllImport("libX11")]
		public static extern int XGetIconSizes(IntPtr display, IntPtr window, out IntPtr size_list, out int count);

		// Token: 0x06000A13 RID: 2579
		[DllImport("libX11")]
		public static extern IntPtr XSetErrorHandler(XErrorHandler error_handler);

		// Token: 0x06000A14 RID: 2580
		[DllImport("libX11")]
		public static extern IntPtr XGetErrorText(IntPtr display, byte code, StringBuilder buffer, int length);

		// Token: 0x06000A15 RID: 2581
		[DllImport("libX11")]
		public static extern int XInitThreads();

		// Token: 0x06000A16 RID: 2582
		[DllImport("libX11")]
		public static extern int XConvertSelection(IntPtr display, IntPtr selection, IntPtr target, IntPtr property, IntPtr requestor, IntPtr time);

		// Token: 0x06000A17 RID: 2583
		[DllImport("libX11")]
		public static extern IntPtr XGetSelectionOwner(IntPtr display, IntPtr selection);

		// Token: 0x06000A18 RID: 2584
		[DllImport("libX11")]
		public static extern int XSetSelectionOwner(IntPtr display, IntPtr selection, IntPtr owner, IntPtr time);

		// Token: 0x06000A19 RID: 2585
		[DllImport("libX11")]
		public static extern int XSetPlaneMask(IntPtr display, IntPtr gc, IntPtr mask);

		// Token: 0x06000A1A RID: 2586
		[DllImport("libX11")]
		public static extern int XSetForeground(IntPtr display, IntPtr gc, UIntPtr foreground);

		// Token: 0x06000A1B RID: 2587
		[DllImport("libX11")]
		public static extern int XSetForeground(IntPtr display, IntPtr gc, IntPtr foreground);

		// Token: 0x06000A1C RID: 2588
		[DllImport("libX11")]
		public static extern int XSetBackground(IntPtr display, IntPtr gc, UIntPtr background);

		// Token: 0x06000A1D RID: 2589
		[DllImport("libX11")]
		public static extern int XSetBackground(IntPtr display, IntPtr gc, IntPtr background);

		// Token: 0x06000A1E RID: 2590
		[DllImport("libX11")]
		public static extern int XBell(IntPtr display, int percent);

		// Token: 0x06000A1F RID: 2591
		[DllImport("libX11")]
		public static extern int XChangeActivePointerGrab(IntPtr display, EventMask event_mask, IntPtr cursor, IntPtr time);

		// Token: 0x06000A20 RID: 2592
		[DllImport("libX11")]
		public static extern bool XFilterEvent(ref XEvent xevent, IntPtr window);

		// Token: 0x06000A21 RID: 2593
		[DllImport("libX11")]
		public static extern void XPeekEvent(IntPtr display, ref XEvent xevent);

		// Token: 0x06000A22 RID: 2594
		[DllImport("libX11", EntryPoint = "XGetVisualInfo")]
		private static extern IntPtr XGetVisualInfoInternal(IntPtr display, IntPtr vinfo_mask, ref XVisualInfo template, out int nitems);

		// Token: 0x06000A23 RID: 2595 RVA: 0x00020800 File Offset: 0x0001EA00
		public static IntPtr XGetVisualInfo(IntPtr display, XVisualInfoMask vinfo_mask, ref XVisualInfo template, out int nitems)
		{
			return Functions.XGetVisualInfoInternal(display, (IntPtr)((int)vinfo_mask), ref template, out nitems);
		}

		// Token: 0x06000A24 RID: 2596
		[DllImport("libX11")]
		public static extern IntPtr XCreateColormap(IntPtr display, IntPtr window, IntPtr visual, int alloc);

		// Token: 0x06000A25 RID: 2597
		[DllImport("libX11")]
		public static extern void XLockDisplay(IntPtr display);

		// Token: 0x06000A26 RID: 2598
		[DllImport("libX11")]
		public static extern void XUnlockDisplay(IntPtr display);

		// Token: 0x06000A27 RID: 2599
		[DllImport("libX11")]
		public static extern int XGetTransientForHint(IntPtr display, IntPtr w, out IntPtr prop_window_return);

		// Token: 0x06000A28 RID: 2600
		[DllImport("libX11")]
		public static extern void XSync(IntPtr display, bool discard);

		// Token: 0x06000A29 RID: 2601
		[DllImport("libX11")]
		public static extern void XAutoRepeatOff(IntPtr display);

		// Token: 0x06000A2A RID: 2602
		[DllImport("libX11")]
		public static extern void XAutoRepeatOn(IntPtr display);

		// Token: 0x06000A2B RID: 2603
		[DllImport("libX11")]
		public static extern IntPtr XDefaultRootWindow(IntPtr display);

		// Token: 0x06000A2C RID: 2604
		[DllImport("libX11")]
		public static extern int XBitmapBitOrder(IntPtr display);

		// Token: 0x06000A2D RID: 2605
		[DllImport("libX11")]
		public static extern IntPtr XCreateImage(IntPtr display, IntPtr visual, uint depth, ImageFormat format, int offset, byte[] data, uint width, uint height, int bitmap_pad, int bytes_per_line);

		// Token: 0x06000A2E RID: 2606
		[DllImport("libX11")]
		public static extern IntPtr XCreateImage(IntPtr display, IntPtr visual, uint depth, ImageFormat format, int offset, IntPtr data, uint width, uint height, int bitmap_pad, int bytes_per_line);

		// Token: 0x06000A2F RID: 2607
		[DllImport("libX11")]
		public static extern void XPutImage(IntPtr display, IntPtr drawable, IntPtr gc, IntPtr image, int src_x, int src_y, int dest_x, int dest_y, uint width, uint height);

		// Token: 0x06000A30 RID: 2608
		[DllImport("libX11")]
		public static extern int XLookupString(ref XKeyEvent event_struct, [Out] byte[] buffer_return, int bytes_buffer, [Out] IntPtr[] keysym_return, IntPtr status_in_out);

		// Token: 0x06000A31 RID: 2609
		[DllImport("libX11")]
		public static extern byte XKeysymToKeycode(IntPtr display, IntPtr keysym);

		// Token: 0x06000A32 RID: 2610
		[DllImport("libX11")]
		public static extern IntPtr XKeycodeToKeysym(IntPtr display, byte keycode, int index);

		// Token: 0x06000A33 RID: 2611
		[DllImport("libX11")]
		public static extern int XRefreshKeyboardMapping(ref XMappingEvent event_map);

		// Token: 0x06000A34 RID: 2612
		[DllImport("libX11")]
		public static extern int XGetEventData(IntPtr display, ref XGenericEventCookie cookie);

		// Token: 0x06000A35 RID: 2613
		[DllImport("libX11")]
		public static extern void XFreeEventData(IntPtr display, ref XGenericEventCookie cookie);

		// Token: 0x06000A36 RID: 2614
		[DllImport("libX11")]
		public static extern void XSetClassHint(IntPtr display, IntPtr window, ref XClassHint hint);

		// Token: 0x06000A37 RID: 2615 RVA: 0x00020810 File Offset: 0x0001EA10
		public static void SendNetWMMessage(X11WindowInfo window, IntPtr message_type, IntPtr l0, IntPtr l1, IntPtr l2)
		{
			XEvent xevent = default(XEvent);
			xevent.ClientMessageEvent.type = XEventName.ClientMessage;
			xevent.ClientMessageEvent.send_event = true;
			xevent.ClientMessageEvent.window = window.Handle;
			xevent.ClientMessageEvent.message_type = message_type;
			xevent.ClientMessageEvent.format = 32;
			xevent.ClientMessageEvent.ptr1 = l0;
			xevent.ClientMessageEvent.ptr2 = l1;
			xevent.ClientMessageEvent.ptr3 = l2;
			Functions.XSendEvent(window.Display, window.RootWindow, false, new IntPtr(1572864), ref xevent);
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x000208B4 File Offset: 0x0001EAB4
		public static void SendNetClientMessage(X11WindowInfo window, IntPtr message_type, IntPtr l0, IntPtr l1, IntPtr l2)
		{
			XEvent xevent = default(XEvent);
			xevent.ClientMessageEvent.type = XEventName.ClientMessage;
			xevent.ClientMessageEvent.send_event = true;
			xevent.ClientMessageEvent.window = window.Handle;
			xevent.ClientMessageEvent.message_type = message_type;
			xevent.ClientMessageEvent.format = 32;
			xevent.ClientMessageEvent.ptr1 = l0;
			xevent.ClientMessageEvent.ptr2 = l1;
			xevent.ClientMessageEvent.ptr3 = l2;
			Functions.XSendEvent(window.Display, window.Handle, false, new IntPtr(0), ref xevent);
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00020954 File Offset: 0x0001EB54
		public static IntPtr CreatePixmapFromImage(IntPtr display, Bitmap image)
		{
			int width = image.Width;
			int height = image.Height;
			BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			IntPtr image2 = Functions.XCreateImage(display, Functions.CopyFromParent, 24U, ImageFormat.ZPixmap, 0, bitmapData.Scan0, (uint)width, (uint)height, 32, 0);
			IntPtr intPtr = Functions.XCreatePixmap(display, Functions.XDefaultRootWindow(display), width, height, 24);
			IntPtr gc = Functions.XCreateGC(display, intPtr, IntPtr.Zero, null);
			Functions.XPutImage(display, intPtr, gc, image2, 0, 0, 0, 0, (uint)width, (uint)height);
			Functions.XFreeGC(display, gc);
			image.UnlockBits(bitmapData);
			return intPtr;
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x000209E8 File Offset: 0x0001EBE8
		public static IntPtr CreateMaskFromImage(IntPtr display, Bitmap image)
		{
			int width = image.Width;
			int height = image.Height;
			int num = width + 7 >> 3;
			byte[] array = new byte[num * height];
			bool flag = Functions.XBitmapBitOrder(display) == 1;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					byte b = (byte)(1 << ((flag ? (7 - (j & 7)) : (j & 7)) & 31));
					int num2 = i * num + (j >> 3);
					if (image.GetPixel(j, i).A >= 128)
					{
						byte[] array2 = array;
						int num3 = num2;
						array2[num3] |= b;
					}
				}
			}
			return Functions.XCreatePixmapFromBitmapData(display, Functions.XDefaultRootWindow(display), array, width, height, new IntPtr(1), IntPtr.Zero, 1);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00020AB0 File Offset: 0x0001ECB0
		public unsafe static IntPtr XCreateWindow(IntPtr display, IntPtr parent, int x, int y, int width, int height, int border_width, int depth, CreateWindowArgs @class, IntPtr visual, SetWindowValuemask valuemask, XSetWindowAttributes? attributes)
		{
			if (attributes != null)
			{
				XSetWindowAttributes value = attributes.Value;
				return Functions.XCreateWindow(display, parent, x, y, width, height, border_width, depth, (int)@class, visual, (IntPtr)((long)valuemask), &value);
			}
			return Functions.XCreateWindow(display, parent, x, y, width, height, border_width, depth, (int)@class, visual, (IntPtr)((long)valuemask), null);
		}

		// Token: 0x06000A3C RID: 2620
		[DllImport("libX11")]
		internal static extern void XChangeWindowAttributes(IntPtr display, IntPtr w, UIntPtr valuemask, ref XSetWindowAttributes attributes);

		// Token: 0x06000A3D RID: 2621 RVA: 0x00020B10 File Offset: 0x0001ED10
		internal static void XChangeWindowAttributes(IntPtr display, IntPtr w, SetWindowValuemask valuemask, ref XSetWindowAttributes attributes)
		{
			Functions.XChangeWindowAttributes(display, w, (UIntPtr)((ulong)((long)valuemask)), ref attributes);
		}

		// Token: 0x06000A3E RID: 2622
		[DllImport("libXcursor.so.1")]
		internal unsafe static extern XcursorImage* XcursorImageCreate(int width, int height);

		// Token: 0x06000A3F RID: 2623
		[DllImport("libXcursor.so.1")]
		internal unsafe static extern void XcursorImageDestroy(XcursorImage* image);

		// Token: 0x06000A40 RID: 2624
		[DllImport("libXcursor.so.1")]
		internal unsafe static extern IntPtr XcursorImageLoadCursor(IntPtr dpy, XcursorImage* image);

		// Token: 0x06000A41 RID: 2625
		[DllImport("libX11")]
		public static extern void XQueryKeymap(IntPtr display, byte[] keys);

		// Token: 0x06000A42 RID: 2626
		[DllImport("libX11")]
		public static extern void XMaskEvent(IntPtr display, EventMask event_mask, ref XEvent e);

		// Token: 0x06000A43 RID: 2627
		[DllImport("libX11")]
		public static extern void XPutBackEvent(IntPtr display, ref XEvent @event);

		// Token: 0x06000A44 RID: 2628
		[DllImport("libXrandr.so.2")]
		public static extern bool XRRQueryExtension(IntPtr dpy, ref int event_basep, ref int error_basep);

		// Token: 0x06000A45 RID: 2629
		[DllImport("libXrandr.so.2")]
		public static extern int XRRQueryVersion(IntPtr dpy, ref int major_versionp, ref int minor_versionp);

		// Token: 0x06000A46 RID: 2630
		[DllImport("libXrandr.so.2")]
		public static extern IntPtr XRRGetScreenInfo(IntPtr dpy, IntPtr draw);

		// Token: 0x06000A47 RID: 2631
		[DllImport("libXrandr.so.2")]
		public static extern void XRRFreeScreenConfigInfo(IntPtr config);

		// Token: 0x06000A48 RID: 2632
		[DllImport("libXrandr.so.2")]
		public static extern int XRRSetScreenConfig(IntPtr dpy, IntPtr config, IntPtr draw, int size_index, ushort rotation, IntPtr timestamp);

		// Token: 0x06000A49 RID: 2633
		[DllImport("libXrandr.so.2")]
		public static extern int XRRSetScreenConfigAndRate(IntPtr dpy, IntPtr config, IntPtr draw, int size_index, ushort rotation, short rate, IntPtr timestamp);

		// Token: 0x06000A4A RID: 2634
		[DllImport("libXrandr.so.2")]
		public static extern ushort XRRConfigRotations(IntPtr config, ref ushort current_rotation);

		// Token: 0x06000A4B RID: 2635
		[DllImport("libXrandr.so.2")]
		public static extern IntPtr XRRConfigTimes(IntPtr config, ref IntPtr config_timestamp);

		// Token: 0x06000A4C RID: 2636
		[DllImport("libXrandr.so.2")]
		[return: MarshalAs(UnmanagedType.LPStruct)]
		public static extern XRRScreenSize XRRConfigSizes(IntPtr config, int[] nsizes);

		// Token: 0x06000A4D RID: 2637
		[DllImport("libXrandr.so.2")]
		public unsafe static extern short* XRRConfigRates(IntPtr config, int size_index, int[] nrates);

		// Token: 0x06000A4E RID: 2638
		[DllImport("libXrandr.so.2")]
		public static extern ushort XRRConfigCurrentConfiguration(IntPtr config, out ushort rotation);

		// Token: 0x06000A4F RID: 2639
		[DllImport("libXrandr.so.2")]
		public static extern short XRRConfigCurrentRate(IntPtr config);

		// Token: 0x06000A50 RID: 2640
		[DllImport("libXrandr.so.2")]
		public static extern int XRRRootToScreen(IntPtr dpy, IntPtr root);

		// Token: 0x06000A51 RID: 2641
		[DllImport("libXrandr.so.2")]
		public static extern IntPtr XRRScreenConfig(IntPtr dpy, int screen);

		// Token: 0x06000A52 RID: 2642
		[DllImport("libXrandr.so.2")]
		public static extern IntPtr XRRConfig(ref Screen screen);

		// Token: 0x06000A53 RID: 2643
		[DllImport("libXrandr.so.2")]
		public static extern void XRRSelectInput(IntPtr dpy, IntPtr window, int mask);

		// Token: 0x06000A54 RID: 2644
		[DllImport("libXrandr.so.2")]
		public static extern int XRRUpdateConfiguration(ref XEvent @event);

		// Token: 0x06000A55 RID: 2645
		[DllImport("libXrandr.so.2")]
		public static extern ushort XRRRotations(IntPtr dpy, int screen, ref ushort current_rotation);

		// Token: 0x06000A56 RID: 2646
		[DllImport("libXrandr.so.2")]
		private unsafe static extern IntPtr XRRSizes(IntPtr dpy, int screen, int* nsizes);

		// Token: 0x06000A57 RID: 2647 RVA: 0x00020B24 File Offset: 0x0001ED24
		public unsafe static XRRScreenSize[] XRRSizes(IntPtr dpy, int screen)
		{
			int num;
			byte* ptr = (byte*)((void*)Functions.XRRSizes(dpy, screen, &num));
			if (num == 0)
			{
				return null;
			}
			XRRScreenSize[] array = new XRRScreenSize[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = default(XRRScreenSize);
				array[i] = (XRRScreenSize)Marshal.PtrToStructure((IntPtr)((void*)ptr), typeof(XRRScreenSize));
				ptr += Marshal.SizeOf(typeof(XRRScreenSize));
			}
			return array;
		}

		// Token: 0x06000A58 RID: 2648
		[DllImport("libXrandr.so.2")]
		private unsafe static extern short* XRRRates(IntPtr dpy, int screen, int size_index, int* nrates);

		// Token: 0x06000A59 RID: 2649 RVA: 0x00020BA0 File Offset: 0x0001EDA0
		public unsafe static short[] XRRRates(IntPtr dpy, int screen, int size_index)
		{
			int num;
			short* ptr = Functions.XRRRates(dpy, screen, size_index, &num);
			if (num == 0)
			{
				return null;
			}
			short[] array = new short[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = ptr[i];
			}
			return array;
		}

		// Token: 0x06000A5A RID: 2650
		[DllImport("libXrandr.so.2")]
		public static extern IntPtr XRRTimes(IntPtr dpy, int screen, out IntPtr config_timestamp);

		// Token: 0x06000A5B RID: 2651
		[DllImport("libX11")]
		public static extern int XScreenCount(IntPtr display);

		// Token: 0x06000A5C RID: 2652
		[DllImport("libX11")]
		private unsafe static extern int* XListDepths(IntPtr display, int screen_number, int* count_return);

		// Token: 0x06000A5D RID: 2653 RVA: 0x00020BDC File Offset: 0x0001EDDC
		public unsafe static int[] XListDepths(IntPtr display, int screen_number)
		{
			int num;
			int* ptr = Functions.XListDepths(display, screen_number, &num);
			if (num == 0)
			{
				return null;
			}
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = ptr[i];
			}
			return array;
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00020C18 File Offset: 0x0001EE18
		public unsafe static IntPtr XCreateBitmapFromData(IntPtr display, IntPtr d, byte[,] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			byte* ptr;
			if (data == null || data.Length == 0)
			{
				ptr = null;
			}
			else
			{
				fixed (byte* ptr = &data[0, 0])
				{
				}
			}
			return Functions.XCreateBitmapFromData(display, d, ptr, data.GetLength(0), data.GetLength(1));
		}

		// Token: 0x06000A5F RID: 2655
		[DllImport("libX11")]
		public unsafe static extern IntPtr XCreateBitmapFromData(IntPtr display, IntPtr d, byte* data, int width, int height);

		// Token: 0x06000A60 RID: 2656
		[DllImport("libX11", EntryPoint = "XAllocColor")]
		public static extern int XAllocNamedColor(IntPtr display, IntPtr colormap, string color_name, out XColor screen_def_return, out XColor exact_def_return);

		// Token: 0x04000968 RID: 2408
		internal const string X11Library = "libX11";

		// Token: 0x04000969 RID: 2409
		internal const string XcursorLibrary = "libXcursor.so.1";

		// Token: 0x0400096A RID: 2410
		private const string XrandrLibrary = "libXrandr.so.2";

		// Token: 0x0400096B RID: 2411
		public static readonly object Lock = API.Lock;

		// Token: 0x0400096C RID: 2412
		private static readonly IntPtr CopyFromParent = IntPtr.Zero;

		// Token: 0x02000107 RID: 263
		// (Invoke) Token: 0x06000A63 RID: 2659
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EventPredicate(IntPtr display, ref XEvent e, IntPtr arg);

		// Token: 0x02000108 RID: 264
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct Pixel
		{
			// Token: 0x06000A66 RID: 2662 RVA: 0x00020C84 File Offset: 0x0001EE84
			public Pixel(byte a, byte r, byte g, byte b)
			{
				this.A = a;
				this.R = r;
				this.G = g;
				this.B = b;
			}

			// Token: 0x06000A67 RID: 2663 RVA: 0x00020CA4 File Offset: 0x0001EEA4
			public static implicit operator Functions.Pixel(int argb)
			{
				return new Functions.Pixel((byte)(argb >> 24 & 255), (byte)(argb >> 16 & 255), (byte)(argb >> 8 & 255), (byte)(argb & 255));
			}

			// Token: 0x0400096D RID: 2413
			public byte A;

			// Token: 0x0400096E RID: 2414
			public byte R;

			// Token: 0x0400096F RID: 2415
			public byte G;

			// Token: 0x04000970 RID: 2416
			public byte B;
		}
	}
}
