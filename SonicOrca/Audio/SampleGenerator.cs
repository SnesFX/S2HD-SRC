using System;

namespace SonicOrca.Audio
{
	// Token: 0x020001A5 RID: 421
	public abstract class SampleGenerator : IDisposable, ISampleProvider
	{
		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06001215 RID: 4629 RVA: 0x000477E2 File Offset: 0x000459E2
		// (set) Token: 0x06001216 RID: 4630 RVA: 0x000477EA File Offset: 0x000459EA
		public double Volume { get; set; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06001217 RID: 4631 RVA: 0x000477F3 File Offset: 0x000459F3
		// (set) Token: 0x06001218 RID: 4632 RVA: 0x000477FB File Offset: 0x000459FB
		public double Pan { get; set; }

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06001219 RID: 4633 RVA: 0x00047804 File Offset: 0x00045A04
		// (set) Token: 0x0600121A RID: 4634 RVA: 0x0004780C File Offset: 0x00045A0C
		public SampleInstanceClassification Classification { get; set; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x0600121B RID: 4635 RVA: 0x00047815 File Offset: 0x00045A15
		// (set) Token: 0x0600121C RID: 4636 RVA: 0x0004781D File Offset: 0x00045A1D
		public bool Playing { get; private set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x0600121D RID: 4637 RVA: 0x00047828 File Offset: 0x00045A28
		public double CalculatedVolume
		{
			get
			{
				double num = this.Volume;
				if (this.Classification == SampleInstanceClassification.Sound)
				{
					num *= this._audioAdapter.SoundVolume;
				}
				else if (this.Classification == SampleInstanceClassification.Music)
				{
					num *= this._audioAdapter.MusicVolume;
				}
				return num * this._audioAdapter.Volume;
			}
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x0004787B File Offset: 0x00045A7B
		public SampleGenerator(AudioContext audioAdapter)
		{
			this._audioAdapter = audioAdapter;
			this.Volume = 1.0;
			this._audioAdapter.RegisterSampleProvider(this);
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x000478A5 File Offset: 0x00045AA5
		public void Dispose()
		{
			this._audioAdapter.UnregisterSampleProvider(this);
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x000478B3 File Offset: 0x00045AB3
		public void Play()
		{
			this.Playing = true;
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x000478BC File Offset: 0x00045ABC
		public void Stop()
		{
			this.Playing = false;
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x000478C8 File Offset: 0x00045AC8
		public int Read(byte[] buffer, int offset, int count)
		{
			for (int i = 0; i < count; i += 4)
			{
				byte[] bytes = BitConverter.GetBytes((short)(this.GetNextSample() * 32767.0));
				Array.Copy(bytes, 0, buffer, offset + i, 2);
				Array.Copy(bytes, 0, buffer, offset + i + 2, 2);
			}
			return count;
		}

		// Token: 0x06001223 RID: 4643
		protected abstract double GetNextSample();

		// Token: 0x04000A0B RID: 2571
		private readonly AudioContext _audioAdapter;
	}
}
