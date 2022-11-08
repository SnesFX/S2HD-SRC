using System;
using System.Collections.Generic;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZTUBECAP
{
	// Token: 0x0200006C RID: 108
	public class CPZTubeCapInstance : ActiveObject
	{
		// Token: 0x06000225 RID: 549 RVA: 0x00008788 File Offset: 0x00006988
		public CPZTubeCapInstance()
		{
			base.DesignBounds = new Rectanglei(-64, -64, 128, 128);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00010338 File Offset: 0x0000E538
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-64, -64, 128, 128), uint.MaxValue, (CollisionFlags)0);
			base.CollisionVectors[1].Id = 1;
			base.CollisionVectors[3].Id = 1;
			base.Priority = -256;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x000103B0 File Offset: 0x0000E5B0
		protected override void OnUpdate()
		{
			if (!this._broken)
			{
				return;
			}
			foreach (Vector2 velocity in CPZTubeCapInstance.ParticleVelocities)
			{
				base.Level.ObjectManager.AddSubObject<CPZTubeCapParticleInstance>(this).Velocity = velocity;
			}
			base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/BREAKABLE"));
			int points = this._playerThatBroke.AwardChainedScore();
			base.Level.CreateScoreObject(points, base.Position);
			base.FinishForever();
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0001045C File Offset: 0x0000E65C
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

		// Token: 0x06000229 RID: 553 RVA: 0x000104EE File Offset: 0x0000E6EE
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000104FB File Offset: 0x0000E6FB
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x04000284 RID: 644
		private const int AnimationCap = 0;

		// Token: 0x04000285 RID: 645
		private static readonly IReadOnlyCollection<Vector2> ParticleVelocities = new Vector2[]
		{
			new Vector2(-4.0, -16.0),
			new Vector2(-3.0, -14.0),
			new Vector2(3.0, -14.0),
			new Vector2(4.0, -16.0)
		};

		// Token: 0x04000286 RID: 646
		private AnimationInstance _animation;

		// Token: 0x04000287 RID: 647
		private bool _broken;

		// Token: 0x04000288 RID: 648
		private Player _playerThatBroke;
	}
}
