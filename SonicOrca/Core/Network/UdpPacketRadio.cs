using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000185 RID: 389
	internal class UdpPacketRadio : IPacketRadio, IDisposable, IObservable<ReceivedPacket>
	{
		// Token: 0x0600110D RID: 4365 RVA: 0x000438F0 File Offset: 0x00041AF0
		public UdpPacketRadio(int port)
		{
			this._udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, port));
			Trace.WriteLine("Listening for UDP packets on port " + port + ".");
			this.RunReceiveThread();
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x00043949 File Offset: 0x00041B49
		public UdpPacketRadio(IPAddress serverIpAddress, int port)
		{
			this._udpClient = new UdpClient();
			this._udpClient.Connect(serverIpAddress, port);
			this.RunReceiveThread();
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x00043980 File Offset: 0x00041B80
		public UdpPacketRadio(string serverHost, int port)
		{
			this._udpClient = new UdpClient();
			IPAddress addr;
			if (IPAddress.TryParse(serverHost, out addr))
			{
				this._udpClient.Connect(addr, port);
			}
			else
			{
				this._udpClient.Connect(serverHost, port);
			}
			this.RunReceiveThread();
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x000439DA File Offset: 0x00041BDA
		public void Dispose()
		{
			this._udpClient.Close();
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x000439E7 File Offset: 0x00041BE7
		private void RunReceiveThread()
		{
			Task.Run(async delegate()
			{
				for (;;)
				{
					UdpReceiveResult udpReceiveResult = await this._udpClient.ReceiveAsync();
					this.OnReceivePacket(new ReceivedPacket(udpReceiveResult.RemoteEndPoint, Packet.FromBuffer(udpReceiveResult.Buffer)));
				}
			});
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x000439FC File Offset: 0x00041BFC
		private void OnReceivePacket(ReceivedPacket receivedPacket)
		{
			Console.WriteLine("RECEIVE " + receivedPacket.Packet);
			Interlocked.Increment(ref this._packetsReceived);
			object sync = this._subscribers.Sync;
			lock (sync)
			{
				foreach (IObserver<ReceivedPacket> observer in this._subscribers.Instance)
				{
					observer.OnNext(receivedPacket);
				}
			}
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x00043AA0 File Offset: 0x00041CA0
		public async Task SendPacketAsync(Packet packet)
		{
			byte[] array = packet.Serialise();
			await this._udpClient.SendAsync(array, array.Length);
			Interlocked.Increment(ref this._packetsSent);
			Console.WriteLine("SEND " + packet);
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x00043AF0 File Offset: 0x00041CF0
		public async Task SendPacketAsync(IPEndPoint destination, Packet packet)
		{
			byte[] array = packet.Serialise();
			await this._udpClient.SendAsync(array, array.Length, destination);
			Interlocked.Increment(ref this._packetsSent);
			Console.WriteLine("SEND " + packet);
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x00043B48 File Offset: 0x00041D48
		public IDisposable Subscribe(IObserver<ReceivedPacket> observer)
		{
			object sync = this._subscribers.Sync;
			lock (sync)
			{
				this._subscribers.Instance.Add(observer);
			}
			return Disposable.FromAction(delegate
			{
				object sync2 = this._subscribers.Sync;
				lock (sync2)
				{
					this._subscribers.Instance.Remove(observer);
				}
			});
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x00043BC4 File Offset: 0x00041DC4
		public override string ToString()
		{
			return string.Format("UdpPacketRadio Sent = {0} Received {1}", this._packetsSent, this._packetsReceived, this._udpClient);
		}

		// Token: 0x04000999 RID: 2457
		private readonly Lockable<List<IObserver<ReceivedPacket>>> _subscribers = new Lockable<List<IObserver<ReceivedPacket>>>(new List<IObserver<ReceivedPacket>>());

		// Token: 0x0400099A RID: 2458
		private readonly UdpClient _udpClient;

		// Token: 0x0400099B RID: 2459
		private int _packetsSent;

		// Token: 0x0400099C RID: 2460
		private int _packetsReceived;
	}
}
