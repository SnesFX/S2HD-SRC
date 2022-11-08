using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000081 RID: 129
	internal static class Functions
	{
		// Token: 0x060007AA RID: 1962
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetWindowPos(IntPtr handle, IntPtr insertAfter, int x, int y, int cx, int cy, SetWindowPosFlags flags);

		// Token: 0x060007AB RID: 1963
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool AdjustWindowRect([In] [Out] ref Win32Rectangle lpRect, WindowStyle dwStyle, bool bMenu);

		// Token: 0x060007AC RID: 1964
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool AdjustWindowRectEx(ref Win32Rectangle lpRect, WindowStyle dwStyle, [MarshalAs(UnmanagedType.Bool)] bool bMenu, ExtendedWindowStyle dwExStyle);

		// Token: 0x060007AD RID: 1965
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern IntPtr CreateWindowEx(ExtendedWindowStyle ExStyle, [MarshalAs(UnmanagedType.LPTStr)] string className, [MarshalAs(UnmanagedType.LPTStr)] string windowName, WindowStyle Style, int X, int Y, int Width, int Height, IntPtr HandleToParentWindow, IntPtr Menu, IntPtr Instance, IntPtr Param);

		// Token: 0x060007AE RID: 1966
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern IntPtr CreateWindowEx(ExtendedWindowStyle ExStyle, IntPtr ClassAtom, IntPtr WindowName, WindowStyle Style, int X, int Y, int Width, int Height, IntPtr HandleToParentWindow, IntPtr Menu, IntPtr Instance, IntPtr Param);

		// Token: 0x060007AF RID: 1967
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DestroyWindow(IntPtr windowHandle);

		// Token: 0x060007B0 RID: 1968
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern ushort RegisterClass(ref WindowClass window_class);

		// Token: 0x060007B1 RID: 1969
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern ushort RegisterClassEx(ref ExtendedWindowClass window_class);

		// Token: 0x060007B2 RID: 1970
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern short UnregisterClass([MarshalAs(UnmanagedType.LPTStr)] string className, IntPtr instance);

		// Token: 0x060007B3 RID: 1971
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern short UnregisterClass(IntPtr className, IntPtr instance);

		// Token: 0x060007B4 RID: 1972
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool GetClassInfoEx(IntPtr hinst, [MarshalAs(UnmanagedType.LPTStr)] string lpszClass, ref ExtendedWindowClass lpwcx);

		// Token: 0x060007B5 RID: 1973
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool GetClassInfoEx(IntPtr hinst, UIntPtr lpszClass, ref ExtendedWindowClass lpwcx);

		// Token: 0x060007B6 RID: 1974
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, WindowMessage Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x060007B7 RID: 1975 RVA: 0x0001A894 File Offset: 0x00018A94
		internal static IntPtr SetWindowLong(IntPtr handle, GetWindowLongOffsets item, IntPtr newValue)
		{
			IntPtr intPtr = IntPtr.Zero;
			Functions.SetLastError(0);
			if (IntPtr.Size == 4)
			{
				intPtr = new IntPtr(Functions.SetWindowLongInternal(handle, item, newValue.ToInt32()));
			}
			else
			{
				intPtr = Functions.SetWindowLongPtrInternal(handle, item, newValue);
			}
			if (intPtr == IntPtr.Zero)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error != 0)
				{
					throw new PlatformException(string.Format("Failed to modify window border. Error: {0}", lastWin32Error));
				}
			}
			return intPtr;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0001A904 File Offset: 0x00018B04
		internal static IntPtr SetWindowLong(IntPtr handle, WindowProcedure newValue)
		{
			return Functions.SetWindowLong(handle, GetWindowLongOffsets.WNDPROC, Marshal.GetFunctionPointerForDelegate(newValue));
		}

		// Token: 0x060007B9 RID: 1977
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
		private static extern int SetWindowLongInternal(IntPtr hWnd, GetWindowLongOffsets nIndex, int dwNewLong);

		// Token: 0x060007BA RID: 1978
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
		private static extern IntPtr SetWindowLongPtrInternal(IntPtr hWnd, GetWindowLongOffsets nIndex, IntPtr dwNewLong);

		// Token: 0x060007BB RID: 1979
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
		private static extern int SetWindowLongInternal(IntPtr hWnd, GetWindowLongOffsets nIndex, [MarshalAs(UnmanagedType.FunctionPtr)] WindowProcedure dwNewLong);

		// Token: 0x060007BC RID: 1980
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
		private static extern IntPtr SetWindowLongPtrInternal(IntPtr hWnd, GetWindowLongOffsets nIndex, [MarshalAs(UnmanagedType.FunctionPtr)] WindowProcedure dwNewLong);

		// Token: 0x060007BD RID: 1981 RVA: 0x0001A914 File Offset: 0x00018B14
		internal static UIntPtr GetWindowLong(IntPtr handle, GetWindowLongOffsets index)
		{
			if (IntPtr.Size == 4)
			{
				return (UIntPtr)Functions.GetWindowLongInternal(handle, index);
			}
			return Functions.GetWindowLongPtrInternal(handle, index);
		}

		// Token: 0x060007BE RID: 1982
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
		private static extern uint GetWindowLongInternal(IntPtr hWnd, GetWindowLongOffsets nIndex);

		// Token: 0x060007BF RID: 1983
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", SetLastError = true)]
		private static extern UIntPtr GetWindowLongPtrInternal(IntPtr hWnd, GetWindowLongOffsets nIndex);

		// Token: 0x060007C0 RID: 1984
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool PeekMessage(ref MSG msg, IntPtr hWnd, int messageFilterMin, int messageFilterMax, PeekMessageFlags flags);

		// Token: 0x060007C1 RID: 1985
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll")]
		internal static extern int GetMessage(ref MSG msg, IntPtr windowHandle, int messageFilterMin, int messageFilterMax);

		// Token: 0x060007C2 RID: 1986
		[DllImport("User32.dll")]
		internal static extern int GetMessageTime();

		// Token: 0x060007C3 RID: 1987
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, WindowMessage Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x060007C4 RID: 1988
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool PostMessage(IntPtr hWnd, WindowMessage Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x060007C5 RID: 1989
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		internal static extern void PostQuitMessage(int exitCode);

		// Token: 0x060007C6 RID: 1990
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("User32.dll")]
		internal static extern IntPtr DispatchMessage(ref MSG msg);

		// Token: 0x060007C7 RID: 1991
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll")]
		internal static extern bool TranslateMessage(ref MSG lpMsg);

		// Token: 0x060007C8 RID: 1992
		[SuppressUnmanagedCodeSecurity]
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		internal static extern int GetQueueStatus([MarshalAs(UnmanagedType.U4)] QueueStatusFlags flags);

		// Token: 0x060007C9 RID: 1993
		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr DefWindowProc(IntPtr hWnd, WindowMessage msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x060007CA RID: 1994
		[SuppressUnmanagedCodeSecurity]
		[DllImport("winmm.dll")]
		internal static extern IntPtr TimeBeginPeriod(int period);

		// Token: 0x060007CB RID: 1995
		[SuppressUnmanagedCodeSecurity]
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool QueryPerformanceFrequency(ref long PerformanceFrequency);

		// Token: 0x060007CC RID: 1996
		[SuppressUnmanagedCodeSecurity]
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool QueryPerformanceCounter(ref long PerformanceCount);

		// Token: 0x060007CD RID: 1997
		[DllImport("user32.dll")]
		internal static extern IntPtr GetDC(IntPtr hwnd);

		// Token: 0x060007CE RID: 1998
		[DllImport("user32.dll")]
		internal static extern IntPtr GetWindowDC(IntPtr hwnd);

		// Token: 0x060007CF RID: 1999
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool ReleaseDC(IntPtr hwnd, IntPtr DC);

		// Token: 0x060007D0 RID: 2000
		[DllImport("gdi32.dll")]
		internal static extern int ChoosePixelFormat(IntPtr dc, ref PixelFormatDescriptor pfd);

		// Token: 0x060007D1 RID: 2001
		[DllImport("gdi32.dll")]
		internal static extern int DescribePixelFormat(IntPtr deviceContext, int pixel, int pfdSize, ref PixelFormatDescriptor pixelFormat);

		// Token: 0x060007D2 RID: 2002
		[DllImport("gdi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetPixelFormat(IntPtr dc, int format, ref PixelFormatDescriptor pfd);

		// Token: 0x060007D3 RID: 2003
		[SuppressUnmanagedCodeSecurity]
		[DllImport("gdi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SwapBuffers(IntPtr dc);

		// Token: 0x060007D4 RID: 2004
		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetProcAddress(IntPtr handle, string funcname);

		// Token: 0x060007D5 RID: 2005
		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetProcAddress(IntPtr handle, IntPtr funcname);

		// Token: 0x060007D6 RID: 2006
		[DllImport("kernel32.dll")]
		internal static extern void SetLastError(int dwErrCode);

		// Token: 0x060007D7 RID: 2007
		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPTStr)] string module_name);

		// Token: 0x060007D8 RID: 2008
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern IntPtr LoadLibrary(string dllName);

		// Token: 0x060007D9 RID: 2009
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool FreeLibrary(IntPtr handle);

		// Token: 0x060007DA RID: 2010
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern short GetAsyncKeyState(VirtualKeys vKey);

		// Token: 0x060007DB RID: 2011
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern short GetKeyState(VirtualKeys vKey);

		// Token: 0x060007DC RID: 2012
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint MapVirtualKey(uint uCode, MapVirtualKeyType uMapType);

		// Token: 0x060007DD RID: 2013
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint MapVirtualKey(VirtualKeys vkey, MapVirtualKeyType uMapType);

		// Token: 0x060007DE RID: 2014
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommand nCmdShow);

		// Token: 0x060007DF RID: 2015
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern bool SetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.LPTStr)] string lpString);

		// Token: 0x060007E0 RID: 2016
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern int GetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.LPTStr)] [In] [Out] StringBuilder lpString, int nMaxCount);

		// Token: 0x060007E1 RID: 2017
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool ScreenToClient(IntPtr hWnd, ref Point point);

		// Token: 0x060007E2 RID: 2018
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool ClientToScreen(IntPtr hWnd, ref Point point);

		// Token: 0x060007E3 RID: 2019
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool GetClientRect(IntPtr windowHandle, out Win32Rectangle clientRectangle);

		// Token: 0x060007E4 RID: 2020
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool GetWindowRect(IntPtr windowHandle, out Win32Rectangle windowRectangle);

		// Token: 0x060007E5 RID: 2021
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll")]
		internal static extern bool GetWindowInfo(IntPtr hwnd, ref WindowInfo wi);

		// Token: 0x060007E6 RID: 2022
		[DllImport("dwmapi.dll")]
		public unsafe static extern IntPtr DwmGetWindowAttribute(IntPtr hwnd, DwmWindowAttribute dwAttribute, void* pvAttribute, int cbAttribute);

		// Token: 0x060007E7 RID: 2023
		[DllImport("user32.dll")]
		public static extern IntPtr GetFocus();

		// Token: 0x060007E8 RID: 2024
		[DllImport("user32.dll")]
		public static extern bool IsWindowVisible(IntPtr intPtr);

		// Token: 0x060007E9 RID: 2025
		[DllImport("user32.dll")]
		public static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

		// Token: 0x060007EA RID: 2026
		[DllImport("user32.dll")]
		public static extern IntPtr LoadCursor(IntPtr hInstance, string lpCursorName);

		// Token: 0x060007EB RID: 2027
		[DllImport("user32.dll")]
		public static extern IntPtr LoadCursor(IntPtr hInstance, IntPtr lpCursorName);

		// Token: 0x060007EC RID: 2028 RVA: 0x0001A934 File Offset: 0x00018B34
		public static IntPtr LoadCursor(CursorName lpCursorName)
		{
			return Functions.LoadCursor(IntPtr.Zero, new IntPtr((int)lpCursorName));
		}

		// Token: 0x060007ED RID: 2029
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr CreateIconIndirect(ref IconInfo iconInfo);

		// Token: 0x060007EE RID: 2030
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetIconInfo(IntPtr hIcon, out IconInfo pIconInfo);

		// Token: 0x060007EF RID: 2031
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool DestroyIcon(IntPtr hIcon);

		// Token: 0x060007F0 RID: 2032
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x060007F1 RID: 2033
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool BringWindowToTop(IntPtr hWnd);

		// Token: 0x060007F2 RID: 2034
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetParent(IntPtr child, IntPtr newParent);

		// Token: 0x060007F3 RID: 2035
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, DeviceNotification Flags);

		// Token: 0x060007F4 RID: 2036
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool UnregisterDeviceNotification(IntPtr Handle);

		// Token: 0x060007F5 RID: 2037
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int ChangeDisplaySettings(DeviceMode device_mode, ChangeDisplaySettingsEnum flags);

		// Token: 0x060007F6 RID: 2038
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int ChangeDisplaySettingsEx([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, DeviceMode lpDevMode, IntPtr hwnd, ChangeDisplaySettingsEnum dwflags, IntPtr lParam);

		// Token: 0x060007F7 RID: 2039
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumDisplayDevices([MarshalAs(UnmanagedType.LPTStr)] string lpDevice, int iDevNum, [In] [Out] WindowsDisplayDevice lpDisplayDevice, int dwFlags);

		// Token: 0x060007F8 RID: 2040
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool EnumDisplaySettings([MarshalAs(UnmanagedType.LPTStr)] string device_name, int graphics_mode, [In] [Out] DeviceMode device_mode);

		// Token: 0x060007F9 RID: 2041
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool EnumDisplaySettings([MarshalAs(UnmanagedType.LPTStr)] string device_name, DisplayModeSettingsEnum graphics_mode, [In] [Out] DeviceMode device_mode);

		// Token: 0x060007FA RID: 2042
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool EnumDisplaySettingsEx([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, DisplayModeSettingsEnum iModeNum, [In] [Out] DeviceMode lpDevMode, int dwFlags);

		// Token: 0x060007FB RID: 2043
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool EnumDisplaySettingsEx([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, int iModeNum, [In] [Out] DeviceMode lpDevMode, int dwFlags);

		// Token: 0x060007FC RID: 2044
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MonitorInfo lpmi);

		// Token: 0x060007FD RID: 2045
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr MonitorFromPoint(POINT pt, MonitorFrom dwFlags);

		// Token: 0x060007FE RID: 2046
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr MonitorFromWindow(IntPtr hwnd, MonitorFrom dwFlags);

		// Token: 0x060007FF RID: 2047
		[DllImport("user32.dll")]
		internal static extern bool SetProcessDPIAware();

		// Token: 0x06000800 RID: 2048
		[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
		public static extern int GetDeviceCaps(IntPtr hDC, DeviceCaps nIndex);

		// Token: 0x06000801 RID: 2049
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool TrackMouseEvent(ref TrackMouseEventStructure lpEventTrack);

		// Token: 0x06000802 RID: 2050
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
		public static extern bool ReleaseCapture();

		// Token: 0x06000803 RID: 2051
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr SetCapture(IntPtr hwnd);

		// Token: 0x06000804 RID: 2052
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr GetCapture();

		// Token: 0x06000805 RID: 2053
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr SetFocus(IntPtr hwnd);

		// Token: 0x06000806 RID: 2054
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int ShowCursor(bool show);

		// Token: 0x06000807 RID: 2055
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool ClipCursor(ref Win32Rectangle rcClip);

		// Token: 0x06000808 RID: 2056
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool ClipCursor(IntPtr rcClip);

		// Token: 0x06000809 RID: 2057
		[DllImport("user32.dll")]
		public static extern bool SetCursorPos(int X, int Y);

		// Token: 0x0600080A RID: 2058
		[DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
		internal unsafe static extern int GetMouseMovePointsEx(uint cbSize, MouseMovePoint* pointsIn, MouseMovePoint* pointsBufferOut, int nBufPoints, uint resolution);

		// Token: 0x0600080B RID: 2059
		[DllImport("user32.dll")]
		public static extern IntPtr SetCursor(IntPtr hCursor);

		// Token: 0x0600080C RID: 2060
		[DllImport("user32.dll")]
		public static extern IntPtr GetCursor();

		// Token: 0x0600080D RID: 2061
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool GetCursorPos(ref POINT point);

		// Token: 0x0600080E RID: 2062
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr DefRawInputProc(RawInput[] RawInput, int Input, uint SizeHeader);

		// Token: 0x0600080F RID: 2063
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr DefRawInputProc(ref RawInput RawInput, int Input, uint SizeHeader);

		// Token: 0x06000810 RID: 2064
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern IntPtr DefRawInputProc(IntPtr RawInput, int Input, uint SizeHeader);

		// Token: 0x06000811 RID: 2065
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool RegisterRawInputDevices(RawInputDevice[] RawInputDevices, uint NumDevices, uint Size);

		// Token: 0x06000812 RID: 2066
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool RegisterRawInputDevices(RawInputDevice[] RawInputDevices, int NumDevices, int Size);

		// Token: 0x06000813 RID: 2067
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint GetRawInputBuffer([Out] RawInput[] Data, [In] [Out] ref uint Size, [In] uint SizeHeader);

		// Token: 0x06000814 RID: 2068
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRawInputBuffer([Out] RawInput[] Data, [In] [Out] ref int Size, [In] int SizeHeader);

		// Token: 0x06000815 RID: 2069
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRawInputBuffer([Out] IntPtr Data, [In] [Out] ref int Size, [In] int SizeHeader);

		// Token: 0x06000816 RID: 2070
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint GetRegisteredRawInputDevices([Out] RawInput[] RawInputDevices, [In] [Out] ref uint NumDevices, uint cbSize);

		// Token: 0x06000817 RID: 2071
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRegisteredRawInputDevices([Out] RawInput[] RawInputDevices, [In] [Out] ref int NumDevices, int cbSize);

		// Token: 0x06000818 RID: 2072
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint GetRawInputDeviceList([In] [Out] RawInputDeviceList[] RawInputDeviceList, [In] [Out] ref uint NumDevices, uint Size);

		// Token: 0x06000819 RID: 2073
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRawInputDeviceList([In] [Out] RawInputDeviceList[] RawInputDeviceList, [In] [Out] ref int NumDevices, int Size);

		// Token: 0x0600081A RID: 2074
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint GetRawInputDeviceList([In] [Out] IntPtr RawInputDeviceList, [In] [Out] ref uint NumDevices, uint Size);

		// Token: 0x0600081B RID: 2075
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRawInputDeviceList([In] [Out] IntPtr RawInputDeviceList, [In] [Out] ref int NumDevices, int Size);

		// Token: 0x0600081C RID: 2076
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint GetRawInputDeviceInfo(IntPtr Device, [MarshalAs(UnmanagedType.U4)] RawInputDeviceInfoEnum Command, [In] [Out] IntPtr Data, [In] [Out] ref uint Size);

		// Token: 0x0600081D RID: 2077
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRawInputDeviceInfo(IntPtr Device, [MarshalAs(UnmanagedType.U4)] RawInputDeviceInfoEnum Command, [In] [Out] IntPtr Data, [In] [Out] ref int Size);

		// Token: 0x0600081E RID: 2078
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint GetRawInputDeviceInfo(IntPtr Device, [MarshalAs(UnmanagedType.U4)] RawInputDeviceInfoEnum Command, [In] [Out] RawInputDeviceInfo Data, [In] [Out] ref uint Size);

		// Token: 0x0600081F RID: 2079
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRawInputDeviceInfo(IntPtr Device, [MarshalAs(UnmanagedType.U4)] RawInputDeviceInfoEnum Command, [In] [Out] RawInputDeviceInfo Data, [In] [Out] ref int Size);

		// Token: 0x06000820 RID: 2080
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRawInputData(IntPtr RawInput, GetRawInputDataEnum Command, [Out] IntPtr Data, [In] [Out] ref int Size, int SizeHeader);

		// Token: 0x06000821 RID: 2081
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetRawInputData(IntPtr RawInput, GetRawInputDataEnum Command, out RawInput Data, [In] [Out] ref int Size, int SizeHeader);

		// Token: 0x06000822 RID: 2082
		[SuppressUnmanagedCodeSecurity]
		[DllImport("user32.dll", SetLastError = true)]
		internal unsafe static extern int GetRawInputData(IntPtr RawInput, GetRawInputDataEnum Command, RawInput* Data, [In] [Out] ref int Size, int SizeHeader);

		// Token: 0x06000823 RID: 2083 RVA: 0x0001A948 File Offset: 0x00018B48
		internal unsafe static IntPtr NextRawInputStructure(IntPtr data)
		{
			return Functions.RawInputAlign((IntPtr)((void*)((byte*)((void*)data) + API.RawInputHeaderSize)));
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0001A960 File Offset: 0x00018B60
		private unsafe static IntPtr RawInputAlign(IntPtr data)
		{
			return (IntPtr)((void*)((byte*)((void*)data) + (IntPtr.Size - 1 & ~(IntPtr.Size - 1))));
		}

		// Token: 0x06000825 RID: 2085
		[DllImport("gdi32.dll", SetLastError = true)]
		internal static extern IntPtr GetStockObject(int index);

		// Token: 0x06000826 RID: 2086
		[DllImport("user32.dll", SetLastError = true)]
		public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent, uint uElapse, Functions.TimerProc lpTimerFunc);

		// Token: 0x06000827 RID: 2087
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool KillTimer(IntPtr hWnd, UIntPtr uIDEvent);

		// Token: 0x06000828 RID: 2088
		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, ShGetFileIconFlags uFlags);

		// Token: 0x06000829 RID: 2089
		[DllImport("Advapi32.dll")]
		internal static extern int RegOpenKeyEx(IntPtr hKey, [MarshalAs(UnmanagedType.LPTStr)] string lpSubKey, int ulOptions, uint samDesired, out IntPtr phkResult);

		// Token: 0x0600082A RID: 2090
		[DllImport("Advapi32.dll")]
		internal static extern int RegGetValue(IntPtr hkey, [MarshalAs(UnmanagedType.LPTStr)] string lpSubKey, [MarshalAs(UnmanagedType.LPTStr)] string lpValue, int dwFlags, out int pdwType, StringBuilder pvData, ref int pcbData);

		// Token: 0x02000082 RID: 130
		// (Invoke) Token: 0x0600082C RID: 2092
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void TimerProc(IntPtr hwnd, WindowMessage uMsg, UIntPtr idEvent, int dwTime);
	}
}
