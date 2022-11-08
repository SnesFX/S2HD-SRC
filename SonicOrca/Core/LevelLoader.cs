using System;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000114 RID: 276
	public class LevelLoader
	{
		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000A43 RID: 2627 RVA: 0x000285FD File Offset: 0x000267FD
		public Area Area
		{
			get
			{
				return this._area;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000A44 RID: 2628 RVA: 0x00028605 File Offset: 0x00026805
		public Level Level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0002860D File Offset: 0x0002680D
		public LevelLoader(SonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._resourceSession = new ResourceSession(gameContext.ResourceTree);
			this._level = new Level(gameContext);
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x0002863C File Offset: 0x0002683C
		public void LoadArea(LevelPrepareSettings prepareSettings)
		{
			if (this._area != null)
			{
				throw new InvalidOperationException("Area is already loaded.");
			}
			if (this._loadingArea)
			{
				throw new InvalidOperationException("Area is already loading.");
			}
			this._loadTask = this.LoadAreaAsync(prepareSettings, default(CancellationToken));
			this._loadingArea = true;
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0002868C File Offset: 0x0002688C
		public void LoadLevel()
		{
			if (this._area == null)
			{
				throw new InvalidOperationException("Area is not loaded.");
			}
			if (this._loadingArea)
			{
				throw new InvalidOperationException("Area is currently loading.");
			}
			if (this._loadingLevel)
			{
				throw new InvalidOperationException("Level is already loading.");
			}
			this._loadTask = this.LoadLevelAsync(default(CancellationToken));
			this._loadingLevel = true;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x000286F0 File Offset: 0x000268F0
		public void UnloadLevel()
		{
			if (!this._levelLoaded)
			{
				throw new InvalidOperationException("Level is not loaded.");
			}
			if (this._loadingArea || this._loadingLevel)
			{
				throw new InvalidOperationException("Can't unload while an area or level is being loaded.");
			}
			this._level.Stop();
			this._level.Unload();
			this._levelLoaded = false;
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00028748 File Offset: 0x00026948
		public void UnloadArea()
		{
			if (this._area == null)
			{
				throw new InvalidOperationException("Area is not loaded.");
			}
			if (this._levelLoaded)
			{
				throw new InvalidOperationException("Can't unload area until level is unloaded.");
			}
			if (this._loadingArea || this._loadingLevel)
			{
				throw new InvalidOperationException("Can't unload while an area or level is being loaded.");
			}
			this._area.Dispose();
			this._area = null;
			this._resourceSession.Unload();
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x000287B4 File Offset: 0x000269B4
		private async Task LoadAreaAsync(LevelPrepareSettings prepareSettings, CancellationToken ct = default(CancellationToken))
		{
			this._resourceSession.PushDependency(prepareSettings.AreaResourceKey);
			await this._resourceSession.LoadAsync(ct, false);
			this._area = this._gameContext.ResourceTree.GetLoadedResource<Area>(prepareSettings.AreaResourceKey);
			this._level.PrepareSettings = prepareSettings;
			await this._level.LoadCommonAsync(ct);
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0002880C File Offset: 0x00026A0C
		private async Task LoadLevelAsync(CancellationToken ct = default(CancellationToken))
		{
			this._area.Prepare(this._level, this._level.PrepareSettings);
			await this._level.LoadAsync(this._area, ct);
			this._levelLoaded = true;
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000A4C RID: 2636 RVA: 0x0002885C File Offset: 0x00026A5C
		public bool HasLoadedArea
		{
			get
			{
				if (!this._loadingArea)
				{
					return this._area != null;
				}
				if (!this._loadTask.IsCompleted)
				{
					return false;
				}
				if (this._loadTask.IsFaulted)
				{
					throw this._loadTask.Exception.InnerException;
				}
				this._loadingArea = false;
				return false;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000A4D RID: 2637 RVA: 0x000288B0 File Offset: 0x00026AB0
		public bool HasLoadedLevel
		{
			get
			{
				if (!this._loadingLevel)
				{
					return this._levelLoaded;
				}
				if (!this._loadTask.IsCompleted)
				{
					return false;
				}
				if (this._loadTask.IsFaulted)
				{
					throw this._loadTask.Exception.InnerException;
				}
				this._loadingLevel = false;
				return false;
			}
		}

		// Token: 0x04000604 RID: 1540
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x04000605 RID: 1541
		private Task _loadTask;

		// Token: 0x04000606 RID: 1542
		private ResourceSession _resourceSession;

		// Token: 0x04000607 RID: 1543
		private Area _area;

		// Token: 0x04000608 RID: 1544
		private readonly Level _level;

		// Token: 0x04000609 RID: 1545
		private bool _loadingArea;

		// Token: 0x0400060A RID: 1546
		private bool _loadingLevel;

		// Token: 0x0400060B RID: 1547
		private bool _levelLoaded;
	}
}
