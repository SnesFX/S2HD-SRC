using System;

namespace OpenTK.Graphics
{
	// Token: 0x020001C1 RID: 449
	public struct ColorFormat : IComparable<ColorFormat>, IEquatable<ColorFormat>
	{
		// Token: 0x06000C37 RID: 3127 RVA: 0x00027FDC File Offset: 0x000261DC
		public ColorFormat(int bpp)
		{
			if (bpp < 0)
			{
				throw new ArgumentOutOfRangeException("bpp", "Must be greater or equal to zero.");
			}
			this.red = (this.green = (this.blue = (this.alpha = 0)));
			this.bitsPerPixel = bpp;
			this.isIndexed = false;
			if (bpp <= 8)
			{
				if (bpp == 1)
				{
					this.IsIndexed = true;
					return;
				}
				if (bpp == 4)
				{
					this.Red = (this.Green = 2);
					this.Blue = 1;
					this.IsIndexed = true;
					return;
				}
				if (bpp == 8)
				{
					this.Red = (this.Green = 3);
					this.Blue = 2;
					this.IsIndexed = true;
					return;
				}
			}
			else
			{
				switch (bpp)
				{
				case 15:
					this.Red = (this.Green = (this.Blue = 5));
					return;
				case 16:
					this.Red = (this.Blue = 5);
					this.Green = 6;
					return;
				default:
					if (bpp == 24)
					{
						this.Red = (this.Green = (this.Blue = 8));
						return;
					}
					if (bpp == 32)
					{
						this.Red = (this.Green = (this.Blue = (this.Alpha = 8)));
						return;
					}
					break;
				}
			}
			this.Red = (this.Blue = (this.Alpha = (int)((byte)(bpp / 4))));
			this.Green = (int)((byte)(bpp / 4 + bpp % 4));
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00028164 File Offset: 0x00026364
		public ColorFormat(int red, int green, int blue, int alpha)
		{
			if (red < 0 || green < 0 || blue < 0 || alpha < 0)
			{
				throw new ArgumentOutOfRangeException("Arguments must be greater or equal to zero.");
			}
			this.red = (byte)red;
			this.green = (byte)green;
			this.blue = (byte)blue;
			this.alpha = (byte)alpha;
			this.bitsPerPixel = red + green + blue + alpha;
			this.isIndexed = false;
			if (this.bitsPerPixel < 15 && this.bitsPerPixel != 0)
			{
				this.isIndexed = true;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000C39 RID: 3129 RVA: 0x000281DC File Offset: 0x000263DC
		// (set) Token: 0x06000C3A RID: 3130 RVA: 0x000281E4 File Offset: 0x000263E4
		public int Red
		{
			get
			{
				return (int)this.red;
			}
			private set
			{
				this.red = (byte)value;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000C3B RID: 3131 RVA: 0x000281F0 File Offset: 0x000263F0
		// (set) Token: 0x06000C3C RID: 3132 RVA: 0x000281F8 File Offset: 0x000263F8
		public int Green
		{
			get
			{
				return (int)this.green;
			}
			private set
			{
				this.green = (byte)value;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000C3D RID: 3133 RVA: 0x00028204 File Offset: 0x00026404
		// (set) Token: 0x06000C3E RID: 3134 RVA: 0x0002820C File Offset: 0x0002640C
		public int Blue
		{
			get
			{
				return (int)this.blue;
			}
			private set
			{
				this.blue = (byte)value;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000C3F RID: 3135 RVA: 0x00028218 File Offset: 0x00026418
		// (set) Token: 0x06000C40 RID: 3136 RVA: 0x00028220 File Offset: 0x00026420
		public int Alpha
		{
			get
			{
				return (int)this.alpha;
			}
			private set
			{
				this.alpha = (byte)value;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000C41 RID: 3137 RVA: 0x0002822C File Offset: 0x0002642C
		// (set) Token: 0x06000C42 RID: 3138 RVA: 0x00028234 File Offset: 0x00026434
		public bool IsIndexed
		{
			get
			{
				return this.isIndexed;
			}
			private set
			{
				this.isIndexed = value;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x00028240 File Offset: 0x00026440
		// (set) Token: 0x06000C44 RID: 3140 RVA: 0x00028248 File Offset: 0x00026448
		public int BitsPerPixel
		{
			get
			{
				return this.bitsPerPixel;
			}
			private set
			{
				this.bitsPerPixel = value;
			}
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x00028254 File Offset: 0x00026454
		public static implicit operator ColorFormat(int bpp)
		{
			return new ColorFormat(bpp);
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x0002825C File Offset: 0x0002645C
		public int CompareTo(ColorFormat other)
		{
			int num = this.BitsPerPixel.CompareTo(other.BitsPerPixel);
			if (num != 0)
			{
				return num;
			}
			num = this.IsIndexed.CompareTo(other.IsIndexed);
			if (num != 0)
			{
				return num;
			}
			return this.Alpha.CompareTo(other.Alpha);
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x000282B8 File Offset: 0x000264B8
		public bool Equals(ColorFormat other)
		{
			return this.Red == other.Red && this.Green == other.Green && this.Blue == other.Blue && this.Alpha == other.Alpha;
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x000282F8 File Offset: 0x000264F8
		public override bool Equals(object obj)
		{
			return obj is ColorFormat && this.Equals((ColorFormat)obj);
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x00028310 File Offset: 0x00026510
		public static bool operator ==(ColorFormat left, ColorFormat right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x0002831C File Offset: 0x0002651C
		public static bool operator !=(ColorFormat left, ColorFormat right)
		{
			return !(left == right);
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x00028328 File Offset: 0x00026528
		public static bool operator >(ColorFormat left, ColorFormat right)
		{
			return left.CompareTo(right) > 0;
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00028338 File Offset: 0x00026538
		public static bool operator >=(ColorFormat left, ColorFormat right)
		{
			return left.CompareTo(right) >= 0;
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x00028348 File Offset: 0x00026548
		public static bool operator <(ColorFormat left, ColorFormat right)
		{
			return left.CompareTo(right) < 0;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00028358 File Offset: 0x00026558
		public static bool operator <=(ColorFormat left, ColorFormat right)
		{
			return left.CompareTo(right) <= 0;
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x00028368 File Offset: 0x00026568
		public override int GetHashCode()
		{
			return this.Red ^ this.Green ^ this.Blue ^ this.Alpha;
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x00028388 File Offset: 0x00026588
		public override string ToString()
		{
			return string.Format("{0} ({1})", this.BitsPerPixel, this.IsIndexed ? " indexed" : (this.Red.ToString() + this.Green.ToString() + this.Blue.ToString() + this.Alpha.ToString()));
		}

		// Token: 0x04001227 RID: 4647
		private byte red;

		// Token: 0x04001228 RID: 4648
		private byte green;

		// Token: 0x04001229 RID: 4649
		private byte blue;

		// Token: 0x0400122A RID: 4650
		private byte alpha;

		// Token: 0x0400122B RID: 4651
		private bool isIndexed;

		// Token: 0x0400122C RID: 4652
		private int bitsPerPixel;

		// Token: 0x0400122D RID: 4653
		public static readonly ColorFormat Empty = new ColorFormat(0);
	}
}
