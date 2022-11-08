using System;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform
{
	// Token: 0x02000062 RID: 98
	internal abstract class PlatformFactoryBase : IPlatformFactory, IDisposable
	{
		// Token: 0x060006BA RID: 1722 RVA: 0x00017BDC File Offset: 0x00015DDC
		public PlatformFactoryBase()
		{
		}

		// Token: 0x060006BB RID: 1723
		public abstract INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice device);

		// Token: 0x060006BC RID: 1724
		public abstract IDisplayDeviceDriver CreateDisplayDeviceDriver();

		// Token: 0x060006BD RID: 1725
		public abstract IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags);

		// Token: 0x060006BE RID: 1726 RVA: 0x00017BE4 File Offset: 0x00015DE4
		public virtual IGraphicsContext CreateGLContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060006BF RID: 1727
		public abstract GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext();

		// Token: 0x060006C0 RID: 1728
		public abstract IKeyboardDriver2 CreateKeyboardDriver();

		// Token: 0x060006C1 RID: 1729
		public abstract IMouseDriver2 CreateMouseDriver();

		// Token: 0x060006C2 RID: 1730 RVA: 0x00017BEC File Offset: 0x00015DEC
		public virtual IGamePadDriver CreateGamePadDriver()
		{
			return new MappedGamePadDriver();
		}

		// Token: 0x060006C3 RID: 1731
		public abstract IJoystickDriver2 CreateJoystickDriver();

		// Token: 0x060006C4 RID: 1732 RVA: 0x00017BF4 File Offset: 0x00015DF4
		public virtual IJoystickDriver CreateLegacyJoystickDriver()
		{
			return new LegacyJoystickDriver();
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00017BFC File Offset: 0x00015DFC
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00017C0C File Offset: 0x00015E0C
		protected virtual void Dispose(bool manual)
		{
			if (!this.IsDisposed)
			{
				this.IsDisposed = true;
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00017C20 File Offset: 0x00015E20
		~PlatformFactoryBase()
		{
			this.Dispose(false);
		}

		// Token: 0x040001C8 RID: 456
		protected bool IsDisposed;
	}
}
