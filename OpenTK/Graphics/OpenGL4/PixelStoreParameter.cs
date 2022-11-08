using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000704 RID: 1796
	public enum PixelStoreParameter
	{
		// Token: 0x04006C1E RID: 27678
		UnpackSwapBytes = 3312,
		// Token: 0x04006C1F RID: 27679
		UnpackLsbFirst,
		// Token: 0x04006C20 RID: 27680
		UnpackRowLength,
		// Token: 0x04006C21 RID: 27681
		UnpackRowLengthExt = 3314,
		// Token: 0x04006C22 RID: 27682
		UnpackSkipRows,
		// Token: 0x04006C23 RID: 27683
		UnpackSkipRowsExt = 3315,
		// Token: 0x04006C24 RID: 27684
		UnpackSkipPixels,
		// Token: 0x04006C25 RID: 27685
		UnpackSkipPixelsExt = 3316,
		// Token: 0x04006C26 RID: 27686
		UnpackAlignment,
		// Token: 0x04006C27 RID: 27687
		PackSwapBytes = 3328,
		// Token: 0x04006C28 RID: 27688
		PackLsbFirst,
		// Token: 0x04006C29 RID: 27689
		PackRowLength,
		// Token: 0x04006C2A RID: 27690
		PackSkipRows,
		// Token: 0x04006C2B RID: 27691
		PackSkipPixels,
		// Token: 0x04006C2C RID: 27692
		PackAlignment,
		// Token: 0x04006C2D RID: 27693
		PackSkipImages = 32875,
		// Token: 0x04006C2E RID: 27694
		PackSkipImagesExt = 32875,
		// Token: 0x04006C2F RID: 27695
		PackImageHeight,
		// Token: 0x04006C30 RID: 27696
		PackImageHeightExt = 32876,
		// Token: 0x04006C31 RID: 27697
		UnpackSkipImages,
		// Token: 0x04006C32 RID: 27698
		UnpackSkipImagesExt = 32877,
		// Token: 0x04006C33 RID: 27699
		UnpackImageHeight,
		// Token: 0x04006C34 RID: 27700
		UnpackImageHeightExt = 32878,
		// Token: 0x04006C35 RID: 27701
		PackSkipVolumesSgis = 33072,
		// Token: 0x04006C36 RID: 27702
		PackImageDepthSgis,
		// Token: 0x04006C37 RID: 27703
		UnpackSkipVolumesSgis,
		// Token: 0x04006C38 RID: 27704
		UnpackImageDepthSgis,
		// Token: 0x04006C39 RID: 27705
		PixelTileWidthSgix = 33088,
		// Token: 0x04006C3A RID: 27706
		PixelTileHeightSgix,
		// Token: 0x04006C3B RID: 27707
		PixelTileGridWidthSgix,
		// Token: 0x04006C3C RID: 27708
		PixelTileGridHeightSgix,
		// Token: 0x04006C3D RID: 27709
		PixelTileGridDepthSgix,
		// Token: 0x04006C3E RID: 27710
		PixelTileCacheSizeSgix,
		// Token: 0x04006C3F RID: 27711
		PackResampleSgix = 33836,
		// Token: 0x04006C40 RID: 27712
		UnpackResampleSgix,
		// Token: 0x04006C41 RID: 27713
		PackSubsampleRateSgix = 34208,
		// Token: 0x04006C42 RID: 27714
		UnpackSubsampleRateSgix,
		// Token: 0x04006C43 RID: 27715
		PackResampleOml = 35204,
		// Token: 0x04006C44 RID: 27716
		UnpackResampleOml,
		// Token: 0x04006C45 RID: 27717
		UnpackCompressedBlockWidth = 37159,
		// Token: 0x04006C46 RID: 27718
		UnpackCompressedBlockHeight,
		// Token: 0x04006C47 RID: 27719
		UnpackCompressedBlockDepth,
		// Token: 0x04006C48 RID: 27720
		UnpackCompressedBlockSize,
		// Token: 0x04006C49 RID: 27721
		PackCompressedBlockWidth,
		// Token: 0x04006C4A RID: 27722
		PackCompressedBlockHeight,
		// Token: 0x04006C4B RID: 27723
		PackCompressedBlockDepth,
		// Token: 0x04006C4C RID: 27724
		PackCompressedBlockSize
	}
}
