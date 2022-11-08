using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.DUST
{
	// Token: 0x0200003C RID: 60
	[Name("Dust")]
	[Description("Dust from Sonic 1")]
	[Classification(ObjectClassification.Particle)]
	[ObjectInstance(typeof(DustInstance))]
	public class DustType : ObjectType
	{
		// Token: 0x0400016E RID: 366
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
