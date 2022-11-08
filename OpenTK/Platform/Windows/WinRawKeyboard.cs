using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200007C RID: 124
	internal sealed class WinRawKeyboard : IKeyboardDriver2
	{
		// Token: 0x06000783 RID: 1923 RVA: 0x000192D8 File Offset: 0x000174D8
		public WinRawKeyboard(IntPtr windowHandle)
		{
			this.window = windowHandle;
			this.RefreshDevices();
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00019324 File Offset: 0x00017524
		public void RefreshDevices()
		{
			lock (this.UpdateLock)
			{
				for (int i = 0; i < this.keyboards.Count; i++)
				{
					KeyboardState value = this.keyboards[i];
					value.IsConnected = false;
					this.keyboards[i] = value;
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
						KeyboardState value2 = this.keyboards[this.rawids[key]];
						value2.IsConnected = true;
						this.keyboards[this.rawids[key]] = value2;
					}
					else
					{
						string deviceName = WinRawKeyboard.GetDeviceName(dev);
						if (!deviceName.ToLower().Contains("root") && (dev.Type == RawInputDeviceType.KEYBOARD || dev.Type == RawInputDeviceType.HID))
						{
							RegistryKey registryKey = WinRawKeyboard.GetRegistryKey(deviceName);
							if (registryKey != null)
							{
								string text = (string)registryKey.GetValue("DeviceDesc");
								string text2 = (string)registryKey.GetValue("Class");
								string str = (string)registryKey.GetValue("ClassGUID");
								if (text2 == null || text2.Equals(string.Empty))
								{
									RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\" + str);
									text2 = ((registryKey2 != null) ? ((string)registryKey2.GetValue("Class")) : string.Empty);
								}
								if (!string.IsNullOrEmpty(text))
								{
									text = text.Substring(text.LastIndexOf(';') + 1);
									if (!string.IsNullOrEmpty(text2) && text2.ToLower().Equals("keyboard"))
									{
										RawInputDeviceInfo data = new RawInputDeviceInfo();
										int rawInputDeviceInfoSize = API.RawInputDeviceInfoSize;
										Functions.GetRawInputDeviceInfo(dev.Device, RawInputDeviceInfoEnum.DEVICEINFO, data, ref rawInputDeviceInfoSize);
										WinRawKeyboard.RegisterKeyboardDevice(this.window, text);
										KeyboardState item = default(KeyboardState);
										item.IsConnected = true;
										this.keyboards.Add(item);
										this.names.Add(text);
										this.rawids.Add(new ContextHandle(dev.Device), this.keyboards.Count - 1);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x000195E8 File Offset: 0x000177E8
		public bool ProcessKeyboardEvent(RawInput rin)
		{
			bool flag = false;
			bool down = rin.Data.Keyboard.Message == 256 || rin.Data.Keyboard.Message == 260;
			short makeCode = rin.Data.Keyboard.MakeCode;
			VirtualKeys vkey = rin.Data.Keyboard.VKey;
			bool extended = (short)(rin.Data.Keyboard.Flags & RawInputKeyboardDataFlags.E0) != 0;
			bool extended2 = (short)(rin.Data.Keyboard.Flags & RawInputKeyboardDataFlags.E1) != 0;
			bool flag2 = true;
			ContextHandle key = new ContextHandle(rin.Header.Device);
			if (!this.rawids.ContainsKey(key))
			{
				this.RefreshDevices();
			}
			if (this.keyboards.Count == 0)
			{
				return false;
			}
			int index = this.rawids.ContainsKey(key) ? this.rawids[key] : 0;
			KeyboardState value = this.keyboards[index];
			Key key2 = WinKeyMap.TranslateKey(makeCode, vkey, extended, extended2, out flag2);
			if (flag2)
			{
				value.SetKeyState(key2, down);
				flag = true;
			}
			bool result;
			lock (this.UpdateLock)
			{
				this.keyboards[index] = value;
				result = flag;
			}
			return result;
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0001974C File Offset: 0x0001794C
		private static RegistryKey GetRegistryKey(string name)
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

		// Token: 0x06000787 RID: 1927 RVA: 0x000197B8 File Offset: 0x000179B8
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

		// Token: 0x06000788 RID: 1928 RVA: 0x00019810 File Offset: 0x00017A10
		private static void RegisterKeyboardDevice(IntPtr window, string name)
		{
			RawInputDevice[] array = new RawInputDevice[]
			{
				default(RawInputDevice)
			};
			array[0].UsagePage = 1;
			array[0].Usage = 6;
			array[0].Flags = RawInputDeviceFlags.INPUTSINK;
			array[0].Target = window;
			Functions.RegisterRawInputDevices(array, 1, API.RawInputDeviceSize);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00019878 File Offset: 0x00017A78
		public KeyboardState GetState()
		{
			KeyboardState result;
			lock (this.UpdateLock)
			{
				KeyboardState keyboardState = default(KeyboardState);
				foreach (KeyboardState other in this.keyboards)
				{
					keyboardState.MergeBits(other);
				}
				result = keyboardState;
			}
			return result;
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x000198FC File Offset: 0x00017AFC
		public KeyboardState GetState(int index)
		{
			KeyboardState result;
			lock (this.UpdateLock)
			{
				if (this.keyboards.Count > index)
				{
					result = this.keyboards[index];
				}
				else
				{
					result = default(KeyboardState);
				}
			}
			return result;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00019958 File Offset: 0x00017B58
		public string GetDeviceName(int index)
		{
			string result;
			lock (this.UpdateLock)
			{
				if (this.names.Count > index)
				{
					result = this.names[index];
				}
				else
				{
					result = string.Empty;
				}
			}
			return result;
		}

		// Token: 0x0400029E RID: 670
		private readonly List<KeyboardState> keyboards = new List<KeyboardState>();

		// Token: 0x0400029F RID: 671
		private readonly List<string> names = new List<string>();

		// Token: 0x040002A0 RID: 672
		private readonly Dictionary<ContextHandle, int> rawids = new Dictionary<ContextHandle, int>();

		// Token: 0x040002A1 RID: 673
		private readonly IntPtr window;

		// Token: 0x040002A2 RID: 674
		private readonly object UpdateLock = new object();
	}
}
