using System;

namespace csvorbis
{
	// Token: 0x02000087 RID: 135
	internal class Residue2 : Residue0
	{
		// Token: 0x06000433 RID: 1075 RVA: 0x0000225B File Offset: 0x0000045B
		public override int forward(Block vb, object vl, float[][] fin, int ch)
		{
			return 0;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00014C8C File Offset: 0x00012E8C
		public override int inverse(Block vb, object vl, float[][] fin, int[] nonzero, int ch)
		{
			int num = 0;
			while (num < ch && nonzero[num] == 0)
			{
				num++;
			}
			if (num == ch)
			{
				return 0;
			}
			return Residue0._2inverse(vb, vl, fin, ch);
		}
	}
}
