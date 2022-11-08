using System;
using csogg;

namespace csvorbis
{
	// Token: 0x02000076 RID: 118
	internal abstract class FuncResidue
	{
		// Token: 0x060003DD RID: 989
		public abstract void pack(object vr, csBuffer opb);

		// Token: 0x060003DE RID: 990
		public abstract object unpack(Info vi, csBuffer opb);

		// Token: 0x060003DF RID: 991
		public abstract object look(DspState vd, InfoMode vm, object vr);

		// Token: 0x060003E0 RID: 992
		public abstract void free_info(object i);

		// Token: 0x060003E1 RID: 993
		public abstract void free_look(object i);

		// Token: 0x060003E2 RID: 994
		public abstract int forward(Block vb, object vl, float[][] fin, int ch);

		// Token: 0x060003E3 RID: 995
		public abstract int inverse(Block vb, object vl, float[][] fin, int[] nonzero, int ch);

		// Token: 0x04000215 RID: 533
		public static FuncResidue[] residue_P = new FuncResidue[]
		{
			new Residue0(),
			new Residue1(),
			new Residue2()
		};
	}
}
