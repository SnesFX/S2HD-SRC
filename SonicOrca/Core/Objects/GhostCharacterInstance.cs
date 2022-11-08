using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Objects
{
	// Token: 0x02000158 RID: 344
	internal class GhostCharacterInstance : ActiveObject
	{
		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000E37 RID: 3639 RVA: 0x00037361 File Offset: 0x00035561
		// (set) Token: 0x06000E38 RID: 3640 RVA: 0x00037369 File Offset: 0x00035569
		public double Angle { get; set; }

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000E39 RID: 3641 RVA: 0x00037372 File Offset: 0x00035572
		// (set) Token: 0x06000E3A RID: 3642 RVA: 0x0003737A File Offset: 0x0003557A
		public CharacterState State { get; set; }

		// Token: 0x06000E3B RID: 3643 RVA: 0x00037383 File Offset: 0x00035583
		protected override void OnStart()
		{
			base.Priority = 1022;
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x00037390 File Offset: 0x00035590
		public void Initialise(string animationResourceKey)
		{
			this.Initialise(base.Level.GameContext.ResourceTree.GetLoadedResource<AnimationGroup>(animationResourceKey));
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x000373AE File Offset: 0x000355AE
		public void Initialise(AnimationGroup animationGroup)
		{
			this._animation = new AnimationInstance(animationGroup, 0);
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x000373C0 File Offset: 0x000355C0
		public void Set(PlayRecorder.Entry entry)
		{
			base.Position = entry.Position;
			if (base.Level.Map.Layers.Count > entry.LayerIndex)
			{
				base.Layer = base.Level.Map.Layers[entry.LayerIndex];
			}
			this.State = (CharacterState)entry.State;
			if (this._animation != null)
			{
				this._animation.Index = entry.AnimationIndex;
				this._animation.CurrentFrameIndex = entry.AnimationFrameIndex;
			}
			this.Angle = (double)entry.Angle;
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x0003745C File Offset: 0x0003565C
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (viewOptions.Shadows)
			{
				return;
			}
			if (this._animation == null)
			{
				return;
			}
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			ICharacterRenderer characterRenderer = renderer.GetCharacterRenderer();
			characterRenderer.ModelMatrix = i2dRenderer.ModelMatrix;
			if (this.Angle != 0.0)
			{
				characterRenderer.ModelMatrix *= Matrix4.CreateRotationZ(this.Angle * 3.141592653589793);
			}
			Animation.Frame currentFrame = this._animation.CurrentFrame;
			Vector2 vector = currentFrame.Offset;
			Rectangle destination = new Rectangle(vector.X - (double)(currentFrame.Source.Width / 2), vector.Y - (double)(currentFrame.Source.Height / 2), (double)currentFrame.Source.Width, (double)currentFrame.Source.Height);
			characterRenderer.RenderTextureGhost(this._animation.AnimationGroup.Textures[1], this._animation.AnimationGroup.Textures[0], currentFrame.Source, destination, !this.State.HasFlag(CharacterState.Left), this.State.HasFlag(CharacterState.Left) && this._animation.Index == 16);
		}

		// Token: 0x04000843 RID: 2115
		private AnimationInstance _animation;
	}
}
