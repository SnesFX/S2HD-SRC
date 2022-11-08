using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core.Collision;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000167 RID: 359
	public abstract class Character : ActiveObject, ICharacter, IActiveObject
	{
		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000F04 RID: 3844 RVA: 0x00038224 File Offset: 0x00036424
		// (set) Token: 0x06000F05 RID: 3845 RVA: 0x0003822C File Offset: 0x0003642C
		protected string AnimationGroupResourceKey { get; set; }

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000F06 RID: 3846 RVA: 0x00038235 File Offset: 0x00036435
		// (set) Token: 0x06000F07 RID: 3847 RVA: 0x0003823D File Offset: 0x0003643D
		protected string BrakeDustResourceKey { get; set; }

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000F08 RID: 3848 RVA: 0x00038246 File Offset: 0x00036446
		// (set) Token: 0x06000F09 RID: 3849 RVA: 0x0003824E File Offset: 0x0003644E
		protected string SpindashDustGroupResourceKey { get; set; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000F0A RID: 3850 RVA: 0x00038257 File Offset: 0x00036457
		// (set) Token: 0x06000F0B RID: 3851 RVA: 0x0003825F File Offset: 0x0003645F
		public AnimationInstance Animation { get; set; }

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000F0C RID: 3852 RVA: 0x00038268 File Offset: 0x00036468
		// (set) Token: 0x06000F0D RID: 3853 RVA: 0x00038270 File Offset: 0x00036470
		protected AnimationInstance BarrierAnimation { get; set; }

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000F0E RID: 3854 RVA: 0x00038279 File Offset: 0x00036479
		// (set) Token: 0x06000F0F RID: 3855 RVA: 0x00038281 File Offset: 0x00036481
		protected AnimationInstance SpindashDustAnimation { get; set; }

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000F10 RID: 3856 RVA: 0x0003828A File Offset: 0x0003648A
		// (set) Token: 0x06000F11 RID: 3857 RVA: 0x00038292 File Offset: 0x00036492
		public double ShowAngle { get; set; }

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000F12 RID: 3858 RVA: 0x0003829B File Offset: 0x0003649B
		// (set) Token: 0x06000F13 RID: 3859 RVA: 0x000382A3 File Offset: 0x000364A3
		public double TumbleAngle { get; set; }

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000F14 RID: 3860 RVA: 0x000382AC File Offset: 0x000364AC
		// (set) Token: 0x06000F15 RID: 3861 RVA: 0x000382B4 File Offset: 0x000364B4
		public int TumbleTurns { get; set; }

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000F16 RID: 3862 RVA: 0x000382BD File Offset: 0x000364BD
		// (set) Token: 0x06000F17 RID: 3863 RVA: 0x000382C5 File Offset: 0x000364C5
		protected bool DrawBodyRotated { get; set; }

		// Token: 0x06000F18 RID: 3864 RVA: 0x000382D0 File Offset: 0x000364D0
		protected override void OnAnimate()
		{
			this.DrawBodyRotated = false;
			this.Animation.OverrideDelay = null;
			if (this.IsDead)
			{
				return;
			}
			CharacterSpecialState specialState = this.SpecialState;
			if (specialState == CharacterSpecialState.Grabbed)
			{
				this.Animation.Index = 24;
				this.Animation.Animate();
			}
			else
			{
				this.AnimationNormalState();
			}
			if (this._drowningClimax)
			{
				this._drowningAnimation.Animate();
			}
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x00038340 File Offset: 0x00036540
		private void AnimationNormalState()
		{
			if (this.IsDying)
			{
				if (this._deathCause == PlayerDeathCause.Drown)
				{
					this.Animation.Index = 20;
				}
				else
				{
					this.Animation.Index = 15;
				}
			}
			else
			{
				if (this.IsDebug)
				{
					this.Animation.Index = 10;
					return;
				}
				if (this.IsHurt)
				{
					this.Animation.Index = 14;
				}
				else if (this.IsWinning)
				{
					this.Animation.Index = 19;
				}
				else if (this.IsFlying)
				{
					this.Animation.Index = 17;
				}
				else if (this.IsCharging)
				{
					this.Animation.Index = 11;
				}
				else if (this.IsSpinball)
				{
					this.Animation.Index = 10;
					this.Animation.OverrideDelay = new int?((int)(Math.Max(0.0, 20.0 - Math.Abs(this.GroundVelocity)) / 5.0));
				}
				else if ((this.Animation.Index != 12 && this.Animation.Index != 13) || !this.IsAirborne)
				{
					if (this.LookDirection == CharacterLookDirection.Up)
					{
						this.Animation.Index = 1;
					}
					else if (this.LookDirection == CharacterLookDirection.Ducking)
					{
						this.Animation.Index = 2;
					}
					else if (this.IsPushing)
					{
						this.Animation.Index = 6;
						this.Animation.OverrideDelay = new int?(8);
						this.DrawBodyRotated = true;
					}
					else if (this.IsBraking)
					{
						this.Animation.Index = 9;
						this.DrawBodyRotated = true;
					}
					else if (this.GroundVelocity == 0.0)
					{
						int num = Math.Abs((int)this._balanceDirection);
						if (num != 1)
						{
							if (num != 2)
							{
								if (this.IsAirborne)
								{
									this.Animation.Index = 13;
								}
								else if (this.Animation.Index == 19)
								{
									this.Animation.Index = 26;
								}
								else if (this.Animation.Index != 26)
								{
									this.Animation.Index = 0;
								}
							}
							else
							{
								this.Animation.Index = 3;
							}
						}
						else if ((this.IsFacingLeft && this._balanceDirection > CharacterBalanceDirection.None) || (this.IsFacingRight && this._balanceDirection < CharacterBalanceDirection.None))
						{
							this.Animation.Index = 5;
						}
						else
						{
							this.Animation.Index = 4;
						}
					}
					else if (this._inhalingBubble != 0)
					{
						if (this._inhalingBubble == 1)
						{
							this._inhalingBubble = 2;
							this.Animation.Index = 18;
						}
						else if (this.Animation.Index != 18)
						{
							this._inhalingBubble = 0;
						}
					}
					else
					{
						bool flag = true;
						bool flag2 = false;
						bool flag3 = false;
						if (this.Player.ProtagonistCharacterType == CharacterType.Sonic && this == this.Player.Protagonist)
						{
							flag2 = true;
							flag3 = true;
						}
						if (Math.Abs(this.GroundVelocity) < 24.0)
						{
							if (flag3)
							{
								if (this.Animation.Index == 0 && this.Animation.CurrentFrameIndex >= 248)
								{
									this.Animation.Index = 27;
								}
								else if (this.Animation.Index == 27)
								{
									this.GroundVelocity = 0.0;
								}
								else
								{
									this.Animation.Index = 7;
								}
							}
							else
							{
								this.Animation.Index = 7;
							}
						}
						else if (Math.Abs(this.GroundVelocity) >= 48.0)
						{
							if (flag2)
							{
								this.Animation.Index = 28;
							}
							else
							{
								this.Animation.Index = 8;
							}
							flag = false;
						}
						else if (flag2)
						{
							if (this.Animation.Index == 28)
							{
								this.Animation.Index = 29;
							}
							else
							{
								this.Animation.Index = 8;
							}
						}
						else
						{
							this.Animation.Index = 8;
						}
						if (flag)
						{
							this.Animation.OverrideDelay = new int?((int)(Math.Max(0.0, 32.0 - Math.Abs(this.GroundVelocity)) / 8.0));
						}
						this.DrawBodyRotated = true;
					}
				}
			}
			this.UpdateRotation();
			if (!this.IsSpinball && this.TumbleAngle != 0.0 && !this.IsHurt && !this.IsDying)
			{
				this.Animation.Index = 16;
				double num2 = MathX.Clamp(this.TumbleAngle, 1.0);
				num2 = ((num2 >= 0.0) ? (num2 / 2.0) : ((1.0 - Math.Abs(num2)) / 2.0 + 0.5));
				if (this.IsFacingLeft)
				{
					num2 = 1.0 - num2;
					num2 = MathX.Wrap(num2 + 0.5, 1.0, 0.0);
				}
				this.Animation.CurrentFrameIndex = (int)((double)(this.Animation.AnimationGroup[this.Animation.Index].Frames.Count - 1) * num2);
				this.Animation.CurrentFrameIndex = MathX.Clamp(0, this.Animation.CurrentFrameIndex, this.Animation.AnimationGroup[this.Animation.Index].Frames.Count - 1);
			}
			else
			{
				this.Animation.Animate();
			}
			if (this.HasBarrier)
			{
				if (this._barrierTypeAnimation != this.Barrier)
				{
					this._barrierTypeAnimation = this.Barrier;
					this.BarrierAnimation = new AnimationInstance(base.ResourceTree, Character.GetBarrierResourceKey(this._barrierTypeAnimation), 0);
				}
				this.BarrierAnimation.Animate();
			}
			this.SpindashDustAnimation.Animate();
			if (this.IsInvincible)
			{
				this.AnimateInvincibility();
			}
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x00038960 File Offset: 0x00036B60
		private void UpdateRotation()
		{
			if (this.Mode == CollisionMode.Air || this.GroundVector == null)
			{
				this.ShowAngle = MathX.GoTowardsWrap(this.ShowAngle, 0.0, 0.05, 0.0, 6.283185307179586);
				if (this.TumbleTurns == 0)
				{
					this.TumbleAngle = MathX.ChangeSpeed(this.TumbleAngle, -0.0234375);
					return;
				}
				if (this.TumbleTurns < 0)
				{
					this.TumbleAngle -= 0.0234375;
					if (this.TumbleAngle < 0.0)
					{
						this.TumbleAngle += 1.0;
						int tumbleTurns = this.TumbleTurns;
						this.TumbleTurns = tumbleTurns + 1;
						return;
					}
				}
				else if (this.TumbleTurns > 0)
				{
					this.TumbleAngle += 0.0234375;
					if (this.TumbleAngle > 1.0)
					{
						this.TumbleAngle -= 2.0;
						int tumbleTurns = this.TumbleTurns;
						this.TumbleTurns = tumbleTurns - 1;
						return;
					}
				}
			}
			else
			{
				double to = this.GroundVector.Flags.HasFlag(CollisionFlags.Rotate) ? this.GroundVector.Angle : ((double)this.Mode * -1.5707963267948966);
				this.ShowAngle = MathX.LerpWrap(this.ShowAngle, to, MathX.Clamp(0.25, Math.Abs(this.GroundVelocity) / 64.0, 1.0), 0.0, 6.283185307179586, 0.0);
				this.TumbleAngle = 0.0;
			}
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x00038B34 File Offset: 0x00036D34
		private static string GetBarrierResourceKey(BarrierType type)
		{
			switch (type)
			{
			case BarrierType.Classic:
				return "SONICORCA/OBJECTS/BARRIER/ANIGROUP";
			case BarrierType.Bubble:
				return "SONICORCA/OBJECTS/BARRIER/BUBBLE/ANIGROUP";
			case BarrierType.Fire:
				return "SONICORCA/OBJECTS/BARRIER/FIRE/ANIGROUP";
			case BarrierType.Lightning:
				return "SONICORCA/OBJECTS/BARRIER/LIGHTNING/ANIGROUP";
			default:
				return null;
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000F1C RID: 3868 RVA: 0x00038B69 File Offset: 0x00036D69
		// (set) Token: 0x06000F1D RID: 3869 RVA: 0x00038B71 File Offset: 0x00036D71
		public int LedgeSensorRadius { get; set; }

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000F1E RID: 3870 RVA: 0x00038B7A File Offset: 0x00036D7A
		// (set) Token: 0x06000F1F RID: 3871 RVA: 0x00038B82 File Offset: 0x00036D82
		public Vector2i NormalCollisionRadius { get; set; }

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000F20 RID: 3872 RVA: 0x00038B8B File Offset: 0x00036D8B
		// (set) Token: 0x06000F21 RID: 3873 RVA: 0x00038B93 File Offset: 0x00036D93
		public Vector2i SpinballCollisionRadius { get; set; }

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000F22 RID: 3874 RVA: 0x00038B9C File Offset: 0x00036D9C
		// (set) Token: 0x06000F23 RID: 3875 RVA: 0x00038BA4 File Offset: 0x00036DA4
		public Vector2i RectangleCollisionRadius { get; set; }

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x00038BAD File Offset: 0x00036DAD
		// (set) Token: 0x06000F25 RID: 3877 RVA: 0x00038BB5 File Offset: 0x00036DB5
		public Vector2i CollisionRadius { get; set; }

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000F26 RID: 3878 RVA: 0x00038BBE File Offset: 0x00036DBE
		// (set) Token: 0x06000F27 RID: 3879 RVA: 0x00038BC6 File Offset: 0x00036DC6
		public int FloorSensorRadius { get; set; }

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000F28 RID: 3880 RVA: 0x00038BCF File Offset: 0x00036DCF
		// (set) Token: 0x06000F29 RID: 3881 RVA: 0x00038BD7 File Offset: 0x00036DD7
		public int CollisionSensorSize { get; set; }

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000F2A RID: 3882 RVA: 0x00038BE0 File Offset: 0x00036DE0
		// (set) Token: 0x06000F2B RID: 3883 RVA: 0x00038BE8 File Offset: 0x00036DE8
		public bool CheckCollision { get; set; }

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000F2C RID: 3884 RVA: 0x00038BF1 File Offset: 0x00036DF1
		// (set) Token: 0x06000F2D RID: 3885 RVA: 0x00038BF9 File Offset: 0x00036DF9
		public bool CheckLandscapeCollision { get; set; }

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000F2E RID: 3886 RVA: 0x00038C02 File Offset: 0x00036E02
		// (set) Token: 0x06000F2F RID: 3887 RVA: 0x00038C0A File Offset: 0x00036E0A
		public bool CheckObjectCollision { get; set; }

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x00038C13 File Offset: 0x00036E13
		// (set) Token: 0x06000F31 RID: 3889 RVA: 0x00038C1B File Offset: 0x00036E1B
		public int Path { get; set; }

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000F32 RID: 3890 RVA: 0x00038C24 File Offset: 0x00036E24
		// (set) Token: 0x06000F33 RID: 3891 RVA: 0x00038C2C File Offset: 0x00036E2C
		public int LastPath { get; set; }

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000F34 RID: 3892 RVA: 0x00038C35 File Offset: 0x00036E35
		// (set) Token: 0x06000F35 RID: 3893 RVA: 0x00038C3D File Offset: 0x00036E3D
		public CollisionMode Mode { get; set; }

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000F36 RID: 3894 RVA: 0x00038C46 File Offset: 0x00036E46
		// (set) Token: 0x06000F37 RID: 3895 RVA: 0x00038C4E File Offset: 0x00036E4E
		public CollisionVector GroundVector { get; set; }

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000F38 RID: 3896 RVA: 0x00038C57 File Offset: 0x00036E57
		private double GroundAngle
		{
			get
			{
				if (this.GroundVector != null)
				{
					return this.GroundVector.Angle;
				}
				return 0.0;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x00038C76 File Offset: 0x00036E76
		// (set) Token: 0x06000F3A RID: 3898 RVA: 0x00038C7E File Offset: 0x00036E7E
		public double DistanceFromLedge { get; set; }

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x00038C87 File Offset: 0x00036E87
		// (set) Token: 0x06000F3C RID: 3900 RVA: 0x00038C8F File Offset: 0x00036E8F
		public ActiveObject ObjectLink { get; set; }

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x00038C98 File Offset: 0x00036E98
		// (set) Token: 0x06000F3E RID: 3902 RVA: 0x00038CA0 File Offset: 0x00036EA0
		public object ObjectTag { get; set; }

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x00038CA9 File Offset: 0x00036EA9
		public IPlatform CurrentPlatform
		{
			get
			{
				return this.ObjectLink as IPlatform;
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x00038CB6 File Offset: 0x00036EB6
		// (set) Token: 0x06000F41 RID: 3905 RVA: 0x00038CBE File Offset: 0x00036EBE
		public int LastTickOnGround { get; set; }

		// Token: 0x06000F42 RID: 3906 RVA: 0x00038CC8 File Offset: 0x00036EC8
		private void ProcessCollision()
		{
			this.ResetCollisionEvents();
			if (this.GroundVector != null && this.GroundVector.Owner != null)
			{
				CollisionVector groundVector = this.GroundVector;
				if (!this.GroundVector.Owner.CollisionVectors.Contains(this.GroundVector))
				{
					this.LeaveGround();
				}
			}
			if (this.CheckCollision)
			{
				this._originalGroundVector = ((this.Mode == CollisionMode.Air) ? null : this.GroundVector);
				this._collidedVectors.Clear();
				if (this.GroundVector != null)
				{
					CollisionMode mode = this.Mode;
					if (mode <= CollisionMode.Right)
					{
						this.ConstrainToPath();
					}
				}
				this.Bump(this.CollisionRadius);
				this.CheckOverlappingVector();
				if (this.PlayerShouldLand())
				{
					this.Land(true);
				}
				this.UpdateCollisionsWithObjects();
				if (this.Mode != CollisionMode.Air)
				{
					this._collisionDetected[(int)this.Mode] = true;
					CollisionInfo collisionInfo = new CollisionInfo(this.GroundVector, default(Vector2), 0.0, this.GroundAngle);
					CollisionEvent collisionEvent;
					if (this.GroundVector != null)
					{
						collisionEvent = new CollisionEvent(this, collisionInfo);
					}
					else
					{
						collisionEvent = new CollisionEvent(this, 0);
						collisionEvent.CollisionInfo = collisionInfo;
					}
					this._collisionEvents[(int)this.Mode] = collisionEvent;
				}
				this.CheckCrushed();
			}
			this.UpdateDistanceFromLedge();
			this.LastPath = this.Path;
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x00038E10 File Offset: 0x00037010
		private void ResetCollisionEvents()
		{
			for (int i = 0; i < 4; i++)
			{
				this._collisionEvents[i] = null;
				this._collisionDetected[i] = false;
				this._collisionEventsTiles[i] = null;
				this._collisionDetectedTiles[i] = false;
				this._overlappingGroundVector = null;
				this._overlappingCollision = new KeyValuePair<ActiveObject, CollisionEvent>(null, null);
			}
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x00038E61 File Offset: 0x00037061
		private bool CheckIgnoreFlag(CollisionVector t)
		{
			return t.Flags.HasFlag(CollisionFlags.Ignore);
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x00038E84 File Offset: 0x00037084
		private bool CheckSolidAngle(CollisionVector t, Vector2 intersection, Vector2 collisionRadius)
		{
			if (t.Flags.HasFlag(CollisionFlags.Solid))
			{
				return false;
			}
			Vector2 b = default(Vector2);
			double x = base.PositionPrecise.X;
			int num = 1;
			if (t.Mode == CollisionMode.Right)
			{
				b = this.GetPointRotatedFromRelative(intersection, new Vector2(intersection.X, intersection.Y - collisionRadius.X), 1.5707963267948966 + this.GroundAngle);
			}
			else if (t.Mode == CollisionMode.Left)
			{
				b = this.GetPointRotatedFromRelative(intersection, new Vector2(intersection.X, intersection.Y + collisionRadius.X), 1.5707963267948966 + this.GroundAngle);
			}
			else if (t.Mode == CollisionMode.Top)
			{
				b = this.GetPointRotatedFromRelative(intersection, new Vector2(intersection.X - collisionRadius.Y, intersection.Y), 1.5707963267948966 + this.GroundAngle);
			}
			else if (t.Mode == CollisionMode.Bottom)
			{
				b = this.GetPointRotatedFromRelative(intersection, new Vector2(intersection.X + collisionRadius.Y, intersection.Y), 1.5707963267948966 + this.GroundAngle);
			}
			return MathX.DifferenceRadians((base.PositionPrecise - b).Angle, t.Angle) * (double)num > 0.0;
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x00038FF0 File Offset: 0x000371F0
		private Vector2 GetPointRotatedFromOrigin(Vector2 center, Vector2 point, double angleInRadians)
		{
			double x = point.X;
			double y = point.Y;
			double x2 = center.X;
			double y2 = center.Y;
			double x3 = (x - x2) * Math.Cos(angleInRadians) - (y - y2) * Math.Sin(angleInRadians) + x2;
			double y3 = (x - x2) * Math.Sin(angleInRadians) + (y - y2) * Math.Cos(angleInRadians) + y2;
			return new Vector2(x3, y3);
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00039054 File Offset: 0x00037254
		private Vector2 GetPointRotatedFromRelative(Vector2 relative, Vector2 point, double theta)
		{
			double x = point.X;
			double y = point.Y;
			double x2 = relative.X;
			double y2 = relative.Y;
			double x3 = Math.Cos(theta) * (x - x2) - Math.Sin(theta) * (y - y2) + x2;
			double y3 = Math.Sin(theta) * (x - x2) + Math.Cos(theta) * (y - y2) + y2;
			return new Vector2(x3, y3);
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x000390B8 File Offset: 0x000372B8
		public Vector2[][] GetCollisionBox(Vector2 collisionRadius, bool rotate)
		{
			double theta = 0.0;
			if (rotate)
			{
				theta = this.GroundAngle;
			}
			Vector2 pointRotatedFromRelative = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X - collisionRadius.X, base.PositionPrecise.Y - collisionRadius.Y), theta);
			Vector2 pointRotatedFromRelative2 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X + collisionRadius.X, base.PositionPrecise.Y - collisionRadius.Y), theta);
			Vector2 pointRotatedFromRelative3 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X + collisionRadius.X, base.PositionPrecise.Y + collisionRadius.Y), theta);
			Vector2 pointRotatedFromRelative4 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X - collisionRadius.X, base.PositionPrecise.Y + collisionRadius.Y), theta);
			return new Vector2[][]
			{
				new Vector2[]
				{
					pointRotatedFromRelative,
					pointRotatedFromRelative2
				},
				new Vector2[]
				{
					pointRotatedFromRelative3,
					pointRotatedFromRelative2
				},
				new Vector2[]
				{
					pointRotatedFromRelative4,
					pointRotatedFromRelative3
				},
				new Vector2[]
				{
					pointRotatedFromRelative4,
					pointRotatedFromRelative
				}
			};
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x0003924C File Offset: 0x0003744C
		private bool IsBeyondPathEnd(bool useLedgeSensor)
		{
			if (base.LastPositionPrecise == base.PositionPrecise)
			{
				return false;
			}
			int num = useLedgeSensor ? (this.CollisionRadius.X - this.LedgeSensorRadius) : 0;
			Vector2 pointRotatedFromRelative = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X - (double)this.CollisionRadius.Y, base.PositionPrecise.Y), this.GroundAngle + 1.5707963267948966);
			Vector2 pointRotatedFromRelative2 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X + (double)this.CollisionRadius.Y, base.PositionPrecise.Y), this.GroundAngle + 1.5707963267948966);
			Vector2i absoluteA = this.GroundVector.AbsoluteA;
			Vector2i absoluteB = this.GroundVector.AbsoluteB;
			if (Vector2.Intersects(pointRotatedFromRelative, pointRotatedFromRelative2, absoluteA, absoluteB))
			{
				return false;
			}
			Vector2 pointA = default(Vector2);
			Vector2.GetLineIntersection(pointRotatedFromRelative, pointRotatedFromRelative2, absoluteA, absoluteB, out pointA);
			double distance = Vector2.GetDistance(pointA, this.GroundVector.Bounds.Centre);
			double distance2 = Vector2.GetDistance(pointA, absoluteA);
			double distance3 = Vector2.GetDistance(pointA, absoluteB);
			double distance4 = Vector2.GetDistance(this.GroundVector.Bounds.Centre, absoluteB);
			double groundAngle = this.GroundAngle;
			double angle = this.GroundVector.Angle;
			return distance3 < distance2 && distance - (double)num > distance4;
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x00039408 File Offset: 0x00037608
		private bool IsBeyondPathStart(bool useLedgeSensor)
		{
			int num = useLedgeSensor ? (this.CollisionRadius.X - this.LedgeSensorRadius) : 0;
			Vector2 pointRotatedFromRelative = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X - (double)this.CollisionRadius.Y, base.PositionPrecise.Y), this.GroundAngle + 1.5707963267948966);
			Vector2 pointRotatedFromRelative2 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X + (double)this.CollisionRadius.Y, base.PositionPrecise.Y), this.GroundAngle + 1.5707963267948966);
			Vector2i absoluteA = this.GroundVector.AbsoluteA;
			Vector2i absoluteB = this.GroundVector.AbsoluteB;
			if (Vector2.Intersects(pointRotatedFromRelative, pointRotatedFromRelative2, absoluteA, absoluteB))
			{
				return false;
			}
			Vector2 pointA = default(Vector2);
			Vector2.GetLineIntersection(pointRotatedFromRelative, pointRotatedFromRelative2, absoluteA, absoluteB, out pointA);
			double distance = Vector2.GetDistance(pointA, this.GroundVector.Bounds.Centre);
			double distance2 = Vector2.GetDistance(pointA, this.GroundVector.AbsoluteA);
			double distance3 = Vector2.GetDistance(pointA, this.GroundVector.AbsoluteB);
			double distance4 = Vector2.GetDistance(this.GroundVector.Bounds.Centre, absoluteA);
			return distance3 > distance2 && distance - (double)num > distance4;
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x000395AC File Offset: 0x000377AC
		private double GenesisHexToRadians(double angle)
		{
			return MathX.ToRadians((angle - 256.0) * 1.40625);
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x000395C8 File Offset: 0x000377C8
		private double GenesisHexToDegrees(double angle)
		{
			return 360.0 + -(256.0 - angle) * 1.40625;
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x000395EC File Offset: 0x000377EC
		private bool IsLandingViable(CollisionVector vector)
		{
			if (vector.Flags.HasFlag(CollisionFlags.NoLanding))
			{
				this.Velocity = default(Vector2);
				return false;
			}
			switch (vector.Mode)
			{
			case CollisionMode.Top:
				return this.Velocity.Y >= 0.0;
			case CollisionMode.Left:
			case CollisionMode.Right:
				if (vector.FlipX != 0 && Math.Abs(this.Velocity.X) >= 0.0)
				{
					return true;
				}
				if (this.Velocity.X * (double)vector.FlipY < 0.0)
				{
					if (vector != null)
					{
						this.Velocity = new Vector2(0.0, this.Velocity.Y);
					}
					else
					{
						this.Velocity = new Vector2(0.0, this.Velocity.Y);
					}
					if (this.Mode != CollisionMode.Air)
					{
						this.GroundVelocity = 0.0;
					}
				}
				else if (vector.FlipY == 0)
				{
					this.Velocity = new Vector2(0.0, this.Velocity.Y);
				}
				return false;
			case CollisionMode.Bottom:
				if (vector.FlipY != 0 && this.Velocity.Y < 0.0)
				{
					return true;
				}
				if (this.Velocity.Y < 0.0)
				{
					this.Velocity = new Vector2(this.Velocity.X, 0.0);
					if (this.Mode != CollisionMode.Air)
					{
						this.GroundVelocity = 0.0;
					}
				}
				return false;
			default:
				return false;
			}
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x000397B8 File Offset: 0x000379B8
		private bool PlayerShouldLand()
		{
			bool result = false;
			CollisionMode collisionMode = CollisionMode.Air;
			for (int i = 0; i < 4; i++)
			{
				if (this._collisionEvents[i] != null && !this._collisionEvents[i].MaintainVelocity && this.IsLandingViable(this._collisionEvents[i].CollisionInfo.Vector))
				{
					collisionMode = (CollisionMode)i;
				}
			}
			if (collisionMode != CollisionMode.Air)
			{
				if (this.CharacterEvents.HasFlag(CharacterEvent.Hurt))
				{
					return result;
				}
				bool flag = this.Mode == CollisionMode.Air;
				CollisionVector vector = this._collisionEvents[(int)collisionMode].CollisionInfo.Vector;
				if (vector != this._originalGroundVector)
				{
					base.PositionPrecise = this.GetAlignmentForVector2(vector, base.PositionPrecise, this.GroundAngle);
					this.AcquireVector(vector);
					if (flag)
					{
						result = true;
					}
					this.Bump(this.CollisionRadius);
				}
			}
			return result;
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x0003988C File Offset: 0x00037A8C
		private void Land(bool updateSpeed = true)
		{
			if (this.Barrier == BarrierType.Bubble && this.HasPerformedBarrierAttack)
			{
				this.Mode = CollisionMode.Air;
				this.GroundVector = null;
				this.IsJumping = true;
				this.IsRollJumping = false;
				this.HasPerformedBarrierAttack = false;
				this.Velocity = new Vector2(this.Velocity.X, -30.0);
			}
			else
			{
				this.IsAirborne = false;
				this.IsJumping = false;
				if (base.Level.Ticks - this.LastTickOnGround > 11)
				{
					this.IsSpinball = false;
				}
				this.IsRollJumping = false;
				this.IsHurt = false;
				this.IsFlying = false;
				this.HasPerformedBarrierAttack = false;
				this.ShowAngle = this.GroundAngle;
				this.Jumped = false;
				if (updateSpeed)
				{
					if (this.GroundVector.Flags.HasFlag(CollisionFlags.NoAngle))
					{
						this.GroundVelocity = this.Velocity.X;
					}
					else
					{
						this.GroundVelocity = ((Math.Abs(this.Velocity.X) > Math.Abs(this.Velocity.Y)) ? (this.Velocity.X * (double)this.GroundVector.FlipX) : (this.Velocity.X * Math.Cos(this.GroundAngle) + this.Velocity.Y * Math.Sin(this.GroundAngle)));
						this.Velocity = new Vector2(this.GroundVelocity * Math.Cos(this.GroundAngle), this.GroundVelocity * Math.Sin(this.GroundAngle));
					}
				}
			}
			this.Player.ResetScoreChain();
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x00039A48 File Offset: 0x00037C48
		public void LeaveGround()
		{
			if (this.GroundVector != null)
			{
				this.RemovePlatformVelocity();
				if (this.GroundVector.Flags.HasFlag(CollisionFlags.Snap))
				{
					Math.Sign(this.GroundVelocity);
					double num = MathX.Snap(this.GroundAngle, 1.5707963267948966);
					this.Velocity = new Vector2(this.GroundVelocity * Math.Cos(num), this.GroundVelocity * Math.Sin(num));
				}
				this.GroundVector = null;
				this.ObjectLink = null;
			}
			this.Mode = CollisionMode.Air;
			this.IsAirborne = true;
			this.IsBraking = false;
			this.IsCharging = false;
			this.IsHurt = false;
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x00039AFC File Offset: 0x00037CFC
		private void ConstrainToPath()
		{
			CollisionVector collisionVector = null;
			bool flag = true;
			if (this.IsBeyondPathEnd(false))
			{
				collisionVector = this.GroundVector;
				bool flag2 = true;
				double num = double.MaxValue;
				CollisionVector collisionVector2 = null;
				while (flag2)
				{
					if ((collisionVector = collisionVector.GetConnectionB(this.Path)) != null)
					{
						double distanceToVector = this.GetDistanceToVector(collisionVector);
						if (distanceToVector < num)
						{
							num = distanceToVector;
							if (this._lastLeftVector != collisionVector)
							{
								collisionVector2 = collisionVector;
								this._lastLeftVector = collisionVector2;
							}
						}
						else
						{
							flag2 = false;
						}
					}
					else
					{
						flag2 = false;
					}
				}
				collisionVector = collisionVector2;
			}
			else if (this.IsBeyondPathStart(false))
			{
				collisionVector = this.GroundVector;
				bool flag3 = true;
				double num2 = double.MaxValue;
				CollisionVector collisionVector3 = null;
				while (flag3)
				{
					if ((collisionVector = collisionVector.GetConnectionA(this.Path)) != null)
					{
						double distanceToVector2 = this.GetDistanceToVector(collisionVector);
						if (distanceToVector2 < num2)
						{
							num2 = distanceToVector2;
							if (this._lastRightVector != collisionVector)
							{
								collisionVector3 = collisionVector;
								this._lastRightVector = collisionVector3;
							}
						}
						else
						{
							flag3 = false;
						}
					}
					else
					{
						flag3 = false;
					}
				}
				collisionVector = collisionVector3;
			}
			else
			{
				this._lastRightVector = null;
				this._lastLeftVector = null;
				flag = false;
			}
			if (collisionVector != null)
			{
				if (!collisionVector.Flags.HasFlag(CollisionFlags.NoPathFollowing))
				{
					base.PositionPrecise = this.GetAlignmentForVector2(collisionVector, base.PositionPrecise, this.GroundAngle);
					this.AcquireVector(collisionVector);
					return;
				}
				if (flag)
				{
					this.LeaveGround();
					return;
				}
			}
			else if (flag)
			{
				if (this.IsBeyondPathEnd(true) || this.IsBeyondPathStart(true))
				{
					this.LeaveGround();
					return;
				}
			}
			else
			{
				this.PlayerShouldLand();
				if (this.CheckIgnoreFlag(this.GroundVector))
				{
					this.LeaveGround();
				}
			}
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x00039C74 File Offset: 0x00037E74
		private IEnumerable<CollisionVector> FixPosition(Vector2 collisionRadius, IEnumerable<CollisionVector> vectorsToCheck)
		{
			List<CollisionVector> result = new List<CollisionVector>();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			bool flag = false;
			foreach (CollisionVector collisionVector in vectorsToCheck)
			{
				double num5 = 0.0;
				double num6 = 0.0;
				if (this.Mode == CollisionMode.Left || this.Mode == CollisionMode.Right)
				{
					flag = true;
					num5 = (double)this.CollisionRadius.Y;
					num6 = (double)this.CollisionRadius.X;
				}
				else
				{
					num5 = (double)this.CollisionRadius.X;
					num6 = (double)this.CollisionRadius.Y;
				}
				Vector2 pointRotatedFromRelative = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y + num5), 1.5707963267948966 + this.GroundAngle);
				Vector2 pointRotatedFromRelative2 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y - num5), 1.5707963267948966 + this.GroundAngle);
				Vector2 pointRotatedFromRelative3 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X + num6, base.PositionPrecise.Y), 1.5707963267948966 + this.GroundAngle);
				Vector2 pointRotatedFromRelative4 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X - num6, base.PositionPrecise.Y), 1.5707963267948966 + this.GroundAngle);
				Vector2[][] collisionBox = this.GetCollisionBox(new Vector2(num5, num6 - (double)this.FloorSensorRadius + 20.0), false);
				Vector2[][] collisionBox2 = this.GetCollisionBox(new Vector2(num5 - (double)this.LedgeSensorRadius, num6), false);
				Vector2[][] array = new Vector2[0][];
				Vector2[][] array2 = new Vector2[0][];
				Vector2 vector = default(Vector2);
				Vector2 vector2 = default(Vector2);
				Vector2 vector3 = default(Vector2);
				Vector2 vector4 = default(Vector2);
				if (flag)
				{
					array = collisionBox2;
					array2 = collisionBox;
					vector = pointRotatedFromRelative3;
					vector2 = pointRotatedFromRelative4;
					vector3 = pointRotatedFromRelative;
					vector4 = pointRotatedFromRelative2;
				}
				else
				{
					array = collisionBox;
					array2 = collisionBox2;
					vector = pointRotatedFromRelative;
					vector2 = pointRotatedFromRelative2;
					vector3 = pointRotatedFromRelative3;
					vector4 = pointRotatedFromRelative4;
				}
				if (this.CanCollideWithVector(collisionVector))
				{
					Vector2[] array3 = new Vector2[]
					{
						collisionVector.AbsoluteA,
						collisionVector.AbsoluteB
					};
					bool flag2 = false;
					if (!this.CheckIgnoreFlag(collisionVector))
					{
						bool flag3 = false;
						if (collisionVector.IsWall)
						{
							List<Vector2[]> list = new List<Vector2[]>
							{
								new Vector2[]
								{
									vector,
									vector2
								}
							};
							list.AddRange(array);
							List<Vector2> list2 = new List<Vector2>();
							for (int i = 0; i < list.Count; i++)
							{
								if (Vector2.Intersects(list[i][0], list[i][1], array3[0], array3[1]))
								{
									flag2 = true;
									Vector2 item = default(Vector2);
									Vector2.GetLineIntersection(list[i][0], list[i][1], array3[0], array3[1], out item);
									list2.Add(item);
								}
								flag3 = (i >= 1);
							}
							if (!flag2)
							{
								Rectangle rectangle = Rectangle.FromLTRB(array[0][0].X, array[0][0].Y, array[1][0].X, array[1][0].Y);
								if (rectangle.ContainsOrOverlaps(array3[0]))
								{
									Vector2 item2 = default(Vector2);
									Vector2 pointRotatedFromRelative5 = this.GetPointRotatedFromRelative(array3[0], new Vector2(array3[0].X - 5.0, array3[0].Y), 1.5707963267948966);
									Vector2.GetLineIntersection(array3[0], pointRotatedFromRelative5, list[0][0], list[0][1], out item2);
									list2.Add(item2);
									flag2 = true;
								}
								if (rectangle.ContainsOrOverlaps(array3[1]))
								{
									Vector2 item3 = default(Vector2);
									Vector2 pointRotatedFromRelative6 = this.GetPointRotatedFromRelative(array3[1], new Vector2(array3[1].X - 5.0, array3[1].Y), 1.5707963267948966);
									Vector2.GetLineIntersection(array3[1], pointRotatedFromRelative6, list[0][0], list[0][1], out item3);
									list2.Add(item3);
									flag2 = true;
								}
							}
							if (flag2)
							{
								Vector2 vector5 = default(Vector2);
								double x = base.PositionPrecise.X;
								double num7 = num2;
								double num8 = num;
								Vector2 vector6 = new Vector2(-1.0, -1.0);
								if (collisionVector.Mode == CollisionMode.Right)
								{
									Vector2 vector7 = list2.First<Vector2>();
									foreach (Vector2 vector8 in list2.Skip(1))
									{
										if (vector8.X < vector7.X)
										{
											vector7 = vector8;
										}
									}
									vector6 = vector7;
									vector5 = this.GetPointRotatedFromRelative(vector6, new Vector2(vector6.X, vector6.Y - num5), 1.5707963267948966 + this.GroundAngle);
									if (vector5.X - x >= num2)
									{
										num2 = vector5.X - x;
									}
								}
								else if (collisionVector.Mode == CollisionMode.Left)
								{
									Vector2 vector9 = list2.First<Vector2>();
									foreach (Vector2 vector10 in list2.Skip(1))
									{
										if (vector10.X > vector9.X)
										{
											vector9 = vector10;
										}
									}
									vector6 = vector9;
									vector5 = this.GetPointRotatedFromRelative(vector6, new Vector2(vector6.X, vector6.Y + num5), 1.5707963267948966 + this.GroundAngle);
									if (vector5.X - x < num)
									{
										num = vector5.X - x;
									}
								}
								if (!this.CheckSolidAngle(collisionVector, vector6, new Vector2(num5, num6)))
								{
									double distance = Vector2.GetDistance(pointRotatedFromRelative2, vector6);
									CollisionInfo collisionInfo = new CollisionInfo(collisionVector, vector6, distance, collisionVector.Angle);
									CollisionEvent collisionEvent = new CollisionEvent(this, collisionInfo);
									if (collisionVector.Owner != null)
									{
										collisionVector.Owner.Collision(collisionEvent);
									}
									if (!collisionEvent.IgnoreCollision)
									{
										this._collisionDetected[(int)collisionVector.Mode] = true;
										this._collisionEvents[(int)collisionVector.Mode] = collisionEvent;
									}
									Vector2 positionPrecise = base.PositionPrecise;
									double num9 = 0.0;
									double num10 = 0.0;
									if (num7 != num2)
									{
										num9 = num2 - num7;
									}
									if (num8 != num)
									{
										num10 = num - num8;
									}
									if (num9 != 0.0 || num10 != 0.0)
									{
										positionPrecise.X += num9;
										positionPrecise.X += num10;
										base.PositionPrecise = positionPrecise;
									}
								}
							}
						}
						else
						{
							List<Vector2[]> list3 = new List<Vector2[]>
							{
								new Vector2[]
								{
									vector3,
									vector4
								}
							};
							list3.AddRange(array2);
							List<Vector2> list4 = new List<Vector2>();
							for (int j = 0; j < list3.Count; j++)
							{
								if (Vector2.Intersects(list3[j][0], list3[j][1], array3[0], array3[1]))
								{
									flag2 = true;
									Vector2 item4 = default(Vector2);
									Vector2.GetLineIntersection(list3[j][0], list3[j][1], array3[0], array3[1], out item4);
									list4.Add(item4);
								}
								flag3 = (j >= 1);
							}
							if (!flag2)
							{
								Rectangle rectangle2 = Rectangle.FromLTRB(array2[0][0].X, array2[0][0].Y, array2[1][0].X, array2[1][0].Y);
								if (rectangle2.ContainsOrOverlaps(array3[0]))
								{
									Vector2 item5 = default(Vector2);
									Vector2.GetLineIntersection(this.GetPointRotatedFromRelative(array3[0], new Vector2(array3[0].X, array3[0].Y + 5.0), 1.5707963267948966), array3[0], list3[0][0], list3[0][1], out item5);
									list4.Add(item5);
									flag2 = true;
								}
								if (rectangle2.ContainsOrOverlaps(array3[1]))
								{
									Vector2 item6 = default(Vector2);
									Vector2.GetLineIntersection(this.GetPointRotatedFromRelative(array3[1], new Vector2(array3[1].X, array3[1].Y + 5.0), 1.5707963267948966), array3[1], list3[0][0], list3[0][1], out item6);
									list4.Add(item6);
									flag2 = true;
								}
							}
							if (flag2)
							{
								Vector2 vector11 = new Vector2(-1.0, -1.0);
								if (!this.ShouldDisregardAsTooHighStep(collisionVector))
								{
									Vector2 vector12 = default(Vector2);
									Math.Sign(this.GroundVelocity);
									Math.Min(Math.Abs(this.GroundVelocity), 96.0);
									Vector2 vector13 = new Vector2(MathX.Clamp(-64.0, this.GroundVelocity * Math.Cos(0.0), 64.0), MathX.Clamp(-64.0, this.GroundVelocity * Math.Sin(0.0), 64.0));
									double num11 = 0.0;
									if (this.IsAirborne)
									{
										num11 = this.Velocity.Y;
									}
									else
									{
										num11 = vector13.Y;
									}
									double y = base.PositionPrecise.Y;
									double num12 = num3;
									double num13 = num4;
									if (collisionVector.Mode == CollisionMode.Top)
									{
										Vector2 vector14 = list4.First<Vector2>();
										foreach (Vector2 vector15 in list4.Skip(1))
										{
											if (vector15.Y > vector14.Y)
											{
												vector14 = vector15;
											}
										}
										vector11 = vector14;
										if (num11 >= 0.0)
										{
											vector12 = this.GetPointRotatedFromRelative(vector11, new Vector2(vector11.X - num6, vector11.Y), 1.5707963267948966 + this.GroundAngle);
											if (vector12.Y - y < num3)
											{
												num3 = vector12.Y - y;
												if (collisionVector != this.GroundVector && this.GroundVector != null)
												{
													if (collisionVector.Owner != null)
													{
														if (collisionVector.Owner.PositionPrecise != collisionVector.Owner.LastPositionPrecise)
														{
															this._overlappingGroundVector = collisionVector;
														}
													}
													else if (this.GroundVector.Owner != null)
													{
														this._overlappingGroundVector = collisionVector;
													}
													else if (collisionVector.Mode == this.Mode)
													{
														this._overlappingGroundVector = collisionVector;
													}
												}
											}
										}
									}
									else if (collisionVector.Mode == CollisionMode.Bottom)
									{
										Vector2 vector16 = list4.First<Vector2>();
										foreach (Vector2 vector17 in list4.Skip(1))
										{
											if (vector17.Y > vector16.Y)
											{
												vector16 = vector17;
											}
										}
										vector11 = vector16;
										if (num11 < 0.0)
										{
											vector12 = this.GetPointRotatedFromRelative(vector11, new Vector2(vector11.X + num6, vector11.Y), 1.5707963267948966 + this.GroundAngle);
											if (vector12.Y - y > num4)
											{
												num4 = vector12.Y - y;
											}
										}
									}
									if (!this.CheckSolidAngle(collisionVector, vector11, new Vector2(num5, num6)))
									{
										double distance2 = Vector2.GetDistance(pointRotatedFromRelative4, vector11);
										CollisionInfo collisionInfo2 = new CollisionInfo(collisionVector, vector11, distance2, collisionVector.Angle);
										CollisionEvent collisionEvent2 = new CollisionEvent(this, collisionInfo2);
										if (flag3 && this.GroundVector != null && (collisionVector.Mode == CollisionMode.Top || collisionVector.Mode == CollisionMode.Bottom) && collisionVector.Owner == null && !this.IsFlying)
										{
											this._collisionDetectedTiles[(int)collisionVector.Mode] = true;
											this._collisionEventsTiles[(int)collisionVector.Mode] = collisionEvent2;
										}
										else
										{
											if (collisionVector.Owner != null)
											{
												KeyValuePair<ActiveObject, CollisionEvent> keyValuePair = new KeyValuePair<ActiveObject, CollisionEvent>(collisionVector.Owner, collisionEvent2);
												this._collidedVectors.Add(keyValuePair);
												if (this._overlappingGroundVector != null)
												{
													if (collisionVector.Owner == this._overlappingGroundVector.Owner)
													{
														this._overlappingCollision = keyValuePair;
													}
													else
													{
														keyValuePair.Key.Collision(keyValuePair.Value);
													}
												}
												else
												{
													keyValuePair.Key.Collision(keyValuePair.Value);
												}
											}
											if (!collisionEvent2.IgnoreCollision)
											{
												this._collisionDetected[(int)collisionVector.Mode] = true;
												this._collisionEvents[(int)collisionVector.Mode] = collisionEvent2;
											}
											Vector2 positionPrecise2 = base.PositionPrecise;
											double num14 = 0.0;
											double num15 = 0.0;
											if (num12 != num3)
											{
												num14 = num3 - num12;
											}
											if (num13 != num4)
											{
												num15 = num4 - num13;
											}
											if (num14 != 0.0 || num15 != 0.0)
											{
												positionPrecise2.Y += num14;
												positionPrecise2.Y += num15;
												base.PositionPrecise = positionPrecise2;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x0003ABC4 File Offset: 0x00038DC4
		private void CheckOverlappingVector()
		{
			if (this._overlappingGroundVector != null && this._overlappingGroundVector != this.GroundVector && this.GroundVector != null && this._overlappingGroundVector.Mode == this.GroundVector.Mode && this._overlappingGroundVector != this.GroundVector.GetConnectionA(this.Path) && this._overlappingGroundVector != this.GroundVector.GetConnectionB(this.Path))
			{
				bool flag = true;
				if (this._overlappingGroundVector.Owner != null)
				{
					flag = this._overlappingGroundVector.Owner.CollisionVectors.Contains(this._overlappingGroundVector);
				}
				base.PositionPrecise = this.GetAlignmentForVector2(this._overlappingGroundVector, base.PositionPrecise, this._overlappingGroundVector.Angle);
				if (flag)
				{
					this.AcquireVector(this._overlappingGroundVector);
					if (this._overlappingGroundVector.Owner != null)
					{
						this.Land(false);
					}
					else
					{
						this.Land(true);
					}
					if (this._overlappingCollision.Key != null && this._overlappingCollision.Value != null)
					{
						this._overlappingCollision.Key.Collision(this._overlappingCollision.Value);
					}
				}
			}
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x0003ACFC File Offset: 0x00038EFC
		private bool IsAttachedToPlatform()
		{
			Vector2 a = default(Vector2);
			if (this.GroundVector != null && this.GroundVector.Flags.HasFlag(CollisionFlags.Conveyor))
			{
				if (this.GroundVector.Owner is IPlatform)
				{
					a = (this.GroundVector.Owner as IPlatform).Velocity;
				}
				else
				{
					a = this.GroundVector.Owner.PositionPrecise - this.GroundVector.Owner.LastPositionPrecise;
				}
			}
			return a != default(Vector2);
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x0003AD98 File Offset: 0x00038F98
		private void Bump(Vector2 collisionRadius)
		{
			Rectangle r = new Rectangle(base.PositionPrecise.X - 128.0, base.PositionPrecise.Y - 128.0, 256.0, 256.0);
			IEnumerable<CollisionVector> enumerable = base.Level.CollisionTable.GetPossibleCollisionIntersections(r, this.CheckLandscapeCollision, this.CheckObjectCollision);
			bool flag = this.IsAttachedToPlatform();
			if (Math.Abs(this.Velocity.X) >= Math.Abs(this.Velocity.Y) || flag)
			{
				enumerable = enumerable.OrderBy(delegate(CollisionVector t)
				{
					if (t.IsWall)
					{
						return 0;
					}
					if (t.Mode != CollisionMode.Top && t.Owner != null)
					{
						return 2;
					}
					return 1;
				});
			}
			else
			{
				enumerable = enumerable.OrderBy(delegate(CollisionVector t)
				{
					if (t.IsWall)
					{
						return 1;
					}
					if (t.Mode != CollisionMode.Top && t.Owner != null)
					{
						return 2;
					}
					return 0;
				});
			}
			enumerable = this.FixPosition(collisionRadius, enumerable);
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x0003AEA0 File Offset: 0x000390A0
		private bool ShouldDisregardAsTooHighStep(CollisionVector t)
		{
			bool result = false;
			if (this.Mode == t.Mode && Math.Abs(t.Bottom - (base.Position.Y + this.CollisionRadius.Y)) >= this.FloorSensorRadius)
			{
				result = true;
				if (t.Owner != null && t.Owner.PositionPrecise.Y - t.Owner.LastPositionPrecise.Y < 0.0)
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x0003AF2D File Offset: 0x0003912D
		private bool CanCollideWithVector(CollisionVector vector)
		{
			return vector.HasPath(this.Path);
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x0003AF40 File Offset: 0x00039140
		private double GetDistanceToVector(CollisionVector t)
		{
			return Vector2.GetDistance(base.PositionPrecise, t.Bounds.Centre);
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x0003AF6C File Offset: 0x0003916C
		public Vector2 GetProjectedPointOnLine(Vector2 v1, Vector2 v2, Vector2 point)
		{
			Vector2 result = point;
			Vector2 vector = new Vector2(v2.X - v1.X, v2.Y - v1.Y);
			Vector2 v3 = new Vector2(result.X - v1.X, result.Y - v1.Y);
			double num = vector.Dot(v3);
			double num2 = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			double num3 = Math.Sqrt(v3.X * v3.X + v3.Y * v3.Y);
			double num4 = num / (num2 * num3) * num3;
			result = new Vector2(v1.X + num4 * vector.X / num2, v1.Y + num4 * vector.Y / num2);
			return result;
		}

		// Token: 0x06000F5A RID: 3930 RVA: 0x0003B054 File Offset: 0x00039254
		public Vector2 GetProjectedPointOnLine2(Vector2 v1, Vector2 v2, Vector2 point)
		{
			Vector2 result = point;
			Vector2 vector = new Vector2(v2.X - v1.X, v2.Y - v1.Y);
			Vector2 v3 = new Vector2(result.X - v1.X, result.Y - v1.Y);
			double num = vector.Dot(v3);
			double num2 = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			double num3 = Math.Sqrt(v3.X * v3.X + v3.Y * v3.Y);
			double num4 = num / (num2 * num3) * num3;
			result = new Vector2(v1.X + num4 * vector.X / num2, v1.Y + num4 * vector.Y / num2);
			return result;
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x0003B13C File Offset: 0x0003933C
		private Vector2 GetAlignmentForVector(CollisionVector t, Vector2 alignmentPosition, double alignmentAngle)
		{
			int y = this.CollisionRadius.Y;
			this.GetPointRotatedFromRelative(alignmentPosition, new Vector2(alignmentPosition.X - (double)y, alignmentPosition.Y), 1.5707963267948966 + alignmentAngle);
			Vector2 pointRotatedFromRelative = this.GetPointRotatedFromRelative(alignmentPosition, new Vector2(alignmentPosition.X + (double)y, alignmentPosition.Y), 1.5707963267948966 + alignmentAngle);
			Vector2 pointRotatedFromRelative2 = this.GetPointRotatedFromRelative(pointRotatedFromRelative, new Vector2(pointRotatedFromRelative.X - (double)y, pointRotatedFromRelative.Y), 1.5707963267948966 + t.Angle);
			Vector2 pointRotatedFromRelative3 = this.GetPointRotatedFromRelative(pointRotatedFromRelative, new Vector2(pointRotatedFromRelative.X + (double)y, pointRotatedFromRelative.Y), 1.5707963267948966 + t.Angle);
			Vector2 relative = Character.Intersector.Intersection(t.AbsoluteB, t.AbsoluteA, pointRotatedFromRelative3, pointRotatedFromRelative2).FirstOrDefault<Vector2>();
			Vector2.GetLineIntersection(t.AbsoluteB, t.AbsoluteA, pointRotatedFromRelative3, pointRotatedFromRelative2, out relative);
			return this.GetPointRotatedFromRelative(relative, new Vector2(relative.X - (double)y, relative.Y), 1.5707963267948966 + t.Angle);
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x0003B27C File Offset: 0x0003947C
		public Vector2 GetAlignmentForVector2(CollisionVector t, Vector2 alignmentPosition, double alignmentAngle)
		{
			double num = (double)this.CollisionRadius.Y;
			Vector2 pointRotatedFromRelative = this.GetPointRotatedFromRelative(alignmentPosition, new Vector2(alignmentPosition.X - num, alignmentPosition.Y), 1.5707963267948966 + t.Angle);
			Vector2 pointRotatedFromRelative2 = this.GetPointRotatedFromRelative(alignmentPosition, new Vector2(alignmentPosition.X + num, alignmentPosition.Y), 1.5707963267948966 + t.Angle);
			Vector2 relative = Character.Intersector.Intersection(t.AbsoluteA, t.AbsoluteB, pointRotatedFromRelative, pointRotatedFromRelative2).FirstOrDefault<Vector2>();
			Vector2.GetLineIntersection(t.AbsoluteA, t.AbsoluteB, pointRotatedFromRelative, pointRotatedFromRelative2, out relative);
			return this.GetPointRotatedFromRelative(relative, new Vector2(relative.X - num, relative.Y), 1.5707963267948966 + t.Angle);
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x0003B36D File Offset: 0x0003956D
		private void AcquireVector(CollisionVector vector)
		{
			this.GroundVector = vector;
			this.Mode = vector.Mode;
			this.ObjectLink = vector.Owner;
		}

		// Token: 0x06000F5E RID: 3934 RVA: 0x0003B390 File Offset: 0x00039590
		private void UpdateCollisionsWithObjects()
		{
			int num = this.RectangleCollisionRadius.Y - this.NormalCollisionRadius.Y;
			Rectangle r = Rectangle.FromLTRB(base.PositionPrecise.X - (double)this.RectangleCollisionRadius.X, base.PositionPrecise.Y - (double)this.RectangleCollisionRadius.Y - (double)num, base.PositionPrecise.X + (double)this.RectangleCollisionRadius.X, base.PositionPrecise.Y + (double)this.RectangleCollisionRadius.Y - (double)num);
			foreach (ActiveObject activeObject in base.Level.ObjectManager.ActiveObjects)
			{
				foreach (CollisionRectangle collisionRectangle in activeObject.CollisionRectangles)
				{
					if (collisionRectangle.AbsoluteBounds.IntersectsWith(r))
					{
						activeObject.Collision(new CollisionEvent(this, collisionRectangle.Id));
					}
				}
			}
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x0003B4D8 File Offset: 0x000396D8
		private void UpdateDistanceFromLedge()
		{
			if (this.Mode == CollisionMode.Air || this.GroundVector == null)
			{
				this.DistanceFromLedge = 0.0;
				return;
			}
			if (this.Mode == CollisionMode.Left || this.Mode == CollisionMode.Right)
			{
				if (this.GroundVector.GetConnectionB(this.Path) == null)
				{
					double num = (base.PositionPrecise.Y - (double)this.GroundVector.AbsoluteB.Y) * (double)this.GroundVector.FlipY;
					if (num > 0.0)
					{
						this.DistanceFromLedge = num;
						return;
					}
				}
				if (this.GroundVector.GetConnectionA(this.Path) == null)
				{
					double num = (base.PositionPrecise.Y - (double)this.GroundVector.AbsoluteA.Y) * (double)this.GroundVector.FlipY;
					if (num < 0.0)
					{
						this.DistanceFromLedge = num;
						return;
					}
				}
			}
			else
			{
				if (this.GroundVector.GetConnectionB(this.Path) == null)
				{
					double num = (base.PositionPrecise.X - (double)this.GroundVector.AbsoluteB.X) * (double)this.GroundVector.FlipX;
					if (num > 0.0)
					{
						this.DistanceFromLedge = num;
						return;
					}
				}
				if (this.GroundVector.GetConnectionA(this.Path) == null)
				{
					double num = (base.PositionPrecise.X - (double)this.GroundVector.AbsoluteA.X) * (double)this.GroundVector.FlipX;
					if (num < 0.0)
					{
						this.DistanceFromLedge = num;
						return;
					}
				}
			}
			this.DistanceFromLedge = 0.0;
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x0003B690 File Offset: 0x00039890
		private void AdjustForPlatform(CollisionVector vector)
		{
			this._lastPositionAdjusted = base.PositionPrecise;
			if (vector != null && vector != this.GroundVector)
			{
				IPlatform platform = vector.Owner as IPlatform;
				if (platform != null)
				{
					Vector2 velocity = platform.Velocity;
					this._lastPositionAdjusted += velocity;
				}
				else if (vector.Owner != null)
				{
					Vector2 b = vector.Owner.PositionPrecise - vector.Owner.LastPositionPrecise;
					this._lastPositionAdjusted += b;
				}
				if (this.GroundVector != null && !this.IsAirborne)
				{
					base.PositionPrecise = this._lastPositionAdjusted;
					base.PositionPrecise = this.GetAlignmentForVector2(this.GroundVector, base.PositionPrecise, vector.Angle);
				}
			}
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x0003B758 File Offset: 0x00039958
		private void AddPlatformVelocity()
		{
			if (this.GroundVector == null)
			{
				return;
			}
			if (!this.GroundVector.Flags.HasFlag(CollisionFlags.Conveyor))
			{
				return;
			}
			Vector2 b = default(Vector2);
			bool flag = false;
			if (this.GroundVector.Owner is IPlatform)
			{
				b = (this.GroundVector.Owner as IPlatform).Velocity;
			}
			else
			{
				Vector2.GetDistance(base.PositionPrecise, this.GroundVector.Bounds.Centre);
				flag = !this.GroundVector.Flags.HasFlag(CollisionFlags.NoAutoAlignment);
			}
			Vector2 b2 = this.GroundVector.Owner.PositionPrecise - this.GroundVector.Owner.Position;
			base.PositionPrecise = base.Position + b2;
			this.Velocity += b;
			if (flag)
			{
				base.PositionPrecise = this.GetAlignmentForVector2(this.GroundVector, base.PositionPrecise, this.GroundAngle);
			}
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x0003B87C File Offset: 0x00039A7C
		private void RemovePlatformVelocity()
		{
			if (this.GroundVector == null)
			{
				return;
			}
			if (!this.GroundVector.Flags.HasFlag(CollisionFlags.Conveyor))
			{
				return;
			}
			Vector2 b = default(Vector2);
			if (this.GroundVector.Owner is IPlatform)
			{
				b = (this.GroundVector.Owner as IPlatform).Velocity;
			}
			else
			{
				b = this.GroundVector.Owner.PositionPrecise - this.GroundVector.Owner.LastPositionPrecise;
			}
			this.Velocity -= b;
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x0003B91C File Offset: 0x00039B1C
		private bool IsCrushedBetweenFloors(Vector2[][] collisionBox, CollisionEvent top, CollisionEvent bottom)
		{
			bool result = false;
			Rectangle rectangle = Rectangle.FromLTRB(collisionBox[0][0].X, collisionBox[0][0].Y, collisionBox[1][0].X, collisionBox[1][0].Y);
			if (top != null)
			{
				Vector2 touch = top.CollisionInfo.Touch;
				if (rectangle.Contains(touch))
				{
					result = true;
				}
			}
			if (bottom != null)
			{
				Vector2 touch2 = bottom.CollisionInfo.Touch;
				if (rectangle.Contains(touch2))
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x0003B9A0 File Offset: 0x00039BA0
		private void CheckCrushed()
		{
			bool flag = this._collisionDetected[0] && this._collisionDetected[2];
			bool flag2 = this._collisionDetected[0] && this._collisionDetectedTiles[2];
			bool flag3 = this._collisionDetectedTiles[0] && this._collisionDetected[2];
			bool flag4 = this._collisionDetected[1] && this._collisionDetected[3];
			bool flag5 = false;
			Vector2[][] collisionBox = this.GetCollisionBox(new Vector2((double)(this.CollisionRadius.X - this.LedgeSensorRadius), (double)this.CollisionRadius.Y), false);
			if (flag)
			{
				CollisionEvent collisionEvent = this._collisionEvents[0];
				CollisionEvent collisionEvent2 = this._collisionEvents[2];
				if (collisionEvent.CollisionInfo.Vector != null && collisionEvent2.CollisionInfo.Vector != null && ((collisionEvent.CollisionInfo.Vector.Owner != null && collisionEvent2.CollisionInfo.Vector.Owner != null) || (collisionEvent.CollisionInfo.Vector.Owner != null && collisionEvent2.CollisionInfo.Vector.Owner == null) || (collisionEvent.CollisionInfo.Vector.Owner == null && collisionEvent2.CollisionInfo.Vector.Owner != null)) && collisionEvent.CollisionInfo.Vector.Owner != collisionEvent2.CollisionInfo.Vector.Owner)
				{
					bool flag6 = true;
					if (collisionEvent.CollisionInfo.Vector.Owner != null)
					{
						flag6 = (collisionEvent.CollisionInfo.Vector.Owner.PositionPrecise != collisionEvent.CollisionInfo.Vector.Owner.LastPositionPrecise);
					}
					if (collisionEvent2.CollisionInfo.Vector.Owner != null)
					{
						flag6 = (collisionEvent2.CollisionInfo.Vector.Owner.PositionPrecise != collisionEvent2.CollisionInfo.Vector.Owner.LastPositionPrecise || flag6);
					}
					if (flag6)
					{
						flag5 = this.IsCrushedBetweenFloors(collisionBox, collisionEvent, collisionEvent2);
					}
				}
			}
			else if (flag2)
			{
				CollisionEvent collisionEvent3 = this._collisionEvents[0];
				CollisionEvent bottom = this._collisionEventsTiles[2];
				if (collisionEvent3.CollisionInfo.Vector != null && collisionEvent3.CollisionInfo.Vector.Owner != null && collisionEvent3.CollisionInfo.Vector.Owner.PositionPrecise != collisionEvent3.CollisionInfo.Vector.Owner.LastPositionPrecise)
				{
					flag5 = this.IsCrushedBetweenFloors(collisionBox, collisionEvent3, bottom);
				}
			}
			else if (flag3)
			{
				CollisionEvent top = this._collisionEventsTiles[0];
				CollisionEvent collisionEvent4 = this._collisionEvents[2];
				if (collisionEvent4.CollisionInfo.Vector != null && collisionEvent4.CollisionInfo.Vector.Owner != null && collisionEvent4.CollisionInfo.Vector.Owner.PositionPrecise != collisionEvent4.CollisionInfo.Vector.Owner.LastPositionPrecise)
				{
					flag5 = this.IsCrushedBetweenFloors(collisionBox, top, collisionEvent4);
				}
			}
			if (flag4)
			{
				Rectangle rectangle = Rectangle.FromLTRB(collisionBox[0][0].X, collisionBox[0][0].Y, collisionBox[1][0].X, collisionBox[1][0].Y);
				CollisionEvent collisionEvent5 = this._collisionEvents[1];
				CollisionEvent collisionEvent6 = this._collisionEvents[3];
				if (collisionEvent5 != null && collisionEvent5.CollisionInfo.Vector != null && collisionEvent5.CollisionInfo.Vector.Owner != null && collisionEvent5.CollisionInfo.Vector.Owner.PositionPrecise != collisionEvent5.CollisionInfo.Vector.Owner.LastPositionPrecise)
				{
					Vector2 touch = this._collisionEvents[1].CollisionInfo.Touch;
					if (rectangle.Contains(touch))
					{
						flag5 = true;
					}
				}
				if (collisionEvent6 != null && collisionEvent6.CollisionInfo.Vector != null && collisionEvent6.CollisionInfo.Vector.Owner != null && collisionEvent6.CollisionInfo.Vector.Owner.PositionPrecise != collisionEvent6.CollisionInfo.Vector.Owner.LastPositionPrecise)
				{
					Vector2 touch2 = this._collisionEvents[3].CollisionInfo.Touch;
					if (rectangle.Contains(touch2))
					{
						flag5 = true;
					}
				}
			}
			if (flag5)
			{
				this.Kill(PlayerDeathCause.Crushed);
			}
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x0003BE18 File Offset: 0x0003A018
		private static bool IsObjectMovingTowardsCollisionMode(IActiveObject obj, CollisionMode mode)
		{
			Vector2 vector = obj.PositionPrecise - obj.LastPositionPrecise;
			switch (mode)
			{
			case CollisionMode.Top:
				return vector.Y < 0.0;
			case CollisionMode.Left:
				return vector.X < 0.0;
			case CollisionMode.Bottom:
				return vector.Y > 0.0;
			case CollisionMode.Right:
				return vector.X > 0.0;
			default:
				return false;
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000F66 RID: 3942 RVA: 0x0003BE9C File Offset: 0x0003A09C
		// (set) Token: 0x06000F67 RID: 3943 RVA: 0x0003BEA4 File Offset: 0x0003A0A4
		public bool CanFly { get; set; }

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000F68 RID: 3944 RVA: 0x0003BEAD File Offset: 0x0003A0AD
		// (set) Token: 0x06000F69 RID: 3945 RVA: 0x0003BEB5 File Offset: 0x0003A0B5
		public Player Player { get; set; }

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0003BEBE File Offset: 0x0003A0BE
		// (set) Token: 0x06000F6B RID: 3947 RVA: 0x0003BEC6 File Offset: 0x0003A0C6
		public CharacterInputState Input { get; set; }

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000F6C RID: 3948 RVA: 0x0003BECF File Offset: 0x0003A0CF
		public int MovingDirection
		{
			get
			{
				return Math.Sign(this.Input.HorizontalDirection);
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000F6D RID: 3949 RVA: 0x0003BEE1 File Offset: 0x0003A0E1
		// (set) Token: 0x06000F6E RID: 3950 RVA: 0x0003BEE9 File Offset: 0x0003A0E9
		public CharacterLookDirection LookDirection { get; set; }

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000F6F RID: 3951 RVA: 0x0003BEF2 File Offset: 0x0003A0F2
		// (set) Token: 0x06000F70 RID: 3952 RVA: 0x0003BEFA File Offset: 0x0003A0FA
		public int LookDelay { get; set; }

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000F71 RID: 3953 RVA: 0x0003BF03 File Offset: 0x0003A103
		// (set) Token: 0x06000F72 RID: 3954 RVA: 0x0003BF0B File Offset: 0x0003A10B
		public double GroundVelocity { get; set; }

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000F73 RID: 3955 RVA: 0x0003BF14 File Offset: 0x0003A114
		// (set) Token: 0x06000F74 RID: 3956 RVA: 0x0003BF1C File Offset: 0x0003A11C
		public Vector2 Velocity { get; set; }

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000F75 RID: 3957 RVA: 0x0003BF25 File Offset: 0x0003A125
		// (set) Token: 0x06000F76 RID: 3958 RVA: 0x0003BF2D File Offset: 0x0003A12D
		public double Acceleration { get; set; }

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000F77 RID: 3959 RVA: 0x0003BF36 File Offset: 0x0003A136
		// (set) Token: 0x06000F78 RID: 3960 RVA: 0x0003BF3E File Offset: 0x0003A13E
		private double Deceleration { get; set; }

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000F79 RID: 3961 RVA: 0x0003BF47 File Offset: 0x0003A147
		// (set) Token: 0x06000F7A RID: 3962 RVA: 0x0003BF4F File Offset: 0x0003A14F
		private double Friction { get; set; }

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000F7B RID: 3963 RVA: 0x0003BF58 File Offset: 0x0003A158
		// (set) Token: 0x06000F7C RID: 3964 RVA: 0x0003BF60 File Offset: 0x0003A160
		private double TopSpeed { get; set; }

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000F7D RID: 3965 RVA: 0x0003BF69 File Offset: 0x0003A169
		// (set) Token: 0x06000F7E RID: 3966 RVA: 0x0003BF71 File Offset: 0x0003A171
		private double JumpForce { get; set; }

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000F7F RID: 3967 RVA: 0x0003BF7A File Offset: 0x0003A17A
		// (set) Token: 0x06000F80 RID: 3968 RVA: 0x0003BF82 File Offset: 0x0003A182
		private double JumpReleaseForce { get; set; }

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000F81 RID: 3969 RVA: 0x0003BF8B File Offset: 0x0003A18B
		// (set) Token: 0x06000F82 RID: 3970 RVA: 0x0003BF93 File Offset: 0x0003A193
		private double Gravity { get; set; }

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x0003BF9C File Offset: 0x0003A19C
		// (set) Token: 0x06000F84 RID: 3972 RVA: 0x0003BFA4 File Offset: 0x0003A1A4
		public int SlopeLockTicks { get; set; }

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000F85 RID: 3973 RVA: 0x0003BFAD File Offset: 0x0003A1AD
		// (set) Token: 0x06000F86 RID: 3974 RVA: 0x0003BFB5 File Offset: 0x0003A1B5
		public CharacterEvent CharacterEvents { get; set; }

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000F87 RID: 3975 RVA: 0x0003BFBE File Offset: 0x0003A1BE
		// (set) Token: 0x06000F88 RID: 3976 RVA: 0x0003BFC6 File Offset: 0x0003A1C6
		public BarrierType Barrier { get; set; }

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000F89 RID: 3977 RVA: 0x0003BFCF File Offset: 0x0003A1CF
		// (set) Token: 0x06000F8A RID: 3978 RVA: 0x0003BFD7 File Offset: 0x0003A1D7
		public bool HasPerformedBarrierAttack { get; set; }

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000F8B RID: 3979 RVA: 0x0003BFE0 File Offset: 0x0003A1E0
		// (set) Token: 0x06000F8C RID: 3980 RVA: 0x0003BFE8 File Offset: 0x0003A1E8
		public bool HasSuperAbility { get; set; }

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000F8D RID: 3981 RVA: 0x0003BFF1 File Offset: 0x0003A1F1
		// (set) Token: 0x06000F8E RID: 3982 RVA: 0x0003BFF9 File Offset: 0x0003A1F9
		public bool HasHyperAbility { get; set; }

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000F8F RID: 3983 RVA: 0x0003C002 File Offset: 0x0003A202
		// (set) Token: 0x06000F90 RID: 3984 RVA: 0x0003C00A File Offset: 0x0003A20A
		public bool Jumped { get; set; }

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x0003C013 File Offset: 0x0003A213
		// (set) Token: 0x06000F92 RID: 3986 RVA: 0x0003C01B File Offset: 0x0003A21B
		public CharacterSpecialState SpecialState { get; set; }

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x0003C024 File Offset: 0x0003A224
		public bool HasBarrier
		{
			get
			{
				return this.Barrier > BarrierType.None;
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000F94 RID: 3988 RVA: 0x0003C02F File Offset: 0x0003A22F
		public IReadOnlyList<CharacterHistoryItem> History
		{
			get
			{
				return this._history;
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x0003C037 File Offset: 0x0003A237
		public bool IsDeadly
		{
			get
			{
				return this.IsSpinball || this.IsCharging || this.IsInvincible;
			}
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x0003C054 File Offset: 0x0003A254
		public Character()
		{
			this.Input = new CharacterInputState();
			this.SetDefaultConstants();
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x0003C0D8 File Offset: 0x0003A2D8
		protected override void OnStart()
		{
			ResourceTree resourceTree = base.ResourceTree;
			this.Animation = new AnimationInstance(resourceTree.GetLoadedResource<AnimationGroup>(this.AnimationGroupResourceKey), 0);
			this.SpindashDustGroupResourceKey = "SONICORCA/OBJECTS/SPINDASH/ANIGROUP";
			this.SpindashDustAnimation = new AnimationInstance(resourceTree.GetLoadedResource<AnimationGroup>(this.SpindashDustGroupResourceKey), 0);
			this.BrakeDustResourceKey = "SONICORCA/OBJECTS/DUST";
			this.InvincibilityGroupResourceKey = "SONICORCA/OBJECTS/INVINCIBILITY/ANIGROUP";
			this._drowningAnimation = new AnimationInstance(resourceTree, "SONICORCA/HUD/DROWNING/ANIGROUP", 0);
			base.Priority = 1024;
			this.StateFlags = (CharacterState)0;
			this.ShowAngle = 0.0;
			this.GroundVelocity = 0.0;
			this.Velocity = new Vector2(0.0, 0.0);
			this.SlopeLockTicks = 0;
			this.LookDirection = CharacterLookDirection.Normal;
			this.BreathTicks = 1800;
			this.CollisionRadius = this.NormalCollisionRadius;
			this.CheckCollision = true;
			this.CheckLandscapeCollision = true;
			this.CheckObjectCollision = true;
			this.InvulnerabilityTicks = 0;
			this.InitialiseInvincibility();
			this.Mode = CollisionMode.Air;
			this._autoSidekickState = Character.AutoSidekickState.Normal;
			this.ShouldReactToLevel = true;
			this.SpecialState = CharacterSpecialState.Normal;
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x00006325 File Offset: 0x00004525
		protected override void OnStop()
		{
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x0003C200 File Offset: 0x0003A400
		protected override void OnUpdate()
		{
			this.RecordHistory();
			this.HandleInput();
			if (this.IsDebug)
			{
				this.ShouldReactToLevel = false;
				this.UpdateDebugState();
				return;
			}
			if (this.IsDying)
			{
				this.ShouldReactToLevel = false;
				this.UpdateDying();
				this.UpdateWaterLogic();
				return;
			}
			if (this.IsSidekick)
			{
				this.UpdateSidekick();
				return;
			}
			this.ShouldReactToLevel = true;
			this.UpdateNormal();
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x0003C268 File Offset: 0x0003A468
		private void SetDefaultConstants()
		{
			this.LedgeSensorRadius = 9;
			this.NormalCollisionRadius = new Vector2i(40, 60);
			this.RectangleCollisionRadius = new Vector2i(44, 76);
			this.SpinballCollisionRadius = new Vector2i(34, 56);
			this.FloorSensorRadius = 32;
			this.CollisionSensorSize = 1;
			this.Path = 1;
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x0003C2C0 File Offset: 0x0003A4C0
		public void HandleInput()
		{
			if (this.IsWinning || this.IsHurt || this.IsObjectControlled)
			{
				this.Input.Clear();
				this.LookDirection = CharacterLookDirection.Normal;
				return;
			}
			this.LookDirection = CharacterLookDirection.Normal;
			if (!this.IsAirborne && !this.IsSpinball && this._balanceDirection == CharacterBalanceDirection.None)
			{
				double throttle = this.Input.Throttle;
				double num = (double)this.Input.VerticalDirection;
				if (Math.Abs(num) > Math.Abs(throttle))
				{
					if (num <= -0.5)
					{
						this.LookDirection = CharacterLookDirection.Up;
					}
					else if (num >= 0.5)
					{
						this.LookDirection = CharacterLookDirection.Ducking;
					}
					this.Input.Throttle = 0.0;
				}
			}
			if (base.Level.ClassicDebugMode)
			{
				if (this.Input.B == CharacterInputButtonState.Pressed)
				{
					this.GroundVelocity += (double)(64 * this.Facing);
				}
				if (this.Input.C == CharacterInputButtonState.Pressed)
				{
					this.IsDebug = !this.IsDebug;
					this.LeaveGround();
				}
				this.Input.B = CharacterInputButtonState.Up;
				this.Input.C = CharacterInputButtonState.Up;
			}
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0003C3E7 File Offset: 0x0003A5E7
		private void RecordHistory()
		{
			Array.Copy(this._history, 0, this._history, 1, this._history.Length - 1);
			this._history[0] = new CharacterHistoryItem(base.PositionPrecise, this.StateFlags, this.Input);
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x0003C428 File Offset: 0x0003A628
		private void UpdateNormal()
		{
			if (this.IsWinning)
			{
				this.GroundVelocity = 0.0;
			}
			this.UpdateVariables();
			this.UpdateMovement();
			this.UpdateSpindash();
			this.UpdateSpinning();
			this.UpdateJumping();
			this.UpdateFalling();
			this.UpdatePosition();
			this.UpdateBalance();
			this.UpdateLooking();
			this.UpdatePushing();
			this.UpdateWaterLogic();
			if (this.InvulnerabilityTicks > 0)
			{
				int invulnerabilityTicks = this.InvulnerabilityTicks;
				this.InvulnerabilityTicks = invulnerabilityTicks - 1;
			}
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0003C4A8 File Offset: 0x0003A6A8
		protected override void OnUpdateCollision()
		{
			if (this.IsSidekick && (this._autoSidekickState == Character.AutoSidekickState.Spawning || this._autoSidekickState == Character.AutoSidekickState.Flying))
			{
				return;
			}
			if (!this.IsDebug && !this.IsDying && !this.IsDead)
			{
				this.ProcessCollision();
			}
			if (!this.IsDying && !this.IsDead)
			{
				this.ApplyLevelBounds();
			}
			this.SetCameraTracking();
			this.CharacterEvents &= ~CharacterEvent.Hurt;
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x0003C518 File Offset: 0x0003A718
		private void UpdateVariables()
		{
			this.Acceleration = 0.1875;
			this.Deceleration = 2.0;
			this.Friction = this.Acceleration;
			this.TopSpeed = 24.0;
			this.JumpForce = 26.0;
			this.JumpReleaseForce = 16.0;
			this.Gravity = 0.875;
			if (this.HasSpeedShoes)
			{
				this.Acceleration = 0.375;
				this.Friction = 0.375;
				this.TopSpeed = 48.0;
			}
			if (this.Mode == CollisionMode.Air)
			{
				if (this.IsRollJumping)
				{
					this.Acceleration = 0.0;
				}
				else
				{
					this.Acceleration *= 2.0;
				}
			}
			else if (this.IsSpinball)
			{
				this.Acceleration = 0.0;
				this.Deceleration = 0.5;
				this.Friction /= 2.0;
			}
			else if (this.MovingDirection != 0)
			{
				this.Friction = 0.0;
			}
			if (this.IsUnderwater)
			{
				this.Acceleration *= 0.5;
				this.Deceleration *= 0.5;
				this.Friction *= 0.5;
				this.TopSpeed *= 0.5;
				this.JumpForce *= 0.5384615384615384;
				this.JumpReleaseForce *= 0.5;
				this.Gravity = 0.25;
			}
			if (this.IsHurt)
			{
				this.Gravity = 0.75;
				this.Acceleration = 0.0;
				this.Deceleration = 0.0;
			}
			else if (this.IsCharging)
			{
				this.Acceleration = 0.0;
				this.Deceleration = 0.0;
			}
			if (this.SlopeLockTicks != 0)
			{
				if (this.Mode == CollisionMode.Air)
				{
					this.SlopeLockTicks = 0;
					return;
				}
				int slopeLockTicks = this.SlopeLockTicks;
				this.SlopeLockTicks = slopeLockTicks - 1;
				this.Deceleration = 0.0;
			}
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x0003C784 File Offset: 0x0003A984
		private void UpdateMovement()
		{
			if (this.Mode == CollisionMode.Air)
			{
				Vector2 velocity = this.Velocity;
				if (this.MovingDirection != 0)
				{
					velocity.X = Character.ChangeSpeed(velocity.X, this.MovingDirection, this.TopSpeed, this.Acceleration, this.Acceleration, 0.0);
					this.Facing = this.MovingDirection;
				}
				velocity.Y = Character.ChangeSpeed(velocity.Y, 1, 64.0, this.Gravity, this.Gravity, 0.0);
				if (velocity.Y < 0.0 && velocity.Y > -this.JumpReleaseForce)
				{
					velocity.X *= 0.96875;
				}
				this.Velocity = velocity;
				return;
			}
			if (!this.IsCharging)
			{
				this.ApplySlopeFriction();
			}
			this.GroundVelocity = Character.ChangeSpeed(this.GroundVelocity, this.MovingDirection, this.TopSpeed, this.Acceleration, this.Deceleration, this.Friction);
			if ((double)this.MovingDirection * this.GroundVelocity > 0.0)
			{
				this.Facing = this.MovingDirection;
			}
			this.UpdateBraking();
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x0003C8C8 File Offset: 0x0003AAC8
		private void UpdateBraking()
		{
			if (this.MovingDirection == Math.Sign(this.GroundVelocity) || this.GroundVelocity == 0.0 || this.Acceleration == 0.0 || this.IsSpinball || this.SlopeLockTicks > 0)
			{
				this.IsBraking = false;
				return;
			}
			if (!this.IsBraking && this.MovingDirection != 0 && Math.Abs(this.GroundVelocity) >= 16.0)
			{
				this.IsBraking = true;
				this._brakeDustDelay = 0;
				this._brakeTicks = 33;
				base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/BRAKE");
			}
			if (this.IsBraking)
			{
				this._brakeTicks--;
				if (this._brakeTicks == 0)
				{
					this.IsBraking = false;
					return;
				}
				this._brakeDustDelay--;
				if (this._brakeDustDelay <= 0)
				{
					this._brakeDustDelay = 6;
					base.Level.ObjectManager.AddObject(new ObjectPlacement(this.BrakeDustResourceKey, base.Level.Map.Layers.IndexOf(base.Layer), new Vector2i(base.Position.X, base.Position.Y + this.CollisionRadius.Y)));
				}
				if (Math.Abs(this.GroundVelocity) < 4.0)
				{
					this.IsBraking = false;
				}
			}
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x0003CA40 File Offset: 0x0003AC40
		private void ApplySlopeFriction()
		{
			if (this.GroundVector == null || this.GroundVector.Flags.HasFlag(CollisionFlags.NoAngle))
			{
				return;
			}
			if (this.GroundAngle == 0.0)
			{
				return;
			}
			double num = -Math.Sin(this.GroundAngle);
			if (this.IsSpinball)
			{
				if (this.GroundVelocity * num > 0.0)
				{
					num *= 0.2873;
				}
				else
				{
					num *= 1.25;
				}
			}
			else
			{
				num *= 0.5;
				if (this.GroundVelocity == 0.0 && Math.Abs(num) <= 0.05)
				{
					return;
				}
			}
			double groundVelocity = this.GroundVelocity;
			this.GroundVelocity -= num;
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x0003CB14 File Offset: 0x0003AD14
		private void UpdateSpindash()
		{
			if (this.IsCharging)
			{
				this.LookDelay = 120;
				this._spindashExtraSpeed *= 0.96875;
				if (this.Input.ABC == CharacterInputButtonState.Pressed)
				{
					this._spindashExtraSpeed = Math.Min(this._spindashExtraSpeed + 4.0, 16.0);
					base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/SPINDASH/CHARGE");
				}
				if (this.LookDirection != CharacterLookDirection.Ducking)
				{
					this.IsCharging = false;
					this.GroundVelocity = (32.0 + this._spindashExtraSpeed) * (double)this.Facing;
					this.CharacterEvents |= CharacterEvent.SpindashLaunch;
					base.CameraProperties.Delay = new Vector2i(16, base.CameraProperties.Delay.Y);
					base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/SPINDASH/RELEASE");
					return;
				}
			}
			else if (!this.IsSpinball && this.Mode != CollisionMode.Air && this.LookDirection == CharacterLookDirection.Ducking && this.Input.ABC == CharacterInputButtonState.Pressed)
			{
				this.IsCharging = true;
				this._spindashExtraSpeed = 0.0;
				base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/SPINDASH/CHARGE");
			}
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x0003CC64 File Offset: 0x0003AE64
		private void UpdateSpinning()
		{
			if (this.Mode == CollisionMode.Air)
			{
				return;
			}
			if (this.GroundVector != null && this.GroundVector.Flags.HasFlag(CollisionFlags.ForceRoll))
			{
				this.UpdateSpinningForced();
				return;
			}
			if (this.IsSpinball)
			{
				if (Math.Abs(this.GroundVelocity) < 2.0)
				{
					this.IsSpinball = false;
					return;
				}
			}
			else if ((this.LookDirection == CharacterLookDirection.Ducking || this.CharacterEvents.HasFlag(CharacterEvent.SpindashLaunch)) && Math.Abs(this.GroundVelocity) > 4.0)
			{
				this.IsSpinball = true;
				if (this.CharacterEvents.HasFlag(CharacterEvent.SpindashLaunch))
				{
					this.CharacterEvents &= ~CharacterEvent.SpindashLaunch;
					return;
				}
				base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/SPINBALL");
			}
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x0003CD50 File Offset: 0x0003AF50
		private void UpdateSpinningForced()
		{
			if (!this.IsSpinball)
			{
				this.IsSpinball = true;
				base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/SPINBALL");
			}
			if (Math.Abs(this.GroundVelocity) < 2.0 && !this.ShouldFallOffGround())
			{
				int num = Math.Sign(this.GroundVelocity);
				if (num == 0)
				{
					num = this.Facing;
				}
				this.GroundVelocity = (double)(16 * num);
			}
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x0003CDC4 File Offset: 0x0003AFC4
		private void UpdateJumping()
		{
			if (this.IsHurt)
			{
				return;
			}
			if (this.IsJumping)
			{
				if (!this.Input.ABC.HasFlag(CharacterInputButtonState.Down))
				{
					if (this.Velocity.Y < -this.JumpReleaseForce)
					{
						this.Velocity = new Vector2(this.Velocity.X, -this.JumpReleaseForce);
					}
					this.IsJumping = false;
					return;
				}
			}
			else if (this.Input.ABC == CharacterInputButtonState.Pressed && !this.IsCharging)
			{
				if (this.Mode == CollisionMode.Air)
				{
					if (this.Jumped)
					{
						if (this.CanFly && this._humanControlled)
						{
							this.CharacterEvents |= CharacterEvent.Fly;
							return;
						}
						if (this.Barrier != BarrierType.None && this.Barrier != BarrierType.Classic)
						{
							if (!this.HasPerformedBarrierAttack)
							{
								this.HasPerformedBarrierAttack = true;
								this.CharacterEvents |= CharacterEvent.BarrierAttack;
								return;
							}
						}
						else if (base.Level.ClassicDebugMode && this.IsSpinball)
						{
							this.IsJumping = true;
							this.CharacterEvents |= CharacterEvent.DoubleJump;
							base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/JUMP");
							return;
						}
					}
				}
				else if (this.GroundVector != null && !this.GroundVector.Flags.HasFlag(CollisionFlags.PreventJump))
				{
					this.Jumped = true;
					this.IsJumping = true;
					if (!this.IsAirborne && this.IsSpinball)
					{
						this.IsRollJumping = true;
					}
					this.IsSpinball = true;
					this.CharacterEvents |= CharacterEvent.Fall;
					this.CharacterEvents |= CharacterEvent.Jump;
					base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/JUMP");
				}
			}
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x0003CF94 File Offset: 0x0003B194
		private void UpdateFalling()
		{
			if (this.Mode == CollisionMode.Top)
			{
				return;
			}
			if (this.Mode == CollisionMode.Air)
			{
				return;
			}
			if (Math.Abs(this.GroundVelocity) >= 10.0)
			{
				return;
			}
			if ((this.GroundVector == null || !this.GroundVector.Flags.HasFlag(CollisionFlags.DontFall)) && this.ShouldFallOffGround())
			{
				this.CharacterEvents |= CharacterEvent.Fall;
				return;
			}
			if (this.SlopeLockTicks == 0)
			{
				this.SlopeLockTicks = 32;
			}
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x0003D01B File Offset: 0x0003B21B
		private bool ShouldFallOffGround()
		{
			return Math.Cos(this.GroundAngle) <= 0.0001;
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x0003D038 File Offset: 0x0003B238
		private void UpdatePosition()
		{
			if (this.Mode != CollisionMode.Air)
			{
				this.GroundVelocity = (double)Math.Sign(this.GroundVelocity) * Math.Min(Math.Abs(this.GroundVelocity), 96.0);
				this.Velocity = new Vector2(MathX.Clamp(-64.0, this.GroundVelocity * Math.Cos(this.GroundAngle), 64.0), MathX.Clamp(-64.0, this.GroundVelocity * Math.Sin(this.GroundAngle), 64.0));
				this.AddPlatformVelocity();
				if (this.CharacterEvents.HasFlag(CharacterEvent.Jump))
				{
					double num = this.GroundAngle;
					if (this.GroundVector.Flags.HasFlag(CollisionFlags.NoAngle))
					{
						num = 0.0;
					}
					this.Velocity += new Vector2(this.JumpForce * Math.Sin(num), this.JumpForce * -Math.Cos(num));
					this.CharacterEvents &= ~CharacterEvent.Jump;
				}
				if (this.CharacterEvents.HasFlag(CharacterEvent.Fall))
				{
					this.LeaveGround();
					this.CharacterEvents &= ~CharacterEvent.Fall;
				}
			}
			this.CharacterEvents.HasFlag(CharacterEvent.Fly);
			if (this.CharacterEvents.HasFlag(CharacterEvent.BarrierAttack))
			{
				switch (this.Barrier)
				{
				case BarrierType.Bubble:
					this.Velocity = new Vector2(0.0, 32.0);
					break;
				case BarrierType.Fire:
					this.Velocity = new Vector2((double)(32 * this.Facing), 0.0);
					break;
				case BarrierType.Lightning:
					this.Velocity = new Vector2(this.Velocity.X, -22.0);
					break;
				}
				this.CharacterEvents &= ~CharacterEvent.BarrierAttack;
			}
			if (this.CharacterEvents.HasFlag(CharacterEvent.DoubleJump))
			{
				this.Velocity = new Vector2(this.Velocity.X, Math.Min(this.Velocity.Y, -this.JumpForce));
				this.CharacterEvents &= ~CharacterEvent.DoubleJump;
			}
			this.Velocity = new Vector2((double)Math.Sign(this.Velocity.X) * Math.Min(Math.Abs(this.Velocity.X), 96.0), (double)Math.Sign(this.Velocity.Y) * Math.Min(Math.Abs(this.Velocity.Y), 96.0));
			bool flag = this._collisionEvents[3] != null;
			bool flag2 = this._collisionEvents[1] != null;
			double y = 0.0;
			bool flag3 = this.IsAttachedToPlatform();
			if (this.IsPushing && !flag3)
			{
				if (flag && this._collisionEvents[3].CollisionInfo.Vector.Flags.HasFlag(CollisionFlags.Mobile))
				{
					y = this.Velocity.Y;
				}
				if (flag2 && this._collisionEvents[1].CollisionInfo.Vector.Flags.HasFlag(CollisionFlags.Mobile))
				{
					y = this.Velocity.Y;
				}
			}
			else
			{
				y = this.Velocity.Y;
			}
			base.PositionPrecise += new Vector2(this.Velocity.X, y);
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x0003D41C File Offset: 0x0003B61C
		private void UpdateBalance()
		{
			if (this.Mode == CollisionMode.Air || this.GroundVelocity != 0.0)
			{
				this._balanceDirection = CharacterBalanceDirection.None;
				return;
			}
			if (this.GroundVector.Flags.HasFlag(CollisionFlags.NoBalance))
			{
				this._balanceDirection = CharacterBalanceDirection.None;
				return;
			}
			int num = Math.Sign(this.DistanceFromLedge);
			double num2 = Math.Abs(this.DistanceFromLedge);
			if (num2 > (double)this.LedgeSensorRadius)
			{
				this._balanceDirection = (CharacterBalanceDirection)(2 * num);
				this.Facing = num;
				return;
			}
			if (num2 > 0.0)
			{
				this._balanceDirection = (CharacterBalanceDirection)num;
				return;
			}
			this._balanceDirection = CharacterBalanceDirection.None;
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x0003D4C4 File Offset: 0x0003B6C4
		private void UpdateLooking()
		{
			if ((this._balanceDirection != CharacterBalanceDirection.None || this.GroundVelocity != 0.0) && this.LookDirection == CharacterLookDirection.Up)
			{
				this.LookDirection = CharacterLookDirection.Normal;
			}
			Vector2 offset = base.CameraProperties.Offset;
			switch (this.LookDirection)
			{
			case CharacterLookDirection.Up:
				this.LookDelay = Math.Max(0, this.LookDelay - 1);
				offset.Y = ((this.LookDelay == 0) ? Math.Max(-344.0, offset.Y - 8.0) : MathX.ChangeSpeed(offset.Y, -8.0));
				break;
			case CharacterLookDirection.Normal:
				this.LookDelay = 120;
				offset.Y = MathX.ChangeSpeed(offset.Y, -8.0);
				break;
			case CharacterLookDirection.Ducking:
				this.LookDelay = Math.Max(0, this.LookDelay - 1);
				offset.Y = ((this.LookDelay == 0) ? Math.Min(352.0, offset.Y + 8.0) : MathX.ChangeSpeed(offset.Y, -8.0));
				break;
			}
			base.CameraProperties.Offset = offset;
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x0003D60C File Offset: 0x0003B80C
		private void UpdatePushing()
		{
			if (this.Mode == CollisionMode.Air || this.MovingDirection == 0 || this.SlopeLockTicks > 0)
			{
				this.IsPushing = false;
				this._pushTicks = 0;
				return;
			}
			if (this.Mode != CollisionMode.Top)
			{
				this.IsPushing = false;
				this._pushTicks = 0;
				this._pushDirection = 0;
				return;
			}
			bool flag = this._collisionEvents[3] != null;
			bool flag2 = this._collisionEvents[1] != null;
			if ((this.MovingDirection == -1 && flag) || (this.MovingDirection == 1 && flag2))
			{
				this.IsPushing = true;
				this._pushDirection = this.MovingDirection;
				this._pushTicks = 12;
				return;
			}
			if (this.MovingDirection != this._pushDirection)
			{
				this.IsPushing = false;
				this._pushTicks = 0;
				this._pushDirection = 0;
				return;
			}
			this._pushTicks--;
			if (this._pushTicks == 0)
			{
				this.IsPushing = false;
				this._pushTicks = 0;
				this._pushDirection = 0;
			}
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x0003D700 File Offset: 0x0003B900
		private static double ChangeSpeed(double speed, int direction, double limit, double acceleration, double deceleration, double friction)
		{
			if (direction != 0)
			{
				double num = limit - speed * (double)direction;
				if (num > limit)
				{
					speed += deceleration * (double)direction;
				}
				else if (num > acceleration)
				{
					speed += acceleration * (double)direction;
				}
				else if (num > 0.0)
				{
					speed = limit * (double)direction;
				}
			}
			if (friction > 0.0)
			{
				if (speed > friction)
				{
					speed -= friction;
				}
				else if (speed < -friction)
				{
					speed += friction;
				}
				else
				{
					speed = 0.0;
				}
			}
			return speed;
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0003D77C File Offset: 0x0003B97C
		private void ApplyLevelBounds()
		{
			if (base.Position.X - 36 < base.Level.Bounds.X)
			{
				base.PositionPrecise = new Vector2((double)(base.Level.Bounds.X + 36), base.PositionPrecise.Y);
				this.Velocity = new Vector2(0.0, this.Velocity.Y);
				this.GroundVelocity = MathX.Clamp(-1.0, this.GroundVelocity, 0.0);
			}
			else if (base.Position.X + 36 > base.Level.Bounds.Right - 1)
			{
				base.PositionPrecise = new Vector2((double)(base.Level.Bounds.Right - 1 - 36), base.PositionPrecise.Y);
				this.Velocity = new Vector2(0.0, this.Velocity.Y);
				this.GroundVelocity = MathX.Clamp(0.0, this.GroundVelocity, 1.0);
			}
			if (this.IsDebug)
			{
				if (base.Position.Y >= base.Level.Bounds.Bottom)
				{
					base.PositionPrecise = new Vector2(base.PositionPrecise.X, (double)base.Level.Bounds.Bottom);
					this.Velocity = new Vector2(this.Velocity.X, 0.0);
				}
				if (base.Position.Y < base.Level.Bounds.Top)
				{
					base.PositionPrecise = new Vector2(base.PositionPrecise.X, (double)base.Level.Bounds.Top);
					this.Velocity = new Vector2(this.Velocity.X, 0.0);
					return;
				}
			}
			else if (base.Position.Y >= base.Level.Bounds.Bottom)
			{
				this.Kill(PlayerDeathCause.BottomlessPit);
			}
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x0003D9E4 File Offset: 0x0003BBE4
		private void SetCameraTracking()
		{
			CameraProperties cameraProperties = base.CameraProperties;
			cameraProperties.MaxVelocity = new Vector2(64.0, cameraProperties.MaxVelocity.Y);
			if (this.IsAirborne)
			{
				cameraProperties.Box = new Rectangle(-64.0, -192.0, 64.0, 256.0);
				cameraProperties.MaxVelocity = new Vector2(cameraProperties.MaxVelocity.X, 64.0);
			}
			else
			{
				Rectangle box = new Rectangle(-64.0, -16.0, 64.0, 0.0);
				if (this.IsSpinball)
				{
					box.Y += (double)(this.NormalCollisionRadius.Y - this.SpinballCollisionRadius.Y);
				}
				cameraProperties.Box = box;
				cameraProperties.MaxVelocity = new Vector2(cameraProperties.MaxVelocity.X, (this.Velocity.Y <= 6.0) ? 24.0 : 64.0);
			}
			if (this.IsDebug)
			{
				cameraProperties.MaxVelocity = new Vector2(Math.Max(64.0, Math.Abs(this.Velocity.X)), Math.Max(64.0, Math.Abs(this.Velocity.Y)));
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x0003DB7C File Offset: 0x0003BD7C
		private void UpdateDebugState()
		{
			int protagonistGamepadIndex = this.Player.ProtagonistGamepadIndex;
			Controller controller = base.Level.GameContext.Current[protagonistGamepadIndex];
			Vector2 velocity = this.Velocity;
			if (controller.DirectionLeft.X == 0.0)
			{
				velocity.X = MathX.ChangeSpeed(this.Velocity.X, -0.1875);
			}
			else
			{
				velocity.X += controller.DirectionLeft.X * 0.1875 * 2.0;
			}
			if (controller.DirectionLeft.Y == 0.0)
			{
				velocity.Y = MathX.ChangeSpeed(this.Velocity.Y, -0.1875);
			}
			else
			{
				velocity.Y += controller.DirectionLeft.Y * 0.1875 * 2.0;
			}
			this.Velocity = velocity;
			this.UpdatePosition();
			this.ApplyLevelBounds();
			this.LookDelay = 120;
			base.CameraProperties.Delay = new Vector2i(0, 0);
			this.BreathTicks = 1800;
			if (this.IsUnderwater)
			{
				this.LeaveWater();
			}
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x0003DCD8 File Offset: 0x0003BED8
		public void DrawDebugInfo(Renderer renderer)
		{
			double num = 512.0;
			base.Level.DebugContext.DrawText(renderer, string.Join("  ", new object[]
			{
				this.IsFacingLeft ? 'L' : 'R',
				this.IsBraking ? 'B' : ' ',
				this.IsPushing ? 'P' : ' ',
				this.IsAirborne ? 'A' : ' ',
				this.IsSpinball ? 'S' : ' ',
				this.IsRollJumping ? 'R' : ' ',
				this.IsDying ? 'D' : ' ',
				this.IsFlying ? 'F' : ' ',
				this.ExhibitsVirtualPlatform ? 'V' : ' ',
				this.HasSpeedShoes ? "SS" : "  ",
				this.IsInvincible ? 'I' : ' '
			}), FontAlignment.MiddleX, 960.0, 16.0, 0.75, new int?(0));
			num += base.Level.DebugContext.DrawText(renderer, string.Format("LAYER: {0}", base.Level.Map.Layers.IndexOf(base.Layer)), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			num += base.Level.DebugContext.DrawText(renderer, string.Format("ANGLE: {0:0.00} TUMBLE: {1:0.00}", this.GroundAngle, this.TumbleAngle), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			num += base.Level.DebugContext.DrawText(renderer, string.Format("POSITION: {0:0.00}, {1:0.00}", base.PositionPrecise.X, base.PositionPrecise.Y), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			num += base.Level.DebugContext.DrawText(renderer, string.Format("VELOCITY: {0:0.00}, {1:0.00}", this.Velocity.X, this.Velocity.Y), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			if (!this.IsAirborne)
			{
				num += base.Level.DebugContext.DrawText(renderer, string.Format("GROUND VELOCITY: {0:0.00}", this.GroundVelocity), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			}
			if (this.SlopeLockTicks > 0)
			{
				num += base.Level.DebugContext.DrawText(renderer, string.Format("SLOPE LOCK: {0}", this.SlopeLockTicks), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			}
			if (this.LookDelay < 120)
			{
				num += base.Level.DebugContext.DrawText(renderer, string.Format("LOOK DELAY: {0}", this.LookDelay), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			}
			if (this.IsCharging)
			{
				num += base.Level.DebugContext.DrawText(renderer, string.Format("SPINDASH: {0}", 32.0 + this._spindashExtraSpeed), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			}
			if (this.InvulnerabilityTicks > 0)
			{
				num += base.Level.DebugContext.DrawText(renderer, string.Format("INVULNERABILITY: {0}", this.InvulnerabilityTicks), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			}
			if (this.BreathTicks < 1800)
			{
				num += base.Level.DebugContext.DrawText(renderer, string.Format("DROWNING: {0}", this.BreathTicks), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			}
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x0003E160 File Offset: 0x0003C360
		protected internal void DrawNewCollisionDebug(Renderer renderer)
		{
			if (this.IsSidekick)
			{
				return;
			}
			string[] array = new string[]
			{
				"MODE: " + this.Mode,
				string.Concat(new object[]
				{
					"POSITION: ",
					base.Position.X,
					", ",
					base.Position.Y
				}),
				string.Concat(new object[]
				{
					"PRECISE: ",
					base.PositionPrecise.X - (double)base.Position.X,
					", ",
					base.PositionPrecise.Y - (double)base.Position.Y
				}),
				string.Concat(new object[]
				{
					"VELOCITY: ",
					(int)this.Velocity.X,
					", ",
					(int)this.Velocity.Y
				}),
				"GROUND VELOCITY: " + (int)this.GroundVelocity,
				"GROUND ID: " + base.Level.Map.CollisionVectors.IndexOf(this.GroundVector),
				"PATH: " + this.Path
			};
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix = Matrix4.Identity;
				double num = 16.0;
				foreach (string text in array)
				{
					num += base.Level.DebugContext.DrawText(renderer, text.ToUpper(), FontAlignment.Right, 1904.0, num, 0.5, new int?(0));
				}
				i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate(-base.Level.Camera.Bounds.X, -base.Level.Camera.Bounds.Y, 0.0);
				if ((this.Mode == CollisionMode.Top || this.Mode == CollisionMode.Bottom) && this.GroundVector != null)
				{
					i2dRenderer.RenderLine(Colours.Blue, new Vector2((double)this.GroundVector.AbsoluteA.X, 0.0), new Vector2((double)this.GroundVector.AbsoluteA.X, 10000.0), 8.0);
					i2dRenderer.RenderLine(Colours.Yellow, new Vector2((double)this.GroundVector.AbsoluteA.X, 0.0), new Vector2((double)this.GroundVector.AbsoluteA.X, 10000.0), 4.0);
					i2dRenderer.RenderLine(Colours.Blue, new Vector2((double)this.GroundVector.AbsoluteB.X, 0.0), new Vector2((double)this.GroundVector.AbsoluteB.X, 10000.0), 8.0);
					i2dRenderer.RenderLine(Colours.Yellow, new Vector2((double)this.GroundVector.AbsoluteB.X, 0.0), new Vector2((double)this.GroundVector.AbsoluteB.X, 10000.0), 4.0);
					string text2 = string.Concat(new object[]
					{
						"{X: ",
						this.GroundVector.AbsoluteA.X,
						", Y: ",
						this.GroundVector.AbsoluteA.Y,
						"}"
					});
					base.Level.DebugContext.DrawText(renderer, text2.ToUpper(), FontAlignment.Right, (double)(this.GroundVector.AbsoluteA.X - 128), (double)(this.GroundVector.AbsoluteA.Y - 128), 0.5, new int?(0));
					text2 = string.Concat(new object[]
					{
						"{X: ",
						this.GroundVector.AbsoluteB.X,
						", Y: ",
						this.GroundVector.AbsoluteB.Y,
						"}"
					});
					base.Level.DebugContext.DrawText(renderer, text2.ToUpper(), FontAlignment.Right, (double)(this.GroundVector.AbsoluteB.X + 256), (double)(this.GroundVector.AbsoluteB.Y - 128), 0.5, new int?(0));
				}
				else if ((this.Mode == CollisionMode.Left || this.Mode == CollisionMode.Right) && this.GroundVector != null)
				{
					i2dRenderer.RenderLine(Colours.Blue, new Vector2(0.0, (double)this.GroundVector.AbsoluteA.Y), new Vector2(100000.0, (double)this.GroundVector.AbsoluteA.Y), 8.0);
					i2dRenderer.RenderLine(Colours.Yellow, new Vector2(0.0, (double)this.GroundVector.AbsoluteA.Y), new Vector2(100000.0, (double)this.GroundVector.AbsoluteA.Y), 4.0);
					i2dRenderer.RenderLine(Colours.Blue, new Vector2(0.0, (double)this.GroundVector.AbsoluteB.Y), new Vector2(100000.0, (double)this.GroundVector.AbsoluteB.Y), 8.0);
					i2dRenderer.RenderLine(Colours.Yellow, new Vector2(0.0, (double)this.GroundVector.AbsoluteB.Y), new Vector2(100000.0, (double)this.GroundVector.AbsoluteB.Y), 4.0);
				}
				foreach (Vector2[] array3 in this.GetCollisionBox(this.CollisionRadius, true))
				{
				}
				new Rectangle(base.PositionPrecise.X - (double)this.CollisionRadius.X, base.PositionPrecise.Y - (double)this.CollisionRadius.Y, (double)(this.CollisionRadius.X * 2), (double)(this.CollisionRadius.Y * 2));
				bool flag = false;
				double num2;
				double num3;
				if (this.Mode == CollisionMode.Left || this.Mode == CollisionMode.Right)
				{
					num2 = (double)this.CollisionRadius.Y;
					num3 = (double)this.CollisionRadius.X;
					flag = true;
				}
				else
				{
					num2 = (double)this.CollisionRadius.X;
					num3 = (double)this.CollisionRadius.Y;
				}
				Vector2 pointRotatedFromRelative = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y + num2), 1.5707963267948966 + this.GroundAngle);
				Vector2 pointRotatedFromRelative2 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y - num2), 1.5707963267948966 + this.GroundAngle);
				Vector2 pointRotatedFromRelative3 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X - num3, base.PositionPrecise.Y), 1.5707963267948966 + this.GroundAngle);
				Vector2 pointRotatedFromRelative4 = this.GetPointRotatedFromRelative(base.PositionPrecise, new Vector2(base.PositionPrecise.X + num3, base.PositionPrecise.Y), 1.5707963267948966 + this.GroundAngle);
				Vector2[][] collisionBox2 = this.GetCollisionBox(new Vector2(num2 - (double)this.LedgeSensorRadius, num3 - (double)this.FloorSensorRadius + 20.0), false);
				Vector2[][] collisionBox3 = this.GetCollisionBox(new Vector2(num2 - (double)this.LedgeSensorRadius, num3), false);
				Vector2[][] collection = new Vector2[0][];
				Vector2[][] collection2 = new Vector2[0][];
				Vector2 vector = default(Vector2);
				Vector2 vector2 = default(Vector2);
				Vector2 vector3 = default(Vector2);
				Vector2 vector4 = default(Vector2);
				if (!flag)
				{
					collection = collisionBox2;
					collection2 = collisionBox3;
					vector = pointRotatedFromRelative;
					vector2 = pointRotatedFromRelative2;
					vector3 = pointRotatedFromRelative3;
					vector4 = pointRotatedFromRelative4;
				}
				else
				{
					collection = collisionBox3;
					collection2 = collisionBox2;
					vector = pointRotatedFromRelative3;
					vector2 = pointRotatedFromRelative4;
					vector3 = pointRotatedFromRelative;
					vector4 = pointRotatedFromRelative2;
				}
				i2dRenderer.RenderLine(Colour.ParseHex("00FF00"), vector, vector2, 5.0);
				i2dRenderer.RenderLine(Colour.ParseHex("00FF00"), vector3, vector4, 5.0);
				foreach (CollisionVector collisionVector in base.Level.Map.CollisionVectors)
				{
					if (base.Level.Camera.Bounds.IntersectsWith(collisionVector.Bounds))
					{
						int num4 = 6;
						i2dRenderer.RenderLine(Colour.ParseHex("FF0000"), collisionVector.AbsoluteA, collisionVector.AbsoluteB, 5.0);
						i2dRenderer.RenderRectangle(Colour.ParseHex("FA35FF"), Rectangle.FromLTRB((double)(collisionVector.AbsoluteA.X - num4), (double)(collisionVector.AbsoluteA.Y - num4), (double)(collisionVector.AbsoluteA.X + num4), (double)(collisionVector.AbsoluteA.Y + num4)), (double)(num4 * 4));
						i2dRenderer.RenderRectangle(Colour.ParseHex("FA35FF"), Rectangle.FromLTRB((double)(collisionVector.AbsoluteB.X - num4), (double)(collisionVector.AbsoluteB.Y - num4), (double)(collisionVector.AbsoluteB.X + num4), (double)(collisionVector.AbsoluteB.Y + num4)), (double)(num4 * 4));
					}
				}
				foreach (ActiveObject activeObject in base.Level.ObjectManager.ActiveObjects)
				{
					foreach (CollisionVector collisionVector2 in activeObject.CollisionVectors)
					{
						i2dRenderer.RenderLine(Colour.ParseHex("FF00FF"), collisionVector2.AbsoluteA, collisionVector2.AbsoluteB, 5.0);
					}
					foreach (CollisionRectangle collisionRectangle in activeObject.CollisionRectangles)
					{
						i2dRenderer.RenderRectangle(Colour.ParseHex("FF00FF"), collisionRectangle.AbsoluteBounds, 5.0);
					}
				}
				if (this.GroundVector != null)
				{
					i2dRenderer.RenderLine(Colour.ParseHex("FFFFFF"), this.GroundVector.AbsoluteA, this.GroundVector.AbsoluteB, 5.0);
					if (this.GroundVector.GetConnectionA(this.Path) != null)
					{
						CollisionVector connectionA = this.GroundVector.GetConnectionA(this.Path);
						i2dRenderer.RenderLine(Colour.ParseHex("00FFFF"), connectionA.AbsoluteA, connectionA.AbsoluteB, 5.0);
					}
					if (this.GroundVector.GetConnectionB(this.Path) != null)
					{
						CollisionVector connectionB = this.GroundVector.GetConnectionB(this.Path);
						i2dRenderer.RenderLine(Colour.ParseHex("FFFF00"), connectionB.AbsoluteA, connectionB.AbsoluteB, 5.0);
					}
				}
				List<Vector2[]> list = new List<Vector2[]>
				{
					new Vector2[]
					{
						vector,
						vector2
					}
				};
				list.AddRange(collection);
				for (int j = 0; j < list.Count; j++)
				{
					Vector2[] array4 = list[j];
					i2dRenderer.RenderLine(Colour.ParseHex("00FF00"), array4[0], array4[1], 5.0);
				}
				list = new List<Vector2[]>
				{
					new Vector2[]
					{
						vector3,
						vector4
					}
				};
				list.AddRange(collection2);
				for (int k = 0; k < list.Count; k++)
				{
					Vector2[] array5 = list[k];
					i2dRenderer.RenderLine(Colour.ParseHex("0000FF"), array5[0], array5[1], 5.0);
				}
			}
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x0003EFB0 File Offset: 0x0003D1B0
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (this.IsSidekick && this._autoSidekickState == Character.AutoSidekickState.Spawning)
			{
				return;
			}
			if (this.IsHurt || this.InvulnerabilityTicks <= 0 || this.InvulnerabilityTicks % 8 >= 4)
			{
				this.DrawBody(renderer, viewOptions);
			}
			this.DrawSpindashDust(renderer);
			if (!viewOptions.Shadows)
			{
				this.DrawProtection(renderer);
				this.DrawBreathTimeRemaining(renderer);
			}
			this._intersection -= base.PositionPrecise;
			renderer.Get2dRenderer().RenderRectangle(Colour.ParseHex("FF00FF"), Rectangle.FromLTRB(this._intersection.X - 10.0, this._intersection.Y - 10.0, this._intersection.X + 10.0, this._intersection.Y + 10.0), 40.0);
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x0003F0A0 File Offset: 0x0003D2A0
		protected virtual void DrawBody(Renderer renderer, LayerViewOptions viewOptions)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			ICharacterRenderer characterRenderer = renderer.GetCharacterRenderer();
			characterRenderer.ModelMatrix = i2dRenderer.ModelMatrix;
			double propertyDouble = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "sonic_hue_shift", 0.0);
			double propertyDouble2 = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "sonic_sat_shift", 0.0);
			double propertyDouble3 = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "sonic_lum_shift", 0.0);
			if (this.DrawBodyRotated)
			{
				characterRenderer.ModelMatrix *= Matrix4.CreateRotationZ(this.ShowAngle);
			}
			Animation.Frame currentFrame = this.Animation.CurrentFrame;
			Vector2 vector = currentFrame.Offset;
			Rectangle destination = new Rectangle(vector.X - (double)(currentFrame.Source.Width / 2), vector.Y - (double)(currentFrame.Source.Height / 2), (double)currentFrame.Source.Width, (double)currentFrame.Source.Height);
			characterRenderer.Filter = viewOptions.Filter;
			characterRenderer.FilterAmount = viewOptions.FilterAmount;
			characterRenderer.Brightness = (viewOptions.Shadows ? 0f : base.Brightness);
			characterRenderer.RenderTexture(this.Animation.AnimationGroup.Textures[1], this.Animation.AnimationGroup.Textures[0], propertyDouble, propertyDouble2, propertyDouble3, currentFrame.Source, destination, this.IsFacingRight, this.IsFacingLeft && this.Animation.Index == 16);
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x0003F278 File Offset: 0x0003D478
		protected void DrawSpindashDust(Renderer renderer)
		{
			if (!this.IsCharging)
			{
				return;
			}
			Vector2 destination = new Vector2((double)(this.SpindashDustAnimation.CurrentFrame.Source.Width / 2), (double)this.CollisionRadius.Y + 8.0 - (double)(this.SpindashDustAnimation.CurrentFrame.Source.Height / 2));
			if (this.IsFacingRight)
			{
				destination.X *= -1.0;
			}
			renderer.GetObjectRenderer().Render(this.SpindashDustAnimation, destination, this.IsFacingRight, false);
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x0003F323 File Offset: 0x0003D523
		protected void DrawProtection(Renderer renderer)
		{
			if (this.IsInvincible)
			{
				this.DrawInvincibility(renderer);
				return;
			}
			this.DrawBarrier(renderer);
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x0003F33C File Offset: 0x0003D53C
		protected void DrawBarrier(Renderer renderer)
		{
			if (!this.HasBarrier || this.BarrierAnimation == null)
			{
				return;
			}
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.BlendMode = BlendMode.Additive;
			objectRenderer.FilterAmount *= 0.25;
			objectRenderer.Render(this.BarrierAnimation, false, false);
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x0003F38C File Offset: 0x0003D58C
		protected void DrawBreathTimeRemaining(Renderer renderer)
		{
			if (this._drowningClimax && this._drowningAnimation.Cycles == 0)
			{
				I2dRenderer renderer2 = renderer.Get2dRenderer();
				Vector2i v = this._drownCountdownPosition - base.Position;
				this._drowningAnimation.Draw(renderer2, v, false, false);
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000FB9 RID: 4025 RVA: 0x0003F3DB File Offset: 0x0003D5DB
		// (set) Token: 0x06000FBA RID: 4026 RVA: 0x0003F3E3 File Offset: 0x0003D5E3
		protected int InvulnerabilityTicks { get; set; }

		// Token: 0x06000FBB RID: 4027 RVA: 0x0003F3EC File Offset: 0x0003D5EC
		private void ScatterRings(int ringCount, int facing)
		{
			base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/RINGSCATTER");
			ringCount = Math.Min(ringCount, 32);
			for (int i = 0; i < ringCount; i++)
			{
				Vector2 velocity = Character.ScatterRingOffsets[i];
				velocity.X *= (double)facing;
				this.CreateRing(velocity);
			}
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x0003F448 File Offset: 0x0003D648
		private void CreateRing(Vector2 velocity)
		{
			base.Level.ObjectManager.AddObject(new ObjectPlacement(base.Level.CommonResources.GetResourcePath("ringobject"), base.Level.Map.Layers.IndexOf(base.Layer), base.Position, new
			{
				Scatter = true,
				Velocity = new Vector2(velocity.X, velocity.Y)
			}));
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000FBD RID: 4029 RVA: 0x0003F4BA File Offset: 0x0003D6BA
		public bool CanBeHurt
		{
			get
			{
				return !this.IsHurt && this.InvulnerabilityTicks <= 0 && !this.IsInvincible;
			}
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x0003F4DC File Offset: 0x0003D6DC
		public void Hurt(int direction, PlayerDeathCause cause = PlayerDeathCause.Hurt)
		{
			if (!this.CanBeHurt)
			{
				return;
			}
			this.LeaveGround();
			if (this.IsSidekick)
			{
				Vector2 velocity = new Vector2(-8.0, -16.0);
				if (this.IsUnderwater)
				{
					velocity = new Vector2(velocity.X / 2.0, velocity.Y / 2.0);
				}
				if (direction >= 0)
				{
					velocity.X *= -1.0;
				}
				this.Velocity = velocity;
				this.Facing = -direction;
				this.IsAirborne = true;
				this.IsBraking = false;
				this.IsCharging = false;
				this.IsSpinball = false;
				this.IsFlying = false;
				this.IsHurt = true;
				this.ShowAngle = 0.0;
				this.TumbleAngle = 0.0;
				this.InvulnerabilityTicks = 120;
			}
			else if (this.Player.CurrentRings > 0 || this.HasBarrier)
			{
				Vector2 velocity2 = new Vector2(-8.0, -16.0);
				if (this.IsUnderwater)
				{
					velocity2 = new Vector2(velocity2.X / 2.0, velocity2.Y / 2.0);
				}
				if (direction >= 0)
				{
					velocity2.X *= -1.0;
				}
				this.Velocity = velocity2;
				this.Facing = -direction;
				this.IsAirborne = true;
				this.IsBraking = false;
				this.IsCharging = false;
				this.IsSpinball = false;
				this.IsFlying = false;
				this.IsHurt = true;
				this.ShowAngle = 0.0;
				this.TumbleAngle = 0.0;
				this.InvulnerabilityTicks = 120;
				if (this.HasBarrier)
				{
					this.Barrier = BarrierType.None;
					base.Level.SoundManager.PlaySound(this, (cause == PlayerDeathCause.Spikes) ? "SONICORCA/SOUND/HURT/SPIKES" : "SONICORCA/SOUND/HURT");
				}
				else
				{
					this.ScatterRings(this.Player.CurrentRings, -direction);
					this.Player.LoseAllRings();
				}
			}
			else
			{
				this.Kill(cause);
			}
			this.CharacterEvents |= CharacterEvent.Hurt;
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x0003F714 File Offset: 0x0003D914
		public void Kill(PlayerDeathCause cause)
		{
			this._deathCause = cause;
			this.Velocity = new Vector2(0.0, -28.0);
			this._dyingTicks = 120;
			base.CameraProperties.Delay = new Vector2i(3600, 3600);
			this.StateFlags = (CharacterState)0;
			this.IsAirborne = true;
			this.IsBraking = false;
			this.IsCharging = false;
			this.IsFlying = false;
			this.IsHurt = false;
			this.IsDying = true;
			this.ShouldReactToLevel = false;
			this.ShowAngle = 0.0;
			base.Level.SoundManager.PlaySound(this, (cause == PlayerDeathCause.Spikes) ? "SONICORCA/SOUND/HURT/SPIKES" : "SONICORCA/SOUND/HURT");
			base.Priority = 4096;
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0003F7DC File Offset: 0x0003D9DC
		private void UpdateDying()
		{
			if (this._dyingTicks == 0)
			{
				this.StateFlags = (CharacterState)0;
				this.IsDead = true;
				return;
			}
			double num = (this._deathCause == PlayerDeathCause.Drown) ? 0.25 : 0.875;
			this.Velocity = new Vector2(this.Velocity.X, Math.Min(this.Velocity.Y + num, 96.0));
			base.PositionPrecise += this.Velocity;
			this._dyingTicks--;
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000FC1 RID: 4033 RVA: 0x0003F87A File Offset: 0x0003DA7A
		// (set) Token: 0x06000FC2 RID: 4034 RVA: 0x0003F882 File Offset: 0x0003DA82
		protected string InvincibilityGroupResourceKey { get; set; }

		// Token: 0x06000FC3 RID: 4035 RVA: 0x0003F88C File Offset: 0x0003DA8C
		private void InitialiseInvincibility()
		{
			AnimationGroup loadedResource = base.Level.GameContext.ResourceTree.GetLoadedResource<AnimationGroup>(this.InvincibilityGroupResourceKey);
			this._invincibilityParticles.Clear();
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					double num = (double)(j * 4 + i) / 12.0;
					this._invincibilityParticles.Add(new Character.InvincibilityParticle(this, num * 6.283185307179586, loadedResource, i));
				}
			}
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x0003F908 File Offset: 0x0003DB08
		private void StartInvincibility()
		{
			this._invincibilityCharacterPositionHistory.Clear();
			for (int i = 0; i < 8; i++)
			{
				this._invincibilityCharacterPositionHistory.Add(base.Position);
			}
			this._invincibilityCharacterPositionHistory.TrimExcess();
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x0003F950 File Offset: 0x0003DB50
		private void AnimateInvincibility()
		{
			if (this._invincibilityCharacterPositionHistory.Count > 0)
			{
				this._invincibilityCharacterPositionHistory.RemoveAt(this._invincibilityCharacterPositionHistory.Count - 1);
			}
			this._invincibilityCharacterPositionHistory.Insert(0, base.Position);
			for (int i = 0; i < 4; i++)
			{
				int num = i * 2;
				if (num < this._invincibilityCharacterPositionHistory.Count)
				{
					Vector2 origin = this._invincibilityCharacterPositionHistory[num];
					for (int j = 0; j < 3; j++)
					{
						int index = i * 3 + j;
						this._invincibilityParticles[index].Origin = origin;
					}
				}
			}
			foreach (Character.InvincibilityParticle invincibilityParticle in this._invincibilityParticles)
			{
				invincibilityParticle.Animate();
			}
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x0003FA30 File Offset: 0x0003DC30
		private void DrawInvincibility(Renderer renderer)
		{
			foreach (Character.InvincibilityParticle invincibilityParticle in this._invincibilityParticles)
			{
				invincibilityParticle.Draw(renderer);
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000FC7 RID: 4039 RVA: 0x0003FA84 File Offset: 0x0003DC84
		// (set) Token: 0x06000FC8 RID: 4040 RVA: 0x0003FA8C File Offset: 0x0003DC8C
		public bool IsSidekick { get; set; }

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000FC9 RID: 4041 RVA: 0x0003FA95 File Offset: 0x0003DC95
		// (set) Token: 0x06000FCA RID: 4042 RVA: 0x0003FA9D File Offset: 0x0003DC9D
		public bool Respawning { get; private set; }

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000FCB RID: 4043 RVA: 0x0003FAA8 File Offset: 0x0003DCA8
		private bool IsLeftBehind
		{
			get
			{
				if (!this.IsSidekick)
				{
					return false;
				}
				double num = (double)Math.Abs(base.Position.X - this.Player.Protagonist.Position.X);
				double num2 = (double)Math.Abs(base.Position.Y - this.Player.Protagonist.Position.Y);
				return num > 2069.0 || num2 > 1152.0;
			}
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0003FB34 File Offset: 0x0003DD34
		public bool IsOnScreen()
		{
			Rectangle rect = new Rectangle((double)(base.Position.X - 128), (double)(base.Position.Y - 128), 256.0, 256.0);
			return base.Level.Camera.Bounds.IntersectsWith(rect);
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000FCD RID: 4045 RVA: 0x0003FB9D File Offset: 0x0003DD9D
		public bool IsHumanInput
		{
			get
			{
				return this.Input.HorizontalDirection != 0 || this.Input.VerticalDirection != 0 || this.Input.ABC.HasFlag(CharacterInputButtonState.Down);
			}
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x0003FBDC File Offset: 0x0003DDDC
		private void UpdateSidekick()
		{
			if (!base.Level.StateFlags.HasFlag(LevelStateFlags.AllowCharacterControl))
			{
				this.UpdateNormal();
				return;
			}
			if (this.IsHumanInput)
			{
				this._humanControlled = true;
				this._humanInputTicksRemaining = 600;
			}
			else
			{
				this._humanInputTicksRemaining--;
				if (this._humanInputTicksRemaining <= 0)
				{
					this._humanControlled = false;
				}
			}
			ICharacter protagonist = this.Player.Protagonist;
			CharacterHistoryItem characterHistoryItem = protagonist.History[17];
			switch (this._autoSidekickState)
			{
			case Character.AutoSidekickState.Spawning:
				if (!protagonist.IsDebug && (this._humanControlled || base.Level.Ticks % 64 == 0))
				{
					this._autoSidekickState = Character.AutoSidekickState.Flying;
					this.StateFlags = (CharacterState)0;
					this.CollisionRadius = this.NormalCollisionRadius;
					base.Position = new Vector2i(protagonist.Position.X, protagonist.Position.Y - 1152);
					base.Priority = 8192;
					this._sidekickOffscreenTicks = 300;
					return;
				}
				return;
			case Character.AutoSidekickState.Flying:
			{
				if (this.IsOnScreen())
				{
					this._sidekickOffscreenTicks = 300;
				}
				else
				{
					this._sidekickOffscreenTicks--;
					if (this._sidekickOffscreenTicks <= 0)
					{
						this._autoSidekickState = Character.AutoSidekickState.Spawning;
						base.Position = default(Vector2i);
						return;
					}
				}
				this._sidekickTargetPosition = characterHistoryItem.Position;
				if (this.CanFly)
				{
					this.IsFlying = true;
					this.IsSpinball = false;
				}
				else
				{
					this.IsSpinball = true;
				}
				this.IsAirborne = true;
				this.IsHurt = false;
				this.IsDying = false;
				this.IsDead = false;
				this.ShouldReactToLevel = false;
				this.Mode = CollisionMode.Air;
				Vector2i offset = default(Vector2i);
				int num = this._sidekickTargetPosition.X - base.Position.X;
				if (num != 0)
				{
					offset.X = Math.Sign(num) * Math.Min(48, Math.Abs(num) / 4);
					offset.X += (int)protagonist.Velocity.X + 4;
					this.Facing = Math.Sign(offset.X);
				}
				int num2 = protagonist.NormalCollisionRadius.Y - this.NormalCollisionRadius.Y;
				int num3 = this._sidekickTargetPosition.Y - base.Position.Y + num2;
				if (num3 != 0)
				{
					offset.Y = Math.Sign(num3) * Math.Min(Math.Abs(num3), this.CanFly ? 4 : 24);
				}
				CharacterState state = characterHistoryItem.State;
				if ((state & (CharacterState.Dying | CharacterState.Dead)) == (CharacterState)0)
				{
					base.Move(offset);
				}
				if (Math.Abs(offset.X) > 48 || offset.Y != 0 || (state & (CharacterState.Rolling | CharacterState.Airborne | CharacterState.Dying | CharacterState.Dead | CharacterState.Debug)) != (CharacterState)0)
				{
					return;
				}
				this.Velocity = default(Vector2);
				this.GroundVelocity = 0.0;
				this.Path = protagonist.Path;
				base.Layer = protagonist.Layer;
				this.Mode = CollisionMode.Air;
				this._autoSidekickState = Character.AutoSidekickState.Normal;
				break;
			}
			case Character.AutoSidekickState.Normal:
				break;
			case Character.AutoSidekickState.Spindash:
				goto IL_3A0;
			default:
				return;
			}
			if (protagonist.IsDying || protagonist.IsDead)
			{
				this.UpdateNormal();
				return;
			}
			this.ShouldReactToLevel = true;
			base.Priority = 1020;
			if (this.IsUnableToCatchUp())
			{
				return;
			}
			if (this._humanControlled || this.IsObjectControlled || this.IsWinning || characterHistoryItem == null)
			{
				this.UpdateNormal();
				return;
			}
			if (this.SlopeLockTicks <= 0)
			{
				this.ApplyAutoInput(this.GetAutoInputNormal(protagonist, characterHistoryItem));
				this.UpdateNormal();
				return;
			}
			this._autoSidekickState = Character.AutoSidekickState.Spindash;
			IL_3A0:
			if (!this.IsUnableToCatchUp())
			{
				if (this.SlopeLockTicks > 0)
				{
					this.UpdateNormal();
					return;
				}
				this.ApplyAutoInput(this.GetAutoInputSpindash(protagonist));
				this.UpdateNormal();
			}
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x0003FFB4 File Offset: 0x0003E1B4
		private CharacterInputState GetAutoInputNormal(ICharacter protagonist, CharacterHistoryItem protagonistHistory)
		{
			CharacterInputState characterInputState = new CharacterInputState(protagonistHistory.Input);
			this.IsFacingLeft = protagonistHistory.State.HasFlag(CharacterState.Left);
			int num = protagonistHistory.Position.X - base.Position.X;
			if (num == 0)
			{
				this.IsFacingLeft = protagonistHistory.State.HasFlag(CharacterState.Left);
			}
			else if (num > 192)
			{
				if (num >= 64)
				{
					characterInputState.HorizontalDirection = 1;
				}
				if (this.GroundVelocity != 0.0 && this.IsFacingRight)
				{
					base.Move(4, 0);
				}
			}
			else if (num < 128)
			{
				if (num <= -64)
				{
					characterInputState.HorizontalDirection = -1;
				}
				if (this.GroundVelocity != 0.0 && !this.IsFacingRight)
				{
					base.Move(-4, 0);
				}
			}
			if (this._autoSidekickJumping)
			{
				characterInputState.A = CharacterInputButtonState.Down;
				if (this.IsAirborne)
				{
					return characterInputState;
				}
				this._autoSidekickJumping = false;
			}
			if (base.Level.Ticks % 256 == 0 && num >= 256)
			{
				return characterInputState;
			}
			int num2 = protagonistHistory.Position.Y - base.Position.Y;
			if (num2 >= 0)
			{
				if (protagonist.IsPushing)
				{
					characterInputState.HorizontalDirection = Math.Sign(num);
				}
				return characterInputState;
			}
			if (num2 <= -128)
			{
				if (base.Level.Ticks % 64 == 0 && this.LookDirection != CharacterLookDirection.Ducking)
				{
					characterInputState.A = CharacterInputButtonState.Pressed;
					this._autoSidekickJumping = true;
				}
				return characterInputState;
			}
			if (protagonist.IsPushing && this.IsPushing && this._pushDirection != protagonist.Facing && this.LookDirection != CharacterLookDirection.Ducking)
			{
				characterInputState.A = CharacterInputButtonState.Pressed;
				this._autoSidekickJumping = true;
				return characterInputState;
			}
			return characterInputState;
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x00040178 File Offset: 0x0003E378
		private CharacterInputState GetAutoInputSpindash(ICharacter protagonist)
		{
			CharacterInputState characterInputState = new CharacterInputState();
			if (!this.IsCharging)
			{
				if (this.GroundVelocity != 0.0)
				{
					return characterInputState;
				}
				this.Facing = Math.Sign(protagonist.Position.X - base.Position.X);
				characterInputState.VerticalDirection = 1;
				characterInputState.A = CharacterInputButtonState.Pressed;
			}
			else
			{
				characterInputState.VerticalDirection = 1;
				if (base.Level.Ticks % 128 != 0)
				{
					if (base.Level.Ticks % 32 == 0)
					{
						characterInputState.A = CharacterInputButtonState.Pressed;
					}
				}
				else
				{
					this._autoSidekickState = Character.AutoSidekickState.Normal;
				}
			}
			return characterInputState;
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x00040219 File Offset: 0x0003E419
		private void ApplyAutoInput(CharacterInputState input)
		{
			this.LookDirection = (CharacterLookDirection)input.VerticalDirection;
			this.Input = input;
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x00040230 File Offset: 0x0003E430
		private bool IsUnableToCatchUp()
		{
			if (this.IsOnScreen())
			{
				this._sidekickOffscreenTicks = 300;
			}
			else
			{
				this._sidekickOffscreenTicks--;
			}
			if (this.IsDead || this._sidekickOffscreenTicks <= 0)
			{
				this._autoSidekickState = Character.AutoSidekickState.Spawning;
				base.Position = new Vector2i(0, 0);
				return true;
			}
			return false;
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x00006325 File Offset: 0x00004525
		private void DoInstaShield()
		{
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x00040288 File Offset: 0x0003E488
		private void DoFireBarrierMove()
		{
			this.GroundVelocity = (double)(32 * this.Facing);
			this.Velocity = new Vector2(this.GroundVelocity, 0.0);
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x000402B4 File Offset: 0x0003E4B4
		private void DoLightningBarrierMove()
		{
			this.Velocity = new Vector2(this.Velocity.X, -22.0);
			this.IsJumping = false;
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x000402EA File Offset: 0x0003E4EA
		private void DoBubbleBarrierMove()
		{
			this.GroundVelocity = 0.0;
			this.Velocity = new Vector2(0.0, 32.0);
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x00006325 File Offset: 0x00004525
		private void DoSuperHyperTransform()
		{
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x00006325 File Offset: 0x00004525
		private void DoHyperDash()
		{
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000FD9 RID: 4057 RVA: 0x00040318 File Offset: 0x0003E518
		// (set) Token: 0x06000FDA RID: 4058 RVA: 0x00040320 File Offset: 0x0003E520
		public CharacterState StateFlags { get; set; }

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000FDB RID: 4059 RVA: 0x00040329 File Offset: 0x0003E529
		// (set) Token: 0x06000FDC RID: 4060 RVA: 0x00040341 File Offset: 0x0003E541
		public bool IsPushing
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Pushing);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Pushing) : (this.StateFlags & ~CharacterState.Pushing));
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000FDD RID: 4061 RVA: 0x0004035F File Offset: 0x0003E55F
		// (set) Token: 0x06000FDE RID: 4062 RVA: 0x00040377 File Offset: 0x0003E577
		public bool IsBraking
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Braking);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Braking) : (this.StateFlags & ~CharacterState.Braking));
			}
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000FDF RID: 4063 RVA: 0x00040395 File Offset: 0x0003E595
		// (set) Token: 0x06000FE0 RID: 4064 RVA: 0x000403B0 File Offset: 0x0003E5B0
		public bool IsSpinball
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Spinball);
			}
			set
			{
				if (this.IsSpinball == value)
				{
					return;
				}
				if (value)
				{
					this.StateFlags |= CharacterState.Spinball;
					this.CollisionRadius = this.SpinballCollisionRadius;
					base.PositionPrecise += new Vector2(0.0, (double)(this.NormalCollisionRadius.Y - this.SpinballCollisionRadius.Y));
				}
				else
				{
					this.StateFlags &= ~CharacterState.Spinball;
					this.CollisionRadius = this.NormalCollisionRadius;
					base.PositionPrecise += new Vector2(0.0, (double)(-(double)(this.NormalCollisionRadius.Y - this.SpinballCollisionRadius.Y)));
				}
				if (!value)
				{
					this.IsRollJumping = false;
				}
			}
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000FE1 RID: 4065 RVA: 0x00040487 File Offset: 0x0003E687
		// (set) Token: 0x06000FE2 RID: 4066 RVA: 0x000404A0 File Offset: 0x0003E6A0
		public bool IsRollJumping
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Rolling);
			}
			set
			{
				if (value)
				{
					this.StateFlags |= CharacterState.Rolling;
					return;
				}
				this.StateFlags &= ~CharacterState.Rolling;
			}
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000FE3 RID: 4067 RVA: 0x000404C4 File Offset: 0x0003E6C4
		// (set) Token: 0x06000FE4 RID: 4068 RVA: 0x000404E0 File Offset: 0x0003E6E0
		public bool IsAirborne
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Airborne);
			}
			set
			{
				if (value)
				{
					if (this.StateFlags != CharacterState.Airborne)
					{
						this.StateFlags |= CharacterState.Airborne;
						this.LastTickOnGround = base.Level.Ticks;
					}
					this.Mode = CollisionMode.Air;
					this.IsBraking = false;
					this.IsPushing = false;
					return;
				}
				this.StateFlags &= ~CharacterState.Airborne;
				this.IsFlying = false;
				this.IsJumping = false;
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000FE5 RID: 4069 RVA: 0x0004054D File Offset: 0x0003E74D
		// (set) Token: 0x06000FE6 RID: 4070 RVA: 0x00040569 File Offset: 0x0003E769
		public bool IsJumping
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Jumping);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Jumping) : (this.StateFlags & ~CharacterState.Jumping));
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000FE7 RID: 4071 RVA: 0x0004058E File Offset: 0x0003E78E
		// (set) Token: 0x06000FE8 RID: 4072 RVA: 0x000405AF File Offset: 0x0003E7AF
		public int Facing
		{
			get
			{
				if (!this.StateFlags.HasFlag(CharacterState.Left))
				{
					return 1;
				}
				return -1;
			}
			set
			{
				if (value < 0)
				{
					this.StateFlags |= CharacterState.Left;
					return;
				}
				if (value > 0)
				{
					this.StateFlags &= ~CharacterState.Left;
				}
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x000405DE File Offset: 0x0003E7DE
		// (set) Token: 0x06000FEA RID: 4074 RVA: 0x000405FC File Offset: 0x0003E7FC
		public bool IsFacingLeft
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Left);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Left) : (this.StateFlags &= ~CharacterState.Left));
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000FEB RID: 4075 RVA: 0x00040635 File Offset: 0x0003E835
		// (set) Token: 0x06000FEC RID: 4076 RVA: 0x00040654 File Offset: 0x0003E854
		public bool IsFacingRight
		{
			get
			{
				return !this.StateFlags.HasFlag(CharacterState.Left);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags &= ~CharacterState.Left) : (this.StateFlags | CharacterState.Left));
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000FED RID: 4077 RVA: 0x0004068D File Offset: 0x0003E88D
		// (set) Token: 0x06000FEE RID: 4078 RVA: 0x000406A9 File Offset: 0x0003E8A9
		public bool IsUnderwater
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Underwater);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Underwater) : (this.StateFlags & ~CharacterState.Underwater));
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000FEF RID: 4079 RVA: 0x000406CE File Offset: 0x0003E8CE
		// (set) Token: 0x06000FF0 RID: 4080 RVA: 0x000406EC File Offset: 0x0003E8EC
		public bool IsHurt
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Hurt);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Hurt) : (this.StateFlags &= ~CharacterState.Hurt));
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000FF1 RID: 4081 RVA: 0x00040725 File Offset: 0x0003E925
		// (set) Token: 0x06000FF2 RID: 4082 RVA: 0x00040741 File Offset: 0x0003E941
		public bool IsDying
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Dying);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Dying) : (this.StateFlags & ~CharacterState.Dying));
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000FF3 RID: 4083 RVA: 0x00040766 File Offset: 0x0003E966
		// (set) Token: 0x06000FF4 RID: 4084 RVA: 0x00040782 File Offset: 0x0003E982
		public bool IsDead
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Dead);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Dead) : (this.StateFlags & ~CharacterState.Dead));
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000FF5 RID: 4085 RVA: 0x000407A7 File Offset: 0x0003E9A7
		// (set) Token: 0x06000FF6 RID: 4086 RVA: 0x000407C4 File Offset: 0x0003E9C4
		public bool IsDebug
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Debug);
			}
			set
			{
				if (value)
				{
					this.StateFlags = (CharacterState.Debug | (this.StateFlags & CharacterState.Left));
					this.Velocity = new Vector2(0.0, 0.0);
				}
				else
				{
					this.StateFlags = (CharacterState.Airborne | (this.StateFlags & CharacterState.Left));
					if (this.Player.InvincibillityTicks > 0 && !this.IsSidekick)
					{
						this.StateFlags |= CharacterState.Invincible;
					}
				}
				this.IsSpinball = true;
				this.Mode = CollisionMode.Air;
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x00040856 File Offset: 0x0003EA56
		// (set) Token: 0x06000FF8 RID: 4088 RVA: 0x00040872 File Offset: 0x0003EA72
		public bool IsFlying
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Flying);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Flying) : (this.StateFlags & ~CharacterState.Flying));
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x00040897 File Offset: 0x0003EA97
		// (set) Token: 0x06000FFA RID: 4090 RVA: 0x000408B3 File Offset: 0x0003EAB3
		public bool ExhibitsVirtualPlatform
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.VirtualPlatform);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.VirtualPlatform) : (this.StateFlags & ~CharacterState.VirtualPlatform));
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000FFB RID: 4091 RVA: 0x000408D8 File Offset: 0x0003EAD8
		// (set) Token: 0x06000FFC RID: 4092 RVA: 0x000408F4 File Offset: 0x0003EAF4
		public bool HasSpeedShoes
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.SpeedShoes);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.SpeedShoes) : (this.StateFlags & ~CharacterState.SpeedShoes));
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x00040919 File Offset: 0x0003EB19
		// (set) Token: 0x06000FFE RID: 4094 RVA: 0x00040935 File Offset: 0x0003EB35
		public bool IsInvincible
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Invincible);
			}
			set
			{
				if (value)
				{
					if (!this.IsInvincible)
					{
						this.StateFlags |= CharacterState.Invincible;
						this.StartInvincibility();
						return;
					}
				}
				else
				{
					this.StateFlags &= ~CharacterState.Invincible;
				}
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000FFF RID: 4095 RVA: 0x0004096D File Offset: 0x0003EB6D
		// (set) Token: 0x06001000 RID: 4096 RVA: 0x00040989 File Offset: 0x0003EB89
		public bool ForceSpinball
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.ForceSpinball);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.ForceSpinball) : (this.StateFlags & ~CharacterState.ForceSpinball));
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x000409AE File Offset: 0x0003EBAE
		// (set) Token: 0x06001002 RID: 4098 RVA: 0x000409CC File Offset: 0x0003EBCC
		public bool IsWinning
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Winning);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Winning) : (this.StateFlags &= ~CharacterState.Winning));
				if (value)
				{
					this.GroundVelocity = 0.0;
					this.Velocity = default(Vector2);
				}
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x00040A26 File Offset: 0x0003EC26
		// (set) Token: 0x06001004 RID: 4100 RVA: 0x00040A42 File Offset: 0x0003EC42
		public bool IsSuper
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.Super);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.Super) : (this.StateFlags & ~CharacterState.Super));
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06001005 RID: 4101 RVA: 0x00040A67 File Offset: 0x0003EC67
		// (set) Token: 0x06001006 RID: 4102 RVA: 0x00040A83 File Offset: 0x0003EC83
		public bool IsCharging
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.ChargingSpindash);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.ChargingSpindash) : (this.StateFlags & ~CharacterState.ChargingSpindash));
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x00040AA8 File Offset: 0x0003ECA8
		// (set) Token: 0x06001008 RID: 4104 RVA: 0x00040AC4 File Offset: 0x0003ECC4
		public bool ShouldReactToLevel
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.ShouldReactToLevel);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.ShouldReactToLevel) : (this.StateFlags & ~CharacterState.ShouldReactToLevel));
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06001009 RID: 4105 RVA: 0x00040AE9 File Offset: 0x0003ECE9
		// (set) Token: 0x0600100A RID: 4106 RVA: 0x00040B05 File Offset: 0x0003ED05
		public bool IsObjectControlled
		{
			get
			{
				return this.StateFlags.HasFlag(CharacterState.ObjectControlled);
			}
			set
			{
				this.StateFlags = (value ? (this.StateFlags | CharacterState.ObjectControlled) : (this.StateFlags & ~CharacterState.ObjectControlled));
			}
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x0600100B RID: 4107 RVA: 0x00040B2A File Offset: 0x0003ED2A
		// (set) Token: 0x0600100C RID: 4108 RVA: 0x00040B32 File Offset: 0x0003ED32
		public int BreathTicks { get; set; }

		// Token: 0x0600100D RID: 4109 RVA: 0x00040B3C File Offset: 0x0003ED3C
		private void UpdateWaterLogic()
		{
			if (this.IsDying && this._deathCause == PlayerDeathCause.Drown)
			{
				this.IsUnderwater = true;
				int num = this._nextBubbleTime;
				this._nextBubbleTime = num - 1;
				if (num < 0)
				{
					this._nextBubbleTime = base.Level.Random.Next(2, 8);
					this.CreateBubble(1);
				}
				return;
			}
			if (this.IsDying || this.IsDead)
			{
				return;
			}
			bool isUnderwater = this.IsUnderwater;
			bool flag = this.IsUnderwater = base.Level.WaterManager.IsUnderwater(base.Position);
			if (!isUnderwater && flag)
			{
				this.EnterWater();
			}
			else if (isUnderwater && !flag)
			{
				this.LeaveWater();
			}
			if (flag)
			{
				int num = this._nextBubbleTime;
				this._nextBubbleTime = num - 1;
				if (num < 0)
				{
					this._nextBubbleTime = base.Level.Random.Next((Math.Abs(this.Velocity.X) > 4.0) ? 8 : 32, (Math.Abs(this.Velocity.X) > 4.0) ? 32 : 128);
					this.CreateBubble(0);
				}
				num = this.BreathTicks;
				this.BreathTicks = num - 1;
				this.CheckForDrowning();
				if (this.Barrier == BarrierType.Fire || this.Barrier == BarrierType.Lightning)
				{
					this.Barrier = BarrierType.None;
					return;
				}
			}
			else
			{
				this.BreathTicks = 1800;
			}
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x00040CA8 File Offset: 0x0003EEA8
		private void EnterWater()
		{
			this.Velocity = new Vector2(this.Velocity.X / 2.0, this.Velocity.Y / 4.0);
			if (this.IsAirborne && !this.IsObjectControlled)
			{
				base.Level.WaterManager.CreateSplash(base.Layer, SplashType.Enter, base.Position);
				base.Level.SoundManager.PlaySound("SONICORCA/SOUND/SPLASH");
			}
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00040D34 File Offset: 0x0003EF34
		private void LeaveWater()
		{
			if (this.IsAirborne && this.Velocity.Y < 0.0)
			{
				this.Velocity = new Vector2(this.Velocity.X, Math.Max(this.Velocity.Y * 2.0, -48.0));
			}
			if (this.IsAirborne && !this.IsObjectControlled && !this.IsDying)
			{
				base.Level.WaterManager.CreateSplash(base.Layer, SplashType.Exit, base.Position);
				base.Level.SoundManager.PlaySound("SONICORCA/SOUND/SPLASH");
			}
			this.BreathTicks = 1800;
			if (this._drowningClimax && !this.IsSidekick)
			{
				base.Level.SoundManager.StopJingle(JingleType.Drowning);
				base.Level.SoundManager.PlayMusic(false);
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x00040E28 File Offset: 0x0003F028
		private void CheckForDrowning()
		{
			if (this.BreathTicks > 720)
			{
				if (Character.BreathLeftWarnings.Contains(this.BreathTicks) && !this.IsSidekick)
				{
					base.Level.SoundManager.PlaySound("SONICORCA/SOUND/DROWNWARNING");
				}
				this._drowningClimax = false;
				return;
			}
			if (!this._drowningClimax)
			{
				if (!this.IsSidekick)
				{
					base.Level.SoundManager.PlayJingle(JingleType.Drowning);
				}
				this._drowningClimax = true;
			}
			if (this.BreathTicks <= 300 && this.BreathTicks % 60 == 0)
			{
				this.ShowBreathTimeRemaining(this.BreathTicks / 60);
			}
			if (this.BreathTicks <= -60)
			{
				this.Drown();
			}
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x00040ED8 File Offset: 0x0003F0D8
		private void Drown()
		{
			this.Kill(PlayerDeathCause.Drown);
			this.Velocity = default(Vector2);
			if (!this.IsSidekick)
			{
				base.Level.SoundManager.StopJingle(JingleType.Drowning);
			}
			base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/DROWN");
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x00040F2C File Offset: 0x0003F12C
		private void ShowBreathTimeRemaining(int secondsLeft)
		{
			this._drownCountdownValue = secondsLeft;
			this._drownCountdownPosition = base.Position + new Vector2i(96, -96);
			if (secondsLeft >= 0 && secondsLeft <= 5)
			{
				this._drowningAnimation.Index = 5 - secondsLeft;
				this._drowningAnimation.Cycles = 0;
			}
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x00040F7C File Offset: 0x0003F17C
		private void CreateBubble(int size)
		{
			base.Level.WaterManager.CreateBubble(base.Level.Map.Layers.IndexOf(base.Layer), base.Position + new Vector2i(8, -8), size);
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x00040FC8 File Offset: 0x0003F1C8
		public void InhaleOxygen()
		{
			this.BreathTicks = 1800;
			if (this._drowningClimax && !this.IsSidekick)
			{
				base.Level.SoundManager.StopJingle(JingleType.Drowning);
				base.Level.SoundManager.PlayMusic(false);
			}
			this.IsSpinball = false;
			this._inhalingBubble = 1;
			base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/INHALE");
		}

		// Token: 0x0400086B RID: 2155
		private BarrierType _barrierTypeAnimation;

		// Token: 0x0400086C RID: 2156
		public const double TumbleSpeed = 0.0234375;

		// Token: 0x0400086D RID: 2157
		private const int KeepSpinballAirborneTolerance = 11;

		// Token: 0x0400086E RID: 2158
		private readonly bool[] _collisionDetected = new bool[4];

		// Token: 0x0400086F RID: 2159
		private readonly CollisionEvent[] _collisionEvents = new CollisionEvent[4];

		// Token: 0x04000870 RID: 2160
		private readonly bool[] _collisionDetectedTiles = new bool[4];

		// Token: 0x04000871 RID: 2161
		private readonly CollisionEvent[] _collisionEventsTiles = new CollisionEvent[4];

		// Token: 0x04000872 RID: 2162
		private readonly List<KeyValuePair<ActiveObject, CollisionEvent>> _collidedVectors = new List<KeyValuePair<ActiveObject, CollisionEvent>>();

		// Token: 0x04000873 RID: 2163
		private CollisionVector _originalGroundVector;

		// Token: 0x04000874 RID: 2164
		private CollisionVector _overlappingGroundVector;

		// Token: 0x04000875 RID: 2165
		private KeyValuePair<ActiveObject, CollisionEvent> _overlappingCollision;

		// Token: 0x04000876 RID: 2166
		private Vector2 _lastPositionAdjusted;

		// Token: 0x04000889 RID: 2185
		private CollisionVector _lastLeftVector;

		// Token: 0x0400088A RID: 2186
		private CollisionVector _lastRightVector;

		// Token: 0x0400088B RID: 2187
		private const string DefaultBarrierClassicResourceKey = "SONICORCA/OBJECTS/BARRIER/ANIGROUP";

		// Token: 0x0400088C RID: 2188
		private const string DefaultBarrierBubbleResourceKey = "SONICORCA/OBJECTS/BARRIER/BUBBLE/ANIGROUP";

		// Token: 0x0400088D RID: 2189
		private const string DefaultBarrierFireResourceKey = "SONICORCA/OBJECTS/BARRIER/FIRE/ANIGROUP";

		// Token: 0x0400088E RID: 2190
		private const string DefaultBarrierLightningResourceKey = "SONICORCA/OBJECTS/BARRIER/LIGHTNING/ANIGROUP";

		// Token: 0x0400088F RID: 2191
		private const string DefaultSpindashDustResourceKey = "SONICORCA/OBJECTS/SPINDASH/ANIGROUP";

		// Token: 0x04000890 RID: 2192
		private const string DefaultBrakeDustResourceKey = "SONICORCA/OBJECTS/DUST";

		// Token: 0x04000891 RID: 2193
		private const string DefaultInvincibilityResourceKey = "SONICORCA/OBJECTS/INVINCIBILITY/ANIGROUP";

		// Token: 0x04000892 RID: 2194
		private const int MaximumVelocity = 96;

		// Token: 0x04000893 RID: 2195
		private readonly CharacterHistoryItem[] _history = new CharacterHistoryItem[32];

		// Token: 0x04000894 RID: 2196
		private CharacterBalanceDirection _balanceDirection;

		// Token: 0x04000895 RID: 2197
		private int _brakeDustDelay;

		// Token: 0x04000896 RID: 2198
		private int _brakeTicks;

		// Token: 0x04000897 RID: 2199
		private int _pushDirection;

		// Token: 0x04000898 RID: 2200
		private int _pushTicks;

		// Token: 0x04000899 RID: 2201
		private double _spindashExtraSpeed;

		// Token: 0x040008B0 RID: 2224
		private Vector2 _intersection;

		// Token: 0x040008B1 RID: 2225
		private int _dyingTicks;

		// Token: 0x040008B2 RID: 2226
		private PlayerDeathCause _deathCause;

		// Token: 0x040008B4 RID: 2228
		private static readonly IReadOnlyList<Vector2> ScatterRingOffsets = new Vector2[]
		{
			new Vector2(-3.12, -15.69),
			new Vector2(3.12, -15.69),
			new Vector2(-8.89, -13.3),
			new Vector2(8.89, -13.3),
			new Vector2(-13.3, -8.89),
			new Vector2(13.3, -8.89),
			new Vector2(-15.69, -3.12),
			new Vector2(15.69, -3.12),
			new Vector2(-15.69, 3.12),
			new Vector2(15.69, 3.12),
			new Vector2(-13.3, 8.89),
			new Vector2(13.3, 8.89),
			new Vector2(-8.89, 13.3),
			new Vector2(8.89, 13.3),
			new Vector2(-3.12, 15.69),
			new Vector2(3.12, 15.69),
			new Vector2(-1.56, -7.85),
			new Vector2(1.56, -7.85),
			new Vector2(-4.44, -6.65),
			new Vector2(4.44, -6.65),
			new Vector2(-6.65, -4.44),
			new Vector2(6.65, -4.44),
			new Vector2(-7.85, -1.56),
			new Vector2(7.85, -1.56),
			new Vector2(-7.85, 1.56),
			new Vector2(7.85, 1.56),
			new Vector2(-6.65, 4.44),
			new Vector2(6.65, 4.44),
			new Vector2(-4.44, 6.65),
			new Vector2(4.44, 6.65),
			new Vector2(-1.56, 7.85),
			new Vector2(1.56, 7.85)
		};

		// Token: 0x040008B5 RID: 2229
		private readonly List<Character.InvincibilityParticle> _invincibilityParticles = new List<Character.InvincibilityParticle>();

		// Token: 0x040008B6 RID: 2230
		private readonly List<Vector2> _invincibilityCharacterPositionHistory = new List<Vector2>();

		// Token: 0x040008B7 RID: 2231
		private const int InvincibilityParticlesPerPositionHistory = 3;

		// Token: 0x040008B8 RID: 2232
		private const int InvincibilityPositionHistoryChunks = 4;

		// Token: 0x040008B9 RID: 2233
		private const int InvincibilityPositionHistoryDelay = 2;

		// Token: 0x040008BB RID: 2235
		public const int NoHumanInputTime = 600;

		// Token: 0x040008BC RID: 2236
		public const int SidekickOffscreenTime = 300;

		// Token: 0x040008BD RID: 2237
		private bool _humanControlled;

		// Token: 0x040008BE RID: 2238
		private int _humanInputTicksRemaining;

		// Token: 0x040008BF RID: 2239
		private Character.AutoSidekickState _autoSidekickState;

		// Token: 0x040008C0 RID: 2240
		private int _sidekickOffscreenTicks;

		// Token: 0x040008C1 RID: 2241
		private Vector2i _sidekickTargetPosition;

		// Token: 0x040008C2 RID: 2242
		private bool _autoSidekickJumping;

		// Token: 0x040008C6 RID: 2246
		private const string DrowningCountDownResourceKey = "SONICORCA/HUD/DROWNING/ANIGROUP";

		// Token: 0x040008C7 RID: 2247
		private const string InhaleSoundResourceKey = "SONICORCA/SOUND/INHALE";

		// Token: 0x040008C8 RID: 2248
		private const string SplashSoundResourceKey = "SONICORCA/SOUND/SPLASH";

		// Token: 0x040008C9 RID: 2249
		private const string DrownWarningSoundResourceKey = "SONICORCA/SOUND/DROWNWARNING";

		// Token: 0x040008CA RID: 2250
		private const string DrownSoundResourceKey = "SONICORCA/SOUND/DROWN";

		// Token: 0x040008CB RID: 2251
		private static readonly IReadOnlyCollection<int> BreathLeftWarnings = new int[]
		{
			1500,
			1200,
			900
		};

		// Token: 0x040008CC RID: 2252
		private const int BreathLeftDrowningMusic = 720;

		// Token: 0x040008CD RID: 2253
		private const int MaximumBreath = 1800;

		// Token: 0x040008CE RID: 2254
		private AnimationInstance _drowningAnimation;

		// Token: 0x040008CF RID: 2255
		private int _nextBubbleTime;

		// Token: 0x040008D0 RID: 2256
		private bool _drowningClimax;

		// Token: 0x040008D1 RID: 2257
		private int _inhalingBubble;

		// Token: 0x040008D2 RID: 2258
		private Vector2i _drownCountdownPosition;

		// Token: 0x040008D3 RID: 2259
		private int _drownCountdownValue;

		// Token: 0x02000247 RID: 583
		private enum CollisionBox
		{
			// Token: 0x04000C8F RID: 3215
			TopLeft,
			// Token: 0x04000C90 RID: 3216
			TopRight,
			// Token: 0x04000C91 RID: 3217
			BottomLeft,
			// Token: 0x04000C92 RID: 3218
			BottomRight
		}

		// Token: 0x02000248 RID: 584
		public class Intersector
		{
			// Token: 0x06001493 RID: 5267 RVA: 0x0004EE4C File Offset: 0x0004D04C
			private static double[] OverlapIntervals(double ub1, double ub2)
			{
				double val = Math.Min(ub1, ub2);
				double val2 = Math.Max(ub1, ub2);
				double num = Math.Max(0.0, val);
				double num2 = Math.Min(1.0, val2);
				if (num > num2)
				{
					return new double[0];
				}
				if (num == num2)
				{
					return new double[]
					{
						num
					};
				}
				return new double[]
				{
					num,
					num2
				};
			}

			// Token: 0x06001494 RID: 5268 RVA: 0x0004EEB4 File Offset: 0x0004D0B4
			private static Vector2[] OneD_Intersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
			{
				double num = a2.X - a1.X;
				double num2 = a2.Y - a1.Y;
				double ub;
				double ub2;
				if (Math.Abs(num) > Math.Abs(num2))
				{
					ub = (b1.X - a1.X) / num;
					ub2 = (b2.X - a1.X) / num;
				}
				else
				{
					ub = (b1.Y - a1.Y) / num2;
					ub2 = (b2.Y - a1.Y) / num2;
				}
				List<Vector2> list = new List<Vector2>();
				foreach (float num3 in Character.Intersector.OverlapIntervals(ub, ub2))
				{
					double x = a2.X * (double)num3 + a1.X * (double)(1f - num3);
					double y = a2.Y * (double)num3 + a1.Y * (double)(1f - num3);
					Vector2 item = new Vector2(x, y);
					list.Add(item);
				}
				return list.ToArray();
			}

			// Token: 0x06001495 RID: 5269 RVA: 0x0004EFC0 File Offset: 0x0004D1C0
			private static bool PointOnLine(Vector2 p, Vector2 a1, Vector2 a2)
			{
				double num = 0.0;
				return Character.Intersector.DistFromSeg(p, a1, a2, Character.Intersector.MyEpsilon, ref num) < Character.Intersector.MyEpsilon;
			}

			// Token: 0x06001496 RID: 5270 RVA: 0x0004EFF0 File Offset: 0x0004D1F0
			private static double DistFromSeg(Vector2 p, Vector2 q0, Vector2 q1, double radius, ref double u)
			{
				double num = q1.X - q0.X;
				double num2 = q1.Y - q0.Y;
				double num3 = q0.X - p.X;
				double num4 = q0.Y - p.Y;
				double num5 = Math.Sqrt(num * num + num2 * num2);
				if (num5 < Character.Intersector.MyEpsilon)
				{
					throw new Exception("Expected line segment, not point.");
				}
				return Math.Abs(num * num4 - num3 * num2) / num5;
			}

			// Token: 0x06001497 RID: 5271 RVA: 0x0004F06C File Offset: 0x0004D26C
			public static Vector2[] Intersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
			{
				if (a1.Equals(a2) && b1.Equals(b2))
				{
					if (a1.Equals(b1))
					{
						return new Vector2[]
						{
							a1
						};
					}
					return new Vector2[0];
				}
				else if (b1.Equals(b2))
				{
					if (Character.Intersector.PointOnLine(b1, a1, a2))
					{
						return new Vector2[]
						{
							b1
						};
					}
					return new Vector2[0];
				}
				else if (a1.Equals(a2))
				{
					if (Character.Intersector.PointOnLine(a1, b1, b2))
					{
						return new Vector2[]
						{
							a1
						};
					}
					return new Vector2[0];
				}
				else
				{
					double num = (b2.X - b1.X) * (a1.Y - b1.Y) - (b2.Y - b1.Y) * (a1.X - b1.X);
					double num2 = (a2.X - a1.X) * (a1.Y - b1.Y) - (a2.Y - a1.Y) * (a1.X - b1.X);
					double num3 = (b2.Y - b1.Y) * (a2.X - a1.X) - (b2.X - b1.X) * (a2.Y - a1.Y);
					if (-Character.Intersector.MyEpsilon >= num3 || num3 >= Character.Intersector.MyEpsilon)
					{
						double num4 = num / num3;
						double num5 = num2 / num3;
						if (0.0 <= num4 && num4 <= 1.0 && 0.0 <= num5 && num5 <= 1.0)
						{
							return new Vector2[]
							{
								new Vector2(a1.X + num4 * (a2.X - a1.X), a1.Y + num4 * (a2.Y - a1.Y))
							};
						}
						return new Vector2[0];
					}
					else
					{
						if ((-Character.Intersector.MyEpsilon >= num || num >= Character.Intersector.MyEpsilon) && (-Character.Intersector.MyEpsilon >= num2 || num2 >= Character.Intersector.MyEpsilon))
						{
							return new Vector2[0];
						}
						if (a1.Equals(a2))
						{
							return Character.Intersector.OneD_Intersection(b1, b2, a1, a2);
						}
						return Character.Intersector.OneD_Intersection(a1, a2, b1, b2);
					}
				}
			}

			// Token: 0x04000C93 RID: 3219
			private static double MyEpsilon = 1E-05;
		}

		// Token: 0x02000249 RID: 585
		private class InvincibilityParticle
		{
			// Token: 0x17000548 RID: 1352
			// (get) Token: 0x0600149A RID: 5274 RVA: 0x0004F2B2 File Offset: 0x0004D4B2
			// (set) Token: 0x0600149B RID: 5275 RVA: 0x0004F2BA File Offset: 0x0004D4BA
			public Vector2 Origin { get; set; }

			// Token: 0x0600149C RID: 5276 RVA: 0x0004F2C4 File Offset: 0x0004D4C4
			public InvincibilityParticle(Character character, double initialAngle, AnimationGroup animationGroup, int animationIndex)
			{
				this._character = character;
				this._angle = initialAngle;
				this._animation = new AnimationInstance(animationGroup, 0);
				this._animation.Index = animationIndex;
				this._animation.CurrentFrameIndex = this._character.Level.Random.Next(animationGroup[animationIndex].Frames.Count);
			}

			// Token: 0x0600149D RID: 5277 RVA: 0x0004F334 File Offset: 0x0004D534
			public void Animate()
			{
				this._angle = MathX.WrapRadians(this._angle + 0.19634954084936207);
				this._position.X = Math.Cos(this._angle) * 46.0 + (double)this._character.Level.Random.Next(-8, 8);
				this._position.Y = Math.Sin(this._angle) * 64.0 + (double)this._character.Level.Random.Next(-8, 8);
				this._animation.Animate();
			}

			// Token: 0x0600149E RID: 5278 RVA: 0x0004F3DC File Offset: 0x0004D5DC
			public void Draw(Renderer renderer)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				objectRenderer.BlendMode = BlendMode.Additive;
				int filter = objectRenderer.Filter;
				objectRenderer.EmitsLight = true;
				objectRenderer.Render(this._animation, this.Origin - this._character.Position + this._position, false, false);
				objectRenderer.EmitsLight = false;
			}

			// Token: 0x04000C94 RID: 3220
			private readonly Character _character;

			// Token: 0x04000C95 RID: 3221
			private readonly AnimationInstance _animation;

			// Token: 0x04000C96 RID: 3222
			private double _angle;

			// Token: 0x04000C97 RID: 3223
			private Vector2 _position;
		}

		// Token: 0x0200024A RID: 586
		private enum AutoSidekickState
		{
			// Token: 0x04000C9A RID: 3226
			Spawning,
			// Token: 0x04000C9B RID: 3227
			Flying,
			// Token: 0x04000C9C RID: 3228
			Normal,
			// Token: 0x04000C9D RID: 3229
			Spindash
		}
	}
}
