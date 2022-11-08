using System;
using System.Drawing;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200008F RID: 143
	internal struct MINMAXINFO
	{
		// Token: 0x04000383 RID: 899
		private Point Reserved;

		// Token: 0x04000384 RID: 900
		public Size MaxSize;

		// Token: 0x04000385 RID: 901
		public Point MaxPosition;

		// Token: 0x04000386 RID: 902
		public Size MinTrackSize;

		// Token: 0x04000387 RID: 903
		public Size MaxTrackSize;
	}
}
