using System;
using OpenTK.Graphics;
using OpenTK.Platform.Windows;

namespace OpenTK.Platform.Egl
{
	// Token: 0x0200002C RID: 44
	internal class EglWinContext : EglContext
	{
		// Token: 0x060004B1 RID: 1201 RVA: 0x00013C7C File Offset: 0x00011E7C
		public EglWinContext(GraphicsMode mode, EglWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags) : base(mode, window, sharedContext, major, minor, flags)
		{
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00013CB0 File Offset: 0x00011EB0
		public EglWinContext(ContextHandle handle, EglWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags) : base(handle, window, sharedContext, major, minor, flags)
		{
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00013CE4 File Offset: 0x00011EE4
		protected override IntPtr GetStaticAddress(IntPtr function, RenderableFlags renderable)
		{
			if ((renderable & RenderableFlags.ES) != (RenderableFlags)0 && this.ES1 != IntPtr.Zero)
			{
				return Functions.GetProcAddress(this.ES1, function);
			}
			if ((renderable & RenderableFlags.ES2) != (RenderableFlags)0 && this.ES2 != IntPtr.Zero)
			{
				return Functions.GetProcAddress(this.ES2, function);
			}
			return IntPtr.Zero;
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00013D40 File Offset: 0x00011F40
		protected override void Dispose(bool manual)
		{
			if (this.ES1 != IntPtr.Zero)
			{
				Functions.FreeLibrary(this.ES1);
			}
			if (this.ES2 != IntPtr.Zero)
			{
				Functions.FreeLibrary(this.ES2);
			}
			base.Dispose(manual);
		}

		// Token: 0x040000B6 RID: 182
		private readonly IntPtr ES1 = Functions.LoadLibrary("libGLESv1_CM");

		// Token: 0x040000B7 RID: 183
		private readonly IntPtr ES2 = Functions.LoadLibrary("libGLESv2");
	}
}
