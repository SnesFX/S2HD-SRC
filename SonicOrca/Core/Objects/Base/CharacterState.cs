using System;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x0200016F RID: 367
	[Flags]
	public enum CharacterState
	{
		// Token: 0x04000915 RID: 2325
		Balancing = 2,
		// Token: 0x04000916 RID: 2326
		Pushing = 4,
		// Token: 0x04000917 RID: 2327
		Braking = 8,
		// Token: 0x04000918 RID: 2328
		Spinball = 16,
		// Token: 0x04000919 RID: 2329
		Rolling = 32,
		// Token: 0x0400091A RID: 2330
		Airborne = 64,
		// Token: 0x0400091B RID: 2331
		Jumping = 128,
		// Token: 0x0400091C RID: 2332
		Left = 256,
		// Token: 0x0400091D RID: 2333
		Underwater = 512,
		// Token: 0x0400091E RID: 2334
		Hurt = 1024,
		// Token: 0x0400091F RID: 2335
		Dying = 2048,
		// Token: 0x04000920 RID: 2336
		Drowning = 4096,
		// Token: 0x04000921 RID: 2337
		Dead = 8192,
		// Token: 0x04000922 RID: 2338
		Debug = 16384,
		// Token: 0x04000923 RID: 2339
		Flying = 32768,
		// Token: 0x04000924 RID: 2340
		VirtualPlatform = 65536,
		// Token: 0x04000925 RID: 2341
		SpeedShoes = 131072,
		// Token: 0x04000926 RID: 2342
		Invincible = 262144,
		// Token: 0x04000927 RID: 2343
		ForceSpinball = 524288,
		// Token: 0x04000928 RID: 2344
		Winning = 1048576,
		// Token: 0x04000929 RID: 2345
		Super = 2097152,
		// Token: 0x0400092A RID: 2346
		ChargingSpindash = 4194304,
		// Token: 0x0400092B RID: 2347
		ShouldReactToLevel = 8388608,
		// Token: 0x0400092C RID: 2348
		ObjectControlled = 16777216
	}
}
