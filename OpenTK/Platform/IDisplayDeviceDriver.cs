using System;

namespace OpenTK.Platform
{
	// Token: 0x02000024 RID: 36
	internal interface IDisplayDeviceDriver
	{
		// Token: 0x0600046F RID: 1135
		bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution);

		// Token: 0x06000470 RID: 1136
		bool TryRestoreResolution(DisplayDevice device);

		// Token: 0x06000471 RID: 1137
		DisplayDevice GetDisplay(DisplayIndex displayIndex);
	}
}
