using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B0D RID: 2829
	internal class CocoaNativeWindow : NativeWindowBase
	{
		// Token: 0x060059C3 RID: 22979 RVA: 0x000F404C File Offset: 0x000F224C
		static CocoaNativeWindow()
		{
			Cocoa.Initialize();
			NSApplication.Initialize();
			CocoaNativeWindow.NSDefaultRunLoopMode = Cocoa.GetStringConstant(Cocoa.FoundationLibrary, "NSDefaultRunLoopMode");
			CocoaNativeWindow.NSCursor = Class.Get("NSCursor");
			CocoaNativeWindow.NSImage = Class.Get("NSImage");
			CocoaNativeWindow.NSBitmapImageRep = Class.Get("NSBitmapImageRep");
		}

		// Token: 0x060059C4 RID: 22980 RVA: 0x000F43FC File Offset: 0x000F25FC
		public CocoaNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device)
		{
			Interlocked.Increment(ref CocoaNativeWindow.UniqueId);
			this.windowClass = Class.AllocateClass("OpenTK_GameWindow" + CocoaNativeWindow.UniqueId, "NSWindow");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowKeyDownDelegate(this.WindowKeyDown), "keyDown:", "v@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowDidResizeDelegate(this.WindowDidResize), "windowDidResize:", "v@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowDidMoveDelegate(this.WindowDidMove), "windowDidMove:", "v@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowDidBecomeKeyDelegate(this.WindowDidBecomeKey), "windowDidBecomeKey:", "v@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowDidResignKeyDelegate(this.WindowDidResignKey), "windowDidResignKey:", "v@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowWillMiniaturizeDelegate(this.WindowWillMiniaturize), "windowWillMiniaturize:", "v@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowDidMiniaturizeDelegate(this.WindowDidMiniaturize), "windowDidMiniaturize:", "v@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowDidDeminiaturizeDelegate(this.WindowDidDeminiaturize), "windowDidDeminiaturize:", "v@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowShouldZoomToFrameDelegate(this.WindowShouldZoomToFrame), "windowShouldZoom:toFrame:", "b@:@{NSRect={NSPoint=ff}{NSSize=ff}}");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.WindowShouldCloseDelegate(this.WindowShouldClose), "windowShouldClose:", "b@:@");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.AcceptsFirstResponderDelegate(this.AcceptsFirstResponder), "acceptsFirstResponder", "b@:");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.CanBecomeKeyWindowDelegate(this.CanBecomeKeyWindow), "canBecomeKeyWindow", "b@:");
			Class.RegisterMethod(this.windowClass, new CocoaNativeWindow.CanBecomeMainWindowDelegate(this.CanBecomeMainWindow), "canBecomeMainWindow", "b@:");
			Class.RegisterClass(this.windowClass);
			IntPtr intPtr = Class.AllocateClass("OpenTK_NSView" + CocoaNativeWindow.UniqueId, "NSView");
			Class.RegisterMethod(intPtr, new CocoaNativeWindow.ResetCursorRectsDelegate(this.ResetCursorRects), "resetCursorRects", "v@:");
			Class.RegisterClass(intPtr);
			NSRect nsrect = Cocoa.SendRect(Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.Get("NSScreen"), Selector.Get("screens")), Selector.Get("objectAtIndex:"), 0UL), Selector.Get("frame"));
			RectangleF s = new RectangleF((float)x, nsrect.Height - (float)height - (float)y, (float)width, (float)height);
			NSWindowStyle styleMask = CocoaNativeWindow.GetStyleMask(this.windowBorder);
			NSBackingStore @int = NSBackingStore.Buffered;
			IntPtr intPtr2 = Cocoa.SendIntPtr(this.windowClass, Selector.Alloc);
			intPtr2 = Cocoa.SendIntPtr(intPtr2, Selector.Get("initWithContentRect:styleMask:backing:defer:"), s, (int)styleMask, (int)@int, false);
			IntPtr intPtr3 = Cocoa.SendIntPtr(intPtr2, Selector.Get("contentView"));
			intPtr3 = Cocoa.SendIntPtr(Cocoa.SendIntPtr(intPtr, Selector.Alloc), Selector.Get("initWithFrame:"), Cocoa.SendRect(intPtr3, CocoaNativeWindow.selBounds));
			if (intPtr3 != IntPtr.Zero)
			{
				Cocoa.SendVoid(intPtr2, Selector.Get("setContentView:"), intPtr3);
			}
			this.windowInfo = new CocoaWindowInfo(intPtr2);
			Cocoa.SendIntPtr(intPtr2, Selector.Get("setDelegate:"), intPtr2);
			Cocoa.SendVoid(intPtr2, Selector.Get("makeKeyWindow"));
			this.SetTitle(title, false);
			this.ResetTrackingArea();
			this.exists = true;
			NSApplication.Quit += this.ApplicationQuit;
		}

		// Token: 0x060059C5 RID: 22981 RVA: 0x000F47A0 File Offset: 0x000F29A0
		private void WindowKeyDown(IntPtr self, IntPtr cmd, IntPtr notification)
		{
		}

		// Token: 0x060059C6 RID: 22982 RVA: 0x000F47A4 File Offset: 0x000F29A4
		private void WindowDidResize(IntPtr self, IntPtr cmd, IntPtr notification)
		{
			this.OnResize(true);
		}

		// Token: 0x060059C7 RID: 22983 RVA: 0x000F47B0 File Offset: 0x000F29B0
		private void OnResize(bool resetTracking)
		{
			if (resetTracking)
			{
				this.ResetTrackingArea();
			}
			IGraphicsContext currentContext = GraphicsContext.CurrentContext;
			if (currentContext != null)
			{
				currentContext.Update(this.windowInfo);
			}
			if (this.suppressResize == 0)
			{
				base.OnResize(EventArgs.Empty);
			}
		}

		// Token: 0x060059C8 RID: 22984 RVA: 0x000F47F0 File Offset: 0x000F29F0
		private void ApplicationQuit(object sender, CancelEventArgs e)
		{
			bool flag = this.WindowShouldClose(this.windowInfo.Handle, IntPtr.Zero, IntPtr.Zero);
			e.Cancel |= !flag;
		}

		// Token: 0x060059C9 RID: 22985 RVA: 0x000F482C File Offset: 0x000F2A2C
		private void WindowDidMove(IntPtr self, IntPtr cmd, IntPtr notification)
		{
			base.OnMove(EventArgs.Empty);
		}

		// Token: 0x060059CA RID: 22986 RVA: 0x000F483C File Offset: 0x000F2A3C
		private void WindowDidBecomeKey(IntPtr self, IntPtr cmd, IntPtr notification)
		{
			base.OnFocusedChanged(EventArgs.Empty);
		}

		// Token: 0x060059CB RID: 22987 RVA: 0x000F484C File Offset: 0x000F2A4C
		private void WindowDidResignKey(IntPtr self, IntPtr cmd, IntPtr notification)
		{
			base.OnFocusedChanged(EventArgs.Empty);
		}

		// Token: 0x060059CC RID: 22988 RVA: 0x000F485C File Offset: 0x000F2A5C
		private void WindowWillMiniaturize(IntPtr self, IntPtr cmd, IntPtr notification)
		{
			this.RestoreWindowState();
		}

		// Token: 0x060059CD RID: 22989 RVA: 0x000F4864 File Offset: 0x000F2A64
		private void WindowDidMiniaturize(IntPtr self, IntPtr cmd, IntPtr notification)
		{
			this.windowState = WindowState.Minimized;
			base.OnWindowStateChanged(EventArgs.Empty);
			this.OnResize(false);
		}

		// Token: 0x060059CE RID: 22990 RVA: 0x000F4880 File Offset: 0x000F2A80
		private void WindowDidDeminiaturize(IntPtr self, IntPtr cmd, IntPtr notification)
		{
			this.windowState = WindowState.Normal;
			base.OnWindowStateChanged(EventArgs.Empty);
			this.OnResize(true);
		}

		// Token: 0x060059CF RID: 22991 RVA: 0x000F489C File Offset: 0x000F2A9C
		private bool WindowShouldZoomToFrame(IntPtr self, IntPtr cmd, IntPtr nsWindow, RectangleF toFrame)
		{
			if (this.windowState == WindowState.Maximized)
			{
				this.WindowState = WindowState.Normal;
			}
			else
			{
				this.previousBounds = this.InternalBounds;
				this.previousWindowBorder = new WindowBorder?(this.WindowBorder);
				this.InternalBounds = toFrame;
				this.windowState = WindowState.Maximized;
				base.OnWindowStateChanged(EventArgs.Empty);
			}
			return false;
		}

		// Token: 0x060059D0 RID: 22992 RVA: 0x000F48F4 File Offset: 0x000F2AF4
		private bool WindowShouldClose(IntPtr self, IntPtr cmd, IntPtr sender)
		{
			CancelEventArgs cancelEventArgs = new CancelEventArgs();
			base.OnClosing(cancelEventArgs);
			if (!cancelEventArgs.Cancel)
			{
				base.OnClosed(EventArgs.Empty);
				return true;
			}
			return false;
		}

		// Token: 0x060059D1 RID: 22993 RVA: 0x000F4924 File Offset: 0x000F2B24
		private bool AcceptsFirstResponder(IntPtr self, IntPtr cmd)
		{
			return true;
		}

		// Token: 0x060059D2 RID: 22994 RVA: 0x000F4928 File Offset: 0x000F2B28
		private bool CanBecomeKeyWindow(IntPtr self, IntPtr cmd)
		{
			return true;
		}

		// Token: 0x060059D3 RID: 22995 RVA: 0x000F492C File Offset: 0x000F2B2C
		private bool CanBecomeMainWindow(IntPtr self, IntPtr cmd)
		{
			return true;
		}

		// Token: 0x060059D4 RID: 22996 RVA: 0x000F4930 File Offset: 0x000F2B30
		private void ResetTrackingArea()
		{
			IntPtr viewHandle = this.windowInfo.ViewHandle;
			if (this.trackingArea != IntPtr.Zero)
			{
				Cocoa.SendVoid(viewHandle, CocoaNativeWindow.selRemoveTrackingArea, this.trackingArea);
				Cocoa.SendVoid(this.trackingArea, Selector.Release);
			}
			NSRect rectangle = Cocoa.SendRect(viewHandle, CocoaNativeWindow.selBounds);
			int @int = 39;
			this.trackingArea = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.Get("NSTrackingArea"), Selector.Alloc), CocoaNativeWindow.selInitWithRect, rectangle, @int, viewHandle, IntPtr.Zero);
			Cocoa.SendVoid(viewHandle, CocoaNativeWindow.selAddTrackingArea, this.trackingArea);
		}

		// Token: 0x060059D5 RID: 22997 RVA: 0x000F49C8 File Offset: 0x000F2BC8
		public override void Close()
		{
			this.shouldClose = true;
		}

		// Token: 0x060059D6 RID: 22998 RVA: 0x000F49D4 File Offset: 0x000F2BD4
		private KeyModifiers GetModifiers(NSEventModifierMask mask)
		{
			KeyModifiers keyModifiers = (KeyModifiers)0;
			if ((mask & NSEventModifierMask.ControlKeyMask) != (NSEventModifierMask)0U)
			{
				keyModifiers |= KeyModifiers.Control;
			}
			if ((mask & NSEventModifierMask.ShiftKeyMask) != (NSEventModifierMask)0U)
			{
				keyModifiers |= KeyModifiers.Shift;
			}
			if ((mask & NSEventModifierMask.AlternateKeyMask) != (NSEventModifierMask)0U)
			{
				keyModifiers |= KeyModifiers.Alt;
			}
			return keyModifiers;
		}

		// Token: 0x060059D7 RID: 22999 RVA: 0x000F4A10 File Offset: 0x000F2C10
		private MouseButton GetMouseButton(int cocoaButtonIndex)
		{
			if (cocoaButtonIndex == 0)
			{
				return MouseButton.Left;
			}
			if (cocoaButtonIndex == 1)
			{
				return MouseButton.Right;
			}
			if (cocoaButtonIndex == 2)
			{
				return MouseButton.Middle;
			}
			if (cocoaButtonIndex >= 12)
			{
				return MouseButton.LastButton;
			}
			return (MouseButton)cocoaButtonIndex;
		}

		// Token: 0x060059D8 RID: 23000 RVA: 0x000F4A2C File Offset: 0x000F2C2C
		public override void ProcessEvents()
		{
			base.ProcessEvents();
			for (;;)
			{
				IntPtr intPtr = Cocoa.SendIntPtr(NSApplication.Handle, CocoaNativeWindow.selNextEventMatchingMask, uint.MaxValue, IntPtr.Zero, CocoaNativeWindow.NSDefaultRunLoopMode, true);
				if (intPtr == IntPtr.Zero)
				{
					break;
				}
				switch (Cocoa.SendInt(intPtr, CocoaNativeWindow.selType))
				{
				case 1:
				case 3:
				case 25:
				{
					int cocoaButtonIndex = Cocoa.SendInt(intPtr, CocoaNativeWindow.selButtonNumber);
					base.OnMouseDown(this.GetMouseButton(cocoaButtonIndex));
					break;
				}
				case 2:
				case 4:
				case 26:
				{
					int cocoaButtonIndex2 = Cocoa.SendInt(intPtr, CocoaNativeWindow.selButtonNumber);
					base.OnMouseUp(this.GetMouseButton(cocoaButtonIndex2));
					break;
				}
				case 5:
				case 6:
				case 7:
				case 27:
				{
					Point point = new Point(this.MouseState.X, this.MouseState.Y);
					if (this.CursorVisible)
					{
						NSPoint nspoint = Cocoa.SendPoint(intPtr, CocoaNativeWindow.selLocationInWindowOwner);
						NSRect nsrect = Cocoa.SendRect(this.windowInfo.Handle, CocoaNativeWindow.selConvertRectToBacking, new RectangleF(nspoint.X, nspoint.Y, 0f, 0f));
						point = new Point(MathHelper.Clamp((int)Math.Round(nsrect.X), 0, base.Width), MathHelper.Clamp((int)Math.Round((double)((float)base.Height - nsrect.Y)), 0, base.Height));
					}
					else
					{
						float num = Cocoa.SendFloat(intPtr, CocoaNativeWindow.selDeltaX);
						float num2 = Cocoa.SendFloat(intPtr, CocoaNativeWindow.selDeltaY);
						point = new Point(MathHelper.Clamp((int)Math.Round((double)((float)point.X + num)), 0, base.Width), MathHelper.Clamp((int)Math.Round((double)((float)point.Y + num2)), 0, base.Height));
					}
					if (this.MouseState.X != point.X || this.MouseState.Y != point.Y)
					{
						base.OnMouseMove(point.X, point.Y);
					}
					break;
				}
				case 8:
				{
					IntPtr receiver = Cocoa.SendIntPtr(intPtr, CocoaNativeWindow.selTrackingArea);
					IntPtr value = Cocoa.SendIntPtr(receiver, CocoaNativeWindow.selOwner);
					if (value == this.windowInfo.ViewHandle)
					{
						MouseCursor mouseCursor = this.selectedCursor;
						MouseCursor @default = MouseCursor.Default;
						base.OnMouseEnter(EventArgs.Empty);
					}
					break;
				}
				case 9:
				{
					IntPtr receiver2 = Cocoa.SendIntPtr(intPtr, CocoaNativeWindow.selTrackingArea);
					IntPtr value2 = Cocoa.SendIntPtr(receiver2, CocoaNativeWindow.selOwner);
					if (value2 == this.windowInfo.ViewHandle)
					{
						MouseCursor mouseCursor2 = this.selectedCursor;
						MouseCursor default2 = MouseCursor.Default;
						base.OnMouseLeave(EventArgs.Empty);
					}
					break;
				}
				case 10:
				{
					MacOSKeyCode code = (MacOSKeyCode)Cocoa.SendUshort(intPtr, CocoaNativeWindow.selKeyCode);
					bool repeat = Cocoa.SendBool(intPtr, CocoaNativeWindow.selIsARepeat);
					Key key = MacOSKeyMap.GetKey(code);
					base.OnKeyDown(key, repeat);
					string text = Cocoa.FromNSString(Cocoa.SendIntPtr(intPtr, CocoaNativeWindow.selCharactersIgnoringModifiers));
					foreach (char c in text)
					{
						int num3 = (int)c;
						if (!char.IsControl(c) && (num3 < 63232 || num3 > 63235))
						{
							base.OnKeyPress(c);
						}
					}
					break;
				}
				case 11:
				{
					MacOSKeyCode code2 = (MacOSKeyCode)Cocoa.SendUshort(intPtr, CocoaNativeWindow.selKeyCode);
					Key key2 = MacOSKeyMap.GetKey(code2);
					base.OnKeyUp(key2);
					break;
				}
				case 12:
				{
					NSEventModifierMask mask = (NSEventModifierMask)Cocoa.SendUint(intPtr, CocoaNativeWindow.selModifierFlags);
					base.UpdateModifierFlags(this.GetModifiers(mask));
					break;
				}
				case 22:
				{
					float num4;
					float num5;
					if (Cocoa.SendBool(intPtr, CocoaNativeWindow.selHasPreciseScrollingDeltas))
					{
						num4 = Cocoa.SendFloat(intPtr, CocoaNativeWindow.selScrollingDeltaX) * 0.1f;
						num5 = Cocoa.SendFloat(intPtr, CocoaNativeWindow.selScrollingDeltaY) * 0.1f;
					}
					else
					{
						num4 = Cocoa.SendFloat(intPtr, CocoaNativeWindow.selDeltaX);
						num5 = Cocoa.SendFloat(intPtr, CocoaNativeWindow.selDeltaY);
					}
					if (num4 != 0f || num5 != 0f)
					{
						base.OnMouseWheel(-num4, num5);
					}
					break;
				}
				}
				Cocoa.SendVoid(NSApplication.Handle, CocoaNativeWindow.selSendEvent, intPtr);
			}
			if (this.shouldClose)
			{
				this.shouldClose = false;
				if (this.GetStyleMask() == NSWindowStyle.Borderless)
				{
					if (this.WindowShouldClose(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero))
					{
						Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selClose);
						return;
					}
				}
				else
				{
					Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selPerformClose, this.windowInfo.Handle);
				}
			}
		}

		// Token: 0x060059D9 RID: 23001 RVA: 0x000F4EEC File Offset: 0x000F30EC
		public override Point PointToClient(Point point)
		{
			NSRect nsrect = Cocoa.SendRect(this.windowInfo.ViewHandle, CocoaNativeWindow.selConvertRectToBacking, Cocoa.SendRect(this.windowInfo.Handle, CocoaNativeWindow.selConvertRectFromScreen, new RectangleF((float)point.X, this.GetCurrentScreenFrame().Height - (float)point.Y, 0f, 0f)));
			return new Point((int)nsrect.X, (int)((float)base.Height - nsrect.Y));
		}

		// Token: 0x060059DA RID: 23002 RVA: 0x000F4F80 File Offset: 0x000F3180
		public override Point PointToScreen(Point point)
		{
			NSRect nsrect = Cocoa.SendRect(this.windowInfo.Handle, CocoaNativeWindow.selConvertRectToScreen, Cocoa.SendRect(this.windowInfo.ViewHandle, CocoaNativeWindow.selConvertRectFromBacking, new RectangleF((float)point.X, (float)(base.Height - point.Y), 0f, 0f)));
			return new Point((int)nsrect.X, (int)(this.GetCurrentScreenFrame().Height - nsrect.Y));
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x060059DB RID: 23003 RVA: 0x000F5014 File Offset: 0x000F3214
		// (set) Token: 0x060059DC RID: 23004 RVA: 0x000F501C File Offset: 0x000F321C
		public override Icon Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				this.icon = value;
				using (Image image = this.icon.ToBitmap())
				{
					IntPtr intPtr = Cocoa.ToNSImage(image);
					Cocoa.SendVoid(NSApplication.Handle, CocoaNativeWindow.selSetApplicationIconImage, intPtr);
				}
				base.OnIconChanged(EventArgs.Empty);
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x060059DD RID: 23005 RVA: 0x000F507C File Offset: 0x000F327C
		// (set) Token: 0x060059DE RID: 23006 RVA: 0x000F5098 File Offset: 0x000F3298
		public override string Title
		{
			get
			{
				return Cocoa.FromNSString(Cocoa.SendIntPtr(this.windowInfo.Handle, CocoaNativeWindow.selTitle));
			}
			set
			{
				this.SetTitle(value, true);
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x060059DF RID: 23007 RVA: 0x000F50A4 File Offset: 0x000F32A4
		public override bool Focused
		{
			get
			{
				return Cocoa.SendBool(this.windowInfo.Handle, CocoaNativeWindow.selIsKeyWindow);
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x060059E0 RID: 23008 RVA: 0x000F50BC File Offset: 0x000F32BC
		// (set) Token: 0x060059E1 RID: 23009 RVA: 0x000F50D4 File Offset: 0x000F32D4
		public override bool Visible
		{
			get
			{
				return Cocoa.SendBool(this.windowInfo.Handle, CocoaNativeWindow.selIsVisible);
			}
			set
			{
				Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selSetIsVisible, value);
				base.OnVisibleChanged(EventArgs.Empty);
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x060059E2 RID: 23010 RVA: 0x000F50F8 File Offset: 0x000F32F8
		public override bool Exists
		{
			get
			{
				return this.exists;
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x060059E3 RID: 23011 RVA: 0x000F5100 File Offset: 0x000F3300
		public override IWindowInfo WindowInfo
		{
			get
			{
				return this.windowInfo;
			}
		}

		// Token: 0x060059E4 RID: 23012 RVA: 0x000F5108 File Offset: 0x000F3308
		private void RestoreWindowState()
		{
			this.suppressResize++;
			if (this.windowState == WindowState.Fullscreen)
			{
				this.SetMenuVisible(true);
				if (MacOSFactory.ExclusiveFullscreen)
				{
					CG.DisplayReleaseAll();
					Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selSetLevel, this.normalLevel);
				}
				this.RestoreBorder();
				this.InternalBounds = this.previousBounds;
			}
			else if (this.windowState == WindowState.Maximized)
			{
				this.RestoreBorder();
				this.InternalBounds = this.previousBounds;
			}
			else if (this.windowState == WindowState.Minimized)
			{
				Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selDeminiaturize, this.windowInfo.Handle);
			}
			this.windowState = WindowState.Normal;
			this.suppressResize--;
		}

		// Token: 0x060059E5 RID: 23013 RVA: 0x000F51CC File Offset: 0x000F33CC
		private void HideBorder()
		{
			this.suppressResize++;
			this.SetWindowBorder(WindowBorder.Hidden);
			this.ProcessEvents();
			this.suppressResize--;
		}

		// Token: 0x060059E6 RID: 23014 RVA: 0x000F51F8 File Offset: 0x000F33F8
		private void RestoreBorder()
		{
			this.suppressResize++;
			this.SetWindowBorder((this.deferredWindowBorder != null) ? this.deferredWindowBorder.Value : ((this.previousWindowBorder != null) ? this.previousWindowBorder.Value : this.windowBorder));
			this.ProcessEvents();
			this.suppressResize--;
			this.deferredWindowBorder = null;
			this.previousWindowBorder = null;
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x060059E7 RID: 23015 RVA: 0x000F5280 File Offset: 0x000F3480
		// (set) Token: 0x060059E8 RID: 23016 RVA: 0x000F5288 File Offset: 0x000F3488
		public override WindowState WindowState
		{
			get
			{
				return this.windowState;
			}
			set
			{
				WindowState windowState = this.windowState;
				if (windowState == value)
				{
					return;
				}
				this.RestoreWindowState();
				if (value == WindowState.Fullscreen)
				{
					if (MacOSFactory.ExclusiveFullscreen)
					{
						this.normalLevel = Cocoa.SendInt(this.windowInfo.Handle, CocoaNativeWindow.selLevel);
						uint @uint = CG.ShieldingWindowLevel();
						CG.CaptureAllDisplays();
						Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selSetLevel, @uint);
					}
					this.previousBounds = this.InternalBounds;
					this.previousWindowBorder = new WindowBorder?(this.WindowBorder);
					this.SetMenuVisible(false);
					this.HideBorder();
					this.InternalBounds = this.GetCurrentScreenFrame();
					this.windowState = value;
					base.OnWindowStateChanged(EventArgs.Empty);
					return;
				}
				if (value == WindowState.Maximized)
				{
					this.WindowShouldZoomToFrame(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, this.GetCurrentScreenVisibleFrame());
					return;
				}
				if (value == WindowState.Minimized)
				{
					Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selMiniaturize, this.windowInfo.Handle);
					return;
				}
				if (value == WindowState.Normal)
				{
					this.windowState = value;
					base.OnWindowStateChanged(EventArgs.Empty);
					base.OnResize(EventArgs.Empty);
				}
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x060059E9 RID: 23017 RVA: 0x000F53A4 File Offset: 0x000F35A4
		// (set) Token: 0x060059EA RID: 23018 RVA: 0x000F53AC File Offset: 0x000F35AC
		public override WindowBorder WindowBorder
		{
			get
			{
				return this.windowBorder;
			}
			set
			{
				if (this.windowState == WindowState.Fullscreen || this.windowState == WindowState.Maximized)
				{
					this.deferredWindowBorder = new WindowBorder?(value);
					return;
				}
				if (this.windowBorder == value)
				{
					return;
				}
				this.SetWindowBorder(value);
				base.OnWindowBorderChanged(EventArgs.Empty);
			}
		}

		// Token: 0x060059EB RID: 23019 RVA: 0x000F53EC File Offset: 0x000F35EC
		private void SetWindowBorder(WindowBorder windowBorder)
		{
			this.windowBorder = windowBorder;
			this.UpdateWindowBorder();
		}

		// Token: 0x060059EC RID: 23020 RVA: 0x000F53FC File Offset: 0x000F35FC
		private static NSWindowStyle GetStyleMask(WindowBorder windowBorder)
		{
			switch (windowBorder)
			{
			case WindowBorder.Resizable:
				return NSWindowStyle.Titled | NSWindowStyle.Closable | NSWindowStyle.Miniaturizable | NSWindowStyle.Resizable;
			case WindowBorder.Fixed:
				return NSWindowStyle.Titled | NSWindowStyle.Closable | NSWindowStyle.Miniaturizable;
			case WindowBorder.Hidden:
				return NSWindowStyle.Borderless;
			default:
				return NSWindowStyle.Borderless;
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x060059ED RID: 23021 RVA: 0x000F5428 File Offset: 0x000F3628
		// (set) Token: 0x060059EE RID: 23022 RVA: 0x000F54A4 File Offset: 0x000F36A4
		public override Rectangle Bounds
		{
			get
			{
				NSRect nsrect = Cocoa.SendRect(this.windowInfo.Handle, CocoaNativeWindow.selFrame);
				return new Rectangle((int)nsrect.X, (int)(this.GetCurrentScreenFrame().Height - nsrect.Y - nsrect.Height), (int)nsrect.Width, (int)nsrect.Height);
			}
			set
			{
				Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selSetFrame, new RectangleF((float)value.X, this.GetCurrentScreenFrame().Height - (float)value.Y - (float)value.Height, (float)value.Width, (float)value.Height), true);
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x060059EF RID: 23023 RVA: 0x000F550C File Offset: 0x000F370C
		// (set) Token: 0x060059F0 RID: 23024 RVA: 0x000F5528 File Offset: 0x000F3728
		private RectangleF InternalBounds
		{
			get
			{
				return Cocoa.SendRect(this.windowInfo.Handle, CocoaNativeWindow.selFrame);
			}
			set
			{
				Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selSetFrame, value, true);
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x060059F1 RID: 23025 RVA: 0x000F5548 File Offset: 0x000F3748
		// (set) Token: 0x060059F2 RID: 23026 RVA: 0x000F55A4 File Offset: 0x000F37A4
		public override Size ClientSize
		{
			get
			{
				NSRect rect = Cocoa.SendRect(this.windowInfo.ViewHandle, CocoaNativeWindow.selBounds);
				NSRect nsrect = Cocoa.SendRect(this.windowInfo.Handle, CocoaNativeWindow.selConvertRectToBacking, rect);
				return new Size((int)nsrect.Width, (int)nsrect.Height);
			}
			set
			{
				NSRect rect = Cocoa.SendRect(this.windowInfo.Handle, CocoaNativeWindow.selConvertRectFromBacking, new RectangleF(PointF.Empty, value));
				NSRect nsrect = Cocoa.SendRect(this.windowInfo.Handle, CocoaNativeWindow.selFrameRectForContentRect, rect);
				this.Size = new Size((int)nsrect.Width, (int)nsrect.Height);
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x060059F3 RID: 23027 RVA: 0x000F5618 File Offset: 0x000F3818
		// (set) Token: 0x060059F4 RID: 23028 RVA: 0x000F5620 File Offset: 0x000F3820
		public override MouseCursor Cursor
		{
			get
			{
				return this.selectedCursor;
			}
			set
			{
				this.selectedCursor = value;
				this.InvalidateCursorRects();
			}
		}

		// Token: 0x060059F5 RID: 23029 RVA: 0x000F5630 File Offset: 0x000F3830
		private static IntPtr ToNSCursor(MouseCursor cursor)
		{
			IntPtr intPtr = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Cocoa.SendIntPtr(CocoaNativeWindow.NSBitmapImageRep, Selector.Alloc), CocoaNativeWindow.selInitWithBitmapDataPlanes, IntPtr.Zero, cursor.Width, cursor.Height, 8, 4, 1, 0, CocoaNativeWindow.NSDeviceRGBColorSpace, NSBitmapFormat.AlphaFirst, 4 * cursor.Width, 32), Selector.Autorelease);
			if (intPtr == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			int num = 0;
			IntPtr ptr = Cocoa.SendIntPtr(intPtr, CocoaNativeWindow.selBitmapData);
			for (int i = 0; i < cursor.Height; i++)
			{
				for (int j = 0; j < cursor.Width; j++)
				{
					uint num2 = (uint)BitConverter.ToInt32(cursor.Data, num);
					if (BitConverter.IsLittleEndian)
					{
						num2 = ((num2 & 255U) << 24 | (num2 & 65280U) << 8 | (num2 & 16711680U) >> 8 | (num2 & 4278190080U) >> 24);
					}
					Marshal.WriteInt32(ptr, num, (int)num2);
					num += 4;
				}
			}
			IntPtr intPtr2 = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Cocoa.SendIntPtr(CocoaNativeWindow.NSImage, Selector.Alloc), CocoaNativeWindow.selInitWithSize, new SizeF((float)cursor.Width, (float)cursor.Height)), Selector.Autorelease);
			if (intPtr2 == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			Cocoa.SendVoid(intPtr2, CocoaNativeWindow.selAddRepresentation, intPtr);
			return Cocoa.SendIntPtr(Cocoa.SendIntPtr(Cocoa.SendIntPtr(CocoaNativeWindow.NSCursor, Selector.Alloc), CocoaNativeWindow.selInitWithImageHotSpot, intPtr2, new PointF((float)cursor.X, (float)cursor.Y)), Selector.Autorelease);
		}

		// Token: 0x060059F6 RID: 23030 RVA: 0x000F57C0 File Offset: 0x000F39C0
		private void ResetCursorRects(IntPtr sender, IntPtr cmd)
		{
			NSRect rect = Cocoa.SendRect(this.windowInfo.ViewHandle, CocoaNativeWindow.selBounds);
			IntPtr intPtr = IntPtr.Zero;
			if (this.selectedCursor == MouseCursor.Default)
			{
				intPtr = Cocoa.SendIntPtr(CocoaNativeWindow.NSCursor, CocoaNativeWindow.selArrowCursor);
			}
			else
			{
				intPtr = CocoaNativeWindow.ToNSCursor(this.selectedCursor);
			}
			if (intPtr != IntPtr.Zero)
			{
				Cocoa.SendVoid(sender, CocoaNativeWindow.selAddCursorRect, rect, intPtr);
			}
		}

		// Token: 0x060059F7 RID: 23031 RVA: 0x000F5830 File Offset: 0x000F3A30
		private void InvalidateCursorRects()
		{
			Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selInvalidateCursorRectsForView, this.windowInfo.ViewHandle);
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x060059F8 RID: 23032 RVA: 0x000F5854 File Offset: 0x000F3A54
		// (set) Token: 0x060059F9 RID: 23033 RVA: 0x000F585C File Offset: 0x000F3A5C
		public override bool CursorVisible
		{
			get
			{
				return this.cursorVisible;
			}
			set
			{
				this.cursorVisible = value;
				if (value)
				{
					this.SetCursorVisible(true);
					return;
				}
				this.SetCursorVisible(false);
			}
		}

		// Token: 0x060059FA RID: 23034 RVA: 0x000F5878 File Offset: 0x000F3A78
		protected override void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}
			NSApplication.Quit -= this.ApplicationQuit;
			this.CursorVisible = true;
			this.disposed = true;
			this.exists = false;
			if (disposing)
			{
				if (this.trackingArea != IntPtr.Zero)
				{
					Cocoa.SendVoid(this.windowInfo.ViewHandle, CocoaNativeWindow.selRemoveTrackingArea, this.trackingArea);
					Cocoa.SendVoid(this.trackingArea, Selector.Release);
					this.trackingArea = IntPtr.Zero;
				}
				this.windowInfo.Dispose();
			}
			base.OnDisposed(EventArgs.Empty);
		}

		// Token: 0x060059FB RID: 23035 RVA: 0x000F5918 File Offset: 0x000F3B18
		public static IntPtr GetView(IntPtr windowHandle)
		{
			return Cocoa.SendIntPtr(windowHandle, CocoaNativeWindow.selContentView);
		}

		// Token: 0x060059FC RID: 23036 RVA: 0x000F5928 File Offset: 0x000F3B28
		private RectangleF GetContentViewFrame()
		{
			return Cocoa.SendRect(this.windowInfo.ViewHandle, CocoaNativeWindow.selFrame);
		}

		// Token: 0x060059FD RID: 23037 RVA: 0x000F5944 File Offset: 0x000F3B44
		private IntPtr GetCurrentScreen()
		{
			return Cocoa.SendIntPtr(this.windowInfo.Handle, CocoaNativeWindow.selScreen);
		}

		// Token: 0x060059FE RID: 23038 RVA: 0x000F595C File Offset: 0x000F3B5C
		private RectangleF GetCurrentScreenFrame()
		{
			return Cocoa.SendRect(this.GetCurrentScreen(), CocoaNativeWindow.selFrame);
		}

		// Token: 0x060059FF RID: 23039 RVA: 0x000F5974 File Offset: 0x000F3B74
		private RectangleF GetCurrentScreenVisibleFrame()
		{
			return Cocoa.SendRect(this.GetCurrentScreen(), CocoaNativeWindow.selVisibleFrame);
		}

		// Token: 0x06005A00 RID: 23040 RVA: 0x000F598C File Offset: 0x000F3B8C
		private void SetCursorVisible(bool visible)
		{
			if (!visible && !this.Bounds.Contains(new Point(this.MouseState.X, this.MouseState.Y)))
			{
				Mouse.SetPosition((double)((this.Bounds.Left + this.Bounds.Right) / 2), (double)((this.Bounds.Top + this.Bounds.Bottom) / 2));
			}
			else if (visible)
			{
				Point point = this.PointToScreen(new Point(this.MouseState.X, this.MouseState.Y));
				Mouse.SetPosition((double)point.X, (double)point.Y);
			}
			CG.AssociateMouseAndMouseCursorPosition(visible);
			Cocoa.SendVoid(CocoaNativeWindow.NSCursor, visible ? CocoaNativeWindow.selUnhide : CocoaNativeWindow.selHide);
		}

		// Token: 0x06005A01 RID: 23041 RVA: 0x000F5A6C File Offset: 0x000F3C6C
		private void SetMenuVisible(bool visible)
		{
			NSApplicationPresentationOptions nsapplicationPresentationOptions = (NSApplicationPresentationOptions)Cocoa.SendInt(NSApplication.Handle, CocoaNativeWindow.selPresentationOptions);
			NSApplicationPresentationOptions nsapplicationPresentationOptions2 = (NSApplicationPresentationOptions)10;
			if (!visible)
			{
				nsapplicationPresentationOptions |= nsapplicationPresentationOptions2;
			}
			else
			{
				nsapplicationPresentationOptions &= ~nsapplicationPresentationOptions2;
			}
			Cocoa.SendVoid(NSApplication.Handle, CocoaNativeWindow.selSetPresentationOptions, (int)nsapplicationPresentationOptions);
		}

		// Token: 0x06005A02 RID: 23042 RVA: 0x000F5AAC File Offset: 0x000F3CAC
		private void SetTitle(string newTitle, bool callEvent)
		{
			this.title = (newTitle ?? "");
			Cocoa.SendIntPtr(this.windowInfo.Handle, CocoaNativeWindow.selSetTitle, Cocoa.ToNSString(this.title));
			if (callEvent)
			{
				base.OnTitleChanged(EventArgs.Empty);
			}
		}

		// Token: 0x06005A03 RID: 23043 RVA: 0x000F5AF8 File Offset: 0x000F3CF8
		private void UpdateWindowBorder()
		{
			Cocoa.SendVoid(this.windowInfo.Handle, CocoaNativeWindow.selSetStyleMask, (uint)CocoaNativeWindow.GetStyleMask(this.windowBorder));
			this.SetTitle(this.title, false);
		}

		// Token: 0x06005A04 RID: 23044 RVA: 0x000F5B28 File Offset: 0x000F3D28
		private NSWindowStyle GetStyleMask()
		{
			return (NSWindowStyle)Cocoa.SendUint(this.windowInfo.Handle, CocoaNativeWindow.selStyleMask);
		}

		// Token: 0x0400B4F1 RID: 46321
		private static int UniqueId;

		// Token: 0x0400B4F2 RID: 46322
		private static readonly IntPtr selNextEventMatchingMask = Selector.Get("nextEventMatchingMask:untilDate:inMode:dequeue:");

		// Token: 0x0400B4F3 RID: 46323
		private static readonly IntPtr selSendEvent = Selector.Get("sendEvent:");

		// Token: 0x0400B4F4 RID: 46324
		private static readonly IntPtr selContentView = Selector.Get("contentView");

		// Token: 0x0400B4F5 RID: 46325
		private static readonly IntPtr selConvertRectFromScreen = Selector.Get("convertRectFromScreen:");

		// Token: 0x0400B4F6 RID: 46326
		private static readonly IntPtr selConvertRectToScreen = Selector.Get("convertRectToScreen:");

		// Token: 0x0400B4F7 RID: 46327
		private static readonly IntPtr selPerformClose = Selector.Get("performClose:");

		// Token: 0x0400B4F8 RID: 46328
		private static readonly IntPtr selClose = Selector.Get("close");

		// Token: 0x0400B4F9 RID: 46329
		private static readonly IntPtr selTitle = Selector.Get("title");

		// Token: 0x0400B4FA RID: 46330
		private static readonly IntPtr selSetTitle = Selector.Get("setTitle:");

		// Token: 0x0400B4FB RID: 46331
		private static readonly IntPtr selSetApplicationIconImage = Selector.Get("setApplicationIconImage:");

		// Token: 0x0400B4FC RID: 46332
		private static readonly IntPtr selIsKeyWindow = Selector.Get("isKeyWindow");

		// Token: 0x0400B4FD RID: 46333
		private static readonly IntPtr selIsVisible = Selector.Get("isVisible");

		// Token: 0x0400B4FE RID: 46334
		private static readonly IntPtr selSetIsVisible = Selector.Get("setIsVisible:");

		// Token: 0x0400B4FF RID: 46335
		private static readonly IntPtr selFrame = Selector.Get("frame");

		// Token: 0x0400B500 RID: 46336
		private static readonly IntPtr selVisibleFrame = Selector.Get("visibleFrame");

		// Token: 0x0400B501 RID: 46337
		private static readonly IntPtr selBounds = Selector.Get("bounds");

		// Token: 0x0400B502 RID: 46338
		private static readonly IntPtr selScreen = Selector.Get("screen");

		// Token: 0x0400B503 RID: 46339
		private static readonly IntPtr selSetFrame = Selector.Get("setFrame:display:");

		// Token: 0x0400B504 RID: 46340
		private static readonly IntPtr selConvertRectToBacking = Selector.Get("convertRectToBacking:");

		// Token: 0x0400B505 RID: 46341
		private static readonly IntPtr selConvertRectFromBacking = Selector.Get("convertRectFromBacking:");

		// Token: 0x0400B506 RID: 46342
		private static readonly IntPtr selFrameRectForContentRect = Selector.Get("frameRectForContentRect:");

		// Token: 0x0400B507 RID: 46343
		private static readonly IntPtr selType = Selector.Get("type");

		// Token: 0x0400B508 RID: 46344
		private static readonly IntPtr selKeyCode = Selector.Get("keyCode");

		// Token: 0x0400B509 RID: 46345
		private static readonly IntPtr selModifierFlags = Selector.Get("modifierFlags");

		// Token: 0x0400B50A RID: 46346
		private static readonly IntPtr selIsARepeat = Selector.Get("isARepeat");

		// Token: 0x0400B50B RID: 46347
		private static readonly IntPtr selCharactersIgnoringModifiers = Selector.Get("charactersIgnoringModifiers");

		// Token: 0x0400B50C RID: 46348
		private static readonly IntPtr selAddTrackingArea = Selector.Get("addTrackingArea:");

		// Token: 0x0400B50D RID: 46349
		private static readonly IntPtr selRemoveTrackingArea = Selector.Get("removeTrackingArea:");

		// Token: 0x0400B50E RID: 46350
		private static readonly IntPtr selTrackingArea = Selector.Get("trackingArea");

		// Token: 0x0400B50F RID: 46351
		private static readonly IntPtr selInitWithSize = Selector.Get("initWithSize:");

		// Token: 0x0400B510 RID: 46352
		private static readonly IntPtr selInitWithRect = Selector.Get("initWithRect:options:owner:userInfo:");

		// Token: 0x0400B511 RID: 46353
		private static readonly IntPtr selOwner = Selector.Get("owner");

		// Token: 0x0400B512 RID: 46354
		private static readonly IntPtr selLocationInWindowOwner = Selector.Get("locationInWindow");

		// Token: 0x0400B513 RID: 46355
		private static readonly IntPtr selHide = Selector.Get("hide");

		// Token: 0x0400B514 RID: 46356
		private static readonly IntPtr selUnhide = Selector.Get("unhide");

		// Token: 0x0400B515 RID: 46357
		private static readonly IntPtr selScrollingDeltaX = Selector.Get("scrollingDeltaX");

		// Token: 0x0400B516 RID: 46358
		private static readonly IntPtr selScrollingDeltaY = Selector.Get("scrollingDeltaY");

		// Token: 0x0400B517 RID: 46359
		private static readonly IntPtr selDeltaX = Selector.Get("deltaX");

		// Token: 0x0400B518 RID: 46360
		private static readonly IntPtr selDeltaY = Selector.Get("deltaY");

		// Token: 0x0400B519 RID: 46361
		private static readonly IntPtr selButtonNumber = Selector.Get("buttonNumber");

		// Token: 0x0400B51A RID: 46362
		private static readonly IntPtr selSetStyleMask = Selector.Get("setStyleMask:");

		// Token: 0x0400B51B RID: 46363
		private static readonly IntPtr selStyleMask = Selector.Get("styleMask");

		// Token: 0x0400B51C RID: 46364
		private static readonly IntPtr selHasPreciseScrollingDeltas = Selector.Get("hasPreciseScrollingDeltas");

		// Token: 0x0400B51D RID: 46365
		private static readonly IntPtr selMiniaturize = Selector.Get("miniaturize:");

		// Token: 0x0400B51E RID: 46366
		private static readonly IntPtr selDeminiaturize = Selector.Get("deminiaturize:");

		// Token: 0x0400B51F RID: 46367
		private static readonly IntPtr selLevel = Selector.Get("level");

		// Token: 0x0400B520 RID: 46368
		private static readonly IntPtr selSetLevel = Selector.Get("setLevel:");

		// Token: 0x0400B521 RID: 46369
		private static readonly IntPtr selPresentationOptions = Selector.Get("presentationOptions");

		// Token: 0x0400B522 RID: 46370
		private static readonly IntPtr selSetPresentationOptions = Selector.Get("setPresentationOptions:");

		// Token: 0x0400B523 RID: 46371
		private static readonly IntPtr selArrowCursor = Selector.Get("arrowCursor");

		// Token: 0x0400B524 RID: 46372
		private static readonly IntPtr selAddCursorRect = Selector.Get("addCursorRect:cursor:");

		// Token: 0x0400B525 RID: 46373
		private static readonly IntPtr selInvalidateCursorRectsForView = Selector.Get("invalidateCursorRectsForView:");

		// Token: 0x0400B526 RID: 46374
		private static readonly IntPtr selInitWithBitmapDataPlanes = Selector.Get("initWithBitmapDataPlanes:pixelsWide:pixelsHigh:bitsPerSample:samplesPerPixel:hasAlpha:isPlanar:colorSpaceName:bitmapFormat:bytesPerRow:bitsPerPixel:");

		// Token: 0x0400B527 RID: 46375
		private static readonly IntPtr selBitmapData = Selector.Get("bitmapData");

		// Token: 0x0400B528 RID: 46376
		private static readonly IntPtr selAddRepresentation = Selector.Get("addRepresentation:");

		// Token: 0x0400B529 RID: 46377
		private static readonly IntPtr selInitWithImageHotSpot = Selector.Get("initWithImage:hotSpot:");

		// Token: 0x0400B52A RID: 46378
		private static readonly IntPtr NSDefaultRunLoopMode;

		// Token: 0x0400B52B RID: 46379
		private static readonly IntPtr NSCursor;

		// Token: 0x0400B52C RID: 46380
		private static readonly IntPtr NSImage;

		// Token: 0x0400B52D RID: 46381
		private static readonly IntPtr NSBitmapImageRep;

		// Token: 0x0400B52E RID: 46382
		private static readonly IntPtr NSDeviceRGBColorSpace = Cocoa.ToNSString("NSDeviceRGBColorSpace");

		// Token: 0x0400B52F RID: 46383
		private CocoaWindowInfo windowInfo;

		// Token: 0x0400B530 RID: 46384
		private IntPtr windowClass;

		// Token: 0x0400B531 RID: 46385
		private IntPtr trackingArea;

		// Token: 0x0400B532 RID: 46386
		private bool disposed;

		// Token: 0x0400B533 RID: 46387
		private bool exists;

		// Token: 0x0400B534 RID: 46388
		private bool cursorVisible = true;

		// Token: 0x0400B535 RID: 46389
		private Icon icon;

		// Token: 0x0400B536 RID: 46390
		private WindowBorder windowBorder;

		// Token: 0x0400B537 RID: 46391
		private WindowBorder? deferredWindowBorder;

		// Token: 0x0400B538 RID: 46392
		private WindowBorder? previousWindowBorder;

		// Token: 0x0400B539 RID: 46393
		private WindowState windowState;

		// Token: 0x0400B53A RID: 46394
		private string title;

		// Token: 0x0400B53B RID: 46395
		private RectangleF previousBounds;

		// Token: 0x0400B53C RID: 46396
		private int normalLevel;

		// Token: 0x0400B53D RID: 46397
		private bool shouldClose;

		// Token: 0x0400B53E RID: 46398
		private int suppressResize;

		// Token: 0x0400B53F RID: 46399
		private bool cursorInsideWindow = true;

		// Token: 0x0400B540 RID: 46400
		private MouseCursor selectedCursor = MouseCursor.Default;

		// Token: 0x02000B0E RID: 2830
		// (Invoke) Token: 0x06005A06 RID: 23046
		private delegate void WindowKeyDownDelegate(IntPtr self, IntPtr cmd, IntPtr notification);

		// Token: 0x02000B0F RID: 2831
		// (Invoke) Token: 0x06005A0A RID: 23050
		private delegate void WindowDidResizeDelegate(IntPtr self, IntPtr cmd, IntPtr notification);

		// Token: 0x02000B10 RID: 2832
		// (Invoke) Token: 0x06005A0E RID: 23054
		private delegate void WindowDidMoveDelegate(IntPtr self, IntPtr cmd, IntPtr notification);

		// Token: 0x02000B11 RID: 2833
		// (Invoke) Token: 0x06005A12 RID: 23058
		private delegate void WindowDidBecomeKeyDelegate(IntPtr self, IntPtr cmd, IntPtr notification);

		// Token: 0x02000B12 RID: 2834
		// (Invoke) Token: 0x06005A16 RID: 23062
		private delegate void WindowDidResignKeyDelegate(IntPtr self, IntPtr cmd, IntPtr notification);

		// Token: 0x02000B13 RID: 2835
		// (Invoke) Token: 0x06005A1A RID: 23066
		private delegate void WindowWillMiniaturizeDelegate(IntPtr self, IntPtr cmd, IntPtr notification);

		// Token: 0x02000B14 RID: 2836
		// (Invoke) Token: 0x06005A1E RID: 23070
		private delegate void WindowDidMiniaturizeDelegate(IntPtr self, IntPtr cmd, IntPtr notification);

		// Token: 0x02000B15 RID: 2837
		// (Invoke) Token: 0x06005A22 RID: 23074
		private delegate void WindowDidDeminiaturizeDelegate(IntPtr self, IntPtr cmd, IntPtr notification);

		// Token: 0x02000B16 RID: 2838
		// (Invoke) Token: 0x06005A26 RID: 23078
		private delegate bool WindowShouldZoomToFrameDelegate(IntPtr self, IntPtr cmd, IntPtr nsWindow, RectangleF toFrame);

		// Token: 0x02000B17 RID: 2839
		// (Invoke) Token: 0x06005A2A RID: 23082
		private delegate bool WindowShouldCloseDelegate(IntPtr self, IntPtr cmd, IntPtr sender);

		// Token: 0x02000B18 RID: 2840
		// (Invoke) Token: 0x06005A2E RID: 23086
		private delegate bool AcceptsFirstResponderDelegate(IntPtr self, IntPtr cmd);

		// Token: 0x02000B19 RID: 2841
		// (Invoke) Token: 0x06005A32 RID: 23090
		private delegate bool CanBecomeKeyWindowDelegate(IntPtr self, IntPtr cmd);

		// Token: 0x02000B1A RID: 2842
		// (Invoke) Token: 0x06005A36 RID: 23094
		private delegate bool CanBecomeMainWindowDelegate(IntPtr self, IntPtr cmd);

		// Token: 0x02000B1B RID: 2843
		// (Invoke) Token: 0x06005A3A RID: 23098
		private delegate void ResetCursorRectsDelegate(IntPtr self, IntPtr cmd);
	}
}
