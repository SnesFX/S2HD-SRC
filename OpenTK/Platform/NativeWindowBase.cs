using System;
using System.ComponentModel;
using System.Drawing;
using OpenTK.Input;

namespace OpenTK.Platform
{
	// Token: 0x020000D3 RID: 211
	internal abstract class NativeWindowBase : INativeWindow, IDisposable
	{
		// Token: 0x0600084B RID: 2123 RVA: 0x0001B18C File Offset: 0x0001938C
		internal NativeWindowBase()
		{
			this.LegacyInputDriver = new LegacyInputDriver(this);
			this.MouseState.SetIsConnected(true);
			this.KeyboardState.SetIsConnected(true);
			this.PreviousMouseState.SetIsConnected(true);
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0001B500 File Offset: 0x00019700
		protected void OnMove(EventArgs e)
		{
			this.Move(this, e);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x0001B510 File Offset: 0x00019710
		protected void OnResize(EventArgs e)
		{
			this.Resize(this, e);
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x0001B520 File Offset: 0x00019720
		protected void OnClosing(CancelEventArgs e)
		{
			this.Closing(this, e);
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0001B530 File Offset: 0x00019730
		protected void OnClosed(EventArgs e)
		{
			this.Closed(this, e);
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0001B540 File Offset: 0x00019740
		protected void OnDisposed(EventArgs e)
		{
			this.Disposed(this, e);
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0001B550 File Offset: 0x00019750
		protected void OnIconChanged(EventArgs e)
		{
			this.IconChanged(this, e);
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0001B560 File Offset: 0x00019760
		protected void OnTitleChanged(EventArgs e)
		{
			this.TitleChanged(this, e);
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0001B570 File Offset: 0x00019770
		protected void OnVisibleChanged(EventArgs e)
		{
			this.VisibleChanged(this, e);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0001B580 File Offset: 0x00019780
		protected void OnFocusedChanged(EventArgs e)
		{
			this.FocusedChanged(this, e);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0001B590 File Offset: 0x00019790
		protected void OnWindowBorderChanged(EventArgs e)
		{
			this.WindowBorderChanged(this, e);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0001B5A0 File Offset: 0x000197A0
		protected void OnWindowStateChanged(EventArgs e)
		{
			this.WindowStateChanged(this, e);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0001B5B0 File Offset: 0x000197B0
		protected void OnKeyDown(Key key, bool repeat)
		{
			this.KeyboardState.SetKeyState(key, true);
			KeyboardKeyEventArgs keyDownArgs = this.KeyDownArgs;
			keyDownArgs.Keyboard = this.KeyboardState;
			keyDownArgs.Key = key;
			keyDownArgs.IsRepeat = repeat;
			this.KeyDown(this, keyDownArgs);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0001B5F8 File Offset: 0x000197F8
		protected void OnKeyPress(char c)
		{
			KeyPressEventArgs keyPressArgs = this.KeyPressArgs;
			keyPressArgs.KeyChar = c;
			this.KeyPress(this, keyPressArgs);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0001B620 File Offset: 0x00019820
		protected void OnKeyUp(Key key)
		{
			this.KeyboardState.SetKeyState(key, false);
			KeyboardKeyEventArgs keyUpArgs = this.KeyUpArgs;
			keyUpArgs.Keyboard = this.KeyboardState;
			keyUpArgs.Key = key;
			keyUpArgs.IsRepeat = false;
			this.KeyUp(this, keyUpArgs);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0001B668 File Offset: 0x00019868
		protected void UpdateModifierFlags(KeyModifiers mods)
		{
			bool flag = (byte)(mods & KeyModifiers.Alt) != 0;
			bool flag2 = (byte)(mods & KeyModifiers.Control) != 0;
			bool flag3 = (byte)(mods & KeyModifiers.Shift) != 0;
			if (flag)
			{
				this.OnKeyDown(Key.AltLeft, this.KeyboardState[Key.AltLeft]);
				this.OnKeyDown(Key.AltRight, this.KeyboardState[Key.AltLeft]);
			}
			else
			{
				if (this.KeyboardState[Key.AltLeft])
				{
					this.OnKeyUp(Key.AltLeft);
				}
				if (this.KeyboardState[Key.AltRight])
				{
					this.OnKeyUp(Key.AltRight);
				}
			}
			if (flag2)
			{
				this.OnKeyDown(Key.ControlLeft, this.KeyboardState[Key.AltLeft]);
				this.OnKeyDown(Key.ControlRight, this.KeyboardState[Key.AltLeft]);
			}
			else
			{
				if (this.KeyboardState[Key.ControlLeft])
				{
					this.OnKeyUp(Key.ControlLeft);
				}
				if (this.KeyboardState[Key.ControlRight])
				{
					this.OnKeyUp(Key.ControlRight);
				}
			}
			if (flag3)
			{
				this.OnKeyDown(Key.ShiftLeft, this.KeyboardState[Key.AltLeft]);
				this.OnKeyDown(Key.ShiftRight, this.KeyboardState[Key.AltLeft]);
				return;
			}
			if (this.KeyboardState[Key.ShiftLeft])
			{
				this.OnKeyUp(Key.ShiftLeft);
			}
			if (this.KeyboardState[Key.ShiftRight])
			{
				this.OnKeyUp(Key.ShiftRight);
			}
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0001B794 File Offset: 0x00019994
		protected void OnMouseLeave(EventArgs e)
		{
			this.MouseLeave(this, e);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0001B7A4 File Offset: 0x000199A4
		protected void OnMouseEnter(EventArgs e)
		{
			this.MouseEnter(this, e);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0001B7B4 File Offset: 0x000199B4
		protected void OnMouseDown(MouseButton button)
		{
			this.MouseState[button] = true;
			MouseButtonEventArgs mouseDownArgs = this.MouseDownArgs;
			mouseDownArgs.Button = button;
			mouseDownArgs.IsPressed = true;
			mouseDownArgs.Mouse = this.MouseState;
			this.MouseDown(this, mouseDownArgs);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0001B7FC File Offset: 0x000199FC
		protected void OnMouseUp(MouseButton button)
		{
			this.MouseState[button] = false;
			MouseButtonEventArgs mouseUpArgs = this.MouseUpArgs;
			mouseUpArgs.Button = button;
			mouseUpArgs.IsPressed = false;
			mouseUpArgs.Mouse = this.MouseState;
			this.MouseUp(this, mouseUpArgs);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0001B844 File Offset: 0x00019A44
		protected void OnMouseMove(int x, int y)
		{
			this.MouseState.X = x;
			this.MouseState.Y = y;
			MouseMoveEventArgs mouseMoveArgs = this.MouseMoveArgs;
			mouseMoveArgs.Mouse = this.MouseState;
			mouseMoveArgs.XDelta = this.MouseState.X - this.PreviousMouseState.X;
			mouseMoveArgs.YDelta = this.MouseState.Y - this.PreviousMouseState.Y;
			if (mouseMoveArgs.XDelta == 0 && mouseMoveArgs.YDelta == 0)
			{
				return;
			}
			this.PreviousMouseState = this.MouseState;
			this.MouseMove(this, mouseMoveArgs);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0001B8E0 File Offset: 0x00019AE0
		protected void OnMouseWheel(float dx, float dy)
		{
			this.MouseState.SetScrollRelative(dx, dy);
			MouseWheelEventArgs mouseWheelArgs = this.MouseWheelArgs;
			mouseWheelArgs.Mouse = this.MouseState;
			mouseWheelArgs.DeltaPrecise = this.MouseState.Scroll.Y - this.PreviousMouseState.Scroll.Y;
			if (dx == 0f && dy == 0f)
			{
				return;
			}
			this.PreviousMouseState = this.MouseState;
			this.MouseWheel(this, mouseWheelArgs);
		}

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06000861 RID: 2145 RVA: 0x0001B964 File Offset: 0x00019B64
		// (remove) Token: 0x06000862 RID: 2146 RVA: 0x0001B99C File Offset: 0x00019B9C
		public event EventHandler<EventArgs> Move = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000863 RID: 2147 RVA: 0x0001B9D4 File Offset: 0x00019BD4
		// (remove) Token: 0x06000864 RID: 2148 RVA: 0x0001BA0C File Offset: 0x00019C0C
		public event EventHandler<EventArgs> Resize = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06000865 RID: 2149 RVA: 0x0001BA44 File Offset: 0x00019C44
		// (remove) Token: 0x06000866 RID: 2150 RVA: 0x0001BA7C File Offset: 0x00019C7C
		public event EventHandler<CancelEventArgs> Closing = delegate(object param0, CancelEventArgs param1)
		{
		};

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06000867 RID: 2151 RVA: 0x0001BAB4 File Offset: 0x00019CB4
		// (remove) Token: 0x06000868 RID: 2152 RVA: 0x0001BAEC File Offset: 0x00019CEC
		public event EventHandler<EventArgs> Closed = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x06000869 RID: 2153 RVA: 0x0001BB24 File Offset: 0x00019D24
		// (remove) Token: 0x0600086A RID: 2154 RVA: 0x0001BB5C File Offset: 0x00019D5C
		public event EventHandler<EventArgs> Disposed = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x0600086B RID: 2155 RVA: 0x0001BB94 File Offset: 0x00019D94
		// (remove) Token: 0x0600086C RID: 2156 RVA: 0x0001BBCC File Offset: 0x00019DCC
		public event EventHandler<EventArgs> IconChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x0600086D RID: 2157 RVA: 0x0001BC04 File Offset: 0x00019E04
		// (remove) Token: 0x0600086E RID: 2158 RVA: 0x0001BC3C File Offset: 0x00019E3C
		public event EventHandler<EventArgs> TitleChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x0600086F RID: 2159 RVA: 0x0001BC74 File Offset: 0x00019E74
		// (remove) Token: 0x06000870 RID: 2160 RVA: 0x0001BCAC File Offset: 0x00019EAC
		public event EventHandler<EventArgs> VisibleChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06000871 RID: 2161 RVA: 0x0001BCE4 File Offset: 0x00019EE4
		// (remove) Token: 0x06000872 RID: 2162 RVA: 0x0001BD1C File Offset: 0x00019F1C
		public event EventHandler<EventArgs> FocusedChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x06000873 RID: 2163 RVA: 0x0001BD54 File Offset: 0x00019F54
		// (remove) Token: 0x06000874 RID: 2164 RVA: 0x0001BD8C File Offset: 0x00019F8C
		public event EventHandler<EventArgs> WindowBorderChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x06000875 RID: 2165 RVA: 0x0001BDC4 File Offset: 0x00019FC4
		// (remove) Token: 0x06000876 RID: 2166 RVA: 0x0001BDFC File Offset: 0x00019FFC
		public event EventHandler<EventArgs> WindowStateChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x06000877 RID: 2167 RVA: 0x0001BE34 File Offset: 0x0001A034
		// (remove) Token: 0x06000878 RID: 2168 RVA: 0x0001BE6C File Offset: 0x0001A06C
		public event EventHandler<KeyboardKeyEventArgs> KeyDown = delegate(object param0, KeyboardKeyEventArgs param1)
		{
		};

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x06000879 RID: 2169 RVA: 0x0001BEA4 File Offset: 0x0001A0A4
		// (remove) Token: 0x0600087A RID: 2170 RVA: 0x0001BEDC File Offset: 0x0001A0DC
		public event EventHandler<KeyPressEventArgs> KeyPress = delegate(object param0, KeyPressEventArgs param1)
		{
		};

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x0600087B RID: 2171 RVA: 0x0001BF14 File Offset: 0x0001A114
		// (remove) Token: 0x0600087C RID: 2172 RVA: 0x0001BF4C File Offset: 0x0001A14C
		public event EventHandler<KeyboardKeyEventArgs> KeyUp = delegate(object param0, KeyboardKeyEventArgs param1)
		{
		};

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x0600087D RID: 2173 RVA: 0x0001BF84 File Offset: 0x0001A184
		// (remove) Token: 0x0600087E RID: 2174 RVA: 0x0001BFBC File Offset: 0x0001A1BC
		public event EventHandler<EventArgs> MouseLeave = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x0600087F RID: 2175 RVA: 0x0001BFF4 File Offset: 0x0001A1F4
		// (remove) Token: 0x06000880 RID: 2176 RVA: 0x0001C02C File Offset: 0x0001A22C
		public event EventHandler<EventArgs> MouseEnter = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x06000881 RID: 2177 RVA: 0x0001C064 File Offset: 0x0001A264
		// (remove) Token: 0x06000882 RID: 2178 RVA: 0x0001C09C File Offset: 0x0001A29C
		public event EventHandler<MouseButtonEventArgs> MouseDown = delegate(object param0, MouseButtonEventArgs param1)
		{
		};

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06000883 RID: 2179 RVA: 0x0001C0D4 File Offset: 0x0001A2D4
		// (remove) Token: 0x06000884 RID: 2180 RVA: 0x0001C10C File Offset: 0x0001A30C
		public event EventHandler<MouseButtonEventArgs> MouseUp = delegate(object param0, MouseButtonEventArgs param1)
		{
		};

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06000885 RID: 2181 RVA: 0x0001C144 File Offset: 0x0001A344
		// (remove) Token: 0x06000886 RID: 2182 RVA: 0x0001C17C File Offset: 0x0001A37C
		public event EventHandler<MouseMoveEventArgs> MouseMove = delegate(object param0, MouseMoveEventArgs param1)
		{
		};

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06000887 RID: 2183 RVA: 0x0001C1B4 File Offset: 0x0001A3B4
		// (remove) Token: 0x06000888 RID: 2184 RVA: 0x0001C1EC File Offset: 0x0001A3EC
		public event EventHandler<MouseWheelEventArgs> MouseWheel = delegate(object param0, MouseWheelEventArgs param1)
		{
		};

		// Token: 0x06000889 RID: 2185
		public abstract void Close();

		// Token: 0x0600088A RID: 2186 RVA: 0x0001C224 File Offset: 0x0001A424
		public virtual void ProcessEvents()
		{
			if (!this.Focused)
			{
				for (Key key = Key.Unknown; key < Key.LastKey; key++)
				{
					if (this.KeyboardState[key])
					{
						this.OnKeyUp(key);
					}
				}
			}
		}

		// Token: 0x0600088B RID: 2187
		public abstract Point PointToClient(Point point);

		// Token: 0x0600088C RID: 2188
		public abstract Point PointToScreen(Point point);

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x0600088D RID: 2189
		// (set) Token: 0x0600088E RID: 2190
		public abstract Icon Icon { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600088F RID: 2191
		// (set) Token: 0x06000890 RID: 2192
		public abstract string Title { get; set; }

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000891 RID: 2193
		public abstract bool Focused { get; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000892 RID: 2194
		// (set) Token: 0x06000893 RID: 2195
		public abstract bool Visible { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000894 RID: 2196
		public abstract bool Exists { get; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000895 RID: 2197
		public abstract IWindowInfo WindowInfo { get; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000896 RID: 2198
		// (set) Token: 0x06000897 RID: 2199
		public abstract WindowState WindowState { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000898 RID: 2200
		// (set) Token: 0x06000899 RID: 2201
		public abstract WindowBorder WindowBorder { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600089A RID: 2202
		// (set) Token: 0x0600089B RID: 2203
		public abstract Rectangle Bounds { get; set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600089C RID: 2204 RVA: 0x0001C260 File Offset: 0x0001A460
		// (set) Token: 0x0600089D RID: 2205 RVA: 0x0001C27C File Offset: 0x0001A47C
		public virtual Point Location
		{
			get
			{
				return this.Bounds.Location;
			}
			set
			{
				this.Bounds = new Rectangle(value, this.Bounds.Size);
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600089E RID: 2206 RVA: 0x0001C2A4 File Offset: 0x0001A4A4
		// (set) Token: 0x0600089F RID: 2207 RVA: 0x0001C2C0 File Offset: 0x0001A4C0
		public virtual Size Size
		{
			get
			{
				return this.Bounds.Size;
			}
			set
			{
				this.Bounds = new Rectangle(this.Bounds.Location, value);
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x0001C2E8 File Offset: 0x0001A4E8
		// (set) Token: 0x060008A1 RID: 2209 RVA: 0x0001C304 File Offset: 0x0001A504
		public int X
		{
			get
			{
				return this.Bounds.X;
			}
			set
			{
				Rectangle bounds = this.Bounds;
				this.Bounds = new Rectangle(value, bounds.Y, bounds.Width, bounds.Height);
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060008A2 RID: 2210 RVA: 0x0001C33C File Offset: 0x0001A53C
		// (set) Token: 0x060008A3 RID: 2211 RVA: 0x0001C358 File Offset: 0x0001A558
		public int Y
		{
			get
			{
				return this.Bounds.Y;
			}
			set
			{
				Rectangle bounds = this.Bounds;
				this.Bounds = new Rectangle(bounds.X, value, bounds.Width, bounds.Height);
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x0001C390 File Offset: 0x0001A590
		// (set) Token: 0x060008A5 RID: 2213 RVA: 0x0001C3AC File Offset: 0x0001A5AC
		public int Width
		{
			get
			{
				return this.ClientSize.Width;
			}
			set
			{
				Rectangle clientRectangle = this.ClientRectangle;
				this.ClientRectangle = new Rectangle(clientRectangle.X, clientRectangle.Y, value, clientRectangle.Height);
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x0001C3E4 File Offset: 0x0001A5E4
		// (set) Token: 0x060008A7 RID: 2215 RVA: 0x0001C400 File Offset: 0x0001A600
		public int Height
		{
			get
			{
				return this.ClientSize.Height;
			}
			set
			{
				Rectangle clientRectangle = this.ClientRectangle;
				this.Bounds = new Rectangle(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, value);
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x0001C438 File Offset: 0x0001A638
		// (set) Token: 0x060008A9 RID: 2217 RVA: 0x0001C44C File Offset: 0x0001A64C
		public Rectangle ClientRectangle
		{
			get
			{
				return new Rectangle(Point.Empty, this.ClientSize);
			}
			set
			{
				this.ClientSize = value.Size;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060008AA RID: 2218
		// (set) Token: 0x060008AB RID: 2219
		public abstract Size ClientSize { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x0001C45C File Offset: 0x0001A65C
		public virtual IInputDriver InputDriver
		{
			get
			{
				return this.LegacyInputDriver;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060008AD RID: 2221
		// (set) Token: 0x060008AE RID: 2222
		public abstract bool CursorVisible { get; set; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060008AF RID: 2223
		// (set) Token: 0x060008B0 RID: 2224
		public abstract MouseCursor Cursor { get; set; }

		// Token: 0x060008B1 RID: 2225 RVA: 0x0001C464 File Offset: 0x0001A664
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060008B2 RID: 2226
		protected abstract void Dispose(bool disposing);

		// Token: 0x060008B3 RID: 2227 RVA: 0x0001C474 File Offset: 0x0001A674
		~NativeWindowBase()
		{
			this.Dispose(false);
		}

		// Token: 0x040006DF RID: 1759
		private readonly LegacyInputDriver LegacyInputDriver;

		// Token: 0x040006E0 RID: 1760
		private readonly MouseButtonEventArgs MouseDownArgs = new MouseButtonEventArgs();

		// Token: 0x040006E1 RID: 1761
		private readonly MouseButtonEventArgs MouseUpArgs = new MouseButtonEventArgs();

		// Token: 0x040006E2 RID: 1762
		private readonly MouseMoveEventArgs MouseMoveArgs = new MouseMoveEventArgs();

		// Token: 0x040006E3 RID: 1763
		private readonly MouseWheelEventArgs MouseWheelArgs = new MouseWheelEventArgs();

		// Token: 0x040006E4 RID: 1764
		private readonly KeyboardKeyEventArgs KeyDownArgs = new KeyboardKeyEventArgs();

		// Token: 0x040006E5 RID: 1765
		private readonly KeyboardKeyEventArgs KeyUpArgs = new KeyboardKeyEventArgs();

		// Token: 0x040006E6 RID: 1766
		private readonly KeyPressEventArgs KeyPressArgs = new KeyPressEventArgs('\0');

		// Token: 0x040006E7 RID: 1767
		protected MouseState MouseState = default(MouseState);

		// Token: 0x040006E8 RID: 1768
		protected KeyboardState KeyboardState = default(KeyboardState);

		// Token: 0x040006E9 RID: 1769
		private MouseState PreviousMouseState = default(MouseState);
	}
}
