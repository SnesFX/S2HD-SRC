using System;

namespace S2HD.Menu
{
	// Token: 0x020000B3 RID: 179
	internal class MenuItem : IMenuItem
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0001D30C File Offset: 0x0001B50C
		public string Text { get; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x0001D314 File Offset: 0x0001B514
		public IMenuViewModel Next { get; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0001D31C File Offset: 0x0001B51C
		public object Tag { get; }

		// Token: 0x0600043C RID: 1084 RVA: 0x0001D324 File Offset: 0x0001B524
		public MenuItem(string text, IMenuViewModel next = null, object tag = null)
		{
			this.Text = text;
			this.Next = next;
			this.Tag = tag;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0001D341 File Offset: 0x0001B541
		public override string ToString()
		{
			return this.Text;
		}
	}
}
