using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;

namespace SONICORCA.OBJECTS.MONITOR
{
	// Token: 0x02000023 RID: 35
	[Name("Monitor")]
	[Description("Monitor from Sonic 2")]
	[Classification(ObjectClassification.General)]
	[ObjectInstance(typeof(MonitorInstance))]
	public class MonitorType : ObjectType
	{
		// Token: 0x040000CC RID: 204
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x040000CD RID: 205
		[Dependency]
		public const string ExplosionResourceKey = "SONICORCA/OBJECTS/EXPLOSION/BADNIK";
	}
}
