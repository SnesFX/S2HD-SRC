using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200005E RID: 94
	public class PngChunkUNKNOWN : PngChunkMultiple
	{
		// Token: 0x06000336 RID: 822 RVA: 0x0000BE88 File Offset: 0x0000A088
		public PngChunkUNKNOWN(string id, ImageInfo info) : base(id, info)
		{
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000C4C5 File Offset: 0x0000A6C5
		private PngChunkUNKNOWN(PngChunkUNKNOWN c, ImageInfo info) : base(c.Id, info)
		{
			Array.Copy(c.data, 0, this.data, 0, c.data.Length);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000225B File Offset: 0x0000045B
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.NONE;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000C4EF File Offset: 0x0000A6EF
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(this.data.Length, false);
			chunkRaw.Data = this.data;
			return chunkRaw;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000C50C File Offset: 0x0000A70C
		public override void ParseFromRaw(ChunkRaw c)
		{
			this.data = c.Data;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000C51A File Offset: 0x0000A71A
		public byte[] GetData()
		{
			return this.data;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000C522 File Offset: 0x0000A722
		public void SetData(byte[] data_0)
		{
			this.data = data_0;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0000C52C File Offset: 0x0000A72C
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkUNKNOWN pngChunkUNKNOWN = (PngChunkUNKNOWN)other;
			this.data = pngChunkUNKNOWN.data;
		}

		// Token: 0x04000188 RID: 392
		private byte[] data;
	}
}
