using System;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.GRABBER
{
	// Token: 0x02000083 RID: 131
	public class GrabberInstance : Badnik
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x00012F18 File Offset: 0x00011118
		public GrabberInstance()
		{
			base.DesignBounds = new Rectanglei(-128, -128, 256, 256);
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -16, -16, 32, 32),
				new CollisionRectangle(this, 1, -16 + this.CharacterGrabOffset.X, -8 + this.CharacterGrabOffset.Y, 32, 32)
			};
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00012F9C File Offset: 0x0001119C
		protected override void OnStart()
		{
			base.OnStart();
			this._regrabTicksCounter = 0;
			this._canGrabAgain = true;
			this._playerEscaped = false;
			this._grabEscapeProtagonistCounter = 0;
			this._lastEscapeProtagonistInput = 0;
			this._grabEscapeSidekickCounter = 0;
			this._lastEscapeSidekickInput = 0;
			this._patrolTicks = 255;
			this._direction = -1;
			this._animationGroup = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type.GetAbsolutePath("/ANIGROUP"));
			this._animationBody = new AnimationInstance(this._animationGroup, 0);
			this._animationLegs = new AnimationInstance(this._animationGroup, 7);
			this._animationWheels = new AnimationInstance(this._animationGroup, 12);
			this._animationThread = new AnimationInstance(this._animationGroup, 13);
			this._animationBodyExplode = new AnimationInstance(this._animationGroup, 14);
			this._legsSubObject = base.Level.ObjectManager.AddSubObject<GrabberInstance.Legs>(this);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00013087 File Offset: 0x00011287
		protected override void OnStop()
		{
			base.OnStop();
			this.ReleaseCharacter();
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00013098 File Offset: 0x00011298
		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (this._grabbedCharacter != null)
			{
				if (this._grabbedCharacter == base.Level.Player.Protagonist)
				{
					if (base.Level.Player.Protagonist.Input.HorizontalDirection != this._lastEscapeProtagonistInput)
					{
						this._lastEscapeProtagonistInput = base.Level.Player.Protagonist.Input.HorizontalDirection;
						this._grabEscapeProtagonistCounter++;
					}
					if (this._grabEscapeProtagonistCounter >= 8)
					{
						this.ReleaseCharacter();
					}
				}
				if (base.Level.Player.Sidekick != null && this._grabbedCharacter == base.Level.Player.Sidekick)
				{
					if (base.Level.Player.Sidekick.Input.HorizontalDirection != this._lastEscapeSidekickInput)
					{
						this._lastEscapeSidekickInput = base.Level.Player.Sidekick.Input.HorizontalDirection;
						this._grabEscapeSidekickCounter++;
					}
					if (this._lastEscapeSidekickInput >= 8)
					{
						this.ReleaseCharacter();
					}
				}
				if (this._grabbedCharacter == null)
				{
					this._lastEscapeSidekickInput = 0;
					this._lastEscapeProtagonistInput = 0;
					this._grabEscapeProtagonistCounter = 0;
					this._lastEscapeSidekickInput = 0;
					this._status = GrabberInstance.StatusType.Raising;
					this._regrabTicksCounter = 0;
					this._playerEscaped = true;
					this._canGrabAgain = false;
				}
			}
			if (this._playerEscaped)
			{
				if (this._regrabTicksCounter <= 30)
				{
					this._regrabTicksCounter++;
				}
				else
				{
					this._playerEscaped = false;
					this._canGrabAgain = true;
				}
			}
			if (this._grabbedCharacter != null)
			{
				if (this._grabbedCharacter.ObjectLink != this || this._grabbedCharacter.IsDebug)
				{
					this.ReleaseCharacter();
					this._status = GrabberInstance.StatusType.Raising;
				}
				else
				{
					this._grabbedCharacter.Position = base.Position + this.CharacterGrabOffset * new Vector2i(this._direction, 1);
					this._grabbedCharacter.Facing = this._direction * -1;
				}
			}
			switch (this._status)
			{
			case GrabberInstance.StatusType.Patroling:
				if (this.DetectPlayer())
				{
					this._status = GrabberInstance.StatusType.Detected;
					this._ticksRemaining = 16;
					return;
				}
				if (this._patrolTicks == 0)
				{
					this._direction *= -1;
					this._patrolTicks = 255;
				}
				else
				{
					this._patrolTicks--;
				}
				base.Move(this._direction, 0);
				return;
			case GrabberInstance.StatusType.Detected:
				this._ticksRemaining--;
				if (this._ticksRemaining <= 0)
				{
					this._status = GrabberInstance.StatusType.Lowering;
					return;
				}
				break;
			case GrabberInstance.StatusType.Lowering:
				if (this._lowerY < 264 && this._grabbedCharacter == null)
				{
					base.Move(0, Math.Min(8, 264 - this._lowerY));
					this._lowerY += 8;
					return;
				}
				this._status = GrabberInstance.StatusType.Raising;
				if (this._grabbedCharacter != null)
				{
					this._ticksRemaining = 20;
					return;
				}
				break;
			case GrabberInstance.StatusType.Raising:
				if (this._ticksRemaining > 0)
				{
					this._ticksRemaining--;
					return;
				}
				if (this._lowerY > 0)
				{
					base.Move(0, -Math.Min(8, this._lowerY));
					this._lowerY -= 8;
					return;
				}
				if (this._grabbedCharacter != null)
				{
					this._status = GrabberInstance.StatusType.Exploding;
					this._ticksRemaining = 130;
					return;
				}
				this._status = GrabberInstance.StatusType.Patroling;
				this._ticksRemaining = 0;
				return;
			case GrabberInstance.StatusType.Exploding:
				this._ticksRemaining--;
				if (this._ticksRemaining == 0)
				{
					if (this._grabbedCharacter != null)
					{
						this._grabbedCharacter.Hurt(this._direction, PlayerDeathCause.Hurt);
						this.ReleaseCharacter();
						base.CreateExplosionObject();
						base.FinishForever();
					}
					this._status = GrabberInstance.StatusType.Patroling;
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00013444 File Offset: 0x00011644
		private bool DetectPlayer()
		{
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				if (character.ShouldReactToLevel && (double)(character.Position.Y - base.Position.Y) >= 0.0 && (double)Math.Abs(character.Position.X - base.Position.X) < (double)(base.CollisionRectangles[1].Bounds.Width / 4))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00013510 File Offset: 0x00011710
		private void GrabCharacter(ICharacter character)
		{
			this._grabbedCharacter = character;
			this._grabbedCharacter.LeaveGround();
			character.IsAirborne = true;
			character.CheckCollision = false;
			character.ObjectLink = this;
			character.Position = base.Position + this.CharacterGrabOffset;
			character.Facing = this._direction * -1;
			character.SpecialState = CharacterSpecialState.Grabbed;
			this._ticksRemaining = 0;
			this._previousCharacterLayer = base.Level.Map.Layers.IndexOf(this._grabbedCharacter.Layer);
			this._grabbedCharacter.Layer = base.Layer;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000135B0 File Offset: 0x000117B0
		private void ReleaseCharacter()
		{
			if (this._grabbedCharacter == null)
			{
				return;
			}
			this._explodeOpacity = 0f;
			this._explodeOpacityAngleVelocity = 0f;
			this._animationBody.ResetFrame();
			this._animationBody.Cycles = 0;
			this._grabbedCharacter.Layer = base.Level.Map.Layers[this._previousCharacterLayer];
			this._grabbedCharacter.SpecialState = CharacterSpecialState.Normal;
			this._grabbedCharacter.Velocity = default(Vector2);
			this._grabbedCharacter.IsSpinball = true;
			this._grabbedCharacter.IsAirborne = true;
			this._grabbedCharacter.CheckCollision = true;
			this._grabbedCharacter.ObjectLink = null;
			this._grabbedCharacter = null;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00013670 File Offset: 0x00011870
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			if (e.Id == 0)
			{
				if (character.IsDeadly)
				{
					this.ReleaseCharacter();
					base.Destroy(character);
					return;
				}
			}
			else if (this._grabbedCharacter == null && this._status != GrabberInstance.StatusType.Patroling && this._canGrabAgain && !character.IsAirborne)
			{
				this.GrabCharacter(character);
				e.MaintainVelocity = true;
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000136EC File Offset: 0x000118EC
		protected override void OnAnimate()
		{
			if (base.Level.State == LevelState.Editing)
			{
				this._animationBody.Animate();
				this._animationLegs.Animate();
				this._showLegs = true;
				return;
			}
			switch (this._status)
			{
			case GrabberInstance.StatusType.Patroling:
				if (this._patrolTicks < this._animationGroup[2].Duration)
				{
					this._animationBody.Index = 2;
				}
				else if (this._patrolTicks == 255)
				{
					this._animationBody.Index = 3;
				}
				else if ((this._patrolTicks == 84 || this._patrolTicks == 168) && base.Level.Random.Next(0, 2) == 0)
				{
					this._animationBody.Index = 1;
				}
				break;
			case GrabberInstance.StatusType.Lowering:
				this._animationBody.Index = 4;
				break;
			case GrabberInstance.StatusType.Raising:
				if (this._animationBody.Index == 4)
				{
					this._animationBody.Index = 5;
				}
				break;
			case GrabberInstance.StatusType.Exploding:
				this._explodeOpacityAngleVelocity = (float)MathX.Clamp(0.10471975511965977, (double)this._explodeOpacityAngleVelocity + 0.005235987755982988, 0.7853981633974483);
				this._explodeOpacityAngle += this._explodeOpacityAngleVelocity;
				this._explodeOpacity = (float)MathX.Clamp(0.0, (1.0 - Math.Cos((double)this._explodeOpacityAngle)) / 2.0, 1.0);
				break;
			}
			if (this._grabbedCharacter != null)
			{
				this._animationBody.Index = 6;
			}
			this._animationBody.Animate();
			this._animationLegs.Animate();
			if (Math.Abs(base.PositionPrecise.Y - base.LastPositionPrecise.Y) > 0.0)
			{
				this._animationWheels.Animate();
			}
			this._animationThread.Animate();
			switch (this._animationBody.Index)
			{
			case 1:
			case 2:
			case 3:
				this._showLegs = false;
				return;
			case 4:
				this._animationLegs.Index = 8;
				this._showLegs = true;
				return;
			case 6:
				if (this._grabbedCharacter != null && this._grabbedCharacter.Entry.Name.Contains("Tails"))
				{
					this._animationLegs.Index = 10;
				}
				else
				{
					this._animationLegs.Index = 11;
				}
				this._showLegs = true;
				return;
			case 9:
				this._animationLegs.Index = 9;
				this._showLegs = true;
				return;
			}
			this._animationLegs.Index = 7;
			this._showLegs = true;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000139BC File Offset: 0x00011BBC
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			bool flag = this._direction < 0;
			using (objectRenderer.BeginMatixState())
			{
				if (flag)
				{
					objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
				}
				objectRenderer.Render(this._animationBody, false, false);
				if (this._explodeOpacity > 0f)
				{
					objectRenderer.MultiplyColour = new Colour((double)this._explodeOpacity, 1.0, 1.0, 1.0);
					objectRenderer.Render(this._animationBodyExplode, false, false);
					objectRenderer.MultiplyColour = Colours.White;
				}
				if (this._showLegs)
				{
					objectRenderer.Render(this._animationLegs, false, false);
				}
				if (this._lowerY > 0)
				{
					Rectanglei source = this._animationThread.CurrentFrame.Source;
					objectRenderer.Render(source, new Rectangle((double)(-(double)source.Width / 2 + -6), (double)(-(double)this._lowerY - 64), (double)source.Width, (double)this._lowerY), false, false);
				}
				objectRenderer.Render(this._animationWheels, false, false);
			}
		}

		// Token: 0x040002FB RID: 763
		private const int AnimationBodyStationary = 0;

		// Token: 0x040002FC RID: 764
		private const int AnimationBodyStationaryWiggle = 1;

		// Token: 0x040002FD RID: 765
		private const int AnimationBodyTurnBegin = 2;

		// Token: 0x040002FE RID: 766
		private const int AnimationBodyTurnEnd = 3;

		// Token: 0x040002FF RID: 767
		private const int AnimationBodyOpen = 4;

		// Token: 0x04000300 RID: 768
		private const int AnimationBodyClose = 5;

		// Token: 0x04000301 RID: 769
		private const int AnimationBodyHold = 6;

		// Token: 0x04000302 RID: 770
		private const int AnimationLegsStationary = 7;

		// Token: 0x04000303 RID: 771
		private const int AnimationLegsOpen = 8;

		// Token: 0x04000304 RID: 772
		private const int AnimationLegsClose = 9;

		// Token: 0x04000305 RID: 773
		private const int AnimationLegsHold = 10;

		// Token: 0x04000306 RID: 774
		private const int AnimationLegsHoldWiggle = 11;

		// Token: 0x04000307 RID: 775
		private const int AnimationWheels = 12;

		// Token: 0x04000308 RID: 776
		private const int AnimationThread = 13;

		// Token: 0x04000309 RID: 777
		private const int AnimationBodyExplode = 14;

		// Token: 0x0400030A RID: 778
		private AnimationGroup _animationGroup;

		// Token: 0x0400030B RID: 779
		private AnimationInstance _animationBody;

		// Token: 0x0400030C RID: 780
		private AnimationInstance _animationLegs;

		// Token: 0x0400030D RID: 781
		private AnimationInstance _animationWheels;

		// Token: 0x0400030E RID: 782
		private AnimationInstance _animationThread;

		// Token: 0x0400030F RID: 783
		private AnimationInstance _animationBodyExplode;

		// Token: 0x04000310 RID: 784
		private bool _showLegs;

		// Token: 0x04000311 RID: 785
		private GrabberInstance.Legs _legsSubObject;

		// Token: 0x04000312 RID: 786
		private float _explodeOpacity;

		// Token: 0x04000313 RID: 787
		private float _explodeOpacityAngle;

		// Token: 0x04000314 RID: 788
		private float _explodeOpacityAngleVelocity;

		// Token: 0x04000315 RID: 789
		private const int MoveSpeed = 1;

		// Token: 0x04000316 RID: 790
		private const int LowerSpeed = 8;

		// Token: 0x04000317 RID: 791
		private readonly Vector2i CharacterGrabOffset = new Vector2i(-8, 64);

		// Token: 0x04000318 RID: 792
		private GrabberInstance.StatusType _status;

		// Token: 0x04000319 RID: 793
		private int _direction;

		// Token: 0x0400031A RID: 794
		private int _patrolTicks;

		// Token: 0x0400031B RID: 795
		private int _ticksRemaining;

		// Token: 0x0400031C RID: 796
		private int _lowerY;

		// Token: 0x0400031D RID: 797
		private int _regrabTicksCounter;

		// Token: 0x0400031E RID: 798
		private bool _canGrabAgain;

		// Token: 0x0400031F RID: 799
		private bool _playerEscaped;

		// Token: 0x04000320 RID: 800
		private int _grabEscapeProtagonistCounter;

		// Token: 0x04000321 RID: 801
		private int _lastEscapeProtagonistInput;

		// Token: 0x04000322 RID: 802
		private int _grabEscapeSidekickCounter;

		// Token: 0x04000323 RID: 803
		private int _lastEscapeSidekickInput;

		// Token: 0x04000324 RID: 804
		private int _previousCharacterLayer;

		// Token: 0x04000325 RID: 805
		private ICharacter _grabbedCharacter;

		// Token: 0x020000F3 RID: 243
		private enum StatusType
		{
			// Token: 0x0400064E RID: 1614
			Patroling,
			// Token: 0x0400064F RID: 1615
			Detected,
			// Token: 0x04000650 RID: 1616
			Lowering,
			// Token: 0x04000651 RID: 1617
			Raising,
			// Token: 0x04000652 RID: 1618
			Exploding
		}

		// Token: 0x020000F4 RID: 244
		private class Legs : ActiveObject
		{
			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x060005EF RID: 1519 RVA: 0x00023988 File Offset: 0x00021B88
			public GrabberInstance Parent
			{
				get
				{
					return base.ParentObject as GrabberInstance;
				}
			}

			// Token: 0x060005F0 RID: 1520 RVA: 0x00023995 File Offset: 0x00021B95
			protected override void OnStart()
			{
				base.Priority = 1152;
				base.LockLifetime = true;
			}

			// Token: 0x060005F1 RID: 1521 RVA: 0x000239A9 File Offset: 0x00021BA9
			protected override void OnUpdate()
			{
				if (this.Parent.Finished)
				{
					base.Finish();
					return;
				}
				base.Position = this.Parent.Position;
			}

			// Token: 0x060005F2 RID: 1522 RVA: 0x000239D0 File Offset: 0x00021BD0
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				GrabberInstance parent = this.Parent;
				if (!parent._showLegs)
				{
					return;
				}
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				bool flag = parent._direction < 0;
				using (objectRenderer.BeginMatixState())
				{
					if (flag)
					{
						objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
					}
					objectRenderer.Render(parent._animationLegs, false, false);
				}
			}
		}
	}
}
