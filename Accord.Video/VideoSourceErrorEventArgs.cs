using System;

namespace Accord.Video
{
	// Token: 0x02000011 RID: 17
	public class VideoSourceErrorEventArgs : EventArgs
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x00003FA3 File Offset: 0x00002FA3
		public VideoSourceErrorEventArgs(string description) : this(description, null)
		{
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003FAD File Offset: 0x00002FAD
		public VideoSourceErrorEventArgs(string description, Exception exception)
		{
			this._description = description;
			this._exception = exception;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00003FC3 File Offset: 0x00002FC3
		public string Description
		{
			get
			{
				return this._description;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00003FCB File Offset: 0x00002FCB
		public Exception Exception
		{
			get
			{
				return this._exception;
			}
		}

		// Token: 0x0400004C RID: 76
		private readonly string _description;

		// Token: 0x0400004D RID: 77
		private readonly Exception _exception;
	}
}
