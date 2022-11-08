using System;
using System.Collections.Generic;
using OpenTK.Graphics;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000E9 RID: 233
	internal class WinGraphicsMode : IGraphicsMode
	{
		// Token: 0x06000984 RID: 2436 RVA: 0x0001FD98 File Offset: 0x0001DF98
		public WinGraphicsMode(IntPtr device)
		{
			if (device == IntPtr.Zero)
			{
				throw new ArgumentException();
			}
			this.Device = device;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0001FDC8 File Offset: 0x0001DFC8
		public GraphicsMode SelectGraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)
		{
			GraphicsMode graphicsMode = new GraphicsMode(color, depth, stencil, samples, accum, buffers, stereo);
			GraphicsMode graphicsMode2 = this.ChoosePixelFormatARB(this.Device, graphicsMode);
			graphicsMode2 = (graphicsMode2 ?? this.ChoosePixelFormatPFD(this.Device, graphicsMode, WinGraphicsMode.AccelerationType.ICD));
			graphicsMode2 = (graphicsMode2 ?? this.ChoosePixelFormatPFD(this.Device, graphicsMode, WinGraphicsMode.AccelerationType.MCD));
			graphicsMode2 = (graphicsMode2 ?? this.ChoosePixelFormatPFD(this.Device, graphicsMode, WinGraphicsMode.AccelerationType.None));
			if (graphicsMode2 == null)
			{
				throw new GraphicsModeException("The requested GraphicsMode is not supported");
			}
			return graphicsMode2;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0001FE40 File Offset: 0x0001E040
		private GraphicsMode ChoosePixelFormatARB(IntPtr device, GraphicsMode desired_mode)
		{
			GraphicsMode result = null;
			GraphicsMode graphicsMode = new GraphicsMode(desired_mode);
			if (Wgl.SupportsExtension("WGL_ARB_pixel_format") && Wgl.SupportsFunction("wglChoosePixelFormatARB"))
			{
				int[] array = new int[1];
				List<int> list = new List<int>();
				bool flag;
				do
				{
					list.Clear();
					list.Add(8195);
					list.Add(8231);
					list.Add(8193);
					list.Add(1);
					if (graphicsMode.ColorFormat.Red > 0)
					{
						list.Add(8213);
						list.Add(graphicsMode.ColorFormat.Red);
					}
					if (graphicsMode.ColorFormat.Green > 0)
					{
						list.Add(8215);
						list.Add(graphicsMode.ColorFormat.Green);
					}
					if (graphicsMode.ColorFormat.Blue > 0)
					{
						list.Add(8217);
						list.Add(graphicsMode.ColorFormat.Blue);
					}
					if (graphicsMode.ColorFormat.Alpha > 0)
					{
						list.Add(8219);
						list.Add(graphicsMode.ColorFormat.Alpha);
					}
					if (graphicsMode.Depth > 0)
					{
						list.Add(8226);
						list.Add(graphicsMode.Depth);
					}
					if (graphicsMode.Stencil > 0)
					{
						list.Add(8227);
						list.Add(graphicsMode.Stencil);
					}
					if (graphicsMode.AccumulatorFormat.Red > 0)
					{
						list.Add(8222);
						list.Add(graphicsMode.AccumulatorFormat.Red);
					}
					if (graphicsMode.AccumulatorFormat.Green > 0)
					{
						list.Add(8223);
						list.Add(graphicsMode.AccumulatorFormat.Green);
					}
					if (graphicsMode.AccumulatorFormat.Blue > 0)
					{
						list.Add(8224);
						list.Add(graphicsMode.AccumulatorFormat.Blue);
					}
					if (graphicsMode.AccumulatorFormat.Alpha > 0)
					{
						list.Add(8225);
						list.Add(graphicsMode.AccumulatorFormat.Alpha);
					}
					if (graphicsMode.Samples > 0 && Wgl.SupportsExtension("WGL_ARB_multisample"))
					{
						list.Add(8257);
						list.Add(1);
						list.Add(8258);
						list.Add(graphicsMode.Samples);
					}
					if (graphicsMode.Buffers > 0)
					{
						list.Add(8209);
						list.Add((graphicsMode.Buffers > 1) ? 1 : 0);
					}
					if (graphicsMode.Stereo)
					{
						list.Add(8210);
						list.Add(1);
					}
					list.Add(0);
					list.Add(0);
					int num;
					if (Wgl.Arb.ChoosePixelFormat(device, list.ToArray(), null, array.Length, array, out num) && num > 0)
					{
						result = this.DescribePixelFormatARB(device, array[0]);
						flag = false;
					}
					else
					{
						flag = Utilities.RelaxGraphicsMode(ref graphicsMode);
					}
				}
				while (flag);
			}
			return result;
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00020170 File Offset: 0x0001E370
		private static bool Compare(int got, int requested, ref int distance)
		{
			bool result = true;
			if (got == 0 && requested != 0)
			{
				result = false;
			}
			else if (got >= requested)
			{
				distance += got - requested;
			}
			else
			{
				distance += 8 * Math.Abs(got - requested);
			}
			return result;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x000201A8 File Offset: 0x0001E3A8
		private static WinGraphicsMode.AccelerationType GetAccelerationType(ref PixelFormatDescriptor pfd)
		{
			WinGraphicsMode.AccelerationType result = WinGraphicsMode.AccelerationType.ICD;
			if ((pfd.Flags & PixelFormatDescriptorFlags.GENERIC_FORMAT) != (PixelFormatDescriptorFlags)0)
			{
				if ((pfd.Flags & PixelFormatDescriptorFlags.GENERIC_ACCELERATED) != (PixelFormatDescriptorFlags)0)
				{
					result = WinGraphicsMode.AccelerationType.MCD;
				}
				else
				{
					result = WinGraphicsMode.AccelerationType.None;
				}
			}
			return result;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x000201D8 File Offset: 0x0001E3D8
		private GraphicsMode ChoosePixelFormatPFD(IntPtr device, GraphicsMode mode, WinGraphicsMode.AccelerationType requested_acceleration_type)
		{
			PixelFormatDescriptor pixelFormatDescriptor = default(PixelFormatDescriptor);
			PixelFormatDescriptorFlags pixelFormatDescriptorFlags = (PixelFormatDescriptorFlags)0;
			pixelFormatDescriptorFlags |= PixelFormatDescriptorFlags.DRAW_TO_WINDOW;
			pixelFormatDescriptorFlags |= PixelFormatDescriptorFlags.SUPPORT_OPENGL;
			if (mode.Stereo)
			{
				pixelFormatDescriptorFlags |= PixelFormatDescriptorFlags.STEREO;
			}
			if (Environment.OSVersion.Version.Major >= 6 && requested_acceleration_type != WinGraphicsMode.AccelerationType.None)
			{
				pixelFormatDescriptorFlags |= PixelFormatDescriptorFlags.SUPPORT_COMPOSITION;
			}
			int num = Functions.DescribePixelFormat(device, 1, (int)API.PixelFormatDescriptorSize, ref pixelFormatDescriptor);
			int pixelformat = 0;
			int num2 = int.MaxValue;
			for (int i = 1; i <= num; i++)
			{
				int num3 = 0;
				bool flag = Functions.DescribePixelFormat(device, i, (int)API.PixelFormatDescriptorSize, ref pixelFormatDescriptor) != 0;
				flag &= (WinGraphicsMode.GetAccelerationType(ref pixelFormatDescriptor) == requested_acceleration_type);
				flag &= ((pixelFormatDescriptor.Flags & pixelFormatDescriptorFlags) == pixelFormatDescriptorFlags);
				flag &= (pixelFormatDescriptor.PixelType == PixelType.RGBA);
				if ((pixelFormatDescriptor.Flags & PixelFormatDescriptorFlags.DOUBLEBUFFER) == (PixelFormatDescriptorFlags)0 && mode.Buffers > 1)
				{
					num3 += 1000;
				}
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.ColorBits, mode.ColorFormat.BitsPerPixel, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.RedBits, mode.ColorFormat.Red, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.GreenBits, mode.ColorFormat.Green, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.BlueBits, mode.ColorFormat.Blue, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.AlphaBits, mode.ColorFormat.Alpha, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.AccumBits, mode.AccumulatorFormat.BitsPerPixel, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.AccumRedBits, mode.AccumulatorFormat.Red, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.AccumGreenBits, mode.AccumulatorFormat.Green, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.AccumBlueBits, mode.AccumulatorFormat.Blue, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.AccumAlphaBits, mode.AccumulatorFormat.Alpha, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.DepthBits, mode.Depth, ref num3);
				flag &= WinGraphicsMode.Compare((int)pixelFormatDescriptor.StencilBits, mode.Stencil, ref num3);
				if (flag && num3 < num2)
				{
					pixelformat = i;
					num2 = num3;
				}
			}
			return WinGraphicsMode.DescribePixelFormatPFD(device, ref pixelFormatDescriptor, pixelformat);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00020458 File Offset: 0x0001E658
		private static GraphicsMode DescribePixelFormatPFD(IntPtr device, ref PixelFormatDescriptor pfd, int pixelformat)
		{
			GraphicsMode result = null;
			if (Functions.DescribePixelFormat(device, pixelformat, (int)pfd.Size, ref pfd) > 0)
			{
				result = new GraphicsMode(new IntPtr?(new IntPtr(pixelformat)), new ColorFormat((int)pfd.RedBits, (int)pfd.GreenBits, (int)pfd.BlueBits, (int)pfd.AlphaBits), (int)pfd.DepthBits, (int)pfd.StencilBits, 0, new ColorFormat((int)pfd.AccumRedBits, (int)pfd.AccumGreenBits, (int)pfd.AccumBlueBits, (int)pfd.AccumAlphaBits), ((pfd.Flags & PixelFormatDescriptorFlags.DOUBLEBUFFER) != (PixelFormatDescriptorFlags)0) ? 2 : 1, (pfd.Flags & PixelFormatDescriptorFlags.STEREO) != (PixelFormatDescriptorFlags)0);
			}
			return result;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x000204F0 File Offset: 0x0001E6F0
		private GraphicsMode DescribePixelFormatARB(IntPtr device, int pixelformat)
		{
			GraphicsMode result = null;
			if (Wgl.SupportsFunction("wglGetPixelFormatAttribivARB"))
			{
				int[] array = new int[]
				{
					8195,
					8213,
					8215,
					8217,
					8219,
					8212,
					8226,
					8227,
					8257,
					8258,
					8222,
					8223,
					8224,
					8225,
					8221,
					8209,
					8210,
					0
				};
				int[] array2 = new int[array.Length];
				Wgl.Arb.GetPixelFormatAttrib(device, pixelformat, 0, array.Length - 1, array, array2);
				WGL_ARB_pixel_format wgl_ARB_pixel_format = (WGL_ARB_pixel_format)array2[0];
				if (wgl_ARB_pixel_format == WGL_ARB_pixel_format.FullAccelerationArb)
				{
					result = new GraphicsMode(new IntPtr?(new IntPtr(pixelformat)), new ColorFormat(array2[1], array2[2], array2[3], array2[4]), array2[6], array2[7], (array2[8] != 0) ? array2[9] : 0, new ColorFormat(array2[10], array2[11], array2[12], array2[13]), (array2[15] == 1) ? 2 : 1, array2[16] == 1);
				}
			}
			return result;
		}

		// Token: 0x040007A4 RID: 1956
		private static readonly object SyncRoot = new object();

		// Token: 0x040007A5 RID: 1957
		private readonly IntPtr Device;

		// Token: 0x040007A6 RID: 1958
		private readonly List<GraphicsMode> modes = new List<GraphicsMode>();

		// Token: 0x020000EA RID: 234
		private enum AccelerationType
		{
			// Token: 0x040007A8 RID: 1960
			None,
			// Token: 0x040007A9 RID: 1961
			MCD,
			// Token: 0x040007AA RID: 1962
			ICD
		}
	}
}
