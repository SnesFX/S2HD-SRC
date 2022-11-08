using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000402 RID: 1026
	public enum PixelStoreParameter
	{
		// Token: 0x04003E5A RID: 15962
		UnpackSwapBytes = 3312,
		// Token: 0x04003E5B RID: 15963
		UnpackLsbFirst,
		// Token: 0x04003E5C RID: 15964
		UnpackRowLength,
		// Token: 0x04003E5D RID: 15965
		UnpackRowLengthExt = 3314,
		// Token: 0x04003E5E RID: 15966
		UnpackSkipRows,
		// Token: 0x04003E5F RID: 15967
		UnpackSkipRowsExt = 3315,
		// Token: 0x04003E60 RID: 15968
		UnpackSkipPixels,
		// Token: 0x04003E61 RID: 15969
		UnpackSkipPixelsExt = 3316,
		// Token: 0x04003E62 RID: 15970
		UnpackAlignment,
		// Token: 0x04003E63 RID: 15971
		PackSwapBytes = 3328,
		// Token: 0x04003E64 RID: 15972
		PackLsbFirst,
		// Token: 0x04003E65 RID: 15973
		PackRowLength,
		// Token: 0x04003E66 RID: 15974
		PackSkipRows,
		// Token: 0x04003E67 RID: 15975
		PackSkipPixels,
		// Token: 0x04003E68 RID: 15976
		PackAlignment,
		// Token: 0x04003E69 RID: 15977
		PackSkipImages = 32875,
		// Token: 0x04003E6A RID: 15978
		PackSkipImagesExt = 32875,
		// Token: 0x04003E6B RID: 15979
		PackImageHeight,
		// Token: 0x04003E6C RID: 15980
		PackImageHeightExt = 32876,
		// Token: 0x04003E6D RID: 15981
		UnpackSkipImages,
		// Token: 0x04003E6E RID: 15982
		UnpackSkipImagesExt = 32877,
		// Token: 0x04003E6F RID: 15983
		UnpackImageHeight,
		// Token: 0x04003E70 RID: 15984
		UnpackImageHeightExt = 32878,
		// Token: 0x04003E71 RID: 15985
		PackSkipVolumesSgis = 33072,
		// Token: 0x04003E72 RID: 15986
		PackImageDepthSgis,
		// Token: 0x04003E73 RID: 15987
		UnpackSkipVolumesSgis,
		// Token: 0x04003E74 RID: 15988
		UnpackImageDepthSgis,
		// Token: 0x04003E75 RID: 15989
		PixelTileWidthSgix = 33088,
		// Token: 0x04003E76 RID: 15990
		PixelTileHeightSgix,
		// Token: 0x04003E77 RID: 15991
		PixelTileGridWidthSgix,
		// Token: 0x04003E78 RID: 15992
		PixelTileGridHeightSgix,
		// Token: 0x04003E79 RID: 15993
		PixelTileGridDepthSgix,
		// Token: 0x04003E7A RID: 15994
		PixelTileCacheSizeSgix,
		// Token: 0x04003E7B RID: 15995
		PackResampleSgix = 33836,
		// Token: 0x04003E7C RID: 15996
		UnpackResampleSgix,
		// Token: 0x04003E7D RID: 15997
		PackSubsampleRateSgix = 34208,
		// Token: 0x04003E7E RID: 15998
		UnpackSubsampleRateSgix,
		// Token: 0x04003E7F RID: 15999
		PackResampleOml = 35204,
		// Token: 0x04003E80 RID: 16000
		UnpackResampleOml,
		// Token: 0x04003E81 RID: 16001
		UnpackCompressedBlockWidth = 37159,
		// Token: 0x04003E82 RID: 16002
		UnpackCompressedBlockHeight,
		// Token: 0x04003E83 RID: 16003
		UnpackCompressedBlockDepth,
		// Token: 0x04003E84 RID: 16004
		UnpackCompressedBlockSize,
		// Token: 0x04003E85 RID: 16005
		PackCompressedBlockWidth,
		// Token: 0x04003E86 RID: 16006
		PackCompressedBlockHeight,
		// Token: 0x04003E87 RID: 16007
		PackCompressedBlockDepth,
		// Token: 0x04003E88 RID: 16008
		PackCompressedBlockSize
	}
}
