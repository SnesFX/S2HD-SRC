using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000096 RID: 150
	internal struct RawInputHeader
	{
		// Token: 0x040003AA RID: 938
		internal RawInputDeviceType Type;

		// Token: 0x040003AB RID: 939
		internal int Size;

		// Token: 0x040003AC RID: 940
		internal IntPtr Device;

		// Token: 0x040003AD RID: 941
		internal IntPtr Param;
	}
}
