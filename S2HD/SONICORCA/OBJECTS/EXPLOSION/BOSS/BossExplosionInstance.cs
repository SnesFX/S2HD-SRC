using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;

namespace SONICORCA.OBJECTS.EXPLOSION.BOSS
{
	// Token: 0x02000039 RID: 57
	public class BossExplosionInstance : ParticleObject
	{
		// Token: 0x0600012C RID: 300 RVA: 0x0000A2BC File Offset: 0x000084BC
		public BossExplosionInstance() : base("/ANIGROUP", 0, 1)
		{
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000A303 File Offset: 0x00008503
		protected override void OnStart()
		{
			base.OnStart();
			base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/BOSSEXPLOSION"));
			base.FilterMultiplier = 0.0;
		}
	}
}
