using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.LOCKY
{
	// Token: 0x02000067 RID: 103
	[Name("Locky")]
	[Description("Locky from Sonic 1")]
	[Classification(ObjectClassification.Animal)]
	[ObjectInstance(typeof(LockyInstance))]
	public class LockyType : ObjectType
	{
		// Token: 0x04000280 RID: 640
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
