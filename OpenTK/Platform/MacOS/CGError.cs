using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B47 RID: 2887
	internal enum CGError
	{
		// Token: 0x0400B70B RID: 46859
		Success,
		// Token: 0x0400B70C RID: 46860
		Failure = 1000,
		// Token: 0x0400B70D RID: 46861
		IllegalArgument,
		// Token: 0x0400B70E RID: 46862
		InvalidConnection,
		// Token: 0x0400B70F RID: 46863
		InvalidContext,
		// Token: 0x0400B710 RID: 46864
		CannotComplete,
		// Token: 0x0400B711 RID: 46865
		NotImplemented = 1006,
		// Token: 0x0400B712 RID: 46866
		RangeCheck,
		// Token: 0x0400B713 RID: 46867
		TypeCheck,
		// Token: 0x0400B714 RID: 46868
		InvalidOperation = 1010,
		// Token: 0x0400B715 RID: 46869
		NoneAvailable
	}
}
