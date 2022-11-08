using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000192 RID: 402
	internal struct XIButtonClassInfo
	{
		// Token: 0x040010BE RID: 4286
		public XIClassType type;

		// Token: 0x040010BF RID: 4287
		public int sourceid;

		// Token: 0x040010C0 RID: 4288
		public int num_buttons;

		// Token: 0x040010C1 RID: 4289
		public IntPtr labels;

		// Token: 0x040010C2 RID: 4290
		public XIButtonState state;
	}
}
