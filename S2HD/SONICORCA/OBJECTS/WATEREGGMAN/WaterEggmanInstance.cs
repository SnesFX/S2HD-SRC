using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
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

namespace SONICORCA.OBJECTS.WATEREGGMAN
{
	// Token: 0x0200008B RID: 139
	public class WaterEggmanInstance : BossObject
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x00014464 File Offset: 0x00012664
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x0001446C File Offset: 0x0001266C
		public WaterEggmanInstance.State ActionState
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00014478 File Offset: 0x00012678
		[HideInEditor]
		public Vector2i JarOffset
		{
			get
			{
				Vector2i result = new Vector2i(this._flipX ? 33 : -33, -186);
				result.X += (this._flipX ? this._armExtension : (-this._armExtension));
				return result;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x000144C5 File Offset: 0x000126C5
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x000144CD File Offset: 0x000126CD
		[StateVariable]
		public int LeftFillX { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x000144D6 File Offset: 0x000126D6
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x000144DE File Offset: 0x000126DE
		[StateVariable]
		public int RightFillX { get; set; }

		// Token: 0x060002C9 RID: 713 RVA: 0x000144E8 File Offset: 0x000126E8
		protected override void OnStart()
		{
			ResourceTree resourceTree = base.Level.GameContext.ResourceTree;
			AnimationGroup animationGroup = this._animationGroup = resourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
			AnimationGroup loadedResource = resourceTree.GetLoadedResource<AnimationGroup>(base.Type, "SONICORCA/OBJECTS/ROBOTNIK/ANIGROUP");
			this._animationEggMobileChasis = new AnimationInstance(animationGroup, 23);
			this._animationEggMobileScreen = new AnimationInstance(animationGroup, 24);
			this._animationEggMobileCap = new AnimationInstance(animationGroup, 25);
			this._animationRobotnik = new AnimationInstance(loadedResource, 0);
			this._animationArmTurn = new AnimationInstance(animationGroup, 30);
			this._animationRobotnikFaceSplash = new AnimationInstance(animationGroup, 55);
			this._animationBase = new AnimationInstance(animationGroup, 0);
			this._animationBaseShadow = new AnimationInstance(animationGroup, 8);
			this._animationBaseLightOn = new AnimationInstance(animationGroup, 1);
			this._animationBaseLightOff = new AnimationInstance(animationGroup, 2);
			this._animationArm = new AnimationInstance(animationGroup, 5);
			this._animationArmTap = new AnimationInstance(animationGroup, 9);
			this._animationArmTapCog = new AnimationInstance(animationGroup, 3);
			this._animationArmJar = new AnimationInstance(animationGroup, 12);
			this._animationArmJarReflection = new AnimationInstance(animationGroup, 13);
			this._animationArmJarLidClosed = new AnimationInstance(animationGroup, 19);
			this._animationArmJarLidBack = new AnimationInstance(animationGroup, 20);
			this._animationArmJarLidFront = new AnimationInstance(animationGroup, 21);
			this._animationDrip = new AnimationInstance(animationGroup, 11);
			this._animationArmJarFill = new AnimationInstance(animationGroup, 14);
			this._animationArmJarFillPlaceholderPrimary = new AnimationInstance(animationGroup, 58);
			this._animationArmJarFillPlaceholderSecondary = new AnimationInstance(animationGroup, 59);
			this._animationArmJarFilled = new AnimationInstance(animationGroup, 17);
			base.ExplosionResourceKey = base.Type.GetAbsolutePath("SONICORCA/OBJECTS/EXPLOSION/BOSS");
			base.HitSoundResourceKey = base.Type.GetAbsolutePath("SONICORCA/SOUND/BOSSHIT");
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -100, -100, 200, 200)
			};
			base.LockLifetime = true;
			this._state = WaterEggmanInstance.State.MoveToSide;
			base.Health = 8;
			this._nonHoverPosition = base.Position;
			this._fillSide = 1;
			this._boiler = base.Level.ObjectManager.AddSubObject<WaterEggmanInstance.Boiler>(this);
			this._jarBack = base.Level.ObjectManager.AddSubObject<WaterEggmanInstance.JarBack>(this);
			this._armFront = base.Level.ObjectManager.AddSubObject<WaterEggmanInstance.ArmFront>(this);
			this._suctionTube = base.Level.ObjectManager.AddSubObject<WaterEggmanInstance.SuctionTube>(this);
			this._jarEmpty = true;
			this._isFaceSplash = false;
			this._updater = new Updater(this.GetUpdates());
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00014766 File Offset: 0x00012966
		protected override void OnUpdate()
		{
			base.OnUpdate();
			this._updater.Update();
			if (this._state != WaterEggmanInstance.State.Defeated && this._state != WaterEggmanInstance.State.Recover)
			{
				this.Hover();
			}
			if (this._mobileExploding)
			{
				base.UpdateExplosions(64);
			}
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000147A2 File Offset: 0x000129A2
		private IEnumerable<UpdateResult> GetUpdates()
		{
			while (this._state < WaterEggmanInstance.State.Defeated)
			{
				switch (this._state)
				{
				case WaterEggmanInstance.State.MoveToSide:
				{
					int num = (this._fillSide == -1) ? this.LeftFillX : this.RightFillX;
					this._nonHoverPosition.X = MathX.GoTowards(this._nonHoverPosition.X, (double)num, 12.0);
					this._armExtension = Math.Max(0, this._armExtension - 8);
					int num2 = (this.LeftFillX + this.RightFillX) / 2;
					bool flag = this._nonHoverPosition.X < (double)num2;
					if (this._armExtension == 0)
					{
						if (this._flipX != flag)
						{
							if (this._animationEggMobileChasis.Index != 26)
							{
								this._animationEggMobileChasis.Index = 26;
								this._animationEggMobileChasis.Cycles = 0;
								this._animationEggMobileScreen.Index = 28;
								this._animationRobotnik.Index = 4;
								this._animationArmTurn.Index = 30;
								this._animationArmTurn.ResetFrame();
								this._animationEggMobileCap.Index = 56;
								this._turning = true;
							}
							else if (this._animationEggMobileChasis.Cycles >= 1)
							{
								this._animationEggMobileChasis.Index = 27;
								this._animationEggMobileScreen.Index = 29;
								this._animationRobotnik.Index = 5;
								this._animationArmTurn.Index = 31;
								this._animationArmTurn.ResetFrame();
								this._animationEggMobileCap.Index = 57;
								this._flipX = flag;
							}
						}
						else if (this._animationEggMobileChasis.Cycles >= 2)
						{
							this._turning = false;
						}
					}
					if (this._nonHoverPosition.X == (double)num && this._armExtension == 0 && this._flipX == flag && !this._turning)
					{
						this._state = WaterEggmanInstance.State.LoweringTube;
					}
					break;
				}
				case WaterEggmanInstance.State.LoweringTube:
					if (this._tubeY < 396)
					{
						this._tubeY += 33;
						this._armExtension = Math.Max(0, this._armExtension - 8);
					}
					else
					{
						this._tubeY = 396;
						this._armExtension = 0;
						this._stateTicks = 0;
						this._state = WaterEggmanInstance.State.FillingJar;
					}
					break;
				case WaterEggmanInstance.State.FillingJar:
					if (this._stateTicks < 236)
					{
						this._stateTicks++;
						if (this._stateTicks > 100)
						{
							this._willJarSplashRobotnik = true;
						}
						if (this._stateTicks > 176)
						{
							this._jarFull = true;
						}
					}
					else
					{
						this._state = WaterEggmanInstance.State.RaisingTube;
					}
					break;
				case WaterEggmanInstance.State.RaisingTube:
					if (this._tubeY > 0)
					{
						this._tubeY -= 33;
					}
					else
					{
						this._tubeY = 0;
						this._state = WaterEggmanInstance.State.Aiming;
					}
					break;
				case WaterEggmanInstance.State.Aiming:
				{
					this._armExtension = Math.Min(256, this._armExtension + 8);
					if (this._armExtension >= 24)
					{
						this._willJarSplashRobotnik = false;
					}
					ICharacter protagonist = base.Level.Player.Protagonist;
					int num3;
					if (this._fillSide == -1)
					{
						num3 = protagonist.Position.X - 256 - 48;
					}
					else
					{
						num3 = protagonist.Position.X + 256 + 48;
					}
					this._nonHoverPosition.X = MathX.GoTowards(this._nonHoverPosition.X, (double)num3, 12.0);
					if (this._armExtension == 256 && this._nonHoverPosition.X == (double)num3)
					{
						this._stateTicks = 0;
						this._state = WaterEggmanInstance.State.DroppingChemical;
					}
					break;
				}
				case WaterEggmanInstance.State.DroppingChemical:
					if (this._stateTicks == 2)
					{
						Vector2i b = new Vector2i(this._flipX ? 33 : -33, -186);
						b.X += (this._flipX ? this._armExtension : (-this._armExtension));
						b.X += (this._flipX ? 8 : -8);
						b.Y -= 16;
						WaterEggmanInstance.ChemicalDroplet chemicalDroplet = base.Level.ObjectManager.AddSubObject<WaterEggmanInstance.ChemicalDroplet>(this);
						chemicalDroplet.FlipX = this._flipX;
						chemicalDroplet.Position = base.Position + b;
						this._jarEmpty = true;
						this._jarFull = false;
					}
					if (this._stateTicks < 30)
					{
						this._stateTicks++;
					}
					else
					{
						this._fillSide = ((this._fillSide == -1) ? 1 : -1);
						this._state = WaterEggmanInstance.State.MoveToSide;
					}
					break;
				}
				yield return UpdateResult.Next();
			}
			this._animationEggMobileChasis.Index = 47;
			this._animationEggMobileScreen.Index = 49;
			this._isFaceSplash = this._willJarSplashRobotnik;
			this._velocityY = 0.0;
			this._mobileExploding = true;
			yield return UpdateResult.Wait(10);
			while (this._suctionTube.Explode())
			{
				yield return UpdateResult.Next();
			}
			yield return UpdateResult.Wait(10);
			while (this._boiler.Explode())
			{
				yield return UpdateResult.Next();
			}
			yield return UpdateResult.Wait(10);
			while (this._armFront.ExplodeJar())
			{
				yield return UpdateResult.Next();
			}
			yield return UpdateResult.Wait(10);
			this._suctionTube.Fall();
			yield return UpdateResult.Wait(10);
			while (this._armFront.ExplodeBar())
			{
				yield return UpdateResult.Next();
			}
			yield return UpdateResult.Wait(4);
			this._boiler.Fall();
			yield return UpdateResult.Wait(40);
			this._mobileExploding = false;
			do
			{
				this._velocityY += 0.375;
				this._nonHoverPosition += new Vector2(0.0, this._velocityY);
				base.PositionPrecise = this._nonHoverPosition;
				yield return UpdateResult.Next();
			}
			while (this._velocityY < 15.0);
			this._isFaceSplash = false;
			this.DoRobotnikNormal();
			this._state = WaterEggmanInstance.State.Recover;
			int num4;
			for (int i = 0; i < 60; i = num4 + 1)
			{
				this._nonHoverPosition += new Vector2(0.0, -6.0);
				base.PositionPrecise = this._nonHoverPosition;
				yield return UpdateResult.Next();
				num4 = i;
			}
			base.Defeated = true;
			this._state = WaterEggmanInstance.State.Fleeing;
			base.Fleeing = true;
			base.PositionPrecise = this._nonHoverPosition;
			int hover_failure_ticks = 0;
			for (;;)
			{
				this._nonHoverPosition += new Vector2(12.0, 0.0);
				if (!this._turning)
				{
					if (hover_failure_ticks == 7)
					{
						this.EmitSmoke(new Vector2(85.0, -160.0), new Vector2(-7.0, -5.0));
					}
					else if (hover_failure_ticks == 21)
					{
						this.EmitSmoke(new Vector2(85.0, -160.0), new Vector2(-7.0, -5.0));
						this.EmitSmoke(new Vector2(-120.0, -180.0), new Vector2(-3.0, -5.0));
					}
					else if (hover_failure_ticks == 11)
					{
						this.EmitSmoke(new Vector2(50.0, -70.0), new Vector2(-3.0, -5.0));
					}
					else if (hover_failure_ticks == 22)
					{
						this.EmitSmoke(new Vector2(50.0, -70.0), new Vector2(-3.0, -5.0));
					}
					else if (hover_failure_ticks == 35)
					{
						this.EmitSmoke(new Vector2(-80.0, -90.0), new Vector2(-3.0, -5.0));
					}
					else if (hover_failure_ticks == 45)
					{
						this.EmitSmoke(new Vector2(0.0, -90.0), new Vector2(-3.0, -7.0));
					}
				}
				if (!this._flipX)
				{
					if (this._animationEggMobileChasis.Index != 51)
					{
						this._animationEggMobileChasis.Index = 51;
						this._animationEggMobileChasis.Cycles = 0;
						this._animationEggMobileScreen.Index = 53;
						this._animationEggMobileCap.Index = 56;
						this._turning = false;
					}
					else if (this._animationEggMobileChasis.Cycles >= 1)
					{
						this._animationEggMobileChasis.Index = 52;
						this._animationEggMobileScreen.Index = 54;
						this._animationEggMobileCap.Index = 57;
						this._flipX = true;
					}
				}
				else if (this._animationEggMobileChasis.Cycles >= 2 && this._turning)
				{
					this._turning = false;
					this._animationEggMobileScreen.Index = 49;
				}
				if (!this._turning && hover_failure_ticks < 15 && this._flipX)
				{
					if (hover_failure_ticks % 5 == 0)
					{
						this._animationEggMobileChasis.Index = 48;
					}
					else
					{
						this._animationEggMobileChasis.Index = 47;
					}
					num4 = hover_failure_ticks;
					hover_failure_ticks = num4 + 1;
					this._nonHoverPosition += new Vector2(0.0, 2.0);
				}
				else if (!this._turning && hover_failure_ticks >= 15 && hover_failure_ticks < 45 && this._flipX)
				{
					if (this._animationEggMobileChasis.Index != 48)
					{
						this._animationEggMobileChasis.Index = 48;
					}
					if (hover_failure_ticks < 30)
					{
						this._nonHoverPosition += new Vector2(0.0, -2.0);
					}
					num4 = hover_failure_ticks;
					hover_failure_ticks = num4 + 1;
				}
				else
				{
					hover_failure_ticks = 0;
				}
				if (this._stateTicks > 600)
				{
					base.LockLifetime = false;
				}
				yield return UpdateResult.Next();
			}
			yield break;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000147B4 File Offset: 0x000129B4
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

		// Token: 0x060002CD RID: 717 RVA: 0x00014898 File Offset: 0x00012A98
		private void Hover()
		{
			double y = Math.Sin(this._floatOffsetAngle) / 3.141592653589793 * 16.0;
			base.PositionPrecise = this._nonHoverPosition + new Vector2(0.0, y);
			this._floatOffsetAngle += 0.04908738521234052;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x000148FB File Offset: 0x00012AFB
		protected override void Hit(ICharacter character)
		{
			base.Hit(character);
			if (base.Health > 0)
			{
				this.DoRobotnikFrown();
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00014914 File Offset: 0x00012B14
		protected override void Defeat()
		{
			this._state = WaterEggmanInstance.State.Defeated;
			this._stateTicks = 0;
			this._nonHoverPosition = base.PositionPrecise;
			this.DoRobotnikDefeated();
			base.CollisionRectangles = new CollisionRectangle[0];
			base.Level.Player.GainScore(1000);
			base.Level.CreateScoreObject(1000, base.Position + new Vector2i(0, -128));
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00014985 File Offset: 0x00012B85
		protected override void OnHurtCharacter(ICharacter character)
		{
			this.DoRobotnikSmile();
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0001498D File Offset: 0x00012B8D
		public void DoRobotnikSmile()
		{
			if (this._animationRobotnik.Index == 0)
			{
				this._animationRobotnik.Index = 1;
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000149A8 File Offset: 0x00012BA8
		public void DoRobotnikFrown()
		{
			this._animationRobotnik.Index = 2;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000149B6 File Offset: 0x00012BB6
		public void DoRobotnikDefeated()
		{
			this._animationRobotnik.Index = 3;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000149C4 File Offset: 0x00012BC4
		public void DoRobotnikNormal()
		{
			this._animationRobotnik.Index = 0;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000149D4 File Offset: 0x00012BD4
		protected override void OnAnimate()
		{
			switch (this._state)
			{
			case WaterEggmanInstance.State.MoveToSide:
				this._animationArmTapCog.Index = 3;
				this._animationArmTap.Index = 9;
				break;
			case WaterEggmanInstance.State.LoweringTube:
				this._animationArmTapCog.Index = 3;
				this._animationArmTap.Index = 9;
				this._jarFillY = 0;
				this._jarEmpty = true;
				this._dripVisible = false;
				this._suctionTube.TubeSuctionIndex = 22f;
				break;
			case WaterEggmanInstance.State.FillingJar:
				if (this._stateTicks < 140)
				{
					this._animationArmTapCog.Index = 4;
					this._animationArmTap.Index = 10;
					this._suctionTube.TubeSuctionIndex -= 0.5f;
					if (this._suctionTube.TubeSuctionIndex <= 0f)
					{
						this._suctionTube.TubeSuctionIndex = 22f;
					}
				}
				else if (this._suctionTube.TubeSuctionIndex > 0f)
				{
					this._suctionTube.TubeSuctionIndex = Math.Max(0f, this._suctionTube.TubeSuctionIndex - 0.5f);
				}
				if (this._dripVisible)
				{
					this._dripPosition.Y = this._dripPosition.Y + 12;
				}
				if (this._stateTicks == 20)
				{
					this._dripVisible = true;
					this._dripPosition = default(Vector2i);
				}
				else if (this._stateTicks == 24)
				{
					this._dripVisible = false;
					this._animationArmJarFill.Index = 14;
					this._animationArmJarFill.ResetFrame();
					this._jarEmpty = false;
				}
				else if (this._stateTicks == 50)
				{
					this._dripVisible = true;
					this._dripPosition = default(Vector2i);
				}
				else if (this._stateTicks == 54)
				{
					this._dripVisible = false;
					this._animationArmJarFill.Index = 15;
				}
				else if (this._stateTicks == 80)
				{
					this._dripVisible = true;
					this._dripPosition = default(Vector2i);
				}
				else if (this._stateTicks == 84)
				{
					this._dripVisible = false;
					this._animationArmJarFill.Index = 16;
					this._jarFillY -= 20;
				}
				else if (this._stateTicks == 110)
				{
					this._dripVisible = true;
					this._dripPosition = default(Vector2i);
				}
				else if (this._stateTicks == 114)
				{
					this._dripVisible = false;
					this._animationArmJarFill.Index = 16;
					this._animationArmJarFill.ResetFrame();
					this._jarFillY -= 20;
				}
				else if (this._stateTicks == 138)
				{
					this._dripVisible = true;
					this._dripPosition = default(Vector2i);
				}
				else if (this._stateTicks == 139)
				{
					this._dripVisible = false;
				}
				else if (this._stateTicks == 140)
				{
					this._animationArmJarFill.Index = 16;
					this._animationArmJarFill.ResetFrame();
					this._jarFillY -= 20;
				}
				this._animationArmJarFill.Animate();
				this._animationArmJarFilled.Animate();
				break;
			case WaterEggmanInstance.State.DroppingChemical:
				if (this._stateTicks == 0)
				{
					this._jarLidOpen = true;
					this._animationArmJarLidBack.ResetFrame();
					this._animationArmJarLidFront.ResetFrame();
					this._animationArmJarLidBack.Cycles = 0;
					this._animationArmJarLidFront.Cycles = 0;
				}
				break;
			case WaterEggmanInstance.State.Defeated:
				if (this._isFaceSplash)
				{
					this._animationRobotnikFaceSplash.Animate();
				}
				break;
			}
			this._animationEggMobileChasis.Animate();
			this._animationEggMobileScreen.Animate();
			this._animationEggMobileCap.Animate();
			this._animationRobotnik.Animate();
			this._animationArmTurn.Animate();
			this._animationBase.Animate();
			this._animationArm.Animate();
			this._animationArmTap.Animate();
			this._animationArmTapCog.Animate();
			this._animationArmJar.Animate();
			this._animationArmJarReflection.Animate();
			this._animationArmJarLidClosed.Animate();
			this._animationArmJarLidBack.Animate();
			this._animationArmJarLidFront.Animate();
			if (this._animationArmJarLidBack.Cycles > 0)
			{
				this._jarLidOpen = false;
			}
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00014DF8 File Offset: 0x00012FF8
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			this.DrawEggMobile(objectRenderer);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00014E14 File Offset: 0x00013014
		private void DrawEggMobile(IObjectRenderer or)
		{
			using (or.BeginMatixState())
			{
				if (this._flipX)
				{
					or.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
				}
				Vector2i vector2i = new Vector2i(-26);
				Vector2i v = vector2i + new Vector2i(0, 0);
				Vector2i v2 = vector2i + new Vector2i(0, -76);
				Vector2i v3 = vector2i + new Vector2i(25, -223);
				Vector2i v4 = vector2i + new Vector2i(0, 0);
				or.FilterAmount *= 0.5;
				if (base.IsInvincibleFlashing)
				{
					or.AdditiveColour = BossObject.FlashAdditiveColour;
				}
				or.Render(this._animationEggMobileCap, v, false, false);
				or.Render(this._animationEggMobileChasis, vector2i, false, false);
				or.AdditiveColour = Colours.Black;
				if (this._isFaceSplash)
				{
					or.Render(this._animationRobotnikFaceSplash, v3, false, false);
				}
				else
				{
					or.Render(this._animationRobotnik, v2, false, false);
				}
				if (base.IsInvincibleFlashing)
				{
					or.AdditiveColour = BossObject.FlashAdditiveColour;
				}
				or.Render(this._animationEggMobileScreen, v4, false, false);
			}
			using (or.BeginMatixState())
			{
				if (this._flipX)
				{
					or.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
				}
				Vector2i a = new Vector2i(0);
				Vector2i vector2i2 = new Vector2i(60, -171);
				if (this._animationArmTurn.Index == 30)
				{
					if (this._animationArmTurn.CurrentFrameIndex == 0)
					{
						vector2i2.Y = -172;
					}
					else if (this._animationArmTurn.CurrentFrameIndex > 0)
					{
						vector2i2.Y = -195;
					}
				}
				if (this._animationArmTurn.Index == 31)
				{
					if (this._animationArmTurn.CurrentFrameIndex == 3)
					{
						vector2i2.Y = -172;
					}
					else if (this._animationArmTurn.CurrentFrameIndex == 2)
					{
						vector2i2.Y = -172;
					}
					else if (this._animationArmTurn.CurrentFrameIndex < 3)
					{
						vector2i2.Y = -195;
					}
				}
				or.ModelMatrix *= Matrix4.CreateTranslation((double)vector2i2.X, (double)vector2i2.Y, 0.0);
				Vector2i v5 = a + new Vector2i(-64, 0);
				if (this._turning && this._state < WaterEggmanInstance.State.Defeated)
				{
					or.Render(this._animationArmTurn, v5, false, false);
				}
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0001510C File Offset: 0x0001330C
		private void ReleaseFragmentMetal(Vector2i position, double speed, int count = 1, bool explode = true)
		{
			for (int i = 0; i < count; i++)
			{
				double num = base.Level.Random.NextRadians();
				Vector2 velocity = new Vector2(speed * Math.Cos(num), speed * Math.Sin(num));
				this.ReleaseFragmentMetal(position, velocity);
			}
			if (explode)
			{
				base.ExplodeAt(position);
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00015160 File Offset: 0x00013360
		private void ReleaseFragmentMetal(Vector2i position, Vector2 velocity)
		{
			Fragment fragment = base.Level.ObjectManager.AddSubObject<Fragment>(this);
			fragment.AnimationGroup = this._animationGroup;
			fragment.AnimationIndex = base.Level.Random.Next(40, 47);
			fragment.Position = position;
			fragment.Velocity = velocity;
			fragment.AngularVelocity = 0.10471975511965977;
			fragment.FlipX = base.Level.Random.NextBoolean();
			fragment.Initialise();
		}

		// Token: 0x0400033E RID: 830
		public const int AnimationBase = 0;

		// Token: 0x0400033F RID: 831
		public const int AnimationBaseLightOn = 1;

		// Token: 0x04000340 RID: 832
		public const int AnimationBaseLightOff = 2;

		// Token: 0x04000341 RID: 833
		public const int AnimationArmCog = 3;

		// Token: 0x04000342 RID: 834
		public const int AnimationArmCogTurn = 4;

		// Token: 0x04000343 RID: 835
		public const int AnimationArm = 5;

		// Token: 0x04000344 RID: 836
		public const int AnimationTube = 6;

		// Token: 0x04000345 RID: 837
		public const int AnimationTubeSucking = 7;

		// Token: 0x04000346 RID: 838
		public const int AnimationBaseShadow = 8;

		// Token: 0x04000347 RID: 839
		public const int AnimationArmTap = 9;

		// Token: 0x04000348 RID: 840
		public const int AnimationArmTapDrip = 10;

		// Token: 0x04000349 RID: 841
		public const int AnimationDrip = 11;

		// Token: 0x0400034A RID: 842
		public const int AnimationJar = 12;

		// Token: 0x0400034B RID: 843
		public const int AnimationJarReflection = 13;

		// Token: 0x0400034C RID: 844
		public const int AnimationJarFillA = 14;

		// Token: 0x0400034D RID: 845
		public const int AnimationJarFillB = 15;

		// Token: 0x0400034E RID: 846
		public const int AnimationJarFillC = 16;

		// Token: 0x0400034F RID: 847
		public const int AnimationJarFillD = 17;

		// Token: 0x04000350 RID: 848
		public const int AnimationJarDroplet = 18;

		// Token: 0x04000351 RID: 849
		public const int AnimationJarLidClosed = 19;

		// Token: 0x04000352 RID: 850
		public const int AnimationJarLidBack = 20;

		// Token: 0x04000353 RID: 851
		public const int AnimationJarLidFront = 21;

		// Token: 0x04000354 RID: 852
		private const int AnimationEggMobileChasis = 22;

		// Token: 0x04000355 RID: 853
		private const int AnimationEggMobileChasisFlame = 23;

		// Token: 0x04000356 RID: 854
		private const int AnimationEggMobileScreen = 24;

		// Token: 0x04000357 RID: 855
		private const int AnimationEggMobileCap = 25;

		// Token: 0x04000358 RID: 856
		private const int AnimationEggMobileChasisTurn1 = 26;

		// Token: 0x04000359 RID: 857
		private const int AnimationEggMobileChasisTurn2 = 27;

		// Token: 0x0400035A RID: 858
		private const int AnimationEggMobileScreenTurn1 = 28;

		// Token: 0x0400035B RID: 859
		private const int AnimationEggMobileScreenTurn2 = 29;

		// Token: 0x0400035C RID: 860
		private const int AnimationArmTurn1 = 30;

		// Token: 0x0400035D RID: 861
		private const int AnimationArmTurn2 = 31;

		// Token: 0x0400035E RID: 862
		private const int AnimationSplash = 32;

		// Token: 0x0400035F RID: 863
		private const int AnimationSplashDrop = 33;

		// Token: 0x04000360 RID: 864
		private const int AnimationSplashSmallDrop = 34;

		// Token: 0x04000361 RID: 865
		private const int AnimationSmoke = 35;

		// Token: 0x04000362 RID: 866
		private const int AnimationBrokenJar = 36;

		// Token: 0x04000363 RID: 867
		private const int AnimationBrokenBoiler = 37;

		// Token: 0x04000364 RID: 868
		private const int AnimationBrokenTube = 38;

		// Token: 0x04000365 RID: 869
		private const int AnimationBrokenBar = 39;

		// Token: 0x04000366 RID: 870
		private const int AnimationBrokenPieces = 40;

		// Token: 0x04000367 RID: 871
		private const int AnimationBrokenEggMobileChasis = 47;

		// Token: 0x04000368 RID: 872
		private const int AnimationBrokenEggMobileChasisFlame = 48;

		// Token: 0x04000369 RID: 873
		private const int AnimationBrokenEggMobileScreen = 49;

		// Token: 0x0400036A RID: 874
		private const int AnimationBrokenEggMobileCap = 50;

		// Token: 0x0400036B RID: 875
		private const int AnimationBrokenEggMobileChasisTurn1 = 51;

		// Token: 0x0400036C RID: 876
		private const int AnimationBrokenEggMobileChasisTurn2 = 52;

		// Token: 0x0400036D RID: 877
		private const int AnimationBrokenEggMobileScreenTurn1 = 53;

		// Token: 0x0400036E RID: 878
		private const int AnimationBrokenEggMobileScreenTurn2 = 54;

		// Token: 0x0400036F RID: 879
		private const int AnimationRobotnikFaceSplash = 55;

		// Token: 0x04000370 RID: 880
		private const int AnimationBrokenEggMobileCapTurn1 = 56;

		// Token: 0x04000371 RID: 881
		private const int AnimationBrokenEggMobileCapTurn2 = 57;

		// Token: 0x04000372 RID: 882
		private const int AnimationJarFluidBottomPrimary = 58;

		// Token: 0x04000373 RID: 883
		private const int AnimationJarFluidBottomSecondary = 59;

		// Token: 0x04000374 RID: 884
		private const int AnimationRobotnikNormal = 0;

		// Token: 0x04000375 RID: 885
		private const int AnimationRobotnikSmiling = 1;

		// Token: 0x04000376 RID: 886
		private const int AnimationRobotnikFrown = 2;

		// Token: 0x04000377 RID: 887
		private const int AnimationRobotnikDefeated = 3;

		// Token: 0x04000378 RID: 888
		private const int AnimationRobotnikTurn1 = 4;

		// Token: 0x04000379 RID: 889
		private const int AnimationRobotnikTurn2 = 5;

		// Token: 0x0400037A RID: 890
		private const int AnimationDustSmoke = 1;

		// Token: 0x0400037B RID: 891
		private WaterEggmanInstance.State _state;

		// Token: 0x0400037C RID: 892
		private AnimationGroup _animationGroup;

		// Token: 0x0400037D RID: 893
		private AnimationInstance _animationEggMobileChasis;

		// Token: 0x0400037E RID: 894
		private AnimationInstance _animationEggMobileScreen;

		// Token: 0x0400037F RID: 895
		private AnimationInstance _animationEggMobileCap;

		// Token: 0x04000380 RID: 896
		private AnimationInstance _animationRobotnik;

		// Token: 0x04000381 RID: 897
		private AnimationInstance _animationArmTurn;

		// Token: 0x04000382 RID: 898
		private AnimationInstance _animationRobotnikFaceSplash;

		// Token: 0x04000383 RID: 899
		private AnimationInstance _animationBase;

		// Token: 0x04000384 RID: 900
		private AnimationInstance _animationBaseShadow;

		// Token: 0x04000385 RID: 901
		private AnimationInstance _animationBaseLightOn;

		// Token: 0x04000386 RID: 902
		private AnimationInstance _animationBaseLightOff;

		// Token: 0x04000387 RID: 903
		private AnimationInstance _animationArm;

		// Token: 0x04000388 RID: 904
		private AnimationInstance _animationArmTap;

		// Token: 0x04000389 RID: 905
		private AnimationInstance _animationArmTapCog;

		// Token: 0x0400038A RID: 906
		private AnimationInstance _animationArmJar;

		// Token: 0x0400038B RID: 907
		private AnimationInstance _animationArmJarReflection;

		// Token: 0x0400038C RID: 908
		private AnimationInstance _animationArmJarLidClosed;

		// Token: 0x0400038D RID: 909
		private AnimationInstance _animationArmJarLidBack;

		// Token: 0x0400038E RID: 910
		private AnimationInstance _animationArmJarLidFront;

		// Token: 0x0400038F RID: 911
		private AnimationInstance _animationDrip;

		// Token: 0x04000390 RID: 912
		private AnimationInstance _animationArmJarFill;

		// Token: 0x04000391 RID: 913
		private AnimationInstance _animationArmJarFillPlaceholderPrimary;

		// Token: 0x04000392 RID: 914
		private AnimationInstance _animationArmJarFillPlaceholderSecondary;

		// Token: 0x04000393 RID: 915
		private AnimationInstance _animationArmJarFilled;

		// Token: 0x04000394 RID: 916
		private Vector2 _nonHoverPosition;

		// Token: 0x04000395 RID: 917
		private double _floatOffsetAngle;

		// Token: 0x04000396 RID: 918
		private bool _turning;

		// Token: 0x04000397 RID: 919
		private bool _flipX;

		// Token: 0x04000398 RID: 920
		private Updater _updater;

		// Token: 0x04000399 RID: 921
		private int _stateTicks;

		// Token: 0x0400039A RID: 922
		private int _armExtension;

		// Token: 0x0400039B RID: 923
		private int _tubeY;

		// Token: 0x0400039C RID: 924
		private int _fillSide;

		// Token: 0x0400039D RID: 925
		private bool _dripVisible;

		// Token: 0x0400039E RID: 926
		private Vector2i _dripPosition;

		// Token: 0x0400039F RID: 927
		private bool _jarEmpty;

		// Token: 0x040003A0 RID: 928
		private bool _jarFull;

		// Token: 0x040003A1 RID: 929
		private bool _willJarSplashRobotnik;

		// Token: 0x040003A2 RID: 930
		private int _jarFillY;

		// Token: 0x040003A3 RID: 931
		private bool _jarLidOpen;

		// Token: 0x040003A4 RID: 932
		private double _velocityY;

		// Token: 0x040003A5 RID: 933
		private WaterEggmanInstance.Boiler _boiler;

		// Token: 0x040003A6 RID: 934
		private WaterEggmanInstance.JarBack _jarBack;

		// Token: 0x040003A7 RID: 935
		private WaterEggmanInstance.ArmFront _armFront;

		// Token: 0x040003A8 RID: 936
		private WaterEggmanInstance.SuctionTube _suctionTube;

		// Token: 0x040003A9 RID: 937
		private bool _mobileExploding;

		// Token: 0x040003AA RID: 938
		private bool _isFaceSplash;

		// Token: 0x020000F5 RID: 245
		public enum State
		{
			// Token: 0x04000654 RID: 1620
			MoveToSide,
			// Token: 0x04000655 RID: 1621
			LoweringTube,
			// Token: 0x04000656 RID: 1622
			FillingJar,
			// Token: 0x04000657 RID: 1623
			RaisingTube,
			// Token: 0x04000658 RID: 1624
			Aiming,
			// Token: 0x04000659 RID: 1625
			DroppingChemical,
			// Token: 0x0400065A RID: 1626
			Defeated,
			// Token: 0x0400065B RID: 1627
			Recover,
			// Token: 0x0400065C RID: 1628
			Fleeing
		}

		// Token: 0x020000F6 RID: 246
		private enum ExplodeState
		{
			// Token: 0x0400065E RID: 1630
			NotExploding,
			// Token: 0x0400065F RID: 1631
			Exploding,
			// Token: 0x04000660 RID: 1632
			Exploded,
			// Token: 0x04000661 RID: 1633
			Falling
		}

		// Token: 0x020000F7 RID: 247
		private class Boiler : ActiveObject
		{
			// Token: 0x170000F2 RID: 242
			// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00023A64 File Offset: 0x00021C64
			public WaterEggmanInstance Parent
			{
				get
				{
					return base.ParentObject as WaterEggmanInstance;
				}
			}

			// Token: 0x060005F5 RID: 1525 RVA: 0x00023A71 File Offset: 0x00021C71
			protected override void OnStart()
			{
				this._updater = new Updater(this.GetUpdates());
				base.Priority = 300;
				base.LockLifetime = true;
			}

			// Token: 0x060005F6 RID: 1526 RVA: 0x00023A96 File Offset: 0x00021C96
			protected override void OnUpdate()
			{
				this._updater.Update();
			}

			// Token: 0x060005F7 RID: 1527 RVA: 0x00023AA4 File Offset: 0x00021CA4
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				if (this.Parent._turning)
				{
					return;
				}
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				using (objectRenderer.BeginMatixState())
				{
					if (this._flipX)
					{
						objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
					}
					objectRenderer.ModelMatrix *= Matrix4.CreateTranslation((double)WaterEggmanInstance.Boiler.OriginOffset.X, (double)WaterEggmanInstance.Boiler.OriginOffset.Y, 0.0);
					if (this._explodeState == WaterEggmanInstance.ExplodeState.Falling)
					{
						objectRenderer.ModelMatrix = objectRenderer.ModelMatrix.RotateZ(this._angle);
					}
					objectRenderer.Render(this.Parent._animationBaseShadow, new Vector2(3.0, 100.0), false, false);
					if (this.Parent.IsInvincibleFlashing)
					{
						objectRenderer.AdditiveColour = BossObject.FlashAdditiveColour;
					}
					if (this._explodeState < WaterEggmanInstance.ExplodeState.Exploded)
					{
						objectRenderer.Render(this.Parent._animationBase, new Vector2(0.0, 0.0), false, false);
						objectRenderer.Render(this.Parent._animationArmTap, new Vector2(-69.0, -68.0), false, false);
						objectRenderer.Render(this.Parent._animationArmTapCog, new Vector2(8.0, -75.0), false, false);
						if (this.Parent._jarFull)
						{
							objectRenderer.Render(this.Parent._animationBaseLightOn, new Vector2(-42.0, 12.0), false, false);
						}
						else
						{
							objectRenderer.Render(this.Parent._animationBaseLightOff, new Vector2(-42.0, 12.0), false, false);
						}
					}
					else
					{
						objectRenderer.Render(this._explodedAnimationInstance, new Vector2(-24.0, 0.0), false, false);
					}
				}
			}

			// Token: 0x060005F8 RID: 1528 RVA: 0x00023CDC File Offset: 0x00021EDC
			private Vector2i GetAbsolutePosition(Vector2i offset)
			{
				Vector2i b = WaterEggmanInstance.Boiler.OriginOffset + offset;
				if (this._flipX)
				{
					b.X *= -1;
				}
				return base.Position + b;
			}

			// Token: 0x060005F9 RID: 1529 RVA: 0x00023D18 File Offset: 0x00021F18
			private IEnumerable<UpdateResult> GetUpdates()
			{
				while (this._explodeState == WaterEggmanInstance.ExplodeState.NotExploding)
				{
					this._flipX = this.Parent._flipX;
					base.Position = this.Parent.Position;
					if (this.Parent.Finished)
					{
						base.Finish();
					}
					yield return UpdateResult.Next();
				}
				this.Parent.ReleaseFragmentMetal(this.GetAbsolutePosition(new Vector2i(4, 100)), 8.0, 1, true);
				yield return UpdateResult.Wait(2);
				this.Parent.ReleaseFragmentMetal(this.GetAbsolutePosition(new Vector2i(0, 0)), 8.0, 1, true);
				yield return UpdateResult.Wait(2);
				this.Parent.ReleaseFragmentMetal(this.GetAbsolutePosition(new Vector2i(-69, -68)), 8.0, 1, true);
				yield return UpdateResult.Next();
				this._explodeState = WaterEggmanInstance.ExplodeState.Exploded;
				this._explodedAnimationInstance = new AnimationInstance(this.Parent._animationGroup, 37);
				yield return UpdateResult.Wait(60);
				int flipMultiplier = this._flipX ? -1 : 1;
				while (this._explodeState != WaterEggmanInstance.ExplodeState.Falling)
				{
					yield return UpdateResult.Next();
				}
				this.Parent.ReleaseFragmentMetal(this.GetAbsolutePosition(new Vector2i(0, 100)), 8.0, 1, true);
				int num;
				for (int i = 0; i < 12; i = num + 1)
				{
					base.Move(flipMultiplier, 1);
					yield return UpdateResult.Next();
					num = i;
				}
				base.LockLifetime = false;
				bool isUnderwater = false;
				for (;;)
				{
					if (!isUnderwater)
					{
						if (base.Level.WaterManager.IsUnderwater(base.Position))
						{
							isUnderwater = true;
							this._velocity = new Vector2(0.0, 1.0);
							base.Level.WaterManager.CreateSplash(base.Layer, SplashType.Enter, base.Position);
						}
						else
						{
							this._angle += 0.10471975511965977 * (double)flipMultiplier;
							this._velocity += new Vector2(0.0, 0.875);
						}
					}
					else
					{
						this._angle += 0.041887902047863905 * (double)flipMultiplier;
						this._velocity += new Vector2(0.0, 0.4375);
					}
					base.MovePrecise(this._velocity);
					if (base.Level.Ticks % 4 == 0)
					{
						this.EmitSmoke();
					}
					yield return UpdateResult.Next();
				}
				yield break;
			}

			// Token: 0x060005FA RID: 1530 RVA: 0x00023D28 File Offset: 0x00021F28
			private void EmitSmoke()
			{
				Matrix4 matrix = Matrix4.Identity;
				matrix *= Matrix4.CreateTranslation(base.Position);
				if (this._flipX)
				{
					matrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
				}
				matrix = (matrix * Matrix4.CreateTranslation(WaterEggmanInstance.Boiler.OriginOffset)).RotateZ(this._angle);
				Vector2i position = (Vector2i)(matrix * new Vector2(0.0, 100.0));
				(base.Level.ObjectManager.AddObject(new ObjectPlacement("SONICORCA/OBJECTS/DUST", base.Level.Map.Layers.IndexOf(base.Layer), position)) as DustInstance).SetDustAnimationIndex(1);
			}

			// Token: 0x060005FB RID: 1531 RVA: 0x00023E09 File Offset: 0x00022009
			public bool Explode()
			{
				if (this._explodeState == WaterEggmanInstance.ExplodeState.NotExploding)
				{
					this._explodeState = WaterEggmanInstance.ExplodeState.Exploding;
					return true;
				}
				return this._explodeState == WaterEggmanInstance.ExplodeState.Exploding;
			}

			// Token: 0x060005FC RID: 1532 RVA: 0x00023E28 File Offset: 0x00022028
			public void Fall()
			{
				this._explodeState = WaterEggmanInstance.ExplodeState.Falling;
			}

			// Token: 0x04000662 RID: 1634
			private static Vector2i OriginOffset = new Vector2i(60, -176);

			// Token: 0x04000663 RID: 1635
			private Updater _updater;

			// Token: 0x04000664 RID: 1636
			private bool _flipX;

			// Token: 0x04000665 RID: 1637
			private WaterEggmanInstance.ExplodeState _explodeState;

			// Token: 0x04000666 RID: 1638
			private AnimationInstance _explodedAnimationInstance;

			// Token: 0x04000667 RID: 1639
			private Vector2 _velocity;

			// Token: 0x04000668 RID: 1640
			private double _angle;
		}

		// Token: 0x020000F8 RID: 248
		private class JarBack : ActiveObject
		{
			// Token: 0x170000F3 RID: 243
			// (get) Token: 0x060005FF RID: 1535 RVA: 0x00023A64 File Offset: 0x00021C64
			public WaterEggmanInstance Parent
			{
				get
				{
					return base.ParentObject as WaterEggmanInstance;
				}
			}

			// Token: 0x06000600 RID: 1536 RVA: 0x00023E44 File Offset: 0x00022044
			protected override void OnStart()
			{
				base.Priority = 310;
				base.LockLifetime = true;
			}

			// Token: 0x06000601 RID: 1537 RVA: 0x00023E58 File Offset: 0x00022058
			protected override void OnUpdate()
			{
				if (this.Parent.Finished)
				{
					base.Finish();
				}
			}

			// Token: 0x06000602 RID: 1538 RVA: 0x00023E70 File Offset: 0x00022070
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				if (this.Parent._turning)
				{
					return;
				}
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				WaterEggmanInstance parent = this.Parent;
				if (parent._state != WaterEggmanInstance.State.Fleeing)
				{
					using (objectRenderer.BeginMatixState())
					{
						objectRenderer.ModelMatrix *= Matrix4.CreateTranslation(parent.JarOffset);
						if (parent._flipX)
						{
							objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
						}
						objectRenderer.Render(parent._animationArmJarReflection, false, false);
						if (parent._jarLidOpen)
						{
							objectRenderer.Render(parent._animationArmJarLidBack, new Vector2(-27.0, 69.0), false, false);
						}
					}
				}
			}
		}

		// Token: 0x020000F9 RID: 249
		private class ArmFront : ActiveObject
		{
			// Token: 0x170000F4 RID: 244
			// (get) Token: 0x06000604 RID: 1540 RVA: 0x00023F60 File Offset: 0x00022160
			// (set) Token: 0x06000605 RID: 1541 RVA: 0x00023F68 File Offset: 0x00022168
			public Vector2 Velocity { get; set; }

			// Token: 0x170000F5 RID: 245
			// (get) Token: 0x06000606 RID: 1542 RVA: 0x00023A64 File Offset: 0x00021C64
			public WaterEggmanInstance Parent
			{
				get
				{
					return base.ParentObject as WaterEggmanInstance;
				}
			}

			// Token: 0x06000607 RID: 1543 RVA: 0x00023F71 File Offset: 0x00022171
			protected override void OnStart()
			{
				this._updater = new Updater(this.GetUpdates());
				base.Priority = 330;
				base.LockLifetime = true;
				this._armJarPlaceholderY = 0;
			}

			// Token: 0x06000608 RID: 1544 RVA: 0x00023F9D File Offset: 0x0002219D
			protected override void OnUpdate()
			{
				this._updater.Update();
				this.Parent._jarBack.Position = base.Position;
			}

			// Token: 0x06000609 RID: 1545 RVA: 0x00023FC4 File Offset: 0x000221C4
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				if (this.Parent._turning)
				{
					return;
				}
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				this.DrawArm(objectRenderer);
				if (this._jarExplodeState == WaterEggmanInstance.ExplodeState.NotExploding)
				{
					this.DrawJar(objectRenderer, this.Parent.JarOffset);
				}
			}

			// Token: 0x0600060A RID: 1546 RVA: 0x0002400C File Offset: 0x0002220C
			private void DrawArm(IObjectRenderer or)
			{
				if (this.Parent.IsInvincibleFlashing)
				{
					or.AdditiveColour = BossObject.FlashAdditiveColour;
				}
				using (or.BeginMatixState())
				{
					if (this._flipX)
					{
						or.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
					}
					foreach (Vector2i v in this.GetArmBarPositions())
					{
						or.Render(this.Parent._animationArm, v, false, false);
					}
				}
				or.AdditiveColour = Colours.Black;
			}

			// Token: 0x0600060B RID: 1547 RVA: 0x000240E4 File Offset: 0x000222E4
			private void DrawJar(IObjectRenderer or, Vector2 offset)
			{
				if (this.Parent._dripVisible)
				{
					or.Render(this.Parent._animationDrip, offset + this.Parent._dripPosition + new Vector2i(this._flipX ? -8 : 8, -32), this._flipX, false);
				}
				if (!this.Parent._jarEmpty)
				{
					int num = this._flipX ? 8 : -8;
					int num2 = 47;
					bool flag;
					if (this.Parent._jarFillY < 0)
					{
						flag = true;
						this._armJarPlaceholderY = num2 + this.Parent._jarFillY;
					}
					else
					{
						flag = false;
					}
					int i;
					for (i = num2; i > num2 + this.Parent._jarFillY; i -= 11)
					{
						Rectanglei source = this.Parent._animationArmJarFilled.CurrentFrame.Source;
						Rectanglei r = new Rectanglei((int)offset.X + num - source.Width / 2, (int)offset.Y + i - 16 - source.Height / 2, source.Width, source.Height);
						or.Texture = this.Parent._animationArmJarFilled.CurrentTexture;
						or.Render(source, r, this._flipX, false);
					}
					i = num2 + this.Parent._jarFillY - this.Parent._animationArmJarFill.CurrentFrame.Source.Height / 2;
					if (this.Parent._animationArmJarFill.Index == 16)
					{
						i += 17;
					}
					or.Render(this.Parent._animationArmJarFill, offset + new Vector2((double)num, (double)i), this._flipX, false);
					if (this.Parent._animationArmJarFill.Index >= 15 && flag)
					{
						int num3 = this.Parent._jarFillY / -20;
						for (int j = 0; j < num3; j++)
						{
							if (num3 == 1)
							{
								or.Render(this.Parent._animationArmJarFillPlaceholderPrimary, offset + new Vector2((double)num, (double)(num2 + j * -20 + -16 + Math.Sign(j) * 8 * j)), this._flipX, false);
							}
							else if (num3 == 2)
							{
								if (j == 0)
								{
									or.Render(this.Parent._animationArmJarFillPlaceholderPrimary, offset + new Vector2((double)num, (double)(num2 + j * -20 + -16 + Math.Sign(j) * 8 * j)), this._flipX, false);
								}
								else
								{
									or.Render(this.Parent._animationArmJarFillPlaceholderPrimary, offset + new Vector2((double)num, (double)(num2 + j * -20 + -16 + Math.Sign(j) * 8 * j)), this._flipX, true);
								}
							}
							else if (j == 0)
							{
								or.Render(this.Parent._animationArmJarFillPlaceholderPrimary, offset + new Vector2((double)num, (double)(num2 + j * -20 + -16 + Math.Sign(j) * 8 * j)), this._flipX, false);
							}
							else if (j == num3 - 1)
							{
								or.Render(this.Parent._animationArmJarFillPlaceholderPrimary, offset + new Vector2((double)num, (double)(num2 + j * -20 + -16 + Math.Sign(j) * 8 * j)), this._flipX, true);
							}
							else
							{
								or.Render(this.Parent._animationArmJarFillPlaceholderSecondary, offset + new Vector2((double)num, (double)(num2 + j * -20 + -16 + Math.Sign(j) * 8 * j)), this._flipX, false);
							}
						}
					}
				}
				if (this.Parent.IsInvincibleFlashing)
				{
					or.AdditiveColour = BossObject.FlashAdditiveColour;
				}
				or.Render(this.Parent._animationArmJar, offset, this._flipX, false);
				or.AdditiveColour = Colours.Black;
				if (this.Parent._jarLidOpen)
				{
					or.Render(this.Parent._animationArmJarLidFront, offset + new Vector2((double)(this._flipX ? -14 : 14), 66.0), this._flipX, false);
					return;
				}
				or.Render(this.Parent._animationArmJarLidClosed, offset + new Vector2((double)(this._flipX ? 8 : -8), 53.0), this._flipX, false);
			}

			// Token: 0x0600060C RID: 1548 RVA: 0x00024556 File Offset: 0x00022756
			private IEnumerable<UpdateResult> GetUpdates()
			{
				while (this._jarExplodeState == WaterEggmanInstance.ExplodeState.NotExploding)
				{
					this._flipX = this.Parent._flipX;
					base.Position = this.Parent.Position;
					if (this.Parent.Finished)
					{
						base.Finish();
					}
					yield return UpdateResult.Next();
				}
				WaterEggmanInstance.BrokenJar brokenJar = this.CreateBrokenJar();
				this._jarExplodeState = WaterEggmanInstance.ExplodeState.Exploded;
				while (this._barExplodeState != WaterEggmanInstance.ExplodeState.Exploding)
				{
					yield return UpdateResult.Next();
				}
				brokenJar.Fall();
				this._jarExplodeState = WaterEggmanInstance.ExplodeState.Falling;
				yield return UpdateResult.Wait(2);
				Vector2i[] array = this.GetArmBarPositions().Reverse<Vector2i>().ToArray<Vector2i>();
				foreach (Vector2i b in array)
				{
					this._barExplodedLength += 16;
					this.EmitBar(base.Position + b);
					yield return UpdateResult.Wait(4);
				}
				Vector2i[] array2 = null;
				this._barExplodeState = WaterEggmanInstance.ExplodeState.Exploded;
				yield break;
			}

			// Token: 0x0600060D RID: 1549 RVA: 0x00024566 File Offset: 0x00022766
			private IEnumerable<Vector2i> GetArmBarPositions()
			{
				Vector2i position = WaterEggmanInstance.ArmFront.ArmBeginPoint;
				while (position.X >= -this.Parent._armExtension + 4 + this._barExplodedLength)
				{
					if (this._flipX)
					{
						yield return position;
					}
					else
					{
						yield return position;
					}
					position.X -= 16;
				}
				yield break;
			}

			// Token: 0x0600060E RID: 1550 RVA: 0x00024578 File Offset: 0x00022778
			private WaterEggmanInstance.BrokenJar CreateBrokenJar()
			{
				this.Parent._jarBack.Finish();
				Vector2i position = base.Position + this.Parent.JarOffset;
				this.Parent.ReleaseFragmentMetal(position, 12.0, 12, true);
				WaterEggmanInstance.BrokenJar brokenJar = base.Level.ObjectManager.AddSubObject<WaterEggmanInstance.BrokenJar>(this.Parent);
				brokenJar.Position = position;
				return brokenJar;
			}

			// Token: 0x0600060F RID: 1551 RVA: 0x000245E4 File Offset: 0x000227E4
			private void EmitBar(Vector2i position)
			{
				double x = (double)base.Level.Random.NextSign() * base.Level.Random.NextDouble(2.0, 8.0);
				Vector2 velocity = new Vector2(x, -12.0);
				Fragment fragment = base.Level.ObjectManager.AddSubObject<Fragment>(this);
				fragment.AnimationGroup = this.Parent._animationGroup;
				fragment.AnimationIndex = 39;
				fragment.Position = position;
				fragment.Velocity = velocity;
				fragment.AngularVelocity = 0.15707963267948966;
				fragment.Initialise();
				this.Parent.ExplodeAt(position);
			}

			// Token: 0x06000610 RID: 1552 RVA: 0x0002468F File Offset: 0x0002288F
			public bool ExplodeJar()
			{
				if (this._jarExplodeState == WaterEggmanInstance.ExplodeState.NotExploding)
				{
					this._jarExplodeState = WaterEggmanInstance.ExplodeState.Exploding;
					return true;
				}
				return this._jarExplodeState == WaterEggmanInstance.ExplodeState.Exploding;
			}

			// Token: 0x06000611 RID: 1553 RVA: 0x000246AE File Offset: 0x000228AE
			public bool ExplodeBar()
			{
				if (this._barExplodeState == WaterEggmanInstance.ExplodeState.NotExploding)
				{
					this._barExplodeState = WaterEggmanInstance.ExplodeState.Exploding;
					return true;
				}
				return this._barExplodeState == WaterEggmanInstance.ExplodeState.Exploding;
			}

			// Token: 0x04000669 RID: 1641
			private static readonly Vector2i ArmBeginPoint = new Vector2i(10, -186);

			// Token: 0x0400066A RID: 1642
			private Updater _updater;

			// Token: 0x0400066B RID: 1643
			private bool _flipX;

			// Token: 0x0400066C RID: 1644
			private WaterEggmanInstance.ExplodeState _jarExplodeState;

			// Token: 0x0400066D RID: 1645
			private WaterEggmanInstance.ExplodeState _barExplodeState;

			// Token: 0x0400066E RID: 1646
			private int _barExplodedLength;

			// Token: 0x0400066F RID: 1647
			private int _armJarPlaceholderY;
		}

		// Token: 0x020000FA RID: 250
		private class BrokenJar : ActiveObject
		{
			// Token: 0x170000F6 RID: 246
			// (get) Token: 0x06000614 RID: 1556 RVA: 0x00023A64 File Offset: 0x00021C64
			public WaterEggmanInstance Parent
			{
				get
				{
					return base.ParentObject as WaterEggmanInstance;
				}
			}

			// Token: 0x06000615 RID: 1557 RVA: 0x000246E0 File Offset: 0x000228E0
			protected override void OnStart()
			{
				this._animation = new AnimationInstance(this.Parent._animationGroup, 36);
			}

			// Token: 0x06000616 RID: 1558 RVA: 0x000246FC File Offset: 0x000228FC
			protected override void OnUpdate()
			{
				if (this._falling)
				{
					int num = this.Parent._flipX ? -1 : 1;
					if (!this._isUnderwater)
					{
						if (base.Level.WaterManager.IsUnderwater(base.Position))
						{
							this._isUnderwater = true;
							this._velocity = new Vector2(0.0, 1.0);
							base.Level.WaterManager.CreateSplash(base.Layer, SplashType.Enter, base.Position);
						}
						else
						{
							this._angle -= 0.10471975511965977 * (double)num;
							this._velocity += new Vector2(0.0, 0.875);
						}
					}
					else
					{
						this._angle -= 0.041887902047863905 * (double)num;
						this._velocity += new Vector2(0.0, 0.4375);
					}
					base.MovePrecise(this._velocity);
				}
			}

			// Token: 0x06000617 RID: 1559 RVA: 0x0002481F File Offset: 0x00022A1F
			protected override void OnAnimate()
			{
				this._animation.Animate();
			}

			// Token: 0x06000618 RID: 1560 RVA: 0x0002482C File Offset: 0x00022A2C
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				using (objectRenderer.BeginMatixState())
				{
					objectRenderer.ModelMatrix *= Matrix4.CreateRotationZ(this._angle);
					objectRenderer.Render(this._animation, this.Parent._flipX, false);
				}
			}

			// Token: 0x06000619 RID: 1561 RVA: 0x00024898 File Offset: 0x00022A98
			public void Fall()
			{
				this._falling = true;
			}

			// Token: 0x04000671 RID: 1649
			private AnimationInstance _animation;

			// Token: 0x04000672 RID: 1650
			private bool _falling;

			// Token: 0x04000673 RID: 1651
			private Vector2 _velocity;

			// Token: 0x04000674 RID: 1652
			private double _angle;

			// Token: 0x04000675 RID: 1653
			private bool _isUnderwater;
		}

		// Token: 0x020000FB RID: 251
		private class SuctionTube : ActiveObject
		{
			// Token: 0x170000F7 RID: 247
			// (get) Token: 0x0600061B RID: 1563 RVA: 0x000248A1 File Offset: 0x00022AA1
			// (set) Token: 0x0600061C RID: 1564 RVA: 0x000248A9 File Offset: 0x00022AA9
			public float TubeSuctionIndex { get; set; }

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x0600061D RID: 1565 RVA: 0x00023A64 File Offset: 0x00021C64
			public WaterEggmanInstance Parent
			{
				get
				{
					return base.ParentObject as WaterEggmanInstance;
				}
			}

			// Token: 0x0600061E RID: 1566 RVA: 0x000248B2 File Offset: 0x00022AB2
			protected override void OnStart()
			{
				this._updater = new Updater(this.GetUpdates());
				base.Priority = 124;
				base.LockLifetime = true;
			}

			// Token: 0x0600061F RID: 1567 RVA: 0x000248D4 File Offset: 0x00022AD4
			protected override void OnUpdate()
			{
				this._updater.Update();
			}

			// Token: 0x06000620 RID: 1568 RVA: 0x000248E4 File Offset: 0x00022AE4
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				int num = this._flipX ? 14 : -14;
				int i = 80;
				if (this._explodeState <= WaterEggmanInstance.ExplodeState.Exploded)
				{
					Animation animation = this.Parent._animationGroup[7];
					int[] frameMap = this._frameMap;
					Array.Clear(frameMap, 0, frameMap.Length);
					int num2 = (int)this.TubeSuctionIndex;
					if (this.TubeSuctionIndex - (float)num2 < 0.5f)
					{
						frameMap[num2] = 1;
						frameMap[num2 + 1] = 2;
						frameMap[num2 + 2] = 4;
						frameMap[num2 + 3] = 6;
					}
					else
					{
						frameMap[num2 + 2] = 3;
						frameMap[num2 + 3] = 5;
					}
					for (int j = 0; j < this._numSegments; j++)
					{
						Animation.Frame frame = animation.Frames[(j + 4 >= 22) ? 0 : frameMap[j + 4]];
						objectRenderer.Texture = this.Parent._animationGroup.Textures[frame.TextureIndex];
						objectRenderer.Render(frame.Source, new Vector2((double)num, (double)i), false, false);
						i += 16;
					}
					return;
				}
				int num3 = 80 + this._numSegments * 16;
				int num4 = 0;
				i -= 8;
				while (i < num3)
				{
					Rectanglei source = this._explodedAnimationInstance.CurrentFrame.Source;
					Rectanglei r = new Rectangle((double)(num - source.Width / 2), (double)i, (double)source.Width, (double)source.Height);
					if (r.Bottom > num3)
					{
						r.Bottom = num3;
						source.Height = r.Height;
					}
					using (objectRenderer.BeginMatixState())
					{
						objectRenderer.ModelMatrix = objectRenderer.ModelMatrix.Translate((double)r.Centre.X, (double)r.Centre.Y, 0.0).RotateZ(this._angle[num4]);
						r.X = -r.Width / 2;
						r.Y = -r.Height / 2;
						objectRenderer.Texture = this._explodedAnimationInstance.CurrentTexture;
						objectRenderer.Render(source, r, false, false);
						i += source.Height;
					}
					num4 = (num4 + 1) % 2;
				}
			}

			// Token: 0x06000621 RID: 1569 RVA: 0x00024B58 File Offset: 0x00022D58
			private IEnumerable<UpdateResult> GetUpdates()
			{
				while (this._explodeState == WaterEggmanInstance.ExplodeState.NotExploding)
				{
					this._flipX = this.Parent._flipX;
					this._numSegments = (this.Parent._tubeY - 80) / 16;
					base.Position = this.Parent.Position;
					if (this.Parent.Finished)
					{
						base.Finish();
					}
					yield return UpdateResult.Next();
				}
				int maxY = 80 + this._numSegments * 16;
				int x = this._flipX ? 32 : -24;
				int y = 80;
				while (y < maxY)
				{
					Vector2i position = base.Position + new Vector2i(x, y);
					this.Parent.ReleaseFragmentMetal(position, 4.0, 1, true);
					y += 136;
					yield return UpdateResult.Wait(4);
				}
				this._explodeState = WaterEggmanInstance.ExplodeState.Exploded;
				this._explodedAnimationInstance = new AnimationInstance(this.Parent._animationGroup, 38);
				while (this._explodeState != WaterEggmanInstance.ExplodeState.Falling)
				{
					yield return UpdateResult.Next();
				}
				this.Parent.ReleaseFragmentMetal(base.Position + new Vector2i(0, 80), 4.0, 1, true);
				base.LockLifetime = false;
				for (;;)
				{
					this._angle[0] += 0.10471975511965977;
					this._angle[1] -= 0.15707963267948966;
					this._velocity += new Vector2(0.0, 0.875);
					base.MovePrecise(this._velocity);
					yield return UpdateResult.Next();
				}
				yield break;
			}

			// Token: 0x06000622 RID: 1570 RVA: 0x00024B68 File Offset: 0x00022D68
			public bool Explode()
			{
				if (this._explodeState == WaterEggmanInstance.ExplodeState.NotExploding)
				{
					this._explodeState = WaterEggmanInstance.ExplodeState.Exploding;
					return true;
				}
				return this._explodeState == WaterEggmanInstance.ExplodeState.Exploding;
			}

			// Token: 0x06000623 RID: 1571 RVA: 0x00024B87 File Offset: 0x00022D87
			public void Fall()
			{
				this._explodeState = WaterEggmanInstance.ExplodeState.Falling;
			}

			// Token: 0x04000676 RID: 1654
			public const int TubeMaxIndex = 22;

			// Token: 0x04000677 RID: 1655
			private Updater _updater;

			// Token: 0x04000678 RID: 1656
			private bool _flipX;

			// Token: 0x04000679 RID: 1657
			private int _numSegments;

			// Token: 0x0400067A RID: 1658
			private int[] _frameMap = new int[26];

			// Token: 0x0400067B RID: 1659
			private WaterEggmanInstance.ExplodeState _explodeState;

			// Token: 0x0400067C RID: 1660
			private AnimationInstance _explodedAnimationInstance;

			// Token: 0x0400067D RID: 1661
			private Vector2 _velocity;

			// Token: 0x0400067E RID: 1662
			private double[] _angle = new double[2];
		}

		// Token: 0x020000FC RID: 252
		private class ChemicalDroplet : Enemy
		{
			// Token: 0x170000F9 RID: 249
			// (get) Token: 0x06000625 RID: 1573 RVA: 0x00023A64 File Offset: 0x00021C64
			public WaterEggmanInstance Parent
			{
				get
				{
					return base.ParentObject as WaterEggmanInstance;
				}
			}

			// Token: 0x06000626 RID: 1574 RVA: 0x00024BB4 File Offset: 0x00022DB4
			protected override void OnStart()
			{
				base.OnStart();
				this._updater = new Updater(this.GetUpdates());
				this._animationInstance = new AnimationInstance(this.Parent._animationGroup, 18);
				base.Priority = 320;
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -64, -64, 128, 128)
				};
			}

			// Token: 0x06000627 RID: 1575 RVA: 0x00024C1F File Offset: 0x00022E1F
			protected override void OnUpdate()
			{
				base.OnUpdate();
				this._updater.Update();
			}

			// Token: 0x06000628 RID: 1576 RVA: 0x00024C33 File Offset: 0x00022E33
			private IEnumerable<UpdateResult> GetUpdates()
			{
				for (;;)
				{
					yield return UpdateResult.Next();
					this._velocityY += 0.875;
					base.MovePrecise(0.0, this._velocityY);
					if (base.Level.WaterManager.IsUnderwater(base.Position))
					{
						break;
					}
					if (this.HasHitFloor())
					{
						goto Block_1;
					}
				}
				base.Finish();
				yield break;
				Block_1:
				this.EmitProjectiles();
				this.EmitSmallProjectile(new Vector2i(-64, -12));
				this.EmitSmallProjectile(new Vector2i(-38, -22));
				this.EmitSmallProjectile(new Vector2i(32, -22));
				this.EmitSmallProjectile(new Vector2i(60, -14));
				this._splashed = true;
				this._animationInstance = new AnimationInstance(this.Parent._animationGroup, 32);
				while (this._animationInstance.Cycles == 0)
				{
					yield return UpdateResult.Next();
				}
				base.Finish();
				yield break;
			}

			// Token: 0x06000629 RID: 1577 RVA: 0x00024C44 File Offset: 0x00022E44
			private bool HasHitFloor()
			{
				double num = double.MaxValue;
				foreach (CollisionInfo collisionInfo in CollisionVector.GetCollisions(this, 64, uint.MaxValue))
				{
					if (collisionInfo.Vector.Mode == CollisionMode.Top)
					{
						ActiveObject owner = collisionInfo.Vector.Owner;
						CollisionEvent collisionEvent = new CollisionEvent(this, collisionInfo);
						if (owner != null)
						{
							owner.Collision(collisionEvent);
							if (collisionEvent.IgnoreCollision)
							{
								continue;
							}
						}
						num = Math.Min(num, collisionInfo.Shift);
					}
				}
				if (num != 1.7976931348623157E+308)
				{
					base.MovePrecise(0.0, num);
					return true;
				}
				return false;
			}

			// Token: 0x0600062A RID: 1578 RVA: 0x00024CFC File Offset: 0x00022EFC
			private void EmitProjectiles()
			{
				for (int i = 0; i < 5; i++)
				{
					WaterEggmanInstance.ChemicalDropletProjectile chemicalDropletProjectile = base.Level.ObjectManager.AddSubObject<WaterEggmanInstance.ChemicalDropletProjectile>(this.Parent);
					chemicalDropletProjectile.Position = base.Position;
					chemicalDropletProjectile.Velocity = new Vector2((double)(base.Level.Random.NextSign() * base.Level.Random.Next(2, 5)), -this._velocityY - (double)base.Level.Random.Next(0, 4));
				}
			}

			// Token: 0x0600062B RID: 1579 RVA: 0x00024D80 File Offset: 0x00022F80
			private void EmitSmallProjectile(Vector2i position)
			{
				WaterEggmanInstance.SmallChemicalDropletProjectile smallChemicalDropletProjectile = base.Level.ObjectManager.AddSubObject<WaterEggmanInstance.SmallChemicalDropletProjectile>(base.ParentObject);
				smallChemicalDropletProjectile.Position = base.Position + position;
				double num = Math.Atan2((double)position.Y, (double)position.X);
				smallChemicalDropletProjectile.Velocity = new Vector2(8.0 * Math.Cos(num), 32.0 * Math.Sin(num));
			}

			// Token: 0x0600062C RID: 1580 RVA: 0x00024DF5 File Offset: 0x00022FF5
			protected override void OnHurtCharacter(ICharacter character)
			{
				this.Parent.DoRobotnikSmile();
			}

			// Token: 0x0600062D RID: 1581 RVA: 0x00024E02 File Offset: 0x00023002
			protected override void OnAnimate()
			{
				base.OnAnimate();
				this._animationInstance.Animate();
			}

			// Token: 0x0600062E RID: 1582 RVA: 0x00024E18 File Offset: 0x00023018
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				using (objectRenderer.BeginMatixState())
				{
					if (this.FlipX)
					{
						objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
					}
					if (!this._splashed)
					{
						objectRenderer.Render(this._animationInstance, false, false);
					}
					else if (this._animationInstance.Cycles == 0)
					{
						Vector2 vector = new Vector2(32.0, 0.0);
						Rectanglei source = this._animationInstance.CurrentFrame.Source;
						Rectanglei r = new Rectangle((double)(-(double)source.Width / 2) + vector.X, (double)(64 - source.Height), (double)source.Width, (double)source.Height);
						objectRenderer.Texture = this._animationInstance.CurrentTexture;
						objectRenderer.Render(source, r, false, false);
					}
				}
			}

			// Token: 0x04000680 RID: 1664
			private AnimationInstance _animationInstance;

			// Token: 0x04000681 RID: 1665
			private double _velocityY;

			// Token: 0x04000682 RID: 1666
			private Updater _updater;

			// Token: 0x04000683 RID: 1667
			private bool _splashed;

			// Token: 0x04000684 RID: 1668
			public bool FlipX;
		}

		// Token: 0x020000FD RID: 253
		private class ChemicalDropletProjectile : Enemy
		{
			// Token: 0x170000FA RID: 250
			// (get) Token: 0x06000630 RID: 1584 RVA: 0x00023A64 File Offset: 0x00021C64
			public WaterEggmanInstance Parent
			{
				get
				{
					return base.ParentObject as WaterEggmanInstance;
				}
			}

			// Token: 0x170000FB RID: 251
			// (get) Token: 0x06000631 RID: 1585 RVA: 0x00024F44 File Offset: 0x00023144
			// (set) Token: 0x06000632 RID: 1586 RVA: 0x00024F4C File Offset: 0x0002314C
			public Vector2 Velocity { get; set; }

			// Token: 0x06000633 RID: 1587 RVA: 0x00024F58 File Offset: 0x00023158
			protected override void OnStart()
			{
				base.OnStart();
				this._animationInstance = new AnimationInstance(this.Parent._animationGroup, 34);
				base.Priority = 320;
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -8, -8, 16, 16)
				};
			}

			// Token: 0x06000634 RID: 1588 RVA: 0x00024FAC File Offset: 0x000231AC
			protected override void OnUpdate()
			{
				base.OnUpdate();
				this.Velocity += new Vector2(0.0, 0.875);
				base.PositionPrecise += this.Velocity;
				if (base.Level.WaterManager.IsUnderwater(base.Position) || this.HasHitFloor())
				{
					base.Finish();
				}
			}

			// Token: 0x06000635 RID: 1589 RVA: 0x00025024 File Offset: 0x00023224
			private bool HasHitFloor()
			{
				using (IEnumerator<CollisionInfo> enumerator = CollisionVector.GetCollisions(this, 8, uint.MaxValue).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Vector.Mode == CollisionMode.Top)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06000636 RID: 1590 RVA: 0x00025080 File Offset: 0x00023280
			protected override void OnHurtCharacter(ICharacter character)
			{
				this.Parent.DoRobotnikSmile();
			}

			// Token: 0x06000637 RID: 1591 RVA: 0x0002508D File Offset: 0x0002328D
			protected override void OnAnimate()
			{
				this._animationInstance.Animate();
			}

			// Token: 0x06000638 RID: 1592 RVA: 0x0002509A File Offset: 0x0002329A
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				renderer.GetObjectRenderer().Render(this._animationInstance, false, false);
			}

			// Token: 0x04000685 RID: 1669
			private AnimationInstance _animationInstance;
		}

		// Token: 0x020000FE RID: 254
		private class SmallChemicalDropletProjectile : ParticleObject
		{
			// Token: 0x170000FC RID: 252
			// (get) Token: 0x0600063A RID: 1594 RVA: 0x000250AF File Offset: 0x000232AF
			// (set) Token: 0x0600063B RID: 1595 RVA: 0x000250B7 File Offset: 0x000232B7
			public Vector2 Velocity { get; set; }

			// Token: 0x0600063C RID: 1596 RVA: 0x000250C0 File Offset: 0x000232C0
			public SmallChemicalDropletProjectile() : base("/ANIGROUP", 33, 0)
			{
			}

			// Token: 0x0600063D RID: 1597 RVA: 0x000250D0 File Offset: 0x000232D0
			protected override void OnUpdate()
			{
				this.Velocity += new Vector2(0.0, 0.875);
				base.MovePrecise(this.Velocity);
				if (base.Level.WaterManager.IsUnderwater(base.Position))
				{
					base.Finish();
				}
				base.OnUpdate();
			}
		}
	}
}
