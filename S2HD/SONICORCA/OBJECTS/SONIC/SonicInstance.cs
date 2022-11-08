using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.SONIC
{
	// Token: 0x02000011 RID: 17
	public class SonicInstance : Character
	{
		// Token: 0x06000066 RID: 102 RVA: 0x000058BA File Offset: 0x00003ABA
		protected override void OnStart()
		{
			base.AnimationGroupResourceKey = base.Type.GetAbsolutePath("/ANIGROUP");
			base.OnStart();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000058D8 File Offset: 0x00003AD8
		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (base.IsWinning)
			{
				if (this._winningTicks == 0)
				{
					base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/PEELOUT/CHARGE");
				}
				else if (this._winningTicks == 70)
				{
					base.Level.SoundManager.PlaySound(this, "SONICORCA/SOUND/PEELOUT/RELEASE");
				}
				this._winningTicks++;
				return;
			}
			this._winningTicks = 0;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000594C File Offset: 0x00003B4C
		protected override void DrawBody(Renderer renderer, LayerViewOptions viewOptions)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			ICharacterRenderer characterRenderer = renderer.GetCharacterRenderer();
			characterRenderer.ModelMatrix = i2dRenderer.ModelMatrix;
			double propertyDouble = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "sonic_hue_shift", 0.0);
			double propertyDouble2 = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "sonic_sat_shift", 0.0);
			double propertyDouble3 = base.Level.GameContext.Configuration.GetPropertyDouble("debug", "sonic_lum_shift", 0.0);
			if (base.DrawBodyRotated)
			{
				characterRenderer.ModelMatrix *= Matrix4.CreateRotationZ(base.ShowAngle);
			}
			Animation.Frame currentFrame = base.Animation.CurrentFrame;
			Vector2 vector = currentFrame.Offset;
			Vector2 vector2 = default(Vector2);
			if (base.IsSpinball)
			{
				vector2 = new Vector2(vector.X, vector.Y - 4.0);
			}
			else
			{
				vector2 = new Vector2(vector.X, vector.Y - 16.0);
			}
			vector = vector2;
			Rectangle destination = new Rectangle(vector.X - (double)(currentFrame.Source.Width / 2), vector.Y - (double)(currentFrame.Source.Height / 2), (double)currentFrame.Source.Width, (double)currentFrame.Source.Height);
			characterRenderer.Filter = viewOptions.Filter;
			characterRenderer.FilterAmount = viewOptions.FilterAmount;
			characterRenderer.Brightness = (viewOptions.Shadows ? 0f : base.Brightness);
			characterRenderer.RenderTexture(base.Animation.AnimationGroup.Textures[1], base.Animation.AnimationGroup.Textures[0], propertyDouble, propertyDouble2, propertyDouble3, currentFrame.Source, destination, base.IsFacingRight, base.IsFacingLeft && base.Animation.Index == 16);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005B78 File Offset: 0x00003D78
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			base.OnDraw(renderer, viewOptions);
		}

		// Token: 0x04000088 RID: 136
		private int _winningTicks;
	}
}
