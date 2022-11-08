using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000190 RID: 400
	internal struct XIDeviceInfo
	{
		// Token: 0x040010B5 RID: 4277
		public int deviceid;

		// Token: 0x040010B6 RID: 4278
		public IntPtr name;

		// Token: 0x040010B7 RID: 4279
		public XIDeviceType use;

		// Token: 0x040010B8 RID: 4280
		public int attachment;

		// Token: 0x040010B9 RID: 4281
		public bool enabled;

		// Token: 0x040010BA RID: 4282
		public int num_classes;

		// Token: 0x040010BB RID: 4283
		public IntPtr classes;
	}
}
