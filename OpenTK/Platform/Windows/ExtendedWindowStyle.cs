using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000B1 RID: 177
	[Flags]
	internal enum ExtendedWindowStyle : uint
	{
		// Token: 0x04000450 RID: 1104
		DialogModalFrame = 1U,
		// Token: 0x04000451 RID: 1105
		NoParentNotify = 4U,
		// Token: 0x04000452 RID: 1106
		Topmost = 8U,
		// Token: 0x04000453 RID: 1107
		AcceptFiles = 16U,
		// Token: 0x04000454 RID: 1108
		Transparent = 32U,
		// Token: 0x04000455 RID: 1109
		MdiChild = 64U,
		// Token: 0x04000456 RID: 1110
		ToolWindow = 128U,
		// Token: 0x04000457 RID: 1111
		WindowEdge = 256U,
		// Token: 0x04000458 RID: 1112
		ClientEdge = 512U,
		// Token: 0x04000459 RID: 1113
		ContextHelp = 1024U,
		// Token: 0x0400045A RID: 1114
		Right = 4096U,
		// Token: 0x0400045B RID: 1115
		Left = 0U,
		// Token: 0x0400045C RID: 1116
		RightToLeftReading = 8192U,
		// Token: 0x0400045D RID: 1117
		LeftToRightReading = 0U,
		// Token: 0x0400045E RID: 1118
		LeftScrollbar = 16384U,
		// Token: 0x0400045F RID: 1119
		RightScrollbar = 0U,
		// Token: 0x04000460 RID: 1120
		ControlParent = 65536U,
		// Token: 0x04000461 RID: 1121
		StaticEdge = 131072U,
		// Token: 0x04000462 RID: 1122
		ApplicationWindow = 262144U,
		// Token: 0x04000463 RID: 1123
		OverlappedWindow = 768U,
		// Token: 0x04000464 RID: 1124
		PaletteWindow = 392U,
		// Token: 0x04000465 RID: 1125
		Layered = 524288U,
		// Token: 0x04000466 RID: 1126
		NoInheritLayout = 1048576U,
		// Token: 0x04000467 RID: 1127
		RightToLeftLayout = 4194304U,
		// Token: 0x04000468 RID: 1128
		Composited = 33554432U,
		// Token: 0x04000469 RID: 1129
		NoActivate = 134217728U
	}
}
