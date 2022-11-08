using System;
using OpenTK.Platform;

namespace OpenTK.Input
{
	// Token: 0x02000525 RID: 1317
	public static class Mouse
	{
		// Token: 0x06003DB4 RID: 15796 RVA: 0x000A2130 File Offset: 0x000A0330
		public static MouseState GetState()
		{
			MouseState state;
			lock (Mouse.SyncRoot)
			{
				state = Mouse.driver.GetState();
			}
			return state;
		}

		// Token: 0x06003DB5 RID: 15797 RVA: 0x000A2170 File Offset: 0x000A0370
		public static MouseState GetState(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			MouseState state;
			lock (Mouse.SyncRoot)
			{
				state = Mouse.driver.GetState(index);
			}
			return state;
		}

		// Token: 0x06003DB6 RID: 15798 RVA: 0x000A21C0 File Offset: 0x000A03C0
		public static MouseState GetCursorState()
		{
			MouseState cursorState;
			lock (Mouse.SyncRoot)
			{
				cursorState = Mouse.driver.GetCursorState();
			}
			return cursorState;
		}

		// Token: 0x06003DB7 RID: 15799 RVA: 0x000A2200 File Offset: 0x000A0400
		public static void SetPosition(double x, double y)
		{
			lock (Mouse.SyncRoot)
			{
				Mouse.driver.SetPosition(x, y);
			}
		}

		// Token: 0x04004DD0 RID: 19920
		private static readonly IMouseDriver2 driver = Factory.Default.CreateMouseDriver();

		// Token: 0x04004DD1 RID: 19921
		private static readonly object SyncRoot = new object();
	}
}
