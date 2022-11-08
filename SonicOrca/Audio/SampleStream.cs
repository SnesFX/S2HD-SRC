using System;
using System.IO;

namespace SonicOrca.Audio
{
	// Token: 0x020001AA RID: 426
	internal class SampleStream : Stream
	{
		// Token: 0x06001250 RID: 4688 RVA: 0x00047D48 File Offset: 0x00045F48
		public SampleStream(Sample sample, int? loopSampleIndex = null)
		{
			this._sample = sample;
			this._pcmData = sample.PcmData;
			this._length = (long)this._sample.PcmData.Length;
			if (loopSampleIndex != null)
			{
				this._loopPoint = new long?(sample.GetPcmDataOffset(loopSampleIndex.Value));
				this._lengthFromLoopPoint = this._length - this._loopPoint.Value;
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06001251 RID: 4689 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override bool CanRead
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06001252 RID: 4690 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06001253 RID: 4691 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06001254 RID: 4692 RVA: 0x00047DBA File Offset: 0x00045FBA
		public override long Length
		{
			get
			{
				return this._length;
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06001255 RID: 4693 RVA: 0x00047DC2 File Offset: 0x00045FC2
		// (set) Token: 0x06001256 RID: 4694 RVA: 0x00047DCA File Offset: 0x00045FCA
		public override long Position { get; set; }

		// Token: 0x06001257 RID: 4695 RVA: 0x00047DD4 File Offset: 0x00045FD4
		public override long Seek(long offset, SeekOrigin origin)
		{
			if (origin == SeekOrigin.End)
			{
				throw new NotImplementedException();
			}
			if (origin == SeekOrigin.Current)
			{
				offset += this.Position;
			}
			long num = offset - (long)this._sample.PcmData.Length;
			if (num > 0L)
			{
				this.Position = ((this._loopPoint != null) ? (this._loopPoint.Value + num % this._lengthFromLoopPoint) : this._length);
			}
			else
			{
				this.Position = offset;
			}
			return this.Position;
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x00047E54 File Offset: 0x00046054
		public override int Read(byte[] buffer, int offset, int count)
		{
			long num = this._length - this.Position;
			if ((long)count > num && this._loopPoint != null)
			{
				return this.ReadWrapped(buffer, offset, count);
			}
			return this.ReadChunk(buffer, offset, (int)Math.Min((long)count, num));
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x00047EA0 File Offset: 0x000460A0
		private int ReadWrapped(byte[] buffer, int offset, int count)
		{
			int i = 0;
			while (i < count)
			{
				long num = this._length - this.Position;
				long num2 = (long)(count - i);
				int num3 = (int)Math.Min(num, num2);
				this.ReadChunk(buffer, offset, num3);
				offset += num3;
				i += num3;
				if (num < num2)
				{
					this.Position = ((this._loopPoint != null) ? this._loopPoint.Value : this._length);
				}
			}
			return i;
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x00047F13 File Offset: 0x00046113
		private int ReadChunk(byte[] buffer, int offset, int count)
		{
			Array.Copy(this._pcmData, this.Position, buffer, (long)offset, (long)count);
			this.Position += (long)count;
			return count;
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x00047669 File Offset: 0x00045869
		public override void Flush()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x00047669 File Offset: 0x00045869
		public override void SetLength(long value)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x00047669 File Offset: 0x00045869
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x04000A23 RID: 2595
		private readonly Sample _sample;

		// Token: 0x04000A24 RID: 2596
		private readonly byte[] _pcmData;

		// Token: 0x04000A25 RID: 2597
		private readonly long? _loopPoint;

		// Token: 0x04000A26 RID: 2598
		private readonly long _length;

		// Token: 0x04000A27 RID: 2599
		private readonly long _lengthFromLoopPoint;
	}
}
