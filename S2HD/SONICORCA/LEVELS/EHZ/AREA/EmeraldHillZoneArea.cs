using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Audio;
using SonicOrca.Core;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;

namespace SONICORCA.LEVELS.EHZ.AREA
{
	// Token: 0x02000005 RID: 5
	public class EmeraldHillZoneArea : Area
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002381 File Offset: 0x00000581
		public override IEnumerable<KeyValuePair<string, object>> StateVariables
		{
			get
			{
				return new KeyValuePair<string, object>[]
				{
					new KeyValuePair<string, object>("STATE", this._state),
					new KeyValuePair<string, object>("BOSS DEFEATED", this._bossDefeated)
				};
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000023C1 File Offset: 0x000005C1
		public EmeraldHillZoneArea() : base(EmeraldHillZoneArea.AreaDependencies)
		{
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023CE File Offset: 0x000005CE
		public override void Dispose()
		{
			SampleInstance waterfallSampleInstance = this._waterfallSampleInstance;
			if (waterfallSampleInstance == null)
			{
				return;
			}
			waterfallSampleInstance.Dispose();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000023E0 File Offset: 0x000005E0
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._level = level;
			this._level.Name = "Emerald Hill";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.AnimalResourceKeys = (from x in EmeraldHillZoneArea.AnimalResourceKeys
			select this.GetAbsolutePath(x)).ToArray<string>();
			if (!settings.Seamless)
			{
				this._level.TileSet = this._gameContext.ResourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._gameContext.ResourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._gameContext.ResourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
				this.PrepareWaterfalls();
			}
			if (settings.Act == 1)
			{
				this.PrepareAct1();
			}
			else if (settings.Act == 2)
			{
				this.PrepareAct2(settings.Seamless);
			}
			settings.StartPath = 0;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000024F8 File Offset: 0x000006F8
		private void PrepareAct1()
		{
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT1";
			this._level.CurrentAct = 1;
			this._level.SetStartPosition("startpos_stk_1");
			this._level.Bounds = this.GetAct1Bounds();
			this._level.RingsPerfectTarget = this._level.ObjectManager.ObjectEntryTable.GetRingCountInRegion(this._level.Bounds);
			this._level.SoundManager.SetJingle(JingleType.SpeedShoes, "SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT1/FAST");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002584 File Offset: 0x00000784
		private void PrepareAct2(bool seamless)
		{
			this._level.SoundManager.SetJingle(JingleType.SpeedShoes, "SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT2/FAST");
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT2";
			this._level.CurrentAct = 2;
			this._level.SetStartPosition("startpos_stk_2");
			Rectanglei act2Bounds = this.GetAct2Bounds();
			act2Bounds.Right = this._level.GetMarker("boss_right").Position.X;
			this._level.RingsPerfectTarget = this._level.ObjectManager.ObjectEntryTable.GetRingCountInRegion(act2Bounds);
			if (seamless)
			{
				base.ExtendSeamlessLevelBounds(this._level, act2Bounds);
			}
			else
			{
				this._level.Bounds = act2Bounds;
			}
			this._state = 0;
			this._bossDefeated = false;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000264C File Offset: 0x0000084C
		private void PrepareWaterfalls()
		{
			SampleInfo loadedResource = this._gameContext.ResourceTree.GetLoadedResource<SampleInfo>("SONICORCA/SOUND/WATERFALL");
			this._waterfallSampleInstance = new SampleInstance(this._gameContext, loadedResource);
			this._waterfallRects = this.GetWaterfalls(this._level.Map.Layers[10]).AsArray<Rectanglei>();
			this._level.Map.Layers[8].WaterfallEffects = this._waterfallRects;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000026CC File Offset: 0x000008CC
		private void UpdateWaterfallSounds()
		{
			Vector2i vector2i = (Vector2i)this._level.Camera.Bounds.Centre;
			Rectanglei rectanglei = default(Rectanglei);
			int num = int.MaxValue;
			foreach (Rectanglei rectanglei2 in this._waterfallRects)
			{
				int num2 = vector2i.X - rectanglei2.Centre.X * 64;
				if (Math.Abs(num2) < Math.Abs(num))
				{
					num = num2;
					rectanglei = rectanglei2;
				}
			}
			int val = Math.Abs(vector2i.Y - rectanglei.Top * 64);
			int val2 = Math.Abs(vector2i.Y - rectanglei.Bottom * 64);
			int num3 = Math.Min(val, val2);
			if (!this._level.StateFlags.HasFlag(LevelStateFlags.Paused) && !this._level.Player.Protagonist.IsDead && Math.Abs(num) < 1000 && num3 < 1400)
			{
				double val3 = 1.0 - (double)Math.Abs(num) / 1000.0;
				double val4 = 1.0 - (double)num3 / 1400.0;
				this._waterfallSampleInstance.Volume = 0.75 * Math.Min(val3, val4);
				this._waterfallSampleInstance.Pan = (double)num / 1000.0;
				this._waterfallSampleInstance.Play();
				return;
			}
			this._waterfallSampleInstance.Stop();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000286E File Offset: 0x00000A6E
		public override void OnPause()
		{
			SampleInstance waterfallSampleInstance = this._waterfallSampleInstance;
			if (waterfallSampleInstance == null)
			{
				return;
			}
			waterfallSampleInstance.Stop();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002880 File Offset: 0x00000A80
		public override void OnUpdate()
		{
			this.UpdateInsideLighting();
			this.UpdateWaterfallSounds();
			if (this._level.CurrentAct == 1)
			{
				return;
			}
			this._level.FinishOnCompleteLevel = false;
			switch (this._state)
			{
			case 0:
				if (this._level.Camera.Bounds.Left >= (double)this._level.GetMarker("boss_oneway").Position.X)
				{
					Rectanglei bounds = this._level.Bounds;
					bounds.Left = this._level.GetMarker("boss_oneway").Position.X;
					bounds.Bottom = this._level.GetMarker("boss_bottom").Position.Y;
					this._level.ScrollBoundsTo(bounds, 2);
					this._state++;
					return;
				}
				break;
			case 1:
				if (!this._level.IsScrollingBounds && this._level.Camera.Bounds.Left >= (double)this._level.GetMarker("boss_left").Position.X)
				{
					this._level.Bounds = this.GetBossBounds();
					this._level.SoundManager.CrossFadeMusic(this.GetAbsolutePath("SONICORCA/MUSIC/BOSS/S2"));
					this._stateTimer = 90;
					this._state++;
					return;
				}
				break;
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
					this._level.SoundManager.PlayMusic(this.GetAbsolutePath("SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT2"));
				}
				if (this._bossObject.Fleeing)
				{
					this._state++;
					return;
				}
				break;
			case 4:
			{
				Rectangle r = this._level.Bounds;
				r.Right = Math.Min(r.Right + 8.0, (double)this.GetAct2Bounds().Right);
				r.Left = Math.Max(r.Left, this._level.Camera.Bounds.Left);
				this._level.Bounds = r;
				if (this._level.StateFlags.HasFlag(LevelStateFlags.StageCompleted))
				{
					this._state++;
					r = this._level.Bounds;
					this._level.Camera.Limits = r;
					r.Right = (double)this._level.Map.Bounds.Right;
					this._level.Bounds = r;
					return;
				}
				break;
			}
			case 5:
				this._level.StateFlags &= ~LevelStateFlags.AllowCharacterControl;
				CharacterIntelligence.SimpleMoveRightJumpObsticals(this._level.Player.Protagonist);
				if (this._level.Player.Sidekick != null)
				{
					CharacterIntelligence.SimpleMoveRightJumpObsticals(this._level.Player.Sidekick);
				}
				if (this._level.Player.Protagonist.Position.X > this._level.Bounds.Right - 128)
				{
					this._state++;
					this._sunFallTimer = 0;
					return;
				}
				break;
			case 6:
				CharacterIntelligence.SimpleMoveRightJumpObsticals(this._level.Player.Protagonist);
				if (this._level.Player.Sidekick != null)
				{
					CharacterIntelligence.SimpleMoveRightJumpObsticals(this._level.Player.Sidekick);
				}
				this._sunFallTimer++;
				if (this._sunFallTimer >= 120)
				{
					this._level.NightMode = Math.Min(this._level.NightMode + 0.00625, 1.0);
				}
				if (this._sunFallTimer >= 380)
				{
					this._level.FadeOut(LevelState.StageCompleted);
					this._state++;
					return;
				}
				break;
			case 7:
				CharacterIntelligence.SimpleMoveRightJumpObsticals(this._level.Player.Protagonist);
				if (this._level.Player.Sidekick != null)
				{
					CharacterIntelligence.SimpleMoveRightJumpObsticals(this._level.Player.Sidekick);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002D34 File Offset: 0x00000F34
		private void UpdateInsideLighting()
		{
			foreach (ICharacter character in this._level.ObjectManager.Characters)
			{
				float brightness = 0f;
				LevelMarker[] markersWithTag = this._level.GetMarkersWithTag("inside");
				for (int i = 0; i < markersWithTag.Length; i++)
				{
					Rectanglei rectanglei = markersWithTag[i].Bounds.Inflate(new Vector2i(-32, -32));
					int val = (character.Position.X >= rectanglei.X + rectanglei.Width / 2) ? (rectanglei.Right - character.Position.X) : (character.Position.X - rectanglei.Left);
					int val2 = (character.Position.Y >= rectanglei.Y + rectanglei.Height / 2) ? (rectanglei.Bottom - character.Position.Y) : (character.Position.Y - rectanglei.Top);
					int num = Math.Min(val, val2);
					if (num >= -64)
					{
						brightness = (float)(MathX.Clamp(0.0, (double)(num + 64) / 64.0, 1.0) * -0.41);
						break;
					}
				}
				character.Brightness = brightness;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002ED4 File Offset: 0x000010D4
		private void SpawnBoss()
		{
			Rectanglei bossBounds = this.GetBossBounds();
			LevelMarker marker = this._level.GetMarker("boss_position");
			this._bossObject = (this._level.ObjectManager.AddObject(new ObjectPlacement(this.GetAbsolutePath("SONICORCA/OBJECTS/DRILLEGGMAN"), this._level.Map.Layers.IndexOf(marker.Layer), marker.Position, new
			{
				LeftEdge = bossBounds.Left,
				RightEdge = bossBounds.Right
			})) as BossObject);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002F58 File Offset: 0x00001158
		private Rectanglei GetAct1Bounds()
		{
			Vector2i position = this._level.GetMarker("bounds_1_lt").Position;
			Vector2i position2 = this._level.GetMarker("bounds_1_rb").Position;
			return Rectanglei.FromLTRB(position.X, position.Y, position2.X, position2.Y);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002FB4 File Offset: 0x000011B4
		private Rectanglei GetAct2Bounds()
		{
			Vector2i position = this._level.GetMarker("bounds_2_lt").Position;
			Vector2i position2 = this._level.GetMarker("bounds_2_rb").Position;
			return Rectanglei.FromLTRB(position.X, position.Y, position2.X, position2.Y);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003010 File Offset: 0x00001210
		private Rectanglei GetBossBounds()
		{
			Vector2i position = this._level.GetMarker("boss_left").Position;
			Vector2i position2 = this._level.GetMarker("boss_right").Position;
			Vector2i position3 = this._level.GetMarker("boss_bottom").Position;
			return Rectanglei.FromLTRB(position.X, this._level.Bounds.Top, position2.X, position3.Y);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000308C File Offset: 0x0000128C
		private IEnumerable<Rectanglei> GetWaterfalls(LevelLayer layer)
		{
			List<Rectanglei> list = new List<Rectanglei>();
			for (int i = 0; i < layer.Columns; i++)
			{
				Rectanglei currentRect = new Rectanglei(i, 0, 1, 0);
				for (int j = 0; j < layer.Rows; j++)
				{
					if (this.IsWaterfallTopTile(layer.Tiles[i, j]) && currentRect.Height != 0)
					{
						this.AggregateWaterfalls(list, currentRect);
						currentRect.Y = j;
						currentRect.Height = 1;
					}
					else if (this.IsWaterfallTile(layer.Tiles[i, j]))
					{
						if (currentRect.Height == 0)
						{
							currentRect.Y = j;
							currentRect.Height = 1;
						}
						else
						{
							int height = currentRect.Height;
							currentRect.Height = height + 1;
						}
					}
					else if (currentRect.Height != 0)
					{
						this.AggregateWaterfalls(list, currentRect);
						currentRect.Y = 0;
						currentRect.Height = 0;
					}
				}
				if (currentRect.Height != 0)
				{
					this.AggregateWaterfalls(list, currentRect);
				}
			}
			return list;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003188 File Offset: 0x00001388
		private void AggregateWaterfalls(IList<Rectanglei> rects, Rectanglei currentRect)
		{
			bool flag = false;
			for (int i = 0; i < rects.Count; i++)
			{
				Rectanglei value = rects[i];
				if (value.Right == currentRect.X && value.Y == currentRect.Y && value.Height == currentRect.Height)
				{
					int width = value.Width;
					value.Width = width + 1;
					rects[i] = value;
					flag = true;
				}
			}
			if (!flag)
			{
				rects.Add(currentRect);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003208 File Offset: 0x00001408
		private bool IsWaterfallTile(int tile)
		{
			int num = tile & 4095;
			return num >= 780 && num <= 803;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003234 File Offset: 0x00001434
		private bool IsWaterfallTopTile(int tile)
		{
			int num = tile & 4095;
			return num >= 792 && num <= 795;
		}

		// Token: 0x04000006 RID: 6
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x04000007 RID: 7
		private const string MapResourceKey = "//MAP";

		// Token: 0x04000008 RID: 8
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x04000009 RID: 9
		private const string BossObjectResourceKey = "SONICORCA/OBJECTS/DRILLEGGMAN";

		// Token: 0x0400000A RID: 10
		private static IReadOnlyList<string> AnimalResourceKeys = new string[]
		{
			"SONICORCA/OBJECTS/FLICKY",
			"SONICORCA/OBJECTS/RICKY"
		};

		// Token: 0x0400000B RID: 11
		private const string Act1MusicResourceKey = "SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT1";

		// Token: 0x0400000C RID: 12
		private const string Act2MusicResourceKey = "SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT2";

		// Token: 0x0400000D RID: 13
		private const string BossMusicResourceKey = "SONICORCA/MUSIC/BOSS/S2";

		// Token: 0x0400000E RID: 14
		private const string Act1FastMusicResourceKey = "SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT1/FAST";

		// Token: 0x0400000F RID: 15
		private const string Act2FastMusicResourceKey = "SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT2/FAST";

		// Token: 0x04000010 RID: 16
		private const string WaterfallResourceKey = "SONICORCA/SOUND/WATERFALL";

		// Token: 0x04000011 RID: 17
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/OBJECTS/DRILLEGGMAN",
			"SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT1",
			"SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT2",
			"SONICORCA/MUSIC/BOSS/S2",
			"SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT1/FAST",
			"SONICORCA/MUSIC/LEVELS/EHZ/COOPERATIVE/ACT2/FAST",
			"SONICORCA/SOUND/WATERFALL"
		}.Concat(EmeraldHillZoneArea.AnimalResourceKeys).ToArray<string>();

		// Token: 0x04000012 RID: 18
		private SonicOrcaGameContext _gameContext;

		// Token: 0x04000013 RID: 19
		private Level _level;

		// Token: 0x04000014 RID: 20
		private int _state;

		// Token: 0x04000015 RID: 21
		private int _stateTimer;

		// Token: 0x04000016 RID: 22
		private BossObject _bossObject;

		// Token: 0x04000017 RID: 23
		private bool _bossDefeated;

		// Token: 0x04000018 RID: 24
		private int _sunFallTimer;

		// Token: 0x04000019 RID: 25
		private Rectanglei[] _waterfallRects;

		// Token: 0x0400001A RID: 26
		private SampleInstance _waterfallSampleInstance;
	}
}
