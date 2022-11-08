using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.HTZVINELIFT
{
	// Token: 0x02000044 RID: 68
	[Name("Vine lift")]
	[Description("Vine lift from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Scenery)]
	[ObjectInstance(typeof(HTZVineLiftInstance))]
	public class HTZVineLiftType : ObjectType
	{
		// Token: 0x04000176 RID: 374
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000177 RID: 375
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/VINELIFT";
	}
}
