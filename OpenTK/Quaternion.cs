using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x02000529 RID: 1321
	[Serializable]
	public struct Quaternion : IEquatable<Quaternion>
	{
		// Token: 0x06003DED RID: 15853 RVA: 0x000A2884 File Offset: 0x000A0A84
		public Quaternion(Vector3 v, float w)
		{
			this.xyz = v;
			this.w = w;
		}

		// Token: 0x06003DEE RID: 15854 RVA: 0x000A2894 File Offset: 0x000A0A94
		public Quaternion(float x, float y, float z, float w)
		{
			this = new Quaternion(new Vector3(x, y, z), w);
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06003DEF RID: 15855 RVA: 0x000A28A8 File Offset: 0x000A0AA8
		// (set) Token: 0x06003DF0 RID: 15856 RVA: 0x000A28B0 File Offset: 0x000A0AB0
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		[Obsolete("Use Xyz property instead.")]
		public Vector3 XYZ
		{
			get
			{
				return this.Xyz;
			}
			set
			{
				this.Xyz = value;
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06003DF1 RID: 15857 RVA: 0x000A28BC File Offset: 0x000A0ABC
		// (set) Token: 0x06003DF2 RID: 15858 RVA: 0x000A28C4 File Offset: 0x000A0AC4
		[CLSCompliant(false)]
		public Vector3 Xyz
		{
			get
			{
				return this.xyz;
			}
			set
			{
				this.xyz = value;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06003DF3 RID: 15859 RVA: 0x000A28D0 File Offset: 0x000A0AD0
		// (set) Token: 0x06003DF4 RID: 15860 RVA: 0x000A28E0 File Offset: 0x000A0AE0
		[XmlIgnore]
		public float X
		{
			get
			{
				return this.xyz.X;
			}
			set
			{
				this.xyz.X = value;
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06003DF5 RID: 15861 RVA: 0x000A28F0 File Offset: 0x000A0AF0
		// (set) Token: 0x06003DF6 RID: 15862 RVA: 0x000A2900 File Offset: 0x000A0B00
		[XmlIgnore]
		public float Y
		{
			get
			{
				return this.xyz.Y;
			}
			set
			{
				this.xyz.Y = value;
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06003DF7 RID: 15863 RVA: 0x000A2910 File Offset: 0x000A0B10
		// (set) Token: 0x06003DF8 RID: 15864 RVA: 0x000A2920 File Offset: 0x000A0B20
		[XmlIgnore]
		public float Z
		{
			get
			{
				return this.xyz.Z;
			}
			set
			{
				this.xyz.Z = value;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06003DF9 RID: 15865 RVA: 0x000A2930 File Offset: 0x000A0B30
		// (set) Token: 0x06003DFA RID: 15866 RVA: 0x000A2938 File Offset: 0x000A0B38
		public float W
		{
			get
			{
				return this.w;
			}
			set
			{
				this.w = value;
			}
		}

		// Token: 0x06003DFB RID: 15867 RVA: 0x000A2944 File Offset: 0x000A0B44
		public void ToAxisAngle(out Vector3 axis, out float angle)
		{
			Vector4 vector = this.ToAxisAngle();
			axis = vector.Xyz;
			angle = vector.W;
		}

		// Token: 0x06003DFC RID: 15868 RVA: 0x000A2970 File Offset: 0x000A0B70
		public Vector4 ToAxisAngle()
		{
			Quaternion quaternion = this;
			if (Math.Abs(quaternion.W) > 1f)
			{
				quaternion.Normalize();
			}
			Vector4 result = default(Vector4);
			result.W = 2f * (float)Math.Acos((double)quaternion.W);
			float num = (float)Math.Sqrt(1.0 - (double)(quaternion.W * quaternion.W));
			if (num > 0.0001f)
			{
				result.Xyz = quaternion.Xyz / num;
			}
			else
			{
				result.Xyz = Vector3.UnitX;
			}
			return result;
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06003DFD RID: 15869 RVA: 0x000A2A10 File Offset: 0x000A0C10
		public float Length
		{
			get
			{
				return (float)Math.Sqrt((double)(this.W * this.W + this.Xyz.LengthSquared));
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06003DFE RID: 15870 RVA: 0x000A2A40 File Offset: 0x000A0C40
		public float LengthSquared
		{
			get
			{
				return this.W * this.W + this.Xyz.LengthSquared;
			}
		}

		// Token: 0x06003DFF RID: 15871 RVA: 0x000A2A6C File Offset: 0x000A0C6C
		public Quaternion Normalized()
		{
			Quaternion result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06003E00 RID: 15872 RVA: 0x000A2A88 File Offset: 0x000A0C88
		public void Invert()
		{
			this.W = -this.W;
		}

		// Token: 0x06003E01 RID: 15873 RVA: 0x000A2A98 File Offset: 0x000A0C98
		public Quaternion Inverted()
		{
			Quaternion result = this;
			result.Invert();
			return result;
		}

		// Token: 0x06003E02 RID: 15874 RVA: 0x000A2AB4 File Offset: 0x000A0CB4
		public void Normalize()
		{
			float num = 1f / this.Length;
			this.Xyz *= num;
			this.W *= num;
		}

		// Token: 0x06003E03 RID: 15875 RVA: 0x000A2AF0 File Offset: 0x000A0CF0
		public void Conjugate()
		{
			this.Xyz = -this.Xyz;
		}

		// Token: 0x06003E04 RID: 15876 RVA: 0x000A2B04 File Offset: 0x000A0D04
		public static Quaternion Add(Quaternion left, Quaternion right)
		{
			return new Quaternion(left.Xyz + right.Xyz, left.W + right.W);
		}

		// Token: 0x06003E05 RID: 15877 RVA: 0x000A2B30 File Offset: 0x000A0D30
		public static void Add(ref Quaternion left, ref Quaternion right, out Quaternion result)
		{
			result = new Quaternion(left.Xyz + right.Xyz, left.W + right.W);
		}

		// Token: 0x06003E06 RID: 15878 RVA: 0x000A2B5C File Offset: 0x000A0D5C
		public static Quaternion Sub(Quaternion left, Quaternion right)
		{
			return new Quaternion(left.Xyz - right.Xyz, left.W - right.W);
		}

		// Token: 0x06003E07 RID: 15879 RVA: 0x000A2B88 File Offset: 0x000A0D88
		public static void Sub(ref Quaternion left, ref Quaternion right, out Quaternion result)
		{
			result = new Quaternion(left.Xyz - right.Xyz, left.W - right.W);
		}

		// Token: 0x06003E08 RID: 15880 RVA: 0x000A2BB4 File Offset: 0x000A0DB4
		[Obsolete("Use Multiply instead.")]
		public static Quaternion Mult(Quaternion left, Quaternion right)
		{
			return new Quaternion(right.W * left.Xyz + left.W * right.Xyz + Vector3.Cross(left.Xyz, right.Xyz), left.W * right.W - Vector3.Dot(left.Xyz, right.Xyz));
		}

		// Token: 0x06003E09 RID: 15881 RVA: 0x000A2C2C File Offset: 0x000A0E2C
		[Obsolete("Use Multiply instead.")]
		public static void Mult(ref Quaternion left, ref Quaternion right, out Quaternion result)
		{
			result = new Quaternion(right.W * left.Xyz + left.W * right.Xyz + Vector3.Cross(left.Xyz, right.Xyz), left.W * right.W - Vector3.Dot(left.Xyz, right.Xyz));
		}

		// Token: 0x06003E0A RID: 15882 RVA: 0x000A2CA0 File Offset: 0x000A0EA0
		public static Quaternion Multiply(Quaternion left, Quaternion right)
		{
			Quaternion result;
			Quaternion.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06003E0B RID: 15883 RVA: 0x000A2CBC File Offset: 0x000A0EBC
		public static void Multiply(ref Quaternion left, ref Quaternion right, out Quaternion result)
		{
			result = new Quaternion(right.W * left.Xyz + left.W * right.Xyz + Vector3.Cross(left.Xyz, right.Xyz), left.W * right.W - Vector3.Dot(left.Xyz, right.Xyz));
		}

		// Token: 0x06003E0C RID: 15884 RVA: 0x000A2D30 File Offset: 0x000A0F30
		public static void Multiply(ref Quaternion quaternion, float scale, out Quaternion result)
		{
			result = new Quaternion(quaternion.X * scale, quaternion.Y * scale, quaternion.Z * scale, quaternion.W * scale);
		}

		// Token: 0x06003E0D RID: 15885 RVA: 0x000A2D60 File Offset: 0x000A0F60
		public static Quaternion Multiply(Quaternion quaternion, float scale)
		{
			return new Quaternion(quaternion.X * scale, quaternion.Y * scale, quaternion.Z * scale, quaternion.W * scale);
		}

		// Token: 0x06003E0E RID: 15886 RVA: 0x000A2D8C File Offset: 0x000A0F8C
		public static Quaternion Conjugate(Quaternion q)
		{
			return new Quaternion(-q.Xyz, q.W);
		}

		// Token: 0x06003E0F RID: 15887 RVA: 0x000A2DA8 File Offset: 0x000A0FA8
		public static void Conjugate(ref Quaternion q, out Quaternion result)
		{
			result = new Quaternion(-q.Xyz, q.W);
		}

		// Token: 0x06003E10 RID: 15888 RVA: 0x000A2DC8 File Offset: 0x000A0FC8
		public static Quaternion Invert(Quaternion q)
		{
			Quaternion result;
			Quaternion.Invert(ref q, out result);
			return result;
		}

		// Token: 0x06003E11 RID: 15889 RVA: 0x000A2DE0 File Offset: 0x000A0FE0
		public static void Invert(ref Quaternion q, out Quaternion result)
		{
			float lengthSquared = q.LengthSquared;
			if ((double)lengthSquared != 0.0)
			{
				float num = 1f / lengthSquared;
				result = new Quaternion(q.Xyz * -num, q.W * num);
				return;
			}
			result = q;
		}

		// Token: 0x06003E12 RID: 15890 RVA: 0x000A2E38 File Offset: 0x000A1038
		public static Quaternion Normalize(Quaternion q)
		{
			Quaternion result;
			Quaternion.Normalize(ref q, out result);
			return result;
		}

		// Token: 0x06003E13 RID: 15891 RVA: 0x000A2E50 File Offset: 0x000A1050
		public static void Normalize(ref Quaternion q, out Quaternion result)
		{
			float num = 1f / q.Length;
			result = new Quaternion(q.Xyz * num, q.W * num);
		}

		// Token: 0x06003E14 RID: 15892 RVA: 0x000A2E8C File Offset: 0x000A108C
		public static Quaternion FromAxisAngle(Vector3 axis, float angle)
		{
			if (axis.LengthSquared == 0f)
			{
				return Quaternion.Identity;
			}
			Quaternion identity = Quaternion.Identity;
			angle *= 0.5f;
			axis.Normalize();
			identity.Xyz = axis * (float)Math.Sin((double)angle);
			identity.W = (float)Math.Cos((double)angle);
			return Quaternion.Normalize(identity);
		}

		// Token: 0x06003E15 RID: 15893 RVA: 0x000A2EF0 File Offset: 0x000A10F0
		public static Quaternion FromMatrix(Matrix3 matrix)
		{
			Quaternion result;
			Quaternion.FromMatrix(ref matrix, out result);
			return result;
		}

		// Token: 0x06003E16 RID: 15894 RVA: 0x000A2F08 File Offset: 0x000A1108
		public static void FromMatrix(ref Matrix3 matrix, out Quaternion result)
		{
			float trace = matrix.Trace;
			if (trace > 0f)
			{
				float num = (float)Math.Sqrt((double)(trace + 1f)) * 2f;
				float num2 = 1f / num;
				result.w = num * 0.25f;
				result.xyz.X = (matrix.Row2.Y - matrix.Row1.Z) * num2;
				result.xyz.Y = (matrix.Row0.Z - matrix.Row2.X) * num2;
				result.xyz.Z = (matrix.Row1.X - matrix.Row0.Y) * num2;
				return;
			}
			float x = matrix.Row0.X;
			float y = matrix.Row1.Y;
			float z = matrix.Row2.Z;
			if (x > y && x > z)
			{
				float num3 = (float)Math.Sqrt((double)(1f + x - y - z)) * 2f;
				float num4 = 1f / num3;
				result.w = (matrix.Row2.Y - matrix.Row1.Z) * num4;
				result.xyz.X = num3 * 0.25f;
				result.xyz.Y = (matrix.Row0.Y + matrix.Row1.X) * num4;
				result.xyz.Z = (matrix.Row0.Z + matrix.Row2.X) * num4;
				return;
			}
			if (y > z)
			{
				float num5 = (float)Math.Sqrt((double)(1f + y - x - z)) * 2f;
				float num6 = 1f / num5;
				result.w = (matrix.Row0.Z - matrix.Row2.X) * num6;
				result.xyz.X = (matrix.Row0.Y + matrix.Row1.X) * num6;
				result.xyz.Y = num5 * 0.25f;
				result.xyz.Z = (matrix.Row1.Z + matrix.Row2.Y) * num6;
				return;
			}
			float num7 = (float)Math.Sqrt((double)(1f + z - x - y)) * 2f;
			float num8 = 1f / num7;
			result.w = (matrix.Row1.X - matrix.Row0.Y) * num8;
			result.xyz.X = (matrix.Row0.Z + matrix.Row2.X) * num8;
			result.xyz.Y = (matrix.Row1.Z + matrix.Row2.Y) * num8;
			result.xyz.Z = num7 * 0.25f;
		}

		// Token: 0x06003E17 RID: 15895 RVA: 0x000A31E8 File Offset: 0x000A13E8
		public static Quaternion Slerp(Quaternion q1, Quaternion q2, float blend)
		{
			if (q1.LengthSquared == 0f)
			{
				if (q2.LengthSquared == 0f)
				{
					return Quaternion.Identity;
				}
				return q2;
			}
			else
			{
				if (q2.LengthSquared == 0f)
				{
					return q1;
				}
				float num = q1.W * q2.W + Vector3.Dot(q1.Xyz, q2.Xyz);
				if (num >= 1f || num <= -1f)
				{
					return q1;
				}
				if (num < 0f)
				{
					q2.Xyz = -q2.Xyz;
					q2.W = -q2.W;
					num = -num;
				}
				float num5;
				float num6;
				if (num < 0.99f)
				{
					float num2 = (float)Math.Acos((double)num);
					float num3 = (float)Math.Sin((double)num2);
					float num4 = 1f / num3;
					num5 = (float)Math.Sin((double)(num2 * (1f - blend))) * num4;
					num6 = (float)Math.Sin((double)(num2 * blend)) * num4;
				}
				else
				{
					num5 = 1f - blend;
					num6 = blend;
				}
				Quaternion q3 = new Quaternion(num5 * q1.Xyz + num6 * q2.Xyz, num5 * q1.W + num6 * q2.W);
				if (q3.LengthSquared > 0f)
				{
					return Quaternion.Normalize(q3);
				}
				return Quaternion.Identity;
			}
		}

		// Token: 0x06003E18 RID: 15896 RVA: 0x000A3334 File Offset: 0x000A1534
		public static Quaternion operator +(Quaternion left, Quaternion right)
		{
			left.Xyz += right.Xyz;
			left.W += right.W;
			return left;
		}

		// Token: 0x06003E19 RID: 15897 RVA: 0x000A3368 File Offset: 0x000A1568
		public static Quaternion operator -(Quaternion left, Quaternion right)
		{
			left.Xyz -= right.Xyz;
			left.W -= right.W;
			return left;
		}

		// Token: 0x06003E1A RID: 15898 RVA: 0x000A339C File Offset: 0x000A159C
		public static Quaternion operator *(Quaternion left, Quaternion right)
		{
			Quaternion.Multiply(ref left, ref right, out left);
			return left;
		}

		// Token: 0x06003E1B RID: 15899 RVA: 0x000A33AC File Offset: 0x000A15AC
		public static Quaternion operator *(Quaternion quaternion, float scale)
		{
			Quaternion.Multiply(ref quaternion, scale, out quaternion);
			return quaternion;
		}

		// Token: 0x06003E1C RID: 15900 RVA: 0x000A33BC File Offset: 0x000A15BC
		public static Quaternion operator *(float scale, Quaternion quaternion)
		{
			return new Quaternion(quaternion.X * scale, quaternion.Y * scale, quaternion.Z * scale, quaternion.W * scale);
		}

		// Token: 0x06003E1D RID: 15901 RVA: 0x000A33E8 File Offset: 0x000A15E8
		public static bool operator ==(Quaternion left, Quaternion right)
		{
			return left.Equals(right);
		}

		// Token: 0x06003E1E RID: 15902 RVA: 0x000A33F4 File Offset: 0x000A15F4
		public static bool operator !=(Quaternion left, Quaternion right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06003E1F RID: 15903 RVA: 0x000A3404 File Offset: 0x000A1604
		public override string ToString()
		{
			return string.Format("V: {0}, W: {1}", this.Xyz, this.W);
		}

		// Token: 0x06003E20 RID: 15904 RVA: 0x000A3428 File Offset: 0x000A1628
		public override bool Equals(object other)
		{
			return other is Quaternion && this == (Quaternion)other;
		}

		// Token: 0x06003E21 RID: 15905 RVA: 0x000A3448 File Offset: 0x000A1648
		public override int GetHashCode()
		{
			return this.Xyz.GetHashCode() ^ this.W.GetHashCode();
		}

		// Token: 0x06003E22 RID: 15906 RVA: 0x000A3478 File Offset: 0x000A1678
		public bool Equals(Quaternion other)
		{
			return this.Xyz == other.Xyz && this.W == other.W;
		}

		// Token: 0x04004DE5 RID: 19941
		private Vector3 xyz;

		// Token: 0x04004DE6 RID: 19942
		private float w;

		// Token: 0x04004DE7 RID: 19943
		public static readonly Quaternion Identity = new Quaternion(0f, 0f, 0f, 1f);
	}
}
