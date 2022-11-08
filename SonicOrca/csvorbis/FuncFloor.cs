using System;
using csogg;

namespace csvorbis
{
	// Token: 0x02000074 RID: 116
	internal abstract class FuncFloor
	{
		// Token: 0x060003CA RID: 970
		public abstract void pack(object i, csBuffer opb);

		// Token: 0x060003CB RID: 971
		public abstract object unpack(Info vi, csBuffer opb);

		// Token: 0x060003CC RID: 972
		public abstract object look(DspState vd, InfoMode mi, object i);

		// Token: 0x060003CD RID: 973
		public abstract void free_info(object i);

		// Token: 0x060003CE RID: 974
		public abstract void free_look(object i);

		// Token: 0x060003CF RID: 975
		public abstract void free_state(object vs);

		// Token: 0x060003D0 RID: 976
		public abstract int forward(Block vb, object i, float[] fin, float[] fout, object vs);

		// Token: 0x060003D1 RID: 977
		public abstract object inverse1(Block vb, object i, object memo);

		// Token: 0x060003D2 RID: 978
		public abstract int inverse2(Block vb, object i, object memo, float[] fout);

		// Token: 0x04000213 RID: 531
		public static FuncFloor[] floor_P = new FuncFloor[]
		{
			new Floor0(),
			new Floor1()
		};
	}
}
