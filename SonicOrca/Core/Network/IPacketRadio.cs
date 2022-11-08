using System;
using System.Net;
using System.Threading.Tasks;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000175 RID: 373
	internal interface IPacketRadio : IDisposable, IObservable<ReceivedPacket>
	{
		// Token: 0x06001084 RID: 4228
		Task SendPacketAsync(Packet packet);

		// Token: 0x06001085 RID: 4229
		Task SendPacketAsync(IPEndPoint destination, Packet packet);
	}
}
