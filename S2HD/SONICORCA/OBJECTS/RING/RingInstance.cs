using System;
using System.Collections.Generic;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Lighting;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.RING
{
	// Token: 0x02000017 RID: 23
	public class RingInstance : ActiveObject
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00006A47 File Offset: 0x00004C47
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00006A4F File Offset: 0x00004C4F
		[StateVariable]
		private bool Scatter
		{
			get
			{
				return this._scatter;
			}
			set
			{
				this._scatter = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00006A58 File Offset: 0x00004C58
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00006A60 File Offset: 0x00004C60
		[StateVariable]
		private Vector2 Velocity
		{
			get
			{
				return this._velocity;
			}
			set
			{
				this._velocity = value;
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006A69 File Offset: 0x00004C69
		public RingInstance()
		{
			base.DesignBounds = new Rectanglei(-32, -32, 64, 64);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006A84 File Offset: 0x00004C84
		protected override void OnStart()
		{
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -16, -16, 32, 32)
			};
			if (this.Scatter)
			{
				this._stationary = false;
				this._lifeTicks = 255;
			}
			else
			{
				this._stationary = true;
				this._lifeTicks = 255;
				this._velocity = default(Vector2);
			}
			base.Priority = 4096;
			this._glowTexture = base.ResourceTree.GetLoadedResource<ITexture>(base.Type.GetAbsolutePath("SONICORCA/PARTICLE/GLOW"));
			base.ShadowInfo = null;
			this._lightSource = new PointLightSource(8, base.Position);
			base.Level.LightingManager.RegisterLightSource(this._lightSource);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006B44 File Offset: 0x00004D44
		protected override void OnUpdate()
		{
			this._lightSource.Position = base.Position;
			ICharacter character = null;
			double num = double.MaxValue;
			foreach (ICharacter character2 in base.Level.ObjectManager.Characters)
			{
				if (character2.Barrier == BarrierType.Lightning)
				{
					double num2 = (double)(character2.Position - base.Position).Length;
					if (num2 < num && (this._attracted || num2 < 256.0))
					{
						character = character2;
						num = num2;
					}
				}
			}
			if (character != null)
			{
				this._stationary = false;
				int value = character.Position.X - base.Position.X;
				if (Math.Sign(value) != Math.Sign(this._velocity.X) && this._velocity.X != 0.0)
				{
					this._velocity.X = this._velocity.X + 1.5 * (double)Math.Sign(value);
				}
				else
				{
					this._velocity.X = this._velocity.X + 0.75 * (double)Math.Sign(value);
				}
				int value2 = character.Position.Y - base.Position.Y;
				if (Math.Sign(value2) != Math.Sign(this._velocity.Y) && this._velocity.Y != 0.0)
				{
					this._velocity.Y = this._velocity.Y + 1.5 * (double)Math.Sign(value2);
				}
				else
				{
					this._velocity.Y = this._velocity.Y + 0.75 * (double)Math.Sign(value2);
				}
				base.PositionPrecise += this._velocity;
				this._attracted = true;
				return;
			}
			if (this._stationary)
			{
				return;
			}
			if (this._animation == null)
			{
				this._animation = new AnimationInstance((base.Type as RingType).AnimationInstance.AnimationGroup, 0);
				this._animation.OverrideDelay = new int?(0);
			}
			if (this._lifeTicks == 0)
			{
				base.FinishForever();
				return;
			}
			this._animation.OverrideDelay = new int?((255 - this._lifeTicks) / 32);
			this._lifeTicks--;
			this.UpdateMovement();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00006DDC File Offset: 0x00004FDC
		private void UpdateMovement()
		{
			base.PositionPrecise += this._velocity;
			bool flag = Math.Abs(this._velocity.Y) < 4.0;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			foreach (CollisionInfo collisionInfo in CollisionVector.GetCollisions(this, 32, uint.MaxValue))
			{
				if (collisionInfo.Vector.Mode == CollisionMode.Bottom || !flag)
				{
					if (collisionInfo.Vector.IsWall)
					{
						base.PositionPrecise = new Vector2(base.PositionPrecise.X + collisionInfo.Shift, base.PositionPrecise.Y);
						flag3 = true;
					}
					else
					{
						base.PositionPrecise = new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y + collisionInfo.Shift);
						flag2 = (collisionInfo.Vector.Mode == CollisionMode.Top);
						flag4 = (collisionInfo.Vector.Mode == CollisionMode.Bottom);
					}
				}
			}
			if (flag3)
			{
				this._velocity.X = this._velocity.X * -0.25;
			}
			if (flag2)
			{
				this._velocity.Y = this._velocity.Y * -0.75;
			}
			if (flag4)
			{
				this._velocity.Y = 0.0;
			}
			if (!flag2 && !flag4)
			{
				this._velocity.Y = this._velocity.Y + 0.375;
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00006F8C File Offset: 0x0000518C
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			if (this._stationary || this._attracted || this._lifeTicks < 175)
			{
				this.Collect(character.Player);
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00006FE4 File Offset: 0x000051E4
		private void Collect(Player player)
		{
			player.GainRings(1);
			this.CreateSparkles();
			Level level = base.Level;
			int ringsCollected = level.RingsCollected;
			level.RingsCollected = ringsCollected + 1;
			if (base.Level.RingsCollected == base.Level.RingsPerfectTarget)
			{
				base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/PERFECT"));
			}
			else
			{
				base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/RING"));
			}
			base.FinishForever();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00007078 File Offset: 0x00005278
		private void CreateSparkles()
		{
			int num = 0;
			foreach (Vector2i b in RingInstance.SparkleParticleOffsets)
			{
				ObjectPlacement objectPlacement = new ObjectPlacement(base.Type.GetAbsolutePath("/SPARKLE"), base.Level.Map.Layers.IndexOf(base.Layer), base.Position + b);
				base.Level.SetInterval(num, delegate
				{
					this.Level.ObjectManager.AddObject(objectPlacement);
				});
				num += 2;
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000712C File Offset: 0x0000532C
		protected override void OnAnimate()
		{
			if (!this._stationary && this._animation != null)
			{
				this._animation.Animate();
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000714C File Offset: 0x0000534C
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.FilterAmount *= 0.25;
			double num = MathX.Clamp((double)this._lifeTicks * 0.06274509803921569, 1.0);
			double num2 = 0.25 * num * viewOptions.FilterAmount;
			if (num2 > 0.0)
			{
				objectRenderer.BlendMode = BlendMode.Additive;
				objectRenderer.Texture = this._glowTexture;
				objectRenderer.MultiplyColour = new Colour(num2, 1.0, 1.0, 0.0);
				objectRenderer.Render(default(Vector2), false, false);
			}
			AnimationInstance animationInstance;
			if (this._stationary || this._animation == null)
			{
				animationInstance = (base.Type as RingType).AnimationInstance;
				objectRenderer.MultiplyColour = Colours.White;
			}
			else
			{
				animationInstance = this._animation;
				objectRenderer.MultiplyColour = new Colour(num, 1.0, 1.0, 1.0);
			}
			objectRenderer.BlendMode = BlendMode.Alpha;
			objectRenderer.Render(animationInstance, false, false);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000726D File Offset: 0x0000546D
		protected override void OnStop()
		{
			if (!this._stationary)
			{
				base.FinishForever();
			}
			base.Level.LightingManager.UnregisterLightSource(this._lightSource);
		}

		// Token: 0x040000A9 RID: 169
		private static readonly IReadOnlyList<Vector2i> SparkleParticleOffsets = new Vector2i[]
		{
			new Vector2i(16, 4),
			new Vector2i(-16, 12),
			new Vector2i(-12, -16),
			new Vector2i(20, -24)
		};

		// Token: 0x040000AA RID: 170
		private bool _scatter;

		// Token: 0x040000AB RID: 171
		private bool _stationary;

		// Token: 0x040000AC RID: 172
		private bool _attracted;

		// Token: 0x040000AD RID: 173
		private AnimationInstance _animation;

		// Token: 0x040000AE RID: 174
		private Vector2 _velocity;

		// Token: 0x040000AF RID: 175
		private int _lifeTicks;

		// Token: 0x040000B0 RID: 176
		private ITexture _glowTexture;

		// Token: 0x040000B1 RID: 177
		private PointLightSource _lightSource;
	}
}
