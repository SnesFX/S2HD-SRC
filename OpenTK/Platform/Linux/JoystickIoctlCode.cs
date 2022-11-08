using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B82 RID: 2946
	internal enum JoystickIoctlCode : uint
	{
		// Token: 0x0400B8AC RID: 47276
		Version = 2147772929U,
		// Token: 0x0400B8AD RID: 47277
		Axes = 2147576337U,
		// Token: 0x0400B8AE RID: 47278
		Buttons,
		// Token: 0x0400B8AF RID: 47279
		Name128 = 2155899411U
	}
}
