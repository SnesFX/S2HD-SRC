using System;

namespace SonicOrca.Geometry
{
	// Token: 0x02000102 RID: 258
	public struct Rectangle : IEquatable<Rectangle>
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x00023A38 File Offset: 0x00021C38
		public static Rectangle Empty
		{
			get
			{
				return default(Rectangle);
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x00023A4E File Offset: 0x00021C4E
		// (set) Token: 0x060008E3 RID: 2275 RVA: 0x00023A56 File Offset: 0x00021C56
		public double X { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x00023A5F File Offset: 0x00021C5F
		// (set) Token: 0x060008E5 RID: 2277 RVA: 0x00023A67 File Offset: 0x00021C67
		public double Y { get; set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x00023A70 File Offset: 0x00021C70
		// (set) Token: 0x060008E7 RID: 2279 RVA: 0x00023A78 File Offset: 0x00021C78
		public double Width { get; set; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060008E8 RID: 2280 RVA: 0x00023A81 File Offset: 0x00021C81
		// (set) Token: 0x060008E9 RID: 2281 RVA: 0x00023A89 File Offset: 0x00021C89
		public double Height { get; set; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060008EA RID: 2282 RVA: 0x00023A92 File Offset: 0x00021C92
		public double Area
		{
			get
			{
				return this.Width * this.Height;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x00023AA1 File Offset: 0x00021CA1
		public Vector2 TopLeft
		{
			get
			{
				return new Vector2(this.Left, this.Top);
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x00023AB4 File Offset: 0x00021CB4
		public Vector2 TopRight
		{
			get
			{
				return new Vector2(this.Right, this.Top);
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x00023AC7 File Offset: 0x00021CC7
		public Vector2 BottomLeft
		{
			get
			{
				return new Vector2(this.Left, this.Bottom);
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x00023ADA File Offset: 0x00021CDA
		public Vector2 BottomRight
		{
			get
			{
				return new Vector2(this.Right, this.Bottom);
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x00023AED File Offset: 0x00021CED
		public Vector2 Centre
		{
			get
			{
				return new Vector2(this.Left + this.Width / 2.0, this.Top + this.Height / 2.0);
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060008F0 RID: 2288 RVA: 0x00023B22 File Offset: 0x00021D22
		public Size Size
		{
			get
			{
				return new Size(this.Width, this.Height);
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00023B35 File Offset: 0x00021D35
		public static Rectangle FromLTRB(double left, double top, double right, double bottom)
		{
			return new Rectangle(left, top, right - left, bottom - top);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00023B44 File Offset: 0x00021D44
		public Rectangle(double x, double y, double width, double height)
		{
			this = default(Rectangle);
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00023B6A File Offset: 0x00021D6A
		public bool Contains(Vector2 p)
		{
			return p.X > this.X && p.Y > this.Y && p.X < this.Right && p.Y < this.Bottom;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00023BAC File Offset: 0x00021DAC
		public bool ContainsOrOverlaps(Vector2 p)
		{
			return p.X >= this.Top && p.Y >= this.Left && p.X <= this.Right && p.Y <= this.Bottom;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00023BFC File Offset: 0x00021DFC
		public bool Contains(Rectangle rect)
		{
			return rect.X >= this.X && rect.Y >= this.Y && rect.Right <= this.Right && rect.Bottom <= this.Bottom;
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00023C4C File Offset: 0x00021E4C
		public bool IntersectsWith(Rectangle rect)
		{
			return rect.X <= this.Right && rect.Right >= this.X && rect.Y <= this.Bottom && rect.Bottom >= this.Y;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00023C9C File Offset: 0x00021E9C
		public Rectangle Inflate(Vector2 amount)
		{
			return new Rectangle(this.X - amount.X, this.Y - amount.Y, this.Width + amount.X * 2.0, this.Height + amount.Y * 2.0);
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00023CFA File Offset: 0x00021EFA
		public Rectangle OffsetBy(Vector2 amount)
		{
			return new Rectangle(this.X + amount.X, this.Y + amount.Y, this.Width, this.Height);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00023D29 File Offset: 0x00021F29
		public override bool Equals(object obj)
		{
			return this.Equals((Rectangle)obj);
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00023D37 File Offset: 0x00021F37
		public bool Equals(Rectangle other)
		{
			return other.X == this.X && other.Y == this.Y && other.Width == this.Width && other.Height == this.Height;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00023D78 File Offset: 0x00021F78
		public override int GetHashCode()
		{
			return (((13 * 7 + this.X.GetHashCode()) * 7 + this.Y.GetHashCode()) * 7 + this.Width.GetHashCode()) * 7 + this.Height.GetHashCode();
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00023DCC File Offset: 0x00021FCC
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

		// Token: 0x060008FD RID: 2301 RVA: 0x00023E21 File Offset: 0x00022021
		public static Rectangle operator +(Rectangle rectangle, Vector2 offset)
		{
			rectangle.X += offset.X;
			rectangle.Y += offset.Y;
			return rectangle;
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00023E4E File Offset: 0x0002204E
		public static Rectangle operator -(Rectangle rectangle, Vector2 offset)
		{
			rectangle.X -= offset.X;
			rectangle.Y -= offset.Y;
			return rectangle;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00023E7B File Offset: 0x0002207B
		public static bool operator ==(Rectangle a, Rectangle b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00023E85 File Offset: 0x00022085
		public static bool operator !=(Rectangle a, Rectangle b)
		{
			return !a.Equals(b);
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x00023E92 File Offset: 0x00022092
		// (set) Token: 0x06000902 RID: 2306 RVA: 0x00023EA5 File Offset: 0x000220A5
		public Vector2 Location
		{
			get
			{
				return new Vector2(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x00023EC1 File Offset: 0x000220C1
		// (set) Token: 0x06000904 RID: 2308 RVA: 0x00023ECC File Offset: 0x000220CC
		public double Left
		{
			get
			{
				return this.X;
			}
			set
			{
				double right = this.Right;
				this.X = value;
				this.Right = right;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x00023EEE File Offset: 0x000220EE
		// (set) Token: 0x06000906 RID: 2310 RVA: 0x00023EF8 File Offset: 0x000220F8
		public double Top
		{
			get
			{
				return this.Y;
			}
			set
			{
				double bottom = this.Bottom;
				this.Y = value;
				this.Bottom = bottom;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x00023F1A File Offset: 0x0002211A
		// (set) Token: 0x06000908 RID: 2312 RVA: 0x00023F29 File Offset: 0x00022129
		public double Right
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

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x00023F39 File Offset: 0x00022139
		// (set) Token: 0x0600090A RID: 2314 RVA: 0x00023F48 File Offset: 0x00022148
		public double Bottom
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

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x00023F58 File Offset: 0x00022158
		public double CentreX
		{
			get
			{
				return this.X + this.Width / 2.0;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x00023F71 File Offset: 0x00022171
		public double CentreY
		{
			get
			{
				return this.Y + this.Height / 2.0;
			}
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00023F8C File Offset: 0x0002218C
		public static Rectangle Intersect(Rectangle a, Rectangle b)
		{
			double num = Math.Max(a.X, b.X);
			double num2 = Math.Min(a.Right, b.Right);
			double num3 = Math.Max(a.Y, b.Y);
			double num4 = Math.Min(a.Bottom, b.Bottom);
			if (num2 >= num && num4 >= num3)
			{
				return new Rectangle(num, num3, num2 - num, num4 - num3);
			}
			return Rectangle.Empty;
		}
	}
}
