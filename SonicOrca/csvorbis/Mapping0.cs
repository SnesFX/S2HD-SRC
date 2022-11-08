using System;
using csogg;

namespace csvorbis
{
	// Token: 0x0200007D RID: 125
	internal class Mapping0 : FuncMapping
	{
		// Token: 0x0600040C RID: 1036 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_info(object imap)
		{
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00006325 File Offset: 0x00004525
		public override void free_look(object imap)
		{
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00013298 File Offset: 0x00011498
		public override object look(DspState vd, InfoMode vm, object m)
		{
			Info vi = vd.vi;
			LookMapping0 lookMapping = new LookMapping0();
			InfoMapping0 infoMapping = lookMapping.map = (InfoMapping0)m;
			lookMapping.mode = vm;
			lookMapping.time_look = new object[infoMapping.submaps];
			lookMapping.floor_look = new object[infoMapping.submaps];
			lookMapping.residue_look = new object[infoMapping.submaps];
			lookMapping.time_func = new FuncTime[infoMapping.submaps];
			lookMapping.floor_func = new FuncFloor[infoMapping.submaps];
			lookMapping.residue_func = new FuncResidue[infoMapping.submaps];
			for (int i = 0; i < infoMapping.submaps; i++)
			{
				int num = infoMapping.timesubmap[i];
				int num2 = infoMapping.floorsubmap[i];
				int num3 = infoMapping.residuesubmap[i];
				lookMapping.time_func[i] = FuncTime.time_P[vi.time_type[num]];
				lookMapping.time_look[i] = lookMapping.time_func[i].look(vd, vm, vi.time_param[num]);
				lookMapping.floor_func[i] = FuncFloor.floor_P[vi.floor_type[num2]];
				lookMapping.floor_look[i] = lookMapping.floor_func[i].look(vd, vm, vi.floor_param[num2]);
				lookMapping.residue_func[i] = FuncResidue.residue_P[vi.residue_type[num3]];
				lookMapping.residue_look[i] = lookMapping.residue_func[i].look(vd, vm, vi.residue_param[num3]);
			}
			if (vi.psys != 0)
			{
				int analysisp = vd.analysisp;
			}
			lookMapping.ch = vi.channels;
			return lookMapping;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00013438 File Offset: 0x00011638
		public override void pack(Info vi, object imap, csBuffer opb)
		{
			InfoMapping0 infoMapping = (InfoMapping0)imap;
			if (infoMapping.submaps > 1)
			{
				opb.write(1, 1);
				opb.write(infoMapping.submaps - 1, 4);
			}
			else
			{
				opb.write(0, 1);
			}
			if (infoMapping.coupling_steps > 0)
			{
				opb.write(1, 1);
				opb.write(infoMapping.coupling_steps - 1, 8);
				for (int i = 0; i < infoMapping.coupling_steps; i++)
				{
					opb.write(infoMapping.coupling_mag[i], Mapping0.ilog2(vi.channels));
					opb.write(infoMapping.coupling_ang[i], Mapping0.ilog2(vi.channels));
				}
			}
			else
			{
				opb.write(0, 1);
			}
			opb.write(0, 2);
			if (infoMapping.submaps > 1)
			{
				for (int j = 0; j < vi.channels; j++)
				{
					opb.write(infoMapping.chmuxlist[j], 4);
				}
			}
			for (int k = 0; k < infoMapping.submaps; k++)
			{
				opb.write(infoMapping.timesubmap[k], 8);
				opb.write(infoMapping.floorsubmap[k], 8);
				opb.write(infoMapping.residuesubmap[k], 8);
			}
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00013554 File Offset: 0x00011754
		public override object unpack(Info vi, csBuffer opb)
		{
			InfoMapping0 infoMapping = new InfoMapping0();
			if (opb.read(1) != 0)
			{
				infoMapping.submaps = opb.read(4) + 1;
			}
			else
			{
				infoMapping.submaps = 1;
			}
			if (opb.read(1) != 0)
			{
				infoMapping.coupling_steps = opb.read(8) + 1;
				for (int i = 0; i < infoMapping.coupling_steps; i++)
				{
					int num = infoMapping.coupling_mag[i] = opb.read(Mapping0.ilog2(vi.channels));
					int num2 = infoMapping.coupling_ang[i] = opb.read(Mapping0.ilog2(vi.channels));
					if (num < 0 || num2 < 0 || num == num2 || num >= vi.channels || num2 >= vi.channels)
					{
						infoMapping.free();
						return null;
					}
				}
			}
			if (opb.read(2) > 0)
			{
				infoMapping.free();
				return null;
			}
			if (infoMapping.submaps > 1)
			{
				for (int j = 0; j < vi.channels; j++)
				{
					infoMapping.chmuxlist[j] = opb.read(4);
					if (infoMapping.chmuxlist[j] >= infoMapping.submaps)
					{
						infoMapping.free();
						return null;
					}
				}
			}
			for (int k = 0; k < infoMapping.submaps; k++)
			{
				infoMapping.timesubmap[k] = opb.read(8);
				if (infoMapping.timesubmap[k] >= vi.times)
				{
					infoMapping.free();
					return null;
				}
				infoMapping.floorsubmap[k] = opb.read(8);
				if (infoMapping.floorsubmap[k] >= vi.floors)
				{
					infoMapping.free();
					return null;
				}
				infoMapping.residuesubmap[k] = opb.read(8);
				if (infoMapping.residuesubmap[k] >= vi.residues)
				{
					infoMapping.free();
					return null;
				}
			}
			return infoMapping;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00013708 File Offset: 0x00011908
		public override int inverse(Block vb, object l)
		{
			int num;
			lock (this)
			{
				DspState vd = vb.vd;
				Info vi = vd.vi;
				LookMapping0 lookMapping = (LookMapping0)l;
				InfoMapping0 map = lookMapping.map;
				InfoMode mode = lookMapping.mode;
				num = (vb.pcmend = vi.blocksizes[vb.W]);
				int num2 = num;
				float[] array = vd.wnd[vb.W][vb.lW][vb.nW][mode.windowtype];
				if (this.pcmbundle == null || this.pcmbundle.Length < vi.channels)
				{
					this.pcmbundle = new float[vi.channels][];
					this.nonzero = new int[vi.channels];
					this.zerobundle = new int[vi.channels];
					this.floormemo = new object[vi.channels];
				}
				for (int i = 0; i < vi.channels; i++)
				{
					float[] array2 = vb.pcm[i];
					int num3 = map.chmuxlist[i];
					this.floormemo[i] = lookMapping.floor_func[num3].inverse1(vb, lookMapping.floor_look[num3], this.floormemo[i]);
					if (this.floormemo[i] != null)
					{
						this.nonzero[i] = 1;
					}
					else
					{
						this.nonzero[i] = 0;
					}
					for (int j = 0; j < num2 / 2; j++)
					{
						array2[j] = 0f;
					}
				}
				for (int k = 0; k < map.coupling_steps; k++)
				{
					if (this.nonzero[map.coupling_mag[k]] != 0 || this.nonzero[map.coupling_ang[k]] != 0)
					{
						this.nonzero[map.coupling_mag[k]] = 1;
						this.nonzero[map.coupling_ang[k]] = 1;
					}
				}
				for (int m = 0; m < map.submaps; m++)
				{
					int num4 = 0;
					for (int n = 0; n < vi.channels; n++)
					{
						if (map.chmuxlist[n] == m)
						{
							if (this.nonzero[n] != 0)
							{
								this.zerobundle[num4] = 1;
							}
							else
							{
								this.zerobundle[num4] = 0;
							}
							this.pcmbundle[num4++] = vb.pcm[n];
						}
					}
					lookMapping.residue_func[m].inverse(vb, lookMapping.residue_look[m], this.pcmbundle, this.zerobundle, num4);
				}
				for (int num5 = map.coupling_steps - 1; num5 >= 0; num5--)
				{
					float[] array3 = vb.pcm[map.coupling_mag[num5]];
					float[] array4 = vb.pcm[map.coupling_ang[num5]];
					for (int num6 = 0; num6 < num2 / 2; num6++)
					{
						float num7 = array3[num6];
						float num8 = array4[num6];
						if (num7 > 0f)
						{
							if (num8 > 0f)
							{
								array3[num6] = num7;
								array4[num6] = num7 - num8;
							}
							else
							{
								array4[num6] = num7;
								array3[num6] = num7 + num8;
							}
						}
						else if (num8 > 0f)
						{
							array3[num6] = num7;
							array4[num6] = num7 + num8;
						}
						else
						{
							array4[num6] = num7;
							array3[num6] = num7 - num8;
						}
					}
				}
				for (int num9 = 0; num9 < vi.channels; num9++)
				{
					float[] fout = vb.pcm[num9];
					int num10 = map.chmuxlist[num9];
					lookMapping.floor_func[num10].inverse2(vb, lookMapping.floor_look[num10], this.floormemo[num9], fout);
				}
				for (int num11 = 0; num11 < vi.channels; num11++)
				{
					float[] array5 = vb.pcm[num11];
					((Mdct)vd.transform[vb.W][0]).backward(array5, array5);
				}
				for (int num12 = 0; num12 < vi.channels; num12++)
				{
					float[] array6 = vb.pcm[num12];
					if (this.nonzero[num12] != 0)
					{
						for (int num13 = 0; num13 < num2; num13++)
						{
							array6[num13] *= array[num13];
						}
					}
					else
					{
						for (int num14 = 0; num14 < num2; num14++)
						{
							array6[num14] = 0f;
						}
					}
				}
				num = 0;
			}
			return num;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00013B78 File Offset: 0x00011D78
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

		// Token: 0x0400024D RID: 589
		private float[][] pcmbundle;

		// Token: 0x0400024E RID: 590
		private int[] zerobundle;

		// Token: 0x0400024F RID: 591
		private int[] nonzero;

		// Token: 0x04000250 RID: 592
		private object[] floormemo;
	}
}
