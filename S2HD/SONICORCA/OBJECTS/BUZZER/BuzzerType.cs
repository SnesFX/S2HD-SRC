using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.BUZZER
{
	// Token: 0x02000059 RID: 89
	[Name("Buzzer")]
	[Description("Buzzer from Sonic 2")]
	[Classification(ObjectClassification.Badnik)]
	[ObjectInstance(typeof(BuzzerInstance))]
	public class BuzzerType : ObjectType
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x0000F037 File Offset: 0x0000D237
		public new Vector2 GetLifeRadius(ActiveObject state)
		{
			return new Vector2i(1024, 0);
		}

		// Token: 0x04000244 RID: 580
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
