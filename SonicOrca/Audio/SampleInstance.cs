using System;
using System.Collections.Generic;
using System.IO;
using SonicOrca.Extensions;

namespace SonicOrca.Audio
{
	// Token: 0x020001A8 RID: 424
	public class SampleInstance : IDisposable, ISampleProvider
	{
		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x00047A21 File Offset: 0x00045C21
		// (set) Token: 0x06001234 RID: 4660 RVA: 0x00047A29 File Offset: 0x00045C29
		public double Volume { get; set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x00047A32 File Offset: 0x00045C32
		// (set) Token: 0x06001236 RID: 4662 RVA: 0x00047A3A File Offset: 0x00045C3A
		public double Pan { get; set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x00047A43 File Offset: 0x00045C43
		// (set) Token: 0x06001238 RID: 4664 RVA: 0x00047A4B File Offset: 0x00045C4B
		public SampleInstanceClassification Classification { get; set; } = SampleInstanceClassification.Sound;

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06001239 RID: 4665 RVA: 0x00047A54 File Offset: 0x00045C54
		public Sample Sample
		{
			get
			{
				return this._sample;
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x0600123A RID: 4666 RVA: 0x00047A5C File Offset: 0x00045C5C
		// (set) Token: 0x0600123B RID: 4667 RVA: 0x00047A64 File Offset: 0x00045C64
		public bool Playing { get; private set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x0600123C RID: 4668 RVA: 0x00047A6D File Offset: 0x00045C6D
		// (set) Token: 0x0600123D RID: 4669 RVA: 0x00047A75 File Offset: 0x00045C75
		public int SampleIndex { get; private set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x0600123E RID: 4670 RVA: 0x00047A7E File Offset: 0x00045C7E
		public double Position
		{
			get
			{
				return (double)this.SampleIndex / (double)this._sample.SampleRate;
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x0600123F RID: 4671 RVA: 0x00047A94 File Offset: 0x00045C94
		public IReadOnlyList<byte> LastReadBytes
		{
			get
			{
				return this._lastReadBytes;
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06001240 RID: 4672 RVA: 0x00047A9C File Offset: 0x00045C9C
		// (set) Token: 0x06001241 RID: 4673 RVA: 0x00047AA4 File Offset: 0x00045CA4
		private int? LoopSampleIndex
		{
			get
			{
				return this._loopSampleIndex;
			}
			set
			{
				if (this._loopSampleIndex != value)
				{
					this._loopSampleIndex = value;
					this.CreateSampleInputStream();
				}
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06001242 RID: 4674 RVA: 0x00047AF0 File Offset: 0x00045CF0
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

		// Token: 0x06001243 RID: 4675 RVA: 0x00047B44 File Offset: 0x00045D44
		public SampleInstance(SonicOrcaGameContext context, SampleInfo sampleInfo) : this(context.Audio, sampleInfo.Sample, sampleInfo.HasLoopPoint ? new int?(sampleInfo.LoopSampleIndex) : null)
		{
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x00047B84 File Offset: 0x00045D84
		public SampleInstance(AudioContext audioAdapter, SampleInfo sampleInfo) : this(audioAdapter, sampleInfo.Sample, sampleInfo.HasLoopPoint ? new int?(sampleInfo.LoopSampleIndex) : null)
		{
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x00047BBC File Offset: 0x00045DBC
		public SampleInstance(SonicOrcaGameContext context, Sample sample, int? loopSampleIndex = null) : this(context.Audio, sample, loopSampleIndex)
		{
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x00047BCC File Offset: 0x00045DCC
		public SampleInstance(AudioContext audioAdapter, Sample sample, int? loopSampleIndex = null)
		{
			this._audioAdapter = audioAdapter;
			this._sample = sample;
			this._loopSampleIndex = loopSampleIndex;
			this.CreateSampleInputStream();
			this.Volume = 1.0;
			this._audioAdapter.RegisterSampleProvider(this);
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x00047C1C File Offset: 0x00045E1C
		private void CreateSampleInputStream()
		{
			this._sampleInputStream = new SampleStream(this._sample, this._loopSampleIndex);
			if (this._sample.SampleRate != 44100)
			{
				this._sampleInputStream = new ResamplerStream(this._sampleInputStream, this._sample.SampleRate, 44100);
			}
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x00047C73 File Offset: 0x00045E73
		public void Dispose()
		{
			this._audioAdapter.UnregisterSampleProvider(this);
			this._sampleInputStream.Dispose();
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x00047C8C File Offset: 0x00045E8C
		public void Play()
		{
			this.Playing = true;
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x00047C95 File Offset: 0x00045E95
		public void Stop()
		{
			this.Playing = false;
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x00047C9E File Offset: 0x00045E9E
		public void SeekToStart()
		{
			this.SeekTo(0);
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x00047CA7 File Offset: 0x00045EA7
		public void SeekToLoopPoint()
		{
			this.SeekTo(this._loopSampleIndex.GetValueOrDefault(0));
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x00047CBB File Offset: 0x00045EBB
		public void SeekTo(int sampleIndex)
		{
			this._sampleInputStream.Position = this._sample.GetPcmDataOffset(sampleIndex);
			this.SampleIndex = sampleIndex;
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x00047CDB File Offset: 0x00045EDB
		public void SeekTo(double time)
		{
			this.SeekTo((int)(time * (double)this._sample.SampleRate));
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x00047CF4 File Offset: 0x00045EF4
		public int Read(byte[] buffer, int offset, int count)
		{
			this.SampleIndex = this._sample.GetSampleIndex(this._sampleInputStream.Position);
			int num = this._sampleInputStream.Read(buffer, offset, count);
			if (num == 0)
			{
				this.Playing = false;
			}
			this._lastReadBytes = buffer.GetRange(0, num);
			return num;
		}

		// Token: 0x04000A15 RID: 2581
		private readonly AudioContext _audioAdapter;

		// Token: 0x04000A16 RID: 2582
		private readonly Sample _sample;

		// Token: 0x04000A17 RID: 2583
		private Stream _sampleInputStream;

		// Token: 0x04000A18 RID: 2584
		private byte[] _lastReadBytes;

		// Token: 0x04000A19 RID: 2585
		private int? _loopSampleIndex;
	}
}
