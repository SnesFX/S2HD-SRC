using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000053 RID: 83
	public class PngChunkPLTE : PngChunkSingle
	{
		// Token: 0x060002D8 RID: 728 RVA: 0x0000B434 File Offset: 0x00009634
		public PngChunkPLTE(ImageInfo info) : base("PLTE", info)
		{
			this.nentries = 0;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000AB55 File Offset: 0x00008D55
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.NA;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000B44C File Offset: 0x0000964C
		public override ChunkRaw CreateRawChunk()
		{
			int len = 3 * this.nentries;
			int[] array = new int[3];
			ChunkRaw chunkRaw = base.createEmptyChunk(len, true);
			int i = 0;
			int num = 0;
			while (i < this.nentries)
			{
				this.GetEntryRgb(i, array);
				chunkRaw.Data[num++] = (byte)array[0];
				chunkRaw.Data[num++] = (byte)array[1];
				chunkRaw.Data[num++] = (byte)array[2];
				i++;
			}
			return chunkRaw;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000B4C8 File Offset: 0x000096C8
		public override void ParseFromRaw(ChunkRaw chunk)
		{
			this.SetNentries(chunk.Length / 3);
			int i = 0;
			int num = 0;
			while (i < this.nentries)
			{
				this.SetEntry(i, (int)(chunk.Data[num++] & byte.MaxValue), (int)(chunk.Data[num++] & byte.MaxValue), (int)(chunk.Data[num++] & byte.MaxValue));
				i++;
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000B534 File Offset: 0x00009734
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkPLTE pngChunkPLTE = (PngChunkPLTE)other;
			this.SetNentries(pngChunkPLTE.GetNentries());
			Array.Copy(pngChunkPLTE.entries, 0, this.entries, 0, this.nentries);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000B570 File Offset: 0x00009770
		public void SetNentries(int nentries)
		{
			this.nentries = nentries;
			if (nentries < 1 || nentries > 256)
			{
				throw new PngjException("invalid pallette - nentries=" + nentries);
			}
			if (this.entries == null || this.entries.Length != nentries)
			{
				this.entries = new int[nentries];
			}
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000B5C5 File Offset: 0x000097C5
		public int GetNentries()
		{
			return this.nentries;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000B5CD File Offset: 0x000097CD
		public void SetEntry(int n, int r, int g, int b)
		{
			this.entries[n] = (r << 16 | g << 8 | b);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000B5E2 File Offset: 0x000097E2
		public int GetEntry(int n)
		{
			return this.entries[n];
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000B5EC File Offset: 0x000097EC
		public void GetEntryRgb(int index, int[] rgb, int offset)
		{
			int num = this.entries[index];
			rgb[offset] = (num & 16711680) >> 16;
			rgb[offset + 1] = (num & 65280) >> 8;
			rgb[offset + 2] = (num & 255);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000B629 File Offset: 0x00009829
		public void GetEntryRgb(int n, int[] rgb)
		{
			this.GetEntryRgb(n, rgb, 0);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000B634 File Offset: 0x00009834
		public int MinBitDepth()
		{
			if (this.nentries <= 2)
			{
				return 1;
			}
			if (this.nentries <= 4)
			{
				return 2;
			}
			if (this.nentries <= 16)
			{
				return 4;
			}
			return 8;
		}

		// Token: 0x04000159 RID: 345
		public const string ID = "PLTE";

		// Token: 0x0400015A RID: 346
		private int nentries;

		// Token: 0x0400015B RID: 347
		private int[] entries;
	}
}
