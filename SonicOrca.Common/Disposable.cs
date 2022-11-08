using System;

namespace SonicOrca
{
	// Token: 0x02000003 RID: 3
	public class Disposable : IDisposable
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C9 File Offset: 0x000002C9
		private Disposable(Action action)
		{
			this._action = action;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020D8 File Offset: 0x000002D8
		public void Dispose()
		{
			if (this._action != null)
			{
				this._action();
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020ED File Offset: 0x000002ED
		public static IDisposable FromAction(Action action)
		{
			return new Disposable(action);
		}

		// Token: 0x04000001 RID: 1
		private readonly Action _action;
	}
}
