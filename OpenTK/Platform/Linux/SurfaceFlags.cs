using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B77 RID: 2935
	[Flags]
	internal enum SurfaceFlags
	{
		// Token: 0x0400B883 RID: 47235
		Scanout = 1,
		// Token: 0x0400B884 RID: 47236
		Cursor64x64 = 2,
		// Token: 0x0400B885 RID: 47237
		Rendering = 4,
		// Token: 0x0400B886 RID: 47238
		Write = 8
	}
}
