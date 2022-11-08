using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenTK.Input;
using OpenTK.Platform.MacOS.Carbon;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x0200058F RID: 1423
	internal class HIDInput : IInputDriver2, IDisposable, IMouseDriver2, IKeyboardDriver2, IJoystickDriver2
	{
		// Token: 0x060045A5 RID: 17829 RVA: 0x000BF4C0 File Offset: 0x000BD6C0
		public HIDInput()
		{
			this.HandleDeviceAdded = new HIDInput.NativeMethods.IOHIDDeviceCallback(this.DeviceAdded);
			this.HandleDeviceRemoved = new HIDInput.NativeMethods.IOHIDDeviceCallback(this.DeviceRemoved);
			this.HandleDeviceValueReceived = new HIDInput.NativeMethods.IOHIDValueCallback(this.DeviceValueReceived);
			this.hidmanager = this.CreateHIDManager();
			this.RegisterHIDCallbacks(this.hidmanager);
			this.RegisterMouseMonitor();
		}

		// Token: 0x060045A6 RID: 17830 RVA: 0x000BF5A8 File Offset: 0x000BD7A8
		private void RegisterMouseMonitor()
		{
			this.MouseEventTapDelegate = new CG.EventTapCallBack(this.MouseEventTapCallback);
			this.MouseEventTap = CG.EventTapCreate(CGEventTapLocation.HIDEventTap, CGEventTapPlacement.HeadInsert, CGEventTapOptions.ListenOnly, CGEventMask.AllMouse, this.MouseEventTapDelegate, IntPtr.Zero);
			if (this.MouseEventTap != IntPtr.Zero)
			{
				this.MouseEventTapSource = CF.MachPortCreateRunLoopSource(IntPtr.Zero, this.MouseEventTap, IntPtr.Zero);
				CF.RunLoopAddSource(this.RunLoop, this.MouseEventTapSource, CF.RunLoopModeDefault);
			}
		}

		// Token: 0x060045A7 RID: 17831 RVA: 0x000BF62C File Offset: 0x000BD82C
		private IntPtr MouseEventTapCallback(IntPtr proxy, CGEventType type, IntPtr @event, IntPtr refcon)
		{
			this.CursorState.SetIsConnected(true);
			switch (type)
			{
			case CGEventType.LeftMouseDown:
			case CGEventType.RightMouseDown:
				goto IL_D1;
			case CGEventType.LeftMouseUp:
			case CGEventType.RightMouseUp:
				goto IL_FC;
			case CGEventType.MouseMoved:
			case CGEventType.LeftMouseDragged:
			case CGEventType.RightMouseDragged:
				break;
			default:
				switch (type)
				{
				case CGEventType.ScrollWheel:
				{
					double num = CG.EventGetDoubleValueField(@event, CGEventField.ScrollWheelEventPointDeltaAxis2) * 0.10000000149011612;
					double num2 = CG.EventGetDoubleValueField(@event, CGEventField.ScrollWheelEventPointDeltaAxis1) * 0.10000000149011612;
					this.CursorState.SetScrollRelative((float)(-(float)num), (float)num2);
					return @event;
				}
				case CGEventType.TabletPointer:
				case CGEventType.TabletProximity:
					return @event;
				case CGEventType.OtherMouseDown:
					goto IL_D1;
				case CGEventType.OtherMouseUp:
					goto IL_FC;
				case CGEventType.OtherMouseDragged:
					break;
				default:
					return @event;
				}
				break;
			}
			HIPoint hipoint = CG.EventGetLocation(@event);
			this.CursorState.X = (int)Math.Round((double)hipoint.X);
			this.CursorState.Y = (int)Math.Round((double)hipoint.Y);
			return @event;
			IL_D1:
			int num3 = CG.EventGetIntegerValueField(@event, CGEventField.MouseEventButtonNumber);
			num3 = ((num3 == 1) ? 2 : ((num3 == 2) ? 1 : num3));
			MouseButton button = (MouseButton)num3;
			this.CursorState[button] = true;
			return @event;
			IL_FC:
			int num4 = CG.EventGetIntegerValueField(@event, CGEventField.MouseEventButtonNumber);
			num4 = ((num4 == 1) ? 2 : ((num4 == 2) ? 1 : num4));
			MouseButton button2 = (MouseButton)num4;
			this.CursorState[button2] = false;
			return @event;
		}

		// Token: 0x060045A8 RID: 17832 RVA: 0x000BF768 File Offset: 0x000BD968
		private IntPtr CreateHIDManager()
		{
			return HIDInput.NativeMethods.IOHIDManagerCreate(IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x060045A9 RID: 17833 RVA: 0x000BF77C File Offset: 0x000BD97C
		private void RegisterHIDCallbacks(IntPtr hidmanager)
		{
			HIDInput.NativeMethods.IOHIDManagerRegisterDeviceMatchingCallback(hidmanager, this.HandleDeviceAdded, IntPtr.Zero);
			HIDInput.NativeMethods.IOHIDManagerRegisterDeviceRemovalCallback(hidmanager, this.HandleDeviceRemoved, IntPtr.Zero);
			HIDInput.NativeMethods.IOHIDManagerScheduleWithRunLoop(hidmanager, this.RunLoop, this.InputLoopMode);
			HIDInput.NativeMethods.IOHIDManagerSetDeviceMatching(hidmanager, this.DeviceTypes.Ref);
			HIDInput.NativeMethods.IOHIDManagerOpen(hidmanager, IntPtr.Zero);
			CF.CFRunLoopRunInMode(this.InputLoopMode, 0.0, true);
		}

		// Token: 0x060045AA RID: 17834 RVA: 0x000BF7F4 File Offset: 0x000BD9F4
		private void DeviceAdded(IntPtr context, IntPtr res, IntPtr sender, IntPtr device)
		{
			try
			{
				bool flag = false;
				if (HIDInput.NativeMethods.IOHIDDeviceOpen(device, IntPtr.Zero) == IntPtr.Zero)
				{
					if (HIDInput.NativeMethods.IOHIDDeviceConformsTo(device, HIDInput.HIDPage.GenericDesktop, 2))
					{
						this.AddMouse(sender, device);
						flag = true;
					}
					if (HIDInput.NativeMethods.IOHIDDeviceConformsTo(device, HIDInput.HIDPage.GenericDesktop, 6))
					{
						this.AddKeyboard(sender, device);
						flag = true;
					}
					bool flag2 = false;
					flag2 |= HIDInput.NativeMethods.IOHIDDeviceConformsTo(device, HIDInput.HIDPage.GenericDesktop, 4);
					flag2 |= HIDInput.NativeMethods.IOHIDDeviceConformsTo(device, HIDInput.HIDPage.GenericDesktop, 5);
					flag2 |= HIDInput.NativeMethods.IOHIDDeviceConformsTo(device, HIDInput.HIDPage.GenericDesktop, 8);
					flag2 |= HIDInput.NativeMethods.IOHIDDeviceConformsTo(device, HIDInput.HIDPage.GenericDesktop, 56);
					if (flag2)
					{
						this.AddJoystick(sender, device);
						flag = true;
					}
					if (flag)
					{
						HIDInput.NativeMethods.IOHIDDeviceRegisterInputValueCallback(device, this.HandleDeviceValueReceived, device);
						HIDInput.NativeMethods.IOHIDDeviceScheduleWithRunLoop(device, this.RunLoop, this.InputLoopMode);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060045AB RID: 17835 RVA: 0x000BF8C8 File Offset: 0x000BDAC8
		private void DeviceRemoved(IntPtr context, IntPtr res, IntPtr sender, IntPtr device)
		{
			try
			{
				bool flag = false;
				if (this.MouseDevices.ContainsKey(device))
				{
					this.RemoveMouse(sender, device);
					flag = true;
				}
				if (this.KeyboardDevices.ContainsKey(device))
				{
					this.RemoveKeyboard(sender, device);
					flag = true;
				}
				if (this.JoystickDevices.ContainsKey(device))
				{
					this.RemoveJoystick(sender, device);
					flag = true;
				}
				if (flag)
				{
					HIDInput.NativeMethods.IOHIDDeviceRegisterInputValueCallback(device, IntPtr.Zero, IntPtr.Zero);
					HIDInput.NativeMethods.IOHIDDeviceUnscheduleFromRunLoop(device, this.RunLoop, this.InputLoopMode);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060045AC RID: 17836 RVA: 0x000BF964 File Offset: 0x000BDB64
		private void DeviceValueReceived(IntPtr context, IntPtr res, IntPtr sender, IntPtr val)
		{
			try
			{
				if (!this.disposed)
				{
					HIDInput.MouseData mouse;
					HIDInput.KeyboardData keyboard;
					HIDInput.JoystickData joy;
					if (this.MouseDevices.TryGetValue(context, out mouse))
					{
						HIDInput.UpdateMouse(mouse, val);
					}
					else if (this.KeyboardDevices.TryGetValue(context, out keyboard))
					{
						HIDInput.UpdateKeyboard(keyboard, val);
					}
					else if (this.JoystickDevices.TryGetValue(context, out joy))
					{
						HIDInput.UpdateJoystick(joy, val);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060045AD RID: 17837 RVA: 0x000BF9DC File Offset: 0x000BDBDC
		private void AddMouse(IntPtr sender, IntPtr device)
		{
			if (!this.MouseDevices.ContainsKey(device))
			{
				this.MouseIndexToDevice.Add(this.MouseDevices.Count, device);
				this.MouseDevices.Add(device, new HIDInput.MouseData());
			}
			this.MouseDevices[device].State.SetIsConnected(true);
		}

		// Token: 0x060045AE RID: 17838 RVA: 0x000BFA38 File Offset: 0x000BDC38
		private void RemoveMouse(IntPtr sender, IntPtr device)
		{
			this.MouseDevices[device].State.SetIsConnected(false);
		}

		// Token: 0x060045AF RID: 17839 RVA: 0x000BFA54 File Offset: 0x000BDC54
		private static void UpdateMouse(HIDInput.MouseData mouse, IntPtr val)
		{
			IntPtr elem = HIDInput.NativeMethods.IOHIDValueGetElement(val);
			int num = HIDInput.NativeMethods.IOHIDValueGetIntegerValue(val).ToInt32();
			HIDInput.HIDPage hidpage = HIDInput.NativeMethods.IOHIDElementGetUsagePage(elem);
			int num2 = HIDInput.NativeMethods.IOHIDElementGetUsage(elem);
			HIDInput.HIDPage hidpage2 = hidpage;
			if (hidpage2 != HIDInput.HIDPage.GenericDesktop)
			{
				if (hidpage2 == HIDInput.HIDPage.Button)
				{
					mouse.State[(MouseButton)(num2 - 1)] = (num == 1);
					return;
				}
				if (hidpage2 != HIDInput.HIDPage.Consumer)
				{
					return;
				}
				HIDInput.HIDUsageCD hidusageCD = (HIDInput.HIDUsageCD)num2;
				if (hidusageCD != HIDInput.HIDUsageCD.ACPan)
				{
					return;
				}
				mouse.State.SetScrollRelative((float)num, 0f);
				return;
			}
			else
			{
				HIDInput.HIDUsageGD hidusageGD = (HIDInput.HIDUsageGD)num2;
				switch (hidusageGD)
				{
				case HIDInput.HIDUsageGD.X:
					mouse.State.X = mouse.State.X + num;
					return;
				case HIDInput.HIDUsageGD.Y:
					mouse.State.Y = mouse.State.Y + num;
					return;
				case HIDInput.HIDUsageGD.Z:
					mouse.State.SetScrollRelative((float)num, 0f);
					return;
				default:
					if (hidusageGD != HIDInput.HIDUsageGD.Wheel)
					{
						return;
					}
					mouse.State.SetScrollRelative(0f, (float)num);
					return;
				}
			}
		}

		// Token: 0x060045B0 RID: 17840 RVA: 0x000BFB40 File Offset: 0x000BDD40
		private void AddKeyboard(IntPtr sender, IntPtr device)
		{
			if (!this.KeyboardDevices.ContainsKey(device))
			{
				this.KeyboardIndexToDevice.Add(this.KeyboardDevices.Count, device);
				this.KeyboardDevices.Add(device, new HIDInput.KeyboardData());
			}
			this.KeyboardDevices[device].State.SetIsConnected(true);
		}

		// Token: 0x060045B1 RID: 17841 RVA: 0x000BFB9C File Offset: 0x000BDD9C
		private void RemoveKeyboard(IntPtr sender, IntPtr device)
		{
			this.KeyboardDevices[device].State.SetIsConnected(false);
		}

		// Token: 0x060045B2 RID: 17842 RVA: 0x000BFBB8 File Offset: 0x000BDDB8
		private static void UpdateKeyboard(HIDInput.KeyboardData keyboard, IntPtr val)
		{
			IntPtr elem = HIDInput.NativeMethods.IOHIDValueGetElement(val);
			int num = HIDInput.NativeMethods.IOHIDValueGetIntegerValue(val).ToInt32();
			HIDInput.HIDPage hidpage = HIDInput.NativeMethods.IOHIDElementGetUsagePage(elem);
			int num2 = HIDInput.NativeMethods.IOHIDElementGetUsage(elem);
			if (num2 >= 0)
			{
				HIDInput.HIDPage hidpage2 = hidpage;
				if (hidpage2 != HIDInput.HIDPage.GenericDesktop && hidpage2 != HIDInput.HIDPage.KeyboardOrKeypad)
				{
					return;
				}
				int num3 = HIDInput.RawKeyMap.Length;
				keyboard.State[HIDInput.RawKeyMap[num2]] = (num != 0);
			}
		}

		// Token: 0x060045B3 RID: 17843 RVA: 0x000BFC20 File Offset: 0x000BDE20
		private Guid CreateJoystickGuid(IntPtr device, string name)
		{
			List<byte> list = new List<byte>();
			long num = 0L;
			long num2 = 0L;
			IntPtr intPtr = HIDInput.NativeMethods.IOHIDDeviceGetProperty(device, HIDInput.NativeMethods.IOHIDVendorIDKey);
			IntPtr intPtr2 = HIDInput.NativeMethods.IOHIDDeviceGetProperty(device, HIDInput.NativeMethods.IOHIDProductIDKey);
			if (intPtr != IntPtr.Zero)
			{
				CF.CFNumberGetValue(intPtr, CF.CFNumberType.kCFNumberLongType, out num);
			}
			if (intPtr2 != IntPtr.Zero)
			{
				CF.CFNumberGetValue(intPtr2, CF.CFNumberType.kCFNumberLongType, out num2);
			}
			if (num != 0L && num2 != 0L)
			{
				list.AddRange(BitConverter.GetBytes(num));
				list.AddRange(BitConverter.GetBytes(num2));
			}
			else
			{
				list.Add(5);
				list.Add(0);
				list.Add(0);
				list.Add(0);
				byte[] array = new byte[12];
				Array.Copy(Encoding.UTF8.GetBytes(name), array, array.Length);
				list.AddRange(array);
			}
			return new Guid(list.ToArray());
		}

		// Token: 0x060045B4 RID: 17844 RVA: 0x000BFCF8 File Offset: 0x000BDEF8
		private HIDInput.JoystickData CreateJoystick(IntPtr sender, IntPtr device)
		{
			HIDInput.JoystickData joystickData = null;
			IntPtr intPtr = HIDInput.NativeMethods.IOHIDDeviceCopyMatchingElements(device, IntPtr.Zero, IntPtr.Zero);
			if (intPtr != IntPtr.Zero)
			{
				joystickData = new HIDInput.JoystickData();
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				IntPtr cfstr = HIDInput.NativeMethods.IOHIDDeviceGetProperty(device, HIDInput.NativeMethods.IOHIDProductKey);
				string name = CF.CFStringGetCString(cfstr);
				Guid guid = this.CreateJoystickGuid(device, name);
				List<int> list = new List<int>();
				List<IntPtr> list2 = new List<IntPtr>();
				CFArray cfarray = new CFArray(intPtr);
				for (int i = 0; i < cfarray.Count; i++)
				{
					IntPtr intPtr2 = cfarray[i];
					HIDInput.NativeMethods.IOHIDElementGetType(intPtr2);
					HIDInput.HIDPage hidpage = HIDInput.NativeMethods.IOHIDElementGetUsagePage(intPtr2);
					int item = HIDInput.NativeMethods.IOHIDElementGetUsage(intPtr2);
					HIDInput.HIDPage hidpage2 = hidpage;
					switch (hidpage2)
					{
					case HIDInput.HIDPage.GenericDesktop:
						switch (item)
						{
						case 48:
						case 49:
						case 50:
						case 51:
						case 52:
						case 53:
						case 54:
						case 55:
						case 56:
							num++;
							break;
						case 57:
							num3++;
							list2.Add(intPtr2);
							break;
						}
						break;
					case HIDInput.HIDPage.Simulation:
						switch (item)
						{
						case 186:
						case 187:
							num++;
							break;
						}
						break;
					default:
						if (hidpage2 == HIDInput.HIDPage.Button)
						{
							list.Add(item);
						}
						break;
					}
				}
				if (num > 11)
				{
					num = 11;
				}
				if (num2 > 32)
				{
					num2 = 32;
				}
				if (num3 > 4)
				{
					num3 = 4;
				}
				joystickData.Name = name;
				joystickData.Guid = guid;
				joystickData.State.SetIsConnected(true);
				joystickData.Capabilities = new JoystickCapabilities(num, num2, num3, true);
				for (int j = 0; j < list.Count; j++)
				{
					joystickData.ElementUsageToButton.Add(list[j], (JoystickButton)j);
				}
				for (int k = 0; k < list2.Count; k++)
				{
					joystickData.ElementToHat.Add(list2[k], (JoystickHat)k);
				}
			}
			CF.CFRelease(intPtr);
			return joystickData;
		}

		// Token: 0x060045B5 RID: 17845 RVA: 0x000BFEE8 File Offset: 0x000BE0E8
		private HIDInput.JoystickData GetJoystick(int index)
		{
			IntPtr key;
			HIDInput.JoystickData result;
			if (this.JoystickIndexToDevice.TryGetValue(index, out key) && this.JoystickDevices.TryGetValue(key, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060045B6 RID: 17846 RVA: 0x000BFF18 File Offset: 0x000BE118
		private void AddJoystick(IntPtr sender, IntPtr device)
		{
			HIDInput.JoystickData joystickData = this.CreateJoystick(sender, device);
			if (joystickData != null)
			{
				if (!this.JoystickDevices.ContainsKey(device))
				{
					this.JoystickDevices.Add(device, joystickData);
				}
				else
				{
					this.JoystickDevices[device] = joystickData;
				}
				int i;
				for (i = 0; i < this.JoystickIndexToDevice.Count; i++)
				{
					IntPtr key = this.JoystickIndexToDevice[i];
					if (!this.JoystickDevices[key].State.IsConnected)
					{
						break;
					}
				}
				if (i == this.JoystickDevices.Count)
				{
					this.JoystickIndexToDevice.Add(this.JoystickDevices.Count, device);
					return;
				}
				this.JoystickIndexToDevice[i] = device;
			}
		}

		// Token: 0x060045B7 RID: 17847 RVA: 0x000BFFCC File Offset: 0x000BE1CC
		private void RemoveJoystick(IntPtr sender, IntPtr device)
		{
			this.JoystickDevices[device].State = default(JoystickState);
			this.JoystickDevices[device].Capabilities = default(JoystickCapabilities);
		}

		// Token: 0x060045B8 RID: 17848 RVA: 0x000BFFFC File Offset: 0x000BE1FC
		private static void UpdateJoystick(HIDInput.JoystickData joy, IntPtr val)
		{
			IntPtr intPtr = HIDInput.NativeMethods.IOHIDValueGetElement(val);
			HIDInput.HIDPage hidpage = HIDInput.NativeMethods.IOHIDElementGetUsagePage(intPtr);
			int usage = HIDInput.NativeMethods.IOHIDElementGetUsage(intPtr);
			HIDInput.HIDPage hidpage2 = hidpage;
			switch (hidpage2)
			{
			case HIDInput.HIDPage.GenericDesktop:
				switch (usage)
				{
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				{
					short joystickAxis = HIDInput.GetJoystickAxis(val, intPtr);
					JoystickAxis joystickAxis2 = HIDInput.TranslateJoystickAxis(usage);
					if (joystickAxis2 >= JoystickAxis.Axis0 && joystickAxis2 <= JoystickAxis.Axis10)
					{
						joy.State.SetAxis(joystickAxis2, joystickAxis);
						return;
					}
					break;
				}
				case 57:
				{
					HatPosition joystickHat = HIDInput.GetJoystickHat(val, intPtr);
					JoystickHat joystickHat2 = HIDInput.TranslateJoystickHat(joy, intPtr);
					if (joystickHat2 >= JoystickHat.Hat0 && joystickHat2 <= JoystickHat.Hat3)
					{
						joy.State.SetHat(joystickHat2, new JoystickHatState(joystickHat));
						return;
					}
					break;
				}
				default:
					return;
				}
				break;
			case HIDInput.HIDPage.Simulation:
				switch (usage)
				{
				case 186:
				case 187:
				{
					short joystickAxis3 = HIDInput.GetJoystickAxis(val, intPtr);
					JoystickAxis joystickAxis4 = HIDInput.TranslateJoystickAxis(usage);
					if (joystickAxis4 >= JoystickAxis.Axis0 && joystickAxis4 <= JoystickAxis.Axis10)
					{
						joy.State.SetAxis(joystickAxis4, joystickAxis3);
						return;
					}
					break;
				}
				default:
					return;
				}
				break;
			default:
			{
				if (hidpage2 != HIDInput.HIDPage.Button)
				{
					return;
				}
				bool joystickButton = HIDInput.GetJoystickButton(val, intPtr);
				JoystickButton joystickButton2 = HIDInput.TranslateJoystickButton(joy, usage);
				if (joystickButton2 >= JoystickButton.Button0 && joystickButton2 <= JoystickButton.Button31)
				{
					joy.State.SetButton(joystickButton2, joystickButton);
				}
				break;
			}
			}
		}

		// Token: 0x060045B9 RID: 17849 RVA: 0x000C014C File Offset: 0x000BE34C
		private static short GetJoystickAxis(IntPtr val, IntPtr element)
		{
			int num = HIDInput.NativeMethods.IOHIDElementGetLogicalMax(element).ToInt32();
			int num2 = HIDInput.NativeMethods.IOHIDElementGetLogicalMin(element).ToInt32();
			int num3 = HIDInput.NativeMethods.IOHIDValueGetIntegerValue(val).ToInt32();
			if (num3 < num2)
			{
				num3 = num2;
			}
			if (num3 > num)
			{
				num3 = num;
			}
			return (short)((num3 - num2) * 65536 / (num - num2) + 32768);
		}

		// Token: 0x060045BA RID: 17850 RVA: 0x000C01A8 File Offset: 0x000BE3A8
		private static JoystickAxis TranslateJoystickAxis(int usage)
		{
			switch (usage)
			{
			case 48:
				return JoystickAxis.Axis0;
			case 49:
				return JoystickAxis.Axis1;
			case 50:
				return JoystickAxis.Axis2;
			case 51:
				return JoystickAxis.Axis4;
			case 52:
				return JoystickAxis.Axis5;
			case 53:
				return JoystickAxis.Axis3;
			case 54:
				return JoystickAxis.Axis6;
			case 55:
				return JoystickAxis.Axis7;
			case 56:
				return JoystickAxis.Axis8;
			default:
				switch (usage)
				{
				case 186:
					return JoystickAxis.Axis9;
				case 187:
					return JoystickAxis.Axis10;
				default:
					return JoystickAxis.Axis0;
				}
				break;
			}
		}

		// Token: 0x060045BB RID: 17851 RVA: 0x000C0214 File Offset: 0x000BE414
		private static bool GetJoystickButton(IntPtr val, IntPtr element)
		{
			int num = HIDInput.NativeMethods.IOHIDValueGetIntegerValue(val).ToInt32();
			return num >= 1;
		}

		// Token: 0x060045BC RID: 17852 RVA: 0x000C0238 File Offset: 0x000BE438
		private static JoystickButton TranslateJoystickButton(HIDInput.JoystickData joy, int usage)
		{
			JoystickButton result;
			if (joy.ElementUsageToButton.TryGetValue(usage, out result))
			{
				return result;
			}
			return (JoystickButton)32;
		}

		// Token: 0x060045BD RID: 17853 RVA: 0x000C025C File Offset: 0x000BE45C
		private static HatPosition GetJoystickHat(IntPtr val, IntPtr element)
		{
			HatPosition result = HatPosition.Centered;
			int num = HIDInput.NativeMethods.IOHIDElementGetLogicalMax(element).ToInt32();
			int num2 = HIDInput.NativeMethods.IOHIDElementGetLogicalMin(element).ToInt32();
			int num3 = HIDInput.NativeMethods.IOHIDValueGetIntegerValue(val).ToInt32() - num2;
			int num4 = Math.Abs(num - num2 + 1);
			if (num3 >= 0)
			{
				if (num4 == 4)
				{
					num3 *= 2;
				}
				if (num4 == 8)
				{
					result = (HatPosition)num3;
				}
			}
			return result;
		}

		// Token: 0x060045BE RID: 17854 RVA: 0x000C02C0 File Offset: 0x000BE4C0
		private static JoystickHat TranslateJoystickHat(HIDInput.JoystickData joy, IntPtr elem)
		{
			JoystickHat result;
			if (joy.ElementToHat.TryGetValue(elem, out result))
			{
				return result;
			}
			return (JoystickHat)4;
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x060045BF RID: 17855 RVA: 0x000C02E0 File Offset: 0x000BE4E0
		public IMouseDriver2 MouseDriver
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x060045C0 RID: 17856 RVA: 0x000C02E4 File Offset: 0x000BE4E4
		public IKeyboardDriver2 KeyboardDriver
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x060045C1 RID: 17857 RVA: 0x000C02E8 File Offset: 0x000BE4E8
		public IGamePadDriver GamePadDriver
		{
			get
			{
				return this.mapped_gamepad;
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x060045C2 RID: 17858 RVA: 0x000C02F0 File Offset: 0x000BE4F0
		public IJoystickDriver2 JoystickDriver
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060045C3 RID: 17859 RVA: 0x000C02F4 File Offset: 0x000BE4F4
		MouseState IMouseDriver2.GetState()
		{
			MouseState result = default(MouseState);
			foreach (KeyValuePair<IntPtr, HIDInput.MouseData> keyValuePair in this.MouseDevices)
			{
				result.MergeBits(keyValuePair.Value.State);
			}
			return result;
		}

		// Token: 0x060045C4 RID: 17860 RVA: 0x000C035C File Offset: 0x000BE55C
		MouseState IMouseDriver2.GetState(int index)
		{
			IntPtr key;
			if (this.MouseIndexToDevice.TryGetValue(index, out key))
			{
				return this.MouseDevices[key].State;
			}
			return default(MouseState);
		}

		// Token: 0x060045C5 RID: 17861 RVA: 0x000C0394 File Offset: 0x000BE594
		MouseState IMouseDriver2.GetCursorState()
		{
			return this.CursorState;
		}

		// Token: 0x060045C6 RID: 17862 RVA: 0x000C039C File Offset: 0x000BE59C
		void IMouseDriver2.SetPosition(double x, double y)
		{
			CG.SetLocalEventsSuppressionInterval(0.0);
			CG.WarpMouseCursorPosition(new HIPoint(x, y));
		}

		// Token: 0x060045C7 RID: 17863 RVA: 0x000C03BC File Offset: 0x000BE5BC
		KeyboardState IKeyboardDriver2.GetState()
		{
			KeyboardState result = default(KeyboardState);
			foreach (KeyValuePair<IntPtr, HIDInput.KeyboardData> keyValuePair in this.KeyboardDevices)
			{
				result.MergeBits(keyValuePair.Value.State);
			}
			return result;
		}

		// Token: 0x060045C8 RID: 17864 RVA: 0x000C0424 File Offset: 0x000BE624
		KeyboardState IKeyboardDriver2.GetState(int index)
		{
			IntPtr key;
			if (this.KeyboardIndexToDevice.TryGetValue(index, out key))
			{
				return this.KeyboardDevices[key].State;
			}
			return default(KeyboardState);
		}

		// Token: 0x060045C9 RID: 17865 RVA: 0x000C045C File Offset: 0x000BE65C
		string IKeyboardDriver2.GetDeviceName(int index)
		{
			IntPtr device;
			if (this.KeyboardIndexToDevice.TryGetValue(index, out device))
			{
				IntPtr intPtr = HIDInput.NativeMethods.IOHIDDeviceGetProperty(device, HIDInput.NativeMethods.IOHIDVendorIDKey);
				IntPtr intPtr2 = HIDInput.NativeMethods.IOHIDDeviceGetProperty(device, HIDInput.NativeMethods.IOHIDProductIDKey);
				return string.Format("{0}:{1}", intPtr, intPtr2);
			}
			return string.Empty;
		}

		// Token: 0x060045CA RID: 17866 RVA: 0x000C04B0 File Offset: 0x000BE6B0
		JoystickState IJoystickDriver2.GetState(int index)
		{
			HIDInput.JoystickData joystick = this.GetJoystick(index);
			if (joystick != null)
			{
				return joystick.State;
			}
			return default(JoystickState);
		}

		// Token: 0x060045CB RID: 17867 RVA: 0x000C04D8 File Offset: 0x000BE6D8
		JoystickCapabilities IJoystickDriver2.GetCapabilities(int index)
		{
			HIDInput.JoystickData joystick = this.GetJoystick(index);
			if (joystick != null)
			{
				return joystick.Capabilities;
			}
			return default(JoystickCapabilities);
		}

		// Token: 0x060045CC RID: 17868 RVA: 0x000C0500 File Offset: 0x000BE700
		Guid IJoystickDriver2.GetGuid(int index)
		{
			HIDInput.JoystickData joystick = this.GetJoystick(index);
			if (joystick != null)
			{
				return joystick.Guid;
			}
			return default(Guid);
		}

		// Token: 0x060045CD RID: 17869 RVA: 0x000C0528 File Offset: 0x000BE728
		private void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				if (manual)
				{
					HIDInput.NativeMethods.IOHIDManagerRegisterDeviceMatchingCallback(this.hidmanager, IntPtr.Zero, IntPtr.Zero);
					HIDInput.NativeMethods.IOHIDManagerRegisterDeviceRemovalCallback(this.hidmanager, IntPtr.Zero, IntPtr.Zero);
					HIDInput.NativeMethods.IOHIDManagerUnscheduleFromRunLoop(this.hidmanager, this.RunLoop, this.InputLoopMode);
					foreach (IntPtr device in this.MouseDevices.Keys)
					{
						this.DeviceRemoved(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, device);
					}
					foreach (IntPtr device2 in this.KeyboardDevices.Keys)
					{
						this.DeviceRemoved(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, device2);
					}
					foreach (IntPtr device3 in this.JoystickDevices.Keys)
					{
						this.DeviceRemoved(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, device3);
					}
					this.HandleDeviceAdded = null;
					this.HandleDeviceRemoved = null;
					this.HandleDeviceValueReceived = null;
					if (this.MouseEventTap != IntPtr.Zero)
					{
						CF.CFRelease(this.MouseEventTap);
						this.MouseEventTap = IntPtr.Zero;
					}
					if (this.MouseEventTapSource != IntPtr.Zero)
					{
						CF.CFRelease(this.MouseEventTapSource);
						this.MouseEventTapSource = IntPtr.Zero;
					}
				}
				this.disposed = true;
			}
		}

		// Token: 0x060045CE RID: 17870 RVA: 0x000C06FC File Offset: 0x000BE8FC
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060045CF RID: 17871 RVA: 0x000C070C File Offset: 0x000BE90C
		~HIDInput()
		{
			this.Dispose(false);
		}

		// Token: 0x040050A3 RID: 20643
		private readonly IntPtr hidmanager;

		// Token: 0x040050A4 RID: 20644
		private readonly Dictionary<IntPtr, HIDInput.MouseData> MouseDevices = new Dictionary<IntPtr, HIDInput.MouseData>(new IntPtrEqualityComparer());

		// Token: 0x040050A5 RID: 20645
		private readonly Dictionary<int, IntPtr> MouseIndexToDevice = new Dictionary<int, IntPtr>();

		// Token: 0x040050A6 RID: 20646
		private readonly Dictionary<IntPtr, HIDInput.KeyboardData> KeyboardDevices = new Dictionary<IntPtr, HIDInput.KeyboardData>(new IntPtrEqualityComparer());

		// Token: 0x040050A7 RID: 20647
		private readonly Dictionary<int, IntPtr> KeyboardIndexToDevice = new Dictionary<int, IntPtr>();

		// Token: 0x040050A8 RID: 20648
		private readonly Dictionary<IntPtr, HIDInput.JoystickData> JoystickDevices = new Dictionary<IntPtr, HIDInput.JoystickData>(new IntPtrEqualityComparer());

		// Token: 0x040050A9 RID: 20649
		private readonly Dictionary<int, IntPtr> JoystickIndexToDevice = new Dictionary<int, IntPtr>();

		// Token: 0x040050AA RID: 20650
		private readonly IntPtr RunLoop = CF.CFRunLoopGetMain();

		// Token: 0x040050AB RID: 20651
		private readonly IntPtr InputLoopMode = CF.RunLoopModeDefault;

		// Token: 0x040050AC RID: 20652
		private readonly CFDictionary DeviceTypes = default(CFDictionary);

		// Token: 0x040050AD RID: 20653
		private readonly MappedGamePadDriver mapped_gamepad = new MappedGamePadDriver();

		// Token: 0x040050AE RID: 20654
		private IntPtr MouseEventTap;

		// Token: 0x040050AF RID: 20655
		private IntPtr MouseEventTapSource;

		// Token: 0x040050B0 RID: 20656
		private MouseState CursorState;

		// Token: 0x040050B1 RID: 20657
		private HIDInput.NativeMethods.IOHIDDeviceCallback HandleDeviceAdded;

		// Token: 0x040050B2 RID: 20658
		private HIDInput.NativeMethods.IOHIDDeviceCallback HandleDeviceRemoved;

		// Token: 0x040050B3 RID: 20659
		private HIDInput.NativeMethods.IOHIDValueCallback HandleDeviceValueReceived;

		// Token: 0x040050B4 RID: 20660
		private bool disposed;

		// Token: 0x040050B5 RID: 20661
		private CG.EventTapCallBack MouseEventTapDelegate;

		// Token: 0x040050B6 RID: 20662
		private static readonly Key[] RawKeyMap = new Key[]
		{
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.A,
			Key.B,
			Key.C,
			Key.D,
			Key.E,
			Key.F,
			Key.G,
			Key.H,
			Key.I,
			Key.J,
			Key.K,
			Key.L,
			Key.M,
			Key.N,
			Key.O,
			Key.P,
			Key.Q,
			Key.R,
			Key.S,
			Key.T,
			Key.U,
			Key.V,
			Key.W,
			Key.X,
			Key.Y,
			Key.Z,
			Key.Number1,
			Key.Number2,
			Key.Number3,
			Key.Number4,
			Key.Number5,
			Key.Number6,
			Key.Number7,
			Key.Number8,
			Key.Number9,
			Key.Number0,
			Key.Enter,
			Key.Escape,
			Key.BackSpace,
			Key.Tab,
			Key.Space,
			Key.Minus,
			Key.Plus,
			Key.BracketLeft,
			Key.BracketRight,
			Key.BackSlash,
			Key.Minus,
			Key.Semicolon,
			Key.Quote,
			Key.Tilde,
			Key.Comma,
			Key.Period,
			Key.Slash,
			Key.CapsLock,
			Key.F1,
			Key.F2,
			Key.F3,
			Key.F4,
			Key.F5,
			Key.F6,
			Key.F7,
			Key.F8,
			Key.F9,
			Key.F10,
			Key.F11,
			Key.F12,
			Key.PrintScreen,
			Key.ScrollLock,
			Key.Pause,
			Key.Insert,
			Key.Home,
			Key.PageUp,
			Key.Delete,
			Key.End,
			Key.PageDown,
			Key.Right,
			Key.Left,
			Key.Down,
			Key.Up,
			Key.NumLock,
			Key.KeypadDivide,
			Key.KeypadMultiply,
			Key.KeypadSubtract,
			Key.KeypadAdd,
			Key.KeypadEnter,
			Key.Keypad1,
			Key.Keypad2,
			Key.Keypad3,
			Key.Keypad4,
			Key.Keypad5,
			Key.Keypad6,
			Key.Keypad7,
			Key.Keypad8,
			Key.Keypad9,
			Key.Keypad0,
			Key.KeypadDecimal,
			Key.BackSlash,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.F13,
			Key.F14,
			Key.F15,
			Key.F16,
			Key.F17,
			Key.F18,
			Key.F19,
			Key.F20,
			Key.F21,
			Key.F22,
			Key.F23,
			Key.F24,
			Key.Unknown,
			Key.Unknown,
			Key.Menu,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.CapsLock,
			Key.NumLock,
			Key.ScrollLock,
			Key.KeypadDecimal,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Enter,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.Unknown,
			Key.ControlLeft,
			Key.ShiftLeft,
			Key.AltLeft,
			Key.WinLeft,
			Key.ControlRight,
			Key.ShiftRight,
			Key.AltRight,
			Key.WinRight
		};

		// Token: 0x02000590 RID: 1424
		private class MouseData
		{
			// Token: 0x040050B7 RID: 20663
			public MouseState State;
		}

		// Token: 0x02000591 RID: 1425
		private class KeyboardData
		{
			// Token: 0x040050B8 RID: 20664
			public KeyboardState State;
		}

		// Token: 0x02000592 RID: 1426
		private class JoystickData
		{
			// Token: 0x040050B9 RID: 20665
			public string Name;

			// Token: 0x040050BA RID: 20666
			public Guid Guid;

			// Token: 0x040050BB RID: 20667
			public JoystickState State;

			// Token: 0x040050BC RID: 20668
			public JoystickCapabilities Capabilities;

			// Token: 0x040050BD RID: 20669
			public readonly Dictionary<int, JoystickButton> ElementUsageToButton = new Dictionary<int, JoystickButton>();

			// Token: 0x040050BE RID: 20670
			public readonly Dictionary<IntPtr, JoystickHat> ElementToHat = new Dictionary<IntPtr, JoystickHat>(new IntPtrEqualityComparer());
		}

		// Token: 0x02000593 RID: 1427
		private class NativeMethods
		{
			// Token: 0x060045D4 RID: 17876
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDManagerCreate(IntPtr allocator, IntPtr options);

			// Token: 0x060045D5 RID: 17877
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDManagerRegisterDeviceMatchingCallback(IntPtr inIOHIDManagerRef, HIDInput.NativeMethods.IOHIDDeviceCallback inIOHIDDeviceCallback, IntPtr inContext);

			// Token: 0x060045D6 RID: 17878
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDManagerRegisterDeviceMatchingCallback(IntPtr inIOHIDManagerRef, IntPtr inIOHIDDeviceCallback, IntPtr inContext);

			// Token: 0x060045D7 RID: 17879
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDManagerRegisterDeviceRemovalCallback(IntPtr inIOHIDManagerRef, HIDInput.NativeMethods.IOHIDDeviceCallback inIOHIDDeviceCallback, IntPtr inContext);

			// Token: 0x060045D8 RID: 17880
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDManagerRegisterDeviceRemovalCallback(IntPtr inIOHIDManagerRef, IntPtr inIOHIDDeviceCallback, IntPtr inContext);

			// Token: 0x060045D9 RID: 17881
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDManagerScheduleWithRunLoop(IntPtr inIOHIDManagerRef, IntPtr inCFRunLoop, IntPtr inCFRunLoopMode);

			// Token: 0x060045DA RID: 17882
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDManagerUnscheduleFromRunLoop(IntPtr inIOHIDManagerRef, IntPtr inCFRunLoop, IntPtr inCFRunLoopMode);

			// Token: 0x060045DB RID: 17883
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDManagerSetDeviceMatching(IntPtr manager, IntPtr matching);

			// Token: 0x060045DC RID: 17884
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDManagerOpen(IntPtr manager, IntPtr options);

			// Token: 0x060045DD RID: 17885
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDDeviceOpen(IntPtr manager, IntPtr opts);

			// Token: 0x060045DE RID: 17886
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDDeviceGetProperty(IntPtr device, IntPtr key);

			// Token: 0x060045DF RID: 17887
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern bool IOHIDDeviceConformsTo(IntPtr inIOHIDDeviceRef, HIDInput.HIDPage inUsagePage, int inUsage);

			// Token: 0x060045E0 RID: 17888
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDDeviceCopyMatchingElements(IntPtr inIOHIDDeviceRef, IntPtr inMatchingCFDictRef, IntPtr inOptions);

			// Token: 0x060045E1 RID: 17889
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDDeviceRegisterInputValueCallback(IntPtr device, HIDInput.NativeMethods.IOHIDValueCallback callback, IntPtr context);

			// Token: 0x060045E2 RID: 17890
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDDeviceRegisterInputValueCallback(IntPtr device, IntPtr callback, IntPtr context);

			// Token: 0x060045E3 RID: 17891
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDDeviceScheduleWithRunLoop(IntPtr device, IntPtr inCFRunLoop, IntPtr inCFRunLoopMode);

			// Token: 0x060045E4 RID: 17892
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern void IOHIDDeviceUnscheduleFromRunLoop(IntPtr device, IntPtr inCFRunLoop, IntPtr inCFRunLoopMode);

			// Token: 0x060045E5 RID: 17893
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDValueGetElement(IntPtr value);

			// Token: 0x060045E6 RID: 17894
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDValueGetIntegerValue(IntPtr value);

			// Token: 0x060045E7 RID: 17895
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern double IOHIDValueGetScaledValue(IntPtr value, HIDInput.IOHIDValueScaleType type);

			// Token: 0x060045E8 RID: 17896
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern HIDInput.IOHIDElementType IOHIDElementGetType(IntPtr element);

			// Token: 0x060045E9 RID: 17897
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern int IOHIDElementGetUsage(IntPtr elem);

			// Token: 0x060045EA RID: 17898
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern HIDInput.HIDPage IOHIDElementGetUsagePage(IntPtr elem);

			// Token: 0x060045EB RID: 17899
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDElementGetLogicalMax(IntPtr element);

			// Token: 0x060045EC RID: 17900
			[DllImport("/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit")]
			public static extern IntPtr IOHIDElementGetLogicalMin(IntPtr element);

			// Token: 0x040050BF RID: 20671
			private const string hid = "/System/Library/Frameworks/IOKit.framework/Versions/Current/IOKit";

			// Token: 0x040050C0 RID: 20672
			public static readonly IntPtr IOHIDVendorIDKey = CF.CFSTR("VendorID");

			// Token: 0x040050C1 RID: 20673
			public static readonly IntPtr IOHIDVendorIDSourceKey = CF.CFSTR("VendorIDSource");

			// Token: 0x040050C2 RID: 20674
			public static readonly IntPtr IOHIDProductIDKey = CF.CFSTR("ProductID");

			// Token: 0x040050C3 RID: 20675
			public static readonly IntPtr IOHIDVersionNumberKey = CF.CFSTR("VersionNumber");

			// Token: 0x040050C4 RID: 20676
			public static readonly IntPtr IOHIDManufacturerKey = CF.CFSTR("Manufacturer");

			// Token: 0x040050C5 RID: 20677
			public static readonly IntPtr IOHIDProductKey = CF.CFSTR("Product");

			// Token: 0x040050C6 RID: 20678
			public static readonly IntPtr IOHIDDeviceUsageKey = CF.CFSTR("DeviceUsage");

			// Token: 0x040050C7 RID: 20679
			public static readonly IntPtr IOHIDDeviceUsagePageKey = CF.CFSTR("DeviceUsagePage");

			// Token: 0x040050C8 RID: 20680
			public static readonly IntPtr IOHIDDeviceUsagePairsKey = CF.CFSTR("DeviceUsagePairs");

			// Token: 0x02000594 RID: 1428
			// (Invoke) Token: 0x060045F0 RID: 17904
			public delegate void IOHIDDeviceCallback(IntPtr ctx, IntPtr res, IntPtr sender, IntPtr device);

			// Token: 0x02000595 RID: 1429
			// (Invoke) Token: 0x060045F4 RID: 17908
			public delegate void IOHIDValueCallback(IntPtr ctx, IntPtr res, IntPtr sender, IntPtr val);
		}

		// Token: 0x02000596 RID: 1430
		private enum IOHIDElementType
		{
			// Token: 0x040050CA RID: 20682
			Input_Misc = 1,
			// Token: 0x040050CB RID: 20683
			Input_Button,
			// Token: 0x040050CC RID: 20684
			Input_Axis,
			// Token: 0x040050CD RID: 20685
			Input_ScanCodes,
			// Token: 0x040050CE RID: 20686
			Output = 129,
			// Token: 0x040050CF RID: 20687
			Feature = 257,
			// Token: 0x040050D0 RID: 20688
			Collection = 513
		}

		// Token: 0x02000597 RID: 1431
		private enum IOHIDValueScaleType
		{
			// Token: 0x040050D2 RID: 20690
			Physical,
			// Token: 0x040050D3 RID: 20691
			Calibrated
		}

		// Token: 0x02000598 RID: 1432
		private enum HIDPage
		{
			// Token: 0x040050D5 RID: 20693
			Undefined,
			// Token: 0x040050D6 RID: 20694
			GenericDesktop,
			// Token: 0x040050D7 RID: 20695
			Simulation,
			// Token: 0x040050D8 RID: 20696
			VR,
			// Token: 0x040050D9 RID: 20697
			Sport,
			// Token: 0x040050DA RID: 20698
			Game,
			// Token: 0x040050DB RID: 20699
			KeyboardOrKeypad = 7,
			// Token: 0x040050DC RID: 20700
			LEDs,
			// Token: 0x040050DD RID: 20701
			Button,
			// Token: 0x040050DE RID: 20702
			Ordinal,
			// Token: 0x040050DF RID: 20703
			Telephony,
			// Token: 0x040050E0 RID: 20704
			Consumer,
			// Token: 0x040050E1 RID: 20705
			Digitizer,
			// Token: 0x040050E2 RID: 20706
			PID = 15,
			// Token: 0x040050E3 RID: 20707
			Unicode,
			// Token: 0x040050E4 RID: 20708
			AlphanumericDisplay = 20,
			// Token: 0x040050E5 RID: 20709
			PowerDevice = 132,
			// Token: 0x040050E6 RID: 20710
			BatterySystem,
			// Token: 0x040050E7 RID: 20711
			BarCodeScanner = 140,
			// Token: 0x040050E8 RID: 20712
			WeighingDevice,
			// Token: 0x040050E9 RID: 20713
			Scale = 141,
			// Token: 0x040050EA RID: 20714
			MagneticStripeReader,
			// Token: 0x040050EB RID: 20715
			CameraControl = 144,
			// Token: 0x040050EC RID: 20716
			Arcade,
			// Token: 0x040050ED RID: 20717
			VendorDefinedStart = 65280
		}

		// Token: 0x02000599 RID: 1433
		private enum HIDUsageCD
		{
			// Token: 0x040050EF RID: 20719
			ACPan = 568
		}

		// Token: 0x0200059A RID: 1434
		private enum HIDUsageGD
		{
			// Token: 0x040050F1 RID: 20721
			Pointer = 1,
			// Token: 0x040050F2 RID: 20722
			Mouse,
			// Token: 0x040050F3 RID: 20723
			Joystick = 4,
			// Token: 0x040050F4 RID: 20724
			GamePad,
			// Token: 0x040050F5 RID: 20725
			Keyboard,
			// Token: 0x040050F6 RID: 20726
			Keypad,
			// Token: 0x040050F7 RID: 20727
			MultiAxisController,
			// Token: 0x040050F8 RID: 20728
			X = 48,
			// Token: 0x040050F9 RID: 20729
			Y,
			// Token: 0x040050FA RID: 20730
			Z,
			// Token: 0x040050FB RID: 20731
			Rx,
			// Token: 0x040050FC RID: 20732
			Ry,
			// Token: 0x040050FD RID: 20733
			Rz,
			// Token: 0x040050FE RID: 20734
			Slider,
			// Token: 0x040050FF RID: 20735
			Dial,
			// Token: 0x04005100 RID: 20736
			Wheel,
			// Token: 0x04005101 RID: 20737
			Hatswitch,
			// Token: 0x04005102 RID: 20738
			CountedBuffer,
			// Token: 0x04005103 RID: 20739
			ByteCount,
			// Token: 0x04005104 RID: 20740
			MotionWakeup,
			// Token: 0x04005105 RID: 20741
			Start,
			// Token: 0x04005106 RID: 20742
			Select,
			// Token: 0x04005107 RID: 20743
			Vx = 64,
			// Token: 0x04005108 RID: 20744
			Vy,
			// Token: 0x04005109 RID: 20745
			Vz,
			// Token: 0x0400510A RID: 20746
			Vbrx,
			// Token: 0x0400510B RID: 20747
			Vbry,
			// Token: 0x0400510C RID: 20748
			Vbrz,
			// Token: 0x0400510D RID: 20749
			Vno,
			// Token: 0x0400510E RID: 20750
			SystemControl = 128,
			// Token: 0x0400510F RID: 20751
			SystemPowerDown,
			// Token: 0x04005110 RID: 20752
			SystemSleep,
			// Token: 0x04005111 RID: 20753
			SystemWakeUp,
			// Token: 0x04005112 RID: 20754
			SystemContextMenu,
			// Token: 0x04005113 RID: 20755
			SystemMainMenu,
			// Token: 0x04005114 RID: 20756
			SystemAppMenu,
			// Token: 0x04005115 RID: 20757
			SystemMenuHelp,
			// Token: 0x04005116 RID: 20758
			SystemMenuExit,
			// Token: 0x04005117 RID: 20759
			SystemMenu,
			// Token: 0x04005118 RID: 20760
			SystemMenuRight,
			// Token: 0x04005119 RID: 20761
			SystemMenuLeft,
			// Token: 0x0400511A RID: 20762
			SystemMenuUp,
			// Token: 0x0400511B RID: 20763
			SystemMenuDown,
			// Token: 0x0400511C RID: 20764
			DPadUp = 144,
			// Token: 0x0400511D RID: 20765
			DPadDown,
			// Token: 0x0400511E RID: 20766
			DPadRight,
			// Token: 0x0400511F RID: 20767
			DPadLeft,
			// Token: 0x04005120 RID: 20768
			Reserved = 65535
		}

		// Token: 0x0200059B RID: 1435
		private enum HIDUsageSim
		{
			// Token: 0x04005122 RID: 20770
			FlightSimulationDevice = 1,
			// Token: 0x04005123 RID: 20771
			AutomobileSimulationDevice,
			// Token: 0x04005124 RID: 20772
			TankSimulationDevice,
			// Token: 0x04005125 RID: 20773
			SpaceshipSimulationDevice,
			// Token: 0x04005126 RID: 20774
			SubmarineSimulationDevice,
			// Token: 0x04005127 RID: 20775
			SailingSimulationDevice,
			// Token: 0x04005128 RID: 20776
			MotorcycleSimulationDevice,
			// Token: 0x04005129 RID: 20777
			SportsSimulationDevice,
			// Token: 0x0400512A RID: 20778
			AirplaneSimulationDevice,
			// Token: 0x0400512B RID: 20779
			HelicopterSimulationDevice,
			// Token: 0x0400512C RID: 20780
			MagicCarpetSimulationDevice,
			// Token: 0x0400512D RID: 20781
			BicycleSimulationDevice,
			// Token: 0x0400512E RID: 20782
			FlightControlStick = 32,
			// Token: 0x0400512F RID: 20783
			FlightStick,
			// Token: 0x04005130 RID: 20784
			CyclicControl,
			// Token: 0x04005131 RID: 20785
			CyclicTrim,
			// Token: 0x04005132 RID: 20786
			FlightYoke,
			// Token: 0x04005133 RID: 20787
			TrackControl,
			// Token: 0x04005134 RID: 20788
			Aileron = 176,
			// Token: 0x04005135 RID: 20789
			AileronTrim,
			// Token: 0x04005136 RID: 20790
			AntiTorqueControl,
			// Token: 0x04005137 RID: 20791
			AutopilotEnable,
			// Token: 0x04005138 RID: 20792
			ChaffRelease,
			// Token: 0x04005139 RID: 20793
			CollectiveControl,
			// Token: 0x0400513A RID: 20794
			DiveBrake,
			// Token: 0x0400513B RID: 20795
			ElectronicCountermeasures,
			// Token: 0x0400513C RID: 20796
			Elevator,
			// Token: 0x0400513D RID: 20797
			ElevatorTrim,
			// Token: 0x0400513E RID: 20798
			Rudder,
			// Token: 0x0400513F RID: 20799
			Throttle,
			// Token: 0x04005140 RID: 20800
			FlightCommunications,
			// Token: 0x04005141 RID: 20801
			FlareRelease,
			// Token: 0x04005142 RID: 20802
			LandingGear,
			// Token: 0x04005143 RID: 20803
			ToeBrake,
			// Token: 0x04005144 RID: 20804
			Trigger,
			// Token: 0x04005145 RID: 20805
			WeaponsArm,
			// Token: 0x04005146 RID: 20806
			Weapons,
			// Token: 0x04005147 RID: 20807
			WingFlaps,
			// Token: 0x04005148 RID: 20808
			Accelerator,
			// Token: 0x04005149 RID: 20809
			Brake,
			// Token: 0x0400514A RID: 20810
			Clutch,
			// Token: 0x0400514B RID: 20811
			Shifter,
			// Token: 0x0400514C RID: 20812
			Steering,
			// Token: 0x0400514D RID: 20813
			TurretDirection,
			// Token: 0x0400514E RID: 20814
			BarrelElevation,
			// Token: 0x0400514F RID: 20815
			DivePlane,
			// Token: 0x04005150 RID: 20816
			Ballast,
			// Token: 0x04005151 RID: 20817
			BicycleCrank,
			// Token: 0x04005152 RID: 20818
			HandleBars,
			// Token: 0x04005153 RID: 20819
			FrontBrake,
			// Token: 0x04005154 RID: 20820
			RearBrake,
			// Token: 0x04005155 RID: 20821
			Reserved = 65535
		}

		// Token: 0x0200059C RID: 1436
		private enum HIDButton
		{
			// Token: 0x04005157 RID: 20823
			Button_1 = 1,
			// Token: 0x04005158 RID: 20824
			Button_2,
			// Token: 0x04005159 RID: 20825
			Button_3,
			// Token: 0x0400515A RID: 20826
			Button_4,
			// Token: 0x0400515B RID: 20827
			Button_65535 = 65535
		}

		// Token: 0x0200059D RID: 1437
		private enum HIDKey
		{
			// Token: 0x0400515D RID: 20829
			ErrorRollOver = 1,
			// Token: 0x0400515E RID: 20830
			POSTFail,
			// Token: 0x0400515F RID: 20831
			ErrorUndefined,
			// Token: 0x04005160 RID: 20832
			A,
			// Token: 0x04005161 RID: 20833
			B,
			// Token: 0x04005162 RID: 20834
			C,
			// Token: 0x04005163 RID: 20835
			D,
			// Token: 0x04005164 RID: 20836
			E,
			// Token: 0x04005165 RID: 20837
			F,
			// Token: 0x04005166 RID: 20838
			G,
			// Token: 0x04005167 RID: 20839
			H,
			// Token: 0x04005168 RID: 20840
			I,
			// Token: 0x04005169 RID: 20841
			J,
			// Token: 0x0400516A RID: 20842
			K,
			// Token: 0x0400516B RID: 20843
			L,
			// Token: 0x0400516C RID: 20844
			M,
			// Token: 0x0400516D RID: 20845
			N,
			// Token: 0x0400516E RID: 20846
			O,
			// Token: 0x0400516F RID: 20847
			P,
			// Token: 0x04005170 RID: 20848
			Q,
			// Token: 0x04005171 RID: 20849
			R,
			// Token: 0x04005172 RID: 20850
			S,
			// Token: 0x04005173 RID: 20851
			T,
			// Token: 0x04005174 RID: 20852
			U,
			// Token: 0x04005175 RID: 20853
			V,
			// Token: 0x04005176 RID: 20854
			W,
			// Token: 0x04005177 RID: 20855
			X,
			// Token: 0x04005178 RID: 20856
			Y,
			// Token: 0x04005179 RID: 20857
			Z,
			// Token: 0x0400517A RID: 20858
			Number1,
			// Token: 0x0400517B RID: 20859
			Number2,
			// Token: 0x0400517C RID: 20860
			Number3,
			// Token: 0x0400517D RID: 20861
			Number4,
			// Token: 0x0400517E RID: 20862
			Number5,
			// Token: 0x0400517F RID: 20863
			Number6,
			// Token: 0x04005180 RID: 20864
			Number7,
			// Token: 0x04005181 RID: 20865
			Number8,
			// Token: 0x04005182 RID: 20866
			Number9,
			// Token: 0x04005183 RID: 20867
			Number0,
			// Token: 0x04005184 RID: 20868
			ReturnOrEnter,
			// Token: 0x04005185 RID: 20869
			Escape,
			// Token: 0x04005186 RID: 20870
			DeleteOrBackspace,
			// Token: 0x04005187 RID: 20871
			Tab,
			// Token: 0x04005188 RID: 20872
			Spacebar,
			// Token: 0x04005189 RID: 20873
			Hyphen,
			// Token: 0x0400518A RID: 20874
			EqualSign,
			// Token: 0x0400518B RID: 20875
			OpenBracket,
			// Token: 0x0400518C RID: 20876
			CloseBracket,
			// Token: 0x0400518D RID: 20877
			Backslash,
			// Token: 0x0400518E RID: 20878
			NonUSPound,
			// Token: 0x0400518F RID: 20879
			Semicolon,
			// Token: 0x04005190 RID: 20880
			Quote,
			// Token: 0x04005191 RID: 20881
			GraveAccentAndTilde,
			// Token: 0x04005192 RID: 20882
			Comma,
			// Token: 0x04005193 RID: 20883
			Period,
			// Token: 0x04005194 RID: 20884
			Slash,
			// Token: 0x04005195 RID: 20885
			CapsLock,
			// Token: 0x04005196 RID: 20886
			F1,
			// Token: 0x04005197 RID: 20887
			F2,
			// Token: 0x04005198 RID: 20888
			F3,
			// Token: 0x04005199 RID: 20889
			F4,
			// Token: 0x0400519A RID: 20890
			F5,
			// Token: 0x0400519B RID: 20891
			F6,
			// Token: 0x0400519C RID: 20892
			F7,
			// Token: 0x0400519D RID: 20893
			F8,
			// Token: 0x0400519E RID: 20894
			F9,
			// Token: 0x0400519F RID: 20895
			F10,
			// Token: 0x040051A0 RID: 20896
			F11,
			// Token: 0x040051A1 RID: 20897
			F12,
			// Token: 0x040051A2 RID: 20898
			PrintScreen,
			// Token: 0x040051A3 RID: 20899
			ScrollLock,
			// Token: 0x040051A4 RID: 20900
			Pause,
			// Token: 0x040051A5 RID: 20901
			Insert,
			// Token: 0x040051A6 RID: 20902
			Home,
			// Token: 0x040051A7 RID: 20903
			PageUp,
			// Token: 0x040051A8 RID: 20904
			DeleteForward,
			// Token: 0x040051A9 RID: 20905
			End,
			// Token: 0x040051AA RID: 20906
			PageDown,
			// Token: 0x040051AB RID: 20907
			RightArrow,
			// Token: 0x040051AC RID: 20908
			LeftArrow,
			// Token: 0x040051AD RID: 20909
			DownArrow,
			// Token: 0x040051AE RID: 20910
			UpArrow,
			// Token: 0x040051AF RID: 20911
			KeypadNumLock,
			// Token: 0x040051B0 RID: 20912
			KeypadSlash,
			// Token: 0x040051B1 RID: 20913
			KeypadAsterisk,
			// Token: 0x040051B2 RID: 20914
			KeypadHyphen,
			// Token: 0x040051B3 RID: 20915
			KeypadPlus,
			// Token: 0x040051B4 RID: 20916
			KeypadEnter,
			// Token: 0x040051B5 RID: 20917
			Keypad1,
			// Token: 0x040051B6 RID: 20918
			Keypad2,
			// Token: 0x040051B7 RID: 20919
			Keypad3,
			// Token: 0x040051B8 RID: 20920
			Keypad4,
			// Token: 0x040051B9 RID: 20921
			Keypad5,
			// Token: 0x040051BA RID: 20922
			Keypad6,
			// Token: 0x040051BB RID: 20923
			Keypad7,
			// Token: 0x040051BC RID: 20924
			Keypad8,
			// Token: 0x040051BD RID: 20925
			Keypad9,
			// Token: 0x040051BE RID: 20926
			Keypad0,
			// Token: 0x040051BF RID: 20927
			KeypadPeriod,
			// Token: 0x040051C0 RID: 20928
			NonUSBackslash,
			// Token: 0x040051C1 RID: 20929
			Application,
			// Token: 0x040051C2 RID: 20930
			Power,
			// Token: 0x040051C3 RID: 20931
			KeypadEqualSign,
			// Token: 0x040051C4 RID: 20932
			F13,
			// Token: 0x040051C5 RID: 20933
			F14,
			// Token: 0x040051C6 RID: 20934
			F15,
			// Token: 0x040051C7 RID: 20935
			F16,
			// Token: 0x040051C8 RID: 20936
			F17,
			// Token: 0x040051C9 RID: 20937
			F18,
			// Token: 0x040051CA RID: 20938
			F19,
			// Token: 0x040051CB RID: 20939
			F20,
			// Token: 0x040051CC RID: 20940
			F21,
			// Token: 0x040051CD RID: 20941
			F22,
			// Token: 0x040051CE RID: 20942
			F23,
			// Token: 0x040051CF RID: 20943
			F24,
			// Token: 0x040051D0 RID: 20944
			Execute,
			// Token: 0x040051D1 RID: 20945
			Help,
			// Token: 0x040051D2 RID: 20946
			Menu,
			// Token: 0x040051D3 RID: 20947
			Select,
			// Token: 0x040051D4 RID: 20948
			Stop,
			// Token: 0x040051D5 RID: 20949
			Again,
			// Token: 0x040051D6 RID: 20950
			Undo,
			// Token: 0x040051D7 RID: 20951
			Cut,
			// Token: 0x040051D8 RID: 20952
			Copy,
			// Token: 0x040051D9 RID: 20953
			Paste,
			// Token: 0x040051DA RID: 20954
			Find,
			// Token: 0x040051DB RID: 20955
			Mute,
			// Token: 0x040051DC RID: 20956
			VolumeUp,
			// Token: 0x040051DD RID: 20957
			VolumeDown,
			// Token: 0x040051DE RID: 20958
			LockingCapsLock,
			// Token: 0x040051DF RID: 20959
			LockingNumLock,
			// Token: 0x040051E0 RID: 20960
			LockingScrollLock,
			// Token: 0x040051E1 RID: 20961
			KeypadComma,
			// Token: 0x040051E2 RID: 20962
			KeypadEqualSignAS400,
			// Token: 0x040051E3 RID: 20963
			International1,
			// Token: 0x040051E4 RID: 20964
			International2,
			// Token: 0x040051E5 RID: 20965
			International3,
			// Token: 0x040051E6 RID: 20966
			International4,
			// Token: 0x040051E7 RID: 20967
			International5,
			// Token: 0x040051E8 RID: 20968
			International6,
			// Token: 0x040051E9 RID: 20969
			International7,
			// Token: 0x040051EA RID: 20970
			International8,
			// Token: 0x040051EB RID: 20971
			International9,
			// Token: 0x040051EC RID: 20972
			LANG1,
			// Token: 0x040051ED RID: 20973
			LANG2,
			// Token: 0x040051EE RID: 20974
			LANG3,
			// Token: 0x040051EF RID: 20975
			LANG4,
			// Token: 0x040051F0 RID: 20976
			LANG5,
			// Token: 0x040051F1 RID: 20977
			LANG6,
			// Token: 0x040051F2 RID: 20978
			LANG7,
			// Token: 0x040051F3 RID: 20979
			LANG8,
			// Token: 0x040051F4 RID: 20980
			LANG9,
			// Token: 0x040051F5 RID: 20981
			AlternateErase,
			// Token: 0x040051F6 RID: 20982
			SysReqOrAttention,
			// Token: 0x040051F7 RID: 20983
			Cancel,
			// Token: 0x040051F8 RID: 20984
			Clear,
			// Token: 0x040051F9 RID: 20985
			Prior,
			// Token: 0x040051FA RID: 20986
			Return,
			// Token: 0x040051FB RID: 20987
			Separator,
			// Token: 0x040051FC RID: 20988
			Out,
			// Token: 0x040051FD RID: 20989
			Oper,
			// Token: 0x040051FE RID: 20990
			ClearOrAgain,
			// Token: 0x040051FF RID: 20991
			CrSelOrProps,
			// Token: 0x04005200 RID: 20992
			ExSel,
			// Token: 0x04005201 RID: 20993
			LeftControl = 224,
			// Token: 0x04005202 RID: 20994
			LeftShift,
			// Token: 0x04005203 RID: 20995
			LeftAlt,
			// Token: 0x04005204 RID: 20996
			LeftGUI,
			// Token: 0x04005205 RID: 20997
			RightControl,
			// Token: 0x04005206 RID: 20998
			RightShift,
			// Token: 0x04005207 RID: 20999
			RightAlt,
			// Token: 0x04005208 RID: 21000
			RightGUI
		}
	}
}
