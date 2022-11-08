using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000133 RID: 307
	internal class X11KeyMap
	{
		// Token: 0x06000AEB RID: 2795 RVA: 0x00024584 File Offset: 0x00022784
		internal X11KeyMap(IntPtr display)
		{
			this.xkb_supported = Xkb.IsSupported(display);
			if (this.xkb_supported)
			{
				this.RefreshKeycodes(display);
			}
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x000245B8 File Offset: 0x000227B8
		internal unsafe void RefreshKeycodes(IntPtr display)
		{
			if (this.xkb_supported)
			{
				XkbDesc* ptr = Xkb.AllocKeyboard(display);
				if (ptr != null)
				{
					Xkb.GetNames(display, XkbNamesMask.All, ptr);
					for (int i = 0; i < this.keycodes.Length; i++)
					{
						this.keycodes[i] = Key.Unknown;
					}
					int j = (int)ptr->min_key_code;
					while (j <= (int)ptr->max_key_code)
					{
						string text = new string((sbyte*)(&ptr->names->keys[j].name.FixedElementField), 0, 4);
						string key;
						if ((key = text) == null)
						{
							goto IL_55E;
						}
						if (<PrivateImplementationDetails>{EB13C4F1-476E-4662-B262-4D6929497D91}.$$method0x6000aa6-1 == null)
						{
							<PrivateImplementationDetails>{EB13C4F1-476E-4662-B262-4D6929497D91}.$$method0x6000aa6-1 = new Dictionary<string, int>(48)
							{
								{
									"TLDE",
									0
								},
								{
									"AE01",
									1
								},
								{
									"AE02",
									2
								},
								{
									"AE03",
									3
								},
								{
									"AE04",
									4
								},
								{
									"AE05",
									5
								},
								{
									"AE06",
									6
								},
								{
									"AE07",
									7
								},
								{
									"AE08",
									8
								},
								{
									"AE09",
									9
								},
								{
									"AE10",
									10
								},
								{
									"AE11",
									11
								},
								{
									"AE12",
									12
								},
								{
									"AD01",
									13
								},
								{
									"AD02",
									14
								},
								{
									"AD03",
									15
								},
								{
									"AD04",
									16
								},
								{
									"AD05",
									17
								},
								{
									"AD06",
									18
								},
								{
									"AD07",
									19
								},
								{
									"AD08",
									20
								},
								{
									"AD09",
									21
								},
								{
									"AD10",
									22
								},
								{
									"AD11",
									23
								},
								{
									"AD12",
									24
								},
								{
									"AC01",
									25
								},
								{
									"AC02",
									26
								},
								{
									"AC03",
									27
								},
								{
									"AC04",
									28
								},
								{
									"AC05",
									29
								},
								{
									"AC06",
									30
								},
								{
									"AC07",
									31
								},
								{
									"AC08",
									32
								},
								{
									"AC09",
									33
								},
								{
									"AC10",
									34
								},
								{
									"AC11",
									35
								},
								{
									"AB01",
									36
								},
								{
									"AB02",
									37
								},
								{
									"AB03",
									38
								},
								{
									"AB04",
									39
								},
								{
									"AB05",
									40
								},
								{
									"AB06",
									41
								},
								{
									"AB07",
									42
								},
								{
									"AB08",
									43
								},
								{
									"AB09",
									44
								},
								{
									"AB10",
									45
								},
								{
									"BKSL",
									46
								},
								{
									"LSGT",
									47
								}
							};
						}
						int num;
						if (!<PrivateImplementationDetails>{EB13C4F1-476E-4662-B262-4D6929497D91}.$$method0x6000aa6-1.TryGetValue(key, out num))
						{
							goto IL_55E;
						}
						Key key2;
						switch (num)
						{
						case 0:
							key2 = Key.Tilde;
							break;
						case 1:
							key2 = Key.Number1;
							break;
						case 2:
							key2 = Key.Number2;
							break;
						case 3:
							key2 = Key.Number3;
							break;
						case 4:
							key2 = Key.Number4;
							break;
						case 5:
							key2 = Key.Number5;
							break;
						case 6:
							key2 = Key.Number6;
							break;
						case 7:
							key2 = Key.Number7;
							break;
						case 8:
							key2 = Key.Number8;
							break;
						case 9:
							key2 = Key.Number9;
							break;
						case 10:
							key2 = Key.Number0;
							break;
						case 11:
							key2 = Key.Minus;
							break;
						case 12:
							key2 = Key.Plus;
							break;
						case 13:
							key2 = Key.Q;
							break;
						case 14:
							key2 = Key.W;
							break;
						case 15:
							key2 = Key.E;
							break;
						case 16:
							key2 = Key.R;
							break;
						case 17:
							key2 = Key.T;
							break;
						case 18:
							key2 = Key.Y;
							break;
						case 19:
							key2 = Key.U;
							break;
						case 20:
							key2 = Key.I;
							break;
						case 21:
							key2 = Key.O;
							break;
						case 22:
							key2 = Key.P;
							break;
						case 23:
							key2 = Key.BracketLeft;
							break;
						case 24:
							key2 = Key.BracketRight;
							break;
						case 25:
							key2 = Key.A;
							break;
						case 26:
							key2 = Key.S;
							break;
						case 27:
							key2 = Key.D;
							break;
						case 28:
							key2 = Key.F;
							break;
						case 29:
							key2 = Key.G;
							break;
						case 30:
							key2 = Key.H;
							break;
						case 31:
							key2 = Key.J;
							break;
						case 32:
							key2 = Key.K;
							break;
						case 33:
							key2 = Key.L;
							break;
						case 34:
							key2 = Key.Semicolon;
							break;
						case 35:
							key2 = Key.Quote;
							break;
						case 36:
							key2 = Key.Z;
							break;
						case 37:
							key2 = Key.X;
							break;
						case 38:
							key2 = Key.C;
							break;
						case 39:
							key2 = Key.V;
							break;
						case 40:
							key2 = Key.B;
							break;
						case 41:
							key2 = Key.N;
							break;
						case 42:
							key2 = Key.M;
							break;
						case 43:
							key2 = Key.Comma;
							break;
						case 44:
							key2 = Key.Period;
							break;
						case 45:
							key2 = Key.Slash;
							break;
						case 46:
							key2 = Key.BackSlash;
							break;
						case 47:
							key2 = Key.Unknown;
							break;
						default:
							goto IL_55E;
						}
						IL_561:
						this.keycodes[j] = key2;
						j++;
						continue;
						IL_55E:
						key2 = Key.Unknown;
						goto IL_561;
					}
					Xkb.FreeKeyboard(ptr, 0, true);
				}
			}
			for (int k = 0; k < 256; k++)
			{
				if (this.keycodes[k] == Key.Unknown)
				{
					XKeyEvent xkeyEvent = default(XKeyEvent);
					xkeyEvent.display = display;
					xkeyEvent.keycode = k;
					Key key3 = Key.Unknown;
					if (this.TranslateKeyEvent(ref xkeyEvent, out key3))
					{
						this.keycodes[k] = key3;
					}
				}
			}
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x00024B9C File Offset: 0x00022D9C
		private static Key TranslateXKey(XKey key)
		{
			if (key <= XKey.Return)
			{
				if (key <= XKey.ISO_Level3_Shift)
				{
					switch (key)
					{
					case XKey.space:
						return Key.Space;
					case XKey.exclam:
					case XKey.numbersign:
					case XKey.dollar:
					case XKey.percent:
					case XKey.ampersand:
					case XKey.parenleft:
					case XKey.parenright:
					case XKey.asterisk:
					case XKey.at:
					case XKey.asciicircum:
					case XKey.underscore:
						break;
					case XKey.quotedbl:
						return Key.Quote;
					case XKey.apostrophe:
						return Key.Quote;
					case XKey.plus:
						return Key.Plus;
					case XKey.comma:
						return Key.Comma;
					case XKey.minus:
						return Key.Minus;
					case XKey.period:
						return Key.Period;
					case XKey.slash:
						return Key.Slash;
					case XKey.Number0:
						return Key.Number0;
					case XKey.Number1:
						return Key.Number1;
					case XKey.Number2:
						return Key.Number2;
					case XKey.Number3:
						return Key.Number3;
					case XKey.Number4:
						return Key.Number4;
					case XKey.Number5:
						return Key.Number5;
					case XKey.Number6:
						return Key.Number6;
					case XKey.Number7:
						return Key.Number7;
					case XKey.Number8:
						return Key.Number8;
					case XKey.Number9:
						return Key.Number9;
					case XKey.colon:
						return Key.Semicolon;
					case XKey.semicolon:
						return Key.Semicolon;
					case XKey.less:
						return Key.Comma;
					case XKey.equal:
						return Key.Plus;
					case XKey.greater:
						return Key.Period;
					case XKey.question:
						return Key.Slash;
					case XKey.A:
					case XKey.a:
						return Key.A;
					case XKey.B:
					case XKey.b:
						return Key.B;
					case XKey.C:
					case XKey.c:
						return Key.C;
					case XKey.D:
					case XKey.d:
						return Key.D;
					case XKey.E:
					case XKey.e:
						return Key.E;
					case XKey.F:
					case XKey.f:
						return Key.F;
					case XKey.G:
					case XKey.g:
						return Key.G;
					case XKey.H:
					case XKey.h:
						return Key.H;
					case XKey.I:
					case XKey.i:
						return Key.I;
					case XKey.J:
					case XKey.j:
						return Key.J;
					case XKey.K:
					case XKey.k:
						return Key.K;
					case XKey.L:
					case XKey.l:
						return Key.L;
					case XKey.M:
					case XKey.m:
						return Key.M;
					case XKey.N:
					case XKey.n:
						return Key.N;
					case XKey.O:
					case XKey.o:
						return Key.O;
					case XKey.P:
					case XKey.p:
						return Key.P;
					case XKey.Q:
					case XKey.q:
						return Key.Q;
					case XKey.R:
					case XKey.r:
						return Key.R;
					case XKey.S:
					case XKey.s:
						return Key.S;
					case XKey.T:
					case XKey.t:
						return Key.T;
					case XKey.U:
					case XKey.u:
						return Key.U;
					case XKey.V:
					case XKey.v:
						return Key.V;
					case XKey.W:
					case XKey.w:
						return Key.W;
					case XKey.X:
					case XKey.x:
						return Key.X;
					case XKey.Y:
					case XKey.y:
						return Key.Y;
					case XKey.Z:
					case XKey.z:
						return Key.Z;
					case XKey.bracketleft:
						return Key.BracketLeft;
					case XKey.backslash:
						return Key.BackSlash;
					case XKey.bracketright:
						return Key.BracketRight;
					case XKey.grave:
						return Key.Tilde;
					case XKey.braceleft:
						return Key.BracketLeft;
					case XKey.bar:
						return Key.BackSlash;
					case XKey.braceright:
						return Key.BracketRight;
					case XKey.asciitilde:
						return Key.Tilde;
					default:
						if (key == XKey.ISO_Level3_Shift)
						{
							return Key.AltRight;
						}
						break;
					}
				}
				else
				{
					switch (key)
					{
					case XKey.BackSpace:
						return Key.BackSpace;
					case XKey.Tab:
						return Key.Tab;
					default:
						if (key == XKey.Return)
						{
							return Key.Enter;
						}
						break;
					}
				}
			}
			else if (key <= XKey.Escape)
			{
				switch (key)
				{
				case XKey.Pause:
					return Key.Pause;
				case XKey.Scroll_Lock:
					return Key.Pause;
				case XKey.Sys_Req:
					return Key.PrintScreen;
				default:
					if (key == XKey.Escape)
					{
						return Key.Escape;
					}
					break;
				}
			}
			else
			{
				switch (key)
				{
				case XKey.Home:
					return Key.Home;
				case XKey.Left:
					return Key.Left;
				case XKey.Up:
					return Key.Up;
				case XKey.Right:
					return Key.Right;
				case XKey.Down:
					return Key.Down;
				case XKey.Prior:
					return Key.PageUp;
				case XKey.Next:
					return Key.PageDown;
				case XKey.End:
					return Key.End;
				case XKey.Begin:
				case (XKey)65369:
				case (XKey)65370:
				case (XKey)65371:
				case (XKey)65372:
				case (XKey)65373:
				case (XKey)65374:
				case (XKey)65375:
				case XKey.Select:
				case XKey.Execute:
				case (XKey)65380:
				case XKey.Undo:
				case XKey.Redo:
				case XKey.Find:
				case XKey.Cancel:
				case XKey.Help:
				case (XKey)65388:
				case (XKey)65389:
				case (XKey)65390:
				case (XKey)65391:
				case (XKey)65392:
				case (XKey)65393:
				case (XKey)65394:
				case (XKey)65395:
				case (XKey)65396:
				case (XKey)65397:
				case (XKey)65398:
				case (XKey)65399:
				case (XKey)65400:
				case (XKey)65401:
				case (XKey)65402:
				case (XKey)65403:
				case (XKey)65404:
				case (XKey)65405:
				case XKey.Mode_switch:
				case XKey.KP_Space:
				case (XKey)65409:
				case (XKey)65410:
				case (XKey)65411:
				case (XKey)65412:
				case (XKey)65413:
				case (XKey)65414:
				case (XKey)65415:
				case (XKey)65416:
				case XKey.KP_Tab:
				case (XKey)65418:
				case (XKey)65419:
				case (XKey)65420:
				case (XKey)65422:
				case (XKey)65423:
				case (XKey)65424:
				case XKey.KP_F1:
				case XKey.KP_F2:
				case XKey.KP_F3:
				case XKey.KP_F4:
				case XKey.KP_Begin:
				case (XKey)65440:
				case (XKey)65441:
				case (XKey)65442:
				case (XKey)65443:
				case (XKey)65444:
				case (XKey)65445:
				case (XKey)65446:
				case (XKey)65447:
				case (XKey)65448:
				case (XKey)65449:
				case XKey.KP_Separator:
				case (XKey)65466:
				case (XKey)65467:
				case (XKey)65468:
				case XKey.KP_Equal:
				case XKey.Shift_Lock:
					break;
				case XKey.Print:
					return Key.PrintScreen;
				case XKey.Insert:
					return Key.PrintScreen;
				case XKey.Menu:
					return Key.Menu;
				case XKey.Break:
					return Key.Pause;
				case XKey.Num_Lock:
					return Key.NumLock;
				case XKey.KP_Enter:
					return Key.KeypadEnter;
				case XKey.KP_Home:
					return Key.Keypad7;
				case XKey.KP_Left:
					return Key.Keypad4;
				case XKey.KP_Up:
					return Key.Keypad8;
				case XKey.KP_Right:
					return Key.Keypad6;
				case XKey.KP_Down:
					return Key.Keypad2;
				case XKey.KP_Prior:
					return Key.Keypad9;
				case XKey.KP_Next:
					return Key.Keypad3;
				case XKey.KP_End:
					return Key.Keypad1;
				case XKey.KP_Insert:
					return Key.Keypad0;
				case XKey.KP_Delete:
					return Key.KeypadDecimal;
				case XKey.KP_Multiply:
					return Key.KeypadMultiply;
				case XKey.KP_Add:
					return Key.KeypadAdd;
				case XKey.KP_Subtract:
					return Key.KeypadSubtract;
				case XKey.KP_Decimal:
					return Key.KeypadDecimal;
				case XKey.KP_Divide:
					return Key.KeypadDivide;
				case XKey.KP_0:
					return Key.Keypad0;
				case XKey.KP_1:
					return Key.Keypad1;
				case XKey.KP_2:
					return Key.Keypad2;
				case XKey.KP_3:
					return Key.Keypad3;
				case XKey.KP_4:
					return Key.Keypad4;
				case XKey.KP_5:
					return Key.Keypad5;
				case XKey.KP_6:
					return Key.Keypad6;
				case XKey.KP_7:
					return Key.Keypad7;
				case XKey.KP_8:
					return Key.Keypad8;
				case XKey.KP_9:
					return Key.Keypad9;
				case XKey.F1:
					return Key.F1;
				case XKey.F2:
					return Key.F2;
				case XKey.F3:
					return Key.F3;
				case XKey.F4:
					return Key.F4;
				case XKey.F5:
					return Key.F5;
				case XKey.F6:
					return Key.F6;
				case XKey.F7:
					return Key.F7;
				case XKey.F8:
					return Key.F8;
				case XKey.F9:
					return Key.F9;
				case XKey.F10:
					return Key.F10;
				case XKey.F11:
					return Key.F11;
				case XKey.F12:
					return Key.F12;
				case XKey.F13:
					return Key.F13;
				case XKey.F14:
					return Key.F14;
				case XKey.F15:
					return Key.F15;
				case XKey.F16:
					return Key.F16;
				case XKey.F17:
					return Key.F17;
				case XKey.F18:
					return Key.F18;
				case XKey.F19:
					return Key.F19;
				case XKey.F20:
					return Key.F20;
				case XKey.F21:
					return Key.F21;
				case XKey.F22:
					return Key.F22;
				case XKey.F23:
					return Key.F23;
				case XKey.F24:
					return Key.F24;
				case XKey.F25:
					return Key.F25;
				case XKey.F26:
					return Key.F26;
				case XKey.F27:
					return Key.F27;
				case XKey.F28:
					return Key.F28;
				case XKey.F29:
					return Key.F29;
				case XKey.F30:
					return Key.F30;
				case XKey.F31:
					return Key.F31;
				case XKey.F32:
					return Key.F32;
				case XKey.F33:
					return Key.F33;
				case XKey.F34:
					return Key.F34;
				case XKey.F35:
					return Key.F35;
				case XKey.Shift_L:
					return Key.ShiftLeft;
				case XKey.Shift_R:
					return Key.ShiftRight;
				case XKey.Control_L:
					return Key.ControlLeft;
				case XKey.Control_R:
					return Key.ControlRight;
				case XKey.Caps_Lock:
					return Key.CapsLock;
				case XKey.Meta_L:
					return Key.WinLeft;
				case XKey.Meta_R:
					return Key.WinRight;
				case XKey.Alt_L:
					return Key.AltLeft;
				case XKey.Alt_R:
					return Key.AltRight;
				case XKey.Super_L:
					return Key.WinLeft;
				case XKey.Super_R:
					return Key.WinRight;
				default:
					if (key == XKey.Delete)
					{
						return Key.Delete;
					}
					break;
				}
			}
			return Key.Unknown;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00025204 File Offset: 0x00023404
		private bool TranslateKeyEvent(ref XKeyEvent e, out Key key)
		{
			if (this.xkb_supported)
			{
				return this.TranslateKeyXkb(e.display, e.keycode, out key);
			}
			return this.TranslateKeyX11(ref e, out key);
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0002522C File Offset: 0x0002342C
		private bool TranslateKeyX11(ref XKeyEvent e, out Key key)
		{
			XKey key2 = (XKey)((int)API.LookupKeysym(ref e, 0));
			XKey key3 = (XKey)((int)API.LookupKeysym(ref e, 1));
			key = X11KeyMap.TranslateXKey(key2);
			if (key == Key.Unknown)
			{
				key = X11KeyMap.TranslateXKey(key3);
			}
			Key key4 = key;
			return key != Key.Unknown;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00025274 File Offset: 0x00023474
		private bool TranslateKeyXkb(IntPtr display, int keycode, out Key key)
		{
			if (keycode < 8 || keycode > 255)
			{
				key = Key.Unknown;
				return false;
			}
			XKey xkey = Xkb.KeycodeToKeysym(display, keycode, 0, 1);
			XKey xkey2 = xkey;
			if (xkey2 != XKey.KP_Enter)
			{
				switch (xkey2)
				{
				case XKey.KP_Separator:
				case XKey.KP_Decimal:
					key = Key.KeypadDecimal;
					return true;
				case XKey.KP_0:
					key = Key.Keypad0;
					return true;
				case XKey.KP_1:
					key = Key.Keypad1;
					return true;
				case XKey.KP_2:
					key = Key.Keypad2;
					return true;
				case XKey.KP_3:
					key = Key.Keypad3;
					return true;
				case XKey.KP_4:
					key = Key.Keypad4;
					return true;
				case XKey.KP_5:
					key = Key.Keypad5;
					return true;
				case XKey.KP_6:
					key = Key.Keypad6;
					return true;
				case XKey.KP_7:
					key = Key.Keypad7;
					return true;
				case XKey.KP_8:
					key = Key.Keypad8;
					return true;
				case XKey.KP_9:
					key = Key.Keypad9;
					return true;
				case XKey.KP_Equal:
					key = Key.Unknown;
					return false;
				}
				xkey = Xkb.KeycodeToKeysym(display, keycode, 0, 0);
				key = X11KeyMap.TranslateXKey(xkey);
				return key != Key.Unknown;
			}
			key = Key.KeypadEnter;
			return true;
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00025368 File Offset: 0x00023568
		internal bool TranslateKey(int keycode, out Key key)
		{
			if (keycode < 0 || keycode > 255)
			{
				key = Key.Unknown;
			}
			else
			{
				key = this.keycodes[keycode];
			}
			return key != Key.Unknown;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00025390 File Offset: 0x00023590
		internal bool TranslateKey(ref XKeyEvent e, out Key key)
		{
			return this.TranslateKey(e.keycode, out key);
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x000253A0 File Offset: 0x000235A0
		internal static MouseButton TranslateButton(int button, out float wheelx, out float wheely)
		{
			wheelx = 0f;
			wheely = 0f;
			switch (button)
			{
			case 1:
				return MouseButton.Left;
			case 2:
				return MouseButton.Middle;
			case 3:
				return MouseButton.Right;
			case 4:
				wheely = 1f;
				return MouseButton.LastButton;
			case 5:
				wheely = -1f;
				return MouseButton.LastButton;
			case 6:
				wheelx = 1f;
				return MouseButton.LastButton;
			case 7:
				wheelx = -1f;
				return MouseButton.LastButton;
			case 8:
				return MouseButton.Button1;
			case 9:
				return MouseButton.Button2;
			case 10:
				return MouseButton.Button3;
			case 11:
				return MouseButton.Button4;
			case 12:
				return MouseButton.Button5;
			case 13:
				return MouseButton.Button6;
			case 14:
				return MouseButton.Button7;
			default:
				return MouseButton.LastButton;
			}
		}

		// Token: 0x04000C32 RID: 3122
		private readonly Key[] keycodes = new Key[256];

		// Token: 0x04000C33 RID: 3123
		private readonly bool xkb_supported;
	}
}
