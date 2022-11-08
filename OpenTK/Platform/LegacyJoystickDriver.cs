using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace OpenTK.Platform
{
	// Token: 0x02000B04 RID: 2820
	internal class LegacyJoystickDriver : IJoystickDriver
	{
		// Token: 0x0600598F RID: 22927 RVA: 0x000F3354 File Offset: 0x000F1554
		internal LegacyJoystickDriver()
		{
			this.joysticks_readonly = this.joysticks.AsReadOnly();
			for (int i = 0; i < 4; i++)
			{
				this.joysticks.Add(new LegacyJoystickDriver.LegacyJoystickDevice(i, 0, 0));
				this.joysticks[i].Description = LegacyJoystickDriver.DisconnectedName;
			}
		}

		// Token: 0x06005990 RID: 22928 RVA: 0x000F33B8 File Offset: 0x000F15B8
		public void Poll()
		{
			for (int i = 0; i < 4; i++)
			{
				JoystickCapabilities capabilities = Joystick.GetCapabilities(i);
				if (capabilities.IsConnected && this.joysticks[i].Description == LegacyJoystickDriver.DisconnectedName)
				{
					this.joysticks[i] = new LegacyJoystickDriver.LegacyJoystickDevice(i, capabilities.AxisCount + 2 * capabilities.HatCount, capabilities.ButtonCount);
					this.joysticks[i].Description = LegacyJoystickDriver.ConnectedName;
				}
				else if (!capabilities.IsConnected && this.joysticks[i].Description != LegacyJoystickDriver.DisconnectedName)
				{
					this.joysticks[i] = new LegacyJoystickDriver.LegacyJoystickDevice(i, 0, 0);
					this.joysticks[i].Description = LegacyJoystickDriver.DisconnectedName;
				}
				JoystickState state = Joystick.GetState(i);
				for (int j = 0; j < capabilities.AxisCount; j++)
				{
					JoystickAxis axis = (JoystickAxis)j;
					this.joysticks[i].SetAxis(axis, state.GetAxis(axis));
				}
				for (int k = 0; k < capabilities.ButtonCount; k++)
				{
					JoystickButton button = (JoystickButton)k;
					this.joysticks[i].SetButton(button, state.GetButton(button) == ButtonState.Pressed);
				}
				for (int l = 0; l < capabilities.HatCount; l++)
				{
					int num = capabilities.AxisCount + 2 * l;
					if (num < 11)
					{
						JoystickHat hat = (JoystickHat)l;
						JoystickHatState hat2 = state.GetHat(hat);
						JoystickAxis joystickAxis = (JoystickAxis)num;
						float num2 = 0f;
						float num3 = 0f;
						if (hat2.IsDown)
						{
							num3 -= 1f;
						}
						if (hat2.IsUp)
						{
							num3 += 1f;
						}
						if (hat2.IsLeft)
						{
							num2 -= 1f;
						}
						if (hat2.IsRight)
						{
							num2 += 1f;
						}
						this.joysticks[i].SetAxis(joystickAxis, num2);
						this.joysticks[i].SetAxis(joystickAxis + 1, num3);
					}
				}
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06005991 RID: 22929 RVA: 0x000F35D4 File Offset: 0x000F17D4
		public IList<JoystickDevice> Joysticks
		{
			get
			{
				this.Poll();
				return this.joysticks_readonly;
			}
		}

		// Token: 0x0400B4C8 RID: 46280
		private static readonly string ConnectedName = "Connected Joystick";

		// Token: 0x0400B4C9 RID: 46281
		private static readonly string DisconnectedName = "Disconnected Joystick";

		// Token: 0x0400B4CA RID: 46282
		private readonly List<JoystickDevice> joysticks = new List<JoystickDevice>();

		// Token: 0x0400B4CB RID: 46283
		private readonly IList<JoystickDevice> joysticks_readonly;

		// Token: 0x02000B05 RID: 2821
		private class LegacyJoystickDevice : JoystickDevice
		{
			// Token: 0x06005993 RID: 22931 RVA: 0x000F35FC File Offset: 0x000F17FC
			public LegacyJoystickDevice(int id, int axes, int buttons) : base(id, axes, buttons)
			{
			}
		}
	}
}
