using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTK.Input
{
	// Token: 0x02000012 RID: 18
	public struct JoystickState : IEquatable<JoystickState>
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00002A14 File Offset: 0x00000C14
		public float GetAxis(JoystickAxis axis)
		{
			return (float)this.GetAxisRaw(axis) * 3.0518044E-05f;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002A24 File Offset: 0x00000C24
		public ButtonState GetButton(JoystickButton button)
		{
			if ((this.buttons & 1 << (int)button) == 0)
			{
				return ButtonState.Released;
			}
			return ButtonState.Pressed;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002A38 File Offset: 0x00000C38
		public JoystickHatState GetHat(JoystickHat hat)
		{
			switch (hat)
			{
			case JoystickHat.Hat0:
				return this.hat0;
			case JoystickHat.Hat1:
				return this.hat1;
			case JoystickHat.Hat2:
				return this.hat2;
			case JoystickHat.Hat3:
				return this.hat3;
			default:
				return default(JoystickHatState);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002A84 File Offset: 0x00000C84
		public bool IsButtonDown(JoystickButton button)
		{
			return (this.buttons & 1 << (int)button) != 0;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002A9C File Offset: 0x00000C9C
		public bool IsButtonUp(JoystickButton button)
		{
			return (this.buttons & 1 << (int)button) == 0;
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002AB0 File Offset: 0x00000CB0
		public bool IsConnected
		{
			get
			{
				return this.is_connected;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 11; i++)
			{
				stringBuilder.Append(" ");
				stringBuilder.Append(string.Format("{0:f4}", this.GetAxis((JoystickAxis)i)));
			}
			return string.Format("{{Axes:{0}; Buttons: {1}; Hat: {2}; IsConnected: {3}}}", new object[]
			{
				stringBuilder.ToString(),
				Convert.ToString(this.buttons, 2).PadLeft(16, '0'),
				this.hat0,
				this.IsConnected
			});
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002B50 File Offset: 0x00000D50
		public override int GetHashCode()
		{
			int num = this.buttons.GetHashCode() ^ this.IsConnected.GetHashCode();
			for (int i = 0; i < 11; i++)
			{
				num ^= this.GetAxisUnsafe(i).GetHashCode();
			}
			return num;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002B98 File Offset: 0x00000D98
		public override bool Equals(object obj)
		{
			return obj is JoystickState && this.Equals((JoystickState)obj);
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002BB0 File Offset: 0x00000DB0
		internal int PacketNumber
		{
			get
			{
				return this.packet_number;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002BB8 File Offset: 0x00000DB8
		internal short GetAxisRaw(JoystickAxis axis)
		{
			return this.GetAxisRaw((int)axis);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002BC4 File Offset: 0x00000DC4
		internal short GetAxisRaw(int axis)
		{
			short result = 0;
			if (axis >= 0 && axis < 11)
			{
				result = this.GetAxisUnsafe(axis);
			}
			return result;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002BE8 File Offset: 0x00000DE8
		internal unsafe void SetAxis(JoystickAxis axis, short value)
		{
			if (axis < JoystickAxis.Axis0 || axis >= (JoystickAxis)11)
			{
				throw new ArgumentOutOfRangeException("axis");
			}
			fixed (short* ptr = &this.axes.FixedElementField)
			{
				ptr[(IntPtr)axis] = value;
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002C24 File Offset: 0x00000E24
		internal void SetButton(JoystickButton button, bool value)
		{
			if (button < JoystickButton.Button0 || button >= (JoystickButton)32)
			{
				throw new ArgumentOutOfRangeException("button");
			}
			if (value)
			{
				this.buttons |= 1 << (int)button;
				return;
			}
			this.buttons &= ~(1 << (int)button);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002C74 File Offset: 0x00000E74
		internal void SetHat(JoystickHat hat, JoystickHatState value)
		{
			switch (hat)
			{
			case JoystickHat.Hat0:
				this.hat0 = value;
				return;
			case JoystickHat.Hat1:
				this.hat1 = value;
				return;
			case JoystickHat.Hat2:
				this.hat2 = value;
				return;
			case JoystickHat.Hat3:
				this.hat3 = value;
				return;
			default:
				throw new ArgumentOutOfRangeException("hat");
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002CC8 File Offset: 0x00000EC8
		internal void SetIsConnected(bool value)
		{
			this.is_connected = value;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002CD4 File Offset: 0x00000ED4
		internal void SetPacketNumber(int number)
		{
			this.packet_number = number;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002CE0 File Offset: 0x00000EE0
		private unsafe short GetAxisUnsafe(int index)
		{
			fixed (short* ptr = &this.axes.FixedElementField)
			{
				return ptr[index];
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002D08 File Offset: 0x00000F08
		public bool Equals(JoystickState other)
		{
			bool flag = this.buttons == other.buttons && this.IsConnected == other.IsConnected;
			int num = 0;
			while (flag && num < 11)
			{
				flag &= (this.GetAxisUnsafe(num) == other.GetAxisUnsafe(num));
				num++;
			}
			int num2 = 0;
			while (flag && num2 < 4)
			{
				JoystickHat hat = (JoystickHat)num2;
				flag &= this.GetHat(hat).Equals(other.GetHat(hat));
				num2++;
			}
			return flag;
		}

		// Token: 0x04000061 RID: 97
		internal const int MaxAxes = 11;

		// Token: 0x04000062 RID: 98
		internal const int MaxButtons = 32;

		// Token: 0x04000063 RID: 99
		internal const int MaxHats = 4;

		// Token: 0x04000064 RID: 100
		private const float ConversionFactor = 3.0518044E-05f;

		// Token: 0x04000065 RID: 101
		private int packet_number;

		// Token: 0x04000066 RID: 102
		private int buttons;

		// Token: 0x04000067 RID: 103
		[FixedBuffer(typeof(short), 11)]
		private JoystickState.<axes>e__FixedBuffer0 axes;

		// Token: 0x04000068 RID: 104
		private JoystickHatState hat0;

		// Token: 0x04000069 RID: 105
		private JoystickHatState hat1;

		// Token: 0x0400006A RID: 106
		private JoystickHatState hat2;

		// Token: 0x0400006B RID: 107
		private JoystickHatState hat3;

		// Token: 0x0400006C RID: 108
		private bool is_connected;

		// Token: 0x02000013 RID: 19
		[UnsafeValueType]
		[CompilerGenerated]
		[StructLayout(LayoutKind.Sequential, Size = 22)]
		public struct <axes>e__FixedBuffer0
		{
			// Token: 0x0400006D RID: 109
			public short FixedElementField;
		}
	}
}
