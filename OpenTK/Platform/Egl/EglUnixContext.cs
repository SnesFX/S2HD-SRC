using System;
using System.Diagnostics;
using OpenTK.Graphics;
using OpenTK.Graphics.ES11;
using OpenTK.Graphics.ES20;
using OpenTK.Graphics.ES30;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Platform.X11;

namespace OpenTK.Platform.Egl
{
	// Token: 0x0200002B RID: 43
	internal class EglUnixContext : EglContext
	{
		// Token: 0x060004AC RID: 1196 RVA: 0x00013A94 File Offset: 0x00011C94
		public EglUnixContext(GraphicsMode mode, EglWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags) : base(mode, window, sharedContext, major, minor, flags)
		{
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00013AE4 File Offset: 0x00011CE4
		public EglUnixContext(ContextHandle handle, EglWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags) : base(handle, window, sharedContext, major, minor, flags)
		{
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00013B34 File Offset: 0x00011D34
		protected override IntPtr GetStaticAddress(IntPtr function, RenderableFlags renderable)
		{
			if ((renderable & RenderableFlags.ES) != (RenderableFlags)0 && this.ES1 != IntPtr.Zero)
			{
				return DL.Symbol(this.ES1, function);
			}
			if ((renderable & RenderableFlags.ES2) != (RenderableFlags)0 && this.ES2 != IntPtr.Zero)
			{
				return DL.Symbol(this.ES2, function);
			}
			if ((renderable & RenderableFlags.GL) != (RenderableFlags)0 && this.GL != IntPtr.Zero)
			{
				return DL.Symbol(this.GL, function);
			}
			return IntPtr.Zero;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x00013BB4 File Offset: 0x00011DB4
		protected override void Dispose(bool manual)
		{
			if (this.ES1 != IntPtr.Zero)
			{
				DL.Close(this.ES1);
			}
			if (this.ES2 != IntPtr.Zero)
			{
				DL.Close(this.ES2);
			}
			if (this.GL != IntPtr.Zero)
			{
				DL.Close(this.GL);
			}
			this.GL = (this.ES1 = (this.ES2 = IntPtr.Zero));
			base.Dispose(manual);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00013C40 File Offset: 0x00011E40
		public override void LoadAll()
		{
			Stopwatch.StartNew();
			new OpenTK.Graphics.OpenGL.GL().LoadEntryPoints();
			new OpenTK.Graphics.OpenGL4.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES11.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES20.GL().LoadEntryPoints();
			new OpenTK.Graphics.ES30.GL().LoadEntryPoints();
		}

		// Token: 0x040000B3 RID: 179
		private IntPtr ES1 = DL.Open("libGLESv1_CM", DLOpenFlags.Lazy);

		// Token: 0x040000B4 RID: 180
		private IntPtr ES2 = DL.Open("libGLESv2", DLOpenFlags.Lazy);

		// Token: 0x040000B5 RID: 181
		private IntPtr GL = DL.Open("libGL", DLOpenFlags.Lazy);
	}
}
