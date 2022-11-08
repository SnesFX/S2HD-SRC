using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A6 RID: 1446
	internal class Sdl2Keyboard : IKeyboardDriver2
	{
		// Token: 0x0600462E RID: 17966 RVA: 0x000C1C6C File Offset: 0x000BFE6C
		public Sdl2Keyboard()
		{
			this.state.IsConnected = true;
		}

		// Token: 0x0600462F RID: 17967 RVA: 0x000C1C8C File Offset: 0x000BFE8C
		private void UpdateModifiers()
		{
			Keymod modState = SDL.GetModState();
			this.state[Key.AltLeft] = ((ushort)(modState & Keymod.LALT) != 0);
			this.state[Key.AltRight] = ((ushort)(modState & Keymod.RALT) != 0);
			this.state[Key.ControlLeft] = ((ushort)(modState & Keymod.LCTRL) != 0);
			this.state[Key.ControlRight] = ((ushort)(modState & Keymod.RCTRL) != 0);
			this.state[Key.ShiftLeft] = ((ushort)(modState & Keymod.LSHIFT) != 0);
			this.state[Key.ShiftRight] = ((ushort)(modState & Keymod.RSHIFT) != 0);
			this.state[Key.Menu] = ((ushort)(modState & Keymod.GUI) != 0);
			this.state[Key.CapsLock] = ((ushort)(modState & Keymod.CAPS) != 0);
			this.state[Key.NumLock] = ((ushort)(modState & Keymod.NUM) != 0);
		}

		// Token: 0x06004630 RID: 17968 RVA: 0x000C1D84 File Offset: 0x000BFF84
		internal void ProcessKeyboardEvent(KeyboardEvent e)
		{
			bool value = e.State != State.Released;
			Scancode scancode = e.Keysym.Scancode;
			Key key = Sdl2KeyMap.GetKey(scancode);
			Sdl2KeyMap.GetModifiers(e.Keysym.Mod);
			if (key != Key.Unknown)
			{
				this.state[key] = value;
			}
		}

		// Token: 0x06004631 RID: 17969 RVA: 0x000C1DD8 File Offset: 0x000BFFD8
		public KeyboardState GetState()
		{
			return this.state;
		}

		// Token: 0x06004632 RID: 17970 RVA: 0x000C1DE0 File Offset: 0x000BFFE0
		public KeyboardState GetState(int index)
		{
			if (index == 0)
			{
				return this.state;
			}
			return default(KeyboardState);
		}

		// Token: 0x06004633 RID: 17971 RVA: 0x000C1E00 File Offset: 0x000C0000
		public string GetDeviceName(int index)
		{
			return "SDL2 Default Keyboard";
		}

		// Token: 0x0400521E RID: 21022
		private KeyboardState state;

		// Token: 0x0400521F RID: 21023
		private readonly List<KeyboardDevice> keyboards = new List<KeyboardDevice>();

		// Token: 0x04005220 RID: 21024
		private readonly IList<KeyboardDevice> keyboards_readonly;
	}
}
