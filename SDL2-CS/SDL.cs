using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDL2
{
	// Token: 0x02000002 RID: 2
	public static class SDL
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static uint SDL_FOURCC(byte A, byte B, byte C, byte D)
		{
			return (uint)((int)A | (int)B << 8 | (int)C << 16 | (int)D << 24);
		}

		// Token: 0x06000002 RID: 2
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr SDL_malloc(IntPtr size);

		// Token: 0x06000003 RID: 3
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		internal static extern void SDL_free(IntPtr memblock);

		// Token: 0x06000004 RID: 4
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFile")]
		internal static extern IntPtr INTERNAL_SDL_RWFromFile([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string file, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string mode);

		// Token: 0x06000005 RID: 5
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_RWFromMem(byte[] mem, int size);

		// Token: 0x06000006 RID: 6
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetMainReady();

		// Token: 0x06000007 RID: 7
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_Init(uint flags);

		// Token: 0x06000008 RID: 8
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_InitSubSystem(uint flags);

		// Token: 0x06000009 RID: 9
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Quit();

		// Token: 0x0600000A RID: 10
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_QuitSubSystem(uint flags);

		// Token: 0x0600000B RID: 11
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WasInit(uint flags);

		// Token: 0x0600000C RID: 12
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetPlatform();

		// Token: 0x0600000D RID: 13
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_ClearHints();

		// Token: 0x0600000E RID: 14
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetHint([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string name);

		// Token: 0x0600000F RID: 15
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_SetHint([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string value);

		// Token: 0x06000010 RID: 16
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_SetHintWithPriority([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string value, SDL.SDL_HintPriority priority);

		// Token: 0x06000011 RID: 17
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_GetHintBoolean([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string name, SDL.SDL_bool default_value);

		// Token: 0x06000012 RID: 18
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_ClearError();

		// Token: 0x06000013 RID: 19
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetError();

		// Token: 0x06000014 RID: 20
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetError([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x06000015 RID: 21
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Log([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x06000016 RID: 22
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogVerbose(int category, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x06000017 RID: 23
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogDebug(int category, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x06000018 RID: 24
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogInfo(int category, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x06000019 RID: 25
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogWarn(int category, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x0600001A RID: 26
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogError(int category, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x0600001B RID: 27
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogCritical(int category, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x0600001C RID: 28
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogMessage(int category, SDL.SDL_LogPriority priority, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x0600001D RID: 29
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogMessageV(int category, SDL.SDL_LogPriority priority, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string fmt, __arglist);

		// Token: 0x0600001E RID: 30
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_LogPriority SDL_LogGetPriority(int category);

		// Token: 0x0600001F RID: 31
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogSetPriority(int category, SDL.SDL_LogPriority priority);

		// Token: 0x06000020 RID: 32
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogSetAllPriority(SDL.SDL_LogPriority priority);

		// Token: 0x06000021 RID: 33
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogResetPriorities();

		// Token: 0x06000022 RID: 34
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogGetOutputFunction(out SDL.SDL_LogOutputFunction callback, out IntPtr userdata);

		// Token: 0x06000023 RID: 35
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogSetOutputFunction(SDL.SDL_LogOutputFunction callback, IntPtr userdata);

		// Token: 0x06000024 RID: 36
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowMessageBox")]
		private static extern int INTERNAL_SDL_ShowMessageBox([In] ref SDL.INTERNAL_SDL_MessageBoxData messageboxdata, out int buttonid);

		// Token: 0x06000025 RID: 37 RVA: 0x00002074 File Offset: 0x00000274
		public unsafe static int SDL_ShowMessageBox([In] ref SDL.SDL_MessageBoxData messageboxdata, out int buttonid)
		{
			ICustomMarshaler instance = LPUtf8StrMarshaler.GetInstance(null);
			SDL.INTERNAL_SDL_MessageBoxData internal_SDL_MessageBoxData = new SDL.INTERNAL_SDL_MessageBoxData
			{
				flags = messageboxdata.flags,
				window = messageboxdata.window,
				title = instance.MarshalManagedToNative(messageboxdata.title),
				message = instance.MarshalManagedToNative(messageboxdata.message),
				numbuttons = messageboxdata.numbuttons
			};
			SDL.INTERNAL_SDL_MessageBoxButtonData[] array = new SDL.INTERNAL_SDL_MessageBoxButtonData[messageboxdata.numbuttons];
			for (int i = 0; i < messageboxdata.numbuttons; i++)
			{
				array[i] = new SDL.INTERNAL_SDL_MessageBoxButtonData
				{
					flags = messageboxdata.buttons[i].flags,
					buttonid = messageboxdata.buttons[i].buttonid,
					text = instance.MarshalManagedToNative(messageboxdata.buttons[i].text)
				};
			}
			bool flag = messageboxdata.colorScheme != null;
			if (flag)
			{
				internal_SDL_MessageBoxData.colorScheme = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SDL.SDL_MessageBoxColorScheme)));
				Marshal.StructureToPtr(messageboxdata.colorScheme.Value, internal_SDL_MessageBoxData.colorScheme, false);
			}
			int result;
			fixed (SDL.INTERNAL_SDL_MessageBoxButtonData* ptr = &array[0])
			{
				internal_SDL_MessageBoxData.buttons = (IntPtr)((void*)ptr);
				result = SDL.INTERNAL_SDL_ShowMessageBox(ref internal_SDL_MessageBoxData, out buttonid);
			}
			Marshal.FreeHGlobal(internal_SDL_MessageBoxData.colorScheme);
			for (int j = 0; j < messageboxdata.numbuttons; j++)
			{
				instance.CleanUpNativeData(array[j].text);
			}
			instance.CleanUpNativeData(internal_SDL_MessageBoxData.message);
			instance.CleanUpNativeData(internal_SDL_MessageBoxData.title);
			return result;
		}

		// Token: 0x06000026 RID: 38
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_ShowSimpleMessageBox(SDL.SDL_MessageBoxFlags flags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string message, IntPtr window);

		// Token: 0x06000027 RID: 39 RVA: 0x0000223D File Offset: 0x0000043D
		public static void SDL_VERSION(out SDL.SDL_version x)
		{
			x.major = 2;
			x.minor = 0;
			x.patch = 6;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002258 File Offset: 0x00000458
		public static int SDL_VERSIONNUM(int X, int Y, int Z)
		{
			return X * 1000 + Y * 100 + Z;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002278 File Offset: 0x00000478
		public static bool SDL_VERSION_ATLEAST(int X, int Y, int Z)
		{
			return SDL.SDL_COMPILEDVERSION >= SDL.SDL_VERSIONNUM(X, Y, Z);
		}

		// Token: 0x0600002A RID: 42
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetVersion(out SDL.SDL_version ver);

		// Token: 0x0600002B RID: 43
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetRevision();

		// Token: 0x0600002C RID: 44
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRevisionNumber();

		// Token: 0x0600002D RID: 45 RVA: 0x0000229C File Offset: 0x0000049C
		public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(int X)
		{
			return 536805376 | X;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000022B8 File Offset: 0x000004B8
		public static bool SDL_WINDOWPOS_ISUNDEFINED(int X)
		{
			return ((long)X & (long)((ulong)-65536)) == 536805376L;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000022DC File Offset: 0x000004DC
		public static int SDL_WINDOWPOS_CENTERED_DISPLAY(int X)
		{
			return 805240832 | X;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000022F8 File Offset: 0x000004F8
		public static bool SDL_WINDOWPOS_ISCENTERED(int X)
		{
			return ((long)X & (long)((ulong)-65536)) == 805240832L;
		}

		// Token: 0x06000031 RID: 49
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateWindow([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string title, int x, int y, int w, int h, SDL.SDL_WindowFlags flags);

		// Token: 0x06000032 RID: 50
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_CreateWindowAndRenderer(int width, int height, SDL.SDL_WindowFlags window_flags, out IntPtr window, out IntPtr renderer);

		// Token: 0x06000033 RID: 51
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);

		// Token: 0x06000034 RID: 52
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DestroyWindow(IntPtr window);

		// Token: 0x06000035 RID: 53
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DisableScreenSaver();

		// Token: 0x06000036 RID: 54
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_EnableScreenSaver();

		// Token: 0x06000037 RID: 55
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetClosestDisplayMode(int displayIndex, ref SDL.SDL_DisplayMode mode, out SDL.SDL_DisplayMode closest);

		// Token: 0x06000038 RID: 56
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetCurrentDisplayMode(int displayIndex, out SDL.SDL_DisplayMode mode);

		// Token: 0x06000039 RID: 57
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetCurrentVideoDriver();

		// Token: 0x0600003A RID: 58
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDesktopDisplayMode(int displayIndex, out SDL.SDL_DisplayMode mode);

		// Token: 0x0600003B RID: 59
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetDisplayName(int index);

		// Token: 0x0600003C RID: 60
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDisplayBounds(int displayIndex, out SDL.SDL_Rect rect);

		// Token: 0x0600003D RID: 61
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDisplayDPI(int displayIndex, out float ddpi, out float hdpi, out float vdpi);

		// Token: 0x0600003E RID: 62
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDisplayMode(int displayIndex, int modeIndex, out SDL.SDL_DisplayMode mode);

		// Token: 0x0600003F RID: 63
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDisplayUsableBounds(int displayIndex, out SDL.SDL_Rect rect);

		// Token: 0x06000040 RID: 64
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumDisplayModes(int displayIndex);

		// Token: 0x06000041 RID: 65
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumVideoDisplays();

		// Token: 0x06000042 RID: 66
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumVideoDrivers();

		// Token: 0x06000043 RID: 67
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetVideoDriver(int index);

		// Token: 0x06000044 RID: 68
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern float SDL_GetWindowBrightness(IntPtr window);

		// Token: 0x06000045 RID: 69
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowOpacity(IntPtr window, float opacity);

		// Token: 0x06000046 RID: 70
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowOpacity(IntPtr window, out float out_opacity);

		// Token: 0x06000047 RID: 71
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowModalFor(IntPtr modal_window, IntPtr parent_window);

		// Token: 0x06000048 RID: 72
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowInputFocus(IntPtr window);

		// Token: 0x06000049 RID: 73
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetWindowData(IntPtr window, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string name);

		// Token: 0x0600004A RID: 74
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowDisplayIndex(IntPtr window);

		// Token: 0x0600004B RID: 75
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowDisplayMode(IntPtr window, out SDL.SDL_DisplayMode mode);

		// Token: 0x0600004C RID: 76
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetWindowFlags(IntPtr window);

		// Token: 0x0600004D RID: 77
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetWindowFromID(uint id);

		// Token: 0x0600004E RID: 78
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowGammaRamp(IntPtr window, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] [Out] ushort[] red, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] [Out] ushort[] green, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] [Out] ushort[] blue);

		// Token: 0x0600004F RID: 79
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_GetWindowGrab(IntPtr window);

		// Token: 0x06000050 RID: 80
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetWindowID(IntPtr window);

		// Token: 0x06000051 RID: 81
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetWindowPixelFormat(IntPtr window);

		// Token: 0x06000052 RID: 82
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetWindowMaximumSize(IntPtr window, out int max_w, out int max_h);

		// Token: 0x06000053 RID: 83
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetWindowMinimumSize(IntPtr window, out int min_w, out int min_h);

		// Token: 0x06000054 RID: 84
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetWindowPosition(IntPtr window, out int x, out int y);

		// Token: 0x06000055 RID: 85
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetWindowSize(IntPtr window, out int w, out int h);

		// Token: 0x06000056 RID: 86
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetWindowSurface(IntPtr window);

		// Token: 0x06000057 RID: 87
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetWindowTitle(IntPtr window);

		// Token: 0x06000058 RID: 88
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_BindTexture(IntPtr texture, out float texw, out float texh);

		// Token: 0x06000059 RID: 89
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GL_CreateContext(IntPtr window);

		// Token: 0x0600005A RID: 90
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_DeleteContext(IntPtr context);

		// Token: 0x0600005B RID: 91
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GL_GetProcAddress([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string proc);

		// Token: 0x0600005C RID: 92
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_GL_ExtensionSupported([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string extension);

		// Token: 0x0600005D RID: 93
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_ResetAttributes();

		// Token: 0x0600005E RID: 94
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_GetAttribute(SDL.SDL_GLattr attr, out int value);

		// Token: 0x0600005F RID: 95
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_GetSwapInterval();

		// Token: 0x06000060 RID: 96
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_MakeCurrent(IntPtr window, IntPtr context);

		// Token: 0x06000061 RID: 97
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GL_GetCurrentWindow();

		// Token: 0x06000062 RID: 98
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GL_GetCurrentContext();

		// Token: 0x06000063 RID: 99
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_GetDrawableSize(IntPtr window, out int w, out int h);

		// Token: 0x06000064 RID: 100
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_SetAttribute(SDL.SDL_GLattr attr, int value);

		// Token: 0x06000065 RID: 101
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_SetSwapInterval(int interval);

		// Token: 0x06000066 RID: 102
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_SwapWindow(IntPtr window);

		// Token: 0x06000067 RID: 103
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_UnbindTexture(IntPtr texture);

		// Token: 0x06000068 RID: 104
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_HideWindow(IntPtr window);

		// Token: 0x06000069 RID: 105
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_IsScreenSaverEnabled();

		// Token: 0x0600006A RID: 106
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MaximizeWindow(IntPtr window);

		// Token: 0x0600006B RID: 107
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MinimizeWindow(IntPtr window);

		// Token: 0x0600006C RID: 108
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RaiseWindow(IntPtr window);

		// Token: 0x0600006D RID: 109
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RestoreWindow(IntPtr window);

		// Token: 0x0600006E RID: 110
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowBrightness(IntPtr window, float brightness);

		// Token: 0x0600006F RID: 111
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_SetWindowData(IntPtr window, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string name, IntPtr userdata);

		// Token: 0x06000070 RID: 112
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowDisplayMode(IntPtr window, ref SDL.SDL_DisplayMode mode);

		// Token: 0x06000071 RID: 113
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowFullscreen(IntPtr window, uint flags);

		// Token: 0x06000072 RID: 114
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowGammaRamp(IntPtr window, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] [In] ushort[] red, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] [In] ushort[] green, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] [In] ushort[] blue);

		// Token: 0x06000073 RID: 115
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowGrab(IntPtr window, SDL.SDL_bool grabbed);

		// Token: 0x06000074 RID: 116
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowIcon(IntPtr window, IntPtr icon);

		// Token: 0x06000075 RID: 117
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowMaximumSize(IntPtr window, int max_w, int max_h);

		// Token: 0x06000076 RID: 118
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowMinimumSize(IntPtr window, int min_w, int min_h);

		// Token: 0x06000077 RID: 119
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowPosition(IntPtr window, int x, int y);

		// Token: 0x06000078 RID: 120
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowSize(IntPtr window, int w, int h);

		// Token: 0x06000079 RID: 121
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowBordered(IntPtr window, SDL.SDL_bool bordered);

		// Token: 0x0600007A RID: 122
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom, out int right);

		// Token: 0x0600007B RID: 123
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowResizable(IntPtr window, SDL.SDL_bool resizable);

		// Token: 0x0600007C RID: 124
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowTitle(IntPtr window, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string title);

		// Token: 0x0600007D RID: 125
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_ShowWindow(IntPtr window);

		// Token: 0x0600007E RID: 126
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateWindowSurface(IntPtr window);

		// Token: 0x0600007F RID: 127
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateWindowSurfaceRects(IntPtr window, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] [In] SDL.SDL_Rect[] rects, int numrects);

		// Token: 0x06000080 RID: 128
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_VideoInit([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string driver_name);

		// Token: 0x06000081 RID: 129
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_VideoQuit();

		// Token: 0x06000082 RID: 130
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowHitTest(IntPtr window, SDL.SDL_HitTest callback, IntPtr callback_data);

		// Token: 0x06000083 RID: 131
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetGrabbedWindow();

		// Token: 0x06000084 RID: 132
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_BlendMode SDL_ComposeCustomBlendMode(SDL.SDL_BlendFactor srcColorFactor, SDL.SDL_BlendFactor dstColorFactor, SDL.SDL_BlendOperation colorOperation, SDL.SDL_BlendFactor srcAlphaFactor, SDL.SDL_BlendFactor dstAlphaFactor, SDL.SDL_BlendOperation alphaOperation);

		// Token: 0x06000085 RID: 133
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_Vulkan_LoadLibrary([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string path);

		// Token: 0x06000086 RID: 134
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_Vulkan_GetVkGetInstanceProcAddr();

		// Token: 0x06000087 RID: 135
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Vulkan_UnloadLibrary();

		// Token: 0x06000088 RID: 136
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_Vulkan_GetInstanceExtensions(IntPtr window, out uint pCount, IntPtr[] pNames);

		// Token: 0x06000089 RID: 137
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_Vulkan_CreateSurface(IntPtr window, IntPtr instance, out IntPtr surface);

		// Token: 0x0600008A RID: 138
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Vulkan_GetDrawableSize(IntPtr window, out int w, out int h);

		// Token: 0x0600008B RID: 139
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRenderer(IntPtr window, int index, SDL.SDL_RendererFlags flags);

		// Token: 0x0600008C RID: 140
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);

		// Token: 0x0600008D RID: 141
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateTexture(IntPtr renderer, uint format, int access, int w, int h);

		// Token: 0x0600008E RID: 142
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface);

		// Token: 0x0600008F RID: 143
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DestroyRenderer(IntPtr renderer);

		// Token: 0x06000090 RID: 144
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DestroyTexture(IntPtr texture);

		// Token: 0x06000091 RID: 145
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumRenderDrivers();

		// Token: 0x06000092 RID: 146
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRenderDrawBlendMode(IntPtr renderer, out SDL.SDL_BlendMode blendMode);

		// Token: 0x06000093 RID: 147
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

		// Token: 0x06000094 RID: 148
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRenderDriverInfo(int index, out SDL.SDL_RendererInfo info);

		// Token: 0x06000095 RID: 149
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetRenderer(IntPtr window);

		// Token: 0x06000096 RID: 150
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRendererInfo(IntPtr renderer, out SDL.SDL_RendererInfo info);

		// Token: 0x06000097 RID: 151
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRendererOutputSize(IntPtr renderer, out int w, out int h);

		// Token: 0x06000098 RID: 152
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetTextureAlphaMod(IntPtr texture, out byte alpha);

		// Token: 0x06000099 RID: 153
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetTextureBlendMode(IntPtr texture, out SDL.SDL_BlendMode blendMode);

		// Token: 0x0600009A RID: 154
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b);

		// Token: 0x0600009B RID: 155
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LockTexture(IntPtr texture, ref SDL.SDL_Rect rect, out IntPtr pixels, out int pitch);

		// Token: 0x0600009C RID: 156
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LockTexture(IntPtr texture, IntPtr rect, out IntPtr pixels, out int pitch);

		// Token: 0x0600009D RID: 157
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_QueryTexture(IntPtr texture, out uint format, out int access, out int w, out int h);

		// Token: 0x0600009E RID: 158
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderClear(IntPtr renderer);

		// Token: 0x0600009F RID: 159
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, ref SDL.SDL_Rect srcrect, ref SDL.SDL_Rect dstrect);

		// Token: 0x060000A0 RID: 160
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, IntPtr srcrect, ref SDL.SDL_Rect dstrect);

		// Token: 0x060000A1 RID: 161
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, ref SDL.SDL_Rect srcrect, IntPtr dstrect);

		// Token: 0x060000A2 RID: 162
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, IntPtr srcrect, IntPtr dstrect);

		// Token: 0x060000A3 RID: 163
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL.SDL_Rect srcrect, ref SDL.SDL_Rect dstrect, double angle, ref SDL.SDL_Point center, SDL.SDL_RendererFlip flip);

		// Token: 0x060000A4 RID: 164
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcrect, ref SDL.SDL_Rect dstrect, double angle, ref SDL.SDL_Point center, SDL.SDL_RendererFlip flip);

		// Token: 0x060000A5 RID: 165
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL.SDL_Rect srcrect, IntPtr dstrect, double angle, ref SDL.SDL_Point center, SDL.SDL_RendererFlip flip);

		// Token: 0x060000A6 RID: 166
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL.SDL_Rect srcrect, ref SDL.SDL_Rect dstrect, double angle, IntPtr center, SDL.SDL_RendererFlip flip);

		// Token: 0x060000A7 RID: 167
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcrect, IntPtr dstrect, double angle, ref SDL.SDL_Point center, SDL.SDL_RendererFlip flip);

		// Token: 0x060000A8 RID: 168
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcrect, ref SDL.SDL_Rect dstrect, double angle, IntPtr center, SDL.SDL_RendererFlip flip);

		// Token: 0x060000A9 RID: 169
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL.SDL_Rect srcrect, IntPtr dstrect, double angle, IntPtr center, SDL.SDL_RendererFlip flip);

		// Token: 0x060000AA RID: 170
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcrect, IntPtr dstrect, double angle, IntPtr center, SDL.SDL_RendererFlip flip);

		// Token: 0x060000AB RID: 171
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawLine(IntPtr renderer, int x1, int y1, int x2, int y2);

		// Token: 0x060000AC RID: 172
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawLines(IntPtr renderer, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] [In] SDL.SDL_Point[] points, int count);

		// Token: 0x060000AD RID: 173
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawPoint(IntPtr renderer, int x, int y);

		// Token: 0x060000AE RID: 174
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawPoints(IntPtr renderer, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] [In] SDL.SDL_Point[] points, int count);

		// Token: 0x060000AF RID: 175
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRect(IntPtr renderer, ref SDL.SDL_Rect rect);

		// Token: 0x060000B0 RID: 176
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRect(IntPtr renderer, IntPtr rect);

		// Token: 0x060000B1 RID: 177
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRects(IntPtr renderer, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] [In] SDL.SDL_Rect[] rects, int count);

		// Token: 0x060000B2 RID: 178
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRect(IntPtr renderer, ref SDL.SDL_Rect rect);

		// Token: 0x060000B3 RID: 179
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRect(IntPtr renderer, IntPtr rect);

		// Token: 0x060000B4 RID: 180
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRects(IntPtr renderer, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] [In] SDL.SDL_Rect[] rects, int count);

		// Token: 0x060000B5 RID: 181
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderGetClipRect(IntPtr renderer, out SDL.SDL_Rect rect);

		// Token: 0x060000B6 RID: 182
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderGetLogicalSize(IntPtr renderer, out int w, out int h);

		// Token: 0x060000B7 RID: 183
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderGetScale(IntPtr renderer, out float scaleX, out float scaleY);

		// Token: 0x060000B8 RID: 184
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderGetViewport(IntPtr renderer, out SDL.SDL_Rect rect);

		// Token: 0x060000B9 RID: 185
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderPresent(IntPtr renderer);

		// Token: 0x060000BA RID: 186
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderReadPixels(IntPtr renderer, ref SDL.SDL_Rect rect, uint format, IntPtr pixels, int pitch);

		// Token: 0x060000BB RID: 187
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetClipRect(IntPtr renderer, ref SDL.SDL_Rect rect);

		// Token: 0x060000BC RID: 188
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetClipRect(IntPtr renderer, IntPtr rect);

		// Token: 0x060000BD RID: 189
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetLogicalSize(IntPtr renderer, int w, int h);

		// Token: 0x060000BE RID: 190
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetScale(IntPtr renderer, float scaleX, float scaleY);

		// Token: 0x060000BF RID: 191
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetIntegerScale(IntPtr renderer, SDL.SDL_bool enable);

		// Token: 0x060000C0 RID: 192
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetViewport(IntPtr renderer, ref SDL.SDL_Rect rect);

		// Token: 0x060000C1 RID: 193
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetRenderDrawBlendMode(IntPtr renderer, SDL.SDL_BlendMode blendMode);

		// Token: 0x060000C2 RID: 194
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);

		// Token: 0x060000C3 RID: 195
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetRenderTarget(IntPtr renderer, IntPtr texture);

		// Token: 0x060000C4 RID: 196
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetTextureAlphaMod(IntPtr texture, byte alpha);

		// Token: 0x060000C5 RID: 197
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetTextureBlendMode(IntPtr texture, SDL.SDL_BlendMode blendMode);

		// Token: 0x060000C6 RID: 198
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b);

		// Token: 0x060000C7 RID: 199
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockTexture(IntPtr texture);

		// Token: 0x060000C8 RID: 200
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateTexture(IntPtr texture, ref SDL.SDL_Rect rect, IntPtr pixels, int pitch);

		// Token: 0x060000C9 RID: 201
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateTexture(IntPtr texture, IntPtr rect, IntPtr pixels, int pitch);

		// Token: 0x060000CA RID: 202
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_RenderTargetSupported(IntPtr renderer);

		// Token: 0x060000CB RID: 203
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);

		// Token: 0x060000CC RID: 204
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_RenderIsClipEnabled(IntPtr renderer);

		// Token: 0x060000CD RID: 205 RVA: 0x0000231C File Offset: 0x0000051C
		public static uint SDL_DEFINE_PIXELFOURCC(byte A, byte B, byte C, byte D)
		{
			return SDL.SDL_FOURCC(A, B, C, D);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00002338 File Offset: 0x00000538
		public static uint SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM type, SDL.SDL_PIXELORDER_ENUM order, SDL.SDL_PACKEDLAYOUT_ENUM layout, byte bits, byte bytes)
		{
			return (uint)(268435456 | (int)((byte)type) << 24 | (int)((byte)order) << 20 | (int)((byte)layout) << 16 | (int)bits << 8 | (int)bytes);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00002368 File Offset: 0x00000568
		public static byte SDL_PIXELFLAG(uint X)
		{
			return (byte)(X >> 28 & 15U);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00002384 File Offset: 0x00000584
		public static byte SDL_PIXELTYPE(uint X)
		{
			return (byte)(X >> 24 & 15U);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000023A0 File Offset: 0x000005A0
		public static byte SDL_PIXELORDER(uint X)
		{
			return (byte)(X >> 20 & 15U);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000023BC File Offset: 0x000005BC
		public static byte SDL_PIXELLAYOUT(uint X)
		{
			return (byte)(X >> 16 & 15U);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000023D8 File Offset: 0x000005D8
		public static byte SDL_BITSPERPIXEL(uint X)
		{
			return (byte)(X >> 8 & 255U);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000023F4 File Offset: 0x000005F4
		public static byte SDL_BYTESPERPIXEL(uint X)
		{
			bool flag = SDL.SDL_ISPIXELFORMAT_FOURCC(X);
			byte result;
			if (flag)
			{
				bool flag2 = X == SDL.SDL_PIXELFORMAT_YUY2 || X == SDL.SDL_PIXELFORMAT_UYVY || X == SDL.SDL_PIXELFORMAT_YVYU;
				if (flag2)
				{
					result = 2;
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				result = (byte)(X & 255U);
			}
			return result;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00002444 File Offset: 0x00000644
		public static bool SDL_ISPIXELFORMAT_INDEXED(uint format)
		{
			bool flag = SDL.SDL_ISPIXELFORMAT_FOURCC(format);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				SDL.SDL_PIXELTYPE_ENUM sdl_PIXELTYPE_ENUM = (SDL.SDL_PIXELTYPE_ENUM)SDL.SDL_PIXELTYPE(format);
				result = (sdl_PIXELTYPE_ENUM == SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1 || sdl_PIXELTYPE_ENUM == SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4 || sdl_PIXELTYPE_ENUM == SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX8);
			}
			return result;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000247C File Offset: 0x0000067C
		public static bool SDL_ISPIXELFORMAT_ALPHA(uint format)
		{
			bool flag = SDL.SDL_ISPIXELFORMAT_FOURCC(format);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				SDL.SDL_PIXELORDER_ENUM sdl_PIXELORDER_ENUM = (SDL.SDL_PIXELORDER_ENUM)SDL.SDL_PIXELORDER(format);
				result = (sdl_PIXELORDER_ENUM == SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB || sdl_PIXELORDER_ENUM == SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA || sdl_PIXELORDER_ENUM == SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR || sdl_PIXELORDER_ENUM == SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA);
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000024B8 File Offset: 0x000006B8
		public static bool SDL_ISPIXELFORMAT_FOURCC(uint format)
		{
			return format == 0U && SDL.SDL_PIXELFLAG(format) != 1;
		}

		// Token: 0x060000D8 RID: 216
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_AllocFormat(uint pixel_format);

		// Token: 0x060000D9 RID: 217
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_AllocPalette(int ncolors);

		// Token: 0x060000DA RID: 218
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_CalculateGammaRamp(float gamma, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] [Out] ushort[] ramp);

		// Token: 0x060000DB RID: 219
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeFormat(IntPtr format);

		// Token: 0x060000DC RID: 220
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreePalette(IntPtr palette);

		// Token: 0x060000DD RID: 221
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetPixelFormatName(uint format);

		// Token: 0x060000DE RID: 222
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetRGB(uint pixel, IntPtr format, out byte r, out byte g, out byte b);

		// Token: 0x060000DF RID: 223
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetRGBA(uint pixel, IntPtr format, out byte r, out byte g, out byte b, out byte a);

		// Token: 0x060000E0 RID: 224
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_MapRGB(IntPtr format, byte r, byte g, byte b);

		// Token: 0x060000E1 RID: 225
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_MapRGBA(IntPtr format, byte r, byte g, byte b, byte a);

		// Token: 0x060000E2 RID: 226
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_MasksToPixelFormatEnum(int bpp, uint Rmask, uint Gmask, uint Bmask, uint Amask);

		// Token: 0x060000E3 RID: 227
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_PixelFormatEnumToMasks(uint format, out int bpp, out uint Rmask, out uint Gmask, out uint Bmask, out uint Amask);

		// Token: 0x060000E4 RID: 228
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetPaletteColors(IntPtr palette, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)] [In] SDL.SDL_Color[] colors, int firstcolor, int ncolors);

		// Token: 0x060000E5 RID: 229
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetPixelFormatPalette(IntPtr format, IntPtr palette);

		// Token: 0x060000E6 RID: 230
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_PointInRect(ref SDL.SDL_Point p, ref SDL.SDL_Rect r);

		// Token: 0x060000E7 RID: 231
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_EnclosePoints([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 1)] [In] SDL.SDL_Point[] points, int count, ref SDL.SDL_Rect clip, out SDL.SDL_Rect result);

		// Token: 0x060000E8 RID: 232
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_HasIntersection(ref SDL.SDL_Rect A, ref SDL.SDL_Rect B);

		// Token: 0x060000E9 RID: 233
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_IntersectRect(ref SDL.SDL_Rect A, ref SDL.SDL_Rect B, out SDL.SDL_Rect result);

		// Token: 0x060000EA RID: 234
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_IntersectRectAndLine(ref SDL.SDL_Rect rect, ref int X1, ref int Y1, ref int X2, ref int Y2);

		// Token: 0x060000EB RID: 235
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_RectEmpty(ref SDL.SDL_Rect rect);

		// Token: 0x060000EC RID: 236
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_RectEquals(ref SDL.SDL_Rect A, ref SDL.SDL_Rect B);

		// Token: 0x060000ED RID: 237
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnionRect(ref SDL.SDL_Rect A, ref SDL.SDL_Rect B, out SDL.SDL_Rect result);

		// Token: 0x060000EE RID: 238 RVA: 0x000024DC File Offset: 0x000006DC
		public static bool SDL_MUSTLOCK(IntPtr surface)
		{
			SDL.SDL_Surface sdl_Surface = (SDL.SDL_Surface)Marshal.PtrToStructure(surface, typeof(SDL.SDL_Surface));
			return (sdl_Surface.flags & 2U) > 0U;
		}

		// Token: 0x060000EF RID: 239
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
		public static extern int SDL_BlitSurface(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x060000F0 RID: 240
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
		public static extern int SDL_BlitSurface(IntPtr src, IntPtr srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x060000F1 RID: 241
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
		public static extern int SDL_BlitSurface(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, IntPtr dstrect);

		// Token: 0x060000F2 RID: 242
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
		public static extern int SDL_BlitSurface(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect);

		// Token: 0x060000F3 RID: 243
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
		public static extern int SDL_BlitScaled(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x060000F4 RID: 244
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
		public static extern int SDL_BlitScaled(IntPtr src, IntPtr srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x060000F5 RID: 245
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
		public static extern int SDL_BlitScaled(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, IntPtr dstrect);

		// Token: 0x060000F6 RID: 246
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
		public static extern int SDL_BlitScaled(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect);

		// Token: 0x060000F7 RID: 247
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_ConvertPixels(int width, int height, uint src_format, IntPtr src, int src_pitch, uint dst_format, IntPtr dst, int dst_pitch);

		// Token: 0x060000F8 RID: 248
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_ConvertSurface(IntPtr src, IntPtr fmt, uint flags);

		// Token: 0x060000F9 RID: 249
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_ConvertSurfaceFormat(IntPtr src, uint pixel_format, uint flags);

		// Token: 0x060000FA RID: 250
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRGBSurface(uint flags, int width, int height, int depth, uint Rmask, uint Gmask, uint Bmask, uint Amask);

		// Token: 0x060000FB RID: 251
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

		// Token: 0x060000FC RID: 252
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRGBSurfaceWithFormat(uint flags, int width, int height, int depth, uint format);

		// Token: 0x060000FD RID: 253
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRGBSurfaceWithFormatFrom(IntPtr pixels, int width, int height, int depth, int pitch, uint format);

		// Token: 0x060000FE RID: 254
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_FillRect(IntPtr dst, ref SDL.SDL_Rect rect, uint color);

		// Token: 0x060000FF RID: 255
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_FillRect(IntPtr dst, IntPtr rect, uint color);

		// Token: 0x06000100 RID: 256
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_FillRects(IntPtr dst, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] [In] SDL.SDL_Rect[] rects, int count, uint color);

		// Token: 0x06000101 RID: 257
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeSurface(IntPtr surface);

		// Token: 0x06000102 RID: 258
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetClipRect(IntPtr surface, out SDL.SDL_Rect rect);

		// Token: 0x06000103 RID: 259
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetColorKey(IntPtr surface, out uint key);

		// Token: 0x06000104 RID: 260
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetSurfaceAlphaMod(IntPtr surface, out byte alpha);

		// Token: 0x06000105 RID: 261
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetSurfaceBlendMode(IntPtr surface, out SDL.SDL_BlendMode blendMode);

		// Token: 0x06000106 RID: 262
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetSurfaceColorMod(IntPtr surface, out byte r, out byte g, out byte b);

		// Token: 0x06000107 RID: 263
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadBMP_RW")]
		private static extern IntPtr INTERNAL_SDL_LoadBMP_RW(IntPtr src, int freesrc);

		// Token: 0x06000108 RID: 264 RVA: 0x00002510 File Offset: 0x00000710
		public static IntPtr SDL_LoadBMP(string file)
		{
			IntPtr src = SDL.INTERNAL_SDL_RWFromFile(file, "rb");
			return SDL.INTERNAL_SDL_LoadBMP_RW(src, 1);
		}

		// Token: 0x06000109 RID: 265
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LockSurface(IntPtr surface);

		// Token: 0x0600010A RID: 266
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LowerBlit(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x0600010B RID: 267
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LowerBlitScaled(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x0600010C RID: 268
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SaveBMP_RW")]
		private static extern int INTERNAL_SDL_SaveBMP_RW(IntPtr surface, IntPtr src, int freesrc);

		// Token: 0x0600010D RID: 269 RVA: 0x00002538 File Offset: 0x00000738
		public static int SDL_SaveBMP(IntPtr surface, string file)
		{
			IntPtr src = SDL.INTERNAL_SDL_RWFromFile(file, "wb");
			return SDL.INTERNAL_SDL_SaveBMP_RW(surface, src, 1);
		}

		// Token: 0x0600010E RID: 270
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_SetClipRect(IntPtr surface, ref SDL.SDL_Rect rect);

		// Token: 0x0600010F RID: 271
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetColorKey(IntPtr surface, int flag, uint key);

		// Token: 0x06000110 RID: 272
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfaceAlphaMod(IntPtr surface, byte alpha);

		// Token: 0x06000111 RID: 273
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfaceBlendMode(IntPtr surface, SDL.SDL_BlendMode blendMode);

		// Token: 0x06000112 RID: 274
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b);

		// Token: 0x06000113 RID: 275
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfacePalette(IntPtr surface, IntPtr palette);

		// Token: 0x06000114 RID: 276
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfaceRLE(IntPtr surface, int flag);

		// Token: 0x06000115 RID: 277
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SoftStretch(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x06000116 RID: 278
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockSurface(IntPtr surface);

		// Token: 0x06000117 RID: 279
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpperBlit(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x06000118 RID: 280
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpperBlitScaled(IntPtr src, ref SDL.SDL_Rect srcrect, IntPtr dst, ref SDL.SDL_Rect dstrect);

		// Token: 0x06000119 RID: 281
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_DuplicateSurface(IntPtr surface);

		// Token: 0x0600011A RID: 282
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_HasClipboardText();

		// Token: 0x0600011B RID: 283
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetClipboardText();

		// Token: 0x0600011C RID: 284
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetClipboardText([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string text);

		// Token: 0x0600011D RID: 285
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_PumpEvents();

		// Token: 0x0600011E RID: 286
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_PeepEvents([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 1)] [Out] SDL.SDL_Event[] events, int numevents, SDL.SDL_eventaction action, SDL.SDL_EventType minType, SDL.SDL_EventType maxType);

		// Token: 0x0600011F RID: 287
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_HasEvent(SDL.SDL_EventType type);

		// Token: 0x06000120 RID: 288
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_HasEvents(SDL.SDL_EventType minType, SDL.SDL_EventType maxType);

		// Token: 0x06000121 RID: 289
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FlushEvent(SDL.SDL_EventType type);

		// Token: 0x06000122 RID: 290
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FlushEvents(SDL.SDL_EventType min, SDL.SDL_EventType max);

		// Token: 0x06000123 RID: 291
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_PollEvent(out SDL.SDL_Event _event);

		// Token: 0x06000124 RID: 292
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_WaitEvent(out SDL.SDL_Event _event);

		// Token: 0x06000125 RID: 293
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_WaitEventTimeout(out SDL.SDL_Event _event, int timeout);

		// Token: 0x06000126 RID: 294
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_PushEvent(ref SDL.SDL_Event _event);

		// Token: 0x06000127 RID: 295
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetEventFilter(SDL.SDL_EventFilter filter, IntPtr userdata);

		// Token: 0x06000128 RID: 296
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_GetEventFilter(out SDL.SDL_EventFilter filter, out IntPtr userdata);

		// Token: 0x06000129 RID: 297
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_AddEventWatch(SDL.SDL_EventFilter filter, IntPtr userdata);

		// Token: 0x0600012A RID: 298
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DelEventWatch(SDL.SDL_EventFilter filter, IntPtr userdata);

		// Token: 0x0600012B RID: 299
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FilterEvents(SDL.SDL_EventFilter filter, IntPtr userdata);

		// Token: 0x0600012C RID: 300
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_EventState(SDL.SDL_EventType type, int state);

		// Token: 0x0600012D RID: 301 RVA: 0x00002560 File Offset: 0x00000760
		public static byte SDL_GetEventState(SDL.SDL_EventType type)
		{
			return SDL.SDL_EventState(type, -1);
		}

		// Token: 0x0600012E RID: 302
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_RegisterEvents(int numevents);

		// Token: 0x0600012F RID: 303 RVA: 0x0000257C File Offset: 0x0000077C
		public static SDL.SDL_Keycode SDL_SCANCODE_TO_KEYCODE(SDL.SDL_Scancode X)
		{
			return (SDL.SDL_Keycode)(X | (SDL.SDL_Scancode)1073741824);
		}

		// Token: 0x06000130 RID: 304
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetKeyboardFocus();

		// Token: 0x06000131 RID: 305
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetKeyboardState(out int numkeys);

		// Token: 0x06000132 RID: 306
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_Keymod SDL_GetModState();

		// Token: 0x06000133 RID: 307
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetModState(SDL.SDL_Keymod modstate);

		// Token: 0x06000134 RID: 308
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_Keycode SDL_GetKeyFromScancode(SDL.SDL_Scancode scancode);

		// Token: 0x06000135 RID: 309
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_Scancode SDL_GetScancodeFromKey(SDL.SDL_Keycode key);

		// Token: 0x06000136 RID: 310
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetScancodeName(SDL.SDL_Scancode scancode);

		// Token: 0x06000137 RID: 311
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_Scancode SDL_GetScancodeFromName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string name);

		// Token: 0x06000138 RID: 312
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetKeyName(SDL.SDL_Keycode key);

		// Token: 0x06000139 RID: 313
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_Keycode SDL_GetKeyFromName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string name);

		// Token: 0x0600013A RID: 314
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_StartTextInput();

		// Token: 0x0600013B RID: 315
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_IsTextInputActive();

		// Token: 0x0600013C RID: 316
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_StopTextInput();

		// Token: 0x0600013D RID: 317
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetTextInputRect(ref SDL.SDL_Rect rect);

		// Token: 0x0600013E RID: 318
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_HasScreenKeyboardSupport();

		// Token: 0x0600013F RID: 319
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_IsScreenKeyboardShown(IntPtr window);

		// Token: 0x06000140 RID: 320
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetMouseFocus();

		// Token: 0x06000141 RID: 321
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetMouseState(out int x, out int y);

		// Token: 0x06000142 RID: 322
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetMouseState(IntPtr x, out int y);

		// Token: 0x06000143 RID: 323
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetMouseState(out int x, IntPtr y);

		// Token: 0x06000144 RID: 324
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetMouseState(IntPtr x, IntPtr y);

		// Token: 0x06000145 RID: 325
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetGlobalMouseState(out int x, out int y);

		// Token: 0x06000146 RID: 326
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetGlobalMouseState(IntPtr x, out int y);

		// Token: 0x06000147 RID: 327
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetGlobalMouseState(out int x, IntPtr y);

		// Token: 0x06000148 RID: 328
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetGlobalMouseState(IntPtr x, IntPtr y);

		// Token: 0x06000149 RID: 329
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetRelativeMouseState(out int x, out int y);

		// Token: 0x0600014A RID: 330
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);

		// Token: 0x0600014B RID: 331
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_WarpMouseGlobal(int x, int y);

		// Token: 0x0600014C RID: 332
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetRelativeMouseMode(SDL.SDL_bool enabled);

		// Token: 0x0600014D RID: 333
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_CaptureMouse(SDL.SDL_bool enabled);

		// Token: 0x0600014E RID: 334
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_GetRelativeMouseMode();

		// Token: 0x0600014F RID: 335
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateCursor(IntPtr data, IntPtr mask, int w, int h, int hot_x, int hot_y);

		// Token: 0x06000150 RID: 336
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateColorCursor(IntPtr surface, int hot_x, int hot_y);

		// Token: 0x06000151 RID: 337
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateSystemCursor(SDL.SDL_SystemCursor id);

		// Token: 0x06000152 RID: 338
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetCursor(IntPtr cursor);

		// Token: 0x06000153 RID: 339
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetCursor();

		// Token: 0x06000154 RID: 340
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeCursor(IntPtr cursor);

		// Token: 0x06000155 RID: 341
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_ShowCursor(int toggle);

		// Token: 0x06000156 RID: 342 RVA: 0x00002598 File Offset: 0x00000798
		public static uint SDL_BUTTON(uint X)
		{
			return 1U << (int)(X - 1U);
		}

		// Token: 0x06000157 RID: 343
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumTouchDevices();

		// Token: 0x06000158 RID: 344
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern long SDL_GetTouchDevice(int index);

		// Token: 0x06000159 RID: 345
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumTouchFingers(long touchID);

		// Token: 0x0600015A RID: 346
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetTouchFinger(long touchID, int index);

		// Token: 0x0600015B RID: 347
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_JoystickClose(IntPtr joystick);

		// Token: 0x0600015C RID: 348
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickEventState(int state);

		// Token: 0x0600015D RID: 349
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern short SDL_JoystickGetAxis(IntPtr joystick, int axis);

		// Token: 0x0600015E RID: 350
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_JoystickGetAxisInitialState(IntPtr joystick, int axis, out ushort state);

		// Token: 0x0600015F RID: 351
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickGetBall(IntPtr joystick, int ball, out int dx, out int dy);

		// Token: 0x06000160 RID: 352
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_JoystickGetButton(IntPtr joystick, int button);

		// Token: 0x06000161 RID: 353
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_JoystickGetHat(IntPtr joystick, int hat);

		// Token: 0x06000162 RID: 354
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_JoystickName(IntPtr joystick);

		// Token: 0x06000163 RID: 355
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_JoystickNameForIndex(int device_index);

		// Token: 0x06000164 RID: 356
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickNumAxes(IntPtr joystick);

		// Token: 0x06000165 RID: 357
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickNumBalls(IntPtr joystick);

		// Token: 0x06000166 RID: 358
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickNumButtons(IntPtr joystick);

		// Token: 0x06000167 RID: 359
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickNumHats(IntPtr joystick);

		// Token: 0x06000168 RID: 360
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_JoystickOpen(int device_index);

		// Token: 0x06000169 RID: 361
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickOpened(int device_index);

		// Token: 0x0600016A RID: 362
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_JoystickUpdate();

		// Token: 0x0600016B RID: 363
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_NumJoysticks();

		// Token: 0x0600016C RID: 364
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern Guid SDL_JoystickGetDeviceGUID(int device_index);

		// Token: 0x0600016D RID: 365
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern Guid SDL_JoystickGetGUID(IntPtr joystick);

		// Token: 0x0600016E RID: 366
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_JoystickGetGUIDString(Guid guid, byte[] pszGUID, int cbGUID);

		// Token: 0x0600016F RID: 367
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern Guid SDL_JoystickGetGUIDFromString([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string pchGUID);

		// Token: 0x06000170 RID: 368
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetDeviceVendor(int device_index);

		// Token: 0x06000171 RID: 369
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetDeviceProduct(int device_index);

		// Token: 0x06000172 RID: 370
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetDeviceProductVersion(int device_index);

		// Token: 0x06000173 RID: 371
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_JoystickType SDL_JoystickGetDeviceType(int device_index);

		// Token: 0x06000174 RID: 372
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickGetDeviceInstanceID(int device_index);

		// Token: 0x06000175 RID: 373
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetVendor(IntPtr joystick);

		// Token: 0x06000176 RID: 374
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetProduct(IntPtr joystick);

		// Token: 0x06000177 RID: 375
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetProductVersion(IntPtr joystick);

		// Token: 0x06000178 RID: 376
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_JoystickType SDL_JoystickGetType(IntPtr joystick);

		// Token: 0x06000179 RID: 377
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_JoystickGetAttached(IntPtr joystick);

		// Token: 0x0600017A RID: 378
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickInstanceID(IntPtr joystick);

		// Token: 0x0600017B RID: 379
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(IntPtr joystick);

		// Token: 0x0600017C RID: 380
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_JoystickFromInstanceID(int joyid);

		// Token: 0x0600017D RID: 381
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerAddMapping([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string mappingString);

		// Token: 0x0600017E RID: 382
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerNumMappings();

		// Token: 0x0600017F RID: 383
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)]
		public static extern string SDL_GameControllerMappingForIndex(int mapping_index);

		// Token: 0x06000180 RID: 384
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerAddMappingsFromRW")]
		private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW(IntPtr rw, int freerw);

		// Token: 0x06000181 RID: 385 RVA: 0x000025B4 File Offset: 0x000007B4
		public static int SDL_GameControllerAddMappingsFromFile(string file)
		{
			IntPtr rw = SDL.INTERNAL_SDL_RWFromFile(file, "rb");
			return SDL.INTERNAL_SDL_GameControllerAddMappingsFromRW(rw, 1);
		}

		// Token: 0x06000182 RID: 386
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GameControllerMappingForGUID(Guid guid);

		// Token: 0x06000183 RID: 387
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GameControllerMapping(IntPtr gamecontroller);

		// Token: 0x06000184 RID: 388
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_IsGameController(int joystick_index);

		// Token: 0x06000185 RID: 389
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GameControllerNameForIndex(int joystick_index);

		// Token: 0x06000186 RID: 390
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GameControllerOpen(int joystick_index);

		// Token: 0x06000187 RID: 391
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GameControllerName(IntPtr gamecontroller);

		// Token: 0x06000188 RID: 392
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_GameControllerGetVendor(IntPtr gamecontroller);

		// Token: 0x06000189 RID: 393
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_GameControllerGetProduct(IntPtr gamecontroller);

		// Token: 0x0600018A RID: 394
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_GameControllerGetProductVersion(IntPtr gamecontroller);

		// Token: 0x0600018B RID: 395
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_GameControllerGetAttached(IntPtr gamecontroller);

		// Token: 0x0600018C RID: 396
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GameControllerGetJoystick(IntPtr gamecontroller);

		// Token: 0x0600018D RID: 397
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerEventState(int state);

		// Token: 0x0600018E RID: 398
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GameControllerUpdate();

		// Token: 0x0600018F RID: 399
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_GameControllerAxis SDL_GameControllerGetAxisFromString([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string pchString);

		// Token: 0x06000190 RID: 400
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GameControllerGetStringForAxis(SDL.SDL_GameControllerAxis axis);

		// Token: 0x06000191 RID: 401
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(IntPtr gamecontroller, SDL.SDL_GameControllerAxis axis);

		// Token: 0x06000192 RID: 402
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern short SDL_GameControllerGetAxis(IntPtr gamecontroller, SDL.SDL_GameControllerAxis axis);

		// Token: 0x06000193 RID: 403
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_GameControllerButton SDL_GameControllerGetButtonFromString([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string pchString);

		// Token: 0x06000194 RID: 404
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GameControllerGetStringForButton(SDL.SDL_GameControllerButton button);

		// Token: 0x06000195 RID: 405
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(IntPtr gamecontroller, SDL.SDL_GameControllerButton button);

		// Token: 0x06000196 RID: 406
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_GameControllerGetButton(IntPtr gamecontroller, SDL.SDL_GameControllerButton button);

		// Token: 0x06000197 RID: 407
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GameControllerClose(IntPtr gamecontroller);

		// Token: 0x06000198 RID: 408
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GameControllerFromInstanceID(int joyid);

		// Token: 0x06000199 RID: 409
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_HapticClose(IntPtr haptic);

		// Token: 0x0600019A RID: 410
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_HapticDestroyEffect(IntPtr haptic, int effect);

		// Token: 0x0600019B RID: 411
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticEffectSupported(IntPtr haptic, ref SDL.SDL_HapticEffect effect);

		// Token: 0x0600019C RID: 412
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticGetEffectStatus(IntPtr haptic, int effect);

		// Token: 0x0600019D RID: 413
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticIndex(IntPtr haptic);

		// Token: 0x0600019E RID: 414
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_HapticName(int device_index);

		// Token: 0x0600019F RID: 415
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticNewEffect(IntPtr haptic, ref SDL.SDL_HapticEffect effect);

		// Token: 0x060001A0 RID: 416
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticNumAxes(IntPtr haptic);

		// Token: 0x060001A1 RID: 417
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticNumEffects(IntPtr haptic);

		// Token: 0x060001A2 RID: 418
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);

		// Token: 0x060001A3 RID: 419
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_HapticOpen(int device_index);

		// Token: 0x060001A4 RID: 420
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticOpened(int device_index);

		// Token: 0x060001A5 RID: 421
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_HapticOpenFromJoystick(IntPtr joystick);

		// Token: 0x060001A6 RID: 422
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_HapticOpenFromMouse();

		// Token: 0x060001A7 RID: 423
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticPause(IntPtr haptic);

		// Token: 0x060001A8 RID: 424
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_HapticQuery(IntPtr haptic);

		// Token: 0x060001A9 RID: 425
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRumbleInit(IntPtr haptic);

		// Token: 0x060001AA RID: 426
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRumblePlay(IntPtr haptic, float strength, uint length);

		// Token: 0x060001AB RID: 427
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRumbleStop(IntPtr haptic);

		// Token: 0x060001AC RID: 428
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRumbleSupported(IntPtr haptic);

		// Token: 0x060001AD RID: 429
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRunEffect(IntPtr haptic, int effect, uint iterations);

		// Token: 0x060001AE RID: 430
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticSetAutocenter(IntPtr haptic, int autocenter);

		// Token: 0x060001AF RID: 431
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticSetGain(IntPtr haptic, int gain);

		// Token: 0x060001B0 RID: 432
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticStopAll(IntPtr haptic);

		// Token: 0x060001B1 RID: 433
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticStopEffect(IntPtr haptic, int effect);

		// Token: 0x060001B2 RID: 434
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticUnpause(IntPtr haptic);

		// Token: 0x060001B3 RID: 435
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticUpdateEffect(IntPtr haptic, int effect, ref SDL.SDL_HapticEffect data);

		// Token: 0x060001B4 RID: 436
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickIsHaptic(IntPtr joystick);

		// Token: 0x060001B5 RID: 437
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_MouseIsHaptic();

		// Token: 0x060001B6 RID: 438
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_NumHaptics();

		// Token: 0x060001B7 RID: 439 RVA: 0x000025DC File Offset: 0x000007DC
		public static ushort SDL_AUDIO_BITSIZE(ushort x)
		{
			return x & 255;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000025F8 File Offset: 0x000007F8
		public static bool SDL_AUDIO_ISFLOAT(ushort x)
		{
			return (x & 256) > 0;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00002614 File Offset: 0x00000814
		public static bool SDL_AUDIO_ISBIGENDIAN(ushort x)
		{
			return (x & 4096) > 0;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00002630 File Offset: 0x00000830
		public static bool SDL_AUDIO_ISSIGNED(ushort x)
		{
			return (x & 32768) > 0;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000264C File Offset: 0x0000084C
		public static bool SDL_AUDIO_ISINT(ushort x)
		{
			return (x & 256) == 0;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00002668 File Offset: 0x00000868
		public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x)
		{
			return (x & 4096) == 0;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00002684 File Offset: 0x00000884
		public static bool SDL_AUDIO_ISUNSIGNED(ushort x)
		{
			return (x & 32768) == 0;
		}

		// Token: 0x060001BE RID: 446
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_AudioDeviceConnected(uint dev);

		// Token: 0x060001BF RID: 447
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_AudioInit([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string driver_name);

		// Token: 0x060001C0 RID: 448
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_AudioQuit();

		// Token: 0x060001C1 RID: 449
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_CloseAudio();

		// Token: 0x060001C2 RID: 450
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_CloseAudioDevice(uint dev);

		// Token: 0x060001C3 RID: 451
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeWAV(IntPtr audio_buf);

		// Token: 0x060001C4 RID: 452
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetAudioDeviceName(int index, int iscapture);

		// Token: 0x060001C5 RID: 453
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_AudioStatus SDL_GetAudioDeviceStatus(uint dev);

		// Token: 0x060001C6 RID: 454
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetAudioDriver(int index);

		// Token: 0x060001C7 RID: 455
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_AudioStatus SDL_GetAudioStatus();

		// Token: 0x060001C8 RID: 456
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string SDL_GetCurrentAudioDriver();

		// Token: 0x060001C9 RID: 457
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumAudioDevices(int iscapture);

		// Token: 0x060001CA RID: 458
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumAudioDrivers();

		// Token: 0x060001CB RID: 459
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadWAV_RW")]
		private static extern IntPtr INTERNAL_SDL_LoadWAV_RW(IntPtr src, int freesrc, ref SDL.SDL_AudioSpec spec, out IntPtr audio_buf, out uint audio_len);

		// Token: 0x060001CC RID: 460 RVA: 0x000026A0 File Offset: 0x000008A0
		public static SDL.SDL_AudioSpec SDL_LoadWAV(string file, ref SDL.SDL_AudioSpec spec, out IntPtr audio_buf, out uint audio_len)
		{
			IntPtr src = SDL.INTERNAL_SDL_RWFromFile(file, "rb");
			IntPtr ptr = SDL.INTERNAL_SDL_LoadWAV_RW(src, 1, ref spec, out audio_buf, out audio_len);
			return (SDL.SDL_AudioSpec)Marshal.PtrToStructure(ptr, typeof(SDL.SDL_AudioSpec));
		}

		// Token: 0x060001CD RID: 461
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LockAudio();

		// Token: 0x060001CE RID: 462
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LockAudioDevice(uint dev);

		// Token: 0x060001CF RID: 463
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MixAudio([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [Out] byte[] dst, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [In] byte[] src, uint len, int volume);

		// Token: 0x060001D0 RID: 464
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MixAudioFormat([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [Out] byte[] dst, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [In] byte[] src, ushort format, uint len, int volume);

		// Token: 0x060001D1 RID: 465
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_OpenAudio(ref SDL.SDL_AudioSpec desired, out SDL.SDL_AudioSpec obtained);

		// Token: 0x060001D2 RID: 466
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_OpenAudio(ref SDL.SDL_AudioSpec desired, IntPtr obtained);

		// Token: 0x060001D3 RID: 467
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_OpenAudioDevice([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string device, int iscapture, ref SDL.SDL_AudioSpec desired, out SDL.SDL_AudioSpec obtained, int allowed_changes);

		// Token: 0x060001D4 RID: 468
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_PauseAudio(int pause_on);

		// Token: 0x060001D5 RID: 469
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_PauseAudioDevice(uint dev, int pause_on);

		// Token: 0x060001D6 RID: 470
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockAudio();

		// Token: 0x060001D7 RID: 471
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockAudioDevice(uint dev);

		// Token: 0x060001D8 RID: 472
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_QueueAudio(uint dev, IntPtr data, uint len);

		// Token: 0x060001D9 RID: 473
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_DequeueAudio(uint dev, IntPtr data, uint len);

		// Token: 0x060001DA RID: 474
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetQueuedAudioSize(uint dev);

		// Token: 0x060001DB RID: 475
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_ClearQueuedAudio(uint dev);

		// Token: 0x060001DC RID: 476 RVA: 0x000026E0 File Offset: 0x000008E0
		public static bool SDL_TICKS_PASSED(uint A, uint B)
		{
			return B - A <= 0U;
		}

		// Token: 0x060001DD RID: 477
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Delay(uint ms);

		// Token: 0x060001DE RID: 478
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetTicks();

		// Token: 0x060001DF RID: 479
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong SDL_GetPerformanceCounter();

		// Token: 0x060001E0 RID: 480
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong SDL_GetPerformanceFrequency();

		// Token: 0x060001E1 RID: 481
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_AddTimer(uint interval, SDL.SDL_TimerCallback callback, IntPtr param);

		// Token: 0x060001E2 RID: 482
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_RemoveTimer(int id);

		// Token: 0x060001E3 RID: 483
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_bool SDL_GetWindowWMInfo(IntPtr window, ref SDL.SDL_SysWMinfo info);

		// Token: 0x060001E4 RID: 484
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)]
		public static extern string SDL_GetBasePath();

		// Token: 0x060001E5 RID: 485
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)]
		public static extern string SDL_GetPrefPath([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string org, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string app);

		// Token: 0x060001E6 RID: 486
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL.SDL_PowerState SDL_GetPowerInfo(out int secs, out int pct);

		// Token: 0x060001E7 RID: 487
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetCPUCount();

		// Token: 0x060001E8 RID: 488
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetSystemRAM();

		// Token: 0x04000001 RID: 1
		private const string nativeLibName = "SDL2.dll";

		// Token: 0x04000002 RID: 2
		public const uint SDL_INIT_TIMER = 1U;

		// Token: 0x04000003 RID: 3
		public const uint SDL_INIT_AUDIO = 16U;

		// Token: 0x04000004 RID: 4
		public const uint SDL_INIT_VIDEO = 32U;

		// Token: 0x04000005 RID: 5
		public const uint SDL_INIT_JOYSTICK = 512U;

		// Token: 0x04000006 RID: 6
		public const uint SDL_INIT_HAPTIC = 4096U;

		// Token: 0x04000007 RID: 7
		public const uint SDL_INIT_GAMECONTROLLER = 8192U;

		// Token: 0x04000008 RID: 8
		public const uint SDL_INIT_NOPARACHUTE = 1048576U;

		// Token: 0x04000009 RID: 9
		public const uint SDL_INIT_EVERYTHING = 12849U;

		// Token: 0x0400000A RID: 10
		public const string SDL_HINT_FRAMEBUFFER_ACCELERATION = "SDL_FRAMEBUFFER_ACCELERATION";

		// Token: 0x0400000B RID: 11
		public const string SDL_HINT_RENDER_DRIVER = "SDL_RENDER_DRIVER";

		// Token: 0x0400000C RID: 12
		public const string SDL_HINT_RENDER_OPENGL_SHADERS = "SDL_RENDER_OPENGL_SHADERS";

		// Token: 0x0400000D RID: 13
		public const string SDL_HINT_RENDER_DIRECT3D_THREADSAFE = "SDL_RENDER_DIRECT3D_THREADSAFE";

		// Token: 0x0400000E RID: 14
		public const string SDL_HINT_RENDER_VSYNC = "SDL_RENDER_VSYNC";

		// Token: 0x0400000F RID: 15
		public const string SDL_HINT_VIDEO_X11_XVIDMODE = "SDL_VIDEO_X11_XVIDMODE";

		// Token: 0x04000010 RID: 16
		public const string SDL_HINT_VIDEO_X11_XINERAMA = "SDL_VIDEO_X11_XINERAMA";

		// Token: 0x04000011 RID: 17
		public const string SDL_HINT_VIDEO_X11_XRANDR = "SDL_VIDEO_X11_XRANDR";

		// Token: 0x04000012 RID: 18
		public const string SDL_HINT_GRAB_KEYBOARD = "SDL_GRAB_KEYBOARD";

		// Token: 0x04000013 RID: 19
		public const string SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS = "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";

		// Token: 0x04000014 RID: 20
		public const string SDL_HINT_IDLE_TIMER_DISABLED = "SDL_IOS_IDLE_TIMER_DISABLED";

		// Token: 0x04000015 RID: 21
		public const string SDL_HINT_ORIENTATIONS = "SDL_IOS_ORIENTATIONS";

		// Token: 0x04000016 RID: 22
		public const string SDL_HINT_XINPUT_ENABLED = "SDL_XINPUT_ENABLED";

		// Token: 0x04000017 RID: 23
		public const string SDL_HINT_GAMECONTROLLERCONFIG = "SDL_GAMECONTROLLERCONFIG";

		// Token: 0x04000018 RID: 24
		public const string SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS = "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";

		// Token: 0x04000019 RID: 25
		public const string SDL_HINT_ALLOW_TOPMOST = "SDL_ALLOW_TOPMOST";

		// Token: 0x0400001A RID: 26
		public const string SDL_HINT_TIMER_RESOLUTION = "SDL_TIMER_RESOLUTION";

		// Token: 0x0400001B RID: 27
		public const string SDL_HINT_RENDER_SCALE_QUALITY = "SDL_RENDER_SCALE_QUALITY";

		// Token: 0x0400001C RID: 28
		public const string SDL_HINT_VIDEO_HIGHDPI_DISABLED = "SDL_VIDEO_HIGHDPI_DISABLED";

		// Token: 0x0400001D RID: 29
		public const string SDL_HINT_CTRL_CLICK_EMULATE_RIGHT_CLICK = "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";

		// Token: 0x0400001E RID: 30
		public const string SDL_HINT_VIDEO_WIN_D3DCOMPILER = "SDL_VIDEO_WIN_D3DCOMPILER";

		// Token: 0x0400001F RID: 31
		public const string SDL_HINT_MOUSE_RELATIVE_MODE_WARP = "SDL_MOUSE_RELATIVE_MODE_WARP";

		// Token: 0x04000020 RID: 32
		public const string SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT = "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";

		// Token: 0x04000021 RID: 33
		public const string SDL_HINT_VIDEO_ALLOW_SCREENSAVER = "SDL_VIDEO_ALLOW_SCREENSAVER";

		// Token: 0x04000022 RID: 34
		public const string SDL_HINT_ACCELEROMETER_AS_JOYSTICK = "SDL_ACCELEROMETER_AS_JOYSTICK";

		// Token: 0x04000023 RID: 35
		public const string SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES = "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

		// Token: 0x04000024 RID: 36
		public const string SDL_HINT_NO_SIGNAL_HANDLERS = "SDL_NO_SIGNAL_HANDLERS";

		// Token: 0x04000025 RID: 37
		public const string SDL_HINT_IME_INTERNAL_EDITING = "SDL_IME_INTERNAL_EDITING";

		// Token: 0x04000026 RID: 38
		public const string SDL_HINT_ANDROID_SEPARATE_MOUSE_AND_TOUCH = "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";

		// Token: 0x04000027 RID: 39
		public const string SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT = "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";

		// Token: 0x04000028 RID: 40
		public const string SDL_HINT_THREAD_STACK_SIZE = "SDL_THREAD_STACK_SIZE";

		// Token: 0x04000029 RID: 41
		public const string SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN = "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";

		// Token: 0x0400002A RID: 42
		public const string SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP = "SDL_WINDOWS_ENABLE_MESSAGELOOP";

		// Token: 0x0400002B RID: 43
		public const string SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4 = "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";

		// Token: 0x0400002C RID: 44
		public const string SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING = "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";

		// Token: 0x0400002D RID: 45
		public const string SDL_HINT_MAC_BACKGROUND_APP = "SDL_MAC_BACKGROUND_APP";

		// Token: 0x0400002E RID: 46
		public const string SDL_HINT_VIDEO_X11_NET_WM_PING = "SDL_VIDEO_X11_NET_WM_PING";

		// Token: 0x0400002F RID: 47
		public const string SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION = "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";

		// Token: 0x04000030 RID: 48
		public const string SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION = "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

		// Token: 0x04000031 RID: 49
		public const string SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH = "SDL_MOUSE_FOCUS_CLICKTHROUGH";

		// Token: 0x04000032 RID: 50
		public const string SDL_HINT_BMP_SAVE_LEGACY_FORMAT = "SDL_BMP_SAVE_LEGACY_FORMAT";

		// Token: 0x04000033 RID: 51
		public const string SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING = "SDL_WINDOWS_DISABLE_THREAD_NAMING";

		// Token: 0x04000034 RID: 52
		public const string SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION = "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

		// Token: 0x04000035 RID: 53
		public const string SDL_HINT_AUDIO_RESAMPLING_MODE = "SDL_AUDIO_RESAMPLING_MODE";

		// Token: 0x04000036 RID: 54
		public const string SDL_HINT_RENDER_LOGICAL_SIZE_MODE = "SDL_RENDER_LOGICAL_SIZE_MODE";

		// Token: 0x04000037 RID: 55
		public const string SDL_HINT_MOUSE_NORMAL_SPEED_SCALE = "SDL_MOUSE_NORMAL_SPEED_SCALE";

		// Token: 0x04000038 RID: 56
		public const string SDL_HINT_MOUSE_RELATIVE_SPEED_SCALE = "SDL_MOUSE_RELATIVE_SPEED_SCALE";

		// Token: 0x04000039 RID: 57
		public const string SDL_HINT_TOUCH_MOUSE_EVENTS = "SDL_TOUCH_MOUSE_EVENTS";

		// Token: 0x0400003A RID: 58
		public const string SDL_HINT_WINDOWS_INTRESOURCE_ICON = "SDL_WINDOWS_INTRESOURCE_ICON";

		// Token: 0x0400003B RID: 59
		public const string SDL_HINT_WINDOWS_INTRESOURCE_ICON_SMALL = "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";

		// Token: 0x0400003C RID: 60
		public const int SDL_LOG_CATEGORY_APPLICATION = 0;

		// Token: 0x0400003D RID: 61
		public const int SDL_LOG_CATEGORY_ERROR = 1;

		// Token: 0x0400003E RID: 62
		public const int SDL_LOG_CATEGORY_ASSERT = 2;

		// Token: 0x0400003F RID: 63
		public const int SDL_LOG_CATEGORY_SYSTEM = 3;

		// Token: 0x04000040 RID: 64
		public const int SDL_LOG_CATEGORY_AUDIO = 4;

		// Token: 0x04000041 RID: 65
		public const int SDL_LOG_CATEGORY_VIDEO = 5;

		// Token: 0x04000042 RID: 66
		public const int SDL_LOG_CATEGORY_RENDER = 6;

		// Token: 0x04000043 RID: 67
		public const int SDL_LOG_CATEGORY_INPUT = 7;

		// Token: 0x04000044 RID: 68
		public const int SDL_LOG_CATEGORY_TEST = 8;

		// Token: 0x04000045 RID: 69
		public const int SDL_LOG_CATEGORY_RESERVED1 = 9;

		// Token: 0x04000046 RID: 70
		public const int SDL_LOG_CATEGORY_RESERVED2 = 10;

		// Token: 0x04000047 RID: 71
		public const int SDL_LOG_CATEGORY_RESERVED3 = 11;

		// Token: 0x04000048 RID: 72
		public const int SDL_LOG_CATEGORY_RESERVED4 = 12;

		// Token: 0x04000049 RID: 73
		public const int SDL_LOG_CATEGORY_RESERVED5 = 13;

		// Token: 0x0400004A RID: 74
		public const int SDL_LOG_CATEGORY_RESERVED6 = 14;

		// Token: 0x0400004B RID: 75
		public const int SDL_LOG_CATEGORY_RESERVED7 = 15;

		// Token: 0x0400004C RID: 76
		public const int SDL_LOG_CATEGORY_RESERVED8 = 16;

		// Token: 0x0400004D RID: 77
		public const int SDL_LOG_CATEGORY_RESERVED9 = 17;

		// Token: 0x0400004E RID: 78
		public const int SDL_LOG_CATEGORY_RESERVED10 = 18;

		// Token: 0x0400004F RID: 79
		public const int SDL_LOG_CATEGORY_CUSTOM = 19;

		// Token: 0x04000050 RID: 80
		public const int SDL_MAJOR_VERSION = 2;

		// Token: 0x04000051 RID: 81
		public const int SDL_MINOR_VERSION = 0;

		// Token: 0x04000052 RID: 82
		public const int SDL_PATCHLEVEL = 6;

		// Token: 0x04000053 RID: 83
		public static readonly int SDL_COMPILEDVERSION = SDL.SDL_VERSIONNUM(2, 0, 6);

		// Token: 0x04000054 RID: 84
		public const int SDL_WINDOWPOS_UNDEFINED_MASK = 536805376;

		// Token: 0x04000055 RID: 85
		public const int SDL_WINDOWPOS_CENTERED_MASK = 805240832;

		// Token: 0x04000056 RID: 86
		public const int SDL_WINDOWPOS_UNDEFINED = 536805376;

		// Token: 0x04000057 RID: 87
		public const int SDL_WINDOWPOS_CENTERED = 805240832;

		// Token: 0x04000058 RID: 88
		public static readonly uint SDL_PIXELFORMAT_UNKNOWN = 0U;

		// Token: 0x04000059 RID: 89
		public static readonly uint SDL_PIXELFORMAT_INDEX1LSB = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 1, 0);

		// Token: 0x0400005A RID: 90
		public static readonly uint SDL_PIXELFORMAT_INDEX1MSB = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 1, 0);

		// Token: 0x0400005B RID: 91
		public static readonly uint SDL_PIXELFORMAT_INDEX4LSB = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 4, 0);

		// Token: 0x0400005C RID: 92
		public static readonly uint SDL_PIXELFORMAT_INDEX4MSB = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 4, 0);

		// Token: 0x0400005D RID: 93
		public static readonly uint SDL_PIXELFORMAT_INDEX8 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX8, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_NONE, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 8, 1);

		// Token: 0x0400005E RID: 94
		public static readonly uint SDL_PIXELFORMAT_RGB332 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED8, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_332, 8, 1);

		// Token: 0x0400005F RID: 95
		public static readonly uint SDL_PIXELFORMAT_RGB444 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 12, 2);

		// Token: 0x04000060 RID: 96
		public static readonly uint SDL_PIXELFORMAT_RGB555 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555, 15, 2);

		// Token: 0x04000061 RID: 97
		public static readonly uint SDL_PIXELFORMAT_BGR555 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555, 15, 2);

		// Token: 0x04000062 RID: 98
		public static readonly uint SDL_PIXELFORMAT_ARGB4444 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 16, 2);

		// Token: 0x04000063 RID: 99
		public static readonly uint SDL_PIXELFORMAT_RGBA4444 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 16, 2);

		// Token: 0x04000064 RID: 100
		public static readonly uint SDL_PIXELFORMAT_ABGR4444 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 16, 2);

		// Token: 0x04000065 RID: 101
		public static readonly uint SDL_PIXELFORMAT_BGRA4444 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 16, 2);

		// Token: 0x04000066 RID: 102
		public static readonly uint SDL_PIXELFORMAT_ARGB1555 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555, 16, 2);

		// Token: 0x04000067 RID: 103
		public static readonly uint SDL_PIXELFORMAT_RGBA5551 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_5551, 16, 2);

		// Token: 0x04000068 RID: 104
		public static readonly uint SDL_PIXELFORMAT_ABGR1555 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555, 16, 2);

		// Token: 0x04000069 RID: 105
		public static readonly uint SDL_PIXELFORMAT_BGRA5551 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_5551, 16, 2);

		// Token: 0x0400006A RID: 106
		public static readonly uint SDL_PIXELFORMAT_RGB565 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_565, 16, 2);

		// Token: 0x0400006B RID: 107
		public static readonly uint SDL_PIXELFORMAT_BGR565 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XBGR, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_565, 16, 2);

		// Token: 0x0400006C RID: 108
		public static readonly uint SDL_PIXELFORMAT_RGB24 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_ARRAYU8, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 24, 3);

		// Token: 0x0400006D RID: 109
		public static readonly uint SDL_PIXELFORMAT_BGR24 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_ARRAYU8, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 24, 3);

		// Token: 0x0400006E RID: 110
		public static readonly uint SDL_PIXELFORMAT_RGB888 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 24, 4);

		// Token: 0x0400006F RID: 111
		public static readonly uint SDL_PIXELFORMAT_RGBX8888 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 24, 4);

		// Token: 0x04000070 RID: 112
		public static readonly uint SDL_PIXELFORMAT_BGR888 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XBGR, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 24, 4);

		// Token: 0x04000071 RID: 113
		public static readonly uint SDL_PIXELFORMAT_BGRX8888 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRX, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 24, 4);

		// Token: 0x04000072 RID: 114
		public static readonly uint SDL_PIXELFORMAT_ARGB8888 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 32, 4);

		// Token: 0x04000073 RID: 115
		public static readonly uint SDL_PIXELFORMAT_RGBA8888 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 32, 4);

		// Token: 0x04000074 RID: 116
		public static readonly uint SDL_PIXELFORMAT_ABGR8888 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 32, 4);

		// Token: 0x04000075 RID: 117
		public static readonly uint SDL_PIXELFORMAT_BGRA8888 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 32, 4);

		// Token: 0x04000076 RID: 118
		public static readonly uint SDL_PIXELFORMAT_ARGB2101010 = SDL.SDL_DEFINE_PIXELFORMAT(SDL.SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL.SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB, SDL.SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_2101010, 32, 4);

		// Token: 0x04000077 RID: 119
		public static readonly uint SDL_PIXELFORMAT_YV12 = SDL.SDL_DEFINE_PIXELFOURCC(89, 86, 49, 50);

		// Token: 0x04000078 RID: 120
		public static readonly uint SDL_PIXELFORMAT_IYUV = SDL.SDL_DEFINE_PIXELFOURCC(73, 89, 85, 86);

		// Token: 0x04000079 RID: 121
		public static readonly uint SDL_PIXELFORMAT_YUY2 = SDL.SDL_DEFINE_PIXELFOURCC(89, 85, 89, 50);

		// Token: 0x0400007A RID: 122
		public static readonly uint SDL_PIXELFORMAT_UYVY = SDL.SDL_DEFINE_PIXELFOURCC(85, 89, 86, 89);

		// Token: 0x0400007B RID: 123
		public static readonly uint SDL_PIXELFORMAT_YVYU = SDL.SDL_DEFINE_PIXELFOURCC(89, 86, 89, 85);

		// Token: 0x0400007C RID: 124
		public const uint SDL_SWSURFACE = 0U;

		// Token: 0x0400007D RID: 125
		public const uint SDL_PREALLOC = 1U;

		// Token: 0x0400007E RID: 126
		public const uint SDL_RLEACCEL = 2U;

		// Token: 0x0400007F RID: 127
		public const uint SDL_DONTFREE = 4U;

		// Token: 0x04000080 RID: 128
		public const byte SDL_PRESSED = 1;

		// Token: 0x04000081 RID: 129
		public const byte SDL_RELEASED = 0;

		// Token: 0x04000082 RID: 130
		public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = 32;

		// Token: 0x04000083 RID: 131
		public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = 32;

		// Token: 0x04000084 RID: 132
		public const int SDL_QUERY = -1;

		// Token: 0x04000085 RID: 133
		public const int SDL_IGNORE = 0;

		// Token: 0x04000086 RID: 134
		public const int SDL_DISABLE = 0;

		// Token: 0x04000087 RID: 135
		public const int SDL_ENABLE = 1;

		// Token: 0x04000088 RID: 136
		public const int SDLK_SCANCODE_MASK = 1073741824;

		// Token: 0x04000089 RID: 137
		public const uint SDL_BUTTON_LEFT = 1U;

		// Token: 0x0400008A RID: 138
		public const uint SDL_BUTTON_MIDDLE = 2U;

		// Token: 0x0400008B RID: 139
		public const uint SDL_BUTTON_RIGHT = 3U;

		// Token: 0x0400008C RID: 140
		public const uint SDL_BUTTON_X1 = 4U;

		// Token: 0x0400008D RID: 141
		public const uint SDL_BUTTON_X2 = 5U;

		// Token: 0x0400008E RID: 142
		public static readonly uint SDL_BUTTON_LMASK = SDL.SDL_BUTTON(1U);

		// Token: 0x0400008F RID: 143
		public static readonly uint SDL_BUTTON_MMASK = SDL.SDL_BUTTON(2U);

		// Token: 0x04000090 RID: 144
		public static readonly uint SDL_BUTTON_RMASK = SDL.SDL_BUTTON(3U);

		// Token: 0x04000091 RID: 145
		public static readonly uint SDL_BUTTON_X1MASK = SDL.SDL_BUTTON(4U);

		// Token: 0x04000092 RID: 146
		public static readonly uint SDL_BUTTON_X2MASK = SDL.SDL_BUTTON(5U);

		// Token: 0x04000093 RID: 147
		public const uint SDL_TOUCH_MOUSEID = 4294967295U;

		// Token: 0x04000094 RID: 148
		public const byte SDL_HAT_CENTERED = 0;

		// Token: 0x04000095 RID: 149
		public const byte SDL_HAT_UP = 1;

		// Token: 0x04000096 RID: 150
		public const byte SDL_HAT_RIGHT = 2;

		// Token: 0x04000097 RID: 151
		public const byte SDL_HAT_DOWN = 4;

		// Token: 0x04000098 RID: 152
		public const byte SDL_HAT_LEFT = 8;

		// Token: 0x04000099 RID: 153
		public const byte SDL_HAT_RIGHTUP = 3;

		// Token: 0x0400009A RID: 154
		public const byte SDL_HAT_RIGHTDOWN = 6;

		// Token: 0x0400009B RID: 155
		public const byte SDL_HAT_LEFTUP = 9;

		// Token: 0x0400009C RID: 156
		public const byte SDL_HAT_LEFTDOWN = 12;

		// Token: 0x0400009D RID: 157
		public const ushort SDL_HAPTIC_CONSTANT = 1;

		// Token: 0x0400009E RID: 158
		public const ushort SDL_HAPTIC_SINE = 2;

		// Token: 0x0400009F RID: 159
		public const ushort SDL_HAPTIC_LEFTRIGHT = 4;

		// Token: 0x040000A0 RID: 160
		public const ushort SDL_HAPTIC_TRIANGLE = 8;

		// Token: 0x040000A1 RID: 161
		public const ushort SDL_HAPTIC_SAWTOOTHUP = 16;

		// Token: 0x040000A2 RID: 162
		public const ushort SDL_HAPTIC_SAWTOOTHDOWN = 32;

		// Token: 0x040000A3 RID: 163
		public const ushort SDL_HAPTIC_SPRING = 128;

		// Token: 0x040000A4 RID: 164
		public const ushort SDL_HAPTIC_DAMPER = 256;

		// Token: 0x040000A5 RID: 165
		public const ushort SDL_HAPTIC_INERTIA = 512;

		// Token: 0x040000A6 RID: 166
		public const ushort SDL_HAPTIC_FRICTION = 1024;

		// Token: 0x040000A7 RID: 167
		public const ushort SDL_HAPTIC_CUSTOM = 2048;

		// Token: 0x040000A8 RID: 168
		public const ushort SDL_HAPTIC_GAIN = 4096;

		// Token: 0x040000A9 RID: 169
		public const ushort SDL_HAPTIC_AUTOCENTER = 8192;

		// Token: 0x040000AA RID: 170
		public const ushort SDL_HAPTIC_STATUS = 16384;

		// Token: 0x040000AB RID: 171
		public const ushort SDL_HAPTIC_PAUSE = 32768;

		// Token: 0x040000AC RID: 172
		public const byte SDL_HAPTIC_POLAR = 0;

		// Token: 0x040000AD RID: 173
		public const byte SDL_HAPTIC_CARTESIAN = 1;

		// Token: 0x040000AE RID: 174
		public const byte SDL_HAPTIC_SPHERICAL = 2;

		// Token: 0x040000AF RID: 175
		public const uint SDL_HAPTIC_INFINITY = 4292967295U;

		// Token: 0x040000B0 RID: 176
		public const ushort SDL_AUDIO_MASK_BITSIZE = 255;

		// Token: 0x040000B1 RID: 177
		public const ushort SDL_AUDIO_MASK_DATATYPE = 256;

		// Token: 0x040000B2 RID: 178
		public const ushort SDL_AUDIO_MASK_ENDIAN = 4096;

		// Token: 0x040000B3 RID: 179
		public const ushort SDL_AUDIO_MASK_SIGNED = 32768;

		// Token: 0x040000B4 RID: 180
		public const ushort AUDIO_U8 = 8;

		// Token: 0x040000B5 RID: 181
		public const ushort AUDIO_S8 = 32776;

		// Token: 0x040000B6 RID: 182
		public const ushort AUDIO_U16LSB = 16;

		// Token: 0x040000B7 RID: 183
		public const ushort AUDIO_S16LSB = 32784;

		// Token: 0x040000B8 RID: 184
		public const ushort AUDIO_U16MSB = 4112;

		// Token: 0x040000B9 RID: 185
		public const ushort AUDIO_S16MSB = 36880;

		// Token: 0x040000BA RID: 186
		public const ushort AUDIO_U16 = 16;

		// Token: 0x040000BB RID: 187
		public const ushort AUDIO_S16 = 32784;

		// Token: 0x040000BC RID: 188
		public const ushort AUDIO_S32LSB = 32800;

		// Token: 0x040000BD RID: 189
		public const ushort AUDIO_S32MSB = 36896;

		// Token: 0x040000BE RID: 190
		public const ushort AUDIO_S32 = 32800;

		// Token: 0x040000BF RID: 191
		public const ushort AUDIO_F32LSB = 33056;

		// Token: 0x040000C0 RID: 192
		public const ushort AUDIO_F32MSB = 37152;

		// Token: 0x040000C1 RID: 193
		public const ushort AUDIO_F32 = 33056;

		// Token: 0x040000C2 RID: 194
		public static readonly ushort AUDIO_U16SYS = BitConverter.IsLittleEndian ? 16 : 4112;

		// Token: 0x040000C3 RID: 195
		public static readonly ushort AUDIO_S16SYS = BitConverter.IsLittleEndian ? 32784 : 36880;

		// Token: 0x040000C4 RID: 196
		public static readonly ushort AUDIO_S32SYS = BitConverter.IsLittleEndian ? 32800 : 36896;

		// Token: 0x040000C5 RID: 197
		public static readonly ushort AUDIO_F32SYS = BitConverter.IsLittleEndian ? 33056 : 37152;

		// Token: 0x040000C6 RID: 198
		public const uint SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 1U;

		// Token: 0x040000C7 RID: 199
		public const uint SDL_AUDIO_ALLOW_FORMAT_CHANGE = 1U;

		// Token: 0x040000C8 RID: 200
		public const uint SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 1U;

		// Token: 0x040000C9 RID: 201
		public const uint SDL_AUDIO_ALLOW_ANY_CHANGE = 1U;

		// Token: 0x040000CA RID: 202
		public const int SDL_MIX_MAXVOLUME = 128;

		// Token: 0x02000007 RID: 7
		public enum SDL_bool
		{
			// Token: 0x040000EC RID: 236
			SDL_FALSE,
			// Token: 0x040000ED RID: 237
			SDL_TRUE
		}

		// Token: 0x02000008 RID: 8
		public enum SDL_HintPriority
		{
			// Token: 0x040000EF RID: 239
			SDL_HINT_DEFAULT,
			// Token: 0x040000F0 RID: 240
			SDL_HINT_NORMAL,
			// Token: 0x040000F1 RID: 241
			SDL_HINT_OVERRIDE
		}

		// Token: 0x02000009 RID: 9
		public enum SDL_LogPriority
		{
			// Token: 0x040000F3 RID: 243
			SDL_LOG_PRIORITY_VERBOSE = 1,
			// Token: 0x040000F4 RID: 244
			SDL_LOG_PRIORITY_DEBUG,
			// Token: 0x040000F5 RID: 245
			SDL_LOG_PRIORITY_INFO,
			// Token: 0x040000F6 RID: 246
			SDL_LOG_PRIORITY_WARN,
			// Token: 0x040000F7 RID: 247
			SDL_LOG_PRIORITY_ERROR,
			// Token: 0x040000F8 RID: 248
			SDL_LOG_PRIORITY_CRITICAL,
			// Token: 0x040000F9 RID: 249
			SDL_NUM_LOG_PRIORITIES
		}

		// Token: 0x0200000A RID: 10
		// (Invoke) Token: 0x06000280 RID: 640
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SDL_LogOutputFunction(IntPtr userdata, int category, SDL.SDL_LogPriority priority, IntPtr message);

		// Token: 0x0200000B RID: 11
		[Flags]
		public enum SDL_MessageBoxFlags : uint
		{
			// Token: 0x040000FB RID: 251
			SDL_MESSAGEBOX_ERROR = 16U,
			// Token: 0x040000FC RID: 252
			SDL_MESSAGEBOX_WARNING = 32U,
			// Token: 0x040000FD RID: 253
			SDL_MESSAGEBOX_INFORMATION = 64U
		}

		// Token: 0x0200000C RID: 12
		[Flags]
		public enum SDL_MessageBoxButtonFlags : uint
		{
			// Token: 0x040000FF RID: 255
			SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 1U,
			// Token: 0x04000100 RID: 256
			SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 2U
		}

		// Token: 0x0200000D RID: 13
		private struct INTERNAL_SDL_MessageBoxButtonData
		{
			// Token: 0x04000101 RID: 257
			public SDL.SDL_MessageBoxButtonFlags flags;

			// Token: 0x04000102 RID: 258
			public int buttonid;

			// Token: 0x04000103 RID: 259
			public IntPtr text;
		}

		// Token: 0x0200000E RID: 14
		public struct SDL_MessageBoxButtonData
		{
			// Token: 0x04000104 RID: 260
			public SDL.SDL_MessageBoxButtonFlags flags;

			// Token: 0x04000105 RID: 261
			public int buttonid;

			// Token: 0x04000106 RID: 262
			public string text;
		}

		// Token: 0x0200000F RID: 15
		public struct SDL_MessageBoxColor
		{
			// Token: 0x04000107 RID: 263
			public byte r;

			// Token: 0x04000108 RID: 264
			public byte g;

			// Token: 0x04000109 RID: 265
			public byte b;
		}

		// Token: 0x02000010 RID: 16
		public enum SDL_MessageBoxColorType
		{
			// Token: 0x0400010B RID: 267
			SDL_MESSAGEBOX_COLOR_BACKGROUND,
			// Token: 0x0400010C RID: 268
			SDL_MESSAGEBOX_COLOR_TEXT,
			// Token: 0x0400010D RID: 269
			SDL_MESSAGEBOX_COLOR_BUTTON_BORDER,
			// Token: 0x0400010E RID: 270
			SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND,
			// Token: 0x0400010F RID: 271
			SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED,
			// Token: 0x04000110 RID: 272
			SDL_MESSAGEBOX_COLOR_MAX
		}

		// Token: 0x02000011 RID: 17
		public struct SDL_MessageBoxColorScheme
		{
			// Token: 0x04000111 RID: 273
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.Struct)]
			public SDL.SDL_MessageBoxColor[] colors;
		}

		// Token: 0x02000012 RID: 18
		private struct INTERNAL_SDL_MessageBoxData
		{
			// Token: 0x04000112 RID: 274
			public SDL.SDL_MessageBoxFlags flags;

			// Token: 0x04000113 RID: 275
			public IntPtr window;

			// Token: 0x04000114 RID: 276
			public IntPtr title;

			// Token: 0x04000115 RID: 277
			public IntPtr message;

			// Token: 0x04000116 RID: 278
			public int numbuttons;

			// Token: 0x04000117 RID: 279
			public IntPtr buttons;

			// Token: 0x04000118 RID: 280
			public IntPtr colorScheme;
		}

		// Token: 0x02000013 RID: 19
		public struct SDL_MessageBoxData
		{
			// Token: 0x04000119 RID: 281
			public SDL.SDL_MessageBoxFlags flags;

			// Token: 0x0400011A RID: 282
			public IntPtr window;

			// Token: 0x0400011B RID: 283
			public string title;

			// Token: 0x0400011C RID: 284
			public string message;

			// Token: 0x0400011D RID: 285
			public int numbuttons;

			// Token: 0x0400011E RID: 286
			public SDL.SDL_MessageBoxButtonData[] buttons;

			// Token: 0x0400011F RID: 287
			public SDL.SDL_MessageBoxColorScheme? colorScheme;
		}

		// Token: 0x02000014 RID: 20
		public struct SDL_version
		{
			// Token: 0x04000120 RID: 288
			public byte major;

			// Token: 0x04000121 RID: 289
			public byte minor;

			// Token: 0x04000122 RID: 290
			public byte patch;
		}

		// Token: 0x02000015 RID: 21
		public enum SDL_GLattr
		{
			// Token: 0x04000124 RID: 292
			SDL_GL_RED_SIZE,
			// Token: 0x04000125 RID: 293
			SDL_GL_GREEN_SIZE,
			// Token: 0x04000126 RID: 294
			SDL_GL_BLUE_SIZE,
			// Token: 0x04000127 RID: 295
			SDL_GL_ALPHA_SIZE,
			// Token: 0x04000128 RID: 296
			SDL_GL_BUFFER_SIZE,
			// Token: 0x04000129 RID: 297
			SDL_GL_DOUBLEBUFFER,
			// Token: 0x0400012A RID: 298
			SDL_GL_DEPTH_SIZE,
			// Token: 0x0400012B RID: 299
			SDL_GL_STENCIL_SIZE,
			// Token: 0x0400012C RID: 300
			SDL_GL_ACCUM_RED_SIZE,
			// Token: 0x0400012D RID: 301
			SDL_GL_ACCUM_GREEN_SIZE,
			// Token: 0x0400012E RID: 302
			SDL_GL_ACCUM_BLUE_SIZE,
			// Token: 0x0400012F RID: 303
			SDL_GL_ACCUM_ALPHA_SIZE,
			// Token: 0x04000130 RID: 304
			SDL_GL_STEREO,
			// Token: 0x04000131 RID: 305
			SDL_GL_MULTISAMPLEBUFFERS,
			// Token: 0x04000132 RID: 306
			SDL_GL_MULTISAMPLESAMPLES,
			// Token: 0x04000133 RID: 307
			SDL_GL_ACCELERATED_VISUAL,
			// Token: 0x04000134 RID: 308
			SDL_GL_RETAINED_BACKING,
			// Token: 0x04000135 RID: 309
			SDL_GL_CONTEXT_MAJOR_VERSION,
			// Token: 0x04000136 RID: 310
			SDL_GL_CONTEXT_MINOR_VERSION,
			// Token: 0x04000137 RID: 311
			SDL_GL_CONTEXT_EGL,
			// Token: 0x04000138 RID: 312
			SDL_GL_CONTEXT_FLAGS,
			// Token: 0x04000139 RID: 313
			SDL_GL_CONTEXT_PROFILE_MASK,
			// Token: 0x0400013A RID: 314
			SDL_GL_SHARE_WITH_CURRENT_CONTEXT,
			// Token: 0x0400013B RID: 315
			SDL_GL_FRAMEBUFFER_SRGB_CAPABLE,
			// Token: 0x0400013C RID: 316
			SDL_GL_CONTEXT_RELEASE_BEHAVIOR,
			// Token: 0x0400013D RID: 317
			SDL_GL_CONTEXT_RESET_NOTIFICATION,
			// Token: 0x0400013E RID: 318
			SDL_GL_CONTEXT_NO_ERROR
		}

		// Token: 0x02000016 RID: 22
		[Flags]
		public enum SDL_GLprofile
		{
			// Token: 0x04000140 RID: 320
			SDL_GL_CONTEXT_PROFILE_CORE = 1,
			// Token: 0x04000141 RID: 321
			SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = 2,
			// Token: 0x04000142 RID: 322
			SDL_GL_CONTEXT_PROFILE_ES = 4
		}

		// Token: 0x02000017 RID: 23
		[Flags]
		public enum SDL_GLcontext
		{
			// Token: 0x04000144 RID: 324
			SDL_GL_CONTEXT_DEBUG_FLAG = 1,
			// Token: 0x04000145 RID: 325
			SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 2,
			// Token: 0x04000146 RID: 326
			SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = 4,
			// Token: 0x04000147 RID: 327
			SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = 8
		}

		// Token: 0x02000018 RID: 24
		public enum SDL_WindowEventID : byte
		{
			// Token: 0x04000149 RID: 329
			SDL_WINDOWEVENT_NONE,
			// Token: 0x0400014A RID: 330
			SDL_WINDOWEVENT_SHOWN,
			// Token: 0x0400014B RID: 331
			SDL_WINDOWEVENT_HIDDEN,
			// Token: 0x0400014C RID: 332
			SDL_WINDOWEVENT_EXPOSED,
			// Token: 0x0400014D RID: 333
			SDL_WINDOWEVENT_MOVED,
			// Token: 0x0400014E RID: 334
			SDL_WINDOWEVENT_RESIZED,
			// Token: 0x0400014F RID: 335
			SDL_WINDOWEVENT_SIZE_CHANGED,
			// Token: 0x04000150 RID: 336
			SDL_WINDOWEVENT_MINIMIZED,
			// Token: 0x04000151 RID: 337
			SDL_WINDOWEVENT_MAXIMIZED,
			// Token: 0x04000152 RID: 338
			SDL_WINDOWEVENT_RESTORED,
			// Token: 0x04000153 RID: 339
			SDL_WINDOWEVENT_ENTER,
			// Token: 0x04000154 RID: 340
			SDL_WINDOWEVENT_LEAVE,
			// Token: 0x04000155 RID: 341
			SDL_WINDOWEVENT_FOCUS_GAINED,
			// Token: 0x04000156 RID: 342
			SDL_WINDOWEVENT_FOCUS_LOST,
			// Token: 0x04000157 RID: 343
			SDL_WINDOWEVENT_CLOSE,
			// Token: 0x04000158 RID: 344
			SDL_WINDOWEVENT_TAKE_FOCUS,
			// Token: 0x04000159 RID: 345
			SDL_WINDOWEVENT_HIT_TEST
		}

		// Token: 0x02000019 RID: 25
		[Flags]
		public enum SDL_WindowFlags : uint
		{
			// Token: 0x0400015B RID: 347
			SDL_WINDOW_FULLSCREEN = 1U,
			// Token: 0x0400015C RID: 348
			SDL_WINDOW_OPENGL = 2U,
			// Token: 0x0400015D RID: 349
			SDL_WINDOW_SHOWN = 4U,
			// Token: 0x0400015E RID: 350
			SDL_WINDOW_HIDDEN = 8U,
			// Token: 0x0400015F RID: 351
			SDL_WINDOW_BORDERLESS = 16U,
			// Token: 0x04000160 RID: 352
			SDL_WINDOW_RESIZABLE = 32U,
			// Token: 0x04000161 RID: 353
			SDL_WINDOW_MINIMIZED = 64U,
			// Token: 0x04000162 RID: 354
			SDL_WINDOW_MAXIMIZED = 128U,
			// Token: 0x04000163 RID: 355
			SDL_WINDOW_INPUT_GRABBED = 256U,
			// Token: 0x04000164 RID: 356
			SDL_WINDOW_INPUT_FOCUS = 512U,
			// Token: 0x04000165 RID: 357
			SDL_WINDOW_MOUSE_FOCUS = 1024U,
			// Token: 0x04000166 RID: 358
			SDL_WINDOW_FULLSCREEN_DESKTOP = 4097U,
			// Token: 0x04000167 RID: 359
			SDL_WINDOW_FOREIGN = 2048U,
			// Token: 0x04000168 RID: 360
			SDL_WINDOW_ALLOW_HIGHDPI = 8192U,
			// Token: 0x04000169 RID: 361
			SDL_WINDOW_MOUSE_CAPTURE = 16384U,
			// Token: 0x0400016A RID: 362
			SDL_WINDOW_ALWAYS_ON_TOP = 32768U,
			// Token: 0x0400016B RID: 363
			SDL_WINDOW_SKIP_TASKBAR = 65536U,
			// Token: 0x0400016C RID: 364
			SDL_WINDOW_UTILITY = 131072U,
			// Token: 0x0400016D RID: 365
			SDL_WINDOW_TOOLTIP = 262144U,
			// Token: 0x0400016E RID: 366
			SDL_WINDOW_POPUP_MENU = 524288U,
			// Token: 0x0400016F RID: 367
			SDL_WINDOW_VULKAN = 268435456U
		}

		// Token: 0x0200001A RID: 26
		public enum SDL_HitTestResult
		{
			// Token: 0x04000171 RID: 369
			SDL_HITTEST_NORMAL,
			// Token: 0x04000172 RID: 370
			SDL_HITTEST_DRAGGABLE,
			// Token: 0x04000173 RID: 371
			SDL_HITTEST_RESIZE_TOPLEFT,
			// Token: 0x04000174 RID: 372
			SDL_HITTEST_RESIZE_TOP,
			// Token: 0x04000175 RID: 373
			SDL_HITTEST_RESIZE_TOPRIGHT,
			// Token: 0x04000176 RID: 374
			SDL_HITTEST_RESIZE_RIGHT,
			// Token: 0x04000177 RID: 375
			SDL_HITTEST_RESIZE_BOTTOMRIGHT,
			// Token: 0x04000178 RID: 376
			SDL_HITTEST_RESIZE_BOTTOM,
			// Token: 0x04000179 RID: 377
			SDL_HITTEST_RESIZE_BOTTOMLEFT,
			// Token: 0x0400017A RID: 378
			SDL_HITTEST_RESIZE_LEFT
		}

		// Token: 0x0200001B RID: 27
		public struct SDL_DisplayMode
		{
			// Token: 0x0400017B RID: 379
			public uint format;

			// Token: 0x0400017C RID: 380
			public int w;

			// Token: 0x0400017D RID: 381
			public int h;

			// Token: 0x0400017E RID: 382
			public int refresh_rate;

			// Token: 0x0400017F RID: 383
			public IntPtr driverdata;
		}

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x06000284 RID: 644
		public delegate SDL.SDL_HitTestResult SDL_HitTest(IntPtr win, IntPtr area, IntPtr data);

		// Token: 0x0200001D RID: 29
		[Flags]
		public enum SDL_BlendMode
		{
			// Token: 0x04000181 RID: 385
			SDL_BLENDMODE_NONE = 0,
			// Token: 0x04000182 RID: 386
			SDL_BLENDMODE_BLEND = 1,
			// Token: 0x04000183 RID: 387
			SDL_BLENDMODE_ADD = 2,
			// Token: 0x04000184 RID: 388
			SDL_BLENDMODE_MOD = 4,
			// Token: 0x04000185 RID: 389
			SDL_BLENDMODE_INVALID = 2147483647
		}

		// Token: 0x0200001E RID: 30
		public enum SDL_BlendOperation
		{
			// Token: 0x04000187 RID: 391
			SDL_BLENDOPERATION_ADD = 1,
			// Token: 0x04000188 RID: 392
			SDL_BLENDOPERATION_SUBTRACT,
			// Token: 0x04000189 RID: 393
			SDL_BLENDOPERATION_REV_SUBTRACT,
			// Token: 0x0400018A RID: 394
			SDL_BLENDOPERATION_MINIMUM,
			// Token: 0x0400018B RID: 395
			SDL_BLENDOPERATION_MAXIMUM
		}

		// Token: 0x0200001F RID: 31
		public enum SDL_BlendFactor
		{
			// Token: 0x0400018D RID: 397
			SDL_BLENDFACTOR_ZERO = 1,
			// Token: 0x0400018E RID: 398
			SDL_BLENDFACTOR_ONE,
			// Token: 0x0400018F RID: 399
			SDL_BLENDFACTOR_SRC_COLOR,
			// Token: 0x04000190 RID: 400
			SDL_BLENDFACTOR_ONE_MINUS_SRC_COLOR,
			// Token: 0x04000191 RID: 401
			SDL_BLENDFACTOR_SRC_ALPHA,
			// Token: 0x04000192 RID: 402
			SDL_BLENDFACTOR_ONE_MINUS_SRC_ALPHA,
			// Token: 0x04000193 RID: 403
			SDL_BLENDFACTOR_DST_COLOR,
			// Token: 0x04000194 RID: 404
			SDL_BLENDFACTOR_ONE_MINUS_DST_COLOR,
			// Token: 0x04000195 RID: 405
			SDL_BLENDFACTOR_DST_ALPHA,
			// Token: 0x04000196 RID: 406
			SDL_BLENDFACTOR_ONE_MINUS_DST_ALPHA
		}

		// Token: 0x02000020 RID: 32
		[Flags]
		public enum SDL_RendererFlags : uint
		{
			// Token: 0x04000198 RID: 408
			SDL_RENDERER_SOFTWARE = 1U,
			// Token: 0x04000199 RID: 409
			SDL_RENDERER_ACCELERATED = 2U,
			// Token: 0x0400019A RID: 410
			SDL_RENDERER_PRESENTVSYNC = 4U,
			// Token: 0x0400019B RID: 411
			SDL_RENDERER_TARGETTEXTURE = 8U
		}

		// Token: 0x02000021 RID: 33
		[Flags]
		public enum SDL_RendererFlip
		{
			// Token: 0x0400019D RID: 413
			SDL_FLIP_NONE = 0,
			// Token: 0x0400019E RID: 414
			SDL_FLIP_HORIZONTAL = 1,
			// Token: 0x0400019F RID: 415
			SDL_FLIP_VERTICAL = 2
		}

		// Token: 0x02000022 RID: 34
		public enum SDL_TextureAccess
		{
			// Token: 0x040001A1 RID: 417
			SDL_TEXTUREACCESS_STATIC,
			// Token: 0x040001A2 RID: 418
			SDL_TEXTUREACCESS_STREAMING,
			// Token: 0x040001A3 RID: 419
			SDL_TEXTUREACCESS_TARGET
		}

		// Token: 0x02000023 RID: 35
		[Flags]
		public enum SDL_TextureModulate
		{
			// Token: 0x040001A5 RID: 421
			SDL_TEXTUREMODULATE_NONE = 0,
			// Token: 0x040001A6 RID: 422
			SDL_TEXTUREMODULATE_HORIZONTAL = 1,
			// Token: 0x040001A7 RID: 423
			SDL_TEXTUREMODULATE_VERTICAL = 2
		}

		// Token: 0x02000024 RID: 36
		public struct SDL_RendererInfo
		{
			// Token: 0x040001A8 RID: 424
			public IntPtr name;

			// Token: 0x040001A9 RID: 425
			public uint flags;

			// Token: 0x040001AA RID: 426
			public uint num_texture_formats;

			// Token: 0x040001AB RID: 427
			[FixedBuffer(typeof(uint), 16)]
			public SDL.SDL_RendererInfo.<texture_formats>e__FixedBuffer texture_formats;

			// Token: 0x040001AC RID: 428
			public int max_texture_width;

			// Token: 0x040001AD RID: 429
			public int max_texture_height;

			// Token: 0x0200007A RID: 122
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 64)]
			public struct <texture_formats>e__FixedBuffer
			{
				// Token: 0x040005C9 RID: 1481
				public uint FixedElementField;
			}
		}

		// Token: 0x02000025 RID: 37
		public enum SDL_PIXELTYPE_ENUM
		{
			// Token: 0x040001AF RID: 431
			SDL_PIXELTYPE_UNKNOWN,
			// Token: 0x040001B0 RID: 432
			SDL_PIXELTYPE_INDEX1,
			// Token: 0x040001B1 RID: 433
			SDL_PIXELTYPE_INDEX4,
			// Token: 0x040001B2 RID: 434
			SDL_PIXELTYPE_INDEX8,
			// Token: 0x040001B3 RID: 435
			SDL_PIXELTYPE_PACKED8,
			// Token: 0x040001B4 RID: 436
			SDL_PIXELTYPE_PACKED16,
			// Token: 0x040001B5 RID: 437
			SDL_PIXELTYPE_PACKED32,
			// Token: 0x040001B6 RID: 438
			SDL_PIXELTYPE_ARRAYU8,
			// Token: 0x040001B7 RID: 439
			SDL_PIXELTYPE_ARRAYU16,
			// Token: 0x040001B8 RID: 440
			SDL_PIXELTYPE_ARRAYU32,
			// Token: 0x040001B9 RID: 441
			SDL_PIXELTYPE_ARRAYF16,
			// Token: 0x040001BA RID: 442
			SDL_PIXELTYPE_ARRAYF32
		}

		// Token: 0x02000026 RID: 38
		public enum SDL_PIXELORDER_ENUM
		{
			// Token: 0x040001BC RID: 444
			SDL_BITMAPORDER_NONE,
			// Token: 0x040001BD RID: 445
			SDL_BITMAPORDER_4321,
			// Token: 0x040001BE RID: 446
			SDL_BITMAPORDER_1234,
			// Token: 0x040001BF RID: 447
			SDL_PACKEDORDER_NONE = 0,
			// Token: 0x040001C0 RID: 448
			SDL_PACKEDORDER_XRGB,
			// Token: 0x040001C1 RID: 449
			SDL_PACKEDORDER_RGBX,
			// Token: 0x040001C2 RID: 450
			SDL_PACKEDORDER_ARGB,
			// Token: 0x040001C3 RID: 451
			SDL_PACKEDORDER_RGBA,
			// Token: 0x040001C4 RID: 452
			SDL_PACKEDORDER_XBGR,
			// Token: 0x040001C5 RID: 453
			SDL_PACKEDORDER_BGRX,
			// Token: 0x040001C6 RID: 454
			SDL_PACKEDORDER_ABGR,
			// Token: 0x040001C7 RID: 455
			SDL_PACKEDORDER_BGRA,
			// Token: 0x040001C8 RID: 456
			SDL_ARRAYORDER_NONE = 0,
			// Token: 0x040001C9 RID: 457
			SDL_ARRAYORDER_RGB,
			// Token: 0x040001CA RID: 458
			SDL_ARRAYORDER_RGBA,
			// Token: 0x040001CB RID: 459
			SDL_ARRAYORDER_ARGB,
			// Token: 0x040001CC RID: 460
			SDL_ARRAYORDER_BGR,
			// Token: 0x040001CD RID: 461
			SDL_ARRAYORDER_BGRA,
			// Token: 0x040001CE RID: 462
			SDL_ARRAYORDER_ABGR
		}

		// Token: 0x02000027 RID: 39
		public enum SDL_PACKEDLAYOUT_ENUM
		{
			// Token: 0x040001D0 RID: 464
			SDL_PACKEDLAYOUT_NONE,
			// Token: 0x040001D1 RID: 465
			SDL_PACKEDLAYOUT_332,
			// Token: 0x040001D2 RID: 466
			SDL_PACKEDLAYOUT_4444,
			// Token: 0x040001D3 RID: 467
			SDL_PACKEDLAYOUT_1555,
			// Token: 0x040001D4 RID: 468
			SDL_PACKEDLAYOUT_5551,
			// Token: 0x040001D5 RID: 469
			SDL_PACKEDLAYOUT_565,
			// Token: 0x040001D6 RID: 470
			SDL_PACKEDLAYOUT_8888,
			// Token: 0x040001D7 RID: 471
			SDL_PACKEDLAYOUT_2101010,
			// Token: 0x040001D8 RID: 472
			SDL_PACKEDLAYOUT_1010102
		}

		// Token: 0x02000028 RID: 40
		public struct SDL_Color
		{
			// Token: 0x040001D9 RID: 473
			public byte r;

			// Token: 0x040001DA RID: 474
			public byte g;

			// Token: 0x040001DB RID: 475
			public byte b;

			// Token: 0x040001DC RID: 476
			public byte a;
		}

		// Token: 0x02000029 RID: 41
		public struct SDL_Palette
		{
			// Token: 0x040001DD RID: 477
			public int ncolors;

			// Token: 0x040001DE RID: 478
			public IntPtr colors;

			// Token: 0x040001DF RID: 479
			public int version;

			// Token: 0x040001E0 RID: 480
			public int refcount;
		}

		// Token: 0x0200002A RID: 42
		public struct SDL_PixelFormat
		{
			// Token: 0x040001E1 RID: 481
			public uint format;

			// Token: 0x040001E2 RID: 482
			public IntPtr palette;

			// Token: 0x040001E3 RID: 483
			public byte BitsPerPixel;

			// Token: 0x040001E4 RID: 484
			public byte BytesPerPixel;

			// Token: 0x040001E5 RID: 485
			public uint Rmask;

			// Token: 0x040001E6 RID: 486
			public uint Gmask;

			// Token: 0x040001E7 RID: 487
			public uint Bmask;

			// Token: 0x040001E8 RID: 488
			public uint Amask;

			// Token: 0x040001E9 RID: 489
			public byte Rloss;

			// Token: 0x040001EA RID: 490
			public byte Gloss;

			// Token: 0x040001EB RID: 491
			public byte Bloss;

			// Token: 0x040001EC RID: 492
			public byte Aloss;

			// Token: 0x040001ED RID: 493
			public byte Rshift;

			// Token: 0x040001EE RID: 494
			public byte Gshift;

			// Token: 0x040001EF RID: 495
			public byte Bshift;

			// Token: 0x040001F0 RID: 496
			public byte Ashift;

			// Token: 0x040001F1 RID: 497
			public int refcount;

			// Token: 0x040001F2 RID: 498
			public IntPtr next;
		}

		// Token: 0x0200002B RID: 43
		public struct SDL_Point
		{
			// Token: 0x040001F3 RID: 499
			public int x;

			// Token: 0x040001F4 RID: 500
			public int y;
		}

		// Token: 0x0200002C RID: 44
		public struct SDL_Rect
		{
			// Token: 0x040001F5 RID: 501
			public int x;

			// Token: 0x040001F6 RID: 502
			public int y;

			// Token: 0x040001F7 RID: 503
			public int w;

			// Token: 0x040001F8 RID: 504
			public int h;
		}

		// Token: 0x0200002D RID: 45
		public struct SDL_Surface
		{
			// Token: 0x040001F9 RID: 505
			public uint flags;

			// Token: 0x040001FA RID: 506
			public IntPtr format;

			// Token: 0x040001FB RID: 507
			public int w;

			// Token: 0x040001FC RID: 508
			public int h;

			// Token: 0x040001FD RID: 509
			public int pitch;

			// Token: 0x040001FE RID: 510
			public IntPtr pixels;

			// Token: 0x040001FF RID: 511
			public IntPtr userdata;

			// Token: 0x04000200 RID: 512
			public int locked;

			// Token: 0x04000201 RID: 513
			public IntPtr lock_data;

			// Token: 0x04000202 RID: 514
			public SDL.SDL_Rect clip_rect;

			// Token: 0x04000203 RID: 515
			public IntPtr map;

			// Token: 0x04000204 RID: 516
			public int refcount;
		}

		// Token: 0x0200002E RID: 46
		public enum SDL_EventType : uint
		{
			// Token: 0x04000206 RID: 518
			SDL_FIRSTEVENT,
			// Token: 0x04000207 RID: 519
			SDL_QUIT = 256U,
			// Token: 0x04000208 RID: 520
			SDL_WINDOWEVENT = 512U,
			// Token: 0x04000209 RID: 521
			SDL_SYSWMEVENT,
			// Token: 0x0400020A RID: 522
			SDL_KEYDOWN = 768U,
			// Token: 0x0400020B RID: 523
			SDL_KEYUP,
			// Token: 0x0400020C RID: 524
			SDL_TEXTEDITING,
			// Token: 0x0400020D RID: 525
			SDL_TEXTINPUT,
			// Token: 0x0400020E RID: 526
			SDL_MOUSEMOTION = 1024U,
			// Token: 0x0400020F RID: 527
			SDL_MOUSEBUTTONDOWN,
			// Token: 0x04000210 RID: 528
			SDL_MOUSEBUTTONUP,
			// Token: 0x04000211 RID: 529
			SDL_MOUSEWHEEL,
			// Token: 0x04000212 RID: 530
			SDL_JOYAXISMOTION = 1536U,
			// Token: 0x04000213 RID: 531
			SDL_JOYBALLMOTION,
			// Token: 0x04000214 RID: 532
			SDL_JOYHATMOTION,
			// Token: 0x04000215 RID: 533
			SDL_JOYBUTTONDOWN,
			// Token: 0x04000216 RID: 534
			SDL_JOYBUTTONUP,
			// Token: 0x04000217 RID: 535
			SDL_JOYDEVICEADDED,
			// Token: 0x04000218 RID: 536
			SDL_JOYDEVICEREMOVED,
			// Token: 0x04000219 RID: 537
			SDL_CONTROLLERAXISMOTION = 1616U,
			// Token: 0x0400021A RID: 538
			SDL_CONTROLLERBUTTONDOWN,
			// Token: 0x0400021B RID: 539
			SDL_CONTROLLERBUTTONUP,
			// Token: 0x0400021C RID: 540
			SDL_CONTROLLERDEVICEADDED,
			// Token: 0x0400021D RID: 541
			SDL_CONTROLLERDEVICEREMOVED,
			// Token: 0x0400021E RID: 542
			SDL_CONTROLLERDEVICEREMAPPED,
			// Token: 0x0400021F RID: 543
			SDL_FINGERDOWN = 1792U,
			// Token: 0x04000220 RID: 544
			SDL_FINGERUP,
			// Token: 0x04000221 RID: 545
			SDL_FINGERMOTION,
			// Token: 0x04000222 RID: 546
			SDL_DOLLARGESTURE = 2048U,
			// Token: 0x04000223 RID: 547
			SDL_DOLLARRECORD,
			// Token: 0x04000224 RID: 548
			SDL_MULTIGESTURE,
			// Token: 0x04000225 RID: 549
			SDL_CLIPBOARDUPDATE = 2304U,
			// Token: 0x04000226 RID: 550
			SDL_DROPFILE = 4096U,
			// Token: 0x04000227 RID: 551
			SDL_DROPTEXT,
			// Token: 0x04000228 RID: 552
			SDL_DROPBEGIN,
			// Token: 0x04000229 RID: 553
			SDL_DROPCOMPLETE,
			// Token: 0x0400022A RID: 554
			SDL_AUDIODEVICEADDED = 4352U,
			// Token: 0x0400022B RID: 555
			SDL_AUDIODEVICEREMOVED,
			// Token: 0x0400022C RID: 556
			SDL_RENDER_TARGETS_RESET = 8192U,
			// Token: 0x0400022D RID: 557
			SDL_RENDER_DEVICE_RESET,
			// Token: 0x0400022E RID: 558
			SDL_USEREVENT = 32768U,
			// Token: 0x0400022F RID: 559
			SDL_LASTEVENT = 65535U
		}

		// Token: 0x0200002F RID: 47
		public enum SDL_MouseWheelDirection : uint
		{
			// Token: 0x04000231 RID: 561
			SDL_MOUSEHWEEL_NORMAL,
			// Token: 0x04000232 RID: 562
			SDL_MOUSEWHEEL_FLIPPED
		}

		// Token: 0x02000030 RID: 48
		public struct SDL_GenericEvent
		{
			// Token: 0x04000233 RID: 563
			public SDL.SDL_EventType type;

			// Token: 0x04000234 RID: 564
			public uint timestamp;
		}

		// Token: 0x02000031 RID: 49
		public struct SDL_WindowEvent
		{
			// Token: 0x04000235 RID: 565
			public SDL.SDL_EventType type;

			// Token: 0x04000236 RID: 566
			public uint timestamp;

			// Token: 0x04000237 RID: 567
			public uint windowID;

			// Token: 0x04000238 RID: 568
			public SDL.SDL_WindowEventID windowEvent;

			// Token: 0x04000239 RID: 569
			private byte padding1;

			// Token: 0x0400023A RID: 570
			private byte padding2;

			// Token: 0x0400023B RID: 571
			private byte padding3;

			// Token: 0x0400023C RID: 572
			public int data1;

			// Token: 0x0400023D RID: 573
			public int data2;
		}

		// Token: 0x02000032 RID: 50
		public struct SDL_KeyboardEvent
		{
			// Token: 0x0400023E RID: 574
			public SDL.SDL_EventType type;

			// Token: 0x0400023F RID: 575
			public uint timestamp;

			// Token: 0x04000240 RID: 576
			public uint windowID;

			// Token: 0x04000241 RID: 577
			public byte state;

			// Token: 0x04000242 RID: 578
			public byte repeat;

			// Token: 0x04000243 RID: 579
			private byte padding2;

			// Token: 0x04000244 RID: 580
			private byte padding3;

			// Token: 0x04000245 RID: 581
			public SDL.SDL_Keysym keysym;
		}

		// Token: 0x02000033 RID: 51
		public struct SDL_TextEditingEvent
		{
			// Token: 0x04000246 RID: 582
			public SDL.SDL_EventType type;

			// Token: 0x04000247 RID: 583
			public uint timestamp;

			// Token: 0x04000248 RID: 584
			public uint windowID;

			// Token: 0x04000249 RID: 585
			[FixedBuffer(typeof(byte), 32)]
			public SDL.SDL_TextEditingEvent.<text>e__FixedBuffer text;

			// Token: 0x0400024A RID: 586
			public int start;

			// Token: 0x0400024B RID: 587
			public int length;

			// Token: 0x0200007B RID: 123
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 32)]
			public struct <text>e__FixedBuffer
			{
				// Token: 0x040005CA RID: 1482
				public byte FixedElementField;
			}
		}

		// Token: 0x02000034 RID: 52
		public struct SDL_TextInputEvent
		{
			// Token: 0x0400024C RID: 588
			public SDL.SDL_EventType type;

			// Token: 0x0400024D RID: 589
			public uint timestamp;

			// Token: 0x0400024E RID: 590
			public uint windowID;

			// Token: 0x0400024F RID: 591
			[FixedBuffer(typeof(byte), 32)]
			public SDL.SDL_TextInputEvent.<text>e__FixedBuffer text;

			// Token: 0x0200007C RID: 124
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 32)]
			public struct <text>e__FixedBuffer
			{
				// Token: 0x040005CB RID: 1483
				public byte FixedElementField;
			}
		}

		// Token: 0x02000035 RID: 53
		public struct SDL_MouseMotionEvent
		{
			// Token: 0x04000250 RID: 592
			public SDL.SDL_EventType type;

			// Token: 0x04000251 RID: 593
			public uint timestamp;

			// Token: 0x04000252 RID: 594
			public uint windowID;

			// Token: 0x04000253 RID: 595
			public uint which;

			// Token: 0x04000254 RID: 596
			public byte state;

			// Token: 0x04000255 RID: 597
			private byte padding1;

			// Token: 0x04000256 RID: 598
			private byte padding2;

			// Token: 0x04000257 RID: 599
			private byte padding3;

			// Token: 0x04000258 RID: 600
			public int x;

			// Token: 0x04000259 RID: 601
			public int y;

			// Token: 0x0400025A RID: 602
			public int xrel;

			// Token: 0x0400025B RID: 603
			public int yrel;
		}

		// Token: 0x02000036 RID: 54
		public struct SDL_MouseButtonEvent
		{
			// Token: 0x0400025C RID: 604
			public SDL.SDL_EventType type;

			// Token: 0x0400025D RID: 605
			public uint timestamp;

			// Token: 0x0400025E RID: 606
			public uint windowID;

			// Token: 0x0400025F RID: 607
			public uint which;

			// Token: 0x04000260 RID: 608
			public byte button;

			// Token: 0x04000261 RID: 609
			public byte state;

			// Token: 0x04000262 RID: 610
			public byte clicks;

			// Token: 0x04000263 RID: 611
			private byte padding1;

			// Token: 0x04000264 RID: 612
			public int x;

			// Token: 0x04000265 RID: 613
			public int y;
		}

		// Token: 0x02000037 RID: 55
		public struct SDL_MouseWheelEvent
		{
			// Token: 0x04000266 RID: 614
			public SDL.SDL_EventType type;

			// Token: 0x04000267 RID: 615
			public uint timestamp;

			// Token: 0x04000268 RID: 616
			public uint windowID;

			// Token: 0x04000269 RID: 617
			public uint which;

			// Token: 0x0400026A RID: 618
			public int x;

			// Token: 0x0400026B RID: 619
			public int y;

			// Token: 0x0400026C RID: 620
			public uint direction;
		}

		// Token: 0x02000038 RID: 56
		public struct SDL_JoyAxisEvent
		{
			// Token: 0x0400026D RID: 621
			public SDL.SDL_EventType type;

			// Token: 0x0400026E RID: 622
			public uint timestamp;

			// Token: 0x0400026F RID: 623
			public int which;

			// Token: 0x04000270 RID: 624
			public byte axis;

			// Token: 0x04000271 RID: 625
			private byte padding1;

			// Token: 0x04000272 RID: 626
			private byte padding2;

			// Token: 0x04000273 RID: 627
			private byte padding3;

			// Token: 0x04000274 RID: 628
			public short axisValue;

			// Token: 0x04000275 RID: 629
			public ushort padding4;
		}

		// Token: 0x02000039 RID: 57
		public struct SDL_JoyBallEvent
		{
			// Token: 0x04000276 RID: 630
			public SDL.SDL_EventType type;

			// Token: 0x04000277 RID: 631
			public uint timestamp;

			// Token: 0x04000278 RID: 632
			public int which;

			// Token: 0x04000279 RID: 633
			public byte ball;

			// Token: 0x0400027A RID: 634
			private byte padding1;

			// Token: 0x0400027B RID: 635
			private byte padding2;

			// Token: 0x0400027C RID: 636
			private byte padding3;

			// Token: 0x0400027D RID: 637
			public short xrel;

			// Token: 0x0400027E RID: 638
			public short yrel;
		}

		// Token: 0x0200003A RID: 58
		public struct SDL_JoyHatEvent
		{
			// Token: 0x0400027F RID: 639
			public SDL.SDL_EventType type;

			// Token: 0x04000280 RID: 640
			public uint timestamp;

			// Token: 0x04000281 RID: 641
			public int which;

			// Token: 0x04000282 RID: 642
			public byte hat;

			// Token: 0x04000283 RID: 643
			public byte hatValue;

			// Token: 0x04000284 RID: 644
			private byte padding1;

			// Token: 0x04000285 RID: 645
			private byte padding2;
		}

		// Token: 0x0200003B RID: 59
		public struct SDL_JoyButtonEvent
		{
			// Token: 0x04000286 RID: 646
			public SDL.SDL_EventType type;

			// Token: 0x04000287 RID: 647
			public uint timestamp;

			// Token: 0x04000288 RID: 648
			public int which;

			// Token: 0x04000289 RID: 649
			public byte button;

			// Token: 0x0400028A RID: 650
			public byte state;

			// Token: 0x0400028B RID: 651
			private byte padding1;

			// Token: 0x0400028C RID: 652
			private byte padding2;
		}

		// Token: 0x0200003C RID: 60
		public struct SDL_JoyDeviceEvent
		{
			// Token: 0x0400028D RID: 653
			public SDL.SDL_EventType type;

			// Token: 0x0400028E RID: 654
			public uint timestamp;

			// Token: 0x0400028F RID: 655
			public int which;
		}

		// Token: 0x0200003D RID: 61
		public struct SDL_ControllerAxisEvent
		{
			// Token: 0x04000290 RID: 656
			public SDL.SDL_EventType type;

			// Token: 0x04000291 RID: 657
			public uint timestamp;

			// Token: 0x04000292 RID: 658
			public int which;

			// Token: 0x04000293 RID: 659
			public byte axis;

			// Token: 0x04000294 RID: 660
			private byte padding1;

			// Token: 0x04000295 RID: 661
			private byte padding2;

			// Token: 0x04000296 RID: 662
			private byte padding3;

			// Token: 0x04000297 RID: 663
			public short axisValue;

			// Token: 0x04000298 RID: 664
			private ushort padding4;
		}

		// Token: 0x0200003E RID: 62
		public struct SDL_ControllerButtonEvent
		{
			// Token: 0x04000299 RID: 665
			public SDL.SDL_EventType type;

			// Token: 0x0400029A RID: 666
			public uint timestamp;

			// Token: 0x0400029B RID: 667
			public int which;

			// Token: 0x0400029C RID: 668
			public byte button;

			// Token: 0x0400029D RID: 669
			public byte state;

			// Token: 0x0400029E RID: 670
			private byte padding1;

			// Token: 0x0400029F RID: 671
			private byte padding2;
		}

		// Token: 0x0200003F RID: 63
		public struct SDL_ControllerDeviceEvent
		{
			// Token: 0x040002A0 RID: 672
			public SDL.SDL_EventType type;

			// Token: 0x040002A1 RID: 673
			public uint timestamp;

			// Token: 0x040002A2 RID: 674
			public int which;
		}

		// Token: 0x02000040 RID: 64
		public struct SDL_TouchFingerEvent
		{
			// Token: 0x040002A3 RID: 675
			public uint type;

			// Token: 0x040002A4 RID: 676
			public uint timestamp;

			// Token: 0x040002A5 RID: 677
			public long touchId;

			// Token: 0x040002A6 RID: 678
			public long fingerId;

			// Token: 0x040002A7 RID: 679
			public float x;

			// Token: 0x040002A8 RID: 680
			public float y;

			// Token: 0x040002A9 RID: 681
			public float dx;

			// Token: 0x040002AA RID: 682
			public float dy;

			// Token: 0x040002AB RID: 683
			public float pressure;
		}

		// Token: 0x02000041 RID: 65
		public struct SDL_MultiGestureEvent
		{
			// Token: 0x040002AC RID: 684
			public uint type;

			// Token: 0x040002AD RID: 685
			public uint timestamp;

			// Token: 0x040002AE RID: 686
			public long touchId;

			// Token: 0x040002AF RID: 687
			public float dTheta;

			// Token: 0x040002B0 RID: 688
			public float dDist;

			// Token: 0x040002B1 RID: 689
			public float x;

			// Token: 0x040002B2 RID: 690
			public float y;

			// Token: 0x040002B3 RID: 691
			public ushort numFingers;

			// Token: 0x040002B4 RID: 692
			public ushort padding;
		}

		// Token: 0x02000042 RID: 66
		public struct SDL_DollarGestureEvent
		{
			// Token: 0x040002B5 RID: 693
			public uint type;

			// Token: 0x040002B6 RID: 694
			public uint timestamp;

			// Token: 0x040002B7 RID: 695
			public long touchId;

			// Token: 0x040002B8 RID: 696
			public long gestureId;

			// Token: 0x040002B9 RID: 697
			public uint numFingers;

			// Token: 0x040002BA RID: 698
			public float error;

			// Token: 0x040002BB RID: 699
			public float x;

			// Token: 0x040002BC RID: 700
			public float y;
		}

		// Token: 0x02000043 RID: 67
		public struct SDL_DropEvent
		{
			// Token: 0x040002BD RID: 701
			public SDL.SDL_EventType type;

			// Token: 0x040002BE RID: 702
			public uint timestamp;

			// Token: 0x040002BF RID: 703
			public IntPtr file;
		}

		// Token: 0x02000044 RID: 68
		public struct SDL_QuitEvent
		{
			// Token: 0x040002C0 RID: 704
			public SDL.SDL_EventType type;

			// Token: 0x040002C1 RID: 705
			public uint timestamp;
		}

		// Token: 0x02000045 RID: 69
		public struct SDL_UserEvent
		{
			// Token: 0x040002C2 RID: 706
			public uint type;

			// Token: 0x040002C3 RID: 707
			public uint timestamp;

			// Token: 0x040002C4 RID: 708
			public uint windowID;

			// Token: 0x040002C5 RID: 709
			public int code;

			// Token: 0x040002C6 RID: 710
			public IntPtr data1;

			// Token: 0x040002C7 RID: 711
			public IntPtr data2;
		}

		// Token: 0x02000046 RID: 70
		public struct SDL_SysWMEvent
		{
			// Token: 0x040002C8 RID: 712
			public SDL.SDL_EventType type;

			// Token: 0x040002C9 RID: 713
			public uint timestamp;

			// Token: 0x040002CA RID: 714
			public IntPtr msg;
		}

		// Token: 0x02000047 RID: 71
		[StructLayout(LayoutKind.Explicit)]
		public struct SDL_Event
		{
			// Token: 0x040002CB RID: 715
			[FieldOffset(0)]
			public SDL.SDL_EventType type;

			// Token: 0x040002CC RID: 716
			[FieldOffset(0)]
			public SDL.SDL_WindowEvent window;

			// Token: 0x040002CD RID: 717
			[FieldOffset(0)]
			public SDL.SDL_KeyboardEvent key;

			// Token: 0x040002CE RID: 718
			[FieldOffset(0)]
			public SDL.SDL_TextEditingEvent edit;

			// Token: 0x040002CF RID: 719
			[FieldOffset(0)]
			public SDL.SDL_TextInputEvent text;

			// Token: 0x040002D0 RID: 720
			[FieldOffset(0)]
			public SDL.SDL_MouseMotionEvent motion;

			// Token: 0x040002D1 RID: 721
			[FieldOffset(0)]
			public SDL.SDL_MouseButtonEvent button;

			// Token: 0x040002D2 RID: 722
			[FieldOffset(0)]
			public SDL.SDL_MouseWheelEvent wheel;

			// Token: 0x040002D3 RID: 723
			[FieldOffset(0)]
			public SDL.SDL_JoyAxisEvent jaxis;

			// Token: 0x040002D4 RID: 724
			[FieldOffset(0)]
			public SDL.SDL_JoyBallEvent jball;

			// Token: 0x040002D5 RID: 725
			[FieldOffset(0)]
			public SDL.SDL_JoyHatEvent jhat;

			// Token: 0x040002D6 RID: 726
			[FieldOffset(0)]
			public SDL.SDL_JoyButtonEvent jbutton;

			// Token: 0x040002D7 RID: 727
			[FieldOffset(0)]
			public SDL.SDL_JoyDeviceEvent jdevice;

			// Token: 0x040002D8 RID: 728
			[FieldOffset(0)]
			public SDL.SDL_ControllerAxisEvent caxis;

			// Token: 0x040002D9 RID: 729
			[FieldOffset(0)]
			public SDL.SDL_ControllerButtonEvent cbutton;

			// Token: 0x040002DA RID: 730
			[FieldOffset(0)]
			public SDL.SDL_ControllerDeviceEvent cdevice;

			// Token: 0x040002DB RID: 731
			[FieldOffset(0)]
			public SDL.SDL_QuitEvent quit;

			// Token: 0x040002DC RID: 732
			[FieldOffset(0)]
			public SDL.SDL_UserEvent user;

			// Token: 0x040002DD RID: 733
			[FieldOffset(0)]
			public SDL.SDL_SysWMEvent syswm;

			// Token: 0x040002DE RID: 734
			[FieldOffset(0)]
			public SDL.SDL_TouchFingerEvent tfinger;

			// Token: 0x040002DF RID: 735
			[FieldOffset(0)]
			public SDL.SDL_MultiGestureEvent mgesture;

			// Token: 0x040002E0 RID: 736
			[FieldOffset(0)]
			public SDL.SDL_DollarGestureEvent dgesture;

			// Token: 0x040002E1 RID: 737
			[FieldOffset(0)]
			public SDL.SDL_DropEvent drop;
		}

		// Token: 0x02000048 RID: 72
		// (Invoke) Token: 0x06000288 RID: 648
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int SDL_EventFilter(IntPtr userdata, IntPtr sdlevent);

		// Token: 0x02000049 RID: 73
		public enum SDL_eventaction
		{
			// Token: 0x040002E3 RID: 739
			SDL_ADDEVENT,
			// Token: 0x040002E4 RID: 740
			SDL_PEEKEVENT,
			// Token: 0x040002E5 RID: 741
			SDL_GETEVENT
		}

		// Token: 0x0200004A RID: 74
		public enum SDL_Scancode
		{
			// Token: 0x040002E7 RID: 743
			SDL_SCANCODE_UNKNOWN,
			// Token: 0x040002E8 RID: 744
			SDL_SCANCODE_A = 4,
			// Token: 0x040002E9 RID: 745
			SDL_SCANCODE_B,
			// Token: 0x040002EA RID: 746
			SDL_SCANCODE_C,
			// Token: 0x040002EB RID: 747
			SDL_SCANCODE_D,
			// Token: 0x040002EC RID: 748
			SDL_SCANCODE_E,
			// Token: 0x040002ED RID: 749
			SDL_SCANCODE_F,
			// Token: 0x040002EE RID: 750
			SDL_SCANCODE_G,
			// Token: 0x040002EF RID: 751
			SDL_SCANCODE_H,
			// Token: 0x040002F0 RID: 752
			SDL_SCANCODE_I,
			// Token: 0x040002F1 RID: 753
			SDL_SCANCODE_J,
			// Token: 0x040002F2 RID: 754
			SDL_SCANCODE_K,
			// Token: 0x040002F3 RID: 755
			SDL_SCANCODE_L,
			// Token: 0x040002F4 RID: 756
			SDL_SCANCODE_M,
			// Token: 0x040002F5 RID: 757
			SDL_SCANCODE_N,
			// Token: 0x040002F6 RID: 758
			SDL_SCANCODE_O,
			// Token: 0x040002F7 RID: 759
			SDL_SCANCODE_P,
			// Token: 0x040002F8 RID: 760
			SDL_SCANCODE_Q,
			// Token: 0x040002F9 RID: 761
			SDL_SCANCODE_R,
			// Token: 0x040002FA RID: 762
			SDL_SCANCODE_S,
			// Token: 0x040002FB RID: 763
			SDL_SCANCODE_T,
			// Token: 0x040002FC RID: 764
			SDL_SCANCODE_U,
			// Token: 0x040002FD RID: 765
			SDL_SCANCODE_V,
			// Token: 0x040002FE RID: 766
			SDL_SCANCODE_W,
			// Token: 0x040002FF RID: 767
			SDL_SCANCODE_X,
			// Token: 0x04000300 RID: 768
			SDL_SCANCODE_Y,
			// Token: 0x04000301 RID: 769
			SDL_SCANCODE_Z,
			// Token: 0x04000302 RID: 770
			SDL_SCANCODE_1,
			// Token: 0x04000303 RID: 771
			SDL_SCANCODE_2,
			// Token: 0x04000304 RID: 772
			SDL_SCANCODE_3,
			// Token: 0x04000305 RID: 773
			SDL_SCANCODE_4,
			// Token: 0x04000306 RID: 774
			SDL_SCANCODE_5,
			// Token: 0x04000307 RID: 775
			SDL_SCANCODE_6,
			// Token: 0x04000308 RID: 776
			SDL_SCANCODE_7,
			// Token: 0x04000309 RID: 777
			SDL_SCANCODE_8,
			// Token: 0x0400030A RID: 778
			SDL_SCANCODE_9,
			// Token: 0x0400030B RID: 779
			SDL_SCANCODE_0,
			// Token: 0x0400030C RID: 780
			SDL_SCANCODE_RETURN,
			// Token: 0x0400030D RID: 781
			SDL_SCANCODE_ESCAPE,
			// Token: 0x0400030E RID: 782
			SDL_SCANCODE_BACKSPACE,
			// Token: 0x0400030F RID: 783
			SDL_SCANCODE_TAB,
			// Token: 0x04000310 RID: 784
			SDL_SCANCODE_SPACE,
			// Token: 0x04000311 RID: 785
			SDL_SCANCODE_MINUS,
			// Token: 0x04000312 RID: 786
			SDL_SCANCODE_EQUALS,
			// Token: 0x04000313 RID: 787
			SDL_SCANCODE_LEFTBRACKET,
			// Token: 0x04000314 RID: 788
			SDL_SCANCODE_RIGHTBRACKET,
			// Token: 0x04000315 RID: 789
			SDL_SCANCODE_BACKSLASH,
			// Token: 0x04000316 RID: 790
			SDL_SCANCODE_NONUSHASH,
			// Token: 0x04000317 RID: 791
			SDL_SCANCODE_SEMICOLON,
			// Token: 0x04000318 RID: 792
			SDL_SCANCODE_APOSTROPHE,
			// Token: 0x04000319 RID: 793
			SDL_SCANCODE_GRAVE,
			// Token: 0x0400031A RID: 794
			SDL_SCANCODE_COMMA,
			// Token: 0x0400031B RID: 795
			SDL_SCANCODE_PERIOD,
			// Token: 0x0400031C RID: 796
			SDL_SCANCODE_SLASH,
			// Token: 0x0400031D RID: 797
			SDL_SCANCODE_CAPSLOCK,
			// Token: 0x0400031E RID: 798
			SDL_SCANCODE_F1,
			// Token: 0x0400031F RID: 799
			SDL_SCANCODE_F2,
			// Token: 0x04000320 RID: 800
			SDL_SCANCODE_F3,
			// Token: 0x04000321 RID: 801
			SDL_SCANCODE_F4,
			// Token: 0x04000322 RID: 802
			SDL_SCANCODE_F5,
			// Token: 0x04000323 RID: 803
			SDL_SCANCODE_F6,
			// Token: 0x04000324 RID: 804
			SDL_SCANCODE_F7,
			// Token: 0x04000325 RID: 805
			SDL_SCANCODE_F8,
			// Token: 0x04000326 RID: 806
			SDL_SCANCODE_F9,
			// Token: 0x04000327 RID: 807
			SDL_SCANCODE_F10,
			// Token: 0x04000328 RID: 808
			SDL_SCANCODE_F11,
			// Token: 0x04000329 RID: 809
			SDL_SCANCODE_F12,
			// Token: 0x0400032A RID: 810
			SDL_SCANCODE_PRINTSCREEN,
			// Token: 0x0400032B RID: 811
			SDL_SCANCODE_SCROLLLOCK,
			// Token: 0x0400032C RID: 812
			SDL_SCANCODE_PAUSE,
			// Token: 0x0400032D RID: 813
			SDL_SCANCODE_INSERT,
			// Token: 0x0400032E RID: 814
			SDL_SCANCODE_HOME,
			// Token: 0x0400032F RID: 815
			SDL_SCANCODE_PAGEUP,
			// Token: 0x04000330 RID: 816
			SDL_SCANCODE_DELETE,
			// Token: 0x04000331 RID: 817
			SDL_SCANCODE_END,
			// Token: 0x04000332 RID: 818
			SDL_SCANCODE_PAGEDOWN,
			// Token: 0x04000333 RID: 819
			SDL_SCANCODE_RIGHT,
			// Token: 0x04000334 RID: 820
			SDL_SCANCODE_LEFT,
			// Token: 0x04000335 RID: 821
			SDL_SCANCODE_DOWN,
			// Token: 0x04000336 RID: 822
			SDL_SCANCODE_UP,
			// Token: 0x04000337 RID: 823
			SDL_SCANCODE_NUMLOCKCLEAR,
			// Token: 0x04000338 RID: 824
			SDL_SCANCODE_KP_DIVIDE,
			// Token: 0x04000339 RID: 825
			SDL_SCANCODE_KP_MULTIPLY,
			// Token: 0x0400033A RID: 826
			SDL_SCANCODE_KP_MINUS,
			// Token: 0x0400033B RID: 827
			SDL_SCANCODE_KP_PLUS,
			// Token: 0x0400033C RID: 828
			SDL_SCANCODE_KP_ENTER,
			// Token: 0x0400033D RID: 829
			SDL_SCANCODE_KP_1,
			// Token: 0x0400033E RID: 830
			SDL_SCANCODE_KP_2,
			// Token: 0x0400033F RID: 831
			SDL_SCANCODE_KP_3,
			// Token: 0x04000340 RID: 832
			SDL_SCANCODE_KP_4,
			// Token: 0x04000341 RID: 833
			SDL_SCANCODE_KP_5,
			// Token: 0x04000342 RID: 834
			SDL_SCANCODE_KP_6,
			// Token: 0x04000343 RID: 835
			SDL_SCANCODE_KP_7,
			// Token: 0x04000344 RID: 836
			SDL_SCANCODE_KP_8,
			// Token: 0x04000345 RID: 837
			SDL_SCANCODE_KP_9,
			// Token: 0x04000346 RID: 838
			SDL_SCANCODE_KP_0,
			// Token: 0x04000347 RID: 839
			SDL_SCANCODE_KP_PERIOD,
			// Token: 0x04000348 RID: 840
			SDL_SCANCODE_NONUSBACKSLASH,
			// Token: 0x04000349 RID: 841
			SDL_SCANCODE_APPLICATION,
			// Token: 0x0400034A RID: 842
			SDL_SCANCODE_POWER,
			// Token: 0x0400034B RID: 843
			SDL_SCANCODE_KP_EQUALS,
			// Token: 0x0400034C RID: 844
			SDL_SCANCODE_F13,
			// Token: 0x0400034D RID: 845
			SDL_SCANCODE_F14,
			// Token: 0x0400034E RID: 846
			SDL_SCANCODE_F15,
			// Token: 0x0400034F RID: 847
			SDL_SCANCODE_F16,
			// Token: 0x04000350 RID: 848
			SDL_SCANCODE_F17,
			// Token: 0x04000351 RID: 849
			SDL_SCANCODE_F18,
			// Token: 0x04000352 RID: 850
			SDL_SCANCODE_F19,
			// Token: 0x04000353 RID: 851
			SDL_SCANCODE_F20,
			// Token: 0x04000354 RID: 852
			SDL_SCANCODE_F21,
			// Token: 0x04000355 RID: 853
			SDL_SCANCODE_F22,
			// Token: 0x04000356 RID: 854
			SDL_SCANCODE_F23,
			// Token: 0x04000357 RID: 855
			SDL_SCANCODE_F24,
			// Token: 0x04000358 RID: 856
			SDL_SCANCODE_EXECUTE,
			// Token: 0x04000359 RID: 857
			SDL_SCANCODE_HELP,
			// Token: 0x0400035A RID: 858
			SDL_SCANCODE_MENU,
			// Token: 0x0400035B RID: 859
			SDL_SCANCODE_SELECT,
			// Token: 0x0400035C RID: 860
			SDL_SCANCODE_STOP,
			// Token: 0x0400035D RID: 861
			SDL_SCANCODE_AGAIN,
			// Token: 0x0400035E RID: 862
			SDL_SCANCODE_UNDO,
			// Token: 0x0400035F RID: 863
			SDL_SCANCODE_CUT,
			// Token: 0x04000360 RID: 864
			SDL_SCANCODE_COPY,
			// Token: 0x04000361 RID: 865
			SDL_SCANCODE_PASTE,
			// Token: 0x04000362 RID: 866
			SDL_SCANCODE_FIND,
			// Token: 0x04000363 RID: 867
			SDL_SCANCODE_MUTE,
			// Token: 0x04000364 RID: 868
			SDL_SCANCODE_VOLUMEUP,
			// Token: 0x04000365 RID: 869
			SDL_SCANCODE_VOLUMEDOWN,
			// Token: 0x04000366 RID: 870
			SDL_SCANCODE_KP_COMMA = 133,
			// Token: 0x04000367 RID: 871
			SDL_SCANCODE_KP_EQUALSAS400,
			// Token: 0x04000368 RID: 872
			SDL_SCANCODE_INTERNATIONAL1,
			// Token: 0x04000369 RID: 873
			SDL_SCANCODE_INTERNATIONAL2,
			// Token: 0x0400036A RID: 874
			SDL_SCANCODE_INTERNATIONAL3,
			// Token: 0x0400036B RID: 875
			SDL_SCANCODE_INTERNATIONAL4,
			// Token: 0x0400036C RID: 876
			SDL_SCANCODE_INTERNATIONAL5,
			// Token: 0x0400036D RID: 877
			SDL_SCANCODE_INTERNATIONAL6,
			// Token: 0x0400036E RID: 878
			SDL_SCANCODE_INTERNATIONAL7,
			// Token: 0x0400036F RID: 879
			SDL_SCANCODE_INTERNATIONAL8,
			// Token: 0x04000370 RID: 880
			SDL_SCANCODE_INTERNATIONAL9,
			// Token: 0x04000371 RID: 881
			SDL_SCANCODE_LANG1,
			// Token: 0x04000372 RID: 882
			SDL_SCANCODE_LANG2,
			// Token: 0x04000373 RID: 883
			SDL_SCANCODE_LANG3,
			// Token: 0x04000374 RID: 884
			SDL_SCANCODE_LANG4,
			// Token: 0x04000375 RID: 885
			SDL_SCANCODE_LANG5,
			// Token: 0x04000376 RID: 886
			SDL_SCANCODE_LANG6,
			// Token: 0x04000377 RID: 887
			SDL_SCANCODE_LANG7,
			// Token: 0x04000378 RID: 888
			SDL_SCANCODE_LANG8,
			// Token: 0x04000379 RID: 889
			SDL_SCANCODE_LANG9,
			// Token: 0x0400037A RID: 890
			SDL_SCANCODE_ALTERASE,
			// Token: 0x0400037B RID: 891
			SDL_SCANCODE_SYSREQ,
			// Token: 0x0400037C RID: 892
			SDL_SCANCODE_CANCEL,
			// Token: 0x0400037D RID: 893
			SDL_SCANCODE_CLEAR,
			// Token: 0x0400037E RID: 894
			SDL_SCANCODE_PRIOR,
			// Token: 0x0400037F RID: 895
			SDL_SCANCODE_RETURN2,
			// Token: 0x04000380 RID: 896
			SDL_SCANCODE_SEPARATOR,
			// Token: 0x04000381 RID: 897
			SDL_SCANCODE_OUT,
			// Token: 0x04000382 RID: 898
			SDL_SCANCODE_OPER,
			// Token: 0x04000383 RID: 899
			SDL_SCANCODE_CLEARAGAIN,
			// Token: 0x04000384 RID: 900
			SDL_SCANCODE_CRSEL,
			// Token: 0x04000385 RID: 901
			SDL_SCANCODE_EXSEL,
			// Token: 0x04000386 RID: 902
			SDL_SCANCODE_KP_00 = 176,
			// Token: 0x04000387 RID: 903
			SDL_SCANCODE_KP_000,
			// Token: 0x04000388 RID: 904
			SDL_SCANCODE_THOUSANDSSEPARATOR,
			// Token: 0x04000389 RID: 905
			SDL_SCANCODE_DECIMALSEPARATOR,
			// Token: 0x0400038A RID: 906
			SDL_SCANCODE_CURRENCYUNIT,
			// Token: 0x0400038B RID: 907
			SDL_SCANCODE_CURRENCYSUBUNIT,
			// Token: 0x0400038C RID: 908
			SDL_SCANCODE_KP_LEFTPAREN,
			// Token: 0x0400038D RID: 909
			SDL_SCANCODE_KP_RIGHTPAREN,
			// Token: 0x0400038E RID: 910
			SDL_SCANCODE_KP_LEFTBRACE,
			// Token: 0x0400038F RID: 911
			SDL_SCANCODE_KP_RIGHTBRACE,
			// Token: 0x04000390 RID: 912
			SDL_SCANCODE_KP_TAB,
			// Token: 0x04000391 RID: 913
			SDL_SCANCODE_KP_BACKSPACE,
			// Token: 0x04000392 RID: 914
			SDL_SCANCODE_KP_A,
			// Token: 0x04000393 RID: 915
			SDL_SCANCODE_KP_B,
			// Token: 0x04000394 RID: 916
			SDL_SCANCODE_KP_C,
			// Token: 0x04000395 RID: 917
			SDL_SCANCODE_KP_D,
			// Token: 0x04000396 RID: 918
			SDL_SCANCODE_KP_E,
			// Token: 0x04000397 RID: 919
			SDL_SCANCODE_KP_F,
			// Token: 0x04000398 RID: 920
			SDL_SCANCODE_KP_XOR,
			// Token: 0x04000399 RID: 921
			SDL_SCANCODE_KP_POWER,
			// Token: 0x0400039A RID: 922
			SDL_SCANCODE_KP_PERCENT,
			// Token: 0x0400039B RID: 923
			SDL_SCANCODE_KP_LESS,
			// Token: 0x0400039C RID: 924
			SDL_SCANCODE_KP_GREATER,
			// Token: 0x0400039D RID: 925
			SDL_SCANCODE_KP_AMPERSAND,
			// Token: 0x0400039E RID: 926
			SDL_SCANCODE_KP_DBLAMPERSAND,
			// Token: 0x0400039F RID: 927
			SDL_SCANCODE_KP_VERTICALBAR,
			// Token: 0x040003A0 RID: 928
			SDL_SCANCODE_KP_DBLVERTICALBAR,
			// Token: 0x040003A1 RID: 929
			SDL_SCANCODE_KP_COLON,
			// Token: 0x040003A2 RID: 930
			SDL_SCANCODE_KP_HASH,
			// Token: 0x040003A3 RID: 931
			SDL_SCANCODE_KP_SPACE,
			// Token: 0x040003A4 RID: 932
			SDL_SCANCODE_KP_AT,
			// Token: 0x040003A5 RID: 933
			SDL_SCANCODE_KP_EXCLAM,
			// Token: 0x040003A6 RID: 934
			SDL_SCANCODE_KP_MEMSTORE,
			// Token: 0x040003A7 RID: 935
			SDL_SCANCODE_KP_MEMRECALL,
			// Token: 0x040003A8 RID: 936
			SDL_SCANCODE_KP_MEMCLEAR,
			// Token: 0x040003A9 RID: 937
			SDL_SCANCODE_KP_MEMADD,
			// Token: 0x040003AA RID: 938
			SDL_SCANCODE_KP_MEMSUBTRACT,
			// Token: 0x040003AB RID: 939
			SDL_SCANCODE_KP_MEMMULTIPLY,
			// Token: 0x040003AC RID: 940
			SDL_SCANCODE_KP_MEMDIVIDE,
			// Token: 0x040003AD RID: 941
			SDL_SCANCODE_KP_PLUSMINUS,
			// Token: 0x040003AE RID: 942
			SDL_SCANCODE_KP_CLEAR,
			// Token: 0x040003AF RID: 943
			SDL_SCANCODE_KP_CLEARENTRY,
			// Token: 0x040003B0 RID: 944
			SDL_SCANCODE_KP_BINARY,
			// Token: 0x040003B1 RID: 945
			SDL_SCANCODE_KP_OCTAL,
			// Token: 0x040003B2 RID: 946
			SDL_SCANCODE_KP_DECIMAL,
			// Token: 0x040003B3 RID: 947
			SDL_SCANCODE_KP_HEXADECIMAL,
			// Token: 0x040003B4 RID: 948
			SDL_SCANCODE_LCTRL = 224,
			// Token: 0x040003B5 RID: 949
			SDL_SCANCODE_LSHIFT,
			// Token: 0x040003B6 RID: 950
			SDL_SCANCODE_LALT,
			// Token: 0x040003B7 RID: 951
			SDL_SCANCODE_LGUI,
			// Token: 0x040003B8 RID: 952
			SDL_SCANCODE_RCTRL,
			// Token: 0x040003B9 RID: 953
			SDL_SCANCODE_RSHIFT,
			// Token: 0x040003BA RID: 954
			SDL_SCANCODE_RALT,
			// Token: 0x040003BB RID: 955
			SDL_SCANCODE_RGUI,
			// Token: 0x040003BC RID: 956
			SDL_SCANCODE_MODE = 257,
			// Token: 0x040003BD RID: 957
			SDL_SCANCODE_AUDIONEXT,
			// Token: 0x040003BE RID: 958
			SDL_SCANCODE_AUDIOPREV,
			// Token: 0x040003BF RID: 959
			SDL_SCANCODE_AUDIOSTOP,
			// Token: 0x040003C0 RID: 960
			SDL_SCANCODE_AUDIOPLAY,
			// Token: 0x040003C1 RID: 961
			SDL_SCANCODE_AUDIOMUTE,
			// Token: 0x040003C2 RID: 962
			SDL_SCANCODE_MEDIASELECT,
			// Token: 0x040003C3 RID: 963
			SDL_SCANCODE_WWW,
			// Token: 0x040003C4 RID: 964
			SDL_SCANCODE_MAIL,
			// Token: 0x040003C5 RID: 965
			SDL_SCANCODE_CALCULATOR,
			// Token: 0x040003C6 RID: 966
			SDL_SCANCODE_COMPUTER,
			// Token: 0x040003C7 RID: 967
			SDL_SCANCODE_AC_SEARCH,
			// Token: 0x040003C8 RID: 968
			SDL_SCANCODE_AC_HOME,
			// Token: 0x040003C9 RID: 969
			SDL_SCANCODE_AC_BACK,
			// Token: 0x040003CA RID: 970
			SDL_SCANCODE_AC_FORWARD,
			// Token: 0x040003CB RID: 971
			SDL_SCANCODE_AC_STOP,
			// Token: 0x040003CC RID: 972
			SDL_SCANCODE_AC_REFRESH,
			// Token: 0x040003CD RID: 973
			SDL_SCANCODE_AC_BOOKMARKS,
			// Token: 0x040003CE RID: 974
			SDL_SCANCODE_BRIGHTNESSDOWN,
			// Token: 0x040003CF RID: 975
			SDL_SCANCODE_BRIGHTNESSUP,
			// Token: 0x040003D0 RID: 976
			SDL_SCANCODE_DISPLAYSWITCH,
			// Token: 0x040003D1 RID: 977
			SDL_SCANCODE_KBDILLUMTOGGLE,
			// Token: 0x040003D2 RID: 978
			SDL_SCANCODE_KBDILLUMDOWN,
			// Token: 0x040003D3 RID: 979
			SDL_SCANCODE_KBDILLUMUP,
			// Token: 0x040003D4 RID: 980
			SDL_SCANCODE_EJECT,
			// Token: 0x040003D5 RID: 981
			SDL_SCANCODE_SLEEP,
			// Token: 0x040003D6 RID: 982
			SDL_SCANCODE_APP1,
			// Token: 0x040003D7 RID: 983
			SDL_SCANCODE_APP2,
			// Token: 0x040003D8 RID: 984
			SDL_NUM_SCANCODES = 512
		}

		// Token: 0x0200004B RID: 75
		public enum SDL_Keycode
		{
			// Token: 0x040003DA RID: 986
			SDLK_UNKNOWN,
			// Token: 0x040003DB RID: 987
			SDLK_RETURN = 13,
			// Token: 0x040003DC RID: 988
			SDLK_ESCAPE = 27,
			// Token: 0x040003DD RID: 989
			SDLK_BACKSPACE = 8,
			// Token: 0x040003DE RID: 990
			SDLK_TAB,
			// Token: 0x040003DF RID: 991
			SDLK_SPACE = 32,
			// Token: 0x040003E0 RID: 992
			SDLK_EXCLAIM,
			// Token: 0x040003E1 RID: 993
			SDLK_QUOTEDBL,
			// Token: 0x040003E2 RID: 994
			SDLK_HASH,
			// Token: 0x040003E3 RID: 995
			SDLK_PERCENT = 37,
			// Token: 0x040003E4 RID: 996
			SDLK_DOLLAR = 36,
			// Token: 0x040003E5 RID: 997
			SDLK_AMPERSAND = 38,
			// Token: 0x040003E6 RID: 998
			SDLK_QUOTE,
			// Token: 0x040003E7 RID: 999
			SDLK_LEFTPAREN,
			// Token: 0x040003E8 RID: 1000
			SDLK_RIGHTPAREN,
			// Token: 0x040003E9 RID: 1001
			SDLK_ASTERISK,
			// Token: 0x040003EA RID: 1002
			SDLK_PLUS,
			// Token: 0x040003EB RID: 1003
			SDLK_COMMA,
			// Token: 0x040003EC RID: 1004
			SDLK_MINUS,
			// Token: 0x040003ED RID: 1005
			SDLK_PERIOD,
			// Token: 0x040003EE RID: 1006
			SDLK_SLASH,
			// Token: 0x040003EF RID: 1007
			SDLK_0,
			// Token: 0x040003F0 RID: 1008
			SDLK_1,
			// Token: 0x040003F1 RID: 1009
			SDLK_2,
			// Token: 0x040003F2 RID: 1010
			SDLK_3,
			// Token: 0x040003F3 RID: 1011
			SDLK_4,
			// Token: 0x040003F4 RID: 1012
			SDLK_5,
			// Token: 0x040003F5 RID: 1013
			SDLK_6,
			// Token: 0x040003F6 RID: 1014
			SDLK_7,
			// Token: 0x040003F7 RID: 1015
			SDLK_8,
			// Token: 0x040003F8 RID: 1016
			SDLK_9,
			// Token: 0x040003F9 RID: 1017
			SDLK_COLON,
			// Token: 0x040003FA RID: 1018
			SDLK_SEMICOLON,
			// Token: 0x040003FB RID: 1019
			SDLK_LESS,
			// Token: 0x040003FC RID: 1020
			SDLK_EQUALS,
			// Token: 0x040003FD RID: 1021
			SDLK_GREATER,
			// Token: 0x040003FE RID: 1022
			SDLK_QUESTION,
			// Token: 0x040003FF RID: 1023
			SDLK_AT,
			// Token: 0x04000400 RID: 1024
			SDLK_LEFTBRACKET = 91,
			// Token: 0x04000401 RID: 1025
			SDLK_BACKSLASH,
			// Token: 0x04000402 RID: 1026
			SDLK_RIGHTBRACKET,
			// Token: 0x04000403 RID: 1027
			SDLK_CARET,
			// Token: 0x04000404 RID: 1028
			SDLK_UNDERSCORE,
			// Token: 0x04000405 RID: 1029
			SDLK_BACKQUOTE,
			// Token: 0x04000406 RID: 1030
			SDLK_a,
			// Token: 0x04000407 RID: 1031
			SDLK_b,
			// Token: 0x04000408 RID: 1032
			SDLK_c,
			// Token: 0x04000409 RID: 1033
			SDLK_d,
			// Token: 0x0400040A RID: 1034
			SDLK_e,
			// Token: 0x0400040B RID: 1035
			SDLK_f,
			// Token: 0x0400040C RID: 1036
			SDLK_g,
			// Token: 0x0400040D RID: 1037
			SDLK_h,
			// Token: 0x0400040E RID: 1038
			SDLK_i,
			// Token: 0x0400040F RID: 1039
			SDLK_j,
			// Token: 0x04000410 RID: 1040
			SDLK_k,
			// Token: 0x04000411 RID: 1041
			SDLK_l,
			// Token: 0x04000412 RID: 1042
			SDLK_m,
			// Token: 0x04000413 RID: 1043
			SDLK_n,
			// Token: 0x04000414 RID: 1044
			SDLK_o,
			// Token: 0x04000415 RID: 1045
			SDLK_p,
			// Token: 0x04000416 RID: 1046
			SDLK_q,
			// Token: 0x04000417 RID: 1047
			SDLK_r,
			// Token: 0x04000418 RID: 1048
			SDLK_s,
			// Token: 0x04000419 RID: 1049
			SDLK_t,
			// Token: 0x0400041A RID: 1050
			SDLK_u,
			// Token: 0x0400041B RID: 1051
			SDLK_v,
			// Token: 0x0400041C RID: 1052
			SDLK_w,
			// Token: 0x0400041D RID: 1053
			SDLK_x,
			// Token: 0x0400041E RID: 1054
			SDLK_y,
			// Token: 0x0400041F RID: 1055
			SDLK_z,
			// Token: 0x04000420 RID: 1056
			SDLK_CAPSLOCK = 1073741881,
			// Token: 0x04000421 RID: 1057
			SDLK_F1,
			// Token: 0x04000422 RID: 1058
			SDLK_F2,
			// Token: 0x04000423 RID: 1059
			SDLK_F3,
			// Token: 0x04000424 RID: 1060
			SDLK_F4,
			// Token: 0x04000425 RID: 1061
			SDLK_F5,
			// Token: 0x04000426 RID: 1062
			SDLK_F6,
			// Token: 0x04000427 RID: 1063
			SDLK_F7,
			// Token: 0x04000428 RID: 1064
			SDLK_F8,
			// Token: 0x04000429 RID: 1065
			SDLK_F9,
			// Token: 0x0400042A RID: 1066
			SDLK_F10,
			// Token: 0x0400042B RID: 1067
			SDLK_F11,
			// Token: 0x0400042C RID: 1068
			SDLK_F12,
			// Token: 0x0400042D RID: 1069
			SDLK_PRINTSCREEN,
			// Token: 0x0400042E RID: 1070
			SDLK_SCROLLLOCK,
			// Token: 0x0400042F RID: 1071
			SDLK_PAUSE,
			// Token: 0x04000430 RID: 1072
			SDLK_INSERT,
			// Token: 0x04000431 RID: 1073
			SDLK_HOME,
			// Token: 0x04000432 RID: 1074
			SDLK_PAGEUP,
			// Token: 0x04000433 RID: 1075
			SDLK_DELETE = 127,
			// Token: 0x04000434 RID: 1076
			SDLK_END = 1073741901,
			// Token: 0x04000435 RID: 1077
			SDLK_PAGEDOWN,
			// Token: 0x04000436 RID: 1078
			SDLK_RIGHT,
			// Token: 0x04000437 RID: 1079
			SDLK_LEFT,
			// Token: 0x04000438 RID: 1080
			SDLK_DOWN,
			// Token: 0x04000439 RID: 1081
			SDLK_UP,
			// Token: 0x0400043A RID: 1082
			SDLK_NUMLOCKCLEAR,
			// Token: 0x0400043B RID: 1083
			SDLK_KP_DIVIDE,
			// Token: 0x0400043C RID: 1084
			SDLK_KP_MULTIPLY,
			// Token: 0x0400043D RID: 1085
			SDLK_KP_MINUS,
			// Token: 0x0400043E RID: 1086
			SDLK_KP_PLUS,
			// Token: 0x0400043F RID: 1087
			SDLK_KP_ENTER,
			// Token: 0x04000440 RID: 1088
			SDLK_KP_1,
			// Token: 0x04000441 RID: 1089
			SDLK_KP_2,
			// Token: 0x04000442 RID: 1090
			SDLK_KP_3,
			// Token: 0x04000443 RID: 1091
			SDLK_KP_4,
			// Token: 0x04000444 RID: 1092
			SDLK_KP_5,
			// Token: 0x04000445 RID: 1093
			SDLK_KP_6,
			// Token: 0x04000446 RID: 1094
			SDLK_KP_7,
			// Token: 0x04000447 RID: 1095
			SDLK_KP_8,
			// Token: 0x04000448 RID: 1096
			SDLK_KP_9,
			// Token: 0x04000449 RID: 1097
			SDLK_KP_0,
			// Token: 0x0400044A RID: 1098
			SDLK_KP_PERIOD,
			// Token: 0x0400044B RID: 1099
			SDLK_APPLICATION = 1073741925,
			// Token: 0x0400044C RID: 1100
			SDLK_POWER,
			// Token: 0x0400044D RID: 1101
			SDLK_KP_EQUALS,
			// Token: 0x0400044E RID: 1102
			SDLK_F13,
			// Token: 0x0400044F RID: 1103
			SDLK_F14,
			// Token: 0x04000450 RID: 1104
			SDLK_F15,
			// Token: 0x04000451 RID: 1105
			SDLK_F16,
			// Token: 0x04000452 RID: 1106
			SDLK_F17,
			// Token: 0x04000453 RID: 1107
			SDLK_F18,
			// Token: 0x04000454 RID: 1108
			SDLK_F19,
			// Token: 0x04000455 RID: 1109
			SDLK_F20,
			// Token: 0x04000456 RID: 1110
			SDLK_F21,
			// Token: 0x04000457 RID: 1111
			SDLK_F22,
			// Token: 0x04000458 RID: 1112
			SDLK_F23,
			// Token: 0x04000459 RID: 1113
			SDLK_F24,
			// Token: 0x0400045A RID: 1114
			SDLK_EXECUTE,
			// Token: 0x0400045B RID: 1115
			SDLK_HELP,
			// Token: 0x0400045C RID: 1116
			SDLK_MENU,
			// Token: 0x0400045D RID: 1117
			SDLK_SELECT,
			// Token: 0x0400045E RID: 1118
			SDLK_STOP,
			// Token: 0x0400045F RID: 1119
			SDLK_AGAIN,
			// Token: 0x04000460 RID: 1120
			SDLK_UNDO,
			// Token: 0x04000461 RID: 1121
			SDLK_CUT,
			// Token: 0x04000462 RID: 1122
			SDLK_COPY,
			// Token: 0x04000463 RID: 1123
			SDLK_PASTE,
			// Token: 0x04000464 RID: 1124
			SDLK_FIND,
			// Token: 0x04000465 RID: 1125
			SDLK_MUTE,
			// Token: 0x04000466 RID: 1126
			SDLK_VOLUMEUP,
			// Token: 0x04000467 RID: 1127
			SDLK_VOLUMEDOWN,
			// Token: 0x04000468 RID: 1128
			SDLK_KP_COMMA = 1073741957,
			// Token: 0x04000469 RID: 1129
			SDLK_KP_EQUALSAS400,
			// Token: 0x0400046A RID: 1130
			SDLK_ALTERASE = 1073741977,
			// Token: 0x0400046B RID: 1131
			SDLK_SYSREQ,
			// Token: 0x0400046C RID: 1132
			SDLK_CANCEL,
			// Token: 0x0400046D RID: 1133
			SDLK_CLEAR,
			// Token: 0x0400046E RID: 1134
			SDLK_PRIOR,
			// Token: 0x0400046F RID: 1135
			SDLK_RETURN2,
			// Token: 0x04000470 RID: 1136
			SDLK_SEPARATOR,
			// Token: 0x04000471 RID: 1137
			SDLK_OUT,
			// Token: 0x04000472 RID: 1138
			SDLK_OPER,
			// Token: 0x04000473 RID: 1139
			SDLK_CLEARAGAIN,
			// Token: 0x04000474 RID: 1140
			SDLK_CRSEL,
			// Token: 0x04000475 RID: 1141
			SDLK_EXSEL,
			// Token: 0x04000476 RID: 1142
			SDLK_KP_00 = 1073742000,
			// Token: 0x04000477 RID: 1143
			SDLK_KP_000,
			// Token: 0x04000478 RID: 1144
			SDLK_THOUSANDSSEPARATOR,
			// Token: 0x04000479 RID: 1145
			SDLK_DECIMALSEPARATOR,
			// Token: 0x0400047A RID: 1146
			SDLK_CURRENCYUNIT,
			// Token: 0x0400047B RID: 1147
			SDLK_CURRENCYSUBUNIT,
			// Token: 0x0400047C RID: 1148
			SDLK_KP_LEFTPAREN,
			// Token: 0x0400047D RID: 1149
			SDLK_KP_RIGHTPAREN,
			// Token: 0x0400047E RID: 1150
			SDLK_KP_LEFTBRACE,
			// Token: 0x0400047F RID: 1151
			SDLK_KP_RIGHTBRACE,
			// Token: 0x04000480 RID: 1152
			SDLK_KP_TAB,
			// Token: 0x04000481 RID: 1153
			SDLK_KP_BACKSPACE,
			// Token: 0x04000482 RID: 1154
			SDLK_KP_A,
			// Token: 0x04000483 RID: 1155
			SDLK_KP_B,
			// Token: 0x04000484 RID: 1156
			SDLK_KP_C,
			// Token: 0x04000485 RID: 1157
			SDLK_KP_D,
			// Token: 0x04000486 RID: 1158
			SDLK_KP_E,
			// Token: 0x04000487 RID: 1159
			SDLK_KP_F,
			// Token: 0x04000488 RID: 1160
			SDLK_KP_XOR,
			// Token: 0x04000489 RID: 1161
			SDLK_KP_POWER,
			// Token: 0x0400048A RID: 1162
			SDLK_KP_PERCENT,
			// Token: 0x0400048B RID: 1163
			SDLK_KP_LESS,
			// Token: 0x0400048C RID: 1164
			SDLK_KP_GREATER,
			// Token: 0x0400048D RID: 1165
			SDLK_KP_AMPERSAND,
			// Token: 0x0400048E RID: 1166
			SDLK_KP_DBLAMPERSAND,
			// Token: 0x0400048F RID: 1167
			SDLK_KP_VERTICALBAR,
			// Token: 0x04000490 RID: 1168
			SDLK_KP_DBLVERTICALBAR,
			// Token: 0x04000491 RID: 1169
			SDLK_KP_COLON,
			// Token: 0x04000492 RID: 1170
			SDLK_KP_HASH,
			// Token: 0x04000493 RID: 1171
			SDLK_KP_SPACE,
			// Token: 0x04000494 RID: 1172
			SDLK_KP_AT,
			// Token: 0x04000495 RID: 1173
			SDLK_KP_EXCLAM,
			// Token: 0x04000496 RID: 1174
			SDLK_KP_MEMSTORE,
			// Token: 0x04000497 RID: 1175
			SDLK_KP_MEMRECALL,
			// Token: 0x04000498 RID: 1176
			SDLK_KP_MEMCLEAR,
			// Token: 0x04000499 RID: 1177
			SDLK_KP_MEMADD,
			// Token: 0x0400049A RID: 1178
			SDLK_KP_MEMSUBTRACT,
			// Token: 0x0400049B RID: 1179
			SDLK_KP_MEMMULTIPLY,
			// Token: 0x0400049C RID: 1180
			SDLK_KP_MEMDIVIDE,
			// Token: 0x0400049D RID: 1181
			SDLK_KP_PLUSMINUS,
			// Token: 0x0400049E RID: 1182
			SDLK_KP_CLEAR,
			// Token: 0x0400049F RID: 1183
			SDLK_KP_CLEARENTRY,
			// Token: 0x040004A0 RID: 1184
			SDLK_KP_BINARY,
			// Token: 0x040004A1 RID: 1185
			SDLK_KP_OCTAL,
			// Token: 0x040004A2 RID: 1186
			SDLK_KP_DECIMAL,
			// Token: 0x040004A3 RID: 1187
			SDLK_KP_HEXADECIMAL,
			// Token: 0x040004A4 RID: 1188
			SDLK_LCTRL = 1073742048,
			// Token: 0x040004A5 RID: 1189
			SDLK_LSHIFT,
			// Token: 0x040004A6 RID: 1190
			SDLK_LALT,
			// Token: 0x040004A7 RID: 1191
			SDLK_LGUI,
			// Token: 0x040004A8 RID: 1192
			SDLK_RCTRL,
			// Token: 0x040004A9 RID: 1193
			SDLK_RSHIFT,
			// Token: 0x040004AA RID: 1194
			SDLK_RALT,
			// Token: 0x040004AB RID: 1195
			SDLK_RGUI,
			// Token: 0x040004AC RID: 1196
			SDLK_MODE = 1073742081,
			// Token: 0x040004AD RID: 1197
			SDLK_AUDIONEXT,
			// Token: 0x040004AE RID: 1198
			SDLK_AUDIOPREV,
			// Token: 0x040004AF RID: 1199
			SDLK_AUDIOSTOP,
			// Token: 0x040004B0 RID: 1200
			SDLK_AUDIOPLAY,
			// Token: 0x040004B1 RID: 1201
			SDLK_AUDIOMUTE,
			// Token: 0x040004B2 RID: 1202
			SDLK_MEDIASELECT,
			// Token: 0x040004B3 RID: 1203
			SDLK_WWW,
			// Token: 0x040004B4 RID: 1204
			SDLK_MAIL,
			// Token: 0x040004B5 RID: 1205
			SDLK_CALCULATOR,
			// Token: 0x040004B6 RID: 1206
			SDLK_COMPUTER,
			// Token: 0x040004B7 RID: 1207
			SDLK_AC_SEARCH,
			// Token: 0x040004B8 RID: 1208
			SDLK_AC_HOME,
			// Token: 0x040004B9 RID: 1209
			SDLK_AC_BACK,
			// Token: 0x040004BA RID: 1210
			SDLK_AC_FORWARD,
			// Token: 0x040004BB RID: 1211
			SDLK_AC_STOP,
			// Token: 0x040004BC RID: 1212
			SDLK_AC_REFRESH,
			// Token: 0x040004BD RID: 1213
			SDLK_AC_BOOKMARKS,
			// Token: 0x040004BE RID: 1214
			SDLK_BRIGHTNESSDOWN,
			// Token: 0x040004BF RID: 1215
			SDLK_BRIGHTNESSUP,
			// Token: 0x040004C0 RID: 1216
			SDLK_DISPLAYSWITCH,
			// Token: 0x040004C1 RID: 1217
			SDLK_KBDILLUMTOGGLE,
			// Token: 0x040004C2 RID: 1218
			SDLK_KBDILLUMDOWN,
			// Token: 0x040004C3 RID: 1219
			SDLK_KBDILLUMUP,
			// Token: 0x040004C4 RID: 1220
			SDLK_EJECT,
			// Token: 0x040004C5 RID: 1221
			SDLK_SLEEP
		}

		// Token: 0x0200004C RID: 76
		[Flags]
		public enum SDL_Keymod : ushort
		{
			// Token: 0x040004C7 RID: 1223
			KMOD_NONE = 0,
			// Token: 0x040004C8 RID: 1224
			KMOD_LSHIFT = 1,
			// Token: 0x040004C9 RID: 1225
			KMOD_RSHIFT = 2,
			// Token: 0x040004CA RID: 1226
			KMOD_LCTRL = 64,
			// Token: 0x040004CB RID: 1227
			KMOD_RCTRL = 128,
			// Token: 0x040004CC RID: 1228
			KMOD_LALT = 256,
			// Token: 0x040004CD RID: 1229
			KMOD_RALT = 512,
			// Token: 0x040004CE RID: 1230
			KMOD_LGUI = 1024,
			// Token: 0x040004CF RID: 1231
			KMOD_RGUI = 2048,
			// Token: 0x040004D0 RID: 1232
			KMOD_NUM = 4096,
			// Token: 0x040004D1 RID: 1233
			KMOD_CAPS = 8192,
			// Token: 0x040004D2 RID: 1234
			KMOD_MODE = 16384,
			// Token: 0x040004D3 RID: 1235
			KMOD_RESERVED = 32768,
			// Token: 0x040004D4 RID: 1236
			KMOD_CTRL = 192,
			// Token: 0x040004D5 RID: 1237
			KMOD_SHIFT = 3,
			// Token: 0x040004D6 RID: 1238
			KMOD_ALT = 768,
			// Token: 0x040004D7 RID: 1239
			KMOD_GUI = 3072
		}

		// Token: 0x0200004D RID: 77
		public struct SDL_Keysym
		{
			// Token: 0x040004D8 RID: 1240
			public SDL.SDL_Scancode scancode;

			// Token: 0x040004D9 RID: 1241
			public SDL.SDL_Keycode sym;

			// Token: 0x040004DA RID: 1242
			public SDL.SDL_Keymod mod;

			// Token: 0x040004DB RID: 1243
			public uint unicode;
		}

		// Token: 0x0200004E RID: 78
		public enum SDL_SystemCursor
		{
			// Token: 0x040004DD RID: 1245
			SDL_SYSTEM_CURSOR_ARROW,
			// Token: 0x040004DE RID: 1246
			SDL_SYSTEM_CURSOR_IBEAM,
			// Token: 0x040004DF RID: 1247
			SDL_SYSTEM_CURSOR_WAIT,
			// Token: 0x040004E0 RID: 1248
			SDL_SYSTEM_CURSOR_CROSSHAIR,
			// Token: 0x040004E1 RID: 1249
			SDL_SYSTEM_CURSOR_WAITARROW,
			// Token: 0x040004E2 RID: 1250
			SDL_SYSTEM_CURSOR_SIZENWSE,
			// Token: 0x040004E3 RID: 1251
			SDL_SYSTEM_CURSOR_SIZENESW,
			// Token: 0x040004E4 RID: 1252
			SDL_SYSTEM_CURSOR_SIZEWE,
			// Token: 0x040004E5 RID: 1253
			SDL_SYSTEM_CURSOR_SIZENS,
			// Token: 0x040004E6 RID: 1254
			SDL_SYSTEM_CURSOR_SIZEALL,
			// Token: 0x040004E7 RID: 1255
			SDL_SYSTEM_CURSOR_NO,
			// Token: 0x040004E8 RID: 1256
			SDL_SYSTEM_CURSOR_HAND,
			// Token: 0x040004E9 RID: 1257
			SDL_NUM_SYSTEM_CURSORS
		}

		// Token: 0x0200004F RID: 79
		public struct SDL_Finger
		{
			// Token: 0x040004EA RID: 1258
			public long id;

			// Token: 0x040004EB RID: 1259
			public float x;

			// Token: 0x040004EC RID: 1260
			public float y;

			// Token: 0x040004ED RID: 1261
			public float pressure;
		}

		// Token: 0x02000050 RID: 80
		public enum SDL_JoystickPowerLevel
		{
			// Token: 0x040004EF RID: 1263
			SDL_JOYSTICK_POWER_UNKNOWN = -1,
			// Token: 0x040004F0 RID: 1264
			SDL_JOYSTICK_POWER_EMPTY,
			// Token: 0x040004F1 RID: 1265
			SDL_JOYSTICK_POWER_LOW,
			// Token: 0x040004F2 RID: 1266
			SDL_JOYSTICK_POWER_MEDIUM,
			// Token: 0x040004F3 RID: 1267
			SDL_JOYSTICK_POWER_FULL,
			// Token: 0x040004F4 RID: 1268
			SDL_JOYSTICK_POWER_WIRED,
			// Token: 0x040004F5 RID: 1269
			SDL_JOYSTICK_POWER_MAX
		}

		// Token: 0x02000051 RID: 81
		public enum SDL_JoystickType
		{
			// Token: 0x040004F7 RID: 1271
			SDL_JOYSTICK_TYPE_UNKNOWN,
			// Token: 0x040004F8 RID: 1272
			SDL_JOYSTICK_TYPE_GAMECONTROLLER,
			// Token: 0x040004F9 RID: 1273
			SDL_JOYSTICK_TYPE_WHEEL,
			// Token: 0x040004FA RID: 1274
			SDL_JOYSTICK_TYPE_ARCADE_STICK,
			// Token: 0x040004FB RID: 1275
			SDL_JOYSTICK_TYPE_FLIGHT_STICK,
			// Token: 0x040004FC RID: 1276
			SDL_JOYSTICK_TYPE_DANCE_PAD,
			// Token: 0x040004FD RID: 1277
			SDL_JOYSTICK_TYPE_GUITAR,
			// Token: 0x040004FE RID: 1278
			SDL_JOYSTICK_TYPE_DRUM_KIT,
			// Token: 0x040004FF RID: 1279
			SDL_JOYSTICK_TYPE_ARCADE_PAD
		}

		// Token: 0x02000052 RID: 82
		public enum SDL_GameControllerBindType
		{
			// Token: 0x04000501 RID: 1281
			SDL_CONTROLLER_BINDTYPE_NONE,
			// Token: 0x04000502 RID: 1282
			SDL_CONTROLLER_BINDTYPE_BUTTON,
			// Token: 0x04000503 RID: 1283
			SDL_CONTROLLER_BINDTYPE_AXIS,
			// Token: 0x04000504 RID: 1284
			SDL_CONTROLLER_BINDTYPE_HAT
		}

		// Token: 0x02000053 RID: 83
		public enum SDL_GameControllerAxis
		{
			// Token: 0x04000506 RID: 1286
			SDL_CONTROLLER_AXIS_INVALID = -1,
			// Token: 0x04000507 RID: 1287
			SDL_CONTROLLER_AXIS_LEFTX,
			// Token: 0x04000508 RID: 1288
			SDL_CONTROLLER_AXIS_LEFTY,
			// Token: 0x04000509 RID: 1289
			SDL_CONTROLLER_AXIS_RIGHTX,
			// Token: 0x0400050A RID: 1290
			SDL_CONTROLLER_AXIS_RIGHTY,
			// Token: 0x0400050B RID: 1291
			SDL_CONTROLLER_AXIS_TRIGGERLEFT,
			// Token: 0x0400050C RID: 1292
			SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
			// Token: 0x0400050D RID: 1293
			SDL_CONTROLLER_AXIS_MAX
		}

		// Token: 0x02000054 RID: 84
		public enum SDL_GameControllerButton
		{
			// Token: 0x0400050F RID: 1295
			SDL_CONTROLLER_BUTTON_INVALID = -1,
			// Token: 0x04000510 RID: 1296
			SDL_CONTROLLER_BUTTON_A,
			// Token: 0x04000511 RID: 1297
			SDL_CONTROLLER_BUTTON_B,
			// Token: 0x04000512 RID: 1298
			SDL_CONTROLLER_BUTTON_X,
			// Token: 0x04000513 RID: 1299
			SDL_CONTROLLER_BUTTON_Y,
			// Token: 0x04000514 RID: 1300
			SDL_CONTROLLER_BUTTON_BACK,
			// Token: 0x04000515 RID: 1301
			SDL_CONTROLLER_BUTTON_GUIDE,
			// Token: 0x04000516 RID: 1302
			SDL_CONTROLLER_BUTTON_START,
			// Token: 0x04000517 RID: 1303
			SDL_CONTROLLER_BUTTON_LEFTSTICK,
			// Token: 0x04000518 RID: 1304
			SDL_CONTROLLER_BUTTON_RIGHTSTICK,
			// Token: 0x04000519 RID: 1305
			SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
			// Token: 0x0400051A RID: 1306
			SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
			// Token: 0x0400051B RID: 1307
			SDL_CONTROLLER_BUTTON_DPAD_UP,
			// Token: 0x0400051C RID: 1308
			SDL_CONTROLLER_BUTTON_DPAD_DOWN,
			// Token: 0x0400051D RID: 1309
			SDL_CONTROLLER_BUTTON_DPAD_LEFT,
			// Token: 0x0400051E RID: 1310
			SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
			// Token: 0x0400051F RID: 1311
			SDL_CONTROLLER_BUTTON_MAX
		}

		// Token: 0x02000055 RID: 85
		public struct INTERNAL_GameControllerButtonBind_hat
		{
			// Token: 0x04000520 RID: 1312
			public int hat;

			// Token: 0x04000521 RID: 1313
			public int hat_mask;
		}

		// Token: 0x02000056 RID: 86
		[StructLayout(LayoutKind.Explicit)]
		public struct SDL_GameControllerButtonBind
		{
			// Token: 0x04000522 RID: 1314
			[FieldOffset(0)]
			public SDL.SDL_GameControllerBindType bindType;

			// Token: 0x04000523 RID: 1315
			[FieldOffset(4)]
			public int button;

			// Token: 0x04000524 RID: 1316
			[FieldOffset(4)]
			public int axis;

			// Token: 0x04000525 RID: 1317
			[FieldOffset(4)]
			public SDL.INTERNAL_GameControllerButtonBind_hat hat;
		}

		// Token: 0x02000057 RID: 87
		public struct SDL_HapticDirection
		{
			// Token: 0x04000526 RID: 1318
			public byte type;

			// Token: 0x04000527 RID: 1319
			[FixedBuffer(typeof(int), 3)]
			public SDL.SDL_HapticDirection.<dir>e__FixedBuffer dir;

			// Token: 0x0200007D RID: 125
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 12)]
			public struct <dir>e__FixedBuffer
			{
				// Token: 0x040005CC RID: 1484
				public int FixedElementField;
			}
		}

		// Token: 0x02000058 RID: 88
		public struct SDL_HapticConstant
		{
			// Token: 0x04000528 RID: 1320
			public ushort type;

			// Token: 0x04000529 RID: 1321
			public SDL.SDL_HapticDirection direction;

			// Token: 0x0400052A RID: 1322
			public uint length;

			// Token: 0x0400052B RID: 1323
			public ushort delay;

			// Token: 0x0400052C RID: 1324
			public ushort button;

			// Token: 0x0400052D RID: 1325
			public ushort interval;

			// Token: 0x0400052E RID: 1326
			public short level;

			// Token: 0x0400052F RID: 1327
			public ushort attack_length;

			// Token: 0x04000530 RID: 1328
			public ushort attack_level;

			// Token: 0x04000531 RID: 1329
			public ushort fade_length;

			// Token: 0x04000532 RID: 1330
			public ushort fade_level;
		}

		// Token: 0x02000059 RID: 89
		public struct SDL_HapticPeriodic
		{
			// Token: 0x04000533 RID: 1331
			public ushort type;

			// Token: 0x04000534 RID: 1332
			public SDL.SDL_HapticDirection direction;

			// Token: 0x04000535 RID: 1333
			public uint length;

			// Token: 0x04000536 RID: 1334
			public ushort delay;

			// Token: 0x04000537 RID: 1335
			public ushort button;

			// Token: 0x04000538 RID: 1336
			public ushort interval;

			// Token: 0x04000539 RID: 1337
			public ushort period;

			// Token: 0x0400053A RID: 1338
			public short magnitude;

			// Token: 0x0400053B RID: 1339
			public short offset;

			// Token: 0x0400053C RID: 1340
			public ushort phase;

			// Token: 0x0400053D RID: 1341
			public ushort attack_length;

			// Token: 0x0400053E RID: 1342
			public ushort attack_level;

			// Token: 0x0400053F RID: 1343
			public ushort fade_length;

			// Token: 0x04000540 RID: 1344
			public ushort fade_level;
		}

		// Token: 0x0200005A RID: 90
		public struct SDL_HapticCondition
		{
			// Token: 0x04000541 RID: 1345
			public ushort type;

			// Token: 0x04000542 RID: 1346
			public SDL.SDL_HapticDirection direction;

			// Token: 0x04000543 RID: 1347
			public uint length;

			// Token: 0x04000544 RID: 1348
			public ushort delay;

			// Token: 0x04000545 RID: 1349
			public ushort button;

			// Token: 0x04000546 RID: 1350
			public ushort interval;

			// Token: 0x04000547 RID: 1351
			[FixedBuffer(typeof(ushort), 3)]
			public SDL.SDL_HapticCondition.<right_sat>e__FixedBuffer right_sat;

			// Token: 0x04000548 RID: 1352
			[FixedBuffer(typeof(ushort), 3)]
			public SDL.SDL_HapticCondition.<left_sat>e__FixedBuffer left_sat;

			// Token: 0x04000549 RID: 1353
			[FixedBuffer(typeof(short), 3)]
			public SDL.SDL_HapticCondition.<right_coeff>e__FixedBuffer right_coeff;

			// Token: 0x0400054A RID: 1354
			[FixedBuffer(typeof(short), 3)]
			public SDL.SDL_HapticCondition.<left_coeff>e__FixedBuffer left_coeff;

			// Token: 0x0400054B RID: 1355
			[FixedBuffer(typeof(ushort), 3)]
			public SDL.SDL_HapticCondition.<deadband>e__FixedBuffer deadband;

			// Token: 0x0400054C RID: 1356
			[FixedBuffer(typeof(short), 3)]
			public SDL.SDL_HapticCondition.<center>e__FixedBuffer center;

			// Token: 0x0200007E RID: 126
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 6)]
			public struct <right_sat>e__FixedBuffer
			{
				// Token: 0x040005CD RID: 1485
				public ushort FixedElementField;
			}

			// Token: 0x0200007F RID: 127
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 6)]
			public struct <left_sat>e__FixedBuffer
			{
				// Token: 0x040005CE RID: 1486
				public ushort FixedElementField;
			}

			// Token: 0x02000080 RID: 128
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 6)]
			public struct <right_coeff>e__FixedBuffer
			{
				// Token: 0x040005CF RID: 1487
				public short FixedElementField;
			}

			// Token: 0x02000081 RID: 129
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 6)]
			public struct <left_coeff>e__FixedBuffer
			{
				// Token: 0x040005D0 RID: 1488
				public short FixedElementField;
			}

			// Token: 0x02000082 RID: 130
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 6)]
			public struct <deadband>e__FixedBuffer
			{
				// Token: 0x040005D1 RID: 1489
				public ushort FixedElementField;
			}

			// Token: 0x02000083 RID: 131
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 6)]
			public struct <center>e__FixedBuffer
			{
				// Token: 0x040005D2 RID: 1490
				public short FixedElementField;
			}
		}

		// Token: 0x0200005B RID: 91
		public struct SDL_HapticRamp
		{
			// Token: 0x0400054D RID: 1357
			public ushort type;

			// Token: 0x0400054E RID: 1358
			public SDL.SDL_HapticDirection direction;

			// Token: 0x0400054F RID: 1359
			public uint length;

			// Token: 0x04000550 RID: 1360
			public ushort delay;

			// Token: 0x04000551 RID: 1361
			public ushort button;

			// Token: 0x04000552 RID: 1362
			public ushort interval;

			// Token: 0x04000553 RID: 1363
			public short start;

			// Token: 0x04000554 RID: 1364
			public short end;

			// Token: 0x04000555 RID: 1365
			public ushort attack_length;

			// Token: 0x04000556 RID: 1366
			public ushort attack_level;

			// Token: 0x04000557 RID: 1367
			public ushort fade_length;

			// Token: 0x04000558 RID: 1368
			public ushort fade_level;
		}

		// Token: 0x0200005C RID: 92
		public struct SDL_HapticLeftRight
		{
			// Token: 0x04000559 RID: 1369
			public ushort type;

			// Token: 0x0400055A RID: 1370
			public uint length;

			// Token: 0x0400055B RID: 1371
			public ushort large_magnitude;

			// Token: 0x0400055C RID: 1372
			public ushort small_magnitude;
		}

		// Token: 0x0200005D RID: 93
		public struct SDL_HapticCustom
		{
			// Token: 0x0400055D RID: 1373
			public ushort type;

			// Token: 0x0400055E RID: 1374
			public SDL.SDL_HapticDirection direction;

			// Token: 0x0400055F RID: 1375
			public uint length;

			// Token: 0x04000560 RID: 1376
			public ushort delay;

			// Token: 0x04000561 RID: 1377
			public ushort button;

			// Token: 0x04000562 RID: 1378
			public ushort interval;

			// Token: 0x04000563 RID: 1379
			public byte channels;

			// Token: 0x04000564 RID: 1380
			public ushort period;

			// Token: 0x04000565 RID: 1381
			public ushort samples;

			// Token: 0x04000566 RID: 1382
			public IntPtr data;

			// Token: 0x04000567 RID: 1383
			public ushort attack_length;

			// Token: 0x04000568 RID: 1384
			public ushort attack_level;

			// Token: 0x04000569 RID: 1385
			public ushort fade_length;

			// Token: 0x0400056A RID: 1386
			public ushort fade_level;
		}

		// Token: 0x0200005E RID: 94
		[StructLayout(LayoutKind.Explicit)]
		public struct SDL_HapticEffect
		{
			// Token: 0x0400056B RID: 1387
			[FieldOffset(0)]
			public ushort type;

			// Token: 0x0400056C RID: 1388
			[FieldOffset(0)]
			public SDL.SDL_HapticConstant constant;

			// Token: 0x0400056D RID: 1389
			[FieldOffset(0)]
			public SDL.SDL_HapticPeriodic periodic;

			// Token: 0x0400056E RID: 1390
			[FieldOffset(0)]
			public SDL.SDL_HapticCondition condition;

			// Token: 0x0400056F RID: 1391
			[FieldOffset(0)]
			public SDL.SDL_HapticRamp ramp;

			// Token: 0x04000570 RID: 1392
			[FieldOffset(0)]
			public SDL.SDL_HapticLeftRight leftright;

			// Token: 0x04000571 RID: 1393
			[FieldOffset(0)]
			public SDL.SDL_HapticCustom custom;
		}

		// Token: 0x0200005F RID: 95
		public enum SDL_AudioStatus
		{
			// Token: 0x04000573 RID: 1395
			SDL_AUDIO_STOPPED,
			// Token: 0x04000574 RID: 1396
			SDL_AUDIO_PLAYING,
			// Token: 0x04000575 RID: 1397
			SDL_AUDIO_PAUSED
		}

		// Token: 0x02000060 RID: 96
		public struct SDL_AudioSpec
		{
			// Token: 0x04000576 RID: 1398
			public int freq;

			// Token: 0x04000577 RID: 1399
			public ushort format;

			// Token: 0x04000578 RID: 1400
			public byte channels;

			// Token: 0x04000579 RID: 1401
			public byte silence;

			// Token: 0x0400057A RID: 1402
			public ushort samples;

			// Token: 0x0400057B RID: 1403
			public uint size;

			// Token: 0x0400057C RID: 1404
			public SDL.SDL_AudioCallback callback;

			// Token: 0x0400057D RID: 1405
			public IntPtr userdata;
		}

		// Token: 0x02000061 RID: 97
		// (Invoke) Token: 0x0600028C RID: 652
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SDL_AudioCallback(IntPtr userdata, IntPtr stream, int len);

		// Token: 0x02000062 RID: 98
		// (Invoke) Token: 0x06000290 RID: 656
		public delegate uint SDL_TimerCallback(uint interval, IntPtr param);

		// Token: 0x02000063 RID: 99
		public enum SDL_SYSWM_TYPE
		{
			// Token: 0x0400057F RID: 1407
			SDL_SYSWM_UNKNOWN,
			// Token: 0x04000580 RID: 1408
			SDL_SYSWM_WINDOWS,
			// Token: 0x04000581 RID: 1409
			SDL_SYSWM_X11,
			// Token: 0x04000582 RID: 1410
			SDL_SYSWM_DIRECTFB,
			// Token: 0x04000583 RID: 1411
			SDL_SYSWM_COCOA,
			// Token: 0x04000584 RID: 1412
			SDL_SYSWM_UIKIT,
			// Token: 0x04000585 RID: 1413
			SDL_SYSWM_WAYLAND,
			// Token: 0x04000586 RID: 1414
			SDL_SYSWM_MIR,
			// Token: 0x04000587 RID: 1415
			SDL_SYSWM_WINRT,
			// Token: 0x04000588 RID: 1416
			SDL_SYSWM_ANDROID
		}

		// Token: 0x02000064 RID: 100
		public struct INTERNAL_windows_wminfo
		{
			// Token: 0x04000589 RID: 1417
			public IntPtr window;

			// Token: 0x0400058A RID: 1418
			public IntPtr hdc;
		}

		// Token: 0x02000065 RID: 101
		public struct INTERNAL_winrt_wminfo
		{
			// Token: 0x0400058B RID: 1419
			public IntPtr window;
		}

		// Token: 0x02000066 RID: 102
		public struct INTERNAL_x11_wminfo
		{
			// Token: 0x0400058C RID: 1420
			public IntPtr display;

			// Token: 0x0400058D RID: 1421
			public IntPtr window;
		}

		// Token: 0x02000067 RID: 103
		public struct INTERNAL_directfb_wminfo
		{
			// Token: 0x0400058E RID: 1422
			public IntPtr dfb;

			// Token: 0x0400058F RID: 1423
			public IntPtr window;

			// Token: 0x04000590 RID: 1424
			public IntPtr surface;
		}

		// Token: 0x02000068 RID: 104
		public struct INTERNAL_cocoa_wminfo
		{
			// Token: 0x04000591 RID: 1425
			public IntPtr window;
		}

		// Token: 0x02000069 RID: 105
		public struct INTERNAL_uikit_wminfo
		{
			// Token: 0x04000592 RID: 1426
			public IntPtr window;

			// Token: 0x04000593 RID: 1427
			public uint framebuffer;

			// Token: 0x04000594 RID: 1428
			public uint colorbuffer;

			// Token: 0x04000595 RID: 1429
			public uint resolveFramebuffer;
		}

		// Token: 0x0200006A RID: 106
		public struct INTERNAL_wayland_wminfo
		{
			// Token: 0x04000596 RID: 1430
			public IntPtr display;

			// Token: 0x04000597 RID: 1431
			public IntPtr surface;

			// Token: 0x04000598 RID: 1432
			public IntPtr shell_surface;
		}

		// Token: 0x0200006B RID: 107
		public struct INTERNAL_mir_wminfo
		{
			// Token: 0x04000599 RID: 1433
			public IntPtr connection;

			// Token: 0x0400059A RID: 1434
			public IntPtr surface;
		}

		// Token: 0x0200006C RID: 108
		public struct INTERNAL_android_wminfo
		{
			// Token: 0x0400059B RID: 1435
			public IntPtr window;

			// Token: 0x0400059C RID: 1436
			public IntPtr surface;
		}

		// Token: 0x0200006D RID: 109
		[StructLayout(LayoutKind.Explicit)]
		public struct INTERNAL_SysWMDriverUnion
		{
			// Token: 0x0400059D RID: 1437
			[FieldOffset(0)]
			public SDL.INTERNAL_windows_wminfo win;

			// Token: 0x0400059E RID: 1438
			[FieldOffset(0)]
			public SDL.INTERNAL_winrt_wminfo winrt;

			// Token: 0x0400059F RID: 1439
			[FieldOffset(0)]
			public SDL.INTERNAL_x11_wminfo x11;

			// Token: 0x040005A0 RID: 1440
			[FieldOffset(0)]
			public SDL.INTERNAL_directfb_wminfo dfb;

			// Token: 0x040005A1 RID: 1441
			[FieldOffset(0)]
			public SDL.INTERNAL_cocoa_wminfo cocoa;

			// Token: 0x040005A2 RID: 1442
			[FieldOffset(0)]
			public SDL.INTERNAL_uikit_wminfo uikit;

			// Token: 0x040005A3 RID: 1443
			[FieldOffset(0)]
			public SDL.INTERNAL_wayland_wminfo wl;

			// Token: 0x040005A4 RID: 1444
			[FieldOffset(0)]
			public SDL.INTERNAL_mir_wminfo mir;

			// Token: 0x040005A5 RID: 1445
			[FieldOffset(0)]
			public SDL.INTERNAL_android_wminfo android;
		}

		// Token: 0x0200006E RID: 110
		public struct SDL_SysWMinfo
		{
			// Token: 0x040005A6 RID: 1446
			public SDL.SDL_version version;

			// Token: 0x040005A7 RID: 1447
			public SDL.SDL_SYSWM_TYPE subsystem;

			// Token: 0x040005A8 RID: 1448
			public SDL.INTERNAL_SysWMDriverUnion info;
		}

		// Token: 0x0200006F RID: 111
		public enum SDL_PowerState
		{
			// Token: 0x040005AA RID: 1450
			SDL_POWERSTATE_UNKNOWN,
			// Token: 0x040005AB RID: 1451
			SDL_POWERSTATE_ON_BATTERY,
			// Token: 0x040005AC RID: 1452
			SDL_POWERSTATE_NO_BATTERY,
			// Token: 0x040005AD RID: 1453
			SDL_POWERSTATE_CHARGING,
			// Token: 0x040005AE RID: 1454
			SDL_POWERSTATE_CHARGED
		}
	}
}
