using System;
using System.IO;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Platform.Egl;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B72 RID: 2930
	internal class LinuxFactory : PlatformFactoryBase
	{
		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06005B7C RID: 23420 RVA: 0x000F7EB8 File Offset: 0x000F60B8
		private int gpu_fd
		{
			get
			{
				int fd;
				lock (this)
				{
					if (this._fd == 0)
					{
						this._fd = LinuxFactory.CreateDisplay(out this.gbm_device, out this.egl_display);
					}
					fd = this._fd;
				}
				return fd;
			}
		}

		// Token: 0x06005B7D RID: 23421 RVA: 0x000F7F10 File Offset: 0x000F6110
		private static int CreateDisplay(out IntPtr gbm_device, out IntPtr egl_display)
		{
			int num = 0;
			gbm_device = IntPtr.Zero;
			egl_display = IntPtr.Zero;
			string[] files = Directory.GetFiles("/dev/dri");
			foreach (string text in files)
			{
				if (Path.GetFileName(text).StartsWith("card"))
				{
					int num2 = LinuxFactory.SetupDisplay(text, out gbm_device, out egl_display);
					if (num2 >= 0)
					{
						try
						{
							if (LinuxDisplayDriver.QueryDisplays(num2, null))
							{
								num = num2;
								break;
							}
						}
						catch (Exception)
						{
						}
						Libc.close(num2);
					}
				}
			}
			if (num == 0)
			{
				throw new PlatformNotSupportedException();
			}
			return num;
		}

		// Token: 0x06005B7E RID: 23422 RVA: 0x000F7FB0 File Offset: 0x000F61B0
		private static int SetupDisplay(string gpu, out IntPtr gbm_device, out IntPtr egl_display)
		{
			gbm_device = IntPtr.Zero;
			egl_display = IntPtr.Zero;
			int num = Libc.open(gpu, OpenFlags.ReadWrite | OpenFlags.CloseOnExec);
			if (num < 0)
			{
				return num;
			}
			gbm_device = Gbm.CreateDevice(num);
			if (gbm_device == IntPtr.Zero)
			{
				throw new NotSupportedException("[KMS] Failed to create GBM device");
			}
			egl_display = Egl.GetDisplay(gbm_device);
			if (egl_display == IntPtr.Zero)
			{
				throw new NotSupportedException("[KMS] Failed to create EGL display");
			}
			int num2;
			int num3;
			if (!Egl.Initialize(egl_display, out num2, out num3))
			{
				ErrorCode error = Egl.GetError();
				throw new NotSupportedException("[KMS] Failed to initialize EGL display. Error code: " + error);
			}
			return num;
		}

		// Token: 0x06005B7F RID: 23423 RVA: 0x000F806C File Offset: 0x000F626C
		protected override void Dispose(bool manual)
		{
			if (this.egl_display != IntPtr.Zero)
			{
				Egl.Terminate(this.egl_display);
				this.egl_display = IntPtr.Zero;
			}
			if (this.gbm_device != IntPtr.Zero)
			{
				Gbm.DestroyDevice(this.gbm_device);
				this.gbm_device = IntPtr.Zero;
			}
			if (this._fd >= 0)
			{
				Libc.close(this._fd);
			}
			base.Dispose(manual);
		}

		// Token: 0x06005B80 RID: 23424 RVA: 0x000F80E8 File Offset: 0x000F62E8
		public override INativeWindow CreateNativeWindow(int x, int y, int width, int height, string title, GraphicsMode mode, GameWindowFlags options, DisplayDevice display_device)
		{
			return new LinuxNativeWindow(this.egl_display, this.gbm_device, this.gpu_fd, x, y, width, height, title, mode, options, display_device);
		}

		// Token: 0x06005B81 RID: 23425 RVA: 0x000F811C File Offset: 0x000F631C
		public override IDisplayDeviceDriver CreateDisplayDeviceDriver()
		{
			return new LinuxDisplayDriver(this.gpu_fd);
		}

		// Token: 0x06005B82 RID: 23426 RVA: 0x000F812C File Offset: 0x000F632C
		public override IGraphicsContext CreateGLContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, bool directRendering, int major, int minor, GraphicsContextFlags flags)
		{
			return new LinuxGraphicsContext(mode, (LinuxWindowInfo)window, shareContext, major, minor, flags);
		}

		// Token: 0x06005B83 RID: 23427 RVA: 0x000F8144 File Offset: 0x000F6344
		public override GraphicsContext.GetCurrentContextDelegate CreateGetCurrentGraphicsContext()
		{
			return () => new ContextHandle(Egl.GetCurrentContext());
		}

		// Token: 0x06005B84 RID: 23428 RVA: 0x000F8164 File Offset: 0x000F6364
		public override IKeyboardDriver2 CreateKeyboardDriver()
		{
			IKeyboardDriver2 mouseKeyboardDriver;
			lock (this)
			{
				this.MouseKeyboardDriver = (this.MouseKeyboardDriver ?? new LinuxInput());
				mouseKeyboardDriver = this.MouseKeyboardDriver;
			}
			return mouseKeyboardDriver;
		}

		// Token: 0x06005B85 RID: 23429 RVA: 0x000F81B0 File Offset: 0x000F63B0
		public override IMouseDriver2 CreateMouseDriver()
		{
			IMouseDriver2 mouseKeyboardDriver;
			lock (this)
			{
				this.MouseKeyboardDriver = (this.MouseKeyboardDriver ?? new LinuxInput());
				mouseKeyboardDriver = this.MouseKeyboardDriver;
			}
			return mouseKeyboardDriver;
		}

		// Token: 0x06005B86 RID: 23430 RVA: 0x000F81FC File Offset: 0x000F63FC
		public override IJoystickDriver2 CreateJoystickDriver()
		{
			IJoystickDriver2 joystickDriver;
			lock (this)
			{
				this.JoystickDriver = (this.JoystickDriver ?? new LinuxJoystick());
				joystickDriver = this.JoystickDriver;
			}
			return joystickDriver;
		}

		// Token: 0x0400B82F RID: 47151
		private const string gpu_path = "/dev/dri";

		// Token: 0x0400B830 RID: 47152
		private int _fd;

		// Token: 0x0400B831 RID: 47153
		private IntPtr gbm_device;

		// Token: 0x0400B832 RID: 47154
		private IntPtr egl_display;

		// Token: 0x0400B833 RID: 47155
		private IJoystickDriver2 JoystickDriver;

		// Token: 0x0400B834 RID: 47156
		private LinuxInput MouseKeyboardDriver;
	}
}
