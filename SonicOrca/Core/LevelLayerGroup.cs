using System;
using System.Collections.Generic;

namespace SonicOrca.Core
{
	// Token: 0x0200011E RID: 286
	public class LevelLayerGroup : ILevelLayerTreeNode
	{
		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000A97 RID: 2711 RVA: 0x0002978D File Offset: 0x0002798D
		// (set) Token: 0x06000A98 RID: 2712 RVA: 0x00029795 File Offset: 0x00027995
		public string Name { get; set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x0002979E File Offset: 0x0002799E
		// (set) Token: 0x06000A9A RID: 2714 RVA: 0x000297A6 File Offset: 0x000279A6
		public bool Editing { get; set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x000297AF File Offset: 0x000279AF
		// (set) Token: 0x06000A9C RID: 2716 RVA: 0x000297B7 File Offset: 0x000279B7
		public bool Visible { get; set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x000297C0 File Offset: 0x000279C0
		public IList<ILevelLayerTreeNode> Children
		{
			get
			{
				return this._children;
			}
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x000297C8 File Offset: 0x000279C8
		public LevelLayerGroup(string name)
		{
			this.Name = name;
			this.Visible = true;
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x000297E9 File Offset: 0x000279E9
		public override string ToString()
		{
			return string.Format("[{0}]", this.Name);
		}

		// Token: 0x04000632 RID: 1586
		private readonly List<ILevelLayerTreeNode> _children = new List<ILevelLayerTreeNode>();
	}
}
