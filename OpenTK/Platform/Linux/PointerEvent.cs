using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B97 RID: 2967
	internal struct PointerEvent
	{
		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06005C4C RID: 23628 RVA: 0x000FA008 File Offset: 0x000F8208
		public IntPtr BaseEvent
		{
			get
			{
				return PointerEvent.GetBaseEvent(this.@event);
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06005C4D RID: 23629 RVA: 0x000FA018 File Offset: 0x000F8218
		public IntPtr Event
		{
			get
			{
				return this.@event;
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06005C4E RID: 23630 RVA: 0x000FA020 File Offset: 0x000F8220
		public uint Time
		{
			get
			{
				return PointerEvent.GetTime(this.@event);
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06005C4F RID: 23631 RVA: 0x000FA030 File Offset: 0x000F8230
		public EvdevButton Button
		{
			get
			{
				return (EvdevButton)PointerEvent.GetButton(this.@event);
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06005C50 RID: 23632 RVA: 0x000FA040 File Offset: 0x000F8240
		public uint ButtonCount
		{
			get
			{
				return PointerEvent.GetButtonCount(this.@event);
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06005C51 RID: 23633 RVA: 0x000FA050 File Offset: 0x000F8250
		public ButtonState ButtonState
		{
			get
			{
				return PointerEvent.GetButtonState(this.@event);
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06005C52 RID: 23634 RVA: 0x000FA060 File Offset: 0x000F8260
		public PointerAxis Axis
		{
			get
			{
				return PointerEvent.GetAxis(this.@event);
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06005C53 RID: 23635 RVA: 0x000FA070 File Offset: 0x000F8270
		public Fixed24 AxisValue
		{
			get
			{
				return PointerEvent.GetAxisValue(this.@event);
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06005C54 RID: 23636 RVA: 0x000FA080 File Offset: 0x000F8280
		public Fixed24 DeltaX
		{
			get
			{
				return PointerEvent.GetDX(this.@event);
			}
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06005C55 RID: 23637 RVA: 0x000FA090 File Offset: 0x000F8290
		public Fixed24 DeltaY
		{
			get
			{
				return PointerEvent.GetDY(this.@event);
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06005C56 RID: 23638 RVA: 0x000FA0A0 File Offset: 0x000F82A0
		public Fixed24 X
		{
			get
			{
				return PointerEvent.GetAbsX(this.@event);
			}
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06005C57 RID: 23639 RVA: 0x000FA0B0 File Offset: 0x000F82B0
		public Fixed24 Y
		{
			get
			{
				return PointerEvent.GetAbsY(this.@event);
			}
		}

		// Token: 0x06005C58 RID: 23640 RVA: 0x000FA0C0 File Offset: 0x000F82C0
		public Fixed24 TransformedX(int width)
		{
			return PointerEvent.GetAbsXTransformed(this.@event, width);
		}

		// Token: 0x06005C59 RID: 23641 RVA: 0x000FA0D0 File Offset: 0x000F82D0
		public Fixed24 TransformedY(int height)
		{
			return PointerEvent.GetAbsYTransformed(this.@event, height);
		}

		// Token: 0x06005C5A RID: 23642
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_time")]
		private static extern uint GetTime(IntPtr @event);

		// Token: 0x06005C5B RID: 23643
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_base_event")]
		private static extern IntPtr GetBaseEvent(IntPtr @event);

		// Token: 0x06005C5C RID: 23644
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_seat_key_count")]
		private static extern uint GetSeatKeyCount(IntPtr @event);

		// Token: 0x06005C5D RID: 23645
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_button")]
		private static extern uint GetButton(IntPtr @event);

		// Token: 0x06005C5E RID: 23646
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_seat_button_count")]
		private static extern uint GetButtonCount(IntPtr @event);

		// Token: 0x06005C5F RID: 23647
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_button_state")]
		private static extern ButtonState GetButtonState(IntPtr @event);

		// Token: 0x06005C60 RID: 23648
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_axis")]
		private static extern PointerAxis GetAxis(IntPtr @event);

		// Token: 0x06005C61 RID: 23649
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_axis_value")]
		private static extern Fixed24 GetAxisValue(IntPtr @event);

		// Token: 0x06005C62 RID: 23650
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_dx")]
		private static extern Fixed24 GetDX(IntPtr @event);

		// Token: 0x06005C63 RID: 23651
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_dy")]
		private static extern Fixed24 GetDY(IntPtr @event);

		// Token: 0x06005C64 RID: 23652
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_absolute_x")]
		private static extern Fixed24 GetAbsX(IntPtr @event);

		// Token: 0x06005C65 RID: 23653
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_absolute_y")]
		private static extern Fixed24 GetAbsY(IntPtr @event);

		// Token: 0x06005C66 RID: 23654
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_absolute_x_transformed")]
		private static extern Fixed24 GetAbsXTransformed(IntPtr @event, int width);

		// Token: 0x06005C67 RID: 23655
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_pointer_get_absolute_y_transformed")]
		private static extern Fixed24 GetAbsYTransformed(IntPtr @event, int height);

		// Token: 0x0400B8FE RID: 47358
		private IntPtr @event;
	}
}
