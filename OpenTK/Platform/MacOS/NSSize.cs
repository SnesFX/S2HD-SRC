using System;
using System.Drawing;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B63 RID: 2915
	internal struct NSSize
	{
		// Token: 0x06005B5B RID: 23387 RVA: 0x000F7DA0 File Offset: 0x000F5FA0
		public static implicit operator NSSize(SizeF s)
		{
			return new NSSize
			{
				Width = s.Width,
				Height = s.Height
			};
		}

		// Token: 0x06005B5C RID: 23388 RVA: 0x000F7DE0 File Offset: 0x000F5FE0
		public static implicit operator SizeF(NSSize s)
		{
			return new SizeF(s.Width, s.Height);
		}

		// Token: 0x0400B7DE RID: 47070
		public NSFloat Width;

		// Token: 0x0400B7DF RID: 47071
		public NSFloat Height;
	}
}
