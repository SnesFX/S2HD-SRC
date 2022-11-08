using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.SPINY
{
	// Token: 0x02000080 RID: 128
	[Name("Spiny")]
	[Description("Spiny from Sonic 2")]
	[Classification(ObjectClassification.Badnik)]
	[ObjectInstance(typeof(SpinyInstance))]
	public class SpinyType : ObjectType
	{
		// Token: 0x040002EF RID: 751
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
