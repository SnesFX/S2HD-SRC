using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200009A RID: 154
	[StructLayout(LayoutKind.Sequential)]
	internal class RawInputDeviceInfo
	{
		// Token: 0x040003BD RID: 957
		private int Size = Marshal.SizeOf(typeof(RawInputDeviceInfo));

		// Token: 0x040003BE RID: 958
		internal RawInputDeviceType Type;

		// Token: 0x040003BF RID: 959
		internal RawInputDeviceInfo.DeviceStruct Device;

		// Token: 0x0200009B RID: 155
		[StructLayout(LayoutKind.Explicit)]
		internal struct DeviceStruct
		{
			// Token: 0x040003C0 RID: 960
			[FieldOffset(0)]
			internal RawInputMouseDeviceInfo Mouse;

			// Token: 0x040003C1 RID: 961
			[FieldOffset(0)]
			internal RawInputKeyboardDeviceInfo Keyboard;

			// Token: 0x040003C2 RID: 962
			[FieldOffset(0)]
			internal RawInputHIDDeviceInfo HID;
		}
	}
}
