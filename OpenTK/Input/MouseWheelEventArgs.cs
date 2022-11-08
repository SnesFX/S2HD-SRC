using System;

namespace OpenTK.Input
{
	// Token: 0x02000B3D RID: 2877
	public class MouseWheelEventArgs : MouseEventArgs
	{
		// Token: 0x06005AD2 RID: 23250 RVA: 0x000F67D0 File Offset: 0x000F49D0
		public MouseWheelEventArgs()
		{
		}

		// Token: 0x06005AD3 RID: 23251 RVA: 0x000F67D8 File Offset: 0x000F49D8
		public MouseWheelEventArgs(int x, int y, int value, int delta) : base(x, y)
		{
			base.Mouse.SetScrollAbsolute(base.Mouse.Scroll.X, (float)value);
			this.delta = (float)delta;
		}

		// Token: 0x06005AD4 RID: 23252 RVA: 0x000F681C File Offset: 0x000F4A1C
		public MouseWheelEventArgs(MouseWheelEventArgs args) : this(args.X, args.Y, args.Value, args.Delta)
		{
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06005AD5 RID: 23253 RVA: 0x000F683C File Offset: 0x000F4A3C
		public int Value
		{
			get
			{
				return (int)Math.Round((double)base.Mouse.Scroll.Y, MidpointRounding.AwayFromZero);
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06005AD6 RID: 23254 RVA: 0x000F6868 File Offset: 0x000F4A68
		public int Delta
		{
			get
			{
				return (int)Math.Round((double)this.delta, MidpointRounding.AwayFromZero);
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06005AD7 RID: 23255 RVA: 0x000F6878 File Offset: 0x000F4A78
		public float ValuePrecise
		{
			get
			{
				return base.Mouse.Scroll.Y;
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06005AD8 RID: 23256 RVA: 0x000F689C File Offset: 0x000F4A9C
		// (set) Token: 0x06005AD9 RID: 23257 RVA: 0x000F68A4 File Offset: 0x000F4AA4
		public float DeltaPrecise
		{
			get
			{
				return this.delta;
			}
			internal set
			{
				this.delta = value;
			}
		}

		// Token: 0x0400B6A0 RID: 46752
		private float delta;
	}
}
