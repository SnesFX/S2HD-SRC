using System;

namespace OpenTK.Input
{
	// Token: 0x02000B5B RID: 2907
	public struct MouseScroll : IEquatable<MouseScroll>
	{
		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06005B22 RID: 23330 RVA: 0x000F6AD8 File Offset: 0x000F4CD8
		// (set) Token: 0x06005B23 RID: 23331 RVA: 0x000F6AE0 File Offset: 0x000F4CE0
		public float X { get; internal set; }

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06005B24 RID: 23332 RVA: 0x000F6AEC File Offset: 0x000F4CEC
		// (set) Token: 0x06005B25 RID: 23333 RVA: 0x000F6AF4 File Offset: 0x000F4CF4
		public float Y { get; internal set; }

		// Token: 0x06005B26 RID: 23334 RVA: 0x000F6B00 File Offset: 0x000F4D00
		public static bool operator ==(MouseScroll left, MouseScroll right)
		{
			return left.Equals(right);
		}

		// Token: 0x06005B27 RID: 23335 RVA: 0x000F6B0C File Offset: 0x000F4D0C
		public static bool operator !=(MouseScroll left, MouseScroll right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06005B28 RID: 23336 RVA: 0x000F6B1C File Offset: 0x000F4D1C
		public override string ToString()
		{
			return string.Format("[X={0:0.00}, Y={1:0.00}]", this.X, this.Y);
		}

		// Token: 0x06005B29 RID: 23337 RVA: 0x000F6B40 File Offset: 0x000F4D40
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode();
		}

		// Token: 0x06005B2A RID: 23338 RVA: 0x000F6B6C File Offset: 0x000F4D6C
		public override bool Equals(object obj)
		{
			return obj is MouseScroll && this.Equals((MouseScroll)obj);
		}

		// Token: 0x06005B2B RID: 23339 RVA: 0x000F6B84 File Offset: 0x000F4D84
		public bool Equals(MouseScroll other)
		{
			return this.X == other.X && this.Y == other.Y;
		}
	}
}
