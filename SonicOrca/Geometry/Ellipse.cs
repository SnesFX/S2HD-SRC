using System;

namespace SonicOrca.Geometry
{
	// Token: 0x020000FE RID: 254
	public struct Ellipse : IEquatable<Ellipse>
	{
		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000899 RID: 2201 RVA: 0x00022234 File Offset: 0x00020434
		public static Ellipse Empty
		{
			get
			{
				return default(Ellipse);
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x0002224A File Offset: 0x0002044A
		// (set) Token: 0x0600089B RID: 2203 RVA: 0x00022252 File Offset: 0x00020452
		public Vector2 Position { get; set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x0600089C RID: 2204 RVA: 0x0002225B File Offset: 0x0002045B
		// (set) Token: 0x0600089D RID: 2205 RVA: 0x00022263 File Offset: 0x00020463
		public Vector2 Radius { get; set; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x0600089E RID: 2206 RVA: 0x0002226C File Offset: 0x0002046C
		public double Area
		{
			get
			{
				return 3.141592653589793 * this.Radius.X * this.Radius.Y;
			}
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x000222A0 File Offset: 0x000204A0
		public Ellipse(double x, double y, double radiusX, double radiusY)
		{
			this = default(Ellipse);
			this.Position = new Vector2(x, y);
			this.Radius = new Vector2(radiusX, radiusY);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x000222C4 File Offset: 0x000204C4
		public bool Contains(Vector2 p)
		{
			if (this.Radius.X <= 0.0 || this.Radius.Y <= 0.0)
			{
				return false;
			}
			Vector2 vector = new Vector2(p.X - this.Position.X, p.Y - this.Position.Y);
			return vector.X * vector.X / (this.Radius.X * this.Radius.X) + vector.Y * vector.Y / (this.Radius.Y * this.Radius.Y) <= 1.0;
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x000223A1 File Offset: 0x000205A1
		public override bool Equals(object obj)
		{
			return this.Equals((Ellipse)obj);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000223B0 File Offset: 0x000205B0
		public bool Equals(Ellipse other)
		{
			return other.Position.X == this.Position.X && other.Position.Y == this.Position.Y && other.Radius.X == this.Radius.X && other.Radius.Y == this.Radius.Y;
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0002243C File Offset: 0x0002063C
		public override int GetHashCode()
		{
			return (((13 * 7 + this.Position.X.GetHashCode()) * 7 + this.Position.Y.GetHashCode()) * 7 + this.Radius.X.GetHashCode()) * 7 + this.Radius.Y.GetHashCode();
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x000224B0 File Offset: 0x000206B0
		public override string ToString()
		{
			return string.Format("X = {0} Y = {1} RadiusX = {2} RadiusY = {3}", new object[]
			{
				this.Position.X,
				this.Position.Y,
				this.Radius.X,
				this.Radius.Y
			});
		}
	}
}
