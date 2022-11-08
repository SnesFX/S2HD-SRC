using System;
using System.Runtime.InteropServices;

namespace OpenTK
{
	// Token: 0x02000B09 RID: 2825
	public class WindowIcon
	{
		// Token: 0x0600599E RID: 22942 RVA: 0x000F3758 File Offset: 0x000F1958
		protected internal WindowIcon()
		{
		}

		// Token: 0x0600599F RID: 22943 RVA: 0x000F3760 File Offset: 0x000F1960
		private WindowIcon(int width, int height)
		{
			if (width < 0 || width > 256 || height < 0 || height > 256)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.width = width;
			this.height = height;
		}

		// Token: 0x060059A0 RID: 22944 RVA: 0x000F3794 File Offset: 0x000F1994
		internal WindowIcon(int width, int height, byte[] data) : this(width, height)
		{
			if (data == null)
			{
				throw new ArgumentNullException();
			}
			if (data.Length < this.Width * this.Height * 4)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.data = data;
		}

		// Token: 0x060059A1 RID: 22945 RVA: 0x000F37C8 File Offset: 0x000F19C8
		internal WindowIcon(int width, int height, IntPtr data) : this(width, height)
		{
			if (data == IntPtr.Zero)
			{
				throw new ArgumentNullException();
			}
			this.data = new byte[width * height * 4];
			Marshal.Copy(data, this.data, 0, this.data.Length);
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x060059A2 RID: 22946 RVA: 0x000F3818 File Offset: 0x000F1A18
		internal byte[] Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x060059A3 RID: 22947 RVA: 0x000F3820 File Offset: 0x000F1A20
		internal int Width
		{
			get
			{
				return this.width;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x060059A4 RID: 22948 RVA: 0x000F3828 File Offset: 0x000F1A28
		internal int Height
		{
			get
			{
				return this.height;
			}
		}

		// Token: 0x0400B4DD RID: 46301
		private byte[] data;

		// Token: 0x0400B4DE RID: 46302
		private int width;

		// Token: 0x0400B4DF RID: 46303
		private int height;
	}
}
