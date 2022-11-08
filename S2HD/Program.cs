using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using SonicOrca;
using SonicOrca.SDL2;

namespace S2HD
{
	// Token: 0x020000A2 RID: 162
	public static class Program
	{
		// Token: 0x060003AB RID: 939
		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

		// Token: 0x060003AC RID: 940
		[DllImport("user32.dll")]
		private static extern int MessageBox(IntPtr hwnd, string text, string caption, uint type);

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060003AD RID: 941 RVA: 0x0001A001 File Offset: 0x00018201
		// (set) Token: 0x060003AE RID: 942 RVA: 0x0001A008 File Offset: 0x00018208
		public static IniConfiguration Configuration { get; private set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060003AF RID: 943 RVA: 0x0001A010 File Offset: 0x00018210
		public static string UserDataDirectory
		{
			get
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "SonicOrca");
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x0001A022 File Offset: 0x00018222
		private static string LogPath
		{
			get
			{
				return Path.Combine(Program.UserDataDirectory, "sonicorca.log");
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x0001A033 File Offset: 0x00018233
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x0001A03A File Offset: 0x0001823A
		public static IReadOnlyList<string> CommandLineArguments { get; private set; }

		// Token: 0x060003B3 RID: 947 RVA: 0x0001A042 File Offset: 0x00018242
		[STAThread]
		private static void Main(string[] args)
		{
			Program.CommandLineArguments = args;
			Program.EnsureUserDataDirectoryExists();
			Program.WriteLogHeader();
			Program.LoadConfiguration();
			Program.RunOrFocusGame();
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0001A05E File Offset: 0x0001825E
		private static void EnsureUserDataDirectoryExists()
		{
			if (!Directory.Exists(Program.UserDataDirectory))
			{
				Directory.CreateDirectory(Program.UserDataDirectory);
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0001A078 File Offset: 0x00018278
		private static void LoadConfiguration()
		{
			string path = Path.Combine(Program.UserDataDirectory, Program.IniConfigurationPath);
			if (File.Exists(path))
			{
				Program.Configuration = new IniConfiguration(path);
				return;
			}
			Program.Configuration = new IniConfiguration();
			Program.Configuration.SetProperty("video", "fullscreen", "0");
			Program.Configuration.SetProperty("audio", "volume", "1.0");
			Program.Configuration.SetProperty("audio", "music_volume", "0.5");
			Program.Configuration.SetProperty("audio", "sound_volume", "1.0");
			Program.Configuration.Save(path);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0001A124 File Offset: 0x00018324
		private static void RunOrFocusGame()
		{
			bool flag;
			using (new Mutex(true, "SonicOrca", ref flag))
			{
				if (flag || Program.Configuration.GetPropertyBoolean("debug", "allow_multiple_instances", false))
				{
					Program.RunGame();
				}
				else
				{
					Program.FocusGame();
				}
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0001A184 File Offset: 0x00018384
		private static IPlatform GetPlatform()
		{
			return SDL2Platform.Instance;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0001A18C File Offset: 0x0001838C
		private static void RunGame()
		{
			using (IPlatform platform = Program.GetPlatform())
			{
				try
				{
					platform.Initialise();
				}
				catch (Exception ex)
				{
					Program.LogException(ex, true);
					Program.ShowErrorMessageBox(ex.Message);
					return;
				}
				if (!Program.CheckOpenGL(platform))
				{
					return;
				}
				using (S2HDSonicOrcaGameContext s2HDSonicOrcaGameContext = new S2HDSonicOrcaGameContext(platform))
				{
					try
					{
						Trace.WriteLine("Initialising game");
						Trace.Indent();
						s2HDSonicOrcaGameContext.Initialise();
						Trace.Unindent();
						Trace.WriteLine("Running game");
						Trace.Indent();
						s2HDSonicOrcaGameContext.Run();
					}
					catch (Exception ex2)
					{
						if (Debugger.IsAttached)
						{
							throw;
						}
						Program.LogException(ex2, true);
						Program.ShowErrorMessageBox(ex2.Message);
					}
					finally
					{
						Trace.Unindent();
					}
				}
			}
			Trace.Unindent();
			Trace.WriteLine(new string('-', 80));
			Trace.WriteLine(string.Empty);
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0001A298 File Offset: 0x00018498
		private static void FocusGame()
		{
			Process current = Process.GetCurrentProcess();
			Process process = (from x in Process.GetProcessesByName(current.ProcessName)
			where x.Id != current.Id
			select x).FirstOrDefault<Process>();
			if (process == null)
			{
				return;
			}
			Program.SetForegroundWindow(process.MainWindowHandle);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0001A2F0 File Offset: 0x000184F0
		private static bool CheckOpenGL(IPlatform platform)
		{
			Trace.WriteLine("Verifying OpenGL version");
			Version openGLVersion = platform.GetOpenGLVersion();
			Trace.WriteLine(string.Format("OpenGL {0}.{1}", openGLVersion.Major, openGLVersion.Minor));
			if (openGLVersion < Program.AppMinOpenGLVersion)
			{
				Trace.WriteLine("OpenGL version too low");
				Program.ShowErrorMessageBox(string.Format("OpenGL {0}.{1} or later is required.", Program.AppMinOpenGLVersion.Major, Program.AppMinOpenGLVersion.Minor));
				return false;
			}
			return true;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0001A37A File Offset: 0x0001857A
		public static void ShowErrorMessageBox(string text)
		{
			Program.MessageBox(IntPtr.Zero, text, "SonicOrca", 48U);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0001A390 File Offset: 0x00018590
		private static void WriteLogHeader()
		{
			Trace.AutoFlush = true;
			Trace.Listeners.Add(new TextWriterTraceListener(Program.LogPath));
			Trace.Listeners.Add(new ConsoleTraceListener());
			Trace.WriteLine(Environment.OSVersion);
			Trace.WriteLine(string.Format("SonicOrca {0} [{1} {2}]", Program.AppVersion, "RELEASE", Program.AppArchitecture));
			Trace.WriteLine(DateTime.Now.ToString("dd MMMM yyyy @ hh:mm tt"));
			Trace.WriteLine(new string('-', 80));
			Trace.Indent();
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0001A41C File Offset: 0x0001861C
		public static void LogException(Exception ex, bool logStackTrace = true)
		{
			string[] array = ex.Message.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			if (array.Length <= 1)
			{
				Trace.WriteLine("EXCEPTION: " + array[0]);
			}
			else
			{
				Trace.WriteLine("EXCEPTION:");
				Trace.Indent();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					Trace.WriteLine(array2[i]);
				}
				Trace.Unindent();
			}
			if (ex.InnerException != null)
			{
				Trace.Indent();
				Program.LogException(ex.InnerException, true);
				Trace.Unindent();
			}
			if (logStackTrace && !string.IsNullOrEmpty(ex.StackTrace))
			{
				string[] array3 = ex.StackTrace.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				Trace.WriteLine("STACK TRACE:");
				Trace.Indent();
				string[] array2 = array3;
				for (int i = 0; i < array2.Length; i++)
				{
					Trace.WriteLine(array2[i].Trim());
				}
				Trace.Unindent();
			}
		}

		// Token: 0x04000455 RID: 1109
		public const string BuildConfigurationName = "RELEASE";

		// Token: 0x04000456 RID: 1110
		public static Version AppVersion = Assembly.GetExecutingAssembly().GetName().Version;

		// Token: 0x04000457 RID: 1111
		public static string AppArchitecture = Environment.Is64BitProcess ? "x64" : "x86";

		// Token: 0x04000458 RID: 1112
		public static Version AppMinOpenGLVersion = new Version(3, 3);

		// Token: 0x04000459 RID: 1113
		private static string IniConfigurationPath = "sonicorca.cfg";
	}
}
