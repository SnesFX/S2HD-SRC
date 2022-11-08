using System;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.SPINY
{
	// Token: 0x02000081 RID: 129
	public class SpinyInstance : Badnik
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00012A81 File Offset: 0x00010C81
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00012A89 File Offset: 0x00010C89
		[StateVariable]
		private bool Wall
		{
			get
			{
				return this._wall;
			}
			set
			{
				this._wall = value;
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00012A92 File Offset: 0x00010C92
		public SpinyInstance()
		{
			base.DesignBounds = new Rectanglei(-110, -63, 220, 126);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00012AB0 File Offset: 0x00010CB0
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._velocity = (this._wall ? new Vector2(0.0, -1.0) : new Vector2(-1.0, 0.0));
			this._status = SpinyInstance.StatusType.Moving;
			this._moveTimeLeft = 128;
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -16, -16, 32, 32)
			};
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00012B54 File Offset: 0x00010D54
		protected override void OnUpdate()
		{
			base.OnUpdate();
			SpinyInstance.StatusType status = this._status;
			if (status == SpinyInstance.StatusType.Moving)
			{
				this.UpdateMove();
				return;
			}
			if (status != SpinyInstance.StatusType.Firing)
			{
				return;
			}
			this.UpdateFiring();
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00012B84 File Offset: 0x00010D84
		private void UpdateMove()
		{
			if (this._holdFireTimeLeft > 0)
			{
				this._holdFireTimeLeft--;
			}
			else if (this.DetectPlayer())
			{
				this._holdFireTimeLeft = 40;
				this._status = SpinyInstance.StatusType.Firing;
				this._animation.Index = 2;
				return;
			}
			this._moveTimeLeft--;
			if (this._moveTimeLeft <= 0)
			{
				this._moveTimeLeft = 128;
				this._velocity.X = this._velocity.X * -1.0;
				this._velocity.Y = this._velocity.Y * -1.0;
			}
			base.PositionPrecise += this._velocity;
			this._animation.Index = (this._wall ? ((this._velocity.Y >= 0.0) ? 0 : 1) : ((this._velocity.X < 0.0) ? 0 : 1));
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00012C86 File Offset: 0x00010E86
		private void UpdateFiring()
		{
			this._holdFireTimeLeft--;
			if (this._holdFireTimeLeft < 0)
			{
				this._status = SpinyInstance.StatusType.Moving;
				this._holdFireTimeLeft = 64;
				return;
			}
			if (this._holdFireTimeLeft == 20)
			{
				this.FireProjectile();
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00012CC0 File Offset: 0x00010EC0
		private bool DetectPlayer()
		{
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				if (character.ShouldReactToLevel)
				{
					double num = (double)(character.Position.Y - base.Position.Y);
					if (num >= -540.0 && num <= 280.0 && (double)Math.Abs(character.Position.X - base.Position.X) < 384.0)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00012D8C File Offset: 0x00010F8C
		private void FireProjectile()
		{
			if (this._wall)
			{
				base.Level.ObjectManager.AddSubObject<SpinyInstance.PlasmaSphere>(this).Velocity = new Vector2(-12.0, 0.0);
				return;
			}
			int num = -1;
			double num2 = double.MaxValue;
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				double value = (double)(character.Position.X - base.Position.X);
				double num3 = Math.Abs(value);
				if (num3 < num2)
				{
					num2 = num3;
					num = Math.Sign(value);
				}
			}
			if (num == 0)
			{
				num = -1;
			}
			base.Level.ObjectManager.AddSubObject<SpinyInstance.PlasmaSphere>(this).Velocity = new Vector2((double)(4 * Math.Sign(num)), -12.0);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00012E88 File Offset: 0x00011088
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00012E98 File Offset: 0x00011098
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			if (this._wall)
			{
				using (objectRenderer.BeginMatixState())
				{
					objectRenderer.ModelMatrix = objectRenderer.ModelMatrix.RotateZ(MathX.ToRadians(-90.0));
					objectRenderer.Render(this._animation, false, false);
					return;
				}
			}
			objectRenderer.Render(this._animation, false, false);
		}

		// Token: 0x040002F0 RID: 752
		private const int AnimationMovingLeft = 0;

		// Token: 0x040002F1 RID: 753
		private const int AnimationMovingRight = 1;

		// Token: 0x040002F2 RID: 754
		private const int AnimationShooting = 2;

		// Token: 0x040002F3 RID: 755
		private const int AnimationPlasma = 3;

		// Token: 0x040002F4 RID: 756
		private bool _wall;

		// Token: 0x040002F5 RID: 757
		private AnimationInstance _animation;

		// Token: 0x040002F6 RID: 758
		private Vector2 _velocity;

		// Token: 0x040002F7 RID: 759
		private SpinyInstance.StatusType _status;

		// Token: 0x040002F8 RID: 760
		private int _moveTimeLeft;

		// Token: 0x040002F9 RID: 761
		private int _holdFireTimeLeft;

		// Token: 0x020000F1 RID: 241
		private enum StatusType
		{
			// Token: 0x04000647 RID: 1607
			Moving,
			// Token: 0x04000648 RID: 1608
			Firing
		}

		// Token: 0x020000F2 RID: 242
		private class PlasmaSphere : Enemy
		{
			// Token: 0x170000EF RID: 239
			// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00023884 File Offset: 0x00021A84
			// (set) Token: 0x060005E7 RID: 1511 RVA: 0x0002388C File Offset: 0x00021A8C
			public int Direction { get; set; }

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00023895 File Offset: 0x00021A95
			// (set) Token: 0x060005E9 RID: 1513 RVA: 0x0002389D File Offset: 0x00021A9D
			public Vector2 Velocity { get; set; }

			// Token: 0x060005EA RID: 1514 RVA: 0x000238A8 File Offset: 0x00021AA8
			protected override void OnStart()
			{
				base.OnStart();
				this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 3);
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -8, -8, 16, 16)
				};
			}

			// Token: 0x060005EB RID: 1515 RVA: 0x000238FC File Offset: 0x00021AFC
			protected override void OnUpdate()
			{
				base.OnUpdate();
				this.Velocity += new Vector2(0.0, 0.5);
				base.PositionPrecise += this.Velocity;
				this._ticks++;
			}

			// Token: 0x060005EC RID: 1516 RVA: 0x0002395C File Offset: 0x00021B5C
			protected override void OnAnimate()
			{
				this._animation.Animate();
			}

			// Token: 0x060005ED RID: 1517 RVA: 0x00023969 File Offset: 0x00021B69
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				if (this._ticks < 3)
				{
					return;
				}
				renderer.GetObjectRenderer().Render(this._animation, false, false);
			}

			// Token: 0x04000649 RID: 1609
			private AnimationInstance _animation;

			// Token: 0x0400064A RID: 1610
			private int _ticks;
		}
	}
}
