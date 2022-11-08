using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.GRABBER
{
	// Token: 0x02000082 RID: 130
	[Name("Grabber")]
	[Description("Grabber from Sonic 2")]
	[Classification(ObjectClassification.Badnik)]
	[ObjectInstance(typeof(GrabberInstance))]
	public class GrabberType : ObjectType
	{
		// Token: 0x040002FA RID: 762
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
