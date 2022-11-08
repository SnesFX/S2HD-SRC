using System;

namespace Accord
{
	// Token: 0x02000013 RID: 19
	[Serializable]
	public struct Range : IRange<float>, IFormattable, IEquatable<Range>
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000318D File Offset: 0x0000218D
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00003195 File Offset: 0x00002195
		public float Min
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

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000AE RID: 174 RVA: 0x0000319E File Offset: 0x0000219E
		// (set) Token: 0x060000AF RID: 175 RVA: 0x000031A6 File Offset: 0x000021A6
		public float Max
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

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000031AF File Offset: 0x000021AF
		public float Length
		{
			get
			{
				return this.max - this.min;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000031BE File Offset: 0x000021BE
		public Range(float min, float max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000031CE File Offset: 0x000021CE
		public bool IsInside(float x)
		{
			return x >= this.min && x <= this.max;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000031E7 File Offset: 0x000021E7
		public bool IsInside(Range range)
		{
			return this.IsInside(range.min) && this.IsInside(range.max);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003205 File Offset: 0x00002205
		public bool IsOverlapping(Range range)
		{
			return this.IsInside(range.min) || this.IsInside(range.max) || range.IsInside(this.min) || range.IsInside(this.max);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003241 File Offset: 0x00002241
		public Range Intersection(Range range)
		{
			return new Range(Math.Max(this.Min, range.Min), Math.Min(this.Max, range.Max));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000326C File Offset: 0x0000226C
		public static bool operator ==(Range range1, Range range2)
		{
			return range1.min == range2.min && range1.max == range2.max;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000328C File Offset: 0x0000228C
		public static bool operator !=(Range range1, Range range2)
		{
			return range1.min != range2.min || range1.max != range2.max;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000032AF File Offset: 0x000022AF
		public bool Equals(Range other)
		{
			return this == other;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000032BD File Offset: 0x000022BD
		public override bool Equals(object obj)
		{
			return obj is Range && this == (Range)obj;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000032DC File Offset: 0x000022DC
		public override int GetHashCode()
		{
			int num = 17;
			num = num * 31 + this.min.GetHashCode();
			return num * 31 + this.max.GetHashCode();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000330F File Offset: 0x0000230F
		public override string ToString()
		{
			return string.Format("[{0}, {1}]", this.min, this.max);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003331 File Offset: 0x00002331
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("[{0}, {1}]", this.min.ToString(format, formatProvider), this.max.ToString(format, formatProvider));
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003357 File Offset: 0x00002357
		public static implicit operator DoubleRange(Range range)
		{
			return new DoubleRange((double)range.Min, (double)range.Max);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003370 File Offset: 0x00002370
		public IntRange ToIntRange(bool provideInnerRange)
		{
			int num;
			int num2;
			if (provideInnerRange)
			{
				num = (int)Math.Ceiling((double)this.min);
				num2 = (int)Math.Floor((double)this.max);
			}
			else
			{
				num = (int)Math.Floor((double)this.min);
				num2 = (int)Math.Ceiling((double)this.max);
			}
			return new IntRange(num, num2);
		}

		// Token: 0x04000012 RID: 18
		private float min;

		// Token: 0x04000013 RID: 19
		private float max;
	}
}
