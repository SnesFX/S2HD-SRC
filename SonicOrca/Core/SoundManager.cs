using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Audio;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000147 RID: 327
	public class SoundManager
	{
		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000D79 RID: 3449 RVA: 0x00033650 File Offset: 0x00031850
		public SampleInstance MusicInstance
		{
			get
			{
				return this._musicInstance;
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000D7A RID: 3450 RVA: 0x00033658 File Offset: 0x00031858
		public SampleInstance CurrentInstance
		{
			get
			{
				SampleInstance sampleInstance = this._jingleInstance.FirstOrDefault((SampleInstance x) => x != null && x.Playing);
				if (sampleInstance == null)
				{
					sampleInstance = this._musicInstance;
				}
				return sampleInstance;
			}
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x0003369C File Offset: 0x0003189C
		public SoundManager(Level level)
		{
			this._gameContext = level.GameContext;
			this._level = level;
			this._resourceTree = this._gameContext.ResourceTree;
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0003373D File Offset: 0x0003193D
		public void Update()
		{
			this.UpdateMusicFading();
			this.CheckFinishedJingles();
			this.UpdateSounds();
			this._simpleInstances.RemoveAll((SampleInstance x) => !x.Playing);
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x0003377C File Offset: 0x0003197C
		public void PlayMusic(string fullKeyPath)
		{
			if (!string.IsNullOrEmpty(fullKeyPath))
			{
				this.PlayMusic(this._resourceTree.GetLoadedResource<SampleInfo>(fullKeyPath));
			}
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x00033798 File Offset: 0x00031998
		public void PlayMusic(SampleInfo si)
		{
			this.SelectMusic(si);
			this.PlayMusic(false);
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x000337A8 File Offset: 0x000319A8
		public void CrossFadeMusic(string fullKeyPath)
		{
			this.CrossFadeMusic(this._resourceTree.GetLoadedResource<SampleInfo>(fullKeyPath));
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x000337BC File Offset: 0x000319BC
		public void CrossFadeMusic(SampleInfo si)
		{
			if (this.CurrentInstance != null)
			{
				this._queuedMusic = si;
				this.FadeOutMusic(120);
				return;
			}
			this.SelectMusic(si);
			this.PlayMusic(false);
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x000337E4 File Offset: 0x000319E4
		private void SelectMusic(SampleInfo si)
		{
			if (this._music == si)
			{
				return;
			}
			if (this._musicInstance != null)
			{
				this._musicInstance.Stop();
				this._musicInstance.Dispose();
			}
			this._music = si;
			this._musicInstance = new SampleInstance(this._gameContext, si);
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x00033834 File Offset: 0x00031A34
		public void UpdateMusicFading()
		{
			SampleInstance currentInstance = this.CurrentInstance;
			if (currentInstance == null)
			{
				return;
			}
			SoundManager.MusicFadeState musicFadeState = this._musicFadeState;
			if (musicFadeState != SoundManager.MusicFadeState.FadingOut)
			{
				if (musicFadeState != SoundManager.MusicFadeState.FadingIn)
				{
					return;
				}
				currentInstance.Volume += this._musicFadeAmount;
				if (currentInstance.Volume >= 1.0)
				{
					currentInstance.Volume = 1.0;
					this._musicFadeState = SoundManager.MusicFadeState.None;
				}
			}
			else
			{
				this._musicFadeVolume -= this._musicFadeAmount;
				currentInstance.Volume = Math.Min(currentInstance.Volume, this._musicFadeVolume);
				if (currentInstance.Volume <= 0.0)
				{
					currentInstance.Volume = 0.0;
					currentInstance.Stop();
					this._musicFadeState = SoundManager.MusicFadeState.None;
					if (this._queuedMusic != null)
					{
						this.SelectMusic(this._queuedMusic);
						this._queuedMusic = null;
						this.PlayMusic(false);
						return;
					}
				}
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x00033910 File Offset: 0x00031B10
		public void PlayMusic(bool continueFadeOut = false)
		{
			if (this._musicInstance != null)
			{
				this.StopAllJingles();
				this._musicInstance.Volume = 1.0;
				if (continueFadeOut && this._musicFadeState == SoundManager.MusicFadeState.FadingOut)
				{
					this._musicInstance.Volume = this._musicFadeVolume;
				}
				else
				{
					this._musicFadeState = SoundManager.MusicFadeState.None;
				}
				this._musicInstance.Classification = SampleInstanceClassification.Music;
				this._musicInstance.SeekToStart();
				this._musicInstance.Play();
			}
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x00033988 File Offset: 0x00031B88
		public void PauseAll()
		{
			this._pausedJingle = this._jingleOrder.LastOrDefault<JingleType>();
			for (int i = 0; i < this.NumJingleTypes; i++)
			{
				SampleInstance sampleInstance = this._jingleInstance[i];
				if (sampleInstance != null && sampleInstance.Playing)
				{
					sampleInstance.Stop();
				}
			}
			if (this._musicInstance != null)
			{
				this._musicInstance.Stop();
			}
			foreach (LevelSound levelSound in this._sounds)
			{
				levelSound.Pause();
			}
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x00033A28 File Offset: 0x00031C28
		public void ResumeAll()
		{
			if (this._pausedJingle != JingleType.None && this._jingleInstance[(int)this._pausedJingle] != null)
			{
				this._jingleInstance[(int)this._pausedJingle].Play();
			}
			else if (this._musicInstance != null)
			{
				this._musicInstance.Play();
			}
			this._pausedJingle = JingleType.None;
			foreach (LevelSound levelSound in this._sounds)
			{
				levelSound.Resume();
			}
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x00033AC0 File Offset: 0x00031CC0
		public void FadeInMusic(int fadeDuration = 60)
		{
			if (this._musicInstance != null)
			{
				this._musicInstance.Volume = 0.0;
				this._musicInstance.Play();
				this._musicFadeState = SoundManager.MusicFadeState.FadingIn;
				this._musicFadeAmount = 1.0 / (double)fadeDuration;
			}
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00033B0D File Offset: 0x00031D0D
		public void FadeOutMusic(int fadeDuration)
		{
			this._musicFadeState = SoundManager.MusicFadeState.FadingOut;
			this._musicFadeVolume = this.CurrentInstance.Volume;
			this._musicFadeAmount = 1.0 / (double)fadeDuration;
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00033B39 File Offset: 0x00031D39
		public void MuteMusic()
		{
			if (this._musicInstance != null)
			{
				this._musicInstance.Volume = 0.0;
			}
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00033B57 File Offset: 0x00031D57
		public void StopMusic()
		{
			if (this._musicInstance != null)
			{
				this._musicInstance.Stop();
			}
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00033B6C File Offset: 0x00031D6C
		public void CheckFinishedJingles()
		{
			for (int i = 0; i < this.NumJingleTypes; i++)
			{
				if (this._jingleInstance[i] != null && !this._jingleInstance[i].Playing)
				{
					this.StopJingle((JingleType)i);
				}
			}
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x00033BAC File Offset: 0x00031DAC
		public void SetJingle(JingleType jingleType, string resourceKey)
		{
			Resource resource = this._gameContext.ResourceTree[resourceKey].Resource;
			SampleInfo sampleInfo = (resource.Identifier == ResourceTypeIdentifier.SampleInfo) ? ((SampleInfo)resource.LoadedResource) : new SampleInfo((Sample)resource.LoadedResource, null);
			this._jingleSampleInfo[(int)jingleType] = sampleInfo;
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x00033C0D File Offset: 0x00031E0D
		public void SetJingle(JingleType jingleType, SampleInfo si)
		{
			this._jingleSampleInfo[(int)jingleType] = si;
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x00033C18 File Offset: 0x00031E18
		public void PlayJingleOnce(Sample sample)
		{
			SampleInstance sampleInstance = new SampleInstance(this._gameContext, sample, null);
			sampleInstance.Classification = SampleInstanceClassification.Music;
			sampleInstance.Play();
			this._simpleInstances.Add(sampleInstance);
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x00033C54 File Offset: 0x00031E54
		public void PlayJingle(JingleType jingleType)
		{
			if (this._jingleSampleInfo[(int)jingleType] == null)
			{
				return;
			}
			switch (jingleType)
			{
			case JingleType.Life:
				this.MuteMusic();
				break;
			case JingleType.Invincibility:
				this.StopMusic();
				break;
			case JingleType.SpeedShoes:
				this.StopMusic();
				break;
			case JingleType.Super:
				this.StopMusic();
				break;
			case JingleType.Drowning:
				this.StopMusic();
				break;
			default:
				return;
			}
			for (int i = 0; i < this.NumJingleTypes; i++)
			{
				if (this._jingleInstance[i] != null)
				{
					this._jingleInstance[i].Volume = 0.0;
				}
			}
			if (this._jingleInstance[(int)jingleType] == null)
			{
				this._jingleInstance[(int)jingleType] = new SampleInstance(this._gameContext, this._jingleSampleInfo[(int)jingleType]);
			}
			else
			{
				this._jingleOrder.Remove(jingleType);
			}
			this._jingleOrder.Add(jingleType);
			this._jingleInstance[(int)jingleType].Classification = SampleInstanceClassification.Music;
			this._jingleInstance[(int)jingleType].Volume = 1.0;
			this._jingleInstance[(int)jingleType].SeekToStart();
			this._jingleInstance[(int)jingleType].Play();
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x00033D60 File Offset: 0x00031F60
		public void StopJingle(JingleType jingleType)
		{
			if (this._jingleInstance[(int)jingleType] == null)
			{
				return;
			}
			this._jingleInstance[(int)jingleType].Stop();
			this._jingleInstance[(int)jingleType].Dispose();
			this._jingleInstance[(int)jingleType] = null;
			this._jingleOrder.Remove(jingleType);
			if (this._jingleOrder.Count == 0)
			{
				if (jingleType != JingleType.Life)
				{
					if (jingleType != JingleType.Drowning)
					{
						this.PlayMusic(true);
						return;
					}
				}
				else if (this._musicFadeState != SoundManager.MusicFadeState.FadingOut)
				{
					this.FadeInMusic(60);
					return;
				}
			}
			else
			{
				JingleType jingleType2 = this._jingleOrder.Last<JingleType>();
				this._jingleInstance[(int)jingleType2].Volume = 1.0;
			}
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x00033DFC File Offset: 0x00031FFC
		public void StopAllJingles()
		{
			for (int i = 0; i < this.NumJingleTypes; i++)
			{
				if (this._jingleInstance[i] != null && this._jingleInstance[i].Playing)
				{
					this.StopJingle((JingleType)i);
				}
			}
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x00033E3C File Offset: 0x0003203C
		public void StopAll()
		{
			this.StopMusic();
			this.StopAllJingles();
			foreach (LevelSound levelSound in this._sounds)
			{
				levelSound.Dispose();
			}
			this._sounds.Clear();
			foreach (SampleInstance sampleInstance in this._simpleInstances)
			{
				sampleInstance.Dispose();
			}
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x00033EE4 File Offset: 0x000320E4
		public void PlaySound(IActiveObject activeObject, string resourceKey)
		{
			this.PlaySound(activeObject.Position, resourceKey);
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x00033EF4 File Offset: 0x000320F4
		public void PlaySound(Vector2i position, string resourceKey)
		{
			Sample sample;
			if (this._resourceTree.TryGetLoadedResource<Sample>(resourceKey, out sample))
			{
				this.PlaySound(position, sample);
			}
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x00033F1C File Offset: 0x0003211C
		public void PlaySound(Vector2i position, Sample sample)
		{
			LevelSound levelSound = new LevelSound(this._level, sample, position, true);
			levelSound.Play();
			this.AddLevelSound(levelSound);
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x00033F45 File Offset: 0x00032145
		public void AddLevelSound(LevelSound levelSound)
		{
			this._sounds.Add(levelSound);
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00033F54 File Offset: 0x00032154
		public void PlaySound(string resourceKey)
		{
			Sample sample;
			if (this._resourceTree.TryGetLoadedResource<Sample>(resourceKey, out sample))
			{
				this.PlaySound(sample);
			}
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x00033F78 File Offset: 0x00032178
		public void PlaySound(Sample sample)
		{
			SampleInstance sampleInstance = new SampleInstance(this._gameContext, sample, null);
			sampleInstance.Play();
			this._simpleInstances.Add(sampleInstance);
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x00033FB0 File Offset: 0x000321B0
		public void PlaySoundVisibleOnly(string resourceKey, Vector2i position)
		{
			if (this._level.Camera.Bounds.Contains(position))
			{
				this.PlaySound(resourceKey);
			}
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x00033FE4 File Offset: 0x000321E4
		private void UpdateSounds()
		{
			foreach (LevelSound levelSound in this._sounds)
			{
				levelSound.Update();
			}
			this._sounds.RemoveAll((LevelSound s) => s.Finished);
		}

		// Token: 0x040007A2 RID: 1954
		private readonly int NumJingleTypes = EnumHelpers.GetEnumCount(typeof(JingleType));

		// Token: 0x040007A3 RID: 1955
		private readonly SampleInfo[] _jingleSampleInfo = new SampleInfo[EnumHelpers.GetEnumCount(typeof(JingleType))];

		// Token: 0x040007A4 RID: 1956
		private readonly SampleInstance[] _jingleInstance = new SampleInstance[EnumHelpers.GetEnumCount(typeof(JingleType))];

		// Token: 0x040007A5 RID: 1957
		private readonly List<JingleType> _jingleOrder = new List<JingleType>();

		// Token: 0x040007A6 RID: 1958
		private readonly List<LevelSound> _sounds = new List<LevelSound>();

		// Token: 0x040007A7 RID: 1959
		private readonly List<SampleInstance> _simpleInstances = new List<SampleInstance>();

		// Token: 0x040007A8 RID: 1960
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040007A9 RID: 1961
		private readonly Level _level;

		// Token: 0x040007AA RID: 1962
		private readonly ResourceTree _resourceTree;

		// Token: 0x040007AB RID: 1963
		private SampleInfo _music;

		// Token: 0x040007AC RID: 1964
		private SampleInfo _queuedMusic;

		// Token: 0x040007AD RID: 1965
		private SampleInstance _musicInstance;

		// Token: 0x040007AE RID: 1966
		private JingleType _pausedJingle;

		// Token: 0x040007AF RID: 1967
		private SoundManager.MusicFadeState _musicFadeState;

		// Token: 0x040007B0 RID: 1968
		private double _musicFadeVolume;

		// Token: 0x040007B1 RID: 1969
		private double _musicFadeAmount;

		// Token: 0x02000233 RID: 563
		private enum MusicFadeState
		{
			// Token: 0x04000C40 RID: 3136
			None,
			// Token: 0x04000C41 RID: 3137
			FadingOut,
			// Token: 0x04000C42 RID: 3138
			FadingIn
		}
	}
}
