using System;
using OpenTK.Platform;

namespace OpenTK.Input
{
	// Token: 0x02000512 RID: 1298
	public sealed class GamePad
	{
		// Token: 0x06003D22 RID: 15650 RVA: 0x000A120C File Offset: 0x0009F40C
		private GamePad()
		{
		}

		// Token: 0x06003D23 RID: 15651 RVA: 0x000A1214 File Offset: 0x0009F414
		public static GamePadCapabilities GetCapabilities(int index)
		{
			if (index < 0)
			{
				throw new IndexOutOfRangeException();
			}
			return GamePad.driver.GetCapabilities(index);
		}

		// Token: 0x06003D24 RID: 15652 RVA: 0x000A122C File Offset: 0x0009F42C
		public static GamePadState GetState(int index)
		{
			return GamePad.driver.GetState(index);
		}

		// Token: 0x06003D25 RID: 15653 RVA: 0x000A123C File Offset: 0x0009F43C
		public static bool SetVibration(int index, float left, float right)
		{
			return GamePad.driver.SetVibration(index, left, right);
		}

		// Token: 0x04004CF5 RID: 19701
		internal const int MaxAxisCount = 10;

		// Token: 0x04004CF6 RID: 19702
		internal const int MaxDPadCount = 2;

		// Token: 0x04004CF7 RID: 19703
		private static readonly IGamePadDriver driver = Factory.Default.CreateGamePadDriver();
	}
}
