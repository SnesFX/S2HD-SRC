using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200019D RID: 413
	internal enum XIEventMasks
	{
		// Token: 0x04001119 RID: 4377
		DeviceChangedMask = 2,
		// Token: 0x0400111A RID: 4378
		KeyPressMask = 4,
		// Token: 0x0400111B RID: 4379
		KeyReleaseMask = 8,
		// Token: 0x0400111C RID: 4380
		ButtonPressMask = 16,
		// Token: 0x0400111D RID: 4381
		ButtonReleaseMask = 32,
		// Token: 0x0400111E RID: 4382
		MotionMask = 64,
		// Token: 0x0400111F RID: 4383
		EnterMask = 128,
		// Token: 0x04001120 RID: 4384
		LeaveMask = 256,
		// Token: 0x04001121 RID: 4385
		FocusInMask = 512,
		// Token: 0x04001122 RID: 4386
		FocusOutMask = 1024,
		// Token: 0x04001123 RID: 4387
		HierarchyChangedMask = 2048,
		// Token: 0x04001124 RID: 4388
		PropertyEventMask = 4096,
		// Token: 0x04001125 RID: 4389
		RawKeyPressMask = 8192,
		// Token: 0x04001126 RID: 4390
		RawKeyReleaseMask = 16384,
		// Token: 0x04001127 RID: 4391
		RawButtonPressMask = 32768,
		// Token: 0x04001128 RID: 4392
		RawButtonReleaseMask = 65536,
		// Token: 0x04001129 RID: 4393
		RawMotionMask = 131072
	}
}
