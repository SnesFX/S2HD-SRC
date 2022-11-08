using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.HTZROCK.PARTICLE
{
	// Token: 0x0200004E RID: 78
	[Name("Rock particle")]
	[Description("Rock particle from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Particle)]
	[ObjectInstance(typeof(HTZRockParticleInstance))]
	public class HTZRockParticleType : ObjectType
	{
		// Token: 0x040001A4 RID: 420
		[Dependency]
		public const string AnimationGroupResourceKey = "//ANIGROUP";
	}
}
