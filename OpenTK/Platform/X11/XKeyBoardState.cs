using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000171 RID: 369
	internal struct XKeyBoardState
	{
		// Token: 0x04000F17 RID: 3863
		public int key_click_percent;

		// Token: 0x04000F18 RID: 3864
		public int bell_percent;

		// Token: 0x04000F19 RID: 3865
		public uint bell_pitch;

		// Token: 0x04000F1A RID: 3866
		public uint bell_duration;

		// Token: 0x04000F1B RID: 3867
		public IntPtr led_mask;

		// Token: 0x04000F1C RID: 3868
		public int global_auto_repeat;

		// Token: 0x04000F1D RID: 3869
		public XKeyBoardState.AutoRepeats auto_repeats;

		// Token: 0x02000172 RID: 370
		[StructLayout(LayoutKind.Explicit)]
		internal struct AutoRepeats
		{
			// Token: 0x04000F1E RID: 3870
			[FieldOffset(0)]
			public byte first;

			// Token: 0x04000F1F RID: 3871
			[FieldOffset(31)]
			public byte last;
		}
	}
}
