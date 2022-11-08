using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.ARZ.AREA
{
	// Token: 0x02000007 RID: 7
	public class AquaticRuinZoneArea : Area
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00004472 File Offset: 0x00002672
		public AquaticRuinZoneArea() : base(AquaticRuinZoneArea.AreaDependencies)
		{
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00004480 File Offset: 0x00002680
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Aquatic Ruin";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/ARZ";
			if (!settings.Seamless)
			{
				this._level.TileSet = this._resourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._resourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._resourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
			}
			if (settings.Act == 1)
			{
				this.PrepareAct1();
				return;
			}
			if (settings.Act == 2)
			{
				if (settings.Seamless)
				{
					this.SeamlessPrepareAct2();
					return;
				}
				this.PrepareAct2();
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004580 File Offset: 0x00002780
		private void PrepareAct1()
		{
			this._level.CurrentAct = 1;
			this._level.SetStartPosition("startpos_stk_1");
			this._level.Bounds = this._level.Map.Bounds;
			this._level.WaterManager.WaterAreas.Add(new Rectanglei(0, 4096, 65536, 4096));
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000045EE File Offset: 0x000027EE
		private void PrepareAct2()
		{
			this._level.CurrentAct = 2;
			this._level.SetStartPosition("startpos_stk_2");
			this._level.Bounds = this._level.Map.Bounds;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004627 File Offset: 0x00002827
		private void SeamlessPrepareAct2()
		{
			this._level.CurrentAct = 2;
			base.ExtendSeamlessLevelBounds(this._level, this._level.Map.Bounds);
		}

		// Token: 0x04000031 RID: 49
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x04000032 RID: 50
		private const string MapResourceKey = "//MAP";

		// Token: 0x04000033 RID: 51
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000034 RID: 52
		private const string LevelMusicResourceKey = "SONICORCA/MUSIC/LEVELS/ARZ";

		// Token: 0x04000035 RID: 53
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/MUSIC/LEVELS/ARZ"
		}.ToArray<string>();

		// Token: 0x04000036 RID: 54
		private SonicOrcaGameContext _gameContext;

		// Token: 0x04000037 RID: 55
		private ResourceTree _resourceTree;

		// Token: 0x04000038 RID: 56
		private Level _level;
	}
}
