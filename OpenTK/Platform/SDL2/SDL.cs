using System;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005AA RID: 1450
	internal class SDL
	{
		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06004675 RID: 18037 RVA: 0x000C3338 File Offset: 0x000C1538
		public static Version Version
		{
			get
			{
				Version result;
				try
				{
					if (SDL.version == null)
					{
						SDL.version = new Version?(SDL.GetVersion());
					}
					result = SDL.version.Value;
				}
				catch
				{
					result = default(Version);
				}
				return result;
			}
		}

		// Token: 0x06004676 RID: 18038 RVA: 0x000C338C File Offset: 0x000C158C
		private static string IntPtrToString(IntPtr ptr)
		{
			return Marshal.PtrToStringAnsi(ptr);
		}

		// Token: 0x06004677 RID: 18039
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateColorCursor", ExactSpelling = true)]
		public static extern IntPtr CreateColorCursor(IntPtr surface, int hot_x, int hot_y);

		// Token: 0x06004678 RID: 18040
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeCursor", ExactSpelling = true)]
		public static extern void FreeCursor(IntPtr cursor);

		// Token: 0x06004679 RID: 18041
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDefaultCursor", ExactSpelling = true)]
		public static extern IntPtr GetDefaultCursor();

		// Token: 0x0600467A RID: 18042
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetCursor", ExactSpelling = true)]
		public static extern void SetCursor(IntPtr cursor);

		// Token: 0x0600467B RID: 18043
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AddEventWatch", ExactSpelling = true)]
		public static extern void AddEventWatch(EventFilter filter, IntPtr userdata);

		// Token: 0x0600467C RID: 18044
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AddEventWatch", ExactSpelling = true)]
		public static extern void AddEventWatch(IntPtr filter, IntPtr userdata);

		// Token: 0x0600467D RID: 18045
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceFrom", ExactSpelling = true)]
		public static extern IntPtr CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

		// Token: 0x0600467E RID: 18046
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindow", ExactSpelling = true)]
		public static extern IntPtr CreateWindow(string title, int x, int y, int w, int h, WindowFlags flags);

		// Token: 0x0600467F RID: 18047
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowFrom", ExactSpelling = true)]
		public static extern IntPtr CreateWindowFrom(IntPtr data);

		// Token: 0x06004680 RID: 18048
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DelEventWatch", ExactSpelling = true)]
		public static extern void DelEventWatch(EventFilter filter, IntPtr userdata);

		// Token: 0x06004681 RID: 18049
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DelEventWatch", ExactSpelling = true)]
		public static extern void DelEventWatch(IntPtr filter, IntPtr userdata);

		// Token: 0x06004682 RID: 18050
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyWindow", ExactSpelling = true)]
		public static extern void DestroyWindow(IntPtr window);

		// Token: 0x06004683 RID: 18051
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeSurface", ExactSpelling = true)]
		public static extern void FreeSurface(IntPtr surface);

		// Token: 0x06004684 RID: 18052
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerEventState", ExactSpelling = true)]
		public static extern EventState GameControllerEventState(EventState state);

		// Token: 0x06004685 RID: 18053
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAxis", ExactSpelling = true)]
		public static extern short GameControllerGetAxis(IntPtr gamecontroller, GameControllerAxis axis);

		// Token: 0x06004686 RID: 18054
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetBindForAxis", ExactSpelling = true)]
		public static extern GameControllerButtonBind GameControllerGetBindForAxis(IntPtr gamecontroller, GameControllerAxis axis);

		// Token: 0x06004687 RID: 18055
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetBindForButton", ExactSpelling = true)]
		public static extern GameControllerButtonBind GameControllerGetBindForButton(IntPtr gamecontroller, GameControllerButton button);

		// Token: 0x06004688 RID: 18056
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetButton", ExactSpelling = true)]
		public static extern bool GameControllerGetButton(IntPtr gamecontroller, GameControllerButton button);

		// Token: 0x06004689 RID: 18057
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetJoystick", ExactSpelling = true)]
		public static extern IntPtr GameControllerGetJoystick(IntPtr gamecontroller);

		// Token: 0x0600468A RID: 18058
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentDisplayMode", ExactSpelling = true)]
		public static extern int GetCurrentDisplayMode(int displayIndex, out DisplayMode mode);

		// Token: 0x0600468B RID: 18059
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerName", ExactSpelling = true)]
		private static extern IntPtr GameControllerNameInternal(IntPtr gamecontroller);

		// Token: 0x0600468C RID: 18060 RVA: 0x000C3394 File Offset: 0x000C1594
		public unsafe static string GameControllerName(IntPtr gamecontroller)
		{
			return new string((sbyte*)((void*)SDL.GameControllerNameInternal(gamecontroller)));
		}

		// Token: 0x0600468D RID: 18061
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerOpen", ExactSpelling = true)]
		public static extern IntPtr GameControllerOpen(int joystick_index);

		// Token: 0x0600468E RID: 18062
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayBounds", ExactSpelling = true)]
		public static extern int GetDisplayBounds(int displayIndex, out Rect rect);

		// Token: 0x0600468F RID: 18063
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayMode", ExactSpelling = true)]
		public static extern int GetDisplayMode(int displayIndex, int modeIndex, out DisplayMode mode);

		// Token: 0x06004690 RID: 18064
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetError", ExactSpelling = true)]
		private static extern IntPtr GetErrorInternal();

		// Token: 0x06004691 RID: 18065 RVA: 0x000C33A8 File Offset: 0x000C15A8
		public static string GetError()
		{
			return SDL.IntPtrToString(SDL.GetErrorInternal());
		}

		// Token: 0x06004692 RID: 18066
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetModState", ExactSpelling = true)]
		public static extern Keymod GetModState();

		// Token: 0x06004693 RID: 18067
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetMouseState", ExactSpelling = true)]
		public static extern ButtonFlags GetMouseState(out int hx, out int hy);

		// Token: 0x06004694 RID: 18068
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumDisplayModes", ExactSpelling = true)]
		public static extern int GetNumDisplayModes(int displayIndex);

		// Token: 0x06004695 RID: 18069
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDisplays", ExactSpelling = true)]
		public static extern int GetNumVideoDisplays();

		// Token: 0x06004696 RID: 18070
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeFromKey", ExactSpelling = true)]
		public static extern Scancode GetScancodeFromKey(Keycode key);

		// Token: 0x06004697 RID: 18071
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVersion", ExactSpelling = true)]
		public static extern void GetVersion(out Version version);

		// Token: 0x06004698 RID: 18072 RVA: 0x000C33B4 File Offset: 0x000C15B4
		public static Version GetVersion()
		{
			Version result;
			SDL.GetVersion(out result);
			return result;
		}

		// Token: 0x06004699 RID: 18073
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowID", ExactSpelling = true)]
		public static extern uint GetWindowID(IntPtr window);

		// Token: 0x0600469A RID: 18074
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPosition", ExactSpelling = true)]
		public static extern void GetWindowPosition(IntPtr window, out int x, out int y);

		// Token: 0x0600469B RID: 18075
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSize", ExactSpelling = true)]
		public static extern void GetWindowSize(IntPtr window, out int w, out int h);

		// Token: 0x0600469C RID: 18076
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowTitle", ExactSpelling = true)]
		private static extern IntPtr GetWindowTitlePrivate(IntPtr window);

		// Token: 0x0600469D RID: 18077 RVA: 0x000C33CC File Offset: 0x000C15CC
		public static string GetWindowTitle(IntPtr window)
		{
			return Marshal.PtrToStringAnsi(SDL.GetWindowTitlePrivate(window));
		}

		// Token: 0x0600469E RID: 18078
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HideWindow", ExactSpelling = true)]
		public static extern void HideWindow(IntPtr window);

		// Token: 0x0600469F RID: 18079
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Init", ExactSpelling = true)]
		public static extern int Init(SystemFlags flags);

		// Token: 0x060046A0 RID: 18080
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_InitSubSystem", ExactSpelling = true)]
		public static extern int InitSubSystem(SystemFlags flags);

		// Token: 0x060046A1 RID: 18081
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsGameController", ExactSpelling = true)]
		public static extern bool IsGameController(int joystick_index);

		// Token: 0x060046A2 RID: 18082
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickClose", ExactSpelling = true)]
		public static extern void JoystickClose(IntPtr joystick);

		// Token: 0x060046A3 RID: 18083
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickEventState", ExactSpelling = true)]
		public static extern EventState JoystickEventState(EventState enabled);

		// Token: 0x060046A4 RID: 18084
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetAxis", ExactSpelling = true)]
		public static extern short JoystickGetAxis(IntPtr joystick, int axis);

		// Token: 0x060046A5 RID: 18085
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetButton", ExactSpelling = true)]
		public static extern byte JoystickGetButton(IntPtr joystick, int button);

		// Token: 0x060046A6 RID: 18086
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetGUID", ExactSpelling = true)]
		public static extern JoystickGuid JoystickGetGUID(IntPtr joystick);

		// Token: 0x060046A7 RID: 18087
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickName", ExactSpelling = true)]
		private static extern IntPtr JoystickNameInternal(IntPtr joystick);

		// Token: 0x060046A8 RID: 18088 RVA: 0x000C33DC File Offset: 0x000C15DC
		public unsafe static string JoystickName(IntPtr joystick)
		{
			return new string((sbyte*)((void*)SDL.JoystickNameInternal(joystick)));
		}

		// Token: 0x060046A9 RID: 18089
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumAxes", ExactSpelling = true)]
		public static extern int JoystickNumAxes(IntPtr joystick);

		// Token: 0x060046AA RID: 18090
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumBalls", ExactSpelling = true)]
		public static extern int JoystickNumBalls(IntPtr joystick);

		// Token: 0x060046AB RID: 18091
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumButtons", ExactSpelling = true)]
		public static extern int JoystickNumButtons(IntPtr joystick);

		// Token: 0x060046AC RID: 18092
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNumHats", ExactSpelling = true)]
		public static extern int JoystickNumHats(IntPtr joystick);

		// Token: 0x060046AD RID: 18093
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickOpen", ExactSpelling = true)]
		public static extern IntPtr JoystickOpen(int device_index);

		// Token: 0x060046AE RID: 18094
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickUpdate", ExactSpelling = true)]
		public static extern void JoystickUpdate();

		// Token: 0x060046AF RID: 18095
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MaximizeWindow", ExactSpelling = true)]
		public static extern void MaximizeWindow(IntPtr window);

		// Token: 0x060046B0 RID: 18096
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MinimizeWindow", ExactSpelling = true)]
		public static extern void MinimizeWindow(IntPtr window);

		// Token: 0x060046B1 RID: 18097
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NumJoysticks", ExactSpelling = true)]
		public static extern int NumJoysticks();

		// Token: 0x060046B2 RID: 18098 RVA: 0x000C33F0 File Offset: 0x000C15F0
		public unsafe static int PeepEvents(ref Event e, EventAction action, EventType min, EventType max)
		{
			fixed (Event* ptr = &e)
			{
				return SDL.PeepEvents(ptr, 1, action, min, max);
			}
		}

		// Token: 0x060046B3 RID: 18099 RVA: 0x000C3410 File Offset: 0x000C1610
		public unsafe static int PeepEvents(Event[] e, int count, EventAction action, EventType min, EventType max)
		{
			if (e == null)
			{
				throw new ArgumentNullException();
			}
			if (count <= 0 || count > e.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			fixed (Event* ptr = e)
			{
				return SDL.PeepEvents(ptr, count, action, min, max);
			}
		}

		// Token: 0x060046B4 RID: 18100
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PeepEvents", ExactSpelling = true)]
		private unsafe static extern int PeepEvents(Event* e, int count, EventAction action, EventType min, EventType max);

		// Token: 0x060046B5 RID: 18101
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PixelFormatEnumToMasks", ExactSpelling = true)]
		public static extern bool PixelFormatEnumToMasks(uint format, out int bpp, out uint rmask, out uint gmask, out uint bmask, out uint amask);

		// Token: 0x060046B6 RID: 18102
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PollEvent", ExactSpelling = true)]
		public static extern int PollEvent(out Event e);

		// Token: 0x060046B7 RID: 18103
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PumpEvents", ExactSpelling = true)]
		public static extern void PumpEvents();

		// Token: 0x060046B8 RID: 18104
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PushEvent", ExactSpelling = true)]
		public static extern int PushEvent(ref Event @event);

		// Token: 0x060046B9 RID: 18105
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RaiseWindow", ExactSpelling = true)]
		public static extern void RaiseWindow(IntPtr window);

		// Token: 0x060046BA RID: 18106
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RestoreWindow", ExactSpelling = true)]
		public static extern void RestoreWindow(IntPtr window);

		// Token: 0x060046BB RID: 18107
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRelativeMouseMode", ExactSpelling = true)]
		public static extern int SetRelativeMouseMode(bool enabled);

		// Token: 0x060046BC RID: 18108
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBordered", ExactSpelling = true)]
		public static extern void SetWindowBordered(IntPtr window, bool bordered);

		// Token: 0x060046BD RID: 18109
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowFullscreen", ExactSpelling = true)]
		public static extern int SetWindowFullscreen(IntPtr window, uint flags);

		// Token: 0x060046BE RID: 18110
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGrab", ExactSpelling = true)]
		public static extern void SetWindowGrab(IntPtr window, bool grabbed);

		// Token: 0x060046BF RID: 18111
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowIcon", ExactSpelling = true)]
		public static extern void SetWindowIcon(IntPtr window, IntPtr icon);

		// Token: 0x060046C0 RID: 18112
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowPosition", ExactSpelling = true)]
		public static extern void SetWindowPosition(IntPtr window, int x, int y);

		// Token: 0x060046C1 RID: 18113
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowSize", ExactSpelling = true)]
		public static extern void SetWindowSize(IntPtr window, int x, int y);

		// Token: 0x060046C2 RID: 18114
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowTitle", ExactSpelling = true)]
		public static extern void SetWindowTitle(IntPtr window, string title);

		// Token: 0x060046C3 RID: 18115
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowCursor", ExactSpelling = true)]
		public static extern int ShowCursor(bool toggle);

		// Token: 0x060046C4 RID: 18116
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowWindow", ExactSpelling = true)]
		public static extern void ShowWindow(IntPtr window);

		// Token: 0x060046C5 RID: 18117
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WasInit", ExactSpelling = true)]
		public static extern bool WasInit(SystemFlags flags);

		// Token: 0x060046C6 RID: 18118
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WarpMouseInWindow", ExactSpelling = true)]
		public static extern void WarpMouseInWindow(IntPtr window, int x, int y);

		// Token: 0x060046C7 RID: 18119 RVA: 0x000C3460 File Offset: 0x000C1660
		public static bool GetWindowWMInfo(IntPtr window, out SysWMInfo info)
		{
			info = default(SysWMInfo);
			info.Version = SDL.GetVersion();
			return SDL.GetWindowWMInfoInternal(window, ref info);
		}

		// Token: 0x060046C8 RID: 18120
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowWMInfo", ExactSpelling = true)]
		private static extern bool GetWindowWMInfoInternal(IntPtr window, ref SysWMInfo info);

		// Token: 0x04005237 RID: 21047
		private const string lib = "SDL2.dll";

		// Token: 0x04005238 RID: 21048
		public static readonly object Sync = new object();

		// Token: 0x04005239 RID: 21049
		private static Version? version;

		// Token: 0x020005AB RID: 1451
		public class GL
		{
			// Token: 0x060046CB RID: 18123
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_CreateContext", ExactSpelling = true)]
			public static extern IntPtr CreateContext(IntPtr window);

			// Token: 0x060046CC RID: 18124
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_DeleteContext", ExactSpelling = true)]
			public static extern void DeleteContext(IntPtr context);

			// Token: 0x060046CD RID: 18125
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetAttribute", ExactSpelling = true)]
			public static extern int GetAttribute(ContextAttribute attr, out int value);

			// Token: 0x060046CE RID: 18126
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetCurrentContext", ExactSpelling = true)]
			public static extern IntPtr GetCurrentContext();

			// Token: 0x060046CF RID: 18127
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetDrawableSize", ExactSpelling = true)]
			public static extern void GetDrawableSize(IntPtr window, out int w, out int h);

			// Token: 0x060046D0 RID: 18128
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetProcAddress", ExactSpelling = true)]
			public static extern IntPtr GetProcAddress(IntPtr proc);

			// Token: 0x060046D1 RID: 18129 RVA: 0x000C3490 File Offset: 0x000C1690
			public static IntPtr GetProcAddress(string proc)
			{
				IntPtr intPtr = Marshal.StringToHGlobalAnsi(proc);
				IntPtr procAddress;
				try
				{
					procAddress = SDL.GL.GetProcAddress(intPtr);
				}
				finally
				{
					Marshal.FreeHGlobal(intPtr);
				}
				return procAddress;
			}

			// Token: 0x060046D2 RID: 18130
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetSwapInterval", ExactSpelling = true)]
			public static extern int GetSwapInterval();

			// Token: 0x060046D3 RID: 18131
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_MakeCurrent", ExactSpelling = true)]
			public static extern int MakeCurrent(IntPtr window, IntPtr context);

			// Token: 0x060046D4 RID: 18132
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SetAttribute", ExactSpelling = true)]
			public static extern int SetAttribute(ContextAttribute attr, int value);

			// Token: 0x060046D5 RID: 18133 RVA: 0x000C34C8 File Offset: 0x000C16C8
			public static int SetAttribute(ContextAttribute attr, ContextFlags value)
			{
				return SDL.GL.SetAttribute(attr, (int)value);
			}

			// Token: 0x060046D6 RID: 18134 RVA: 0x000C34D4 File Offset: 0x000C16D4
			public static int SetAttribute(ContextAttribute attr, ContextProfileFlags value)
			{
				return SDL.GL.SetAttribute(attr, (int)value);
			}

			// Token: 0x060046D7 RID: 18135
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SetSwapInterval", ExactSpelling = true)]
			public static extern int SetSwapInterval(int interval);

			// Token: 0x060046D8 RID: 18136
			[SuppressUnmanagedCodeSecurity]
			[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_SwapWindow", ExactSpelling = true)]
			public static extern void SwapWindow(IntPtr window);
		}
	}
}
