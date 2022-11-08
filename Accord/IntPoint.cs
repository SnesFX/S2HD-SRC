using System;
using System.Globalization;

namespace Accord
{
	// Token: 0x0200000F RID: 15
	[Serializable]
	public struct IntPoint : IComparable<IntPoint>
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00002831 File Offset: 0x00001831
		public IntPoint(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002844 File Offset: 0x00001844
		public float DistanceTo(IntPoint anotherPoint)
		{
			int num = this.X - anotherPoint.X;
			int num2 = this.Y - anotherPoint.Y;
			return (float)Math.Sqrt((double)(num * num + num2 * num2));
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000287C File Offset: 0x0000187C
		public float SquaredDistanceTo(Point anotherPoint)
		{
			float num = (float)this.X - anotherPoint.X;
			float num2 = (float)this.Y - anotherPoint.Y;
			return num * num + num2 * num2;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000028AE File Offset: 0x000018AE
		public static IntPoint operator +(IntPoint point1, IntPoint point2)
		{
			return new IntPoint(point1.X + point2.X, point1.Y + point2.Y);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000028AE File Offset: 0x000018AE
		public static IntPoint Add(IntPoint point1, IntPoint point2)
		{
			return new IntPoint(point1.X + point2.X, point1.Y + point2.Y);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000028CF File Offset: 0x000018CF
		public static IntPoint operator -(IntPoint point1, IntPoint point2)
		{
			return new IntPoint(point1.X - point2.X, point1.Y - point2.Y);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000028CF File Offset: 0x000018CF
		public static IntPoint Subtract(IntPoint point1, IntPoint point2)
		{
			return new IntPoint(point1.X - point2.X, point1.Y - point2.Y);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000028F0 File Offset: 0x000018F0
		public static IntPoint operator +(IntPoint point, int valueToAdd)
		{
			return new IntPoint(point.X + valueToAdd, point.Y + valueToAdd);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000028F0 File Offset: 0x000018F0
		public static IntPoint Add(IntPoint point, int valueToAdd)
		{
			return new IntPoint(point.X + valueToAdd, point.Y + valueToAdd);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002907 File Offset: 0x00001907
		public static IntPoint operator -(IntPoint point, int valueToSubtract)
		{
			return new IntPoint(point.X - valueToSubtract, point.Y - valueToSubtract);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002907 File Offset: 0x00001907
		public static IntPoint Subtract(IntPoint point, int valueToSubtract)
		{
			return new IntPoint(point.X - valueToSubtract, point.Y - valueToSubtract);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000291E File Offset: 0x0000191E
		public static IntPoint operator *(IntPoint point, int factor)
		{
			return new IntPoint(point.X * factor, point.Y * factor);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000291E File Offset: 0x0000191E
		public static IntPoint Multiply(IntPoint point, int factor)
		{
			return new IntPoint(point.X * factor, point.Y * factor);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002935 File Offset: 0x00001935
		public static IntPoint operator /(IntPoint point, int factor)
		{
			return new IntPoint(point.X / factor, point.Y / factor);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002935 File Offset: 0x00001935
		public static IntPoint Divide(IntPoint point, int factor)
		{
			return new IntPoint(point.X / factor, point.Y / factor);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000294C File Offset: 0x0000194C
		public static bool operator ==(IntPoint point1, IntPoint point2)
		{
			return point1.X == point2.X && point1.Y == point2.Y;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000296C File Offset: 0x0000196C
		public static bool operator !=(IntPoint point1, IntPoint point2)
		{
			return point1.X != point2.X || point1.Y != point2.Y;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000298F File Offset: 0x0000198F
		public override bool Equals(object obj)
		{
			return obj is IntPoint && this == (IntPoint)obj;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000029AC File Offset: 0x000019AC
		public override int GetHashCode()
		{
			return this.X.GetHashCode() + this.Y.GetHashCode();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000029C5 File Offset: 0x000019C5
		public static implicit operator Point(IntPoint point)
		{
			return new Point((float)point.X, (float)point.Y);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000029DA File Offset: 0x000019DA
		public static implicit operator DoublePoint(IntPoint point)
		{
			return new DoublePoint((double)point.X, (double)point.Y);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000029EF File Offset: 0x000019EF
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}, {1}", new object[]
			{
				this.X,
				this.Y
			});
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002A22 File Offset: 0x00001A22
		public float EuclideanNorm()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002A48 File Offset: 0x00001A48
		public int CompareTo(IntPoint other)
		{
			int num = this.Y.CompareTo(other.Y);
			if (num == 0)
			{
				return this.X.CompareTo(other.X);
			}
			return num;
		}

		// Token: 0x0400000C RID: 12
		public int X;

		// Token: 0x0400000D RID: 13
		public int Y;
	}
}
