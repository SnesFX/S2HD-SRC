using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.SPIKER
{
	// Token: 0x0200005B RID: 91
	[Name("Spiker")]
	[Description("Spiker from Sonic 2")]
	[Classification(ObjectClassification.Badnik)]
	[ObjectInstance(typeof(SpikerInstance))]
	public class SpikerType : ObjectType
	{
		// Token: 0x060001EC RID: 492 RVA: 0x0000F037 File Offset: 0x0000D237
		public new Vector2 GetLifeRadius(ActiveObject state)
		{
			return new Vector2i(1024, 0);
		}

		// Token: 0x0400024F RID: 591
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
