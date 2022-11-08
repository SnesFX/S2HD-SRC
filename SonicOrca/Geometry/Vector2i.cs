using System;

namespace SonicOrca.Geometry
{
	// Token: 0x02000107 RID: 263
	public struct Vector2i : IEquatable<Vector2i>
	{
		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000987 RID: 2439 RVA: 0x0002504A File Offset: 0x0002324A
		// (set) Token: 0x06000988 RID: 2440 RVA: 0x00025052 File Offset: 0x00023252
		public int X { get; set; }

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000989 RID: 2441 RVA: 0x0002505B File Offset: 0x0002325B
		// (set) Token: 0x0600098A RID: 2442 RVA: 0x00025063 File Offset: 0x00023263
		public int Y { get; set; }

		// Token: 0x0600098B RID: 2443 RVA: 0x0002506C File Offset: 0x0002326C
		public Vector2i(int xy)
		{
			this = new Vector2i(xy, xy);
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00025076 File Offset: 0x00023276
		public Vector2i(int x, int y)
		{
			this = default(Vector2i);
			this.X = x;
			this.Y = y;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0002508D File Offset: 0x0002328D
		public override bool Equals(object obj)
		{
			return this.Equals((Vector2i)obj);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0002509B File Offset: 0x0002329B
		public bool Equals(Vector2i p)
		{
			return p.X == this.X && p.Y == this.Y;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x000250C0 File Offset: 0x000232C0
		public override int GetHashCode()
		{
			return (13 * 7 + this.X.GetHashCode()) * 7 + this.Y.GetHashCode();
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x000250F1 File Offset: 0x000232F1
		public override string ToString()
		{
			return string.Format("X = {0}, Y = {1}", this.X, this.Y);
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000991 RID: 2449 RVA: 0x00025113 File Offset: 0x00023313
		public int Length
		{
			get
			{
				return (int)Math.Sqrt((double)((long)this.X * (long)this.X + (long)this.Y * (long)this.Y));
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x0002513B File Offset: 0x0002333B
		public double Angle
		{
			get
			{
				return Math.Atan2((double)this.Y, (double)this.X);
			}
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00025150 File Offset: 0x00023350
		public static Vector2i operator +(Vector2i a, Vector2i b)
		{
			return new Vector2i(a.X + b.X, a.Y + b.Y);
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00025175 File Offset: 0x00023375
		public static Vector2i operator -(Vector2i a, Vector2i b)
		{
			return new Vector2i(a.X - b.X, a.Y - b.Y);
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0002519A File Offset: 0x0002339A
		public static Vector2i operator *(Vector2i a, Vector2i b)
		{
			return new Vector2i(a.X * b.X, a.Y * b.Y);
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x000251BF File Offset: 0x000233BF
		public static Vector2i operator /(Vector2i a, Vector2i b)
		{
			return new Vector2i(a.X / b.X, a.Y / b.Y);
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x000251E4 File Offset: 0x000233E4
		public static Vector2i operator *(Vector2i v, int x)
		{
			return new Vector2i(v.X * x, v.Y * x);
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x000251FD File Offset: 0x000233FD
		public static Vector2i operator /(Vector2i v, int x)
		{
			return new Vector2i(v.X / x, v.Y / x);
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00025216 File Offset: 0x00023416
		public static bool operator ==(Vector2i a, Vector2i b)
		{
			return a.Equals(b);
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00025220 File Offset: 0x00023420
		public static bool operator !=(Vector2i a, Vector2i b)
		{
			return !a.Equals(b);
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002522D File Offset: 0x0002342D
		public static implicit operator Vector2(Vector2i v)
		{
			return new Vector2((double)v.X, (double)v.Y);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00025244 File Offset: 0x00023444
		public static explicit operator Vector2i(Vector2 v)
		{
			return new Vector2i((int)v.X, (int)v.Y);
		}
	}
}
