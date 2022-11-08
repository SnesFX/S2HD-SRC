using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core.Network;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x02000134 RID: 308
	public class LevelGameState : IGameState, IDisposable
	{
		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000C11 RID: 3089 RVA: 0x0002F10C File Offset: 0x0002D30C
		// (set) Token: 0x06000C12 RID: 3090 RVA: 0x0002F114 File Offset: 0x0002D314
		public LevelPrepareSettings PrepareSettings { get; set; }

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000C13 RID: 3091 RVA: 0x0002F11D File Offset: 0x0002D31D
		// (set) Token: 0x06000C14 RID: 3092 RVA: 0x0002F125 File Offset: 0x0002D325
		public bool Completed { get; set; }

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000C15 RID: 3093 RVA: 0x0002F12E File Offset: 0x0002D32E
		public Player Player
		{
			get
			{
				return this._player;
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x0002F136 File Offset: 0x0002D336
		public Level Level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x0002F13E File Offset: 0x0002D33E
		public LevelGameState(SonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._levelLoader = new LevelLoader(gameContext);
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x0002F159 File Offset: 0x0002D359
		public void Dispose()
		{
			if (this._levelLoader.HasLoadedLevel)
			{
				this._levelLoader.UnloadLevel();
			}
			if (this._levelLoader.HasLoadedArea)
			{
				this._levelLoader.UnloadArea();
			}
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x0002F18B File Offset: 0x0002D38B
		public IEnumerable<UpdateResult> Update()
		{
			if (this.PrepareSettings == null)
			{
				throw new InvalidOperationException("Prepare settings was not specified.");
			}
			this._levelLoader.LoadArea(this.PrepareSettings);
			while (!this._levelLoader.HasLoadedArea)
			{
				yield return UpdateResult.Next();
			}
			this._area = this._levelLoader.Area;
			this._level = this._levelLoader.Level;
			this._player = this._level.Player;
			this._player.Lives = this.PrepareSettings.Lives;
			this._player.Score = this.PrepareSettings.Score;
			this._levelLoader.LoadLevel();
			for (;;)
			{
				if (this._levelLoader.HasLoadedLevel)
				{
					switch (this._level.State)
					{
					case LevelState.Null:
						if (!this.IsWaitingForNetworkPlayers())
						{
							this.StartLevel();
						}
						break;
					case LevelState.Playing:
						this.OnLevelUpdate();
						break;
					case LevelState.Dead:
						this.OnPlayerDeath();
						break;
					case LevelState.StageCompleted:
						this.OnStageComplete();
						break;
					case LevelState.Restart:
					case LevelState.RestartCheckpoint:
						this.OnPlayerRestart();
						break;
					case LevelState.Quit:
						this._finished = true;
						break;
					}
					yield return UpdateResult.Next();
					if (this._finished)
					{
						break;
					}
				}
				else
				{
					yield return UpdateResult.Next();
				}
			}
			yield break;
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x0002F19B File Offset: 0x0002D39B
		public void HandleInput()
		{
			if (this._level != null && this._level.State == LevelState.Playing)
			{
				this._level.HandleInput();
			}
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x0002F1BE File Offset: 0x0002D3BE
		public void Draw()
		{
			if (this._draw)
			{
				this._level.Draw(this._gameContext.Renderer);
			}
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0002F1E0 File Offset: 0x0002D3E0
		private void StartLevel()
		{
			this._level.SeamlessAct = (this._level.CurrentAct == 1 && !this.PrepareSettings.TimeTrial);
			if (this.PrepareSettings.TimeTrial)
			{
				this._level.Player.Lives = -1;
			}
			this._level.Start();
			this._draw = true;
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0002F248 File Offset: 0x0002D448
		private void OnLevelUpdate()
		{
			this.NetworkPlayUpdate();
			LevelStateFlags stateFlags = this._level.StateFlags;
			if (stateFlags.HasFlag(LevelStateFlags.Paused))
			{
				if (!this._areaPaused)
				{
					this._areaPaused = true;
					this._area.OnPause();
				}
			}
			else
			{
				if (this._areaPaused)
				{
					this._areaPaused = false;
					this._area.OnUnpause();
				}
				this._area.OnUpdate();
			}
			this._level.Update();
			this._level.Animate();
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x0002F2D8 File Offset: 0x0002D4D8
		private void OnPlayerDeath()
		{
			if (this._level.PlayRecorder != null)
			{
				if (this._level.PlayRecorder.Recording)
				{
					this.PrepareSettings.RecordedPlayWritePath = null;
				}
				if (this._level.PlayRecorder.Playing)
				{
					if (!string.IsNullOrEmpty(this.PrepareSettings.RecordedPlayReadPath))
					{
						this._finished = true;
						return;
					}
					if (!this.PrepareSettings.TimeTrial && this._level.Player.StarpostIndex != -1)
					{
						this.PrepareSettings.RecordedPlayGhostReadPath = null;
					}
				}
			}
			this._draw = false;
			this._level.State = LevelState.Null;
			this._levelLoader.UnloadLevel();
			this.PrepareSettings.Seamless = false;
			if (this.PrepareSettings.TimeTrial)
			{
				this._level.Time = 0;
				this._level.RingsCollected = 0;
				this._level.Player.StarpostIndex = -1;
			}
			else if (this._level.Player.Lives == 0)
			{
				this._finished = true;
				return;
			}
			this._levelLoader.LoadLevel();
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x0002F3F0 File Offset: 0x0002D5F0
		private void OnPlayerRestart()
		{
			bool flag = this._level.State == LevelState.RestartCheckpoint;
			if (this._level.PlayRecorder != null)
			{
				if (this._level.PlayRecorder.Recording)
				{
					this.PrepareSettings.RecordedPlayWritePath = null;
				}
				if (this._level.PlayRecorder.Playing)
				{
					if (!string.IsNullOrEmpty(this.PrepareSettings.RecordedPlayReadPath))
					{
						this._finished = true;
						return;
					}
					if (!this.PrepareSettings.TimeTrial && this._level.Player.StarpostIndex != -1)
					{
						this.PrepareSettings.RecordedPlayGhostReadPath = null;
					}
				}
			}
			this._draw = false;
			this._level.State = LevelState.Null;
			this._levelLoader.UnloadLevel();
			this.PrepareSettings.Seamless = false;
			if (this.PrepareSettings.TimeTrial || !flag)
			{
				this._level.Time = 0;
				this._level.RingsCollected = 0;
				this._level.Player.StarpostIndex = -1;
			}
			else if (this._level.Player.Lives == 0)
			{
				this._finished = true;
				return;
			}
			this._levelLoader.LoadLevel();
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x0002F51C File Offset: 0x0002D71C
		private void OnStageComplete()
		{
			this._level.State = LevelState.Null;
			if (this.PrepareSettings.TimeTrial)
			{
				this._draw = false;
				this.Completed = true;
				this._finished = true;
				return;
			}
			if (this._level.CurrentAct == 1)
			{
				this._level.Time = 0;
				this._level.RingsCollected = 0;
				this._level.Player.StarpostIndex = -1;
				LevelPrepareSettings prepareSettings = this.PrepareSettings;
				int act = prepareSettings.Act;
				prepareSettings.Act = act + 1;
				this.PrepareSettings.Seamless = true;
				this._levelLoader.LoadLevel();
				return;
			}
			this._draw = false;
			this._finished = true;
			this.Completed = true;
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0002F5D4 File Offset: 0x0002D7D4
		private bool IsWaitingForNetworkPlayers()
		{
			bool result = true;
			NetworkManager networkManager = this._gameContext.NetworkManager;
			if (networkManager.NetworkPlay)
			{
				if (networkManager.Hosting)
				{
					networkManager.Server.Level = this._level;
					if (networkManager.Server.NetworkPlayers.All((NetworkPlayer x) => x.Ready))
					{
						networkManager.Server.SendPacketToAllClients(new NotifyPacket(PacketType.ReadyToStartLevel));
						result = false;
					}
				}
				else
				{
					networkManager.Client.Level = this._level;
					if (networkManager.Client.Ready)
					{
						result = false;
					}
					else if (Environment.TickCount > this._lastNotificationTickCount + 3000)
					{
						networkManager.Client.SendPacket(new NotifyPacket(PacketType.ReadyToStartLevel));
						this._lastNotificationTickCount = Environment.TickCount;
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x0002F6B0 File Offset: 0x0002D8B0
		private void NetworkPlayUpdate()
		{
			NetworkManager networkManager = this._gameContext.NetworkManager;
			if (networkManager.Hosting)
			{
				int characterId = 1;
				if (this._inputDirection == this._gameContext.Current[0].DirectionLeft && this._inputAction == this._gameContext.Current[0].Action1)
				{
					return;
				}
				this._inputDirection = this._gameContext.Current[0].DirectionLeft;
				this._inputAction = this._gameContext.Current[0].Action1;
				PlayInputPacket packet = new PlayInputPacket(characterId, this._inputDirection, this._inputAction);
				networkManager.Server.SendPacketToAllClients(packet);
			}
		}

		// Token: 0x040006FE RID: 1790
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040006FF RID: 1791
		private readonly LevelLoader _levelLoader;

		// Token: 0x04000700 RID: 1792
		private Area _area;

		// Token: 0x04000701 RID: 1793
		private Level _level;

		// Token: 0x04000702 RID: 1794
		private Player _player;

		// Token: 0x04000703 RID: 1795
		private bool _draw;

		// Token: 0x04000704 RID: 1796
		private bool _finished;

		// Token: 0x04000705 RID: 1797
		private bool _areaPaused;

		// Token: 0x04000708 RID: 1800
		private int _lastNotificationTickCount;

		// Token: 0x04000709 RID: 1801
		private Vector2 _inputDirection;

		// Token: 0x0400070A RID: 1802
		private bool _inputAction;
	}
}
