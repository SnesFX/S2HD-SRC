using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.HTZRISINGBLOCK
{
	// Token: 0x0200008C RID: 140
	[Name("Rising block")]
	[Description("Rising block from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(HTZRisingBlockInstance))]
	public class HTZRisingBlockType : ObjectType
	{
		// Token: 0x040003AD RID: 941
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
