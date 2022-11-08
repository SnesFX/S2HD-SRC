using System;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZTUBESPRING
{
	// Token: 0x02000077 RID: 119
	public class CPZTubeSpringInstance : ActiveObject
	{
		// Token: 0x0600025C RID: 604 RVA: 0x000116D2 File Offset: 0x0000F8D2
		public CPZTubeSpringInstance()
		{
			base.DesignBounds = new Rectanglei(-67, -66, 134, 132);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000116F4 File Offset: 0x0000F8F4
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._bounceVelocity = new Vector2(0.0, -42.0);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectangle(-64.0, -64.0, 128.0, 64.0), uint.MaxValue, (CollisionFlags)0).Take(3).ToArray<CollisionVector>();
			base.CollisionVectors[1].Id = 1;
			base.Priority = 1256;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000117A0 File Offset: 0x0000F9A0
		protected override void OnUpdate()
		{
			bool flag = false;
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				Vector2 vector = character.Position;
				if (vector.X >= (double)(base.Position.X - 64) && vector.X <= (double)(base.Position.X + 64) && vector.Y >= (double)(base.Position.Y - 48) && vector.Y <= (double)(base.Position.Y + 72))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				this._animation.Index = 2;
				return;
			}
			if (this._animation.Index == 2)
			{
				this._animation.Index = 3;
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0001189C File Offset: 0x0000FA9C
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.Id != 1)
			{
				return;
			}
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			if (this._animation.Index == 3 || this._animation.Index == 2)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			character.IsAirborne = true;
			character.IsSpinball = false;
			character.TumbleAngle = 0.0;
			character.TumbleTurns = 1;
			character.GroundVelocity = 1.0;
			character.Velocity = new Vector2((this._bounceVelocity.X != 0.0) ? this._bounceVelocity.X : character.Velocity.X, (this._bounceVelocity.Y != 0.0) ? this._bounceVelocity.Y : character.Velocity.Y);
			character.IsHurt = false;
			this._animation.Index = 1;
			e.MaintainVelocity = true;
			base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/SPRING"));
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000119CB File Offset: 0x0000FBCB
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000261 RID: 609 RVA: 0x000119D8 File Offset: 0x0000FBD8
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, new Vector2(0.0, -66.0), false, false);
		}

		// Token: 0x040002B9 RID: 697
		private const int AnimationStationary = 0;

		// Token: 0x040002BA RID: 698
		private const int AnimationBounce = 1;

		// Token: 0x040002BB RID: 699
		private const int AnimationOpen = 2;

		// Token: 0x040002BC RID: 700
		private const int AnimationClose = 3;

		// Token: 0x040002BD RID: 701
		private AnimationInstance _animation;

		// Token: 0x040002BE RID: 702
		private Vector2 _bounceVelocity;
	}
}
