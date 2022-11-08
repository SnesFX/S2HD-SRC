using System;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000164 RID: 356
	public abstract class Animal : ActiveObject
	{
		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x00037B10 File Offset: 0x00035D10
		// (set) Token: 0x06000ED8 RID: 3800 RVA: 0x00037B18 File Offset: 0x00035D18
		[StateVariable]
		public int Delay
		{
			get
			{
				return this._delay;
			}
			set
			{
				this._delay = value;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x00037B21 File Offset: 0x00035D21
		// (set) Token: 0x06000EDA RID: 3802 RVA: 0x00037B29 File Offset: 0x00035D29
		[StateVariable]
		public int Direction
		{
			get
			{
				return this._direction;
			}
			set
			{
				this._direction = value;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000EDB RID: 3803 RVA: 0x00037B32 File Offset: 0x00035D32
		// (set) Token: 0x06000EDC RID: 3804 RVA: 0x00037B3A File Offset: 0x00035D3A
		protected Vector2 JumpVelocity { get; set; }

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000EDD RID: 3805 RVA: 0x00037B43 File Offset: 0x00035D43
		// (set) Token: 0x06000EDE RID: 3806 RVA: 0x00037B4B File Offset: 0x00035D4B
		protected double JumpGravity { get; set; }

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000EDF RID: 3807 RVA: 0x00037B54 File Offset: 0x00035D54
		protected AnimationInstance AnimationInstance
		{
			get
			{
				return this._animationInstance;
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x00037B5C File Offset: 0x00035D5C
		protected Vector2 Velocity
		{
			get
			{
				return this._velocity;
			}
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x00037B64 File Offset: 0x00035D64
		public Animal(string animationGroupResourceKey)
		{
			this._animationGroupResourceKey = animationGroupResourceKey;
			this.JumpGravity = 0.375;
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x00037B8C File Offset: 0x00035D8C
		protected override void OnStart()
		{
			this._animationInstance = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath(this._animationGroupResourceKey), 0);
			this.JumpVelocity = new Vector2(Math.Abs(this.JumpVelocity.X) * (double)Math.Sign(this._direction), this.JumpVelocity.Y);
			base.Priority = ((this._delay > 0) ? -256 : 1280);
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x00037C10 File Offset: 0x00035E10
		protected override void OnUpdate()
		{
			if (this._delay > 0)
			{
				base.Priority = -256;
				this._delay--;
				if (this._delay == 0)
				{
					this._velocity = new Vector2(0.0, -16.0);
				}
				return;
			}
			base.Priority = 1280;
			base.PositionPrecise += this._velocity;
			bool flag = false;
			foreach (CollisionInfo collisionInfo in CollisionVector.GetCollisions(this, 32, uint.MaxValue))
			{
				if (!collisionInfo.Vector.IsWall && collisionInfo.Vector.Mode != CollisionMode.Bottom)
				{
					ActiveObject owner = collisionInfo.Vector.Owner;
					if (owner == null || owner.Type.Classification != ObjectClassification.Capsule)
					{
						base.PositionPrecise = new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y + collisionInfo.Shift);
						flag = true;
					}
				}
			}
			if (flag)
			{
				this._jumping = true;
				this._velocity = this.JumpVelocity;
				this._animationInstance.Index = 1;
				return;
			}
			this._velocity.Y = this._velocity.Y + (this._jumping ? this.JumpGravity : 0.875);
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x00037D80 File Offset: 0x00035F80
		protected override void OnAnimate()
		{
			if (this._delay <= 0)
			{
				this._animationInstance.Animate();
			}
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x00037D96 File Offset: 0x00035F96
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animationInstance, this._velocity.X > 0.0, false);
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x00037DC0 File Offset: 0x00035FC0
		protected override void OnStop()
		{
			base.FinishForever();
		}

		// Token: 0x04000850 RID: 2128
		private readonly string _animationGroupResourceKey;

		// Token: 0x04000851 RID: 2129
		private AnimationInstance _animationInstance;

		// Token: 0x04000852 RID: 2130
		private Vector2 _velocity;

		// Token: 0x04000853 RID: 2131
		private bool _jumping;

		// Token: 0x04000854 RID: 2132
		private int _delay;

		// Token: 0x04000855 RID: 2133
		private int _direction = -1;
	}
}
