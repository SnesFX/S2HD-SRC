using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.SPIKER
{
	// Token: 0x0200005C RID: 92
	public class SpikerInstance : Badnik
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0000F3A9 File Offset: 0x0000D5A9
		// (set) Token: 0x060001EF RID: 495 RVA: 0x0000F3B1 File Offset: 0x0000D5B1
		[StateVariable]
		private bool UpsideDown
		{
			get
			{
				return this._flipY;
			}
			set
			{
				this._flipY = value;
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000F3BA File Offset: 0x0000D5BA
		public SpikerInstance()
		{
			base.DesignBounds = new Rectanglei(-115, -165, 230, 330);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000F3E0 File Offset: 0x0000D5E0
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 2);
			this._resting = false;
			this._velocityX = 2;
			this._stateTimer = 64;
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -32, this._flipY ? -128 : 48, 64, 64)
			};
			this._spike = base.Level.ObjectManager.AddSubObject<SpikerInstance.Spike>(this);
			this._spike.Position = base.Position;
			this._spike.FlipY = this._flipY;
			this._spike.LockLifetime = true;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x0000F49C File Offset: 0x0000D69C
		protected override void Rebound(ICharacter character)
		{
			Vector2 velocity = character.Velocity;
			if (velocity.Y < 0.0)
			{
				velocity.Y += 4.0;
			}
			else if (character.Position.Y >= base.Position.Y)
			{
				velocity.Y *= -1.0;
			}
			else
			{
				velocity.Y *= -1.0;
			}
			character.Velocity = velocity;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x0000F530 File Offset: 0x0000D730
		protected override void OnUpdateEditor()
		{
			base.OnUpdateEditor();
			this._spike.Position = base.Position;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0000F54C File Offset: 0x0000D74C
		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (this._resting)
			{
				int stateTimer = this._stateTimer;
				this._stateTimer = stateTimer - 1;
				if (stateTimer <= 0)
				{
					this._resting = false;
					this._stateTimer = 64;
					this._velocityX *= -1;
				}
			}
			else
			{
				base.Position += new Vector2i(this._velocityX, 0);
				if (!this._spikeFired)
				{
					this._spike.Position += new Vector2i(this._velocityX, 0);
					this._spike._velocityX = this._velocityX;
				}
				int stateTimer = this._stateTimer;
				this._stateTimer = stateTimer - 1;
				if (stateTimer <= 0)
				{
					this._resting = true;
					this._stateTimer = 16;
				}
			}
			if (this.CheckForCharacter())
			{
				this._spike.Fire();
				this._spikeFired = true;
				this._spike.LockLifetime = false;
				this._spike._velocityX = 0;
			}
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000F64C File Offset: 0x0000D84C
		private bool CheckForCharacter()
		{
			ICharacter closestCharacterTo = base.Level.ObjectManager.GetClosestCharacterTo(base.Position);
			return closestCharacterTo != null && Math.Abs(base.Position.X - closestCharacterTo.Position.X) < 128 && Math.Abs(base.Position.Y - closestCharacterTo.Position.Y) < 384;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x0000F6D1 File Offset: 0x0000D8D1
		protected override void OnStop()
		{
			base.OnStop();
			if (!this._spikeFired)
			{
				this._spike.FinishForever();
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000F6EC File Offset: 0x0000D8EC
		protected override void OnAnimate()
		{
			if (!this._resting)
			{
				this._animation.Animate();
			}
			bool flipX = this._flipX;
			bool flag = this._velocityX > 0;
			if (flipX != flag)
			{
				if (this._animation.Index == 2 && !this._turning)
				{
					this._animation.Index = 3;
					this._animation.Cycles = 0;
					this._animation.ResetFrame();
					this._turning = true;
					return;
				}
				if (this._animation.Index == 3 && this._animation.Cycles >= 1)
				{
					this._turning = false;
					this._animation.Index = 2;
					this._animation.Cycles = 0;
					this._animation.ResetFrame();
					this._flipX = flag;
				}
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000F7B0 File Offset: 0x0000D9B0
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			using (objectRenderer.BeginMatixState())
			{
				objectRenderer.ModelMatrix *= Matrix4.CreateScale((double)(this._flipX ? -1 : 1), (double)(this._flipY ? -1 : 1), 1.0);
				if (this._animation.Index == 3)
				{
					objectRenderer.Render(this._animation, new Vector2(0.0, 8.0), true, false);
				}
				else if (this._animation.Index == 2)
				{
					if (this._animation.CurrentFrameIndex == 0)
					{
						objectRenderer.Render(this._animation, new Vector2(0.0, 0.0), false, false);
					}
					else
					{
						objectRenderer.Render(this._animation, false, false);
					}
				}
			}
		}

		// Token: 0x04000250 RID: 592
		private const int AnimationHead = 2;

		// Token: 0x04000251 RID: 593
		private const int AnimationBodyTurn = 3;

		// Token: 0x04000252 RID: 594
		private AnimationInstance _animation;

		// Token: 0x04000253 RID: 595
		private bool _flipX;

		// Token: 0x04000254 RID: 596
		private bool _flipY;

		// Token: 0x04000255 RID: 597
		private bool _turning;

		// Token: 0x04000256 RID: 598
		private int _velocityX;

		// Token: 0x04000257 RID: 599
		private bool _resting;

		// Token: 0x04000258 RID: 600
		private bool _spikeFired;

		// Token: 0x04000259 RID: 601
		private int _stateTimer;

		// Token: 0x0400025A RID: 602
		private SpikerInstance.Spike _spike;

		// Token: 0x020000E1 RID: 225
		private class Spike : Enemy
		{
			// Token: 0x170000DE RID: 222
			// (get) Token: 0x0600058B RID: 1419 RVA: 0x00021CB3 File Offset: 0x0001FEB3
			// (set) Token: 0x0600058C RID: 1420 RVA: 0x00021CBB File Offset: 0x0001FEBB
			public bool FlipX { get; set; }

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x0600058D RID: 1421 RVA: 0x00021CC4 File Offset: 0x0001FEC4
			// (set) Token: 0x0600058E RID: 1422 RVA: 0x00021CCC File Offset: 0x0001FECC
			public bool FlipY { get; set; }

			// Token: 0x0600058F RID: 1423 RVA: 0x00021CD8 File Offset: 0x0001FED8
			protected override void OnStart()
			{
				base.OnStart();
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -32, -72, 64, 144)
				};
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			}

			// Token: 0x06000590 RID: 1424 RVA: 0x00021D2E File Offset: 0x0001FF2E
			protected override void OnUpdate()
			{
				base.OnUpdate();
				if (this._fired)
				{
					base.Position += new Vector2i(0, -8 * (this.FlipY ? -1 : 1));
				}
			}

			// Token: 0x06000591 RID: 1425 RVA: 0x00021D64 File Offset: 0x0001FF64
			public void Fire()
			{
				this._animation.Index = (this.FlipX ? 6 : 1);
				this._fired = true;
			}

			// Token: 0x06000592 RID: 1426 RVA: 0x00021D84 File Offset: 0x0001FF84
			protected override void OnStop()
			{
				base.OnStop();
				if (this._fired)
				{
					base.FinishForever();
				}
			}

			// Token: 0x06000593 RID: 1427 RVA: 0x00021D9C File Offset: 0x0001FF9C
			protected override void OnAnimate()
			{
				base.OnAnimate();
				this._animation.Animate();
				bool flipX = this.FlipX;
				bool flag = this._velocityX > 0;
				if (flipX != flag)
				{
					if ((this._animation.Index == 4 || this._animation.Index == 0) && !this._turning)
					{
						if (flag)
						{
							this._animation.Index = 5;
						}
						else
						{
							this._animation.Index = 7;
						}
						this._animation.Cycles = 0;
						this._animation.ResetFrame();
						this._turning = true;
						return;
					}
					if ((this._animation.Index == 7 || this._animation.Index == 5) && this._animation.Cycles >= 1)
					{
						this._turning = false;
						this.FlipX = flag;
						if (this.FlipX)
						{
							this._animation.Index = 4;
						}
						else
						{
							this._animation.Index = 0;
						}
						this._animation.Cycles = 0;
						this._animation.ResetFrame();
					}
				}
			}

			// Token: 0x06000594 RID: 1428 RVA: 0x00021EA0 File Offset: 0x000200A0
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				if (this._animation.Index == 7 || this._animation.Index == 5)
				{
					int x = (this._animation.Index == 7) ? -2 : 2;
					objectRenderer.Render(this._animation, new Vector2i(x, 0), false, this.FlipY);
					return;
				}
				int num = 0;
				if (this._animation.Index == 0 || this._animation.Index == 4)
				{
					num = ((this._animation.Index == 0) ? 1 : -2);
				}
				objectRenderer.Render(this._animation, new Vector2((double)num, 0.0), false, this.FlipY);
			}

			// Token: 0x040005FF RID: 1535
			public const int AnimationSpikeLeft = 0;

			// Token: 0x04000600 RID: 1536
			public const int AnimationSpikeRight = 4;

			// Token: 0x04000601 RID: 1537
			private const int AnimationSpikeSpinningLeft = 1;

			// Token: 0x04000602 RID: 1538
			private const int AnimationSpikeSpinningRight = 6;

			// Token: 0x04000603 RID: 1539
			public const int AnimationSpikeTurnToRight = 5;

			// Token: 0x04000604 RID: 1540
			public const int AnimationSpikeTurnToLeft = 7;

			// Token: 0x04000605 RID: 1541
			public AnimationInstance _animation;

			// Token: 0x04000606 RID: 1542
			private bool _fired;

			// Token: 0x04000607 RID: 1543
			private bool _turning;

			// Token: 0x04000608 RID: 1544
			public int _velocityX;
		}
	}
}
