using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.MTZ.AREA
{
	// Token: 0x0200000E RID: 14
	public class MetropolisZoneArea : Area
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00005672 File Offset: 0x00003872
		public MetropolisZoneArea() : base(MetropolisZoneArea.AreaDependencies)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005680 File Offset: 0x00003880
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Metropolis";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/MTZ";
			if (!settings.Seamless)
			{
				this._level.TileSet = this._resourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._resourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._resourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
			}
			this._level.Bounds = this._level.Map.Bounds;
		}

		// Token: 0x04000075 RID: 117
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x04000076 RID: 118
		private const string MapResourceKey = "//MAP";

		// Token: 0x04000077 RID: 119
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000078 RID: 120
		private const string LevelMusicResourceKey = "SONICORCA/MUSIC/LEVELS/MTZ";

		// Token: 0x04000079 RID: 121
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/MUSIC/LEVELS/MTZ"
		}.ToArray<string>();

		// Token: 0x0400007A RID: 122
		private SonicOrcaGameContext _gameContext;

		// Token: 0x0400007B RID: 123
		private ResourceTree _resourceTree;

		// Token: 0x0400007C RID: 124
		private Level _level;
	}
}
