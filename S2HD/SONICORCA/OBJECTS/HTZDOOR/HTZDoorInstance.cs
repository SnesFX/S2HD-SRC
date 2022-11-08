using System;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZDOOR
{
	// Token: 0x02000054 RID: 84
	public class HTZDoorInstance : ActiveObject
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060001AF RID: 431 RVA: 0x0000CAFC File Offset: 0x0000ACFC
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x0000CB04 File Offset: 0x0000AD04
		[StateVariable]
		private DoorDirection Direction
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

		// Token: 0x060001B1 RID: 433 RVA: 0x0000CB0D File Offset: 0x0000AD0D
		public HTZDoorInstance()
		{
			base.DesignBounds = new Rectanglei(-32, -128, 64, 320);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000CB34 File Offset: 0x0000AD34
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._initialPosition = base.Position;
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-32, -128, 64, 320), uint.MaxValue, (CollisionFlags)0);
			CollisionVector[] collisionVectors = base.CollisionVectors;
			for (int i = 0; i < collisionVectors.Length; i++)
			{
				collisionVectors[i].Flags |= CollisionFlags.Solid;
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
		protected override void OnUpdate()
		{
			this._closed = (this._barrierOffset == 0);
			this._barrierOffset = (base.Level.ObjectManager.Characters.Any((ICharacter x) => this.CheckCharacter(x)) ? Math.Max(this._barrierOffset - 32, -320) : Math.Min(this._barrierOffset + 32, 0));
			base.Position = this._initialPosition + new Vector2i(0, this._barrierOffset);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000CC40 File Offset: 0x0000AE40
		private bool CheckCharacter(ICharacter character)
		{
			if (!character.ShouldReactToLevel)
			{
				return false;
			}
			int num = this._closed ? 0 : (character.CollisionRadius.X + 4);
			int num2 = 1080;
			Rectanglei rectanglei;
			if (this._direction == DoorDirection.Left)
			{
				rectanglei = Rectanglei.FromLTRB(this._initialPosition.X - num, this._initialPosition.Y - num2, this._initialPosition.X + 2048, this._initialPosition.Y + num2);
			}
			else
			{
				rectanglei = Rectanglei.FromLTRB(this._initialPosition.X - 2048, this._initialPosition.Y - num2, this._initialPosition.X + num, this._initialPosition.Y + num2);
			}
			return rectanglei.Contains(character.Position);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000CD0D File Offset: 0x0000AF0D
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000CD1C File Offset: 0x0000AF1C
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			using (objectRenderer.BeginMatixState())
			{
				if (this._direction == DoorDirection.Left)
				{
					objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
				}
				objectRenderer.Render(this._animation, false, false);
			}
		}

		// Token: 0x040001B8 RID: 440
		private const int BarrierMoveSpeed = 32;

		// Token: 0x040001B9 RID: 441
		private AnimationInstance _animation;

		// Token: 0x040001BA RID: 442
		private Vector2i _initialPosition;

		// Token: 0x040001BB RID: 443
		private int _barrierOffset;

		// Token: 0x040001BC RID: 444
		private bool _closed;

		// Token: 0x040001BD RID: 445
		private DoorDirection _direction = DoorDirection.Right;
	}
}
