using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200008B RID: 139
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal class DeviceMode
	{
		// Token: 0x06000831 RID: 2097 RVA: 0x0001A9B8 File Offset: 0x00018BB8
		internal DeviceMode()
		{
			this.Size = (short)Marshal.SizeOf(this);
		}

		// Token: 0x04000348 RID: 840
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		internal string DeviceName;

		// Token: 0x04000349 RID: 841
		internal short SpecVersion;

		// Token: 0x0400034A RID: 842
		internal short DriverVersion;

		// Token: 0x0400034B RID: 843
		private short Size;

		// Token: 0x0400034C RID: 844
		internal short DriverExtra;

		// Token: 0x0400034D RID: 845
		internal int Fields;

		// Token: 0x0400034E RID: 846
		internal POINT Position;

		// Token: 0x0400034F RID: 847
		internal int DisplayOrientation;

		// Token: 0x04000350 RID: 848
		internal int DisplayFixedOutput;

		// Token: 0x04000351 RID: 849
		internal short Color;

		// Token: 0x04000352 RID: 850
		internal short Duplex;

		// Token: 0x04000353 RID: 851
		internal short YResolution;

		// Token: 0x04000354 RID: 852
		internal short TTOption;

		// Token: 0x04000355 RID: 853
		internal short Collate;

		// Token: 0x04000356 RID: 854
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		internal string FormName;

		// Token: 0x04000357 RID: 855
		internal short LogPixels;

		// Token: 0x04000358 RID: 856
		internal int BitsPerPel;

		// Token: 0x04000359 RID: 857
		internal int PelsWidth;

		// Token: 0x0400035A RID: 858
		internal int PelsHeight;

		// Token: 0x0400035B RID: 859
		internal int DisplayFlags;

		// Token: 0x0400035C RID: 860
		internal int DisplayFrequency;

		// Token: 0x0400035D RID: 861
		internal int ICMMethod;

		// Token: 0x0400035E RID: 862
		internal int ICMIntent;

		// Token: 0x0400035F RID: 863
		internal int MediaType;

		// Token: 0x04000360 RID: 864
		internal int DitherType;

		// Token: 0x04000361 RID: 865
		internal int Reserved1;

		// Token: 0x04000362 RID: 866
		internal int Reserved2;

		// Token: 0x04000363 RID: 867
		internal int PanningWidth;

		// Token: 0x04000364 RID: 868
		internal int PanningHeight;
	}
}
