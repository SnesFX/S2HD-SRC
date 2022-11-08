using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000178 RID: 376
	internal class NetworkGameServer : IDisposable, IObserver<ReceivedPacket>
	{
		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x0600109F RID: 4255 RVA: 0x00042435 File Offset: 0x00040635
		// (set) Token: 0x060010A0 RID: 4256 RVA: 0x0004243D File Offset: 0x0004063D
		public bool AllowClientsToConnect { get; set; }

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x060010A1 RID: 4257 RVA: 0x00042448 File Offset: 0x00040648
		public IReadOnlyList<NetworkPlayer> NetworkPlayers
		{
			get
			{
				object sync = this._networkPlayers.Sync;
				IReadOnlyList<NetworkPlayer> result;
				lock (sync)
				{
					result = this._networkPlayers.Instance.ToArray();
				}
				return result;
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x060010A2 RID: 4258 RVA: 0x0004249C File Offset: 0x0004069C
		// (set) Token: 0x060010A3 RID: 4259 RVA: 0x000424A4 File Offset: 0x000406A4
		public Level Level { get; set; }

		// Token: 0x060010A4 RID: 4260 RVA: 0x000424B0 File Offset: 0x000406B0
		public NetworkGameServer(Level level, int port)
		{
			this.Level = level;
			this._radio = new UdpPacketRadio(port);
			this._radio.Subscribe(this);
			this.AllowClientsToConnect = true;
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x0004252D File Offset: 0x0004072D
		public void Dispose()
		{
			this._radio.Dispose();
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x0004253C File Offset: 0x0004073C
		private NetworkPlayer GetNetworkPlayer(IPEndPoint remoteEndPoint)
		{
			object sync = this._networkPlayers.Sync;
			NetworkPlayer result;
			lock (sync)
			{
				result = this._networkPlayers.Instance.FirstOrDefault((NetworkPlayer x) => x.RemoteEndPoint.Equals(remoteEndPoint));
			}
			return result;
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x000425A8 File Offset: 0x000407A8
		private void OnReceiveHandshake(ReceivedPacket receivedPacket)
		{
			if (!this.AllowClientsToConnect)
			{
				return;
			}
			NetworkPlayer newNetworkPlayer = new NetworkPlayer(this, receivedPacket.Sender, "No name");
			object sync = this._networkPlayers.Sync;
			lock (sync)
			{
				this._networkPlayers.Instance.Add(newNetworkPlayer);
			}
			Task.Run(() => this._radio.SendPacketAsync(newNetworkPlayer.RemoteEndPoint, new NotifyPacket(PacketType.ConnectAck)));
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x0004263C File Offset: 0x0004083C
		private void MaintainConnections()
		{
			List<NetworkPlayer> list = new List<NetworkPlayer>();
			object sync = this._networkPlayers.Sync;
			lock (sync)
			{
				foreach (NetworkPlayer networkPlayer in this._networkPlayers.Instance)
				{
					if (Environment.TickCount >= networkPlayer.LastPacketReceivedTickCount + 30000)
					{
						this._networkPlayers.Instance.Remove(networkPlayer);
						list.Add(networkPlayer);
					}
				}
			}
			foreach (NetworkPlayer networkPlayer2 in list)
			{
				this.OnDisconnect(networkPlayer2);
			}
		}

		// Token: 0x060010A9 RID: 4265 RVA: 0x00006325 File Offset: 0x00004525
		private void OnDisconnect(NetworkPlayer networkPlayer)
		{
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public void OnCompleted()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public void OnError(Exception error)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x00042730 File Offset: 0x00040930
		public void OnNext(ReceivedPacket receivedPacket)
		{
			PacketType type = receivedPacket.Packet.Type;
			if (type == PacketType.Connect)
			{
				this.OnReceiveHandshake(receivedPacket);
				return;
			}
			NetworkPlayer networkPlayer = this.GetNetworkPlayer(receivedPacket.Sender);
			if (networkPlayer != null)
			{
				networkPlayer.ReceivePacket(receivedPacket.Packet);
			}
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x00042774 File Offset: 0x00040974
		public void SendPacket(NetworkPlayer networkPlayer, Packet packet)
		{
			object sync = this._outgoingPackets.Sync;
			lock (sync)
			{
				this._outgoingPackets.Instance.Enqueue(new Tuple<IPEndPoint, Packet>(networkPlayer.RemoteEndPoint, packet));
			}
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x000427D0 File Offset: 0x000409D0
		public void SendPacket(IEnumerable<NetworkPlayer> networkPlayers, Packet packet)
		{
			foreach (NetworkPlayer networkPlayer in networkPlayers)
			{
				this.SendPacket(networkPlayer, packet);
			}
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x0004281C File Offset: 0x00040A1C
		public void SendPacketToAllClients(Packet packet)
		{
			object sync = this._networkPlayers.Sync;
			lock (sync)
			{
				foreach (NetworkPlayer networkPlayer in this._networkPlayers.Instance)
				{
					this.SendPacket(networkPlayer, packet);
				}
			}
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x000428A4 File Offset: 0x00040AA4
		public void Update()
		{
			NetworkGameServer.<>c__DisplayClass29_0 CS$<>8__locals1 = new NetworkGameServer.<>c__DisplayClass29_0();
			CS$<>8__locals1.<>4__this = this;
			object sync = this._networkPlayers.Sync;
			lock (sync)
			{
				foreach (NetworkPlayer networkPlayer in this._networkPlayers.Instance)
				{
					networkPlayer.Update();
				}
			}
			if (this.Level != null)
			{
				this.PerformCharacterInputs();
				this.ConstructPackets();
			}
			sync = this._outgoingPackets.Sync;
			lock (sync)
			{
				CS$<>8__locals1.packetsToSend = this._outgoingPackets.Instance.ToArray();
				this._outgoingPackets.Instance.Clear();
			}
			Task.Run(delegate()
			{
				NetworkGameServer.<>c__DisplayClass29_0.<<Update>b__0>d <<Update>b__0>d;
				<<Update>b__0>d.<>4__this = CS$<>8__locals1;
				<<Update>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<Update>b__0>d.<>1__state = -1;
				AsyncTaskMethodBuilder <>t__builder = <<Update>b__0>d.<>t__builder;
				<>t__builder.Start<NetworkGameServer.<>c__DisplayClass29_0.<<Update>b__0>d>(ref <<Update>b__0>d);
				return <<Update>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x000429AC File Offset: 0x00040BAC
		private void ConstructPackets()
		{
			if (this._lastCharacterSynchronisationTickCount + 200 < Environment.TickCount)
			{
				this._lastCharacterSynchronisationTickCount = Environment.TickCount;
				this.SendCharacterSynchronisation();
			}
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x000429D4 File Offset: 0x00040BD4
		private void PerformCharacterInputs()
		{
			ICharacter[] array = this.Level.ObjectManager.Characters.ToArray<ICharacter>();
			object sync = this._networkPlayers.Sync;
			lock (sync)
			{
				using (List<NetworkPlayer>.Enumerator enumerator = this._networkPlayers.Instance.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						NetworkPlayer networkPlayer = enumerator.Current;
						int characterId = networkPlayer.CharacterId;
						if (characterId >= 0 && characterId < array.Length)
						{
							array[characterId].Input = new CharacterInputState
							{
								Throttle = networkPlayer.InputDirection.X,
								VerticalDirection = Math.Sign(networkPlayer.InputDirection.Y),
								A = (networkPlayer.InputAction ? CharacterInputButtonState.Down : CharacterInputButtonState.Up)
							};
							if (networkPlayer.InputDirty)
							{
								IEnumerable<NetworkPlayer> instance = this._networkPlayers.Instance;
								Func<NetworkPlayer, bool> predicate;
								Func<NetworkPlayer, bool> <>9__0;
								if ((predicate = <>9__0) == null)
								{
									predicate = (<>9__0 = ((NetworkPlayer x) => x != networkPlayer));
								}
								foreach (NetworkPlayer networkPlayer2 in instance.Where(predicate))
								{
									networkPlayer2.SendPacket(new PlayInputPacket(characterId, networkPlayer.InputDirection, networkPlayer.InputAction));
								}
								networkPlayer.InputDirty = false;
							}
						}
					}
				}
			}
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x00042BC8 File Offset: 0x00040DC8
		private void SendCharacterSynchronisation()
		{
			ICharacter[] array = this.Level.ObjectManager.Characters.ToArray<ICharacter>();
			if (array.Length == 0)
			{
				return;
			}
			this.SendPacketToAllClients(new CharacterSynchronisationPacket(array));
		}

		// Token: 0x04000962 RID: 2402
		private readonly ConcurrentQueue<Packet> _receivedPackets = new ConcurrentQueue<Packet>();

		// Token: 0x04000963 RID: 2403
		private readonly Lockable<Queue<Tuple<IPEndPoint, Packet>>> _outgoingPackets = new Lockable<Queue<Tuple<IPEndPoint, Packet>>>(new Queue<Tuple<IPEndPoint, Packet>>());

		// Token: 0x04000964 RID: 2404
		private IPacketRadio _radio;

		// Token: 0x04000965 RID: 2405
		private readonly Lockable<List<NetworkPlayer>> _networkPlayers = new Lockable<List<NetworkPlayer>>(new List<NetworkPlayer>());

		// Token: 0x04000966 RID: 2406
		private Vector2[] _characterInputDirection = new Vector2[2];

		// Token: 0x04000967 RID: 2407
		private bool[] _characterInputAction = new bool[2];

		// Token: 0x04000968 RID: 2408
		private int _lastCharacterSynchronisationTickCount;
	}
}
