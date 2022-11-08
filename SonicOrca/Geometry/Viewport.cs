using System;
using SonicOrca.Graphics;

namespace SonicOrca.Geometry
{
	// Token: 0x0200010A RID: 266
	public class Viewport
	{
		// Token: 0x060009D7 RID: 2519 RVA: 0x00025A70 File Offset: 0x00023C70
		public Viewport(Rectanglei destination)
		{
			this.Bounds = new Rectangle(0.0, 0.0, (double)destination.Width, (double)destination.Height);
			this.Destination = destination;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00025ABC File Offset: 0x00023CBC
		public Viewport(Rectanglei destination, Rectanglei bounds)
		{
			this.Destination = destination;
			this.Bounds = bounds;
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00025AD2 File Offset: 0x00023CD2
		// (set) Token: 0x060009DA RID: 2522 RVA: 0x00025ADA File Offset: 0x00023CDA
		public Rectanglei Bounds
		{
			get
			{
				return this._bounds;
			}
			set
			{
				this._bounds = value;
				this.CalculateScale();
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x00025AE9 File Offset: 0x00023CE9
		// (set) Token: 0x060009DC RID: 2524 RVA: 0x00025AF1 File Offset: 0x00023CF1
		public Rectanglei Destination
		{
			get
			{
				return this._destination;
			}
			set
			{
				this._destination = value;
				this.CalculateScale();
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x00025B00 File Offset: 0x00023D00
		public Vector2 Scale
		{
			get
			{
				return this._scale;
			}
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00025B08 File Offset: 0x00023D08
		private void CalculateScale()
		{
			this._scale = new Vector2((double)this.Destination.Width / (double)this.Bounds.Width, (double)this.Destination.Height / (double)this.Bounds.Height);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x00025B5E File Offset: 0x00023D5E
		public Vector2i GetAbsolutePosition(Vector2i position)
		{
			return this.GetAbsolutePosition(position.X, position.Y);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00025B74 File Offset: 0x00023D74
		public Vector2i GetAbsolutePosition(int x, int y)
		{
			Vector2 scale = this.Scale;
			return new Vector2i(this.Bounds.X + (int)((double)x * scale.X), this.Bounds.Y + (int)((double)y * scale.Y));
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00025BC1 File Offset: 0x00023DC1
		public Vector2i GetRelativePosition(Vector2i position)
		{
			return this.GetRelativePosition(position.X, position.Y);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00025BD8 File Offset: 0x00023DD8
		public Vector2i GetRelativePosition(int x, int y)
		{
			Vector2 scale = this.Scale;
			return new Vector2i((int)((double)(x - this.Bounds.X) / scale.X), (int)((double)(y - this.Bounds.Y) / scale.Y));
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00025C28 File Offset: 0x00023E28
		public IDisposable ApplyRendererState(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IDisposable result = i2dRenderer.BeginMatixState();
			i2dRenderer.ClipRectangle = this.Destination;
			Vector2 scale = this.Scale;
			i2dRenderer.ModelMatrix = Matrix4.CreateTranslation((double)this.Destination.X, (double)this.Destination.Y, 0.0) * Matrix4.CreateScale(scale.X, scale.Y, 1.0);
			return result;
		}

		// Token: 0x0400057E RID: 1406
		private Rectanglei _bounds;

		// Token: 0x0400057F RID: 1407
		private Rectanglei _destination;

		// Token: 0x04000580 RID: 1408
		private Vector2 _scale;
	}
}
