using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using OpenTK.Input;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A8 RID: 1448
	internal class Sdl2NativeWindow : NativeWindowBase
	{
		// Token: 0x0600463E RID: 17982 RVA: 0x000C1FF0 File Offset: 0x000C01F0
		public Sdl2NativeWindow(int x, int y, int width, int height, string title, GameWindowFlags options, DisplayDevice device)
		{
			lock (this.sync)
			{
				Rectangle bounds = device.Bounds;
				WindowFlags windowFlags = Sdl2NativeWindow.TranslateFlags(options);
				windowFlags |= WindowFlags.OPENGL;
				windowFlags |= WindowFlags.HIDDEN;
				if (Toolkit.Options.EnableHighResolution)
				{
					windowFlags |= WindowFlags.ALLOW_HIGHDPI;
				}
				if ((windowFlags & WindowFlags.FULLSCREEN_DESKTOP) != WindowFlags.Default || (windowFlags & WindowFlags.FULLSCREEN) != WindowFlags.Default)
				{
					this.window_state = WindowState.Fullscreen;
				}
				if ((windowFlags & WindowFlags.RESIZABLE) == WindowFlags.Default)
				{
					this.window_border = WindowBorder.Fixed;
				}
				IntPtr handle;
				lock (SDL.Sync)
				{
					handle = SDL.CreateWindow(title, bounds.Left + x, bounds.Top + y, width, height, windowFlags);
					this.exists = true;
				}
				this.ProcessEvents();
				this.window = new Sdl2WindowInfo(handle, null);
				this.window_id = SDL.GetWindowID(handle);
				Sdl2NativeWindow.windows.Add(this.window_id, this);
				this.window_title = title;
			}
		}

		// Token: 0x0600463F RID: 17983 RVA: 0x000C212C File Offset: 0x000C032C
		private static WindowFlags TranslateFlags(GameWindowFlags flags)
		{
			WindowFlags windowFlags = WindowFlags.Default;
			if ((flags & GameWindowFlags.Fullscreen) != GameWindowFlags.Default)
			{
				if (Sdl2Factory.UseFullscreenDesktop)
				{
					windowFlags |= WindowFlags.FULLSCREEN_DESKTOP;
				}
				else
				{
					windowFlags |= WindowFlags.FULLSCREEN;
				}
			}
			if ((flags & GameWindowFlags.FixedWindow) == GameWindowFlags.Default)
			{
				windowFlags |= WindowFlags.RESIZABLE;
			}
			return windowFlags;
		}

		// Token: 0x06004640 RID: 17984 RVA: 0x000C2160 File Offset: 0x000C0360
		private static Key TranslateKey(Scancode scan)
		{
			return Sdl2KeyMap.GetKey(scan);
		}

		// Token: 0x06004641 RID: 17985 RVA: 0x000C2168 File Offset: 0x000C0368
		private static Key TranslateKey(Keycode key)
		{
			Scancode scancodeFromKey = SDL.GetScancodeFromKey(key);
			return Sdl2NativeWindow.TranslateKey(scancodeFromKey);
		}

		// Token: 0x06004642 RID: 17986 RVA: 0x000C2184 File Offset: 0x000C0384
		private int ProcessEvent(ref Event ev)
		{
			bool flag = false;
			try
			{
				Sdl2NativeWindow sdl2NativeWindow = null;
				EventType type = ev.Type;
				if (type <= EventType.WINDOWEVENT)
				{
					if (type != EventType.QUIT)
					{
						if (type == EventType.WINDOWEVENT)
						{
							if (Sdl2NativeWindow.windows.TryGetValue(ev.Window.WindowID, out sdl2NativeWindow))
							{
								Sdl2NativeWindow.ProcessWindowEvent(sdl2NativeWindow, ev.Window);
								flag = true;
							}
						}
					}
				}
				else
				{
					switch (type)
					{
					case EventType.KEYDOWN:
					case EventType.KEYUP:
						if (Sdl2NativeWindow.windows.TryGetValue(ev.Key.WindowID, out sdl2NativeWindow))
						{
							Sdl2NativeWindow.ProcessKeyEvent(sdl2NativeWindow, ev);
							flag = true;
						}
						break;
					case EventType.TEXTEDITING:
						break;
					case EventType.TEXTINPUT:
						if (Sdl2NativeWindow.windows.TryGetValue(ev.Text.WindowID, out sdl2NativeWindow))
						{
							Sdl2NativeWindow.ProcessTextInputEvent(sdl2NativeWindow, ev.Text);
							flag = true;
						}
						break;
					default:
						switch (type)
						{
						case EventType.MOUSEMOTION:
							if (Sdl2NativeWindow.windows.TryGetValue(ev.Motion.WindowID, out sdl2NativeWindow))
							{
								Sdl2NativeWindow.ProcessMouseMotionEvent(sdl2NativeWindow, ev.Motion);
								flag = true;
							}
							break;
						case EventType.MOUSEBUTTONDOWN:
						case EventType.MOUSEBUTTONUP:
							if (Sdl2NativeWindow.windows.TryGetValue(ev.Button.WindowID, out sdl2NativeWindow))
							{
								Sdl2NativeWindow.ProcessMouseButtonEvent(sdl2NativeWindow, ev.Button);
								flag = true;
							}
							break;
						case EventType.MOUSEWHEEL:
							if (Sdl2NativeWindow.windows.TryGetValue(ev.Wheel.WindowID, out sdl2NativeWindow))
							{
								Sdl2NativeWindow.ProcessMouseWheelEvent(sdl2NativeWindow, ev.Wheel);
								flag = true;
							}
							break;
						}
						break;
					}
				}
			}
			catch (Exception)
			{
			}
			if (!flag)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06004643 RID: 17987 RVA: 0x000C2324 File Offset: 0x000C0524
		private static void ProcessMouseButtonEvent(Sdl2NativeWindow window, MouseButtonEvent ev)
		{
			bool flag = ev.State == State.Pressed;
			if (window.CursorVisible)
			{
				SDL.SetWindowGrab(window.window.Handle, flag);
			}
			MouseButton button = Sdl2Mouse.TranslateButton(ev.Button);
			if (flag)
			{
				window.OnMouseDown(button);
				return;
			}
			window.OnMouseUp(button);
		}

		// Token: 0x06004644 RID: 17988 RVA: 0x000C237C File Offset: 0x000C057C
		private static void ProcessKeyEvent(Sdl2NativeWindow window, Event ev)
		{
			bool flag = ev.Key.State == State.Pressed;
			Key key = Sdl2NativeWindow.TranslateKey(ev.Key.Keysym.Scancode);
			if (flag)
			{
				window.OnKeyDown(key, ev.Key.Repeat > 0);
				return;
			}
			window.OnKeyUp(key);
		}

		// Token: 0x06004645 RID: 17989 RVA: 0x000C23D4 File Offset: 0x000C05D4
		private unsafe static void ProcessTextInputEvent(Sdl2NativeWindow window, TextInputEvent ev)
		{
			int num = 0;
			while (num < 32 && (&ev.Text.FixedElementField)[num] != 0)
			{
				num++;
			}
			int num2 = Encoding.UTF8.GetCharCount(&ev.Text.FixedElementField, num);
			if (window.DecodeTextBuffer.Length < num2)
			{
				Array.Resize<char>(ref window.DecodeTextBuffer, 2 * Math.Max(num2, window.DecodeTextBuffer.Length));
			}
			fixed (char* decodeTextBuffer = window.DecodeTextBuffer)
			{
				num2 = Encoding.UTF8.GetChars(&ev.Text.FixedElementField, num, decodeTextBuffer, window.DecodeTextBuffer.Length);
			}
			for (int i = 0; i < num2; i++)
			{
				window.OnKeyPress(window.DecodeTextBuffer[i]);
			}
		}

		// Token: 0x06004646 RID: 17990 RVA: 0x000C24A0 File Offset: 0x000C06A0
		private static void ProcessMouseMotionEvent(Sdl2NativeWindow window, MouseMotionEvent ev)
		{
			float num = (float)window.ClientSize.Width / (float)window.Size.Width;
			window.OnMouseMove((int)Math.Round((double)((float)ev.X * num)), (int)Math.Round((double)((float)ev.Y * num)));
		}

		// Token: 0x06004647 RID: 17991 RVA: 0x000C24F8 File Offset: 0x000C06F8
		private static void ProcessMouseWheelEvent(Sdl2NativeWindow window, MouseWheelEvent ev)
		{
			window.OnMouseWheel((float)ev.X, (float)ev.Y);
		}

		// Token: 0x06004648 RID: 17992 RVA: 0x000C2510 File Offset: 0x000C0710
		private static void ProcessWindowEvent(Sdl2NativeWindow window, WindowEvent e)
		{
			switch (e.Event)
			{
			case WindowEventID.SHOWN:
				window.is_visible = true;
				window.OnVisibleChanged(EventArgs.Empty);
				return;
			case WindowEventID.HIDDEN:
				window.is_visible = false;
				window.OnVisibleChanged(EventArgs.Empty);
				return;
			case WindowEventID.EXPOSED:
				break;
			case WindowEventID.MOVED:
				window.OnMove(EventArgs.Empty);
				return;
			case WindowEventID.RESIZED:
			case WindowEventID.SIZE_CHANGED:
				window.OnResize(EventArgs.Empty);
				break;
			case WindowEventID.MINIMIZED:
				window.previous_window_state = window.window_state;
				window.window_state = WindowState.Minimized;
				window.OnWindowStateChanged(EventArgs.Empty);
				return;
			case WindowEventID.MAXIMIZED:
				window.window_state = WindowState.Maximized;
				window.OnWindowStateChanged(EventArgs.Empty);
				return;
			case WindowEventID.RESTORED:
				window.window_state = window.previous_window_state;
				window.OnWindowStateChanged(EventArgs.Empty);
				return;
			case WindowEventID.ENTER:
				window.OnMouseEnter(EventArgs.Empty);
				return;
			case WindowEventID.LEAVE:
				window.OnMouseLeave(EventArgs.Empty);
				return;
			case WindowEventID.FOCUS_GAINED:
				window.is_focused = true;
				window.OnFocusedChanged(EventArgs.Empty);
				return;
			case WindowEventID.FOCUS_LOST:
				window.is_focused = false;
				window.OnFocusedChanged(EventArgs.Empty);
				return;
			case WindowEventID.CLOSE:
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				try
				{
					window.is_in_closing_event = true;
					window.OnClosing(cancelEventArgs);
				}
				finally
				{
					window.is_in_closing_event = false;
				}
				if (!cancelEventArgs.Cancel)
				{
					window.OnClosed(EventArgs.Empty);
					window.must_destroy = true;
					return;
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x06004649 RID: 17993 RVA: 0x000C267C File Offset: 0x000C087C
		private void DestroyWindow()
		{
			this.exists = false;
			if (this.window.Handle != IntPtr.Zero)
			{
				this.CursorVisible = true;
				lock (SDL.Sync)
				{
					if (Sdl2NativeWindow.windows.ContainsKey(this.window_id))
					{
						Sdl2NativeWindow.windows.Remove(this.window_id);
					}
					SDL.DestroyWindow(this.window.Handle);
				}
			}
			this.window_id = 0U;
			this.window.Handle = IntPtr.Zero;
		}

		// Token: 0x0600464A RID: 17994 RVA: 0x000C2720 File Offset: 0x000C0920
		private void GrabCursor(bool grab)
		{
			SDL.ShowCursor(!grab);
			SDL.SetWindowGrab(this.window.Handle, grab);
			SDL.SetRelativeMouseMode(grab);
			if (!grab)
			{
				float num = (float)base.Width / (float)this.Size.Width;
				SDL.WarpMouseInWindow(this.window.Handle, (int)Math.Round((double)((float)this.MouseState.X / num)), (int)Math.Round((double)((float)this.MouseState.Y / num)));
			}
		}

		// Token: 0x0600464B RID: 17995 RVA: 0x000C27A4 File Offset: 0x000C09A4
		private void HideShowWindowHack()
		{
			SDL.HideWindow(this.window.Handle);
			this.ProcessEvents();
			SDL.ShowWindow(this.window.Handle);
			this.ProcessEvents();
		}

		// Token: 0x0600464C RID: 17996 RVA: 0x000C27D4 File Offset: 0x000C09D4
		private void RestoreWindow()
		{
			switch (this.WindowState)
			{
			case WindowState.Minimized:
				SDL.RestoreWindow(this.window.Handle);
				break;
			case WindowState.Maximized:
				SDL.RestoreWindow(this.window.Handle);
				this.HideShowWindowHack();
				break;
			case WindowState.Fullscreen:
				SDL.SetWindowFullscreen(this.window.Handle, 0U);
				break;
			}
			this.ProcessEvents();
			this.window_state = WindowState.Normal;
		}

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x0600464D RID: 17997 RVA: 0x000C284C File Offset: 0x000C0A4C
		// (set) Token: 0x0600464E RID: 17998 RVA: 0x000C2854 File Offset: 0x000C0A54
		public unsafe override MouseCursor Cursor
		{
			get
			{
				return this.cursor;
			}
			set
			{
				lock (this.sync)
				{
					if (this.cursor != value)
					{
						if (this.sdl_cursor != IntPtr.Zero)
						{
							SDL.FreeCursor(this.sdl_cursor);
							this.sdl_cursor = IntPtr.Zero;
						}
						if (value == MouseCursor.Default)
						{
							SDL.SetCursor(SDL.GetDefaultCursor());
							this.cursor = value;
						}
						else
						{
							fixed (byte* ptr = value.Data)
							{
								IntPtr intPtr = SDL.CreateRGBSurfaceFrom(new IntPtr((void*)ptr), value.Width, value.Height, 32, value.Width * 4, 16711680U, 65280U, 255U, 4278190080U);
								if (!(intPtr == IntPtr.Zero))
								{
									this.sdl_cursor = SDL.CreateColorCursor(intPtr, value.X, value.Y);
									if (!(this.sdl_cursor == IntPtr.Zero))
									{
										if (this.sdl_cursor != IntPtr.Zero)
										{
											SDL.SetCursor(this.sdl_cursor);
											this.cursor = value;
										}
										if (intPtr != IntPtr.Zero)
										{
											SDL.FreeSurface(intPtr);
										}
										ptr = null;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600464F RID: 17999 RVA: 0x000C29B0 File Offset: 0x000C0BB0
		public override void Close()
		{
			lock (this.sync)
			{
				if (this.Exists && !this.must_destroy && !this.is_in_closing_event)
				{
					Event @event = default(Event);
					@event.Type = EventType.WINDOWEVENT;
					@event.Window.Event = WindowEventID.CLOSE;
					@event.Window.WindowID = this.window_id;
					lock (SDL.Sync)
					{
						SDL.PushEvent(ref @event);
					}
				}
			}
		}

		// Token: 0x06004650 RID: 18000 RVA: 0x000C2A5C File Offset: 0x000C0C5C
		public override void ProcessEvents()
		{
			base.ProcessEvents();
			lock (this.sync)
			{
				if (this.Exists)
				{
					SDL.PumpEvents();
					Event @event;
					while (SDL.PollEvent(out @event) > 0)
					{
						this.ProcessEvent(ref @event);
					}
					if (this.must_destroy)
					{
						this.DestroyWindow();
					}
				}
			}
		}

		// Token: 0x06004651 RID: 18001 RVA: 0x000C2AC8 File Offset: 0x000C0CC8
		public override Point PointToClient(Point point)
		{
			Point point2 = Point.Empty;
			DisplayDevice @default = DisplayDevice.Default;
			if (@default != null)
			{
				point2 = @default.Bounds.Location;
			}
			Point location = this.Location;
			return new Point(point.X + location.X - point2.X, point.Y + location.Y - point2.Y);
		}

		// Token: 0x06004652 RID: 18002 RVA: 0x000C2B30 File Offset: 0x000C0D30
		public override Point PointToScreen(Point point)
		{
			Point point2 = Point.Empty;
			DisplayDevice @default = DisplayDevice.Default;
			if (@default != null)
			{
				point2 = @default.Bounds.Location;
			}
			Point location = this.Location;
			return new Point(point.X + point2.X - location.X, point.Y + point2.Y - location.Y);
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06004653 RID: 18003 RVA: 0x000C2B98 File Offset: 0x000C0D98
		// (set) Token: 0x06004654 RID: 18004 RVA: 0x000C2BA0 File Offset: 0x000C0DA0
		public override Icon Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				lock (this.sync)
				{
					if (this.Exists)
					{
						if (value != null)
						{
							using (Bitmap bitmap = value.ToBitmap())
							{
								BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, value.Width, value.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
								IntPtr surface = SDL.CreateRGBSurfaceFrom(bitmapData.Scan0, bitmapData.Width, bitmapData.Height, 32, bitmapData.Stride, 16711680U, 65280U, 255U, 4278190080U);
								SDL.SetWindowIcon(this.window.Handle, surface);
								SDL.FreeSurface(surface);
								bitmap.UnlockBits(bitmapData);
								goto IL_B8;
							}
						}
						SDL.SetWindowIcon(this.window.Handle, IntPtr.Zero);
						IL_B8:
						this.icon = value;
						base.OnIconChanged(EventArgs.Empty);
					}
				}
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06004655 RID: 18005 RVA: 0x000C2C9C File Offset: 0x000C0E9C
		// (set) Token: 0x06004656 RID: 18006 RVA: 0x000C2CF4 File Offset: 0x000C0EF4
		public override string Title
		{
			get
			{
				string result;
				lock (this.sync)
				{
					if (this.Exists)
					{
						result = SDL.GetWindowTitle(this.window.Handle);
					}
					else
					{
						result = string.Empty;
					}
				}
				return result;
			}
			set
			{
				lock (this.sync)
				{
					if (this.Exists)
					{
						SDL.SetWindowTitle(this.window.Handle, value);
						this.window_title = value;
					}
				}
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06004657 RID: 18007 RVA: 0x000C2D48 File Offset: 0x000C0F48
		public override bool Focused
		{
			get
			{
				return this.is_focused;
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06004658 RID: 18008 RVA: 0x000C2D50 File Offset: 0x000C0F50
		// (set) Token: 0x06004659 RID: 18009 RVA: 0x000C2D58 File Offset: 0x000C0F58
		public override bool Visible
		{
			get
			{
				return this.is_visible;
			}
			set
			{
				lock (this.sync)
				{
					if (this.Exists)
					{
						if (value)
						{
							SDL.ShowWindow(this.window.Handle);
						}
						else
						{
							SDL.HideWindow(this.window.Handle);
						}
					}
				}
			}
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x0600465A RID: 18010 RVA: 0x000C2DB8 File Offset: 0x000C0FB8
		public override bool Exists
		{
			get
			{
				return this.exists;
			}
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x0600465B RID: 18011 RVA: 0x000C2DC0 File Offset: 0x000C0FC0
		public override IWindowInfo WindowInfo
		{
			get
			{
				return this.window;
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x0600465C RID: 18012 RVA: 0x000C2DC8 File Offset: 0x000C0FC8
		// (set) Token: 0x0600465D RID: 18013 RVA: 0x000C2DD0 File Offset: 0x000C0FD0
		public override WindowState WindowState
		{
			get
			{
				return this.window_state;
			}
			set
			{
				lock (this.sync)
				{
					if (this.Exists && this.WindowState != value)
					{
						switch (value)
						{
						case WindowState.Normal:
							this.RestoreWindow();
							break;
						case WindowState.Minimized:
							SDL.MinimizeWindow(this.window.Handle);
							this.window_state = WindowState.Minimized;
							break;
						case WindowState.Maximized:
							this.RestoreWindow();
							SDL.MaximizeWindow(this.window.Handle);
							this.window_state = WindowState.Maximized;
							break;
						case WindowState.Fullscreen:
						{
							this.RestoreWindow();
							bool flag = Sdl2Factory.UseFullscreenDesktop ? (SDL.SetWindowFullscreen(this.window.Handle, 4097U) < 0) : (SDL.SetWindowFullscreen(this.window.Handle, 1U) < 0);
							SDL.RaiseWindow(this.window.Handle);
							this.window_state = WindowState.Fullscreen;
							break;
						}
						}
						if (!this.CursorVisible)
						{
							this.GrabCursor(true);
						}
					}
				}
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x0600465E RID: 18014 RVA: 0x000C2EDC File Offset: 0x000C10DC
		// (set) Token: 0x0600465F RID: 18015 RVA: 0x000C2EE4 File Offset: 0x000C10E4
		public override WindowBorder WindowBorder
		{
			get
			{
				return this.window_border;
			}
			set
			{
				if (this.WindowBorder != value)
				{
					lock (this.sync)
					{
						if (this.Exists)
						{
							switch (value)
							{
							case WindowBorder.Resizable:
								SDL.SetWindowBordered(this.window.Handle, true);
								this.window_border = WindowBorder.Resizable;
								break;
							case WindowBorder.Hidden:
								SDL.SetWindowBordered(this.window.Handle, false);
								this.window_border = WindowBorder.Hidden;
								break;
							}
						}
					}
					if (this.Exists)
					{
						base.OnWindowBorderChanged(EventArgs.Empty);
					}
				}
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06004660 RID: 18016 RVA: 0x000C2F84 File Offset: 0x000C1184
		// (set) Token: 0x06004661 RID: 18017 RVA: 0x000C2F98 File Offset: 0x000C1198
		public override Rectangle Bounds
		{
			get
			{
				return new Rectangle(this.Location, this.Size);
			}
			set
			{
				this.Size = value.Size;
				this.Location = value.Location;
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06004662 RID: 18018 RVA: 0x000C2FB4 File Offset: 0x000C11B4
		// (set) Token: 0x06004663 RID: 18019 RVA: 0x000C301C File Offset: 0x000C121C
		public override Point Location
		{
			get
			{
				Point result;
				lock (this.sync)
				{
					if (this.Exists)
					{
						int x;
						int y;
						SDL.GetWindowPosition(this.window.Handle, out x, out y);
						result = new Point(x, y);
					}
					else
					{
						result = default(Point);
					}
				}
				return result;
			}
			set
			{
				lock (this.sync)
				{
					if (this.Exists)
					{
						SDL.SetWindowPosition(this.window.Handle, value.X, value.Y);
					}
				}
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06004664 RID: 18020 RVA: 0x000C3078 File Offset: 0x000C1278
		// (set) Token: 0x06004665 RID: 18021 RVA: 0x000C30E0 File Offset: 0x000C12E0
		public override Size Size
		{
			get
			{
				Size result;
				lock (this.sync)
				{
					if (this.Exists)
					{
						int width;
						int height;
						SDL.GetWindowSize(this.window.Handle, out width, out height);
						result = new Size(width, height);
					}
					else
					{
						result = default(Size);
					}
				}
				return result;
			}
			set
			{
				lock (this.sync)
				{
					if (this.Exists)
					{
						SDL.SetWindowSize(this.window.Handle, value.Width, value.Height);
					}
				}
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06004666 RID: 18022 RVA: 0x000C313C File Offset: 0x000C133C
		// (set) Token: 0x06004667 RID: 18023 RVA: 0x000C3190 File Offset: 0x000C1390
		public override Size ClientSize
		{
			get
			{
				int width;
				int height;
				if (SDL.Version.Number > 2000)
				{
					SDL.GL.GetDrawableSize(this.window.Handle, out width, out height);
				}
				else
				{
					SDL.GetWindowSize(this.window.Handle, out width, out height);
				}
				return new Size(width, height);
			}
			set
			{
				float num = (float)this.Size.Width / (float)this.ClientSize.Width;
				this.Size = new Size((int)((float)value.Width * num), (int)((float)value.Height * num));
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06004668 RID: 18024 RVA: 0x000C31E0 File Offset: 0x000C13E0
		// (set) Token: 0x06004669 RID: 18025 RVA: 0x000C31E8 File Offset: 0x000C13E8
		public override bool CursorVisible
		{
			get
			{
				return this.is_cursor_visible;
			}
			set
			{
				lock (this.sync)
				{
					if (this.Exists)
					{
						this.GrabCursor(!value);
						this.is_cursor_visible = value;
					}
				}
			}
		}

		// Token: 0x0600466A RID: 18026 RVA: 0x000C3234 File Offset: 0x000C1434
		protected override void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				lock (this.sync)
				{
					if (manual)
					{
						this.InputDriver.Dispose();
						if (this.Exists)
						{
							this.DestroyWindow();
						}
						if (this.sdl_cursor != IntPtr.Zero)
						{
							SDL.FreeCursor(this.sdl_cursor);
							this.sdl_cursor = IntPtr.Zero;
						}
					}
					else if (this.Exists)
					{
						this.Close();
					}
					this.disposed = true;
				}
			}
		}

		// Token: 0x04005222 RID: 21026
		private readonly object sync = new object();

		// Token: 0x04005223 RID: 21027
		private Sdl2WindowInfo window;

		// Token: 0x04005224 RID: 21028
		private uint window_id;

		// Token: 0x04005225 RID: 21029
		private bool is_visible;

		// Token: 0x04005226 RID: 21030
		private bool is_focused;

		// Token: 0x04005227 RID: 21031
		private bool is_cursor_visible = true;

		// Token: 0x04005228 RID: 21032
		private bool exists;

		// Token: 0x04005229 RID: 21033
		private bool must_destroy;

		// Token: 0x0400522A RID: 21034
		private bool disposed;

		// Token: 0x0400522B RID: 21035
		private volatile bool is_in_closing_event;

		// Token: 0x0400522C RID: 21036
		private WindowState window_state;

		// Token: 0x0400522D RID: 21037
		private WindowState previous_window_state;

		// Token: 0x0400522E RID: 21038
		private WindowBorder window_border;

		// Token: 0x0400522F RID: 21039
		private Icon icon;

		// Token: 0x04005230 RID: 21040
		private MouseCursor cursor = MouseCursor.Default;

		// Token: 0x04005231 RID: 21041
		private IntPtr sdl_cursor = IntPtr.Zero;

		// Token: 0x04005232 RID: 21042
		private string window_title;

		// Token: 0x04005233 RID: 21043
		private char[] DecodeTextBuffer = new char[32];

		// Token: 0x04005234 RID: 21044
		private static readonly Dictionary<uint, Sdl2NativeWindow> windows = new Dictionary<uint, Sdl2NativeWindow>();
	}
}
