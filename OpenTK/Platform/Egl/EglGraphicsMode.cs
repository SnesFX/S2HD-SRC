using System;
using OpenTK.Graphics;

namespace OpenTK.Platform.Egl
{
	// Token: 0x02000070 RID: 112
	internal class EglGraphicsMode
	{
		// Token: 0x06000734 RID: 1844 RVA: 0x00018708 File Offset: 0x00016908
		public GraphicsMode SelectGraphicsMode(EglWindowInfo window, GraphicsMode mode, RenderableFlags flags)
		{
			return this.SelectGraphicsMode(window, mode.ColorFormat, mode.Depth, mode.Stencil, mode.Samples, mode.AccumulatorFormat, mode.Buffers, mode.Stereo, flags);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00018748 File Offset: 0x00016948
		public GraphicsMode SelectGraphicsMode(EglWindowInfo window, ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo, RenderableFlags renderable_flags)
		{
			IntPtr[] array = new IntPtr[1];
			int[] array2 = new int[]
			{
				12339,
				4,
				12352,
				0,
				12324,
				0,
				12323,
				0,
				12322,
				0,
				12321,
				0,
				12325,
				0,
				12326,
				0,
				12338,
				0,
				12337,
				0,
				12344
			};
			array2[3] = (int)renderable_flags;
			array2[5] = color.Red;
			array2[7] = color.Green;
			array2[9] = color.Blue;
			array2[11] = color.Alpha;
			array2[13] = ((depth > 0) ? depth : 0);
			array2[15] = ((stencil > 0) ? stencil : 0);
			array2[17] = ((samples > 0) ? 1 : 0);
			array2[19] = ((samples > 0) ? samples : 0);
			int[] attrib_list = array2;
			IntPtr display = window.Display;
			int num;
			if (!Egl.ChooseConfig(display, attrib_list, array, array.Length, out num) || num == 0)
			{
				throw new GraphicsModeException(string.Format("Failed to retrieve GraphicsMode, error {0}", Egl.GetError()));
			}
			IntPtr intPtr = array[0];
			int red;
			Egl.GetConfigAttrib(display, intPtr, 12324, out red);
			int green;
			Egl.GetConfigAttrib(display, intPtr, 12323, out green);
			int blue;
			Egl.GetConfigAttrib(display, intPtr, 12322, out blue);
			int alpha;
			Egl.GetConfigAttrib(display, intPtr, 12321, out alpha);
			int depth2;
			Egl.GetConfigAttrib(display, intPtr, 12325, out depth2);
			int stencil2;
			Egl.GetConfigAttrib(display, intPtr, 12326, out stencil2);
			int num2;
			Egl.GetConfigAttrib(display, intPtr, 12337, out num2);
			Egl.GetConfigAttrib(display, intPtr, 12337, out samples);
			return new GraphicsMode(new IntPtr?(intPtr), new ColorFormat(red, green, blue, alpha), depth2, stencil2, (num2 > 0) ? samples : 0, 0, 2, false);
		}
	}
}
