using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200015D RID: 349
	internal enum XEventName
	{
		// Token: 0x04000DF5 RID: 3573
		KeyPress = 2,
		// Token: 0x04000DF6 RID: 3574
		KeyRelease,
		// Token: 0x04000DF7 RID: 3575
		ButtonPress,
		// Token: 0x04000DF8 RID: 3576
		ButtonRelease,
		// Token: 0x04000DF9 RID: 3577
		MotionNotify,
		// Token: 0x04000DFA RID: 3578
		EnterNotify,
		// Token: 0x04000DFB RID: 3579
		LeaveNotify,
		// Token: 0x04000DFC RID: 3580
		FocusIn,
		// Token: 0x04000DFD RID: 3581
		FocusOut,
		// Token: 0x04000DFE RID: 3582
		KeymapNotify,
		// Token: 0x04000DFF RID: 3583
		Expose,
		// Token: 0x04000E00 RID: 3584
		GraphicsExpose,
		// Token: 0x04000E01 RID: 3585
		NoExpose,
		// Token: 0x04000E02 RID: 3586
		VisibilityNotify,
		// Token: 0x04000E03 RID: 3587
		CreateNotify,
		// Token: 0x04000E04 RID: 3588
		DestroyNotify,
		// Token: 0x04000E05 RID: 3589
		UnmapNotify,
		// Token: 0x04000E06 RID: 3590
		MapNotify,
		// Token: 0x04000E07 RID: 3591
		MapRequest,
		// Token: 0x04000E08 RID: 3592
		ReparentNotify,
		// Token: 0x04000E09 RID: 3593
		ConfigureNotify,
		// Token: 0x04000E0A RID: 3594
		ConfigureRequest,
		// Token: 0x04000E0B RID: 3595
		GravityNotify,
		// Token: 0x04000E0C RID: 3596
		ResizeRequest,
		// Token: 0x04000E0D RID: 3597
		CirculateNotify,
		// Token: 0x04000E0E RID: 3598
		CirculateRequest,
		// Token: 0x04000E0F RID: 3599
		PropertyNotify,
		// Token: 0x04000E10 RID: 3600
		SelectionClear,
		// Token: 0x04000E11 RID: 3601
		SelectionRequest,
		// Token: 0x04000E12 RID: 3602
		SelectionNotify,
		// Token: 0x04000E13 RID: 3603
		ColormapNotify,
		// Token: 0x04000E14 RID: 3604
		ClientMessage,
		// Token: 0x04000E15 RID: 3605
		MappingNotify,
		// Token: 0x04000E16 RID: 3606
		GenericEvent,
		// Token: 0x04000E17 RID: 3607
		LASTEvent
	}
}
