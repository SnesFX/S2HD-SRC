using System;
using System.Runtime.CompilerServices;
using csogg;

namespace csvorbis
{
	// Token: 0x02000083 RID: 131
	internal class Residue0 : FuncResidue
	{
		// Token: 0x06000421 RID: 1057 RVA: 0x000144B0 File Offset: 0x000126B0
		public override void pack(object vr, csBuffer opb)
		{
			InfoResidue0 infoResidue = (InfoResidue0)vr;
			int num = 0;
			opb.write(infoResidue.begin, 24);
			opb.write(infoResidue.end, 24);
			opb.write(infoResidue.grouping - 1, 24);
			opb.write(infoResidue.partitions - 1, 6);
			opb.write(infoResidue.groupbook, 8);
			for (int i = 0; i < infoResidue.partitions; i++)
			{
				if (Residue0.ilog(infoResidue.secondstages[i]) > 3)
				{
					opb.write(infoResidue.secondstages[i], 3);
					opb.write(1, 1);
					opb.write(infoResidue.secondstages[i] >> 3, 5);
				}
				else
				{
					opb.write(infoResidue.secondstages[i], 4);
				}
				num += Residue0.icount(infoResidue.secondstages[i]);
			}
			for (int j = 0; j < num; j++)
			{
				opb.write(infoResidue.booklist[j], 8);
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00014594 File Offset: 0x00012794
		public override object unpack(Info vi, csBuffer opb)
		{
			int num = 0;
			InfoResidue0 infoResidue = new InfoResidue0();
			infoResidue.begin = opb.read(24);
			infoResidue.end = opb.read(24);
			infoResidue.grouping = opb.read(24) + 1;
			infoResidue.partitions = opb.read(6) + 1;
			infoResidue.groupbook = opb.read(8);
			for (int i = 0; i < infoResidue.partitions; i++)
			{
				int num2 = opb.read(3);
				if (opb.read(1) != 0)
				{
					num2 |= opb.read(5) << 3;
				}
				infoResidue.secondstages[i] = num2;
				num += Residue0.icount(num2);
			}
			for (int j = 0; j < num; j++)
			{
				infoResidue.booklist[j] = opb.read(8);
			}
			if (infoResidue.groupbook >= vi.books)
			{
				this.free_info(infoResidue);
				return null;
			}
			for (int k = 0; k < num; k++)
			{
				if (infoResidue.booklist[k] >= vi.books)
				{
					this.free_info(infoResidue);
					return null;
				}
			}
			return infoResidue;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00014694 File Offset: 0x00012894
		public override object look(DspState vd, InfoMode vm, object vr)
		{
			InfoResidue0 infoResidue = (InfoResidue0)vr;
			LookResidue0 lookResidue = new LookResidue0();
			int num = 0;
			int num2 = 0;
			lookResidue.info = infoResidue;
			lookResidue.map = vm.mapping;
			lookResidue.parts = infoResidue.partitions;
			lookResidue.fullbooks = vd.fullbooks;
			lookResidue.phrasebook = vd.fullbooks[infoResidue.groupbook];
			int dim = lookResidue.phrasebook.dim;
			lookResidue.partbooks = new int[lookResidue.parts][];
			for (int i = 0; i < lookResidue.parts; i++)
			{
				int num3 = Residue0.ilog(infoResidue.secondstages[i]);
				if (num3 != 0)
				{
					if (num3 > num2)
					{
						num2 = num3;
					}
					lookResidue.partbooks[i] = new int[num3];
					for (int j = 0; j < num3; j++)
					{
						if ((infoResidue.secondstages[i] & 1 << j) != 0)
						{
							lookResidue.partbooks[i][j] = infoResidue.booklist[num++];
						}
					}
				}
			}
			lookResidue.partvals = (int)Math.Round(Math.Pow((double)lookResidue.parts, (double)dim));
			lookResidue.stages = num2;
			lookResidue.decodemap = new int[lookResidue.partvals][];
			for (int k = 0; k < lookResidue.partvals; k++)
			{
				int num4 = k;
				int num5 = lookResidue.partvals / lookResidue.parts;
				lookResidue.decodemap[k] = new int[dim];
				for (int l = 0; l < dim; l++)
				{
					int num6 = num4 / num5;
					num4 -= num6 * num5;
					num5 /= lookResidue.parts;
					lookResidue.decodemap[k][l] = num6;
				}
			}
			return lookResidue;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_info(object i)
		{
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_look(object i)
		{
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000225B File Offset: 0x0000045B
		public override int forward(Block vb, object vl, float[][] fin, int ch)
		{
			return 0;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00014834 File Offset: 0x00012A34
		[MethodImpl(MethodImplOptions.Synchronized)]
		internal static int _01inverse(Block vb, object vl, float[][] fin, int ch, int decodepart)
		{
			LookResidue0 lookResidue = (LookResidue0)vl;
			InfoResidue0 info = lookResidue.info;
			int grouping = info.grouping;
			int dim = lookResidue.phrasebook.dim;
			int num = (info.end - info.begin) / grouping;
			int num2 = (num + dim - 1) / dim;
			if (Residue0.partword.Length < ch)
			{
				Residue0.partword = new int[ch][][];
				for (int i = 0; i < ch; i++)
				{
					Residue0.partword[i] = new int[num2][];
				}
			}
			else
			{
				for (int i = 0; i < ch; i++)
				{
					if (Residue0.partword[i] == null || Residue0.partword[i].Length < num2)
					{
						Residue0.partword[i] = new int[num2][];
					}
				}
			}
			for (int j = 0; j < lookResidue.stages; j++)
			{
				int k = 0;
				int num3 = 0;
				while (k < num)
				{
					if (j == 0)
					{
						for (int i = 0; i < ch; i++)
						{
							int num4 = lookResidue.phrasebook.decode(vb.opb);
							if (num4 == -1)
							{
								return 0;
							}
							Residue0.partword[i][num3] = lookResidue.decodemap[num4];
							if (Residue0.partword[i][num3] == null)
							{
								return 0;
							}
						}
					}
					int num5 = 0;
					while (num5 < dim && k < num)
					{
						for (int i = 0; i < ch; i++)
						{
							int offset = info.begin + k * grouping;
							if ((info.secondstages[Residue0.partword[i][num3][num5]] & 1 << j) != 0)
							{
								CodeBook codeBook = lookResidue.fullbooks[lookResidue.partbooks[Residue0.partword[i][num3][num5]][j]];
								if (codeBook != null)
								{
									if (decodepart == 0)
									{
										if (codeBook.decodevs_add(fin[i], offset, vb.opb, grouping) == -1)
										{
											return 0;
										}
									}
									else if (decodepart == 1 && codeBook.decodev_add(fin[i], offset, vb.opb, grouping) == -1)
									{
										return 0;
									}
								}
							}
						}
						num5++;
						k++;
					}
					num3++;
				}
			}
			return 0;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00014A20 File Offset: 0x00012C20
		internal static int _2inverse(Block vb, object vl, float[][] fin, int ch)
		{
			LookResidue0 lookResidue = (LookResidue0)vl;
			InfoResidue0 info = lookResidue.info;
			int grouping = info.grouping;
			int dim = lookResidue.phrasebook.dim;
			int num = (info.end - info.begin) / grouping;
			int[][] array = new int[(num + dim - 1) / dim][];
			for (int i = 0; i < lookResidue.stages; i++)
			{
				int j = 0;
				int num2 = 0;
				while (j < num)
				{
					if (i == 0)
					{
						int num3 = lookResidue.phrasebook.decode(vb.opb);
						if (num3 == -1)
						{
							return 0;
						}
						array[num2] = lookResidue.decodemap[num3];
						if (array[num2] == null)
						{
							return 0;
						}
					}
					int num4 = 0;
					while (num4 < dim && j < num)
					{
						int offset = info.begin + j * grouping;
						if ((info.secondstages[array[num2][num4]] & 1 << i) != 0)
						{
							CodeBook codeBook = lookResidue.fullbooks[lookResidue.partbooks[array[num2][num4]][i]];
							if (codeBook != null && codeBook.decodevv_add(fin, offset, ch, vb.opb, grouping) == -1)
							{
								return 0;
							}
						}
						num4++;
						j++;
					}
					num2++;
				}
			}
			return 0;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00014B50 File Offset: 0x00012D50
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
				return Residue0._01inverse(vb, vl, fin, num, 0);
			}
			return 0;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00014B8C File Offset: 0x00012D8C
		internal static int ilog(int v)
		{
			int num = 0;
			while (v != 0)
			{
				num++;
				v = (int)((uint)v >> 1);
			}
			return num;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00014BAC File Offset: 0x00012DAC
		internal static int icount(int v)
		{
			int num = 0;
			while (v != 0)
			{
				num += (v & 1);
				v = (int)((uint)v >> 1);
			}
			return num;
		}

		// Token: 0x0400027F RID: 639
		private static int[][][] partword = new int[2][][];
	}
}
