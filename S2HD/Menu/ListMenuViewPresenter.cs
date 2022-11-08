using System;
using System.Collections.Immutable;
using SonicOrca;
using SonicOrca.Audio;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Input;

namespace S2HD.Menu
{
	// Token: 0x020000B4 RID: 180
	internal class ListMenuViewPresenter : IMenuViewPresenter
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x0001D349 File Offset: 0x0001B549
		// (set) Token: 0x0600043F RID: 1087 RVA: 0x0001D356 File Offset: 0x0001B556
		public int HighlightedIndex
		{
			get
			{
				return this._viewModel.HighlightedIndex;
			}
			set
			{
				this._viewModel.HighlightedIndex = value;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x0001D364 File Offset: 0x0001B564
		// (set) Token: 0x06000441 RID: 1089 RVA: 0x0001D36C File Offset: 0x0001B56C
		public Rectanglei Bounds { get; set; }

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000442 RID: 1090 RVA: 0x0001D378 File Offset: 0x0001B578
		// (remove) Token: 0x06000443 RID: 1091 RVA: 0x0001D3B0 File Offset: 0x0001B5B0
		public event EventHandler NavigateBack;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000444 RID: 1092 RVA: 0x0001D3E8 File Offset: 0x0001B5E8
		// (remove) Token: 0x06000445 RID: 1093 RVA: 0x0001D420 File Offset: 0x0001B620
		public event EventHandler<NavigateNextEventArgs> NavigateNext;

		// Token: 0x06000446 RID: 1094 RVA: 0x0001D455 File Offset: 0x0001B655
		public ListMenuViewPresenter(S2HDSonicOrcaGameContext gameContext, ISettingUIResources resources, IListMenuViewModel viewModel)
		{
			this._gameContext = gameContext;
			this._audioContext = gameContext.Audio;
			this._resources = resources;
			this._items = viewModel.Items;
			this._viewModel = viewModel;
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000FD87 File Offset: 0x0000DF87
		public void Update()
		{
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0001D48C File Offset: 0x0001B68C
		public void HandleInput()
		{
			InputContext input = this._gameContext.Input;
			InputState pressed = this._gameContext.Input.Pressed;
			if (input.Pressed.Keyboard[41] || pressed.GamePad[0].Select || pressed.GamePad[0].East)
			{
				this.NavigateBack2();
			}
			else if (input.Pressed.Keyboard[40] || pressed.GamePad[0].Start || pressed.GamePad[0].South)
			{
				this.NavigateSelect();
			}
			else if (input.Pressed.Keyboard[82] || ((pressed.GamePad[0].POV.Y == -1 || pressed.GamePad[0].LeftAxis.Y <= -0.5) && !this._tapDown))
			{
				this.NavigateUp();
			}
			else if (input.Pressed.Keyboard[81] || ((pressed.GamePad[0].POV.Y == 1 || pressed.GamePad[0].LeftAxis.Y >= 0.5) && !this._tapUp))
			{
				this.NavigateDown();
			}
			if (pressed.GamePad[0].POV.Y == 1 || pressed.GamePad[0].LeftAxis.Y >= 0.5)
			{
				this._tapUp = true;
			}
			if (pressed.GamePad[0].POV.Y == -1 || pressed.GamePad[0].LeftAxis.Y < -0.5)
			{
				this._tapDown = true;
				return;
			}
			if (pressed.GamePad[0].POV.Y == 0 && Math.Abs(pressed.GamePad[0].LeftAxis.Y) < 0.01)
			{
				this._tapUp = false;
				this._tapDown = false;
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0001D716 File Offset: 0x0001B916
		private void NavigateBack2()
		{
			EventHandler navigateBack = this.NavigateBack;
			if (navigateBack == null)
			{
				return;
			}
			navigateBack(this, EventArgs.Empty);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0001D730 File Offset: 0x0001B930
		private void NavigateSelect()
		{
			IMenuItem menuItem = this._items[this.HighlightedIndex];
			NavigateNextEventArgs e = new NavigateNextEventArgs(menuItem.Next, menuItem.Tag);
			EventHandler<NavigateNextEventArgs> navigateNext = this.NavigateNext;
			if (navigateNext == null)
			{
				return;
			}
			navigateNext(this, e);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0001D778 File Offset: 0x0001B978
		private void NavigateUp()
		{
			if (this.HighlightedIndex > 0)
			{
				int highlightedIndex = this.HighlightedIndex;
				this.HighlightedIndex = highlightedIndex - 1;
				this.PlayNavigationSound();
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0001D7A4 File Offset: 0x0001B9A4
		private void NavigateDown()
		{
			if (this.HighlightedIndex < this._items.Length - 1)
			{
				int highlightedIndex = this.HighlightedIndex;
				this.HighlightedIndex = highlightedIndex + 1;
				this.PlayNavigationSound();
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0001D7DF File Offset: 0x0001B9DF
		private void PlayNavigationSound()
		{
			if (this._resources.NavigateSample != null)
			{
				this._audioContext.PlaySound(this._resources.NavigateSample);
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0001D7DF File Offset: 0x0001B9DF
		private void PlayConfirmSound()
		{
			if (this._resources.NavigateSample != null)
			{
				this._audioContext.PlaySound(this._resources.NavigateSample);
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0001D804 File Offset: 0x0001BA04
		public void Draw(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			int num = this._items.Length * 64;
			int y = this.Bounds.Centre.Y - num / 2;
			new Rectanglei(this.Bounds.X, y, this.Bounds.Width, 64);
			Rectanglei r = new Rectanglei(this.Bounds.X, y, this.Bounds.Width, 64);
			for (int i = 0; i < this._items.Length; i++)
			{
				IMenuItem menuItem = this._items[i];
				int overlay = 0;
				if (i == this.HighlightedIndex)
				{
					i2dRenderer.BlendMode = BlendMode.Additive;
					i2dRenderer.Colour = new Colour(0.3, 1.0, 1.0, 1.0);
					i2dRenderer.RenderTexture(this._resources.SelectionBar, r, false, false);
					overlay = 1;
				}
				fontRenderer.RenderStringWithShadow(menuItem.Text, r, FontAlignment.Centre, this._resources.Font, overlay);
				r.Y += r.Height;
			}
		}

		// Token: 0x040004F9 RID: 1273
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x040004FA RID: 1274
		private readonly AudioContext _audioContext;

		// Token: 0x040004FB RID: 1275
		private readonly ISettingUIResources _resources;

		// Token: 0x040004FC RID: 1276
		private readonly ImmutableArray<IMenuItem> _items;

		// Token: 0x040004FD RID: 1277
		private readonly IListMenuViewModel _viewModel;

		// Token: 0x040004FE RID: 1278
		private bool _tapUp;

		// Token: 0x040004FF RID: 1279
		private bool _tapDown;
	}
}
