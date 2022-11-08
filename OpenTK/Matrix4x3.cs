using System;

namespace OpenTK
{
	// Token: 0x02000022 RID: 34
	[Serializable]
	public struct Matrix4x3 : IEquatable<Matrix4x3>
	{
		// Token: 0x060003D3 RID: 979 RVA: 0x00010828 File Offset: 0x0000EA28
		public Matrix4x3(Vector3 row0, Vector3 row1, Vector3 row2, Vector3 row3)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
			this.Row3 = row3;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00010848 File Offset: 0x0000EA48
		public Matrix4x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22, float m30, float m31, float m32)
		{
			this.Row0 = new Vector3(m00, m01, m02);
			this.Row1 = new Vector3(m10, m11, m12);
			this.Row2 = new Vector3(m20, m21, m22);
			this.Row3 = new Vector3(m30, m31, m32);
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00010898 File Offset: 0x0000EA98
		public Vector4 Column0
		{
			get
			{
				return new Vector4(this.Row0.X, this.Row1.X, this.Row2.X, this.Row3.X);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x000108CC File Offset: 0x0000EACC
		public Vector4 Column1
		{
			get
			{
				return new Vector4(this.Row0.Y, this.Row1.Y, this.Row2.Y, this.Row3.Y);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x00010900 File Offset: 0x0000EB00
		public Vector4 Column2
		{
			get
			{
				return new Vector4(this.Row0.Z, this.Row1.Z, this.Row2.Z, this.Row3.Z);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00010934 File Offset: 0x0000EB34
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00010944 File Offset: 0x0000EB44
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

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00010954 File Offset: 0x0000EB54
		// (set) Token: 0x060003DB RID: 987 RVA: 0x00010964 File Offset: 0x0000EB64
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

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060003DC RID: 988 RVA: 0x00010974 File Offset: 0x0000EB74
		// (set) Token: 0x060003DD RID: 989 RVA: 0x00010984 File Offset: 0x0000EB84
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

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00010994 File Offset: 0x0000EB94
		// (set) Token: 0x060003DF RID: 991 RVA: 0x000109A4 File Offset: 0x0000EBA4
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

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x000109B4 File Offset: 0x0000EBB4
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x000109C4 File Offset: 0x0000EBC4
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

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x000109D4 File Offset: 0x0000EBD4
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x000109E4 File Offset: 0x0000EBE4
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

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x000109F4 File Offset: 0x0000EBF4
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x00010A04 File Offset: 0x0000EC04
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

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00010A14 File Offset: 0x0000EC14
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x00010A24 File Offset: 0x0000EC24
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

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x00010A34 File Offset: 0x0000EC34
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x00010A44 File Offset: 0x0000EC44
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

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x00010A54 File Offset: 0x0000EC54
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x00010A64 File Offset: 0x0000EC64
		public float M41
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

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x00010A74 File Offset: 0x0000EC74
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x00010A84 File Offset: 0x0000EC84
		public float M42
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

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x00010A94 File Offset: 0x0000EC94
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x00010AA4 File Offset: 0x0000ECA4
		public float M43
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060003F0 RID: 1008 RVA: 0x00010AB4 File Offset: 0x0000ECB4
		// (set) Token: 0x060003F1 RID: 1009 RVA: 0x00010ADC File Offset: 0x0000ECDC
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

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00010B14 File Offset: 0x0000ED14
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y + this.Row2.Z;
			}
		}

		// Token: 0x170000DA RID: 218
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

		// Token: 0x060003F5 RID: 1013 RVA: 0x00010C58 File Offset: 0x0000EE58
		public void Invert()
		{
			this = Matrix4x3.Invert(this);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00010C6C File Offset: 0x0000EE6C
		public static void CreateFromAxisAngle(Vector3 axis, float angle, out Matrix4x3 result)
		{
			axis.Normalize();
			float x = axis.X;
			float y = axis.Y;
			float z = axis.Z;
			float num = (float)Math.Cos((double)(-(double)angle));
			float num2 = (float)Math.Sin((double)(-(double)angle));
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
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num;
			result.Row1.Z = num8 - num10;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
			result.Row3.Z = 0f;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x00010DB8 File Offset: 0x0000EFB8
		public static Matrix4x3 CreateFromAxisAngle(Vector3 axis, float angle)
		{
			Matrix4x3 result;
			Matrix4x3.CreateFromAxisAngle(axis, angle, out result);
			return result;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00010DD0 File Offset: 0x0000EFD0
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix4x3 result)
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
			float num10 = w * num;
			float num11 = w * num2;
			float num12 = w * num3;
			result.Row0.X = 1f - num5 - num6;
			result.Row0.Y = num7 - num12;
			result.Row0.Z = num8 + num11;
			result.Row1.X = num7 + num12;
			result.Row1.Y = 1f - num4 - num6;
			result.Row1.Z = num9 - num10;
			result.Row2.X = num8 - num11;
			result.Row2.Y = num9 + num10;
			result.Row2.Z = 1f - num4 - num5;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
			result.Row3.Z = 0f;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00010F1C File Offset: 0x0000F11C
		public static Matrix4x3 CreateFromQuaternion(Quaternion q)
		{
			Matrix4x3 result;
			Matrix4x3.CreateFromQuaternion(ref q, out result);
			return result;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00010F34 File Offset: 0x0000F134
		public static void CreateRotationX(float angle, out Matrix4x3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = 1f;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = num;
			result.Row1.Z = num2;
			result.Row2.X = 0f;
			result.Row2.Y = -num2;
			result.Row2.Z = num;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
			result.Row3.Z = 0f;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00011004 File Offset: 0x0000F204
		public static Matrix4x3 CreateRotationX(float angle)
		{
			Matrix4x3 result;
			Matrix4x3.CreateRotationX(angle, out result);
			return result;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0001101C File Offset: 0x0000F21C
		public static void CreateRotationY(float angle, out Matrix4x3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = num;
			result.Row0.Y = 0f;
			result.Row0.Z = -num2;
			result.Row1.X = 0f;
			result.Row1.Y = 1f;
			result.Row1.Z = 0f;
			result.Row2.X = num2;
			result.Row2.Y = 0f;
			result.Row2.Z = num;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
			result.Row3.Z = 0f;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x000110EC File Offset: 0x0000F2EC
		public static Matrix4x3 CreateRotationY(float angle)
		{
			Matrix4x3 result;
			Matrix4x3.CreateRotationY(angle, out result);
			return result;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00011104 File Offset: 0x0000F304
		public static void CreateRotationZ(float angle, out Matrix4x3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row0.Z = 0f;
			result.Row1.X = -num2;
			result.Row1.Y = num;
			result.Row1.Z = 0f;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row2.Z = 1f;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
			result.Row3.Z = 0f;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000111D4 File Offset: 0x0000F3D4
		public static Matrix4x3 CreateRotationZ(float angle)
		{
			Matrix4x3 result;
			Matrix4x3.CreateRotationZ(angle, out result);
			return result;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000111EC File Offset: 0x0000F3EC
		public static void CreateTranslation(float x, float y, float z, out Matrix4x3 result)
		{
			result.Row0.X = 1f;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = 1f;
			result.Row1.Z = 0f;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row2.Z = 1f;
			result.Row3.X = x;
			result.Row3.Y = y;
			result.Row3.Z = z;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000112B0 File Offset: 0x0000F4B0
		public static void CreateTranslation(ref Vector3 vector, out Matrix4x3 result)
		{
			result.Row0.X = 1f;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = 1f;
			result.Row1.Z = 0f;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row2.Z = 1f;
			result.Row3.X = vector.X;
			result.Row3.Y = vector.Y;
			result.Row3.Z = vector.Z;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00011380 File Offset: 0x0000F580
		public static Matrix4x3 CreateTranslation(float x, float y, float z)
		{
			Matrix4x3 result;
			Matrix4x3.CreateTranslation(x, y, z, out result);
			return result;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00011398 File Offset: 0x0000F598
		public static Matrix4x3 CreateTranslation(Vector3 vector)
		{
			Matrix4x3 result;
			Matrix4x3.CreateTranslation(vector.X, vector.Y, vector.Z, out result);
			return result;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000113C4 File Offset: 0x0000F5C4
		public static Matrix4x3 CreateScale(float scale)
		{
			return Matrix4x3.CreateScale(scale, scale, scale);
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000113D0 File Offset: 0x0000F5D0
		public static Matrix4x3 CreateScale(Vector3 scale)
		{
			return Matrix4x3.CreateScale(scale.X, scale.Y, scale.Z);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x000113EC File Offset: 0x0000F5EC
		public static Matrix4x3 CreateScale(float x, float y, float z)
		{
			Matrix4x3 result;
			result.Row0.X = x;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = y;
			result.Row1.Z = 0f;
			result.Row2.X = 0f;
			result.Row2.Y = 0f;
			result.Row2.Z = z;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
			result.Row3.Z = 0f;
			return result;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x000114BC File Offset: 0x0000F6BC
		public static Matrix4 Mult(Matrix4x3 left, Matrix3x4 right)
		{
			Matrix4 result;
			Matrix4x3.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x000114D8 File Offset: 0x0000F6D8
		public static void Mult(ref Matrix4x3 left, ref Matrix3x4 right, out Matrix4 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float z3 = left.Row2.Z;
			float x4 = left.Row3.X;
			float y4 = left.Row3.Y;
			float z4 = left.Row3.Z;
			float x5 = right.Row0.X;
			float y5 = right.Row0.Y;
			float z5 = right.Row0.Z;
			float w = right.Row0.W;
			float x6 = right.Row1.X;
			float y6 = right.Row1.Y;
			float z6 = right.Row1.Z;
			float w2 = right.Row1.W;
			float x7 = right.Row2.X;
			float y7 = right.Row2.Y;
			float z7 = right.Row2.Z;
			float w3 = right.Row2.W;
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

		// Token: 0x06000409 RID: 1033 RVA: 0x000117CC File Offset: 0x0000F9CC
		public static Matrix4x3 Mult(Matrix4x3 left, Matrix4x3 right)
		{
			Matrix4x3 result;
			Matrix4x3.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x000117E8 File Offset: 0x0000F9E8
		public static void Mult(ref Matrix4x3 left, ref Matrix4x3 right, out Matrix4x3 result)
		{
			float x = left.Row0.X;
			float y = left.Row0.Y;
			float z = left.Row0.Z;
			float x2 = left.Row1.X;
			float y2 = left.Row1.Y;
			float z2 = left.Row1.Z;
			float x3 = left.Row2.X;
			float y3 = left.Row2.Y;
			float z3 = left.Row2.Z;
			float x4 = left.Row3.X;
			float y4 = left.Row3.Y;
			float z4 = left.Row3.Z;
			float x5 = right.Row0.X;
			float y5 = right.Row0.Y;
			float z5 = right.Row0.Z;
			float x6 = right.Row1.X;
			float y6 = right.Row1.Y;
			float z6 = right.Row1.Z;
			float x7 = right.Row2.X;
			float y7 = right.Row2.Y;
			float z7 = right.Row2.Z;
			float x8 = right.Row3.X;
			float y8 = right.Row3.Y;
			float z8 = right.Row3.Z;
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

		// Token: 0x0600040B RID: 1035 RVA: 0x00011A94 File Offset: 0x0000FC94
		public static Matrix4x3 Mult(Matrix4x3 left, float right)
		{
			Matrix4x3 result;
			Matrix4x3.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00011AAC File Offset: 0x0000FCAC
		public static void Mult(ref Matrix4x3 left, float right, out Matrix4x3 result)
		{
			result.Row0 = left.Row0 * right;
			result.Row1 = left.Row1 * right;
			result.Row2 = left.Row2 * right;
			result.Row3 = left.Row3 * right;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00011B04 File Offset: 0x0000FD04
		public static Matrix4x3 Add(Matrix4x3 left, Matrix4x3 right)
		{
			Matrix4x3 result;
			Matrix4x3.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00011B20 File Offset: 0x0000FD20
		public static void Add(ref Matrix4x3 left, ref Matrix4x3 right, out Matrix4x3 result)
		{
			result.Row0 = left.Row0 + right.Row0;
			result.Row1 = left.Row1 + right.Row1;
			result.Row2 = left.Row2 + right.Row2;
			result.Row3 = left.Row3 + right.Row3;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00011B8C File Offset: 0x0000FD8C
		public static Matrix4x3 Subtract(Matrix4x3 left, Matrix4x3 right)
		{
			Matrix4x3 result;
			Matrix4x3.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00011BA8 File Offset: 0x0000FDA8
		public static void Subtract(ref Matrix4x3 left, ref Matrix4x3 right, out Matrix4x3 result)
		{
			result.Row0 = left.Row0 - right.Row0;
			result.Row1 = left.Row1 - right.Row1;
			result.Row2 = left.Row2 - right.Row2;
			result.Row3 = left.Row3 - right.Row3;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00011C14 File Offset: 0x0000FE14
		public static Matrix4x3 Invert(Matrix4x3 mat)
		{
			Matrix4x3 result;
			Matrix4x3.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00011C2C File Offset: 0x0000FE2C
		public static void Invert(ref Matrix4x3 mat, out Matrix4x3 result)
		{
			Matrix3 matrix = new Matrix3(mat.Column0.Xyz, mat.Column1.Xyz, mat.Column2.Xyz);
			matrix.Row0 /= matrix.Row0.LengthSquared;
			matrix.Row1 /= matrix.Row1.LengthSquared;
			matrix.Row2 /= matrix.Row2.LengthSquared;
			Vector3 row = mat.Row3;
			result.Row0 = matrix.Row0;
			result.Row1 = matrix.Row1;
			result.Row2 = matrix.Row2;
			result.Row3 = new Vector3(-Vector3.Dot(matrix.Row0, row), -Vector3.Dot(matrix.Row1, row), -Vector3.Dot(matrix.Row2, row));
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00011D28 File Offset: 0x0000FF28
		public static Matrix3x4 Transpose(Matrix4x3 mat)
		{
			return new Matrix3x4(mat.Column0, mat.Column1, mat.Column2);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00011D44 File Offset: 0x0000FF44
		public static void Transpose(ref Matrix4x3 mat, out Matrix3x4 result)
		{
			result.Row0 = mat.Column0;
			result.Row1 = mat.Column1;
			result.Row2 = mat.Column2;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00011D6C File Offset: 0x0000FF6C
		public static Matrix4 operator *(Matrix4x3 left, Matrix3x4 right)
		{
			return Matrix4x3.Mult(left, right);
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00011D78 File Offset: 0x0000FF78
		public static Matrix4x3 operator *(Matrix4x3 left, Matrix4x3 right)
		{
			return Matrix4x3.Mult(left, right);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00011D84 File Offset: 0x0000FF84
		public static Matrix4x3 operator *(Matrix4x3 left, float right)
		{
			return Matrix4x3.Mult(left, right);
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00011D90 File Offset: 0x0000FF90
		public static Matrix4x3 operator +(Matrix4x3 left, Matrix4x3 right)
		{
			return Matrix4x3.Add(left, right);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00011D9C File Offset: 0x0000FF9C
		public static Matrix4x3 operator -(Matrix4x3 left, Matrix4x3 right)
		{
			return Matrix4x3.Subtract(left, right);
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00011DA8 File Offset: 0x0000FFA8
		public static bool operator ==(Matrix4x3 left, Matrix4x3 right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00011DB4 File Offset: 0x0000FFB4
		public static bool operator !=(Matrix4x3 left, Matrix4x3 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00011DC4 File Offset: 0x0000FFC4
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", this.Row0, this.Row1, this.Row2);
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00011DF4 File Offset: 0x0000FFF4
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode();
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00011E2C File Offset: 0x0001002C
		public override bool Equals(object obj)
		{
			return obj is Matrix4x3 && this.Equals((Matrix4x3)obj);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00011E44 File Offset: 0x00010044
		public bool Equals(Matrix4x3 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2 && this.Row3 == other.Row3;
		}

		// Token: 0x040000A1 RID: 161
		public Vector3 Row0;

		// Token: 0x040000A2 RID: 162
		public Vector3 Row1;

		// Token: 0x040000A3 RID: 163
		public Vector3 Row2;

		// Token: 0x040000A4 RID: 164
		public Vector3 Row3;

		// Token: 0x040000A5 RID: 165
		public static readonly Matrix4x3 Zero = new Matrix4x3(Vector3.Zero, Vector3.Zero, Vector3.Zero, Vector3.Zero);
	}
}
