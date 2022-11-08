using System;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZBLOCK
{
	// Token: 0x02000079 RID: 121
	public class CPZBlockInstance : Platform
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00011A04 File Offset: 0x0000FC04
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00011A0C File Offset: 0x0000FC0C
		[StateVariable]
		private CPZBlockInstance.BlockType BlockKind
		{
			get
			{
				return this._blockType;
			}
			set
			{
				this._blockType = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00011A15 File Offset: 0x0000FC15
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00011A1D File Offset: 0x0000FC1D
		[StateVariable]
		private CPZBlockInstance.TurnDirection Direction
		{
			get
			{
				return this._turnDirection;
			}
			set
			{
				this._turnDirection = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00011A26 File Offset: 0x0000FC26
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00011A2E File Offset: 0x0000FC2E
		[StateVariable]
		private int Length
		{
			get
			{
				return this._movementLength;
			}
			set
			{
				this._movementLength = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00011A37 File Offset: 0x0000FC37
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00011A3F File Offset: 0x0000FC3F
		[StateVariable]
		private int InitialState
		{
			get
			{
				return this._initialState;
			}
			set
			{
				this._initialState = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00011A48 File Offset: 0x0000FC48
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00011A50 File Offset: 0x0000FC50
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

		// Token: 0x0600026D RID: 621 RVA: 0x00011A5C File Offset: 0x0000FC5C
		protected override void OnStart()
		{
			base.OnStart();
			if (this._blockType == CPZBlockInstance.BlockType.Single)
			{
				this._state0position = base.Position - this.GetStatePosition(this._initialState);
				base.DesignBounds = new Rectanglei(-64, -64, 128, 128);
			}
			else
			{
				this._state0position = base.Position;
				this._siblings = new CPZBlockInstance[3];
				for (int i = 0; i < 3; i++)
				{
					CPZBlockInstance cpzblockInstance = base.Level.ObjectManager.AddSubObject<CPZBlockInstance>(this);
					cpzblockInstance._blockType = CPZBlockInstance.BlockType.None;
					cpzblockInstance.Position = base.Position + new Vector2i((i + 1) * 128, 0);
					cpzblockInstance.LockLifetime = true;
					this._siblings[i] = cpzblockInstance;
				}
				if (this._flipX)
				{
					base.Move(384, 0);
					this._siblings[0].Move(128, 0);
					this._siblings[1].Move(-128, 0);
					this._siblings[2].Move(-384, 0);
				}
				base.DesignBounds = new Rectanglei(-64, -64, 512, 128);
			}
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-64, -64, 128, 128), uint.MaxValue, (CollisionFlags)0);
			base.CollisionVectors[0].Id = 0;
			base.CollisionVectors[1].Id = 1;
			base.CollisionVectors[2].Id = 2;
			base.CollisionVectors[3].Id = 3;
			base.CollisionVectors[1].Flags |= CollisionFlags.Conveyor;
			for (int j = 0; j < 4; j++)
			{
				base.CollisionVectors[j].Flags |= CollisionFlags.Solid;
				base.CollisionVectors[j].Flags |= CollisionFlags.NoBalance;
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00011C51 File Offset: 0x0000FE51
		protected override void OnUpdate()
		{
			if (base.ParentObject != null && base.ParentObject.Finished)
			{
				base.Finish();
				return;
			}
			base.OnUpdate();
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00011C78 File Offset: 0x0000FE78
		protected override void OnUpdateEditor()
		{
			if (base.ParentObject != null && base.ParentObject.Finished)
			{
				base.Finish();
				return;
			}
			if (this._siblings != null)
			{
				for (int i = 0; i < this._siblings.Length; i++)
				{
					this._siblings[i].Position = base.Position + new Vector2i((i + 1) * 128, 0);
				}
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00011CE4 File Offset: 0x0000FEE4
		protected override void OnUpdatePrepare()
		{
			if (base.ParentObject is CPZBlockInstance)
			{
				return;
			}
			Vector2 positionPrecise = base.PositionPrecise;
			Vector2[] array = new Vector2[this._siblings.Length];
			for (int i = 0; i < this._siblings.Length; i++)
			{
				array[i] = this._siblings[i].PositionPrecise;
			}
			this.UpdateMovement();
			for (int j = 0; j < this._siblings.Length; j++)
			{
				this._siblings[j]._nextPositionPrecise = this._siblings[j].PositionPrecise;
				this._siblings[j]._velocityBasedOnNextPosition = this._siblings[j]._nextPositionPrecise - array[j];
			}
			base._nextPositionPrecise = base.PositionPrecise;
			this._velocityBasedOnNextPosition = base._nextPositionPrecise - positionPrecise;
			base.PositionPrecise = positionPrecise;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00011DBC File Offset: 0x0000FFBC
		protected override void UpdateMovement()
		{
			CPZBlockInstance.BlockType blockType = this._blockType;
			if (blockType == CPZBlockInstance.BlockType.Single)
			{
				this.UpdateMovementSingle();
				return;
			}
			if (blockType != CPZBlockInstance.BlockType.Stairs)
			{
				return;
			}
			this.UpdateMovementStairs();
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00011DE8 File Offset: 0x0000FFE8
		private Vector2i GetStatePosition(int state)
		{
			switch (state)
			{
			default:
				return this._state0position + new Vector2i(0, 0);
			case 1:
				return this._state0position + new Vector2i(this._movementLength, 0);
			case 2:
				return this._state0position + new Vector2i(this._movementLength, this._movementLength);
			case 3:
				return this._state0position + new Vector2i(0, this._movementLength);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00011E6C File Offset: 0x0001006C
		private void UpdateMovementSingle()
		{
			int num = base.Level.Ticks % 720 / 180;
			int num2;
			int state;
			if (this._turnDirection == CPZBlockInstance.TurnDirection.Clockwise)
			{
				num2 = (this._initialState + num) % 4;
				state = (num2 + 1) % 4;
			}
			else
			{
				num2 = (this._initialState - num + 4) % 4;
				state = (num2 + 3) % 4;
			}
			Vector2i statePosition = this.GetStatePosition(num2);
			Vector2i statePosition2 = this.GetStatePosition(state);
			double num3 = (double)(base.Level.Ticks % 180) / 180.0;
			double t = 0.5 - Math.Cos(num3 * 3.141592653589793) / 2.0;
			base.PositionPrecise = new Vector2((statePosition.X == statePosition2.X) ? ((double)statePosition.X) : MathX.Lerp((double)statePosition.X, (double)statePosition2.X, t), (statePosition.Y == statePosition2.Y) ? ((double)statePosition.Y) : MathX.Lerp((double)statePosition.Y, (double)statePosition2.Y, t));
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00011F88 File Offset: 0x00010188
		private void UpdateMovementStairs()
		{
			if (!this._activated)
			{
				return;
			}
			int num = (this._turnDirection == CPZBlockInstance.TurnDirection.Up) ? -1 : 1;
			if (this._ticks < 30)
			{
				this._ticks++;
				return;
			}
			if (this._ticks > 158)
			{
				return;
			}
			double t = (double)(this._ticks - 30) / 128.0;
			Vector2 positionPrecise = base.PositionPrecise;
			positionPrecise.Y = MathX.Lerp((double)this._state0position.Y, (double)(this._state0position.Y + num * 128), t);
			base.PositionPrecise = positionPrecise;
			for (int i = 0; i < 3; i++)
			{
				positionPrecise = this._siblings[i].PositionPrecise;
				positionPrecise.Y = MathX.Lerp((double)this._state0position.Y, (double)(this._state0position.Y + num * ((i + 2) * 128)), t);
				this._siblings[i].PositionPrecise = positionPrecise;
			}
			this._ticks++;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0001208C File Offset: 0x0001028C
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.Id == 1 && e.ActiveObject.Type.Classification == ObjectClassification.Character)
			{
				this._activated = true;
				CPZBlockInstance cpzblockInstance = base.ParentObject as CPZBlockInstance;
				if (cpzblockInstance != null)
				{
					cpzblockInstance._activated = true;
				}
			}
			base.OnCollision(e);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000120D9 File Offset: 0x000102D9
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000120E6 File Offset: 0x000102E6
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x040002C0 RID: 704
		private AnimationInstance _animation;

		// Token: 0x040002C1 RID: 705
		private CPZBlockInstance.BlockType _blockType = CPZBlockInstance.BlockType.Single;

		// Token: 0x040002C2 RID: 706
		private int _movementLength = 384;

		// Token: 0x040002C3 RID: 707
		private bool _flipX;

		// Token: 0x040002C4 RID: 708
		private CPZBlockInstance.TurnDirection _turnDirection = CPZBlockInstance.TurnDirection.Clockwise;

		// Token: 0x040002C5 RID: 709
		private int _initialState;

		// Token: 0x040002C6 RID: 710
		private Vector2i _state0position;

		// Token: 0x040002C7 RID: 711
		private CPZBlockInstance[] _siblings = new CPZBlockInstance[0];

		// Token: 0x040002C8 RID: 712
		private bool _activated;

		// Token: 0x040002C9 RID: 713
		private int _ticks;

		// Token: 0x020000EB RID: 235
		private enum BlockType
		{
			// Token: 0x04000628 RID: 1576
			None,
			// Token: 0x04000629 RID: 1577
			Single,
			// Token: 0x0400062A RID: 1578
			Stairs
		}

		// Token: 0x020000EC RID: 236
		private enum TurnDirection
		{
			// Token: 0x0400062C RID: 1580
			Up,
			// Token: 0x0400062D RID: 1581
			Down,
			// Token: 0x0400062E RID: 1582
			Clockwise,
			// Token: 0x0400062F RID: 1583
			AntiClockwise
		}
	}
}
