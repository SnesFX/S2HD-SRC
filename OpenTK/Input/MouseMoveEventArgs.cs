using System;

namespace OpenTK.Input
{
	// Token: 0x02000B3B RID: 2875
	public class MouseMoveEventArgs : MouseEventArgs
	{
		// Token: 0x06005AC4 RID: 23236 RVA: 0x000F66E0 File Offset: 0x000F48E0
		public MouseMoveEventArgs()
		{
		}

		// Token: 0x06005AC5 RID: 23237 RVA: 0x000F66E8 File Offset: 0x000F48E8
		public MouseMoveEventArgs(int x, int y, int xDelta, int yDelta) : base(x, y)
		{
			this.XDelta = xDelta;
			this.YDelta = yDelta;
		}

		// Token: 0x06005AC6 RID: 23238 RVA: 0x000F6704 File Offset: 0x000F4904
		public MouseMoveEventArgs(MouseMoveEventArgs args) : this(args.X, args.Y, args.XDelta, args.YDelta)
		{
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06005AC7 RID: 23239 RVA: 0x000F6724 File Offset: 0x000F4924
		// (set) Token: 0x06005AC8 RID: 23240 RVA: 0x000F672C File Offset: 0x000F492C
		public int XDelta
		{
			get
			{
				return this.x_delta;
			}
			internal set
			{
				this.x_delta = value;
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06005AC9 RID: 23241 RVA: 0x000F6738 File Offset: 0x000F4938
		// (set) Token: 0x06005ACA RID: 23242 RVA: 0x000F6740 File Offset: 0x000F4940
		public int YDelta
		{
			get
			{
				return this.y_delta;
			}
			internal set
			{
				this.y_delta = value;
			}
		}

		// Token: 0x0400B69C RID: 46748
		private int x_delta;

		// Token: 0x0400B69D RID: 46749
		private int y_delta;
	}
}
