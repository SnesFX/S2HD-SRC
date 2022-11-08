using System;

namespace OpenTK.Input
{
	// Token: 0x02000527 RID: 1319
	public struct GamePadState : IEquatable<GamePadState>
	{
		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06003DDC RID: 15836 RVA: 0x000A2614 File Offset: 0x000A0814
		public GamePadThumbSticks ThumbSticks
		{
			get
			{
				return new GamePadThumbSticks(this.left_stick_x, this.left_stick_y, this.right_stick_x, this.right_stick_y);
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06003DDD RID: 15837 RVA: 0x000A2634 File Offset: 0x000A0834
		public GamePadButtons Buttons
		{
			get
			{
				return new GamePadButtons(this.buttons);
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06003DDE RID: 15838 RVA: 0x000A2644 File Offset: 0x000A0844
		public GamePadDPad DPad
		{
			get
			{
				return new GamePadDPad(this.buttons);
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06003DDF RID: 15839 RVA: 0x000A2654 File Offset: 0x000A0854
		public GamePadTriggers Triggers
		{
			get
			{
				return new GamePadTriggers(this.left_trigger, this.right_trigger);
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06003DE0 RID: 15840 RVA: 0x000A2668 File Offset: 0x000A0868
		public bool IsConnected
		{
			get
			{
				return this.is_connected;
			}
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06003DE1 RID: 15841 RVA: 0x000A2670 File Offset: 0x000A0870
		public int PacketNumber
		{
			get
			{
				return this.packet_number;
			}
		}

		// Token: 0x06003DE2 RID: 15842 RVA: 0x000A2678 File Offset: 0x000A0878
		public override string ToString()
		{
			return string.Format("{{Sticks: {0}; Buttons: {1}; DPad: {2}; IsConnected: {3}}}", new object[]
			{
				this.ThumbSticks,
				this.Buttons,
				this.DPad,
				this.IsConnected
			});
		}

		// Token: 0x06003DE3 RID: 15843 RVA: 0x000A26D0 File Offset: 0x000A08D0
		public override int GetHashCode()
		{
			return this.ThumbSticks.GetHashCode() ^ this.Buttons.GetHashCode() ^ this.DPad.GetHashCode() ^ this.IsConnected.GetHashCode();
		}

		// Token: 0x06003DE4 RID: 15844 RVA: 0x000A272C File Offset: 0x000A092C
		public override bool Equals(object obj)
		{
			return obj is GamePadState && this.Equals((GamePadState)obj);
		}

		// Token: 0x06003DE5 RID: 15845 RVA: 0x000A2744 File Offset: 0x000A0944
		public bool Equals(GamePadState other)
		{
			return this.ThumbSticks == other.ThumbSticks && this.Buttons == other.Buttons && this.DPad == other.DPad && this.IsConnected == other.IsConnected;
		}

		// Token: 0x06003DE6 RID: 15846 RVA: 0x000A27A0 File Offset: 0x000A09A0
		internal void SetAxis(GamePadAxes axis, short value)
		{
			if ((byte)(axis & GamePadAxes.LeftX) != 0)
			{
				this.left_stick_x = value;
			}
			if ((byte)(axis & GamePadAxes.LeftY) != 0)
			{
				this.left_stick_y = value;
			}
			if ((byte)(axis & GamePadAxes.RightX) != 0)
			{
				this.right_stick_x = value;
			}
			if ((byte)(axis & GamePadAxes.RightY) != 0)
			{
				this.right_stick_y = value;
			}
			if ((byte)(axis & GamePadAxes.LeftTrigger) != 0)
			{
				this.left_trigger = (byte)(value - short.MinValue >> 8);
			}
			if ((byte)(axis & GamePadAxes.RightTrigger) != 0)
			{
				this.right_trigger = (byte)(value - short.MinValue >> 8);
			}
		}

		// Token: 0x06003DE7 RID: 15847 RVA: 0x000A2810 File Offset: 0x000A0A10
		internal void SetButton(Buttons button, bool pressed)
		{
			if (pressed)
			{
				this.buttons |= button;
				return;
			}
			this.buttons &= ~button;
		}

		// Token: 0x06003DE8 RID: 15848 RVA: 0x000A2834 File Offset: 0x000A0A34
		internal void SetConnected(bool connected)
		{
			this.is_connected = connected;
		}

		// Token: 0x06003DE9 RID: 15849 RVA: 0x000A2840 File Offset: 0x000A0A40
		internal void SetTriggers(byte left, byte right)
		{
			this.left_trigger = left;
			this.right_trigger = right;
		}

		// Token: 0x06003DEA RID: 15850 RVA: 0x000A2850 File Offset: 0x000A0A50
		internal void SetPacketNumber(int number)
		{
			this.packet_number = number;
		}

		// Token: 0x06003DEB RID: 15851 RVA: 0x000A285C File Offset: 0x000A0A5C
		private bool IsAxisValid(GamePadAxes axis)
		{
			return axis >= (GamePadAxes)0 && axis < (GamePadAxes.LeftY | GamePadAxes.RightX);
		}

		// Token: 0x06003DEC RID: 15852 RVA: 0x000A2878 File Offset: 0x000A0A78
		private bool IsDPadValid(int index)
		{
			return index >= 0 && index < 2;
		}

		// Token: 0x04004DD7 RID: 19927
		private const float RangeMultiplier = 3.0517578E-05f;

		// Token: 0x04004DD8 RID: 19928
		private Buttons buttons;

		// Token: 0x04004DD9 RID: 19929
		private int packet_number;

		// Token: 0x04004DDA RID: 19930
		private short left_stick_x;

		// Token: 0x04004DDB RID: 19931
		private short left_stick_y;

		// Token: 0x04004DDC RID: 19932
		private short right_stick_x;

		// Token: 0x04004DDD RID: 19933
		private short right_stick_y;

		// Token: 0x04004DDE RID: 19934
		private byte left_trigger;

		// Token: 0x04004DDF RID: 19935
		private byte right_trigger;

		// Token: 0x04004DE0 RID: 19936
		private bool is_connected;
	}
}
