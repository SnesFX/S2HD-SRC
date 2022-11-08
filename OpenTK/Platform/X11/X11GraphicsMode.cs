using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK.Graphics;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000131 RID: 305
	internal class X11GraphicsMode : IGraphicsMode
	{
		// Token: 0x06000AB2 RID: 2738 RVA: 0x00021804 File Offset: 0x0001FA04
		public GraphicsMode SelectGraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)
		{
			IntPtr intPtr = IntPtr.Zero;
			IntPtr defaultDisplay = API.DefaultDisplay;
			for (;;)
			{
				intPtr = this.SelectVisualUsingFBConfig(color, depth, stencil, samples, accum, buffers, stereo);
				if (intPtr == IntPtr.Zero)
				{
					intPtr = this.SelectVisualUsingChooseVisual(color, depth, stencil, samples, accum, buffers, stereo);
				}
				if (intPtr == IntPtr.Zero && !Utilities.RelaxGraphicsMode(ref color, ref depth, ref stencil, ref samples, ref accum, ref buffers, ref stereo))
				{
					break;
				}
				if (!(intPtr == IntPtr.Zero))
				{
					goto Block_4;
				}
			}
			throw new GraphicsModeException("Requested GraphicsMode not available.");
			Block_4:
			XVisualInfo xvisualInfo = (XVisualInfo)Marshal.PtrToStructure(intPtr, typeof(XVisualInfo));
			int alpha;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.ALPHA_SIZE, out alpha);
			int red;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.RED_SIZE, out red);
			int green;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.GREEN_SIZE, out green);
			int blue;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.BLUE_SIZE, out blue);
			int alpha2;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.ACCUM_ALPHA_SIZE, out alpha2);
			int red2;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.ACCUM_RED_SIZE, out red2);
			int green2;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.ACCUM_GREEN_SIZE, out green2);
			int blue2;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.ACCUM_BLUE_SIZE, out blue2);
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.DEPTH_SIZE, out depth);
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.STENCIL_SIZE, out stencil);
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.SAMPLES, out samples);
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.DOUBLEBUFFER, out buffers);
			buffers++;
			int num;
			Glx.GetConfig(defaultDisplay, ref xvisualInfo, GLXAttribute.STEREO, out num);
			stereo = (num != 0);
			GraphicsMode result = new GraphicsMode(new IntPtr?(xvisualInfo.VisualID), new ColorFormat(red, green, blue, alpha), depth, stencil, samples, new ColorFormat(red2, green2, blue2, alpha2), buffers, stereo);
			using (new XLock(defaultDisplay))
			{
				Functions.XFree(intPtr);
			}
			return result;
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x000219BC File Offset: 0x0001FBBC
		private unsafe IntPtr SelectVisualUsingFBConfig(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)
		{
			List<int> list = new List<int>();
			IntPtr result = IntPtr.Zero;
			if (color.BitsPerPixel > 0)
			{
				if (!color.IsIndexed)
				{
					list.Add(4);
					list.Add(1);
				}
				list.Add(8);
				list.Add(color.Red);
				list.Add(9);
				list.Add(color.Green);
				list.Add(10);
				list.Add(color.Blue);
				list.Add(11);
				list.Add(color.Alpha);
			}
			if (depth > 0)
			{
				list.Add(12);
				list.Add(depth);
			}
			if (buffers > 1)
			{
				list.Add(5);
				list.Add(1);
			}
			if (stencil > 1)
			{
				list.Add(13);
				list.Add(stencil);
			}
			if (accum.BitsPerPixel > 0)
			{
				list.Add(17);
				list.Add(accum.Alpha);
				list.Add(16);
				list.Add(accum.Blue);
				list.Add(15);
				list.Add(accum.Green);
				list.Add(14);
				list.Add(accum.Red);
			}
			if (samples > 0)
			{
				list.Add(100000);
				list.Add(1);
				list.Add(100001);
				list.Add(samples);
			}
			if (stereo)
			{
				list.Add(6);
				list.Add(1);
			}
			list.Add(0);
			IntPtr defaultDisplay = API.DefaultDisplay;
			using (new XLock(defaultDisplay))
			{
				try
				{
					int num = Functions.XDefaultScreen(defaultDisplay);
					Functions.XRootWindow(defaultDisplay, num);
					int num2;
					IntPtr* ptr = Glx.ChooseFBConfig(defaultDisplay, num, list.ToArray(), out num2);
					if (num2 > 0 && ptr != null)
					{
						result = Glx.GetVisualFromFBConfig(defaultDisplay, *ptr);
						Functions.XFree((IntPtr)((void*)ptr));
					}
				}
				catch (EntryPointNotFoundException)
				{
					return IntPtr.Zero;
				}
			}
			return result;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x00021BB4 File Offset: 0x0001FDB4
		private IntPtr SelectVisualUsingChooseVisual(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)
		{
			List<int> list = new List<int>();
			if (color.BitsPerPixel > 0)
			{
				if (!color.IsIndexed)
				{
					list.Add(4);
				}
				list.Add(8);
				list.Add(color.Red);
				list.Add(9);
				list.Add(color.Green);
				list.Add(10);
				list.Add(color.Blue);
				list.Add(11);
				list.Add(color.Alpha);
			}
			if (depth > 0)
			{
				list.Add(12);
				list.Add(depth);
			}
			if (buffers > 1)
			{
				list.Add(5);
			}
			if (stencil > 1)
			{
				list.Add(13);
				list.Add(stencil);
			}
			if (accum.BitsPerPixel > 0)
			{
				list.Add(17);
				list.Add(accum.Alpha);
				list.Add(16);
				list.Add(accum.Blue);
				list.Add(15);
				list.Add(accum.Green);
				list.Add(14);
				list.Add(accum.Red);
			}
			if (samples > 0)
			{
				list.Add(100000);
				list.Add(1);
				list.Add(100001);
				list.Add(samples);
			}
			if (stereo)
			{
				list.Add(6);
			}
			list.Add(0);
			IntPtr defaultDisplay = API.DefaultDisplay;
			IntPtr result;
			using (new XLock(defaultDisplay))
			{
				result = Glx.ChooseVisual(defaultDisplay, Functions.XDefaultScreen(defaultDisplay), list.ToArray());
			}
			return result;
		}
	}
}
