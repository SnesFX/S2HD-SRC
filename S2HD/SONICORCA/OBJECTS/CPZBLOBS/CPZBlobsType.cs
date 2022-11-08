using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CPZBLOBS
{
	// Token: 0x0200007E RID: 126
	[Name("Blobs")]
	[Description("Blobs from Chemical Plant Zone, Sonic 2")]
	[ObjectInstance(typeof(CPZBlobsInstance))]
	public class CPZBlobsType : ObjectType
	{
		// Token: 0x040002E0 RID: 736
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x040002E1 RID: 737
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/BLOB";
	}
}
