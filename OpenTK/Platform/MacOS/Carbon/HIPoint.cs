using System;

namespace OpenTK.Platform.MacOS.Carbon
{
	// Token: 0x02000B2E RID: 2862
	internal struct HIPoint
	{
		// Token: 0x06005AA1 RID: 23201 RVA: 0x000F6504 File Offset: 0x000F4704
		public HIPoint(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06005AA2 RID: 23202 RVA: 0x000F6514 File Offset: 0x000F4714
		public HIPoint(double x, double y)
		{
			this = new HIPoint((float)x, (float)y);
		}

		// Token: 0x0400B5F8 RID: 46584
		public float X;

		// Token: 0x0400B5F9 RID: 46585
		public float Y;
	}
}
