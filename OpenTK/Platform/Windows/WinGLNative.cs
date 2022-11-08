using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000D4 RID: 212
	internal sealed class WinGLNative : NativeWindowBase
	{
		// Token: 0x060008C8 RID: 2248 RVA: 0x0001C4F4 File Offset: 0x0001A6F4
		public WinGLNative(int x, int y, int width, int height, string title, GameWindowFlags options, DisplayDevice device)
		{
			lock (WinGLNative.SyncRoot)
			{
				this.WindowProcedureDelegate = new WindowProcedure(this.WindowProcedure);
				int width2 = width;
				int height2 = height;
				int x2 = x;
				int y2 = y;
				if (Toolkit.Options.EnableHighResolution)
				{
					width2 = WinGLNative.ScaleX(width);
					height2 = WinGLNative.ScaleY(height);
					x2 = WinGLNative.ScaleX(x);
					y2 = WinGLNative.ScaleY(y);
				}
				this.window = new WinWindowInfo(this.CreateWindow(x2, y2, width2, height2, title, options, device, IntPtr.Zero), null);
				this.child_window = new WinWindowInfo(this.CreateWindow(0, 0, this.ClientSize.Width, this.ClientSize.Height, title, options, device, this.window.Handle), this.window);
				this.exists = true;
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0001C678 File Offset: 0x0001A878
		private static int Scale(int v, WinGLNative.ScaleDirection direction)
		{
			IntPtr dc = Functions.GetDC(IntPtr.Zero);
			if (dc != IntPtr.Zero)
			{
				int deviceCaps = Functions.GetDeviceCaps(dc, (direction == WinGLNative.ScaleDirection.X) ? DeviceCaps.LogPixelsX : DeviceCaps.LogPixelsY);
				if (deviceCaps > 0)
				{
					float num = (float)deviceCaps / 96f;
					v = (int)Math.Round((double)((float)v * num));
				}
				Functions.ReleaseDC(IntPtr.Zero, dc);
			}
			return v;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0001C6D4 File Offset: 0x0001A8D4
		private static int ScaleX(int x)
		{
			return WinGLNative.Scale(x, WinGLNative.ScaleDirection.X);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0001C6E0 File Offset: 0x0001A8E0
		private static int ScaleY(int y)
		{
			return WinGLNative.Scale(y, WinGLNative.ScaleDirection.Y);
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x0001C6EC File Offset: 0x0001A8EC
		private static int Unscale(int v, WinGLNative.ScaleDirection direction)
		{
			IntPtr dc = Functions.GetDC(IntPtr.Zero);
			if (dc != IntPtr.Zero)
			{
				int deviceCaps = Functions.GetDeviceCaps(dc, (direction == WinGLNative.ScaleDirection.X) ? DeviceCaps.LogPixelsX : DeviceCaps.LogPixelsY);
				if (deviceCaps > 0)
				{
					float num = (float)deviceCaps / 96f;
					v = (int)Math.Round((double)((float)v / num));
				}
				Functions.ReleaseDC(IntPtr.Zero, dc);
			}
			return v;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0001C748 File Offset: 0x0001A948
		private static int UnscaleX(int x)
		{
			return WinGLNative.Unscale(x, WinGLNative.ScaleDirection.X);
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x0001C754 File Offset: 0x0001A954
		private static int UnscaleY(int y)
		{
			return WinGLNative.Unscale(y, WinGLNative.ScaleDirection.Y);
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x0001C760 File Offset: 0x0001A960
		private void HandleActivate(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			bool flag = this.Focused;
			if (IntPtr.Size == 4)
			{
				this.focused = ((wParam.ToInt32() & 65535) != 0);
			}
			else
			{
				this.focused = ((wParam.ToInt64() & 65535L) != 0L);
			}
			if (flag != this.Focused)
			{
				base.OnFocusedChanged(EventArgs.Empty);
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x0001C7C8 File Offset: 0x0001A9C8
		private void HandleEnterModalLoop(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			this.is_in_modal_loop = true;
			this.StartTimer(handle);
			if (!this.CursorVisible)
			{
				this.UngrabCursor();
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x0001C7E8 File Offset: 0x0001A9E8
		private void HandleExitModalLoop(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			this.is_in_modal_loop = false;
			this.StopTimer(handle);
			if (!this.CursorVisible)
			{
				this.GrabCursor();
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0001C808 File Offset: 0x0001AA08
		private unsafe void HandleWindowPositionChanged(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			WindowPosition* ptr = (WindowPosition*)((void*)lParam);
			if (this.window != null && ptr->hwnd == this.window.Handle)
			{
				Point point = new Point(ptr->x, ptr->y);
				if (this.Location != point)
				{
					this.bounds.Location = point;
					base.OnMove(EventArgs.Empty);
				}
				Size sz = new Size(ptr->cx, ptr->cy);
				if (this.Size != sz)
				{
					this.bounds.Width = ptr->cx;
					this.bounds.Height = ptr->cy;
					Win32Rectangle win32Rectangle;
					Functions.GetClientRect(handle, out win32Rectangle);
					this.client_rectangle = win32Rectangle.ToRectangle();
					Functions.SetWindowPos(this.child_window.Handle, IntPtr.Zero, 0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height, SetWindowPosFlags.NOZORDER | SetWindowPosFlags.NOACTIVATE | SetWindowPosFlags.NOOWNERZORDER | SetWindowPosFlags.NOSENDCHANGING);
					if (this.suppress_resize <= 0)
					{
						base.OnResize(EventArgs.Empty);
					}
				}
				if (!this.is_in_modal_loop && !this.CursorVisible)
				{
					this.GrabCursor();
				}
			}
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0001C93C File Offset: 0x0001AB3C
		private unsafe void HandleStyleChanged(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			WindowBorder windowBorder = this.windowBorder;
			WindowBorder windowBorder2 = windowBorder;
			GWL gwl = (GWL)wParam.ToInt32();
			if ((gwl & GWL.WNDPROC) != (GWL)0)
			{
				WindowStyle @new = ((StyleStruct*)((void*)lParam))->New;
				if ((@new & (WindowStyle)2147483648U) != WindowStyle.Overlapped)
				{
					windowBorder2 = WindowBorder.Hidden;
				}
				else if ((@new & WindowStyle.ThickFrame) != WindowStyle.Overlapped)
				{
					windowBorder2 = WindowBorder.Resizable;
				}
				else if ((@new & ~(WindowStyle.ThickFrame | WindowStyle.TabStop)) != WindowStyle.Overlapped)
				{
					windowBorder2 = WindowBorder.Fixed;
				}
			}
			if (windowBorder2 != this.windowBorder)
			{
				if (!this.CursorVisible)
				{
					this.GrabCursor();
				}
				this.windowBorder = windowBorder2;
				base.OnWindowBorderChanged(EventArgs.Empty);
			}
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0001C9BC File Offset: 0x0001ABBC
		private void HandleSize(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			SizeMessage sizeMessage = (SizeMessage)wParam.ToInt64();
			WindowState windowState = this.windowState;
			switch (sizeMessage)
			{
			case SizeMessage.RESTORED:
				windowState = (this.borderless_maximized_window_state ? WindowState.Maximized : WindowState.Normal);
				break;
			case SizeMessage.MINIMIZED:
				windowState = WindowState.Minimized;
				break;
			case SizeMessage.MAXIMIZED:
				windowState = ((this.WindowBorder == WindowBorder.Hidden) ? WindowState.Fullscreen : WindowState.Maximized);
				break;
			}
			if (windowState != this.windowState)
			{
				this.windowState = windowState;
				base.OnWindowStateChanged(EventArgs.Empty);
				if (!this.CursorVisible)
				{
					this.GrabCursor();
				}
			}
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0001CA3C File Offset: 0x0001AC3C
		private IntPtr? HandleSetCursor(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			if (this.cursor != MouseCursor.Default && (lParam.ToInt64() & 65535L) == 1L)
			{
				Functions.SetCursor(this.cursor_handle);
				return new IntPtr?(new IntPtr(1));
			}
			return null;
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0001CA8C File Offset: 0x0001AC8C
		private void HandleChar(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			char c;
			if (IntPtr.Size == 4)
			{
				c = (char)wParam.ToInt32();
			}
			else
			{
				c = (char)wParam.ToInt64();
			}
			if (!char.IsControl(c))
			{
				base.OnKeyPress(c);
			}
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0001CAC4 File Offset: 0x0001ACC4
		private unsafe void HandleMouseMove(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Point point = new Point((int)((short)(lParam.ToInt32() & 65535)), (int)((short)((uint)(lParam.ToInt32() & -65536) >> 16)));
			Point point2 = point;
			Functions.ClientToScreen(handle, ref point2);
			int messageTime = Functions.GetMessageTime();
			MouseMovePoint mouseMovePoint = new MouseMovePoint
			{
				X = (point2.X & 65535),
				Y = (point2.Y & 65535),
				Time = messageTime
			};
			MouseMovePoint* ptr = stackalloc MouseMovePoint[checked(unchecked((UIntPtr)64) * (UIntPtr)sizeof(MouseMovePoint))];
			int mouseMovePointsEx = Functions.GetMouseMovePointsEx((uint)MouseMovePoint.SizeInBytes, &mouseMovePoint, ptr, 64, 1U);
			int lastWin32Error = Marshal.GetLastWin32Error();
			if (mouseMovePointsEx == 0 || (mouseMovePointsEx == -1 && lastWin32Error == 1171))
			{
				base.OnMouseMove(point.X, point.Y);
			}
			else
			{
				if (mouseMovePointsEx == -1)
				{
					throw new Win32Exception(lastWin32Error);
				}
				Point point3 = new Point(this.InputDriver.Mouse[0].X, this.InputDriver.Mouse[0].Y);
				Functions.ClientToScreen(handle, ref point3);
				for (int i = 0; i < mouseMovePointsEx; i++)
				{
					if (ptr[i].Time < this.mouse_last_timestamp || (ptr[i].Time == this.mouse_last_timestamp && ptr[i].X == point3.X && ptr[i].Y == point3.Y))
					{
						IL_22C:
						while (--i >= 0)
						{
							Point point4 = new Point(ptr[i].X, ptr[i].Y);
							if (point4.X > 32767)
							{
								point4.X -= 65536;
							}
							if (point4.Y > 32767)
							{
								point4.Y -= 65536;
							}
							Functions.ScreenToClient(handle, ref point4);
							base.OnMouseMove(point4.X, point4.Y);
						}
						goto IL_239;
					}
				}
				goto IL_22C;
			}
			IL_239:
			this.mouse_last_timestamp = messageTime;
			if (this.mouse_outside_window)
			{
				this.mouse_outside_window = false;
				this.EnableMouseTracking();
				base.OnMouseEnter(EventArgs.Empty);
			}
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0001CD34 File Offset: 0x0001AF34
		private void HandleMouseLeave(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			this.mouse_outside_window = true;
			base.OnMouseLeave(EventArgs.Empty);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0001CD48 File Offset: 0x0001AF48
		private void HandleMouseWheel(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			base.OnMouseWheel(0f, (float)((long)wParam << 32 >> 48) / 120f);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0001CD68 File Offset: 0x0001AF68
		private void HandleMouseHWheel(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			base.OnMouseWheel((float)((long)wParam << 32 >> 48) / 120f, 0f);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0001CD88 File Offset: 0x0001AF88
		private void HandleLButtonDown(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Functions.SetCapture(this.window.Handle);
			base.OnMouseDown(MouseButton.Left);
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0001CDA4 File Offset: 0x0001AFA4
		private void HandleMButtonDown(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Functions.SetCapture(this.window.Handle);
			base.OnMouseDown(MouseButton.Middle);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0001CDC0 File Offset: 0x0001AFC0
		private void HandleRButtonDown(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Functions.SetCapture(this.window.Handle);
			base.OnMouseDown(MouseButton.Right);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x0001CDDC File Offset: 0x0001AFDC
		private void HandleXButtonDown(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Functions.SetCapture(this.window.Handle);
			MouseButton button = (((long)wParam.ToInt32() & (long)((ulong)-65536)) >> 16 == 1L) ? MouseButton.Button1 : MouseButton.Button2;
			base.OnMouseDown(button);
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0001CE1C File Offset: 0x0001B01C
		private void HandleLButtonUp(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Functions.ReleaseCapture();
			base.OnMouseUp(MouseButton.Left);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0001CE2C File Offset: 0x0001B02C
		private void HandleMButtonUp(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Functions.ReleaseCapture();
			base.OnMouseUp(MouseButton.Middle);
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0001CE3C File Offset: 0x0001B03C
		private void HandleRButtonUp(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Functions.ReleaseCapture();
			base.OnMouseUp(MouseButton.Right);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x0001CE4C File Offset: 0x0001B04C
		private void HandleXButtonUp(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			Functions.ReleaseCapture();
			MouseButton button = (((long)wParam.ToInt32() & (long)((ulong)-65536)) >> 16 == 1L) ? MouseButton.Button1 : MouseButton.Button2;
			base.OnMouseUp(button);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0001CE84 File Offset: 0x0001B084
		private void HandleKeyboard(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			bool flag = message == WindowMessage.KEYDOWN || message == WindowMessage.SYSKEYDOWN;
			bool extended = (lParam.ToInt64() & 16777216L) != 0L;
			short scancode = (short)(lParam.ToInt64() >> 16 & 255L);
			VirtualKeys vkey = (VirtualKeys)((int)wParam);
			bool flag2;
			Key key = WinKeyMap.TranslateKey(scancode, vkey, extended, false, out flag2);
			if (flag2)
			{
				if (flag)
				{
					base.OnKeyDown(key, this.KeyboardState[key]);
					return;
				}
				base.OnKeyUp(key);
			}
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0001CF08 File Offset: 0x0001B108
		private void HandleKillFocus(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0001CF0C File Offset: 0x0001B10C
		private void HandleCreate(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			CreateStruct createStruct = (CreateStruct)Marshal.PtrToStructure(lParam, typeof(CreateStruct));
			if (createStruct.hwndParent == IntPtr.Zero)
			{
				this.bounds.X = createStruct.x;
				this.bounds.Y = createStruct.y;
				this.bounds.Width = createStruct.cx;
				this.bounds.Height = createStruct.cy;
				Win32Rectangle win32Rectangle;
				Functions.GetClientRect(handle, out win32Rectangle);
				this.client_rectangle = win32Rectangle.ToRectangle();
				this.invisible_since_creation = true;
			}
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0001CFA8 File Offset: 0x0001B1A8
		private void HandleClose(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			CancelEventArgs cancelEventArgs = new CancelEventArgs();
			base.OnClosing(cancelEventArgs);
			if (!cancelEventArgs.Cancel)
			{
				this.DestroyWindow();
			}
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0001CFD0 File Offset: 0x0001B1D0
		private void HandleDestroy(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			this.exists = false;
			if (handle == this.window.Handle)
			{
				Functions.UnregisterClass(this.ClassName, this.Instance);
			}
			this.window.Dispose();
			this.child_window.Dispose();
			base.OnClosed(EventArgs.Empty);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0001D02C File Offset: 0x0001B22C
		private IntPtr WindowProcedure(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			IntPtr? intPtr = null;
			if (message <= WindowMessage.WINDOWPOSCHANGED)
			{
				if (message <= WindowMessage.CLOSE)
				{
					switch (message)
					{
					case WindowMessage.CREATE:
						this.HandleCreate(handle, message, wParam, lParam);
						break;
					case WindowMessage.DESTROY:
						this.HandleDestroy(handle, message, wParam, lParam);
						break;
					case WindowMessage.MOVE:
					case (WindowMessage)4:
					case WindowMessage.SETFOCUS:
						break;
					case WindowMessage.SIZE:
						this.HandleSize(handle, message, wParam, lParam);
						break;
					case WindowMessage.ACTIVATE:
						this.HandleActivate(handle, message, wParam, lParam);
						break;
					case WindowMessage.KILLFOCUS:
						this.HandleKillFocus(handle, message, wParam, lParam);
						break;
					default:
						if (message == WindowMessage.CLOSE)
						{
							this.HandleClose(handle, message, wParam, lParam);
							return IntPtr.Zero;
						}
						break;
					}
				}
				else
				{
					if (message == WindowMessage.ERASEBKGND)
					{
						return new IntPtr(1);
					}
					if (message != WindowMessage.SETCURSOR)
					{
						if (message == WindowMessage.WINDOWPOSCHANGED)
						{
							this.HandleWindowPositionChanged(handle, message, wParam, lParam);
						}
					}
					else
					{
						intPtr = this.HandleSetCursor(handle, message, wParam, lParam);
					}
				}
			}
			else if (message <= WindowMessage.SYSCHAR)
			{
				if (message != WindowMessage.STYLECHANGED)
				{
					switch (message)
					{
					case WindowMessage.KEYDOWN:
					case WindowMessage.KEYUP:
					case WindowMessage.SYSKEYDOWN:
					case WindowMessage.SYSKEYUP:
						this.HandleKeyboard(handle, message, wParam, lParam);
						return IntPtr.Zero;
					case WindowMessage.CHAR:
						this.HandleChar(handle, message, wParam, lParam);
						break;
					case WindowMessage.SYSCHAR:
						return IntPtr.Zero;
					}
				}
				else
				{
					this.HandleStyleChanged(handle, message, wParam, lParam);
				}
			}
			else
			{
				switch (message)
				{
				case WindowMessage.MOUSEMOVE:
					this.HandleMouseMove(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.LBUTTONDOWN:
					this.HandleLButtonDown(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.LBUTTONUP:
					this.HandleLButtonUp(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.LBUTTONDBLCLK:
				case WindowMessage.RBUTTONDBLCLK:
				case WindowMessage.MBUTTONDBLCLK:
				case WindowMessage.XBUTTONDBLCLK:
				case (WindowMessage)527:
				case WindowMessage.PARENTNOTIFY:
					goto IL_2A8;
				case WindowMessage.RBUTTONDOWN:
					this.HandleRButtonDown(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.RBUTTONUP:
					this.HandleRButtonUp(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.MBUTTONDOWN:
					this.HandleMButtonDown(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.MBUTTONUP:
					this.HandleMButtonUp(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.MOUSEWHEEL:
					this.HandleMouseWheel(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.XBUTTONDOWN:
					this.HandleXButtonDown(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.XBUTTONUP:
					this.HandleXButtonUp(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.MOUSEHWHEEL:
					this.HandleMouseHWheel(handle, message, wParam, lParam);
					goto IL_2A8;
				case WindowMessage.ENTERMENULOOP:
					break;
				case WindowMessage.EXITMENULOOP:
					goto IL_13F;
				default:
					switch (message)
					{
					case WindowMessage.ENTERSIZEMOVE:
						break;
					case WindowMessage.EXITSIZEMOVE:
						goto IL_13F;
					default:
						if (message != WindowMessage.MOUSELEAVE)
						{
							goto IL_2A8;
						}
						this.HandleMouseLeave(handle, message, wParam, lParam);
						goto IL_2A8;
					}
					break;
				}
				this.HandleEnterModalLoop(handle, message, wParam, lParam);
				goto IL_2A8;
				IL_13F:
				this.HandleExitModalLoop(handle, message, wParam, lParam);
			}
			IL_2A8:
			if (intPtr != null)
			{
				return intPtr.Value;
			}
			return Functions.DefWindowProc(handle, message, wParam, lParam);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0001D2FC File Offset: 0x0001B4FC
		private void EnableMouseTracking()
		{
			TrackMouseEventStructure trackMouseEventStructure = default(TrackMouseEventStructure);
			trackMouseEventStructure.Size = TrackMouseEventStructure.SizeInBytes;
			trackMouseEventStructure.TrackWindowHandle = this.child_window.Handle;
			trackMouseEventStructure.Flags = TrackMouseEventFlags.LEAVE;
			Functions.TrackMouseEvent(ref trackMouseEventStructure);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0001D340 File Offset: 0x0001B540
		private void StartTimer(IntPtr handle)
		{
			if (this.timer_handle == UIntPtr.Zero)
			{
				this.timer_handle = Functions.SetTimer(handle, new UIntPtr(1U), this.ModalLoopTimerPeriod, null);
				this.timer_handle == UIntPtr.Zero;
			}
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0001D380 File Offset: 0x0001B580
		private void StopTimer(IntPtr handle)
		{
			if (this.timer_handle != UIntPtr.Zero)
			{
				Functions.KillTimer(handle, this.timer_handle);
				this.timer_handle = UIntPtr.Zero;
			}
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0001D3AC File Offset: 0x0001B5AC
		private IntPtr CreateWindow(int x, int y, int width, int height, string title, GameWindowFlags options, DisplayDevice device, IntPtr parentHandle)
		{
			WindowStyle windowStyle = WindowStyle.Overlapped;
			ExtendedWindowStyle extendedWindowStyle;
			if (parentHandle == IntPtr.Zero)
			{
				windowStyle |= (WindowStyle.ClipChildren | WindowStyle.Caption | WindowStyle.SystemMenu | WindowStyle.ThickFrame | WindowStyle.Group | WindowStyle.TabStop);
				extendedWindowStyle = (ExtendedWindowStyle.WindowEdge | ExtendedWindowStyle.ApplicationWindow);
			}
			else
			{
				windowStyle |= (WindowStyle.Child | WindowStyle.Visible | WindowStyle.ClipSiblings);
				extendedWindowStyle = ExtendedWindowStyle.Left;
			}
			Win32Rectangle win32Rectangle = default(Win32Rectangle);
			win32Rectangle.left = x;
			win32Rectangle.top = y;
			win32Rectangle.right = x + width;
			win32Rectangle.bottom = y + height;
			Functions.AdjustWindowRectEx(ref win32Rectangle, windowStyle, false, extendedWindowStyle);
			if (!this.class_registered)
			{
				ExtendedWindowClass extendedWindowClass = default(ExtendedWindowClass);
				extendedWindowClass.Size = ExtendedWindowClass.SizeInBytes;
				extendedWindowClass.Style = ClassStyle.OwnDC;
				extendedWindowClass.Instance = this.Instance;
				extendedWindowClass.WndProc = this.WindowProcedureDelegate;
				extendedWindowClass.ClassName = this.ClassName;
				extendedWindowClass.Icon = ((this.Icon != null) ? this.Icon.Handle : IntPtr.Zero);
				extendedWindowClass.IconSm = ((this.Icon != null) ? new Icon(this.Icon, 16, 16).Handle : IntPtr.Zero);
				extendedWindowClass.Cursor = Functions.LoadCursor(CursorName.Arrow);
				if (Functions.RegisterClassEx(ref extendedWindowClass) == 0)
				{
					throw new PlatformException(string.Format("Failed to register window class. Error: {0}", Marshal.GetLastWin32Error()));
				}
				this.class_registered = true;
			}
			IntPtr windowName = Marshal.StringToHGlobalAuto(title);
			IntPtr intPtr = Functions.CreateWindowEx(extendedWindowStyle, this.ClassName, windowName, windowStyle, win32Rectangle.left, win32Rectangle.top, win32Rectangle.Width, win32Rectangle.Height, parentHandle, IntPtr.Zero, this.Instance, IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				throw new PlatformException(string.Format("Failed to create window. Error: {0}", Marshal.GetLastWin32Error()));
			}
			return intPtr;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0001D568 File Offset: 0x0001B768
		private void DestroyWindow()
		{
			if (this.Exists)
			{
				Functions.DestroyWindow(this.window.Handle);
				this.exists = false;
			}
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001D58C File Offset: 0x0001B78C
		private void HideBorder()
		{
			this.suppress_resize++;
			this.WindowBorder = WindowBorder.Hidden;
			this.suppress_resize--;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0001D5B4 File Offset: 0x0001B7B4
		private void RestoreBorder()
		{
			this.suppress_resize++;
			this.WindowBorder = ((this.deferred_window_border != null) ? this.deferred_window_border.Value : ((this.previous_window_border != null) ? this.previous_window_border.Value : this.WindowBorder));
			this.suppress_resize--;
			WindowBorder? windowBorder = null;
			this.previous_window_border = windowBorder;
			this.deferred_window_border = (this.previous_window_border = windowBorder);
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0001D63C File Offset: 0x0001B83C
		private void ResetWindowState()
		{
			this.suppress_resize++;
			this.WindowState = WindowState.Normal;
			this.suppress_resize--;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0001D664 File Offset: 0x0001B864
		private void GrabCursor()
		{
			Point point = this.PointToScreen(new Point(base.ClientRectangle.X, base.ClientRectangle.Y));
			Win32Rectangle win32Rectangle = default(Win32Rectangle);
			win32Rectangle.left = point.X;
			win32Rectangle.right = point.X + base.ClientRectangle.Width;
			win32Rectangle.top = point.Y;
			win32Rectangle.bottom = point.Y + base.ClientRectangle.Height;
			Functions.ClipCursor(ref win32Rectangle);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0001D704 File Offset: 0x0001B904
		private void UngrabCursor()
		{
			Functions.ClipCursor(IntPtr.Zero);
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060008F3 RID: 2291 RVA: 0x0001D714 File Offset: 0x0001B914
		// (set) Token: 0x060008F4 RID: 2292 RVA: 0x0001D71C File Offset: 0x0001B91C
		public override Rectangle Bounds
		{
			get
			{
				return this.bounds;
			}
			set
			{
				Functions.SetWindowPos(this.window.Handle, IntPtr.Zero, value.X, value.Y, value.Width, value.Height, (SetWindowPosFlags)0);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x0001D754 File Offset: 0x0001B954
		// (set) Token: 0x060008F6 RID: 2294 RVA: 0x0001D770 File Offset: 0x0001B970
		public override Point Location
		{
			get
			{
				return this.Bounds.Location;
			}
			set
			{
				Functions.SetWindowPos(this.window.Handle, IntPtr.Zero, value.X, value.Y, 0, 0, SetWindowPosFlags.NOSIZE);
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x0001D79C File Offset: 0x0001B99C
		// (set) Token: 0x060008F8 RID: 2296 RVA: 0x0001D7B8 File Offset: 0x0001B9B8
		public override Size Size
		{
			get
			{
				return this.Bounds.Size;
			}
			set
			{
				Functions.SetWindowPos(this.window.Handle, IntPtr.Zero, 0, 0, value.Width, value.Height, SetWindowPosFlags.NOMOVE);
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060008F9 RID: 2297 RVA: 0x0001D7E4 File Offset: 0x0001B9E4
		// (set) Token: 0x060008FA RID: 2298 RVA: 0x0001D7F4 File Offset: 0x0001B9F4
		public override Size ClientSize
		{
			get
			{
				return this.client_rectangle.Size;
			}
			set
			{
				WindowStyle dwStyle = (WindowStyle)((uint)Functions.GetWindowLong(this.window.Handle, GetWindowLongOffsets.STYLE));
				Win32Rectangle win32Rectangle = Win32Rectangle.From(value);
				Functions.AdjustWindowRect(ref win32Rectangle, dwStyle, false);
				this.Size = new Size(win32Rectangle.Width, win32Rectangle.Height);
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0001D844 File Offset: 0x0001BA44
		// (set) Token: 0x060008FC RID: 2300 RVA: 0x0001D84C File Offset: 0x0001BA4C
		public override Icon Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				if (value != this.icon)
				{
					this.icon = value;
					if (this.window.Handle != IntPtr.Zero)
					{
						Functions.SendMessage(this.window.Handle, WindowMessage.SETICON, (IntPtr)0, (this.icon == null) ? IntPtr.Zero : value.Handle);
						Functions.SendMessage(this.window.Handle, WindowMessage.SETICON, (IntPtr)1, (this.icon == null) ? IntPtr.Zero : value.Handle);
					}
					base.OnIconChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0001D8F0 File Offset: 0x0001BAF0
		public override bool Focused
		{
			get
			{
				return this.focused;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x0001D94C File Offset: 0x0001BB4C
		public override string Title
		{
			get
			{
				this.sb_title.Remove(0, this.sb_title.Length);
				Functions.GetWindowText(this.window.Handle, this.sb_title, this.sb_title.Capacity);
				return this.sb_title.ToString();
			}
			set
			{
				if (this.Title != value)
				{
					Functions.SetWindowText(this.window.Handle, value);
					base.OnTitleChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0001D97C File Offset: 0x0001BB7C
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x0001D990 File Offset: 0x0001BB90
		public override bool Visible
		{
			get
			{
				return Functions.IsWindowVisible(this.window.Handle);
			}
			set
			{
				if (value != this.Visible)
				{
					if (value)
					{
						Functions.ShowWindow(this.window.Handle, ShowWindowCommand.SHOW);
						if (this.invisible_since_creation)
						{
							Functions.BringWindowToTop(this.window.Handle);
							Functions.SetForegroundWindow(this.window.Handle);
						}
					}
					else if (!value)
					{
						Functions.ShowWindow(this.window.Handle, ShowWindowCommand.HIDE);
					}
					base.OnVisibleChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x0001DA08 File Offset: 0x0001BC08
		public override bool Exists
		{
			get
			{
				return this.exists;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x0001DA10 File Offset: 0x0001BC10
		// (set) Token: 0x06000904 RID: 2308 RVA: 0x0001DA18 File Offset: 0x0001BC18
		public unsafe override MouseCursor Cursor
		{
			get
			{
				return this.cursor;
			}
			set
			{
				if (value != this.cursor)
				{
					bool flag = this.cursor != MouseCursor.Default;
					IntPtr intPtr = IntPtr.Zero;
					if (value == MouseCursor.Default)
					{
						this.cursor_handle = Functions.LoadCursor(CursorName.Arrow);
						intPtr = Functions.SetCursor(this.cursor_handle);
						this.cursor = value;
					}
					else
					{
						int stride = value.Width * (Image.GetPixelFormatSize(PixelFormat.Format32bppArgb) / 8);
						Bitmap bitmap;
						fixed (byte* data = value.Data)
						{
							bitmap = new Bitmap(value.Width, value.Height, stride, PixelFormat.Format32bppArgb, new IntPtr((void*)data));
						}
						using (bitmap)
						{
							IconInfo iconInfo = default(IconInfo);
							IntPtr hicon = bitmap.GetHicon();
							bool iconInfo2 = Functions.GetIconInfo(hicon, out iconInfo);
							if (iconInfo2)
							{
								iconInfo.xHotspot = value.X;
								iconInfo.yHotspot = value.Y;
								iconInfo.fIcon = false;
								IntPtr value2 = Functions.CreateIconIndirect(ref iconInfo);
								if (value2 != IntPtr.Zero)
								{
									this.cursor = value;
									this.cursor_handle = value2;
									intPtr = Functions.SetCursor(value2);
								}
							}
						}
					}
					if (flag && intPtr != IntPtr.Zero)
					{
						Functions.DestroyIcon(intPtr);
					}
				}
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x0001DB78 File Offset: 0x0001BD78
		// (set) Token: 0x06000906 RID: 2310 RVA: 0x0001DB88 File Offset: 0x0001BD88
		public override bool CursorVisible
		{
			get
			{
				return this.cursor_visible_count >= 0;
			}
			set
			{
				if (value && this.cursor_visible_count < 0)
				{
					do
					{
						this.cursor_visible_count = Functions.ShowCursor(true);
					}
					while (this.cursor_visible_count < 0);
					this.UngrabCursor();
					return;
				}
				if (!value && this.cursor_visible_count >= 0)
				{
					do
					{
						this.cursor_visible_count = Functions.ShowCursor(false);
					}
					while (this.cursor_visible_count >= 0);
					this.GrabCursor();
				}
			}
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0001DBE4 File Offset: 0x0001BDE4
		public override void Close()
		{
			Functions.PostMessage(this.window.Handle, WindowMessage.CLOSE, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0001DC04 File Offset: 0x0001BE04
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x0001DC0C File Offset: 0x0001BE0C
		public override WindowState WindowState
		{
			get
			{
				return this.windowState;
			}
			set
			{
				if (this.WindowState == value)
				{
					return;
				}
				ShowWindowCommand showWindowCommand = ShowWindowCommand.HIDE;
				bool flag = false;
				switch (value)
				{
				case WindowState.Normal:
					showWindowCommand = ShowWindowCommand.RESTORE;
					this.borderless_maximized_window_state = false;
					if (this.WindowState == WindowState.Fullscreen)
					{
						flag = true;
					}
					break;
				case WindowState.Minimized:
					showWindowCommand = ShowWindowCommand.MINIMIZE;
					break;
				case WindowState.Maximized:
					this.ResetWindowState();
					if (this.WindowBorder == WindowBorder.Hidden)
					{
						IntPtr hMonitor = Functions.MonitorFromWindow(this.window.Handle, MonitorFrom.Nearest);
						MonitorInfo monitorInfo = default(MonitorInfo);
						monitorInfo.Size = MonitorInfo.SizeInBytes;
						Functions.GetMonitorInfo(hMonitor, ref monitorInfo);
						this.previous_bounds = this.Bounds;
						this.borderless_maximized_window_state = true;
						this.Bounds = monitorInfo.Work.ToRectangle();
					}
					else
					{
						this.borderless_maximized_window_state = false;
						showWindowCommand = ShowWindowCommand.SHOWMAXIMIZED;
					}
					break;
				case WindowState.Fullscreen:
					this.ResetWindowState();
					this.previous_bounds = this.Bounds;
					this.previous_window_border = new WindowBorder?(this.WindowBorder);
					this.HideBorder();
					showWindowCommand = ShowWindowCommand.SHOWMAXIMIZED;
					Functions.SetForegroundWindow(this.window.Handle);
					break;
				}
				if (showWindowCommand != ShowWindowCommand.HIDE)
				{
					Functions.ShowWindow(this.window.Handle, showWindowCommand);
				}
				if (flag)
				{
					this.RestoreBorder();
				}
				if (showWindowCommand == ShowWindowCommand.RESTORE && this.previous_bounds != Rectangle.Empty)
				{
					this.Bounds = this.previous_bounds;
					this.previous_bounds = Rectangle.Empty;
				}
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x0001DD60 File Offset: 0x0001BF60
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x0001DD68 File Offset: 0x0001BF68
		public unsafe override WindowBorder WindowBorder
		{
			get
			{
				return this.windowBorder;
			}
			set
			{
				if (this.WindowState == WindowState.Fullscreen)
				{
					this.deferred_window_border = new WindowBorder?(value);
					return;
				}
				if (this.windowBorder == value)
				{
					return;
				}
				bool visible = this.Visible;
				WindowState windowState = this.WindowState;
				this.ResetWindowState();
				WindowStyle windowStyle = WindowStyle.ClipSiblings | WindowStyle.ClipChildren;
				WindowStyle windowStyle2 = windowStyle;
				switch (value)
				{
				case WindowBorder.Resizable:
					windowStyle2 |= WindowStyle.TiledWindow;
					break;
				case WindowBorder.Fixed:
					windowStyle2 |= (WindowStyle.Caption | WindowStyle.SystemMenu | WindowStyle.Group);
					break;
				case WindowBorder.Hidden:
					windowStyle2 |= (WindowStyle)2147483648U;
					break;
				}
				Size clientSize = this.ClientSize;
				Win32Rectangle win32Rectangle = Win32Rectangle.From(clientSize);
				Functions.AdjustWindowRectEx(ref win32Rectangle, windowStyle2, false, ExtendedWindowStyle.WindowEdge | ExtendedWindowStyle.ApplicationWindow);
				if (visible)
				{
					this.Visible = false;
				}
				Functions.SetWindowLong(this.window.Handle, GetWindowLongOffsets.STYLE, (IntPtr)((int)windowStyle2));
				Functions.SetWindowPos(this.window.Handle, IntPtr.Zero, 0, 0, win32Rectangle.Width, win32Rectangle.Height, SetWindowPosFlags.NOMOVE | SetWindowPosFlags.NOZORDER | SetWindowPosFlags.FRAMECHANGED);
				if (visible)
				{
					this.Visible = true;
				}
				this.WindowState = windowState;
				if (Configuration.RunningOnMono)
				{
					StyleStruct styleStruct = default(StyleStruct);
					styleStruct.New = windowStyle2;
					styleStruct.Old = windowStyle;
					this.HandleStyleChanged(this.window.Handle, WindowMessage.STYLECHANGED, new IntPtr(-4), new IntPtr((void*)(&styleStruct)));
				}
			}
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0001DEA4 File Offset: 0x0001C0A4
		public override Point PointToClient(Point point)
		{
			if (!Functions.ScreenToClient(this.window.Handle, ref point))
			{
				throw new InvalidOperationException(string.Format("Could not convert point {0} from screen to client coordinates. Windows error: {1}", point.ToString(), Marshal.GetLastWin32Error()));
			}
			return point;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0001DEE4 File Offset: 0x0001C0E4
		public override Point PointToScreen(Point point)
		{
			if (!Functions.ClientToScreen(this.window.Handle, ref point))
			{
				throw new InvalidOperationException(string.Format("Could not convert point {0} from screen to client coordinates. Windows error: {1}", point.ToString(), Marshal.GetLastWin32Error()));
			}
			return point;
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x0001DF24 File Offset: 0x0001C124
		public override void ProcessEvents()
		{
			base.ProcessEvents();
			while (Functions.PeekMessage(ref this.msg, IntPtr.Zero, 0, 0, PeekMessageFlags.Remove))
			{
				Functions.TranslateMessage(ref this.msg);
				Functions.DispatchMessage(ref this.msg);
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x0001DF5C File Offset: 0x0001C15C
		public override IWindowInfo WindowInfo
		{
			get
			{
				return this.child_window;
			}
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0001DF64 File Offset: 0x0001C164
		protected override void Dispose(bool calledManually)
		{
			if (!this.disposed)
			{
				if (calledManually)
				{
					if (this.Cursor != MouseCursor.Default && this.cursor_handle != IntPtr.Zero)
					{
						Functions.DestroyIcon(this.cursor_handle);
						this.cursor_handle = IntPtr.Zero;
					}
					this.DestroyWindow();
					if (this.Icon != null)
					{
						this.Icon.Dispose();
					}
				}
				base.OnDisposed(EventArgs.Empty);
				this.disposed = true;
			}
		}

		// Token: 0x04000712 RID: 1810
		private const ExtendedWindowStyle ParentStyleEx = ExtendedWindowStyle.WindowEdge | ExtendedWindowStyle.ApplicationWindow;

		// Token: 0x04000713 RID: 1811
		private const ExtendedWindowStyle ChildStyleEx = ExtendedWindowStyle.Left;

		// Token: 0x04000714 RID: 1812
		private const ClassStyle DefaultClassStyle = ClassStyle.OwnDC;

		// Token: 0x04000715 RID: 1813
		private const long ExtendedBit = 16777216L;

		// Token: 0x04000716 RID: 1814
		private readonly IntPtr Instance = Marshal.GetHINSTANCE(typeof(WinGLNative).Module);

		// Token: 0x04000717 RID: 1815
		private readonly IntPtr ClassName = Marshal.StringToHGlobalAuto(Guid.NewGuid().ToString());

		// Token: 0x04000718 RID: 1816
		private readonly WindowProcedure WindowProcedureDelegate;

		// Token: 0x04000719 RID: 1817
		private readonly uint ModalLoopTimerPeriod = 1U;

		// Token: 0x0400071A RID: 1818
		private UIntPtr timer_handle;

		// Token: 0x0400071B RID: 1819
		private bool class_registered;

		// Token: 0x0400071C RID: 1820
		private bool disposed;

		// Token: 0x0400071D RID: 1821
		private bool exists;

		// Token: 0x0400071E RID: 1822
		private WinWindowInfo window;

		// Token: 0x0400071F RID: 1823
		private WinWindowInfo child_window;

		// Token: 0x04000720 RID: 1824
		private WindowBorder windowBorder;

		// Token: 0x04000721 RID: 1825
		private WindowBorder? previous_window_border;

		// Token: 0x04000722 RID: 1826
		private WindowBorder? deferred_window_border;

		// Token: 0x04000723 RID: 1827
		private WindowState windowState;

		// Token: 0x04000724 RID: 1828
		private bool borderless_maximized_window_state;

		// Token: 0x04000725 RID: 1829
		private bool focused;

		// Token: 0x04000726 RID: 1830
		private bool mouse_outside_window = true;

		// Token: 0x04000727 RID: 1831
		private int mouse_last_timestamp;

		// Token: 0x04000728 RID: 1832
		private bool invisible_since_creation;

		// Token: 0x04000729 RID: 1833
		private int suppress_resize;

		// Token: 0x0400072A RID: 1834
		private bool is_in_modal_loop;

		// Token: 0x0400072B RID: 1835
		private Rectangle bounds = default(Rectangle);

		// Token: 0x0400072C RID: 1836
		private Rectangle client_rectangle = default(Rectangle);

		// Token: 0x0400072D RID: 1837
		private Rectangle previous_bounds = default(Rectangle);

		// Token: 0x0400072E RID: 1838
		private Icon icon;

		// Token: 0x0400072F RID: 1839
		public static readonly uint ShiftLeftScanCode = Functions.MapVirtualKey(VirtualKeys.LSHIFT, MapVirtualKeyType.VirtualKeyToScanCode);

		// Token: 0x04000730 RID: 1840
		public static readonly uint ShiftRightScanCode = Functions.MapVirtualKey(VirtualKeys.RSHIFT, MapVirtualKeyType.VirtualKeyToScanCode);

		// Token: 0x04000731 RID: 1841
		public static readonly uint ControlLeftScanCode = Functions.MapVirtualKey(VirtualKeys.LCONTROL, MapVirtualKeyType.VirtualKeyToScanCode);

		// Token: 0x04000732 RID: 1842
		public static readonly uint ControlRightScanCode = Functions.MapVirtualKey(VirtualKeys.RCONTROL, MapVirtualKeyType.VirtualKeyToScanCode);

		// Token: 0x04000733 RID: 1843
		public static readonly uint AltLeftScanCode = Functions.MapVirtualKey(VirtualKeys.LMENU, MapVirtualKeyType.VirtualKeyToScanCode);

		// Token: 0x04000734 RID: 1844
		public static readonly uint AltRightScanCode = Functions.MapVirtualKey(VirtualKeys.RMENU, MapVirtualKeyType.VirtualKeyToScanCode);

		// Token: 0x04000735 RID: 1845
		private MouseCursor cursor = MouseCursor.Default;

		// Token: 0x04000736 RID: 1846
		private IntPtr cursor_handle = Functions.LoadCursor(CursorName.Arrow);

		// Token: 0x04000737 RID: 1847
		private int cursor_visible_count;

		// Token: 0x04000738 RID: 1848
		private static readonly object SyncRoot = new object();

		// Token: 0x04000739 RID: 1849
		private StringBuilder sb_title = new StringBuilder(256);

		// Token: 0x0400073A RID: 1850
		private MSG msg;

		// Token: 0x020000D5 RID: 213
		private enum ScaleDirection
		{
			// Token: 0x0400073C RID: 1852
			X,
			// Token: 0x0400073D RID: 1853
			Y
		}
	}
}
