using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x0200052B RID: 1323
	[Serializable]
	public struct Vector4 : IEquatable<Vector4>
	{
		// Token: 0x06003E69 RID: 15977 RVA: 0x000A48F0 File Offset: 0x000A2AF0
		public Vector4(float value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
			this.W = value;
		}

		// Token: 0x06003E6A RID: 15978 RVA: 0x000A4910 File Offset: 0x000A2B10
		public Vector4(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x06003E6B RID: 15979 RVA: 0x000A4930 File Offset: 0x000A2B30
		public Vector4(Vector2 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = 0f;
			this.W = 0f;
		}

		// Token: 0x06003E6C RID: 15980 RVA: 0x000A4964 File Offset: 0x000A2B64
		public Vector4(Vector3 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
			this.W = 0f;
		}

		// Token: 0x06003E6D RID: 15981 RVA: 0x000A4998 File Offset: 0x000A2B98
		public Vector4(Vector3 v, float w)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
			this.W = w;
		}

		// Token: 0x06003E6E RID: 15982 RVA: 0x000A49C8 File Offset: 0x000A2BC8
		public Vector4(Vector4 v)
		{
			this.X = v.X;
			this.Y = v.Y;
			this.Z = v.Z;
			this.W = v.W;
		}

		// Token: 0x170002D3 RID: 723
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

		// Token: 0x06003E71 RID: 15985 RVA: 0x000A4AA4 File Offset: 0x000A2CA4
		[Obsolete("Use static Add() method instead.")]
		[CLSCompliant(false)]
		public void Add(Vector4 right)
		{
			this.X += right.X;
			this.Y += right.Y;
			this.Z += right.Z;
			this.W += right.W;
		}

		// Token: 0x06003E72 RID: 15986 RVA: 0x000A4B04 File Offset: 0x000A2D04
		[CLSCompliant(false)]
		[Obsolete("Use static Add() method instead.")]
		public void Add(ref Vector4 right)
		{
			this.X += right.X;
			this.Y += right.Y;
			this.Z += right.Z;
			this.W += right.W;
		}

		// Token: 0x06003E73 RID: 15987 RVA: 0x000A4B60 File Offset: 0x000A2D60
		[CLSCompliant(false)]
		[Obsolete("Use static Subtract() method instead.")]
		public void Sub(Vector4 right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
			this.Z -= right.Z;
			this.W -= right.W;
		}

		// Token: 0x06003E74 RID: 15988 RVA: 0x000A4BC0 File Offset: 0x000A2DC0
		[CLSCompliant(false)]
		[Obsolete("Use static Subtract() method instead.")]
		public void Sub(ref Vector4 right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
			this.Z -= right.Z;
			this.W -= right.W;
		}

		// Token: 0x06003E75 RID: 15989 RVA: 0x000A4C1C File Offset: 0x000A2E1C
		[Obsolete("Use static Multiply() method instead.")]
		public void Mult(float f)
		{
			this.X *= f;
			this.Y *= f;
			this.Z *= f;
			this.W *= f;
		}

		// Token: 0x06003E76 RID: 15990 RVA: 0x000A4C58 File Offset: 0x000A2E58
		[Obsolete("Use static Divide() method instead.")]
		public void Div(float f)
		{
			float num = 1f / f;
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
			this.W *= num;
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06003E77 RID: 15991 RVA: 0x000A4CA8 File Offset: 0x000A2EA8
		public float Length
		{
			get
			{
				return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06003E78 RID: 15992 RVA: 0x000A4CE8 File Offset: 0x000A2EE8
		public float LengthFast
		{
			get
			{
				return 1f / MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06003E79 RID: 15993 RVA: 0x000A4D38 File Offset: 0x000A2F38
		public float LengthSquared
		{
			get
			{
				return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
			}
		}

		// Token: 0x06003E7A RID: 15994 RVA: 0x000A4D74 File Offset: 0x000A2F74
		public Vector4 Normalized()
		{
			Vector4 result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06003E7B RID: 15995 RVA: 0x000A4D90 File Offset: 0x000A2F90
		public void Normalize()
		{
			float num = 1f / this.Length;
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
			this.W *= num;
		}

		// Token: 0x06003E7C RID: 15996 RVA: 0x000A4DE4 File Offset: 0x000A2FE4
		public void NormalizeFast()
		{
			float num = MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W);
			this.X *= num;
			this.Y *= num;
			this.Z *= num;
			this.W *= num;
		}

		// Token: 0x06003E7D RID: 15997 RVA: 0x000A4E68 File Offset: 0x000A3068
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(float sx, float sy, float sz, float sw)
		{
			this.X *= sx;
			this.Y *= sy;
			this.Z *= sz;
			this.W *= sw;
		}

		// Token: 0x06003E7E RID: 15998 RVA: 0x000A4EA4 File Offset: 0x000A30A4
		[CLSCompliant(false)]
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(Vector4 scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
			this.Z *= scale.Z;
			this.W *= scale.W;
		}

		// Token: 0x06003E7F RID: 15999 RVA: 0x000A4F04 File Offset: 0x000A3104
		[Obsolete("Use static Multiply() method instead.")]
		[CLSCompliant(false)]
		public void Scale(ref Vector4 scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
			this.Z *= scale.Z;
			this.W *= scale.W;
		}

		// Token: 0x06003E80 RID: 16000 RVA: 0x000A4F60 File Offset: 0x000A3160
		public static Vector4 Sub(Vector4 a, Vector4 b)
		{
			a.X -= b.X;
			a.Y -= b.Y;
			a.Z -= b.Z;
			a.W -= b.W;
			return a;
		}

		// Token: 0x06003E81 RID: 16001 RVA: 0x000A4FC4 File Offset: 0x000A31C4
		public static void Sub(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = a.X - b.X;
			result.Y = a.Y - b.Y;
			result.Z = a.Z - b.Z;
			result.W = a.W - b.W;
		}

		// Token: 0x06003E82 RID: 16002 RVA: 0x000A5020 File Offset: 0x000A3220
		public static Vector4 Mult(Vector4 a, float f)
		{
			a.X *= f;
			a.Y *= f;
			a.Z *= f;
			a.W *= f;
			return a;
		}

		// Token: 0x06003E83 RID: 16003 RVA: 0x000A5060 File Offset: 0x000A3260
		public static void Mult(ref Vector4 a, float f, out Vector4 result)
		{
			result.X = a.X * f;
			result.Y = a.Y * f;
			result.Z = a.Z * f;
			result.W = a.W * f;
		}

		// Token: 0x06003E84 RID: 16004 RVA: 0x000A509C File Offset: 0x000A329C
		public static Vector4 Div(Vector4 a, float f)
		{
			float num = 1f / f;
			a.X *= num;
			a.Y *= num;
			a.Z *= num;
			a.W *= num;
			return a;
		}

		// Token: 0x06003E85 RID: 16005 RVA: 0x000A50F0 File Offset: 0x000A32F0
		public static void Div(ref Vector4 a, float f, out Vector4 result)
		{
			float num = 1f / f;
			result.X = a.X * num;
			result.Y = a.Y * num;
			result.Z = a.Z * num;
			result.W = a.W * num;
		}

		// Token: 0x06003E86 RID: 16006 RVA: 0x000A5140 File Offset: 0x000A3340
		public static Vector4 Add(Vector4 a, Vector4 b)
		{
			Vector4.Add(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06003E87 RID: 16007 RVA: 0x000A5150 File Offset: 0x000A3350
		public static void Add(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result = new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
		}

		// Token: 0x06003E88 RID: 16008 RVA: 0x000A519C File Offset: 0x000A339C
		public static Vector4 Subtract(Vector4 a, Vector4 b)
		{
			Vector4.Subtract(ref a, ref b, out a);
			return a;
		}

		// Token: 0x06003E89 RID: 16009 RVA: 0x000A51AC File Offset: 0x000A33AC
		public static void Subtract(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result = new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
		}

		// Token: 0x06003E8A RID: 16010 RVA: 0x000A51F8 File Offset: 0x000A33F8
		public static Vector4 Multiply(Vector4 vector, float scale)
		{
			Vector4.Multiply(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06003E8B RID: 16011 RVA: 0x000A5208 File Offset: 0x000A3408
		public static void Multiply(ref Vector4 vector, float scale, out Vector4 result)
		{
			result = new Vector4(vector.X * scale, vector.Y * scale, vector.Z * scale, vector.W * scale);
		}

		// Token: 0x06003E8C RID: 16012 RVA: 0x000A5238 File Offset: 0x000A3438
		public static Vector4 Multiply(Vector4 vector, Vector4 scale)
		{
			Vector4.Multiply(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06003E8D RID: 16013 RVA: 0x000A5248 File Offset: 0x000A3448
		public static void Multiply(ref Vector4 vector, ref Vector4 scale, out Vector4 result)
		{
			result = new Vector4(vector.X * scale.X, vector.Y * scale.Y, vector.Z * scale.Z, vector.W * scale.W);
		}

		// Token: 0x06003E8E RID: 16014 RVA: 0x000A5294 File Offset: 0x000A3494
		public static Vector4 Divide(Vector4 vector, float scale)
		{
			Vector4.Divide(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06003E8F RID: 16015 RVA: 0x000A52A4 File Offset: 0x000A34A4
		public static void Divide(ref Vector4 vector, float scale, out Vector4 result)
		{
			Vector4.Multiply(ref vector, 1f / scale, out result);
		}

		// Token: 0x06003E90 RID: 16016 RVA: 0x000A52B4 File Offset: 0x000A34B4
		public static Vector4 Divide(Vector4 vector, Vector4 scale)
		{
			Vector4.Divide(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06003E91 RID: 16017 RVA: 0x000A52C4 File Offset: 0x000A34C4
		public static void Divide(ref Vector4 vector, ref Vector4 scale, out Vector4 result)
		{
			result = new Vector4(vector.X / scale.X, vector.Y / scale.Y, vector.Z / scale.Z, vector.W / scale.W);
		}

		// Token: 0x06003E92 RID: 16018 RVA: 0x000A5310 File Offset: 0x000A3510
		public static Vector4 Min(Vector4 a, Vector4 b)
		{
			a.X = ((a.X < b.X) ? a.X : b.X);
			a.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			a.Z = ((a.Z < b.Z) ? a.Z : b.Z);
			a.W = ((a.W < b.W) ? a.W : b.W);
			return a;
		}

		// Token: 0x06003E93 RID: 16019 RVA: 0x000A53BC File Offset: 0x000A35BC
		public static void Min(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = ((a.X < b.X) ? a.X : b.X);
			result.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			result.Z = ((a.Z < b.Z) ? a.Z : b.Z);
			result.W = ((a.W < b.W) ? a.W : b.W);
		}

		// Token: 0x06003E94 RID: 16020 RVA: 0x000A5454 File Offset: 0x000A3654
		public static Vector4 Max(Vector4 a, Vector4 b)
		{
			a.X = ((a.X > b.X) ? a.X : b.X);
			a.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			a.Z = ((a.Z > b.Z) ? a.Z : b.Z);
			a.W = ((a.W > b.W) ? a.W : b.W);
			return a;
		}

		// Token: 0x06003E95 RID: 16021 RVA: 0x000A5500 File Offset: 0x000A3700
		public static void Max(ref Vector4 a, ref Vector4 b, out Vector4 result)
		{
			result.X = ((a.X > b.X) ? a.X : b.X);
			result.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			result.Z = ((a.Z > b.Z) ? a.Z : b.Z);
			result.W = ((a.W > b.W) ? a.W : b.W);
		}

		// Token: 0x06003E96 RID: 16022 RVA: 0x000A5598 File Offset: 0x000A3798
		public static Vector4 Clamp(Vector4 vec, Vector4 min, Vector4 max)
		{
			vec.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			vec.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			vec.Z = ((vec.X < min.Z) ? min.Z : ((vec.Z > max.Z) ? max.Z : vec.Z));
			vec.W = ((vec.Y < min.W) ? min.W : ((vec.W > max.W) ? max.W : vec.W));
			return vec;
		}

		// Token: 0x06003E97 RID: 16023 RVA: 0x000A56A8 File Offset: 0x000A38A8
		public static void Clamp(ref Vector4 vec, ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			result.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			result.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			result.Z = ((vec.X < min.Z) ? min.Z : ((vec.Z > max.Z) ? max.Z : vec.Z));
			result.W = ((vec.Y < min.W) ? min.W : ((vec.W > max.W) ? max.W : vec.W));
		}

		// Token: 0x06003E98 RID: 16024 RVA: 0x000A5798 File Offset: 0x000A3998
		public static Vector4 Normalize(Vector4 vec)
		{
			float num = 1f / vec.Length;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			vec.W *= num;
			return vec;
		}

		// Token: 0x06003E99 RID: 16025 RVA: 0x000A57F0 File Offset: 0x000A39F0
		public static void Normalize(ref Vector4 vec, out Vector4 result)
		{
			float num = 1f / vec.Length;
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
			result.W = vec.W * num;
		}

		// Token: 0x06003E9A RID: 16026 RVA: 0x000A5844 File Offset: 0x000A3A44
		public static Vector4 NormalizeFast(Vector4 vec)
		{
			float num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z + vec.W * vec.W);
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			vec.W *= num;
			return vec;
		}

		// Token: 0x06003E9B RID: 16027 RVA: 0x000A58D4 File Offset: 0x000A3AD4
		public static void NormalizeFast(ref Vector4 vec, out Vector4 result)
		{
			float num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y + vec.Z * vec.Z + vec.W * vec.W);
			result.X = vec.X * num;
			result.Y = vec.Y * num;
			result.Z = vec.Z * num;
			result.W = vec.W * num;
		}

		// Token: 0x06003E9C RID: 16028 RVA: 0x000A5958 File Offset: 0x000A3B58
		public static float Dot(Vector4 left, Vector4 right)
		{
			return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		}

		// Token: 0x06003E9D RID: 16029 RVA: 0x000A59A4 File Offset: 0x000A3BA4
		public static void Dot(ref Vector4 left, ref Vector4 right, out float result)
		{
			result = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
		}

		// Token: 0x06003E9E RID: 16030 RVA: 0x000A59E0 File Offset: 0x000A3BE0
		public static Vector4 Lerp(Vector4 a, Vector4 b, float blend)
		{
			a.X = blend * (b.X - a.X) + a.X;
			a.Y = blend * (b.Y - a.Y) + a.Y;
			a.Z = blend * (b.Z - a.Z) + a.Z;
			a.W = blend * (b.W - a.W) + a.W;
			return a;
		}

		// Token: 0x06003E9F RID: 16031 RVA: 0x000A5A70 File Offset: 0x000A3C70
		public static void Lerp(ref Vector4 a, ref Vector4 b, float blend, out Vector4 result)
		{
			result.X = blend * (b.X - a.X) + a.X;
			result.Y = blend * (b.Y - a.Y) + a.Y;
			result.Z = blend * (b.Z - a.Z) + a.Z;
			result.W = blend * (b.W - a.W) + a.W;
		}

		// Token: 0x06003EA0 RID: 16032 RVA: 0x000A5AF0 File Offset: 0x000A3CF0
		public static Vector4 BaryCentric(Vector4 a, Vector4 b, Vector4 c, float u, float v)
		{
			return a + u * (b - a) + v * (c - a);
		}

		// Token: 0x06003EA1 RID: 16033 RVA: 0x000A5B18 File Offset: 0x000A3D18
		public static void BaryCentric(ref Vector4 a, ref Vector4 b, ref Vector4 c, float u, float v, out Vector4 result)
		{
			result = a;
			Vector4 vector = b;
			Vector4.Subtract(ref vector, ref a, out vector);
			Vector4.Multiply(ref vector, u, out vector);
			Vector4.Add(ref result, ref vector, out result);
			vector = c;
			Vector4.Subtract(ref vector, ref a, out vector);
			Vector4.Multiply(ref vector, v, out vector);
			Vector4.Add(ref result, ref vector, out result);
		}

		// Token: 0x06003EA2 RID: 16034 RVA: 0x000A5B80 File Offset: 0x000A3D80
		public static Vector4 Transform(Vector4 vec, Matrix4 mat)
		{
			Vector4 result;
			Vector4.Transform(ref vec, ref mat, out result);
			return result;
		}

		// Token: 0x06003EA3 RID: 16035 RVA: 0x000A5B9C File Offset: 0x000A3D9C
		public static void Transform(ref Vector4 vec, ref Matrix4 mat, out Vector4 result)
		{
			result = new Vector4(vec.X * mat.Row0.X + vec.Y * mat.Row1.X + vec.Z * mat.Row2.X + vec.W * mat.Row3.X, vec.X * mat.Row0.Y + vec.Y * mat.Row1.Y + vec.Z * mat.Row2.Y + vec.W * mat.Row3.Y, vec.X * mat.Row0.Z + vec.Y * mat.Row1.Z + vec.Z * mat.Row2.Z + vec.W * mat.Row3.Z, vec.X * mat.Row0.W + vec.Y * mat.Row1.W + vec.Z * mat.Row2.W + vec.W * mat.Row3.W);
		}

		// Token: 0x06003EA4 RID: 16036 RVA: 0x000A5CE0 File Offset: 0x000A3EE0
		public static Vector4 Transform(Vector4 vec, Quaternion quat)
		{
			Vector4 result;
			Vector4.Transform(ref vec, ref quat, out result);
			return result;
		}

		// Token: 0x06003EA5 RID: 16037 RVA: 0x000A5CFC File Offset: 0x000A3EFC
		public static void Transform(ref Vector4 vec, ref Quaternion quat, out Vector4 result)
		{
			Quaternion quaternion = new Quaternion(vec.X, vec.Y, vec.Z, vec.W);
			Quaternion quaternion2;
			Quaternion.Invert(ref quat, out quaternion2);
			Quaternion quaternion3;
			Quaternion.Multiply(ref quat, ref quaternion, out quaternion3);
			Quaternion.Multiply(ref quaternion3, ref quaternion2, out quaternion);
			result = new Vector4(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06003EA6 RID: 16038 RVA: 0x000A5D74 File Offset: 0x000A3F74
		// (set) Token: 0x06003EA7 RID: 16039 RVA: 0x000A5D88 File Offset: 0x000A3F88
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

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06003EA8 RID: 16040 RVA: 0x000A5DA4 File Offset: 0x000A3FA4
		// (set) Token: 0x06003EA9 RID: 16041 RVA: 0x000A5DB8 File Offset: 0x000A3FB8
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

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06003EAA RID: 16042 RVA: 0x000A5DD4 File Offset: 0x000A3FD4
		// (set) Token: 0x06003EAB RID: 16043 RVA: 0x000A5DE8 File Offset: 0x000A3FE8
		[XmlIgnore]
		public Vector2 Xw
		{
			get
			{
				return new Vector2(this.X, this.W);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06003EAC RID: 16044 RVA: 0x000A5E04 File Offset: 0x000A4004
		// (set) Token: 0x06003EAD RID: 16045 RVA: 0x000A5E18 File Offset: 0x000A4018
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

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06003EAE RID: 16046 RVA: 0x000A5E34 File Offset: 0x000A4034
		// (set) Token: 0x06003EAF RID: 16047 RVA: 0x000A5E48 File Offset: 0x000A4048
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

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06003EB0 RID: 16048 RVA: 0x000A5E64 File Offset: 0x000A4064
		// (set) Token: 0x06003EB1 RID: 16049 RVA: 0x000A5E78 File Offset: 0x000A4078
		[XmlIgnore]
		public Vector2 Yw
		{
			get
			{
				return new Vector2(this.Y, this.W);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06003EB2 RID: 16050 RVA: 0x000A5E94 File Offset: 0x000A4094
		// (set) Token: 0x06003EB3 RID: 16051 RVA: 0x000A5EA8 File Offset: 0x000A40A8
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

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06003EB4 RID: 16052 RVA: 0x000A5EC4 File Offset: 0x000A40C4
		// (set) Token: 0x06003EB5 RID: 16053 RVA: 0x000A5ED8 File Offset: 0x000A40D8
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

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06003EB6 RID: 16054 RVA: 0x000A5EF4 File Offset: 0x000A40F4
		// (set) Token: 0x06003EB7 RID: 16055 RVA: 0x000A5F08 File Offset: 0x000A4108
		[XmlIgnore]
		public Vector2 Zw
		{
			get
			{
				return new Vector2(this.Z, this.W);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06003EB8 RID: 16056 RVA: 0x000A5F24 File Offset: 0x000A4124
		// (set) Token: 0x06003EB9 RID: 16057 RVA: 0x000A5F38 File Offset: 0x000A4138
		[XmlIgnore]
		public Vector2 Wx
		{
			get
			{
				return new Vector2(this.W, this.X);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06003EBA RID: 16058 RVA: 0x000A5F54 File Offset: 0x000A4154
		// (set) Token: 0x06003EBB RID: 16059 RVA: 0x000A5F68 File Offset: 0x000A4168
		[XmlIgnore]
		public Vector2 Wy
		{
			get
			{
				return new Vector2(this.W, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06003EBC RID: 16060 RVA: 0x000A5F84 File Offset: 0x000A4184
		// (set) Token: 0x06003EBD RID: 16061 RVA: 0x000A5F98 File Offset: 0x000A4198
		[XmlIgnore]
		public Vector2 Wz
		{
			get
			{
				return new Vector2(this.W, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06003EBE RID: 16062 RVA: 0x000A5FB4 File Offset: 0x000A41B4
		// (set) Token: 0x06003EBF RID: 16063 RVA: 0x000A5FD0 File Offset: 0x000A41D0
		[XmlIgnore]
		public Vector3 Xyz
		{
			get
			{
				return new Vector3(this.X, this.Y, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06003EC0 RID: 16064 RVA: 0x000A5FFC File Offset: 0x000A41FC
		// (set) Token: 0x06003EC1 RID: 16065 RVA: 0x000A6018 File Offset: 0x000A4218
		[XmlIgnore]
		public Vector3 Xyw
		{
			get
			{
				return new Vector3(this.X, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06003EC2 RID: 16066 RVA: 0x000A6044 File Offset: 0x000A4244
		// (set) Token: 0x06003EC3 RID: 16067 RVA: 0x000A6060 File Offset: 0x000A4260
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

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06003EC4 RID: 16068 RVA: 0x000A608C File Offset: 0x000A428C
		// (set) Token: 0x06003EC5 RID: 16069 RVA: 0x000A60A8 File Offset: 0x000A42A8
		[XmlIgnore]
		public Vector3 Xzw
		{
			get
			{
				return new Vector3(this.X, this.Z, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06003EC6 RID: 16070 RVA: 0x000A60D4 File Offset: 0x000A42D4
		// (set) Token: 0x06003EC7 RID: 16071 RVA: 0x000A60F0 File Offset: 0x000A42F0
		[XmlIgnore]
		public Vector3 Xwy
		{
			get
			{
				return new Vector3(this.X, this.W, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06003EC8 RID: 16072 RVA: 0x000A611C File Offset: 0x000A431C
		// (set) Token: 0x06003EC9 RID: 16073 RVA: 0x000A6138 File Offset: 0x000A4338
		[XmlIgnore]
		public Vector3 Xwz
		{
			get
			{
				return new Vector3(this.X, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06003ECA RID: 16074 RVA: 0x000A6164 File Offset: 0x000A4364
		// (set) Token: 0x06003ECB RID: 16075 RVA: 0x000A6180 File Offset: 0x000A4380
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

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06003ECC RID: 16076 RVA: 0x000A61AC File Offset: 0x000A43AC
		// (set) Token: 0x06003ECD RID: 16077 RVA: 0x000A61C8 File Offset: 0x000A43C8
		[XmlIgnore]
		public Vector3 Yxw
		{
			get
			{
				return new Vector3(this.Y, this.X, this.W);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06003ECE RID: 16078 RVA: 0x000A61F4 File Offset: 0x000A43F4
		// (set) Token: 0x06003ECF RID: 16079 RVA: 0x000A6210 File Offset: 0x000A4410
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

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06003ED0 RID: 16080 RVA: 0x000A623C File Offset: 0x000A443C
		// (set) Token: 0x06003ED1 RID: 16081 RVA: 0x000A6258 File Offset: 0x000A4458
		[XmlIgnore]
		public Vector3 Yzw
		{
			get
			{
				return new Vector3(this.Y, this.Z, this.W);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06003ED2 RID: 16082 RVA: 0x000A6284 File Offset: 0x000A4484
		// (set) Token: 0x06003ED3 RID: 16083 RVA: 0x000A62A0 File Offset: 0x000A44A0
		[XmlIgnore]
		public Vector3 Ywx
		{
			get
			{
				return new Vector3(this.Y, this.W, this.X);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06003ED4 RID: 16084 RVA: 0x000A62CC File Offset: 0x000A44CC
		// (set) Token: 0x06003ED5 RID: 16085 RVA: 0x000A62E8 File Offset: 0x000A44E8
		[XmlIgnore]
		public Vector3 Ywz
		{
			get
			{
				return new Vector3(this.Y, this.W, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06003ED6 RID: 16086 RVA: 0x000A6314 File Offset: 0x000A4514
		// (set) Token: 0x06003ED7 RID: 16087 RVA: 0x000A6330 File Offset: 0x000A4530
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

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06003ED8 RID: 16088 RVA: 0x000A635C File Offset: 0x000A455C
		// (set) Token: 0x06003ED9 RID: 16089 RVA: 0x000A6378 File Offset: 0x000A4578
		[XmlIgnore]
		public Vector3 Zxw
		{
			get
			{
				return new Vector3(this.Z, this.X, this.W);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06003EDA RID: 16090 RVA: 0x000A63A4 File Offset: 0x000A45A4
		// (set) Token: 0x06003EDB RID: 16091 RVA: 0x000A63C0 File Offset: 0x000A45C0
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

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06003EDC RID: 16092 RVA: 0x000A63EC File Offset: 0x000A45EC
		// (set) Token: 0x06003EDD RID: 16093 RVA: 0x000A6408 File Offset: 0x000A4608
		[XmlIgnore]
		public Vector3 Zyw
		{
			get
			{
				return new Vector3(this.Z, this.Y, this.W);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06003EDE RID: 16094 RVA: 0x000A6434 File Offset: 0x000A4634
		// (set) Token: 0x06003EDF RID: 16095 RVA: 0x000A6450 File Offset: 0x000A4650
		[XmlIgnore]
		public Vector3 Zwx
		{
			get
			{
				return new Vector3(this.Z, this.W, this.X);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06003EE0 RID: 16096 RVA: 0x000A647C File Offset: 0x000A467C
		// (set) Token: 0x06003EE1 RID: 16097 RVA: 0x000A6498 File Offset: 0x000A4698
		[XmlIgnore]
		public Vector3 Zwy
		{
			get
			{
				return new Vector3(this.Z, this.W, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06003EE2 RID: 16098 RVA: 0x000A64C4 File Offset: 0x000A46C4
		// (set) Token: 0x06003EE3 RID: 16099 RVA: 0x000A64E0 File Offset: 0x000A46E0
		[XmlIgnore]
		public Vector3 Wxy
		{
			get
			{
				return new Vector3(this.W, this.X, this.Y);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06003EE4 RID: 16100 RVA: 0x000A650C File Offset: 0x000A470C
		// (set) Token: 0x06003EE5 RID: 16101 RVA: 0x000A6528 File Offset: 0x000A4728
		[XmlIgnore]
		public Vector3 Wxz
		{
			get
			{
				return new Vector3(this.W, this.X, this.Z);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06003EE6 RID: 16102 RVA: 0x000A6554 File Offset: 0x000A4754
		// (set) Token: 0x06003EE7 RID: 16103 RVA: 0x000A6570 File Offset: 0x000A4770
		[XmlIgnore]
		public Vector3 Wyx
		{
			get
			{
				return new Vector3(this.W, this.Y, this.X);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06003EE8 RID: 16104 RVA: 0x000A659C File Offset: 0x000A479C
		// (set) Token: 0x06003EE9 RID: 16105 RVA: 0x000A65B8 File Offset: 0x000A47B8
		[XmlIgnore]
		public Vector3 Wyz
		{
			get
			{
				return new Vector3(this.W, this.Y, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06003EEA RID: 16106 RVA: 0x000A65E4 File Offset: 0x000A47E4
		// (set) Token: 0x06003EEB RID: 16107 RVA: 0x000A6600 File Offset: 0x000A4800
		[XmlIgnore]
		public Vector3 Wzx
		{
			get
			{
				return new Vector3(this.W, this.Z, this.X);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06003EEC RID: 16108 RVA: 0x000A662C File Offset: 0x000A482C
		// (set) Token: 0x06003EED RID: 16109 RVA: 0x000A6648 File Offset: 0x000A4848
		[XmlIgnore]
		public Vector3 Wzy
		{
			get
			{
				return new Vector3(this.W, this.Z, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06003EEE RID: 16110 RVA: 0x000A6674 File Offset: 0x000A4874
		// (set) Token: 0x06003EEF RID: 16111 RVA: 0x000A6694 File Offset: 0x000A4894
		[XmlIgnore]
		public Vector4 Xywz
		{
			get
			{
				return new Vector4(this.X, this.Y, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06003EF0 RID: 16112 RVA: 0x000A66CC File Offset: 0x000A48CC
		// (set) Token: 0x06003EF1 RID: 16113 RVA: 0x000A66EC File Offset: 0x000A48EC
		[XmlIgnore]
		public Vector4 Xzyw
		{
			get
			{
				return new Vector4(this.X, this.Z, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06003EF2 RID: 16114 RVA: 0x000A6724 File Offset: 0x000A4924
		// (set) Token: 0x06003EF3 RID: 16115 RVA: 0x000A6744 File Offset: 0x000A4944
		[XmlIgnore]
		public Vector4 Xzwy
		{
			get
			{
				return new Vector4(this.X, this.Z, this.W, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.W = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06003EF4 RID: 16116 RVA: 0x000A677C File Offset: 0x000A497C
		// (set) Token: 0x06003EF5 RID: 16117 RVA: 0x000A679C File Offset: 0x000A499C
		[XmlIgnore]
		public Vector4 Xwyz
		{
			get
			{
				return new Vector4(this.X, this.W, this.Y, this.Z);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Y = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06003EF6 RID: 16118 RVA: 0x000A67D4 File Offset: 0x000A49D4
		// (set) Token: 0x06003EF7 RID: 16119 RVA: 0x000A67F4 File Offset: 0x000A49F4
		[XmlIgnore]
		public Vector4 Xwzy
		{
			get
			{
				return new Vector4(this.X, this.W, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06003EF8 RID: 16120 RVA: 0x000A682C File Offset: 0x000A4A2C
		// (set) Token: 0x06003EF9 RID: 16121 RVA: 0x000A684C File Offset: 0x000A4A4C
		[XmlIgnore]
		public Vector4 Yxzw
		{
			get
			{
				return new Vector4(this.Y, this.X, this.Z, this.W);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.Z = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06003EFA RID: 16122 RVA: 0x000A6884 File Offset: 0x000A4A84
		// (set) Token: 0x06003EFB RID: 16123 RVA: 0x000A68A4 File Offset: 0x000A4AA4
		[XmlIgnore]
		public Vector4 Yxwz
		{
			get
			{
				return new Vector4(this.Y, this.X, this.W, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06003EFC RID: 16124 RVA: 0x000A68DC File Offset: 0x000A4ADC
		// (set) Token: 0x06003EFD RID: 16125 RVA: 0x000A68FC File Offset: 0x000A4AFC
		[XmlIgnore]
		public Vector4 Yyzw
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.Z, this.W);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06003EFE RID: 16126 RVA: 0x000A6934 File Offset: 0x000A4B34
		// (set) Token: 0x06003EFF RID: 16127 RVA: 0x000A6954 File Offset: 0x000A4B54
		[XmlIgnore]
		public Vector4 Yywz
		{
			get
			{
				return new Vector4(this.Y, this.Y, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06003F00 RID: 16128 RVA: 0x000A698C File Offset: 0x000A4B8C
		// (set) Token: 0x06003F01 RID: 16129 RVA: 0x000A69AC File Offset: 0x000A4BAC
		[XmlIgnore]
		public Vector4 Yzxw
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.X, this.W);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.X = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06003F02 RID: 16130 RVA: 0x000A69E4 File Offset: 0x000A4BE4
		// (set) Token: 0x06003F03 RID: 16131 RVA: 0x000A6A04 File Offset: 0x000A4C04
		[XmlIgnore]
		public Vector4 Yzwx
		{
			get
			{
				return new Vector4(this.Y, this.Z, this.W, this.X);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.W = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06003F04 RID: 16132 RVA: 0x000A6A3C File Offset: 0x000A4C3C
		// (set) Token: 0x06003F05 RID: 16133 RVA: 0x000A6A5C File Offset: 0x000A4C5C
		[XmlIgnore]
		public Vector4 Ywxz
		{
			get
			{
				return new Vector4(this.Y, this.W, this.X, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.X = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06003F06 RID: 16134 RVA: 0x000A6A94 File Offset: 0x000A4C94
		// (set) Token: 0x06003F07 RID: 16135 RVA: 0x000A6AB4 File Offset: 0x000A4CB4
		[XmlIgnore]
		public Vector4 Ywzx
		{
			get
			{
				return new Vector4(this.Y, this.W, this.Z, this.X);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06003F08 RID: 16136 RVA: 0x000A6AEC File Offset: 0x000A4CEC
		// (set) Token: 0x06003F09 RID: 16137 RVA: 0x000A6B0C File Offset: 0x000A4D0C
		[XmlIgnore]
		public Vector4 Zxyw
		{
			get
			{
				return new Vector4(this.Z, this.X, this.Y, this.W);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06003F0A RID: 16138 RVA: 0x000A6B44 File Offset: 0x000A4D44
		// (set) Token: 0x06003F0B RID: 16139 RVA: 0x000A6B64 File Offset: 0x000A4D64
		[XmlIgnore]
		public Vector4 Zxwy
		{
			get
			{
				return new Vector4(this.Z, this.X, this.W, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.W = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06003F0C RID: 16140 RVA: 0x000A6B9C File Offset: 0x000A4D9C
		// (set) Token: 0x06003F0D RID: 16141 RVA: 0x000A6BBC File Offset: 0x000A4DBC
		[XmlIgnore]
		public Vector4 Zyxw
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.X, this.W);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.X = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06003F0E RID: 16142 RVA: 0x000A6BF4 File Offset: 0x000A4DF4
		// (set) Token: 0x06003F0F RID: 16143 RVA: 0x000A6C14 File Offset: 0x000A4E14
		[XmlIgnore]
		public Vector4 Zywx
		{
			get
			{
				return new Vector4(this.Z, this.Y, this.W, this.X);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06003F10 RID: 16144 RVA: 0x000A6C4C File Offset: 0x000A4E4C
		// (set) Token: 0x06003F11 RID: 16145 RVA: 0x000A6C6C File Offset: 0x000A4E6C
		[XmlIgnore]
		public Vector4 Zwxy
		{
			get
			{
				return new Vector4(this.Z, this.W, this.X, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.X = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06003F12 RID: 16146 RVA: 0x000A6CA4 File Offset: 0x000A4EA4
		// (set) Token: 0x06003F13 RID: 16147 RVA: 0x000A6CC4 File Offset: 0x000A4EC4
		[XmlIgnore]
		public Vector4 Zwyx
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Y, this.X);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.Y = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06003F14 RID: 16148 RVA: 0x000A6CFC File Offset: 0x000A4EFC
		// (set) Token: 0x06003F15 RID: 16149 RVA: 0x000A6D1C File Offset: 0x000A4F1C
		[XmlIgnore]
		public Vector4 Zwzy
		{
			get
			{
				return new Vector4(this.Z, this.W, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06003F16 RID: 16150 RVA: 0x000A6D54 File Offset: 0x000A4F54
		// (set) Token: 0x06003F17 RID: 16151 RVA: 0x000A6D74 File Offset: 0x000A4F74
		[XmlIgnore]
		public Vector4 Wxyz
		{
			get
			{
				return new Vector4(this.W, this.X, this.Y, this.Z);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Y = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06003F18 RID: 16152 RVA: 0x000A6DAC File Offset: 0x000A4FAC
		// (set) Token: 0x06003F19 RID: 16153 RVA: 0x000A6DCC File Offset: 0x000A4FCC
		[XmlIgnore]
		public Vector4 Wxzy
		{
			get
			{
				return new Vector4(this.W, this.X, this.Z, this.Y);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06003F1A RID: 16154 RVA: 0x000A6E04 File Offset: 0x000A5004
		// (set) Token: 0x06003F1B RID: 16155 RVA: 0x000A6E24 File Offset: 0x000A5024
		[XmlIgnore]
		public Vector4 Wyxz
		{
			get
			{
				return new Vector4(this.W, this.Y, this.X, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.X = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06003F1C RID: 16156 RVA: 0x000A6E5C File Offset: 0x000A505C
		// (set) Token: 0x06003F1D RID: 16157 RVA: 0x000A6E7C File Offset: 0x000A507C
		[XmlIgnore]
		public Vector4 Wyzx
		{
			get
			{
				return new Vector4(this.W, this.Y, this.Z, this.X);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06003F1E RID: 16158 RVA: 0x000A6EB4 File Offset: 0x000A50B4
		// (set) Token: 0x06003F1F RID: 16159 RVA: 0x000A6ED4 File Offset: 0x000A50D4
		[XmlIgnore]
		public Vector4 Wzxy
		{
			get
			{
				return new Vector4(this.W, this.Z, this.X, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.X = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06003F20 RID: 16160 RVA: 0x000A6F0C File Offset: 0x000A510C
		// (set) Token: 0x06003F21 RID: 16161 RVA: 0x000A6F2C File Offset: 0x000A512C
		[XmlIgnore]
		public Vector4 Wzyx
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Y, this.X);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06003F22 RID: 16162 RVA: 0x000A6F64 File Offset: 0x000A5164
		// (set) Token: 0x06003F23 RID: 16163 RVA: 0x000A6F84 File Offset: 0x000A5184
		[XmlIgnore]
		public Vector4 Wzyw
		{
			get
			{
				return new Vector4(this.W, this.Z, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x06003F24 RID: 16164 RVA: 0x000A6FBC File Offset: 0x000A51BC
		public static Vector4 operator +(Vector4 left, Vector4 right)
		{
			left.X += right.X;
			left.Y += right.Y;
			left.Z += right.Z;
			left.W += right.W;
			return left;
		}

		// Token: 0x06003F25 RID: 16165 RVA: 0x000A7020 File Offset: 0x000A5220
		public static Vector4 operator -(Vector4 left, Vector4 right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
			left.Z -= right.Z;
			left.W -= right.W;
			return left;
		}

		// Token: 0x06003F26 RID: 16166 RVA: 0x000A7084 File Offset: 0x000A5284
		public static Vector4 operator -(Vector4 vec)
		{
			vec.X = -vec.X;
			vec.Y = -vec.Y;
			vec.Z = -vec.Z;
			vec.W = -vec.W;
			return vec;
		}

		// Token: 0x06003F27 RID: 16167 RVA: 0x000A70C4 File Offset: 0x000A52C4
		public static Vector4 operator *(Vector4 vec, float scale)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			vec.W *= scale;
			return vec;
		}

		// Token: 0x06003F28 RID: 16168 RVA: 0x000A7104 File Offset: 0x000A5304
		public static Vector4 operator *(float scale, Vector4 vec)
		{
			vec.X *= scale;
			vec.Y *= scale;
			vec.Z *= scale;
			vec.W *= scale;
			return vec;
		}

		// Token: 0x06003F29 RID: 16169 RVA: 0x000A7144 File Offset: 0x000A5344
		public static Vector4 operator *(Vector4 vec, Vector4 scale)
		{
			vec.X *= scale.X;
			vec.Y *= scale.Y;
			vec.Z *= scale.Z;
			vec.W *= scale.W;
			return vec;
		}

		// Token: 0x06003F2A RID: 16170 RVA: 0x000A71A8 File Offset: 0x000A53A8
		public static Vector4 operator /(Vector4 vec, float scale)
		{
			float num = 1f / scale;
			vec.X *= num;
			vec.Y *= num;
			vec.Z *= num;
			vec.W *= num;
			return vec;
		}

		// Token: 0x06003F2B RID: 16171 RVA: 0x000A71FC File Offset: 0x000A53FC
		public static bool operator ==(Vector4 left, Vector4 right)
		{
			return left.Equals(right);
		}

		// Token: 0x06003F2C RID: 16172 RVA: 0x000A7208 File Offset: 0x000A5408
		public static bool operator !=(Vector4 left, Vector4 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06003F2D RID: 16173 RVA: 0x000A7218 File Offset: 0x000A5418
		[CLSCompliant(false)]
		public unsafe static explicit operator float*(Vector4 v)
		{
			return &v.X;
		}

		// Token: 0x06003F2E RID: 16174 RVA: 0x000A7224 File Offset: 0x000A5424
		public unsafe static explicit operator IntPtr(Vector4 v)
		{
			return (IntPtr)((void*)(&v.X));
		}

		// Token: 0x06003F2F RID: 16175 RVA: 0x000A7234 File Offset: 0x000A5434
		public override string ToString()
		{
			return string.Format("({0}{4} {1}{4} {2}{4} {3})", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W,
				Vector4.listSeparator
			});
		}

		// Token: 0x06003F30 RID: 16176 RVA: 0x000A7294 File Offset: 0x000A5494
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode() ^ this.W.GetHashCode();
		}

		// Token: 0x06003F31 RID: 16177 RVA: 0x000A72C8 File Offset: 0x000A54C8
		public override bool Equals(object obj)
		{
			return obj is Vector4 && this.Equals((Vector4)obj);
		}

		// Token: 0x06003F32 RID: 16178 RVA: 0x000A72E0 File Offset: 0x000A54E0
		public bool Equals(Vector4 other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z && this.W == other.W;
		}

		// Token: 0x04004DEC RID: 19948
		public float X;

		// Token: 0x04004DED RID: 19949
		public float Y;

		// Token: 0x04004DEE RID: 19950
		public float Z;

		// Token: 0x04004DEF RID: 19951
		public float W;

		// Token: 0x04004DF0 RID: 19952
		public static readonly Vector4 UnitX = new Vector4(1f, 0f, 0f, 0f);

		// Token: 0x04004DF1 RID: 19953
		public static readonly Vector4 UnitY = new Vector4(0f, 1f, 0f, 0f);

		// Token: 0x04004DF2 RID: 19954
		public static readonly Vector4 UnitZ = new Vector4(0f, 0f, 1f, 0f);

		// Token: 0x04004DF3 RID: 19955
		public static readonly Vector4 UnitW = new Vector4(0f, 0f, 0f, 1f);

		// Token: 0x04004DF4 RID: 19956
		public static readonly Vector4 Zero = new Vector4(0f, 0f, 0f, 0f);

		// Token: 0x04004DF5 RID: 19957
		public static readonly Vector4 One = new Vector4(1f, 1f, 1f, 1f);

		// Token: 0x04004DF6 RID: 19958
		public static readonly int SizeInBytes = Marshal.SizeOf(default(Vector4));

		// Token: 0x04004DF7 RID: 19959
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
