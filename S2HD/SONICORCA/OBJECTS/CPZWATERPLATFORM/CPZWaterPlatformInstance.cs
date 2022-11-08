using System;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZWATERPLATFORM
{
	// Token: 0x02000085 RID: 133
	public class CPZWaterPlatformInstance : Platform
	{
		// Token: 0x060002AF RID: 687 RVA: 0x00013B4A File Offset: 0x00011D4A
		public CPZWaterPlatformInstance()
		{
			base.DesignBounds = new Rectanglei(-132, -62, 265, 125);
			base.Linear = true;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00013B74 File Offset: 0x00011D74
		protected override void OnStart()
		{
			base.OnStart();
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type.GetAbsolutePath("/ANIGROUP"));
			this._animationPlatform = new AnimationInstance(loadedResource, 0);
			this._animationPlatformGlow = new AnimationInstance(loadedResource, 1);
			this._animationWheel = new AnimationInstance(loadedResource, 3);
			base.CollisionVectors = new CollisionVector[]
			{
				new CollisionVector(this, new Vector2i(-96, -32), new Vector2i(96, -32), uint.MaxValue, CollisionFlags.Conveyor)
			};
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00013BF4 File Offset: 0x00011DF4
		protected override void OnAnimate()
		{
			int num = 120;
			this._glow = MathX.Clamp(0.0, (1.0 - Math.Cos(6.283185307179586 * (double)(base.Level.Ticks % num) / ((double)num - 1.0))) / 2.0, 1.0);
			this._animationPlatform.Animate();
			this._animationPlatformGlow.Animate();
			int num2 = Math.Sign(base.Position.X - base.LastPosition.X);
			if (num2 == -1)
			{
				this._animationWheel.Index = 3;
				this._animationWheel.Animate();
				return;
			}
			if (num2 == 1)
			{
				this._animationWheel.Index = 2;
				this._animationWheel.Animate();
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00013CD0 File Offset: 0x00011ED0
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.Render(this._animationPlatform, false, false);
			objectRenderer.MultiplyColour = new Colour(this._glow, 1.0, 1.0, 1.0);
			objectRenderer.Render(this._animationPlatformGlow, false, false);
			objectRenderer.MultiplyColour = Colours.White;
			objectRenderer.Render(this._animationWheel, new Vector2i(-78, 0), false, false);
			objectRenderer.Render(this._animationWheel, new Vector2i(78, 0), false, false);
		}

		// Token: 0x04000327 RID: 807
		private const int AnimationPlatform = 0;

		// Token: 0x04000328 RID: 808
		private const int AnimationPlatformGlow = 1;

		// Token: 0x04000329 RID: 809
		private const int AnimationWheelsMoveRight = 2;

		// Token: 0x0400032A RID: 810
		private const int AnimationWheelsMoveLeft = 3;

		// Token: 0x0400032B RID: 811
		private AnimationInstance _animationPlatform;

		// Token: 0x0400032C RID: 812
		private AnimationInstance _animationPlatformGlow;

		// Token: 0x0400032D RID: 813
		private AnimationInstance _animationWheel;

		// Token: 0x0400032E RID: 814
		private double _glow;
	}
}
