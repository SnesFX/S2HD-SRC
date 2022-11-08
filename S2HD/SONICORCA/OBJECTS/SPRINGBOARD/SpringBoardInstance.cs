using System;
using System.Collections.Generic;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.SPRINGBOARD
{
	// Token: 0x02000087 RID: 135
	public class SpringBoardInstance : ActiveObject
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00013D6B File Offset: 0x00011F6B
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x00013D73 File Offset: 0x00011F73
		[StateVariable]
		private bool FlipX
		{
			get
			{
				return this._flipX;
			}
			set
			{
				this._flipX = value;
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00013D7C File Offset: 0x00011F7C
		public SpringBoardInstance()
		{
			base.DesignBounds = new Rectanglei(-116, -32, 232, 64);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00013D9C File Offset: 0x00011F9C
		protected override void OnStart()
		{
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type.GetAbsolutePath("/ANIGROUP"));
			this._animation = new AnimationInstance(loadedResource, 0);
			base.CollisionVectors = new CollisionVector[]
			{
				new CollisionVector(this, default(Vector2i), default(Vector2i), uint.MaxValue, CollisionFlags.Conveyor | CollisionFlags.NoAngle | CollisionFlags.Solid),
				new CollisionVector(this, default(Vector2i), default(Vector2i), uint.MaxValue, CollisionFlags.Conveyor | CollisionFlags.NoAngle | CollisionFlags.Solid),
				new CollisionVector(this, default(Vector2i), default(Vector2i), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, default(Vector2i), default(Vector2i), uint.MaxValue, (CollisionFlags)0)
			};
			this.SetCollision(64);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000FD87 File Offset: 0x0000DF87
		protected override void OnUpdate()
		{
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00013E62 File Offset: 0x00012062
		protected override void OnUpdateCollision()
		{
			this.UpdateBumping();
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00013E6C File Offset: 0x0001206C
		private void UpdateBumping()
		{
			switch (this._state)
			{
			case 0:
			{
				bool flag = false;
				foreach (ICharacter character in this.GetStandingCharacters())
				{
					if (!this._flipX)
					{
						if (132 + MathX.Clamp(-132, character.Position.X - base.Position.X, 110) >= 32)
						{
							flag = true;
						}
					}
					else if (110 + MathX.Clamp(-110, character.Position.X - base.Position.X, 132) < 210)
					{
						flag = true;
					}
				}
				if (flag)
				{
					this.SetCollision(32);
					this._state++;
					return;
				}
				break;
			}
			case 1:
			case 2:
				this._state++;
				return;
			case 3:
			case 4:
				this.SetCollision(16);
				this._state++;
				return;
			case 5:
				this.SetCollision(32);
				this._state++;
				return;
			case 6:
				this.SetCollision(64);
				this._state++;
				base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/SPRING");
				return;
			case 7:
				foreach (ICharacter character2 in this.GetStandingCharacters())
				{
					double num2;
					if (!this._flipX)
					{
						int num = 132 + MathX.Clamp(-132, character2.Position.X - base.Position.X, 110);
						if (num >= 32)
						{
							bool flag = true;
						}
						double t = (double)(num - 32) / 210.0;
						num2 = MathX.Lerp(-16.0, -32.0, t);
					}
					else
					{
						int num3 = 110 + MathX.Clamp(-110, character2.Position.X - base.Position.X, 132);
						if (num3 < 210)
						{
							bool flag = true;
						}
						double t2 = (double)(210 - num3) / 210.0;
						num2 = MathX.Lerp(-16.0, -32.0, t2);
					}
					if (num2 != 0.0)
					{
						character2.LeaveGround();
						character2.Velocity = new Vector2(character2.Velocity.X, -32.0);
						character2.TumbleAngle = 0.0;
						character2.TumbleTurns = 1;
					}
				}
				this._state = 0;
				break;
			default:
				return;
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00014184 File Offset: 0x00012384
		private List<ICharacter> GetStandingCharacters()
		{
			List<ICharacter> list = new List<ICharacter>();
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				Character character2 = (Character)character;
				if (character2.GroundVector == base.CollisionVectors[0] || character2.GroundVector == base.CollisionVectors[1])
				{
					list.Add(character2);
				}
			}
			return list;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00014208 File Offset: 0x00012408
		private void SetCollision(int height = 64)
		{
			if (!this._flipX)
			{
				Rectanglei rectanglei = Rectanglei.FromLTRB(-132, -32 - height, 110, -32);
				Vector2i vector2i = new Vector2i(42, rectanglei.Top);
				base.CollisionVectors[0].RelativeA = rectanglei.BottomLeft;
				base.CollisionVectors[0].RelativeB = vector2i;
				base.CollisionVectors[1].RelativeA = vector2i;
				base.CollisionVectors[1].RelativeB = rectanglei.TopRight;
				base.CollisionVectors[2].RelativeA = rectanglei.TopRight;
				base.CollisionVectors[2].RelativeB = rectanglei.BottomRight;
				base.CollisionVectors[3].RelativeA = rectanglei.BottomRight;
				base.CollisionVectors[3].RelativeB = rectanglei.BottomLeft;
			}
			else
			{
				Rectanglei rectanglei2 = Rectanglei.FromLTRB(-110, -32 - height, 132, -32);
				Vector2i vector2i2 = new Vector2i(42, rectanglei2.Top);
				base.CollisionVectors[0].RelativeA = vector2i2;
				base.CollisionVectors[0].RelativeB = rectanglei2.BottomRight;
				base.CollisionVectors[1].RelativeA = rectanglei2.TopLeft;
				base.CollisionVectors[1].RelativeB = vector2i2;
				base.CollisionVectors[2].RelativeA = rectanglei2.BottomLeft;
				base.CollisionVectors[2].RelativeB = rectanglei2.TopLeft;
				base.CollisionVectors[3].RelativeA = rectanglei2.BottomRight;
				base.CollisionVectors[3].RelativeB = rectanglei2.BottomLeft;
			}
			base.RegisterCollisionUpdate();
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0001439C File Offset: 0x0001259C
		protected override void OnAnimate()
		{
			if (this._state == 0)
			{
				this._animation.Index = 0;
			}
			else if (this._state < 4)
			{
				this._animation.Index = 1;
			}
			else if (this._state < 6)
			{
				this._animation.Index = 2;
			}
			else
			{
				this._animation.Index = 3;
			}
			this._animation.Animate();
		}

		// Token: 0x060002BE RID: 702 RVA: 0x00014404 File Offset: 0x00012604
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, new Vector2i(0, -78), this._flipX, false);
		}

		// Token: 0x04000331 RID: 817
		private const int AnimationNormal = 0;

		// Token: 0x04000332 RID: 818
		private const int AnimationStep = 1;

		// Token: 0x04000333 RID: 819
		private const int AnimationDown = 2;

		// Token: 0x04000334 RID: 820
		private const int AnimationBounce = 3;

		// Token: 0x04000335 RID: 821
		private AnimationInstance _animation;

		// Token: 0x04000336 RID: 822
		private bool _flipX;

		// Token: 0x04000337 RID: 823
		private int _state;
	}
}
