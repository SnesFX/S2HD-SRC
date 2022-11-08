using System;
using System.Drawing;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200009F RID: 159
	internal struct Win32Rectangle
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0001AAD4 File Offset: 0x00018CD4
		internal int Width
		{
			get
			{
				return this.right - this.left;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0001AAE4 File Offset: 0x00018CE4
		internal int Height
		{
			get
			{
				return this.bottom - this.top;
			}
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0001AAF4 File Offset: 0x00018CF4
		public override string ToString()
		{
			return string.Format("({0},{1})-({2},{3})", new object[]
			{
				this.left,
				this.top,
				this.right,
				this.bottom
			});
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0001AB4C File Offset: 0x00018D4C
		internal Rectangle ToRectangle()
		{
			return Rectangle.FromLTRB(this.left, this.top, this.right, this.bottom);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0001AB6C File Offset: 0x00018D6C
		internal static Win32Rectangle From(Rectangle value)
		{
			return new Win32Rectangle
			{
				left = value.Left,
				right = value.Right,
				top = value.Top,
				bottom = value.Bottom
			};
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0001ABBC File Offset: 0x00018DBC
		internal static Win32Rectangle From(Size value)
		{
			return new Win32Rectangle
			{
				left = 0,
				right = value.Width,
				top = 0,
				bottom = value.Height
			};
		}

		// Token: 0x040003D2 RID: 978
		internal int left;

		// Token: 0x040003D3 RID: 979
		internal int top;

		// Token: 0x040003D4 RID: 980
		internal int right;

		// Token: 0x040003D5 RID: 981
		internal int bottom;
	}
}
