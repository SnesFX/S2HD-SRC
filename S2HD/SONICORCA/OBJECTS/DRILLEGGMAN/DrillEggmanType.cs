using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.DRILLEGGMAN
{
	// Token: 0x02000055 RID: 85
	[Name("Drill Eggman")]
	[Description("Drill Eggman from Emerald Hill Zone, Sonic 2")]
	[ObjectInstance(typeof(DrillEggmanInstance))]
	public class DrillEggmanType : ObjectType
	{
		// Token: 0x040001BE RID: 446
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x040001BF RID: 447
		[Dependency]
		public const string RobotnikAnimationGroupResourceKey = "SONICORCA/OBJECTS/ROBOTNIK/ANIGROUP";

		// Token: 0x040001C0 RID: 448
		[Dependency]
		public const string BossExplosionResourceKey = "SONICORCA/OBJECTS/EXPLOSION/BOSS";

		// Token: 0x040001C1 RID: 449
		[Dependency]
		public const string BossHelicopterSoundResourceKey = "SONICORCA/SOUND/BOSSHELICOPTER";

		// Token: 0x040001C2 RID: 450
		[Dependency]
		public const string BossHitSoundResourceKey = "SONICORCA/SOUND/BOSSHIT";

		// Token: 0x040001C3 RID: 451
		[Dependency]
		public const string DefaultBrokenSmokeResourceKey = "SONICORCA/OBJECTS/DUST";
	}
}
