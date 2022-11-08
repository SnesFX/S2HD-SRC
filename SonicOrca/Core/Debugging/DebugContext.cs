using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Audio;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Input;
using SonicOrca.Resources;

namespace SonicOrca.Core.Debugging
{
	// Token: 0x0200018F RID: 399
	public class DebugContext : IDisposable
	{
		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x0600113F RID: 4415 RVA: 0x000443AF File Offset: 0x000425AF
		// (set) Token: 0x06001140 RID: 4416 RVA: 0x000443B7 File Offset: 0x000425B7
		public Font Font { get; private set; }

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06001141 RID: 4417 RVA: 0x000443C0 File Offset: 0x000425C0
		// (set) Token: 0x06001142 RID: 4418 RVA: 0x000443C8 File Offset: 0x000425C8
		public bool Visible { get; private set; }

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06001143 RID: 4419 RVA: 0x000443D1 File Offset: 0x000425D1
		public Level Level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06001144 RID: 4420 RVA: 0x000443D9 File Offset: 0x000425D9
		public DebugOption CurrentOption
		{
			get
			{
				return this._currentOption;
			}
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x000443E4 File Offset: 0x000425E4
		public DebugContext(Level level)
		{
			this._gameContext = level.GameContext;
			this._level = level;
			this._pages.AddRange(from x in DebugOptionDefinitions.CreateOptionsInOrder(this)
			group x by x.Page into x
			select new DebugPage(this, x.Key, x));
			if (this._pages.Count > 0)
			{
				this.SelectPage(this._pages.First<DebugPage>());
			}
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x0004447C File Offset: 0x0004267C
		public async Task LoadAsync(CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependencies(new string[]
			{
				"SONICORCA/FONTS/HUD",
				"SONICORCA/SOUND/TALLY/SWITCH"
			});
			await this._resourceSession.LoadAsync(ct, false);
			this.Font = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/HUD");
			this._focusSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/SOUND/TALLY/SWITCH");
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x000444C9 File Offset: 0x000426C9
		public void Dispose()
		{
			if (this._resourceSession != null)
			{
				this._resourceSession.Dispose();
			}
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x000444DE File Offset: 0x000426DE
		public void Update()
		{
			if (!this._gameContext.Console.IsOpen)
			{
				this.HandleInput();
			}
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x000444F8 File Offset: 0x000426F8
		private void SelectPage(DebugPage page)
		{
			this._currentPage = page;
			this._currentOption = this._currentPage.Options.FirstOrDefault((DebugOption x) => x.Selectable);
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x00044538 File Offset: 0x00042738
		private void HandleInput()
		{
			KeyboardState keyboard = this._gameContext.Input.Pressed.Keyboard;
			if (!this.Visible)
			{
				return;
			}
			if (keyboard[80])
			{
				this.OnPressLeft();
			}
			else if (keyboard[79])
			{
				this.OnPressRight();
			}
			if (keyboard[82])
			{
				this.OnPressUp();
				return;
			}
			if (keyboard[81])
			{
				this.OnPressDown();
			}
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x000445A8 File Offset: 0x000427A8
		private void OnPressLeft()
		{
			if (this._gameContext.Input.CurrentState.Keyboard[224])
			{
				int num = this._pages.IndexOf(this._currentPage);
				if (num > 0)
				{
					this.SelectPage(this._pages[num - 1]);
					this.PlayFocusSound();
					return;
				}
			}
			else if (this._currentOption != null)
			{
				this._currentOption.OnPressLeft();
			}
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x0004461C File Offset: 0x0004281C
		private void OnPressRight()
		{
			if (this._gameContext.Input.CurrentState.Keyboard[224])
			{
				int num = this._pages.IndexOf(this._currentPage);
				if (num < this._pages.Count - 1)
				{
					this.SelectPage(this._pages[num + 1]);
					this.PlayFocusSound();
					return;
				}
			}
			else if (this._currentOption != null)
			{
				this._currentOption.OnPressRight();
			}
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x0004469C File Offset: 0x0004289C
		private void OnPressUp()
		{
			if (this._currentPage.Options.Count == 0)
			{
				return;
			}
			int num = this._currentPage.Options.IndexOf(this._currentOption);
			for (int i = num - 1; i >= 0; i--)
			{
				DebugOption debugOption = this._currentPage.Options[num - 1];
				if (debugOption.Selectable)
				{
					this._currentOption = debugOption;
					this.PlayFocusSound();
				}
			}
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x0004470C File Offset: 0x0004290C
		private void OnPressDown()
		{
			if (this._currentPage.Options.Count == 0)
			{
				return;
			}
			int num = this._currentPage.Options.IndexOf(this._currentOption);
			for (int i = num + 1; i < this._currentPage.Options.Count; i++)
			{
				DebugOption debugOption = this._currentPage.Options[num + 1];
				if (debugOption.Selectable)
				{
					this._currentOption = debugOption;
					this.PlayFocusSound();
				}
			}
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x0004478C File Offset: 0x0004298C
		public void Draw(Renderer renderer)
		{
			if (!this.Visible)
			{
				return;
			}
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.BlendMode = BlendMode.Alpha;
			i2dRenderer.RenderQuad(new Colour(192, 0, 0, 0), new Rectangle(8.0, 8.0, 1904.0, 1064.0));
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate(16.0, 16.0, 0.0);
				i2dRenderer.ClipRectangle = new Rectangle(16.0, 16.0, 1888.0, 1048.0);
				this.DrawPageTabs(renderer);
				i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate(0.0, (double)(this.Font.Height + 32), 0.0);
				if (this._currentPage != null)
				{
					this._currentPage.Draw(renderer);
				}
			}
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x000448C0 File Offset: 0x00042AC0
		private void DrawPageTabs(Renderer renderer)
		{
			int num = 0;
			foreach (DebugPage debugPage in this._pages)
			{
				this.DrawText(renderer, debugPage.Name, FontAlignment.Left, (double)num, 0.0, 1.0, new int?((this._currentPage == debugPage) ? 1 : 0));
				num += (int)this.Font.MeasureString(debugPage.Name).Width + 64;
			}
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x00044964 File Offset: 0x00042B64
		public double DrawText(Renderer renderer, string text, FontAlignment alignment, double x, double y, double scale, int? overlay)
		{
			return this.DrawText(renderer, text, alignment, x, y, scale, overlay, Colours.White);
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x00044988 File Offset: 0x00042B88
		public double DrawText(Renderer renderer, string text, FontAlignment alignment, double x, double y, double scale, Colour colour)
		{
			return this.DrawText(renderer, text, alignment, x, y, scale, null, colour);
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x000449B0 File Offset: 0x00042BB0
		public double DrawText(Renderer renderer, string text, FontAlignment alignment, double x, double y, double scale, int? overlay, Colour colour)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix = (i2dRenderer.ModelMatrix * Matrix4.CreateScale(scale, scale, 1.0)).Translate(x, y, 0.0);
				renderer.GetFontRenderer().RenderStringWithShadow(text, default(Rectangle), alignment, this.Font, colour, overlay);
			}
			return (double)this.Font.Height * scale + 8.0;
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x00044A58 File Offset: 0x00042C58
		public void PlayFocusSound()
		{
			this._gameContext.Audio.PlaySound(this._focusSample);
		}

		// Token: 0x040009A5 RID: 2469
		private const string FontResourceKey = "SONICORCA/FONTS/HUD";

		// Token: 0x040009A6 RID: 2470
		private const string FocusResourceKey = "SONICORCA/SOUND/TALLY/SWITCH";

		// Token: 0x040009A7 RID: 2471
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040009A8 RID: 2472
		private readonly Level _level;

		// Token: 0x040009A9 RID: 2473
		private readonly List<DebugPage> _pages = new List<DebugPage>();

		// Token: 0x040009AA RID: 2474
		private DebugPage _currentPage;

		// Token: 0x040009AB RID: 2475
		private DebugOption _currentOption;

		// Token: 0x040009AC RID: 2476
		private ResourceSession _resourceSession;

		// Token: 0x040009AD RID: 2477
		private Sample _focusSample;

		// Token: 0x040009B0 RID: 2480
		public const int DebugTextSilver = 0;

		// Token: 0x040009B1 RID: 2481
		public const int DebugTextGold = 1;

		// Token: 0x040009B2 RID: 2482
		public const double DebugTextNormal = 1.0;

		// Token: 0x040009B3 RID: 2483
		public const double DebugTextSmall = 0.75;

		// Token: 0x040009B4 RID: 2484
		public const double DebugTextXSmall = 0.5;

		// Token: 0x040009B5 RID: 2485
		public const double DebugTextXXSmall = 0.25;
	}
}
