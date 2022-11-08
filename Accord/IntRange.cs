using System;
using System.Collections;
using System.Collections.Generic;

namespace Accord
{
	// Token: 0x02000010 RID: 16
	[Serializable]
	public struct IntRange : IRange<int>, IFormattable, IEquatable<IntRange>, IEnumerable<int>, IEnumerable
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00002A7D File Offset: 0x00001A7D
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00002A85 File Offset: 0x00001A85
		public int Min
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

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002A8E File Offset: 0x00001A8E
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00002A96 File Offset: 0x00001A96
		public int Max
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

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00002A9F File Offset: 0x00001A9F
		public int Length
		{
			get
			{
				return this.max - this.min;
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002AAE File Offset: 0x00001AAE
		public IntRange(int min, int max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002ABE File Offset: 0x00001ABE
		public bool IsInside(int x)
		{
			return x >= this.min && x <= this.max;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002AD7 File Offset: 0x00001AD7
		public IntRange Intersection(IntRange range)
		{
			return new IntRange(Math.Max(this.Min, range.Min), Math.Min(this.Max, range.Max));
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002B02 File Offset: 0x00001B02
		public bool IsInside(IntRange range)
		{
			return this.IsInside(range.min) && this.IsInside(range.max);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00002B20 File Offset: 0x00001B20
		public bool IsOverlapping(IntRange range)
		{
			return this.IsInside(range.min) || this.IsInside(range.max) || range.IsInside(this.min) || range.IsInside(this.max);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002B5C File Offset: 0x00001B5C
		public static bool operator ==(IntRange range1, IntRange range2)
		{
			return range1.min == range2.min && range1.max == range2.max;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002B7C File Offset: 0x00001B7C
		public static bool operator !=(IntRange range1, IntRange range2)
		{
			return range1.min != range2.min || range1.max != range2.max;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00002B9F File Offset: 0x00001B9F
		public bool Equals(IntRange other)
		{
			return this == other;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00002BAD File Offset: 0x00001BAD
		public override bool Equals(object obj)
		{
			return obj is IntRange && this == (IntRange)obj;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00002BCC File Offset: 0x00001BCC
		public override int GetHashCode()
		{
			int num = 17;
			num = num * 31 + this.min.GetHashCode();
			return num * 31 + this.max.GetHashCode();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00002BFF File Offset: 0x00001BFF
		public override string ToString()
		{
			return string.Format("[{0}, {1}]", this.min, this.max);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002C21 File Offset: 0x00001C21
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("[{0}, {1}]", this.min.ToString(format, formatProvider), this.max.ToString(format, formatProvider));
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002C47 File Offset: 0x00001C47
		public static implicit operator DoubleRange(IntRange range)
		{
			return new DoubleRange((double)range.Min, (double)range.Max);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002C5E File Offset: 0x00001C5E
		public static implicit operator Range(IntRange range)
		{
			return new Range((float)range.Min, (float)range.Max);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00002C75 File Offset: 0x00001C75
		public IEnumerator<int> GetEnumerator()
		{
			int num;
			for (int i = this.min; i < this.max; i = num + 1)
			{
				yield return i;
				num = i;
			}
			yield break;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00002C89 File Offset: 0x00001C89
		IEnumerator IEnumerable.GetEnumerator()
		{
			int num;
			for (int i = this.min; i < this.max; i = num + 1)
			{
				yield return i;
				num = i;
			}
			yield break;
		}

		// Token: 0x0400000E RID: 14
		private int min;

		// Token: 0x0400000F RID: 15
		private int max;
	}
}
