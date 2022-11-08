using System;
using System.Collections.Generic;

namespace SonicOrca.Audio
{
	// Token: 0x020001A1 RID: 417
	public interface ISampleMixer
	{
		// Token: 0x060011F1 RID: 4593
		void Mix(byte[] buffer, int offset, int length, IEnumerable<ISampleProvider> channels);
	}
}
