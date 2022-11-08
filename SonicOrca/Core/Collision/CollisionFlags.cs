using System;

namespace SonicOrca.Core.Collision
{
	// Token: 0x02000197 RID: 407
	[Flags]
	public enum CollisionFlags
	{
		// Token: 0x040009CC RID: 2508
		Mobile = 1,
		// Token: 0x040009CD RID: 2509
		Conveyor = 2,
		// Token: 0x040009CE RID: 2510
		Reacts = 4,
		// Token: 0x040009CF RID: 2511
		Rotate = 8,
		// Token: 0x040009D0 RID: 2512
		ForceRoll = 16,
		// Token: 0x040009D1 RID: 2513
		PreventJump = 32,
		// Token: 0x040009D2 RID: 2514
		DontFall = 64,
		// Token: 0x040009D3 RID: 2515
		NoAngle = 128,
		// Token: 0x040009D4 RID: 2516
		NoLanding = 256,
		// Token: 0x040009D5 RID: 2517
		Snap = 512,
		// Token: 0x040009D6 RID: 2518
		NoBalance = 1024,
		// Token: 0x040009D7 RID: 2519
		Solid = 2048,
		// Token: 0x040009D8 RID: 2520
		NoPathFollowing = 4096,
		// Token: 0x040009D9 RID: 2521
		Ignore = 8192,
		// Token: 0x040009DA RID: 2522
		NoAutoAlignment = 16384
	}
}
