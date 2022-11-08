using System;

namespace SonicOrca.Geometry
{
	// Token: 0x02000105 RID: 261
	public struct Sizei : IComparable<Sizei>, IEquatable<Sizei>
	{
		// Token: 0x1700020D RID: 525
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x00024818 File Offset: 0x00022A18
		// (set) Token: 0x0600094F RID: 2383 RVA: 0x00024820 File Offset: 0x00022A20
		public int Width { get; set; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x00024829 File Offset: 0x00022A29
		// (set) Token: 0x06000951 RID: 2385 RVA: 0x00024831 File Offset: 0x00022A31
		public int Height { get; set; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x0002483A File Offset: 0x00022A3A
		public long Area
		{
			get
			{
				return (long)this.Width * (long)this.Height;
			}
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0002484B File Offset: 0x00022A4B
		public Sizei(int width, int height)
		{
			this = default(Sizei);
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00024862 File Offset: 0x00022A62
		public override bool Equals(object obj)
		{
			return this.Equals((Sizei)obj);
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00024870 File Offset: 0x00022A70
		public bool Equals(Sizei other)
		{
			return this.Width == other.Width && this.Height == other.Height;
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00024894 File Offset: 0x00022A94
		public int CompareTo(Sizei other)
		{
			return this.Area.CompareTo(other.Area);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x000248B8 File Offset: 0x00022AB8
		public override int GetHashCode()
		{
			return (13 * 7 + this.Width.GetHashCode()) * 7 + this.Height.GetHashCode();
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x000248E9 File Offset: 0x00022AE9
		public override string ToString()
		{
			return string.Format("Width = {0} Height = {1}", this.Width, this.Height);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0002490B File Offset: 0x00022B0B
		public static Sizei operator +(Sizei a, Sizei b)
		{
			return new Sizei(a.Width + b.Width, a.Height + b.Height);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00024930 File Offset: 0x00022B30
		public static Sizei operator -(Sizei a, Sizei b)
		{
			return new Sizei(a.Width - b.Width, a.Height - b.Height);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00024955 File Offset: 0x00022B55
		public static Sizei operator *(Sizei a, Sizei b)
		{
			return new Sizei(a.Width * b.Width, a.Height * b.Height);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0002497A File Offset: 0x00022B7A
		public static Sizei operator /(Sizei a, Sizei b)
		{
			return new Sizei(a.Width / b.Width, a.Height / b.Height);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0002499F File Offset: 0x00022B9F
		public static Sizei operator *(Sizei v, int x)
		{
			return new Sizei(v.Width * x, v.Height * x);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x000249B8 File Offset: 0x00022BB8
		public static Sizei operator /(Sizei v, int x)
		{
			return new Sizei(v.Width / x, v.Height / x);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x000249D1 File Offset: 0x00022BD1
		public static bool operator ==(Sizei a, Sizei b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x000249DB File Offset: 0x00022BDB
		public static bool operator !=(Sizei a, Sizei b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x000249E8 File Offset: 0x00022BE8
		public static implicit operator Size(Sizei size)
		{
			return new Size((double)size.Width, (double)size.Height);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x000249FF File Offset: 0x00022BFF
		public static explicit operator Sizei(Size size)
		{
			return new Sizei((int)size.Width, (int)size.Height);
		}
	}
}
