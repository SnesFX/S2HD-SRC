using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B8A RID: 2954
	internal struct PollFD
	{
		// Token: 0x0400B8DA RID: 47322
		public int fd;

		// Token: 0x0400B8DB RID: 47323
		public PollFlags events;

		// Token: 0x0400B8DC RID: 47324
		public PollFlags revents;
	}
}
