using System;
using csogg;

namespace csvorbis
{
	// Token: 0x02000089 RID: 137
	internal class Time0 : FuncTime
	{
		// Token: 0x06000442 RID: 1090 RVA: 0x00006325 File Offset: 0x00004525
		public override void pack(object i, csBuffer opb)
		{
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0001549A File Offset: 0x0001369A
		public override object unpack(Info vi, csBuffer opb)
		{
			return "";
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0001549A File Offset: 0x0001369A
		public override object look(DspState vd, InfoMode mi, object i)
		{
			return "";
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_info(object i)
		{
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_look(object i)
		{
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000225B File Offset: 0x0000045B
		public override int forward(Block vb, object i)
		{
			return 0;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000225B File Offset: 0x0000045B
		public override int inverse(Block vb, object i, float[] fin, float[] fout)
		{
			return 0;
		}
	}
}
