using System;

namespace OpenTK
{
	// Token: 0x02000015 RID: 21
	public struct Matrix2 : IEquatable<Matrix2>
	{
		// Token: 0x06000084 RID: 132 RVA: 0x00002E80 File Offset: 0x00001080
		public Matrix2(Vector2 row0, Vector2 row1)
		{
			this.Row0 = row0;
			this.Row1 = row1;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002E90 File Offset: 0x00001090
		public Matrix2(float m00, float m01, float m10, float m11)
		{
			this.Row0 = new Vector2(m00, m01);
			this.Row1 = new Vector2(m10, m11);
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00002EB0 File Offset: 0x000010B0
		public float Determinant
		{
			get
			{
				float x = this.Row0.X;
				float y = this.Row0.Y;
				float x2 = this.Row1.X;
				float y2 = this.Row1.Y;
				return x * y2 - y * x2;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00002EF4 File Offset: 0x000010F4
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00002F14 File Offset: 0x00001114
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

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00002F3C File Offset: 0x0000113C
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00002F5C File Offset: 0x0000115C
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

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00002F84 File Offset: 0x00001184
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00002F94 File Offset: 0x00001194
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

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00002FA4 File Offset: 0x000011A4
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00002FB4 File Offset: 0x000011B4
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

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00002FC4 File Offset: 0x000011C4
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00002FD4 File Offset: 0x000011D4
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

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00002FE4 File Offset: 0x000011E4
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00002FF4 File Offset: 0x000011F4
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

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00003004 File Offset: 0x00001204
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00003024 File Offset: 0x00001224
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

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000304C File Offset: 0x0000124C
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x17000022 RID: 34
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

		// Token: 0x06000098 RID: 152 RVA: 0x00003140 File Offset: 0x00001340
		public void Transpose()
		{
			this = Matrix2.Transpose(this);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003154 File Offset: 0x00001354
		public void Invert()
		{
			this = Matrix2.Invert(this);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003168 File Offset: 0x00001368
		public static void CreateRotation(float angle, out Matrix2 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000031B8 File Offset: 0x000013B8
		public static Matrix2 CreateRotation(float angle)
		{
			Matrix2 result;
			Matrix2.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000031D0 File Offset: 0x000013D0
		public static void CreateScale(float scale, out Matrix2 result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000320C File Offset: 0x0000140C
		public static Matrix2 CreateScale(float scale)
		{
			Matrix2 result;
			Matrix2.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003224 File Offset: 0x00001424
		public static void CreateScale(Vector2 scale, out Matrix2 result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = scale.Y;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003278 File Offset: 0x00001478
		public static Matrix2 CreateScale(Vector2 scale)
		{
			Matrix2 result;
			Matrix2.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003290 File Offset: 0x00001490
		public static void CreateScale(float x, float y, out Matrix2 result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = y;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000032CC File Offset: 0x000014CC
		public static Matrix2 CreateScale(float x, float y)
		{
			Matrix2 result;
			Matrix2.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000032E4 File Offset: 0x000014E4
		public static void Mult(ref Matrix2 left, float right, out Matrix2 result)
		{
			result.Row0.X = left.Row0.X * right;
			result.Row0.Y = left.Row0.Y * right;
			result.Row1.X = left.Row1.X * right;
			result.Row1.Y = left.Row1.Y * right;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003354 File Offset: 0x00001554
		public static Matrix2 Mult(Matrix2 left, float right)
		{
			Matrix2 result;
			Matrix2.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000336C File Offset: 0x0000156C
		public static void Mult(ref Matrix2 left, ref Matrix2 right, out Matrix2 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			result.Row0.X = x * x3 + y * x4;
			result.Row0.Y = x * y3 + y * y4;
			result.Row1.X = x2 * x3 + y2 * x4;
			result.Row1.Y = x2 * y3 + y2 * y4;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003430 File Offset: 0x00001630
		public static Matrix2 Mult(Matrix2 left, Matrix2 right)
		{
			Matrix2 result;
			Matrix2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000344C File Offset: 0x0000164C
		public static void Mult(ref Matrix2 left, ref Matrix2x3 right, out Matrix2x3 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float z = right.Row0.Z;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			float z2 = right.Row1.Z;
			result.Row0.X = x * x3 + y * x4;
			result.Row0.Y = x * y3 + y * y4;
			result.Row0.Z = x * z + y * z2;
			result.Row1.X = x2 * x3 + y2 * x4;
			result.Row1.Y = x2 * y3 + y2 * y4;
			result.Row1.Z = x2 * z + y2 * z2;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003550 File Offset: 0x00001750
		public static Matrix2x3 Mult(Matrix2 left, Matrix2x3 right)
		{
			Matrix2x3 result;
			Matrix2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000356C File Offset: 0x0000176C
		public static void Mult(ref Matrix2 left, ref Matrix2x4 right, out Matrix2x4 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float x3 = right.Row0.X;
			float y3 = right.Row0.Y;
			float z = right.Row0.Z;
			float w = right.Row0.W;
			float x4 = right.Row1.X;
			float y4 = right.Row1.Y;
			float z2 = right.Row1.Z;
			float w2 = right.Row1.W;
			result.Row0.X = x * x3 + y * x4;
			result.Row0.Y = x * y3 + y * y4;
			result.Row0.Z = x * z + y * z2;
			result.Row0.W = x * w + y * w2;
			result.Row1.X = x2 * x3 + y2 * x4;
			result.Row1.Y = x2 * y3 + y2 * y4;
			result.Row1.Z = x2 * z + y2 * z2;
			result.Row1.W = x2 * w + y2 * w2;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000036B4 File Offset: 0x000018B4
		public static Matrix2x4 Mult(Matrix2 left, Matrix2x4 right)
		{
			Matrix2x4 result;
			Matrix2.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000036D0 File Offset: 0x000018D0
		public static void Add(ref Matrix2 left, ref Matrix2 right, out Matrix2 result)
		{
			result.Row0.X = left.Row0.X + right.Row0.X;
			result.Row0.Y = left.Row0.Y + right.Row0.Y;
			result.Row1.X = left.Row1.X + right.Row1.X;
			result.Row1.Y = left.Row1.Y + right.Row1.Y;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003768 File Offset: 0x00001968
		public static Matrix2 Add(Matrix2 left, Matrix2 right)
		{
			Matrix2 result;
			Matrix2.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003784 File Offset: 0x00001984
		public static void Subtract(ref Matrix2 left, ref Matrix2 right, out Matrix2 result)
		{
			result.Row0.X = left.Row0.X - right.Row0.X;
			result.Row0.Y = left.Row0.Y - right.Row0.Y;
			result.Row1.X = left.Row1.X - right.Row1.X;
			result.Row1.Y = left.Row1.Y - right.Row1.Y;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000381C File Offset: 0x00001A1C
		public static Matrix2 Subtract(Matrix2 left, Matrix2 right)
		{
			Matrix2 result;
			Matrix2.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003838 File Offset: 0x00001A38
		public static void Invert(ref Matrix2 mat, out Matrix2 result)
		{
			float determinant = mat.Determinant;
			if (determinant == 0f)
			{
				throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
			}
			float num = 1f / determinant;
			result.Row0.X = mat.Row1.Y * num;
			result.Row0.Y = -mat.Row0.Y * num;
			result.Row1.X = -mat.Row1.X * num;
			result.Row1.Y = mat.Row0.X * num;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000038CC File Offset: 0x00001ACC
		public static Matrix2 Invert(Matrix2 mat)
		{
			Matrix2 result;
			Matrix2.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000038E4 File Offset: 0x00001AE4
		public static void Transpose(ref Matrix2 mat, out Matrix2 result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000394C File Offset: 0x00001B4C
		public static Matrix2 Transpose(Matrix2 mat)
		{
			Matrix2 result;
			Matrix2.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003964 File Offset: 0x00001B64
		public static Matrix2 operator *(float left, Matrix2 right)
		{
			return Matrix2.Mult(right, left);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003970 File Offset: 0x00001B70
		public static Matrix2 operator *(Matrix2 left, float right)
		{
			return Matrix2.Mult(left, right);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000397C File Offset: 0x00001B7C
		public static Matrix2 operator *(Matrix2 left, Matrix2 right)
		{
			return Matrix2.Mult(left, right);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003988 File Offset: 0x00001B88
		public static Matrix2x3 operator *(Matrix2 left, Matrix2x3 right)
		{
			return Matrix2.Mult(left, right);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003994 File Offset: 0x00001B94
		public static Matrix2x4 operator *(Matrix2 left, Matrix2x4 right)
		{
			return Matrix2.Mult(left, right);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000039A0 File Offset: 0x00001BA0
		public static Matrix2 operator +(Matrix2 left, Matrix2 right)
		{
			return Matrix2.Add(left, right);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000039AC File Offset: 0x00001BAC
		public static Matrix2 operator -(Matrix2 left, Matrix2 right)
		{
			return Matrix2.Subtract(left, right);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000039B8 File Offset: 0x00001BB8
		public static bool operator ==(Matrix2 left, Matrix2 right)
		{
			return left.Equals(right);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000039C4 File Offset: 0x00001BC4
		public static bool operator !=(Matrix2 left, Matrix2 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000039D4 File Offset: 0x00001BD4
		public override string ToString()
		{
			return string.Format("{0}\n{1}", this.Row0, this.Row1);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000039F8 File Offset: 0x00001BF8
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode();
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003A20 File Offset: 0x00001C20
		public override bool Equals(object obj)
		{
			return obj is Matrix2 && this.Equals((Matrix2)obj);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003A38 File Offset: 0x00001C38
		public bool Equals(Matrix2 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1;
		}

		// Token: 0x0400006E RID: 110
		public Vector2 Row0;

		// Token: 0x0400006F RID: 111
		public Vector2 Row1;

		// Token: 0x04000070 RID: 112
		public static readonly Matrix2 Identity = new Matrix2(Vector2.UnitX, Vector2.UnitY);

		// Token: 0x04000071 RID: 113
		public static readonly Matrix2 Zero = new Matrix2(Vector2.Zero, Vector2.Zero);
	}
}
