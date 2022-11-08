using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x0200075D RID: 1885
	public enum Version30
	{
		// Token: 0x040071B3 RID: 29107
		ContextFlagForwardCompatibleBit = 1,
		// Token: 0x040071B4 RID: 29108
		MapReadBit = 1,
		// Token: 0x040071B5 RID: 29109
		MapWriteBit,
		// Token: 0x040071B6 RID: 29110
		MapInvalidateRangeBit = 4,
		// Token: 0x040071B7 RID: 29111
		MapInvalidateBufferBit = 8,
		// Token: 0x040071B8 RID: 29112
		MapFlushExplicitBit = 16,
		// Token: 0x040071B9 RID: 29113
		MapUnsynchronizedBit = 32,
		// Token: 0x040071BA RID: 29114
		InvalidFramebufferOperation = 1286,
		// Token: 0x040071BB RID: 29115
		MaxClipDistances = 3378,
		// Token: 0x040071BC RID: 29116
		HalfFloat = 5131,
		// Token: 0x040071BD RID: 29117
		ClipDistance0 = 12288,
		// Token: 0x040071BE RID: 29118
		ClipDistance1,
		// Token: 0x040071BF RID: 29119
		ClipDistance2,
		// Token: 0x040071C0 RID: 29120
		ClipDistance3,
		// Token: 0x040071C1 RID: 29121
		ClipDistance4,
		// Token: 0x040071C2 RID: 29122
		ClipDistance5,
		// Token: 0x040071C3 RID: 29123
		ClipDistance6,
		// Token: 0x040071C4 RID: 29124
		ClipDistance7,
		// Token: 0x040071C5 RID: 29125
		FramebufferAttachmentColorEncoding = 33296,
		// Token: 0x040071C6 RID: 29126
		FramebufferAttachmentComponentType,
		// Token: 0x040071C7 RID: 29127
		FramebufferAttachmentRedSize,
		// Token: 0x040071C8 RID: 29128
		FramebufferAttachmentGreenSize,
		// Token: 0x040071C9 RID: 29129
		FramebufferAttachmentBlueSize,
		// Token: 0x040071CA RID: 29130
		FramebufferAttachmentAlphaSize,
		// Token: 0x040071CB RID: 29131
		FramebufferAttachmentDepthSize,
		// Token: 0x040071CC RID: 29132
		FramebufferAttachmentStencilSize,
		// Token: 0x040071CD RID: 29133
		FramebufferDefault,
		// Token: 0x040071CE RID: 29134
		FramebufferUndefined,
		// Token: 0x040071CF RID: 29135
		DepthStencilAttachment,
		// Token: 0x040071D0 RID: 29136
		MajorVersion,
		// Token: 0x040071D1 RID: 29137
		MinorVersion,
		// Token: 0x040071D2 RID: 29138
		NumExtensions,
		// Token: 0x040071D3 RID: 29139
		ContextFlags,
		// Token: 0x040071D4 RID: 29140
		Index = 33314,
		// Token: 0x040071D5 RID: 29141
		CompressedRed = 33317,
		// Token: 0x040071D6 RID: 29142
		CompressedRg,
		// Token: 0x040071D7 RID: 29143
		Rg,
		// Token: 0x040071D8 RID: 29144
		RgInteger,
		// Token: 0x040071D9 RID: 29145
		R8,
		// Token: 0x040071DA RID: 29146
		R16,
		// Token: 0x040071DB RID: 29147
		Rg8,
		// Token: 0x040071DC RID: 29148
		Rg16,
		// Token: 0x040071DD RID: 29149
		R16f,
		// Token: 0x040071DE RID: 29150
		R32f,
		// Token: 0x040071DF RID: 29151
		Rg16f,
		// Token: 0x040071E0 RID: 29152
		Rg32f,
		// Token: 0x040071E1 RID: 29153
		R8i,
		// Token: 0x040071E2 RID: 29154
		R8ui,
		// Token: 0x040071E3 RID: 29155
		R16i,
		// Token: 0x040071E4 RID: 29156
		R16ui,
		// Token: 0x040071E5 RID: 29157
		R32i,
		// Token: 0x040071E6 RID: 29158
		R32ui,
		// Token: 0x040071E7 RID: 29159
		Rg8i,
		// Token: 0x040071E8 RID: 29160
		Rg8ui,
		// Token: 0x040071E9 RID: 29161
		Rg16i,
		// Token: 0x040071EA RID: 29162
		Rg16ui,
		// Token: 0x040071EB RID: 29163
		Rg32i,
		// Token: 0x040071EC RID: 29164
		Rg32ui,
		// Token: 0x040071ED RID: 29165
		MaxRenderbufferSize = 34024,
		// Token: 0x040071EE RID: 29166
		DepthStencil = 34041,
		// Token: 0x040071EF RID: 29167
		UnsignedInt248,
		// Token: 0x040071F0 RID: 29168
		VertexArrayBinding = 34229,
		// Token: 0x040071F1 RID: 29169
		Rgba32f = 34836,
		// Token: 0x040071F2 RID: 29170
		Rgb32f,
		// Token: 0x040071F3 RID: 29171
		Rgba16f = 34842,
		// Token: 0x040071F4 RID: 29172
		Rgb16f,
		// Token: 0x040071F5 RID: 29173
		CompareRefToTexture = 34894,
		// Token: 0x040071F6 RID: 29174
		Depth24Stencil8 = 35056,
		// Token: 0x040071F7 RID: 29175
		TextureStencilSize,
		// Token: 0x040071F8 RID: 29176
		VertexAttribArrayInteger = 35069,
		// Token: 0x040071F9 RID: 29177
		MaxArrayTextureLayers = 35071,
		// Token: 0x040071FA RID: 29178
		MinProgramTexelOffset = 35076,
		// Token: 0x040071FB RID: 29179
		MaxProgramTexelOffset,
		// Token: 0x040071FC RID: 29180
		ClampReadColor = 35100,
		// Token: 0x040071FD RID: 29181
		FixedOnly,
		// Token: 0x040071FE RID: 29182
		MaxVaryingComponents = 35659,
		// Token: 0x040071FF RID: 29183
		TextureRedType = 35856,
		// Token: 0x04007200 RID: 29184
		TextureGreenType,
		// Token: 0x04007201 RID: 29185
		TextureBlueType,
		// Token: 0x04007202 RID: 29186
		TextureAlphaType,
		// Token: 0x04007203 RID: 29187
		TextureDepthType = 35862,
		// Token: 0x04007204 RID: 29188
		UnsignedNormalized,
		// Token: 0x04007205 RID: 29189
		Texture1DArray,
		// Token: 0x04007206 RID: 29190
		ProxyTexture1DArray,
		// Token: 0x04007207 RID: 29191
		Texture2DArray,
		// Token: 0x04007208 RID: 29192
		ProxyTexture2DArray,
		// Token: 0x04007209 RID: 29193
		TextureBinding1DArray,
		// Token: 0x0400720A RID: 29194
		TextureBinding2DArray,
		// Token: 0x0400720B RID: 29195
		R11fG11fB10f = 35898,
		// Token: 0x0400720C RID: 29196
		UnsignedInt10F11F11FRev,
		// Token: 0x0400720D RID: 29197
		Rgb9E5 = 35901,
		// Token: 0x0400720E RID: 29198
		UnsignedInt5999Rev,
		// Token: 0x0400720F RID: 29199
		TextureSharedSize,
		// Token: 0x04007210 RID: 29200
		TransformFeedbackVaryingMaxLength = 35958,
		// Token: 0x04007211 RID: 29201
		TransformFeedbackBufferMode = 35967,
		// Token: 0x04007212 RID: 29202
		MaxTransformFeedbackSeparateComponents,
		// Token: 0x04007213 RID: 29203
		TransformFeedbackVaryings = 35971,
		// Token: 0x04007214 RID: 29204
		TransformFeedbackBufferStart,
		// Token: 0x04007215 RID: 29205
		TransformFeedbackBufferSize,
		// Token: 0x04007216 RID: 29206
		PrimitivesGenerated = 35975,
		// Token: 0x04007217 RID: 29207
		TransformFeedbackPrimitivesWritten,
		// Token: 0x04007218 RID: 29208
		RasterizerDiscard,
		// Token: 0x04007219 RID: 29209
		MaxTransformFeedbackInterleavedComponents,
		// Token: 0x0400721A RID: 29210
		MaxTransformFeedbackSeparateAttribs,
		// Token: 0x0400721B RID: 29211
		InterleavedAttribs,
		// Token: 0x0400721C RID: 29212
		SeparateAttribs,
		// Token: 0x0400721D RID: 29213
		TransformFeedbackBuffer,
		// Token: 0x0400721E RID: 29214
		TransformFeedbackBufferBinding,
		// Token: 0x0400721F RID: 29215
		DrawFramebufferBinding = 36006,
		// Token: 0x04007220 RID: 29216
		FramebufferBinding = 36006,
		// Token: 0x04007221 RID: 29217
		RenderbufferBinding,
		// Token: 0x04007222 RID: 29218
		ReadFramebuffer,
		// Token: 0x04007223 RID: 29219
		DrawFramebuffer,
		// Token: 0x04007224 RID: 29220
		ReadFramebufferBinding,
		// Token: 0x04007225 RID: 29221
		RenderbufferSamples,
		// Token: 0x04007226 RID: 29222
		DepthComponent32f,
		// Token: 0x04007227 RID: 29223
		Depth32fStencil8,
		// Token: 0x04007228 RID: 29224
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x04007229 RID: 29225
		FramebufferAttachmentObjectName,
		// Token: 0x0400722A RID: 29226
		FramebufferAttachmentTextureLevel,
		// Token: 0x0400722B RID: 29227
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x0400722C RID: 29228
		FramebufferAttachmentTextureLayer,
		// Token: 0x0400722D RID: 29229
		FramebufferComplete,
		// Token: 0x0400722E RID: 29230
		FramebufferIncompleteAttachment,
		// Token: 0x0400722F RID: 29231
		FramebufferIncompleteMissingAttachment,
		// Token: 0x04007230 RID: 29232
		FramebufferIncompleteDrawBuffer = 36059,
		// Token: 0x04007231 RID: 29233
		FramebufferIncompleteReadBuffer,
		// Token: 0x04007232 RID: 29234
		FramebufferUnsupported,
		// Token: 0x04007233 RID: 29235
		MaxColorAttachments = 36063,
		// Token: 0x04007234 RID: 29236
		ColorAttachment0,
		// Token: 0x04007235 RID: 29237
		ColorAttachment1,
		// Token: 0x04007236 RID: 29238
		ColorAttachment2,
		// Token: 0x04007237 RID: 29239
		ColorAttachment3,
		// Token: 0x04007238 RID: 29240
		ColorAttachment4,
		// Token: 0x04007239 RID: 29241
		ColorAttachment5,
		// Token: 0x0400723A RID: 29242
		ColorAttachment6,
		// Token: 0x0400723B RID: 29243
		ColorAttachment7,
		// Token: 0x0400723C RID: 29244
		ColorAttachment8,
		// Token: 0x0400723D RID: 29245
		ColorAttachment9,
		// Token: 0x0400723E RID: 29246
		ColorAttachment10,
		// Token: 0x0400723F RID: 29247
		ColorAttachment11,
		// Token: 0x04007240 RID: 29248
		ColorAttachment12,
		// Token: 0x04007241 RID: 29249
		ColorAttachment13,
		// Token: 0x04007242 RID: 29250
		ColorAttachment14,
		// Token: 0x04007243 RID: 29251
		ColorAttachment15,
		// Token: 0x04007244 RID: 29252
		DepthAttachment = 36096,
		// Token: 0x04007245 RID: 29253
		StencilAttachment = 36128,
		// Token: 0x04007246 RID: 29254
		Framebuffer = 36160,
		// Token: 0x04007247 RID: 29255
		Renderbuffer,
		// Token: 0x04007248 RID: 29256
		RenderbufferWidth,
		// Token: 0x04007249 RID: 29257
		RenderbufferHeight,
		// Token: 0x0400724A RID: 29258
		RenderbufferInternalFormat,
		// Token: 0x0400724B RID: 29259
		StencilIndex1 = 36166,
		// Token: 0x0400724C RID: 29260
		StencilIndex4,
		// Token: 0x0400724D RID: 29261
		StencilIndex8,
		// Token: 0x0400724E RID: 29262
		StencilIndex16,
		// Token: 0x0400724F RID: 29263
		RenderbufferRedSize = 36176,
		// Token: 0x04007250 RID: 29264
		RenderbufferGreenSize,
		// Token: 0x04007251 RID: 29265
		RenderbufferBlueSize,
		// Token: 0x04007252 RID: 29266
		RenderbufferAlphaSize,
		// Token: 0x04007253 RID: 29267
		RenderbufferDepthSize,
		// Token: 0x04007254 RID: 29268
		RenderbufferStencilSize,
		// Token: 0x04007255 RID: 29269
		FramebufferIncompleteMultisample,
		// Token: 0x04007256 RID: 29270
		MaxSamples,
		// Token: 0x04007257 RID: 29271
		Rgba32ui = 36208,
		// Token: 0x04007258 RID: 29272
		Rgb32ui,
		// Token: 0x04007259 RID: 29273
		Rgba16ui = 36214,
		// Token: 0x0400725A RID: 29274
		Rgb16ui,
		// Token: 0x0400725B RID: 29275
		Rgba8ui = 36220,
		// Token: 0x0400725C RID: 29276
		Rgb8ui,
		// Token: 0x0400725D RID: 29277
		Rgba32i = 36226,
		// Token: 0x0400725E RID: 29278
		Rgb32i,
		// Token: 0x0400725F RID: 29279
		Rgba16i = 36232,
		// Token: 0x04007260 RID: 29280
		Rgb16i,
		// Token: 0x04007261 RID: 29281
		Rgba8i = 36238,
		// Token: 0x04007262 RID: 29282
		Rgb8i,
		// Token: 0x04007263 RID: 29283
		RedInteger = 36244,
		// Token: 0x04007264 RID: 29284
		GreenInteger,
		// Token: 0x04007265 RID: 29285
		BlueInteger,
		// Token: 0x04007266 RID: 29286
		RgbInteger = 36248,
		// Token: 0x04007267 RID: 29287
		RgbaInteger,
		// Token: 0x04007268 RID: 29288
		BgrInteger,
		// Token: 0x04007269 RID: 29289
		BgraInteger,
		// Token: 0x0400726A RID: 29290
		Float32UnsignedInt248Rev = 36269,
		// Token: 0x0400726B RID: 29291
		FramebufferSrgb = 36281,
		// Token: 0x0400726C RID: 29292
		CompressedRedRgtc1 = 36283,
		// Token: 0x0400726D RID: 29293
		CompressedSignedRedRgtc1,
		// Token: 0x0400726E RID: 29294
		CompressedRgRgtc2,
		// Token: 0x0400726F RID: 29295
		CompressedSignedRgRgtc2,
		// Token: 0x04007270 RID: 29296
		Sampler1DArray = 36288,
		// Token: 0x04007271 RID: 29297
		Sampler2DArray,
		// Token: 0x04007272 RID: 29298
		Sampler1DArrayShadow = 36291,
		// Token: 0x04007273 RID: 29299
		Sampler2DArrayShadow,
		// Token: 0x04007274 RID: 29300
		SamplerCubeShadow,
		// Token: 0x04007275 RID: 29301
		UnsignedIntVec2,
		// Token: 0x04007276 RID: 29302
		UnsignedIntVec3,
		// Token: 0x04007277 RID: 29303
		UnsignedIntVec4,
		// Token: 0x04007278 RID: 29304
		IntSampler1D,
		// Token: 0x04007279 RID: 29305
		IntSampler2D,
		// Token: 0x0400727A RID: 29306
		IntSampler3D,
		// Token: 0x0400727B RID: 29307
		IntSamplerCube,
		// Token: 0x0400727C RID: 29308
		IntSampler1DArray = 36302,
		// Token: 0x0400727D RID: 29309
		IntSampler2DArray,
		// Token: 0x0400727E RID: 29310
		UnsignedIntSampler1D = 36305,
		// Token: 0x0400727F RID: 29311
		UnsignedIntSampler2D,
		// Token: 0x04007280 RID: 29312
		UnsignedIntSampler3D,
		// Token: 0x04007281 RID: 29313
		UnsignedIntSamplerCube,
		// Token: 0x04007282 RID: 29314
		UnsignedIntSampler1DArray = 36310,
		// Token: 0x04007283 RID: 29315
		UnsignedIntSampler2DArray,
		// Token: 0x04007284 RID: 29316
		QueryWait = 36371,
		// Token: 0x04007285 RID: 29317
		QueryNoWait,
		// Token: 0x04007286 RID: 29318
		QueryByRegionWait,
		// Token: 0x04007287 RID: 29319
		QueryByRegionNoWait,
		// Token: 0x04007288 RID: 29320
		BufferAccessFlags = 37151,
		// Token: 0x04007289 RID: 29321
		BufferMapLength,
		// Token: 0x0400728A RID: 29322
		BufferMapOffset
	}
}
