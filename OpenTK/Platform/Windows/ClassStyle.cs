using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000B6 RID: 182
	[Flags]
	internal enum ClassStyle
	{
		// Token: 0x0400048E RID: 1166
		VRedraw = 1,
		// Token: 0x0400048F RID: 1167
		HRedraw = 2,
		// Token: 0x04000490 RID: 1168
		DoubleClicks = 8,
		// Token: 0x04000491 RID: 1169
		OwnDC = 32,
		// Token: 0x04000492 RID: 1170
		ClassDC = 64,
		// Token: 0x04000493 RID: 1171
		ParentDC = 128,
		// Token: 0x04000494 RID: 1172
		NoClose = 512,
		// Token: 0x04000495 RID: 1173
		SaveBits = 2048,
		// Token: 0x04000496 RID: 1174
		ByteAlignClient = 4096,
		// Token: 0x04000497 RID: 1175
		ByteAlignWindow = 8192,
		// Token: 0x04000498 RID: 1176
		GlobalClass = 16384,
		// Token: 0x04000499 RID: 1177
		Ime = 65536,
		// Token: 0x0400049A RID: 1178
		DropShadow = 131072
	}
}
