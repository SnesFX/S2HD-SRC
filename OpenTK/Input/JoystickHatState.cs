using System;

namespace OpenTK.Input
{
	// Token: 0x02000B08 RID: 2824
	public struct JoystickHatState : IEquatable<JoystickHatState>
	{
		// Token: 0x06005994 RID: 22932 RVA: 0x000F3608 File Offset: 0x000F1808
		internal JoystickHatState(HatPosition pos)
		{
			this.position = pos;
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06005995 RID: 22933 RVA: 0x000F3614 File Offset: 0x000F1814
		public HatPosition Position
		{
			get
			{
				return this.position;
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06005996 RID: 22934 RVA: 0x000F361C File Offset: 0x000F181C
		public bool IsUp
		{
			get
			{
				return this.Position == HatPosition.Up || this.Position == HatPosition.UpLeft || this.Position == HatPosition.UpRight;
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06005997 RID: 22935 RVA: 0x000F363C File Offset: 0x000F183C
		public bool IsDown
		{
			get
			{
				return this.Position == HatPosition.Down || this.Position == HatPosition.DownLeft || this.Position == HatPosition.DownRight;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06005998 RID: 22936 RVA: 0x000F365C File Offset: 0x000F185C
		public bool IsLeft
		{
			get
			{
				return this.Position == HatPosition.Left || this.Position == HatPosition.UpLeft || this.Position == HatPosition.DownLeft;
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06005999 RID: 22937 RVA: 0x000F367C File Offset: 0x000F187C
		public bool IsRight
		{
			get
			{
				return this.Position == HatPosition.Right || this.Position == HatPosition.UpRight || this.Position == HatPosition.DownRight;
			}
		}

		// Token: 0x0600599A RID: 22938 RVA: 0x000F369C File Offset: 0x000F189C
		public override string ToString()
		{
			return string.Format("{{{0}{1}{2}{3}}}", new object[]
			{
				this.IsUp ? "U" : string.Empty,
				this.IsLeft ? "L" : string.Empty,
				this.IsDown ? "D" : string.Empty,
				this.IsRight ? "R" : string.Empty
			});
		}

		// Token: 0x0600599B RID: 22939 RVA: 0x000F3718 File Offset: 0x000F1918
		public override int GetHashCode()
		{
			return this.Position.GetHashCode();
		}

		// Token: 0x0600599C RID: 22940 RVA: 0x000F372C File Offset: 0x000F192C
		public override bool Equals(object obj)
		{
			return obj is JoystickHatState && this.Equals((JoystickHatState)obj);
		}

		// Token: 0x0600599D RID: 22941 RVA: 0x000F3744 File Offset: 0x000F1944
		public bool Equals(JoystickHatState other)
		{
			return this.Position == other.Position;
		}

		// Token: 0x0400B4DC RID: 46300
		private HatPosition position;
	}
}
