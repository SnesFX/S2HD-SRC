using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.REXON
{
	// Token: 0x0200005D RID: 93
	[Name("Rexon")]
	[Description("Rexon from Sonic 2")]
	[Classification(ObjectClassification.Badnik)]
	[ObjectInstance(typeof(RexonInstance))]
	public class RexonType : ObjectType
	{
		// Token: 0x0400025B RID: 603
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
