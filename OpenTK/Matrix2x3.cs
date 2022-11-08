using System;

namespace OpenTK
{
	// Token: 0x02000017 RID: 23
	public struct Matrix2x3 : IEquatable<Matrix2x3>
	{
		// Token: 0x060000FC RID: 252 RVA: 0x000046D8 File Offset: 0x000028D8
		public Matrix2x3(Vector3 row0, Vector3 row1)
		{
			this.Row0 = row0;
			this.Row1 = row1;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x000046E8 File Offset: 0x000028E8
		public Matrix2x3(float m00, float m01, float m02, float m10, float m11, float m12)
		{
			this.Row0 = new Vector3(m00, m01, m02);
			this.Row1 = new Vector3(m10, m11, m12);
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000FE RID: 254 RVA: 0x0000470C File Offset: 0x0000290C
		// (set) Token: 0x060000FF RID: 255 RVA: 0x0000472C File Offset: 0x0000292C
		public Vector2 Column0
		{
			get
			{
				return new Vector2(this.Row0.X, this.Row1.X);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.X = value.Y;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00004754 File Offset: 0x00002954
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00004774 File Offset: 0x00002974
		public Vector2 Column1
		{
			get
			{
				return new Vector2(this.Row0.Y, this.Row1.Y);
			}
			set
			{
				this.Row0.Y = value.X;
				this.Row1.Y = value.Y;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000102 RID: 258 RVA: 0x0000479C File Offset: 0x0000299C
		// (set) Token: 0x06000103 RID: 259 RVA: 0x000047BC File Offset: 0x000029BC
		public Vector2 Column2
		{
			get
			{
				return new Vector2(this.Row0.Z, this.Row1.Z);
			}
			set
			{
				this.Row0.Z = value.X;
				this.Row1.Z = value.Y;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000104 RID: 260 RVA: 0x000047E4 File Offset: 0x000029E4
		// (set) Token: 0x06000105 RID: 261 RVA: 0x000047F4 File Offset: 0x000029F4
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

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00004804 File Offset: 0x00002A04
		// (set) Token: 0x06000107 RID: 263 RVA: 0x00004814 File Offset: 0x00002A14
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

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00004824 File Offset: 0x00002A24
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00004834 File Offset: 0x00002A34
		public float M13
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

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00004844 File Offset: 0x00002A44
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00004854 File Offset: 0x00002A54
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

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00004864 File Offset: 0x00002A64
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00004874 File Offset: 0x00002A74
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

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00004884 File Offset: 0x00002A84
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00004894 File Offset: 0x00002A94
		public float M23
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

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000110 RID: 272 RVA: 0x000048A4 File Offset: 0x00002AA4
		// (set) Token: 0x06000111 RID: 273 RVA: 0x000048C4 File Offset: 0x00002AC4
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

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000112 RID: 274 RVA: 0x000048EC File Offset: 0x00002AEC
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x17000038 RID: 56
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

		// Token: 0x06000115 RID: 277 RVA: 0x000049E0 File Offset: 0x00002BE0
		public static void CreateRotation(float angle, out Matrix2x3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row0.Z = 0f;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row1.Z = 0f;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00004A50 File Offset: 0x00002C50
		public static Matrix2x3 CreateRotation(float angle)
		{
			Matrix2x3 result;
			Matrix2x3.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00004A68 File Offset: 0x00002C68
		public static void CreateScale(float scale, out Matrix2x3 result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale;
			result.Row1.Z = 0f;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00004AD0 File Offset: 0x00002CD0
		public static Matrix2x3 CreateScale(float scale)
		{
			Matrix2x3 result;
			Matrix2x3.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00004AE8 File Offset: 0x00002CE8
		public static void CreateScale(Vector2 scale, out Matrix2x3 result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale.Y;
			result.Row1.Z = 0f;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004B5C File Offset: 0x00002D5C
		public static Matrix2x3 CreateScale(Vector2 scale)
		{
			Matrix2x3 result;
			Matrix2x3.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00004B74 File Offset: 0x00002D74
		public static void CreateScale(float x, float y, out Matrix2x3 result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = y;
			result.Row1.Z = 0f;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00004BDC File Offset: 0x00002DDC
		public static Matrix2x3 CreateScale(float x, float y)
		{
			Matrix2x3 result;
			Matrix2x3.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00004BF4 File Offset: 0x00002DF4
		public static void Mult(ref Matrix2x3 left, float right, out Matrix2x3 result)
		{
			result.Row0.X = left.Row0.X * right;
			result.Row0.Y = left.Row0.Y * right;
			result.Row0.Z = left.Row0.Z * right;
			result.Row1.X = left.Row1.X * right;
			result.Row1.Y = left.Row1.Y * right;
			result.Row1.Z = left.Row1.Z * right;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00004C94 File Offset: 0x00002E94
		public static Matrix2x3 Mult(Matrix2x3 left, float right)
		{
			Matrix2x3 result;
			Matrix2x3.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004CAC File Offset: 0x00002EAC
		public static void Mult(ref Matrix2x3 left, ref Matrix3x2 right, out Matrix2 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			float x5 = right.Row2.X;
			float y5 = right.Row2.Y;
			result.Row0.X = x * x3 + y * x4 + z * x5;
			result.Row0.Y = x * y3 + y * y4 + z * y5;
			result.Row1.X = x2 * x3 + y2 * x4 + z2 * x5;
			result.Row1.Y = x2 * y3 + y2 * y4 + z2 * y5;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004DBC File Offset: 0x00002FBC
		public static Matrix2 Mult(Matrix2x3 left, Matrix3x2 right)
		{
			Matrix2 result;
			Matrix2x3.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004DD8 File Offset: 0x00002FD8
		public static void Mult(ref Matrix2x3 left, ref Matrix3 right, out Matrix2x3 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float z3 = right.Row0.Z;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			float z4 = right.Row1.Z;
			float x5 = right.Row2.X;
			float y5 = right.Row2.Y;
			float z5 = right.Row2.Z;
			result.Row0.X = x * x3 + y * x4 + z * x5;
			result.Row0.Y = x * y3 + y * y4 + z * y5;
			result.Row0.Z = x * z3 + y * z4 + z * z5;
			result.Row1.X = x2 * x3 + y2 * x4 + z2 * x5;
			result.Row1.Y = x2 * y3 + y2 * y4 + z2 * y5;
			result.Row1.Z = x2 * z3 + y2 * z4 + z2 * z5;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004F40 File Offset: 0x00003140
		public static Matrix2x3 Mult(Matrix2x3 left, Matrix3 right)
		{
			Matrix2x3 result;
			Matrix2x3.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004F5C File Offset: 0x0000315C
		public static void Mult(ref Matrix2x3 left, ref Matrix3x4 right, out Matrix2x4 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float z3 = right.Row0.Z;
			float w = right.Row0.W;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			float z4 = right.Row1.Z;
			float w2 = right.Row1.W;
			float x5 = right.Row2.X;
			float y5 = right.Row2.Y;
			float z5 = right.Row2.Z;
			float w3 = right.Row2.W;
			result.Row0.X = x * x3 + y * x4 + z * x5;
			result.Row0.Y = x * y3 + y * y4 + z * y5;
			result.Row0.Z = x * z3 + y * z4 + z * z5;
			result.Row0.W = x * w + y * w2 + z * w3;
			result.Row1.X = x2 * x3 + y2 * x4 + z2 * x5;
			result.Row1.Y = x2 * y3 + y2 * y4 + z2 * y5;
			result.Row1.Z = x2 * z3 + y2 * z4 + z2 * z5;
			result.Row1.W = x2 * w + y2 * w2 + z2 * w3;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00005120 File Offset: 0x00003320
		public static Matrix2x4 Mult(Matrix2x3 left, Matrix3x4 right)
		{
			Matrix2x4 result;
			Matrix2x3.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000513C File Offset: 0x0000333C
		public static void Add(ref Matrix2x3 left, ref Matrix2x3 right, out Matrix2x3 result)
		{
			result.Row0.X = left.Row0.X + right.Row0.X;
			result.Row0.Y = left.Row0.Y + right.Row0.Y;
			result.Row0.Z = left.Row0.Z + right.Row0.Z;
			result.Row1.X = left.Row1.X + right.Row1.X;
			result.Row1.Y = left.Row1.Y + right.Row1.Y;
			result.Row1.Z = left.Row1.Z + right.Row1.Z;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00005218 File Offset: 0x00003418
		public static Matrix2x3 Add(Matrix2x3 left, Matrix2x3 right)
		{
			Matrix2x3 result;
			Matrix2x3.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00005234 File Offset: 0x00003434
		public static void Subtract(ref Matrix2x3 left, ref Matrix2x3 right, out Matrix2x3 result)
		{
			result.Row0.X = left.Row0.X - right.Row0.X;
			result.Row0.Y = left.Row0.Y - right.Row0.Y;
			result.Row0.Z = left.Row0.Z - right.Row0.Z;
			result.Row1.X = left.Row1.X - right.Row1.X;
			result.Row1.Y = left.Row1.Y - right.Row1.Y;
			result.Row1.Z = left.Row1.Z - right.Row1.Z;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00005310 File Offset: 0x00003510
		public static Matrix2x3 Subtract(Matrix2x3 left, Matrix2x3 right)
		{
			Matrix2x3 result;
			Matrix2x3.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000532C File Offset: 0x0000352C
		public static void Transpose(ref Matrix2x3 mat, out Matrix3x2 result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
			result.Row2.X = mat.Row0.Z;
			result.Row2.Y = mat.Row1.Z;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000053C0 File Offset: 0x000035C0
		public static Matrix3x2 Transpose(Matrix2x3 mat)
		{
			Matrix3x2 result;
			Matrix2x3.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000053D8 File Offset: 0x000035D8
		public static Matrix2x3 operator *(float left, Matrix2x3 right)
		{
			return Matrix2x3.Mult(right, left);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000053E4 File Offset: 0x000035E4
		public static Matrix2x3 operator *(Matrix2x3 left, float right)
		{
			return Matrix2x3.Mult(left, right);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000053F0 File Offset: 0x000035F0
		public static Matrix2 operator *(Matrix2x3 left, Matrix3x2 right)
		{
			return Matrix2x3.Mult(left, right);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000053FC File Offset: 0x000035FC
		public static Matrix2x3 operator *(Matrix2x3 left, Matrix3 right)
		{
			return Matrix2x3.Mult(left, right);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00005408 File Offset: 0x00003608
		public static Matrix2x4 operator *(Matrix2x3 left, Matrix3x4 right)
		{
			return Matrix2x3.Mult(left, right);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00005414 File Offset: 0x00003614
		public static Matrix2x3 operator +(Matrix2x3 left, Matrix2x3 right)
		{
			return Matrix2x3.Add(left, right);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00005420 File Offset: 0x00003620
		public static Matrix2x3 operator -(Matrix2x3 left, Matrix2x3 right)
		{
			return Matrix2x3.Subtract(left, right);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000542C File Offset: 0x0000362C
		public static bool operator ==(Matrix2x3 left, Matrix2x3 right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005438 File Offset: 0x00003638
		public static bool operator !=(Matrix2x3 left, Matrix2x3 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00005448 File Offset: 0x00003648
		public override string ToString()
		{
			return string.Format("{0}\n{1}", this.Row0, this.Row1);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000546C File Offset: 0x0000366C
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00005494 File Offset: 0x00003694
		public override bool Equals(object obj)
		{
			return obj is Matrix2x3 && this.Equals((Matrix2x3)obj);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000054AC File Offset: 0x000036AC
		public bool Equals(Matrix2x3 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1;
		}

		// Token: 0x04000076 RID: 118
		public Vector3 Row0;

		// Token: 0x04000077 RID: 119
		public Vector3 Row1;

		// Token: 0x04000078 RID: 120
		public static readonly Matrix2x3 Zero = new Matrix2x3(Vector3.Zero, Vector3.Zero);
	}
}
