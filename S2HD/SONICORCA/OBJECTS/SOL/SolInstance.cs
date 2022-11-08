using System;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.SOL
{
	// Token: 0x02000060 RID: 96
	public class SolInstance : Badnik
	{
		// Token: 0x06000203 RID: 515 RVA: 0x0000FBE7 File Offset: 0x0000DDE7
		public SolInstance()
		{
			base.DesignBounds = new Rectanglei(-36, -36, 72, 72);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000FC04 File Offset: 0x0000DE04
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -36, -36, 72, 72)
			};
			this._waitingForCharacter = true;
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				SolInstance.Fireball fireball = base.Level.ObjectManager.AddSubObject<SolInstance.Fireball>(this);
				fireball.Angle = num;
				fireball.UpdateOrbitPosition();
				num += 64;
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000FC8E File Offset: 0x0000DE8E
		protected override void OnStop()
		{
			base.OnStop();
			if (!this._waitingForCharacter)
			{
				base.FinishForever();
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000FCA4 File Offset: 0x0000DEA4
		protected override void OnUpdate()
		{
			base.OnUpdate();
			base.Position += new Vector2i(-1, 0);
			if (this._waitingForCharacter && this.IsCharacterCloseEnough(base.Level.Player.Protagonist))
			{
				this._waitingForCharacter = false;
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000FCF8 File Offset: 0x0000DEF8
		private bool IsCharacterCloseEnough(ICharacter character)
		{
			if (character.IsDebug)
			{
				return false;
			}
			Vector2i vector2i = character.Position - base.Position;
			vector2i.X = Math.Abs(vector2i.X);
			vector2i.Y = Math.Abs(vector2i.Y);
			return vector2i.X < 640 && vector2i.Y < 320;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0000FD65 File Offset: 0x0000DF65
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000FD72 File Offset: 0x0000DF72
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x0400026F RID: 623
		private const int AnimationSol = 0;

		// Token: 0x04000270 RID: 624
		private const int AnimationFireball = 2;

		// Token: 0x04000271 RID: 625
		private AnimationInstance _animation;

		// Token: 0x04000272 RID: 626
		private bool _waitingForCharacter;

		// Token: 0x020000E6 RID: 230
		private class Fireball : Enemy
		{
			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x060005BA RID: 1466 RVA: 0x0002263A File Offset: 0x0002083A
			// (set) Token: 0x060005BB RID: 1467 RVA: 0x00022642 File Offset: 0x00020842
			public int Angle { get; set; }

			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x060005BC RID: 1468 RVA: 0x0002264B File Offset: 0x0002084B
			public SolInstance Sol
			{
				get
				{
					return (SolInstance)base.ParentObject;
				}
			}

			// Token: 0x060005BD RID: 1469 RVA: 0x00022658 File Offset: 0x00020858
			protected override void OnStart()
			{
				base.OnStart();
				this._animation = new AnimationInstance(this.Sol._animation.AnimationGroup, 2);
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -8, -8, 16, 16)
				};
				base.LockLifetime = true;
			}

			// Token: 0x060005BE RID: 1470 RVA: 0x000226AC File Offset: 0x000208AC
			protected override void OnUpdate()
			{
				base.OnUpdate();
				if (this._fired)
				{
					base.PositionPrecise += new Vector2(-8.0, 0.0);
					return;
				}
				if (this.Sol.Finished)
				{
					base.Finish();
					return;
				}
				if (this.Sol._waitingForCharacter || this.Angle != 64)
				{
					this.Angle = MathX.Wrap(this.Angle + 1, 256, 0);
					this.UpdateOrbitPosition();
					return;
				}
				this._fired = true;
				base.LockLifetime = false;
			}

			// Token: 0x060005BF RID: 1471 RVA: 0x00022749 File Offset: 0x00020949
			protected override void OnUpdateEditor()
			{
				base.OnUpdateEditor();
				this.UpdateOrbitPosition();
			}

			// Token: 0x060005C0 RID: 1472 RVA: 0x00022758 File Offset: 0x00020958
			public void UpdateOrbitPosition()
			{
				double num = (double)this.Angle * 0.02454369260617026;
				base.PositionPrecise = this.Sol.PositionPrecise + new Vector2(64.0 * Math.Cos(num), 64.0 * Math.Sin(num));
			}

			// Token: 0x060005C1 RID: 1473 RVA: 0x000227B2 File Offset: 0x000209B2
			protected override void OnAnimate()
			{
				this._animation.Animate();
			}

			// Token: 0x060005C2 RID: 1474 RVA: 0x000227BF File Offset: 0x000209BF
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				objectRenderer.EmitsLight = true;
				objectRenderer.Render(this._animation, false, false);
			}

			// Token: 0x04000618 RID: 1560
			private AnimationInstance _animation;

			// Token: 0x04000619 RID: 1561
			private bool _fired;
		}
	}
}
