using System;
using OpenTK.Platform.Egl;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B87 RID: 2951
	internal class LinuxWindowInfo : EglWindowInfo
	{
		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06005C03 RID: 23555 RVA: 0x000F9A28 File Offset: 0x000F7C28
		// (set) Token: 0x06005C04 RID: 23556 RVA: 0x000F9A30 File Offset: 0x000F7C30
		public int FD { get; private set; }

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06005C05 RID: 23557 RVA: 0x000F9A3C File Offset: 0x000F7C3C
		// (set) Token: 0x06005C06 RID: 23558 RVA: 0x000F9A44 File Offset: 0x000F7C44
		public LinuxDisplay DisplayDevice { get; private set; }

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06005C07 RID: 23559 RVA: 0x000F9A50 File Offset: 0x000F7C50
		// (set) Token: 0x06005C08 RID: 23560 RVA: 0x000F9A58 File Offset: 0x000F7C58
		public IntPtr BufferManager { get; private set; }

		// Token: 0x06005C09 RID: 23561 RVA: 0x000F9A64 File Offset: 0x000F7C64
		public LinuxWindowInfo(IntPtr display, int fd, IntPtr gbm, LinuxDisplay display_device) : base(IntPtr.Zero, display, IntPtr.Zero)
		{
			if (display_device == null)
			{
				throw new ArgumentNullException();
			}
			this.FD = fd;
			this.BufferManager = gbm;
			this.DisplayDevice = display_device;
		}
	}
}
