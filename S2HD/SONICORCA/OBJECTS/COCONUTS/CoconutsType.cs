using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.COCONUTS
{
	// Token: 0x02000029 RID: 41
	[Name("Coconuts")]
	[Description("Coconuts from Sonic 2")]
	[Classification(ObjectClassification.Badnik)]
	[ObjectInstance(typeof(CoconutsInstance))]
	public class CoconutsType : ObjectType
	{
		// Token: 0x040000FA RID: 250
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
