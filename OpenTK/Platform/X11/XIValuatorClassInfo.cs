using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000194 RID: 404
	internal struct XIValuatorClassInfo
	{
		// Token: 0x040010C9 RID: 4297
		public XIClassType type;

		// Token: 0x040010CA RID: 4298
		public int sourceid;

		// Token: 0x040010CB RID: 4299
		public int number;

		// Token: 0x040010CC RID: 4300
		public IntPtr label;

		// Token: 0x040010CD RID: 4301
		public double min;

		// Token: 0x040010CE RID: 4302
		public double max;

		// Token: 0x040010CF RID: 4303
		public double value;

		// Token: 0x040010D0 RID: 4304
		public int resolution;

		// Token: 0x040010D1 RID: 4305
		public int mode;
	}
}
