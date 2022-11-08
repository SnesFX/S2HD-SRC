using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SONICORCA.LEVELS.CPZ.AREA
{
	// Token: 0x02000008 RID: 8
	public class ChemicalPlantZoneArea : Area
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00004683 File Offset: 0x00002883
		public ChemicalPlantZoneArea() : base(ChemicalPlantZoneArea.AreaDependencies)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00004690 File Offset: 0x00002890
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._resourceTree = this._gameContext.ResourceTree;
			this._level = level;
			this._level.Name = "Chemical Plant";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.AnimalResourceKeys = (from x in ChemicalPlantZoneArea.AnimalResourceKeys
			select this.GetAbsolutePath(x)).ToArray<string>();
			if (!settings.Seamless)
			{
				this._level.TileSet = this._resourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._resourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._resourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
			}
			if (settings.Act == 1)
			{
				this.PrepareAct1();
			}
			else if (settings.Act == 2)
			{
				if (settings.Seamless)
				{
					this.SeamlessPrepareAct2();
				}
				else
				{
					this.PrepareAct2();
				}
			}
			settings.StartPath = 1;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000047B0 File Offset: 0x000029B0
		private void PrepareAct1()
		{
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/CPZ/ACT1";
			this._level.CurrentAct = 1;
			this._level.SetStartPosition("startpos_stk_1");
			this._level.Bounds = this.GetAct1Bounds();
			this._level.RingsPerfectTarget = this._level.ObjectManager.ObjectEntryTable.GetRingCountInRegion(this._level.Bounds);
			this._level.SoundManager.SetJingle(JingleType.SpeedShoes, "SONICORCA/MUSIC/LEVELS/CPZ/ACT1/FAST");
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000483C File Offset: 0x00002A3C
		private void PrepareAct2()
		{
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/CPZ/ACT2";
			this._level.CurrentAct = 2;
			this._level.SetStartPosition("startpos_stk_2");
			Rectanglei act2Bounds = this.GetAct2Bounds();
			act2Bounds.Right = this._level.GetMarker("boss_right").Position.X;
			this._level.Bounds = act2Bounds;
			this._level.RingsPerfectTarget = this._level.ObjectManager.ObjectEntryTable.GetRingCountInRegion(act2Bounds);
			this._state = 0;
			this._bossDefeated = false;
			this.InitialiseWater();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000048E4 File Offset: 0x00002AE4
		private void SeamlessPrepareAct2()
		{
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/CPZ/ACT2";
			this._level.CurrentAct = 2;
			Rectanglei act2Bounds = this.GetAct2Bounds();
			act2Bounds.Right = this._level.GetMarker("boss_right").Position.X;
			this._level.RingsPerfectTarget = this._level.ObjectManager.ObjectEntryTable.GetRingCountInRegion(act2Bounds);
			base.ExtendSeamlessLevelBounds(this._level, act2Bounds);
			this._state = 0;
			this._bossDefeated = false;
			this.InitialiseWater();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000497C File Offset: 0x00002B7C
		private void InitialiseWater()
		{
			this._waterHeightOscillation = 0;
			Rectanglei bounds = this._level.Map.Bounds;
			Rectanglei item = Rectanglei.FromLTRB(bounds.Left, 10304, bounds.Right, bounds.Bottom);
			if (this._level.GetPlayerStartPosition().X - 960 >= 71936)
			{
				this._waterHeight = 8256;
				this._waterRaised = true;
			}
			else
			{
				this._waterHeight = 10304;
				this._waterRaised = false;
			}
			item.Top = 8256;
			this._level.WaterManager.Enabled = true;
			this._level.WaterManager.WaterAreas.Clear();
			this._level.WaterManager.WaterAreas.Add(item);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00004A50 File Offset: 0x00002C50
		private void UpdateWater()
		{
			Rectanglei value = this._level.WaterManager.WaterAreas[0];
			int num = value.Top;
			if (!this._waterRaised && this._level.Camera.Bounds.Left >= 71936.0)
			{
				this._waterRaised = true;
				this._waterHeight = num;
				this._waterHeightOscillation = 0;
			}
			int num2 = this._waterRaised ? 8256 : 10304;
			if (this._waterHeight == num2)
			{
				this._waterHeightOscillation++;
				double num3 = (double)this._waterHeightOscillation / 252.0;
				int waterHeight = this._waterHeight;
				double num4 = (1.0 - Math.Cos(num3 * 6.283185307179586)) / 2.0;
				num = waterHeight + 0;
			}
			else
			{
				this._waterHeight = MathX.GoTowards(this._waterHeight, num2, 4);
				num = this._waterHeight;
			}
			value.Top = num;
			this._level.WaterManager.WaterAreas[0] = value;
			this._level.WaterManager.HueTarget = 0.3;
			this._level.WaterManager.HueAmount = 0.8;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004B98 File Offset: 0x00002D98
		public override void OnUpdate()
		{
			if (!this._level.StateFlags.HasFlag(LevelStateFlags.Updating))
			{
				return;
			}
			if (this._level.CurrentAct != 2)
			{
				return;
			}
			this.UpdateWater();
			Rectangle r = this._level.Bounds;
			Rectanglei rectanglei = this._level.Camera.Bounds;
			switch (this._state)
			{
			case 0:
			{
				int x = this._level.GetMarker("boss_oneway").Position.X;
				int y = this._level.GetMarker("boss_bottom").Position.Y;
				if (rectanglei.Left >= x)
				{
					Rectanglei newBounds = r;
					newBounds.Left = x;
					newBounds.Bottom = y;
					this._level.ScrollBoundsTo(newBounds, 2);
					this._state++;
					return;
				}
				break;
			}
			case 1:
			{
				int x2 = this._level.GetMarker("boss_left").Position.X;
				if (!this._level.IsScrollingBounds && rectanglei.Left >= x2)
				{
					this._level.Bounds = this.GetBossBounds();
					this._level.SoundManager.CrossFadeMusic(this.GetAbsolutePath("SONICORCA/MUSIC/BOSS/S2"));
					this._stateTimer = 90;
					this._state++;
					return;
				}
				break;
			}
			case 2:
				this._stateTimer--;
				if (this._stateTimer <= 0)
				{
					this.SpawnBoss();
					this._state++;
					return;
				}
				break;
			case 3:
				if (!this._bossDefeated && this._bossObject.Defeated)
				{
					this._bossDefeated = true;
					this._level.SoundManager.PlayMusic(this.GetAbsolutePath("SONICORCA/MUSIC/LEVELS/CPZ/ACT2"));
				}
				if (this._bossObject.Fleeing)
				{
					this._state++;
					return;
				}
				break;
			case 4:
			{
				Rectangle r2 = this._level.Bounds;
				r2.Right = Math.Min(r2.Right + 8.0, (double)this.GetAct2Bounds().Right);
				r2.Left = Math.Max(r2.Left, this._level.Camera.Bounds.Left);
				this._level.Bounds = r2;
				if (this._level.StateFlags.HasFlag(LevelStateFlags.StageCompleted))
				{
					this._level.FadeOut(LevelState.StageCompleted);
					this._state++;
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004E64 File Offset: 0x00003064
		private void SpawnBoss()
		{
			LevelMarker marker = this._level.GetMarker("boss_position");
			LevelMarker marker2 = this._level.GetMarker("boss_fill_left");
			LevelMarker marker3 = this._level.GetMarker("boss_fill_right");
			var state = new
			{
				LeftFillX = marker2.Position.X,
				RightFillX = marker3.Position.X
			};
			this._bossObject = (this._level.ObjectManager.AddObject(new ObjectPlacement(this.GetAbsolutePath("SONICORCA/OBJECTS/WATEREGGMAN"), this._level.Map.Layers.IndexOf(marker.Layer), marker.Position, state)) as BossObject);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004F14 File Offset: 0x00003114
		private Rectanglei GetAct1Bounds()
		{
			return Rectanglei.FromLTRB(0, 0, this._level.GetMarker("bounds_1_r").Position.X, 8192);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004F4C File Offset: 0x0000314C
		private Rectanglei GetAct2Bounds()
		{
			return Rectanglei.FromLTRB(this._level.GetMarker("bounds_2_l").Position.X, 3072, this._level.Map.Bounds.Width, this._level.Map.Bounds.Height);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004FB0 File Offset: 0x000031B0
		private Rectanglei GetBossBounds()
		{
			Vector2i position = this._level.GetMarker("boss_left").Position;
			Vector2i position2 = this._level.GetMarker("boss_right").Position;
			Vector2i position3 = this._level.GetMarker("boss_bottom").Position;
			return Rectanglei.FromLTRB(position.X, this._level.Bounds.Top, position2.X, position3.Y);
		}

		// Token: 0x04000039 RID: 57
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x0400003A RID: 58
		private const string MapResourceKey = "//MAP";

		// Token: 0x0400003B RID: 59
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x0400003C RID: 60
		private const string BossObjectResourceKey = "SONICORCA/OBJECTS/WATEREGGMAN";

		// Token: 0x0400003D RID: 61
		private static IReadOnlyList<string> AnimalResourceKeys = new string[]
		{
			"SONICORCA/OBJECTS/LOCKY",
			"SONICORCA/OBJECTS/POCKY"
		};

		// Token: 0x0400003E RID: 62
		private const string Act1MusicResourceKey = "SONICORCA/MUSIC/LEVELS/CPZ/ACT1";

		// Token: 0x0400003F RID: 63
		private const string Act2MusicResourceKey = "SONICORCA/MUSIC/LEVELS/CPZ/ACT2";

		// Token: 0x04000040 RID: 64
		private const string BossMusicResourceKey = "SONICORCA/MUSIC/BOSS/S2";

		// Token: 0x04000041 RID: 65
		private const string Act1FastMusicResourceKey = "SONICORCA/MUSIC/LEVELS/CPZ/ACT1/FAST";

		// Token: 0x04000042 RID: 66
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/MUSIC/LEVELS/CPZ/ACT1",
			"SONICORCA/MUSIC/LEVELS/CPZ/ACT2",
			"SONICORCA/MUSIC/BOSS/S2",
			"SONICORCA/MUSIC/LEVELS/CPZ/ACT1/FAST",
			"SONICORCA/OBJECTS/WATEREGGMAN"
		}.Concat(ChemicalPlantZoneArea.AnimalResourceKeys).ToArray<string>();

		// Token: 0x04000043 RID: 67
		private SonicOrcaGameContext _gameContext;

		// Token: 0x04000044 RID: 68
		private ResourceTree _resourceTree;

		// Token: 0x04000045 RID: 69
		private Level _level;

		// Token: 0x04000046 RID: 70
		private int _state;

		// Token: 0x04000047 RID: 71
		private int _stateTimer;

		// Token: 0x04000048 RID: 72
		private bool _bossDefeated;

		// Token: 0x04000049 RID: 73
		private BossObject _bossObject;

		// Token: 0x0400004A RID: 74
		private bool _waterRaised;

		// Token: 0x0400004B RID: 75
		private int _waterHeight;

		// Token: 0x0400004C RID: 76
		private int _waterHeightOscillation;
	}
}
