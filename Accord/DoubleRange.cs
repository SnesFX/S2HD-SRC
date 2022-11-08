using System;

namespace Accord
{
	// Token: 0x02000008 RID: 8
	[Serializable]
	public struct DoubleRange : IRange<double>, IFormattable, IEquatable<DoubleRange>
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002562 File Offset: 0x00001562
		// (set) Token: 0x0600003D RID: 61 RVA: 0x0000256A File Offset: 0x0000156A
		public double Min
		{
			get
			{
				return this.min;
			}
			set
			{
				this.min = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002573 File Offset: 0x00001573
		// (set) Token: 0x0600003F RID: 63 RVA: 0x0000257B File Offset: 0x0000157B
		public double Max
		{
			get
			{
				return this.max;
			}
			set
			{
				this.max = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002584 File Offset: 0x00001584
		public double Length
		{
			get
			{
				return this.max - this.min;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002593 File Offset: 0x00001593
		public DoubleRange(double min, double max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000025A3 File Offset: 0x000015A3
		public bool IsInside(double x)
		{
			return x >= this.min && x <= this.max;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000025BC File Offset: 0x000015BC
		public bool IsInside(DoubleRange range)
		{
			return this.IsInside(range.min) && this.IsInside(range.max);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000025DA File Offset: 0x000015DA
		public bool IsOverlapping(DoubleRange range)
		{
			return this.IsInside(range.min) || this.IsInside(range.max) || range.IsInside(this.min) || range.IsInside(this.max);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002616 File Offset: 0x00001616
		public DoubleRange Intersection(DoubleRange range)
		{
			return new DoubleRange(Math.Max(this.Min, range.Min), Math.Min(this.Max, range.Max));
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002641 File Offset: 0x00001641
		public static bool operator ==(DoubleRange range1, DoubleRange range2)
		{
			return range1.min == range2.min && range1.max == range2.max;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002661 File Offset: 0x00001661
		public static bool operator !=(DoubleRange range1, DoubleRange range2)
		{
			return range1.min != range2.min || range1.max != range2.max;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002684 File Offset: 0x00001684
		public bool Equals(DoubleRange other)
		{
			return this == other;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002692 File Offset: 0x00001692
		public override bool Equals(object obj)
		{
			return obj is DoubleRange && this == (DoubleRange)obj;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000026B0 File Offset: 0x000016B0
		public override int GetHashCode()
		{
			int num = 17;
			num = num * 31 + this.min.GetHashCode();
			return num * 31 + this.max.GetHashCode();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000026E3 File Offset: 0x000016E3
		public override string ToString()
		{
			return string.Format("[{0}, {1}]", this.min, this.max);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002705 File Offset: 0x00001705
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("[{0}, {1}]", this.min.ToString(format, formatProvider), this.max.ToString(format, formatProvider));
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000272C File Offset: 0x0000172C
		public IntRange ToIntRange(bool provideInnerRange)
		{
			int num;
			int num2;
			if (provideInnerRange)
			{
				num = (int)Math.Ceiling(this.min);
				num2 = (int)Math.Floor(this.max);
			}
			else
			{
				num = (int)Math.Floor(this.min);
				num2 = (int)Math.Ceiling(this.max);
			}
			return new IntRange(num, num2);
		}

		// Token: 0x04000007 RID: 7
		private double min;

		// Token: 0x04000008 RID: 8
		private double max;
	}
}
