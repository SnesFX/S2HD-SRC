using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000EB RID: 235
	public enum ArbCreateContext
	{
		// Token: 0x040007AC RID: 1964
		CoreProfileBit = 1,
		// Token: 0x040007AD RID: 1965
		CompatibilityProfileBit,
		// Token: 0x040007AE RID: 1966
		DebugBit = 1,
		// Token: 0x040007AF RID: 1967
		ForwardCompatibleBit,
		// Token: 0x040007B0 RID: 1968
		MajorVersion = 8337,
		// Token: 0x040007B1 RID: 1969
		MinorVersion,
		// Token: 0x040007B2 RID: 1970
		LayerPlane,
		// Token: 0x040007B3 RID: 1971
		ContextFlags,
		// Token: 0x040007B4 RID: 1972
		ErrorInvalidVersion,
		// Token: 0x040007B5 RID: 1973
		ProfileMask = 37158
	}
}
