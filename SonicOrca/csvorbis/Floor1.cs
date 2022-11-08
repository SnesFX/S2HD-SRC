using System;
using csogg;

namespace csvorbis
{
	// Token: 0x0200006F RID: 111
	internal class Floor1 : FuncFloor
	{
		// Token: 0x060003B3 RID: 947 RVA: 0x000112C4 File Offset: 0x0000F4C4
		public override void pack(object i, csBuffer opb)
		{
			InfoFloor1 infoFloor = (InfoFloor1)i;
			int num = 0;
			int v = infoFloor.postlist[1];
			int num2 = -1;
			opb.write(infoFloor.partitions, 5);
			for (int j = 0; j < infoFloor.partitions; j++)
			{
				opb.write(infoFloor.partitionclass[j], 4);
				if (num2 < infoFloor.partitionclass[j])
				{
					num2 = infoFloor.partitionclass[j];
				}
			}
			for (int k = 0; k < num2 + 1; k++)
			{
				opb.write(infoFloor.class_dim[k] - 1, 3);
				opb.write(infoFloor.class_subs[k], 2);
				if (infoFloor.class_subs[k] != 0)
				{
					opb.write(infoFloor.class_book[k], 8);
				}
				for (int l = 0; l < 1 << infoFloor.class_subs[k]; l++)
				{
					opb.write(infoFloor.class_subbook[k][l] + 1, 8);
				}
			}
			opb.write(infoFloor.mult - 1, 2);
			opb.write(Floor1.ilog2(v), 4);
			int bits = Floor1.ilog2(v);
			int m = 0;
			int n = 0;
			while (m < infoFloor.partitions)
			{
				num += infoFloor.class_dim[infoFloor.partitionclass[m]];
				while (n < num)
				{
					opb.write(infoFloor.postlist[n + 2], bits);
					n++;
				}
				m++;
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00011420 File Offset: 0x0000F620
		public override object unpack(Info vi, csBuffer opb)
		{
			int num = 0;
			int num2 = -1;
			InfoFloor1 infoFloor = new InfoFloor1();
			infoFloor.partitions = opb.read(5);
			for (int i = 0; i < infoFloor.partitions; i++)
			{
				infoFloor.partitionclass[i] = opb.read(4);
				if (num2 < infoFloor.partitionclass[i])
				{
					num2 = infoFloor.partitionclass[i];
				}
			}
			for (int j = 0; j < num2 + 1; j++)
			{
				infoFloor.class_dim[j] = opb.read(3) + 1;
				infoFloor.class_subs[j] = opb.read(2);
				if (infoFloor.class_subs[j] < 0)
				{
					infoFloor.free();
					return null;
				}
				if (infoFloor.class_subs[j] != 0)
				{
					infoFloor.class_book[j] = opb.read(8);
				}
				if (infoFloor.class_book[j] < 0 || infoFloor.class_book[j] >= vi.books)
				{
					infoFloor.free();
					return null;
				}
				for (int k = 0; k < 1 << infoFloor.class_subs[j]; k++)
				{
					infoFloor.class_subbook[j][k] = opb.read(8) - 1;
					if (infoFloor.class_subbook[j][k] < -1 || infoFloor.class_subbook[j][k] >= vi.books)
					{
						infoFloor.free();
						return null;
					}
				}
			}
			infoFloor.mult = opb.read(2) + 1;
			int num3 = opb.read(4);
			int l = 0;
			int m = 0;
			while (l < infoFloor.partitions)
			{
				num += infoFloor.class_dim[infoFloor.partitionclass[l]];
				while (m < num)
				{
					int num4 = infoFloor.postlist[m + 2] = opb.read(num3);
					if (num4 < 0 || num4 >= 1 << num3)
					{
						infoFloor.free();
						return null;
					}
					m++;
				}
				l++;
			}
			infoFloor.postlist[0] = 0;
			infoFloor.postlist[1] = 1 << num3;
			return infoFloor;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00011604 File Offset: 0x0000F804
		public override object look(DspState vd, InfoMode mi, object i)
		{
			int num = 0;
			int[] array = new int[Floor1.VIF_POSIT + 2];
			InfoFloor1 infoFloor = (InfoFloor1)i;
			LookFloor1 lookFloor = new LookFloor1();
			lookFloor.vi = infoFloor;
			lookFloor.n = infoFloor.postlist[1];
			for (int j = 0; j < infoFloor.partitions; j++)
			{
				num += infoFloor.class_dim[infoFloor.partitionclass[j]];
			}
			num += 2;
			lookFloor.posts = num;
			for (int k = 0; k < num; k++)
			{
				array[k] = k;
			}
			for (int l = 0; l < num - 1; l++)
			{
				for (int m = l; m < num; m++)
				{
					if (infoFloor.postlist[array[l]] > infoFloor.postlist[array[m]])
					{
						int num2 = array[m];
						array[m] = array[l];
						array[l] = num2;
					}
				}
			}
			for (int n = 0; n < num; n++)
			{
				lookFloor.forward_index[n] = array[n];
			}
			for (int num3 = 0; num3 < num; num3++)
			{
				lookFloor.reverse_index[lookFloor.forward_index[num3]] = num3;
			}
			for (int num4 = 0; num4 < num; num4++)
			{
				lookFloor.sorted_index[num4] = infoFloor.postlist[lookFloor.forward_index[num4]];
			}
			switch (infoFloor.mult)
			{
			case 1:
				lookFloor.quant_q = 256;
				break;
			case 2:
				lookFloor.quant_q = 128;
				break;
			case 3:
				lookFloor.quant_q = 86;
				break;
			case 4:
				lookFloor.quant_q = 64;
				break;
			default:
				lookFloor.quant_q = -1;
				break;
			}
			for (int num5 = 0; num5 < num - 2; num5++)
			{
				int num6 = 0;
				int num7 = 1;
				int num8 = 0;
				int num9 = lookFloor.n;
				int num10 = infoFloor.postlist[num5 + 2];
				for (int num11 = 0; num11 < num5 + 2; num11++)
				{
					int num12 = infoFloor.postlist[num11];
					if (num12 > num8 && num12 < num10)
					{
						num6 = num11;
						num8 = num12;
					}
					if (num12 < num9 && num12 > num10)
					{
						num7 = num11;
						num9 = num12;
					}
				}
				lookFloor.loneighbor[num5] = num6;
				lookFloor.hineighbor[num5] = num7;
			}
			return lookFloor;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_info(object i)
		{
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_look(object i)
		{
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_state(object vs)
		{
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000225B File Offset: 0x0000045B
		public override int forward(Block vb, object i, float[] fin, float[] fout, object vs)
		{
			return 0;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00011830 File Offset: 0x0000FA30
		public override object inverse1(Block vb, object ii, object memo)
		{
			LookFloor1 lookFloor = (LookFloor1)ii;
			InfoFloor1 vi = lookFloor.vi;
			CodeBook[] fullbooks = vb.vd.fullbooks;
			if (vb.opb.read(1) == 1)
			{
				int[] array = null;
				if (memo is int[])
				{
					array = (int[])memo;
				}
				if (array == null || array.Length < lookFloor.posts)
				{
					array = new int[lookFloor.posts];
				}
				else
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = 0;
					}
				}
				array[0] = vb.opb.read(Floor1.ilog(lookFloor.quant_q - 1));
				array[1] = vb.opb.read(Floor1.ilog(lookFloor.quant_q - 1));
				int j = 0;
				int num = 2;
				while (j < vi.partitions)
				{
					int num2 = vi.partitionclass[j];
					int num3 = vi.class_dim[num2];
					int num4 = vi.class_subs[num2];
					int num5 = 1 << num4;
					int num6 = 0;
					if (num4 != 0)
					{
						num6 = fullbooks[vi.class_book[num2]].decode(vb.opb);
						if (num6 == -1)
						{
							return null;
						}
					}
					for (int k = 0; k < num3; k++)
					{
						int num7 = vi.class_subbook[num2][num6 & num5 - 1];
						num6 = (int)((uint)num6 >> num4);
						if (num7 >= 0)
						{
							if ((array[num + k] = fullbooks[num7].decode(vb.opb)) == -1)
							{
								return null;
							}
						}
						else
						{
							array[num + k] = 0;
						}
					}
					num += num3;
					j++;
				}
				for (int l = 2; l < lookFloor.posts; l++)
				{
					int num8 = Floor1.render_point(vi.postlist[lookFloor.loneighbor[l - 2]], vi.postlist[lookFloor.hineighbor[l - 2]], array[lookFloor.loneighbor[l - 2]], array[lookFloor.hineighbor[l - 2]], vi.postlist[l]);
					int num9 = lookFloor.quant_q - num8;
					int num10 = num8;
					int num11 = ((num9 < num10) ? num9 : num10) << 1;
					int num12 = array[l];
					if (num12 != 0)
					{
						if (num12 >= num11)
						{
							if (num9 > num10)
							{
								num12 -= num10;
							}
							else
							{
								num12 = -1 - (num12 - num9);
							}
						}
						else if ((num12 & 1) != 0)
						{
							num12 = (int)(-(int)((ulong)((uint)(num12 + 1) >> 1)));
						}
						else
						{
							num12 >>= 1;
						}
						array[l] = num12 + num8;
						array[lookFloor.loneighbor[l - 2]] &= 32767;
						array[lookFloor.hineighbor[l - 2]] &= 32767;
					}
					else
					{
						array[l] = (num8 | 32768);
					}
				}
				return array;
			}
			return null;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00011ACC File Offset: 0x0000FCCC
		private static int render_point(int x0, int x1, int y0, int y1, int x)
		{
			y0 &= 32767;
			y1 &= 32767;
			int num = y1 - y0;
			int num2 = x1 - x0;
			int num3 = Math.Abs(num) * (x - x0) / num2;
			if (num < 0)
			{
				return y0 - num3;
			}
			return y0 + num3;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00011B0C File Offset: 0x0000FD0C
		public override int inverse2(Block vb, object i, object memo, float[] fout)
		{
			LookFloor1 lookFloor = (LookFloor1)i;
			InfoFloor1 vi = lookFloor.vi;
			int num = vb.vd.vi.blocksizes[vb.mode] / 2;
			if (memo != null)
			{
				int[] array = (int[])memo;
				int num2 = 0;
				int x = 0;
				int y = array[0] * vi.mult;
				for (int j = 1; j < lookFloor.posts; j++)
				{
					int num3 = lookFloor.forward_index[j];
					int num4 = array[num3] & 32767;
					if (num4 == array[num3])
					{
						num4 *= vi.mult;
						num2 = vi.postlist[num3];
						Floor1.render_line(x, num2, y, num4, fout);
						x = num2;
						y = num4;
					}
				}
				for (int k = num2; k < num; k++)
				{
					fout[k] *= fout[k - 1];
				}
				return 1;
			}
			for (int l = 0; l < num; l++)
			{
				fout[l] = 0f;
			}
			return 0;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x00011C04 File Offset: 0x0000FE04
		private static void render_line(int x0, int x1, int y0, int y1, float[] d)
		{
			int num = y1 - y0;
			int num2 = x1 - x0;
			int num3 = Math.Abs(num);
			int num4 = num / num2;
			int num5 = (num < 0) ? (num4 - 1) : (num4 + 1);
			int num6 = x0;
			int num7 = y0;
			int num8 = 0;
			num3 -= Math.Abs(num4 * num2);
			d[num6] *= Floor1.FLOOR_fromdB_LOOKUP[num7];
			while (++num6 < x1)
			{
				num8 += num3;
				if (num8 >= num2)
				{
					num8 -= num2;
					num7 += num5;
				}
				else
				{
					num7 += num4;
				}
				d[num6] *= Floor1.FLOOR_fromdB_LOOKUP[num7];
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00011C98 File Offset: 0x0000FE98
		private static int ilog(int v)
		{
			int num = 0;
			while (v != 0)
			{
				num++;
				v = (int)((uint)v >> 1);
			}
			return num;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00011CB8 File Offset: 0x0000FEB8
		private static int ilog2(int v)
		{
			int num = 0;
			while (v > 1)
			{
				num++;
				v = (int)((uint)v >> 1);
			}
			return num;
		}

		// Token: 0x040001F1 RID: 497
		private static int floor1_rangedb = 140;

		// Token: 0x040001F2 RID: 498
		private static int VIF_POSIT = 63;

		// Token: 0x040001F3 RID: 499
		private static float[] FLOOR_fromdB_LOOKUP = new float[]
		{
			1.0649863E-07f,
			1.1341951E-07f,
			1.2079015E-07f,
			1.2863978E-07f,
			1.369995E-07f,
			1.459025E-07f,
			1.5538409E-07f,
			1.6548181E-07f,
			1.7623574E-07f,
			1.8768856E-07f,
			1.998856E-07f,
			2.128753E-07f,
			2.2670913E-07f,
			2.4144197E-07f,
			2.5713223E-07f,
			2.7384212E-07f,
			2.9163792E-07f,
			3.1059022E-07f,
			3.307741E-07f,
			3.5226967E-07f,
			3.7516213E-07f,
			3.995423E-07f,
			4.255068E-07f,
			4.5315863E-07f,
			4.8260745E-07f,
			5.1397E-07f,
			5.4737063E-07f,
			5.829419E-07f,
			6.208247E-07f,
			6.611694E-07f,
			7.041359E-07f,
			7.4989464E-07f,
			7.98627E-07f,
			8.505263E-07f,
			9.057983E-07f,
			9.646621E-07f,
			1.0273513E-06f,
			1.0941144E-06f,
			1.1652161E-06f,
			1.2409384E-06f,
			1.3215816E-06f,
			1.4074654E-06f,
			1.4989305E-06f,
			1.5963394E-06f,
			1.7000785E-06f,
			1.8105592E-06f,
			1.9282195E-06f,
			2.053526E-06f,
			2.1869757E-06f,
			2.3290977E-06f,
			2.4804558E-06f,
			2.6416496E-06f,
			2.813319E-06f,
			2.9961443E-06f,
			3.1908505E-06f,
			3.39821E-06f,
			3.619045E-06f,
			3.8542307E-06f,
			4.1047006E-06f,
			4.371447E-06f,
			4.6555283E-06f,
			4.958071E-06f,
			5.280274E-06f,
			5.623416E-06f,
			5.988857E-06f,
			6.3780467E-06f,
			6.7925284E-06f,
			7.2339453E-06f,
			7.704048E-06f,
			8.2047E-06f,
			8.737888E-06f,
			9.305725E-06f,
			9.910464E-06f,
			1.0554501E-05f,
			1.1240392E-05f,
			1.1970856E-05f,
			1.2748789E-05f,
			1.3577278E-05f,
			1.4459606E-05f,
			1.5399271E-05f,
			1.6400005E-05f,
			1.7465769E-05f,
			1.8600793E-05f,
			1.9809577E-05f,
			2.1096914E-05f,
			2.2467912E-05f,
			2.3928002E-05f,
			2.5482977E-05f,
			2.7139005E-05f,
			2.890265E-05f,
			3.078091E-05f,
			3.2781227E-05f,
			3.4911533E-05f,
			3.718028E-05f,
			3.9596467E-05f,
			4.2169668E-05f,
			4.491009E-05f,
			4.7828602E-05f,
			5.0936775E-05f,
			5.424693E-05f,
			5.7772202E-05f,
			6.152657E-05f,
			6.552491E-05f,
			6.9783084E-05f,
			7.4317984E-05f,
			7.914758E-05f,
			8.429104E-05f,
			8.976875E-05f,
			9.560242E-05f,
			0.00010181521f,
			0.00010843174f,
			0.00011547824f,
			0.00012298267f,
			0.00013097477f,
			0.00013948625f,
			0.00014855085f,
			0.00015820454f,
			0.00016848555f,
			0.00017943469f,
			0.00019109536f,
			0.00020351382f,
			0.0002167393f,
			0.00023082423f,
			0.00024582449f,
			0.00026179955f,
			0.00027881275f,
			0.00029693157f,
			0.00031622787f,
			0.00033677815f,
			0.00035866388f,
			0.00038197188f,
			0.00040679457f,
			0.00043323037f,
			0.0004613841f,
			0.0004913675f,
			0.00052329927f,
			0.0005573062f,
			0.0005935231f,
			0.0006320936f,
			0.0006731706f,
			0.000716917f,
			0.0007635063f,
			0.00081312325f,
			0.00086596457f,
			0.00092223985f,
			0.0009821722f,
			0.0010459992f,
			0.0011139743f,
			0.0011863665f,
			0.0012634633f,
			0.0013455702f,
			0.0014330129f,
			0.0015261382f,
			0.0016253153f,
			0.0017309374f,
			0.0018434235f,
			0.0019632196f,
			0.0020908006f,
			0.0022266726f,
			0.0023713743f,
			0.0025254795f,
			0.0026895993f,
			0.0028643848f,
			0.0030505287f,
			0.003248769f,
			0.0034598925f,
			0.0036847359f,
			0.0039241905f,
			0.0041792067f,
			0.004450795f,
			0.004740033f,
			0.005048067f,
			0.0053761187f,
			0.005725489f,
			0.0060975635f,
			0.0064938175f,
			0.0069158226f,
			0.0073652514f,
			0.007843887f,
			0.008353627f,
			0.008896492f,
			0.009474637f,
			0.010090352f,
			0.01074608f,
			0.011444421f,
			0.012188144f,
			0.012980198f,
			0.013823725f,
			0.014722068f,
			0.015678791f,
			0.016697686f,
			0.017782796f,
			0.018938422f,
			0.020169148f,
			0.021479854f,
			0.022875736f,
			0.02436233f,
			0.025945531f,
			0.027631618f,
			0.029427277f,
			0.031339627f,
			0.03337625f,
			0.035545226f,
			0.037855156f,
			0.0403152f,
			0.042935107f,
			0.045725275f,
			0.048696756f,
			0.05186135f,
			0.05523159f,
			0.05882085f,
			0.062643364f,
			0.06671428f,
			0.07104975f,
			0.075666964f,
			0.08058423f,
			0.08582105f,
			0.09139818f,
			0.097337745f,
			0.1036633f,
			0.11039993f,
			0.11757434f,
			0.12521498f,
			0.13335215f,
			0.14201812f,
			0.15124726f,
			0.16107617f,
			0.1715438f,
			0.18269168f,
			0.19456401f,
			0.20720787f,
			0.22067343f,
			0.23501402f,
			0.25028655f,
			0.26655158f,
			0.28387362f,
			0.3023213f,
			0.32196787f,
			0.34289113f,
			0.36517414f,
			0.3889052f,
			0.41417846f,
			0.44109413f,
			0.4697589f,
			0.50028646f,
			0.53279793f,
			0.5674221f,
			0.6042964f,
			0.64356697f,
			0.6853896f,
			0.72993004f,
			0.777365f,
			0.8278826f,
			0.88168305f,
			0.9389798f,
			1f
		};
	}
}
