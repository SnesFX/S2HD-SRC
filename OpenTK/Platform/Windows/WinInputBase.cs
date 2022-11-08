using System;
using System.Runtime.InteropServices;
using System.Threading;
using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200002E RID: 46
	internal abstract class WinInputBase : IInputDriver2, IDisposable
	{
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x000140E4 File Offset: 0x000122E4
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x000140EC File Offset: 0x000122EC
		private protected INativeWindow Native
		{
			protected get
			{
				return this.native;
			}
			private set
			{
				this.native = value;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x000140F8 File Offset: 0x000122F8
		protected WinWindowInfo Parent
		{
			get
			{
				return (WinWindowInfo)this.Native.WindowInfo;
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0001410C File Offset: 0x0001230C
		public WinInputBase()
		{
			this.WndProc = new WindowProcedure(this.WindowProcedure);
			this.InputThread = new Thread(new ThreadStart(this.ProcessEvents));
			this.InputThread.SetApartmentState(ApartmentState.STA);
			this.InputThread.IsBackground = true;
			this.InputThread.Start();
			this.InputReady.WaitOne();
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00014184 File Offset: 0x00012384
		private INativeWindow ConstructMessageWindow()
		{
			INativeWindow nativeWindow = new NativeWindow();
			nativeWindow.ProcessEvents();
			WinWindowInfo winWindowInfo = nativeWindow.WindowInfo as WinWindowInfo;
			Functions.SetParent(winWindowInfo.Handle, Constants.MESSAGE_ONLY);
			nativeWindow.ProcessEvents();
			return nativeWindow;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x000141C4 File Offset: 0x000123C4
		private void ProcessEvents()
		{
			this.Native = this.ConstructMessageWindow();
			this.CreateDrivers();
			this.OldWndProc = Functions.SetWindowLong(this.Parent.Handle, this.WndProc);
			this.InputReady.Set();
			MSG msg = default(MSG);
			while (this.Native.Exists)
			{
				int message = Functions.GetMessage(ref msg, this.Parent.Handle, 0, 0);
				if (message == -1)
				{
					throw new PlatformException(string.Format("An error happened while processing the message queue. Windows error: {0}", Marshal.GetLastWin32Error()));
				}
				Functions.TranslateMessage(ref msg);
				Functions.DispatchMessage(ref msg);
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00014268 File Offset: 0x00012468
		private IntPtr WndProcHandler(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			IntPtr intPtr = this.WindowProcedure(handle, message, wParam, lParam);
			if (intPtr == WinInputBase.Unhandled)
			{
				return Functions.CallWindowProc(this.OldWndProc, handle, message, wParam, lParam);
			}
			return intPtr;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x000142A0 File Offset: 0x000124A0
		protected virtual IntPtr WindowProcedure(IntPtr handle, WindowMessage message, IntPtr wParam, IntPtr lParam)
		{
			return WinInputBase.Unhandled;
		}

		// Token: 0x060004C4 RID: 1220
		protected abstract void CreateDrivers();

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060004C5 RID: 1221
		public abstract IMouseDriver2 MouseDriver { get; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060004C6 RID: 1222
		public abstract IKeyboardDriver2 KeyboardDriver { get; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060004C7 RID: 1223
		public abstract IGamePadDriver GamePadDriver { get; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060004C8 RID: 1224
		public abstract IJoystickDriver2 JoystickDriver { get; }

		// Token: 0x060004C9 RID: 1225 RVA: 0x000142A8 File Offset: 0x000124A8
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x000142B8 File Offset: 0x000124B8
		protected virtual void Dispose(bool manual)
		{
			if (!this.Disposed)
			{
				if (manual && this.Native != null)
				{
					this.Native.Close();
					this.Native.Dispose();
				}
				this.Disposed = true;
			}
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x000142EC File Offset: 0x000124EC
		~WinInputBase()
		{
			this.Dispose(false);
		}

		// Token: 0x040000BA RID: 186
		private readonly WindowProcedure WndProc;

		// Token: 0x040000BB RID: 187
		private readonly Thread InputThread;

		// Token: 0x040000BC RID: 188
		private readonly AutoResetEvent InputReady = new AutoResetEvent(false);

		// Token: 0x040000BD RID: 189
		private IntPtr OldWndProc;

		// Token: 0x040000BE RID: 190
		private INativeWindow native;

		// Token: 0x040000BF RID: 191
		private static readonly IntPtr Unhandled = new IntPtr(-1);

		// Token: 0x040000C0 RID: 192
		protected bool Disposed;
	}
}
