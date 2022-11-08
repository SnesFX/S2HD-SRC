using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Core.Objects;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Input;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000144 RID: 324
	public class SonicOrcaConsole : IDisposable
	{
		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000D56 RID: 3414 RVA: 0x00032956 File Offset: 0x00030B56
		// (set) Token: 0x06000D57 RID: 3415 RVA: 0x0003295E File Offset: 0x00030B5E
		public bool IsOpen { get; set; }

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000D58 RID: 3416 RVA: 0x00032967 File Offset: 0x00030B67
		// (set) Token: 0x06000D59 RID: 3417 RVA: 0x0003296F File Offset: 0x00030B6F
		public LevelGameState LevelGameState { get; set; }

		// Token: 0x06000D5A RID: 3418 RVA: 0x00032978 File Offset: 0x00030B78
		public SonicOrcaConsole(SonicOrcaGameContext context)
		{
			this._context = context;
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x000329A8 File Offset: 0x00030BA8
		public void LoadResources()
		{
			if (this._loadingResources)
			{
				return;
			}
			this._loadingResources = true;
			Task.Run(() => this.LoadResourcesAsync());
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x000329CC File Offset: 0x00030BCC
		public async Task LoadResourcesAsync()
		{
			ResourceTree resourceTree = this._context.ResourceTree;
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependency("SONICORCA/FONTS/SEGOEUI");
			await this._resourceSession.LoadAsync(default(CancellationToken), false);
			this._font = resourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/SEGOEUI");
			this._loadingResources = false;
			this._resourcesLoaded = true;
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x00032A11 File Offset: 0x00030C11
		public void Dispose()
		{
			if (this._resourceSession != null)
			{
				this._resourceSession.Dispose();
			}
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00032A28 File Offset: 0x00030C28
		public void Update()
		{
			if (!this._resourcesLoaded)
			{
				this.LoadResources();
				return;
			}
			InputContext input = this._context.Input;
			KeyboardState keyboard = input.Pressed.Keyboard;
			if (this.IsOpen)
			{
				this._opacity = Math.Min(this._opacity + 0.06666667f, 1f);
				if (keyboard[42])
				{
					if (this._currentLine.Length > 0)
					{
						this._currentLine.Remove(this._currentLine.Length - 1, 1);
						return;
					}
				}
				else if (keyboard[40])
				{
					if (this._currentLine.Length > 0)
					{
						string text = this._currentLine.ToString();
						this._currentLine.Clear();
						if (this._history.Count >= 128)
						{
							this._history.RemoveAt(0);
						}
						this._history.Add(text);
						this._historyScrollIndex = this._history.Count;
						this.WriteLine("> " + text);
						this.ProcessLine(text);
						return;
					}
				}
				else if (keyboard[82])
				{
					this._currentLine.Clear();
					this._historyScrollIndex = Math.Max(0, this._historyScrollIndex - 1);
					if (this._historyScrollIndex < this._history.Count)
					{
						this._currentLine.Append(this._history[this._historyScrollIndex]);
						return;
					}
				}
				else if (keyboard[81])
				{
					this._currentLine.Clear();
					this._historyScrollIndex = Math.Min(this._history.Count, this._historyScrollIndex + 1);
					if (this._historyScrollIndex < this._history.Count)
					{
						this._currentLine.Append(this._history[this._historyScrollIndex]);
						return;
					}
				}
				else if (input.TextInput != null)
				{
					this._currentLine.Append(input.TextInput);
				}
				return;
			}
			this._opacity = Math.Max(this._opacity - 0.06666667f, 0f);
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x00032C3C File Offset: 0x00030E3C
		public void Draw(Renderer renderer)
		{
			if (!this._resourcesLoaded || this._opacity == 0f)
			{
				return;
			}
			int height = this._font.Height;
			Colour colour = new Colour(0.8 * (double)this._opacity, 0.1, 0.1, 0.1);
			Colour colour2 = new Colour(1.0 * (double)this._opacity, 1.0, 1.0, 1.0);
			Vector2i clientSize = renderer.Window.ClientSize;
			Rectanglei r = new Rectanglei(8, 8, clientSize.X - 16, 6 * height);
			Rectanglei r2 = new Rectangle(8.0, (double)(r.Bottom + 8), (double)(clientSize.X - 16), (double)height);
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.RenderQuad(colour, r);
			i2dRenderer.RenderQuad(colour, r2);
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			int num = r.Bottom;
			for (int i = 0; i < Math.Min(this._buffer.Count, 6); i++)
			{
				string text = this._buffer[this._buffer.Count - 1 - i];
				num -= height;
				fontRenderer.RenderString(text, new Rectangle((double)(r.X + 4), (double)num, (double)r.Width, (double)height), FontAlignment.MiddleY, this._font, colour2, null);
			}
			fontRenderer.RenderString("> " + this._currentLine.ToString(), r2.Inflate(new Vector2i(-4, 0)), FontAlignment.MiddleY, this._font, colour2, null);
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x00032E0D File Offset: 0x0003100D
		public void WriteLine(string line)
		{
			if (this._buffer.Count >= 128)
			{
				this._buffer.RemoveAt(0);
			}
			this._buffer.Add(line);
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x00032E3C File Offset: 0x0003103C
		private void ProcessLine(string line)
		{
			string[] tokens = SonicOrcaConsole.GetTokens(line);
			if (tokens.Length == 0)
			{
				return;
			}
			string[] args = tokens.Skip(1).ToArray<string>();
			string a = tokens[0].ToLower();
			if (a == "barrier")
			{
				this.ProcessCommandBarrier(args);
				return;
			}
			if (a == "debug")
			{
				this.ProcessCommandDebug(args);
				return;
			}
			if (a == "spawn")
			{
				this.ProcessCommandSpawn(args);
				return;
			}
			if (a == "teleport")
			{
				this.ProcessCommandTeleport(args);
				return;
			}
			if (!(a == "restart"))
			{
				return;
			}
			this.ProcessCommandRestart(args);
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x00032ED4 File Offset: 0x000310D4
		private void ProcessCommandBarrier(string[] args)
		{
			if (args.Length < 1)
			{
				this.WriteLine("usage: barrier <none|classic|bubble|fire|lightning>");
				return;
			}
			string a = args[0].ToLower();
			BarrierType barrier;
			if (!(a == "none"))
			{
				if (!(a == "classic"))
				{
					if (!(a == "bubble"))
					{
						if (!(a == "fire"))
						{
							if (!(a == "lightning"))
							{
								this.WriteLine("usage: barrier <classic|bubble|fire|lightning>");
								return;
							}
							barrier = BarrierType.Lightning;
						}
						else
						{
							barrier = BarrierType.Fire;
						}
					}
					else
					{
						barrier = BarrierType.Bubble;
					}
				}
				else
				{
					barrier = BarrierType.Classic;
				}
			}
			else
			{
				barrier = BarrierType.None;
			}
			LevelGameState levelGameState = null;
			if (levelGameState != null && levelGameState.Level != null)
			{
				ICharacter protagonist = levelGameState.Player.Protagonist;
				if (protagonist != null)
				{
					protagonist.Barrier = barrier;
				}
			}
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x00032F84 File Offset: 0x00031184
		private void ProcessCommandDebug(string[] args)
		{
			if (this.LevelGameState == null || this.LevelGameState.Level == null)
			{
				return;
			}
			Level level = this.LevelGameState.Level;
			if (args.Length == 0)
			{
				level.ClassicDebugMode = !level.ClassicDebugMode;
				return;
			}
			string a = args[0].ToLower();
			if (!(a == "collision"))
			{
				if (!(a == "invulnerable"))
				{
					return;
				}
				level.Player.Protagonist.IsInvincible = !level.Player.Protagonist.IsInvincible;
				return;
			}
			else
			{
				if (level.LayerViewOptions.ShowLandscapeCollision)
				{
					level.LayerViewOptions.ShowLandscape = true;
					level.LayerViewOptions.ShowLandscapeCollision = false;
					level.LayerViewOptions.ShowObjectCollision = false;
					level.ShowCharacterInfo = false;
					return;
				}
				level.LayerViewOptions.ShowLandscape = false;
				level.LayerViewOptions.ShowLandscapeCollision = true;
				level.LayerViewOptions.ShowObjectCollision = true;
				level.ShowCharacterInfo = true;
				return;
			}
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x00033074 File Offset: 0x00031274
		private void ProcessCommandSpawn(string[] args)
		{
			if (this.LevelGameState == null || this.LevelGameState.Level == null)
			{
				return;
			}
			Level level = this.LevelGameState.Level;
			if (args.Length < 1)
			{
				return;
			}
			string objectType = "SONICORCA/OBJECTS/" + args[0].ToUpper();
			if (!level.ObjectManager.RegisteredTypes.Any((ObjectType x) => x.ResourceKey == objectType))
			{
				return;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			for (int i = 1; i < args.Length; i++)
			{
				if (args[i].StartsWith("-") || i >= args.Length - 2)
				{
					string key = args[i].Substring(1);
					object value = SonicOrcaConsole.ParseBehaviourValue(args[i + 1]);
					dictionary.Add(key, value);
					i++;
				}
			}
			Vector2i position = level.Player.Protagonist.Position;
			LevelLayer item = level.Map.Layers[level.Map.CollisionPathLayers.Last<int>()];
			ObjectPlacement objectPlacement = new ObjectPlacement(objectType, level.Map.Layers.IndexOf(item), position, dictionary);
			level.ObjectManager.AddObject(objectPlacement);
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x000331A4 File Offset: 0x000313A4
		private static object ParseBehaviourValue(string value)
		{
			int num;
			if (int.TryParse(value, out num))
			{
				return num;
			}
			double num2;
			if (double.TryParse(value, out num2))
			{
				return num2;
			}
			bool flag;
			if (bool.TryParse(value, out flag))
			{
				return flag;
			}
			return value;
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x000331E8 File Offset: 0x000313E8
		private void ProcessCommandTeleport(string[] args)
		{
			if (this.LevelGameState == null || this.LevelGameState.Level == null)
			{
				return;
			}
			Level level = this.LevelGameState.Level;
			if (args.Length < 2)
			{
				return;
			}
			int x;
			int y;
			if (int.TryParse(args[0], out x) && int.TryParse(args[1], out y))
			{
				level.Player.Protagonist.Position = new Vector2i(x, y);
			}
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x00033250 File Offset: 0x00031450
		private void ProcessCommandRestart(string[] args)
		{
			if (this.LevelGameState == null || this.LevelGameState.Level == null)
			{
				return;
			}
			Level level = this.LevelGameState.Level;
			string a = string.Empty;
			if (args.Length >= 1)
			{
				a = args[0].ToLower();
			}
			if (!(a == "checkpoint") && !(a == "starpost"))
			{
				level.FadeOut(LevelState.Restart);
				return;
			}
			level.FadeOut(LevelState.RestartCheckpoint);
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x000332C0 File Offset: 0x000314C0
		private static string[] GetTokens(string line)
		{
			List<string> list = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in line)
			{
				if (c == '"')
				{
					flag = !flag;
				}
				else if (char.IsWhiteSpace(c) && !flag)
				{
					if (stringBuilder.Length > 0)
					{
						list.Add(stringBuilder.ToString());
						stringBuilder.Clear();
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(stringBuilder.ToString());
			}
			return list.ToArray();
		}

		// Token: 0x04000787 RID: 1927
		private const string DefaultFontResourceKey = "SONICORCA/FONTS/SEGOEUI";

		// Token: 0x04000788 RID: 1928
		private readonly SonicOrcaGameContext _context;

		// Token: 0x04000789 RID: 1929
		private ResourceSession _resourceSession;

		// Token: 0x0400078A RID: 1930
		private Font _font;

		// Token: 0x0400078B RID: 1931
		private bool _loadingResources;

		// Token: 0x0400078C RID: 1932
		private bool _resourcesLoaded;

		// Token: 0x0400078D RID: 1933
		private float _opacity;

		// Token: 0x0400078E RID: 1934
		private readonly StringBuilder _currentLine = new StringBuilder();

		// Token: 0x0400078F RID: 1935
		private readonly List<string> _buffer = new List<string>();

		// Token: 0x04000790 RID: 1936
		private readonly List<string> _history = new List<string>();

		// Token: 0x04000791 RID: 1937
		private int _historyScrollIndex;
	}
}
