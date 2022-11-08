using System;
using SonicOrca.Core.Objects.Metadata;

namespace SonicOrca.Core.Objects
{
	// Token: 0x02000157 RID: 343
	[Name("Ghost")]
	[Description("Ghost character simulating playback.")]
	[ObjectInstance(typeof(GhostCharacterInstance))]
	internal class GhostCharacterType : ObjectType
	{
		// Token: 0x04000842 RID: 2114
		public const string VirtualResourceKey = "SONICORCA/OBJECTS/GHOST";
	}
}
