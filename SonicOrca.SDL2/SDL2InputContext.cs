using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SDL2;
using SonicOrca.Geometry;
using SonicOrca.Input;

namespace SonicOrca.SDL2
{
	// Token: 0x0200000B RID: 11
	public class SDL2InputContext : InputContext, IDisposable
	{
		// Token: 0x06000062 RID: 98 RVA: 0x0000321C File Offset: 0x0000141C
		public SDL2InputContext(SDL2Platform platform)
		{
			this._platform = platform;
			this._windowHandle = ((SDL2WindowContext)this._platform.Window).WindowHandle;
			Trace.WriteLine("Initialising SDL2 joystick");
			if (SDL.SDL_InitSubSystem(512U) != 0)
			{
				throw SDL2Exception.FromError("Unable to initialise SDL2 joystick subsystem.");
			}
			Trace.WriteLine("Initialising SDL2 game controller");
			if (SDL.SDL_InitSubSystem(8192U) != 0)
			{
				throw SDL2Exception.FromError("Unable to initialise SDL2 game controller subsystem.");
			}
			Trace.WriteLine("Initialising SDL2 haptic");
			if (SDL.SDL_InitSubSystem(4096U) != 0)
			{
				throw SDL2Exception.FromError("Unable to initialise SDL2 haptic subsystem.");
			}
			this.FindGameControllers();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000032E0 File Offset: 0x000014E0
		public void Dispose()
		{
			Trace.WriteLine("Quitting SDL2 haptic");
			SDL.SDL_QuitSubSystem(4096U);
			Trace.WriteLine("Quitting SDL2 game controller");
			SDL.SDL_QuitSubSystem(8192U);
			Trace.WriteLine("Quitting SDL2 joystick");
			SDL.SDL_QuitSubSystem(512U);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003320 File Offset: 0x00001520
		private void FindGameControllers()
		{
			this._gameControllers.Clear();
			for (int i = 0; i < SDL.SDL_NumJoysticks(); i++)
			{
				if (SDL.SDL_IsGameController(i) != SDL.SDL_bool.SDL_FALSE)
				{
					IntPtr intPtr = SDL.SDL_GameControllerOpen(i);
					if (intPtr != IntPtr.Zero)
					{
						IntPtr intPtr2 = IntPtr.Zero;
						IntPtr joystick = SDL.SDL_GameControllerGetJoystick(intPtr);
						this._gameControllers.Add(intPtr);
						intPtr2 = SDL.SDL_HapticOpenFromJoystick(joystick);
						if (intPtr2 != IntPtr.Zero && SDL.SDL_HapticRumbleInit(intPtr2) != 0)
						{
							intPtr2 = IntPtr.Zero;
						}
						this._haptic.Add(intPtr2);
					}
				}
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000033AC File Offset: 0x000015AC
		private void VibrateController(int index, double left, double right, int duration)
		{
			if (this._haptic.Count <= index)
			{
				return;
			}
			IntPtr intPtr = this._haptic[index];
			if (intPtr == IntPtr.Zero)
			{
				return;
			}
			SDL.SDL_HapticRumblePlay(intPtr, (float)((left + right) / 2.0), (uint)duration);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000033FC File Offset: 0x000015FC
		public unsafe override void UpdateCurrentState()
		{
			int num = 0;
			base.TextInput = null;
			SDL.SDL_StartTextInput();
			int num2 = SDL.SDL_PeepEvents(this.events, this.events.Length, SDL.SDL_eventaction.SDL_PEEKEVENT, SDL.SDL_EventType.SDL_FIRSTEVENT, SDL.SDL_EventType.SDL_LASTEVENT);
			SDL.SDL_Event sdl_Event;
			for (int i = 0; i < num2; i++)
			{
				sdl_Event = this.events[i];
				SDL.SDL_EventType type = sdl_Event.type;
				if (type != SDL.SDL_EventType.SDL_TEXTEDITING)
				{
					if (type != SDL.SDL_EventType.SDL_TEXTINPUT)
					{
						if (type == SDL.SDL_EventType.SDL_MOUSEWHEEL)
						{
							num = sdl_Event.wheel.y;
						}
					}
					else
					{
						IntPtr ptr = (IntPtr)((void*)(&sdl_Event.text.text.FixedElementField));
						byte[] array = new byte[32];
						int num3 = 0;
						while (num3 < 32 && (array[num3] = Marshal.ReadByte(ptr, num3)) != 0)
						{
							num3++;
						}
						base.TextInput = Encoding.UTF8.GetString(array, 0, num3);
					}
				}
			}
			while (SDL.SDL_PollEvent(out sdl_Event) != 0)
			{
			}
			int num4;
			IntPtr ptr2 = SDL.SDL_GetKeyboardState(out num4);
			bool[] array2 = new bool[num4];
			for (int j = 0; j < num4; j++)
			{
				array2[j] = (Marshal.ReadByte(ptr2, j) > 0);
			}
			int x2;
			int y;
			uint num5 = SDL.SDL_GetMouseState(out x2, out y);
			int num6;
			int num7;
			SDL.SDL_GetWindowSize(this._windowHandle, out num6, out num7);
			MouseState mouseState = default(MouseState);
			mouseState.X = x2;
			mouseState.Y = y;
			mouseState.Left = ((num5 & SDL.SDL_BUTTON_LMASK) > 0U);
			mouseState.Middle = ((num5 & SDL.SDL_BUTTON_MMASK) > 0U);
			mouseState.Right = ((num5 & SDL.SDL_BUTTON_RMASK) > 0U);
			mouseState.Wheel = (double)num;
			KeyboardState keyboardState = new KeyboardState(array2);
			GamePadInputState[] array3 = (from x in Enumerable.Range(0, 4)
			select default(GamePadInputState)).ToArray<GamePadInputState>();
			for (int k = 0; k < this._gameControllers.Count; k++)
			{
				IntPtr intPtr = this._gameControllers[k];
				SDL.SDL_GameControllerGetJoystick(intPtr);
				GamePadInputState gamePadInputState = array3[k];
				double minTolerance = 0.2;
				double maxTolerance = 0.75;
				gamePadInputState.South = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A);
				gamePadInputState.East = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B);
				gamePadInputState.West = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X);
				gamePadInputState.North = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y);
				gamePadInputState.Start = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_START);
				gamePadInputState.Select = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_BACK);
				gamePadInputState.LeftBumper = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSHOULDER);
				gamePadInputState.RightBumper = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSHOULDER);
				gamePadInputState.LeftAxisButton = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSTICK);
				gamePadInputState.RightAxisButton = this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSTICK);
				Vector2i pov = default(Vector2i);
				if (this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT))
				{
					pov.X = -1;
				}
				if (this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT))
				{
					pov.X = 1;
				}
				if (this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP))
				{
					pov.Y = -1;
				}
				if (this.IsGameControllerButtonDown(intPtr, SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN))
				{
					pov.Y = 1;
				}
				gamePadInputState.POV = pov;
				gamePadInputState.LeftAxis = this.GetGameControllerAxis(intPtr, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTY, minTolerance, maxTolerance);
				gamePadInputState.RightAxis = this.GetGameControllerAxis(intPtr, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTX, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_RIGHTY, minTolerance, maxTolerance);
				gamePadInputState.LeftTrigger = this.GetGameControllerAxis(intPtr, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERLEFT, minTolerance, maxTolerance);
				gamePadInputState.RightTrigger = this.GetGameControllerAxis(intPtr, SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_TRIGGERRIGHT, minTolerance, maxTolerance);
				array3[k] = gamePadInputState;
			}
			base.CurrentState = new InputState(mouseState, keyboardState, array3);
			GamePadOutputState[] gamePad = base.OutputState.GamePad;
			if (base.IsVibrationEnabled && base.OutputState.GamePad != null)
			{
				for (int l = 0; l < gamePad.Length; l++)
				{
					this.VibrateController(l, gamePad[l].LeftVibration, gamePad[l].RightVibration, 4000);
				}
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000037F4 File Offset: 0x000019F4
		private bool IsGameControllerButtonDown(IntPtr controller, SDL.SDL_GameControllerButton button)
		{
			return SDL.SDL_GameControllerGetButton(controller, button) > 0;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003800 File Offset: 0x00001A00
		private Vector2 GetGameControllerAxis(IntPtr controller, SDL.SDL_GameControllerAxis x, SDL.SDL_GameControllerAxis y, double minTolerance, double maxTolerance)
		{
			return new Vector2(this.GetGameControllerAxis(controller, x, minTolerance, maxTolerance), this.GetGameControllerAxis(controller, y, minTolerance, maxTolerance));
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003820 File Offset: 0x00001A20
		private double GetGameControllerAxis(IntPtr controller, SDL.SDL_GameControllerAxis axis, double minTolerance, double maxTolerance)
		{
			double value = (double)SDL.SDL_GameControllerGetAxis(controller, axis) / 32767.0;
			double num = Math.Abs(value);
			if (num < minTolerance)
			{
				return 0.0;
			}
			if (num > maxTolerance)
			{
				return 1.0 * (double)Math.Sign(value);
			}
			return (num - minTolerance) / (maxTolerance - minTolerance) * (double)Math.Sign(value);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000387C File Offset: 0x00001A7C
		public override char GetKeyCode(int scancode)
		{
			return (char)SDL.SDL_GetKeyFromScancode((SDL.SDL_Scancode)scancode);
		}

		// Token: 0x0400002B RID: 43
		private readonly SDL2Platform _platform;

		// Token: 0x0400002C RID: 44
		private readonly IntPtr _windowHandle;

		// Token: 0x0400002D RID: 45
		private readonly List<IntPtr> _gameControllers = new List<IntPtr>();

		// Token: 0x0400002E RID: 46
		private readonly List<IntPtr> _haptic = new List<IntPtr>();

		// Token: 0x0400002F RID: 47
		private SDL.SDL_Event[] events = new SDL.SDL_Event[512];
	}
}
