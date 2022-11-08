using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000054 RID: 84
	public class PngChunkSBIT : PngChunkSingle
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x0000B659 File Offset: 0x00009859
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x0000B661 File Offset: 0x00009861
		public int Graysb { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x0000B66A File Offset: 0x0000986A
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x0000B672 File Offset: 0x00009872
		public int Alphasb { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x0000B67B File Offset: 0x0000987B
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x0000B683 File Offset: 0x00009883
		public int Redsb { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060002EA RID: 746 RVA: 0x0000B68C File Offset: 0x0000988C
		// (set) Token: 0x060002EB RID: 747 RVA: 0x0000B694 File Offset: 0x00009894
		public int Greensb { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060002EC RID: 748 RVA: 0x0000B69D File Offset: 0x0000989D
		// (set) Token: 0x060002ED RID: 749 RVA: 0x0000B6A5 File Offset: 0x000098A5
		public int Bluesb { get; set; }

		// Token: 0x060002EE RID: 750 RVA: 0x0000B6AE File Offset: 0x000098AE
		public PngChunkSBIT(ImageInfo info) : base("sBIT", info)
		{
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00006340 File Offset: 0x00004540
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.BEFORE_PLTE_AND_IDAT;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000B6BC File Offset: 0x000098BC
		public override void ParseFromRaw(ChunkRaw c)
		{
			if (c.Length != this.GetLen())
			{
				throw new PngjException("bad chunk length " + c);
			}
			if (this.ImgInfo.Greyscale)
			{
				this.Graysb = PngHelperInternal.ReadInt1fromByte(c.Data, 0);
				if (this.ImgInfo.Alpha)
				{
					this.Alphasb = PngHelperInternal.ReadInt1fromByte(c.Data, 1);
					return;
				}
			}
			else
			{
				this.Redsb = PngHelperInternal.ReadInt1fromByte(c.Data, 0);
				this.Greensb = PngHelperInternal.ReadInt1fromByte(c.Data, 1);
				this.Bluesb = PngHelperInternal.ReadInt1fromByte(c.Data, 2);
				if (this.ImgInfo.Alpha)
				{
					this.Alphasb = PngHelperInternal.ReadInt1fromByte(c.Data, 3);
				}
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000B77C File Offset: 0x0000997C
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(this.GetLen(), true);
			if (this.ImgInfo.Greyscale)
			{
				chunkRaw.Data[0] = (byte)this.Graysb;
				if (this.ImgInfo.Alpha)
				{
					chunkRaw.Data[1] = (byte)this.Alphasb;
				}
			}
			else
			{
				chunkRaw.Data[0] = (byte)this.Redsb;
				chunkRaw.Data[1] = (byte)this.Greensb;
				chunkRaw.Data[2] = (byte)this.Bluesb;
				if (this.ImgInfo.Alpha)
				{
					chunkRaw.Data[3] = (byte)this.Alphasb;
				}
			}
			return chunkRaw;
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000B820 File Offset: 0x00009A20
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkSBIT pngChunkSBIT = (PngChunkSBIT)other;
			this.Graysb = pngChunkSBIT.Graysb;
			this.Redsb = pngChunkSBIT.Redsb;
			this.Greensb = pngChunkSBIT.Greensb;
			this.Bluesb = pngChunkSBIT.Bluesb;
			this.Alphasb = pngChunkSBIT.Alphasb;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000B870 File Offset: 0x00009A70
		private int GetLen()
		{
			int num = this.ImgInfo.Greyscale ? 1 : 3;
			if (this.ImgInfo.Alpha)
			{
				num++;
			}
			return num;
		}

		// Token: 0x0400015C RID: 348
		public const string ID = "sBIT";
	}
}
