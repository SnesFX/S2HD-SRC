using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.WATEREGGMAN
{
	// Token: 0x0200008A RID: 138
	[Name("Water Eggman")]
	[Description("Water Eggman from Chemical Plant Zone, Sonic 2")]
	[ObjectInstance(typeof(WaterEggmanInstance))]
	public class WaterEggmanType : ObjectType
	{
		// Token: 0x04000339 RID: 825
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x0400033A RID: 826
		[Dependency]
		public const string RobotnikAnimationGroupResourceKey = "SONICORCA/OBJECTS/ROBOTNIK/ANIGROUP";

		// Token: 0x0400033B RID: 827
		[Dependency]
		public const string BossExplosionResourceKey = "SONICORCA/OBJECTS/EXPLOSION/BOSS";

		// Token: 0x0400033C RID: 828
		[Dependency]
		public const string BossHitSoundResourceKey = "SONICORCA/SOUND/BOSSHIT";

		// Token: 0x0400033D RID: 829
		[Dependency]
		public const string DefaultBrokenSmokeResourceKey = "SONICORCA/OBJECTS/DUST";
	}
}
