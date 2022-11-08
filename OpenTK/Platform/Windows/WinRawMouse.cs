using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200007E RID: 126
	internal sealed class WinRawMouse : IMouseDriver2
	{
		// Token: 0x06000797 RID: 1943 RVA: 0x00019C14 File Offset: 0x00017E14
		public WinRawMouse(IntPtr window)
		{
			if (window == IntPtr.Zero)
			{
				throw new ArgumentNullException("window");
			}
			this.Window = window;
			this.RefreshDevices();
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00019C78 File Offset: 0x00017E78
		public void RefreshDevices()
		{
			lock (this.UpdateLock)
			{
				for (int i = 0; i < this.mice.Count; i++)
				{
					MouseState value = this.mice[i];
					value.IsConnected = false;
					this.mice[i] = value;
				}
				int deviceCount = WinRawInput.DeviceCount;
				RawInputDeviceList[] array = new RawInputDeviceList[deviceCount];
				for (int j = 0; j < deviceCount; j++)
				{
					array[j] = default(RawInputDeviceList);
				}
				Functions.GetRawInputDeviceList(array, ref deviceCount, API.RawInputDeviceListSize);
				foreach (RawInputDeviceList dev in array)
				{
					ContextHandle key = new ContextHandle(dev.Device);
					if (this.rawids.ContainsKey(key))
					{
						MouseState value2 = this.mice[this.rawids[key]];
						value2.IsConnected = true;
						this.mice[this.rawids[key]] = value2;
					}
					else
					{
						string deviceName = WinRawMouse.GetDeviceName(dev);
						if (!deviceName.ToLower().Contains("root") && (dev.Type == RawInputDeviceType.MOUSE || dev.Type == RawInputDeviceType.HID))
						{
							RegistryKey registryKey = WinRawMouse.FindRegistryKey(deviceName);
							if (registryKey != null)
							{
								string text = (string)registryKey.GetValue("DeviceDesc");
								string text2 = (string)registryKey.GetValue("Class");
								if (text2 == null)
								{
									string str = (string)registryKey.GetValue("ClassGUID");
									RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\" + str);
									text2 = ((registryKey2 != null) ? ((string)registryKey2.GetValue("Class")) : string.Empty);
								}
								if (string.IsNullOrEmpty(text))
								{
									text = "Windows Mouse " + this.mice.Count;
								}
								else
								{
									text = text.Substring(text.LastIndexOf(';') + 1);
								}
								if (!string.IsNullOrEmpty(text2) && text2.ToLower().Equals("mouse") && !this.rawids.ContainsKey(new ContextHandle(dev.Device)))
								{
									RawInputDeviceInfo data = new RawInputDeviceInfo();
									int rawInputDeviceInfoSize = API.RawInputDeviceInfoSize;
									Functions.GetRawInputDeviceInfo(dev.Device, RawInputDeviceInfoEnum.DEVICEINFO, data, ref rawInputDeviceInfoSize);
									WinRawMouse.RegisterRawDevice(this.Window, text);
									MouseState item = default(MouseState);
									item.IsConnected = true;
									this.mice.Add(item);
									this.names.Add(text);
									this.rawids.Add(new ContextHandle(dev.Device), this.mice.Count - 1);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00019F64 File Offset: 0x00018164
		public bool ProcessMouseEvent(RawInput rin)
		{
			RawMouse mouse = rin.Data.Mouse;
			ContextHandle key = new ContextHandle(rin.Header.Device);
			if (!this.rawids.ContainsKey(key))
			{
				this.RefreshDevices();
			}
			if (this.mice.Count == 0)
			{
				return false;
			}
			int index = this.rawids.ContainsKey(key) ? this.rawids[key] : 0;
			MouseState value = this.mice[index];
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.LEFT_BUTTON_DOWN) != 0)
			{
				value.EnableBit(0);
				Functions.SetCapture(this.Window);
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.LEFT_BUTTON_UP) != 0)
			{
				value.DisableBit(0);
				Functions.ReleaseCapture();
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.RIGHT_BUTTON_DOWN) != 0)
			{
				value.EnableBit(2);
				Functions.SetCapture(this.Window);
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.RIGHT_BUTTON_UP) != 0)
			{
				value.DisableBit(2);
				Functions.ReleaseCapture();
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.MIDDLE_BUTTON_DOWN) != 0)
			{
				value.EnableBit(1);
				Functions.SetCapture(this.Window);
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.MIDDLE_BUTTON_UP) != 0)
			{
				value.DisableBit(1);
				Functions.ReleaseCapture();
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.BUTTON_4_DOWN) != 0)
			{
				value.EnableBit(3);
				Functions.SetCapture(this.Window);
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.BUTTON_4_UP) != 0)
			{
				value.DisableBit(3);
				Functions.ReleaseCapture();
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.BUTTON_5_DOWN) != 0)
			{
				value.EnableBit(4);
				Functions.SetCapture(this.Window);
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.BUTTON_5_UP) != 0)
			{
				value.DisableBit(4);
				Functions.ReleaseCapture();
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.WHEEL) != 0)
			{
				value.SetScrollRelative(0f, (float)((short)mouse.ButtonData) / 120f);
			}
			if ((ushort)(mouse.ButtonFlags & RawInputMouseState.HWHEEL) != 0)
			{
				value.SetScrollRelative((float)((short)mouse.ButtonData) / 120f, 0f);
			}
			if ((ushort)(mouse.Flags & RawMouseFlags.MOUSE_MOVE_ABSOLUTE) != 0)
			{
				value.X = mouse.LastX;
				value.Y = mouse.LastY;
			}
			else
			{
				value.X += mouse.LastX;
				value.Y += mouse.LastY;
			}
			bool result;
			lock (this.UpdateLock)
			{
				this.mice[index] = value;
				result = true;
			}
			return result;
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001A1F4 File Offset: 0x000183F4
		private static string GetDeviceName(RawInputDeviceList dev)
		{
			uint num = 0U;
			Functions.GetRawInputDeviceInfo(dev.Device, RawInputDeviceInfoEnum.DEVICENAME, IntPtr.Zero, ref num);
			IntPtr intPtr = Marshal.AllocHGlobal((IntPtr)((long)((ulong)num)));
			Functions.GetRawInputDeviceInfo(dev.Device, RawInputDeviceInfoEnum.DEVICENAME, intPtr, ref num);
			string result = Marshal.PtrToStringAnsi(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0001A24C File Offset: 0x0001844C
		private static RegistryKey FindRegistryKey(string name)
		{
			if (name.Length < 4)
			{
				return null;
			}
			name = name.Substring(4);
			string[] array = name.Split(new char[]
			{
				'#'
			});
			if (array.Length < 3)
			{
				return null;
			}
			string arg = array[0];
			string arg2 = array[1];
			string arg3 = array[2];
			string name2 = string.Format("System\\CurrentControlSet\\Enum\\{0}\\{1}\\{2}", arg, arg2, arg3);
			return Registry.LocalMachine.OpenSubKey(name2);
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0001A2B8 File Offset: 0x000184B8
		private static void RegisterRawDevice(IntPtr window, string device)
		{
			RawInputDevice[] array = new RawInputDevice[]
			{
				default(RawInputDevice)
			};
			array[0].UsagePage = 1;
			array[0].Usage = 2;
			array[0].Flags = RawInputDeviceFlags.INPUTSINK;
			array[0].Target = window;
			Functions.RegisterRawInputDevices(array, 1, API.RawInputDeviceSize);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001A320 File Offset: 0x00018520
		public MouseState GetState()
		{
			MouseState result;
			lock (this.UpdateLock)
			{
				MouseState mouseState = default(MouseState);
				foreach (MouseState other in this.mice)
				{
					mouseState.MergeBits(other);
				}
				result = mouseState;
			}
			return result;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001A3A4 File Offset: 0x000185A4
		public MouseState GetState(int index)
		{
			MouseState result;
			lock (this.UpdateLock)
			{
				if (this.mice.Count > index)
				{
					result = this.mice[index];
				}
				else
				{
					result = default(MouseState);
				}
			}
			return result;
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0001A400 File Offset: 0x00018600
		public void SetPosition(double x, double y)
		{
			Functions.SetCursorPos((int)x, (int)y);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0001A40C File Offset: 0x0001860C
		public MouseState GetCursorState()
		{
			POINT point = default(POINT);
			Functions.GetCursorPos(ref point);
			MouseState state = this.GetState();
			state.X = point.X;
			state.Y = point.Y;
			return state;
		}

		// Token: 0x040002AB RID: 683
		private readonly List<MouseState> mice = new List<MouseState>();

		// Token: 0x040002AC RID: 684
		private readonly List<string> names = new List<string>();

		// Token: 0x040002AD RID: 685
		private readonly Dictionary<ContextHandle, int> rawids = new Dictionary<ContextHandle, int>();

		// Token: 0x040002AE RID: 686
		private readonly IntPtr Window;

		// Token: 0x040002AF RID: 687
		private readonly object UpdateLock = new object();
	}
}
