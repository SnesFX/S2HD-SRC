using System;
using System.Runtime.InteropServices;
using OpenTK.Platform.SDL2;
using OpenTK.Platform.X11;

namespace OpenTK
{
	// Token: 0x0200005A RID: 90
	public sealed class Configuration
	{
		// Token: 0x0600067C RID: 1660 RVA: 0x0001765C File Offset: 0x0001585C
		private Configuration()
		{
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x00017664 File Offset: 0x00015864
		public static bool RunningOnWindows
		{
			get
			{
				return Configuration.runningOnWindows;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x0001766C File Offset: 0x0001586C
		public static bool RunningOnX11
		{
			get
			{
				return Configuration.runningOnX11;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x00017674 File Offset: 0x00015874
		public static bool RunningOnUnix
		{
			get
			{
				return Configuration.runningOnUnix;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x0001767C File Offset: 0x0001587C
		// (set) Token: 0x06000681 RID: 1665 RVA: 0x00017684 File Offset: 0x00015884
		public static bool RunningOnSdl2 { get; private set; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x0001768C File Offset: 0x0001588C
		public static bool RunningOnLinux
		{
			get
			{
				return Configuration.runningOnLinux;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00017694 File Offset: 0x00015894
		public static bool RunningOnMacOS
		{
			get
			{
				return Configuration.runningOnMacOS;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x0001769C File Offset: 0x0001589C
		public static bool RunningOnMono
		{
			get
			{
				return Configuration.runningOnMono;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x000176A4 File Offset: 0x000158A4
		public static bool RunningOnAndroid
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x000176A8 File Offset: 0x000158A8
		private static string DetectUnixKernel()
		{
			Configuration.utsname utsname = default(Configuration.utsname);
			Configuration.uname(out utsname);
			return utsname.sysname.ToString();
		}

		// Token: 0x06000687 RID: 1671
		[DllImport("libc")]
		private static extern void uname(out Configuration.utsname uname_struct);

		// Token: 0x06000688 RID: 1672 RVA: 0x000176D0 File Offset: 0x000158D0
		private static bool DetectMono()
		{
			Type type = Type.GetType("Mono.Runtime");
			return type != null;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x000176F0 File Offset: 0x000158F0
		private static bool DetectSdl2()
		{
			bool result = false;
			OpenTK.Platform.SDL2.Version version = default(OpenTK.Platform.SDL2.Version);
			try
			{
				if (SDL.Version.Number >= 2000)
				{
					if (SDL.WasInit(SystemFlags.Default))
					{
						result = true;
					}
					else
					{
						SystemFlags flags = SystemFlags.TIMER | SystemFlags.VIDEO;
						if (SDL.Init(flags) == 0)
						{
							result = true;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001774C File Offset: 0x0001594C
		private static void DetectUnix(out bool unix, out bool linux, out bool macos)
		{
			unix = (linux = (macos = false));
			string text = Configuration.DetectUnixKernel();
			string a;
			if ((a = text) == null || a == "")
			{
				throw new PlatformNotSupportedException("Unknown platform. Please file a bug report at http://www.opentk.com");
			}
			if (a == "Linux")
			{
				linux = (unix = true);
				return;
			}
			if (!(a == "Darwin"))
			{
				unix = true;
				return;
			}
			macos = (unix = true);
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x000177C0 File Offset: 0x000159C0
		private static bool DetectWindows()
		{
			return Environment.OSVersion.Platform == PlatformID.Win32NT || Environment.OSVersion.Platform == PlatformID.Win32S || Environment.OSVersion.Platform == PlatformID.Win32Windows || Environment.OSVersion.Platform == PlatformID.WinCE;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x000177F8 File Offset: 0x000159F8
		private static bool DetectX11()
		{
			bool result;
			try
			{
				result = (API.DefaultDisplay != IntPtr.Zero);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00017830 File Offset: 0x00015A30
		internal static void Init(ToolkitOptions options)
		{
			lock (Configuration.InitLock)
			{
				if (!Configuration.initialized)
				{
					Configuration.runningOnMono = Configuration.DetectMono();
					Configuration.runningOnWindows = Configuration.DetectWindows();
					if (!Configuration.runningOnWindows)
					{
						Configuration.DetectUnix(out Configuration.runningOnUnix, out Configuration.runningOnLinux, out Configuration.runningOnMacOS);
					}
					if (options.Backend == PlatformBackend.Default)
					{
						Configuration.RunningOnSdl2 = Configuration.DetectSdl2();
					}
					if ((Configuration.runningOnLinux && !Configuration.RunningOnSdl2) || options.Backend == PlatformBackend.PreferX11)
					{
						Configuration.runningOnX11 = Configuration.DetectX11();
					}
					Configuration.initialized = true;
				}
			}
		}

		// Token: 0x040001B4 RID: 436
		private static bool runningOnWindows;

		// Token: 0x040001B5 RID: 437
		private static bool runningOnUnix;

		// Token: 0x040001B6 RID: 438
		private static bool runningOnX11;

		// Token: 0x040001B7 RID: 439
		private static bool runningOnMacOS;

		// Token: 0x040001B8 RID: 440
		private static bool runningOnLinux;

		// Token: 0x040001B9 RID: 441
		private static bool runningOnMono;

		// Token: 0x040001BA RID: 442
		private static volatile bool initialized;

		// Token: 0x040001BB RID: 443
		private static readonly object InitLock = new object();

		// Token: 0x0200005B RID: 91
		private struct utsname
		{
			// Token: 0x040001BD RID: 445
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string sysname;

			// Token: 0x040001BE RID: 446
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string nodename;

			// Token: 0x040001BF RID: 447
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string release;

			// Token: 0x040001C0 RID: 448
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string version;

			// Token: 0x040001C1 RID: 449
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string machine;

			// Token: 0x040001C2 RID: 450
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
			public string extraJustInCase;
		}
	}
}
