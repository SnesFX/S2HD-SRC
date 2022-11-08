using System;
using OpenTK.Graphics;

namespace OpenTK.Platform.Egl
{
	// Token: 0x0200002A RID: 42
	internal abstract class EglContext : EmbeddedGraphicsContext
	{
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x00013758 File Offset: 0x00011958
		// (set) Token: 0x0600049F RID: 1183 RVA: 0x00013768 File Offset: 0x00011968
		private IntPtr HandleAsEGLContext
		{
			get
			{
				return this.Handle.Handle;
			}
			set
			{
				this.Handle = new ContextHandle(value);
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00013778 File Offset: 0x00011978
		public EglContext(GraphicsMode mode, EglWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags)
		{
			if (mode == null)
			{
				throw new ArgumentNullException("mode");
			}
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			EglContext eglContext = (EglContext)sharedContext;
			this.WindowInfo = window;
			this.Renderable = RenderableFlags.GL;
			if ((flags & GraphicsContextFlags.Embedded) != GraphicsContextFlags.Default)
			{
				this.Renderable = ((major > 1) ? RenderableFlags.ES2 : RenderableFlags.ES);
			}
			RenderApi api = ((this.Renderable & RenderableFlags.GL) != (RenderableFlags)0) ? RenderApi.GL : RenderApi.ES;
			Egl.BindAPI(api);
			this.Mode = new EglGraphicsMode().SelectGraphicsMode(window, mode.ColorFormat, mode.Depth, mode.Stencil, mode.Samples, mode.AccumulatorFormat, mode.Buffers, mode.Stereo, this.Renderable);
			if (this.Mode.Index == null)
			{
				throw new GraphicsModeException("Invalid or unsupported GraphicsMode.");
			}
			IntPtr value = this.Mode.Index.Value;
			if (window.Surface == IntPtr.Zero)
			{
				window.CreateWindowSurface(value);
			}
			int[] attrib_list = new int[]
			{
				12440,
				major,
				12344
			};
			this.HandleAsEGLContext = Egl.CreateContext(window.Display, value, (eglContext != null) ? eglContext.HandleAsEGLContext : IntPtr.Zero, attrib_list);
			this.MakeCurrent(window);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x000138D4 File Offset: 0x00011AD4
		public EglContext(ContextHandle handle, EglWindowInfo window, IGraphicsContext sharedContext, int major, int minor, GraphicsContextFlags flags)
		{
			if (handle == ContextHandle.Zero)
			{
				throw new ArgumentException("handle");
			}
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			this.Handle = handle;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00013910 File Offset: 0x00011B10
		public override void SwapBuffers()
		{
			Egl.SwapBuffers(this.WindowInfo.Display, this.WindowInfo.Surface);
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00013930 File Offset: 0x00011B30
		public override void MakeCurrent(IWindowInfo window)
		{
			if (window is EglWindowInfo)
			{
				this.WindowInfo = (EglWindowInfo)window;
			}
			Egl.MakeCurrent(this.WindowInfo.Display, this.WindowInfo.Surface, this.WindowInfo.Surface, this.HandleAsEGLContext);
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00013980 File Offset: 0x00011B80
		public override bool IsCurrent
		{
			get
			{
				return Egl.GetCurrentContext() == this.HandleAsEGLContext;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00013994 File Offset: 0x00011B94
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x0001399C File Offset: 0x00011B9C
		public override int SwapInterval
		{
			get
			{
				return this.swap_interval;
			}
			set
			{
				if (value < 0)
				{
					value = 1;
				}
				if (Egl.SwapInterval(this.WindowInfo.Display, value))
				{
					this.swap_interval = value;
				}
			}
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000139C0 File Offset: 0x00011BC0
		public override IntPtr GetAddress(IntPtr function)
		{
			IntPtr intPtr = this.GetStaticAddress(function, this.Renderable);
			if (intPtr == IntPtr.Zero)
			{
				intPtr = Egl.GetProcAddress(function);
			}
			return intPtr;
		}

		// Token: 0x060004A8 RID: 1192
		protected abstract IntPtr GetStaticAddress(IntPtr function, RenderableFlags renderable);

		// Token: 0x060004A9 RID: 1193 RVA: 0x000139F0 File Offset: 0x00011BF0
		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00013A00 File Offset: 0x00011C00
		protected virtual void Dispose(bool manual)
		{
			if (!base.IsDisposed)
			{
				if (manual)
				{
					Egl.MakeCurrent(this.WindowInfo.Display, this.WindowInfo.Surface, this.WindowInfo.Surface, IntPtr.Zero);
					Egl.DestroyContext(this.WindowInfo.Display, this.HandleAsEGLContext);
				}
				base.IsDisposed = true;
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00013A64 File Offset: 0x00011C64
		~EglContext()
		{
			this.Dispose(false);
		}

		// Token: 0x040000B0 RID: 176
		protected readonly RenderableFlags Renderable;

		// Token: 0x040000B1 RID: 177
		protected EglWindowInfo WindowInfo;

		// Token: 0x040000B2 RID: 178
		private int swap_interval = 1;
	}
}
