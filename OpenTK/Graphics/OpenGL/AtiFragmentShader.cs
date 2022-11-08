using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x0200028C RID: 652
	public enum AtiFragmentShader
	{
		// Token: 0x04002C5E RID: 11358
		Gl2XBitAti = 1,
		// Token: 0x04002C5F RID: 11359
		RedBitAti = 1,
		// Token: 0x04002C60 RID: 11360
		CompBitAti,
		// Token: 0x04002C61 RID: 11361
		Gl4XBitAti = 2,
		// Token: 0x04002C62 RID: 11362
		GreenBitAti = 2,
		// Token: 0x04002C63 RID: 11363
		BlueBitAti = 4,
		// Token: 0x04002C64 RID: 11364
		Gl8XBitAti = 4,
		// Token: 0x04002C65 RID: 11365
		NegateBitAti = 4,
		// Token: 0x04002C66 RID: 11366
		BiasBitAti = 8,
		// Token: 0x04002C67 RID: 11367
		HalfBitAti = 8,
		// Token: 0x04002C68 RID: 11368
		QuarterBitAti = 16,
		// Token: 0x04002C69 RID: 11369
		EighthBitAti = 32,
		// Token: 0x04002C6A RID: 11370
		SaturateBitAti = 64,
		// Token: 0x04002C6B RID: 11371
		FragmentShaderAti = 35104,
		// Token: 0x04002C6C RID: 11372
		Reg0Ati,
		// Token: 0x04002C6D RID: 11373
		Reg1Ati,
		// Token: 0x04002C6E RID: 11374
		Reg2Ati,
		// Token: 0x04002C6F RID: 11375
		Reg3Ati,
		// Token: 0x04002C70 RID: 11376
		Reg4Ati,
		// Token: 0x04002C71 RID: 11377
		Reg5Ati,
		// Token: 0x04002C72 RID: 11378
		Reg6Ati,
		// Token: 0x04002C73 RID: 11379
		Reg7Ati,
		// Token: 0x04002C74 RID: 11380
		Reg8Ati,
		// Token: 0x04002C75 RID: 11381
		Reg9Ati,
		// Token: 0x04002C76 RID: 11382
		Reg10Ati,
		// Token: 0x04002C77 RID: 11383
		Reg11Ati,
		// Token: 0x04002C78 RID: 11384
		Reg12Ati,
		// Token: 0x04002C79 RID: 11385
		Reg13Ati,
		// Token: 0x04002C7A RID: 11386
		Reg14Ati,
		// Token: 0x04002C7B RID: 11387
		Reg15Ati,
		// Token: 0x04002C7C RID: 11388
		Reg16Ati,
		// Token: 0x04002C7D RID: 11389
		Reg17Ati,
		// Token: 0x04002C7E RID: 11390
		Reg18Ati,
		// Token: 0x04002C7F RID: 11391
		Reg19Ati,
		// Token: 0x04002C80 RID: 11392
		Reg20Ati,
		// Token: 0x04002C81 RID: 11393
		Reg21Ati,
		// Token: 0x04002C82 RID: 11394
		Reg22Ati,
		// Token: 0x04002C83 RID: 11395
		Reg23Ati,
		// Token: 0x04002C84 RID: 11396
		Reg24Ati,
		// Token: 0x04002C85 RID: 11397
		Reg25Ati,
		// Token: 0x04002C86 RID: 11398
		Reg26Ati,
		// Token: 0x04002C87 RID: 11399
		Reg27Ati,
		// Token: 0x04002C88 RID: 11400
		Reg28Ati,
		// Token: 0x04002C89 RID: 11401
		Reg29Ati,
		// Token: 0x04002C8A RID: 11402
		Reg30Ati,
		// Token: 0x04002C8B RID: 11403
		Reg31Ati,
		// Token: 0x04002C8C RID: 11404
		Con0Ati,
		// Token: 0x04002C8D RID: 11405
		Con1Ati,
		// Token: 0x04002C8E RID: 11406
		Con2Ati,
		// Token: 0x04002C8F RID: 11407
		Con3Ati,
		// Token: 0x04002C90 RID: 11408
		Con4Ati,
		// Token: 0x04002C91 RID: 11409
		Con5Ati,
		// Token: 0x04002C92 RID: 11410
		Con6Ati,
		// Token: 0x04002C93 RID: 11411
		Con7Ati,
		// Token: 0x04002C94 RID: 11412
		Con8Ati,
		// Token: 0x04002C95 RID: 11413
		Con9Ati,
		// Token: 0x04002C96 RID: 11414
		Con10Ati,
		// Token: 0x04002C97 RID: 11415
		Con11Ati,
		// Token: 0x04002C98 RID: 11416
		Con12Ati,
		// Token: 0x04002C99 RID: 11417
		Con13Ati,
		// Token: 0x04002C9A RID: 11418
		Con14Ati,
		// Token: 0x04002C9B RID: 11419
		Con15Ati,
		// Token: 0x04002C9C RID: 11420
		Con16Ati,
		// Token: 0x04002C9D RID: 11421
		Con17Ati,
		// Token: 0x04002C9E RID: 11422
		Con18Ati,
		// Token: 0x04002C9F RID: 11423
		Con19Ati,
		// Token: 0x04002CA0 RID: 11424
		Con20Ati,
		// Token: 0x04002CA1 RID: 11425
		Con21Ati,
		// Token: 0x04002CA2 RID: 11426
		Con22Ati,
		// Token: 0x04002CA3 RID: 11427
		Con23Ati,
		// Token: 0x04002CA4 RID: 11428
		Con24Ati,
		// Token: 0x04002CA5 RID: 11429
		Con25Ati,
		// Token: 0x04002CA6 RID: 11430
		Con26Ati,
		// Token: 0x04002CA7 RID: 11431
		Con27Ati,
		// Token: 0x04002CA8 RID: 11432
		Con28Ati,
		// Token: 0x04002CA9 RID: 11433
		Con29Ati,
		// Token: 0x04002CAA RID: 11434
		Con30Ati,
		// Token: 0x04002CAB RID: 11435
		Con31Ati,
		// Token: 0x04002CAC RID: 11436
		MovAti,
		// Token: 0x04002CAD RID: 11437
		AddAti = 35171,
		// Token: 0x04002CAE RID: 11438
		MulAti,
		// Token: 0x04002CAF RID: 11439
		SubAti,
		// Token: 0x04002CB0 RID: 11440
		Dot3Ati,
		// Token: 0x04002CB1 RID: 11441
		Dot4Ati,
		// Token: 0x04002CB2 RID: 11442
		MadAti,
		// Token: 0x04002CB3 RID: 11443
		LerpAti,
		// Token: 0x04002CB4 RID: 11444
		CndAti,
		// Token: 0x04002CB5 RID: 11445
		Cnd0Ati,
		// Token: 0x04002CB6 RID: 11446
		Dot2AddAti,
		// Token: 0x04002CB7 RID: 11447
		SecondaryInterpolatorAti,
		// Token: 0x04002CB8 RID: 11448
		NumFragmentRegistersAti,
		// Token: 0x04002CB9 RID: 11449
		NumFragmentConstantsAti,
		// Token: 0x04002CBA RID: 11450
		NumPassesAti,
		// Token: 0x04002CBB RID: 11451
		NumInstructionsPerPassAti,
		// Token: 0x04002CBC RID: 11452
		NumInstructionsTotalAti,
		// Token: 0x04002CBD RID: 11453
		NumInputInterpolatorComponentsAti,
		// Token: 0x04002CBE RID: 11454
		NumLoopbackComponentsAti,
		// Token: 0x04002CBF RID: 11455
		ColorAlphaPairingAti,
		// Token: 0x04002CC0 RID: 11456
		SwizzleStrAti,
		// Token: 0x04002CC1 RID: 11457
		SwizzleStqAti,
		// Token: 0x04002CC2 RID: 11458
		SwizzleStrDrAti,
		// Token: 0x04002CC3 RID: 11459
		SwizzleStqDqAti,
		// Token: 0x04002CC4 RID: 11460
		SwizzleStrqAti,
		// Token: 0x04002CC5 RID: 11461
		SwizzleStrqDqAti
	}
}
