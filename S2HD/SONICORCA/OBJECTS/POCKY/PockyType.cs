using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.POCKY
{
	// Token: 0x02000088 RID: 136
	[Name("Pocky")]
	[Description("Pocky from Sonic 1")]
	[Classification(ObjectClassification.Animal)]
	[ObjectInstance(typeof(PockyInstance))]
	public class PockyType : ObjectType
	{
		// Token: 0x04000338 RID: 824
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
