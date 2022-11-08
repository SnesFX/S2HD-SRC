using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000132 RID: 306
	public class ParticleManager : IDisposable
	{
		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000C08 RID: 3080 RVA: 0x0002E971 File Offset: 0x0002CB71
		public Random Random
		{
			get
			{
				return this._random;
			}
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x0002E97C File Offset: 0x0002CB7C
		public ParticleManager(Level level)
		{
			this._gameContext = level.GameContext;
			this._level = level;
			this._resourceSession = new ResourceSession(this._gameContext.ResourceTree);
			this._workCanvas = this._gameContext.Window.GraphicsContext.CreateFrameBuffer(128, 128, 1);
			this._enabled = this._gameContext.Configuration.GetPropertyBoolean("graphics", "particles", true);
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x0002EA18 File Offset: 0x0002CC18
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession.PushDependencies(new string[]
			{
				"SONICORCA/PARTICLE/HEAT",
				"SONICORCA/PARTICLE/SMOKE"
			});
			await this._resourceSession.LoadAsync(default(CancellationToken), false);
			this._heatParticleTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/PARTICLE/HEAT");
			this._smokeParticleTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/PARTICLE/SMOKE");
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0002EA5D File Offset: 0x0002CC5D
		public void Dispose()
		{
			this._resourceSession.Dispose();
			if (this._workCanvas != null)
			{
				this._workCanvas.Dispose();
			}
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x0002EA80 File Offset: 0x0002CC80
		public int GetNumParticlesOnLayer(LevelLayer layer)
		{
			return this._particles.Count((Particle x) => x.Layer == layer);
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x0002EAB1 File Offset: 0x0002CCB1
		public void Add(Particle p)
		{
			if (this._enabled)
			{
				this._particles.Add(p);
			}
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x0002EAC7 File Offset: 0x0002CCC7
		public void Clear()
		{
			this._particles.Clear();
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x0002EAD4 File Offset: 0x0002CCD4
		public void Update()
		{
			if (!this._enabled)
			{
				return;
			}
			foreach (Particle particle in this._particles)
			{
				particle.Update();
			}
			this._particles.RemoveAll((Particle x) => x.Time <= 0);
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x0002EB58 File Offset: 0x0002CD58
		public void Draw(Renderer renderer, Viewport viewport, LevelLayer layer, IVideoSettings videoSettings)
		{
			if (!this._enabled || this._particles.Count == 0)
			{
				return;
			}
			IFramebuffer currentFramebuffer = renderer.Window.GraphicsContext.CurrentFramebuffer;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IHeatRenderer heatRenderer = renderer.GetHeatRenderer();
			heatRenderer.DistortionTexture = this._heatParticleTexture;
			Matrix4 modelMatrix = i2dRenderer.ModelMatrix;
			foreach (Particle particle in this._particles)
			{
				if (particle.Layer == layer)
				{
					switch (particle.Type)
					{
					case ParticleType.Heat:
						if (videoSettings.EnableHeatEffects)
						{
							renderer.DeativateRenderer();
							Rectanglei destination = new Rectangle(particle.Position.X - (double)(this._heatParticleTexture.Width / 2), particle.Position.Y - (double)(this._heatParticleTexture.Height / 2), (double)this._heatParticleTexture.Width, (double)this._heatParticleTexture.Height).OffsetBy(viewport.Bounds.TopLeft * -1);
							if (destination.IntersectsWith(new Rectanglei(0, 0, currentFramebuffer.Width, currentFramebuffer.Height)))
							{
								heatRenderer.DistortionAmount = 1.0 / (double)this._heatParticleTexture.Width * 8.0;
								if (particle.Time < 60)
								{
									heatRenderer.DistortionAmount *= (double)particle.Time / 60.0;
								}
								this._workCanvas.Activate();
								i2dRenderer.BlendMode = BlendMode.Opaque;
								i2dRenderer.Colour = Colours.White;
								i2dRenderer.ClipRectangle = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
								i2dRenderer.ModelMatrix = Matrix4.Identity;
								i2dRenderer.RenderTexture(currentFramebuffer.Textures[0], new Rectanglei(destination.X, 1080 - destination.Bottom, destination.Width, destination.Height), new Rectanglei(0, 0, destination.Width, destination.Height), false, false);
								i2dRenderer.Deactivate();
								currentFramebuffer.Activate();
								heatRenderer.Render(this._workCanvas.Textures[0], new Rectanglei(0, 0, destination.Width, destination.Height), destination, false, false);
							}
						}
						break;
					case ParticleType.Smoke:
					{
						Vector2 vector = particle.Position - viewport.Bounds.TopLeft;
						if (new Rectangle(vector.X - (double)(this._smokeParticleTexture.Width / 2), vector.Y - (double)(this._smokeParticleTexture.Height / 2), (double)this._smokeParticleTexture.Width, (double)this._smokeParticleTexture.Height).IntersectsWith(new Rectanglei(0, 0, currentFramebuffer.Width, currentFramebuffer.Height)))
						{
							double a = ((particle.Time < 120) ? ((double)particle.Time / 120.0) : 1.0) * 0.2;
							currentFramebuffer.Activate();
							i2dRenderer.BlendMode = BlendMode.Alpha;
							i2dRenderer.Colour = new Colour(a, 1.0, 1.0, 1.0);
							i2dRenderer.ClipRectangle = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
							i2dRenderer.ModelMatrix = Matrix4.CreateTranslation(vector.X, vector.Y, 0.0) * Matrix4.CreateRotationZ(particle.Angle);
							i2dRenderer.RenderTexture(this._smokeParticleTexture, default(Vector2), false, false);
						}
						break;
					}
					case ParticleType.Custom:
					{
						ITexture customTexture = particle.CustomTexture;
						if (customTexture != null)
						{
							Vector2 vector2 = particle.Position - viewport.Bounds.TopLeft;
							if (new Rectangle(vector2.X - (double)(customTexture.Width / 2), vector2.Y - (double)(customTexture.Height / 2), (double)customTexture.Width, (double)customTexture.Height).IntersectsWith(new Rectanglei(0, 0, currentFramebuffer.Width, currentFramebuffer.Height)))
							{
								currentFramebuffer.Activate();
								i2dRenderer.BlendMode = BlendMode.Alpha;
								i2dRenderer.Colour = new Colour(1.0, 1.0, 1.0, 1.0);
								i2dRenderer.ClipRectangle = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
								i2dRenderer.ModelMatrix = Matrix4.CreateTranslation(vector2.X, vector2.Y, 0.0) * Matrix4.CreateRotationZ(particle.Angle) * Matrix4.CreateScale(particle.Size, particle.Size, 1.0);
								i2dRenderer.RenderTexture(customTexture, default(Vector2), false, false);
							}
						}
						break;
					}
					}
				}
			}
			renderer.DeativateRenderer();
			i2dRenderer.ModelMatrix = modelMatrix;
		}

		// Token: 0x040006EF RID: 1775
		private const string HeatParticleTextureResourceKey = "SONICORCA/PARTICLE/HEAT";

		// Token: 0x040006F0 RID: 1776
		private const string SmokeParticleTextureResourceKey = "SONICORCA/PARTICLE/SMOKE";

		// Token: 0x040006F1 RID: 1777
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040006F2 RID: 1778
		private readonly Level _level;

		// Token: 0x040006F3 RID: 1779
		private readonly Random _random = new Random();

		// Token: 0x040006F4 RID: 1780
		private readonly List<Particle> _particles = new List<Particle>();

		// Token: 0x040006F5 RID: 1781
		private readonly ResourceSession _resourceSession;

		// Token: 0x040006F6 RID: 1782
		private ITexture _heatParticleTexture;

		// Token: 0x040006F7 RID: 1783
		private ITexture _smokeParticleTexture;

		// Token: 0x040006F8 RID: 1784
		private IFramebuffer _workCanvas;

		// Token: 0x040006F9 RID: 1785
		private bool _enabled;
	}
}
