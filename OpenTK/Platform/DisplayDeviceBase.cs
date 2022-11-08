using System;
using System.Collections.Generic;

namespace OpenTK.Platform
{
	// Token: 0x02000025 RID: 37
	internal abstract class DisplayDeviceBase : IDisplayDeviceDriver
	{
		// Token: 0x06000472 RID: 1138
		public abstract bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution);

		// Token: 0x06000473 RID: 1139
		public abstract bool TryRestoreResolution(DisplayDevice device);

		// Token: 0x06000474 RID: 1140 RVA: 0x00013660 File Offset: 0x00011860
		public virtual DisplayDevice GetDisplay(DisplayIndex index)
		{
			if (index == DisplayIndex.Primary)
			{
				return this.Primary;
			}
			if (index >= DisplayIndex.First && index < (DisplayIndex)this.AvailableDevices.Count)
			{
				return this.AvailableDevices[(int)index];
			}
			return null;
		}

		// Token: 0x040000AB RID: 171
		protected readonly List<DisplayDevice> AvailableDevices = new List<DisplayDevice>();

		// Token: 0x040000AC RID: 172
		protected DisplayDevice Primary;
	}
}
