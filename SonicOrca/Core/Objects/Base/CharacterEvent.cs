using System;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x0200016A RID: 362
	[Flags]
	public enum CharacterEvent
	{
		// Token: 0x040008FB RID: 2299
		Fall = 1,
		// Token: 0x040008FC RID: 2300
		Jump = 2,
		// Token: 0x040008FD RID: 2301
		DoubleJump = 4,
		// Token: 0x040008FE RID: 2302
		SpindashLaunch = 8,
		// Token: 0x040008FF RID: 2303
		Fly = 16,
		// Token: 0x04000900 RID: 2304
		BarrierAttack = 32,
		// Token: 0x04000901 RID: 2305
		Hurt = 64
	}
}
