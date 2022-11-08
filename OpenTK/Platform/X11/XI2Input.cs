using System;
using OpenTK.Input;
using OpenTK.Platform.Linux;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B5D RID: 2909
	internal class XI2Input : IInputDriver2, IDisposable
	{
		// Token: 0x06005B32 RID: 23346 RVA: 0x000F6C0C File Offset: 0x000F4E0C
		internal XI2Input()
		{
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06005B33 RID: 23347 RVA: 0x000F6C38 File Offset: 0x000F4E38
		public IMouseDriver2 MouseDriver
		{
			get
			{
				return this.mouse_keyboard;
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06005B34 RID: 23348 RVA: 0x000F6C40 File Offset: 0x000F4E40
		public IKeyboardDriver2 KeyboardDriver
		{
			get
			{
				return this.mouse_keyboard;
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06005B35 RID: 23349 RVA: 0x000F6C48 File Offset: 0x000F4E48
		public IGamePadDriver GamePadDriver
		{
			get
			{
				return this.gamepad;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06005B36 RID: 23350 RVA: 0x000F6C50 File Offset: 0x000F4E50
		public IJoystickDriver2 JoystickDriver
		{
			get
			{
				return this.joystick;
			}
		}

		// Token: 0x06005B37 RID: 23351 RVA: 0x000F6C58 File Offset: 0x000F4E58
		public void Dispose()
		{
			this.mouse_keyboard.Dispose();
			this.joystick.Dispose();
		}

		// Token: 0x0400B7BC RID: 47036
		private readonly XI2MouseKeyboard mouse_keyboard = new XI2MouseKeyboard();

		// Token: 0x0400B7BD RID: 47037
		private readonly LinuxJoystick joystick = new LinuxJoystick();

		// Token: 0x0400B7BE RID: 47038
		private readonly IGamePadDriver gamepad = new MappedGamePadDriver();
	}
}
