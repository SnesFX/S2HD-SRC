using System;
using System.Collections.Generic;

namespace OpenTK.Graphics
{
	// Token: 0x02000005 RID: 5
	internal sealed class GraphicsModeComparer : IComparer<GraphicsMode>
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00002538 File Offset: 0x00000738
		public int Compare(GraphicsMode x, GraphicsMode y)
		{
			int num = x.ColorFormat.CompareTo(y.ColorFormat);
			if (num != 0)
			{
				return num;
			}
			num = x.Depth.CompareTo(y.Depth);
			if (num != 0)
			{
				return num;
			}
			num = x.Stencil.CompareTo(y.Stencil);
			if (num != 0)
			{
				return num;
			}
			num = x.Samples.CompareTo(y.Samples);
			if (num != 0)
			{
				return num;
			}
			num = x.Stereo.CompareTo(y.Stereo);
			if (num != 0)
			{
				return num;
			}
			num = x.Buffers.CompareTo(y.Buffers);
			if (num != 0)
			{
				return num;
			}
			return x.AccumulatorFormat.CompareTo(y.AccumulatorFormat);
		}
	}
}
