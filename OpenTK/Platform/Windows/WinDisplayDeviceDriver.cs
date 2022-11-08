using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200007F RID: 127
	internal sealed class WinDisplayDeviceDriver : DisplayDeviceBase
	{
		// Token: 0x060007A1 RID: 1953 RVA: 0x0001A450 File Offset: 0x00018650
		public WinDisplayDeviceDriver()
		{
			this.RefreshDisplayDevices();
			SystemEvents.DisplaySettingsChanged += this.HandleDisplaySettingsChanged;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x0001A47C File Offset: 0x0001867C
		public sealed override bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution)
		{
			DeviceMode deviceMode = null;
			if (resolution != null)
			{
				deviceMode = new DeviceMode();
				deviceMode.PelsWidth = resolution.Width;
				deviceMode.PelsHeight = resolution.Height;
				deviceMode.BitsPerPel = resolution.BitsPerPixel;
				deviceMode.DisplayFrequency = (int)resolution.RefreshRate;
				deviceMode.Fields = 6029312;
			}
			return 0 == Functions.ChangeDisplaySettingsEx((string)device.Id, deviceMode, IntPtr.Zero, ChangeDisplaySettingsEnum.Fullscreen, IntPtr.Zero);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0001A4F8 File Offset: 0x000186F8
		public sealed override bool TryRestoreResolution(DisplayDevice device)
		{
			return this.TryChangeResolution(device, null);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0001A504 File Offset: 0x00018704
		public void RefreshDisplayDevices()
		{
			lock (this.display_lock)
			{
				DisplayDevice[] array = this.AvailableDevices.ToArray();
				this.AvailableDevices.Clear();
				DisplayResolution displayResolution = null;
				List<DisplayResolution> list = new List<DisplayResolution>();
				bool flag = false;
				int num = 0;
				WindowsDisplayDevice windowsDisplayDevice = new WindowsDisplayDevice();
				new WindowsDisplayDevice();
				while (Functions.EnumDisplayDevices(null, num++, windowsDisplayDevice, 0))
				{
					if ((windowsDisplayDevice.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop) != DisplayDeviceStateFlags.None)
					{
						DeviceMode deviceMode = new DeviceMode();
						if (Functions.EnumDisplaySettingsEx(windowsDisplayDevice.DeviceName.ToString(), DisplayModeSettingsEnum.CurrentSettings, deviceMode, 0) || Functions.EnumDisplaySettingsEx(windowsDisplayDevice.DeviceName.ToString(), DisplayModeSettingsEnum.RegistrySettings, deviceMode, 0))
						{
							WinDisplayDeviceDriver.VerifyMode(windowsDisplayDevice, deviceMode);
							float scale = this.GetScale(ref deviceMode);
							displayResolution = new DisplayResolution((int)((float)deviceMode.Position.X / scale), (int)((float)deviceMode.Position.Y / scale), (int)((float)deviceMode.PelsWidth / scale), (int)((float)deviceMode.PelsHeight / scale), deviceMode.BitsPerPel, (float)deviceMode.DisplayFrequency);
							flag = ((windowsDisplayDevice.StateFlags & DisplayDeviceStateFlags.PrimaryDevice) != DisplayDeviceStateFlags.None);
						}
						list.Clear();
						int num2 = 0;
						while (Functions.EnumDisplaySettingsEx(windowsDisplayDevice.DeviceName.ToString(), num2++, deviceMode, 0))
						{
							WinDisplayDeviceDriver.VerifyMode(windowsDisplayDevice, deviceMode);
							float scale2 = this.GetScale(ref deviceMode);
							DisplayResolution item = new DisplayResolution((int)((float)deviceMode.Position.X / scale2), (int)((float)deviceMode.Position.Y / scale2), (int)((float)deviceMode.PelsWidth / scale2), (int)((float)deviceMode.PelsHeight / scale2), deviceMode.BitsPerPel, (float)deviceMode.DisplayFrequency);
							list.Add(item);
						}
						DisplayDevice displayDevice = new DisplayDevice(displayResolution, flag, list, displayResolution.Bounds, windowsDisplayDevice.DeviceName);
						foreach (DisplayDevice displayDevice2 in array)
						{
							if ((string)displayDevice2.Id == (string)displayDevice.Id)
							{
								displayDevice.OriginalResolution = displayDevice2.OriginalResolution;
							}
						}
						this.AvailableDevices.Add(displayDevice);
						if (flag)
						{
							this.Primary = displayDevice;
						}
					}
				}
			}
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0001A758 File Offset: 0x00018958
		private float GetScale(ref DeviceMode monitor_mode)
		{
			float result = 1f;
			if ((monitor_mode.Fields & 131072) != 0)
			{
				result = (float)monitor_mode.LogPixels / 96f;
			}
			return result;
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0001A78C File Offset: 0x0001898C
		private static void VerifyMode(WindowsDisplayDevice device, DeviceMode mode)
		{
			if (mode.BitsPerPel == 0)
			{
				mode.BitsPerPel = 32;
			}
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0001A7A0 File Offset: 0x000189A0
		private void HandleDisplaySettingsChanged(object sender, EventArgs e)
		{
			this.RefreshDisplayDevices();
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0001A7A8 File Offset: 0x000189A8
		~WinDisplayDeviceDriver()
		{
			SystemEvents.DisplaySettingsChanged -= this.HandleDisplaySettingsChanged;
		}

		// Token: 0x040002B0 RID: 688
		private readonly object display_lock = new object();
	}
}
