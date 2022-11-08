using System;

namespace OpenTK.Audio.OpenAL
{
	// Token: 0x0200058B RID: 1419
	public enum ALDistanceModel
	{
		// Token: 0x0400508D RID: 20621
		None,
		// Token: 0x0400508E RID: 20622
		InverseDistance = 53249,
		// Token: 0x0400508F RID: 20623
		InverseDistanceClamped,
		// Token: 0x04005090 RID: 20624
		LinearDistance,
		// Token: 0x04005091 RID: 20625
		LinearDistanceClamped,
		// Token: 0x04005092 RID: 20626
		ExponentDistance,
		// Token: 0x04005093 RID: 20627
		ExponentDistanceClamped
	}
}
