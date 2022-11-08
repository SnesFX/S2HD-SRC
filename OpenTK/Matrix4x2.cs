using System;

namespace OpenTK
{
	// Token: 0x02000020 RID: 32
	public struct Matrix4x2 : IEquatable<Matrix4x2>
	{
		// Token: 0x06000355 RID: 853 RVA: 0x0000E3D0 File Offset: 0x0000C5D0
		public Matrix4x2(Vector2 row0, Vector2 row1, Vector2 row2, Vector2 row3)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
			this.Row3 = row3;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000E3F0 File Offset: 0x0000C5F0
		public Matrix4x2(float m00, float m01, float m10, float m11, float m20, float m21, float m30, float m31)
		{
			this.Row0 = new Vector2(m00, m01);
			this.Row1 = new Vector2(m10, m11);
			this.Row2 = new Vector2(m20, m21);
			this.Row3 = new Vector2(m30, m31);
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000357 RID: 855 RVA: 0x0000E42C File Offset: 0x0000C62C
		// (set) Token: 0x06000358 RID: 856 RVA: 0x0000E460 File Offset: 0x0000C660
		public Vector4 Column0
		{
			get
			{
				return new Vector4(this.Row0.X, this.Row1.X, this.Row2.X, this.Row3.X);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.X = value.Y;
				this.Row2.X = value.Z;
				this.Row3.X = value.W;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000359 RID: 857 RVA: 0x0000E4B8 File Offset: 0x0000C6B8
		// (set) Token: 0x0600035A RID: 858 RVA: 0x0000E4EC File Offset: 0x0000C6EC
		public Vector4 Column1
		{
			get
			{
				return new Vector4(this.Row0.Y, this.Row1.Y, this.Row2.Y, this.Row3.X);
			}
			set
			{
				this.Row0.Y = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Y = value.Z;
				this.Row3.Y = value.W;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600035B RID: 859 RVA: 0x0000E544 File Offset: 0x0000C744
		// (set) Token: 0x0600035C RID: 860 RVA: 0x0000E554 File Offset: 0x0000C754
		public float M11
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

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600035D RID: 861 RVA: 0x0000E564 File Offset: 0x0000C764
		// (set) Token: 0x0600035E RID: 862 RVA: 0x0000E574 File Offset: 0x0000C774
		public float M12
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

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600035F RID: 863 RVA: 0x0000E584 File Offset: 0x0000C784
		// (set) Token: 0x06000360 RID: 864 RVA: 0x0000E594 File Offset: 0x0000C794
		public float M21
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

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0000E5A4 File Offset: 0x0000C7A4
		// (set) Token: 0x06000362 RID: 866 RVA: 0x0000E5B4 File Offset: 0x0000C7B4
		public float M22
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

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0000E5C4 File Offset: 0x0000C7C4
		// (set) Token: 0x06000364 RID: 868 RVA: 0x0000E5D4 File Offset: 0x0000C7D4
		public float M31
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

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0000E5E4 File Offset: 0x0000C7E4
		// (set) Token: 0x06000366 RID: 870 RVA: 0x0000E5F4 File Offset: 0x0000C7F4
		public float M32
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

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000367 RID: 871 RVA: 0x0000E604 File Offset: 0x0000C804
		// (set) Token: 0x06000368 RID: 872 RVA: 0x0000E614 File Offset: 0x0000C814
		public float M41
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

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000369 RID: 873 RVA: 0x0000E624 File Offset: 0x0000C824
		// (set) Token: 0x0600036A RID: 874 RVA: 0x0000E634 File Offset: 0x0000C834
		public float M42
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

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600036B RID: 875 RVA: 0x0000E644 File Offset: 0x0000C844
		// (set) Token: 0x0600036C RID: 876 RVA: 0x0000E664 File Offset: 0x0000C864
		public Vector2 Diagonal
		{
			get
			{
				return new Vector2(this.Row0.X, this.Row1.Y);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.Y = value.Y;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0000E68C File Offset: 0x0000C88C
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x170000BB RID: 187
		public float this[int rowIndex, int columnIndex]
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

		// Token: 0x06000370 RID: 880 RVA: 0x0000E7C4 File Offset: 0x0000C9C4
		public static void CreateRotation(float angle, out Matrix4x2 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000E854 File Offset: 0x0000CA54
		public static Matrix4x2 CreateRotation(float angle)
		{
			Matrix4x2 result;
			Matrix4x2.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000E86C File Offset: 0x0000CA6C
		public static void CreateScale(float scale, out Matrix4x2 result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000E8F4 File Offset: 0x0000CAF4
		public static Matrix4x2 CreateScale(float scale)
		{
			Matrix4x2 result;
			Matrix4x2.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000E90C File Offset: 0x0000CB0C
		public static void CreateScale(Vector2 scale, out Matrix4x2 result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale.Y;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000E9A0 File Offset: 0x0000CBA0
		public static Matrix4x2 CreateScale(Vector2 scale)
		{
			Matrix4x2 result;
			Matrix4x2.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000E9B8 File Offset: 0x0000CBB8
		public static void CreateScale(float x, float y, out Matrix4x2 result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = y;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000EA40 File Offset: 0x0000CC40
		public static Matrix4x2 CreateScale(float x, float y)
		{
			Matrix4x2 result;
			Matrix4x2.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000EA58 File Offset: 0x0000CC58
		public static void Mult(ref Matrix4x2 left, float right, out Matrix4x2 result)
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

		// Token: 0x06000379 RID: 889 RVA: 0x0000EB28 File Offset: 0x0000CD28
		public static Matrix4x2 Mult(Matrix4x2 left, float right)
		{
			Matrix4x2 result;
			Matrix4x2.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000EB40 File Offset: 0x0000CD40
		public static void Mult(ref Matrix4x2 left, ref Matrix2 right, out Matrix4x2 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float x4 = left.Row3.X;
			float y4 = left.Row3.Y;
			float x5 = right.Row0.X;
			float y5 = right.Row0.Y;
			float x6 = right.Row1.X;
			float y6 = right.Row1.Y;
			result.Row0.X = x * x5 + y * x6;
			result.Row0.Y = x * y5 + y * y6;
			result.Row1.X = x2 * x5 + y2 * x6;
			result.Row1.Y = x2 * y5 + y2 * y6;
			result.Row2.X = x3 * x5 + y3 * x6;
			result.Row2.Y = x3 * y5 + y3 * y6;
			result.Row3.X = x4 * x5 + y4 * x6;
			result.Row3.Y = x4 * y5 + y4 * y6;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000EC90 File Offset: 0x0000CE90
		public static Matrix4x2 Mult(Matrix4x2 left, Matrix2 right)
		{
			Matrix4x2 result;
			Matrix4x2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000ECAC File Offset: 0x0000CEAC
		public static void Mult(ref Matrix4x2 left, ref Matrix2x3 right, out Matrix4x3 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float x4 = left.Row3.X;
			float y4 = left.Row3.Y;
			float x5 = right.Row0.X;
			float y5 = right.Row0.Y;
			float z = right.Row0.Z;
			float x6 = right.Row1.X;
			float y6 = right.Row1.Y;
			float z2 = right.Row1.Z;
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

		// Token: 0x0600037D RID: 893 RVA: 0x0000EE68 File Offset: 0x0000D068
		public static Matrix4x3 Mult(Matrix4x2 left, Matrix2x3 right)
		{
			Matrix4x3 result;
			Matrix4x2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000EE84 File Offset: 0x0000D084
		public static void Mult(ref Matrix4x2 left, ref Matrix2x4 right, out Matrix4 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float x4 = left.Row3.X;
			float y4 = left.Row3.Y;
			float x5 = right.Row0.X;
			float y5 = right.Row0.Y;
			float z = right.Row0.Z;
			float w = right.Row0.W;
			float x6 = right.Row1.X;
			float y6 = right.Row1.Y;
			float z2 = right.Row1.Z;
			float w2 = right.Row1.W;
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

		// Token: 0x0600037F RID: 895 RVA: 0x0000F0B0 File Offset: 0x0000D2B0
		public static Matrix4 Mult(Matrix4x2 left, Matrix2x4 right)
		{
			Matrix4 result;
			Matrix4x2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000F0CC File Offset: 0x0000D2CC
		public static void Add(ref Matrix4x2 left, ref Matrix4x2 right, out Matrix4x2 result)
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

		// Token: 0x06000381 RID: 897 RVA: 0x0000F1EC File Offset: 0x0000D3EC
		public static Matrix4x2 Add(Matrix4x2 left, Matrix4x2 right)
		{
			Matrix4x2 result;
			Matrix4x2.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0000F208 File Offset: 0x0000D408
		public static void Subtract(ref Matrix4x2 left, ref Matrix4x2 right, out Matrix4x2 result)
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

		// Token: 0x06000383 RID: 899 RVA: 0x0000F328 File Offset: 0x0000D528
		public static Matrix4x2 Subtract(Matrix4x2 left, Matrix4x2 right)
		{
			Matrix4x2 result;
			Matrix4x2.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000F344 File Offset: 0x0000D544
		public static void Transpose(ref Matrix4x2 mat, out Matrix2x4 result)
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

		// Token: 0x06000385 RID: 901 RVA: 0x0000F404 File Offset: 0x0000D604
		public static Matrix2x4 Transpose(Matrix4x2 mat)
		{
			Matrix2x4 result;
			Matrix4x2.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000F41C File Offset: 0x0000D61C
		public static Matrix4x2 operator *(float left, Matrix4x2 right)
		{
			return Matrix4x2.Mult(right, left);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000F428 File Offset: 0x0000D628
		public static Matrix4x2 operator *(Matrix4x2 left, float right)
		{
			return Matrix4x2.Mult(left, right);
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000F434 File Offset: 0x0000D634
		public static Matrix4x2 operator *(Matrix4x2 left, Matrix2 right)
		{
			return Matrix4x2.Mult(left, right);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000F440 File Offset: 0x0000D640
		public static Matrix4x3 operator *(Matrix4x2 left, Matrix2x3 right)
		{
			return Matrix4x2.Mult(left, right);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000F44C File Offset: 0x0000D64C
		public static Matrix4 operator *(Matrix4x2 left, Matrix2x4 right)
		{
			return Matrix4x2.Mult(left, right);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000F458 File Offset: 0x0000D658
		public static Matrix4x2 operator +(Matrix4x2 left, Matrix4x2 right)
		{
			return Matrix4x2.Add(left, right);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000F464 File Offset: 0x0000D664
		public static Matrix4x2 operator -(Matrix4x2 left, Matrix4x2 right)
		{
			return Matrix4x2.Subtract(left, right);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000F470 File Offset: 0x0000D670
		public static bool operator ==(Matrix4x2 left, Matrix4x2 right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000F47C File Offset: 0x0000D67C
		public static bool operator !=(Matrix4x2 left, Matrix4x2 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000F48C File Offset: 0x0000D68C
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

		// Token: 0x06000390 RID: 912 RVA: 0x0000F4E4 File Offset: 0x0000D6E4
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode() ^ this.Row3.GetHashCode();
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0000F538 File Offset: 0x0000D738
		public override bool Equals(object obj)
		{
			return obj is Matrix4x2 && this.Equals((Matrix4x2)obj);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0000F550 File Offset: 0x0000D750
		public bool Equals(Matrix4x2 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2 && this.Row3 == other.Row3;
		}

		// Token: 0x04000097 RID: 151
		public Vector2 Row0;

		// Token: 0x04000098 RID: 152
		public Vector2 Row1;

		// Token: 0x04000099 RID: 153
		public Vector2 Row2;

		// Token: 0x0400009A RID: 154
		public Vector2 Row3;

		// Token: 0x0400009B RID: 155
		public static readonly Matrix4x2 Zero = new Matrix4x2(Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero);
	}
}
