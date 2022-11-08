using System;

namespace OpenTK.Input
{
	// Token: 0x02000B3C RID: 2876
	public class MouseButtonEventArgs : MouseEventArgs
	{
		// Token: 0x06005ACB RID: 23243 RVA: 0x000F674C File Offset: 0x000F494C
		public MouseButtonEventArgs()
		{
		}

		// Token: 0x06005ACC RID: 23244 RVA: 0x000F6754 File Offset: 0x000F4954
		public MouseButtonEventArgs(int x, int y, MouseButton button, bool pressed) : base(x, y)
		{
			this.button = button;
			this.pressed = pressed;
		}

		// Token: 0x06005ACD RID: 23245 RVA: 0x000F6770 File Offset: 0x000F4970
		public MouseButtonEventArgs(MouseButtonEventArgs args) : this(args.X, args.Y, args.Button, args.IsPressed)
		{
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06005ACE RID: 23246 RVA: 0x000F6790 File Offset: 0x000F4990
		// (set) Token: 0x06005ACF RID: 23247 RVA: 0x000F6798 File Offset: 0x000F4998
		public MouseButton Button
		{
			get
			{
				return this.button;
			}
			internal set
			{
				this.button = value;
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06005AD0 RID: 23248 RVA: 0x000F67A4 File Offset: 0x000F49A4
		// (set) Token: 0x06005AD1 RID: 23249 RVA: 0x000F67B8 File Offset: 0x000F49B8
		public bool IsPressed
		{
			get
			{
				return base.GetButton(this.Button) == ButtonState.Pressed;
			}
			internal set
			{
				base.SetButton(this.Button, value ? ButtonState.Pressed : ButtonState.Released);
			}
		}

		// Token: 0x0400B69E RID: 46750
		private MouseButton button;

		// Token: 0x0400B69F RID: 46751
		private bool pressed;
	}
}
