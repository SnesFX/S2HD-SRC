using System;
using SonicOrca.Audio;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SONICORCA.OBJECTS.DUST;
using SonicOrca.Resources;

namespace SONICORCA.OBJECTS.DRILLEGGMAN
{
	// Token: 0x02000056 RID: 86
	public class DrillEggmanInstance : BossObject
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x0000CDA5 File Offset: 0x0000AFA5
		[HideInEditor]
		public DrillEggmanInstance.StatusType Status
		{
			get
			{
				return this._status;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000CDAD File Offset: 0x0000AFAD
		// (set) Token: 0x060001BB RID: 443 RVA: 0x0000CDB5 File Offset: 0x0000AFB5
		[StateVariable]
		public int LeftEdge { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000CDBE File Offset: 0x0000AFBE
		// (set) Token: 0x060001BD RID: 445 RVA: 0x0000CDC6 File Offset: 0x0000AFC6
		[StateVariable]
		public int RightEdge { get; set; }

		// Token: 0x060001BE RID: 446 RVA: 0x0000CDD0 File Offset: 0x0000AFD0
		protected override void OnStart()
		{
			ResourceTree resourceTree = base.Level.GameContext.ResourceTree;
			AnimationGroup animationGroup = this._animationGroup = resourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
			resourceTree.GetLoadedResource<AnimationGroup>(base.Type, "SONICORCA/OBJECTS/ROBOTNIK/ANIGROUP");
			this._animation = new AnimationInstance(animationGroup, 0);
			this._carLightAnimation = new AnimationInstance(animationGroup, 10);
			this._sparkAnimation = new AnimationInstance(animationGroup, 17);
			this._brokenVentAnimation = new AnimationInstance(animationGroup, 12);
			base.ExplosionResourceKey = base.Type.GetAbsolutePath("SONICORCA/OBJECTS/EXPLOSION/BOSS");
			base.HitSoundResourceKey = base.Type.GetAbsolutePath("SONICORCA/SOUND/BOSSHIT");
			base.LockLifetime = true;
			this._startPosition = base.Position;
			base.Position += new Vector2i(0, 1176);
			this._eggMobile = base.Level.ObjectManager.AddSubObject<DrillEggmanInstance.EggMobile>(this);
			this._eggMobile.Position = this._startPosition;
			for (int i = 0; i < 4; i++)
			{
				this._wheels[i] = base.Level.ObjectManager.AddSubObject<DrillEggmanInstance.Wheel>(this);
				this._wheels[i].Index = i;
				this._wheels[i].LockLifetime = true;
				this._wheels[i].AutoPositionToCar();
			}
			this._drill = base.Level.ObjectManager.AddSubObject<DrillEggmanInstance.Drill>(this);
			this._drill.Position = base.Position + new Vector2i(-224, 52);
			this._drill.FlipX = false;
			this._drill.LockLifetime = true;
			this._wheels[2].Priority = 252;
			this._wheels[3].Priority = 252;
			this._eggMobile.Priority = 254;
			base.Priority = 256;
			this._drill.Priority = 258;
			this._wheels[0].Priority = 260;
			this._wheels[1].Priority = 260;
			base.Health = 8;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000CFF0 File Offset: 0x0000B1F0
		protected override void OnUpdate()
		{
			base.OnUpdate();
			switch (this._status)
			{
			case DrillEggmanInstance.StatusType.InitialApproch:
				if (this._eggMobile.Position.X <= this._startPosition.X - 1152)
				{
					this._status = DrillEggmanInstance.StatusType.FinalApproach;
					return;
				}
				base.Position += new Vector2i(-4, 0);
				this._drill.Position += new Vector2i(-4, 0);
				return;
			case DrillEggmanInstance.StatusType.FinalApproach:
				if (this._eggMobile.Position.Y >= this._startPosition.Y + 1176)
				{
					this._eggMobile.Position = new Vector2i(this._eggMobile.Position.X, this._startPosition.Y + 1176);
					this._eggMobile.BeginLoweringPropeller();
					this._status = DrillEggmanInstance.StatusType.LowerPropeller;
					this._stateTimer = 60;
					return;
				}
				break;
			case DrillEggmanInstance.StatusType.LowerPropeller:
			{
				int num = this._stateTimer - 1;
				this._stateTimer = num;
				if (num <= 0)
				{
					this._status = DrillEggmanInstance.StatusType.Normal;
					this._velocityX = -8;
					base.CollisionRectangles = new CollisionRectangle[]
					{
						new CollisionRectangle(this, 0, -128, -128, 256, 256)
					};
					return;
				}
				break;
			}
			case DrillEggmanInstance.StatusType.Normal:
				if (this._eggMobile.Position.X <= this.LeftEdge - 512 || this._eggMobile.Position.X >= this.RightEdge + 512)
				{
					this._velocityX *= -1;
					this._eggMobile.FlipX = (this._velocityX > 0);
					if (!this._drill.Released)
					{
						this._drill.Position = new Vector2i(base.Position.X + (base.Position.X - this._drill.Position.X), this._drill.Position.Y);
						this._drill.FlipX = (this._velocityX > 0);
					}
					if (base.Health == 1)
					{
						this.ReleaseDrill();
					}
				}
				this._eggMobile.Position += new Vector2i(this._velocityX, 0);
				base.Position += new Vector2i(this._velocityX, 0);
				if (!this._drill.Released)
				{
					this._drill.Position += new Vector2i(this._velocityX, 0);
				}
				if (base.Health == 1)
				{
					if (this._lastHealthFlash > 0f)
					{
						this._lastHealthFlash = Math.Max(0f, this._lastHealthFlash - 0.1f);
					}
					if (this._sparkAnimation.Cycles > 0 && base.Level.Random.Next(60) == 0)
					{
						this._sparkAnimation.Cycles = 0;
						this._sparkAnimation.ResetFrame();
						this._lastHealthFlash = 1f;
					}
					if (base.Level.Random.Next(40) == 0)
					{
						if (this._velocityX >= 0)
						{
							this.EmitSmoke(new Vector2i(base.Level.Random.Next(-128, 28), -32), new Vector2(-1.0, -4.0));
							return;
						}
						this.EmitSmoke(new Vector2i(base.Level.Random.Next(-128, 28), -32), new Vector2(1.0, -4.0));
						return;
					}
				}
				break;
			case DrillEggmanInstance.StatusType.Defeated:
				this._stateTimer--;
				if (this._stateTimer > 0)
				{
					this._eggMobile.DoEggMobileBreak();
					base.UpdateExplosions(128);
					this.UpdateCarToGroundLevel();
					return;
				}
				this._status = DrillEggmanInstance.StatusType.PostDefeatedIdleA;
				this._stateTimer = 12;
				this._eggMobile.DoRobotnikNormal();
				return;
			case DrillEggmanInstance.StatusType.PostDefeatedIdleA:
				this._stateTimer--;
				if (this._stateTimer <= 0)
				{
					this._status = DrillEggmanInstance.StatusType.PostDefeatStartPropeller;
					return;
				}
				break;
			case DrillEggmanInstance.StatusType.PostDefeatStartPropeller:
				base.Defeated = true;
				this._stateTimer = 50;
				this._status = DrillEggmanInstance.StatusType.PostDefeatB;
				return;
			case DrillEggmanInstance.StatusType.PostDefeatB:
			{
				int num = this._stateTimer - 1;
				this._stateTimer = num;
				if (num <= 0)
				{
					this._status = DrillEggmanInstance.StatusType.Finished;
					this._stateTimer = 146;
					base.Fleeing = true;
					return;
				}
				break;
			}
			case DrillEggmanInstance.StatusType.Finished:
				this._stateTimer--;
				break;
			default:
				return;
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0000D490 File Offset: 0x0000B690
		private void UpdateCarToGroundLevel()
		{
			double num = (double)(this._eggMobile.Position.Y - base.Position.Y);
			base.PositionPrecise += new Vector2(0.0, this._velocityY);
			this._velocityY += 0.875;
			if (this._velocityY > 0.0)
			{
				foreach (CollisionInfo collisionInfo in CollisionVector.GetCollisions(this, 80, uint.MaxValue))
				{
					if (collisionInfo.Vector.Owner == null && !collisionInfo.Vector.IsWall)
					{
						base.PositionPrecise = new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y + collisionInfo.Shift);
						this._velocityY = 0.0;
					}
				}
			}
			this._eggMobile.PositionPrecise = new Vector2((double)this._eggMobile.Position.X, (double)base.Position.Y + num);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000D5DC File Offset: 0x0000B7DC
		protected override void Hit(ICharacter character)
		{
			base.Hit(character);
			if (base.Health > 0)
			{
				this._eggMobile.DoRobotnikFrown();
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000D5FC File Offset: 0x0000B7FC
		protected override void Defeat()
		{
			this._status = DrillEggmanInstance.StatusType.Defeated;
			this._stateTimer = 179;
			this._eggMobile.DoRobotnikDefeated();
			base.CollisionRectangles = new CollisionRectangle[0];
			this._velocityY = -6.0;
			this._animation.Index = 11;
			this.ReleaseFragments();
			this.ReleaseWheels();
			this.ReleaseDrill();
			base.Level.Player.GainScore(1000);
			base.Level.CreateScoreObject(1000, base.Position + new Vector2i(0, -128));
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0000D698 File Offset: 0x0000B898
		private void EmitSmoke(Vector2 offset, Vector2 velocity)
		{
			Matrix4 matrix = Matrix4.Identity;
			matrix *= Matrix4.CreateTranslation(base.Position);
			if (this._eggMobile.FlipX)
			{
				matrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
			}
			matrix = (matrix * Matrix4.CreateTranslation(offset)).RotateZ(0.0);
			Vector2i position = (Vector2i)(matrix * new Vector2(0.0, 0.0));
			DustInstance dustInstance = base.Level.ObjectManager.AddObject(new ObjectPlacement("SONICORCA/OBJECTS/DUST", base.Level.Map.Layers.IndexOf(base.Layer), position)) as DustInstance;
			dustInstance.Velocity = velocity;
			dustInstance.SetDustAnimationIndex(1);
			if (base.Level.Random.NextBoolean())
			{
				dustInstance.Priority = base.Priority - 8;
				return;
			}
			dustInstance.Priority = base.Priority + 8;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
		private void ReleaseFragments()
		{
			this.ReleaseFragmentPipe(new Vector2i(106, -15), new Vector2(-4.0, -10.0), 2.2);
			this.ReleaseFragmentPipe(new Vector2i(118, -15), new Vector2(-2.0, -15.0), 1.4);
			this.ReleaseFragmentPipe(new Vector2i(130, -15), new Vector2(5.0, -12.0), 2.0);
			for (int i = 0; i < 16; i++)
			{
				double x = (double)(-(double)base.Level.Random.Next(1, 8));
				double y = (double)(-(double)base.Level.Random.Next(-4, -1));
				this.ReleaseFragmentGlass(new Vector2i(-120, 0), new Vector2(x, y));
			}
			this.ReleaseFragmentMetal(new Vector2i(-14, -69), new Vector2(-10.0, -8.0));
			this.ReleaseFragmentMetal(new Vector2i(102, 0), new Vector2(-8.0, -6.0));
			this.ReleaseFragmentMetal(new Vector2i(132, 0), new Vector2(6.0, -8.0));
			this.ReleaseFragmentMetal(new Vector2i(102, -30), new Vector2(-4.0, -14.0));
			this.ReleaseFragmentMetal(new Vector2i(132, -28), new Vector2(8.0, -12.0));
			this.ReleaseFragmentMetal(new Vector2i(176, 18), new Vector2(12.0, -6.0));
			this.ReleaseFragmentRed(new Vector2i(-48, 10), new Vector2(-3.0, -8.0));
			this.ReleaseFragmentRed(new Vector2i(-48, 10), new Vector2(5.0, -8.0));
			this.ReleaseFragmentRed(new Vector2i(36, 46), new Vector2(-4.0, -4.0));
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000D9F8 File Offset: 0x0000BBF8
		private void ReleaseFragmentGlass(Vector2i offset, Vector2 velocity)
		{
			int num = base.Level.Random.Next(0, 3);
			int num2 = (this._velocityX > 0) ? -1 : 1;
			offset.X *= num2;
			velocity.X *= (double)num2;
			Fragment fragment = base.Level.ObjectManager.AddSubObject<Fragment>(this);
			fragment.AnimationGroup = this._animationGroup;
			fragment.AnimationIndex = 13;
			fragment.Position += offset;
			fragment.Velocity = velocity;
			fragment.Scale = 1.0 - (double)num * 0.25;
			fragment.AngularVelocity = 6.283185307179586 / ((double)(num + 1) * 0.5 * 60.0);
			fragment.Angle = base.Level.Random.NextRadians();
			fragment.FlipX = (this._velocityX > 0);
			fragment.FlipY = base.Level.Random.NextBoolean();
			fragment.Initialise();
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000DB08 File Offset: 0x0000BD08
		private void ReleaseFragmentMetal(Vector2i offset, Vector2 velocity)
		{
			int num = (this._velocityX > 0) ? -1 : 1;
			offset.X *= num;
			velocity.X *= (double)num;
			Fragment fragment = base.Level.ObjectManager.AddSubObject<Fragment>(this);
			fragment.AnimationGroup = this._animationGroup;
			fragment.AnimationIndex = 14;
			fragment.Position += offset;
			fragment.Velocity = velocity;
			fragment.AngularVelocity = 0.10471975511965977;
			fragment.FlipX = (this._velocityX > 0);
			fragment.Initialise();
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000DBA4 File Offset: 0x0000BDA4
		private void ReleaseFragmentRed(Vector2i offset, Vector2 velocity)
		{
			int num = (this._velocityX > 0) ? -1 : 1;
			offset.X *= num;
			velocity.X *= (double)num;
			Fragment fragment = base.Level.ObjectManager.AddSubObject<Fragment>(this);
			fragment.AnimationGroup = this._animationGroup;
			fragment.AnimationIndex = 15;
			fragment.Position += offset;
			fragment.Velocity = velocity;
			fragment.AngularVelocity = 0.20943951023931953;
			fragment.FlipX = (this._velocityX > 0);
			fragment.Initialise();
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000DC40 File Offset: 0x0000BE40
		private void ReleaseFragmentPipe(Vector2i offset, Vector2 velocity, double angularVelocityTimePeriod)
		{
			int num = (this._velocityX > 0) ? -1 : 1;
			offset.X *= num;
			velocity.X *= (double)num;
			Fragment fragment = base.Level.ObjectManager.AddSubObject<Fragment>(this);
			fragment.AnimationGroup = this._animationGroup;
			fragment.AnimationIndex = 16;
			fragment.Position += offset;
			fragment.Velocity = velocity;
			fragment.AngularVelocity = 6.283185307179586 / (angularVelocityTimePeriod * 60.0);
			fragment.FlipX = (this._velocityX > 0);
			fragment.Initialise();
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000DCE8 File Offset: 0x0000BEE8
		private void ReleaseWheels()
		{
			for (int i = 0; i < 4; i++)
			{
				Vector2 velocity = new Vector2(-8.0, -12.0);
				if (this._velocityX > 0)
				{
					velocity.X *= -1.0;
				}
				if (i == 1 || i == 3)
				{
					velocity.X *= -1.0;
				}
				this._wheels[i].Velocity = velocity;
				this._wheels[i].Released = true;
				this._wheels[i].LockLifetime = false;
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000DD8C File Offset: 0x0000BF8C
		private void ReleaseDrill()
		{
			if (this._drill.Released)
			{
				return;
			}
			this._drill.Released = true;
			this._drill.Velocity = new Vector2i(-12 * (this._drill.FlipX ? -1 : 1), 0);
			this._drill.LockLifetime = false;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000DDE4 File Offset: 0x0000BFE4
		protected override void OnHurtCharacter(ICharacter character)
		{
			this._eggMobile.DoRobotnikSmile();
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000DDF1 File Offset: 0x0000BFF1
		protected override void OnAnimate()
		{
			this._animation.Animate();
			this._carLightAnimation.Animate();
			this._sparkAnimation.Animate();
			this._brokenVentAnimation.Animate();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000DE20 File Offset: 0x0000C020
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			bool flag = this._velocityX > 0;
			Vector2i v = new Vector2i(-32 * (flag ? -1 : 1), 32);
			if (base.Health == 1)
			{
				int num = 4;
				double a = 6.283185307179586 * ((double)(base.Level.Ticks % num) / (double)num);
				v.Y += (int)(Math.Sin(a) * 2.0);
			}
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			float num2 = (base.Health == 1) ? this._lastHealthFlash : 0f;
			if (base.IsInvincibleFlashing)
			{
				num2 = 1f;
			}
			num2 *= 0.25f;
			objectRenderer.AdditiveColour = ((num2 > 0f) ? new Colour((double)num2, (double)num2, (double)num2) : Colours.Black);
			objectRenderer.Render(this._animation, v, flag, false);
			if (this._status == DrillEggmanInstance.StatusType.Normal)
			{
				objectRenderer.AdditiveColour = Colours.Black;
				objectRenderer.BlendMode = BlendMode.Additive;
				objectRenderer.EmitsLight = true;
				objectRenderer.Render(this._carLightAnimation, v + new Vector2((double)(flag ? 93 : -93), -24.0), flag, false);
				if (base.Health == 1 && this._sparkAnimation.Cycles == 0)
				{
					Animation.Frame currentFrame = this._sparkAnimation.CurrentFrame;
					Vector2i offset = currentFrame.Offset;
					if (flag)
					{
						offset.X *= -1;
					}
					objectRenderer.Texture = this._sparkAnimation.CurrentTexture;
					objectRenderer.Render(currentFrame.Source, currentFrame.Offset, flag, false);
				}
				objectRenderer.EmitsLight = false;
				objectRenderer.BlendMode = BlendMode.Alpha;
			}
			if (this._status >= DrillEggmanInstance.StatusType.Defeated)
			{
				objectRenderer.Render(this._brokenVentAnimation, v + new Vector2((double)(flag ? -112 : 112), -16.0), flag, false);
			}
		}

		// Token: 0x040001C4 RID: 452
		private const int AnimationCar = 0;

		// Token: 0x040001C5 RID: 453
		private const int AnimationWheelFrontMoving = 1;

		// Token: 0x040001C6 RID: 454
		private const int AnimationWheelFrontStill = 2;

		// Token: 0x040001C7 RID: 455
		private const int AnimationWheelBackMoving = 3;

		// Token: 0x040001C8 RID: 456
		private const int AnimationWheelBackStill = 4;

		// Token: 0x040001C9 RID: 457
		private const int AnimationDrill = 5;

		// Token: 0x040001CA RID: 458
		private const int AnimationPropellerStatic = 6;

		// Token: 0x040001CB RID: 459
		private const int AnimationPropellerOut = 7;

		// Token: 0x040001CC RID: 460
		private const int AnimationPropellerSpinning = 8;

		// Token: 0x040001CD RID: 461
		private const int AnimationPropellerIn = 9;

		// Token: 0x040001CE RID: 462
		private const int AnimationCarLight = 10;

		// Token: 0x040001CF RID: 463
		private const int AnimationBrokenCar = 11;

		// Token: 0x040001D0 RID: 464
		private const int AnimationBrokenVent = 12;

		// Token: 0x040001D1 RID: 465
		private const int AnimationGlassFragment = 13;

		// Token: 0x040001D2 RID: 466
		private const int AnimationMetalFragment = 14;

		// Token: 0x040001D3 RID: 467
		private const int AnimationRedFragment = 15;

		// Token: 0x040001D4 RID: 468
		private const int AnimationPipeFragment = 16;

		// Token: 0x040001D5 RID: 469
		private const int AnimationSpark = 17;

		// Token: 0x040001D6 RID: 470
		private const int AnimationEggMobileChasis = 18;

		// Token: 0x040001D7 RID: 471
		private const int AnimationEggMobileChasisFlame = 19;

		// Token: 0x040001D8 RID: 472
		private const int AnimationEggMobileScreen = 20;

		// Token: 0x040001D9 RID: 473
		private const int AnimationEggMobileCap = 21;

		// Token: 0x040001DA RID: 474
		private const int AnimationEggMobileChasisTurn1 = 22;

		// Token: 0x040001DB RID: 475
		private const int AnimationEggMobileChasisTurn2 = 23;

		// Token: 0x040001DC RID: 476
		private const int AnimationEggMobileScreenTurn1 = 24;

		// Token: 0x040001DD RID: 477
		private const int AnimationEggMobileScreenTurn2 = 25;

		// Token: 0x040001DE RID: 478
		private const int AnimationBrokenEggMobileChasis = 26;

		// Token: 0x040001DF RID: 479
		private const int AnimationBrokenEggMobileChasisFlame = 27;

		// Token: 0x040001E0 RID: 480
		private const int AnimationBrokenEggMobileScreen = 28;

		// Token: 0x040001E1 RID: 481
		private const int AnimationBrokenEggMobileCap = 29;

		// Token: 0x040001E2 RID: 482
		private const int AnimationBrokenEggMobileChasisTurn1 = 30;

		// Token: 0x040001E3 RID: 483
		private const int AnimationBrokenEggMobileChasisTurn2 = 31;

		// Token: 0x040001E4 RID: 484
		private const int AnimationBrokenEggMobileScreenTurn1 = 32;

		// Token: 0x040001E5 RID: 485
		private const int AnimationBrokenEggMobileScreenTurn2 = 33;

		// Token: 0x040001E6 RID: 486
		private const int AnimationEggMobileCapTurn1 = 34;

		// Token: 0x040001E7 RID: 487
		private const int AnimationEggMobileCapTurn2 = 35;

		// Token: 0x040001E8 RID: 488
		private const int AnimationRobotnikNormal = 0;

		// Token: 0x040001E9 RID: 489
		private const int AnimationRobotnikSmiling = 1;

		// Token: 0x040001EA RID: 490
		private const int AnimationRobotnikFrown = 2;

		// Token: 0x040001EB RID: 491
		private const int AnimationRobotnikDefeated = 3;

		// Token: 0x040001EC RID: 492
		private const int AnimationRobotnikTurn1 = 4;

		// Token: 0x040001ED RID: 493
		private const int AnimationRobotnikTurn2 = 5;

		// Token: 0x040001EE RID: 494
		private const int AnimationDustSmoke = 1;

		// Token: 0x040001EF RID: 495
		private const double Gravity = 0.875;

		// Token: 0x040001F0 RID: 496
		private AnimationGroup _animationGroup;

		// Token: 0x040001F1 RID: 497
		private AnimationInstance _animation;

		// Token: 0x040001F2 RID: 498
		private AnimationInstance _carLightAnimation;

		// Token: 0x040001F3 RID: 499
		private AnimationInstance _sparkAnimation;

		// Token: 0x040001F4 RID: 500
		private AnimationInstance _brokenVentAnimation;

		// Token: 0x040001F5 RID: 501
		private DrillEggmanInstance.StatusType _status;

		// Token: 0x040001F6 RID: 502
		private Vector2i _startPosition;

		// Token: 0x040001F7 RID: 503
		private int _stateTimer;

		// Token: 0x040001F8 RID: 504
		private int _velocityX;

		// Token: 0x040001F9 RID: 505
		private double _velocityY;

		// Token: 0x040001FA RID: 506
		private DrillEggmanInstance.EggMobile _eggMobile;

		// Token: 0x040001FB RID: 507
		private DrillEggmanInstance.Drill _drill;

		// Token: 0x040001FC RID: 508
		private DrillEggmanInstance.Wheel[] _wheels = new DrillEggmanInstance.Wheel[4];

		// Token: 0x040001FD RID: 509
		private float _lastHealthFlash;

		// Token: 0x020000D6 RID: 214
		public enum StatusType
		{
			// Token: 0x040005C2 RID: 1474
			InitialApproch,
			// Token: 0x040005C3 RID: 1475
			FinalApproach,
			// Token: 0x040005C4 RID: 1476
			LowerPropeller,
			// Token: 0x040005C5 RID: 1477
			Normal,
			// Token: 0x040005C6 RID: 1478
			Defeated,
			// Token: 0x040005C7 RID: 1479
			PostDefeatedIdleA,
			// Token: 0x040005C8 RID: 1480
			PostDefeatStartPropeller,
			// Token: 0x040005C9 RID: 1481
			PostDefeatB,
			// Token: 0x040005CA RID: 1482
			Finished
		}

		// Token: 0x020000D7 RID: 215
		private class EggMobile : ActiveObject
		{
			// Token: 0x170000CA RID: 202
			// (get) Token: 0x0600052D RID: 1325 RVA: 0x0002074D File Offset: 0x0001E94D
			// (set) Token: 0x0600052E RID: 1326 RVA: 0x00020755 File Offset: 0x0001E955
			public bool FlipX { get; set; }

			// Token: 0x170000CB RID: 203
			// (get) Token: 0x0600052F RID: 1327 RVA: 0x0002075E File Offset: 0x0001E95E
			// (set) Token: 0x06000530 RID: 1328 RVA: 0x00020766 File Offset: 0x0001E966
			private bool Turning { get; set; }

			// Token: 0x170000CC RID: 204
			// (get) Token: 0x06000531 RID: 1329 RVA: 0x0002076F File Offset: 0x0001E96F
			public DrillEggmanInstance DrillEggman
			{
				get
				{
					return (DrillEggmanInstance)base.ParentObject;
				}
			}

			// Token: 0x06000532 RID: 1330 RVA: 0x0002077C File Offset: 0x0001E97C
			protected override void OnStart()
			{
				ResourceTree resourceTree = base.Level.GameContext.ResourceTree;
				AnimationGroup loadedResource = resourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
				AnimationGroup loadedResource2 = resourceTree.GetLoadedResource<AnimationGroup>(base.Type, "SONICORCA/OBJECTS/ROBOTNIK/ANIGROUP");
				this._animationEggMobileChasis = new AnimationInstance(loadedResource, 19);
				this._animationEggMobileScreen = new AnimationInstance(loadedResource, 20);
				this._animationPropeller = new AnimationInstance(loadedResource, 8);
				this._animationRobotnik = new AnimationInstance(loadedResource2, 0);
				SampleInfo loadedResource3 = resourceTree.GetLoadedResource<SampleInfo>(base.Type, "SONICORCA/SOUND/BOSSHELICOPTER");
				this._helicopterSound = new LevelSound(base.Level, loadedResource3, default(Vector2i), false);
				this._helicopterSound.DistanceAudible = 3840;
				base.Level.SoundManager.AddLevelSound(this._helicopterSound);
				this._propellerOffset = -136;
				base.LockLifetime = true;
				this.Turning = false;
			}

			// Token: 0x06000533 RID: 1331 RVA: 0x00020860 File Offset: 0x0001EA60
			protected override void OnUpdate()
			{
				switch (this.DrillEggman._status)
				{
				case DrillEggmanInstance.StatusType.InitialApproch:
					base.Position += new Vector2i(-4, 4);
					this._helicopterSound.Play();
					break;
				case DrillEggmanInstance.StatusType.FinalApproach:
					base.Position += new Vector2i(0, 4);
					break;
				case DrillEggmanInstance.StatusType.LowerPropeller:
					if (this.DrillEggman._stateTimer <= 41)
					{
						this._propellerOffset++;
					}
					break;
				case DrillEggmanInstance.StatusType.Normal:
					this._animationEggMobileChasis.Index = 18;
					break;
				case DrillEggmanInstance.StatusType.PostDefeatB:
					this._animationEggMobileChasis.Index = 19;
					if (this.DrillEggman._stateTimer > 8)
					{
						this._propellerOffset--;
					}
					else if (this.DrillEggman._stateTimer == 8)
					{
						this._animationPropeller.Index = 7;
					}
					break;
				case DrillEggmanInstance.StatusType.Finished:
					this._helicopterSound.Play();
					if (this.DrillEggman._stateTimer > 0)
					{
						base.Position += new Vector2i(0, -4);
					}
					else if (!this.FlipX)
					{
						if (this._animationEggMobileChasis.Index != 30)
						{
							this._animationEggMobileChasis.Index = 30;
							this._animationEggMobileChasis.Cycles = 0;
							this._animationEggMobileScreen.Index = 32;
							this.Turning = false;
						}
						else if (this._animationEggMobileChasis.Cycles >= 1)
						{
							this._animationEggMobileChasis.Index = 31;
							this._animationEggMobileScreen.Index = 33;
							this.FlipX = true;
						}
					}
					else if (this._animationEggMobileChasis.Cycles >= 2 && this.Turning)
					{
						this.Turning = false;
						this._animationEggMobileScreen.Index = 28;
					}
					else if (this.FlipX)
					{
						base.Position += new Vector2i(24, 0);
					}
					this._fleeTicks++;
					if (this._fleeTicks > 1200)
					{
						base.LockLifetime = false;
					}
					break;
				}
				this._helicopterSound.Position = base.Position;
			}

			// Token: 0x06000534 RID: 1332 RVA: 0x00020AA3 File Offset: 0x0001ECA3
			public void BeginLoweringPropeller()
			{
				this._animationPropeller.Index = 9;
				this._helicopterSound.Stop();
			}

			// Token: 0x06000535 RID: 1333 RVA: 0x00020ABD File Offset: 0x0001ECBD
			public void DoEggMobileBreak()
			{
				this._animationEggMobileChasis.Index = 26;
				this._animationEggMobileScreen.Index = 28;
			}

			// Token: 0x06000536 RID: 1334 RVA: 0x00020AD9 File Offset: 0x0001ECD9
			public void DoRobotnikSmile()
			{
				if (this._animationRobotnik.Index == 0)
				{
					this._animationRobotnik.Index = 1;
				}
			}

			// Token: 0x06000537 RID: 1335 RVA: 0x00020AF4 File Offset: 0x0001ECF4
			public void DoRobotnikFrown()
			{
				this._animationRobotnik.Index = 2;
			}

			// Token: 0x06000538 RID: 1336 RVA: 0x00020B02 File Offset: 0x0001ED02
			public void DoRobotnikDefeated()
			{
				this._animationRobotnik.Index = 3;
			}

			// Token: 0x06000539 RID: 1337 RVA: 0x00020B10 File Offset: 0x0001ED10
			public void DoRobotnikNormal()
			{
				this._animationRobotnik.Index = 0;
			}

			// Token: 0x0600053A RID: 1338 RVA: 0x00020B1E File Offset: 0x0001ED1E
			protected override void OnStop()
			{
				this._helicopterSound.Dispose();
			}

			// Token: 0x0600053B RID: 1339 RVA: 0x00020B2B File Offset: 0x0001ED2B
			protected override void OnAnimate()
			{
				this._animationEggMobileChasis.Animate();
				this._animationEggMobileScreen.Animate();
				this._animationPropeller.Animate();
				this._animationRobotnik.Animate();
			}

			// Token: 0x0600053C RID: 1340 RVA: 0x00020B5C File Offset: 0x0001ED5C
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				using (objectRenderer.BeginMatixState())
				{
					if (this.FlipX)
					{
						objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
					}
					Vector2i v = new Vector2i(36, this._propellerOffset);
					Vector2i vector2i = new Vector2i(-8, -26);
					vector2i + new Vector2i(0, 0);
					Vector2i v2 = vector2i + new Vector2i(0, -76);
					Vector2i v3 = vector2i + new Vector2i(0, 0);
					objectRenderer.FilterAmount *= 0.5;
					if (this.DrillEggman.IsInvincibleFlashing)
					{
						objectRenderer.AdditiveColour = BossObject.FlashAdditiveColour;
					}
					objectRenderer.Render(this._animationPropeller, v, false, false);
					objectRenderer.Render(this._animationEggMobileChasis, vector2i, false, false);
					objectRenderer.AdditiveColour = Colours.Black;
					objectRenderer.Render(this._animationRobotnik, v2, false, false);
					if (this.DrillEggman.IsInvincibleFlashing)
					{
						objectRenderer.AdditiveColour = BossObject.FlashAdditiveColour;
					}
					objectRenderer.Render(this._animationEggMobileScreen, v3, false, false);
				}
			}

			// Token: 0x040005CB RID: 1483
			private AnimationInstance _animationEggMobileChasis;

			// Token: 0x040005CC RID: 1484
			private AnimationInstance _animationEggMobileScreen;

			// Token: 0x040005CD RID: 1485
			private AnimationInstance _animationPropeller;

			// Token: 0x040005CE RID: 1486
			private AnimationInstance _animationRobotnik;

			// Token: 0x040005CF RID: 1487
			private LevelSound _helicopterSound;

			// Token: 0x040005D0 RID: 1488
			private int _propellerOffset;

			// Token: 0x040005D1 RID: 1489
			private int _fleeTicks;
		}

		// Token: 0x020000D8 RID: 216
		private class Drill : Enemy
		{
			// Token: 0x170000CD RID: 205
			// (get) Token: 0x0600053E RID: 1342 RVA: 0x00020CC4 File Offset: 0x0001EEC4
			// (set) Token: 0x0600053F RID: 1343 RVA: 0x00020CCC File Offset: 0x0001EECC
			public Vector2i Velocity { get; set; }

			// Token: 0x170000CE RID: 206
			// (get) Token: 0x06000540 RID: 1344 RVA: 0x00020CD5 File Offset: 0x0001EED5
			// (set) Token: 0x06000541 RID: 1345 RVA: 0x00020CDD File Offset: 0x0001EEDD
			public bool FlipX { get; set; }

			// Token: 0x170000CF RID: 207
			// (get) Token: 0x06000542 RID: 1346 RVA: 0x00020CE6 File Offset: 0x0001EEE6
			// (set) Token: 0x06000543 RID: 1347 RVA: 0x00020CEE File Offset: 0x0001EEEE
			public bool Released { get; set; }

			// Token: 0x170000D0 RID: 208
			// (get) Token: 0x06000544 RID: 1348 RVA: 0x0002076F File Offset: 0x0001E96F
			public DrillEggmanInstance DrillEggman
			{
				get
				{
					return (DrillEggmanInstance)base.ParentObject;
				}
			}

			// Token: 0x06000545 RID: 1349 RVA: 0x00020CF8 File Offset: 0x0001EEF8
			protected override void OnStart()
			{
				base.OnStart();
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -96, -96, 192, 192)
				};
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 5);
			}

			// Token: 0x06000546 RID: 1350 RVA: 0x00020D51 File Offset: 0x0001EF51
			protected override void OnUpdate()
			{
				base.OnUpdate();
				base.Position += this.Velocity;
			}

			// Token: 0x06000547 RID: 1351 RVA: 0x00020D70 File Offset: 0x0001EF70
			protected override void OnCollision(CollisionEvent e)
			{
				if (this.DrillEggman._status >= DrillEggmanInstance.StatusType.Normal)
				{
					base.OnCollision(e);
				}
			}

			// Token: 0x06000548 RID: 1352 RVA: 0x00020D87 File Offset: 0x0001EF87
			protected override void OnHurtCharacter(ICharacter character)
			{
				(base.ParentObject as DrillEggmanInstance)._eggMobile.DoRobotnikSmile();
			}

			// Token: 0x06000549 RID: 1353 RVA: 0x00020DA0 File Offset: 0x0001EFA0
			protected override void OnAnimate()
			{
				base.OnAnimate();
				if (this.DrillEggman._status < DrillEggmanInstance.StatusType.LowerPropeller)
				{
					return;
				}
				if (this.DrillEggman._status == DrillEggmanInstance.StatusType.LowerPropeller)
				{
					this._animation.OverrideDelay = new int?(3);
				}
				else
				{
					this._animation.OverrideDelay = null;
				}
				this._animation.Animate();
			}

			// Token: 0x0600054A RID: 1354 RVA: 0x00020E02 File Offset: 0x0001F002
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				renderer.GetObjectRenderer().Render(this._animation, this.FlipX, false);
			}

			// Token: 0x040005D4 RID: 1492
			private AnimationInstance _animation;
		}

		// Token: 0x020000D9 RID: 217
		private class Wheel : ActiveObject
		{
			// Token: 0x170000D1 RID: 209
			// (get) Token: 0x0600054C RID: 1356 RVA: 0x00020E1C File Offset: 0x0001F01C
			// (set) Token: 0x0600054D RID: 1357 RVA: 0x00020E24 File Offset: 0x0001F024
			public int Index { get; set; }

			// Token: 0x170000D2 RID: 210
			// (get) Token: 0x0600054E RID: 1358 RVA: 0x00020E2D File Offset: 0x0001F02D
			// (set) Token: 0x0600054F RID: 1359 RVA: 0x00020E35 File Offset: 0x0001F035
			public Vector2 Velocity { get; set; }

			// Token: 0x170000D3 RID: 211
			// (get) Token: 0x06000550 RID: 1360 RVA: 0x00020E3E File Offset: 0x0001F03E
			// (set) Token: 0x06000551 RID: 1361 RVA: 0x00020E46 File Offset: 0x0001F046
			public bool FlipX { get; set; }

			// Token: 0x170000D4 RID: 212
			// (get) Token: 0x06000552 RID: 1362 RVA: 0x00020E4F File Offset: 0x0001F04F
			// (set) Token: 0x06000553 RID: 1363 RVA: 0x00020E57 File Offset: 0x0001F057
			public bool Released { get; set; }

			// Token: 0x170000D5 RID: 213
			// (get) Token: 0x06000554 RID: 1364 RVA: 0x0002076F File Offset: 0x0001E96F
			public DrillEggmanInstance DrillEggman
			{
				get
				{
					return (DrillEggmanInstance)base.ParentObject;
				}
			}

			// Token: 0x06000555 RID: 1365 RVA: 0x00020E60 File Offset: 0x0001F060
			protected override void OnStart()
			{
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			}

			// Token: 0x06000556 RID: 1366 RVA: 0x00020E84 File Offset: 0x0001F084
			protected override void OnUpdate()
			{
				if (this.Released)
				{
					base.PositionPrecise += this.Velocity;
					this.Velocity += new Vector2(0.0, 0.875);
					if (this.Velocity.Y > 0.0 && this.MoveToGroundLevel())
					{
						this.Velocity += new Vector2(0.0, -8.0);
						return;
					}
				}
				else
				{
					this.AutoPositionToCar();
					base.Position += new Vector2i(this.DrillEggman._velocityX, 0);
					this.MoveToGroundLevel();
				}
			}

			// Token: 0x06000557 RID: 1367 RVA: 0x00020F54 File Offset: 0x0001F154
			public void AutoPositionToCar()
			{
				this.FlipX = (this.DrillEggman._velocityX > 0);
				base.Position = this.DrillEggman.Position + ((this.DrillEggman._velocityX <= 0) ? DrillEggmanInstance.Wheel.LeftPositions[this.Index] : DrillEggmanInstance.Wheel.RightPositions[this.Index]);
			}

			// Token: 0x06000558 RID: 1368 RVA: 0x00020FBC File Offset: 0x0001F1BC
			private bool MoveToGroundLevel()
			{
				bool result = false;
				foreach (CollisionInfo collisionInfo in CollisionVector.GetCollisions(this, 64, uint.MaxValue))
				{
					if (collisionInfo.Vector.Owner == null && !collisionInfo.Vector.IsWall)
					{
						base.PositionPrecise = new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y + collisionInfo.Shift);
						result = true;
					}
				}
				return result;
			}

			// Token: 0x06000559 RID: 1369 RVA: 0x00021054 File Offset: 0x0001F254
			protected override void OnAnimate()
			{
				bool flag = false;
				if (base.PositionPrecise - base.LastPositionPrecise != default(Vector2))
				{
					flag = true;
				}
				int index;
				if (this.Index == 0 || this.Index == 1)
				{
					index = (flag ? 1 : 2);
				}
				else
				{
					index = (flag ? 3 : 4);
				}
				this._animation.Index = index;
				this._animation.Animate();
			}

			// Token: 0x0600055A RID: 1370 RVA: 0x000210C0 File Offset: 0x0001F2C0
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				if (this.DrillEggman.IsInvincibleFlashing)
				{
					objectRenderer.AdditiveColour = BossObject.FlashAdditiveColour;
				}
				objectRenderer.Render(this._animation, this.FlipX, false);
			}

			// Token: 0x040005D8 RID: 1496
			private const double Gravity = 0.875;

			// Token: 0x040005D9 RID: 1497
			private static readonly Vector2i[] LeftPositions = new Vector2i[]
			{
				new Vector2i(-48, 80),
				new Vector2i(144, 80),
				new Vector2i(-192, 80),
				new Vector2i(0, 80)
			};

			// Token: 0x040005DA RID: 1498
			private static readonly Vector2i[] RightPositions = new Vector2i[]
			{
				new Vector2i(48, 80),
				new Vector2i(-144, 80),
				new Vector2i(192, 80),
				new Vector2i(0, 80)
			};

			// Token: 0x040005DB RID: 1499
			private AnimationInstance _animation;
		}
	}
}
