using System;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Platform.Egl;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B73 RID: 2931
	internal class LinuxNativeWindow : NativeWindowBase
	{
		// Token: 0x06005B88 RID: 23432 RVA: 0x000F8254 File Offset: 0x000F6454
		public LinuxNativeWindow(IntPtr display, IntPtr gbm, int fd, int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice display_device)
		{
			this.Title = title;
			display_device = (display_device ?? DisplayDevice.Default);
			if (display_device == null)
			{
				throw new NotSupportedException("[KMS] Driver does not currently support headless systems");
			}
			this.window = new LinuxWindowInfo(display, fd, gbm, display_device.Id as LinuxDisplay);
			width = display_device.Width;
			height = display_device.Height;
			this.bounds = new Rectangle(0, 0, width, height);
			this.client_size = this.bounds.Size;
			if (mode.Index == null)
			{
				mode = new EglGraphicsMode().SelectGraphicsMode(this.window, mode, (RenderableFlags)0);
			}
			SurfaceFormat format = LinuxNativeWindow.GetSurfaceFormat(display, mode);
			SurfaceFlags surfaceFlags = SurfaceFlags.Scanout | SurfaceFlags.Rendering;
			if (!Gbm.IsFormatSupported(gbm, format, surfaceFlags))
			{
				format = SurfaceFormat.XRGB8888;
			}
			IntPtr intPtr = Gbm.CreateSurface(gbm, width, height, format, surfaceFlags);
			if (intPtr == IntPtr.Zero)
			{
				throw new NotSupportedException("[KMS] Failed to create GBM surface for rendering");
			}
			this.window.Handle = intPtr;
			this.window.CreateWindowSurface(mode.Index.Value);
			this.cursor_default = LinuxNativeWindow.CreateCursor(gbm, Cursors.Default);
			this.cursor_empty = LinuxNativeWindow.CreateCursor(gbm, Cursors.Empty);
			this.Cursor = MouseCursor.Default;
			this.exists = true;
		}

		// Token: 0x06005B89 RID: 23433 RVA: 0x000F83A4 File Offset: 0x000F65A4
		private static BufferObject CreateCursor(IntPtr gbm, MouseCursor cursor)
		{
			if (cursor.Width > 64 || cursor.Height > 64)
			{
				return default(BufferObject);
			}
			int num = 64;
			int num2 = 64;
			SurfaceFormat format = SurfaceFormat.ARGB8888;
			SurfaceFlags flags = SurfaceFlags.Cursor64x64 | SurfaceFlags.Write;
			BufferObject bufferObject = Gbm.CreateBuffer(gbm, num, num2, format, flags);
			if (bufferObject == BufferObject.Zero)
			{
				return bufferObject;
			}
			byte[] array = new byte[num * num2 * 4];
			for (int i = 0; i < cursor.Height; i++)
			{
				int destinationIndex = i * num * 4;
				int sourceIndex = i * cursor.Width * 4;
				int length = cursor.Width * 4;
				Array.Copy(cursor.Data, sourceIndex, array, destinationIndex, length);
			}
			bufferObject.Write(array);
			return bufferObject;
		}

		// Token: 0x06005B8A RID: 23434 RVA: 0x000F845C File Offset: 0x000F665C
		private void SetCursor(MouseCursor cursor)
		{
			BufferObject left = default(BufferObject);
			if (cursor == MouseCursor.Default)
			{
				left = this.cursor_default;
			}
			else if (cursor == MouseCursor.Empty)
			{
				left = this.cursor_empty;
			}
			else
			{
				if (this.cursor_custom != BufferObject.Zero)
				{
					this.cursor_custom.Dispose();
				}
				this.cursor_custom = LinuxNativeWindow.CreateCursor(this.window.BufferManager, cursor);
				left = this.cursor_custom;
			}
			if (left == BufferObject.Zero)
			{
				left = this.cursor_empty;
			}
			if (left != BufferObject.Zero)
			{
				Drm.SetCursor(this.window.FD, this.window.DisplayDevice.Id, left.Handle, left.Width, left.Height, cursor.X, cursor.Y);
			}
		}

		// Token: 0x06005B8B RID: 23435 RVA: 0x000F8534 File Offset: 0x000F6734
		private static SurfaceFormat GetSurfaceFormat(IntPtr display, GraphicsMode mode)
		{
			int num;
			Egl.GetConfigAttrib(display, mode.Index.Value, 12334, out num);
			if (num != 0)
			{
				return (SurfaceFormat)num;
			}
			int red = mode.ColorFormat.Red;
			int green = mode.ColorFormat.Green;
			int blue = mode.ColorFormat.Blue;
			int alpha = mode.ColorFormat.Alpha;
			if (mode.ColorFormat.IsIndexed)
			{
				return SurfaceFormat.C8;
			}
			if (red == 3 && green == 3 && blue == 2 && alpha == 0)
			{
				return SurfaceFormat.RGB332;
			}
			if (red == 5 && green == 6 && blue == 5 && alpha == 0)
			{
				return SurfaceFormat.RGB565;
			}
			if (red == 5 && green == 6 && blue == 5 && alpha == 0)
			{
				return SurfaceFormat.RGB565;
			}
			if (red == 8 && green == 8 && blue == 8 && alpha == 0)
			{
				return SurfaceFormat.RGB888;
			}
			if (red == 5 && green == 5 && blue == 5 && alpha == 1)
			{
				return SurfaceFormat.RGBA5551;
			}
			if (red == 10 && green == 10 && blue == 10 && alpha == 2)
			{
				return SurfaceFormat.RGBA1010102;
			}
			if (red == 4 && green == 4 && blue == 4 && alpha == 4)
			{
				return SurfaceFormat.RGBA4444;
			}
			if (red == 8 && green == 8 && blue == 8 && alpha == 8)
			{
				return SurfaceFormat.RGBA8888;
			}
			return SurfaceFormat.RGBA8888;
		}

		// Token: 0x06005B8C RID: 23436 RVA: 0x000F8678 File Offset: 0x000F6878
		private KeyboardState ProcessKeyboard(KeyboardState keyboard)
		{
			for (Key key = Key.Unknown; key < Key.LastKey; key++)
			{
				if (keyboard[key])
				{
					base.OnKeyDown(key, this.previous_keyboard[key]);
				}
				if (!keyboard[key] && this.previous_keyboard[key])
				{
					base.OnKeyUp(key);
				}
			}
			return keyboard;
		}

		// Token: 0x06005B8D RID: 23437 RVA: 0x000F86D4 File Offset: 0x000F68D4
		private MouseState ProcessMouse(MouseState mouse)
		{
			for (MouseButton mouseButton = MouseButton.Left; mouseButton < MouseButton.LastButton; mouseButton++)
			{
				if (mouse[mouseButton] && !this.previous_mouse[mouseButton])
				{
					base.OnMouseDown(mouseButton);
				}
				if (!mouse[mouseButton] && this.previous_mouse[mouseButton])
				{
					base.OnMouseUp(mouseButton);
				}
			}
			int num = mouse.X;
			int num2 = mouse.Y;
			if (!this.CursorVisible)
			{
				num = MathHelper.Clamp(mouse.X, this.Bounds.Left, this.Bounds.Right - 1);
				num2 = MathHelper.Clamp(mouse.Y, this.Bounds.Top, this.Bounds.Bottom - 1);
				if (num != mouse.X || num2 != mouse.Y)
				{
					Mouse.SetPosition((double)num, (double)num2);
				}
			}
			if (num != this.previous_mouse.X || num2 != this.previous_mouse.Y)
			{
				base.OnMouseMove(num, num2);
			}
			if (mouse.Scroll != this.previous_mouse.Scroll)
			{
				float dx = mouse.Scroll.X - this.previous_mouse.Scroll.X;
				float dy = mouse.Scroll.Y - this.previous_mouse.Scroll.Y;
				base.OnMouseWheel(dx, dy);
			}
			bool flag = this.Bounds.Contains(new Point(mouse.X, mouse.Y));
			if (!flag && this.Focused)
			{
				base.OnMouseLeave(EventArgs.Empty);
				this.SetFocus(false);
			}
			else if (flag && !this.Focused)
			{
				base.OnMouseEnter(EventArgs.Empty);
				this.SetFocus(true);
			}
			return mouse;
		}

		// Token: 0x06005B8E RID: 23438 RVA: 0x000F88B4 File Offset: 0x000F6AB4
		private void SetFocus(bool focus)
		{
			if (this.is_focused != focus)
			{
				this.is_focused = focus;
				base.OnFocusedChanged(EventArgs.Empty);
			}
		}

		// Token: 0x06005B8F RID: 23439 RVA: 0x000F88D4 File Offset: 0x000F6AD4
		public override void ProcessEvents()
		{
			this.previous_keyboard = this.ProcessKeyboard(Keyboard.GetState());
			this.previous_mouse = this.ProcessMouse(Mouse.GetCursorState());
			base.ProcessEvents();
		}

		// Token: 0x06005B90 RID: 23440 RVA: 0x000F8900 File Offset: 0x000F6B00
		public override void Close()
		{
			this.exists = false;
		}

		// Token: 0x06005B91 RID: 23441 RVA: 0x000F890C File Offset: 0x000F6B0C
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

		// Token: 0x06005B92 RID: 23442 RVA: 0x000F8974 File Offset: 0x000F6B74
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

		// Token: 0x06005B93 RID: 23443 RVA: 0x000F89DC File Offset: 0x000F6BDC
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.window.Dispose();
				Gbm.DestroySurface(this.window.Handle);
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06005B94 RID: 23444 RVA: 0x000F89FC File Offset: 0x000F6BFC
		// (set) Token: 0x06005B95 RID: 23445 RVA: 0x000F8A04 File Offset: 0x000F6C04
		public override Icon Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				if (this.icon != value)
				{
					this.icon = value;
					base.OnIconChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06005B96 RID: 23446 RVA: 0x000F8A24 File Offset: 0x000F6C24
		// (set) Token: 0x06005B97 RID: 23447 RVA: 0x000F8A2C File Offset: 0x000F6C2C
		public override string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				if (this.title != value)
				{
					this.title = value;
					base.OnTitleChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06005B98 RID: 23448 RVA: 0x000F8A50 File Offset: 0x000F6C50
		public override bool Focused
		{
			get
			{
				return this.is_focused;
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06005B99 RID: 23449 RVA: 0x000F8A58 File Offset: 0x000F6C58
		// (set) Token: 0x06005B9A RID: 23450 RVA: 0x000F8A5C File Offset: 0x000F6C5C
		public override bool Visible
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06005B9B RID: 23451 RVA: 0x000F8A60 File Offset: 0x000F6C60
		public override bool Exists
		{
			get
			{
				return this.exists;
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06005B9C RID: 23452 RVA: 0x000F8A68 File Offset: 0x000F6C68
		public override IWindowInfo WindowInfo
		{
			get
			{
				return this.window;
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06005B9D RID: 23453 RVA: 0x000F8A70 File Offset: 0x000F6C70
		// (set) Token: 0x06005B9E RID: 23454 RVA: 0x000F8A74 File Offset: 0x000F6C74
		public override WindowState WindowState
		{
			get
			{
				return WindowState.Fullscreen;
			}
			set
			{
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06005B9F RID: 23455 RVA: 0x000F8A78 File Offset: 0x000F6C78
		// (set) Token: 0x06005BA0 RID: 23456 RVA: 0x000F8A7C File Offset: 0x000F6C7C
		public override WindowBorder WindowBorder
		{
			get
			{
				return WindowBorder.Hidden;
			}
			set
			{
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06005BA1 RID: 23457 RVA: 0x000F8A80 File Offset: 0x000F6C80
		// (set) Token: 0x06005BA2 RID: 23458 RVA: 0x000F8A88 File Offset: 0x000F6C88
		public override Rectangle Bounds
		{
			get
			{
				return this.bounds;
			}
			set
			{
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06005BA3 RID: 23459 RVA: 0x000F8A8C File Offset: 0x000F6C8C
		// (set) Token: 0x06005BA4 RID: 23460 RVA: 0x000F8A94 File Offset: 0x000F6C94
		public override Size ClientSize
		{
			get
			{
				return this.client_size;
			}
			set
			{
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06005BA5 RID: 23461 RVA: 0x000F8A98 File Offset: 0x000F6C98
		// (set) Token: 0x06005BA6 RID: 23462 RVA: 0x000F8AA0 File Offset: 0x000F6CA0
		public override bool CursorVisible
		{
			get
			{
				return this.is_cursor_visible;
			}
			set
			{
				if (value && !this.is_cursor_visible)
				{
					this.SetCursor(this.cursor_current);
				}
				else if (!value && this.is_cursor_visible)
				{
					this.SetCursor(MouseCursor.Empty);
				}
				this.is_cursor_visible = value;
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06005BA7 RID: 23463 RVA: 0x000F8AD8 File Offset: 0x000F6CD8
		// (set) Token: 0x06005BA8 RID: 23464 RVA: 0x000F8AE0 File Offset: 0x000F6CE0
		public override MouseCursor Cursor
		{
			get
			{
				return this.cursor_current;
			}
			set
			{
				if (this.cursor_current != value)
				{
					if (this.cursor_custom != BufferObject.Zero)
					{
						this.cursor_custom.Dispose();
					}
					if (this.CursorVisible)
					{
						this.SetCursor(value);
					}
					this.cursor_current = value;
				}
			}
		}

		// Token: 0x0400B836 RID: 47158
		private LinuxWindowInfo window;

		// Token: 0x0400B837 RID: 47159
		private string title;

		// Token: 0x0400B838 RID: 47160
		private Icon icon;

		// Token: 0x0400B839 RID: 47161
		private Rectangle bounds;

		// Token: 0x0400B83A RID: 47162
		private Size client_size;

		// Token: 0x0400B83B RID: 47163
		private bool exists;

		// Token: 0x0400B83C RID: 47164
		private bool is_focused;

		// Token: 0x0400B83D RID: 47165
		private bool is_cursor_visible = true;

		// Token: 0x0400B83E RID: 47166
		private KeyboardState previous_keyboard;

		// Token: 0x0400B83F RID: 47167
		private MouseState previous_mouse;

		// Token: 0x0400B840 RID: 47168
		private MouseCursor cursor_current;

		// Token: 0x0400B841 RID: 47169
		private BufferObject cursor_custom;

		// Token: 0x0400B842 RID: 47170
		private BufferObject cursor_default;

		// Token: 0x0400B843 RID: 47171
		private BufferObject cursor_empty;

		// Token: 0x0400B844 RID: 47172
		private IntPtr gbm_surface;
	}
}
