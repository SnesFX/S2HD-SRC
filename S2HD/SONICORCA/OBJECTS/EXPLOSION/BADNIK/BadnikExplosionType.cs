using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.EXPLOSION.BADNIK
{
	// Token: 0x02000036 RID: 54
	[Name("Badnik explosion")]
	[Description("Badnik explosion from Sonic 1")]
	[Classification(ObjectClassification.Particle)]
	[ObjectInstance(typeof(BadnikExplosionInstance))]
	public class BadnikExplosionType : ObjectType
	{
		// Token: 0x04000150 RID: 336
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000151 RID: 337
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/BADNIKEXPLOSION";
	}
}
