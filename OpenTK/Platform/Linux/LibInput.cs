using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B8E RID: 2958
	internal class LibInput
	{
		// Token: 0x06005C23 RID: 23587
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_udev_create_for_seat")]
		public static extern IntPtr CreateContext(InputInterface @interface, IntPtr user_data, IntPtr udev, string seat_id);

		// Token: 0x06005C24 RID: 23588
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_destroy")]
		public static extern void DestroyContext(IntPtr libinput);

		// Token: 0x06005C25 RID: 23589
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_destroy")]
		public static extern void DestroyEvent(IntPtr @event);

		// Token: 0x06005C26 RID: 23590
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_device_get_sysname")]
		private static extern IntPtr DeviceGetNameInternal(IntPtr device);

		// Token: 0x06005C27 RID: 23591 RVA: 0x000F9ECC File Offset: 0x000F80CC
		public unsafe static string DeviceGetName(IntPtr device)
		{
			return new string((sbyte*)((void*)LibInput.DeviceGetNameInternal(device)));
		}

		// Token: 0x06005C28 RID: 23592
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_device_get_user_data")]
		public static extern IntPtr DeviceGetData(IntPtr device);

		// Token: 0x06005C29 RID: 23593
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_device_set_user_data")]
		public static extern void DeviceSetData(IntPtr device, IntPtr user_data);

		// Token: 0x06005C2A RID: 23594
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_device_get_output_name")]
		private static extern IntPtr DeviceGetOutputNameInternal(IntPtr device);

		// Token: 0x06005C2B RID: 23595 RVA: 0x000F9EE0 File Offset: 0x000F80E0
		public unsafe static string DeviceGetOutputName(IntPtr device)
		{
			sbyte* ptr = (sbyte*)((void*)LibInput.DeviceGetOutputNameInternal(device));
			if (ptr != null)
			{
				return new string(ptr);
			}
			return string.Empty;
		}

		// Token: 0x06005C2C RID: 23596
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_device_get_seat")]
		public static extern IntPtr DeviceGetSeat(IntPtr device);

		// Token: 0x06005C2D RID: 23597
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_device_has_capability")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeviceHasCapability(IntPtr device, DeviceCapability capability);

		// Token: 0x06005C2E RID: 23598
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_dispatch")]
		public static extern int Dispatch(IntPtr libinput);

		// Token: 0x06005C2F RID: 23599
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_get_device")]
		public static extern IntPtr GetDevice(IntPtr @event);

		// Token: 0x06005C30 RID: 23600
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_get_event")]
		public static extern IntPtr GetEvent(IntPtr libinput);

		// Token: 0x06005C31 RID: 23601
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_get_keyboard_event")]
		public static extern KeyboardEvent GetKeyboardEvent(IntPtr @event);

		// Token: 0x06005C32 RID: 23602
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_get_pointer_event")]
		public static extern PointerEvent GetPointerEvent(IntPtr @event);

		// Token: 0x06005C33 RID: 23603
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_event_get_type")]
		public static extern InputEventType GetEventType(IntPtr @event);

		// Token: 0x06005C34 RID: 23604
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_get_fd")]
		public static extern int GetFD(IntPtr libinput);

		// Token: 0x06005C35 RID: 23605
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_next_event_type")]
		public static extern InputEventType NextEventType(IntPtr libinput);

		// Token: 0x06005C36 RID: 23606
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_resume")]
		public static extern void Resume(IntPtr libinput);

		// Token: 0x06005C37 RID: 23607
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_suspend")]
		public static extern void Suspend(IntPtr libinput);

		// Token: 0x06005C38 RID: 23608
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_seat_get_logical_name")]
		public static extern IntPtr SeatGetLogicalNameInternal(IntPtr seat);

		// Token: 0x06005C39 RID: 23609 RVA: 0x000F9F0C File Offset: 0x000F810C
		public unsafe static string SeatGetLogicalName(IntPtr seat)
		{
			return new string((sbyte*)((void*)LibInput.SeatGetLogicalNameInternal(seat)));
		}

		// Token: 0x06005C3A RID: 23610
		[DllImport("libinput", CallingConvention = CallingConvention.Cdecl, EntryPoint = "libinput_seat_get_physical_name")]
		public static extern IntPtr SeatGetPhysicalNameInternal(IntPtr seat);

		// Token: 0x06005C3B RID: 23611 RVA: 0x000F9F20 File Offset: 0x000F8120
		public unsafe static string SeatGetPhysicalName(IntPtr seat)
		{
			return new string((sbyte*)((void*)LibInput.SeatGetPhysicalNameInternal(seat)));
		}

		// Token: 0x0400B8DE RID: 47326
		internal const string lib = "libinput";
	}
}
