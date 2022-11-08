using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000BB RID: 187
	internal enum RawInputKeyboardDataFlags : short
	{
		// Token: 0x040004C1 RID: 1217
		MAKE,
		// Token: 0x040004C2 RID: 1218
		BREAK,
		// Token: 0x040004C3 RID: 1219
		E0,
		// Token: 0x040004C4 RID: 1220
		E1 = 4,
		// Token: 0x040004C5 RID: 1221
		TERMSRV_SET_LED = 8,
		// Token: 0x040004C6 RID: 1222
		TERMSRV_SHADOW = 16
	}
}
