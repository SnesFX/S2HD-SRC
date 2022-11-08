using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.EHZPLATFORM
{
	// Token: 0x02000040 RID: 64
	[Name("Floating platform")]
	[Description("Floating platform from Emerald Hill Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(EHZPlatformInstance))]
	public class EHZPlatformType : ObjectType
	{
		// Token: 0x0600014D RID: 333 RVA: 0x0000B248 File Offset: 0x00009448
		public Vector2 GetLifeRadius(Platform state)
		{
			return new Vector2(state.MovementRadius.X, state.MovementRadius.Y);
		}

		// Token: 0x04000172 RID: 370
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
