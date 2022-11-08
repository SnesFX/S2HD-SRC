using System;
using System.Runtime.InteropServices;
using OpenTK.Platform.MacOS.Carbon;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B3E RID: 2878
	internal class CG
	{
		// Token: 0x06005ADA RID: 23258
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGEventTapCreate")]
		public static extern IntPtr EventTapCreate(CGEventTapLocation tap, CGEventTapPlacement place, CGEventTapOptions options, CGEventMask eventsOfInterest, [MarshalAs(UnmanagedType.FunctionPtr)] CG.EventTapCallBack callback, IntPtr refcon);

		// Token: 0x06005ADB RID: 23259
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGEventGetDoubleValueField")]
		internal static extern double EventGetDoubleValueField(IntPtr @event, CGEventField field);

		// Token: 0x06005ADC RID: 23260
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGEventGetIntegerValueField")]
		internal static extern int EventGetIntegerValueField(IntPtr @event, CGEventField field);

		// Token: 0x06005ADD RID: 23261
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGEventGetLocation")]
		internal static extern HIPoint EventGetLocation(IntPtr @event);

		// Token: 0x06005ADE RID: 23262
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGGetActiveDisplayList")]
		internal unsafe static extern CGDisplayErr GetActiveDisplayList(int maxDisplays, IntPtr* activeDspys, out int dspyCnt);

		// Token: 0x06005ADF RID: 23263
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGMainDisplayID")]
		internal static extern IntPtr MainDisplayID();

		// Token: 0x06005AE0 RID: 23264 RVA: 0x000F68B0 File Offset: 0x000F4AB0
		internal static HIRect DisplayBounds(IntPtr display)
		{
			HIRect result;
			CG.DisplayBounds(out result, display);
			return result;
		}

		// Token: 0x06005AE1 RID: 23265
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayBounds")]
		private static extern void DisplayBounds(out HIRect rect, IntPtr display);

		// Token: 0x06005AE2 RID: 23266
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayPixelsWide")]
		internal static extern int DisplayPixelsWide(IntPtr display);

		// Token: 0x06005AE3 RID: 23267
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayPixelsHigh")]
		internal static extern int DisplayPixelsHigh(IntPtr display);

		// Token: 0x06005AE4 RID: 23268
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayCurrentMode")]
		internal static extern IntPtr DisplayCurrentMode(IntPtr display);

		// Token: 0x06005AE5 RID: 23269
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayCapture")]
		internal static extern CGDisplayErr DisplayCapture(IntPtr display);

		// Token: 0x06005AE6 RID: 23270
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGCaptureAllDisplays")]
		internal static extern CGDisplayErr CaptureAllDisplays();

		// Token: 0x06005AE7 RID: 23271
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGShieldingWindowLevel")]
		internal static extern uint ShieldingWindowLevel();

		// Token: 0x06005AE8 RID: 23272
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayRelease")]
		internal static extern CGDisplayErr DisplayRelease(IntPtr display);

		// Token: 0x06005AE9 RID: 23273
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGReleaseAllDisplays")]
		internal static extern CGDisplayErr DisplayReleaseAll();

		// Token: 0x06005AEA RID: 23274
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayAvailableModes")]
		internal static extern IntPtr DisplayAvailableModes(IntPtr display);

		// Token: 0x06005AEB RID: 23275
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplaySwitchToMode")]
		internal static extern IntPtr DisplaySwitchToMode(IntPtr display, IntPtr displayMode);

		// Token: 0x06005AEC RID: 23276
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGWarpMouseCursorPosition")]
		internal static extern CGError WarpMouseCursorPosition(HIPoint newCursorPosition);

		// Token: 0x06005AED RID: 23277
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGCursorIsVisible")]
		internal static extern bool CursorIsVisible();

		// Token: 0x06005AEE RID: 23278
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayShowCursor")]
		internal static extern CGError DisplayShowCursor(IntPtr display);

		// Token: 0x06005AEF RID: 23279
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGDisplayHideCursor")]
		internal static extern CGError DisplayHideCursor(IntPtr display);

		// Token: 0x06005AF0 RID: 23280
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGAssociateMouseAndMouseCursorPosition")]
		internal static extern CGError AssociateMouseAndMouseCursorPosition(bool connected);

		// Token: 0x06005AF1 RID: 23281
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CGSetLocalEventsSuppressionInterval")]
		internal static extern CGError SetLocalEventsSuppressionInterval(double seconds);

		// Token: 0x0400B6A1 RID: 46753
		private const string lib = "/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices";

		// Token: 0x02000B3F RID: 2879
		// (Invoke) Token: 0x06005AF4 RID: 23284
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr EventTapCallBack(IntPtr proxy, CGEventType type, IntPtr @event, IntPtr refcon);
	}
}
