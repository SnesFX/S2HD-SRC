using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000AEC RID: 2796
	public enum TextureMinFilter
	{
		// Token: 0x0400B2B1 RID: 45745
		Nearest = 9728,
		// Token: 0x0400B2B2 RID: 45746
		Linear,
		// Token: 0x0400B2B3 RID: 45747
		NearestMipmapNearest = 9984,
		// Token: 0x0400B2B4 RID: 45748
		LinearMipmapNearest,
		// Token: 0x0400B2B5 RID: 45749
		NearestMipmapLinear,
		// Token: 0x0400B2B6 RID: 45750
		LinearMipmapLinear,
		// Token: 0x0400B2B7 RID: 45751
		Filter4Sgis = 33094,
		// Token: 0x0400B2B8 RID: 45752
		LinearClipmapLinearSgix = 33136,
		// Token: 0x0400B2B9 RID: 45753
		PixelTexGenQCeilingSgix = 33156,
		// Token: 0x0400B2BA RID: 45754
		PixelTexGenQRoundSgix,
		// Token: 0x0400B2BB RID: 45755
		PixelTexGenQFloorSgix,
		// Token: 0x0400B2BC RID: 45756
		NearestClipmapNearestSgix = 33869,
		// Token: 0x0400B2BD RID: 45757
		NearestClipmapLinearSgix,
		// Token: 0x0400B2BE RID: 45758
		LinearClipmapNearestSgix
	}
}
