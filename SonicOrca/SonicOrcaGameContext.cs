using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using SonicOrca.Audio;
using SonicOrca.Core;
using SonicOrca.Core.Network;
using SonicOrca.Graphics;
using SonicOrca.Input;
using SonicOrca.Resources;

namespace SonicOrca
{
	// Token: 0x02000097 RID: 151
	public abstract class SonicOrcaGameContext : IDisposable
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0001921D File Offset: 0x0001741D
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x00019224 File Offset: 0x00017424
		public static SonicOrcaGameContext Singleton { get; private set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x0001922C File Offset: 0x0001742C
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x00019233 File Offset: 0x00017433
		public static bool IsMaxPerformance { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0001923B File Offset: 0x0001743B
		public Renderer Renderer
		{
			get
			{
				return this._renderer;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x00019243 File Offset: 0x00017443
		public IPlatform Platform
		{
			get
			{
				return this._platform;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0001924B File Offset: 0x0001744B
		public AudioContext Audio
		{
			get
			{
				return this._platform.Audio;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x00019258 File Offset: 0x00017458
		public InputContext Input
		{
			get
			{
				return this._platform.Input;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00019265 File Offset: 0x00017465
		public WindowContext Window
		{
			get
			{
				return this._platform.Window;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x00019272 File Offset: 0x00017472
		public ResourceTree ResourceTree
		{
			get
			{
				return this._resourceTree;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0001927A File Offset: 0x0001747A
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x00019282 File Offset: 0x00017482
		public int UpdateCount { get; private set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0001928B File Offset: 0x0001748B
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x00019293 File Offset: 0x00017493
		public int DrawCount { get; private set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0001929C File Offset: 0x0001749C
		// (set) Token: 0x060004F6 RID: 1270 RVA: 0x000192A4 File Offset: 0x000174A4
		public bool Finish { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x000192AD File Offset: 0x000174AD
		// (set) Token: 0x060004F8 RID: 1272 RVA: 0x000192B5 File Offset: 0x000174B5
		public int TargetFrameRate { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x000192BE File Offset: 0x000174BE
		public int LastUps
		{
			get
			{
				return this._fpsMonitorLastUps;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060004FA RID: 1274 RVA: 0x000192C6 File Offset: 0x000174C6
		public int LastFps
		{
			get
			{
				return this._fpsMonitorLastFps;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x000192CE File Offset: 0x000174CE
		// (set) Token: 0x060004FC RID: 1276 RVA: 0x000192D6 File Offset: 0x000174D6
		public bool Catchup
		{
			get
			{
				return this._catchup;
			}
			set
			{
				this._catchup = value;
				this.ResetCatchup();
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x000192E5 File Offset: 0x000174E5
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x000192ED File Offset: 0x000174ED
		public SonicOrcaConsole Console { get; private set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x000192F6 File Offset: 0x000174F6
		public NetworkManager NetworkManager
		{
			get
			{
				return this._networkManager;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x000192FE File Offset: 0x000174FE
		// (set) Token: 0x06000501 RID: 1281 RVA: 0x00019306 File Offset: 0x00017506
		public bool ForceHD { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0001930F File Offset: 0x0001750F
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x00019317 File Offset: 0x00017517
		public IniConfiguration Configuration { get; protected set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x00019320 File Offset: 0x00017520
		public IReadOnlyList<Controller> Current
		{
			get
			{
				return this._controllersCurrent;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x00019328 File Offset: 0x00017528
		public IReadOnlyList<Controller> Pressed
		{
			get
			{
				return this._controllersPressed;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x00019330 File Offset: 0x00017530
		public IReadOnlyList<Controller> Released
		{
			get
			{
				return this._controllersReleased;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x00019338 File Offset: 0x00017538
		public IList<GamePadOutputState> Output
		{
			get
			{
				return this._controllersOutput;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x00019340 File Offset: 0x00017540
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x00019348 File Offset: 0x00017548
		public string UserDataDirectory { get; protected set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x00019351 File Offset: 0x00017551
		public IEnumerable<Controller> Controllers
		{
			get
			{
				return this._controllersCurrent.Concat(this._controllersPressed).Concat(this._controllersReleased);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600050B RID: 1291
		public abstract IAudioSettings AudioSettings { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600050C RID: 1292
		public abstract IVideoSettings VideoSettings { get; }

		// Token: 0x0600050D RID: 1293 RVA: 0x00019370 File Offset: 0x00017570
		public SonicOrcaGameContext(IPlatform platform)
		{
			SonicOrcaGameContext.Singleton = this;
			this._platform = platform;
			this._resourceTree = new ResourceTree();
			this.TargetFrameRate = 60;
			this.ForceHD = true;
			for (int i = 0; i < 4; i++)
			{
				this._controllersCurrent[i] = new Controller(this, i, InputStateEventType.Current);
				this._controllersPressed[i] = new Controller(this, i, InputStateEventType.Pressed);
				this._controllersReleased[i] = new Controller(this, i, InputStateEventType.Released);
			}
			this.Console = new SonicOrcaConsole(this);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0001942D File Offset: 0x0001762D
		public virtual void Initialise()
		{
			this.Window.HideCursorIfIdle = true;
			this._renderer = this.CreateRenderer();
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void Dispose()
		{
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00019447 File Offset: 0x00017647
		public void Run()
		{
			this.ResetCatchup();
			this.Finish = false;
			while (!this.Finish)
			{
				this.MainLoopIteration();
			}
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00019468 File Offset: 0x00017668
		private void MainLoopIteration()
		{
			int tickCount = Environment.TickCount;
			if (this._stopwatch == null)
			{
				this._stopwatch = new Stopwatch();
			}
			this._stopwatch.Start();
			if (this._catchup)
			{
				this.UpdateCatchup();
			}
			else
			{
				this.Update();
			}
			if (this._dirty)
			{
				this.Draw(this._renderer);
			}
			this.MeasureFrameRate();
			if (!SonicOrcaGameContext.IsMaxPerformance)
			{
				while (this._stopwatch.ElapsedTicks <= Stopwatch.Frequency / 60L)
				{
					if (this._stopwatch.ElapsedTicks < Stopwatch.Frequency / 70L)
					{
						Thread.Sleep(1);
					}
				}
			}
			this._stopwatch.Reset();
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00019510 File Offset: 0x00017710
		private void MeasureFrameRate()
		{
			if (Environment.TickCount - this._fpsMonitorLastTick > 1000)
			{
				this._fpsMonitorLastUps = this.UpdateCount - this._fpsMonitorUpdateCount;
				this._fpsMonitorLastFps = this.DrawCount - this._fpsMonitorDrawCount;
				this._fpsMonitorLastTick = Environment.TickCount;
				this._fpsMonitorUpdateCount = this.UpdateCount;
				this._fpsMonitorDrawCount = this.DrawCount;
			}
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00019579 File Offset: 0x00017779
		public void ResetCatchup()
		{
			this._catchupTick = Environment.TickCount;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00019588 File Offset: 0x00017788
		private void UpdateCatchup()
		{
			int i = (Environment.TickCount - this._catchupTick) * this.TargetFrameRate / 1000;
			if (i > this._lastFrameTick + this.TargetFrameRate * 2)
			{
				this._lastUpdateTick = 0;
				this._catchupTick = Environment.TickCount;
				this.Update();
				return;
			}
			while (i > this._lastUpdateTick)
			{
				this.Update();
				this._lastUpdateTick++;
			}
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x000195F8 File Offset: 0x000177F8
		public void Update()
		{
			this.Window.Update();
			if (this.Window.Finished)
			{
				this.Finish = true;
			}
			this.Audio.Update();
			this.Input.Update();
			this.OnUpdate();
			this.Input.UpdatePressedReleased();
			this.OnUpdateStep();
			this._dirty = true;
			int updateCount = this.UpdateCount;
			this.UpdateCount = updateCount + 1;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnUpdateStep()
		{
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00019668 File Offset: 0x00017868
		public void Draw(Renderer renderer)
		{
			this.Window.BeginRender();
			this.OnDraw();
			renderer.DeativateRenderer();
			this.Window.EndRender();
			int drawCount = this.DrawCount;
			this.DrawCount = drawCount + 1;
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnDraw()
		{
		}

		// Token: 0x0600051A RID: 1306
		protected abstract Renderer CreateRenderer();

		// Token: 0x0600051B RID: 1307
		protected internal abstract ILevelRenderer CreateLevelRenderer(Level level);

		// Token: 0x0400030A RID: 778
		private readonly IPlatform _platform;

		// Token: 0x0400030B RID: 779
		private readonly ResourceTree _resourceTree;

		// Token: 0x0400030D RID: 781
		private bool _catchup;

		// Token: 0x0400030E RID: 782
		private bool _dirty;

		// Token: 0x0400030F RID: 783
		private int _catchupTick;

		// Token: 0x04000310 RID: 784
		private int _lastUpdateTick;

		// Token: 0x04000311 RID: 785
		private int _lastFrameTick;

		// Token: 0x04000312 RID: 786
		private int _fpsMonitorLastTick;

		// Token: 0x04000313 RID: 787
		private int _fpsMonitorLastUps;

		// Token: 0x04000314 RID: 788
		private int _fpsMonitorLastFps;

		// Token: 0x04000315 RID: 789
		private int _fpsMonitorUpdateCount;

		// Token: 0x04000316 RID: 790
		private int _fpsMonitorDrawCount;

		// Token: 0x04000317 RID: 791
		private Renderer _renderer;

		// Token: 0x04000318 RID: 792
		private Stopwatch _stopwatch;

		// Token: 0x0400031D RID: 797
		private readonly NetworkManager _networkManager = new NetworkManager();

		// Token: 0x0400031E RID: 798
		protected IFramebuffer _canvas;

		// Token: 0x04000321 RID: 801
		private Controller[] _controllersCurrent = new Controller[4];

		// Token: 0x04000322 RID: 802
		private Controller[] _controllersPressed = new Controller[4];

		// Token: 0x04000323 RID: 803
		private Controller[] _controllersReleased = new Controller[4];

		// Token: 0x04000324 RID: 804
		private GamePadOutputState[] _controllersOutput = new GamePadOutputState[4];
	}
}
