using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.EHZTWISTEDPATHWAY
{
	// Token: 0x0200003F RID: 63
	public class EHZTwistedPathwayInstance : ActiveObject
	{
		// Token: 0x06000145 RID: 325 RVA: 0x0000AB14 File Offset: 0x00008D14
		public EHZTwistedPathwayInstance()
		{
			base.DesignBounds = new Rectanglei(-this._radius.X, -this._radius.Y, this._radius.X * 2, this._radius.Y * 2);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000AB7C File Offset: 0x00008D7C
		protected override void OnStop()
		{
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				if (character.ObjectLink == this)
				{
					this.DisengadgeCharacter(character);
				}
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000ABDC File Offset: 0x00008DDC
		protected override void OnUpdate()
		{
			this._radius.X = 768;
			this._radius.Y = 192;
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				this.UpdateCharacter(character);
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000AC54 File Offset: 0x00008E54
		private void UpdateCharacter(ICharacter character)
		{
			if (character.ObjectLink == this)
			{
				character.CheckLandscapeCollision = false;
				character.IsAirborne = false;
				if (Math.Abs(character.GroundVelocity) < 20.0)
				{
					this.DisengadgeCharacter(character);
					return;
				}
				if (character.IsAirborne || character.IsDebug)
				{
					this.DisengadgeCharacter(character);
					return;
				}
				if (character.Position.X + character.CollisionRadius.X < base.Position.X - this._radius.X - 44 || character.Position.X - character.CollisionRadius.X >= base.Position.X + this._radius.X + 44)
				{
					this.DisengadgeCharacter(character);
					return;
				}
				this.UpdateTumble(character);
				return;
			}
			else
			{
				if (Math.Abs(character.GroundVelocity) < 20.0)
				{
					return;
				}
				if (character.IsAirborne || character.IsDebug)
				{
					return;
				}
				if (character.Position.X + character.CollisionRadius.X >= base.Position.X - this._radius.X && character.Position.X - character.CollisionRadius.X < base.Position.X + this._radius.X && character.Position.Y + character.CollisionRadius.Y >= base.Position.Y + this._radius.Y - 32 && character.Position.Y + character.CollisionRadius.Y < base.Position.Y + this._radius.Y + 32)
				{
					this.EngadgeCharacter(character);
					this.UpdateTumble(character);
				}
				return;
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000AE60 File Offset: 0x00009060
		private void UpdateTumble(ICharacter character)
		{
			double num = (double)(character.Position.X - (base.Position.X - this._radius.X)) / (double)(this._radius.X * 2);
			double num2 = Math.Cos(num * 6.283185307179586) * (double)(this._radius.Y - character.CollisionRadius.Y);
			character.PositionPrecise = new Vector2((double)character.Position.X, (double)base.Position.Y + num2);
			character.TumbleAngle = ((num < 0.5) ? (num * 2.0) : ((1.0 - num) * -2.0));
			if (character.TumbleAngle <= 0.0)
			{
				if (character.TumbleAngle + 0.0234375 > 0.0)
				{
					character.TumbleAngle = this._previousTumbleAngle;
					return;
				}
				this._previousTumbleAngle = character.TumbleAngle;
				return;
			}
			else
			{
				if (character.TumbleAngle - 0.0234375 < 0.0)
				{
					character.TumbleAngle = this._previousTumbleAngle;
					return;
				}
				this._previousTumbleAngle = character.TumbleAngle;
				return;
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000AFB0 File Offset: 0x000091B0
		private void EngadgeCharacter(ICharacter character)
		{
			if (character.ObjectLink != null)
			{
				if (character.ObjectLink.Type.Name == "Twisted pathway")
				{
					this._previousTumbleAngle = (character.ObjectLink as EHZTwistedPathwayInstance)._previousTumbleAngle;
				}
			}
			else
			{
				this._previousTumbleAngle = character.TumbleAngle;
			}
			character.LeaveGround();
			character.ObjectLink = this;
			character.CheckLandscapeCollision = false;
			character.ShowAngle = 0.0;
			character.Velocity = new Vector2(character.Velocity.X, 0.0);
			character.Mode = CollisionMode.Top;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000B051 File Offset: 0x00009251
		private void DisengadgeCharacter(ICharacter character)
		{
			this._previousTumbleAngle = 0.0;
			character.ObjectLink = null;
			character.CheckLandscapeCollision = true;
			character.IsAirborne = true;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000B078 File Offset: 0x00009278
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (!base.Level.LayerViewOptions.ShowObjectCollision && !base.Level.StateFlags.HasFlag(LevelStateFlags.Editing))
			{
				return;
			}
			if (viewOptions.Shadows)
			{
				return;
			}
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderLine(Colours.White, new Vector2((double)(-(double)this._radius.X) * renderer.GetObjectRenderer().Scale.X, 0.0), new Vector2((double)this._radius.X * renderer.GetObjectRenderer().Scale.X, 0.0), 2.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(0.0, (double)(-(double)this._radius.Y) * renderer.GetObjectRenderer().Scale.Y), new Vector2(0.0, (double)this._radius.Y * renderer.GetObjectRenderer().Scale.Y), 2.0);
			i2dRenderer.RenderRectangle(Colours.White, new Rectangle((double)(-(double)this._radius.X) * renderer.GetObjectRenderer().Scale.X, (double)(-(double)this._radius.Y) * renderer.GetObjectRenderer().Scale.Y, (double)(this._radius.X * 2) * renderer.GetObjectRenderer().Scale.X, (double)(this._radius.Y * 2) * renderer.GetObjectRenderer().Scale.Y), 2.0);
		}

		// Token: 0x04000170 RID: 368
		private Vector2i _radius = new Vector2i(832, 200);

		// Token: 0x04000171 RID: 369
		private double _previousTumbleAngle;
	}
}
