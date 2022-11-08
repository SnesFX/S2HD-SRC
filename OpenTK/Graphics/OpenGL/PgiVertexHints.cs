using System;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020003FD RID: 1021
	public enum PgiVertexHints
	{
		// Token: 0x04003D61 RID: 15713
		Vertex23BitPgi = 4,
		// Token: 0x04003D62 RID: 15714
		Vertex4BitPgi = 8,
		// Token: 0x04003D63 RID: 15715
		Color3BitPgi = 65536,
		// Token: 0x04003D64 RID: 15716
		Color4BitPgi = 131072,
		// Token: 0x04003D65 RID: 15717
		EdgeflagBitPgi = 262144,
		// Token: 0x04003D66 RID: 15718
		IndexBitPgi = 524288,
		// Token: 0x04003D67 RID: 15719
		MatAmbientBitPgi = 1048576,
		// Token: 0x04003D68 RID: 15720
		MatAmbientAndDiffuseBitPgi = 2097152,
		// Token: 0x04003D69 RID: 15721
		MatDiffuseBitPgi = 4194304,
		// Token: 0x04003D6A RID: 15722
		MatEmissionBitPgi = 8388608,
		// Token: 0x04003D6B RID: 15723
		MatColorIndexesBitPgi = 16777216,
		// Token: 0x04003D6C RID: 15724
		MatShininessBitPgi = 33554432,
		// Token: 0x04003D6D RID: 15725
		MatSpecularBitPgi = 67108864,
		// Token: 0x04003D6E RID: 15726
		NormalBitPgi = 134217728,
		// Token: 0x04003D6F RID: 15727
		Texcoord1BitPgi = 268435456,
		// Token: 0x04003D70 RID: 15728
		VertexDataHintPgi = 107050,
		// Token: 0x04003D71 RID: 15729
		VertexConsistentHintPgi,
		// Token: 0x04003D72 RID: 15730
		MaterialSideHintPgi,
		// Token: 0x04003D73 RID: 15731
		MaxVertexHintPgi,
		// Token: 0x04003D74 RID: 15732
		Texcoord2BitPgi = 536870912,
		// Token: 0x04003D75 RID: 15733
		Texcoord3BitPgi = 1073741824,
		// Token: 0x04003D76 RID: 15734
		Texcoord4BitPgi = -2147483648
	}
}
