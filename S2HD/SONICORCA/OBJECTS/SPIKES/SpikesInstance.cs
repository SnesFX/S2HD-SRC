using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.SPIKES
{
	// Token: 0x0200002C RID: 44
	public class SpikesInstance : ActiveObject
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00008766 File Offset: 0x00006966
		// (set) Token: 0x060000EB RID: 235 RVA: 0x0000876E File Offset: 0x0000696E
		[StateVariable]
		private SpikesInstance.SpikesDirection Direction
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

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00008777 File Offset: 0x00006977
		// (set) Token: 0x060000ED RID: 237 RVA: 0x0000877F File Offset: 0x0000697F
		[StateVariable]
		private bool Movement
		{
			get
			{
				return this._moving;
			}
			set
			{
				this._moving = value;
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00008788 File Offset: 0x00006988
		public SpikesInstance()
		{
			base.DesignBounds = new Rectanglei(-64, -64, 128, 128);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000087AC File Offset: 0x000069AC
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectangle(-64.0, -64.0, 128.0, 128.0), uint.MaxValue, (CollisionFlags)0);
			int num;
			switch (this._direction)
			{
			case SpikesInstance.SpikesDirection.Right:
				num = 2;
				this._targetDisplacement = new Vector2i(128, 0);
				this._velocity = new Vector2i(32, 0);
				goto IL_101;
			case SpikesInstance.SpikesDirection.Down:
				num = 3;
				this._targetDisplacement = new Vector2i(0, -128);
				this._velocity = new Vector2i(0, -32);
				goto IL_101;
			case SpikesInstance.SpikesDirection.Left:
				num = 0;
				this._targetDisplacement = new Vector2i(-128, 0);
				this._velocity = new Vector2i(-32, 0);
				goto IL_101;
			}
			num = 1;
			this._targetDisplacement = new Vector2i(0, 128);
			this._velocity = new Vector2i(0, 32);
			IL_101:
			base.CollisionVectors[num].Id = 1;
			base.CollisionVectors[num].Flags |= (CollisionFlags.Conveyor | CollisionFlags.Solid);
			this._movementDelay = 60;
			this._shouldBeAtTarget = true;
			base.Priority = -256;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000088FC File Offset: 0x00006AFC
		protected override void OnUpdate()
		{
			if (!this._moving)
			{
				return;
			}
			this._movementDelay--;
			if (this._movementDelay <= 0)
			{
				this._movementDelay = 60;
				this._shouldBeAtTarget = !this._shouldBeAtTarget;
				this._velocity *= -1;
				base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/SPIKESLASH"));
			}
			if (this._shouldBeAtTarget)
			{
				if (this._currentDisplacement != this._targetDisplacement)
				{
					this._currentDisplacement += this._velocity;
					base.Position += this._velocity;
					return;
				}
			}
			else if (this._currentDisplacement != default(Vector2))
			{
				this._currentDisplacement += this._velocity;
				base.Position += this._velocity;
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00008A08 File Offset: 0x00006C08
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
			ICharacter character = (ICharacter)e.ActiveObject;
			character.Hurt(Math.Sign(character.Position.X - base.Position.X), PlayerDeathCause.Spikes);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00008A66 File Offset: 0x00006C66
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00008A74 File Offset: 0x00006C74
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			using (objectRenderer.BeginMatixState())
			{
				if (this._direction != SpikesInstance.SpikesDirection.Up)
				{
					objectRenderer.ModelMatrix *= Matrix4.CreateRotationZ(1.5707963267948966 * (double)this._direction);
				}
				objectRenderer.Render(this._animation, false, false);
			}
		}

		// Token: 0x04000108 RID: 264
		private AnimationInstance _animation;

		// Token: 0x04000109 RID: 265
		private SpikesInstance.SpikesDirection _direction;

		// Token: 0x0400010A RID: 266
		private bool _moving;

		// Token: 0x0400010B RID: 267
		private Vector2i _velocity;

		// Token: 0x0400010C RID: 268
		private Vector2i _currentDisplacement;

		// Token: 0x0400010D RID: 269
		private Vector2i _targetDisplacement;

		// Token: 0x0400010E RID: 270
		private int _movementDelay;

		// Token: 0x0400010F RID: 271
		private bool _shouldBeAtTarget;

		// Token: 0x020000CD RID: 205
		private enum SpikesDirection
		{
			// Token: 0x04000592 RID: 1426
			Up,
			// Token: 0x04000593 RID: 1427
			Right,
			// Token: 0x04000594 RID: 1428
			Down,
			// Token: 0x04000595 RID: 1429
			Left
		}
	}
}
