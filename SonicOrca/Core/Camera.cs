using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x0200014D RID: 333
	public class Camera
	{
		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x000348B5 File Offset: 0x00032AB5
		// (set) Token: 0x06000DCD RID: 3533 RVA: 0x000348BD File Offset: 0x00032ABD
		public Rectangle ScreenBounds { get; set; }

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000DCE RID: 3534 RVA: 0x000348C6 File Offset: 0x00032AC6
		// (set) Token: 0x06000DCF RID: 3535 RVA: 0x000348CE File Offset: 0x00032ACE
		public ActiveObject ObjectToTrack { get; set; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x000348D7 File Offset: 0x00032AD7
		// (set) Token: 0x06000DD1 RID: 3537 RVA: 0x000348DF File Offset: 0x00032ADF
		public Vector2 Acceleration { get; set; }

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x000348E8 File Offset: 0x00032AE8
		// (set) Token: 0x06000DD3 RID: 3539 RVA: 0x000348F0 File Offset: 0x00032AF0
		public Vector2 Deceleration { get; set; }

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x000348F9 File Offset: 0x00032AF9
		// (set) Token: 0x06000DD5 RID: 3541 RVA: 0x00034901 File Offset: 0x00032B01
		public Vector2 MaxVelocity { get; set; }

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x0003490A File Offset: 0x00032B0A
		// (set) Token: 0x06000DD7 RID: 3543 RVA: 0x00034912 File Offset: 0x00032B12
		public Rectanglei Limits { get; set; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x0003491B File Offset: 0x00032B1B
		// (set) Token: 0x06000DD9 RID: 3545 RVA: 0x00034923 File Offset: 0x00032B23
		public Rectangle Bounds
		{
			get
			{
				return this._bounds;
			}
			set
			{
				this._bounds = value;
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000DDA RID: 3546 RVA: 0x0003492C File Offset: 0x00032B2C
		public Vector2 Velocity
		{
			get
			{
				return this._velocity;
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x00034934 File Offset: 0x00032B34
		public Vector2 Scale
		{
			get
			{
				return new Vector2(this.ScreenBounds.Width / this.Bounds.Width, this.ScreenBounds.Height / this.Bounds.Height);
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000DDC RID: 3548 RVA: 0x00034980 File Offset: 0x00032B80
		// (set) Token: 0x06000DDD RID: 3549 RVA: 0x00034988 File Offset: 0x00032B88
		public bool ShowDebugInformation { get; set; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000DDE RID: 3550 RVA: 0x00034991 File Offset: 0x00032B91
		// (set) Token: 0x06000DDF RID: 3551 RVA: 0x00034999 File Offset: 0x00032B99
		public bool SpyMode { get; set; }

		// Token: 0x06000DE0 RID: 3552 RVA: 0x000349A4 File Offset: 0x00032BA4
		public Camera(Level level)
		{
			this._level = level;
			this._trackBounds = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
			this._bounds = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
			this.ScreenBounds = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
			this.Acceleration = new Vector2(0.0, 0.0);
			this.Deceleration = new Vector2(0.5, 0.5);
			this._velocity = new Vector2(0.0, 0.0);
			this.MaxVelocity = new Vector2(64.0, 64.0);
			this.SetScale(1.0);
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x00034ACE File Offset: 0x00032CCE
		public virtual void Update()
		{
			if (this.SpyMode)
			{
				this.UpdateSpyMode();
				return;
			}
			this.UpdateTrackMode();
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x00034AE8 File Offset: 0x00032CE8
		public void SetScale(double value)
		{
			this._bounds.Width = this.ScreenBounds.Width / value;
			this._bounds.Height = this.ScreenBounds.Height / value;
			this._trackBounds.Width = this.Bounds.Width;
			this._trackBounds.Height = this.Bounds.Height;
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00034B60 File Offset: 0x00032D60
		public void CentreObjectToTrack()
		{
			if (this.ObjectToTrack == null)
			{
				return;
			}
			CameraProperties cameraProperties = this.ObjectToTrack.CameraProperties;
			Vector2 vector = this.ObjectToTrack.Position;
			this._trackBounds.X = vector.X - this._trackBounds.Width / 2.0;
			this._trackBounds.Y = vector.Y - this._trackBounds.Height / 2.0;
			this._bounds.X = this._trackBounds.X + cameraProperties.Offset.X;
			this._bounds.Y = this._trackBounds.Y + cameraProperties.Offset.Y;
			this.ApplyBounds();
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x00034C33 File Offset: 0x00032E33
		public void Shift(int x, int y)
		{
			this._bounds.X = this._bounds.X + (double)x;
			this._bounds.Y = this._bounds.Y + (double)y;
			this.ApplyBounds();
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00034C64 File Offset: 0x00032E64
		protected void ApplyMovement()
		{
			if (this.Acceleration.X == 0.0)
			{
				this._velocity.X = MathX.ChangeSpeed(this._velocity.X, -this.Deceleration.X);
			}
			if (this.Acceleration.Y == 0.0)
			{
				this._velocity.Y = MathX.ChangeSpeed(this._velocity.Y, -this.Deceleration.Y);
			}
			this._velocity += this.Acceleration;
			this._velocity.X = MathX.Clamp(this._velocity.X, this.MaxVelocity.X);
			this._velocity.Y = MathX.Clamp(this._velocity.Y, this.MaxVelocity.Y);
			this._bounds.X = this._bounds.X + this._velocity.X;
			this._bounds.Y = this._bounds.Y + this._velocity.Y;
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x00034D9C File Offset: 0x00032F9C
		protected void ApplyBounds()
		{
			double x = this.Bounds.X;
			double y = this.Bounds.Y;
			Rectanglei rectanglei = (this.Limits == Rectanglei.Empty) ? this._level.Bounds : this.Limits;
			this._bounds.X = Math.Max(this.Bounds.X, (double)rectanglei.X);
			this._bounds.Y = Math.Max(this.Bounds.Y, (double)rectanglei.Y);
			this._bounds.X = Math.Min(this.Bounds.Right, (double)rectanglei.Right) - this.Bounds.Width;
			this._bounds.Y = Math.Min(this.Bounds.Bottom, (double)rectanglei.Bottom) - this.Bounds.Height;
			Vector2 velocity = this.Velocity;
			if (this.Bounds.X != x)
			{
				velocity.X = 0.0;
			}
			if (this.Bounds.Y != y)
			{
				velocity.Y = 0.0;
			}
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x00034EF8 File Offset: 0x000330F8
		private void UpdateSpyMode()
		{
			this.Acceleration = new Vector2(0.0, 0.0);
			if (!this._level.DebugContext.Visible)
			{
				double x = this._level.GameContext.Current[0].DirectionLeft.X;
				double y = this._level.GameContext.Current[0].DirectionLeft.Y;
				this.Acceleration = new Vector2(x * 0.5, y * 0.5);
			}
			this.ApplyMovement();
			this.ApplyBounds();
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x00034FAC File Offset: 0x000331AC
		private void UpdateTrackMode()
		{
			this._velocity = new Vector2(0.0, 0.0);
			if (this.ObjectToTrack == null)
			{
				return;
			}
			CameraProperties cameraProperties = this.ObjectToTrack.CameraProperties;
			Rectangle box = cameraProperties.Box;
			box.X += this._trackBounds.Width / 2.0;
			box.Y += this._trackBounds.Height / 2.0;
			Vector2 vector = this.ObjectToTrack.Position;
			vector.X -= this._trackBounds.X;
			vector.Y -= this._trackBounds.Y;
			if (cameraProperties.Delay.X == 0)
			{
				if (vector.X < box.X)
				{
					this._velocity.X = vector.X - box.X;
				}
				else if (vector.X > box.Right)
				{
					this._velocity.X = vector.X - box.Right;
				}
				this._velocity.X = MathX.Clamp(this._velocity.X, cameraProperties.MaxVelocity.X);
			}
			else
			{
				cameraProperties.Delay = new Vector2i(cameraProperties.Delay.X - 1, cameraProperties.Delay.Y);
			}
			if (cameraProperties.Delay.Y == 0)
			{
				if (vector.Y < box.Y)
				{
					this._velocity.Y = vector.Y - box.Y;
				}
				else if (vector.Y > box.Bottom)
				{
					this._velocity.Y = vector.Y - box.Bottom;
				}
				this._velocity.Y = MathX.Clamp(this._velocity.Y, cameraProperties.MaxVelocity.Y);
			}
			else
			{
				cameraProperties.Delay = new Vector2i(cameraProperties.Delay.X, cameraProperties.Delay.Y - 1);
			}
			Vector2 maxVelocity = cameraProperties.MaxVelocity;
			maxVelocity.X = Math.Min(maxVelocity.X, this.MaxVelocity.X);
			maxVelocity.Y = Math.Min(maxVelocity.Y, this.MaxVelocity.Y);
			this._trackBounds.X = this._trackBounds.X + this._velocity.X;
			this._trackBounds.Y = this._trackBounds.Y + this._velocity.Y;
			if (cameraProperties.MaxVelocity.X == 0.0)
			{
				this._bounds.X = (double)this.ObjectToTrack.Position.X - this._trackBounds.Width / 2.0;
			}
			else
			{
				this._bounds.X = MathX.GoTowards(this._bounds.X, this._trackBounds.X + cameraProperties.Offset.X, maxVelocity.X);
			}
			if (cameraProperties.MaxVelocity.Y == 0.0)
			{
				this._bounds.Y = (double)this.ObjectToTrack.Position.Y - this._trackBounds.Height / 2.0;
			}
			else
			{
				this._bounds.Y = MathX.GoTowards(this._bounds.Y, this._trackBounds.Y + cameraProperties.Offset.Y, maxVelocity.Y);
			}
			this.ApplyBounds();
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x000353A8 File Offset: 0x000335A8
		public virtual void Draw(Renderer renderer)
		{
			this.DrawBounds(renderer, this.ScreenBounds, this.Bounds);
			if (this.ShowDebugInformation)
			{
				this.DrawSafeAreaGuides(renderer);
				if (this.ObjectToTrack != null && !this.SpyMode)
				{
					this.DrawTracking(renderer);
				}
				else
				{
					this.DrawCrossHair(renderer);
				}
				this.DrawPosition(renderer);
			}
			if (this.SpyMode)
			{
				this.DrawSpyCameraModeLabel(renderer);
			}
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x00006325 File Offset: 0x00004525
		protected void DrawBounds(Renderer renderer, Rectangle screenBounds, Rectangle bounds)
		{
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x00035410 File Offset: 0x00033610
		protected void DrawSafeAreaGuides(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			double num = this.ScreenBounds.Width * 0.019999999552965164;
			double num2 = Math.Min(this.ScreenBounds.Width, this.ScreenBounds.Height) / 3.0;
			Rectangle rectangle = new Rectangle(this.ScreenBounds.X + num, this.ScreenBounds.Y + num, this.ScreenBounds.Width - num * 2.0, this.ScreenBounds.Height - num * 2.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X + num2, rectangle.Y), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X, rectangle.Y + num2), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(rectangle.Right, rectangle.Y), new Vector2(rectangle.Right - num2, rectangle.Y), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(rectangle.Right, rectangle.Y), new Vector2(rectangle.Right, rectangle.Y + num2), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(rectangle.X, rectangle.Bottom), new Vector2(rectangle.X, rectangle.Bottom - num2), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(rectangle.X, rectangle.Bottom), new Vector2(rectangle.X + num2, rectangle.Bottom), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(rectangle.Right, rectangle.Bottom), new Vector2(rectangle.Right - num2, rectangle.Bottom), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(rectangle.Right, rectangle.Bottom), new Vector2(rectangle.Right, rectangle.Bottom - num2), 1.0);
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x000356A4 File Offset: 0x000338A4
		protected void DrawCrossHair(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			double num = Math.Min(this.ScreenBounds.Width, this.ScreenBounds.Height) / 3.0;
			i2dRenderer.RenderLine(Colours.White, new Vector2(this.ScreenBounds.CentreX, this.ScreenBounds.CentreY - num), new Vector2(this.ScreenBounds.CentreX, this.ScreenBounds.CentreY + num), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(this.ScreenBounds.CentreX - num, this.ScreenBounds.CentreY), new Vector2(this.ScreenBounds.CentreX + num, this.ScreenBounds.CentreY), 1.0);
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x00035798 File Offset: 0x00033998
		protected void DrawTracking(Renderer renderer)
		{
			if (this.ObjectToTrack == null)
			{
				return;
			}
			Rectangle box = this.ObjectToTrack.CameraProperties.Box;
			box.X += this._trackBounds.X - this._bounds.X + this._trackBounds.Width / 2.0;
			box.Y += this._trackBounds.Y - this._bounds.Y + this._trackBounds.Height / 2.0;
			Vector2 vector = this.ObjectToTrack.Position;
			vector.X -= this._bounds.X;
			vector.Y -= this._bounds.Y;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderRectangle(Colours.White, box, 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(vector.X, vector.Y - 16.0), new Vector2(vector.X, vector.Y + 16.0), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(vector.X - 16.0, vector.Y), new Vector2(vector.X + 16.0, vector.Y), 1.0);
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00035930 File Offset: 0x00033B30
		protected void DrawPosition(Renderer renderer)
		{
			this._level.DebugContext.DrawText(renderer, string.Format("{0:0.0}, {1:0.0}", this._bounds.Left, this._bounds.Top), FontAlignment.Left, this.ScreenBounds.Left + 8.0, this.ScreenBounds.Top + 8.0, 0.75, new int?(0));
			this._level.DebugContext.DrawText(renderer, string.Format("{0:0.0}, {1:0.0}", this._bounds.Right, this._bounds.Bottom), (FontAlignment)10, this.ScreenBounds.Right - 8.0, this.ScreenBounds.Bottom - 8.0, 0.75, new int?(0));
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x00035A38 File Offset: 0x00033C38
		protected void DrawSpyCameraModeLabel(Renderer renderer)
		{
			this._level.DebugContext.DrawText(renderer, "SPY CAMERA", FontAlignment.Right, this.ScreenBounds.Right - 8.0, this.ScreenBounds.Top + 8.0, 0.75, new int?(0));
		}

		// Token: 0x040007CD RID: 1997
		private readonly Level _level;

		// Token: 0x040007CE RID: 1998
		private Rectangle _bounds;

		// Token: 0x040007CF RID: 1999
		private Rectangle _trackBounds;

		// Token: 0x040007D0 RID: 2000
		private Vector2 _velocity;
	}
}
