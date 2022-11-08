using System;

namespace OpenTK.Input
{
	// Token: 0x02000AF9 RID: 2809
	public struct GamePadCapabilities : IEquatable<GamePadCapabilities>
	{
		// Token: 0x06005923 RID: 22819 RVA: 0x000F263C File Offset: 0x000F083C
		internal GamePadCapabilities(GamePadType type, GamePadAxes axes, Buttons buttons, bool is_connected)
		{
			this = default(GamePadCapabilities);
			this.gamepad_type = (byte)type;
			this.axes = axes;
			this.buttons = buttons;
			this.is_connected = is_connected;
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06005924 RID: 22820 RVA: 0x000F2664 File Offset: 0x000F0864
		public GamePadType GamePadType
		{
			get
			{
				return (GamePadType)this.gamepad_type;
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06005925 RID: 22821 RVA: 0x000F266C File Offset: 0x000F086C
		public bool HasDPadUpButton
		{
			get
			{
				return (this.buttons & Buttons.DPadUp) != (Buttons)0;
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06005926 RID: 22822 RVA: 0x000F267C File Offset: 0x000F087C
		public bool HasDPadDownButton
		{
			get
			{
				return (this.buttons & Buttons.DPadDown) != (Buttons)0;
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06005927 RID: 22823 RVA: 0x000F268C File Offset: 0x000F088C
		public bool HasDPadLeftButton
		{
			get
			{
				return (this.buttons & Buttons.DPadLeft) != (Buttons)0;
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06005928 RID: 22824 RVA: 0x000F269C File Offset: 0x000F089C
		public bool HasDPadRightButton
		{
			get
			{
				return (this.buttons & Buttons.DPadRight) != (Buttons)0;
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06005929 RID: 22825 RVA: 0x000F26AC File Offset: 0x000F08AC
		public bool HasAButton
		{
			get
			{
				return (this.buttons & Buttons.A) != (Buttons)0;
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x0600592A RID: 22826 RVA: 0x000F26C0 File Offset: 0x000F08C0
		public bool HasBButton
		{
			get
			{
				return (this.buttons & Buttons.B) != (Buttons)0;
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x0600592B RID: 22827 RVA: 0x000F26D4 File Offset: 0x000F08D4
		public bool HasXButton
		{
			get
			{
				return (this.buttons & Buttons.X) != (Buttons)0;
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x0600592C RID: 22828 RVA: 0x000F26E8 File Offset: 0x000F08E8
		public bool HasYButton
		{
			get
			{
				return (this.buttons & Buttons.Y) != (Buttons)0;
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x0600592D RID: 22829 RVA: 0x000F26FC File Offset: 0x000F08FC
		public bool HasLeftStickButton
		{
			get
			{
				return (this.buttons & Buttons.LeftStick) != (Buttons)0;
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x0600592E RID: 22830 RVA: 0x000F2710 File Offset: 0x000F0910
		public bool HasRightStickButton
		{
			get
			{
				return (this.buttons & Buttons.RightStick) != (Buttons)0;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x0600592F RID: 22831 RVA: 0x000F2724 File Offset: 0x000F0924
		public bool HasLeftShoulderButton
		{
			get
			{
				return (this.buttons & Buttons.LeftShoulder) != (Buttons)0;
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06005930 RID: 22832 RVA: 0x000F2738 File Offset: 0x000F0938
		public bool HasRightShoulderButton
		{
			get
			{
				return (this.buttons & Buttons.RightShoulder) != (Buttons)0;
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06005931 RID: 22833 RVA: 0x000F274C File Offset: 0x000F094C
		public bool HasBackButton
		{
			get
			{
				return (this.buttons & Buttons.Back) != (Buttons)0;
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06005932 RID: 22834 RVA: 0x000F2760 File Offset: 0x000F0960
		public bool HasBigButton
		{
			get
			{
				return (this.buttons & Buttons.Home) != (Buttons)0;
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06005933 RID: 22835 RVA: 0x000F2774 File Offset: 0x000F0974
		public bool HasStartButton
		{
			get
			{
				return (this.buttons & Buttons.Start) != (Buttons)0;
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06005934 RID: 22836 RVA: 0x000F2788 File Offset: 0x000F0988
		public bool HasLeftXThumbStick
		{
			get
			{
				return (byte)(this.axes & GamePadAxes.LeftX) != 0;
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06005935 RID: 22837 RVA: 0x000F279C File Offset: 0x000F099C
		public bool HasLeftYThumbStick
		{
			get
			{
				return (byte)(this.axes & GamePadAxes.LeftY) != 0;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06005936 RID: 22838 RVA: 0x000F27B0 File Offset: 0x000F09B0
		public bool HasRightXThumbStick
		{
			get
			{
				return (byte)(this.axes & GamePadAxes.RightX) != 0;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06005937 RID: 22839 RVA: 0x000F27C4 File Offset: 0x000F09C4
		public bool HasRightYThumbStick
		{
			get
			{
				return (byte)(this.axes & GamePadAxes.RightY) != 0;
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06005938 RID: 22840 RVA: 0x000F27D8 File Offset: 0x000F09D8
		public bool HasLeftTrigger
		{
			get
			{
				return (byte)(this.axes & GamePadAxes.LeftTrigger) != 0;
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06005939 RID: 22841 RVA: 0x000F27EC File Offset: 0x000F09EC
		public bool HasRightTrigger
		{
			get
			{
				return (byte)(this.axes & GamePadAxes.RightTrigger) != 0;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x0600593A RID: 22842 RVA: 0x000F2800 File Offset: 0x000F0A00
		public bool HasLeftVibrationMotor
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x0600593B RID: 22843 RVA: 0x000F2804 File Offset: 0x000F0A04
		public bool HasRightVibrationMotor
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x0600593C RID: 22844 RVA: 0x000F2808 File Offset: 0x000F0A08
		public bool HasVoiceSupport
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x0600593D RID: 22845 RVA: 0x000F280C File Offset: 0x000F0A0C
		public bool IsConnected
		{
			get
			{
				return this.is_connected;
			}
		}

		// Token: 0x0600593E RID: 22846 RVA: 0x000F2814 File Offset: 0x000F0A14
		public static bool operator ==(GamePadCapabilities left, GamePadCapabilities right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600593F RID: 22847 RVA: 0x000F2820 File Offset: 0x000F0A20
		public static bool operator !=(GamePadCapabilities left, GamePadCapabilities right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06005940 RID: 22848 RVA: 0x000F2830 File Offset: 0x000F0A30
		public override string ToString()
		{
			return string.Format("{{Type: {0}; Axes: {1}; Buttons: {2}; Connected: {3}}}", new object[]
			{
				this.GamePadType,
				Convert.ToString((int)this.axes, 2),
				Convert.ToString((int)this.buttons, 2),
				this.IsConnected
			});
		}

		// Token: 0x06005941 RID: 22849 RVA: 0x000F288C File Offset: 0x000F0A8C
		public override int GetHashCode()
		{
			return this.buttons.GetHashCode() ^ this.is_connected.GetHashCode() ^ this.gamepad_type.GetHashCode();
		}

		// Token: 0x06005942 RID: 22850 RVA: 0x000F28B8 File Offset: 0x000F0AB8
		public override bool Equals(object obj)
		{
			return obj is GamePadCapabilities && this.Equals((GamePadCapabilities)obj);
		}

		// Token: 0x06005943 RID: 22851 RVA: 0x000F28D0 File Offset: 0x000F0AD0
		public bool Equals(GamePadCapabilities other)
		{
			return this.buttons == other.buttons && this.is_connected == other.is_connected && this.gamepad_type == other.gamepad_type;
		}

		// Token: 0x0400B491 RID: 46225
		private Buttons buttons;

		// Token: 0x0400B492 RID: 46226
		private GamePadAxes axes;

		// Token: 0x0400B493 RID: 46227
		private byte gamepad_type;

		// Token: 0x0400B494 RID: 46228
		private bool is_connected;
	}
}
