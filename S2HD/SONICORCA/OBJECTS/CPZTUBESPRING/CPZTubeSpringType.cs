using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CPZTUBESPRING
{
	// Token: 0x02000076 RID: 118
	[Name("Tube spring")]
	[Description("Tube spring from Chemical Plant Zone, Sonic 2")]
	[Classification(ObjectClassification.General)]
	[ObjectInstance(typeof(CPZTubeSpringInstance))]
	public class CPZTubeSpringType : ObjectType
	{
		// Token: 0x040002B7 RID: 695
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x040002B8 RID: 696
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/SPRING";
	}
}
