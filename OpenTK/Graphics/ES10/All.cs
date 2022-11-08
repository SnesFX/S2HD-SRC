using System;

namespace OpenTK.Graphics.ES10
{
	// Token: 0x020004D3 RID: 1235
	public enum All
	{
		// Token: 0x04004ADE RID: 19166
		False,
		// Token: 0x04004ADF RID: 19167
		NoError = 0,
		// Token: 0x04004AE0 RID: 19168
		Zero = 0,
		// Token: 0x04004AE1 RID: 19169
		Points = 0,
		// Token: 0x04004AE2 RID: 19170
		DepthBufferBit = 256,
		// Token: 0x04004AE3 RID: 19171
		StencilBufferBit = 1024,
		// Token: 0x04004AE4 RID: 19172
		ColorBufferBit = 16384,
		// Token: 0x04004AE5 RID: 19173
		Lines = 1,
		// Token: 0x04004AE6 RID: 19174
		LineLoop,
		// Token: 0x04004AE7 RID: 19175
		LineStrip,
		// Token: 0x04004AE8 RID: 19176
		Triangles,
		// Token: 0x04004AE9 RID: 19177
		TriangleStrip,
		// Token: 0x04004AEA RID: 19178
		TriangleFan,
		// Token: 0x04004AEB RID: 19179
		Add = 260,
		// Token: 0x04004AEC RID: 19180
		Never = 512,
		// Token: 0x04004AED RID: 19181
		Less,
		// Token: 0x04004AEE RID: 19182
		Equal,
		// Token: 0x04004AEF RID: 19183
		Lequal,
		// Token: 0x04004AF0 RID: 19184
		Greater,
		// Token: 0x04004AF1 RID: 19185
		Notequal,
		// Token: 0x04004AF2 RID: 19186
		Gequal,
		// Token: 0x04004AF3 RID: 19187
		Always,
		// Token: 0x04004AF4 RID: 19188
		SrcColor = 768,
		// Token: 0x04004AF5 RID: 19189
		OneMinusSrcColor,
		// Token: 0x04004AF6 RID: 19190
		SrcAlpha,
		// Token: 0x04004AF7 RID: 19191
		OneMinusSrcAlpha,
		// Token: 0x04004AF8 RID: 19192
		DstAlpha,
		// Token: 0x04004AF9 RID: 19193
		OneMinusDstAlpha,
		// Token: 0x04004AFA RID: 19194
		DstColor,
		// Token: 0x04004AFB RID: 19195
		OneMinusDstColor,
		// Token: 0x04004AFC RID: 19196
		SrcAlphaSaturate,
		// Token: 0x04004AFD RID: 19197
		Front = 1028,
		// Token: 0x04004AFE RID: 19198
		Back,
		// Token: 0x04004AFF RID: 19199
		FrontAndBack = 1032,
		// Token: 0x04004B00 RID: 19200
		InvalidEnum = 1280,
		// Token: 0x04004B01 RID: 19201
		InvalidValue,
		// Token: 0x04004B02 RID: 19202
		InvalidOperation,
		// Token: 0x04004B03 RID: 19203
		StackOverflow,
		// Token: 0x04004B04 RID: 19204
		StackUnderflow,
		// Token: 0x04004B05 RID: 19205
		OutOfMemory,
		// Token: 0x04004B06 RID: 19206
		Exp = 2048,
		// Token: 0x04004B07 RID: 19207
		Exp2,
		// Token: 0x04004B08 RID: 19208
		Cw = 2304,
		// Token: 0x04004B09 RID: 19209
		Ccw,
		// Token: 0x04004B0A RID: 19210
		PointSmooth = 2832,
		// Token: 0x04004B0B RID: 19211
		SmoothPointSizeRange = 2834,
		// Token: 0x04004B0C RID: 19212
		LineSmooth = 2848,
		// Token: 0x04004B0D RID: 19213
		SmoothLineWidthRange = 2850,
		// Token: 0x04004B0E RID: 19214
		CullFace = 2884,
		// Token: 0x04004B0F RID: 19215
		Lighting = 2896,
		// Token: 0x04004B10 RID: 19216
		LightModelTwoSide = 2898,
		// Token: 0x04004B11 RID: 19217
		LightModelAmbient,
		// Token: 0x04004B12 RID: 19218
		ColorMaterial = 2903,
		// Token: 0x04004B13 RID: 19219
		Fog = 2912,
		// Token: 0x04004B14 RID: 19220
		FogDensity = 2914,
		// Token: 0x04004B15 RID: 19221
		FogStart,
		// Token: 0x04004B16 RID: 19222
		FogEnd,
		// Token: 0x04004B17 RID: 19223
		FogMode,
		// Token: 0x04004B18 RID: 19224
		FogColor,
		// Token: 0x04004B19 RID: 19225
		DepthTest = 2929,
		// Token: 0x04004B1A RID: 19226
		StencilTest = 2960,
		// Token: 0x04004B1B RID: 19227
		Normalize = 2977,
		// Token: 0x04004B1C RID: 19228
		AlphaTest = 3008,
		// Token: 0x04004B1D RID: 19229
		Dither = 3024,
		// Token: 0x04004B1E RID: 19230
		Blend = 3042,
		// Token: 0x04004B1F RID: 19231
		ColorLogicOp = 3058,
		// Token: 0x04004B20 RID: 19232
		ScissorTest = 3089,
		// Token: 0x04004B21 RID: 19233
		PerspectiveCorrectionHint = 3152,
		// Token: 0x04004B22 RID: 19234
		PointSmoothHint,
		// Token: 0x04004B23 RID: 19235
		LineSmoothHint,
		// Token: 0x04004B24 RID: 19236
		PolygonSmoothHint,
		// Token: 0x04004B25 RID: 19237
		FogHint,
		// Token: 0x04004B26 RID: 19238
		UnpackAlignment = 3317,
		// Token: 0x04004B27 RID: 19239
		PackAlignment = 3333,
		// Token: 0x04004B28 RID: 19240
		MaxLights = 3377,
		// Token: 0x04004B29 RID: 19241
		MaxTextureSize = 3379,
		// Token: 0x04004B2A RID: 19242
		MaxModelviewStackDepth = 3382,
		// Token: 0x04004B2B RID: 19243
		MaxProjectionStackDepth = 3384,
		// Token: 0x04004B2C RID: 19244
		MaxTextureStackDepth,
		// Token: 0x04004B2D RID: 19245
		MaxViewportDims,
		// Token: 0x04004B2E RID: 19246
		SubpixelBits = 3408,
		// Token: 0x04004B2F RID: 19247
		RedBits = 3410,
		// Token: 0x04004B30 RID: 19248
		GreenBits,
		// Token: 0x04004B31 RID: 19249
		BlueBits,
		// Token: 0x04004B32 RID: 19250
		AlphaBits,
		// Token: 0x04004B33 RID: 19251
		DepthBits,
		// Token: 0x04004B34 RID: 19252
		StencilBits,
		// Token: 0x04004B35 RID: 19253
		Texture2D = 3553,
		// Token: 0x04004B36 RID: 19254
		DontCare = 4352,
		// Token: 0x04004B37 RID: 19255
		Fastest,
		// Token: 0x04004B38 RID: 19256
		Nicest,
		// Token: 0x04004B39 RID: 19257
		Ambient = 4608,
		// Token: 0x04004B3A RID: 19258
		Diffuse,
		// Token: 0x04004B3B RID: 19259
		Specular,
		// Token: 0x04004B3C RID: 19260
		Position,
		// Token: 0x04004B3D RID: 19261
		SpotDirection,
		// Token: 0x04004B3E RID: 19262
		SpotExponent,
		// Token: 0x04004B3F RID: 19263
		SpotCutoff,
		// Token: 0x04004B40 RID: 19264
		ConstantAttenuation,
		// Token: 0x04004B41 RID: 19265
		LinearAttenuation,
		// Token: 0x04004B42 RID: 19266
		QuadraticAttenuation,
		// Token: 0x04004B43 RID: 19267
		Byte = 5120,
		// Token: 0x04004B44 RID: 19268
		UnsignedByte,
		// Token: 0x04004B45 RID: 19269
		Short,
		// Token: 0x04004B46 RID: 19270
		UnsignedShort,
		// Token: 0x04004B47 RID: 19271
		Float = 5126,
		// Token: 0x04004B48 RID: 19272
		Fixed = 5132,
		// Token: 0x04004B49 RID: 19273
		Clear = 5376,
		// Token: 0x04004B4A RID: 19274
		And,
		// Token: 0x04004B4B RID: 19275
		AndReverse,
		// Token: 0x04004B4C RID: 19276
		Copy,
		// Token: 0x04004B4D RID: 19277
		AndInverted,
		// Token: 0x04004B4E RID: 19278
		Noop,
		// Token: 0x04004B4F RID: 19279
		Xor,
		// Token: 0x04004B50 RID: 19280
		Or,
		// Token: 0x04004B51 RID: 19281
		Nor,
		// Token: 0x04004B52 RID: 19282
		Equiv,
		// Token: 0x04004B53 RID: 19283
		Invert,
		// Token: 0x04004B54 RID: 19284
		OrReverse,
		// Token: 0x04004B55 RID: 19285
		CopyInverted,
		// Token: 0x04004B56 RID: 19286
		OrInverted,
		// Token: 0x04004B57 RID: 19287
		Nand,
		// Token: 0x04004B58 RID: 19288
		Set,
		// Token: 0x04004B59 RID: 19289
		Emission = 5632,
		// Token: 0x04004B5A RID: 19290
		Shininess,
		// Token: 0x04004B5B RID: 19291
		AmbientAndDiffuse,
		// Token: 0x04004B5C RID: 19292
		Modelview = 5888,
		// Token: 0x04004B5D RID: 19293
		Projection,
		// Token: 0x04004B5E RID: 19294
		Texture,
		// Token: 0x04004B5F RID: 19295
		Alpha = 6406,
		// Token: 0x04004B60 RID: 19296
		Rgb,
		// Token: 0x04004B61 RID: 19297
		Rgba,
		// Token: 0x04004B62 RID: 19298
		Luminance,
		// Token: 0x04004B63 RID: 19299
		LuminanceAlpha,
		// Token: 0x04004B64 RID: 19300
		Flat = 7424,
		// Token: 0x04004B65 RID: 19301
		Smooth,
		// Token: 0x04004B66 RID: 19302
		Keep = 7680,
		// Token: 0x04004B67 RID: 19303
		Replace,
		// Token: 0x04004B68 RID: 19304
		Incr,
		// Token: 0x04004B69 RID: 19305
		Decr,
		// Token: 0x04004B6A RID: 19306
		Vendor = 7936,
		// Token: 0x04004B6B RID: 19307
		Renderer,
		// Token: 0x04004B6C RID: 19308
		Version,
		// Token: 0x04004B6D RID: 19309
		Extensions,
		// Token: 0x04004B6E RID: 19310
		Modulate = 8448,
		// Token: 0x04004B6F RID: 19311
		Decal,
		// Token: 0x04004B70 RID: 19312
		TextureEnvMode = 8704,
		// Token: 0x04004B71 RID: 19313
		TextureEnvColor,
		// Token: 0x04004B72 RID: 19314
		TextureEnv = 8960,
		// Token: 0x04004B73 RID: 19315
		Nearest = 9728,
		// Token: 0x04004B74 RID: 19316
		Linear,
		// Token: 0x04004B75 RID: 19317
		NearestMipmapNearest = 9984,
		// Token: 0x04004B76 RID: 19318
		LinearMipmapNearest,
		// Token: 0x04004B77 RID: 19319
		NearestMipmapLinear,
		// Token: 0x04004B78 RID: 19320
		LinearMipmapLinear,
		// Token: 0x04004B79 RID: 19321
		TextureMagFilter = 10240,
		// Token: 0x04004B7A RID: 19322
		TextureMinFilter,
		// Token: 0x04004B7B RID: 19323
		TextureWrapS,
		// Token: 0x04004B7C RID: 19324
		TextureWrapT,
		// Token: 0x04004B7D RID: 19325
		Repeat = 10497,
		// Token: 0x04004B7E RID: 19326
		Light0 = 16384,
		// Token: 0x04004B7F RID: 19327
		Light1,
		// Token: 0x04004B80 RID: 19328
		Light2,
		// Token: 0x04004B81 RID: 19329
		Light3,
		// Token: 0x04004B82 RID: 19330
		Light4,
		// Token: 0x04004B83 RID: 19331
		Light5,
		// Token: 0x04004B84 RID: 19332
		Light6,
		// Token: 0x04004B85 RID: 19333
		Light7,
		// Token: 0x04004B86 RID: 19334
		UnsignedShort4444 = 32819,
		// Token: 0x04004B87 RID: 19335
		UnsignedShort5551,
		// Token: 0x04004B88 RID: 19336
		PolygonOffsetFill = 32823,
		// Token: 0x04004B89 RID: 19337
		RescaleNormal = 32826,
		// Token: 0x04004B8A RID: 19338
		VertexArray = 32884,
		// Token: 0x04004B8B RID: 19339
		NormalArray,
		// Token: 0x04004B8C RID: 19340
		ColorArray,
		// Token: 0x04004B8D RID: 19341
		TextureCoordArray = 32888,
		// Token: 0x04004B8E RID: 19342
		Multisample = 32925,
		// Token: 0x04004B8F RID: 19343
		SampleAlphaToCoverage,
		// Token: 0x04004B90 RID: 19344
		SampleAlphaToOne,
		// Token: 0x04004B91 RID: 19345
		SampleCoverage,
		// Token: 0x04004B92 RID: 19346
		MaxElementsVertices = 33000,
		// Token: 0x04004B93 RID: 19347
		MaxElementsIndices,
		// Token: 0x04004B94 RID: 19348
		ClampToEdge = 33071,
		// Token: 0x04004B95 RID: 19349
		UnsignedShort565 = 33635,
		// Token: 0x04004B96 RID: 19350
		AliasedPointSizeRange = 33901,
		// Token: 0x04004B97 RID: 19351
		AliasedLineWidthRange,
		// Token: 0x04004B98 RID: 19352
		Texture0 = 33984,
		// Token: 0x04004B99 RID: 19353
		Texture1,
		// Token: 0x04004B9A RID: 19354
		Texture2,
		// Token: 0x04004B9B RID: 19355
		Texture3,
		// Token: 0x04004B9C RID: 19356
		Texture4,
		// Token: 0x04004B9D RID: 19357
		Texture5,
		// Token: 0x04004B9E RID: 19358
		Texture6,
		// Token: 0x04004B9F RID: 19359
		Texture7,
		// Token: 0x04004BA0 RID: 19360
		Texture8,
		// Token: 0x04004BA1 RID: 19361
		Texture9,
		// Token: 0x04004BA2 RID: 19362
		Texture10,
		// Token: 0x04004BA3 RID: 19363
		Texture11,
		// Token: 0x04004BA4 RID: 19364
		Texture12,
		// Token: 0x04004BA5 RID: 19365
		Texture13,
		// Token: 0x04004BA6 RID: 19366
		Texture14,
		// Token: 0x04004BA7 RID: 19367
		Texture15,
		// Token: 0x04004BA8 RID: 19368
		Texture16,
		// Token: 0x04004BA9 RID: 19369
		Texture17,
		// Token: 0x04004BAA RID: 19370
		Texture18,
		// Token: 0x04004BAB RID: 19371
		Texture19,
		// Token: 0x04004BAC RID: 19372
		Texture20,
		// Token: 0x04004BAD RID: 19373
		Texture21,
		// Token: 0x04004BAE RID: 19374
		Texture22,
		// Token: 0x04004BAF RID: 19375
		Texture23,
		// Token: 0x04004BB0 RID: 19376
		Texture24,
		// Token: 0x04004BB1 RID: 19377
		Texture25,
		// Token: 0x04004BB2 RID: 19378
		Texture26,
		// Token: 0x04004BB3 RID: 19379
		Texture27,
		// Token: 0x04004BB4 RID: 19380
		Texture28,
		// Token: 0x04004BB5 RID: 19381
		Texture29,
		// Token: 0x04004BB6 RID: 19382
		Texture30,
		// Token: 0x04004BB7 RID: 19383
		Texture31,
		// Token: 0x04004BB8 RID: 19384
		MaxTextureUnits = 34018,
		// Token: 0x04004BB9 RID: 19385
		NumCompressedTextureFormats = 34466,
		// Token: 0x04004BBA RID: 19386
		CompressedTextureFormats,
		// Token: 0x04004BBB RID: 19387
		Palette4Rgb8Oes = 35728,
		// Token: 0x04004BBC RID: 19388
		Palette4Rgba8Oes,
		// Token: 0x04004BBD RID: 19389
		Palette4R5G6B5Oes,
		// Token: 0x04004BBE RID: 19390
		Palette4Rgba4Oes,
		// Token: 0x04004BBF RID: 19391
		Palette4Rgb5A1Oes,
		// Token: 0x04004BC0 RID: 19392
		Palette8Rgb8Oes,
		// Token: 0x04004BC1 RID: 19393
		Palette8Rgba8Oes,
		// Token: 0x04004BC2 RID: 19394
		Palette8R5G6B5Oes,
		// Token: 0x04004BC3 RID: 19395
		Palette8Rgba4Oes,
		// Token: 0x04004BC4 RID: 19396
		Palette8Rgb5A1Oes,
		// Token: 0x04004BC5 RID: 19397
		ImplementationColorReadTypeOes,
		// Token: 0x04004BC6 RID: 19398
		ImplementationColorReadFormatOes,
		// Token: 0x04004BC7 RID: 19399
		OesCompressedPalettedTexture = 1,
		// Token: 0x04004BC8 RID: 19400
		OesReadFormat = 1,
		// Token: 0x04004BC9 RID: 19401
		OesVersion10 = 1,
		// Token: 0x04004BCA RID: 19402
		One = 1,
		// Token: 0x04004BCB RID: 19403
		True = 1
	}
}
