using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZPLATFORM
{
	// Token: 0x0200006F RID: 111
	public class HTZPlatformInstance : Platform
	{
		// Token: 0x06000236 RID: 566 RVA: 0x0000B276 File Offset: 0x00009476
		public HTZPlatformInstance()
		{
			base.DesignBounds = new Rectanglei(-128, -64, 256, 128);
			base.SagWhenStoodOn = true;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000106C0 File Offset: 0x0000E8C0
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionVectors = new CollisionVector[]
			{
				new CollisionVector(this, new Vector2i(-128, -32), new Vector2i(128, -32), uint.MaxValue, CollisionFlags.Conveyor)
			};
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00010721 File Offset: 0x0000E921
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0001072E File Offset: 0x0000E92E
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x0400028D RID: 653
		private AnimationInstance _animation;
	}
}
