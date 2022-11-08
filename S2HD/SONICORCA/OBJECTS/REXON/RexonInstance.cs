using System;
using System.Collections.Generic;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.REXON
{
	// Token: 0x0200005E RID: 94
	public class RexonInstance : ActiveObject
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001FA RID: 506 RVA: 0x0000F8A8 File Offset: 0x0000DAA8
		private RexonInstance.HeadBack Head
		{
			get
			{
				return (RexonInstance.HeadBack)this._necks[4];
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000F8B7 File Offset: 0x0000DAB7
		public RexonInstance()
		{
			base.DesignBounds = new Rectanglei(-64, -32, 128, 64);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000F8E4 File Offset: 0x0000DAE4
		protected override void OnStart()
		{
			base.OnStart();
			this._animationGroup = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
			this._animationBody = new AnimationInstance(this._animationGroup, 0);
			this._animationNeck = new AnimationInstance(this._animationGroup, 1);
			this._animationMouth = new AnimationInstance(this._animationGroup, 2);
			this._animationHead = new AnimationInstance(this._animationGroup, 3);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-64, -32, 128, 64), uint.MaxValue, (CollisionFlags)0);
			this._velocity = new Vector2(-0.5, 0.0);
			this._turnTicksRemaining = 128;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000F9A1 File Offset: 0x0000DBA1
		protected override void OnUpdate()
		{
			if (!this._headLifted)
			{
				this.WaitForCharacter();
			}
			if (this.Head != null)
			{
				this._headIsAlive = !this.Head.Finished;
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000F9D0 File Offset: 0x0000DBD0
		private void WaitForCharacter()
		{
			ICharacter closestCharacterTo = base.Level.ObjectManager.GetClosestCharacterTo(base.Position);
			if (closestCharacterTo != null && Math.Abs(base.Position.X - closestCharacterTo.Position.X) < 640)
			{
				this._facingRight = (closestCharacterTo.Position.X > base.Position.X);
				this._velocity = default(Vector2);
				this.CreateNeckAndHead();
				return;
			}
			int turnTicksRemaining = this._turnTicksRemaining;
			this._turnTicksRemaining = turnTicksRemaining - 1;
			if (turnTicksRemaining <= 0)
			{
				this._velocity.X = this._velocity.X * -1.0;
				this._facingRight = !this._facingRight;
				this._turnTicksRemaining = 128;
			}
			base.PositionPrecise += this._velocity;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000FABC File Offset: 0x0000DCBC
		private void CreateNeckAndHead()
		{
			this._headIsAlive = true;
			this._headLifted = true;
			RexonInstance.Neck neck = null;
			for (int i = 4; i >= 0; i--)
			{
				RexonInstance.Neck neck2;
				if (i != 4)
				{
					neck2 = base.Level.ObjectManager.AddSubObject<RexonInstance.Neck>(this);
				}
				else
				{
					neck2 = base.Level.ObjectManager.AddSubObject<RexonInstance.HeadBack>(this);
				}
				this._necks[i] = neck2;
				neck2.Prepare(i);
				if (neck != null)
				{
					neck2.NextNeck = neck;
					neck.PreviousNeck = neck2;
				}
				neck = neck2;
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000FB34 File Offset: 0x0000DD34
		protected override void OnAnimate()
		{
			if (this._headIsAlive)
			{
				if (this.Head.NextProjectileTicksRemaining < this._animationGroup[4].Duration - 4)
				{
					this._animationMouth.Index = 4;
				}
				if (this.Head.NextProjectileTicksRemaining < this._animationGroup[5].Duration - 4)
				{
					this._animationHead.Index = 5;
				}
			}
			this._animationBody.Animate();
			this._animationNeck.Animate();
			this._animationMouth.Animate();
			this._animationHead.Animate();
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000FBCD File Offset: 0x0000DDCD
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animationBody, this._facingRight, false);
		}

		// Token: 0x0400025C RID: 604
		private const int AnimationBody = 0;

		// Token: 0x0400025D RID: 605
		private const int AnimationNeck = 1;

		// Token: 0x0400025E RID: 606
		private const int AnimationMouth = 2;

		// Token: 0x0400025F RID: 607
		private const int AnimationHead = 3;

		// Token: 0x04000260 RID: 608
		private const int AnimationMouthFire = 4;

		// Token: 0x04000261 RID: 609
		private const int AnimationHeadFire = 5;

		// Token: 0x04000262 RID: 610
		private const int AnimationProjectile = 6;

		// Token: 0x04000263 RID: 611
		private AnimationGroup _animationGroup;

		// Token: 0x04000264 RID: 612
		private AnimationInstance _animationBody;

		// Token: 0x04000265 RID: 613
		private AnimationInstance _animationNeck;

		// Token: 0x04000266 RID: 614
		private AnimationInstance _animationMouth;

		// Token: 0x04000267 RID: 615
		private AnimationInstance _animationHead;

		// Token: 0x04000268 RID: 616
		private Vector2 _velocity;

		// Token: 0x04000269 RID: 617
		private bool _headLifted;

		// Token: 0x0400026A RID: 618
		private bool _facingRight;

		// Token: 0x0400026B RID: 619
		private int _turnTicksRemaining;

		// Token: 0x0400026C RID: 620
		private readonly RexonInstance.Neck[] _necks = new RexonInstance.Neck[5];

		// Token: 0x0400026D RID: 621
		private bool _headIsAlive;

		// Token: 0x020000E2 RID: 226
		private class Neck : Badnik
		{
			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x06000596 RID: 1430 RVA: 0x00021F57 File Offset: 0x00020157
			public RexonInstance Rexon
			{
				get
				{
					return (RexonInstance)base.ParentObject;
				}
			}

			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x06000597 RID: 1431 RVA: 0x00021F64 File Offset: 0x00020164
			// (set) Token: 0x06000598 RID: 1432 RVA: 0x00021F6C File Offset: 0x0002016C
			public RexonInstance.Neck PreviousNeck { get; set; }

			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x06000599 RID: 1433 RVA: 0x00021F75 File Offset: 0x00020175
			// (set) Token: 0x0600059A RID: 1434 RVA: 0x00021F7D File Offset: 0x0002017D
			public RexonInstance.Neck NextNeck { get; set; }

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x0600059B RID: 1435 RVA: 0x00021F86 File Offset: 0x00020186
			// (set) Token: 0x0600059C RID: 1436 RVA: 0x00021F8E File Offset: 0x0002018E
			protected RexonInstance.Neck.NeckState State { get; set; }

			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x0600059D RID: 1437 RVA: 0x00021F97 File Offset: 0x00020197
			// (set) Token: 0x0600059E RID: 1438 RVA: 0x00021F9F File Offset: 0x0002019F
			protected int StateTicksRemaining { get; set; }

			// Token: 0x0600059F RID: 1439 RVA: 0x00021FA8 File Offset: 0x000201A8
			public virtual void Prepare(int index)
			{
				this._index = index;
				this.StateTicksRemaining = RexonInstance.Neck.NeckRaiseTicks[this._index];
				this._oscillation += this._index * 16;
				Vector2i b = new Vector2i(-80, 64);
				if (this.Rexon._facingRight)
				{
					b.X *= -1;
				}
				base.Position += b;
				base.Priority = base.ParentObject.Priority + 1 + this._index;
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -16, -16, 32, 32)
				};
				base.CanBeDestoryed = false;
			}

			// Token: 0x060005A0 RID: 1440 RVA: 0x00022060 File Offset: 0x00020260
			protected override void OnUpdate()
			{
				base.OnUpdate();
				switch (this.State)
				{
				case RexonInstance.Neck.NeckState.PreRise:
				{
					this.CheckHeadIsAlive();
					int stateTicksRemaining = this.StateTicksRemaining;
					this.StateTicksRemaining = stateTicksRemaining - 1;
					if (stateTicksRemaining < 0)
					{
						this.StartRaise();
						return;
					}
					break;
				}
				case RexonInstance.Neck.NeckState.Rise:
				{
					this.CheckHeadIsAlive();
					this._velocity.X = this._velocity.X + 0.25;
					int stateTicksRemaining = this.StateTicksRemaining;
					this.StateTicksRemaining = stateTicksRemaining - 1;
					if (stateTicksRemaining < 0)
					{
						this.StartNormalState();
					}
					base.PositionPrecise += this._velocity;
					return;
				}
				case RexonInstance.Neck.NeckState.Oscillate:
					this.CheckHeadIsAlive();
					this.Oscillate();
					return;
				case RexonInstance.Neck.NeckState.Drop:
					this._velocity.Y = this._velocity.Y + 0.875;
					base.PositionPrecise += this._velocity;
					break;
				default:
					return;
				}
			}

			// Token: 0x060005A1 RID: 1441 RVA: 0x00022147 File Offset: 0x00020347
			private void StartRaise()
			{
				this.State = RexonInstance.Neck.NeckState.Rise;
				this._velocity = new Vector2(-0.45, -8.0);
				this.StateTicksRemaining = RexonInstance.Neck.NeckRaiseTicks[4 - this._index];
			}

			// Token: 0x060005A2 RID: 1442 RVA: 0x00022185 File Offset: 0x00020385
			private void StartNormalState()
			{
				this.State = RexonInstance.Neck.NeckState.Oscillate;
				this._velocity = default(Vector2);
				this.StateTicksRemaining = 32;
				this._oscillation = RexonInstance.Neck.UnknownA[this._index] * 4;
			}

			// Token: 0x060005A3 RID: 1443 RVA: 0x000221BA File Offset: 0x000203BA
			private void CheckHeadIsAlive()
			{
				if (!this.Rexon._headIsAlive)
				{
					this.State = RexonInstance.Neck.NeckState.Drop;
					this._velocity.X = RexonInstance.Neck.DeathXVelocities[this._index];
				}
			}

			// Token: 0x060005A4 RID: 1444 RVA: 0x000221EC File Offset: 0x000203EC
			private void Oscillate()
			{
				this._oscillation = (this._oscillation + 1) % 128;
				double num = (double)this._oscillation / 128.0 * 6.283185307179586;
				int x = (int)(Math.Cos(num) * 24.0);
				int num2 = (int)(-Math.Abs(Math.Sin(num)) * 8.0) - 52;
				if (this is RexonInstance.HeadBack)
				{
					num2 += 16;
				}
				if (this.PreviousNeck != null)
				{
					base.Position = this.PreviousNeck.Position + new Vector2i(x, num2);
				}
				if (this._index == 4)
				{
					base.Position += new Vector2i(this.Rexon._facingRight ? 18 : -18, 0);
				}
			}

			// Token: 0x060005A5 RID: 1445 RVA: 0x000222BC File Offset: 0x000204BC
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				Animation animation = this.Rexon._animationNeck.Animation;
				int count = animation.Frames.Count;
				int num = this.NextNeck._oscillation;
				num += (this.Rexon._facingRight ? 44 : 108);
				num %= 128;
				int index = MathX.Clamp(0, num, count - 1);
				Animation.Frame frame = animation.Frames[index];
				Rectanglei source = frame.Source;
				objectRenderer.Texture = this.Rexon._animationNeck.AnimationGroup.Textures[frame.TextureIndex];
				objectRenderer.Render(source, default(Vector2i), this.Rexon._facingRight, false);
			}

			// Token: 0x0400060B RID: 1547
			private static readonly IReadOnlyList<int> NeckRaiseTicks = new int[]
			{
				30,
				24,
				18,
				12,
				6,
				0
			};

			// Token: 0x0400060C RID: 1548
			private static readonly IReadOnlyList<int> UnknownA = new int[]
			{
				0,
				36,
				32,
				28,
				26
			};

			// Token: 0x0400060D RID: 1549
			private static readonly IReadOnlyList<double> DeathXVelocities = new double[]
			{
				2.0,
				-4.0,
				4.0,
				-2.0,
				2.0
			};

			// Token: 0x0400060E RID: 1550
			private int _index;

			// Token: 0x0400060F RID: 1551
			private Vector2 _velocity;

			// Token: 0x04000610 RID: 1552
			private int _oscillation;

			// Token: 0x02000134 RID: 308
			protected enum NeckState
			{
				// Token: 0x0400075B RID: 1883
				PreRise,
				// Token: 0x0400075C RID: 1884
				Rise,
				// Token: 0x0400075D RID: 1885
				Oscillate,
				// Token: 0x0400075E RID: 1886
				Drop
			}
		}

		// Token: 0x020000E3 RID: 227
		private class HeadBack : RexonInstance.Neck
		{
			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x060005A8 RID: 1448 RVA: 0x000223DB File Offset: 0x000205DB
			public int NextProjectileTicksRemaining
			{
				get
				{
					if (base.State != RexonInstance.Neck.NeckState.Oscillate)
					{
						return 127;
					}
					return base.StateTicksRemaining;
				}
			}

			// Token: 0x060005A9 RID: 1449 RVA: 0x000223EF File Offset: 0x000205EF
			public override void Prepare(int index)
			{
				base.Prepare(index);
				this._headFront = base.Level.ObjectManager.AddSubObject<RexonInstance.HeadFront>(this);
				base.CanBeDestoryed = true;
			}

			// Token: 0x060005AA RID: 1450 RVA: 0x00022418 File Offset: 0x00020618
			protected override void OnUpdate()
			{
				base.OnUpdate();
				if (base.State == RexonInstance.Neck.NeckState.Oscillate)
				{
					int stateTicksRemaining = base.StateTicksRemaining;
					base.StateTicksRemaining = stateTicksRemaining - 1;
					if (stateTicksRemaining < 0)
					{
						this.FireProjectile();
					}
				}
				if (this._headFront != null)
				{
					this._headFront.Position = base.Position;
				}
			}

			// Token: 0x060005AB RID: 1451 RVA: 0x00022468 File Offset: 0x00020668
			private void FireProjectile()
			{
				base.StateTicksRemaining = 127;
				RexonInstance.Projectile projectile = base.Level.ObjectManager.AddSubObject<RexonInstance.Projectile>(base.ParentObject);
				projectile.Position = base.Position + new Vector2i(base.Rexon._facingRight ? 16 : -16, 4);
				projectile.Velocity = new Vector2((double)(4 * (base.Rexon._facingRight ? 1 : -1)), 2.0);
			}

			// Token: 0x060005AC RID: 1452 RVA: 0x000224E4 File Offset: 0x000206E4
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				renderer.GetObjectRenderer().Render(base.Rexon._animationMouth, base.Rexon._facingRight, false);
			}

			// Token: 0x04000615 RID: 1557
			private RexonInstance.HeadFront _headFront;
		}

		// Token: 0x020000E4 RID: 228
		private class HeadFront : ActiveObject
		{
			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x060005AE RID: 1454 RVA: 0x00022510 File Offset: 0x00020710
			public RexonInstance.Neck Parent
			{
				get
				{
					return base.ParentObject as RexonInstance.Neck;
				}
			}

			// Token: 0x060005AF RID: 1455 RVA: 0x0002251D File Offset: 0x0002071D
			protected override void OnStart()
			{
				base.LockLifetime = true;
				base.Priority = 512;
			}

			// Token: 0x060005B0 RID: 1456 RVA: 0x00022531 File Offset: 0x00020731
			protected override void OnUpdate()
			{
				if (this.Parent.Finished)
				{
					base.Finish();
				}
			}

			// Token: 0x060005B1 RID: 1457 RVA: 0x00022548 File Offset: 0x00020748
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				RexonInstance rexonInstance = base.ParentObject.ParentObject as RexonInstance;
				renderer.GetObjectRenderer().Render(rexonInstance._animationHead, rexonInstance._facingRight, false);
			}
		}

		// Token: 0x020000E5 RID: 229
		private class Projectile : Enemy
		{
			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x060005B3 RID: 1459 RVA: 0x0002257E File Offset: 0x0002077E
			// (set) Token: 0x060005B4 RID: 1460 RVA: 0x00022586 File Offset: 0x00020786
			public Vector2 Velocity { get; set; }

			// Token: 0x060005B5 RID: 1461 RVA: 0x00022590 File Offset: 0x00020790
			protected override void OnStart()
			{
				base.OnStart();
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 6);
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -25, -25, 50, 50)
				};
				base.Priority += 32;
			}

			// Token: 0x060005B6 RID: 1462 RVA: 0x000225F2 File Offset: 0x000207F2
			protected override void OnUpdate()
			{
				base.OnUpdate();
				base.PositionPrecise += this.Velocity;
			}

			// Token: 0x060005B7 RID: 1463 RVA: 0x00022611 File Offset: 0x00020811
			protected override void OnAnimate()
			{
				this._animation.Animate();
			}

			// Token: 0x060005B8 RID: 1464 RVA: 0x0002261E File Offset: 0x0002081E
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				objectRenderer.EmitsLight = true;
				objectRenderer.Render(this._animation, false, false);
			}

			// Token: 0x04000616 RID: 1558
			private AnimationInstance _animation;
		}
	}
}
