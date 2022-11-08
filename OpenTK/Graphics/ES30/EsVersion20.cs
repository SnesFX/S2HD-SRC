using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020007C3 RID: 1987
	public enum EsVersion20
	{
		// Token: 0x040080CA RID: 32970
		False,
		// Token: 0x040080CB RID: 32971
		NoError = 0,
		// Token: 0x040080CC RID: 32972
		None = 0,
		// Token: 0x040080CD RID: 32973
		Zero = 0,
		// Token: 0x040080CE RID: 32974
		Points = 0,
		// Token: 0x040080CF RID: 32975
		DepthBufferBit = 256,
		// Token: 0x040080D0 RID: 32976
		StencilBufferBit = 1024,
		// Token: 0x040080D1 RID: 32977
		ColorBufferBit = 16384,
		// Token: 0x040080D2 RID: 32978
		Lines = 1,
		// Token: 0x040080D3 RID: 32979
		LineLoop,
		// Token: 0x040080D4 RID: 32980
		LineStrip,
		// Token: 0x040080D5 RID: 32981
		Triangles,
		// Token: 0x040080D6 RID: 32982
		TriangleStrip,
		// Token: 0x040080D7 RID: 32983
		TriangleFan,
		// Token: 0x040080D8 RID: 32984
		Never = 512,
		// Token: 0x040080D9 RID: 32985
		Less,
		// Token: 0x040080DA RID: 32986
		Equal,
		// Token: 0x040080DB RID: 32987
		Lequal,
		// Token: 0x040080DC RID: 32988
		Greater,
		// Token: 0x040080DD RID: 32989
		Notequal,
		// Token: 0x040080DE RID: 32990
		Gequal,
		// Token: 0x040080DF RID: 32991
		Always,
		// Token: 0x040080E0 RID: 32992
		SrcColor = 768,
		// Token: 0x040080E1 RID: 32993
		OneMinusSrcColor,
		// Token: 0x040080E2 RID: 32994
		SrcAlpha,
		// Token: 0x040080E3 RID: 32995
		OneMinusSrcAlpha,
		// Token: 0x040080E4 RID: 32996
		DstAlpha,
		// Token: 0x040080E5 RID: 32997
		OneMinusDstAlpha,
		// Token: 0x040080E6 RID: 32998
		DstColor,
		// Token: 0x040080E7 RID: 32999
		OneMinusDstColor,
		// Token: 0x040080E8 RID: 33000
		SrcAlphaSaturate,
		// Token: 0x040080E9 RID: 33001
		Front = 1028,
		// Token: 0x040080EA RID: 33002
		Back,
		// Token: 0x040080EB RID: 33003
		FrontAndBack = 1032,
		// Token: 0x040080EC RID: 33004
		InvalidEnum = 1280,
		// Token: 0x040080ED RID: 33005
		InvalidValue,
		// Token: 0x040080EE RID: 33006
		InvalidOperation,
		// Token: 0x040080EF RID: 33007
		OutOfMemory = 1285,
		// Token: 0x040080F0 RID: 33008
		InvalidFramebufferOperation,
		// Token: 0x040080F1 RID: 33009
		Cw = 2304,
		// Token: 0x040080F2 RID: 33010
		Ccw,
		// Token: 0x040080F3 RID: 33011
		LineWidth = 2849,
		// Token: 0x040080F4 RID: 33012
		CullFace = 2884,
		// Token: 0x040080F5 RID: 33013
		CullFaceMode,
		// Token: 0x040080F6 RID: 33014
		FrontFace,
		// Token: 0x040080F7 RID: 33015
		DepthRange = 2928,
		// Token: 0x040080F8 RID: 33016
		DepthTest,
		// Token: 0x040080F9 RID: 33017
		DepthWritemask,
		// Token: 0x040080FA RID: 33018
		DepthClearValue,
		// Token: 0x040080FB RID: 33019
		DepthFunc,
		// Token: 0x040080FC RID: 33020
		StencilTest = 2960,
		// Token: 0x040080FD RID: 33021
		StencilClearValue,
		// Token: 0x040080FE RID: 33022
		StencilFunc,
		// Token: 0x040080FF RID: 33023
		StencilValueMask,
		// Token: 0x04008100 RID: 33024
		StencilFail,
		// Token: 0x04008101 RID: 33025
		StencilPassDepthFail,
		// Token: 0x04008102 RID: 33026
		StencilPassDepthPass,
		// Token: 0x04008103 RID: 33027
		StencilRef,
		// Token: 0x04008104 RID: 33028
		StencilWritemask,
		// Token: 0x04008105 RID: 33029
		Viewport = 2978,
		// Token: 0x04008106 RID: 33030
		Dither = 3024,
		// Token: 0x04008107 RID: 33031
		Blend = 3042,
		// Token: 0x04008108 RID: 33032
		ScissorBox = 3088,
		// Token: 0x04008109 RID: 33033
		ScissorTest,
		// Token: 0x0400810A RID: 33034
		ColorClearValue = 3106,
		// Token: 0x0400810B RID: 33035
		ColorWritemask,
		// Token: 0x0400810C RID: 33036
		UnpackAlignment = 3317,
		// Token: 0x0400810D RID: 33037
		PackAlignment = 3333,
		// Token: 0x0400810E RID: 33038
		MaxTextureSize = 3379,
		// Token: 0x0400810F RID: 33039
		MaxViewportDims = 3386,
		// Token: 0x04008110 RID: 33040
		SubpixelBits = 3408,
		// Token: 0x04008111 RID: 33041
		RedBits = 3410,
		// Token: 0x04008112 RID: 33042
		GreenBits,
		// Token: 0x04008113 RID: 33043
		BlueBits,
		// Token: 0x04008114 RID: 33044
		AlphaBits,
		// Token: 0x04008115 RID: 33045
		DepthBits,
		// Token: 0x04008116 RID: 33046
		StencilBits,
		// Token: 0x04008117 RID: 33047
		Texture2D = 3553,
		// Token: 0x04008118 RID: 33048
		DontCare = 4352,
		// Token: 0x04008119 RID: 33049
		Fastest,
		// Token: 0x0400811A RID: 33050
		Nicest,
		// Token: 0x0400811B RID: 33051
		Byte = 5120,
		// Token: 0x0400811C RID: 33052
		UnsignedByte,
		// Token: 0x0400811D RID: 33053
		Short,
		// Token: 0x0400811E RID: 33054
		UnsignedShort,
		// Token: 0x0400811F RID: 33055
		Int,
		// Token: 0x04008120 RID: 33056
		UnsignedInt,
		// Token: 0x04008121 RID: 33057
		Float,
		// Token: 0x04008122 RID: 33058
		Fixed = 5132,
		// Token: 0x04008123 RID: 33059
		Invert = 5386,
		// Token: 0x04008124 RID: 33060
		Texture = 5890,
		// Token: 0x04008125 RID: 33061
		DepthComponent = 6402,
		// Token: 0x04008126 RID: 33062
		Alpha = 6406,
		// Token: 0x04008127 RID: 33063
		Rgb,
		// Token: 0x04008128 RID: 33064
		Rgba,
		// Token: 0x04008129 RID: 33065
		Luminance,
		// Token: 0x0400812A RID: 33066
		LuminanceAlpha,
		// Token: 0x0400812B RID: 33067
		Keep = 7680,
		// Token: 0x0400812C RID: 33068
		Replace,
		// Token: 0x0400812D RID: 33069
		Incr,
		// Token: 0x0400812E RID: 33070
		Decr,
		// Token: 0x0400812F RID: 33071
		Vendor = 7936,
		// Token: 0x04008130 RID: 33072
		Renderer,
		// Token: 0x04008131 RID: 33073
		Version,
		// Token: 0x04008132 RID: 33074
		Extensions,
		// Token: 0x04008133 RID: 33075
		Nearest = 9728,
		// Token: 0x04008134 RID: 33076
		Linear,
		// Token: 0x04008135 RID: 33077
		NearestMipmapNearest = 9984,
		// Token: 0x04008136 RID: 33078
		LinearMipmapNearest,
		// Token: 0x04008137 RID: 33079
		NearestMipmapLinear,
		// Token: 0x04008138 RID: 33080
		LinearMipmapLinear,
		// Token: 0x04008139 RID: 33081
		TextureMagFilter = 10240,
		// Token: 0x0400813A RID: 33082
		TextureMinFilter,
		// Token: 0x0400813B RID: 33083
		TextureWrapS,
		// Token: 0x0400813C RID: 33084
		TextureWrapT,
		// Token: 0x0400813D RID: 33085
		Repeat = 10497,
		// Token: 0x0400813E RID: 33086
		PolygonOffsetUnits = 10752,
		// Token: 0x0400813F RID: 33087
		ConstantColor = 32769,
		// Token: 0x04008140 RID: 33088
		OneMinusConstantColor,
		// Token: 0x04008141 RID: 33089
		ConstantAlpha,
		// Token: 0x04008142 RID: 33090
		OneMinusConstantAlpha,
		// Token: 0x04008143 RID: 33091
		BlendColor,
		// Token: 0x04008144 RID: 33092
		FuncAdd,
		// Token: 0x04008145 RID: 33093
		BlendEquation = 32777,
		// Token: 0x04008146 RID: 33094
		BlendEquationRgb = 32777,
		// Token: 0x04008147 RID: 33095
		FuncSubtract,
		// Token: 0x04008148 RID: 33096
		FuncReverseSubtract,
		// Token: 0x04008149 RID: 33097
		UnsignedShort4444 = 32819,
		// Token: 0x0400814A RID: 33098
		UnsignedShort5551,
		// Token: 0x0400814B RID: 33099
		PolygonOffsetFill = 32823,
		// Token: 0x0400814C RID: 33100
		PolygonOffsetFactor,
		// Token: 0x0400814D RID: 33101
		Rgba4 = 32854,
		// Token: 0x0400814E RID: 33102
		Rgb5A1,
		// Token: 0x0400814F RID: 33103
		TextureBinding2D = 32873,
		// Token: 0x04008150 RID: 33104
		SampleAlphaToCoverage = 32926,
		// Token: 0x04008151 RID: 33105
		SampleCoverage = 32928,
		// Token: 0x04008152 RID: 33106
		SampleBuffers = 32936,
		// Token: 0x04008153 RID: 33107
		Samples,
		// Token: 0x04008154 RID: 33108
		SampleCoverageValue,
		// Token: 0x04008155 RID: 33109
		SampleCoverageInvert,
		// Token: 0x04008156 RID: 33110
		BlendDstRgb = 32968,
		// Token: 0x04008157 RID: 33111
		BlendSrcRgb,
		// Token: 0x04008158 RID: 33112
		BlendDstAlpha,
		// Token: 0x04008159 RID: 33113
		BlendSrcAlpha,
		// Token: 0x0400815A RID: 33114
		ClampToEdge = 33071,
		// Token: 0x0400815B RID: 33115
		GenerateMipmapHint = 33170,
		// Token: 0x0400815C RID: 33116
		DepthComponent16 = 33189,
		// Token: 0x0400815D RID: 33117
		UnsignedShort565 = 33635,
		// Token: 0x0400815E RID: 33118
		MirroredRepeat = 33648,
		// Token: 0x0400815F RID: 33119
		AliasedPointSizeRange = 33901,
		// Token: 0x04008160 RID: 33120
		AliasedLineWidthRange,
		// Token: 0x04008161 RID: 33121
		Texture0 = 33984,
		// Token: 0x04008162 RID: 33122
		Texture1,
		// Token: 0x04008163 RID: 33123
		Texture2,
		// Token: 0x04008164 RID: 33124
		Texture3,
		// Token: 0x04008165 RID: 33125
		Texture4,
		// Token: 0x04008166 RID: 33126
		Texture5,
		// Token: 0x04008167 RID: 33127
		Texture6,
		// Token: 0x04008168 RID: 33128
		Texture7,
		// Token: 0x04008169 RID: 33129
		Texture8,
		// Token: 0x0400816A RID: 33130
		Texture9,
		// Token: 0x0400816B RID: 33131
		Texture10,
		// Token: 0x0400816C RID: 33132
		Texture11,
		// Token: 0x0400816D RID: 33133
		Texture12,
		// Token: 0x0400816E RID: 33134
		Texture13,
		// Token: 0x0400816F RID: 33135
		Texture14,
		// Token: 0x04008170 RID: 33136
		Texture15,
		// Token: 0x04008171 RID: 33137
		Texture16,
		// Token: 0x04008172 RID: 33138
		Texture17,
		// Token: 0x04008173 RID: 33139
		Texture18,
		// Token: 0x04008174 RID: 33140
		Texture19,
		// Token: 0x04008175 RID: 33141
		Texture20,
		// Token: 0x04008176 RID: 33142
		Texture21,
		// Token: 0x04008177 RID: 33143
		Texture22,
		// Token: 0x04008178 RID: 33144
		Texture23,
		// Token: 0x04008179 RID: 33145
		Texture24,
		// Token: 0x0400817A RID: 33146
		Texture25,
		// Token: 0x0400817B RID: 33147
		Texture26,
		// Token: 0x0400817C RID: 33148
		Texture27,
		// Token: 0x0400817D RID: 33149
		Texture28,
		// Token: 0x0400817E RID: 33150
		Texture29,
		// Token: 0x0400817F RID: 33151
		Texture30,
		// Token: 0x04008180 RID: 33152
		Texture31,
		// Token: 0x04008181 RID: 33153
		ActiveTexture,
		// Token: 0x04008182 RID: 33154
		MaxRenderbufferSize = 34024,
		// Token: 0x04008183 RID: 33155
		IncrWrap = 34055,
		// Token: 0x04008184 RID: 33156
		DecrWrap,
		// Token: 0x04008185 RID: 33157
		TextureCubeMap = 34067,
		// Token: 0x04008186 RID: 33158
		TextureBindingCubeMap,
		// Token: 0x04008187 RID: 33159
		TextureCubeMapPositiveX,
		// Token: 0x04008188 RID: 33160
		TextureCubeMapNegativeX,
		// Token: 0x04008189 RID: 33161
		TextureCubeMapPositiveY,
		// Token: 0x0400818A RID: 33162
		TextureCubeMapNegativeY,
		// Token: 0x0400818B RID: 33163
		TextureCubeMapPositiveZ,
		// Token: 0x0400818C RID: 33164
		TextureCubeMapNegativeZ,
		// Token: 0x0400818D RID: 33165
		MaxCubeMapTextureSize = 34076,
		// Token: 0x0400818E RID: 33166
		VertexAttribArrayEnabled = 34338,
		// Token: 0x0400818F RID: 33167
		VertexAttribArraySize,
		// Token: 0x04008190 RID: 33168
		VertexAttribArrayStride,
		// Token: 0x04008191 RID: 33169
		VertexAttribArrayType,
		// Token: 0x04008192 RID: 33170
		CurrentVertexAttrib,
		// Token: 0x04008193 RID: 33171
		VertexAttribArrayPointer = 34373,
		// Token: 0x04008194 RID: 33172
		NumCompressedTextureFormats = 34466,
		// Token: 0x04008195 RID: 33173
		CompressedTextureFormats,
		// Token: 0x04008196 RID: 33174
		BufferSize = 34660,
		// Token: 0x04008197 RID: 33175
		BufferUsage,
		// Token: 0x04008198 RID: 33176
		StencilBackFunc = 34816,
		// Token: 0x04008199 RID: 33177
		StencilBackFail,
		// Token: 0x0400819A RID: 33178
		StencilBackPassDepthFail,
		// Token: 0x0400819B RID: 33179
		StencilBackPassDepthPass,
		// Token: 0x0400819C RID: 33180
		BlendEquationAlpha = 34877,
		// Token: 0x0400819D RID: 33181
		MaxVertexAttribs = 34921,
		// Token: 0x0400819E RID: 33182
		VertexAttribArrayNormalized,
		// Token: 0x0400819F RID: 33183
		MaxTextureImageUnits = 34930,
		// Token: 0x040081A0 RID: 33184
		ArrayBuffer = 34962,
		// Token: 0x040081A1 RID: 33185
		ElementArrayBuffer,
		// Token: 0x040081A2 RID: 33186
		ArrayBufferBinding,
		// Token: 0x040081A3 RID: 33187
		ElementArrayBufferBinding,
		// Token: 0x040081A4 RID: 33188
		VertexAttribArrayBufferBinding = 34975,
		// Token: 0x040081A5 RID: 33189
		StreamDraw = 35040,
		// Token: 0x040081A6 RID: 33190
		StaticDraw = 35044,
		// Token: 0x040081A7 RID: 33191
		DynamicDraw = 35048,
		// Token: 0x040081A8 RID: 33192
		FragmentShader = 35632,
		// Token: 0x040081A9 RID: 33193
		VertexShader,
		// Token: 0x040081AA RID: 33194
		MaxVertexTextureImageUnits = 35660,
		// Token: 0x040081AB RID: 33195
		MaxCombinedTextureImageUnits,
		// Token: 0x040081AC RID: 33196
		ShaderType = 35663,
		// Token: 0x040081AD RID: 33197
		FloatVec2,
		// Token: 0x040081AE RID: 33198
		FloatVec3,
		// Token: 0x040081AF RID: 33199
		FloatVec4,
		// Token: 0x040081B0 RID: 33200
		IntVec2,
		// Token: 0x040081B1 RID: 33201
		IntVec3,
		// Token: 0x040081B2 RID: 33202
		IntVec4,
		// Token: 0x040081B3 RID: 33203
		Bool,
		// Token: 0x040081B4 RID: 33204
		BoolVec2,
		// Token: 0x040081B5 RID: 33205
		BoolVec3,
		// Token: 0x040081B6 RID: 33206
		BoolVec4,
		// Token: 0x040081B7 RID: 33207
		FloatMat2,
		// Token: 0x040081B8 RID: 33208
		FloatMat3,
		// Token: 0x040081B9 RID: 33209
		FloatMat4,
		// Token: 0x040081BA RID: 33210
		Sampler2D = 35678,
		// Token: 0x040081BB RID: 33211
		SamplerCube = 35680,
		// Token: 0x040081BC RID: 33212
		DeleteStatus = 35712,
		// Token: 0x040081BD RID: 33213
		CompileStatus,
		// Token: 0x040081BE RID: 33214
		LinkStatus,
		// Token: 0x040081BF RID: 33215
		ValidateStatus,
		// Token: 0x040081C0 RID: 33216
		InfoLogLength,
		// Token: 0x040081C1 RID: 33217
		AttachedShaders,
		// Token: 0x040081C2 RID: 33218
		ActiveUniforms,
		// Token: 0x040081C3 RID: 33219
		ActiveUniformMaxLength,
		// Token: 0x040081C4 RID: 33220
		ShaderSourceLength,
		// Token: 0x040081C5 RID: 33221
		ActiveAttributes,
		// Token: 0x040081C6 RID: 33222
		ActiveAttributeMaxLength,
		// Token: 0x040081C7 RID: 33223
		ShadingLanguageVersion = 35724,
		// Token: 0x040081C8 RID: 33224
		CurrentProgram,
		// Token: 0x040081C9 RID: 33225
		ImplementationColorReadType = 35738,
		// Token: 0x040081CA RID: 33226
		ImplementationColorReadFormat,
		// Token: 0x040081CB RID: 33227
		StencilBackRef = 36003,
		// Token: 0x040081CC RID: 33228
		StencilBackValueMask,
		// Token: 0x040081CD RID: 33229
		StencilBackWritemask,
		// Token: 0x040081CE RID: 33230
		FramebufferBinding,
		// Token: 0x040081CF RID: 33231
		RenderbufferBinding,
		// Token: 0x040081D0 RID: 33232
		FramebufferAttachmentObjectType = 36048,
		// Token: 0x040081D1 RID: 33233
		FramebufferAttachmentObjectName,
		// Token: 0x040081D2 RID: 33234
		FramebufferAttachmentTextureLevel,
		// Token: 0x040081D3 RID: 33235
		FramebufferAttachmentTextureCubeMapFace,
		// Token: 0x040081D4 RID: 33236
		FramebufferComplete = 36053,
		// Token: 0x040081D5 RID: 33237
		FramebufferIncompleteAttachment,
		// Token: 0x040081D6 RID: 33238
		FramebufferIncompleteMissingAttachment,
		// Token: 0x040081D7 RID: 33239
		FramebufferIncompleteDimensions = 36057,
		// Token: 0x040081D8 RID: 33240
		FramebufferUnsupported = 36061,
		// Token: 0x040081D9 RID: 33241
		ColorAttachment0 = 36064,
		// Token: 0x040081DA RID: 33242
		DepthAttachment = 36096,
		// Token: 0x040081DB RID: 33243
		StencilAttachment = 36128,
		// Token: 0x040081DC RID: 33244
		Framebuffer = 36160,
		// Token: 0x040081DD RID: 33245
		Renderbuffer,
		// Token: 0x040081DE RID: 33246
		RenderbufferWidth,
		// Token: 0x040081DF RID: 33247
		RenderbufferHeight,
		// Token: 0x040081E0 RID: 33248
		RenderbufferInternalFormat,
		// Token: 0x040081E1 RID: 33249
		StencilIndex8 = 36168,
		// Token: 0x040081E2 RID: 33250
		RenderbufferRedSize = 36176,
		// Token: 0x040081E3 RID: 33251
		RenderbufferGreenSize,
		// Token: 0x040081E4 RID: 33252
		RenderbufferBlueSize,
		// Token: 0x040081E5 RID: 33253
		RenderbufferAlphaSize,
		// Token: 0x040081E6 RID: 33254
		RenderbufferDepthSize,
		// Token: 0x040081E7 RID: 33255
		RenderbufferStencilSize,
		// Token: 0x040081E8 RID: 33256
		Rgb565 = 36194,
		// Token: 0x040081E9 RID: 33257
		LowFloat = 36336,
		// Token: 0x040081EA RID: 33258
		MediumFloat,
		// Token: 0x040081EB RID: 33259
		HighFloat,
		// Token: 0x040081EC RID: 33260
		LowInt,
		// Token: 0x040081ED RID: 33261
		MediumInt,
		// Token: 0x040081EE RID: 33262
		HighInt,
		// Token: 0x040081EF RID: 33263
		ShaderBinaryFormats = 36344,
		// Token: 0x040081F0 RID: 33264
		NumShaderBinaryFormats,
		// Token: 0x040081F1 RID: 33265
		ShaderCompiler,
		// Token: 0x040081F2 RID: 33266
		MaxVertexUniformVectors,
		// Token: 0x040081F3 RID: 33267
		MaxVaryingVectors,
		// Token: 0x040081F4 RID: 33268
		MaxFragmentUniformVectors,
		// Token: 0x040081F5 RID: 33269
		One = 1,
		// Token: 0x040081F6 RID: 33270
		True = 1
	}
}
