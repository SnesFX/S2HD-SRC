using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using SDL2;
using SonicOrca.Audio;
using SonicOrca.Graphics;
using SonicOrca.Input;

namespace SonicOrca.SDL2
{
	// Token: 0x0200000C RID: 12
	public class SDL2Platform : IPlatform, IDisposable
	{
		// Token: 0x0600006B RID: 107
		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibrary(string path);

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003885 File Offset: 0x00001A85
		public WindowContext Window
		{
			get
			{
				return this._window;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000388D File Offset: 0x00001A8D
		public InputContext Input
		{
			get
			{
				return this._input;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00003895 File Offset: 0x00001A95
		public AudioContext Audio
		{
			get
			{
				return this._audio;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600006F RID: 111 RVA: 0x0000389D File Offset: 0x00001A9D
		public static SDL2Platform Instance
		{
			get
			{
				return SDL2Platform._singleton;
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000038A4 File Offset: 0x00001AA4
		private SDL2Platform()
		{
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000038AC File Offset: 0x00001AAC
		public void Initialise()
		{
			if (this._initialised)
			{
				throw new InvalidOperationException("Platform already initialised.");
			}
			this._initialised = true;
			Trace.WriteLine("Initialising SDL2 platform");
			Trace.WriteLine("-- SDL2 " + this.GetVersion());
			Trace.Indent();
			this._window = new SDL2WindowContext(this);
			this._input = new SDL2InputContext(this);
			this._audio = new SDL2AudioContext(this);
			Trace.Unindent();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003920 File Offset: 0x00001B20
		public void Dispose()
		{
			if (!this._initialised)
			{
				throw new InvalidOperationException("Platform not initialised.");
			}
			this._initialised = false;
			Trace.WriteLine("Disposing SDL2 platform");
			Trace.Indent();
			if (this._audio != null)
			{
				this._audio.Dispose();
			}
			if (this._input != null)
			{
				this._input.Dispose();
			}
			if (this._window != null)
			{
				this._window.Dispose();
			}
			Trace.Unindent();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003994 File Offset: 0x00001B94
		public Version GetVersion()
		{
			SDL.SDL_version sdl_version;
			SDL.SDL_VERSION(out sdl_version);
			return new Version((int)sdl_version.major, (int)sdl_version.minor, (int)sdl_version.patch);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000039C0 File Offset: 0x00001BC0
		public Version GetOpenGLVersion()
		{
			if (!this._initialised)
			{
				throw new InvalidOperationException("Platform not initialised.");
			}
			int major;
			GL.GetInteger(GetPName.MajorVersion, out major);
			int minor;
			GL.GetInteger(GetPName.MinorVersion, out minor);
			return new Version(major, minor);
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00003A00 File Offset: 0x00001C00
		public string GraphicsAPI
		{
			get
			{
				Version openGLVersion = this.GetOpenGLVersion();
				return string.Format("OpenGL {0}.{1}", openGLVersion.Major, openGLVersion.Minor);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00003A34 File Offset: 0x00001C34
		public string GraphicsVendor
		{
			get
			{
				return GL.GetString(StringName.Vendor);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00003A40 File Offset: 0x00001C40
		public int TotalMemory
		{
			get
			{
				return SDL.SDL_GetSystemRAM();
			}
		}

		// Token: 0x04000030 RID: 48
		private static readonly SDL2Platform _singleton = new SDL2Platform();

		// Token: 0x04000031 RID: 49
		private bool _initialised;

		// Token: 0x04000032 RID: 50
		private SDL2WindowContext _window;

		// Token: 0x04000033 RID: 51
		private SDL2InputContext _input;

		// Token: 0x04000034 RID: 52
		private SDL2AudioContext _audio;
	}
}
