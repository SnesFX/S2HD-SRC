using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.CNZ.AREA
{
	// Token: 0x02000009 RID: 9
	public class CasinoNightZoneArea : Area
	{
		// Token: 0x06000050 RID: 80 RVA: 0x000050AE File Offset: 0x000032AE
		public CasinoNightZoneArea() : base(CasinoNightZoneArea.AreaDependencies)
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000050BC File Offset: 0x000032BC
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Casino Night";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			if (!settings.Seamless)
			{
				this._level.TileSet = this._resourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._resourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._resourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
			}
			this._level.Bounds = this._level.Map.Bounds;
		}

		// Token: 0x0400004D RID: 77
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x0400004E RID: 78
		private const string MapResourceKey = "//MAP";

		// Token: 0x0400004F RID: 79
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000050 RID: 80
		private const string LevelMusicResourceKey = "SONICORCA/MUSIC/LEVELS/CNZ/COOPERATIVE";

		// Token: 0x04000051 RID: 81
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING"
		}.ToArray<string>();

		// Token: 0x04000052 RID: 82
		private SonicOrcaGameContext _gameContext;

		// Token: 0x04000053 RID: 83
		private ResourceTree _resourceTree;

		// Token: 0x04000054 RID: 84
		private Level _level;
	}
}
