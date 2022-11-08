using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000105 RID: 261
	internal sealed class X11WindowInfo : IWindowInfo, IDisposable
	{
		// Token: 0x0600098D RID: 2445 RVA: 0x000205B4 File Offset: 0x0001E7B4
		public X11WindowInfo()
		{
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x000205BC File Offset: 0x0001E7BC
		public X11WindowInfo(IntPtr handle, X11WindowInfo parent)
		{
			this.handle = handle;
			this.parent = parent;
			if (parent != null)
			{
				this.rootWindow = parent.rootWindow;
				this.display = parent.display;
				this.screen = parent.screen;
				this.visualInfo = parent.visualInfo;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600098F RID: 2447 RVA: 0x00020610 File Offset: 0x0001E810
		// (set) Token: 0x06000990 RID: 2448 RVA: 0x00020618 File Offset: 0x0001E818
		public IntPtr Handle
		{
			get
			{
				return this.handle;
			}
			set
			{
				this.handle = value;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000991 RID: 2449 RVA: 0x00020624 File Offset: 0x0001E824
		// (set) Token: 0x06000992 RID: 2450 RVA: 0x0002062C File Offset: 0x0001E82C
		public X11WindowInfo Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000993 RID: 2451 RVA: 0x00020638 File Offset: 0x0001E838
		// (set) Token: 0x06000994 RID: 2452 RVA: 0x00020640 File Offset: 0x0001E840
		public IntPtr RootWindow
		{
			get
			{
				return this.rootWindow;
			}
			set
			{
				this.rootWindow = value;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000995 RID: 2453 RVA: 0x0002064C File Offset: 0x0001E84C
		// (set) Token: 0x06000996 RID: 2454 RVA: 0x00020654 File Offset: 0x0001E854
		public IntPtr Display
		{
			get
			{
				return this.display;
			}
			set
			{
				this.display = value;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000997 RID: 2455 RVA: 0x00020660 File Offset: 0x0001E860
		// (set) Token: 0x06000998 RID: 2456 RVA: 0x00020668 File Offset: 0x0001E868
		public int Screen
		{
			get
			{
				return this.screen;
			}
			set
			{
				this.screen = value;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x00020674 File Offset: 0x0001E874
		// (set) Token: 0x0600099A RID: 2458 RVA: 0x0002067C File Offset: 0x0001E87C
		public XVisualInfo VisualInfo
		{
			get
			{
				return this.visualInfo;
			}
			set
			{
				this.visualInfo = value;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x00020688 File Offset: 0x0001E888
		// (set) Token: 0x0600099C RID: 2460 RVA: 0x00020690 File Offset: 0x0001E890
		public EventMask EventMask
		{
			get
			{
				return this.eventMask;
			}
			set
			{
				this.eventMask = value;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x0002069C File Offset: 0x0001E89C
		// (set) Token: 0x0600099E RID: 2462 RVA: 0x000206A4 File Offset: 0x0001E8A4
		public IntPtr WindowHandle
		{
			get
			{
				return this.Handle;
			}
			set
			{
				this.Handle = value;
			}
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x000206B0 File Offset: 0x0001E8B0
		public void Dispose()
		{
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000206B4 File Offset: 0x0001E8B4
		public override string ToString()
		{
			return string.Format("X11.WindowInfo: Display {0}, Screen {1}, Handle {2}, Parent: ({3})", new object[]
			{
				this.Display,
				this.Screen,
				this.Handle,
				(this.Parent != null) ? this.Parent.ToString() : "null"
			});
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0002071C File Offset: 0x0001E91C
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (base.GetType() != obj.GetType())
			{
				return false;
			}
			X11WindowInfo x11WindowInfo = (X11WindowInfo)obj;
			return x11WindowInfo != null && object.Equals(this.display, x11WindowInfo.display) && this.handle.Equals(x11WindowInfo.handle);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00020788 File Offset: 0x0001E988
		public override int GetHashCode()
		{
			return this.handle.GetHashCode() ^ this.display.GetHashCode();
		}

		// Token: 0x04000961 RID: 2401
		private IntPtr handle;

		// Token: 0x04000962 RID: 2402
		private IntPtr rootWindow;

		// Token: 0x04000963 RID: 2403
		private IntPtr display;

		// Token: 0x04000964 RID: 2404
		private X11WindowInfo parent;

		// Token: 0x04000965 RID: 2405
		private int screen;

		// Token: 0x04000966 RID: 2406
		private XVisualInfo visualInfo;

		// Token: 0x04000967 RID: 2407
		private EventMask eventMask;
	}
}
