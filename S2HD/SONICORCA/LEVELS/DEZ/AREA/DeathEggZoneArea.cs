using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.DEZ.AREA
{
	// Token: 0x0200000F RID: 15
	public class DeathEggZoneArea : Area
	{
		// Token: 0x06000062 RID: 98 RVA: 0x0000579E File Offset: 0x0000399E
		public DeathEggZoneArea() : base(DeathEggZoneArea.AreaDependencies)
		{
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000057AC File Offset: 0x000039AC
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Death Egg";
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

		// Token: 0x0400007D RID: 125
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x0400007E RID: 126
		private const string MapResourceKey = "//MAP";

		// Token: 0x0400007F RID: 127
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000080 RID: 128
		private const string LevelMusicResourceKey = "SONICORCA/MUSIC/LEVELS/DEZ";

		// Token: 0x04000081 RID: 129
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING"
		}.ToArray<string>();

		// Token: 0x04000082 RID: 130
		private SonicOrcaGameContext _gameContext;

		// Token: 0x04000083 RID: 131
		private ResourceTree _resourceTree;

		// Token: 0x04000084 RID: 132
		private Level _level;
	}
}
