using System;

namespace OpenTK.Input
{
	// Token: 0x0200000D RID: 13
	internal interface IMouseDriver2
	{
		// Token: 0x06000040 RID: 64
		MouseState GetState();

		// Token: 0x06000041 RID: 65
		MouseState GetState(int index);

		// Token: 0x06000042 RID: 66
		void SetPosition(double x, double y);

		// Token: 0x06000043 RID: 67
		MouseState GetCursorState();
	}
}
