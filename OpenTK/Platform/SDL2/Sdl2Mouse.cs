using System;
using OpenTK.Input;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005A7 RID: 1447
	internal class Sdl2Mouse : IMouseDriver2
	{
		// Token: 0x06004634 RID: 17972 RVA: 0x000C1E08 File Offset: 0x000C0008
		public Sdl2Mouse()
		{
			this.state.IsConnected = true;
		}

		// Token: 0x06004635 RID: 17973 RVA: 0x000C1E1C File Offset: 0x000C001C
		internal static MouseButton TranslateButton(Button button)
		{
			switch (button)
			{
			case Button.Left:
				return MouseButton.Left;
			case Button.Middle:
				return MouseButton.Middle;
			case Button.Right:
				return MouseButton.Right;
			case Button.X1:
				return MouseButton.Button1;
			case Button.X2:
				return MouseButton.Button2;
			default:
				return MouseButton.Left;
			}
		}

		// Token: 0x06004636 RID: 17974 RVA: 0x000C1E54 File Offset: 0x000C0054
		private void SetButtonState(MouseButton button, bool pressed)
		{
			if (pressed)
			{
				this.state.EnableBit((int)button);
				return;
			}
			this.state.DisableBit((int)button);
		}

		// Token: 0x06004637 RID: 17975 RVA: 0x000C1E74 File Offset: 0x000C0074
		public void ProcessWheelEvent(MouseWheelEvent wheel)
		{
			this.state.SetScrollRelative((float)wheel.X, (float)wheel.Y);
		}

		// Token: 0x06004638 RID: 17976 RVA: 0x000C1E94 File Offset: 0x000C0094
		public void ProcessMouseEvent(MouseMotionEvent motion)
		{
			this.state.X = this.state.X + motion.Xrel;
			this.state.Y = this.state.Y + motion.Yrel;
		}

		// Token: 0x06004639 RID: 17977 RVA: 0x000C1EC8 File Offset: 0x000C00C8
		public void ProcessMouseEvent(MouseButtonEvent button)
		{
			bool pressed = button.State == State.Pressed;
			this.SetButtonState(Sdl2Mouse.TranslateButton(button.Button), pressed);
		}

		// Token: 0x0600463A RID: 17978 RVA: 0x000C1EF4 File Offset: 0x000C00F4
		public MouseState GetState()
		{
			return this.state;
		}

		// Token: 0x0600463B RID: 17979 RVA: 0x000C1EFC File Offset: 0x000C00FC
		public MouseState GetState(int index)
		{
			if (index == 0)
			{
				return this.state;
			}
			return default(MouseState);
		}

		// Token: 0x0600463C RID: 17980 RVA: 0x000C1F1C File Offset: 0x000C011C
		public MouseState GetCursorState()
		{
			int x;
			int y;
			ButtonFlags mouseState = SDL.GetMouseState(out x, out y);
			MouseState mouseState2 = default(MouseState);
			mouseState2.SetIsConnected(true);
			mouseState2.X = x;
			mouseState2.Y = y;
			mouseState2.SetScrollAbsolute(this.state.Scroll.X, this.state.Scroll.Y);
			mouseState2[MouseButton.Left] = ((mouseState & ButtonFlags.Left) != (ButtonFlags)0);
			mouseState2[MouseButton.Middle] = ((mouseState & ButtonFlags.Middle) != (ButtonFlags)0);
			mouseState2[MouseButton.Right] = ((mouseState & ButtonFlags.Right) != (ButtonFlags)0);
			mouseState2[MouseButton.Button1] = ((mouseState & ButtonFlags.X1) != (ButtonFlags)0);
			mouseState2[MouseButton.Button2] = ((mouseState & ButtonFlags.X2) != (ButtonFlags)0);
			return this.state;
		}

		// Token: 0x0600463D RID: 17981 RVA: 0x000C1FE0 File Offset: 0x000C01E0
		public void SetPosition(double x, double y)
		{
			SDL.WarpMouseInWindow(IntPtr.Zero, (int)x, (int)y);
		}

		// Token: 0x04005221 RID: 21025
		private MouseState state;
	}
}
