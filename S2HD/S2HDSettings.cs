using System;
using SonicOrca;
using SonicOrca.Audio;
using SonicOrca.Graphics;

namespace S2HD
{
	// Token: 0x0200009F RID: 159
	internal class S2HDSettings : IAudioSettings, IVideoSettings
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000385 RID: 901 RVA: 0x00019869 File Offset: 0x00017A69
		// (set) Token: 0x06000386 RID: 902 RVA: 0x00019876 File Offset: 0x00017A76
		public double MusicVolume
		{
			get
			{
				return this._audioContext.MusicVolume;
			}
			set
			{
				this._audioContext.MusicVolume = value;
				this._config.SetProperty("audio", "music_volume", value.ToString().ToLower());
				this._config.Save();
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000387 RID: 903 RVA: 0x000198B0 File Offset: 0x00017AB0
		// (set) Token: 0x06000388 RID: 904 RVA: 0x000198BD File Offset: 0x00017ABD
		public double SoundVolume
		{
			get
			{
				return this._audioContext.SoundVolume;
			}
			set
			{
				this._audioContext.SoundVolume = value;
				this._config.SetProperty("audio", "sound_volume", value.ToString().ToLower());
				this._config.Save();
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000389 RID: 905 RVA: 0x000198F7 File Offset: 0x00017AF7
		// (set) Token: 0x0600038A RID: 906 RVA: 0x00019900 File Offset: 0x00017B00
		public VideoMode Mode
		{
			get
			{
				return this._mode;
			}
			set
			{
				this._mode = value;
				this._config.SetProperty("video", "fullscreen", ((int)this.Mode).ToString().ToLower());
				this._config.Save();
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00019947 File Offset: 0x00017B47
		// (set) Token: 0x0600038C RID: 908 RVA: 0x0001994F File Offset: 0x00017B4F
		public Resolution Resolution { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00019958 File Offset: 0x00017B58
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00019960 File Offset: 0x00017B60
		public bool EnableShadows
		{
			get
			{
				return this._enableShadows;
			}
			set
			{
				this._enableShadows = value;
				this._config.SetProperty("graphics", "shadows", value.ToString().ToLower());
				this._config.Save();
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00019995 File Offset: 0x00017B95
		// (set) Token: 0x06000390 RID: 912 RVA: 0x0001999D File Offset: 0x00017B9D
		public bool EnableWaterEffects
		{
			get
			{
				return this._enableWaterEffects;
			}
			set
			{
				this._enableWaterEffects = value;
				this._config.SetProperty("graphics", "water_effects", value.ToString().ToLower());
				this._config.Save();
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000391 RID: 913 RVA: 0x000199D2 File Offset: 0x00017BD2
		// (set) Token: 0x06000392 RID: 914 RVA: 0x000199DA File Offset: 0x00017BDA
		public bool EnableHeatEffects
		{
			get
			{
				return this._enableHeatEffects;
			}
			set
			{
				this._enableHeatEffects = value;
				this._config.SetProperty("graphics", "heat_effects", value.ToString().ToLower());
				this._config.Save();
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00019A10 File Offset: 0x00017C10
		public S2HDSettings(IniConfiguration config, AudioContext audioContext, WindowContext windowContext)
		{
			this._config = config;
			this._audioContext = audioContext;
			this._windowContext = windowContext;
			this._audioContext.MusicVolume = config.GetPropertyDouble("audio", "music_volume", 1.0);
			this._audioContext.SoundVolume = config.GetPropertyDouble("audio", "sound_volume", 1.0);
			this._mode = VideoMode.Windowed;
			int mode;
			if (int.TryParse(config.GetProperty("video", "fullscreen", "0"), out mode))
			{
				this._mode = (VideoMode)mode;
			}
			this.Resolution = new Resolution(1920, 1080);
			this._enableShadows = config.GetPropertyBoolean("graphics", "shadows", true);
			this._enableWaterEffects = config.GetPropertyBoolean("graphics", "water_effects", true);
			this._enableHeatEffects = config.GetPropertyBoolean("graphics", "heat_effects", false);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00019B06 File Offset: 0x00017D06
		public void Apply()
		{
			this._windowContext.Mode = this.Mode;
		}

		// Token: 0x04000442 RID: 1090
		private readonly AudioContext _audioContext;

		// Token: 0x04000443 RID: 1091
		private readonly WindowContext _windowContext;

		// Token: 0x04000444 RID: 1092
		private readonly IniConfiguration _config;

		// Token: 0x04000445 RID: 1093
		private VideoMode _mode;

		// Token: 0x04000446 RID: 1094
		private bool _enableShadows;

		// Token: 0x04000447 RID: 1095
		private bool _enableWaterEffects;

		// Token: 0x04000448 RID: 1096
		private bool _enableHeatEffects;
	}
}
