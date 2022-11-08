using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200012E RID: 302
	internal sealed class X11DisplayDevice : DisplayDeviceBase
	{
		// Token: 0x06000A9E RID: 2718 RVA: 0x00020F20 File Offset: 0x0001F120
		public X11DisplayDevice()
		{
			this.RefreshDisplayDevices();
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00020F5C File Offset: 0x0001F15C
		private void RefreshDisplayDevices()
		{
			using (new XLock(API.DefaultDisplay))
			{
				List<DisplayDevice> list = new List<DisplayDevice>();
				this.xinerama_supported = false;
				try
				{
					this.xinerama_supported = this.QueryXinerama(list);
				}
				catch
				{
				}
				if (!this.xinerama_supported)
				{
					for (int i = 0; i < API.ScreenCount; i++)
					{
						DisplayDevice displayDevice = new DisplayDevice();
						displayDevice.IsPrimary = (i == Functions.XDefaultScreen(API.DefaultDisplay));
						list.Add(displayDevice);
						this.deviceToScreen.Add(displayDevice, i);
					}
				}
				try
				{
					this.xrandr_supported = this.QueryXRandR(list);
				}
				catch
				{
				}
				if (!this.xrandr_supported)
				{
					try
					{
						this.xf86_supported = this.QueryXF86(list);
					}
					catch
					{
					}
					bool flag = this.xf86_supported;
				}
				this.AvailableDevices.Clear();
				this.AvailableDevices.AddRange(list);
				this.Primary = X11DisplayDevice.FindDefaultDevice(list);
			}
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00021074 File Offset: 0x0001F274
		private static DisplayDevice FindDefaultDevice(IEnumerable<DisplayDevice> devices)
		{
			foreach (DisplayDevice displayDevice in devices)
			{
				if (displayDevice.IsPrimary)
				{
					return displayDevice;
				}
			}
			throw new InvalidOperationException("No primary display found. Please file a bug at http://www.opentk.com");
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x000210D0 File Offset: 0x0001F2D0
		private bool QueryXinerama(List<DisplayDevice> devices)
		{
			int num;
			int num2;
			if (X11DisplayDevice.NativeMethods.XineramaQueryExtension(API.DefaultDisplay, out num, out num2) && X11DisplayDevice.NativeMethods.XineramaIsActive(API.DefaultDisplay))
			{
				IList<X11DisplayDevice.XineramaScreenInfo> list = X11DisplayDevice.NativeMethods.XineramaQueryScreens(API.DefaultDisplay);
				bool flag = true;
				foreach (X11DisplayDevice.XineramaScreenInfo xineramaScreenInfo in list)
				{
					DisplayDevice displayDevice = new DisplayDevice();
					displayDevice.Bounds = new Rectangle((int)xineramaScreenInfo.X, (int)xineramaScreenInfo.Y, (int)xineramaScreenInfo.Width, (int)xineramaScreenInfo.Height);
					if (flag)
					{
						displayDevice.IsPrimary = true;
						flag = false;
					}
					devices.Add(displayDevice);
					this.deviceToScreen.Add(displayDevice, 0);
				}
			}
			return devices.Count > 0;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x000211A4 File Offset: 0x0001F3A4
		private bool QueryXRandR(List<DisplayDevice> devices)
		{
			foreach (DisplayDevice displayDevice in devices)
			{
				int num = this.deviceToScreen[displayDevice];
				IntPtr item;
				Functions.XRRTimes(API.DefaultDisplay, num, out item);
				this.lastConfigUpdate.Add(item);
				List<DisplayResolution> list = new List<DisplayResolution>();
				this.screenResolutionToIndex.Add(new Dictionary<DisplayResolution, int>());
				int[] array = X11DisplayDevice.FindAvailableDepths(num);
				int num2 = 0;
				foreach (XRRScreenSize xrrscreenSize in X11DisplayDevice.FindAvailableResolutions(num))
				{
					if (xrrscreenSize.Width != 0 && xrrscreenSize.Height != 0)
					{
						short[] array3 = Functions.XRRRates(API.DefaultDisplay, num, num2);
						foreach (short num3 in array3)
						{
							if (num3 != 0 || array3.Length == 1)
							{
								foreach (int bitsPerPixel in array)
								{
									list.Add(new DisplayResolution(0, 0, xrrscreenSize.Width, xrrscreenSize.Height, bitsPerPixel, (float)num3));
								}
							}
						}
						foreach (int bitsPerPixel2 in array)
						{
							DisplayResolution key = new DisplayResolution(0, 0, xrrscreenSize.Width, xrrscreenSize.Height, bitsPerPixel2, 0f);
							if (!this.screenResolutionToIndex[num].ContainsKey(key))
							{
								this.screenResolutionToIndex[num].Add(key, num2);
							}
						}
						num2++;
					}
				}
				float refreshRate = X11DisplayDevice.FindCurrentRefreshRate(num);
				int bitsPerPixel3 = X11DisplayDevice.FindCurrentDepth(num);
				IntPtr config = Functions.XRRGetScreenInfo(API.DefaultDisplay, Functions.XRootWindow(API.DefaultDisplay, num));
				ushort num5;
				int num4 = (int)Functions.XRRConfigCurrentConfiguration(config, out num5);
				if (displayDevice.Bounds == Rectangle.Empty)
				{
					int num6 = num4 * array.Length;
					if (num6 >= list.Count)
					{
						num6 = num4;
					}
					DisplayResolution displayResolution = list[num6];
					displayDevice.Bounds = new Rectangle(0, 0, displayResolution.Width, displayResolution.Height);
				}
				displayDevice.BitsPerPixel = bitsPerPixel3;
				displayDevice.RefreshRate = refreshRate;
				displayDevice.AvailableResolutions = list;
				this.deviceToDefaultResolution.Add(displayDevice, num4);
			}
			return true;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0002141C File Offset: 0x0001F61C
		private bool QueryXF86(List<DisplayDevice> devices)
		{
			try
			{
				int num;
				int num2;
				if (!API.XF86VidModeQueryVersion(API.DefaultDisplay, out num, out num2))
				{
					return false;
				}
			}
			catch (DllNotFoundException)
			{
				return false;
			}
			int num3 = 0;
			foreach (DisplayDevice displayDevice in devices)
			{
				int num4;
				IntPtr source;
				API.XF86VidModeGetAllModeLines(API.DefaultDisplay, num3, out num4, out source);
				IntPtr[] array = new IntPtr[num4];
				Marshal.Copy(source, array, 0, num4);
				API.XF86VidModeModeInfo xf86VidModeModeInfo = default(API.XF86VidModeModeInfo);
				int x;
				int y;
				API.XF86VidModeGetViewPort(API.DefaultDisplay, num3, out x, out y);
				List<DisplayResolution> list = new List<DisplayResolution>();
				for (int i = 0; i < num4; i++)
				{
					xf86VidModeModeInfo = (API.XF86VidModeModeInfo)Marshal.PtrToStructure(array[i], typeof(API.XF86VidModeModeInfo));
					list.Add(new DisplayResolution(x, y, (int)xf86VidModeModeInfo.hdisplay, (int)xf86VidModeModeInfo.vdisplay, 24, (float)xf86VidModeModeInfo.dotclock * 1000f / (float)(xf86VidModeModeInfo.vtotal * xf86VidModeModeInfo.htotal)));
				}
				displayDevice.AvailableResolutions = list;
				int num5;
				API.XF86VidModeModeLine xf86VidModeModeLine;
				API.XF86VidModeGetModeLine(API.DefaultDisplay, num3, out num5, out xf86VidModeModeLine);
				displayDevice.Bounds = new Rectangle(x, y, (int)xf86VidModeModeLine.hdisplay, (int)((xf86VidModeModeLine.vdisplay == 0) ? xf86VidModeModeLine.vsyncstart : xf86VidModeModeLine.vdisplay));
				displayDevice.BitsPerPixel = X11DisplayDevice.FindCurrentDepth(num3);
				displayDevice.RefreshRate = (float)num5 * 1000f / (float)(xf86VidModeModeLine.vtotal * xf86VidModeModeLine.htotal);
				num3++;
			}
			return true;
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x000215E8 File Offset: 0x0001F7E8
		private static int[] FindAvailableDepths(int screen)
		{
			return Functions.XListDepths(API.DefaultDisplay, screen);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x000215F8 File Offset: 0x0001F7F8
		private static XRRScreenSize[] FindAvailableResolutions(int screen)
		{
			XRRScreenSize[] array = Functions.XRRSizes(API.DefaultDisplay, screen);
			if (array == null)
			{
				throw new NotSupportedException("XRandR extensions not available.");
			}
			return array;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00021624 File Offset: 0x0001F824
		private static float FindCurrentRefreshRate(int screen)
		{
			IntPtr config = Functions.XRRGetScreenInfo(API.DefaultDisplay, Functions.XRootWindow(API.DefaultDisplay, screen));
			ushort num = 0;
			Functions.XRRConfigCurrentConfiguration(config, out num);
			short num2 = Functions.XRRConfigCurrentRate(config);
			Functions.XRRFreeScreenConfigInfo(config);
			return (float)num2;
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00021664 File Offset: 0x0001F864
		private static int FindCurrentDepth(int screen)
		{
			return (int)Functions.XDefaultDepth(API.DefaultDisplay, screen);
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00021674 File Offset: 0x0001F874
		private bool ChangeResolutionXRandR(DisplayDevice device, DisplayResolution resolution)
		{
			bool result;
			using (new XLock(API.DefaultDisplay))
			{
				int num = this.deviceToScreen[device];
				IntPtr draw = Functions.XRootWindow(API.DefaultDisplay, num);
				IntPtr config = Functions.XRRGetScreenInfo(API.DefaultDisplay, draw);
				ushort rotation;
				Functions.XRRConfigCurrentConfiguration(config, out rotation);
				int size_index;
				if (resolution != null)
				{
					size_index = this.screenResolutionToIndex[num][new DisplayResolution(0, 0, resolution.Width, resolution.Height, resolution.BitsPerPixel, 0f)];
				}
				else
				{
					size_index = this.deviceToDefaultResolution[device];
				}
				short num2 = (short)((resolution != null) ? resolution.RefreshRate : 0f);
				int num3;
				if (num2 > 0)
				{
					num3 = Functions.XRRSetScreenConfigAndRate(API.DefaultDisplay, config, draw, size_index, rotation, num2, IntPtr.Zero);
				}
				else
				{
					num3 = Functions.XRRSetScreenConfig(API.DefaultDisplay, config, draw, size_index, rotation, IntPtr.Zero);
				}
				result = (num3 == 0);
			}
			return result;
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00021784 File Offset: 0x0001F984
		private static bool ChangeResolutionXF86(DisplayDevice device, DisplayResolution resolution)
		{
			return false;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x00021788 File Offset: 0x0001F988
		public sealed override bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution)
		{
			if (this.xrandr_supported)
			{
				return this.ChangeResolutionXRandR(device, resolution);
			}
			return this.xf86_supported && X11DisplayDevice.ChangeResolutionXF86(device, resolution);
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x000217AC File Offset: 0x0001F9AC
		public sealed override bool TryRestoreResolution(DisplayDevice device)
		{
			return this.TryChangeResolution(device, null);
		}

		// Token: 0x04000BF2 RID: 3058
		private readonly List<Dictionary<DisplayResolution, int>> screenResolutionToIndex = new List<Dictionary<DisplayResolution, int>>();

		// Token: 0x04000BF3 RID: 3059
		private readonly Dictionary<DisplayDevice, int> deviceToDefaultResolution = new Dictionary<DisplayDevice, int>();

		// Token: 0x04000BF4 RID: 3060
		private readonly Dictionary<DisplayDevice, int> deviceToScreen = new Dictionary<DisplayDevice, int>();

		// Token: 0x04000BF5 RID: 3061
		private readonly List<IntPtr> lastConfigUpdate = new List<IntPtr>();

		// Token: 0x04000BF6 RID: 3062
		private bool xinerama_supported;

		// Token: 0x04000BF7 RID: 3063
		private bool xrandr_supported;

		// Token: 0x04000BF8 RID: 3064
		private bool xf86_supported;

		// Token: 0x0200012F RID: 303
		private static class NativeMethods
		{
			// Token: 0x06000AAC RID: 2732
			[DllImport("libXinerama")]
			public static extern bool XineramaQueryExtension(IntPtr dpy, out int event_basep, out int error_basep);

			// Token: 0x06000AAD RID: 2733
			[DllImport("libXinerama")]
			public static extern int XineramaQueryVersion(IntPtr dpy, out int major_versionp, out int minor_versionp);

			// Token: 0x06000AAE RID: 2734
			[DllImport("libXinerama")]
			public static extern bool XineramaIsActive(IntPtr dpy);

			// Token: 0x06000AAF RID: 2735
			[DllImport("libXinerama")]
			private static extern IntPtr XineramaQueryScreens(IntPtr dpy, out int number);

			// Token: 0x06000AB0 RID: 2736 RVA: 0x000217B8 File Offset: 0x0001F9B8
			public unsafe static IList<X11DisplayDevice.XineramaScreenInfo> XineramaQueryScreens(IntPtr dpy)
			{
				int num;
				IntPtr value = X11DisplayDevice.NativeMethods.XineramaQueryScreens(dpy, out num);
				List<X11DisplayDevice.XineramaScreenInfo> list = new List<X11DisplayDevice.XineramaScreenInfo>(num);
				X11DisplayDevice.XineramaScreenInfo* ptr = (X11DisplayDevice.XineramaScreenInfo*)((void*)value);
				while (--num >= 0)
				{
					list.Add(*ptr);
					ptr++;
				}
				return list;
			}

			// Token: 0x04000BF9 RID: 3065
			private const string Xinerama = "libXinerama";
		}

		// Token: 0x02000130 RID: 304
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct XineramaScreenInfo
		{
			// Token: 0x04000BFA RID: 3066
			public int ScreenNumber;

			// Token: 0x04000BFB RID: 3067
			public short X;

			// Token: 0x04000BFC RID: 3068
			public short Y;

			// Token: 0x04000BFD RID: 3069
			public short Width;

			// Token: 0x04000BFE RID: 3070
			public short Height;
		}
	}
}
