using System;

namespace SonicOrca.Geometry
{
	// Token: 0x02000109 RID: 265
	public struct Vector4 : IEquatable<Vector4>
	{
		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x0002559C File Offset: 0x0002379C
		// (set) Token: 0x060009B7 RID: 2487 RVA: 0x000255A4 File Offset: 0x000237A4
		public double X { get; set; }

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x000255AD File Offset: 0x000237AD
		// (set) Token: 0x060009B9 RID: 2489 RVA: 0x000255B5 File Offset: 0x000237B5
		public double Y { get; set; }

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x000255BE File Offset: 0x000237BE
		// (set) Token: 0x060009BB RID: 2491 RVA: 0x000255C6 File Offset: 0x000237C6
		public double Z { get; set; }

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x000255CF File Offset: 0x000237CF
		// (set) Token: 0x060009BD RID: 2493 RVA: 0x000255D7 File Offset: 0x000237D7
		public double W { get; set; }

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x000255E0 File Offset: 0x000237E0
		public Vector2 XY
		{
			get
			{
				return new Vector2(this.X, this.Y);
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x000255F3 File Offset: 0x000237F3
		public Vector3 XYZ
		{
			get
			{
				return new Vector3(this.X, this.Y, this.Z);
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0002560C File Offset: 0x0002380C
		public Vector4 Normalised
		{
			get
			{
				return this / this.Length;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x00025620 File Offset: 0x00023820
		public double Length
		{
			get
			{
				return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W * this.W);
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x00025670 File Offset: 0x00023870
		public static Vector4 UnitX
		{
			get
			{
				return new Vector4(1.0, 0.0, 0.0, 0.0);
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x0002569B File Offset: 0x0002389B
		public static Vector4 UnitY
		{
			get
			{
				return new Vector4(0.0, 1.0, 0.0, 0.0);
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x000256C6 File Offset: 0x000238C6
		public static Vector4 UnitZ
		{
			get
			{
				return new Vector4(0.0, 0.0, 1.0, 0.0);
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060009C5 RID: 2501 RVA: 0x000256F1 File Offset: 0x000238F1
		public static Vector4 UnitW
		{
			get
			{
				return new Vector4(0.0, 0.0, 0.0, 1.0);
			}
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0002571C File Offset: 0x0002391C
		public Vector4(double xyzw)
		{
			this = new Vector4(xyzw, xyzw, xyzw, xyzw);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x00025728 File Offset: 0x00023928
		public Vector4(double x, double y, double z, double w)
		{
			this = default(Vector4);
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0002574E File Offset: 0x0002394E
		public override bool Equals(object obj)
		{
			return this.Equals((Vector4)obj);
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0002575C File Offset: 0x0002395C
		public bool Equals(Vector4 p)
		{
			return p.X == this.X && p.Y == this.Y && p.Z == this.Z && p.W == this.W;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0002579C File Offset: 0x0002399C
		public override int GetHashCode()
		{
			return (((13 * 7 + this.X.GetHashCode()) * 7 + this.Y.GetHashCode()) * 7 + this.Z.GetHashCode()) * 7 + this.W.GetHashCode();
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x000257F0 File Offset: 0x000239F0
		public override string ToString()
		{
			return string.Format("X = {0} Y = {1} Z = {2} W = {3}", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			});
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00025848 File Offset: 0x00023A48
		public static Vector4 operator +(Vector4 a, Vector4 b)
		{
			return new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00025898 File Offset: 0x00023A98
		public static Vector4 operator -(Vector4 a, Vector4 b)
		{
			return new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x000258E6 File Offset: 0x00023AE6
		public static Vector4 operator -(Vector4 v)
		{
			return new Vector4(-v.X, -v.Y, -v.Z, -v.W);
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00025910 File Offset: 0x00023B10
		public static Vector4 operator *(Vector4 a, Vector4 b)
		{
			return new Vector4(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0002595E File Offset: 0x00023B5E
		public static Vector4 operator *(Vector4 v, double s)
		{
			return new Vector4(v.X * s, v.Y * s, v.Z * s, v.W * s);
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00025989 File Offset: 0x00023B89
		public static Vector4 operator *(double s, Vector4 v)
		{
			return new Vector4(v.X * s, v.Y * s, v.Z * s, v.W * s);
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x000259B4 File Offset: 0x00023BB4
		public static Vector4 operator /(Vector4 a, Vector4 b)
		{
			return new Vector4(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x00025A02 File Offset: 0x00023C02
		public static Vector4 operator /(Vector4 v, double s)
		{
			return new Vector4(v.X / s, v.Y / s, v.Z / s, v.W / s);
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x00025A2D File Offset: 0x00023C2D
		public static Vector4 operator /(double s, Vector4 v)
		{
			return new Vector4(v.X / s, v.Y / s, v.Z / s, v.W / s);
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00025A58 File Offset: 0x00023C58
		public static bool operator ==(Vector4 a, Vector4 b)
		{
			return a.Equals(b);
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x00025A62 File Offset: 0x00023C62
		public static bool operator !=(Vector4 a, Vector4 b)
		{
			return !a.Equals(b);
		}
	}
}
