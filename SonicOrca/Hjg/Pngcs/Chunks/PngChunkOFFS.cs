using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000051 RID: 81
	public class PngChunkOFFS : PngChunkSingle
	{
		// Token: 0x060002BE RID: 702 RVA: 0x0000B049 File Offset: 0x00009249
		public PngChunkOFFS(ImageInfo info) : base("oFFs", info)
		{
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000B057 File Offset: 0x00009257
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.BEFORE_IDAT;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000B05C File Offset: 0x0000925C
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(9, true);
			PngHelperInternal.WriteInt4tobytes((int)this.posX, chunkRaw.Data, 0);
			PngHelperInternal.WriteInt4tobytes((int)this.posY, chunkRaw.Data, 4);
			chunkRaw.Data[8] = (byte)this.units;
			return chunkRaw;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000B0AC File Offset: 0x000092AC
		public override void ParseFromRaw(ChunkRaw chunk)
		{
			if (chunk.Length != 9)
			{
				throw new PngjException("bad chunk length " + chunk);
			}
			this.posX = (long)PngHelperInternal.ReadInt4fromBytes(chunk.Data, 0);
			if (this.posX < 0L)
			{
				this.posX += 4294967296L;
			}
			this.posY = (long)PngHelperInternal.ReadInt4fromBytes(chunk.Data, 4);
			if (this.posY < 0L)
			{
				this.posY += 4294967296L;
			}
			this.units = PngHelperInternal.ReadInt1fromByte(chunk.Data, 8);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000B14C File Offset: 0x0000934C
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkOFFS pngChunkOFFS = (PngChunkOFFS)other;
			this.posX = pngChunkOFFS.posX;
			this.posY = pngChunkOFFS.posY;
			this.units = pngChunkOFFS.units;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000B184 File Offset: 0x00009384
		public int GetUnits()
		{
			return this.units;
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000B18C File Offset: 0x0000938C
		public void SetUnits(int units)
		{
			this.units = units;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000B195 File Offset: 0x00009395
		public long GetPosX()
		{
			return this.posX;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000B19D File Offset: 0x0000939D
		public void SetPosX(long posX)
		{
			this.posX = posX;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000B1A6 File Offset: 0x000093A6
		public long GetPosY()
		{
			return this.posY;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000B1AE File Offset: 0x000093AE
		public void SetPosY(long posY)
		{
			this.posY = posY;
		}

		// Token: 0x04000151 RID: 337
		public const string ID = "oFFs";

		// Token: 0x04000152 RID: 338
		private long posX;

		// Token: 0x04000153 RID: 339
		private long posY;

		// Token: 0x04000154 RID: 340
		private int units;
	}
}
