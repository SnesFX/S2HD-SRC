using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x020000B7 RID: 183
	[Flags]
	internal enum RawInputDeviceFlags
	{
		// Token: 0x0400049C RID: 1180
		REMOVE = 1,
		// Token: 0x0400049D RID: 1181
		EXCLUDE = 16,
		// Token: 0x0400049E RID: 1182
		PAGEONLY = 32,
		// Token: 0x0400049F RID: 1183
		NOLEGACY = 48,
		// Token: 0x040004A0 RID: 1184
		INPUTSINK = 256,
		// Token: 0x040004A1 RID: 1185
		CAPTUREMOUSE = 512,
		// Token: 0x040004A2 RID: 1186
		NOHOTKEYS = 512,
		// Token: 0x040004A3 RID: 1187
		APPKEYS = 1024,
		// Token: 0x040004A4 RID: 1188
		EXINPUTSINK = 4096,
		// Token: 0x040004A5 RID: 1189
		DEVNOTIFY = 8192
	}
}
