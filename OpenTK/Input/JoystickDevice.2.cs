using System;

namespace OpenTK.Input
{
	// Token: 0x0200051E RID: 1310
	internal class JoystickDevice<TDetail> : JoystickDevice where TDetail : new()
	{
		// Token: 0x06003D8D RID: 15757 RVA: 0x000A1E90 File Offset: 0x000A0090
		internal JoystickDevice(int id, int axes, int buttons) : base(id, axes, buttons)
		{
		}

		// Token: 0x04004DC5 RID: 19909
		internal TDetail Details = (default(TDetail) == null) ? Activator.CreateInstance<TDetail>() : default(TDetail);
	}
}
