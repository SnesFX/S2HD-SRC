using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.SPRING
{
	// Token: 0x02000035 RID: 53
	public class SpringInstance : ActiveObject
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00009AAC File Offset: 0x00007CAC
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00009AB4 File Offset: 0x00007CB4
		[StateVariable]
		private SpringDirection Direction
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

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00009ABD File Offset: 0x00007CBD
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00009AC5 File Offset: 0x00007CC5
		[StateVariable]
		private int Strength
		{
			get
			{
				return this._strength;
			}
			set
			{
				this._strength = value;
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00009ACE File Offset: 0x00007CCE
		public SpringInstance()
		{
			base.DesignBounds = new Rectanglei(-101, -104, 202, 208);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00009B00 File Offset: 0x00007D00
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._animation.Index = ((this._strength >= 52) ? 0 : 2);
			if (this._direction % SpringDirection.Right == SpringDirection.UpRight)
			{
				this._animation.Index += 4;
			}
			this._bounceAnimationIndex = this._animation.Index + 1;
			switch (this._direction)
			{
			case SpringDirection.Up:
				base.CollisionVectors = new CollisionVector[]
				{
					new CollisionVector(this, new Vector2i(-64, 64), new Vector2i(-64, 8), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(-64, 8), new Vector2i(-56, 0), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(-56, 0), new Vector2i(56, 0), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(56, 0), new Vector2i(64, 8), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(64, 8), new Vector2i(64, 64), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(-64, 64), new Vector2i(64, 64), uint.MaxValue, (CollisionFlags)0)
				};
				base.CollisionVectors[1].Id = 1;
				base.CollisionVectors[2].Id = 1;
				base.CollisionVectors[3].Id = 1;
				this._bounceVelocity = new Vector2(0.0, (double)(-(double)this._strength));
				break;
			case SpringDirection.UpRight:
				base.CollisionVectors = new CollisionVector[]
				{
					new CollisionVector(this, new Vector2i(-48, -48), new Vector2i(48, 48), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(-48, -84), new Vector2i(-48, -48), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(-84, -84), new Vector2i(-48, -84), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(-84, 80), new Vector2i(-84, -48), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(48, 80), new Vector2i(-84, 80), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(48, 48), new Vector2i(48, 80), uint.MaxValue, (CollisionFlags)0)
				};
				base.CollisionVectors[0].Id = 1;
				base.CollisionVectors[1].Id = 1;
				base.CollisionVectors[2].Id = 1;
				base.CollisionVectors[5].Id = 1;
				this._bounceVelocity = new Vector2((double)this._strength, (double)(-(double)this._strength));
				break;
			case SpringDirection.Right:
				base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectangle(-64.0, -60.0, 64.0, 128.0), uint.MaxValue, (CollisionFlags)0);
				base.CollisionVectors[2].Id = 1;
				this._bounceVelocity = new Vector2((double)this._strength, 0.0);
				break;
			case SpringDirection.Down:
				base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectangle(-64.0, -69.0, 128.0, 64.0), uint.MaxValue, (CollisionFlags)0);
				base.CollisionVectors[3].Id = 1;
				this._bounceVelocity = new Vector2(0.0, (double)this._strength);
				break;
			case SpringDirection.Left:
				base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectangle(5.0, -64.0, 64.0, 128.0), uint.MaxValue, (CollisionFlags)0);
				base.CollisionVectors[0].Id = 1;
				this._bounceVelocity = new Vector2((double)(-(double)this._strength), 0.0);
				break;
			case SpringDirection.UpLeft:
				base.CollisionVectors = new CollisionVector[]
				{
					new CollisionVector(this, new Vector2i(-48, 48), new Vector2i(48, -48), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(48, -48), new Vector2i(84, -48), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(84, -48), new Vector2i(84, 80), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(84, 80), new Vector2i(-48, 80), uint.MaxValue, (CollisionFlags)0),
					new CollisionVector(this, new Vector2i(-48, 80), new Vector2i(-48, 48), uint.MaxValue, (CollisionFlags)0)
				};
				base.CollisionVectors[0].Id = 1;
				base.CollisionVectors[1].Id = 1;
				this._bounceVelocity = new Vector2((double)(-(double)this._strength), (double)(-(double)this._strength));
				break;
			}
			base.Priority = -256;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00009FD8 File Offset: 0x000081D8
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.Id != 1)
			{
				return;
			}
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			Character character = (Character)e.ActiveObject;
			SpringDirection direction = this.Direction;
			if (direction <= SpringDirection.UpRight || direction == SpringDirection.UpLeft)
			{
				character.LeaveGround();
			}
			if (this._direction == SpringDirection.Up || this._direction == SpringDirection.UpRight || this._direction == SpringDirection.UpLeft)
			{
				character.IsAirborne = true;
				character.IsSpinball = false;
				if (this._direction == SpringDirection.Up)
				{
					character.TumbleAngle = 0.0;
					character.TumbleTurns = 1;
					character.GroundVelocity = 1.0;
				}
				else
				{
					character.Animation.Index = 12;
				}
			}
			if (character.IsAirborne)
			{
				character.Velocity = new Vector2((this._bounceVelocity.X != 0.0) ? this._bounceVelocity.X : character.Velocity.X, (this._bounceVelocity.Y != 0.0) ? this._bounceVelocity.Y : character.Velocity.Y);
				character.IsHurt = false;
			}
			else
			{
				character.GroundVelocity = this._bounceVelocity.X;
				character.Facing = Math.Sign(this._bounceVelocity.X);
				character.SlopeLockTicks = Math.Max(16, character.SlopeLockTicks);
				character.IsPushing = false;
			}
			this._animation.Index = this._bounceAnimationIndex;
			e.MaintainVelocity = true;
			base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/SPRING"));
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000A180 File Offset: 0x00008380
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000A190 File Offset: 0x00008390
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			using (objectRenderer.BeginMatixState())
			{
				switch (this._direction)
				{
				case SpringDirection.Up:
					objectRenderer.Render(this._animation, false, false);
					break;
				case SpringDirection.UpRight:
					objectRenderer.Render(this._animation, false, false);
					break;
				case SpringDirection.Right:
					objectRenderer.ModelMatrix *= Matrix4.CreateRotationZ(1.5707963267948966);
					objectRenderer.Render(this._animation, true, false);
					break;
				case SpringDirection.DownRight:
					objectRenderer.Render(this._animation, false, false);
					break;
				case SpringDirection.Down:
					objectRenderer.Render(this._animation, false, true);
					break;
				case SpringDirection.DownLeft:
					objectRenderer.Render(this._animation, false, true);
					break;
				case SpringDirection.Left:
					objectRenderer.ModelMatrix *= Matrix4.CreateRotationZ(1.5707963267948966);
					objectRenderer.Render(this._animation, true, true);
					break;
				case SpringDirection.UpLeft:
					objectRenderer.Render(this._animation, true, false);
					break;
				}
			}
		}

		// Token: 0x0400014B RID: 331
		private SpringDirection _direction = SpringDirection.Right;

		// Token: 0x0400014C RID: 332
		private int _strength = 40;

		// Token: 0x0400014D RID: 333
		private AnimationInstance _animation;

		// Token: 0x0400014E RID: 334
		private int _bounceAnimationIndex;

		// Token: 0x0400014F RID: 335
		private Vector2 _bounceVelocity;
	}
}
