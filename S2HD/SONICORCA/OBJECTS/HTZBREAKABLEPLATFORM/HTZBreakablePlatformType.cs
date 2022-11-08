using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.HTZBREAKABLEPLATFORM
{
	// Token: 0x02000050 RID: 80
	[Name("Breakable platform")]
	[Description("Breakable platform from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(HTZBreakablePlatformInstance))]
	public class HTZBreakablePlatformType : ObjectType
	{
		// Token: 0x040001A9 RID: 425
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x040001AA RID: 426
		[Dependency]
		public const string ParticleObjectResourceKey = "SONICORCA/OBJECTS/HTZROCK/PARTICLE";

		// Token: 0x040001AB RID: 427
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/BREAKABLE";
	}
}
