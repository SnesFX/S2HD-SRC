using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZBLOCK
{
	// Token: 0x0200004B RID: 75
	public class HTZBlockInstance : Platform
	{
		// Token: 0x06000188 RID: 392 RVA: 0x0000B352 File Offset: 0x00009552
		public HTZBlockInstance()
		{
			base.DesignBounds = new Rectanglei(-128, -192, 256, 384);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000C080 File Offset: 0x0000A280
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-128, -164, 256, 356), uint.MaxValue, (CollisionFlags)0);
			base.CollisionVectors[0].Id = 1;
			base.CollisionVectors[2].Id = 1;
			base.CollisionVectors[3].Id = 1;
			base.CollisionVectors[1].Flags = CollisionFlags.Conveyor;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000C111 File Offset: 0x0000A311
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000C11E File Offset: 0x0000A31E
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x0400019B RID: 411
		private AnimationInstance _animation;
	}
}
