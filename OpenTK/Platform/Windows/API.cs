using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000080 RID: 128
	internal static class API
	{
		// Token: 0x060007A9 RID: 1961 RVA: 0x0001A7E0 File Offset: 0x000189E0
		static API()
		{
			API.RawInputSize = Marshal.SizeOf(typeof(RawInput));
			API.RawMouseSize = Marshal.SizeOf(typeof(RawMouse));
			API.RawInputDeviceSize = Marshal.SizeOf(typeof(RawInputDevice));
			API.RawInputDeviceListSize = Marshal.SizeOf(typeof(RawInputDeviceList));
			API.RawInputDeviceInfoSize = Marshal.SizeOf(typeof(RawInputDeviceInfo));
			API.PixelFormatDescriptorVersion = 1;
			API.PixelFormatDescriptorSize = (short)Marshal.SizeOf(typeof(PixelFormatDescriptor));
			API.WindowInfoSize = Marshal.SizeOf(typeof(WindowInfo));
		}

		// Token: 0x040002B1 RID: 689
		internal static readonly short PixelFormatDescriptorSize;

		// Token: 0x040002B2 RID: 690
		internal static readonly short PixelFormatDescriptorVersion;

		// Token: 0x040002B3 RID: 691
		internal static readonly int RawInputSize;

		// Token: 0x040002B4 RID: 692
		internal static readonly int RawInputDeviceSize;

		// Token: 0x040002B5 RID: 693
		internal static readonly int RawInputHeaderSize = Marshal.SizeOf(typeof(RawInputHeader));

		// Token: 0x040002B6 RID: 694
		internal static readonly int RawInputDeviceListSize;

		// Token: 0x040002B7 RID: 695
		internal static readonly int RawInputDeviceInfoSize;

		// Token: 0x040002B8 RID: 696
		internal static readonly int RawMouseSize;

		// Token: 0x040002B9 RID: 697
		internal static readonly int WindowInfoSize;
	}
}
