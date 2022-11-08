using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000ED RID: 237
	public class CompositionInstance
	{
		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x0001FB17 File Offset: 0x0001DD17
		public CompositionGroup CompositionGroup
		{
			get
			{
				return this._compositionGroup;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0001FB1F File Offset: 0x0001DD1F
		// (set) Token: 0x0600082F RID: 2095 RVA: 0x0001FB27 File Offset: 0x0001DD27
		public bool AdditiveBlending { get; set; }

		// Token: 0x06000830 RID: 2096 RVA: 0x0001FB30 File Offset: 0x0001DD30
		public CompositionInstance(ResourceTree resourceTree, string resourceKey)
		{
			this._compositionGroup = resourceTree.GetLoadedResource<CompositionGroup>(resourceKey);
			this._composition = this._compositionGroup.First<Composition>();
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0001FB84 File Offset: 0x0001DD84
		public CompositionInstance(CompositionGroup compositionGroup)
		{
			this._compositionGroup = compositionGroup;
			this._composition = this._compositionGroup.First<Composition>();
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0001FBD0 File Offset: 0x0001DDD0
		public void ResetFrame()
		{
			this._ellapsedFrames = 0;
			this._playing = false;
			this._finished = false;
			foreach (CompositionLayer compositionLayer in this._composition.Layers)
			{
				compositionLayer.ResetFrame();
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x0001FC34 File Offset: 0x0001DE34
		public bool Playing
		{
			get
			{
				return this._playing;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x0001FC3C File Offset: 0x0001DE3C
		public bool Finished
		{
			get
			{
				return this._finished;
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0001FC44 File Offset: 0x0001DE44
		public void Animate()
		{
			if ((long)this._ellapsedFrames >= (long)((ulong)this._composition.StartFrame) && (long)this._ellapsedFrames <= (long)((ulong)this._composition.EndFrame))
			{
				foreach (CompositionLayer compositionLayer in this._composition.Layers)
				{
					compositionLayer.Animate();
				}
			}
			if ((long)this._ellapsedFrames > (long)((ulong)this._composition.EndFrame))
			{
				this._playing = false;
				this._finished = true;
				return;
			}
			this._playing = true;
			this._ellapsedFrames++;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0001FCF8 File Offset: 0x0001DEF8
		public void Seek(int ticks)
		{
			this.ResetFrame();
			for (int i = 0; i < ticks; i++)
			{
				this.Animate();
			}
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0001FD1D File Offset: 0x0001DF1D
		public void Draw(Renderer renderer, Vector2 offset = default(Vector2), bool flipX = false, bool flipY = false)
		{
			this.Draw(renderer, Colours.White, offset, flipX, flipY);
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0001FD30 File Offset: 0x0001DF30
		private Composition.Frame CurrentFrame
		{
			get
			{
				Composition.Frame result = default(Composition.Frame);
				CompositionLayer currentLayer = this._activeLayers.ElementAt(this._currentRenderLayerIndex);
				CompositionLayerAnimatableTransform transform = currentLayer.Transform;
				result.TextureIndex = this._compositionGroup.Assets.TakeWhile((CompositionAsset x) => x.ID != currentLayer.TextureReference).Count<CompositionAsset>();
				result.Source = new Rectanglei(0, 0, this._compositionGroup.Assets.ElementAt(result.TextureIndex).Width, this._compositionGroup.Assets.ElementAt(result.TextureIndex).Height);
				result.Opacity = transform.Opacity;
				result.Position = transform.Position;
				result.Rotation = transform.Rotation;
				result.Scale = transform.Scale;
				return result;
			}
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0001FE14 File Offset: 0x0001E014
		private Composition.Frame GetMaskFrameForLayer(CompositionLayer layer)
		{
			Composition.Frame result = default(Composition.Frame);
			CompositionLayer currentMask = (from m in this._masks
			select m into m
			where m.Index == layer.Index - 1U && m.SubKind == CompositionLayer.LayerSubKind.Mask
			select m).First<CompositionLayer>();
			CompositionLayerAnimatableTransform transform = currentMask.Transform;
			result.TextureIndex = this._compositionGroup.Assets.TakeWhile((CompositionAsset x) => x.ID != currentMask.TextureReference).Count<CompositionAsset>();
			result.Source = new Rectanglei(0, 0, this._compositionGroup.Assets.ElementAt(result.TextureIndex).Width, this._compositionGroup.Assets.ElementAt(result.TextureIndex).Height);
			result.Opacity = transform.Opacity;
			result.Position = transform.Position;
			result.Rotation = transform.Rotation;
			result.Scale = transform.Scale;
			return result;
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0001FF2C File Offset: 0x0001E12C
		private List<CompositionLayer> GetActiveLayers()
		{
			IEnumerable<CompositionLayer> activeLayers = (from l in this._composition.Layers
			select l).Where(delegate(CompositionLayer l)
			{
				if ((long)this._ellapsedFrames >= (long)((ulong)l.StartFrame) && l.Transform.Tweens.Count > 0 && l.Transform.Tweens.Any((CompositionLayerTween t) => t.HasKeyFrames && (long)this._ellapsedFrames >= (long)((ulong)t.StartFrame)))
				{
					return true;
				}
				if ((long)this._ellapsedFrames >= (long)((ulong)l.StartFrame))
				{
					return l.Transform.Tweens.All((CompositionLayerTween t) => !t.HasKeyFrames);
				}
				return false;
			});
			this._masks.AddRange(from m in activeLayers
			select m into m
			where m.SubKind == CompositionLayer.LayerSubKind.Mask
			select m);
			this._maskedLayers.AddRange(from l in activeLayers
			select l into l
			where activeLayers.Any((CompositionLayer m) => m.SubKind == CompositionLayer.LayerSubKind.Mask && m.Index == l.Index - 1U)
			select l);
			IEnumerable<CompositionLayer> collection = from l in activeLayers
			select l into l
			where l.SubKind == CompositionLayer.LayerSubKind.None && !this._composition.Layers.Any((CompositionLayer m) => m.SubKind == CompositionLayer.LayerSubKind.Mask && m.Index == l.Index - 1U)
			select l;
			this._activeLayers.AddRange(collection);
			this._activeLayers.AddRange(this._maskedLayers);
			this._activeLayers = (from l in this._activeLayers
			orderby l.Index descending
			select l).ToList<CompositionLayer>();
			return this._activeLayers;
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x000200B8 File Offset: 0x0001E2B8
		public void Draw(Renderer renderer, Colour colour, Vector2 offset = default(Vector2), bool flipX = false, bool flipY = false)
		{
			this._masks.Clear();
			this._maskedLayers.Clear();
			this._activeLayers.Clear();
			this._activeLayers = this.GetActiveLayers();
			for (int i = 0; i < this._activeLayers.Count<CompositionLayer>(); i++)
			{
				this._currentRenderLayerIndex = i;
				Composition.Frame currentFrame = this.CurrentFrame;
				Rectangle targetDestination = new Rectangle(offset.X - (double)currentFrame.Source.Width * 0.5, offset.Y - (double)currentFrame.Source.Height * 0.5, (double)currentFrame.Source.Width, (double)currentFrame.Source.Height);
				this.AdditiveBlending = (this._activeLayers.ElementAt(i).BlendMode == BlendMode.Additive);
				if (!this._maskedLayers.Contains(this._activeLayers.ElementAt(i)))
				{
					IMaskRenderer maskRenderer = renderer.GetMaskRenderer();
					this.Draw(maskRenderer, colour, currentFrame.Source, targetDestination, flipX, flipY);
				}
				else
				{
					IMaskRenderer maskRenderer2 = renderer.GetMaskRenderer();
					Composition.Frame maskFrameForLayer = this.GetMaskFrameForLayer(this._activeLayers.ElementAt(i));
					Rectangle maskDestination = new Rectangle(offset.X - (double)maskFrameForLayer.Source.Width * 0.5 * (maskFrameForLayer.Scale.X * 0.01), offset.Y - (double)maskFrameForLayer.Source.Height * 0.5 * (maskFrameForLayer.Scale.Y * 0.01), (double)maskFrameForLayer.Source.Width * maskFrameForLayer.Scale.X * 0.01, (double)maskFrameForLayer.Source.Height * maskFrameForLayer.Scale.Y * 0.01);
					this.Draw(maskRenderer2, maskFrameForLayer, colour, maskFrameForLayer.Source, maskDestination, currentFrame.Source, targetDestination, flipX, flipY);
				}
			}
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00020300 File Offset: 0x0001E500
		public void Draw(I2dRenderer renderer, Colour colour, Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false)
		{
			Composition.Frame currentFrame = this.CurrentFrame;
			ITexture texture = this._compositionGroup.Textures[currentFrame.TextureIndex];
			using (renderer.BeginMatixState())
			{
				Matrix4 matrix = Matrix4.Identity;
				matrix *= Matrix4.CreateTranslation(currentFrame.Position);
				matrix = (matrix * Matrix4.CreateScale(currentFrame.Scale.X * 0.01, currentFrame.Scale.Y * 0.01, 1.0)).RotateZ(currentFrame.Rotation);
				colour.Alpha = (byte)(currentFrame.Opacity * 0.01 * 256.0);
				renderer.ModelMatrix = matrix;
				renderer.Colour = colour;
				renderer.BlendMode = (this.AdditiveBlending ? BlendMode.Additive : BlendMode.Alpha);
				renderer.RenderTexture(texture, source, destination, flipX, flipY);
			}
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00020414 File Offset: 0x0001E614
		public void Draw(IMaskRenderer renderer, Colour colour, Rectangle targetSource, Rectangle targetDestination, bool flipX = false, bool flipY = false)
		{
			Composition.Frame currentFrame = this.CurrentFrame;
			ITexture texture = this._compositionGroup.Textures[currentFrame.TextureIndex];
			using (renderer.BeginMatixState())
			{
				double num = 1.0;
				double num2 = 1.0;
				if (flipX)
				{
					num = -1.0;
				}
				if (flipY)
				{
					num2 = -1.0;
				}
				Matrix4 matrix = Matrix4.Identity;
				matrix *= Matrix4.CreateTranslation(currentFrame.Position);
				matrix = (matrix * Matrix4.CreateScale(currentFrame.Scale.X * 0.01 * num, currentFrame.Scale.Y * 0.01 * num2, 1.0)).RotateZ(currentFrame.Rotation);
				renderer.BlendMode = (this.AdditiveBlending ? BlendMode.Additive : BlendMode.Alpha);
				renderer.Colour = colour;
				renderer.TargetModelMatrix = matrix;
				renderer.Source = targetSource;
				renderer.Destination = targetDestination;
				renderer.Texture = texture;
				renderer.MaskTexture = null;
				renderer.Render(false);
			}
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x00020560 File Offset: 0x0001E760
		public void Draw(IMaskRenderer renderer, Composition.Frame maskFrame, Colour colour, Rectangle maskSource, Rectangle maskDestination, Rectangle targetSource, Rectangle targetDestination, bool flipX = false, bool flipY = false)
		{
			Composition.Frame currentFrame = this.CurrentFrame;
			ITexture texture = this._compositionGroup.Textures[currentFrame.TextureIndex];
			ITexture maskTexture = this._compositionGroup.Textures[maskFrame.TextureIndex];
			using (renderer.BeginMatixState())
			{
				Matrix4 matrix = Matrix4.Identity;
				matrix *= Matrix4.CreateTranslation(maskFrame.Position);
				Matrix4 matrix2 = Matrix4.Identity;
				matrix2 *= Matrix4.CreateTranslation(new Vector2(0.5));
				matrix2 *= Matrix4.CreateScale(1.0 / (currentFrame.Scale.X * 0.01), 1.0 / (currentFrame.Scale.Y * 0.01), 1.0);
				matrix2 *= Matrix4.CreateRotationZ(0.0);
				matrix2 *= Matrix4.CreateTranslation(new Vector2(-0.5));
				Matrix4 matrix3 = Matrix4.Identity;
				matrix3 *= Matrix4.CreateTranslation(new Vector2(0.5));
				matrix3 *= Matrix4.CreateRotationZ(maskFrame.Rotation);
				matrix3 *= Matrix4.CreateTranslation(new Vector2(-0.5));
				renderer.BlendMode = (this.AdditiveBlending ? BlendMode.Additive : BlendMode.Alpha);
				renderer.Colour = colour;
				renderer.IntersectionModelMatrix = matrix;
				renderer.MaskModelMatrix = matrix3;
				renderer.MaskSource = maskSource;
				renderer.MaskDestination = maskDestination;
				renderer.MaskTexture = maskTexture;
				renderer.TargetModelMatrix = matrix2;
				renderer.Source = targetSource;
				renderer.Destination = targetDestination;
				renderer.Texture = texture;
				renderer.Render(false);
			}
		}

		// Token: 0x04000500 RID: 1280
		private readonly CompositionGroup _compositionGroup;

		// Token: 0x04000501 RID: 1281
		private int _ellapsedFrames;

		// Token: 0x04000502 RID: 1282
		private int _currentRenderLayerIndex;

		// Token: 0x04000503 RID: 1283
		private List<CompositionLayer> _activeLayers = new List<CompositionLayer>();

		// Token: 0x04000504 RID: 1284
		private Composition _composition;

		// Token: 0x04000506 RID: 1286
		private bool _playing;

		// Token: 0x04000507 RID: 1287
		private bool _finished;

		// Token: 0x04000508 RID: 1288
		private List<CompositionLayer> _maskedLayers = new List<CompositionLayer>();

		// Token: 0x04000509 RID: 1289
		private List<CompositionLayer> _masks = new List<CompositionLayer>();
	}
}
