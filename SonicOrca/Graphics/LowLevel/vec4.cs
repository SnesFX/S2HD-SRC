using System;
using System.Runtime.InteropServices;

namespace SonicOrca.Graphics.LowLevel
{
	// Token: 0x020000FD RID: 253
	[VertexAttributeType(VertexAttributePointerType.Float, 4)]
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct vec4
	{
		// Token: 0x04000544 RID: 1348
		[FieldOffset(0)]
		public float x;

		// Token: 0x04000545 RID: 1349
		[FieldOffset(4)]
		public float y;

		// Token: 0x04000546 RID: 1350
		[FieldOffset(8)]
		public float z;

		// Token: 0x04000547 RID: 1351
		[FieldOffset(12)]
		public float w;

		// Token: 0x04000548 RID: 1352
		[FieldOffset(0)]
		public float s;

		// Token: 0x04000549 RID: 1353
		[FieldOffset(4)]
		public float t;

		// Token: 0x0400054A RID: 1354
		[FieldOffset(8)]
		public float p;

		// Token: 0x0400054B RID: 1355
		[FieldOffset(12)]
		public float q;

		// Token: 0x0400054C RID: 1356
		[FieldOffset(0)]
		public float r;

		// Token: 0x0400054D RID: 1357
		[FieldOffset(4)]
		public float g;

		// Token: 0x0400054E RID: 1358
		[FieldOffset(8)]
		public float b;

		// Token: 0x0400054F RID: 1359
		[FieldOffset(12)]
		public float a;
	}
}
