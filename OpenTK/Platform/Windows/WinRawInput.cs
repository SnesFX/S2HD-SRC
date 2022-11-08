using System;
using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200007D RID: 125
	internal sealed class WinRawInput : WinInputBase
	{
		// Token: 0x0600078D RID: 1933 RVA: 0x000199B8 File Offset: 0x00017BB8
		private unsafe static IntPtr RegisterForDeviceNotifications(WinWindowInfo parent)
		{
			BroadcastDeviceInterface type = default(BroadcastDeviceInterface);
			type.Size = BlittableValueType.StrideOf<BroadcastDeviceInterface>(type);
			type.DeviceType = DeviceBroadcastType.INTERFACE;
			type.ClassGuid = WinRawInput.DeviceInterfaceHid;
			IntPtr intPtr = Functions.RegisterDeviceNotification(parent.Handle, new IntPtr((void*)(&type)), DeviceNotification.WINDOW_HANDLE);
			intPtr == IntPtr.Zero;
			return intPtr;
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00019A10 File Offset: 0x00017C10
		protected override IntPtr WindowProcedure(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			if (message != WindowMessage.INPUT)
			{
				if (message == WindowMessage.DEVICECHANGE)
				{
					((WinRawKeyboard)this.KeyboardDriver).RefreshDevices();
					((WinRawMouse)this.MouseDriver).RefreshDevices();
					((WinMMJoystick)this.JoystickDriver).RefreshDevices();
				}
			}
			else
			{
				int num = 0;
				Functions.GetRawInputData(lParam, GetRawInputDataEnum.INPUT, IntPtr.Zero, ref num, API.RawInputHeaderSize);
				if (num == Functions.GetRawInputData(lParam, GetRawInputDataEnum.INPUT, out WinRawInput.data, ref num, API.RawInputHeaderSize))
				{
					switch (WinRawInput.data.Header.Type)
					{
					case RawInputDeviceType.MOUSE:
						if (((WinRawMouse)this.MouseDriver).ProcessMouseEvent(WinRawInput.data))
						{
							return IntPtr.Zero;
						}
						break;
					case RawInputDeviceType.KEYBOARD:
						if (((WinRawKeyboard)this.KeyboardDriver).ProcessKeyboardEvent(WinRawInput.data))
						{
							return IntPtr.Zero;
						}
						break;
					}
				}
			}
			return base.WindowProcedure(handle, message, wParam, lParam);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00019B0C File Offset: 0x00017D0C
		protected override void CreateDrivers()
		{
			this.keyboard_driver = new WinRawKeyboard(base.Parent.Handle);
			this.mouse_driver = new WinRawMouse(base.Parent.Handle);
			this.joystick_driver = new WinMMJoystick();
			try
			{
				this.gamepad_driver = new XInputJoystick();
			}
			catch (Exception)
			{
				this.gamepad_driver = new MappedGamePadDriver();
			}
			this.DevNotifyHandle = WinRawInput.RegisterForDeviceNotifications(base.Parent);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00019B8C File Offset: 0x00017D8C
		protected override void Dispose(bool manual)
		{
			if (!this.Disposed)
			{
				Functions.UnregisterDeviceNotification(this.DevNotifyHandle);
				base.Dispose(manual);
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x00019BAC File Offset: 0x00017DAC
		public static int DeviceCount
		{
			get
			{
				int result = 0;
				Functions.GetRawInputDeviceList(null, ref result, API.RawInputDeviceListSize);
				return result;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x00019BCC File Offset: 0x00017DCC
		public override IKeyboardDriver2 KeyboardDriver
		{
			get
			{
				return this.keyboard_driver;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x00019BD4 File Offset: 0x00017DD4
		public override IMouseDriver2 MouseDriver
		{
			get
			{
				return this.mouse_driver;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x00019BDC File Offset: 0x00017DDC
		public override IGamePadDriver GamePadDriver
		{
			get
			{
				return this.gamepad_driver;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x00019BE4 File Offset: 0x00017DE4
		public override IJoystickDriver2 JoystickDriver
		{
			get
			{
				return this.joystick_driver;
			}
		}

		// Token: 0x040002A3 RID: 675
		private static RawInput data = default(RawInput);

		// Token: 0x040002A4 RID: 676
		private static readonly int rawInputStructSize = API.RawInputSize;

		// Token: 0x040002A5 RID: 677
		private WinRawKeyboard keyboard_driver;

		// Token: 0x040002A6 RID: 678
		private WinRawMouse mouse_driver;

		// Token: 0x040002A7 RID: 679
		private IGamePadDriver gamepad_driver;

		// Token: 0x040002A8 RID: 680
		private IJoystickDriver2 joystick_driver;

		// Token: 0x040002A9 RID: 681
		private IntPtr DevNotifyHandle;

		// Token: 0x040002AA RID: 682
		private static readonly Guid DeviceInterfaceHid = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");
	}
}
