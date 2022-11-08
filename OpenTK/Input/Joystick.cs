using System;
using OpenTK.Platform;

namespace OpenTK.Input
{
	// Token: 0x0200000E RID: 14
	public sealed class Joystick
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00002848 File Offset: 0x00000A48
		private Joystick()
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002850 File Offset: 0x00000A50
		public static JoystickCapabilities GetCapabilities(int index)
		{
			return Joystick.implementation.GetCapabilities(index);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002860 File Offset: 0x00000A60
		public static JoystickState GetState(int index)
		{
			return Joystick.implementation.GetState(index);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002870 File Offset: 0x00000A70
		internal static Guid GetGuid(int index)
		{
			return Joystick.implementation.GetGuid(index);
		}

		// Token: 0x0400002D RID: 45
		private static readonly IJoystickDriver2 implementation = Factory.Default.CreateJoystickDriver();
	}
}
