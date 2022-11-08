using System;

namespace Accord.Video.FFMPEG
{
	// Token: 0x02000125 RID: 293
	public enum AudioCodec
	{
		// Token: 0x04000214 RID: 532
		None = -1,
		// Token: 0x04000215 RID: 533
		MP3,
		// Token: 0x04000216 RID: 534
		AAC,
		// Token: 0x04000217 RID: 535
		[Obsolete("Please use MP4ALS instead.")]
		M4A,
		// Token: 0x04000218 RID: 536
		MP4ALS = 2
	}
}
