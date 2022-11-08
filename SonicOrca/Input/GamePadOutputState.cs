using System;

namespace SonicOrca.Input
{
	// Token: 0x020000AC RID: 172
	public struct GamePadOutputState
	{
		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x0001BE55 File Offset: 0x0001A055
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x0001BE5D File Offset: 0x0001A05D
		public double LeftVibration { get; set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x0001BE66 File Offset: 0x0001A066
		// (set) Token: 0x060005C5 RID: 1477 RVA: 0x0001BE6E File Offset: 0x0001A06E
		public double RightVibration { get; set; }
	}
}
