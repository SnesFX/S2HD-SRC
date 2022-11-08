using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200011D RID: 285
	internal struct MotifWmHints
	{
		// Token: 0x06000A99 RID: 2713 RVA: 0x00020E30 File Offset: 0x0001F030
		public override string ToString()
		{
			return string.Format("MotifWmHints <flags={0}, functions={1}, decorations={2}, input_mode={3}, status={4}", new object[]
			{
				(MotifFlags)this.flags.ToInt32(),
				(MotifFunctions)this.functions.ToInt32(),
				(MotifDecorations)this.decorations.ToInt32(),
				(MotifInputMode)this.input_mode.ToInt32(),
				this.status.ToInt32()
			});
		}

		// Token: 0x040009FC RID: 2556
		internal IntPtr flags;

		// Token: 0x040009FD RID: 2557
		internal IntPtr functions;

		// Token: 0x040009FE RID: 2558
		internal IntPtr decorations;

		// Token: 0x040009FF RID: 2559
		internal IntPtr input_mode;

		// Token: 0x04000A00 RID: 2560
		internal IntPtr status;
	}
}
