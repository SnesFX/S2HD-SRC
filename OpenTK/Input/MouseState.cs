using System;

namespace OpenTK.Input
{
	// Token: 0x02000526 RID: 1318
	public struct MouseState : IEquatable<MouseState>
	{
		// Token: 0x170002A7 RID: 679
		public bool this[MouseButton button]
		{
			get
			{
				return this.IsButtonDown(button);
			}
			internal set
			{
				if (value)
				{
					this.EnableBit((int)button);
					return;
				}
				this.DisableBit((int)button);
			}
		}

		// Token: 0x06003DBB RID: 15803 RVA: 0x000A227C File Offset: 0x000A047C
		public bool IsButtonDown(MouseButton button)
		{
			return this.ReadBit((int)button);
		}

		// Token: 0x06003DBC RID: 15804 RVA: 0x000A2288 File Offset: 0x000A0488
		public bool IsButtonUp(MouseButton button)
		{
			return !this.ReadBit((int)button);
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06003DBD RID: 15805 RVA: 0x000A2294 File Offset: 0x000A0494
		public int Wheel
		{
			get
			{
				return (int)Math.Round((double)this.scroll.Y, MidpointRounding.AwayFromZero);
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06003DBE RID: 15806 RVA: 0x000A22AC File Offset: 0x000A04AC
		public float WheelPrecise
		{
			get
			{
				return this.scroll.Y;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06003DBF RID: 15807 RVA: 0x000A22BC File Offset: 0x000A04BC
		public MouseScroll Scroll
		{
			get
			{
				return this.scroll;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06003DC0 RID: 15808 RVA: 0x000A22C4 File Offset: 0x000A04C4
		// (set) Token: 0x06003DC1 RID: 15809 RVA: 0x000A22D8 File Offset: 0x000A04D8
		public int X
		{
			get
			{
				return (int)Math.Round((double)this.position.X);
			}
			internal set
			{
				this.position.X = (float)value;
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06003DC2 RID: 15810 RVA: 0x000A22E8 File Offset: 0x000A04E8
		// (set) Token: 0x06003DC3 RID: 15811 RVA: 0x000A22FC File Offset: 0x000A04FC
		public int Y
		{
			get
			{
				return (int)Math.Round((double)this.position.Y);
			}
			internal set
			{
				this.position.Y = (float)value;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06003DC4 RID: 15812 RVA: 0x000A230C File Offset: 0x000A050C
		public ButtonState LeftButton
		{
			get
			{
				if (!this.IsButtonDown(MouseButton.Left))
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06003DC5 RID: 15813 RVA: 0x000A231C File Offset: 0x000A051C
		public ButtonState MiddleButton
		{
			get
			{
				if (!this.IsButtonDown(MouseButton.Middle))
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06003DC6 RID: 15814 RVA: 0x000A232C File Offset: 0x000A052C
		public ButtonState RightButton
		{
			get
			{
				if (!this.IsButtonDown(MouseButton.Right))
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06003DC7 RID: 15815 RVA: 0x000A233C File Offset: 0x000A053C
		public ButtonState XButton1
		{
			get
			{
				if (!this.IsButtonDown(MouseButton.Button1))
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06003DC8 RID: 15816 RVA: 0x000A234C File Offset: 0x000A054C
		public ButtonState XButton2
		{
			get
			{
				if (!this.IsButtonDown(MouseButton.Button2))
				{
					return ButtonState.Released;
				}
				return ButtonState.Pressed;
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06003DC9 RID: 15817 RVA: 0x000A235C File Offset: 0x000A055C
		public int ScrollWheelValue
		{
			get
			{
				return this.Wheel;
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06003DCA RID: 15818 RVA: 0x000A2364 File Offset: 0x000A0564
		// (set) Token: 0x06003DCB RID: 15819 RVA: 0x000A236C File Offset: 0x000A056C
		public bool IsConnected
		{
			get
			{
				return this.is_connected;
			}
			internal set
			{
				this.is_connected = value;
			}
		}

		// Token: 0x06003DCC RID: 15820 RVA: 0x000A2378 File Offset: 0x000A0578
		public static bool operator ==(MouseState left, MouseState right)
		{
			return left.Equals(right);
		}

		// Token: 0x06003DCD RID: 15821 RVA: 0x000A2384 File Offset: 0x000A0584
		public static bool operator !=(MouseState left, MouseState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06003DCE RID: 15822 RVA: 0x000A2394 File Offset: 0x000A0594
		public override bool Equals(object obj)
		{
			return obj is MouseState && this == (MouseState)obj;
		}

		// Token: 0x06003DCF RID: 15823 RVA: 0x000A23B4 File Offset: 0x000A05B4
		public override int GetHashCode()
		{
			return this.buttons.GetHashCode() ^ this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.scroll.GetHashCode();
		}

		// Token: 0x06003DD0 RID: 15824 RVA: 0x000A23FC File Offset: 0x000A05FC
		public override string ToString()
		{
			string text = Convert.ToString((int)this.buttons, 2).PadLeft(10, '0');
			return string.Format("[X={0}, Y={1}, Scroll={2}, Buttons={3}, IsConnected={4}]", new object[]
			{
				this.X,
				this.Y,
				this.Scroll,
				text,
				this.IsConnected
			});
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06003DD1 RID: 15825 RVA: 0x000A2470 File Offset: 0x000A0670
		// (set) Token: 0x06003DD2 RID: 15826 RVA: 0x000A2478 File Offset: 0x000A0678
		internal Vector2 Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}

		// Token: 0x06003DD3 RID: 15827 RVA: 0x000A2484 File Offset: 0x000A0684
		internal bool ReadBit(int offset)
		{
			MouseState.ValidateOffset(offset);
			return ((int)this.buttons & 1 << offset) != 0;
		}

		// Token: 0x06003DD4 RID: 15828 RVA: 0x000A24A0 File Offset: 0x000A06A0
		internal void EnableBit(int offset)
		{
			MouseState.ValidateOffset(offset);
			this.buttons |= (ushort)(1 << offset);
		}

		// Token: 0x06003DD5 RID: 15829 RVA: 0x000A24C0 File Offset: 0x000A06C0
		internal void DisableBit(int offset)
		{
			MouseState.ValidateOffset(offset);
			this.buttons &= (ushort)(~(ushort)(1 << offset));
		}

		// Token: 0x06003DD6 RID: 15830 RVA: 0x000A24E0 File Offset: 0x000A06E0
		internal void MergeBits(MouseState other)
		{
			this.buttons |= other.buttons;
			this.SetScrollRelative(other.scroll.X, other.scroll.Y);
			this.X += other.X;
			this.Y += other.Y;
			this.IsConnected |= other.IsConnected;
		}

		// Token: 0x06003DD7 RID: 15831 RVA: 0x000A255C File Offset: 0x000A075C
		internal void SetIsConnected(bool value)
		{
			this.IsConnected = value;
		}

		// Token: 0x06003DD8 RID: 15832 RVA: 0x000A2568 File Offset: 0x000A0768
		internal void SetScrollAbsolute(float x, float y)
		{
			this.scroll.X = x;
			this.scroll.Y = y;
		}

		// Token: 0x06003DD9 RID: 15833 RVA: 0x000A2584 File Offset: 0x000A0784
		internal void SetScrollRelative(float x, float y)
		{
			this.scroll.X = this.scroll.X + x;
			this.scroll.Y = this.scroll.Y + y;
		}

		// Token: 0x06003DDA RID: 15834 RVA: 0x000A25AC File Offset: 0x000A07AC
		private static void ValidateOffset(int offset)
		{
			if (offset < 0 || offset >= 16)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
		}

		// Token: 0x06003DDB RID: 15835 RVA: 0x000A25C4 File Offset: 0x000A07C4
		public bool Equals(MouseState other)
		{
			return this.buttons == other.buttons && this.X == other.X && this.Y == other.Y && this.Scroll == other.Scroll;
		}

		// Token: 0x04004DD2 RID: 19922
		internal const int MaxButtons = 16;

		// Token: 0x04004DD3 RID: 19923
		private Vector2 position;

		// Token: 0x04004DD4 RID: 19924
		private MouseScroll scroll;

		// Token: 0x04004DD5 RID: 19925
		private ushort buttons;

		// Token: 0x04004DD6 RID: 19926
		private bool is_connected;
	}
}
