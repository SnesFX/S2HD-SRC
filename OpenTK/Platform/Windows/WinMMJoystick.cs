using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000DA RID: 218
	internal sealed class WinMMJoystick : IJoystickDriver, IJoystickDriver2
	{
		// Token: 0x06000938 RID: 2360 RVA: 0x0001EA40 File Offset: 0x0001CC40
		public WinMMJoystick()
		{
			this.sticks_readonly = this.sticks.AsReadOnly();
			this.RefreshDevices();
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0001EA98 File Offset: 0x0001CC98
		internal void RefreshDevices()
		{
			for (int i = 0; i < this.sticks.Count; i++)
			{
				this.CloseJoystick(i);
			}
			for (int j = 0; j < WinMMJoystick.UnsafeNativeMethods.joyGetNumDevs(); j++)
			{
				this.OpenJoystick(j);
			}
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0001EADC File Offset: 0x0001CCDC
		private JoystickDevice<WinMMJoystick.WinMMJoyDetails> OpenJoystick(int number)
		{
			JoystickDevice<WinMMJoystick.WinMMJoyDetails> result;
			lock (this.sync)
			{
				JoystickDevice<WinMMJoystick.WinMMJoyDetails> joystickDevice = null;
				WinMMJoystick.JoyCaps joyCaps;
				if (WinMMJoystick.UnsafeNativeMethods.joyGetDevCaps(number, out joyCaps, WinMMJoystick.JoyCaps.SizeInBytes) == WinMMJoystick.JoystickError.NoError)
				{
					if (joyCaps.NumAxes > 11)
					{
						joyCaps.NumAxes = 11;
					}
					if (joyCaps.NumAxes > 32)
					{
						joyCaps.NumButtons = 32;
					}
					JoystickCapabilities caps = new JoystickCapabilities(joyCaps.NumAxes, joyCaps.NumButtons, ((joyCaps.Capabilities & WinMMJoystick.JoystCapsFlags.HasPov) != (WinMMJoystick.JoystCapsFlags)0) ? 1 : 0, true);
					int num = joyCaps.NumAxes;
					if ((joyCaps.Capabilities & WinMMJoystick.JoystCapsFlags.HasPov) != (WinMMJoystick.JoystCapsFlags)0)
					{
						num += 2;
					}
					joystickDevice = new JoystickDevice<WinMMJoystick.WinMMJoyDetails>(number, num, joyCaps.NumButtons);
					joystickDevice.Details = new WinMMJoystick.WinMMJoyDetails(caps);
					for (int i = 0; i < joyCaps.NumAxes; i++)
					{
						if (i % 2 == 1)
						{
							joystickDevice.Details.Min[i] = joyCaps.GetMax(i);
							joystickDevice.Details.Max[i] = joyCaps.GetMin(i);
						}
						else
						{
							joystickDevice.Details.Min[i] = joyCaps.GetMin(i);
							joystickDevice.Details.Max[i] = joyCaps.GetMax(i);
						}
					}
					if ((joyCaps.Capabilities & WinMMJoystick.JoystCapsFlags.HasPov) != (WinMMJoystick.JoystCapsFlags)0)
					{
						joystickDevice.Details.PovType = WinMMJoystick.PovType.Exists;
						if ((joyCaps.Capabilities & WinMMJoystick.JoystCapsFlags.HasPov4Dir) != (WinMMJoystick.JoystCapsFlags)0)
						{
							JoystickDevice<WinMMJoystick.WinMMJoyDetails> joystickDevice2 = joystickDevice;
							joystickDevice2.Details.PovType = (joystickDevice2.Details.PovType | WinMMJoystick.PovType.Discrete);
						}
						if ((joyCaps.Capabilities & WinMMJoystick.JoystCapsFlags.HasPovContinuous) != (WinMMJoystick.JoystCapsFlags)0)
						{
							JoystickDevice<WinMMJoystick.WinMMJoyDetails> joystickDevice3 = joystickDevice;
							joystickDevice3.Details.PovType = (joystickDevice3.Details.PovType | WinMMJoystick.PovType.Continuous);
						}
					}
					joystickDevice.Description = string.Format("Joystick/Joystick #{0} ({1} axes, {2} buttons)", number, joystickDevice.Axis.Count, joystickDevice.Button.Count);
					this.index_to_stick.Add(number, this.sticks.Count);
					this.player_to_index.Add(this.player_to_index.Count, number);
					this.sticks.Add(joystickDevice);
				}
				result = joystickDevice;
			}
			return result;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0001ED00 File Offset: 0x0001CF00
		private void UnplugJoystick(int player_index)
		{
			WinMMJoystick.UnsafeNativeMethods.joyConfigChanged(0);
			this.CloseJoystick(player_index);
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0001ED10 File Offset: 0x0001CF10
		private void CloseJoystick(int player_index)
		{
			lock (this.sync)
			{
				if (this.IsValid(player_index))
				{
					int key = this.player_to_index[player_index];
					JoystickDevice<WinMMJoystick.WinMMJoyDetails> joystickDevice = this.sticks[this.index_to_stick[key]] as JoystickDevice<WinMMJoystick.WinMMJoyDetails>;
					if (joystickDevice != null)
					{
						this.index_to_stick.Remove(key);
						this.player_to_index.Remove(player_index);
					}
				}
			}
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0001ED94 File Offset: 0x0001CF94
		private bool IsValid(int player_index)
		{
			return this.player_to_index.ContainsKey(player_index);
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x0001EDA8 File Offset: 0x0001CFA8
		private static short CalculateOffset(int pos, int min, int max)
		{
			int num = 65535 * (pos - min) / (max - min) - 32767;
			return (short)num;
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x0001EDCC File Offset: 0x0001CFCC
		public int DeviceCount
		{
			get
			{
				return this.sticks.Count;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x0001EDDC File Offset: 0x0001CFDC
		public IList<JoystickDevice> Joysticks
		{
			get
			{
				return this.sticks_readonly;
			}
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0001EDE4 File Offset: 0x0001CFE4
		public void Poll()
		{
			lock (this.sync)
			{
				foreach (JoystickDevice joystickDevice in this.sticks)
				{
					JoystickDevice<WinMMJoystick.WinMMJoyDetails> joystickDevice2 = (JoystickDevice<WinMMJoystick.WinMMJoyDetails>)joystickDevice;
					WinMMJoystick.JoyInfoEx joyInfoEx = default(WinMMJoystick.JoyInfoEx);
					joyInfoEx.Size = WinMMJoystick.JoyInfoEx.SizeInBytes;
					joyInfoEx.Flags = WinMMJoystick.JoystickFlags.All;
					WinMMJoystick.UnsafeNativeMethods.joyGetPosEx(joystickDevice2.Id, ref joyInfoEx);
					int num = joystickDevice2.Axis.Count;
					if ((joystickDevice2.Details.PovType & WinMMJoystick.PovType.Exists) != WinMMJoystick.PovType.None)
					{
						num -= 2;
					}
					int num2 = 0;
					if (num2 < num)
					{
						joystickDevice2.SetAxis((JoystickAxis)num2, joystickDevice2.Details.CalculateOffset((float)joyInfoEx.XPos, num2));
						num2++;
					}
					if (num2 < num)
					{
						joystickDevice2.SetAxis((JoystickAxis)num2, joystickDevice2.Details.CalculateOffset((float)joyInfoEx.YPos, num2));
						num2++;
					}
					if (num2 < num)
					{
						joystickDevice2.SetAxis((JoystickAxis)num2, joystickDevice2.Details.CalculateOffset((float)joyInfoEx.ZPos, num2));
						num2++;
					}
					if (num2 < num)
					{
						joystickDevice2.SetAxis((JoystickAxis)num2, joystickDevice2.Details.CalculateOffset((float)joyInfoEx.RPos, num2));
						num2++;
					}
					if (num2 < num)
					{
						joystickDevice2.SetAxis((JoystickAxis)num2, joystickDevice2.Details.CalculateOffset((float)joyInfoEx.UPos, num2));
						num2++;
					}
					if (num2 < num)
					{
						joystickDevice2.SetAxis((JoystickAxis)num2, joystickDevice2.Details.CalculateOffset((float)joyInfoEx.VPos, num2));
						num2++;
					}
					if ((joystickDevice2.Details.PovType & WinMMJoystick.PovType.Exists) != WinMMJoystick.PovType.None)
					{
						float value = 0f;
						float value2 = 0f;
						if ((ushort)joyInfoEx.Pov != 65535)
						{
							if (joyInfoEx.Pov > 27000 || joyInfoEx.Pov < 9000)
							{
								value2 = 1f;
							}
							if (joyInfoEx.Pov > 0 && joyInfoEx.Pov < 18000)
							{
								value = 1f;
							}
							if (joyInfoEx.Pov > 9000 && joyInfoEx.Pov < 27000)
							{
								value2 = -1f;
							}
							if (joyInfoEx.Pov > 18000)
							{
								value = -1f;
							}
						}
						joystickDevice2.SetAxis((JoystickAxis)(num2++), value);
						joystickDevice2.SetAxis((JoystickAxis)(num2++), value2);
					}
					for (int i = 0; i < joystickDevice2.Button.Count; i++)
					{
						joystickDevice2.SetButton((JoystickButton)i, ((ulong)joyInfoEx.Buttons & (ulong)(1L << (i & 31))) != 0UL);
					}
				}
			}
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0001F098 File Offset: 0x0001D298
		public JoystickCapabilities GetCapabilities(int player_index)
		{
			JoystickCapabilities result;
			lock (this.sync)
			{
				if (this.IsValid(player_index))
				{
					int key = this.player_to_index[player_index];
					JoystickDevice<WinMMJoystick.WinMMJoyDetails> joystickDevice = this.sticks[this.index_to_stick[key]] as JoystickDevice<WinMMJoystick.WinMMJoyDetails>;
					result = joystickDevice.Details.Capabilities;
				}
				else
				{
					result = default(JoystickCapabilities);
				}
			}
			return result;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0001F118 File Offset: 0x0001D318
		public JoystickState GetState(int player_index)
		{
			JoystickState result;
			lock (this.sync)
			{
				JoystickState joystickState = default(JoystickState);
				if (this.IsValid(player_index))
				{
					int num = this.player_to_index[player_index];
					int index = this.index_to_stick[num];
					JoystickDevice<WinMMJoystick.WinMMJoyDetails> joystickDevice = this.sticks[index] as JoystickDevice<WinMMJoystick.WinMMJoyDetails>;
					if (joystickDevice.Details.Capabilities.AxisCount <= 3 || joystickDevice.Details.Capabilities.ButtonCount <= 4)
					{
						WinMMJoystick.JoyInfo joyInfo = default(WinMMJoystick.JoyInfo);
						WinMMJoystick.JoystickError joystickError = WinMMJoystick.UnsafeNativeMethods.joyGetPos(num, ref joyInfo);
						if (joystickError == WinMMJoystick.JoystickError.NoError)
						{
							for (int i = 0; i < joystickDevice.Details.Capabilities.AxisCount; i++)
							{
								joystickState.SetAxis((JoystickAxis)i, WinMMJoystick.CalculateOffset(joyInfo.GetAxis(i), joystickDevice.Details.Min[i], joystickDevice.Details.Max[i]));
							}
							for (int j = 0; j < joystickDevice.Details.Capabilities.ButtonCount; j++)
							{
								joystickState.SetButton((JoystickButton)j, ((ulong)joyInfo.Buttons & (ulong)(1L << (j & 31))) != 0UL);
							}
							joystickState.SetIsConnected(true);
						}
						else if (joystickError == WinMMJoystick.JoystickError.Unplugged)
						{
							this.UnplugJoystick(player_index);
						}
					}
					else
					{
						WinMMJoystick.JoyInfoEx joyInfoEx = default(WinMMJoystick.JoyInfoEx);
						joyInfoEx.Size = WinMMJoystick.JoyInfoEx.SizeInBytes;
						joyInfoEx.Flags = WinMMJoystick.JoystickFlags.All;
						WinMMJoystick.JoystickError joystickError2 = WinMMJoystick.UnsafeNativeMethods.joyGetPosEx(num, ref joyInfoEx);
						if (joystickError2 == WinMMJoystick.JoystickError.NoError)
						{
							for (int k = 0; k < joystickDevice.Details.Capabilities.AxisCount; k++)
							{
								joystickState.SetAxis((JoystickAxis)k, WinMMJoystick.CalculateOffset(joyInfoEx.GetAxis(k), joystickDevice.Details.Min[k], joystickDevice.Details.Max[k]));
							}
							for (int l = 0; l < joystickDevice.Details.Capabilities.ButtonCount; l++)
							{
								joystickState.SetButton((JoystickButton)l, ((ulong)joyInfoEx.Buttons & (ulong)(1L << (l & 31))) != 0UL);
							}
							for (int m = 0; m < joystickDevice.Details.Capabilities.HatCount; m++)
							{
								if ((ushort)joyInfoEx.Pov != 65535)
								{
									HatPosition hatPosition = HatPosition.Centered;
									if (joyInfoEx.Pov < 4500 || joyInfoEx.Pov >= 31500)
									{
										hatPosition |= HatPosition.Up;
									}
									if (joyInfoEx.Pov >= 4500 && joyInfoEx.Pov < 13500)
									{
										hatPosition |= HatPosition.Right;
									}
									if (joyInfoEx.Pov >= 13500 && joyInfoEx.Pov < 22500)
									{
										hatPosition |= HatPosition.Down;
									}
									if (joyInfoEx.Pov >= 22500 && joyInfoEx.Pov < 31500)
									{
										hatPosition |= HatPosition.Left;
									}
									joystickState.SetHat((JoystickHat)m, new JoystickHatState(hatPosition));
								}
							}
							joystickState.SetIsConnected(true);
						}
						else if (joystickError2 == WinMMJoystick.JoystickError.Unplugged)
						{
							this.UnplugJoystick(player_index);
						}
					}
				}
				result = joystickState;
			}
			return result;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0001F44C File Offset: 0x0001D64C
		public Guid GetGuid(int index)
		{
			Guid result;
			lock (this.sync)
			{
				Guid guid = default(Guid);
				this.IsValid(index);
				result = guid;
			}
			return result;
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0001F494 File Offset: 0x0001D694
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0001F4A4 File Offset: 0x0001D6A4
		private void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				this.disposed = true;
			}
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0001F4B8 File Offset: 0x0001D6B8
		~WinMMJoystick()
		{
			this.Dispose(false);
		}

		// Token: 0x04000748 RID: 1864
		private readonly object sync = new object();

		// Token: 0x04000749 RID: 1865
		private List<JoystickDevice> sticks = new List<JoystickDevice>();

		// Token: 0x0400074A RID: 1866
		private IList<JoystickDevice> sticks_readonly;

		// Token: 0x0400074B RID: 1867
		private readonly Dictionary<int, int> index_to_stick = new Dictionary<int, int>();

		// Token: 0x0400074C RID: 1868
		private readonly Dictionary<int, int> player_to_index = new Dictionary<int, int>();

		// Token: 0x0400074D RID: 1869
		private bool disposed;

		// Token: 0x020000DB RID: 219
		[Flags]
		private enum JoystickFlags
		{
			// Token: 0x0400074F RID: 1871
			X = 1,
			// Token: 0x04000750 RID: 1872
			Y = 2,
			// Token: 0x04000751 RID: 1873
			Z = 4,
			// Token: 0x04000752 RID: 1874
			R = 8,
			// Token: 0x04000753 RID: 1875
			U = 16,
			// Token: 0x04000754 RID: 1876
			V = 32,
			// Token: 0x04000755 RID: 1877
			Pov = 64,
			// Token: 0x04000756 RID: 1878
			Buttons = 128,
			// Token: 0x04000757 RID: 1879
			All = 255
		}

		// Token: 0x020000DC RID: 220
		private enum JoystickError : uint
		{
			// Token: 0x04000759 RID: 1881
			NoError,
			// Token: 0x0400075A RID: 1882
			InvalidParameters = 165U,
			// Token: 0x0400075B RID: 1883
			NoCanDo,
			// Token: 0x0400075C RID: 1884
			Unplugged
		}

		// Token: 0x020000DD RID: 221
		[Flags]
		private enum JoystCapsFlags
		{
			// Token: 0x0400075E RID: 1886
			HasZ = 1,
			// Token: 0x0400075F RID: 1887
			HasR = 2,
			// Token: 0x04000760 RID: 1888
			HasU = 4,
			// Token: 0x04000761 RID: 1889
			HasV = 8,
			// Token: 0x04000762 RID: 1890
			HasPov = 22,
			// Token: 0x04000763 RID: 1891
			HasPov4Dir = 50,
			// Token: 0x04000764 RID: 1892
			HasPovContinuous = 100
		}

		// Token: 0x020000DE RID: 222
		private enum JoystickPovPosition : ushort
		{
			// Token: 0x04000766 RID: 1894
			Centered = 65535,
			// Token: 0x04000767 RID: 1895
			Forward = 0,
			// Token: 0x04000768 RID: 1896
			Right = 9000,
			// Token: 0x04000769 RID: 1897
			Backward = 18000,
			// Token: 0x0400076A RID: 1898
			Left = 27000
		}

		// Token: 0x020000DF RID: 223
		private struct JoyCaps
		{
			// Token: 0x06000949 RID: 2377 RVA: 0x0001F510 File Offset: 0x0001D710
			public int GetMin(int i)
			{
				switch (i)
				{
				case 0:
					return this.XMin;
				case 1:
					return this.YMin;
				case 2:
					return this.ZMin;
				case 3:
					return this.RMin;
				case 4:
					return this.UMin;
				case 5:
					return this.VMin;
				default:
					return 0;
				}
			}

			// Token: 0x0600094A RID: 2378 RVA: 0x0001F56C File Offset: 0x0001D76C
			public int GetMax(int i)
			{
				switch (i)
				{
				case 0:
					return this.XMax;
				case 1:
					return this.YMax;
				case 2:
					return this.ZMax;
				case 3:
					return this.RMax;
				case 4:
					return this.UMax;
				case 5:
					return this.VMax;
				default:
					return 0;
				}
			}

			// Token: 0x0400076B RID: 1899
			public ushort Mid;

			// Token: 0x0400076C RID: 1900
			public ushort ProductId;

			// Token: 0x0400076D RID: 1901
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string ProductName;

			// Token: 0x0400076E RID: 1902
			public int XMin;

			// Token: 0x0400076F RID: 1903
			public int XMax;

			// Token: 0x04000770 RID: 1904
			public int YMin;

			// Token: 0x04000771 RID: 1905
			public int YMax;

			// Token: 0x04000772 RID: 1906
			public int ZMin;

			// Token: 0x04000773 RID: 1907
			public int ZMax;

			// Token: 0x04000774 RID: 1908
			public int NumButtons;

			// Token: 0x04000775 RID: 1909
			public int PeriodMin;

			// Token: 0x04000776 RID: 1910
			public int PeriodMax;

			// Token: 0x04000777 RID: 1911
			public int RMin;

			// Token: 0x04000778 RID: 1912
			public int RMax;

			// Token: 0x04000779 RID: 1913
			public int UMin;

			// Token: 0x0400077A RID: 1914
			public int UMax;

			// Token: 0x0400077B RID: 1915
			public int VMin;

			// Token: 0x0400077C RID: 1916
			public int VMax;

			// Token: 0x0400077D RID: 1917
			public WinMMJoystick.JoystCapsFlags Capabilities;

			// Token: 0x0400077E RID: 1918
			public int MaxAxes;

			// Token: 0x0400077F RID: 1919
			public int NumAxes;

			// Token: 0x04000780 RID: 1920
			public int MaxButtons;

			// Token: 0x04000781 RID: 1921
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string RegKey;

			// Token: 0x04000782 RID: 1922
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string OemVxD;

			// Token: 0x04000783 RID: 1923
			public static readonly int SizeInBytes = Marshal.SizeOf(default(WinMMJoystick.JoyCaps));
		}

		// Token: 0x020000E0 RID: 224
		private struct JoyInfo
		{
			// Token: 0x0600094B RID: 2379 RVA: 0x0001F5C8 File Offset: 0x0001D7C8
			public int GetAxis(int i)
			{
				switch (i)
				{
				case 0:
					return this.XPos;
				case 1:
					return this.YPos;
				case 2:
					return this.ZPos;
				default:
					return 0;
				}
			}

			// Token: 0x04000784 RID: 1924
			public int XPos;

			// Token: 0x04000785 RID: 1925
			public int YPos;

			// Token: 0x04000786 RID: 1926
			public int ZPos;

			// Token: 0x04000787 RID: 1927
			public uint Buttons;
		}

		// Token: 0x020000E1 RID: 225
		private struct JoyInfoEx
		{
			// Token: 0x0600094D RID: 2381 RVA: 0x0001F62C File Offset: 0x0001D82C
			public int GetAxis(int i)
			{
				switch (i)
				{
				case 0:
					return this.XPos;
				case 1:
					return this.YPos;
				case 2:
					return this.ZPos;
				case 3:
					return this.RPos;
				case 4:
					return this.UPos;
				case 5:
					return this.VPos;
				default:
					return 0;
				}
			}

			// Token: 0x04000788 RID: 1928
			public int Size;

			// Token: 0x04000789 RID: 1929
			[MarshalAs(UnmanagedType.I4)]
			public WinMMJoystick.JoystickFlags Flags;

			// Token: 0x0400078A RID: 1930
			public int XPos;

			// Token: 0x0400078B RID: 1931
			public int YPos;

			// Token: 0x0400078C RID: 1932
			public int ZPos;

			// Token: 0x0400078D RID: 1933
			public int RPos;

			// Token: 0x0400078E RID: 1934
			public int UPos;

			// Token: 0x0400078F RID: 1935
			public int VPos;

			// Token: 0x04000790 RID: 1936
			public uint Buttons;

			// Token: 0x04000791 RID: 1937
			public uint ButtonNumber;

			// Token: 0x04000792 RID: 1938
			public int Pov;

			// Token: 0x04000793 RID: 1939
			private uint Reserved1;

			// Token: 0x04000794 RID: 1940
			private uint Reserved2;

			// Token: 0x04000795 RID: 1941
			public static readonly int SizeInBytes = Marshal.SizeOf(default(WinMMJoystick.JoyInfoEx));
		}

		// Token: 0x020000E2 RID: 226
		private static class UnsafeNativeMethods
		{
			// Token: 0x0600094E RID: 2382
			[SuppressUnmanagedCodeSecurity]
			[DllImport("Winmm.dll")]
			public static extern WinMMJoystick.JoystickError joyGetDevCaps(int uJoyID, out WinMMJoystick.JoyCaps pjc, int cbjc);

			// Token: 0x0600094F RID: 2383
			[SuppressUnmanagedCodeSecurity]
			[DllImport("Winmm.dll")]
			public static extern WinMMJoystick.JoystickError joyGetPos(int uJoyID, ref WinMMJoystick.JoyInfo pji);

			// Token: 0x06000950 RID: 2384
			[SuppressUnmanagedCodeSecurity]
			[DllImport("Winmm.dll")]
			public static extern WinMMJoystick.JoystickError joyGetPosEx(int uJoyID, ref WinMMJoystick.JoyInfoEx pji);

			// Token: 0x06000951 RID: 2385
			[SuppressUnmanagedCodeSecurity]
			[DllImport("Winmm.dll")]
			public static extern int joyGetNumDevs();

			// Token: 0x06000952 RID: 2386
			[SuppressUnmanagedCodeSecurity]
			[DllImport("Winmm.dll")]
			public static extern WinMMJoystick.JoystickError joyConfigChanged(int flags);
		}

		// Token: 0x020000E3 RID: 227
		[Flags]
		private enum PovType
		{
			// Token: 0x04000797 RID: 1943
			None = 0,
			// Token: 0x04000798 RID: 1944
			Exists = 1,
			// Token: 0x04000799 RID: 1945
			Discrete = 2,
			// Token: 0x0400079A RID: 1946
			Continuous = 4
		}

		// Token: 0x020000E4 RID: 228
		private struct WinMMJoyDetails
		{
			// Token: 0x06000953 RID: 2387 RVA: 0x0001F688 File Offset: 0x0001D888
			public WinMMJoyDetails(JoystickCapabilities caps)
			{
				this = default(WinMMJoystick.WinMMJoyDetails);
				this.Min = new int[caps.AxisCount];
				this.Max = new int[caps.AxisCount];
				this.Capabilities = caps;
			}

			// Token: 0x06000954 RID: 2388 RVA: 0x0001F6BC File Offset: 0x0001D8BC
			public float CalculateOffset(float pos, int axis)
			{
				float num = 2f * (pos - (float)this.Min[axis]) / (float)(this.Max[axis] - this.Min[axis]) - 1f;
				if (num > 1f)
				{
					return 1f;
				}
				if (num < -1f)
				{
					return -1f;
				}
				if (num < 0.001f && num > -0.001f)
				{
					return 0f;
				}
				return num;
			}

			// Token: 0x0400079B RID: 1947
			public readonly int[] Min;

			// Token: 0x0400079C RID: 1948
			public readonly int[] Max;

			// Token: 0x0400079D RID: 1949
			public WinMMJoystick.PovType PovType;

			// Token: 0x0400079E RID: 1950
			public JoystickCapabilities Capabilities;
		}
	}
}
