using System;

namespace OpenTK
{
	// Token: 0x02000534 RID: 1332
	[Serializable]
	public struct Matrix4 : IEquatable<Matrix4>
	{
		// Token: 0x060040D5 RID: 16597 RVA: 0x000ADA40 File Offset: 0x000ABC40
		public Matrix4(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
			this.Row3 = row3;
		}

		// Token: 0x060040D6 RID: 16598 RVA: 0x000ADA60 File Offset: 0x000ABC60
		public Matrix4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
		{
			this.Row0 = new Vector4(m00, m01, m02, m03);
			this.Row1 = new Vector4(m10, m11, m12, m13);
			this.Row2 = new Vector4(m20, m21, m22, m23);
			this.Row3 = new Vector4(m30, m31, m32, m33);
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060040D7 RID: 16599 RVA: 0x000ADAB8 File Offset: 0x000ABCB8
		public float Determinant
		{
			get
			{
				float x = this.Row0.X;
				float y = this.Row0.Y;
				float z = this.Row0.Z;
				float w = this.Row0.W;
				float x2 = this.Row1.X;
				float y2 = this.Row1.Y;
				float z2 = this.Row1.Z;
				float w2 = this.Row1.W;
				float x3 = this.Row2.X;
				float y3 = this.Row2.Y;
				float z3 = this.Row2.Z;
				float w3 = this.Row2.W;
				float x4 = this.Row3.X;
				float y4 = this.Row3.Y;
				float z4 = this.Row3.Z;
				float w4 = this.Row3.W;
				return x * y2 * z3 * w4 - x * y2 * w3 * z4 + x * z2 * w3 * y4 - x * z2 * y3 * w4 + x * w2 * y3 * z4 - x * w2 * z3 * y4 - y * z2 * w3 * x4 + y * z2 * x3 * w4 - y * w2 * x3 * z4 + y * w2 * z3 * x4 - y * x2 * z3 * w4 + y * x2 * w3 * z4 + z * w2 * x3 * y4 - z * w2 * y3 * x4 + z * x2 * y3 * w4 - z * x2 * w3 * y4 + z * y2 * w3 * x4 - z * y2 * x3 * w4 - w * x2 * y3 * z4 + w * x2 * z3 * y4 - w * y2 * z3 * x4 + w * y2 * x3 * z4 - w * z2 * x3 * y4 + w * z2 * y3 * x4;
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060040D8 RID: 16600 RVA: 0x000ADC98 File Offset: 0x000ABE98
		// (set) Token: 0x060040D9 RID: 16601 RVA: 0x000ADCCC File Offset: 0x000ABECC
		public Vector4 Column0
		{
			get
			{
				return new Vector4(this.Row0.X, this.Row1.X, this.Row2.X, this.Row3.X);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.X = value.Y;
				this.Row2.X = value.Z;
				this.Row3.X = value.W;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060040DA RID: 16602 RVA: 0x000ADD24 File Offset: 0x000ABF24
		// (set) Token: 0x060040DB RID: 16603 RVA: 0x000ADD58 File Offset: 0x000ABF58
		public Vector4 Column1
		{
			get
			{
				return new Vector4(this.Row0.Y, this.Row1.Y, this.Row2.Y, this.Row3.Y);
			}
			set
			{
				this.Row0.Y = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Y = value.Z;
				this.Row3.Y = value.W;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060040DC RID: 16604 RVA: 0x000ADDB0 File Offset: 0x000ABFB0
		// (set) Token: 0x060040DD RID: 16605 RVA: 0x000ADDE4 File Offset: 0x000ABFE4
		public Vector4 Column2
		{
			get
			{
				return new Vector4(this.Row0.Z, this.Row1.Z, this.Row2.Z, this.Row3.Z);
			}
			set
			{
				this.Row0.Z = value.X;
				this.Row1.Z = value.Y;
				this.Row2.Z = value.Z;
				this.Row3.Z = value.W;
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x060040DE RID: 16606 RVA: 0x000ADE3C File Offset: 0x000AC03C
		// (set) Token: 0x060040DF RID: 16607 RVA: 0x000ADE70 File Offset: 0x000AC070
		public Vector4 Column3
		{
			get
			{
				return new Vector4(this.Row0.W, this.Row1.W, this.Row2.W, this.Row3.W);
			}
			set
			{
				this.Row0.W = value.X;
				this.Row1.W = value.Y;
				this.Row2.W = value.Z;
				this.Row3.W = value.W;
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060040E0 RID: 16608 RVA: 0x000ADEC8 File Offset: 0x000AC0C8
		// (set) Token: 0x060040E1 RID: 16609 RVA: 0x000ADED8 File Offset: 0x000AC0D8
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

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x060040E2 RID: 16610 RVA: 0x000ADEE8 File Offset: 0x000AC0E8
		// (set) Token: 0x060040E3 RID: 16611 RVA: 0x000ADEF8 File Offset: 0x000AC0F8
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

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x060040E4 RID: 16612 RVA: 0x000ADF08 File Offset: 0x000AC108
		// (set) Token: 0x060040E5 RID: 16613 RVA: 0x000ADF18 File Offset: 0x000AC118
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

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060040E6 RID: 16614 RVA: 0x000ADF28 File Offset: 0x000AC128
		// (set) Token: 0x060040E7 RID: 16615 RVA: 0x000ADF38 File Offset: 0x000AC138
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

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x060040E8 RID: 16616 RVA: 0x000ADF48 File Offset: 0x000AC148
		// (set) Token: 0x060040E9 RID: 16617 RVA: 0x000ADF58 File Offset: 0x000AC158
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

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x060040EA RID: 16618 RVA: 0x000ADF68 File Offset: 0x000AC168
		// (set) Token: 0x060040EB RID: 16619 RVA: 0x000ADF78 File Offset: 0x000AC178
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

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060040EC RID: 16620 RVA: 0x000ADF88 File Offset: 0x000AC188
		// (set) Token: 0x060040ED RID: 16621 RVA: 0x000ADF98 File Offset: 0x000AC198
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

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x060040EE RID: 16622 RVA: 0x000ADFA8 File Offset: 0x000AC1A8
		// (set) Token: 0x060040EF RID: 16623 RVA: 0x000ADFB8 File Offset: 0x000AC1B8
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

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060040F0 RID: 16624 RVA: 0x000ADFC8 File Offset: 0x000AC1C8
		// (set) Token: 0x060040F1 RID: 16625 RVA: 0x000ADFD8 File Offset: 0x000AC1D8
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

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x060040F2 RID: 16626 RVA: 0x000ADFE8 File Offset: 0x000AC1E8
		// (set) Token: 0x060040F3 RID: 16627 RVA: 0x000ADFF8 File Offset: 0x000AC1F8
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

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x060040F4 RID: 16628 RVA: 0x000AE008 File Offset: 0x000AC208
		// (set) Token: 0x060040F5 RID: 16629 RVA: 0x000AE018 File Offset: 0x000AC218
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

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x060040F6 RID: 16630 RVA: 0x000AE028 File Offset: 0x000AC228
		// (set) Token: 0x060040F7 RID: 16631 RVA: 0x000AE038 File Offset: 0x000AC238
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

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x060040F8 RID: 16632 RVA: 0x000AE048 File Offset: 0x000AC248
		// (set) Token: 0x060040F9 RID: 16633 RVA: 0x000AE058 File Offset: 0x000AC258
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

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x060040FA RID: 16634 RVA: 0x000AE068 File Offset: 0x000AC268
		// (set) Token: 0x060040FB RID: 16635 RVA: 0x000AE078 File Offset: 0x000AC278
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

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x060040FC RID: 16636 RVA: 0x000AE088 File Offset: 0x000AC288
		// (set) Token: 0x060040FD RID: 16637 RVA: 0x000AE098 File Offset: 0x000AC298
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

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x060040FE RID: 16638 RVA: 0x000AE0A8 File Offset: 0x000AC2A8
		// (set) Token: 0x060040FF RID: 16639 RVA: 0x000AE0B8 File Offset: 0x000AC2B8
		public float M44
		{
			get
			{
				return this.Row3.W;
			}
			set
			{
				this.Row3.W = value;
			}
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06004100 RID: 16640 RVA: 0x000AE0C8 File Offset: 0x000AC2C8
		// (set) Token: 0x06004101 RID: 16641 RVA: 0x000AE0FC File Offset: 0x000AC2FC
		public Vector4 Diagonal
		{
			get
			{
				return new Vector4(this.Row0.X, this.Row1.Y, this.Row2.Z, this.Row3.W);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Z = value.Z;
				this.Row3.W = value.W;
			}
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06004102 RID: 16642 RVA: 0x000AE154 File Offset: 0x000AC354
		public float Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y + this.Row2.Z + this.Row3.W;
			}
		}

		// Token: 0x17000369 RID: 873
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

		// Token: 0x06004105 RID: 16645 RVA: 0x000AE2A4 File Offset: 0x000AC4A4
		public void Invert()
		{
			this = Matrix4.Invert(this);
		}

		// Token: 0x06004106 RID: 16646 RVA: 0x000AE2B8 File Offset: 0x000AC4B8
		public void Transpose()
		{
			this = Matrix4.Transpose(this);
		}

		// Token: 0x06004107 RID: 16647 RVA: 0x000AE2CC File Offset: 0x000AC4CC
		public Matrix4 Normalized()
		{
			Matrix4 result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06004108 RID: 16648 RVA: 0x000AE2E8 File Offset: 0x000AC4E8
		public void Normalize()
		{
			float determinant = this.Determinant;
			this.Row0 /= determinant;
			this.Row1 /= determinant;
			this.Row2 /= determinant;
			this.Row3 /= determinant;
		}

		// Token: 0x06004109 RID: 16649 RVA: 0x000AE344 File Offset: 0x000AC544
		public Matrix4 Inverted()
		{
			Matrix4 result = this;
			if (result.Determinant != 0f)
			{
				result.Invert();
			}
			return result;
		}

		// Token: 0x0600410A RID: 16650 RVA: 0x000AE370 File Offset: 0x000AC570
		public Matrix4 ClearTranslation()
		{
			Matrix4 result = this;
			result.Row3.Xyz = Vector3.Zero;
			return result;
		}

		// Token: 0x0600410B RID: 16651 RVA: 0x000AE398 File Offset: 0x000AC598
		public Matrix4 ClearScale()
		{
			Matrix4 result = this;
			result.Row0.Xyz = result.Row0.Xyz.Normalized();
			result.Row1.Xyz = result.Row1.Xyz.Normalized();
			result.Row2.Xyz = result.Row2.Xyz.Normalized();
			return result;
		}

		// Token: 0x0600410C RID: 16652 RVA: 0x000AE410 File Offset: 0x000AC610
		public Matrix4 ClearRotation()
		{
			Matrix4 result = this;
			result.Row0.Xyz = new Vector3(result.Row0.Xyz.Length, 0f, 0f);
			result.Row1.Xyz = new Vector3(0f, result.Row1.Xyz.Length, 0f);
			result.Row2.Xyz = new Vector3(0f, 0f, result.Row2.Xyz.Length);
			return result;
		}

		// Token: 0x0600410D RID: 16653 RVA: 0x000AE4B4 File Offset: 0x000AC6B4
		public Matrix4 ClearProjection()
		{
			Matrix4 result = this;
			result.Column3 = Vector4.Zero;
			return result;
		}

		// Token: 0x0600410E RID: 16654 RVA: 0x000AE4D8 File Offset: 0x000AC6D8
		public Vector3 ExtractTranslation()
		{
			return this.Row3.Xyz;
		}

		// Token: 0x0600410F RID: 16655 RVA: 0x000AE4E8 File Offset: 0x000AC6E8
		public Vector3 ExtractScale()
		{
			return new Vector3(this.Row0.Xyz.Length, this.Row1.Xyz.Length, this.Row2.Xyz.Length);
		}

		// Token: 0x06004110 RID: 16656 RVA: 0x000AE534 File Offset: 0x000AC734
		public Quaternion ExtractRotation(bool row_normalise = true)
		{
			Vector3 vector = this.Row0.Xyz;
			Vector3 vector2 = this.Row1.Xyz;
			Vector3 vector3 = this.Row2.Xyz;
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

		// Token: 0x06004111 RID: 16657 RVA: 0x000AE8B4 File Offset: 0x000ACAB4
		public Vector4 ExtractProjection()
		{
			return this.Column3;
		}

		// Token: 0x06004112 RID: 16658 RVA: 0x000AE8BC File Offset: 0x000ACABC
		public static void CreateFromAxisAngle(Vector3 axis, float angle, out Matrix4 result)
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
			result.Row0.W = 0f;
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num;
			result.Row1.Z = num8 - num10;
			result.Row1.W = 0f;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num;
			result.Row2.W = 0f;
			result.Row3 = Vector4.UnitW;
		}

		// Token: 0x06004113 RID: 16659 RVA: 0x000AEA10 File Offset: 0x000ACC10
		public static Matrix4 CreateFromAxisAngle(Vector3 axis, float angle)
		{
			Matrix4 result;
			Matrix4.CreateFromAxisAngle(axis, angle, out result);
			return result;
		}

		// Token: 0x06004114 RID: 16660 RVA: 0x000AEA28 File Offset: 0x000ACC28
		public static void CreateFromQuaternion(ref Quaternion q, out Matrix4 result)
		{
			Vector3 axis;
			float angle;
			q.ToAxisAngle(out axis, out angle);
			Matrix4.CreateFromAxisAngle(axis, angle, out result);
		}

		// Token: 0x06004115 RID: 16661 RVA: 0x000AEA48 File Offset: 0x000ACC48
		public static Matrix4 CreateFromQuaternion(Quaternion q)
		{
			Matrix4 result;
			Matrix4.CreateFromQuaternion(ref q, out result);
			return result;
		}

		// Token: 0x06004116 RID: 16662 RVA: 0x000AEA60 File Offset: 0x000ACC60
		public static void CreateRotationX(float angle, out Matrix4 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix4.Identity;
			result.Row1.Y = num;
			result.Row1.Z = num2;
			result.Row2.Y = -num2;
			result.Row2.Z = num;
		}

		// Token: 0x06004117 RID: 16663 RVA: 0x000AEABC File Offset: 0x000ACCBC
		public static Matrix4 CreateRotationX(float angle)
		{
			Matrix4 result;
			Matrix4.CreateRotationX(angle, out result);
			return result;
		}

		// Token: 0x06004118 RID: 16664 RVA: 0x000AEAD4 File Offset: 0x000ACCD4
		public static void CreateRotationY(float angle, out Matrix4 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix4.Identity;
			result.Row0.X = num;
			result.Row0.Z = -num2;
			result.Row2.X = num2;
			result.Row2.Z = num;
		}

		// Token: 0x06004119 RID: 16665 RVA: 0x000AEB30 File Offset: 0x000ACD30
		public static Matrix4 CreateRotationY(float angle)
		{
			Matrix4 result;
			Matrix4.CreateRotationY(angle, out result);
			return result;
		}

		// Token: 0x0600411A RID: 16666 RVA: 0x000AEB48 File Offset: 0x000ACD48
		public static void CreateRotationZ(float angle, out Matrix4 result)
		{
			float num = (float)Math.Cos((double)angle);
			float num2 = (float)Math.Sin((double)angle);
			result = Matrix4.Identity;
			result.Row0.X = num;
			result.Row0.Y = num2;
			result.Row1.X = -num2;
			result.Row1.Y = num;
		}

		// Token: 0x0600411B RID: 16667 RVA: 0x000AEBA4 File Offset: 0x000ACDA4
		public static Matrix4 CreateRotationZ(float angle)
		{
			Matrix4 result;
			Matrix4.CreateRotationZ(angle, out result);
			return result;
		}

		// Token: 0x0600411C RID: 16668 RVA: 0x000AEBBC File Offset: 0x000ACDBC
		public static void CreateTranslation(float x, float y, float z, out Matrix4 result)
		{
			result = Matrix4.Identity;
			result.Row3.X = x;
			result.Row3.Y = y;
			result.Row3.Z = z;
		}

		// Token: 0x0600411D RID: 16669 RVA: 0x000AEBF0 File Offset: 0x000ACDF0
		public static void CreateTranslation(ref Vector3 vector, out Matrix4 result)
		{
			result = Matrix4.Identity;
			result.Row3.X = vector.X;
			result.Row3.Y = vector.Y;
			result.Row3.Z = vector.Z;
		}

		// Token: 0x0600411E RID: 16670 RVA: 0x000AEC30 File Offset: 0x000ACE30
		public static Matrix4 CreateTranslation(float x, float y, float z)
		{
			Matrix4 result;
			Matrix4.CreateTranslation(x, y, z, out result);
			return result;
		}

		// Token: 0x0600411F RID: 16671 RVA: 0x000AEC48 File Offset: 0x000ACE48
		public static Matrix4 CreateTranslation(Vector3 vector)
		{
			Matrix4 result;
			Matrix4.CreateTranslation(vector.X, vector.Y, vector.Z, out result);
			return result;
		}

		// Token: 0x06004120 RID: 16672 RVA: 0x000AEC74 File Offset: 0x000ACE74
		public static Matrix4 CreateScale(float scale)
		{
			Matrix4 result;
			Matrix4.CreateScale(scale, out result);
			return result;
		}

		// Token: 0x06004121 RID: 16673 RVA: 0x000AEC8C File Offset: 0x000ACE8C
		public static Matrix4 CreateScale(Vector3 scale)
		{
			Matrix4 result;
			Matrix4.CreateScale(ref scale, out result);
			return result;
		}

		// Token: 0x06004122 RID: 16674 RVA: 0x000AECA4 File Offset: 0x000ACEA4
		public static Matrix4 CreateScale(float x, float y, float z)
		{
			Matrix4 result;
			Matrix4.CreateScale(x, y, z, out result);
			return result;
		}

		// Token: 0x06004123 RID: 16675 RVA: 0x000AECBC File Offset: 0x000ACEBC
		public static void CreateScale(float scale, out Matrix4 result)
		{
			result = Matrix4.Identity;
			result.Row0.X = scale;
			result.Row1.Y = scale;
			result.Row2.Z = scale;
		}

		// Token: 0x06004124 RID: 16676 RVA: 0x000AECF0 File Offset: 0x000ACEF0
		public static void CreateScale(ref Vector3 scale, out Matrix4 result)
		{
			result = Matrix4.Identity;
			result.Row0.X = scale.X;
			result.Row1.Y = scale.Y;
			result.Row2.Z = scale.Z;
		}

		// Token: 0x06004125 RID: 16677 RVA: 0x000AED30 File Offset: 0x000ACF30
		public static void CreateScale(float x, float y, float z, out Matrix4 result)
		{
			result = Matrix4.Identity;
			result.Row0.X = x;
			result.Row1.Y = y;
			result.Row2.Z = z;
		}

		// Token: 0x06004126 RID: 16678 RVA: 0x000AED64 File Offset: 0x000ACF64
		public static void CreateOrthographic(float width, float height, float zNear, float zFar, out Matrix4 result)
		{
			Matrix4.CreateOrthographicOffCenter(-width / 2f, width / 2f, -height / 2f, height / 2f, zNear, zFar, out result);
		}

		// Token: 0x06004127 RID: 16679 RVA: 0x000AED90 File Offset: 0x000ACF90
		public static Matrix4 CreateOrthographic(float width, float height, float zNear, float zFar)
		{
			Matrix4 result;
			Matrix4.CreateOrthographicOffCenter(-width / 2f, width / 2f, -height / 2f, height / 2f, zNear, zFar, out result);
			return result;
		}

		// Token: 0x06004128 RID: 16680 RVA: 0x000AEDC8 File Offset: 0x000ACFC8
		public static void CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4 result)
		{
			result = Matrix4.Identity;
			float num = 1f / (right - left);
			float num2 = 1f / (top - bottom);
			float num3 = 1f / (zFar - zNear);
			result.Row0.X = 2f * num;
			result.Row1.Y = 2f * num2;
			result.Row2.Z = -2f * num3;
			result.Row3.X = -(right + left) * num;
			result.Row3.Y = -(top + bottom) * num2;
			result.Row3.Z = -(zFar + zNear) * num3;
		}

		// Token: 0x06004129 RID: 16681 RVA: 0x000AEE74 File Offset: 0x000AD074
		public static Matrix4 CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
		{
			Matrix4 result;
			Matrix4.CreateOrthographicOffCenter(left, right, bottom, top, zNear, zFar, out result);
			return result;
		}

		// Token: 0x0600412A RID: 16682 RVA: 0x000AEE94 File Offset: 0x000AD094
		public static void CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar, out Matrix4 result)
		{
			if (fovy <= 0f || (double)fovy > 3.141592653589793)
			{
				throw new ArgumentOutOfRangeException("fovy");
			}
			if (aspect <= 0f)
			{
				throw new ArgumentOutOfRangeException("aspect");
			}
			if (zNear <= 0f)
			{
				throw new ArgumentOutOfRangeException("zNear");
			}
			if (zFar <= 0f)
			{
				throw new ArgumentOutOfRangeException("zFar");
			}
			float num = zNear * (float)Math.Tan((double)(0.5f * fovy));
			float num2 = -num;
			float left = num2 * aspect;
			float right = num * aspect;
			Matrix4.CreatePerspectiveOffCenter(left, right, num2, num, zNear, zFar, out result);
		}

		// Token: 0x0600412B RID: 16683 RVA: 0x000AEF24 File Offset: 0x000AD124
		public static Matrix4 CreatePerspectiveFieldOfView(float fovy, float aspect, float zNear, float zFar)
		{
			Matrix4 result;
			Matrix4.CreatePerspectiveFieldOfView(fovy, aspect, zNear, zFar, out result);
			return result;
		}

		// Token: 0x0600412C RID: 16684 RVA: 0x000AEF40 File Offset: 0x000AD140
		public static void CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar, out Matrix4 result)
		{
			if (zNear <= 0f)
			{
				throw new ArgumentOutOfRangeException("zNear");
			}
			if (zFar <= 0f)
			{
				throw new ArgumentOutOfRangeException("zFar");
			}
			if (zNear >= zFar)
			{
				throw new ArgumentOutOfRangeException("zNear");
			}
			float x = 2f * zNear / (right - left);
			float y = 2f * zNear / (top - bottom);
			float x2 = (right + left) / (right - left);
			float y2 = (top + bottom) / (top - bottom);
			float z = -(zFar + zNear) / (zFar - zNear);
			float z2 = -(2f * zFar * zNear) / (zFar - zNear);
			result.Row0.X = x;
			result.Row0.Y = 0f;
			result.Row0.Z = 0f;
			result.Row0.W = 0f;
			result.Row1.X = 0f;
			result.Row1.Y = y;
			result.Row1.Z = 0f;
			result.Row1.W = 0f;
			result.Row2.X = x2;
			result.Row2.Y = y2;
			result.Row2.Z = z;
			result.Row2.W = -1f;
			result.Row3.X = 0f;
			result.Row3.Y = 0f;
			result.Row3.Z = z2;
			result.Row3.W = 0f;
		}

		// Token: 0x0600412D RID: 16685 RVA: 0x000AF0CC File Offset: 0x000AD2CC
		public static Matrix4 CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float zNear, float zFar)
		{
			Matrix4 result;
			Matrix4.CreatePerspectiveOffCenter(left, right, bottom, top, zNear, zFar, out result);
			return result;
		}

		// Token: 0x0600412E RID: 16686 RVA: 0x000AF0EC File Offset: 0x000AD2EC
		[Obsolete("Use CreateTranslation instead.")]
		public static Matrix4 Translation(Vector3 trans)
		{
			return Matrix4.CreateTranslation(trans);
		}

		// Token: 0x0600412F RID: 16687 RVA: 0x000AF0F4 File Offset: 0x000AD2F4
		[Obsolete("Use CreateTranslation instead.")]
		public static Matrix4 Translation(float x, float y, float z)
		{
			return Matrix4.CreateTranslation(x, y, z);
		}

		// Token: 0x06004130 RID: 16688 RVA: 0x000AF100 File Offset: 0x000AD300
		[Obsolete("Use CreateRotationX instead.")]
		public static Matrix4 RotateX(float angle)
		{
			return Matrix4.CreateRotationX(angle);
		}

		// Token: 0x06004131 RID: 16689 RVA: 0x000AF108 File Offset: 0x000AD308
		[Obsolete("Use CreateRotationY instead.")]
		public static Matrix4 RotateY(float angle)
		{
			return Matrix4.CreateRotationY(angle);
		}

		// Token: 0x06004132 RID: 16690 RVA: 0x000AF110 File Offset: 0x000AD310
		[Obsolete("Use CreateRotationZ instead.")]
		public static Matrix4 RotateZ(float angle)
		{
			return Matrix4.CreateRotationZ(angle);
		}

		// Token: 0x06004133 RID: 16691 RVA: 0x000AF118 File Offset: 0x000AD318
		[Obsolete("Use CreateFromAxisAngle instead.")]
		public static Matrix4 Rotate(Vector3 axis, float angle)
		{
			return Matrix4.CreateFromAxisAngle(axis, angle);
		}

		// Token: 0x06004134 RID: 16692 RVA: 0x000AF124 File Offset: 0x000AD324
		[Obsolete("Use CreateRotation instead.")]
		public static Matrix4 Rotate(Quaternion q)
		{
			return Matrix4.CreateFromQuaternion(q);
		}

		// Token: 0x06004135 RID: 16693 RVA: 0x000AF12C File Offset: 0x000AD32C
		[Obsolete("Use CreateScale instead.")]
		public static Matrix4 Scale(float scale)
		{
			return Matrix4.Scale(scale, scale, scale);
		}

		// Token: 0x06004136 RID: 16694 RVA: 0x000AF138 File Offset: 0x000AD338
		[Obsolete("Use CreateScale instead.")]
		public static Matrix4 Scale(Vector3 scale)
		{
			return Matrix4.Scale(scale.X, scale.Y, scale.Z);
		}

		// Token: 0x06004137 RID: 16695 RVA: 0x000AF154 File Offset: 0x000AD354
		[Obsolete("Use CreateScale instead.")]
		public static Matrix4 Scale(float x, float y, float z)
		{
			Matrix4 result;
			result.Row0 = Vector4.UnitX * x;
			result.Row1 = Vector4.UnitY * y;
			result.Row2 = Vector4.UnitZ * z;
			result.Row3 = Vector4.UnitW;
			return result;
		}

		// Token: 0x06004138 RID: 16696 RVA: 0x000AF1A4 File Offset: 0x000AD3A4
		[Obsolete("Use CreatePerspectiveOffCenter instead.")]
		public static Matrix4 Frustum(float left, float right, float bottom, float top, float near, float far)
		{
			float num = 1f / (right - left);
			float num2 = 1f / (top - bottom);
			float num3 = 1f / (far - near);
			return new Matrix4(new Vector4(2f * near * num, 0f, 0f, 0f), new Vector4(0f, 2f * near * num2, 0f, 0f), new Vector4((right + left) * num, (top + bottom) * num2, -(far + near) * num3, -1f), new Vector4(0f, 0f, -2f * far * near * num3, 0f));
		}

		// Token: 0x06004139 RID: 16697 RVA: 0x000AF250 File Offset: 0x000AD450
		[Obsolete("Use CreatePerspectiveFieldOfView instead.")]
		public static Matrix4 Perspective(float fovy, float aspect, float near, float far)
		{
			float num = near * (float)Math.Tan((double)(0.5f * fovy));
			float num2 = -num;
			float left = num2 * aspect;
			float right = num * aspect;
			return Matrix4.Frustum(left, right, num2, num, near, far);
		}

		// Token: 0x0600413A RID: 16698 RVA: 0x000AF284 File Offset: 0x000AD484
		public static Matrix4 LookAt(Vector3 eye, Vector3 target, Vector3 up)
		{
			Vector3 vector = Vector3.Normalize(eye - target);
			Vector3 right = Vector3.Normalize(Vector3.Cross(up, vector));
			Vector3 vector2 = Vector3.Normalize(Vector3.Cross(vector, right));
			Matrix4 result;
			result.Row0.X = right.X;
			result.Row0.Y = vector2.X;
			result.Row0.Z = vector.X;
			result.Row0.W = 0f;
			result.Row1.X = right.Y;
			result.Row1.Y = vector2.Y;
			result.Row1.Z = vector.Y;
			result.Row1.W = 0f;
			result.Row2.X = right.Z;
			result.Row2.Y = vector2.Z;
			result.Row2.Z = vector.Z;
			result.Row2.W = 0f;
			result.Row3.X = -(right.X * eye.X + right.Y * eye.Y + right.Z * eye.Z);
			result.Row3.Y = -(vector2.X * eye.X + vector2.Y * eye.Y + vector2.Z * eye.Z);
			result.Row3.Z = -(vector.X * eye.X + vector.Y * eye.Y + vector.Z * eye.Z);
			result.Row3.W = 1f;
			return result;
		}

		// Token: 0x0600413B RID: 16699 RVA: 0x000AF45C File Offset: 0x000AD65C
		public static Matrix4 LookAt(float eyeX, float eyeY, float eyeZ, float targetX, float targetY, float targetZ, float upX, float upY, float upZ)
		{
			return Matrix4.LookAt(new Vector3(eyeX, eyeY, eyeZ), new Vector3(targetX, targetY, targetZ), new Vector3(upX, upY, upZ));
		}

		// Token: 0x0600413C RID: 16700 RVA: 0x000AF480 File Offset: 0x000AD680
		public static Matrix4 Add(Matrix4 left, Matrix4 right)
		{
			Matrix4 result;
			Matrix4.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600413D RID: 16701 RVA: 0x000AF49C File Offset: 0x000AD69C
		public static void Add(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
		{
			result.Row0 = left.Row0 + right.Row0;
			result.Row1 = left.Row1 + right.Row1;
			result.Row2 = left.Row2 + right.Row2;
			result.Row3 = left.Row3 + right.Row3;
		}

		// Token: 0x0600413E RID: 16702 RVA: 0x000AF508 File Offset: 0x000AD708
		public static Matrix4 Subtract(Matrix4 left, Matrix4 right)
		{
			Matrix4 result;
			Matrix4.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x0600413F RID: 16703 RVA: 0x000AF524 File Offset: 0x000AD724
		public static void Subtract(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
		{
			result.Row0 = left.Row0 - right.Row0;
			result.Row1 = left.Row1 - right.Row1;
			result.Row2 = left.Row2 - right.Row2;
			result.Row3 = left.Row3 - right.Row3;
		}

		// Token: 0x06004140 RID: 16704 RVA: 0x000AF590 File Offset: 0x000AD790
		public static Matrix4 Mult(Matrix4 left, Matrix4 right)
		{
			Matrix4 result;
			Matrix4.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06004141 RID: 16705 RVA: 0x000AF5AC File Offset: 0x000AD7AC
		public static void Mult(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
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
			float x4 = left.Row3.X;
			float y4 = left.Row3.Y;
			float z4 = left.Row3.Z;
			float w4 = left.Row3.W;
			float x5 = right.Row0.X;
			float y5 = right.Row0.Y;
			float z5 = right.Row0.Z;
			float w5 = right.Row0.W;
			float x6 = right.Row1.X;
			float y6 = right.Row1.Y;
			float z6 = right.Row1.Z;
			float w6 = right.Row1.W;
			float x7 = right.Row2.X;
			float y7 = right.Row2.Y;
			float z7 = right.Row2.Z;
			float w7 = right.Row2.W;
			float x8 = right.Row3.X;
			float y8 = right.Row3.Y;
			float z8 = right.Row3.Z;
			float w8 = right.Row3.W;
			result.Row0.X = x * x5 + y * x6 + z * x7 + w * x8;
			result.Row0.Y = x * y5 + y * y6 + z * y7 + w * y8;
			result.Row0.Z = x * z5 + y * z6 + z * z7 + w * z8;
			result.Row0.W = x * w5 + y * w6 + z * w7 + w * w8;
			result.Row1.X = x2 * x5 + y2 * x6 + z2 * x7 + w2 * x8;
			result.Row1.Y = x2 * y5 + y2 * y6 + z2 * y7 + w2 * y8;
			result.Row1.Z = x2 * z5 + y2 * z6 + z2 * z7 + w2 * z8;
			result.Row1.W = x2 * w5 + y2 * w6 + z2 * w7 + w2 * w8;
			result.Row2.X = x3 * x5 + y3 * x6 + z3 * x7 + w3 * x8;
			result.Row2.Y = x3 * y5 + y3 * y6 + z3 * y7 + w3 * y8;
			result.Row2.Z = x3 * z5 + y3 * z6 + z3 * z7 + w3 * z8;
			result.Row2.W = x3 * w5 + y3 * w6 + z3 * w7 + w3 * w8;
			result.Row3.X = x4 * x5 + y4 * x6 + z4 * x7 + w4 * x8;
			result.Row3.Y = x4 * y5 + y4 * y6 + z4 * y7 + w4 * y8;
			result.Row3.Z = x4 * z5 + y4 * z6 + z4 * z7 + w4 * z8;
			result.Row3.W = x4 * w5 + y4 * w6 + z4 * w7 + w4 * w8;
		}

		// Token: 0x06004142 RID: 16706 RVA: 0x000AF968 File Offset: 0x000ADB68
		public static Matrix4 Mult(Matrix4 left, float right)
		{
			Matrix4 result;
			Matrix4.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x06004143 RID: 16707 RVA: 0x000AF980 File Offset: 0x000ADB80
		public static void Mult(ref Matrix4 left, float right, out Matrix4 result)
		{
			result.Row0 = left.Row0 * right;
			result.Row1 = left.Row1 * right;
			result.Row2 = left.Row2 * right;
			result.Row3 = left.Row3 * right;
		}

		// Token: 0x06004144 RID: 16708 RVA: 0x000AF9D8 File Offset: 0x000ADBD8
		public static void Invert(ref Matrix4 mat, out Matrix4 result)
		{
			int[] array = new int[4];
			int[] array2 = array;
			int[] array3 = new int[4];
			int[] array4 = array3;
			int[] array5 = new int[]
			{
				-1,
				-1,
				-1,
				-1
			};
			float[,] array6 = new float[4, 4];
			array6[0, 0] = mat.Row0.X;
			array6[0, 1] = mat.Row0.Y;
			array6[0, 2] = mat.Row0.Z;
			array6[0, 3] = mat.Row0.W;
			array6[1, 0] = mat.Row1.X;
			array6[1, 1] = mat.Row1.Y;
			array6[1, 2] = mat.Row1.Z;
			array6[1, 3] = mat.Row1.W;
			array6[2, 0] = mat.Row2.X;
			array6[2, 1] = mat.Row2.Y;
			array6[2, 2] = mat.Row2.Z;
			array6[2, 3] = mat.Row2.W;
			array6[3, 0] = mat.Row3.X;
			array6[3, 1] = mat.Row3.Y;
			array6[3, 2] = mat.Row3.Z;
			array6[3, 3] = mat.Row3.W;
			float[,] array7 = array6;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 4; i++)
			{
				float num3 = 0f;
				for (int j = 0; j < 4; j++)
				{
					if (array5[j] != 0)
					{
						for (int k = 0; k < 4; k++)
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
					for (int l = 0; l < 4; l++)
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
				for (int m = 0; m < 4; m++)
				{
					array7[num, m] *= num7;
				}
				for (int n = 0; n < 4; n++)
				{
					if (num != n)
					{
						float num8 = array7[n, num];
						array7[n, num] = 0f;
						for (int num9 = 0; num9 < 4; num9++)
						{
							array7[n, num9] -= array7[num, num9] * num8;
						}
					}
				}
			}
			for (int num10 = 3; num10 >= 0; num10--)
			{
				int num11 = array4[num10];
				int num12 = array2[num10];
				for (int num13 = 0; num13 < 4; num13++)
				{
					float num14 = array7[num13, num11];
					array7[num13, num11] = array7[num13, num12];
					array7[num13, num12] = num14;
				}
			}
			result.Row0.X = array7[0, 0];
			result.Row0.Y = array7[0, 1];
			result.Row0.Z = array7[0, 2];
			result.Row0.W = array7[0, 3];
			result.Row1.X = array7[1, 0];
			result.Row1.Y = array7[1, 1];
			result.Row1.Z = array7[1, 2];
			result.Row1.W = array7[1, 3];
			result.Row2.X = array7[2, 0];
			result.Row2.Y = array7[2, 1];
			result.Row2.Z = array7[2, 2];
			result.Row2.W = array7[2, 3];
			result.Row3.X = array7[3, 0];
			result.Row3.Y = array7[3, 1];
			result.Row3.Z = array7[3, 2];
			result.Row3.W = array7[3, 3];
		}

		// Token: 0x06004145 RID: 16709 RVA: 0x000AFE94 File Offset: 0x000AE094
		public static Matrix4 Invert(Matrix4 mat)
		{
			Matrix4 result;
			Matrix4.Invert(ref mat, out result);
			return result;
		}

		// Token: 0x06004146 RID: 16710 RVA: 0x000AFEAC File Offset: 0x000AE0AC
		public static Matrix4 Transpose(Matrix4 mat)
		{
			return new Matrix4(mat.Column0, mat.Column1, mat.Column2, mat.Column3);
		}

		// Token: 0x06004147 RID: 16711 RVA: 0x000AFED0 File Offset: 0x000AE0D0
		public static void Transpose(ref Matrix4 mat, out Matrix4 result)
		{
			result.Row0 = mat.Column0;
			result.Row1 = mat.Column1;
			result.Row2 = mat.Column2;
			result.Row3 = mat.Column3;
		}

		// Token: 0x06004148 RID: 16712 RVA: 0x000AFF04 File Offset: 0x000AE104
		public static Matrix4 operator *(Matrix4 left, Matrix4 right)
		{
			return Matrix4.Mult(left, right);
		}

		// Token: 0x06004149 RID: 16713 RVA: 0x000AFF10 File Offset: 0x000AE110
		public static Matrix4 operator *(Matrix4 left, float right)
		{
			return Matrix4.Mult(left, right);
		}

		// Token: 0x0600414A RID: 16714 RVA: 0x000AFF1C File Offset: 0x000AE11C
		public static Matrix4 operator +(Matrix4 left, Matrix4 right)
		{
			return Matrix4.Add(left, right);
		}

		// Token: 0x0600414B RID: 16715 RVA: 0x000AFF28 File Offset: 0x000AE128
		public static Matrix4 operator -(Matrix4 left, Matrix4 right)
		{
			return Matrix4.Subtract(left, right);
		}

		// Token: 0x0600414C RID: 16716 RVA: 0x000AFF34 File Offset: 0x000AE134
		public static bool operator ==(Matrix4 left, Matrix4 right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600414D RID: 16717 RVA: 0x000AFF40 File Offset: 0x000AE140
		public static bool operator !=(Matrix4 left, Matrix4 right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600414E RID: 16718 RVA: 0x000AFF50 File Offset: 0x000AE150
		public override string ToString()
		{
			return string.Format("{0}\n{1}\n{2}\n{3}", new object[]
			{
				this.Row0,
				this.Row1,
				this.Row2,
				this.Row3
			});
		}

		// Token: 0x0600414F RID: 16719 RVA: 0x000AFFA8 File Offset: 0x000AE1A8
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode() ^ this.Row3.GetHashCode();
		}

		// Token: 0x06004150 RID: 16720 RVA: 0x000AFFFC File Offset: 0x000AE1FC
		public override bool Equals(object obj)
		{
			return obj is Matrix4 && this.Equals((Matrix4)obj);
		}

		// Token: 0x06004151 RID: 16721 RVA: 0x000B0014 File Offset: 0x000AE214
		public bool Equals(Matrix4 other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2 && this.Row3 == other.Row3;
		}

		// Token: 0x04004E24 RID: 20004
		public Vector4 Row0;

		// Token: 0x04004E25 RID: 20005
		public Vector4 Row1;

		// Token: 0x04004E26 RID: 20006
		public Vector4 Row2;

		// Token: 0x04004E27 RID: 20007
		public Vector4 Row3;

		// Token: 0x04004E28 RID: 20008
		public static readonly Matrix4 Identity = new Matrix4(Vector4.UnitX, Vector4.UnitY, Vector4.UnitZ, Vector4.UnitW);

		// Token: 0x04004E29 RID: 20009
		public static readonly Matrix4 Zero = new Matrix4(Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero);
	}
}
