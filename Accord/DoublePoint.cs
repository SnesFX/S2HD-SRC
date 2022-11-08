using System;
using System.Globalization;

namespace Accord
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	public struct DoublePoint
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002050 File Offset: 0x00001050
		public DoublePoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002060 File Offset: 0x00001060
		public double DistanceTo(DoublePoint anotherPoint)
		{
			double num = this.X - anotherPoint.X;
			double num2 = this.Y - anotherPoint.Y;
			return Math.Sqrt(num * num + num2 * num2);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002098 File Offset: 0x00001098
		public double SquaredDistanceTo(DoublePoint anotherPoint)
		{
			double num = this.X - anotherPoint.X;
			double num2 = this.Y - anotherPoint.Y;
			return num * num + num2 * num2;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020C8 File Offset: 0x000010C8
		public static DoublePoint operator +(DoublePoint point1, DoublePoint point2)
		{
			return new DoublePoint(point1.X + point2.X, point1.Y + point2.Y);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020C8 File Offset: 0x000010C8
		public static DoublePoint Add(DoublePoint point1, DoublePoint point2)
		{
			return new DoublePoint(point1.X + point2.X, point1.Y + point2.Y);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020E9 File Offset: 0x000010E9
		public static DoublePoint operator -(DoublePoint point1, DoublePoint point2)
		{
			return new DoublePoint(point1.X - point2.X, point1.Y - point2.Y);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020E9 File Offset: 0x000010E9
		public static DoublePoint Subtract(DoublePoint point1, DoublePoint point2)
		{
			return new DoublePoint(point1.X - point2.X, point1.Y - point2.Y);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000210A File Offset: 0x0000110A
		public static DoublePoint operator +(DoublePoint point, double valueToAdd)
		{
			return new DoublePoint(point.X + valueToAdd, point.Y + valueToAdd);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000210A File Offset: 0x0000110A
		public static DoublePoint Add(DoublePoint point, double valueToAdd)
		{
			return new DoublePoint(point.X + valueToAdd, point.Y + valueToAdd);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002121 File Offset: 0x00001121
		public static DoublePoint operator -(DoublePoint point, double valueToSubtract)
		{
			return new DoublePoint(point.X - valueToSubtract, point.Y - valueToSubtract);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002121 File Offset: 0x00001121
		public static DoublePoint Subtract(DoublePoint point, double valueToSubtract)
		{
			return new DoublePoint(point.X - valueToSubtract, point.Y - valueToSubtract);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002138 File Offset: 0x00001138
		public static DoublePoint operator *(DoublePoint point, double factor)
		{
			return new DoublePoint(point.X * factor, point.Y * factor);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002138 File Offset: 0x00001138
		public static DoublePoint Multiply(DoublePoint point, double factor)
		{
			return new DoublePoint(point.X * factor, point.Y * factor);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000214F File Offset: 0x0000114F
		public static DoublePoint operator /(DoublePoint point, double factor)
		{
			return new DoublePoint(point.X / factor, point.Y / factor);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000214F File Offset: 0x0000114F
		public static DoublePoint Divide(DoublePoint point, double factor)
		{
			return new DoublePoint(point.X / factor, point.Y / factor);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002166 File Offset: 0x00001166
		public static bool operator ==(DoublePoint point1, DoublePoint point2)
		{
			return point1.X == point2.X && point1.Y == point2.Y;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002186 File Offset: 0x00001186
		public static bool operator !=(DoublePoint point1, DoublePoint point2)
		{
			return point1.X != point2.X || point1.Y != point2.Y;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000021A9 File Offset: 0x000011A9
		public override bool Equals(object obj)
		{
			return obj is DoublePoint && this == (DoublePoint)obj;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000021C6 File Offset: 0x000011C6
		public override int GetHashCode()
		{
			return this.X.GetHashCode() + this.Y.GetHashCode();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000021DF File Offset: 0x000011DF
		public static explicit operator IntPoint(DoublePoint point)
		{
			return new IntPoint((int)point.X, (int)point.Y);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000021F4 File Offset: 0x000011F4
		public static explicit operator Point(DoublePoint point)
		{
			return new Point((float)point.X, (float)point.Y);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002209 File Offset: 0x00001209
		public IntPoint Round()
		{
			return new IntPoint((int)Math.Round(this.X), (int)Math.Round(this.Y));
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002228 File Offset: 0x00001228
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}, {1}", new object[]
			{
				this.X,
				this.Y
			});
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000225B File Offset: 0x0000125B
		public double EuclideanNorm()
		{
			return Math.Sqrt(this.X * this.X + this.Y * this.Y);
		}

		// Token: 0x04000001 RID: 1
		public double X;

		// Token: 0x04000002 RID: 2
		public double Y;
	}
}
