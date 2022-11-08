using System;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020006AF RID: 1711
	public enum ErrorCode
	{
		// Token: 0x0400659B RID: 26011
		NoError,
		// Token: 0x0400659C RID: 26012
		InvalidEnum = 1280,
		// Token: 0x0400659D RID: 26013
		InvalidValue,
		// Token: 0x0400659E RID: 26014
		InvalidOperation,
		// Token: 0x0400659F RID: 26015
		OutOfMemory = 1285,
		// Token: 0x040065A0 RID: 26016
		InvalidFramebufferOperation,
		// Token: 0x040065A1 RID: 26017
		InvalidFramebufferOperationExt = 1286,
		// Token: 0x040065A2 RID: 26018
		InvalidFramebufferOperationOes = 1286,
		// Token: 0x040065A3 RID: 26019
		TableTooLarge = 32817,
		// Token: 0x040065A4 RID: 26020
		TableTooLargeExt = 32817,
		// Token: 0x040065A5 RID: 26021
		TextureTooLargeExt = 32869
	}
}
