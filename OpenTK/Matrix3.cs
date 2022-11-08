using System;

namespace OpenTK
{
	// Token: 0x0200001B RID: 27
	[Serializable]
	public struct Matrix3 : IEquatable<Matrix3>
	{
		// Token: 0x060001FC RID: 508 RVA: 0x00008648 File Offset: 0x00006848
		public Matrix3(Vector3 row0, Vector3 row1, Vector3 row2)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00008660 File Offset: 0x00006860
		public Matrix3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
		{
			this.Row0 = new Vector3(m00, m01, m02);
			this.Row1 = new Vector3(m10, m11, m12);
			this.Row2 = new Vector3(m20, m21, m22);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00008694 File Offset: 0x00006894
		public Matrix3(Matrix4 matrix)
		{
			this.Row0 = matrix.Row0.Xyz;
			this.Row1 = matrix.Row1.Xyz;
			this.Row2 = matrix.Row2.Xyz;
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001FF RID: 511 RVA: 0x000086CC File Offset: 0x000068CC
		public float Determinant
		{
			get
			{
				float x = this.Row0.X;
				float y = this.Row0.Y;
				float z = this.Row0.Z;
				float x2 = this.Row1.X;
				float y2 = this.Row1.Y;
				float z2 = this.Row1.Z;
				float x3 = this.Row2.X;
				float y3 = this.Row2.Y;
				float z3 = this.Row2.Z;
				return x * y2 * z3 + y * z2 * x3 + z * x2 * y3 - z * y2 * x3 - x * z2 * y3 - y * x2 * z3;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000200 RID: 512 RVA: 0x00008778 File Offset: 0x00006978
		public Vector3 Column0
		{
			get
			{
				return new Vector3(this.Row0.X, this.Row1.X, this.Row2.X);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000201 RID: 513 RVA: 0x000087A0 File Offset: 0x000069A0
		public Vector3 Column1
		{
			get
			{
				return new Vector3(this.Row0.Y, this.Row1.Y, this.Row2.Y);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000202 RID: 514 RVA: 0x000087C8 File Offset: 0x000069C8
		public Vector3 Column2
		{
			get
			{
				return new Vector3(this.Row0.Z, this.Row1.Z, this.Row2.Z);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000203 RID: 515 RVA: 0x000087F0 File Offset: 0x000069F0
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00008800 File Offset: 0x00006A00
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

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00008810 File Offset: 0x00006A10
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00008820 File Offset: 0x00006A20
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

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00008830 File Offset: 0x00006A30
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00008840 File Offset: 0x00006A40
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

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00008850 File Offset: 0x00006A50
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00008860 File Offset: 0x00006A60
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

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600020B RID: 523 RVA: 0x00008870 File Offset: 0x00006A70
		// (set) Token: 0x0600020C RID: 524 RVA: 0x00008880 File Offset: 0x00006A80
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

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00008890 File Offset: 0x00006A90
		// (set) Token: 0x0600020E RID: 526 RVA: 0x000088A0 File Offset: 0x00006AA0
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600020F RID: 527 RVA: 0x000088B0 File Offset: 0x00006AB0
		// (set) Token: 0x06000210 RID: 528 RVA: 0x000088C0 File Offset: 0x00006AC0
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

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000211 RID: 529 RVA: 0x000088D0 File Offset: 0x00006AD0
		// (set) Token: 0x06000212 RID: 530 RVA: 0x000088E0 File Offset: 0x00006AE0
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

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000213 RID: 531 RVA: 0x000088F0 File Offset: 0x00006AF0
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00008900 File Offset: 0x00006B00
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

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00008910 File Offset: 0x00006B10
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00008938 File Offset: 0x00006B38
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

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00008970 File Offset: 0x00006B70
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y + this.Row2.Z;
			}
		}

		// Token: 0x17000072 RID: 114
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

		// Token: 0x0600021A RID: 538 RVA: 0x00008A94 File Offset: 0x00006C94
		public void Invert()
		{
			this = Matrix3.Invert(this);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00008AA8 File Offset: 0x00006CA8
		public void Transpose()
		{
			this = Matrix3.Transpose(this);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00008ABC File Offset: 0x00006CBC
		public Matrix3 Normalized()
		{
			Matrix3 result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00008AD8 File Offset: 0x00006CD8
		public void Normalize()
		{
			float determinant = this.Determinant;
			this.Row0 /= determinant;
			this.Row1 /= determinant;
			this.Row2 /= determinant;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00008B24 File Offset: 0x00006D24
		public Matrix3 Inverted()
		{
			Matrix3 result = this;
			if (result.Determinant != 0f)
			{
				result.Invert();
			}
			return result;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00008B50 File Offset: 0x00006D50
		public Matrix3 ClearScale()
		{
			Matrix3 result = this;
			result.Row0 = result.Row0.Normalized();
			result.Row1 = result.Row1.Normalized();
			result.Row2 = result.Row2.Normalized();
			return result;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00008BA0 File Offset: 0x00006DA0
		public Matrix3 ClearRotation()
		{
			Matrix3 result = this;
			result.Row0 = new Vector3(result.Row0.Length, 0f, 0f);
			result.Row1 = new Vector3(0f, result.Row1.Length, 0f);
			result.Row2 = new Vector3(0f, 0f, result.Row2.Length);
			return result;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00008C1C File Offset: 0x00006E1C
		public Vector3 ExtractScale()
		{
			return new Vector3(this.Row0.Length, this.Row1.Length, this.Row2.Length);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00008C44 File Offset: 0x00006E44
		public Quaternion ExtractRotation(bool row_normalise = true)
		{
			Vector3 vector = this.Row0;
			Vector3 vector2 = this.Row1;
			Vector3 vector3 = this.Row2;
			if (row_normalise)
			{
				vector = vector.Normalized();
				vector2 = vector2.Normalized();
				vector3 = vector3.Normalized();
			}
			Quaternion result = default(Quaternion);
			double num = 0.25 * ((double)(vector[0] + vector2[1] + vector3[2]) + 1.0);
			if (num > 0.0)
			{
				double num2 = Math.Sqrt(num);
				result.W = (float)num2;
				num2 = 1.0 / (4.0 * num2);
				result.X = (float)((double)(vector2[2] - vector3[1]) * num2);
				result.Y = (float)((double)(vector3[0] - vector[2]) * num2);
				result.Z = (float)((double)(vector[1] - vector2[0]) * num2);
			}
			else if (vector[0] > vector2[1] && vector[0] > vector3[2])
			{
				double num3 = 2.0 * Math.Sqrt(1.0 + (double)vector[0] - (double)vector2[1] - (double)vector3[2]);
				result.X = (float)(0.25 * num3);
				num3 = 1.0 / num3;
				result.W = (float)((double)(vector3[1] - vector2[2]) * num3);
				result.Y = (float)((double)(vector2[0] + vector[1]) * num3);
				result.Z = (float)((double)(vector3[0] + vector[2]) * num3);
			}
			else if (vector2[1] > vector3[2])
			{
				double num4 = 2.0 * Math.Sqrt(1.0 + (double)vector2[1] - (double)vector[0] - (double)vector3[2]);
				result.Y = (float)(0.25 * num4);
				num4 = 1.0 / num4;
				result.W = (float)((double)(vector3[0] - vector[2]) * num4);
				result.X = (float)((double)(vector2[0] + vector[1]) * num4);
				result.Z = (float)((double)(vector3[1] + vector2[2]) * num4);
			}
			else
			{
				double num5 = 2.0 * Math.Sqrt(1.0 + (double)vector3[2] - (double)vector[0] - (double)vector2[1]);
				result.Z = (float)(0.25 * num5);
				num5 = 1.0 / num5;
				result.W = (float)((double)(vector2[0] - vector[1]) * num5);
				result.X = (float)((double)(vector3[0] + vector[2]) * num5);
				result.Y = (float)((double)(vector3[1] + vector2[2]) * num5);
			}
			result.Normalize();
			return result;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00008FB8 File Offset: 0x000071B8
		public static void CreateFromAxisAngle(Vector3 axis, float angle, out Matrix3 result)
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
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000090D4 File Offset: 0x000072D4
		public static Matrix3 CreateFromAxisAngle(Vector3 axis, float angle)
		{
			Matrix3 result;
			Matrix3.CreateFromAxisAngle(axis, angle, out result);
			return result;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000090EC File Offset: 0x000072EC
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix3 result)
		{
			Vector3 axis;
			float angle;
			q.ToAxisAngle(out axis, out angle);
			Matrix3.CreateFromAxisAngle(axis, angle, out result);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000910C File Offset: 0x0000730C
		public static Matrix3 CreateFromQuaternion(Quaternion q)
		{
			Matrix3 result;
			Matrix3.CreateFromQuaternion(ref q, out result);
			return result;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00009124 File Offset: 0x00007324
		public static void CreateRotationX(float angle, out Matrix3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix3.Identity;
			result.Row1.Y = num;
			result.Row1.Z = num2;
			result.Row2.Y = -num2;
			result.Row2.Z = num;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00009180 File Offset: 0x00007380
		public static Matrix3 CreateRotationX(float angle)
		{
			Matrix3 result;
			Matrix3.CreateRotationX(angle, out result);
			return result;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00009198 File Offset: 0x00007398
		public static void CreateRotationY(float angle, out Matrix3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix3.Identity;
			result.Row0.X = num;
			result.Row0.Z = -num2;
			result.Row2.X = num2;
			result.Row2.Z = num;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000091F4 File Offset: 0x000073F4
		public static Matrix3 CreateRotationY(float angle)
		{
			Matrix3 result;
			Matrix3.CreateRotationY(angle, out result);
			return result;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000920C File Offset: 0x0000740C
		public static void CreateRotationZ(float angle, out Matrix3 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix3.Identity;
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00009268 File Offset: 0x00007468
		public static Matrix3 CreateRotationZ(float angle)
		{
			Matrix3 result;
			Matrix3.CreateRotationZ(angle, out result);
			return result;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00009280 File Offset: 0x00007480
		public static Matrix3 CreateScale(float scale)
		{
			Matrix3 result;
			Matrix3.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00009298 File Offset: 0x00007498
		public static Matrix3 CreateScale(Vector3 scale)
		{
			Matrix3 result;
			Matrix3.CreateScale(ref scale, out result);
			return result;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x000092B0 File Offset: 0x000074B0
		public static Matrix3 CreateScale(float x, float y, float z)
		{
			Matrix3 result;
			Matrix3.CreateScale(x, y, z, out result);
			return result;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x000092C8 File Offset: 0x000074C8
		public static void CreateScale(float scale, out Matrix3 result)
		{
			result = Matrix3.Identity;
			result.Row0.X = scale;
			result.Row1.Y = scale;
			result.Row2.Z = scale;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x000092FC File Offset: 0x000074FC
		public static void CreateScale(ref Vector3 scale, out Matrix3 result)
		{
			result = Matrix3.Identity;
			result.Row0.X = scale.X;
			result.Row1.Y = scale.Y;
			result.Row2.Z = scale.Z;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000933C File Offset: 0x0000753C
		public static void CreateScale(float x, float y, float z, out Matrix3 result)
		{
			result = Matrix3.Identity;
			result.Row0.X = x;
			result.Row1.Y = y;
			result.Row2.Z = z;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00009370 File Offset: 0x00007570
		public static Matrix3 Mult(Matrix3 left, Matrix3 right)
		{
			Matrix3 result;
			Matrix3.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000938C File Offset: 0x0000758C
		public static void Mult(ref Matrix3 left, ref Matrix3 right, out Matrix3 result)
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
			float x4 = right.Row0.X;
			float y4 = right.Row0.Y;
			float z4 = right.Row0.Z;
			float x5 = right.Row1.X;
			float y5 = right.Row1.Y;
			float z5 = right.Row1.Z;
			float x6 = right.Row2.X;
			float y6 = right.Row2.Y;
			float z6 = right.Row2.Z;
			result.Row0.X = x * x4 + y * x5 + z * x6;
			result.Row0.Y = x * y4 + y * y5 + z * y6;
			result.Row0.Z = x * z4 + y * z5 + z * z6;
			result.Row1.X = x2 * x4 + y2 * x5 + z2 * x6;
			result.Row1.Y = x2 * y4 + y2 * y5 + z2 * y6;
			result.Row1.Z = x2 * z4 + y2 * z5 + z2 * z6;
			result.Row2.X = x3 * x4 + y3 * x5 + z3 * x6;
			result.Row2.Y = x3 * y4 + y3 * y5 + z3 * y6;
			result.Row2.Z = x3 * z4 + y3 * z5 + z3 * z6;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00009570 File Offset: 0x00007770
		public static void Invert(ref Matrix3 mat, out Matrix3 result)
		{
			int[] array = new int[3];
			int[] array2 = array;
			int[] array3 = new int[3];
			int[] array4 = array3;
			int[] array5 = new int[]
			{
				-1,
				-1,
				-1
			};
			float[,] array6 = new float[3, 3];
			array6[0, 0] = mat.Row0.X;
			array6[0, 1] = mat.Row0.Y;
			array6[0, 2] = mat.Row0.Z;
			array6[1, 0] = mat.Row1.X;
			array6[1, 1] = mat.Row1.Y;
			array6[1, 2] = mat.Row1.Z;
			array6[2, 0] = mat.Row2.X;
			array6[2, 1] = mat.Row2.Y;
			array6[2, 2] = mat.Row2.Z;
			float[,] array7 = array6;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 3; i++)
			{
				float num3 = 0f;
				for (int j = 0; j < 3; j++)
				{
					if (array5[j] != 0)
					{
						for (int k = 0; k < 3; k++)
						{
							if (array5[k] == -1)
							{
								float num4 = Math.Abs(array7[j, k]);
								if (num4 > num3)
								{
									num3 = num4;
									num2 = j;
									num = k;
								}
							}
							else if (array5[k] > 0)
							{
								result = mat;
								return;
							}
						}
					}
				}
				array5[num]++;
				if (num2 != num)
				{
					for (int l = 0; l < 3; l++)
					{
						float num5 = array7[num2, l];
						array7[num2, l] = array7[num, l];
						array7[num, l] = num5;
					}
				}
				array4[i] = num2;
				array2[i] = num;
				float num6 = array7[num, num];
				if (num6 == 0f)
				{
					throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
				}
				float num7 = 1f / num6;
				array7[num, num] = 1f;
				for (int m = 0; m < 3; m++)
				{
					array7[num, m] *= num7;
				}
				for (int n = 0; n < 3; n++)
				{
					if (num != n)
					{
						float num8 = array7[n, num];
						array7[n, num] = 0f;
						for (int num9 = 0; num9 < 3; num9++)
						{
							array7[n, num9] -= array7[num, num9] * num8;
						}
					}
				}
			}
			for (int num10 = 2; num10 >= 0; num10--)
			{
				int num11 = array4[num10];
				int num12 = array2[num10];
				for (int num13 = 0; num13 < 3; num13++)
				{
					float num14 = array7[num13, num11];
					array7[num13, num11] = array7[num13, num12];
					array7[num13, num12] = num14;
				}
			}
			result.Row0.X = array7[0, 0];
			result.Row0.Y = array7[0, 1];
			result.Row0.Z = array7[0, 2];
			result.Row1.X = array7[1, 0];
			result.Row1.Y = array7[1, 1];
			result.Row1.Z = array7[1, 2];
			result.Row2.X = array7[2, 0];
			result.Row2.Y = array7[2, 1];
			result.Row2.Z = array7[2, 2];
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000991C File Offset: 0x00007B1C
		public static Matrix3 Invert(Matrix3 mat)
		{
			Matrix3 result;
			Matrix3.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00009934 File Offset: 0x00007B34
		public static Matrix3 Transpose(Matrix3 mat)
		{
			return new Matrix3(mat.Column0, mat.Column1, mat.Column2);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00009950 File Offset: 0x00007B50
		public static void Transpose(ref Matrix3 mat, out Matrix3 result)
		{
			result.Row0.X = mat.Row0.X;
			result.Row0.Y = mat.Row1.X;
			result.Row0.Z = mat.Row2.X;
			result.Row1.X = mat.Row0.Y;
			result.Row1.Y = mat.Row1.Y;
			result.Row1.Z = mat.Row2.Y;
			result.Row2.X = mat.Row0.Z;
			result.Row2.Y = mat.Row1.Z;
			result.Row2.Z = mat.Row2.Z;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00009A24 File Offset: 0x00007C24
		public static Matrix3 operator *(Matrix3 left, Matrix3 right)
		{
			return Matrix3.Mult(left, right);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00009A30 File Offset: 0x00007C30
		public static bool operator ==(Matrix3 left, Matrix3 right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00009A3C File Offset: 0x00007C3C
		public static bool operator !=(Matrix3 left, Matrix3 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00009A4C File Offset: 0x00007C4C
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}", this.Row0, this.Row1, this.Row2);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00009A7C File Offset: 0x00007C7C
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode();
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00009AB4 File Offset: 0x00007CB4
		public override bool Equals(object obj)
		{
			return obj is Matrix3 && this.Equals((Matrix3)obj);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00009ACC File Offset: 0x00007CCC
		public bool Equals(Matrix3 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2;
		}

		// Token: 0x04000082 RID: 130
		public Vector3 Row0;

		// Token: 0x04000083 RID: 131
		public Vector3 Row1;

		// Token: 0x04000084 RID: 132
		public Vector3 Row2;

		// Token: 0x04000085 RID: 133
		public static readonly Matrix3 Identity = new Matrix3(Vector3.UnitX, Vector3.UnitY, Vector3.UnitZ);

		// Token: 0x04000086 RID: 134
		public static readonly Matrix3 Zero = new Matrix3(Vector3.Zero, Vector3.Zero, Vector3.Zero);
	}
}
