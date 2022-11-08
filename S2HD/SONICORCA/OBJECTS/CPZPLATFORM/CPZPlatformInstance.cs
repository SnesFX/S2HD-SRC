using System;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZPLATFORM
{
	// Token: 0x02000075 RID: 117
	public class CPZPlatformInstance : Platform
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00011186 File Offset: 0x0000F386
		// (set) Token: 0x06000256 RID: 598 RVA: 0x0001118E File Offset: 0x0000F38E
		[StateVariable]
		private CPZPlatformInstance.PlatformSize Size
		{
			get
			{
				return this._size;
			}
			set
			{
				this._size = value;
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00011197 File Offset: 0x0000F397
		public CPZPlatformInstance()
		{
			base.DesignBounds = new Rectanglei(-130, -74, 260, 148);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000111BC File Offset: 0x0000F3BC
		protected override void OnStart()
		{
			base.OnStart();
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type.GetAbsolutePath("/ANIGROUP"));
			if (this.Size == CPZPlatformInstance.PlatformSize.Large)
			{
				this._animationBase = new AnimationInstance(loadedResource, 0);
				this._animationStripGlow = new AnimationInstance(loadedResource, 1);
				this._animationStripBarometerA = new AnimationInstance(loadedResource, 3);
				this._animationStripBarometerB = new AnimationInstance(loadedResource, 2);
				this._animationLiquid = new AnimationInstance(loadedResource, 6);
			}
			else
			{
				this._animationBase = new AnimationInstance(loadedResource, 7);
				this._animationStripGlow = new AnimationInstance(loadedResource, 8);
				this._animationStripGlowBlue = new AnimationInstance(loadedResource, 9);
				this._animationStripGlowGreen = new AnimationInstance(loadedResource, 10);
				this._animationStripBarometerA = new AnimationInstance(loadedResource, 3);
				this._animationStripBarometerB = new AnimationInstance(loadedResource, 2);
				this._animationLiquid = new AnimationInstance(loadedResource, 11);
			}
			int num = (this.Size == CPZPlatformInstance.PlatformSize.Small) ? 96 : 128;
			base.CollisionVectors = new CollisionVector[]
			{
				new CollisionVector(this, new Vector2i(-num, -64), new Vector2i(num, -64), uint.MaxValue, CollisionFlags.Conveyor | CollisionFlags.Solid)
			};
		}

		// Token: 0x06000259 RID: 601 RVA: 0x000112D4 File Offset: 0x0000F4D4
		protected override void OnAnimate()
		{
			if (base.TimePeriod != this._switchBlueGreenBalanceTimePeriod)
			{
				this._switchBlueGreenBalanceTimePeriod = base.TimePeriod;
				this._switchBlueGreenBalanceEaseTimeline = new EaseTimeline(new EaseTimeline.Entry[]
				{
					new EaseTimeline.Entry(base.TimePeriod / 4 - 8, 1.0),
					new EaseTimeline.Entry(base.TimePeriod / 4 + 8, -1.0),
					new EaseTimeline.Entry(base.TimePeriod * 3 / 4 - 8, -1.0),
					new EaseTimeline.Entry(base.TimePeriod * 3 / 4 + 8, 1.0)
				});
			}
			if (base.TimePeriod == 0)
			{
				this._blueGreenBalance = 0.0;
			}
			else
			{
				this._blueGreenBalance = this._switchBlueGreenBalanceEaseTimeline.GetValueAt(base.CurrentTime);
			}
			double dest = (double)(base.IsCharacterInteractingWithPlatform() ? 1 : 0);
			this._glowOpacity = MathX.GoTowards(this._glowOpacity, dest, 0.03333333333333333);
			bool rising = this._rising;
			if (base.Position.Y != this._lastY)
			{
				this._rising = (base.Position.Y <= this._lastY);
			}
			this._lastY = base.Position.Y;
			if (!rising && this._rising)
			{
				this._animationStripBarometerB.Index = 4;
			}
			else if (rising && !this._rising)
			{
				this._animationStripBarometerB.Index = 5;
			}
			this._animationBase.Animate();
			this._animationStripGlow.Animate();
			this._animationStripBarometerA.Animate();
			this._animationStripBarometerB.Animate();
			this._animationLiquid.Animate();
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00011490 File Offset: 0x0000F690
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			if (this.Size == CPZPlatformInstance.PlatformSize.Large)
			{
				objectRenderer.Render(this._animationBase, false, false);
				if (this._glowOpacity > 0.0)
				{
					objectRenderer.MultiplyColour = new Colour(this._glowOpacity, 1.0, 1.0, 1.0);
					objectRenderer.Render(this._animationStripGlow, false, false);
					objectRenderer.MultiplyColour = Colours.White;
				}
				objectRenderer.Render(this._animationStripBarometerA, new Vector2(-15.0, -14.0), true, false);
				objectRenderer.Render(this._animationStripBarometerB, new Vector2(15.0, -14.0), false, false);
				objectRenderer.Render(this._animationLiquid, false, false);
				return;
			}
			objectRenderer.Render(this._animationBase, false, false);
			double num = (this._blueGreenBalance + 1.0) / 2.0;
			double num2 = 1.0 - num;
			if (num2 > 0.0)
			{
				objectRenderer.MultiplyColour = new Colour(num2, 1.0, 1.0, 1.0);
				objectRenderer.Render(this._animationStripGlowBlue, false, false);
			}
			if (num > 0.0)
			{
				objectRenderer.MultiplyColour = new Colour(num, 1.0, 1.0, 1.0);
				objectRenderer.Render(this._animationStripGlowGreen, false, false);
			}
			if (this._glowOpacity > 0.0)
			{
				objectRenderer.MultiplyColour = new Colour(this._glowOpacity, 1.0, 1.0, 1.0);
				objectRenderer.Render(this._animationStripGlow, false, false);
			}
			objectRenderer.MultiplyColour = Colours.White;
			objectRenderer.Render(this._animationStripBarometerA, new Vector2(-15.0, -14.0), true, false);
			objectRenderer.Render(this._animationStripBarometerB, new Vector2(15.0, -14.0), false, false);
			objectRenderer.Render(this._animationLiquid, false, false);
		}

		// Token: 0x0400029D RID: 669
		private const int AnimationBase = 0;

		// Token: 0x0400029E RID: 670
		private const int AnimationStripGlow = 1;

		// Token: 0x0400029F RID: 671
		private const int AnimationBarometerStill = 2;

		// Token: 0x040002A0 RID: 672
		private const int AnimationBarometerTwitching = 3;

		// Token: 0x040002A1 RID: 673
		private const int AnimationBarometerStillToTwitching = 4;

		// Token: 0x040002A2 RID: 674
		private const int AnimationBarometerTwitchingToStill = 5;

		// Token: 0x040002A3 RID: 675
		private const int AnimationLiquid = 6;

		// Token: 0x040002A4 RID: 676
		private const int AnimationSmallBase = 7;

		// Token: 0x040002A5 RID: 677
		private const int AnimationSmallStripGlow = 8;

		// Token: 0x040002A6 RID: 678
		private const int AnimationSmallStripGlowBlue = 9;

		// Token: 0x040002A7 RID: 679
		private const int AnimationSmallStripGlowGreen = 10;

		// Token: 0x040002A8 RID: 680
		private const int AnimationSmallLiquid = 11;

		// Token: 0x040002A9 RID: 681
		private AnimationInstance _animationBase;

		// Token: 0x040002AA RID: 682
		private AnimationInstance _animationStripGlow;

		// Token: 0x040002AB RID: 683
		private AnimationInstance _animationStripGlowBlue;

		// Token: 0x040002AC RID: 684
		private AnimationInstance _animationStripGlowGreen;

		// Token: 0x040002AD RID: 685
		private AnimationInstance _animationStripBarometerA;

		// Token: 0x040002AE RID: 686
		private AnimationInstance _animationStripBarometerB;

		// Token: 0x040002AF RID: 687
		private AnimationInstance _animationLiquid;

		// Token: 0x040002B0 RID: 688
		private CPZPlatformInstance.PlatformSize _size;

		// Token: 0x040002B1 RID: 689
		private int _lastY;

		// Token: 0x040002B2 RID: 690
		private bool _rising;

		// Token: 0x040002B3 RID: 691
		private double _glowOpacity;

		// Token: 0x040002B4 RID: 692
		private double _blueGreenBalance;

		// Token: 0x040002B5 RID: 693
		private int _switchBlueGreenBalanceTimePeriod;

		// Token: 0x040002B6 RID: 694
		private EaseTimeline _switchBlueGreenBalanceEaseTimeline;

		// Token: 0x020000EA RID: 234
		private enum PlatformSize
		{
			// Token: 0x04000625 RID: 1573
			Small,
			// Token: 0x04000626 RID: 1574
			Large
		}
	}
}
