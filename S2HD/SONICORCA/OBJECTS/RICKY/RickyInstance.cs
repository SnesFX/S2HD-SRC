using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.RICKY
{
	// Token: 0x02000021 RID: 33
	public class RickyInstance : Animal
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x000075B8 File Offset: 0x000057B8
		public RickyInstance() : base("/ANIGROUP")
		{
			base.JumpVelocity = new Vector2(-14.0, -14.0);
			base.JumpGravity = 0.875;
		}
	}
}
