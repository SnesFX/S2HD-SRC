using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020003C4 RID: 964
	public enum NvPathRendering
	{
		// Token: 0x04003AE1 RID: 15073
		ClosePathNv,
		// Token: 0x04003AE2 RID: 15074
		FontXMinBoundsBitNv = 65536,
		// Token: 0x04003AE3 RID: 15075
		FontYMinBoundsBitNv = 131072,
		// Token: 0x04003AE4 RID: 15076
		FontXMaxBoundsBitNv = 262144,
		// Token: 0x04003AE5 RID: 15077
		FontYMaxBoundsBitNv = 524288,
		// Token: 0x04003AE6 RID: 15078
		FontUnitsPerEmBitNv = 1048576,
		// Token: 0x04003AE7 RID: 15079
		FontAscenderBitNv = 2097152,
		// Token: 0x04003AE8 RID: 15080
		FontDescenderBitNv = 4194304,
		// Token: 0x04003AE9 RID: 15081
		FontHeightBitNv = 8388608,
		// Token: 0x04003AEA RID: 15082
		BoldBitNv = 1,
		// Token: 0x04003AEB RID: 15083
		GlyphWidthBitNv = 1,
		// Token: 0x04003AEC RID: 15084
		FontMaxAdvanceWidthBitNv = 16777216,
		// Token: 0x04003AED RID: 15085
		GlyphHeightBitNv = 2,
		// Token: 0x04003AEE RID: 15086
		ItalicBitNv = 2,
		// Token: 0x04003AEF RID: 15087
		MoveToNv = 2,
		// Token: 0x04003AF0 RID: 15088
		FontMaxAdvanceHeightBitNv = 33554432,
		// Token: 0x04003AF1 RID: 15089
		RelativeMoveToNv = 3,
		// Token: 0x04003AF2 RID: 15090
		GlyphHorizontalBearingXBitNv,
		// Token: 0x04003AF3 RID: 15091
		LineToNv = 4,
		// Token: 0x04003AF4 RID: 15092
		FontUnderlinePositionBitNv = 67108864,
		// Token: 0x04003AF5 RID: 15093
		RelativeLineToNv = 5,
		// Token: 0x04003AF6 RID: 15094
		HorizontalLineToNv,
		// Token: 0x04003AF7 RID: 15095
		RelativeHorizontalLineToNv,
		// Token: 0x04003AF8 RID: 15096
		GlyphHorizontalBearingYBitNv,
		// Token: 0x04003AF9 RID: 15097
		VerticalLineToNv = 8,
		// Token: 0x04003AFA RID: 15098
		FontUnderlineThicknessBitNv = 134217728,
		// Token: 0x04003AFB RID: 15099
		RelativeVerticalLineToNv = 9,
		// Token: 0x04003AFC RID: 15100
		QuadraticCurveToNv,
		// Token: 0x04003AFD RID: 15101
		RelativeQuadraticCurveToNv,
		// Token: 0x04003AFE RID: 15102
		CubicCurveToNv,
		// Token: 0x04003AFF RID: 15103
		RelativeCubicCurveToNv,
		// Token: 0x04003B00 RID: 15104
		SmoothQuadraticCurveToNv,
		// Token: 0x04003B01 RID: 15105
		RelativeSmoothQuadraticCurveToNv,
		// Token: 0x04003B02 RID: 15106
		GlyphHorizontalBearingAdvanceBitNv,
		// Token: 0x04003B03 RID: 15107
		SmoothCubicCurveToNv = 16,
		// Token: 0x04003B04 RID: 15108
		GlyphHasKerningBitNv = 256,
		// Token: 0x04003B05 RID: 15109
		FontHasKerningBitNv = 268435456,
		// Token: 0x04003B06 RID: 15110
		RelativeSmoothCubicCurveToNv = 17,
		// Token: 0x04003B07 RID: 15111
		SmallCcwArcToNv,
		// Token: 0x04003B08 RID: 15112
		RelativeSmallCcwArcToNv,
		// Token: 0x04003B09 RID: 15113
		SmallCwArcToNv,
		// Token: 0x04003B0A RID: 15114
		RelativeSmallCwArcToNv,
		// Token: 0x04003B0B RID: 15115
		LargeCcwArcToNv,
		// Token: 0x04003B0C RID: 15116
		RelativeLargeCcwArcToNv,
		// Token: 0x04003B0D RID: 15117
		LargeCwArcToNv,
		// Token: 0x04003B0E RID: 15118
		RelativeLargeCwArcToNv,
		// Token: 0x04003B0F RID: 15119
		GlyphVerticalBearingXBitNv = 32,
		// Token: 0x04003B10 RID: 15120
		GlyphVerticalBearingYBitNv = 64,
		// Token: 0x04003B11 RID: 15121
		GlyphVerticalBearingAdvanceBitNv = 128,
		// Token: 0x04003B12 RID: 15122
		PrimaryColorNv = 34092,
		// Token: 0x04003B13 RID: 15123
		SecondaryColorNv,
		// Token: 0x04003B14 RID: 15124
		PrimaryColor = 34167,
		// Token: 0x04003B15 RID: 15125
		PathFormatSvgNv = 36976,
		// Token: 0x04003B16 RID: 15126
		PathFormatPsNv,
		// Token: 0x04003B17 RID: 15127
		StandardFontNameNv,
		// Token: 0x04003B18 RID: 15128
		SystemFontNameNv,
		// Token: 0x04003B19 RID: 15129
		FileNameNv,
		// Token: 0x04003B1A RID: 15130
		PathStrokeWidthNv,
		// Token: 0x04003B1B RID: 15131
		PathEndCapsNv,
		// Token: 0x04003B1C RID: 15132
		PathInitialEndCapNv,
		// Token: 0x04003B1D RID: 15133
		PathTerminalEndCapNv,
		// Token: 0x04003B1E RID: 15134
		PathJoinStyleNv,
		// Token: 0x04003B1F RID: 15135
		PathMiterLimitNv,
		// Token: 0x04003B20 RID: 15136
		PathDashCapsNv,
		// Token: 0x04003B21 RID: 15137
		PathInitialDashCapNv,
		// Token: 0x04003B22 RID: 15138
		PathTerminalDashCapNv,
		// Token: 0x04003B23 RID: 15139
		PathDashOffsetNv,
		// Token: 0x04003B24 RID: 15140
		PathClientLengthNv,
		// Token: 0x04003B25 RID: 15141
		PathFillModeNv,
		// Token: 0x04003B26 RID: 15142
		PathFillMaskNv,
		// Token: 0x04003B27 RID: 15143
		PathFillCoverModeNv,
		// Token: 0x04003B28 RID: 15144
		PathStrokeCoverModeNv,
		// Token: 0x04003B29 RID: 15145
		PathStrokeMaskNv,
		// Token: 0x04003B2A RID: 15146
		CountUpNv = 37000,
		// Token: 0x04003B2B RID: 15147
		CountDownNv,
		// Token: 0x04003B2C RID: 15148
		PathObjectBoundingBoxNv,
		// Token: 0x04003B2D RID: 15149
		ConvexHullNv,
		// Token: 0x04003B2E RID: 15150
		BoundingBoxNv = 37005,
		// Token: 0x04003B2F RID: 15151
		TranslateXNv,
		// Token: 0x04003B30 RID: 15152
		TranslateYNv,
		// Token: 0x04003B31 RID: 15153
		Translate2DNv,
		// Token: 0x04003B32 RID: 15154
		Translate3DNv,
		// Token: 0x04003B33 RID: 15155
		Affine2DNv,
		// Token: 0x04003B34 RID: 15156
		Affine3DNv = 37012,
		// Token: 0x04003B35 RID: 15157
		TransposeAffine2DNv = 37014,
		// Token: 0x04003B36 RID: 15158
		TransposeAffine3DNv = 37016,
		// Token: 0x04003B37 RID: 15159
		Utf8Nv = 37018,
		// Token: 0x04003B38 RID: 15160
		Utf16Nv,
		// Token: 0x04003B39 RID: 15161
		BoundingBoxOfBoundingBoxesNv,
		// Token: 0x04003B3A RID: 15162
		PathCommandCountNv,
		// Token: 0x04003B3B RID: 15163
		PathCoordCountNv,
		// Token: 0x04003B3C RID: 15164
		PathDashArrayCountNv,
		// Token: 0x04003B3D RID: 15165
		PathComputedLengthNv,
		// Token: 0x04003B3E RID: 15166
		PathFillBoundingBoxNv,
		// Token: 0x04003B3F RID: 15167
		PathStrokeBoundingBoxNv,
		// Token: 0x04003B40 RID: 15168
		SquareNv,
		// Token: 0x04003B41 RID: 15169
		RoundNv,
		// Token: 0x04003B42 RID: 15170
		TriangularNv,
		// Token: 0x04003B43 RID: 15171
		BevelNv,
		// Token: 0x04003B44 RID: 15172
		MiterRevertNv,
		// Token: 0x04003B45 RID: 15173
		MiterTruncateNv,
		// Token: 0x04003B46 RID: 15174
		SkipMissingGlyphNv,
		// Token: 0x04003B47 RID: 15175
		UseMissingGlyphNv,
		// Token: 0x04003B48 RID: 15176
		PathErrorPositionNv,
		// Token: 0x04003B49 RID: 15177
		PathFogGenModeNv,
		// Token: 0x04003B4A RID: 15178
		AccumAdjacentPairsNv,
		// Token: 0x04003B4B RID: 15179
		AdjacentPairsNv,
		// Token: 0x04003B4C RID: 15180
		FirstToRestNv,
		// Token: 0x04003B4D RID: 15181
		PathGenModeNv,
		// Token: 0x04003B4E RID: 15182
		PathGenCoeffNv,
		// Token: 0x04003B4F RID: 15183
		PathGenColorFormatNv,
		// Token: 0x04003B50 RID: 15184
		PathGenComponentsNv,
		// Token: 0x04003B51 RID: 15185
		PathDashOffsetResetNv,
		// Token: 0x04003B52 RID: 15186
		MoveToResetsNv,
		// Token: 0x04003B53 RID: 15187
		MoveToContinuesNv,
		// Token: 0x04003B54 RID: 15188
		PathStencilFuncNv,
		// Token: 0x04003B55 RID: 15189
		PathStencilRefNv,
		// Token: 0x04003B56 RID: 15190
		PathStencilValueMaskNv,
		// Token: 0x04003B57 RID: 15191
		PathStencilDepthOffsetFactorNv = 37053,
		// Token: 0x04003B58 RID: 15192
		PathStencilDepthOffsetUnitsNv,
		// Token: 0x04003B59 RID: 15193
		PathCoverDepthFuncNv,
		// Token: 0x04003B5A RID: 15194
		RestartPathNv = 240,
		// Token: 0x04003B5B RID: 15195
		DupFirstCubicCurveToNv = 242,
		// Token: 0x04003B5C RID: 15196
		DupLastCubicCurveToNv = 244,
		// Token: 0x04003B5D RID: 15197
		RectNv = 246,
		// Token: 0x04003B5E RID: 15198
		CircularCcwArcToNv = 248,
		// Token: 0x04003B5F RID: 15199
		CircularCwArcToNv = 250,
		// Token: 0x04003B60 RID: 15200
		CircularTangentArcToNv = 252,
		// Token: 0x04003B61 RID: 15201
		ArcToNv = 254,
		// Token: 0x04003B62 RID: 15202
		RelativeArcToNv
	}
}
