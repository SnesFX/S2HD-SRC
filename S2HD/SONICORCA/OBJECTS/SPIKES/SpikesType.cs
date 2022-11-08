using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.SPIKES
{
	// Token: 0x0200002B RID: 43
	[Name("Spikes")]
	[Description("Spikes from Sonic 1")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(SpikesInstance))]
	public class SpikesType : ObjectType
	{
		// Token: 0x04000106 RID: 262
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x04000107 RID: 263
		[Dependency]
		public const string SpikeMovementSoundResourceKey = "SONICORCA/SOUND/SPIKESLASH";
	}
}
