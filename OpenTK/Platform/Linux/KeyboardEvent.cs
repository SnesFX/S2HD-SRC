using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B96 RID: 2966
	internal struct KeyboardEvent
	{
		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06005C41 RID: 23617 RVA: 0x000F9FB0 File Offset: 0x000F81B0
		public IntPtr BaseEvent
		{
			get
			{
				return KeyboardEvent.GetBaseEvent(this.@event);
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06005C42 RID: 23618 RVA: 0x000F9FC0 File Offset: 0x000F81C0
		public IntPtr Event
		{
			get
			{
				return this.@event;
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06005C43 RID: 23619 RVA: 0x000F9FC8 File Offset: 0x000F81C8
		public uint Time
		{
			get
			{
				return KeyboardEvent.GetTime(this.@event);
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06005C44 RID: 23620 RVA: 0x000F9FD8 File Offset: 0x000F81D8
		public uint Key
		{
			get
			{
				return KeyboardEvent.GetKey(this.@event);
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06005C45 RID: 23621 RVA: 0x000F9FE8 File Offset: 0x000F81E8
		public uint KeyCount
		{
			get
			{
				return KeyboardEvent.GetSeatKeyCount(this.@event);
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06005C46 RID: 23622 RVA: 0x000F9FF8 File Offset: 0x000F81F8
		public KeyState KeyState
		{
			get
			{
				return KeyboardEvent.GetKeyState(this.@event);
			}
		}

		// Token: 0x06005C47 RID: 23623
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_keyboard_get_time")]
		private static extern uint GetTime(IntPtr @event);

		// Token: 0x06005C48 RID: 23624
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_keyboard_get_base_event")]
		private static extern IntPtr GetBaseEvent(IntPtr @event);

		// Token: 0x06005C49 RID: 23625
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_keyboard_get_seat_key_count")]
		private static extern uint GetSeatKeyCount(IntPtr @event);

		// Token: 0x06005C4A RID: 23626
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_keyboard_get_key")]
		private static extern uint GetKey(IntPtr @event);

		// Token: 0x06005C4B RID: 23627
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_keyboard_get_key_state")]
		private static extern KeyState GetKeyState(IntPtr @event);

		// Token: 0x0400B8FD RID: 47357
		private IntPtr @event;
	}
}
