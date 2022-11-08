using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000A5 RID: 165
	internal struct BroadcastHeader
	{
		// Token: 0x040003F3 RID: 1011
		public int Size;

		// Token: 0x040003F4 RID: 1012
		public DeviceBroadcastType DeviceType;

		// Token: 0x040003F5 RID: 1013
		private int dbch_reserved;
	}
}
