using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.SPRINGBOARD
{
	// Token: 0x02000086 RID: 134
	[Name("Spring board")]
	[Description("Spring board from Sonic 2")]
	[Classification(ObjectClassification.General)]
	[ObjectInstance(typeof(SpringBoardInstance))]
	public class SpringBoardType : ObjectType
	{
		// Token: 0x0400032F RID: 815
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000330 RID: 816
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/SPRING";
	}
}
