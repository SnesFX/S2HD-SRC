using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000093 RID: 147
	internal struct RawInputDeviceList
	{
		// Token: 0x06000836 RID: 2102 RVA: 0x0001AA90 File Offset: 0x00018C90
		public override string ToString()
		{
			return string.Format("{0}, Handle: {1}", this.Type, this.Device);
		}

		// Token: 0x040003A3 RID: 931
		internal IntPtr Device;

		// Token: 0x040003A4 RID: 932
		internal RawInputDeviceType Type;
	}
}
