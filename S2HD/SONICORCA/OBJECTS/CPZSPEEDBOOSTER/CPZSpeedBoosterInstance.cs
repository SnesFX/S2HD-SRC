using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZSPEEDBOOSTER
{
	// Token: 0x0200007B RID: 123
	public class CPZSpeedBoosterInstance : ActiveObject
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00012128 File Offset: 0x00010328
		// (set) Token: 0x0600027B RID: 635 RVA: 0x00012130 File Offset: 0x00010330
		[StateVariable]
		private int Strength
		{
			get
			{
				return this._strength;
			}
			set
			{
				this._strength = value;
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0001213C File Offset: 0x0001033C
		protected override void OnStart()
		{
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type.GetAbsolutePath("/ANIGROUP"));
			this._animationFrame = new AnimationInstance(loadedResource, 0);
			this._animationCore = new AnimationInstance(loadedResource, 1);
			this._animationArrows = new AnimationInstance(loadedResource, 2);
			this._animationSpinner = new AnimationInstance(loadedResource, 3);
			this._animationSmallWheel = new AnimationInstance(loadedResource, 4);
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, -64, -64, 128, 32)
			};
			base.DesignBounds = new Rectanglei(-158, -188, 316, 376);
			base.Priority = 1512;
			base.Level.ObjectManager.AddSubObject<CPZSpeedBoosterInstance.BackWheel>(this);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00012204 File Offset: 0x00010404
		protected override void OnCollision(CollisionEvent e)
		{
			ICharacter character = (ICharacter)e.ActiveObject;
			if (character.IsAirborne || this._strength == 0)
			{
				return;
			}
			if (character.GroundVelocity < (double)Math.Abs(this._strength) || Math.Sign(character.GroundVelocity) != Math.Sign(this._strength))
			{
				character.GroundVelocity = (double)this._strength;
				character.SlopeLockTicks = 15;
				character.Facing = Math.Sign(this._strength);
				bool flag = false;
				double x = base.Level.Camera.Velocity.X;
				if (this._strength < 0)
				{
					flag = (x >= 0.0);
				}
				else if (this._strength > 0)
				{
					flag = (x <= 0.0);
				}
				if (flag)
				{
					character.CameraProperties.Delay = new Vector2i(16, base.CameraProperties.Delay.Y);
				}
			}
			base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/SPRING");
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00012314 File Offset: 0x00010514
		protected override void OnAnimate()
		{
			if (this._strength == 0)
			{
				return;
			}
			this._animationFrame.Animate();
			this._animationCore.Animate();
			this._animationArrows.Animate();
			this._animationSpinner.Animate();
			this._animationSmallWheel.Animate();
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00012364 File Offset: 0x00010564
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (this._strength == 0)
			{
				return;
			}
			bool flag = this._strength < 0;
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.Render(this._animationFrame, new Vector2(0.0, 0.0), false, false);
			objectRenderer.Render(this._animationCore, new Vector2(0.0, 0.0), false, false);
			objectRenderer.Render(this._animationArrows, new Vector2(0.0, 0.0), flag, false);
			objectRenderer.Render(this._animationSpinner, new Vector2(64.0, 0.0), !flag, false);
			objectRenderer.Render(this._animationSmallWheel, new Vector2(-112.0, 0.0), flag, false);
			objectRenderer.Render(this._animationSmallWheel, new Vector2(112.0, 0.0), flag, false);
		}

		// Token: 0x040002CC RID: 716
		private const int AnimationFrame = 0;

		// Token: 0x040002CD RID: 717
		private const int AnimationCore = 1;

		// Token: 0x040002CE RID: 718
		private const int AnimationArrows = 2;

		// Token: 0x040002CF RID: 719
		private const int AnimationSpinner = 3;

		// Token: 0x040002D0 RID: 720
		private const int AnimationSmallWheel = 4;

		// Token: 0x040002D1 RID: 721
		private AnimationInstance _animationFrame;

		// Token: 0x040002D2 RID: 722
		private AnimationInstance _animationCore;

		// Token: 0x040002D3 RID: 723
		private AnimationInstance _animationArrows;

		// Token: 0x040002D4 RID: 724
		private AnimationInstance _animationSpinner;

		// Token: 0x040002D5 RID: 725
		private AnimationInstance _animationSmallWheel;

		// Token: 0x040002D6 RID: 726
		private int _strength = 128;

		// Token: 0x020000ED RID: 237
		private class BackWheel : ActiveObject
		{
			// Token: 0x060005CE RID: 1486 RVA: 0x00022860 File Offset: 0x00020A60
			protected override void OnUpdate()
			{
				CPZSpeedBoosterInstance cpzspeedBoosterInstance = base.ParentObject as CPZSpeedBoosterInstance;
				if (cpzspeedBoosterInstance == null || cpzspeedBoosterInstance.Finished)
				{
					base.Finish();
				}
			}

			// Token: 0x060005CF RID: 1487 RVA: 0x0002288C File Offset: 0x00020A8C
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				CPZSpeedBoosterInstance cpzspeedBoosterInstance = base.ParentObject as CPZSpeedBoosterInstance;
				if (cpzspeedBoosterInstance == null)
				{
					return;
				}
				if (cpzspeedBoosterInstance._strength == 0)
				{
					return;
				}
				bool flipX = cpzspeedBoosterInstance._strength < 0;
				renderer.GetObjectRenderer().Render(cpzspeedBoosterInstance._animationSpinner, new Vector2(-64.0, 0.0), flipX, false);
			}
		}
	}
}
