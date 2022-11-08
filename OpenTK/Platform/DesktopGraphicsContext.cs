using System;
using System.Diagnostics;
using OpenTK.Graphics;
using OpenTK.Graphics.ES11;
using OpenTK.Graphics.ES20;
using OpenTK.Graphics.ES30;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics.OpenGL4;

namespace OpenTK.Platform
{
	// Token: 0x02000069 RID: 105
	internal abstract class DesktopGraphicsContext : GraphicsContextBase
	{
		// Token: 0x060006FD RID: 1789 RVA: 0x000180D8 File Offset: 0x000162D8
		public override void LoadAll()
		{
			Stopwatch.StartNew();
			new OpenTK.Graphics.OpenGL.GL().LoadEntryPoints();
			new OpenTK.Graphics.OpenGL4.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES11.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES20.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES30.GL().LoadEntryPoints();
		}
	}
}
