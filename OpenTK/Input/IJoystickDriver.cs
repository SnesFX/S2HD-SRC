using System;
using System.Collections.Generic;

namespace OpenTK.Input
{
	// Token: 0x020000D9 RID: 217
	[Obsolete]
	public interface IJoystickDriver
	{
		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000937 RID: 2359
		IList<JoystickDevice> Joysticks { get; }
	}
}
