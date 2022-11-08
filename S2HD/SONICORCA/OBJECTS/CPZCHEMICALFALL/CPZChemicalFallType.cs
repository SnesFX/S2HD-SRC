using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.CPZCHEMICALFALL
{
	// Token: 0x02000090 RID: 144
	[Name("Chemical Fall")]
	[Description("Chemical Fall from Chemical Plant Zone, Sonic 2")]
	[ObjectInstance(typeof(CPZChemicalFallInstance))]
	public class CPZChemicalFallType : ObjectType
	{
		// Token: 0x060002F6 RID: 758 RVA: 0x0001604C File Offset: 0x0001424C
		public new Vector2 GetLifeRadius(ActiveObject state)
		{
			return new Vector2i(0, base.Level.Map.Bounds.Height);
		}

		// Token: 0x040003BD RID: 957
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";
	}
}
