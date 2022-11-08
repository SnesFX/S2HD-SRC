using System;
using System.Drawing;

namespace OpenTK.Input
{
	// Token: 0x02000B3A RID: 2874
	public class MouseEventArgs : EventArgs
	{
		// Token: 0x06005AB7 RID: 23223 RVA: 0x000F659C File Offset: 0x000F479C
		public MouseEventArgs()
		{
			this.state.SetIsConnected(true);
		}

		// Token: 0x06005AB8 RID: 23224 RVA: 0x000F65B0 File Offset: 0x000F47B0
		public MouseEventArgs(int x, int y) : this()
		{
			this.state.X = x;
			this.state.Y = y;
		}

		// Token: 0x06005AB9 RID: 23225 RVA: 0x000F65D0 File Offset: 0x000F47D0
		public MouseEventArgs(MouseEventArgs args) : this(args.X, args.Y)
		{
		}

		// Token: 0x06005ABA RID: 23226 RVA: 0x000F65E4 File Offset: 0x000F47E4
		internal void SetButton(MouseButton button, ButtonState state)
		{
			if (button < MouseButton.Left || button > MouseButton.LastButton)
			{
				throw new ArgumentOutOfRangeException();
			}
			switch (state)
			{
			case ButtonState.Released:
				this.state.DisableBit((int)button);
				return;
			case ButtonState.Pressed:
				this.state.EnableBit((int)button);
				return;
			default:
				return;
			}
		}

		// Token: 0x06005ABB RID: 23227 RVA: 0x000F662C File Offset: 0x000F482C
		internal ButtonState GetButton(MouseButton button)
		{
			if (button < MouseButton.Left || button > MouseButton.LastButton)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (!this.state.ReadBit((int)button))
			{
				return ButtonState.Released;
			}
			return ButtonState.Pressed;
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06005ABC RID: 23228 RVA: 0x000F6650 File Offset: 0x000F4850
		// (set) Token: 0x06005ABD RID: 23229 RVA: 0x000F6660 File Offset: 0x000F4860
		public int X
		{
			get
			{
				return this.state.X;
			}
			internal set
			{
				this.state.X = value;
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06005ABE RID: 23230 RVA: 0x000F6670 File Offset: 0x000F4870
		// (set) Token: 0x06005ABF RID: 23231 RVA: 0x000F6680 File Offset: 0x000F4880
		public int Y
		{
			get
			{
				return this.state.Y;
			}
			internal set
			{
				this.state.Y = value;
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06005AC0 RID: 23232 RVA: 0x000F6690 File Offset: 0x000F4890
		// (set) Token: 0x06005AC1 RID: 23233 RVA: 0x000F66B0 File Offset: 0x000F48B0
		public Point Position
		{
			get
			{
				return new Point(this.state.X, this.state.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06005AC2 RID: 23234 RVA: 0x000F66CC File Offset: 0x000F48CC
		// (set) Token: 0x06005AC3 RID: 23235 RVA: 0x000F66D4 File Offset: 0x000F48D4
		public MouseState Mouse
		{
			get
			{
				return this.state;
			}
			internal set
			{
				this.state = value;
			}
		}

		// Token: 0x0400B69B RID: 46747
		private MouseState state;
	}
}
