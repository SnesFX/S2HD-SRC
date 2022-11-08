using System;
using System.Globalization;

namespace Accord
{
	// Token: 0x02000011 RID: 17
	[Serializable]
	public struct Point
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00002C9D File Offset: 0x00001C9D
		public Point(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002CB0 File Offset: 0x00001CB0
		public float DistanceTo(Point anotherPoint)
		{
			float num = this.X - anotherPoint.X;
			float num2 = this.Y - anotherPoint.Y;
			return (float)Math.Sqrt((double)(num * num + num2 * num2));
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00002CE8 File Offset: 0x00001CE8
		public float SquaredDistanceTo(Point anotherPoint)
		{
			float num = this.X - anotherPoint.X;
			float num2 = this.Y - anotherPoint.Y;
			return num * num + num2 * num2;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00002D18 File Offset: 0x00001D18
		public static Point operator +(Point point1, Point point2)
		{
			return new Point(point1.X + point2.X, point1.Y + point2.Y);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00002D18 File Offset: 0x00001D18
		public static Point Add(Point point1, Point point2)
		{
			return new Point(point1.X + point2.X, point1.Y + point2.Y);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00002D39 File Offset: 0x00001D39
		public static Point operator -(Point point1, Point point2)
		{
			return new Point(point1.X - point2.X, point1.Y - point2.Y);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00002D39 File Offset: 0x00001D39
		public static Point Subtract(Point point1, Point point2)
		{
			return new Point(point1.X - point2.X, point1.Y - point2.Y);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00002D5A File Offset: 0x00001D5A
		public static Point operator +(Point point, float valueToAdd)
		{
			return new Point(point.X + valueToAdd, point.Y + valueToAdd);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00002D5A File Offset: 0x00001D5A
		public static Point Add(Point point, float valueToAdd)
		{
			return new Point(point.X + valueToAdd, point.Y + valueToAdd);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00002D71 File Offset: 0x00001D71
		public static Point operator -(Point point, float valueToSubtract)
		{
			return new Point(point.X - valueToSubtract, point.Y - valueToSubtract);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00002D71 File Offset: 0x00001D71
		public static Point Subtract(Point point, float valueToSubtract)
		{
			return new Point(point.X - valueToSubtract, point.Y - valueToSubtract);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00002D88 File Offset: 0x00001D88
		public static Point operator *(Point point, float factor)
		{
			return new Point(point.X * factor, point.Y * factor);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00002D88 File Offset: 0x00001D88
		public static Point Multiply(Point point, float factor)
		{
			return new Point(point.X * factor, point.Y * factor);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00002D9F File Offset: 0x00001D9F
		public static Point operator /(Point point, float factor)
		{
			return new Point(point.X / factor, point.Y / factor);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002D9F File Offset: 0x00001D9F
		public static Point Divide(Point point, float factor)
		{
			return new Point(point.X / factor, point.Y / factor);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00002DB6 File Offset: 0x00001DB6
		public static bool operator ==(Point point1, Point point2)
		{
			return point1.X == point2.X && point1.Y == point2.Y;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002DD6 File Offset: 0x00001DD6
		public static bool operator !=(Point point1, Point point2)
		{
			return point1.X != point2.X || point1.Y != point2.Y;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00002DF9 File Offset: 0x00001DF9
		public override bool Equals(object obj)
		{
			return obj is Point && this == (Point)obj;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00002E16 File Offset: 0x00001E16
		public override int GetHashCode()
		{
			return this.X.GetHashCode() + this.Y.GetHashCode();
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00002E2F File Offset: 0x00001E2F
		public static explicit operator IntPoint(Point point)
		{
			return new IntPoint((int)point.X, (int)point.Y);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002E44 File Offset: 0x00001E44
		public static implicit operator DoublePoint(Point point)
		{
			return new DoublePoint((double)point.X, (double)point.Y);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00002E59 File Offset: 0x00001E59
		public IntPoint Round()
		{
			return new IntPoint((int)Math.Round((double)this.X), (int)Math.Round((double)this.Y));
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00002E7A File Offset: 0x00001E7A
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}, {1}", new object[]
			{
				this.X,
				this.Y
			});
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00002EAD File Offset: 0x00001EAD
		public float EuclideanNorm()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
		}

		// Token: 0x04000010 RID: 16
		public float X;

		// Token: 0x04000011 RID: 17
		public float Y;
	}
}
