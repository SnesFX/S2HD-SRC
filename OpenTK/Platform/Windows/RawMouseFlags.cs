using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000BD RID: 189
	[Flags]
	internal enum RawMouseFlags : ushort
	{
		// Token: 0x040004CC RID: 1228
		MOUSE_MOVE_RELATIVE = 0,
		// Token: 0x040004CD RID: 1229
		MOUSE_MOVE_ABSOLUTE = 1,
		// Token: 0x040004CE RID: 1230
		MOUSE_VIRTUAL_DESKTOP = 2,
		// Token: 0x040004CF RID: 1231
		MOUSE_ATTRIBUTES_CHANGED = 4
	}
}
