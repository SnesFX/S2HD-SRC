using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.LEVELS.HTZ.AREA
{
	// Token: 0x02000006 RID: 6
	public class HillTopZoneArea : Area
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000032FD File Offset: 0x000014FD
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

		// Token: 0x06000028 RID: 40 RVA: 0x0000333D File Offset: 0x0000153D
		public HillTopZoneArea() : base(HillTopZoneArea.AreaDependencies)
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003354 File Offset: 0x00001554
		public override void Prepare(Level level, LevelPrepareSettings settings)
		{
			this._gameContext = level.GameContext;
			this._level = level;
			this._level.Name = "Hill Top";
			this._level.ShowAsZone = true;
			this._level.ShowAsAct = true;
			this._level.Scheme = LevelScheme.S2;
			this._level.AnimalResourceKeys = HillTopZoneArea.AnimalResourceKeys;
			if (!settings.Seamless)
			{
				this._level.TileSet = this._gameContext.ResourceTree.GetLoadedResource<TileSet>(this, "//TILESET");
				this._level.LoadMap(this._gameContext.ResourceTree.GetLoadedResource<LevelMap>(this, "//MAP"));
				this._level.LoadBinding(this._gameContext.ResourceTree.GetLoadedResource<LevelBinding>(this, "//BINDING"));
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

		// Token: 0x0600002A RID: 42 RVA: 0x0000345C File Offset: 0x0000165C
		private void PrepareAct1()
		{
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/HTZ/COOPERATIVE/ACT1";
			this._level.CurrentAct = 1;
			this._level.SetStartPosition("startpos_stk_1");
			this._level.Bounds = this.GetAct1Bounds();
			this._level.RingsPerfectTarget = this._level.ObjectManager.ObjectEntryTable.GetRingCountInRegion(this._level.Bounds);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000034D4 File Offset: 0x000016D4
		private void PrepareAct2()
		{
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/HTZ/COOPERATIVE/ACT2";
			this._level.CurrentAct = 2;
			this._level.SetStartPosition("startpos_stk_2");
			this._level.Bounds = this.GetAct2Bounds();
			this._level.RingsPerfectTarget = this._level.ObjectManager.ObjectEntryTable.GetRingCountInRegion(this._level.Bounds);
			this._state = 0;
			this._bossDefeated = false;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003558 File Offset: 0x00001758
		private void SeamlessPrepareAct2()
		{
			this._level.LevelMusic = "SONICORCA/MUSIC/LEVELS/HTZ/COOPERATIVE/ACT2";
			this._level.CurrentAct = 2;
			Rectanglei act2Bounds = this.GetAct2Bounds();
			this._level.RingsPerfectTarget = this._level.ObjectManager.ObjectEntryTable.GetRingCountInRegion(act2Bounds);
			base.ExtendSeamlessLevelBounds(this._level, act2Bounds);
			this._state = 0;
			this._bossDefeated = false;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000035C4 File Offset: 0x000017C4
		public override void OnStart()
		{
			this._lavaLayerA = this._level.Map.FindLayer("lavawallcave");
			this._lavaLayerB = this._level.Map.FindLayer("lavawall middle");
			this._insideAreaMarkers = this._level.GetMarkersWithTag("inside");
			this._lavaCaveAreaMarkers = this._level.GetMarkersWithTag("lavacave");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003634 File Offset: 0x00001834
		public override void OnUpdate()
		{
			if (!this._level.StateFlags.HasFlag(LevelStateFlags.Updating))
			{
				return;
			}
			Vector2 vector = this._level.Player.Protagonist.Position;
			switch (this._timeOfDayState)
			{
			case 0:
				if (vector.X > 22272.0)
				{
					this._timeOfDayState = 1;
				}
				break;
			case 1:
				if (vector.Y > 4480.0)
				{
					this._timeOfDayState = 2;
				}
				break;
			case 2:
				this._level.NightMode = MathX.Clamp(this._level.NightMode, (vector.X - 19456.0) / 14784.0, 1.0);
				if (this._level.NightMode >= 1.0)
				{
					this._timeOfDayState = 3;
				}
				break;
			case 3:
				this._level.NightMode = MathX.Clamp(this._level.NightMode, (vector.X - 0.0) / 98816.0, 1.0);
				break;
			}
			int currentAct = this._level.CurrentAct;
			if (currentAct == 2)
			{
				this.Act2Events();
			}
			this.UpdateInsideLighting();
			this.UpdateLavaGlow();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000037A0 File Offset: 0x000019A0
		private void SpawnBoss()
		{
			LevelMarker marker = this._level.GetMarker("boss_position");
			this._bossObject = (this._level.ObjectManager.AddObject(new ObjectPlacement(this.GetAbsolutePath("SONICORCA/OBJECTS/SUBMARINEEGGMAN"), this._level.Map.Layers.IndexOf(marker.Layer), marker.Position)) as BossObject);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000380C File Offset: 0x00001A0C
		private Rectanglei GetAct1Bounds()
		{
			return Rectanglei.FromLTRB(0, 0, this._level.GetMarker("bounds_1_r").Position.X, this._level.Map.Bounds.Height - 64);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003858 File Offset: 0x00001A58
		private Rectanglei GetAct2Bounds()
		{
			return Rectanglei.FromLTRB(this._level.GetMarker("bounds_2_l").Position.X, 0, this._level.Map.Bounds.Width, this._level.Map.Bounds.Height - 64);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000038BC File Offset: 0x00001ABC
		private void Act2Events()
		{
			if (this._state < 6)
			{
				Vector2i position = this._level.GetMarker("boss_oneway").Position;
				if (this._level.Camera.Bounds.Left >= (double)position.X)
				{
					Rectangle r = this._level.Bounds;
					r.Left = (double)position.X;
					r.Bottom = this._level.Camera.Bounds.Bottom;
					this._level.Bounds = r;
					this._state = 6;
				}
			}
			switch (this._state)
			{
			case 6:
			{
				int y = this._level.GetMarker("boss_oneway").Position.Y;
				int num = this._level.GetMarker("boss_left").Position.X - 68;
				int num2 = this._level.GetMarker("boss_right").Position.X + 68;
				if (this._level.Camera.Bounds.Left >= (double)num)
				{
					Rectangle r2 = this._level.Bounds;
					r2.Left = (double)num;
					r2.Right = (double)num2;
					r2.Bottom = (double)y;
					this._level.Bounds = r2;
					this._level.SoundManager.CrossFadeMusic(this.GetAbsolutePath("SONICORCA/MUSIC/BOSS/S2"));
					this._stateTimer = 90;
					this._state++;
					return;
				}
				Rectangle r3 = this._level.Bounds;
				r3.Bottom = MathX.GoTowards(r3.Bottom, (double)y, 2.0);
				this._level.Bounds = r3;
				return;
			}
			case 7:
				this._stateTimer--;
				if (this._stateTimer <= 0)
				{
					this.SpawnBoss();
					this._state++;
					return;
				}
				break;
			case 8:
				if (!this._bossDefeated && this._bossObject != null && this._bossObject.Defeated)
				{
					this._bossDefeated = true;
					this._level.SoundManager.PlayMusic(this.GetAbsolutePath("SONICORCA/MUSIC/LEVELS/HTZ/COOPERATIVE/ACT2"));
				}
				if (this._bossObject != null && this._bossObject.Fleeing)
				{
					this._state++;
					return;
				}
				break;
			case 9:
			{
				Rectangle r4 = this._level.Bounds;
				r4.Right = Math.Min(r4.Right + 8.0, (double)this.GetAct2Bounds().Right);
				r4.Left = (double)this.GetAct2Bounds().Left;
				r4.Left = Math.Max(r4.Left, this._level.Camera.Bounds.Left);
				if (this._level.Player.Protagonist.Position.X >= 95700)
				{
					r4.Bottom = Math.Max(r4.Bottom - 8.0, (double)(this.GetAct2Bounds().Bottom - 3000));
				}
				this._level.Bounds = r4;
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003C44 File Offset: 0x00001E44
		private void UpdateLayerVisibillity()
		{
			Rectanglei rectanglei = this._level.Camera.Bounds;
			foreach (LevelMarker levelMarker in this._lavaCaveAreaMarkers)
			{
				if (rectanglei.IntersectsWith(levelMarker.Bounds))
				{
					this.ShowLavaCaves(true);
					return;
				}
			}
			this.ShowLavaCaves(false);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003C9E File Offset: 0x00001E9E
		private void ShowLavaCaves(bool value)
		{
			this._lavaLayerA.Visible = value;
			this._lavaLayerB.Visible = value;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003CB8 File Offset: 0x00001EB8
		private void InitialiseDendaleons()
		{
			if (this._dendaleonTexture == null)
			{
				this._dendaleonTexture = this._gameContext.ResourceTree.GetLoadedResource<ITexture>("SONICORCA/PARTICLE/DENDALEON");
			}
			if (this.ShouldCreateDendaleons())
			{
				int num = 300;
				ParticleManager particleManager = this._level.ParticleManager;
				for (int i = 0; i < num; i++)
				{
					if (i % 8 == 0)
					{
						particleManager.Add(this.CreateParticle());
					}
					particleManager.Update();
				}
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003D25 File Offset: 0x00001F25
		private void UpdateDendaleons()
		{
			if (this.ShouldCreateDendaleons() && this._level.Ticks % 8 == 0)
			{
				this._level.ParticleManager.Add(this.CreateParticle());
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003D54 File Offset: 0x00001F54
		private Particle CreateParticle()
		{
			Random random = this._level.Random;
			Rectanglei rectanglei = this._level.Camera.Bounds;
			Rectanglei rectanglei2 = new Rectanglei(rectanglei.Right, rectanglei.Top + 4, 128, rectanglei.Height - 8);
			int num = this._level.Random.Next(rectanglei2.Left, rectanglei2.Right);
			int num2 = this._level.Random.Next(rectanglei2.Top, rectanglei2.Bottom);
			double num3 = this._level.Random.NextDouble(0.1, 0.7);
			double num4 = MathX.Lerp(2.0, 18.0, (num3 - 0.1) / 0.6);
			return new Particle
			{
				Type = ParticleType.Custom,
				Time = 1200,
				Velocity = new Vector2(-num4, this._level.Random.NextDouble(-2.0, 2.0)),
				Angle = random.NextDouble(6.283185307179586),
				AngularVelocity = random.NextDouble(0.05, 0.1),
				CustomTexture = this._dendaleonTexture,
				Position = new Vector2((double)num, (double)num2),
				Layer = this._level.Map.Layers[21],
				Size = num3
			};
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003EF8 File Offset: 0x000020F8
		private bool ShouldCreateDendaleons()
		{
			return this._level.Camera.Bounds.Right > 32000.0;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003F28 File Offset: 0x00002128
		private void UpdateInsideLighting()
		{
			foreach (ICharacter character in this._level.ObjectManager.Characters)
			{
				float num = 0f;
				LevelMarker[] insideAreaMarkers = this._insideAreaMarkers;
				for (int i = 0; i < insideAreaMarkers.Length; i++)
				{
					Rectanglei rectanglei = insideAreaMarkers[i].Bounds.Inflate(new Vector2i(-32, -32));
					int val = (character.Position.X >= rectanglei.X + rectanglei.Width / 2) ? (rectanglei.Right - character.Position.X) : (character.Position.X - rectanglei.Left);
					int val2 = (character.Position.Y >= rectanglei.Y + rectanglei.Height / 2) ? (rectanglei.Bottom - character.Position.Y) : (character.Position.Y - rectanglei.Top);
					int num2 = Math.Min(val, val2);
					if (num2 >= -64)
					{
						float num3 = (float)MathX.Clamp(0.0, (double)(num2 + 64) / 64.0, 1.0);
						if (num3 == 1f)
						{
							num = -0.41f;
							break;
						}
						num = Math.Min(num3 * -0.41f, num);
					}
				}
				character.Brightness = num;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000040D4 File Offset: 0x000022D4
		private void UpdateLavaGlow()
		{
			ObjectType objectType = this._level.ObjectManager.RegisteredTypes.FirstOrDefault((ObjectType x) => x.ResourceKey == "SONICORCA/OBJECTS/LAVA");
			List<Rectanglei> list = new List<Rectanglei>();
			if (objectType != null)
			{
				foreach (ActiveObject activeObject in this._level.ObjectManager.ActiveObjects)
				{
					if (activeObject.Type == objectType && activeObject.CollisionVectors.Length >= 2)
					{
						CollisionVector collisionVector = activeObject.CollisionVectors[1];
						Rectanglei item = Rectanglei.FromLTRB(collisionVector.AbsoluteA.X, collisionVector.AbsoluteA.Y - 256, collisionVector.AbsoluteB.X, collisionVector.AbsoluteB.Y).Inflate(new Vector2i(-32, 32));
						list.Add(item);
					}
				}
			}
			foreach (ICharacter character in this._level.ObjectManager.Characters)
			{
				float num = 0f;
				foreach (Rectanglei rectanglei in list)
				{
					int num2 = (character.Position.X >= rectanglei.X + rectanglei.Width / 2) ? (rectanglei.Right - character.Position.X) : (character.Position.X - rectanglei.Left);
					int num3 = (character.Position.Y >= rectanglei.Y + rectanglei.Height / 2) ? (rectanglei.Bottom - character.Position.Y) : (character.Position.Y - rectanglei.Top);
					if (num2 >= -64 && num3 >= -64)
					{
						float val = (float)(MathX.Clamp(0.0, (double)(num2 + 64) / 64.0, 1.0) * 0.4);
						float val2 = (float)(MathX.Clamp(0.0, (double)(num3 + 64) / (double)rectanglei.Height, 1.0) * 0.4);
						num = Math.Min(val, val2);
					}
				}
				character.Brightness = Math.Min(character.Brightness + num * 2f, 0.4f);
			}
		}

		// Token: 0x0400001B RID: 27
		private const string TileSetResourceKey = "//TILESET";

		// Token: 0x0400001C RID: 28
		private const string MapResourceKey = "//MAP";

		// Token: 0x0400001D RID: 29
		private const string BindingResourceKey = "//BINDING";

		// Token: 0x0400001E RID: 30
		private const string BossObjectResourceKey = "SONICORCA/OBJECTS/SUBMARINEEGGMAN";

		// Token: 0x0400001F RID: 31
		private static IReadOnlyList<string> AnimalResourceKeys = new string[]
		{
			"SONICORCA/OBJECTS/LOCKY",
			"SONICORCA/OBJECTS/WOCKY"
		};

		// Token: 0x04000020 RID: 32
		private const string Act1MusicResourceKey = "SONICORCA/MUSIC/LEVELS/HTZ/COOPERATIVE/ACT1";

		// Token: 0x04000021 RID: 33
		private const string Act2MusicResourceKey = "SONICORCA/MUSIC/LEVELS/HTZ/COOPERATIVE/ACT2";

		// Token: 0x04000022 RID: 34
		private const string BossMusicResourceKey = "SONICORCA/MUSIC/BOSS/S2";

		// Token: 0x04000023 RID: 35
		private const string DendaleonResourceKey = "SONICORCA/PARTICLE/DENDALEON";

		// Token: 0x04000024 RID: 36
		public static IReadOnlyList<string> AreaDependencies = new string[]
		{
			"//TILESET",
			"//MAP",
			"//BINDING",
			"SONICORCA/OBJECTS/SUBMARINEEGGMAN",
			"SONICORCA/MUSIC/LEVELS/HTZ/COOPERATIVE/ACT1",
			"SONICORCA/MUSIC/LEVELS/HTZ/COOPERATIVE/ACT2",
			"SONICORCA/MUSIC/BOSS/S2",
			"SONICORCA/PARTICLE/DENDALEON"
		}.Concat(HillTopZoneArea.AnimalResourceKeys).ToArray<string>();

		// Token: 0x04000025 RID: 37
		private SonicOrcaGameContext _gameContext;

		// Token: 0x04000026 RID: 38
		private Level _level;

		// Token: 0x04000027 RID: 39
		private int _state;

		// Token: 0x04000028 RID: 40
		private int _stateTimer;

		// Token: 0x04000029 RID: 41
		private BossObject _bossObject;

		// Token: 0x0400002A RID: 42
		private bool _bossDefeated;

		// Token: 0x0400002B RID: 43
		private LevelLayer _lavaLayerA;

		// Token: 0x0400002C RID: 44
		private LevelLayer _lavaLayerB;

		// Token: 0x0400002D RID: 45
		private LevelMarker[] _insideAreaMarkers;

		// Token: 0x0400002E RID: 46
		private LevelMarker[] _lavaCaveAreaMarkers;

		// Token: 0x0400002F RID: 47
		private int _timeOfDayState = -1;

		// Token: 0x04000030 RID: 48
		private ITexture _dendaleonTexture;
	}
}
