using System;

namespace OpenTK.Input
{
	// Token: 0x02000AFC RID: 2812
	public struct GamePadButtons : IEquatable<GamePadButtons>
	{
		// Token: 0x06005958 RID: 22872 RVA: 0x000F2AD4 File Offset: 0x000F0CD4
		public GamePadButtons(Buttons state)
		{
			this.buttons = state;
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06005959 RID: 22873 RVA: 0x000F2AE0 File Offset: 0x000F0CE0
		public ButtonState A
		{
			get
			{
				return this.GetButton(Buttons.A);
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x0600595A RID: 22874 RVA: 0x000F2AF0 File Offset: 0x000F0CF0
		public ButtonState B
		{
			get
			{
				return this.GetButton(Buttons.B);
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x0600595B RID: 22875 RVA: 0x000F2B00 File Offset: 0x000F0D00
		public ButtonState X
		{
			get
			{
				return this.GetButton(Buttons.X);
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x0600595C RID: 22876 RVA: 0x000F2B10 File Offset: 0x000F0D10
		public ButtonState Y
		{
			get
			{
				return this.GetButton(Buttons.Y);
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x0600595D RID: 22877 RVA: 0x000F2B20 File Offset: 0x000F0D20
		public ButtonState Back
		{
			get
			{
				return this.GetButton(Buttons.Back);
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x0600595E RID: 22878 RVA: 0x000F2B2C File Offset: 0x000F0D2C
		public ButtonState BigButton
		{
			get
			{
				return this.GetButton(Buttons.Home);
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x0600595F RID: 22879 RVA: 0x000F2B3C File Offset: 0x000F0D3C
		public ButtonState LeftShoulder
		{
			get
			{
				return this.GetButton(Buttons.LeftShoulder);
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06005960 RID: 22880 RVA: 0x000F2B4C File Offset: 0x000F0D4C
		public ButtonState LeftStick
		{
			get
			{
				return this.GetButton(Buttons.LeftStick);
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06005961 RID: 22881 RVA: 0x000F2B58 File Offset: 0x000F0D58
		public ButtonState RightShoulder
		{
			get
			{
				return this.GetButton(Buttons.RightShoulder);
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06005962 RID: 22882 RVA: 0x000F2B68 File Offset: 0x000F0D68
		public ButtonState RightStick
		{
			get
			{
				return this.GetButton(Buttons.RightStick);
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06005963 RID: 22883 RVA: 0x000F2B78 File Offset: 0x000F0D78
		public ButtonState Start
		{
			get
			{
				return this.GetButton(Buttons.Start);
			}
		}

		// Token: 0x06005964 RID: 22884 RVA: 0x000F2B84 File Offset: 0x000F0D84
		public static bool operator ==(GamePadButtons left, GamePadButtons right)
		{
			return left.Equals(right);
		}

		// Token: 0x06005965 RID: 22885 RVA: 0x000F2B90 File Offset: 0x000F0D90
		public static bool operator !=(GamePadButtons left, GamePadButtons right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06005966 RID: 22886 RVA: 0x000F2BA0 File Offset: 0x000F0DA0
		public override string ToString()
		{
			return Convert.ToString((int)this.buttons, 2).PadLeft(10, '0');
		}

		// Token: 0x06005967 RID: 22887 RVA: 0x000F2BB8 File Offset: 0x000F0DB8
		public override int GetHashCode()
		{
			return this.buttons.GetHashCode();
		}

		// Token: 0x06005968 RID: 22888 RVA: 0x000F2BCC File Offset: 0x000F0DCC
		public override bool Equals(object obj)
		{
			return obj is GamePadButtons && this.Equals((GamePadButtons)obj);
		}

		// Token: 0x06005969 RID: 22889 RVA: 0x000F2BE4 File Offset: 0x000F0DE4
		public bool Equals(GamePadButtons other)
		{
			return this.buttons == other.buttons;
		}

		// Token: 0x0600596A RID: 22890 RVA: 0x000F2BF8 File Offset: 0x000F0DF8
		private ButtonState GetButton(Buttons b)
		{
			if ((this.buttons & b) == (Buttons)0)
			{
				return ButtonState.Released;
			}
			return ButtonState.Pressed;
		}

		// Token: 0x0400B49B RID: 46235
		private Buttons buttons;
	}
}
