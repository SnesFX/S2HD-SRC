using System;

namespace OpenTK
{
	// Token: 0x02000B0A RID: 2826
	public sealed class MouseCursor : WindowIcon
	{
		// Token: 0x060059A5 RID: 22949 RVA: 0x000F3830 File Offset: 0x000F1A30
		private MouseCursor()
		{
		}

		// Token: 0x060059A6 RID: 22950 RVA: 0x000F3838 File Offset: 0x000F1A38
		public MouseCursor(int hotx, int hoty, int width, int height, byte[] data) : base(width, height, data)
		{
			if (hotx < 0 || hotx >= base.Width || hoty < 0 || hoty >= base.Height)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.x = hotx;
			this.y = hoty;
		}

		// Token: 0x060059A7 RID: 22951 RVA: 0x000F3874 File Offset: 0x000F1A74
		public MouseCursor(int hotx, int hoty, int width, int height, IntPtr data) : base(width, height, data)
		{
			if (hotx < 0 || hotx >= base.Width || hoty < 0 || hoty >= base.Height)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.x = hotx;
			this.y = hoty;
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x060059A8 RID: 22952 RVA: 0x000F38B0 File Offset: 0x000F1AB0
		internal int X
		{
			get
			{
				return this.x;
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x060059A9 RID: 22953 RVA: 0x000F38B8 File Offset: 0x000F1AB8
		internal int Y
		{
			get
			{
				return this.y;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x060059AA RID: 22954 RVA: 0x000F38C0 File Offset: 0x000F1AC0
		public static MouseCursor Default
		{
			get
			{
				return MouseCursor.default_cursor;
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x060059AB RID: 22955 RVA: 0x000F38C8 File Offset: 0x000F1AC8
		public static MouseCursor Empty
		{
			get
			{
				return MouseCursor.empty_cursor;
			}
		}

		// Token: 0x0400B4E0 RID: 46304
		private static readonly MouseCursor default_cursor = new MouseCursor();

		// Token: 0x0400B4E1 RID: 46305
		private static readonly MouseCursor empty_cursor = new MouseCursor(0, 0, 16, 16, new byte[1024]);

		// Token: 0x0400B4E2 RID: 46306
		private int x;

		// Token: 0x0400B4E3 RID: 46307
		private int y;
	}
}
