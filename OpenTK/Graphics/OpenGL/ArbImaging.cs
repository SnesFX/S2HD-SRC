using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x02000222 RID: 546
	public enum ArbImaging
	{
		// Token: 0x040027B7 RID: 10167
		ConstantColor = 32769,
		// Token: 0x040027B8 RID: 10168
		OneMinusConstantColor,
		// Token: 0x040027B9 RID: 10169
		ConstantAlpha,
		// Token: 0x040027BA RID: 10170
		OneMinusConstantAlpha,
		// Token: 0x040027BB RID: 10171
		BlendColor,
		// Token: 0x040027BC RID: 10172
		FuncAdd,
		// Token: 0x040027BD RID: 10173
		Min,
		// Token: 0x040027BE RID: 10174
		Max,
		// Token: 0x040027BF RID: 10175
		BlendEquation,
		// Token: 0x040027C0 RID: 10176
		FuncSubtract,
		// Token: 0x040027C1 RID: 10177
		FuncReverseSubtract,
		// Token: 0x040027C2 RID: 10178
		Convolution1D = 32784,
		// Token: 0x040027C3 RID: 10179
		Convolution2D,
		// Token: 0x040027C4 RID: 10180
		Separable2D,
		// Token: 0x040027C5 RID: 10181
		ConvolutionBorderMode,
		// Token: 0x040027C6 RID: 10182
		ConvolutionFilterScale,
		// Token: 0x040027C7 RID: 10183
		ConvolutionFilterBias,
		// Token: 0x040027C8 RID: 10184
		Reduce,
		// Token: 0x040027C9 RID: 10185
		ConvolutionFormat,
		// Token: 0x040027CA RID: 10186
		ConvolutionWidth,
		// Token: 0x040027CB RID: 10187
		ConvolutionHeight,
		// Token: 0x040027CC RID: 10188
		MaxConvolutionWidth,
		// Token: 0x040027CD RID: 10189
		MaxConvolutionHeight,
		// Token: 0x040027CE RID: 10190
		PostConvolutionRedScale,
		// Token: 0x040027CF RID: 10191
		PostConvolutionGreenScale,
		// Token: 0x040027D0 RID: 10192
		PostConvolutionBlueScale,
		// Token: 0x040027D1 RID: 10193
		PostConvolutionAlphaScale,
		// Token: 0x040027D2 RID: 10194
		PostConvolutionRedBias,
		// Token: 0x040027D3 RID: 10195
		PostConvolutionGreenBias,
		// Token: 0x040027D4 RID: 10196
		PostConvolutionBlueBias,
		// Token: 0x040027D5 RID: 10197
		PostConvolutionAlphaBias,
		// Token: 0x040027D6 RID: 10198
		Histogram,
		// Token: 0x040027D7 RID: 10199
		ProxyHistogram,
		// Token: 0x040027D8 RID: 10200
		HistogramWidth,
		// Token: 0x040027D9 RID: 10201
		HistogramFormat,
		// Token: 0x040027DA RID: 10202
		HistogramRedSize,
		// Token: 0x040027DB RID: 10203
		HistogramGreenSize,
		// Token: 0x040027DC RID: 10204
		HistogramBlueSize,
		// Token: 0x040027DD RID: 10205
		HistogramAlphaSize,
		// Token: 0x040027DE RID: 10206
		HistogramLuminanceSize,
		// Token: 0x040027DF RID: 10207
		HistogramSink,
		// Token: 0x040027E0 RID: 10208
		Minmax,
		// Token: 0x040027E1 RID: 10209
		MinmaxFormat,
		// Token: 0x040027E2 RID: 10210
		MinmaxSink,
		// Token: 0x040027E3 RID: 10211
		TableTooLarge,
		// Token: 0x040027E4 RID: 10212
		ColorMatrix = 32945,
		// Token: 0x040027E5 RID: 10213
		ColorMatrixStackDepth,
		// Token: 0x040027E6 RID: 10214
		MaxColorMatrixStackDepth,
		// Token: 0x040027E7 RID: 10215
		PostColorMatrixRedScale,
		// Token: 0x040027E8 RID: 10216
		PostColorMatrixGreenScale,
		// Token: 0x040027E9 RID: 10217
		PostColorMatrixBlueScale,
		// Token: 0x040027EA RID: 10218
		PostColorMatrixAlphaScale,
		// Token: 0x040027EB RID: 10219
		PostColorMatrixRedBias,
		// Token: 0x040027EC RID: 10220
		PostColorMatrixGreenBias,
		// Token: 0x040027ED RID: 10221
		PostColorMatrixBlueBias,
		// Token: 0x040027EE RID: 10222
		PostColorMatrixAlphaBias,
		// Token: 0x040027EF RID: 10223
		ColorTable = 32976,
		// Token: 0x040027F0 RID: 10224
		PostConvolutionColorTable,
		// Token: 0x040027F1 RID: 10225
		PostColorMatrixColorTable,
		// Token: 0x040027F2 RID: 10226
		ProxyColorTable,
		// Token: 0x040027F3 RID: 10227
		ProxyPostConvolutionColorTable,
		// Token: 0x040027F4 RID: 10228
		ProxyPostColorMatrixColorTable,
		// Token: 0x040027F5 RID: 10229
		ColorTableScale,
		// Token: 0x040027F6 RID: 10230
		ColorTableBias,
		// Token: 0x040027F7 RID: 10231
		ColorTableFormat,
		// Token: 0x040027F8 RID: 10232
		ColorTableWidth,
		// Token: 0x040027F9 RID: 10233
		ColorTableRedSize,
		// Token: 0x040027FA RID: 10234
		ColorTableGreenSize,
		// Token: 0x040027FB RID: 10235
		ColorTableBlueSize,
		// Token: 0x040027FC RID: 10236
		ColorTableAlphaSize,
		// Token: 0x040027FD RID: 10237
		ColorTableLuminanceSize,
		// Token: 0x040027FE RID: 10238
		ColorTableIntensitySize,
		// Token: 0x040027FF RID: 10239
		ConstantBorder = 33105,
		// Token: 0x04002800 RID: 10240
		ReplicateBorder = 33107,
		// Token: 0x04002801 RID: 10241
		ConvolutionBorderColor
	}
}
