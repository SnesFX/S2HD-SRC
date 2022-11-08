using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.BUBBLE
{
	// Token: 0x02000063 RID: 99
	[Name("Bubble")]
	[Description("Bubble from Sonic 1")]
	[ObjectInstance(typeof(BubbleInstance))]
	public class BubbleType : ObjectType
	{
		// Token: 0x04000275 RID: 629
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
