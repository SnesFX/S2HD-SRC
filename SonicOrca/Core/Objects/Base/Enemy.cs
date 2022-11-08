using System;
using SonicOrca.Core.Collision;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000170 RID: 368
	public class Enemy : ActiveObject
	{
		// Token: 0x0600102D RID: 4141 RVA: 0x000415D0 File Offset: 0x0003F7D0
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			if (character.CanBeHurt)
			{
				character.Hurt(Math.Sign(character.Position.X - base.Position.X), PlayerDeathCause.Hurt);
				this.OnHurtCharacter(character);
			}
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnHurtCharacter(ICharacter character)
		{
		}
	}
}
