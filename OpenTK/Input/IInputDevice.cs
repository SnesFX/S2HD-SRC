using System;

namespace OpenTK.Input
{
	// Token: 0x02000513 RID: 1299
	public interface IInputDevice
	{
		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06003D27 RID: 15655
		string Description { get; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06003D28 RID: 15656
		InputDeviceType DeviceType { get; }
	}
}
