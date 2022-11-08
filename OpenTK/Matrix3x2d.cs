using System;

namespace OpenTK
{
	// Token: 0x0200001D RID: 29
	public struct Matrix3x2d : IEquatable<Matrix3x2d>
	{
		// Token: 0x0600027C RID: 636 RVA: 0x0000A98C File Offset: 0x00008B8C
		public Matrix3x2d(Vector2d row0, Vector2d row1, Vector2d row2)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000A9A4 File Offset: 0x00008BA4
		public Matrix3x2d(double m00, double m01, double m10, double m11, double m20, double m21)
		{
			this.Row0 = new Vector2d(m00, m01);
			this.Row1 = new Vector2d(m10, m11);
			this.Row2 = new Vector2d(m20, m21);
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600027E RID: 638 RVA: 0x0000A9D0 File Offset: 0x00008BD0
		// (set) Token: 0x0600027F RID: 639 RVA: 0x0000A9F8 File Offset: 0x00008BF8
		public Vector3d Column0
		{
			get
			{
				return new Vector3d(this.Row0.X, this.Row1.X, this.Row2.X);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.X = value.Y;
				this.Row2.X = value.Z;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000280 RID: 640 RVA: 0x0000AA30 File Offset: 0x00008C30
		// (set) Token: 0x06000281 RID: 641 RVA: 0x0000AA58 File Offset: 0x00008C58
		public Vector3d Column1
		{
			get
			{
				return new Vector3d(this.Row0.Y, this.Row1.Y, this.Row2.Y);
			}
			set
			{
				this.Row0.Y = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Y = value.Z;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0000AA90 File Offset: 0x00008C90
		// (set) Token: 0x06000283 RID: 643 RVA: 0x0000AAA0 File Offset: 0x00008CA0
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

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0000AAB0 File Offset: 0x00008CB0
		// (set) Token: 0x06000285 RID: 645 RVA: 0x0000AAC0 File Offset: 0x00008CC0
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

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000286 RID: 646 RVA: 0x0000AAD0 File Offset: 0x00008CD0
		// (set) Token: 0x06000287 RID: 647 RVA: 0x0000AAE0 File Offset: 0x00008CE0
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

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000288 RID: 648 RVA: 0x0000AAF0 File Offset: 0x00008CF0
		// (set) Token: 0x06000289 RID: 649 RVA: 0x0000AB00 File Offset: 0x00008D00
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

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600028A RID: 650 RVA: 0x0000AB10 File Offset: 0x00008D10
		// (set) Token: 0x0600028B RID: 651 RVA: 0x0000AB20 File Offset: 0x00008D20
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

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600028C RID: 652 RVA: 0x0000AB30 File Offset: 0x00008D30
		// (set) Token: 0x0600028D RID: 653 RVA: 0x0000AB40 File Offset: 0x00008D40
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

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000AB50 File Offset: 0x00008D50
		// (set) Token: 0x0600028F RID: 655 RVA: 0x0000AB70 File Offset: 0x00008D70
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

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000AB98 File Offset: 0x00008D98
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x17000088 RID: 136
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

		// Token: 0x06000293 RID: 659 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		public static void CreateRotation(double angle, out Matrix3x2d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000AD24 File Offset: 0x00008F24
		public static Matrix3x2d CreateRotation(double angle)
		{
			Matrix3x2d result;
			Matrix3x2d.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000AD3C File Offset: 0x00008F3C
		public static void CreateScale(double scale, out Matrix3x2d result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000ADB4 File Offset: 0x00008FB4
		public static Matrix3x2d CreateScale(double scale)
		{
			Matrix3x2d result;
			Matrix3x2d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000ADCC File Offset: 0x00008FCC
		public static void CreateScale(Vector2d scale, out Matrix3x2d result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale.Y;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000AE50 File Offset: 0x00009050
		public static Matrix3x2d CreateScale(Vector2d scale)
		{
			Matrix3x2d result;
			Matrix3x2d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000AE68 File Offset: 0x00009068
		public static void CreateScale(double x, double y, out Matrix3x2d result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = y;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000AEE0 File Offset: 0x000090E0
		public static Matrix3x2d CreateScale(double x, double y)
		{
			Matrix3x2d result;
			Matrix3x2d.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000AEF8 File Offset: 0x000090F8
		public static void Mult(ref Matrix3x2d left, double right, out Matrix3x2d result)
		{
			result.Row0.X = left.Row0.X * right;
			result.Row0.Y = left.Row0.Y * right;
			result.Row1.X = left.Row1.X * right;
			result.Row1.Y = left.Row1.Y * right;
			result.Row2.X = left.Row2.X * right;
			result.Row2.Y = left.Row2.Y * right;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000AF98 File Offset: 0x00009198
		public static Matrix3x2d Mult(Matrix3x2d left, double right)
		{
			Matrix3x2d result;
			Matrix3x2d.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000AFB0 File Offset: 0x000091B0
		public static void Mult(ref Matrix3x2d left, ref Matrix2d right, out Matrix3x2d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double x4 = right.Row0.X;
			double y4 = right.Row0.Y;
			double x5 = right.Row1.X;
			double y5 = right.Row1.Y;
			result.Row0.X = x * x4 + y * x5;
			result.Row0.Y = x * y4 + y * y5;
			result.Row1.X = x2 * x4 + y2 * x5;
			result.Row1.Y = x2 * y4 + y2 * y5;
			result.Row2.X = x3 * x4 + y3 * x5;
			result.Row2.Y = x3 * y4 + y3 * y5;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000B0B8 File Offset: 0x000092B8
		public static Matrix3x2d Mult(Matrix3x2d left, Matrix2d right)
		{
			Matrix3x2d result;
			Matrix3x2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000B0D4 File Offset: 0x000092D4
		public static void Mult(ref Matrix3x2d left, ref Matrix2x3d right, out Matrix3d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double x4 = right.Row0.X;
			double y4 = right.Row0.Y;
			double z = right.Row0.Z;
			double x5 = right.Row1.X;
			double y5 = right.Row1.Y;
			double z2 = right.Row1.Z;
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

		// Token: 0x060002A0 RID: 672 RVA: 0x0000B234 File Offset: 0x00009434
		public static Matrix3d Mult(Matrix3x2d left, Matrix2x3d right)
		{
			Matrix3d result;
			Matrix3x2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000B250 File Offset: 0x00009450
		public static void Mult(ref Matrix3x2d left, ref Matrix2x4d right, out Matrix3x4d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double x4 = right.Row0.X;
			double y4 = right.Row0.Y;
			double z = right.Row0.Z;
			double w = right.Row0.W;
			double x5 = right.Row1.X;
			double y5 = right.Row1.Y;
			double z2 = right.Row1.Z;
			double w2 = right.Row1.W;
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

		// Token: 0x060002A2 RID: 674 RVA: 0x0000B408 File Offset: 0x00009608
		public static Matrix3x4d Mult(Matrix3x2d left, Matrix2x4d right)
		{
			Matrix3x4d result;
			Matrix3x2d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000B424 File Offset: 0x00009624
		public static void Add(ref Matrix3x2d left, ref Matrix3x2d right, out Matrix3x2d result)
		{
			result.Row0.X = left.Row0.X + right.Row0.X;
			result.Row0.Y = left.Row0.Y + right.Row0.Y;
			result.Row1.X = left.Row1.X + right.Row1.X;
			result.Row1.Y = left.Row1.Y + right.Row1.Y;
			result.Row2.X = left.Row2.X + right.Row2.X;
			result.Row2.Y = left.Row2.Y + right.Row2.Y;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000B500 File Offset: 0x00009700
		public static Matrix3x2d Add(Matrix3x2d left, Matrix3x2d right)
		{
			Matrix3x2d result;
			Matrix3x2d.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000B51C File Offset: 0x0000971C
		public static void Subtract(ref Matrix3x2d left, ref Matrix3x2d right, out Matrix3x2d result)
		{
			result.Row0.X = left.Row0.X - right.Row0.X;
			result.Row0.Y = left.Row0.Y - right.Row0.Y;
			result.Row1.X = left.Row1.X - right.Row1.X;
			result.Row1.Y = left.Row1.Y - right.Row1.Y;
			result.Row2.X = left.Row2.X - right.Row2.X;
			result.Row2.Y = left.Row2.Y - right.Row2.Y;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000B5F8 File Offset: 0x000097F8
		public static Matrix3x2d Subtract(Matrix3x2d left, Matrix3x2d right)
		{
			Matrix3x2d result;
			Matrix3x2d.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000B614 File Offset: 0x00009814
		public static void Transpose(ref Matrix3x2d mat, out Matrix2x3d result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row0.Z = mat.Row2.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
			result.Row1.Z = mat.Row2.Y;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000B6A8 File Offset: 0x000098A8
		public static Matrix2x3d Transpose(Matrix3x2d mat)
		{
			Matrix2x3d result;
			Matrix3x2d.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000B6C0 File Offset: 0x000098C0
		public static Matrix3x2d operator *(double left, Matrix3x2d right)
		{
			return Matrix3x2d.Mult(right, left);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000B6CC File Offset: 0x000098CC
		public static Matrix3x2d operator *(Matrix3x2d left, double right)
		{
			return Matrix3x2d.Mult(left, right);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000B6D8 File Offset: 0x000098D8
		public static Matrix3x2d operator *(Matrix3x2d left, Matrix2d right)
		{
			return Matrix3x2d.Mult(left, right);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000B6E4 File Offset: 0x000098E4
		public static Matrix3d operator *(Matrix3x2d left, Matrix2x3d right)
		{
			return Matrix3x2d.Mult(left, right);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000B6F0 File Offset: 0x000098F0
		public static Matrix3x4d operator *(Matrix3x2d left, Matrix2x4d right)
		{
			return Matrix3x2d.Mult(left, right);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000B6FC File Offset: 0x000098FC
		public static Matrix3x2d operator +(Matrix3x2d left, Matrix3x2d right)
		{
			return Matrix3x2d.Add(left, right);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000B708 File Offset: 0x00009908
		public static Matrix3x2d operator -(Matrix3x2d left, Matrix3x2d right)
		{
			return Matrix3x2d.Subtract(left, right);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000B714 File Offset: 0x00009914
		public static bool operator ==(Matrix3x2d left, Matrix3x2d right)
		{
			return left.Equals(right);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000B720 File Offset: 0x00009920
		public static bool operator !=(Matrix3x2d left, Matrix3x2d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000B730 File Offset: 0x00009930
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", this.Row0, this.Row1, this.Row2);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000B760 File Offset: 0x00009960
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode();
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000B798 File Offset: 0x00009998
		public override bool Equals(object obj)
		{
			return obj is Matrix3x2d && this.Equals((Matrix3x2d)obj);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000B7B0 File Offset: 0x000099B0
		public bool Equals(Matrix3x2d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2;
		}

		// Token: 0x0400008B RID: 139
		public Vector2d Row0;

		// Token: 0x0400008C RID: 140
		public Vector2d Row1;

		// Token: 0x0400008D RID: 141
		public Vector2d Row2;

		// Token: 0x0400008E RID: 142
		public static readonly Matrix3x2d Zero = new Matrix3x2d(Vector2d.Zero, Vector2d.Zero, Vector2d.Zero);
	}
}
