using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using S2HD;
using SonicOrca.Core;
using SonicOrca.Drawing;
using SonicOrca.Drawing.LevelRendering;
using SonicOrca.Drawing.Renderers;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Input;
using SonicOrca.Resources;

namespace SonicOrca
{
	// Token: 0x02000094 RID: 148
	internal class S2HDSonicOrcaGameContext : SonicOrcaGameContext
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00016B2A File Offset: 0x00014D2A
		// (set) Token: 0x0600031B RID: 795 RVA: 0x00016B32 File Offset: 0x00014D32
		public CommandLineArguments CommandLineArguments { get; private set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00016B3B File Offset: 0x00014D3B
		// (set) Token: 0x0600031D RID: 797 RVA: 0x00016B43 File Offset: 0x00014D43
		public LevelGameState CurrentLevelScreen { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00016B4C File Offset: 0x00014D4C
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00016B54 File Offset: 0x00014D54
		public IRendererFactory RenderFactory { get; private set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000320 RID: 800 RVA: 0x00016B5D File Offset: 0x00014D5D
		// (set) Token: 0x06000321 RID: 801 RVA: 0x00016B65 File Offset: 0x00014D65
		public S2HDSettings Settings { get; private set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000322 RID: 802 RVA: 0x00016B6E File Offset: 0x00014D6E
		public override IAudioSettings AudioSettings
		{
			get
			{
				return this.Settings;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000323 RID: 803 RVA: 0x00016B6E File Offset: 0x00014D6E
		public override IVideoSettings VideoSettings
		{
			get
			{
				return this.Settings;
			}
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00016B76 File Offset: 0x00014D76
		public S2HDSonicOrcaGameContext(IPlatform platform) : base(platform)
		{
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00016BA4 File Offset: 0x00014DA4
		public override void Initialise()
		{
			base.Initialise();
			this.CommandLineArguments = new CommandLineArguments(Program.CommandLineArguments);
			base.Configuration = Program.Configuration;
			base.UserDataDirectory = Program.UserDataDirectory;
			this._canvas = base.Window.GraphicsContext.CreateFrameBuffer(1920, 1080, 1);
			SonicOrcaGameContext.IsMaxPerformance = base.Configuration.GetPropertyBoolean("graphics", "max_performance", false);
			base.Audio.Volume = base.Configuration.GetPropertyDouble("audio", "volume", 1.0);
			base.Audio.MusicVolume = base.Configuration.GetPropertyDouble("audio", "music_volume", 0.2);
			base.Audio.SoundVolume = base.Configuration.GetPropertyDouble("audio", "sound_volume", 1.0);
			base.Input.IsVibrationEnabled = base.Configuration.GetPropertyBoolean("input", "vibration", true);
			this.Settings = new S2HDSettings(base.Configuration, base.Audio, base.Window);
			this.Settings.Apply();
			base.Window.WindowTitle = "Sonic 2 HD";
			base.Window.AspectRatio = new Vector2i(16, 9);
			string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			this.LoadResourceFiles(Path.Combine(directoryName, "data"));
			if (bool.Parse(base.Configuration.GetProperty("general", "use_mods", "true")))
			{
				this.LoadResourceFiles(Path.Combine(directoryName, "mods"));
			}
			this.RenderFactory = DefaultRendererFactory.Create(base.Window.GraphicsContext);
			this._rootGameState = new RootGameState(this);
			this._gameStateUpdater = new Updater(this._rootGameState.Update());
			this.Begin();
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00016D94 File Offset: 0x00014F94
		private void LoadResources(string path)
		{
			string[] files = Directory.GetFiles(path, "*.dat", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				ResourceFile resourceFile = new ResourceFile(files[i]);
				base.ResourceTree.MergeWith(resourceFile.Scan());
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00016DD6 File Offset: 0x00014FD6
		public override void Dispose()
		{
			this._rootGameState.Dispose();
			base.Dispose();
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00016DEC File Offset: 0x00014FEC
		private void Begin()
		{
			string a = null;
			LevelPrepareSettings levelPrepareSettings = new LevelPrepareSettings
			{
				Act = 1,
				Lives = 3
			};
			IReadOnlyList<string> commandLineArguments = Program.CommandLineArguments;
			int i = 0;
			while (i < commandLineArguments.Count)
			{
				bool flag = i == commandLineArguments.Count - 1;
				string argument = commandLineArguments[i];
				string text = argument.ToLower();
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1911695018U)
				{
					if (num <= 858517105U)
					{
						if (num <= 316833741U)
						{
							if (num != 219382073U)
							{
								if (num == 316833741U)
								{
									if (text == "-record")
									{
										if (!flag)
										{
											levelPrepareSettings.RecordedPlayWritePath = commandLineArguments[++i];
										}
									}
								}
							}
							else if (text == "-fullscreen")
							{
								base.Window.FullScreen = true;
							}
						}
						else if (num != 366450519U)
						{
							if (num != 458083694U)
							{
								if (num == 858517105U)
								{
									if (text == "-editor")
									{
										goto IL_395;
									}
								}
							}
							else if (text == "-level")
							{
								if (!flag)
								{
									string areaResourceKey = Levels.GetAreaResourceKey(commandLineArguments[++i].ToLower());
									if (areaResourceKey != null)
									{
										levelPrepareSettings.AreaResourceKey = areaResourceKey;
										a = "level";
									}
								}
							}
						}
						else if (text == "-timetrial")
						{
							levelPrepareSettings.TimeTrial = true;
						}
					}
					else if (num <= 1024998106U)
					{
						if (num != 925764489U)
						{
							if (num == 1024998106U)
							{
								if (text == "-credits")
								{
									a = "credits";
								}
							}
						}
						else if (text == "-playback")
						{
							if (!flag)
							{
								levelPrepareSettings.RecordedPlayReadPath = commandLineArguments[++i];
							}
						}
					}
					else if (num != 1566413665U)
					{
						if (num != 1658401661U)
						{
							if (num == 1911695018U)
							{
								if (text == "-host")
								{
									Trace.WriteLine("Waiting for client");
									base.NetworkManager.Host(7237);
									while (!base.NetworkManager.AllConnected)
									{
										base.NetworkManager.Update();
									}
								}
							}
						}
						else if (text == "-halfpipe")
						{
							a = "halfpipe";
						}
					}
					else if (text == "-sidekick")
					{
						if (!flag)
						{
							argument = commandLineArguments[++i].ToLower();
							levelPrepareSettings.SidekickCharacter = this.CharacterNames.IndexOf((string x) => x.Equals(argument)) + CharacterType.Sonic;
						}
					}
				}
				else if (num <= 2725636254U)
				{
					if (num <= 2107701544U)
					{
						if (num != 1913698679U)
						{
							if (num == 2107701544U)
							{
								if (text == "-join")
								{
									string text2 = commandLineArguments[++i];
									Trace.WriteLine("Joining " + text2);
									base.NetworkManager.Join(text2, 7237);
									while (!base.NetworkManager.AllConnected)
									{
										base.NetworkManager.Update();
									}
								}
							}
						}
						else if (text == "-ghost")
						{
							if (!flag)
							{
								levelPrepareSettings.RecordedPlayGhostReadPath = commandLineArguments[++i];
							}
						}
					}
					else if (num != 2353739631U)
					{
						if (num != 2625104368U)
						{
							if (num == 2725636254U)
							{
								if (text == "-night")
								{
									if (!flag)
									{
										double nightMode;
										double.TryParse(commandLineArguments[++i], NumberStyles.Float, CultureInfo.InvariantCulture, out nightMode);
										levelPrepareSettings.NightMode = nightMode;
									}
								}
							}
						}
						else if (text == "-protagonist")
						{
							if (!flag)
							{
								argument = commandLineArguments[++i].ToLower();
								levelPrepareSettings.ProtagonistCharacter = this.CharacterNames.IndexOf((string x) => x.Equals(argument)) + CharacterType.Sonic;
							}
						}
					}
					else if (text == "-debug")
					{
						levelPrepareSettings.Debugging = true;
					}
				}
				else if (num <= 3333613284U)
				{
					if (num != 3178170700U)
					{
						if (num == 3333613284U)
						{
							if (text == "-window")
							{
								base.Window.FullScreen = false;
							}
						}
					}
					else if (text == "-edit")
					{
						goto IL_395;
					}
				}
				else if (num != 3577458254U)
				{
					if (num != 3762663828U)
					{
						if (num == 3881374379U)
						{
							if (text == "-lives")
							{
								if (!flag)
								{
									int value;
									int.TryParse(commandLineArguments[++i], out value);
									levelPrepareSettings.Lives = MathX.Clamp(1, value, 99);
								}
							}
						}
					}
					else if (text == "-act")
					{
						if (!flag)
						{
							int act;
							int.TryParse(commandLineArguments[++i], out act);
							levelPrepareSettings.Act = act;
						}
					}
				}
				else if (text == "-startpos")
				{
					int x2;
					int y;
					if (!flag && int.TryParse(commandLineArguments[++i], out x2) && i != commandLineArguments.Count - 1 && int.TryParse(commandLineArguments[++i], out y))
					{
						levelPrepareSettings.StartPosition = new Vector2i?(new Vector2i(x2, y));
					}
				}
				IL_641:
				i++;
				continue;
				IL_395:
				a = "editor";
				goto IL_641;
			}
			if (a == "credits")
			{
				new CreditsGameState(this);
				return;
			}
			if (!(a == "level"))
			{
				if (!(a == "halfpipe"))
				{
					Program.CommandLineArguments.Contains("-soundtrack");
				}
				return;
			}
			new StoryPlaythroughGameState(this).StartFrom(levelPrepareSettings);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00017498 File Offset: 0x00015698
		protected override void OnUpdate()
		{
			if ((base.Input.CurrentState.Keyboard[226] || base.Input.CurrentState.Keyboard[230]) && base.Input.Pressed.Keyboard[40])
			{
				base.Window.FullScreen = !base.Window.FullScreen;
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00017510 File Offset: 0x00015710
		protected override void OnUpdateStep()
		{
			base.Console.Update();
			base.NetworkManager.Update();
			if (!this._gameStateUpdater.Update())
			{
				base.Finish = true;
			}
			foreach (Controller controller in base.Controllers)
			{
				controller.Update();
			}
			base.Input.OutputState.GamePad = base.Output.ToArray<GamePadOutputState>();
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000175A0 File Offset: 0x000157A0
		protected override void OnDraw()
		{
			I2dRenderer i2dRenderer = base.Renderer.Get2dRenderer();
			i2dRenderer.ClipRectangle = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
			if (base.ForceHD)
			{
				this._canvas.Activate();
			}
			else
			{
				base.Window.GraphicsContext.RenderToBackBuffer();
			}
			base.Window.GraphicsContext.ClearBuffer();
			this._rootGameState.Draw();
			base.Renderer.DeativateRenderer();
			base.Console.Draw(base.Renderer);
			base.Renderer.DeativateRenderer();
			if (SonicOrcaGameContext.Singleton.Input.Pressed.Keyboard[67])
			{
				ScreenshotRenderer.GrabScreenshot();
			}
			if (base.ForceHD)
			{
				base.Window.GraphicsContext.RenderToBackBuffer();
				i2dRenderer.BlendMode = BlendMode.Opaque;
				i2dRenderer.Colour = Colours.White;
				i2dRenderer.ClipRectangle = new Rectangle(0.0, 0.0, (double)base.Window.ClientSize.X, (double)base.Window.ClientSize.Y);
				i2dRenderer.RenderTexture(this._canvas.Textures[0], new Rectangle(0.0, 0.0, (double)base.Window.ClientSize.X, (double)base.Window.ClientSize.Y), false, true);
				i2dRenderer.Deactivate();
			}
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00017744 File Offset: 0x00015944
		private void CreateDataResourceFiles(string inputDirectory, string outputDirectory)
		{
			if (!Directory.Exists(inputDirectory))
			{
				return;
			}
			if (!Directory.Exists(outputDirectory))
			{
				Directory.CreateDirectory(outputDirectory);
			}
			foreach (string text in Directory.GetDirectories(inputDirectory))
			{
				string path = Path.GetFileName(text) + ".dat";
				string path2 = Path.Combine(text, "sonicorca");
				ResourceTree tree = new ResourceTree();
				ResourceFile.GetResourcesFromDirectory(tree, path2, null);
				new ResourceFile(Path.Combine(outputDirectory, path)).Write(tree);
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000177C0 File Offset: 0x000159C0
		private void LoadResourceFiles(string inputDirectory)
		{
			if (!Directory.Exists(inputDirectory))
			{
				return;
			}
			foreach (string path in Directory.GetFiles(inputDirectory))
			{
				base.ResourceTree.MergeWith(new ResourceFile(path).Scan());
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00017805 File Offset: 0x00015A05
		protected override Renderer CreateRenderer()
		{
			return new TheRenderer(base.Window);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00017812 File Offset: 0x00015A12
		protected override ILevelRenderer CreateLevelRenderer(Level level)
		{
			return new LevelRenderer(level, this.VideoSettings);
		}

		// Token: 0x040003E4 RID: 996
		private IGameState _rootGameState;

		// Token: 0x040003E5 RID: 997
		private Updater _gameStateUpdater;

		// Token: 0x040003EA RID: 1002
		private readonly IReadOnlyList<string> CharacterNames = new string[]
		{
			"sonic",
			"tails",
			"knuckles"
		};
	}
}
