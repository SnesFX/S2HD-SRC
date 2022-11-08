using System;
using System.IO;

namespace SonicOrca.Audio
{
	// Token: 0x020001A3 RID: 419
	public class ResamplerStream : Stream
	{
		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x060011F6 RID: 4598 RVA: 0x000474F6 File Offset: 0x000456F6
		// (set) Token: 0x060011F7 RID: 4599 RVA: 0x000474FE File Offset: 0x000456FE
		public int InputSampleRate { get; set; }

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x060011F8 RID: 4600 RVA: 0x00047507 File Offset: 0x00045707
		// (set) Token: 0x060011F9 RID: 4601 RVA: 0x0004750F File Offset: 0x0004570F
		public int OutputSampleRate { get; set; }

		// Token: 0x060011FA RID: 4602 RVA: 0x00047518 File Offset: 0x00045718
		public ResamplerStream(Stream stream, int inputSampleRate, int outputSampleRate)
		{
			this._baseStream = stream;
			this.InputSampleRate = inputSampleRate;
			this.OutputSampleRate = outputSampleRate;
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x060011FB RID: 4603 RVA: 0x00047535 File Offset: 0x00045735
		public override bool CanRead
		{
			get
			{
				return this._baseStream.CanRead;
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x060011FC RID: 4604 RVA: 0x00047542 File Offset: 0x00045742
		public override bool CanSeek
		{
			get
			{
				return this._baseStream.CanSeek;
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x060011FD RID: 4605 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x060011FE RID: 4606 RVA: 0x0004754F File Offset: 0x0004574F
		public override long Length
		{
			get
			{
				return this._baseStream.Length;
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x060011FF RID: 4607 RVA: 0x0004755C File Offset: 0x0004575C
		// (set) Token: 0x06001200 RID: 4608 RVA: 0x00047569 File Offset: 0x00045769
		public override long Position
		{
			get
			{
				return this._baseStream.Position;
			}
			set
			{
				this._baseStream.Position = value;
			}
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x00047578 File Offset: 0x00045778
		public override int Read(byte[] buffer, int offset, int count)
		{
			double num = (double)this.InputSampleRate / (double)this.OutputSampleRate;
			int num2 = (int)((double)count * num);
			byte[] array = new byte[num2];
			this._baseStream.Read(array, 0, num2);
			float[] array2;
			float[] array3;
			Sample.PCMToSamples(array, out array2, out array3);
			array2 = ResamplerStream.LerpSamples(array2, count / 4);
			array3 = ResamplerStream.LerpSamples(array3, count / 4);
			array = Sample.SamplesToPCM(array2, array3);
			Array.Copy(array, 0, buffer, offset, array.Length);
			return array.Length;
		}

		// Token: 0x06001202 RID: 4610 RVA: 0x000475EC File Offset: 0x000457EC
		private static float[] LerpSamples(float[] source, int desiredLength)
		{
			float[] array = new float[desiredLength];
			for (int i = 0; i < desiredLength; i++)
			{
				float num = (float)i / (float)(desiredLength - 1) * (float)(source.Length - 1);
				int num2 = (int)Math.Floor((double)num);
				int num3 = (int)Math.Ceiling((double)num);
				float num4 = source[num2];
				float num5 = source[num3];
				array[i] = ((num5 - num4 == 0f) ? num4 : (num4 + (num5 - num4) * (num - (float)num2)));
			}
			return array;
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x0004765A File Offset: 0x0004585A
		public override long Seek(long offset, SeekOrigin origin)
		{
			return this._baseStream.Seek(offset, origin);
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x00047669 File Offset: 0x00045869
		public override void Flush()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x00047669 File Offset: 0x00045869
		public override void SetLength(long value)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x00047669 File Offset: 0x00045869
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x04000A03 RID: 2563
		private Stream _baseStream;
	}
}
