using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.HTZBLOCK
{
	// Token: 0x0200004A RID: 74
	[Name("Floating block")]
	[Description("Floating block from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(HTZBlockInstance))]
	public class HTZBlockType : ObjectType
	{
		// Token: 0x06000186 RID: 390 RVA: 0x0000C050 File Offset: 0x0000A250
		public Vector2 GetLifeRadius(Platform state)
		{
			return new Vector2(state.MovementRadius.X, state.MovementRadius.Y);
		}

		// Token: 0x0400019A RID: 410
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
