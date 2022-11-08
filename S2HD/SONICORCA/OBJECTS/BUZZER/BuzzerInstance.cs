using System;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.BUZZER
{
	// Token: 0x0200005A RID: 90
	public class BuzzerInstance : Badnik
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x0000F049 File Offset: 0x0000D249
		public BuzzerInstance()
		{
			base.DesignBounds = new Rectanglei(-130, -84, 260, 168);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000F070 File Offset: 0x0000D270
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._animation.Index = 0;
			this._velocityX = -4;
			this._status = BuzzerInstance.StatusType.Moving;
			this._flightDuration = 256;
			this._turnWaitDuration = 0;
			this._fireDuration = 0;
			this._firedThisRound = false;
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -64, -32, 128, 64)
			};
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000F104 File Offset: 0x0000D304
		protected override void OnUpdate()
		{
			base.OnUpdate();
			BuzzerInstance.StatusType status = this._status;
			if (status == BuzzerInstance.StatusType.Moving)
			{
				this.UpdateMoving();
				return;
			}
			if (status != BuzzerInstance.StatusType.Firing)
			{
				return;
			}
			this.UpdateFiring();
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000F134 File Offset: 0x0000D334
		private void UpdateMoving()
		{
			if (!this._firedThisRound && this.CheckForCharacter())
			{
				this._animation.Index = 2;
				this._status = BuzzerInstance.StatusType.Firing;
				this._fireDuration = 50;
				this._firedThisRound = true;
				return;
			}
			if (this._turnWaitDuration > 0)
			{
				this._turnWaitDuration--;
				if (this._turnWaitDuration == 15)
				{
					this._velocityX *= -1;
					this._animation.Index = 1;
					this._firedThisRound = false;
					return;
				}
			}
			else
			{
				this._flightDuration--;
				if (this._flightDuration > 0)
				{
					base.Position += new Vector2i(this._velocityX, 0);
					return;
				}
				this._flightDuration = 256;
				this._turnWaitDuration = 30;
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000F1FF File Offset: 0x0000D3FF
		private void UpdateFiring()
		{
			this._fireDuration--;
			if (this._fireDuration < 0)
			{
				this._status = BuzzerInstance.StatusType.Moving;
				return;
			}
			if (this._fireDuration == 20)
			{
				this.FireProjectile();
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000F230 File Offset: 0x0000D430
		private void FireProjectile()
		{
			BuzzerInstance.Projectile projectile = base.Level.ObjectManager.AddSubObject<BuzzerInstance.Projectile>(this);
			projectile.Position = new Vector2i(base.Position.X + Math.Sign(this._velocityX) * -52, base.Position.Y + 96);
			projectile.Direction = Math.Sign(this._velocityX);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000F298 File Offset: 0x0000D498
		private bool CheckForCharacter()
		{
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				if (base.Position.Y >= character.Position.Y || base.Position.Y < character.Position.Y - 1024)
				{
					return false;
				}
				double b = (double)Math.Abs(base.Position.X - character.Position.X);
				if (MathX.IsBetween(160.0, b, 192.0))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000F37C File Offset: 0x0000D57C
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000F389 File Offset: 0x0000D589
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, this._velocityX >= 0, false);
		}

		// Token: 0x04000245 RID: 581
		private const int AnimationMoving = 0;

		// Token: 0x04000246 RID: 582
		private const int AnimationTurning = 1;

		// Token: 0x04000247 RID: 583
		private const int AnimationFiring = 2;

		// Token: 0x04000248 RID: 584
		private AnimationInstance _animation;

		// Token: 0x04000249 RID: 585
		private int _velocityX;

		// Token: 0x0400024A RID: 586
		private BuzzerInstance.StatusType _status;

		// Token: 0x0400024B RID: 587
		private int _flightDuration;

		// Token: 0x0400024C RID: 588
		private int _turnWaitDuration;

		// Token: 0x0400024D RID: 589
		private int _fireDuration;

		// Token: 0x0400024E RID: 590
		private bool _firedThisRound;

		// Token: 0x020000DF RID: 223
		private enum StatusType
		{
			// Token: 0x040005F9 RID: 1529
			Moving,
			// Token: 0x040005FA RID: 1530
			Firing
		}

		// Token: 0x020000E0 RID: 224
		private class Projectile : Enemy
		{
			// Token: 0x170000DD RID: 221
			// (get) Token: 0x06000583 RID: 1411 RVA: 0x00021BD5 File Offset: 0x0001FDD5
			// (set) Token: 0x06000584 RID: 1412 RVA: 0x00021BE7 File Offset: 0x0001FDE7
			public int Direction
			{
				get
				{
					return Math.Sign(this._velocity.X);
				}
				set
				{
					this._velocity.X = 6 * Math.Sign(value);
				}
			}

			// Token: 0x06000585 RID: 1413 RVA: 0x00021BFC File Offset: 0x0001FDFC
			protected override void OnStart()
			{
				base.OnStart();
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 3);
				this._velocity = new Vector2i(6);
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -16, -16, 32, 32)
				};
			}

			// Token: 0x06000586 RID: 1414 RVA: 0x00021C5B File Offset: 0x0001FE5B
			protected override void OnUpdate()
			{
				base.OnUpdate();
				base.Position += this._velocity;
			}

			// Token: 0x06000587 RID: 1415 RVA: 0x00021C7A File Offset: 0x0001FE7A
			protected override void OnAnimate()
			{
				this._animation.Animate();
			}

			// Token: 0x06000588 RID: 1416 RVA: 0x00021C87 File Offset: 0x0001FE87
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				objectRenderer.EmitsLight = true;
				objectRenderer.Render(this._animation, this._velocity.X >= 0, false);
			}

			// Token: 0x06000589 RID: 1417 RVA: 0x0001FCB0 File Offset: 0x0001DEB0
			protected override void OnStop()
			{
				base.OnStop();
				base.FinishForever();
			}

			// Token: 0x040005FB RID: 1531
			private const int AnimationProjectile = 3;

			// Token: 0x040005FC RID: 1532
			private const int Speed = 6;

			// Token: 0x040005FD RID: 1533
			private AnimationInstance _animation;

			// Token: 0x040005FE RID: 1534
			private Vector2i _velocity;
		}
	}
}
