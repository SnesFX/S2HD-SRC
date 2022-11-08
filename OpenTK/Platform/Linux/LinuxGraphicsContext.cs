using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics;
using OpenTK.Platform.Egl;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B88 RID: 2952
	internal class LinuxGraphicsContext : EglUnixContext
	{
		// Token: 0x06005C0A RID: 23562 RVA: 0x000F9A98 File Offset: 0x000F7C98
		public LinuxGraphicsContext(GraphicsMode mode, LinuxWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags) : base(mode, window, sharedContext, major, minor, flags)
		{
			if (mode.Buffers < 1)
			{
				throw new ArgumentException();
			}
			this.fd = window.FD;
			this.PageFlip = new PageFlipCallback(this.HandlePageFlip);
			this.PageFlipPtr = Marshal.GetFunctionPointerForDelegate(this.PageFlip);
		}

		// Token: 0x06005C0B RID: 23563 RVA: 0x000F9AF4 File Offset: 0x000F7CF4
		public override void SwapBuffers()
		{
			base.SwapBuffers();
			this.bo_next = this.LockSurface();
			int framebuffer = this.GetFramebuffer(this.bo_next);
			if (this.is_flip_queued)
			{
				this.WaitFlip(true);
				if (this.is_flip_queued)
				{
					return;
				}
			}
			this.QueueFlip(framebuffer);
		}

		// Token: 0x06005C0C RID: 23564 RVA: 0x000F9B40 File Offset: 0x000F7D40
		public override void Update(IWindowInfo window)
		{
			this.WaitFlip(true);
			base.SwapBuffers();
			this.bo = this.LockSurface();
			int framebuffer = this.GetFramebuffer(this.bo);
			this.SetScanoutRegion(framebuffer);
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06005C0D RID: 23565 RVA: 0x000F9B7C File Offset: 0x000F7D7C
		// (set) Token: 0x06005C0E RID: 23566 RVA: 0x000F9B84 File Offset: 0x000F7D84
		public override int SwapInterval
		{
			get
			{
				return this.swap_interval;
			}
			set
			{
				this.swap_interval = MathHelper.Clamp(value, 0, 1);
			}
		}

		// Token: 0x06005C0F RID: 23567 RVA: 0x000F9B94 File Offset: 0x000F7D94
		private void WaitFlip(bool block)
		{
			PollFD pollFD = default(PollFD);
			pollFD.fd = this.fd;
			pollFD.events = PollFlags.In;
			EventContext eventContext = default(EventContext);
			eventContext.version = EventContext.Version;
			eventContext.page_flip_handler = this.PageFlipPtr;
			int timeout = block ? -1 : 0;
			while (this.is_flip_queued)
			{
				pollFD.revents = (PollFlags)0;
				if (Libc.poll(ref pollFD, 1, timeout) < 0 || (short)(pollFD.revents & (PollFlags.Error | PollFlags.Hup)) != 0 || (short)(pollFD.revents & PollFlags.In) == 0)
				{
					break;
				}
				Drm.HandleEvent(this.fd, ref eventContext);
			}
			if (!this.is_flip_queued)
			{
				IntPtr handle = this.WindowInfo.Handle;
				Gbm.ReleaseBuffer(handle, this.bo);
				this.bo = this.bo_next;
			}
		}

		// Token: 0x06005C10 RID: 23568 RVA: 0x000F9C58 File Offset: 0x000F7E58
		private void QueueFlip(int buffer)
		{
			LinuxWindowInfo linuxWindowInfo = this.WindowInfo as LinuxWindowInfo;
			if (linuxWindowInfo == null)
			{
				throw new InvalidOperationException();
			}
			int num = Drm.ModePageFlip(this.fd, linuxWindowInfo.DisplayDevice.Id, buffer, PageFlipFlags.FlipEvent, IntPtr.Zero);
			this.is_flip_queued = true;
		}

		// Token: 0x06005C11 RID: 23569 RVA: 0x000F9CA4 File Offset: 0x000F7EA4
		private unsafe void SetScanoutRegion(int buffer)
		{
			LinuxWindowInfo linuxWindowInfo = this.WindowInfo as LinuxWindowInfo;
			if (linuxWindowInfo == null)
			{
				throw new InvalidOperationException();
			}
			ModeInfo* modes = linuxWindowInfo.DisplayDevice.pConnector->modes;
			int connector_id = linuxWindowInfo.DisplayDevice.pConnector->connector_id;
			int id = linuxWindowInfo.DisplayDevice.Id;
			int x = 0;
			int y = 0;
			int count = 1;
			int num = Drm.ModeSetCrtc(this.fd, id, buffer, x, y, &connector_id, count, modes);
		}

		// Token: 0x06005C12 RID: 23570 RVA: 0x000F9D1C File Offset: 0x000F7F1C
		private BufferObject LockSurface()
		{
			IntPtr handle = this.WindowInfo.Handle;
			return Gbm.LockFrontBuffer(handle);
		}

		// Token: 0x06005C13 RID: 23571 RVA: 0x000F9D3C File Offset: 0x000F7F3C
		private int GetFramebuffer(BufferObject bo)
		{
			if (!(bo == BufferObject.Zero))
			{
				int handle = bo.Handle;
				if (handle != 0)
				{
					int width = bo.Width;
					int height = bo.Height;
					int bitsPerPixel = this.Mode.ColorFormat.BitsPerPixel;
					int depth = this.Mode.Depth;
					int stride = bo.Stride;
					int num;
					if (width != 0 && height != 0 && bitsPerPixel != 0 && Drm.ModeAddFB(this.fd, width, height, (byte)depth, (byte)bitsPerPixel, stride, handle, out num) == 0)
					{
						bo.SetUserData((IntPtr)num, LinuxGraphicsContext.DestroyFB);
						return num;
					}
				}
			}
			return -1;
		}

		// Token: 0x06005C14 RID: 23572 RVA: 0x000F9DDC File Offset: 0x000F7FDC
		private void HandlePageFlip(int fd, int sequence, int tv_sec, int tv_usec, IntPtr user_data)
		{
			this.is_flip_queued = false;
		}

		// Token: 0x06005C15 RID: 23573 RVA: 0x000F9DE8 File Offset: 0x000F7FE8
		private static void HandleDestroyFB(BufferObject bo, IntPtr data)
		{
			IntPtr device = bo.Device;
			int num = data.ToInt32();
			if (num != 0)
			{
				Drm.ModeRmFB(Gbm.DeviceGetFD(device), num);
			}
		}

		// Token: 0x06005C16 RID: 23574 RVA: 0x000F9E18 File Offset: 0x000F8018
		protected unsafe override void Dispose(bool manual)
		{
			if (manual)
			{
				LinuxWindowInfo linuxWindowInfo = this.WindowInfo as LinuxWindowInfo;
				if (linuxWindowInfo != null)
				{
					int connector_id = linuxWindowInfo.DisplayDevice.pConnector->connector_id;
					ModeInfo originalMode = linuxWindowInfo.DisplayDevice.OriginalMode;
					Drm.ModeSetCrtc(this.fd, linuxWindowInfo.DisplayDevice.pCrtc->crtc_id, linuxWindowInfo.DisplayDevice.pCrtc->buffer_id, linuxWindowInfo.DisplayDevice.pCrtc->x, linuxWindowInfo.DisplayDevice.pCrtc->y, &connector_id, 1, &originalMode);
				}
			}
			base.Dispose(manual);
		}

		// Token: 0x0400B8CB RID: 47307
		private BufferObject bo;

		// Token: 0x0400B8CC RID: 47308
		private BufferObject bo_next;

		// Token: 0x0400B8CD RID: 47309
		private int fd;

		// Token: 0x0400B8CE RID: 47310
		private bool is_flip_queued;

		// Token: 0x0400B8CF RID: 47311
		private int swap_interval;

		// Token: 0x0400B8D0 RID: 47312
		private readonly IntPtr PageFlipPtr;

		// Token: 0x0400B8D1 RID: 47313
		private readonly PageFlipCallback PageFlip;

		// Token: 0x0400B8D2 RID: 47314
		private static readonly DestroyUserDataCallback DestroyFB = new DestroyUserDataCallback(LinuxGraphicsContext.HandleDestroyFB);
	}
}
