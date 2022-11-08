using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK.Input;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A4 RID: 1444
	internal class Sdl2InputDriver : IInputDriver2, IDisposable
	{
		// Token: 0x06004621 RID: 17953 RVA: 0x000C13DC File Offset: 0x000BF5DC
		public Sdl2InputDriver()
		{
			lock (SDL.Sync)
			{
				SDL.GameControllerEventState(EventState.Enable);
				SDL.JoystickEventState(EventState.Enable);
				this.EventFilterDelegate = Marshal.GetFunctionPointerForDelegate(this.EventFilterDelegate_GCUnsafe);
				this.driver_handle = new IntPtr(Sdl2InputDriver.count++);
				Sdl2InputDriver.DriverHandles.Add(this.driver_handle, this);
				SDL.AddEventWatch(this.EventFilterDelegate, this.driver_handle);
				SDL.InitSubSystem(SystemFlags.JOYSTICK);
				SDL.InitSubSystem(SystemFlags.GAMECONTROLLER);
			}
		}

		// Token: 0x06004622 RID: 17954 RVA: 0x000C14BC File Offset: 0x000BF6BC
		private unsafe static int FilterInputEvents(IntPtr driver_handle, IntPtr e)
		{
			try
			{
				Event @event = *(Event*)((void*)e);
				Sdl2InputDriver sdl2InputDriver;
				if (Sdl2InputDriver.DriverHandles.TryGetValue(driver_handle, out sdl2InputDriver))
				{
					EventType type = @event.Type;
					switch (type)
					{
					case EventType.KEYDOWN:
					case EventType.KEYUP:
						sdl2InputDriver.keyboard_driver.ProcessKeyboardEvent(@event.Key);
						break;
					default:
						switch (type)
						{
						case EventType.MOUSEMOTION:
							sdl2InputDriver.mouse_driver.ProcessMouseEvent(@event.Motion);
							break;
						case EventType.MOUSEBUTTONDOWN:
						case EventType.MOUSEBUTTONUP:
							sdl2InputDriver.mouse_driver.ProcessMouseEvent(@event.Button);
							break;
						case EventType.MOUSEWHEEL:
							sdl2InputDriver.mouse_driver.ProcessWheelEvent(@event.Wheel);
							break;
						default:
							switch (type)
							{
							case EventType.JOYAXISMOTION:
								sdl2InputDriver.joystick_driver.ProcessJoystickEvent(@event.JoyAxis);
								break;
							case EventType.JOYBALLMOTION:
								sdl2InputDriver.joystick_driver.ProcessJoystickEvent(@event.JoyBall);
								break;
							case EventType.JOYHATMOTION:
								sdl2InputDriver.joystick_driver.ProcessJoystickEvent(@event.JoyHat);
								break;
							case EventType.JOYBUTTONDOWN:
							case EventType.JOYBUTTONUP:
								sdl2InputDriver.joystick_driver.ProcessJoystickEvent(@event.JoyButton);
								break;
							case EventType.JOYDEVICEADDED:
							case EventType.JOYDEVICEREMOVED:
								sdl2InputDriver.joystick_driver.ProcessJoystickEvent(@event.JoyDevice);
								break;
							}
							break;
						}
						break;
					}
				}
			}
			catch (Exception)
			{
			}
			return 0;
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06004623 RID: 17955 RVA: 0x000C1628 File Offset: 0x000BF828
		public IMouseDriver2 MouseDriver
		{
			get
			{
				return this.mouse_driver;
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06004624 RID: 17956 RVA: 0x000C1630 File Offset: 0x000BF830
		public IKeyboardDriver2 KeyboardDriver
		{
			get
			{
				return this.keyboard_driver;
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06004625 RID: 17957 RVA: 0x000C1638 File Offset: 0x000BF838
		public IGamePadDriver GamePadDriver
		{
			get
			{
				return this.joystick_driver;
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06004626 RID: 17958 RVA: 0x000C1640 File Offset: 0x000BF840
		public IJoystickDriver2 JoystickDriver
		{
			get
			{
				return this.joystick_driver;
			}
		}

		// Token: 0x06004627 RID: 17959 RVA: 0x000C1648 File Offset: 0x000BF848
		private void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				if (manual)
				{
					this.joystick_driver.Dispose();
					lock (SDL.Sync)
					{
						SDL.DelEventWatch(this.EventFilterDelegate, this.driver_handle);
					}
					Sdl2InputDriver.DriverHandles.Remove(this.driver_handle);
				}
				this.disposed = true;
			}
		}

		// Token: 0x06004628 RID: 17960 RVA: 0x000C16BC File Offset: 0x000BF8BC
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06004629 RID: 17961 RVA: 0x000C16CC File Offset: 0x000BF8CC
		~Sdl2InputDriver()
		{
			this.Dispose(false);
		}

		// Token: 0x04005215 RID: 21013
		private static readonly Dictionary<IntPtr, Sdl2InputDriver> DriverHandles = new Dictionary<IntPtr, Sdl2InputDriver>();

		// Token: 0x04005216 RID: 21014
		private readonly IntPtr driver_handle;

		// Token: 0x04005217 RID: 21015
		private readonly Sdl2Keyboard keyboard_driver = new Sdl2Keyboard();

		// Token: 0x04005218 RID: 21016
		private readonly Sdl2Mouse mouse_driver = new Sdl2Mouse();

		// Token: 0x04005219 RID: 21017
		private readonly Sdl2JoystickDriver joystick_driver = new Sdl2JoystickDriver();

		// Token: 0x0400521A RID: 21018
		private readonly EventFilter EventFilterDelegate_GCUnsafe = new EventFilter(Sdl2InputDriver.FilterInputEvents);

		// Token: 0x0400521B RID: 21019
		private readonly IntPtr EventFilterDelegate;

		// Token: 0x0400521C RID: 21020
		private static int count;

		// Token: 0x0400521D RID: 21021
		private bool disposed;
	}
}
