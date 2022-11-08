using System;

namespace OpenTK.Input
{
	// Token: 0x02000007 RID: 7
	public struct GamePadTriggers : IEquatable<GamePadTriggers>
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002780 File Offset: 0x00000980
		internal GamePadTriggers(byte left, byte right)
		{
			this.left = left;
			this.right = right;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002790 File Offset: 0x00000990
		public float Left
		{
			get
			{
				return (float)this.left * 0.003921569f;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000027A0 File Offset: 0x000009A0
		public float Right
		{
			get
			{
				return (float)this.right * 0.003921569f;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000027B0 File Offset: 0x000009B0
		public static bool operator ==(GamePadTriggers left, GamePadTriggers right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000027BC File Offset: 0x000009BC
		public static bool operator !=(GamePadTriggers left, GamePadTriggers right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000027CC File Offset: 0x000009CC
		public override string ToString()
		{
			return string.Format("{{Left: {0:f2}; Right: {1:f2}}}", this.Left, this.Right);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000027F0 File Offset: 0x000009F0
		public override int GetHashCode()
		{
			return this.left.GetHashCode() ^ this.right.GetHashCode();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000280C File Offset: 0x00000A0C
		public override bool Equals(object obj)
		{
			return obj is GamePadTriggers && this.Equals((GamePadTriggers)obj);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002824 File Offset: 0x00000A24
		public bool Equals(GamePadTriggers other)
		{
			return this.left == other.left && this.right == other.right;
		}

		// Token: 0x0400001D RID: 29
		private const float ConversionFactor = 0.003921569f;

		// Token: 0x0400001E RID: 30
		private byte left;

		// Token: 0x0400001F RID: 31
		private byte right;
	}
}
