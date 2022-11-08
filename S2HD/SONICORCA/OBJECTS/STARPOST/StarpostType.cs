using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.STARPOST
{
	// Token: 0x0200002D RID: 45
	[Name("Starpost")]
	[Description("Starpost from Sonic 2")]
	[Classification(ObjectClassification.General)]
	[ObjectInstance(typeof(StarpostInstance))]
	public class StarpostType : ObjectType
	{
		// Token: 0x04000110 RID: 272
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000111 RID: 273
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/STARPOST";
	}
}
