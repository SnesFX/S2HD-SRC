using System;
using OpenTK.Input;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200058C RID: 1420
	internal sealed class X11Keyboard : IKeyboardDriver2
	{
		// Token: 0x06004599 RID: 17817 RVA: 0x000BF018 File Offset: 0x000BD218
		public X11Keyboard()
		{
			this.state.IsConnected = true;
			IntPtr defaultDisplay = API.DefaultDisplay;
			using (new XLock(defaultDisplay))
			{
				int num = 0;
				int num2 = 0;
				API.DisplayKeycodes(defaultDisplay, ref num, ref num2);
				IntPtr keyboardMapping = API.GetKeyboardMapping(defaultDisplay, (byte)num, num2 - num + 1, ref this.KeysymsPerKeycode);
				Functions.XFree(keyboardMapping);
				if (Xkb.IsSupported(defaultDisplay))
				{
					bool flag;
					Xkb.SetDetectableAutoRepeat(defaultDisplay, true, out flag);
					this.KeyMap = new X11KeyMap(defaultDisplay);
				}
			}
		}

		// Token: 0x0600459A RID: 17818 RVA: 0x000BF0C8 File Offset: 0x000BD2C8
		public KeyboardState GetState()
		{
			this.ProcessEvents();
			return this.state;
		}

		// Token: 0x0600459B RID: 17819 RVA: 0x000BF0D8 File Offset: 0x000BD2D8
		public KeyboardState GetState(int index)
		{
			this.ProcessEvents();
			if (index == 0)
			{
				return this.state;
			}
			return default(KeyboardState);
		}

		// Token: 0x0600459C RID: 17820 RVA: 0x000BF100 File Offset: 0x000BD300
		public string GetDeviceName(int index)
		{
			if (index == 0)
			{
				return X11Keyboard.name;
			}
			return string.Empty;
		}

		// Token: 0x0600459D RID: 17821 RVA: 0x000BF110 File Offset: 0x000BD310
		private void ProcessEvents()
		{
			IntPtr defaultDisplay = API.DefaultDisplay;
			using (new XLock(defaultDisplay))
			{
				Functions.XQueryKeymap(defaultDisplay, this.keys);
				for (int i = 0; i < 256; i++)
				{
					bool value = (this.keys[i >> 3] >> (i & 7) & 1) != 0;
					Key key;
					if (this.KeyMap.TranslateKey(i, out key))
					{
						this.state[key] = value;
					}
				}
			}
		}

		// Token: 0x04005094 RID: 20628
		private static readonly string name = "Core X11 keyboard";

		// Token: 0x04005095 RID: 20629
		private readonly byte[] keys = new byte[32];

		// Token: 0x04005096 RID: 20630
		private readonly int KeysymsPerKeycode;

		// Token: 0x04005097 RID: 20631
		private readonly X11KeyMap KeyMap;

		// Token: 0x04005098 RID: 20632
		private KeyboardState state = default(KeyboardState);
	}
}
