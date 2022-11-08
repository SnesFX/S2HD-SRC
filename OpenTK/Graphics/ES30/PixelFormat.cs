using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x0200087C RID: 2172
	public enum PixelFormat
	{
		// Token: 0x04008B10 RID: 35600
		UnsignedShort = 5123,
		// Token: 0x04008B11 RID: 35601
		UnsignedInt = 5125,
		// Token: 0x04008B12 RID: 35602
		ColorIndex = 6400,
		// Token: 0x04008B13 RID: 35603
		StencilIndex,
		// Token: 0x04008B14 RID: 35604
		DepthComponent,
		// Token: 0x04008B15 RID: 35605
		Red,
		// Token: 0x04008B16 RID: 35606
		RedExt = 6403,
		// Token: 0x04008B17 RID: 35607
		Green,
		// Token: 0x04008B18 RID: 35608
		Blue,
		// Token: 0x04008B19 RID: 35609
		Alpha,
		// Token: 0x04008B1A RID: 35610
		Rgb,
		// Token: 0x04008B1B RID: 35611
		Rgba,
		// Token: 0x04008B1C RID: 35612
		Luminance,
		// Token: 0x04008B1D RID: 35613
		LuminanceAlpha,
		// Token: 0x04008B1E RID: 35614
		R = 8194,
		// Token: 0x04008B1F RID: 35615
		AbgrExt = 32768,
		// Token: 0x04008B20 RID: 35616
		CmykExt = 32780,
		// Token: 0x04008B21 RID: 35617
		CmykaExt,
		// Token: 0x04008B22 RID: 35618
		Ycrcb422Sgix = 33211,
		// Token: 0x04008B23 RID: 35619
		Ycrcb444Sgix,
		// Token: 0x04008B24 RID: 35620
		Rg = 33319,
		// Token: 0x04008B25 RID: 35621
		RgInteger,
		// Token: 0x04008B26 RID: 35622
		DepthStencil = 34041,
		// Token: 0x04008B27 RID: 35623
		RedInteger = 36244,
		// Token: 0x04008B28 RID: 35624
		RgbInteger = 36248,
		// Token: 0x04008B29 RID: 35625
		RgbaInteger
	}
}
