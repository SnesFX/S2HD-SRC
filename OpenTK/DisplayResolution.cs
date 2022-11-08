using System;
using System.ComponentModel;
using System.Drawing;

namespace OpenTK
{
	// Token: 0x02000052 RID: 82
	public class DisplayResolution
	{
		// Token: 0x06000601 RID: 1537 RVA: 0x00016344 File Offset: 0x00014544
		internal DisplayResolution()
		{
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0001634C File Offset: 0x0001454C
		internal DisplayResolution(int x, int y, int width, int height, int bitsPerPixel, float refreshRate)
		{
			if (width <= 0)
			{
				throw new ArgumentOutOfRangeException("width", "Must be greater than zero.");
			}
			if (height <= 0)
			{
				throw new ArgumentOutOfRangeException("height", "Must be greater than zero.");
			}
			if (bitsPerPixel <= 0)
			{
				throw new ArgumentOutOfRangeException("bitsPerPixel", "Must be greater than zero.");
			}
			if (refreshRate < 0f)
			{
				throw new ArgumentOutOfRangeException("refreshRate", "Must be greater than, or equal to zero.");
			}
			this.bounds = new Rectangle(x, y, width, height);
			this.bits_per_pixel = bitsPerPixel;
			this.refresh_rate = refreshRate;
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000603 RID: 1539 RVA: 0x000163D8 File Offset: 0x000145D8
		[Obsolete("This property will return invalid results if a monitor changes resolution. Use DisplayDevice.Bounds instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Rectangle Bounds
		{
			get
			{
				return this.bounds;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x000163E0 File Offset: 0x000145E0
		// (set) Token: 0x06000605 RID: 1541 RVA: 0x000163F0 File Offset: 0x000145F0
		public int Width
		{
			get
			{
				return this.bounds.Width;
			}
			internal set
			{
				this.bounds.Width = value;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x00016400 File Offset: 0x00014600
		// (set) Token: 0x06000607 RID: 1543 RVA: 0x00016410 File Offset: 0x00014610
		public int Height
		{
			get
			{
				return this.bounds.Height;
			}
			internal set
			{
				this.bounds.Height = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x00016420 File Offset: 0x00014620
		// (set) Token: 0x06000609 RID: 1545 RVA: 0x00016428 File Offset: 0x00014628
		public int BitsPerPixel
		{
			get
			{
				return this.bits_per_pixel;
			}
			internal set
			{
				this.bits_per_pixel = value;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x00016434 File Offset: 0x00014634
		// (set) Token: 0x0600060B RID: 1547 RVA: 0x0001643C File Offset: 0x0001463C
		public float RefreshRate
		{
			get
			{
				return this.refresh_rate;
			}
			internal set
			{
				this.refresh_rate = value;
			}
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00016448 File Offset: 0x00014648
		public override string ToString()
		{
			return string.Format("{0}x{1}@{2}Hz", this.Bounds, this.bits_per_pixel, this.refresh_rate);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00016478 File Offset: 0x00014678
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (base.GetType() == obj.GetType())
			{
				DisplayResolution displayResolution = (DisplayResolution)obj;
				return this.Width == displayResolution.Width && this.Height == displayResolution.Height && this.BitsPerPixel == displayResolution.BitsPerPixel && this.RefreshRate == displayResolution.RefreshRate;
			}
			return false;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x000164DC File Offset: 0x000146DC
		public override int GetHashCode()
		{
			return this.Bounds.GetHashCode() ^ this.bits_per_pixel ^ this.refresh_rate.GetHashCode();
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00016510 File Offset: 0x00014710
		public static bool operator ==(DisplayResolution left, DisplayResolution right)
		{
			return (left == null && right == null) || ((left != null || right == null) && (left == null || right != null) && left.Equals(right));
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00016530 File Offset: 0x00014730
		public static bool operator !=(DisplayResolution left, DisplayResolution right)
		{
			return !(left == right);
		}

		// Token: 0x04000188 RID: 392
		private Rectangle bounds;

		// Token: 0x04000189 RID: 393
		private int bits_per_pixel;

		// Token: 0x0400018A RID: 394
		private float refresh_rate;
	}
}
