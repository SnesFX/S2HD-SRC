using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;

namespace OpenTK
{
	// Token: 0x02000535 RID: 1333
	[Serializable]
	public struct Half : ISerializable, IComparable<Half>, IFormattable, IEquatable<Half>
	{
		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06004153 RID: 16723 RVA: 0x000B00B4 File Offset: 0x000AE2B4
		public bool IsZero
		{
			get
			{
				return this.bits == 0 || this.bits == 32768;
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06004154 RID: 16724 RVA: 0x000B00D0 File Offset: 0x000AE2D0
		public bool IsNaN
		{
			get
			{
				return (this.bits & 31744) == 31744 && (this.bits & 1023) != 0;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06004155 RID: 16725 RVA: 0x000B00FC File Offset: 0x000AE2FC
		public bool IsPositiveInfinity
		{
			get
			{
				return this.bits == 31744;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06004156 RID: 16726 RVA: 0x000B010C File Offset: 0x000AE30C
		public bool IsNegativeInfinity
		{
			get
			{
				return this.bits == 64512;
			}
		}

		// Token: 0x06004157 RID: 16727 RVA: 0x000B011C File Offset: 0x000AE31C
		public unsafe Half(float f)
		{
			this = default(Half);
			this.bits = this.SingleToHalf(*(int*)(&f));
		}

		// Token: 0x06004158 RID: 16728 RVA: 0x000B0138 File Offset: 0x000AE338
		public Half(float f, bool throwOnError)
		{
			this = new Half(f);
			if (throwOnError)
			{
				if (f > Half.MaxValue)
				{
					throw new ArithmeticException("Half: Positive maximum value exceeded.");
				}
				if (f < -Half.MaxValue)
				{
					throw new ArithmeticException("Half: Negative minimum value exceeded.");
				}
				if (float.IsNaN(f))
				{
					throw new ArithmeticException("Half: Input is not a number (NaN).");
				}
				if (float.IsPositiveInfinity(f))
				{
					throw new ArithmeticException("Half: Input is positive infinity.");
				}
				if (float.IsNegativeInfinity(f))
				{
					throw new ArithmeticException("Half: Input is negative infinity.");
				}
			}
		}

		// Token: 0x06004159 RID: 16729 RVA: 0x000B01B0 File Offset: 0x000AE3B0
		public Half(double d)
		{
			this = new Half((float)d);
		}

		// Token: 0x0600415A RID: 16730 RVA: 0x000B01BC File Offset: 0x000AE3BC
		public Half(double d, bool throwOnError)
		{
			this = new Half((float)d, throwOnError);
		}

		// Token: 0x0600415B RID: 16731 RVA: 0x000B01C8 File Offset: 0x000AE3C8
		private ushort SingleToHalf(int si32)
		{
			int num = si32 >> 16 & 32768;
			int num2 = (si32 >> 23 & 255) - 112;
			int num3 = si32 & 8388607;
			if (num2 <= 0)
			{
				if (num2 < -10)
				{
					return (ushort)num;
				}
				num3 |= 8388608;
				int num4 = 14 - num2;
				int num5 = (1 << num4 - 1) - 1;
				int num6 = num3 >> num4 & 1;
				num3 = num3 + num5 + num6 >> num4;
				return (ushort)(num | num3);
			}
			else if (num2 == 143)
			{
				if (num3 == 0)
				{
					return (ushort)(num | 31744);
				}
				num3 >>= 13;
				return (ushort)(num | 31744 | num3 | ((num3 == 0) ? 1 : 0));
			}
			else
			{
				num3 = num3 + 4095 + (num3 >> 13 & 1);
				if ((num3 & 8388608) != 0)
				{
					num3 = 0;
					num2++;
				}
				if (num2 > 30)
				{
					throw new ArithmeticException("Half: Hardware floating-point overflow.");
				}
				return (ushort)(num | num2 << 10 | num3 >> 13);
			}
		}

		// Token: 0x0600415C RID: 16732 RVA: 0x000B02A0 File Offset: 0x000AE4A0
		public unsafe float ToSingle()
		{
			int num = this.HalfToFloat(this.bits);
			return *(float*)(&num);
		}

		// Token: 0x0600415D RID: 16733 RVA: 0x000B02C0 File Offset: 0x000AE4C0
		private int HalfToFloat(ushort ui16)
		{
			int num = ui16 >> 15 & 1;
			int num2 = ui16 >> 10 & 31;
			int num3 = (int)(ui16 & 1023);
			if (num2 == 0)
			{
				if (num3 == 0)
				{
					return num << 31;
				}
				while ((num3 & 1024) == 0)
				{
					num3 <<= 1;
					num2--;
				}
				num2++;
				num3 &= -1025;
			}
			else if (num2 == 31)
			{
				if (num3 == 0)
				{
					return num << 31 | 2139095040;
				}
				return num << 31 | 2139095040 | num3 << 13;
			}
			num2 += 112;
			num3 <<= 13;
			return num << 31 | num2 << 23 | num3;
		}

		// Token: 0x0600415E RID: 16734 RVA: 0x000B0348 File Offset: 0x000AE548
		public static explicit operator Half(float f)
		{
			return new Half(f);
		}

		// Token: 0x0600415F RID: 16735 RVA: 0x000B0350 File Offset: 0x000AE550
		public static explicit operator Half(double d)
		{
			return new Half(d);
		}

		// Token: 0x06004160 RID: 16736 RVA: 0x000B0358 File Offset: 0x000AE558
		public static implicit operator float(Half h)
		{
			return h.ToSingle();
		}

		// Token: 0x06004161 RID: 16737 RVA: 0x000B0364 File Offset: 0x000AE564
		public static implicit operator double(Half h)
		{
			return (double)h.ToSingle();
		}

		// Token: 0x06004162 RID: 16738 RVA: 0x000B0370 File Offset: 0x000AE570
		public Half(SerializationInfo info, StreamingContext context)
		{
			this.bits = (ushort)info.GetValue("bits", typeof(ushort));
		}

		// Token: 0x06004163 RID: 16739 RVA: 0x000B0394 File Offset: 0x000AE594
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("bits", this.bits);
		}

		// Token: 0x06004164 RID: 16740 RVA: 0x000B03A8 File Offset: 0x000AE5A8
		public void FromBinaryStream(BinaryReader bin)
		{
			this.bits = bin.ReadUInt16();
		}

		// Token: 0x06004165 RID: 16741 RVA: 0x000B03B8 File Offset: 0x000AE5B8
		public void ToBinaryStream(BinaryWriter bin)
		{
			bin.Write(this.bits);
		}

		// Token: 0x06004166 RID: 16742 RVA: 0x000B03C8 File Offset: 0x000AE5C8
		public bool Equals(Half other)
		{
			short num = (short)other.bits;
			short num2 = (short)this.bits;
			if (num < 0)
			{
				num = (short)(32768 - (int)num);
			}
			if (num2 < 0)
			{
				num2 = (short)(32768 - (int)num2);
			}
			short num3 = Math.Abs(num - num2);
			return num3 <= 1;
		}

		// Token: 0x06004167 RID: 16743 RVA: 0x000B0414 File Offset: 0x000AE614
		public int CompareTo(Half other)
		{
			return this.CompareTo(other);
		}

		// Token: 0x06004168 RID: 16744 RVA: 0x000B043C File Offset: 0x000AE63C
		public override string ToString()
		{
			return this.ToSingle().ToString();
		}

		// Token: 0x06004169 RID: 16745 RVA: 0x000B0458 File Offset: 0x000AE658
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return this.ToSingle().ToString(format, formatProvider);
		}

		// Token: 0x0600416A RID: 16746 RVA: 0x000B0478 File Offset: 0x000AE678
		public static Half Parse(string s)
		{
			return (Half)float.Parse(s);
		}

		// Token: 0x0600416B RID: 16747 RVA: 0x000B0488 File Offset: 0x000AE688
		public static Half Parse(string s, NumberStyles style, IFormatProvider provider)
		{
			return (Half)float.Parse(s, style, provider);
		}

		// Token: 0x0600416C RID: 16748 RVA: 0x000B0498 File Offset: 0x000AE698
		public static bool TryParse(string s, out Half result)
		{
			float num;
			bool result2 = float.TryParse(s, out num);
			result = (Half)num;
			return result2;
		}

		// Token: 0x0600416D RID: 16749 RVA: 0x000B04BC File Offset: 0x000AE6BC
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out Half result)
		{
			float num;
			bool result2 = float.TryParse(s, style, provider, out num);
			result = (Half)num;
			return result2;
		}

		// Token: 0x0600416E RID: 16750 RVA: 0x000B04E4 File Offset: 0x000AE6E4
		public static byte[] GetBytes(Half h)
		{
			return BitConverter.GetBytes(h.bits);
		}

		// Token: 0x0600416F RID: 16751 RVA: 0x000B04F4 File Offset: 0x000AE6F4
		public static Half FromBytes(byte[] value, int startIndex)
		{
			Half result;
			result.bits = BitConverter.ToUInt16(value, startIndex);
			return result;
		}

		// Token: 0x04004E2A RID: 20010
		private const int maxUlps = 1;

		// Token: 0x04004E2B RID: 20011
		private ushort bits;

		// Token: 0x04004E2C RID: 20012
		public static readonly int SizeInBytes = 2;

		// Token: 0x04004E2D RID: 20013
		public static readonly float MinValue = 5.9604645E-08f;

		// Token: 0x04004E2E RID: 20014
		public static readonly float MinNormalizedValue = 6.1035156E-05f;

		// Token: 0x04004E2F RID: 20015
		public static readonly float MaxValue = 65504f;

		// Token: 0x04004E30 RID: 20016
		public static readonly float Epsilon = 0.00097656f;
	}
}
