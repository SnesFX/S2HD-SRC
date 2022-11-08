using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000092 RID: 146
	internal struct RawInputDevice
	{
		// Token: 0x06000835 RID: 2101 RVA: 0x0001AA38 File Offset: 0x00018C38
		public override string ToString()
		{
			return string.Format("{0}/{1}, flags: {2}, window: {3}", new object[]
			{
				this.UsagePage,
				this.Usage,
				this.Flags,
				this.Target
			});
		}

		// Token: 0x0400039F RID: 927
		internal short UsagePage;

		// Token: 0x040003A0 RID: 928
		internal short Usage;

		// Token: 0x040003A1 RID: 929
		internal RawInputDeviceFlags Flags;

		// Token: 0x040003A2 RID: 930
		internal IntPtr Target;
	}
}
