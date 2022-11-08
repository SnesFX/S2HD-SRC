using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading.Tasks;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Network
{
	// Token: 0x0200017A RID: 378
	internal class NetworkPlayer
	{
		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x060010C2 RID: 4290 RVA: 0x00042D3F File Offset: 0x00040F3F
		public IPEndPoint RemoteEndPoint
		{
			get
			{
				return this._remoteEndPoint;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x060010C3 RID: 4291 RVA: 0x00042D47 File Offset: 0x00040F47
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x060010C4 RID: 4292 RVA: 0x00042D4F File Offset: 0x00040F4F
		// (set) Token: 0x060010C5 RID: 4293 RVA: 0x00042D57 File Offset: 0x00040F57
		public Player Player { get; set; }

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x060010C6 RID: 4294 RVA: 0x00042D60 File Offset: 0x00040F60
		// (set) Token: 0x060010C7 RID: 4295 RVA: 0x00042D68 File Offset: 0x00040F68
		public int CharacterId { get; set; }

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x060010C8 RID: 4296 RVA: 0x00042D71 File Offset: 0x00040F71
		// (set) Token: 0x060010C9 RID: 4297 RVA: 0x00042D79 File Offset: 0x00040F79
		public Vector2 InputDirection { get; set; }

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x060010CA RID: 4298 RVA: 0x00042D82 File Offset: 0x00040F82
		// (set) Token: 0x060010CB RID: 4299 RVA: 0x00042D8A File Offset: 0x00040F8A
		public bool InputAction { get; set; }

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x060010CC RID: 4300 RVA: 0x00042D93 File Offset: 0x00040F93
		// (set) Token: 0x060010CD RID: 4301 RVA: 0x00042D9B File Offset: 0x00040F9B
		public bool InputDirty { get; set; }

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x060010CE RID: 4302 RVA: 0x00042DA4 File Offset: 0x00040FA4
		public int LastPacketReceivedTickCount
		{
			get
			{
				return this._lastPacketReceivedTickCount;
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x060010CF RID: 4303 RVA: 0x00042DAC File Offset: 0x00040FAC
		// (set) Token: 0x060010D0 RID: 4304 RVA: 0x00042DB4 File Offset: 0x00040FB4
		public bool Ready { get; set; }

		// Token: 0x060010D1 RID: 4305 RVA: 0x00042DBD File Offset: 0x00040FBD
		public NetworkPlayer(NetworkGameServer networkGameServer, IPEndPoint remoteEndPoint, string name)
		{
			this._networkGameServer = networkGameServer;
			this._remoteEndPoint = remoteEndPoint;
			this._name = name;
		}

		// Token: 0x060010D2 RID: 4306 RVA: 0x00042DE5 File Offset: 0x00040FE5
		public void SendPacket(Packet packet)
		{
			this._networkGameServer.SendPacket(this, packet);
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x00042DF4 File Offset: 0x00040FF4
		public void ReceivePacket(Packet packet)
		{
			this._lastPacketReceivedTickCount = Environment.TickCount;
			PacketType type = packet.Type;
			if (type == PacketType.Pong)
			{
				this.ReceivePong(((PongPacket)packet).Id);
				return;
			}
			this._receivedPackets.Enqueue(packet);
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x00042E35 File Offset: 0x00041035
		public bool TryGetNextPacket(out Packet packet)
		{
			return this._receivedPackets.TryDequeue(out packet);
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x00042E44 File Offset: 0x00041044
		public void Update()
		{
			if (Environment.TickCount > this._lastPingTickCount + 5000)
			{
				this.Ping();
			}
			Packet packet;
			while (this.TryGetNextPacket(out packet))
			{
				this.ProcessPacket(packet);
			}
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x00042E80 File Offset: 0x00041080
		private void ProcessPacket(Packet packet)
		{
			PacketType type = packet.Type;
			if (type == PacketType.ReadyToStartLevel)
			{
				this.Ready = true;
				return;
			}
			if (type != PacketType.PlayInput)
			{
				return;
			}
			this.ProcessPlayInput((PlayInputPacket)packet);
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x00042EB1 File Offset: 0x000410B1
		private void Ping()
		{
			this._lastPingId++;
			this._lastPingTickCount = Environment.TickCount;
			Task.Run(delegate()
			{
				this.SendPacket(new PingPacket(this._lastPingId, this._roundTripTime));
			});
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x00042EDE File Offset: 0x000410DE
		private void ReceivePong(int id)
		{
			if (id == this._lastPingId)
			{
				this._roundTripTime = Environment.TickCount - this._lastPingTickCount;
			}
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x00042EFD File Offset: 0x000410FD
		private void ProcessPlayInput(PlayInputPacket playInputPacket)
		{
			int characterId = playInputPacket.CharacterId;
			this.InputDirection = playInputPacket.Direction;
			this.InputAction = playInputPacket.Action;
			this.InputDirty = true;
		}

		// Token: 0x04000972 RID: 2418
		private readonly NetworkGameServer _networkGameServer;

		// Token: 0x04000973 RID: 2419
		private readonly IPEndPoint _remoteEndPoint;

		// Token: 0x04000974 RID: 2420
		private readonly string _name;

		// Token: 0x04000975 RID: 2421
		private readonly ConcurrentQueue<Packet> _receivedPackets = new ConcurrentQueue<Packet>();

		// Token: 0x04000978 RID: 2424
		private volatile int _roundTripTime;

		// Token: 0x04000979 RID: 2425
		private int _lastPingId;

		// Token: 0x0400097A RID: 2426
		private int _lastPingTickCount;

		// Token: 0x0400097B RID: 2427
		private int _lastPacketReceivedTickCount;
	}
}
