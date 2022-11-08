using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B29 RID: 2857
	internal enum NSEventType
	{
		// Token: 0x0400B5AE RID: 46510
		LeftMouseDown = 1,
		// Token: 0x0400B5AF RID: 46511
		LeftMouseUp,
		// Token: 0x0400B5B0 RID: 46512
		RightMouseDown,
		// Token: 0x0400B5B1 RID: 46513
		RightMouseUp,
		// Token: 0x0400B5B2 RID: 46514
		MouseMoved,
		// Token: 0x0400B5B3 RID: 46515
		LeftMouseDragged,
		// Token: 0x0400B5B4 RID: 46516
		RightMouseDragged,
		// Token: 0x0400B5B5 RID: 46517
		MouseEntered,
		// Token: 0x0400B5B6 RID: 46518
		MouseExited,
		// Token: 0x0400B5B7 RID: 46519
		KeyDown,
		// Token: 0x0400B5B8 RID: 46520
		KeyUp,
		// Token: 0x0400B5B9 RID: 46521
		FlagsChanged,
		// Token: 0x0400B5BA RID: 46522
		AppKitDefined,
		// Token: 0x0400B5BB RID: 46523
		SystemDefined,
		// Token: 0x0400B5BC RID: 46524
		ApplicationDefined,
		// Token: 0x0400B5BD RID: 46525
		Periodic,
		// Token: 0x0400B5BE RID: 46526
		CursorUpdate,
		// Token: 0x0400B5BF RID: 46527
		Rotate,
		// Token: 0x0400B5C0 RID: 46528
		BeginGesture,
		// Token: 0x0400B5C1 RID: 46529
		EndGesture,
		// Token: 0x0400B5C2 RID: 46530
		ScrollWheel = 22,
		// Token: 0x0400B5C3 RID: 46531
		TabletPoint,
		// Token: 0x0400B5C4 RID: 46532
		TabletProximity,
		// Token: 0x0400B5C5 RID: 46533
		OtherMouseDown,
		// Token: 0x0400B5C6 RID: 46534
		OtherMouseUp,
		// Token: 0x0400B5C7 RID: 46535
		OtherMouseDragged,
		// Token: 0x0400B5C8 RID: 46536
		Gesture = 29,
		// Token: 0x0400B5C9 RID: 46537
		Magnify,
		// Token: 0x0400B5CA RID: 46538
		Swipe,
		// Token: 0x0400B5CB RID: 46539
		SmartMagnify,
		// Token: 0x0400B5CC RID: 46540
		QuickLook
	}
}
