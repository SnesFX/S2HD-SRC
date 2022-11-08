using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B1C RID: 2844
	internal sealed class CocoaWindowInfo : IWindowInfo, IDisposable
	{
		// Token: 0x06005A3D RID: 23101 RVA: 0x000F5B40 File Offset: 0x000F3D40
		public CocoaWindowInfo(IntPtr nsWindowRef) : this(nsWindowRef, Cocoa.SendIntPtr(nsWindowRef, CocoaWindowInfo.selContentView))
		{
		}

		// Token: 0x06005A3E RID: 23102 RVA: 0x000F5B54 File Offset: 0x000F3D54
		public CocoaWindowInfo(IntPtr nsWindowRef, IntPtr nsViewRef)
		{
			this.nsWindowRef = nsWindowRef;
			this.nsViewRef = nsViewRef;
			Cocoa.SendVoid(nsWindowRef, Selector.Retain);
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06005A3F RID: 23103 RVA: 0x000F5B78 File Offset: 0x000F3D78
		public IntPtr Handle
		{
			get
			{
				return this.nsWindowRef;
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06005A40 RID: 23104 RVA: 0x000F5B80 File Offset: 0x000F3D80
		public IntPtr ViewHandle
		{
			get
			{
				return this.nsViewRef;
			}
		}

		// Token: 0x06005A41 RID: 23105 RVA: 0x000F5B88 File Offset: 0x000F3D88
		public override string ToString()
		{
			return string.Format("MacOS.CocoaWindowInfo: NSWindow {0}, NSView {1}", this.nsWindowRef, this.nsViewRef);
		}

		// Token: 0x06005A42 RID: 23106 RVA: 0x000F5BAC File Offset: 0x000F3DAC
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06005A43 RID: 23107 RVA: 0x000F5BB8 File Offset: 0x000F3DB8
		private void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}
			if (disposing)
			{
				Cocoa.SendVoid(this.nsWindowRef, Selector.Release);
			}
			this.disposed = true;
		}

		// Token: 0x0400B541 RID: 46401
		private static readonly IntPtr selContentView = Selector.Get("contentView");

		// Token: 0x0400B542 RID: 46402
		private IntPtr nsWindowRef;

		// Token: 0x0400B543 RID: 46403
		private IntPtr nsViewRef;

		// Token: 0x0400B544 RID: 46404
		private bool disposed;
	}
}
