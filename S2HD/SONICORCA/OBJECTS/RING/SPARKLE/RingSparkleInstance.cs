using System;
using SonicOrca.Core.Objects.Base;

namespace SONICORCA.OBJECTS.RING.SPARKLE
{
	// Token: 0x02000019 RID: 25
	public class RingSparkleInstance : ParticleObject
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x000072EB File Offset: 0x000054EB
		public RingSparkleInstance() : base("/ANIGROUP", 0, 1)
		{
			base.AdditiveBlending = true;
			base.FilterMultiplier = 0.0;
		}
	}
}
