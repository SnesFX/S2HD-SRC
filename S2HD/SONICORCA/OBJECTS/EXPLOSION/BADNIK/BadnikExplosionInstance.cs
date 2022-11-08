using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;

namespace SONICORCA.OBJECTS.EXPLOSION.BADNIK
{
	// Token: 0x02000037 RID: 55
	public class BadnikExplosionInstance : ParticleObject
	{
		// Token: 0x06000129 RID: 297 RVA: 0x0000A2BC File Offset: 0x000084BC
		public BadnikExplosionInstance() : base("/ANIGROUP", 0, 1)
		{
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000A2CB File Offset: 0x000084CB
		protected override void OnStart()
		{
			base.OnStart();
			base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/BADNIKEXPLOSION"));
			base.FilterMultiplier = 0.5;
		}
	}
}
