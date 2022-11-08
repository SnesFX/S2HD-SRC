using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.EHZPLATFORM
{
	// Token: 0x02000041 RID: 65
	public class EHZPlatformInstance : Platform
	{
		// Token: 0x0600014F RID: 335 RVA: 0x0000B276 File Offset: 0x00009476
		public EHZPlatformInstance()
		{
			base.DesignBounds = new Rectanglei(-128, -64, 256, 128);
			base.SagWhenStoodOn = true;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000B2A0 File Offset: 0x000094A0
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionVectors = new CollisionVector[]
			{
				new CollisionVector(this, new Vector2i(-128, -32), new Vector2i(128, -32), uint.MaxValue, CollisionFlags.Conveyor)
			};
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000B301 File Offset: 0x00009501
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000B30E File Offset: 0x0000950E
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x04000173 RID: 371
		private AnimationInstance _animation;
	}
}
