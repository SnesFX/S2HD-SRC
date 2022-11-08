using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Core.Network;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Menu;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000116 RID: 278
	public class LevelScreen : Screen
	{
		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x00028901 File Offset: 0x00026B01
		// (set) Token: 0x06000A4F RID: 2639 RVA: 0x00028909 File Offset: 0x00026B09
		public Vector2i? OverrideStartPosition { get; set; }

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000A50 RID: 2640 RVA: 0x00028912 File Offset: 0x00026B12
		public Area Area
		{
			get
			{
				return this._area;
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x0002891A File Offset: 0x00026B1A
		public Player Player
		{
			get
			{
				return this._player;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000A52 RID: 2642 RVA: 0x00028922 File Offset: 0x00026B22
		public Level Level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0002892C File Offset: 0x00026B2C
		public LevelScreen(SonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._resourceSession = new ResourceSession(gameContext.ResourceTree);
			this._level = new Level(this._gameContext);
			this._currentAct = int.Parse(this._gameContext.Configuration.GetProperty("debug", "startact", "1"));
			string property = this._gameContext.Configuration.GetProperty("debug", "startpos", null);
			if (property != null)
			{
				string[] array = property.Split(new char[]
				{
					','
				});
				this.OverrideStartPosition = new Vector2i?(new Vector2i(int.Parse(array[0]), int.Parse(array[1])));
			}
			int num = int.Parse(this._gameContext.Configuration.GetProperty("debug", "zone", "1"));
			if (num == 2)
			{
				this._areaResourceKey = "SONICORCA/S2/LEVELS/CPZ/AREA";
			}
			if (num == 3)
			{
				this._areaResourceKey = "SONICORCA/S2/LEVELS/ARZ/AREA";
				return;
			}
			if (num == 5)
			{
				this._areaResourceKey = "SONICORCA/S2/LEVELS/HTZ/AREA";
			}
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x00028A48 File Offset: 0x00026C48
		public LevelScreen(SonicOrcaGameContext gameContext, string areaResourceKey, int act)
		{
			this._gameContext = gameContext;
			this._resourceSession = new ResourceSession(gameContext.ResourceTree);
			this._level = new Level(this._gameContext);
			this._areaResourceKey = areaResourceKey;
			this._currentAct = act;
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00028AA4 File Offset: 0x00026CA4
		public override async Task LoadAsync(ScreenLoadingProgress progress, CancellationToken ct = default(CancellationToken))
		{
			this._resourceSession.PushDependency("SONICORCA/FONTS/HUD");
			await this._resourceSession.LoadAsync(ct, false);
			this._font = this._gameContext.ResourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/HUD");
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00028AF1 File Offset: 0x00026CF1
		public override void Unload()
		{
			if (this._level != null)
			{
				this._level.Dispose();
			}
			this._resourceSession.Unload();
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x00028B14 File Offset: 0x00026D14
		public override void Update()
		{
			switch (this._state)
			{
			case LevelScreen.LevelScreenState.Initialise:
				if (this.NetworkSetupCheck())
				{
					this._state = LevelScreen.LevelScreenState.EstablishingNetworkPlay;
					return;
				}
				this._state = LevelScreen.LevelScreenState.Loading;
				return;
			case LevelScreen.LevelScreenState.Loading:
				this.LoadingUpdate();
				return;
			case LevelScreen.LevelScreenState.ReadyToQuit:
				this.UnloadLevel();
				base.Finish();
				return;
			case LevelScreen.LevelScreenState.ReadyToPlay:
			case LevelScreen.LevelScreenState.Playing:
				this.PlayingUpdate();
				return;
			case LevelScreen.LevelScreenState.EstablishingNetworkPlay:
				this.EstablishNetworkUpdate();
				return;
			case LevelScreen.LevelScreenState.NetworkWaitingForStart:
				this.NetworkWaitingUpdate();
				return;
			case LevelScreen.LevelScreenState.FadingOut:
				this.PlayingUpdate();
				if (!this._level.StateFlags.HasFlag(LevelStateFlags.FadingOut))
				{
					this._state = this._nextState;
					return;
				}
				break;
			case LevelScreen.LevelScreenState.Dead:
			{
				if (this._level.StateFlags.HasFlag(LevelStateFlags.TimeUp))
				{
					this._player.StarpostTime = 0;
				}
				this._level.Time = this._player.StarpostTime;
				this.UnloadLevel();
				Player player = this._player;
				int lives = player.Lives;
				player.Lives = lives - 1;
				if (this._player.Lives <= 0)
				{
					base.Finish();
					return;
				}
				this._state = LevelScreen.LevelScreenState.Loading;
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00028C44 File Offset: 0x00026E44
		public override void Draw(Renderer renderer)
		{
			switch (this._state)
			{
			case LevelScreen.LevelScreenState.Loading:
				if (this._seamless)
				{
					this.PlayingDraw(renderer);
					return;
				}
				this.LoadingDraw(renderer);
				return;
			case LevelScreen.LevelScreenState.ReadyToQuit:
				break;
			case LevelScreen.LevelScreenState.ReadyToPlay:
				if (this._seamless)
				{
					this.PlayingDraw(renderer);
					return;
				}
				break;
			case LevelScreen.LevelScreenState.Playing:
			case LevelScreen.LevelScreenState.FadingOut:
				this.PlayingDraw(renderer);
				break;
			case LevelScreen.LevelScreenState.EstablishingNetworkPlay:
				this.EstablishNetworkDraw(renderer);
				return;
			case LevelScreen.LevelScreenState.NetworkWaitingForStart:
				this.NetworkWaitingDraw(renderer);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00028CBC File Offset: 0x00026EBC
		private async Task LoadArea(CancellationToken ct = default(CancellationToken))
		{
			this._resourceSession.PushDependency(this._areaResourceKey);
			await this._resourceSession.LoadAsync(ct, false);
			this._area = this._gameContext.ResourceTree.GetLoadedResource<Area>(this._areaResourceKey);
			this._player = this._level.Player;
			await this._level.LoadCommonAsync(ct);
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00028D0C File Offset: 0x00026F0C
		private Task PrepareLevel(bool seamless)
		{
			Trace.WriteLine(string.Join(" ", new string[]
			{
				"Preparing",
				seamless ? "seamless" : string.Empty,
				"level"
			}));
			LevelPrepareSettings settings = new LevelPrepareSettings
			{
				Act = this._currentAct,
				Seamless = seamless
			};
			this._area.Prepare(this._level, settings);
			if (this.OverrideStartPosition != null)
			{
				this._level.StartPosition = this.OverrideStartPosition.Value;
				this.OverrideStartPosition = null;
			}
			return this._level.LoadAsync(this._area, default(CancellationToken));
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x00028DD0 File Offset: 0x00026FD0
		private void LoadingUpdate()
		{
			if (this._area == null)
			{
				if (this._loadingAreaTask == null)
				{
					this._loadingAreaTask = this.LoadArea(default(CancellationToken));
					return;
				}
			}
			else
			{
				this._loadingAreaTask = null;
				if (this._preparingLevelTask == null)
				{
					this._preparingLevelTask = this.PrepareLevel(this._seamless);
					return;
				}
				if (this._preparingLevelTask.IsCompleted)
				{
					this._preparingLevelTask = null;
					this._state = (this._networkPlay ? LevelScreen.LevelScreenState.NetworkWaitingForStart : LevelScreen.LevelScreenState.ReadyToPlay);
				}
			}
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x00028E4B File Offset: 0x0002704B
		private void LoadingDraw(Renderer renderer)
		{
			Area area = this._area;
			renderer.GetFontRenderer();
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x00028E5B File Offset: 0x0002705B
		private void UnloadLevel()
		{
			this._level.Unload();
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00028E68 File Offset: 0x00027068
		private void PlayingUpdate()
		{
			if (this._state == LevelScreen.LevelScreenState.ReadyToPlay)
			{
				if (!this._seamless)
				{
					this._level.Start();
				}
				else
				{
					this._seamless = false;
					this._level.Start();
				}
				this._state = LevelScreen.LevelScreenState.Playing;
			}
			if (this._state == LevelScreen.LevelScreenState.Playing)
			{
				LevelState state = this._level.State;
				if (state != LevelState.Dead)
				{
					if (state == LevelState.StageCompleted)
					{
						if (this._level.CurrentAct == 1)
						{
							this._currentAct = 2;
							this._level.Time = 0;
							this._player.StarpostIndex = -1;
							this._seamless = true;
							this._state = LevelScreen.LevelScreenState.Loading;
						}
						else
						{
							this._level.FadeOut(LevelState.StageCompleted);
							this._state = LevelScreen.LevelScreenState.FadingOut;
							this._nextState = LevelScreen.LevelScreenState.ReadyToQuit;
						}
					}
				}
				else
				{
					this._level.FadeOut(LevelState.Dead);
					this._state = LevelScreen.LevelScreenState.FadingOut;
					this._nextState = LevelScreen.LevelScreenState.Dead;
				}
			}
			if (this._networkPlay)
			{
				this.NetworkPlayUpdate();
			}
			if (!this._level.StateFlags.HasFlag(LevelStateFlags.Editing))
			{
				this._area.OnUpdate();
			}
			this._level.Update();
			this._level.Animate();
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00028F91 File Offset: 0x00027191
		private void PlayingDraw(Renderer renderer)
		{
			this._level.Draw(renderer);
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00028FA0 File Offset: 0x000271A0
		private void EstablishNetworkUpdate()
		{
			if (this._hosting)
			{
				if (this._server.NetworkPlayers.Count > 0)
				{
					this._server.AllowClientsToConnect = false;
					this._state = LevelScreen.LevelScreenState.Loading;
					return;
				}
			}
			else if (this._joiningServer.IsCompleted)
			{
				if (this._joiningServer.IsFaulted)
				{
					throw this._joiningServer.Exception.InnerException;
				}
				if (this._client.Connected)
				{
					this._state = LevelScreen.LevelScreenState.Loading;
				}
			}
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x0002901C File Offset: 0x0002721C
		private void EstablishNetworkDraw(Renderer renderer)
		{
			string text = this._hosting ? "WAITING FOR CLIENT TO CONNECT..." : "CONNECTING TO SERVER...";
			renderer.GetFontRenderer().RenderStringWithShadow(text, new Rectangle(8.0, 8.0, 0.0, 0.0), FontAlignment.Left, this._font, 0);
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x0002907C File Offset: 0x0002727C
		private void NetworkWaitingUpdate()
		{
			if (this._hosting)
			{
				this._server.Update();
				if (this._server.NetworkPlayers.All((NetworkPlayer x) => x.Ready))
				{
					this._server.SendPacketToAllClients(new NotifyPacket(PacketType.ReadyToStartLevel));
					this._state = LevelScreen.LevelScreenState.ReadyToPlay;
					return;
				}
			}
			else
			{
				this._client.Update();
				if (this._client.Ready)
				{
					this._state = LevelScreen.LevelScreenState.ReadyToPlay;
					return;
				}
				if (Environment.TickCount > this._lastNotificationTickCount + 3000)
				{
					this._client.SendPacket(new NotifyPacket(PacketType.ReadyToStartLevel));
					this._lastNotificationTickCount = Environment.TickCount;
				}
			}
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x00029138 File Offset: 0x00027338
		private void NetworkWaitingDraw(Renderer renderer)
		{
			renderer.GetFontRenderer().RenderStringWithShadow("WAITING FOR OTHER PLAYERS TO LOAD GAME...", new Rectangle(8.0, 8.0, 0.0, 0.0), FontAlignment.Left, this._font, 0);
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x00029188 File Offset: 0x00027388
		private bool NetworkSetupCheck()
		{
			IReadOnlyList<string> commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs.Count > 1)
			{
				string a = commandLineArgs[0].ToLower();
				if (a == "host")
				{
					this._server = new NetworkGameServer(this._level, 7237);
					this._networkPlay = true;
					this._hosting = true;
					return true;
				}
				if (a == "join")
				{
					this._client = new NetworkGameClient(this._level);
					this._joiningServer = this._client.InitiateHandshake(commandLineArgs[2], 7237, 5000);
					this._networkPlay = true;
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x00029234 File Offset: 0x00027434
		private void NetworkPlayUpdate()
		{
			if (!this._hosting)
			{
				this._client.Update();
				return;
			}
			this._server.Update();
			int characterId = 1;
			if (this._inputDirection == this._gameContext.Current[0].DirectionLeft && this._inputAction == this._gameContext.Current[0].Action1)
			{
				return;
			}
			this._inputDirection = this._gameContext.Current[0].DirectionLeft;
			this._inputAction = this._gameContext.Current[0].Action1;
			PlayInputPacket packet = new PlayInputPacket(characterId, this._inputDirection, this._inputAction);
			this._server.SendPacketToAllClients(packet);
		}

		// Token: 0x04000611 RID: 1553
		public const int DefaultPort = 7237;

		// Token: 0x04000612 RID: 1554
		private const string FontResourceKey = "SONICORCA/FONTS/HUD";

		// Token: 0x04000613 RID: 1555
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x04000614 RID: 1556
		private readonly ResourceSession _resourceSession;

		// Token: 0x04000615 RID: 1557
		private Player _player;

		// Token: 0x04000616 RID: 1558
		private Area _area;

		// Token: 0x04000617 RID: 1559
		private Level _level;

		// Token: 0x04000618 RID: 1560
		private LevelScreen.LevelScreenState _state;

		// Token: 0x04000619 RID: 1561
		private LevelScreen.LevelScreenState _nextState;

		// Token: 0x0400061A RID: 1562
		private int _currentAct = 1;

		// Token: 0x0400061B RID: 1563
		private bool _seamless;

		// Token: 0x0400061D RID: 1565
		private string _areaResourceKey = "SONICORCA/S2/LEVELS/EHZ/AREA";

		// Token: 0x0400061E RID: 1566
		private Font _font;

		// Token: 0x0400061F RID: 1567
		private Task _loadingAreaTask;

		// Token: 0x04000620 RID: 1568
		private Task _preparingLevelTask;

		// Token: 0x04000621 RID: 1569
		private bool _networkPlay;

		// Token: 0x04000622 RID: 1570
		private bool _hosting;

		// Token: 0x04000623 RID: 1571
		private NetworkGameServer _server;

		// Token: 0x04000624 RID: 1572
		private NetworkGameClient _client;

		// Token: 0x04000625 RID: 1573
		private Task _joiningServer;

		// Token: 0x04000626 RID: 1574
		private int _lastNotificationTickCount;

		// Token: 0x04000627 RID: 1575
		private Vector2 _inputDirection;

		// Token: 0x04000628 RID: 1576
		private bool _inputAction;

		// Token: 0x020001F6 RID: 502
		private enum LevelScreenState
		{
			// Token: 0x04000B5A RID: 2906
			Initialise,
			// Token: 0x04000B5B RID: 2907
			Loading,
			// Token: 0x04000B5C RID: 2908
			ReadyToQuit,
			// Token: 0x04000B5D RID: 2909
			ReadyToPlay,
			// Token: 0x04000B5E RID: 2910
			Playing,
			// Token: 0x04000B5F RID: 2911
			EstablishingNetworkPlay,
			// Token: 0x04000B60 RID: 2912
			NetworkWaitingForStart,
			// Token: 0x04000B61 RID: 2913
			FadingOut,
			// Token: 0x04000B62 RID: 2914
			Dead
		}
	}
}
