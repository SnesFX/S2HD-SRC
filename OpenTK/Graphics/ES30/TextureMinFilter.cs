using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020008B7 RID: 2231
	public enum TextureMinFilter
	{
		// Token: 0x04008E57 RID: 36439
		Nearest = 9728,
		// Token: 0x04008E58 RID: 36440
		Linear,
		// Token: 0x04008E59 RID: 36441
		NearestMipmapNearest = 9984,
		// Token: 0x04008E5A RID: 36442
		LinearMipmapNearest,
		// Token: 0x04008E5B RID: 36443
		NearestMipmapLinear,
		// Token: 0x04008E5C RID: 36444
		LinearMipmapLinear,
		// Token: 0x04008E5D RID: 36445
		Filter4Sgis = 33094,
		// Token: 0x04008E5E RID: 36446
		LinearClipmapLinearSgix = 33136,
		// Token: 0x04008E5F RID: 36447
		PixelTexGenQCeilingSgix = 33156,
		// Token: 0x04008E60 RID: 36448
		PixelTexGenQRoundSgix,
		// Token: 0x04008E61 RID: 36449
		PixelTexGenQFloorSgix,
		// Token: 0x04008E62 RID: 36450
		NearestClipmapNearestSgix = 33869,
		// Token: 0x04008E63 RID: 36451
		NearestClipmapLinearSgix,
		// Token: 0x04008E64 RID: 36452
		LinearClipmapNearestSgix
	}
}
