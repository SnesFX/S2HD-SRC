using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000A6 RID: 166
	internal struct BroadcastDeviceInterface
	{
		// Token: 0x040003F6 RID: 1014
		public int Size;

		// Token: 0x040003F7 RID: 1015
		public DeviceBroadcastType DeviceType;

		// Token: 0x040003F8 RID: 1016
		private int dbcc_reserved;

		// Token: 0x040003F9 RID: 1017
		public Guid ClassGuid;

		// Token: 0x040003FA RID: 1018
		public char dbcc_name;
	}
}
