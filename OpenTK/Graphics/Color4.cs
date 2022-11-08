using System;
using System.Drawing;

namespace OpenTK.Graphics
{
	// Token: 0x020001B7 RID: 439
	[Serializable]
	public struct Color4 : IEquatable<Color4>
	{
		// Token: 0x06000B3F RID: 2879 RVA: 0x00026450 File Offset: 0x00024650
		public Color4(float r, float g, float b, float a)
		{
			this.R = r;
			this.G = g;
			this.B = b;
			this.A = a;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x00026470 File Offset: 0x00024670
		public Color4(byte r, byte g, byte b, byte a)
		{
			this.R = (float)r / 255f;
			this.G = (float)g / 255f;
			this.B = (float)b / 255f;
			this.A = (float)a / 255f;
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x000264AC File Offset: 0x000246AC
		[Obsolete("Use new Color4(r, g, b, a) instead.")]
		public Color4(Color color)
		{
			this = new Color4(color.R, color.G, color.B, color.A);
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x000264D0 File Offset: 0x000246D0
		public int ToArgb()
		{
			return (int)((uint)(this.A * 255f) << 24 | (uint)(this.R * 255f) << 16 | (uint)(this.G * 255f) << 8 | (uint)(this.B * 255f));
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x00026520 File Offset: 0x00024720
		public static bool operator ==(Color4 left, Color4 right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0002652C File Offset: 0x0002472C
		public static bool operator !=(Color4 left, Color4 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0002653C File Offset: 0x0002473C
		public static implicit operator Color4(Color color)
		{
			return new Color4(color.R, color.G, color.B, color.A);
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00026560 File Offset: 0x00024760
		public static explicit operator Color(Color4 color)
		{
			return Color.FromArgb((int)(color.A * 255f), (int)(color.R * 255f), (int)(color.G * 255f), (int)(color.B * 255f));
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x000265A0 File Offset: 0x000247A0
		public override bool Equals(object obj)
		{
			return obj is Color4 && this.Equals((Color4)obj);
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x000265B8 File Offset: 0x000247B8
		public override int GetHashCode()
		{
			return this.ToArgb();
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x000265C0 File Offset: 0x000247C0
		public override string ToString()
		{
			return string.Format("{{(R, G, B, A) = ({0}, {1}, {2}, {3})}}", new object[]
			{
				this.R.ToString(),
				this.G.ToString(),
				this.B.ToString(),
				this.A.ToString()
			});
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000B4A RID: 2890 RVA: 0x00026618 File Offset: 0x00024818
		public static Color4 Transparent
		{
			get
			{
				return new Color4(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x00026630 File Offset: 0x00024830
		public static Color4 AliceBlue
		{
			get
			{
				return new Color4(240, 248, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0002664C File Offset: 0x0002484C
		public static Color4 AntiqueWhite
		{
			get
			{
				return new Color4(250, 235, 215, byte.MaxValue);
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x00026668 File Offset: 0x00024868
		public static Color4 Aqua
		{
			get
			{
				return new Color4(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000B4E RID: 2894 RVA: 0x00026680 File Offset: 0x00024880
		public static Color4 Aquamarine
		{
			get
			{
				return new Color4(127, byte.MaxValue, 212, byte.MaxValue);
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x00026698 File Offset: 0x00024898
		public static Color4 Azure
		{
			get
			{
				return new Color4(240, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000B50 RID: 2896 RVA: 0x000266B4 File Offset: 0x000248B4
		public static Color4 Beige
		{
			get
			{
				return new Color4(245, 245, 220, byte.MaxValue);
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x000266D0 File Offset: 0x000248D0
		public static Color4 Bisque
		{
			get
			{
				return new Color4(byte.MaxValue, 228, 196, byte.MaxValue);
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000B52 RID: 2898 RVA: 0x000266EC File Offset: 0x000248EC
		public static Color4 Black
		{
			get
			{
				return new Color4(0, 0, 0, byte.MaxValue);
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x000266FC File Offset: 0x000248FC
		public static Color4 BlanchedAlmond
		{
			get
			{
				return new Color4(byte.MaxValue, 235, 205, byte.MaxValue);
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000B54 RID: 2900 RVA: 0x00026718 File Offset: 0x00024918
		public static Color4 Blue
		{
			get
			{
				return new Color4(0, 0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x0002672C File Offset: 0x0002492C
		public static Color4 BlueViolet
		{
			get
			{
				return new Color4(138, 43, 226, byte.MaxValue);
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000B56 RID: 2902 RVA: 0x00026744 File Offset: 0x00024944
		public static Color4 Brown
		{
			get
			{
				return new Color4(165, 42, 42, byte.MaxValue);
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x0002675C File Offset: 0x0002495C
		public static Color4 BurlyWood
		{
			get
			{
				return new Color4(222, 184, 135, byte.MaxValue);
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000B58 RID: 2904 RVA: 0x00026778 File Offset: 0x00024978
		public static Color4 CadetBlue
		{
			get
			{
				return new Color4(95, 158, 160, byte.MaxValue);
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x00026790 File Offset: 0x00024990
		public static Color4 Chartreuse
		{
			get
			{
				return new Color4(127, byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000B5A RID: 2906 RVA: 0x000267A4 File Offset: 0x000249A4
		public static Color4 Chocolate
		{
			get
			{
				return new Color4(210, 105, 30, byte.MaxValue);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x000267BC File Offset: 0x000249BC
		public static Color4 Coral
		{
			get
			{
				return new Color4(byte.MaxValue, 127, 80, byte.MaxValue);
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000B5C RID: 2908 RVA: 0x000267D4 File Offset: 0x000249D4
		public static Color4 CornflowerBlue
		{
			get
			{
				return new Color4(100, 149, 237, byte.MaxValue);
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x000267EC File Offset: 0x000249EC
		public static Color4 Cornsilk
		{
			get
			{
				return new Color4(byte.MaxValue, 248, 220, byte.MaxValue);
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000B5E RID: 2910 RVA: 0x00026808 File Offset: 0x00024A08
		public static Color4 Crimson
		{
			get
			{
				return new Color4(220, 20, 60, byte.MaxValue);
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000B5F RID: 2911 RVA: 0x00026820 File Offset: 0x00024A20
		public static Color4 Cyan
		{
			get
			{
				return new Color4(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x00026838 File Offset: 0x00024A38
		public static Color4 DarkBlue
		{
			get
			{
				return new Color4(0, 0, 139, byte.MaxValue);
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0002684C File Offset: 0x00024A4C
		public static Color4 DarkCyan
		{
			get
			{
				return new Color4(0, 139, 139, byte.MaxValue);
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000B62 RID: 2914 RVA: 0x00026864 File Offset: 0x00024A64
		public static Color4 DarkGoldenrod
		{
			get
			{
				return new Color4(184, 134, 11, byte.MaxValue);
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0002687C File Offset: 0x00024A7C
		public static Color4 DarkGray
		{
			get
			{
				return new Color4(169, 169, 169, byte.MaxValue);
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000B64 RID: 2916 RVA: 0x00026898 File Offset: 0x00024A98
		public static Color4 DarkGreen
		{
			get
			{
				return new Color4(0, 100, 0, byte.MaxValue);
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x000268A8 File Offset: 0x00024AA8
		public static Color4 DarkKhaki
		{
			get
			{
				return new Color4(189, 183, 107, byte.MaxValue);
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x000268C0 File Offset: 0x00024AC0
		public static Color4 DarkMagenta
		{
			get
			{
				return new Color4(139, 0, 139, byte.MaxValue);
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x000268D8 File Offset: 0x00024AD8
		public static Color4 DarkOliveGreen
		{
			get
			{
				return new Color4(85, 107, 47, byte.MaxValue);
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000B68 RID: 2920 RVA: 0x000268EC File Offset: 0x00024AEC
		public static Color4 DarkOrange
		{
			get
			{
				return new Color4(byte.MaxValue, 140, 0, byte.MaxValue);
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x00026904 File Offset: 0x00024B04
		public static Color4 DarkOrchid
		{
			get
			{
				return new Color4(153, 50, 204, byte.MaxValue);
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000B6A RID: 2922 RVA: 0x0002691C File Offset: 0x00024B1C
		public static Color4 DarkRed
		{
			get
			{
				return new Color4(139, 0, 0, byte.MaxValue);
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000B6B RID: 2923 RVA: 0x00026930 File Offset: 0x00024B30
		public static Color4 DarkSalmon
		{
			get
			{
				return new Color4(233, 150, 122, byte.MaxValue);
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x00026948 File Offset: 0x00024B48
		public static Color4 DarkSeaGreen
		{
			get
			{
				return new Color4(143, 188, 139, byte.MaxValue);
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000B6D RID: 2925 RVA: 0x00026964 File Offset: 0x00024B64
		public static Color4 DarkSlateBlue
		{
			get
			{
				return new Color4(72, 61, 139, byte.MaxValue);
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000B6E RID: 2926 RVA: 0x0002697C File Offset: 0x00024B7C
		public static Color4 DarkSlateGray
		{
			get
			{
				return new Color4(47, 79, 79, byte.MaxValue);
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000B6F RID: 2927 RVA: 0x00026990 File Offset: 0x00024B90
		public static Color4 DarkTurquoise
		{
			get
			{
				return new Color4(0, 206, 209, byte.MaxValue);
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000B70 RID: 2928 RVA: 0x000269A8 File Offset: 0x00024BA8
		public static Color4 DarkViolet
		{
			get
			{
				return new Color4(148, 0, 211, byte.MaxValue);
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000B71 RID: 2929 RVA: 0x000269C0 File Offset: 0x00024BC0
		public static Color4 DeepPink
		{
			get
			{
				return new Color4(byte.MaxValue, 20, 147, byte.MaxValue);
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x000269D8 File Offset: 0x00024BD8
		public static Color4 DeepSkyBlue
		{
			get
			{
				return new Color4(0, 191, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x000269F0 File Offset: 0x00024BF0
		public static Color4 DimGray
		{
			get
			{
				return new Color4(105, 105, 105, byte.MaxValue);
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000B74 RID: 2932 RVA: 0x00026A04 File Offset: 0x00024C04
		public static Color4 DodgerBlue
		{
			get
			{
				return new Color4(30, 144, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x00026A1C File Offset: 0x00024C1C
		public static Color4 Firebrick
		{
			get
			{
				return new Color4(178, 34, 34, byte.MaxValue);
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000B76 RID: 2934 RVA: 0x00026A34 File Offset: 0x00024C34
		public static Color4 FloralWhite
		{
			get
			{
				return new Color4(byte.MaxValue, 250, 240, byte.MaxValue);
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x00026A50 File Offset: 0x00024C50
		public static Color4 ForestGreen
		{
			get
			{
				return new Color4(34, 139, 34, byte.MaxValue);
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000B78 RID: 2936 RVA: 0x00026A68 File Offset: 0x00024C68
		public static Color4 Fuchsia
		{
			get
			{
				return new Color4(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x00026A80 File Offset: 0x00024C80
		public static Color4 Gainsboro
		{
			get
			{
				return new Color4(220, 220, 220, byte.MaxValue);
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000B7A RID: 2938 RVA: 0x00026A9C File Offset: 0x00024C9C
		public static Color4 GhostWhite
		{
			get
			{
				return new Color4(248, 248, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x00026AB8 File Offset: 0x00024CB8
		public static Color4 Gold
		{
			get
			{
				return new Color4(byte.MaxValue, 215, 0, byte.MaxValue);
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000B7C RID: 2940 RVA: 0x00026AD0 File Offset: 0x00024CD0
		public static Color4 Goldenrod
		{
			get
			{
				return new Color4(218, 165, 32, byte.MaxValue);
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x00026AE8 File Offset: 0x00024CE8
		public static Color4 Gray
		{
			get
			{
				return new Color4(128, 128, 128, byte.MaxValue);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000B7E RID: 2942 RVA: 0x00026B04 File Offset: 0x00024D04
		public static Color4 Green
		{
			get
			{
				return new Color4(0, 128, 0, byte.MaxValue);
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000B7F RID: 2943 RVA: 0x00026B18 File Offset: 0x00024D18
		public static Color4 GreenYellow
		{
			get
			{
				return new Color4(173, byte.MaxValue, 47, byte.MaxValue);
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000B80 RID: 2944 RVA: 0x00026B30 File Offset: 0x00024D30
		public static Color4 Honeydew
		{
			get
			{
				return new Color4(240, byte.MaxValue, 240, byte.MaxValue);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000B81 RID: 2945 RVA: 0x00026B4C File Offset: 0x00024D4C
		public static Color4 HotPink
		{
			get
			{
				return new Color4(byte.MaxValue, 105, 180, byte.MaxValue);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000B82 RID: 2946 RVA: 0x00026B64 File Offset: 0x00024D64
		public static Color4 IndianRed
		{
			get
			{
				return new Color4(205, 92, 92, byte.MaxValue);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000B83 RID: 2947 RVA: 0x00026B7C File Offset: 0x00024D7C
		public static Color4 Indigo
		{
			get
			{
				return new Color4(75, 0, 130, byte.MaxValue);
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000B84 RID: 2948 RVA: 0x00026B90 File Offset: 0x00024D90
		public static Color4 Ivory
		{
			get
			{
				return new Color4(byte.MaxValue, byte.MaxValue, 240, byte.MaxValue);
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000B85 RID: 2949 RVA: 0x00026BAC File Offset: 0x00024DAC
		public static Color4 Khaki
		{
			get
			{
				return new Color4(240, 230, 140, byte.MaxValue);
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x00026BC8 File Offset: 0x00024DC8
		public static Color4 Lavender
		{
			get
			{
				return new Color4(230, 230, 250, byte.MaxValue);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000B87 RID: 2951 RVA: 0x00026BE4 File Offset: 0x00024DE4
		public static Color4 LavenderBlush
		{
			get
			{
				return new Color4(byte.MaxValue, 240, 245, byte.MaxValue);
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x00026C00 File Offset: 0x00024E00
		public static Color4 LawnGreen
		{
			get
			{
				return new Color4(124, 252, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x00026C14 File Offset: 0x00024E14
		public static Color4 LemonChiffon
		{
			get
			{
				return new Color4(byte.MaxValue, 250, 205, byte.MaxValue);
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x00026C30 File Offset: 0x00024E30
		public static Color4 LightBlue
		{
			get
			{
				return new Color4(173, 216, 230, byte.MaxValue);
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x00026C4C File Offset: 0x00024E4C
		public static Color4 LightCoral
		{
			get
			{
				return new Color4(240, 128, 128, byte.MaxValue);
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x00026C68 File Offset: 0x00024E68
		public static Color4 LightCyan
		{
			get
			{
				return new Color4(224, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x00026C84 File Offset: 0x00024E84
		public static Color4 LightGoldenrodYellow
		{
			get
			{
				return new Color4(250, 250, 210, byte.MaxValue);
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x00026CA0 File Offset: 0x00024EA0
		public static Color4 LightGreen
		{
			get
			{
				return new Color4(144, 238, 144, byte.MaxValue);
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x00026CBC File Offset: 0x00024EBC
		public static Color4 LightGray
		{
			get
			{
				return new Color4(211, 211, 211, byte.MaxValue);
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x00026CD8 File Offset: 0x00024ED8
		public static Color4 LightPink
		{
			get
			{
				return new Color4(byte.MaxValue, 182, 193, byte.MaxValue);
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x00026CF4 File Offset: 0x00024EF4
		public static Color4 LightSalmon
		{
			get
			{
				return new Color4(byte.MaxValue, 160, 122, byte.MaxValue);
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x00026D0C File Offset: 0x00024F0C
		public static Color4 LightSeaGreen
		{
			get
			{
				return new Color4(32, 178, 170, byte.MaxValue);
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x00026D24 File Offset: 0x00024F24
		public static Color4 LightSkyBlue
		{
			get
			{
				return new Color4(135, 206, 250, byte.MaxValue);
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x00026D40 File Offset: 0x00024F40
		public static Color4 LightSlateGray
		{
			get
			{
				return new Color4(119, 136, 153, byte.MaxValue);
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x00026D58 File Offset: 0x00024F58
		public static Color4 LightSteelBlue
		{
			get
			{
				return new Color4(176, 196, 222, byte.MaxValue);
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000B96 RID: 2966 RVA: 0x00026D74 File Offset: 0x00024F74
		public static Color4 LightYellow
		{
			get
			{
				return new Color4(byte.MaxValue, byte.MaxValue, 224, byte.MaxValue);
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x00026D90 File Offset: 0x00024F90
		public static Color4 Lime
		{
			get
			{
				return new Color4(0, byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x00026DA4 File Offset: 0x00024FA4
		public static Color4 LimeGreen
		{
			get
			{
				return new Color4(50, 205, 50, byte.MaxValue);
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x00026DBC File Offset: 0x00024FBC
		public static Color4 Linen
		{
			get
			{
				return new Color4(250, 240, 230, byte.MaxValue);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x00026DD8 File Offset: 0x00024FD8
		public static Color4 Magenta
		{
			get
			{
				return new Color4(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x00026DF0 File Offset: 0x00024FF0
		public static Color4 Maroon
		{
			get
			{
				return new Color4(128, 0, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x00026E04 File Offset: 0x00025004
		public static Color4 MediumAquamarine
		{
			get
			{
				return new Color4(102, 205, 170, byte.MaxValue);
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x00026E1C File Offset: 0x0002501C
		public static Color4 MediumBlue
		{
			get
			{
				return new Color4(0, 0, 205, byte.MaxValue);
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x00026E30 File Offset: 0x00025030
		public static Color4 MediumOrchid
		{
			get
			{
				return new Color4(186, 85, 211, byte.MaxValue);
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x00026E48 File Offset: 0x00025048
		public static Color4 MediumPurple
		{
			get
			{
				return new Color4(147, 112, 219, byte.MaxValue);
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x00026E60 File Offset: 0x00025060
		public static Color4 MediumSeaGreen
		{
			get
			{
				return new Color4(60, 179, 113, byte.MaxValue);
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x00026E78 File Offset: 0x00025078
		public static Color4 MediumSlateBlue
		{
			get
			{
				return new Color4(123, 104, 238, byte.MaxValue);
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x00026E90 File Offset: 0x00025090
		public static Color4 MediumSpringGreen
		{
			get
			{
				return new Color4(0, 250, 154, byte.MaxValue);
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x00026EA8 File Offset: 0x000250A8
		public static Color4 MediumTurquoise
		{
			get
			{
				return new Color4(72, 209, 204, byte.MaxValue);
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000BA4 RID: 2980 RVA: 0x00026EC0 File Offset: 0x000250C0
		public static Color4 MediumVioletRed
		{
			get
			{
				return new Color4(199, 21, 133, byte.MaxValue);
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x00026ED8 File Offset: 0x000250D8
		public static Color4 MidnightBlue
		{
			get
			{
				return new Color4(25, 25, 112, byte.MaxValue);
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000BA6 RID: 2982 RVA: 0x00026EEC File Offset: 0x000250EC
		public static Color4 MintCream
		{
			get
			{
				return new Color4(245, byte.MaxValue, 250, byte.MaxValue);
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000BA7 RID: 2983 RVA: 0x00026F08 File Offset: 0x00025108
		public static Color4 MistyRose
		{
			get
			{
				return new Color4(byte.MaxValue, 228, 225, byte.MaxValue);
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x00026F24 File Offset: 0x00025124
		public static Color4 Moccasin
		{
			get
			{
				return new Color4(byte.MaxValue, 228, 181, byte.MaxValue);
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x00026F40 File Offset: 0x00025140
		public static Color4 NavajoWhite
		{
			get
			{
				return new Color4(byte.MaxValue, 222, 173, byte.MaxValue);
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x00026F5C File Offset: 0x0002515C
		public static Color4 Navy
		{
			get
			{
				return new Color4(0, 0, 128, byte.MaxValue);
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x00026F70 File Offset: 0x00025170
		public static Color4 OldLace
		{
			get
			{
				return new Color4(253, 245, 230, byte.MaxValue);
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x00026F8C File Offset: 0x0002518C
		public static Color4 Olive
		{
			get
			{
				return new Color4(128, 128, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x00026FA4 File Offset: 0x000251A4
		public static Color4 OliveDrab
		{
			get
			{
				return new Color4(107, 142, 35, byte.MaxValue);
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x00026FBC File Offset: 0x000251BC
		public static Color4 Orange
		{
			get
			{
				return new Color4(byte.MaxValue, 165, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x00026FD4 File Offset: 0x000251D4
		public static Color4 OrangeRed
		{
			get
			{
				return new Color4(byte.MaxValue, 69, 0, byte.MaxValue);
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x00026FE8 File Offset: 0x000251E8
		public static Color4 Orchid
		{
			get
			{
				return new Color4(218, 112, 214, byte.MaxValue);
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x00027000 File Offset: 0x00025200
		public static Color4 PaleGoldenrod
		{
			get
			{
				return new Color4(238, 232, 170, byte.MaxValue);
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000BB2 RID: 2994 RVA: 0x0002701C File Offset: 0x0002521C
		public static Color4 PaleGreen
		{
			get
			{
				return new Color4(152, 251, 152, byte.MaxValue);
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x00027038 File Offset: 0x00025238
		public static Color4 PaleTurquoise
		{
			get
			{
				return new Color4(175, 238, 238, byte.MaxValue);
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000BB4 RID: 2996 RVA: 0x00027054 File Offset: 0x00025254
		public static Color4 PaleVioletRed
		{
			get
			{
				return new Color4(219, 112, 147, byte.MaxValue);
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x0002706C File Offset: 0x0002526C
		public static Color4 PapayaWhip
		{
			get
			{
				return new Color4(byte.MaxValue, 239, 213, byte.MaxValue);
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x00027088 File Offset: 0x00025288
		public static Color4 PeachPuff
		{
			get
			{
				return new Color4(byte.MaxValue, 218, 185, byte.MaxValue);
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000BB7 RID: 2999 RVA: 0x000270A4 File Offset: 0x000252A4
		public static Color4 Peru
		{
			get
			{
				return new Color4(205, 133, 63, byte.MaxValue);
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x000270BC File Offset: 0x000252BC
		public static Color4 Pink
		{
			get
			{
				return new Color4(byte.MaxValue, 192, 203, byte.MaxValue);
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x000270D8 File Offset: 0x000252D8
		public static Color4 Plum
		{
			get
			{
				return new Color4(221, 160, 221, byte.MaxValue);
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000BBA RID: 3002 RVA: 0x000270F4 File Offset: 0x000252F4
		public static Color4 PowderBlue
		{
			get
			{
				return new Color4(176, 224, 230, byte.MaxValue);
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000BBB RID: 3003 RVA: 0x00027110 File Offset: 0x00025310
		public static Color4 Purple
		{
			get
			{
				return new Color4(128, 0, 128, byte.MaxValue);
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000BBC RID: 3004 RVA: 0x00027128 File Offset: 0x00025328
		public static Color4 Red
		{
			get
			{
				return new Color4(byte.MaxValue, 0, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000BBD RID: 3005 RVA: 0x0002713C File Offset: 0x0002533C
		public static Color4 RosyBrown
		{
			get
			{
				return new Color4(188, 143, 143, byte.MaxValue);
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x00027158 File Offset: 0x00025358
		public static Color4 RoyalBlue
		{
			get
			{
				return new Color4(65, 105, 225, byte.MaxValue);
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000BBF RID: 3007 RVA: 0x00027170 File Offset: 0x00025370
		public static Color4 SaddleBrown
		{
			get
			{
				return new Color4(139, 69, 19, byte.MaxValue);
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x00027188 File Offset: 0x00025388
		public static Color4 Salmon
		{
			get
			{
				return new Color4(250, 128, 114, byte.MaxValue);
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x000271A0 File Offset: 0x000253A0
		public static Color4 SandyBrown
		{
			get
			{
				return new Color4(244, 164, 96, byte.MaxValue);
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x000271B8 File Offset: 0x000253B8
		public static Color4 SeaGreen
		{
			get
			{
				return new Color4(46, 139, 87, byte.MaxValue);
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x000271D0 File Offset: 0x000253D0
		public static Color4 SeaShell
		{
			get
			{
				return new Color4(byte.MaxValue, 245, 238, byte.MaxValue);
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x000271EC File Offset: 0x000253EC
		public static Color4 Sienna
		{
			get
			{
				return new Color4(160, 82, 45, byte.MaxValue);
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x00027204 File Offset: 0x00025404
		public static Color4 Silver
		{
			get
			{
				return new Color4(192, 192, 192, byte.MaxValue);
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x00027220 File Offset: 0x00025420
		public static Color4 SkyBlue
		{
			get
			{
				return new Color4(135, 206, 235, byte.MaxValue);
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x0002723C File Offset: 0x0002543C
		public static Color4 SlateBlue
		{
			get
			{
				return new Color4(106, 90, 205, byte.MaxValue);
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x00027254 File Offset: 0x00025454
		public static Color4 SlateGray
		{
			get
			{
				return new Color4(112, 128, 144, byte.MaxValue);
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000BC9 RID: 3017 RVA: 0x0002726C File Offset: 0x0002546C
		public static Color4 Snow
		{
			get
			{
				return new Color4(byte.MaxValue, 250, 250, byte.MaxValue);
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x00027288 File Offset: 0x00025488
		public static Color4 SpringGreen
		{
			get
			{
				return new Color4(0, byte.MaxValue, 127, byte.MaxValue);
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000BCB RID: 3019 RVA: 0x0002729C File Offset: 0x0002549C
		public static Color4 SteelBlue
		{
			get
			{
				return new Color4(70, 130, 180, byte.MaxValue);
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x000272B4 File Offset: 0x000254B4
		public static Color4 Tan
		{
			get
			{
				return new Color4(210, 180, 140, byte.MaxValue);
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x000272D0 File Offset: 0x000254D0
		public static Color4 Teal
		{
			get
			{
				return new Color4(0, 128, 128, byte.MaxValue);
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x000272E8 File Offset: 0x000254E8
		public static Color4 Thistle
		{
			get
			{
				return new Color4(216, 191, 216, byte.MaxValue);
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x00027304 File Offset: 0x00025504
		public static Color4 Tomato
		{
			get
			{
				return new Color4(byte.MaxValue, 99, 71, byte.MaxValue);
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0002731C File Offset: 0x0002551C
		public static Color4 Turquoise
		{
			get
			{
				return new Color4(64, 224, 208, byte.MaxValue);
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x00027334 File Offset: 0x00025534
		public static Color4 Violet
		{
			get
			{
				return new Color4(238, 130, 238, byte.MaxValue);
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x00027350 File Offset: 0x00025550
		public static Color4 Wheat
		{
			get
			{
				return new Color4(245, 222, 179, byte.MaxValue);
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0002736C File Offset: 0x0002556C
		public static Color4 White
		{
			get
			{
				return new Color4(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x00027388 File Offset: 0x00025588
		public static Color4 WhiteSmoke
		{
			get
			{
				return new Color4(245, 245, 245, byte.MaxValue);
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x000273A4 File Offset: 0x000255A4
		public static Color4 Yellow
		{
			get
			{
				return new Color4(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x000273BC File Offset: 0x000255BC
		public static Color4 YellowGreen
		{
			get
			{
				return new Color4(154, 205, 50, byte.MaxValue);
			}
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x000273D4 File Offset: 0x000255D4
		public bool Equals(Color4 other)
		{
			return this.R == other.R && this.G == other.G && this.B == other.B && this.A == other.A;
		}

		// Token: 0x04001207 RID: 4615
		public float R;

		// Token: 0x04001208 RID: 4616
		public float G;

		// Token: 0x04001209 RID: 4617
		public float B;

		// Token: 0x0400120A RID: 4618
		public float A;
	}
}
