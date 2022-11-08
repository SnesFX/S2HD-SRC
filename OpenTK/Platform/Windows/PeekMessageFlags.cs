using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000C2 RID: 194
	[Flags]
	internal enum PeekMessageFlags : uint
	{
		// Token: 0x04000669 RID: 1641
		NoRemove = 0U,
		// Token: 0x0400066A RID: 1642
		Remove = 1U,
		// Token: 0x0400066B RID: 1643
		NoYield = 2U
	}
}
