using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000196 RID: 406
	internal struct XIRawEvent
	{
		// Token: 0x040010E8 RID: 4328
		public int type;

		// Token: 0x040010E9 RID: 4329
		public IntPtr serial;

		// Token: 0x040010EA RID: 4330
		public bool send_event;

		// Token: 0x040010EB RID: 4331
		public IntPtr display;

		// Token: 0x040010EC RID: 4332
		public int extension;

		// Token: 0x040010ED RID: 4333
		public XIEventType evtype;

		// Token: 0x040010EE RID: 4334
		public IntPtr time;

		// Token: 0x040010EF RID: 4335
		public int deviceid;

		// Token: 0x040010F0 RID: 4336
		public int sourceid;

		// Token: 0x040010F1 RID: 4337
		public int detail;

		// Token: 0x040010F2 RID: 4338
		public XIEventFlags flags;

		// Token: 0x040010F3 RID: 4339
		public XIValuatorState valuators;

		// Token: 0x040010F4 RID: 4340
		public IntPtr raw_values;
	}
}
