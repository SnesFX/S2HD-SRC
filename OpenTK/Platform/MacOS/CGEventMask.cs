using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B43 RID: 2883
	[Flags]
	internal enum CGEventMask : long
	{
		// Token: 0x0400B6AD RID: 46765
		LeftMouseDown = 2L,
		// Token: 0x0400B6AE RID: 46766
		LeftMouseUp = 4L,
		// Token: 0x0400B6AF RID: 46767
		RightMouseDown = 8L,
		// Token: 0x0400B6B0 RID: 46768
		RightMouseUp = 16L,
		// Token: 0x0400B6B1 RID: 46769
		MouseMoved = 32L,
		// Token: 0x0400B6B2 RID: 46770
		LeftMouseDragged = 2L,
		// Token: 0x0400B6B3 RID: 46771
		RightMouseDragged = 8L,
		// Token: 0x0400B6B4 RID: 46772
		KeyDown = 1024L,
		// Token: 0x0400B6B5 RID: 46773
		KeyUp = 2048L,
		// Token: 0x0400B6B6 RID: 46774
		FlagsChanged = 4096L,
		// Token: 0x0400B6B7 RID: 46775
		ScrollWheel = 4194304L,
		// Token: 0x0400B6B8 RID: 46776
		TabletPointer = 8388608L,
		// Token: 0x0400B6B9 RID: 46777
		TabletProximity = 16777216L,
		// Token: 0x0400B6BA RID: 46778
		OtherMouseDown = 33554432L,
		// Token: 0x0400B6BB RID: 46779
		OtherMouseUp = 67108864L,
		// Token: 0x0400B6BC RID: 46780
		OtherMouseDragged = 134217728L,
		// Token: 0x0400B6BD RID: 46781
		All = -1L,
		// Token: 0x0400B6BE RID: 46782
		AllMouse = 239075390L
	}
}
