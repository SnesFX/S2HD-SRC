using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B2D RID: 2861
	internal sealed class CarbonWindowInfo : IWindowInfo, IDisposable
	{
		// Token: 0x06005A8E RID: 23182 RVA: 0x000F63C8 File Offset: 0x000F45C8
		public CarbonWindowInfo(IntPtr windowRef, bool ownHandle, bool isControl)
		{
			this.windowRef = windowRef;
			this.ownHandle = ownHandle;
			this.isControl = isControl;
		}

		// Token: 0x06005A8F RID: 23183 RVA: 0x000F63EC File Offset: 0x000F45EC
		public CarbonWindowInfo(IntPtr windowRef, bool ownHandle, bool isControl, GetInt getX, GetInt getY) : this(windowRef, ownHandle, isControl)
		{
			this.xOffset = getX;
			this.yOffset = getY;
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06005A90 RID: 23184 RVA: 0x000F6408 File Offset: 0x000F4608
		// (set) Token: 0x06005A91 RID: 23185 RVA: 0x000F6410 File Offset: 0x000F4610
		public IntPtr Handle
		{
			get
			{
				return this.windowRef;
			}
			set
			{
				this.windowRef = value;
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06005A92 RID: 23186 RVA: 0x000F641C File Offset: 0x000F461C
		// (set) Token: 0x06005A93 RID: 23187 RVA: 0x000F6424 File Offset: 0x000F4624
		internal bool GoFullScreenHack
		{
			get
			{
				return this.goFullScreenHack;
			}
			set
			{
				this.goFullScreenHack = value;
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06005A94 RID: 23188 RVA: 0x000F6430 File Offset: 0x000F4630
		// (set) Token: 0x06005A95 RID: 23189 RVA: 0x000F6438 File Offset: 0x000F4638
		internal bool GoWindowedHack
		{
			get
			{
				return this.goWindowedHack;
			}
			set
			{
				this.goWindowedHack = value;
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06005A96 RID: 23190 RVA: 0x000F6444 File Offset: 0x000F4644
		public bool IsControl
		{
			get
			{
				return this.isControl;
			}
		}

		// Token: 0x06005A97 RID: 23191 RVA: 0x000F644C File Offset: 0x000F464C
		public override string ToString()
		{
			return string.Format("MacOS.CarbonWindowInfo: Handle {0}", this.Handle);
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06005A98 RID: 23192 RVA: 0x000F6464 File Offset: 0x000F4664
		// (set) Token: 0x06005A99 RID: 23193 RVA: 0x000F646C File Offset: 0x000F466C
		public IntPtr WindowHandle
		{
			get
			{
				return this.Handle;
			}
			set
			{
				this.Handle = value;
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06005A9A RID: 23194 RVA: 0x000F6478 File Offset: 0x000F4678
		// (set) Token: 0x06005A9B RID: 23195 RVA: 0x000F6480 File Offset: 0x000F4680
		public GetInt XOffset
		{
			get
			{
				return this.xOffset;
			}
			set
			{
				this.xOffset = value;
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06005A9C RID: 23196 RVA: 0x000F648C File Offset: 0x000F468C
		// (set) Token: 0x06005A9D RID: 23197 RVA: 0x000F6494 File Offset: 0x000F4694
		public GetInt YOffset
		{
			get
			{
				return this.yOffset;
			}
			set
			{
				this.yOffset = value;
			}
		}

		// Token: 0x06005A9E RID: 23198 RVA: 0x000F64A0 File Offset: 0x000F46A0
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x06005A9F RID: 23199 RVA: 0x000F64AC File Offset: 0x000F46AC
		private void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}
			if (this.ownHandle)
			{
				this.windowRef = IntPtr.Zero;
			}
			this.disposed = true;
		}

		// Token: 0x06005AA0 RID: 23200 RVA: 0x000F64D4 File Offset: 0x000F46D4
		~CarbonWindowInfo()
		{
			this.Dispose(false);
		}

		// Token: 0x0400B5F0 RID: 46576
		private IntPtr windowRef;

		// Token: 0x0400B5F1 RID: 46577
		private bool ownHandle;

		// Token: 0x0400B5F2 RID: 46578
		private bool disposed;

		// Token: 0x0400B5F3 RID: 46579
		private bool isControl = true;

		// Token: 0x0400B5F4 RID: 46580
		private bool goFullScreenHack;

		// Token: 0x0400B5F5 RID: 46581
		private bool goWindowedHack;

		// Token: 0x0400B5F6 RID: 46582
		private GetInt xOffset;

		// Token: 0x0400B5F7 RID: 46583
		private GetInt yOffset;
	}
}
