using System;

namespace OpenTK
{
	// Token: 0x0200052F RID: 1327
	[Serializable]
	public struct Matrix4d : IEquatable<Matrix4d>
	{
		// Token: 0x06003FBD RID: 16317 RVA: 0x000A93C4 File Offset: 0x000A75C4
		public Matrix4d(Vector4d row0, Vector4d row1, Vector4d row2, Vector4d row3)
		{
			this.Row0 = row0;
			this.Row1 = row1;
			this.Row2 = row2;
			this.Row3 = row3;
		}

		// Token: 0x06003FBE RID: 16318 RVA: 0x000A93E4 File Offset: 0x000A75E4
		public Matrix4d(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23, double m30, double m31, double m32, double m33)
		{
			this.Row0 = new Vector4d(m00, m01, m02, m03);
			this.Row1 = new Vector4d(m10, m11, m12, m13);
			this.Row2 = new Vector4d(m20, m21, m22, m23);
			this.Row3 = new Vector4d(m30, m31, m32, m33);
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06003FBF RID: 16319 RVA: 0x000A943C File Offset: 0x000A763C
		public double Determinant
		{
			get
			{
				return this.Row0.X * this.Row1.Y * this.Row2.Z * this.Row3.W - this.Row0.X * this.Row1.Y * this.Row2.W * this.Row3.Z + this.Row0.X * this.Row1.Z * this.Row2.W * this.Row3.Y - this.Row0.X * this.Row1.Z * this.Row2.Y * this.Row3.W + this.Row0.X * this.Row1.W * this.Row2.Y * this.Row3.Z - this.Row0.X * this.Row1.W * this.Row2.Z * this.Row3.Y - this.Row0.Y * this.Row1.Z * this.Row2.W * this.Row3.X + this.Row0.Y * this.Row1.Z * this.Row2.X * this.Row3.W - this.Row0.Y * this.Row1.W * this.Row2.X * this.Row3.Z + this.Row0.Y * this.Row1.W * this.Row2.Z * this.Row3.X - this.Row0.Y * this.Row1.X * this.Row2.Z * this.Row3.W + this.Row0.Y * this.Row1.X * this.Row2.W * this.Row3.Z + this.Row0.Z * this.Row1.W * this.Row2.X * this.Row3.Y - this.Row0.Z * this.Row1.W * this.Row2.Y * this.Row3.X + this.Row0.Z * this.Row1.X * this.Row2.Y * this.Row3.W - this.Row0.Z * this.Row1.X * this.Row2.W * this.Row3.Y + this.Row0.Z * this.Row1.Y * this.Row2.W * this.Row3.X - this.Row0.Z * this.Row1.Y * this.Row2.X * this.Row3.W - this.Row0.W * this.Row1.X * this.Row2.Y * this.Row3.Z + this.Row0.W * this.Row1.X * this.Row2.Z * this.Row3.Y - this.Row0.W * this.Row1.Y * this.Row2.Z * this.Row3.X + this.Row0.W * this.Row1.Y * this.Row2.X * this.Row3.Z - this.Row0.W * this.Row1.Z * this.Row2.X * this.Row3.Y + this.Row0.W * this.Row1.Z * this.Row2.Y * this.Row3.X;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06003FC0 RID: 16320 RVA: 0x000A98C8 File Offset: 0x000A7AC8
		// (set) Token: 0x06003FC1 RID: 16321 RVA: 0x000A98FC File Offset: 0x000A7AFC
		public Vector4d Column0
		{
			get
			{
				return new Vector4d(this.Row0.X, this.Row1.X, this.Row2.X, this.Row3.X);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.X = value.Y;
				this.Row2.X = value.Z;
				this.Row3.X = value.W;
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06003FC2 RID: 16322 RVA: 0x000A9954 File Offset: 0x000A7B54
		// (set) Token: 0x06003FC3 RID: 16323 RVA: 0x000A9988 File Offset: 0x000A7B88
		public Vector4d Column1
		{
			get
			{
				return new Vector4d(this.Row0.Y, this.Row1.Y, this.Row2.Y, this.Row3.Y);
			}
			set
			{
				this.Row0.Y = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Y = value.Z;
				this.Row3.Y = value.W;
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06003FC4 RID: 16324 RVA: 0x000A99E0 File Offset: 0x000A7BE0
		// (set) Token: 0x06003FC5 RID: 16325 RVA: 0x000A9A14 File Offset: 0x000A7C14
		public Vector4d Column2
		{
			get
			{
				return new Vector4d(this.Row0.Z, this.Row1.Z, this.Row2.Z, this.Row3.Z);
			}
			set
			{
				this.Row0.Z = value.X;
				this.Row1.Z = value.Y;
				this.Row2.Z = value.Z;
				this.Row3.Z = value.W;
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06003FC6 RID: 16326 RVA: 0x000A9A6C File Offset: 0x000A7C6C
		// (set) Token: 0x06003FC7 RID: 16327 RVA: 0x000A9AA0 File Offset: 0x000A7CA0
		public Vector4d Column3
		{
			get
			{
				return new Vector4d(this.Row0.W, this.Row1.W, this.Row2.W, this.Row3.W);
			}
			set
			{
				this.Row0.W = value.X;
				this.Row1.W = value.Y;
				this.Row2.W = value.Z;
				this.Row3.W = value.W;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06003FC8 RID: 16328 RVA: 0x000A9AF8 File Offset: 0x000A7CF8
		// (set) Token: 0x06003FC9 RID: 16329 RVA: 0x000A9B08 File Offset: 0x000A7D08
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

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06003FCA RID: 16330 RVA: 0x000A9B18 File Offset: 0x000A7D18
		// (set) Token: 0x06003FCB RID: 16331 RVA: 0x000A9B28 File Offset: 0x000A7D28
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

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06003FCC RID: 16332 RVA: 0x000A9B38 File Offset: 0x000A7D38
		// (set) Token: 0x06003FCD RID: 16333 RVA: 0x000A9B48 File Offset: 0x000A7D48
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

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06003FCE RID: 16334 RVA: 0x000A9B58 File Offset: 0x000A7D58
		// (set) Token: 0x06003FCF RID: 16335 RVA: 0x000A9B68 File Offset: 0x000A7D68
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

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06003FD0 RID: 16336 RVA: 0x000A9B78 File Offset: 0x000A7D78
		// (set) Token: 0x06003FD1 RID: 16337 RVA: 0x000A9B88 File Offset: 0x000A7D88
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

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06003FD2 RID: 16338 RVA: 0x000A9B98 File Offset: 0x000A7D98
		// (set) Token: 0x06003FD3 RID: 16339 RVA: 0x000A9BA8 File Offset: 0x000A7DA8
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

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06003FD4 RID: 16340 RVA: 0x000A9BB8 File Offset: 0x000A7DB8
		// (set) Token: 0x06003FD5 RID: 16341 RVA: 0x000A9BC8 File Offset: 0x000A7DC8
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

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06003FD6 RID: 16342 RVA: 0x000A9BD8 File Offset: 0x000A7DD8
		// (set) Token: 0x06003FD7 RID: 16343 RVA: 0x000A9BE8 File Offset: 0x000A7DE8
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

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06003FD8 RID: 16344 RVA: 0x000A9BF8 File Offset: 0x000A7DF8
		// (set) Token: 0x06003FD9 RID: 16345 RVA: 0x000A9C08 File Offset: 0x000A7E08
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

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06003FDA RID: 16346 RVA: 0x000A9C18 File Offset: 0x000A7E18
		// (set) Token: 0x06003FDB RID: 16347 RVA: 0x000A9C28 File Offset: 0x000A7E28
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

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06003FDC RID: 16348 RVA: 0x000A9C38 File Offset: 0x000A7E38
		// (set) Token: 0x06003FDD RID: 16349 RVA: 0x000A9C48 File Offset: 0x000A7E48
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

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06003FDE RID: 16350 RVA: 0x000A9C58 File Offset: 0x000A7E58
		// (set) Token: 0x06003FDF RID: 16351 RVA: 0x000A9C68 File Offset: 0x000A7E68
		public double M34
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

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06003FE0 RID: 16352 RVA: 0x000A9C78 File Offset: 0x000A7E78
		// (set) Token: 0x06003FE1 RID: 16353 RVA: 0x000A9C88 File Offset: 0x000A7E88
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

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06003FE2 RID: 16354 RVA: 0x000A9C98 File Offset: 0x000A7E98
		// (set) Token: 0x06003FE3 RID: 16355 RVA: 0x000A9CA8 File Offset: 0x000A7EA8
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

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06003FE4 RID: 16356 RVA: 0x000A9CB8 File Offset: 0x000A7EB8
		// (set) Token: 0x06003FE5 RID: 16357 RVA: 0x000A9CC8 File Offset: 0x000A7EC8
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

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06003FE6 RID: 16358 RVA: 0x000A9CD8 File Offset: 0x000A7ED8
		// (set) Token: 0x06003FE7 RID: 16359 RVA: 0x000A9CE8 File Offset: 0x000A7EE8
		public double M44
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

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06003FE8 RID: 16360 RVA: 0x000A9CF8 File Offset: 0x000A7EF8
		// (set) Token: 0x06003FE9 RID: 16361 RVA: 0x000A9D2C File Offset: 0x000A7F2C
		public Vector4d Diagonal
		{
			get
			{
				return new Vector4d(this.Row0.X, this.Row1.Y, this.Row2.Z, this.Row3.W);
			}
			set
			{
				this.Row0.X = value.X;
				this.Row1.Y = value.Y;
				this.Row2.Z = value.Z;
				this.Row3.W = value.W;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06003FEA RID: 16362 RVA: 0x000A9D84 File Offset: 0x000A7F84
		public double Trace
		{
			get
			{
				return this.Row0.X + this.Row1.Y + this.Row2.Z + this.Row3.W;
			}
		}

		// Token: 0x1700033D RID: 829
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

		// Token: 0x06003FED RID: 16365 RVA: 0x000A9ED4 File Offset: 0x000A80D4
		public void Invert()
		{
			this = Matrix4d.Invert(this);
		}

		// Token: 0x06003FEE RID: 16366 RVA: 0x000A9EE8 File Offset: 0x000A80E8
		public void Transpose()
		{
			this = Matrix4d.Transpose(this);
		}

		// Token: 0x06003FEF RID: 16367 RVA: 0x000A9EFC File Offset: 0x000A80FC
		public Matrix4d Normalized()
		{
			Matrix4d result = this;
			result.Normalize();
			return result;
		}

		// Token: 0x06003FF0 RID: 16368 RVA: 0x000A9F18 File Offset: 0x000A8118
		public void Normalize()
		{
			double determinant = this.Determinant;
			this.Row0 /= determinant;
			this.Row1 /= determinant;
			this.Row2 /= determinant;
			this.Row3 /= determinant;
		}

		// Token: 0x06003FF1 RID: 16369 RVA: 0x000A9F74 File Offset: 0x000A8174
		public Matrix4d Inverted()
		{
			Matrix4d result = this;
			if (result.Determinant != 0.0)
			{
				result.Invert();
			}
			return result;
		}

		// Token: 0x06003FF2 RID: 16370 RVA: 0x000A9FA4 File Offset: 0x000A81A4
		public Matrix4d ClearTranslation()
		{
			Matrix4d result = this;
			result.Row3.Xyz = Vector3d.Zero;
			return result;
		}

		// Token: 0x06003FF3 RID: 16371 RVA: 0x000A9FCC File Offset: 0x000A81CC
		public Matrix4d ClearScale()
		{
			Matrix4d result = this;
			result.Row0.Xyz = result.Row0.Xyz.Normalized();
			result.Row1.Xyz = result.Row1.Xyz.Normalized();
			result.Row2.Xyz = result.Row2.Xyz.Normalized();
			return result;
		}

		// Token: 0x06003FF4 RID: 16372 RVA: 0x000AA044 File Offset: 0x000A8244
		public Matrix4d ClearRotation()
		{
			Matrix4d result = this;
			result.Row0.Xyz = new Vector3d(result.Row0.Xyz.Length, 0.0, 0.0);
			result.Row1.Xyz = new Vector3d(0.0, result.Row1.Xyz.Length, 0.0);
			result.Row2.Xyz = new Vector3d(0.0, 0.0, result.Row2.Xyz.Length);
			return result;
		}

		// Token: 0x06003FF5 RID: 16373 RVA: 0x000AA100 File Offset: 0x000A8300
		public Matrix4d ClearProjection()
		{
			Matrix4d result = this;
			result.Column3 = Vector4d.Zero;
			return result;
		}

		// Token: 0x06003FF6 RID: 16374 RVA: 0x000AA124 File Offset: 0x000A8324
		public Vector3d ExtractTranslation()
		{
			return this.Row3.Xyz;
		}

		// Token: 0x06003FF7 RID: 16375 RVA: 0x000AA134 File Offset: 0x000A8334
		public Vector3d ExtractScale()
		{
			return new Vector3d(this.Row0.Xyz.Length, this.Row1.Xyz.Length, this.Row2.Xyz.Length);
		}

		// Token: 0x06003FF8 RID: 16376 RVA: 0x000AA180 File Offset: 0x000A8380
		public Quaterniond ExtractRotation(bool row_normalise = true)
		{
			Vector3d vector3d = this.Row0.Xyz;
			Vector3d vector3d2 = this.Row1.Xyz;
			Vector3d vector3d3 = this.Row2.Xyz;
			if (row_normalise)
			{
				vector3d = vector3d.Normalized();
				vector3d2 = vector3d2.Normalized();
				vector3d3 = vector3d3.Normalized();
			}
			Quaterniond result = default(Quaterniond);
			double num = 0.25 * (vector3d[0] + vector3d2[1] + vector3d3[2] + 1.0);
			if (num > 0.0)
			{
				double num2 = Math.Sqrt(num);
				result.W = num2;
				num2 = 1.0 / (4.0 * num2);
				result.X = (vector3d2[2] - vector3d3[1]) * num2;
				result.Y = (vector3d3[0] - vector3d[2]) * num2;
				result.Z = (vector3d[1] - vector3d2[0]) * num2;
			}
			else if (vector3d[0] > vector3d2[1] && vector3d[0] > vector3d3[2])
			{
				double num3 = 2.0 * Math.Sqrt(1.0 + vector3d[0] - vector3d2[1] - vector3d3[2]);
				result.X = 0.25 * num3;
				num3 = 1.0 / num3;
				result.W = (vector3d3[1] - vector3d2[2]) * num3;
				result.Y = (vector3d2[0] + vector3d[1]) * num3;
				result.Z = (vector3d3[0] + vector3d[2]) * num3;
			}
			else if (vector3d2[1] > vector3d3[2])
			{
				double num4 = 2.0 * Math.Sqrt(1.0 + vector3d2[1] - vector3d[0] - vector3d3[2]);
				result.Y = 0.25 * num4;
				num4 = 1.0 / num4;
				result.W = (vector3d3[0] - vector3d[2]) * num4;
				result.X = (vector3d2[0] + vector3d[1]) * num4;
				result.Z = (vector3d3[1] + vector3d2[2]) * num4;
			}
			else
			{
				double num5 = 2.0 * Math.Sqrt(1.0 + vector3d3[2] - vector3d[0] - vector3d2[1]);
				result.Z = 0.25 * num5;
				num5 = 1.0 / num5;
				result.W = (vector3d2[0] - vector3d[1]) * num5;
				result.X = (vector3d3[0] + vector3d[2]) * num5;
				result.Y = (vector3d3[1] + vector3d2[2]) * num5;
			}
			result.Normalize();
			return result;
		}

		// Token: 0x06003FF9 RID: 16377 RVA: 0x000AA4DC File Offset: 0x000A86DC
		public Vector4d ExtractProjection()
		{
			return this.Column3;
		}

		// Token: 0x06003FFA RID: 16378 RVA: 0x000AA4E4 File Offset: 0x000A86E4
		public static void CreateFromAxisAngle(Vector3d axis, double angle, out Matrix4d result)
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
			result.Row0.W = 0.0;
			result.Row1.X = num5 + num12;
			result.Row1.Y = num7 + num;
			result.Row1.Z = num8 - num10;
			result.Row1.W = 0.0;
			result.Row2.X = num6 - num11;
			result.Row2.Y = num8 + num10;
			result.Row2.Z = num9 + num;
			result.Row2.W = 0.0;
			result.Row3 = Vector4d.UnitW;
		}

		// Token: 0x06003FFB RID: 16379 RVA: 0x000AA644 File Offset: 0x000A8844
		public static Matrix4d CreateFromAxisAngle(Vector3d axis, double angle)
		{
			Matrix4d result;
			Matrix4d.CreateFromAxisAngle(axis, angle, out result);
			return result;
		}

		// Token: 0x06003FFC RID: 16380 RVA: 0x000AA65C File Offset: 0x000A885C
		public static void CreateRotationX(double angle, out Matrix4d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0 = Vector4d.UnitX;
			result.Row1 = new Vector4d(0.0, num, num2, 0.0);
			result.Row2 = new Vector4d(0.0, -num2, num, 0.0);
			result.Row3 = Vector4d.UnitW;
		}

		// Token: 0x06003FFD RID: 16381 RVA: 0x000AA6CC File Offset: 0x000A88CC
		public static Matrix4d CreateRotationX(double angle)
		{
			Matrix4d result;
			Matrix4d.CreateRotationX(angle, out result);
			return result;
		}

		// Token: 0x06003FFE RID: 16382 RVA: 0x000AA6E4 File Offset: 0x000A88E4
		public static void CreateRotationY(double angle, out Matrix4d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0 = new Vector4d(num, 0.0, -num2, 0.0);
			result.Row1 = Vector4d.UnitY;
			result.Row2 = new Vector4d(num2, 0.0, num, 0.0);
			result.Row3 = Vector4d.UnitW;
		}

		// Token: 0x06003FFF RID: 16383 RVA: 0x000AA754 File Offset: 0x000A8954
		public static Matrix4d CreateRotationY(double angle)
		{
			Matrix4d result;
			Matrix4d.CreateRotationY(angle, out result);
			return result;
		}

		// Token: 0x06004000 RID: 16384 RVA: 0x000AA76C File Offset: 0x000A896C
		public static void CreateRotationZ(double angle, out Matrix4d result)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			result.Row0 = new Vector4d(num, num2, 0.0, 0.0);
			result.Row1 = new Vector4d(-num2, num, 0.0, 0.0);
			result.Row2 = Vector4d.UnitZ;
			result.Row3 = Vector4d.UnitW;
		}

		// Token: 0x06004001 RID: 16385 RVA: 0x000AA7DC File Offset: 0x000A89DC
		public static Matrix4d CreateRotationZ(double angle)
		{
			Matrix4d result;
			Matrix4d.CreateRotationZ(angle, out result);
			return result;
		}

		// Token: 0x06004002 RID: 16386 RVA: 0x000AA7F4 File Offset: 0x000A89F4
		public static void CreateTranslation(double x, double y, double z, out Matrix4d result)
		{
			result = Matrix4d.Identity;
			result.Row3 = new Vector4d(x, y, z, 1.0);
		}

		// Token: 0x06004003 RID: 16387 RVA: 0x000AA818 File Offset: 0x000A8A18
		public static void CreateTranslation(ref Vector3d vector, out Matrix4d result)
		{
			result = Matrix4d.Identity;
			result.Row3 = new Vector4d(vector.X, vector.Y, vector.Z, 1.0);
		}

		// Token: 0x06004004 RID: 16388 RVA: 0x000AA84C File Offset: 0x000A8A4C
		public static Matrix4d CreateTranslation(double x, double y, double z)
		{
			Matrix4d result;
			Matrix4d.CreateTranslation(x, y, z, out result);
			return result;
		}

		// Token: 0x06004005 RID: 16389 RVA: 0x000AA864 File Offset: 0x000A8A64
		public static Matrix4d CreateTranslation(Vector3d vector)
		{
			Matrix4d result;
			Matrix4d.CreateTranslation(vector.X, vector.Y, vector.Z, out result);
			return result;
		}

		// Token: 0x06004006 RID: 16390 RVA: 0x000AA890 File Offset: 0x000A8A90
		public static void CreateOrthographic(double width, double height, double zNear, double zFar, out Matrix4d result)
		{
			Matrix4d.CreateOrthographicOffCenter(-width / 2.0, width / 2.0, -height / 2.0, height / 2.0, zNear, zFar, out result);
		}

		// Token: 0x06004007 RID: 16391 RVA: 0x000AA8CC File Offset: 0x000A8ACC
		public static Matrix4d CreateOrthographic(double width, double height, double zNear, double zFar)
		{
			Matrix4d result;
			Matrix4d.CreateOrthographicOffCenter(-width / 2.0, width / 2.0, -height / 2.0, height / 2.0, zNear, zFar, out result);
			return result;
		}

		// Token: 0x06004008 RID: 16392 RVA: 0x000AA914 File Offset: 0x000A8B14
		public static void CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNear, double zFar, out Matrix4d result)
		{
			result = default(Matrix4d);
			double num = 1.0 / (right - left);
			double num2 = 1.0 / (top - bottom);
			double num3 = 1.0 / (zFar - zNear);
			result.M11 = 2.0 * num;
			result.M22 = 2.0 * num2;
			result.M33 = -2.0 * num3;
			result.M41 = -(right + left) * num;
			result.M42 = -(top + bottom) * num2;
			result.M43 = -(zFar + zNear) * num3;
			result.M44 = 1.0;
		}

		// Token: 0x06004009 RID: 16393 RVA: 0x000AA9C4 File Offset: 0x000A8BC4
		public static Matrix4d CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNear, double zFar)
		{
			Matrix4d result;
			Matrix4d.CreateOrthographicOffCenter(left, right, bottom, top, zNear, zFar, out result);
			return result;
		}

		// Token: 0x0600400A RID: 16394 RVA: 0x000AA9E4 File Offset: 0x000A8BE4
		public static void CreatePerspectiveFieldOfView(double fovy, double aspect, double zNear, double zFar, out Matrix4d result)
		{
			if (fovy <= 0.0 || fovy > 3.141592653589793)
			{
				throw new ArgumentOutOfRangeException("fovy");
			}
			if (aspect <= 0.0)
			{
				throw new ArgumentOutOfRangeException("aspect");
			}
			if (zNear <= 0.0)
			{
				throw new ArgumentOutOfRangeException("zNear");
			}
			if (zFar <= 0.0)
			{
				throw new ArgumentOutOfRangeException("zFar");
			}
			double num = zNear * Math.Tan(0.5 * fovy);
			double num2 = -num;
			double left = num2 * aspect;
			double right = num * aspect;
			Matrix4d.CreatePerspectiveOffCenter(left, right, num2, num, zNear, zFar, out result);
		}

		// Token: 0x0600400B RID: 16395 RVA: 0x000AAA84 File Offset: 0x000A8C84
		public static Matrix4d CreatePerspectiveFieldOfView(double fovy, double aspect, double zNear, double zFar)
		{
			Matrix4d result;
			Matrix4d.CreatePerspectiveFieldOfView(fovy, aspect, zNear, zFar, out result);
			return result;
		}

		// Token: 0x0600400C RID: 16396 RVA: 0x000AAAA0 File Offset: 0x000A8CA0
		public static void CreatePerspectiveOffCenter(double left, double right, double bottom, double top, double zNear, double zFar, out Matrix4d result)
		{
			if (zNear <= 0.0)
			{
				throw new ArgumentOutOfRangeException("zNear");
			}
			if (zFar <= 0.0)
			{
				throw new ArgumentOutOfRangeException("zFar");
			}
			if (zNear >= zFar)
			{
				throw new ArgumentOutOfRangeException("zNear");
			}
			double m = 2.0 * zNear / (right - left);
			double m2 = 2.0 * zNear / (top - bottom);
			double m3 = (right + left) / (right - left);
			double m4 = (top + bottom) / (top - bottom);
			double m5 = -(zFar + zNear) / (zFar - zNear);
			double m6 = -(2.0 * zFar * zNear) / (zFar - zNear);
			result = new Matrix4d(m, 0.0, 0.0, 0.0, 0.0, m2, 0.0, 0.0, m3, m4, m5, -1.0, 0.0, 0.0, m6, 0.0);
		}

		// Token: 0x0600400D RID: 16397 RVA: 0x000AABB4 File Offset: 0x000A8DB4
		public static Matrix4d CreatePerspectiveOffCenter(double left, double right, double bottom, double top, double zNear, double zFar)
		{
			Matrix4d result;
			Matrix4d.CreatePerspectiveOffCenter(left, right, bottom, top, zNear, zFar, out result);
			return result;
		}

		// Token: 0x0600400E RID: 16398 RVA: 0x000AABD4 File Offset: 0x000A8DD4
		public static void CreateFromQuaternion(ref Quaterniond q, out Matrix4d result)
		{
			Vector3d axis;
			double angle;
			q.ToAxisAngle(out axis, out angle);
			Matrix4d.CreateFromAxisAngle(axis, angle, out result);
		}

		// Token: 0x0600400F RID: 16399 RVA: 0x000AABF4 File Offset: 0x000A8DF4
		public static Matrix4d CreateFromQuaternion(Quaterniond q)
		{
			Matrix4d result;
			Matrix4d.CreateFromQuaternion(ref q, out result);
			return result;
		}

		// Token: 0x06004010 RID: 16400 RVA: 0x000AAC0C File Offset: 0x000A8E0C
		[Obsolete("Use double-precision overload instead")]
		public static void CreateFromQuaternion(ref Quaternion q, ref Matrix4 m)
		{
			m = Matrix4.Identity;
			float x = q.X;
			float y = q.Y;
			float z = q.Z;
			float w = q.W;
			float num = x * x;
			float num2 = x * y;
			float num3 = x * z;
			float num4 = x * w;
			float num5 = y * y;
			float num6 = y * z;
			float num7 = y * w;
			float num8 = z * z;
			float num9 = z * w;
			m.M11 = 1f - 2f * (num5 + num8);
			m.M21 = 2f * (num2 - num9);
			m.M31 = 2f * (num3 + num7);
			m.M12 = 2f * (num2 + num9);
			m.M22 = 1f - 2f * (num + num8);
			m.M32 = 2f * (num6 - num4);
			m.M13 = 2f * (num3 - num7);
			m.M23 = 2f * (num6 + num4);
			m.M33 = 1f - 2f * (num + num5);
		}

		// Token: 0x06004011 RID: 16401 RVA: 0x000AAD18 File Offset: 0x000A8F18
		[Obsolete("Use double-precision overload instead")]
		public static Matrix4 CreateFromQuaternion(ref Quaternion q)
		{
			Matrix4 identity = Matrix4.Identity;
			float x = q.X;
			float y = q.Y;
			float z = q.Z;
			float w = q.W;
			float num = x * x;
			float num2 = x * y;
			float num3 = x * z;
			float num4 = x * w;
			float num5 = y * y;
			float num6 = y * z;
			float num7 = y * w;
			float num8 = z * z;
			float num9 = z * w;
			identity.M11 = 1f - 2f * (num5 + num8);
			identity.M21 = 2f * (num2 - num9);
			identity.M31 = 2f * (num3 + num7);
			identity.M12 = 2f * (num2 + num9);
			identity.M22 = 1f - 2f * (num + num8);
			identity.M32 = 2f * (num6 - num4);
			identity.M13 = 2f * (num3 - num7);
			identity.M23 = 2f * (num6 + num4);
			identity.M33 = 1f - 2f * (num + num5);
			return identity;
		}

		// Token: 0x06004012 RID: 16402 RVA: 0x000AAE30 File Offset: 0x000A9030
		[Obsolete("Use CreateTranslation instead.")]
		public static Matrix4d Translation(Vector3d trans)
		{
			return Matrix4d.Translation(trans.X, trans.Y, trans.Z);
		}

		// Token: 0x06004013 RID: 16403 RVA: 0x000AAE4C File Offset: 0x000A904C
		[Obsolete("Use CreateTranslation instead.")]
		public static Matrix4d Translation(double x, double y, double z)
		{
			Matrix4d identity = Matrix4d.Identity;
			identity.Row3 = new Vector4d(x, y, z, 1.0);
			return identity;
		}

		// Token: 0x06004014 RID: 16404 RVA: 0x000AAE78 File Offset: 0x000A9078
		public static Matrix4d Scale(double scale)
		{
			return Matrix4d.Scale(scale, scale, scale);
		}

		// Token: 0x06004015 RID: 16405 RVA: 0x000AAE84 File Offset: 0x000A9084
		public static Matrix4d Scale(Vector3d scale)
		{
			return Matrix4d.Scale(scale.X, scale.Y, scale.Z);
		}

		// Token: 0x06004016 RID: 16406 RVA: 0x000AAEA0 File Offset: 0x000A90A0
		public static Matrix4d Scale(double x, double y, double z)
		{
			Matrix4d result;
			result.Row0 = Vector4d.UnitX * x;
			result.Row1 = Vector4d.UnitY * y;
			result.Row2 = Vector4d.UnitZ * z;
			result.Row3 = Vector4d.UnitW;
			return result;
		}

		// Token: 0x06004017 RID: 16407 RVA: 0x000AAEF0 File Offset: 0x000A90F0
		public static Matrix4d RotateX(double angle)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			Matrix4d result;
			result.Row0 = Vector4d.UnitX;
			result.Row1 = new Vector4d(0.0, num, num2, 0.0);
			result.Row2 = new Vector4d(0.0, -num2, num, 0.0);
			result.Row3 = Vector4d.UnitW;
			return result;
		}

		// Token: 0x06004018 RID: 16408 RVA: 0x000AAF68 File Offset: 0x000A9168
		public static Matrix4d RotateY(double angle)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			Matrix4d result;
			result.Row0 = new Vector4d(num, 0.0, -num2, 0.0);
			result.Row1 = Vector4d.UnitY;
			result.Row2 = new Vector4d(num2, 0.0, num, 0.0);
			result.Row3 = Vector4d.UnitW;
			return result;
		}

		// Token: 0x06004019 RID: 16409 RVA: 0x000AAFE0 File Offset: 0x000A91E0
		public static Matrix4d RotateZ(double angle)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			Matrix4d result;
			result.Row0 = new Vector4d(num, num2, 0.0, 0.0);
			result.Row1 = new Vector4d(-num2, num, 0.0, 0.0);
			result.Row2 = Vector4d.UnitZ;
			result.Row3 = Vector4d.UnitW;
			return result;
		}

		// Token: 0x0600401A RID: 16410 RVA: 0x000AB058 File Offset: 0x000A9258
		public static Matrix4d Rotate(Vector3d axis, double angle)
		{
			double num = Math.Cos(-angle);
			double num2 = Math.Sin(-angle);
			double num3 = 1.0 - num;
			axis.Normalize();
			Matrix4d result;
			result.Row0 = new Vector4d(num3 * axis.X * axis.X + num, num3 * axis.X * axis.Y - num2 * axis.Z, num3 * axis.X * axis.Z + num2 * axis.Y, 0.0);
			result.Row1 = new Vector4d(num3 * axis.X * axis.Y + num2 * axis.Z, num3 * axis.Y * axis.Y + num, num3 * axis.Y * axis.Z - num2 * axis.X, 0.0);
			result.Row2 = new Vector4d(num3 * axis.X * axis.Z - num2 * axis.Y, num3 * axis.Y * axis.Z + num2 * axis.X, num3 * axis.Z * axis.Z + num, 0.0);
			result.Row3 = Vector4d.UnitW;
			return result;
		}

		// Token: 0x0600401B RID: 16411 RVA: 0x000AB1B0 File Offset: 0x000A93B0
		public static Matrix4d Rotate(Quaterniond q)
		{
			Vector3d axis;
			double angle;
			q.ToAxisAngle(out axis, out angle);
			return Matrix4d.Rotate(axis, angle);
		}

		// Token: 0x0600401C RID: 16412 RVA: 0x000AB1D0 File Offset: 0x000A93D0
		public static Matrix4d LookAt(Vector3d eye, Vector3d target, Vector3d up)
		{
			Vector3d vector3d = Vector3d.Normalize(eye - target);
			Vector3d right = Vector3d.Normalize(Vector3d.Cross(up, vector3d));
			Vector3d vector3d2 = Vector3d.Normalize(Vector3d.Cross(vector3d, right));
			Matrix4d right2 = new Matrix4d(new Vector4d(right.X, vector3d2.X, vector3d.X, 0.0), new Vector4d(right.Y, vector3d2.Y, vector3d.Y, 0.0), new Vector4d(right.Z, vector3d2.Z, vector3d.Z, 0.0), Vector4d.UnitW);
			Matrix4d left = Matrix4d.CreateTranslation(-eye);
			return left * right2;
		}

		// Token: 0x0600401D RID: 16413 RVA: 0x000AB290 File Offset: 0x000A9490
		public static Matrix4d LookAt(double eyeX, double eyeY, double eyeZ, double targetX, double targetY, double targetZ, double upX, double upY, double upZ)
		{
			return Matrix4d.LookAt(new Vector3d(eyeX, eyeY, eyeZ), new Vector3d(targetX, targetY, targetZ), new Vector3d(upX, upY, upZ));
		}

		// Token: 0x0600401E RID: 16414 RVA: 0x000AB2B4 File Offset: 0x000A94B4
		public static Matrix4d Frustum(double left, double right, double bottom, double top, double near, double far)
		{
			double num = 1.0 / (right - left);
			double num2 = 1.0 / (top - bottom);
			double num3 = 1.0 / (far - near);
			return new Matrix4d(new Vector4d(2.0 * near * num, 0.0, 0.0, 0.0), new Vector4d(0.0, 2.0 * near * num2, 0.0, 0.0), new Vector4d((right + left) * num, (top + bottom) * num2, -(far + near) * num3, -1.0), new Vector4d(0.0, 0.0, -2.0 * far * near * num3, 0.0));
		}

		// Token: 0x0600401F RID: 16415 RVA: 0x000AB3A0 File Offset: 0x000A95A0
		public static Matrix4d Perspective(double fovy, double aspect, double near, double far)
		{
			double num = near * Math.Tan(0.5 * fovy);
			double num2 = -num;
			double left = num2 * aspect;
			double right = num * aspect;
			return Matrix4d.Frustum(left, right, num2, num, near, far);
		}

		// Token: 0x06004020 RID: 16416 RVA: 0x000AB3D8 File Offset: 0x000A95D8
		public static Matrix4d Add(Matrix4d left, Matrix4d right)
		{
			Matrix4d result;
			Matrix4d.Add(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06004021 RID: 16417 RVA: 0x000AB3F4 File Offset: 0x000A95F4
		public static void Add(ref Matrix4d left, ref Matrix4d right, out Matrix4d result)
		{
			result.Row0 = left.Row0 + right.Row0;
			result.Row1 = left.Row1 + right.Row1;
			result.Row2 = left.Row2 + right.Row2;
			result.Row3 = left.Row3 + right.Row3;
		}

		// Token: 0x06004022 RID: 16418 RVA: 0x000AB460 File Offset: 0x000A9660
		public static Matrix4d Subtract(Matrix4d left, Matrix4d right)
		{
			Matrix4d result;
			Matrix4d.Subtract(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06004023 RID: 16419 RVA: 0x000AB47C File Offset: 0x000A967C
		public static void Subtract(ref Matrix4d left, ref Matrix4d right, out Matrix4d result)
		{
			result.Row0 = left.Row0 - right.Row0;
			result.Row1 = left.Row1 - right.Row1;
			result.Row2 = left.Row2 - right.Row2;
			result.Row3 = left.Row3 - right.Row3;
		}

		// Token: 0x06004024 RID: 16420 RVA: 0x000AB4E8 File Offset: 0x000A96E8
		public static Matrix4d Mult(Matrix4d left, Matrix4d right)
		{
			Matrix4d result;
			Matrix4d.Mult(ref left, ref right, out result);
			return result;
		}

		// Token: 0x06004025 RID: 16421 RVA: 0x000AB504 File Offset: 0x000A9704
		public static void Mult(ref Matrix4d left, ref Matrix4d right, out Matrix4d result)
		{
			double x = left.Row0.X;
			double y = left.Row0.Y;
			double z = left.Row0.Z;
			double w = left.Row0.W;
			double x2 = left.Row1.X;
			double y2 = left.Row1.Y;
			double z2 = left.Row1.Z;
			double w2 = left.Row1.W;
			double x3 = left.Row2.X;
			double y3 = left.Row2.Y;
			double z3 = left.Row2.Z;
			double w3 = left.Row2.W;
			double x4 = left.Row3.X;
			double y4 = left.Row3.Y;
			double z4 = left.Row3.Z;
			double w4 = left.Row3.W;
			double x5 = right.Row0.X;
			double y5 = right.Row0.Y;
			double z5 = right.Row0.Z;
			double w5 = right.Row0.W;
			double x6 = right.Row1.X;
			double y6 = right.Row1.Y;
			double z6 = right.Row1.Z;
			double w6 = right.Row1.W;
			double x7 = right.Row2.X;
			double y7 = right.Row2.Y;
			double z7 = right.Row2.Z;
			double w7 = right.Row2.W;
			double x8 = right.Row3.X;
			double y8 = right.Row3.Y;
			double z8 = right.Row3.Z;
			double w8 = right.Row3.W;
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

		// Token: 0x06004026 RID: 16422 RVA: 0x000AB8C0 File Offset: 0x000A9AC0
		public static Matrix4d Mult(Matrix4d left, double right)
		{
			Matrix4d result;
			Matrix4d.Mult(ref left, right, out result);
			return result;
		}

		// Token: 0x06004027 RID: 16423 RVA: 0x000AB8D8 File Offset: 0x000A9AD8
		public static void Mult(ref Matrix4d left, double right, out Matrix4d result)
		{
			result.Row0 = left.Row0 * right;
			result.Row1 = left.Row1 * right;
			result.Row2 = left.Row2 * right;
			result.Row3 = left.Row3 * right;
		}

		// Token: 0x06004028 RID: 16424 RVA: 0x000AB930 File Offset: 0x000A9B30
		public static Matrix4d Invert(Matrix4d mat)
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
			double[,] array6 = new double[4, 4];
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
			double[,] array7 = array6;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 4; i++)
			{
				double num3 = 0.0;
				for (int j = 0; j < 4; j++)
				{
					if (array5[j] != 0)
					{
						for (int k = 0; k < 4; k++)
						{
							if (array5[k] == -1)
							{
								double num4 = Math.Abs(array7[j, k]);
								if (num4 > num3)
								{
									num3 = num4;
									num2 = j;
									num = k;
								}
							}
							else if (array5[k] > 0)
							{
								return mat;
							}
						}
					}
				}
				array5[num]++;
				if (num2 != num)
				{
					for (int l = 0; l < 4; l++)
					{
						double num5 = array7[num2, l];
						array7[num2, l] = array7[num, l];
						array7[num, l] = num5;
					}
				}
				array4[i] = num2;
				array2[i] = num;
				double num6 = array7[num, num];
				if (num6 == 0.0)
				{
					throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
				}
				double num7 = 1.0 / num6;
				array7[num, num] = 1.0;
				for (int m = 0; m < 4; m++)
				{
					array7[num, m] *= num7;
				}
				for (int n = 0; n < 4; n++)
				{
					if (num != n)
					{
						double num8 = array7[n, num];
						array7[n, num] = 0.0;
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
					double num14 = array7[num13, num11];
					array7[num13, num11] = array7[num13, num12];
					array7[num13, num12] = num14;
				}
			}
			mat.Row0 = new Vector4d(array7[0, 0], array7[0, 1], array7[0, 2], array7[0, 3]);
			mat.Row1 = new Vector4d(array7[1, 0], array7[1, 1], array7[1, 2], array7[1, 3]);
			mat.Row2 = new Vector4d(array7[2, 0], array7[2, 1], array7[2, 2], array7[2, 3]);
			mat.Row3 = new Vector4d(array7[3, 0], array7[3, 1], array7[3, 2], array7[3, 3]);
			return mat;
		}

		// Token: 0x06004029 RID: 16425 RVA: 0x000ABD84 File Offset: 0x000A9F84
		public static Matrix4d Transpose(Matrix4d mat)
		{
			return new Matrix4d(mat.Column0, mat.Column1, mat.Column2, mat.Column3);
		}

		// Token: 0x0600402A RID: 16426 RVA: 0x000ABDA8 File Offset: 0x000A9FA8
		public static void Transpose(ref Matrix4d mat, out Matrix4d result)
		{
			result.Row0 = mat.Column0;
			result.Row1 = mat.Column1;
			result.Row2 = mat.Column2;
			result.Row3 = mat.Column3;
		}

		// Token: 0x0600402B RID: 16427 RVA: 0x000ABDDC File Offset: 0x000A9FDC
		public static Matrix4d operator *(Matrix4d left, Matrix4d right)
		{
			return Matrix4d.Mult(left, right);
		}

		// Token: 0x0600402C RID: 16428 RVA: 0x000ABDE8 File Offset: 0x000A9FE8
		public static Matrix4d operator *(Matrix4d left, float right)
		{
			return Matrix4d.Mult(left, (double)right);
		}

		// Token: 0x0600402D RID: 16429 RVA: 0x000ABDF4 File Offset: 0x000A9FF4
		public static Matrix4d operator +(Matrix4d left, Matrix4d right)
		{
			return Matrix4d.Add(left, right);
		}

		// Token: 0x0600402E RID: 16430 RVA: 0x000ABE00 File Offset: 0x000AA000
		public static Matrix4d operator -(Matrix4d left, Matrix4d right)
		{
			return Matrix4d.Subtract(left, right);
		}

		// Token: 0x0600402F RID: 16431 RVA: 0x000ABE0C File Offset: 0x000AA00C
		public static bool operator ==(Matrix4d left, Matrix4d right)
		{
			return left.Equals(right);
		}

		// Token: 0x06004030 RID: 16432 RVA: 0x000ABE18 File Offset: 0x000AA018
		public static bool operator !=(Matrix4d left, Matrix4d right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06004031 RID: 16433 RVA: 0x000ABE28 File Offset: 0x000AA028
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

		// Token: 0x06004032 RID: 16434 RVA: 0x000ABE80 File Offset: 0x000AA080
		public override int GetHashCode()
		{
			return this.Row0.GetHashCode() ^ this.Row1.GetHashCode() ^ this.Row2.GetHashCode() ^ this.Row3.GetHashCode();
		}

		// Token: 0x06004033 RID: 16435 RVA: 0x000ABED4 File Offset: 0x000AA0D4
		public override bool Equals(object obj)
		{
			return obj is Matrix4d && this.Equals((Matrix4d)obj);
		}

		// Token: 0x06004034 RID: 16436 RVA: 0x000ABEEC File Offset: 0x000AA0EC
		public bool Equals(Matrix4d other)
		{
			return this.Row0 == other.Row0 && this.Row1 == other.Row1 && this.Row2 == other.Row2 && this.Row3 == other.Row3;
		}

		// Token: 0x04004E0A RID: 19978
		public Vector4d Row0;

		// Token: 0x04004E0B RID: 19979
		public Vector4d Row1;

		// Token: 0x04004E0C RID: 19980
		public Vector4d Row2;

		// Token: 0x04004E0D RID: 19981
		public Vector4d Row3;

		// Token: 0x04004E0E RID: 19982
		public static Matrix4d Identity = new Matrix4d(Vector4d.UnitX, Vector4d.UnitY, Vector4d.UnitZ, Vector4d.UnitW);
	}
}
