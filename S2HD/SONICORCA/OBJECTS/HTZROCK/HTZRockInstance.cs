using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZROCK
{
	// Token: 0x0200004D RID: 77
	public class HTZRockInstance : ActiveObject
	{
		// Token: 0x0600018D RID: 397 RVA: 0x0000C133 File Offset: 0x0000A333
		public HTZRockInstance()
		{
			base.DesignBounds = new Rectanglei(-96, -64, 192, 128);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000C154 File Offset: 0x0000A354
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-96, -64, 192, 128), uint.MaxValue, (CollisionFlags)0);
			base.CollisionVectors[1].Id = 1;
			base.CollisionVectors[3].Id = 1;
			base.Priority = -256;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000C1CC File Offset: 0x0000A3CC
		protected override void OnUpdate()
		{
			if (!this._broken)
			{
				return;
			}
			foreach (Vector2 vector in HTZRockInstance.ParticleVelocities)
			{
				base.Level.ObjectManager.AddObject(new ObjectPlacement(base.Type.GetAbsolutePath("/PARTICLE"), base.Level.Map.Layers.IndexOf(base.Level.Map.Layers.Last<LevelLayer>()), base.Position, new
				{
					Velocity = new Vector2(vector.X, vector.Y)
				}));
			}
			base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/BREAKABLE"));
			int points = this._playerThatBroke.AwardChainedScore();
			base.Level.CreateScoreObject(points, base.Position);
			base.Finish();
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000C2D0 File Offset: 0x0000A4D0
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.Id == 1 && e.ActiveObject.Type.Classification == ObjectClassification.Character)
			{
				ICharacter character = (ICharacter)e.ActiveObject;
				if (character.IsSpinball)
				{
					this._broken = true;
					this._playerThatBroke = character.Player;
					if (character.Velocity.Y > 0.0)
					{
						character.Velocity = new Vector2(character.Velocity.X, -12.0);
					}
					e.MaintainVelocity = true;
				}
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000C362 File Offset: 0x0000A562
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000C36F File Offset: 0x0000A56F
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x0400019F RID: 415
		private const int AnimationRock = 0;

		// Token: 0x040001A0 RID: 416
		private static readonly IReadOnlyCollection<Vector2> ParticleVelocities = new Vector2[]
		{
			new Vector2(-8.0, -10.0),
			new Vector2(-6.0, -8.0),
			new Vector2(-2.0, -10.0),
			new Vector2(2.0, -12.0),
			new Vector2(6.0, -8.0),
			new Vector2(8.0, -10.0)
		};

		// Token: 0x040001A1 RID: 417
		private AnimationInstance _animation;

		// Token: 0x040001A2 RID: 418
		private bool _broken;

		// Token: 0x040001A3 RID: 419
		private Player _playerThatBroke;
	}
}
