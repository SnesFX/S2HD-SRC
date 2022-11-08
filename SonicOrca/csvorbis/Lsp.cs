using System;
using System.Runtime.InteropServices;

namespace csvorbis
{
	// Token: 0x0200007C RID: 124
	internal class Lsp
	{
		// Token: 0x06000409 RID: 1033 RVA: 0x000130D0 File Offset: 0x000112D0
		internal static void lsp_to_curve(float[] curve, int[] map, int n, int ln, float[] lsp, int m, float amp, float ampoffset)
		{
			float num = Lsp.M_PI / (float)ln;
			int i;
			for (i = 0; i < m; i++)
			{
				lsp[i] = Lookup.coslook(lsp[i]);
			}
			int num2 = m / 2 * 2;
			i = 0;
			while (i < n)
			{
				Lsp.FloatHack floatHack = default(Lsp.FloatHack);
				int num3 = map[i];
				float num4 = 0.70710677f;
				float num5 = 0.70710677f;
				float num6 = Lookup.coslook(num * (float)num3);
				for (int j = 0; j < num2; j += 2)
				{
					num5 *= lsp[j] - num6;
					num4 *= lsp[j + 1] - num6;
				}
				if ((m & 1) != 0)
				{
					num5 *= lsp[m - 1] - num6;
					num5 *= num5;
					num4 *= num4 * (1f - num6 * num6);
				}
				else
				{
					num5 *= num5 * (1f + num6);
					num4 *= num4 * (1f - num6);
				}
				num5 = num4 + num5;
				floatHack.fh_float = num5;
				int num7 = floatHack.fh_int;
				int num8 = int.MaxValue & num7;
				int num9 = 0;
				if (num8 < 2139095040 && num8 != 0)
				{
					if (num8 < 8388608)
					{
						num5 *= 33554432f;
						floatHack.fh_float = num5;
						num7 = floatHack.fh_int;
						num8 = (int.MaxValue & num7);
						num9 = -25;
					}
					num9 += (int)(((uint)num8 >> 23) - 126U);
					num7 = (int)(((long)num7 & (long)((ulong)-2139095041)) | 1056964608L);
					floatHack.fh_int = num7;
					num5 = floatHack.fh_float;
				}
				num5 = Lookup.fromdBlook(amp * Lookup.invsqlook(num5) * Lookup.invsq2explook(num9 + m) - ampoffset);
				do
				{
					curve[i] *= num5;
					i++;
				}
				while (i < n && map[i] == num3);
			}
		}

		// Token: 0x0400024C RID: 588
		private static float M_PI = 3.1415927f;

		// Token: 0x020001B2 RID: 434
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		private struct FloatHack
		{
			// Token: 0x04000A54 RID: 2644
			[FieldOffset(0)]
			public float fh_float;

			// Token: 0x04000A55 RID: 2645
			[FieldOffset(0)]
			public int fh_int;
		}
	}
}
