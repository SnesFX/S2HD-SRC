using System;
using SonicOrca.Core.Collision;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000165 RID: 357
	public class Badnik : ActiveObject
	{
		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x00037DC8 File Offset: 0x00035FC8
		// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x00037DD0 File Offset: 0x00035FD0
		public bool CanBeDestoryed { get; set; } = true;

		// Token: 0x06000EE9 RID: 3817 RVA: 0x00037DD9 File Offset: 0x00035FD9
		protected override void OnStart()
		{
			base.Priority = 128;
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x00037DE8 File Offset: 0x00035FE8
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			if (character.IsDeadly && this.CanBeDestoryed)
			{
				this.Destroy(character);
				return;
			}
			character.Hurt(Math.Sign(e.ActiveObject.Position.X - base.Position.X), PlayerDeathCause.Hurt);
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x00037E5C File Offset: 0x0003605C
		protected void Destroy(ICharacter character)
		{
			if (character.IsAirborne)
			{
				this.Rebound(character);
			}
			base.FinishForever();
			int points = character.Player.AwardChainedScore();
			this.CreateExplosionObject();
			base.Level.CreateRandomAnimalObject(base.Level.Map.Layers.IndexOf(base.Layer), base.Position, -1, 0);
			base.Level.CreateScoreObject(points, base.Position);
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00037ED0 File Offset: 0x000360D0
		protected virtual void Rebound(ICharacter character)
		{
			Vector2 velocity = character.Velocity;
			if (velocity.Y < 0.0)
			{
				velocity.Y += 4.0;
			}
			else if (character.Position.Y >= base.Position.Y)
			{
				velocity.Y -= 4.0;
			}
			else
			{
				velocity.Y *= -1.0;
			}
			character.Velocity = velocity;
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x00037F64 File Offset: 0x00036164
		protected void CreateExplosionObject()
		{
			base.Level.ObjectManager.AddObject(new ObjectPlacement(base.Level.CommonResources.GetResourcePath("badnikexplosionobject"), base.Level.Map.Layers.IndexOf(base.Layer), base.Position));
		}
	}
}
