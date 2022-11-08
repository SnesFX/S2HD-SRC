using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.MCZ.AREA
{
	// Token: 0x0200000A RID: 10
	public class MysticCaveZoneArea : Area
	{
		// Token: 0x06000053 RID: 83 RVA: 0x000051C2 File Offset: 0x000033C2
		public MysticCaveZoneArea() : base(MysticCaveZoneArea.AreaDependencies)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000051D0 File Offset: 0x000033D0
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Mystic Cave";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/MCZ/COOPERATIVE";
			if (!settings.Seamless)
			{
				this._level.TileSet = this._resourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._resourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._resourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
			}
			this._level.Bounds = this._level.Map.Bounds;
		}

		// Token: 0x04000055 RID: 85
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x04000056 RID: 86
		private const string MapResourceKey = "//MAP";

		// Token: 0x04000057 RID: 87
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000058 RID: 88
		private const string LevelMusicResourceKey = "SONICORCA/MUSIC/LEVELS/MCZ/COOPERATIVE";

		// Token: 0x04000059 RID: 89
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/MUSIC/LEVELS/MCZ/COOPERATIVE"
		}.ToArray<string>();

		// Token: 0x0400005A RID: 90
		private SonicOrcaGameContext _gameContext;

		// Token: 0x0400005B RID: 91
		private ResourceTree _resourceTree;

		// Token: 0x0400005C RID: 92
		private Level _level;
	}
}
