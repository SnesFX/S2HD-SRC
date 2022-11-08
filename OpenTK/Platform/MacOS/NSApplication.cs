using System;
using System.ComponentModel;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B20 RID: 2848
	internal static class NSApplication
	{
		// Token: 0x06005A7E RID: 23166 RVA: 0x000F5F88 File Offset: 0x000F4188
		internal static void Initialize()
		{
			NSApplication.AutoreleasePool = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.NSAutoreleasePool, Selector.Alloc), Selector.Init);
			IntPtr intPtr = Class.Get("NSApplication");
			Class.RegisterMethod(intPtr, new NSApplication.OnQuitDelegate(NSApplication.OnQuit), "quit", "v@:");
			NSApplication.Handle = Cocoa.SendIntPtr(intPtr, Selector.Get("sharedApplication"));
			Cocoa.SendBool(NSApplication.Handle, Selector.Get("setActivationPolicy:"), 0);
			Cocoa.SendVoid(NSApplication.Handle, Selector.Get("activateIgnoringOtherApps:"), true);
			IntPtr intPtr2 = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.Get("NSMenu"), Selector.Alloc), Selector.Autorelease);
			IntPtr intPtr3 = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.Get("NSMenuItem"), Selector.Alloc), Selector.Autorelease);
			Cocoa.SendIntPtr(intPtr2, Selector.Get("addItem:"), intPtr3);
			Cocoa.SendIntPtr(NSApplication.Handle, Selector.Get("setMainMenu:"), intPtr2);
			IntPtr intPtr4 = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.Get("NSMenu"), Selector.Alloc), Selector.Autorelease);
			IntPtr intPtr5 = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.Get("NSMenuItem"), Selector.Alloc), Selector.Get("initWithTitle:action:keyEquivalent:"), Cocoa.ToNSString("Quit"), NSApplication.selQuit, Cocoa.ToNSString("q")), Selector.Autorelease);
			Cocoa.SendIntPtr(intPtr4, Selector.Get("addItem:"), intPtr5);
			Cocoa.SendIntPtr(intPtr3, Selector.Get("setSubmenu:"), intPtr4);
			Cocoa.SendVoid(NSApplication.Handle, Selector.Get("finishLaunching"));
			IntPtr intPtr6 = Cocoa.SendIntPtr(Class.NSDictionary, Selector.Alloc);
			Cocoa.SendIntPtr(Class.NSNumber, Selector.Get("numberWithBool:"), false);
			IntPtr intPtr7 = Cocoa.SendIntPtr(Class.NSNumber, Selector.Get("numberWithBool:"), false);
			intPtr6 = Cocoa.SendIntPtr(intPtr6, Selector.Get("initWithObjectsAndKeys:"), intPtr7, Cocoa.ToNSString("ApplePressAndHoldEnabled"), IntPtr.Zero);
			Cocoa.SendVoid(Cocoa.SendIntPtr(Class.NSUserDefaults, Selector.Get("standardUserDefaults")), Selector.Get("registerDefaults:"), intPtr6);
			Cocoa.SendVoid(intPtr6, Selector.Release);
		}

		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06005A7F RID: 23167 RVA: 0x000F61B4 File Offset: 0x000F43B4
		// (remove) Token: 0x06005A80 RID: 23168 RVA: 0x000F61E8 File Offset: 0x000F43E8
		internal static event EventHandler<CancelEventArgs> Quit;

		// Token: 0x06005A81 RID: 23169 RVA: 0x000F621C File Offset: 0x000F441C
		private static void OnQuit(IntPtr self, IntPtr cmd)
		{
			CancelEventArgs cancelEventArgs = new CancelEventArgs();
			NSApplication.Quit(null, cancelEventArgs);
			if (!cancelEventArgs.Cancel)
			{
				Cocoa.SendVoid(NSApplication.Handle, Selector.Get("terminate:"), NSApplication.Handle);
			}
		}

		// Token: 0x06005A82 RID: 23170 RVA: 0x000F625C File Offset: 0x000F445C
		// Note: this type is marked as 'beforefieldinit'.
		static NSApplication()
		{
			NSApplication.Quit = delegate(object param0, CancelEventArgs param1)
			{
			};
		}

		// Token: 0x0400B554 RID: 46420
		internal static IntPtr Handle;

		// Token: 0x0400B555 RID: 46421
		internal static IntPtr AutoreleasePool;

		// Token: 0x0400B556 RID: 46422
		private static readonly IntPtr selQuit = Selector.Get("quit");

		// Token: 0x02000B21 RID: 2849
		// (Invoke) Token: 0x06005A85 RID: 23173
		private delegate void OnQuitDelegate(IntPtr self, IntPtr cmd);
	}
}
