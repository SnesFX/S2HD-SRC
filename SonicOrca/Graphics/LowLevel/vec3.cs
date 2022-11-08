using System;
using System.Runtime.InteropServices;

namespace SonicOrca.Graphics.LowLevel
{
	// Token: 0x020000FC RID: 252
	[VertexAttributeType(VertexAttributePointerType.Float, 3)]
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct vec3
	{
		// Token: 0x0400053E RID: 1342
		[FieldOffset(0)]
		public float x;

		// Token: 0x0400053F RID: 1343
		[FieldOffset(4)]
		public float y;

		// Token: 0x04000540 RID: 1344
		[FieldOffset(8)]
		public float z;

		// Token: 0x04000541 RID: 1345
		[FieldOffset(0)]
		public float s;

		// Token: 0x04000542 RID: 1346
		[FieldOffset(4)]
		public float t;

		// Token: 0x04000543 RID: 1347
		[FieldOffset(8)]
		public float p;
	}
}
