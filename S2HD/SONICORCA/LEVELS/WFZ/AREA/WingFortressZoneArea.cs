using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.WFZ.AREA
{
	// Token: 0x0200000D RID: 13
	public class WingFortressZoneArea : Area
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00005546 File Offset: 0x00003746
		public WingFortressZoneArea() : base(WingFortressZoneArea.AreaDependencies)
		{
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00005554 File Offset: 0x00003754
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Wing Fortress";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/WFZ";
			if (!settings.Seamless)
			{
				this._level.TileSet = this._resourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._resourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._resourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
			}
			this._level.Bounds = this._level.Map.Bounds;
		}

		// Token: 0x0400006D RID: 109
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x0400006E RID: 110
		private const string MapResourceKey = "//MAP";

		// Token: 0x0400006F RID: 111
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000070 RID: 112
		private const string LevelMusicResourceKey = "SONICORCA/MUSIC/LEVELS/WFZ";

		// Token: 0x04000071 RID: 113
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/MUSIC/LEVELS/WFZ"
		}.ToArray<string>();

		// Token: 0x04000072 RID: 114
		private SonicOrcaGameContext _gameContext;

		// Token: 0x04000073 RID: 115
		private ResourceTree _resourceTree;

		// Token: 0x04000074 RID: 116
		private Level _level;
	}
}
