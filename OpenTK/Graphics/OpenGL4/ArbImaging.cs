using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x02000628 RID: 1576
	public enum ArbImaging
	{
		// Token: 0x0400608B RID: 24715
		ConstantColor = 32769,
		// Token: 0x0400608C RID: 24716
		OneMinusConstantColor,
		// Token: 0x0400608D RID: 24717
		ConstantAlpha,
		// Token: 0x0400608E RID: 24718
		OneMinusConstantAlpha,
		// Token: 0x0400608F RID: 24719
		BlendColor,
		// Token: 0x04006090 RID: 24720
		FuncAdd,
		// Token: 0x04006091 RID: 24721
		Min,
		// Token: 0x04006092 RID: 24722
		Max,
		// Token: 0x04006093 RID: 24723
		BlendEquation,
		// Token: 0x04006094 RID: 24724
		FuncSubtract,
		// Token: 0x04006095 RID: 24725
		FuncReverseSubtract,
		// Token: 0x04006096 RID: 24726
		Convolution1D = 32784,
		// Token: 0x04006097 RID: 24727
		Convolution2D,
		// Token: 0x04006098 RID: 24728
		Separable2D,
		// Token: 0x04006099 RID: 24729
		ConvolutionBorderMode,
		// Token: 0x0400609A RID: 24730
		ConvolutionFilterScale,
		// Token: 0x0400609B RID: 24731
		ConvolutionFilterBias,
		// Token: 0x0400609C RID: 24732
		Reduce,
		// Token: 0x0400609D RID: 24733
		ConvolutionFormat,
		// Token: 0x0400609E RID: 24734
		ConvolutionWidth,
		// Token: 0x0400609F RID: 24735
		ConvolutionHeight,
		// Token: 0x040060A0 RID: 24736
		MaxConvolutionWidth,
		// Token: 0x040060A1 RID: 24737
		MaxConvolutionHeight,
		// Token: 0x040060A2 RID: 24738
		PostConvolutionRedScale,
		// Token: 0x040060A3 RID: 24739
		PostConvolutionGreenScale,
		// Token: 0x040060A4 RID: 24740
		PostConvolutionBlueScale,
		// Token: 0x040060A5 RID: 24741
		PostConvolutionAlphaScale,
		// Token: 0x040060A6 RID: 24742
		PostConvolutionRedBias,
		// Token: 0x040060A7 RID: 24743
		PostConvolutionGreenBias,
		// Token: 0x040060A8 RID: 24744
		PostConvolutionBlueBias,
		// Token: 0x040060A9 RID: 24745
		PostConvolutionAlphaBias,
		// Token: 0x040060AA RID: 24746
		Histogram,
		// Token: 0x040060AB RID: 24747
		ProxyHistogram,
		// Token: 0x040060AC RID: 24748
		HistogramWidth,
		// Token: 0x040060AD RID: 24749
		HistogramFormat,
		// Token: 0x040060AE RID: 24750
		HistogramRedSize,
		// Token: 0x040060AF RID: 24751
		HistogramGreenSize,
		// Token: 0x040060B0 RID: 24752
		HistogramBlueSize,
		// Token: 0x040060B1 RID: 24753
		HistogramAlphaSize,
		// Token: 0x040060B2 RID: 24754
		HistogramLuminanceSize,
		// Token: 0x040060B3 RID: 24755
		HistogramSink,
		// Token: 0x040060B4 RID: 24756
		Minmax,
		// Token: 0x040060B5 RID: 24757
		MinmaxFormat,
		// Token: 0x040060B6 RID: 24758
		MinmaxSink,
		// Token: 0x040060B7 RID: 24759
		TableTooLarge,
		// Token: 0x040060B8 RID: 24760
		ColorMatrix = 32945,
		// Token: 0x040060B9 RID: 24761
		ColorMatrixStackDepth,
		// Token: 0x040060BA RID: 24762
		MaxColorMatrixStackDepth,
		// Token: 0x040060BB RID: 24763
		PostColorMatrixRedScale,
		// Token: 0x040060BC RID: 24764
		PostColorMatrixGreenScale,
		// Token: 0x040060BD RID: 24765
		PostColorMatrixBlueScale,
		// Token: 0x040060BE RID: 24766
		PostColorMatrixAlphaScale,
		// Token: 0x040060BF RID: 24767
		PostColorMatrixRedBias,
		// Token: 0x040060C0 RID: 24768
		PostColorMatrixGreenBias,
		// Token: 0x040060C1 RID: 24769
		PostColorMatrixBlueBias,
		// Token: 0x040060C2 RID: 24770
		PostColorMatrixAlphaBias,
		// Token: 0x040060C3 RID: 24771
		ColorTable = 32976,
		// Token: 0x040060C4 RID: 24772
		PostConvolutionColorTable,
		// Token: 0x040060C5 RID: 24773
		PostColorMatrixColorTable,
		// Token: 0x040060C6 RID: 24774
		ProxyColorTable,
		// Token: 0x040060C7 RID: 24775
		ProxyPostConvolutionColorTable,
		// Token: 0x040060C8 RID: 24776
		ProxyPostColorMatrixColorTable,
		// Token: 0x040060C9 RID: 24777
		ColorTableScale,
		// Token: 0x040060CA RID: 24778
		ColorTableBias,
		// Token: 0x040060CB RID: 24779
		ColorTableFormat,
		// Token: 0x040060CC RID: 24780
		ColorTableWidth,
		// Token: 0x040060CD RID: 24781
		ColorTableRedSize,
		// Token: 0x040060CE RID: 24782
		ColorTableGreenSize,
		// Token: 0x040060CF RID: 24783
		ColorTableBlueSize,
		// Token: 0x040060D0 RID: 24784
		ColorTableAlphaSize,
		// Token: 0x040060D1 RID: 24785
		ColorTableLuminanceSize,
		// Token: 0x040060D2 RID: 24786
		ColorTableIntensitySize,
		// Token: 0x040060D3 RID: 24787
		ConstantBorder = 33105,
		// Token: 0x040060D4 RID: 24788
		ReplicateBorder = 33107,
		// Token: 0x040060D5 RID: 24789
		ConvolutionBorderColor
	}
}
