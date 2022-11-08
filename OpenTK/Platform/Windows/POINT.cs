using System;
using System.Drawing;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000D1 RID: 209
	internal struct POINT
	{
		// Token: 0x06000846 RID: 2118 RVA: 0x0001ACF0 File Offset: 0x00018EF0
		internal POINT(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0001AD00 File Offset: 0x00018F00
		internal Point ToPoint()
		{
			return new Point(this.X, this.Y);
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0001AD14 File Offset: 0x00018F14
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Point {",
				this.X.ToString(),
				", ",
				this.Y.ToString(),
				")"
			});
		}

		// Token: 0x040006DD RID: 1757
		internal int X;

		// Token: 0x040006DE RID: 1758
		internal int Y;
	}
}
