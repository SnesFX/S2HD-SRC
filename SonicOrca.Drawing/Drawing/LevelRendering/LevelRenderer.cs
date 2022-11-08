using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Drawing.Renderers;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Drawing.LevelRendering
{
	// Token: 0x0200001A RID: 26
	public class LevelRenderer : ILevelRenderer, IDisposable
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00007255 File Offset: 0x00005455
		// (set) Token: 0x0600015D RID: 349 RVA: 0x0000725D File Offset: 0x0000545D
		public string[] LastDebugLog { get; private set; }

		// Token: 0x0600015E RID: 350 RVA: 0x00007268 File Offset: 0x00005468
		public LevelRenderer(Level level, IVideoSettings videoSettings)
		{
			this._gameContext = level.GameContext;
			this._level = level;
			this._graphicsContext = this._gameContext.Window.GraphicsContext;
			this._videoSettings = videoSettings;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x000072CF File Offset: 0x000054CF
		public void Dispose()
		{
			this.DisposeCanvas();
			ResourceSession resourceSession = this._resourceSession;
			if (resourceSession == null)
			{
				return;
			}
			resourceSession.Dispose();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000072E8 File Offset: 0x000054E8
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken))
		{
			this._resourceSession = new ResourceSession(this._gameContext.ResourceTree);
			this._resourceSession.PushDependency("SONICORCA/PARTICLE/WATERFALL");
			await this._resourceSession.LoadAsync(default(CancellationToken), false);
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._waterfallDistortionTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/PARTICLE/WATERFALL");
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00007330 File Offset: 0x00005530
		public void Initialise()
		{
			this._tileSet = this._level.TileSet;
			this._particleManager = this._level.ParticleManager;
			this._numLayers = this._level.Map.Layers.Count;
			this._renderingLayers = new RenderingLayer[this._numLayers];
			for (int i = 0; i < this._numLayers; i++)
			{
				RenderingLayer renderingLayer = new RenderingLayer(this._level, i, this._videoSettings);
				renderingLayer.UpdateClippingMarkers();
				this._renderingLayers[i] = renderingLayer;
				renderingLayer.Layer.Index = i;
			}
			this._renderingTileList = new RenderingTileList();
			this._tiler = new RenderingTiler(this._level, this._renderingTileList);
			this.InitialiseShadowRendering();
			this._canvasViewport = new Viewport(this._screenBounds);
			this._canvasViewport.Bounds = this._screenBounds;
			this.InitialiseCanvas(this._canvasViewport.Destination.Width, this._canvasViewport.Destination.Height);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00007440 File Offset: 0x00005640
		public void Render(Renderer renderer, Viewport screenViewport, LayerViewOptions layerViewOptions)
		{
			renderer.DeativateRenderer();
			IFramebuffer currentFramebuffer = this._graphicsContext.CurrentFramebuffer;
			if (this._screenBounds != screenViewport.Destination)
			{
				this._screenBounds = screenViewport.Destination;
				this._canvasViewport = new Viewport(this._screenBounds);
				this.InitialiseCanvas(this._canvasViewport.Destination.Width, this._canvasViewport.Destination.Height);
			}
			this._canvasViewport.Bounds = screenViewport.Bounds;
			if (this._canvasViewport.Bounds.X != this._previousCanvasViewport.X || this._canvasViewport.Bounds.Y != this._previousCanvasViewport.Y)
			{
				this._previousCanvasViewport = this._canvasViewport.Bounds;
			}
			this._canvasFramebuffer.Activate();
			this._graphicsContext.ClearBuffer();
			this.PrepareLayers(this._canvasViewport, layerViewOptions);
			this.PrepareObjects();
			this.DrawLayers(renderer, this._canvasViewport, layerViewOptions);
			if (layerViewOptions.ShowLandscapeCollision)
			{
				this.DrawLandscapeCollision(renderer, layerViewOptions);
			}
			this._level.WaterManager.Draw(renderer, this._canvasViewport);
			renderer.DeativateRenderer();
			RenderingHelpers.RenderToFramebuffer(renderer, this._canvasFramebuffer.Textures[0], currentFramebuffer, this._canvasViewport.Destination, BlendMode.Opaque);
			renderer.DeativateRenderer();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000075B0 File Offset: 0x000057B0
		private void InitialiseCanvas(int width, int height)
		{
			if (this._canvasFramebuffer == null || this._canvasFramebuffer.Width != width || this._canvasFramebuffer.Height != height)
			{
				this.DisposeCanvas();
				this._canvasFramebuffer = this._graphicsContext.CreateFrameBuffer(width, height, 1);
				this._effectFramebuffer = this._graphicsContext.CreateFrameBuffer(width, height, 1);
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000760F File Offset: 0x0000580F
		private void DisposeCanvas()
		{
			IFramebuffer canvasFramebuffer = this._canvasFramebuffer;
			if (canvasFramebuffer != null)
			{
				canvasFramebuffer.Dispose();
			}
			IFramebuffer effectFramebuffer = this._effectFramebuffer;
			if (effectFramebuffer == null)
			{
				return;
			}
			effectFramebuffer.Dispose();
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00007634 File Offset: 0x00005834
		private void PrepareLayers(Viewport canvasViewport, LayerViewOptions layerViewOptions)
		{
			this._renderingTileList.Clear();
			for (int i = 0; i < this._numLayers; i++)
			{
				RenderingLayer renderingLayer = this._renderingLayers[i];
				renderingLayer.Clear();
				if (renderingLayer.Layer.Visible)
				{
					this._tiler.PrepareTiles(renderingLayer, canvasViewport, layerViewOptions);
				}
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00007688 File Offset: 0x00005888
		private void PrepareObjects()
		{
			List<ActiveObject> list = this._level.ObjectManager.ActiveObjects.ToList<ActiveObject>();
			list.Sort((ActiveObject a, ActiveObject b) => a.Priority - b.Priority);
			for (int i = 0; i < this._numLayers; i++)
			{
				this._renderingLayers[i].Clear();
			}
			foreach (ActiveObject activeObject in list)
			{
				int index = activeObject.Layer.Index;
				RenderingLayer renderingLayer = this._renderingLayers[index];
				int priority = activeObject.Priority;
				if (priority < 0)
				{
					renderingLayer.AddLowObject(activeObject);
				}
				else if (priority > 0)
				{
					renderingLayer.AddHighObject(activeObject);
				}
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00007764 File Offset: 0x00005964
		private void DrawLayers(Renderer renderer, Viewport viewport, LayerViewOptions viewOptions)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			Matrix4 modelMatrix = i2dRenderer.ModelMatrix;
			i2dRenderer.ModelMatrix = Matrix4.Identity;
			ITileRenderer tileRenderer = renderer.GetTileRenderer();
			tileRenderer.ClipRectangle = viewport.Destination;
			tileRenderer.ModelMatrix = Matrix4.Identity;
			tileRenderer.Textures = this._tileSet.Textures.ToArray<ITexture>();
			tileRenderer.Filter = viewOptions.Filter;
			tileRenderer.FilterAmount = viewOptions.FilterAmount;
			Stopwatch.StartNew();
			RenderingTiler tiler = this._tiler;
			foreach (RenderingLayer renderingLayer in this._renderingLayers)
			{
				if (renderingLayer.Layer.Visible)
				{
					this.BeginShadowStenciling(renderingLayer.HasShadows);
					this.SetLighting(renderingLayer.Layer, viewOptions);
					this.DrawBackObjects(renderer, viewport, viewOptions, renderingLayer);
					tiler.RenderTiles(i2dRenderer, tileRenderer, renderingLayer.RenderTileIndex, renderingLayer.RenderTileCount);
					this.DrawFrontObjects(renderer, viewport, viewOptions, renderingLayer);
					if (renderingLayer.HasShadows)
					{
						this.DrawShadows(renderer, i2dRenderer, tileRenderer, viewport, viewOptions, renderingLayer);
					}
					if (this._videoSettings.EnableWaterEffects)
					{
						this.RenderWaterfallEffects(renderer, viewport, renderingLayer);
					}
					this.RenderParticles(renderer, viewport, renderingLayer);
				}
			}
			i2dRenderer.ModelMatrix = modelMatrix;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000078A4 File Offset: 0x00005AA4
		private void DrawLandscapeCollision(Renderer renderer, LayerViewOptions layerViewOptions)
		{
			foreach (CollisionVector collisionVector in this._level.CollisionTable.InternalTree.Query(this._canvasViewport.Bounds))
			{
				collisionVector.Draw(renderer, this._canvasViewport);
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00007910 File Offset: 0x00005B10
		private void SetLighting(LevelLayer layer, LayerViewOptions viewOptions)
		{
			viewOptions.Filter = 0;
			viewOptions.FilterAmount = 0.0;
			LevelLayerLightingType type = layer.Lighting.Type;
			if (type != LevelLayerLightingType.Outside)
			{
				if (type != LevelLayerLightingType.Inside)
				{
					return;
				}
				viewOptions.Filter = 2;
				viewOptions.FilterAmount = 1.0 - layer.Lighting.Light;
			}
			else if (this._level.NightMode != 0.0)
			{
				viewOptions.Filter = 1;
				viewOptions.FilterAmount = this._level.NightMode;
				return;
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00007998 File Offset: 0x00005B98
		private void InitialiseShadowRendering()
		{
			GL.StencilMask(255);
			GL.StencilOp(StencilOp.Keep, StencilOp.Replace, StencilOp.Replace);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000079B8 File Offset: 0x00005BB8
		private void BeginShadowStenciling(bool shadowsEnabled)
		{
			if (shadowsEnabled)
			{
				GL.Enable(EnableCap.StencilTest);
				GL.Clear(ClearBufferMask.StencilBufferBit);
				GL.StencilFunc(StencilFunction.Always, 1, 255);
				GL.StencilOp(StencilOp.Keep, StencilOp.Replace, StencilOp.Replace);
				return;
			}
			GL.Disable(EnableCap.StencilTest);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00007A0C File Offset: 0x00005C0C
		private void DrawShadows(Renderer renderer, I2dRenderer g, ITileRenderer tr, Viewport viewport, LayerViewOptions viewOptions, RenderingLayer rlayer)
		{
			GL.StencilFunc(StencilFunction.Equal, 1, 255);
			GL.StencilOp(StencilOp.Keep, StencilOp.Keep, StencilOp.Zero);
			viewOptions.Shadows = true;
			ShadowRenderer.IsShadowing = true;
			Matrix4 modelMatrix = tr.ModelMatrix;
			RenderingTiler tiler = this._tiler;
			foreach (LevelLayerShadow levelLayerShadow in rlayer.Layer.Shadows)
			{
				int num = rlayer.LayerIndex + levelLayerShadow.LayerIndexOffset;
				RenderingLayer renderingLayer = this._renderingLayers[num];
				TileRenderer.ShadowColour = levelLayerShadow.Colour;
				this.DrawBackObjects(renderer, viewport, viewOptions, renderingLayer);
				tr.ModelMatrix = Matrix4.CreateTranslation(levelLayerShadow.Displacement);
				tiler.RenderTiles(g, tr, renderingLayer.RenderTileIndex, renderingLayer.RenderTileCount);
				this.DrawFrontObjects(renderer, viewport, viewOptions, renderingLayer);
			}
			tr.ModelMatrix = modelMatrix;
			ShadowRenderer.IsShadowing = false;
			viewOptions.Shadows = false;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00007B18 File Offset: 0x00005D18
		private void DrawBackObjects(Renderer renderer, Viewport viewport, LayerViewOptions viewOptions, RenderingLayer rlayer)
		{
			if (rlayer.LowObjects != null)
			{
				foreach (ActiveObject activeObject in rlayer.LowObjects)
				{
					activeObject.Draw(renderer, viewport, viewOptions);
				}
			}
			renderer.DeativateRenderer();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00007B7C File Offset: 0x00005D7C
		private void DrawFrontObjects(Renderer renderer, Viewport viewport, LayerViewOptions viewOptions, RenderingLayer rlayer)
		{
			if (rlayer.HighObjects != null)
			{
				foreach (ActiveObject activeObject in rlayer.HighObjects)
				{
					activeObject.Draw(renderer, viewport, viewOptions);
				}
			}
			renderer.DeativateRenderer();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00007BE0 File Offset: 0x00005DE0
		public void RenderToClipboard(Viewport viewport, LayerViewOptions layerViewOptions)
		{
			int num = viewport.Destination.Width * viewport.Destination.Height;
			int num2 = 4194304;
			if (num > num2)
			{
				Trace.WriteLine(string.Format("Copying {0} pixels, Max copy image limit: {1} pixels", num, num2));
				return;
			}
			int width;
			int height;
			byte[] argbData;
			try
			{
				using (IFramebuffer framebuffer = this._gameContext.Window.GraphicsContext.CreateFrameBuffer(viewport.Destination.Width, viewport.Destination.Height, 1))
				{
					using (Renderer renderer = new TheRenderer(this._gameContext.Window))
					{
						framebuffer.Activate();
						this.Render(renderer, viewport, layerViewOptions);
					}
					ITexture texture = framebuffer.Textures[0];
					width = texture.Width;
					height = texture.Height;
					argbData = texture.GetArgbData();
				}
			}
			catch (Exception)
			{
				return;
			}
			try
			{
				using (Bitmap bitmap = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, Marshal.UnsafeAddrOfPinnedArrayElement(argbData, 0)))
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						bitmap.Save(memoryStream, ImageFormat.Png);
						File.WriteAllBytes(Path.Combine(this._gameContext.UserDataDirectory, "copiedtiles.png"), memoryStream.ToArray());
						DataObject dataObject = new DataObject();
						((IDataObject)dataObject).SetData("PNG", false, memoryStream);
						Clipboard.SetDataObject(dataObject, true);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00007DAC File Offset: 0x00005FAC
		private void RenderWaterfallEffects(Renderer renderer, Viewport viewport, RenderingLayer rlayer)
		{
			this.GetWaterfallRegions(rlayer.Layer, viewport);
			if (this._waterfallRegions.Count > 0)
			{
				IFramebuffer canvasFramebuffer = this._canvasFramebuffer;
				ITexture texture = canvasFramebuffer.Textures[0];
				this._effectFramebuffer.Activate();
				this._graphicsContext.ClearBuffer();
				RenderingHelpers.RenderToFramebuffer(renderer, texture, this._effectFramebuffer, BlendMode.Opaque);
				this._waterfallDistortionTexture.Wrapping = TextureWrapping.Repeat;
				WaterfallRenderer waterfallRenderer = WaterfallRenderer.FromRenderer(renderer);
				waterfallRenderer.DistortionOffset = new Vector2(0.0, (double)(this._level.Ticks % 60) / -60.0);
				waterfallRenderer.DistortionTexture = this._waterfallDistortionTexture;
				waterfallRenderer.DistortionAmount = 16.0;
				waterfallRenderer.NonDistortionRadius = new Vector2i(4, 24);
				foreach (Rectanglei destination in this._waterfallRegions)
				{
					Vector2i amount = new Vector2i(0, 1080 - destination.Bottom - destination.Top);
					Rectanglei source = destination.OffsetBy(amount);
					waterfallRenderer.Render(texture, source, destination, false, true);
				}
				RenderingHelpers.RenderToFramebuffer(renderer, this._effectFramebuffer.Textures[0], canvasFramebuffer, BlendMode.Alpha);
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00007F08 File Offset: 0x00006108
		private void GetWaterfallRegions(LevelLayer layer, Viewport viewport)
		{
			this._waterfallRegions.Clear();
			if (layer.WaterfallEffects != null)
			{
				Rectanglei bounds = viewport.Bounds;
				Vector2i amount = new Vector2i(-bounds.X, -bounds.Y);
				foreach (Rectanglei rectanglei in layer.WaterfallEffects)
				{
					Rectanglei rectanglei2 = new Rectanglei(rectanglei.X * 64, rectanglei.Y * 64, rectanglei.Width * 64, rectanglei.Height * 64);
					rectanglei2 = Rectanglei.Intersect(rectanglei2, bounds);
					if (rectanglei2.Width > 0 && rectanglei2.Height > 0)
					{
						rectanglei2 = rectanglei2.OffsetBy(amount);
						this._waterfallRegions.Add(rectanglei2);
					}
				}
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00007FE8 File Offset: 0x000061E8
		private void RenderParticles(Renderer renderer, Viewport viewport, RenderingLayer rlayer)
		{
			renderer.DeativateRenderer();
			this._particleManager.Draw(renderer, viewport, rlayer.Layer, this._videoSettings);
		}

		// Token: 0x040000DD RID: 221
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040000DE RID: 222
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x040000DF RID: 223
		private readonly IVideoSettings _videoSettings;

		// Token: 0x040000E0 RID: 224
		private readonly Level _level;

		// Token: 0x040000E1 RID: 225
		private TileSet _tileSet;

		// Token: 0x040000E2 RID: 226
		private ParticleManager _particleManager;

		// Token: 0x040000E3 RID: 227
		private ResourceSession _resourceSession;

		// Token: 0x040000E4 RID: 228
		private IFramebuffer _canvasFramebuffer;

		// Token: 0x040000E5 RID: 229
		private IFramebuffer _effectFramebuffer;

		// Token: 0x040000E6 RID: 230
		private RenderingLayer[] _renderingLayers;

		// Token: 0x040000E7 RID: 231
		private RenderingTileList _renderingTileList;

		// Token: 0x040000E8 RID: 232
		private RenderingTiler _tiler;

		// Token: 0x040000E9 RID: 233
		private int _numLayers;

		// Token: 0x040000EB RID: 235
		private Rectanglei _previousCanvasViewport;

		// Token: 0x040000EC RID: 236
		private Rectanglei _screenBounds = new Rectanglei(0, 0, 1920, 1080);

		// Token: 0x040000ED RID: 237
		private Viewport _canvasViewport;

		// Token: 0x040000EE RID: 238
		private const string WaterfallDistortionTextureResourceKey = "SONICORCA/PARTICLE/WATERFALL";

		// Token: 0x040000EF RID: 239
		private ITexture _waterfallDistortionTexture;

		// Token: 0x040000F0 RID: 240
		private readonly List<Rectanglei> _waterfallRegions = new List<Rectanglei>(16);
	}
}
