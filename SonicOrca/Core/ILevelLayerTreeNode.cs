using System;
using System.Collections.Generic;

namespace SonicOrca.Core
{
	// Token: 0x0200011A RID: 282
	public interface ILevelLayerTreeNode
	{
		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000A84 RID: 2692
		// (set) Token: 0x06000A85 RID: 2693
		string Name { get; set; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000A86 RID: 2694
		// (set) Token: 0x06000A87 RID: 2695
		bool Editing { get; set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000A88 RID: 2696
		// (set) Token: 0x06000A89 RID: 2697
		bool Visible { get; set; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000A8A RID: 2698
		IList<ILevelLayerTreeNode> Children { get; }
	}
}
