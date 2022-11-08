using System;
using System.Runtime.InteropServices;

namespace SonicOrca.Graphics.LowLevel
{
	// Token: 0x020000FB RID: 251
	[VertexAttributeType(VertexAttributePointerType.Float, 2)]
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct vec2
	{
		// Token: 0x0400053A RID: 1338
		[FieldOffset(0)]
		public float x;

		// Token: 0x0400053B RID: 1339
		[FieldOffset(4)]
		public float y;

		// Token: 0x0400053C RID: 1340
		[FieldOffset(0)]
		public float s;

		// Token: 0x0400053D RID: 1341
		[FieldOffset(4)]
		public float t;
	}
}
