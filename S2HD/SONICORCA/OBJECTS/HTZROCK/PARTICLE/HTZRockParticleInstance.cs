using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZROCK.PARTICLE
{
	// Token: 0x0200004F RID: 79
	public class HTZRockParticleInstance : ActiveObject
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000C450 File Offset: 0x0000A650
		// (set) Token: 0x06000196 RID: 406 RVA: 0x0000C458 File Offset: 0x0000A658
		[StateVariable]
		private Vector2 Velocity
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

		// Token: 0x06000197 RID: 407 RVA: 0x00007672 File Offset: 0x00005872
		public HTZRockParticleInstance()
		{
			base.DesignBounds = new Rectanglei(-60, -60, 120, 120);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000C464 File Offset: 0x0000A664
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("//ANIGROUP"), 1);
			this._animation.CurrentFrameIndex = base.Level.Random.Next(0, this._animation.Animation.Frames.Count);
			this._scale = base.Level.Random.NextDouble() * 0.5 + 0.5;
			base.Priority = 1512;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000C4F9 File Offset: 0x0000A6F9
		protected override void OnStop()
		{
			base.FinishForever();
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000C501 File Offset: 0x0000A701
		protected override void OnUpdate()
		{
			this._velocity.Y = this._velocity.Y + 0.5625;
			base.PositionPrecise += this._velocity;
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000C535 File Offset: 0x0000A735
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000C544 File Offset: 0x0000A744
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			using (objectRenderer.BeginMatixState())
			{
				objectRenderer.ModelMatrix *= Matrix4.CreateScale(this._scale, this._scale, 1.0);
				objectRenderer.Render(this._animation, false, false);
			}
		}

		// Token: 0x040001A5 RID: 421
		private const int AnimationRockParticle = 1;

		// Token: 0x040001A6 RID: 422
		private AnimationInstance _animation;

		// Token: 0x040001A7 RID: 423
		private Vector2 _velocity;

		// Token: 0x040001A8 RID: 424
		private double _scale;
	}
}
