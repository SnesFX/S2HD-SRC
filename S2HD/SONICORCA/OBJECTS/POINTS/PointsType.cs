using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.POINTS
{
	// Token: 0x0200001A RID: 26
	[Name("Points")]
	[Description("Points from Sonic 1")]
	[Classification(ObjectClassification.Particle)]
	[ObjectInstance(typeof(PointsInstance))]
	public class PointsType : ObjectType
	{
		// Token: 0x040000B3 RID: 179
		[Dependency]
		public const string FontResourceKey = "SONICORCA/FONTS/POINTS";
	}
}
