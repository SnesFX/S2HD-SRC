using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000195 RID: 405
	internal struct XIDeviceEvent
	{
		// Token: 0x040010D2 RID: 4306
		public int type;

		// Token: 0x040010D3 RID: 4307
		public IntPtr serial;

		// Token: 0x040010D4 RID: 4308
		public bool send_event;

		// Token: 0x040010D5 RID: 4309
		public IntPtr display;

		// Token: 0x040010D6 RID: 4310
		public int extension;

		// Token: 0x040010D7 RID: 4311
		public XIEventType evtype;

		// Token: 0x040010D8 RID: 4312
		public IntPtr time;

		// Token: 0x040010D9 RID: 4313
		public int deviceid;

		// Token: 0x040010DA RID: 4314
		public int sourceid;

		// Token: 0x040010DB RID: 4315
		public int detail;

		// Token: 0x040010DC RID: 4316
		public IntPtr root;

		// Token: 0x040010DD RID: 4317
		public IntPtr @event;

		// Token: 0x040010DE RID: 4318
		public IntPtr child;

		// Token: 0x040010DF RID: 4319
		public double root_x;

		// Token: 0x040010E0 RID: 4320
		public double root_y;

		// Token: 0x040010E1 RID: 4321
		public double event_x;

		// Token: 0x040010E2 RID: 4322
		public double event_y;

		// Token: 0x040010E3 RID: 4323
		public XIEventFlags flags;

		// Token: 0x040010E4 RID: 4324
		public XIButtonState buttons;

		// Token: 0x040010E5 RID: 4325
		public XIValuatorState valuators;

		// Token: 0x040010E6 RID: 4326
		public XIModifierState mods;

		// Token: 0x040010E7 RID: 4327
		public XIGroupState group;
	}
}
