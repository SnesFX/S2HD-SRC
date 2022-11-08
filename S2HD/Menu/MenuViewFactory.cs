using System;
using System.Collections.Generic;
using SonicOrca;
using SonicOrca.Graphics;

namespace S2HD.Menu
{
	// Token: 0x020000B9 RID: 185
	internal class MenuViewFactory
	{
		// Token: 0x06000468 RID: 1128 RVA: 0x0001DD92 File Offset: 0x0001BF92
		public MenuViewFactory(S2HDSonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0001DDA4 File Offset: 0x0001BFA4
		public IListMenuViewModel GetInGameOptionsView(bool canRestart)
		{
			List<IMenuItem> list = new List<IMenuItem>(4);
			list.Add(new MenuItem("RESUME", null, 3));
			if (canRestart)
			{
				list.Add(new MenuItem("RESTART", this.GetConfirmMenu(2), null));
			}
			list.Add(new MenuItem("OPTIONS", this.GetOptionsView(), null));
			list.Add(new MenuItem("QUIT", this.GetConfirmMenu(1), null));
			return new ListMenuViewModel(list, null);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0001DE2A File Offset: 0x0001C02A
		public IListMenuViewModel GetConfirmMenu(object confirmTag)
		{
			return new ListMenuViewModel(new IMenuItem[]
			{
				new MenuItem("NO", null, 0),
				new MenuItem("YES", null, confirmTag)
			}, null);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0001DE5C File Offset: 0x0001C05C
		public IMenuViewModel GetOptionsView()
		{
			return new ListMenuViewModel(new IMenuItem[]
			{
				new MenuItem("AUDIO", this.GetAudioOptions(), 6),
				new MenuItem("VIDEO", this.GetVideoOptions(), 7)
			}, 5);
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0001DEAC File Offset: 0x0001C0AC
		public ISettingListMenuViewModel GetAudioOptions()
		{
			return new SettingListMenuViewModel(new ISetting[]
			{
				new MenuViewFactory.MusicSetting(this._gameContext.Settings),
				new MenuViewFactory.SoundSetting(this._gameContext.Settings)
			}, 5);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0001DEE8 File Offset: 0x0001C0E8
		public ISettingListMenuViewModel GetVideoOptions()
		{
			S2HDSettings settings = this._gameContext.Settings;
			ISetting[] array = new ISetting[5];
			array[0] = new StandardOptionSetting("MODE", new string[]
			{
				"WINDOW",
				"FULLSCREEN",
				"BORDERLESS WINDOWED"
			}, () => (int)settings.Mode, delegate(int value)
			{
				settings.Mode = (VideoMode)value;
			});
			array[1] = new StandardOptionSetting("RESOLUTION", new string[]
			{
				"1920 X 1080"
			}, () => 0, delegate(int value)
			{
			});
			array[2] = new OnOffOptionSetting("SHADOWS", () => settings.EnableShadows, delegate(bool value)
			{
				settings.EnableShadows = value;
			});
			array[3] = new OnOffOptionSetting("WATER EFFECTS", () => settings.EnableWaterEffects, delegate(bool value)
			{
				settings.EnableWaterEffects = value;
			});
			array[4] = new OnOffOptionSetting("HEAT EFFECTS", () => settings.EnableHeatEffects, delegate(bool value)
			{
				settings.EnableHeatEffects = value;
			});
			return new SettingListMenuViewModel(array, 5);
		}

		// Token: 0x04000518 RID: 1304
		private S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x02000127 RID: 295
		private class MusicSetting : IAudioSliderSetting, ISetting
		{
			// Token: 0x1700012A RID: 298
			// (get) Token: 0x06000711 RID: 1809 RVA: 0x00029037 File Offset: 0x00027237
			public string Name
			{
				get
				{
					return "MUSIC";
				}
			}

			// Token: 0x1700012B RID: 299
			// (get) Token: 0x06000712 RID: 1810 RVA: 0x0002903E File Offset: 0x0002723E
			// (set) Token: 0x06000713 RID: 1811 RVA: 0x0002904B File Offset: 0x0002724B
			public double Value
			{
				get
				{
					return this._settings.MusicVolume;
				}
				set
				{
					this._settings.MusicVolume = value;
				}
			}

			// Token: 0x06000714 RID: 1812 RVA: 0x00029059 File Offset: 0x00027259
			public MusicSetting(S2HDSettings settings)
			{
				this._settings = settings;
			}

			// Token: 0x04000740 RID: 1856
			private readonly S2HDSettings _settings;
		}

		// Token: 0x02000128 RID: 296
		private class SoundSetting : IAudioSliderSetting, ISetting
		{
			// Token: 0x1700012C RID: 300
			// (get) Token: 0x06000715 RID: 1813 RVA: 0x00029068 File Offset: 0x00027268
			public string Name
			{
				get
				{
					return "SFX";
				}
			}

			// Token: 0x1700012D RID: 301
			// (get) Token: 0x06000716 RID: 1814 RVA: 0x0002906F File Offset: 0x0002726F
			// (set) Token: 0x06000717 RID: 1815 RVA: 0x0002907C File Offset: 0x0002727C
			public double Value
			{
				get
				{
					return this._settings.SoundVolume;
				}
				set
				{
					this._settings.SoundVolume = value;
				}
			}

			// Token: 0x06000718 RID: 1816 RVA: 0x0002908A File Offset: 0x0002728A
			public SoundSetting(S2HDSettings settings)
			{
				this._settings = settings;
			}

			// Token: 0x04000741 RID: 1857
			private readonly S2HDSettings _settings;
		}
	}
}
