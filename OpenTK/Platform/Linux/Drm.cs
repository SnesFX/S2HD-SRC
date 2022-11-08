using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B67 RID: 2919
	internal class Drm
	{
		// Token: 0x06005B6B RID: 23403
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmHandleEvent")]
		public static extern int HandleEvent(int fd, ref EventContext evctx);

		// Token: 0x06005B6C RID: 23404
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeAddFB")]
		public static extern int ModeAddFB(int fd, int width, int height, byte depth, byte bpp, int pitch, int bo_handle, out int buf_id);

		// Token: 0x06005B6D RID: 23405
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeRmFB")]
		public static extern int ModeRmFB(int fd, int bufferId);

		// Token: 0x06005B6E RID: 23406
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeFreeCrtc")]
		public static extern void ModeFreeCrtc(IntPtr ptr);

		// Token: 0x06005B6F RID: 23407
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeGetCrtc")]
		public static extern IntPtr ModeGetCrtc(int fd, int crtcId);

		// Token: 0x06005B70 RID: 23408
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeFreeConnector")]
		public static extern void ModeFreeConnector(IntPtr ptr);

		// Token: 0x06005B71 RID: 23409
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeFreeEncoder")]
		public static extern void ModeFreeEncoder(IntPtr ptr);

		// Token: 0x06005B72 RID: 23410
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeGetConnector")]
		public static extern IntPtr ModeGetConnector(int fd, int connector_id);

		// Token: 0x06005B73 RID: 23411
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeGetEncoder")]
		public static extern IntPtr ModeGetEncoder(int fd, int encoder_id);

		// Token: 0x06005B74 RID: 23412
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeGetResources")]
		public static extern IntPtr ModeGetResources(int fd);

		// Token: 0x06005B75 RID: 23413
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModePageFlip")]
		public static extern int ModePageFlip(int fd, int crtc_id, int fb_id, PageFlipFlags flags, IntPtr user_data);

		// Token: 0x06005B76 RID: 23414
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeSetCrtc")]
		public unsafe static extern int ModeSetCrtc(int fd, int crtcId, int bufferId, int x, int y, int* connectors, int count, ModeInfo* mode);

		// Token: 0x06005B77 RID: 23415
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeSetCursor2")]
		public static extern int SetCursor(int fd, int crtcId, int bo_handle, int width, int height, int hot_x, int hot_y);

		// Token: 0x06005B78 RID: 23416
		[DllImport("libdrm", CallingConvention = CallingConvention.Cdecl, EntryPoint = "drmModeMoveCursor")]
		public static extern int MoveCursor(int fd, int crtcId, int x, int y);

		// Token: 0x0400B7E2 RID: 47074
		private const string lib = "libdrm";
	}
}
