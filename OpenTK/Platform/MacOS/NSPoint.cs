using System;
using System.Drawing;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B62 RID: 2914
	internal struct NSPoint
	{
		// Token: 0x06005B59 RID: 23385 RVA: 0x000F7D3C File Offset: 0x000F5F3C
		public static implicit operator NSPoint(PointF p)
		{
			return new NSPoint
			{
				X = p.X,
				Y = p.Y
			};
		}

		// Token: 0x06005B5A RID: 23386 RVA: 0x000F7D7C File Offset: 0x000F5F7C
		public static implicit operator PointF(NSPoint s)
		{
			return new PointF(s.X, s.Y);
		}

		// Token: 0x0400B7DC RID: 47068
		public NSFloat X;

		// Token: 0x0400B7DD RID: 47069
		public NSFloat Y;
	}
}
