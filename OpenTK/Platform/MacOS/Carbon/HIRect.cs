using System;

namespace OpenTK.Platform.MacOS.Carbon
{
	// Token: 0x02000B30 RID: 2864
	internal struct HIRect
	{
		// Token: 0x06005AA3 RID: 23203 RVA: 0x000F6520 File Offset: 0x000F4720
		public override string ToString()
		{
			return string.Format("Rect: [{0}, {1}, {2}, {3}]", new object[]
			{
				this.Origin.X,
				this.Origin.Y,
				this.Size.Width,
				this.Size.Height
			});
		}

		// Token: 0x0400B5FC RID: 46588
		public HIPoint Origin;

		// Token: 0x0400B5FD RID: 46589
		public HISize Size;
	}
}
