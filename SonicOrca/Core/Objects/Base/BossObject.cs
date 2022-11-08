using System;
using SonicOrca.Core.Collision;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000166 RID: 358
	public class BossObject : Enemy
	{
		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x00037FCC File Offset: 0x000361CC
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x00037FD4 File Offset: 0x000361D4
		protected string ExplosionResourceKey { get; set; }

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x00037FDD File Offset: 0x000361DD
		// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x00037FE5 File Offset: 0x000361E5
		protected string HitSoundResourceKey { get; set; }

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x00037FEE File Offset: 0x000361EE
		// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x00037FF6 File Offset: 0x000361F6
		protected int Health { get; set; }

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x00037FFF File Offset: 0x000361FF
		// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x00038007 File Offset: 0x00036207
		protected int InvincibilityTimer { get; set; }

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x00038010 File Offset: 0x00036210
		// (set) Token: 0x06000EF8 RID: 3832 RVA: 0x00038018 File Offset: 0x00036218
		public bool Defeated { get; set; }

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x00038021 File Offset: 0x00036221
		// (set) Token: 0x06000EFA RID: 3834 RVA: 0x00038029 File Offset: 0x00036229
		public bool Fleeing { get; set; }

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000EFB RID: 3835 RVA: 0x00038032 File Offset: 0x00036232
		protected bool IsInvincibleFlashing
		{
			get
			{
				return this.InvincibilityTimer > 0 && this.InvincibilityTimer % 2 == 0;
			}
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x0003804A File Offset: 0x0003624A
		public BossObject()
		{
			this.ExplosionResourceKey = "SONICORCA/OBJECTS/BOSS/EXPLOSION";
			this.HitSoundResourceKey = "SONICORCA/SOUND/BOSSHIT";
			this.Health = 8;
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x00038070 File Offset: 0x00036270
		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (this.InvincibilityTimer > 0)
			{
				int invincibilityTimer = this.InvincibilityTimer;
				this.InvincibilityTimer = invincibilityTimer - 1;
			}
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x0003809C File Offset: 0x0003629C
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.ActiveObject.Type.Classification == ObjectClassification.Character)
			{
				ICharacter character = (ICharacter)e.ActiveObject;
				if (character.IsDeadly)
				{
					if (this.InvincibilityTimer <= 0)
					{
						this.Hit(character);
					}
					return;
				}
			}
			base.OnCollision(e);
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x000380E8 File Offset: 0x000362E8
		protected virtual void Hit(ICharacter character)
		{
			if (character.IsAirborne)
			{
				character.Velocity *= -1.0;
			}
			else
			{
				character.GroundVelocity *= -1.0;
			}
			int health = this.Health;
			this.Health = health - 1;
			this.InvincibilityTimer = 32;
			if (this.Health > 0)
			{
				base.Level.SoundManager.PlaySound(this, this.HitSoundResourceKey);
				return;
			}
			this.Defeat();
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void Defeat()
		{
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x00038170 File Offset: 0x00036370
		protected void UpdateExplosions(int radius)
		{
			int explosionTimer = this._explosionTimer;
			this._explosionTimer = explosionTimer - 1;
			if (explosionTimer > 0)
			{
				return;
			}
			this._explosionTimer = 8;
			Vector2i b = new Vector2i(base.Level.Random.Next(-radius, radius), base.Level.Random.Next(-radius, radius));
			this.ExplodeAt(base.Position + b);
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x000381D8 File Offset: 0x000363D8
		protected void ExplodeAt(Vector2i position)
		{
			base.Level.ObjectManager.AddObject(new ObjectPlacement(this.ExplosionResourceKey, base.Level.Map.Layers.IndexOf(base.Layer), position));
		}

		// Token: 0x04000859 RID: 2137
		public static readonly Colour FlashAdditiveColour = new Colour(64, 64, 64);

		// Token: 0x0400085A RID: 2138
		private int _explosionTimer;
	}
}
