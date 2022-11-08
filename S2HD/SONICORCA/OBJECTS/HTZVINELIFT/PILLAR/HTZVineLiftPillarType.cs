using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.HTZVINELIFT.PILLAR
{
	// Token: 0x02000046 RID: 70
	[Name("Vine lift pillar")]
	[Description("Vine lift pillar from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Scenery)]
	[ObjectInstance(typeof(HTZVineLiftPillarInstance))]
	public class HTZVineLiftPillarType : ObjectType
	{
		// Token: 0x04000183 RID: 387
		[Dependency]
		public const string AnimationGroupResourceKey = "//ANIGROUP";
	}
}
