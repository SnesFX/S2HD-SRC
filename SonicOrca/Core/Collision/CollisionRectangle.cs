using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Collision
{
	// Token: 0x0200019A RID: 410
	public class CollisionRectangle : IBounds
	{
		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06001180 RID: 4480 RVA: 0x00045273 File Offset: 0x00043473
		public ActiveObject Owner
		{
			get
			{
				return this._owner;
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06001181 RID: 4481 RVA: 0x0004527B File Offset: 0x0004347B
		// (set) Token: 0x06001182 RID: 4482 RVA: 0x00045283 File Offset: 0x00043483
		public int Id { get; set; }

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06001183 RID: 4483 RVA: 0x0004528C File Offset: 0x0004348C
		// (set) Token: 0x06001184 RID: 4484 RVA: 0x00045294 File Offset: 0x00043494
		public Rectanglei Bounds { get; set; }

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06001185 RID: 4485 RVA: 0x000452A0 File Offset: 0x000434A0
		public Rectanglei AbsoluteBounds
		{
			get
			{
				if (this._owner != null)
				{
					return this.Bounds.OffsetBy(this.Owner.Position);
				}
				return this.Bounds;
			}
		}

		// Token: 0x06001186 RID: 4486 RVA: 0x000452D5 File Offset: 0x000434D5
		public CollisionRectangle(ActiveObject owner, int id, int x, int y, int width, int height)
		{
			this._owner = owner;
			this.Id = id;
			this.Bounds = new Rectangle((double)x, (double)y, (double)width, (double)height);
		}

		// Token: 0x06001187 RID: 4487 RVA: 0x00045308 File Offset: 0x00043508
		public void OffsetBy(Vector2i offset)
		{
			Rectangle r = this.Bounds;
			r.Location += offset;
			this.Bounds = r;
		}

		// Token: 0x06001188 RID: 4488 RVA: 0x00045348 File Offset: 0x00043548
		public bool IntersectsWith(CollisionRectangle other)
		{
			return this.AbsoluteBounds.IntersectsWith(other.AbsoluteBounds);
		}

		// Token: 0x06001189 RID: 4489 RVA: 0x0004536C File Offset: 0x0004356C
		public void Draw(Renderer renderer, Viewport viewport)
		{
			if (!viewport.Bounds.IntersectsWith(this.AbsoluteBounds))
			{
				return;
			}
			Rectangle destination = this.AbsoluteBounds.OffsetBy(viewport.Bounds.Location * -1);
			destination.X *= viewport.Scale.X;
			destination.Y *= viewport.Scale.Y;
			destination.Width *= viewport.Scale.X;
			destination.Height *= viewport.Scale.Y;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			Colour colour = new Colour(byte.MaxValue, 0, 0);
			i2dRenderer.RenderRectangle(colour, destination, 1.0);
			i2dRenderer.RenderLine(colour, new Vector2(destination.X + destination.Width / 2.0, destination.Y), new Vector2(destination.X + destination.Width / 2.0, destination.Y + destination.Height), 1.0);
			i2dRenderer.RenderLine(colour, new Vector2(destination.X, destination.Y + destination.Height / 2.0), new Vector2(destination.X + destination.Width, destination.Y + destination.Height / 2.0), 1.0);
		}

		// Token: 0x040009E5 RID: 2533
		private readonly ActiveObject _owner;
	}
}
