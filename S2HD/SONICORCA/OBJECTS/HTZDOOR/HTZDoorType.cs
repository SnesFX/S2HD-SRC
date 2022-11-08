using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.HTZDOOR
{
	// Token: 0x02000053 RID: 83
	[Name("One-way door")]
	[Description("One-way door from from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(HTZDoorInstance))]
	public class HTZDoorType : ObjectType
	{
		// Token: 0x040001B7 RID: 439
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
