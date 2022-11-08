using System;

namespace SonicOrca.Audio
{
	// Token: 0x020001A2 RID: 418
	public interface ISampleProvider
	{
		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x060011F2 RID: 4594
		double CalculatedVolume { get; }

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x060011F3 RID: 4595
		double Pan { get; }

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x060011F4 RID: 4596
		bool Playing { get; }

		// Token: 0x060011F5 RID: 4597
		int Read(byte[] buffer, int offset, int count);
	}
}
