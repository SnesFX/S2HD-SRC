using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.HTZPLATFORM
{
	// Token: 0x0200006E RID: 110
	[Name("Floating platform")]
	[Description("Floating platform from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(HTZPlatformInstance))]
	public class HTZPlatformType : ObjectType
	{
		// Token: 0x06000234 RID: 564 RVA: 0x00010690 File Offset: 0x0000E890
		public Vector2 GetLifeRadius(Platform state)
		{
			return new Vector2(state.MovementRadius.X, state.MovementRadius.Y);
		}

		// Token: 0x0400028C RID: 652
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
