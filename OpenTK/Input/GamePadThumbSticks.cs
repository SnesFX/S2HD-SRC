using System;

namespace OpenTK.Input
{
	// Token: 0x02000006 RID: 6
	public struct GamePadThumbSticks : IEquatable<GamePadThumbSticks>
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002604 File Offset: 0x00000804
		internal GamePadThumbSticks(short left_x, short left_y, short right_x, short right_y)
		{
			this.left_x = left_x;
			this.left_y = left_y;
			this.right_x = right_x;
			this.right_y = right_y;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002624 File Offset: 0x00000824
		public Vector2 Left
		{
			get
			{
				return new Vector2((float)this.left_x * 3.051851E-05f, (float)this.left_y * 3.051851E-05f);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002648 File Offset: 0x00000848
		public Vector2 Right
		{
			get
			{
				return new Vector2((float)this.right_x * 3.051851E-05f, (float)this.right_y * 3.051851E-05f);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000266C File Offset: 0x0000086C
		public static bool operator ==(GamePadThumbSticks left, GamePadThumbSticks right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002678 File Offset: 0x00000878
		public static bool operator !=(GamePadThumbSticks left, GamePadThumbSticks right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002688 File Offset: 0x00000888
		public override string ToString()
		{
			return string.Format("{{Left: ({0:f4}; {1:f4}); Right: ({2:f4}; {3:f4})}}", new object[]
			{
				this.Left.X,
				this.Left.Y,
				this.Right.X,
				this.Right.Y
			});
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000026F4 File Offset: 0x000008F4
		public override int GetHashCode()
		{
			return this.left_x.GetHashCode() ^ this.left_y.GetHashCode() ^ this.right_x.GetHashCode() ^ this.right_y.GetHashCode();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002728 File Offset: 0x00000928
		public override bool Equals(object obj)
		{
			return obj is GamePadThumbSticks && this.Equals((GamePadThumbSticks)obj);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002740 File Offset: 0x00000940
		public bool Equals(GamePadThumbSticks other)
		{
			return this.left_x == other.left_x && this.left_y == other.left_y && this.right_x == other.right_x && this.right_y == other.right_y;
		}

		// Token: 0x04000018 RID: 24
		private const float ConversionFactor = 3.051851E-05f;

		// Token: 0x04000019 RID: 25
		private short left_x;

		// Token: 0x0400001A RID: 26
		private short left_y;

		// Token: 0x0400001B RID: 27
		private short right_x;

		// Token: 0x0400001C RID: 28
		private short right_y;
	}
}
