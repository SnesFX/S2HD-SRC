using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using SDL2;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.SDL2
{
	// Token: 0x0200000D RID: 13
	public class SDL2WindowContext : WindowContext
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00003A53 File Offset: 0x00001C53
		public IntPtr WindowHandle
		{
			get
			{
				return this._windowHandle;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00003A5B File Offset: 0x00001C5B
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00003A63 File Offset: 0x00001C63
		public Thread ContextThread { get; private set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00003A6C File Offset: 0x00001C6C
		public override SonicOrca.Graphics.IGraphicsContext GraphicsContext
		{
			get
			{
				return this._glGraphicsContext;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00003A74 File Offset: 0x00001C74
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00003A7C File Offset: 0x00001C7C
		public bool IsMaxPerformance { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00003A85 File Offset: 0x00001C85
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00003A90 File Offset: 0x00001C90
		public override bool FullScreen
		{
			get
			{
				return this.Mode > VideoMode.Windowed;
			}
			set
			{
				if (value)
				{
					if (this.Mode == VideoMode.Windowed)
					{
						this.Mode = VideoMode.WindowedBorderless;
						return;
					}
				}
				else
				{
					this.Mode = VideoMode.Windowed;
				}
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003AAC File Offset: 0x00001CAC
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00003AB4 File Offset: 0x00001CB4
		public override VideoMode Mode
		{
			get
			{
				return this._mode;
			}
			set
			{
				if (this._mode != value)
				{
					this._mode = value;
					uint flags = 0U;
					if (value == VideoMode.Fullscreen)
					{
						flags = 1U;
					}
					else if (value == VideoMode.WindowedBorderless)
					{
						flags = 4097U;
					}
					SDL.SDL_SetWindowFullscreen(this._windowHandle, flags);
					if (value == VideoMode.Windowed)
					{
						this.UpdateWindowSize(new Vector2i(1920, 1080));
					}
				}
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00003B0A File Offset: 0x00001D0A
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00003B12 File Offset: 0x00001D12
		public override string WindowTitle
		{
			get
			{
				return this._windowTitle;
			}
			set
			{
				this._windowTitle = value;
				if (this._windowHandle != IntPtr.Zero)
				{
					SDL.SDL_SetWindowTitle(this._windowHandle, value);
				}
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00003B39 File Offset: 0x00001D39
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00003B41 File Offset: 0x00001D41
		public override Vector2i ClientSize
		{
			get
			{
				return this._clientSize;
			}
			set
			{
				this.UpdateWindowSize(value);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00003B4A File Offset: 0x00001D4A
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00003B52 File Offset: 0x00001D52
		public override Vector2i AspectRatio
		{
			get
			{
				return this._aspectRatio;
			}
			set
			{
				if (this._aspectRatio != value)
				{
					this._aspectRatio = value;
					this.UpdateWindowSize();
				}
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003B6F File Offset: 0x00001D6F
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00003B77 File Offset: 0x00001D77
		public override bool HideCursorIfIdle
		{
			get
			{
				return base.HideCursorIfIdle;
			}
			set
			{
				base.HideCursorIfIdle = value;
				if (value)
				{
					this.ShowCursor = true;
				}
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00003B8A File Offset: 0x00001D8A
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00003B92 File Offset: 0x00001D92
		public bool ShowCursor
		{
			get
			{
				return this._showingCursor;
			}
			set
			{
				if (this._showingCursor != value)
				{
					this._showingCursor = value;
					SDL.SDL_ShowCursor(value ? 1 : 0);
				}
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003BB4 File Offset: 0x00001DB4
		public SDL2WindowContext(SDL2Platform platform)
		{
			this._platform = platform;
			Trace.WriteLine("Initialising SDL2 video");
			if (SDL.SDL_InitSubSystem(32U) != 0)
			{
				throw SDL2Exception.FromError("Unable to initialise a video driver.");
			}
			SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_MULTISAMPLESAMPLES, 1);
			SDL.SDL_GL_SetSwapInterval(1);
			SDL.SDL_DisplayMode sdl_DisplayMode;
			SDL.SDL_GetDesktopDisplayMode(0, out sdl_DisplayMode);
			int num = 1920;
			int num2 = 1080;
			while (num > sdl_DisplayMode.w || num2 > sdl_DisplayMode.h)
			{
				num -= 480;
				num2 -= 270;
			}
			Trace.WriteLine("Creating window");
			this._windowHandle = SDL.SDL_CreateWindow(this._windowTitle, 805240832, 805240832, num, num2, SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL | SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN | SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
			if (this._windowHandle == IntPtr.Zero)
			{
				throw SDL2Exception.FromError("Unable to create window.");
			}
			this._clientSize = new Vector2i(num, num2);
			this.SetIconToAssemblyResource();
			Trace.WriteLine("Creating OpenGL context");
			this._glContext = SDL.SDL_GL_CreateContext(this._windowHandle);
			if (this._glContext == IntPtr.Zero)
			{
				throw SDL2Exception.FromError("Unable to create OpenGL context.");
			}
			this.SetOpenTKOpenGLHandle(this._glContext, this.GetWindowHWND(this._windowHandle));
			this.ContextThread = Thread.CurrentThread;
			this._glGraphicsContext = new GLGraphicsContext(this);
			this.ShowWindowWithBlackBackground();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003D20 File Offset: 0x00001F20
		private void SetIconToAssemblyResource()
		{
			IntPtr intPtr = SDL2WindowContext.User32.LoadIcon(Marshal.GetHINSTANCE(Assembly.GetEntryAssembly().ManifestModule), new IntPtr(32512));
			if (intPtr != IntPtr.Zero)
			{
				SDL2WindowContext.User32.SendMessage(this.GetWindowHWND(this._windowHandle), 128U, new IntPtr(0), intPtr);
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003D78 File Offset: 0x00001F78
		private void SetOpenTKOpenGLHandle(IntPtr glHandle, IntPtr windowHandle)
		{
			Toolkit.Init();
			Utilities.CreateWindowsWindowInfo(windowHandle);
			ContextHandle ch = new ContextHandle(this._glContext);
			((IGraphicsContextInternal)new GraphicsContext(ch, (string proc) => SDL.SDL_GL_GetProcAddress(proc), () => ch)).Implementation.LoadAll();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003DEC File Offset: 0x00001FEC
		private IntPtr GetWindowHWND(IntPtr window)
		{
			SDL.SDL_SysWMinfo sdl_SysWMinfo = default(SDL.SDL_SysWMinfo);
			SDL.SDL_GetWindowWMInfo(window, ref sdl_SysWMinfo);
			return sdl_SysWMinfo.info.win.window;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003E1A File Offset: 0x0000201A
		public override void Dispose()
		{
			Trace.WriteLine("Deleting OpenGL context");
			SDL.SDL_GL_DeleteContext(this._glContext);
			Trace.WriteLine("Closing window");
			SDL.SDL_DestroyWindow(this._windowHandle);
			Trace.WriteLine("Quitting SDL2 video");
			SDL.SDL_QuitSubSystem(32U);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003E58 File Offset: 0x00002058
		public override void Update()
		{
			uint num = SDL.SDL_GetTicks();
			SDL.SDL_PumpEvents();
			int num2 = SDL.SDL_PeepEvents(this.events, this.events.Length, SDL.SDL_eventaction.SDL_PEEKEVENT, SDL.SDL_EventType.SDL_FIRSTEVENT, SDL.SDL_EventType.SDL_LASTEVENT);
			for (int i = 0; i < num2; i++)
			{
				SDL.SDL_Event sdl_Event = this.events[i];
				if (sdl_Event.type == SDL.SDL_EventType.SDL_QUIT)
				{
					base.Finished = true;
				}
				SDL.SDL_EventType type = sdl_Event.type;
				if (type != SDL.SDL_EventType.SDL_WINDOWEVENT)
				{
					if (type != SDL.SDL_EventType.SDL_KEYDOWN)
					{
						if (type == SDL.SDL_EventType.SDL_MOUSEMOTION && this.HideCursorIfIdle)
						{
							this._lastMouseMovementTickCount = num;
							this.ShowCursor = true;
						}
					}
					else if ((sdl_Event.key.keysym.mod & SDL.SDL_Keymod.KMOD_ALT) != SDL.SDL_Keymod.KMOD_NONE && sdl_Event.key.keysym.sym == SDL.SDL_Keycode.SDLK_F4)
					{
						base.Finished = true;
					}
				}
				else
				{
					SDL.SDL_WindowEventID windowEvent = sdl_Event.window.windowEvent;
					if (windowEvent != SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SIZE_CHANGED)
					{
						if (windowEvent == SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE)
						{
							base.Finished = true;
						}
					}
					else
					{
						this.UpdateWindowSize(new Vector2i(sdl_Event.window.data1, sdl_Event.window.data2));
					}
				}
			}
			Action action;
			while (this._dispatchedActions.TryDequeue(out action))
			{
				action();
			}
			this._glGraphicsContext.Update();
			if (this.HideCursorIfIdle && num - this._lastMouseMovementTickCount > 3000U)
			{
				this.ShowCursor = false;
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003FC1 File Offset: 0x000021C1
		public override void BeginRender()
		{
			GL.ClearColor(0f, 0f, 0f, 0f);
			this._glGraphicsContext.BlendMode = BlendMode.Alpha;
			this._glGraphicsContext.RenderToBackBuffer();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003FF3 File Offset: 0x000021F3
		public override void EndRender()
		{
			if (!SonicOrcaGameContext.IsMaxPerformance)
			{
				GL.Finish();
			}
			SDL.SDL_GL_SwapWindow(this._windowHandle);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000400C File Offset: 0x0000220C
		public void Dispatch(Action action)
		{
			this._dispatchedActions.Enqueue(action);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000401A File Offset: 0x0000221A
		private void ShowWindowWithBlackBackground()
		{
			GL.ClearColor(0f, 0f, 0f, 1f);
			SDL.SDL_GL_SwapWindow(this._windowHandle);
			SDL.SDL_ShowWindow(this._windowHandle);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000404B File Offset: 0x0000224B
		private void UpdateWindowSize()
		{
			this.UpdateWindowSize(this._clientSize);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000405C File Offset: 0x0000225C
		private void UpdateWindowSize(Vector2i size)
		{
			if (this._aspectRatio.X != 0 || this._aspectRatio.Y != 0)
			{
				double num = (double)this._aspectRatio.X / (double)this._aspectRatio.Y;
				if (this._clientSize.X != size.X)
				{
					size.Y = (int)((double)size.X / num);
				}
				else if (this._clientSize.Y != size.Y)
				{
					size.X = (int)((double)size.Y * num);
				}
			}
			this._clientSize = size;
			SDL.SDL_SetWindowSize(this._windowHandle, size.X, size.Y);
			GL.Viewport(0, 0, size.X, size.Y);
		}

		// Token: 0x04000035 RID: 53
		public const int DEFAULT_HICON_RESOURCE_ID = 32512;

		// Token: 0x04000036 RID: 54
		private const int HideMouseIdleTimeMs = 3000;

		// Token: 0x04000037 RID: 55
		private readonly SDL2Platform _platform;

		// Token: 0x04000038 RID: 56
		private readonly ConcurrentQueue<Action> _dispatchedActions = new ConcurrentQueue<Action>();

		// Token: 0x04000039 RID: 57
		private readonly GLGraphicsContext _glGraphicsContext;

		// Token: 0x0400003A RID: 58
		private IntPtr _windowHandle;

		// Token: 0x0400003B RID: 59
		private IntPtr _glContext;

		// Token: 0x0400003C RID: 60
		private Vector2i _clientSize;

		// Token: 0x0400003D RID: 61
		private Vector2i _aspectRatio;

		// Token: 0x0400003E RID: 62
		private VideoMode _mode;

		// Token: 0x0400003F RID: 63
		private string _windowTitle;

		// Token: 0x04000040 RID: 64
		private uint _lastMouseMovementTickCount;

		// Token: 0x04000041 RID: 65
		private bool _showingCursor = true;

		// Token: 0x04000043 RID: 67
		private SDL.SDL_Event[] events = new SDL.SDL_Event[512];

		// Token: 0x02000016 RID: 22
		private static class User32
		{
			// Token: 0x060000B7 RID: 183
			[DllImport("user32.dll")]
			public static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

			// Token: 0x060000B8 RID: 184
			[DllImport("user32.dll")]
			public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

			// Token: 0x0400005C RID: 92
			public const int WM_SETICON = 128;

			// Token: 0x0400005D RID: 93
			public const int ICON_SMALL = 0;
		}
	}
}
