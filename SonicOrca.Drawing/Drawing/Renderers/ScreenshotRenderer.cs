using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000010 RID: 16
	public class ScreenshotRenderer
	{
		// Token: 0x060000C9 RID: 201 RVA: 0x00004DCC File Offset: 0x00002FCC
		public static void GrabScreenshot()
		{
			int width = 1920;
			int height = 1080;
			Bitmap bitmap = new Bitmap(width, height);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			GL.ReadPixels(0, 0, width, height, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, bitmapData.Scan0);
			bitmap.UnlockBits(bitmapData);
			bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
			string filename = string.Concat(new object[]
			{
				"Sonic 2 HD ",
				DateTime.Now.Year,
				"-",
				DateTime.Now.Month,
				"-",
				DateTime.Now.Day,
				" ",
				DateTime.Now.Hour,
				"-",
				DateTime.Now.Minute,
				"-",
				DateTime.Now.Second,
				"-",
				DateTime.Now.Millisecond,
				".png"
			});
			bitmap.Save(filename, ImageFormat.Png);
			bitmap.Dispose();
		}
	}
}
