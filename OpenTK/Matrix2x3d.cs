using System;

namespace OpenTK
{
	// Token: 0x02000018 RID: 24
	public struct Matrix2x3d : IEquatable<Matrix2x3d>
	{
		// Token: 0x06000139 RID: 313 RVA: 0x000054F0 File Offset: 0x000036F0
		public Matrix2x3d(Vector3d row0, Vector3d row1)
		{
			this.Row0 = row0;
			this.Row1 = row1;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00005500 File Offset: 0x00003700
		public Matrix2x3d(double m00, double m01, double m02, double m10, double m11, double m12)
		{
			this.Row0 = new Vector3d(m00, m01, m02);
			this.Row1 = new Vector3d(m10, m11, m12);
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00005524 File Offset: 0x00003724
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00005544 File Offset: 0x00003744
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

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0000556C File Offset: 0x0000376C
		// (set) Token: 0x0600013E RID: 318 RVA: 0x0000558C File Offset: 0x0000378C
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

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600013F RID: 319 RVA: 0x000055B4 File Offset: 0x000037B4
		// (set) Token: 0x06000140 RID: 320 RVA: 0x000055D4 File Offset: 0x000037D4
		public Vector2d Column2
		{
			get
			{
				return new Vector2d(this.Row0.Z, this.Row1.Z);
			}
			set
			{
				this.Row0.Z = value.X;
				this.Row1.Z = value.Y;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000141 RID: 321 RVA: 0x000055FC File Offset: 0x000037FC
		// (set) Token: 0x06000142 RID: 322 RVA: 0x0000560C File Offset: 0x0000380C
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

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000143 RID: 323 RVA: 0x0000561C File Offset: 0x0000381C
		// (set) Token: 0x06000144 RID: 324 RVA: 0x0000562C File Offset: 0x0000382C
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

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0000563C File Offset: 0x0000383C
		// (set) Token: 0x06000146 RID: 326 RVA: 0x0000564C File Offset: 0x0000384C
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

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000147 RID: 327 RVA: 0x0000565C File Offset: 0x0000385C
		// (set) Token: 0x06000148 RID: 328 RVA: 0x0000566C File Offset: 0x0000386C
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

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000149 RID: 329 RVA: 0x0000567C File Offset: 0x0000387C
		// (set) Token: 0x0600014A RID: 330 RVA: 0x0000568C File Offset: 0x0000388C
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

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600014B RID: 331 RVA: 0x0000569C File Offset: 0x0000389C
		// (set) Token: 0x0600014C RID: 332 RVA: 0x000056AC File Offset: 0x000038AC
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

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600014D RID: 333 RVA: 0x000056BC File Offset: 0x000038BC
		// (set) Token: 0x0600014E RID: 334 RVA: 0x000056DC File Offset: 0x000038DC
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

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00005704 File Offset: 0x00003904
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x17000044 RID: 68
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

		// Token: 0x06000152 RID: 338 RVA: 0x000057F8 File Offset: 0x000039F8
		public static void CreateRotation(double angle, out Matrix2x3d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row0.Z = 0.0;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row1.Z = 0.0;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000586C File Offset: 0x00003A6C
		public static Matrix2x3d CreateRotation(double angle)
		{
			Matrix2x3d result;
			Matrix2x3d.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005884 File Offset: 0x00003A84
		public static void CreateScale(double scale, out Matrix2x3d result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale;
			result.Row1.Z = 0.0;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000058FC File Offset: 0x00003AFC
		public static Matrix2x3d CreateScale(double scale)
		{
			Matrix2x3d result;
			Matrix2x3d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00005914 File Offset: 0x00003B14
		public static void CreateScale(Vector2d scale, out Matrix2x3d result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale.Y;
			result.Row1.Z = 0.0;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00005998 File Offset: 0x00003B98
		public static Matrix2x3d CreateScale(Vector2d scale)
		{
			Matrix2x3d result;
			Matrix2x3d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000059B0 File Offset: 0x00003BB0
		public static void CreateScale(double x, double y, out Matrix2x3d result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = y;
			result.Row1.Z = 0.0;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00005A28 File Offset: 0x00003C28
		public static Matrix2x3d CreateScale(double x, double y)
		{
			Matrix2x3d result;
			Matrix2x3d.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00005A40 File Offset: 0x00003C40
		public static void Mult(ref Matrix2x3d left, double right, out Matrix2x3d result)
		{
			result.Row0.X = left.Row0.X * right;
			result.Row0.Y = left.Row0.Y * right;
			result.Row0.Z = left.Row0.Z * right;
			result.Row1.X = left.Row1.X * right;
			result.Row1.Y = left.Row1.Y * right;
			result.Row1.Z = left.Row1.Z * right;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005AE0 File Offset: 0x00003CE0
		public static Matrix2x3d Mult(Matrix2x3d left, double right)
		{
			Matrix2x3d result;
			Matrix2x3d.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005AF8 File Offset: 0x00003CF8
		public static void Mult(ref Matrix2x3d left, ref Matrix3x2 right, out Matrix2d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double num = (double)right.Row0.X;
			double num2 = (double)right.Row0.Y;
			double num3 = (double)right.Row1.X;
			double num4 = (double)right.Row1.Y;
			double num5 = (double)right.Row2.X;
			double num6 = (double)right.Row2.Y;
			result.Row0.X = x * num + y * num3 + z * num5;
			result.Row0.Y = x * num2 + y * num4 + z * num6;
			result.Row1.X = x2 * num + y2 * num3 + z2 * num5;
			result.Row1.Y = x2 * num2 + y2 * num4 + z2 * num6;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00005C0C File Offset: 0x00003E0C
		public static Matrix2d Mult(Matrix2x3d left, Matrix3x2 right)
		{
			Matrix2d result;
			Matrix2x3d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00005C28 File Offset: 0x00003E28
		public static void Mult(ref Matrix2x3d left, ref Matrix3 right, out Matrix2x3d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double num = (double)right.Row0.X;
			double num2 = (double)right.Row0.Y;
			double num3 = (double)right.Row0.Z;
			double num4 = (double)right.Row1.X;
			double num5 = (double)right.Row1.Y;
			double num6 = (double)right.Row1.Z;
			double num7 = (double)right.Row2.X;
			double num8 = (double)right.Row2.Y;
			double num9 = (double)right.Row2.Z;
			result.Row0.X = x * num + y * num4 + z * num7;
			result.Row0.Y = x * num2 + y * num5 + z * num8;
			result.Row0.Z = x * num3 + y * num6 + z * num9;
			result.Row1.X = x2 * num + y2 * num4 + z2 * num7;
			result.Row1.Y = x2 * num2 + y2 * num5 + z2 * num8;
			result.Row1.Z = x2 * num3 + y2 * num6 + z2 * num9;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00005D9C File Offset: 0x00003F9C
		public static Matrix2x3d Mult(Matrix2x3d left, Matrix3 right)
		{
			Matrix2x3d result;
			Matrix2x3d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005DB8 File Offset: 0x00003FB8
		public static void Mult(ref Matrix2x3d left, ref Matrix3x4 right, out Matrix2x4d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double num = (double)right.Row0.X;
			double num2 = (double)right.Row0.Y;
			double num3 = (double)right.Row0.Z;
			double num4 = (double)right.Row0.W;
			double num5 = (double)right.Row1.X;
			double num6 = (double)right.Row1.Y;
			double num7 = (double)right.Row1.Z;
			double num8 = (double)right.Row1.W;
			double num9 = (double)right.Row2.X;
			double num10 = (double)right.Row2.Y;
			double num11 = (double)right.Row2.Z;
			double num12 = (double)right.Row2.W;
			result.Row0.X = x * num + y * num5 + z * num9;
			result.Row0.Y = x * num2 + y * num6 + z * num10;
			result.Row0.Z = x * num3 + y * num7 + z * num11;
			result.Row0.W = x * num4 + y * num8 + z * num12;
			result.Row1.X = x2 * num + y2 * num5 + z2 * num9;
			result.Row1.Y = x2 * num2 + y2 * num6 + z2 * num10;
			result.Row1.Z = x2 * num3 + y2 * num7 + z2 * num11;
			result.Row1.W = x2 * num4 + y2 * num8 + z2 * num12;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005F88 File Offset: 0x00004188
		public static Matrix2x4d Mult(Matrix2x3d left, Matrix3x4 right)
		{
			Matrix2x4d result;
			Matrix2x3d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005FA4 File Offset: 0x000041A4
		public static void Add(ref Matrix2x3d left, ref Matrix2x3d right, out Matrix2x3d result)
		{
			result.Row0.X = left.Row0.X + right.Row0.X;
			result.Row0.Y = left.Row0.Y + right.Row0.Y;
			result.Row0.Z = left.Row0.Z + right.Row0.Z;
			result.Row1.X = left.Row1.X + right.Row1.X;
			result.Row1.Y = left.Row1.Y + right.Row1.Y;
			result.Row1.Z = left.Row1.Z + right.Row1.Z;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00006080 File Offset: 0x00004280
		public static Matrix2x3d Add(Matrix2x3d left, Matrix2x3d right)
		{
			Matrix2x3d result;
			Matrix2x3d.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000609C File Offset: 0x0000429C
		public static void Subtract(ref Matrix2x3d left, ref Matrix2x3d right, out Matrix2x3d result)
		{
			result.Row0.X = left.Row0.X - right.Row0.X;
			result.Row0.Y = left.Row0.Y - right.Row0.Y;
			result.Row0.Z = left.Row0.Z - right.Row0.Z;
			result.Row1.X = left.Row1.X - right.Row1.X;
			result.Row1.Y = left.Row1.Y - right.Row1.Y;
			result.Row1.Z = left.Row1.Z - right.Row1.Z;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00006178 File Offset: 0x00004378
		public static Matrix2x3d Subtract(Matrix2x3d left, Matrix2x3d right)
		{
			Matrix2x3d result;
			Matrix2x3d.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00006194 File Offset: 0x00004394
		public static void Transpose(ref Matrix2x3d mat, out Matrix3x2d result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
			result.Row2.X = mat.Row0.Z;
			result.Row2.Y = mat.Row1.Z;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00006228 File Offset: 0x00004428
		public static Matrix3x2d Transpose(Matrix2x3d mat)
		{
			Matrix3x2d result;
			Matrix2x3d.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00006240 File Offset: 0x00004440
		public static Matrix2x3d operator *(double left, Matrix2x3d right)
		{
			return Matrix2x3d.Mult(right, left);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000624C File Offset: 0x0000444C
		public static Matrix2x3d operator *(Matrix2x3d left, double right)
		{
			return Matrix2x3d.Mult(left, right);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00006258 File Offset: 0x00004458
		public static Matrix2d operator *(Matrix2x3d left, Matrix3x2 right)
		{
			return Matrix2x3d.Mult(left, right);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00006264 File Offset: 0x00004464
		public static Matrix2x3d operator *(Matrix2x3d left, Matrix3 right)
		{
			return Matrix2x3d.Mult(left, right);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006270 File Offset: 0x00004470
		public static Matrix2x4d operator *(Matrix2x3d left, Matrix3x4 right)
		{
			return Matrix2x3d.Mult(left, right);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000627C File Offset: 0x0000447C
		public static Matrix2x3d operator +(Matrix2x3d left, Matrix2x3d right)
		{
			return Matrix2x3d.Add(left, right);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00006288 File Offset: 0x00004488
		public static Matrix2x3d operator -(Matrix2x3d left, Matrix2x3d right)
		{
			return Matrix2x3d.Subtract(left, right);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00006294 File Offset: 0x00004494
		public static bool operator ==(Matrix2x3d left, Matrix2x3d right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000062A0 File Offset: 0x000044A0
		public static bool operator !=(Matrix2x3d left, Matrix2x3d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000062B0 File Offset: 0x000044B0
		public override string ToString()
		{
			return string.Format("{0}\n{1}", this.Row0, this.Row1);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000062D4 File Offset: 0x000044D4
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000062FC File Offset: 0x000044FC
		public override bool Equals(object obj)
		{
			return obj is Matrix2x3d && this.Equals((Matrix2x3d)obj);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006314 File Offset: 0x00004514
		public bool Equals(Matrix2x3d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1;
		}

		// Token: 0x04000079 RID: 121
		public Vector3d Row0;

		// Token: 0x0400007A RID: 122
		public Vector3d Row1;

		// Token: 0x0400007B RID: 123
		public static readonly Matrix2x3d Zero = new Matrix2x3d(Vector3d.Zero, Vector3d.Zero);
	}
}
