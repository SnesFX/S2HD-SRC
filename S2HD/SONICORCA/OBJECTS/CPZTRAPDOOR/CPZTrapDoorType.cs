using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CPZTRAPDOOR
{
	// Token: 0x0200007C RID: 124
	[Name("Trap door")]
	[Description("Trap door from Chemical Plant Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(CPZTrapDoorInstance))]
	public class CPZTrapDoorType : ObjectType
	{
		// Token: 0x040002D7 RID: 727
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
