using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B6C RID: 2924
	internal struct ModeConnector
	{
		// Token: 0x0400B7F6 RID: 47094
		public int connector_id;

		// Token: 0x0400B7F7 RID: 47095
		public int encoder_id;

		// Token: 0x0400B7F8 RID: 47096
		public int connector_type;

		// Token: 0x0400B7F9 RID: 47097
		public int connector_type_id;

		// Token: 0x0400B7FA RID: 47098
		public ModeConnection connection;

		// Token: 0x0400B7FB RID: 47099
		public int mmWidth;

		// Token: 0x0400B7FC RID: 47100
		public int mmHeight;

		// Token: 0x0400B7FD RID: 47101
		public ModeSubPixel subpixel;

		// Token: 0x0400B7FE RID: 47102
		public int count_modes;

		// Token: 0x0400B7FF RID: 47103
		public unsafe ModeInfo* modes;

		// Token: 0x0400B800 RID: 47104
		public int count_props;

		// Token: 0x0400B801 RID: 47105
		public unsafe int* props;

		// Token: 0x0400B802 RID: 47106
		public unsafe long* prop_values;

		// Token: 0x0400B803 RID: 47107
		public int count_encoders;

		// Token: 0x0400B804 RID: 47108
		public unsafe int* encoders;
	}
}
