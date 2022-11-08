using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000B0 RID: 176
	[Flags]
	internal enum WindowStyle : uint
	{
		// Token: 0x04000434 RID: 1076
		Overlapped = 0U,
		// Token: 0x04000435 RID: 1077
		Popup = 2147483648U,
		// Token: 0x04000436 RID: 1078
		Child = 1073741824U,
		// Token: 0x04000437 RID: 1079
		Minimize = 536870912U,
		// Token: 0x04000438 RID: 1080
		Visible = 268435456U,
		// Token: 0x04000439 RID: 1081
		Disabled = 134217728U,
		// Token: 0x0400043A RID: 1082
		ClipSiblings = 67108864U,
		// Token: 0x0400043B RID: 1083
		ClipChildren = 33554432U,
		// Token: 0x0400043C RID: 1084
		Maximize = 16777216U,
		// Token: 0x0400043D RID: 1085
		Caption = 12582912U,
		// Token: 0x0400043E RID: 1086
		Border = 8388608U,
		// Token: 0x0400043F RID: 1087
		DialogFrame = 4194304U,
		// Token: 0x04000440 RID: 1088
		VScroll = 2097152U,
		// Token: 0x04000441 RID: 1089
		HScreen = 1048576U,
		// Token: 0x04000442 RID: 1090
		SystemMenu = 524288U,
		// Token: 0x04000443 RID: 1091
		ThickFrame = 262144U,
		// Token: 0x04000444 RID: 1092
		Group = 131072U,
		// Token: 0x04000445 RID: 1093
		TabStop = 65536U,
		// Token: 0x04000446 RID: 1094
		MinimizeBox = 131072U,
		// Token: 0x04000447 RID: 1095
		MaximizeBox = 65536U,
		// Token: 0x04000448 RID: 1096
		Tiled = 0U,
		// Token: 0x04000449 RID: 1097
		Iconic = 536870912U,
		// Token: 0x0400044A RID: 1098
		SizeBox = 262144U,
		// Token: 0x0400044B RID: 1099
		TiledWindow = 13565952U,
		// Token: 0x0400044C RID: 1100
		OverlappedWindow = 13565952U,
		// Token: 0x0400044D RID: 1101
		PopupWindow = 2156396544U,
		// Token: 0x0400044E RID: 1102
		ChildWindow = 1073741824U
	}
}
