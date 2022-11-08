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

namespace SONICORCA.OBJECTS.HTZSEESAW
{
	// Token: 0x02000049 RID: 73
	public class HTZSeeSawInstance : ActiveObject
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000173 RID: 371 RVA: 0x0000B7B3 File Offset: 0x000099B3
		// (set) Token: 0x06000174 RID: 372 RVA: 0x0000B7BB File Offset: 0x000099BB
		[StateVariable]
		private bool FlipX { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000175 RID: 373 RVA: 0x0000B7C4 File Offset: 0x000099C4
		// (set) Token: 0x06000176 RID: 374 RVA: 0x0000B7CC File Offset: 0x000099CC
		[StateVariable]
		private double StrengthMultiplier
		{
			get
			{
				return this._strengthMultiplier;
			}
			set
			{
				this._strengthMultiplier = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000177 RID: 375 RVA: 0x0000B7D5 File Offset: 0x000099D5
		private IEnumerable<ICharacter> CharactersOnObject
		{
			get
			{
				return this._charactersOnLeftSide.Concat(this._charactersOnMiddleSide).Concat(this._charactersOnRightSide);
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000B7F4 File Offset: 0x000099F4
		public HTZSeeSawInstance()
		{
			base.DesignBounds = new Rectanglei(-216, -132, 432, 264);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000B87C File Offset: 0x00009A7C
		protected override void OnStart()
		{
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
			this._animationStand = new AnimationInstance(loadedResource, 0);
			this._animationPlatform = new AnimationInstance(loadedResource, 1);
			base.CollisionVectors = new CollisionVector[]
			{
				new CollisionVector(this, default(Vector2i), default(Vector2i), uint.MaxValue, CollisionFlags.Conveyor | CollisionFlags.NoAngle | CollisionFlags.NoBalance | CollisionFlags.NoAutoAlignment)
			};
			this._bias = (this.FlipX ? -1 : 1);
			this._visualAngle = this.VisualAngles[this._bias + 1];
			this._sol = base.Level.ObjectManager.AddSubObject<HTZSeeSawInstance.Sol>(this);
			this._sol.Position = base.Position + new Vector2i(160 * this._bias, 32);
			this._sol.Side = this._bias;
			this._sol.LockLifetime = true;
			base.Priority = -256;
			base.ShadowInfo.MaxShadowOffset = new Vector2i(16);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000B98C File Offset: 0x00009B8C
		protected override void OnUpdateEditor()
		{
			base.OnUpdateEditor();
			this._sol.Position = base.Position + new Vector2i(160 * this._bias, 32);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000B9C0 File Offset: 0x00009BC0
		protected override void OnUpdate()
		{
			if (this._charactersOnLeftSide.Count != 0 || this._charactersOnMiddleSide.Count != 0 || this._charactersOnRightSide.Count != 0)
			{
				int num = Math.Sign(this._charactersOnRightSide.Count - this._charactersOnLeftSide.Count);
				if (num != this._bias)
				{
					this._bias = num;
					this.OnCharacterTouch(this._bias, this._maxCharacterLandVelocity);
				}
			}
			this._maxCharacterLandVelocity = 0.0;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000BA42 File Offset: 0x00009C42
		protected override void OnStop()
		{
			base.OnStop();
			this._sol.FinishForever();
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000BA55 File Offset: 0x00009C55
		protected override void OnCollision(CollisionEvent e)
		{
			ObjectClassification classification = e.ActiveObject.Type.Classification;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000BA6C File Offset: 0x00009C6C
		private List<ICharacter> GetStandingCharacters()
		{
			List<ICharacter> list = new List<ICharacter>();
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				if (character.GroundVector == base.CollisionVectors[0] && !character.IsAirborne)
				{
					list.Add(character);
				}
			}
			return list;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000BAE4 File Offset: 0x00009CE4
		protected override void OnUpdateCollision()
		{
			this._charactersOnLeftSide.Clear();
			this._charactersOnRightSide.Clear();
			this._charactersOnMiddleSide.Clear();
			foreach (ICharacter character in this.GetStandingCharacters())
			{
				if (character.Velocity.Y >= 0.0 || !character.IsAirborne)
				{
					int num;
					if (character.Position.X < base.Position.X - 32)
					{
						num = -1;
						this._charactersOnLeftSide.Add(character);
					}
					else if (character.Position.X > base.Position.X + 32)
					{
						num = 0;
						this._charactersOnRightSide.Add(character);
					}
					else
					{
						num = 1;
						this._charactersOnMiddleSide.Add(character);
					}
					if (!this._sol.Flying && num != this._sol.Side)
					{
						this._maxCharacterLandVelocity = Math.Max(this._maxCharacterLandVelocity, character.Velocity.Y);
					}
				}
			}
			if (this._bias < -1 || this._bias > 1)
			{
				return;
			}
			int[] array = new int[]
			{
				80,
				4,
				-64
			};
			int[] array2 = new int[]
			{
				-64,
				4,
				80
			};
			CollisionVector collisionVector = base.CollisionVectors[0];
			collisionVector.RelativeA = new Vector2i(-192, array[this._bias + 1]);
			collisionVector.RelativeB = new Vector2i(192, array2[this._bias + 1]);
			base.RegisterCollisionUpdate();
			foreach (ICharacter character2 in this.CharactersOnObject)
			{
				int num2;
				if (this.GetYIntersectAt(character2.Position.X, out num2))
				{
					character2.Position = new Vector2i(character2.Position.X, num2 - character2.CollisionRadius.Y - 4);
				}
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000BD30 File Offset: 0x00009F30
		private bool GetYIntersectAt(int x, out int y)
		{
			CollisionVector a = base.CollisionVectors[0];
			CollisionVector b = new CollisionVector(new Vector2i(x, base.Position.Y - 512), new Vector2i(x, base.Position.Y + 512), uint.MaxValue, (CollisionFlags)0);
			Vector2 vector;
			if (!CollisionVector.GetIntersection(a, b, out vector))
			{
				y = 0;
				return false;
			}
			y = (int)vector.Y - 1;
			return true;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000BDA0 File Offset: 0x00009FA0
		private void OnCharacterTouch(int side, double yVelocity)
		{
			if (!this._sol.Flying && side != this._sol.Side)
			{
				Vector2 velocity = new Vector2(4.3125, 32.375);
				if (side != 0)
				{
					velocity = new Vector2(3.1875, 43.75);
					if (yVelocity > 36.0)
					{
						velocity = new Vector2(2.5, 56.0);
					}
				}
				if (this._sol.Side == 1)
				{
					velocity.X *= -1.0;
				}
				velocity.Y *= -1.0;
				this._sol.Velocity = velocity;
				this._sol.Side = ((this._sol.Side == 1) ? -1 : 1);
				this._sol.Flying = true;
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000BE9C File Offset: 0x0000A09C
		private void OnSolTouch(int side, double yVelocity)
		{
			IEnumerable<ICharacter> enumerable = (side == -1) ? this._charactersOnRightSide.Concat(this._charactersOnMiddleSide) : this._charactersOnLeftSide.Concat(this._charactersOnMiddleSide);
			bool flag = false;
			foreach (ICharacter character in enumerable)
			{
				character.LeaveGround();
				character.IsAirborne = true;
				character.Velocity = new Vector2(character.Velocity.X, -yVelocity * this._strengthMultiplier);
				character.TumbleAngle = 0.0;
				character.TumbleTurns = 1;
				character.GroundVelocity = 0.0;
				flag = true;
			}
			if (flag)
			{
				base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/SPRING"));
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000BF80 File Offset: 0x0000A180
		private void AnimateVisualAngle()
		{
			this._visualAngle = MathX.GoTowards(this._visualAngle, this.VisualAngles[this._bias + 1], 0.39269908169872414);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000BFAF File Offset: 0x0000A1AF
		protected override void OnAnimate()
		{
			this.AnimateVisualAngle();
			this._animationStand.Animate();
			this._animationPlatform.Animate();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000BFD0 File Offset: 0x0000A1D0
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			using (objectRenderer.BeginMatixState())
			{
				if (this._visualAngle != 0.0)
				{
					objectRenderer.ModelMatrix *= Matrix4.CreateRotationZ(this._visualAngle);
				}
				objectRenderer.Render(this._animationPlatform, false, false);
			}
			objectRenderer.Render(this._animationStand, false, false);
		}

		// Token: 0x0400018C RID: 396
		private readonly IReadOnlyList<double> VisualAngles = new double[]
		{
			-0.39269908169872414,
			0.0,
			0.39269908169872414
		};

		// Token: 0x0400018D RID: 397
		private const int AnimationStand = 0;

		// Token: 0x0400018E RID: 398
		private const int AnimationPlatform = 1;

		// Token: 0x0400018F RID: 399
		private AnimationInstance _animationStand;

		// Token: 0x04000190 RID: 400
		private AnimationInstance _animationPlatform;

		// Token: 0x04000191 RID: 401
		private readonly List<ICharacter> _charactersOnLeftSide = new List<ICharacter>();

		// Token: 0x04000192 RID: 402
		private readonly List<ICharacter> _charactersOnMiddleSide = new List<ICharacter>();

		// Token: 0x04000193 RID: 403
		private readonly List<ICharacter> _charactersOnRightSide = new List<ICharacter>();

		// Token: 0x04000194 RID: 404
		private int _bias;

		// Token: 0x04000195 RID: 405
		private double _visualAngle;

		// Token: 0x04000196 RID: 406
		private HTZSeeSawInstance.Sol _sol;

		// Token: 0x04000197 RID: 407
		private double _maxCharacterLandVelocity;

		// Token: 0x04000198 RID: 408
		private double _strengthMultiplier = 1.0;

		// Token: 0x020000D5 RID: 213
		private class Sol : Enemy
		{
			// Token: 0x170000C6 RID: 198
			// (get) Token: 0x06000520 RID: 1312 RVA: 0x000204BB File Offset: 0x0001E6BB
			// (set) Token: 0x06000521 RID: 1313 RVA: 0x000204C3 File Offset: 0x0001E6C3
			public Vector2 Velocity { get; set; }

			// Token: 0x170000C7 RID: 199
			// (get) Token: 0x06000522 RID: 1314 RVA: 0x000204CC File Offset: 0x0001E6CC
			// (set) Token: 0x06000523 RID: 1315 RVA: 0x000204D4 File Offset: 0x0001E6D4
			public int Side { get; set; }

			// Token: 0x170000C8 RID: 200
			// (get) Token: 0x06000524 RID: 1316 RVA: 0x000204DD File Offset: 0x0001E6DD
			// (set) Token: 0x06000525 RID: 1317 RVA: 0x000204E5 File Offset: 0x0001E6E5
			public bool Flying { get; set; }

			// Token: 0x170000C9 RID: 201
			// (get) Token: 0x06000526 RID: 1318 RVA: 0x000204EE File Offset: 0x0001E6EE
			public HTZSeeSawInstance SeeSaw
			{
				get
				{
					return (HTZSeeSawInstance)base.ParentObject;
				}
			}

			// Token: 0x06000527 RID: 1319 RVA: 0x000204FC File Offset: 0x0001E6FC
			protected override void OnStart()
			{
				base.OnStart();
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -36, -36, 72, 72)
				};
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("SONICORCA/OBJECTS/SOL/ANIGROUP"), 1);
				base.ShadowInfo.MaxShadowOffset = new Vector2i(16, 16);
			}

			// Token: 0x06000528 RID: 1320 RVA: 0x00020564 File Offset: 0x0001E764
			protected override void OnUpdate()
			{
				if (base.Level.Player.Protagonist != null)
				{
					this._facingRight = (base.Level.Player.Protagonist.Position.X >= base.Position.X);
				}
				int num = this.SeeSaw._bias + 1;
				if (this.Side == 1)
				{
					num += 2;
				}
				int num2 = this.SeeSaw.Position.Y + 64 + HTZSeeSawInstance.Sol.SolRestYOffsets[num];
				if (!this.Flying)
				{
					base.Position = new Vector2i(base.Position.X, num2);
				}
				else
				{
					base.PositionPrecise += this.Velocity;
					this.Velocity += new Vector2(0.0, 0.875);
					if (this.Velocity.Y > 0.0 && base.Position.Y >= num2)
					{
						base.Position = new Vector2i(base.Position.X, num2);
						this.Flying = false;
						this.SeeSaw._bias = this.Side;
						this.SeeSaw.OnSolTouch(this.Side, this.Velocity.Y);
					}
				}
				this.SeeSaw._charactersOnLeftSide.Clear();
				this.SeeSaw._charactersOnMiddleSide.Clear();
				this.SeeSaw._charactersOnRightSide.Clear();
			}

			// Token: 0x06000529 RID: 1321 RVA: 0x00020708 File Offset: 0x0001E908
			protected override void OnAnimate()
			{
				base.OnAnimate();
				this._animation.Animate();
			}

			// Token: 0x0600052A RID: 1322 RVA: 0x0002071B File Offset: 0x0001E91B
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				renderer.GetObjectRenderer().Render(this._animation, this._facingRight, false);
			}

			// Token: 0x040005B9 RID: 1465
			private const int AnimationSol = 1;

			// Token: 0x040005BA RID: 1466
			private const double Gravity = 0.875;

			// Token: 0x040005BB RID: 1467
			private static readonly IReadOnlyList<int> SolRestYOffsets = new int[]
			{
				-32,
				-112,
				-188,
				-112,
				-32
			};

			// Token: 0x040005BC RID: 1468
			private AnimationInstance _animation;

			// Token: 0x040005BD RID: 1469
			private bool _facingRight;
		}
	}
}
