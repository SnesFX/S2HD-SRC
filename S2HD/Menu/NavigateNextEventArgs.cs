using System;

namespace S2HD.Menu
{
	// Token: 0x020000B7 RID: 183
	internal class NavigateNextEventArgs : EventArgs
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x0001DD6C File Offset: 0x0001BF6C
		public IMenuViewModel ViewModel { get; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x0001DD74 File Offset: 0x0001BF74
		public object Tag { get; }

		// Token: 0x06000466 RID: 1126 RVA: 0x0001DD7C File Offset: 0x0001BF7C
		public NavigateNextEventArgs(IMenuViewModel viewModel, object tag)
		{
			this.ViewModel = viewModel;
			this.Tag = tag;
		}
	}
}
