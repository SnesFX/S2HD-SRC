using System;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000111 RID: 273
	internal class Sonic2LevelTitleCard : ILevelTitleCard, IDisposable
	{
		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x00027374 File Offset: 0x00025574
		// (set) Token: 0x06000A1F RID: 2591 RVA: 0x0002737C File Offset: 0x0002557C
		public bool AllowLevelToStart { get; private set; }

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000A20 RID: 2592 RVA: 0x00027385 File Offset: 0x00025585
		// (set) Token: 0x06000A21 RID: 2593 RVA: 0x0002738D File Offset: 0x0002558D
		public bool AllowCharacterControl { get; private set; }

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000A22 RID: 2594 RVA: 0x00027396 File Offset: 0x00025596
		// (set) Token: 0x06000A23 RID: 2595 RVA: 0x0002739E File Offset: 0x0002559E
		public bool Finished { get; private set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000A24 RID: 2596 RVA: 0x000273A7 File Offset: 0x000255A7
		// (set) Token: 0x06000A25 RID: 2597 RVA: 0x000273AF File Offset: 0x000255AF
		public bool Seamless { get; set; }

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x000273B8 File Offset: 0x000255B8
		// (set) Token: 0x06000A27 RID: 2599 RVA: 0x000273C0 File Offset: 0x000255C0
		public bool UnlockCamera { get; set; }

		// Token: 0x06000A28 RID: 2600 RVA: 0x000273C9 File Offset: 0x000255C9
		public Sonic2LevelTitleCard(Level level)
		{
			this._level = level;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x000273D8 File Offset: 0x000255D8
		public async Task LoadAsync(ResourceTree resourceTree, CancellationToken ct = default(CancellationToken))
		{
			if (this._disposed)
			{
				throw new ObjectDisposedException("Sonic2LevelTitleCard");
			}
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependencies(new string[]
			{
				"SONICORCA/HUD/TITLECARD/LOGO",
				"SONICORCA/HUD/TITLECARD/LOGODARK",
				"SONICORCA/HUD/TITLECARD/TRIANGLE",
				"SONICORCA/HUD/TITLECARD/PATTERNA",
				"SONICORCA/HUD/TITLECARD/PATTERNB",
				"SONICORCA/HUD/TITLECARD/GAME",
				"SONICORCA/FONTS/TITLE/S2/NAME",
				"SONICORCA/FONTS/TITLE/S2/ACT"
			});
			await this._resourceSession.LoadAsync(ct, false);
			this._logoTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TITLECARD/LOGO");
			this._logoDarkTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TITLECARD/LOGODARK");
			this._triangleTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TITLECARD/TRIANGLE");
			this._patternATexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TITLECARD/PATTERNA");
			this._patternBTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TITLECARD/PATTERNB");
			this._gameTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TITLECARD/GAME");
			this._levelNameFont = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/TITLE/S2/NAME");
			this._levelActFont = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/TITLE/S2/ACT");
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0002742D File Offset: 0x0002562D
		public void Dispose()
		{
			if (this._resourceSession != null)
			{
				this._resourceSession.Unload();
			}
			this._disposed = true;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00027449 File Offset: 0x00025649
		public void Start()
		{
			this._ticks = 0;
			this.AllowLevelToStart = false;
			this.AllowCharacterControl = false;
			this.UnlockCamera = false;
			this.Finished = false;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00027470 File Offset: 0x00025670
		public void Update()
		{
			if (this.Finished)
			{
				return;
			}
			if (this.Seamless)
			{
				this.AllowLevelToStart = true;
				if (this._ticks >= 90)
				{
					this.UnlockCamera = true;
				}
			}
			if (this._ticks >= 120)
			{
				this.AllowLevelToStart = true;
			}
			if (this._ticks >= 145)
			{
				this.AllowCharacterControl = true;
			}
			if (this._ticks >= 250)
			{
				this.Finished = true;
			}
			this._ticks++;
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x000274F0 File Offset: 0x000256F0
		public void Draw(Renderer renderer)
		{
			if (this.Finished)
			{
				return;
			}
			if (this._ticks < 60 && !this.Seamless)
			{
				renderer.Get2dRenderer().RenderQuad(Colours.Black, new Rectangle(0.0, 0.0, 1920.0, 1080.0));
			}
			if (!this.Seamless)
			{
				this.DrawBlueBlock(renderer);
				this.DrawYellowBlock(renderer);
				this.DrawRedBlock(renderer);
			}
			else
			{
				this.DrawBlueBlockSeamless(renderer);
				this.DrawYellowBlockSeamless(renderer);
				this.DrawRedBlockSeamless(renderer);
			}
			this.DrawLevelName(renderer);
			this.DrawZoneAct(renderer);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00027594 File Offset: 0x00025794
		private void DrawBlueBlock(Renderer renderer)
		{
			int num = (int)Sonic2LevelTitleCard.BlueBlockY.GetValueAt(this._ticks);
			int num2 = 63 - this._ticks % 64;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderQuad(new Colour(0, 61, 155), new Rectangle(1502.0, (double)(num - 1080), 418.0, 1080.0));
			i2dRenderer.RenderQuad(new Colour(0, 80, 170), new Rectangle(0.0, (double)(num - 1080), 1502.0, 1080.0));
			i2dRenderer.Colour = new Colour(0, 80, 170);
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ClipRectangle = new Rectangle(0.0, 0.0, 1920.0, (double)num);
				for (int i = -1; i < 17; i++)
				{
					i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle(1502.0, (double)(num - 1080 + i * 64 + num2), 32.0, 64.0), false, false);
				}
			}
			i2dRenderer.Colour = Colours.White;
			i2dRenderer.RenderTexture(this._logoTexture, new Vector2(1466.0, (double)(num - 734)), false, false);
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x0002771C File Offset: 0x0002591C
		private void DrawYellowBlock(Renderer renderer)
		{
			int num = (int)Sonic2LevelTitleCard.YellowBlockX.GetValueAt(this._ticks);
			int num2 = 127 - this._ticks % 128;
			int num3 = this._ticks % 128;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderQuad(new Colour(byte.MaxValue, byte.MaxValue, 0), new Rectangle((double)num, 736.0, 1920.0, 344.0));
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ClipRectangle = new Rectangle((double)num, 736.0, (double)(1920 - num), 344.0);
				i2dRenderer.Colour = Colours.White;
				for (int i = -1; i < 16; i++)
				{
					i2dRenderer.RenderTexture(this._patternATexture, new Rectangle((double)(num + i * 128 + num2), 736.0, 128.0, 128.0), false, false);
				}
				i2dRenderer.Colour = new Colour(byte.MaxValue, 234, 0);
				for (int j = -1; j < 16; j++)
				{
					i2dRenderer.RenderTexture(this._patternBTexture, new Rectangle((double)(num + j * 128 + num3), 892.0, 128.0, 128.0), false, false);
				}
				i2dRenderer.Colour = Colours.White;
				i2dRenderer.RenderTexture(this._gameTexture, new Vector2((double)(num + 1347), 800.0), false, false);
			}
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x000278D8 File Offset: 0x00025AD8
		private void DrawRedBlock(Renderer renderer)
		{
			int num = (int)Sonic2LevelTitleCard.RedBlockX.GetValueAt(this._ticks);
			int[] array = new int[]
			{
				this._ticks * 4 % 256,
				this._ticks * 2 % 128,
				this._ticks % 64
			};
			int num2 = num - 808;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderQuad(new Colour(224, 0, 0), new Rectangle((double)(num2 + 454), 0.0, 320.0, 1080.0));
			i2dRenderer.RenderQuad(new Colour(191, 0, 0), new Rectangle((double)(num2 + 126), 0.0, 328.0, 1080.0));
			i2dRenderer.RenderQuad(new Colour(168, 0, 0), new Rectangle((double)num2, 0.0, 126.0, 1080.0));
			for (int i = -1; i < 17; i++)
			{
				i2dRenderer.Colour = Colours.Black;
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 774), (double)(i * 64 + 16 + array[2]), 32.0, 64.0), false, false);
				i2dRenderer.Colour = new Colour(224, 0, 0);
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 774), (double)(i * 64 + array[2]), 32.0, 64.0), false, false);
			}
			i2dRenderer.Colour = new Colour(191, 0, 0);
			for (int j = -1; j < 9; j++)
			{
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 454), (double)(j * 128 + array[1]), 64.0, 128.0), false, false);
			}
			i2dRenderer.Colour = new Colour(168, 0, 0);
			for (int k = -1; k < 5; k++)
			{
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 126), (double)(k * 256 + array[0]), 128.0, 256.0), false, false);
			}
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00027B3C File Offset: 0x00025D3C
		private void DrawBlueBlockSeamless(Renderer renderer)
		{
			int num = (int)Sonic2LevelTitleCard.BlueBlockY.GetValueAt(this._ticks);
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.BlendMode = BlendMode.Additive;
			i2dRenderer.Colour = Colours.White;
			i2dRenderer.RenderTexture(this._logoDarkTexture, new Vector2(1466.0, (double)(num - 734)), false, false);
			i2dRenderer.BlendMode = BlendMode.Alpha;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00027BA0 File Offset: 0x00025DA0
		private void DrawYellowBlockSeamless(Renderer renderer)
		{
			int num = (int)Sonic2LevelTitleCard.YellowBlockX.GetValueAt(this._ticks) + 600;
			int num2 = 127 - this._ticks % 128;
			int num3 = this._ticks % 128;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderQuad(Colours.Black, new Rectangle((double)num, 816.0, 1920.0, 16.0));
			i2dRenderer.RenderQuad(Colours.Yellow, new Rectangle((double)num, 736.0, 1920.0, 80.0));
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ClipRectangle = new Rectangle((double)num, 736.0, (double)(1920 - num), 128.0);
				i2dRenderer.Colour = Colours.White;
				for (int i = -1; i < 16; i++)
				{
					i2dRenderer.RenderTexture(this._patternATexture, new Rectangle((double)(num + i * 128 + num2), 718.0, 128.0, 128.0), false, false);
				}
				i2dRenderer.Colour = new Colour(byte.MaxValue, 234, 0);
				for (int j = -1; j < 16; j++)
				{
					i2dRenderer.RenderTexture(this._patternBTexture, new Rectangle((double)(num + j * 128 + num3), 874.0, 128.0, 128.0), false, false);
				}
				i2dRenderer.Colour = Colours.White;
				i2dRenderer.RenderTexture(this._gameTexture, new Vector2((double)(num + 770), 782.0), false, false);
			}
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00027D84 File Offset: 0x00025F84
		private void DrawRedBlockSeamless(Renderer renderer)
		{
			int num = (int)Sonic2LevelTitleCard.RedBlockX.GetValueAt(this._ticks);
			int[] array = new int[]
			{
				63 - this._ticks % 64,
				this._ticks * 2 % 128,
				this._ticks % 64
			};
			int num2 = num - 808;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderQuad(new Colour(224, 0, 0), new Rectangle((double)(num2 + 454), 0.0, 320.0, 1080.0));
			i2dRenderer.RenderQuad(new Colour(168, 0, 0), new Rectangle((double)(num2 + 432), 0.0, 168.0, 1080.0));
			for (int i = -1; i < 17; i++)
			{
				i2dRenderer.Colour = Colours.Black;
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 774), (double)(i * 64 + 16 + array[2]), 32.0, 64.0), false, false);
				i2dRenderer.Colour = new Colour(224, 0, 0);
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 774), (double)(i * 64 + array[2]), 32.0, 64.0), false, false);
			}
			i2dRenderer.Colour = new Colour(168, 0, 0);
			for (int j = -1; j < 9; j++)
			{
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 600), (double)(j * 128 + array[1]), 64.0, 128.0), false, false);
			}
			for (int k = -1; k < 17; k++)
			{
				i2dRenderer.Colour = Colours.Black;
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 400), (double)(k * 64 + 16 + array[0]), 32.0, 64.0), true, false);
				i2dRenderer.Colour = new Colour(168, 0, 0);
				i2dRenderer.RenderTexture(this._triangleTexture, new Rectangle((double)(num2 + 400), (double)(k * 64 + array[0]), 32.0, 64.0), true, false);
			}
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00028000 File Offset: 0x00026200
		private void DrawLevelName(Renderer renderer)
		{
			int num = (int)Sonic2LevelTitleCard.LevelNameX.GetValueAt(this._ticks);
			byte b = (byte)MathX.Clamp(0.0, Sonic2LevelTitleCard.LevelNameHighlight.GetValueAt(this._ticks), 255.0);
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			num -= (int)this._levelNameFont.MeasureString(this._level.Name.ToUpper(), new Rectangle((double)num, 342.0, 0.0, 0.0), FontAlignment.Left).Width;
			fontRenderer.RenderStringWithShadow(this._level.Name.ToUpper(), new Rectangle((double)num, 342.0, 0.0, 0.0), FontAlignment.Left, this._levelNameFont, Colours.White, (b > 0) ? null : new int?(0), this._levelNameFont.DefaultShadow, new Colour(b, b, b), null);
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x0002810C File Offset: 0x0002630C
		private void DrawZoneAct(Renderer renderer)
		{
			Rectangle boundary = new Rectangle(Sonic2LevelTitleCard.ZoneActX.GetValueAt(this._ticks) - 16.0, 486.0, 256.0, 256.0);
			byte b = (byte)MathX.Clamp(0.0, Sonic2LevelTitleCard.ZoneActHighlight.GetValueAt(this._ticks), 255.0);
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			if (this._level.ShowAsAct)
			{
				boundary.X -= this._levelActFont.MeasureString(this._level.CurrentAct.ToString(), boundary, FontAlignment.Left).Width;
				fontRenderer.RenderStringWithShadow(this._level.CurrentAct.ToString(), boundary, FontAlignment.Left, this._levelActFont, Colours.White, new int?(0), this._levelActFont.DefaultShadow, new Colour(b, b, b), null);
				if (b > 0)
				{
					fontRenderer.RenderString(this._level.CurrentAct.ToString(), boundary, FontAlignment.Left, this._levelActFont, new Colour(b, byte.MaxValue, byte.MaxValue, byte.MaxValue), null);
				}
			}
			if (this._level.ShowAsZone)
			{
				boundary.X -= this._levelNameFont.MeasureString("ZONE", boundary, FontAlignment.Left).Width;
				fontRenderer.RenderStringWithShadow("ZONE", boundary, FontAlignment.Left, this._levelNameFont, Colours.White, (b > 0) ? null : new int?(0), this._levelNameFont.DefaultShadow, new Colour(b, b, b), null);
			}
		}

		// Token: 0x040005E2 RID: 1506
		private const string LogoResourceKey = "SONICORCA/HUD/TITLECARD/LOGO";

		// Token: 0x040005E3 RID: 1507
		private const string LogoDarkResourceKey = "SONICORCA/HUD/TITLECARD/LOGODARK";

		// Token: 0x040005E4 RID: 1508
		private const string TriangleResourceKey = "SONICORCA/HUD/TITLECARD/TRIANGLE";

		// Token: 0x040005E5 RID: 1509
		private const string PatternAResourceKey = "SONICORCA/HUD/TITLECARD/PATTERNA";

		// Token: 0x040005E6 RID: 1510
		private const string PatternBResourceKey = "SONICORCA/HUD/TITLECARD/PATTERNB";

		// Token: 0x040005E7 RID: 1511
		private const string GameResourceKey = "SONICORCA/HUD/TITLECARD/GAME";

		// Token: 0x040005E8 RID: 1512
		private const string LevelNameFontResourceKey = "SONICORCA/FONTS/TITLE/S2/NAME";

		// Token: 0x040005E9 RID: 1513
		private const string ActFontResourceKey = "SONICORCA/FONTS/TITLE/S2/ACT";

		// Token: 0x040005EA RID: 1514
		private readonly Level _level;

		// Token: 0x040005EB RID: 1515
		private ResourceSession _resourceSession;

		// Token: 0x040005EC RID: 1516
		private ITexture _logoTexture;

		// Token: 0x040005ED RID: 1517
		private ITexture _logoDarkTexture;

		// Token: 0x040005EE RID: 1518
		private ITexture _triangleTexture;

		// Token: 0x040005EF RID: 1519
		private ITexture _patternATexture;

		// Token: 0x040005F0 RID: 1520
		private ITexture _patternBTexture;

		// Token: 0x040005F1 RID: 1521
		private ITexture _gameTexture;

		// Token: 0x040005F2 RID: 1522
		private Font _levelNameFont;

		// Token: 0x040005F3 RID: 1523
		private Font _levelActFont;

		// Token: 0x040005F4 RID: 1524
		private bool _disposed;

		// Token: 0x040005F5 RID: 1525
		private int _ticks;

		// Token: 0x040005F6 RID: 1526
		private static readonly EaseTimeline BlueBlockY = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, 0.0),
			new EaseTimeline.Entry(18, 1080.0),
			new EaseTimeline.Entry(146, 1080.0),
			new EaseTimeline.Entry(156, 0.0)
		});

		// Token: 0x040005F7 RID: 1527
		private static readonly EaseTimeline YellowBlockX = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(12, 1920.0),
			new EaseTimeline.Entry(42, 0.0),
			new EaseTimeline.Entry(134, 0.0),
			new EaseTimeline.Entry(150, 1920.0)
		});

		// Token: 0x040005F8 RID: 1528
		private static readonly EaseTimeline RedBlockX = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(36, 0.0),
			new EaseTimeline.Entry(50, 808.0),
			new EaseTimeline.Entry(132, 808.0),
			new EaseTimeline.Entry(140, 0.0)
		});

		// Token: 0x040005F9 RID: 1529
		private static readonly EaseTimeline LevelNameX = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(32, 3840.0),
			new EaseTimeline.Entry(72, 1680.0),
			new EaseTimeline.Entry(190, 1440.0),
			new EaseTimeline.Entry(210, -16.0)
		});

		// Token: 0x040005FA RID: 1530
		private static readonly EaseTimeline ZoneActX = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(42, 0.0),
			new EaseTimeline.Entry(72, 1440.0),
			new EaseTimeline.Entry(190, 1680.0),
			new EaseTimeline.Entry(210, 3840.0)
		});

		// Token: 0x040005FB RID: 1531
		private static readonly EaseTimeline LevelNameHighlight = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(90, 0.0),
			new EaseTimeline.Entry(100, 255.0),
			new EaseTimeline.Entry(110, 0.0)
		});

		// Token: 0x040005FC RID: 1532
		private static readonly EaseTimeline ZoneActHighlight = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(110, 0.0),
			new EaseTimeline.Entry(120, 255.0),
			new EaseTimeline.Entry(130, 0.0)
		});
	}
}
