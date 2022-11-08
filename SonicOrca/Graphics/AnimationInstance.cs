using System;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Graphics
{
	// Token: 0x020000DA RID: 218
	public class AnimationInstance
	{
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x0001E2A5 File Offset: 0x0001C4A5
		// (set) Token: 0x06000743 RID: 1859 RVA: 0x0001E2AD File Offset: 0x0001C4AD
		public int CurrentFrameIndex { get; set; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x0001E2B6 File Offset: 0x0001C4B6
		// (set) Token: 0x06000745 RID: 1861 RVA: 0x0001E2BE File Offset: 0x0001C4BE
		public int Cycles { get; set; }

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x0001E2C7 File Offset: 0x0001C4C7
		// (set) Token: 0x06000747 RID: 1863 RVA: 0x0001E2CF File Offset: 0x0001C4CF
		public int? OverrideDelay { get; set; }

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x0001E2D8 File Offset: 0x0001C4D8
		// (set) Token: 0x06000749 RID: 1865 RVA: 0x0001E2E0 File Offset: 0x0001C4E0
		public int? OverrideTextureIndex { get; set; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x0001E2E9 File Offset: 0x0001C4E9
		// (set) Token: 0x0600074B RID: 1867 RVA: 0x0001E2F1 File Offset: 0x0001C4F1
		public bool AdditiveBlending { get; set; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x0001E2FA File Offset: 0x0001C4FA
		public Animation Animation
		{
			get
			{
				return this._animationGroup[this._animationIndex];
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x0001E30D File Offset: 0x0001C50D
		public AnimationGroup AnimationGroup
		{
			get
			{
				return this._animationGroup;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x0001E315 File Offset: 0x0001C515
		public Animation.Frame CurrentFrame
		{
			get
			{
				return this._animationGroup[this._animationIndex].Frames[this.CurrentFrameIndex];
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x0001E338 File Offset: 0x0001C538
		public ITexture CurrentTexture
		{
			get
			{
				return this._animationGroup.Textures[this.OverrideTextureIndex.GetValueOrDefault(this.CurrentFrame.TextureIndex)];
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x0001E371 File Offset: 0x0001C571
		// (set) Token: 0x06000751 RID: 1873 RVA: 0x0001E379 File Offset: 0x0001C579
		public int Index
		{
			get
			{
				return this._animationIndex;
			}
			set
			{
				if (this._animationIndex != value)
				{
					this._animationIndex = value;
					this.CurrentFrameIndex = 0;
					this._frameTime = 0;
				}
			}
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x0001E399 File Offset: 0x0001C599
		public AnimationInstance(ResourceTree resourceTree, string resourceKey, int index = 0)
		{
			this._animationGroup = resourceTree.GetLoadedResource<AnimationGroup>(resourceKey);
			this._animationIndex = index;
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0001E3B5 File Offset: 0x0001C5B5
		public AnimationInstance(AnimationGroup animationGroup, int index = 0)
		{
			this._animationGroup = animationGroup;
			this._animationIndex = index;
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0001E3CB File Offset: 0x0001C5CB
		public void ResetFrame()
		{
			this.CurrentFrameIndex = 0;
			this._frameTime = 0;
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0001E3DC File Offset: 0x0001C5DC
		public void Animate()
		{
			Animation animation = this._animationGroup[this._animationIndex];
			Animation.Frame frame = animation.Frames[this.CurrentFrameIndex];
			int valueOrDefault = this.OverrideDelay.GetValueOrDefault(frame.Delay);
			if (this._frameTime >= valueOrDefault)
			{
				int num = this.CurrentFrameIndex;
				this.CurrentFrameIndex = num + 1;
				if (this.CurrentFrameIndex >= animation.Frames.Count)
				{
					if (animation.LoopFrameIndex != null)
					{
						this.CurrentFrameIndex = animation.LoopFrameIndex.Value;
					}
					else if (animation.NextFrameIndex != null)
					{
						this.Index = animation.NextFrameIndex.Value;
					}
					else
					{
						this.CurrentFrameIndex = 0;
					}
					num = this.Cycles;
					this.Cycles = num + 1;
				}
				this._frameTime = 0;
				return;
			}
			this._frameTime++;
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0001E4D0 File Offset: 0x0001C6D0
		public void Seek(int ticks)
		{
			for (int i = 0; i < ticks; i++)
			{
				this.Animate();
			}
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0001E4EF File Offset: 0x0001C6EF
		public void Draw(I2dRenderer renderer, Vector2 position = default(Vector2), bool flipX = false, bool flipY = false)
		{
			this.Draw(renderer, Colours.White, position, flipX, flipY);
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0001E504 File Offset: 0x0001C704
		public void Draw(I2dRenderer renderer, Colour colour, Vector2 position = default(Vector2), bool flipX = false, bool flipY = false)
		{
			Animation.Frame currentFrame = this.CurrentFrame;
			Rectangle destination = new Rectangle(position.X - (double)(currentFrame.Source.Width / 2), position.Y - (double)(currentFrame.Source.Height / 2), (double)currentFrame.Source.Width, (double)currentFrame.Source.Height);
			this.Draw(renderer, colour, destination, flipX, flipY);
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0001E580 File Offset: 0x0001C780
		public void Draw(I2dRenderer renderer, Colour colour, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			this.Draw(renderer, colour, this.CurrentFrame.Source, destination, flipX, flipY);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0001E5B0 File Offset: 0x0001C7B0
		public void Draw(I2dRenderer renderer, Colour colour, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			Animation.Frame currentFrame = this.CurrentFrame;
			ITexture texture = this._animationGroup.Textures[this.OverrideTextureIndex.GetValueOrDefault(currentFrame.TextureIndex)];
			destination = destination.OffsetBy(currentFrame.Offset);
			renderer.Colour = colour;
			renderer.BlendMode = (this.AdditiveBlending ? BlendMode.Additive : BlendMode.Alpha);
			renderer.RenderTexture(texture, source, destination, flipX, flipY);
			renderer.BlendMode = BlendMode.Alpha;
		}

		// Token: 0x040004D1 RID: 1233
		private readonly AnimationGroup _animationGroup;

		// Token: 0x040004D2 RID: 1234
		private int _animationIndex;

		// Token: 0x040004D3 RID: 1235
		private int _frameTime;
	}
}
