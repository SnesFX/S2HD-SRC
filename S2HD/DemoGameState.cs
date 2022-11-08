using System;
using System.Collections.Generic;
using System.Threading;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Input;
using SonicOrca.Resources;

namespace S2HD
{
	// Token: 0x0200009A RID: 154
	internal class DemoGameState : IGameState, IDisposable
	{
		// Token: 0x06000367 RID: 871 RVA: 0x00018EC1 File Offset: 0x000170C1
		public DemoGameState(S2HDSonicOrcaGameContext gameContext, string demoResourceKey)
		{
			this._gameContext = gameContext;
			this._demoResourceKey = demoResourceKey;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00018EE4 File Offset: 0x000170E4
		private byte[] GetDemoData(string resourceKey)
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			byte[] data;
			using (ResourceSession resourceSession = new ResourceSession(resourceTree))
			{
				resourceSession.PushDependency(resourceKey);
				resourceSession.LoadAsync(default(CancellationToken), true).Wait();
				data = resourceTree.GetLoadedResource<InputRecordingResource>(resourceKey).Data;
			}
			return data;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00018F4C File Offset: 0x0001714C
		private void StartLevel(LevelPrepareSettings prepareSettings)
		{
			this._prepareSettings = prepareSettings;
			this._levelGameState = new LevelGameState(this._gameContext);
			this._levelGameState.PrepareSettings = prepareSettings;
			this._gameContext.Console.LevelGameState = this._levelGameState;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00018F88 File Offset: 0x00017188
		public IEnumerable<UpdateResult> Update()
		{
			byte[] demoData = this.GetDemoData(this._demoResourceKey);
			LevelPrepareSettings prepareSettings = new LevelPrepareSettings
			{
				Act = 1,
				AreaResourceKey = Levels.GetAreaResourceKey("ehz"),
				LevelNumber = 1,
				Lives = 3,
				ProtagonistCharacter = CharacterType.Sonic,
				SidekickCharacter = CharacterType.Null,
				RecordedPlayReadData = demoData
			};
			this.StartLevel(prepareSettings);
			bool finishingDemo = false;
			do
			{
				foreach (UpdateResult updateResult in this._levelGameState.Update())
				{
					if (!finishingDemo && this.ShouldFinishDemo())
					{
						finishingDemo = true;
						Level level = this._levelGameState.Level;
						if (level != null)
						{
							level.FadeOut(LevelState.Quit);
						}
					}
					yield return updateResult;
				}
				IEnumerator<UpdateResult> enumerator = null;
			}
			while (this._levelGameState.Completed);
			yield break;
			yield break;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00018F98 File Offset: 0x00017198
		private bool ShouldFinishDemo()
		{
			Level level = this._levelGameState.Level;
			if (level != null && level.Ticks >= this._demoLength)
			{
				return true;
			}
			InputState pressed = this._gameContext.Input.Pressed;
			return pressed.Keyboard[40] || pressed.GamePad[0].Start;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00018FFD File Offset: 0x000171FD
		public void Draw()
		{
			if (this._levelGameState != null)
			{
				this._levelGameState.Draw();
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00019012 File Offset: 0x00017212
		public void Dispose()
		{
			if (this._levelGameState != null)
			{
				this._levelGameState.Dispose();
			}
		}

		// Token: 0x0400041C RID: 1052
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x0400041D RID: 1053
		private readonly string _demoResourceKey;

		// Token: 0x0400041E RID: 1054
		private LevelPrepareSettings _prepareSettings;

		// Token: 0x0400041F RID: 1055
		private LevelGameState _levelGameState;

		// Token: 0x04000420 RID: 1056
		private int _demoLength = 1800;
	}
}
