using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.SOL
{
	// Token: 0x0200005F RID: 95
	[Name("Sol")]
	[Description("Sol from Sonic 2")]
	[Classification(ObjectClassification.Badnik)]
	[ObjectInstance(typeof(SolInstance))]
	public class SolType : ObjectType
	{
		// Token: 0x0400026E RID: 622
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
