using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.OOZ.AREA
{
	// Token: 0x0200000B RID: 11
	public class OilOceanZoneArea : Area
	{
		// Token: 0x06000056 RID: 86 RVA: 0x000052EE File Offset: 0x000034EE
		public OilOceanZoneArea() : base(OilOceanZoneArea.AreaDependencies)
		{
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000052FC File Offset: 0x000034FC
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Oil Ocean";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/OOZ";
			if (!settings.Seamless)
			{
				this._level.TileSet = this._resourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._resourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._resourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
			}
			this._level.Bounds = this._level.Map.Bounds;
		}

		// Token: 0x0400005D RID: 93
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x0400005E RID: 94
		private const string MapResourceKey = "//MAP";

		// Token: 0x0400005F RID: 95
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000060 RID: 96
		private const string LevelMusicResourceKey = "SONICORCA/MUSIC/LEVELS/OOZ";

		// Token: 0x04000061 RID: 97
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/MUSIC/LEVELS/OOZ"
		}.ToArray<string>();

		// Token: 0x04000062 RID: 98
		private SonicOrcaGameContext _gameContext;

		// Token: 0x04000063 RID: 99
		private ResourceTree _resourceTree;

		// Token: 0x04000064 RID: 100
		private Level _level;
	}
}
