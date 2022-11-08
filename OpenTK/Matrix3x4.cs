using System;

namespace OpenTK
{
	// Token: 0x0200001E RID: 30
	[Serializable]
	public struct Matrix3x4 : IEquatable<Matrix3x4>
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x0000B80C File Offset: 0x00009A0C
		public Matrix3x4(Vector4 row0, Vector4 row1, Vector4 row2)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000B824 File Offset: 0x00009A24
		public Matrix3x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23)
		{
			this.Row0 = new Vector4(m00, m01, m02, m03);
			this.Row1 = new Vector4(m10, m11, m12, m13);
			this.Row2 = new Vector4(m20, m21, m22, m23);
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000B85C File Offset: 0x00009A5C
		public Vector3 Column0
		{
			get
			{
				return new Vector3(this.Row0.X, this.Row1.X, this.Row2.X);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0000B884 File Offset: 0x00009A84
		public Vector3 Column1
		{
			get
			{
				return new Vector3(this.Row0.Y, this.Row1.Y, this.Row2.Y);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0000B8AC File Offset: 0x00009AAC
		public Vector3 Column2
		{
			get
			{
				return new Vector3(this.Row0.Z, this.Row1.Z, this.Row2.Z);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002BC RID: 700 RVA: 0x0000B8D4 File Offset: 0x00009AD4
		public Vector3 Column3
		{
			get
			{
				return new Vector3(this.Row0.W, this.Row1.W, this.Row2.W);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002BD RID: 701 RVA: 0x0000B8FC File Offset: 0x00009AFC
		// (set) Token: 0x060002BE RID: 702 RVA: 0x0000B90C File Offset: 0x00009B0C
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

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002BF RID: 703 RVA: 0x0000B91C File Offset: 0x00009B1C
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x0000B92C File Offset: 0x00009B2C
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

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x0000B93C File Offset: 0x00009B3C
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x0000B94C File Offset: 0x00009B4C
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

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x0000B95C File Offset: 0x00009B5C
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x0000B96C File Offset: 0x00009B6C
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

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x0000B97C File Offset: 0x00009B7C
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x0000B98C File Offset: 0x00009B8C
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

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x0000B99C File Offset: 0x00009B9C
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x0000B9AC File Offset: 0x00009BAC
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

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x0000B9BC File Offset: 0x00009BBC
		// (set) Token: 0x060002CA RID: 714 RVA: 0x0000B9CC File Offset: 0x00009BCC
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

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002CB RID: 715 RVA: 0x0000B9DC File Offset: 0x00009BDC
		// (set) Token: 0x060002CC RID: 716 RVA: 0x0000B9EC File Offset: 0x00009BEC
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

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002CD RID: 717 RVA: 0x0000B9FC File Offset: 0x00009BFC
		// (set) Token: 0x060002CE RID: 718 RVA: 0x0000BA0C File Offset: 0x00009C0C
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

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002CF RID: 719 RVA: 0x0000BA1C File Offset: 0x00009C1C
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x0000BA2C File Offset: 0x00009C2C
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

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x0000BA3C File Offset: 0x00009C3C
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x0000BA4C File Offset: 0x00009C4C
		public float M33
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

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x0000BA5C File Offset: 0x00009C5C
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x0000BA6C File Offset: 0x00009C6C
		public float M34
		{
			get
			{
				return this.Row2.W;
			}
			set
			{
				this.Row2.W = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x0000BA7C File Offset: 0x00009C7C
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x0000BAA4 File Offset: 0x00009CA4
		public Vector3 Diagonal
		{
			get
			{
				return new Vector3(this.Row0.X, this.Row1.Y, this.Row2.Z);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Z = value.Z;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x0000BADC File Offset: 0x00009CDC
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y + this.Row2.Z;
			}
		}

		// Token: 0x1700009B RID: 155
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

		// Token: 0x060002DA RID: 730 RVA: 0x0000BC00 File Offset: 0x00009E00
		public void Invert()
		{
			this = Matrix3x4.Invert(this);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000BC14 File Offset: 0x00009E14
		public static void CreateFromAxisAngle(Vector3 axis, float angle, out Matrix3x4 result)
		{
			axis.Normalize();
			float x = axis.X;
			float y = axis.Y;
			float z = axis.Z;
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			float num3 = 1f - num;
			float num4 = num3 * x * x;
			float num5 = num3 * x * y;
			float num6 = num3 * x * z;
			float num7 = num3 * y * y;
			float num8 = num3 * y * z;
			float num9 = num3 * z * z;
			float num10 = num2 * x;
			float num11 = num2 * y;
			float num12 = num2 * z;
			result.Row0.X = num4 + num;
			result.Row0.Y = num5 - num12;
			result.Row0.Z = num6 + num11;
			result.Row0.W = 0f;
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num;
			result.Row1.Z = num8 - num10;
			result.Row1.W = 0f;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num;
			result.Row2.W = 0f;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000BD5C File Offset: 0x00009F5C
		public static Matrix3x4 CreateFromAxisAngle(Vector3 axis, float angle)
		{
			Matrix3x4 result;
			Matrix3x4.CreateFromAxisAngle(axis, angle, out result);
			return result;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000BD74 File Offset: 0x00009F74
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix3x4 result)
		{
			float x = q.X;
			float y = q.Y;
			float z = q.Z;
			float w = q.W;
			float num = 2f * x;
			float num2 = 2f * y;
			float num3 = 2f * z;
			float num4 = num * x;
			float num5 = num2 * y;
			float num6 = num3 * z;
			float num7 = num * y;
			float num8 = num * z;
			float num9 = num2 * z;
			float num10 = num * w;
			float num11 = num2 * w;
			float num12 = num3 * w;
			result.Row0.X = 1f - (num5 + num6);
			result.Row0.Y = num7 + num12;
			result.Row0.Z = num8 - num11;
			result.Row0.W = 0f;
			result.Row1.X = num7 - num12;
			result.Row1.Y = 1f - (num4 + num6);
			result.Row1.Z = num9 + num10;
			result.Row1.W = 0f;
			result.Row2.X = num8 + num11;
			result.Row2.Y = num9 - num10;
			result.Row2.Z = 1f - (num4 + num5);
			result.Row2.W = 0f;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000BEC0 File Offset: 0x0000A0C0
		public static Matrix3x4 CreateFromQuaternion(Quaternion q)
		{
			Matrix3x4 result;
			Matrix3x4.CreateFromQuaternion(ref q, out result);
			return result;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000BED8 File Offset: 0x0000A0D8
		public static void CreateRotationX(float angle, out Matrix3x4 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = 1f;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row0.W = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = num;
			result.Row1.Z = num2;
			result.Row1.W = 0f;
			result.Row2.X = 0f;
			result.Row2.Y = -num2;
			result.Row2.Z = num;
			result.Row2.W = 0f;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000BFA8 File Offset: 0x0000A1A8
		public static Matrix3x4 CreateRotationX(float angle)
		{
			Matrix3x4 result;
			Matrix3x4.CreateRotationX(angle, out result);
			return result;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000BFC0 File Offset: 0x0000A1C0
		public static void CreateRotationY(float angle, out Matrix3x4 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = num;
			result.Row0.Y = 0f;
			result.Row0.Z = -num2;
			result.Row0.W = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = 1f;
			result.Row1.Z = 0f;
			result.Row1.W = 0f;
			result.Row2.X = num2;
			result.Row2.Y = 0f;
			result.Row2.Z = num;
			result.Row2.W = 0f;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000C090 File Offset: 0x0000A290
		public static Matrix3x4 CreateRotationY(float angle)
		{
			Matrix3x4 result;
			Matrix3x4.CreateRotationY(angle, out result);
			return result;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000C0A8 File Offset: 0x0000A2A8
		public static void CreateRotationZ(float angle, out Matrix3x4 result)
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
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row2.Z = 1f;
			result.Row2.W = 0f;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000C178 File Offset: 0x0000A378
		public static Matrix3x4 CreateRotationZ(float angle)
		{
			Matrix3x4 result;
			Matrix3x4.CreateRotationZ(angle, out result);
			return result;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000C190 File Offset: 0x0000A390
		public static void CreateTranslation(float x, float y, float z, out Matrix3x4 result)
		{
			result.Row0.X = 1f;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row0.W = x;
			result.Row1.X = 0f;
			result.Row1.Y = 1f;
			result.Row1.Z = 0f;
			result.Row1.W = y;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row2.Z = 1f;
			result.Row2.W = z;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000C254 File Offset: 0x0000A454
		public static void CreateTranslation(ref Vector3 vector, out Matrix3x4 result)
		{
			result.Row0.X = 1f;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row0.W = vector.X;
			result.Row1.X = 0f;
			result.Row1.Y = 1f;
			result.Row1.Z = 0f;
			result.Row1.W = vector.Y;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row2.Z = 1f;
			result.Row2.W = vector.Z;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000C324 File Offset: 0x0000A524
		public static Matrix3x4 CreateTranslation(float x, float y, float z)
		{
			Matrix3x4 result;
			Matrix3x4.CreateTranslation(x, y, z, out result);
			return result;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000C33C File Offset: 0x0000A53C
		public static Matrix3x4 CreateTranslation(Vector3 vector)
		{
			Matrix3x4 result;
			Matrix3x4.CreateTranslation(vector.X, vector.Y, vector.Z, out result);
			return result;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000C368 File Offset: 0x0000A568
		public static Matrix3x4 CreateScale(float scale)
		{
			return Matrix3x4.CreateScale(scale, scale, scale);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000C374 File Offset: 0x0000A574
		public static Matrix3x4 CreateScale(Vector3 scale)
		{
			return Matrix3x4.CreateScale(scale.X, scale.Y, scale.Z);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000C390 File Offset: 0x0000A590
		public static Matrix3x4 CreateScale(float x, float y, float z)
		{
			Matrix3x4 result;
			result.Row0.X = x;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row0.W = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = y;
			result.Row1.Z = 0f;
			result.Row1.W = 0f;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row2.Z = z;
			result.Row2.W = 0f;
			return result;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000C460 File Offset: 0x0000A660
		public static Matrix3 Mult(Matrix3x4 left, Matrix4x3 right)
		{
			Matrix3 result;
			Matrix3x4.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000C47C File Offset: 0x0000A67C
		public static void Mult(ref Matrix3x4 left, ref Matrix4x3 right, out Matrix3 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float w = left.Row0.W;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float w2 = left.Row1.W;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float z3 = left.Row2.Z;
			float w3 = left.Row2.W;
			float x4 = right.Row0.X;
			float y4 = right.Row0.Y;
			float z4 = right.Row0.Z;
			float x5 = right.Row1.X;
			float y5 = right.Row1.Y;
			float z5 = right.Row1.Z;
			float x6 = right.Row2.X;
			float y6 = right.Row2.Y;
			float z6 = right.Row2.Z;
			float x7 = right.Row3.X;
			float y7 = right.Row3.Y;
			float z7 = right.Row3.Z;
			result.Row0.X = x * x4 + y * x5 + z * x6 + w * x7;
			result.Row0.Y = x * y4 + y * y5 + z * y6 + w * y7;
			result.Row0.Z = x * z4 + y * z5 + z * z6 + w * z7;
			result.Row1.X = x2 * x4 + y2 * x5 + z2 * x6 + w2 * x7;
			result.Row1.Y = x2 * y4 + y2 * y5 + z2 * y6 + w2 * y7;
			result.Row1.Z = x2 * z4 + y2 * z5 + z2 * z6 + w2 * z7;
			result.Row2.X = x3 * x4 + y3 * x5 + z3 * x6 + w3 * x7;
			result.Row2.Y = x3 * y4 + y3 * y5 + z3 * y6 + w3 * y7;
			result.Row2.Z = x3 * z4 + y3 * z5 + z3 * z6 + w3 * z7;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000C6E4 File Offset: 0x0000A8E4
		public static Matrix3x4 Mult(Matrix3x4 left, Matrix3x4 right)
		{
			Matrix3x4 result;
			Matrix3x4.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000C700 File Offset: 0x0000A900
		public static void Mult(ref Matrix3x4 left, ref Matrix3x4 right, out Matrix3x4 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float w = left.Row0.W;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float w2 = left.Row1.W;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float z3 = left.Row2.Z;
			float w3 = left.Row2.W;
			float x4 = right.Row0.X;
			float y4 = right.Row0.Y;
			float z4 = right.Row0.Z;
			float w4 = right.Row0.W;
			float x5 = right.Row1.X;
			float y5 = right.Row1.Y;
			float z5 = right.Row1.Z;
			float w5 = right.Row1.W;
			float x6 = right.Row2.X;
			float y6 = right.Row2.Y;
			float z6 = right.Row2.Z;
			float w6 = right.Row2.W;
			result.Row0.X = x * x4 + y * x5 + z * x6;
			result.Row0.Y = x * y4 + y * y5 + z * y6;
			result.Row0.Z = x * z4 + y * z5 + z * z6;
			result.Row0.W = x * w4 + y * w5 + z * w6 + w;
			result.Row1.X = x2 * x4 + y2 * x5 + z2 * x6;
			result.Row1.Y = x2 * y4 + y2 * y5 + z2 * y6;
			result.Row1.Z = x2 * z4 + y2 * z5 + z2 * z6;
			result.Row1.W = x2 * w4 + y2 * w5 + z2 * w6 + w2;
			result.Row2.X = x3 * x4 + y3 * x5 + z3 * x6;
			result.Row2.Y = x3 * y4 + y3 * y5 + z3 * y6;
			result.Row2.Z = x3 * z4 + y3 * z5 + z3 * z6;
			result.Row2.W = x3 * w4 + y3 * w5 + z3 * w6 + w3;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000C990 File Offset: 0x0000AB90
		public static Matrix3x4 Mult(Matrix3x4 left, float right)
		{
			Matrix3x4 result;
			Matrix3x4.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000C9A8 File Offset: 0x0000ABA8
		public static void Mult(ref Matrix3x4 left, float right, out Matrix3x4 result)
		{
			result.Row0 = left.Row0 * right;
			result.Row1 = left.Row1 * right;
			result.Row2 = left.Row2 * right;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000C9E0 File Offset: 0x0000ABE0
		public static Matrix3x4 Add(Matrix3x4 left, Matrix3x4 right)
		{
			Matrix3x4 result;
			Matrix3x4.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000C9FC File Offset: 0x0000ABFC
		public static void Add(ref Matrix3x4 left, ref Matrix3x4 right, out Matrix3x4 result)
		{
			result.Row0 = left.Row0 + right.Row0;
			result.Row1 = left.Row1 + right.Row1;
			result.Row2 = left.Row2 + right.Row2;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000CA50 File Offset: 0x0000AC50
		public static Matrix3x4 Subtract(Matrix3x4 left, Matrix3x4 right)
		{
			Matrix3x4 result;
			Matrix3x4.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000CA6C File Offset: 0x0000AC6C
		public static void Subtract(ref Matrix3x4 left, ref Matrix3x4 right, out Matrix3x4 result)
		{
			result.Row0 = left.Row0 - right.Row0;
			result.Row1 = left.Row1 - right.Row1;
			result.Row2 = left.Row2 - right.Row2;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000CAC0 File Offset: 0x0000ACC0
		public static Matrix3x4 Invert(Matrix3x4 mat)
		{
			Matrix3x4 result;
			Matrix3x4.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000CAD8 File Offset: 0x0000ACD8
		public static void Invert(ref Matrix3x4 mat, out Matrix3x4 result)
		{
			Matrix3 matrix = new Matrix3(mat.Column0, mat.Column1, mat.Column2);
			matrix.Row0 /= matrix.Row0.LengthSquared;
			matrix.Row1 /= matrix.Row1.LengthSquared;
			matrix.Row2 /= matrix.Row2.LengthSquared;
			Vector3 right = new Vector3(mat.Row0.W, mat.Row1.W, mat.Row2.W);
			result.Row0 = new Vector4(matrix.Row0, -Vector3.Dot(matrix.Row0, right));
			result.Row1 = new Vector4(matrix.Row1, -Vector3.Dot(matrix.Row1, right));
			result.Row2 = new Vector4(matrix.Row2, -Vector3.Dot(matrix.Row2, right));
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000CBE0 File Offset: 0x0000ADE0
		public static Matrix4x3 Transpose(Matrix3x4 mat)
		{
			return new Matrix4x3(mat.Column0, mat.Column1, mat.Column2, mat.Column3);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000CC04 File Offset: 0x0000AE04
		public static void Transpose(ref Matrix3x4 mat, out Matrix4x3 result)
		{
			result.Row0 = mat.Column0;
			result.Row1 = mat.Column1;
			result.Row2 = mat.Column2;
			result.Row3 = mat.Column3;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000CC38 File Offset: 0x0000AE38
		public static Matrix3 operator *(Matrix3x4 left, Matrix4x3 right)
		{
			return Matrix3x4.Mult(left, right);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x0000CC44 File Offset: 0x0000AE44
		public static Matrix3x4 operator *(Matrix3x4 left, Matrix3x4 right)
		{
			return Matrix3x4.Mult(left, right);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000CC50 File Offset: 0x0000AE50
		public static Matrix3x4 operator *(Matrix3x4 left, float right)
		{
			return Matrix3x4.Mult(left, right);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		public static Matrix3x4 operator +(Matrix3x4 left, Matrix3x4 right)
		{
			return Matrix3x4.Add(left, right);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0000CC68 File Offset: 0x0000AE68
		public static Matrix3x4 operator -(Matrix3x4 left, Matrix3x4 right)
		{
			return Matrix3x4.Subtract(left, right);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000CC74 File Offset: 0x0000AE74
		public static bool operator ==(Matrix3x4 left, Matrix3x4 right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000CC80 File Offset: 0x0000AE80
		public static bool operator !=(Matrix3x4 left, Matrix3x4 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000CC90 File Offset: 0x0000AE90
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", this.Row0, this.Row1, this.Row2);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000CCC0 File Offset: 0x0000AEC0
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode();
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000CCF8 File Offset: 0x0000AEF8
		public override bool Equals(object obj)
		{
			return obj is Matrix3x4 && this.Equals((Matrix3x4)obj);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000CD10 File Offset: 0x0000AF10
		public bool Equals(Matrix3x4 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2;
		}

		// Token: 0x0400008F RID: 143
		public Vector4 Row0;

		// Token: 0x04000090 RID: 144
		public Vector4 Row1;

		// Token: 0x04000091 RID: 145
		public Vector4 Row2;

		// Token: 0x04000092 RID: 146
		public static Matrix3x4 Zero = new Matrix3x4(Vector4.Zero, Vector4.Zero, Vector4.Zero);
	}
}
