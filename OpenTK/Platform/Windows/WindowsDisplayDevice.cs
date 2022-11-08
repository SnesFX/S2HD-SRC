using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200008C RID: 140
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal class WindowsDisplayDevice
	{
		// Token: 0x06000832 RID: 2098 RVA: 0x0001A9D0 File Offset: 0x00018BD0
		internal WindowsDisplayDevice()
		{
			this.size = (int)((short)Marshal.SizeOf(this));
		}

		// Token: 0x04000365 RID: 869
		private readonly int size;

		// Token: 0x04000366 RID: 870
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		internal string DeviceName;

		// Token: 0x04000367 RID: 871
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		internal string DeviceString;

		// Token: 0x04000368 RID: 872
		internal DisplayDeviceStateFlags StateFlags;

		// Token: 0x04000369 RID: 873
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		internal string DeviceID;

		// Token: 0x0400036A RID: 874
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		internal string DeviceKey;
	}
}
