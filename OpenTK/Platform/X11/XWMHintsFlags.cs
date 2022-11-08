using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000184 RID: 388
	[Flags]
	internal enum XWMHintsFlags
	{
		// Token: 0x04000FF9 RID: 4089
		InputHint = 1,
		// Token: 0x04000FFA RID: 4090
		StateHint = 2,
		// Token: 0x04000FFB RID: 4091
		IconPixmapHint = 4,
		// Token: 0x04000FFC RID: 4092
		IconWindowHint = 8,
		// Token: 0x04000FFD RID: 4093
		IconPositionHint = 16,
		// Token: 0x04000FFE RID: 4094
		IconMaskHint = 32,
		// Token: 0x04000FFF RID: 4095
		WindowGroupHint = 64,
		// Token: 0x04001000 RID: 4096
		AllHints = 127
	}
}
