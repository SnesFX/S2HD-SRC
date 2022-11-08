using System;

namespace OpenTK
{
	// Token: 0x0200001A RID: 26
	public struct Matrix2x4d : IEquatable<Matrix2x4d>
	{
		// Token: 0x060001B9 RID: 441 RVA: 0x00007494 File Offset: 0x00005694
		public Matrix2x4d(Vector4d row0, Vector4d row1)
		{
			this.Row0 = row0;
			this.Row1 = row1;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000074A4 File Offset: 0x000056A4
		public Matrix2x4d(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13)
		{
			this.Row0 = new Vector4d(m00, m01, m02, m03);
			this.Row1 = new Vector4d(m10, m11, m12, m13);
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000074CC File Offset: 0x000056CC
		// (set) Token: 0x060001BC RID: 444 RVA: 0x000074EC File Offset: 0x000056EC
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

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00007514 File Offset: 0x00005714
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00007534 File Offset: 0x00005734
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

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001BF RID: 447 RVA: 0x0000755C File Offset: 0x0000575C
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x0000757C File Offset: 0x0000577C
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

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x000075A4 File Offset: 0x000057A4
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x000075C4 File Offset: 0x000057C4
		public Vector2d Column3
		{
			get
			{
				return new Vector2d(this.Row0.W, this.Row1.W);
			}
			set
			{
				this.Row0.W = value.X;
				this.Row1.W = value.Y;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x000075EC File Offset: 0x000057EC
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x000075FC File Offset: 0x000057FC
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

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x0000760C File Offset: 0x0000580C
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x0000761C File Offset: 0x0000581C
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

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x0000762C File Offset: 0x0000582C
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x0000763C File Offset: 0x0000583C
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

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000764C File Offset: 0x0000584C
		// (set) Token: 0x060001CA RID: 458 RVA: 0x0000765C File Offset: 0x0000585C
		public double M14
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

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000766C File Offset: 0x0000586C
		// (set) Token: 0x060001CC RID: 460 RVA: 0x0000767C File Offset: 0x0000587C
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

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001CD RID: 461 RVA: 0x0000768C File Offset: 0x0000588C
		// (set) Token: 0x060001CE RID: 462 RVA: 0x0000769C File Offset: 0x0000589C
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

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001CF RID: 463 RVA: 0x000076AC File Offset: 0x000058AC
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x000076BC File Offset: 0x000058BC
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

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x000076CC File Offset: 0x000058CC
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x000076DC File Offset: 0x000058DC
		public double M24
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

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x000076EC File Offset: 0x000058EC
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0000770C File Offset: 0x0000590C
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

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00007734 File Offset: 0x00005934
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y;
			}
		}

		// Token: 0x17000062 RID: 98
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

		// Token: 0x060001D8 RID: 472 RVA: 0x00007828 File Offset: 0x00005A28
		public static void CreateRotation(double angle, out Matrix2x4d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row0.Z = 0.0;
			result.Row0.W = 0.0;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row1.Z = 0.0;
			result.Row1.W = 0.0;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000078C4 File Offset: 0x00005AC4
		public static Matrix2x4d CreateRotation(double angle)
		{
			Matrix2x4d result;
			Matrix2x4d.CreateRotation(angle, out result);
			return result;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000078DC File Offset: 0x00005ADC
		public static void CreateScale(double scale, out Matrix2x4d result)
		{
			result.Row0.X = scale;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row0.W = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale;
			result.Row1.Z = 0.0;
			result.Row1.W = 0.0;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000797C File Offset: 0x00005B7C
		public static Matrix2x4d CreateScale(double scale)
		{
			Matrix2x4d result;
			Matrix2x4d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00007994 File Offset: 0x00005B94
		public static void CreateScale(Vector2d scale, out Matrix2x4d result)
		{
			result.Row0.X = scale.X;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row0.W = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = scale.Y;
			result.Row1.Z = 0.0;
			result.Row1.W = 0.0;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00007A40 File Offset: 0x00005C40
		public static Matrix2x4d CreateScale(Vector2d scale)
		{
			Matrix2x4d result;
			Matrix2x4d.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00007A58 File Offset: 0x00005C58
		public static void CreateScale(double x, double y, out Matrix2x4d result)
		{
			result.Row0.X = x;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row0.W = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = y;
			result.Row1.Z = 0.0;
			result.Row1.W = 0.0;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00007AF8 File Offset: 0x00005CF8
		public static Matrix2x4d CreateScale(double x, double y)
		{
			Matrix2x4d result;
			Matrix2x4d.CreateScale(x, y, out result);
			return result;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00007B10 File Offset: 0x00005D10
		public static void Mult(ref Matrix2x4d left, double right, out Matrix2x4d result)
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

		// Token: 0x060001E1 RID: 481 RVA: 0x00007BE0 File Offset: 0x00005DE0
		public static Matrix2x4d Mult(Matrix2x4d left, double right)
		{
			Matrix2x4d result;
			Matrix2x4d.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00007BF8 File Offset: 0x00005DF8
		public static void Mult(ref Matrix2x4d left, ref Matrix4x2 right, out Matrix2d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double w = left.Row0.W;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double w2 = left.Row1.W;
			double num = (double)right.Row0.X;
			double num2 = (double)right.Row0.Y;
			double num3 = (double)right.Row1.X;
			double num4 = (double)right.Row1.Y;
			double num5 = (double)right.Row2.X;
			double num6 = (double)right.Row2.Y;
			double num7 = (double)right.Row3.X;
			double num8 = (double)right.Row3.Y;
			result.Row0.X = x * num + y * num3 + z * num5 + w * num7;
			result.Row0.Y = x * num2 + y * num4 + z * num6 + w * num8;
			result.Row1.X = x2 * num + y2 * num3 + z2 * num5 + w2 * num7;
			result.Row1.Y = x2 * num2 + y2 * num4 + z2 * num6 + w2 * num8;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00007D5C File Offset: 0x00005F5C
		public static Matrix2d Mult(Matrix2x4d left, Matrix4x2 right)
		{
			Matrix2d result;
			Matrix2x4d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00007D78 File Offset: 0x00005F78
		public static void Mult(ref Matrix2x4d left, ref Matrix4x3 right, out Matrix2x3d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double w = left.Row0.W;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double w2 = left.Row1.W;
			double num = (double)right.Row0.X;
			double num2 = (double)right.Row0.Y;
			double num3 = (double)right.Row0.Z;
			double num4 = (double)right.Row1.X;
			double num5 = (double)right.Row1.Y;
			double num6 = (double)right.Row1.Z;
			double num7 = (double)right.Row2.X;
			double num8 = (double)right.Row2.Y;
			double num9 = (double)right.Row2.Z;
			double num10 = (double)right.Row3.X;
			double num11 = (double)right.Row3.Y;
			double num12 = (double)right.Row3.Z;
			result.Row0.X = x * num + y * num4 + z * num7 + w * num10;
			result.Row0.Y = x * num2 + y * num5 + z * num8 + w * num11;
			result.Row0.Z = x * num3 + y * num6 + z * num9 + w * num12;
			result.Row1.X = x2 * num + y2 * num4 + z2 * num7 + w2 * num10;
			result.Row1.Y = x2 * num2 + y2 * num5 + z2 * num8 + w2 * num11;
			result.Row1.Z = x2 * num3 + y2 * num6 + z2 * num9 + w2 * num12;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00007F54 File Offset: 0x00006154
		public static Matrix2x3d Mult(Matrix2x4d left, Matrix4x3 right)
		{
			Matrix2x3d result;
			Matrix2x4d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00007F70 File Offset: 0x00006170
		public static void Mult(ref Matrix2x4d left, ref Matrix4 right, out Matrix2x4d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double w = left.Row0.W;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double w2 = left.Row1.W;
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
			double num13 = (double)right.Row3.X;
			double num14 = (double)right.Row3.Y;
			double num15 = (double)right.Row3.Z;
			double num16 = (double)right.Row3.W;
			result.Row0.X = x * num + y * num5 + z * num9 + w * num13;
			result.Row0.Y = x * num2 + y * num6 + z * num10 + w * num14;
			result.Row0.Z = x * num3 + y * num7 + z * num11 + w * num15;
			result.Row0.W = x * num4 + y * num8 + z * num12 + w * num16;
			result.Row1.X = x2 * num + y2 * num5 + z2 * num9 + w2 * num13;
			result.Row1.Y = x2 * num2 + y2 * num6 + z2 * num10 + w2 * num14;
			result.Row1.Z = x2 * num3 + y2 * num7 + z2 * num11 + w2 * num15;
			result.Row1.W = x2 * num4 + y2 * num8 + z2 * num12 + w2 * num16;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000081C4 File Offset: 0x000063C4
		public static Matrix2x4d Mult(Matrix2x4d left, Matrix4 right)
		{
			Matrix2x4d result;
			Matrix2x4d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000081E0 File Offset: 0x000063E0
		public static void Add(ref Matrix2x4d left, ref Matrix2x4d right, out Matrix2x4d result)
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

		// Token: 0x060001E9 RID: 489 RVA: 0x00008300 File Offset: 0x00006500
		public static Matrix2x4d Add(Matrix2x4d left, Matrix2x4d right)
		{
			Matrix2x4d result;
			Matrix2x4d.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000831C File Offset: 0x0000651C
		public static void Subtract(ref Matrix2x4d left, ref Matrix2x4d right, out Matrix2x4d result)
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

		// Token: 0x060001EB RID: 491 RVA: 0x0000843C File Offset: 0x0000663C
		public static Matrix2x4d Subtract(Matrix2x4d left, Matrix2x4d right)
		{
			Matrix2x4d result;
			Matrix2x4d.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00008458 File Offset: 0x00006658
		public static void Transpose(ref Matrix2x4d mat, out Matrix4x2d result)
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

		// Token: 0x060001ED RID: 493 RVA: 0x00008518 File Offset: 0x00006718
		public static Matrix4x2d Transpose(Matrix2x4d mat)
		{
			Matrix4x2d result;
			Matrix2x4d.Transpose(ref mat, out result);
			return result;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00008530 File Offset: 0x00006730
		public static Matrix2x4d operator *(double left, Matrix2x4d right)
		{
			return Matrix2x4d.Mult(right, left);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000853C File Offset: 0x0000673C
		public static Matrix2x4d operator *(Matrix2x4d left, double right)
		{
			return Matrix2x4d.Mult(left, right);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00008548 File Offset: 0x00006748
		public static Matrix2d operator *(Matrix2x4d left, Matrix4x2 right)
		{
			return Matrix2x4d.Mult(left, right);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00008554 File Offset: 0x00006754
		public static Matrix2x3d operator *(Matrix2x4d left, Matrix4x3 right)
		{
			return Matrix2x4d.Mult(left, right);
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00008560 File Offset: 0x00006760
		public static Matrix2x4d operator *(Matrix2x4d left, Matrix4 right)
		{
			return Matrix2x4d.Mult(left, right);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000856C File Offset: 0x0000676C
		public static Matrix2x4d operator +(Matrix2x4d left, Matrix2x4d right)
		{
			return Matrix2x4d.Add(left, right);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00008578 File Offset: 0x00006778
		public static Matrix2x4d operator -(Matrix2x4d left, Matrix2x4d right)
		{
			return Matrix2x4d.Subtract(left, right);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00008584 File Offset: 0x00006784
		public static bool operator ==(Matrix2x4d left, Matrix2x4d right)
		{
			return left.Equals(right);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00008590 File Offset: 0x00006790
		public static bool operator !=(Matrix2x4d left, Matrix2x4d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x000085A0 File Offset: 0x000067A0
		public override string ToString()
		{
			return string.Format("{0}\n{1}", this.Row0, this.Row1);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x000085C4 File Offset: 0x000067C4
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode();
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x000085EC File Offset: 0x000067EC
		public override bool Equals(object obj)
		{
			return obj is Matrix2x4d && this.Equals((Matrix2x4d)obj);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00008604 File Offset: 0x00006804
		public bool Equals(Matrix2x4d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1;
		}

		// Token: 0x0400007F RID: 127
		public Vector4d Row0;

		// Token: 0x04000080 RID: 128
		public Vector4d Row1;

		// Token: 0x04000081 RID: 129
		public static readonly Matrix2x4d Zero = new Matrix2x4d(Vector4d.Zero, Vector4d.Zero);
	}
}
