using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.SIGNPOST
{
	// Token: 0x02000031 RID: 49
	[Name("Signpost")]
	[Description("Signpost from Sonic 1")]
	[Classification(ObjectClassification.General)]
	[ObjectInstance(typeof(SignpostInstance))]
	public class SignpostType : ObjectType
	{
		// Token: 0x0600010D RID: 269 RVA: 0x0000965C File Offset: 0x0000785C
		public new Vector2 GetLifeRadius(ActiveObject state)
		{
			return new Vector2i(0, base.Level.Bounds.Height);
		}

		// Token: 0x0400012A RID: 298
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x0400012B RID: 299
		[Dependency]
		public const string SparkleObjectResourceKey = "SONICORCA/OBJECTS/RING/SPARKLE";

		// Token: 0x0400012C RID: 300
		[Dependency]
		public const string SoundResourceKey = "SONICORCA/SOUND/SIGNPOST";
	}
}
