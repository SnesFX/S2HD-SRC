using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.STARPOST
{
	// Token: 0x0200002E RID: 46
	public class StarpostInstance : ActiveObject
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00008AE8 File Offset: 0x00006CE8
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x00008AF0 File Offset: 0x00006CF0
		[StateVariable]
		private int Index
		{
			get
			{
				return this._index;
			}
			set
			{
				this._index = value;
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00008AF9 File Offset: 0x00006CF9
		public StarpostInstance()
		{
			base.DesignBounds = new Rectanglei(-50, -150, 100, 300);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00008B1C File Offset: 0x00006D1C
		protected override void OnStart()
		{
			AnimationGroup loadedResource = base.Level.GameContext.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
			this._standAnimation = new AnimationInstance(loadedResource, 0);
			this._starAnimation = new AnimationInstance(loadedResource, 0);
			this._starGlowAnimation = new AnimationInstance(loadedResource, 0);
			this._standAnimation.Index = 0;
			this._starAnimation.Index = 1;
			this._starGlowAnimation.Index = 3;
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -32, -128, 64, 256)
			};
			this._activated = base.Level.Player.IsStarpostActivated(this._index);
			this._glowing = this._activated;
			this.UpdateStarPosition();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00008BE4 File Offset: 0x00006DE4
		protected override void OnUpdate()
		{
			if (!this._activated && base.Level.Player.IsStarpostActivated(this._index))
			{
				this._activated = true;
				this._glowing = true;
			}
			if (this._starSpinning)
			{
				double num = 0.41887902047863906;
				this._starAngle += num;
				if (this._starAngle >= 12.566370614359172)
				{
					this._starAngle = 0.0;
					this._starSpinning = false;
					this._glowing = true;
				}
			}
			this.UpdateStarPosition();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00008C74 File Offset: 0x00006E74
		private void UpdateStarPosition()
		{
			this._starPosition = new Vector2(StarpostInstance.StarAxelMidpoint.X + Math.Sin(this._starAngle) * StarpostInstance.StarAxelRadius, StarpostInstance.StarAxelMidpoint.Y - Math.Cos(this._starAngle) * StarpostInstance.StarAxelRadius);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00008CC4 File Offset: 0x00006EC4
		protected override void OnCollision(CollisionEvent e)
		{
			if (this._activated)
			{
				return;
			}
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			if (character.IsSidekick)
			{
				return;
			}
			character.Player.ActivateStarpost(this._index, base.Position + new Vector2i(0, 64));
			this._activated = true;
			this._starSpinning = true;
			base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/STARPOST"));
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00008D58 File Offset: 0x00006F58
		protected override void OnAnimate()
		{
			if (this._glowing)
			{
				this._starAnimation.Index = 2;
				this._starGlowAnimation.CurrentFrameIndex = this._starAnimation.CurrentFrameIndex;
			}
			this._standAnimation.Animate();
			this._starAnimation.Animate();
			this._starGlowAnimation.Animate();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00008DB0 File Offset: 0x00006FB0
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.Render(this._standAnimation, false, false);
			objectRenderer.Render(this._starAnimation, this._starPosition, false, false);
			if (this._glowing)
			{
				objectRenderer.BlendMode = BlendMode.Additive;
				objectRenderer.EmitsLight = true;
				objectRenderer.Render(this._starGlowAnimation, this._starPosition, false, false);
			}
		}

		// Token: 0x04000112 RID: 274
		public const int AnimationStand = 0;

		// Token: 0x04000113 RID: 275
		public const int AnimationStarInactive = 1;

		// Token: 0x04000114 RID: 276
		public const int AnimationStarActive = 2;

		// Token: 0x04000115 RID: 277
		public const int AnimationStarActiveGlow = 3;

		// Token: 0x04000116 RID: 278
		private static double StarAxelRadius = 44.0;

		// Token: 0x04000117 RID: 279
		private static Vector2 StarAxelMidpoint = new Vector2(0.0, -52.0);

		// Token: 0x04000118 RID: 280
		private AnimationInstance _standAnimation;

		// Token: 0x04000119 RID: 281
		private AnimationInstance _starAnimation;

		// Token: 0x0400011A RID: 282
		private AnimationInstance _starGlowAnimation;

		// Token: 0x0400011B RID: 283
		private Vector2 _starPosition;

		// Token: 0x0400011C RID: 284
		private int _index;

		// Token: 0x0400011D RID: 285
		private bool _activated;

		// Token: 0x0400011E RID: 286
		private bool _glowing;

		// Token: 0x0400011F RID: 287
		private bool _starSpinning;

		// Token: 0x04000120 RID: 288
		private double _starAngle;
	}
}
