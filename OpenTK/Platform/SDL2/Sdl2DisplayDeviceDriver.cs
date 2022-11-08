using System;
using System.Collections.Generic;
using System.Drawing;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A0 RID: 1440
	internal class Sdl2DisplayDeviceDriver : DisplayDeviceBase
	{
		// Token: 0x060045FA RID: 17914 RVA: 0x000C0B54 File Offset: 0x000BED54
		public Sdl2DisplayDeviceDriver()
		{
			int numVideoDisplays = SDL.GetNumVideoDisplays();
			for (int i = 0; i < numVideoDisplays; i++)
			{
				Rect rect;
				SDL.GetDisplayBounds(i, out rect);
				DisplayMode displayMode;
				SDL.GetCurrentDisplayMode(i, out displayMode);
				List<DisplayResolution> list = new List<DisplayResolution>();
				int numDisplayModes = SDL.GetNumDisplayModes(i);
				for (int j = 0; j < numDisplayModes; j++)
				{
					DisplayMode displayMode2;
					SDL.GetDisplayMode(i, j, out displayMode2);
					list.Add(new DisplayResolution(rect.X, rect.Y, displayMode2.Width, displayMode2.Height, this.TranslateFormat(displayMode2.Format), (float)displayMode2.RefreshRate));
				}
				DisplayResolution currentResolution = new DisplayResolution(rect.X, rect.Y, displayMode.Width, displayMode.Height, this.TranslateFormat(displayMode.Format), (float)displayMode.RefreshRate);
				DisplayDevice displayDevice = new DisplayDevice(currentResolution, i == 0, list, this.TranslateBounds(rect), i);
				this.AvailableDevices.Add(displayDevice);
				if (i == 0)
				{
					this.Primary = displayDevice;
				}
			}
		}

		// Token: 0x060045FB RID: 17915 RVA: 0x000C0C68 File Offset: 0x000BEE68
		private int TranslateFormat(uint format)
		{
			int result;
			uint num;
			uint num2;
			uint num3;
			uint num4;
			SDL.PixelFormatEnumToMasks(format, out result, out num, out num2, out num3, out num4);
			return result;
		}

		// Token: 0x060045FC RID: 17916 RVA: 0x000C0C88 File Offset: 0x000BEE88
		private Rectangle TranslateBounds(Rect rect)
		{
			return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		}

		// Token: 0x060045FD RID: 17917 RVA: 0x000C0CAC File Offset: 0x000BEEAC
		public override bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution)
		{
			Sdl2Factory.UseFullscreenDesktop = false;
			return true;
		}

		// Token: 0x060045FE RID: 17918 RVA: 0x000C0CB8 File Offset: 0x000BEEB8
		public override bool TryRestoreResolution(DisplayDevice device)
		{
			Sdl2Factory.UseFullscreenDesktop = true;
			return true;
		}
	}
}
