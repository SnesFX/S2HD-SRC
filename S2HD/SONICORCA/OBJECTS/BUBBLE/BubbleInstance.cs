using System;
using System.Collections.Generic;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.BUBBLE
{
	// Token: 0x02000064 RID: 100
	public class BubbleInstance : ActiveObject
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000FF57 File Offset: 0x0000E157
		// (set) Token: 0x06000212 RID: 530 RVA: 0x0000FF5F File Offset: 0x0000E15F
		[StateVariable]
		private BubbleInstance.SizeType Size
		{
			get
			{
				return this._size;
			}
			set
			{
				this._size = value;
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000FF68 File Offset: 0x0000E168
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.Priority = 1024;
			this._velocity = new Vector2(0.0, -0.53125);
			this._angle = base.Level.Random.NextDouble() * 6.283185307179586;
			this._maxSize = BubbleInstance.SizeRadius[(int)this._size];
			if (this._size != BubbleInstance.SizeType.Large)
			{
				this._maxSize += base.Level.Random.Next(-4, 4);
				return;
			}
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -28, -28, 56, 56)
			};
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00010040 File Offset: 0x0000E240
		protected override void OnUpdate()
		{
			this._angle = MathX.WrapRadians(this._angle + 0.04908738521234052);
			this._velocity.X = Math.Sin(this._angle) * 0.5;
			base.PositionPrecise += this._velocity;
			this._size = (BubbleInstance.SizeType)Math.Min((int)(this._size + 1), this._maxSize);
			if (!base.Level.WaterManager.IsUnderwater(base.Position))
			{
				base.FinishForever();
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000100D8 File Offset: 0x0000E2D8
		protected override void OnCollision(CollisionEvent e)
		{
			if (this._size != BubbleInstance.SizeType.Large || e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			character.Velocity = default(Vector2);
			character.InhaleOxygen();
			base.FinishForever();
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00010127 File Offset: 0x0000E327
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00010134 File Offset: 0x0000E334
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			double num = (double)this._size / (double)this._animation.CurrentTexture.Width;
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			using (objectRenderer.BeginMatixState())
			{
				objectRenderer.ModelMatrix *= Matrix4.CreateScale(num, num, 1.0);
				objectRenderer.Render(this._animation, false, false);
			}
		}

		// Token: 0x04000276 RID: 630
		private static IReadOnlyList<int> SizeRadius = new int[]
		{
			16,
			38,
			112
		};

		// Token: 0x04000277 RID: 631
		private AnimationInstance _animation;

		// Token: 0x04000278 RID: 632
		private Vector2 _velocity;

		// Token: 0x04000279 RID: 633
		private BubbleInstance.SizeType _size;

		// Token: 0x0400027A RID: 634
		private double _angle;

		// Token: 0x0400027B RID: 635
		private int _maxSize;

		// Token: 0x020000E7 RID: 231
		private enum SizeType
		{
			// Token: 0x0400061C RID: 1564
			Small,
			// Token: 0x0400061D RID: 1565
			Medium,
			// Token: 0x0400061E RID: 1566
			Large
		}
	}
}
