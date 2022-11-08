using System;
using csogg;

namespace csvorbis
{
	// Token: 0x02000077 RID: 119
	internal abstract class FuncTime
	{
		// Token: 0x060003E6 RID: 998
		public abstract void pack(object i, csBuffer opb);

		// Token: 0x060003E7 RID: 999
		public abstract object unpack(Info vi, csBuffer opb);

		// Token: 0x060003E8 RID: 1000
		public abstract object look(DspState vd, InfoMode vm, object i);

		// Token: 0x060003E9 RID: 1001
		public abstract void free_info(object i);

		// Token: 0x060003EA RID: 1002
		public abstract void free_look(object i);

		// Token: 0x060003EB RID: 1003
		public abstract int forward(Block vb, object i);

		// Token: 0x060003EC RID: 1004
		public abstract int inverse(Block vb, object i, float[] fin, float[] fout);

		// Token: 0x04000216 RID: 534
		public static FuncTime[] time_P = new FuncTime[]
		{
			new Time0()
		};
	}
}
