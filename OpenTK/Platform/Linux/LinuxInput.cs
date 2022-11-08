using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTK.Input;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B98 RID: 2968
	internal class LinuxInput : IKeyboardDriver2, IMouseDriver2, IDisposable
	{
		// Token: 0x06005C68 RID: 23656 RVA: 0x000FA0E0 File Offset: 0x000F82E0
		public LinuxInput()
		{
			Semaphore semaphore = new Semaphore(0, 1);
			this.input_thread = new Thread(new ParameterizedThreadStart(this.InputThreadLoop));
			this.input_thread.IsBackground = true;
			this.input_thread.Start(semaphore);
			semaphore.WaitOne();
			if (this.exit != 0L)
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06005C69 RID: 23657 RVA: 0x000FA198 File Offset: 0x000F8398
		private static void CloseRestrictedHandler(int fd, IntPtr data)
		{
			int num = Libc.close(fd);
			if (num < 0)
			{
				return;
			}
			Interlocked.Decrement(ref LinuxInput.DeviceFDCount);
		}

		// Token: 0x06005C6A RID: 23658 RVA: 0x000FA1BC File Offset: 0x000F83BC
		private static int OpenRestrictedHandler(IntPtr path, int flags, IntPtr data)
		{
			int num = Libc.open(path, (OpenFlags)flags);
			if (num >= 0)
			{
				Interlocked.Increment(ref LinuxInput.DeviceFDCount);
			}
			return num;
		}

		// Token: 0x06005C6B RID: 23659 RVA: 0x000FA1E4 File Offset: 0x000F83E4
		private void InputThreadLoop(object semaphore)
		{
			this.Setup();
			(semaphore as Semaphore).Release();
			PollFD pollFD = default(PollFD);
			pollFD.fd = this.fd;
			pollFD.events = PollFlags.In;
			while (Interlocked.Read(ref this.exit) == 0L)
			{
				int num = Libc.poll(ref pollFD, 1, -1);
				ErrorNumber lastWin32Error = (ErrorNumber)Marshal.GetLastWin32Error();
				bool flag = (num < 0 && lastWin32Error != ErrorNumber.Again && lastWin32Error != ErrorNumber.Interrupted) || (short)(pollFD.revents & (PollFlags.Error | PollFlags.Hup | PollFlags.Invalid)) != 0;
				this.UpdateDisplayBounds();
				if (num > 0 && (short)(pollFD.revents & (PollFlags.In | PollFlags.Pri)) != 0)
				{
					this.ProcessEvents(this.input_context);
				}
				if (flag)
				{
					Interlocked.Increment(ref this.exit);
				}
			}
		}

		// Token: 0x06005C6C RID: 23660 RVA: 0x000FA294 File Offset: 0x000F8494
		private void UpdateDisplayBounds()
		{
			this.bounds = Rectangle.Empty;
			for (DisplayIndex displayIndex = DisplayIndex.First; displayIndex < DisplayIndex.Sixth; displayIndex++)
			{
				DisplayDevice display = DisplayDevice.GetDisplay(displayIndex);
				if (display != null)
				{
					this.bounds = Rectangle.Union(this.bounds, display.Bounds);
				}
			}
		}

		// Token: 0x06005C6D RID: 23661 RVA: 0x000FA2DC File Offset: 0x000F84DC
		private void UpdateCursor()
		{
			Point point = new Point((int)Math.Round((double)(this.CursorPosition.X + this.CursorOffset.X)), (int)Math.Round((double)(this.CursorPosition.Y + this.CursorOffset.Y)));
			DisplayDevice displayDevice = DisplayDevice.FromPoint(point.X, point.Y) ?? DisplayDevice.Default;
			if (displayDevice != null)
			{
				LinuxDisplay linuxDisplay = (LinuxDisplay)displayDevice.Id;
				Drm.MoveCursor(linuxDisplay.FD, linuxDisplay.Id, point.X, point.Y);
			}
		}

		// Token: 0x06005C6E RID: 23662 RVA: 0x000FA378 File Offset: 0x000F8578
		private void Setup()
		{
			this.udev = Udev.New();
			if (this.udev == IntPtr.Zero)
			{
				Interlocked.Increment(ref this.exit);
				return;
			}
			this.input_context = LibInput.CreateContext(this.input_interface, IntPtr.Zero, this.udev, "seat0");
			if (this.input_context == IntPtr.Zero)
			{
				Interlocked.Increment(ref this.exit);
				return;
			}
			this.fd = LibInput.GetFD(this.input_context);
			if (this.fd < 0)
			{
				Interlocked.Increment(ref this.exit);
				return;
			}
			this.ProcessEvents(this.input_context);
			LibInput.Resume(this.input_context);
			if (Interlocked.Read(ref LinuxInput.DeviceFDCount) <= 0L)
			{
				Interlocked.Increment(ref this.exit);
			}
		}

		// Token: 0x06005C6F RID: 23663 RVA: 0x000FA448 File Offset: 0x000F8648
		private void ProcessEvents(IntPtr input_context)
		{
			for (;;)
			{
				int num = LibInput.Dispatch(input_context);
				if (num != 0)
				{
					break;
				}
				IntPtr @event = LibInput.GetEvent(input_context);
				if (@event == IntPtr.Zero)
				{
					return;
				}
				IntPtr device = LibInput.GetDevice(@event);
				InputEventType eventType = LibInput.GetEventType(@event);
				lock (LinuxInput.Sync)
				{
					InputEventType inputEventType = eventType;
					switch (inputEventType)
					{
					case InputEventType.DeviceAdded:
						this.HandleDeviceAdded(input_context, device);
						break;
					case InputEventType.DeviceRemoved:
						this.HandleDeviceRemoved(input_context, device);
						break;
					default:
						if (inputEventType != InputEventType.KeyboardKey)
						{
							switch (inputEventType)
							{
							case InputEventType.PointerMotion:
								this.HandlePointerMotion(this.GetMouse(device), LibInput.GetPointerEvent(@event));
								break;
							case InputEventType.PointerMotionAbsolute:
								this.HandlePointerMotionAbsolute(this.GetMouse(device), LibInput.GetPointerEvent(@event));
								break;
							case InputEventType.PointerButton:
								this.HandlePointerButton(this.GetMouse(device), LibInput.GetPointerEvent(@event));
								break;
							case InputEventType.PointerAxis:
								this.HandlePointerAxis(this.GetMouse(device), LibInput.GetPointerEvent(@event));
								break;
							}
						}
						else
						{
							this.HandleKeyboard(this.GetKeyboard(device), LibInput.GetKeyboardEvent(@event));
						}
						break;
					}
				}
				LibInput.DestroyEvent(@event);
			}
		}

		// Token: 0x06005C70 RID: 23664 RVA: 0x000FA56C File Offset: 0x000F876C
		private void HandleDeviceAdded(IntPtr context, IntPtr device)
		{
			if (LibInput.DeviceHasCapability(device, DeviceCapability.Keyboard))
			{
				LinuxInput.KeyboardDevice keyboardDevice = new LinuxInput.KeyboardDevice(device, this.Keyboards.Count);
				this.KeyboardCandidates.Add(keyboardDevice.Id, keyboardDevice);
			}
			if (LibInput.DeviceHasCapability(device, DeviceCapability.Mouse))
			{
				LinuxInput.MouseDevice mouseDevice = new LinuxInput.MouseDevice(device, this.Mice.Count);
				this.MouseCandidates.Add(mouseDevice.Id, mouseDevice);
			}
			LibInput.DeviceHasCapability(device, DeviceCapability.Touch);
		}

		// Token: 0x06005C71 RID: 23665 RVA: 0x000FA5DC File Offset: 0x000F87DC
		private void HandleDeviceRemoved(IntPtr context, IntPtr device)
		{
			if (LibInput.DeviceHasCapability(device, DeviceCapability.Keyboard))
			{
				int id = LinuxInput.GetId(device);
				this.Keyboards.TryRemove(id);
				this.KeyboardCandidates.TryRemove(id);
			}
			if (LibInput.DeviceHasCapability(device, DeviceCapability.Mouse))
			{
				int id2 = LinuxInput.GetId(device);
				this.Mice.TryRemove(id2);
				this.MouseCandidates.TryRemove(id2);
			}
		}

		// Token: 0x06005C72 RID: 23666 RVA: 0x000FA640 File Offset: 0x000F8840
		private void HandleKeyboard(LinuxInput.KeyboardDevice device, KeyboardEvent e)
		{
			if (device != null)
			{
				device.State.SetIsConnected(true);
				Key key = Key.Unknown;
				uint key2 = e.Key;
				if (key2 >= 0U && (ulong)key2 < (ulong)((long)LinuxInput.KeyMap.Length))
				{
					key = LinuxInput.KeyMap[(int)((UIntPtr)key2)];
				}
				device.State.SetKeyState(key, e.KeyState == KeyState.Pressed);
			}
		}

		// Token: 0x06005C73 RID: 23667 RVA: 0x000FA698 File Offset: 0x000F8898
		private void HandlePointerAxis(LinuxInput.MouseDevice mouse, PointerEvent e)
		{
			if (mouse != null)
			{
				mouse.State.SetIsConnected(true);
				double num = e.AxisValue;
				switch (e.Axis)
				{
				case PointerAxis.VerticalScroll:
					mouse.State.SetScrollRelative(0f, (float)num);
					break;
				case PointerAxis.HorizontalScroll:
					mouse.State.SetScrollRelative((float)num, 0f);
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x06005C74 RID: 23668 RVA: 0x000FA700 File Offset: 0x000F8900
		private void HandlePointerButton(LinuxInput.MouseDevice mouse, PointerEvent e)
		{
			if (mouse != null)
			{
				mouse.State.SetIsConnected(true);
				MouseButton mouseButton = Evdev.GetMouseButton(e.Button);
				ButtonState buttonState = e.ButtonState;
				mouse.State[mouseButton] = (buttonState == ButtonState.Pressed);
			}
		}

		// Token: 0x06005C75 RID: 23669 RVA: 0x000FA744 File Offset: 0x000F8944
		private void HandlePointerMotion(LinuxInput.MouseDevice mouse, PointerEvent e)
		{
			Vector2 right = new Vector2(e.X, e.Y);
			if (mouse != null)
			{
				mouse.State.SetIsConnected(true);
				mouse.State.Position = mouse.State.Position + right;
			}
			this.CursorPosition = new Vector2(MathHelper.Clamp(this.CursorPosition.X + right.X, (float)this.bounds.Left, (float)(this.bounds.Right - 1)), MathHelper.Clamp(this.CursorPosition.Y + right.Y, (float)this.bounds.Top, (float)(this.bounds.Bottom - 1)));
			this.UpdateCursor();
		}

		// Token: 0x06005C76 RID: 23670 RVA: 0x000FA810 File Offset: 0x000F8A10
		private void HandlePointerMotionAbsolute(LinuxInput.MouseDevice mouse, PointerEvent e)
		{
			if (mouse != null)
			{
				mouse.State.SetIsConnected(true);
				mouse.State.Position = new Vector2(e.X, e.Y);
			}
			this.CursorPosition = new Vector2(e.TransformedX(this.bounds.Width), e.TransformedY(this.bounds.Height));
			this.UpdateCursor();
		}

		// Token: 0x06005C77 RID: 23671 RVA: 0x000FA898 File Offset: 0x000F8A98
		private static int GetId(IntPtr device)
		{
			return LibInput.DeviceGetData(device).ToInt32();
		}

		// Token: 0x06005C78 RID: 23672 RVA: 0x000FA8B4 File Offset: 0x000F8AB4
		private LinuxInput.KeyboardDevice GetKeyboard(IntPtr device)
		{
			int id = LinuxInput.GetId(device);
			LinuxInput.KeyboardDevice keyboardDevice = this.KeyboardCandidates.FromHardwareId(id);
			if (keyboardDevice != null)
			{
				this.Keyboards.Add(id, keyboardDevice);
			}
			return keyboardDevice;
		}

		// Token: 0x06005C79 RID: 23673 RVA: 0x000FA8E8 File Offset: 0x000F8AE8
		private LinuxInput.MouseDevice GetMouse(IntPtr device)
		{
			int id = LinuxInput.GetId(device);
			LinuxInput.MouseDevice mouseDevice = this.MouseCandidates.FromHardwareId(id);
			if (mouseDevice != null)
			{
				this.Mice.Add(id, mouseDevice);
			}
			return mouseDevice;
		}

		// Token: 0x06005C7A RID: 23674 RVA: 0x000FA91C File Offset: 0x000F8B1C
		KeyboardState IKeyboardDriver2.GetState()
		{
			KeyboardState result;
			lock (LinuxInput.Sync)
			{
				KeyboardState keyboardState = default(KeyboardState);
				foreach (LinuxInput.KeyboardDevice keyboardDevice in this.Keyboards)
				{
					keyboardState.MergeBits(keyboardDevice.State);
				}
				result = keyboardState;
			}
			return result;
		}

		// Token: 0x06005C7B RID: 23675 RVA: 0x000FA9A0 File Offset: 0x000F8BA0
		KeyboardState IKeyboardDriver2.GetState(int index)
		{
			KeyboardState result;
			lock (LinuxInput.Sync)
			{
				LinuxInput.KeyboardDevice keyboardDevice = this.Keyboards.FromIndex(index);
				if (keyboardDevice != null)
				{
					result = keyboardDevice.State;
				}
				else
				{
					result = default(KeyboardState);
				}
			}
			return result;
		}

		// Token: 0x06005C7C RID: 23676 RVA: 0x000FA9F8 File Offset: 0x000F8BF8
		string IKeyboardDriver2.GetDeviceName(int index)
		{
			string result;
			lock (LinuxInput.Sync)
			{
				LinuxInput.KeyboardDevice keyboardDevice = this.Keyboards.FromIndex(index);
				if (keyboardDevice != null)
				{
					result = keyboardDevice.Name;
				}
				else
				{
					result = string.Empty;
				}
			}
			return result;
		}

		// Token: 0x06005C7D RID: 23677 RVA: 0x000FAA4C File Offset: 0x000F8C4C
		MouseState IMouseDriver2.GetState()
		{
			MouseState result;
			lock (LinuxInput.Sync)
			{
				MouseState mouseState = default(MouseState);
				foreach (LinuxInput.MouseDevice mouseDevice in this.Mice)
				{
					mouseState.MergeBits(mouseDevice.State);
				}
				result = mouseState;
			}
			return result;
		}

		// Token: 0x06005C7E RID: 23678 RVA: 0x000FAAD0 File Offset: 0x000F8CD0
		MouseState IMouseDriver2.GetState(int index)
		{
			MouseState result;
			lock (LinuxInput.Sync)
			{
				LinuxInput.MouseDevice mouseDevice = this.Mice.FromIndex(index);
				if (mouseDevice != null)
				{
					result = mouseDevice.State;
				}
				else
				{
					result = default(MouseState);
				}
			}
			return result;
		}

		// Token: 0x06005C7F RID: 23679 RVA: 0x000FAB28 File Offset: 0x000F8D28
		void IMouseDriver2.SetPosition(double x, double y)
		{
			this.CursorOffset = new Vector2((float)x - this.CursorPosition.X, (float)y - this.CursorPosition.Y);
			this.UpdateCursor();
		}

		// Token: 0x06005C80 RID: 23680 RVA: 0x000FAB58 File Offset: 0x000F8D58
		MouseState IMouseDriver2.GetCursorState()
		{
			MouseState state = ((IMouseDriver2)this).GetState();
			state.Position = this.CursorPosition + this.CursorOffset;
			return state;
		}

		// Token: 0x06005C81 RID: 23681 RVA: 0x000FAB88 File Offset: 0x000F8D88
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06005C82 RID: 23682 RVA: 0x000FAB98 File Offset: 0x000F8D98
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.input_context != IntPtr.Zero)
				{
					LibInput.Suspend(this.input_context);
					Interlocked.Increment(ref this.exit);
					LibInput.DestroyContext(this.input_context);
					this.input_context = IntPtr.Zero;
				}
				if (this.udev != IntPtr.Zero)
				{
					Udev.Destroy(this.udev);
					this.udev = IntPtr.Zero;
				}
				this.input_interface = null;
			}
		}

		// Token: 0x06005C83 RID: 23683 RVA: 0x000FAC18 File Offset: 0x000F8E18
		~LinuxInput()
		{
			this.Dispose(false);
		}

		// Token: 0x0400B8FF RID: 47359
		private static readonly object Sync = new object();

		// Token: 0x0400B900 RID: 47360
		private static readonly Key[] KeyMap = Evdev.KeyMap;

		// Token: 0x0400B901 RID: 47361
		private static long DeviceFDCount;

		// Token: 0x0400B902 RID: 47362
		private DeviceCollection<LinuxInput.KeyboardDevice> KeyboardCandidates = new DeviceCollection<LinuxInput.KeyboardDevice>();

		// Token: 0x0400B903 RID: 47363
		private DeviceCollection<LinuxInput.MouseDevice> MouseCandidates = new DeviceCollection<LinuxInput.MouseDevice>();

		// Token: 0x0400B904 RID: 47364
		private DeviceCollection<LinuxInput.KeyboardDevice> Keyboards = new DeviceCollection<LinuxInput.KeyboardDevice>();

		// Token: 0x0400B905 RID: 47365
		private DeviceCollection<LinuxInput.MouseDevice> Mice = new DeviceCollection<LinuxInput.MouseDevice>();

		// Token: 0x0400B906 RID: 47366
		private Rectangle bounds;

		// Token: 0x0400B907 RID: 47367
		private Vector2 CursorPosition = Vector2.Zero;

		// Token: 0x0400B908 RID: 47368
		private Vector2 CursorOffset = Vector2.Zero;

		// Token: 0x0400B909 RID: 47369
		private IntPtr udev;

		// Token: 0x0400B90A RID: 47370
		private IntPtr input_context;

		// Token: 0x0400B90B RID: 47371
		private InputInterface input_interface = new InputInterface(LinuxInput.OpenRestricted, LinuxInput.CloseRestricted);

		// Token: 0x0400B90C RID: 47372
		private int fd;

		// Token: 0x0400B90D RID: 47373
		private Thread input_thread;

		// Token: 0x0400B90E RID: 47374
		private long exit;

		// Token: 0x0400B90F RID: 47375
		private static CloseRestrictedCallback CloseRestricted = new CloseRestrictedCallback(LinuxInput.CloseRestrictedHandler);

		// Token: 0x0400B910 RID: 47376
		private static OpenRestrictedCallback OpenRestricted = new OpenRestrictedCallback(LinuxInput.OpenRestrictedHandler);

		// Token: 0x02000B99 RID: 2969
		private class DeviceBase
		{
			// Token: 0x06005C85 RID: 23685 RVA: 0x000FAC80 File Offset: 0x000F8E80
			public DeviceBase(IntPtr device, int id)
			{
				this.Device = device;
				this.Id = id;
			}

			// Token: 0x17000503 RID: 1283
			// (get) Token: 0x06005C86 RID: 23686 RVA: 0x000FAC98 File Offset: 0x000F8E98
			// (set) Token: 0x06005C87 RID: 23687 RVA: 0x000FACA8 File Offset: 0x000F8EA8
			public int Id
			{
				get
				{
					return LinuxInput.GetId(this.Device);
				}
				set
				{
					LibInput.DeviceSetData(this.Device, (IntPtr)value);
				}
			}

			// Token: 0x17000504 RID: 1284
			// (get) Token: 0x06005C88 RID: 23688 RVA: 0x000FACBC File Offset: 0x000F8EBC
			public string Name
			{
				get
				{
					this.name = (this.name ?? LibInput.DeviceGetName(this.Device));
					return this.name;
				}
			}

			// Token: 0x17000505 RID: 1285
			// (get) Token: 0x06005C89 RID: 23689 RVA: 0x000FACE0 File Offset: 0x000F8EE0
			public IntPtr Seat
			{
				get
				{
					return LibInput.DeviceGetSeat(this.Device);
				}
			}

			// Token: 0x17000506 RID: 1286
			// (get) Token: 0x06005C8A RID: 23690 RVA: 0x000FACF0 File Offset: 0x000F8EF0
			public string LogicalSeatName
			{
				get
				{
					this.logical_seat = (this.logical_seat ?? LibInput.SeatGetLogicalName(this.Seat));
					return this.logical_seat;
				}
			}

			// Token: 0x17000507 RID: 1287
			// (get) Token: 0x06005C8B RID: 23691 RVA: 0x000FAD14 File Offset: 0x000F8F14
			public string PhysicalSeatName
			{
				get
				{
					this.physical_seat = (this.physical_seat ?? LibInput.SeatGetPhysicalName(this.Seat));
					return this.physical_seat;
				}
			}

			// Token: 0x17000508 RID: 1288
			// (get) Token: 0x06005C8C RID: 23692 RVA: 0x000FAD38 File Offset: 0x000F8F38
			public string Output
			{
				get
				{
					this.output = (this.output ?? LibInput.DeviceGetOutputName(this.Device));
					return this.output;
				}
			}

			// Token: 0x0400B911 RID: 47377
			private readonly IntPtr Device;

			// Token: 0x0400B912 RID: 47378
			private string name;

			// Token: 0x0400B913 RID: 47379
			private string output;

			// Token: 0x0400B914 RID: 47380
			private string logical_seat;

			// Token: 0x0400B915 RID: 47381
			private string physical_seat;
		}

		// Token: 0x02000B9A RID: 2970
		private class KeyboardDevice : LinuxInput.DeviceBase
		{
			// Token: 0x06005C8D RID: 23693 RVA: 0x000FAD5C File Offset: 0x000F8F5C
			public KeyboardDevice(IntPtr device, int id) : base(device, id)
			{
			}

			// Token: 0x0400B916 RID: 47382
			public KeyboardState State;
		}

		// Token: 0x02000B9B RID: 2971
		private class MouseDevice : LinuxInput.DeviceBase
		{
			// Token: 0x06005C8E RID: 23694 RVA: 0x000FAD68 File Offset: 0x000F8F68
			public MouseDevice(IntPtr device, int id) : base(device, id)
			{
			}

			// Token: 0x0400B917 RID: 47383
			public MouseState State;
		}
	}
}
