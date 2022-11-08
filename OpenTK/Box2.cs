using System;

namespace OpenTK
{
	// Token: 0x02000533 RID: 1331
	public struct Box2
	{
		// Token: 0x060040CF RID: 16591 RVA: 0x000AD954 File Offset: 0x000ABB54
		public Box2(Vector2 topLeft, Vector2 bottomRight)
		{
			this.Left = topLeft.X;
			this.Top = topLeft.Y;
			this.Right = bottomRight.X;
			this.Bottom = bottomRight.Y;
		}

		// Token: 0x060040D0 RID: 16592 RVA: 0x000AD98C File Offset: 0x000ABB8C
		public Box2(float left, float top, float right, float bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		// Token: 0x060040D1 RID: 16593 RVA: 0x000AD9AC File Offset: 0x000ABBAC
		public static Box2 FromTLRB(float top, float left, float right, float bottom)
		{
			return new Box2(left, top, right, bottom);
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060040D2 RID: 16594 RVA: 0x000AD9B8 File Offset: 0x000ABBB8
		public float Width
		{
			get
			{
				return Math.Abs(this.Right - this.Left);
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060040D3 RID: 16595 RVA: 0x000AD9D0 File Offset: 0x000ABBD0
		public float Height
		{
			get
			{
				return Math.Abs(this.Bottom - this.Top);
			}
		}

		// Token: 0x060040D4 RID: 16596 RVA: 0x000AD9E8 File Offset: 0x000ABBE8
		public override string ToString()
		{
			return string.Format("({0},{1})-({2},{3})", new object[]
			{
				this.Left,
				this.Top,
				this.Right,
				this.Bottom
			});
		}

		// Token: 0x04004E20 RID: 20000
		public float Left;

		// Token: 0x04004E21 RID: 20001
		public float Right;

		// Token: 0x04004E22 RID: 20002
		public float Top;

		// Token: 0x04004E23 RID: 20003
		public float Bottom;
	}
}
