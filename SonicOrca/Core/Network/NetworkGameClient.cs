using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000177 RID: 375
	internal class NetworkGameClient : IDisposable, IObserver<ReceivedPacket>
	{
		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x0600108A RID: 4234 RVA: 0x00041FEA File Offset: 0x000401EA
		// (set) Token: 0x0600108B RID: 4235 RVA: 0x00041FF2 File Offset: 0x000401F2
		public bool Ready { get; set; }

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x0600108C RID: 4236 RVA: 0x00041FFB File Offset: 0x000401FB
		public bool Connected
		{
			get
			{
				return this._connectionState == NetworkGameClient.ConnectionState.Connected;
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x0600108D RID: 4237 RVA: 0x00042006 File Offset: 0x00040206
		// (set) Token: 0x0600108E RID: 4238 RVA: 0x0004200E File Offset: 0x0004020E
		public Level Level { get; set; }

		// Token: 0x0600108F RID: 4239 RVA: 0x00042018 File Offset: 0x00040218
		public NetworkGameClient(Level level)
		{
			this._connectionState = NetworkGameClient.ConnectionState.NotConnected;
			this.Level = level;
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x00042067 File Offset: 0x00040267
		public void Dispose()
		{
			if (this._radio != null)
			{
				this._radio.Dispose();
			}
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x0004207C File Offset: 0x0004027C
		public async Task InitiateHandshake(string serverHost, int port, int timeout = 5000)
		{
			this._radio = new UdpPacketRadio(serverHost, port);
			this._radio.Subscribe(this);
			this._connectionState = NetworkGameClient.ConnectionState.ConnectingToServer;
			this._handshakeAcknoledged = new TaskCompletionSource<bool>();
			await this._radio.SendPacketAsync(new NotifyPacket(PacketType.Connect));
			await Task.WhenAny(new Task[]
			{
				Task.Delay(timeout),
				this._handshakeAcknoledged.Task
			});
			if (!this._handshakeAcknoledged.Task.IsCompleted)
			{
				throw new TimeoutException("Connecting to server timed out.");
			}
			if (!this._handshakeAcknoledged.Task.Result)
			{
				throw new NetworkException("Server refused connection.");
			}
			this._connectionState = NetworkGameClient.ConnectionState.Connected;
		}

		// Token: 0x06001092 RID: 4242 RVA: 0x000420D9 File Offset: 0x000402D9
		private void OnReceiveHandshakeAcknoledgement(Packet packet)
		{
			if (this._connectionState == NetworkGameClient.ConnectionState.ConnectingToServer)
			{
				this._handshakeAcknoledged.SetResult(true);
			}
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x000420F0 File Offset: 0x000402F0
		public void Pong(PingPacket packet)
		{
			Task.Run(() => this._radio.SendPacketAsync(new PongPacket(packet.Id)));
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public void OnCompleted()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public void OnError(Exception error)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06001096 RID: 4246 RVA: 0x00042118 File Offset: 0x00040318
		public void OnNext(ReceivedPacket receivedPacket)
		{
			PacketType type = receivedPacket.Packet.Type;
			if (type == PacketType.ConnectAck)
			{
				this.OnReceiveHandshakeAcknoledgement(receivedPacket.Packet);
				return;
			}
			if (type != PacketType.Ping)
			{
				this._receivedPackets.Enqueue(receivedPacket.Packet);
				return;
			}
			PingPacket pingPacket = (PingPacket)receivedPacket.Packet;
			this.Pong(pingPacket);
			this._roundTripTime = pingPacket.RoundTripTime;
		}

		// Token: 0x06001097 RID: 4247 RVA: 0x00042179 File Offset: 0x00040379
		public void SendPacket(Packet packet)
		{
			Task.Run(() => this._radio.SendPacketAsync(packet));
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x000421A0 File Offset: 0x000403A0
		public void Update()
		{
			NetworkGameClient.<>c__DisplayClass29_0 CS$<>8__locals1 = new NetworkGameClient.<>c__DisplayClass29_0();
			CS$<>8__locals1.<>4__this = this;
			this._outgoingPackets.Clear();
			Packet packet;
			while (this._receivedPackets.TryDequeue(out packet))
			{
				this.ProcessPacket(packet);
			}
			if (this.Level != null)
			{
				this.PerformCharacterInputs();
				this.ConstructPackets();
			}
			CS$<>8__locals1.packetsToSend = this._outgoingPackets.ToArray();
			Task.Run(delegate()
			{
				NetworkGameClient.<>c__DisplayClass29_0.<<Update>b__0>d <<Update>b__0>d;
				<<Update>b__0>d.<>4__this = CS$<>8__locals1;
				<<Update>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<Update>b__0>d.<>1__state = -1;
				AsyncTaskMethodBuilder <>t__builder = <<Update>b__0>d.<>t__builder;
				<>t__builder.Start<NetworkGameClient.<>c__DisplayClass29_0.<<Update>b__0>d>(ref <<Update>b__0>d);
				return <<Update>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x00042214 File Offset: 0x00040414
		private void ProcessPacket(Packet packet)
		{
			switch (packet.Type)
			{
			case PacketType.ReadyToStartLevel:
				this.Ready = true;
				return;
			case PacketType.PlayInput:
				this.ProcessPlayInput((PlayInputPacket)packet);
				return;
			case PacketType.CharacterSynchronisation:
				this.ProcessCharacterSynchronisation((CharacterSynchronisationPacket)packet);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x0004225E File Offset: 0x0004045E
		private void ConstructPackets()
		{
			this.SendPlayInput();
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x00042268 File Offset: 0x00040468
		private void ProcessPlayInput(PlayInputPacket playInputPacket)
		{
			int characterId = playInputPacket.CharacterId;
			if (characterId == this._characterId)
			{
				return;
			}
			this._characterInputDirection[characterId] = playInputPacket.Direction;
			this._characterInputAction[characterId] = playInputPacket.Action;
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x000422A6 File Offset: 0x000404A6
		private void ProcessCharacterSynchronisation(CharacterSynchronisationPacket characterSynchronisation)
		{
			if (characterSynchronisation == null)
			{
				return;
			}
			characterSynchronisation.Apply(this.Level.ObjectManager.Characters.ToArray<ICharacter>(), this._roundTripTime);
			characterSynchronisation = null;
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x000422D0 File Offset: 0x000404D0
		private void SendPlayInput()
		{
			SonicOrcaGameContext gameContext = this.Level.GameContext;
			if (this._characterInputDirection[this._characterId] == gameContext.Current[0].DirectionLeft && this._characterInputAction[this._characterId] == gameContext.Current[0].Action1)
			{
				return;
			}
			this._characterInputDirection[this._characterId] = gameContext.Current[0].DirectionLeft;
			this._characterInputAction[this._characterId] = gameContext.Current[0].Action1;
			PlayInputPacket item = new PlayInputPacket(this._characterId, this._characterInputDirection[this._characterId], this._characterInputAction[this._characterId]);
			this._outgoingPackets.Enqueue(item);
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x000423AC File Offset: 0x000405AC
		private void PerformCharacterInputs()
		{
			ICharacter[] array = this.Level.ObjectManager.Characters.ToArray<ICharacter>();
			for (int i = 0; i < 2; i++)
			{
				if (array.Length > i)
				{
					array[i].Input = new CharacterInputState
					{
						Throttle = this._characterInputDirection[i].X,
						VerticalDirection = Math.Sign(this._characterInputDirection[i].Y),
						A = (this._characterInputAction[i] ? CharacterInputButtonState.Down : CharacterInputButtonState.Up)
					};
				}
			}
		}

		// Token: 0x04000957 RID: 2391
		private readonly ConcurrentQueue<Packet> _receivedPackets = new ConcurrentQueue<Packet>();

		// Token: 0x04000958 RID: 2392
		private readonly Queue<Packet> _outgoingPackets = new Queue<Packet>();

		// Token: 0x04000959 RID: 2393
		private IPacketRadio _radio;

		// Token: 0x0400095A RID: 2394
		private NetworkGameClient.ConnectionState _connectionState;

		// Token: 0x0400095B RID: 2395
		private int _roundTripTime;

		// Token: 0x0400095C RID: 2396
		private int _characterId;

		// Token: 0x0400095D RID: 2397
		private Vector2[] _characterInputDirection = new Vector2[2];

		// Token: 0x0400095E RID: 2398
		private bool[] _characterInputAction = new bool[2];

		// Token: 0x04000961 RID: 2401
		private TaskCompletionSource<bool> _handshakeAcknoledged;

		// Token: 0x0200024C RID: 588
		private enum ConnectionState
		{
			// Token: 0x04000CA2 RID: 3234
			NotConnected,
			// Token: 0x04000CA3 RID: 3235
			ConnectingToServer,
			// Token: 0x04000CA4 RID: 3236
			Connected
		}
	}
}
