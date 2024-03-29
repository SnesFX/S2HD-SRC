﻿using System;
using OpenTK.Input;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A5 RID: 1445
	internal class Sdl2KeyMap
	{
		// Token: 0x0600462B RID: 17963 RVA: 0x000C1708 File Offset: 0x000BF908
		public static Key GetKey(Scancode code)
		{
			switch (code)
			{
			case Scancode.A:
				return Key.A;
			case Scancode.B:
				return Key.B;
			case Scancode.C:
				return Key.C;
			case Scancode.D:
				return Key.D;
			case Scancode.E:
				return Key.E;
			case Scancode.F:
				return Key.F;
			case Scancode.G:
				return Key.G;
			case Scancode.H:
				return Key.H;
			case Scancode.I:
				return Key.I;
			case Scancode.J:
				return Key.J;
			case Scancode.K:
				return Key.K;
			case Scancode.L:
				return Key.L;
			case Scancode.M:
				return Key.M;
			case Scancode.N:
				return Key.N;
			case Scancode.O:
				return Key.O;
			case Scancode.P:
				return Key.P;
			case Scancode.Q:
				return Key.Q;
			case Scancode.R:
				return Key.R;
			case Scancode.S:
				return Key.S;
			case Scancode.T:
				return Key.T;
			case Scancode.U:
				return Key.U;
			case Scancode.V:
				return Key.V;
			case Scancode.W:
				return Key.W;
			case Scancode.X:
				return Key.X;
			case Scancode.Y:
				return Key.Y;
			case Scancode.Z:
				return Key.Z;
			case Scancode.Num1:
				return Key.Number1;
			case Scancode.Num2:
				return Key.Number2;
			case Scancode.Num3:
				return Key.Number3;
			case Scancode.Num4:
				return Key.Number4;
			case Scancode.Num5:
				return Key.Number5;
			case Scancode.Num6:
				return Key.Number6;
			case Scancode.Num7:
				return Key.Number7;
			case Scancode.Num8:
				return Key.Number8;
			case Scancode.Num9:
				return Key.Number9;
			case Scancode.Num0:
				return Key.Number0;
			case Scancode.RETURN:
				return Key.Enter;
			case Scancode.ESCAPE:
				return Key.Escape;
			case Scancode.BACKSPACE:
				return Key.BackSpace;
			case Scancode.TAB:
				return Key.Tab;
			case Scancode.SPACE:
				return Key.Space;
			case Scancode.MINUS:
				return Key.Minus;
			case Scancode.EQUALS:
				return Key.Plus;
			case Scancode.LEFTBRACKET:
				return Key.BracketLeft;
			case Scancode.RIGHTBRACKET:
				return Key.BracketRight;
			case Scancode.BACKSLASH:
				return Key.BackSlash;
			case Scancode.NONUSHASH:
			case Scancode.KP_ENTER:
			case Scancode.KP_PERIOD:
			case Scancode.NONUSBACKSLASH:
			case Scancode.POWER:
			case Scancode.KP_EQUALS:
			case Scancode.EXECUTE:
			case Scancode.HELP:
			case Scancode.SELECT:
			case Scancode.STOP:
			case Scancode.AGAIN:
			case Scancode.UNDO:
			case Scancode.CUT:
			case Scancode.COPY:
			case Scancode.PASTE:
			case Scancode.FIND:
			case Scancode.MUTE:
			case Scancode.VOLUMEUP:
			case Scancode.VOLUMEDOWN:
			case (Scancode)130:
			case (Scancode)131:
			case (Scancode)132:
			case Scancode.KP_COMMA:
			case Scancode.KP_EQUALSAS400:
			case Scancode.INTERNATIONAL1:
			case Scancode.INTERNATIONAL2:
			case Scancode.INTERNATIONAL3:
			case Scancode.INTERNATIONAL4:
			case Scancode.INTERNATIONAL5:
			case Scancode.INTERNATIONAL6:
			case Scancode.INTERNATIONAL7:
			case Scancode.INTERNATIONAL8:
			case Scancode.INTERNATIONAL9:
			case Scancode.LANG1:
			case Scancode.LANG2:
			case Scancode.LANG3:
			case Scancode.LANG4:
			case Scancode.LANG5:
			case Scancode.LANG6:
			case Scancode.LANG7:
			case Scancode.LANG8:
			case Scancode.LANG9:
			case Scancode.ALTERASE:
			case Scancode.SYSREQ:
			case Scancode.CANCEL:
			case Scancode.PRIOR:
			case Scancode.RETURN2:
			case Scancode.SEPARATOR:
			case Scancode.OUT:
			case Scancode.OPER:
			case Scancode.CLEARAGAIN:
			case Scancode.CRSEL:
			case Scancode.EXSEL:
			case (Scancode)165:
			case (Scancode)166:
			case (Scancode)167:
			case (Scancode)168:
			case (Scancode)169:
			case (Scancode)170:
			case (Scancode)171:
			case (Scancode)172:
			case (Scancode)173:
			case (Scancode)174:
			case (Scancode)175:
			case Scancode.KP_00:
			case Scancode.KP_000:
			case Scancode.THOUSANDSSEPARATOR:
			case Scancode.DECIMALSEPARATOR:
			case Scancode.CURRENCYUNIT:
			case Scancode.CURRENCYSUBUNIT:
			case Scancode.KP_LEFTPAREN:
			case Scancode.KP_RIGHTPAREN:
			case Scancode.KP_LEFTBRACE:
			case Scancode.KP_RIGHTBRACE:
			case Scancode.KP_TAB:
			case Scancode.KP_BACKSPACE:
			case Scancode.KP_A:
			case Scancode.KP_B:
			case Scancode.KP_C:
			case Scancode.KP_D:
			case Scancode.KP_E:
			case Scancode.KP_F:
			case Scancode.KP_XOR:
			case Scancode.KP_POWER:
			case Scancode.KP_PERCENT:
			case Scancode.KP_LESS:
			case Scancode.KP_GREATER:
			case Scancode.KP_AMPERSAND:
			case Scancode.KP_DBLAMPERSAND:
			case Scancode.KP_VERTICALBAR:
			case Scancode.KP_DBLVERTICALBAR:
			case Scancode.KP_COLON:
			case Scancode.KP_HASH:
			case Scancode.KP_SPACE:
			case Scancode.KP_AT:
			case Scancode.KP_EXCLAM:
			case Scancode.KP_MEMSTORE:
			case Scancode.KP_MEMRECALL:
			case Scancode.KP_MEMCLEAR:
			case Scancode.KP_MEMADD:
			case Scancode.KP_MEMSUBTRACT:
			case Scancode.KP_MEMMULTIPLY:
			case Scancode.KP_MEMDIVIDE:
			case Scancode.KP_PLUSMINUS:
			case Scancode.KP_CLEAR:
			case Scancode.KP_CLEARENTRY:
			case Scancode.KP_BINARY:
			case Scancode.KP_OCTAL:
			case Scancode.KP_HEXADECIMAL:
			case (Scancode)222:
			case (Scancode)223:
				break;
			case Scancode.SEMICOLON:
				return Key.Semicolon;
			case Scancode.APOSTROPHE:
				return Key.Quote;
			case Scancode.GRAVE:
				return Key.Tilde;
			case Scancode.COMMA:
				return Key.Comma;
			case Scancode.PERIOD:
				return Key.Period;
			case Scancode.SLASH:
				return Key.Slash;
			case Scancode.CAPSLOCK:
				return Key.CapsLock;
			case Scancode.F1:
				return Key.F1;
			case Scancode.F2:
				return Key.F2;
			case Scancode.F3:
				return Key.F3;
			case Scancode.F4:
				return Key.F4;
			case Scancode.F5:
				return Key.F5;
			case Scancode.F6:
				return Key.F6;
			case Scancode.F7:
				return Key.F7;
			case Scancode.F8:
				return Key.F8;
			case Scancode.F9:
				return Key.F9;
			case Scancode.F10:
				return Key.F10;
			case Scancode.F11:
				return Key.F11;
			case Scancode.F12:
				return Key.F12;
			case Scancode.PRINTSCREEN:
				return Key.PrintScreen;
			case Scancode.SCROLLLOCK:
				return Key.ScrollLock;
			case Scancode.PAUSE:
				return Key.Pause;
			case Scancode.INSERT:
				return Key.Insert;
			case Scancode.HOME:
				return Key.Home;
			case Scancode.PAGEUP:
				return Key.PageUp;
			case Scancode.DELETE:
				return Key.Delete;
			case Scancode.END:
				return Key.End;
			case Scancode.PAGEDOWN:
				return Key.PageDown;
			case Scancode.RIGHT:
				return Key.Right;
			case Scancode.LEFT:
				return Key.Left;
			case Scancode.DOWN:
				return Key.Down;
			case Scancode.UP:
				return Key.Up;
			case Scancode.NUMLOCKCLEAR:
				return Key.NumLock;
			case Scancode.KP_DIVIDE:
				return Key.KeypadDivide;
			case Scancode.KP_MULTIPLY:
				return Key.KeypadMultiply;
			case Scancode.KP_MINUS:
				return Key.KeypadSubtract;
			case Scancode.KP_PLUS:
				return Key.KeypadAdd;
			case Scancode.KP_1:
				return Key.Keypad1;
			case Scancode.KP_2:
				return Key.Keypad2;
			case Scancode.KP_3:
				return Key.Keypad3;
			case Scancode.KP_4:
				return Key.Keypad4;
			case Scancode.KP_5:
				return Key.Keypad5;
			case Scancode.KP_6:
				return Key.Keypad6;
			case Scancode.KP_7:
				return Key.Keypad7;
			case Scancode.KP_8:
				return Key.Keypad8;
			case Scancode.KP_9:
				return Key.Keypad9;
			case Scancode.KP_0:
				return Key.Keypad0;
			case Scancode.APPLICATION:
				return Key.Menu;
			case Scancode.F13:
				return Key.F13;
			case Scancode.F14:
				return Key.F14;
			case Scancode.F15:
				return Key.F15;
			case Scancode.F16:
				return Key.F16;
			case Scancode.F17:
				return Key.F17;
			case Scancode.F18:
				return Key.F18;
			case Scancode.F19:
				return Key.F19;
			case Scancode.F20:
				return Key.F20;
			case Scancode.F21:
				return Key.F21;
			case Scancode.F22:
				return Key.F22;
			case Scancode.F23:
				return Key.F23;
			case Scancode.F24:
				return Key.F24;
			case Scancode.MENU:
				return Key.Menu;
			case Scancode.CLEAR:
				return Key.Clear;
			case Scancode.KP_DECIMAL:
				return Key.KeypadDecimal;
			case Scancode.LCTRL:
				return Key.ControlLeft;
			case Scancode.LSHIFT:
				return Key.ShiftLeft;
			case Scancode.LALT:
				return Key.AltLeft;
			case Scancode.LGUI:
				return Key.WinLeft;
			case Scancode.RCTRL:
				return Key.ControlRight;
			case Scancode.RSHIFT:
				return Key.ShiftRight;
			case Scancode.RALT:
				return Key.AltRight;
			case Scancode.RGUI:
				return Key.WinRight;
			default:
				if (code == Scancode.SLEEP)
				{
					return Key.Sleep;
				}
				break;
			}
			return Key.Unknown;
		}

		// Token: 0x0600462C RID: 17964 RVA: 0x000C1C20 File Offset: 0x000BFE20
		public static KeyModifiers GetModifiers(Keymod mod)
		{
			KeyModifiers keyModifiers = (KeyModifiers)0;
			keyModifiers |= (((ushort)(mod & Keymod.ALT) != 0) ? KeyModifiers.Alt : ((KeyModifiers)0));
			keyModifiers |= (((ushort)(mod & Keymod.CTRL) != 0) ? KeyModifiers.Control : ((KeyModifiers)0));
			return keyModifiers | (((ushort)(mod & Keymod.SHIFT) != 0) ? KeyModifiers.Shift : ((KeyModifiers)0));
		}
	}
}
