using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200016A RID: 362
	internal struct XWindowChanges
	{
		// Token: 0x04000EEF RID: 3823
		public int x;

		// Token: 0x04000EF0 RID: 3824
		public int y;

		// Token: 0x04000EF1 RID: 3825
		public int width;

		// Token: 0x04000EF2 RID: 3826
		public int height;

		// Token: 0x04000EF3 RID: 3827
		public int border_width;

		// Token: 0x04000EF4 RID: 3828
		public IntPtr sibling;

		// Token: 0x04000EF5 RID: 3829
		public StackMode stack_mode;
	}
}
