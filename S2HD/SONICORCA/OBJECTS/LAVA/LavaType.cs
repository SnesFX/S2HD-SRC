using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.LAVA
{
	// Token: 0x0200002F RID: 47
	[Name("Lava")]
	[Description("Lava from Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(LavaInstance))]
	public class LavaType : ObjectType
	{
		// Token: 0x060000FF RID: 255 RVA: 0x00008E3C File Offset: 0x0000703C
		public Vector2 GetLifeRadius(LavaInstance state)
		{
			return new Vector2i(state.Width, state.Height) / 2 * 64;
		}

		// Token: 0x04000121 RID: 289
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
