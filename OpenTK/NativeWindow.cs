using System;
using System.ComponentModel;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Platform;

namespace OpenTK
{
	// Token: 0x02000051 RID: 81
	public class NativeWindow : INativeWindow, IDisposable
	{
		// Token: 0x0600056C RID: 1388 RVA: 0x00014C1C File Offset: 0x00012E1C
		public NativeWindow() : this(640, 480, "OpenTK Native Window", GameWindowFlags.Default, GraphicsMode.Default, DisplayDevice.Default)
		{
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00014C40 File Offset: 0x00012E40
		public NativeWindow(int width, int height, string title, GameWindowFlags options, GraphicsMode mode, DisplayDevice device) : this((device != null) ? (device.Bounds.Left + (device.Bounds.Width - width) / 2) : 0, (device != null) ? (device.Bounds.Top + (device.Bounds.Height - height) / 2) : 0, width, height, title, options, mode, device)
		{
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00014CB0 File Offset: 0x00012EB0
		public NativeWindow(int x, int y, int width, int height, string title, GameWindowFlags options, GraphicsMode mode, DisplayDevice device)
		{
			if (width < 1)
			{
				throw new ArgumentOutOfRangeException("width", "Must be greater than zero.");
			}
			if (height < 1)
			{
				throw new ArgumentOutOfRangeException("height", "Must be greater than zero.");
			}
			if (mode == null)
			{
				throw new ArgumentNullException("mode");
			}
			this.options = options;
			this.device = device;
			this.implementation = Factory.Default.CreateNativeWindow(x, y, width, height, title, mode, options, this.device);
			if ((options & GameWindowFlags.Fullscreen) != GameWindowFlags.Default)
			{
				if (this.device != null)
				{
					this.device.ChangeResolution(width, height, mode.ColorFormat.BitsPerPixel, 0f);
				}
				this.WindowState = WindowState.Fullscreen;
			}
			if ((options & GameWindowFlags.FixedWindow) != GameWindowFlags.Default)
			{
				this.WindowBorder = WindowBorder.Fixed;
			}
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0001503C File Offset: 0x0001323C
		public void Close()
		{
			this.EnsureUndisposed();
			this.implementation.Close();
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x00015050 File Offset: 0x00013250
		public Point PointToClient(Point point)
		{
			return this.implementation.PointToClient(point);
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00015060 File Offset: 0x00013260
		public Point PointToScreen(Point point)
		{
			return this.implementation.PointToScreen(point);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00015070 File Offset: 0x00013270
		public void ProcessEvents()
		{
			this.ProcessEvents(false);
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0001507C File Offset: 0x0001327C
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x00015090 File Offset: 0x00013290
		public Rectangle Bounds
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Bounds;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Bounds = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x000150A4 File Offset: 0x000132A4
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x000150B8 File Offset: 0x000132B8
		public Rectangle ClientRectangle
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.ClientRectangle;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.ClientRectangle = value;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x000150CC File Offset: 0x000132CC
		// (set) Token: 0x06000578 RID: 1400 RVA: 0x000150E0 File Offset: 0x000132E0
		public Size ClientSize
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.ClientSize;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.ClientSize = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x000150F4 File Offset: 0x000132F4
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x00015108 File Offset: 0x00013308
		public MouseCursor Cursor
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Cursor;
			}
			set
			{
				this.EnsureUndisposed();
				if (value == null)
				{
					value = MouseCursor.Empty;
				}
				this.implementation.Cursor = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x00015128 File Offset: 0x00013328
		public bool Exists
		{
			get
			{
				return !this.IsDisposed && this.implementation.Exists;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x00015140 File Offset: 0x00013340
		public bool Focused
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Focused;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x00015154 File Offset: 0x00013354
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x00015168 File Offset: 0x00013368
		public int Height
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Height;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Height = value;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0001517C File Offset: 0x0001337C
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x00015190 File Offset: 0x00013390
		public Icon Icon
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Icon;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Icon = value;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x000151A4 File Offset: 0x000133A4
		[Obsolete]
		public IInputDriver InputDriver
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.InputDriver;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x000151B8 File Offset: 0x000133B8
		// (set) Token: 0x06000583 RID: 1411 RVA: 0x000151CC File Offset: 0x000133CC
		public Point Location
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Location;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Location = value;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x000151E0 File Offset: 0x000133E0
		// (set) Token: 0x06000585 RID: 1413 RVA: 0x000151F4 File Offset: 0x000133F4
		public Size Size
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Size;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Size = value;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x00015208 File Offset: 0x00013408
		// (set) Token: 0x06000587 RID: 1415 RVA: 0x0001521C File Offset: 0x0001341C
		public string Title
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Title;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Title = value;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00015230 File Offset: 0x00013430
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x00015244 File Offset: 0x00013444
		public bool Visible
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Visible;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Visible = value;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00015258 File Offset: 0x00013458
		// (set) Token: 0x0600058B RID: 1419 RVA: 0x0001526C File Offset: 0x0001346C
		public int Width
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Width;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Width = value;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x00015280 File Offset: 0x00013480
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x00015290 File Offset: 0x00013490
		public WindowBorder WindowBorder
		{
			get
			{
				return this.implementation.WindowBorder;
			}
			set
			{
				this.implementation.WindowBorder = value;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x000152A0 File Offset: 0x000134A0
		public IWindowInfo WindowInfo
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.WindowInfo;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x000152B4 File Offset: 0x000134B4
		// (set) Token: 0x06000590 RID: 1424 RVA: 0x000152C4 File Offset: 0x000134C4
		public virtual WindowState WindowState
		{
			get
			{
				return this.implementation.WindowState;
			}
			set
			{
				this.implementation.WindowState = value;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x000152D4 File Offset: 0x000134D4
		// (set) Token: 0x06000592 RID: 1426 RVA: 0x000152E8 File Offset: 0x000134E8
		public int X
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.X;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.X = value;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x000152FC File Offset: 0x000134FC
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x00015310 File Offset: 0x00013510
		public int Y
		{
			get
			{
				this.EnsureUndisposed();
				return this.implementation.Y;
			}
			set
			{
				this.EnsureUndisposed();
				this.implementation.Y = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x00015324 File Offset: 0x00013524
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x0001532C File Offset: 0x0001352C
		public bool CursorVisible
		{
			get
			{
				return this.cursor_visible;
			}
			set
			{
				this.cursor_visible = value;
				this.implementation.CursorVisible = value;
			}
		}

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000597 RID: 1431 RVA: 0x00015344 File Offset: 0x00013544
		// (remove) Token: 0x06000598 RID: 1432 RVA: 0x0001537C File Offset: 0x0001357C
		public event EventHandler<EventArgs> Closed = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x06000599 RID: 1433 RVA: 0x000153B4 File Offset: 0x000135B4
		// (remove) Token: 0x0600059A RID: 1434 RVA: 0x000153EC File Offset: 0x000135EC
		public event EventHandler<CancelEventArgs> Closing = delegate(object param0, CancelEventArgs param1)
		{
		};

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x0600059B RID: 1435 RVA: 0x00015424 File Offset: 0x00013624
		// (remove) Token: 0x0600059C RID: 1436 RVA: 0x0001545C File Offset: 0x0001365C
		public event EventHandler<EventArgs> Disposed = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x0600059D RID: 1437 RVA: 0x00015494 File Offset: 0x00013694
		// (remove) Token: 0x0600059E RID: 1438 RVA: 0x000154CC File Offset: 0x000136CC
		public event EventHandler<EventArgs> FocusedChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x0600059F RID: 1439 RVA: 0x00015504 File Offset: 0x00013704
		// (remove) Token: 0x060005A0 RID: 1440 RVA: 0x0001553C File Offset: 0x0001373C
		public event EventHandler<EventArgs> IconChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060005A1 RID: 1441 RVA: 0x00015574 File Offset: 0x00013774
		// (remove) Token: 0x060005A2 RID: 1442 RVA: 0x000155AC File Offset: 0x000137AC
		public event EventHandler<KeyboardKeyEventArgs> KeyDown = delegate(object param0, KeyboardKeyEventArgs param1)
		{
		};

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060005A3 RID: 1443 RVA: 0x000155E4 File Offset: 0x000137E4
		// (remove) Token: 0x060005A4 RID: 1444 RVA: 0x0001561C File Offset: 0x0001381C
		public event EventHandler<KeyPressEventArgs> KeyPress = delegate(object param0, KeyPressEventArgs param1)
		{
		};

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060005A5 RID: 1445 RVA: 0x00015654 File Offset: 0x00013854
		// (remove) Token: 0x060005A6 RID: 1446 RVA: 0x0001568C File Offset: 0x0001388C
		public event EventHandler<KeyboardKeyEventArgs> KeyUp = delegate(object param0, KeyboardKeyEventArgs param1)
		{
		};

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060005A7 RID: 1447 RVA: 0x000156C4 File Offset: 0x000138C4
		// (remove) Token: 0x060005A8 RID: 1448 RVA: 0x000156FC File Offset: 0x000138FC
		public event EventHandler<EventArgs> Move = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060005A9 RID: 1449 RVA: 0x00015734 File Offset: 0x00013934
		// (remove) Token: 0x060005AA RID: 1450 RVA: 0x0001576C File Offset: 0x0001396C
		public event EventHandler<EventArgs> MouseEnter = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060005AB RID: 1451 RVA: 0x000157A4 File Offset: 0x000139A4
		// (remove) Token: 0x060005AC RID: 1452 RVA: 0x000157DC File Offset: 0x000139DC
		public event EventHandler<EventArgs> MouseLeave = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060005AD RID: 1453 RVA: 0x00015814 File Offset: 0x00013A14
		// (remove) Token: 0x060005AE RID: 1454 RVA: 0x0001584C File Offset: 0x00013A4C
		public event EventHandler<EventArgs> Resize = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x060005AF RID: 1455 RVA: 0x00015884 File Offset: 0x00013A84
		// (remove) Token: 0x060005B0 RID: 1456 RVA: 0x000158BC File Offset: 0x00013ABC
		public event EventHandler<EventArgs> TitleChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x060005B1 RID: 1457 RVA: 0x000158F4 File Offset: 0x00013AF4
		// (remove) Token: 0x060005B2 RID: 1458 RVA: 0x0001592C File Offset: 0x00013B2C
		public event EventHandler<EventArgs> VisibleChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060005B3 RID: 1459 RVA: 0x00015964 File Offset: 0x00013B64
		// (remove) Token: 0x060005B4 RID: 1460 RVA: 0x0001599C File Offset: 0x00013B9C
		public event EventHandler<EventArgs> WindowBorderChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060005B5 RID: 1461 RVA: 0x000159D4 File Offset: 0x00013BD4
		// (remove) Token: 0x060005B6 RID: 1462 RVA: 0x00015A0C File Offset: 0x00013C0C
		public event EventHandler<EventArgs> WindowStateChanged = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060005B7 RID: 1463 RVA: 0x00015A44 File Offset: 0x00013C44
		// (remove) Token: 0x060005B8 RID: 1464 RVA: 0x00015A7C File Offset: 0x00013C7C
		public event EventHandler<MouseButtonEventArgs> MouseDown = delegate(object param0, MouseButtonEventArgs param1)
		{
		};

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060005B9 RID: 1465 RVA: 0x00015AB4 File Offset: 0x00013CB4
		// (remove) Token: 0x060005BA RID: 1466 RVA: 0x00015AEC File Offset: 0x00013CEC
		public event EventHandler<MouseButtonEventArgs> MouseUp = delegate(object param0, MouseButtonEventArgs param1)
		{
		};

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060005BB RID: 1467 RVA: 0x00015B24 File Offset: 0x00013D24
		// (remove) Token: 0x060005BC RID: 1468 RVA: 0x00015B5C File Offset: 0x00013D5C
		public event EventHandler<MouseMoveEventArgs> MouseMove = delegate(object param0, MouseMoveEventArgs param1)
		{
		};

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x060005BD RID: 1469 RVA: 0x00015B94 File Offset: 0x00013D94
		// (remove) Token: 0x060005BE RID: 1470 RVA: 0x00015BCC File Offset: 0x00013DCC
		public event EventHandler<MouseWheelEventArgs> MouseWheel = delegate(object param0, MouseWheelEventArgs param1)
		{
		};

		// Token: 0x060005BF RID: 1471 RVA: 0x00015C04 File Offset: 0x00013E04
		public virtual void Dispose()
		{
			if (!this.IsDisposed)
			{
				if ((this.options & GameWindowFlags.Fullscreen) != GameWindowFlags.Default && this.device != null)
				{
					this.device.RestoreResolution();
				}
				this.implementation.Dispose();
				GC.SuppressFinalize(this);
				this.IsDisposed = true;
			}
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x00015C44 File Offset: 0x00013E44
		protected void EnsureUndisposed()
		{
			if (this.IsDisposed)
			{
				throw new ObjectDisposedException(base.GetType().Name);
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x00015C60 File Offset: 0x00013E60
		// (set) Token: 0x060005C2 RID: 1474 RVA: 0x00015C68 File Offset: 0x00013E68
		protected bool IsDisposed
		{
			get
			{
				return this.disposed;
			}
			set
			{
				this.disposed = value;
			}
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00015C74 File Offset: 0x00013E74
		protected virtual void OnClosed(EventArgs e)
		{
			this.Closed(this, e);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00015C84 File Offset: 0x00013E84
		protected virtual void OnClosing(CancelEventArgs e)
		{
			this.Closing(this, e);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00015C94 File Offset: 0x00013E94
		protected virtual void OnDisposed(EventArgs e)
		{
			this.Disposed(this, e);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00015CA4 File Offset: 0x00013EA4
		protected virtual void OnFocusedChanged(EventArgs e)
		{
			if (!this.Focused)
			{
				this.previous_cursor_visible = this.CursorVisible;
				this.CursorVisible = true;
			}
			else if (!this.previous_cursor_visible)
			{
				this.previous_cursor_visible = true;
				this.CursorVisible = false;
			}
			this.FocusedChanged(this, e);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00015CF4 File Offset: 0x00013EF4
		protected virtual void OnIconChanged(EventArgs e)
		{
			this.IconChanged(this, e);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00015D04 File Offset: 0x00013F04
		protected virtual void OnKeyDown(KeyboardKeyEventArgs e)
		{
			this.KeyDown(this, e);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00015D14 File Offset: 0x00013F14
		protected virtual void OnKeyPress(KeyPressEventArgs e)
		{
			this.KeyPress(this, e);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00015D24 File Offset: 0x00013F24
		protected virtual void OnKeyUp(KeyboardKeyEventArgs e)
		{
			this.KeyUp(this, e);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00015D34 File Offset: 0x00013F34
		protected virtual void OnMove(EventArgs e)
		{
			this.Move(this, e);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00015D44 File Offset: 0x00013F44
		protected virtual void OnMouseEnter(EventArgs e)
		{
			this.MouseEnter(this, e);
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00015D54 File Offset: 0x00013F54
		protected virtual void OnMouseLeave(EventArgs e)
		{
			this.MouseLeave(this, e);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00015D64 File Offset: 0x00013F64
		protected virtual void OnMouseDown(MouseButtonEventArgs e)
		{
			this.MouseDown(this, e);
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00015D74 File Offset: 0x00013F74
		protected virtual void OnMouseUp(MouseButtonEventArgs e)
		{
			this.MouseUp(this, e);
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00015D84 File Offset: 0x00013F84
		protected virtual void OnMouseMove(MouseMoveEventArgs e)
		{
			this.MouseMove(this, e);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x00015D94 File Offset: 0x00013F94
		protected virtual void OnMouseWheel(MouseWheelEventArgs e)
		{
			this.MouseWheel(this, e);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00015DA4 File Offset: 0x00013FA4
		protected virtual void OnResize(EventArgs e)
		{
			this.Resize(this, e);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00015DB4 File Offset: 0x00013FB4
		protected virtual void OnTitleChanged(EventArgs e)
		{
			this.TitleChanged(this, e);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00015DC4 File Offset: 0x00013FC4
		protected virtual void OnVisibleChanged(EventArgs e)
		{
			this.VisibleChanged(this, e);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00015DD4 File Offset: 0x00013FD4
		protected virtual void OnWindowBorderChanged(EventArgs e)
		{
			this.WindowBorderChanged(this, e);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00015DE4 File Offset: 0x00013FE4
		protected virtual void OnWindowStateChanged(EventArgs e)
		{
			this.WindowStateChanged(this, e);
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00015DF4 File Offset: 0x00013FF4
		protected void ProcessEvents(bool retainEvents)
		{
			this.EnsureUndisposed();
			if (!retainEvents && !this.events)
			{
				this.Events = true;
			}
			this.implementation.ProcessEvents();
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00015E1C File Offset: 0x0001401C
		private void OnClosedInternal(object sender, EventArgs e)
		{
			this.OnClosed(e);
			this.Events = false;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00015E2C File Offset: 0x0001402C
		private void OnClosingInternal(object sender, CancelEventArgs e)
		{
			this.OnClosing(e);
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00015E38 File Offset: 0x00014038
		private void OnDisposedInternal(object sender, EventArgs e)
		{
			this.OnDisposed(e);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00015E44 File Offset: 0x00014044
		private void OnFocusedChangedInternal(object sender, EventArgs e)
		{
			this.OnFocusedChanged(e);
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00015E50 File Offset: 0x00014050
		private void OnIconChangedInternal(object sender, EventArgs e)
		{
			this.OnIconChanged(e);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x00015E5C File Offset: 0x0001405C
		private void OnKeyDownInternal(object sender, KeyboardKeyEventArgs e)
		{
			this.OnKeyDown(e);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00015E68 File Offset: 0x00014068
		private void OnKeyPressInternal(object sender, KeyPressEventArgs e)
		{
			this.OnKeyPress(e);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00015E74 File Offset: 0x00014074
		private void OnKeyUpInternal(object sender, KeyboardKeyEventArgs e)
		{
			this.OnKeyUp(e);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x00015E80 File Offset: 0x00014080
		private void OnMouseEnterInternal(object sender, EventArgs e)
		{
			this.OnMouseEnter(e);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00015E8C File Offset: 0x0001408C
		private void OnMouseLeaveInternal(object sender, EventArgs e)
		{
			this.OnMouseLeave(e);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x00015E98 File Offset: 0x00014098
		private void OnMouseDownInternal(object sender, MouseButtonEventArgs e)
		{
			this.OnMouseDown(e);
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x00015EA4 File Offset: 0x000140A4
		private void OnMouseUpInternal(object sender, MouseButtonEventArgs e)
		{
			this.OnMouseUp(e);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00015EB0 File Offset: 0x000140B0
		private void OnMouseMoveInternal(object sender, MouseMoveEventArgs e)
		{
			this.OnMouseMove(e);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00015EBC File Offset: 0x000140BC
		private void OnMouseWheelInternal(object sender, MouseWheelEventArgs e)
		{
			this.OnMouseWheel(e);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00015EC8 File Offset: 0x000140C8
		private void OnMoveInternal(object sender, EventArgs e)
		{
			this.OnMove(e);
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x00015ED4 File Offset: 0x000140D4
		private void OnResizeInternal(object sender, EventArgs e)
		{
			this.OnResize(e);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00015EE0 File Offset: 0x000140E0
		private void OnTitleChangedInternal(object sender, EventArgs e)
		{
			this.OnTitleChanged(e);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00015EEC File Offset: 0x000140EC
		private void OnVisibleChangedInternal(object sender, EventArgs e)
		{
			this.OnVisibleChanged(e);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00015EF8 File Offset: 0x000140F8
		private void OnWindowBorderChangedInternal(object sender, EventArgs e)
		{
			this.OnWindowBorderChanged(e);
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00015F04 File Offset: 0x00014104
		private void OnWindowStateChangedInternal(object sender, EventArgs e)
		{
			this.OnWindowStateChanged(e);
		}

		// Token: 0x17000134 RID: 308
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x00015F10 File Offset: 0x00014110
		private bool Events
		{
			set
			{
				if (value)
				{
					if (this.events)
					{
						throw new InvalidOperationException("Event propagation is already enabled.");
					}
					this.implementation.Closed += this.OnClosedInternal;
					this.implementation.Closing += this.OnClosingInternal;
					this.implementation.Disposed += this.OnDisposedInternal;
					this.implementation.FocusedChanged += this.OnFocusedChangedInternal;
					this.implementation.IconChanged += this.OnIconChangedInternal;
					this.implementation.KeyDown += this.OnKeyDownInternal;
					this.implementation.KeyPress += this.OnKeyPressInternal;
					this.implementation.KeyUp += this.OnKeyUpInternal;
					this.implementation.MouseEnter += this.OnMouseEnterInternal;
					this.implementation.MouseLeave += this.OnMouseLeaveInternal;
					this.implementation.MouseDown += this.OnMouseDownInternal;
					this.implementation.MouseUp += this.OnMouseUpInternal;
					this.implementation.MouseMove += this.OnMouseMoveInternal;
					this.implementation.MouseWheel += this.OnMouseWheelInternal;
					this.implementation.Move += this.OnMoveInternal;
					this.implementation.Resize += this.OnResizeInternal;
					this.implementation.TitleChanged += this.OnTitleChangedInternal;
					this.implementation.VisibleChanged += this.OnVisibleChangedInternal;
					this.implementation.WindowBorderChanged += this.OnWindowBorderChangedInternal;
					this.implementation.WindowStateChanged += this.OnWindowStateChangedInternal;
					this.events = true;
					return;
				}
				else
				{
					if (this.events)
					{
						this.implementation.Closed -= this.OnClosedInternal;
						this.implementation.Closing -= this.OnClosingInternal;
						this.implementation.Disposed -= this.OnDisposedInternal;
						this.implementation.FocusedChanged -= this.OnFocusedChangedInternal;
						this.implementation.IconChanged -= this.OnIconChangedInternal;
						this.implementation.KeyDown -= this.OnKeyDownInternal;
						this.implementation.KeyPress -= this.OnKeyPressInternal;
						this.implementation.KeyUp -= this.OnKeyUpInternal;
						this.implementation.MouseEnter -= this.OnMouseEnterInternal;
						this.implementation.MouseLeave -= this.OnMouseLeaveInternal;
						this.implementation.MouseDown -= this.OnMouseDownInternal;
						this.implementation.MouseUp -= this.OnMouseUpInternal;
						this.implementation.MouseMove -= this.OnMouseMoveInternal;
						this.implementation.MouseWheel -= this.OnMouseWheelInternal;
						this.implementation.Move -= this.OnMoveInternal;
						this.implementation.Resize -= this.OnResizeInternal;
						this.implementation.TitleChanged -= this.OnTitleChangedInternal;
						this.implementation.VisibleChanged -= this.OnVisibleChangedInternal;
						this.implementation.WindowBorderChanged -= this.OnWindowBorderChangedInternal;
						this.implementation.WindowStateChanged -= this.OnWindowStateChangedInternal;
						this.events = false;
						return;
					}
					throw new InvalidOperationException("Event propagation is already disabled.");
				}
			}
		}

		// Token: 0x04000159 RID: 345
		private readonly GameWindowFlags options;

		// Token: 0x0400015A RID: 346
		private readonly DisplayDevice device;

		// Token: 0x0400015B RID: 347
		private readonly INativeWindow implementation;

		// Token: 0x0400015C RID: 348
		private bool disposed;

		// Token: 0x0400015D RID: 349
		private bool events;

		// Token: 0x0400015E RID: 350
		private bool cursor_visible = true;

		// Token: 0x0400015F RID: 351
		private bool previous_cursor_visible = true;
	}
}
