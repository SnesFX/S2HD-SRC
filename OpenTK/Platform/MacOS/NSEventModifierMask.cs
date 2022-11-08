using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B2A RID: 2858
	[Flags]
	internal enum NSEventModifierMask : uint
	{
		// Token: 0x0400B5CE RID: 46542
		AlphaShiftKeyMask = 65536U,
		// Token: 0x0400B5CF RID: 46543
		ShiftKeyMask = 131072U,
		// Token: 0x0400B5D0 RID: 46544
		ControlKeyMask = 262144U,
		// Token: 0x0400B5D1 RID: 46545
		AlternateKeyMask = 524288U,
		// Token: 0x0400B5D2 RID: 46546
		CommandKeyMask = 1048576U,
		// Token: 0x0400B5D3 RID: 46547
		NumericPadKeyMask = 2097152U,
		// Token: 0x0400B5D4 RID: 46548
		HelpKeyMask = 4194304U,
		// Token: 0x0400B5D5 RID: 46549
		FunctionKeyMask = 8388608U,
		// Token: 0x0400B5D6 RID: 46550
		DeviceIndependentModifierFlagsMask = 4294901760U
	}
}
