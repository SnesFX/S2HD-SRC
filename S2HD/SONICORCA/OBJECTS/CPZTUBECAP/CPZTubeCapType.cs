using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CPZTUBECAP
{
	// Token: 0x0200006B RID: 107
	[Name("Tube cap")]
	[Description("Tube cap from Chemical Plant Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(CPZTubeCapInstance))]
	public class CPZTubeCapType : ObjectType
	{
		// Token: 0x04000282 RID: 642
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000283 RID: 643
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/BREAKABLE";
	}
}
