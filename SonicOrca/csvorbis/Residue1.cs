using System;

namespace csvorbis
{
	// Token: 0x02000086 RID: 134
	internal class Residue1 : Residue0
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x0000225B File Offset: 0x0000045B
		private new int forward(Block vb, object vl, float[][] fin, int ch)
		{
			return 0;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00014C48 File Offset: 0x00012E48
		public override int inverse(Block vb, object vl, float[][] fin, int[] nonzero, int ch)
		{
			int num = 0;
			for (int i = 0; i < ch; i++)
			{
				if (nonzero[i] != 0)
				{
					fin[num++] = fin[i];
				}
			}
			if (num != 0)
			{
				return Residue0._01inverse(vb, vl, fin, num, 1);
			}
			return 0;
		}
	}
}
