using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000756 RID: 1878
	public enum Version11
	{
		// Token: 0x04006FF0 RID: 28656
		False,
		// Token: 0x04006FF1 RID: 28657
		NoError = 0,
		// Token: 0x04006FF2 RID: 28658
		None = 0,
		// Token: 0x04006FF3 RID: 28659
		Zero = 0,
		// Token: 0x04006FF4 RID: 28660
		Points = 0,
		// Token: 0x04006FF5 RID: 28661
		DepthBufferBit = 256,
		// Token: 0x04006FF6 RID: 28662
		StencilBufferBit = 1024,
		// Token: 0x04006FF7 RID: 28663
		ColorBufferBit = 16384,
		// Token: 0x04006FF8 RID: 28664
		Lines = 1,
		// Token: 0x04006FF9 RID: 28665
		LineLoop,
		// Token: 0x04006FFA RID: 28666
		LineStrip,
		// Token: 0x04006FFB RID: 28667
		Triangles,
		// Token: 0x04006FFC RID: 28668
		TriangleStrip,
		// Token: 0x04006FFD RID: 28669
		TriangleFan,
		// Token: 0x04006FFE RID: 28670
		Never = 512,
		// Token: 0x04006FFF RID: 28671
		Less,
		// Token: 0x04007000 RID: 28672
		Equal,
		// Token: 0x04007001 RID: 28673
		Lequal,
		// Token: 0x04007002 RID: 28674
		Greater,
		// Token: 0x04007003 RID: 28675
		Notequal,
		// Token: 0x04007004 RID: 28676
		Gequal,
		// Token: 0x04007005 RID: 28677
		Always,
		// Token: 0x04007006 RID: 28678
		SrcColor = 768,
		// Token: 0x04007007 RID: 28679
		OneMinusSrcColor,
		// Token: 0x04007008 RID: 28680
		SrcAlpha,
		// Token: 0x04007009 RID: 28681
		OneMinusSrcAlpha,
		// Token: 0x0400700A RID: 28682
		DstAlpha,
		// Token: 0x0400700B RID: 28683
		OneMinusDstAlpha,
		// Token: 0x0400700C RID: 28684
		DstColor,
		// Token: 0x0400700D RID: 28685
		OneMinusDstColor,
		// Token: 0x0400700E RID: 28686
		SrcAlphaSaturate,
		// Token: 0x0400700F RID: 28687
		FrontLeft = 1024,
		// Token: 0x04007010 RID: 28688
		FrontRight,
		// Token: 0x04007011 RID: 28689
		BackLeft,
		// Token: 0x04007012 RID: 28690
		BackRight,
		// Token: 0x04007013 RID: 28691
		Front,
		// Token: 0x04007014 RID: 28692
		Back,
		// Token: 0x04007015 RID: 28693
		Left,
		// Token: 0x04007016 RID: 28694
		Right,
		// Token: 0x04007017 RID: 28695
		FrontAndBack,
		// Token: 0x04007018 RID: 28696
		InvalidEnum = 1280,
		// Token: 0x04007019 RID: 28697
		InvalidValue,
		// Token: 0x0400701A RID: 28698
		InvalidOperation,
		// Token: 0x0400701B RID: 28699
		OutOfMemory = 1285,
		// Token: 0x0400701C RID: 28700
		Cw = 2304,
		// Token: 0x0400701D RID: 28701
		Ccw,
		// Token: 0x0400701E RID: 28702
		PointSize = 2833,
		// Token: 0x0400701F RID: 28703
		PointSizeRange,
		// Token: 0x04007020 RID: 28704
		PointSizeGranularity,
		// Token: 0x04007021 RID: 28705
		LineSmooth = 2848,
		// Token: 0x04007022 RID: 28706
		LineWidth,
		// Token: 0x04007023 RID: 28707
		LineWidthRange,
		// Token: 0x04007024 RID: 28708
		LineWidthGranularity,
		// Token: 0x04007025 RID: 28709
		PolygonMode = 2880,
		// Token: 0x04007026 RID: 28710
		PolygonSmooth,
		// Token: 0x04007027 RID: 28711
		CullFace = 2884,
		// Token: 0x04007028 RID: 28712
		CullFaceMode,
		// Token: 0x04007029 RID: 28713
		FrontFace,
		// Token: 0x0400702A RID: 28714
		DepthRange = 2928,
		// Token: 0x0400702B RID: 28715
		DepthTest,
		// Token: 0x0400702C RID: 28716
		DepthWritemask,
		// Token: 0x0400702D RID: 28717
		DepthClearValue,
		// Token: 0x0400702E RID: 28718
		DepthFunc,
		// Token: 0x0400702F RID: 28719
		StencilTest = 2960,
		// Token: 0x04007030 RID: 28720
		StencilClearValue,
		// Token: 0x04007031 RID: 28721
		StencilFunc,
		// Token: 0x04007032 RID: 28722
		StencilValueMask,
		// Token: 0x04007033 RID: 28723
		StencilFail,
		// Token: 0x04007034 RID: 28724
		StencilPassDepthFail,
		// Token: 0x04007035 RID: 28725
		StencilPassDepthPass,
		// Token: 0x04007036 RID: 28726
		StencilRef,
		// Token: 0x04007037 RID: 28727
		StencilWritemask,
		// Token: 0x04007038 RID: 28728
		Viewport = 2978,
		// Token: 0x04007039 RID: 28729
		Dither = 3024,
		// Token: 0x0400703A RID: 28730
		BlendDst = 3040,
		// Token: 0x0400703B RID: 28731
		BlendSrc,
		// Token: 0x0400703C RID: 28732
		Blend,
		// Token: 0x0400703D RID: 28733
		LogicOpMode = 3056,
		// Token: 0x0400703E RID: 28734
		ColorLogicOp = 3058,
		// Token: 0x0400703F RID: 28735
		DrawBuffer = 3073,
		// Token: 0x04007040 RID: 28736
		ReadBuffer,
		// Token: 0x04007041 RID: 28737
		ScissorBox = 3088,
		// Token: 0x04007042 RID: 28738
		ScissorTest,
		// Token: 0x04007043 RID: 28739
		ColorClearValue = 3106,
		// Token: 0x04007044 RID: 28740
		ColorWritemask,
		// Token: 0x04007045 RID: 28741
		Doublebuffer = 3122,
		// Token: 0x04007046 RID: 28742
		Stereo,
		// Token: 0x04007047 RID: 28743
		LineSmoothHint = 3154,
		// Token: 0x04007048 RID: 28744
		PolygonSmoothHint,
		// Token: 0x04007049 RID: 28745
		UnpackSwapBytes = 3312,
		// Token: 0x0400704A RID: 28746
		UnpackLsbFirst,
		// Token: 0x0400704B RID: 28747
		UnpackRowLength,
		// Token: 0x0400704C RID: 28748
		UnpackSkipRows,
		// Token: 0x0400704D RID: 28749
		UnpackSkipPixels,
		// Token: 0x0400704E RID: 28750
		UnpackAlignment,
		// Token: 0x0400704F RID: 28751
		PackSwapBytes = 3328,
		// Token: 0x04007050 RID: 28752
		PackLsbFirst,
		// Token: 0x04007051 RID: 28753
		PackRowLength,
		// Token: 0x04007052 RID: 28754
		PackSkipRows,
		// Token: 0x04007053 RID: 28755
		PackSkipPixels,
		// Token: 0x04007054 RID: 28756
		PackAlignment,
		// Token: 0x04007055 RID: 28757
		MaxTextureSize = 3379,
		// Token: 0x04007056 RID: 28758
		MaxViewportDims = 3386,
		// Token: 0x04007057 RID: 28759
		SubpixelBits = 3408,
		// Token: 0x04007058 RID: 28760
		Texture1D = 3552,
		// Token: 0x04007059 RID: 28761
		Texture2D,
		// Token: 0x0400705A RID: 28762
		TextureWidth = 4096,
		// Token: 0x0400705B RID: 28763
		TextureHeight,
		// Token: 0x0400705C RID: 28764
		TextureInternalFormat = 4099,
		// Token: 0x0400705D RID: 28765
		TextureBorderColor,
		// Token: 0x0400705E RID: 28766
		DontCare = 4352,
		// Token: 0x0400705F RID: 28767
		Fastest,
		// Token: 0x04007060 RID: 28768
		Nicest,
		// Token: 0x04007061 RID: 28769
		Byte = 5120,
		// Token: 0x04007062 RID: 28770
		UnsignedByte,
		// Token: 0x04007063 RID: 28771
		Short,
		// Token: 0x04007064 RID: 28772
		UnsignedShort,
		// Token: 0x04007065 RID: 28773
		Int,
		// Token: 0x04007066 RID: 28774
		UnsignedInt,
		// Token: 0x04007067 RID: 28775
		Float,
		// Token: 0x04007068 RID: 28776
		Double = 5130,
		// Token: 0x04007069 RID: 28777
		Clear = 5376,
		// Token: 0x0400706A RID: 28778
		And,
		// Token: 0x0400706B RID: 28779
		AndReverse,
		// Token: 0x0400706C RID: 28780
		Copy,
		// Token: 0x0400706D RID: 28781
		AndInverted,
		// Token: 0x0400706E RID: 28782
		Noop,
		// Token: 0x0400706F RID: 28783
		Xor,
		// Token: 0x04007070 RID: 28784
		Or,
		// Token: 0x04007071 RID: 28785
		Nor,
		// Token: 0x04007072 RID: 28786
		Equiv,
		// Token: 0x04007073 RID: 28787
		Invert,
		// Token: 0x04007074 RID: 28788
		OrReverse,
		// Token: 0x04007075 RID: 28789
		CopyInverted,
		// Token: 0x04007076 RID: 28790
		OrInverted,
		// Token: 0x04007077 RID: 28791
		Nand,
		// Token: 0x04007078 RID: 28792
		Set,
		// Token: 0x04007079 RID: 28793
		Texture = 5890,
		// Token: 0x0400707A RID: 28794
		Color = 6144,
		// Token: 0x0400707B RID: 28795
		Depth,
		// Token: 0x0400707C RID: 28796
		Stencil,
		// Token: 0x0400707D RID: 28797
		StencilIndex = 6401,
		// Token: 0x0400707E RID: 28798
		DepthComponent,
		// Token: 0x0400707F RID: 28799
		Red,
		// Token: 0x04007080 RID: 28800
		Green,
		// Token: 0x04007081 RID: 28801
		Blue,
		// Token: 0x04007082 RID: 28802
		Alpha,
		// Token: 0x04007083 RID: 28803
		Rgb,
		// Token: 0x04007084 RID: 28804
		Rgba,
		// Token: 0x04007085 RID: 28805
		Point = 6912,
		// Token: 0x04007086 RID: 28806
		Line,
		// Token: 0x04007087 RID: 28807
		Fill,
		// Token: 0x04007088 RID: 28808
		Keep = 7680,
		// Token: 0x04007089 RID: 28809
		Replace,
		// Token: 0x0400708A RID: 28810
		Incr,
		// Token: 0x0400708B RID: 28811
		Decr,
		// Token: 0x0400708C RID: 28812
		Vendor = 7936,
		// Token: 0x0400708D RID: 28813
		Renderer,
		// Token: 0x0400708E RID: 28814
		Version,
		// Token: 0x0400708F RID: 28815
		Extensions,
		// Token: 0x04007090 RID: 28816
		Nearest = 9728,
		// Token: 0x04007091 RID: 28817
		Linear,
		// Token: 0x04007092 RID: 28818
		NearestMipmapNearest = 9984,
		// Token: 0x04007093 RID: 28819
		LinearMipmapNearest,
		// Token: 0x04007094 RID: 28820
		NearestMipmapLinear,
		// Token: 0x04007095 RID: 28821
		LinearMipmapLinear,
		// Token: 0x04007096 RID: 28822
		TextureMagFilter = 10240,
		// Token: 0x04007097 RID: 28823
		TextureMinFilter,
		// Token: 0x04007098 RID: 28824
		TextureWrapS,
		// Token: 0x04007099 RID: 28825
		TextureWrapT,
		// Token: 0x0400709A RID: 28826
		Repeat = 10497,
		// Token: 0x0400709B RID: 28827
		PolygonOffsetUnits = 10752,
		// Token: 0x0400709C RID: 28828
		PolygonOffsetPoint,
		// Token: 0x0400709D RID: 28829
		PolygonOffsetLine,
		// Token: 0x0400709E RID: 28830
		R3G3B2 = 10768,
		// Token: 0x0400709F RID: 28831
		PolygonOffsetFill = 32823,
		// Token: 0x040070A0 RID: 28832
		PolygonOffsetFactor,
		// Token: 0x040070A1 RID: 28833
		Rgb4 = 32847,
		// Token: 0x040070A2 RID: 28834
		Rgb5,
		// Token: 0x040070A3 RID: 28835
		Rgb8,
		// Token: 0x040070A4 RID: 28836
		Rgb10,
		// Token: 0x040070A5 RID: 28837
		Rgb12,
		// Token: 0x040070A6 RID: 28838
		Rgb16,
		// Token: 0x040070A7 RID: 28839
		Rgba2,
		// Token: 0x040070A8 RID: 28840
		Rgba4,
		// Token: 0x040070A9 RID: 28841
		Rgb5A1,
		// Token: 0x040070AA RID: 28842
		Rgba8,
		// Token: 0x040070AB RID: 28843
		Rgb10A2,
		// Token: 0x040070AC RID: 28844
		Rgba12,
		// Token: 0x040070AD RID: 28845
		Rgba16,
		// Token: 0x040070AE RID: 28846
		TextureRedSize,
		// Token: 0x040070AF RID: 28847
		TextureGreenSize,
		// Token: 0x040070B0 RID: 28848
		TextureBlueSize,
		// Token: 0x040070B1 RID: 28849
		TextureAlphaSize,
		// Token: 0x040070B2 RID: 28850
		ProxyTexture1D = 32867,
		// Token: 0x040070B3 RID: 28851
		ProxyTexture2D,
		// Token: 0x040070B4 RID: 28852
		TextureBinding1D = 32872,
		// Token: 0x040070B5 RID: 28853
		TextureBinding2D,
		// Token: 0x040070B6 RID: 28854
		One = 1,
		// Token: 0x040070B7 RID: 28855
		True = 1
	}
}
