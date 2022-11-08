using System;

namespace OpenTK
{
	// Token: 0x0200004F RID: 79
	public class KeyPressEventArgs : EventArgs
	{
		// Token: 0x06000568 RID: 1384 RVA: 0x00014BF0 File Offset: 0x00012DF0
		public KeyPressEventArgs(char keyChar)
		{
			this.KeyChar = keyChar;
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x00014C00 File Offset: 0x00012E00
		// (set) Token: 0x0600056A RID: 1386 RVA: 0x00014C08 File Offset: 0x00012E08
		public char KeyChar
		{
			get
			{
				return this.key_char;
			}
			internal set
			{
				this.key_char = value;
			}
		}

		// Token: 0x04000155 RID: 341
		private char key_char;
	}
}
