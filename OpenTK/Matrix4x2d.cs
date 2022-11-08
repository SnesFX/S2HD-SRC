using System;

namespace OpenTK
{
	// Token: 0x02000021 RID: 33
	public struct Matrix4x2d : IEquatable<Matrix4x2d>
	{
		// Token: 0x06000394 RID: 916 RVA: 0x0000F5D0 File Offset: 0x0000D7D0
		public Matrix4x2d(Vector2d row0, Vector2d row1, Vector2d row2, Vector2d row3)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
			this.Row3 = row3;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000F5F0 File Offset: 0x0000D7F0
		public Matrix4x2d(double m00, double m01, double m10, double m11, double m20, double m21, double m30, double m31)
		{
			this.Row0 = new Vector2d(m00, m01);
			this.Row1 = new Vector2d(m10, m11);
			this.Row2 = new Vector2d(m20, m21);
			this.Row3 = new Vector2d(m30, m31);
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000396 RID: 918 RVA: 0x0000F62C File Offset: 0x0000D82C
		// (set) Token: 0x06000397 RID: 919 RVA: 0x0000F660 File Offset: 0x0000D860
		public Vector4d Column0
		{
			get
			{
				return new Vector4d(this.Row0.X, this.Row1.X, this.Row2.X, this.Row3.X);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.X = value.Y;
				this.Row2.X = value.Z;
				this.Row3.X = value.W;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000398 RID: 920 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0000F6EC File Offset: 0x0000D8EC
		public Vector4d Column1
		{
			get
			{
				return new Vector4d(this.Row0.Y, this.Row1.Y, this.Row2.Y, this.Row3.X);
			}
			set
			{
				this.Row0.Y = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Y = value.Z;
				this.Row3.Y = value.W;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600039A RID: 922 RVA: 0x0000F744 File Offset: 0x0000D944
		// (set) Token: 0x0600039B RID: 923 RVA: 0x0000F754 File Offset: 0x0000D954
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

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600039C RID: 924 RVA: 0x0000F764 File Offset: 0x0000D964
		// (set) Token: 0x0600039D RID: 925 RVA: 0x0000F774 File Offset: 0x0000D974
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

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600039E RID: 926 RVA: 0x0000F784 File Offset: 0x0000D984
		// (set) Token: 0x0600039F RID: 927 RVA: 0x0000F794 File Offset: 0x0000D994
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

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x0000F7A4 File Offset: 0x0000D9A4
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x0000F7B4 File Offset: 0x0000D9B4
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

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x0000F7C4 File Offset: 0x0000D9C4
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x0000F7D4 File Offset: 0x0000D9D4
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

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x0000F7E4 File Offset: 0x0000D9E4
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x0000F7F4 File Offset: 0x0000D9F4
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

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x0000F804 File Offset: 0x0000DA04
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x0000F814 File Offset: 0x0000DA14
		public double M41
		{
			get
			{
				return this.Row3.X;
			}
			set
			{
				this.Row3.X = value;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x0000F824 File Offset: 0x0000DA24
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x0000F834 File Offset: 0x0000DA34
		public double M42
		{
			get
			{
				return this.Row3.Y;
			}
			set
			{
				this.Row3.Y = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060003AA RID: 938 RVA: 0x0000F844 File Offset: 0x0000DA44
		// (set) Token: 0x060003AB RID: 939 RVA: 0x0000F864 File Offset: 0x0000DA64
		public Vector2d Diagonal
		{
			get
			{
				return new Vector2d(this.Row0.X, this.Row1.Y);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.Y = value.Y;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060003AC RID: 940 RVA: 0x0000F88C File Offset: 0x0000DA8C
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x170000C8 RID: 200
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
				if (rowIndex == 3)
				{
					return this.Row3[columnIndex];
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
				if (rowIndex == 3)
				{
					this.Row3[columnIndex] = value;
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

		// Token: 0x060003AF RID: 943 RVA: 0x0000F9C4 File Offset: 0x0000DBC4
		public static void CreateRotation(double angle, out Matrix4x2d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000FA64 File Offset: 0x0000DC64
		public static Matrix4x2d CreateRotation(double angle)
		{
			Matrix4x2d result;
			Matrix4x2d.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000FA7C File Offset: 0x0000DC7C
		public static void CreateScale(double scale, out Matrix4x2d result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000FB1C File Offset: 0x0000DD1C
		public static Matrix4x2d CreateScale(double scale)
		{
			Matrix4x2d result;
			Matrix4x2d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000FB34 File Offset: 0x0000DD34
		public static void CreateScale(Vector2d scale, out Matrix4x2d result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale.Y;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000FBE0 File Offset: 0x0000DDE0
		public static Matrix4x2d CreateScale(Vector2d scale)
		{
			Matrix4x2d result;
			Matrix4x2d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000FBF8 File Offset: 0x0000DDF8
		public static void CreateScale(double x, double y, out Matrix4x2d result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = y;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000FC98 File Offset: 0x0000DE98
		public static Matrix4x2d CreateScale(double x, double y)
		{
			Matrix4x2d result;
			Matrix4x2d.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000FCB0 File Offset: 0x0000DEB0
		public static void Mult(ref Matrix4x2d left, double right, out Matrix4x2d result)
		{
			result.Row0.X = left.Row0.X * right;
			result.Row0.Y = left.Row0.Y * right;
			result.Row1.X = left.Row1.X * right;
			result.Row1.Y = left.Row1.Y * right;
			result.Row2.X = left.Row2.X * right;
			result.Row2.Y = left.Row2.Y * right;
			result.Row3.X = left.Row3.X * right;
			result.Row3.Y = left.Row3.Y * right;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000FD80 File Offset: 0x0000DF80
		public static Matrix4x2d Mult(Matrix4x2d left, double right)
		{
			Matrix4x2d result;
			Matrix4x2d.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000FD98 File Offset: 0x0000DF98
		public static void Mult(ref Matrix4x2d left, ref Matrix2d right, out Matrix4x2d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double x4 = left.Row3.X;
			double y4 = left.Row3.Y;
			double x5 = right.Row0.X;
			double y5 = right.Row0.Y;
			double x6 = right.Row1.X;
			double y6 = right.Row1.Y;
			result.Row0.X = x * x5 + y * x6;
			result.Row0.Y = x * y5 + y * y6;
			result.Row1.X = x2 * x5 + y2 * x6;
			result.Row1.Y = x2 * y5 + y2 * y6;
			result.Row2.X = x3 * x5 + y3 * x6;
			result.Row2.Y = x3 * y5 + y3 * y6;
			result.Row3.X = x4 * x5 + y4 * x6;
			result.Row3.Y = x4 * y5 + y4 * y6;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000FEE8 File Offset: 0x0000E0E8
		public static Matrix4x2d Mult(Matrix4x2d left, Matrix2d right)
		{
			Matrix4x2d result;
			Matrix4x2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000FF04 File Offset: 0x0000E104
		public static void Mult(ref Matrix4x2d left, ref Matrix2x3d right, out Matrix4x3d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double x4 = left.Row3.X;
			double y4 = left.Row3.Y;
			double x5 = right.Row0.X;
			double y5 = right.Row0.Y;
			double z = right.Row0.Z;
			double x6 = right.Row1.X;
			double y6 = right.Row1.Y;
			double z2 = right.Row1.Z;
			result.Row0.X = x * x5 + y * x6;
			result.Row0.Y = x * y5 + y * y6;
			result.Row0.Z = x * z + y * z2;
			result.Row1.X = x2 * x5 + y2 * x6;
			result.Row1.Y = x2 * y5 + y2 * y6;
			result.Row1.Z = x2 * z + y2 * z2;
			result.Row2.X = x3 * x5 + y3 * x6;
			result.Row2.Y = x3 * y5 + y3 * y6;
			result.Row2.Z = x3 * z + y3 * z2;
			result.Row3.X = x4 * x5 + y4 * x6;
			result.Row3.Y = x4 * y5 + y4 * y6;
			result.Row3.Z = x4 * z + y4 * z2;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x000100C0 File Offset: 0x0000E2C0
		public static Matrix4x3d Mult(Matrix4x2d left, Matrix2x3d right)
		{
			Matrix4x3d result;
			Matrix4x2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000100DC File Offset: 0x0000E2DC
		public static void Mult(ref Matrix4x2d left, ref Matrix2x4d right, out Matrix4d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double x4 = left.Row3.X;
			double y4 = left.Row3.Y;
			double x5 = right.Row0.X;
			double y5 = right.Row0.Y;
			double z = right.Row0.Z;
			double w = right.Row0.W;
			double x6 = right.Row1.X;
			double y6 = right.Row1.Y;
			double z2 = right.Row1.Z;
			double w2 = right.Row1.W;
			result.Row0.X = x * x5 + y * x6;
			result.Row0.Y = x * y5 + y * y6;
			result.Row0.Z = x * z + y * z2;
			result.Row0.W = x * w + y * w2;
			result.Row1.X = x2 * x5 + y2 * x6;
			result.Row1.Y = x2 * y5 + y2 * y6;
			result.Row1.Z = x2 * z + y2 * z2;
			result.Row1.W = x2 * w + y2 * w2;
			result.Row2.X = x3 * x5 + y3 * x6;
			result.Row2.Y = x3 * y5 + y3 * y6;
			result.Row2.Z = x3 * z + y3 * z2;
			result.Row2.W = x3 * w + y3 * w2;
			result.Row3.X = x4 * x5 + y4 * x6;
			result.Row3.Y = x4 * y5 + y4 * y6;
			result.Row3.Z = x4 * z + y4 * z2;
			result.Row3.W = x4 * w + y4 * w2;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00010308 File Offset: 0x0000E508
		public static Matrix4d Mult(Matrix4x2d left, Matrix2x4d right)
		{
			Matrix4d result;
			Matrix4x2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00010324 File Offset: 0x0000E524
		public static void Add(ref Matrix4x2d left, ref Matrix4x2d right, out Matrix4x2d result)
		{
			result.Row0.X = left.Row0.X + right.Row0.X;
			result.Row0.Y = left.Row0.Y + right.Row0.Y;
			result.Row1.X = left.Row1.X + right.Row1.X;
			result.Row1.Y = left.Row1.Y + right.Row1.Y;
			result.Row2.X = left.Row2.X + right.Row2.X;
			result.Row2.Y = left.Row2.Y + right.Row2.Y;
			result.Row3.X = left.Row3.X + right.Row3.X;
			result.Row3.Y = left.Row3.Y + right.Row3.Y;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00010444 File Offset: 0x0000E644
		public static Matrix4x2d Add(Matrix4x2d left, Matrix4x2d right)
		{
			Matrix4x2d result;
			Matrix4x2d.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x00010460 File Offset: 0x0000E660
		public static void Subtract(ref Matrix4x2d left, ref Matrix4x2d right, out Matrix4x2d result)
		{
			result.Row0.X = left.Row0.X - right.Row0.X;
			result.Row0.Y = left.Row0.Y - right.Row0.Y;
			result.Row1.X = left.Row1.X - right.Row1.X;
			result.Row1.Y = left.Row1.Y - right.Row1.Y;
			result.Row2.X = left.Row2.X - right.Row2.X;
			result.Row2.Y = left.Row2.Y - right.Row2.Y;
			result.Row3.X = left.Row3.X - right.Row3.X;
			result.Row3.Y = left.Row3.Y - right.Row3.Y;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00010580 File Offset: 0x0000E780
		public static Matrix4x2d Subtract(Matrix4x2d left, Matrix4x2d right)
		{
			Matrix4x2d result;
			Matrix4x2d.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x0001059C File Offset: 0x0000E79C
		public static void Transpose(ref Matrix4x2d mat, out Matrix2x4d result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row0.Z = mat.Row2.X;
			result.Row0.W = mat.Row3.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
			result.Row1.Z = mat.Row2.Y;
			result.Row1.W = mat.Row3.Y;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0001065C File Offset: 0x0000E85C
		public static Matrix2x4d Transpose(Matrix4x2d mat)
		{
			Matrix2x4d result;
			Matrix4x2d.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00010674 File Offset: 0x0000E874
		public static Matrix4x2d operator *(double left, Matrix4x2d right)
		{
			return Matrix4x2d.Mult(right, left);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00010680 File Offset: 0x0000E880
		public static Matrix4x2d operator *(Matrix4x2d left, double right)
		{
			return Matrix4x2d.Mult(left, right);
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0001068C File Offset: 0x0000E88C
		public static Matrix4x2d operator *(Matrix4x2d left, Matrix2d right)
		{
			return Matrix4x2d.Mult(left, right);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00010698 File Offset: 0x0000E898
		public static Matrix4x3d operator *(Matrix4x2d left, Matrix2x3d right)
		{
			return Matrix4x2d.Mult(left, right);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x000106A4 File Offset: 0x0000E8A4
		public static Matrix4d operator *(Matrix4x2d left, Matrix2x4d right)
		{
			return Matrix4x2d.Mult(left, right);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x000106B0 File Offset: 0x0000E8B0
		public static Matrix4x2d operator +(Matrix4x2d left, Matrix4x2d right)
		{
			return Matrix4x2d.Add(left, right);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x000106BC File Offset: 0x0000E8BC
		public static Matrix4x2d operator -(Matrix4x2d left, Matrix4x2d right)
		{
			return Matrix4x2d.Subtract(left, right);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000106C8 File Offset: 0x0000E8C8
		public static bool operator ==(Matrix4x2d left, Matrix4x2d right)
		{
			return left.Equals(right);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x000106D4 File Offset: 0x0000E8D4
		public static bool operator !=(Matrix4x2d left, Matrix4x2d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x000106E4 File Offset: 0x0000E8E4
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}\n{3}", new object[]
			{
				this.Row0,
				this.Row1,
				this.Row2,
				this.Row3
			});
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001073C File Offset: 0x0000E93C
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode() ^ this.Row3.GetHashCode();
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00010790 File Offset: 0x0000E990
		public override bool Equals(object obj)
		{
			return obj is Matrix4x2d && this.Equals((Matrix4x2d)obj);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x000107A8 File Offset: 0x0000E9A8
		public bool Equals(Matrix4x2d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2 && this.Row3 == other.Row3;
		}

		// Token: 0x0400009C RID: 156
		public Vector2d Row0;

		// Token: 0x0400009D RID: 157
		public Vector2d Row1;

		// Token: 0x0400009E RID: 158
		public Vector2d Row2;

		// Token: 0x0400009F RID: 159
		public Vector2d Row3;

		// Token: 0x040000A0 RID: 160
		public static readonly Matrix4x2d Zero = new Matrix4x2d(Vector2d.Zero, Vector2d.Zero, Vector2d.Zero, Vector2d.Zero);
	}
}
