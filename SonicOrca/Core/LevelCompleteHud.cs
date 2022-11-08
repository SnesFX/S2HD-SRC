using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Audio;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x0200010F RID: 271
	internal class LevelCompleteHud : IDisposable
	{
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x00025F93 File Offset: 0x00024193
		// (set) Token: 0x060009FA RID: 2554 RVA: 0x00025F9B File Offset: 0x0002419B
		public int TimeBonus { get; set; }

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x00025FA4 File Offset: 0x000241A4
		// (set) Token: 0x060009FC RID: 2556 RVA: 0x00025FAC File Offset: 0x000241AC
		public int RingBonus { get; set; }

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x00025FB5 File Offset: 0x000241B5
		// (set) Token: 0x060009FE RID: 2558 RVA: 0x00025FBD File Offset: 0x000241BD
		public int PerfectBonus { get; set; }

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x00025FC6 File Offset: 0x000241C6
		public bool Finished
		{
			get
			{
				return this._state == LevelCompleteHud.State.Finished;
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00025FD1 File Offset: 0x000241D1
		public LevelCompleteHud(Level level)
		{
			this._level = level;
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00025FE0 File Offset: 0x000241E0
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._level.GameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependencies(new string[]
			{
				"SONICORCA/FONTS/TITLE/S2/NAME",
				"SONICORCA/FONTS/TITLE/S2/ACT",
				"SONICORCA/FONTS/HUD",
				"SONICORCA/HUD/TRIANGLE",
				"SONICORCA/HUD/TRIANGLE/TAILS",
				"SONICORCA/HUD/TRIANGLE/KNUCKLES",
				"SONICORCA/MUSIC/JINGLE/STAGECLEAR/S1",
				"SONICORCA/SOUND/TALLY/SWITCH",
				"SONICORCA/SOUND/TALLY/END"
			});
			await this._resourceSession.LoadAsync(ct, false);
			this._captionFont = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/TITLE/S2/NAME");
			this._captionActFont = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/TITLE/S2/ACT");
			this._statisticsFont = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/HUD");
			this._triangleTextureSonic = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TRIANGLE");
			this._triangleTextureTails = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TRIANGLE/TAILS");
			this._triangleTextureKnuckles = resourceTree.GetLoadedResource<ITexture>("SONICORCA/HUD/TRIANGLE/KNUCKLES");
			this._jingleSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/MUSIC/JINGLE/STAGECLEAR/S1");
			this._tallySwitchSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/SOUND/TALLY/SWITCH");
			this._tallyEndSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/SOUND/TALLY/END");
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0002602D File Offset: 0x0002422D
		public void Dispose()
		{
			if (this._resourceSession != null)
			{
				this._resourceSession.Dispose();
			}
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00026044 File Offset: 0x00024244
		public void Start()
		{
			this.TimeBonus = LevelCompleteHud.TimeBonusScores[Math.Min(this._level.Time / 60 / 15, LevelCompleteHud.TimeBonusScores.Count - 1)];
			this.RingBonus = this._level.Player.CurrentRings * 100;
			if (this._level.RingsCollected < this._level.RingsPerfectTarget)
			{
				this._achievedPerfect = false;
				this.PerfectBonus = 0;
			}
			else
			{
				this._achievedPerfect = true;
				this.PerfectBonus = 50000;
			}
			this._total = 0;
			this._state = LevelCompleteHud.State.PreDelay;
			this._level.SoundManager.FadeOutMusic(60);
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x000260F8 File Offset: 0x000242F8
		public void Update()
		{
			switch (this._state)
			{
			case LevelCompleteHud.State.PreDelay:
				this._ticks++;
				if (this._ticks >= 90)
				{
					this._state = LevelCompleteHud.State.FlyIn;
					this._flyTicks = 0;
					this.SetFlyInEasings();
					this._level.SoundManager.PlayJingleOnce(this._jingleSample);
					return;
				}
				break;
			case LevelCompleteHud.State.FlyIn:
				this._flyTicks++;
				if (this._flyTicks >= 340)
				{
					this._state = LevelCompleteHud.State.Banking;
					this._bankPointsDelay = 0;
				}
				this._ticks++;
				return;
			case LevelCompleteHud.State.Banking:
				this._bankPointsDelay--;
				if (this._bankPointsDelay <= 0)
				{
					if (this.BankPoints())
					{
						this._bankPointsDelay = 1;
					}
					else
					{
						this._state = LevelCompleteHud.State.PostBankWait;
						this._bankPointsDelay = 120;
						this._shineTicks = 0;
					}
				}
				this._ticks++;
				return;
			case LevelCompleteHud.State.PostBankWait:
				this._bankPointsDelay--;
				this._shineTicks++;
				if (this._bankPointsDelay <= 0)
				{
					this._state = LevelCompleteHud.State.FlyOut;
					this._flyTicks = 0;
					this.SetFlyOutEasings();
				}
				this._ticks++;
				return;
			case LevelCompleteHud.State.FlyOut:
				this._flyTicks++;
				if (this._flyTicks >= 75)
				{
					this._level.SoundManager.StopAll();
					this._state = LevelCompleteHud.State.Finished;
				}
				this._ticks++;
				break;
			default:
				return;
			}
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x00006325 File Offset: 0x00004525
		public void Animate()
		{
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0002627C File Offset: 0x0002447C
		private void SetFlyInEasings()
		{
			this._captionAFly = LevelCompleteHud.CaptionAFlyIn;
			this._captionBFly = LevelCompleteHud.CaptionBFlyIn;
			this._timeBonusFly = LevelCompleteHud.TimeBonusFlyIn;
			this._ringBonusFly = LevelCompleteHud.RingBonusFlyIn;
			this._perfectBonusFly = LevelCompleteHud.PerfectBonusFlyIn;
			this._totalFly = LevelCompleteHud.TotalFlyIn;
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x000262CC File Offset: 0x000244CC
		private void SetFlyOutEasings()
		{
			this._captionAFly = LevelCompleteHud.CaptionAFlyOut;
			this._captionBFly = LevelCompleteHud.CaptionBFlyOut;
			this._timeBonusFly = LevelCompleteHud.TimeBonusFlyOut;
			this._ringBonusFly = LevelCompleteHud.RingBonusFlyOut;
			this._perfectBonusFly = LevelCompleteHud.PerfectBonusFlyOut;
			this._totalFly = LevelCompleteHud.TotalFlyOut;
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0002631C File Offset: 0x0002451C
		private bool BankPoints()
		{
			int num = Math.Min(this.TimeBonus, 100);
			int num2 = Math.Min(this.RingBonus, 100);
			int num3 = Math.Min(this.PerfectBonus, 100);
			int num4 = num + num2 + num3;
			if (num4 == 0)
			{
				this._level.SoundManager.PlaySound(this._tallyEndSample);
				return false;
			}
			this.TimeBonus -= num;
			this.RingBonus -= num2;
			this.PerfectBonus -= num3;
			this._total += num4;
			this._level.Player.Score += num4;
			this._tallySwitchDelay = (this._tallySwitchDelay + 1) % 2;
			if (this._tallySwitchDelay == 0)
			{
				this._level.SoundManager.PlaySound(this._tallySwitchSample);
			}
			return true;
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x000263F3 File Offset: 0x000245F3
		public void Draw(Renderer renderer)
		{
			if (this._state != LevelCompleteHud.State.PreDelay)
			{
				this.DrawCaption(renderer);
				this.DrawScoreLabels(renderer);
			}
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0002640C File Offset: 0x0002460C
		private void DrawCaption(Renderer renderer)
		{
			double valueAt = this._captionAFly.GetValueAt(this._flyTicks);
			double num = this._captionBFly.GetValueAt(this._flyTicks);
			string str = "SONIC";
			CharacterType protagonistCharacterType = this._level.Player.ProtagonistCharacterType;
			if (protagonistCharacterType != CharacterType.Tails)
			{
				if (protagonistCharacterType == CharacterType.Knuckles)
				{
					str = "KNUCKLES";
				}
			}
			else
			{
				str = "TAILS";
			}
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			fontRenderer.RenderStringWithShadow(str + " GOT", new Rectangle(valueAt, 270.0, 1920.0, 0.0), FontAlignment.MiddleX, this._captionFont, 0);
			double num2 = this._captionFont.MeasureString("THROUGH ACT", default(Rectangle), FontAlignment.Left).Width + (double)(this._captionFont.DefaultWidth / 2);
			double num3 = num2 + this._captionActFont.MeasureString(this._level.CurrentAct.ToString(), default(Rectangle), FontAlignment.Left).Width;
			num += (1920.0 - num3) / 2.0;
			fontRenderer.RenderStringWithShadow("THROUGH ACT", new Rectangle(num, (double)(270 + this._captionFont.Height + 16), 1920.0, 0.0), FontAlignment.Left, this._captionFont, 0);
			fontRenderer.RenderStringWithShadow(this._level.CurrentAct.ToString(), new Rectangle(num + num2, (double)(270 + this._captionFont.Height + 16), 0.0, 0.0), FontAlignment.Left, this._captionActFont, 0);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x000265C4 File Offset: 0x000247C4
		private void DrawScoreLabels(Renderer renderer)
		{
			this.DrawScoreLabel(renderer, "TIME BONUS", this.TimeBonus, this._timeBonusFly.GetValueAt(this._flyTicks), 604.0, 0);
			this.DrawScoreLabel(renderer, "RING BONUS", this.RingBonus, this._ringBonusFly.GetValueAt(this._flyTicks), 668.0, 0);
			if (this._achievedPerfect)
			{
				this.DrawScoreLabel(renderer, "PERFECT BONUS", this.PerfectBonus, this._perfectBonusFly.GetValueAt(this._flyTicks), 732.0, 0);
			}
			byte highlight = (byte)MathX.Clamp(0.0, LevelCompleteHud.TotalShine.GetValueAt(this._shineTicks), 255.0);
			this.DrawScoreLabel(renderer, "TOTAL", this._total, this._totalFly.GetValueAt(this._flyTicks), 796.0, highlight);
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x000266B8 File Offset: 0x000248B8
		private void DrawScoreLabel(Renderer renderer, string caption, int value, double offsetX, double y, byte highlight = 0)
		{
			this.DrawCaption(renderer, caption, new Rectangle(480.0 + offsetX, y, 480.0, 0.0), FontAlignment.MiddleX);
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			FontAlignment fontAlignment = FontAlignment.Right;
			Rectangle boundary = new Rectangle(1380.0 + offsetX, y, 0.0, 0.0);
			if (highlight > 0)
			{
				fontRenderer.RenderStringWithShadow(value.ToString(), boundary, fontAlignment, this._statisticsFont, Colours.White, null, this._statisticsFont.DefaultShadow, new Colour(highlight, highlight, highlight), null);
				return;
			}
			fontRenderer.RenderStringWithShadow(value.ToString(), boundary, fontAlignment, this._statisticsFont, 0);
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00026784 File Offset: 0x00024984
		private void DrawCaption(Renderer renderer, string text, Rectangle boundary, FontAlignment textAlignment)
		{
			Rectangle rectangle = this._statisticsFont.MeasureString(text, boundary, textAlignment);
			ITexture texture = this._triangleTextureSonic;
			CharacterType protagonistCharacterType = this._level.Player.ProtagonistCharacterType;
			if (protagonistCharacterType != CharacterType.Tails)
			{
				if (protagonistCharacterType == CharacterType.Knuckles)
				{
					texture = this._triangleTextureKnuckles;
				}
			}
			else
			{
				texture = this._triangleTextureTails;
			}
			renderer.Get2dRenderer().RenderTexture(texture, new Vector2(rectangle.Right - 8.0, rectangle.Bottom - 7.0), false, false);
			renderer.GetFontRenderer().RenderStringWithShadow(text, boundary, textAlignment, this._statisticsFont, 1);
		}

		// Token: 0x04000593 RID: 1427
		private const string CaptionFontResourceKey = "SONICORCA/FONTS/TITLE/S2/NAME";

		// Token: 0x04000594 RID: 1428
		private const string CaptionActFontResourceKey = "SONICORCA/FONTS/TITLE/S2/ACT";

		// Token: 0x04000595 RID: 1429
		private const string StatisticsFontResourceKey = "SONICORCA/FONTS/HUD";

		// Token: 0x04000596 RID: 1430
		private const string SonicTriangleResourceKey = "SONICORCA/HUD/TRIANGLE";

		// Token: 0x04000597 RID: 1431
		private const string TailsTriangleResourceKey = "SONICORCA/HUD/TRIANGLE/TAILS";

		// Token: 0x04000598 RID: 1432
		private const string KnucklesTriangleResourceKey = "SONICORCA/HUD/TRIANGLE/KNUCKLES";

		// Token: 0x04000599 RID: 1433
		private const string JingleResourceKey = "SONICORCA/MUSIC/JINGLE/STAGECLEAR/S1";

		// Token: 0x0400059A RID: 1434
		private const string TallySwitchResourceKey = "SONICORCA/SOUND/TALLY/SWITCH";

		// Token: 0x0400059B RID: 1435
		private const string TalleEndResourceKey = "SONICORCA/SOUND/TALLY/END";

		// Token: 0x0400059C RID: 1436
		private static IReadOnlyList<int> TimeBonusScores = new int[]
		{
			50000,
			50000,
			10000,
			5000,
			4000,
			4000,
			3000,
			3000,
			2000,
			2000,
			2000,
			2000,
			1000,
			1000,
			1000,
			1000,
			500,
			500,
			500,
			500,
			0
		};

		// Token: 0x0400059D RID: 1437
		private const int BankFrequency = 120;

		// Token: 0x0400059E RID: 1438
		private const int BankAmount = 100;

		// Token: 0x0400059F RID: 1439
		private readonly Level _level;

		// Token: 0x040005A0 RID: 1440
		private ResourceSession _resourceSession;

		// Token: 0x040005A1 RID: 1441
		private Font _captionFont;

		// Token: 0x040005A2 RID: 1442
		private Font _captionActFont;

		// Token: 0x040005A3 RID: 1443
		private Font _statisticsFont;

		// Token: 0x040005A4 RID: 1444
		private ITexture _triangleTextureSonic;

		// Token: 0x040005A5 RID: 1445
		private ITexture _triangleTextureTails;

		// Token: 0x040005A6 RID: 1446
		private ITexture _triangleTextureKnuckles;

		// Token: 0x040005A7 RID: 1447
		private Sample _jingleSample;

		// Token: 0x040005A8 RID: 1448
		private Sample _tallySwitchSample;

		// Token: 0x040005A9 RID: 1449
		private Sample _tallyEndSample;

		// Token: 0x040005AA RID: 1450
		private LevelCompleteHud.State _state;

		// Token: 0x040005AB RID: 1451
		private int _ticks;

		// Token: 0x040005AC RID: 1452
		private int _flyTicks;

		// Token: 0x040005AD RID: 1453
		private int _shineTicks;

		// Token: 0x040005AE RID: 1454
		private int _bankPointsDelay;

		// Token: 0x040005AF RID: 1455
		private bool _achievedPerfect;

		// Token: 0x040005B0 RID: 1456
		private int _total;

		// Token: 0x040005B1 RID: 1457
		private int _tallySwitchDelay;

		// Token: 0x040005B2 RID: 1458
		private EaseTimeline _captionAFly;

		// Token: 0x040005B3 RID: 1459
		private EaseTimeline _captionBFly;

		// Token: 0x040005B4 RID: 1460
		private EaseTimeline _timeBonusFly;

		// Token: 0x040005B5 RID: 1461
		private EaseTimeline _ringBonusFly;

		// Token: 0x040005B6 RID: 1462
		private EaseTimeline _perfectBonusFly;

		// Token: 0x040005B7 RID: 1463
		private EaseTimeline _totalFly;

		// Token: 0x040005BB RID: 1467
		private static readonly EaseTimeline CaptionAFlyIn = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, -1920.0),
			new EaseTimeline.Entry(40, 0.0)
		});

		// Token: 0x040005BC RID: 1468
		private static readonly EaseTimeline CaptionBFlyIn = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, 1920.0),
			new EaseTimeline.Entry(40, 0.0)
		});

		// Token: 0x040005BD RID: 1469
		private static readonly EaseTimeline TimeBonusFlyIn = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(40, 1920.0),
			new EaseTimeline.Entry(80, 0.0)
		});

		// Token: 0x040005BE RID: 1470
		private static readonly EaseTimeline RingBonusFlyIn = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(45, 1920.0),
			new EaseTimeline.Entry(85, 0.0)
		});

		// Token: 0x040005BF RID: 1471
		private static readonly EaseTimeline PerfectBonusFlyIn = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(50, 1920.0),
			new EaseTimeline.Entry(90, 0.0)
		});

		// Token: 0x040005C0 RID: 1472
		private static readonly EaseTimeline TotalFlyIn = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(55, 1920.0),
			new EaseTimeline.Entry(95, 0.0)
		});

		// Token: 0x040005C1 RID: 1473
		private static readonly EaseTimeline TotalFlyOut = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, 0.0),
			new EaseTimeline.Entry(40, 1920.0)
		});

		// Token: 0x040005C2 RID: 1474
		private static readonly EaseTimeline PerfectBonusFlyOut = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(5, 0.0),
			new EaseTimeline.Entry(45, 1920.0)
		});

		// Token: 0x040005C3 RID: 1475
		private static readonly EaseTimeline RingBonusFlyOut = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(10, 0.0),
			new EaseTimeline.Entry(50, 1920.0)
		});

		// Token: 0x040005C4 RID: 1476
		private static readonly EaseTimeline TimeBonusFlyOut = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(15, 0.0),
			new EaseTimeline.Entry(55, 1920.0)
		});

		// Token: 0x040005C5 RID: 1477
		private static readonly EaseTimeline CaptionBFlyOut = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, 0.0),
			new EaseTimeline.Entry(40, 1920.0)
		});

		// Token: 0x040005C6 RID: 1478
		private static readonly EaseTimeline CaptionAFlyOut = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, 0.0),
			new EaseTimeline.Entry(40, -1920.0)
		});

		// Token: 0x040005C7 RID: 1479
		private static readonly EaseTimeline TotalShine = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, 0.0),
			new EaseTimeline.Entry(10, 255.0),
			new EaseTimeline.Entry(20, 0.0)
		});

		// Token: 0x020001EF RID: 495
		private enum State
		{
			// Token: 0x04000B30 RID: 2864
			None,
			// Token: 0x04000B31 RID: 2865
			PreDelay,
			// Token: 0x04000B32 RID: 2866
			FlyIn,
			// Token: 0x04000B33 RID: 2867
			Banking,
			// Token: 0x04000B34 RID: 2868
			PostBankWait,
			// Token: 0x04000B35 RID: 2869
			FlyOut,
			// Token: 0x04000B36 RID: 2870
			Finished
		}
	}
}
