using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.EHZBRIDGE.STAKE
{
	// Token: 0x02000028 RID: 40
	public class EHZBridgeStakeInstance : Scenery
	{
		// Token: 0x060000DA RID: 218 RVA: 0x000082FF File Offset: 0x000064FF
		public EHZBridgeStakeInstance() : base("//ANIGROUP")
		{
			base.DesignBounds = new Rectanglei(-32, -32, 64, 64);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000831F File Offset: 0x0000651F
		protected override void OnStart()
		{
			base.OnStart();
			base.Priority = 1280;
		}
	}
}
