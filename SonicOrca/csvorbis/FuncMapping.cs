using System;
using csogg;

namespace csvorbis
{
	// Token: 0x02000075 RID: 117
	internal abstract class FuncMapping
	{
		// Token: 0x060003D5 RID: 981
		public abstract void pack(Info info, object imap, csBuffer buffer);

		// Token: 0x060003D6 RID: 982
		public abstract object unpack(Info info, csBuffer buffer);

		// Token: 0x060003D7 RID: 983
		public abstract object look(DspState vd, InfoMode vm, object m);

		// Token: 0x060003D8 RID: 984
		public abstract void free_info(object imap);

		// Token: 0x060003D9 RID: 985
		public abstract void free_look(object imap);

		// Token: 0x060003DA RID: 986
		public abstract int inverse(Block vd, object lm);

		// Token: 0x04000214 RID: 532
		public static FuncMapping[] mapping_P = new FuncMapping[]
		{
			new Mapping0()
		};
	}
}
