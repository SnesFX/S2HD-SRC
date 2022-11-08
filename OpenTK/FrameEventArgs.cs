using System;

namespace OpenTK
{
	// Token: 0x02000055 RID: 85
	public class FrameEventArgs : EventArgs
	{
		// Token: 0x06000625 RID: 1573 RVA: 0x00016884 File Offset: 0x00014A84
		public FrameEventArgs()
		{
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001688C File Offset: 0x00014A8C
		public FrameEventArgs(double elapsed)
		{
			this.Time = elapsed;
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x0001689C File Offset: 0x00014A9C
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x000168A4 File Offset: 0x00014AA4
		public double Time
		{
			get
			{
				return this.elapsed;
			}
			internal set
			{
				if (value <= 0.0)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.elapsed = value;
			}
		}

		// Token: 0x04000194 RID: 404
		private double elapsed;
	}
}
