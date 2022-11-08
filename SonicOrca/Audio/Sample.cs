using System;
using SonicOrca.Resources;

namespace SonicOrca.Audio
{
	// Token: 0x020001A4 RID: 420
	public class Sample : ILoadedResource, IDisposable
	{
		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06001207 RID: 4615 RVA: 0x00047670 File Offset: 0x00045870
		// (set) Token: 0x06001208 RID: 4616 RVA: 0x00047678 File Offset: 0x00045878
		public Resource Resource { get; set; }

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06001209 RID: 4617 RVA: 0x00047681 File Offset: 0x00045881
		public byte[] PcmData
		{
			get
			{
				return this._pcmData;
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x0600120A RID: 4618 RVA: 0x00047689 File Offset: 0x00045889
		public int BitsPerSample
		{
			get
			{
				return this._bitsPerSample;
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x0600120B RID: 4619 RVA: 0x00047691 File Offset: 0x00045891
		public int SampleRate
		{
			get
			{
				return this._sampleRate;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x0600120C RID: 4620 RVA: 0x00047699 File Offset: 0x00045899
		public int Channels
		{
			get
			{
				return this._channels;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x0600120D RID: 4621 RVA: 0x000476A1 File Offset: 0x000458A1
		public int SampleCount
		{
			get
			{
				return this._pcmData.Length / (this._bitsPerSample / 8 * this._channels);
			}
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x000476BB File Offset: 0x000458BB
		public Sample(byte[] pcmData, int bitsPerSample, int sampleRate, int channels)
		{
			this._pcmData = pcmData;
			this._bitsPerSample = bitsPerSample;
			this._sampleRate = sampleRate;
			this._channels = channels;
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x00006325 File Offset: 0x00004525
		public void OnLoaded()
		{
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x000476E0 File Offset: 0x000458E0
		public long GetPcmDataOffset(int sampleIndex)
		{
			return (long)(this._bitsPerSample / 8 * this._channels) * (long)sampleIndex;
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x000476F5 File Offset: 0x000458F5
		public int GetSampleIndex(long pcmDataOffset)
		{
			return (int)(pcmDataOffset / (long)(this._bitsPerSample / 8 * this._channels));
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x0004770C File Offset: 0x0004590C
		public static int PCMToSamples(byte[] source, out float[] leftSamples, out float[] rightSamples)
		{
			leftSamples = new float[source.Length / 4];
			rightSamples = new float[source.Length / 4];
			int num = 0;
			for (int i = 0; i < source.Length; i += 4)
			{
				leftSamples[num] = (float)BitConverter.ToInt16(source, i) / 32767f;
				rightSamples[num] = (float)BitConverter.ToInt16(source, i + 2) / 32767f;
				num++;
			}
			return num;
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x0004776C File Offset: 0x0004596C
		public static byte[] SamplesToPCM(float[] leftSamples, float[] rightSamples)
		{
			byte[] array = new byte[leftSamples.Length * 4];
			int num = 0;
			for (int i = 0; i < leftSamples.Length; i++)
			{
				short num2 = (short)(leftSamples[i] * 32767f);
				short num3 = (short)(rightSamples[i] * 32767f);
				array[num++] = (byte)(num2 & 255);
				array[num++] = (byte)(num2 >> 8);
				array[num++] = (byte)(num3 & 255);
				array[num++] = (byte)(num3 >> 8);
			}
			return array;
		}

		// Token: 0x04000A06 RID: 2566
		private readonly byte[] _pcmData;

		// Token: 0x04000A07 RID: 2567
		private readonly int _bitsPerSample;

		// Token: 0x04000A08 RID: 2568
		private readonly int _sampleRate;

		// Token: 0x04000A09 RID: 2569
		private readonly int _channels;
	}
}
