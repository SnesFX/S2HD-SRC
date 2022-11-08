using System;
using System.Collections.Generic;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.COCONUTS
{
	// Token: 0x0200002A RID: 42
	public class CoconutsInstance : Badnik
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00008332 File Offset: 0x00006532
		public CoconutsInstance()
		{
			base.DesignBounds = new Rectanglei(-96, -100, 192, 200);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00008354 File Offset: 0x00006554
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._animation.Index = 0;
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -48, -64, 96, 128)
			};
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000083B8 File Offset: 0x000065B8
		protected override void OnUpdate()
		{
			base.OnUpdate();
			switch (this._state)
			{
			case CoconutsInstance.StateType.Resting:
				this.UpdateResting();
				return;
			case CoconutsInstance.StateType.Climbing:
				this.UpdateClimbing();
				return;
			case CoconutsInstance.StateType.PreThrowing:
				this.UpdatePreThrowing();
				return;
			case CoconutsInstance.StateType.PostThrowing:
				this.UpdatePostThrowing();
				return;
			default:
				return;
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00008404 File Offset: 0x00006604
		private void UpdateResting()
		{
			ICharacter closestCharacterTo = base.Level.ObjectManager.GetClosestCharacterTo(base.Position);
			if (closestCharacterTo != null)
			{
				bool flag = closestCharacterTo.Position.X > base.Position.X;
				if (this._facingRight != flag)
				{
					this._facingRight = flag;
					this._animation.Index = 2;
				}
				double num = (double)Math.Abs(base.Position.X - closestCharacterTo.Position.X);
				double num2 = (double)Math.Abs(base.Position.Y - closestCharacterTo.Position.Y);
				if (num < 384.0 && num2 < 400.0)
				{
					if (this._throwWaitDuration == 0)
					{
						this._state = CoconutsInstance.StateType.PreThrowing;
						this._stateDuration = 8;
						this._throwWaitDuration = 32;
						this._animation.Index = 3;
						return;
					}
					this._throwWaitDuration--;
				}
			}
			this._stateDuration--;
			if (this._stateDuration < 0)
			{
				this._state = CoconutsInstance.StateType.Climbing;
				this._animation.Index = 1;
				this.UpdateClimbIndex();
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00008538 File Offset: 0x00006738
		private void UpdateClimbing()
		{
			this._stateDuration--;
			if (this._stateDuration <= 0)
			{
				this._state = CoconutsInstance.StateType.Resting;
				this._animation.Index = 0;
				this._stateDuration = 16;
				return;
			}
			base.Position += new Vector2i(0, CoconutsInstance.ClimbData[this._climbDataIndex].VelocityY);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000085A7 File Offset: 0x000067A7
		private void UpdatePreThrowing()
		{
			this._stateDuration--;
			if (this._stateDuration < 0)
			{
				this.FireProjectile();
				this._state = CoconutsInstance.StateType.PostThrowing;
				this._stateDuration = 8;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000085D4 File Offset: 0x000067D4
		private void UpdatePostThrowing()
		{
			this._stateDuration--;
			if (this._stateDuration < 0)
			{
				this._state = CoconutsInstance.StateType.Climbing;
				this._stateDuration = 8;
				this._animation.Index = 1;
				this.UpdateClimbIndex();
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00008610 File Offset: 0x00006810
		private void UpdateClimbIndex()
		{
			this._climbDataIndex++;
			if (this._climbDataIndex >= CoconutsInstance.ClimbData.Count)
			{
				this._climbDataIndex = 0;
			}
			this._stateDuration = CoconutsInstance.ClimbData[this._climbDataIndex].Duration;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00008664 File Offset: 0x00006864
		private void FireProjectile()
		{
			CoconutsInstance.Projectile projectile = base.Level.ObjectManager.AddSubObject<CoconutsInstance.Projectile>(this);
			projectile.Position = new Vector2i(base.Position.X + (this._facingRight ? -44 : 44), base.Position.Y - 52);
			projectile.Direction = (this._facingRight ? 1 : -1);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000086CC File Offset: 0x000068CC
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000086D9 File Offset: 0x000068D9
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, this._facingRight, false);
		}

		// Token: 0x040000FB RID: 251
		private static readonly IReadOnlyList<CoconutsInstance.ClimbDataItem> ClimbData = new CoconutsInstance.ClimbDataItem[]
		{
			new CoconutsInstance.ClimbDataItem(-1, 32),
			new CoconutsInstance.ClimbDataItem(1, 24),
			new CoconutsInstance.ClimbDataItem(-1, 16),
			new CoconutsInstance.ClimbDataItem(1, 40),
			new CoconutsInstance.ClimbDataItem(-1, 32),
			new CoconutsInstance.ClimbDataItem(1, 16)
		};

		// Token: 0x040000FC RID: 252
		private const int AnimationResting = 0;

		// Token: 0x040000FD RID: 253
		private const int AnimationClimbing = 1;

		// Token: 0x040000FE RID: 254
		private const int AnimationTurning = 2;

		// Token: 0x040000FF RID: 255
		private const int AnimationThrowing = 3;

		// Token: 0x04000100 RID: 256
		private AnimationInstance _animation;

		// Token: 0x04000101 RID: 257
		private CoconutsInstance.StateType _state;

		// Token: 0x04000102 RID: 258
		private int _stateDuration;

		// Token: 0x04000103 RID: 259
		private int _throwWaitDuration;

		// Token: 0x04000104 RID: 260
		private int _climbDataIndex;

		// Token: 0x04000105 RID: 261
		private bool _facingRight;

		// Token: 0x020000CA RID: 202
		private struct ClimbDataItem
		{
			// Token: 0x170000BE RID: 190
			// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0001FB58 File Offset: 0x0001DD58
			public int VelocityY
			{
				get
				{
					return this._velocityY;
				}
			}

			// Token: 0x170000BF RID: 191
			// (get) Token: 0x060004F2 RID: 1266 RVA: 0x0001FB60 File Offset: 0x0001DD60
			public int Duration
			{
				get
				{
					return this._duration;
				}
			}

			// Token: 0x060004F3 RID: 1267 RVA: 0x0001FB68 File Offset: 0x0001DD68
			public ClimbDataItem(int velocityY, int duration)
			{
				this._velocityY = velocityY;
				this._duration = duration;
			}

			// Token: 0x060004F4 RID: 1268 RVA: 0x0001FB78 File Offset: 0x0001DD78
			public override string ToString()
			{
				return string.Format("Velocity Y = {0} Duration = {1}", this._velocityY, this._duration);
			}

			// Token: 0x04000585 RID: 1413
			private readonly int _velocityY;

			// Token: 0x04000586 RID: 1414
			private readonly int _duration;
		}

		// Token: 0x020000CB RID: 203
		private enum StateType
		{
			// Token: 0x04000588 RID: 1416
			Resting,
			// Token: 0x04000589 RID: 1417
			Climbing,
			// Token: 0x0400058A RID: 1418
			PreThrowing,
			// Token: 0x0400058B RID: 1419
			PostThrowing
		}

		// Token: 0x020000CC RID: 204
		private class Projectile : Enemy
		{
			// Token: 0x170000C0 RID: 192
			// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0001FB9A File Offset: 0x0001DD9A
			// (set) Token: 0x060004F6 RID: 1270 RVA: 0x0001FBAC File Offset: 0x0001DDAC
			public int Direction
			{
				get
				{
					return Math.Sign(this._velocity.X);
				}
				set
				{
					this._velocity.X = 4.0 * (double)Math.Sign(value);
				}
			}

			// Token: 0x060004F7 RID: 1271 RVA: 0x0001FBCC File Offset: 0x0001DDCC
			protected override void OnStart()
			{
				base.OnStart();
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 4);
				this._velocity = new Vector2(4.0, -4.0);
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -16, -16, 32, 32)
				};
			}

			// Token: 0x060004F8 RID: 1272 RVA: 0x0001FC3C File Offset: 0x0001DE3C
			protected override void OnUpdate()
			{
				base.OnUpdate();
				base.PositionPrecise += this._velocity;
				this._velocity.Y = this._velocity.Y + 0.5;
			}

			// Token: 0x060004F9 RID: 1273 RVA: 0x0001FC76 File Offset: 0x0001DE76
			protected override void OnAnimate()
			{
				this._animation.Animate();
			}

			// Token: 0x060004FA RID: 1274 RVA: 0x0001FC83 File Offset: 0x0001DE83
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				renderer.GetObjectRenderer().Render(this._animation, this._velocity.X >= 0.0, false);
			}

			// Token: 0x060004FB RID: 1275 RVA: 0x0001FCB0 File Offset: 0x0001DEB0
			protected override void OnStop()
			{
				base.OnStop();
				base.FinishForever();
			}

			// Token: 0x0400058C RID: 1420
			private const int AnimationProjectile = 4;

			// Token: 0x0400058D RID: 1421
			private const double InitialSpeed = 4.0;

			// Token: 0x0400058E RID: 1422
			private const double Gravity = 0.5;

			// Token: 0x0400058F RID: 1423
			private AnimationInstance _animation;

			// Token: 0x04000590 RID: 1424
			private Vector2 _velocity;
		}
	}
}
