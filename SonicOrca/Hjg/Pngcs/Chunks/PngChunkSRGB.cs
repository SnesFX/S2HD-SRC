using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000058 RID: 88
	public class PngChunkSRGB : PngChunkSingle
	{
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600030A RID: 778 RVA: 0x0000BC3A File Offset: 0x00009E3A
		// (set) Token: 0x0600030B RID: 779 RVA: 0x0000BC42 File Offset: 0x00009E42
		public int Intent { get; set; }

		// Token: 0x0600030C RID: 780 RVA: 0x0000BC4B File Offset: 0x00009E4B
		public PngChunkSRGB(ImageInfo info) : base("sRGB", info)
		{
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00006340 File Offset: 0x00004540
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.BEFORE_PLTE_AND_IDAT;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000BC59 File Offset: 0x00009E59
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(1, true);
			chunkRaw.Data[0] = (byte)this.Intent;
			return chunkRaw;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000BC72 File Offset: 0x00009E72
		public override void ParseFromRaw(ChunkRaw c)
		{
			if (c.Length != 1)
			{
				throw new PngjException("bad chunk length " + c);
			}
			this.Intent = PngHelperInternal.ReadInt1fromByte(c.Data, 0);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000BCA0 File Offset: 0x00009EA0
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkSRGB pngChunkSRGB = (PngChunkSRGB)other;
			this.Intent = pngChunkSRGB.Intent;
		}

		// Token: 0x04000166 RID: 358
		public const string ID = "sRGB";

		// Token: 0x04000167 RID: 359
		public const int RENDER_INTENT_Perceptual = 0;

		// Token: 0x04000168 RID: 360
		public const int RENDER_INTENT_Relative_colorimetric = 1;

		// Token: 0x04000169 RID: 361
		public const int RENDER_INTENT_Saturation = 2;

		// Token: 0x0400016A RID: 362
		public const int RENDER_INTENT_Absolute_colorimetric = 3;
	}
}
