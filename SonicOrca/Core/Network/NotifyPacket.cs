using System;

namespace SonicOrca.Core.Network
{
	// Token: 0x0200017F RID: 383
	internal class NotifyPacket : Packet
	{
		// Token: 0x060010F4 RID: 4340 RVA: 0x0004358C File Offset: 0x0004178C
		public NotifyPacket(PacketType packetType) : base(packetType)
		{
		}

		// Token: 0x060010F5 RID: 4341 RVA: 0x00043595 File Offset: 0x00041795
		protected override byte[] SerialiseData()
		{
			return new byte[0];
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x0004359D File Offset: 0x0004179D
		public override string ToString()
		{
			return string.Format("Notify packet = {0}", base.Type);
		}
	}
}
