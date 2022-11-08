using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.LOCKY
{
	// Token: 0x02000068 RID: 104
	public class LockyInstance : Animal
	{
		// Token: 0x06000221 RID: 545 RVA: 0x000102E4 File Offset: 0x0000E4E4
		public LockyInstance() : base("/ANIGROUP")
		{
			base.JumpVelocity = new Vector2(-10.0, -12.0);
		}
	}
}
