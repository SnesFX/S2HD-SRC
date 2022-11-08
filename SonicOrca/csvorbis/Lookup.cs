using System;

namespace csvorbis
{
	// Token: 0x0200007A RID: 122
	internal class Lookup
	{
		// Token: 0x060003FC RID: 1020 RVA: 0x00012C54 File Offset: 0x00010E54
		internal static float coslook(float a)
		{
			double num = (double)a * (0.31830989 * (double)((float)Lookup.COS_LOOKUP_SZ));
			int num2 = (int)num;
			return Lookup.COS_LOOKUP[num2] + (float)(num - (double)num2) * (Lookup.COS_LOOKUP[num2 + 1] - Lookup.COS_LOOKUP[num2]);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00012C98 File Offset: 0x00010E98
		internal static float invsqlook(float a)
		{
			double num = (double)(a * (2f * (float)Lookup.INVSQ_LOOKUP_SZ) - (float)Lookup.INVSQ_LOOKUP_SZ);
			int num2 = (int)num;
			return Lookup.INVSQ_LOOKUP[num2] + (float)(num - (double)num2) * (Lookup.INVSQ_LOOKUP[num2 + 1] - Lookup.INVSQ_LOOKUP[num2]);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00012CDE File Offset: 0x00010EDE
		internal static float invsq2explook(int a)
		{
			return Lookup.INVSQ2EXP_LOOKUP[a - Lookup.INVSQ2EXP_LOOKUP_MIN];
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00012CF0 File Offset: 0x00010EF0
		internal static float fromdBlook(float a)
		{
			int num = (int)(a * -8f);
			if (num < 0)
			{
				return 1f;
			}
			if (num < 1120)
			{
				return Lookup.FROMdB_LOOKUP[(int)((uint)num >> 5)] * Lookup.FROMdB2_LOOKUP[num & 31];
			}
			return 0f;
		}

		// Token: 0x0400023C RID: 572
		private static int COS_LOOKUP_SZ = 128;

		// Token: 0x0400023D RID: 573
		private static float[] COS_LOOKUP = new float[]
		{
			1f,
			0.9996988f,
			0.99879545f,
			0.99729043f,
			0.9951847f,
			0.99247956f,
			0.9891765f,
			0.98527765f,
			0.98078525f,
			0.9757021f,
			0.97003126f,
			0.96377605f,
			0.95694035f,
			0.94952816f,
			0.94154406f,
			0.9329928f,
			0.9238795f,
			0.9142098f,
			0.9039893f,
			0.8932243f,
			0.8819213f,
			0.87008697f,
			0.8577286f,
			0.8448536f,
			0.8314696f,
			0.8175848f,
			0.8032075f,
			0.7883464f,
			0.77301043f,
			0.7572088f,
			0.7409511f,
			0.7242471f,
			0.70710677f,
			0.68954057f,
			0.671559f,
			0.65317285f,
			0.6343933f,
			0.6152316f,
			0.5956993f,
			0.57580817f,
			0.55557024f,
			0.53499764f,
			0.51410276f,
			0.4928982f,
			0.47139674f,
			0.44961134f,
			0.42755508f,
			0.4052413f,
			0.38268343f,
			0.35989505f,
			0.33688986f,
			0.31368175f,
			0.29028466f,
			0.26671275f,
			0.24298018f,
			0.21910124f,
			0.19509032f,
			0.17096189f,
			0.14673047f,
			0.12241068f,
			0.09801714f,
			0.07356457f,
			0.049067676f,
			0.024541229f,
			0f,
			-0.024541229f,
			-0.049067676f,
			-0.07356457f,
			-0.09801714f,
			-0.12241068f,
			-0.14673047f,
			-0.17096189f,
			-0.19509032f,
			-0.21910124f,
			-0.24298018f,
			-0.26671275f,
			-0.29028466f,
			-0.31368175f,
			-0.33688986f,
			-0.35989505f,
			-0.38268343f,
			-0.4052413f,
			-0.42755508f,
			-0.44961134f,
			-0.47139674f,
			-0.4928982f,
			-0.51410276f,
			-0.53499764f,
			-0.55557024f,
			-0.57580817f,
			-0.5956993f,
			-0.6152316f,
			-0.6343933f,
			-0.65317285f,
			-0.671559f,
			-0.68954057f,
			-0.70710677f,
			-0.7242471f,
			-0.7409511f,
			-0.7572088f,
			-0.77301043f,
			-0.7883464f,
			-0.8032075f,
			-0.8175848f,
			-0.8314696f,
			-0.8448536f,
			-0.8577286f,
			-0.87008697f,
			-0.8819213f,
			-0.8932243f,
			-0.9039893f,
			-0.9142098f,
			-0.9238795f,
			-0.9329928f,
			-0.94154406f,
			-0.94952816f,
			-0.95694035f,
			-0.96377605f,
			-0.97003126f,
			-0.9757021f,
			-0.98078525f,
			-0.98527765f,
			-0.9891765f,
			-0.99247956f,
			-0.9951847f,
			-0.99729043f,
			-0.99879545f,
			-0.9996988f,
			-1f
		};

		// Token: 0x0400023E RID: 574
		private static int INVSQ_LOOKUP_SZ = 32;

		// Token: 0x0400023F RID: 575
		private static float[] INVSQ_LOOKUP = new float[]
		{
			1.4142135f,
			1.3926213f,
			1.3719887f,
			1.3522468f,
			1.3333334f,
			1.3151919f,
			1.2977713f,
			1.2810252f,
			1.264911f,
			1.2493901f,
			1.2344269f,
			1.2199886f,
			1.2060454f,
			1.1925696f,
			1.1795356f,
			1.16692f,
			1.1547005f,
			1.1428572f,
			1.1313709f,
			1.1202241f,
			1.1094004f,
			1.0988845f,
			1.0886621f,
			1.0787197f,
			1.069045f,
			1.0596259f,
			1.0504515f,
			1.0415113f,
			1.0327955f,
			1.0242951f,
			1.016001f,
			1.0079052f,
			1f
		};

		// Token: 0x04000240 RID: 576
		private static int INVSQ2EXP_LOOKUP_MIN = -32;

		// Token: 0x04000241 RID: 577
		private static float[] INVSQ2EXP_LOOKUP = new float[]
		{
			65536f,
			46340.95f,
			32768f,
			23170.475f,
			16384f,
			11585.237f,
			8192f,
			5792.6187f,
			4096f,
			2896.3093f,
			2048f,
			1448.1547f,
			1024f,
			724.07733f,
			512f,
			362.03867f,
			256f,
			181.01933f,
			128f,
			90.50967f,
			64f,
			45.254833f,
			32f,
			22.627417f,
			16f,
			11.313708f,
			8f,
			5.656854f,
			4f,
			2.828427f,
			2f,
			1.4142135f,
			1f,
			0.70710677f,
			0.5f,
			0.35355338f,
			0.25f,
			0.17677669f,
			0.125f,
			0.088388346f,
			0.0625f,
			0.044194173f,
			0.03125f,
			0.022097087f,
			0.015625f,
			0.011048543f,
			0.0078125f,
			0.0055242716f,
			0.00390625f,
			0.0027621358f,
			0.001953125f,
			0.0013810679f,
			0.0009765625f,
			0.00069053395f,
			0.00048828125f,
			0.00034526698f,
			0.00024414062f,
			0.00017263349f,
			0.00012207031f,
			8.6316744E-05f,
			6.1035156E-05f,
			4.3158372E-05f,
			3.0517578E-05f,
			2.1579186E-05f,
			1.5258789E-05f
		};

		// Token: 0x04000242 RID: 578
		private const int FROMdB_LOOKUP_SZ = 35;

		// Token: 0x04000243 RID: 579
		private const int FROMdB2_LOOKUP_SZ = 32;

		// Token: 0x04000244 RID: 580
		private const int FROMdB_SHIFT = 5;

		// Token: 0x04000245 RID: 581
		private const int FROMdB2_SHIFT = 3;

		// Token: 0x04000246 RID: 582
		private const int FROMdB2_MASK = 31;

		// Token: 0x04000247 RID: 583
		private static float[] FROMdB_LOOKUP = new float[]
		{
			1f,
			0.63095737f,
			0.39810717f,
			0.25118864f,
			0.15848932f,
			0.1f,
			0.06309573f,
			0.039810717f,
			0.025118865f,
			0.015848933f,
			0.01f,
			0.0063095735f,
			0.0039810715f,
			0.0025118864f,
			0.0015848932f,
			0.001f,
			0.00063095737f,
			0.00039810716f,
			0.00025118864f,
			0.00015848932f,
			0.0001f,
			6.309574E-05f,
			3.981072E-05f,
			2.5118865E-05f,
			1.5848931E-05f,
			1E-05f,
			6.3095736E-06f,
			3.9810716E-06f,
			2.5118864E-06f,
			1.5848932E-06f,
			1E-06f,
			6.3095735E-07f,
			3.9810718E-07f,
			2.5118865E-07f,
			1.5848931E-07f
		};

		// Token: 0x04000248 RID: 584
		private static float[] FROMdB2_LOOKUP = new float[]
		{
			0.9928303f,
			0.9786446f,
			0.9646616f,
			0.95087844f,
			0.9372922f,
			0.92390007f,
			0.9106993f,
			0.89768714f,
			0.8848609f,
			0.8722179f,
			0.8597556f,
			0.8474713f,
			0.83536255f,
			0.8234268f,
			0.8116616f,
			0.8000645f,
			0.7886331f,
			0.777365f,
			0.76625794f,
			0.7553096f,
			0.7445176f,
			0.7338799f,
			0.72339416f,
			0.71305823f,
			0.70287f,
			0.6928273f,
			0.68292814f,
			0.6731704f,
			0.66355205f,
			0.65407115f,
			0.64472574f,
			0.63551384f
		};
	}
}
