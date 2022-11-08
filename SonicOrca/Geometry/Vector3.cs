using System;

namespace SonicOrca.Geometry
{
	// Token: 0x02000108 RID: 264
	public struct Vector3 : IEquatable<Vector3>
	{
		// Token: 0x1700021A RID: 538
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x0002525B File Offset: 0x0002345B
		// (set) Token: 0x0600099E RID: 2462 RVA: 0x00025263 File Offset: 0x00023463
		public double X { get; set; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x0002526C File Offset: 0x0002346C
		// (set) Token: 0x060009A0 RID: 2464 RVA: 0x00025274 File Offset: 0x00023474
		public double Y { get; set; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0002527D File Offset: 0x0002347D
		// (set) Token: 0x060009A2 RID: 2466 RVA: 0x00025285 File Offset: 0x00023485
		public double Z { get; set; }

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x0002528E File Offset: 0x0002348E
		public Vector2 XY
		{
			get
			{
				return new Vector2(this.X, this.Y);
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x000252A1 File Offset: 0x000234A1
		public Vector3 Normalised
		{
			get
			{
				return this / this.Length;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x000252B4 File Offset: 0x000234B4
		public double Length
		{
			get
			{
				return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
			}
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x000252E4 File Offset: 0x000234E4
		public Vector3(double xyz)
		{
			this = new Vector3(xyz, xyz, xyz);
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000252EF File Offset: 0x000234EF
		public Vector3(double x, double y, double z)
		{
			this = default(Vector3);
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0002530D File Offset: 0x0002350D
		public override bool Equals(object obj)
		{
			return this.Equals((Vector3)obj);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0002531B File Offset: 0x0002351B
		public bool Equals(Vector3 p)
		{
			return p.X == this.X && p.Y == this.Y && p.Z == this.Z;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0002534C File Offset: 0x0002354C
		public override int GetHashCode()
		{
			return ((13 * 7 + this.X.GetHashCode()) * 7 + this.Y.GetHashCode()) * 7 + this.Z.GetHashCode();
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0002538E File Offset: 0x0002358E
		public override string ToString()
		{
			return string.Format("X = {0} Y = {1} Z = {2}", this.X, this.Y, this.Z);
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000253BC File Offset: 0x000235BC
		public Vector3 Cross(Vector3 other)
		{
			return new Vector3(this.Y * other.Z - this.Z * other.Y, this.Z * other.X - this.X * other.Z, this.X * other.Y - this.Y * other.X);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x00025425 File Offset: 0x00023625
		public static Vector3 operator +(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00025459 File Offset: 0x00023659
		public static Vector3 operator -(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0002548D File Offset: 0x0002368D
		public static Vector3 operator -(Vector3 v)
		{
			return new Vector3(-v.X, -v.Y, -v.Z);
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x000254AC File Offset: 0x000236AC
		public static Vector3 operator *(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x000254E0 File Offset: 0x000236E0
		public static Vector3 operator *(Vector3 v, double s)
		{
			return new Vector3(v.X * s, v.Y * s, v.Z * s);
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00025502 File Offset: 0x00023702
		public static Vector3 operator *(double s, Vector3 v)
		{
			return new Vector3(v.X * s, v.Y * s, v.Z * s);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00025524 File Offset: 0x00023724
		public static Vector3 operator /(Vector3 a, Vector3 b)
		{
			return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00025558 File Offset: 0x00023758
		public static Vector3 operator /(Vector3 v, double s)
		{
			return new Vector3(v.X / s, v.Y / s, v.Z / s);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0002557A File Offset: 0x0002377A
		public static Vector3 operator /(double s, Vector3 v)
		{
			return new Vector3(v.X / s, v.Y / s, v.Z / s);
		}
	}
}
