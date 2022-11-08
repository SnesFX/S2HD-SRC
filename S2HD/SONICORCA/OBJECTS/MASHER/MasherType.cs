using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.MASHER
{
	// Token: 0x0200001C RID: 28
	[Name("Masher")]
	[Description("Masher from Sonic 2")]
	[Classification(ObjectClassification.Badnik)]
	[ObjectInstance(typeof(MasherInstance))]
	public class MasherType : ObjectType
	{
		// Token: 0x040000B7 RID: 183
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
