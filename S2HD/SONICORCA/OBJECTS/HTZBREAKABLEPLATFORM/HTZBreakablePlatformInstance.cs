using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZBREAKABLEPLATFORM
{
	// Token: 0x02000051 RID: 81
	public class HTZBreakablePlatformInstance : ActiveObject
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600019E RID: 414 RVA: 0x0000C5B4 File Offset: 0x0000A7B4
		// (set) Token: 0x0600019F RID: 415 RVA: 0x0000C5BC File Offset: 0x0000A7BC
		[StateVariable]
		private uint Paths { get; set; } = uint.MaxValue;

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x0000C5C5 File Offset: 0x0000A7C5
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x0000C5CD File Offset: 0x0000A7CD
		[StateVariable]
		private int RemainingBlocks { get; set; } = 5;

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000C5D6 File Offset: 0x0000A7D6
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x0000C5DE File Offset: 0x0000A7DE
		[StateVariable]
		private int ResetPath { get; set; } = -1;

		// Token: 0x060001A4 RID: 420 RVA: 0x0000C5E7 File Offset: 0x0000A7E7
		public HTZBreakablePlatformInstance()
		{
			base.DesignBounds = new Rectanglei(-64, -160, 128, 384);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000C620 File Offset: 0x0000A820
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 5 - this.RemainingBlocks);
			base.CollisionVectors = CollisionVector.FromRectangle(this, default(Rectanglei), uint.MaxValue, (CollisionFlags)0);
			base.CollisionVectors[1].Id = 1;
			base.CollisionVectors[1].Flags = (CollisionFlags.NoAngle | CollisionFlags.NoBalance);
			this.UpdateBlockCollision();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000C694 File Offset: 0x0000A894
		protected override void OnUpdate()
		{
			if (this.RemainingBlocks == 0)
			{
				base.FinishForever();
				return;
			}
			if (this._breakBlockOff)
			{
				foreach (Vector2 vector in HTZBreakablePlatformInstance.ParticleVelocities)
				{
					base.Level.ObjectManager.AddObject(new ObjectPlacement(base.Type.GetAbsolutePath("SONICORCA/OBJECTS/HTZROCK/PARTICLE"), base.Level.Map.Layers.IndexOf(base.Level.Map.Layers.Last<LevelLayer>()), base.Position, new
					{
						Velocity = new Vector2(vector.X, vector.Y)
					}));
				}
				base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/BREAKABLE"));
				int points = this._playerThatBroke.AwardChainedScore();
				base.Level.CreateScoreObject(points, base.Position);
				int num = this.RemainingBlocks;
				this.RemainingBlocks = num - 1;
				(base.Entry.State as HTZBreakablePlatformInstance).RemainingBlocks = this.RemainingBlocks;
				this._breakBlockOff = false;
				if (this.RemainingBlocks == 0)
				{
					base.FinishForever();
					base.CollisionVectors = new CollisionVector[0];
				}
				else
				{
					AnimationInstance animation = this._animation;
					num = animation.Index;
					animation.Index = num + 1;
					foreach (ICharacter character in this.GetStandingCharacters())
					{
						character.LeaveGround();
					}
				}
			}
			this.UpdateBlockCollision();
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000C84C File Offset: 0x0000AA4C
		private void UpdateBlockCollision()
		{
			if (this.RemainingBlocks > 0 && base.CollisionVectors.Length != 0)
			{
				int num = this.RemainingBlocks * 64;
				CollisionVector.UpdateRectangle(base.CollisionVectors, new Rectanglei(-64, 160 - num, 128, num));
				base.RegisterCollisionUpdate();
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000C89C File Offset: 0x0000AA9C
		private List<ICharacter> GetStandingCharacters()
		{
			List<ICharacter> list = new List<ICharacter>();
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				Character character2 = (Character)character;
				if (character2.GroundVector == base.CollisionVectors[1])
				{
					list.Add(character2);
				}
			}
			return list;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000C910 File Offset: 0x0000AB10
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.Id == 1 && e.ActiveObject.Type.Classification == ObjectClassification.Character)
			{
				ICharacter character = (ICharacter)e.ActiveObject;
				if (this.RemainingBlocks == 5)
				{
					if (((ulong)this.Paths & (ulong)(1L << (character.Path & 31))) != 0UL)
					{
						if (character.IsSpinball)
						{
							this.BreakBlocks(e, character);
							return;
						}
						if (this.ResetPath != -1)
						{
							character.Path = this.ResetPath;
							if (character.Mode != CollisionMode.Top)
							{
								character.GroundVelocity = 0.0;
								character.LeaveGround();
								return;
							}
						}
					}
				}
				else if (character.IsSpinball)
				{
					this.BreakBlocks(e, character);
				}
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000C9BC File Offset: 0x0000ABBC
		private void BreakBlocks(CollisionEvent e, ICharacter character)
		{
			this._breakBlockOff = true;
			this._playerThatBroke = character.Player;
			character.LeaveGround();
			character.Velocity = new Vector2(character.Velocity.X, -1.0);
			e.MaintainVelocity = true;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000CA0B File Offset: 0x0000AC0B
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000CA18 File Offset: 0x0000AC18
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x040001AC RID: 428
		private static readonly IReadOnlyCollection<Vector2> ParticleVelocities = new Vector2[]
		{
			new Vector2(-6.0, -14.0),
			new Vector2(-4.0, -18.0),
			new Vector2(-2.0, -22.0),
			new Vector2(2.0, -24.0),
			new Vector2(4.0, -16.0),
			new Vector2(6.0, -12.0)
		};

		// Token: 0x040001AD RID: 429
		private const int MaximumBlocks = 5;

		// Token: 0x040001AE RID: 430
		private AnimationInstance _animation;

		// Token: 0x040001AF RID: 431
		private bool _breakBlockOff;

		// Token: 0x040001B0 RID: 432
		private Player _playerThatBroke;
	}
}
