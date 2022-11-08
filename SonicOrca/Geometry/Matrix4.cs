using System;
using System.Text;

namespace SonicOrca.Geometry
{
	// Token: 0x02000100 RID: 256
	public struct Matrix4 : IEquatable<Matrix4>
	{
		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x00022525 File Offset: 0x00020725
		// (set) Token: 0x060008A7 RID: 2215 RVA: 0x00022544 File Offset: 0x00020744
		public Vector4 Row1
		{
			get
			{
				return new Vector4(this.M11, this.M21, this.M31, this.M41);
			}
			set
			{
				this.M11 = value.X;
				this.M21 = value.Y;
				this.M31 = value.Z;
				this.M41 = value.W;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x0002257A File Offset: 0x0002077A
		// (set) Token: 0x060008A9 RID: 2217 RVA: 0x00022599 File Offset: 0x00020799
		public Vector4 Row2
		{
			get
			{
				return new Vector4(this.M12, this.M22, this.M32, this.M42);
			}
			set
			{
				this.M12 = value.X;
				this.M22 = value.Y;
				this.M32 = value.Z;
				this.M42 = value.W;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060008AA RID: 2218 RVA: 0x000225CF File Offset: 0x000207CF
		// (set) Token: 0x060008AB RID: 2219 RVA: 0x000225EE File Offset: 0x000207EE
		public Vector4 Row3
		{
			get
			{
				return new Vector4(this.M13, this.M23, this.M33, this.M43);
			}
			set
			{
				this.M13 = value.X;
				this.M23 = value.Y;
				this.M33 = value.Z;
				this.M43 = value.W;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x00022624 File Offset: 0x00020824
		// (set) Token: 0x060008AD RID: 2221 RVA: 0x00022643 File Offset: 0x00020843
		public Vector4 Row4
		{
			get
			{
				return new Vector4(this.M14, this.M24, this.M34, this.M44);
			}
			set
			{
				this.M14 = value.X;
				this.M24 = value.Y;
				this.M34 = value.Z;
				this.M44 = value.W;
			}
		}

		// Token: 0x170001E3 RID: 483
		public double this[int x, int y]
		{
			get
			{
				if (x == 0 && y == 0)
				{
					return this.M11;
				}
				if (x == 1 && y == 0)
				{
					return this.M21;
				}
				if (x == 2 && y == 0)
				{
					return this.M31;
				}
				if (x == 3 && y == 0)
				{
					return this.M41;
				}
				if (x == 0 && y == 1)
				{
					return this.M12;
				}
				if (x == 1 && y == 1)
				{
					return this.M22;
				}
				if (x == 2 && y == 1)
				{
					return this.M32;
				}
				if (x == 3 && y == 1)
				{
					return this.M42;
				}
				if (x == 0 && y == 2)
				{
					return this.M13;
				}
				if (x == 1 && y == 2)
				{
					return this.M23;
				}
				if (x == 2 && y == 2)
				{
					return this.M33;
				}
				if (x == 3 && y == 2)
				{
					return this.M43;
				}
				if (x == 0 && y == 3)
				{
					return this.M14;
				}
				if (x == 1 && y == 3)
				{
					return this.M24;
				}
				if (x == 2 && y == 3)
				{
					return this.M34;
				}
				if (x == 3 && y == 3)
				{
					return this.M44;
				}
				throw new ArgumentOutOfRangeException();
			}
			set
			{
				if (x == 0 && y == 0)
				{
					this.M11 = value;
					return;
				}
				if (x == 1 && y == 0)
				{
					this.M21 = value;
					return;
				}
				if (x == 2 && y == 0)
				{
					this.M31 = value;
					return;
				}
				if (x == 3 && y == 0)
				{
					this.M41 = value;
					return;
				}
				if (x == 0 && y == 1)
				{
					this.M12 = value;
					return;
				}
				if (x == 1 && y == 1)
				{
					this.M22 = value;
					return;
				}
				if (x == 2 && y == 1)
				{
					this.M32 = value;
					return;
				}
				if (x == 3 && y == 1)
				{
					this.M42 = value;
					return;
				}
				if (x == 0 && y == 2)
				{
					this.M13 = value;
					return;
				}
				if (x == 1 && y == 2)
				{
					this.M23 = value;
					return;
				}
				if (x == 2 && y == 2)
				{
					this.M33 = value;
					return;
				}
				if (x == 3 && y == 2)
				{
					this.M43 = value;
					return;
				}
				if (x == 0 && y == 3)
				{
					this.M14 = value;
					return;
				}
				if (x == 1 && y == 3)
				{
					this.M24 = value;
					return;
				}
				if (x == 2 && y == 3)
				{
					this.M34 = value;
					return;
				}
				if (x == 3 && y == 3)
				{
					this.M44 = value;
					return;
				}
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00022882 File Offset: 0x00020A82
		public Matrix4(Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4)
		{
			this = default(Matrix4);
			this.Row1 = row1;
			this.Row2 = row2;
			this.Row3 = row3;
			this.Row4 = row4;
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x000228A8 File Offset: 0x00020AA8
		public override bool Equals(object obj)
		{
			return this.Equals((Matrix4)obj);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x000228B8 File Offset: 0x00020AB8
		public bool Equals(Matrix4 other)
		{
			return this.Row1 == other.Row1 && this.Row2 == other.Row2 && this.Row3 == other.Row3 && this.Row4 == other.Row4;
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00022918 File Offset: 0x00020B18
		public override int GetHashCode()
		{
			return (((13 * 7 + this.Row1.GetHashCode()) * 7 + this.Row2.GetHashCode()) * 7 + this.Row3.GetHashCode()) * 7 + this.Row4.GetHashCode();
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00022984 File Offset: 0x00020B84
		public override string ToString()
		{
			Func<Vector4, string> func = (Vector4 v) => string.Format("({0},{1},{2},{3})", new object[]
			{
				v.X,
				v.Y,
				v.Z,
				v.W
			});
			return string.Join(Environment.NewLine, new string[]
			{
				func(this.Row1),
				func(this.Row2),
				func(this.Row3),
				func(this.Row4)
			});
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00022A00 File Offset: 0x00020C00
		public string GetFormattedString()
		{
			string[,] array = new string[4, 4];
			int[] array2 = new int[4];
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					array[j, i] = this[j, i].ToString();
					array2[j] = Math.Max(array2[j], array[j, i].Length);
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int k = 0; k < 4; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					int count = array2[l] - array[l, k].Length;
					stringBuilder.Append(' ');
					stringBuilder.Append(new string(' ', count));
					stringBuilder.Append(array[l, k]);
					stringBuilder.Append(' ');
				}
				if (k < 3)
				{
					stringBuilder.AppendLine();
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00022AEF File Offset: 0x00020CEF
		public Matrix4 Translate(double x, double y, double z = 0.0)
		{
			return Matrix4.CreateTranslation(x, y, z) * this;
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00022B04 File Offset: 0x00020D04
		public Matrix4 Translate(Vector2 v)
		{
			return Matrix4.CreateTranslation(v) * this;
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00022B17 File Offset: 0x00020D17
		public Matrix4 Translate(Vector3 v)
		{
			return Matrix4.CreateTranslation(v) * this;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00022B2A File Offset: 0x00020D2A
		public Matrix4 Scale(Vector2 v)
		{
			return Matrix4.CreateScale(v.X, v.Y, 1.0) * this;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00022B53 File Offset: 0x00020D53
		public Matrix4 Scale(double x, double y, double z = 1.0)
		{
			return Matrix4.CreateScale(x, y, z) * this;
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00022B68 File Offset: 0x00020D68
		public Matrix4 RotateX(double angle)
		{
			return this * Matrix4.CreateRotationX(angle);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00022B7B File Offset: 0x00020D7B
		public Matrix4 RotateY(double angle)
		{
			return this * Matrix4.CreateRotationY(angle);
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00022B8E File Offset: 0x00020D8E
		public Matrix4 RotateZ(double angle)
		{
			return this * Matrix4.CreateRotationZ(angle);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00022BA4 File Offset: 0x00020DA4
		public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
		{
			return new Matrix4
			{
				M11 = lhs.M11 * rhs.M11 + lhs.M12 * rhs.M21 + lhs.M13 * rhs.M31 + lhs.M14 * rhs.M41,
				M12 = lhs.M11 * rhs.M12 + lhs.M12 * rhs.M22 + lhs.M13 * rhs.M32 + lhs.M14 * rhs.M42,
				M13 = lhs.M11 * rhs.M13 + lhs.M12 * rhs.M23 + lhs.M13 * rhs.M33 + lhs.M14 * rhs.M43,
				M14 = lhs.M11 * rhs.M14 + lhs.M12 * rhs.M24 + lhs.M13 * rhs.M34 + lhs.M14 * rhs.M44,
				M21 = lhs.M21 * rhs.M11 + lhs.M22 * rhs.M21 + lhs.M23 * rhs.M31 + lhs.M24 * rhs.M41,
				M22 = lhs.M21 * rhs.M12 + lhs.M22 * rhs.M22 + lhs.M23 * rhs.M32 + lhs.M24 * rhs.M42,
				M23 = lhs.M21 * rhs.M13 + lhs.M22 * rhs.M23 + lhs.M23 * rhs.M33 + lhs.M24 * rhs.M43,
				M24 = lhs.M21 * rhs.M14 + lhs.M22 * rhs.M24 + lhs.M23 * rhs.M34 + lhs.M24 * rhs.M44,
				M31 = lhs.M31 * rhs.M11 + lhs.M32 * rhs.M21 + lhs.M33 * rhs.M31 + lhs.M34 * rhs.M41,
				M32 = lhs.M31 * rhs.M12 + lhs.M32 * rhs.M22 + lhs.M33 * rhs.M32 + lhs.M34 * rhs.M42,
				M33 = lhs.M31 * rhs.M13 + lhs.M32 * rhs.M23 + lhs.M33 * rhs.M33 + lhs.M34 * rhs.M43,
				M34 = lhs.M31 * rhs.M14 + lhs.M32 * rhs.M24 + lhs.M33 * rhs.M34 + lhs.M34 * rhs.M44,
				M41 = lhs.M41 * rhs.M11 + lhs.M42 * rhs.M21 + lhs.M43 * rhs.M31 + lhs.M44 * rhs.M41,
				M42 = lhs.M41 * rhs.M12 + lhs.M42 * rhs.M22 + lhs.M43 * rhs.M32 + lhs.M44 * rhs.M42,
				M43 = lhs.M41 * rhs.M13 + lhs.M42 * rhs.M23 + lhs.M43 * rhs.M33 + lhs.M44 * rhs.M43,
				M44 = lhs.M41 * rhs.M14 + lhs.M42 * rhs.M24 + lhs.M43 * rhs.M34 + lhs.M44 * rhs.M44
			};
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00022F9C File Offset: 0x0002119C
		public static Vector2 operator *(Matrix4 mat, Vector2 vec)
		{
			return (mat * new Vector4(vec.X, vec.Y, 1.0, 1.0)).XY;
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00022FDC File Offset: 0x000211DC
		public static Vector3 operator *(Matrix4 mat, Vector3 vec)
		{
			return (mat * new Vector4(vec.X, vec.Y, vec.Z, 1.0)).XYZ;
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0002301C File Offset: 0x0002121C
		public static Vector4 operator *(Matrix4 mat, Vector4 vec)
		{
			return new Vector4(vec.X * mat.Row1.X + vec.Y * mat.Row2.X + vec.Z * mat.Row3.X + vec.W * mat.Row4.X, vec.X * mat.Row1.Y + vec.Y * mat.Row2.Y + vec.Z * mat.Row3.Y + vec.W * mat.Row4.Y, vec.X * mat.Row1.Z + vec.Y * mat.Row2.Z + vec.Z * mat.Row3.Z + vec.W * mat.Row4.Z, vec.X * mat.Row1.W + vec.Y * mat.Row2.W + vec.Z * mat.Row3.W + vec.W * mat.Row4.W);
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x000231AA File Offset: 0x000213AA
		public static bool operator ==(Matrix4 lhs, Matrix4 rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x000231B4 File Offset: 0x000213B4
		public static bool operator !=(Matrix4 lhs, Matrix4 rhs)
		{
			return !lhs.Equals(rhs);
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x000231C1 File Offset: 0x000213C1
		public static Matrix4 CreateOrthographic(double width, double height, double zNear, double zFar)
		{
			return Matrix4.CreateOrthographicOffCenter(-width / 2.0, width / 2.0, -height / 2.0, height / 2.0, zNear, zFar);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x000231F8 File Offset: 0x000213F8
		public static Matrix4 CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNear, double zFar)
		{
			Matrix4 result = default(Matrix4);
			double num = 1.0 / (right - left);
			double num2 = 1.0 / (top - bottom);
			double num3 = 1.0 / (zFar - zNear);
			result.M11 = 2.0 * num;
			result.M22 = 2.0 * num2;
			result.M33 = -2.0 * num3;
			result.M14 = -(right + left) * num;
			result.M24 = -(top + bottom) * num2;
			result.M34 = -(zFar + zNear) * num3;
			result.M44 = 1.0;
			return result;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000232AC File Offset: 0x000214AC
		public static Matrix4 LookAt(Vector3 eye, Vector3 target, Vector3 up)
		{
			Vector3 normalised = (eye - target).Normalised;
			Vector3 normalised2 = up.Cross(normalised).Normalised;
			Vector3 normalised3 = normalised.Cross(normalised2).Normalised;
			Matrix4 lhs = new Matrix4(new Vector4(normalised2.X, normalised3.X, normalised.X, 0.0), new Vector4(normalised2.Y, normalised3.Y, normalised.Y, 0.0), new Vector4(normalised2.Z, normalised3.Z, normalised.Z, 0.0), Vector4.UnitW);
			Matrix4 rhs = Matrix4.CreateTranslation(-eye);
			return lhs * rhs;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x00023373 File Offset: 0x00021573
		public static Matrix4 LookAt(double eyeX, double eyeY, double eyeZ, double targetX, double targetY, double targetZ, double upX, double upY, double upZ)
		{
			return Matrix4.LookAt(new Vector3(eyeX, eyeY, eyeZ), new Vector3(targetX, targetY, targetZ), new Vector3(upX, upY, upZ));
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00023398 File Offset: 0x00021598
		public static Matrix4 Frustum(double left, double right, double bottom, double top, double near, double far)
		{
			double num = 1.0 / (right - left);
			double num2 = 1.0 / (top - bottom);
			double num3 = 1.0 / (far - near);
			return new Matrix4(new Vector4(2.0 * near * num, 0.0, 0.0, 0.0), new Vector4(0.0, 2.0 * near * num2, 0.0, 0.0), new Vector4((right + left) * num, (top + bottom) * num2, -(far + near) * num3, -1.0), new Vector4(0.0, 0.0, -2.0 * far * near * num3, 0.0));
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x00023484 File Offset: 0x00021684
		public static Matrix4 Perspective(double fovy, double aspect, double near, double far)
		{
			double num = near * Math.Tan(0.5 * fovy);
			double num2 = -num;
			double left = num2 * aspect;
			double right = num * aspect;
			return Matrix4.Frustum(left, right, num2, num, near, far);
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x000234B8 File Offset: 0x000216B8
		public static Matrix4 CreateTranslation(Vector2 value)
		{
			Matrix4 identity = Matrix4.Identity;
			identity.M14 = value.X;
			identity.M24 = value.Y;
			return identity;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x000234E8 File Offset: 0x000216E8
		public static Matrix4 CreateTranslation(Vector3 value)
		{
			Matrix4 identity = Matrix4.Identity;
			identity.M14 = value.X;
			identity.M24 = value.Y;
			identity.M34 = value.Z;
			return identity;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00023528 File Offset: 0x00021728
		public static Matrix4 CreateTranslation(double x, double y, double z = 0.0)
		{
			Matrix4 identity = Matrix4.Identity;
			identity.M14 = x;
			identity.M24 = y;
			identity.M34 = z;
			return identity;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00023554 File Offset: 0x00021754
		public static Matrix4 CreateScale(double x, double y, double z = 1.0)
		{
			Matrix4 identity = Matrix4.Identity;
			identity.M11 = x;
			identity.M22 = y;
			identity.M33 = z;
			return identity;
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00023580 File Offset: 0x00021780
		public static Matrix4 CreateRotationX(double angle)
		{
			double m = Math.Cos(angle);
			double num = Math.Sin(angle);
			Matrix4 identity = Matrix4.Identity;
			identity.M21 = m;
			identity.M31 = num;
			identity.M22 = -num;
			identity.M32 = num;
			return identity;
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x000235C8 File Offset: 0x000217C8
		public static Matrix4 CreateRotationY(double angle)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			Matrix4 identity = Matrix4.Identity;
			identity.M11 = num;
			identity.M31 = -num2;
			identity.M13 = num2;
			identity.M33 = num;
			return identity;
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00023610 File Offset: 0x00021810
		public static Matrix4 CreateRotationZ(double angle)
		{
			double num = Math.Cos(angle);
			double num2 = Math.Sin(angle);
			Matrix4 identity = Matrix4.Identity;
			identity.M11 = num;
			identity.M21 = num2;
			identity.M12 = -num2;
			identity.M22 = num;
			return identity;
		}

		// Token: 0x04000552 RID: 1362
		public double M11;

		// Token: 0x04000553 RID: 1363
		public double M21;

		// Token: 0x04000554 RID: 1364
		public double M31;

		// Token: 0x04000555 RID: 1365
		public double M41;

		// Token: 0x04000556 RID: 1366
		public double M12;

		// Token: 0x04000557 RID: 1367
		public double M22;

		// Token: 0x04000558 RID: 1368
		public double M32;

		// Token: 0x04000559 RID: 1369
		public double M42;

		// Token: 0x0400055A RID: 1370
		public double M13;

		// Token: 0x0400055B RID: 1371
		public double M23;

		// Token: 0x0400055C RID: 1372
		public double M33;

		// Token: 0x0400055D RID: 1373
		public double M43;

		// Token: 0x0400055E RID: 1374
		public double M14;

		// Token: 0x0400055F RID: 1375
		public double M24;

		// Token: 0x04000560 RID: 1376
		public double M34;

		// Token: 0x04000561 RID: 1377
		public double M44;

		// Token: 0x04000562 RID: 1378
		public static Matrix4 Identity = new Matrix4(Vector4.UnitX, Vector4.UnitY, Vector4.UnitZ, Vector4.UnitW);
	}
}
