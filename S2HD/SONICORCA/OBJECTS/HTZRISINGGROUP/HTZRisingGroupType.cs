using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.HTZRISINGGROUP
{
	// Token: 0x0200008E RID: 142
	[Name("Rising group")]
	[Description("Rising group from Hill Top Zone, Sonic 2")]
	[Classification(ObjectClassification.Obstacle)]
	[ObjectInstance(typeof(HTZRisingGroupInstance))]
	public class HTZRisingGroupType : ObjectType
	{
		// Token: 0x060002E5 RID: 741 RVA: 0x000154E0 File Offset: 0x000136E0
		public Vector2 GetLifeRadius(HTZRisingGroupInstance state)
		{
			return new Vector2((double)state.Size.X / 2.0, (double)state.Size.Y / 2.0);
		}
	}
}
