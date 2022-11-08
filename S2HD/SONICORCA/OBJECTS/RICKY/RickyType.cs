using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.RICKY
{
	// Token: 0x02000020 RID: 32
	[Name("Ricky")]
	[Description("Ricky from Sonic 1")]
	[Classification(ObjectClassification.Animal)]
	[ObjectInstance(typeof(RickyInstance))]
	public class RickyType : ObjectType
	{
		// Token: 0x040000C1 RID: 193
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
