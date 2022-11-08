using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x0200053C RID: 1340
	[Serializable]
	public struct Vector3d : IEquatable<Vector3d>
	{
		// Token: 0x06004375 RID: 17269 RVA: 0x000B6A88 File Offset: 0x000B4C88
		public Vector3d(double value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
		}

		// Token: 0x06004376 RID: 17270 RVA: 0x000B6AA0 File Offset: 0x000B4CA0
		public Vector3d(double x, double y, double z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x06004377 RID: 17271 RVA: 0x000B6AB8 File Offset: 0x000B4CB8
		public Vector3d(Vector2d v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = 0.0;
		}

		// Token: 0x06004378 RID: 17272 RVA: 0x000B6AE4 File Offset: 0x000B4CE4
		public Vector3d(Vector3d v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
		}

		// Token: 0x06004379 RID: 17273 RVA: 0x000B6B10 File Offset: 0x000B4D10
		public Vector3d(Vector4d v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
		}

		// Token: 0x170003FF RID: 1023
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
				throw new IndexOutOfRangeException("You tried to set this vector at index: " + index);
			}
		}

		// Token: 0x0600437C RID: 17276 RVA: 0x000B6BB0 File Offset: 0x000B4DB0
		[Obsolete("Use static Add() method instead.")]
		[CLSCompliant(false)]
		public void Add(Vector3d right)
		{
			this.X += right.X;
			this.Y += right.Y;
			this.Z += right.Z;
		}

		// Token: 0x0600437D RID: 17277 RVA: 0x000B6BF0 File Offset: 0x000B4DF0
		[CLSCompliant(false)]
		[Obsolete("Use static Add() method instead.")]
		public void Add(ref Vector3d right)
		{
			this.X += right.X;
			this.Y += right.Y;
			this.Z += right.Z;
		}

		// Token: 0x0600437E RID: 17278 RVA: 0x000B6C2C File Offset: 0x000B4E2C
		[Obsolete("Use static Subtract() method instead.")]
		[CLSCompliant(false)]
		public void Sub(Vector3d right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
			this.Z -= right.Z;
		}

		// Token: 0x0600437F RID: 17279 RVA: 0x000B6C6C File Offset: 0x000B4E6C
		[CLSCompliant(false)]
		[Obsolete("Use static Subtract() method instead.")]
		public void Sub(ref Vector3d right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
			this.Z -= right.Z;
		}

		// Token: 0x06004380 RID: 17280 RVA: 0x000B6CA8 File Offset: 0x000B4EA8
		[Obsolete("Use static Multiply() method instead.")]
		public void Mult(double f)
		{
			this.X *= f;
			this.Y *= f;
			this.Z *= f;
		}

		// Token: 0x06004381 RID: 17281 RVA: 0x000B6CD4 File Offset: 0x000B4ED4
		[Obsolete("Use static Divide() method instead.")]
		public void Div(double f)
		{
			double num = 1.0 / f;
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06004382 RID: 17282 RVA: 0x000B6D18 File Offset: 0x000B4F18
		public double Length
		{
			get
			{
				return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06004383 RID: 17283 RVA: 0x000B6D48 File Offset: 0x000B4F48
		public double LengthFast
		{
			get
			{
				return 1.0 / MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06004384 RID: 17284 RVA: 0x000B6D84 File Offset: 0x000B4F84
		public double LengthSquared
		{
			get
			{
				return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
			}
		}

		// Token: 0x06004385 RID: 17285 RVA: 0x000B6DB0 File Offset: 0x000B4FB0
		public Vector3d Normalized()
		{
			Vector3d result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06004386 RID: 17286 RVA: 0x000B6DCC File Offset: 0x000B4FCC
		public void Normalize()
		{
			double num = 1.0 / this.Length;
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
		}

		// Token: 0x06004387 RID: 17287 RVA: 0x000B6E14 File Offset: 0x000B5014
		public void NormalizeFast()
		{
			double num = MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
		}

		// Token: 0x06004388 RID: 17288 RVA: 0x000B6E7C File Offset: 0x000B507C
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(double sx, double sy, double sz)
		{
			this.X *= sx;
			this.Y *= sy;
			this.Z *= sz;
		}

		// Token: 0x06004389 RID: 17289 RVA: 0x000B6EA8 File Offset: 0x000B50A8
		[Obsolete("Use static Multiply() method instead.")]
		[CLSCompliant(false)]
		public void Scale(Vector3d scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
			this.Z *= scale.Z;
		}

		// Token: 0x0600438A RID: 17290 RVA: 0x000B6EE8 File Offset: 0x000B50E8
		[CLSCompliant(false)]
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(ref Vector3d scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
			this.Z *= scale.Z;
		}

		// Token: 0x0600438B RID: 17291 RVA: 0x000B6F24 File Offset: 0x000B5124
		[Obsolete("Use static Subtract() method instead.")]
		public static Vector3d Sub(Vector3d a, Vector3d b)
		{
			a.X -= b.X;
			a.Y -= b.Y;
			a.Z -= b.Z;
			return a;
		}

		// Token: 0x0600438C RID: 17292 RVA: 0x000B6F74 File Offset: 0x000B5174
		[Obsolete("Use static Subtract() method instead.")]
		public static void Sub(ref Vector3d a, ref Vector3d b, out Vector3d result)
		{
			result.X = a.X - b.X;
			result.Y = a.Y - b.Y;
			result.Z = a.Z - b.Z;
		}

		// Token: 0x0600438D RID: 17293 RVA: 0x000B6FB0 File Offset: 0x000B51B0
		[Obsolete("Use static Multiply() method instead.")]
		public static Vector3d Mult(Vector3d a, double f)
		{
			a.X *= f;
			a.Y *= f;
			a.Z *= f;
			return a;
		}

		// Token: 0x0600438E RID: 17294 RVA: 0x000B6FE0 File Offset: 0x000B51E0
		[Obsolete("Use static Multiply() method instead.")]
		public static void Mult(ref Vector3d a, double f, out Vector3d result)
		{
			result.X = a.X * f;
			result.Y = a.Y * f;
			result.Z = a.Z * f;
		}

		// Token: 0x0600438F RID: 17295 RVA: 0x000B700C File Offset: 0x000B520C
		[Obsolete("Use static Divide() method instead.")]
		public static Vector3d Div(Vector3d a, double f)
		{
			double num = 1.0 / f;
			a.X *= num;
			a.Y *= num;
			a.Z *= num;
			return a;
		}

		// Token: 0x06004390 RID: 17296 RVA: 0x000B7054 File Offset: 0x000B5254
		[Obsolete("Use static Divide() method instead.")]
		public static void Div(ref Vector3d a, double f, out Vector3d result)
		{
			double num = 1.0 / f;
			result.X = a.X * num;
			result.Y = a.Y * num;
			result.Z = a.Z * num;
		}

		// Token: 0x06004391 RID: 17297 RVA: 0x000B7098 File Offset: 0x000B5298
		public static Vector3d Add(Vector3d a, Vector3d b)
		{
			Vector3d.Add(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06004392 RID: 17298 RVA: 0x000B70A8 File Offset: 0x000B52A8
		public static void Add(ref Vector3d a, ref Vector3d b, out Vector3d result)
		{
			result = new Vector3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		// Token: 0x06004393 RID: 17299 RVA: 0x000B70DC File Offset: 0x000B52DC
		public static Vector3d Subtract(Vector3d a, Vector3d b)
		{
			Vector3d.Subtract(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06004394 RID: 17300 RVA: 0x000B70EC File Offset: 0x000B52EC
		public static void Subtract(ref Vector3d a, ref Vector3d b, out Vector3d result)
		{
			result = new Vector3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		// Token: 0x06004395 RID: 17301 RVA: 0x000B7120 File Offset: 0x000B5320
		public static Vector3d Multiply(Vector3d vector, double scale)
		{
			Vector3d.Multiply(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06004396 RID: 17302 RVA: 0x000B7130 File Offset: 0x000B5330
		public static void Multiply(ref Vector3d vector, double scale, out Vector3d result)
		{
			result = new Vector3d(vector.X * scale, vector.Y * scale, vector.Z * scale);
		}

		// Token: 0x06004397 RID: 17303 RVA: 0x000B7158 File Offset: 0x000B5358
		public static Vector3d Multiply(Vector3d vector, Vector3d scale)
		{
			Vector3d.Multiply(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06004398 RID: 17304 RVA: 0x000B7168 File Offset: 0x000B5368
		public static void Multiply(ref Vector3d vector, ref Vector3d scale, out Vector3d result)
		{
			result = new Vector3d(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z);
		}

		// Token: 0x06004399 RID: 17305 RVA: 0x000B719C File Offset: 0x000B539C
		public static Vector3d Divide(Vector3d vector, double scale)
		{
			Vector3d.Divide(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x0600439A RID: 17306 RVA: 0x000B71AC File Offset: 0x000B53AC
		public static void Divide(ref Vector3d vector, double scale, out Vector3d result)
		{
			Vector3d.Multiply(ref vector, 1.0 / scale, out result);
		}

		// Token: 0x0600439B RID: 17307 RVA: 0x000B71C0 File Offset: 0x000B53C0
		public static Vector3d Divide(Vector3d vector, Vector3d scale)
		{
			Vector3d.Divide(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x0600439C RID: 17308 RVA: 0x000B71D0 File Offset: 0x000B53D0
		public static void Divide(ref Vector3d vector, ref Vector3d scale, out Vector3d result)
		{
			result = new Vector3d(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z);
		}

		// Token: 0x0600439D RID: 17309 RVA: 0x000B7204 File Offset: 0x000B5404
		public static Vector3d ComponentMin(Vector3d a, Vector3d b)
		{
			a.X = ((a.X < b.X) ? a.X : b.X);
			a.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			a.Z = ((a.Z < b.Z) ? a.Z : b.Z);
			return a;
		}

		// Token: 0x0600439E RID: 17310 RVA: 0x000B7288 File Offset: 0x000B5488
		public static void ComponentMin(ref Vector3d a, ref Vector3d b, out Vector3d result)
		{
			result.X = ((a.X < b.X) ? a.X : b.X);
			result.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			result.Z = ((a.Z < b.Z) ? a.Z : b.Z);
		}

		// Token: 0x0600439F RID: 17311 RVA: 0x000B72FC File Offset: 0x000B54FC
		public static Vector3d ComponentMax(Vector3d a, Vector3d b)
		{
			a.X = ((a.X > b.X) ? a.X : b.X);
			a.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			a.Z = ((a.Z > b.Z) ? a.Z : b.Z);
			return a;
		}

		// Token: 0x060043A0 RID: 17312 RVA: 0x000B7380 File Offset: 0x000B5580
		public static void ComponentMax(ref Vector3d a, ref Vector3d b, out Vector3d result)
		{
			result.X = ((a.X > b.X) ? a.X : b.X);
			result.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			result.Z = ((a.Z > b.Z) ? a.Z : b.Z);
		}

		// Token: 0x060043A1 RID: 17313 RVA: 0x000B73F4 File Offset: 0x000B55F4
		public static Vector3d Min(Vector3d left, Vector3d right)
		{
			if (left.LengthSquared >= right.LengthSquared)
			{
				return right;
			}
			return left;
		}

		// Token: 0x060043A2 RID: 17314 RVA: 0x000B740C File Offset: 0x000B560C
		public static Vector3d Max(Vector3d left, Vector3d right)
		{
			if (left.LengthSquared < right.LengthSquared)
			{
				return right;
			}
			return left;
		}

		// Token: 0x060043A3 RID: 17315 RVA: 0x000B7424 File Offset: 0x000B5624
		public static Vector3d Clamp(Vector3d vec, Vector3d min, Vector3d max)
		{
			vec.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			vec.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			vec.Z = ((vec.Z < min.Z) ? min.Z : ((vec.Z > max.Z) ? max.Z : vec.Z));
			return vec;
		}

		// Token: 0x060043A4 RID: 17316 RVA: 0x000B74F4 File Offset: 0x000B56F4
		public static void Clamp(ref Vector3d vec, ref Vector3d min, ref Vector3d max, out Vector3d result)
		{
			result.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			result.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			result.Z = ((vec.Z < min.Z) ? min.Z : ((vec.Z > max.Z) ? max.Z : vec.Z));
		}

		// Token: 0x060043A5 RID: 17317 RVA: 0x000B75AC File Offset: 0x000B57AC
		public static Vector3d Normalize(Vector3d vec)
		{
			double num = 1.0 / vec.Length;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			return vec;
		}

		// Token: 0x060043A6 RID: 17318 RVA: 0x000B75FC File Offset: 0x000B57FC
		public static void Normalize(ref Vector3d vec, out Vector3d result)
		{
			double num = 1.0 / vec.Length;
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
		}

		// Token: 0x060043A7 RID: 17319 RVA: 0x000B7644 File Offset: 0x000B5844
		public static Vector3d NormalizeFast(Vector3d vec)
		{
			double num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z);
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			return vec;
		}

		// Token: 0x060043A8 RID: 17320 RVA: 0x000B76B4 File Offset: 0x000B58B4
		public static void NormalizeFast(ref Vector3d vec, out Vector3d result)
		{
			double num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z);
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
		}

		// Token: 0x060043A9 RID: 17321 RVA: 0x000B771C File Offset: 0x000B591C
		public static double Dot(Vector3d left, Vector3d right)
		{
			return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
		}

		// Token: 0x060043AA RID: 17322 RVA: 0x000B7750 File Offset: 0x000B5950
		public static void Dot(ref Vector3d left, ref Vector3d right, out double result)
		{
			result = left.X * right.X + left.Y * right.Y + left.Z * right.Z;
		}

		// Token: 0x060043AB RID: 17323 RVA: 0x000B7780 File Offset: 0x000B5980
		public static Vector3d Cross(Vector3d left, Vector3d right)
		{
			Vector3d result;
			Vector3d.Cross(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060043AC RID: 17324 RVA: 0x000B779C File Offset: 0x000B599C
		public static void Cross(ref Vector3d left, ref Vector3d right, out Vector3d result)
		{
			result = new Vector3d(left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);
		}

		// Token: 0x060043AD RID: 17325 RVA: 0x000B7808 File Offset: 0x000B5A08
		public static Vector3d Lerp(Vector3d a, Vector3d b, double blend)
		{
			a.X = blend * (b.X - a.X) + a.X;
			a.Y = blend * (b.Y - a.Y) + a.Y;
			a.Z = blend * (b.Z - a.Z) + a.Z;
			return a;
		}

		// Token: 0x060043AE RID: 17326 RVA: 0x000B7878 File Offset: 0x000B5A78
		public static void Lerp(ref Vector3d a, ref Vector3d b, double blend, out Vector3d result)
		{
			result.X = blend * (b.X - a.X) + a.X;
			result.Y = blend * (b.Y - a.Y) + a.Y;
			result.Z = blend * (b.Z - a.Z) + a.Z;
		}

		// Token: 0x060043AF RID: 17327 RVA: 0x000B78DC File Offset: 0x000B5ADC
		public static Vector3d BaryCentric(Vector3d a, Vector3d b, Vector3d c, double u, double v)
		{
			return a + u * (b - a) + v * (c - a);
		}

		// Token: 0x060043B0 RID: 17328 RVA: 0x000B7904 File Offset: 0x000B5B04
		public static void BaryCentric(ref Vector3d a, ref Vector3d b, ref Vector3d c, double u, double v, out Vector3d result)
		{
			result = a;
			Vector3d vector3d = b;
			Vector3d.Subtract(ref vector3d, ref a, out vector3d);
			Vector3d.Multiply(ref vector3d, u, out vector3d);
			Vector3d.Add(ref result, ref vector3d, out result);
			vector3d = c;
			Vector3d.Subtract(ref vector3d, ref a, out vector3d);
			Vector3d.Multiply(ref vector3d, v, out vector3d);
			Vector3d.Add(ref result, ref vector3d, out result);
		}

		// Token: 0x060043B1 RID: 17329 RVA: 0x000B796C File Offset: 0x000B5B6C
		public static Vector3d TransformVector(Vector3d vec, Matrix4d mat)
		{
			return new Vector3d(Vector3d.Dot(vec, new Vector3d(mat.Column0)), Vector3d.Dot(vec, new Vector3d(mat.Column1)), Vector3d.Dot(vec, new Vector3d(mat.Column2)));
		}

		// Token: 0x060043B2 RID: 17330 RVA: 0x000B79AC File Offset: 0x000B5BAC
		public static void TransformVector(ref Vector3d vec, ref Matrix4d mat, out Vector3d result)
		{
			result.X = vec.X * mat.Row0.X + vec.Y * mat.Row1.X + vec.Z * mat.Row2.X;
			result.Y = vec.X * mat.Row0.Y + vec.Y * mat.Row1.Y + vec.Z * mat.Row2.Y;
			result.Z = vec.X * mat.Row0.Z + vec.Y * mat.Row1.Z + vec.Z * mat.Row2.Z;
		}

		// Token: 0x060043B3 RID: 17331 RVA: 0x000B7A74 File Offset: 0x000B5C74
		public static Vector3d TransformNormal(Vector3d norm, Matrix4d mat)
		{
			mat.Invert();
			return Vector3d.TransformNormalInverse(norm, mat);
		}

		// Token: 0x060043B4 RID: 17332 RVA: 0x000B7A84 File Offset: 0x000B5C84
		public static void TransformNormal(ref Vector3d norm, ref Matrix4d mat, out Vector3d result)
		{
			Matrix4d matrix4d = Matrix4d.Invert(mat);
			Vector3d.TransformNormalInverse(ref norm, ref matrix4d, out result);
		}

		// Token: 0x060043B5 RID: 17333 RVA: 0x000B7AA8 File Offset: 0x000B5CA8
		public static Vector3d TransformNormalInverse(Vector3d norm, Matrix4d invMat)
		{
			return new Vector3d(Vector3d.Dot(norm, new Vector3d(invMat.Row0)), Vector3d.Dot(norm, new Vector3d(invMat.Row1)), Vector3d.Dot(norm, new Vector3d(invMat.Row2)));
		}

		// Token: 0x060043B6 RID: 17334 RVA: 0x000B7AE8 File Offset: 0x000B5CE8
		public static void TransformNormalInverse(ref Vector3d norm, ref Matrix4d invMat, out Vector3d result)
		{
			result.X = norm.X * invMat.Row0.X + norm.Y * invMat.Row0.Y + norm.Z * invMat.Row0.Z;
			result.Y = norm.X * invMat.Row1.X + norm.Y * invMat.Row1.Y + norm.Z * invMat.Row1.Z;
			result.Z = norm.X * invMat.Row2.X + norm.Y * invMat.Row2.Y + norm.Z * invMat.Row2.Z;
		}

		// Token: 0x060043B7 RID: 17335 RVA: 0x000B7BB0 File Offset: 0x000B5DB0
		public static Vector3d TransformPosition(Vector3d pos, Matrix4d mat)
		{
			return new Vector3d(Vector3d.Dot(pos, new Vector3d(mat.Column0)) + mat.Row3.X, Vector3d.Dot(pos, new Vector3d(mat.Column1)) + mat.Row3.Y, Vector3d.Dot(pos, new Vector3d(mat.Column2)) + mat.Row3.Z);
		}

		// Token: 0x060043B8 RID: 17336 RVA: 0x000B7C20 File Offset: 0x000B5E20
		public static void TransformPosition(ref Vector3d pos, ref Matrix4d mat, out Vector3d result)
		{
			result.X = pos.X * mat.Row0.X + pos.Y * mat.Row1.X + pos.Z * mat.Row2.X + mat.Row3.X;
			result.Y = pos.X * mat.Row0.Y + pos.Y * mat.Row1.Y + pos.Z * mat.Row2.Y + mat.Row3.Y;
			result.Z = pos.X * mat.Row0.Z + pos.Y * mat.Row1.Z + pos.Z * mat.Row2.Z + mat.Row3.Z;
		}

		// Token: 0x060043B9 RID: 17337 RVA: 0x000B7D0C File Offset: 0x000B5F0C
		public static Vector3d Transform(Vector3d vec, Matrix4d mat)
		{
			Vector3d result;
			Vector3d.Transform(ref vec, ref mat, out result);
			return result;
		}

		// Token: 0x060043BA RID: 17338 RVA: 0x000B7D28 File Offset: 0x000B5F28
		public static void Transform(ref Vector3d vec, ref Matrix4d mat, out Vector3d result)
		{
			Vector4d vector4d = new Vector4d(vec.X, vec.Y, vec.Z, 1.0);
			Vector4d.Transform(ref vector4d, ref mat, out vector4d);
			result = vector4d.Xyz;
		}

		// Token: 0x060043BB RID: 17339 RVA: 0x000B7D74 File Offset: 0x000B5F74
		public static Vector3d Transform(Vector3d vec, Quaterniond quat)
		{
			Vector3d result;
			Vector3d.Transform(ref vec, ref quat, out result);
			return result;
		}

		// Token: 0x060043BC RID: 17340 RVA: 0x000B7D90 File Offset: 0x000B5F90
		public static void Transform(ref Vector3d vec, ref Quaterniond quat, out Vector3d result)
		{
			Vector3d xyz = quat.Xyz;
			Vector3d vector3d;
			Vector3d.Cross(ref xyz, ref vec, out vector3d);
			Vector3d vector3d2;
			Vector3d.Multiply(ref vec, quat.W, out vector3d2);
			Vector3d.Add(ref vector3d, ref vector3d2, out vector3d);
			Vector3d.Cross(ref xyz, ref vector3d, out vector3d);
			Vector3d.Multiply(ref vector3d, 2.0, out vector3d);
			Vector3d.Add(ref vec, ref vector3d, out result);
		}

		// Token: 0x060043BD RID: 17341 RVA: 0x000B7DF0 File Offset: 0x000B5FF0
		public static Vector3d TransformPerspective(Vector3d vec, Matrix4d mat)
		{
			Vector3d result;
			Vector3d.TransformPerspective(ref vec, ref mat, out result);
			return result;
		}

		// Token: 0x060043BE RID: 17342 RVA: 0x000B7E0C File Offset: 0x000B600C
		public static void TransformPerspective(ref Vector3d vec, ref Matrix4d mat, out Vector3d result)
		{
			Vector4d vector4d = new Vector4d(vec, 1.0);
			Vector4d.Transform(ref vector4d, ref mat, out vector4d);
			result.X = vector4d.X / vector4d.W;
			result.Y = vector4d.Y / vector4d.W;
			result.Z = vector4d.Z / vector4d.W;
		}

		// Token: 0x060043BF RID: 17343 RVA: 0x000B7E80 File Offset: 0x000B6080
		public static double CalculateAngle(Vector3d first, Vector3d second)
		{
			return Math.Acos(Vector3d.Dot(first, second) / (first.Length * second.Length));
		}

		// Token: 0x060043C0 RID: 17344 RVA: 0x000B7EA0 File Offset: 0x000B60A0
		public static void CalculateAngle(ref Vector3d first, ref Vector3d second, out double result)
		{
			double num;
			Vector3d.Dot(ref first, ref second, out num);
			result = Math.Acos(num / (first.Length * second.Length));
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x060043C1 RID: 17345 RVA: 0x000B7ECC File Offset: 0x000B60CC
		// (set) Token: 0x060043C2 RID: 17346 RVA: 0x000B7EE0 File Offset: 0x000B60E0
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

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x060043C3 RID: 17347 RVA: 0x000B7EFC File Offset: 0x000B60FC
		// (set) Token: 0x060043C4 RID: 17348 RVA: 0x000B7F10 File Offset: 0x000B6110
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

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x060043C5 RID: 17349 RVA: 0x000B7F2C File Offset: 0x000B612C
		// (set) Token: 0x060043C6 RID: 17350 RVA: 0x000B7F40 File Offset: 0x000B6140
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

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x060043C7 RID: 17351 RVA: 0x000B7F5C File Offset: 0x000B615C
		// (set) Token: 0x060043C8 RID: 17352 RVA: 0x000B7F70 File Offset: 0x000B6170
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

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x060043C9 RID: 17353 RVA: 0x000B7F8C File Offset: 0x000B618C
		// (set) Token: 0x060043CA RID: 17354 RVA: 0x000B7FA0 File Offset: 0x000B61A0
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

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x060043CB RID: 17355 RVA: 0x000B7FBC File Offset: 0x000B61BC
		// (set) Token: 0x060043CC RID: 17356 RVA: 0x000B7FD0 File Offset: 0x000B61D0
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

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x060043CD RID: 17357 RVA: 0x000B7FEC File Offset: 0x000B61EC
		// (set) Token: 0x060043CE RID: 17358 RVA: 0x000B8008 File Offset: 0x000B6208
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

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x060043CF RID: 17359 RVA: 0x000B8034 File Offset: 0x000B6234
		// (set) Token: 0x060043D0 RID: 17360 RVA: 0x000B8050 File Offset: 0x000B6250
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

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x060043D1 RID: 17361 RVA: 0x000B807C File Offset: 0x000B627C
		// (set) Token: 0x060043D2 RID: 17362 RVA: 0x000B8098 File Offset: 0x000B6298
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

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x060043D3 RID: 17363 RVA: 0x000B80C4 File Offset: 0x000B62C4
		// (set) Token: 0x060043D4 RID: 17364 RVA: 0x000B80E0 File Offset: 0x000B62E0
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

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x060043D5 RID: 17365 RVA: 0x000B810C File Offset: 0x000B630C
		// (set) Token: 0x060043D6 RID: 17366 RVA: 0x000B8128 File Offset: 0x000B6328
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

		// Token: 0x060043D7 RID: 17367 RVA: 0x000B8154 File Offset: 0x000B6354
		public static Vector3d operator +(Vector3d left, Vector3d right)
		{
			left.X += right.X;
			left.Y += right.Y;
			left.Z += right.Z;
			return left;
		}

		// Token: 0x060043D8 RID: 17368 RVA: 0x000B81A4 File Offset: 0x000B63A4
		public static Vector3d operator -(Vector3d left, Vector3d right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
			left.Z -= right.Z;
			return left;
		}

		// Token: 0x060043D9 RID: 17369 RVA: 0x000B81F4 File Offset: 0x000B63F4
		public static Vector3d operator -(Vector3d vec)
		{
			vec.X = -vec.X;
			vec.Y = -vec.Y;
			vec.Z = -vec.Z;
			return vec;
		}

		// Token: 0x060043DA RID: 17370 RVA: 0x000B8224 File Offset: 0x000B6424
		public static Vector3d operator *(Vector3d vec, double scale)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			return vec;
		}

		// Token: 0x060043DB RID: 17371 RVA: 0x000B8254 File Offset: 0x000B6454
		public static Vector3d operator *(double scale, Vector3d vec)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			return vec;
		}

		// Token: 0x060043DC RID: 17372 RVA: 0x000B8284 File Offset: 0x000B6484
		public static Vector3d operator *(Vector3d vec, Vector3d scale)
		{
			vec.X *= scale.X;
			vec.Y *= scale.Y;
			vec.Z *= scale.Z;
			return vec;
		}

		// Token: 0x060043DD RID: 17373 RVA: 0x000B82D4 File Offset: 0x000B64D4
		public static Vector3d operator /(Vector3d vec, double scale)
		{
			double num = 1.0 / scale;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			return vec;
		}

		// Token: 0x060043DE RID: 17374 RVA: 0x000B831C File Offset: 0x000B651C
		public static bool operator ==(Vector3d left, Vector3d right)
		{
			return left.Equals(right);
		}

		// Token: 0x060043DF RID: 17375 RVA: 0x000B8328 File Offset: 0x000B6528
		public static bool operator !=(Vector3d left, Vector3d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060043E0 RID: 17376 RVA: 0x000B8338 File Offset: 0x000B6538
		public static explicit operator Vector3d(Vector3 v3)
		{
			return new Vector3d((double)v3.X, (double)v3.Y, (double)v3.Z);
		}

		// Token: 0x060043E1 RID: 17377 RVA: 0x000B8358 File Offset: 0x000B6558
		public static explicit operator Vector3(Vector3d v3d)
		{
			return new Vector3((float)v3d.X, (float)v3d.Y, (float)v3d.Z);
		}

		// Token: 0x060043E2 RID: 17378 RVA: 0x000B8378 File Offset: 0x000B6578
		public override string ToString()
		{
			return string.Format("({0}{3} {1}{3} {2})", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				Vector3d.listSeparator
			});
		}

		// Token: 0x060043E3 RID: 17379 RVA: 0x000B83CC File Offset: 0x000B65CC
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
		}

		// Token: 0x060043E4 RID: 17380 RVA: 0x000B83F4 File Offset: 0x000B65F4
		public override bool Equals(object obj)
		{
			return obj is Vector3d && this.Equals((Vector3d)obj);
		}

		// Token: 0x060043E5 RID: 17381 RVA: 0x000B840C File Offset: 0x000B660C
		public bool Equals(Vector3d other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
		}

		// Token: 0x04004E5C RID: 20060
		public double X;

		// Token: 0x04004E5D RID: 20061
		public double Y;

		// Token: 0x04004E5E RID: 20062
		public double Z;

		// Token: 0x04004E5F RID: 20063
		public static readonly Vector3d UnitX = new Vector3d(1.0, 0.0, 0.0);

		// Token: 0x04004E60 RID: 20064
		public static readonly Vector3d UnitY = new Vector3d(0.0, 1.0, 0.0);

		// Token: 0x04004E61 RID: 20065
		public static readonly Vector3d UnitZ = new Vector3d(0.0, 0.0, 1.0);

		// Token: 0x04004E62 RID: 20066
		public static readonly Vector3d Zero = new Vector3d(0.0, 0.0, 0.0);

		// Token: 0x04004E63 RID: 20067
		public static readonly Vector3d One = new Vector3d(1.0, 1.0, 1.0);

		// Token: 0x04004E64 RID: 20068
		public static readonly int SizeInBytes = Marshal.SizeOf(default(Vector3d));

		// Token: 0x04004E65 RID: 20069
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
