using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.MASHER
{
	// Token: 0x0200001D RID: 29
	public class MasherInstance : Badnik
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x0000741D File Offset: 0x0000561D
		public MasherInstance()
		{
			base.DesignBounds = new Rectanglei(-51, -76, 102, 152);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000743C File Offset: 0x0000563C
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -48, -64, 96, 128)
			};
			this._initialY = (double)base.Position.Y;
			this._velocityY = -1.5625;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000074B8 File Offset: 0x000056B8
		protected override void OnUpdate()
		{
			base.OnUpdate();
			base.PositionPrecise += new Vector2(0.0, this._velocityY);
			this._velocityY += 0.375;
			if ((double)base.Position.Y > this._initialY)
			{
				base.PositionPrecise = new Vector2((double)base.Position.X, this._initialY);
				this._velocityY = -20.0;
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000754C File Offset: 0x0000574C
		protected override void OnAnimate()
		{
			this._animation.Index = ((this._velocityY >= 0.0) ? 0 : 1);
			this._animation.Animate();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00007579 File Offset: 0x00005779
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x040000B8 RID: 184
		private const double InitialVelocity = -1.5625;

		// Token: 0x040000B9 RID: 185
		private const double LaunchVelocity = -20.0;

		// Token: 0x040000BA RID: 186
		private const double Acceleration = 0.375;

		// Token: 0x040000BB RID: 187
		private const int AnimationNormal = 0;

		// Token: 0x040000BC RID: 188
		private const int AnimationMunching = 1;

		// Token: 0x040000BD RID: 189
		private AnimationInstance _animation;

		// Token: 0x040000BE RID: 190
		private double _initialY;

		// Token: 0x040000BF RID: 191
		private double _velocityY;
	}
}
