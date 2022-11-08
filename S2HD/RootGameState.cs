using System;
using System.Collections.Generic;
using System.Globalization;
using S2HD.Menu;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Geometry;
using SonicOrca.Input;

namespace S2HD
{
	// Token: 0x020000A1 RID: 161
	internal class RootGameState : IGameState, IDisposable
	{
		// Token: 0x0600039A RID: 922 RVA: 0x00019C78 File Offset: 0x00017E78
		public RootGameState(S2HDSonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._cmdLineArgs = gameContext.CommandLineArguments;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00019C93 File Offset: 0x00017E93
		public IEnumerable<UpdateResult> Update()
		{
			this.Initialise();
			InputState controller = this._gameContext.Input.Pressed;
			InputContext input = this._gameContext.Input;
			if (this._cmdLineArgs.HasOption("level"))
			{
				LevelPrepareSettings levelPrepareSettingsFromCommandLine = this.GetLevelPrepareSettingsFromCommandLine();
				if (levelPrepareSettingsFromCommandLine == null)
				{
					Program.ShowErrorMessageBox("Level does not exist.");
					yield break;
				}
				StoryPlaythroughGameState storyPlaythroughGameState = new StoryPlaythroughGameState(this._gameContext);
				storyPlaythroughGameState.StartFrom(levelPrepareSettingsFromCommandLine);
				this.ChangeGameState(storyPlaythroughGameState);
				foreach (UpdateResult updateResult in this._currentGameState.Update())
				{
					yield return updateResult;
				}
				IEnumerator<UpdateResult> enumerator = null;
			}
			else
			{
				if (this._cmdLineArgs.HasOption("credits"))
				{
					this.ShowCredits();
					foreach (UpdateResult updateResult2 in this._currentGameState.Update())
					{
						yield return updateResult2;
					}
					IEnumerator<UpdateResult> enumerator = null;
				}
				else if (this._cmdLineArgs.HasOption("options"))
				{
					this.ShowOptions();
					foreach (UpdateResult updateResult3 in this._currentGameState.Update())
					{
						yield return updateResult3;
					}
					IEnumerator<UpdateResult> enumerator = null;
				}
				if (this._cmdLineArgs.HasOption("demo"))
				{
					this.PlayDemo();
					foreach (UpdateResult updateResult4 in this._currentGameState.Update())
					{
						yield return updateResult4;
					}
					IEnumerator<UpdateResult> enumerator = null;
				}
				if (!this._cmdLineArgs.HasOption("nologos"))
				{
					this.ShowDisclaimer();
					foreach (UpdateResult updateResult5 in this._currentGameState.Update())
					{
						yield return updateResult5;
					}
					IEnumerator<UpdateResult> enumerator = null;
				}
				bool shouldQuit = false;
				while (!shouldQuit)
				{
					IEnumerator<UpdateResult> enumerator;
					if (!this._cmdLineArgs.HasOption("nologos"))
					{
						this.ShowLogos();
						foreach (UpdateResult updateResult6 in this._currentGameState.Update())
						{
							if (controller.GamePad[0].Start || input.Pressed.Keyboard[40])
							{
								break;
							}
							yield return updateResult6;
						}
						enumerator = null;
					}
					if (!this._cmdLineArgs.HasOption("nologos"))
					{
						this.ShowTeamLogo();
						foreach (UpdateResult updateResult7 in this._currentGameState.Update())
						{
							if (controller.GamePad[0].Start || input.Pressed.Keyboard[40])
							{
								break;
							}
							yield return updateResult7;
						}
						enumerator = null;
					}
					this.ShowTitle();
					foreach (UpdateResult updateResult8 in this._currentGameState.Update())
					{
						yield return updateResult8;
					}
					enumerator = null;
					TitleGameState titleGameState = this._currentGameState as TitleGameState;
					StoryPlaythroughGameState storyState;
					switch (titleGameState.Result)
					{
					case TitleGameState.ResultType.NewGame:
					case TitleGameState.ResultType.LevelSelect:
						this.PlayClassic();
						storyState = (this._currentGameState as StoryPlaythroughGameState);
						if (titleGameState.LevelPrepareSettings != null)
						{
							storyState.StartFrom(titleGameState.LevelPrepareSettings);
						}
						foreach (UpdateResult updateResult9 in this._currentGameState.Update())
						{
							yield return updateResult9;
						}
						enumerator = null;
						if (!storyState.QuitViaOptions)
						{
							this.ShowCredits();
							foreach (UpdateResult updateResult10 in this._currentGameState.Update())
							{
								yield return updateResult10;
							}
							enumerator = null;
						}
						break;
					case TitleGameState.ResultType.ShowOptions:
						this.ShowOptions();
						foreach (UpdateResult updateResult11 in this._currentGameState.Update())
						{
							yield return updateResult11;
						}
						enumerator = null;
						break;
					case TitleGameState.ResultType.StartDemo:
						this.PlayDemo();
						foreach (UpdateResult updateResult12 in this._currentGameState.Update())
						{
							yield return updateResult12;
						}
						enumerator = null;
						break;
					case TitleGameState.ResultType.Quit:
						shouldQuit = true;
						break;
					}
					storyState = null;
				}
			}
			yield break;
			yield break;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00019CA3 File Offset: 0x00017EA3
		public void Draw()
		{
			if (this._currentGameState != null)
			{
				this._currentGameState.Draw();
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00019CB8 File Offset: 0x00017EB8
		private void Initialise()
		{
			SharedRenderers.Initialise(this._gameContext.RenderFactory);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00019CCA File Offset: 0x00017ECA
		public void Dispose()
		{
			if (this._currentGameState != null)
			{
				this._currentGameState.Dispose();
			}
			SharedRenderers.Dispose();
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00019CE4 File Offset: 0x00017EE4
		private void ShowLogos()
		{
			this.ChangeGameState(new LogosGameState(this._gameContext));
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00019CF7 File Offset: 0x00017EF7
		private void ShowTeamLogo()
		{
			this.ChangeGameState(new TeamLogoGameState(this._gameContext));
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00019D0A File Offset: 0x00017F0A
		private void ShowDisclaimer()
		{
			this.ChangeGameState(new DisclaimerGameState(this._gameContext));
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00019D1D File Offset: 0x00017F1D
		private void ShowTitle()
		{
			this.ChangeGameState(new TitleGameState(this._gameContext));
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00019D30 File Offset: 0x00017F30
		private void PlayClassic()
		{
			this.ChangeGameState(new StoryPlaythroughGameState(this._gameContext));
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00019D43 File Offset: 0x00017F43
		private void ShowOptions()
		{
			this.ChangeGameState(new OptionsGameState(this._gameContext));
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00019D56 File Offset: 0x00017F56
		private void ShowCredits()
		{
			this.ChangeGameState(new CreditsGameState(this._gameContext));
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00019D69 File Offset: 0x00017F69
		private void PlayDemo()
		{
			this.ChangeGameState(new DemoGameState(this._gameContext, "SONICORCA/RECORDINGS/EHZ"));
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00019D81 File Offset: 0x00017F81
		private void ChangeGameState(IGameState newGameState)
		{
			if (this._currentGameState != null)
			{
				this._currentGameState.Dispose();
			}
			this._currentGameState = newGameState;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00019DA0 File Offset: 0x00017FA0
		private LevelPrepareSettings GetLevelPrepareSettingsFromCommandLine()
		{
			string[] optionValues = this._cmdLineArgs.GetOptionValues("level");
			if (optionValues.Length == 0)
			{
				return null;
			}
			string mnemonic = optionValues[0];
			string areaResourceKey = Levels.GetAreaResourceKey(mnemonic);
			if (areaResourceKey == null)
			{
				return null;
			}
			int num = Levels.GetLevelIndex(mnemonic);
			if (num == -1)
			{
				num = 1;
			}
			LevelPrepareSettings levelPrepareSettings = new LevelPrepareSettings
			{
				Act = 1,
				AreaResourceKey = areaResourceKey,
				Debugging = this._cmdLineArgs.HasOption("debug"),
				LevelNumber = num,
				Lives = 3,
				TimeTrial = this._cmdLineArgs.HasOption("timetrial")
			};
			optionValues = this._cmdLineArgs.GetOptionValues("act");
			int num2;
			if (optionValues.Length != 0 && int.TryParse(optionValues[0], out num2))
			{
				levelPrepareSettings.Act = num2;
			}
			optionValues = this._cmdLineArgs.GetOptionValues("lives");
			if (optionValues.Length != 0 && int.TryParse(optionValues[0], out num2))
			{
				levelPrepareSettings.Lives = num2;
			}
			optionValues = this._cmdLineArgs.GetOptionValues("protagonist");
			if (optionValues.Length != 0)
			{
				levelPrepareSettings.ProtagonistCharacter = RootGameState.GetCharacterType(optionValues[0]);
			}
			optionValues = this._cmdLineArgs.GetOptionValues("sidekick");
			if (optionValues.Length != 0)
			{
				levelPrepareSettings.SidekickCharacter = RootGameState.GetCharacterType(optionValues[0]);
			}
			optionValues = this._cmdLineArgs.GetOptionValues("startpos");
			int x;
			int y;
			if (optionValues.Length >= 2 && int.TryParse(optionValues[0], out x) && int.TryParse(optionValues[1], out y))
			{
				levelPrepareSettings.StartPosition = new Vector2i?(new Vector2i(x, y));
			}
			optionValues = this._cmdLineArgs.GetOptionValues("night");
			float num3;
			if (optionValues.Length != 0 && float.TryParse(optionValues[0], NumberStyles.Float, CultureInfo.InvariantCulture, out num3))
			{
				levelPrepareSettings.NightMode = (double)num3;
			}
			optionValues = this._cmdLineArgs.GetOptionValues("record");
			if (optionValues.Length != 0)
			{
				levelPrepareSettings.RecordedPlayWritePath = optionValues[0];
			}
			optionValues = this._cmdLineArgs.GetOptionValues("playback");
			if (optionValues.Length != 0)
			{
				levelPrepareSettings.RecordedPlayReadPath = optionValues[0];
			}
			optionValues = this._cmdLineArgs.GetOptionValues("ghost");
			if (optionValues.Length != 0)
			{
				levelPrepareSettings.RecordedPlayGhostReadPath = optionValues[0];
			}
			return levelPrepareSettings;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00019FA8 File Offset: 0x000181A8
		private static CharacterType GetCharacterType(string characterType)
		{
			for (int i = 0; i < RootGameState.CharacterNames.Length; i++)
			{
				if (RootGameState.CharacterNames[i].Equals(characterType, StringComparison.OrdinalIgnoreCase))
				{
					return i + CharacterType.Sonic;
				}
			}
			return CharacterType.Null;
		}

		// Token: 0x04000451 RID: 1105
		private static readonly string[] CharacterNames = new string[]
		{
			"sonic",
			"tails",
			"knuckles"
		};

		// Token: 0x04000452 RID: 1106
		private readonly S2HDSonicOrcaGameContext _gameContext;

		// Token: 0x04000453 RID: 1107
		private readonly CommandLineArguments _cmdLineArgs;

		// Token: 0x04000454 RID: 1108
		private IGameState _currentGameState;
	}
}
