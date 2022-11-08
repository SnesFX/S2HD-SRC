using System;

namespace SonicOrca.Geometry
{
	// Token: 0x02000103 RID: 259
	public struct Rectanglei : IEquatable<Rectanglei>
	{
		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x00024004 File Offset: 0x00022204
		public static Rectanglei Empty
		{
			get
			{
				return default(Rectanglei);
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x0002401A File Offset: 0x0002221A
		// (set) Token: 0x06000910 RID: 2320 RVA: 0x00024022 File Offset: 0x00022222
		public int X { get; set; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0002402B File Offset: 0x0002222B
		// (set) Token: 0x06000912 RID: 2322 RVA: 0x00024033 File Offset: 0x00022233
		public int Y { get; set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x0002403C File Offset: 0x0002223C
		// (set) Token: 0x06000914 RID: 2324 RVA: 0x00024044 File Offset: 0x00022244
		public int Width { get; set; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x0002404D File Offset: 0x0002224D
		// (set) Token: 0x06000916 RID: 2326 RVA: 0x00024055 File Offset: 0x00022255
		public int Height { get; set; }

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x0002405E File Offset: 0x0002225E
		public long Area
		{
			get
			{
				return (long)this.Width * (long)this.Height;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x0002406F File Offset: 0x0002226F
		public Vector2i TopLeft
		{
			get
			{
				return new Vector2i(this.Left, this.Top);
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x00024082 File Offset: 0x00022282
		public Vector2i TopRight
		{
			get
			{
				return new Vector2i(this.Right, this.Top);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x00024095 File Offset: 0x00022295
		public Vector2i BottomLeft
		{
			get
			{
				return new Vector2i(this.Left, this.Bottom);
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x000240A8 File Offset: 0x000222A8
		public Vector2i BottomRight
		{
			get
			{
				return new Vector2i(this.Right, this.Bottom);
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x000240BB File Offset: 0x000222BB
		public Vector2i Centre
		{
			get
			{
				return new Vector2i(this.Left + this.Width / 2, this.Top + this.Height / 2);
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x000240E0 File Offset: 0x000222E0
		public Sizei Size
		{
			get
			{
				return new Sizei(this.Width, this.Height);
			}
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x000240F3 File Offset: 0x000222F3
		public static Rectangle FromLTRB(float left, float top, float right, float bottom)
		{
			return new Rectangle((double)left, (double)top, (double)(right - left), (double)(bottom - top));
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00024106 File Offset: 0x00022306
		public static Rectanglei FromLTRB(int left, int top, int right, int bottom)
		{
			return new Rectanglei(left, top, right - left, bottom - top);
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00024115 File Offset: 0x00022315
		public Rectanglei(int x, int y, int width, int height)
		{
			this = default(Rectanglei);
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0002413B File Offset: 0x0002233B
		public bool Contains(Vector2i p)
		{
			return p.X >= this.X && p.Y >= this.Y && p.X < this.Right && p.Y < this.Bottom;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0002417C File Offset: 0x0002237C
		public bool Contains(Rectanglei rect)
		{
			return rect.X >= this.X && rect.Y >= this.Y && rect.Right <= this.Right && rect.Bottom <= this.Bottom;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x000241CA File Offset: 0x000223CA
		public bool IntersectsWith(Rectanglei rect)
		{
			return rect.X < this.Right && rect.Right > this.X && rect.Y < this.Bottom && rect.Bottom > this.Y;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0002420C File Offset: 0x0002240C
		public Rectanglei Inflate(Vector2i amount)
		{
			return new Rectanglei(this.X - amount.X, this.Y - amount.Y, this.Width + amount.X * 2, this.Height + amount.Y * 2);
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0002425A File Offset: 0x0002245A
		public Rectanglei OffsetBy(Vector2i amount)
		{
			return new Rectanglei(this.X + amount.X, this.Y + amount.Y, this.Width, this.Height);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0002428C File Offset: 0x0002248C
		public Rectanglei Union(Rectanglei rect)
		{
			return new Rectanglei
			{
				Left = Math.Min(this.Left, rect.Left),
				Top = Math.Min(this.Top, rect.Top),
				Right = Math.Max(this.Right, rect.Right),
				Bottom = Math.Max(this.Bottom, rect.Bottom)
			};
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00024308 File Offset: 0x00022508
		public override bool Equals(object obj)
		{
			Rectanglei rectanglei = (Rectanglei)obj;
			return rectanglei.X == this.X && rectanglei.Y == this.Y && rectanglei.Width == this.Width && rectanglei.Height == this.Height;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0002435A File Offset: 0x0002255A
		public bool Equals(Rectanglei other)
		{
			return other.X == this.X && other.Y == this.Y && other.Width == this.Width && other.Height == this.Height;
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0002439C File Offset: 0x0002259C
		public override int GetHashCode()
		{
			return (((13 * 7 + this.X.GetHashCode()) * 7 + this.Y.GetHashCode()) * 7 + this.Width.GetHashCode()) * 7 + this.Height.GetHashCode();
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x000243F0 File Offset: 0x000225F0
		public override string ToString()
		{
			return string.Format("X = {0} Y = {1} Width = {2} Height = {3}", new object[]
			{
				this.X,
				this.Y,
				this.Width,
				this.Height
			});
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x00024445 File Offset: 0x00022645
		// (set) Token: 0x0600092C RID: 2348 RVA: 0x00024458 File Offset: 0x00022658
		public Vector2i Location
		{
			get
			{
				return new Vector2i(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x00024474 File Offset: 0x00022674
		// (set) Token: 0x0600092E RID: 2350 RVA: 0x0002447C File Offset: 0x0002267C
		public int Left
		{
			get
			{
				return this.X;
			}
			set
			{
				int right = this.Right;
				this.X = value;
				this.Right = right;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0002449E File Offset: 0x0002269E
		// (set) Token: 0x06000930 RID: 2352 RVA: 0x000244A8 File Offset: 0x000226A8
		public int Top
		{
			get
			{
				return this.Y;
			}
			set
			{
				int bottom = this.Bottom;
				this.Y = value;
				this.Bottom = bottom;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000931 RID: 2353 RVA: 0x000244CA File Offset: 0x000226CA
		// (set) Token: 0x06000932 RID: 2354 RVA: 0x000244D9 File Offset: 0x000226D9
		public int Right
		{
			get
			{
				return this.X + this.Width;
			}
			set
			{
				this.Width = value - this.X;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x000244E9 File Offset: 0x000226E9
		// (set) Token: 0x06000934 RID: 2356 RVA: 0x000244F8 File Offset: 0x000226F8
		public int Bottom
		{
			get
			{
				return this.Y + this.Height;
			}
			set
			{
				this.Height = value - this.Y;
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00024508 File Offset: 0x00022708
		public static Rectanglei Union(Rectanglei a, Rectanglei b)
		{
			return Rectanglei.FromLTRB(Math.Min(a.Left, b.Left), Math.Min(a.Top, b.Top), Math.Max(a.Right, b.Right), Math.Max(a.Bottom, b.Bottom));
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00024568 File Offset: 0x00022768
		public static Rectanglei Intersect(Rectanglei a, Rectanglei b)
		{
			int num = Math.Max(a.X, b.X);
			int num2 = Math.Min(a.Right, b.Right);
			int num3 = Math.Max(a.Y, b.Y);
			int num4 = Math.Min(a.Bottom, b.Bottom);
			if (num2 >= num && num4 >= num3)
			{
				return new Rectanglei(num, num3, num2 - num, num4 - num3);
			}
			return Rectanglei.Empty;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x000245E0 File Offset: 0x000227E0
		public static implicit operator Rectangle(Rectanglei r)
		{
			return new Rectangle((double)r.X, (double)r.Y, (double)r.Width, (double)r.Height);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00024607 File Offset: 0x00022807
		public static implicit operator Rectanglei(Rectangle r)
		{
			return new Rectanglei((int)r.X, (int)r.Y, (int)r.Width, (int)r.Height);
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0002462E File Offset: 0x0002282E
		public static bool operator ==(Rectanglei a, Rectanglei b)
		{
			return a.Equals(b);
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00024638 File Offset: 0x00022838
		public static bool operator !=(Rectanglei a, Rectanglei b)
		{
			return !a.Equals(b);
		}
	}
}
