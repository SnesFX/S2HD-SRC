using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B51 RID: 2897
	internal struct XkbDesc
	{
		// Token: 0x0400B761 RID: 46945
		internal IntPtr dpy;

		// Token: 0x0400B762 RID: 46946
		internal ushort flags;

		// Token: 0x0400B763 RID: 46947
		internal ushort device_spec;

		// Token: 0x0400B764 RID: 46948
		internal byte min_key_code;

		// Token: 0x0400B765 RID: 46949
		internal byte max_key_code;

		// Token: 0x0400B766 RID: 46950
		internal IntPtr ctrls;

		// Token: 0x0400B767 RID: 46951
		internal IntPtr server;

		// Token: 0x0400B768 RID: 46952
		internal IntPtr map;

		// Token: 0x0400B769 RID: 46953
		internal IntPtr indicators;

		// Token: 0x0400B76A RID: 46954
		internal unsafe XkbNames* names;

		// Token: 0x0400B76B RID: 46955
		internal IntPtr compat;

		// Token: 0x0400B76C RID: 46956
		internal IntPtr geom;
	}
}
