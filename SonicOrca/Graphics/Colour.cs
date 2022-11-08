using System;
using System.Text.RegularExpressions;

namespace SonicOrca.Graphics
{
	// Token: 0x020000DC RID: 220
	public struct Colour : IEquatable<Colour>
	{
		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x0001E62D File Offset: 0x0001C82D
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x0001E635 File Offset: 0x0001C835
		public uint Argb { get; set; }

		// Token: 0x0600075D RID: 1885 RVA: 0x0001E63E File Offset: 0x0001C83E
		public Colour(double rgb)
		{
			this = new Colour(rgb, rgb, rgb);
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0001E649 File Offset: 0x0001C849
		public Colour(double r, double g, double b)
		{
			this = new Colour(1.0, r, g, b);
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0001E65D File Offset: 0x0001C85D
		public Colour(double a, double r, double g, double b)
		{
			this = new Colour((byte)(a * 255.0), (byte)(r * 255.0), (byte)(g * 255.0), (byte)(b * 255.0));
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0001E696 File Offset: 0x0001C896
		public Colour(byte r, byte g, byte b)
		{
			this = new Colour(byte.MaxValue, r, g, b);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0001E6A6 File Offset: 0x0001C8A6
		public Colour(byte a, byte r, byte g, byte b)
		{
			this = default(Colour);
			this.Alpha = a;
			this.Red = r;
			this.Green = g;
			this.Blue = b;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0001E6CC File Offset: 0x0001C8CC
		public Colour(uint argb)
		{
			this = default(Colour);
			this.Argb = argb;
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x0001E6DC File Offset: 0x0001C8DC
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x0001E6E8 File Offset: 0x0001C8E8
		public byte Alpha
		{
			get
			{
				return (byte)(this.Argb >> 24);
			}
			set
			{
				this.Argb = ((this.Argb & 16777215U) | (uint)((uint)value << 24));
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x0001E701 File Offset: 0x0001C901
		// (set) Token: 0x06000766 RID: 1894 RVA: 0x0001E713 File Offset: 0x0001C913
		public byte Red
		{
			get
			{
				return (byte)(this.Argb >> 16 & 255U);
			}
			set
			{
				this.Argb = ((this.Argb & 4278255615U) | (uint)((uint)value << 16));
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x0001E72C File Offset: 0x0001C92C
		// (set) Token: 0x06000768 RID: 1896 RVA: 0x0001E73D File Offset: 0x0001C93D
		public byte Green
		{
			get
			{
				return (byte)(this.Argb >> 8 & 255U);
			}
			set
			{
				this.Argb = ((this.Argb & 4294902015U) | (uint)((uint)value << 8));
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x0001E755 File Offset: 0x0001C955
		// (set) Token: 0x0600076A RID: 1898 RVA: 0x0001E764 File Offset: 0x0001C964
		public byte Blue
		{
			get
			{
				return (byte)(this.Argb & 255U);
			}
			set
			{
				this.Argb = ((this.Argb & 4294967040U) | (uint)value);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0001E77C File Offset: 0x0001C97C
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x0001E8B3 File Offset: 0x0001CAB3
		public double Hue
		{
			get
			{
				double num = (double)this.Red / 255.0;
				double num2 = (double)this.Green / 255.0;
				double num3 = (double)this.Blue / 255.0;
				double num4 = Math.Max(Math.Max(num, num2), num3);
				double num5 = Math.Min(Math.Min(num, num2), num3);
				if ((num5 + num4) / 2.0 <= 0.0)
				{
					return 0.0;
				}
				double num6 = num4 - num5;
				if (num6 <= 0.0)
				{
					return 0.0;
				}
				double num7 = (num4 - num) / num6;
				double num8 = (num4 - num2) / num6;
				double num9 = (num4 - num3) / num6;
				double num10;
				if (num == num4)
				{
					num10 = ((num2 == num5) ? (5.0 + num9) : (1.0 - num8));
				}
				else if (num2 == num4)
				{
					num10 = ((num3 == num5) ? (1.0 + num7) : (3.0 - num9));
				}
				else
				{
					num10 = ((num == num5) ? (3.0 + num8) : (5.0 - num7));
				}
				return num10 / 6.0;
			}
			set
			{
				this.SetFromHSL(value, this.Saturation, this.Luminosity);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x0001E8C8 File Offset: 0x0001CAC8
		// (set) Token: 0x0600076E RID: 1902 RVA: 0x0001E982 File Offset: 0x0001CB82
		public double Saturation
		{
			get
			{
				double val = (double)this.Red / 255.0;
				double val2 = (double)this.Green / 255.0;
				double val3 = (double)this.Blue / 255.0;
				double num = Math.Max(Math.Max(val, val2), val3);
				double num2 = Math.Min(Math.Min(val, val2), val3);
				double num3 = (num2 + num) / 2.0;
				if (num3 <= 0.0)
				{
					return 0.0;
				}
				double num4 = num - num2;
				if (num4 <= 0.0)
				{
					return num4;
				}
				return num4 / ((num3 <= 0.5) ? (num + num2) : (2.0 - num - num2));
			}
			set
			{
				this.SetFromHSL(this.Hue, value, this.Luminosity);
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x0001E998 File Offset: 0x0001CB98
		// (set) Token: 0x06000770 RID: 1904 RVA: 0x0001EA00 File Offset: 0x0001CC00
		public double Luminosity
		{
			get
			{
				double val = (double)this.Red / 255.0;
				double val2 = (double)this.Green / 255.0;
				double val3 = (double)this.Blue / 255.0;
				double num = Math.Max(Math.Max(val, val2), val3);
				return (Math.Min(Math.Min(val, val2), val3) + num) / 2.0;
			}
			set
			{
				this.SetFromHSL(this.Hue, this.Saturation, value);
			}
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0001EA18 File Offset: 0x0001CC18
		public override int GetHashCode()
		{
			return this.Argb.GetHashCode();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0001EA33 File Offset: 0x0001CC33
		public override bool Equals(object obj)
		{
			return this.Equals((Colour)obj);
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0001EA41 File Offset: 0x0001CC41
		public bool Equals(Colour other)
		{
			return this.Argb == other.Argb;
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0001EA54 File Offset: 0x0001CC54
		public override string ToString()
		{
			return string.Format("({0}, {1}, {2}, {3})", new object[]
			{
				this.Red,
				this.Green,
				this.Blue,
				this.Alpha
			});
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0001EAA9 File Offset: 0x0001CCA9
		public static bool operator ==(Colour lhs, Colour rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0001EAB3 File Offset: 0x0001CCB3
		public static bool operator !=(Colour lhs, Colour rhs)
		{
			return !lhs.Equals(rhs);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0001EAC0 File Offset: 0x0001CCC0
		public Colour GetDarker(double amount)
		{
			Colour result = this;
			result.Luminosity -= amount;
			return result;
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0001EAE4 File Offset: 0x0001CCE4
		public Colour GetLighter(double amount)
		{
			Colour result = this;
			result.Luminosity += amount;
			return result;
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0001EB08 File Offset: 0x0001CD08
		public static Colour FromHSL(double hue, double sat, double lum)
		{
			Colour result = default(Colour);
			result.SetFromHSL(hue, sat, lum);
			return result;
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0001EB28 File Offset: 0x0001CD28
		private void SetFromHSL(double hue, double sat, double lum)
		{
			hue = MathX.Clamp(0.0, hue, 1.0);
			sat = MathX.Clamp(0.0, sat, 1.0);
			lum = MathX.Clamp(0.0, lum, 1.0);
			double num = lum;
			double num2 = lum;
			double num3 = lum;
			double num4 = (lum <= 0.5) ? (lum * (1.0 + sat)) : (lum + sat - lum * sat);
			if (num4 > 0.0)
			{
				double num5 = lum + lum - num4;
				double num6 = (num4 - num5) / num4;
				hue *= 6.0;
				int num7 = (int)hue;
				double num8 = hue - (double)num7;
				double num9 = num4 * num6 * num8;
				double num10 = num5 + num9;
				double num11 = num4 - num9;
				switch (num7)
				{
				case 0:
					num = num4;
					num2 = num10;
					num3 = num5;
					break;
				case 1:
					num = num11;
					num2 = num4;
					num3 = num5;
					break;
				case 2:
					num = num5;
					num2 = num4;
					num3 = num10;
					break;
				case 3:
					num = num5;
					num2 = num11;
					num3 = num4;
					break;
				case 4:
					num = num10;
					num2 = num5;
					num3 = num4;
					break;
				case 5:
					num = num4;
					num2 = num5;
					num3 = num11;
					break;
				}
			}
			this.Red = (byte)MathX.Clamp(0.0, num * 255.0, 255.0);
			this.Green = (byte)MathX.Clamp(0.0, num2 * 255.0, 255.0);
			this.Blue = (byte)MathX.Clamp(0.0, num3 * 255.0, 255.0);
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0001ECD0 File Offset: 0x0001CED0
		public string ToHexString()
		{
			if (Colour.IsFourBitColour(this.Alpha) && Colour.IsFourBitColour(this.Red) && Colour.IsFourBitColour(this.Green) && Colour.IsFourBitColour(this.Blue))
			{
				if (this.Alpha == 255)
				{
					return string.Format("#{0:X}{1:X}{2:X}", (int)(this.Red & 15), (int)(this.Green & 15), (int)(this.Blue & 15));
				}
				return string.Format("#{0:X}{1:X}{2:X}{3:X}", new object[]
				{
					(int)(this.Alpha & 15),
					(int)(this.Red & 15),
					(int)(this.Green & 15),
					(int)(this.Blue & 15)
				});
			}
			else
			{
				if (this.Alpha == 255)
				{
					return string.Format("#{0:X2}{1:X2}{2:X2}", this.Red, this.Green, this.Blue);
				}
				return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", new object[]
				{
					this.Alpha,
					this.Red,
					this.Green,
					this.Blue
				});
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0001EE38 File Offset: 0x0001D038
		public static Colour ParseHex(string s)
		{
			Colour result;
			if (!Colour.TryParseHex(s, out result))
			{
				throw new FormatException("Invalid colour hex string.");
			}
			return result;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0001EE5C File Offset: 0x0001D05C
		public static bool TryParseHex(string s, out Colour result)
		{
			s = s.Trim();
			if (s.Length == 0)
			{
				result = Colours.Black;
				return false;
			}
			if (s[0] == '#')
			{
				s = s.Substring(1);
			}
			s = s.ToUpper();
			if (!Regex.IsMatch(s, "^([0-9A-F]{3}|[0-9A-F]{4}|[0-9A-F]{6}|[0-9A-F]{8})$"))
			{
				result = Colours.Black;
				return false;
			}
			switch (s.Length)
			{
			case 3:
				result = new Colour(Colour.Convert4to8BitColour(Convert.ToByte(s.Substring(0, 1), 16)), Colour.Convert4to8BitColour(Convert.ToByte(s.Substring(1, 1), 16)), Colour.Convert4to8BitColour(Convert.ToByte(s.Substring(2, 1), 16)));
				return true;
			case 4:
				result = new Colour(Colour.Convert4to8BitColour(Convert.ToByte(s.Substring(0, 1), 16)), Colour.Convert4to8BitColour(Convert.ToByte(s.Substring(1, 1), 16)), Colour.Convert4to8BitColour(Convert.ToByte(s.Substring(2, 1), 16)), Colour.Convert4to8BitColour(Convert.ToByte(s.Substring(3, 1), 16)));
				return true;
			case 6:
				result = new Colour(Convert.ToByte(s.Substring(0, 2), 16), Convert.ToByte(s.Substring(2, 2), 16), Convert.ToByte(s.Substring(4, 2), 16));
				return true;
			case 8:
				result = new Colour(Convert.ToByte(s.Substring(0, 2), 16), Convert.ToByte(s.Substring(2, 2), 16), Convert.ToByte(s.Substring(4, 2), 16), Convert.ToByte(s.Substring(6, 2), 16));
				return true;
			}
			result = Colours.Black;
			return false;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0001F01D File Offset: 0x0001D21D
		private static byte Convert4to8BitColour(byte colour)
		{
			return (byte)((int)colour << 4 | (int)colour);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0001F025 File Offset: 0x0001D225
		private static bool IsFourBitColour(byte colour)
		{
			return colour >> 4 == (int)(colour & 15);
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0001F030 File Offset: 0x0001D230
		public static Colour FromOpacity(double opacity)
		{
			return new Colour(opacity, 1.0, 1.0, 1.0);
		}
	}
}
