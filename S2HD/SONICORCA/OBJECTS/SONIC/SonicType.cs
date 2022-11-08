using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.SONIC
{
	// Token: 0x02000010 RID: 16
	[Name("Sonic")]
	[Description("Sonic from Sonic 1")]
	[Classification(ObjectClassification.Character)]
	[ObjectInstance(typeof(SonicInstance))]
	[Dependency("SONICORCA/OBJECTS/DUST")]
	[Dependency("SONICORCA/OBJECTS/BARRIER/ANIGROUP")]
	[Dependency("SONICORCA/OBJECTS/BARRIER/BUBBLE/ANIGROUP")]
	[Dependency("SONICORCA/OBJECTS/BARRIER/FIRE/ANIGROUP")]
	[Dependency("SONICORCA/OBJECTS/BARRIER/LIGHTNING/ANIGROUP")]
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
	public class SonicType : ObjectType
	{
		// Token: 0x04000085 RID: 133
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000086 RID: 134
		[Dependency]
		public const string PeeloutChargeSoundResourceKey = "SONICORCA/SOUND/PEELOUT/CHARGE";

		// Token: 0x04000087 RID: 135
		[Dependency]
		public const string PeeloutReleaseSoundResourceKey = "SONICORCA/SOUND/PEELOUT/RELEASE";
	}
}
