using System;

namespace OpenTK
{
	// Token: 0x0200052A RID: 1322
	[Serializable]
	public struct Matrix3d : IEquatable<Matrix3d>
	{
		// Token: 0x06003E24 RID: 15908 RVA: 0x000A34C0 File Offset: 0x000A16C0
		public Matrix3d(Vector3d row0, Vector3d row1, Vector3d row2)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
		}

		// Token: 0x06003E25 RID: 15909 RVA: 0x000A34D8 File Offset: 0x000A16D8
		public Matrix3d(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22)
		{
			this.Row0 = new Vector3d(m00, m01, m02);
			this.Row1 = new Vector3d(m10, m11, m12);
			this.Row2 = new Vector3d(m20, m21, m22);
		}

		// Token: 0x06003E26 RID: 15910 RVA: 0x000A350C File Offset: 0x000A170C
		public Matrix3d(Matrix4d matrix)
		{
			this.Row0 = matrix.Row0.Xyz;
			this.Row1 = matrix.Row1.Xyz;
			this.Row2 = matrix.Row2.Xyz;
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06003E27 RID: 15911 RVA: 0x000A3544 File Offset: 0x000A1744
		public double Determinant
		{
			get
			{
				double x = this.Row0.X;
				double y = this.Row0.Y;
				double z = this.Row0.Z;
				double x2 = this.Row1.X;
				double y2 = this.Row1.Y;
				double z2 = this.Row1.Z;
				double x3 = this.Row2.X;
				double y3 = this.Row2.Y;
				double z3 = this.Row2.Z;
				return x * y2 * z3 + y * z2 * x3 + z * x2 * y3 - z * y2 * x3 - x * z2 * y3 - y * x2 * z3;
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06003E28 RID: 15912 RVA: 0x000A35F0 File Offset: 0x000A17F0
		public Vector3d Column0
		{
			get
			{
				return new Vector3d(this.Row0.X, this.Row1.X, this.Row2.X);
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06003E29 RID: 15913 RVA: 0x000A3618 File Offset: 0x000A1818
		public Vector3d Column1
		{
			get
			{
				return new Vector3d(this.Row0.Y, this.Row1.Y, this.Row2.Y);
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06003E2A RID: 15914 RVA: 0x000A3640 File Offset: 0x000A1840
		public Vector3d Column2
		{
			get
			{
				return new Vector3d(this.Row0.Z, this.Row1.Z, this.Row2.Z);
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06003E2B RID: 15915 RVA: 0x000A3668 File Offset: 0x000A1868
		// (set) Token: 0x06003E2C RID: 15916 RVA: 0x000A3678 File Offset: 0x000A1878
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

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06003E2D RID: 15917 RVA: 0x000A3688 File Offset: 0x000A1888
		// (set) Token: 0x06003E2E RID: 15918 RVA: 0x000A3698 File Offset: 0x000A1898
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

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06003E2F RID: 15919 RVA: 0x000A36A8 File Offset: 0x000A18A8
		// (set) Token: 0x06003E30 RID: 15920 RVA: 0x000A36B8 File Offset: 0x000A18B8
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

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06003E31 RID: 15921 RVA: 0x000A36C8 File Offset: 0x000A18C8
		// (set) Token: 0x06003E32 RID: 15922 RVA: 0x000A36D8 File Offset: 0x000A18D8
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

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06003E33 RID: 15923 RVA: 0x000A36E8 File Offset: 0x000A18E8
		// (set) Token: 0x06003E34 RID: 15924 RVA: 0x000A36F8 File Offset: 0x000A18F8
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

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06003E35 RID: 15925 RVA: 0x000A3708 File Offset: 0x000A1908
		// (set) Token: 0x06003E36 RID: 15926 RVA: 0x000A3718 File Offset: 0x000A1918
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

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06003E37 RID: 15927 RVA: 0x000A3728 File Offset: 0x000A1928
		// (set) Token: 0x06003E38 RID: 15928 RVA: 0x000A3738 File Offset: 0x000A1938
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

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06003E39 RID: 15929 RVA: 0x000A3748 File Offset: 0x000A1948
		// (set) Token: 0x06003E3A RID: 15930 RVA: 0x000A3758 File Offset: 0x000A1958
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

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06003E3B RID: 15931 RVA: 0x000A3768 File Offset: 0x000A1968
		// (set) Token: 0x06003E3C RID: 15932 RVA: 0x000A3778 File Offset: 0x000A1978
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

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06003E3D RID: 15933 RVA: 0x000A3788 File Offset: 0x000A1988
		// (set) Token: 0x06003E3E RID: 15934 RVA: 0x000A37B0 File Offset: 0x000A19B0
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

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06003E3F RID: 15935 RVA: 0x000A37E8 File Offset: 0x000A19E8
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y + this.Row2.Z;
			}
		}

		// Token: 0x170002D2 RID: 722
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

		// Token: 0x06003E42 RID: 15938 RVA: 0x000A390C File Offset: 0x000A1B0C
		public void Invert()
		{
			this = Matrix3d.Invert(this);
		}

		// Token: 0x06003E43 RID: 15939 RVA: 0x000A3920 File Offset: 0x000A1B20
		public void Transpose()
		{
			this = Matrix3d.Transpose(this);
		}

		// Token: 0x06003E44 RID: 15940 RVA: 0x000A3934 File Offset: 0x000A1B34
		public Matrix3d Normalized()
		{
			Matrix3d result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06003E45 RID: 15941 RVA: 0x000A3950 File Offset: 0x000A1B50
		public void Normalize()
		{
			double determinant = this.Determinant;
			this.Row0 /= determinant;
			this.Row1 /= determinant;
			this.Row2 /= determinant;
		}

		// Token: 0x06003E46 RID: 15942 RVA: 0x000A399C File Offset: 0x000A1B9C
		public Matrix3d Inverted()
		{
			Matrix3d result = this;
			if (result.Determinant != 0.0)
			{
				result.Invert();
			}
			return result;
		}

		// Token: 0x06003E47 RID: 15943 RVA: 0x000A39CC File Offset: 0x000A1BCC
		public Matrix3d ClearScale()
		{
			Matrix3d result = this;
			result.Row0 = result.Row0.Normalized();
			result.Row1 = result.Row1.Normalized();
			result.Row2 = result.Row2.Normalized();
			return result;
		}

		// Token: 0x06003E48 RID: 15944 RVA: 0x000A3A1C File Offset: 0x000A1C1C
		public Matrix3d ClearRotation()
		{
			Matrix3d result = this;
			result.Row0 = new Vector3d(result.Row0.Length, 0.0, 0.0);
			result.Row1 = new Vector3d(0.0, result.Row1.Length, 0.0);
			result.Row2 = new Vector3d(0.0, 0.0, result.Row2.Length);
			return result;
		}

		// Token: 0x06003E49 RID: 15945 RVA: 0x000A3AB0 File Offset: 0x000A1CB0
		public Vector3d ExtractScale()
		{
			return new Vector3d(this.Row0.Length, this.Row1.Length, this.Row2.Length);
		}

		// Token: 0x06003E4A RID: 15946 RVA: 0x000A3AD8 File Offset: 0x000A1CD8
		public Quaterniond ExtractRotation(bool row_normalise = true)
		{
			Vector3d vector3d = this.Row0;
			Vector3d vector3d2 = this.Row1;
			Vector3d vector3d3 = this.Row2;
			if (row_normalise)
			{
				vector3d = vector3d.Normalized();
				vector3d2 = vector3d2.Normalized();
				vector3d3 = vector3d3.Normalized();
			}
			Quaterniond result = default(Quaterniond);
			double num = 0.25 * (vector3d[0] + vector3d2[1] + vector3d3[2] + 1.0);
			if (num > 0.0)
			{
				double num2 = Math.Sqrt(num);
				result.W = num2;
				num2 = 1.0 / (4.0 * num2);
				result.X = (vector3d2[2] - vector3d3[1]) * num2;
				result.Y = (vector3d3[0] - vector3d[2]) * num2;
				result.Z = (vector3d[1] - vector3d2[0]) * num2;
			}
			else if (vector3d[0] > vector3d2[1] && vector3d[0] > vector3d3[2])
			{
				double num3 = 2.0 * Math.Sqrt(1.0 + vector3d[0] - vector3d2[1] - vector3d3[2]);
				result.X = 0.25 * num3;
				num3 = 1.0 / num3;
				result.W = (vector3d3[1] - vector3d2[2]) * num3;
				result.Y = (vector3d2[0] + vector3d[1]) * num3;
				result.Z = (vector3d3[0] + vector3d[2]) * num3;
			}
			else if (vector3d2[1] > vector3d3[2])
			{
				double num4 = 2.0 * Math.Sqrt(1.0 + vector3d2[1] - vector3d[0] - vector3d3[2]);
				result.Y = 0.25 * num4;
				num4 = 1.0 / num4;
				result.W = (vector3d3[0] - vector3d[2]) * num4;
				result.X = (vector3d2[0] + vector3d[1]) * num4;
				result.Z = (vector3d3[1] + vector3d2[2]) * num4;
			}
			else
			{
				double num5 = 2.0 * Math.Sqrt(1.0 + vector3d3[2] - vector3d[0] - vector3d2[1]);
				result.Z = 0.25 * num5;
				num5 = 1.0 / num5;
				result.W = (vector3d2[0] - vector3d[1]) * num5;
				result.X = (vector3d3[0] + vector3d[2]) * num5;
				result.Y = (vector3d3[1] + vector3d2[2]) * num5;
			}
			result.Normalize();
			return result;
		}

		// Token: 0x06003E4B RID: 15947 RVA: 0x000A3E24 File Offset: 0x000A2024
		public static void CreateFromAxisAngle(Vector3d axis, double angle, out Matrix3d result)
		{
			axis.Normalize();
			double x = axis.X;
			double y = axis.Y;
			double z = axis.Z;
			double num = Math.Cos(-angle);
			double num2 = Math.Sin(-angle);
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
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num;
			result.Row1.Z = num8 - num10;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num;
		}

		// Token: 0x06003E4C RID: 15948 RVA: 0x000A3F40 File Offset: 0x000A2140
		public static Matrix3d CreateFromAxisAngle(Vector3d axis, double angle)
		{
			Matrix3d result;
			Matrix3d.CreateFromAxisAngle(axis, angle, out result);
			return result;
		}

		// Token: 0x06003E4D RID: 15949 RVA: 0x000A3F58 File Offset: 0x000A2158
		public static void CreateFromQuaternion(ref Quaterniond q, out Matrix3d result)
		{
			Vector3d axis;
			double angle;
			q.ToAxisAngle(out axis, out angle);
			Matrix3d.CreateFromAxisAngle(axis, angle, out result);
		}

		// Token: 0x06003E4E RID: 15950 RVA: 0x000A3F78 File Offset: 0x000A2178
		public static Matrix3d CreateFromQuaternion(Quaterniond q)
		{
			Matrix3d result;
			Matrix3d.CreateFromQuaternion(ref q, out result);
			return result;
		}

		// Token: 0x06003E4F RID: 15951 RVA: 0x000A3F90 File Offset: 0x000A2190
		public static void CreateRotationX(double angle, out Matrix3d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result = Matrix3d.Identity;
			result.Row1.Y = num;
			result.Row1.Z = num2;
			result.Row2.Y = -num2;
			result.Row2.Z = num;
		}

		// Token: 0x06003E50 RID: 15952 RVA: 0x000A3FE8 File Offset: 0x000A21E8
		public static Matrix3d CreateRotationX(double angle)
		{
			Matrix3d result;
			Matrix3d.CreateRotationX(angle, out result);
			return result;
		}

		// Token: 0x06003E51 RID: 15953 RVA: 0x000A4000 File Offset: 0x000A2200
		public static void CreateRotationY(double angle, out Matrix3d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result = Matrix3d.Identity;
			result.Row0.X = num;
			result.Row0.Z = -num2;
			result.Row2.X = num2;
			result.Row2.Z = num;
		}

		// Token: 0x06003E52 RID: 15954 RVA: 0x000A4058 File Offset: 0x000A2258
		public static Matrix3d CreateRotationY(double angle)
		{
			Matrix3d result;
			Matrix3d.CreateRotationY(angle, out result);
			return result;
		}

		// Token: 0x06003E53 RID: 15955 RVA: 0x000A4070 File Offset: 0x000A2270
		public static void CreateRotationZ(double angle, out Matrix3d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result = Matrix3d.Identity;
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
		}

		// Token: 0x06003E54 RID: 15956 RVA: 0x000A40C8 File Offset: 0x000A22C8
		public static Matrix3d CreateRotationZ(double angle)
		{
			Matrix3d result;
			Matrix3d.CreateRotationZ(angle, out result);
			return result;
		}

		// Token: 0x06003E55 RID: 15957 RVA: 0x000A40E0 File Offset: 0x000A22E0
		public static Matrix3d CreateScale(double scale)
		{
			Matrix3d result;
			Matrix3d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06003E56 RID: 15958 RVA: 0x000A40F8 File Offset: 0x000A22F8
		public static Matrix3d CreateScale(Vector3d scale)
		{
			Matrix3d result;
			Matrix3d.CreateScale(ref scale, out result);
			return result;
		}

		// Token: 0x06003E57 RID: 15959 RVA: 0x000A4110 File Offset: 0x000A2310
		public static Matrix3d CreateScale(double x, double y, double z)
		{
			Matrix3d result;
			Matrix3d.CreateScale(x, y, z, out result);
			return result;
		}

		// Token: 0x06003E58 RID: 15960 RVA: 0x000A4128 File Offset: 0x000A2328
		public static void CreateScale(double scale, out Matrix3d result)
		{
			result = Matrix3d.Identity;
			result.Row0.X = scale;
			result.Row1.Y = scale;
			result.Row2.Z = scale;
		}

		// Token: 0x06003E59 RID: 15961 RVA: 0x000A415C File Offset: 0x000A235C
		public static void CreateScale(ref Vector3d scale, out Matrix3d result)
		{
			result = Matrix3d.Identity;
			result.Row0.X = scale.X;
			result.Row1.Y = scale.Y;
			result.Row2.Z = scale.Z;
		}

		// Token: 0x06003E5A RID: 15962 RVA: 0x000A419C File Offset: 0x000A239C
		public static void CreateScale(double x, double y, double z, out Matrix3d result)
		{
			result = Matrix3d.Identity;
			result.Row0.X = x;
			result.Row1.Y = y;
			result.Row2.Z = z;
		}

		// Token: 0x06003E5B RID: 15963 RVA: 0x000A41D0 File Offset: 0x000A23D0
		public static Matrix3d Mult(Matrix3d left, Matrix3d right)
		{
			Matrix3d result;
			Matrix3d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06003E5C RID: 15964 RVA: 0x000A41EC File Offset: 0x000A23EC
		public static void Mult(ref Matrix3d left, ref Matrix3d right, out Matrix3d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double z3 = left.Row2.Z;
			double x4 = right.Row0.X;
			double y4 = right.Row0.Y;
			double z4 = right.Row0.Z;
			double x5 = right.Row1.X;
			double y5 = right.Row1.Y;
			double z5 = right.Row1.Z;
			double x6 = right.Row2.X;
			double y6 = right.Row2.Y;
			double z6 = right.Row2.Z;
			result.Row0.X = x * x4 + y * x5 + z * x6;
			result.Row0.Y = x * y4 + y * y5 + z * y6;
			result.Row0.Z = x * z4 + y * z5 + z * z6;
			result.Row1.X = x2 * x4 + y2 * x5 + z2 * x6;
			result.Row1.Y = x2 * y4 + y2 * y5 + z2 * y6;
			result.Row1.Z = x2 * z4 + y2 * z5 + z2 * z6;
			result.Row2.X = x3 * x4 + y3 * x5 + z3 * x6;
			result.Row2.Y = x3 * y4 + y3 * y5 + z3 * y6;
			result.Row2.Z = x3 * z4 + y3 * z5 + z3 * z6;
		}

		// Token: 0x06003E5D RID: 15965 RVA: 0x000A43D0 File Offset: 0x000A25D0
		public static void Invert(ref Matrix3d mat, out Matrix3d result)
		{
			int[] array = new int[3];
			int[] array2 = array;
			int[] array3 = new int[3];
			int[] array4 = array3;
			int[] array5 = new int[]
			{
				-1,
				-1,
				-1
			};
			double[,] array6 = new double[3, 3];
			array6[0, 0] = mat.Row0.X;
			array6[0, 1] = mat.Row0.Y;
			array6[0, 2] = mat.Row0.Z;
			array6[1, 0] = mat.Row1.X;
			array6[1, 1] = mat.Row1.Y;
			array6[1, 2] = mat.Row1.Z;
			array6[2, 0] = mat.Row2.X;
			array6[2, 1] = mat.Row2.Y;
			array6[2, 2] = mat.Row2.Z;
			double[,] array7 = array6;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 3; i++)
			{
				double num3 = 0.0;
				for (int j = 0; j < 3; j++)
				{
					if (array5[j] != 0)
					{
						for (int k = 0; k < 3; k++)
						{
							if (array5[k] == -1)
							{
								double num4 = Math.Abs(array7[j, k]);
								if (num4 > num3)
								{
									num3 = num4;
									num2 = j;
									num = k;
								}
							}
							else if (array5[k] > 0)
							{
								result = mat;
								return;
							}
						}
					}
				}
				array5[num]++;
				if (num2 != num)
				{
					for (int l = 0; l < 3; l++)
					{
						double num5 = array7[num2, l];
						array7[num2, l] = array7[num, l];
						array7[num, l] = num5;
					}
				}
				array4[i] = num2;
				array2[i] = num;
				double num6 = array7[num, num];
				if (num6 == 0.0)
				{
					throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
				}
				double num7 = 1.0 / num6;
				array7[num, num] = 1.0;
				for (int m = 0; m < 3; m++)
				{
					array7[num, m] *= num7;
				}
				for (int n = 0; n < 3; n++)
				{
					if (num != n)
					{
						double num8 = array7[n, num];
						array7[n, num] = 0.0;
						for (int num9 = 0; num9 < 3; num9++)
						{
							array7[n, num9] -= array7[num, num9] * num8;
						}
					}
				}
			}
			for (int num10 = 2; num10 >= 0; num10--)
			{
				int num11 = array4[num10];
				int num12 = array2[num10];
				for (int num13 = 0; num13 < 3; num13++)
				{
					double num14 = array7[num13, num11];
					array7[num13, num11] = array7[num13, num12];
					array7[num13, num12] = num14;
				}
			}
			result.Row0.X = array7[0, 0];
			result.Row0.Y = array7[0, 1];
			result.Row0.Z = array7[0, 2];
			result.Row1.X = array7[1, 0];
			result.Row1.Y = array7[1, 1];
			result.Row1.Z = array7[1, 2];
			result.Row2.X = array7[2, 0];
			result.Row2.Y = array7[2, 1];
			result.Row2.Z = array7[2, 2];
		}

		// Token: 0x06003E5E RID: 15966 RVA: 0x000A4790 File Offset: 0x000A2990
		public static Matrix3d Invert(Matrix3d mat)
		{
			Matrix3d result;
			Matrix3d.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x06003E5F RID: 15967 RVA: 0x000A47A8 File Offset: 0x000A29A8
		public static Matrix3d Transpose(Matrix3d mat)
		{
			return new Matrix3d(mat.Column0, mat.Column1, mat.Column2);
		}

		// Token: 0x06003E60 RID: 15968 RVA: 0x000A47C4 File Offset: 0x000A29C4
		public static void Transpose(ref Matrix3d mat, out Matrix3d result)
		{
			result.Row0 = mat.Column0;
			result.Row1 = mat.Column1;
			result.Row2 = mat.Column2;
		}

		// Token: 0x06003E61 RID: 15969 RVA: 0x000A47EC File Offset: 0x000A29EC
		public static Matrix3d operator *(Matrix3d left, Matrix3d right)
		{
			return Matrix3d.Mult(left, right);
		}

		// Token: 0x06003E62 RID: 15970 RVA: 0x000A47F8 File Offset: 0x000A29F8
		public static bool operator ==(Matrix3d left, Matrix3d right)
		{
			return left.Equals(right);
		}

		// Token: 0x06003E63 RID: 15971 RVA: 0x000A4804 File Offset: 0x000A2A04
		public static bool operator !=(Matrix3d left, Matrix3d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06003E64 RID: 15972 RVA: 0x000A4814 File Offset: 0x000A2A14
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", this.Row0, this.Row1, this.Row2);
		}

		// Token: 0x06003E65 RID: 15973 RVA: 0x000A4844 File Offset: 0x000A2A44
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode();
		}

		// Token: 0x06003E66 RID: 15974 RVA: 0x000A487C File Offset: 0x000A2A7C
		public override bool Equals(object obj)
		{
			return obj is Matrix3d && this.Equals((Matrix3d)obj);
		}

		// Token: 0x06003E67 RID: 15975 RVA: 0x000A4894 File Offset: 0x000A2A94
		public bool Equals(Matrix3d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2;
		}

		// Token: 0x04004DE8 RID: 19944
		public Vector3d Row0;

		// Token: 0x04004DE9 RID: 19945
		public Vector3d Row1;

		// Token: 0x04004DEA RID: 19946
		public Vector3d Row2;

		// Token: 0x04004DEB RID: 19947
		public static Matrix3d Identity = new Matrix3d(Vector3d.UnitX, Vector3d.UnitY, Vector3d.UnitZ);
	}
}
