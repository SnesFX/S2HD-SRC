using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000132 RID: 306
	internal sealed class X11GLNative : NativeWindowBase
	{
		// Token: 0x06000AB5 RID: 2741 RVA: 0x00021D44 File Offset: 0x0001FF44
		public X11GLNative(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device) : this()
		{
			if (width <= 0)
			{
				throw new ArgumentOutOfRangeException("width", "Must be higher than zero.");
			}
			if (height <= 0)
			{
				throw new ArgumentOutOfRangeException("height", "Must be higher than zero.");
			}
			XVisualInfo xvisualInfo = default(XVisualInfo);
			using (new XLock(this.window.Display))
			{
				if (mode.Index == null)
				{
					mode = new X11GraphicsMode().SelectGraphicsMode(mode.ColorFormat, mode.Depth, mode.Stencil, mode.Samples, mode.AccumulatorFormat, mode.Buffers, mode.Stereo);
				}
				xvisualInfo.VisualID = mode.Index.Value;
				int num;
				this.window.VisualInfo = (XVisualInfo)Marshal.PtrToStructure(Functions.XGetVisualInfo(this.window.Display, XVisualInfoMask.ID, ref xvisualInfo, out num), typeof(XVisualInfo));
				XSetWindowAttributes value = default(XSetWindowAttributes);
				value.background_pixel = IntPtr.Zero;
				value.border_pixel = IntPtr.Zero;
				value.colormap = Functions.XCreateColormap(this.window.Display, this.window.RootWindow, this.window.VisualInfo.Visual, 0);
				this.window.EventMask = (EventMask.KeyPressMask | EventMask.KeyReleaseMask | EventMask.ButtonPressMask | EventMask.ButtonReleaseMask | EventMask.EnterWindowMask | EventMask.LeaveWindowMask | EventMask.PointerMotionMask | EventMask.KeymapStateMask | EventMask.ExposureMask | EventMask.StructureNotifyMask | EventMask.FocusChangeMask | EventMask.PropertyChangeMask);
				value.event_mask = (IntPtr)((long)this.window.EventMask);
				SetWindowValuemask valuemask = SetWindowValuemask.BackPixel | SetWindowValuemask.BorderPixel | SetWindowValuemask.EventMask | SetWindowValuemask.ColorMap;
				this.window.Handle = Functions.XCreateWindow(this.window.Display, this.window.RootWindow, x, y, width, height, 0, this.window.VisualInfo.Depth, CreateWindowArgs.ParentRelative, this.window.VisualInfo.Visual, valuemask, new XSetWindowAttributes?(value));
				if (this.window.Handle == IntPtr.Zero)
				{
					throw new ApplicationException("XCreateWindow call failed (returned 0).");
				}
				if (title != null)
				{
					Functions.XStoreName(this.window.Display, this.window.Handle, title);
				}
			}
			XSizeHints xsizeHints = default(XSizeHints);
			xsizeHints.base_width = width;
			xsizeHints.base_height = height;
			xsizeHints.flags = (IntPtr)12L;
			XClassHint xclassHint = default(XClassHint);
			xclassHint.Name = Assembly.GetEntryAssembly().GetName().Name.ToLower();
			xclassHint.Class = Assembly.GetEntryAssembly().GetName().Name;
			using (new XLock(this.window.Display))
			{
				Functions.XSetWMNormalHints(this.window.Display, this.window.Handle, ref xsizeHints);
				Functions.XSetWMProtocols(this.window.Display, this.window.Handle, new IntPtr[]
				{
					this._atom_wm_destroy
				}, 1);
				Functions.XSetClassHint(this.window.Display, this.window.Handle, ref xclassHint);
			}
			this.SetWindowMinMax(30, 30, -1, -1);
			XEvent xevent = default(XEvent);
			xevent.ConfigureEvent.x = x;
			xevent.ConfigureEvent.y = y;
			xevent.ConfigureEvent.width = width;
			xevent.ConfigureEvent.height = height;
			this.RefreshWindowBounds(ref xevent);
			this.EmptyCursor = X11GLNative.CreateEmptyCursor(this.window);
			using (new XLock(this.window.Display))
			{
				if (Xkb.IsSupported(this.window.Display))
				{
					bool flag;
					Xkb.SetDetectableAutoRepeat(this.window.Display, true, out flag);
				}
			}
			this.xi2_supported = XI2MouseKeyboard.IsSupported(this.window.Display);
			if (this.xi2_supported)
			{
				this.xi2_opcode = XI2MouseKeyboard.XIOpCode;
				this.xi2_version = XI2MouseKeyboard.XIVersion;
			}
			this.exists = true;
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x00022188 File Offset: 0x00020388
		public X11GLNative()
		{
			this.window.Display = Functions.XOpenDisplay(IntPtr.Zero);
			if (this.window.Display == IntPtr.Zero)
			{
				throw new Exception("Could not open connection to X");
			}
			using (new XLock(this.window.Display))
			{
				this.window.Screen = Functions.XDefaultScreen(this.window.Display);
				this.window.RootWindow = Functions.XRootWindow(this.window.Display, this.window.Screen);
				this.KeyMap = new X11KeyMap(this.window.Display);
			}
			this.RegisterAtoms(this.window);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x000222B8 File Offset: 0x000204B8
		private void RegisterAtoms(X11WindowInfo window)
		{
			using (new XLock(window.Display))
			{
				this._atom_wm_destroy = Functions.XInternAtom(window.Display, "WM_DELETE_WINDOW", true);
				this._atom_net_wm_state = Functions.XInternAtom(window.Display, "_NET_WM_STATE", false);
				this._atom_net_wm_state_minimized = Functions.XInternAtom(window.Display, "_NET_WM_STATE_MINIMIZED", false);
				this._atom_net_wm_state_fullscreen = Functions.XInternAtom(window.Display, "_NET_WM_STATE_FULLSCREEN", false);
				this._atom_net_wm_state_maximized_horizontal = Functions.XInternAtom(window.Display, "_NET_WM_STATE_MAXIMIZED_HORZ", false);
				this._atom_net_wm_state_maximized_vertical = Functions.XInternAtom(window.Display, "_NET_WM_STATE_MAXIMIZED_VERT", false);
				this._atom_net_wm_allowed_actions = Functions.XInternAtom(window.Display, "_NET_WM_ALLOWED_ACTIONS", false);
				this._atom_net_wm_action_resize = Functions.XInternAtom(window.Display, "_NET_WM_ACTION_RESIZE", false);
				this._atom_net_wm_action_maximize_horizontally = Functions.XInternAtom(window.Display, "_NET_WM_ACTION_MAXIMIZE_HORZ", false);
				this._atom_net_wm_action_maximize_vertically = Functions.XInternAtom(window.Display, "_NET_WM_ACTION_MAXIMIZE_VERT", false);
				this._atom_net_wm_icon = Functions.XInternAtom(window.Display, "_NEW_WM_ICON", false);
				this._atom_net_frame_extents = Functions.XInternAtom(window.Display, "_NET_FRAME_EXTENTS", false);
			}
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00022414 File Offset: 0x00020614
		private void SetWindowMinMax(int min_width, int min_height, int max_width, int max_height)
		{
			this.SetWindowMinMax((short)min_width, (short)min_height, (short)max_width, (short)max_height);
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x00022428 File Offset: 0x00020628
		private void SetWindowMinMax(short min_width, short min_height, short max_width, short max_height)
		{
			XSizeHints xsizeHints = default(XSizeHints);
			using (new XLock(this.window.Display))
			{
				IntPtr intPtr;
				Functions.XGetWMNormalHints(this.window.Display, this.window.Handle, ref xsizeHints, out intPtr);
			}
			if (min_width > 0 || min_height > 0)
			{
				xsizeHints.flags = (IntPtr)((int)xsizeHints.flags | 16);
				xsizeHints.min_width = (int)min_width;
				xsizeHints.min_height = (int)min_height;
			}
			else
			{
				xsizeHints.flags = (IntPtr)((int)xsizeHints.flags & -17);
			}
			if (max_width > 0 || max_height > 0)
			{
				xsizeHints.flags = (IntPtr)((int)xsizeHints.flags | 32);
				xsizeHints.max_width = (int)max_width;
				xsizeHints.max_height = (int)max_height;
			}
			else
			{
				xsizeHints.flags = (IntPtr)((int)xsizeHints.flags & -33);
			}
			if (xsizeHints.flags != IntPtr.Zero)
			{
				using (new XLock(this.window.Display))
				{
					Functions.XSetWMNormalHints(this.window.Display, this.window.Handle, ref xsizeHints);
				}
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x00022590 File Offset: 0x00020790
		private bool IsWindowBorderResizable
		{
			get
			{
				using (new XLock(this.window.Display))
				{
					XSizeHints xsizeHints = default(XSizeHints);
					IntPtr intPtr;
					if (Functions.XGetWMNormalHints(this.window.Display, this.window.Handle, ref xsizeHints, out intPtr) != 0)
					{
						return xsizeHints.min_width != xsizeHints.max_width || xsizeHints.min_height != xsizeHints.max_height;
					}
				}
				return false;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000ABB RID: 2747 RVA: 0x00022624 File Offset: 0x00020824
		private bool IsWindowBorderHidden
		{
			get
			{
				IntPtr zero = IntPtr.Zero;
				bool result;
				using (new XLock(this.window.Display))
				{
					IntPtr value = Functions.XInternAtom(this.window.Display, "_MOTIF_WM_HINTS", true);
					if (value != IntPtr.Zero && this._decorations_hidden)
					{
						result = true;
					}
					else
					{
						IntPtr value2;
						Functions.XGetTransientForHint(this.window.Display, this.window.Handle, out value2);
						if (value2 != IntPtr.Zero)
						{
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x000226CC File Offset: 0x000208CC
		private void DisableWindowDecorations()
		{
			if (this.DisableMotifDecorations())
			{
				this._decorations_hidden = true;
			}
			using (new XLock(this.window.Display))
			{
				Functions.XSetTransientForHint(this.window.Display, this.Handle, this.window.RootWindow);
				if (this._decorations_hidden)
				{
					Functions.XUnmapWindow(this.window.Display, this.Handle);
					Functions.XMapWindow(this.window.Display, this.Handle);
				}
			}
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00022774 File Offset: 0x00020974
		private bool DisableMotifDecorations()
		{
			bool result;
			using (new XLock(this.window.Display))
			{
				IntPtr intPtr = Functions.XInternAtom(this.window.Display, "_MOTIF_WM_HINTS", true);
				if (intPtr != IntPtr.Zero)
				{
					MotifWmHints motifWmHints = default(MotifWmHints);
					motifWmHints.flags = (IntPtr)2L;
					Functions.XChangeProperty(this.window.Display, this.Handle, intPtr, intPtr, 32, PropertyMode.Replace, ref motifWmHints, Marshal.SizeOf(motifWmHints) / IntPtr.Size);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x00022824 File Offset: 0x00020A24
		private bool DisableGnomeDecorations()
		{
			bool result;
			using (new XLock(this.window.Display))
			{
				IntPtr intPtr = Functions.XInternAtom(this.window.Display, "_WIN_HINTS", true);
				if (intPtr != IntPtr.Zero)
				{
					IntPtr zero = IntPtr.Zero;
					Functions.XChangeProperty(this.window.Display, this.Handle, intPtr, intPtr, 32, PropertyMode.Replace, ref zero, Marshal.SizeOf(zero) / IntPtr.Size);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x000228C4 File Offset: 0x00020AC4
		private void EnableWindowDecorations()
		{
			if (this.EnableMotifDecorations())
			{
				this._decorations_hidden = false;
			}
			using (new XLock(this.window.Display))
			{
				Functions.XSetTransientForHint(this.window.Display, this.Handle, IntPtr.Zero);
				if (!this._decorations_hidden)
				{
					Functions.XUnmapWindow(this.window.Display, this.Handle);
					Functions.XMapWindow(this.window.Display, this.Handle);
				}
			}
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00022964 File Offset: 0x00020B64
		private bool EnableMotifDecorations()
		{
			bool result;
			using (new XLock(this.window.Display))
			{
				IntPtr intPtr = Functions.XInternAtom(this.window.Display, "_MOTIF_WM_HINTS", true);
				if (intPtr != IntPtr.Zero)
				{
					MotifWmHints motifWmHints = default(MotifWmHints);
					motifWmHints.flags = (IntPtr)2L;
					motifWmHints.decorations = (IntPtr)1L;
					Functions.XChangeProperty(this.window.Display, this.Handle, intPtr, intPtr, 32, PropertyMode.Replace, ref motifWmHints, Marshal.SizeOf(motifWmHints) / IntPtr.Size);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x00022A20 File Offset: 0x00020C20
		private bool EnableGnomeDecorations()
		{
			bool result;
			using (new XLock(this.window.Display))
			{
				IntPtr intPtr = Functions.XInternAtom(this.window.Display, "_WIN_HINTS", true);
				if (intPtr != IntPtr.Zero)
				{
					Functions.XDeleteProperty(this.window.Display, this.Handle, intPtr);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00022AA4 File Offset: 0x00020CA4
		private static void DeleteIconPixmaps(IntPtr display, IntPtr window)
		{
			using (new XLock(display))
			{
				IntPtr intPtr = Functions.XGetWMHints(display, window);
				if (intPtr != IntPtr.Zero)
				{
					XWMHints xwmhints = (XWMHints)Marshal.PtrToStructure(intPtr, typeof(XWMHints));
					XWMHintsFlags xwmhintsFlags = (XWMHintsFlags)xwmhints.flags.ToInt32();
					if ((xwmhintsFlags & XWMHintsFlags.IconPixmapHint) != (XWMHintsFlags)0)
					{
						xwmhints.flags = new IntPtr((int)(xwmhintsFlags & ~XWMHintsFlags.IconPixmapHint));
						Functions.XFreePixmap(display, xwmhints.icon_pixmap);
					}
					if ((xwmhintsFlags & XWMHintsFlags.IconMaskHint) != (XWMHintsFlags)0)
					{
						xwmhints.flags = new IntPtr((int)(xwmhintsFlags & ~XWMHintsFlags.IconMaskHint));
						Functions.XFreePixmap(display, xwmhints.icon_mask);
					}
					Functions.XSetWMHints(display, window, ref xwmhints);
					Functions.XFree(intPtr);
				}
			}
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00022B68 File Offset: 0x00020D68
		private bool RefreshWindowBorders()
		{
			bool result = false;
			if (this.IsWindowBorderHidden)
			{
				result = (this.border_left != 0 || this.border_right != 0 || this.border_top != 0 || this.border_bottom != 0);
				this.border_left = 0;
				this.border_right = 0;
				this.border_top = 0;
				this.border_bottom = 0;
			}
			else
			{
				IntPtr zero = IntPtr.Zero;
				IntPtr value;
				using (new XLock(this.window.Display))
				{
					IntPtr intPtr;
					int num;
					IntPtr intPtr2;
					Functions.XGetWindowProperty(this.window.Display, this.window.Handle, this._atom_net_frame_extents, IntPtr.Zero, new IntPtr(16), false, (IntPtr)6L, out intPtr, out num, out value, out intPtr2, ref zero);
				}
				if (zero != IntPtr.Zero)
				{
					if ((long)value == 4L)
					{
						int num2 = Marshal.ReadIntPtr(zero, 0).ToInt32();
						int num3 = Marshal.ReadIntPtr(zero, IntPtr.Size).ToInt32();
						int num4 = Marshal.ReadIntPtr(zero, IntPtr.Size * 2).ToInt32();
						int num5 = Marshal.ReadIntPtr(zero, IntPtr.Size * 3).ToInt32();
						result = (num2 != this.border_left || num3 != this.border_right || num4 != this.border_top || num5 != this.border_bottom);
						this.border_left = num2;
						this.border_right = num3;
						this.border_top = num4;
						this.border_bottom = num5;
					}
					using (new XLock(this.window.Display))
					{
						Functions.XFree(zero);
					}
				}
			}
			return result;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00022D44 File Offset: 0x00020F44
		private void RefreshWindowBounds(ref XEvent e)
		{
			this.RefreshWindowBorders();
			int x;
			int y;
			if (!e.ConfigureEvent.send_event)
			{
				IntPtr intPtr;
				Functions.XTranslateCoordinates(this.window.Display, this.window.Handle, this.window.RootWindow, 0, 0, out x, out y, out intPtr);
			}
			else
			{
				x = e.ConfigureEvent.x;
				y = e.ConfigureEvent.y;
			}
			Point point = new Point(x - this.border_left, y - this.border_top);
			if (this.Location != point)
			{
				this.bounds.Location = point;
				base.OnMove(EventArgs.Empty);
			}
			Size size = new Size(e.ConfigureEvent.width + this.border_left + this.border_right, e.ConfigureEvent.height + this.border_top + this.border_bottom);
			if (this.Bounds.Size != size)
			{
				this.bounds.Size = size;
				this.client_rectangle.Size = new Size(Math.Max(e.ConfigureEvent.width, 1), Math.Max(e.ConfigureEvent.height, 1));
				base.OnResize(EventArgs.Empty);
			}
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00022E88 File Offset: 0x00021088
		private static IntPtr CreateEmptyCursor(X11WindowInfo window)
		{
			IntPtr result = IntPtr.Zero;
			using (new XLock(window.Display))
			{
				IntPtr colormap = Functions.XDefaultColormap(window.Display, window.Screen);
				XColor xcolor;
				XColor xcolor2;
				Functions.XAllocNamedColor(window.Display, colormap, "black", out xcolor, out xcolor2);
				IntPtr display = window.Display;
				IntPtr handle = window.Handle;
				byte[,] data = new byte[1, 1];
				IntPtr intPtr = Functions.XCreateBitmapFromData(display, handle, data);
				result = Functions.XCreatePixmapCursor(window.Display, intPtr, intPtr, ref xcolor, ref xcolor, 0, 0);
			}
			return result;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00022F28 File Offset: 0x00021128
		public override void ProcessEvents()
		{
			base.ProcessEvents();
			while (this.Exists && this.window != null)
			{
				using (new XLock(this.window.Display))
				{
					if (!Functions.XCheckWindowEvent(this.window.Display, this.window.Handle, this.window.EventMask, ref this.e) && !Functions.XCheckTypedWindowEvent(this.window.Display, this.window.Handle, XEventName.ClientMessage, ref this.e))
					{
						break;
					}
				}
				switch (this.e.type)
				{
				case XEventName.KeyPress:
				case XEventName.KeyRelease:
				{
					bool flag = this.e.type == XEventName.KeyPress;
					Key key;
					if (this.KeyMap.TranslateKey(ref this.e.KeyEvent, out key))
					{
						if (flag)
						{
							bool repeat = this.KeyboardState[key];
							base.OnKeyDown(key, repeat);
						}
						else
						{
							base.OnKeyUp(key);
						}
						if (flag)
						{
							int num = Functions.XLookupString(ref this.e.KeyEvent, this.ascii, this.ascii.Length, null, IntPtr.Zero);
							Encoding.Default.GetChars(this.ascii, 0, num, this.chars, 0);
							for (int i = 0; i < num; i++)
							{
								if (!char.IsControl(this.chars[i]))
								{
									base.OnKeyPress(this.chars[i]);
								}
							}
						}
					}
					break;
				}
				case XEventName.ButtonPress:
				{
					float num2;
					float num3;
					MouseButton mouseButton = X11KeyMap.TranslateButton(this.e.ButtonEvent.button, out num2, out num3);
					if (mouseButton != MouseButton.LastButton)
					{
						base.OnMouseDown(mouseButton);
					}
					if (this.xi2_version >= 210)
					{
						MouseState cursorState = Mouse.GetCursorState();
						num2 = cursorState.Scroll.X - this.MouseState.Scroll.X;
						num3 = cursorState.Scroll.Y - this.MouseState.Scroll.Y;
					}
					if (num2 != 0f || num3 != 0f)
					{
						base.OnMouseWheel(num2, num3);
					}
					break;
				}
				case XEventName.ButtonRelease:
				{
					float num4;
					float num5;
					MouseButton mouseButton2 = X11KeyMap.TranslateButton(this.e.ButtonEvent.button, out num4, out num5);
					if (mouseButton2 != MouseButton.LastButton)
					{
						base.OnMouseUp(mouseButton2);
					}
					break;
				}
				case XEventName.MotionNotify:
				{
					int x = this.e.MotionEvent.x;
					int y = this.e.MotionEvent.y;
					if (x != 0 || y != 0)
					{
						base.OnMouseMove(MathHelper.Clamp(x, 0, base.Width), MathHelper.Clamp(y, 0, base.Height));
					}
					break;
				}
				case XEventName.EnterNotify:
					base.OnMouseEnter(EventArgs.Empty);
					break;
				case XEventName.LeaveNotify:
					if (this.CursorVisible)
					{
						int num6 = MathHelper.Clamp(this.e.CrossingEvent.x, 0, base.Width);
						int num7 = MathHelper.Clamp(this.e.CrossingEvent.y, 0, base.Height);
						if (num6 != this.MouseState.X || num7 != this.MouseState.Y)
						{
							base.OnMouseMove(num6, num7);
						}
						base.OnMouseLeave(EventArgs.Empty);
					}
					break;
				case XEventName.FocusIn:
				{
					bool flag2 = this.has_focus;
					this.has_focus = true;
					if (this.has_focus != flag2)
					{
						base.OnFocusedChanged(EventArgs.Empty);
					}
					if (this.Focused && !this.CursorVisible)
					{
						this.GrabMouse();
					}
					break;
				}
				case XEventName.FocusOut:
				{
					bool flag3 = this.has_focus;
					this.has_focus = false;
					if (this.has_focus != flag3)
					{
						base.OnFocusedChanged(EventArgs.Empty);
					}
					break;
				}
				case XEventName.DestroyNotify:
					this.exists = false;
					return;
				case XEventName.UnmapNotify:
				{
					bool flag4 = this.visible;
					this.visible = false;
					if (this.visible != flag4)
					{
						base.OnVisibleChanged(EventArgs.Empty);
					}
					break;
				}
				case XEventName.MapNotify:
				{
					bool flag5 = this.visible;
					this.visible = true;
					if (this.visible != flag5)
					{
						base.OnVisibleChanged(EventArgs.Empty);
					}
					return;
				}
				case XEventName.ConfigureNotify:
					this.RefreshWindowBounds(ref this.e);
					break;
				case XEventName.PropertyNotify:
					if (this.e.PropertyEvent.atom == this._atom_net_wm_state)
					{
						base.OnWindowStateChanged(EventArgs.Empty);
					}
					break;
				case XEventName.ClientMessage:
					if (!this.isExiting && this.e.ClientMessageEvent.ptr1 == this._atom_wm_destroy)
					{
						CancelEventArgs cancelEventArgs = new CancelEventArgs();
						base.OnClosing(cancelEventArgs);
						if (!cancelEventArgs.Cancel)
						{
							this.isExiting = true;
							this.DestroyWindow();
							base.OnClosed(EventArgs.Empty);
						}
					}
					break;
				case XEventName.MappingNotify:
					if (this.e.MappingEvent.request == 0 || this.e.MappingEvent.request == 1)
					{
						Functions.XRefreshKeyboardMapping(ref this.e.MappingEvent);
						this.KeyMap.RefreshKeycodes(this.window.Display);
					}
					break;
				}
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x000234BC File Offset: 0x000216BC
		// (set) Token: 0x06000AC8 RID: 2760 RVA: 0x000234C4 File Offset: 0x000216C4
		public override Rectangle Bounds
		{
			get
			{
				return this.bounds;
			}
			set
			{
				bool flag = this.bounds.Location != value.Location;
				bool flag2 = this.bounds.Size != value.Size;
				int x = value.X;
				int y = value.Y;
				int num = value.Width - this.border_left - this.border_right;
				int num2 = value.Height - this.border_top - this.border_bottom;
				if (this.WindowBorder != WindowBorder.Resizable)
				{
					this.SetWindowMinMax(num, num2, num, num2);
				}
				using (new XLock(this.window.Display))
				{
					if (flag && flag2)
					{
						Functions.XMoveResizeWindow(this.window.Display, this.window.Handle, x, y, num, num2);
					}
					else if (flag)
					{
						Functions.XMoveWindow(this.window.Display, this.window.Handle, x, y);
					}
					else if (flag2)
					{
						Functions.XResizeWindow(this.window.Display, this.window.Handle, num, num2);
					}
				}
				this.ProcessEvents();
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x00023600 File Offset: 0x00021800
		// (set) Token: 0x06000ACA RID: 2762 RVA: 0x00023610 File Offset: 0x00021810
		public override Size ClientSize
		{
			get
			{
				return this.client_rectangle.Size;
			}
			set
			{
				using (new XLock(this.window.Display))
				{
					Functions.XResizeWindow(this.window.Display, this.window.Handle, value.Width, value.Height);
				}
				this.ProcessEvents();
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000ACB RID: 2763 RVA: 0x00023680 File Offset: 0x00021880
		// (set) Token: 0x06000ACC RID: 2764 RVA: 0x00023688 File Offset: 0x00021888
		public override Icon Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				if (value == this.icon)
				{
					return;
				}
				if (value == null)
				{
					using (new XLock(this.window.Display))
					{
						Functions.XDeleteProperty(this.window.Display, this.window.Handle, this._atom_net_wm_icon);
						X11GLNative.DeleteIconPixmaps(this.window.Display, this.window.Handle);
						goto IL_26E;
					}
				}
				Bitmap bitmap = value.ToBitmap();
				int num = bitmap.Width * bitmap.Height + 2;
				IntPtr[] array = new IntPtr[num];
				int num2 = 0;
				array[num2++] = (IntPtr)bitmap.Width;
				array[num2++] = (IntPtr)bitmap.Height;
				for (int i = 0; i < bitmap.Height; i++)
				{
					for (int j = 0; j < bitmap.Width; j++)
					{
						array[num2++] = (IntPtr)bitmap.GetPixel(j, i).ToArgb();
					}
				}
				using (new XLock(this.window.Display))
				{
					Functions.XChangeProperty(this.window.Display, this.window.Handle, this._atom_net_wm_icon, this._atom_xa_cardinal, 32, PropertyMode.Replace, array, num);
				}
				X11GLNative.DeleteIconPixmaps(this.window.Display, this.window.Handle);
				using (new XLock(this.window.Display))
				{
					IntPtr intPtr = Functions.XGetWMHints(this.window.Display, this.window.Handle);
					if (intPtr == IntPtr.Zero)
					{
						intPtr = Functions.XAllocWMHints();
					}
					XWMHints xwmhints = (XWMHints)Marshal.PtrToStructure(intPtr, typeof(XWMHints));
					xwmhints.flags = new IntPtr(xwmhints.flags.ToInt32() | 36);
					xwmhints.icon_pixmap = Functions.CreatePixmapFromImage(this.window.Display, bitmap);
					xwmhints.icon_mask = Functions.CreateMaskFromImage(this.window.Display, bitmap);
					Functions.XSetWMHints(this.window.Display, this.window.Handle, ref xwmhints);
					Functions.XFree(intPtr);
					Functions.XSync(this.window.Display, false);
				}
				IL_26E:
				this.icon = value;
				base.OnIconChanged(EventArgs.Empty);
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x00023940 File Offset: 0x00021B40
		public override bool Focused
		{
			get
			{
				return this.has_focus;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x00023948 File Offset: 0x00021B48
		// (set) Token: 0x06000ACF RID: 2767 RVA: 0x00023AB4 File Offset: 0x00021CB4
		public override WindowState WindowState
		{
			get
			{
				IntPtr zero = IntPtr.Zero;
				bool flag = false;
				int num = 0;
				bool flag2 = false;
				IntPtr value;
				using (new XLock(this.window.Display))
				{
					IntPtr intPtr;
					int num2;
					IntPtr intPtr2;
					Functions.XGetWindowProperty(this.window.Display, this.window.Handle, this._atom_net_wm_state, IntPtr.Zero, new IntPtr(256), false, new IntPtr(4), out intPtr, out num2, out value, out intPtr2, ref zero);
				}
				if ((long)value > 0L && zero != IntPtr.Zero)
				{
					int num3 = 0;
					while ((long)num3 < (long)value)
					{
						IntPtr value2 = Marshal.ReadIntPtr(zero, num3 * IntPtr.Size);
						if (value2 == this._atom_net_wm_state_maximized_horizontal || value2 == this._atom_net_wm_state_maximized_vertical)
						{
							num++;
						}
						else if (value2 == this._atom_net_wm_state_minimized)
						{
							flag2 = true;
						}
						else if (value2 == this._atom_net_wm_state_fullscreen)
						{
							flag = true;
						}
						num3++;
					}
					using (new XLock(this.window.Display))
					{
						Functions.XFree(zero);
					}
				}
				if (flag2)
				{
					return WindowState.Minimized;
				}
				if (num == 2)
				{
					return WindowState.Maximized;
				}
				if (flag)
				{
					return WindowState.Fullscreen;
				}
				return WindowState.Normal;
			}
			set
			{
				WindowState windowState = this.WindowState;
				if (windowState == WindowState.Normal)
				{
					this._previous_window_border = this.WindowBorder;
					this._previous_window_size = this.ClientSize;
				}
				if (windowState == value)
				{
					return;
				}
				if (value != WindowState.Minimized)
				{
					if (this.WindowBorder == WindowBorder.Fixed)
					{
						this.ChangeWindowBorder(WindowBorder.Resizable);
					}
					this.ResetWindowState(windowState);
				}
				this.ChangeWindowState(value);
				this.ProcessEvents();
			}
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00023B10 File Offset: 0x00021D10
		private void ResetWindowState(WindowState current_state)
		{
			if (current_state != WindowState.Normal)
			{
				using (new XLock(this.window.Display))
				{
					switch (current_state)
					{
					case WindowState.Minimized:
						Functions.XMapWindow(this.window.Display, this.window.Handle);
						break;
					case WindowState.Maximized:
						Functions.SendNetWMMessage(this.window, this._atom_net_wm_state, X11GLNative._atom_toggle, this._atom_net_wm_state_maximized_horizontal, this._atom_net_wm_state_maximized_vertical);
						break;
					case WindowState.Fullscreen:
						Functions.SendNetWMMessage(this.window, this._atom_net_wm_state, X11GLNative._atom_remove, this._atom_net_wm_state_fullscreen, IntPtr.Zero);
						break;
					}
				}
			}
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00023BD0 File Offset: 0x00021DD0
		private void ChangeWindowState(WindowState value)
		{
			using (new XLock(this.window.Display))
			{
				switch (value)
				{
				case WindowState.Normal:
					Functions.XRaiseWindow(this.window.Display, this.window.Handle);
					this.ChangeWindowBorder(this._previous_window_border, this._previous_window_size.Width, this._previous_window_size.Height);
					break;
				case WindowState.Minimized:
					Functions.XIconifyWindow(this.window.Display, this.window.Handle, this.window.Screen);
					break;
				case WindowState.Maximized:
					Functions.SendNetWMMessage(this.window, this._atom_net_wm_state, X11GLNative._atom_add, this._atom_net_wm_state_maximized_horizontal, this._atom_net_wm_state_maximized_vertical);
					Functions.XRaiseWindow(this.window.Display, this.window.Handle);
					break;
				case WindowState.Fullscreen:
					Functions.SendNetWMMessage(this.window, this._atom_net_wm_state, X11GLNative._atom_add, this._atom_net_wm_state_fullscreen, IntPtr.Zero);
					Functions.XRaiseWindow(this.window.Display, this.window.Handle);
					break;
				}
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x00023D20 File Offset: 0x00021F20
		// (set) Token: 0x06000AD3 RID: 2771 RVA: 0x00023D50 File Offset: 0x00021F50
		public override WindowBorder WindowBorder
		{
			get
			{
				if (this.IsWindowBorderHidden || this.WindowState == WindowState.Fullscreen)
				{
					return WindowBorder.Hidden;
				}
				if (!this.IsWindowBorderResizable)
				{
					return WindowBorder.Fixed;
				}
				if (this.WindowState == WindowState.Maximized)
				{
					return this._previous_window_border;
				}
				return WindowBorder.Resizable;
			}
			set
			{
				if (this.WindowBorder == value)
				{
					return;
				}
				if (this.WindowState == WindowState.Fullscreen)
				{
					this._previous_window_border = value;
					return;
				}
				this.ChangeWindowBorder(value);
				base.OnWindowBorderChanged(EventArgs.Empty);
			}
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00023D80 File Offset: 0x00021F80
		private void ChangeWindowBorder(WindowBorder value)
		{
			this.ChangeWindowBorder(value, base.Width, base.Height);
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00023D98 File Offset: 0x00021F98
		private void ChangeWindowBorder(WindowBorder value, int width, int height)
		{
			if (this.WindowBorder == WindowBorder.Hidden)
			{
				this.EnableWindowDecorations();
			}
			switch (value)
			{
			case WindowBorder.Resizable:
				this.SetWindowMinMax(30, 30, -1, -1);
				break;
			case WindowBorder.Fixed:
				this.SetWindowMinMax((short)width, (short)height, (short)width, (short)height);
				break;
			case WindowBorder.Hidden:
				this.SetWindowMinMax(30, 30, -1, -1);
				this.DisableWindowDecorations();
				break;
			}
			this.ProcessEvents();
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x00023E00 File Offset: 0x00022000
		// (set) Token: 0x06000AD7 RID: 2775 RVA: 0x00023E08 File Offset: 0x00022008
		public unsafe override MouseCursor Cursor
		{
			get
			{
				return this.cursor;
			}
			set
			{
				if (value == this.cursor)
				{
					return;
				}
				using (new XLock(this.window.Display))
				{
					if (value == MouseCursor.Default)
					{
						this.cursorHandle = IntPtr.Zero;
					}
					else if (value == MouseCursor.Empty)
					{
						this.cursorHandle = this.EmptyCursor;
					}
					else
					{
						try
						{
							fixed (byte* ptr = value.Data)
							{
								XcursorImage* ptr2 = Functions.XcursorImageCreate(value.Width, value.Height);
								ptr2->xhot = (uint)value.X;
								ptr2->yhot = (uint)value.Y;
								ptr2->pixels = (uint*)ptr;
								ptr2->delay = 0U;
								this.cursorHandle = Functions.XcursorImageLoadCursor(this.window.Display, ptr2);
								Functions.XcursorImageDestroy(ptr2);
							}
						}
						finally
						{
							byte* ptr = null;
						}
					}
					if (this.CursorVisible)
					{
						Functions.XDefineCursor(this.window.Display, this.window.Handle, this.cursorHandle);
					}
					this.cursor = value;
				}
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x00023F34 File Offset: 0x00022134
		// (set) Token: 0x06000AD9 RID: 2777 RVA: 0x00023F3C File Offset: 0x0002213C
		public override bool CursorVisible
		{
			get
			{
				return this.cursor_visible;
			}
			set
			{
				if (value)
				{
					using (new XLock(this.window.Display))
					{
						this.UngrabMouse();
						Point point = this.PointToScreen(new Point(this.MouseState.X, this.MouseState.Y));
						Mouse.SetPosition((double)point.X, (double)point.Y);
						Functions.XDefineCursor(this.window.Display, this.window.Handle, this.cursorHandle);
						this.cursor_visible = true;
						return;
					}
				}
				using (new XLock(this.window.Display))
				{
					this.GrabMouse();
					this.cursor_visible = false;
				}
			}
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x00024020 File Offset: 0x00022220
		private void GrabMouse()
		{
			Functions.XGrabPointer(this.window.Display, this.window.Handle, false, EventMask.ButtonPressMask | EventMask.ButtonReleaseMask | EventMask.PointerMotionMask, GrabMode.GrabModeAsync, GrabMode.GrabModeAsync, this.window.Handle, this.EmptyCursor, IntPtr.Zero);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x00024064 File Offset: 0x00022264
		private void UngrabMouse()
		{
			Functions.XUngrabPointer(this.window.Display, IntPtr.Zero);
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x0002407C File Offset: 0x0002227C
		public override bool Exists
		{
			get
			{
				return this.exists;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x00024084 File Offset: 0x00022284
		public bool IsIdle
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x00024090 File Offset: 0x00022290
		public IntPtr Handle
		{
			get
			{
				return this.window.Handle;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x000240A0 File Offset: 0x000222A0
		// (set) Token: 0x06000AE0 RID: 2784 RVA: 0x0002411C File Offset: 0x0002231C
		public override string Title
		{
			get
			{
				IntPtr zero = IntPtr.Zero;
				using (new XLock(this.window.Display))
				{
					Functions.XFetchName(this.window.Display, this.window.Handle, ref zero);
				}
				if (zero != IntPtr.Zero)
				{
					return Marshal.PtrToStringAnsi(zero);
				}
				return string.Empty;
			}
			set
			{
				if (value != null && value != this.Title)
				{
					using (new XLock(this.window.Display))
					{
						Functions.XStoreName(this.window.Display, this.window.Handle, value);
					}
				}
				base.OnTitleChanged(EventArgs.Empty);
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x00024194 File Offset: 0x00022394
		// (set) Token: 0x06000AE2 RID: 2786 RVA: 0x0002419C File Offset: 0x0002239C
		public override bool Visible
		{
			get
			{
				return this.visible;
			}
			set
			{
				if (value && !this.visible)
				{
					using (new XLock(this.window.Display))
					{
						Functions.XMapWindow(this.window.Display, this.window.Handle);
						return;
					}
				}
				if (!value && this.visible)
				{
					using (new XLock(this.window.Display))
					{
						Functions.XUnmapWindow(this.window.Display, this.window.Handle);
					}
				}
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x00024258 File Offset: 0x00022458
		public override IWindowInfo WindowInfo
		{
			get
			{
				return this.window;
			}
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00024260 File Offset: 0x00022460
		public override void Close()
		{
			this.Exit();
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00024268 File Offset: 0x00022468
		public void Exit()
		{
			XEvent xevent = default(XEvent);
			xevent.type = XEventName.ClientMessage;
			xevent.ClientMessageEvent.format = 32;
			xevent.ClientMessageEvent.display = this.window.Display;
			xevent.ClientMessageEvent.window = this.window.Handle;
			xevent.ClientMessageEvent.ptr1 = this._atom_wm_destroy;
			using (new XLock(this.window.Display))
			{
				Functions.XSendEvent(this.window.Display, this.window.Handle, false, EventMask.NoEventMask, ref xevent);
				Functions.XFlush(this.window.Display);
			}
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00024338 File Offset: 0x00022538
		public void DestroyWindow()
		{
			using (new XLock(this.window.Display))
			{
				Functions.XSync(this.window.Display, true);
				Functions.XDestroyWindow(this.window.Display, this.window.Handle);
				this.exists = false;
			}
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x000243AC File Offset: 0x000225AC
		public override Point PointToClient(Point point)
		{
			int x;
			int y;
			using (new XLock(this.window.Display))
			{
				IntPtr intPtr;
				Functions.XTranslateCoordinates(this.window.Display, this.window.RootWindow, this.window.Handle, point.X, point.Y, out x, out y, out intPtr);
			}
			point.X = x;
			point.Y = y;
			return point;
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00024438 File Offset: 0x00022638
		public override Point PointToScreen(Point point)
		{
			int x;
			int y;
			using (new XLock(this.window.Display))
			{
				IntPtr intPtr;
				Functions.XTranslateCoordinates(this.window.Display, this.window.Handle, this.window.RootWindow, point.X, point.Y, out x, out y, out intPtr);
			}
			point.X = x;
			point.Y = y;
			return point;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x000244C4 File Offset: 0x000226C4
		protected override void Dispose(bool manuallyCalled)
		{
			if (!this.disposed)
			{
				if (manuallyCalled && this.window != null && this.window.Handle != IntPtr.Zero)
				{
					Functions.XFreeCursor(this.window.Display, this.EmptyCursor);
					if (this.cursorHandle != IntPtr.Zero)
					{
						Functions.XFreeCursor(this.window.Display, this.cursorHandle);
					}
					if (this.Exists)
					{
						this.DestroyWindow();
					}
					this.window.Dispose();
				}
				this.disposed = true;
			}
		}

		// Token: 0x04000BFF RID: 3071
		private const int _min_width = 30;

		// Token: 0x04000C00 RID: 3072
		private const int _min_height = 30;

		// Token: 0x04000C01 RID: 3073
		private const string MOTIF_WM_ATOM = "_MOTIF_WM_HINTS";

		// Token: 0x04000C02 RID: 3074
		private const string KDE_WM_ATOM = "KWM_WIN_DECORATION";

		// Token: 0x04000C03 RID: 3075
		private const string KDE_NET_WM_ATOM = "_KDE_NET_WM_WINDOW_TYPE";

		// Token: 0x04000C04 RID: 3076
		private const string ICCM_WM_ATOM = "_NET_WM_WINDOW_TYPE";

		// Token: 0x04000C05 RID: 3077
		private const string ICON_NET_ATOM = "_NET_WM_ICON";

		// Token: 0x04000C06 RID: 3078
		private readonly X11WindowInfo window = new X11WindowInfo();

		// Token: 0x04000C07 RID: 3079
		private readonly X11KeyMap KeyMap;

		// Token: 0x04000C08 RID: 3080
		private IntPtr _atom_wm_destroy;

		// Token: 0x04000C09 RID: 3081
		private IntPtr _atom_net_wm_state;

		// Token: 0x04000C0A RID: 3082
		private IntPtr _atom_net_wm_state_minimized;

		// Token: 0x04000C0B RID: 3083
		private IntPtr _atom_net_wm_state_fullscreen;

		// Token: 0x04000C0C RID: 3084
		private IntPtr _atom_net_wm_state_maximized_horizontal;

		// Token: 0x04000C0D RID: 3085
		private IntPtr _atom_net_wm_state_maximized_vertical;

		// Token: 0x04000C0E RID: 3086
		private IntPtr _atom_net_wm_allowed_actions;

		// Token: 0x04000C0F RID: 3087
		private IntPtr _atom_net_wm_action_resize;

		// Token: 0x04000C10 RID: 3088
		private IntPtr _atom_net_wm_action_maximize_horizontally;

		// Token: 0x04000C11 RID: 3089
		private IntPtr _atom_net_wm_action_maximize_vertically;

		// Token: 0x04000C12 RID: 3090
		private IntPtr _atom_net_wm_icon;

		// Token: 0x04000C13 RID: 3091
		private IntPtr _atom_net_frame_extents;

		// Token: 0x04000C14 RID: 3092
		private IntPtr _atom_wm_class;

		// Token: 0x04000C15 RID: 3093
		private readonly IntPtr _atom_xa_cardinal = new IntPtr(6);

		// Token: 0x04000C16 RID: 3094
		private static readonly IntPtr _atom_remove = (IntPtr)0;

		// Token: 0x04000C17 RID: 3095
		private static readonly IntPtr _atom_add = (IntPtr)1;

		// Token: 0x04000C18 RID: 3096
		private static readonly IntPtr _atom_toggle = (IntPtr)2;

		// Token: 0x04000C19 RID: 3097
		private Rectangle bounds;

		// Token: 0x04000C1A RID: 3098
		private Rectangle client_rectangle;

		// Token: 0x04000C1B RID: 3099
		private int border_left;

		// Token: 0x04000C1C RID: 3100
		private int border_right;

		// Token: 0x04000C1D RID: 3101
		private int border_top;

		// Token: 0x04000C1E RID: 3102
		private int border_bottom;

		// Token: 0x04000C1F RID: 3103
		private Icon icon;

		// Token: 0x04000C20 RID: 3104
		private bool has_focus;

		// Token: 0x04000C21 RID: 3105
		private bool visible;

		// Token: 0x04000C22 RID: 3106
		private XEvent e = default(XEvent);

		// Token: 0x04000C23 RID: 3107
		private bool disposed;

		// Token: 0x04000C24 RID: 3108
		private bool exists;

		// Token: 0x04000C25 RID: 3109
		private bool isExiting;

		// Token: 0x04000C26 RID: 3110
		private bool _decorations_hidden;

		// Token: 0x04000C27 RID: 3111
		private WindowBorder _previous_window_border;

		// Token: 0x04000C28 RID: 3112
		private Size _previous_window_size;

		// Token: 0x04000C29 RID: 3113
		private MouseCursor cursor = MouseCursor.Default;

		// Token: 0x04000C2A RID: 3114
		private IntPtr cursorHandle;

		// Token: 0x04000C2B RID: 3115
		private bool cursor_visible = true;

		// Token: 0x04000C2C RID: 3116
		private readonly byte[] ascii = new byte[16];

		// Token: 0x04000C2D RID: 3117
		private readonly char[] chars = new char[16];

		// Token: 0x04000C2E RID: 3118
		private readonly IntPtr EmptyCursor;

		// Token: 0x04000C2F RID: 3119
		private readonly bool xi2_supported;

		// Token: 0x04000C30 RID: 3120
		private readonly int xi2_opcode;

		// Token: 0x04000C31 RID: 3121
		private readonly int xi2_version;
	}
}
