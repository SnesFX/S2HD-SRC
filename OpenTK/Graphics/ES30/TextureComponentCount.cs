using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020008AD RID: 2221
	public enum TextureComponentCount
	{
		// Token: 0x04008D9D RID: 36253
		Alpha = 6406,
		// Token: 0x04008D9E RID: 36254
		Rgb,
		// Token: 0x04008D9F RID: 36255
		Rgba,
		// Token: 0x04008DA0 RID: 36256
		Luminance,
		// Token: 0x04008DA1 RID: 36257
		LuminanceAlpha,
		// Token: 0x04008DA2 RID: 36258
		Alpha8Ext = 32828,
		// Token: 0x04008DA3 RID: 36259
		Luminance8Ext = 32832,
		// Token: 0x04008DA4 RID: 36260
		Luminance8Alpha8Ext = 32837,
		// Token: 0x04008DA5 RID: 36261
		Rgb8 = 32849,
		// Token: 0x04008DA6 RID: 36262
		Rgb10Ext,
		// Token: 0x04008DA7 RID: 36263
		Rgba4 = 32854,
		// Token: 0x04008DA8 RID: 36264
		Rgb5A1,
		// Token: 0x04008DA9 RID: 36265
		Rgba8,
		// Token: 0x04008DAA RID: 36266
		Rgb10A2,
		// Token: 0x04008DAB RID: 36267
		Rgb10A2Ext = 32857,
		// Token: 0x04008DAC RID: 36268
		DepthComponent16 = 33189,
		// Token: 0x04008DAD RID: 36269
		DepthComponent24,
		// Token: 0x04008DAE RID: 36270
		R8 = 33321,
		// Token: 0x04008DAF RID: 36271
		R8Ext = 33321,
		// Token: 0x04008DB0 RID: 36272
		Rg8 = 33323,
		// Token: 0x04008DB1 RID: 36273
		Rg8Ext = 33323,
		// Token: 0x04008DB2 RID: 36274
		R16f = 33325,
		// Token: 0x04008DB3 RID: 36275
		R16fExt = 33325,
		// Token: 0x04008DB4 RID: 36276
		R32f,
		// Token: 0x04008DB5 RID: 36277
		R32fExt = 33326,
		// Token: 0x04008DB6 RID: 36278
		Rg16f,
		// Token: 0x04008DB7 RID: 36279
		Rg16fExt = 33327,
		// Token: 0x04008DB8 RID: 36280
		Rg32f,
		// Token: 0x04008DB9 RID: 36281
		Rg32fExt = 33328,
		// Token: 0x04008DBA RID: 36282
		R8i,
		// Token: 0x04008DBB RID: 36283
		R8ui,
		// Token: 0x04008DBC RID: 36284
		R16i,
		// Token: 0x04008DBD RID: 36285
		R16ui,
		// Token: 0x04008DBE RID: 36286
		R32i,
		// Token: 0x04008DBF RID: 36287
		R32ui,
		// Token: 0x04008DC0 RID: 36288
		Rg8i,
		// Token: 0x04008DC1 RID: 36289
		Rg8ui,
		// Token: 0x04008DC2 RID: 36290
		Rg16i,
		// Token: 0x04008DC3 RID: 36291
		Rg16ui,
		// Token: 0x04008DC4 RID: 36292
		Rg32i,
		// Token: 0x04008DC5 RID: 36293
		Rg32ui,
		// Token: 0x04008DC6 RID: 36294
		Rgba32f = 34836,
		// Token: 0x04008DC7 RID: 36295
		Rgba32fExt = 34836,
		// Token: 0x04008DC8 RID: 36296
		Rgb32f,
		// Token: 0x04008DC9 RID: 36297
		Rgb32fExt = 34837,
		// Token: 0x04008DCA RID: 36298
		Alpha32fExt,
		// Token: 0x04008DCB RID: 36299
		Luminance32fExt = 34840,
		// Token: 0x04008DCC RID: 36300
		LuminanceAlpha32fExt,
		// Token: 0x04008DCD RID: 36301
		Rgba16f,
		// Token: 0x04008DCE RID: 36302
		Rgba16fExt = 34842,
		// Token: 0x04008DCF RID: 36303
		Rgb16f,
		// Token: 0x04008DD0 RID: 36304
		Rgb16fExt = 34843,
		// Token: 0x04008DD1 RID: 36305
		Alpha16fExt,
		// Token: 0x04008DD2 RID: 36306
		Luminance16fExt = 34846,
		// Token: 0x04008DD3 RID: 36307
		LuminanceAlpha16fExt,
		// Token: 0x04008DD4 RID: 36308
		Depth24Stencil8 = 35056,
		// Token: 0x04008DD5 RID: 36309
		RgbRaw422Apple = 35409,
		// Token: 0x04008DD6 RID: 36310
		R11fG11fB10f = 35898,
		// Token: 0x04008DD7 RID: 36311
		Rgb9E5 = 35901,
		// Token: 0x04008DD8 RID: 36312
		Srgb8 = 35905,
		// Token: 0x04008DD9 RID: 36313
		Srgb8Alpha8 = 35907,
		// Token: 0x04008DDA RID: 36314
		DepthComponent32f = 36012,
		// Token: 0x04008DDB RID: 36315
		Depth32fStencil8,
		// Token: 0x04008DDC RID: 36316
		Rgb565 = 36194,
		// Token: 0x04008DDD RID: 36317
		Rgba32ui = 36208,
		// Token: 0x04008DDE RID: 36318
		Rgb32ui,
		// Token: 0x04008DDF RID: 36319
		Rgba16ui = 36214,
		// Token: 0x04008DE0 RID: 36320
		Rgb16ui,
		// Token: 0x04008DE1 RID: 36321
		Rgba8ui = 36220,
		// Token: 0x04008DE2 RID: 36322
		Rgb8ui,
		// Token: 0x04008DE3 RID: 36323
		Rgba32i = 36226,
		// Token: 0x04008DE4 RID: 36324
		Rgb32i,
		// Token: 0x04008DE5 RID: 36325
		Rgba16i = 36232,
		// Token: 0x04008DE6 RID: 36326
		Rgb16i,
		// Token: 0x04008DE7 RID: 36327
		Rgba8i = 36238,
		// Token: 0x04008DE8 RID: 36328
		Rgb8i,
		// Token: 0x04008DE9 RID: 36329
		R8Snorm = 36756,
		// Token: 0x04008DEA RID: 36330
		Rg8Snorm,
		// Token: 0x04008DEB RID: 36331
		Rgb8Snorm,
		// Token: 0x04008DEC RID: 36332
		Rgba8Snorm,
		// Token: 0x04008DED RID: 36333
		Rgb10A2ui = 36975,
		// Token: 0x04008DEE RID: 36334
		Bgra8Ext = 37793
	}
}
