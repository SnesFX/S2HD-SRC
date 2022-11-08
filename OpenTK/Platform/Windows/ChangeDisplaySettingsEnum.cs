using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000AF RID: 175
	[Flags]
	internal enum ChangeDisplaySettingsEnum
	{
		// Token: 0x04000430 RID: 1072
		UpdateRegistry = 1,
		// Token: 0x04000431 RID: 1073
		Test = 2,
		// Token: 0x04000432 RID: 1074
		Fullscreen = 4
	}
}
