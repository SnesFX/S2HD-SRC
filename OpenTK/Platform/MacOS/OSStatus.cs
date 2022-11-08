using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000079 RID: 121
	internal enum OSStatus
	{
		// Token: 0x04000267 RID: 615
		NoError,
		// Token: 0x04000268 RID: 616
		ParameterError = -50,
		// Token: 0x04000269 RID: 617
		NoHardwareError = -200,
		// Token: 0x0400026A RID: 618
		NotEnoughHardwareError = -201,
		// Token: 0x0400026B RID: 619
		UserCanceledError = -128,
		// Token: 0x0400026C RID: 620
		QueueError = -1,
		// Token: 0x0400026D RID: 621
		VTypErr = -2,
		// Token: 0x0400026E RID: 622
		CorErr = -3,
		// Token: 0x0400026F RID: 623
		UnimpErr = -4,
		// Token: 0x04000270 RID: 624
		SlpTypeErr = -5,
		// Token: 0x04000271 RID: 625
		SeNoDB = -8,
		// Token: 0x04000272 RID: 626
		ControlErr = -17,
		// Token: 0x04000273 RID: 627
		StatusErr = -18,
		// Token: 0x04000274 RID: 628
		ReadErr = -19,
		// Token: 0x04000275 RID: 629
		WritErr = -20,
		// Token: 0x04000276 RID: 630
		BadUnitErr = -21,
		// Token: 0x04000277 RID: 631
		UnitEmptyErr = -22,
		// Token: 0x04000278 RID: 632
		OpenErr = -23,
		// Token: 0x04000279 RID: 633
		ClosErr = -24,
		// Token: 0x0400027A RID: 634
		DRemovErr = -25,
		// Token: 0x0400027B RID: 635
		DInstErr = -26,
		// Token: 0x0400027C RID: 636
		InvalidWindowPtr = -5600,
		// Token: 0x0400027D RID: 637
		UnsupportedWindowAttributesForClass = -5601,
		// Token: 0x0400027E RID: 638
		WindowDoesNotHaveProxy = -5602,
		// Token: 0x0400027F RID: 639
		WindowPropertyNotFound = -5604,
		// Token: 0x04000280 RID: 640
		UnrecognizedWindowClass = -5605,
		// Token: 0x04000281 RID: 641
		CorruptWindowDescription = -5606,
		// Token: 0x04000282 RID: 642
		UserWantsToDragWindow = -5607,
		// Token: 0x04000283 RID: 643
		WindowsAlreadyInitialized = -5608,
		// Token: 0x04000284 RID: 644
		FloatingWindowsNotInitialized = -5609,
		// Token: 0x04000285 RID: 645
		WindowNotFound = -5610,
		// Token: 0x04000286 RID: 646
		WindowDoesNotFitOnscreen = -5611,
		// Token: 0x04000287 RID: 647
		WindowAttributeImmutable = -5612,
		// Token: 0x04000288 RID: 648
		WindowAttributesConflict = -5613,
		// Token: 0x04000289 RID: 649
		WindowManagerInternalError = -5614,
		// Token: 0x0400028A RID: 650
		WindowWrongState = -5615,
		// Token: 0x0400028B RID: 651
		WindowGroupInvalid = -5616,
		// Token: 0x0400028C RID: 652
		WindowAppModalStateAlreadyExists = -5617,
		// Token: 0x0400028D RID: 653
		WindowNoAppModalState = -5618,
		// Token: 0x0400028E RID: 654
		WindowDoesntSupportFocus = -30583,
		// Token: 0x0400028F RID: 655
		WindowRegionCodeInvalid = -30593,
		// Token: 0x04000290 RID: 656
		EventAlreadyPosted = -9860,
		// Token: 0x04000291 RID: 657
		EventTargetBusy = -9861,
		// Token: 0x04000292 RID: 658
		EventDeferAccessibilityEvent = -9865,
		// Token: 0x04000293 RID: 659
		EventInternalError = -9868,
		// Token: 0x04000294 RID: 660
		EventParameterNotFound = -9870,
		// Token: 0x04000295 RID: 661
		EventNotHandled = -9874,
		// Token: 0x04000296 RID: 662
		EventLoopTimedOut = -9875,
		// Token: 0x04000297 RID: 663
		EventLoopQuit = -9876,
		// Token: 0x04000298 RID: 664
		EventNotInQueue = -9877,
		// Token: 0x04000299 RID: 665
		HotKeyExists = -9878,
		// Token: 0x0400029A RID: 666
		EventPassToNextTarget = -9880
	}
}
