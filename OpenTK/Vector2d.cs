using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x02000530 RID: 1328
	[Serializable]
	public struct Vector2d : IEquatable<Vector2d>
	{
		// Token: 0x06004036 RID: 16438 RVA: 0x000ABF6C File Offset: 0x000AA16C
		public Vector2d(double value)
		{
			this.X = value;
			this.Y = value;
		}

		// Token: 0x06004037 RID: 16439 RVA: 0x000ABF7C File Offset: 0x000AA17C
		public Vector2d(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x1700033E RID: 830
		public double this[int index]
		{
			get
			{
				if (index == 0)
				{
					return this.X;
				}
				if (index == 1)
				{
					return this.Y;
				}
				throw new IndexOutOfRangeException("You tried to access this vector at index: " + index);
			}
			set
			{
				if (index == 0)
				{
					this.X = value;
					return;
				}
				if (index == 1)
				{
					this.Y = value;
					return;
				}
				throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
			}
		}

		// Token: 0x0600403A RID: 16442 RVA: 0x000ABFE8 File Offset: 0x000AA1E8
		[Obsolete("Use static Add() method instead.")]
		[CLSCompliant(false)]
		public void Add(Vector2d right)
		{
			this.X += right.X;
			this.Y += right.Y;
		}

		// Token: 0x0600403B RID: 16443 RVA: 0x000AC014 File Offset: 0x000AA214
		[Obsolete("Use static Add() method instead.")]
		[CLSCompliant(false)]
		public void Add(ref Vector2d right)
		{
			this.X += right.X;
			this.Y += right.Y;
		}

		// Token: 0x0600403C RID: 16444 RVA: 0x000AC03C File Offset: 0x000AA23C
		[Obsolete("Use static Subtract() method instead.")]
		[CLSCompliant(false)]
		public void Sub(Vector2d right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
		}

		// Token: 0x0600403D RID: 16445 RVA: 0x000AC068 File Offset: 0x000AA268
		[CLSCompliant(false)]
		[Obsolete("Use static Subtract() method instead.")]
		public void Sub(ref Vector2d right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
		}

		// Token: 0x0600403E RID: 16446 RVA: 0x000AC090 File Offset: 0x000AA290
		[Obsolete("Use static Multiply() method instead.")]
		public void Mult(double f)
		{
			this.X *= f;
			this.Y *= f;
		}

		// Token: 0x0600403F RID: 16447 RVA: 0x000AC0B0 File Offset: 0x000AA2B0
		[Obsolete("Use static Divide() method instead.")]
		public void Div(double f)
		{
			double num = 1.0 / f;
			this.X *= num;
			this.Y *= num;
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06004040 RID: 16448 RVA: 0x000AC0E8 File Offset: 0x000AA2E8
		public double Length
		{
			get
			{
				return Math.Sqrt(this.X * this.X + this.Y * this.Y);
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06004041 RID: 16449 RVA: 0x000AC10C File Offset: 0x000AA30C
		public double LengthSquared
		{
			get
			{
				return this.X * this.X + this.Y * this.Y;
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06004042 RID: 16450 RVA: 0x000AC12C File Offset: 0x000AA32C
		public Vector2d PerpendicularRight
		{
			get
			{
				return new Vector2d(this.Y, -this.X);
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06004043 RID: 16451 RVA: 0x000AC140 File Offset: 0x000AA340
		public Vector2d PerpendicularLeft
		{
			get
			{
				return new Vector2d(-this.Y, this.X);
			}
		}

		// Token: 0x06004044 RID: 16452 RVA: 0x000AC154 File Offset: 0x000AA354
		public Vector2d Normalized()
		{
			Vector2d result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06004045 RID: 16453 RVA: 0x000AC170 File Offset: 0x000AA370
		public void Normalize()
		{
			double num = 1.0 / this.Length;
			this.X *= num;
			this.Y *= num;
		}

		// Token: 0x06004046 RID: 16454 RVA: 0x000AC1AC File Offset: 0x000AA3AC
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(double sx, double sy)
		{
			this.X *= sx;
			this.Y *= sy;
		}

		// Token: 0x06004047 RID: 16455 RVA: 0x000AC1CC File Offset: 0x000AA3CC
		[Obsolete("Use static Multiply() method instead.")]
		[CLSCompliant(false)]
		public void Scale(Vector2d scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
		}

		// Token: 0x06004048 RID: 16456 RVA: 0x000AC1F8 File Offset: 0x000AA3F8
		[CLSCompliant(false)]
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(ref Vector2d scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
		}

		// Token: 0x06004049 RID: 16457 RVA: 0x000AC220 File Offset: 0x000AA420
		[Obsolete("Use static Subtract() method instead.")]
		public static Vector2d Sub(Vector2d a, Vector2d b)
		{
			a.X -= b.X;
			a.Y -= b.Y;
			return a;
		}

		// Token: 0x0600404A RID: 16458 RVA: 0x000AC250 File Offset: 0x000AA450
		[Obsolete("Use static Subtract() method instead.")]
		public static void Sub(ref Vector2d a, ref Vector2d b, out Vector2d result)
		{
			result.X = a.X - b.X;
			result.Y = a.Y - b.Y;
		}

		// Token: 0x0600404B RID: 16459 RVA: 0x000AC278 File Offset: 0x000AA478
		[Obsolete("Use static Multiply() method instead.")]
		public static Vector2d Mult(Vector2d a, double d)
		{
			a.X *= d;
			a.Y *= d;
			return a;
		}

		// Token: 0x0600404C RID: 16460 RVA: 0x000AC29C File Offset: 0x000AA49C
		[Obsolete("Use static Multiply() method instead.")]
		public static void Mult(ref Vector2d a, double d, out Vector2d result)
		{
			result.X = a.X * d;
			result.Y = a.Y * d;
		}

		// Token: 0x0600404D RID: 16461 RVA: 0x000AC2BC File Offset: 0x000AA4BC
		[Obsolete("Use static Divide() method instead.")]
		public static Vector2d Div(Vector2d a, double d)
		{
			double num = 1.0 / d;
			a.X *= num;
			a.Y *= num;
			return a;
		}

		// Token: 0x0600404E RID: 16462 RVA: 0x000AC2F4 File Offset: 0x000AA4F4
		[Obsolete("Use static Divide() method instead.")]
		public static void Div(ref Vector2d a, double d, out Vector2d result)
		{
			double num = 1.0 / d;
			result.X = a.X * num;
			result.Y = a.Y * num;
		}

		// Token: 0x0600404F RID: 16463 RVA: 0x000AC32C File Offset: 0x000AA52C
		public static Vector2d Add(Vector2d a, Vector2d b)
		{
			Vector2d.Add(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06004050 RID: 16464 RVA: 0x000AC33C File Offset: 0x000AA53C
		public static void Add(ref Vector2d a, ref Vector2d b, out Vector2d result)
		{
			result = new Vector2d(a.X + b.X, a.Y + b.Y);
		}

		// Token: 0x06004051 RID: 16465 RVA: 0x000AC364 File Offset: 0x000AA564
		public static Vector2d Subtract(Vector2d a, Vector2d b)
		{
			Vector2d.Subtract(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06004052 RID: 16466 RVA: 0x000AC374 File Offset: 0x000AA574
		public static void Subtract(ref Vector2d a, ref Vector2d b, out Vector2d result)
		{
			result = new Vector2d(a.X - b.X, a.Y - b.Y);
		}

		// Token: 0x06004053 RID: 16467 RVA: 0x000AC39C File Offset: 0x000AA59C
		public static Vector2d Multiply(Vector2d vector, double scale)
		{
			Vector2d.Multiply(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06004054 RID: 16468 RVA: 0x000AC3AC File Offset: 0x000AA5AC
		public static void Multiply(ref Vector2d vector, double scale, out Vector2d result)
		{
			result = new Vector2d(vector.X * scale, vector.Y * scale);
		}

		// Token: 0x06004055 RID: 16469 RVA: 0x000AC3CC File Offset: 0x000AA5CC
		public static Vector2d Multiply(Vector2d vector, Vector2d scale)
		{
			Vector2d.Multiply(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06004056 RID: 16470 RVA: 0x000AC3DC File Offset: 0x000AA5DC
		public static void Multiply(ref Vector2d vector, ref Vector2d scale, out Vector2d result)
		{
			result = new Vector2d(vector.X * scale.X, vector.Y * scale.Y);
		}

		// Token: 0x06004057 RID: 16471 RVA: 0x000AC404 File Offset: 0x000AA604
		public static Vector2d Divide(Vector2d vector, double scale)
		{
			Vector2d.Divide(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06004058 RID: 16472 RVA: 0x000AC414 File Offset: 0x000AA614
		public static void Divide(ref Vector2d vector, double scale, out Vector2d result)
		{
			Vector2d.Multiply(ref vector, 1.0 / scale, out result);
		}

		// Token: 0x06004059 RID: 16473 RVA: 0x000AC428 File Offset: 0x000AA628
		public static Vector2d Divide(Vector2d vector, Vector2d scale)
		{
			Vector2d.Divide(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x0600405A RID: 16474 RVA: 0x000AC438 File Offset: 0x000AA638
		public static void Divide(ref Vector2d vector, ref Vector2d scale, out Vector2d result)
		{
			result = new Vector2d(vector.X / scale.X, vector.Y / scale.Y);
		}

		// Token: 0x0600405B RID: 16475 RVA: 0x000AC460 File Offset: 0x000AA660
		public static Vector2d Min(Vector2d a, Vector2d b)
		{
			a.X = ((a.X < b.X) ? a.X : b.X);
			a.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			return a;
		}

		// Token: 0x0600405C RID: 16476 RVA: 0x000AC4BC File Offset: 0x000AA6BC
		public static void Min(ref Vector2d a, ref Vector2d b, out Vector2d result)
		{
			result.X = ((a.X < b.X) ? a.X : b.X);
			result.Y = ((a.Y < b.Y) ? a.Y : b.Y);
		}

		// Token: 0x0600405D RID: 16477 RVA: 0x000AC510 File Offset: 0x000AA710
		public static Vector2d Max(Vector2d a, Vector2d b)
		{
			a.X = ((a.X > b.X) ? a.X : b.X);
			a.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			return a;
		}

		// Token: 0x0600405E RID: 16478 RVA: 0x000AC56C File Offset: 0x000AA76C
		public static void Max(ref Vector2d a, ref Vector2d b, out Vector2d result)
		{
			result.X = ((a.X > b.X) ? a.X : b.X);
			result.Y = ((a.Y > b.Y) ? a.Y : b.Y);
		}

		// Token: 0x0600405F RID: 16479 RVA: 0x000AC5C0 File Offset: 0x000AA7C0
		public static Vector2d Clamp(Vector2d vec, Vector2d min, Vector2d max)
		{
			vec.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			vec.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			return vec;
		}

		// Token: 0x06004060 RID: 16480 RVA: 0x000AC650 File Offset: 0x000AA850
		public static void Clamp(ref Vector2d vec, ref Vector2d min, ref Vector2d max, out Vector2d result)
		{
			result.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			result.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
		}

		// Token: 0x06004061 RID: 16481 RVA: 0x000AC6D0 File Offset: 0x000AA8D0
		public static Vector2d Normalize(Vector2d vec)
		{
			double num = 1.0 / vec.Length;
			vec.X *= num;
			vec.Y *= num;
			return vec;
		}

		// Token: 0x06004062 RID: 16482 RVA: 0x000AC710 File Offset: 0x000AA910
		public static void Normalize(ref Vector2d vec, out Vector2d result)
		{
			double num = 1.0 / vec.Length;
			result.X = vec.X * num;
			result.Y = vec.Y * num;
		}

		// Token: 0x06004063 RID: 16483 RVA: 0x000AC74C File Offset: 0x000AA94C
		public static Vector2d NormalizeFast(Vector2d vec)
		{
			double num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y);
			vec.X *= num;
			vec.Y *= num;
			return vec;
		}

		// Token: 0x06004064 RID: 16484 RVA: 0x000AC7A0 File Offset: 0x000AA9A0
		public static void NormalizeFast(ref Vector2d vec, out Vector2d result)
		{
			double num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y);
			result.X = vec.X * num;
			result.Y = vec.Y * num;
		}

		// Token: 0x06004065 RID: 16485 RVA: 0x000AC7EC File Offset: 0x000AA9EC
		public static double Dot(Vector2d left, Vector2d right)
		{
			return left.X * right.X + left.Y * right.Y;
		}

		// Token: 0x06004066 RID: 16486 RVA: 0x000AC810 File Offset: 0x000AAA10
		public static void Dot(ref Vector2d left, ref Vector2d right, out double result)
		{
			result = left.X * right.X + left.Y * right.Y;
		}

		// Token: 0x06004067 RID: 16487 RVA: 0x000AC830 File Offset: 0x000AAA30
		public static Vector2d Lerp(Vector2d a, Vector2d b, double blend)
		{
			a.X = blend * (b.X - a.X) + a.X;
			a.Y = blend * (b.Y - a.Y) + a.Y;
			return a;
		}

		// Token: 0x06004068 RID: 16488 RVA: 0x000AC880 File Offset: 0x000AAA80
		public static void Lerp(ref Vector2d a, ref Vector2d b, double blend, out Vector2d result)
		{
			result.X = blend * (b.X - a.X) + a.X;
			result.Y = blend * (b.Y - a.Y) + a.Y;
		}

		// Token: 0x06004069 RID: 16489 RVA: 0x000AC8BC File Offset: 0x000AAABC
		public static Vector2d BaryCentric(Vector2d a, Vector2d b, Vector2d c, double u, double v)
		{
			return a + u * (b - a) + v * (c - a);
		}

		// Token: 0x0600406A RID: 16490 RVA: 0x000AC8E4 File Offset: 0x000AAAE4
		public static void BaryCentric(ref Vector2d a, ref Vector2d b, ref Vector2d c, double u, double v, out Vector2d result)
		{
			result = a;
			Vector2d vector2d = b;
			Vector2d.Subtract(ref vector2d, ref a, out vector2d);
			Vector2d.Multiply(ref vector2d, u, out vector2d);
			Vector2d.Add(ref result, ref vector2d, out result);
			vector2d = c;
			Vector2d.Subtract(ref vector2d, ref a, out vector2d);
			Vector2d.Multiply(ref vector2d, v, out vector2d);
			Vector2d.Add(ref result, ref vector2d, out result);
		}

		// Token: 0x0600406B RID: 16491 RVA: 0x000AC94C File Offset: 0x000AAB4C
		public static Vector2d Transform(Vector2d vec, Quaterniond quat)
		{
			Vector2d result;
			Vector2d.Transform(ref vec, ref quat, out result);
			return result;
		}

		// Token: 0x0600406C RID: 16492 RVA: 0x000AC968 File Offset: 0x000AAB68
		public static void Transform(ref Vector2d vec, ref Quaterniond quat, out Vector2d result)
		{
			Quaterniond quaterniond = new Quaterniond(vec.X, vec.Y, 0.0, 0.0);
			Quaterniond quaterniond2;
			Quaterniond.Invert(ref quat, out quaterniond2);
			Quaterniond quaterniond3;
			Quaterniond.Multiply(ref quat, ref quaterniond, out quaterniond3);
			Quaterniond.Multiply(ref quaterniond3, ref quaterniond2, out quaterniond);
			result = new Vector2d(quaterniond.X, quaterniond.Y);
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x0600406D RID: 16493 RVA: 0x000AC9D8 File Offset: 0x000AABD8
		// (set) Token: 0x0600406E RID: 16494 RVA: 0x000AC9EC File Offset: 0x000AABEC
		[XmlIgnore]
		public Vector2d Yx
		{
			get
			{
				return new Vector2d(this.Y, this.X);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x0600406F RID: 16495 RVA: 0x000ACA08 File Offset: 0x000AAC08
		public static Vector2d operator +(Vector2d left, Vector2d right)
		{
			left.X += right.X;
			left.Y += right.Y;
			return left;
		}

		// Token: 0x06004070 RID: 16496 RVA: 0x000ACA38 File Offset: 0x000AAC38
		public static Vector2d operator -(Vector2d left, Vector2d right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
			return left;
		}

		// Token: 0x06004071 RID: 16497 RVA: 0x000ACA68 File Offset: 0x000AAC68
		public static Vector2d operator -(Vector2d vec)
		{
			vec.X = -vec.X;
			vec.Y = -vec.Y;
			return vec;
		}

		// Token: 0x06004072 RID: 16498 RVA: 0x000ACA8C File Offset: 0x000AAC8C
		public static Vector2d operator *(Vector2d vec, double f)
		{
			vec.X *= f;
			vec.Y *= f;
			return vec;
		}

		// Token: 0x06004073 RID: 16499 RVA: 0x000ACAB0 File Offset: 0x000AACB0
		public static Vector2d operator *(double f, Vector2d vec)
		{
			vec.X *= f;
			vec.Y *= f;
			return vec;
		}

		// Token: 0x06004074 RID: 16500 RVA: 0x000ACAD4 File Offset: 0x000AACD4
		public static Vector2d operator *(Vector2d vec, Vector2d scale)
		{
			vec.X *= scale.X;
			vec.Y *= scale.Y;
			return vec;
		}

		// Token: 0x06004075 RID: 16501 RVA: 0x000ACB04 File Offset: 0x000AAD04
		public static Vector2d operator /(Vector2d vec, double f)
		{
			double num = 1.0 / f;
			vec.X *= num;
			vec.Y *= num;
			return vec;
		}

		// Token: 0x06004076 RID: 16502 RVA: 0x000ACB3C File Offset: 0x000AAD3C
		public static bool operator ==(Vector2d left, Vector2d right)
		{
			return left.Equals(right);
		}

		// Token: 0x06004077 RID: 16503 RVA: 0x000ACB48 File Offset: 0x000AAD48
		public static bool operator !=(Vector2d left, Vector2d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06004078 RID: 16504 RVA: 0x000ACB58 File Offset: 0x000AAD58
		public static explicit operator Vector2d(Vector2 v2)
		{
			return new Vector2d((double)v2.X, (double)v2.Y);
		}

		// Token: 0x06004079 RID: 16505 RVA: 0x000ACB70 File Offset: 0x000AAD70
		public static explicit operator Vector2(Vector2d v2d)
		{
			return new Vector2((float)v2d.X, (float)v2d.Y);
		}

		// Token: 0x0600407A RID: 16506 RVA: 0x000ACB88 File Offset: 0x000AAD88
		public override string ToString()
		{
			return string.Format("({0}{2} {1})", this.X, this.Y, Vector2d.listSeparator);
		}

		// Token: 0x0600407B RID: 16507 RVA: 0x000ACBB0 File Offset: 0x000AADB0
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode();
		}

		// Token: 0x0600407C RID: 16508 RVA: 0x000ACBCC File Offset: 0x000AADCC
		public override bool Equals(object obj)
		{
			return obj is Vector2d && this.Equals((Vector2d)obj);
		}

		// Token: 0x0600407D RID: 16509 RVA: 0x000ACBE4 File Offset: 0x000AADE4
		public bool Equals(Vector2d other)
		{
			return this.X == other.X && this.Y == other.Y;
		}

		// Token: 0x04004E0F RID: 19983
		public double X;

		// Token: 0x04004E10 RID: 19984
		public double Y;

		// Token: 0x04004E11 RID: 19985
		public static readonly Vector2d UnitX = new Vector2d(1.0, 0.0);

		// Token: 0x04004E12 RID: 19986
		public static readonly Vector2d UnitY = new Vector2d(0.0, 1.0);

		// Token: 0x04004E13 RID: 19987
		public static readonly Vector2d Zero = new Vector2d(0.0, 0.0);

		// Token: 0x04004E14 RID: 19988
		public static readonly Vector2d One = new Vector2d(1.0, 1.0);

		// Token: 0x04004E15 RID: 19989
		public static readonly int SizeInBytes = Marshal.SizeOf(default(Vector2d));

		// Token: 0x04004E16 RID: 19990
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
