using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x0200053A RID: 1338
	[Serializable]
	public struct Quaterniond : IEquatable<Quaterniond>
	{
		// Token: 0x060042A4 RID: 17060 RVA: 0x000B4360 File Offset: 0x000B2560
		public Quaterniond(Vector3d v, double w)
		{
			this.xyz = v;
			this.w = w;
		}

		// Token: 0x060042A5 RID: 17061 RVA: 0x000B4370 File Offset: 0x000B2570
		public Quaterniond(double x, double y, double z, double w)
		{
			this = new Quaterniond(new Vector3d(x, y, z), w);
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x060042A6 RID: 17062 RVA: 0x000B4384 File Offset: 0x000B2584
		// (set) Token: 0x060042A7 RID: 17063 RVA: 0x000B438C File Offset: 0x000B258C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use Xyz property instead.")]
		[CLSCompliant(false)]
		[XmlIgnore]
		public Vector3d XYZ
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

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x060042A8 RID: 17064 RVA: 0x000B4398 File Offset: 0x000B2598
		// (set) Token: 0x060042A9 RID: 17065 RVA: 0x000B43A0 File Offset: 0x000B25A0
		public Vector3d Xyz
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

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x060042AA RID: 17066 RVA: 0x000B43AC File Offset: 0x000B25AC
		// (set) Token: 0x060042AB RID: 17067 RVA: 0x000B43BC File Offset: 0x000B25BC
		[XmlIgnore]
		public double X
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

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x060042AC RID: 17068 RVA: 0x000B43CC File Offset: 0x000B25CC
		// (set) Token: 0x060042AD RID: 17069 RVA: 0x000B43DC File Offset: 0x000B25DC
		[XmlIgnore]
		public double Y
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

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x060042AE RID: 17070 RVA: 0x000B43EC File Offset: 0x000B25EC
		// (set) Token: 0x060042AF RID: 17071 RVA: 0x000B43FC File Offset: 0x000B25FC
		[XmlIgnore]
		public double Z
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

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x060042B0 RID: 17072 RVA: 0x000B440C File Offset: 0x000B260C
		// (set) Token: 0x060042B1 RID: 17073 RVA: 0x000B4414 File Offset: 0x000B2614
		public double W
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

		// Token: 0x060042B2 RID: 17074 RVA: 0x000B4420 File Offset: 0x000B2620
		public void ToAxisAngle(out Vector3d axis, out double angle)
		{
			Vector4d vector4d = this.ToAxisAngle();
			axis = vector4d.Xyz;
			angle = vector4d.W;
		}

		// Token: 0x060042B3 RID: 17075 RVA: 0x000B444C File Offset: 0x000B264C
		public Vector4d ToAxisAngle()
		{
			Quaterniond quaterniond = this;
			if (Math.Abs(quaterniond.W) > 1.0)
			{
				quaterniond.Normalize();
			}
			Vector4d result = default(Vector4d);
			result.W = (double)(2f * (float)Math.Acos(quaterniond.W));
			float num = (float)Math.Sqrt(1.0 - quaterniond.W * quaterniond.W);
			if (num > 0.0001f)
			{
				result.Xyz = quaterniond.Xyz / (double)num;
			}
			else
			{
				result.Xyz = Vector3d.UnitX;
			}
			return result;
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x060042B4 RID: 17076 RVA: 0x000B44F0 File Offset: 0x000B26F0
		public double Length
		{
			get
			{
				return Math.Sqrt(this.W * this.W + this.Xyz.LengthSquared);
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x060042B5 RID: 17077 RVA: 0x000B4520 File Offset: 0x000B2720
		public double LengthSquared
		{
			get
			{
				return this.W * this.W + this.Xyz.LengthSquared;
			}
		}

		// Token: 0x060042B6 RID: 17078 RVA: 0x000B454C File Offset: 0x000B274C
		public Quaterniond Normalized()
		{
			Quaterniond result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x060042B7 RID: 17079 RVA: 0x000B4568 File Offset: 0x000B2768
		public void Invert()
		{
			this.W = -this.W;
		}

		// Token: 0x060042B8 RID: 17080 RVA: 0x000B4578 File Offset: 0x000B2778
		public Quaterniond Inverted()
		{
			Quaterniond result = this;
			result.Invert();
			return result;
		}

		// Token: 0x060042B9 RID: 17081 RVA: 0x000B4594 File Offset: 0x000B2794
		public void Normalize()
		{
			double num = 1.0 / this.Length;
			this.Xyz *= num;
			this.W *= num;
		}

		// Token: 0x060042BA RID: 17082 RVA: 0x000B45D4 File Offset: 0x000B27D4
		public void Conjugate()
		{
			this.Xyz = -this.Xyz;
		}

		// Token: 0x060042BB RID: 17083 RVA: 0x000B45E8 File Offset: 0x000B27E8
		public static Quaterniond Add(Quaterniond left, Quaterniond right)
		{
			return new Quaterniond(left.Xyz + right.Xyz, left.W + right.W);
		}

		// Token: 0x060042BC RID: 17084 RVA: 0x000B4614 File Offset: 0x000B2814
		public static void Add(ref Quaterniond left, ref Quaterniond right, out Quaterniond result)
		{
			result = new Quaterniond(left.Xyz + right.Xyz, left.W + right.W);
		}

		// Token: 0x060042BD RID: 17085 RVA: 0x000B4640 File Offset: 0x000B2840
		public static Quaterniond Sub(Quaterniond left, Quaterniond right)
		{
			return new Quaterniond(left.Xyz - right.Xyz, left.W - right.W);
		}

		// Token: 0x060042BE RID: 17086 RVA: 0x000B466C File Offset: 0x000B286C
		public static void Sub(ref Quaterniond left, ref Quaterniond right, out Quaterniond result)
		{
			result = new Quaterniond(left.Xyz - right.Xyz, left.W - right.W);
		}

		// Token: 0x060042BF RID: 17087 RVA: 0x000B4698 File Offset: 0x000B2898
		[Obsolete("Use Multiply instead.")]
		public static Quaterniond Mult(Quaterniond left, Quaterniond right)
		{
			return new Quaterniond(right.W * left.Xyz + left.W * right.Xyz + Vector3d.Cross(left.Xyz, right.Xyz), left.W * right.W - Vector3d.Dot(left.Xyz, right.Xyz));
		}

		// Token: 0x060042C0 RID: 17088 RVA: 0x000B4710 File Offset: 0x000B2910
		[Obsolete("Use Multiply instead.")]
		public static void Mult(ref Quaterniond left, ref Quaterniond right, out Quaterniond result)
		{
			result = new Quaterniond(right.W * left.Xyz + left.W * right.Xyz + Vector3d.Cross(left.Xyz, right.Xyz), left.W * right.W - Vector3d.Dot(left.Xyz, right.Xyz));
		}

		// Token: 0x060042C1 RID: 17089 RVA: 0x000B4784 File Offset: 0x000B2984
		public static Quaterniond Multiply(Quaterniond left, Quaterniond right)
		{
			Quaterniond result;
			Quaterniond.Multiply(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060042C2 RID: 17090 RVA: 0x000B47A0 File Offset: 0x000B29A0
		public static void Multiply(ref Quaterniond left, ref Quaterniond right, out Quaterniond result)
		{
			result = new Quaterniond(right.W * left.Xyz + left.W * right.Xyz + Vector3d.Cross(left.Xyz, right.Xyz), left.W * right.W - Vector3d.Dot(left.Xyz, right.Xyz));
		}

		// Token: 0x060042C3 RID: 17091 RVA: 0x000B4814 File Offset: 0x000B2A14
		public static void Multiply(ref Quaterniond quaternion, double scale, out Quaterniond result)
		{
			result = new Quaterniond(quaternion.X * scale, quaternion.Y * scale, quaternion.Z * scale, quaternion.W * scale);
		}

		// Token: 0x060042C4 RID: 17092 RVA: 0x000B4844 File Offset: 0x000B2A44
		public static Quaterniond Multiply(Quaterniond quaternion, double scale)
		{
			return new Quaterniond(quaternion.X * scale, quaternion.Y * scale, quaternion.Z * scale, quaternion.W * scale);
		}

		// Token: 0x060042C5 RID: 17093 RVA: 0x000B4870 File Offset: 0x000B2A70
		public static Quaterniond Conjugate(Quaterniond q)
		{
			return new Quaterniond(-q.Xyz, q.W);
		}

		// Token: 0x060042C6 RID: 17094 RVA: 0x000B488C File Offset: 0x000B2A8C
		public static void Conjugate(ref Quaterniond q, out Quaterniond result)
		{
			result = new Quaterniond(-q.Xyz, q.W);
		}

		// Token: 0x060042C7 RID: 17095 RVA: 0x000B48AC File Offset: 0x000B2AAC
		public static Quaterniond Invert(Quaterniond q)
		{
			Quaterniond result;
			Quaterniond.Invert(ref q, out result);
			return result;
		}

		// Token: 0x060042C8 RID: 17096 RVA: 0x000B48C4 File Offset: 0x000B2AC4
		public static void Invert(ref Quaterniond q, out Quaterniond result)
		{
			double lengthSquared = q.LengthSquared;
			if (lengthSquared != 0.0)
			{
				double num = 1.0 / lengthSquared;
				result = new Quaterniond(q.Xyz * -num, q.W * num);
				return;
			}
			result = q;
		}

		// Token: 0x060042C9 RID: 17097 RVA: 0x000B4920 File Offset: 0x000B2B20
		public static Quaterniond Normalize(Quaterniond q)
		{
			Quaterniond result;
			Quaterniond.Normalize(ref q, out result);
			return result;
		}

		// Token: 0x060042CA RID: 17098 RVA: 0x000B4938 File Offset: 0x000B2B38
		public static void Normalize(ref Quaterniond q, out Quaterniond result)
		{
			double num = 1.0 / q.Length;
			result = new Quaterniond(q.Xyz * num, q.W * num);
		}

		// Token: 0x060042CB RID: 17099 RVA: 0x000B4978 File Offset: 0x000B2B78
		public static Quaterniond FromAxisAngle(Vector3d axis, double angle)
		{
			if (axis.LengthSquared == 0.0)
			{
				return Quaterniond.Identity;
			}
			Quaterniond identity = Quaterniond.Identity;
			angle *= 0.5;
			axis.Normalize();
			identity.Xyz = axis * Math.Sin(angle);
			identity.W = Math.Cos(angle);
			return Quaterniond.Normalize(identity);
		}

		// Token: 0x060042CC RID: 17100 RVA: 0x000B49E0 File Offset: 0x000B2BE0
		public static Quaterniond FromMatrix(Matrix3d matrix)
		{
			Quaterniond result;
			Quaterniond.FromMatrix(ref matrix, out result);
			return result;
		}

		// Token: 0x060042CD RID: 17101 RVA: 0x000B49F8 File Offset: 0x000B2BF8
		public static void FromMatrix(ref Matrix3d matrix, out Quaterniond result)
		{
			double trace = matrix.Trace;
			if (trace > 0.0)
			{
				double num = Math.Sqrt(trace + 1.0) * 2.0;
				double num2 = 1.0 / num;
				result.w = num * 0.25;
				result.xyz.X = (matrix.Row2.Y - matrix.Row1.Z) * num2;
				result.xyz.Y = (matrix.Row0.Z - matrix.Row2.X) * num2;
				result.xyz.Z = (matrix.Row1.X - matrix.Row0.Y) * num2;
				return;
			}
			double x = matrix.Row0.X;
			double y = matrix.Row1.Y;
			double z = matrix.Row2.Z;
			if (x > y && x > z)
			{
				double num3 = Math.Sqrt(1.0 + x - y - z) * 2.0;
				double num4 = 1.0 / num3;
				result.w = (matrix.Row2.Y - matrix.Row1.Z) * num4;
				result.xyz.X = num3 * 0.25;
				result.xyz.Y = (matrix.Row0.Y + matrix.Row1.X) * num4;
				result.xyz.Z = (matrix.Row0.Z + matrix.Row2.X) * num4;
				return;
			}
			if (y > z)
			{
				double num5 = Math.Sqrt(1.0 + y - x - z) * 2.0;
				double num6 = 1.0 / num5;
				result.w = (matrix.Row0.Z - matrix.Row2.X) * num6;
				result.xyz.X = (matrix.Row0.Y + matrix.Row1.X) * num6;
				result.xyz.Y = num5 * 0.25;
				result.xyz.Z = (matrix.Row1.Z + matrix.Row2.Y) * num6;
				return;
			}
			double num7 = Math.Sqrt(1.0 + z - x - y) * 2.0;
			double num8 = 1.0 / num7;
			result.w = (matrix.Row1.X - matrix.Row0.Y) * num8;
			result.xyz.X = (matrix.Row0.Z + matrix.Row2.X) * num8;
			result.xyz.Y = (matrix.Row1.Z + matrix.Row2.Y) * num8;
			result.xyz.Z = num7 * 0.25;
		}

		// Token: 0x060042CE RID: 17102 RVA: 0x000B4D14 File Offset: 0x000B2F14
		public static Quaterniond Slerp(Quaterniond q1, Quaterniond q2, double blend)
		{
			if (q1.LengthSquared == 0.0)
			{
				if (q2.LengthSquared == 0.0)
				{
					return Quaterniond.Identity;
				}
				return q2;
			}
			else
			{
				if (q2.LengthSquared == 0.0)
				{
					return q1;
				}
				double num = q1.W * q2.W + Vector3d.Dot(q1.Xyz, q2.Xyz);
				if (num >= 1.0 || num <= -1.0)
				{
					return q1;
				}
				if (num < 0.0)
				{
					q2.Xyz = -q2.Xyz;
					q2.W = -q2.W;
					num = -num;
				}
				double num5;
				double num6;
				if (num < 0.9900000095367432)
				{
					double num2 = Math.Acos(num);
					double num3 = Math.Sin(num2);
					double num4 = 1.0 / num3;
					num5 = Math.Sin(num2 * (1.0 - blend)) * num4;
					num6 = Math.Sin(num2 * blend) * num4;
				}
				else
				{
					num5 = 1.0 - blend;
					num6 = blend;
				}
				Quaterniond q3 = new Quaterniond(num5 * q1.Xyz + num6 * q2.Xyz, num5 * q1.W + num6 * q2.W);
				if (q3.LengthSquared > 0.0)
				{
					return Quaterniond.Normalize(q3);
				}
				return Quaterniond.Identity;
			}
		}

		// Token: 0x060042CF RID: 17103 RVA: 0x000B4E88 File Offset: 0x000B3088
		public static Quaterniond operator +(Quaterniond left, Quaterniond right)
		{
			left.Xyz += right.Xyz;
			left.W += right.W;
			return left;
		}

		// Token: 0x060042D0 RID: 17104 RVA: 0x000B4EBC File Offset: 0x000B30BC
		public static Quaterniond operator -(Quaterniond left, Quaterniond right)
		{
			left.Xyz -= right.Xyz;
			left.W -= right.W;
			return left;
		}

		// Token: 0x060042D1 RID: 17105 RVA: 0x000B4EF0 File Offset: 0x000B30F0
		public static Quaterniond operator *(Quaterniond left, Quaterniond right)
		{
			Quaterniond.Multiply(ref left, ref right, out left);
			return left;
		}

		// Token: 0x060042D2 RID: 17106 RVA: 0x000B4F00 File Offset: 0x000B3100
		public static Quaterniond operator *(Quaterniond quaternion, double scale)
		{
			Quaterniond.Multiply(ref quaternion, scale, out quaternion);
			return quaternion;
		}

		// Token: 0x060042D3 RID: 17107 RVA: 0x000B4F10 File Offset: 0x000B3110
		public static Quaterniond operator *(double scale, Quaterniond quaternion)
		{
			return new Quaterniond(quaternion.X * scale, quaternion.Y * scale, quaternion.Z * scale, quaternion.W * scale);
		}

		// Token: 0x060042D4 RID: 17108 RVA: 0x000B4F3C File Offset: 0x000B313C
		public static bool operator ==(Quaterniond left, Quaterniond right)
		{
			return left.Equals(right);
		}

		// Token: 0x060042D5 RID: 17109 RVA: 0x000B4F48 File Offset: 0x000B3148
		public static bool operator !=(Quaterniond left, Quaterniond right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060042D6 RID: 17110 RVA: 0x000B4F58 File Offset: 0x000B3158
		public override string ToString()
		{
			return string.Format("V: {0}, W: {1}", this.Xyz, this.W);
		}

		// Token: 0x060042D7 RID: 17111 RVA: 0x000B4F7C File Offset: 0x000B317C
		public override bool Equals(object other)
		{
			return other is Quaterniond && this == (Quaterniond)other;
		}

		// Token: 0x060042D8 RID: 17112 RVA: 0x000B4F9C File Offset: 0x000B319C
		public override int GetHashCode()
		{
			return this.Xyz.GetHashCode() ^ this.W.GetHashCode();
		}

		// Token: 0x060042D9 RID: 17113 RVA: 0x000B4FCC File Offset: 0x000B31CC
		public bool Equals(Quaterniond other)
		{
			return this.Xyz == other.Xyz && this.W == other.W;
		}

		// Token: 0x04004E53 RID: 20051
		private Vector3d xyz;

		// Token: 0x04004E54 RID: 20052
		private double w;

		// Token: 0x04004E55 RID: 20053
		public static readonly Quaterniond Identity = new Quaterniond(0.0, 0.0, 0.0, 1.0);
	}
}
