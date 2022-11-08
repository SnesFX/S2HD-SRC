using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace OpenTK.Platform
{
	// Token: 0x02000B28 RID: 2856
	internal class LegacyInputDriver : IInputDriver, IKeyboardDriver, IMouseDriver, IJoystickDriver, IDisposable
	{
		// Token: 0x06005A88 RID: 23176 RVA: 0x000F6294 File Offset: 0x000F4494
		internal LegacyInputDriver(INativeWindow window)
		{
			if (window == null)
			{
				throw new ArgumentNullException();
			}
			MouseDevice mouseDevice = new MouseDevice();
			mouseDevice.Description = "Standard Mouse";
			mouseDevice.NumberOfButtons = 3;
			mouseDevice.NumberOfWheels = 1;
			this.dummy_mice_list.Add(mouseDevice);
			KeyboardDevice keyboardDevice = new KeyboardDevice();
			keyboardDevice.Description = "Standard Keyboard";
			keyboardDevice.NumberOfKeys = 101;
			keyboardDevice.NumberOfLeds = 3;
			keyboardDevice.NumberOfFunctionKeys = 12;
			this.dummy_keyboard_list.Add(keyboardDevice);
			window.MouseDown += mouseDevice.HandleMouseDown;
			window.MouseUp += mouseDevice.HandleMouseUp;
			window.MouseMove += mouseDevice.HandleMouseMove;
			window.MouseWheel += mouseDevice.HandleMouseWheel;
			window.KeyDown += keyboardDevice.HandleKeyDown;
			window.KeyUp += keyboardDevice.HandleKeyUp;
		}

		// Token: 0x06005A89 RID: 23177 RVA: 0x000F63A0 File Offset: 0x000F45A0
		public void Poll()
		{
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06005A8A RID: 23178 RVA: 0x000F63A4 File Offset: 0x000F45A4
		public IList<KeyboardDevice> Keyboard
		{
			get
			{
				return this.dummy_keyboard_list;
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06005A8B RID: 23179 RVA: 0x000F63AC File Offset: 0x000F45AC
		public IList<MouseDevice> Mouse
		{
			get
			{
				return this.dummy_mice_list;
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06005A8C RID: 23180 RVA: 0x000F63B4 File Offset: 0x000F45B4
		public IList<JoystickDevice> Joysticks
		{
			get
			{
				return this.JoystickDriver.Joysticks;
			}
		}

		// Token: 0x06005A8D RID: 23181 RVA: 0x000F63C4 File Offset: 0x000F45C4
		public void Dispose()
		{
		}

		// Token: 0x0400B5AA RID: 46506
		private List<KeyboardDevice> dummy_keyboard_list = new List<KeyboardDevice>(1);

		// Token: 0x0400B5AB RID: 46507
		private List<MouseDevice> dummy_mice_list = new List<MouseDevice>(1);

		// Token: 0x0400B5AC RID: 46508
		private readonly LegacyJoystickDriver JoystickDriver = new LegacyJoystickDriver();
	}
}
