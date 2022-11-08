using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Audio;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Debugging;
using SonicOrca.Core.Lighting;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Input;
using SonicOrca.Menu;

namespace SonicOrca.Core
{
	// Token: 0x02000121 RID: 289
	public class Level : IDisposable
	{
		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x00029943 File Offset: 0x00027B43
		public SonicOrcaGameContext GameContext
		{
			get
			{
				return this._gameContext;
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x0002994B File Offset: 0x00027B4B
		public Player Player
		{
			get
			{
				return this._player;
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x00029953 File Offset: 0x00027B53
		// (set) Token: 0x06000AC4 RID: 2756 RVA: 0x0002995B File Offset: 0x00027B5B
		public Area Area { get; private set; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x00029964 File Offset: 0x00027B64
		// (set) Token: 0x06000AC6 RID: 2758 RVA: 0x0002996C File Offset: 0x00027B6C
		public LevelPrepareSettings PrepareSettings { get; set; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x00029975 File Offset: 0x00027B75
		// (set) Token: 0x06000AC8 RID: 2760 RVA: 0x0002997D File Offset: 0x00027B7D
		public string Name { get; set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x00029986 File Offset: 0x00027B86
		// (set) Token: 0x06000ACA RID: 2762 RVA: 0x0002998E File Offset: 0x00027B8E
		public bool ShowAsZone { get; set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000ACB RID: 2763 RVA: 0x00029997 File Offset: 0x00027B97
		// (set) Token: 0x06000ACC RID: 2764 RVA: 0x0002999F File Offset: 0x00027B9F
		public bool ShowAsAct { get; set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x000299A8 File Offset: 0x00027BA8
		// (set) Token: 0x06000ACE RID: 2766 RVA: 0x000299B0 File Offset: 0x00027BB0
		public int CurrentAct { get; set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x000299B9 File Offset: 0x00027BB9
		// (set) Token: 0x06000AD0 RID: 2768 RVA: 0x000299C1 File Offset: 0x00027BC1
		public LevelScheme Scheme { get; set; }

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x000299CA File Offset: 0x00027BCA
		// (set) Token: 0x06000AD2 RID: 2770 RVA: 0x000299D2 File Offset: 0x00027BD2
		public IReadOnlyCollection<string> AnimalResourceKeys { get; set; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x000299DB File Offset: 0x00027BDB
		// (set) Token: 0x06000AD4 RID: 2772 RVA: 0x000299E3 File Offset: 0x00027BE3
		public string LevelMusic { get; set; }

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x000299EC File Offset: 0x00027BEC
		// (set) Token: 0x06000AD6 RID: 2774 RVA: 0x000299F4 File Offset: 0x00027BF4
		public Vector2i StartPosition { get; set; }

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x000299FD File Offset: 0x00027BFD
		// (set) Token: 0x06000AD8 RID: 2776 RVA: 0x00029A05 File Offset: 0x00027C05
		public int StartLayerIndex { get; set; }

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x00029A0E File Offset: 0x00027C0E
		// (set) Token: 0x06000ADA RID: 2778 RVA: 0x00029A16 File Offset: 0x00027C16
		public Rectanglei Bounds { get; set; }

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000ADB RID: 2779 RVA: 0x00029A1F File Offset: 0x00027C1F
		// (set) Token: 0x06000ADC RID: 2780 RVA: 0x00029A27 File Offset: 0x00027C27
		public Rectanglei SeamlessNextBounds { get; set; }

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x00029A30 File Offset: 0x00027C30
		// (set) Token: 0x06000ADE RID: 2782 RVA: 0x00029A38 File Offset: 0x00027C38
		public bool SeamlessAct { get; set; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x00029A41 File Offset: 0x00027C41
		// (set) Token: 0x06000AE0 RID: 2784 RVA: 0x00029A49 File Offset: 0x00027C49
		public double NightMode { get; set; }

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x00029A52 File Offset: 0x00027C52
		// (set) Token: 0x06000AE2 RID: 2786 RVA: 0x00029A5A File Offset: 0x00027C5A
		public bool FinishOnCompleteLevel { get; set; }

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x00029A63 File Offset: 0x00027C63
		// (set) Token: 0x06000AE4 RID: 2788 RVA: 0x00029A6B File Offset: 0x00027C6B
		public TileSet TileSet { get; set; }

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x00029A74 File Offset: 0x00027C74
		// (set) Token: 0x06000AE6 RID: 2790 RVA: 0x00029A7C File Offset: 0x00027C7C
		public LevelBinding Binding { get; set; }

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x00029A85 File Offset: 0x00027C85
		// (set) Token: 0x06000AE8 RID: 2792 RVA: 0x00029A8D File Offset: 0x00027C8D
		public LevelMap Map { get; set; }

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x00029A96 File Offset: 0x00027C96
		internal PlayRecorder PlayRecorder
		{
			get
			{
				return this._playRecorder;
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x00029A9E File Offset: 0x00027C9E
		// (set) Token: 0x06000AEB RID: 2795 RVA: 0x00029AA6 File Offset: 0x00027CA6
		public LevelState State { get; set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x00029AAF File Offset: 0x00027CAF
		// (set) Token: 0x06000AED RID: 2797 RVA: 0x00029AB7 File Offset: 0x00027CB7
		public LevelStateFlags StateFlags { get; set; }

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x00029AC0 File Offset: 0x00027CC0
		// (set) Token: 0x06000AEF RID: 2799 RVA: 0x00029AC8 File Offset: 0x00027CC8
		public int Ticks { get; set; }

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x00029AD1 File Offset: 0x00027CD1
		// (set) Token: 0x06000AF1 RID: 2801 RVA: 0x00029AD9 File Offset: 0x00027CD9
		public int Time { get; set; }

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x00029AE2 File Offset: 0x00027CE2
		public Camera Camera
		{
			get
			{
				return this._camera;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x00029AEA File Offset: 0x00027CEA
		public bool IsScrollingBounds
		{
			get
			{
				return this._boundsScrollSpeed != 0;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x00029AF5 File Offset: 0x00027CF5
		public LayerViewOptions LayerViewOptions
		{
			get
			{
				return this._layerViewOptions;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000AF5 RID: 2805 RVA: 0x00029AFD File Offset: 0x00027CFD
		public Random Random
		{
			get
			{
				return this._random;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x00029B05 File Offset: 0x00027D05
		public ObjectManager ObjectManager
		{
			get
			{
				return this._objectManager;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x00029B0D File Offset: 0x00027D0D
		public CollisionTable CollisionTable
		{
			get
			{
				return this._collisionTable;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x00029B15 File Offset: 0x00027D15
		public ParticleManager ParticleManager
		{
			get
			{
				return this._particleManager;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000AF9 RID: 2809 RVA: 0x00029B1D File Offset: 0x00027D1D
		public WaterManager WaterManager
		{
			get
			{
				return this._waterManager;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x00029B25 File Offset: 0x00027D25
		public SoundManager SoundManager
		{
			get
			{
				return this._soundManager;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000AFB RID: 2811 RVA: 0x00029B2D File Offset: 0x00027D2D
		public ILightingManager LightingManager
		{
			get
			{
				return this._lightingManager;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x00029B35 File Offset: 0x00027D35
		public DebugContext DebugContext
		{
			get
			{
				return this._debugContext;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000AFD RID: 2813 RVA: 0x00029B3D File Offset: 0x00027D3D
		// (set) Token: 0x06000AFE RID: 2814 RVA: 0x00029B45 File Offset: 0x00027D45
		public bool LandscapeAnimating { get; set; }

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000AFF RID: 2815 RVA: 0x00029B4E File Offset: 0x00027D4E
		// (set) Token: 0x06000B00 RID: 2816 RVA: 0x00029B56 File Offset: 0x00027D56
		public bool ObjectsAnimating { get; set; }

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x00029B5F File Offset: 0x00027D5F
		// (set) Token: 0x06000B02 RID: 2818 RVA: 0x00029B67 File Offset: 0x00027D67
		public bool ShowCharacterInfo { get; set; }

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x00029B70 File Offset: 0x00027D70
		// (set) Token: 0x06000B04 RID: 2820 RVA: 0x00029B78 File Offset: 0x00027D78
		public bool ShowSidekickIntelligence { get; set; }

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000B05 RID: 2821 RVA: 0x00029B81 File Offset: 0x00027D81
		// (set) Token: 0x06000B06 RID: 2822 RVA: 0x00029B89 File Offset: 0x00027D89
		public bool ClassicDebugMode { get; set; }

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000B07 RID: 2823 RVA: 0x00029B92 File Offset: 0x00027D92
		// (set) Token: 0x06000B08 RID: 2824 RVA: 0x00029B9A File Offset: 0x00027D9A
		public bool ShowHUD { get; set; }

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000B09 RID: 2825 RVA: 0x00029BA3 File Offset: 0x00027DA3
		// (set) Token: 0x06000B0A RID: 2826 RVA: 0x00029BAB File Offset: 0x00027DAB
		public int RingsCollected { get; set; }

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000B0B RID: 2827 RVA: 0x00029BB4 File Offset: 0x00027DB4
		// (set) Token: 0x06000B0C RID: 2828 RVA: 0x00029BBC File Offset: 0x00027DBC
		public int RingsPerfectTarget { get; set; }

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x00029BC5 File Offset: 0x00027DC5
		public CommonResources CommonResources
		{
			get
			{
				return this._commonResources;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x00029BCD File Offset: 0x00027DCD
		public ILevelRenderer LevelRenderer
		{
			get
			{
				return this._levelRenderer;
			}
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00029BD8 File Offset: 0x00027DD8
		public Level(SonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._fadeTransitionRenderer = gameContext.Renderer.CreateFadeTransitionRenderer();
			this._levelRenderer = gameContext.CreateLevelRenderer(this);
			this._player = new Player(this);
			this._collisionTable = new CollisionTable(this);
			this._objectManager = new ObjectManager(this);
			this._particleManager = new ParticleManager(this);
			this._waterManager = new WaterManager(this);
			this._soundManager = new SoundManager(this);
			this._lightingManager = new LightingManager();
			this._debugContext = new DebugContext(this);
			this._hud = new LevelHud(this);
			this._completeHud = new LevelCompleteHud(this);
			this._gameOverHud = new GameOverHud(this);
			this._camera = new Camera(this);
			this._commonResources = new CommonResources(this._gameContext);
			this._playRecorder = new PlayRecorder();
			this.TileSet = new TileSet();
			this.Map = new LevelMap();
			this.LandscapeAnimating = true;
			this.ObjectsAnimating = true;
			this.ShowHUD = true;
			this.AnimalResourceKeys = new string[0];
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00029D5C File Offset: 0x00027F5C
		public void Dispose()
		{
			if (this._earthquakeSampleInstance != null)
			{
				this._earthquakeSampleInstance.Dispose();
			}
			this.Unload();
			this._playRecorder.Dispose();
			this._commonResources.Dispose();
			this._particleManager.Dispose();
			this._gameOverHud.Dispose();
			this._completeHud.Dispose();
			this._hud.Dispose();
			this._debugContext.Dispose();
			this._fadeTransitionRenderer.Dispose();
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00029DDC File Offset: 0x00027FDC
		public async Task LoadCommonAsync(CancellationToken ct = default(CancellationToken))
		{
			Trace.WriteLine("Loading common level components");
			await this._debugContext.LoadAsync(ct);
			await this._hud.LoadAsync(ct);
			await this._completeHud.LoadAsync(ct);
			await this._gameOverHud.LoadAsync(ct);
			await this._particleManager.LoadAsync(ct);
			await this._levelRenderer.LoadAsync(ct);
			await this._commonResources.LoadEntriesAsync(ct);
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00029E2C File Offset: 0x0002802C
		public async Task LoadAsync(Area area, CancellationToken ct = default(CancellationToken))
		{
			Trace.WriteLine("Loading level " + this.Name);
			this.Area = area;
			await this._commonResources.LoadSchemeAsync(this.Scheme, ct);
			this._titleCard = new Sonic2LevelTitleCard(this);
			await this._titleCard.LoadAsync(this._gameContext.ResourceTree, ct);
			this._soundManager.SetJingle(JingleType.Life, this._commonResources.GetResourcePath("1upjingle"));
			this._soundManager.SetJingle(JingleType.Invincibility, this._commonResources.GetResourcePath("invincibilityjingle"));
			this._soundManager.SetJingle(JingleType.Drowning, this._commonResources.GetResourcePath("drowningjingle"));
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00029E84 File Offset: 0x00028084
		public void LoadMap(LevelMap map)
		{
			Trace.WriteLine("Loading level map");
			this.Map = map;
			this.Map.Level = this;
			this._objectManager.Setup(this.Map);
			this._collisionTable.Initialise(this.Map);
			this._markers.Clear();
			foreach (LevelMarker levelMarker in map.Markers)
			{
				if (!string.IsNullOrEmpty(levelMarker.Name))
				{
					this._markers[levelMarker.Name.ToLower()] = levelMarker;
				}
			}
			this._levelRenderer.Initialise();
			Trace.WriteLine("Map loading complete");
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x00029F50 File Offset: 0x00028150
		public void LoadBinding(LevelBinding binding)
		{
			Trace.WriteLine("Loading level binding");
			this.Binding = binding;
			this.Binding.Level = this;
			this._objectManager.Bind(this.Binding);
			Trace.WriteLine("Map binding complete");
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00029F8C File Offset: 0x0002818C
		public void UnloadCommon()
		{
			Trace.WriteLine("Unloading common level components");
			this._debugContext.Dispose();
			this._hud.Dispose();
			this._completeHud.Dispose();
			this._gameOverHud.Dispose();
			this._particleManager.Dispose();
			this._levelRenderer.Dispose();
			this._commonResources.Dispose();
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00029FF0 File Offset: 0x000281F0
		public void Unload()
		{
			Trace.WriteLine("Unloading level " + this.Name);
			this.Stop();
			if (this._titleCard != null)
			{
				this._titleCard.Dispose();
			}
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0002A020 File Offset: 0x00028220
		public void Start()
		{
			Trace.WriteLine("Starting level " + this.Name);
			this._waterManager.Load();
			this._fadeTransition.Clear();
			this.StateFlags = (LevelStateFlags)0;
			this.Ticks = 0;
			this._intervals.Clear();
			this.InitialiseEarthquake();
			this.FinishOnCompleteLevel = true;
			this.NightMode = this.PrepareSettings.NightMode;
			if (!this.PrepareSettings.Seamless)
			{
				this._objectManager.Start();
			}
			if (this.State != LevelState.Editing)
			{
				this._player.ResetScoreChain();
				this._player.ResetRings();
				this._player.RemovePowerups();
				if (this.PrepareSettings.Seamless)
				{
					this._player.StarpostIndex = -1;
					this._player.Protagonist.IsWinning = false;
					if (this._player.Sidekick != null)
					{
						this._player.Sidekick.IsWinning = false;
					}
					this.StateFlags |= LevelStateFlags.AllowCharacterControl;
					this.StateFlags |= LevelStateFlags.UpdateTime;
					this._cameraLockedSeamless = true;
				}
				else
				{
					this.SetupCharacters();
					this._cameraLockedSeamless = false;
				}
				this.StartTitleCard(this.PrepareSettings.Seamless);
				this._soundManager.PlayMusic(this.LevelMusic);
				this.Time = ((this._player.StarpostIndex == -1) ? 0 : this._player.StarpostTime);
				this._hud.ShowMiliseconds = this.PrepareSettings.TimeTrial;
				this.ClassicDebugMode = this.PrepareSettings.Debugging;
				Controller.IsDebug = this.PrepareSettings.Debugging;
				if (!this.PrepareSettings.Seamless)
				{
					if (!string.IsNullOrEmpty(this.PrepareSettings.RecordedPlayReadPath))
					{
						this._playRecorder.BeginPlaying(this.PrepareSettings.RecordedPlayReadPath);
					}
					else if (this.PrepareSettings.RecordedPlayReadData != null)
					{
						this._playRecorder.BeginPlaying(new MemoryStream(this.PrepareSettings.RecordedPlayReadData));
					}
					else if (!string.IsNullOrEmpty(this.PrepareSettings.RecordedPlayGhostReadPath))
					{
						this._playRecorder.BeginPlaying(this.PrepareSettings.RecordedPlayGhostReadPath);
					}
					if (!string.IsNullOrEmpty(this.PrepareSettings.RecordedPlayWritePath))
					{
						this._playRecorder.BeginRecording(this.PrepareSettings.RecordedPlayWritePath);
					}
				}
				this.State = LevelState.Playing;
				this.RingsCollected = 0;
				this.Area.OnStart();
			}
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0002A29C File Offset: 0x0002849C
		public void Stop()
		{
			Trace.WriteLine("Stopping level " + this.Name);
			if (this._playRecorder != null)
			{
				this._playRecorder.EndPlaying();
				this._playRecorder.EndRecording();
			}
			this.StopEarthquake();
			this._soundManager.StopAll();
			this._objectManager.Stop();
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0002A2F8 File Offset: 0x000284F8
		private void SetupCharacters()
		{
			Vector2i playerStartPosition = this.GetPlayerStartPosition();
			Vector2i position = playerStartPosition + new Vector2i(-64, 0);
			CharacterType characterType = this.PrepareSettings.ProtagonistCharacter;
			CharacterType characterType2 = this.PrepareSettings.SidekickCharacter;
			if (characterType == CharacterType.Null)
			{
				characterType = CharacterType.Sonic;
				characterType2 = CharacterType.Tails;
			}
			string resourceKey = this.CharacterTypeResourceKeys[(int)characterType];
			string resourceKey2 = this.CharacterTypeResourceKeys[(int)characterType2];
			ICharacter sidekick = (characterType2 != CharacterType.Null) ? this.CreateCharacter(resourceKey2, position) : null;
			ICharacter character = this.CreateCharacter(resourceKey, playerStartPosition);
			this.SetupCharacters(character, sidekick);
			this.Player.ProtagonistCharacterType = characterType;
			this.Player.SidekickCharacterType = characterType2;
			if (!string.IsNullOrEmpty(this.PrepareSettings.RecordedPlayGhostReadPath))
			{
				this._ghostCharacter = this.CreateGhostCharacter(character, playerStartPosition);
			}
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0002A3B8 File Offset: 0x000285B8
		private void SetupCharacters(ICharacter protagonist, ICharacter sidekick)
		{
			this._camera.ObjectToTrack = (ActiveObject)protagonist;
			this._camera.CentreObjectToTrack();
			protagonist.Player = this.Player;
			protagonist.Path = this.PrepareSettings.StartPath;
			this.Player.Protagonist = protagonist;
			this.Player.ProtagonistGamepadIndex = 0;
			if (sidekick != null)
			{
				sidekick.Player = this.Player;
				sidekick.IsSidekick = true;
				sidekick.Path = this.PrepareSettings.StartPath;
				this.Player.Sidekick = sidekick;
				this.Player.SidekickGamepadIndex = 1;
			}
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0002A458 File Offset: 0x00028658
		private ICharacter CreateCharacter(string resourceKey, Vector2i position)
		{
			ObjectPlacement placement = new ObjectPlacement(resourceKey, this.Map.Layers.IndexOf(this.Map.Layers[this.StartLayerIndex]), position);
			ObjectEntry objectEntry = new ObjectEntry(this, placement);
			this._objectManager.AddObjectEntry(objectEntry);
			ActiveObject activeObject = this._objectManager.ActivateObjectEntry(objectEntry);
			activeObject.LockLifetime = true;
			return (ICharacter)activeObject;
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0002A4C0 File Offset: 0x000286C0
		private GhostCharacterInstance CreateGhostCharacter(ICharacter character, Vector2i position)
		{
			ObjectEntry objectEntry = new ObjectEntry(this, new GhostCharacterType(), this.Map.Layers[this.StartLayerIndex], position, default(Guid));
			GhostCharacterInstance ghostCharacterInstance = (GhostCharacterInstance)this._objectManager.ActivateObjectEntry(objectEntry);
			ghostCharacterInstance.LockLifetime = true;
			ghostCharacterInstance.Initialise(character.Animation.AnimationGroup);
			return ghostCharacterInstance;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0002A524 File Offset: 0x00028724
		public Vector2i GetPlayerStartPosition()
		{
			Vector2i result = this.PrepareSettings.StartPosition ?? this.StartPosition;
			if (this._player.StarpostIndex != -1)
			{
				result = this._player.StarpostPosition;
			}
			return result;
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0002A574 File Offset: 0x00028774
		public void Update()
		{
			if (this.StateFlags.HasFlag(LevelStateFlags.Paused))
			{
				return;
			}
			if (this.StateFlags.HasFlag(LevelStateFlags.TitleCardActive))
			{
				this._titleCard.Update();
				if (this._titleCard.AllowLevelToStart)
				{
					this.StateFlags |= LevelStateFlags.Updating;
					this.StateFlags |= LevelStateFlags.UpdateTime;
					this.StateFlags |= LevelStateFlags.Animating;
				}
				if (this._titleCard.AllowCharacterControl)
				{
					this.StateFlags |= LevelStateFlags.AllowCharacterControl;
				}
				if (this._titleCard.Finished)
				{
					this.StateFlags &= ~LevelStateFlags.TitleCardActive;
				}
				if (this._titleCard.Seamless && this._titleCard.UnlockCamera && this._cameraLockedSeamless)
				{
					this._cameraLockedSeamless = false;
					this.Bounds = this.SeamlessNextBounds;
					this.Camera.MaxVelocity = new Vector2(0.0, 0.0);
				}
			}
			if (this.StateFlags.HasFlag(LevelStateFlags.CompletingStage))
			{
				if (this._player.Sidekick != null && !this._player.Sidekick.IsAirborne)
				{
					this._player.Sidekick.IsWinning = true;
				}
				this._completeHud.Update();
				if (this._completeHud.Finished)
				{
					this.StateFlags &= ~LevelStateFlags.CompletingStage;
					this.StateFlags |= LevelStateFlags.StageCompleted;
					if (this.FinishOnCompleteLevel || this.PrepareSettings.TimeTrial)
					{
						if (!this.SeamlessAct)
						{
							this.FadeOut(LevelState.StageCompleted);
						}
						else
						{
							this.State = LevelState.StageCompleted;
						}
					}
					else
					{
						this._player.Protagonist.IsWinning = false;
						if (this._player.Sidekick != null)
						{
							this._player.Sidekick.IsWinning = false;
						}
					}
				}
			}
			if (this.StateFlags.HasFlag(LevelStateFlags.TimeOver) || this.StateFlags.HasFlag(LevelStateFlags.GameOver))
			{
				this._gameOverHud.Update();
				if (this._gameOverHud.Finished)
				{
					this.StateFlags &= ~(LevelStateFlags.TimeOver | LevelStateFlags.GameOver);
					this.StateFlags |= LevelStateFlags.Dead;
					this.FadeOut(LevelState.Dead);
				}
			}
			PlayRecorder.Entry entry = null;
			if (this._playRecorder.Playing)
			{
				entry = this._playRecorder.GetNextEntry();
			}
			int num;
			if (this.StateFlags.HasFlag(LevelStateFlags.Updating))
			{
				if (entry != null)
				{
					if (string.IsNullOrEmpty(this.PrepareSettings.RecordedPlayGhostReadPath))
					{
						CharacterInputState input = this._player.Protagonist.Input;
						input.Throttle = entry.Direction.X;
						input.VerticalDirection = Math.Sign(entry.Direction.Y);
						if (entry.Action)
						{
							if (input.A == CharacterInputButtonState.Up || input.A == CharacterInputButtonState.Released)
							{
								input.A = CharacterInputButtonState.Pressed;
							}
							else
							{
								input.A = CharacterInputButtonState.Down;
							}
						}
						else if (input.A == CharacterInputButtonState.Down || input.A == CharacterInputButtonState.Pressed)
						{
							input.A = CharacterInputButtonState.Released;
						}
						else
						{
							input.A = CharacterInputButtonState.Up;
						}
					}
					else
					{
						this._ghostCharacter.Set(entry);
						this.ReadPlayerInput();
					}
				}
				else
				{
					this.ReadPlayerInput();
				}
				this.SetObjectLifetimeArea();
				this._objectManager.Update();
				this._particleManager.Update();
				this._waterManager.Update();
				this.UpdateScrollBounds();
				this._camera.Update();
				this.UpdateInverals();
				this.Player.Update();
				if (this.Player.Protagonist.IsDead)
				{
					if (this._player.Lives > 0)
					{
						Player player = this._player;
						num = player.Lives;
						player.Lives = num - 1;
					}
					this.StateFlags &= ~LevelStateFlags.Animating;
					this.StateFlags &= ~LevelStateFlags.Updating;
					this.StateFlags &= ~LevelStateFlags.UpdateTime;
					this.StateFlags |= LevelStateFlags.Dead;
					if (this.StateFlags.HasFlag(LevelStateFlags.TimeUp))
					{
						this.StartTimeOverSequence();
					}
					else if (this.Player.Lives == 0)
					{
						this.StartGameOverSequence();
					}
					else
					{
						this.FadeOut(LevelState.Dead);
					}
				}
				if (this.StateFlags.HasFlag(LevelStateFlags.WaitingForCharacterToWin))
				{
					this.CompleteLevel();
				}
				this.UpdateEarthquake();
			}
			else if (this._earthquakeSampleInstance != null)
			{
				this._earthquakeSampleInstance.Stop();
			}
			this._soundManager.Update();
			if (this.StateFlags.HasFlag(LevelStateFlags.UpdateTime))
			{
				if (this.Time >= this.TimeBeforeDeath - 1)
				{
					this._player.StarpostTime = 0;
					this.StateFlags &= ~LevelStateFlags.UpdateTime;
					this.StateFlags |= LevelStateFlags.TimeUp;
					this.Player.Protagonist.Kill(PlayerDeathCause.TimeOver);
				}
				else
				{
					num = this.Time;
					this.Time = num + 1;
				}
			}
			this._debugContext.Update();
			if (this.StateFlags.HasFlag(LevelStateFlags.FadingOut))
			{
				this._fadeTransition.Update();
				if (this._fadeTransition.Finished)
				{
					this.StateFlags &= ~LevelStateFlags.FadingOut;
					this.State = this._fadeOutToState;
				}
			}
			if (this._playRecorder.Recording)
			{
				CharacterInputState input2 = this._player.Protagonist.Input;
				this._playRecorder.WriteEntry(new PlayRecorder.Entry
				{
					Direction = new Vector2(input2.Throttle, (double)input2.VerticalDirection),
					Action = input2.ABC.HasFlag(CharacterInputButtonState.Down),
					Position = this._player.Protagonist.Position,
					LayerIndex = this.Map.Layers.IndexOf(this._player.Protagonist.Layer),
					State = (int)this._player.Protagonist.StateFlags,
					AnimationIndex = this._player.Protagonist.Animation.Index,
					AnimationFrameIndex = this._player.Protagonist.Animation.CurrentFrameIndex,
					Angle = (float)this._player.Protagonist.ShowAngle
				});
			}
			num = this.Ticks;
			this.Ticks = num + 1;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0002AC23 File Offset: 0x00028E23
		public void HandleInput()
		{
			if (!this._gameContext.Console.IsOpen && this._gameContext.Pressed[0].Start)
			{
				this.TogglePause();
			}
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0002AC58 File Offset: 0x00028E58
		public void Animate()
		{
			if (this.StateFlags.HasFlag(LevelStateFlags.Paused))
			{
				return;
			}
			if (this.StateFlags.HasFlag(LevelStateFlags.Animating))
			{
				if (this.LandscapeAnimating)
				{
					this.TileSet.Animate();
				}
				this.Map.Animate();
				if (this.ObjectsAnimating)
				{
					this._objectManager.Animate();
				}
				this._waterManager.Animate();
				this._hud.Animate();
			}
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0002ACE1 File Offset: 0x00028EE1
		public void TogglePause()
		{
			if (this.StateFlags.HasFlag(LevelStateFlags.Paused))
			{
				this.Unpause();
				return;
			}
			this.Pause();
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0002AD0C File Offset: 0x00028F0C
		public void Pause()
		{
			if (!this.StateFlags.HasFlag(LevelStateFlags.Paused))
			{
				LevelStateFlags levelStateFlags = LevelStateFlags.FadingIn | LevelStateFlags.FadingOut | LevelStateFlags.CompletingStage | LevelStateFlags.Restarting | LevelStateFlags.TitleCardActive | LevelStateFlags.Dead | LevelStateFlags.StageCompleted | LevelStateFlags.TimeOver | LevelStateFlags.GameOver | LevelStateFlags.TimeUp;
				if ((this.StateFlags & levelStateFlags) == (LevelStateFlags)0)
				{
					this.StateFlags |= LevelStateFlags.Paused;
					this.SoundManager.PauseAll();
					if (this._earthquakeSampleInstance != null)
					{
						this._earthquakeSampleInstance.Stop();
					}
				}
			}
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0002AD78 File Offset: 0x00028F78
		public void Unpause()
		{
			if (!this.StateFlags.HasFlag(LevelStateFlags.Paused) && !this.StateFlags.HasFlag(LevelStateFlags.GameOver))
			{
				return;
			}
			if (this.StateFlags.HasFlag(LevelStateFlags.Paused))
			{
				this.SoundManager.ResumeAll();
			}
			this.StateFlags &= ~LevelStateFlags.Paused;
			if (this._earthquakeSampleInstance != null && this._earthquakeIsCurrentlyActive)
			{
				this._earthquakeSampleInstance.Play();
			}
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0002AE14 File Offset: 0x00029014
		private void ReadPlayerInput()
		{
			if (this._gameContext.Console.IsOpen || !this.StateFlags.HasFlag(LevelStateFlags.AllowCharacterControl))
			{
				return;
			}
			Controller controller = this._gameContext.Current[this._player.ProtagonistGamepadIndex];
			Controller controller2 = this._gameContext.Pressed[this._player.ProtagonistGamepadIndex];
			Controller controller3 = this._gameContext.Released[this._player.ProtagonistGamepadIndex];
			this._player.Protagonist.Input = new CharacterInputState
			{
				Throttle = controller.DirectionLeft.X,
				VerticalDirection = Math.Sign(controller.DirectionLeft.Y),
				A = Level.GetButtonState(controller.Action1, controller2.Action1, controller3.Action1),
				B = Level.GetButtonState(controller.Action2, controller2.Action2, controller3.Action2),
				C = Level.GetButtonState(controller.Action3, controller2.Action3, controller3.Action3)
			};
			controller = this._gameContext.Current[this._player.SidekickGamepadIndex];
			controller2 = this._gameContext.Pressed[this._player.SidekickGamepadIndex];
			controller3 = this._gameContext.Released[this._player.SidekickGamepadIndex];
			if (this._player.Sidekick != null)
			{
				this._player.Sidekick.Input = new CharacterInputState
				{
					Throttle = controller.DirectionLeft.X,
					VerticalDirection = Math.Sign(controller.DirectionLeft.Y),
					A = Level.GetButtonState(controller.Action1, controller2.Action1, controller3.Action1),
					B = Level.GetButtonState(controller.Action2, controller2.Action2, controller3.Action2),
					C = Level.GetButtonState(controller.Action3, controller2.Action3, controller3.Action3)
				};
			}
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0002B036 File Offset: 0x00029236
		private static CharacterInputButtonState GetButtonState(bool down, bool pressed, bool released)
		{
			if (!down)
			{
				if (!released)
				{
					return CharacterInputButtonState.Up;
				}
				return CharacterInputButtonState.Released;
			}
			else
			{
				if (!pressed)
				{
					return CharacterInputButtonState.Down;
				}
				return CharacterInputButtonState.Pressed;
			}
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0002B048 File Offset: 0x00029248
		public void Draw(Renderer renderer)
		{
			Viewport viewport = new Viewport(new Rectangle(0.0, 0.0, 1920.0, 1080.0));
			viewport.Bounds = this._camera.Bounds;
			this._levelRenderer.Render(renderer, viewport, this._layerViewOptions);
			this._camera.Draw(renderer);
			if (this.ShowHUD)
			{
				this._hud.Draw(renderer);
			}
			if (this.StateFlags.HasFlag(LevelStateFlags.CompletingStage))
			{
				this._completeHud.Draw(renderer);
			}
			if (this.StateFlags.HasFlag(LevelStateFlags.TimeOver) || this.StateFlags.HasFlag(LevelStateFlags.GameOver))
			{
				this._gameOverHud.Draw(renderer);
			}
			if (this.StateFlags.HasFlag(LevelStateFlags.TitleCardActive))
			{
				this._titleCard.Draw(renderer);
			}
			this.DrawDebugThings(renderer);
			renderer.DeativateRenderer();
			this._fadeTransitionRenderer.Opacity = (float)(-(float)this._fadeTransition.Opacity);
			this._fadeTransitionRenderer.Render();
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0002B194 File Offset: 0x00029394
		private void DrawMusicFrequency(Renderer renderer)
		{
			if (this._soundManager == null)
			{
				return;
			}
			if (this._soundManager.MusicInstance == null)
			{
				return;
			}
			if (this._soundManager.MusicInstance.LastReadBytes == null || this._soundManager.MusicInstance.LastReadBytes.Count == 0)
			{
				return;
			}
			float[] array;
			float[] array2;
			int num = Sample.PCMToSamples(this._soundManager.MusicInstance.LastReadBytes.ToArray<byte>(), out array, out array2);
			ComplexNumber[] array3 = new ComplexNumber[num];
			for (int i = 0; i < num; i++)
			{
				array3[i] = new ComplexNumber((double)array[i], 0.0);
			}
			num = 256;
			array3 = array3.GetRange(0, num);
			FastFourierTransform.TimeToFrequency((int)Math.Log((double)array3.Length, 2.0), array3);
			int num2 = 1024 / (num / 2);
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderQuad(new Colour(76, 0, 0, 0), new Rectangle(0.0, 0.0, 1024.0, 1024.0));
			for (int j = 0; j < array3.Length / 2; j++)
			{
				ComplexNumber complexNumber = array3[j];
				double num3 = 10.0 * Math.Log10(complexNumber.Magnitude);
				double num4 = -90.0;
				if (num3 < num4)
				{
					num3 = num4;
				}
				num3 = num3 / num4 * 1024.0;
				num3 = 1024.0 - num3;
				i2dRenderer.RenderQuad(Colours.White, new Rectangle((double)(j * num2), 1024.0 - num3, (double)num2, num3));
			}
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0002B340 File Offset: 0x00029540
		private void DrawDebugThings(Renderer renderer)
		{
			if (this.ShowCharacterInfo)
			{
				(this.Player.Protagonist as Character).DrawNewCollisionDebug(renderer);
			}
			this._debugContext.Draw(renderer);
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0002B36C File Offset: 0x0002956C
		private void StartTitleCard(bool seamless = false)
		{
			this.StateFlags |= LevelStateFlags.TitleCardActive;
			this._titleCard.Seamless = seamless;
			this._titleCard.Start();
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0002B397 File Offset: 0x00029597
		private void StartCompleteStageHud()
		{
			this.StateFlags |= LevelStateFlags.CompletingStage;
			this._completeHud.Start();
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0002B3B3 File Offset: 0x000295B3
		private void StartTimeOverSequence()
		{
			this.StateFlags &= ~(LevelStateFlags.Animating | LevelStateFlags.Updating);
			this.StateFlags |= LevelStateFlags.TimeOver;
			this._gameOverHud.Start(GameOverHud.Reason.TimeOver);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0002B3E2 File Offset: 0x000295E2
		private void StartGameOverSequence()
		{
			this.StateFlags &= ~(LevelStateFlags.Animating | LevelStateFlags.Updating);
			this.StateFlags |= LevelStateFlags.GameOver;
			this._gameOverHud.Start(GameOverHud.Reason.GameOver);
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0002B411 File Offset: 0x00029611
		public void FadeOut(LevelState finishingState)
		{
			this._soundManager.FadeOutMusic(60);
			this._fadeTransition.BeginFadeOut();
			this.StateFlags |= LevelStateFlags.FadingOut;
			this._fadeOutToState = finishingState;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0002B444 File Offset: 0x00029644
		public void JustAboutToCompleteLevel()
		{
			this.StateFlags &= ~LevelStateFlags.UpdateTime;
			this.Camera.CentreObjectToTrack();
			Rectangle r = this.Bounds;
			r.Left = this.Camera.Bounds.Left;
			r.Right = this.Camera.Bounds.Right;
			this.Bounds = r;
			this._player.RemovePowerups();
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0002B4C8 File Offset: 0x000296C8
		public void CompleteLevel()
		{
			ICharacter protagonist = this._player.Protagonist;
			if (protagonist.IsAirborne)
			{
				this.StateFlags |= LevelStateFlags.WaitingForCharacterToWin;
				return;
			}
			this.StateFlags &= ~LevelStateFlags.WaitingForCharacterToWin;
			protagonist.IsWinning = true;
			this.StartCompleteStageHud();
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0002B51B File Offset: 0x0002971B
		public void SetInterval(int ticks, Action callback)
		{
			this._intervals.Add(new Tuple<int, Action>(this.Ticks + ticks, callback));
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0002B538 File Offset: 0x00029738
		private void UpdateInverals()
		{
			foreach (Tuple<int, Action> tuple in from x in this._intervals
			where x.Item1 <= this.Ticks
			select x)
			{
				tuple.Item2();
			}
			this._intervals.RemoveAll((Tuple<int, Action> x) => x.Item1 == this.Ticks);
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0002B5B0 File Offset: 0x000297B0
		public void ScrollBoundsTo(Rectanglei newBounds, int speed)
		{
			this._targetBounds = newBounds;
			this._boundsScrollSpeed = speed;
			this.Bounds = Rectanglei.Union(this._camera.Bounds, newBounds);
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0002B5DC File Offset: 0x000297DC
		private void UpdateScrollBounds()
		{
			if (!this._cameraLockedSeamless)
			{
				Vector2 maxVelocity = this.Camera.MaxVelocity;
				if (maxVelocity.X < 64.0)
				{
					maxVelocity.X = Math.Min(maxVelocity.X + 0.5, 64.0);
					maxVelocity.Y = maxVelocity.X;
					this.Camera.MaxVelocity = maxVelocity;
				}
			}
			if (this._boundsScrollSpeed != 0)
			{
				Rectanglei bounds = this.Bounds;
				bounds.Left = MathX.GoTowards(bounds.Left, this._targetBounds.Left, this._boundsScrollSpeed);
				bounds.Top = MathX.GoTowards(bounds.Top, this._targetBounds.Top, this._boundsScrollSpeed);
				bounds.Right = MathX.GoTowards(bounds.Right, this._targetBounds.Right, this._boundsScrollSpeed);
				bounds.Bottom = MathX.GoTowards(bounds.Bottom, this._targetBounds.Bottom, this._boundsScrollSpeed);
				this.Bounds = bounds;
				if (bounds == this._targetBounds)
				{
					this._boundsScrollSpeed = 0;
				}
			}
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0002B710 File Offset: 0x00029910
		private void SetObjectLifetimeArea()
		{
			this._objectManager.ResetLifetimeArea();
			int num = 1024;
			foreach (ICharacter character in this._objectManager.Characters)
			{
				this._objectManager.AddLifeArea(new Rectanglei(character.Position.X - num, character.Position.Y - num, num * 2, num * 2));
			}
			Rectanglei area = this._camera.Bounds.Inflate(new Vector2i(num, num));
			this._objectManager.AddLifeArea(area);
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0002B7D4 File Offset: 0x000299D4
		public void CreateScoreObject(int points, Vector2i position)
		{
			if (this.Map.Layers.Count == 0)
			{
				return;
			}
			this._objectManager.AddObject(new ObjectPlacement(this._commonResources.GetResourcePath("pointsobject"), this.Map.Layers.IndexOf(this.Map.Layers.Last<LevelLayer>()), position, new
			{
				Value = points
			}));
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0002B83C File Offset: 0x00029A3C
		public void CreateRandomAnimalObject(int layer, Vector2i position, int direction = -1, int delay = 0)
		{
			if (this.Map.Layers.Count == 0)
			{
				return;
			}
			string randomAnimalResourceKey = this.GetRandomAnimalResourceKey();
			if (string.IsNullOrEmpty(randomAnimalResourceKey))
			{
				return;
			}
			this._objectManager.AddObject(new ObjectPlacement(randomAnimalResourceKey, layer, position, new
			{
				Delay = delay,
				Direction = direction
			}));
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0002B888 File Offset: 0x00029A88
		private string GetRandomAnimalResourceKey()
		{
			string[] array = this.AnimalResourceKeys.ToArray<string>();
			if (array.Length != 0)
			{
				return array[this._random.Next(array.Length)];
			}
			return null;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0002B8B8 File Offset: 0x00029AB8
		public LevelMarker GetMarker(string name)
		{
			LevelMarker result;
			if (this.TryGetMarker(name, out result))
			{
				return result;
			}
			throw new ArgumentException("No marker named " + name);
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0002B8E2 File Offset: 0x00029AE2
		public bool TryGetMarker(string name, out LevelMarker marker)
		{
			return this._markers.TryGetValue(name, out marker);
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0002B8F1 File Offset: 0x00029AF1
		public void SetStartPosition(string markerName)
		{
			this.SetStartPosition(this.GetMarker(markerName));
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0002B900 File Offset: 0x00029B00
		public void SetStartPosition(LevelMarker marker)
		{
			this.StartPosition = marker.Position;
			this.StartLayerIndex = this.Map.Layers.IndexOf(marker.Layer);
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0002B92C File Offset: 0x00029B2C
		public LevelMarker[] GetMarkersWithTag(string tag)
		{
			List<LevelMarker> list = new List<LevelMarker>();
			foreach (LevelMarker levelMarker in this.Map.Markers)
			{
				if (string.Compare(tag, levelMarker.Tag, true) == 0)
				{
					list.Add(levelMarker);
				}
			}
			return list.ToArray();
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0002B99C File Offset: 0x00029B9C
		// (set) Token: 0x06000B3E RID: 2878 RVA: 0x0002B9A4 File Offset: 0x00029BA4
		public bool EarthquakeActive { get; set; }

		// Token: 0x06000B3F RID: 2879 RVA: 0x0002B9AD File Offset: 0x00029BAD
		private void InitialiseEarthquake()
		{
			this._earthquakeIsCurrentlyActive = false;
			this._earthquakeFade = 0.0;
			this.EarthquakeActive = false;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0002B9CC File Offset: 0x00029BCC
		private void StopEarthquake()
		{
			this._earthquakeIsCurrentlyActive = false;
			this._earthquakeFade = 0.0;
			this.EarthquakeActive = false;
			if (this._earthquakeSampleInstance != null)
			{
				this._earthquakeSampleInstance.Stop();
			}
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0002BA00 File Offset: 0x00029C00
		private void UpdateEarthquake()
		{
			this.GameContext.Output[0] = default(GamePadOutputState);
			if (!this.EarthquakeActive && this._earthquakeFade == 0.0)
			{
				return;
			}
			if (this.EarthquakeActive && this._earthquakeFade < 1.0)
			{
				if (this._earthquakeSampleInstance == null)
				{
					SampleInfo loadedResource = this._gameContext.ResourceTree.GetLoadedResource<SampleInfo>(this._commonResources.GetResourcePath("earthquakesample"));
					this._earthquakeSampleInstance = new SampleInstance(this._gameContext, loadedResource);
				}
				if (!this._earthquakeSampleInstance.Playing)
				{
					this._earthquakeSampleInstance.SeekToStart();
					this._earthquakeSampleInstance.Play();
				}
				this._earthquakeIsCurrentlyActive = true;
				this._earthquakeFade = Math.Min(this._earthquakeFade + 0.011111111111111112, 1.0);
			}
			else if (this._earthquakeIsCurrentlyActive && this._earthquakeFade > 0.0)
			{
				this._earthquakeFade -= 0.011111111111111112;
				if (this._earthquakeFade <= 0.0)
				{
					this._earthquakeFade = 0.0;
					this._earthquakeIsCurrentlyActive = false;
					if (this._earthquakeSampleInstance != null)
					{
						this._earthquakeSampleInstance.Stop();
					}
					return;
				}
			}
			this._earthquakeSampleInstance.Volume = this._earthquakeFade;
			int num = (int)(this._earthquakeFade * 16.0);
			this._camera.Shift(this._random.Next(-num, num), this._random.Next(-num, num));
			double val = this._earthquakeFade * 1.0;
			this.GameContext.Output[0] = new GamePadOutputState
			{
				LeftVibration = Math.Min(val, 0.5 + this._random.NextDouble() * 0.5),
				RightVibration = Math.Min(val, 0.5 + this._random.NextDouble() * 0.5)
			};
		}

		// Token: 0x04000645 RID: 1605
		private int TimeBeforeDeath = 36000;

		// Token: 0x04000646 RID: 1606
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x04000647 RID: 1607
		private readonly Player _player;

		// Token: 0x0400065B RID: 1627
		private readonly Random _random = new Random();

		// Token: 0x0400065C RID: 1628
		private readonly FadeTransition _fadeTransition = new FadeTransition(60);

		// Token: 0x0400065D RID: 1629
		private readonly ObjectManager _objectManager;

		// Token: 0x0400065E RID: 1630
		private readonly CollisionTable _collisionTable;

		// Token: 0x0400065F RID: 1631
		private readonly ParticleManager _particleManager;

		// Token: 0x04000660 RID: 1632
		private readonly WaterManager _waterManager;

		// Token: 0x04000661 RID: 1633
		private readonly SoundManager _soundManager;

		// Token: 0x04000662 RID: 1634
		private readonly LightingManager _lightingManager;

		// Token: 0x04000663 RID: 1635
		private readonly Dictionary<string, LevelMarker> _markers = new Dictionary<string, LevelMarker>();

		// Token: 0x04000664 RID: 1636
		private readonly DebugContext _debugContext;

		// Token: 0x04000665 RID: 1637
		private readonly LevelHud _hud;

		// Token: 0x04000666 RID: 1638
		private readonly LevelCompleteHud _completeHud;

		// Token: 0x04000667 RID: 1639
		private readonly GameOverHud _gameOverHud;

		// Token: 0x04000668 RID: 1640
		private ILevelTitleCard _titleCard;

		// Token: 0x04000669 RID: 1641
		private readonly Camera _camera;

		// Token: 0x0400066A RID: 1642
		private readonly LayerViewOptions _layerViewOptions = new LayerViewOptions();

		// Token: 0x0400066B RID: 1643
		private readonly List<Tuple<int, Action>> _intervals = new List<Tuple<int, Action>>();

		// Token: 0x0400066C RID: 1644
		private GhostCharacterInstance _ghostCharacter;

		// Token: 0x0400066D RID: 1645
		private PlayRecorder _playRecorder;

		// Token: 0x0400066E RID: 1646
		private Rectanglei _targetBounds;

		// Token: 0x0400066F RID: 1647
		private int _boundsScrollSpeed;

		// Token: 0x04000670 RID: 1648
		private bool _cameraLockedSeamless;

		// Token: 0x04000671 RID: 1649
		private LevelState _fadeOutToState;

		// Token: 0x0400067E RID: 1662
		private readonly CommonResources _commonResources;

		// Token: 0x0400067F RID: 1663
		private readonly IFadeTransitionRenderer _fadeTransitionRenderer;

		// Token: 0x04000680 RID: 1664
		private readonly ILevelRenderer _levelRenderer;

		// Token: 0x04000681 RID: 1665
		private readonly IReadOnlyList<string> CharacterTypeResourceKeys = new string[]
		{
			null,
			"SONICORCA/OBJECTS/SONIC",
			"SONICORCA/OBJECTS/TAILS",
			"SONICORCA/OBJECTS/KNUCKLES"
		};

		// Token: 0x04000682 RID: 1666
		private const double EarthquakeFadeAmount = 0.011111111111111112;

		// Token: 0x04000683 RID: 1667
		private bool _earthquakeIsCurrentlyActive;

		// Token: 0x04000684 RID: 1668
		private double _earthquakeFade;

		// Token: 0x04000685 RID: 1669
		private SampleInstance _earthquakeSampleInstance;
	}
}
