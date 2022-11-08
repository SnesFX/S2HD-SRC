using System;
using System.Net;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000183 RID: 387
	internal class ReceivedPacket
	{
		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06001109 RID: 4361 RVA: 0x000438B2 File Offset: 0x00041AB2
		public IPEndPoint Sender
		{
			get
			{
				return this._sender;
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x0600110A RID: 4362 RVA: 0x000438BA File Offset: 0x00041ABA
		public Packet Packet
		{
			get
			{
				return this._packet;
			}
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x000438C2 File Offset: 0x00041AC2
		public ReceivedPacket(IPEndPoint sender, Packet packet)
		{
			this._sender = sender;
			this._packet = packet;
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x000438D8 File Offset: 0x00041AD8
		public override string ToString()
		{
			return string.Format("{0} sent {1}", this._sender, this._packet);
		}

		// Token: 0x0400098C RID: 2444
		private readonly IPEndPoint _sender;

		// Token: 0x0400098D RID: 2445
		private readonly Packet _packet;
	}
}
