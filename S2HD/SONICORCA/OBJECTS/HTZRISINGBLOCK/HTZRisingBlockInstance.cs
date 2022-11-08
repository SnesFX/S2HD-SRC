using System;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZRISINGBLOCK
{
	// Token: 0x0200008D RID: 141
	public class HTZRisingBlockInstance : ActiveObject
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060002DC RID: 732 RVA: 0x000151E4 File Offset: 0x000133E4
		// (set) Token: 0x060002DD RID: 733 RVA: 0x000151EC File Offset: 0x000133EC
		public HTZRisingBlockInstance.BlockType BlockKind
		{
			get
			{
				return this._blockKind;
			}
			set
			{
				this._blockKind = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060002DE RID: 734 RVA: 0x000151F5 File Offset: 0x000133F5
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00015200 File Offset: 0x00013400
		public Vector2i Size
		{
			get
			{
				return this._size;
			}
			set
			{
				this._size = value;
				base.DesignBounds = new Rectanglei(-(this._size.X / 2), -(this._size.Y / 2), this._size.X, this._size.Y);
				base.CollisionVectors = this.CalculateCollisionVectors();
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00015260 File Offset: 0x00013460
		public HTZRisingBlockInstance()
		{
			base.DesignBounds = new Rectanglei(-(this._size.X / 2), -(this._size.Y / 2), this._size.X, this._size.Y);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x000152C8 File Offset: 0x000134C8
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._animation.Index = (int)this.BlockKind;
			base.CollisionVectors = this.CalculateCollisionVectors();
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00015314 File Offset: 0x00013514
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00015324 File Offset: 0x00013524
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (this.BlockKind == HTZRisingBlockInstance.BlockType.FloorB)
			{
				ICharacter character = base.Level.ObjectManager.Characters.FirstOrDefault<ICharacter>();
				if (character != null && character.Position.Y > 3400)
				{
					return;
				}
			}
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0001537C File Offset: 0x0001357C
		private CollisionVector[] CalculateCollisionVectors()
		{
			CollisionVector[] array;
			if (this.BlockKind == HTZRisingBlockInstance.BlockType.FloorB)
			{
				Vector2i b = new Vector2i(this._size.X / 2, this._size.Y / 2);
				Vector2i vector2i = new Vector2i(0, 58) - b;
				Vector2i vector2i2 = new Vector2i(3072, 838) - b;
				Vector2i vector2i3 = new Vector2i(0, this.Size.Y / 2) - b;
				Vector2i vector2i4 = new Vector2i(this.Size.X, this.Size.Y / 2) - b;
				array = new CollisionVector[]
				{
					new CollisionVector(this, vector2i3, vector2i, uint.MaxValue, CollisionFlags.Solid),
					new CollisionVector(this, vector2i, vector2i2, uint.MaxValue, CollisionFlags.Solid),
					new CollisionVector(this, vector2i2, vector2i4, uint.MaxValue, CollisionFlags.Solid),
					new CollisionVector(this, vector2i4, vector2i3, uint.MaxValue, CollisionFlags.Solid)
				};
			}
			else
			{
				array = CollisionVector.FromRectangle(this, new Rectanglei(-(this._size.X / 2), -(this._size.Y / 2), this._size.X, this._size.Y), uint.MaxValue, CollisionFlags.Solid);
			}
			array[1].Flags |= CollisionFlags.Conveyor;
			array[3].Flags |= CollisionFlags.Conveyor;
			return array;
		}

		// Token: 0x040003AE RID: 942
		private AnimationInstance _animation;

		// Token: 0x040003AF RID: 943
		private Vector2i _size = new Vector2i(2048, 512);

		// Token: 0x040003B0 RID: 944
		private HTZRisingBlockInstance.BlockType _blockKind;

		// Token: 0x02000100 RID: 256
		public enum BlockType
		{
			// Token: 0x0400068F RID: 1679
			FloorA,
			// Token: 0x04000690 RID: 1680
			FloorB,
			// Token: 0x04000691 RID: 1681
			CeilingA
		}
	}
}
