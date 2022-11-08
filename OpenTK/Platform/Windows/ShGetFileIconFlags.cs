using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000C8 RID: 200
	[Flags]
	internal enum ShGetFileIconFlags
	{
		// Token: 0x040006AA RID: 1706
		Icon = 256,
		// Token: 0x040006AB RID: 1707
		DisplayName = 512,
		// Token: 0x040006AC RID: 1708
		TypeName = 1024,
		// Token: 0x040006AD RID: 1709
		Attributes = 2048,
		// Token: 0x040006AE RID: 1710
		IconLocation = 4096,
		// Token: 0x040006AF RID: 1711
		ExeType = 8192,
		// Token: 0x040006B0 RID: 1712
		SysIconIndex = 16384,
		// Token: 0x040006B1 RID: 1713
		LinkOverlay = 32768,
		// Token: 0x040006B2 RID: 1714
		Selected = 65536,
		// Token: 0x040006B3 RID: 1715
		Attr_Specified = 131072,
		// Token: 0x040006B4 RID: 1716
		LargeIcon = 0,
		// Token: 0x040006B5 RID: 1717
		SmallIcon = 1,
		// Token: 0x040006B6 RID: 1718
		OpenIcon = 2,
		// Token: 0x040006B7 RID: 1719
		ShellIconSize = 4,
		// Token: 0x040006B8 RID: 1720
		PIDL = 8,
		// Token: 0x040006B9 RID: 1721
		UseFileAttributes = 16,
		// Token: 0x040006BA RID: 1722
		AddOverlays = 32,
		// Token: 0x040006BB RID: 1723
		OverlayIndex = 64
	}
}
