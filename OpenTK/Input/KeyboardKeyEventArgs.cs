using System;

namespace OpenTK.Input
{
	// Token: 0x02000524 RID: 1316
	public class KeyboardKeyEventArgs : EventArgs
	{
		// Token: 0x06003DA7 RID: 15783 RVA: 0x000A2030 File Offset: 0x000A0230
		public KeyboardKeyEventArgs()
		{
		}

		// Token: 0x06003DA8 RID: 15784 RVA: 0x000A2038 File Offset: 0x000A0238
		public KeyboardKeyEventArgs(KeyboardKeyEventArgs args)
		{
			this.Key = args.Key;
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06003DA9 RID: 15785 RVA: 0x000A204C File Offset: 0x000A024C
		// (set) Token: 0x06003DAA RID: 15786 RVA: 0x000A2054 File Offset: 0x000A0254
		public Key Key
		{
			get
			{
				return this.key;
			}
			internal set
			{
				this.key = value;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06003DAB RID: 15787 RVA: 0x000A2060 File Offset: 0x000A0260
		[CLSCompliant(false)]
		public uint ScanCode
		{
			get
			{
				return (uint)this.Key;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06003DAC RID: 15788 RVA: 0x000A2068 File Offset: 0x000A0268
		public bool Alt
		{
			get
			{
				return this.state[Key.AltLeft] || this.state[Key.AltRight];
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06003DAD RID: 15789 RVA: 0x000A2088 File Offset: 0x000A0288
		public bool Control
		{
			get
			{
				return this.state[Key.ControlLeft] || this.state[Key.ControlRight];
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06003DAE RID: 15790 RVA: 0x000A20A8 File Offset: 0x000A02A8
		public bool Shift
		{
			get
			{
				return this.state[Key.ShiftLeft] || this.state[Key.ShiftRight];
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06003DAF RID: 15791 RVA: 0x000A20C8 File Offset: 0x000A02C8
		public KeyModifiers Modifiers
		{
			get
			{
				KeyModifiers keyModifiers = (KeyModifiers)0;
				keyModifiers |= (this.Alt ? KeyModifiers.Alt : ((KeyModifiers)0));
				keyModifiers |= (this.Control ? KeyModifiers.Control : ((KeyModifiers)0));
				return keyModifiers | (this.Shift ? KeyModifiers.Shift : ((KeyModifiers)0));
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06003DB0 RID: 15792 RVA: 0x000A2108 File Offset: 0x000A0308
		// (set) Token: 0x06003DB1 RID: 15793 RVA: 0x000A2110 File Offset: 0x000A0310
		public KeyboardState Keyboard
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

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06003DB2 RID: 15794 RVA: 0x000A211C File Offset: 0x000A031C
		// (set) Token: 0x06003DB3 RID: 15795 RVA: 0x000A2124 File Offset: 0x000A0324
		public bool IsRepeat
		{
			get
			{
				return this.repeat;
			}
			internal set
			{
				this.repeat = value;
			}
		}

		// Token: 0x04004DCD RID: 19917
		private Key key;

		// Token: 0x04004DCE RID: 19918
		private bool repeat;

		// Token: 0x04004DCF RID: 19919
		private KeyboardState state;
	}
}
