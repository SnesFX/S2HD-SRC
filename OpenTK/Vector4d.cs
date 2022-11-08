using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x02000536 RID: 1334
	[Serializable]
	public struct Vector4d : IEquatable<Vector4d>
	{
		// Token: 0x06004171 RID: 16753 RVA: 0x000B0540 File Offset: 0x000AE740
		public Vector4d(double value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
			this.W = value;
		}

		// Token: 0x06004172 RID: 16754 RVA: 0x000B0560 File Offset: 0x000AE760
		public Vector4d(double x, double y, double z, double w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x06004173 RID: 16755 RVA: 0x000B0580 File Offset: 0x000AE780
		public Vector4d(Vector2d v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = 0.0;
			this.W = 0.0;
		}

		// Token: 0x06004174 RID: 16756 RVA: 0x000B05BC File Offset: 0x000AE7BC
		public Vector4d(Vector3d v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
			this.W = 0.0;
		}

		// Token: 0x06004175 RID: 16757 RVA: 0x000B05F4 File Offset: 0x000AE7F4
		public Vector4d(Vector3d v, double w)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
			this.W = w;
		}

		// Token: 0x06004176 RID: 16758 RVA: 0x000B0624 File Offset: 0x000AE824
		public Vector4d(Vector4d v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
			this.W = v.W;
		}

		// Token: 0x1700036E RID: 878
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
				if (index == 2)
				{
					return this.Z;
				}
				if (index == 3)
				{
					return this.W;
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
				if (index == 2)
				{
					this.Z = value;
					return;
				}
				if (index == 3)
				{
					this.W = value;
					return;
				}
				throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
			}
		}

		// Token: 0x06004179 RID: 16761 RVA: 0x000B0700 File Offset: 0x000AE900
		[Obsolete("Use static Add() method instead.")]
		[CLSCompliant(false)]
		public void Add(Vector4d right)
		{
			this.X += right.X;
			this.Y += right.Y;
			this.Z += right.Z;
			this.W += right.W;
		}

		// Token: 0x0600417A RID: 16762 RVA: 0x000B0760 File Offset: 0x000AE960
		[CLSCompliant(false)]
		[Obsolete("Use static Add() method instead.")]
		public void Add(ref Vector4d right)
		{
			this.X += right.X;
			this.Y += right.Y;
			this.Z += right.Z;
			this.W += right.W;
		}

		// Token: 0x0600417B RID: 16763 RVA: 0x000B07BC File Offset: 0x000AE9BC
		[CLSCompliant(false)]
		[Obsolete("Use static Subtract() method instead.")]
		public void Sub(Vector4d right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
			this.Z -= right.Z;
			this.W -= right.W;
		}

		// Token: 0x0600417C RID: 16764 RVA: 0x000B081C File Offset: 0x000AEA1C
		[CLSCompliant(false)]
		[Obsolete("Use static Subtract() method instead.")]
		public void Sub(ref Vector4d right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
			this.Z -= right.Z;
			this.W -= right.W;
		}

		// Token: 0x0600417D RID: 16765 RVA: 0x000B0878 File Offset: 0x000AEA78
		[Obsolete("Use static Multiply() method instead.")]
		public void Mult(double f)
		{
			this.X *= f;
			this.Y *= f;
			this.Z *= f;
			this.W *= f;
		}

		// Token: 0x0600417E RID: 16766 RVA: 0x000B08B4 File Offset: 0x000AEAB4
		[Obsolete("Use static Divide() method instead.")]
		public void Div(double f)
		{
			double num = 1.0 / f;
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
			this.W *= num;
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x0600417F RID: 16767 RVA: 0x000B0908 File Offset: 0x000AEB08
		public double Length
		{
			get
			{
				return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06004180 RID: 16768 RVA: 0x000B0948 File Offset: 0x000AEB48
		public double LengthFast
		{
			get
			{
				return 1.0 / MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06004181 RID: 16769 RVA: 0x000B099C File Offset: 0x000AEB9C
		public double LengthSquared
		{
			get
			{
				return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
			}
		}

		// Token: 0x06004182 RID: 16770 RVA: 0x000B09D8 File Offset: 0x000AEBD8
		public Vector4d Normalized()
		{
			Vector4d result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06004183 RID: 16771 RVA: 0x000B09F4 File Offset: 0x000AEBF4
		public void Normalize()
		{
			double num = 1.0 / this.Length;
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
			this.W *= num;
		}

		// Token: 0x06004184 RID: 16772 RVA: 0x000B0A4C File Offset: 0x000AEC4C
		public void NormalizeFast()
		{
			double num = MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
			this.W *= num;
		}

		// Token: 0x06004185 RID: 16773 RVA: 0x000B0AD0 File Offset: 0x000AECD0
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(double sx, double sy, double sz, double sw)
		{
			this.X *= sx;
			this.Y *= sy;
			this.Z *= sz;
			this.W *= sw;
		}

		// Token: 0x06004186 RID: 16774 RVA: 0x000B0B0C File Offset: 0x000AED0C
		[CLSCompliant(false)]
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(Vector4d scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
			this.Z *= scale.Z;
			this.W *= scale.W;
		}

		// Token: 0x06004187 RID: 16775 RVA: 0x000B0B6C File Offset: 0x000AED6C
		[Obsolete("Use static Multiply() method instead.")]
		[CLSCompliant(false)]
		public void Scale(ref Vector4d scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
			this.Z *= scale.Z;
			this.W *= scale.W;
		}

		// Token: 0x06004188 RID: 16776 RVA: 0x000B0BC8 File Offset: 0x000AEDC8
		[Obsolete("Use static Subtract() method instead.")]
		public static Vector4d Sub(Vector4d a, Vector4d b)
		{
			a.X -= b.X;
			a.Y -= b.Y;
			a.Z -= b.Z;
			a.W -= b.W;
			return a;
		}

		// Token: 0x06004189 RID: 16777 RVA: 0x000B0C2C File Offset: 0x000AEE2C
		[Obsolete("Use static Subtract() method instead.")]
		public static void Sub(ref Vector4d a, ref Vector4d b, out Vector4d result)
		{
			result.X = a.X - b.X;
			result.Y = a.Y - b.Y;
			result.Z = a.Z - b.Z;
			result.W = a.W - b.W;
		}

		// Token: 0x0600418A RID: 16778 RVA: 0x000B0C88 File Offset: 0x000AEE88
		[Obsolete("Use static Multiply() method instead.")]
		public static Vector4d Mult(Vector4d a, double f)
		{
			a.X *= f;
			a.Y *= f;
			a.Z *= f;
			a.W *= f;
			return a;
		}

		// Token: 0x0600418B RID: 16779 RVA: 0x000B0CC8 File Offset: 0x000AEEC8
		[Obsolete("Use static Multiply() method instead.")]
		public static void Mult(ref Vector4d a, double f, out Vector4d result)
		{
			result.X = a.X * f;
			result.Y = a.Y * f;
			result.Z = a.Z * f;
			result.W = a.W * f;
		}

		// Token: 0x0600418C RID: 16780 RVA: 0x000B0D04 File Offset: 0x000AEF04
		[Obsolete("Use static Divide() method instead.")]
		public static Vector4d Div(Vector4d a, double f)
		{
			double num = 1.0 / f;
			a.X *= num;
			a.Y *= num;
			a.Z *= num;
			a.W *= num;
			return a;
		}

		// Token: 0x0600418D RID: 16781 RVA: 0x000B0D5C File Offset: 0x000AEF5C
		[Obsolete("Use static Divide() method instead.")]
		public static void Div(ref Vector4d a, double f, out Vector4d result)
		{
			double num = 1.0 / f;
			result.X = a.X * num;
			result.Y = a.Y * num;
			result.Z = a.Z * num;
			result.W = a.W * num;
		}

		// Token: 0x0600418E RID: 16782 RVA: 0x000B0DB0 File Offset: 0x000AEFB0
		public static Vector4d Add(Vector4d a, Vector4d b)
		{
			Vector4d.Add(ref a, ref b, out a);
			return a;
		}

		// Token: 0x0600418F RID: 16783 RVA: 0x000B0DC0 File Offset: 0x000AEFC0
		public static void Add(ref Vector4d a, ref Vector4d b, out Vector4d result)
		{
			result = new Vector4d(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
		}

		// Token: 0x06004190 RID: 16784 RVA: 0x000B0E0C File Offset: 0x000AF00C
		public static Vector4d Subtract(Vector4d a, Vector4d b)
		{
			Vector4d.Subtract(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06004191 RID: 16785 RVA: 0x000B0E1C File Offset: 0x000AF01C
		public static void Subtract(ref Vector4d a, ref Vector4d b, out Vector4d result)
		{
			result = new Vector4d(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
		}

		// Token: 0x06004192 RID: 16786 RVA: 0x000B0E68 File Offset: 0x000AF068
		public static Vector4d Multiply(Vector4d vector, double scale)
		{
			Vector4d.Multiply(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06004193 RID: 16787 RVA: 0x000B0E78 File Offset: 0x000AF078
		public static void Multiply(ref Vector4d vector, double scale, out Vector4d result)
		{
			result = new Vector4d(vector.X * scale, vector.Y * scale, vector.Z * scale, vector.W * scale);
		}

		// Token: 0x06004194 RID: 16788 RVA: 0x000B0EA8 File Offset: 0x000AF0A8
		public static Vector4d Multiply(Vector4d vector, Vector4d scale)
		{
			Vector4d.Multiply(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06004195 RID: 16789 RVA: 0x000B0EB8 File Offset: 0x000AF0B8
		public static void Multiply(ref Vector4d vector, ref Vector4d scale, out Vector4d result)
		{
			result = new Vector4d(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z, vector.W * scale.W);
		}

		// Token: 0x06004196 RID: 16790 RVA: 0x000B0F04 File Offset: 0x000AF104
		public static Vector4d Divide(Vector4d vector, double scale)
		{
			Vector4d.Divide(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06004197 RID: 16791 RVA: 0x000B0F14 File Offset: 0x000AF114
		public static void Divide(ref Vector4d vector, double scale, out Vector4d result)
		{
			Vector4d.Multiply(ref vector, 1.0 / scale, out result);
		}

		// Token: 0x06004198 RID: 16792 RVA: 0x000B0F28 File Offset: 0x000AF128
		public static Vector4d Divide(Vector4d vector, Vector4d scale)
		{
			Vector4d.Divide(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06004199 RID: 16793 RVA: 0x000B0F38 File Offset: 0x000AF138
		public static void Divide(ref Vector4d vector, ref Vector4d scale, out Vector4d result)
		{
			result = new Vector4d(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z, vector.W / scale.W);
		}

		// Token: 0x0600419A RID: 16794 RVA: 0x000B0F84 File Offset: 0x000AF184
		public static Vector4d Min(Vector4d a, Vector4d b)
		{
			a.X = ((a.X < b.X) ? a.X : b.X);
			a.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			a.Z = ((a.Z < b.Z) ? a.Z : b.Z);
			a.W = ((a.W < b.W) ? a.W : b.W);
			return a;
		}

		// Token: 0x0600419B RID: 16795 RVA: 0x000B1030 File Offset: 0x000AF230
		public static void Min(ref Vector4d a, ref Vector4d b, out Vector4d result)
		{
			result.X = ((a.X < b.X) ? a.X : b.X);
			result.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			result.Z = ((a.Z < b.Z) ? a.Z : b.Z);
			result.W = ((a.W < b.W) ? a.W : b.W);
		}

		// Token: 0x0600419C RID: 16796 RVA: 0x000B10C8 File Offset: 0x000AF2C8
		public static Vector4d Max(Vector4d a, Vector4d b)
		{
			a.X = ((a.X > b.X) ? a.X : b.X);
			a.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			a.Z = ((a.Z > b.Z) ? a.Z : b.Z);
			a.W = ((a.W > b.W) ? a.W : b.W);
			return a;
		}

		// Token: 0x0600419D RID: 16797 RVA: 0x000B1174 File Offset: 0x000AF374
		public static void Max(ref Vector4d a, ref Vector4d b, out Vector4d result)
		{
			result.X = ((a.X > b.X) ? a.X : b.X);
			result.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			result.Z = ((a.Z > b.Z) ? a.Z : b.Z);
			result.W = ((a.W > b.W) ? a.W : b.W);
		}

		// Token: 0x0600419E RID: 16798 RVA: 0x000B120C File Offset: 0x000AF40C
		public static Vector4d Clamp(Vector4d vec, Vector4d min, Vector4d max)
		{
			vec.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			vec.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			vec.Z = ((vec.X < min.Z) ? min.Z : ((vec.Z > max.Z) ? max.Z : vec.Z));
			vec.W = ((vec.Y < min.W) ? min.W : ((vec.W > max.W) ? max.W : vec.W));
			return vec;
		}

		// Token: 0x0600419F RID: 16799 RVA: 0x000B131C File Offset: 0x000AF51C
		public static void Clamp(ref Vector4d vec, ref Vector4d min, ref Vector4d max, out Vector4d result)
		{
			result.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			result.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			result.Z = ((vec.X < min.Z) ? min.Z : ((vec.Z > max.Z) ? max.Z : vec.Z));
			result.W = ((vec.Y < min.W) ? min.W : ((vec.W > max.W) ? max.W : vec.W));
		}

		// Token: 0x060041A0 RID: 16800 RVA: 0x000B140C File Offset: 0x000AF60C
		public static Vector4d Normalize(Vector4d vec)
		{
			double num = 1.0 / vec.Length;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			vec.W *= num;
			return vec;
		}

		// Token: 0x060041A1 RID: 16801 RVA: 0x000B1468 File Offset: 0x000AF668
		public static void Normalize(ref Vector4d vec, out Vector4d result)
		{
			double num = 1.0 / vec.Length;
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
			result.W = vec.W * num;
		}

		// Token: 0x060041A2 RID: 16802 RVA: 0x000B14C0 File Offset: 0x000AF6C0
		public static Vector4d NormalizeFast(Vector4d vec)
		{
			double num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z + vec.W * vec.W);
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			vec.W *= num;
			return vec;
		}

		// Token: 0x060041A3 RID: 16803 RVA: 0x000B1550 File Offset: 0x000AF750
		public static void NormalizeFast(ref Vector4d vec, out Vector4d result)
		{
			double num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z + vec.W * vec.W);
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
			result.W = vec.W * num;
		}

		// Token: 0x060041A4 RID: 16804 RVA: 0x000B15D4 File Offset: 0x000AF7D4
		public static double Dot(Vector4d left, Vector4d right)
		{
			return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		}

		// Token: 0x060041A5 RID: 16805 RVA: 0x000B1620 File Offset: 0x000AF820
		public static void Dot(ref Vector4d left, ref Vector4d right, out double result)
		{
			result = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		}

		// Token: 0x060041A6 RID: 16806 RVA: 0x000B165C File Offset: 0x000AF85C
		public static Vector4d Lerp(Vector4d a, Vector4d b, double blend)
		{
			a.X = blend * (b.X - a.X) + a.X;
			a.Y = blend * (b.Y - a.Y) + a.Y;
			a.Z = blend * (b.Z - a.Z) + a.Z;
			a.W = blend * (b.W - a.W) + a.W;
			return a;
		}

		// Token: 0x060041A7 RID: 16807 RVA: 0x000B16EC File Offset: 0x000AF8EC
		public static void Lerp(ref Vector4d a, ref Vector4d b, double blend, out Vector4d result)
		{
			result.X = blend * (b.X - a.X) + a.X;
			result.Y = blend * (b.Y - a.Y) + a.Y;
			result.Z = blend * (b.Z - a.Z) + a.Z;
			result.W = blend * (b.W - a.W) + a.W;
		}

		// Token: 0x060041A8 RID: 16808 RVA: 0x000B176C File Offset: 0x000AF96C
		public static Vector4d BaryCentric(Vector4d a, Vector4d b, Vector4d c, double u, double v)
		{
			return a + u * (b - a) + v * (c - a);
		}

		// Token: 0x060041A9 RID: 16809 RVA: 0x000B1794 File Offset: 0x000AF994
		public static void BaryCentric(ref Vector4d a, ref Vector4d b, ref Vector4d c, double u, double v, out Vector4d result)
		{
			result = a;
			Vector4d vector4d = b;
			Vector4d.Subtract(ref vector4d, ref a, out vector4d);
			Vector4d.Multiply(ref vector4d, u, out vector4d);
			Vector4d.Add(ref result, ref vector4d, out result);
			vector4d = c;
			Vector4d.Subtract(ref vector4d, ref a, out vector4d);
			Vector4d.Multiply(ref vector4d, v, out vector4d);
			Vector4d.Add(ref result, ref vector4d, out result);
		}

		// Token: 0x060041AA RID: 16810 RVA: 0x000B17FC File Offset: 0x000AF9FC
		public static Vector4d Transform(Vector4d vec, Matrix4d mat)
		{
			Vector4d result;
			Vector4d.Transform(ref vec, ref mat, out result);
			return result;
		}

		// Token: 0x060041AB RID: 16811 RVA: 0x000B1818 File Offset: 0x000AFA18
		public static void Transform(ref Vector4d vec, ref Matrix4d mat, out Vector4d result)
		{
			result = new Vector4d(vec.X * mat.Row0.X + vec.Y * mat.Row1.X + vec.Z * mat.Row2.X + vec.W * mat.Row3.X, vec.X * mat.Row0.Y + vec.Y * mat.Row1.Y + vec.Z * mat.Row2.Y + vec.W * mat.Row3.Y, vec.X * mat.Row0.Z + vec.Y * mat.Row1.Z + vec.Z * mat.Row2.Z + vec.W * mat.Row3.Z, vec.X * mat.Row0.W + vec.Y * mat.Row1.W + vec.Z * mat.Row2.W + vec.W * mat.Row3.W);
		}

		// Token: 0x060041AC RID: 16812 RVA: 0x000B195C File Offset: 0x000AFB5C
		public static Vector4d Transform(Vector4d vec, Quaterniond quat)
		{
			Vector4d result;
			Vector4d.Transform(ref vec, ref quat, out result);
			return result;
		}

		// Token: 0x060041AD RID: 16813 RVA: 0x000B1978 File Offset: 0x000AFB78
		public static void Transform(ref Vector4d vec, ref Quaterniond quat, out Vector4d result)
		{
			Quaterniond quaterniond = new Quaterniond(vec.X, vec.Y, vec.Z, vec.W);
			Quaterniond quaterniond2;
			Quaterniond.Invert(ref quat, out quaterniond2);
			Quaterniond quaterniond3;
			Quaterniond.Multiply(ref quat, ref quaterniond, out quaterniond3);
			Quaterniond.Multiply(ref quaterniond3, ref quaterniond2, out quaterniond);
			result = new Vector4d(quaterniond.X, quaterniond.Y, quaterniond.Z, quaterniond.W);
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x060041AE RID: 16814 RVA: 0x000B19F0 File Offset: 0x000AFBF0
		// (set) Token: 0x060041AF RID: 16815 RVA: 0x000B1A04 File Offset: 0x000AFC04
		[XmlIgnore]
		public Vector2d Xy
		{
			get
			{
				return new Vector2d(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x060041B0 RID: 16816 RVA: 0x000B1A20 File Offset: 0x000AFC20
		// (set) Token: 0x060041B1 RID: 16817 RVA: 0x000B1A34 File Offset: 0x000AFC34
		[XmlIgnore]
		public Vector2d Xz
		{
			get
			{
				return new Vector2d(this.X, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x060041B2 RID: 16818 RVA: 0x000B1A50 File Offset: 0x000AFC50
		// (set) Token: 0x060041B3 RID: 16819 RVA: 0x000B1A64 File Offset: 0x000AFC64
		[XmlIgnore]
		public Vector2d Xw
		{
			get
			{
				return new Vector2d(this.X, this.W);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x060041B4 RID: 16820 RVA: 0x000B1A80 File Offset: 0x000AFC80
		// (set) Token: 0x060041B5 RID: 16821 RVA: 0x000B1A94 File Offset: 0x000AFC94
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

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x060041B6 RID: 16822 RVA: 0x000B1AB0 File Offset: 0x000AFCB0
		// (set) Token: 0x060041B7 RID: 16823 RVA: 0x000B1AC4 File Offset: 0x000AFCC4
		[XmlIgnore]
		public Vector2d Yz
		{
			get
			{
				return new Vector2d(this.Y, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x060041B8 RID: 16824 RVA: 0x000B1AE0 File Offset: 0x000AFCE0
		// (set) Token: 0x060041B9 RID: 16825 RVA: 0x000B1AF4 File Offset: 0x000AFCF4
		[XmlIgnore]
		public Vector2d Yw
		{
			get
			{
				return new Vector2d(this.Y, this.W);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x060041BA RID: 16826 RVA: 0x000B1B10 File Offset: 0x000AFD10
		// (set) Token: 0x060041BB RID: 16827 RVA: 0x000B1B24 File Offset: 0x000AFD24
		[XmlIgnore]
		public Vector2d Zx
		{
			get
			{
				return new Vector2d(this.Z, this.X);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x060041BC RID: 16828 RVA: 0x000B1B40 File Offset: 0x000AFD40
		// (set) Token: 0x060041BD RID: 16829 RVA: 0x000B1B54 File Offset: 0x000AFD54
		[XmlIgnore]
		public Vector2d Zy
		{
			get
			{
				return new Vector2d(this.Z, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x060041BE RID: 16830 RVA: 0x000B1B70 File Offset: 0x000AFD70
		// (set) Token: 0x060041BF RID: 16831 RVA: 0x000B1B84 File Offset: 0x000AFD84
		[XmlIgnore]
		public Vector2d Zw
		{
			get
			{
				return new Vector2d(this.Z, this.W);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x060041C0 RID: 16832 RVA: 0x000B1BA0 File Offset: 0x000AFDA0
		// (set) Token: 0x060041C1 RID: 16833 RVA: 0x000B1BB4 File Offset: 0x000AFDB4
		[XmlIgnore]
		public Vector2d Wx
		{
			get
			{
				return new Vector2d(this.W, this.X);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x060041C2 RID: 16834 RVA: 0x000B1BD0 File Offset: 0x000AFDD0
		// (set) Token: 0x060041C3 RID: 16835 RVA: 0x000B1BE4 File Offset: 0x000AFDE4
		[XmlIgnore]
		public Vector2d Wy
		{
			get
			{
				return new Vector2d(this.W, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x060041C4 RID: 16836 RVA: 0x000B1C00 File Offset: 0x000AFE00
		// (set) Token: 0x060041C5 RID: 16837 RVA: 0x000B1C14 File Offset: 0x000AFE14
		[XmlIgnore]
		public Vector2d Wz
		{
			get
			{
				return new Vector2d(this.W, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x060041C6 RID: 16838 RVA: 0x000B1C30 File Offset: 0x000AFE30
		// (set) Token: 0x060041C7 RID: 16839 RVA: 0x000B1C4C File Offset: 0x000AFE4C
		[XmlIgnore]
		public Vector3d Xyz
		{
			get
			{
				return new Vector3d(this.X, this.Y, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x060041C8 RID: 16840 RVA: 0x000B1C78 File Offset: 0x000AFE78
		// (set) Token: 0x060041C9 RID: 16841 RVA: 0x000B1C94 File Offset: 0x000AFE94
		[XmlIgnore]
		public Vector3d Xyw
		{
			get
			{
				return new Vector3d(this.X, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x060041CA RID: 16842 RVA: 0x000B1CC0 File Offset: 0x000AFEC0
		// (set) Token: 0x060041CB RID: 16843 RVA: 0x000B1CDC File Offset: 0x000AFEDC
		[XmlIgnore]
		public Vector3d Xzy
		{
			get
			{
				return new Vector3d(this.X, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x060041CC RID: 16844 RVA: 0x000B1D08 File Offset: 0x000AFF08
		// (set) Token: 0x060041CD RID: 16845 RVA: 0x000B1D24 File Offset: 0x000AFF24
		[XmlIgnore]
		public Vector3d Xzw
		{
			get
			{
				return new Vector3d(this.X, this.Z, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x060041CE RID: 16846 RVA: 0x000B1D50 File Offset: 0x000AFF50
		// (set) Token: 0x060041CF RID: 16847 RVA: 0x000B1D6C File Offset: 0x000AFF6C
		[XmlIgnore]
		public Vector3d Xwy
		{
			get
			{
				return new Vector3d(this.X, this.W, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x060041D0 RID: 16848 RVA: 0x000B1D98 File Offset: 0x000AFF98
		// (set) Token: 0x060041D1 RID: 16849 RVA: 0x000B1DB4 File Offset: 0x000AFFB4
		[XmlIgnore]
		public Vector3d Xwz
		{
			get
			{
				return new Vector3d(this.X, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x060041D2 RID: 16850 RVA: 0x000B1DE0 File Offset: 0x000AFFE0
		// (set) Token: 0x060041D3 RID: 16851 RVA: 0x000B1DFC File Offset: 0x000AFFFC
		[XmlIgnore]
		public Vector3d Yxz
		{
			get
			{
				return new Vector3d(this.Y, this.X, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x060041D4 RID: 16852 RVA: 0x000B1E28 File Offset: 0x000B0028
		// (set) Token: 0x060041D5 RID: 16853 RVA: 0x000B1E44 File Offset: 0x000B0044
		[XmlIgnore]
		public Vector3d Yxw
		{
			get
			{
				return new Vector3d(this.Y, this.X, this.W);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x060041D6 RID: 16854 RVA: 0x000B1E70 File Offset: 0x000B0070
		// (set) Token: 0x060041D7 RID: 16855 RVA: 0x000B1E8C File Offset: 0x000B008C
		[XmlIgnore]
		public Vector3d Yzx
		{
			get
			{
				return new Vector3d(this.Y, this.Z, this.X);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x060041D8 RID: 16856 RVA: 0x000B1EB8 File Offset: 0x000B00B8
		// (set) Token: 0x060041D9 RID: 16857 RVA: 0x000B1ED4 File Offset: 0x000B00D4
		[XmlIgnore]
		public Vector3d Yzw
		{
			get
			{
				return new Vector3d(this.Y, this.Z, this.W);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x060041DA RID: 16858 RVA: 0x000B1F00 File Offset: 0x000B0100
		// (set) Token: 0x060041DB RID: 16859 RVA: 0x000B1F1C File Offset: 0x000B011C
		[XmlIgnore]
		public Vector3d Ywx
		{
			get
			{
				return new Vector3d(this.Y, this.W, this.X);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x060041DC RID: 16860 RVA: 0x000B1F48 File Offset: 0x000B0148
		// (set) Token: 0x060041DD RID: 16861 RVA: 0x000B1F64 File Offset: 0x000B0164
		[XmlIgnore]
		public Vector3d Ywz
		{
			get
			{
				return new Vector3d(this.Y, this.W, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x060041DE RID: 16862 RVA: 0x000B1F90 File Offset: 0x000B0190
		// (set) Token: 0x060041DF RID: 16863 RVA: 0x000B1FAC File Offset: 0x000B01AC
		[XmlIgnore]
		public Vector3d Zxy
		{
			get
			{
				return new Vector3d(this.Z, this.X, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x060041E0 RID: 16864 RVA: 0x000B1FD8 File Offset: 0x000B01D8
		// (set) Token: 0x060041E1 RID: 16865 RVA: 0x000B1FF4 File Offset: 0x000B01F4
		[XmlIgnore]
		public Vector3d Zxw
		{
			get
			{
				return new Vector3d(this.Z, this.X, this.W);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x060041E2 RID: 16866 RVA: 0x000B2020 File Offset: 0x000B0220
		// (set) Token: 0x060041E3 RID: 16867 RVA: 0x000B203C File Offset: 0x000B023C
		[XmlIgnore]
		public Vector3d Zyx
		{
			get
			{
				return new Vector3d(this.Z, this.Y, this.X);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x060041E4 RID: 16868 RVA: 0x000B2068 File Offset: 0x000B0268
		// (set) Token: 0x060041E5 RID: 16869 RVA: 0x000B2084 File Offset: 0x000B0284
		[XmlIgnore]
		public Vector3d Zyw
		{
			get
			{
				return new Vector3d(this.Z, this.Y, this.W);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x060041E6 RID: 16870 RVA: 0x000B20B0 File Offset: 0x000B02B0
		// (set) Token: 0x060041E7 RID: 16871 RVA: 0x000B20CC File Offset: 0x000B02CC
		[XmlIgnore]
		public Vector3d Zwx
		{
			get
			{
				return new Vector3d(this.Z, this.W, this.X);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x060041E8 RID: 16872 RVA: 0x000B20F8 File Offset: 0x000B02F8
		// (set) Token: 0x060041E9 RID: 16873 RVA: 0x000B2114 File Offset: 0x000B0314
		[XmlIgnore]
		public Vector3d Zwy
		{
			get
			{
				return new Vector3d(this.Z, this.W, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x060041EA RID: 16874 RVA: 0x000B2140 File Offset: 0x000B0340
		// (set) Token: 0x060041EB RID: 16875 RVA: 0x000B215C File Offset: 0x000B035C
		[XmlIgnore]
		public Vector3d Wxy
		{
			get
			{
				return new Vector3d(this.W, this.X, this.Y);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x060041EC RID: 16876 RVA: 0x000B2188 File Offset: 0x000B0388
		// (set) Token: 0x060041ED RID: 16877 RVA: 0x000B21A4 File Offset: 0x000B03A4
		[XmlIgnore]
		public Vector3d Wxz
		{
			get
			{
				return new Vector3d(this.W, this.X, this.Z);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x060041EE RID: 16878 RVA: 0x000B21D0 File Offset: 0x000B03D0
		// (set) Token: 0x060041EF RID: 16879 RVA: 0x000B21EC File Offset: 0x000B03EC
		[XmlIgnore]
		public Vector3d Wyx
		{
			get
			{
				return new Vector3d(this.W, this.Y, this.X);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x060041F0 RID: 16880 RVA: 0x000B2218 File Offset: 0x000B0418
		// (set) Token: 0x060041F1 RID: 16881 RVA: 0x000B2234 File Offset: 0x000B0434
		[XmlIgnore]
		public Vector3d Wyz
		{
			get
			{
				return new Vector3d(this.W, this.Y, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060041F2 RID: 16882 RVA: 0x000B2260 File Offset: 0x000B0460
		// (set) Token: 0x060041F3 RID: 16883 RVA: 0x000B227C File Offset: 0x000B047C
		[XmlIgnore]
		public Vector3d Wzx
		{
			get
			{
				return new Vector3d(this.W, this.Z, this.X);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060041F4 RID: 16884 RVA: 0x000B22A8 File Offset: 0x000B04A8
		// (set) Token: 0x060041F5 RID: 16885 RVA: 0x000B22C4 File Offset: 0x000B04C4
		[XmlIgnore]
		public Vector3d Wzy
		{
			get
			{
				return new Vector3d(this.W, this.Z, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x060041F6 RID: 16886 RVA: 0x000B22F0 File Offset: 0x000B04F0
		// (set) Token: 0x060041F7 RID: 16887 RVA: 0x000B2310 File Offset: 0x000B0510
		[XmlIgnore]
		public Vector4d Xywz
		{
			get
			{
				return new Vector4d(this.X, this.Y, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x060041F8 RID: 16888 RVA: 0x000B2348 File Offset: 0x000B0548
		// (set) Token: 0x060041F9 RID: 16889 RVA: 0x000B2368 File Offset: 0x000B0568
		[XmlIgnore]
		public Vector4d Xzyw
		{
			get
			{
				return new Vector4d(this.X, this.Z, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x060041FA RID: 16890 RVA: 0x000B23A0 File Offset: 0x000B05A0
		// (set) Token: 0x060041FB RID: 16891 RVA: 0x000B23C0 File Offset: 0x000B05C0
		[XmlIgnore]
		public Vector4d Xzwy
		{
			get
			{
				return new Vector4d(this.X, this.Z, this.W, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.W = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x060041FC RID: 16892 RVA: 0x000B23F8 File Offset: 0x000B05F8
		// (set) Token: 0x060041FD RID: 16893 RVA: 0x000B2418 File Offset: 0x000B0618
		[XmlIgnore]
		public Vector4d Xwyz
		{
			get
			{
				return new Vector4d(this.X, this.W, this.Y, this.Z);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Y = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x060041FE RID: 16894 RVA: 0x000B2450 File Offset: 0x000B0650
		// (set) Token: 0x060041FF RID: 16895 RVA: 0x000B2470 File Offset: 0x000B0670
		[XmlIgnore]
		public Vector4d Xwzy
		{
			get
			{
				return new Vector4d(this.X, this.W, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06004200 RID: 16896 RVA: 0x000B24A8 File Offset: 0x000B06A8
		// (set) Token: 0x06004201 RID: 16897 RVA: 0x000B24C8 File Offset: 0x000B06C8
		[XmlIgnore]
		public Vector4d Yxzw
		{
			get
			{
				return new Vector4d(this.Y, this.X, this.Z, this.W);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.Z = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06004202 RID: 16898 RVA: 0x000B2500 File Offset: 0x000B0700
		// (set) Token: 0x06004203 RID: 16899 RVA: 0x000B2520 File Offset: 0x000B0720
		[XmlIgnore]
		public Vector4d Yxwz
		{
			get
			{
				return new Vector4d(this.Y, this.X, this.W, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06004204 RID: 16900 RVA: 0x000B2558 File Offset: 0x000B0758
		// (set) Token: 0x06004205 RID: 16901 RVA: 0x000B2578 File Offset: 0x000B0778
		[XmlIgnore]
		public Vector4d Yyzw
		{
			get
			{
				return new Vector4d(this.Y, this.Y, this.Z, this.W);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06004206 RID: 16902 RVA: 0x000B25B0 File Offset: 0x000B07B0
		// (set) Token: 0x06004207 RID: 16903 RVA: 0x000B25D0 File Offset: 0x000B07D0
		[XmlIgnore]
		public Vector4d Yywz
		{
			get
			{
				return new Vector4d(this.Y, this.Y, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06004208 RID: 16904 RVA: 0x000B2608 File Offset: 0x000B0808
		// (set) Token: 0x06004209 RID: 16905 RVA: 0x000B2628 File Offset: 0x000B0828
		[XmlIgnore]
		public Vector4d Yzxw
		{
			get
			{
				return new Vector4d(this.Y, this.Z, this.X, this.W);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.X = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x0600420A RID: 16906 RVA: 0x000B2660 File Offset: 0x000B0860
		// (set) Token: 0x0600420B RID: 16907 RVA: 0x000B2680 File Offset: 0x000B0880
		[XmlIgnore]
		public Vector4d Yzwx
		{
			get
			{
				return new Vector4d(this.Y, this.Z, this.W, this.X);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.W = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x0600420C RID: 16908 RVA: 0x000B26B8 File Offset: 0x000B08B8
		// (set) Token: 0x0600420D RID: 16909 RVA: 0x000B26D8 File Offset: 0x000B08D8
		[XmlIgnore]
		public Vector4d Ywxz
		{
			get
			{
				return new Vector4d(this.Y, this.W, this.X, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.X = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x0600420E RID: 16910 RVA: 0x000B2710 File Offset: 0x000B0910
		// (set) Token: 0x0600420F RID: 16911 RVA: 0x000B2730 File Offset: 0x000B0930
		[XmlIgnore]
		public Vector4d Ywzx
		{
			get
			{
				return new Vector4d(this.Y, this.W, this.Z, this.X);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06004210 RID: 16912 RVA: 0x000B2768 File Offset: 0x000B0968
		// (set) Token: 0x06004211 RID: 16913 RVA: 0x000B2788 File Offset: 0x000B0988
		[XmlIgnore]
		public Vector4d Zxyw
		{
			get
			{
				return new Vector4d(this.Z, this.X, this.Y, this.W);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06004212 RID: 16914 RVA: 0x000B27C0 File Offset: 0x000B09C0
		// (set) Token: 0x06004213 RID: 16915 RVA: 0x000B27E0 File Offset: 0x000B09E0
		[XmlIgnore]
		public Vector4d Zxwy
		{
			get
			{
				return new Vector4d(this.Z, this.X, this.W, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.W = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06004214 RID: 16916 RVA: 0x000B2818 File Offset: 0x000B0A18
		// (set) Token: 0x06004215 RID: 16917 RVA: 0x000B2838 File Offset: 0x000B0A38
		[XmlIgnore]
		public Vector4d Zyxw
		{
			get
			{
				return new Vector4d(this.Z, this.Y, this.X, this.W);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.X = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06004216 RID: 16918 RVA: 0x000B2870 File Offset: 0x000B0A70
		// (set) Token: 0x06004217 RID: 16919 RVA: 0x000B2890 File Offset: 0x000B0A90
		[XmlIgnore]
		public Vector4d Zywx
		{
			get
			{
				return new Vector4d(this.Z, this.Y, this.W, this.X);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06004218 RID: 16920 RVA: 0x000B28C8 File Offset: 0x000B0AC8
		// (set) Token: 0x06004219 RID: 16921 RVA: 0x000B28E8 File Offset: 0x000B0AE8
		[XmlIgnore]
		public Vector4d Zwxy
		{
			get
			{
				return new Vector4d(this.Z, this.W, this.X, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.X = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x0600421A RID: 16922 RVA: 0x000B2920 File Offset: 0x000B0B20
		// (set) Token: 0x0600421B RID: 16923 RVA: 0x000B2940 File Offset: 0x000B0B40
		[XmlIgnore]
		public Vector4d Zwyx
		{
			get
			{
				return new Vector4d(this.Z, this.W, this.Y, this.X);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.Y = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x0600421C RID: 16924 RVA: 0x000B2978 File Offset: 0x000B0B78
		// (set) Token: 0x0600421D RID: 16925 RVA: 0x000B2998 File Offset: 0x000B0B98
		[XmlIgnore]
		public Vector4d Zwzy
		{
			get
			{
				return new Vector4d(this.Z, this.W, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x0600421E RID: 16926 RVA: 0x000B29D0 File Offset: 0x000B0BD0
		// (set) Token: 0x0600421F RID: 16927 RVA: 0x000B29F0 File Offset: 0x000B0BF0
		[XmlIgnore]
		public Vector4d Wxyz
		{
			get
			{
				return new Vector4d(this.W, this.X, this.Y, this.Z);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Y = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06004220 RID: 16928 RVA: 0x000B2A28 File Offset: 0x000B0C28
		// (set) Token: 0x06004221 RID: 16929 RVA: 0x000B2A48 File Offset: 0x000B0C48
		[XmlIgnore]
		public Vector4d Wxzy
		{
			get
			{
				return new Vector4d(this.W, this.X, this.Z, this.Y);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06004222 RID: 16930 RVA: 0x000B2A80 File Offset: 0x000B0C80
		// (set) Token: 0x06004223 RID: 16931 RVA: 0x000B2AA0 File Offset: 0x000B0CA0
		[XmlIgnore]
		public Vector4d Wyxz
		{
			get
			{
				return new Vector4d(this.W, this.Y, this.X, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.X = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06004224 RID: 16932 RVA: 0x000B2AD8 File Offset: 0x000B0CD8
		// (set) Token: 0x06004225 RID: 16933 RVA: 0x000B2AF8 File Offset: 0x000B0CF8
		[XmlIgnore]
		public Vector4d Wyzx
		{
			get
			{
				return new Vector4d(this.W, this.Y, this.Z, this.X);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06004226 RID: 16934 RVA: 0x000B2B30 File Offset: 0x000B0D30
		// (set) Token: 0x06004227 RID: 16935 RVA: 0x000B2B50 File Offset: 0x000B0D50
		[XmlIgnore]
		public Vector4d Wzxy
		{
			get
			{
				return new Vector4d(this.W, this.Z, this.X, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.X = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06004228 RID: 16936 RVA: 0x000B2B88 File Offset: 0x000B0D88
		// (set) Token: 0x06004229 RID: 16937 RVA: 0x000B2BA8 File Offset: 0x000B0DA8
		[XmlIgnore]
		public Vector4d Wzyx
		{
			get
			{
				return new Vector4d(this.W, this.Z, this.Y, this.X);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x0600422A RID: 16938 RVA: 0x000B2BE0 File Offset: 0x000B0DE0
		// (set) Token: 0x0600422B RID: 16939 RVA: 0x000B2C00 File Offset: 0x000B0E00
		[XmlIgnore]
		public Vector4d Wzyw
		{
			get
			{
				return new Vector4d(this.W, this.Z, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x0600422C RID: 16940 RVA: 0x000B2C38 File Offset: 0x000B0E38
		public static Vector4d operator +(Vector4d left, Vector4d right)
		{
			left.X += right.X;
			left.Y += right.Y;
			left.Z += right.Z;
			left.W += right.W;
			return left;
		}

		// Token: 0x0600422D RID: 16941 RVA: 0x000B2C9C File Offset: 0x000B0E9C
		public static Vector4d operator -(Vector4d left, Vector4d right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
			left.Z -= right.Z;
			left.W -= right.W;
			return left;
		}

		// Token: 0x0600422E RID: 16942 RVA: 0x000B2D00 File Offset: 0x000B0F00
		public static Vector4d operator -(Vector4d vec)
		{
			vec.X = -vec.X;
			vec.Y = -vec.Y;
			vec.Z = -vec.Z;
			vec.W = -vec.W;
			return vec;
		}

		// Token: 0x0600422F RID: 16943 RVA: 0x000B2D40 File Offset: 0x000B0F40
		public static Vector4d operator *(Vector4d vec, double scale)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			vec.W *= scale;
			return vec;
		}

		// Token: 0x06004230 RID: 16944 RVA: 0x000B2D80 File Offset: 0x000B0F80
		public static Vector4d operator *(double scale, Vector4d vec)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			vec.W *= scale;
			return vec;
		}

		// Token: 0x06004231 RID: 16945 RVA: 0x000B2DC0 File Offset: 0x000B0FC0
		public static Vector4d operator *(Vector4d vec, Vector4d scale)
		{
			vec.X *= scale.X;
			vec.Y *= scale.Y;
			vec.Z *= scale.Z;
			vec.W *= scale.W;
			return vec;
		}

		// Token: 0x06004232 RID: 16946 RVA: 0x000B2E24 File Offset: 0x000B1024
		public static Vector4d operator /(Vector4d vec, double scale)
		{
			double num = 1.0 / scale;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			vec.W *= num;
			return vec;
		}

		// Token: 0x06004233 RID: 16947 RVA: 0x000B2E7C File Offset: 0x000B107C
		public static bool operator ==(Vector4d left, Vector4d right)
		{
			return left.Equals(right);
		}

		// Token: 0x06004234 RID: 16948 RVA: 0x000B2E88 File Offset: 0x000B1088
		public static bool operator !=(Vector4d left, Vector4d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06004235 RID: 16949 RVA: 0x000B2E98 File Offset: 0x000B1098
		[CLSCompliant(false)]
		public unsafe static explicit operator double*(Vector4d v)
		{
			return &v.X;
		}

		// Token: 0x06004236 RID: 16950 RVA: 0x000B2EA4 File Offset: 0x000B10A4
		public unsafe static explicit operator IntPtr(Vector4d v)
		{
			return (IntPtr)((void*)(&v.X));
		}

		// Token: 0x06004237 RID: 16951 RVA: 0x000B2EB4 File Offset: 0x000B10B4
		public static explicit operator Vector4d(Vector4 v4)
		{
			return new Vector4d((double)v4.X, (double)v4.Y, (double)v4.Z, (double)v4.W);
		}

		// Token: 0x06004238 RID: 16952 RVA: 0x000B2EDC File Offset: 0x000B10DC
		public static explicit operator Vector4(Vector4d v4d)
		{
			return new Vector4((float)v4d.X, (float)v4d.Y, (float)v4d.Z, (float)v4d.W);
		}

		// Token: 0x06004239 RID: 16953 RVA: 0x000B2F04 File Offset: 0x000B1104
		public override string ToString()
		{
			return string.Format("({0}{4} {1}{4} {2}{4} {3})", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W,
				Vector4d.listSeparator
			});
		}

		// Token: 0x0600423A RID: 16954 RVA: 0x000B2F64 File Offset: 0x000B1164
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode() ^ this.W.GetHashCode();
		}

		// Token: 0x0600423B RID: 16955 RVA: 0x000B2F98 File Offset: 0x000B1198
		public override bool Equals(object obj)
		{
			return obj is Vector4d && this.Equals((Vector4d)obj);
		}

		// Token: 0x0600423C RID: 16956 RVA: 0x000B2FB0 File Offset: 0x000B11B0
		public bool Equals(Vector4d other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z && this.W == other.W;
		}

		// Token: 0x04004E31 RID: 20017
		public double X;

		// Token: 0x04004E32 RID: 20018
		public double Y;

		// Token: 0x04004E33 RID: 20019
		public double Z;

		// Token: 0x04004E34 RID: 20020
		public double W;

		// Token: 0x04004E35 RID: 20021
		public static readonly Vector4d UnitX = new Vector4d(1.0, 0.0, 0.0, 0.0);

		// Token: 0x04004E36 RID: 20022
		public static readonly Vector4d UnitY = new Vector4d(0.0, 1.0, 0.0, 0.0);

		// Token: 0x04004E37 RID: 20023
		public static readonly Vector4d UnitZ = new Vector4d(0.0, 0.0, 1.0, 0.0);

		// Token: 0x04004E38 RID: 20024
		public static readonly Vector4d UnitW = new Vector4d(0.0, 0.0, 0.0, 1.0);

		// Token: 0x04004E39 RID: 20025
		public static readonly Vector4d Zero = new Vector4d(0.0, 0.0, 0.0, 0.0);

		// Token: 0x04004E3A RID: 20026
		public static readonly Vector4d One = new Vector4d(1.0, 1.0, 1.0, 1.0);

		// Token: 0x04004E3B RID: 20027
		public static readonly int SizeInBytes = Marshal.SizeOf(default(Vector4d));

		// Token: 0x04004E3C RID: 20028
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
