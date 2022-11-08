using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.EHZBRIDGE.STAKE
{
	// Token: 0x02000027 RID: 39
	[Name("Bridge stake")]
	[Description("Bridge stake from Emerald Hill Zone, Sonic 2")]
	[Classification(ObjectClassification.Scenery)]
	[ObjectInstance(typeof(EHZBridgeStakeInstance))]
	public class EHZBridgeStakeType : ObjectType
	{
		// Token: 0x040000F9 RID: 249
		[Dependency]
		public const string AnimationGroupResourceKey = "//ANIGROUP";
	}
}
