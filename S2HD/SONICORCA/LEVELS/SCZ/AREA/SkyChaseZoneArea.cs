using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.SCZ.AREA
{
	// Token: 0x0200000C RID: 12
	public class SkyChaseZoneArea : Area
	{
		// Token: 0x06000059 RID: 89 RVA: 0x0000541A File Offset: 0x0000361A
		public SkyChaseZoneArea() : base(SkyChaseZoneArea.AreaDependencies)
		{
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00005428 File Offset: 0x00003628
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Sky Chase";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/SCZ";
			if (!settings.Seamless)
			{
				this._level.TileSet = this._resourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._resourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._resourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
			}
			this._level.Bounds = this._level.Map.Bounds;
		}

		// Token: 0x04000065 RID: 101
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x04000066 RID: 102
		private const string MapResourceKey = "//MAP";

		// Token: 0x04000067 RID: 103
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000068 RID: 104
		private const string LevelMusicResourceKey = "SONICORCA/MUSIC/LEVELS/SCZ";

		// Token: 0x04000069 RID: 105
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/MUSIC/LEVELS/SCZ"
		}.ToArray<string>();

		// Token: 0x0400006A RID: 106
		private SonicOrcaGameContext _gameContext;

		// Token: 0x0400006B RID: 107
		private ResourceTree _resourceTree;

		// Token: 0x0400006C RID: 108
		private Level _level;
	}
}
