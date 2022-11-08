using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CPZSPEEDBOOSTER
{
	// Token: 0x0200007A RID: 122
	[Name("Speed Booster")]
	[Description("Speed Booster from Chemical Plant Zone, Sonic 2")]
	[ObjectInstance(typeof(CPZSpeedBoosterInstance))]
	public class CPZSpeedBoosterType : ObjectType
	{
		// Token: 0x040002CA RID: 714
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x040002CB RID: 715
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/SPRING";
	}
}
