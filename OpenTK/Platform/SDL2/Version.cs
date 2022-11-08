using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005E2 RID: 1506
	internal struct Version
	{
		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x060046DF RID: 18143 RVA: 0x000C3524 File Offset: 0x000C1724
		public int Number
		{
			get
			{
				return 1000 * (int)this.Major + (int)(100 * this.Minor) + (int)this.Patch;
			}
		}

		// Token: 0x0400558B RID: 21899
		public byte Major;

		// Token: 0x0400558C RID: 21900
		public byte Minor;

		// Token: 0x0400558D RID: 21901
		public byte Patch;
	}
}
