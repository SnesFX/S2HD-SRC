using System;
using System.Threading.Tasks;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000179 RID: 377
	public class NetworkManager
	{
		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x060010B4 RID: 4276 RVA: 0x00042BFC File Offset: 0x00040DFC
		// (set) Token: 0x060010B5 RID: 4277 RVA: 0x00042C04 File Offset: 0x00040E04
		internal NetworkGameServer Server { get; private set; }

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x060010B6 RID: 4278 RVA: 0x00042C0D File Offset: 0x00040E0D
		// (set) Token: 0x060010B7 RID: 4279 RVA: 0x00042C15 File Offset: 0x00040E15
		internal NetworkGameClient Client { get; private set; }

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x060010B8 RID: 4280 RVA: 0x00042C1E File Offset: 0x00040E1E
		// (set) Token: 0x060010B9 RID: 4281 RVA: 0x00042C26 File Offset: 0x00040E26
		public bool NetworkPlay { get; private set; }

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x060010BA RID: 4282 RVA: 0x00042C2F File Offset: 0x00040E2F
		// (set) Token: 0x060010BB RID: 4283 RVA: 0x00042C37 File Offset: 0x00040E37
		public bool Hosting { get; private set; }

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x060010BC RID: 4284 RVA: 0x00042C40 File Offset: 0x00040E40
		// (set) Token: 0x060010BD RID: 4285 RVA: 0x00042C48 File Offset: 0x00040E48
		public bool AllConnected { get; private set; }

		// Token: 0x060010BE RID: 4286 RVA: 0x00042C51 File Offset: 0x00040E51
		public void Host(int port = 7237)
		{
			this.Server = new NetworkGameServer(null, 7237);
			this.NetworkPlay = true;
			this.Hosting = true;
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x00042C72 File Offset: 0x00040E72
		public void Join(string serverHost, int port = 7237)
		{
			this.Client = new NetworkGameClient(null);
			this._joiningServer = this.Client.InitiateHandshake(serverHost, port, 5000);
			this.NetworkPlay = true;
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x00042CA0 File Offset: 0x00040EA0
		public void Update()
		{
			if (!this.NetworkPlay)
			{
				return;
			}
			if (!this.AllConnected)
			{
				if (this.Hosting)
				{
					if (this.Server.NetworkPlayers.Count > 0)
					{
						this.Server.AllowClientsToConnect = false;
						this.AllConnected = true;
						return;
					}
				}
				else if (this._joiningServer.IsCompleted)
				{
					if (this._joiningServer.IsFaulted)
					{
						throw this._joiningServer.Exception.InnerException;
					}
					this.AllConnected = true;
				}
				return;
			}
			if (this.Hosting)
			{
				this.Server.Update();
				return;
			}
			this.Client.Update();
		}

		// Token: 0x0400096B RID: 2411
		public const int DefaultPort = 7237;

		// Token: 0x0400096C RID: 2412
		private Task _joiningServer;
	}
}
