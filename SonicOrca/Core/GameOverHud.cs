using System;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Audio;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x0200010D RID: 269
	public class GameOverHud : IDisposable
	{
		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x00025CF9 File Offset: 0x00023EF9
		// (set) Token: 0x060009E6 RID: 2534 RVA: 0x00025D01 File Offset: 0x00023F01
		public bool Finished { get; private set; }

		// Token: 0x060009E7 RID: 2535 RVA: 0x00025D0A File Offset: 0x00023F0A
		public GameOverHud(Level level)
		{
			this._level = level;
			this._resourceSession = new ResourceSession(level.GameContext.ResourceTree);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00025D30 File Offset: 0x00023F30
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._resourceSession.ResourceTree;
			this._resourceSession.PushDependencies(new string[]
			{
				"SONICORCA/FONTS/METALIC",
				"SONICORCA/MUSIC/JINGLE/GAMEOVER/S1"
			});
			await this._resourceSession.LoadAsync(ct, false);
			this._font = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/METALIC");
			this._jingle = resourceTree.GetLoadedResource<Sample>("SONICORCA/MUSIC/JINGLE/GAMEOVER/S1");
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00025D7D File Offset: 0x00023F7D
		public void Dispose()
		{
			this._resourceSession.Dispose();
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00025D8A File Offset: 0x00023F8A
		public void Start(GameOverHud.Reason reason)
		{
			this._ticks = 0;
			this._reason = reason;
			this.Finished = false;
			this._level.SoundManager.StopAll();
			this._level.SoundManager.PlayJingleOnce(this._jingle);
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x00025DC7 File Offset: 0x00023FC7
		public void Update()
		{
			this._ticks++;
			if (this._ticks >= 900)
			{
				this.Finished = true;
			}
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x00025DEC File Offset: 0x00023FEC
		public void Draw(Renderer renderer)
		{
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			int num = this._font.DefaultWidth / 2;
			fontRenderer.RenderStringWithShadow((this._reason == GameOverHud.Reason.GameOver) ? "GAME" : "TIME", new Rectangle(GameOverHud.LeftFly.GetValueAt(this._ticks) - (double)num, 0.0, 0.0, 1080.0), (FontAlignment)6, this._font, Colours.White, null);
			fontRenderer.RenderStringWithShadow("OVER", new Rectangle(GameOverHud.RightFly.GetValueAt(this._ticks) + (double)num, 0.0, 0.0, 1080.0), FontAlignment.MiddleY, this._font, Colours.White, null);
		}

		// Token: 0x04000586 RID: 1414
		private const string FontResourceKey = "SONICORCA/FONTS/METALIC";

		// Token: 0x04000587 RID: 1415
		private const string JingleResourceKey = "SONICORCA/MUSIC/JINGLE/GAMEOVER/S1";

		// Token: 0x04000588 RID: 1416
		private const int TotalTime = 900;

		// Token: 0x04000589 RID: 1417
		private const int FlyTime = 15;

		// Token: 0x0400058A RID: 1418
		private static readonly EaseTimeline LeftFly = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, 0.0),
			new EaseTimeline.Entry(15, 960.0),
			new EaseTimeline.Entry(885, 960.0),
			new EaseTimeline.Entry(900, 0.0)
		});

		// Token: 0x0400058B RID: 1419
		private static readonly EaseTimeline RightFly = new EaseTimeline(new EaseTimeline.Entry[]
		{
			new EaseTimeline.Entry(0, 1920.0),
			new EaseTimeline.Entry(15, 960.0),
			new EaseTimeline.Entry(885, 960.0),
			new EaseTimeline.Entry(900, 1920.0)
		});

		// Token: 0x0400058C RID: 1420
		private readonly Level _level;

		// Token: 0x0400058D RID: 1421
		private readonly ResourceSession _resourceSession;

		// Token: 0x0400058E RID: 1422
		private Font _font;

		// Token: 0x0400058F RID: 1423
		private Sample _jingle;

		// Token: 0x04000590 RID: 1424
		private GameOverHud.Reason _reason;

		// Token: 0x04000591 RID: 1425
		private int _ticks;

		// Token: 0x020001ED RID: 493
		public enum Reason
		{
			// Token: 0x04000B27 RID: 2855
			GameOver,
			// Token: 0x04000B28 RID: 2856
			TimeOver
		}
	}
}
