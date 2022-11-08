using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CPZDOOR
{
	// Token: 0x02000072 RID: 114
	[Name("One-way door")]
	[Description("One-way door from from Chemical Plant Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(CPZDoorInstance))]
	public class CPZDoorType : ObjectType
	{
		// Token: 0x04000295 RID: 661
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
