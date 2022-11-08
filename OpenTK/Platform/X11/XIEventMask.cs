using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200019B RID: 411
	internal struct XIEventMask : IDisposable
	{
		// Token: 0x06000B0F RID: 2831 RVA: 0x000260C4 File Offset: 0x000242C4
		public unsafe XIEventMask(int id, XIEventMasks m)
		{
			this.deviceid = id;
			this.mask_len = 4;
			this.mask = (XIEventMasks*)((void*)Marshal.AllocHGlobal(this.mask_len));
			*this.mask = m;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x000260F4 File Offset: 0x000242F4
		public unsafe void Dispose()
		{
			Marshal.FreeHGlobal(new IntPtr((void*)this.mask));
		}

		// Token: 0x04001102 RID: 4354
		public int deviceid;

		// Token: 0x04001103 RID: 4355
		private int mask_len;

		// Token: 0x04001104 RID: 4356
		private unsafe XIEventMasks* mask;
	}
}
