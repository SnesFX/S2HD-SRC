using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000AC8 RID: 2760
	public enum PixelStoreParameter
	{
		// Token: 0x0400B141 RID: 45377
		UnpackSwapBytes = 3312,
		// Token: 0x0400B142 RID: 45378
		UnpackLsbFirst,
		// Token: 0x0400B143 RID: 45379
		UnpackRowLength,
		// Token: 0x0400B144 RID: 45380
		UnpackRowLengthExt = 3314,
		// Token: 0x0400B145 RID: 45381
		UnpackSkipRows,
		// Token: 0x0400B146 RID: 45382
		UnpackSkipRowsExt = 3315,
		// Token: 0x0400B147 RID: 45383
		UnpackSkipPixels,
		// Token: 0x0400B148 RID: 45384
		UnpackSkipPixelsExt = 3316,
		// Token: 0x0400B149 RID: 45385
		UnpackAlignment,
		// Token: 0x0400B14A RID: 45386
		PackSwapBytes = 3328,
		// Token: 0x0400B14B RID: 45387
		PackLsbFirst,
		// Token: 0x0400B14C RID: 45388
		PackRowLength,
		// Token: 0x0400B14D RID: 45389
		PackSkipRows,
		// Token: 0x0400B14E RID: 45390
		PackSkipPixels,
		// Token: 0x0400B14F RID: 45391
		PackAlignment,
		// Token: 0x0400B150 RID: 45392
		PackSkipImages = 32875,
		// Token: 0x0400B151 RID: 45393
		PackSkipImagesExt = 32875,
		// Token: 0x0400B152 RID: 45394
		PackImageHeight,
		// Token: 0x0400B153 RID: 45395
		PackImageHeightExt = 32876,
		// Token: 0x0400B154 RID: 45396
		UnpackSkipImages,
		// Token: 0x0400B155 RID: 45397
		UnpackSkipImagesExt = 32877,
		// Token: 0x0400B156 RID: 45398
		UnpackImageHeight,
		// Token: 0x0400B157 RID: 45399
		UnpackImageHeightExt = 32878,
		// Token: 0x0400B158 RID: 45400
		PackSkipVolumesSgis = 33072,
		// Token: 0x0400B159 RID: 45401
		PackImageDepthSgis,
		// Token: 0x0400B15A RID: 45402
		UnpackSkipVolumesSgis,
		// Token: 0x0400B15B RID: 45403
		UnpackImageDepthSgis,
		// Token: 0x0400B15C RID: 45404
		PixelTileWidthSgix = 33088,
		// Token: 0x0400B15D RID: 45405
		PixelTileHeightSgix,
		// Token: 0x0400B15E RID: 45406
		PixelTileGridWidthSgix,
		// Token: 0x0400B15F RID: 45407
		PixelTileGridHeightSgix,
		// Token: 0x0400B160 RID: 45408
		PixelTileGridDepthSgix,
		// Token: 0x0400B161 RID: 45409
		PixelTileCacheSizeSgix,
		// Token: 0x0400B162 RID: 45410
		PackResampleSgix = 33836,
		// Token: 0x0400B163 RID: 45411
		UnpackResampleSgix,
		// Token: 0x0400B164 RID: 45412
		PackSubsampleRateSgix = 34208,
		// Token: 0x0400B165 RID: 45413
		UnpackSubsampleRateSgix,
		// Token: 0x0400B166 RID: 45414
		PackResampleOml = 35204,
		// Token: 0x0400B167 RID: 45415
		UnpackResampleOml
	}
}
