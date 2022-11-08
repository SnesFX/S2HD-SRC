using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.WOCKY
{
	// Token: 0x0200006A RID: 106
	public class WockyInstance : Animal
	{
		// Token: 0x06000223 RID: 547 RVA: 0x0001030E File Offset: 0x0000E50E
		public WockyInstance() : base("/ANIGROUP")
		{
			base.JumpVelocity = new Vector2(-10.0, -5.0);
		}
	}
}
