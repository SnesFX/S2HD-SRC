using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Lighting;
using SonicOrca.Core.Objects;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.LAVA
{
	// Token: 0x02000030 RID: 48
	public class LavaInstance : ActiveObject
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00008E61 File Offset: 0x00007061
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00008E6E File Offset: 0x0000706E
		public int Width
		{
			get
			{
				return this._size.X;
			}
			set
			{
				this._size.X = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00008E7C File Offset: 0x0000707C
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00008E89 File Offset: 0x00007089
		public int Height
		{
			get
			{
				return this._size.Y;
			}
			set
			{
				this._size.Y = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00008E98 File Offset: 0x00007098
		private Rectanglei Bounds
		{
			get
			{
				return new Rectanglei(-this._size.X / 2 * 64, -this._size.Y / 2 * 64, this._size.X * 64, this._size.Y * 64);
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00008EE8 File Offset: 0x000070E8
		protected override void OnStart()
		{
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type.GetAbsolutePath("/ANIGROUP"));
			this._animationTop = new AnimationInstance(loadedResource, 0);
			this._animationMiddle = new AnimationInstance(loadedResource, 1);
			this._animationBottom = new AnimationInstance(loadedResource, 2);
			base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectanglei(-this._size.X / 2 * 64, -this._size.Y / 2 * 64, this._size.X * 64, this._size.Y * 64), uint.MaxValue, (CollisionFlags)0);
			base.CollisionVectors[1].Flags = CollisionFlags.Conveyor;
			base.Priority = 4096;
			Rectanglei designBounds = this.Bounds;
			base.DesignBounds = designBounds;
			designBounds = designBounds.OffsetBy(base.Position);
			this._lightSource = new VectorLightSource(32, designBounds.TopLeft, designBounds.TopRight);
			base.Level.LightingManager.RegisterLightSource(this._lightSource);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00008FEF File Offset: 0x000071EF
		protected override void OnStop()
		{
			base.Level.LightingManager.UnregisterLightSource(this._lightSource);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00009007 File Offset: 0x00007207
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			((ICharacter)e.ActiveObject).Hurt(-1, PlayerDeathCause.Hurt);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00009030 File Offset: 0x00007230
		protected override void OnUpdate()
		{
			Rectanglei rectanglei = this.Bounds.OffsetBy(base.Position);
			this._lightSource.A = rectanglei.TopLeft;
			this._lightSource.B = rectanglei.TopRight;
			if (base.Level.Ticks % 24 != 0)
			{
				return;
			}
			ParticleManager particleManager = base.Level.ParticleManager;
			Random random = particleManager.Random;
			int num = -this._size.X / 2 * 64;
			int num2 = -this._size.Y / 2 * 64;
			for (int i = 0; i < this._size.X; i++)
			{
				for (int j = 0; j < 1; j++)
				{
					Vector2i a = base.Position + new Vector2i(num + i * 64 + 32, num2 + j * 64 + 32);
					particleManager.Add(new Particle
					{
						Type = ParticleType.Heat,
						Layer = base.Layer,
						Position = a + new Vector2i(random.Next(-4, 8), random.Next(-4, 8)),
						Velocity = new Vector2(random.NextSignedDouble() * 1.0, random.NextDouble() * -1.4 - 0.8),
						Time = random.Next(60, 120)
					});
				}
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000091A9 File Offset: 0x000073A9
		protected override void OnAnimate()
		{
			this._animationTop.Animate();
			this._animationMiddle.Animate();
			this._animationBottom.Animate();
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000091CC File Offset: 0x000073CC
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (viewOptions.Shadows)
			{
				return;
			}
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.EmitsLight = true;
			int num = -this._size.X / 2 * 64;
			int num2 = -this._size.Y / 2 * 64;
			int num3 = (this._size.X + 1) / 2 * 64;
			int num4 = (this._size.Y + 1) / 2 * 64;
			Rectanglei source = this._animationTop.CurrentFrame.Source;
			for (int i = num; i < num3; i += source.Width)
			{
				Rectangle destination = new Rectangle((double)i, (double)(num2 - source.Height), (double)source.Width, (double)source.Height);
				destination.Right = Math.Min(destination.Right, (double)num3);
				destination.Bottom = Math.Min(destination.Bottom, (double)num4);
				Rectangle source2 = this._animationTop.CurrentFrame.Source;
				source2.Width = destination.Width;
				source2.Height = destination.Height;
				objectRenderer.Texture = this._animationTop.CurrentTexture;
				objectRenderer.BlendMode = BlendMode.Additive;
				destination.X *= objectRenderer.Scale.X;
				destination.Y *= objectRenderer.Scale.Y;
				destination.Width *= objectRenderer.Scale.X;
				destination.Height *= objectRenderer.Scale.Y;
				objectRenderer.Render(source2, destination, false, false);
			}
			objectRenderer.BlendMode = BlendMode.Alpha;
			int num5 = num2;
			source = this._animationMiddle.CurrentFrame.Source;
			for (int j = num; j < num3; j += source.Width)
			{
				Rectangle destination2 = new Rectangle((double)j, (double)num2, (double)source.Width, (double)source.Height);
				destination2.Right = Math.Min(destination2.Right, (double)num3);
				destination2.Bottom = Math.Min(destination2.Bottom, (double)num4);
				Rectangle source3 = this._animationMiddle.CurrentFrame.Source;
				source3.Width = destination2.Width;
				source3.Height = destination2.Height;
				num5 = (int)destination2.Bottom;
				destination2.X *= objectRenderer.Scale.X;
				destination2.Y *= objectRenderer.Scale.Y;
				destination2.Width *= objectRenderer.Scale.X;
				destination2.Height *= objectRenderer.Scale.Y;
				objectRenderer.Texture = this._animationMiddle.CurrentTexture;
				objectRenderer.Render(source3, destination2, false, false);
			}
			if (num5 >= num4)
			{
				return;
			}
			source = this._animationBottom.CurrentFrame.Source;
			for (int k = num5; k < num4; k += source.Height)
			{
				for (int l = num; l < num3; l += source.Width)
				{
					Rectangle destination3 = new Rectangle((double)l, (double)k, (double)source.Width, (double)source.Height);
					destination3.Right = Math.Min(destination3.Right, (double)num3);
					destination3.Bottom = Math.Min(destination3.Bottom, (double)num4);
					Rectangle source4 = this._animationBottom.CurrentFrame.Source;
					source4.Width = destination3.Width;
					source4.Height = destination3.Height;
					destination3.X *= objectRenderer.Scale.X;
					destination3.Y *= objectRenderer.Scale.Y;
					destination3.Width *= objectRenderer.Scale.X;
					destination3.Height *= objectRenderer.Scale.Y;
					objectRenderer.Texture = this._animationBottom.CurrentTexture;
					objectRenderer.Render(source4, destination3, false, false);
				}
			}
		}

		// Token: 0x04000122 RID: 290
		private const int AnimationTop = 0;

		// Token: 0x04000123 RID: 291
		private const int AnimationMiddle = 1;

		// Token: 0x04000124 RID: 292
		private const int AnimationBottom = 2;

		// Token: 0x04000125 RID: 293
		private AnimationInstance _animationTop;

		// Token: 0x04000126 RID: 294
		private AnimationInstance _animationMiddle;

		// Token: 0x04000127 RID: 295
		private AnimationInstance _animationBottom;

		// Token: 0x04000128 RID: 296
		private Vector2i _size = new Vector2i(1, 1);

		// Token: 0x04000129 RID: 297
		private VectorLightSource _lightSource;
	}
}
