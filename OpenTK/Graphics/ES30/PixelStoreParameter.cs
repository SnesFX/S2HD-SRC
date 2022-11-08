using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x0200087F RID: 2175
	public enum PixelStoreParameter
	{
		// Token: 0x04008B3C RID: 35644
		UnpackSwapBytes = 3312,
		// Token: 0x04008B3D RID: 35645
		UnpackLsbFirst,
		// Token: 0x04008B3E RID: 35646
		UnpackRowLength,
		// Token: 0x04008B3F RID: 35647
		UnpackRowLengthExt = 3314,
		// Token: 0x04008B40 RID: 35648
		UnpackSkipRows,
		// Token: 0x04008B41 RID: 35649
		UnpackSkipRowsExt = 3315,
		// Token: 0x04008B42 RID: 35650
		UnpackSkipPixels,
		// Token: 0x04008B43 RID: 35651
		UnpackSkipPixelsExt = 3316,
		// Token: 0x04008B44 RID: 35652
		UnpackAlignment,
		// Token: 0x04008B45 RID: 35653
		PackSwapBytes = 3328,
		// Token: 0x04008B46 RID: 35654
		PackLsbFirst,
		// Token: 0x04008B47 RID: 35655
		PackRowLength,
		// Token: 0x04008B48 RID: 35656
		PackSkipRows,
		// Token: 0x04008B49 RID: 35657
		PackSkipPixels,
		// Token: 0x04008B4A RID: 35658
		PackAlignment,
		// Token: 0x04008B4B RID: 35659
		PackSkipImages = 32875,
		// Token: 0x04008B4C RID: 35660
		PackSkipImagesExt = 32875,
		// Token: 0x04008B4D RID: 35661
		PackImageHeight,
		// Token: 0x04008B4E RID: 35662
		PackImageHeightExt = 32876,
		// Token: 0x04008B4F RID: 35663
		UnpackSkipImages,
		// Token: 0x04008B50 RID: 35664
		UnpackSkipImagesExt = 32877,
		// Token: 0x04008B51 RID: 35665
		UnpackImageHeight,
		// Token: 0x04008B52 RID: 35666
		UnpackImageHeightExt = 32878,
		// Token: 0x04008B53 RID: 35667
		PackSkipVolumesSgis = 33072,
		// Token: 0x04008B54 RID: 35668
		PackImageDepthSgis,
		// Token: 0x04008B55 RID: 35669
		UnpackSkipVolumesSgis,
		// Token: 0x04008B56 RID: 35670
		UnpackImageDepthSgis,
		// Token: 0x04008B57 RID: 35671
		PixelTileWidthSgix = 33088,
		// Token: 0x04008B58 RID: 35672
		PixelTileHeightSgix,
		// Token: 0x04008B59 RID: 35673
		PixelTileGridWidthSgix,
		// Token: 0x04008B5A RID: 35674
		PixelTileGridHeightSgix,
		// Token: 0x04008B5B RID: 35675
		PixelTileGridDepthSgix,
		// Token: 0x04008B5C RID: 35676
		PixelTileCacheSizeSgix,
		// Token: 0x04008B5D RID: 35677
		PackResampleSgix = 33836,
		// Token: 0x04008B5E RID: 35678
		UnpackResampleSgix,
		// Token: 0x04008B5F RID: 35679
		PackSubsampleRateSgix = 34208,
		// Token: 0x04008B60 RID: 35680
		UnpackSubsampleRateSgix,
		// Token: 0x04008B61 RID: 35681
		PackResampleOml = 35204,
		// Token: 0x04008B62 RID: 35682
		UnpackResampleOml
	}
}
