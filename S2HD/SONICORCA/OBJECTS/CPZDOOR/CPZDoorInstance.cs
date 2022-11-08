using System;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZDOOR
{
	// Token: 0x02000073 RID: 115
	public class CPZDoorInstance : ActiveObject
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00010F0F File Offset: 0x0000F10F
		// (set) Token: 0x0600024B RID: 587 RVA: 0x00010F17 File Offset: 0x0000F117
		[StateVariable]
		private int Direction
		{
			get
			{
				return this._direction;
			}
			set
			{
				this._direction = value;
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00010F20 File Offset: 0x0000F120
		public CPZDoorInstance()
		{
			base.DesignBounds = new Rectanglei(-32, -128, 64, 256);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00010F48 File Offset: 0x0000F148
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._initialPosition = base.Position;
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-32, -128, 64, 256), uint.MaxValue, (CollisionFlags)0);
			CollisionVector[] collisionVectors = base.CollisionVectors;
			for (int i = 0; i < collisionVectors.Length; i++)
			{
				collisionVectors[i].Flags |= CollisionFlags.Solid;
			}
			base.Priority = -128;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00010FD4 File Offset: 0x0000F1D4
		protected override void OnUpdate()
		{
			this._closed = (this._barrierOffset == 0);
			this._barrierOffset = (base.Level.ObjectManager.Characters.Any((ICharacter x) => this.CheckCharacter(x)) ? Math.Max(this._barrierOffset - 32, -256) : Math.Min(this._barrierOffset + 32, 0));
			base.Position = this._initialPosition + new Vector2i(0, this._barrierOffset);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0001105C File Offset: 0x0000F25C
		private bool CheckCharacter(ICharacter character)
		{
			if (!character.ShouldReactToLevel)
			{
				return false;
			}
			int num = this._closed ? 0 : (character.CollisionRadius.X + 32 + 4);
			int num2 = 1080;
			Rectanglei rectanglei;
			if (this._direction == -1)
			{
				rectanglei = Rectanglei.FromLTRB(this._initialPosition.X - num, this._initialPosition.Y - num2, this._initialPosition.X + 2048, this._initialPosition.Y + num2);
			}
			else
			{
				rectanglei = Rectanglei.FromLTRB(this._initialPosition.X - 2048, this._initialPosition.Y - num2, this._initialPosition.X + num, this._initialPosition.Y + num2);
			}
			return rectanglei.Contains(character.Position);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0001112C File Offset: 0x0000F32C
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00011139 File Offset: 0x0000F339
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x04000296 RID: 662
		private const int BarrierMoveSpeed = 32;

		// Token: 0x04000297 RID: 663
		private AnimationInstance _animation;

		// Token: 0x04000298 RID: 664
		private Vector2i _initialPosition;

		// Token: 0x04000299 RID: 665
		private int _barrierOffset;

		// Token: 0x0400029A RID: 666
		private bool _closed;

		// Token: 0x0400029B RID: 667
		private int _direction = 1;
	}
}
