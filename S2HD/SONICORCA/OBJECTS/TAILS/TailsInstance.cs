using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Drawing.Renderers;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.TAILS
{
	// Token: 0x02000013 RID: 19
	public class TailsInstance : Character
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00005B8C File Offset: 0x00003D8C
		protected override void OnStart()
		{
			base.AnimationGroupResourceKey = base.Type.GetAbsolutePath("/ANIGROUP");
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/TAIL/ANIGROUP");
			AnimationGroup loadedResource2 = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/HEAD/ANIGROUP");
			this._tailAnimationInstance = new AnimationInstance(loadedResource, 0);
			this._headAnimationInstance = new AnimationInstance(loadedResource2, 0);
			base.NormalCollisionRadius = new Vector2i(40, 60);
			base.CanFly = true;
			base.OnStart();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005C14 File Offset: 0x00003E14
		protected override void OnAnimate()
		{
			base.OnAnimate();
			int num = this._tailAnimationInstance.Index;
			switch (base.Animation.Index)
			{
			case 0:
			case 1:
			case 2:
				num = 0;
				goto IL_AC;
			case 3:
				num = 1;
				goto IL_AC;
			case 4:
				num = 1;
				goto IL_AC;
			case 5:
				num = 1;
				goto IL_AC;
			case 6:
				num = 0;
				goto IL_AC;
			case 9:
				num = 1;
				goto IL_AC;
			case 10:
				num = 1;
				goto IL_AC;
			case 11:
				num = 2;
				goto IL_AC;
			}
			num = -1;
			IL_AC:
			this._tailAnimationInstance.Index = num;
			if (num != -1)
			{
				this._tailAnimationInstance.Animate();
			}
			if (base.Animation.Index == 24)
			{
				this._headAnimationInstance.Index = 0;
				this._headAnimationInstance.Animate();
				return;
			}
			this._headAnimationInstance.Index = -1;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005D1C File Offset: 0x00003F1C
		protected override void DrawBody(Renderer renderer, LayerViewOptions viewOptions)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			CharacterRenderer characterRenderer = CharacterRenderer.FromRenderer(renderer);
			characterRenderer.ModelMatrix = i2dRenderer.ModelMatrix;
			double propertyDouble = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "tails_hue_shift", 0.0);
			double propertyDouble2 = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "tails_sat_shift", 0.0);
			double propertyDouble3 = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "tails_lum_shift", 0.0);
			characterRenderer.Filter = viewOptions.Filter;
			characterRenderer.FilterAmount = viewOptions.FilterAmount;
			characterRenderer.Brightness = base.Brightness;
			if (base.DrawBodyRotated)
			{
				characterRenderer.ModelMatrix *= Matrix4.CreateRotationZ(base.ShowAngle);
			}
			Animation.Frame currentFrame;
			Vector2 vector;
			Rectangle destination;
			if (this._tailAnimationInstance.Index != -1)
			{
				currentFrame = this._tailAnimationInstance.CurrentFrame;
				vector = currentFrame.Offset;
				destination = new Rectangle(vector.X - (double)(currentFrame.Source.Width / 2), vector.Y - (double)(currentFrame.Source.Height / 2), (double)currentFrame.Source.Width, (double)currentFrame.Source.Height);
				if (base.Animation.Index == 10)
				{
					double angle = Math.Atan2(base.Velocity.Y, base.Velocity.X);
					characterRenderer.ModelMatrix *= Matrix4.CreateRotationZ(angle);
					characterRenderer.RenderTexture(this._tailAnimationInstance.AnimationGroup.Textures[1], this._tailAnimationInstance.AnimationGroup.Textures[0], propertyDouble, propertyDouble2, propertyDouble3, currentFrame.Source, destination, true, base.Velocity.X < 0.0);
					characterRenderer.ModelMatrix = i2dRenderer.ModelMatrix;
				}
				else
				{
					characterRenderer.RenderTexture(this._tailAnimationInstance.AnimationGroup.Textures[1], this._tailAnimationInstance.AnimationGroup.Textures[0], propertyDouble, propertyDouble2, propertyDouble3, currentFrame.Source, destination, base.IsFacingRight, false);
				}
			}
			currentFrame = base.Animation.CurrentFrame;
			vector = currentFrame.Offset;
			destination = new Rectangle(vector.X - (double)(currentFrame.Source.Width / 2), vector.Y - (double)(currentFrame.Source.Height / 2), (double)currentFrame.Source.Width, (double)currentFrame.Source.Height);
			characterRenderer.RenderTexture(base.Animation.AnimationGroup.Textures[1], base.Animation.AnimationGroup.Textures[0], propertyDouble, propertyDouble2, propertyDouble3, currentFrame.Source, destination, base.IsFacingRight, base.IsFacingLeft && base.Animation.Index == 16);
			if (this._headAnimationInstance.Index != -1)
			{
				currentFrame = this._headAnimationInstance.CurrentFrame;
				vector = currentFrame.Offset;
				destination = new Rectangle(vector.X - (double)(currentFrame.Source.Width / 2), vector.Y - (double)(currentFrame.Source.Height / 2), (double)currentFrame.Source.Width, (double)currentFrame.Source.Height);
				characterRenderer.RenderTexture(this._headAnimationInstance.AnimationGroup.Textures[1], this._headAnimationInstance.AnimationGroup.Textures[0], propertyDouble, propertyDouble2, propertyDouble3, currentFrame.Source, destination, base.IsFacingRight, false);
			}
		}

		// Token: 0x0400008C RID: 140
		private AnimationInstance _tailAnimationInstance;

		// Token: 0x0400008D RID: 141
		private AnimationInstance _headAnimationInstance;
	}
}
