using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CPZSPINTUBE
{
	// Token: 0x02000070 RID: 112
	[Name("Spin tube path")]
	[Description("Spin tube path from Chemical Plant Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(CPZSpinTubeInstance))]
	public class CPZSpinTubeType : ObjectType
	{
		// Token: 0x0400028E RID: 654
		[Dependency]
		public const string SpinballSoundResourceKey = "SONICORCA/SOUND/SPINBALL";

		// Token: 0x0400028F RID: 655
		[Dependency]
		public const string SpindashReleaseSoundResourceKey = "SONICORCA/SOUND/SPINDASH/RELEASE";
	}
}
