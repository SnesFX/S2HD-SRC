using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using OpenTK.Graphics;
using OpenTK.Platform.Dummy;
using OpenTK.Platform.MacOS;
using OpenTK.Platform.SDL2;
using OpenTK.Platform.Windows;
using OpenTK.Platform.X11;

namespace OpenTK.Platform
{
	// Token: 0x02000064 RID: 100
	public static class Utilities
	{
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x00017C50 File Offset: 0x00015E50
		// (set) Token: 0x060006CD RID: 1741 RVA: 0x00017C58 File Offset: 0x00015E58
		internal static bool ThrowOnX11Error
		{
			get
			{
				return Utilities.throw_on_error;
			}
			set
			{
				if (value && !Utilities.throw_on_error)
				{
					Type.GetType("System.Windows.Forms.XplatUIX11, System.Windows.Forms").GetField("ErrorExceptions", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, true);
					Utilities.throw_on_error = true;
					return;
				}
				if (!value && Utilities.throw_on_error)
				{
					Type.GetType("System.Windows.Forms.XplatUIX11, System.Windows.Forms").GetField("ErrorExceptions", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, false);
					Utilities.throw_on_error = false;
				}
			}
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00017CCC File Offset: 0x00015ECC
		internal static void LoadExtensions(Type type)
		{
			int num = 0;
			Type nestedType = type.GetNestedType("Delegates", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (nestedType == null)
			{
				throw new InvalidOperationException("The specified type does not have any loadable extensions.");
			}
			FieldInfo[] fields = nestedType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (fields == null)
			{
				throw new InvalidOperationException("The specified type does not have any loadable extensions.");
			}
			MethodInfo method = type.GetMethod("LoadDelegate", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (method == null)
			{
				throw new InvalidOperationException(type.ToString() + " does not contain a static LoadDelegate method.");
			}
			Utilities.LoadDelegateFunction loadDelegateFunction = (Utilities.LoadDelegateFunction)Delegate.CreateDelegate(typeof(Utilities.LoadDelegateFunction), method);
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Reset();
			stopwatch.Start();
			foreach (FieldInfo fieldInfo in fields)
			{
				Delegate @delegate = loadDelegateFunction(fieldInfo.Name, fieldInfo.FieldType);
				if (@delegate != null)
				{
					num++;
				}
				fieldInfo.SetValue(null, @delegate);
			}
			FieldInfo field = type.GetField("rebuildExtensionList", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				field.SetValue(null, true);
			}
			stopwatch.Stop();
			stopwatch.Reset();
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00017DD8 File Offset: 0x00015FD8
		internal static bool TryLoadExtension(Type type, string extension)
		{
			Type nestedType = type.GetNestedType("Delegates", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (nestedType == null)
			{
				return false;
			}
			Utilities.LoadDelegateFunction loadDelegateFunction = (Utilities.LoadDelegateFunction)Delegate.CreateDelegate(typeof(Utilities.LoadDelegateFunction), type.GetMethod("LoadDelegate", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
			if (loadDelegateFunction == null)
			{
				return false;
			}
			FieldInfo field = nestedType.GetField(extension, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				return false;
			}
			Delegate @delegate = field.GetValue(null) as Delegate;
			Delegate delegate2 = loadDelegateFunction(field.Name, field.FieldType);
			if (((@delegate != null) ? @delegate.Target : null) != ((delegate2 != null) ? delegate2.Target : null))
			{
				field.SetValue(null, delegate2);
				FieldInfo field2 = type.GetField("rebuildExtensionList", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (field2 != null)
				{
					field2.SetValue(null, true);
				}
			}
			return delegate2 != null;
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00017EA0 File Offset: 0x000160A0
		internal static GraphicsContext.GetAddressDelegate CreateGetAddress()
		{
			GraphicsContext.GetAddressDelegate result;
			if (Configuration.RunningOnWindows)
			{
				result = new GraphicsContext.GetAddressDelegate(Wgl.GetProcAddress);
			}
			else if (Configuration.RunningOnX11)
			{
				result = new GraphicsContext.GetAddressDelegate(Glx.GetProcAddress);
			}
			else
			{
				if (!Configuration.RunningOnMacOS)
				{
					throw new PlatformNotSupportedException();
				}
				result = new GraphicsContext.GetAddressDelegate(NS.GetAddress);
			}
			return result;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x00017EF8 File Offset: 0x000160F8
		[Obsolete("Call new OpenTK.Graphics.GraphicsContext() directly, instead.")]
		public static IGraphicsContext CreateGraphicsContext(GraphicsMode mode, IWindowInfo window, int major, int minor, GraphicsContextFlags flags)
		{
			GraphicsContext graphicsContext = new GraphicsContext(mode, window, major, minor, flags);
			graphicsContext.MakeCurrent(window);
			((IGraphicsContextInternal)graphicsContext).LoadAll();
			return graphicsContext;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00017F20 File Offset: 0x00016120
		public static IWindowInfo CreateX11WindowInfo(IntPtr display, int screen, IntPtr windowHandle, IntPtr rootWindow, IntPtr visualInfo)
		{
			X11WindowInfo x11WindowInfo = new X11WindowInfo();
			x11WindowInfo.Display = display;
			x11WindowInfo.Screen = screen;
			x11WindowInfo.Handle = windowHandle;
			x11WindowInfo.RootWindow = rootWindow;
			if (visualInfo != IntPtr.Zero)
			{
				x11WindowInfo.VisualInfo = (XVisualInfo)Marshal.PtrToStructure(visualInfo, typeof(XVisualInfo));
			}
			return x11WindowInfo;
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00017F7C File Offset: 0x0001617C
		public static IWindowInfo CreateWindowsWindowInfo(IntPtr windowHandle)
		{
			return new WinWindowInfo(windowHandle, null);
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00017F88 File Offset: 0x00016188
		public static IWindowInfo CreateMacOSCarbonWindowInfo(IntPtr windowHandle, bool ownHandle, bool isControl)
		{
			return Utilities.CreateMacOSCarbonWindowInfo(windowHandle, ownHandle, isControl, null, null);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00017F94 File Offset: 0x00016194
		public static IWindowInfo CreateMacOSCarbonWindowInfo(IntPtr windowHandle, bool ownHandle, bool isControl, GetInt xOffset, GetInt yOffset)
		{
			return new CarbonWindowInfo(windowHandle, false, isControl, xOffset, yOffset);
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00017FA4 File Offset: 0x000161A4
		public static IWindowInfo CreateMacOSWindowInfo(IntPtr windowHandle)
		{
			return new CocoaWindowInfo(windowHandle);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00017FAC File Offset: 0x000161AC
		public static IWindowInfo CreateMacOSWindowInfo(IntPtr windowHandle, IntPtr viewHandle)
		{
			return new CocoaWindowInfo(windowHandle, viewHandle);
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00017FB8 File Offset: 0x000161B8
		public static IWindowInfo CreateDummyWindowInfo()
		{
			return new DummyWindowInfo();
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00017FC0 File Offset: 0x000161C0
		public static IWindowInfo CreateSdl2WindowInfo(IntPtr windowHandle)
		{
			return new Sdl2WindowInfo(windowHandle, null);
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00017FCC File Offset: 0x000161CC
		internal static bool RelaxGraphicsMode(ref GraphicsMode mode)
		{
			ColorFormat colorFormat = mode.ColorFormat;
			int depth = mode.Depth;
			int stencil = mode.Stencil;
			int samples = mode.Samples;
			ColorFormat accumulatorFormat = mode.AccumulatorFormat;
			int buffers = mode.Buffers;
			bool stereo = mode.Stereo;
			bool result = Utilities.RelaxGraphicsMode(ref colorFormat, ref depth, ref stencil, ref samples, ref accumulatorFormat, ref buffers, ref stereo);
			mode = new GraphicsMode(colorFormat, depth, stencil, samples, accumulatorFormat, buffers, stereo);
			return result;
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0001803C File Offset: 0x0001623C
		internal static bool RelaxGraphicsMode(ref ColorFormat color, ref int depth, ref int stencil, ref int samples, ref ColorFormat accum, ref int buffers, ref bool stereo)
		{
			if (accum != 0)
			{
				accum = 0;
				return true;
			}
			if (buffers > 2)
			{
				buffers = 2;
				return true;
			}
			if (samples > 0)
			{
				samples = Math.Max(samples - 1, 0);
				return true;
			}
			if (stereo)
			{
				stereo = false;
				return true;
			}
			if (stencil != 0)
			{
				stencil = 0;
				return true;
			}
			if (depth != 0)
			{
				depth = 0;
				return true;
			}
			if (color != 24)
			{
				color = 24;
				return true;
			}
			if (buffers != 0)
			{
				buffers = 0;
				return true;
			}
			return false;
		}

		// Token: 0x040001C9 RID: 457
		private static bool throw_on_error;

		// Token: 0x02000065 RID: 101
		// (Invoke) Token: 0x060006DD RID: 1757
		private delegate Delegate LoadDelegateFunction(string name, Type signature);
	}
}
