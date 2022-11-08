using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.TAILS
{
	// Token: 0x02000012 RID: 18
	[Name("Tails")]
	[Description("Tails from Sonic 2")]
	[Classification(ObjectClassification.Character)]
	[ObjectInstance(typeof(TailsInstance))]
	[Dependency("SONICORCA/OBJECTS/DUST")]
	[Dependency("SONICORCA/OBJECTS/BARRIER/ANIGROUP")]
	[Dependency("SONICORCA/OBJECTS/INVINCIBILITY/ANIGROUP")]
	[Dependency("SONICORCA/OBJECTS/SPINDASH/ANIGROUP")]
	[Dependency("SONICORCA/SOUND/BARRIER")]
	[Dependency("SONICORCA/SOUND/BRAKE")]
	[Dependency("SONICORCA/SOUND/SPINBALL")]
	[Dependency("SONICORCA/SOUND/JUMP")]
	[Dependency("SONICORCA/SOUND/SPINDASH/CHARGE")]
	[Dependency("SONICORCA/SOUND/SPINDASH/RELEASE")]
	[Dependency("SONICORCA/SOUND/HURT")]
	[Dependency("SONICORCA/SOUND/HURT/SPIKES")]
	[Dependency("SONICORCA/SOUND/RINGSCATTER")]
	[Dependency("SONICORCA/SOUND/INHALE")]
	[Dependency("SONICORCA/SOUND/SPLASH")]
	[Dependency("SONICORCA/SOUND/DROWNWARNING")]
	[Dependency("SONICORCA/SOUND/DROWN")]
	public class TailsType : ObjectType
	{
		// Token: 0x04000089 RID: 137
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x0400008A RID: 138
		[Dependency]
		public const string TailAnimationGroupResourceKey = "/TAIL/ANIGROUP";

		// Token: 0x0400008B RID: 139
		[Dependency]
		public const string HeadAnimationGroupResourceKey = "/HEAD/ANIGROUP";
	}
}
