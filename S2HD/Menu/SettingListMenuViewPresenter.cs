using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using SonicOrca;
using SonicOrca.Audio;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Input;

namespace S2HD.Menu
{
	// Token: 0x020000C3 RID: 195
	internal class SettingListMenuViewPresenter : IMenuViewPresenter
	{
		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060004B4 RID: 1204 RVA: 0x0001EFA0 File Offset: 0x0001D1A0
		// (remove) Token: 0x060004B5 RID: 1205 RVA: 0x0001EFD8 File Offset: 0x0001D1D8
		public event EventHandler NavigateBack;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060004B6 RID: 1206 RVA: 0x0001F010 File Offset: 0x0001D210
		// (remove) Token: 0x060004B7 RID: 1207 RVA: 0x0001F048 File Offset: 0x0001D248
		public event EventHandler<NavigateNextEventArgs> NavigateNext;

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0001F07D File Offset: 0x0001D27D
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0001F085 File Offset: 0x0001D285
		public Rectanglei Bounds
		{
			get
			{
				return this._bounds;
			}
			set
			{
				this._bounds = value;
				this._layoutDirty = true;
			}
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0001F098 File Offset: 0x0001D298
		public SettingListMenuViewPresenter(S2HDSonicOrcaGameContext gameContext, ISettingUIResources resources, ISettingListMenuViewModel viewModel)
		{
			this._gameContext = gameContext;
			this._audioContext = this._gameContext.Audio;
			this._resources = resources;
			this._viewModel = viewModel;
			this._settings = viewModel.Items;
			this.Layout();
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0001F0F8 File Offset: 0x0001D2F8
		private void Layout()
		{
			int x = this.Bounds.Left + 16;
			int width = this.Bounds.Width - 32;
			int num = this.Bounds.Top + 16;
			this._optionSettingUIs.Clear();
			foreach (ISetting setting in this._settings)
			{
				SettingUI settingUI = new SettingUI(setting, this._resources);
				settingUI.Bounds = new Rectanglei(x, num, width, 64);
				settingUI.Highlighted = false;
				this._optionSettingUIs.Add(settingUI);
				num += 64;
			}
			if (this._optionSettingUIs.Count > 0)
			{
				if (this._selectedIndex == -1)
				{
					this._selectedIndex = 0;
				}
				else
				{
					this._selectedIndex = Math.Min(this._selectedIndex, this._optionSettingUIs.Count - 1);
				}
				this._optionSettingUIs[this._selectedIndex].Highlighted = true;
			}
			else
			{
				this._selectedIndex = -1;
			}
			this._layoutDirty = false;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0001F206 File Offset: 0x0001D406
		public void Update()
		{
			if (this._layoutDirty)
			{
				this.Layout();
			}
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001F218 File Offset: 0x0001D418
		public void HandleInput()
		{
			InputContext input = this._gameContext.Input;
			InputState pressed = this._gameContext.Input.Pressed;
			if (input.Pressed.Keyboard[40] || pressed.GamePad[0].Start || pressed.GamePad[0].South)
			{
				EventHandler<NavigateNextEventArgs> navigateNext = this.NavigateNext;
				if (navigateNext != null)
				{
					navigateNext(this, new NavigateNextEventArgs(null, 4));
				}
			}
			else if (input.Pressed.Keyboard[41] || pressed.GamePad[0].Select || pressed.GamePad[0].East)
			{
				EventHandler navigateBack = this.NavigateBack;
				if (navigateBack != null)
				{
					navigateBack(this, EventArgs.Empty);
				}
			}
			else if (input.Pressed.Keyboard[82] || ((pressed.GamePad[0].POV.Y == -1 || pressed.GamePad[0].LeftAxis.Y <= -0.5) && !this._tapDown))
			{
				this.NavigateUp();
			}
			else if (input.Pressed.Keyboard[81] || ((pressed.GamePad[0].POV.Y == 1 || pressed.GamePad[0].LeftAxis.Y >= 0.5) && !this._tapUp))
			{
				this.NavigateDown();
			}
			else if (input.Pressed.Keyboard[80] || ((pressed.GamePad[0].POV.X == -1 || pressed.GamePad[0].LeftAxis.X <= -0.5) && !this._tapLeft))
			{
				this.NavigateLeft();
			}
			else if (input.Pressed.Keyboard[79] || ((pressed.GamePad[0].POV.X == 1 || pressed.GamePad[0].LeftAxis.X >= 0.5) && !this._tapRight))
			{
				this.NavigateRight();
			}
			if (pressed.GamePad[0].POV.Y == 1 || pressed.GamePad[0].LeftAxis.Y >= 0.5)
			{
				this._tapUp = true;
			}
			else if (pressed.GamePad[0].POV.Y == -1 || pressed.GamePad[0].LeftAxis.Y < -0.5)
			{
				this._tapDown = true;
			}
			if (pressed.GamePad[0].POV.X == 1 || pressed.GamePad[0].LeftAxis.X >= 0.5)
			{
				this._tapRight = true;
			}
			else if (pressed.GamePad[0].POV.X == -1 || pressed.GamePad[0].LeftAxis.X < -0.5)
			{
				this._tapLeft = true;
			}
			if (pressed.GamePad[0].POV.Y == 0 && Math.Abs(pressed.GamePad[0].LeftAxis.Y) < 0.01)
			{
				this._tapUp = false;
				this._tapDown = false;
			}
			if (pressed.GamePad[0].POV.X == 0 && Math.Abs(pressed.GamePad[0].LeftAxis.X) < 0.01)
			{
				this._tapLeft = false;
				this._tapRight = false;
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0001F6A8 File Offset: 0x0001D8A8
		public void NavigateUp()
		{
			if (this._selectedIndex > 0)
			{
				this._optionSettingUIs[this._selectedIndex].Highlighted = false;
				this._selectedIndex--;
				this._optionSettingUIs[this._selectedIndex].Highlighted = true;
				this.PlayNavigationSound();
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0001F700 File Offset: 0x0001D900
		public void NavigateDown()
		{
			if (this._selectedIndex < this._optionSettingUIs.Count - 1)
			{
				this._optionSettingUIs[this._selectedIndex].Highlighted = false;
				this._selectedIndex++;
				this._optionSettingUIs[this._selectedIndex].Highlighted = true;
				this.PlayNavigationSound();
			}
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0001F764 File Offset: 0x0001D964
		private void PlayNavigationSound()
		{
			if (this._resources.NavigateSample != null)
			{
				this._audioContext.PlaySound(this._resources.NavigateSample);
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0001F78C File Offset: 0x0001D98C
		private void NavigateLeft()
		{
			if (this._selectedIndex != -1)
			{
				ISetting setting = this._settings[this._selectedIndex];
				if (setting is IAudioSliderSetting)
				{
					IAudioSliderSetting audioSliderSetting = setting as IAudioSliderSetting;
					if (audioSliderSetting.Value > 0.0)
					{
						audioSliderSetting.Value = MathX.Snap(audioSliderSetting.Value - 0.1, 0.1);
						audioSliderSetting.Value = Math.Max(audioSliderSetting.Value, 0.0);
						this.PlayNavigationSound();
						return;
					}
				}
				else if (setting is ISpinnerSetting)
				{
					ISpinnerSetting spinnerSetting = setting as ISpinnerSetting;
					if (spinnerSetting.SelectedIndex > 0)
					{
						ISpinnerSetting spinnerSetting2 = spinnerSetting;
						int selectedIndex = spinnerSetting2.SelectedIndex;
						spinnerSetting2.SelectedIndex = selectedIndex - 1;
						this.PlayNavigationSound();
					}
				}
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0001F850 File Offset: 0x0001DA50
		private void NavigateRight()
		{
			if (this._selectedIndex != -1)
			{
				ISetting setting = this._settings[this._selectedIndex];
				if (setting is IAudioSliderSetting)
				{
					IAudioSliderSetting audioSliderSetting = setting as IAudioSliderSetting;
					if (audioSliderSetting.Value < 1.0)
					{
						audioSliderSetting.Value = MathX.Snap(audioSliderSetting.Value + 0.1, 0.1);
						audioSliderSetting.Value = Math.Min(audioSliderSetting.Value, 1.0);
						this.PlayNavigationSound();
						return;
					}
				}
				else if (setting is ISpinnerSetting)
				{
					ISpinnerSetting spinnerSetting = setting as ISpinnerSetting;
					int count = spinnerSetting.Values.Count;
					if (spinnerSetting.SelectedIndex < count - 1)
					{
						ISpinnerSetting spinnerSetting2 = spinnerSetting;
						int selectedIndex = spinnerSetting2.SelectedIndex;
						spinnerSetting2.SelectedIndex = selectedIndex + 1;
						this.PlayNavigationSound();
					}
				}
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0001F928 File Offset: 0x0001DB28
		public void Draw(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			if (this._selectedIndex != -1)
			{
				Rectanglei r = this._optionSettingUIs[this._selectedIndex].Bounds.Inflate(new Vector2i(16, 0));
				Colour colour = new Colour(0.1, 1.0, 1.0, 1.0);
				i2dRenderer.BlendMode = BlendMode.Additive;
				i2dRenderer.RenderQuad(colour, r);
			}
			foreach (SettingUI settingUI in this._optionSettingUIs)
			{
				settingUI.Draw(renderer);
			}
		}

		// Token: 0x0400055B RID: 1371
		private const int Margin = 16;

		// Token: 0x0400055C RID: 1372
		private const int ItemHeight = 64;

		// Token: 0x0400055D RID: 1373
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x0400055E RID: 1374
		private readonly AudioContext _audioContext;

		// Token: 0x0400055F RID: 1375
		private readonly ISettingUIResources _resources;

		// Token: 0x04000560 RID: 1376
		private readonly ImmutableArray<ISetting> _settings;

		// Token: 0x04000561 RID: 1377
		private readonly ISettingListMenuViewModel _viewModel;

		// Token: 0x04000562 RID: 1378
		private readonly List<SettingUI> _optionSettingUIs = new List<SettingUI>();

		// Token: 0x04000563 RID: 1379
		private Rectanglei _bounds;

		// Token: 0x04000564 RID: 1380
		private bool _layoutDirty = true;

		// Token: 0x04000565 RID: 1381
		private int _selectedIndex;

		// Token: 0x04000568 RID: 1384
		private bool _tapUp;

		// Token: 0x04000569 RID: 1385
		private bool _tapDown;

		// Token: 0x0400056A RID: 1386
		private bool _tapLeft;

		// Token: 0x0400056B RID: 1387
		private bool _tapRight;
	}
}
