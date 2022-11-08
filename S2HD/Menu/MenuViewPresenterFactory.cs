using System;
using SonicOrca;

namespace S2HD.Menu
{
	// Token: 0x020000B5 RID: 181
	internal class MenuViewPresenterFactory
	{
		// Token: 0x06000450 RID: 1104 RVA: 0x0001D96C File Offset: 0x0001BB6C
		public MenuViewPresenterFactory(S2HDSonicOrcaGameContext gameContext, ISettingUIResources resources)
		{
			this._gameContext = gameContext;
			this._resources = resources;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0001D984 File Offset: 0x0001BB84
		public IMenuViewPresenter Create(IMenuViewModel viewModel)
		{
			if (viewModel is IListMenuViewModel)
			{
				return new ListMenuViewPresenter(this._gameContext, this._resources, viewModel as IListMenuViewModel);
			}
			if (viewModel is ISettingListMenuViewModel)
			{
				return new SettingListMenuViewPresenter(this._gameContext, this._resources, viewModel as ISettingListMenuViewModel);
			}
			throw new NotSupportedException();
		}

		// Token: 0x04000503 RID: 1283
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x04000504 RID: 1284
		private readonly ISettingUIResources _resources;
	}
}
