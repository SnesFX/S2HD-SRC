using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000193 RID: 403
	internal struct XIScrollClassInfo
	{
		// Token: 0x040010C3 RID: 4291
		public XIClassType type;

		// Token: 0x040010C4 RID: 4292
		public int sourceid;

		// Token: 0x040010C5 RID: 4293
		public int number;

		// Token: 0x040010C6 RID: 4294
		public XIScrollType scroll_type;

		// Token: 0x040010C7 RID: 4295
		public double increment;

		// Token: 0x040010C8 RID: 4296
		public int flags;
	}
}
