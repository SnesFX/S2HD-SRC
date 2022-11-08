using System;
using OpenTK.Platform;

namespace OpenTK.Input
{
	// Token: 0x02000511 RID: 1297
	public static class Keyboard
	{
		// Token: 0x06003D1F RID: 15647 RVA: 0x000A1160 File Offset: 0x0009F360
		public static KeyboardState GetState()
		{
			KeyboardState state;
			lock (Keyboard.SyncRoot)
			{
				state = Keyboard.driver.GetState();
			}
			return state;
		}

		// Token: 0x06003D20 RID: 15648 RVA: 0x000A11A0 File Offset: 0x0009F3A0
		public static KeyboardState GetState(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			KeyboardState state;
			lock (Keyboard.SyncRoot)
			{
				state = Keyboard.driver.GetState(index);
			}
			return state;
		}

		// Token: 0x04004CF3 RID: 19699
		private static readonly IKeyboardDriver2 driver = Factory.Default.CreateKeyboardDriver();

		// Token: 0x04004CF4 RID: 19700
		private static readonly object SyncRoot = new object();
	}
}
