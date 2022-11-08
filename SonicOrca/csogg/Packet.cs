using System;

namespace csogg
{
	// Token: 0x0200008C RID: 140
	public class Packet
	{
		// Token: 0x040002CF RID: 719
		public byte[] packet_base;

		// Token: 0x040002D0 RID: 720
		public int packet;

		// Token: 0x040002D1 RID: 721
		public int bytes;

		// Token: 0x040002D2 RID: 722
		public int b_o_s;

		// Token: 0x040002D3 RID: 723
		public int e_o_s;

		// Token: 0x040002D4 RID: 724
		public long granulepos;

		// Token: 0x040002D5 RID: 725
		public long packetno;
	}
}
