using System;

namespace SonicOrca
{
	// Token: 0x0200009D RID: 157
	public struct UpdateResult
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x0001A23C File Offset: 0x0001843C
		public UpdateResultType Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x0001A244 File Offset: 0x00018444
		public int WaitTicks
		{
			get
			{
				return this._waitTicks;
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0001A24C File Offset: 0x0001844C
		private UpdateResult(UpdateResultType type, int waitTicks = 0)
		{
			this._type = type;
			this._waitTicks = waitTicks;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001A25C File Offset: 0x0001845C
		public static UpdateResult Next()
		{
			return new UpdateResult(UpdateResultType.Next, 0);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001A265 File Offset: 0x00018465
		public static UpdateResult Wait(int ticks)
		{
			return new UpdateResult(UpdateResultType.Wait, ticks);
		}

		// Token: 0x04000330 RID: 816
		private readonly UpdateResultType _type;

		// Token: 0x04000331 RID: 817
		private readonly int _waitTicks;
	}
}
