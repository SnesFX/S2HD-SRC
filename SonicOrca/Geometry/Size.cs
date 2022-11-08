using System;

namespace SonicOrca.Geometry
{
	// Token: 0x02000104 RID: 260
	public struct Size : IComparable<Size>, IEquatable<Size>
	{
		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x00024645 File Offset: 0x00022845
		// (set) Token: 0x0600093C RID: 2364 RVA: 0x0002464D File Offset: 0x0002284D
		public double Width { get; set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x00024656 File Offset: 0x00022856
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x0002465E File Offset: 0x0002285E
		public double Height { get; set; }

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x00024667 File Offset: 0x00022867
		public double Area
		{
			get
			{
				return this.Width * this.Height;
			}
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00024676 File Offset: 0x00022876
		public Size(double width, double height)
		{
			this = default(Size);
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0002468D File Offset: 0x0002288D
		public override bool Equals(object obj)
		{
			return this.Equals((Size)obj);
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0002469B File Offset: 0x0002289B
		public bool Equals(Size other)
		{
			return this.Width == other.Width && this.Height == other.Height;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x000246C0 File Offset: 0x000228C0
		public int CompareTo(Size other)
		{
			return this.Area.CompareTo(other.Area);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x000246E4 File Offset: 0x000228E4
		public override int GetHashCode()
		{
			return (13 * 7 + this.Width.GetHashCode()) * 7 + this.Height.GetHashCode();
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00024715 File Offset: 0x00022915
		public override string ToString()
		{
			return string.Format("Width = {0} Height = {1}", this.Width, this.Height);
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x00024737 File Offset: 0x00022937
		public static Size operator +(Size a, Size b)
		{
			return new Size(a.Width + b.Width, a.Height + b.Height);
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0002475C File Offset: 0x0002295C
		public static Size operator -(Size a, Size b)
		{
			return new Size(a.Width - b.Width, a.Height - b.Height);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00024781 File Offset: 0x00022981
		public static Size operator *(Size a, Size b)
		{
			return new Size(a.Width * b.Width, a.Height * b.Height);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x000247A6 File Offset: 0x000229A6
		public static Size operator /(Size a, Size b)
		{
			return new Size(a.Width / b.Width, a.Height / b.Height);
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x000247CB File Offset: 0x000229CB
		public static Size operator *(Size v, int x)
		{
			return new Size(v.Width * (double)x, v.Height * (double)x);
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x000247E6 File Offset: 0x000229E6
		public static Size operator /(Size v, int x)
		{
			return new Size(v.Width / (double)x, v.Height / (double)x);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00024801 File Offset: 0x00022A01
		public static bool operator ==(Size a, Size b)
		{
			return a.Equals(b);
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0002480B File Offset: 0x00022A0B
		public static bool operator !=(Size a, Size b)
		{
			return !a.Equals(b);
		}
	}
}
