using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace OpenTK.Platform
{
	// Token: 0x0200002D RID: 45
	internal class MappedGamePadDriver : IGamePadDriver
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x00013D90 File Offset: 0x00011F90
		public GamePadState GetState(int index)
		{
			JoystickState state = Joystick.GetState(index);
			GamePadState result = default(GamePadState);
			if (state.IsConnected)
			{
				result.SetConnected(true);
				result.SetPacketNumber(state.PacketNumber);
				GamePadConfiguration configuration = this.GetConfiguration(Joystick.GetGuid(index));
				foreach (GamePadConfigurationItem gamePadConfigurationItem in configuration)
				{
					switch (gamePadConfigurationItem.Source.Type)
					{
					case ConfigurationType.Axis:
					{
						JoystickAxis axis = gamePadConfigurationItem.Source.Axis;
						short axisRaw = state.GetAxisRaw(axis);
						switch (gamePadConfigurationItem.Target.Type)
						{
						case ConfigurationType.Axis:
							result.SetAxis(gamePadConfigurationItem.Target.Axis, axisRaw);
							break;
						case ConfigurationType.Button:
							result.SetButton(gamePadConfigurationItem.Target.Button, Math.Abs(axisRaw) >= 16383);
							break;
						}
						break;
					}
					case ConfigurationType.Button:
					{
						JoystickButton button = gamePadConfigurationItem.Source.Button;
						bool flag = state.GetButton(button) == ButtonState.Pressed;
						switch (gamePadConfigurationItem.Target.Type)
						{
						case ConfigurationType.Axis:
							result.SetAxis(gamePadConfigurationItem.Target.Axis, flag ? short.MaxValue : 0);
							break;
						case ConfigurationType.Button:
							result.SetButton(gamePadConfigurationItem.Target.Button, flag);
							break;
						}
						break;
					}
					}
				}
			}
			return result;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00013F58 File Offset: 0x00012158
		public GamePadCapabilities GetCapabilities(int index)
		{
			GamePadCapabilities result;
			if (Joystick.GetCapabilities(index).IsConnected)
			{
				GamePadConfiguration configuration = this.GetConfiguration(Joystick.GetGuid(index));
				GamePadAxes gamePadAxes = (GamePadAxes)0;
				Buttons buttons = (Buttons)0;
				foreach (GamePadConfigurationItem gamePadConfigurationItem in configuration)
				{
					switch (gamePadConfigurationItem.Target.Type)
					{
					case ConfigurationType.Axis:
						gamePadAxes |= gamePadConfigurationItem.Target.Axis;
						break;
					case ConfigurationType.Button:
						buttons |= gamePadConfigurationItem.Target.Button;
						break;
					}
				}
				result = new GamePadCapabilities(GamePadType.GamePad, gamePadAxes, buttons, true);
			}
			else
			{
				result = default(GamePadCapabilities);
			}
			return result;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00014030 File Offset: 0x00012230
		public string GetName(int index)
		{
			JoystickCapabilities capabilities = Joystick.GetCapabilities(index);
			string result = string.Empty;
			if (capabilities.IsConnected)
			{
				GamePadConfiguration configuration = this.GetConfiguration(Joystick.GetGuid(index));
				result = configuration.Name;
			}
			return result;
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00014068 File Offset: 0x00012268
		public bool SetVibration(int index, float left, float right)
		{
			return false;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0001406C File Offset: 0x0001226C
		private GamePadConfiguration GetConfiguration(Guid guid)
		{
			if (!this.configurations.ContainsKey(guid))
			{
				string configuration = this.database[guid];
				GamePadConfiguration value = new GamePadConfiguration(configuration);
				this.configurations.Add(guid, value);
			}
			return this.configurations[guid];
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000140B4 File Offset: 0x000122B4
		private bool IsMapped(GamePadConfigurationSource item)
		{
			return item.Type != ConfigurationType.Unmapped;
		}

		// Token: 0x040000B8 RID: 184
		private readonly GamePadConfigurationDatabase database = new GamePadConfigurationDatabase();

		// Token: 0x040000B9 RID: 185
		private readonly Dictionary<Guid, GamePadConfiguration> configurations = new Dictionary<Guid, GamePadConfiguration>();
	}
}
