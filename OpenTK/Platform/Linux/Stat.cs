using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B84 RID: 2948
	internal struct Stat
	{
		// Token: 0x0400B8B3 RID: 47283
		public IntPtr dev;

		// Token: 0x0400B8B4 RID: 47284
		public IntPtr ino;

		// Token: 0x0400B8B5 RID: 47285
		public IntPtr mode;

		// Token: 0x0400B8B6 RID: 47286
		public IntPtr nlink;

		// Token: 0x0400B8B7 RID: 47287
		public IntPtr uid;

		// Token: 0x0400B8B8 RID: 47288
		public IntPtr gid;

		// Token: 0x0400B8B9 RID: 47289
		public IntPtr rdev;

		// Token: 0x0400B8BA RID: 47290
		public IntPtr size;

		// Token: 0x0400B8BB RID: 47291
		public IntPtr blksize;

		// Token: 0x0400B8BC RID: 47292
		public IntPtr blocks;

		// Token: 0x0400B8BD RID: 47293
		public IntPtr atime;

		// Token: 0x0400B8BE RID: 47294
		public IntPtr mtime;

		// Token: 0x0400B8BF RID: 47295
		public IntPtr ctime;
	}
}
