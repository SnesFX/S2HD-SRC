using System;
using OpenTK.Input;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000BA5 RID: 2981
	internal class Evdev
	{
		// Token: 0x06005C9D RID: 23709 RVA: 0x000FAF34 File Offset: 0x000F9134
		public static MouseButton GetMouseButton(EvdevButton button)
		{
			switch (button)
			{
			case EvdevButton.MISC:
				return MouseButton.Button1;
			case EvdevButton.BTN1:
				return MouseButton.Button2;
			case EvdevButton.BTN2:
				return MouseButton.Button3;
			case EvdevButton.BTN3:
				return MouseButton.Button4;
			case EvdevButton.BTN4:
				return MouseButton.Button5;
			case EvdevButton.BTN5:
				return MouseButton.Button6;
			case EvdevButton.BTN6:
				return MouseButton.Button7;
			case EvdevButton.BTN7:
				return MouseButton.Button8;
			case EvdevButton.BTN8:
				return MouseButton.Button9;
			case EvdevButton.MOUSE:
				return MouseButton.Left;
			case EvdevButton.RIGHT:
				return MouseButton.Right;
			case EvdevButton.MIDDLE:
				return MouseButton.Middle;
			}
			return MouseButton.Left;
		}

		// Token: 0x06005C9F RID: 23711 RVA: 0x000FAFC4 File Offset: 0x000F91C4
		// Note: this type is marked as 'beforefieldinit'.
		static Evdev()
		{
			Key[] array = new Key[256];
			array[1] = Key.Escape;
			array[2] = Key.Number1;
			array[3] = Key.Number2;
			array[4] = Key.Number3;
			array[5] = Key.Number4;
			array[6] = Key.Number5;
			array[7] = Key.Number6;
			array[8] = Key.Number7;
			array[9] = Key.Number8;
			array[10] = Key.Number9;
			array[11] = Key.Number0;
			array[12] = Key.Minus;
			array[13] = Key.Plus;
			array[14] = Key.BackSpace;
			array[15] = Key.Tab;
			array[16] = Key.Q;
			array[17] = Key.W;
			array[18] = Key.E;
			array[19] = Key.R;
			array[20] = Key.T;
			array[21] = Key.Y;
			array[22] = Key.U;
			array[23] = Key.I;
			array[24] = Key.O;
			array[25] = Key.P;
			array[26] = Key.BracketLeft;
			array[27] = Key.BracketRight;
			array[28] = Key.Enter;
			array[29] = Key.ControlLeft;
			array[30] = Key.A;
			array[31] = Key.S;
			array[32] = Key.D;
			array[33] = Key.F;
			array[34] = Key.G;
			array[35] = Key.H;
			array[36] = Key.J;
			array[37] = Key.K;
			array[38] = Key.L;
			array[39] = Key.Semicolon;
			array[40] = Key.Quote;
			array[41] = Key.Tilde;
			array[42] = Key.ShiftLeft;
			array[43] = Key.BackSlash;
			array[44] = Key.Z;
			array[45] = Key.X;
			array[46] = Key.C;
			array[47] = Key.V;
			array[48] = Key.B;
			array[49] = Key.N;
			array[50] = Key.M;
			array[51] = Key.Comma;
			array[52] = Key.Period;
			array[53] = Key.Slash;
			array[54] = Key.ShiftRight;
			array[55] = Key.KeypadMultiply;
			array[56] = Key.AltLeft;
			array[57] = Key.Space;
			array[58] = Key.CapsLock;
			array[59] = Key.F1;
			array[60] = Key.F2;
			array[61] = Key.F3;
			array[62] = Key.F4;
			array[63] = Key.F5;
			array[64] = Key.F6;
			array[65] = Key.F7;
			array[66] = Key.F8;
			array[67] = Key.F9;
			array[68] = Key.F10;
			array[69] = Key.NumLock;
			array[70] = Key.ScrollLock;
			array[71] = Key.Keypad7;
			array[72] = Key.Keypad8;
			array[73] = Key.Keypad9;
			array[74] = Key.KeypadSubtract;
			array[75] = Key.Keypad4;
			array[76] = Key.Keypad5;
			array[77] = Key.Keypad6;
			array[78] = Key.KeypadAdd;
			array[79] = Key.Keypad1;
			array[80] = Key.Keypad2;
			array[81] = Key.Keypad3;
			array[82] = Key.Keypad0;
			array[83] = Key.KeypadDecimal;
			array[87] = Key.F11;
			array[88] = Key.F12;
			array[96] = Key.KeypadEnter;
			array[97] = Key.ControlRight;
			array[98] = Key.KeypadDivide;
			array[100] = Key.AltRight;
			array[102] = Key.Home;
			array[103] = Key.Up;
			array[104] = Key.PageUp;
			array[105] = Key.Left;
			array[106] = Key.Right;
			array[107] = Key.End;
			array[108] = Key.Down;
			array[109] = Key.PageDown;
			array[110] = Key.Insert;
			array[111] = Key.Delete;
			array[119] = Key.Pause;
			array[125] = Key.WinLeft;
			array[126] = Key.WinRight;
			array[158] = Key.BackSpace;
			array[183] = Key.F13;
			array[184] = Key.F14;
			array[185] = Key.F15;
			array[186] = Key.F16;
			array[187] = Key.F17;
			array[188] = Key.F18;
			array[189] = Key.F19;
			array[190] = Key.F20;
			array[191] = Key.F21;
			array[192] = Key.F22;
			array[193] = Key.F23;
			array[194] = Key.F24;
			Evdev.KeyMap = array;
		}

		// Token: 0x0400B975 RID: 47477
		public static readonly Key[] KeyMap;
	}
}
