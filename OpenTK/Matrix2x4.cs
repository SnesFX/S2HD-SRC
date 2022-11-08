using System;

namespace OpenTK
{
	// Token: 0x02000019 RID: 25
	public struct Matrix2x4 : IEquatable<Matrix2x4>
	{
		// Token: 0x06000176 RID: 374 RVA: 0x00006358 File Offset: 0x00004558
		public Matrix2x4(Vector4 row0, Vector4 row1)
		{
			this.Row0 = row0;
			this.Row1 = row1;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00006368 File Offset: 0x00004568
		public Matrix2x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13)
		{
			this.Row0 = new Vector4(m00, m01, m02, m03);
			this.Row1 = new Vector4(m10, m11, m12, m13);
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00006390 File Offset: 0x00004590
		// (set) Token: 0x06000179 RID: 377 RVA: 0x000063B0 File Offset: 0x000045B0
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

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600017A RID: 378 RVA: 0x000063D8 File Offset: 0x000045D8
		// (set) Token: 0x0600017B RID: 379 RVA: 0x000063F8 File Offset: 0x000045F8
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

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00006420 File Offset: 0x00004620
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00006440 File Offset: 0x00004640
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

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00006468 File Offset: 0x00004668
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00006488 File Offset: 0x00004688
		public Vector2 Column3
		{
			get
			{
				return new Vector2(this.Row0.W, this.Row1.W);
			}
			set
			{
				this.Row0.W = value.X;
				this.Row1.W = value.Y;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000180 RID: 384 RVA: 0x000064B0 File Offset: 0x000046B0
		// (set) Token: 0x06000181 RID: 385 RVA: 0x000064C0 File Offset: 0x000046C0
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

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000182 RID: 386 RVA: 0x000064D0 File Offset: 0x000046D0
		// (set) Token: 0x06000183 RID: 387 RVA: 0x000064E0 File Offset: 0x000046E0
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

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000184 RID: 388 RVA: 0x000064F0 File Offset: 0x000046F0
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00006500 File Offset: 0x00004700
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

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00006510 File Offset: 0x00004710
		// (set) Token: 0x06000187 RID: 391 RVA: 0x00006520 File Offset: 0x00004720
		public float M14
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

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00006530 File Offset: 0x00004730
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00006540 File Offset: 0x00004740
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

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00006550 File Offset: 0x00004750
		// (set) Token: 0x0600018B RID: 395 RVA: 0x00006560 File Offset: 0x00004760
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

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00006570 File Offset: 0x00004770
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00006580 File Offset: 0x00004780
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

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00006590 File Offset: 0x00004790
		// (set) Token: 0x0600018F RID: 399 RVA: 0x000065A0 File Offset: 0x000047A0
		public float M24
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

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000190 RID: 400 RVA: 0x000065B0 File Offset: 0x000047B0
		// (set) Token: 0x06000191 RID: 401 RVA: 0x000065D0 File Offset: 0x000047D0
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

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000192 RID: 402 RVA: 0x000065F8 File Offset: 0x000047F8
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x17000053 RID: 83
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

		// Token: 0x06000195 RID: 405 RVA: 0x000066EC File Offset: 0x000048EC
		public static void CreateRotation(float angle, out Matrix2x4 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row0.Z = 0f;
			result.Row0.W = 0f;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row1.Z = 0f;
			result.Row1.W = 0f;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000677C File Offset: 0x0000497C
		public static Matrix2x4 CreateRotation(float angle)
		{
			Matrix2x4 result;
			Matrix2x4.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00006794 File Offset: 0x00004994
		public static void CreateScale(float scale, out Matrix2x4 result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row0.W = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale;
			result.Row1.Z = 0f;
			result.Row1.W = 0f;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000681C File Offset: 0x00004A1C
		public static Matrix2x4 CreateScale(float scale)
		{
			Matrix2x4 result;
			Matrix2x4.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00006834 File Offset: 0x00004A34
		public static void CreateScale(Vector2 scale, out Matrix2x4 result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row0.W = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale.Y;
			result.Row1.Z = 0f;
			result.Row1.W = 0f;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000068C8 File Offset: 0x00004AC8
		public static Matrix2x4 CreateScale(Vector2 scale)
		{
			Matrix2x4 result;
			Matrix2x4.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000068E0 File Offset: 0x00004AE0
		public static void CreateScale(float x, float y, out Matrix2x4 result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row0.W = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = y;
			result.Row1.Z = 0f;
			result.Row1.W = 0f;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00006968 File Offset: 0x00004B68
		public static Matrix2x4 CreateScale(float x, float y)
		{
			Matrix2x4 result;
			Matrix2x4.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00006980 File Offset: 0x00004B80
		public static void Mult(ref Matrix2x4 left, float right, out Matrix2x4 result)
		{
			result.Row0.X = left.Row0.X * right;
			result.Row0.Y = left.Row0.Y * right;
			result.Row0.Z = left.Row0.Z * right;
			result.Row0.W = left.Row0.W * right;
			result.Row1.X = left.Row1.X * right;
			result.Row1.Y = left.Row1.Y * right;
			result.Row1.Z = left.Row1.Z * right;
			result.Row1.W = left.Row1.W * right;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00006A50 File Offset: 0x00004C50
		public static Matrix2x4 Mult(Matrix2x4 left, float right)
		{
			Matrix2x4 result;
			Matrix2x4.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00006A68 File Offset: 0x00004C68
		public static void Mult(ref Matrix2x4 left, ref Matrix4x2 right, out Matrix2 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float w = left.Row0.W;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float w2 = left.Row1.W;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			float x5 = right.Row2.X;
			float y5 = right.Row2.Y;
			float x6 = right.Row3.X;
			float y6 = right.Row3.Y;
			result.Row0.X = x * x3 + y * x4 + z * x5 + w * x6;
			result.Row0.Y = x * y3 + y * y4 + z * y5 + w * y6;
			result.Row1.X = x2 * x3 + y2 * x4 + z2 * x5 + w2 * x6;
			result.Row1.Y = x2 * y3 + y2 * y4 + z2 * y5 + w2 * y6;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00006BC4 File Offset: 0x00004DC4
		public static Matrix2 Mult(Matrix2x4 left, Matrix4x2 right)
		{
			Matrix2 result;
			Matrix2x4.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00006BE0 File Offset: 0x00004DE0
		public static void Mult(ref Matrix2x4 left, ref Matrix4x3 right, out Matrix2x3 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float w = left.Row0.W;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float w2 = left.Row1.W;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float z3 = right.Row0.Z;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			float z4 = right.Row1.Z;
			float x5 = right.Row2.X;
			float y5 = right.Row2.Y;
			float z5 = right.Row2.Z;
			float x6 = right.Row3.X;
			float y6 = right.Row3.Y;
			float z6 = right.Row3.Z;
			result.Row0.X = x * x3 + y * x4 + z * x5 + w * x6;
			result.Row0.Y = x * y3 + y * y4 + z * y5 + w * y6;
			result.Row0.Z = x * z3 + y * z4 + z * z5 + w * z6;
			result.Row1.X = x2 * x3 + y2 * x4 + z2 * x5 + w2 * x6;
			result.Row1.Y = x2 * y3 + y2 * y4 + z2 * y5 + w2 * y6;
			result.Row1.Z = x2 * z3 + y2 * z4 + z2 * z5 + w2 * z6;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00006DB0 File Offset: 0x00004FB0
		public static Matrix2x3 Mult(Matrix2x4 left, Matrix4x3 right)
		{
			Matrix2x3 result;
			Matrix2x4.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00006DCC File Offset: 0x00004FCC
		public static void Mult(ref Matrix2x4 left, ref Matrix4 right, out Matrix2x4 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float w = left.Row0.W;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float w2 = left.Row1.W;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float z3 = right.Row0.Z;
			float w3 = right.Row0.W;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			float z4 = right.Row1.Z;
			float w4 = right.Row1.W;
			float x5 = right.Row2.X;
			float y5 = right.Row2.Y;
			float z5 = right.Row2.Z;
			float w5 = right.Row2.W;
			float x6 = right.Row3.X;
			float y6 = right.Row3.Y;
			float z6 = right.Row3.Z;
			float w6 = right.Row3.W;
			result.Row0.X = x * x3 + y * x4 + z * x5 + w * x6;
			result.Row0.Y = x * y3 + y * y4 + z * y5 + w * y6;
			result.Row0.Z = x * z3 + y * z4 + z * z5 + w * z6;
			result.Row0.W = x * w3 + y * w4 + z * w5 + w * w6;
			result.Row1.X = x2 * x3 + y2 * x4 + z2 * x5 + w2 * x6;
			result.Row1.Y = x2 * y3 + y2 * y4 + z2 * y5 + w2 * y6;
			result.Row1.Z = x2 * z3 + y2 * z4 + z2 * z5 + w2 * z6;
			result.Row1.W = x2 * w3 + y2 * w4 + z2 * w5 + w2 * w6;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00007010 File Offset: 0x00005210
		public static Matrix2x4 Mult(Matrix2x4 left, Matrix4 right)
		{
			Matrix2x4 result;
			Matrix2x4.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000702C File Offset: 0x0000522C
		public static void Add(ref Matrix2x4 left, ref Matrix2x4 right, out Matrix2x4 result)
		{
			result.Row0.X = left.Row0.X + right.Row0.X;
			result.Row0.Y = left.Row0.Y + right.Row0.Y;
			result.Row0.Z = left.Row0.Z + right.Row0.Z;
			result.Row0.W = left.Row0.W + right.Row0.W;
			result.Row1.X = left.Row1.X + right.Row1.X;
			result.Row1.Y = left.Row1.Y + right.Row1.Y;
			result.Row1.Z = left.Row1.Z + right.Row1.Z;
			result.Row1.W = left.Row1.W + right.Row1.W;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000714C File Offset: 0x0000534C
		public static Matrix2x4 Add(Matrix2x4 left, Matrix2x4 right)
		{
			Matrix2x4 result;
			Matrix2x4.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00007168 File Offset: 0x00005368
		public static void Subtract(ref Matrix2x4 left, ref Matrix2x4 right, out Matrix2x4 result)
		{
			result.Row0.X = left.Row0.X - right.Row0.X;
			result.Row0.Y = left.Row0.Y - right.Row0.Y;
			result.Row0.Z = left.Row0.Z - right.Row0.Z;
			result.Row0.W = left.Row0.W - right.Row0.W;
			result.Row1.X = left.Row1.X - right.Row1.X;
			result.Row1.Y = left.Row1.Y - right.Row1.Y;
			result.Row1.Z = left.Row1.Z - right.Row1.Z;
			result.Row1.W = left.Row1.W - right.Row1.W;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00007288 File Offset: 0x00005488
		public static Matrix2x4 Subtract(Matrix2x4 left, Matrix2x4 right)
		{
			Matrix2x4 result;
			Matrix2x4.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000072A4 File Offset: 0x000054A4
		public static void Transpose(ref Matrix2x4 mat, out Matrix4x2 result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
			result.Row2.X = mat.Row0.Z;
			result.Row2.Y = mat.Row1.Z;
			result.Row3.X = mat.Row0.W;
			result.Row3.Y = mat.Row1.W;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00007364 File Offset: 0x00005564
		public static Matrix4x2 Transpose(Matrix2x4 mat)
		{
			Matrix4x2 result;
			Matrix2x4.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000737C File Offset: 0x0000557C
		public static Matrix2x4 operator *(float left, Matrix2x4 right)
		{
			return Matrix2x4.Mult(right, left);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00007388 File Offset: 0x00005588
		public static Matrix2x4 operator *(Matrix2x4 left, float right)
		{
			return Matrix2x4.Mult(left, right);
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00007394 File Offset: 0x00005594
		public static Matrix2 operator *(Matrix2x4 left, Matrix4x2 right)
		{
			return Matrix2x4.Mult(left, right);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000073A0 File Offset: 0x000055A0
		public static Matrix2x3 operator *(Matrix2x4 left, Matrix4x3 right)
		{
			return Matrix2x4.Mult(left, right);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000073AC File Offset: 0x000055AC
		public static Matrix2x4 operator *(Matrix2x4 left, Matrix4 right)
		{
			return Matrix2x4.Mult(left, right);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000073B8 File Offset: 0x000055B8
		public static Matrix2x4 operator +(Matrix2x4 left, Matrix2x4 right)
		{
			return Matrix2x4.Add(left, right);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000073C4 File Offset: 0x000055C4
		public static Matrix2x4 operator -(Matrix2x4 left, Matrix2x4 right)
		{
			return Matrix2x4.Subtract(left, right);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x000073D0 File Offset: 0x000055D0
		public static bool operator ==(Matrix2x4 left, Matrix2x4 right)
		{
			return left.Equals(right);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000073DC File Offset: 0x000055DC
		public static bool operator !=(Matrix2x4 left, Matrix2x4 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000073EC File Offset: 0x000055EC
		public override string ToString()
		{
			return string.Format("{0}\n{1}", this.Row0, this.Row1);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00007410 File Offset: 0x00005610
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00007438 File Offset: 0x00005638
		public override bool Equals(object obj)
		{
			return obj is Matrix2x4 && this.Equals((Matrix2x4)obj);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00007450 File Offset: 0x00005650
		public bool Equals(Matrix2x4 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1;
		}

		// Token: 0x0400007C RID: 124
		public Vector4 Row0;

		// Token: 0x0400007D RID: 125
		public Vector4 Row1;

		// Token: 0x0400007E RID: 126
		public static readonly Matrix2x4 Zero = new Matrix2x4(Vector4.Zero, Vector4.Zero);
	}
}
