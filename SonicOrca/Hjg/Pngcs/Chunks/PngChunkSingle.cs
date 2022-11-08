using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000055 RID: 85
	public abstract class PngChunkSingle : PngChunk
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x0000B03F File Offset: 0x0000923F
		public PngChunkSingle(string id, ImageInfo imgInfo) : base(id, imgInfo)
		{
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000225B File Offset: 0x0000045B
		public sealed override bool AllowsMultiple()
		{
			return false;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000B8A4 File Offset: 0x00009AA4
		public override int GetHashCode()
		{
			int num = 31;
			int num2 = 1;
			return num * num2 + ((this.Id == null) ? 0 : this.Id.GetHashCode());
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000B8D0 File Offset: 0x00009AD0
		public override bool Equals(object obj)
		{
			return obj is PngChunkSingle && this.Id != null && this.Id.Equals(((PngChunkSingle)obj).Id);
		}
	}
}
