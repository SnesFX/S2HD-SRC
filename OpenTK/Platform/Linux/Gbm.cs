using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B75 RID: 2933
	internal class Gbm
	{
		// Token: 0x06005BAD RID: 23469
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_create")]
		public static extern BufferObject CreateBuffer(IntPtr gbm, int width, int height, SurfaceFormat format, SurfaceFlags flags);

		// Token: 0x06005BAE RID: 23470
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_destroy")]
		public static extern void DestroyBuffer(BufferObject bo);

		// Token: 0x06005BAF RID: 23471
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_write")]
		public static extern int BOWrite(IntPtr bo, IntPtr buf, IntPtr count);

		// Token: 0x06005BB0 RID: 23472
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_get_device")]
		public static extern IntPtr BOGetDevice(IntPtr bo);

		// Token: 0x06005BB1 RID: 23473
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_get_handle")]
		public static extern IntPtr BOGetHandle(IntPtr bo);

		// Token: 0x06005BB2 RID: 23474
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_get_height")]
		public static extern int BOGetHeight(IntPtr bo);

		// Token: 0x06005BB3 RID: 23475
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_get_width")]
		public static extern int BOGetWidth(IntPtr bo);

		// Token: 0x06005BB4 RID: 23476
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_get_stride")]
		public static extern int BOGetStride(IntPtr bo);

		// Token: 0x06005BB5 RID: 23477
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_bo_set_user_data")]
		public static extern void BOSetUserData(IntPtr bo, IntPtr data, DestroyUserDataCallback callback);

		// Token: 0x06005BB6 RID: 23478
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_create_device")]
		public static extern IntPtr CreateDevice(int fd);

		// Token: 0x06005BB7 RID: 23479
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_device_destroy")]
		public static extern void DestroyDevice(IntPtr gbm);

		// Token: 0x06005BB8 RID: 23480
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_device_get_fd")]
		public static extern int DeviceGetFD(IntPtr gbm);

		// Token: 0x06005BB9 RID: 23481
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_surface_create")]
		public static extern IntPtr CreateSurface(IntPtr gbm, int width, int height, SurfaceFormat format, SurfaceFlags flags);

		// Token: 0x06005BBA RID: 23482
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_surface_destroy")]
		public static extern void DestroySurface(IntPtr surface);

		// Token: 0x06005BBB RID: 23483
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_device_is_format_supported")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsFormatSupported(IntPtr gbm, SurfaceFormat format, SurfaceFlags usage);

		// Token: 0x06005BBC RID: 23484
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_surface_lock_front_buffer")]
		public static extern BufferObject LockFrontBuffer(IntPtr surface);

		// Token: 0x06005BBD RID: 23485
		[DllImport("gbm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "gbm_surface_release_buffer")]
		public static extern void ReleaseBuffer(IntPtr surface, BufferObject buffer);

		// Token: 0x0400B845 RID: 47173
		private const string lib = "gbm";
	}
}
