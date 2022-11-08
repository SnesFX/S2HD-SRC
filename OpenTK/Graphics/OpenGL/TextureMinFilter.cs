using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000484 RID: 1156
	public enum TextureMinFilter
	{
		// Token: 0x040042A6 RID: 17062
		Nearest = 9728,
		// Token: 0x040042A7 RID: 17063
		Linear,
		// Token: 0x040042A8 RID: 17064
		NearestMipmapNearest = 9984,
		// Token: 0x040042A9 RID: 17065
		LinearMipmapNearest,
		// Token: 0x040042AA RID: 17066
		NearestMipmapLinear,
		// Token: 0x040042AB RID: 17067
		LinearMipmapLinear,
		// Token: 0x040042AC RID: 17068
		Filter4Sgis = 33094,
		// Token: 0x040042AD RID: 17069
		LinearClipmapLinearSgix = 33136,
		// Token: 0x040042AE RID: 17070
		PixelTexGenQCeilingSgix = 33156,
		// Token: 0x040042AF RID: 17071
		PixelTexGenQRoundSgix,
		// Token: 0x040042B0 RID: 17072
		PixelTexGenQFloorSgix,
		// Token: 0x040042B1 RID: 17073
		NearestClipmapNearestSgix = 33869,
		// Token: 0x040042B2 RID: 17074
		NearestClipmapLinearSgix,
		// Token: 0x040042B3 RID: 17075
		LinearClipmapNearestSgix
	}
}
