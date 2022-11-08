using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020003E5 RID: 997
	public enum NvVertexProgram
	{
		// Token: 0x04003C90 RID: 15504
		VertexProgramNv = 34336,
		// Token: 0x04003C91 RID: 15505
		VertexStateProgramNv,
		// Token: 0x04003C92 RID: 15506
		AttribArraySizeNv = 34339,
		// Token: 0x04003C93 RID: 15507
		AttribArrayStrideNv,
		// Token: 0x04003C94 RID: 15508
		AttribArrayTypeNv,
		// Token: 0x04003C95 RID: 15509
		CurrentAttribNv,
		// Token: 0x04003C96 RID: 15510
		ProgramLengthNv,
		// Token: 0x04003C97 RID: 15511
		ProgramStringNv,
		// Token: 0x04003C98 RID: 15512
		ModelviewProjectionNv,
		// Token: 0x04003C99 RID: 15513
		IdentityNv,
		// Token: 0x04003C9A RID: 15514
		InverseNv,
		// Token: 0x04003C9B RID: 15515
		TransposeNv,
		// Token: 0x04003C9C RID: 15516
		InverseTransposeNv,
		// Token: 0x04003C9D RID: 15517
		MaxTrackMatrixStackDepthNv,
		// Token: 0x04003C9E RID: 15518
		MaxTrackMatricesNv,
		// Token: 0x04003C9F RID: 15519
		Matrix0Nv,
		// Token: 0x04003CA0 RID: 15520
		Matrix1Nv,
		// Token: 0x04003CA1 RID: 15521
		Matrix2Nv,
		// Token: 0x04003CA2 RID: 15522
		Matrix3Nv,
		// Token: 0x04003CA3 RID: 15523
		Matrix4Nv,
		// Token: 0x04003CA4 RID: 15524
		Matrix5Nv,
		// Token: 0x04003CA5 RID: 15525
		Matrix6Nv,
		// Token: 0x04003CA6 RID: 15526
		Matrix7Nv,
		// Token: 0x04003CA7 RID: 15527
		CurrentMatrixStackDepthNv = 34368,
		// Token: 0x04003CA8 RID: 15528
		CurrentMatrixNv,
		// Token: 0x04003CA9 RID: 15529
		VertexProgramPointSizeNv,
		// Token: 0x04003CAA RID: 15530
		VertexProgramTwoSideNv,
		// Token: 0x04003CAB RID: 15531
		ProgramParameterNv,
		// Token: 0x04003CAC RID: 15532
		AttribArrayPointerNv,
		// Token: 0x04003CAD RID: 15533
		ProgramTargetNv,
		// Token: 0x04003CAE RID: 15534
		ProgramResidentNv,
		// Token: 0x04003CAF RID: 15535
		TrackMatrixNv,
		// Token: 0x04003CB0 RID: 15536
		TrackMatrixTransformNv,
		// Token: 0x04003CB1 RID: 15537
		VertexProgramBindingNv,
		// Token: 0x04003CB2 RID: 15538
		ProgramErrorPositionNv,
		// Token: 0x04003CB3 RID: 15539
		VertexAttribArray0Nv = 34384,
		// Token: 0x04003CB4 RID: 15540
		VertexAttribArray1Nv,
		// Token: 0x04003CB5 RID: 15541
		VertexAttribArray2Nv,
		// Token: 0x04003CB6 RID: 15542
		VertexAttribArray3Nv,
		// Token: 0x04003CB7 RID: 15543
		VertexAttribArray4Nv,
		// Token: 0x04003CB8 RID: 15544
		VertexAttribArray5Nv,
		// Token: 0x04003CB9 RID: 15545
		VertexAttribArray6Nv,
		// Token: 0x04003CBA RID: 15546
		VertexAttribArray7Nv,
		// Token: 0x04003CBB RID: 15547
		VertexAttribArray8Nv,
		// Token: 0x04003CBC RID: 15548
		VertexAttribArray9Nv,
		// Token: 0x04003CBD RID: 15549
		VertexAttribArray10Nv,
		// Token: 0x04003CBE RID: 15550
		VertexAttribArray11Nv,
		// Token: 0x04003CBF RID: 15551
		VertexAttribArray12Nv,
		// Token: 0x04003CC0 RID: 15552
		VertexAttribArray13Nv,
		// Token: 0x04003CC1 RID: 15553
		VertexAttribArray14Nv,
		// Token: 0x04003CC2 RID: 15554
		VertexAttribArray15Nv,
		// Token: 0x04003CC3 RID: 15555
		Map1VertexAttrib04Nv,
		// Token: 0x04003CC4 RID: 15556
		Map1VertexAttrib14Nv,
		// Token: 0x04003CC5 RID: 15557
		Map1VertexAttrib24Nv,
		// Token: 0x04003CC6 RID: 15558
		Map1VertexAttrib34Nv,
		// Token: 0x04003CC7 RID: 15559
		Map1VertexAttrib44Nv,
		// Token: 0x04003CC8 RID: 15560
		Map1VertexAttrib54Nv,
		// Token: 0x04003CC9 RID: 15561
		Map1VertexAttrib64Nv,
		// Token: 0x04003CCA RID: 15562
		Map1VertexAttrib74Nv,
		// Token: 0x04003CCB RID: 15563
		Map1VertexAttrib84Nv,
		// Token: 0x04003CCC RID: 15564
		Map1VertexAttrib94Nv,
		// Token: 0x04003CCD RID: 15565
		Map1VertexAttrib104Nv,
		// Token: 0x04003CCE RID: 15566
		Map1VertexAttrib114Nv,
		// Token: 0x04003CCF RID: 15567
		Map1VertexAttrib124Nv,
		// Token: 0x04003CD0 RID: 15568
		Map1VertexAttrib134Nv,
		// Token: 0x04003CD1 RID: 15569
		Map1VertexAttrib144Nv,
		// Token: 0x04003CD2 RID: 15570
		Map1VertexAttrib154Nv,
		// Token: 0x04003CD3 RID: 15571
		Map2VertexAttrib04Nv,
		// Token: 0x04003CD4 RID: 15572
		Map2VertexAttrib14Nv,
		// Token: 0x04003CD5 RID: 15573
		Map2VertexAttrib24Nv,
		// Token: 0x04003CD6 RID: 15574
		Map2VertexAttrib34Nv,
		// Token: 0x04003CD7 RID: 15575
		Map2VertexAttrib44Nv,
		// Token: 0x04003CD8 RID: 15576
		Map2VertexAttrib54Nv,
		// Token: 0x04003CD9 RID: 15577
		Map2VertexAttrib64Nv,
		// Token: 0x04003CDA RID: 15578
		Map2VertexAttrib74Nv,
		// Token: 0x04003CDB RID: 15579
		Map2VertexAttrib84Nv,
		// Token: 0x04003CDC RID: 15580
		Map2VertexAttrib94Nv,
		// Token: 0x04003CDD RID: 15581
		Map2VertexAttrib104Nv,
		// Token: 0x04003CDE RID: 15582
		Map2VertexAttrib114Nv,
		// Token: 0x04003CDF RID: 15583
		Map2VertexAttrib124Nv,
		// Token: 0x04003CE0 RID: 15584
		Map2VertexAttrib134Nv,
		// Token: 0x04003CE1 RID: 15585
		Map2VertexAttrib144Nv,
		// Token: 0x04003CE2 RID: 15586
		Map2VertexAttrib154Nv
	}
}
