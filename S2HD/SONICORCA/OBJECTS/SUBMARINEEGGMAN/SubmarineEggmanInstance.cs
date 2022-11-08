using System;
using System.Collections.Generic;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SONICORCA.OBJECTS.DUST;
using SonicOrca.Resources;

namespace SONICORCA.OBJECTS.SUBMARINEEGGMAN
{
	// Token: 0x02000058 RID: 88
	public class SubmarineEggmanInstance : BossObject
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x0000E020 File Offset: 0x0000C220
		protected override void OnStart()
		{
			ResourceTree resourceTree = base.Level.GameContext.ResourceTree;
			AnimationGroup loadedResource = resourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
			AnimationGroup loadedResource2 = resourceTree.GetLoadedResource<AnimationGroup>(base.Type, "SONICORCA/OBJECTS/ROBOTNIK/ANIGROUP");
			this._animationInside = new AnimationInstance(loadedResource, 0);
			this._animationRobotnik = new AnimationInstance(loadedResource2, 0);
			this._animationBody = new AnimationInstance(loadedResource, 1);
			this._animationLights = new AnimationInstance(loadedResource, 4);
			this._animationHighlightsSpawnIntro = new AnimationInstance(loadedResource, 8);
			this._animationHighlightsIntro = new AnimationInstance(loadedResource, 9);
			this._animationHighlightsEnd = new AnimationInstance(loadedResource, 10);
			this._animationHighlightsLava = new AnimationInstance(loadedResource, 11);
			this._brokenPartsPositions[12] = new Vector2i(-20, -64);
			this._brokenPartsPositions[14] = new Vector2i(-8, -88);
			this._brokenPartsPositions[15] = new Vector2i(-16, -112);
			this._brokenPartsPositions[13] = new Vector2i(-44, -112);
			this._brokenPartsPositions[16] = new Vector2i(-80, -112);
			this._brokenPartsIndexOrder[0] = 16;
			this._brokenPartsIndexOrder[1] = 13;
			this._brokenPartsIndexOrder[2] = 15;
			this._brokenPartsIndexOrder[3] = 14;
			this._brokenPartsIndexOrder[4] = 12;
			this._animationGroup = loadedResource;
			this._brokenPartsA = new AnimationInstance(this._animationGroup, 12);
			this._brokenPartsB = new AnimationInstance(this._animationGroup, 13);
			this._brokenPartsC = new AnimationInstance(this._animationGroup, 14);
			this._brokenPartsD = new AnimationInstance(this._animationGroup, 15);
			this._brokenPartsE = new AnimationInstance(this._animationGroup, 16);
			base.ExplosionResourceKey = base.Type.GetAbsolutePath("SONICORCA/OBJECTS/EXPLOSION/BOSS");
			base.HitSoundResourceKey = base.Type.GetAbsolutePath("SONICORCA/SOUND/BOSSHIT");
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -100, -100, 200, 200)
			};
			this._startPosition = base.Position;
			this._leftX += this._startPosition.X;
			this._rightX += this._startPosition.X;
			this._leftPeekY += this._startPosition.Y;
			this._leftFireballY += this._startPosition.Y;
			this._leftSpawnY += this._startPosition.Y;
			this._rightPeekY += this._startPosition.Y;
			this._rightFireballY += this._startPosition.Y;
			this._rightSpawnY += this._startPosition.Y;
			base.LockLifetime = true;
			this._velocity = new Vector2(0.0, -3.5);
			this._isRightPit = true;
			this._state = SubmarineEggmanInstance.State.Raise;
			base.Health = 8;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000E33C File Offset: 0x0000C53C
		private void ResetHighlights()
		{
			this._animationHighlightsSpawnIntro.ResetFrame();
			this._animationHighlightsSpawnIntro.Cycles = 0;
			this._animationHighlightsIntro.ResetFrame();
			this._animationHighlightsIntro.Cycles = 0;
			this._animationHighlightsEnd.ResetFrame();
			this._animationHighlightsEnd.Cycles = 0;
			this._currentHighlight = this._animationHighlightsSpawnIntro;
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000E39A File Offset: 0x0000C59A
		private void CleanHighlights()
		{
			this.ResetHighlights();
			this._currentHighlight = null;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000E3AC File Offset: 0x0000C5AC
		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (base.Health == 1 && base.Level.Random.Next(15) == 0)
			{
				this.EmitSmoke(new Vector2i(base.Level.Random.Next(-128, 128), base.Level.Random.Next(-64, -32)), new Vector2(0.0, -4.0));
			}
			switch (this._state)
			{
			case SubmarineEggmanInstance.State.Raise:
				base.PositionPrecise += this._velocity;
				if (base.Position.Y <= (this._isRightPit ? this._rightPeekY : this._leftPeekY))
				{
					this._velocity.Y = 0.0;
					this._state = SubmarineEggmanInstance.State.PrepareFlameThrower;
					this._stateTimer = 60;
					this._nonHoverPosition = base.PositionPrecise;
					this._floatOffsetAngle = 0.0;
					return;
				}
				break;
			case SubmarineEggmanInstance.State.PrepareFlameThrower:
				this._stateTimer--;
				if (this._stateTimer > 0)
				{
					this.Hover();
					return;
				}
				if (this._stateTimer == 0)
				{
					this.CreateFlameThrowerFlame();
					this.ResetHighlights();
					return;
				}
				if (this._stateTimer <= -120)
				{
					this.CreateFlameThrowerShot();
					this._currentHighlight = this._animationHighlightsIntro;
					this._stateTimer = 47;
					this._state = SubmarineEggmanInstance.State.Hover;
					return;
				}
				break;
			case SubmarineEggmanInstance.State.Hover:
				this._stateTimer--;
				if (this._stateTimer > 0)
				{
					this.Hover();
					return;
				}
				this._currentHighlight = this._animationHighlightsEnd;
				this._velocity = new Vector2(0.0, 3.5);
				this._state = SubmarineEggmanInstance.State.Lower;
				return;
			case SubmarineEggmanInstance.State.Lower:
			{
				base.PositionPrecise += this._velocity;
				if (base.Position.Y > (this._isRightPit ? this._rightFireballY : this._leftFireballY) && !this._firedFireball)
				{
					this.CreateFireball(-1);
					this.CreateFireball(1);
					base.Level.SoundManager.PlaySound(base.Position, "SONICORCA/SOUND/FIREBALL");
					this._firedFireball = true;
				}
				if (this._isRightPit)
				{
					if (base.Position.Y < this._rightSpawnY)
					{
						break;
					}
					base.Position = new Vector2i(base.Position.X, this._rightSpawnY);
				}
				else
				{
					if (base.Position.Y < this._leftSpawnY)
					{
						break;
					}
					base.Position = new Vector2i(base.Position.X, this._leftSpawnY);
				}
				this._velocity = new Vector2(0.0, -3.5);
				this._state = SubmarineEggmanInstance.State.Raise;
				this._firedFireball = false;
				ICharacter protagonist = base.Level.Player.Protagonist;
				if (protagonist.Position.X < this._startPosition.X - 512)
				{
					base.Position = new Vector2i(this._leftX, this._leftSpawnY);
					this._isRightPit = false;
				}
				else
				{
					base.Position = new Vector2i(this._rightX, this._rightSpawnY);
					this._isRightPit = true;
				}
				this._flipX = (protagonist.Position.X >= base.Position.X);
				return;
			}
			case SubmarineEggmanInstance.State.Defeated:
				this.CleanHighlights();
				this._stateTimer--;
				if (this._stateTimer > 0)
				{
					if (this._stateTimer % 16 == 0 && this._brokenPartsCounter < 5)
					{
						int num = this._brokenPartsIndexOrder[this._brokenPartsCounter];
						Vector2i position = base.Position;
						Vector2i vector2i = this._brokenPartsPositions[num];
						vector2i = position + vector2i;
						this.ReleaseFragmentMetal(vector2i, 6.0, num, true);
						switch (num)
						{
						case 12:
							this._brokenPartsA = null;
							break;
						case 13:
							this._brokenPartsB = null;
							break;
						case 14:
							this._brokenPartsC = null;
							break;
						case 15:
							this._brokenPartsD = null;
							break;
						case 16:
							this._brokenPartsE = null;
							break;
						}
						this._brokenPartsCounter++;
					}
					base.UpdateExplosions(128);
					if (this._stateTimer < 30)
					{
						this.UpdateSmoke();
						return;
					}
				}
				else
				{
					this._animationBody.Index = 3;
					this._animationRobotnik.Index = 0;
					this.UpdateSmoke();
					if (this._stateTimer <= -60)
					{
						base.Defeated = true;
						base.Fleeing = true;
						base.LockLifetime = false;
						base.Position += new Vector2i(0, 8);
					}
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000E878 File Offset: 0x0000CA78
		private void EmitSmoke(Vector2 offset, Vector2 velocity)
		{
			Matrix4 matrix = Matrix4.Identity;
			matrix *= Matrix4.CreateTranslation(base.Position);
			if (this._flipX)
			{
				matrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
			}
			matrix = (matrix * Matrix4.CreateTranslation(offset)).RotateZ(0.0);
			Vector2i position = (Vector2i)(matrix * new Vector2(0.0, 100.0));
			DustInstance dustInstance = base.Level.ObjectManager.AddObject(new ObjectPlacement("SONICORCA/OBJECTS/DUST", base.Level.Map.Layers.IndexOf(base.Layer), position)) as DustInstance;
			dustInstance.SetDustAnimationIndex(1);
			dustInstance.Velocity = velocity;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000E95C File Offset: 0x0000CB5C
		private void Hover()
		{
			double y = Math.Sin(this._floatOffsetAngle) / 3.141592653589793 * 16.0;
			base.PositionPrecise = this._nonHoverPosition + new Vector2(0.0, y);
			this._floatOffsetAngle += 0.04908738521234052;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000E9C0 File Offset: 0x0000CBC0
		private void CreateFlameThrowerFlame()
		{
			SubmarineEggmanInstance.FlameThrower flameThrower = base.Level.ObjectManager.AddSubObject<SubmarineEggmanInstance.FlameThrower>(this);
			flameThrower.FlipX = this._flipX;
			flameThrower.Position = base.Position + new Vector2i(this._flipX ? 132 : -132, -121);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000EA18 File Offset: 0x0000CC18
		private void CreateFlameThrowerShot()
		{
			SubmarineEggmanInstance.FlameThrowerShot flameThrowerShot = base.Level.ObjectManager.AddSubObject<SubmarineEggmanInstance.FlameThrowerShot>(this);
			flameThrowerShot.FlipX = this._flipX;
			flameThrowerShot.Position = base.Position + new Vector2i(this._flipX ? 448 : -448, -112);
			flameThrowerShot.Velocity = new Vector2i(this._flipX ? 16 : -16, 0);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000EA88 File Offset: 0x0000CC88
		private void CreateFireball(int direction)
		{
			SubmarineEggmanInstance.Fireball fireball = base.Level.ObjectManager.AddSubObject<SubmarineEggmanInstance.Fireball>(this);
			fireball.IsMainFireball = true;
			fireball.SpawnDirection = (SubmarineEggmanInstance.Fireball.FireSpawn)direction;
			fireball.Position = base.Position;
			if (this._isRightPit)
			{
				if (direction == 1)
				{
					fireball.Velocity = new Vector2(7.0, -25.0);
					return;
				}
				if (direction == -1)
				{
					fireball.Velocity = new Vector2(-6.85, -25.0);
					return;
				}
			}
			else
			{
				if (direction == 1)
				{
					fireball.Velocity = new Vector2(6.7, -21.0);
					return;
				}
				if (direction == -1)
				{
					fireball.Velocity = new Vector2(-7.0, -21.0);
				}
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000EB50 File Offset: 0x0000CD50
		protected override void Hit(ICharacter character)
		{
			base.Hit(character);
			if (character.Velocity.Y < -15.125)
			{
				character.Velocity = new Vector2(character.Velocity.X, -15.125);
			}
			if (base.Health > 0)
			{
				this._animationRobotnik.Index = 1;
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000EBB4 File Offset: 0x0000CDB4
		protected override void Defeat()
		{
			base.Defeat();
			this._state = SubmarineEggmanInstance.State.Defeated;
			this._stateTimer = 179;
			this._animationBody.Index = 2;
			this._animationRobotnik.Index = 2;
			base.CollisionRectangles = new CollisionRectangle[0];
			base.Level.Player.GainScore(1000);
			base.Level.CreateScoreObject(1000, base.Position + new Vector2i(0, -128));
		}

		// Token: 0x060001DB RID: 475 RVA: 0x0000EC38 File Offset: 0x0000CE38
		private void UpdateSmoke()
		{
			if (base.Level.Random.Next(15) == 0)
			{
				this.EmitSmoke(new Vector2i(base.Level.Random.Next(-128, 128), base.Level.Random.Next(-64, -32)), new Vector2(0.0, -4.0));
			}
		}

		// Token: 0x060001DC RID: 476 RVA: 0x0000ECAC File Offset: 0x0000CEAC
		private void ReleaseFragmentMetal(Vector2i position, double speed, int index, bool explode = true)
		{
			double num = base.Level.Random.NextRadians();
			Vector2 velocity = new Vector2(speed * Math.Cos(num), speed * Math.Sin(num));
			this.ReleaseFragmentMetal(position, velocity, index);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x0000ECF0 File Offset: 0x0000CEF0
		private void ReleaseFragmentMetal(Vector2i position, Vector2 velocity, int index)
		{
			Fragment fragment = base.Level.ObjectManager.AddSubObject<Fragment>(this);
			fragment.AnimationGroup = this._animationGroup;
			fragment.AnimationIndex = index;
			fragment.Position = position;
			fragment.Velocity = velocity;
			fragment.AngularVelocity = 0.41887902047863906;
			fragment.FlipX = base.Level.Random.NextBoolean();
			fragment.Initialise();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000ED5C File Offset: 0x0000CF5C
		protected override void OnAnimate()
		{
			this._animationInside.Animate();
			this._animationRobotnik.Animate();
			this._animationBody.Animate();
			this._animationLights.Animate();
			if (this._currentHighlight != null)
			{
				if (this._currentHighlight == this._animationHighlightsEnd)
				{
					this._currentHighlight.Animate();
					if (this._currentHighlight.Cycles > 0)
					{
						this._currentHighlight = null;
						this.CleanHighlights();
						return;
					}
				}
				else
				{
					this._currentHighlight.Animate();
				}
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000EDE0 File Offset: 0x0000CFE0
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.FilterAmount *= 0.5;
			objectRenderer.Render(this._animationInside, this._flipX, false);
			objectRenderer.Render(this._animationRobotnik, new Vector2i(this._flipX ? 32 : -32, -42), this._flipX, false);
			if (base.IsInvincibleFlashing)
			{
				objectRenderer.AdditiveColour = BossObject.FlashAdditiveColour;
			}
			objectRenderer.Render(this._animationBody, this._flipX, false);
			objectRenderer.EmitsLight = true;
			objectRenderer.Render(this._animationLights, this._flipX, false);
			if (this._currentHighlight != null)
			{
				objectRenderer.Render(this._currentHighlight, new Vector2i(0, 0), this._flipX, false);
			}
			objectRenderer.Render(this._animationHighlightsLava, new Vector2i(0, 0), this._flipX, false);
			if (this._state == SubmarineEggmanInstance.State.Defeated)
			{
				if (this._brokenPartsA != null)
				{
					Vector2i v = this._brokenPartsPositions[12];
					objectRenderer.Render(this._brokenPartsA, v, this._flipX, false);
				}
				if (this._brokenPartsC != null)
				{
					Vector2i v2 = this._brokenPartsPositions[14];
					objectRenderer.Render(this._brokenPartsC, v2, this._flipX, false);
				}
				if (this._brokenPartsD != null)
				{
					Vector2i v3 = this._brokenPartsPositions[15];
					objectRenderer.Render(this._brokenPartsD, v3, this._flipX, false);
				}
				if (this._brokenPartsB != null)
				{
					Vector2i v4 = this._brokenPartsPositions[13];
					objectRenderer.Render(this._brokenPartsB, v4, this._flipX, false);
				}
				if (this._brokenPartsE != null)
				{
					Vector2i v5 = this._brokenPartsPositions[16];
					objectRenderer.Render(this._brokenPartsE, v5, this._flipX, false);
				}
			}
		}

		// Token: 0x04000207 RID: 519
		public const int AnimationMobileInside = 0;

		// Token: 0x04000208 RID: 520
		public const int AnimationMobileBody = 1;

		// Token: 0x04000209 RID: 521
		public const int AnimationMobileBodyExploding = 2;

		// Token: 0x0400020A RID: 522
		public const int AnimationMobileBodyDefeated = 3;

		// Token: 0x0400020B RID: 523
		public const int AnimationMobileLights = 4;

		// Token: 0x0400020C RID: 524
		public const int AnimationFlameThrower = 5;

		// Token: 0x0400020D RID: 525
		public const int AnimationFlameThrowerShot = 6;

		// Token: 0x0400020E RID: 526
		public const int AnimationFireball = 7;

		// Token: 0x0400020F RID: 527
		public const int AnimationHighlightsSpawnIntro = 8;

		// Token: 0x04000210 RID: 528
		public const int AnimationHighlightsIntro = 9;

		// Token: 0x04000211 RID: 529
		public const int AnimationHighlightsEnd = 10;

		// Token: 0x04000212 RID: 530
		public const int AnimationHighlightsLava = 11;

		// Token: 0x04000213 RID: 531
		public const int AnimationBrokenPartsLavaA = 12;

		// Token: 0x04000214 RID: 532
		public const int AnimationBrokenPartsLavaB = 13;

		// Token: 0x04000215 RID: 533
		public const int AnimationBrokenPartsLavaC = 14;

		// Token: 0x04000216 RID: 534
		public const int AnimationBrokenPartsLavaD = 15;

		// Token: 0x04000217 RID: 535
		public const int AnimationBrokenPartsLavaE = 16;

		// Token: 0x04000218 RID: 536
		public const int AnimationFireballTransition = 17;

		// Token: 0x04000219 RID: 537
		public const int AnimationFireballIntro = 18;

		// Token: 0x0400021A RID: 538
		public const int AnimationFireballEnd = 19;

		// Token: 0x0400021B RID: 539
		private const int AnimationRobotnikNormal = 0;

		// Token: 0x0400021C RID: 540
		private const int AnimationRobotnikSmiling = 1;

		// Token: 0x0400021D RID: 541
		private const int AnimationRobotnikDefeated = 2;

		// Token: 0x0400021E RID: 542
		private const int AnimationDustSmoke = 1;

		// Token: 0x0400021F RID: 543
		private const double AltitudeSpeed = 3.5;

		// Token: 0x04000220 RID: 544
		private const int AltitudeSpeedDefeated = 8;

		// Token: 0x04000221 RID: 545
		private AnimationInstance _animationInside;

		// Token: 0x04000222 RID: 546
		private AnimationInstance _animationRobotnik;

		// Token: 0x04000223 RID: 547
		private AnimationInstance _animationBody;

		// Token: 0x04000224 RID: 548
		private AnimationInstance _animationLights;

		// Token: 0x04000225 RID: 549
		private AnimationInstance _animationHighlightsSpawnIntro;

		// Token: 0x04000226 RID: 550
		private AnimationInstance _animationHighlightsIntro;

		// Token: 0x04000227 RID: 551
		private AnimationInstance _animationHighlightsEnd;

		// Token: 0x04000228 RID: 552
		private AnimationInstance _animationHighlightsLava;

		// Token: 0x04000229 RID: 553
		private Dictionary<int, Vector2i> _brokenPartsPositions = new Dictionary<int, Vector2i>();

		// Token: 0x0400022A RID: 554
		private Dictionary<int, int> _brokenPartsIndexOrder = new Dictionary<int, int>();

		// Token: 0x0400022B RID: 555
		private AnimationInstance _brokenPartsA;

		// Token: 0x0400022C RID: 556
		private AnimationInstance _brokenPartsB;

		// Token: 0x0400022D RID: 557
		private AnimationInstance _brokenPartsC;

		// Token: 0x0400022E RID: 558
		private AnimationInstance _brokenPartsD;

		// Token: 0x0400022F RID: 559
		private AnimationInstance _brokenPartsE;

		// Token: 0x04000230 RID: 560
		private int _leftX = -1024;

		// Token: 0x04000231 RID: 561
		private int _rightX;

		// Token: 0x04000232 RID: 562
		private int _leftPeekY = -416;

		// Token: 0x04000233 RID: 563
		private int _leftFireballY = -288;

		// Token: 0x04000234 RID: 564
		private int _leftSpawnY = 128;

		// Token: 0x04000235 RID: 565
		private int _rightPeekY = -528;

		// Token: 0x04000236 RID: 566
		private int _rightFireballY = -224;

		// Token: 0x04000237 RID: 567
		private int _rightSpawnY;

		// Token: 0x04000238 RID: 568
		private Vector2i _startPosition;

		// Token: 0x04000239 RID: 569
		private Vector2 _nonHoverPosition;

		// Token: 0x0400023A RID: 570
		private SubmarineEggmanInstance.State _state;

		// Token: 0x0400023B RID: 571
		private Vector2 _velocity;

		// Token: 0x0400023C RID: 572
		private bool _flipX;

		// Token: 0x0400023D RID: 573
		private bool _isRightPit;

		// Token: 0x0400023E RID: 574
		private int _stateTimer;

		// Token: 0x0400023F RID: 575
		private int _brokenPartsCounter;

		// Token: 0x04000240 RID: 576
		private double _floatOffsetAngle;

		// Token: 0x04000241 RID: 577
		private bool _firedFireball;

		// Token: 0x04000242 RID: 578
		private AnimationGroup _animationGroup;

		// Token: 0x04000243 RID: 579
		private AnimationInstance _currentHighlight;

		// Token: 0x020000DA RID: 218
		private enum State
		{
			// Token: 0x040005E1 RID: 1505
			Raise,
			// Token: 0x040005E2 RID: 1506
			PrepareFlameThrower,
			// Token: 0x040005E3 RID: 1507
			Hover,
			// Token: 0x040005E4 RID: 1508
			Lower,
			// Token: 0x040005E5 RID: 1509
			Defeated
		}

		// Token: 0x020000DB RID: 219
		private class FlameThrower : ParticleObject
		{
			// Token: 0x0600055D RID: 1373 RVA: 0x000211AD File Offset: 0x0001F3AD
			public FlameThrower() : base("/ANIGROUP", 5, 1)
			{
				base.FilterMultiplier = 0.0;
			}

			// Token: 0x0600055E RID: 1374 RVA: 0x00009007 File Offset: 0x00007207
			protected override void OnCollision(CollisionEvent e)
			{
				if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
				{
					return;
				}
				((ICharacter)e.ActiveObject).Hurt(-1, PlayerDeathCause.Hurt);
			}

			// Token: 0x0600055F RID: 1375 RVA: 0x000211CB File Offset: 0x0001F3CB
			protected override void OnAnimate()
			{
				base.OnAnimate();
			}

			// Token: 0x06000560 RID: 1376 RVA: 0x000211D4 File Offset: 0x0001F3D4
			protected override void OnUpdate()
			{
				base.OnUpdate();
				if (this._animationInstance.CurrentFrameIndex == 35)
				{
					if (base.CollisionRectangles == null || base.CollisionRectangles.Length == 0)
					{
						int x = (int)((double)(base.FlipX ? (-(double)this._animationInstance.CurrentFrame.Offset.X) : this._animationInstance.CurrentFrame.Offset.X) - (double)this._animationInstance.CurrentFrame.Source.Width / 2.0);
						int y = (int)((double)this._animationInstance.CurrentFrame.Offset.Y - (double)this._animationInstance.CurrentFrame.Source.Height / 4.0);
						int width = this._animationInstance.CurrentFrame.Source.Width;
						int height = this._animationInstance.CurrentFrame.Source.Height / 2;
						base.CollisionRectangles = new CollisionRectangle[]
						{
							new CollisionRectangle(this, 0, x, y, width, height)
						};
						return;
					}
				}
				else if (this._animationInstance.CurrentFrameIndex == 50 && (base.CollisionRectangles != null || base.CollisionRectangles.Length != 0))
				{
					base.CollisionRectangles = new CollisionRectangle[0];
				}
			}

			// Token: 0x06000561 RID: 1377 RVA: 0x0002134C File Offset: 0x0001F54C
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				if (this._animationInstance.CurrentFrameIndex >= 35)
				{
					if (!base.CanDraw())
					{
						return;
					}
					Vector2 destination = new Vector2(12.0, 9.0);
					IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
					using (objectRenderer.BeginMatixState())
					{
						if (base.FlipX)
						{
							objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
						}
						if (base.FlipY)
						{
							objectRenderer.ModelMatrix *= Matrix4.CreateScale(1.0, -1.0, 1.0);
						}
						if (base.FilterMultiplier == 0.0)
						{
							objectRenderer.Filter = 0;
						}
						else
						{
							objectRenderer.FilterAmount *= base.FilterMultiplier;
						}
						objectRenderer.BlendMode = (base.AdditiveBlending ? BlendMode.Additive : BlendMode.Alpha);
						objectRenderer.Render(this._animationInstance, destination, false, false);
						return;
					}
				}
				base.OnDraw(renderer, viewOptions);
			}
		}

		// Token: 0x020000DC RID: 220
		private class FlameThrowerShot : Enemy
		{
			// Token: 0x170000D6 RID: 214
			// (get) Token: 0x06000562 RID: 1378 RVA: 0x00021480 File Offset: 0x0001F680
			// (set) Token: 0x06000563 RID: 1379 RVA: 0x00021488 File Offset: 0x0001F688
			public bool FlipX { get; set; }

			// Token: 0x170000D7 RID: 215
			// (get) Token: 0x06000564 RID: 1380 RVA: 0x00021491 File Offset: 0x0001F691
			// (set) Token: 0x06000565 RID: 1381 RVA: 0x00021499 File Offset: 0x0001F699
			public Vector2i Velocity { get; set; }

			// Token: 0x06000566 RID: 1382 RVA: 0x000214A4 File Offset: 0x0001F6A4
			protected override void OnStart()
			{
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 6);
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -16, -16, 32, 32)
				};
			}

			// Token: 0x06000567 RID: 1383 RVA: 0x000214F1 File Offset: 0x0001F6F1
			protected override void OnUpdate()
			{
				base.Position += this.Velocity;
			}

			// Token: 0x06000568 RID: 1384 RVA: 0x0002150A File Offset: 0x0001F70A
			protected override void OnAnimate()
			{
				this._animation.Animate();
			}

			// Token: 0x06000569 RID: 1385 RVA: 0x00021517 File Offset: 0x0001F717
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				objectRenderer.EmitsLight = true;
				objectRenderer.Render(this._animation, this.FlipX, false);
			}

			// Token: 0x040005E6 RID: 1510
			private AnimationInstance _animation;
		}

		// Token: 0x020000DD RID: 221
		private class Fireball : Enemy
		{
			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x0600056B RID: 1387 RVA: 0x00021538 File Offset: 0x0001F738
			// (set) Token: 0x0600056C RID: 1388 RVA: 0x00021540 File Offset: 0x0001F740
			public Vector2 Velocity { get; set; }

			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x0600056D RID: 1389 RVA: 0x00021549 File Offset: 0x0001F749
			// (set) Token: 0x0600056E RID: 1390 RVA: 0x00021551 File Offset: 0x0001F751
			public bool IsMainFireball { get; set; }

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x0600056F RID: 1391 RVA: 0x0002155A File Offset: 0x0001F75A
			// (set) Token: 0x06000570 RID: 1392 RVA: 0x00021562 File Offset: 0x0001F762
			public SubmarineEggmanInstance.Fireball.FireSpawn SpawnDirection
			{
				get
				{
					return this._spawnDirection;
				}
				set
				{
					this._spawnDirection = value;
				}
			}

			// Token: 0x06000571 RID: 1393 RVA: 0x0002156C File Offset: 0x0001F76C
			protected override void OnStart()
			{
				this._fireball = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 7);
				this._fireballTransition = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 17);
				this._currentAnimation = this._fireball;
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -32, -32, 64, 64)
				};
			}

			// Token: 0x06000572 RID: 1394 RVA: 0x000215E8 File Offset: 0x0001F7E8
			protected override void OnUpdate()
			{
				base.PositionPrecise += this.Velocity;
				this.Velocity += new Vector2(0.0, 0.875);
				if (!this.IsTouchingGround())
				{
					return;
				}
				this.Velocity = new Vector2(0.0, 0.0);
				if (this._currentAnimation != this._fireballTransition)
				{
					this._currentAnimation = this._fireballTransition;
				}
				if (this.IsMainFireball)
				{
					this._ticks++;
					if (this._ticks == 15)
					{
						this.CreateFire();
						return;
					}
					if (this._ticks == 20)
					{
						this.CreateFire();
						return;
					}
					if (this._ticks == 25)
					{
						this.CreateFire();
						return;
					}
					if (this._ticks == 29)
					{
						this.CreateFire();
					}
				}
			}

			// Token: 0x06000573 RID: 1395 RVA: 0x000216D0 File Offset: 0x0001F8D0
			private void CreateFire()
			{
				SubmarineEggmanInstance.Fire fire = base.Level.ObjectManager.AddSubObject<SubmarineEggmanInstance.Fire>(base.ParentObject);
				fire.Position = base.Position + new Vector2i(this._fireInstances * fire.DesignBounds.Width * (int)this.SpawnDirection, 0);
				fire.BubbleLeftCount = 4;
				fire.BubbleRightCount = 4;
				fire.Priority = 1024;
				fire.Layer = base.Level.Map.Layers[base.Level.Map.Layers.Count - 1];
				base.Level.SoundManager.PlaySound(base.Position, base.Type.GetAbsolutePath("SONICORCA/SOUND/FIREBURN"));
				this._fireInstances++;
			}

			// Token: 0x06000574 RID: 1396 RVA: 0x000217A8 File Offset: 0x0001F9A8
			private bool IsTouchingGround()
			{
				bool result = false;
				foreach (CollisionInfo collisionInfo in CollisionVector.GetCollisions(this, 32, uint.MaxValue))
				{
					if (collisionInfo.Vector.Owner == null && !collisionInfo.Vector.IsWall)
					{
						base.PositionPrecise = new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y + collisionInfo.Shift);
						result = true;
					}
				}
				return result;
			}

			// Token: 0x06000575 RID: 1397 RVA: 0x00021840 File Offset: 0x0001FA40
			protected override void OnAnimate()
			{
				if (this._currentAnimation != null)
				{
					this._currentAnimation.Animate();
				}
				if (this._currentAnimation == this._fireballTransition && this._currentAnimation.Cycles > 0)
				{
					this._currentAnimation = null;
					base.Finish();
				}
			}

			// Token: 0x06000576 RID: 1398 RVA: 0x00021880 File Offset: 0x0001FA80
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				objectRenderer.EmitsLight = true;
				if (this._currentAnimation != null)
				{
					if (this._currentAnimation == this._fireballTransition)
					{
						bool flag = this.SpawnDirection == SubmarineEggmanInstance.Fireball.FireSpawn.Right;
						objectRenderer.Render(this._currentAnimation, new Vector2((double)(flag ? 80 : -80), -8.0), flag, false);
						return;
					}
					double angle = this.Velocity.Angle + 3.7699111843077517;
					using (objectRenderer.BeginMatixState())
					{
						objectRenderer.ModelMatrix *= Matrix4.CreateRotationZ(angle);
						objectRenderer.Render(this._currentAnimation, false, false);
					}
				}
			}

			// Token: 0x040005E9 RID: 1513
			private const double Gravity = 0.875;

			// Token: 0x040005EA RID: 1514
			private AnimationInstance _currentAnimation;

			// Token: 0x040005EB RID: 1515
			private AnimationInstance _fireball;

			// Token: 0x040005EC RID: 1516
			private AnimationInstance _fireballTransition;

			// Token: 0x040005ED RID: 1517
			private int _ticks = 10;

			// Token: 0x040005EE RID: 1518
			private int _fireInstances;

			// Token: 0x040005EF RID: 1519
			private SubmarineEggmanInstance.Fireball.FireSpawn _spawnDirection = SubmarineEggmanInstance.Fireball.FireSpawn.Left;

			// Token: 0x02000133 RID: 307
			public enum FireSpawn
			{
				// Token: 0x04000758 RID: 1880
				Left = -1,
				// Token: 0x04000759 RID: 1881
				Right = 1
			}
		}

		// Token: 0x020000DE RID: 222
		private class Fire : Enemy
		{
			// Token: 0x170000DB RID: 219
			// (get) Token: 0x06000578 RID: 1400 RVA: 0x00021963 File Offset: 0x0001FB63
			// (set) Token: 0x06000579 RID: 1401 RVA: 0x0002196B File Offset: 0x0001FB6B
			public int BubbleLeftCount { get; set; }

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x0600057A RID: 1402 RVA: 0x00021974 File Offset: 0x0001FB74
			// (set) Token: 0x0600057B RID: 1403 RVA: 0x0002197C File Offset: 0x0001FB7C
			public int BubbleRightCount { get; set; }

			// Token: 0x0600057C RID: 1404 RVA: 0x00021988 File Offset: 0x0001FB88
			protected override void OnStart()
			{
				this._fireballIntro = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 18);
				this._fireballEnd = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 19);
				this._currentAnimation = this._fireballIntro;
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -32, -32, 64, 64)
				};
				this._timer = 74;
			}

			// Token: 0x0600057D RID: 1405 RVA: 0x00021A10 File Offset: 0x0001FC10
			protected override void OnUpdate()
			{
				this._timer--;
				if (this._timer == 66)
				{
					if (this.BubbleLeftCount > 0)
					{
						Vector2i bubblePosition = base.Position + new Vector2i(-64, 0);
						int num = this.BubbleLeftCount;
						this.BubbleLeftCount = num - 1;
						this.BubbleFire(bubblePosition, num, 0);
					}
					if (this.BubbleRightCount > 0)
					{
						Vector2i bubblePosition2 = base.Position + new Vector2i(64, 0);
						int leftCount = 0;
						int num = this.BubbleRightCount;
						this.BubbleRightCount = num - 1;
						this.BubbleFire(bubblePosition2, leftCount, num);
						return;
					}
				}
				else if (this._timer == 0)
				{
					this._currentAnimation = this._fireballEnd;
				}
			}

			// Token: 0x0600057E RID: 1406 RVA: 0x00021AB2 File Offset: 0x0001FCB2
			private void BubbleFire(Vector2i bubblePosition, int leftCount, int rightCount)
			{
				if (this.IsGroundBelow(ref bubblePosition))
				{
					SubmarineEggmanInstance.Fire fire = base.Level.ObjectManager.AddSubObject<SubmarineEggmanInstance.Fire>(base.ParentObject);
					fire.Position = bubblePosition;
					fire.BubbleLeftCount = leftCount;
					fire.BubbleRightCount = rightCount;
				}
			}

			// Token: 0x0600057F RID: 1407 RVA: 0x00021AE8 File Offset: 0x0001FCE8
			private bool IsGroundBelow(ref Vector2i postion)
			{
				bool result = false;
				foreach (CollisionInfo collisionInfo in CollisionVector.GetCollisions(this, 32, uint.MaxValue))
				{
					if (collisionInfo.Vector.Owner == null && !collisionInfo.Vector.IsWall)
					{
						postion.Y += (int)collisionInfo.Shift;
						result = true;
					}
				}
				return result;
			}

			// Token: 0x06000580 RID: 1408 RVA: 0x00021B64 File Offset: 0x0001FD64
			protected override void OnAnimate()
			{
				if (this._currentAnimation != null)
				{
					this._currentAnimation.Animate();
				}
				if (this._currentAnimation == this._fireballEnd && this._currentAnimation.Cycles > 0)
				{
					this._currentAnimation = null;
					base.Finish();
				}
			}

			// Token: 0x06000581 RID: 1409 RVA: 0x00021BA4 File Offset: 0x0001FDA4
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				objectRenderer.EmitsLight = true;
				if (this._currentAnimation != null)
				{
					objectRenderer.Render(this._currentAnimation, false, false);
				}
			}

			// Token: 0x040005F2 RID: 1522
			private AnimationInstance _currentAnimation;

			// Token: 0x040005F3 RID: 1523
			private AnimationInstance _fireballIntro;

			// Token: 0x040005F4 RID: 1524
			private AnimationInstance _fireballEnd;

			// Token: 0x040005F5 RID: 1525
			private int _timer;
		}
	}
}
