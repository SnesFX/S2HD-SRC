using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.WOCKY
{
	// Token: 0x02000069 RID: 105
	[Name("Wocky")]
	[Description("Wocky from Sonic 1")]
	[Classification(ObjectClassification.Animal)]
	[ObjectInstance(typeof(WockyInstance))]
	public class WockyType : ObjectType
	{
		// Token: 0x04000281 RID: 641
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
