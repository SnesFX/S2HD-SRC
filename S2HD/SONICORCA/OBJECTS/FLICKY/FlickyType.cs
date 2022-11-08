using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.FLICKY
{
	// Token: 0x0200001E RID: 30
	[Name("Flicky")]
	[Description("Flicky from Sonic 1")]
	[Classification(ObjectClassification.Animal)]
	[ObjectInstance(typeof(FlickyInstance))]
	public class FlickyType : ObjectType
	{
		// Token: 0x040000C0 RID: 192
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
