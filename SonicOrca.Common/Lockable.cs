using System;

namespace SonicOrca
{
	// Token: 0x02000006 RID: 6
	public sealed class Lockable<T> where T : class
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002131 File Offset: 0x00000331
		public Lockable(T instance)
		{
			this._instance = instance;
			this._sync = new object();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000214B File Offset: 0x0000034B
		public T Instance
		{
			get
			{
				return this._instance;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002153 File Offset: 0x00000353
		public object Sync
		{
			get
			{
				return this._sync;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000215B File Offset: 0x0000035B
		public static implicit operator T(Lockable<T> lockable)
		{
			return lockable.Instance;
		}

		// Token: 0x04000002 RID: 2
		private readonly T _instance;

		// Token: 0x04000003 RID: 3
		private readonly object _sync;
	}
}
