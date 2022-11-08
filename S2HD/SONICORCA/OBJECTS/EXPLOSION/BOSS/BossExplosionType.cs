using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.EXPLOSION.BOSS
{
	// Token: 0x02000038 RID: 56
	[Name("Boss explosion")]
	[Description("Boss explosion from Sonic 1")]
	[Classification(ObjectClassification.Particle)]
	[ObjectInstance(typeof(BossExplosionInstance))]
	public class BossExplosionType : ObjectType
	{
		// Token: 0x04000152 RID: 338
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000153 RID: 339
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/BOSSEXPLOSION";
	}
}
