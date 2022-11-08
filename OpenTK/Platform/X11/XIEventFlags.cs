using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x020001A1 RID: 417
	[Flags]
	internal enum XIEventFlags
	{
		// Token: 0x04001132 RID: 4402
		KeyRepeat = 65536,
		// Token: 0x04001133 RID: 4403
		PointerEmulated = 65536,
		// Token: 0x04001134 RID: 4404
		TouchPendingEnd = 65536,
		// Token: 0x04001135 RID: 4405
		TouchEmulatingPointer = 131072
	}
}
