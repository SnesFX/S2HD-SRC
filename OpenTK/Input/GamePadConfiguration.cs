using System;
using System.Collections.Generic;

namespace OpenTK.Input
{
	// Token: 0x02000AFF RID: 2815
	internal sealed class GamePadConfiguration
	{
		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x0600596E RID: 22894 RVA: 0x000F2DE0 File Offset: 0x000F0FE0
		// (set) Token: 0x0600596F RID: 22895 RVA: 0x000F2DE8 File Offset: 0x000F0FE8
		public Guid Guid
		{
			get
			{
				return this.guid;
			}
			private set
			{
				this.guid = value;
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06005970 RID: 22896 RVA: 0x000F2DF4 File Offset: 0x000F0FF4
		// (set) Token: 0x06005971 RID: 22897 RVA: 0x000F2DFC File Offset: 0x000F0FFC
		public string Name
		{
			get
			{
				return this.name;
			}
			private set
			{
				this.name = value;
			}
		}

		// Token: 0x06005972 RID: 22898 RVA: 0x000F2E08 File Offset: 0x000F1008
		public GamePadConfiguration(string configuration)
		{
			this.ParseConfiguration(configuration);
		}

		// Token: 0x06005973 RID: 22899 RVA: 0x000F2E24 File Offset: 0x000F1024
		public List<GamePadConfigurationItem>.Enumerator GetEnumerator()
		{
			return this.configuration_items.GetEnumerator();
		}

		// Token: 0x06005974 RID: 22900 RVA: 0x000F2E34 File Offset: 0x000F1034
		private void ParseConfiguration(string configuration)
		{
			if (string.IsNullOrEmpty(configuration))
			{
				throw new ArgumentNullException();
			}
			string[] array = configuration.Split(GamePadConfiguration.ConfigurationSeparator, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length < 3)
			{
				throw new ArgumentException();
			}
			this.Guid = new Guid(array[0]);
			this.Name = array[1];
			for (int i = 2; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					':'
				});
				GamePadConfigurationTarget target = GamePadConfiguration.ParseTarget(array2[0]);
				GamePadConfigurationSource source = GamePadConfiguration.ParseSource(array2[1]);
				this.configuration_items.Add(new GamePadConfigurationItem(source, target));
			}
		}

		// Token: 0x06005975 RID: 22901 RVA: 0x000F2ED0 File Offset: 0x000F10D0
		private static GamePadConfigurationTarget ParseTarget(string target)
		{
			switch (target)
			{
			case "a":
				return new GamePadConfigurationTarget(Buttons.A);
			case "b":
				return new GamePadConfigurationTarget(Buttons.B);
			case "x":
				return new GamePadConfigurationTarget(Buttons.X);
			case "y":
				return new GamePadConfigurationTarget(Buttons.Y);
			case "start":
				return new GamePadConfigurationTarget(Buttons.Start);
			case "back":
				return new GamePadConfigurationTarget(Buttons.Back);
			case "guide":
				return new GamePadConfigurationTarget(Buttons.Home);
			case "leftshoulder":
				return new GamePadConfigurationTarget(Buttons.LeftShoulder);
			case "rightshoulder":
				return new GamePadConfigurationTarget(Buttons.RightShoulder);
			case "leftstick":
				return new GamePadConfigurationTarget(Buttons.LeftStick);
			case "rightstick":
				return new GamePadConfigurationTarget(Buttons.RightStick);
			case "dpup":
				return new GamePadConfigurationTarget(Buttons.DPadUp);
			case "dpdown":
				return new GamePadConfigurationTarget(Buttons.DPadDown);
			case "dpleft":
				return new GamePadConfigurationTarget(Buttons.DPadLeft);
			case "dpright":
				return new GamePadConfigurationTarget(Buttons.DPadRight);
			case "leftx":
				return new GamePadConfigurationTarget(GamePadAxes.LeftX);
			case "lefty":
				return new GamePadConfigurationTarget(GamePadAxes.LeftY);
			case "rightx":
				return new GamePadConfigurationTarget(GamePadAxes.RightX);
			case "righty":
				return new GamePadConfigurationTarget(GamePadAxes.RightY);
			case "lefttrigger":
				return new GamePadConfigurationTarget(GamePadAxes.LeftTrigger);
			case "righttrigger":
				return new GamePadConfigurationTarget(GamePadAxes.RightTrigger);
			}
			return default(GamePadConfigurationTarget);
		}

		// Token: 0x06005976 RID: 22902 RVA: 0x000F313C File Offset: 0x000F133C
		private static GamePadConfigurationSource ParseSource(string item)
		{
			if (string.IsNullOrEmpty(item))
			{
				return default(GamePadConfigurationSource);
			}
			char c = item[0];
			switch (c)
			{
			case 'a':
				return new GamePadConfigurationSource(GamePadConfiguration.ParseAxis(item));
			case 'b':
				return new GamePadConfigurationSource(GamePadConfiguration.ParseButton(item));
			default:
				if (c != 'h')
				{
					throw new InvalidOperationException("[Input] Invalid GamePad configuration value");
				}
				throw new NotImplementedException();
			}
		}

		// Token: 0x06005977 RID: 22903 RVA: 0x000F31A4 File Offset: 0x000F13A4
		private static JoystickAxis ParseAxis(string item)
		{
			JoystickAxis joystickAxis = JoystickAxis.Axis0;
			int num = int.Parse(item.Substring(1));
			return joystickAxis + num;
		}

		// Token: 0x06005978 RID: 22904 RVA: 0x000F31C4 File Offset: 0x000F13C4
		private static JoystickButton ParseButton(string item)
		{
			JoystickButton joystickButton = JoystickButton.Button0;
			int num = int.Parse(item.Substring(1));
			return joystickButton + num;
		}

		// Token: 0x0400B4B8 RID: 46264
		private static readonly char[] ConfigurationSeparator = new char[]
		{
			','
		};

		// Token: 0x0400B4B9 RID: 46265
		private Guid guid;

		// Token: 0x0400B4BA RID: 46266
		private string name;

		// Token: 0x0400B4BB RID: 46267
		private readonly List<GamePadConfigurationItem> configuration_items = new List<GamePadConfigurationItem>();
	}
}
