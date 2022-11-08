using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZVINELIFT
{
	// Token: 0x02000045 RID: 69
	public class HTZVineLiftInstance : ActiveObject
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600015A RID: 346 RVA: 0x0000B41D File Offset: 0x0000961D
		// (set) Token: 0x0600015B RID: 347 RVA: 0x0000B425 File Offset: 0x00009625
		[StateVariable]
		private int Duration
		{
			get
			{
				return this._duration;
			}
			set
			{
				this._duration = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600015C RID: 348 RVA: 0x0000B42E File Offset: 0x0000962E
		// (set) Token: 0x0600015D RID: 349 RVA: 0x0000B436 File Offset: 0x00009636
		[StateVariable]
		private HTZVineLiftInstance.LiftDirection Direction
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

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600015E RID: 350 RVA: 0x0000B43F File Offset: 0x0000963F
		// (set) Token: 0x0600015F RID: 351 RVA: 0x0000B447 File Offset: 0x00009647
		[StateVariable]
		private bool Outdoors
		{
			get
			{
				return this._outdoors;
			}
			set
			{
				this._outdoors = value;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000B450 File Offset: 0x00009650
		public HTZVineLiftInstance()
		{
			base.DesignBounds = new Rectanglei(-132, -41, 264, 82);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000B480 File Offset: 0x00009680
		protected override void OnStart()
		{
			base.OnStart();
			this._velocity = new Vector2(8.0, 4.0);
			if (this._direction == HTZVineLiftInstance.LiftDirection.Left)
			{
				this._velocity.X = this._velocity.X * -1.0;
			}
			base.Priority = 1256;
			int index = 5;
			if (this._outdoors)
			{
				index = 0;
			}
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), index);
			this._platform = base.Level.ObjectManager.AddSubObject<HTZVineLiftInstance.LiftPlatform>(this);
			this._platform.Position = base.Position;
			this._platform.LockLifetime = true;
			if (this.Direction == HTZVineLiftInstance.LiftDirection.Left)
			{
				this._platform.Position = new Vector2i(base.Position.X - 16, base.Position.Y);
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000B577 File Offset: 0x00009777
		protected override void OnUpdateEditor()
		{
			this._platform.Position = base.Position;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000B58C File Offset: 0x0000978C
		protected override void OnUpdatePrepare()
		{
			switch (this._state)
			{
			case HTZVineLiftInstance.State.Waiting:
				if (this._platform.Activated)
				{
					this._state = HTZVineLiftInstance.State.Moving;
					return;
				}
				break;
			case HTZVineLiftInstance.State.Moving:
				this._duration--;
				if (this._duration == 0)
				{
					this._state = HTZVineLiftInstance.State.Falling;
					this._velocity = default(Vector2);
					this._platform.Velocity = default(Vector2);
					if (this.Direction == HTZVineLiftInstance.LiftDirection.Left)
					{
						this._platform.Position = new Vector2i(this._platform.Position.X - 16, this._platform.Position.Y);
					}
					this._platform.BeginDetach();
					return;
				}
				this._platform.Velocity = this._velocity;
				return;
			case HTZVineLiftInstance.State.Falling:
			{
				int index = 6;
				if (this._outdoors)
				{
					index = 1;
				}
				this._animation.Index = index;
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000B67F File Offset: 0x0000987F
		protected override void OnUpdate()
		{
			if (this._state == HTZVineLiftInstance.State.Moving)
			{
				base.MovePrecise(this._velocity);
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000B696 File Offset: 0x00009896
		protected override void OnStop()
		{
			if (this._state != HTZVineLiftInstance.State.Falling)
			{
				this._platform.FinishForever();
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000B6AC File Offset: 0x000098AC
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000B6BC File Offset: 0x000098BC
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			bool flipX = this._direction == HTZVineLiftInstance.LiftDirection.Left;
			objectRenderer.Render(this._animation, new Vector2i(-16, -8), flipX, false);
		}

		// Token: 0x04000178 RID: 376
		private const int VerticalVinesOutdoorsAnimationIndex = 0;

		// Token: 0x04000179 RID: 377
		private const int VerticalVinesDetachOutdoorsAnimationIndex = 1;

		// Token: 0x0400017A RID: 378
		private const int VerticalVinesInsideAnimationIndex = 5;

		// Token: 0x0400017B RID: 379
		private const int VerticalVinesDetachInsideAnimationIndex = 6;

		// Token: 0x0400017C RID: 380
		private AnimationInstance _animation;

		// Token: 0x0400017D RID: 381
		private Vector2 _velocity;

		// Token: 0x0400017E RID: 382
		private int _duration = 60;

		// Token: 0x0400017F RID: 383
		private HTZVineLiftInstance.LiftDirection _direction;

		// Token: 0x04000180 RID: 384
		private bool _outdoors = true;

		// Token: 0x04000181 RID: 385
		private HTZVineLiftInstance.State _state;

		// Token: 0x04000182 RID: 386
		private HTZVineLiftInstance.LiftPlatform _platform;

		// Token: 0x020000D2 RID: 210
		private enum State
		{
			// Token: 0x040005AA RID: 1450
			Waiting,
			// Token: 0x040005AB RID: 1451
			Moving,
			// Token: 0x040005AC RID: 1452
			Falling
		}

		// Token: 0x020000D3 RID: 211
		private enum LiftDirection
		{
			// Token: 0x040005AE RID: 1454
			Left,
			// Token: 0x040005AF RID: 1455
			Right
		}

		// Token: 0x020000D4 RID: 212
		private class LiftPlatform : ActiveObject, IPlatform, IActiveObject
		{
			// Token: 0x170000C3 RID: 195
			// (get) Token: 0x06000511 RID: 1297 RVA: 0x0002027F File Offset: 0x0001E47F
			// (set) Token: 0x06000512 RID: 1298 RVA: 0x00020287 File Offset: 0x0001E487
			public bool Activated { get; set; }

			// Token: 0x170000C4 RID: 196
			// (get) Token: 0x06000513 RID: 1299 RVA: 0x00020290 File Offset: 0x0001E490
			// (set) Token: 0x06000514 RID: 1300 RVA: 0x00020298 File Offset: 0x0001E498
			public bool Falling { get; set; }

			// Token: 0x170000C5 RID: 197
			// (get) Token: 0x06000515 RID: 1301 RVA: 0x000202A1 File Offset: 0x0001E4A1
			// (set) Token: 0x06000516 RID: 1302 RVA: 0x000202A9 File Offset: 0x0001E4A9
			public Vector2 Velocity { get; set; }

			// Token: 0x06000517 RID: 1303 RVA: 0x000202B4 File Offset: 0x0001E4B4
			protected override void OnStart()
			{
				base.CollisionVectors = new CollisionVector[]
				{
					new CollisionVector(this, new Vector2i(-132, 17), new Vector2i(132, 17), uint.MaxValue, CollisionFlags.Conveyor)
				};
				base.Priority = 1256;
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 4);
			}

			// Token: 0x06000518 RID: 1304 RVA: 0x00020320 File Offset: 0x0001E520
			protected override void OnUpdatePrepare()
			{
				if (this.Falling)
				{
					if (this._fallingTicks < 6)
					{
						int num = HTZVineLiftInstance.LiftPlatform.FallElasticYOffsets[this._fallingTicks];
						Vector2i fallingOriginPosition = this._fallingOriginPosition;
						fallingOriginPosition.Y += num;
						this.Velocity = fallingOriginPosition - base.PositionPrecise;
						return;
					}
					this.Velocity += new Vector2(0.0, 0.875);
				}
			}

			// Token: 0x06000519 RID: 1305 RVA: 0x000203A4 File Offset: 0x0001E5A4
			protected override void OnUpdate()
			{
				if (!this.Activated && base.Level.ObjectManager.IsCharacterStandingOn(base.CollisionVectors[0]))
				{
					this.Activated = true;
				}
				if (this.Falling)
				{
					this._fallingTicks++;
				}
				else if (this.Activated && base.Level.Ticks % 16 == 0)
				{
					base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/VINELIFT"));
				}
				base.MovePrecise(this.Velocity);
			}

			// Token: 0x0600051A RID: 1306 RVA: 0x00020437 File Offset: 0x0001E637
			protected override void OnStop()
			{
				if (this.Falling)
				{
					base.FinishForever();
				}
			}

			// Token: 0x0600051B RID: 1307 RVA: 0x00020447 File Offset: 0x0001E647
			protected override void OnAnimate()
			{
				this._animation.Animate();
			}

			// Token: 0x0600051C RID: 1308 RVA: 0x00020454 File Offset: 0x0001E654
			public void BeginDetach()
			{
				this.Falling = true;
				base.LockLifetime = false;
				this._fallingOriginPosition = base.Position;
			}

			// Token: 0x0600051D RID: 1309 RVA: 0x00020470 File Offset: 0x0001E670
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				if (this.Falling && this._fallingTicks >= 7)
				{
					renderer.GetObjectRenderer().Render(this._animation, new Vector2i(8, 13), false, false);
				}
			}

			// Token: 0x040005B0 RID: 1456
			private const int PlatformAnimationIndex = 4;

			// Token: 0x040005B1 RID: 1457
			private const double Gravity = 0.875;

			// Token: 0x040005B2 RID: 1458
			private static readonly int[] FallElasticYOffsets = new int[]
			{
				0,
				20,
				40,
				40,
				60,
				60
			};

			// Token: 0x040005B3 RID: 1459
			private AnimationInstance _animation;

			// Token: 0x040005B4 RID: 1460
			private int _fallingTicks;

			// Token: 0x040005B5 RID: 1461
			private Vector2i _fallingOriginPosition;
		}
	}
}
