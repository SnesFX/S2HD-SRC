using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005D0 RID: 1488
	internal struct Keysym
	{
		// Token: 0x04005540 RID: 21824
		public Scancode Scancode;

		// Token: 0x04005541 RID: 21825
		public Keycode Sym;

		// Token: 0x04005542 RID: 21826
		public Keymod Mod;

		// Token: 0x04005543 RID: 21827
		[Obsolete]
		public uint Unicode;
	}
}
