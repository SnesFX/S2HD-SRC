using System;
using OpenTK.Input;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B7B RID: 2939
	internal struct LinuxJoyDetails
	{
		// Token: 0x0400B890 RID: 47248
		public Guid Guid;

		// Token: 0x0400B891 RID: 47249
		public int FileDescriptor;

		// Token: 0x0400B892 RID: 47250
		public JoystickState State;
	}
}
