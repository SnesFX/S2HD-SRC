using System;

namespace OpenTK
{
	// Token: 0x02000023 RID: 35
	[Serializable]
	public struct Matrix4x3d : IEquatable<Matrix4x3d>
	{
		// Token: 0x06000421 RID: 1057 RVA: 0x00011EC4 File Offset: 0x000100C4
		public Matrix4x3d(Vector3d row0, Vector3d row1, Vector3d row2, Vector3d row3)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
			this.Row3 = row3;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00011EE4 File Offset: 0x000100E4
		public Matrix4x3d(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22, double m30, double m31, double m32)
		{
			this.Row0 = new Vector3d(m00, m01, m02);
			this.Row1 = new Vector3d(m10, m11, m12);
			this.Row2 = new Vector3d(m20, m21, m22);
			this.Row3 = new Vector3d(m30, m31, m32);
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00011F34 File Offset: 0x00010134
		public Vector4d Column0
		{
			get
			{
				return new Vector4d(this.Row0.X, this.Row1.X, this.Row2.X, this.Row3.X);
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00011F68 File Offset: 0x00010168
		public Vector4d Column1
		{
			get
			{
				return new Vector4d(this.Row0.Y, this.Row1.Y, this.Row2.Y, this.Row3.Y);
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x00011F9C File Offset: 0x0001019C
		public Vector4d Column2
		{
			get
			{
				return new Vector4d(this.Row0.Z, this.Row1.Z, this.Row2.Z, this.Row3.Z);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x00011FD0 File Offset: 0x000101D0
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00011FE0 File Offset: 0x000101E0
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

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x00011FF0 File Offset: 0x000101F0
		// (set) Token: 0x06000429 RID: 1065 RVA: 0x00012000 File Offset: 0x00010200
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

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x00012010 File Offset: 0x00010210
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x00012020 File Offset: 0x00010220
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

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x00012030 File Offset: 0x00010230
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x00012040 File Offset: 0x00010240
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

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x00012050 File Offset: 0x00010250
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x00012060 File Offset: 0x00010260
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

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x00012070 File Offset: 0x00010270
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x00012080 File Offset: 0x00010280
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

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00012090 File Offset: 0x00010290
		// (set) Token: 0x06000433 RID: 1075 RVA: 0x000120A0 File Offset: 0x000102A0
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

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x000120B0 File Offset: 0x000102B0
		// (set) Token: 0x06000435 RID: 1077 RVA: 0x000120C0 File Offset: 0x000102C0
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

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x000120D0 File Offset: 0x000102D0
		// (set) Token: 0x06000437 RID: 1079 RVA: 0x000120E0 File Offset: 0x000102E0
		public double M33
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

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x000120F0 File Offset: 0x000102F0
		// (set) Token: 0x06000439 RID: 1081 RVA: 0x00012100 File Offset: 0x00010300
		public double M41
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

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x00012110 File Offset: 0x00010310
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x00012120 File Offset: 0x00010320
		public double M42
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

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x00012130 File Offset: 0x00010330
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x00012140 File Offset: 0x00010340
		public double M43
		{
			get
			{
				return this.Row3.Z;
			}
			set
			{
				this.Row3.Z = value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x00012150 File Offset: 0x00010350
		// (set) Token: 0x0600043F RID: 1087 RVA: 0x00012178 File Offset: 0x00010378
		public Vector3d Diagonal
		{
			get
			{
				return new Vector3d(this.Row0.X, this.Row1.Y, this.Row2.Z);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Z = value.Z;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x000121B0 File Offset: 0x000103B0
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y + this.Row2.Z;
			}
		}

		// Token: 0x170000EC RID: 236
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

		// Token: 0x06000443 RID: 1091 RVA: 0x000122F4 File Offset: 0x000104F4
		public void Invert()
		{
			this = Matrix4x3d.Invert(this);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00012308 File Offset: 0x00010508
		public static void CreateFromAxisAngle(Vector3d axis, double angle, out Matrix4x3d result)
		{
			axis.Normalize();
			double x = axis.X;
			double y = axis.Y;
			double z = axis.Z;
			double num = Math.Cos(-angle);
			double num2 = Math.Sin(-angle);
			double num3 = 1.0 - num;
			double num4 = num3 * x * x;
			double num5 = num3 * x * y;
			double num6 = num3 * x * z;
			double num7 = num3 * y * y;
			double num8 = num3 * y * z;
			double num9 = num3 * z * z;
			double num10 = num2 * x;
			double num11 = num2 * y;
			double num12 = num2 * z;
			result.Row0.X = num4 + num;
			result.Row0.Y = num5 - num12;
			result.Row0.Z = num6 + num11;
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num;
			result.Row1.Z = num8 - num10;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
			result.Row3.Z = 0.0;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00012460 File Offset: 0x00010660
		public static Matrix4x3d CreateFromAxisAngle(Vector3d axis, double angle)
		{
			Matrix4x3d result;
			Matrix4x3d.CreateFromAxisAngle(axis, angle, out result);
			return result;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00012478 File Offset: 0x00010678
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix4x3d result)
		{
			double num = (double)q.X;
			double num2 = (double)q.Y;
			double num3 = (double)q.Z;
			double num4 = (double)q.W;
			double num5 = 2.0 * num;
			double num6 = 2.0 * num2;
			double num7 = 2.0 * num3;
			double num8 = num5 * num;
			double num9 = num6 * num2;
			double num10 = num7 * num3;
			double num11 = num5 * num2;
			double num12 = num5 * num3;
			double num13 = num6 * num3;
			double num14 = num4 * num5;
			double num15 = num4 * num6;
			double num16 = num4 * num7;
			result.Row0.X = 1.0 - num9 - num10;
			result.Row0.Y = num11 - num16;
			result.Row0.Z = num12 + num15;
			result.Row1.X = num11 + num16;
			result.Row1.Y = 1.0 - num8 - num10;
			result.Row1.Z = num13 - num14;
			result.Row2.X = num12 - num15;
			result.Row2.Y = num13 + num14;
			result.Row2.Z = 1.0 - num8 - num9;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
			result.Row3.Z = 0.0;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x000125EC File Offset: 0x000107EC
		public static Matrix4x3d CreateFromQuaternion(Quaternion q)
		{
			Matrix4x3d result;
			Matrix4x3d.CreateFromQuaternion(ref q, out result);
			return result;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00012604 File Offset: 0x00010804
		public static void CreateRotationX(double angle, out Matrix4x3d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = 1.0;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = num;
			result.Row1.Z = num2;
			result.Row2.X = 0.0;
			result.Row2.Y = -num2;
			result.Row2.Z = num;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
			result.Row3.Z = 0.0;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x000126F4 File Offset: 0x000108F4
		public static Matrix4x3d CreateRotationX(double angle)
		{
			Matrix4x3d result;
			Matrix4x3d.CreateRotationX(angle, out result);
			return result;
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0001270C File Offset: 0x0001090C
		public static void CreateRotationY(double angle, out Matrix4x3d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = 0.0;
			result.Row0.Z = -num2;
			result.Row1.X = 0.0;
			result.Row1.Y = 1.0;
			result.Row1.Z = 0.0;
			result.Row2.X = num2;
			result.Row2.Y = 0.0;
			result.Row2.Z = num;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
			result.Row3.Z = 0.0;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000127FC File Offset: 0x000109FC
		public static Matrix4x3d CreateRotationY(double angle)
		{
			Matrix4x3d result;
			Matrix4x3d.CreateRotationY(angle, out result);
			return result;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00012814 File Offset: 0x00010A14
		public static void CreateRotationZ(double angle, out Matrix4x3d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row0.Z = 0.0;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row1.Z = 0.0;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row2.Z = 1.0;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
			result.Row3.Z = 0.0;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00012904 File Offset: 0x00010B04
		public static Matrix4x3d CreateRotationZ(double angle)
		{
			Matrix4x3d result;
			Matrix4x3d.CreateRotationZ(angle, out result);
			return result;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0001291C File Offset: 0x00010B1C
		public static void CreateTranslation(double x, double y, double z, out Matrix4x3d result)
		{
			result.Row0.X = 1.0;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = 1.0;
			result.Row1.Z = 0.0;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row2.Z = 1.0;
			result.Row3.X = x;
			result.Row3.Y = y;
			result.Row3.Z = z;
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00012A04 File Offset: 0x00010C04
		public static void CreateTranslation(ref Vector3d vector, out Matrix4x3d result)
		{
			result.Row0.X = 1.0;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = 1.0;
			result.Row1.Z = 0.0;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row2.Z = 1.0;
			result.Row3.X = vector.X;
			result.Row3.Y = vector.Y;
			result.Row3.Z = vector.Z;
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00012AF8 File Offset: 0x00010CF8
		public static Matrix4x3d CreateTranslation(double x, double y, double z)
		{
			Matrix4x3d result;
			Matrix4x3d.CreateTranslation(x, y, z, out result);
			return result;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00012B10 File Offset: 0x00010D10
		public static Matrix4x3d CreateTranslation(Vector3d vector)
		{
			Matrix4x3d result;
			Matrix4x3d.CreateTranslation(vector.X, vector.Y, vector.Z, out result);
			return result;
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00012B3C File Offset: 0x00010D3C
		public static Matrix4x3d CreateScale(double scale)
		{
			return Matrix4x3d.CreateScale(scale, scale, scale);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00012B48 File Offset: 0x00010D48
		public static Matrix4x3d CreateScale(Vector3d scale)
		{
			return Matrix4x3d.CreateScale(scale.X, scale.Y, scale.Z);
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00012B64 File Offset: 0x00010D64
		public static Matrix4x3d CreateScale(double x, double y, double z)
		{
			Matrix4x3d result;
			result.Row0.X = x;
			result.Row0.Y = 0.0;
			result.Row0.Z = 0.0;
			result.Row1.X = 0.0;
			result.Row1.Y = y;
			result.Row1.Z = 0.0;
			result.Row2.X = 0.0;
			result.Row2.Y = 0.0;
			result.Row2.Z = z;
			result.Row3.X = 0.0;
			result.Row3.Y = 0.0;
			result.Row3.Z = 0.0;
			return result;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00012C58 File Offset: 0x00010E58
		public static Matrix4d Mult(Matrix4x3d left, Matrix3x4d right)
		{
			Matrix4d result;
			Matrix4x3d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00012C74 File Offset: 0x00010E74
		public static void Mult(ref Matrix4x3d left, ref Matrix3x4d right, out Matrix4d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double z3 = left.Row2.Z;
			double x4 = left.Row3.X;
			double y4 = left.Row3.Y;
			double z4 = left.Row3.Z;
			double x5 = right.Row0.X;
			double y5 = right.Row0.Y;
			double z5 = right.Row0.Z;
			double w = right.Row0.W;
			double x6 = right.Row1.X;
			double y6 = right.Row1.Y;
			double z6 = right.Row1.Z;
			double w2 = right.Row1.W;
			double x7 = right.Row2.X;
			double y7 = right.Row2.Y;
			double z7 = right.Row2.Z;
			double w3 = right.Row2.W;
			result.Row0.X = x * x5 + y * x6 + z * x7;
			result.Row0.Y = x * y5 + y * y6 + z * y7;
			result.Row0.Z = x * z5 + y * z6 + z * z7;
			result.Row0.W = x * w + y * w2 + z * w3;
			result.Row1.X = x2 * x5 + y2 * x6 + z2 * x7;
			result.Row1.Y = x2 * y5 + y2 * y6 + z2 * y7;
			result.Row1.Z = x2 * z5 + y2 * z6 + z2 * z7;
			result.Row1.W = x2 * w + y2 * w2 + z2 * w3;
			result.Row2.X = x3 * x5 + y3 * x6 + z3 * x7;
			result.Row2.Y = x3 * y5 + y3 * y6 + z3 * y7;
			result.Row2.Z = x3 * z5 + y3 * z6 + z3 * z7;
			result.Row2.W = x3 * w + y3 * w2 + z3 * w3;
			result.Row3.X = x4 * x5 + y4 * x6 + z4 * x7;
			result.Row3.Y = x4 * y5 + y4 * y6 + z4 * y7;
			result.Row3.Z = x4 * z5 + y4 * z6 + z4 * z7;
			result.Row3.W = x4 * w + y4 * w2 + z4 * w3;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00012F68 File Offset: 0x00011168
		public static Matrix4x3d Mult(Matrix4x3d left, Matrix4x3d right)
		{
			Matrix4x3d result;
			Matrix4x3d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00012F84 File Offset: 0x00011184
		public static void Mult(ref Matrix4x3d left, ref Matrix4x3d right, out Matrix4x3d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double z3 = left.Row2.Z;
			double x4 = left.Row3.X;
			double y4 = left.Row3.Y;
			double z4 = left.Row3.Z;
			double x5 = right.Row0.X;
			double y5 = right.Row0.Y;
			double z5 = right.Row0.Z;
			double x6 = right.Row1.X;
			double y6 = right.Row1.Y;
			double z6 = right.Row1.Z;
			double x7 = right.Row2.X;
			double y7 = right.Row2.Y;
			double z7 = right.Row2.Z;
			double x8 = right.Row3.X;
			double y8 = right.Row3.Y;
			double z8 = right.Row3.Z;
			result.Row0.X = x * x5 + y * x6 + z * x7 + x8;
			result.Row0.Y = x * y5 + y * y6 + z * y7 + y8;
			result.Row0.Z = x * z5 + y * z6 + z * z7 + z8;
			result.Row1.X = x2 * x5 + y2 * x6 + z2 * x7 + x8;
			result.Row1.Y = x2 * y5 + y2 * y6 + z2 * y7 + y8;
			result.Row1.Z = x2 * z5 + y2 * z6 + z2 * z7 + z8;
			result.Row2.X = x3 * x5 + y3 * x6 + z3 * x7 + x8;
			result.Row2.Y = x3 * y5 + y3 * y6 + z3 * y7 + y8;
			result.Row2.Z = x3 * z5 + y3 * z6 + z3 * z7 + z8;
			result.Row3.X = x4 * x5 + y4 * x6 + z4 * x7 + x8;
			result.Row3.Y = x4 * y5 + y4 * y6 + z4 * y7 + y8;
			result.Row3.Z = x4 * z5 + y4 * z6 + z4 * z7 + z8;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00013230 File Offset: 0x00011430
		public static Matrix4x3d Mult(Matrix4x3d left, double right)
		{
			Matrix4x3d result;
			Matrix4x3d.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00013248 File Offset: 0x00011448
		public static void Mult(ref Matrix4x3d left, double right, out Matrix4x3d result)
		{
			result.Row0 = left.Row0 * right;
			result.Row1 = left.Row1 * right;
			result.Row2 = left.Row2 * right;
			result.Row3 = left.Row3 * right;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000132A0 File Offset: 0x000114A0
		public static Matrix4x3d Add(Matrix4x3d left, Matrix4x3d right)
		{
			Matrix4x3d result;
			Matrix4x3d.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x000132BC File Offset: 0x000114BC
		public static void Add(ref Matrix4x3d left, ref Matrix4x3d right, out Matrix4x3d result)
		{
			result.Row0 = left.Row0 + right.Row0;
			result.Row1 = left.Row1 + right.Row1;
			result.Row2 = left.Row2 + right.Row2;
			result.Row3 = left.Row3 + right.Row3;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00013328 File Offset: 0x00011528
		public static Matrix4x3d Subtract(Matrix4x3d left, Matrix4x3d right)
		{
			Matrix4x3d result;
			Matrix4x3d.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00013344 File Offset: 0x00011544
		public static void Subtract(ref Matrix4x3d left, ref Matrix4x3d right, out Matrix4x3d result)
		{
			result.Row0 = left.Row0 - right.Row0;
			result.Row1 = left.Row1 - right.Row1;
			result.Row2 = left.Row2 - right.Row2;
			result.Row3 = left.Row3 - right.Row3;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x000133B0 File Offset: 0x000115B0
		public static Matrix4x3d Invert(Matrix4x3d mat)
		{
			Matrix4x3d result;
			Matrix4x3d.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000133C8 File Offset: 0x000115C8
		public static void Invert(ref Matrix4x3d mat, out Matrix4x3d result)
		{
			Matrix3d matrix3d = new Matrix3d(mat.Column0.Xyz, mat.Column1.Xyz, mat.Column2.Xyz);
			matrix3d.Row0 /= matrix3d.Row0.LengthSquared;
			matrix3d.Row1 /= matrix3d.Row1.LengthSquared;
			matrix3d.Row2 /= matrix3d.Row2.LengthSquared;
			Vector3d row = mat.Row3;
			result.Row0 = matrix3d.Row0;
			result.Row1 = matrix3d.Row1;
			result.Row2 = matrix3d.Row2;
			result.Row3 = new Vector3d(-Vector3d.Dot(matrix3d.Row0, row), -Vector3d.Dot(matrix3d.Row1, row), -Vector3d.Dot(matrix3d.Row2, row));
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000134C4 File Offset: 0x000116C4
		public static Matrix3x4d Transpose(Matrix4x3d mat)
		{
			return new Matrix3x4d(mat.Column0, mat.Column1, mat.Column2);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000134E0 File Offset: 0x000116E0
		public static void Transpose(ref Matrix4x3d mat, out Matrix3x4d result)
		{
			result.Row0 = mat.Column0;
			result.Row1 = mat.Column1;
			result.Row2 = mat.Column2;
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00013508 File Offset: 0x00011708
		public static Matrix4d operator *(Matrix4x3d left, Matrix3x4d right)
		{
			return Matrix4x3d.Mult(left, right);
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00013514 File Offset: 0x00011714
		public static Matrix4x3d operator *(Matrix4x3d left, Matrix4x3d right)
		{
			return Matrix4x3d.Mult(left, right);
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00013520 File Offset: 0x00011720
		public static Matrix4x3d operator *(Matrix4x3d left, double right)
		{
			return Matrix4x3d.Mult(left, right);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0001352C File Offset: 0x0001172C
		public static Matrix4x3d operator +(Matrix4x3d left, Matrix4x3d right)
		{
			return Matrix4x3d.Add(left, right);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00013538 File Offset: 0x00011738
		public static Matrix4x3d operator -(Matrix4x3d left, Matrix4x3d right)
		{
			return Matrix4x3d.Subtract(left, right);
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00013544 File Offset: 0x00011744
		public static bool operator ==(Matrix4x3d left, Matrix4x3d right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00013550 File Offset: 0x00011750
		public static bool operator !=(Matrix4x3d left, Matrix4x3d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00013560 File Offset: 0x00011760
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", this.Row0, this.Row1, this.Row2);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00013590 File Offset: 0x00011790
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode();
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x000135C8 File Offset: 0x000117C8
		public override bool Equals(object obj)
		{
			return obj is Matrix4x3d && this.Equals((Matrix4x3d)obj);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000135E0 File Offset: 0x000117E0
		public bool Equals(Matrix4x3d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2 && this.Row3 == other.Row3;
		}

		// Token: 0x040000A6 RID: 166
		public Vector3d Row0;

		// Token: 0x040000A7 RID: 167
		public Vector3d Row1;

		// Token: 0x040000A8 RID: 168
		public Vector3d Row2;

		// Token: 0x040000A9 RID: 169
		public Vector3d Row3;

		// Token: 0x040000AA RID: 170
		public static Matrix4x3d Zero = new Matrix4x3d(Vector3d.Zero, Vector3d.Zero, Vector3d.Zero, Vector3d.Zero);
	}
}
