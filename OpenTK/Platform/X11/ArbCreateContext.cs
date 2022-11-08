using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x020001AD RID: 429
	internal enum ArbCreateContext
	{
		// Token: 0x040011EA RID: 4586
		DebugBit = 1,
		// Token: 0x040011EB RID: 4587
		ForwardCompatibleBit,
		// Token: 0x040011EC RID: 4588
		CoreProfileBit = 1,
		// Token: 0x040011ED RID: 4589
		CompatibilityProfileBit,
		// Token: 0x040011EE RID: 4590
		MajorVersion = 8337,
		// Token: 0x040011EF RID: 4591
		MinorVersion,
		// Token: 0x040011F0 RID: 4592
		LayerPlane,
		// Token: 0x040011F1 RID: 4593
		Flags,
		// Token: 0x040011F2 RID: 4594
		ErrorInvalidVersion,
		// Token: 0x040011F3 RID: 4595
		ProfileMask = 37158
	}
}
