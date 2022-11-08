using System;
using OpenTK.Input;
using OpenTK.Platform.Linux;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B5C RID: 2908
	internal class X11Input : IInputDriver2, IDisposable
	{
		// Token: 0x06005B2C RID: 23340 RVA: 0x000F6BA8 File Offset: 0x000F4DA8
		internal X11Input()
		{
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06005B2D RID: 23341 RVA: 0x000F6BDC File Offset: 0x000F4DDC
		public IMouseDriver2 MouseDriver
		{
			get
			{
				return this.mouse;
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06005B2E RID: 23342 RVA: 0x000F6BE4 File Offset: 0x000F4DE4
		public IKeyboardDriver2 KeyboardDriver
		{
			get
			{
				return this.keyboard;
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06005B2F RID: 23343 RVA: 0x000F6BEC File Offset: 0x000F4DEC
		public IGamePadDriver GamePadDriver
		{
			get
			{
				return this.gamepad;
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06005B30 RID: 23344 RVA: 0x000F6BF4 File Offset: 0x000F4DF4
		public IJoystickDriver2 JoystickDriver
		{
			get
			{
				return this.joystick;
			}
		}

		// Token: 0x06005B31 RID: 23345 RVA: 0x000F6BFC File Offset: 0x000F4DFC
		public void Dispose()
		{
			this.joystick.Dispose();
		}

		// Token: 0x0400B7B8 RID: 47032
		private readonly X11Mouse mouse = new X11Mouse();

		// Token: 0x0400B7B9 RID: 47033
		private readonly X11Keyboard keyboard = new X11Keyboard();

		// Token: 0x0400B7BA RID: 47034
		private readonly LinuxJoystick joystick = new LinuxJoystick();

		// Token: 0x0400B7BB RID: 47035
		private readonly IGamePadDriver gamepad = new MappedGamePadDriver();
	}
}
