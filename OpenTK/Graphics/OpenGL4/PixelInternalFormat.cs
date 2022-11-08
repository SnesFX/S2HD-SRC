using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000702 RID: 1794
	public enum PixelInternalFormat
	{
		// Token: 0x04006B7C RID: 27516
		DepthComponent = 6402,
		// Token: 0x04006B7D RID: 27517
		Alpha = 6406,
		// Token: 0x04006B7E RID: 27518
		Rgb,
		// Token: 0x04006B7F RID: 27519
		Rgba,
		// Token: 0x04006B80 RID: 27520
		Luminance,
		// Token: 0x04006B81 RID: 27521
		LuminanceAlpha,
		// Token: 0x04006B82 RID: 27522
		R3G3B2 = 10768,
		// Token: 0x04006B83 RID: 27523
		Rgb2Ext = 32846,
		// Token: 0x04006B84 RID: 27524
		Rgb4,
		// Token: 0x04006B85 RID: 27525
		Rgb5,
		// Token: 0x04006B86 RID: 27526
		Rgb8,
		// Token: 0x04006B87 RID: 27527
		Rgb10,
		// Token: 0x04006B88 RID: 27528
		Rgb12,
		// Token: 0x04006B89 RID: 27529
		Rgb16,
		// Token: 0x04006B8A RID: 27530
		Rgba2,
		// Token: 0x04006B8B RID: 27531
		Rgba4,
		// Token: 0x04006B8C RID: 27532
		Rgb5A1,
		// Token: 0x04006B8D RID: 27533
		Rgba8,
		// Token: 0x04006B8E RID: 27534
		Rgb10A2,
		// Token: 0x04006B8F RID: 27535
		Rgba12,
		// Token: 0x04006B90 RID: 27536
		Rgba16,
		// Token: 0x04006B91 RID: 27537
		DualAlpha4Sgis = 33040,
		// Token: 0x04006B92 RID: 27538
		DualAlpha8Sgis,
		// Token: 0x04006B93 RID: 27539
		DualAlpha12Sgis,
		// Token: 0x04006B94 RID: 27540
		DualAlpha16Sgis,
		// Token: 0x04006B95 RID: 27541
		DualLuminance4Sgis,
		// Token: 0x04006B96 RID: 27542
		DualLuminance8Sgis,
		// Token: 0x04006B97 RID: 27543
		DualLuminance12Sgis,
		// Token: 0x04006B98 RID: 27544
		DualLuminance16Sgis,
		// Token: 0x04006B99 RID: 27545
		DualIntensity4Sgis,
		// Token: 0x04006B9A RID: 27546
		DualIntensity8Sgis,
		// Token: 0x04006B9B RID: 27547
		DualIntensity12Sgis,
		// Token: 0x04006B9C RID: 27548
		DualIntensity16Sgis,
		// Token: 0x04006B9D RID: 27549
		DualLuminanceAlpha4Sgis,
		// Token: 0x04006B9E RID: 27550
		DualLuminanceAlpha8Sgis,
		// Token: 0x04006B9F RID: 27551
		QuadAlpha4Sgis,
		// Token: 0x04006BA0 RID: 27552
		QuadAlpha8Sgis,
		// Token: 0x04006BA1 RID: 27553
		QuadLuminance4Sgis,
		// Token: 0x04006BA2 RID: 27554
		QuadLuminance8Sgis,
		// Token: 0x04006BA3 RID: 27555
		QuadIntensity4Sgis,
		// Token: 0x04006BA4 RID: 27556
		QuadIntensity8Sgis,
		// Token: 0x04006BA5 RID: 27557
		DepthComponent16 = 33189,
		// Token: 0x04006BA6 RID: 27558
		DepthComponent16Sgix = 33189,
		// Token: 0x04006BA7 RID: 27559
		DepthComponent24,
		// Token: 0x04006BA8 RID: 27560
		DepthComponent24Sgix = 33190,
		// Token: 0x04006BA9 RID: 27561
		DepthComponent32,
		// Token: 0x04006BAA RID: 27562
		DepthComponent32Sgix = 33191,
		// Token: 0x04006BAB RID: 27563
		CompressedRed = 33317,
		// Token: 0x04006BAC RID: 27564
		CompressedRg,
		// Token: 0x04006BAD RID: 27565
		R8 = 33321,
		// Token: 0x04006BAE RID: 27566
		R16,
		// Token: 0x04006BAF RID: 27567
		Rg8,
		// Token: 0x04006BB0 RID: 27568
		Rg16,
		// Token: 0x04006BB1 RID: 27569
		R16f,
		// Token: 0x04006BB2 RID: 27570
		R32f,
		// Token: 0x04006BB3 RID: 27571
		Rg16f,
		// Token: 0x04006BB4 RID: 27572
		Rg32f,
		// Token: 0x04006BB5 RID: 27573
		R8i,
		// Token: 0x04006BB6 RID: 27574
		R8ui,
		// Token: 0x04006BB7 RID: 27575
		R16i,
		// Token: 0x04006BB8 RID: 27576
		R16ui,
		// Token: 0x04006BB9 RID: 27577
		R32i,
		// Token: 0x04006BBA RID: 27578
		R32ui,
		// Token: 0x04006BBB RID: 27579
		Rg8i,
		// Token: 0x04006BBC RID: 27580
		Rg8ui,
		// Token: 0x04006BBD RID: 27581
		Rg16i,
		// Token: 0x04006BBE RID: 27582
		Rg16ui,
		// Token: 0x04006BBF RID: 27583
		Rg32i,
		// Token: 0x04006BC0 RID: 27584
		Rg32ui,
		// Token: 0x04006BC1 RID: 27585
		CompressedRgbS3tcDxt1Ext = 33776,
		// Token: 0x04006BC2 RID: 27586
		CompressedRgbaS3tcDxt1Ext,
		// Token: 0x04006BC3 RID: 27587
		CompressedRgbaS3tcDxt3Ext,
		// Token: 0x04006BC4 RID: 27588
		CompressedRgbaS3tcDxt5Ext,
		// Token: 0x04006BC5 RID: 27589
		RgbIccSgix = 33888,
		// Token: 0x04006BC6 RID: 27590
		RgbaIccSgix,
		// Token: 0x04006BC7 RID: 27591
		AlphaIccSgix,
		// Token: 0x04006BC8 RID: 27592
		LuminanceIccSgix,
		// Token: 0x04006BC9 RID: 27593
		IntensityIccSgix,
		// Token: 0x04006BCA RID: 27594
		LuminanceAlphaIccSgix,
		// Token: 0x04006BCB RID: 27595
		R5G6B5IccSgix,
		// Token: 0x04006BCC RID: 27596
		R5G6B5A8IccSgix,
		// Token: 0x04006BCD RID: 27597
		Alpha16IccSgix,
		// Token: 0x04006BCE RID: 27598
		Luminance16IccSgix,
		// Token: 0x04006BCF RID: 27599
		Intensity16IccSgix,
		// Token: 0x04006BD0 RID: 27600
		Luminance16Alpha8IccSgix,
		// Token: 0x04006BD1 RID: 27601
		CompressedAlpha = 34025,
		// Token: 0x04006BD2 RID: 27602
		CompressedLuminance,
		// Token: 0x04006BD3 RID: 27603
		CompressedLuminanceAlpha,
		// Token: 0x04006BD4 RID: 27604
		CompressedIntensity,
		// Token: 0x04006BD5 RID: 27605
		CompressedRgb,
		// Token: 0x04006BD6 RID: 27606
		CompressedRgba,
		// Token: 0x04006BD7 RID: 27607
		DepthStencil = 34041,
		// Token: 0x04006BD8 RID: 27608
		Rgba32f = 34836,
		// Token: 0x04006BD9 RID: 27609
		Rgb32f,
		// Token: 0x04006BDA RID: 27610
		Rgba16f = 34842,
		// Token: 0x04006BDB RID: 27611
		Rgb16f,
		// Token: 0x04006BDC RID: 27612
		Depth24Stencil8 = 35056,
		// Token: 0x04006BDD RID: 27613
		R11fG11fB10f = 35898,
		// Token: 0x04006BDE RID: 27614
		Rgb9E5 = 35901,
		// Token: 0x04006BDF RID: 27615
		Srgb = 35904,
		// Token: 0x04006BE0 RID: 27616
		Srgb8,
		// Token: 0x04006BE1 RID: 27617
		SrgbAlpha,
		// Token: 0x04006BE2 RID: 27618
		Srgb8Alpha8,
		// Token: 0x04006BE3 RID: 27619
		SluminanceAlpha,
		// Token: 0x04006BE4 RID: 27620
		Sluminance8Alpha8,
		// Token: 0x04006BE5 RID: 27621
		Sluminance,
		// Token: 0x04006BE6 RID: 27622
		Sluminance8,
		// Token: 0x04006BE7 RID: 27623
		CompressedSrgb,
		// Token: 0x04006BE8 RID: 27624
		CompressedSrgbAlpha,
		// Token: 0x04006BE9 RID: 27625
		CompressedSluminance,
		// Token: 0x04006BEA RID: 27626
		CompressedSluminanceAlpha,
		// Token: 0x04006BEB RID: 27627
		CompressedSrgbS3tcDxt1Ext,
		// Token: 0x04006BEC RID: 27628
		CompressedSrgbAlphaS3tcDxt1Ext,
		// Token: 0x04006BED RID: 27629
		CompressedSrgbAlphaS3tcDxt3Ext,
		// Token: 0x04006BEE RID: 27630
		CompressedSrgbAlphaS3tcDxt5Ext,
		// Token: 0x04006BEF RID: 27631
		DepthComponent32f = 36012,
		// Token: 0x04006BF0 RID: 27632
		Depth32fStencil8,
		// Token: 0x04006BF1 RID: 27633
		Rgba32ui = 36208,
		// Token: 0x04006BF2 RID: 27634
		Rgb32ui,
		// Token: 0x04006BF3 RID: 27635
		Rgba16ui = 36214,
		// Token: 0x04006BF4 RID: 27636
		Rgb16ui,
		// Token: 0x04006BF5 RID: 27637
		Rgba8ui = 36220,
		// Token: 0x04006BF6 RID: 27638
		Rgb8ui,
		// Token: 0x04006BF7 RID: 27639
		Rgba32i = 36226,
		// Token: 0x04006BF8 RID: 27640
		Rgb32i,
		// Token: 0x04006BF9 RID: 27641
		Rgba16i = 36232,
		// Token: 0x04006BFA RID: 27642
		Rgb16i,
		// Token: 0x04006BFB RID: 27643
		Rgba8i = 36238,
		// Token: 0x04006BFC RID: 27644
		Rgb8i,
		// Token: 0x04006BFD RID: 27645
		Float32UnsignedInt248Rev = 36269,
		// Token: 0x04006BFE RID: 27646
		CompressedRedRgtc1 = 36283,
		// Token: 0x04006BFF RID: 27647
		CompressedSignedRedRgtc1,
		// Token: 0x04006C00 RID: 27648
		CompressedRgRgtc2,
		// Token: 0x04006C01 RID: 27649
		CompressedSignedRgRgtc2,
		// Token: 0x04006C02 RID: 27650
		CompressedRgbaBptcUnorm = 36492,
		// Token: 0x04006C03 RID: 27651
		CompressedRgbBptcSignedFloat = 36494,
		// Token: 0x04006C04 RID: 27652
		CompressedRgbBptcUnsignedFloat,
		// Token: 0x04006C05 RID: 27653
		R8Snorm = 36756,
		// Token: 0x04006C06 RID: 27654
		Rg8Snorm,
		// Token: 0x04006C07 RID: 27655
		Rgb8Snorm,
		// Token: 0x04006C08 RID: 27656
		Rgba8Snorm,
		// Token: 0x04006C09 RID: 27657
		R16Snorm,
		// Token: 0x04006C0A RID: 27658
		Rg16Snorm,
		// Token: 0x04006C0B RID: 27659
		Rgb16Snorm,
		// Token: 0x04006C0C RID: 27660
		Rgba16Snorm,
		// Token: 0x04006C0D RID: 27661
		Rgb10A2ui = 36975,
		// Token: 0x04006C0E RID: 27662
		One = 1,
		// Token: 0x04006C0F RID: 27663
		Two,
		// Token: 0x04006C10 RID: 27664
		Three,
		// Token: 0x04006C11 RID: 27665
		Four
	}
}
