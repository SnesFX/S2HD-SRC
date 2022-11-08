using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B4E RID: 2894
	internal class Xkb
	{
		// Token: 0x06005B15 RID: 23317
		[DllImport("libX11", EntryPoint = "XkbFreeKeyboard")]
		internal unsafe static extern void FreeKeyboard(XkbDesc* descr, int which, bool free);

		// Token: 0x06005B16 RID: 23318
		[DllImport("libX11", EntryPoint = "XkbAllocKeyboard")]
		internal unsafe static extern XkbDesc* AllocKeyboard(IntPtr display);

		// Token: 0x06005B17 RID: 23319
		[DllImport("libX11", EntryPoint = "XkbGetKeyboard")]
		internal static extern IntPtr GetKeyboard(IntPtr display, XkbKeyboardMask which, int device_id);

		// Token: 0x06005B18 RID: 23320
		[DllImport("libX11", EntryPoint = "XkbGetMap")]
		internal static extern IntPtr GetMap(IntPtr display, XkbKeyboardMask which, int device_spec);

		// Token: 0x06005B19 RID: 23321
		[DllImport("libX11", EntryPoint = "XkbGetNames")]
		internal unsafe static extern IntPtr GetNames(IntPtr display, XkbNamesMask which, XkbDesc* xkb);

		// Token: 0x06005B1A RID: 23322
		[DllImport("libX11", EntryPoint = "XkbKeycodeToKeysym")]
		internal static extern XKey KeycodeToKeysym(IntPtr display, int keycode, int group, int level);

		// Token: 0x06005B1B RID: 23323
		[DllImport("libX11", EntryPoint = "XkbQueryExtension")]
		internal static extern bool QueryExtension(IntPtr display, out int opcode_rtrn, out int event_rtrn, out int error_rtrn, ref int major_in_out, ref int minor_in_out);

		// Token: 0x06005B1C RID: 23324
		[DllImport("libX11", EntryPoint = "XkbSetDetectableAutoRepeat")]
		internal static extern bool SetDetectableAutoRepeat(IntPtr display, bool detectable, out bool supported);

		// Token: 0x06005B1D RID: 23325 RVA: 0x000F69FC File Offset: 0x000F4BFC
		internal static bool IsSupported(IntPtr display)
		{
			int num = 1;
			int num2 = 0;
			int num3;
			int num4;
			int num5;
			return Xkb.QueryExtension(display, out num3, out num4, out num5, ref num, ref num2);
		}

		// Token: 0x0400B740 RID: 46912
		private const string lib = "libX11";

		// Token: 0x0400B741 RID: 46913
		internal const int KeyNameLength = 4;

		// Token: 0x0400B742 RID: 46914
		internal const int NumModifiers = 8;

		// Token: 0x0400B743 RID: 46915
		internal const int NumVirtualMods = 16;

		// Token: 0x0400B744 RID: 46916
		internal const int NumIndicators = 32;

		// Token: 0x0400B745 RID: 46917
		internal const int NumKbdGroups = 4;

		// Token: 0x0400B746 RID: 46918
		internal const int UseCoreKeyboard = 256;
	}
}
