using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005BA RID: 1466
	[Flags]
	internal enum Keymod : ushort
	{
		// Token: 0x040053AB RID: 21419
		NONE = 0,
		// Token: 0x040053AC RID: 21420
		LSHIFT = 1,
		// Token: 0x040053AD RID: 21421
		RSHIFT = 2,
		// Token: 0x040053AE RID: 21422
		LCTRL = 64,
		// Token: 0x040053AF RID: 21423
		RCTRL = 128,
		// Token: 0x040053B0 RID: 21424
		LALT = 256,
		// Token: 0x040053B1 RID: 21425
		RALT = 512,
		// Token: 0x040053B2 RID: 21426
		LGUI = 1024,
		// Token: 0x040053B3 RID: 21427
		RGUI = 2048,
		// Token: 0x040053B4 RID: 21428
		NUM = 4096,
		// Token: 0x040053B5 RID: 21429
		CAPS = 8192,
		// Token: 0x040053B6 RID: 21430
		MODE = 16384,
		// Token: 0x040053B7 RID: 21431
		RESERVED = 32768,
		// Token: 0x040053B8 RID: 21432
		CTRL = 192,
		// Token: 0x040053B9 RID: 21433
		SHIFT = 3,
		// Token: 0x040053BA RID: 21434
		ALT = 768,
		// Token: 0x040053BB RID: 21435
		GUI = 3072
	}
}
