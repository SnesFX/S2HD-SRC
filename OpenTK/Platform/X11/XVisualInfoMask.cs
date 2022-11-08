using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200012A RID: 298
	[Flags]
	internal enum XVisualInfoMask
	{
		// Token: 0x04000BC7 RID: 3015
		No = 0,
		// Token: 0x04000BC8 RID: 3016
		ID = 1,
		// Token: 0x04000BC9 RID: 3017
		Screen = 2,
		// Token: 0x04000BCA RID: 3018
		Depth = 4,
		// Token: 0x04000BCB RID: 3019
		Class = 8,
		// Token: 0x04000BCC RID: 3020
		Red = 16,
		// Token: 0x04000BCD RID: 3021
		Green = 32,
		// Token: 0x04000BCE RID: 3022
		Blue = 64,
		// Token: 0x04000BCF RID: 3023
		ColormapSize = 128,
		// Token: 0x04000BD0 RID: 3024
		BitsPerRGB = 256,
		// Token: 0x04000BD1 RID: 3025
		All = 511
	}
}
