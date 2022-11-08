using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.POCKY
{
	// Token: 0x02000089 RID: 137
	public class PockyInstance : Animal
	{
		// Token: 0x060002C0 RID: 704 RVA: 0x0001442B File Offset: 0x0001262B
		public PockyInstance() : base("/ANIGROUP")
		{
			base.JumpVelocity = new Vector2(-6.0, -12.0);
			base.JumpGravity = 0.875;
		}
	}
}
