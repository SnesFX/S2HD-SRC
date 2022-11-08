using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Platform;

namespace OpenTK
{
	// Token: 0x02000002 RID: 2
	public class DisplayDevice
	{
		// Token: 0x06000002 RID: 2 RVA: 0x0000206C File Offset: 0x0000026C
		internal DisplayDevice()
		{
			this.available_resolutions_readonly = this.available_resolutions.AsReadOnly();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000209C File Offset: 0x0000029C
		internal DisplayDevice(DisplayResolution currentResolution, bool primary, IEnumerable<DisplayResolution> availableResolutions, Rectangle bounds, object id) : this()
		{
			this.current_resolution = currentResolution;
			this.IsPrimary = primary;
			this.available_resolutions.AddRange(availableResolutions);
			this.bounds = ((bounds == Rectangle.Empty) ? currentResolution.Bounds : bounds);
			this.Id = id;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020F0 File Offset: 0x000002F0
		// (set) Token: 0x06000005 RID: 5 RVA: 0x000020F8 File Offset: 0x000002F8
		public Rectangle Bounds
		{
			get
			{
				return this.bounds;
			}
			internal set
			{
				this.bounds = value;
				this.current_resolution.Height = this.bounds.Height;
				this.current_resolution.Width = this.bounds.Width;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002130 File Offset: 0x00000330
		public int Width
		{
			get
			{
				return this.current_resolution.Width;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002140 File Offset: 0x00000340
		public int Height
		{
			get
			{
				return this.current_resolution.Height;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002150 File Offset: 0x00000350
		// (set) Token: 0x06000009 RID: 9 RVA: 0x00002160 File Offset: 0x00000360
		public int BitsPerPixel
		{
			get
			{
				return this.current_resolution.BitsPerPixel;
			}
			internal set
			{
				this.current_resolution.BitsPerPixel = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002170 File Offset: 0x00000370
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002180 File Offset: 0x00000380
		public float RefreshRate
		{
			get
			{
				return this.current_resolution.RefreshRate;
			}
			internal set
			{
				this.current_resolution.RefreshRate = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002190 File Offset: 0x00000390
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002198 File Offset: 0x00000398
		public bool IsPrimary
		{
			get
			{
				return this.primary;
			}
			internal set
			{
				if (value && DisplayDevice.primary_display != null && DisplayDevice.primary_display != this)
				{
					DisplayDevice.primary_display.IsPrimary = false;
				}
				lock (DisplayDevice.display_lock)
				{
					this.primary = value;
					if (value)
					{
						DisplayDevice.primary_display = this;
					}
				}
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021F8 File Offset: 0x000003F8
		public DisplayResolution SelectResolution(int width, int height, int bitsPerPixel, float refreshRate)
		{
			DisplayResolution displayResolution = this.FindResolution(width, height, bitsPerPixel, refreshRate);
			if (displayResolution == null)
			{
				displayResolution = this.FindResolution(width, height, bitsPerPixel, 0f);
			}
			if (displayResolution == null)
			{
				displayResolution = this.FindResolution(width, height, 0, 0f);
			}
			if (displayResolution == null)
			{
				return this.current_resolution;
			}
			return displayResolution;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002254 File Offset: 0x00000454
		// (set) Token: 0x06000010 RID: 16 RVA: 0x0000225C File Offset: 0x0000045C
		public IList<DisplayResolution> AvailableResolutions
		{
			get
			{
				return this.available_resolutions_readonly;
			}
			internal set
			{
				this.available_resolutions = (List<DisplayResolution>)value;
				this.available_resolutions_readonly = this.available_resolutions.AsReadOnly();
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000227C File Offset: 0x0000047C
		public void ChangeResolution(DisplayResolution resolution)
		{
			if (resolution == null)
			{
				this.RestoreResolution();
			}
			if (resolution == this.current_resolution)
			{
				return;
			}
			if (DisplayDevice.implementation.TryChangeResolution(this, resolution))
			{
				if (this.original_resolution == null)
				{
					this.original_resolution = this.current_resolution;
				}
				this.current_resolution = resolution;
				return;
			}
			throw new GraphicsModeException(string.Format("Device {0}: Failed to change resolution to {1}.", this, resolution));
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022E8 File Offset: 0x000004E8
		public void ChangeResolution(int width, int height, int bitsPerPixel, float refreshRate)
		{
			this.ChangeResolution(this.SelectResolution(width, height, bitsPerPixel, refreshRate));
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022FC File Offset: 0x000004FC
		public void RestoreResolution()
		{
			if (!(this.original_resolution != null))
			{
				return;
			}
			if (DisplayDevice.implementation.TryRestoreResolution(this))
			{
				this.current_resolution = this.original_resolution;
				this.original_resolution = null;
				return;
			}
			throw new GraphicsModeException(string.Format("Device {0}: Failed to restore resolution.", this));
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000014 RID: 20 RVA: 0x0000234C File Offset: 0x0000054C
		[Obsolete("Use GetDisplay(DisplayIndex) instead.")]
		public static IList<DisplayDevice> AvailableDisplays
		{
			get
			{
				List<DisplayDevice> list = new List<DisplayDevice>();
				for (int i = 0; i < 6; i++)
				{
					DisplayDevice display = DisplayDevice.GetDisplay((DisplayIndex)i);
					if (display != null)
					{
						list.Add(display);
					}
				}
				return list.AsReadOnly();
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002384 File Offset: 0x00000584
		public static DisplayDevice Default
		{
			get
			{
				return DisplayDevice.implementation.GetDisplay(DisplayIndex.Primary);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002394 File Offset: 0x00000594
		public static DisplayDevice GetDisplay(DisplayIndex index)
		{
			return DisplayDevice.implementation.GetDisplay(index);
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000023A4 File Offset: 0x000005A4
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000023AC File Offset: 0x000005AC
		internal DisplayResolution OriginalResolution
		{
			get
			{
				return this.original_resolution;
			}
			set
			{
				this.original_resolution = value;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000023B8 File Offset: 0x000005B8
		internal static DisplayDevice FromPoint(int x, int y)
		{
			for (DisplayIndex displayIndex = DisplayIndex.First; displayIndex < DisplayIndex.Sixth; displayIndex++)
			{
				DisplayDevice display = DisplayDevice.GetDisplay(displayIndex);
				if (display != null && display.Bounds.Contains(x, y))
				{
					return display;
				}
			}
			return null;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000023F0 File Offset: 0x000005F0
		private DisplayResolution FindResolution(int width, int height, int bitsPerPixel, float refreshRate)
		{
			return this.available_resolutions.Find((DisplayResolution test) => ((width > 0 && width == test.Width) || width == 0) && ((height > 0 && height == test.Height) || height == 0) && ((bitsPerPixel > 0 && bitsPerPixel == test.BitsPerPixel) || bitsPerPixel == 0) && ((refreshRate > 0f && (double)Math.Abs(refreshRate - test.RefreshRate) < 1.0) || refreshRate == 0f));
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002438 File Offset: 0x00000638
		public override string ToString()
		{
			return string.Format("{0}: {1} ({2} modes available)", this.IsPrimary ? "Primary" : "Secondary", this.Bounds.ToString(), this.available_resolutions.Count);
		}

		// Token: 0x04000001 RID: 1
		private bool primary;

		// Token: 0x04000002 RID: 2
		private Rectangle bounds;

		// Token: 0x04000003 RID: 3
		private DisplayResolution current_resolution = new DisplayResolution();

		// Token: 0x04000004 RID: 4
		private DisplayResolution original_resolution;

		// Token: 0x04000005 RID: 5
		private List<DisplayResolution> available_resolutions = new List<DisplayResolution>();

		// Token: 0x04000006 RID: 6
		private IList<DisplayResolution> available_resolutions_readonly;

		// Token: 0x04000007 RID: 7
		internal object Id;

		// Token: 0x04000008 RID: 8
		private static readonly object display_lock = new object();

		// Token: 0x04000009 RID: 9
		private static DisplayDevice primary_display;

		// Token: 0x0400000A RID: 10
		private static IDisplayDeviceDriver implementation = Factory.Default.CreateDisplayDeviceDriver();
	}
}
