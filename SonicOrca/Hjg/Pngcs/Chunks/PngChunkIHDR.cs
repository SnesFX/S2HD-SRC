using System;
using System.IO;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200004E RID: 78
	public class PngChunkIHDR : PngChunkSingle
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600029F RID: 671 RVA: 0x0000AB77 File Offset: 0x00008D77
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x0000AB7F File Offset: 0x00008D7F
		public int Cols { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000AB88 File Offset: 0x00008D88
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x0000AB90 File Offset: 0x00008D90
		public int Rows { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x0000AB99 File Offset: 0x00008D99
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x0000ABA1 File Offset: 0x00008DA1
		public int Bitspc { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x0000ABAA File Offset: 0x00008DAA
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x0000ABB2 File Offset: 0x00008DB2
		public int Colormodel { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0000ABBB File Offset: 0x00008DBB
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x0000ABC3 File Offset: 0x00008DC3
		public int Compmeth { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x0000ABCC File Offset: 0x00008DCC
		// (set) Token: 0x060002AA RID: 682 RVA: 0x0000ABD4 File Offset: 0x00008DD4
		public int Filmeth { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000ABDD File Offset: 0x00008DDD
		// (set) Token: 0x060002AC RID: 684 RVA: 0x0000ABE5 File Offset: 0x00008DE5
		public int Interlaced { get; set; }

		// Token: 0x060002AD RID: 685 RVA: 0x0000ABEE File Offset: 0x00008DEE
		public PngChunkIHDR(ImageInfo info) : base("IHDR", info)
		{
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000AB55 File Offset: 0x00008D55
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.NA;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000ABFC File Offset: 0x00008DFC
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = new ChunkRaw(13, ChunkHelper.b_IHDR, true);
			int num = 0;
			PngHelperInternal.WriteInt4tobytes(this.Cols, chunkRaw.Data, num);
			num += 4;
			PngHelperInternal.WriteInt4tobytes(this.Rows, chunkRaw.Data, num);
			num += 4;
			chunkRaw.Data[num++] = (byte)this.Bitspc;
			chunkRaw.Data[num++] = (byte)this.Colormodel;
			chunkRaw.Data[num++] = (byte)this.Compmeth;
			chunkRaw.Data[num++] = (byte)this.Filmeth;
			chunkRaw.Data[num++] = (byte)this.Interlaced;
			return chunkRaw;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000ACA8 File Offset: 0x00008EA8
		public override void ParseFromRaw(ChunkRaw c)
		{
			if (c.Length != 13)
			{
				throw new PngjException("Bad IDHR len " + c.Length);
			}
			MemoryStream asByteStream = c.GetAsByteStream();
			this.Cols = PngHelperInternal.ReadInt4(asByteStream);
			this.Rows = PngHelperInternal.ReadInt4(asByteStream);
			this.Bitspc = PngHelperInternal.ReadByte(asByteStream);
			this.Colormodel = PngHelperInternal.ReadByte(asByteStream);
			this.Compmeth = PngHelperInternal.ReadByte(asByteStream);
			this.Filmeth = PngHelperInternal.ReadByte(asByteStream);
			this.Interlaced = PngHelperInternal.ReadByte(asByteStream);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000AD38 File Offset: 0x00008F38
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkIHDR pngChunkIHDR = (PngChunkIHDR)other;
			this.Cols = pngChunkIHDR.Cols;
			this.Rows = pngChunkIHDR.Rows;
			this.Bitspc = pngChunkIHDR.Bitspc;
			this.Colormodel = pngChunkIHDR.Colormodel;
			this.Compmeth = pngChunkIHDR.Compmeth;
			this.Filmeth = pngChunkIHDR.Filmeth;
			this.Interlaced = pngChunkIHDR.Interlaced;
		}

		// Token: 0x04000145 RID: 325
		public const string ID = "IHDR";
	}
}
