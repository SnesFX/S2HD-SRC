using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.RING.SPARKLE
{
	// Token: 0x02000018 RID: 24
	[Name("Ring sparkle")]
	[Description("Ring sparkle from Sonic 1")]
	[Classification(ObjectClassification.Particle)]
	[ObjectInstance(typeof(RingSparkleInstance))]
	public class RingSparkleType : ObjectType
	{
		// Token: 0x040000B2 RID: 178
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
