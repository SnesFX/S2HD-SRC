using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000AE RID: 174
	[Flags]
	internal enum DisplayDeviceStateFlags
	{
		// Token: 0x04000423 RID: 1059
		None = 0,
		// Token: 0x04000424 RID: 1060
		AttachedToDesktop = 1,
		// Token: 0x04000425 RID: 1061
		MultiDriver = 2,
		// Token: 0x04000426 RID: 1062
		PrimaryDevice = 4,
		// Token: 0x04000427 RID: 1063
		MirroringDriver = 8,
		// Token: 0x04000428 RID: 1064
		VgaCompatible = 16,
		// Token: 0x04000429 RID: 1065
		Removable = 32,
		// Token: 0x0400042A RID: 1066
		ModesPruned = 134217728,
		// Token: 0x0400042B RID: 1067
		Remote = 67108864,
		// Token: 0x0400042C RID: 1068
		Disconnect = 33554432,
		// Token: 0x0400042D RID: 1069
		Active = 1,
		// Token: 0x0400042E RID: 1070
		Attached = 2
	}
}
