using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.SUBMARINEEGGMAN
{
	// Token: 0x02000057 RID: 87
	[Name("Submarine Eggman")]
	[Description("Submarine Eggman from Hill Top Zone, Sonic 2")]
	[ObjectInstance(typeof(SubmarineEggmanInstance))]
	public class SubmarineEggmanType : ObjectType
	{
		// Token: 0x04000200 RID: 512
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000201 RID: 513
		[Dependency]
		public const string RobotnikAnimationGroupResourceKey = "SONICORCA/OBJECTS/ROBOTNIK/ANIGROUP";

		// Token: 0x04000202 RID: 514
		[Dependency]
		public const string BossExplosionResourceKey = "SONICORCA/OBJECTS/EXPLOSION/BOSS";

		// Token: 0x04000203 RID: 515
		[Dependency]
		public const string BossHitSoundResourceKey = "SONICORCA/SOUND/BOSSHIT";

		// Token: 0x04000204 RID: 516
		[Dependency]
		public const string FireBallSoundResourceKey = "SONICORCA/SOUND/FIREBALL";

		// Token: 0x04000205 RID: 517
		[Dependency]
		public const string FireBurnSoundResourceKey = "SONICORCA/SOUND/FIREBURN";

		// Token: 0x04000206 RID: 518
		[Dependency]
		public const string DefaultBrokenSmokeResourceKey = "SONICORCA/OBJECTS/DUST";
	}
}
