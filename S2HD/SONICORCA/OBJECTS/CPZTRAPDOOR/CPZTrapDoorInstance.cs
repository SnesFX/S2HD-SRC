using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZTRAPDOOR
{
	// Token: 0x0200007D RID: 125
	public class CPZTrapDoorInstance : ActiveObject
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0001247D File Offset: 0x0001067D
		// (set) Token: 0x06000283 RID: 643 RVA: 0x00012485 File Offset: 0x00010685
		[StateVariable]
		private int TimeOffset
		{
			get
			{
				return this._timeOffset;
			}
			set
			{
				this._timeOffset = value;
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00008788 File Offset: 0x00006988
		public CPZTrapDoorInstance()
		{
			base.DesignBounds = new Rectanglei(-64, -64, 128, 128);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00012490 File Offset: 0x00010690
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._closeAnimationLength = this._animation.AnimationGroup[3].Duration;
			int num = (base.Level.Ticks + this._timeOffset) % 256;
			this._open = (num >= 128);
			if (num >= 256 - this._closeAnimationLength)
			{
				this._animation.Index = 3;
				this._animation.Seek(num - (256 - this._closeAnimationLength));
			}
			else if (num >= 128)
			{
				this._animation.Index = 2;
				this._animation.Seek(num - 128);
			}
			base.CollisionVectors = new CollisionVector[]
			{
				new CollisionVector(this, new Vector2i(-64, -64), new Vector2i(64, -64), uint.MaxValue, (CollisionFlags)0)
			};
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0001258C File Offset: 0x0001078C
		protected override void OnUpdate()
		{
			int num = (base.Level.Ticks + this._timeOffset) % 256;
			this._open = (num >= 128);
			if (num == 128)
			{
				this._animation.Index = 2;
			}
			else if (num == 256 - this._closeAnimationLength)
			{
				this._animation.Index = 3;
			}
			if (this._open)
			{
				foreach (CollisionVector collisionVector in base.CollisionVectors)
				{
					if (!collisionVector.Flags.HasFlag(CollisionFlags.Ignore))
					{
						collisionVector.Flags |= CollisionFlags.Ignore;
					}
				}
				return;
			}
			foreach (CollisionVector collisionVector2 in base.CollisionVectors)
			{
				if (collisionVector2.Flags.HasFlag(CollisionFlags.Ignore))
				{
					collisionVector2.Flags &= ~CollisionFlags.Ignore;
				}
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0001268E File Offset: 0x0001088E
		protected override void OnCollision(CollisionEvent e)
		{
			base.OnCollision(e);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00012697 File Offset: 0x00010897
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000126A4 File Offset: 0x000108A4
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x040002D8 RID: 728
		private const int AnimationClosed = 0;

		// Token: 0x040002D9 RID: 729
		private const int AnimationOpen = 1;

		// Token: 0x040002DA RID: 730
		private const int AnimationClosedToOpen = 2;

		// Token: 0x040002DB RID: 731
		private const int AnimationOpenToClosed = 3;

		// Token: 0x040002DC RID: 732
		private AnimationInstance _animation;

		// Token: 0x040002DD RID: 733
		private int _closeAnimationLength;

		// Token: 0x040002DE RID: 734
		private int _timeOffset;

		// Token: 0x040002DF RID: 735
		private bool _open;
	}
}
