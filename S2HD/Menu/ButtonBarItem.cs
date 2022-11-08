using System;

namespace S2HD.Menu
{
	// Token: 0x020000AB RID: 171
	public struct ButtonBarItem
	{
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x0001CF5E File Offset: 0x0001B15E
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x0001CF66 File Offset: 0x0001B166
		public GamePadButton Button { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0001CF6F File Offset: 0x0001B16F
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x0001CF77 File Offset: 0x0001B177
		public string Text { get; set; }
	}
}
