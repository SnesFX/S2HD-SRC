using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.SPRING
{
	// Token: 0x02000034 RID: 52
	[Name("Spring")]
	[Description("Spring from Sonic 1")]
	[Classification(ObjectClassification.General)]
	[ObjectInstance(typeof(SpringInstance))]
	public class SpringType : ObjectType
	{
		// Token: 0x04000149 RID: 329
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x0400014A RID: 330
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/SPRING";
	}
}
