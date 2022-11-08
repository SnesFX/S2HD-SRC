using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Platform.MacOS.Carbon;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x0200007B RID: 123
	internal sealed class QuartzDisplayDeviceDriver : DisplayDeviceBase
	{
		// Token: 0x0600077E RID: 1918 RVA: 0x00018F78 File Offset: 0x00017178
		public unsafe QuartzDisplayDeviceDriver()
		{
			lock (QuartzDisplayDeviceDriver.display_lock)
			{
				IntPtr[] array = new IntPtr[20];
				int num;
				fixed (IntPtr* ptr = array)
				{
					CG.GetActiveDisplayList(20, ptr, out num);
				}
				for (int i = 0; i < num; i++)
				{
					IntPtr intPtr = array[i];
					bool flag = i == 0;
					CG.DisplayPixelsWide(intPtr);
					CG.DisplayPixelsHigh(intPtr);
					IntPtr reference = CG.DisplayAvailableModes(intPtr);
					CFArray cfarray = new CFArray(reference);
					DisplayResolution currentResolution = null;
					List<DisplayResolution> list = new List<DisplayResolution>();
					IntPtr reference2 = CG.DisplayCurrentMode(intPtr);
					CFDictionary cfdictionary = new CFDictionary(reference2);
					for (int j = 0; j < cfarray.Count; j++)
					{
						CFDictionary cfdictionary2 = new CFDictionary(cfarray[j]);
						int width = (int)cfdictionary2.GetNumberValue("Width");
						int height = (int)cfdictionary2.GetNumberValue("Height");
						int bitsPerPixel = (int)cfdictionary2.GetNumberValue("BitsPerPixel");
						double numberValue = cfdictionary2.GetNumberValue("RefreshRate");
						bool flag2 = cfdictionary.Ref == cfdictionary2.Ref;
						DisplayResolution displayResolution = new DisplayResolution(0, 0, width, height, bitsPerPixel, (float)numberValue);
						list.Add(displayResolution);
						if (flag2)
						{
							currentResolution = displayResolution;
						}
					}
					HIRect hirect = CG.DisplayBounds(intPtr);
					Rectangle bounds = new Rectangle((int)hirect.Origin.X, (int)hirect.Origin.Y, (int)hirect.Size.Width, (int)hirect.Size.Height);
					DisplayDevice displayDevice = new DisplayDevice(currentResolution, flag, list, bounds, intPtr);
					this.AvailableDevices.Add(displayDevice);
					if (flag)
					{
						this.Primary = displayDevice;
					}
				}
			}
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0001917C File Offset: 0x0001737C
		internal static IntPtr HandleTo(DisplayDevice displayDevice)
		{
			return (IntPtr)displayDevice.Id;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0001918C File Offset: 0x0001738C
		public sealed override bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution)
		{
			IntPtr intPtr = QuartzDisplayDeviceDriver.HandleTo(device);
			IntPtr value = CG.DisplayCurrentMode(intPtr);
			if (!this.storedModes.ContainsKey(intPtr))
			{
				this.storedModes.Add(intPtr, value);
			}
			IntPtr reference = CG.DisplayAvailableModes(intPtr);
			CFArray cfarray = new CFArray(reference);
			for (int i = 0; i < cfarray.Count; i++)
			{
				CFDictionary cfdictionary = new CFDictionary(cfarray[i]);
				int num = (int)cfdictionary.GetNumberValue("Width");
				int num2 = (int)cfdictionary.GetNumberValue("Height");
				int num3 = (int)cfdictionary.GetNumberValue("BitsPerPixel");
				double numberValue = cfdictionary.GetNumberValue("RefreshRate");
				if (num == resolution.Width && num2 == resolution.Height && num3 == resolution.BitsPerPixel && Math.Abs(numberValue - (double)resolution.RefreshRate) < 1E-06)
				{
					CG.DisplaySwitchToMode(intPtr, cfarray[i]);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00019284 File Offset: 0x00017484
		public sealed override bool TryRestoreResolution(DisplayDevice device)
		{
			IntPtr intPtr = QuartzDisplayDeviceDriver.HandleTo(device);
			if (this.storedModes.ContainsKey(intPtr))
			{
				CG.DisplaySwitchToMode(intPtr, this.storedModes[intPtr]);
				this.displaysCaptured.Remove(intPtr);
				return true;
			}
			return false;
		}

		// Token: 0x0400029B RID: 667
		private static object display_lock = new object();

		// Token: 0x0400029C RID: 668
		private Dictionary<IntPtr, IntPtr> storedModes = new Dictionary<IntPtr, IntPtr>();

		// Token: 0x0400029D RID: 669
		private List<IntPtr> displaysCaptured = new List<IntPtr>();
	}
}
