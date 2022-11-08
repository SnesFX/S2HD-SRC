using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000745 RID: 1861
	public enum TextureMinFilter
	{
		// Token: 0x04006EFE RID: 28414
		Nearest = 9728,
		// Token: 0x04006EFF RID: 28415
		Linear,
		// Token: 0x04006F00 RID: 28416
		NearestMipmapNearest = 9984,
		// Token: 0x04006F01 RID: 28417
		LinearMipmapNearest,
		// Token: 0x04006F02 RID: 28418
		NearestMipmapLinear,
		// Token: 0x04006F03 RID: 28419
		LinearMipmapLinear,
		// Token: 0x04006F04 RID: 28420
		Filter4Sgis = 33094,
		// Token: 0x04006F05 RID: 28421
		LinearClipmapLinearSgix = 33136,
		// Token: 0x04006F06 RID: 28422
		PixelTexGenQCeilingSgix = 33156,
		// Token: 0x04006F07 RID: 28423
		PixelTexGenQRoundSgix,
		// Token: 0x04006F08 RID: 28424
		PixelTexGenQFloorSgix,
		// Token: 0x04006F09 RID: 28425
		NearestClipmapNearestSgix = 33869,
		// Token: 0x04006F0A RID: 28426
		NearestClipmapLinearSgix,
		// Token: 0x04006F0B RID: 28427
		LinearClipmapNearestSgix
	}
}
