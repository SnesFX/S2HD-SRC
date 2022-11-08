using System;

namespace OpenTK
{
	// Token: 0x0200001F RID: 31
	[Serializable]
	public struct Matrix3x4d : IEquatable<Matrix3x4d>
	{
		// Token: 0x06000306 RID: 774 RVA: 0x0000CD6C File Offset: 0x0000AF6C
		public Matrix3x4d(Vector4d row0, Vector4d row1, Vector4d row2)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000CD84 File Offset: 0x0000AF84
		public Matrix3x4d(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23)
		{
			this.Row0 = new Vector4d(m00, m01, m02, m03);
			this.Row1 = new Vector4d(m10, m11, m12, m13);
			this.Row2 = new Vector4d(m20, m21, m22, m23);
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000308 RID: 776 RVA: 0x0000CDBC File Offset: 0x0000AFBC
		public Vector3d Column0
		{
			get
			{
				return new Vector3d(this.Row0.X, this.Row1.X, this.Row2.X);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000309 RID: 777 RVA: 0x0000CDE4 File Offset: 0x0000AFE4
		public Vector3d Column1
		{
			get
			{
				return new Vector3d(this.Row0.Y, this.Row1.Y, this.Row2.Y);
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600030A RID: 778 RVA: 0x0000CE0C File Offset: 0x0000B00C
		public Vector3d Column2
		{
			get
			{
				return new Vector3d(this.Row0.Z, this.Row1.Z, this.Row2.Z);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000CE34 File Offset: 0x0000B034
		public Vector3d Column3
		{
			get
			{
				return new Vector3d(this.Row0.W, this.Row1.W, this.Row2.W);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600030C RID: 780 RVA: 0x0000CE5C File Offset: 0x0000B05C
		// (set) Token: 0x0600030D RID: 781 RVA: 0x0000CE6C File Offset: 0x0000B06C
		public double M11
		{
			get
			{
				return this.Row0.X;
			}
			set
			{
				this.Row0.X = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600030E RID: 782 RVA: 0x0000CE7C File Offset: 0x0000B07C
		// (set) Token: 0x0600030F RID: 783 RVA: 0x0000CE8C File Offset: 0x0000B08C
		public double M12
		{
			get
			{
				return this.Row0.Y;
			}
			set
			{
				this.Row0.Y = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000310 RID: 784 RVA: 0x0000CE9C File Offset: 0x0000B09C
		// (set) Token: 0x06000311 RID: 785 RVA: 0x0000CEAC File Offset: 0x0000B0AC
		public double M13
		{
			get
			{
				return this.Row0.Z;
			}
			set
			{
				this.Row0.Z = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000312 RID: 786 RVA: 0x0000CEBC File Offset: 0x0000B0BC
		// (set) Token: 0x06000313 RID: 787 RVA: 0x0000CECC File Offset: 0x0000B0CC
		public double M14
		{
			get
			{
				return this.Row0.W;
			}
			set
			{
				this.Row0.W = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0000CEDC File Offset: 0x0000B0DC
		// (set) Token: 0x06000315 RID: 789 RVA: 0x0000CEEC File Offset: 0x0000B0EC
		public double M21
		{
			get
			{
				return this.Row1.X;
			}
			set
			{
				this.Row1.X = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000316 RID: 790 RVA: 0x0000CEFC File Offset: 0x0000B0FC
		// (set) Token: 0x06000317 RID: 791 RVA: 0x0000CF0C File Offset: 0x0000B10C
		public double M22
		{
			get
			{
				return this.Row1.Y;
			}
			set
			{
				this.Row1.Y = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000318 RID: 792 RVA: 0x0000CF1C File Offset: 0x0000B11C
		// (set) Token: 0x06000319 RID: 793 RVA: 0x0000CF2C File Offset: 0x0000B12C
		public double M23
		{
			get
			{
				return this.Row1.Z;
			}
			set
			{
				this.Row1.Z = value;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000CF3C File Offset: 0x0000B13C
		// (set) Token: 0x0600031B RID: 795 RVA: 0x0000CF4C File Offset: 0x0000B14C
		public double M24
		{
			get
			{
				return this.Row1.W;
			}
			set
			{
				this.Row1.W = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0000CF5C File Offset: 0x0000B15C
		// (set) Token: 0x0600031D RID: 797 RVA: 0x0000CF6C File Offset: 0x0000B16C
		public double M31
		{
			get
			{
				return this.Row2.X;
			}
			set
			{
				this.Row2.X = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600031E RID: 798 RVA: 0x0000CF7C File Offset: 0x0000B17C
		// (set) Token: 0x0600031F RID: 799 RVA: 0x0000CF8C File Offset: 0x0000B18C
		public double M32
		{
			get
			{
				return this.Row2.Y;
			}
			set
			{
				this.Row2.Y = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000320 RID: 800 RVA: 0x0000CF9C File Offset: 0x0000B19C
		// (set) Token: 0x06000321 RID: 801 RVA: 0x0000CFAC File Offset: 0x0000B1AC
		public double M33
		{
			get
			{
				return this.Row2.Z;
			}
			set
			{
				this.Row2.Z = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000CFBC File Offset: 0x0000B1BC
		// (set) Token: 0x06000323 RID: 803 RVA: 0x0000CFCC File Offset: 0x0000B1CC
		public double M34
		{
			get
			{
				return this.Row2.W;
			}
			set
			{
				this.Row2.W = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000CFDC File Offset: 0x0000B1DC
		// (set) Token: 0x06000325 RID: 805 RVA: 0x0000D004 File Offset: 0x0000B204
		public Vector3d Diagonal
		{
			get
			{
				return new Vector3d(this.Row0.X, this.Row1.Y, this.Row2.Z);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Z = value.Z;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000326 RID: 806 RVA: 0x0000D03C File Offset: 0x0000B23C
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y + this.Row2.Z;
			}
		}

		// Token: 0x170000AE RID: 174
		public double this[int rowIndex, int columnIndex]
		{
			get
			{
				if (rowIndex == 0)
				{
					return this.Row0[columnIndex];
				}
				if (rowIndex == 1)
				{
					return this.Row1[columnIndex];
				}
				if (rowIndex == 2)
				{
					return this.Row2[columnIndex];
				}
				throw new IndexOutOfRangeException(string.Concat(new object[]
				{
					"You tried to access this matrix at: (",
					rowIndex,
					", ",
					columnIndex,
					")"
				}));
			}
			set
			{
				if (rowIndex == 0)
				{
					this.Row0[columnIndex] = value;
					return;
				}
				if (rowIndex == 1)
				{
					this.Row1[columnIndex] = value;
					return;
				}
				if (rowIndex == 2)
				{
					this.Row2[columnIndex] = value;
					return;
				}
				throw new IndexOutOfRangeException(string.Concat(new object[]
				{
					"You tried to set this matrix at: (",
					rowIndex,
					", ",
					columnIndex,
					")"
				}));
			}
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000D160 File Offset: 0x0000B360
		public void Invert()
		{
			this = Matrix3x4d.Invert(this);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000D174 File Offset: 0x0000B374
		public static void CreateFromAxisAngle(Vector3d axis, double angle, out Matrix3x4d result)
		{
			axis.Normalize();
			double x = axis.X;
			double y = axis.Y;
			double z = axis.Z;
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			double num3 = 1.0 - num;
			double num4 = num3 * x * x;
			double num5 = num3 * x * y;
			double num6 = num3 * x * z;
			double num7 = num3 * y * y;
			double num8 = num3 * y * z;
			double num9 = num3 * z * z;
			double num10 = num2 * x;
			double num11 = num2 * y;
			double num12 = num2 * z;
			result.Row0.X = num4 + num;
			result.Row0.Y = num5 - num12;
			result.Row0.Z = num6 + num11;
			result.Row0.W = 0.0;
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num;
			result.Row1.Z = num8 - num10;
			result.Row1.W = 0.0;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num;
			result.Row2.W = 0.0;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000D2CC File Offset: 0x0000B4CC
		public static Matrix3x4d CreateFromAxisAngle(Vector3d axis, double angle)
		{
			Matrix3x4d result;
			Matrix3x4d.CreateFromAxisAngle(axis, angle, out result);
			return result;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000D2E4 File Offset: 0x0000B4E4
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix3x4d result)
		{
			double num = (double)q.X;
			double num2 = (double)q.Y;
			double num3 = (double)q.Z;
			double num4 = (double)q.W;
			double num5 = 2.0 * num;
			double num6 = 2.0 * num2;
			double num7 = 2.0 * num3;
			double num8 = num5 * num;
			double num9 = num6 * num2;
			double num10 = num7 * num3;
			double num11 = num5 * num2;
			double num12 = num5 * num3;
			double num13 = num6 * num3;
			double num14 = num5 * num4;
			double num15 = num6 * num4;
			double num16 = num7 * num4;
			result.Row0.X = 1.0 - (num9 + num10);
			result.Row0.Y = num11 + num16;
			result.Row0.Z = num12 - num15;
			result.Row0.W = 0.0;
			result.Row1.X = num11 - num16;
			result.Row1.Y = 1.0 - (num8 + num10);
			result.Row1.Z = num13 + num14;
			result.Row1.W = 0.0;
			result.Row2.X = num12 + num15;
			result.Row2.Y = num13 - num14;
			result.Row2.Z = 1.0 - (num8 + num9);
			result.Row2.W = 0.0;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000D458 File Offset: 0x0000B658
		public static Matrix3x4d CreateFromQuaternion(Quaternion q)
		{
			Matrix3x4d result;
			Matrix3x4d.CreateFromQuaternion(ref q, out result);
			return result;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000D470 File Offset: 0x0000B670
		public static void CreateRotationX(double angle, out Matrix3x4d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = 1.0;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row0.W = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = num;
			result.Row1.Z = num2;
			result.Row1.W = 0.0;
			result.Row2.X = 0.0;
			result.Row2.Y = -num2;
			result.Row2.Z = num;
			result.Row2.W = 0.0;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000D560 File Offset: 0x0000B760
		public static Matrix3x4d CreateRotationX(double angle)
		{
			Matrix3x4d result;
			Matrix3x4d.CreateRotationX(angle, out result);
			return result;
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000D578 File Offset: 0x0000B778
		public static void CreateRotationY(double angle, out Matrix3x4d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = 0.0;
			result.Row0.Z = -num2;
			result.Row0.W = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = 1.0;
			result.Row1.Z = 0.0;
			result.Row1.W = 0.0;
			result.Row2.X = num2;
			result.Row2.Y = 0.0;
			result.Row2.Z = num;
			result.Row2.W = 0.0;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000D668 File Offset: 0x0000B868
		public static Matrix3x4d CreateRotationY(double angle)
		{
			Matrix3x4d result;
			Matrix3x4d.CreateRotationY(angle, out result);
			return result;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000D680 File Offset: 0x0000B880
		public static void CreateRotationZ(double angle, out Matrix3x4d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row0.Z = 0.0;
			result.Row0.W = 0.0;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row1.Z = 0.0;
			result.Row1.W = 0.0;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row2.Z = 1.0;
			result.Row2.W = 0.0;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000D770 File Offset: 0x0000B970
		public static Matrix3x4d CreateRotationZ(double angle)
		{
			Matrix3x4d result;
			Matrix3x4d.CreateRotationZ(angle, out result);
			return result;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000D788 File Offset: 0x0000B988
		public static void CreateTranslation(double x, double y, double z, out Matrix3x4d result)
		{
			result.Row0.X = 1.0;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row0.W = x;
			result.Row1.X = 0.0;
			result.Row1.Y = 1.0;
			result.Row1.Z = 0.0;
			result.Row1.W = y;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row2.Z = 1.0;
			result.Row2.W = z;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000D870 File Offset: 0x0000BA70
		public static void CreateTranslation(ref Vector3d vector, out Matrix3x4d result)
		{
			result.Row0.X = 1.0;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row0.W = vector.X;
			result.Row1.X = 0.0;
			result.Row1.Y = 1.0;
			result.Row1.Z = 0.0;
			result.Row1.W = vector.Y;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row2.Z = 1.0;
			result.Row2.W = vector.Z;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000D964 File Offset: 0x0000BB64
		public static Matrix3x4d CreateTranslation(double x, double y, double z)
		{
			Matrix3x4d result;
			Matrix3x4d.CreateTranslation(x, y, z, out result);
			return result;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000D97C File Offset: 0x0000BB7C
		public static Matrix3x4d CreateTranslation(Vector3d vector)
		{
			Matrix3x4d result;
			Matrix3x4d.CreateTranslation(vector.X, vector.Y, vector.Z, out result);
			return result;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000D9A8 File Offset: 0x0000BBA8
		public static Matrix3x4d CreateScale(double scale)
		{
			return Matrix3x4d.CreateScale(scale, scale, scale);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000D9B4 File Offset: 0x0000BBB4
		public static Matrix3x4d CreateScale(Vector3d scale)
		{
			return Matrix3x4d.CreateScale(scale.X, scale.Y, scale.Z);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000D9D0 File Offset: 0x0000BBD0
		public static Matrix3x4d CreateScale(double x, double y, double z)
		{
			Matrix3x4d result;
			result.Row0.X = x;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row0.W = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = y;
			result.Row1.Z = 0.0;
			result.Row1.W = 0.0;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row2.Z = z;
			result.Row2.W = 0.0;
			return result;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000DAC4 File Offset: 0x0000BCC4
		public static Matrix3d Mult(Matrix3x4d left, Matrix4x3d right)
		{
			Matrix3d result;
			Matrix3x4d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000DAE0 File Offset: 0x0000BCE0
		public static void Mult(ref Matrix3x4d left, ref Matrix4x3d right, out Matrix3d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double w = left.Row0.W;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double w2 = left.Row1.W;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double z3 = left.Row2.Z;
			double w3 = left.Row2.W;
			double x4 = right.Row0.X;
			double y4 = right.Row0.Y;
			double z4 = right.Row0.Z;
			double x5 = right.Row1.X;
			double y5 = right.Row1.Y;
			double z5 = right.Row1.Z;
			double x6 = right.Row2.X;
			double y6 = right.Row2.Y;
			double z6 = right.Row2.Z;
			double x7 = right.Row3.X;
			double y7 = right.Row3.Y;
			double z7 = right.Row3.Z;
			result.Row0.X = x * x4 + y * x5 + z * x6 + w * x7;
			result.Row0.Y = x * y4 + y * y5 + z * y6 + w * y7;
			result.Row0.Z = x * z4 + y * z5 + z * z6 + w * z7;
			result.Row1.X = x2 * x4 + y2 * x5 + z2 * x6 + w2 * x7;
			result.Row1.Y = x2 * y4 + y2 * y5 + z2 * y6 + w2 * y7;
			result.Row1.Z = x2 * z4 + y2 * z5 + z2 * z6 + w2 * z7;
			result.Row2.X = x3 * x4 + y3 * x5 + z3 * x6 + w3 * x7;
			result.Row2.Y = x3 * y4 + y3 * y5 + z3 * y6 + w3 * y7;
			result.Row2.Z = x3 * z4 + y3 * z5 + z3 * z6 + w3 * z7;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000DD48 File Offset: 0x0000BF48
		public static Matrix3x4d Mult(Matrix3x4d left, Matrix3x4d right)
		{
			Matrix3x4d result;
			Matrix3x4d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000DD64 File Offset: 0x0000BF64
		public static void Mult(ref Matrix3x4d left, ref Matrix3x4d right, out Matrix3x4d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double w = left.Row0.W;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double w2 = left.Row1.W;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double z3 = left.Row2.Z;
			double w3 = left.Row2.W;
			double x4 = right.Row0.X;
			double y4 = right.Row0.Y;
			double z4 = right.Row0.Z;
			double w4 = right.Row0.W;
			double x5 = right.Row1.X;
			double y5 = right.Row1.Y;
			double z5 = right.Row1.Z;
			double w5 = right.Row1.W;
			double x6 = right.Row2.X;
			double y6 = right.Row2.Y;
			double z6 = right.Row2.Z;
			double w6 = right.Row2.W;
			result.Row0.X = x * x4 + y * x5 + z * x6;
			result.Row0.Y = x * y4 + y * y5 + z * y6;
			result.Row0.Z = x * z4 + y * z5 + z * z6;
			result.Row0.W = x * w4 + y * w5 + z * w6 + w;
			result.Row1.X = x2 * x4 + y2 * x5 + z2 * x6;
			result.Row1.Y = x2 * y4 + y2 * y5 + z2 * y6;
			result.Row1.Z = x2 * z4 + y2 * z5 + z2 * z6;
			result.Row1.W = x2 * w4 + y2 * w5 + z2 * w6 + w2;
			result.Row2.X = x3 * x4 + y3 * x5 + z3 * x6;
			result.Row2.Y = x3 * y4 + y3 * y5 + z3 * y6;
			result.Row2.Z = x3 * z4 + y3 * z5 + z3 * z6;
			result.Row2.W = x3 * w4 + y3 * w5 + z3 * w6 + w3;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000DFF4 File Offset: 0x0000C1F4
		public static Matrix3x4d Mult(Matrix3x4d left, double right)
		{
			Matrix3x4d result;
			Matrix3x4d.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000E00C File Offset: 0x0000C20C
		public static void Mult(ref Matrix3x4d left, double right, out Matrix3x4d result)
		{
			result.Row0 = left.Row0 * right;
			result.Row1 = left.Row1 * right;
			result.Row2 = left.Row2 * right;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000E044 File Offset: 0x0000C244
		public static Matrix3x4d Add(Matrix3x4d left, Matrix3x4d right)
		{
			Matrix3x4d result;
			Matrix3x4d.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000E060 File Offset: 0x0000C260
		public static void Add(ref Matrix3x4d left, ref Matrix3x4d right, out Matrix3x4d result)
		{
			result.Row0 = left.Row0 + right.Row0;
			result.Row1 = left.Row1 + right.Row1;
			result.Row2 = left.Row2 + right.Row2;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000E0B4 File Offset: 0x0000C2B4
		public static Matrix3x4d Subtract(Matrix3x4d left, Matrix3x4d right)
		{
			Matrix3x4d result;
			Matrix3x4d.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000E0D0 File Offset: 0x0000C2D0
		public static void Subtract(ref Matrix3x4d left, ref Matrix3x4d right, out Matrix3x4d result)
		{
			result.Row0 = left.Row0 - right.Row0;
			result.Row1 = left.Row1 - right.Row1;
			result.Row2 = left.Row2 - right.Row2;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000E124 File Offset: 0x0000C324
		public static Matrix3x4d Invert(Matrix3x4d mat)
		{
			Matrix3x4d result;
			Matrix3x4d.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000E13C File Offset: 0x0000C33C
		public static void Invert(ref Matrix3x4d mat, out Matrix3x4d result)
		{
			Matrix3d matrix3d = new Matrix3d(mat.Column0, mat.Column1, mat.Column2);
			matrix3d.Row0 /= matrix3d.Row0.LengthSquared;
			matrix3d.Row1 /= matrix3d.Row1.LengthSquared;
			matrix3d.Row2 /= matrix3d.Row2.LengthSquared;
			Vector3d right = new Vector3d(mat.Row0.W, mat.Row1.W, mat.Row2.W);
			result.Row0 = new Vector4d(matrix3d.Row0, -Vector3d.Dot(matrix3d.Row0, right));
			result.Row1 = new Vector4d(matrix3d.Row1, -Vector3d.Dot(matrix3d.Row1, right));
			result.Row2 = new Vector4d(matrix3d.Row2, -Vector3d.Dot(matrix3d.Row2, right));
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000E244 File Offset: 0x0000C444
		public static Matrix4x3d Transpose(Matrix3x4d mat)
		{
			return new Matrix4x3d(mat.Column0, mat.Column1, mat.Column2, mat.Column3);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000E268 File Offset: 0x0000C468
		public static void Transpose(ref Matrix3x4d mat, out Matrix4x3d result)
		{
			result.Row0 = mat.Column0;
			result.Row1 = mat.Column1;
			result.Row2 = mat.Column2;
			result.Row3 = mat.Column3;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000E29C File Offset: 0x0000C49C
		public static Matrix3d operator *(Matrix3x4d left, Matrix4x3d right)
		{
			return Matrix3x4d.Mult(left, right);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000E2A8 File Offset: 0x0000C4A8
		public static Matrix3x4d operator *(Matrix3x4d left, Matrix3x4d right)
		{
			return Matrix3x4d.Mult(left, right);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000E2B4 File Offset: 0x0000C4B4
		public static Matrix3x4d operator *(Matrix3x4d left, double right)
		{
			return Matrix3x4d.Mult(left, right);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000E2C0 File Offset: 0x0000C4C0
		public static Matrix3x4d operator +(Matrix3x4d left, Matrix3x4d right)
		{
			return Matrix3x4d.Add(left, right);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000E2CC File Offset: 0x0000C4CC
		public static Matrix3x4d operator -(Matrix3x4d left, Matrix3x4d right)
		{
			return Matrix3x4d.Subtract(left, right);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000E2D8 File Offset: 0x0000C4D8
		public static bool operator ==(Matrix3x4d left, Matrix3x4d right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000E2E4 File Offset: 0x0000C4E4
		public static bool operator !=(Matrix3x4d left, Matrix3x4d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000E2F4 File Offset: 0x0000C4F4
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", this.Row0, this.Row1, this.Row2);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000E324 File Offset: 0x0000C524
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode();
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000E35C File Offset: 0x0000C55C
		public override bool Equals(object obj)
		{
			return obj is Matrix3x4d && this.Equals((Matrix3x4d)obj);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000E374 File Offset: 0x0000C574
		public bool Equals(Matrix3x4d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2;
		}

		// Token: 0x04000093 RID: 147
		public Vector4d Row0;

		// Token: 0x04000094 RID: 148
		public Vector4d Row1;

		// Token: 0x04000095 RID: 149
		public Vector4d Row2;

		// Token: 0x04000096 RID: 150
		public static Matrix3x4d Zero = new Matrix3x4d(Vector4d.Zero, Vector4d.Zero, Vector4d.Zero);
	}
}
