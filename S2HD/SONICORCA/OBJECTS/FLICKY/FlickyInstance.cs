using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.FLICKY
{
	// Token: 0x0200001F RID: 31
	public class FlickyInstance : Animal
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x0000758E File Offset: 0x0000578E
		public FlickyInstance() : base("/ANIGROUP")
		{
			base.JumpVelocity = new Vector2(-12.0, -16.0);
		}
	}
}
