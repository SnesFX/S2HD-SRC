using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005D6 RID: 1494
	internal struct SysWMInfo
	{
		// Token: 0x04005569 RID: 21865
		public Version Version;

		// Token: 0x0400556A RID: 21866
		public SysWMType Subsystem;

		// Token: 0x0400556B RID: 21867
		public SysWMInfo.SysInfo Info;

		// Token: 0x020005D7 RID: 1495
		[StructLayout(LayoutKind.Explicit)]
		public struct SysInfo
		{
			// Token: 0x0400556C RID: 21868
			[FieldOffset(0)]
			public SysWMInfo.SysInfo.WindowsInfo Windows;

			// Token: 0x0400556D RID: 21869
			[FieldOffset(0)]
			public SysWMInfo.SysInfo.X11Info X11;

			// Token: 0x0400556E RID: 21870
			[FieldOffset(0)]
			public SysWMInfo.SysInfo.WaylandInfo Wayland;

			// Token: 0x0400556F RID: 21871
			[FieldOffset(0)]
			public SysWMInfo.SysInfo.DirectFBInfo DirectFB;

			// Token: 0x04005570 RID: 21872
			[FieldOffset(0)]
			public SysWMInfo.SysInfo.CocoaInfo Cocoa;

			// Token: 0x04005571 RID: 21873
			[FieldOffset(0)]
			public SysWMInfo.SysInfo.UIKitInfo UIKit;

			// Token: 0x020005D8 RID: 1496
			public struct WindowsInfo
			{
				// Token: 0x04005572 RID: 21874
				public IntPtr Window;
			}

			// Token: 0x020005D9 RID: 1497
			public struct X11Info
			{
				// Token: 0x04005573 RID: 21875
				public IntPtr Display;

				// Token: 0x04005574 RID: 21876
				public IntPtr Window;
			}

			// Token: 0x020005DA RID: 1498
			public struct WaylandInfo
			{
				// Token: 0x04005575 RID: 21877
				public IntPtr Display;

				// Token: 0x04005576 RID: 21878
				public IntPtr Surface;

				// Token: 0x04005577 RID: 21879
				public IntPtr ShellSurface;
			}

			// Token: 0x020005DB RID: 1499
			public struct DirectFBInfo
			{
				// Token: 0x04005578 RID: 21880
				public IntPtr Dfb;

				// Token: 0x04005579 RID: 21881
				public IntPtr Window;

				// Token: 0x0400557A RID: 21882
				public IntPtr Surface;
			}

			// Token: 0x020005DC RID: 1500
			public struct CocoaInfo
			{
				// Token: 0x0400557B RID: 21883
				public IntPtr Window;
			}

			// Token: 0x020005DD RID: 1501
			public struct UIKitInfo
			{
				// Token: 0x0400557C RID: 21884
				public IntPtr Window;
			}
		}
	}
}
