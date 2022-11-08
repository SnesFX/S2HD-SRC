using System;

namespace OpenTK.Input
{
	// Token: 0x02000518 RID: 1304
	public interface IInputDriver : IKeyboardDriver, IMouseDriver, IJoystickDriver, IDisposable
	{
		// Token: 0x06003D50 RID: 15696
		void Poll();
	}
}
