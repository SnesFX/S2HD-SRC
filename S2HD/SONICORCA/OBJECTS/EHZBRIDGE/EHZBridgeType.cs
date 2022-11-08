using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.EHZBRIDGE
{
	// Token: 0x02000025 RID: 37
	[Name("Bridge")]
	[Description("Bridge from Emerald Hill Zone, Sonic 2")]
	[Classification(ObjectClassification.Platform)]
	[ObjectInstance(typeof(EHZBridgeInstance))]
	public class EHZBridgeType : ObjectType
	{
		// Token: 0x060000CC RID: 204 RVA: 0x00007D5B File Offset: 0x00005F5B
		public Vector2 GetLifeRadius(EHZBridgeInstance state)
		{
			return new Vector2i(state.Logs * 64 / 2, 0);
		}

		// Token: 0x040000F4 RID: 244
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
