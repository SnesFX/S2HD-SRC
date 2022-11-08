using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005B8 RID: 1464
	[Flags]
	internal enum HatPosition : byte
	{
		// Token: 0x040052B4 RID: 21172
		Centered = 0,
		// Token: 0x040052B5 RID: 21173
		Up = 1,
		// Token: 0x040052B6 RID: 21174
		Right = 2,
		// Token: 0x040052B7 RID: 21175
		Down = 3,
		// Token: 0x040052B8 RID: 21176
		Left = 4,
		// Token: 0x040052B9 RID: 21177
		RightUp = 3,
		// Token: 0x040052BA RID: 21178
		RightDown = 3,
		// Token: 0x040052BB RID: 21179
		LeftUp = 5,
		// Token: 0x040052BC RID: 21180
		LeftDown = 7
	}
}
