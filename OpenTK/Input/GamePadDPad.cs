using System;

namespace OpenTK.Input
{
	// Token: 0x02000AFA RID: 2810
	public struct GamePadDPad : IEquatable<GamePadDPad>
	{
		// Token: 0x06005944 RID: 22852 RVA: 0x000F2904 File Offset: 0x000F0B04
		internal GamePadDPad(Buttons state)
		{
			this.buttons = (GamePadDPad.DPadButtons)(state & (Buttons.DPadUp | Buttons.DPadDown | Buttons.DPadLeft | Buttons.DPadRight));
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06005945 RID: 22853 RVA: 0x000F2914 File Offset: 0x000F0B14
		public ButtonState Up
		{
			get
			{
				if (!this.IsUp)
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06005946 RID: 22854 RVA: 0x000F2924 File Offset: 0x000F0B24
		public ButtonState Down
		{
			get
			{
				if (!this.IsDown)
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06005947 RID: 22855 RVA: 0x000F2934 File Offset: 0x000F0B34
		public ButtonState Left
		{
			get
			{
				if (!this.IsLeft)
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06005948 RID: 22856 RVA: 0x000F2944 File Offset: 0x000F0B44
		public ButtonState Right
		{
			get
			{
				if (!this.IsRight)
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06005949 RID: 22857 RVA: 0x000F2954 File Offset: 0x000F0B54
		// (set) Token: 0x0600594A RID: 22858 RVA: 0x000F2968 File Offset: 0x000F0B68
		public bool IsUp
		{
			get
			{
				return (byte)(this.buttons & GamePadDPad.DPadButtons.Up) != 0;
			}
			internal set
			{
				this.SetButton(GamePadDPad.DPadButtons.Up, value);
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x0600594B RID: 22859 RVA: 0x000F2974 File Offset: 0x000F0B74
		// (set) Token: 0x0600594C RID: 22860 RVA: 0x000F2988 File Offset: 0x000F0B88
		public bool IsDown
		{
			get
			{
				return (byte)(this.buttons & GamePadDPad.DPadButtons.Down) != 0;
			}
			internal set
			{
				this.SetButton(GamePadDPad.DPadButtons.Down, value);
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x0600594D RID: 22861 RVA: 0x000F2994 File Offset: 0x000F0B94
		// (set) Token: 0x0600594E RID: 22862 RVA: 0x000F29A8 File Offset: 0x000F0BA8
		public bool IsLeft
		{
			get
			{
				return (byte)(this.buttons & GamePadDPad.DPadButtons.Left) != 0;
			}
			internal set
			{
				this.SetButton(GamePadDPad.DPadButtons.Left, value);
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x0600594F RID: 22863 RVA: 0x000F29B4 File Offset: 0x000F0BB4
		// (set) Token: 0x06005950 RID: 22864 RVA: 0x000F29C8 File Offset: 0x000F0BC8
		public bool IsRight
		{
			get
			{
				return (byte)(this.buttons & GamePadDPad.DPadButtons.Right) != 0;
			}
			internal set
			{
				this.SetButton(GamePadDPad.DPadButtons.Right, value);
			}
		}

		// Token: 0x06005951 RID: 22865 RVA: 0x000F29D4 File Offset: 0x000F0BD4
		public static bool operator ==(GamePadDPad left, GamePadDPad right)
		{
			return left.Equals(right);
		}

		// Token: 0x06005952 RID: 22866 RVA: 0x000F29E0 File Offset: 0x000F0BE0
		public static bool operator !=(GamePadDPad left, GamePadDPad right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06005953 RID: 22867 RVA: 0x000F29F0 File Offset: 0x000F0BF0
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

		// Token: 0x06005954 RID: 22868 RVA: 0x000F2A6C File Offset: 0x000F0C6C
		public override int GetHashCode()
		{
			return this.buttons.GetHashCode();
		}

		// Token: 0x06005955 RID: 22869 RVA: 0x000F2A80 File Offset: 0x000F0C80
		public override bool Equals(object obj)
		{
			return obj is GamePadDPad && this.Equals((GamePadDPad)obj);
		}

		// Token: 0x06005956 RID: 22870 RVA: 0x000F2A98 File Offset: 0x000F0C98
		private void SetButton(GamePadDPad.DPadButtons button, bool value)
		{
			if (value)
			{
				this.buttons |= button;
				return;
			}
			this.buttons &= ~button;
		}

		// Token: 0x06005957 RID: 22871 RVA: 0x000F2AC0 File Offset: 0x000F0CC0
		public bool Equals(GamePadDPad other)
		{
			return this.buttons == other.buttons;
		}

		// Token: 0x0400B495 RID: 46229
		private GamePadDPad.DPadButtons buttons;

		// Token: 0x02000AFB RID: 2811
		[Flags]
		private enum DPadButtons : byte
		{
			// Token: 0x0400B497 RID: 46231
			Up = 1,
			// Token: 0x0400B498 RID: 46232
			Down = 2,
			// Token: 0x0400B499 RID: 46233
			Left = 4,
			// Token: 0x0400B49A RID: 46234
			Right = 8
		}
	}
}
