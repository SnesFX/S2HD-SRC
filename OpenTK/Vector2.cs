using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x02000537 RID: 1335
	[Serializable]
	public struct Vector2 : IEquatable<Vector2>
	{
		// Token: 0x0600423E RID: 16958 RVA: 0x000B3140 File Offset: 0x000B1340
		public Vector2(float value)
		{
			this.X = value;
			this.Y = value;
		}

		// Token: 0x0600423F RID: 16959 RVA: 0x000B3150 File Offset: 0x000B1350
		public Vector2(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06004240 RID: 16960 RVA: 0x000B3160 File Offset: 0x000B1360
		[Obsolete]
		public Vector2(Vector2 v)
		{
			this.X = v.X;
			this.Y = v.Y;
		}

		// Token: 0x06004241 RID: 16961 RVA: 0x000B317C File Offset: 0x000B137C
		[Obsolete]
		public Vector2(Vector3 v)
		{
			this.X = v.X;
			this.Y = v.Y;
		}

		// Token: 0x06004242 RID: 16962 RVA: 0x000B3198 File Offset: 0x000B1398
		[Obsolete]
		public Vector2(Vector4 v)
		{
			this.X = v.X;
			this.Y = v.Y;
		}

		// Token: 0x170003B1 RID: 945
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

		// Token: 0x06004245 RID: 16965 RVA: 0x000B3210 File Offset: 0x000B1410
		[Obsolete("Use static Add() method instead.")]
		[CLSCompliant(false)]
		public void Add(Vector2 right)
		{
			this.X += right.X;
			this.Y += right.Y;
		}

		// Token: 0x06004246 RID: 16966 RVA: 0x000B323C File Offset: 0x000B143C
		[Obsolete("Use static Add() method instead.")]
		[CLSCompliant(false)]
		public void Add(ref Vector2 right)
		{
			this.X += right.X;
			this.Y += right.Y;
		}

		// Token: 0x06004247 RID: 16967 RVA: 0x000B3264 File Offset: 0x000B1464
		[Obsolete("Use static Subtract() method instead.")]
		[CLSCompliant(false)]
		public void Sub(Vector2 right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
		}

		// Token: 0x06004248 RID: 16968 RVA: 0x000B3290 File Offset: 0x000B1490
		[CLSCompliant(false)]
		[Obsolete("Use static Subtract() method instead.")]
		public void Sub(ref Vector2 right)
		{
			this.X -= right.X;
			this.Y -= right.Y;
		}

		// Token: 0x06004249 RID: 16969 RVA: 0x000B32B8 File Offset: 0x000B14B8
		[Obsolete("Use static Multiply() method instead.")]
		public void Mult(float f)
		{
			this.X *= f;
			this.Y *= f;
		}

		// Token: 0x0600424A RID: 16970 RVA: 0x000B32D8 File Offset: 0x000B14D8
		[Obsolete("Use static Divide() method instead.")]
		public void Div(float f)
		{
			float num = 1f / f;
			this.X *= num;
			this.Y *= num;
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x0600424B RID: 16971 RVA: 0x000B330C File Offset: 0x000B150C
		public float Length
		{
			get
			{
				return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x0600424C RID: 16972 RVA: 0x000B3330 File Offset: 0x000B1530
		public float LengthFast
		{
			get
			{
				return 1f / MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y);
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x0600424D RID: 16973 RVA: 0x000B3358 File Offset: 0x000B1558
		public float LengthSquared
		{
			get
			{
				return this.X * this.X + this.Y * this.Y;
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x0600424E RID: 16974 RVA: 0x000B3378 File Offset: 0x000B1578
		public Vector2 PerpendicularRight
		{
			get
			{
				return new Vector2(this.Y, -this.X);
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x0600424F RID: 16975 RVA: 0x000B338C File Offset: 0x000B158C
		public Vector2 PerpendicularLeft
		{
			get
			{
				return new Vector2(-this.Y, this.X);
			}
		}

		// Token: 0x06004250 RID: 16976 RVA: 0x000B33A0 File Offset: 0x000B15A0
		public Vector2 Normalized()
		{
			Vector2 result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06004251 RID: 16977 RVA: 0x000B33BC File Offset: 0x000B15BC
		public void Normalize()
		{
			float num = 1f / this.Length;
			this.X *= num;
			this.Y *= num;
		}

		// Token: 0x06004252 RID: 16978 RVA: 0x000B33F4 File Offset: 0x000B15F4
		public void NormalizeFast()
		{
			float num = MathHelper.InverseSqrtFast(this.X * this.X + this.Y * this.Y);
			this.X *= num;
			this.Y *= num;
		}

		// Token: 0x06004253 RID: 16979 RVA: 0x000B3440 File Offset: 0x000B1640
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(float sx, float sy)
		{
			this.X *= sx;
			this.Y *= sy;
		}

		// Token: 0x06004254 RID: 16980 RVA: 0x000B3460 File Offset: 0x000B1660
		[CLSCompliant(false)]
		[Obsolete("Use static Multiply() method instead.")]
		public void Scale(Vector2 scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
		}

		// Token: 0x06004255 RID: 16981 RVA: 0x000B348C File Offset: 0x000B168C
		[Obsolete("Use static Multiply() method instead.")]
		[CLSCompliant(false)]
		public void Scale(ref Vector2 scale)
		{
			this.X *= scale.X;
			this.Y *= scale.Y;
		}

		// Token: 0x06004256 RID: 16982 RVA: 0x000B34B4 File Offset: 0x000B16B4
		[Obsolete("Use static Subtract() method instead.")]
		public static Vector2 Sub(Vector2 a, Vector2 b)
		{
			a.X -= b.X;
			a.Y -= b.Y;
			return a;
		}

		// Token: 0x06004257 RID: 16983 RVA: 0x000B34E4 File Offset: 0x000B16E4
		[Obsolete("Use static Subtract() method instead.")]
		public static void Sub(ref Vector2 a, ref Vector2 b, out Vector2 result)
		{
			result.X = a.X - b.X;
			result.Y = a.Y - b.Y;
		}

		// Token: 0x06004258 RID: 16984 RVA: 0x000B350C File Offset: 0x000B170C
		[Obsolete("Use static Multiply() method instead.")]
		public static Vector2 Mult(Vector2 a, float f)
		{
			a.X *= f;
			a.Y *= f;
			return a;
		}

		// Token: 0x06004259 RID: 16985 RVA: 0x000B3530 File Offset: 0x000B1730
		[Obsolete("Use static Multiply() method instead.")]
		public static void Mult(ref Vector2 a, float f, out Vector2 result)
		{
			result.X = a.X * f;
			result.Y = a.Y * f;
		}

		// Token: 0x0600425A RID: 16986 RVA: 0x000B3550 File Offset: 0x000B1750
		[Obsolete("Use static Divide() method instead.")]
		public static Vector2 Div(Vector2 a, float f)
		{
			float num = 1f / f;
			a.X *= num;
			a.Y *= num;
			return a;
		}

		// Token: 0x0600425B RID: 16987 RVA: 0x000B3584 File Offset: 0x000B1784
		[Obsolete("Use static Divide() method instead.")]
		public static void Div(ref Vector2 a, float f, out Vector2 result)
		{
			float num = 1f / f;
			result.X = a.X * num;
			result.Y = a.Y * num;
		}

		// Token: 0x0600425C RID: 16988 RVA: 0x000B35B8 File Offset: 0x000B17B8
		public static Vector2 Add(Vector2 a, Vector2 b)
		{
			Vector2.Add(ref a, ref b, out a);
			return a;
		}

		// Token: 0x0600425D RID: 16989 RVA: 0x000B35C8 File Offset: 0x000B17C8
		public static void Add(ref Vector2 a, ref Vector2 b, out Vector2 result)
		{
			result = new Vector2(a.X + b.X, a.Y + b.Y);
		}

		// Token: 0x0600425E RID: 16990 RVA: 0x000B35F0 File Offset: 0x000B17F0
		public static Vector2 Subtract(Vector2 a, Vector2 b)
		{
			Vector2.Subtract(ref a, ref b, out a);
			return a;
		}

		// Token: 0x0600425F RID: 16991 RVA: 0x000B3600 File Offset: 0x000B1800
		public static void Subtract(ref Vector2 a, ref Vector2 b, out Vector2 result)
		{
			result = new Vector2(a.X - b.X, a.Y - b.Y);
		}

		// Token: 0x06004260 RID: 16992 RVA: 0x000B3628 File Offset: 0x000B1828
		public static Vector2 Multiply(Vector2 vector, float scale)
		{
			Vector2.Multiply(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06004261 RID: 16993 RVA: 0x000B3638 File Offset: 0x000B1838
		public static void Multiply(ref Vector2 vector, float scale, out Vector2 result)
		{
			result = new Vector2(vector.X * scale, vector.Y * scale);
		}

		// Token: 0x06004262 RID: 16994 RVA: 0x000B3658 File Offset: 0x000B1858
		public static Vector2 Multiply(Vector2 vector, Vector2 scale)
		{
			Vector2.Multiply(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06004263 RID: 16995 RVA: 0x000B3668 File Offset: 0x000B1868
		public static void Multiply(ref Vector2 vector, ref Vector2 scale, out Vector2 result)
		{
			result = new Vector2(vector.X * scale.X, vector.Y * scale.Y);
		}

		// Token: 0x06004264 RID: 16996 RVA: 0x000B3690 File Offset: 0x000B1890
		public static Vector2 Divide(Vector2 vector, float scale)
		{
			Vector2.Divide(ref vector, scale, out vector);
			return vector;
		}

		// Token: 0x06004265 RID: 16997 RVA: 0x000B36A0 File Offset: 0x000B18A0
		public static void Divide(ref Vector2 vector, float scale, out Vector2 result)
		{
			Vector2.Multiply(ref vector, 1f / scale, out result);
		}

		// Token: 0x06004266 RID: 16998 RVA: 0x000B36B0 File Offset: 0x000B18B0
		public static Vector2 Divide(Vector2 vector, Vector2 scale)
		{
			Vector2.Divide(ref vector, ref scale, out vector);
			return vector;
		}

		// Token: 0x06004267 RID: 16999 RVA: 0x000B36C0 File Offset: 0x000B18C0
		public static void Divide(ref Vector2 vector, ref Vector2 scale, out Vector2 result)
		{
			result = new Vector2(vector.X / scale.X, vector.Y / scale.Y);
		}

		// Token: 0x06004268 RID: 17000 RVA: 0x000B36E8 File Offset: 0x000B18E8
		public static Vector2 ComponentMin(Vector2 a, Vector2 b)
		{
			a.X = ((a.X < b.X) ? a.X : b.X);
			a.Y = ((a.Y < b.Y) ? a.Y : b.Y);
			return a;
		}

		// Token: 0x06004269 RID: 17001 RVA: 0x000B3744 File Offset: 0x000B1944
		public static void ComponentMin(ref Vector2 a, ref Vector2 b, out Vector2 result)
		{
			result.X = ((a.X < b.X) ? a.X : b.X);
			result.Y = ((a.Y < b.Y) ? a.Y : b.Y);
		}

		// Token: 0x0600426A RID: 17002 RVA: 0x000B3798 File Offset: 0x000B1998
		public static Vector2 ComponentMax(Vector2 a, Vector2 b)
		{
			a.X = ((a.X > b.X) ? a.X : b.X);
			a.Y = ((a.Y > b.Y) ? a.Y : b.Y);
			return a;
		}

		// Token: 0x0600426B RID: 17003 RVA: 0x000B37F4 File Offset: 0x000B19F4
		public static void ComponentMax(ref Vector2 a, ref Vector2 b, out Vector2 result)
		{
			result.X = ((a.X > b.X) ? a.X : b.X);
			result.Y = ((a.Y > b.Y) ? a.Y : b.Y);
		}

		// Token: 0x0600426C RID: 17004 RVA: 0x000B3848 File Offset: 0x000B1A48
		public static Vector2 Min(Vector2 left, Vector2 right)
		{
			if (left.LengthSquared >= right.LengthSquared)
			{
				return right;
			}
			return left;
		}

		// Token: 0x0600426D RID: 17005 RVA: 0x000B3860 File Offset: 0x000B1A60
		public static Vector2 Max(Vector2 left, Vector2 right)
		{
			if (left.LengthSquared < right.LengthSquared)
			{
				return right;
			}
			return left;
		}

		// Token: 0x0600426E RID: 17006 RVA: 0x000B3878 File Offset: 0x000B1A78
		public static Vector2 Clamp(Vector2 vec, Vector2 min, Vector2 max)
		{
			vec.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			vec.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
			return vec;
		}

		// Token: 0x0600426F RID: 17007 RVA: 0x000B3908 File Offset: 0x000B1B08
		public static void Clamp(ref Vector2 vec, ref Vector2 min, ref Vector2 max, out Vector2 result)
		{
			result.X = ((vec.X < min.X) ? min.X : ((vec.X > max.X) ? max.X : vec.X));
			result.Y = ((vec.Y < min.Y) ? min.Y : ((vec.Y > max.Y) ? max.Y : vec.Y));
		}

		// Token: 0x06004270 RID: 17008 RVA: 0x000B3988 File Offset: 0x000B1B88
		public static Vector2 Normalize(Vector2 vec)
		{
			float num = 1f / vec.Length;
			vec.X *= num;
			vec.Y *= num;
			return vec;
		}

		// Token: 0x06004271 RID: 17009 RVA: 0x000B39C4 File Offset: 0x000B1BC4
		public static void Normalize(ref Vector2 vec, out Vector2 result)
		{
			float num = 1f / vec.Length;
			result.X = vec.X * num;
			result.Y = vec.Y * num;
		}

		// Token: 0x06004272 RID: 17010 RVA: 0x000B39FC File Offset: 0x000B1BFC
		public static Vector2 NormalizeFast(Vector2 vec)
		{
			float num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y);
			vec.X *= num;
			vec.Y *= num;
			return vec;
		}

		// Token: 0x06004273 RID: 17011 RVA: 0x000B3A50 File Offset: 0x000B1C50
		public static void NormalizeFast(ref Vector2 vec, out Vector2 result)
		{
			float num = MathHelper.InverseSqrtFast(vec.X * vec.X + vec.Y * vec.Y);
			result.X = vec.X * num;
			result.Y = vec.Y * num;
		}

		// Token: 0x06004274 RID: 17012 RVA: 0x000B3A9C File Offset: 0x000B1C9C
		public static float Dot(Vector2 left, Vector2 right)
		{
			return left.X * right.X + left.Y * right.Y;
		}

		// Token: 0x06004275 RID: 17013 RVA: 0x000B3AC0 File Offset: 0x000B1CC0
		public static void Dot(ref Vector2 left, ref Vector2 right, out float result)
		{
			result = left.X * right.X + left.Y * right.Y;
		}

		// Token: 0x06004276 RID: 17014 RVA: 0x000B3AE0 File Offset: 0x000B1CE0
		public static float PerpDot(Vector2 left, Vector2 right)
		{
			return left.X * right.Y - left.Y * right.X;
		}

		// Token: 0x06004277 RID: 17015 RVA: 0x000B3B04 File Offset: 0x000B1D04
		public static void PerpDot(ref Vector2 left, ref Vector2 right, out float result)
		{
			result = left.X * right.Y - left.Y * right.X;
		}

		// Token: 0x06004278 RID: 17016 RVA: 0x000B3B24 File Offset: 0x000B1D24
		public static Vector2 Lerp(Vector2 a, Vector2 b, float blend)
		{
			a.X = blend * (b.X - a.X) + a.X;
			a.Y = blend * (b.Y - a.Y) + a.Y;
			return a;
		}

		// Token: 0x06004279 RID: 17017 RVA: 0x000B3B74 File Offset: 0x000B1D74
		public static void Lerp(ref Vector2 a, ref Vector2 b, float blend, out Vector2 result)
		{
			result.X = blend * (b.X - a.X) + a.X;
			result.Y = blend * (b.Y - a.Y) + a.Y;
		}

		// Token: 0x0600427A RID: 17018 RVA: 0x000B3BB0 File Offset: 0x000B1DB0
		public static Vector2 BaryCentric(Vector2 a, Vector2 b, Vector2 c, float u, float v)
		{
			return a + u * (b - a) + v * (c - a);
		}

		// Token: 0x0600427B RID: 17019 RVA: 0x000B3BD8 File Offset: 0x000B1DD8
		public static void BaryCentric(ref Vector2 a, ref Vector2 b, ref Vector2 c, float u, float v, out Vector2 result)
		{
			result = a;
			Vector2 vector = b;
			Vector2.Subtract(ref vector, ref a, out vector);
			Vector2.Multiply(ref vector, u, out vector);
			Vector2.Add(ref result, ref vector, out result);
			vector = c;
			Vector2.Subtract(ref vector, ref a, out vector);
			Vector2.Multiply(ref vector, v, out vector);
			Vector2.Add(ref result, ref vector, out result);
		}

		// Token: 0x0600427C RID: 17020 RVA: 0x000B3C40 File Offset: 0x000B1E40
		public static Vector2 Transform(Vector2 vec, Quaternion quat)
		{
			Vector2 result;
			Vector2.Transform(ref vec, ref quat, out result);
			return result;
		}

		// Token: 0x0600427D RID: 17021 RVA: 0x000B3C5C File Offset: 0x000B1E5C
		public static void Transform(ref Vector2 vec, ref Quaternion quat, out Vector2 result)
		{
			Quaternion quaternion = new Quaternion(vec.X, vec.Y, 0f, 0f);
			Quaternion quaternion2;
			Quaternion.Invert(ref quat, out quaternion2);
			Quaternion quaternion3;
			Quaternion.Multiply(ref quat, ref quaternion, out quaternion3);
			Quaternion.Multiply(ref quaternion3, ref quaternion2, out quaternion);
			result = new Vector2(quaternion.X, quaternion.Y);
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600427E RID: 17022 RVA: 0x000B3CC4 File Offset: 0x000B1EC4
		// (set) Token: 0x0600427F RID: 17023 RVA: 0x000B3CD8 File Offset: 0x000B1ED8
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

		// Token: 0x06004280 RID: 17024 RVA: 0x000B3CF4 File Offset: 0x000B1EF4
		public static Vector2 operator +(Vector2 left, Vector2 right)
		{
			left.X += right.X;
			left.Y += right.Y;
			return left;
		}

		// Token: 0x06004281 RID: 17025 RVA: 0x000B3D24 File Offset: 0x000B1F24
		public static Vector2 operator -(Vector2 left, Vector2 right)
		{
			left.X -= right.X;
			left.Y -= right.Y;
			return left;
		}

		// Token: 0x06004282 RID: 17026 RVA: 0x000B3D54 File Offset: 0x000B1F54
		public static Vector2 operator -(Vector2 vec)
		{
			vec.X = -vec.X;
			vec.Y = -vec.Y;
			return vec;
		}

		// Token: 0x06004283 RID: 17027 RVA: 0x000B3D78 File Offset: 0x000B1F78
		public static Vector2 operator *(Vector2 vec, float scale)
		{
			vec.X *= scale;
			vec.Y *= scale;
			return vec;
		}

		// Token: 0x06004284 RID: 17028 RVA: 0x000B3D9C File Offset: 0x000B1F9C
		public static Vector2 operator *(float scale, Vector2 vec)
		{
			vec.X *= scale;
			vec.Y *= scale;
			return vec;
		}

		// Token: 0x06004285 RID: 17029 RVA: 0x000B3DC0 File Offset: 0x000B1FC0
		public static Vector2 operator *(Vector2 vec, Vector2 scale)
		{
			vec.X *= scale.X;
			vec.Y *= scale.Y;
			return vec;
		}

		// Token: 0x06004286 RID: 17030 RVA: 0x000B3DF0 File Offset: 0x000B1FF0
		public static Vector2 operator /(Vector2 vec, float scale)
		{
			float num = 1f / scale;
			vec.X *= num;
			vec.Y *= num;
			return vec;
		}

		// Token: 0x06004287 RID: 17031 RVA: 0x000B3E24 File Offset: 0x000B2024
		public static bool operator ==(Vector2 left, Vector2 right)
		{
			return left.Equals(right);
		}

		// Token: 0x06004288 RID: 17032 RVA: 0x000B3E30 File Offset: 0x000B2030
		public static bool operator !=(Vector2 left, Vector2 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06004289 RID: 17033 RVA: 0x000B3E40 File Offset: 0x000B2040
		public override string ToString()
		{
			return string.Format("({0}{2} {1})", this.X, this.Y, Vector2.listSeparator);
		}

		// Token: 0x0600428A RID: 17034 RVA: 0x000B3E68 File Offset: 0x000B2068
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode();
		}

		// Token: 0x0600428B RID: 17035 RVA: 0x000B3E84 File Offset: 0x000B2084
		public override bool Equals(object obj)
		{
			return obj is Vector2 && this.Equals((Vector2)obj);
		}

		// Token: 0x0600428C RID: 17036 RVA: 0x000B3E9C File Offset: 0x000B209C
		public bool Equals(Vector2 other)
		{
			return this.X == other.X && this.Y == other.Y;
		}

		// Token: 0x04004E3D RID: 20029
		public float X;

		// Token: 0x04004E3E RID: 20030
		public float Y;

		// Token: 0x04004E3F RID: 20031
		public static readonly Vector2 UnitX = new Vector2(1f, 0f);

		// Token: 0x04004E40 RID: 20032
		public static readonly Vector2 UnitY = new Vector2(0f, 1f);

		// Token: 0x04004E41 RID: 20033
		public static readonly Vector2 Zero = new Vector2(0f, 0f);

		// Token: 0x04004E42 RID: 20034
		public static readonly Vector2 One = new Vector2(1f, 1f);

		// Token: 0x04004E43 RID: 20035
		public static readonly int SizeInBytes = Marshal.SizeOf(default(Vector2));

		// Token: 0x04004E44 RID: 20036
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
