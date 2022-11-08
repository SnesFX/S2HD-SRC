using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B79 RID: 2937
	internal class LinuxDisplay
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06005BCE RID: 23502 RVA: 0x000F8C78 File Offset: 0x000F6E78
		public unsafe ModeConnector* pConnector
		{
			get
			{
				return (ModeConnector*)((void*)this.Connector);
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06005BCF RID: 23503 RVA: 0x000F8C88 File Offset: 0x000F6E88
		public unsafe ModeCrtc* pCrtc
		{
			get
			{
				return (ModeCrtc*)((void*)this.Crtc);
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06005BD0 RID: 23504 RVA: 0x000F8C98 File Offset: 0x000F6E98
		public unsafe ModeEncoder* pEncoder
		{
			get
			{
				return (ModeEncoder*)((void*)this.Encoder);
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06005BD1 RID: 23505 RVA: 0x000F8CA8 File Offset: 0x000F6EA8
		public unsafe int Id
		{
			get
			{
				if (this.Crtc == IntPtr.Zero)
				{
					throw new InvalidOperationException();
				}
				return this.pCrtc->crtc_id;
			}
		}

		// Token: 0x06005BD2 RID: 23506 RVA: 0x000F8CD0 File Offset: 0x000F6ED0
		public unsafe LinuxDisplay(int fd, IntPtr c, IntPtr e, IntPtr r)
		{
			this.FD = fd;
			this.Connector = c;
			this.Encoder = e;
			this.Crtc = r;
			this.OriginalMode = this.pCrtc->mode;
		}

		// Token: 0x0400B889 RID: 47241
		public int FD;

		// Token: 0x0400B88A RID: 47242
		public IntPtr Connector;

		// Token: 0x0400B88B RID: 47243
		public IntPtr Crtc;

		// Token: 0x0400B88C RID: 47244
		public IntPtr Encoder;

		// Token: 0x0400B88D RID: 47245
		public ModeInfo OriginalMode;
	}
}
