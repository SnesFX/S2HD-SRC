using System;
using System.Diagnostics;
using OpenTK.Graphics;
using OpenTK.Graphics.ES11;
using OpenTK.Graphics.ES20;
using OpenTK.Graphics.ES30;

namespace OpenTK.Platform
{
	// Token: 0x02000029 RID: 41
	internal abstract class EmbeddedGraphicsContext : GraphicsContextBase
	{
		// Token: 0x0600049C RID: 1180 RVA: 0x00013728 File Offset: 0x00011928
		public override void LoadAll()
		{
			Stopwatch.StartNew();
			new OpenTK.Graphics.ES11.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES20.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES30.GL().LoadEntryPoints();
		}
	}
}
