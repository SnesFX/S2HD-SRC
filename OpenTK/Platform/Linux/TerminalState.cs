using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000BA2 RID: 2978
	internal struct TerminalState
	{
		// Token: 0x0400B94B RID: 47435
		public InputFlags InputMode;

		// Token: 0x0400B94C RID: 47436
		public OutputFlags OutputMode;

		// Token: 0x0400B94D RID: 47437
		public ControlFlags ControlMode;

		// Token: 0x0400B94E RID: 47438
		public LocalFlags LocalMode;

		// Token: 0x0400B94F RID: 47439
		public byte LineDiscipline;

		// Token: 0x0400B950 RID: 47440
		public ControlCharacters ControlCharacters;

		// Token: 0x0400B951 RID: 47441
		public int InputSpeed;

		// Token: 0x0400B952 RID: 47442
		public int OutputSpeed;
	}
}
