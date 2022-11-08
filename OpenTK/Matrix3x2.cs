using System;

namespace OpenTK
{
	// Token: 0x0200001C RID: 28
	public struct Matrix3x2 : IEquatable<Matrix3x2>
	{
		// Token: 0x06000241 RID: 577 RVA: 0x00009B40 File Offset: 0x00007D40
		public Matrix3x2(Vector2 row0, Vector2 row1, Vector2 row2)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00009B58 File Offset: 0x00007D58
		public Matrix3x2(float m00, float m01, float m10, float m11, float m20, float m21)
		{
			this.Row0 = new Vector2(m00, m01);
			this.Row1 = new Vector2(m10, m11);
			this.Row2 = new Vector2(m20, m21);
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000243 RID: 579 RVA: 0x00009B84 File Offset: 0x00007D84
		// (set) Token: 0x06000244 RID: 580 RVA: 0x00009BAC File Offset: 0x00007DAC
		public Vector3 Column0
		{
			get
			{
				return new Vector3(this.Row0.X, this.Row1.X, this.Row2.X);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.X = value.Y;
				this.Row2.X = value.Z;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00009BE4 File Offset: 0x00007DE4
		// (set) Token: 0x06000246 RID: 582 RVA: 0x00009C0C File Offset: 0x00007E0C
		public Vector3 Column1
		{
			get
			{
				return new Vector3(this.Row0.Y, this.Row1.Y, this.Row2.Y);
			}
			set
			{
				this.Row0.Y = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Y = value.Z;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00009C44 File Offset: 0x00007E44
		// (set) Token: 0x06000248 RID: 584 RVA: 0x00009C54 File Offset: 0x00007E54
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

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00009C64 File Offset: 0x00007E64
		// (set) Token: 0x0600024A RID: 586 RVA: 0x00009C74 File Offset: 0x00007E74
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

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00009C84 File Offset: 0x00007E84
		// (set) Token: 0x0600024C RID: 588 RVA: 0x00009C94 File Offset: 0x00007E94
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

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600024D RID: 589 RVA: 0x00009CA4 File Offset: 0x00007EA4
		// (set) Token: 0x0600024E RID: 590 RVA: 0x00009CB4 File Offset: 0x00007EB4
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

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00009CC4 File Offset: 0x00007EC4
		// (set) Token: 0x06000250 RID: 592 RVA: 0x00009CD4 File Offset: 0x00007ED4
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

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000251 RID: 593 RVA: 0x00009CE4 File Offset: 0x00007EE4
		// (set) Token: 0x06000252 RID: 594 RVA: 0x00009CF4 File Offset: 0x00007EF4
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

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00009D04 File Offset: 0x00007F04
		// (set) Token: 0x06000254 RID: 596 RVA: 0x00009D24 File Offset: 0x00007F24
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

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00009D4C File Offset: 0x00007F4C
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x1700007D RID: 125
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

		// Token: 0x06000258 RID: 600 RVA: 0x00009E64 File Offset: 0x00008064
		public static void CreateRotation(float angle, out Matrix3x2 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00009ED4 File Offset: 0x000080D4
		public static Matrix3x2 CreateRotation(float angle)
		{
			Matrix3x2 result;
			Matrix3x2.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00009EEC File Offset: 0x000080EC
		public static void CreateScale(float scale, out Matrix3x2 result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00009F54 File Offset: 0x00008154
		public static Matrix3x2 CreateScale(float scale)
		{
			Matrix3x2 result;
			Matrix3x2.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00009F6C File Offset: 0x0000816C
		public static void CreateScale(Vector2 scale, out Matrix3x2 result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale.Y;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00009FE0 File Offset: 0x000081E0
		public static Matrix3x2 CreateScale(Vector2 scale)
		{
			Matrix3x2 result;
			Matrix3x2.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00009FF8 File Offset: 0x000081F8
		public static void CreateScale(float x, float y, out Matrix3x2 result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = y;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000A060 File Offset: 0x00008260
		public static Matrix3x2 CreateScale(float x, float y)
		{
			Matrix3x2 result;
			Matrix3x2.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000A078 File Offset: 0x00008278
		public static void Mult(ref Matrix3x2 left, float right, out Matrix3x2 result)
		{
			result.Row0.X = left.Row0.X * right;
			result.Row0.Y = left.Row0.Y * right;
			result.Row1.X = left.Row1.X * right;
			result.Row1.Y = left.Row1.Y * right;
			result.Row2.X = left.Row2.X * right;
			result.Row2.Y = left.Row2.Y * right;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000A118 File Offset: 0x00008318
		public static Matrix3x2 Mult(Matrix3x2 left, float right)
		{
			Matrix3x2 result;
			Matrix3x2.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000A130 File Offset: 0x00008330
		public static void Mult(ref Matrix3x2 left, ref Matrix2 right, out Matrix3x2 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float x4 = right.Row0.X;
			float y4 = right.Row0.Y;
			float x5 = right.Row1.X;
			float y5 = right.Row1.Y;
			result.Row0.X = x * x4 + y * x5;
			result.Row0.Y = x * y4 + y * y5;
			result.Row1.X = x2 * x4 + y2 * x5;
			result.Row1.Y = x2 * y4 + y2 * y5;
			result.Row2.X = x3 * x4 + y3 * x5;
			result.Row2.Y = x3 * y4 + y3 * y5;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000A238 File Offset: 0x00008438
		public static Matrix3x2 Mult(Matrix3x2 left, Matrix2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000A254 File Offset: 0x00008454
		public static void Mult(ref Matrix3x2 left, ref Matrix2x3 right, out Matrix3 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float x4 = right.Row0.X;
			float y4 = right.Row0.Y;
			float z = right.Row0.Z;
			float x5 = right.Row1.X;
			float y5 = right.Row1.Y;
			float z2 = right.Row1.Z;
			result.Row0.X = x * x4 + y * x5;
			result.Row0.Y = x * y4 + y * y5;
			result.Row0.Z = x * z + y * z2;
			result.Row1.X = x2 * x4 + y2 * x5;
			result.Row1.Y = x2 * y4 + y2 * y5;
			result.Row1.Z = x2 * z + y2 * z2;
			result.Row2.X = x3 * x4 + y3 * x5;
			result.Row2.Y = x3 * y4 + y3 * y5;
			result.Row2.Z = x3 * z + y3 * z2;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000A3B4 File Offset: 0x000085B4
		public static Matrix3 Mult(Matrix3x2 left, Matrix2x3 right)
		{
			Matrix3 result;
			Matrix3x2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000A3D0 File Offset: 0x000085D0
		public static void Mult(ref Matrix3x2 left, ref Matrix2x4 right, out Matrix3x4 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float x4 = right.Row0.X;
			float y4 = right.Row0.Y;
			float z = right.Row0.Z;
			float w = right.Row0.W;
			float x5 = right.Row1.X;
			float y5 = right.Row1.Y;
			float z2 = right.Row1.Z;
			float w2 = right.Row1.W;
			result.Row0.X = x * x4 + y * x5;
			result.Row0.Y = x * y4 + y * y5;
			result.Row0.Z = x * z + y * z2;
			result.Row0.W = x * w + y * w2;
			result.Row1.X = x2 * x4 + y2 * x5;
			result.Row1.Y = x2 * y4 + y2 * y5;
			result.Row1.Z = x2 * z + y2 * z2;
			result.Row1.W = x2 * w + y2 * w2;
			result.Row2.X = x3 * x4 + y3 * x5;
			result.Row2.Y = x3 * y4 + y3 * y5;
			result.Row2.Z = x3 * z + y3 * z2;
			result.Row2.W = x3 * w + y3 * w2;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000A588 File Offset: 0x00008788
		public static Matrix3x4 Mult(Matrix3x2 left, Matrix2x4 right)
		{
			Matrix3x4 result;
			Matrix3x2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000A5A4 File Offset: 0x000087A4
		public static void Add(ref Matrix3x2 left, ref Matrix3x2 right, out Matrix3x2 result)
		{
			result.Row0.X = left.Row0.X + right.Row0.X;
			result.Row0.Y = left.Row0.Y + right.Row0.Y;
			result.Row1.X = left.Row1.X + right.Row1.X;
			result.Row1.Y = left.Row1.Y + right.Row1.Y;
			result.Row2.X = left.Row2.X + right.Row2.X;
			result.Row2.Y = left.Row2.Y + right.Row2.Y;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000A680 File Offset: 0x00008880
		public static Matrix3x2 Add(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000A69C File Offset: 0x0000889C
		public static void Subtract(ref Matrix3x2 left, ref Matrix3x2 right, out Matrix3x2 result)
		{
			result.Row0.X = left.Row0.X - right.Row0.X;
			result.Row0.Y = left.Row0.Y - right.Row0.Y;
			result.Row1.X = left.Row1.X - right.Row1.X;
			result.Row1.Y = left.Row1.Y - right.Row1.Y;
			result.Row2.X = left.Row2.X - right.Row2.X;
			result.Row2.Y = left.Row2.Y - right.Row2.Y;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000A778 File Offset: 0x00008978
		public static Matrix3x2 Subtract(Matrix3x2 left, Matrix3x2 right)
		{
			Matrix3x2 result;
			Matrix3x2.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000A794 File Offset: 0x00008994
		public static void Transpose(ref Matrix3x2 mat, out Matrix2x3 result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row0.Z = mat.Row2.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
			result.Row1.Z = mat.Row2.Y;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000A828 File Offset: 0x00008A28
		public static Matrix2x3 Transpose(Matrix3x2 mat)
		{
			Matrix2x3 result;
			Matrix3x2.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000A840 File Offset: 0x00008A40
		public static Matrix3x2 operator *(float left, Matrix3x2 right)
		{
			return Matrix3x2.Mult(right, left);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000A84C File Offset: 0x00008A4C
		public static Matrix3x2 operator *(Matrix3x2 left, float right)
		{
			return Matrix3x2.Mult(left, right);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000A858 File Offset: 0x00008A58
		public static Matrix3x2 operator *(Matrix3x2 left, Matrix2 right)
		{
			return Matrix3x2.Mult(left, right);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000A864 File Offset: 0x00008A64
		public static Matrix3 operator *(Matrix3x2 left, Matrix2x3 right)
		{
			return Matrix3x2.Mult(left, right);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000A870 File Offset: 0x00008A70
		public static Matrix3x4 operator *(Matrix3x2 left, Matrix2x4 right)
		{
			return Matrix3x2.Mult(left, right);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000A87C File Offset: 0x00008A7C
		public static Matrix3x2 operator +(Matrix3x2 left, Matrix3x2 right)
		{
			return Matrix3x2.Add(left, right);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000A888 File Offset: 0x00008A88
		public static Matrix3x2 operator -(Matrix3x2 left, Matrix3x2 right)
		{
			return Matrix3x2.Subtract(left, right);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000A894 File Offset: 0x00008A94
		public static bool operator ==(Matrix3x2 left, Matrix3x2 right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000A8A0 File Offset: 0x00008AA0
		public static bool operator !=(Matrix3x2 left, Matrix3x2 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000A8B0 File Offset: 0x00008AB0
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", this.Row0, this.Row1, this.Row2);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000A8E0 File Offset: 0x00008AE0
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode();
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000A918 File Offset: 0x00008B18
		public override bool Equals(object obj)
		{
			return obj is Matrix3x2 && this.Equals((Matrix3x2)obj);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000A930 File Offset: 0x00008B30
		public bool Equals(Matrix3x2 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2;
		}

		// Token: 0x04000087 RID: 135
		public Vector2 Row0;

		// Token: 0x04000088 RID: 136
		public Vector2 Row1;

		// Token: 0x04000089 RID: 137
		public Vector2 Row2;

		// Token: 0x0400008A RID: 138
		public static readonly Matrix3x2 Zero = new Matrix3x2(Vector2.Zero, Vector2.Zero, Vector2.Zero);
	}
}
