using System;
using System.Collections;
using System.Collections.Generic;

namespace Accord
{
	// Token: 0x02000007 RID: 7
	[Serializable]
	public struct ByteRange : IRange<byte>, IFormattable, IEquatable<ByteRange>, IEnumerable<byte>, IEnumerable
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000026 RID: 38 RVA: 0x0000232F File Offset: 0x0000132F
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002337 File Offset: 0x00001337
		public byte Min
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

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002340 File Offset: 0x00001340
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002348 File Offset: 0x00001348
		public byte Max
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

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002351 File Offset: 0x00001351
		public int Length
		{
			get
			{
				return (int)(this.max - this.min);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002360 File Offset: 0x00001360
		public ByteRange(byte min, byte max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002370 File Offset: 0x00001370
		public bool IsInside(byte x)
		{
			return x >= this.min && x <= this.max;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002389 File Offset: 0x00001389
		public bool IsInside(ByteRange range)
		{
			return this.IsInside(range.min) && this.IsInside(range.max);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000023A7 File Offset: 0x000013A7
		public bool IsOverlapping(ByteRange range)
		{
			return this.IsInside(range.min) || this.IsInside(range.max) || range.IsInside(this.min) || range.IsInside(this.max);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000023E3 File Offset: 0x000013E3
		public ByteRange Intersection(ByteRange range)
		{
			return new ByteRange(Math.Max(this.Min, range.Min), Math.Min(this.Max, range.Max));
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000240E File Offset: 0x0000140E
		public static bool operator ==(ByteRange range1, ByteRange range2)
		{
			return range1.min == range2.min && range1.max == range2.max;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000242E File Offset: 0x0000142E
		public static bool operator !=(ByteRange range1, ByteRange range2)
		{
			return range1.min != range2.min || range1.max != range2.max;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002451 File Offset: 0x00001451
		public bool Equals(ByteRange other)
		{
			return this == other;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000245F File Offset: 0x0000145F
		public override bool Equals(object obj)
		{
			return obj is ByteRange && this == (ByteRange)obj;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000247C File Offset: 0x0000147C
		public override int GetHashCode()
		{
			int num = 17;
			num = num * 31 + this.min.GetHashCode();
			return num * 31 + this.max.GetHashCode();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000024AF File Offset: 0x000014AF
		public override string ToString()
		{
			return string.Format("[{0}, {1}]", this.min, this.max);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000024D1 File Offset: 0x000014D1
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("[{0}, {1}]", this.min.ToString(format, formatProvider), this.max.ToString(format, formatProvider));
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000024F7 File Offset: 0x000014F7
		public static implicit operator IntRange(ByteRange range)
		{
			return new IntRange((int)range.Min, (int)range.Max);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000250C File Offset: 0x0000150C
		public static implicit operator DoubleRange(ByteRange range)
		{
			return new DoubleRange((double)range.Min, (double)range.Max);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002523 File Offset: 0x00001523
		public static implicit operator Range(ByteRange range)
		{
			return new Range((float)range.Min, (float)range.Max);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000253A File Offset: 0x0000153A
		public IEnumerator<byte> GetEnumerator()
		{
			byte b;
			for (byte i = this.min; i < this.max; i = b + 1)
			{
				yield return i;
				b = i;
			}
			yield break;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000254E File Offset: 0x0000154E
		IEnumerator IEnumerable.GetEnumerator()
		{
			byte b;
			for (byte i = this.min; i < this.max; i = b + 1)
			{
				yield return i;
				b = i;
			}
			yield break;
		}

		// Token: 0x04000005 RID: 5
		private byte min;

		// Token: 0x04000006 RID: 6
		private byte max;
	}
}
