using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x0200014E RID: 334
	public class CameraProperties
	{
		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x00035A9C File Offset: 0x00033C9C
		// (set) Token: 0x06000DF1 RID: 3569 RVA: 0x00035AA4 File Offset: 0x00033CA4
		public Rectangle Box { get; set; }

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000DF2 RID: 3570 RVA: 0x00035AAD File Offset: 0x00033CAD
		// (set) Token: 0x06000DF3 RID: 3571 RVA: 0x00035AB5 File Offset: 0x00033CB5
		public Vector2i Delay { get; set; }

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x00035ABE File Offset: 0x00033CBE
		// (set) Token: 0x06000DF5 RID: 3573 RVA: 0x00035AC6 File Offset: 0x00033CC6
		public Vector2 MaxVelocity { get; set; }

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000DF6 RID: 3574 RVA: 0x00035ACF File Offset: 0x00033CCF
		// (set) Token: 0x06000DF7 RID: 3575 RVA: 0x00035AD7 File Offset: 0x00033CD7
		public Vector2 Offset { get; set; }
	}
}
