using System;

namespace OpenTK.Input
{
	// Token: 0x02000520 RID: 1312
	public class JoystickButtonEventArgs : EventArgs
	{
		// Token: 0x06003D8F RID: 15759 RVA: 0x000A1ED4 File Offset: 0x000A00D4
		internal JoystickButtonEventArgs(JoystickButton button, bool pressed)
		{
			this.button = button;
			this.pressed = pressed;
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06003D90 RID: 15760 RVA: 0x000A1EEC File Offset: 0x000A00EC
		// (set) Token: 0x06003D91 RID: 15761 RVA: 0x000A1EF4 File Offset: 0x000A00F4
		public JoystickButton Button
		{
			get
			{
				return this.button;
			}
			internal set
			{
				this.button = value;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06003D92 RID: 15762 RVA: 0x000A1F00 File Offset: 0x000A0100
		// (set) Token: 0x06003D93 RID: 15763 RVA: 0x000A1F08 File Offset: 0x000A0108
		public bool Pressed
		{
			get
			{
				return this.pressed;
			}
			internal set
			{
				this.pressed = value;
			}
		}

		// Token: 0x04004DC6 RID: 19910
		private JoystickButton button;

		// Token: 0x04004DC7 RID: 19911
		private bool pressed;
	}
}
