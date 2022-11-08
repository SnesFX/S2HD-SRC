using System;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000A00 RID: 2560
	public enum TextureMinFilter
	{
		// Token: 0x0400A398 RID: 41880
		Nearest = 9728,
		// Token: 0x0400A399 RID: 41881
		Linear,
		// Token: 0x0400A39A RID: 41882
		NearestMipmapNearest = 9984,
		// Token: 0x0400A39B RID: 41883
		LinearMipmapNearest,
		// Token: 0x0400A39C RID: 41884
		NearestMipmapLinear,
		// Token: 0x0400A39D RID: 41885
		LinearMipmapLinear,
		// Token: 0x0400A39E RID: 41886
		Filter4Sgis = 33094,
		// Token: 0x0400A39F RID: 41887
		LinearClipmapLinearSgix = 33136,
		// Token: 0x0400A3A0 RID: 41888
		PixelTexGenQCeilingSgix = 33156,
		// Token: 0x0400A3A1 RID: 41889
		PixelTexGenQRoundSgix,
		// Token: 0x0400A3A2 RID: 41890
		PixelTexGenQFloorSgix,
		// Token: 0x0400A3A3 RID: 41891
		NearestClipmapNearestSgix = 33869,
		// Token: 0x0400A3A4 RID: 41892
		NearestClipmapLinearSgix,
		// Token: 0x0400A3A5 RID: 41893
		LinearClipmapNearestSgix
	}
}
