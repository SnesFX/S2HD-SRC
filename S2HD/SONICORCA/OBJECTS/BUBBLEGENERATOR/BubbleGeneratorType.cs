using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.BUBBLEGENERATOR
{
	// Token: 0x02000065 RID: 101
	[Name("Bubble Generator")]
	[Description("Bubble Generator from Sonic 1")]
	[ObjectInstance(typeof(BubbleGeneratorInstance))]
	public class BubbleGeneratorType : ObjectType
	{
		// Token: 0x0400027C RID: 636
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
