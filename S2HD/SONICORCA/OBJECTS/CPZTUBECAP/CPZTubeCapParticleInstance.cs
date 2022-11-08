using System;
using SonicOrca.Core;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZTUBECAP
{
	// Token: 0x0200006D RID: 109
	public class CPZTubeCapParticleInstance : ActiveObject
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600022C RID: 556 RVA: 0x000105A0 File Offset: 0x0000E7A0
		// (set) Token: 0x0600022D RID: 557 RVA: 0x000105A8 File Offset: 0x0000E7A8
		public Vector2 Velocity
		{
			get
			{
				return this._velocity;
			}
			set
			{
				this._velocity = value;
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x000105B1 File Offset: 0x0000E7B1
		public CPZTubeCapParticleInstance()
		{
			base.DesignBounds = new Rectanglei(-60, -50, 120, 101);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x000105CC File Offset: 0x0000E7CC
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 1);
			this._animation.CurrentFrameIndex = base.Level.Random.Next(0, this._animation.Animation.Frames.Count);
			base.Priority = 1512;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000C4F9 File Offset: 0x0000A6F9
		protected override void OnStop()
		{
			base.FinishForever();
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00010637 File Offset: 0x0000E837
		protected override void OnUpdate()
		{
			this._velocity.Y = this._velocity.Y + 0.5625;
			base.PositionPrecise += this._velocity;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0001066B File Offset: 0x0000E86B
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00010678 File Offset: 0x0000E878
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x04000289 RID: 649
		private const int AnimationParticle = 1;

		// Token: 0x0400028A RID: 650
		private AnimationInstance _animation;

		// Token: 0x0400028B RID: 651
		private Vector2 _velocity;
	}
}
