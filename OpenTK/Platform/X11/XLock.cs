using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200012C RID: 300
	internal struct XLock : IDisposable
	{
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000A9A RID: 2714 RVA: 0x00020EB0 File Offset: 0x0001F0B0
		// (set) Token: 0x06000A9B RID: 2715 RVA: 0x00020ED8 File Offset: 0x0001F0D8
		public IntPtr Display
		{
			get
			{
				if (this._display == IntPtr.Zero)
				{
					throw new InvalidOperationException("Internal error (XLockDisplay with IntPtr.Zero). Please report this at http://www.opentk.com/node/add/project-issue/opentk");
				}
				return this._display;
			}
			set
			{
				if (value == IntPtr.Zero)
				{
					throw new ArgumentException();
				}
				this._display = value;
			}
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00020EF4 File Offset: 0x0001F0F4
		public XLock(IntPtr display)
		{
			this = default(XLock);
			this.Display = display;
			Functions.XLockDisplay(this.Display);
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x00020F10 File Offset: 0x0001F110
		public void Dispose()
		{
			Functions.XUnlockDisplay(this.Display);
		}

		// Token: 0x04000BE8 RID: 3048
		private IntPtr _display;
	}
}
