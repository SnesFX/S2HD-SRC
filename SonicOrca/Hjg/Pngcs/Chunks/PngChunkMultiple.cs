using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000050 RID: 80
	public abstract class PngChunkMultiple : PngChunk
	{
		// Token: 0x060002BC RID: 700 RVA: 0x0000B03F File Offset: 0x0000923F
		internal PngChunkMultiple(string id, ImageInfo imgInfo) : base(id, imgInfo)
		{
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00006340 File Offset: 0x00004540
		public sealed override bool AllowsMultiple()
		{
			return true;
		}
	}
}
