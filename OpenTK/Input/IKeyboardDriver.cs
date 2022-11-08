using System;
using System.Collections.Generic;

namespace OpenTK.Input
{
	// Token: 0x02000517 RID: 1303
	[Obsolete]
	public interface IKeyboardDriver
	{
		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06003D4F RID: 15695
		IList<KeyboardDevice> Keyboard { get; }
	}
}
