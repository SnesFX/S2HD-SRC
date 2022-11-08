using System;
using System.Drawing;

namespace Accord.Video
{
	// Token: 0x02000010 RID: 16
	public class NewFrameEventArgs : EventArgs
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x00003F8C File Offset: 0x00002F8C
		public NewFrameEventArgs(Bitmap frame)
		{
			this.frame = frame;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00003F9B File Offset: 0x00002F9B
		public Bitmap Frame
		{
			get
			{
				return this.frame;
			}
		}

		// Token: 0x0400004B RID: 75
		private Bitmap frame;
	}
}
