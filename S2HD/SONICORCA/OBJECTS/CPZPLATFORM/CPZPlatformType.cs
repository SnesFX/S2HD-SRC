using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.CPZPLATFORM
{
	// Token: 0x02000074 RID: 116
	[Name("Floating platform")]
	[Description("Floating platform from Chemical Plant Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(CPZPlatformInstance))]
	public class CPZPlatformType : ObjectType
	{
		// Token: 0x06000253 RID: 595 RVA: 0x00011158 File Offset: 0x0000F358
		public Vector2 GetLifeRadius(Platform state)
		{
			return new Vector2(state.MovementRadius.X, state.MovementRadius.Y);
		}

		// Token: 0x0400029C RID: 668
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
