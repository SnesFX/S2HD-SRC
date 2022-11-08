using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.HTZROCK
{
	// Token: 0x0200004C RID: 76
	[Name("Rock")]
	[Description("Rock from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(HTZRockInstance))]
	public class HTZRockType : ObjectType
	{
		// Token: 0x0400019C RID: 412
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x0400019D RID: 413
		[Dependency]
		public const string ParticleObjectResourceKey = "/PARTICLE";

		// Token: 0x0400019E RID: 414
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/BREAKABLE";
	}
}
