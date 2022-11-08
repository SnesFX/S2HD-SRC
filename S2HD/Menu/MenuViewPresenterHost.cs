using System;
using System.Collections.Generic;
using SonicOrca;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace S2HD.Menu
{
	// Token: 0x020000B6 RID: 182
	internal class MenuViewPresenterHost
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000452 RID: 1106 RVA: 0x0001D9D8 File Offset: 0x0001BBD8
		// (remove) Token: 0x06000453 RID: 1107 RVA: 0x0001DA10 File Offset: 0x0001BC10
		public event EventHandler NavigateBack;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000454 RID: 1108 RVA: 0x0001DA48 File Offset: 0x0001BC48
		// (remove) Token: 0x06000455 RID: 1109 RVA: 0x0001DA80 File Offset: 0x0001BC80
		public event EventHandler<NavigateNextEventArgs> NavigateNext;

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x0001DAB5 File Offset: 0x0001BCB5
		// (set) Token: 0x06000457 RID: 1111 RVA: 0x0001DABD File Offset: 0x0001BCBD
		public Rectanglei Bounds
		{
			get
			{
				return this._bounds;
			}
			set
			{
				this._bounds = value;
				if (this._viewPresenter != null)
				{
					this._viewPresenter.Bounds = value;
				}
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x0001DADA File Offset: 0x0001BCDA
		public object CurrentViewModelTag
		{
			get
			{
				return this._viewModel.Tag;
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0001DAE7 File Offset: 0x0001BCE7
		public MenuViewPresenterHost(MenuViewPresenterFactory viewPresenterFactory, IMenuViewModel initialViewModel, ISettingUIResources settingUIResources)
		{
			this._viewPresenterFactory = viewPresenterFactory;
			this._settingUIResources = settingUIResources;
			this.SetViewModel(initialViewModel);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x0001DB0F File Offset: 0x0001BD0F
		public void Update()
		{
			IMenuViewPresenter viewPresenter = this._viewPresenter;
			if (viewPresenter == null)
			{
				return;
			}
			viewPresenter.Update();
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0001DB21 File Offset: 0x0001BD21
		public void HandleInput()
		{
			IMenuViewPresenter viewPresenter = this._viewPresenter;
			if (viewPresenter == null)
			{
				return;
			}
			viewPresenter.HandleInput();
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0001DB34 File Offset: 0x0001BD34
		private void SetViewModel(IMenuViewModel viewModel)
		{
			if (this._viewModel != null)
			{
				this.PlayConfirmSound();
			}
			this._viewModel = viewModel;
			this._viewPresenter = this._viewPresenterFactory.Create(this._viewModel);
			this._viewPresenter.Bounds = this._bounds;
			this._viewPresenter.NavigateBack += this.NavigateBackHandler;
			this._viewPresenter.NavigateNext += delegate(object s, NavigateNextEventArgs e)
			{
				this.NavigateNextHandler(s, e);
			};
			this._viewPresenter.Update();
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0001DBB8 File Offset: 0x0001BDB8
		private void NavigateBackHandler(object sender, EventArgs e)
		{
			if (this._viewModelStack.Count != 0)
			{
				IMenuViewModel viewModel = this._viewModelStack.Pop();
				this.SetViewModel(viewModel);
				if (this.NavigateBack.Target.GetType() != typeof(OptionsGameState))
				{
					EventHandler navigateBack = this.NavigateBack;
					if (navigateBack == null)
					{
						return;
					}
					navigateBack(sender, EventArgs.Empty);
				}
				return;
			}
			EventHandler navigateBack2 = this.NavigateBack;
			if (navigateBack2 == null)
			{
				return;
			}
			navigateBack2(this, EventArgs.Empty);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0001DC34 File Offset: 0x0001BE34
		private void NavigateNextHandler(object s, NavigateNextEventArgs e)
		{
			if (e.ViewModel != null)
			{
				this._viewModelStack.Push(this._viewModel);
				this.SetViewModel(e.ViewModel);
			}
			if (e.Tag != null && e.Tag.Equals(0))
			{
				this.NavigateBackHandler(s, e);
				return;
			}
			if (e.ViewModel != null && e.Tag == null)
			{
				EventHandler<NavigateNextEventArgs> navigateNext = this.NavigateNext;
				if (navigateNext == null)
				{
					return;
				}
				navigateNext(s, new NavigateNextEventArgs(e.ViewModel, e.ViewModel.Tag));
				return;
			}
			else
			{
				EventHandler<NavigateNextEventArgs> navigateNext2 = this.NavigateNext;
				if (navigateNext2 == null)
				{
					return;
				}
				navigateNext2(s, e);
				return;
			}
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0001DCD4 File Offset: 0x0001BED4
		private void PlayNavigationSound()
		{
			if (this._settingUIResources.NavigateSample != null)
			{
				SonicOrcaGameContext.Singleton.Audio.PlaySound(this._settingUIResources.NavigateSample);
			}
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0001DCFD File Offset: 0x0001BEFD
		private void PlayConfirmSound()
		{
			if (this._settingUIResources.NavigateSample != null)
			{
				SonicOrcaGameContext.Singleton.Audio.PlaySound(this._settingUIResources.ConfirmSample);
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0001DD26 File Offset: 0x0001BF26
		private void PlayBackSound()
		{
			if (this._settingUIResources.NavigateSample != null)
			{
				SonicOrcaGameContext.Singleton.Audio.PlaySound(this._settingUIResources.CancelSample);
			}
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0001DD4F File Offset: 0x0001BF4F
		public void Draw(Renderer renderer)
		{
			IMenuViewPresenter viewPresenter = this._viewPresenter;
			if (viewPresenter == null)
			{
				return;
			}
			viewPresenter.Draw(renderer);
		}

		// Token: 0x04000505 RID: 1285
		private readonly Stack<IMenuViewModel> _viewModelStack = new Stack<IMenuViewModel>();

		// Token: 0x04000506 RID: 1286
		private readonly MenuViewPresenterFactory _viewPresenterFactory;

		// Token: 0x04000507 RID: 1287
		private readonly ISettingUIResources _settingUIResources;

		// Token: 0x04000508 RID: 1288
		private IMenuViewPresenter _viewPresenter;

		// Token: 0x04000509 RID: 1289
		private IMenuViewModel _viewModel;

		// Token: 0x0400050A RID: 1290
		private Rectanglei _bounds;
	}
}
