using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000045 RID: 69
	internal class XI
	{
		// Token: 0x060004EB RID: 1259
		[DllImport("libXi", EntryPoint = "XISelectEvents")]
		private static extern int SelectEvents(IntPtr dpy, IntPtr win, [In] XIEventMask[] masks, int num_masks);

		// Token: 0x060004EC RID: 1260
		[DllImport("libXi", EntryPoint = "XISelectEvents")]
		private static extern int SelectEvents(IntPtr dpy, IntPtr win, [In] ref XIEventMask masks, int num_masks);

		// Token: 0x060004ED RID: 1261 RVA: 0x00014834 File Offset: 0x00012A34
		public static int SelectEvents(IntPtr dpy, IntPtr win, XIEventMask[] masks)
		{
			return XI.SelectEvents(dpy, win, masks, masks.Length);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00014844 File Offset: 0x00012A44
		public static int SelectEvents(IntPtr dpy, IntPtr win, XIEventMask mask)
		{
			return XI.SelectEvents(dpy, win, ref mask, 1);
		}

		// Token: 0x060004EF RID: 1263
		[DllImport("libXi", EntryPoint = "XIGrabDevice")]
		private static extern ErrorCodes GrabDevice(IntPtr display, int deviceid, IntPtr grab_window, IntPtr time, IntPtr cursor, int grab_mode, int paired_device_mode, bool owner_events, XIEventMask[] mask);

		// Token: 0x060004F0 RID: 1264
		[DllImport("libXi", EntryPoint = "XIUngrabDevice")]
		private static extern ErrorCodes UngrabDevice(IntPtr display, int deviceid, IntPtr time);

		// Token: 0x060004F1 RID: 1265
		[DllImport("libXi")]
		public static extern bool XIWarpPointer(IntPtr display, int deviceid, IntPtr src_w, IntPtr dest_w, double src_x, double src_y, int src_width, int src_height, double dest_x, double dest_y);

		// Token: 0x060004F2 RID: 1266
		[DllImport("libXi", EntryPoint = "XIQueryDevice")]
		public static extern IntPtr QueryDevice(IntPtr display, int id, out int count);

		// Token: 0x060004F3 RID: 1267
		[DllImport("libXi", EntryPoint = "XIFreeDeviceInfo")]
		public static extern void FreeDeviceInfo(IntPtr devices);

		// Token: 0x060004F4 RID: 1268
		[DllImport("libXi", EntryPoint = "XIQueryPointer")]
		public static extern bool QueryPointer(IntPtr display, int deviceid, IntPtr win, out IntPtr root_return, out IntPtr child_return, out double root_x_return, out double root_y_return, out double win_x_return, out double win_y_return, out XIButtonState buttons_return, out XIModifierState modifiers_return, out XIGroupState group_return);

		// Token: 0x060004F5 RID: 1269
		[DllImport("libXi", EntryPoint = "XIQueryVersion")]
		internal static extern ErrorCodes QueryVersion(IntPtr display, ref int major, ref int minor);

		// Token: 0x0400011B RID: 283
		private const string lib = "libXi";

		// Token: 0x0400011C RID: 284
		internal const int XIAllDevices = 0;

		// Token: 0x0400011D RID: 285
		internal const int XIAllMasterDevices = 1;

		// Token: 0x0400011E RID: 286
		internal static readonly IntPtr ButtonLeft = Functions.XInternAtom(API.DefaultDisplay, "Button Left", false);

		// Token: 0x0400011F RID: 287
		internal static readonly IntPtr ButtonMiddle = Functions.XInternAtom(API.DefaultDisplay, "Button Middle", false);

		// Token: 0x04000120 RID: 288
		internal static readonly IntPtr ButtonRight = Functions.XInternAtom(API.DefaultDisplay, "Button Right", false);

		// Token: 0x04000121 RID: 289
		internal static readonly IntPtr ButtonWheelUp = Functions.XInternAtom(API.DefaultDisplay, "Button Wheel Up", false);

		// Token: 0x04000122 RID: 290
		internal static readonly IntPtr ButtonWheelDown = Functions.XInternAtom(API.DefaultDisplay, "Button Wheel Down", false);

		// Token: 0x04000123 RID: 291
		internal static readonly IntPtr ButtonWheelLeft = Functions.XInternAtom(API.DefaultDisplay, "Button Horiz Wheel Left", false);

		// Token: 0x04000124 RID: 292
		internal static readonly IntPtr ButtonWheelRight = Functions.XInternAtom(API.DefaultDisplay, "Button Horiz Wheel Right", false);

		// Token: 0x04000125 RID: 293
		internal static readonly IntPtr RelativeX = Functions.XInternAtom(API.DefaultDisplay, "Rel X", false);

		// Token: 0x04000126 RID: 294
		internal static readonly IntPtr RelativeY = Functions.XInternAtom(API.DefaultDisplay, "Rel Y", false);

		// Token: 0x04000127 RID: 295
		internal static readonly IntPtr RelativeHWheel = Functions.XInternAtom(API.DefaultDisplay, "Rel Horiz Wheel", false);

		// Token: 0x04000128 RID: 296
		internal static readonly IntPtr RelativeVWheel = Functions.XInternAtom(API.DefaultDisplay, "Rel Vert Wheel", false);

		// Token: 0x04000129 RID: 297
		internal static readonly IntPtr RelativeHScroll = Functions.XInternAtom(API.DefaultDisplay, "Rel Horiz Scroll", false);

		// Token: 0x0400012A RID: 298
		internal static readonly IntPtr RelativeVScroll = Functions.XInternAtom(API.DefaultDisplay, "Rel Vert Scroll", false);

		// Token: 0x0400012B RID: 299
		internal static readonly IntPtr TouchX = Functions.XInternAtom(API.DefaultDisplay, "Abs MT Position X", false);

		// Token: 0x0400012C RID: 300
		internal static readonly IntPtr TouchY = Functions.XInternAtom(API.DefaultDisplay, "Abs MT Position Y", false);

		// Token: 0x0400012D RID: 301
		internal static readonly IntPtr TouchMajor = Functions.XInternAtom(API.DefaultDisplay, "Abs MT Touch Major", false);

		// Token: 0x0400012E RID: 302
		internal static readonly IntPtr TouchMinor = Functions.XInternAtom(API.DefaultDisplay, "Abs MT Touch Minor", false);

		// Token: 0x0400012F RID: 303
		internal static readonly IntPtr TouchPressure = Functions.XInternAtom(API.DefaultDisplay, "Abs MT Pressure", false);

		// Token: 0x04000130 RID: 304
		internal static readonly IntPtr TouchId = Functions.XInternAtom(API.DefaultDisplay, "Abs MT Tracking ID", false);

		// Token: 0x04000131 RID: 305
		internal static readonly IntPtr TouchMaxContacts = Functions.XInternAtom(API.DefaultDisplay, "Max Contacts", false);

		// Token: 0x04000132 RID: 306
		internal static readonly IntPtr AbsoluteX = Functions.XInternAtom(API.DefaultDisplay, "Abs X", false);

		// Token: 0x04000133 RID: 307
		internal static readonly IntPtr AbsoluteY = Functions.XInternAtom(API.DefaultDisplay, "Abs Y", false);

		// Token: 0x04000134 RID: 308
		internal static readonly IntPtr AbsolutePressure = Functions.XInternAtom(API.DefaultDisplay, "Abs Pressure", false);

		// Token: 0x04000135 RID: 309
		internal static readonly IntPtr AbsoluteTiltX = Functions.XInternAtom(API.DefaultDisplay, "Abs Tilt X", false);

		// Token: 0x04000136 RID: 310
		internal static readonly IntPtr AbsoluteTiltY = Functions.XInternAtom(API.DefaultDisplay, "Abs Tilt Y", false);

		// Token: 0x04000137 RID: 311
		internal static readonly IntPtr AbsoluteWheel = Functions.XInternAtom(API.DefaultDisplay, "Abs Wheel", false);

		// Token: 0x04000138 RID: 312
		internal static readonly IntPtr AbsoluteDistance = Functions.XInternAtom(API.DefaultDisplay, "Abs Distance", false);
	}
}
