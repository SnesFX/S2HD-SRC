using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.HTZSEESAW
{
	// Token: 0x02000048 RID: 72
	[Name("See Saw")]
	[Description("See Saw and Sol from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(HTZSeeSawInstance))]
	public class HTZSeeSawType : ObjectType
	{
		// Token: 0x06000171 RID: 369 RVA: 0x0000B7A1 File Offset: 0x000099A1
		public new Vector2 GetLifeRadius(ActiveObject state)
		{
			return new Vector2i(0, 2048);
		}

		// Token: 0x04000189 RID: 393
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x0400018A RID: 394
		[Dependency]
		public const string SolAnimationGroupResourceKey = "SONICORCA/OBJECTS/SOL/ANIGROUP";

		// Token: 0x0400018B RID: 395
		[Dependency]
		public const string BounceSoundResourceKey = "SONICORCA/SOUND/SPRING";
	}
}
