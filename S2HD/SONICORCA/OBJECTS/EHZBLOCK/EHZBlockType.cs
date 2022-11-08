using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.EHZBLOCK
{
	// Token: 0x02000042 RID: 66
	[Name("Floating block")]
	[Description("Floating block from Emerald Hill Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(EHZBlockInstance))]
	public class EHZBlockType : ObjectType
	{
		// Token: 0x06000153 RID: 339 RVA: 0x0000B324 File Offset: 0x00009524
		public Vector2 GetLifeRadius(Platform state)
		{
			return new Vector2(state.MovementRadius.X, state.MovementRadius.Y);
		}

		// Token: 0x04000174 RID: 372
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
