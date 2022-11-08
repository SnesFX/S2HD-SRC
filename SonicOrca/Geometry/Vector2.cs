using System;
using System.Globalization;

namespace SonicOrca.Geometry
{
	// Token: 0x02000106 RID: 262
	public struct Vector2 : IEquatable<Vector2>
	{
		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000963 RID: 2403 RVA: 0x00024A16 File Offset: 0x00022C16
		// (set) Token: 0x06000964 RID: 2404 RVA: 0x00024A1E File Offset: 0x00022C1E
		public double X { get; set; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x00024A27 File Offset: 0x00022C27
		// (set) Token: 0x06000966 RID: 2406 RVA: 0x00024A2F File Offset: 0x00022C2F
		public double Y { get; set; }

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x00024A38 File Offset: 0x00022C38
		public Vector2 Normalised
		{
			get
			{
				return this / this.Length;
			}
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x00024A4B File Offset: 0x00022C4B
		public Vector2(double xy)
		{
			this = new Vector2(xy, xy);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00024A55 File Offset: 0x00022C55
		public Vector2(double x, double y)
		{
			this = default(Vector2);
			this.X = x;
			this.Y = y;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00024A6C File Offset: 0x00022C6C
		public override bool Equals(object obj)
		{
			return this.Equals((Vector2)obj);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x00024A7A File Offset: 0x00022C7A
		public bool Equals(Vector2 p)
		{
			return p.X == this.X && p.Y == this.Y;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00024A9C File Offset: 0x00022C9C
		public override int GetHashCode()
		{
			return (13 * 7 + this.X.GetHashCode()) * 7 + this.Y.GetHashCode();
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00024ACD File Offset: 0x00022CCD
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "X = {0}, Y = {1}", new object[]
			{
				this.X,
				this.Y
			});
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00024B00 File Offset: 0x00022D00
		public Vector2 Rotate(double radians)
		{
			double num = Math.Cos(radians);
			double num2 = Math.Sin(radians);
			return new Vector2(this.X * num - this.Y * num2, this.X * num2 + this.Y * num);
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00024B44 File Offset: 0x00022D44
		public Vector2 Rotate(double radians, Vector2 origin)
		{
			return (this + origin).Rotate(radians) - origin;
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x00024B6C File Offset: 0x00022D6C
		public Vector2 Reflect(Vector2 normal)
		{
			return this - 2.0 * this.Dot(normal) * normal;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x00024B90 File Offset: 0x00022D90
		public double Dot(Vector2 v)
		{
			return this.X * v.X + this.Y * v.Y;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x00024BAF File Offset: 0x00022DAF
		public double Cross(Vector2 v)
		{
			return this.X * v.Y - this.Y * v.X;
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000973 RID: 2419 RVA: 0x00024BCE File Offset: 0x00022DCE
		public double Length
		{
			get
			{
				return Math.Sqrt(this.X * this.X + this.Y * this.Y);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x00024BF0 File Offset: 0x00022DF0
		public double LengthSquared
		{
			get
			{
				return Math.Pow(this.X * this.X + this.Y * this.Y, 2.0);
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x00024C1B File Offset: 0x00022E1B
		public double Angle
		{
			get
			{
				return Math.Atan2(this.Y, this.X);
			}
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00024C30 File Offset: 0x00022E30
		public static Vector2 GetPointRotatedFromRelative(Vector2 relative, Vector2 point, double theta)
		{
			double x = point.X;
			double y = point.Y;
			double x2 = relative.X;
			double y2 = relative.Y;
			double x3 = Math.Cos(theta) * (x - x2) - Math.Sin(theta) * (y - y2) + x2;
			double y3 = Math.Sin(theta) * (x - x2) + Math.Cos(theta) * (y - y2) + y2;
			return new Vector2(x3, y3);
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00024C94 File Offset: 0x00022E94
		public static Vector2 FromAngle(double radians)
		{
			return new Vector2(Math.Cos(radians), Math.Sin(radians));
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x00024CA8 File Offset: 0x00022EA8
		public static double GetDistance(Vector2 pointA, Vector2 pointB)
		{
			return Math.Sqrt(Math.Pow(pointB.X - pointA.X, 2.0) + Math.Pow(pointB.Y - pointA.Y, 2.0));
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00024CF8 File Offset: 0x00022EF8
		public static bool Intersects(Vector2 line0point0, Vector2 line0point1, Vector2 line1point0, Vector2 line1point1)
		{
			Vector2 vector = new Vector2(line0point1.X - line0point0.X, line0point1.Y - line0point0.Y);
			Vector2 vector2 = new Vector2(line1point1.X - line1point0.X, line1point1.Y - line1point0.Y);
			double num = (-vector.Y * (line0point0.X - line1point0.X) + vector.X * (line0point0.Y - line1point0.Y)) / (-vector2.X * vector.Y + vector.X * vector2.Y);
			double num2 = (vector2.X * (line0point0.Y - line1point0.Y) - vector2.Y * (line0point0.X - line1point0.X)) / (-vector2.X * vector.Y + vector.X * vector2.Y);
			return num >= 0.0 && num <= 1.0 && num2 >= 0.0 && num2 <= 1.0;
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x00024E28 File Offset: 0x00023028
		public static bool GetLineIntersection(Vector2 A, Vector2 B, Vector2 C, Vector2 D, out Vector2 intersection)
		{
			double num = B.Y - A.Y;
			double num2 = A.X - B.X;
			double num3 = num * A.X + num2 * A.Y;
			double num4 = D.Y - C.Y;
			double num5 = C.X - D.X;
			double num6 = num4 * C.X + num5 * C.Y;
			double num7 = num * num5 - num4 * num2;
			if (num7 == 0.0)
			{
				intersection = new Vector2(double.MaxValue, double.MaxValue);
				return false;
			}
			double x = (num5 * num3 - num2 * num6) / num7;
			double y = (num * num6 - num4 * num3) / num7;
			intersection = new Vector2(x, y);
			return true;
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x00024F03 File Offset: 0x00023103
		public static Vector2 operator +(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X + b.X, a.Y + b.Y);
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x00024F28 File Offset: 0x00023128
		public static Vector2 operator -(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X - b.X, a.Y - b.Y);
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x00024F4D File Offset: 0x0002314D
		public static Vector2 operator -(Vector2 a)
		{
			return new Vector2(-a.X, -a.Y);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x00024F64 File Offset: 0x00023164
		public static Vector2 operator *(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X * b.X, a.Y * b.Y);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x00024F89 File Offset: 0x00023189
		public static double Multiply(Vector2 v, Vector2 w)
		{
			return v.X * w.X + v.Y * w.Y;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x00024FAA File Offset: 0x000231AA
		public static Vector2 operator /(Vector2 a, Vector2 b)
		{
			return new Vector2(a.X / b.X, a.Y / b.Y);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00024FCF File Offset: 0x000231CF
		public static Vector2 operator *(Vector2 v, double x)
		{
			return new Vector2(v.X * x, v.Y * x);
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x00024FE8 File Offset: 0x000231E8
		public static Vector2 operator *(double x, Vector2 v)
		{
			return new Vector2(v.X * x, v.Y * x);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00025001 File Offset: 0x00023201
		public static Vector2 operator /(Vector2 v, double x)
		{
			return new Vector2(v.X / x, v.Y / x);
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x0002501A File Offset: 0x0002321A
		public static Vector2 operator /(double x, Vector2 v)
		{
			return new Vector2(v.X / x, v.Y / x);
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00025033 File Offset: 0x00023233
		public static bool operator ==(Vector2 a, Vector2 b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0002503D File Offset: 0x0002323D
		public static bool operator !=(Vector2 a, Vector2 b)
		{
			return !a.Equals(b);
		}
	}
}
