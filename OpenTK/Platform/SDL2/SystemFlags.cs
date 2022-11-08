using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005BD RID: 1469
	[Flags]
	internal enum SystemFlags : uint
	{
		// Token: 0x040054B3 RID: 21683
		Default = 0U,
		// Token: 0x040054B4 RID: 21684
		TIMER = 1U,
		// Token: 0x040054B5 RID: 21685
		AUDIO = 16U,
		// Token: 0x040054B6 RID: 21686
		VIDEO = 32U,
		// Token: 0x040054B7 RID: 21687
		JOYSTICK = 512U,
		// Token: 0x040054B8 RID: 21688
		HAPTIC = 4096U,
		// Token: 0x040054B9 RID: 21689
		GAMECONTROLLER = 8192U,
		// Token: 0x040054BA RID: 21690
		NOPARACHUTE = 1048576U,
		// Token: 0x040054BB RID: 21691
		EVERYTHING = 12849U
	}
}
