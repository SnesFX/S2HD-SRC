using System;
using SonicOrca.Audio;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x02000146 RID: 326
	public class LevelSound : IDisposable
	{
		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000D6A RID: 3434 RVA: 0x0003335F File Offset: 0x0003155F
		// (set) Token: 0x06000D6B RID: 3435 RVA: 0x00033367 File Offset: 0x00031567
		public Vector2i Position { get; set; }

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000D6C RID: 3436 RVA: 0x00033370 File Offset: 0x00031570
		// (set) Token: 0x06000D6D RID: 3437 RVA: 0x00033378 File Offset: 0x00031578
		public bool Finished { get; private set; }

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000D6E RID: 3438 RVA: 0x00033381 File Offset: 0x00031581
		// (set) Token: 0x06000D6F RID: 3439 RVA: 0x00033389 File Offset: 0x00031589
		public int DistanceAudible { get; set; } = 1000;

		// Token: 0x06000D70 RID: 3440 RVA: 0x00033394 File Offset: 0x00031594
		public LevelSound(Level level, Sample sample, Vector2i position = default(Vector2i), bool autoFinish = true)
		{
			this._level = level;
			this._instance = new SampleInstance(this._level.GameContext, sample, null);
			this._instance.Classification = SampleInstanceClassification.Sound;
			this._autoFinish = autoFinish;
			this.Position = position;
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x000333F4 File Offset: 0x000315F4
		public LevelSound(Level level, SampleInfo sampleInfo, Vector2i position = default(Vector2i), bool autoFinish = true)
		{
			this._level = level;
			this._instance = new SampleInstance(this._level.GameContext, sampleInfo);
			this._instance.Classification = SampleInstanceClassification.Sound;
			this._autoFinish = autoFinish;
			this.Position = position;
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x0003344B File Offset: 0x0003164B
		public void Dispose()
		{
			this._instance.Dispose();
			this.Finished = true;
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x0003345F File Offset: 0x0003165F
		public void Update()
		{
			this.UpdatePanAndVolume();
			if (this._autoFinish && !this._instance.Playing)
			{
				this.Finished = true;
			}
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00033484 File Offset: 0x00031684
		private void UpdatePanAndVolume()
		{
			Camera camera = this._level.Camera;
			double num = camera.Bounds.X + camera.Bounds.Width / 2.0;
			double num2 = (double)this.Position.X - num;
			if (Math.Abs(num2) < 512.0)
			{
				this._instance.Pan = 0.0;
			}
			else
			{
				this._instance.Pan = MathX.Clamp(-1.0, num2 / camera.Bounds.Width, 1.0);
			}
			double num3 = 0.0;
			if ((double)this.Position.X < camera.Bounds.X)
			{
				num3 = camera.Bounds.X - (double)this.Position.X;
			}
			else if ((double)this.Position.X > camera.Bounds.Right)
			{
				num3 = (double)this.Position.X - camera.Bounds.Right;
			}
			this._instance.Volume = MathX.Clamp(0.0, 1.0 - num3 / (double)this.DistanceAudible, 1.0);
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x000335F9 File Offset: 0x000317F9
		public void Play()
		{
			this._instance.Play();
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x00033606 File Offset: 0x00031806
		public void Stop()
		{
			this._instance.Stop();
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x00033613 File Offset: 0x00031813
		public void Pause()
		{
			if (this._instance.Playing)
			{
				this._instance.Stop();
				this._paused = true;
			}
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x00033634 File Offset: 0x00031834
		public void Resume()
		{
			if (this._paused)
			{
				this._paused = false;
				this._instance.Play();
			}
		}

		// Token: 0x0400079B RID: 1947
		private readonly Level _level;

		// Token: 0x0400079C RID: 1948
		private readonly SampleInstance _instance;

		// Token: 0x0400079D RID: 1949
		private readonly bool _autoFinish;

		// Token: 0x0400079E RID: 1950
		private bool _paused;
	}
}
