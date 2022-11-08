using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.CAPSULE
{
	// Token: 0x0200003A RID: 58
	[Name("Capsule")]
	[Description("Capsule from Sonic 2")]
	[Classification(ObjectClassification.Capsule)]
	[ObjectInstance(typeof(CapsuleInstance))]
	public class CapsuleType : ObjectType
	{
		// Token: 0x04000154 RID: 340
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
