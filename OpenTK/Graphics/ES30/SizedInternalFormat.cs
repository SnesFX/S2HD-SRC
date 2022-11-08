using System;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020008A4 RID: 2212
	public enum SizedInternalFormat
	{
		// Token: 0x04008D20 RID: 36128
		Alpha8Ext = 32828,
		// Token: 0x04008D21 RID: 36129
		Luminance8Ext = 32832,
		// Token: 0x04008D22 RID: 36130
		Luminance8Alpha8Ext = 32837,
		// Token: 0x04008D23 RID: 36131
		Rgb8 = 32849,
		// Token: 0x04008D24 RID: 36132
		Rgb10Ext,
		// Token: 0x04008D25 RID: 36133
		Rgba4 = 32854,
		// Token: 0x04008D26 RID: 36134
		Rgb5A1,
		// Token: 0x04008D27 RID: 36135
		Rgba8,
		// Token: 0x04008D28 RID: 36136
		Rgb10A2,
		// Token: 0x04008D29 RID: 36137
		Rgb10A2Ext = 32857,
		// Token: 0x04008D2A RID: 36138
		DepthComponent16 = 33189,
		// Token: 0x04008D2B RID: 36139
		DepthComponent24,
		// Token: 0x04008D2C RID: 36140
		R8 = 33321,
		// Token: 0x04008D2D RID: 36141
		R8Ext = 33321,
		// Token: 0x04008D2E RID: 36142
		Rg8 = 33323,
		// Token: 0x04008D2F RID: 36143
		Rg8Ext = 33323,
		// Token: 0x04008D30 RID: 36144
		R16f = 33325,
		// Token: 0x04008D31 RID: 36145
		R16fExt = 33325,
		// Token: 0x04008D32 RID: 36146
		R32f,
		// Token: 0x04008D33 RID: 36147
		R32fExt = 33326,
		// Token: 0x04008D34 RID: 36148
		Rg16f,
		// Token: 0x04008D35 RID: 36149
		Rg16fExt = 33327,
		// Token: 0x04008D36 RID: 36150
		Rg32f,
		// Token: 0x04008D37 RID: 36151
		Rg32fExt = 33328,
		// Token: 0x04008D38 RID: 36152
		R8i,
		// Token: 0x04008D39 RID: 36153
		R8ui,
		// Token: 0x04008D3A RID: 36154
		R16i,
		// Token: 0x04008D3B RID: 36155
		R16ui,
		// Token: 0x04008D3C RID: 36156
		R32i,
		// Token: 0x04008D3D RID: 36157
		R32ui,
		// Token: 0x04008D3E RID: 36158
		Rg8i,
		// Token: 0x04008D3F RID: 36159
		Rg8ui,
		// Token: 0x04008D40 RID: 36160
		Rg16i,
		// Token: 0x04008D41 RID: 36161
		Rg16ui,
		// Token: 0x04008D42 RID: 36162
		Rg32i,
		// Token: 0x04008D43 RID: 36163
		Rg32ui,
		// Token: 0x04008D44 RID: 36164
		Rgba32f = 34836,
		// Token: 0x04008D45 RID: 36165
		Rgba32fExt = 34836,
		// Token: 0x04008D46 RID: 36166
		Rgb32f,
		// Token: 0x04008D47 RID: 36167
		Rgb32fExt = 34837,
		// Token: 0x04008D48 RID: 36168
		Alpha32fExt,
		// Token: 0x04008D49 RID: 36169
		Luminance32fExt = 34840,
		// Token: 0x04008D4A RID: 36170
		LuminanceAlpha32fExt,
		// Token: 0x04008D4B RID: 36171
		Rgba16f,
		// Token: 0x04008D4C RID: 36172
		Rgba16fExt = 34842,
		// Token: 0x04008D4D RID: 36173
		Rgb16f,
		// Token: 0x04008D4E RID: 36174
		Rgb16fExt = 34843,
		// Token: 0x04008D4F RID: 36175
		Alpha16fExt,
		// Token: 0x04008D50 RID: 36176
		Luminance16fExt = 34846,
		// Token: 0x04008D51 RID: 36177
		LuminanceAlpha16fExt,
		// Token: 0x04008D52 RID: 36178
		Depth24Stencil8 = 35056,
		// Token: 0x04008D53 RID: 36179
		RgbRaw422Apple = 35409,
		// Token: 0x04008D54 RID: 36180
		R11fG11fB10f = 35898,
		// Token: 0x04008D55 RID: 36181
		Rgb9E5 = 35901,
		// Token: 0x04008D56 RID: 36182
		Srgb8 = 35905,
		// Token: 0x04008D57 RID: 36183
		Srgb8Alpha8 = 35907,
		// Token: 0x04008D58 RID: 36184
		DepthComponent32f = 36012,
		// Token: 0x04008D59 RID: 36185
		Depth32fStencil8,
		// Token: 0x04008D5A RID: 36186
		Rgb565 = 36194,
		// Token: 0x04008D5B RID: 36187
		Rgba32ui = 36208,
		// Token: 0x04008D5C RID: 36188
		Rgb32ui,
		// Token: 0x04008D5D RID: 36189
		Rgba16ui = 36214,
		// Token: 0x04008D5E RID: 36190
		Rgb16ui,
		// Token: 0x04008D5F RID: 36191
		Rgba8ui = 36220,
		// Token: 0x04008D60 RID: 36192
		Rgb8ui,
		// Token: 0x04008D61 RID: 36193
		Rgba32i = 36226,
		// Token: 0x04008D62 RID: 36194
		Rgb32i,
		// Token: 0x04008D63 RID: 36195
		Rgba16i = 36232,
		// Token: 0x04008D64 RID: 36196
		Rgb16i,
		// Token: 0x04008D65 RID: 36197
		Rgba8i = 36238,
		// Token: 0x04008D66 RID: 36198
		Rgb8i,
		// Token: 0x04008D67 RID: 36199
		R8Snorm = 36756,
		// Token: 0x04008D68 RID: 36200
		Rg8Snorm,
		// Token: 0x04008D69 RID: 36201
		Rgb8Snorm,
		// Token: 0x04008D6A RID: 36202
		Rgba8Snorm,
		// Token: 0x04008D6B RID: 36203
		Rgb10A2ui = 36975,
		// Token: 0x04008D6C RID: 36204
		Bgra8Ext = 37793
	}
}
