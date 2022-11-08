using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.CPZWATERPLATFORM
{
	// Token: 0x02000084 RID: 132
	[Name("Water platform")]
	[Description("Water platform from Chemical Plant Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(CPZWaterPlatformInstance))]
	public class CPZWaterPlatformType : ObjectType
	{
		// Token: 0x060002AD RID: 685 RVA: 0x00013B1C File Offset: 0x00011D1C
		public Vector2 GetLifeRadius(Platform state)
		{
			return new Vector2(state.MovementRadius.X, state.MovementRadius.Y);
		}

		// Token: 0x04000326 RID: 806
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
