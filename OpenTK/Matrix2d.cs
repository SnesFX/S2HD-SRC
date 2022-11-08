using System;

namespace OpenTK
{
	// Token: 0x02000016 RID: 22
	public struct Matrix2d : IEquatable<Matrix2d>
	{
		// Token: 0x060000C0 RID: 192 RVA: 0x00003A90 File Offset: 0x00001C90
		public Matrix2d(Vector2d row0, Vector2d row1)
		{
			this.Row0 = row0;
			this.Row1 = row1;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003AA0 File Offset: 0x00001CA0
		public Matrix2d(double m00, double m01, double m10, double m11)
		{
			this.Row0 = new Vector2d(m00, m01);
			this.Row1 = new Vector2d(m10, m11);
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00003AC0 File Offset: 0x00001CC0
		public double Determinant
		{
			get
			{
				double x = this.Row0.X;
				double y = this.Row0.Y;
				double x2 = this.Row1.X;
				double y2 = this.Row1.Y;
				return x * y2 - y * x2;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00003B04 File Offset: 0x00001D04
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00003B24 File Offset: 0x00001D24
		public Vector2d Column0
		{
			get
			{
				return new Vector2d(this.Row0.X, this.Row1.X);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.X = value.Y;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00003B4C File Offset: 0x00001D4C
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00003B6C File Offset: 0x00001D6C
		public Vector2d Column1
		{
			get
			{
				return new Vector2d(this.Row0.Y, this.Row1.Y);
			}
			set
			{
				this.Row0.Y = value.X;
				this.Row1.Y = value.Y;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00003B94 File Offset: 0x00001D94
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00003BA4 File Offset: 0x00001DA4
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

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00003BB4 File Offset: 0x00001DB4
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00003BC4 File Offset: 0x00001DC4
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

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00003BD4 File Offset: 0x00001DD4
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00003BE4 File Offset: 0x00001DE4
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

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00003BF4 File Offset: 0x00001DF4
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00003C04 File Offset: 0x00001E04
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

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00003C14 File Offset: 0x00001E14
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00003C34 File Offset: 0x00001E34
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

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00003C5C File Offset: 0x00001E5C
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x1700002C RID: 44
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

		// Token: 0x060000D4 RID: 212 RVA: 0x00003D50 File Offset: 0x00001F50
		public void Transpose()
		{
			this = Matrix2d.Transpose(this);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003D64 File Offset: 0x00001F64
		public void Invert()
		{
			this = Matrix2d.Invert(this);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003D78 File Offset: 0x00001F78
		public static void CreateRotation(double angle, out Matrix2d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003DC8 File Offset: 0x00001FC8
		public static Matrix2d CreateRotation(double angle)
		{
			Matrix2d result;
			Matrix2d.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00003DE0 File Offset: 0x00001FE0
		public static void CreateScale(double scale, out Matrix2d result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003E30 File Offset: 0x00002030
		public static Matrix2d CreateScale(double scale)
		{
			Matrix2d result;
			Matrix2d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003E48 File Offset: 0x00002048
		public static void CreateScale(Vector2d scale, out Matrix2d result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale.Y;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00003EA4 File Offset: 0x000020A4
		public static Matrix2d CreateScale(Vector2d scale)
		{
			Matrix2d result;
			Matrix2d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00003EBC File Offset: 0x000020BC
		public static void CreateScale(double x, double y, out Matrix2d result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = y;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00003F0C File Offset: 0x0000210C
		public static Matrix2d CreateScale(double x, double y)
		{
			Matrix2d result;
			Matrix2d.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003F24 File Offset: 0x00002124
		public static void Mult(ref Matrix2d left, double right, out Matrix2d result)
		{
			result.Row0.X = left.Row0.X * right;
			result.Row0.Y = left.Row0.Y * right;
			result.Row1.X = left.Row1.X * right;
			result.Row1.Y = left.Row1.Y * right;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003F94 File Offset: 0x00002194
		public static Matrix2d Mult(Matrix2d left, double right)
		{
			Matrix2d result;
			Matrix2d.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00003FAC File Offset: 0x000021AC
		public static void Mult(ref Matrix2d left, ref Matrix2d right, out Matrix2d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = right.Row0.X;
			double y3 = right.Row0.Y;
			double x4 = right.Row1.X;
			double y4 = right.Row1.Y;
			result.Row0.X = x * x3 + y * x4;
			result.Row0.Y = x * y3 + y * y4;
			result.Row1.X = x2 * x3 + y2 * x4;
			result.Row1.Y = x2 * y3 + y2 * y4;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00004070 File Offset: 0x00002270
		public static Matrix2d Mult(Matrix2d left, Matrix2d right)
		{
			Matrix2d result;
			Matrix2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000408C File Offset: 0x0000228C
		public static void Mult(ref Matrix2d left, ref Matrix2x3d right, out Matrix2x3d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = right.Row0.X;
			double y3 = right.Row0.Y;
			double z = right.Row0.Z;
			double x4 = right.Row1.X;
			double y4 = right.Row1.Y;
			double z2 = right.Row1.Z;
			result.Row0.X = x * x3 + y * x4;
			result.Row0.Y = x * y3 + y * y4;
			result.Row0.Z = x * z + y * z2;
			result.Row1.X = x2 * x3 + y2 * x4;
			result.Row1.Y = x2 * y3 + y2 * y4;
			result.Row1.Z = x2 * z + y2 * z2;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004190 File Offset: 0x00002390
		public static Matrix2x3d Mult(Matrix2d left, Matrix2x3d right)
		{
			Matrix2x3d result;
			Matrix2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000041AC File Offset: 0x000023AC
		public static void Mult(ref Matrix2d left, ref Matrix2x4d right, out Matrix2x4d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = right.Row0.X;
			double y3 = right.Row0.Y;
			double z = right.Row0.Z;
			double w = right.Row0.W;
			double x4 = right.Row1.X;
			double y4 = right.Row1.Y;
			double z2 = right.Row1.Z;
			double w2 = right.Row1.W;
			result.Row0.X = x * x3 + y * x4;
			result.Row0.Y = x * y3 + y * y4;
			result.Row0.Z = x * z + y * z2;
			result.Row0.W = x * w + y * w2;
			result.Row1.X = x2 * x3 + y2 * x4;
			result.Row1.Y = x2 * y3 + y2 * y4;
			result.Row1.Z = x2 * z + y2 * z2;
			result.Row1.W = x2 * w + y2 * w2;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000042F4 File Offset: 0x000024F4
		public static Matrix2x4d Mult(Matrix2d left, Matrix2x4d right)
		{
			Matrix2x4d result;
			Matrix2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004310 File Offset: 0x00002510
		public static void Add(ref Matrix2d left, ref Matrix2d right, out Matrix2d result)
		{
			result.Row0.X = left.Row0.X + right.Row0.X;
			result.Row0.Y = left.Row0.Y + right.Row0.Y;
			result.Row1.X = left.Row1.X + right.Row1.X;
			result.Row1.Y = left.Row1.Y + right.Row1.Y;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000043A8 File Offset: 0x000025A8
		public static Matrix2d Add(Matrix2d left, Matrix2d right)
		{
			Matrix2d result;
			Matrix2d.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000043C4 File Offset: 0x000025C4
		public static void Subtract(ref Matrix2d left, ref Matrix2d right, out Matrix2d result)
		{
			result.Row0.X = left.Row0.X - right.Row0.X;
			result.Row0.Y = left.Row0.Y - right.Row0.Y;
			result.Row1.X = left.Row1.X - right.Row1.X;
			result.Row1.Y = left.Row1.Y - right.Row1.Y;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000445C File Offset: 0x0000265C
		public static Matrix2d Subtract(Matrix2d left, Matrix2d right)
		{
			Matrix2d result;
			Matrix2d.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004478 File Offset: 0x00002678
		public static void Invert(ref Matrix2d mat, out Matrix2d result)
		{
			double determinant = mat.Determinant;
			if (determinant == 0.0)
			{
				throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
			}
			double num = 1.0 / determinant;
			result.Row0.X = mat.Row1.Y * num;
			result.Row0.Y = -mat.Row0.Y * num;
			result.Row1.X = -mat.Row1.X * num;
			result.Row1.Y = mat.Row0.X * num;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004514 File Offset: 0x00002714
		public static Matrix2d Invert(Matrix2d mat)
		{
			Matrix2d result;
			Matrix2d.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000452C File Offset: 0x0000272C
		public static void Transpose(ref Matrix2d mat, out Matrix2d result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004594 File Offset: 0x00002794
		public static Matrix2d Transpose(Matrix2d mat)
		{
			Matrix2d result;
			Matrix2d.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000045AC File Offset: 0x000027AC
		public static Matrix2d operator *(double left, Matrix2d right)
		{
			return Matrix2d.Mult(right, left);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000045B8 File Offset: 0x000027B8
		public static Matrix2d operator *(Matrix2d left, double right)
		{
			return Matrix2d.Mult(left, right);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000045C4 File Offset: 0x000027C4
		public static Matrix2d operator *(Matrix2d left, Matrix2d right)
		{
			return Matrix2d.Mult(left, right);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000045D0 File Offset: 0x000027D0
		public static Matrix2x3d operator *(Matrix2d left, Matrix2x3d right)
		{
			return Matrix2d.Mult(left, right);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000045DC File Offset: 0x000027DC
		public static Matrix2x4d operator *(Matrix2d left, Matrix2x4d right)
		{
			return Matrix2d.Mult(left, right);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000045E8 File Offset: 0x000027E8
		public static Matrix2d operator +(Matrix2d left, Matrix2d right)
		{
			return Matrix2d.Add(left, right);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000045F4 File Offset: 0x000027F4
		public static Matrix2d operator -(Matrix2d left, Matrix2d right)
		{
			return Matrix2d.Subtract(left, right);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004600 File Offset: 0x00002800
		public static bool operator ==(Matrix2d left, Matrix2d right)
		{
			return left.Equals(right);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000460C File Offset: 0x0000280C
		public static bool operator !=(Matrix2d left, Matrix2d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000461C File Offset: 0x0000281C
		public override string ToString()
		{
			return string.Format("{0}\n{1}", this.Row0, this.Row1);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004640 File Offset: 0x00002840
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004668 File Offset: 0x00002868
		public override bool Equals(object obj)
		{
			return obj is Matrix2d && this.Equals((Matrix2d)obj);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004680 File Offset: 0x00002880
		public bool Equals(Matrix2d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1;
		}

		// Token: 0x04000072 RID: 114
		public Vector2d Row0;

		// Token: 0x04000073 RID: 115
		public Vector2d Row1;

		// Token: 0x04000074 RID: 116
		public static readonly Matrix2d Identity = new Matrix2d(Vector2d.UnitX, Vector2d.UnitY);

		// Token: 0x04000075 RID: 117
		public static readonly Matrix2d Zero = new Matrix2d(Vector2d.Zero, Vector2d.Zero);
	}
}
