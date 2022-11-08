using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x0200052D RID: 1325
	[Serializable]
	public struct Vector3 : IEquatable<Vector3>
	{
		// Token: 0x06003F40 RID: 16192 RVA: 0x000A7738 File Offset: 0x000A5938
		public Vector3(float value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
		}

		// Token: 0x06003F41 RID: 16193 RVA: 0x000A7750 File Offset: 0x000A5950
		public Vector3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x06003F42 RID: 16194 RVA: 0x000A7768 File Offset: 0x000A5968
		public Vector3(Vector2 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = 0f;
		}

		// Token: 0x06003F43 RID: 16195 RVA: 0x000A7790 File Offset: 0x000A5990
		public Vector3(Vector3 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
		}

		// Token: 0x06003F44 RID: 16196 RVA: 0x000A77BC File Offset: 0x000A59BC
		public Vector3(Vector4 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
		}

		// Token: 0x17000317 RID: 791
		public float this[int index]
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

		// Token: 0x06003F47 RID: 16199 RVA: 0x000A785C File Offset: 0x000A5A5C
		[Obsolete("Use static Add() method instead.")]
		[CLSCompliant(false)]
		public void Add(Vector3 right)
		{
			this.X += right.X;
			this.Y += right.Y;
			this.Z += right.Z;
		}

		// Token: 0x06003F48 RID: 16200 RVA: 0x000A789C File Offset: 0x000A5A9C
		[CLSCompliant(false)]
		[Obsolete("Use static Add() method instead.")]
		public void Add(ref Vector3 right)
		{
			this.X += right.X;
			this.Y += right.Y;
			this.Z += right.Z;
		}

		// Token: 0x06003F49 RID: 16201 RVA: 0x000A78D8 File Offset: 0x000A5AD8
		[Obsolete("Use static Subtract() method instead.")]
		[CLSCompliant(false)]
		public void Sub(Vector3 right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
			this.Z -= right.Z;
		}

		// Token: 0x06003F4A RID: 16202 RVA: 0x000A7918 File Offset: 0x000A5B18
		[CLSCompliant(false)]
		[Obsolete("Use static Subtract() method instead.")]
		public void Sub(ref Vector3 right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
			this.Z -= right.Z;
		}

		// Token: 0x06003F4B RID: 16203 RVA: 0x000A7954 File Offset: 0x000A5B54
		[Obsolete("Use static Multiply() method instead.")]
		public void Mult(float f)
		{
			this.X *= f;
			this.Y *= f;
			this.Z *= f;
		}

		// Token: 0x06003F4C RID: 16204 RVA: 0x000A7980 File Offset: 0x000A5B80
		[Obsolete("Use static Divide() method instead.")]
		public void Div(float f)
		{
			float num = 1f / f;
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06003F4D RID: 16205 RVA: 0x000A79C0 File Offset: 0x000A5BC0
		public float Length
		{
			get
			{
				return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z));
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06003F4E RID: 16206 RVA: 0x000A79F4 File Offset: 0x000A5BF4
		public float LengthFast
		{
			get
			{
				return 1f / MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06003F4F RID: 16207 RVA: 0x000A7A2C File Offset: 0x000A5C2C
		public float LengthSquared
		{
			get
			{
				return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
			}
		}

		// Token: 0x06003F50 RID: 16208 RVA: 0x000A7A58 File Offset: 0x000A5C58
		public Vector3 Normalized()
		{
			Vector3 result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06003F51 RID: 16209 RVA: 0x000A7A74 File Offset: 0x000A5C74
		public void Normalize()
		{
			float num = 1f / this.Length;
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
		}

		// Token: 0x06003F52 RID: 16210 RVA: 0x000A7AB8 File Offset: 0x000A5CB8
		public void NormalizeFast()
		{
			float num = MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
		}

		// Token: 0x06003F53 RID: 16211 RVA: 0x000A7B20 File Offset: 0x000A5D20
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(float sx, float sy, float sz)
		{
			this.X *= sx;
			this.Y *= sy;
			this.Z *= sz;
		}

		// Token: 0x06003F54 RID: 16212 RVA: 0x000A7B4C File Offset: 0x000A5D4C
		[Obsolete("Use static Multiply() method instead.")]
		[CLSCompliant(false)]
		public void Scale(Vector3 scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
			this.Z *= scale.Z;
		}

		// Token: 0x06003F55 RID: 16213 RVA: 0x000A7B8C File Offset: 0x000A5D8C
		[Obsolete("Use static Multiply() method instead.")]
		[CLSCompliant(false)]
		public void Scale(ref Vector3 scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
			this.Z *= scale.Z;
		}

		// Token: 0x06003F56 RID: 16214 RVA: 0x000A7BC8 File Offset: 0x000A5DC8
		[Obsolete("Use static Subtract() method instead.")]
		public static Vector3 Sub(Vector3 a, Vector3 b)
		{
			a.X -= b.X;
			a.Y -= b.Y;
			a.Z -= b.Z;
			return a;
		}

		// Token: 0x06003F57 RID: 16215 RVA: 0x000A7C18 File Offset: 0x000A5E18
		[Obsolete("Use static Subtract() method instead.")]
		public static void Sub(ref Vector3 a, ref Vector3 b, out Vector3 result)
		{
			result.X = a.X - b.X;
			result.Y = a.Y - b.Y;
			result.Z = a.Z - b.Z;
		}

		// Token: 0x06003F58 RID: 16216 RVA: 0x000A7C54 File Offset: 0x000A5E54
		[Obsolete("Use static Multiply() method instead.")]
		public static Vector3 Mult(Vector3 a, float f)
		{
			a.X *= f;
			a.Y *= f;
			a.Z *= f;
			return a;
		}

		// Token: 0x06003F59 RID: 16217 RVA: 0x000A7C84 File Offset: 0x000A5E84
		[Obsolete("Use static Multiply() method instead.")]
		public static void Mult(ref Vector3 a, float f, out Vector3 result)
		{
			result.X = a.X * f;
			result.Y = a.Y * f;
			result.Z = a.Z * f;
		}

		// Token: 0x06003F5A RID: 16218 RVA: 0x000A7CB0 File Offset: 0x000A5EB0
		[Obsolete("Use static Divide() method instead.")]
		public static Vector3 Div(Vector3 a, float f)
		{
			float num = 1f / f;
			a.X *= num;
			a.Y *= num;
			a.Z *= num;
			return a;
		}

		// Token: 0x06003F5B RID: 16219 RVA: 0x000A7CF4 File Offset: 0x000A5EF4
		[Obsolete("Use static Divide() method instead.")]
		public static void Div(ref Vector3 a, float f, out Vector3 result)
		{
			float num = 1f / f;
			result.X = a.X * num;
			result.Y = a.Y * num;
			result.Z = a.Z * num;
		}

		// Token: 0x06003F5C RID: 16220 RVA: 0x000A7D34 File Offset: 0x000A5F34
		public static Vector3 Add(Vector3 a, Vector3 b)
		{
			Vector3.Add(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06003F5D RID: 16221 RVA: 0x000A7D44 File Offset: 0x000A5F44
		public static void Add(ref Vector3 a, ref Vector3 b, out Vector3 result)
		{
			result = new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		// Token: 0x06003F5E RID: 16222 RVA: 0x000A7D78 File Offset: 0x000A5F78
		public static Vector3 Subtract(Vector3 a, Vector3 b)
		{
			Vector3.Subtract(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06003F5F RID: 16223 RVA: 0x000A7D88 File Offset: 0x000A5F88
		public static void Subtract(ref Vector3 a, ref Vector3 b, out Vector3 result)
		{
			result = new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		// Token: 0x06003F60 RID: 16224 RVA: 0x000A7DBC File Offset: 0x000A5FBC
		public static Vector3 Multiply(Vector3 vector, float scale)
		{
			Vector3.Multiply(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06003F61 RID: 16225 RVA: 0x000A7DCC File Offset: 0x000A5FCC
		public static void Multiply(ref Vector3 vector, float scale, out Vector3 result)
		{
			result = new Vector3(vector.X * scale, vector.Y * scale, vector.Z * scale);
		}

		// Token: 0x06003F62 RID: 16226 RVA: 0x000A7DF4 File Offset: 0x000A5FF4
		public static Vector3 Multiply(Vector3 vector, Vector3 scale)
		{
			Vector3.Multiply(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06003F63 RID: 16227 RVA: 0x000A7E04 File Offset: 0x000A6004
		public static void Multiply(ref Vector3 vector, ref Vector3 scale, out Vector3 result)
		{
			result = new Vector3(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z);
		}

		// Token: 0x06003F64 RID: 16228 RVA: 0x000A7E38 File Offset: 0x000A6038
		public static Vector3 Divide(Vector3 vector, float scale)
		{
			Vector3.Divide(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06003F65 RID: 16229 RVA: 0x000A7E48 File Offset: 0x000A6048
		public static void Divide(ref Vector3 vector, float scale, out Vector3 result)
		{
			Vector3.Multiply(ref vector, 1f / scale, out result);
		}

		// Token: 0x06003F66 RID: 16230 RVA: 0x000A7E58 File Offset: 0x000A6058
		public static Vector3 Divide(Vector3 vector, Vector3 scale)
		{
			Vector3.Divide(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06003F67 RID: 16231 RVA: 0x000A7E68 File Offset: 0x000A6068
		public static void Divide(ref Vector3 vector, ref Vector3 scale, out Vector3 result)
		{
			result = new Vector3(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z);
		}

		// Token: 0x06003F68 RID: 16232 RVA: 0x000A7E9C File Offset: 0x000A609C
		public static Vector3 ComponentMin(Vector3 a, Vector3 b)
		{
			a.X = ((a.X < b.X) ? a.X : b.X);
			a.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			a.Z = ((a.Z < b.Z) ? a.Z : b.Z);
			return a;
		}

		// Token: 0x06003F69 RID: 16233 RVA: 0x000A7F20 File Offset: 0x000A6120
		public static void ComponentMin(ref Vector3 a, ref Vector3 b, out Vector3 result)
		{
			result.X = ((a.X < b.X) ? a.X : b.X);
			result.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			result.Z = ((a.Z < b.Z) ? a.Z : b.Z);
		}

		// Token: 0x06003F6A RID: 16234 RVA: 0x000A7F94 File Offset: 0x000A6194
		public static Vector3 ComponentMax(Vector3 a, Vector3 b)
		{
			a.X = ((a.X > b.X) ? a.X : b.X);
			a.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			a.Z = ((a.Z > b.Z) ? a.Z : b.Z);
			return a;
		}

		// Token: 0x06003F6B RID: 16235 RVA: 0x000A8018 File Offset: 0x000A6218
		public static void ComponentMax(ref Vector3 a, ref Vector3 b, out Vector3 result)
		{
			result.X = ((a.X > b.X) ? a.X : b.X);
			result.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			result.Z = ((a.Z > b.Z) ? a.Z : b.Z);
		}

		// Token: 0x06003F6C RID: 16236 RVA: 0x000A808C File Offset: 0x000A628C
		public static Vector3 Min(Vector3 left, Vector3 right)
		{
			if (left.LengthSquared >= right.LengthSquared)
			{
				return right;
			}
			return left;
		}

		// Token: 0x06003F6D RID: 16237 RVA: 0x000A80A4 File Offset: 0x000A62A4
		public static Vector3 Max(Vector3 left, Vector3 right)
		{
			if (left.LengthSquared < right.LengthSquared)
			{
				return right;
			}
			return left;
		}

		// Token: 0x06003F6E RID: 16238 RVA: 0x000A80BC File Offset: 0x000A62BC
		public static Vector3 Clamp(Vector3 vec, Vector3 min, Vector3 max)
		{
			vec.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			vec.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			vec.Z = ((vec.Z < min.Z) ? min.Z : ((vec.Z > max.Z) ? max.Z : vec.Z));
			return vec;
		}

		// Token: 0x06003F6F RID: 16239 RVA: 0x000A818C File Offset: 0x000A638C
		public static void Clamp(ref Vector3 vec, ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
			result.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			result.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			result.Z = ((vec.Z < min.Z) ? min.Z : ((vec.Z > max.Z) ? max.Z : vec.Z));
		}

		// Token: 0x06003F70 RID: 16240 RVA: 0x000A8244 File Offset: 0x000A6444
		public static Vector3 Normalize(Vector3 vec)
		{
			float num = 1f / vec.Length;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			return vec;
		}

		// Token: 0x06003F71 RID: 16241 RVA: 0x000A8290 File Offset: 0x000A6490
		public static void Normalize(ref Vector3 vec, out Vector3 result)
		{
			float num = 1f / vec.Length;
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
		}

		// Token: 0x06003F72 RID: 16242 RVA: 0x000A82D4 File Offset: 0x000A64D4
		public static Vector3 NormalizeFast(Vector3 vec)
		{
			float num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z);
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			return vec;
		}

		// Token: 0x06003F73 RID: 16243 RVA: 0x000A8344 File Offset: 0x000A6544
		public static void NormalizeFast(ref Vector3 vec, out Vector3 result)
		{
			float num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z);
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
		}

		// Token: 0x06003F74 RID: 16244 RVA: 0x000A83AC File Offset: 0x000A65AC
		public static float Dot(Vector3 left, Vector3 right)
		{
			return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
		}

		// Token: 0x06003F75 RID: 16245 RVA: 0x000A83E0 File Offset: 0x000A65E0
		public static void Dot(ref Vector3 left, ref Vector3 right, out float result)
		{
			result = left.X * right.X + left.Y * right.Y + left.Z * right.Z;
		}

		// Token: 0x06003F76 RID: 16246 RVA: 0x000A8410 File Offset: 0x000A6610
		public static Vector3 Cross(Vector3 left, Vector3 right)
		{
			Vector3 result;
			Vector3.Cross(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06003F77 RID: 16247 RVA: 0x000A842C File Offset: 0x000A662C
		public static void Cross(ref Vector3 left, ref Vector3 right, out Vector3 result)
		{
			result = new Vector3(left.Y * right.Z - left.Z * right.Y, left.Z * right.X - left.X * right.Z, left.X * right.Y - left.Y * right.X);
		}

		// Token: 0x06003F78 RID: 16248 RVA: 0x000A8498 File Offset: 0x000A6698
		public static Vector3 Lerp(Vector3 a, Vector3 b, float blend)
		{
			a.X = blend * (b.X - a.X) + a.X;
			a.Y = blend * (b.Y - a.Y) + a.Y;
			a.Z = blend * (b.Z - a.Z) + a.Z;
			return a;
		}

		// Token: 0x06003F79 RID: 16249 RVA: 0x000A8508 File Offset: 0x000A6708
		public static void Lerp(ref Vector3 a, ref Vector3 b, float blend, out Vector3 result)
		{
			result.X = blend * (b.X - a.X) + a.X;
			result.Y = blend * (b.Y - a.Y) + a.Y;
			result.Z = blend * (b.Z - a.Z) + a.Z;
		}

		// Token: 0x06003F7A RID: 16250 RVA: 0x000A856C File Offset: 0x000A676C
		public static Vector3 BaryCentric(Vector3 a, Vector3 b, Vector3 c, float u, float v)
		{
			return a + u * (b - a) + v * (c - a);
		}

		// Token: 0x06003F7B RID: 16251 RVA: 0x000A8594 File Offset: 0x000A6794
		public static void BaryCentric(ref Vector3 a, ref Vector3 b, ref Vector3 c, float u, float v, out Vector3 result)
		{
			result = a;
			Vector3 vector = b;
			Vector3.Subtract(ref vector, ref a, out vector);
			Vector3.Multiply(ref vector, u, out vector);
			Vector3.Add(ref result, ref vector, out result);
			vector = c;
			Vector3.Subtract(ref vector, ref a, out vector);
			Vector3.Multiply(ref vector, v, out vector);
			Vector3.Add(ref result, ref vector, out result);
		}

		// Token: 0x06003F7C RID: 16252 RVA: 0x000A85FC File Offset: 0x000A67FC
		public static Vector3 TransformVector(Vector3 vec, Matrix4 mat)
		{
			Vector3 result;
			result.X = Vector3.Dot(vec, new Vector3(mat.Column0));
			result.Y = Vector3.Dot(vec, new Vector3(mat.Column1));
			result.Z = Vector3.Dot(vec, new Vector3(mat.Column2));
			return result;
		}

		// Token: 0x06003F7D RID: 16253 RVA: 0x000A8658 File Offset: 0x000A6858
		public static void TransformVector(ref Vector3 vec, ref Matrix4 mat, out Vector3 result)
		{
			result.X = vec.X * mat.Row0.X + vec.Y * mat.Row1.X + vec.Z * mat.Row2.X;
			result.Y = vec.X * mat.Row0.Y + vec.Y * mat.Row1.Y + vec.Z * mat.Row2.Y;
			result.Z = vec.X * mat.Row0.Z + vec.Y * mat.Row1.Z + vec.Z * mat.Row2.Z;
		}

		// Token: 0x06003F7E RID: 16254 RVA: 0x000A8720 File Offset: 0x000A6920
		public static Vector3 TransformNormal(Vector3 norm, Matrix4 mat)
		{
			mat.Invert();
			return Vector3.TransformNormalInverse(norm, mat);
		}

		// Token: 0x06003F7F RID: 16255 RVA: 0x000A8730 File Offset: 0x000A6930
		public static void TransformNormal(ref Vector3 norm, ref Matrix4 mat, out Vector3 result)
		{
			Matrix4 matrix = Matrix4.Invert(mat);
			Vector3.TransformNormalInverse(ref norm, ref matrix, out result);
		}

		// Token: 0x06003F80 RID: 16256 RVA: 0x000A8754 File Offset: 0x000A6954
		public static Vector3 TransformNormalInverse(Vector3 norm, Matrix4 invMat)
		{
			Vector3 result;
			result.X = Vector3.Dot(norm, new Vector3(invMat.Row0));
			result.Y = Vector3.Dot(norm, new Vector3(invMat.Row1));
			result.Z = Vector3.Dot(norm, new Vector3(invMat.Row2));
			return result;
		}

		// Token: 0x06003F81 RID: 16257 RVA: 0x000A87B0 File Offset: 0x000A69B0
		public static void TransformNormalInverse(ref Vector3 norm, ref Matrix4 invMat, out Vector3 result)
		{
			result.X = norm.X * invMat.Row0.X + norm.Y * invMat.Row0.Y + norm.Z * invMat.Row0.Z;
			result.Y = norm.X * invMat.Row1.X + norm.Y * invMat.Row1.Y + norm.Z * invMat.Row1.Z;
			result.Z = norm.X * invMat.Row2.X + norm.Y * invMat.Row2.Y + norm.Z * invMat.Row2.Z;
		}

		// Token: 0x06003F82 RID: 16258 RVA: 0x000A8878 File Offset: 0x000A6A78
		public static Vector3 TransformPosition(Vector3 pos, Matrix4 mat)
		{
			Vector3 result;
			result.X = Vector3.Dot(pos, new Vector3(mat.Column0)) + mat.Row3.X;
			result.Y = Vector3.Dot(pos, new Vector3(mat.Column1)) + mat.Row3.Y;
			result.Z = Vector3.Dot(pos, new Vector3(mat.Column2)) + mat.Row3.Z;
			return result;
		}

		// Token: 0x06003F83 RID: 16259 RVA: 0x000A88F8 File Offset: 0x000A6AF8
		public static void TransformPosition(ref Vector3 pos, ref Matrix4 mat, out Vector3 result)
		{
			result.X = pos.X * mat.Row0.X + pos.Y * mat.Row1.X + pos.Z * mat.Row2.X + mat.Row3.X;
			result.Y = pos.X * mat.Row0.Y + pos.Y * mat.Row1.Y + pos.Z * mat.Row2.Y + mat.Row3.Y;
			result.Z = pos.X * mat.Row0.Z + pos.Y * mat.Row1.Z + pos.Z * mat.Row2.Z + mat.Row3.Z;
		}

		// Token: 0x06003F84 RID: 16260 RVA: 0x000A89E4 File Offset: 0x000A6BE4
		public static Vector3 Transform(Vector3 vec, Matrix4 mat)
		{
			Vector3 result;
			Vector3.Transform(ref vec, ref mat, out result);
			return result;
		}

		// Token: 0x06003F85 RID: 16261 RVA: 0x000A8A00 File Offset: 0x000A6C00
		public static void Transform(ref Vector3 vec, ref Matrix4 mat, out Vector3 result)
		{
			Vector4 vector = new Vector4(vec.X, vec.Y, vec.Z, 1f);
			Vector4.Transform(ref vector, ref mat, out vector);
			result = vector.Xyz;
		}

		// Token: 0x06003F86 RID: 16262 RVA: 0x000A8A48 File Offset: 0x000A6C48
		public static Vector3 Transform(Vector3 vec, Quaternion quat)
		{
			Vector3 result;
			Vector3.Transform(ref vec, ref quat, out result);
			return result;
		}

		// Token: 0x06003F87 RID: 16263 RVA: 0x000A8A64 File Offset: 0x000A6C64
		public static void Transform(ref Vector3 vec, ref Quaternion quat, out Vector3 result)
		{
			Vector3 xyz = quat.Xyz;
			Vector3 vector;
			Vector3.Cross(ref xyz, ref vec, out vector);
			Vector3 vector2;
			Vector3.Multiply(ref vec, quat.W, out vector2);
			Vector3.Add(ref vector, ref vector2, out vector);
			Vector3.Cross(ref xyz, ref vector, out vector);
			Vector3.Multiply(ref vector, 2f, out vector);
			Vector3.Add(ref vec, ref vector, out result);
		}

		// Token: 0x06003F88 RID: 16264 RVA: 0x000A8AC0 File Offset: 0x000A6CC0
		public static Vector3 TransformPerspective(Vector3 vec, Matrix4 mat)
		{
			Vector3 result;
			Vector3.TransformPerspective(ref vec, ref mat, out result);
			return result;
		}

		// Token: 0x06003F89 RID: 16265 RVA: 0x000A8ADC File Offset: 0x000A6CDC
		public static void TransformPerspective(ref Vector3 vec, ref Matrix4 mat, out Vector3 result)
		{
			Vector4 vector = new Vector4(vec, 1f);
			Vector4.Transform(ref vector, ref mat, out vector);
			result.X = vector.X / vector.W;
			result.Y = vector.Y / vector.W;
			result.Z = vector.Z / vector.W;
		}

		// Token: 0x06003F8A RID: 16266 RVA: 0x000A8B4C File Offset: 0x000A6D4C
		public static float CalculateAngle(Vector3 first, Vector3 second)
		{
			return (float)Math.Acos((double)(Vector3.Dot(first, second) / (first.Length * second.Length)));
		}

		// Token: 0x06003F8B RID: 16267 RVA: 0x000A8B6C File Offset: 0x000A6D6C
		public static void CalculateAngle(ref Vector3 first, ref Vector3 second, out float result)
		{
			float num;
			Vector3.Dot(ref first, ref second, out num);
			result = (float)Math.Acos((double)(num / (first.Length * second.Length)));
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06003F8C RID: 16268 RVA: 0x000A8B9C File Offset: 0x000A6D9C
		// (set) Token: 0x06003F8D RID: 16269 RVA: 0x000A8BB0 File Offset: 0x000A6DB0
		[XmlIgnore]
		public Vector2 Xy
		{
			get
			{
				return new Vector2(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06003F8E RID: 16270 RVA: 0x000A8BCC File Offset: 0x000A6DCC
		// (set) Token: 0x06003F8F RID: 16271 RVA: 0x000A8BE0 File Offset: 0x000A6DE0
		[XmlIgnore]
		public Vector2 Xz
		{
			get
			{
				return new Vector2(this.X, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06003F90 RID: 16272 RVA: 0x000A8BFC File Offset: 0x000A6DFC
		// (set) Token: 0x06003F91 RID: 16273 RVA: 0x000A8C10 File Offset: 0x000A6E10
		[XmlIgnore]
		public Vector2 Yx
		{
			get
			{
				return new Vector2(this.Y, this.X);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06003F92 RID: 16274 RVA: 0x000A8C2C File Offset: 0x000A6E2C
		// (set) Token: 0x06003F93 RID: 16275 RVA: 0x000A8C40 File Offset: 0x000A6E40
		[XmlIgnore]
		public Vector2 Yz
		{
			get
			{
				return new Vector2(this.Y, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06003F94 RID: 16276 RVA: 0x000A8C5C File Offset: 0x000A6E5C
		// (set) Token: 0x06003F95 RID: 16277 RVA: 0x000A8C70 File Offset: 0x000A6E70
		[XmlIgnore]
		public Vector2 Zx
		{
			get
			{
				return new Vector2(this.Z, this.X);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06003F96 RID: 16278 RVA: 0x000A8C8C File Offset: 0x000A6E8C
		// (set) Token: 0x06003F97 RID: 16279 RVA: 0x000A8CA0 File Offset: 0x000A6EA0
		[XmlIgnore]
		public Vector2 Zy
		{
			get
			{
				return new Vector2(this.Z, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06003F98 RID: 16280 RVA: 0x000A8CBC File Offset: 0x000A6EBC
		// (set) Token: 0x06003F99 RID: 16281 RVA: 0x000A8CD8 File Offset: 0x000A6ED8
		[XmlIgnore]
		public Vector3 Xzy
		{
			get
			{
				return new Vector3(this.X, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06003F9A RID: 16282 RVA: 0x000A8D04 File Offset: 0x000A6F04
		// (set) Token: 0x06003F9B RID: 16283 RVA: 0x000A8D20 File Offset: 0x000A6F20
		[XmlIgnore]
		public Vector3 Yxz
		{
			get
			{
				return new Vector3(this.Y, this.X, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06003F9C RID: 16284 RVA: 0x000A8D4C File Offset: 0x000A6F4C
		// (set) Token: 0x06003F9D RID: 16285 RVA: 0x000A8D68 File Offset: 0x000A6F68
		[XmlIgnore]
		public Vector3 Yzx
		{
			get
			{
				return new Vector3(this.Y, this.Z, this.X);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06003F9E RID: 16286 RVA: 0x000A8D94 File Offset: 0x000A6F94
		// (set) Token: 0x06003F9F RID: 16287 RVA: 0x000A8DB0 File Offset: 0x000A6FB0
		[XmlIgnore]
		public Vector3 Zxy
		{
			get
			{
				return new Vector3(this.Z, this.X, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06003FA0 RID: 16288 RVA: 0x000A8DDC File Offset: 0x000A6FDC
		// (set) Token: 0x06003FA1 RID: 16289 RVA: 0x000A8DF8 File Offset: 0x000A6FF8
		[XmlIgnore]
		public Vector3 Zyx
		{
			get
			{
				return new Vector3(this.Z, this.Y, this.X);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x06003FA2 RID: 16290 RVA: 0x000A8E24 File Offset: 0x000A7024
		public static Vector3 operator +(Vector3 left, Vector3 right)
		{
			left.X += right.X;
			left.Y += right.Y;
			left.Z += right.Z;
			return left;
		}

		// Token: 0x06003FA3 RID: 16291 RVA: 0x000A8E74 File Offset: 0x000A7074
		public static Vector3 operator -(Vector3 left, Vector3 right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
			left.Z -= right.Z;
			return left;
		}

		// Token: 0x06003FA4 RID: 16292 RVA: 0x000A8EC4 File Offset: 0x000A70C4
		public static Vector3 operator -(Vector3 vec)
		{
			vec.X = -vec.X;
			vec.Y = -vec.Y;
			vec.Z = -vec.Z;
			return vec;
		}

		// Token: 0x06003FA5 RID: 16293 RVA: 0x000A8EF4 File Offset: 0x000A70F4
		public static Vector3 operator *(Vector3 vec, float scale)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			return vec;
		}

		// Token: 0x06003FA6 RID: 16294 RVA: 0x000A8F24 File Offset: 0x000A7124
		public static Vector3 operator *(float scale, Vector3 vec)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			return vec;
		}

		// Token: 0x06003FA7 RID: 16295 RVA: 0x000A8F54 File Offset: 0x000A7154
		public static Vector3 operator *(Vector3 vec, Vector3 scale)
		{
			vec.X *= scale.X;
			vec.Y *= scale.Y;
			vec.Z *= scale.Z;
			return vec;
		}

		// Token: 0x06003FA8 RID: 16296 RVA: 0x000A8FA4 File Offset: 0x000A71A4
		public static Vector3 operator /(Vector3 vec, float scale)
		{
			float num = 1f / scale;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			return vec;
		}

		// Token: 0x06003FA9 RID: 16297 RVA: 0x000A8FE8 File Offset: 0x000A71E8
		public static bool operator ==(Vector3 left, Vector3 right)
		{
			return left.Equals(right);
		}

		// Token: 0x06003FAA RID: 16298 RVA: 0x000A8FF4 File Offset: 0x000A71F4
		public static bool operator !=(Vector3 left, Vector3 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06003FAB RID: 16299 RVA: 0x000A9004 File Offset: 0x000A7204
		public override string ToString()
		{
			return string.Format("({0}{3} {1}{3} {2})", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				Vector3.listSeparator
			});
		}

		// Token: 0x06003FAC RID: 16300 RVA: 0x000A9058 File Offset: 0x000A7258
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
		}

		// Token: 0x06003FAD RID: 16301 RVA: 0x000A9080 File Offset: 0x000A7280
		public override bool Equals(object obj)
		{
			return obj is Vector3 && this.Equals((Vector3)obj);
		}

		// Token: 0x06003FAE RID: 16302 RVA: 0x000A9098 File Offset: 0x000A7298
		public bool Equals(Vector3 other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
		}

		// Token: 0x04004DFA RID: 19962
		public float X;

		// Token: 0x04004DFB RID: 19963
		public float Y;

		// Token: 0x04004DFC RID: 19964
		public float Z;

		// Token: 0x04004DFD RID: 19965
		public static readonly Vector3 UnitX = new Vector3(1f, 0f, 0f);

		// Token: 0x04004DFE RID: 19966
		public static readonly Vector3 UnitY = new Vector3(0f, 1f, 0f);

		// Token: 0x04004DFF RID: 19967
		public static readonly Vector3 UnitZ = new Vector3(0f, 0f, 1f);

		// Token: 0x04004E00 RID: 19968
		public static readonly Vector3 Zero = new Vector3(0f, 0f, 0f);

		// Token: 0x04004E01 RID: 19969
		public static readonly Vector3 One = new Vector3(1f, 1f, 1f);

		// Token: 0x04004E02 RID: 19970
		public static readonly int SizeInBytes = Marshal.SizeOf(default(Vector3));

		// Token: 0x04004E03 RID: 19971
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
