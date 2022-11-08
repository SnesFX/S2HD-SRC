using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.EHZBLOCK
{
	// Token: 0x02000043 RID: 67
	public class EHZBlockInstance : Platform
	{
		// Token: 0x06000155 RID: 341 RVA: 0x0000B352 File Offset: 0x00009552
		public EHZBlockInstance()
		{
			base.DesignBounds = new Rectanglei(-128, -192, 256, 384);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000B378 File Offset: 0x00009578
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-128, -164, 256, 356), uint.MaxValue, (CollisionFlags)0);
			base.CollisionVectors[0].Id = 1;
			base.CollisionVectors[2].Id = 1;
			base.CollisionVectors[3].Id = 1;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000B3FB File Offset: 0x000095FB
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000B408 File Offset: 0x00009608
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x04000175 RID: 373
		private AnimationInstance _animation;
	}
}
