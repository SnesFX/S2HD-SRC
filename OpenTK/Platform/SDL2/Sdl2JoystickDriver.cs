using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005E5 RID: 1509
	internal class Sdl2JoystickDriver : IJoystickDriver, IJoystickDriver2, IGamePadDriver, IDisposable
	{
		// Token: 0x060046E2 RID: 18146 RVA: 0x000C3568 File Offset: 0x000C1768
		public Sdl2JoystickDriver()
		{
			this.joysticks_readonly = this.joysticks.AsReadOnly();
		}

		// Token: 0x060046E3 RID: 18147 RVA: 0x000C35A4 File Offset: 0x000C17A4
		private JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> OpenJoystick(int id)
		{
			JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = null;
			IntPtr intPtr = SDL.JoystickOpen(id);
			if (intPtr != IntPtr.Zero)
			{
				int axes = SDL.JoystickNumAxes(intPtr);
				int buttons = SDL.JoystickNumButtons(intPtr);
				int hatCount = SDL.JoystickNumHats(intPtr);
				int ballCount = SDL.JoystickNumBalls(intPtr);
				joystickDevice = new JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>(id, axes, buttons);
				joystickDevice.Description = SDL.JoystickName(intPtr);
				joystickDevice.Details.Handle = intPtr;
				joystickDevice.Details.Guid = SDL.JoystickGetGUID(intPtr).ToGuid();
				joystickDevice.Details.HatCount = hatCount;
				joystickDevice.Details.BallCount = ballCount;
			}
			return joystickDevice;
		}

		// Token: 0x060046E4 RID: 18148 RVA: 0x000C364C File Offset: 0x000C184C
		private bool IsJoystickValid(int id)
		{
			return id >= 0 && id < this.joysticks.Count;
		}

		// Token: 0x060046E5 RID: 18149 RVA: 0x000C3664 File Offset: 0x000C1864
		private bool IsJoystickInstanceValid(int instance_id)
		{
			return this.sdl_instanceid_to_joysticks.ContainsKey(instance_id);
		}

		// Token: 0x060046E6 RID: 18150 RVA: 0x000C3674 File Offset: 0x000C1874
		private HatPosition TranslateHat(HatPosition value)
		{
			if ((value & HatPosition.LeftUp) == value)
			{
				return HatPosition.UpLeft;
			}
			if ((value & HatPosition.Down) == value)
			{
				return HatPosition.UpRight;
			}
			if ((value & HatPosition.LeftDown) == value)
			{
				return HatPosition.DownLeft;
			}
			if ((value & HatPosition.Down) == value)
			{
				return HatPosition.DownRight;
			}
			if ((value & HatPosition.Up) == value)
			{
				return HatPosition.Up;
			}
			if ((value & HatPosition.Right) == value)
			{
				return HatPosition.Right;
			}
			if ((value & HatPosition.Down) == value)
			{
				return HatPosition.Down;
			}
			if ((value & HatPosition.Left) == value)
			{
				return HatPosition.Left;
			}
			return HatPosition.Centered;
		}

		// Token: 0x060046E7 RID: 18151 RVA: 0x000C36CC File Offset: 0x000C18CC
		public void ProcessJoystickEvent(JoyDeviceEvent ev)
		{
			int which = ev.Which;
			if (which < 0)
			{
				return;
			}
			switch (ev.Type)
			{
			case EventType.JOYDEVICEADDED:
			{
				IntPtr value = SDL.JoystickOpen(which);
				if (value != IntPtr.Zero)
				{
					int num = which;
					int key = this.last_joystick_instance++;
					JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = this.OpenJoystick(which);
					if (joystickDevice != null)
					{
						joystickDevice.Details.IsConnected = true;
						if (num < this.joysticks.Count)
						{
							this.joysticks[num] = joystickDevice;
						}
						else
						{
							this.joysticks.Add(joystickDevice);
						}
						this.sdl_instanceid_to_joysticks.Add(key, num);
						return;
					}
				}
				break;
			}
			case EventType.JOYDEVICEREMOVED:
				if (this.IsJoystickInstanceValid(which))
				{
					int key2 = which;
					int index = this.sdl_instanceid_to_joysticks[key2];
					JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice2 = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)this.joysticks[index];
					joystickDevice2.Details.IsConnected = false;
					this.sdl_instanceid_to_joysticks.Remove(key2);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060046E8 RID: 18152 RVA: 0x000C37D4 File Offset: 0x000C19D4
		public void ProcessJoystickEvent(JoyAxisEvent ev)
		{
			int which = ev.Which;
			if (this.IsJoystickInstanceValid(which))
			{
				int index = this.sdl_instanceid_to_joysticks[which];
				JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)this.joysticks[index];
				float value = (float)ev.Value * 3.0517578E-05f;
				joystickDevice.SetAxis((JoystickAxis)ev.Axis, value);
				joystickDevice.Details.PacketNumber = Math.Max(0, joystickDevice.Details.PacketNumber + 1);
			}
		}

		// Token: 0x060046E9 RID: 18153 RVA: 0x000C384C File Offset: 0x000C1A4C
		public void ProcessJoystickEvent(JoyBallEvent ev)
		{
			int which = ev.Which;
			if (this.IsJoystickInstanceValid(which))
			{
				int index = this.sdl_instanceid_to_joysticks[which];
				JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)this.joysticks[index];
				joystickDevice.Details.PacketNumber = Math.Max(0, joystickDevice.Details.PacketNumber + 1);
			}
		}

		// Token: 0x060046EA RID: 18154 RVA: 0x000C38A8 File Offset: 0x000C1AA8
		public void ProcessJoystickEvent(JoyButtonEvent ev)
		{
			int which = ev.Which;
			if (this.IsJoystickInstanceValid(which))
			{
				int index = this.sdl_instanceid_to_joysticks[which];
				JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)this.joysticks[index];
				joystickDevice.SetButton((JoystickButton)ev.Button, ev.State == State.Pressed);
				joystickDevice.Details.PacketNumber = Math.Max(0, joystickDevice.Details.PacketNumber + 1);
			}
		}

		// Token: 0x060046EB RID: 18155 RVA: 0x000C391C File Offset: 0x000C1B1C
		public void ProcessJoystickEvent(JoyHatEvent ev)
		{
			int which = ev.Which;
			if (this.IsJoystickInstanceValid(which))
			{
				int index = this.sdl_instanceid_to_joysticks[which];
				JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)this.joysticks[index];
				if (ev.Hat >= 0 && ev.Hat < 4)
				{
					joystickDevice.Details.Hat[(int)ev.Hat] = new JoystickHatState(this.TranslateHat(ev.Value));
				}
				joystickDevice.Details.PacketNumber = Math.Max(0, joystickDevice.Details.PacketNumber + 1);
			}
		}

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x060046EC RID: 18156 RVA: 0x000C39BC File Offset: 0x000C1BBC
		public IList<JoystickDevice> Joysticks
		{
			get
			{
				return this.joysticks_readonly;
			}
		}

		// Token: 0x060046ED RID: 18157 RVA: 0x000C39C4 File Offset: 0x000C1BC4
		public void Poll()
		{
		}

		// Token: 0x060046EE RID: 18158 RVA: 0x000C39C8 File Offset: 0x000C1BC8
		public GamePadCapabilities GetCapabilities(int index)
		{
			return this.gamepad_driver.GetCapabilities(index);
		}

		// Token: 0x060046EF RID: 18159 RVA: 0x000C39D8 File Offset: 0x000C1BD8
		public GamePadState GetState(int index)
		{
			return this.gamepad_driver.GetState(index);
		}

		// Token: 0x060046F0 RID: 18160 RVA: 0x000C39E8 File Offset: 0x000C1BE8
		public string GetName(int index)
		{
			return this.gamepad_driver.GetName(index);
		}

		// Token: 0x060046F1 RID: 18161 RVA: 0x000C39F8 File Offset: 0x000C1BF8
		public bool SetVibration(int index, float left, float right)
		{
			return false;
		}

		// Token: 0x060046F2 RID: 18162 RVA: 0x000C39FC File Offset: 0x000C1BFC
		JoystickState IJoystickDriver2.GetState(int index)
		{
			JoystickState result = default(JoystickState);
			if (this.IsJoystickValid(index))
			{
				JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)this.joysticks[index];
				for (int i = 0; i < joystickDevice.Axis.Count; i++)
				{
					result.SetAxis((JoystickAxis)i, (short)(joystickDevice.Axis[i] * 32767f + 0.5f));
				}
				for (int j = 0; j < joystickDevice.Button.Count; j++)
				{
					result.SetButton((JoystickButton)j, joystickDevice.Button[j]);
				}
				for (int k = 0; k < joystickDevice.Details.HatCount; k++)
				{
					result.SetHat((JoystickHat)k, joystickDevice.Details.Hat[k]);
				}
				result.SetIsConnected(joystickDevice.Details.IsConnected);
				result.SetPacketNumber(joystickDevice.Details.PacketNumber);
			}
			return result;
		}

		// Token: 0x060046F3 RID: 18163 RVA: 0x000C3AF0 File Offset: 0x000C1CF0
		JoystickCapabilities IJoystickDriver2.GetCapabilities(int index)
		{
			if (this.IsJoystickValid(index))
			{
				JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)this.joysticks[index];
				return new JoystickCapabilities(joystickDevice.Axis.Count, joystickDevice.Button.Count, joystickDevice.Details.HatCount, joystickDevice.Details.IsConnected);
			}
			return default(JoystickCapabilities);
		}

		// Token: 0x060046F4 RID: 18164 RVA: 0x000C3B54 File Offset: 0x000C1D54
		Guid IJoystickDriver2.GetGuid(int index)
		{
			Guid result = default(Guid);
			if (this.IsJoystickValid(index))
			{
				JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)this.joysticks[index];
				return joystickDevice.Details.Guid;
			}
			return result;
		}

		// Token: 0x060046F5 RID: 18165 RVA: 0x000C3B94 File Offset: 0x000C1D94
		private void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				if (manual)
				{
					foreach (JoystickDevice joystickDevice in this.joysticks)
					{
						JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails> joystickDevice2 = (JoystickDevice<Sdl2JoystickDriver.Sdl2JoystickDetails>)joystickDevice;
						IntPtr handle = joystickDevice2.Details.Handle;
						SDL.JoystickClose(handle);
					}
					this.joysticks.Clear();
				}
				this.disposed = true;
			}
		}

		// Token: 0x060046F6 RID: 18166 RVA: 0x000C3C18 File Offset: 0x000C1E18
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060046F7 RID: 18167 RVA: 0x000C3C28 File Offset: 0x000C1E28
		~Sdl2JoystickDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x04005597 RID: 21911
		private const float RangeMultiplier = 3.0517578E-05f;

		// Token: 0x04005598 RID: 21912
		private readonly MappedGamePadDriver gamepad_driver = new MappedGamePadDriver();

		// Token: 0x04005599 RID: 21913
		private bool disposed;

		// Token: 0x0400559A RID: 21914
		private int last_joystick_instance;

		// Token: 0x0400559B RID: 21915
		private readonly List<JoystickDevice> joysticks = new List<JoystickDevice>(4);

		// Token: 0x0400559C RID: 21916
		private readonly Dictionary<int, int> sdl_instanceid_to_joysticks = new Dictionary<int, int>();

		// Token: 0x0400559D RID: 21917
		private IList<JoystickDevice> joysticks_readonly;

		// Token: 0x020005E6 RID: 1510
		private class Sdl2JoystickDetails
		{
			// Token: 0x1700044A RID: 1098
			// (get) Token: 0x060046F8 RID: 18168 RVA: 0x000C3C58 File Offset: 0x000C1E58
			// (set) Token: 0x060046F9 RID: 18169 RVA: 0x000C3C60 File Offset: 0x000C1E60
			public IntPtr Handle { get; set; }

			// Token: 0x1700044B RID: 1099
			// (get) Token: 0x060046FA RID: 18170 RVA: 0x000C3C6C File Offset: 0x000C1E6C
			// (set) Token: 0x060046FB RID: 18171 RVA: 0x000C3C74 File Offset: 0x000C1E74
			public Guid Guid { get; set; }

			// Token: 0x1700044C RID: 1100
			// (get) Token: 0x060046FC RID: 18172 RVA: 0x000C3C80 File Offset: 0x000C1E80
			// (set) Token: 0x060046FD RID: 18173 RVA: 0x000C3C88 File Offset: 0x000C1E88
			public int PacketNumber { get; set; }

			// Token: 0x1700044D RID: 1101
			// (get) Token: 0x060046FE RID: 18174 RVA: 0x000C3C94 File Offset: 0x000C1E94
			// (set) Token: 0x060046FF RID: 18175 RVA: 0x000C3C9C File Offset: 0x000C1E9C
			public int HatCount { get; set; }

			// Token: 0x1700044E RID: 1102
			// (get) Token: 0x06004700 RID: 18176 RVA: 0x000C3CA8 File Offset: 0x000C1EA8
			// (set) Token: 0x06004701 RID: 18177 RVA: 0x000C3CB0 File Offset: 0x000C1EB0
			public int BallCount { get; set; }

			// Token: 0x1700044F RID: 1103
			// (get) Token: 0x06004702 RID: 18178 RVA: 0x000C3CBC File Offset: 0x000C1EBC
			// (set) Token: 0x06004703 RID: 18179 RVA: 0x000C3CC4 File Offset: 0x000C1EC4
			public bool IsConnected { get; set; }

			// Token: 0x0400559E RID: 21918
			public readonly JoystickHatState[] Hat = new JoystickHatState[4];
		}
	}
}
