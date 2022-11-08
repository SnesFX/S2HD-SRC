using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTK.Input;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B5E RID: 2910
	internal sealed class XI2MouseKeyboard : IKeyboardDriver2, IMouseDriver2, IDisposable
	{
		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06005B38 RID: 23352 RVA: 0x000F6C70 File Offset: 0x000F4E70
		// (set) Token: 0x06005B39 RID: 23353 RVA: 0x000F6C78 File Offset: 0x000F4E78
		internal static int XIOpCode { get; private set; }

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06005B3A RID: 23354 RVA: 0x000F6C80 File Offset: 0x000F4E80
		// (set) Token: 0x06005B3B RID: 23355 RVA: 0x000F6C88 File Offset: 0x000F4E88
		internal static int XIVersion { get; private set; }

		// Token: 0x06005B3C RID: 23356 RVA: 0x000F6C90 File Offset: 0x000F4E90
		static XI2MouseKeyboard()
		{
			using (new XLock(API.DefaultDisplay))
			{
				XI2MouseKeyboard.RelX = Functions.XInternAtom(API.DefaultDisplay, "Rel X", false);
				XI2MouseKeyboard.RelY = Functions.XInternAtom(API.DefaultDisplay, "Rel Y", false);
				XI2MouseKeyboard.ExitAtom = Functions.XInternAtom(API.DefaultDisplay, "Exit Input Thread Message", false);
			}
		}

		// Token: 0x06005B3D RID: 23357 RVA: 0x000F6D18 File Offset: 0x000F4F18
		public XI2MouseKeyboard()
		{
			this.window = new X11WindowInfo();
			this.window.Display = Functions.XOpenDisplay(IntPtr.Zero);
			using (new XLock(this.window.Display))
			{
				XSetWindowAttributes value = default(XSetWindowAttributes);
				this.window.Screen = Functions.XDefaultScreen(this.window.Display);
				this.window.RootWindow = Functions.XRootWindow(this.window.Display, this.window.Screen);
				this.window.Handle = Functions.XCreateWindow(this.window.Display, this.window.RootWindow, 0, 0, 1, 1, 0, 0, CreateWindowArgs.InputOnly, IntPtr.Zero, SetWindowValuemask.Nothing, new XSetWindowAttributes?(value));
				this.KeyMap = new X11KeyMap(this.window.Display);
			}
			if (!XI2MouseKeyboard.IsSupported(this.window.Display))
			{
				throw new NotSupportedException("XInput2 not supported.");
			}
			using (new XLock(this.window.Display))
			{
				using (XIEventMask mask = new XIEventMask(1, (XIEventMasks)254018))
				{
					XI.SelectEvents(this.window.Display, this.window.RootWindow, mask);
					this.UpdateDevices();
				}
			}
			this.ProcessingThread = new Thread(new ThreadStart(this.ProcessEvents));
			this.ProcessingThread.IsBackground = true;
			this.ProcessingThread.Start();
		}

		// Token: 0x06005B3E RID: 23358 RVA: 0x000F6F20 File Offset: 0x000F5120
		internal static bool IsSupported(IntPtr display)
		{
			try
			{
				if (display == IntPtr.Zero)
				{
					display = API.DefaultDisplay;
				}
				using (new XLock(display))
				{
					int num;
					int num2;
					int num3;
					if (Functions.XQueryExtension(display, "XInputExtension", out num, out num2, out num3) != 0)
					{
						XI2MouseKeyboard.XIOpCode = num;
						for (int i = 2; i >= 0; i--)
						{
							if (XI.QueryVersion(display, ref num, ref i) == ErrorCodes.Success)
							{
								XI2MouseKeyboard.XIVersion = num * 100 + i * 10;
								return true;
							}
						}
					}
				}
			}
			catch (DllNotFoundException)
			{
			}
			return false;
		}

		// Token: 0x06005B3F RID: 23359 RVA: 0x000F6FC4 File Offset: 0x000F51C4
		KeyboardState IKeyboardDriver2.GetState()
		{
			KeyboardState result;
			lock (this.Sync)
			{
				KeyboardState keyboardState = default(KeyboardState);
				foreach (XI2MouseKeyboard.XIKeyboard xikeyboard in this.keyboards)
				{
					keyboardState.MergeBits(xikeyboard.State);
				}
				result = keyboardState;
			}
			return result;
		}

		// Token: 0x06005B40 RID: 23360 RVA: 0x000F704C File Offset: 0x000F524C
		KeyboardState IKeyboardDriver2.GetState(int index)
		{
			KeyboardState result;
			lock (this.Sync)
			{
				if (index >= 0 && index < this.keyboards.Count)
				{
					result = this.keyboards[index].State;
				}
				else
				{
					result = default(KeyboardState);
				}
			}
			return result;
		}

		// Token: 0x06005B41 RID: 23361 RVA: 0x000F70B0 File Offset: 0x000F52B0
		string IKeyboardDriver2.GetDeviceName(int index)
		{
			string result;
			lock (this.Sync)
			{
				if (index >= 0 && index < this.keyboards.Count)
				{
					result = this.keyboards[index].Name;
				}
				else
				{
					result = string.Empty;
				}
			}
			return result;
		}

		// Token: 0x06005B42 RID: 23362 RVA: 0x000F7110 File Offset: 0x000F5310
		MouseState IMouseDriver2.GetState()
		{
			MouseState result;
			lock (this.Sync)
			{
				MouseState mouseState = default(MouseState);
				foreach (XI2MouseKeyboard.XIMouse ximouse in this.devices)
				{
					mouseState.MergeBits(ximouse.State);
				}
				result = mouseState;
			}
			return result;
		}

		// Token: 0x06005B43 RID: 23363 RVA: 0x000F7198 File Offset: 0x000F5398
		MouseState IMouseDriver2.GetState(int index)
		{
			MouseState result;
			lock (this.Sync)
			{
				if (index >= 0 && index < this.devices.Count)
				{
					result = this.devices[index].State;
				}
				else
				{
					result = default(MouseState);
				}
			}
			return result;
		}

		// Token: 0x06005B44 RID: 23364 RVA: 0x000F71FC File Offset: 0x000F53FC
		MouseState IMouseDriver2.GetCursorState()
		{
			MouseState result;
			lock (this.Sync)
			{
				MouseState state = ((IMouseDriver2)this).GetState();
				state.X = (int)Interlocked.Read(ref this.cursor_x);
				state.Y = (int)Interlocked.Read(ref this.cursor_y);
				result = state;
			}
			return result;
		}

		// Token: 0x06005B45 RID: 23365 RVA: 0x000F7260 File Offset: 0x000F5460
		void IMouseDriver2.SetPosition(double x, double y)
		{
			using (new XLock(API.DefaultDisplay))
			{
				Functions.XWarpPointer(API.DefaultDisplay, IntPtr.Zero, this.window.RootWindow, 0, 0, 0U, 0U, (int)x, (int)y);
				Functions.XFlush(API.DefaultDisplay);
				Interlocked.Exchange(ref this.cursor_x, (long)x);
				Interlocked.Exchange(ref this.cursor_y, (long)y);
			}
		}

		// Token: 0x06005B46 RID: 23366 RVA: 0x000F72E4 File Offset: 0x000F54E4
		private unsafe void UpdateDevices()
		{
			lock (this.Sync)
			{
				this.devices.Clear();
				this.keyboards.Clear();
				int num;
				XIDeviceInfo* ptr = (XIDeviceInfo*)((void*)XI.QueryDevice(this.window.Display, 0, out num));
				for (int i = 0; i < num; i++)
				{
					switch (ptr[i].use)
					{
					case XIDeviceType.MasterPointer:
					case XIDeviceType.FloatingSlave:
					{
						XI2MouseKeyboard.XIMouse ximouse = new XI2MouseKeyboard.XIMouse();
						ximouse.DeviceInfo = ptr[i];
						ximouse.State.SetIsConnected(ximouse.DeviceInfo.enabled);
						ximouse.Name = Marshal.PtrToStringAnsi(ximouse.DeviceInfo.name);
						for (int j = 0; j < ximouse.DeviceInfo.num_classes; j++)
						{
							XIAnyClassInfo* ptr2 = *(IntPtr*)((byte*)((void*)ximouse.DeviceInfo.classes) + (IntPtr)j * (IntPtr)sizeof(XIAnyClassInfo*));
							switch (ptr2->type)
							{
							case XIClassType.Valuator:
							{
								XIValuatorClassInfo* ptr3 = (XIValuatorClassInfo*)ptr2;
								if (ptr3->label == XI2MouseKeyboard.RelX)
								{
									ximouse.MotionX = *ptr3;
								}
								else if (ptr3->label == XI2MouseKeyboard.RelY)
								{
									ximouse.MotionY = *ptr3;
								}
								break;
							}
							case XIClassType.Scroll:
							{
								XIScrollClassInfo* ptr4 = (XIScrollClassInfo*)ptr2;
								switch (ptr4->scroll_type)
								{
								case XIScrollType.Vertical:
									ximouse.ScrollY = *ptr4;
									break;
								case XIScrollType.Horizontal:
									ximouse.ScrollX = *ptr4;
									break;
								}
								break;
							}
							}
						}
						int deviceid = ximouse.DeviceInfo.deviceid;
						if (!this.rawids.ContainsKey(deviceid))
						{
							this.rawids.Add(deviceid, 0);
						}
						this.rawids[deviceid] = this.devices.Count;
						this.devices.Add(ximouse);
						break;
					}
					case XIDeviceType.MasterKeyboard:
					{
						XI2MouseKeyboard.XIKeyboard xikeyboard = new XI2MouseKeyboard.XIKeyboard();
						xikeyboard.DeviceInfo = ptr[i];
						xikeyboard.State.SetIsConnected(xikeyboard.DeviceInfo.enabled);
						xikeyboard.Name = Marshal.PtrToStringAnsi(xikeyboard.DeviceInfo.name);
						int deviceid2 = xikeyboard.DeviceInfo.deviceid;
						if (!this.keyboard_ids.ContainsKey(deviceid2))
						{
							this.keyboard_ids.Add(xikeyboard.DeviceInfo.deviceid, 0);
						}
						this.keyboard_ids[deviceid2] = this.keyboards.Count;
						this.keyboards.Add(xikeyboard);
						break;
					}
					}
				}
				XI.FreeDeviceInfo((IntPtr)((void*)ptr));
			}
		}

		// Token: 0x06005B47 RID: 23367 RVA: 0x000F75D4 File Offset: 0x000F57D4
		private void ProcessEvents()
		{
			while (!this.disposed)
			{
				XEvent xevent = default(XEvent);
				using (new XLock(this.window.Display))
				{
					Functions.XIfEvent(this.window.Display, ref xevent, this.Predicate, new IntPtr(XI2MouseKeyboard.XIOpCode));
					if (xevent.type == XEventName.ClientMessage && xevent.ClientMessageEvent.ptr1 == XI2MouseKeyboard.ExitAtom)
					{
						Functions.XDestroyWindow(this.window.Display, this.window.Handle);
						this.window.Handle = IntPtr.Zero;
						break;
					}
					if (xevent.type == XEventName.GenericEvent && xevent.GenericEvent.extension == XI2MouseKeyboard.XIOpCode)
					{
						IntPtr intPtr;
						int num;
						int num2;
						int num3;
						Functions.XQueryPointer(this.window.Display, this.window.RootWindow, out intPtr, out intPtr, out num, out num2, out num3, out num3, out num3);
						Interlocked.Exchange(ref this.cursor_x, (long)num);
						Interlocked.Exchange(ref this.cursor_y, (long)num2);
						XGenericEventCookie genericEventCookie = xevent.GenericEventCookie;
						if (Functions.XGetEventData(this.window.Display, ref genericEventCookie) != 0)
						{
							XIEventType evtype = (XIEventType)genericEventCookie.evtype;
							if (evtype != XIEventType.DeviceChanged)
							{
								if (evtype != XIEventType.Motion)
								{
									switch (evtype)
									{
									case XIEventType.RawKeyPress:
									case XIEventType.RawKeyRelease:
									case XIEventType.RawButtonPress:
									case XIEventType.RawButtonRelease:
									case XIEventType.RawMotion:
										this.ProcessRawEvent(ref genericEventCookie);
										break;
									}
								}
							}
							else
							{
								this.UpdateDevices();
							}
						}
						Functions.XFreeEventData(this.window.Display, ref genericEventCookie);
					}
				}
			}
		}

		// Token: 0x06005B48 RID: 23368 RVA: 0x000F778C File Offset: 0x000F598C
		private unsafe void ProcessRawEvent(ref XGenericEventCookie cookie)
		{
			lock (this.Sync)
			{
				XIRawEvent xirawEvent = *(XIRawEvent*)((void*)cookie.data);
				switch (xirawEvent.evtype)
				{
				case XIEventType.RawKeyPress:
				case XIEventType.RawKeyRelease:
				{
					XI2MouseKeyboard.XIKeyboard xikeyboard;
					Key key;
					if (this.GetKeyboardDevice(xirawEvent.deviceid, out xikeyboard) && this.KeyMap.TranslateKey(xirawEvent.detail, out key))
					{
						xikeyboard.State[key] = (xirawEvent.evtype == XIEventType.RawKeyPress);
					}
					break;
				}
				case XIEventType.RawButtonPress:
				case XIEventType.RawButtonRelease:
				{
					XI2MouseKeyboard.XIMouse ximouse;
					if (this.GetMouseDevice(xirawEvent.deviceid, out ximouse))
					{
						float num;
						float num2;
						MouseButton button = X11KeyMap.TranslateButton(xirawEvent.detail, out num, out num2);
						ximouse.State[button] = (xirawEvent.evtype == XIEventType.RawButtonPress);
					}
					break;
				}
				case XIEventType.RawMotion:
				{
					XI2MouseKeyboard.XIMouse ximouse;
					if (this.GetMouseDevice(xirawEvent.deviceid, out ximouse))
					{
						XI2MouseKeyboard.ProcessRawMotion(ximouse, ref xirawEvent);
					}
					break;
				}
				}
			}
		}

		// Token: 0x06005B49 RID: 23369 RVA: 0x000F7898 File Offset: 0x000F5A98
		private bool GetMouseDevice(int deviceid, out XI2MouseKeyboard.XIMouse mouse)
		{
			if (!this.rawids.ContainsKey(deviceid))
			{
				mouse = null;
				return false;
			}
			mouse = this.devices[this.rawids[deviceid]];
			return true;
		}

		// Token: 0x06005B4A RID: 23370 RVA: 0x000F78C8 File Offset: 0x000F5AC8
		private bool GetKeyboardDevice(int deviceid, out XI2MouseKeyboard.XIKeyboard keyboard)
		{
			if (!this.keyboard_ids.ContainsKey(deviceid))
			{
				keyboard = null;
				return false;
			}
			keyboard = this.keyboards[this.keyboard_ids[deviceid]];
			return true;
		}

		// Token: 0x06005B4B RID: 23371 RVA: 0x000F78F8 File Offset: 0x000F5AF8
		private static void ProcessRawMotion(XI2MouseKeyboard.XIMouse d, ref XIRawEvent raw)
		{
			double a = XI2MouseKeyboard.ReadRawValue(ref raw, d.MotionX.number);
			double a2 = XI2MouseKeyboard.ReadRawValue(ref raw, d.MotionY.number);
			double num = XI2MouseKeyboard.ReadRawValue(ref raw, d.ScrollX.number) / d.ScrollX.increment;
			double num2 = XI2MouseKeyboard.ReadRawValue(ref raw, d.ScrollY.number) / d.ScrollY.increment;
			d.State.X = d.State.X + (int)Math.Round(a);
			d.State.Y = d.State.Y + (int)Math.Round(a2);
			d.State.SetScrollRelative((float)num, (float)(-(float)num2));
		}

		// Token: 0x06005B4C RID: 23372 RVA: 0x000F79A8 File Offset: 0x000F5BA8
		private unsafe static double ReadRawValue(ref XIRawEvent raw, int bit)
		{
			double result = 0.0;
			if (XI2MouseKeyboard.IsBitSet(raw.valuators.mask, bit))
			{
				int num = 0;
				for (int i = 0; i < bit; i++)
				{
					if (XI2MouseKeyboard.IsBitSet(raw.valuators.mask, i))
					{
						num++;
					}
				}
				result = *(double*)((byte*)((void*)raw.raw_values) + (IntPtr)num * 8);
			}
			return result;
		}

		// Token: 0x06005B4D RID: 23373 RVA: 0x000F7A0C File Offset: 0x000F5C0C
		private static bool IsEventValid(IntPtr display, ref XEvent e, IntPtr arg)
		{
			bool flag = false;
			switch (e.type)
			{
			case XEventName.ClientMessage:
				flag = (e.ClientMessageEvent.ptr1 == XI2MouseKeyboard.ExitAtom);
				break;
			case XEventName.GenericEvent:
			{
				long num = (long)e.GenericEventCookie.extension;
				flag = (num == arg.ToInt64() && (e.GenericEventCookie.evtype == 13 || e.GenericEventCookie.evtype == 14 || e.GenericEventCookie.evtype == 17 || e.GenericEventCookie.evtype == 15 || e.GenericEventCookie.evtype == 16 || e.GenericEventCookie.evtype == 1));
				flag |= (num == 0L);
				break;
			}
			}
			return flag;
		}

		// Token: 0x06005B4E RID: 23374 RVA: 0x000F7AD4 File Offset: 0x000F5CD4
		private unsafe static bool IsBitSet(IntPtr mask, int bit)
		{
			return bit >= 0 && ((int)((byte*)((void*)mask))[bit >> 3] & 1 << (bit & 7)) != 0;
		}

		// Token: 0x06005B4F RID: 23375 RVA: 0x000F7AF8 File Offset: 0x000F5CF8
		private void SendExitEvent()
		{
			using (new XLock(API.DefaultDisplay))
			{
				XEvent xevent = default(XEvent);
				xevent.type = XEventName.ClientMessage;
				xevent.ClientMessageEvent.display = this.window.Display;
				xevent.ClientMessageEvent.window = this.window.Handle;
				xevent.ClientMessageEvent.format = 32;
				xevent.ClientMessageEvent.ptr1 = XI2MouseKeyboard.ExitAtom;
				Functions.XSendEvent(API.DefaultDisplay, this.window.Handle, false, EventMask.NoEventMask, ref xevent);
				Functions.XFlush(API.DefaultDisplay);
			}
		}

		// Token: 0x06005B50 RID: 23376 RVA: 0x000F7BB4 File Offset: 0x000F5DB4
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06005B51 RID: 23377 RVA: 0x000F7BC4 File Offset: 0x000F5DC4
		private void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				this.disposed = true;
				this.SendExitEvent();
			}
		}

		// Token: 0x06005B52 RID: 23378 RVA: 0x000F7BDC File Offset: 0x000F5DDC
		~XI2MouseKeyboard()
		{
			this.Dispose(false);
		}

		// Token: 0x0400B7BF RID: 47039
		private static readonly IntPtr ExitAtom;

		// Token: 0x0400B7C0 RID: 47040
		private readonly object Sync = new object();

		// Token: 0x0400B7C1 RID: 47041
		private readonly Thread ProcessingThread;

		// Token: 0x0400B7C2 RID: 47042
		private readonly X11KeyMap KeyMap;

		// Token: 0x0400B7C3 RID: 47043
		private bool disposed;

		// Token: 0x0400B7C4 RID: 47044
		private static readonly IntPtr RelX;

		// Token: 0x0400B7C5 RID: 47045
		private static readonly IntPtr RelY;

		// Token: 0x0400B7C6 RID: 47046
		private long cursor_x;

		// Token: 0x0400B7C7 RID: 47047
		private long cursor_y;

		// Token: 0x0400B7C8 RID: 47048
		private List<XI2MouseKeyboard.XIMouse> devices = new List<XI2MouseKeyboard.XIMouse>();

		// Token: 0x0400B7C9 RID: 47049
		private Dictionary<int, int> rawids = new Dictionary<int, int>();

		// Token: 0x0400B7CA RID: 47050
		private List<XI2MouseKeyboard.XIKeyboard> keyboards = new List<XI2MouseKeyboard.XIKeyboard>();

		// Token: 0x0400B7CB RID: 47051
		private Dictionary<int, int> keyboard_ids = new Dictionary<int, int>();

		// Token: 0x0400B7CC RID: 47052
		internal readonly X11WindowInfo window;

		// Token: 0x0400B7CD RID: 47053
		private static readonly Functions.EventPredicate PredicateImpl = new Functions.EventPredicate(XI2MouseKeyboard.IsEventValid);

		// Token: 0x0400B7CE RID: 47054
		private readonly IntPtr Predicate = Marshal.GetFunctionPointerForDelegate(XI2MouseKeyboard.PredicateImpl);

		// Token: 0x02000B5F RID: 2911
		private class XIMouse
		{
			// Token: 0x0400B7D1 RID: 47057
			public MouseState State;

			// Token: 0x0400B7D2 RID: 47058
			public XIDeviceInfo DeviceInfo;

			// Token: 0x0400B7D3 RID: 47059
			public XIScrollClassInfo ScrollX = new XIScrollClassInfo
			{
				number = -1
			};

			// Token: 0x0400B7D4 RID: 47060
			public XIScrollClassInfo ScrollY = new XIScrollClassInfo
			{
				number = -1
			};

			// Token: 0x0400B7D5 RID: 47061
			public XIValuatorClassInfo MotionX = new XIValuatorClassInfo
			{
				number = -1
			};

			// Token: 0x0400B7D6 RID: 47062
			public XIValuatorClassInfo MotionY = new XIValuatorClassInfo
			{
				number = -1
			};

			// Token: 0x0400B7D7 RID: 47063
			public string Name;
		}

		// Token: 0x02000B60 RID: 2912
		private class XIKeyboard
		{
			// Token: 0x0400B7D8 RID: 47064
			public KeyboardState State;

			// Token: 0x0400B7D9 RID: 47065
			public XIDeviceInfo DeviceInfo;

			// Token: 0x0400B7DA RID: 47066
			public string Name;
		}
	}
}
