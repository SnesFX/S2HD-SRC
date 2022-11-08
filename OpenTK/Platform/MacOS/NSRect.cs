using System;
using System.Drawing;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B64 RID: 2916
	internal struct NSRect
	{
		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06005B5D RID: 23389 RVA: 0x000F7E04 File Offset: 0x000F6004
		public NSFloat Width
		{
			get
			{
				return this.Size.Width;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06005B5E RID: 23390 RVA: 0x000F7E14 File Offset: 0x000F6014
		public NSFloat Height
		{
			get
			{
				return this.Size.Height;
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06005B5F RID: 23391 RVA: 0x000F7E24 File Offset: 0x000F6024
		public NSFloat X
		{
			get
			{
				return this.Location.X;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06005B60 RID: 23392 RVA: 0x000F7E34 File Offset: 0x000F6034
		public NSFloat Y
		{
			get
			{
				return this.Location.Y;
			}
		}

		// Token: 0x06005B61 RID: 23393 RVA: 0x000F7E44 File Offset: 0x000F6044
		public static implicit operator NSRect(RectangleF s)
		{
			return new NSRect
			{
				Location = s.Location,
				Size = s.Size
			};
		}

		// Token: 0x06005B62 RID: 23394 RVA: 0x000F7E80 File Offset: 0x000F6080
		public static implicit operator RectangleF(NSRect s)
		{
			return new RectangleF(s.Location, s.Size);
		}

		// Token: 0x0400B7E0 RID: 47072
		public NSPoint Location;

		// Token: 0x0400B7E1 RID: 47073
		public NSSize Size;
	}
}
