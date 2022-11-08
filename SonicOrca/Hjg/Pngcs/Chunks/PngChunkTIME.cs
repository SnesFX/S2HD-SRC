using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200005C RID: 92
	public class PngChunkTIME : PngChunkSingle
	{
		// Token: 0x06000321 RID: 801 RVA: 0x0000BEB2 File Offset: 0x0000A0B2
		public PngChunkTIME(ImageInfo info) : base("tIME", info)
		{
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000225B File Offset: 0x0000045B
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.NONE;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000BEC0 File Offset: 0x0000A0C0
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(7, true);
			PngHelperInternal.WriteInt2tobytes(this.year, chunkRaw.Data, 0);
			chunkRaw.Data[2] = (byte)this.mon;
			chunkRaw.Data[3] = (byte)this.day;
			chunkRaw.Data[4] = (byte)this.hour;
			chunkRaw.Data[5] = (byte)this.min;
			chunkRaw.Data[6] = (byte)this.sec;
			return chunkRaw;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000BF34 File Offset: 0x0000A134
		public override void ParseFromRaw(ChunkRaw chunk)
		{
			if (chunk.Length != 7)
			{
				throw new PngjException("bad chunk " + chunk);
			}
			this.year = PngHelperInternal.ReadInt2fromBytes(chunk.Data, 0);
			this.mon = PngHelperInternal.ReadInt1fromByte(chunk.Data, 2);
			this.day = PngHelperInternal.ReadInt1fromByte(chunk.Data, 3);
			this.hour = PngHelperInternal.ReadInt1fromByte(chunk.Data, 4);
			this.min = PngHelperInternal.ReadInt1fromByte(chunk.Data, 5);
			this.sec = PngHelperInternal.ReadInt1fromByte(chunk.Data, 6);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000BFC8 File Offset: 0x0000A1C8
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkTIME pngChunkTIME = (PngChunkTIME)other;
			this.year = pngChunkTIME.year;
			this.mon = pngChunkTIME.mon;
			this.day = pngChunkTIME.day;
			this.hour = pngChunkTIME.hour;
			this.min = pngChunkTIME.min;
			this.sec = pngChunkTIME.sec;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000C024 File Offset: 0x0000A224
		public void SetNow(int secsAgo)
		{
			DateTime now = DateTime.Now;
			this.year = now.Year;
			this.mon = now.Month;
			this.day = now.Day;
			this.hour = now.Hour;
			this.min = now.Minute;
			this.sec = now.Second;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000C085 File Offset: 0x0000A285
		internal void SetYMDHMS(int yearx, int monx, int dayx, int hourx, int minx, int secx)
		{
			this.year = yearx;
			this.mon = monx;
			this.day = dayx;
			this.hour = hourx;
			this.min = minx;
			this.sec = secx;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0000C0B4 File Offset: 0x0000A2B4
		public int[] GetYMDHMS()
		{
			return new int[]
			{
				this.year,
				this.mon,
				this.day,
				this.hour,
				this.min,
				this.sec
			};
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000C0F4 File Offset: 0x0000A2F4
		public string GetAsString()
		{
			return string.Format("%04d/%02d/%02d %02d:%02d:%02d", new object[]
			{
				this.year,
				this.mon,
				this.day,
				this.hour,
				this.min,
				this.sec
			});
		}

		// Token: 0x0400017B RID: 379
		public const string ID = "tIME";

		// Token: 0x0400017C RID: 380
		private int year;

		// Token: 0x0400017D RID: 381
		private int mon;

		// Token: 0x0400017E RID: 382
		private int day;

		// Token: 0x0400017F RID: 383
		private int hour;

		// Token: 0x04000180 RID: 384
		private int min;

		// Token: 0x04000181 RID: 385
		private int sec;
	}
}
