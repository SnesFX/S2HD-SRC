using System;
using OpenTK.Input;

namespace OpenTK.Platform.X11
{
	// Token: 0x0200058D RID: 1421
	internal sealed class X11Mouse : IMouseDriver2
	{
		// Token: 0x0600459F RID: 17823 RVA: 0x000BF1AC File Offset: 0x000BD3AC
		public X11Mouse()
		{
			this.mouse.IsConnected = true;
			this.cursor.IsConnected = true;
			this.display = API.DefaultDisplay;
			this.root_window = Functions.XRootWindow(this.display, Functions.XDefaultScreen(this.display));
		}

		// Token: 0x060045A0 RID: 17824 RVA: 0x000BF218 File Offset: 0x000BD418
		public MouseState GetState()
		{
			this.ProcessEvents();
			return this.mouse;
		}

		// Token: 0x060045A1 RID: 17825 RVA: 0x000BF228 File Offset: 0x000BD428
		public MouseState GetState(int index)
		{
			this.ProcessEvents();
			if (index == 0)
			{
				return this.mouse;
			}
			return default(MouseState);
		}

		// Token: 0x060045A2 RID: 17826 RVA: 0x000BF250 File Offset: 0x000BD450
		public MouseState GetCursorState()
		{
			this.ProcessEvents();
			return this.cursor;
		}

		// Token: 0x060045A3 RID: 17827 RVA: 0x000BF260 File Offset: 0x000BD460
		public void SetPosition(double x, double y)
		{
			this.ProcessEvents();
			using (new XLock(this.display))
			{
				this.mouse_detached = true;
				this.mouse_detached_x = (int)x;
				this.mouse_detached_y = (int)y;
				Functions.XWarpPointer(this.display, IntPtr.Zero, this.root_window, 0, 0, 0U, 0U, (int)x, (int)y);
			}
		}

		// Token: 0x060045A4 RID: 17828 RVA: 0x000BF2D8 File Offset: 0x000BD4D8
		private void ProcessEvents()
		{
			using (new XLock(this.display))
			{
				IntPtr window = this.root_window;
				IntPtr intPtr;
				IntPtr intPtr2;
				int num;
				int num2;
				int num3;
				int num4;
				int num5;
				Functions.XQueryPointer(this.display, window, out intPtr, out intPtr2, out num, out num2, out num3, out num4, out num5);
				this.cursor.X = num;
				this.cursor.Y = num2;
				if (!this.mouse_detached)
				{
					this.mouse.X = num;
					this.mouse.Y = num2;
				}
				else
				{
					this.mouse.X = this.mouse.X + (num - this.mouse_detached_x);
					this.mouse.Y = this.mouse.Y + (num2 - this.mouse_detached_y);
					this.mouse_detached_x = num;
					this.mouse_detached_y = num2;
				}
				this.cursor[MouseButton.Left] = (this.mouse[MouseButton.Left] = ((num5 & 256) != 0));
				this.cursor[MouseButton.Middle] = (this.mouse[MouseButton.Middle] = ((num5 & 512) != 0));
				this.cursor[MouseButton.Right] = (this.mouse[MouseButton.Right] = ((num5 & 1024) != 0));
				this.cursor[MouseButton.Button1] = (this.mouse[MouseButton.Button1] = ((num5 & 8192) != 0));
				this.cursor[MouseButton.Button2] = (this.mouse[MouseButton.Button2] = ((num5 & 16384) != 0));
				this.cursor[MouseButton.Button3] = (this.mouse[MouseButton.Button3] = ((num5 & 32768) != 0));
			}
		}

		// Token: 0x04005099 RID: 20633
		private readonly IntPtr display;

		// Token: 0x0400509A RID: 20634
		private readonly IntPtr root_window;

		// Token: 0x0400509B RID: 20635
		private MouseState mouse = default(MouseState);

		// Token: 0x0400509C RID: 20636
		private MouseState cursor = default(MouseState);

		// Token: 0x0400509D RID: 20637
		private bool mouse_detached;

		// Token: 0x0400509E RID: 20638
		private int mouse_detached_x;

		// Token: 0x0400509F RID: 20639
		private int mouse_detached_y;
	}
}
