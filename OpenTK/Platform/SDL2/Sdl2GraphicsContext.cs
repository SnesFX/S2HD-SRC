using System;
using System.Diagnostics;
using OpenTK.Graphics;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A2 RID: 1442
	internal class Sdl2GraphicsContext : DesktopGraphicsContext
	{
		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x0600460C RID: 17932 RVA: 0x000C0D9C File Offset: 0x000BEF9C
		// (set) Token: 0x0600460D RID: 17933 RVA: 0x000C0DA4 File Offset: 0x000BEFA4
		private IWindowInfo Window { get; set; }

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x0600460E RID: 17934 RVA: 0x000C0DB0 File Offset: 0x000BEFB0
		// (set) Token: 0x0600460F RID: 17935 RVA: 0x000C0DB8 File Offset: 0x000BEFB8
		private ContextHandle SdlContext { get; set; }

		// Token: 0x06004610 RID: 17936 RVA: 0x000C0DC4 File Offset: 0x000BEFC4
		private Sdl2GraphicsContext(IWindowInfo window)
		{
			if (window is Sdl2WindowInfo)
			{
				this.Window = window;
				return;
			}
			this.Window = new Sdl2WindowInfo(SDL.CreateWindowFrom(window.Handle), null);
		}

		// Token: 0x06004611 RID: 17937 RVA: 0x000C0DF4 File Offset: 0x000BEFF4
		public Sdl2GraphicsContext(GraphicsMode mode, IWindowInfo win, IGraphicsContext shareContext, int major, int minor, GraphicsContextFlags flags) : this(win)
		{
			lock (SDL.Sync)
			{
				do
				{
					Sdl2GraphicsContext.SetGLAttributes(mode, shareContext, major, minor, flags);
					this.SdlContext = new ContextHandle(SDL.GL.CreateContext(this.Window.Handle));
				}
				while (this.SdlContext == ContextHandle.Zero && Utilities.RelaxGraphicsMode(ref mode));
				if (this.SdlContext == ContextHandle.Zero)
				{
					string error = SDL.GetError();
					throw new GraphicsContextException(error);
				}
				this.Mode = Sdl2GraphicsContext.GetGLAttributes(this.SdlContext, out flags);
			}
			this.Handle = GraphicsContext.GetCurrentContext();
		}

		// Token: 0x06004612 RID: 17938 RVA: 0x000C0EBC File Offset: 0x000BF0BC
		private static GraphicsMode GetGLAttributes(ContextHandle sdlContext, out GraphicsContextFlags context_flags)
		{
			context_flags = GraphicsContextFlags.Default;
			int red;
			SDL.GL.GetAttribute(ContextAttribute.ACCUM_RED_SIZE, out red);
			int green;
			SDL.GL.GetAttribute(ContextAttribute.ACCUM_GREEN_SIZE, out green);
			int blue;
			SDL.GL.GetAttribute(ContextAttribute.ACCUM_BLUE_SIZE, out blue);
			int alpha;
			SDL.GL.GetAttribute(ContextAttribute.ACCUM_ALPHA_SIZE, out alpha);
			int num;
			SDL.GL.GetAttribute(ContextAttribute.DOUBLEBUFFER, out num);
			num++;
			int red2;
			SDL.GL.GetAttribute(ContextAttribute.RED_SIZE, out red2);
			int green2;
			SDL.GL.GetAttribute(ContextAttribute.GREEN_SIZE, out green2);
			int blue2;
			SDL.GL.GetAttribute(ContextAttribute.BLUE_SIZE, out blue2);
			int alpha2;
			SDL.GL.GetAttribute(ContextAttribute.ALPHA_SIZE, out alpha2);
			int depth;
			SDL.GL.GetAttribute(ContextAttribute.DEPTH_SIZE, out depth);
			int stencil;
			SDL.GL.GetAttribute(ContextAttribute.STENCIL_SIZE, out stencil);
			int samples;
			SDL.GL.GetAttribute(ContextAttribute.MULTISAMPLESAMPLES, out samples);
			int stereo;
			SDL.GL.GetAttribute(ContextAttribute.STEREO, out stereo);
			int num2;
			SDL.GL.GetAttribute(ContextAttribute.CONTEXT_MAJOR_VERSION, out num2);
			int num3;
			SDL.GL.GetAttribute(ContextAttribute.CONTEXT_MINOR_VERSION, out num3);
			int num4;
			SDL.GL.GetAttribute(ContextAttribute.CONTEXT_FLAGS, out num4);
			int num5;
			SDL.GL.GetAttribute(ContextAttribute.CONTEXT_EGL, out num5);
			int num6;
			SDL.GL.GetAttribute(ContextAttribute.CONTEXT_PROFILE_MASK, out num6);
			if (num5 != 0 && (num6 & 4) != 0)
			{
				context_flags |= GraphicsContextFlags.Embedded;
			}
			if ((num4 & 1) != 0)
			{
				context_flags |= GraphicsContextFlags.Debug;
			}
			if ((num6 & 1) != 0)
			{
				context_flags |= GraphicsContextFlags.ForwardCompatible;
			}
			return new GraphicsMode(new ColorFormat(red2, green2, blue2, alpha2), depth, stencil, samples, new ColorFormat(red, green, blue, alpha), num, stereo != 0);
		}

		// Token: 0x06004613 RID: 17939 RVA: 0x000C0FD4 File Offset: 0x000BF1D4
		private static void ClearGLAttributes()
		{
			SDL.GL.SetAttribute(ContextAttribute.ACCUM_ALPHA_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.ACCUM_RED_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.ACCUM_GREEN_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.ACCUM_BLUE_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.DOUBLEBUFFER, 0);
			SDL.GL.SetAttribute(ContextAttribute.ALPHA_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.RED_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.GREEN_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.BLUE_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.DEPTH_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.MULTISAMPLEBUFFERS, 0);
			SDL.GL.SetAttribute(ContextAttribute.MULTISAMPLESAMPLES, 0);
			SDL.GL.SetAttribute(ContextAttribute.STENCIL_SIZE, 0);
			SDL.GL.SetAttribute(ContextAttribute.STEREO, 0);
			SDL.GL.SetAttribute(ContextAttribute.CONTEXT_MAJOR_VERSION, 1);
			SDL.GL.SetAttribute(ContextAttribute.CONTEXT_MINOR_VERSION, 0);
			SDL.GL.SetAttribute(ContextAttribute.CONTEXT_FLAGS, 0);
			SDL.GL.SetAttribute(ContextAttribute.CONTEXT_EGL, 0);
			SDL.GL.SetAttribute(ContextAttribute.CONTEXT_PROFILE_MASK, 0);
			SDL.GL.SetAttribute(ContextAttribute.SHARE_WITH_CURRENT_CONTEXT, 0);
		}

		// Token: 0x06004614 RID: 17940 RVA: 0x000C1090 File Offset: 0x000BF290
		private static void SetGLAttributes(GraphicsMode mode, IGraphicsContext shareContext, int major, int minor, GraphicsContextFlags flags)
		{
			ContextProfileFlags contextProfileFlags = (ContextProfileFlags)0;
			Sdl2GraphicsContext.ClearGLAttributes();
			if (mode.AccumulatorFormat.BitsPerPixel > 0)
			{
				SDL.GL.SetAttribute(ContextAttribute.ACCUM_ALPHA_SIZE, mode.AccumulatorFormat.Alpha);
				SDL.GL.SetAttribute(ContextAttribute.ACCUM_RED_SIZE, mode.AccumulatorFormat.Red);
				SDL.GL.SetAttribute(ContextAttribute.ACCUM_GREEN_SIZE, mode.AccumulatorFormat.Green);
				SDL.GL.SetAttribute(ContextAttribute.ACCUM_BLUE_SIZE, mode.AccumulatorFormat.Blue);
			}
			if (mode.Buffers > 0)
			{
				SDL.GL.SetAttribute(ContextAttribute.DOUBLEBUFFER, (mode.Buffers > 1) ? 1 : 0);
			}
			if (mode.ColorFormat > 0)
			{
				SDL.GL.SetAttribute(ContextAttribute.ALPHA_SIZE, mode.ColorFormat.Alpha);
				SDL.GL.SetAttribute(ContextAttribute.RED_SIZE, mode.ColorFormat.Red);
				SDL.GL.SetAttribute(ContextAttribute.GREEN_SIZE, mode.ColorFormat.Green);
				SDL.GL.SetAttribute(ContextAttribute.BLUE_SIZE, mode.ColorFormat.Blue);
			}
			if (mode.Depth > 0)
			{
				SDL.GL.SetAttribute(ContextAttribute.DEPTH_SIZE, mode.Depth);
			}
			if (mode.Samples > 0)
			{
				SDL.GL.SetAttribute(ContextAttribute.MULTISAMPLEBUFFERS, 1);
				SDL.GL.SetAttribute(ContextAttribute.MULTISAMPLESAMPLES, mode.Samples);
			}
			if (mode.Stencil > 0)
			{
				SDL.GL.SetAttribute(ContextAttribute.STENCIL_SIZE, mode.Stereo ? 1 : 0);
			}
			if (mode.Stereo)
			{
				SDL.GL.SetAttribute(ContextAttribute.STEREO, 1);
			}
			if (major > 0)
			{
				if (Configuration.RunningOnMacOS && major >= 3 && (flags & GraphicsContextFlags.Embedded) == GraphicsContextFlags.Default)
				{
					contextProfileFlags |= ContextProfileFlags.CORE;
					if (major == 3 && minor < 2)
					{
						minor = 2;
					}
				}
				SDL.GL.SetAttribute(ContextAttribute.CONTEXT_MAJOR_VERSION, major);
				SDL.GL.SetAttribute(ContextAttribute.CONTEXT_MINOR_VERSION, minor);
			}
			if ((flags & GraphicsContextFlags.Debug) != GraphicsContextFlags.Default)
			{
				SDL.GL.SetAttribute(ContextAttribute.CONTEXT_FLAGS, ContextFlags.DEBUG);
			}
			if ((flags & GraphicsContextFlags.Embedded) != GraphicsContextFlags.Default)
			{
				contextProfileFlags |= ContextProfileFlags.ES;
				SDL.GL.SetAttribute(ContextAttribute.CONTEXT_EGL, 1);
			}
			if ((flags & GraphicsContextFlags.ForwardCompatible) != GraphicsContextFlags.Default)
			{
				contextProfileFlags |= ContextProfileFlags.CORE;
			}
			if (contextProfileFlags != (ContextProfileFlags)0)
			{
				SDL.GL.SetAttribute(ContextAttribute.CONTEXT_PROFILE_MASK, contextProfileFlags);
			}
			if (shareContext != null)
			{
				if (shareContext.IsCurrent)
				{
					SDL.GL.SetAttribute(ContextAttribute.SHARE_WITH_CURRENT_CONTEXT, 1);
					return;
				}
				Trace.WriteLine("Warning: SDL2 requires a shared context to be current before sharing. Sharing failed.");
			}
		}

		// Token: 0x06004615 RID: 17941 RVA: 0x000C1288 File Offset: 0x000BF488
		public static ContextHandle GetCurrentContext()
		{
			return new ContextHandle(SDL.GL.GetCurrentContext());
		}

		// Token: 0x06004616 RID: 17942 RVA: 0x000C1294 File Offset: 0x000BF494
		public override void SwapBuffers()
		{
			SDL.GL.SwapWindow(this.Window.Handle);
		}

		// Token: 0x06004617 RID: 17943 RVA: 0x000C12A8 File Offset: 0x000BF4A8
		public override void MakeCurrent(IWindowInfo window)
		{
			if (window != null)
			{
				int num = SDL.GL.MakeCurrent(window.Handle, this.SdlContext.Handle);
			}
			else
			{
				int num = SDL.GL.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
			}
		}

		// Token: 0x06004618 RID: 17944 RVA: 0x000C12EC File Offset: 0x000BF4EC
		public override IntPtr GetAddress(IntPtr function)
		{
			return SDL.GL.GetProcAddress(function);
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06004619 RID: 17945 RVA: 0x000C12F4 File Offset: 0x000BF4F4
		public override bool IsCurrent
		{
			get
			{
				return GraphicsContext.GetCurrentContext() == base.Context;
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x0600461A RID: 17946 RVA: 0x000C130C File Offset: 0x000BF50C
		// (set) Token: 0x0600461B RID: 17947 RVA: 0x000C1314 File Offset: 0x000BF514
		public override int SwapInterval
		{
			get
			{
				return SDL.GL.GetSwapInterval();
			}
			set
			{
				SDL.GL.SetSwapInterval(value);
			}
		}

		// Token: 0x0600461C RID: 17948 RVA: 0x000C1320 File Offset: 0x000BF520
		private void Dispose(bool manual)
		{
			if (!base.IsDisposed)
			{
				if (manual)
				{
					lock (SDL.Sync)
					{
						SDL.GL.DeleteContext(this.SdlContext.Handle);
					}
				}
				base.IsDisposed = true;
			}
		}

		// Token: 0x0600461D RID: 17949 RVA: 0x000C1378 File Offset: 0x000BF578
		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600461E RID: 17950 RVA: 0x000C1388 File Offset: 0x000BF588
		~Sdl2GraphicsContext()
		{
			this.Dispose(false);
		}
	}
}
