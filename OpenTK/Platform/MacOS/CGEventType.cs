using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B44 RID: 2884
	internal enum CGEventType
	{
		// Token: 0x0400B6C0 RID: 46784
		Null,
		// Token: 0x0400B6C1 RID: 46785
		LeftMouseDown,
		// Token: 0x0400B6C2 RID: 46786
		LeftMouseUp,
		// Token: 0x0400B6C3 RID: 46787
		RightMouseDown,
		// Token: 0x0400B6C4 RID: 46788
		RightMouseUp,
		// Token: 0x0400B6C5 RID: 46789
		MouseMoved,
		// Token: 0x0400B6C6 RID: 46790
		LeftMouseDragged,
		// Token: 0x0400B6C7 RID: 46791
		RightMouseDragged,
		// Token: 0x0400B6C8 RID: 46792
		KeyDown = 10,
		// Token: 0x0400B6C9 RID: 46793
		KeyUp,
		// Token: 0x0400B6CA RID: 46794
		FlagsChanged,
		// Token: 0x0400B6CB RID: 46795
		ScrollWheel = 22,
		// Token: 0x0400B6CC RID: 46796
		TabletPointer,
		// Token: 0x0400B6CD RID: 46797
		TabletProximity,
		// Token: 0x0400B6CE RID: 46798
		OtherMouseDown,
		// Token: 0x0400B6CF RID: 46799
		OtherMouseUp,
		// Token: 0x0400B6D0 RID: 46800
		OtherMouseDragged,
		// Token: 0x0400B6D1 RID: 46801
		TapDisabledByTimeout = -2,
		// Token: 0x0400B6D2 RID: 46802
		TapDisabledByUserInput
	}
}
