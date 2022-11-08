using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CPZBLOCK
{
	// Token: 0x02000078 RID: 120
	[Name("Block")]
	[Description("Block from Chemical Plant Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(CPZBlockInstance))]
	public class CPZBlockType : ObjectType
	{
		// Token: 0x040002BF RID: 703
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
